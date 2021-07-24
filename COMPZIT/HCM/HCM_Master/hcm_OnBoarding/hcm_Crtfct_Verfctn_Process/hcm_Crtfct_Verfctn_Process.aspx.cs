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
using System.Web.Services;
using EL_Compzit;
using BL_Compzit.HCM;
using EL_Compzit.HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Collections;
using BL_Compzit.BusineesLayer_HCM;
//using EL_Compzit.EntityLayer_HCM;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Collections;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Collections.Generic;

// CREATED BY:EVM-0008
// CREATED DATE:6/27/2017
// REVIEWED BY:
// REVIEW DATE:

public partial class HCM_HCM_Master_hcm_OnBoarding_hcm_Crtfct_Verfctn_Process_hcm_Crtfct_Verfctn_Process : System.Web.UI.Page
{
   
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
    clcBusiness_Crtfct_Verfctn_Process objBusinessIntrvTem = new clcBusiness_Crtfct_Verfctn_Process();
    protected void Page_Load(object sender, EventArgs e)
    {


        ddlCandName.Attributes.Add("onkeypress", "return DisableEnter(event)");
      //  ddlCandName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlCandBundl.Attributes.Add("onkeypress", "return DisableEnter(event)");
       // ddlCandBundl.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        if (!IsPostBack)
        {
            this.Form.Enctype = "multipart/form-data";
            HiddenCertfctVBundle.Value = "";
            txtJobRole.Enabled = false;
            ddlCandName.Focus();
            DropDownCadidate();
            DropDownCertfctBundl();
            HiddenUpdateChk.Value = "";
            HiddenFieldDuplcnChk.Value = "";
            hiddenTemNextId.Value = "0";
            btnClear.Visible = false;
           // btnComplt.Visible = false;
            clsEntity_Crtfct_Verfctn_Process objEntityIntrvTem = new clsEntity_Crtfct_Verfctn_Process();
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                Hiddenuserid.Value = Session["USERID"].ToString();

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            int intUserRoleRecall = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0;
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Certificate_Validation);
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
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                }
            }

            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

                btnUpdate.Visible = true;
                btnComplt.Visible = true;

            }
            else
            {

                btnUpdate.Visible = false;
                btnComplt.Visible = false;

            }
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

                HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                HiddenOrgid.Value = Session["ORGID"].ToString();
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            //btnAddNext.Visible = false;
            //  btnSkip.Visible = false;
            //when editing 

           // Update("6116219");

            if (Request.QueryString["Id"] != null)
            {

                // btnClear.Visible = false;
                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    btnUpdate.Visible = true;
                   btnComplt.Visible = true;
                }
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                HiddenJobId.Value = strId;
                HiddenUpdateChk.Value = strId;
                Update(strId);
                lblEntry.Text = "Edit Certificate Validation";

            }
            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                //  btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

               View(strId);

                lblEntry.Text = "View Certificate Validation";

                if (Request.QueryString["RFGP"] != null)
                {
                    btnCancel.Visible = false;
                    divList.Visible = false;
                }
            }

            else
            {
                lblEntry.Text = "Add Certificate Validation";




              //  btnComplt.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnComplt.Visible = false;
                btnAdd.Visible = true;
                ButtonCompl.Visible = true;
                btnAddClose.Visible = true;
                btnClear.Visible = true;
                // btnClear.Visible = true;
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
                        //  btnSkip.Visible = true;
                        //  btnAddNext.Visible = true;
                        // btnAddClose.Visible = false;
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationPrj", "SuccessConfirmationPrj();", true);
                    }
                    else if (strInsUpd == "PrjUpd")
                    {
                        //    btnSkip.Visible = true;
                        //   btnAddNext.Visible = true;
                        // btnAddClose.Visible = false;
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdationPrj", "SuccessUpdationPrj();", true);
                    }
                }






            }
        }
    }
    public void DropDownCadidate()
    {

        clsEntity_Crtfct_Verfctn_Process objEntityIntrvTem = new clsEntity_Crtfct_Verfctn_Process();
        if (Session["USERID"] != null)
        {
            objEntityIntrvTem.UsrId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityIntrvTem.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityIntrvTem.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtEmployeeList = new DataTable();
        dtEmployeeList = objBusinessIntrvTem.ReadCandidateLoad(objEntityIntrvTem);
        if (dtEmployeeList.Rows.Count > 0)
        {
            ddlCandName.DataSource = dtEmployeeList;
            ddlCandName.DataTextField = "CAND_NAME";
            ddlCandName.DataValueField = "CAND_ID";
            ddlCandName.DataBind();

        }
        // DataTable dtDefaultcurc = ObjBussinessBankGuarnt.ReadDefualtCurrency(ObjEntityRequest);
        //string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        ddlCandName.Items.Insert(0, "--SELECT CANDIDATE--");
    }
    public void DropDownCertfctBundl()
    {

        clsEntity_Crtfct_Verfctn_Process objEntityIntrvTem = new clsEntity_Crtfct_Verfctn_Process();
        if (Session["USERID"] != null)
        {
            objEntityIntrvTem.UsrId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityIntrvTem.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityIntrvTem.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtEmployeeList = new DataTable();
        dtEmployeeList = objBusinessIntrvTem.ReadCertfctBundl(objEntityIntrvTem);
        if (dtEmployeeList.Rows.Count > 0)
        {
            ddlCandBundl.DataSource = dtEmployeeList;
            ddlCandBundl.DataTextField = "CRTFTBNDLTEM_NAME";
            ddlCandBundl.DataValueField = "CRTFTBNDLTEM_ID";
            ddlCandBundl.DataBind();

        }
        // DataTable dtDefaultcurc = ObjBussinessBankGuarnt.ReadDefualtCurrency(ObjEntityRequest);
        //string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        ddlCandBundl.Items.Insert(0, "--SELECT CERTIFICATE BUNDLE--");
    }


    private void View(string intrvwTemId)
    {//when Editing 

        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntity_Crtfct_Verfctn_Process objEntityIntrvTem = new clsEntity_Crtfct_Verfctn_Process();
        objEntityIntrvTem.NextProcId = Convert.ToInt32(intrvwTemId);
        hiddenTemNextId.Value = intrvwTemId.ToString();
        // btnUpdate.Visible = true;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityIntrvTem.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }



        if (Session["ORGID"] != null)
        {
            objEntityIntrvTem.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        DataTable dtIntervw = new DataTable();
        //   DataTable dtWBill = new DataTable();
        DataTable dtIntervwTxt = new DataTable();

        dtIntervwTxt  = objBusinessIntrvTem.ReadCrtVerfctnPrss(objEntityIntrvTem);
        dtIntervw = objBusinessIntrvTem.ReadCrtVerfctnPrssDtls(objEntityIntrvTem);

        string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CERTIFICATE_VERIFICATION);
        HiddenFilePath.Value = strImagePath;

        if (dtIntervwTxt.Rows.Count > 0)
        {

            if (ddlCandName.Items.FindByValue(dtIntervwTxt.Rows[0]["CAND_ID_NAME"].ToString()) != null)
            {
                ddlCandName.Items.FindByValue(dtIntervwTxt.Rows[0]["CAND_ID_NAME"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtIntervwTxt.Rows[0]["CAND_NAME"].ToString(), dtIntervwTxt.Rows[0]["CAND_ID_NAME"].ToString());
                ddlCandName.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlCandName);

                ddlCandName.Items.FindByValue(dtIntervwTxt.Rows[0]["CAND_ID_NAME"].ToString()).Selected = true;
            }
            if (dtIntervwTxt.Rows[0]["DSGN_NAME"].ToString() !=null  && dtIntervwTxt.Rows[0]["DSGN_NAME"].ToString() != "")
            {
                txtJobRole.Text = dtIntervwTxt.Rows[0]["DSGN_NAME"].ToString();
                HiddenJobRlDesg.Value = dtIntervwTxt.Rows[0]["MNP_DESIGID_ROLE"].ToString();
            }

            if (dtIntervwTxt.Rows[0]["CRTFTBNDLTEM_STATUS"].ToString() == "1" && dtIntervwTxt.Rows[0]["CRTFTBNDLTEM_CNCL_USR_ID"].ToString() == "")
            {
                ddlCandBundl.Items.FindByValue(dtIntervwTxt.Rows[0]["CRTFTBNDLTEM_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtIntervwTxt.Rows[0]["CRTFTBNDLTEM_NAME"].ToString(), dtIntervwTxt.Rows[0]["CRTFTBNDLTEM_ID"].ToString());
                ddlCandBundl.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlCandName);

                ddlCandBundl.Items.FindByValue(dtIntervwTxt.Rows[0]["CRTFTBNDLTEM_ID"].ToString()).Selected = true;
            }

            //   hiddenActiveUser.Value = dtQtn.Rows[0]["LDQUOT_ACTIVE_USR_ID"].ToString();

            // HiddenTempDetailId.Value=

            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("ProssDetlId", typeof(int));
            dtDetail.Columns.Add("Addition", typeof(string));
            dtDetail.Columns.Add("Submit", typeof(int));
            dtDetail.Columns.Add("dDate", typeof(string));
            dtDetail.Columns.Add("Verify", typeof(int));
            dtDetail.Columns.Add("Status", typeof(int));
            dtDetail.Columns.Add("FileName", typeof(string));
            dtDetail.Columns.Add("ActualFileName", typeof(string));
            //  dtDetail.Columns.Add("Amount", typeof(decimal));


            for (int intcnt = 0; intcnt < dtIntervw.Rows.Count; intcnt++)
            {
                DataRow drDtl = dtDetail.NewRow();
                drDtl["ProssDetlId"] = Convert.ToInt32(dtIntervw.Rows[intcnt]["CRTFCT_VERPRSDTL_ID"].ToString());
                drDtl["Addition"] = dtIntervw.Rows[intcnt]["CRTFCT_VERPRSDTL_NAME"].ToString().Trim();
                drDtl["Submit"] = Convert.ToInt32(dtIntervw.Rows[intcnt]["CRTFCT_VERPRSDTL_SUBMIT"].ToString());
                drDtl["dDate"] = dtIntervw.Rows[intcnt]["CRTFCT_VERPRSDTL_DATE"].ToString();
                drDtl["Verify"] = Convert.ToInt32(dtIntervw.Rows[intcnt]["CRTFCT_VERPRSDTL_VERIFY"].ToString());
                drDtl["Status"] = dtIntervw.Rows[intcnt]["CRTFCT_VERPRSDTL_STATUS"].ToString();
                drDtl["FileName"] = dtIntervw.Rows[intcnt]["CAND_RESUMENAME"].ToString();
                drDtl["ActualFileName"] = dtIntervw.Rows[intcnt]["CAND_ACT_RESUMENAME"].ToString();

                // drDtl["Amount"] = Convert.ToDecimal(dtIntervw.Rows[intcnt]["RCPT_AMNT"].ToString());

                dtDetail.Rows.Add(drDtl);

            }

            string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
            //if (intEditOrView == 1)
            //{
        
            //  btnReOpen.Visible = false;
            hiddenView.Value = strJson;
            //  }
            //else if (intEditOrView == 2)
            //{

            //    btnSave.Visible = false;
            //    btnSaveClose.Visible = false;
            //    btnUpdate.Visible = false;
            //    btnUpdateClose.Visible = false;
            //    btnConfirm.Visible = false;
            //    hiddenView.Value = strJson;
            //}


        }
        ButtonCompl.Visible = false;
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        ddlCandName.Enabled = false;
        ddlCandName.Attributes["class"] = "form11";
        ddlCandBundl.Attributes["class"] = "form11";
        ddlCandBundl.Enabled = false;
        btnComplt.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        btnComplt.Visible = false;
       // btnCancel.Enabled = false;
    }
    private void Update(string intrvwTemId)
    {//when Editing 

        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntity_Crtfct_Verfctn_Process objEntityIntrvTem = new clsEntity_Crtfct_Verfctn_Process();
        objEntityIntrvTem.NextProcId = Convert.ToInt32(intrvwTemId);
        hiddenTemNextId.Value = intrvwTemId.ToString();
        // btnUpdate.Visible = true;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityIntrvTem.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }



        if (Session["ORGID"] != null)
        {
            objEntityIntrvTem.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        DataTable dtIntervw = new DataTable();
        //   DataTable dtWBill = new DataTable();
        DataTable dtIntervwTxt = new DataTable();

        dtIntervwTxt  = objBusinessIntrvTem.ReadCrtVerfctnPrss(objEntityIntrvTem);
        dtIntervw = objBusinessIntrvTem.ReadCrtVerfctnPrssDtls(objEntityIntrvTem);

        string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CERTIFICATE_VERIFICATION);
        HiddenFilePath.Value = strImagePath;

        if (dtIntervwTxt.Rows.Count > 0)
        {

            if (ddlCandName.Items.FindByValue(dtIntervwTxt.Rows[0]["CAND_ID_NAME"].ToString()) != null)
            {
                ddlCandName.Items.FindByValue(dtIntervwTxt.Rows[0]["CAND_ID_NAME"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtIntervwTxt.Rows[0]["CAND_NAME"].ToString(), dtIntervwTxt.Rows[0]["CAND_ID_NAME"].ToString());
                ddlCandName.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlCandName);

                ddlCandName.Items.FindByValue(dtIntervwTxt.Rows[0]["CAND_ID_NAME"].ToString()).Selected = true;
            }
            if (dtIntervwTxt.Rows[0]["DSGN_NAME"].ToString() !=null  && dtIntervwTxt.Rows[0]["DSGN_NAME"].ToString() != "")
            {
                txtJobRole.Text = dtIntervwTxt.Rows[0]["DSGN_NAME"].ToString();
                HiddenJobRlDesg.Value = dtIntervwTxt.Rows[0]["MNP_DESIGID_ROLE"].ToString();
            }

            if (dtIntervwTxt.Rows[0]["CRTFTBNDLTEM_STATUS"].ToString() == "1" && dtIntervwTxt.Rows[0]["CRTFTBNDLTEM_CNCL_USR_ID"].ToString() == "")
            {
                ddlCandBundl.Items.FindByValue(dtIntervwTxt.Rows[0]["CRTFTBNDLTEM_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtIntervwTxt.Rows[0]["CRTFTBNDLTEM_NAME"].ToString(), dtIntervwTxt.Rows[0]["CRTFTBNDLTEM_ID"].ToString());
                ddlCandBundl.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlCandName);

                ddlCandBundl.Items.FindByValue(dtIntervwTxt.Rows[0]["CRTFTBNDLTEM_ID"].ToString()).Selected = true;
            }


             objEntityIntrvTem.CertVerctnProcId = Convert.ToInt32(dtIntervwTxt.Rows[0]["CRTFTBNDLTEM_ID"].ToString());
    
        DataTable dtCertfctCount = new DataTable();
        dtCertfctCount = objBusinessIntrvTem.ReadCertfctBundle(objEntityIntrvTem);
        string strRet = "";
        int intCertcount = 0;
        if (dtCertfctCount.Rows.Count > 0)
        {
            intCertcount = dtCertfctCount.Rows.Count;
        }

        HiddenCertcount.Value = intCertcount.ToString();
         

            //   hiddenActiveUser.Value = dtQtn.Rows[0]["LDQUOT_ACTIVE_USR_ID"].ToString();

            // HiddenTempDetailId.Value=

            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("ProssDetlId", typeof(int));
            dtDetail.Columns.Add("Addition", typeof(string));
            dtDetail.Columns.Add("Submit", typeof(int));
            dtDetail.Columns.Add("dDate", typeof(string));
            dtDetail.Columns.Add("Verify", typeof(int));
            dtDetail.Columns.Add("Status", typeof(int));
            dtDetail.Columns.Add("FileName", typeof(string));
            dtDetail.Columns.Add("ActualFileName", typeof(string));
           // dtDetail.Columns.Add("Certcount", typeof(int));
            //  dtDetail.Columns.Add("Amount", typeof(decimal));


            for (int intcnt = 0; intcnt < dtIntervw.Rows.Count; intcnt++)
            {
                DataRow drDtl = dtDetail.NewRow();
                drDtl["ProssDetlId"] = Convert.ToInt32(dtIntervw.Rows[intcnt]["CRTFCT_VERPRSDTL_ID"].ToString());
                drDtl["Addition"] = dtIntervw.Rows[intcnt]["CRTFCT_VERPRSDTL_NAME"].ToString();
                drDtl["Submit"] = Convert.ToInt32(dtIntervw.Rows[intcnt]["CRTFCT_VERPRSDTL_SUBMIT"].ToString());
                if (dtIntervw.Rows[intcnt]["CRTFCT_VERPRSDTL_DATE"].ToString() == DateTime.MinValue.ToString("dd-MM-yyyy"))
                {
                    drDtl["dDate"] = "";
                }
                else
                {
                    drDtl["dDate"] = dtIntervw.Rows[intcnt]["CRTFCT_VERPRSDTL_DATE"].ToString();
                }
                drDtl["Verify"] = Convert.ToInt32(dtIntervw.Rows[intcnt]["CRTFCT_VERPRSDTL_VERIFY"].ToString());
                drDtl["Status"] = dtIntervw.Rows[intcnt]["CRTFCT_VERPRSDTL_STATUS"].ToString();
                drDtl["FileName"] = dtIntervw.Rows[intcnt]["CAND_RESUMENAME"].ToString();
                drDtl["ActualFileName"] = dtIntervw.Rows[intcnt]["CAND_ACT_RESUMENAME"].ToString();
             //   drDtl["Certcount"] = intCertcount;
                // drDtl["Amount"] = Convert.ToDecimal(dtIntervw.Rows[intcnt]["RCPT_AMNT"].ToString());

                dtDetail.Rows.Add(drDtl);

            }

            string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
            //if (intEditOrView == 1)
            //{
            btnAdd.Visible = false;
            ButtonCompl.Visible = false;
            btnAddClose.Visible = false;
            //  btnReOpen.Visible = false;
            hiddenEdit.Value = strJson;
            //  }
            //else if (intEditOrView == 2)
            //{

            //    btnSave.Visible = false;
            //    btnSaveClose.Visible = false;
            //    btnUpdate.Visible = false;
            //    btnUpdateClose.Visible = false;
            //    btnConfirm.Visible = false;
            //    hiddenView.Value = strJson;
            //}


        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntity_Crtfct_Verfctn_Process objEntityIntrvTem = new clsEntity_Crtfct_Verfctn_Process();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityIntrvTem.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityIntrvTem.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        if (Session["USERID"] != null)
        {
            objEntityIntrvTem.UsrId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }



        objEntityIntrvTem.NextProcId = Convert.ToInt32(hiddenTemNextId.Value);
        objEntityIntrvTem.D_Date = System.DateTime.Now;


        //  objEntityEmployee.Sponsor_Group_Id = Convert.ToInt32(ddlSpnsrType.SelectedItem.Value);


        objEntityIntrvTem.CandId = Convert.ToInt32(ddlCandName.SelectedItem.Value);

        objEntityIntrvTem.DesgRoleId = Convert.ToInt32(HiddenJobRlDesg.Value);
        objEntityIntrvTem.CertVerctnProcId = Convert.ToInt32(ddlCandBundl.SelectedItem.Value);

        List<clsEntity_Crtverfcn_Dtls> objEntityCrtfnDetilsList = new List<clsEntity_Crtverfcn_Dtls>();
        List<clsEntity_Crtverfcn_Dtls> objEntityCrtfnDetilsupdList = new List<clsEntity_Crtverfcn_Dtls>();
       
        string jsonData = HiddenIntervw_Tem.Value;
        string c = jsonData.Replace("\"{", "\\{");
        string d = c.Replace("\\n", "\r\n");
        string g = d.Replace("\\", "");
        string h = g.Replace("}\"]", "}]");
        string i = h.Replace("}\",", "},");
        List<clsWBData> objWBDataList = new List<clsWBData>();
        //   UserData  data
        objWBDataList = JsonConvert.DeserializeObject<List<clsWBData>>(i);
        int intImgCount = 1;
        int intFileID = 0;
        int rowId;
        foreach (clsWBData objclsWBData in objWBDataList)
        {
            if (objclsWBData.EVTACTION == "INS")
            {

                clsEntity_Crtverfcn_Dtls objEntityDetails = new clsEntity_Crtverfcn_Dtls();
                rowId = Convert.ToInt32(objclsWBData.ROWID);
            //    objEntityDetails.CertVerctnProcId = Convert.ToInt32(objclsWBData.DTLID);
                objEntityDetails.CertProcDtlName = objclsWBData.LNKTXT;
                objEntityDetails.DtlSubmit = Convert.ToInt32(objclsWBData.SCORECHK);
                if (objclsWBData.SELCTDATE != "")
                {
                    objEntityDetails.Detaildate = objCommon.textToDateTime(objclsWBData.SELCTDATE);
                }
                else
                {
                    objEntityDetails.Detaildate = DateTime.MinValue;
                }
                objEntityDetails.Dtlverify = Convert.ToInt32(objclsWBData.CHKBOXSUB);
                objEntityDetails.DtlSts = Convert.ToInt32(objclsWBData.VALSTATUS);




                string jsonFileid = "uploadimportFiles" + rowId;


                HttpPostedFile PostedFile = Request.Files["uploadimportFiles" + rowId];

                if (PostedFile.ContentLength > 0)
                {
                    // clsJoiningWorkerDtl objEntityJWorkerDtl = new clsJoiningWorkerDtl();
                    string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                    objEntityDetails.ActualFileName = strFileName;
                    string strFileExt;

                    strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

                    //  int intImageSectionOtherDocu = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CERTIFICATE_VERIFICATION);
                    string year = DateTime.Today.Year.ToString();
                    string strImageName = "DOC_" + year + intImgCount + "_" + objEntityIntrvTem.NextProcId.ToString() + "." + strFileExt;
                    objEntityDetails.FileName = strImageName;
                    string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CERTIFICATE_VERIFICATION);

                    PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityDetails.FileName);
                    intImgCount++;

                }
                objEntityCrtfnDetilsList.Add(objEntityDetails);
            }
            else if (objclsWBData.EVTACTION == "UPD")
            {
                clsEntity_Crtverfcn_Dtls objEntityDetails = new clsEntity_Crtverfcn_Dtls();
                if (objclsWBData.ACTFILENAME != "")
                {
                    objEntityDetails.DelOrNot = 1;
                    string strFilePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CERTIFICATE_VERIFICATION);
                    strFilePath = strFilePath + objclsWBData.ACTFILENAME;
                    //for delete all the files in the specific folder.
                    if (File.Exists(MapPath(strFilePath)))
                    {
                        File.Delete(MapPath(strFilePath));
                    }
                }

              
                rowId = Convert.ToInt32(objclsWBData.ROWID);
                objEntityDetails.CertVerctnProcId =Convert.ToInt32( objclsWBData.DTLID);
                objEntityDetails.CertProcDtlName = objclsWBData.LNKTXT;
                objEntityDetails.DtlSubmit = Convert.ToInt32(objclsWBData.SCORECHK);
                if (objclsWBData.SELCTDATE != "")
                {
                    objEntityDetails.Detaildate = objCommon.textToDateTime(objclsWBData.SELCTDATE);
                }
                else
                {
                    objEntityDetails.Detaildate = DateTime.MinValue;
                }
                objEntityDetails.Dtlverify = Convert.ToInt32(objclsWBData.CHKBOXSUB);
                objEntityDetails.DtlSts = Convert.ToInt32(objclsWBData.VALSTATUS);




                string jsonFileid = "uploadimportFiles" + rowId;


                HttpPostedFile PostedFile = Request.Files["uploadimportFiles" + rowId];

                if (PostedFile.ContentLength > 0)
                {
                    // clsJoiningWorkerDtl objEntityJWorkerDtl = new clsJoiningWorkerDtl();
                    objEntityDetails.DelOrNot = 1;
                    string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                    objEntityDetails.ActualFileName = strFileName;
                    string strFileExt;

                    strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

                    //  int intImageSectionOtherDocu = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CERTIFICATE_VERIFICATION);
                    string year = DateTime.Today.Year.ToString();
                    string strImageName = "DOC_" + year + intImgCount + "_" + objEntityIntrvTem.NextProcId.ToString() + "." + strFileExt;
                    objEntityDetails.FileName = strImageName;
                    string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CERTIFICATE_VERIFICATION);

                    PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityDetails.FileName);
                    intImgCount++;

                }
                else
                {
                    if (objclsWBData.ACTFILENAME != "")
                    {
                        objEntityDetails.ActualFileName = "";
                        objEntityDetails.FileName = "";
                    }
                }
                objEntityCrtfnDetilsupdList.Add(objEntityDetails);
            }

           
        }
        string strCanclDtlId = "";
        string[] strarrCancldtlIds = strCanclDtlId.Split(',');
        if (hiddenCanclDtlId.Value != "" && hiddenCanclDtlId.Value != null)
        {
            strCanclDtlId = hiddenCanclDtlId.Value;
            strarrCancldtlIds = strCanclDtlId.Split(',');

        }

     
        objBusinessIntrvTem.Update_VerfcnProcess(objEntityIntrvTem, objEntityCrtfnDetilsList, objEntityCrtfnDetilsupdList, strarrCancldtlIds);
    
        if (clickedButton.ID == "btnUpdate")
        {
            hiddenEdit.Value = "";
            Response.Redirect("hcm_Crtfct_Verfctn_Process.aspx?InsUpd=Upd");
        }
        else if (clickedButton.ID == "btnUpdateClose")
        {
            Response.Redirect("hcm_Crtfct_Verfctn_Process_List.aspx?InsUpd=Upd");
        }
        else if (clickedButton.ID == "btnComplt")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ValidateComplt", "ValidateComplt();", true);
        }




        //}

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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntity_Crtfct_Verfctn_Process objEntityIntrvTem = new clsEntity_Crtfct_Verfctn_Process();
          
            int intUserId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityIntrvTem.CorpId= Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }


            if (Session["ORGID"] != null)
            {
                objEntityIntrvTem.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

        

            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CERTIFICATE_VERIFICATION);
            objEntityCommon.CorporateID = objEntityIntrvTem.CorpId;
            objEntityCommon.Organisation_Id = objEntityIntrvTem.OrgId;
            string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
            objEntityIntrvTem.NextProcId = Convert.ToInt32(strNextId);
            hiddenTemNextId.Value = objEntityIntrvTem.NextProcId.ToString(); ;

            objEntityIntrvTem.UsrId = intUserId;
            objEntityIntrvTem.D_Date = System.DateTime.Now;

            objEntityIntrvTem.CandId = Convert.ToInt32(ddlCandName.SelectedItem.Value);

            objEntityIntrvTem.DesgRoleId = Convert.ToInt32(HiddenJobRlDesg.Value);
            objEntityIntrvTem.CertVerctnProcId = Convert.ToInt32(ddlCandBundl.SelectedItem.Value);

            List<clsEntity_Crtverfcn_Dtls> objEntityCrtfnDetilsList = new List<clsEntity_Crtverfcn_Dtls>();
            string jsonData = HiddenIntervw_Tem.Value;
            string c = jsonData.Replace("\"{", "\\{");
            string d = c.Replace("\\n", "\r\n");
            string g = d.Replace("\\", "");
            string h = g.Replace("}\"]", "}]");
            string i = h.Replace("}\",", "},");
            List<clsWBData> objWBDataList = new List<clsWBData>();
            //   UserData  data
            objWBDataList = JsonConvert.DeserializeObject<List<clsWBData>>(i);
            int intImgCount = 1;
            int intFileID = 0;
            int rowId;
            if (objWBDataList != null)
            {
                foreach (clsWBData objclsWBData in objWBDataList)
                {

                    clsEntity_Crtverfcn_Dtls objEntityDetails = new clsEntity_Crtverfcn_Dtls();
                    rowId = Convert.ToInt32(objclsWBData.ROWID);
                    objEntityDetails.CertProcDtlName = objclsWBData.LNKTXT;
                    objEntityDetails.DtlSubmit = Convert.ToInt32(objclsWBData.SCORECHK);
                    if (objclsWBData.SELCTDATE != "")
                    {
                        objEntityDetails.Detaildate = objCommon.textToDateTime(objclsWBData.SELCTDATE);
                    }
                    else
                    {
                        objEntityDetails.Detaildate = DateTime.MinValue;
                    }
                    objEntityDetails.Dtlverify = Convert.ToInt32(objclsWBData.CHKBOXSUB);
                    objEntityDetails.DtlSts = Convert.ToInt32(objclsWBData.VALSTATUS);




                    string jsonFileid = "uploadimportFiles" + rowId;


                    HttpPostedFile PostedFile = Request.Files["uploadimportFiles" + rowId];

                    if (PostedFile.ContentLength > 0)
                    {
                        // clsJoiningWorkerDtl objEntityJWorkerDtl = new clsJoiningWorkerDtl();
                        string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                        objEntityDetails.ActualFileName = strFileName;
                        string strFileExt;

                        strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

                        //  int intImageSectionOtherDocu = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CERTIFICATE_VERIFICATION);
                        string year = DateTime.Today.Year.ToString();
                        string strImageName = "DOC_" + year + intImgCount + "_" + objEntityIntrvTem.NextProcId.ToString() + "." + strFileExt;
                        objEntityDetails.FileName = strImageName;
                        string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CERTIFICATE_VERIFICATION);

                        PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityDetails.FileName);
                        intImgCount++;

                    }


                    objEntityCrtfnDetilsList.Add(objEntityDetails);
                }
            }

            objBusinessIntrvTem.InsertVerfcnProcess(objEntityIntrvTem, objEntityCrtfnDetilsList);
            // objBusinessInterviewCategory.InsertInterviewCategory(objEntityInterviewCategory, objEntityInterviewCategoryDetilsList);
            if (clickedButton.ID == "btnAdd")
            {
               // string strEncId = Request.QueryString["Id"].ToString();
                Response.Redirect("hcm_Crtfct_Verfctn_Process.aspx?InsUpd=Ins");
                //Response.Redirect("gen_Candidate_Selection.aspx?InsUpd=Save");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("hcm_Crtfct_Verfctn_Process_List.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "ButtonCompl")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ValidateComplt", "ValidateComplt();", true);
            }

        }
        catch (Exception ex)
        {
            //throw ex;
            ScriptManager.RegisterStartupScript(this, GetType(), "ErrMsg", "ErrMsg();", true);
        }
    }
    
    public class clsWBData
    {
        public string ROWID { get; set; }
        public string LNKTXT { get; set; }
        public string SCORECHK { get; set; }
        public string SELCTDATE { get; set; }
        public string CHKBOXSUB { get; set; }
        public string VALSTATUS { get; set; }

        public string ACTFILENAME { get; set; }
        public string EVTACTION { get; set; }
        public string DTLID { get; set; }
 
        //public string FILENAME { get; set; }

        

    }
    public class DynamicTable 
    {
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
    }
    [WebMethod]
    public static string ChangeJobRole(string ddlCandSEl, string corpId, string orgID)
    {

        
        clcBusiness_Crtfct_Verfctn_Process objBusinessIntrvTem = new clcBusiness_Crtfct_Verfctn_Process();
        clsEntity_Crtfct_Verfctn_Process objEntityIntrvTem = new clsEntity_Crtfct_Verfctn_Process();
        objEntityIntrvTem.CandId =Convert.ToInt32(ddlCandSEl);
        objEntityIntrvTem.OrgId = Convert.ToInt32(orgID);
        objEntityIntrvTem.CorpId = Convert.ToInt32(corpId);
        DataTable dtEmployeeList = new DataTable();
        dtEmployeeList = objBusinessIntrvTem.ReadJobRole(objEntityIntrvTem);
        string strRet = "";
        if (dtEmployeeList.Rows.Count > 0)
        {
            strRet = dtEmployeeList.Rows[0]["DSGN_NAME"].ToString() + "," + dtEmployeeList.Rows[0]["MNP_DESIGID"].ToString();
        }
       return strRet;
    }
    [WebMethod]
    public static string ChangeCertfBundle(string ddlCertBundl, string corpId, string orgID)
    {
        DynamicTable objconvert = new DynamicTable();
        clcBusiness_Crtfct_Verfctn_Process objBusinessIntrvTem = new clcBusiness_Crtfct_Verfctn_Process();
        clsEntity_Crtfct_Verfctn_Process objEntityIntrvTem = new clsEntity_Crtfct_Verfctn_Process();
        objEntityIntrvTem.CertVerctnProcId = Convert.ToInt32(ddlCertBundl);
        objEntityIntrvTem.OrgId = Convert.ToInt32(orgID);
        objEntityIntrvTem.CorpId = Convert.ToInt32(corpId);
        DataTable dtEmployeeList = new DataTable();
        dtEmployeeList = objBusinessIntrvTem.ReadCertfctBundle(objEntityIntrvTem);
        string strRet = "";
        if (dtEmployeeList.Rows.Count > 0)
        {
            DataTable dtDetail = new DataTable();
           
            dtDetail.Columns.Add("BUNDLE_NAME", typeof(string));
            dtDetail.Columns.Add("BUNDLE_ID", typeof(int));


            foreach (DataRow dr in dtEmployeeList.Rows)
            {
                
                DataRow drDtl = dtDetail.NewRow();

                drDtl["BUNDLE_NAME"] = dr["CRTFTBNDLTEMDTL_NAME"].ToString();
                drDtl["BUNDLE_ID"] = dr["CRTFTBNDLTEMDTL_ID"].ToString();
               

                dtDetail.Rows.Add(drDtl);
    

            }

            string strJson = objconvert.DataTableToJSONWithJavaScriptSerializer(dtDetail);
            strRet = strJson;
            
        }
        return strRet;
    }

    

         [WebMethod]
    public static string ChangeToComplete(string NextId, string corpId, string orgID, string userid)
    {

        
        clcBusiness_Crtfct_Verfctn_Process objBusinessIntrvTem = new clcBusiness_Crtfct_Verfctn_Process();
        clsEntity_Crtfct_Verfctn_Process objEntityIntrvTem = new clsEntity_Crtfct_Verfctn_Process();
     

        string strRet = "success";
        objEntityIntrvTem.OrgId = Convert.ToInt32(orgID);
        objEntityIntrvTem.CorpId = Convert.ToInt32(corpId);
        objEntityIntrvTem.UsrId = Convert.ToInt32(userid);

        objEntityIntrvTem.NextProcId = Convert.ToInt32(NextId);
        try
        {
            objBusinessIntrvTem.ChangeReqToConplete(objEntityIntrvTem);
        }
        catch
        {
            strRet = "failed";
        }
        return strRet;
     
    }
}