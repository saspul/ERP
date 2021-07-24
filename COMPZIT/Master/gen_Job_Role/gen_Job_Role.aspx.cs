using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using CL_Compzit;
using System.Text;
using EL_Compzit;
using System.Data;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Collections;

public partial class Master_gen_Job_Role_Job_Role : System.Web.UI.Page
{
    clsBusinessLayerJobRole objBusinessLayerJobRole = new clsBusinessLayerJobRole();
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
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {          
            //DesignationLoad();
            DropDownBind();
            ddlDesignation.Focus();
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {


            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {


            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }


            //when editing 
            if (Request.QueryString["Id"] != null)
            {

                BindCompzitModules();
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnUpdate.Visible = true;
                btnUpdateClose.Visible = true;

                btnAddF.Visible = false;
                btnAddCloseF.Visible = false;
                btnUpdateF.Visible = true;
                btnUpdateCloseF.Visible = true;
                //divAllocateAll.Visible = false;
                //ddlEmployee.Enabled = false;
              //  ddlDesignation.Enabled = false;
               // ddlJobrole.Enabled = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                UpdateView(strId);

                lblEntry.InnerText = "Edit Job Role ";
                lblEntryB.InnerText = "Edit Job Role ";
                btnClear.Visible = false;
                btnClearF.Visible = false;
            }
            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {

                BindCompzitModules();
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAddF.Visible = false;
                btnAddCloseF.Visible = false;
                btnUpdateF.Visible = false;
                btnUpdateCloseF.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                UpdateView(strId);
               // ddlEmployee.Enabled = false;
                ddlDesignation.Enabled = false;
               // ddlJobrole.Enabled = false;
                txtJobRoleName.Enabled = false;
                cbxStatus.Disabled = true;

                //cbxStatus.Enabled = false;
                //cbxlCompzitModules.Enabled = false;
                //TreeViewCompzit_SalesAutomation.Enabled = false;
                //TreeViewCompzit_GuaranteeManagement.Enabled = false;
                //TreeViewCompzit_AutoWorkshopManagement.Enabled = false;
                //TreeViewCompzit_AppAdminstration.Enabled = false;


                lblEntry.InnerText = "View Job Role ";
                lblEntryB.InnerText = "View Job Role ";
                btnClear.Visible = false;
                btnClearF.Visible = false;
            }

            else
            {


                lblEntry.InnerText = "Add Job Role ";
                lblEntryB.InnerText = "Add Job Role ";
                BindCompzitModules();
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
                btnUpdateF.Visible = false;
                btnUpdateCloseF.Visible = false;
                btnAddF.Visible = true;
                btnAddCloseF.Visible = true;
                //divAllocateAll.Visible = false;
            }

            //Allocating child roles
            //Check 
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Job_role);
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

                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                    {
                        //future

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
    }

    public void BindCompzitModules()
    {
       // clsEntityEmpRoleAllocation objEmpRoleAllocation = new clsEntityEmpRoleAllocation();
        clsEntityLayerJobRole objEntityJobRl = new clsEntityLayerJobRole();

        clsBusinessLayerJobRole objBusinessLayerDsgnMaster = new clsBusinessLayerJobRole();

        DataTable dtModuleDetails = new DataTable();
        if (Session["USERID"] == null)
        {
            Response.Redirect("../../Default.aspx");

        }
        else
        {
            objEntityJobRl.UserID = Convert.ToInt32(Session["USERID"].ToString());
        }
        //BL 
        dtModuleDetails = objBusinessLayerDsgnMaster.DisplayCompzitModuleByUsrId(objEntityJobRl);
        if (dtModuleDetails.Rows.Count > 0)
        {
            divCompzitModuleList.Visible = true;
            divCompzitModuleNoList.Visible = false;
        }
        else
        {

            divCompzitModuleList.Visible = false;
            divCompzitModuleNoList.Visible = true;
        }
    }

    public void DropDownBind(string strDsgnTypeName = null)
    {
        int intUserAppAdminstrtn = 0, intUserComzitSFA = 0, intUserCompzitAWMS = 0, intUserCompzitGMS = 0, intUserCompzitHCM = 0, intUserCompzitFMS = 0, intUserCompzitPMS = 0, intUserId = 0;
        ddlDesignation.Items.Clear();
        clsEntityLayerJobRole objEntityJobRl = null;
        objEntityJobRl = new clsEntityLayerJobRole();
        DataTable dtDsgnTypeDetails = new DataTable();
        if (Session["DSGN_CONTROL"] == null)
        {
            Response.Redirect("../../Default.aspx");

        }
        else
        {
            objEntityJobRl.DsgControl = Convert.ToChar(Session["DSGN_CONTROL"].ToString());
        }
        if (Session["ORGID"] != null)
        {
            objEntityJobRl.DsgnOrgId = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["DSGN_TYPID"] != null)
        {
            objEntityJobRl.DesignationTypeId = Convert.ToInt32(Session["DSGN_TYPID"].ToString());

        }
        else if (Session["DSGN_TYPID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJobRl.UserID = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }



        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        DataTable dtUserAppRole = new DataTable();
        dtUserAppRole = objBusinessLayer.ReadUserAppRoleByUserId(intUserId);

        for (int intRowCountUserAppRole = 0; intRowCountUserAppRole < dtUserAppRole.Rows.Count; intRowCountUserAppRole++)
        {
            int intPrmntzId = Convert.ToInt32(dtUserAppRole.Rows[intRowCountUserAppRole]["PRTZAPP_ID"].ToString());
            if (intPrmntzId == Convert.ToInt32(APPS.APP_ADMINSTRATION))
            {
                intUserAppAdminstrtn = 1;
            }
            else if (intPrmntzId == Convert.ToInt32(APPS.SALES_FORCE_AUTOMATION))
            {
                intUserComzitSFA = 1;
            }
            else if (intPrmntzId == Convert.ToInt32(APPS.AUTO_WORKSHOP_MANAGEMENT_SYSTEM))
            {
                intUserCompzitAWMS = 1;
            }
            else if (intPrmntzId == Convert.ToInt32(APPS.GUARANTEE_MANAGEMENT_SYSTEM))
            {
                intUserCompzitGMS = 1;
            }
            else if (intPrmntzId == Convert.ToInt32(APPS.HUMAN_CAPITAL_MANAGEMENT))
            {
                intUserCompzitHCM = 1;
            }
            else if (intPrmntzId == Convert.ToInt32(APPS.FINANCE_MANAGEMENT_SYSTEM))
            {
                intUserCompzitFMS = 1;
            }
            else if (intPrmntzId == Convert.ToInt32(APPS.PROCUREMENT_MANAGEMENT_SYSTEM))//PMS
            {
                intUserCompzitPMS = 1;
            }

        }
        //BL
        clsBusinessLayerJobRole objBusinessLayerJobRole = new clsBusinessLayerJobRole();
        dtDsgnTypeDetails = objBusinessLayerJobRole.ReadDsgnDetails(objEntityJobRl);

        for (int intRowBodyCount = 0; intRowBodyCount < dtDsgnTypeDetails.Rows.Count; intRowBodyCount++)
        {
            int intDsgnAppAdminstrtn = 0, intDsgnComzitSFA = 0, intDsgnCompzitAWMS = 0, intDsgnCompzitGMS = 0, intDsgnCompzitHCM = 0, intDsgnCompzitFMS = 0, intDsgnCompzitPMS = 0;
            int intDsgId = Convert.ToInt32(dtDsgnTypeDetails.Rows[intRowBodyCount]["DSGN_ID"].ToString());
            objEntityJobRl.DesignationId = intDsgId;
            DataTable dtDsgnAppRole = new DataTable();
            dtDsgnAppRole = objBusinessLayerJobRole.ReadDsgnAppRoleByDsgnId(objEntityJobRl);
            for (int intRowCountDsgnAppRole = 0; intRowCountDsgnAppRole < dtDsgnAppRole.Rows.Count; intRowCountDsgnAppRole++)
            {
                int intPrmntzId = Convert.ToInt32(dtDsgnAppRole.Rows[intRowCountDsgnAppRole]["PRTZAPP_ID"].ToString());
                if (intPrmntzId == Convert.ToInt32(APPS.APP_ADMINSTRATION))
                {
                    intDsgnAppAdminstrtn = 1;
                }
                else if (intPrmntzId == Convert.ToInt32(APPS.SALES_FORCE_AUTOMATION))
                {
                    intDsgnComzitSFA = 1;
                }
                else if (intPrmntzId == Convert.ToInt32(APPS.AUTO_WORKSHOP_MANAGEMENT_SYSTEM))
                {
                    intDsgnCompzitAWMS = 1;
                }
                else if (intPrmntzId == Convert.ToInt32(APPS.GUARANTEE_MANAGEMENT_SYSTEM))
                {
                    intDsgnCompzitGMS = 1;
                }
                else if (intPrmntzId == Convert.ToInt32(APPS.HUMAN_CAPITAL_MANAGEMENT))
                {
                    intDsgnCompzitHCM = 1;
                }
                else if (intPrmntzId == Convert.ToInt32(APPS.FINANCE_MANAGEMENT_SYSTEM))
                {
                    intDsgnCompzitFMS = 1;
                }
                else if (intPrmntzId == Convert.ToInt32(APPS.PROCUREMENT_MANAGEMENT_SYSTEM))//PMS
                {
                    intDsgnCompzitPMS = 1;
                }

            }
            if ((intUserAppAdminstrtn == intDsgnAppAdminstrtn || intUserAppAdminstrtn > intDsgnAppAdminstrtn) && (intUserComzitSFA == intDsgnComzitSFA || intUserComzitSFA > intDsgnComzitSFA) && (intUserCompzitAWMS == intDsgnCompzitAWMS || intUserCompzitAWMS > intDsgnCompzitAWMS) && (intUserCompzitGMS == intDsgnCompzitGMS || intUserCompzitGMS > intDsgnCompzitGMS) && (intUserCompzitHCM == intDsgnCompzitHCM || intUserCompzitHCM > intDsgnCompzitHCM) && (intUserCompzitFMS == intDsgnCompzitFMS || intUserCompzitFMS > intDsgnCompzitFMS) && (intUserCompzitPMS == intDsgnCompzitPMS || intUserCompzitPMS > intDsgnCompzitPMS))
            {
                //bind one by one here

            }
            else
            {
                DataRow dr = dtDsgnTypeDetails.Rows[intRowBodyCount];
                dr.Delete();
            }

        }

        ddlDesignation.DataSource = dtDsgnTypeDetails;
        ddlDesignation.DataTextField = "DSGN_NAME";


        ddlDesignation.DataValueField = "DSGN_ID";
        ddlDesignation.DataBind();
        ddlDesignation.Items.Insert(0, "--Select Designation--");
        if (strDsgnTypeName != null)
        {
            if (ddlDesignation.Items.FindByText(strDsgnTypeName) != null)
            {
                ddlDesignation.Items.FindByText(strDsgnTypeName).Selected = true;
            }
        }
    }





    public void Treefill(char charDsgTypCntrl)
    {
        int intUserLimited = Convert.ToInt32(USERLIMITED.ISLIMITED);
        int intUserId = 0;
       // clsEntityEmpRoleAllocation objEmpRoleAllocation = new clsEntityEmpRoleAllocation();
        clsEntityLayerJobRole objEntityJobRl = new clsEntityLayerJobRole();

        clsBusinessLayerJobRole objBusinessLayerDsgnMaster = new clsBusinessLayerJobRole();


        DataTable dtUserDetails = new DataTable();
        if (Session["USERID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        else
        {
            objEntityJobRl.UserID = Convert.ToInt32(Session["USERID"].ToString());
            // objEmpRoleAllocation.UserId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
            intUserId = objEntityJobRl.UserID;
        }
        //BL
        dtUserDetails = objBusinessLayerDsgnMaster.ReadIfUserLimitedByUsrId(objEntityJobRl);
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
        Treefill_CRM_PMS(charDsgTypCntrl, intUserLimited, intUserId);

    }
    public void Treefill_CRM_App(char charDsgTypCntrl, Int32 intUserLimited, Int32 intUserId)
    {
        treeApp.InnerHtml = "";
        treeSfa.InnerHtml = "";
        treeAwms.InnerHtml = "";
        treeGms.InnerHtml = "";
        treeHcm.InnerHtml = "";
        treeFms.InnerHtml = "";
        treePms.InnerHtml = "";

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
       // clsEntityEmpRoleAllocation objEmpRoleAllocation = new clsEntityEmpRoleAllocation();

        clsEntityLayerJobRole objEntityJobRl = new clsEntityLayerJobRole();

        clsBusinessLayerJobRole objBusinessLayerDsgnMaster = new clsBusinessLayerJobRole();




        objEntityJobRl.ParentId = 0;
        objEntityJobRl.AppId = intAppId;
        objEntityJobRl.AppType = chAppType;
        objEntityJobRl.DsgControl = charUsrolCntrl;
        objEntityJobRl.UserID= intUserId;
        objEntityJobRl.UserLimited = intUserLimited;
        DataTable dt = new DataTable();
        if (Session["FRMWRK_TYPE"] != null && Session["FRMWRK_TYPE"].ToString() == "1")
        {
            if (Session["FRMWRK_ID"] != null)
            {
                objEntityJobRl.CorpOfficeId = Convert.ToInt32(Session["FRMWRK_ID"].ToString());
            }
            dt = objBusinessLayerDsgnMaster.DisplayUserolMstrFramewrk(objEntityJobRl);
        }
        else
        {
            dt = objBusinessLayerDsgnMaster.DisplayUserolMstr(objEntityJobRl);
        }

        if (Appsid == APPS.APP_ADMINSTRATION)
        {
            treeApp.InnerHtml = PopulateNodes(dt, intAppId, chAppType, charUsrolCntrl, intUserLimited, intUserId, 1);
        }
        else if (Appsid == APPS.SALES_FORCE_AUTOMATION)
        {
            treeSfa.InnerHtml = PopulateNodes(dt, intAppId, chAppType, charUsrolCntrl, intUserLimited, intUserId, 1);
        }
        else if (Appsid == APPS.AUTO_WORKSHOP_MANAGEMENT_SYSTEM)
        {
            treeAwms.InnerHtml = PopulateNodes(dt, intAppId, chAppType, charUsrolCntrl, intUserLimited, intUserId, 1);
        }
        else if (Appsid == APPS.GUARANTEE_MANAGEMENT_SYSTEM)
        {
            treeGms.InnerHtml = PopulateNodes(dt, intAppId, chAppType, charUsrolCntrl, intUserLimited, intUserId, 1);
        }
        else if (Appsid == APPS.HUMAN_CAPITAL_MANAGEMENT)
        {
            treeHcm.InnerHtml = PopulateNodes(dt, intAppId, chAppType, charUsrolCntrl, intUserLimited, intUserId, 1);
        }
        else if (Appsid == APPS.FINANCE_MANAGEMENT_SYSTEM)
        {
            treeFms.InnerHtml = PopulateNodes(dt, intAppId, chAppType, charUsrolCntrl, intUserLimited, intUserId, 1);
        }
        else if (Appsid == APPS.PROCUREMENT_MANAGEMENT_SYSTEM)//PMS
        {
            treePms.InnerHtml = PopulateNodes(dt, intAppId, chAppType, charUsrolCntrl, intUserLimited, intUserId, 1);
        }

    }

    private string PopulateSubLevel(int parentid, int intAppId, char chAppType, char charUsrolCntrl, Int32 intUserLimited, Int32 intUserId)
    { //Created objects for business layer


        clsEntityLayerJobRole objEntityJobRl = new clsEntityLayerJobRole();

        clsBusinessLayerJobRole objBusinessLayerDsgnMaster = new clsBusinessLayerJobRole();

        objEntityJobRl.ParentId = parentid;
        objEntityJobRl.AppId = intAppId;
        objEntityJobRl.AppType = chAppType;
        objEntityJobRl.DsgControl = charUsrolCntrl;
        objEntityJobRl.UserID = intUserId;
        objEntityJobRl.UserLimited = intUserLimited;
        DataTable dt = new DataTable();
        if (Session["FRMWRK_TYPE"] != null && Session["FRMWRK_TYPE"].ToString() == "1")
        {
            if (Session["FRMWRK_ID"] != null)
            {
                objEntityJobRl.CorpOfficeId = Convert.ToInt32(Session["FRMWRK_ID"].ToString());
            }
            dt = objBusinessLayerDsgnMaster.DisplayUserolMstrFramewrk(objEntityJobRl);
        }
        else
        {
            dt = objBusinessLayerDsgnMaster.DisplayUserolMstr(objEntityJobRl);
        }
        return PopulateNodes(dt, intAppId, chAppType, charUsrolCntrl, intUserLimited, intUserId, 2);
    }

    private string PopulateNodes(DataTable dt, int intAppId, char chAppType, char charUsrolCntrl, Int32 intUserLimited, Int32 intUserId, Int32 lev)
    {
        string strHtml = "";
        foreach (DataRow dr in dt.Rows)
        {
            int intUsrRolMstrId, intLimitedEnableAdd = 0, intLimitedEnableModify = 0, intLimitedEnableCancel = 0, intLimitedEnableFind = 0, intLimitedEnableRateUpdation = 0;
            int intLimitedEnableConfirm = 0, intLimitedEnableApprove = 0, intLimitedEnableReOpen = 0, intLimitedEnableReturn = 0, intLimitedEnableWin = 0, intLimitedEnableLoss = 0;
            int intLimitedEnableAllocate = 0, intLimitedEnableAllMails = 0, intLimitedEnableMailAllocate = 0, intLimitedEnableMailForword = 0, intLimitedEnableMailAttach = 0, intLimitedEnableClose = 0, intLimitedEnableSuplier_Guarantee_Permission = 0, intLimitedEnableClient_Guarantee_Permission = 0;
            int intLimitedEnableRenew = 0, intLimitedEnableHRallocation = 0, intLimitedEnableSelfAllocation = 0, intLimitedEditAllocation = 0, intLimitedGMAllocation = 0;
            int intLimitedEnableReissue = 0, intLimitedEnableOnHold = 0, intLimitedEnableBussinessunit = 0, intLimitedAllDivision = 0, intLimitedFmsAudit = 0, intAccountSecific = 0, intBusinessSecific = 0, intLimitedFmsAccount = 0, intDiscount = 0, intFiscalYrEdit = 0, intAdministrator_Privileges = 0, intRecurring = 0, intChequePrint = 0;  //evm-0023-05-04-19
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            if (lev == 1)
            {
                strHtml += "<ul>";
            }
            else
            {
                strHtml += "<ul class=\"uilist\">";
            }
            strHtml += "<li>";
            strHtml += "<i class=\"button-checkbox\">";
            strHtml += "<button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
            strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "\" type=\"checkbox\" class=\"hidden\">";
            strHtml += "</i>";
            strHtml += "<span>" + dr["USROL_NAME"].ToString() + "</span>";

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
                strHtml += "<ul class=\"uilist\">";
                string strChildDef = dr["USROL_CHLDRL_DEFN"].ToString();
                // Split string on spaces.
                // ... This will separate all the words.
                string[] strChildDefArrWords = strChildDef.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>ADD</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>MODIFY</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>CANCEL</span>";
                        strHtml += " </li>";

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableFind == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>FIND</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableRateUpdation == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>RATE UPDATION</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>CONFIRM</span>";
                        strHtml += " </li>";
                    }

                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableApprove == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>DM ALLOCATION</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableReOpen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>RE-OPEN</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Return).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Return).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableReturn == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Return).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>RETURN</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Win).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Win).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableWin == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Win).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>WIN</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Loss).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Loss).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableLoss == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Loss).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>LOSS</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Allocate).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Allocate).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableAllocate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Allocate).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>ALLOCATE</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.All_Mails).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.All_Mails).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableAllMails == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.All_Mails).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>VIEW ALL MAILS</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Allocate).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Allocate).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableMailAllocate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Allocate).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>MAIL ALLOCATE</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Forward).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Forward).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableMailForword == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Forward).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>MAIL FORWARD</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Attach).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Attach).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableMailAttach == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Attach).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>LEAD ATTACH</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableClose == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>CLOSE</span>";
                        strHtml += " </li>";
                    }

                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Suplier_Guarantee_Permission).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Suplier_Guarantee_Permission).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableSuplier_Guarantee_Permission == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Suplier_Guarantee_Permission).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>SUPPLIER_GUARANTEE</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Client_Guarantee_Permission).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Client_Guarantee_Permission).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableClient_Guarantee_Permission == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Client_Guarantee_Permission).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>CLIENT_GUARANTEE</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Renew).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Renew).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableRenew == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Renew).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>RENEW</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableHRallocation == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>HR ALLOCATION</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Self_Allocation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Self_Allocation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableSelfAllocation == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Self_Allocation).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>SELF ALLOCATION</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Edit_Allocation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Edit_Allocation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEditAllocation == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Edit_Allocation).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>EDIT ALLOCATION</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Reissue).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Reissue).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableReissue == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Reissue).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>REISSUE</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.GM_Allocation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.GM_Allocation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedGMAllocation == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.GM_Allocation).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>GM ALLOCATION</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.OnHold).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.OnHold).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableOnHold == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.OnHold).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>ON HOLD</span>";
                        strHtml += " </li>";
                    }

                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_BUSINESS_UNIT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_BUSINESS_UNIT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableBussinessunit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_BUSINESS_UNIT).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>ALL BUSINESS UNIT</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_DIVISION).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_DIVISION).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedAllDivision == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_DIVISION).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>ALL DIVISION</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_ACCOUNT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedFmsAccount == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_ACCOUNT).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>ACCOUNT</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedFmsAudit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>AUDIT</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ACCOUNT_SPECIFIC).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ACCOUNT_SPECIFIC).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intAccountSecific == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {

                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.ACCOUNT_SPECIFIC).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>ACCOUNT SPECIFIC</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.BUSINESS_SPECIFIC).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.BUSINESS_SPECIFIC).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intBusinessSecific == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {

                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.BUSINESS_SPECIFIC).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>BUSINESS SPECIFIC</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.DISCOUNT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.DISCOUNT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intDiscount == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {

                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.DISCOUNT).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>DISCOUNT</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FINANCL_YR_EDIT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FINANCL_YR_EDIT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intFiscalYrEdit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {

                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.FINANCL_YR_EDIT).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>FINANCIAL YEAR EDIT</span>";
                        strHtml += " </li>";
                    }

                        //evm-0023-05-04-19
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Administrator_Privileges).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Administrator_Privileges).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intAdministrator_Privileges == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {

                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Administrator_Privileges).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>ADMINISTRATOR PRIVILEGES</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Recurring).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Recurring).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intRecurring == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {

                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Recurring).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>RECURRING</span>";
                        strHtml += " </li>";
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cheque_Print).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cheque_Print).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intChequePrint == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {

                        strHtml += " <li>";
                        strHtml += "<i class=\"button-checkbox\">";
                        strHtml += " <button type=\"button\" class=\"active btn-d\" data-color=\"p\" onclick=\"myFunct()\" ng-model=\"all\"><i class=\"state-icon fa fa-square-o gly2\"></i>&nbsp;</button>";
                        strHtml += "<input value=\"" + dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Cheque_Print).ToString() + "\" type=\"checkbox\" class=\"hidden\">";
                        strHtml += " </i>";
                        strHtml += " <span>CHEQUE PRINT</span>";
                        strHtml += " </li>";
                    }
                }
                strHtml += "</ul>";
                // PopulateSubLevel(Convert.ToInt32(dr["USROL_ID"].ToString()), tn);

            }

            if (Convert.ToInt32(dr["childnodecount"].ToString()) > 0)
            {
                strHtml += PopulateSubLevel(Convert.ToInt32(dr["USROL_ID"].ToString()), intAppId, chAppType, charUsrolCntrl, intUserLimited, intUserId);

            }
            strHtml += "</li>";
            strHtml += "</ul>";
        }
        return strHtml;
    }


 




    protected void btnAdd_Click(object sender, EventArgs e)
    {

        int intTreeAppAdminVisible = 0, intTreeSFAVisible = 0, intTreeAWMSVisible = 0, intTreeGMSVisible = 0, intTreeHCMVisible = 0, intTreeFMSVisible = 0, intTreePMSVisible = 0;
        Button clickedButton = sender as Button;

        List<clsEntityLayerJobRlAppRole> objlisJobRlAppRol = new List<clsEntityLayerJobRlAppRole>();

        string[] app = HiddenFieldAppChecked.Value.Split(',');

        foreach (string itemCheckBoxModules in app)
        {

            if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
            {
                clsEntityLayerJobRlAppRole objJobRlAppRol = new clsEntityLayerJobRlAppRole();

                // If the item is selected.

                if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.APP_ADMINSTRATION))
                {
                    intTreeAppAdminVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.SALES_FORCE_AUTOMATION))
                {
                    intTreeSFAVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.AUTO_WORKSHOP_MANAGEMENT_SYSTEM))
                {
                    intTreeAWMSVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.GUARANTEE_MANAGEMENT_SYSTEM))
                {
                    intTreeGMSVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.HUMAN_CAPITAL_MANAGEMENT))
                {
                    intTreeHCMVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.FINANCE_MANAGEMENT_SYSTEM))
                {
                    intTreeFMSVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.PROCUREMENT_MANAGEMENT_SYSTEM))
                {
                    intTreePMSVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }

                objJobRlAppRol.App_Id = Convert.ToInt32(itemCheckBoxModules);
                objlisJobRlAppRol.Add(objJobRlAppRol);
            }
            else
            {
                // Item is not selected, do something else.
            }
        }



        List<clsEntityLayerJobRlRole> objlisDsgnRol = new List<clsEntityLayerJobRlRole>();

        clsEntityLayerJobRole objEntityJobRl = null;
        objEntityJobRl = new clsEntityLayerJobRole();
        objEntityJobRl.JobRoleName = txtJobRoleName.Text.ToUpper().Trim();

            if (Session["CORPOFFICEID"] != null)
            {

                objEntityJobRl.CorpOfficeId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        
        if (Session["ORGID"] != null)
        {

            objEntityJobRl.DsgnOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        string strNameCount = objBusinessLayerJobRole.CheckDupJobRlNameIns(objEntityJobRl);

        if (strNameCount == "0")
        {
            if (Session["USERID"] != null)
            {
                objEntityJobRl.UserID = Convert.ToInt32(Session["USERID"].ToString());

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityJobRl.NextId = Convert.ToInt32(clsCommonLibrary.MasterId.Job_Role);

            DataTable dtNextId = objBusinessLayerJobRole.ReadNextId(objEntityJobRl);
            objEntityJobRl.JobRoleId = Convert.ToInt32(dtNextId.Rows[0]["MST_NEXT_VALUE"]);
            objEntityJobRl.DesignationId = Convert.ToInt32(ddlDesignation.SelectedItem.Value);

            objEntityJobRl.DsgnPrimary = Convert.ToInt32(clsCommonLibrary.DesignationType.NonPrimary);
            objEntityJobRl.DsgControl = objBusinessLayerJobRole.ReadDsgnControl(objEntityJobRl);
            if (cbxStatus.Checked)
            {
                objEntityJobRl.JobRoleStatus = 1;
            }
            else
            {
                objEntityJobRl.JobRoleStatus = 0;
            }



            if (intTreeAppAdminVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

                string[] appS = HiddenFieldApp.Value.Split(',');
                if (appS.Length > 0)
                {


                    List<clsEntityLayerJobRlRole> objlisDsgnRolMainDtls_AppAdmin = new List<clsEntityLayerJobRlRole>();
                    List<clsEntityLayerJobRlRole> objlisDsgnRolChildrenDtls_AppAdmin = new List<clsEntityLayerJobRlRole>();
                    foreach (string itemCheckBoxModules in appS)
                    {

                        if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                        {
                            clsEntityLayerJobRlRole objEntityDsgnRole = null;
                            objEntityDsgnRole = new clsEntityLayerJobRlRole();

                            string[] strchild = itemCheckBoxModules.Split('.');

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

                    }
                    
                        List<clsEntityLayerJobRlRole> objlisDsgnRolAppAdministration = new List<clsEntityLayerJobRlRole>();
                        objlisDsgnRolAppAdministration = Merge(objlisDsgnRolMainDtls_AppAdmin, objlisDsgnRolChildrenDtls_AppAdmin);

                        foreach (clsEntityLayerJobRlRole objDsgnRol in objlisDsgnRolAppAdministration)
                        {
                            objlisDsgnRol.Add(objDsgnRol);
                        }

                    
                }
                else
                {
                    // lblSelectedNodes.Text = "Select Node(s).";
                }

            }
            if (intTreeSFAVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                 string[] appS = HiddenFieldSfa.Value.Split(',');
                   if (appS.Length > 0)
            
                {


                    List<clsEntityLayerJobRlRole> objlisDsgnRolMainDtls_SFA = new List<clsEntityLayerJobRlRole>();
                    List<clsEntityLayerJobRlRole> objlisDsgnRolChildrenDtls_SFA = new List<clsEntityLayerJobRlRole>();
                    foreach (string itemCheckBoxModules in appS)
                    {

                        if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                        {

                            clsEntityLayerJobRlRole objEntityDsgnRole = null;
                            objEntityDsgnRole = new clsEntityLayerJobRlRole();

                            string[] strchild = itemCheckBoxModules.Split('.');
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

                    }
                    List<clsEntityLayerJobRlRole> objlisDsgnRolSFA = new List<clsEntityLayerJobRlRole>();
                    objlisDsgnRolSFA = Merge(objlisDsgnRolMainDtls_SFA, objlisDsgnRolChildrenDtls_SFA);

                    foreach (clsEntityLayerJobRlRole objDsgnRol in objlisDsgnRolSFA)
                    {
                        objlisDsgnRol.Add(objDsgnRol);
                    }

                }
                else
                {
                    // lblSelectedNodes.Text = "Select Node(s).";
                }
            }
            if (intTreeAWMSVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                string[] appS = HiddenFieldAwms.Value.Split(',');
                if (appS.Length > 0)
                {


                    List<clsEntityLayerJobRlRole> objlisDsgnRolMainDtls_WMS = new List<clsEntityLayerJobRlRole>();
                    List<clsEntityLayerJobRlRole> objlisDsgnRolChildrenDtls_WMS = new List<clsEntityLayerJobRlRole>();
                    foreach (string itemCheckBoxModules in appS)
                    {

                        if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                        {
                            clsEntityLayerJobRlRole objEntityDsgnRole = null;
                            objEntityDsgnRole = new clsEntityLayerJobRlRole();

                            string[] strchild = itemCheckBoxModules.Split('.');
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
                    }

                    List<clsEntityLayerJobRlRole> objlisDsgnRolWMS = new List<clsEntityLayerJobRlRole>();
                    objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_WMS, objlisDsgnRolChildrenDtls_WMS);

                    foreach (clsEntityLayerJobRlRole objDsgnRol in objlisDsgnRolWMS)
                    {
                        objlisDsgnRol.Add(objDsgnRol);
                    }

                }
                else
                {
                    // lblSelectedNodes.Text = "Select Node(s).";
                }
            }
            if (intTreeGMSVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                string[] appS = HiddenFieldGms.Value.Split(',');
                if (appS.Length > 0)
                {


                    List<clsEntityLayerJobRlRole> objlisDsgnRolMainDtls_GMS = new List<clsEntityLayerJobRlRole>();
                    List<clsEntityLayerJobRlRole> objlisDsgnRolChildrenDtls_GMS = new List<clsEntityLayerJobRlRole>();
                    foreach (string itemCheckBoxModules in appS)
                    {
                        if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                        {
                            clsEntityLayerJobRlRole objEntityDsgnRole = null;
                            objEntityDsgnRole = new clsEntityLayerJobRlRole();

                            string[] strchild = itemCheckBoxModules.Split('.');
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
                    }

                    List<clsEntityLayerJobRlRole> objlisDsgnRolWMS = new List<clsEntityLayerJobRlRole>();
                    objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_GMS, objlisDsgnRolChildrenDtls_GMS);

                    foreach (clsEntityLayerJobRlRole objDsgnRol in objlisDsgnRolWMS)
                    {
                        objlisDsgnRol.Add(objDsgnRol);
                    }

                }
                else
                {
                    // lblSelectedNodes.Text = "Select Node(s).";
                }
            }
            if (intTreeHCMVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                string[] appS = HiddenFieldHcm.Value.Split(',');
                if (appS.Length > 0)
                {


                    List<clsEntityLayerJobRlRole> objlisDsgnRolMainDtls_HCM = new List<clsEntityLayerJobRlRole>();
                    List<clsEntityLayerJobRlRole> objlisDsgnRolChildrenDtls_HCM = new List<clsEntityLayerJobRlRole>();
                    foreach (string itemCheckBoxModules in appS)
                    {
                        if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                        {
                            clsEntityLayerJobRlRole objEntityDsgnRole = null;
                            objEntityDsgnRole = new clsEntityLayerJobRlRole();

                            string[] strchild = itemCheckBoxModules.Split('.');
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
                    }

                    List<clsEntityLayerJobRlRole> objlisDsgnRolWMS = new List<clsEntityLayerJobRlRole>();
                    objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_HCM, objlisDsgnRolChildrenDtls_HCM);

                    foreach (clsEntityLayerJobRlRole objDsgnRol in objlisDsgnRolWMS)
                    {
                        objlisDsgnRol.Add(objDsgnRol);
                    }

                }
                else
                {
                    // lblSelectedNodes.Text = "Select Node(s).";
                }
            }
            if (intTreeFMSVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                string[] appS = HiddenFieldFms.Value.Split(',');
                if (appS.Length > 0)
                {



                    List<clsEntityLayerJobRlRole> objlisDsgnRolMainDtls_FMS = new List<clsEntityLayerJobRlRole>();
                    List<clsEntityLayerJobRlRole> objlisDsgnRolChildrenDtls_FMS = new List<clsEntityLayerJobRlRole>();
                    foreach (string itemCheckBoxModules in appS)
                    {

                        if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                        {
                            clsEntityLayerJobRlRole objEntityDsgnRole = null;
                            objEntityDsgnRole = new clsEntityLayerJobRlRole();

                            string[] strchild = itemCheckBoxModules.Split('.');
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
                    }

                    List<clsEntityLayerJobRlRole> objlisDsgnRolWMS = new List<clsEntityLayerJobRlRole>();
                    objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_FMS, objlisDsgnRolChildrenDtls_FMS);

                    foreach (clsEntityLayerJobRlRole objDsgnRol in objlisDsgnRolWMS)
                    {
                        objlisDsgnRol.Add(objDsgnRol);
                    }

                }
                else
                {
                    // lblSelectedNodes.Text = "Select Node(s).";
                }
            }

            if (intTreePMSVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                string[] appS = HiddenFieldPms.Value.Split(',');
                if (appS.Length > 0)
                {


                    List<clsEntityLayerJobRlRole> objlisDsgnRolMainDtls_PMS = new List<clsEntityLayerJobRlRole>();
                    List<clsEntityLayerJobRlRole> objlisDsgnRolChildrenDtls_PMS = new List<clsEntityLayerJobRlRole>();
                    foreach (string itemCheckBoxModules in appS)
                    {
                        if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                        {
                            clsEntityLayerJobRlRole objEntityDsgnRole = null;
                            objEntityDsgnRole = new clsEntityLayerJobRlRole();

                            string[] strchild = itemCheckBoxModules.Split('.');
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

                    }
                    List<clsEntityLayerJobRlRole> objlisDsgnRolWMS = new List<clsEntityLayerJobRlRole>();
                    objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_PMS, objlisDsgnRolChildrenDtls_PMS);

                    foreach (clsEntityLayerJobRlRole objDsgnRol in objlisDsgnRolWMS)
                    {
                        objlisDsgnRol.Add(objDsgnRol);
                    }

                }
                else
                {
                    // lblSelectedNodes.Text = "Select Node(s).";
                }
            }


            objBusinessLayerJobRole.InsertJobRlDetail(objEntityJobRl, objlisDsgnRol, objlisJobRlAppRol);


            if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddF")
            {
                Response.Redirect("gen_Job_Role.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose" || clickedButton.ID == "btnAddCloseF")
            {
                Response.Redirect("gen_Job_Role_List.aspx?InsUpd=Ins");
            }



        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtJobRoleName.Focus();
        }

    }



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


    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        int intTreeAppAdminVisible = 0, intTreeSFAVisible = 0, intTreeAWMSVisible = 0, intTreeGMSVisible = 0, intTreeHCMVisible = 0, intTreeFMSVisible = 0, intTreePMSVisible = 0;
        Button clickedButton = sender as Button;

        List<clsEntityLayerJobRlAppRole> objlisJobRlAppRol = new List<clsEntityLayerJobRlAppRole>();

        string[] app = HiddenFieldAppChecked.Value.Split(',');

        foreach (string itemCheckBoxModules in app)
        {

            if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
            {
                clsEntityLayerJobRlAppRole objJobRlAppRol = new clsEntityLayerJobRlAppRole();

                // If the item is selected.

                if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.APP_ADMINSTRATION))
                {
                    intTreeAppAdminVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.SALES_FORCE_AUTOMATION))
                {
                    intTreeSFAVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.AUTO_WORKSHOP_MANAGEMENT_SYSTEM))
                {
                    intTreeAWMSVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.GUARANTEE_MANAGEMENT_SYSTEM))
                {
                    intTreeGMSVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.HUMAN_CAPITAL_MANAGEMENT))
                {
                    intTreeHCMVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.FINANCE_MANAGEMENT_SYSTEM))
                {
                    intTreeFMSVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (Convert.ToInt32(itemCheckBoxModules) == Convert.ToInt32(APPS.PROCUREMENT_MANAGEMENT_SYSTEM))
                {
                    intTreePMSVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }

                objJobRlAppRol.App_Id = Convert.ToInt32(itemCheckBoxModules);
                objlisJobRlAppRol.Add(objJobRlAppRol);
            }
            else
            {
                // Item is not selected, do something else.
            }
        }



        List<clsEntityLayerJobRlRole> objlisDsgnRol = new List<clsEntityLayerJobRlRole>();

        clsEntityLayerJobRole objEntityJobRl = null;
        objEntityJobRl = new clsEntityLayerJobRole();
        objEntityJobRl.JobRoleName = txtJobRoleName.Text.ToUpper().Trim();

        if (Session["CORPOFFICEID"] != null)
        {

            objEntityJobRl.CorpOfficeId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {

            objEntityJobRl.DsgnOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Request.QueryString["Id"] != null)
        {
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityJobRl.JobRoleId = Convert.ToInt32(strId);

        }

        string strNameCount = objBusinessLayerJobRole.CheckDupJobRlNameUpd(objEntityJobRl);

        if (strNameCount == "0")
        {
            if (Session["USERID"] != null)
            {
                objEntityJobRl.UserID = Convert.ToInt32(Session["USERID"].ToString());

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityJobRl.NextId = Convert.ToInt32(clsCommonLibrary.MasterId.Job_Role);

            //DataTable dtNextId = objBusinessLayerJobRole.ReadNextId(objEntityJobRl);
            //objEntityJobRl.JobRoleId = Convert.ToInt32(dtNextId.Rows[0]["MST_NEXT_VALUE"]);
            objEntityJobRl.DesignationId = Convert.ToInt32(ddlDesignation.SelectedItem.Value);

            objEntityJobRl.DsgnPrimary = Convert.ToInt32(clsCommonLibrary.DesignationType.NonPrimary);
            objEntityJobRl.DsgControl = objBusinessLayerJobRole.ReadDsgnControl(objEntityJobRl);
            if (cbxStatus.Checked)
            {
                objEntityJobRl.JobRoleStatus = 1;
            }
            else
            {
                objEntityJobRl.JobRoleStatus = 0;
            }



            if (intTreeAppAdminVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

                string[] appS = HiddenFieldApp.Value.Split(',');
                if (appS.Length > 0)
                {


                    List<clsEntityLayerJobRlRole> objlisDsgnRolMainDtls_AppAdmin = new List<clsEntityLayerJobRlRole>();
                    List<clsEntityLayerJobRlRole> objlisDsgnRolChildrenDtls_AppAdmin = new List<clsEntityLayerJobRlRole>();
                    foreach (string itemCheckBoxModules in appS)
                    {

                        if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                        {
                            clsEntityLayerJobRlRole objEntityDsgnRole = null;
                            objEntityDsgnRole = new clsEntityLayerJobRlRole();

                            string[] strchild = itemCheckBoxModules.Split('.');

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

                    }

                    List<clsEntityLayerJobRlRole> objlisDsgnRolAppAdministration = new List<clsEntityLayerJobRlRole>();
                    objlisDsgnRolAppAdministration = Merge(objlisDsgnRolMainDtls_AppAdmin, objlisDsgnRolChildrenDtls_AppAdmin);

                    foreach (clsEntityLayerJobRlRole objDsgnRol in objlisDsgnRolAppAdministration)
                    {
                        objlisDsgnRol.Add(objDsgnRol);
                    }


                }
                else
                {
                    // lblSelectedNodes.Text = "Select Node(s).";
                }

            }
            if (intTreeSFAVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                string[] appS = HiddenFieldSfa.Value.Split(',');
                if (appS.Length > 0)
                {


                    List<clsEntityLayerJobRlRole> objlisDsgnRolMainDtls_SFA = new List<clsEntityLayerJobRlRole>();
                    List<clsEntityLayerJobRlRole> objlisDsgnRolChildrenDtls_SFA = new List<clsEntityLayerJobRlRole>();
                    foreach (string itemCheckBoxModules in appS)
                    {

                        if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                        {

                            clsEntityLayerJobRlRole objEntityDsgnRole = null;
                            objEntityDsgnRole = new clsEntityLayerJobRlRole();

                            string[] strchild = itemCheckBoxModules.Split('.');
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

                    }
                    List<clsEntityLayerJobRlRole> objlisDsgnRolSFA = new List<clsEntityLayerJobRlRole>();
                    objlisDsgnRolSFA = Merge(objlisDsgnRolMainDtls_SFA, objlisDsgnRolChildrenDtls_SFA);

                    foreach (clsEntityLayerJobRlRole objDsgnRol in objlisDsgnRolSFA)
                    {
                        objlisDsgnRol.Add(objDsgnRol);
                    }

                }
                else
                {
                    // lblSelectedNodes.Text = "Select Node(s).";
                }
            }
            if (intTreeAWMSVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                string[] appS = HiddenFieldAwms.Value.Split(',');
                if (appS.Length > 0)
                {


                    List<clsEntityLayerJobRlRole> objlisDsgnRolMainDtls_WMS = new List<clsEntityLayerJobRlRole>();
                    List<clsEntityLayerJobRlRole> objlisDsgnRolChildrenDtls_WMS = new List<clsEntityLayerJobRlRole>();
                    foreach (string itemCheckBoxModules in appS)
                    {

                        if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                        {
                            clsEntityLayerJobRlRole objEntityDsgnRole = null;
                            objEntityDsgnRole = new clsEntityLayerJobRlRole();

                            string[] strchild = itemCheckBoxModules.Split('.');
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
                    }

                    List<clsEntityLayerJobRlRole> objlisDsgnRolWMS = new List<clsEntityLayerJobRlRole>();
                    objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_WMS, objlisDsgnRolChildrenDtls_WMS);

                    foreach (clsEntityLayerJobRlRole objDsgnRol in objlisDsgnRolWMS)
                    {
                        objlisDsgnRol.Add(objDsgnRol);
                    }

                }
                else
                {
                    // lblSelectedNodes.Text = "Select Node(s).";
                }
            }
            if (intTreeGMSVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                string[] appS = HiddenFieldGms.Value.Split(',');
                if (appS.Length > 0)
                {


                    List<clsEntityLayerJobRlRole> objlisDsgnRolMainDtls_GMS = new List<clsEntityLayerJobRlRole>();
                    List<clsEntityLayerJobRlRole> objlisDsgnRolChildrenDtls_GMS = new List<clsEntityLayerJobRlRole>();
                    foreach (string itemCheckBoxModules in appS)
                    {
                        if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                        {
                            clsEntityLayerJobRlRole objEntityDsgnRole = null;
                            objEntityDsgnRole = new clsEntityLayerJobRlRole();

                            string[] strchild = itemCheckBoxModules.Split('.');
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
                    }

                    List<clsEntityLayerJobRlRole> objlisDsgnRolWMS = new List<clsEntityLayerJobRlRole>();
                    objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_GMS, objlisDsgnRolChildrenDtls_GMS);

                    foreach (clsEntityLayerJobRlRole objDsgnRol in objlisDsgnRolWMS)
                    {
                        objlisDsgnRol.Add(objDsgnRol);
                    }

                }
                else
                {
                    // lblSelectedNodes.Text = "Select Node(s).";
                }
            }
            if (intTreeHCMVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                string[] appS = HiddenFieldHcm.Value.Split(',');
                if (appS.Length > 0)
                {


                    List<clsEntityLayerJobRlRole> objlisDsgnRolMainDtls_HCM = new List<clsEntityLayerJobRlRole>();
                    List<clsEntityLayerJobRlRole> objlisDsgnRolChildrenDtls_HCM = new List<clsEntityLayerJobRlRole>();
                    foreach (string itemCheckBoxModules in appS)
                    {
                        if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                        {
                            clsEntityLayerJobRlRole objEntityDsgnRole = null;
                            objEntityDsgnRole = new clsEntityLayerJobRlRole();

                            string[] strchild = itemCheckBoxModules.Split('.');
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
                    }

                    List<clsEntityLayerJobRlRole> objlisDsgnRolWMS = new List<clsEntityLayerJobRlRole>();
                    objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_HCM, objlisDsgnRolChildrenDtls_HCM);

                    foreach (clsEntityLayerJobRlRole objDsgnRol in objlisDsgnRolWMS)
                    {
                        objlisDsgnRol.Add(objDsgnRol);
                    }

                }
                else
                {
                    // lblSelectedNodes.Text = "Select Node(s).";
                }
            }
            if (intTreeFMSVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                string[] appS = HiddenFieldFms.Value.Split(',');
                if (appS.Length > 0)
                {



                    List<clsEntityLayerJobRlRole> objlisDsgnRolMainDtls_FMS = new List<clsEntityLayerJobRlRole>();
                    List<clsEntityLayerJobRlRole> objlisDsgnRolChildrenDtls_FMS = new List<clsEntityLayerJobRlRole>();
                    foreach (string itemCheckBoxModules in appS)
                    {

                        if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                        {
                            clsEntityLayerJobRlRole objEntityDsgnRole = null;
                            objEntityDsgnRole = new clsEntityLayerJobRlRole();

                            string[] strchild = itemCheckBoxModules.Split('.');
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
                    }

                    List<clsEntityLayerJobRlRole> objlisDsgnRolWMS = new List<clsEntityLayerJobRlRole>();
                    objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_FMS, objlisDsgnRolChildrenDtls_FMS);

                    foreach (clsEntityLayerJobRlRole objDsgnRol in objlisDsgnRolWMS)
                    {
                        objlisDsgnRol.Add(objDsgnRol);
                    }

                }
                else
                {
                    // lblSelectedNodes.Text = "Select Node(s).";
                }
            }

            if (intTreePMSVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                string[] appS = HiddenFieldPms.Value.Split(',');
                if (appS.Length > 0)
                {


                    List<clsEntityLayerJobRlRole> objlisDsgnRolMainDtls_PMS = new List<clsEntityLayerJobRlRole>();
                    List<clsEntityLayerJobRlRole> objlisDsgnRolChildrenDtls_PMS = new List<clsEntityLayerJobRlRole>();
                    foreach (string itemCheckBoxModules in appS)
                    {
                        if (itemCheckBoxModules != "" && itemCheckBoxModules != null)
                        {
                            clsEntityLayerJobRlRole objEntityDsgnRole = null;
                            objEntityDsgnRole = new clsEntityLayerJobRlRole();

                            string[] strchild = itemCheckBoxModules.Split('.');
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

                    }
                    List<clsEntityLayerJobRlRole> objlisDsgnRolWMS = new List<clsEntityLayerJobRlRole>();
                    objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_PMS, objlisDsgnRolChildrenDtls_PMS);

                    foreach (clsEntityLayerJobRlRole objDsgnRol in objlisDsgnRolWMS)
                    {
                        objlisDsgnRol.Add(objDsgnRol);
                    }

                }
                else
                {
                    // lblSelectedNodes.Text = "Select Node(s).";
                }
            }


            objBusinessLayerJobRole.UpdateJobRlDetail(objEntityJobRl, objlisDsgnRol, objlisJobRlAppRol);


            if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateF")
           {
               Response.Redirect("gen_Job_Role.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Upd");
           }
            else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseF")
           {
               Response.Redirect("gen_Job_Role_List.aspx?InsUpd=Upd");
           }



        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtJobRoleName.Focus();
        }

    }


    public void UpdateView(string strJobRlId)
    {
        clsEntityLayerJobRole objEntityJobRl = new clsEntityLayerJobRole();
        objEntityJobRl.JobRoleId = Convert.ToInt32(strJobRlId);
        DataTable dtJobRlDetails = objBusinessLayerJobRole.ReadJobRLMasterById(objEntityJobRl);
        DropDownBind();
        if (dtJobRlDetails.Rows.Count > 0)
        {
            //ie IF  DESIGNATION IS ACTIVE
            if (dtJobRlDetails.Rows[0]["DSGN_STATUS"].ToString() == "1" && dtJobRlDetails.Rows[0]["DSGN_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlDesignation.Items.FindByText(dtJobRlDetails.Rows[0]["DSGN_NAME"].ToString()) != null)
                {
                    ddlDesignation.ClearSelection();
                    ddlDesignation.Items.FindByText(dtJobRlDetails.Rows[0]["DSGN_NAME"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lst = new ListItem(dtJobRlDetails.Rows[0]["DSGN_NAME"].ToString(), dtJobRlDetails.Rows[0]["DSGN_ID"].ToString());
                ddlDesignation.Items.Insert(1, lst);

                SortDDL(ref this.ddlDesignation);
                ddlDesignation.ClearSelection();
                ddlDesignation.Items.FindByText(dtJobRlDetails.Rows[0]["DSGN_NAME"].ToString()).Selected = true;
            }
            //NEW ENDS


            string strDesigId = dtJobRlDetails.Rows[0]["DSGN_ID"].ToString();


            //ddlDesignation.Items.FindByValue(strDesigId).Selected=true;
            //if (strDesigId != null)
            //{
            //    if (ddlDesignation.Items.FindByValue(strDesigId) != null)
            //    {
            //        ddlDesignation.Items.FindByValue(strDesigId).Selected = true;
            //    }
            //}
            txtJobRoleName.Text = dtJobRlDetails.Rows[0]["JOB ROLE NAME"].ToString();
            if (dtJobRlDetails.Rows[0]["STATUS"].ToString() == "ACTIVE")
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
            //UpdateViewByDdl(ddlDesignation.SelectedItem.Value);
            UpdateTreeViewByJobRolID(strJobRlId);
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



    public void UpdateTreeViewByJobRolID(string strJobRolID)
    {

        clsEntityLayerJobRole objEntityJobRl = new clsEntityLayerJobRole();
        objEntityJobRl.JobRoleId = Convert.ToInt32(strJobRolID);
        //BL
        //del
        DataTable dtDsgnMastr = objBusinessLayerJobRole.ReadJobRlRoles(objEntityJobRl);
        //BL
        DataTable dtDsgnAppRoles = objBusinessLayerJobRole.ReadJobRlAppRoles(objEntityJobRl);
        for (int intcountApp = 0; intcountApp < dtDsgnAppRoles.Rows.Count; intcountApp++)
        {

            if (dtDsgnAppRoles.Rows[intcountApp]["PRTZAPP_ID"].ToString() != "")
            {
                  HiddenFieldAppChecked.Value += dtDsgnAppRoles.Rows[intcountApp]["PRTZAPP_ID"].ToString() + ",";
                    
                
            }

        }
        char charDsgTypCntrl = 'A';


        if (dtDsgnMastr.Rows.Count > 0)
        {
            charDsgTypCntrl = Convert.ToChar(dtDsgnMastr.Rows[0]["DSGN_CONTROL"].ToString());
            //charDsgTypCntrl = 'C';
            Treefill(charDsgTypCntrl);
            //txtDesignationName.Text = dtDsgnMastr.Rows[0]["DSGN_NAME"].ToString();
            Int32 intPrimary = 1;
            //Int32 intPrimary = Convert.ToInt32(dtDsgnMastr.Rows[0]["DSGN_PRIMARY"].ToString());
            //hiddenPrimaryDecision.Value = dtDsgnMastr.Rows[0]["DSGN_PRIMARY"].ToString();

            //if (intPrimary == Convert.ToInt32(clsCommonLibrary.DesignationType.Primary))
            //{
            //    DropDownBind();
            //    ddlDesignation.Items.Clear();
            //    ListItem lst = new ListItem("Corporate Administrator", "3");
            //    ddlDesignation.Items.Insert(0, lst);

            //    //  ddlDesignationType.Items.Insert(0, "Corporate Administrator");
            //    //  ddlDesignationType.Enabled = false;
            //}
            //else
            //{
            //    DropDownBind(dtDsgnMastr.Rows[0]["DSGTYP_NAME"].ToString());

            //}


            //int intStatus = Convert.ToInt32(dtDsgnMastr.Rows[0]["DSGN_STATUS"]);
            //if (intStatus == 1)
            //{
            //    cbxStatus.Checked = true;
            //}
            //else
            //{
            //    cbxStatus.Checked = false;
            //}

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


                HiddenFieldcbxChecked.Value = strUsrRoleChildRole;

                //foreach (TreeNode node in TreeViewCompzit_AppAdminstration.Nodes)
                //{
                //    SelectNodesRecursive(node, strUsrRoleChildRole);
                //}
                //foreach (TreeNode node in TreeViewCompzit_SalesAutomation.Nodes)
                //{
                //    SelectNodesRecursive(node, strUsrRoleChildRole);
                //}
                //foreach (TreeNode node in TreeViewCompzit_AutoWorkshopManagement.Nodes)
                //{
                //    SelectNodesRecursive(node, strUsrRoleChildRole);
                //}
                //foreach (TreeNode node in TreeViewCompzit_GuaranteeManagement.Nodes)
                //{
                //    SelectNodesRecursive(node, strUsrRoleChildRole);
                //}
                //foreach (TreeNode node in TreeViewCompzit_HumanCapitalManagement.Nodes)
                //{
                //    SelectNodesRecursive(node, strUsrRoleChildRole);
                //}
                //foreach (TreeNode node in TreeViewCompzit_FinanceManagementSystem.Nodes)
                //{
                //    SelectNodesRecursive(node, strUsrRoleChildRole);
                //}
                //foreach (TreeNode node in TreeViewCompzit_ProcurementManagementSystem.Nodes)//PMS
                //{
                //    SelectNodesRecursive(node, strUsrRoleChildRole);
                //}

            }

        }
    }




    protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        hiddenConfirmValue.Value = "IncrmntConfrmCounter";
        // cbxlCompzitModules.ClearSelection();
        //cbxlCompzitModules.Items.Clear();
        BindCompzitModules();
        clsEntityLayerJobRole objEntityJobRl = new clsEntityLayerJobRole();

        char charDsgTypCntrl = 'A';
        if (ddlDesignation.SelectedItem.Value != "--SELECT--")
        {
            objEntityJobRl.DesignationId = Convert.ToInt32(ddlDesignation.SelectedItem.Value);
            //BL
            charDsgTypCntrl = Convert.ToChar(objBusinessLayerJobRole.ReadDsgnControl(objEntityJobRl));
            Treefill(charDsgTypCntrl);
        }
        else
        {
            BindCompzitModules();
            treeApp.InnerHtml = "";
            treeSfa.InnerHtml = "";
            treeAwms.InnerHtml = "";
            treeGms.InnerHtml = "";
            treeHcm.InnerHtml = "";
            treeFms.InnerHtml = "";
            treePms.InnerHtml = "";
        }
        UpdateViewByDdl(ddlDesignation.SelectedItem.Value);
        ddlDesignation.Focus(); //evm-0023
    }



    public void UpdateViewByDdl(string strDesgnId)
    {
        if (strDesgnId == "--SELECT--")
        {

        }
        else
        {
            clsEntityLayerJobRole objEntityJobRl = new clsEntityLayerJobRole();


            objEntityJobRl.DesignationId = Convert.ToInt32(strDesgnId);
            //BL
            DataTable dtDsgnMastr = objBusinessLayerJobRole.ReadDsgnMasterEdit(objEntityJobRl);
            //BL
            DataTable dtDsgnAppRoles = objBusinessLayerJobRole.ReadDsgnAppRoleByDsgnId(objEntityJobRl);
            for (int intcountApp = 0; intcountApp < dtDsgnAppRoles.Rows.Count; intcountApp++)
            {

                if (dtDsgnAppRoles.Rows[intcountApp]["PRTZAPP_ID"].ToString() != "")
                {
                    HiddenFieldAppChecked.Value += dtDsgnAppRoles.Rows[intcountApp]["PRTZAPP_ID"].ToString() + ",";
                }

            }
            char charDsgTypCntrl = 'A';


            if (dtDsgnMastr.Rows.Count > 0)
            {
                charDsgTypCntrl = Convert.ToChar(dtDsgnMastr.Rows[0]["DSGN_CONTROL"].ToString());
                //Check
                //charDsgTypCntrl = 'C';
                Treefill(charDsgTypCntrl);
                //txtDesignationName.Text = dtDsgnMastr.Rows[0]["DSGN_NAME"].ToString();
                //Check
                Int32 intPrimary = 1;
                hiddenPrimaryDecision.Value = "1";

                //Int32 intPrimary = Convert.ToInt32(dtDsgnMastr.Rows[0]["DSGN_PRIMARY"].ToString());
                //hiddenPrimaryDecision.Value = dtDsgnMastr.Rows[0]["DSGN_PRIMARY"].ToString();

                //if (intPrimary == Convert.ToInt32(clsCommonLibrary.DesignationType.Primary))
                //{
                //    DropDownBind();
                //    ddlDesignation.Items.Clear();
                //    ListItem lst = new ListItem("Corporate Administrator", "3");
                //    ddlDesignation.Items.Insert(0, lst);

                //    //  ddlDesignationType.Items.Insert(0, "Corporate Administrator");
                //    //  ddlDesignationType.Enabled = false;
                //}
                //else
                //{
                //    DropDownBind(dtDsgnMastr.Rows[0]["DSGTYP_NAME"].ToString());

                //}


                //int intStatus = Convert.ToInt32(dtDsgnMastr.Rows[0]["DSGN_STATUS"]);
                //if (intStatus == 1)
                //{
                //    cbxStatus.Checked = true;
                //}
                //else
                //{
                //    cbxStatus.Checked = false;
                //}

                string strUsrRoleChildRole = "";
                for (int intcount = 0; intcount < dtDsgnMastr.Rows.Count; intcount++)
                {

                    if (dtDsgnMastr.Rows[intcount]["USROL_ID"].ToString() != "")
                    {
                        if (intcount == 0)
                        {
                            strUsrRoleChildRole = dtDsgnMastr.Rows[intcount]["USROL_ID"].ToString();
                            if (dtDsgnMastr.Rows[intcount]["DSGROL_CHLDRL_DEFN"].ToString() != "")
                            {
                                string strchildRoleDefn = dtDsgnMastr.Rows[intcount]["DSGROL_CHLDRL_DEFN"].ToString();

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

                            if (dtDsgnMastr.Rows[intcount]["DSGROL_CHLDRL_DEFN"].ToString() != "")
                            {

                                string strchildRoleDefn = dtDsgnMastr.Rows[intcount]["DSGROL_CHLDRL_DEFN"].ToString();

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
                    HiddenFieldcbxChecked.Value = strUsrRoleChildRole;

                }

            }
        }
    }
}
    


    
