using System;  
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DL_Compzit.DataLayer_PMS;
using BL_Compzit.BusinessLayer_PMS;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.ComponentModel;
using EL_Compzit;
using CL_Compzit;
using BL_Compzit;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Collections;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Web.Services;
using System.IO;
using System.Net;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

[System.Web.Script.Services.ScriptService]
public partial class Master_gen_Document_Workflow_gen_Document_Workflow : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {

        clsBusinessLayerPMS objEntitybuspms = new clsBusinessLayerPMS();

        if (!IsPostBack)
        {
            this.txtName.Focus();
            Read_Document();
            Read_Departments();
            Read_Divisions();
            Read_hrchyname();
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableConfirm = 0, intEnableReopne = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

            clsEntityApprovalHierarchyTemp objEntity = new clsEntityApprovalHierarchyTemp();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntity.Corporate_id = intCorpId;
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            int intOrgId = 0;
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntity.Organisation_id = intOrgId;
            }
            //Allocating child roles

            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Document_Workflow);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intEnableReopne = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenFieldReopen.Value = "1";
                    }
                }
            }
            if (intEnableConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                //Msgbox(intEnableConfirm.ToString());
            }
            else
            {
                btnCnfrm1.Visible = false;
                btnCnfrm1Float.Visible = false;
            }

            btnReopen1.Visible = false;
            btnReopen1Float.Visible = false;

            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                //DisableAllControls(Page);
                lblEntry.InnerHtml = "Edit Document Workflow";

                btnSave.Visible = false;
                btnSaveFloat.Visible = false;
                btnsaveclose.Visible = false;
                btnsavecloseFloat.Visible = false;

                btnUpdate.Visible = true;
                btnUpdateFloat.Visible = true;
                btnUpdateClose.Visible = true;
                btnUpdateCloseFloat.Visible = true;

                btnCnfrm1.Visible = true;
                btnCnfrm1Float.Visible = true;

                btnClear.Visible = false;
                btnClearFloat.Visible = false;

                HiddenFieldAprvlHierarchyId.Value = strId;
                Hiddenhrytest.Value = strId;
                HiddenHrchyId.Value = strId;
                if (intEnableConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {

                }
                else
                {
                    btnCnfrm1.Visible = false;
                    btnCnfrm1Float.Visible = false;
                }

                WRKFLW(strId, 0);

                HiddenHrchyId.Value = strId;
                hiddenEditMode.Value = "1";
            }
            //when  viewing
            else if (Request.QueryString["Id1"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id1"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                if (intEnableConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    // Msgbox(intEnableConfirm.ToString());
                }
                else
                {
                    btnCnfrm1.Visible = false;
                    btnCnfrm1Float.Visible = false;
                }
                WRKFLW(strId, 0);
                HiddenFieldView.Value = "1";
                HiddenHrchyId.Value = strId;
                hiddenEditMode.Value = "2";
            }
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                DisableAllControls(Page);

                btnSave.Visible = false;
                btnSaveFloat.Visible = false;
                btnsaveclose.Visible = false;
                btnsavecloseFloat.Visible = false;

                btnUpdate.Visible = false;
                btnUpdateFloat.Visible = false;
                btnUpdateClose.Visible = false;
                btnUpdateCloseFloat.Visible = false;
                btnCnfrm1.Visible = false;
                btnCnfrm1Float.Visible = false;
                btnEcnfrm.Visible = false;

                btnReopen1.Visible = false;
                btnReopen1Float.Visible = false;

                btnClear.Visible = false;
                btnClearFloat.Visible = false;
                btnCancel.Visible = true;

                WRKFLW(strId, 0);

                HiddenFieldView.Value = "1";
                HiddenHrchyId.Value = strId;
                hiddenEditMode.Value = "2";
            }
            else
            {

            }
            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessIns", "SuccessIns();", true);
                }
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpd", "SuccessUpd();", true);
                }
                else if (strInsUpd == "Cnfm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCnfm", "SuccessCnfm();", true);
                }
                else if (strInsUpd == "Reopen")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReopen", "SuccessReopen();", true);
                }
                else if (strInsUpd == "AlrdyCncl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AlreadyDeleted", "AlreadyDeleted();", true);
                }
            }


        }
    }

    [WebMethod]
    public static string[] ReadDesgDdl(string strLikeEmployee, int orgID, int corptID)
    {
        List<string> Employees = new List<string>();
        clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
        clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
        objentityPassport.Corporate_id = corptID;
        objentityPassport.Organisation_id = orgID;
        DataTable dtEmployess = objBussinesspasprt.ReadDesgDDL(strLikeEmployee.ToUpper(), objentityPassport);
        for (int intRowCount = 0; intRowCount < dtEmployess.Rows.Count; intRowCount++)
        {
            Employees.Add(string.Format("{0}<->{1}", dtEmployess.Rows[intRowCount]["DSGN_ID"].ToString(), dtEmployess.Rows[intRowCount]["DSGN_NAME"].ToString()));
        }
        return Employees.ToArray();
    }

    [WebMethod]
    public static string[] changeDesg(string strLikeEmployee, int orgID, int corptID, string DesgId)
    {
        List<string> Employees = new List<string>();
        clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
        clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
        objentityPassport.Corporate_id = Convert.ToInt32(corptID);
        objentityPassport.Organisation_id = Convert.ToInt32(orgID);
        objentityPassport.DesgId = Convert.ToInt32(DesgId);
        DataTable dtEmployess = objBussinesspasprt.ReadEmployeeDDL(strLikeEmployee.ToUpper(), objentityPassport);
        for (int intRowCount = 0; intRowCount < dtEmployess.Rows.Count; intRowCount++)
        {
            Employees.Add(string.Format("{0}<->{1}", dtEmployess.Rows[intRowCount]["USR_ID"].ToString(), dtEmployess.Rows[intRowCount]["USR_NAME"].ToString()));
        }
        return Employees.ToArray();
    }
    [WebMethod]
    public static string checkDup(string Name2)
    {
        string arr = "";
        try
        {
            clsEntityApprovalHierarchyTemp objentityPass1 = new clsEntityApprovalHierarchyTemp();
            clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();

            objentityPass1.Name = Name2;
            DataTable dtSubConrt = objBussinesspasprt.Readwrkflwname(objentityPass1);

            if (dtSubConrt.Rows[0][0].ToString() != "0")
            {
                arr = "dup";
            }
        }
        catch (Exception ex)
        {
        }
        return arr;
    }
    [WebMethod]
    public static string checkEmpDuplication(string orgID, string corptID, string Id, string DtlId, string EmpId, string CanclIds)
    {
        string arr = "";
        try
        {
            clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
            clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
            objentityPassport.Corporate_id = Convert.ToInt32(corptID);
            objentityPassport.Organisation_id = Convert.ToInt32(orgID);
            objentityPassport.TempId = Convert.ToInt32(Id);
            objentityPassport.ParentId = Convert.ToInt32(DtlId);
            objentityPassport.EmployeeId = Convert.ToInt32(EmpId);
            objentityPassport.CancelReason = CanclIds.Replace('-', ',');
            DataTable dtSubConrt = objBussinesspasprt.CheckEmpDup(objentityPassport);
            if (dtSubConrt.Rows[0][0].ToString() != "0")
            {
                arr = "dup";
            }
        }
        catch (Exception ex)
        {
        }
        return arr;
    }

    public class clsTVData
    {
        public string DL { get; set; }
        public string DTLID { get; set; }
        public string TRAIL { get; set; }
        public string LEVEL { get; set; }
        public string DESGID { get; set; }
        public string EMPID { get; set; }
        public string APPRVMANSTS { get; set; }
        public string SUBEMPSTS { get; set; }
        public string THRESMODE { get; set; }
        public string PERIOD { get; set; }
        public string APPRVPENSTS { get; set; }
        public string TTCSTS { get; set; }
        public string SMSSTS { get; set; }
        public string SYSSTS { get; set; }
        public string PARENT { get; set; }
        public string IDDL { get; set; }
        public string RO { get; set; }
        public int ROWID { get; set; }
    }
    public void WRKFLW(string id, int mode)
    {
        clsBusinessLayerPMS objEntitybuspms = new clsBusinessLayerPMS();
        clsEntityApprovalHierarchyTemp objentityPass1 = new clsEntityApprovalHierarchyTemp();
        clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();

        objentityPass1.Name = id;
        objentityPass1.TempId = Convert.ToInt32(id);

        DataTable dts = objEntitybuspms.Readwrkflwdid1(objentityPass1);

        DataTable dt = objEntitybuspms.Readwrkflwdtls11(objentityPass1);

        if (dt.Rows.Count > 0)
        {
            HiddenWrkname.Value = dt.Rows[0]["WRKFLW_NAME"].ToString();
            txtName.Text = dt.Rows[0]["WRKFLW_NAME"].ToString();
            if (docsection.Items.FindByValue(dt.Rows[0]["DOC_ID"].ToString()) != null)
            {
                docsection.Items.FindByValue(dt.Rows[0]["DOC_ID"].ToString()).Selected = true;
            }
            if (dt.Rows[0]["WRKFLW_STATUS"].ToString() == "1")
            {
                cbxsts.Checked = true;
            }
            else
            {
                cbxsts.Checked = false;
            }
            txtDescr.Text = dt.Rows[0]["WRKFLW_DESCRIPTN"].ToString();
            if (dt.Rows[0]["WRKFLW_APRVL_TRNSFR"].ToString() == "1")
            {
                cbxapr.Checked = true;
            }
            else
            {
                cbxapr.Checked = false;
            }
            if (dt.Rows[0]["WRKFLW_APRVR_MODFY"].ToString() == "1")
            {
                cbxmdfy.Checked = true;
            }
            else
            {
                cbxmdfy.Checked = false;
            }
            if (dt.Rows[0]["WRKFLW_PRIORTY"].ToString() == "0")
            {
                rbMedium.Checked = true;
            }
            else
            {
                rbHigh.Checked = true;
            }
            if (dlHrchy.Items.FindByValue(dt.Rows[0]["HRCHY_ID"].ToString()) != null)
            {
                dlHrchy.Items.FindByValue(dt.Rows[0]["HRCHY_ID"].ToString()).Selected = true;
            }
            //dlHrchy.Attributes.Add("readonly","true");
            //dlHrchy.Attributes.Add("style", "pointer-events:none;");

            if (dt.Rows[0]["WRKFLW_APRVL_PNDNG_MSG_STS"].ToString() == "1")
            {
                cbxaprpnd.Checked = true;
            }
            else
            {
                cbxaprpnd.Checked = false;
            }
            if (dt.Rows[0]["WRKFLW_SMS_MSG_STS"].ToString() == "1")
            {
                cbxsm.Checked = true;
            }
            else
            {
                cbxsm.Checked = false;
            }
            if (dt.Rows[0]["WRKFLW_DASHBRD_MSG_STS"].ToString() == "1")
            {
                cbxnt.Checked = true;
            }
            else
            {
                cbxnt.Checked = false;
            }
            if (dt.Rows[0]["WRKFLW_TTC_EXCD_MSG_STS"].ToString() == "1")
            {
                cbxTmExd.Checked = true;
            }
            else
            {
                cbxTmExd.Checked = false;
            }
            string dep = dt.Rows[0]["WRKFLW_CPRDEPT_IDS"].ToString();
            string[] words = dep.Split(',');

            foreach (string word in words)
            {
                objentityPass1.Dep = word;

                for (int j = 0; j < lstDpt.Items.Count; j++)

                    if (word == lstDpt.Items[j].Value)
                    {
                        lstDpt.Items[j].Selected = true;
                    }
            }
            string div = dt.Rows[0]["WRKFLW_CPRDIV_IDS"].ToString();
            string[] words1 = div.Split(',');

            foreach (string word1 in words1)
            {
                objentityPass1.div = word1;

                DataTable dt2 = objEntitybuspms.selectdiv(objentityPass1);

                for (int j = 0; j < lstDiv.Items.Count; j++)
                {
                    if (word1 == lstDiv.Items[j].Value)
                    {
                        //Msgbox(sd1);
                        lstDiv.Items[j].Selected = true;
                    }
                }
            }
            if (dt.Rows[0]["WRKFLW_STRTDATE"].ToString() != "")
            {
                DateTime dat = Convert.ToDateTime(dt.Rows[0]["WRKFLW_STRTDATE"].ToString());
                dte_1_a.Value = dat.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                dte_1_a.Value = "";
            }
            if (dt.Rows[0]["WRKFLW_ENDDATE"].ToString() != "")
            {
                DateTime Edat = Convert.ToDateTime(dt.Rows[0]["WRKFLW_ENDDATE"].ToString());
                dte_1.Value = Edat.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                dte_1.Value = "";
            }

            string strId = id;
            if (dt.Rows[0]["WRKFLW_CONFRM_STS"].ToString() == "1")
            {
                Hiddenview.Value = "1";
                DisableAllControls(Page);

                btnReopen.Enabled = true;

                btnReopen1.Enabled = true;
                btnReopen1Float.Enabled = true;
                btnCancel.Enabled = true;
                btnCancelFloat.Enabled = true;

                btnUpdate.Visible = false;
                btnUpdateFloat.Visible = false;
                btnUpdateClose.Visible = false;
                btnUpdateCloseFloat.Visible = false;
                btnCnfrm1.Visible = false;
                btnCnfrm1Float.Visible = false;

                btnReopen1.Visible = true;
                btnReopen1Float.Visible = true;

                this.lstDiv.Attributes.Add("disabled", "");
                this.lstDpt.Attributes.Add("disabled", "");
                dte_1_a.Attributes["disabled"] = "disabled";

                if (HiddenFieldReopen.Value == "1")
                {
                    btnReopen1.Visible = false;
                    btnReopen1Float.Visible = false;
                }
                else
                {
                    //Msgbox(intEnableReopne.ToString());
                    btnReopen1.Visible = true;
                    btnReopen1Float.Visible = true;
                }
                clsDataLayerPMS objBussinesspasprt1 = new clsDataLayerPMS();
                objentityPass1.TempId = Convert.ToInt32(id);

                DataTable dt3 = objBussinesspasprt1.ReadApprovalAss(objentityPass1);
                if (dt3.Rows.Count > 0)
                {
                    btnReopen1.Visible = false;
                    btnReopen1Float.Visible = false;

                    btnReopen.Enabled = false;
                    btnReopen1.Enabled = false;
                    btnReopen1Float.Enabled = false;
                }
                else
                {
                    btnReopen1.Visible = true;
                    btnReopen1Float.Visible = true;

                    btnReopen.Enabled = true;
                    btnReopen1.Enabled = true;
                    btnReopen1Float.Enabled = true;
                }
            }
            else
            {
                EnableAllControls(Page);
                btnReopen.Enabled = false;

                btnReopen1.Enabled = false;
                btnReopen1Float.Enabled = false;
                btnCancel.Enabled = true;
                btnCancelFloat.Enabled = true;
            }

            HiddenFieldwrkId.Value = strId;
            if (Request.QueryString["ViewId"] != null)
            {
                Hiddenview.Value = "1";
                DisableAllControls(Page);
                
                btnSave.Visible = false;
                btnSaveFloat.Visible = false;

                btnUpdate.Visible = false;
                btnUpdateFloat.Visible = false;
                btnCnfrm1.Visible = false;
                btnCnfrm1Float.Visible = false;
                btnEcnfrm.Visible = false;

                btnReopen1.Visible = false;
                btnReopen1Float.Visible = false;

                btnCancel.Visible = true;
                btnCancel.Enabled = true;
                btnCancelFloat.Enabled = true;
                cbsdate.Enabled = false;

                this.lstDiv.Attributes.Add("disabled", "");
                this.lstDpt.Attributes.Add("disabled", "");
            }

            if (Convert.ToInt32(dt.Rows[0]["CNT"].ToString()) > 0)
            {
                btnReopen1.Visible = false;
                btnReopen1Float.Visible = false;
            }

            //Msgbox(strId);
            Update1(strId, 0);
        }
    }
    private void DisableAllControls(Control Page)
    {
        foreach (Control ctrl in Page.Controls)
        {
            if (ctrl is TextBox) ((TextBox)(ctrl)).Enabled = false;
            else if (ctrl is Button) ((Button)(ctrl)).Enabled = false;
            else if (ctrl is DropDownList) ((DropDownList)(ctrl)).Enabled = false;
            else if (ctrl is ListBox) ((ListBox)(ctrl)).Enabled = false;
            else if (ctrl is CheckBox) ((CheckBox)(ctrl)).Enabled = false;
            else if (ctrl is CheckBoxList) ((CheckBoxList)(ctrl)).Enabled = false;
            else if (ctrl is RadioButton) ((RadioButton)(ctrl)).Enabled = false;
            else if (ctrl is RadioButtonList) ((RadioButtonList)(ctrl)).Enabled = false;
            else
            {
                if (ctrl.Controls.Count > 0) DisableAllControls(ctrl);
            }
        }
    }

    private void EnableAllControls(Control Page)
    {
        foreach (Control ctrl in Page.Controls)
        {
            if (ctrl is TextBox) ((TextBox)(ctrl)).Enabled = true;
            else if (ctrl is Button) ((Button)(ctrl)).Enabled = true;
            else if (ctrl is DropDownList) ((DropDownList)(ctrl)).Enabled = true;
            else if (ctrl is ListBox) ((ListBox)(ctrl)).Enabled = true;
            else if (ctrl is CheckBox) ((CheckBox)(ctrl)).Enabled = true;
            else if (ctrl is CheckBoxList) ((CheckBoxList)(ctrl)).Enabled = true;
            else if (ctrl is RadioButton) ((RadioButton)(ctrl)).Enabled = true;
            else if (ctrl is RadioButtonList) ((RadioButtonList)(ctrl)).Enabled = true;
            else
            {
                if (ctrl.Controls.Count > 0) EnableAllControls(ctrl);
            }
        }
    }
    public void Update1(string id, int mode)
    {

        HiddenFieldwrkId.Value = id;

        clsEntityApprovalHierarchyTemp objentityPass = new clsEntityApprovalHierarchyTemp();
        clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();

        objentityPass.TempId = Convert.ToInt32(id);

        DataTable dt = objBussinesspasprt.ReadDocumentdtls(objentityPass);
        if (dt.Rows.Count > 0)
        {

            HiddenHrchyname.Value = dt.Rows[0]["WRKFLW_NAME"].ToString();
            if (dt.Rows[0]["WRKFLW_STATUS"].ToString() == "0")
            {
                cbxhrsts.Checked = false;
            }
            else
            {
                cbxhrsts.Checked = true;
            }

            if (dt.Rows[0]["WRKFLW_STRTDATE"].ToString() != "")
            {
                cbsdate.Checked = true;
                dte_1_a.Value = dt.Rows[0]["WRKFLW_STRTDATE"].ToString();

            }
            if (dt.Rows[0]["WRKFLW_ENDDATE"].ToString() != "")
            {
                cbEdate.Checked = true;
                dte_1.Value = dt.Rows[0]["WRKFLW_ENDDATE"].ToString();
            }

            StringBuilder objstr = new StringBuilder();

            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("DTLID", typeof(string));
            dtDetail.Columns.Add("TRAIL", typeof(string));
            dtDetail.Columns.Add("LEVEL", typeof(string));
            dtDetail.Columns.Add("DESGID", typeof(string));
            dtDetail.Columns.Add("EMPID", typeof(string));
            dtDetail.Columns.Add("APPRVMANSTS", typeof(string));
            dtDetail.Columns.Add("SUBEMPSTS", typeof(string));
            dtDetail.Columns.Add("THRESMODE", typeof(string));
            dtDetail.Columns.Add("PERIOD", typeof(string));
            dtDetail.Columns.Add("APPRVPENSTS", typeof(string));
            dtDetail.Columns.Add("TTCSTS", typeof(string));
            dtDetail.Columns.Add("SMSSTS", typeof(string));
            dtDetail.Columns.Add("SYSSTS", typeof(string));
            dtDetail.Columns.Add("NAME", typeof(string));
            dtDetail.Columns.Add("DESGNAME", typeof(string));
            dtDetail.Columns.Add("PARENT", typeof(string));
            for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
            {
                int a = intCount + 1;
                DataRow drDtl = dtDetail.NewRow();
                drDtl["DTLID"] = dt.Rows[intCount]["WRKFLW_DTL_ID"].ToString();
                drDtl["TRAIL"] = a.ToString();
                drDtl["LEVEL"] = dt.Rows[intCount]["WRKFLW_LEVEL"].ToString();
                drDtl["DESGID"] = dt.Rows[intCount]["DSGN_ID"].ToString();
                drDtl["EMPID"] = dt.Rows[intCount]["USR_ID"].ToString();
                drDtl["APPRVMANSTS"] = dt.Rows[intCount]["WRKFLW_APRVL_MNDTRY_STS"].ToString();
                drDtl["SUBEMPSTS"] = dt.Rows[intCount]["WRKFLW_SUBSTUTE_STS"].ToString();
                drDtl["THRESMODE"] = dt.Rows[intCount]["WRKFLW_THRSHOLD_PRD_STS"].ToString();
                drDtl["PERIOD"] = dt.Rows[intCount]["WRKFLW_THRSHOLD_PERIOD"].ToString();
                drDtl["APPRVPENSTS"] = dt.Rows[intCount]["WRKFLW_APRVL_PENDING_MSG_STS"].ToString();
                drDtl["TTCSTS"] = dt.Rows[intCount]["WRKFLW_TTC_EXCD_MSG_STS"].ToString();
                drDtl["SMSSTS"] = dt.Rows[intCount]["WRKFLW_SMS_MSG_STS"].ToString();
                drDtl["SYSSTS"] = dt.Rows[intCount]["WRKFLW_DASHBRD_MSG_STS"].ToString();
                drDtl["NAME"] = dt.Rows[intCount]["USR_NAME"].ToString();
                drDtl["DESGNAME"] = dt.Rows[intCount]["DSGN_NAME"].ToString();
                drDtl["PARENT"] = "1";
                dtDetail.Rows.Add(drDtl);

                objstr.Append("<li>");
                objstr.Append("<span><i class=\"fa fa-black-tie\"></i>" + dt.Rows[intCount]["USR_NAME"].ToString() + "</span>");
                objstr.Append("<button onclick=\"return FuctionOrganize1('" + dt.Rows[intCount]["WRKFLW_DTL_ID"].ToString() + "','" + dt.Rows[intCount]["WRKFLW_LEVEL"].ToString() + "','" + dt.Rows[intCount]["USR_NAME"].ToString() + "','" + HiddenFieldwrkId.Value + "');\" class=\"edt_1 tablinks notv\"><i class=\"fa fa-edit\"></i></button>");
                objstr.Append(bindSubmenu1(dt.Rows[intCount]["WRKFLW_DTL_ID"].ToString()));
                objstr.Append("<li>");

            }
            string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
            HiddenEdit.Value = strJson;

            myTab1.InnerHtml = objstr.ToString();

        }
    }
    public string bindSubmenu1(string DtlId)
    {

        StringBuilder objstr = new StringBuilder();
        clsEntityApprovalHierarchyTemp objentityPass = new clsEntityApprovalHierarchyTemp();
        clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
        objentityPass.TempId = Convert.ToInt32(DtlId);
        DataTable dt = objBussinesspasprt.ReadSubtableDOCDtls(objentityPass);
        if (dt.Rows.Count > 0)
        {

            objstr.Append("<ul>");
            for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
            {
                string UserName = dt.Rows[intCount]["USR_NAME"].ToString();
                objstr.Append("<li>");
                objstr.Append("<span><i class=\"fa fa-black-tie\"></i>" + dt.Rows[intCount]["USR_NAME"].ToString() + "</span>");
                objstr.Append("<button onclick=\"return FuctionOrganize1('" + dt.Rows[intCount]["WRKFLW_DTL_ID"].ToString() + "','" + dt.Rows[intCount]["WRKFLW_LEVEL"].ToString() + "','" + dt.Rows[intCount]["USR_NAME"].ToString() + "','" + HiddenFieldwrkId.Value + "');\" class=\"edt_1 tablinks notv\"><i class=\"fa fa-edit\"></i></button>");
                objstr.Append(bindSubmenu1(dt.Rows[intCount]["WRKFLW_DTL_ID"].ToString()));
                objstr.Append("</li>");
            }
            objstr.Append("</ul>");
        }
        return objstr.ToString();
    }
    [WebMethod]
    public static string ReadSubtableDOCDtls(string orgID, string corptID, string DtlId)
    {
        string arr = "";

        try
        {
            clsEntityApprovalHierarchyTemp objentityPass = new clsEntityApprovalHierarchyTemp();
            clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
            objentityPass.Corporate_id = Convert.ToInt32(corptID);
            objentityPass.Organisation_id = Convert.ToInt32(orgID);

            objentityPass.TempId = Convert.ToInt32(DtlId);

            DataTable dt = objBussinesspasprt.ReadSubtableDOCDtls(objentityPass);
            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("DTLID", typeof(string));
            dtDetail.Columns.Add("TRAIL", typeof(string));
            dtDetail.Columns.Add("LEVEL", typeof(string));


            dtDetail.Columns.Add("DESGID", typeof(string));
            dtDetail.Columns.Add("EMPID", typeof(string));
            dtDetail.Columns.Add("APPRVMANSTS", typeof(string));
            dtDetail.Columns.Add("SUBEMPSTS", typeof(string));
            dtDetail.Columns.Add("THRESMODE", typeof(string));
            dtDetail.Columns.Add("PERIOD", typeof(string));
            dtDetail.Columns.Add("APPRVPENSTS", typeof(string));
            dtDetail.Columns.Add("TTCSTS", typeof(string));
            dtDetail.Columns.Add("SMSSTS", typeof(string));
            dtDetail.Columns.Add("SYSSTS", typeof(string));
            dtDetail.Columns.Add("SUBORDNUM", typeof(string));
            dtDetail.Columns.Add("NAME", typeof(string));
            dtDetail.Columns.Add("DESGNAME", typeof(string));

            for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
            {
                DataRow drDtl = dtDetail.NewRow();
                int a = intCount + 1;
                drDtl["DTLID"] = dt.Rows[intCount]["WRKFLW_DTL_ID"].ToString();
                drDtl["TRAIL"] = a.ToString();
                drDtl["LEVEL"] = dt.Rows[intCount]["WRKFLW_LEVEL"].ToString();
                drDtl["DESGID"] = dt.Rows[intCount]["DSGN_ID"].ToString();
                drDtl["EMPID"] = dt.Rows[intCount]["USR_ID"].ToString();
                drDtl["APPRVMANSTS"] = dt.Rows[intCount]["WRKFLW_APRVL_MNDTRY_STS"].ToString();
                drDtl["SUBEMPSTS"] = dt.Rows[intCount]["WRKFLW_SUBSTUTE_STS"].ToString();
                drDtl["THRESMODE"] = dt.Rows[intCount]["WRKFLW_THRSHOLD_PRD_STS"].ToString();
                drDtl["PERIOD"] = dt.Rows[intCount]["WRKFLW_THRSHOLD_PERIOD"].ToString();
                drDtl["APPRVPENSTS"] = dt.Rows[intCount]["WRKFLW_APRVL_PENDING_MSG_STS"].ToString();
                drDtl["TTCSTS"] = dt.Rows[intCount]["WRKFLW_TTC_EXCD_MSG_STS"].ToString();
                drDtl["SMSSTS"] = dt.Rows[intCount]["WRKFLW_SMS_MSG_STS"].ToString();
                drDtl["SYSSTS"] = dt.Rows[intCount]["WRKFLW_DASHBRD_MSG_STS"].ToString();
                drDtl["SUBORDNUM"] = dt.Rows[intCount]["SUBORD_NUM"].ToString();
                drDtl["NAME"] = dt.Rows[intCount]["USR_NAME"].ToString();
                drDtl["DESGNAME"] = dt.Rows[intCount]["DSGN_NAME"].ToString();
                dtDetail.Rows.Add(drDtl);
            }
            if (dt.Rows.Count > 0)
            {
                arr = DataTableToJSONWithJavaScriptSerializer(dtDetail);

            }
        }
        catch (Exception ex)
        {
        }
        return arr;
    }

    public void Update(string id, int mode)
    {
        HiddenFieldwrkId.Value = "";

        clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
        clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
        //Msgbox(id.ToString());
        objentityPassport.TempId = Convert.ToInt32(id);
        DataTable dt = objBussinesspasprt.ReadTemplatedtls(objentityPassport);

        if (dt.Rows.Count > 0)
        {
            HiddenHrchyname.Value = dt.Rows[0]["HRCHY_NAME"].ToString();
            if (dt.Rows[0]["HRCHY_STATUS"].ToString() == "0")
            {
                cbxhrsts.Checked = false;
            }
            else
            {
                cbxhrsts.Checked = true;
            }
            if (dt.Rows[0]["HRCHY_STRTDATE"].ToString() != "")
            {
                cbsdate.Checked = true;
                dte_1_a.Value = dt.Rows[0]["HRCHY_STRTDATE"].ToString();
            }
            if (dt.Rows[0]["HRCHY_ENDDATE"].ToString() != "")
            {
                cbEdate.Checked = true;
                dte_1.Value = dt.Rows[0]["HRCHY_ENDDATE"].ToString();
            }

            StringBuilder objstr = new StringBuilder();

            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("DTLID", typeof(string));
            dtDetail.Columns.Add("TRAIL", typeof(string));
            dtDetail.Columns.Add("LEVEL", typeof(string));
            dtDetail.Columns.Add("DESGID", typeof(string));
            dtDetail.Columns.Add("EMPID", typeof(string));
            dtDetail.Columns.Add("APPRVMANSTS", typeof(string));
            dtDetail.Columns.Add("SUBEMPSTS", typeof(string));
            dtDetail.Columns.Add("THRESMODE", typeof(string));
            dtDetail.Columns.Add("PERIOD", typeof(string));
            dtDetail.Columns.Add("APPRVPENSTS", typeof(string));
            dtDetail.Columns.Add("TTCSTS", typeof(string));
            dtDetail.Columns.Add("SMSSTS", typeof(string));
            dtDetail.Columns.Add("SYSSTS", typeof(string));
            dtDetail.Columns.Add("NAME", typeof(string));
            dtDetail.Columns.Add("DESGNAME", typeof(string));
            dtDetail.Columns.Add("PARENT", typeof(string));

            for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
            {
                int a = intCount + 1;
                DataRow drDtl = dtDetail.NewRow();
                drDtl["DTLID"] = dt.Rows[intCount]["HRCHY_DTL_ID"].ToString();
                drDtl["TRAIL"] = a.ToString();
                drDtl["LEVEL"] = dt.Rows[intCount]["HRCHY_LEVEL"].ToString();
                drDtl["DESGID"] = dt.Rows[intCount]["DSGN_ID"].ToString();
                drDtl["EMPID"] = dt.Rows[intCount]["USR_ID"].ToString();
                drDtl["APPRVMANSTS"] = dt.Rows[intCount]["HRCHY_APRVL_MNDTRY_STS"].ToString();
                drDtl["SUBEMPSTS"] = dt.Rows[intCount]["HRCHY_SUBSTUTE_STS"].ToString();
                drDtl["THRESMODE"] = dt.Rows[intCount]["HRCHY_THRSHOLD_PRD_STS"].ToString();
                drDtl["PERIOD"] = dt.Rows[intCount]["HRCHY_THRSHOLD_PERIOD"].ToString();
                drDtl["APPRVPENSTS"] = dt.Rows[intCount]["HRCHY_APRVL_PENDING_MSG_STS"].ToString();
                drDtl["TTCSTS"] = dt.Rows[intCount]["HRCHY_TTC_EXCD_MSG_STS"].ToString();
                drDtl["SMSSTS"] = dt.Rows[intCount]["HRCHY_SMS_MSG_STS"].ToString();
                drDtl["SYSSTS"] = dt.Rows[intCount]["HRCHY_DASHBRD_MSG_STS"].ToString();
                drDtl["NAME"] = dt.Rows[intCount]["USR_NAME"].ToString();
                drDtl["DESGNAME"] = dt.Rows[intCount]["DSGN_NAME"].ToString();

                objentityPassport.TempId = Convert.ToInt32(dt.Rows[intCount]["HRCHY_DTL_ID"].ToString());
                DataTable dt1 = objBussinesspasprt.ReadSubtableDtls(objentityPassport);
                if (dt1.Rows.Count > 0 && dt1.Rows[0][1].ToString() != "")
                {
                    drDtl["PARENT"] = "1";

                }
                else
                {
                    drDtl["PARENT"] = "0";
                }

                dtDetail.Rows.Add(drDtl);

                objstr.Append("<li>");

                objstr.Append("<span><i class=\"fa fa-black-tie\"></i>" + dt.Rows[intCount]["USR_NAME"].ToString() + "</span>");
                objstr.Append("<button onclick=\"return FuctionOrganize('" + dt.Rows[intCount]["HRCHY_DTL_ID"].ToString() + "','" + dt.Rows[intCount]["HRCHY_LEVEL"].ToString() + "','" + dt.Rows[intCount]["USR_NAME"].ToString() + "','" + HiddenFieldwrkId.Value + "');\" class=\"edt_1 tablinks notv\"><i class=\"fa fa-edit\"></i></button>");
                objstr.Append(bindSubmenu(dt.Rows[intCount]["HRCHY_DTL_ID"].ToString()));
                objstr.Append("<li>");

            }
            string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
            HiddenEdit.Value = strJson;

            myTab1.InnerHtml = objstr.ToString();

        }
    }
    

    public void Updatesub(string id, int mode)
    {
        HiddenFieldwrkId.Value = "0";
        clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
        clsEntityApprovalHierarchyTemp objentityPass = new clsEntityApprovalHierarchyTemp();
        clsEntityApprovalHierarchyTemp objentityPa = new clsEntityApprovalHierarchyTemp();
        clsBusinessLayerPMS objBussinesspasprt = new clsBusinessLayerPMS();

        objentityPass.TempId = Convert.ToInt32(id);
        objentityPassport.TempId = Convert.ToInt32(id);

        clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt1 = new clsBusinessLayerApprovalHierarchyTemp();
        clsBusinessLayerApprovalHierarchyTemp objBussinesspas = new clsBusinessLayerApprovalHierarchyTemp();

        //Msgbox(id.ToString());
        objentityPassport.TempId = Convert.ToInt32(id);
        DataTable dt = objBussinesspas.ReadTemplatedtls(objentityPassport);


        StringBuilder objstr = new StringBuilder();
        DataTable dtDetail1 = new DataTable();
        dtDetail1.Columns.Add("DTLID", typeof(string));
        dtDetail1.Columns.Add("TRAIL", typeof(string));

        dtDetail1.Columns.Add("LEVEL", typeof(string));
        dtDetail1.Columns.Add("DESGID", typeof(string));
        dtDetail1.Columns.Add("EMPID", typeof(string));
        dtDetail1.Columns.Add("APPRVMANSTS", typeof(string));
        dtDetail1.Columns.Add("SUBEMPSTS", typeof(string));
        dtDetail1.Columns.Add("THRESMODE", typeof(string));
        dtDetail1.Columns.Add("PERIOD", typeof(string));
        dtDetail1.Columns.Add("APPRVPENSTS", typeof(string));
        dtDetail1.Columns.Add("TTCSTS", typeof(string));
        dtDetail1.Columns.Add("SMSSTS", typeof(string));
        dtDetail1.Columns.Add("SYSSTS", typeof(string));
        dtDetail1.Columns.Add("SUBORDNUM", typeof(string));
        dtDetail1.Columns.Add("NAME", typeof(string));
        dtDetail1.Columns.Add("DESGNAME", typeof(string));
        dtDetail1.Columns.Add("RO", typeof(string));
        dtDetail1.Columns.Add("PARENTID", typeof(string));

        DataTable dt1 = objBussinesspasprt.ReadSubtableDtls(objentityPass);


        if (dt1.Rows.Count > 0)
        {

            int a = dt.Rows.Count, sum = dt1.Rows.Count;
            var hro = "0";
            var dtld = "0";
            for (int intCount1 = dt1.Rows.Count - 1; intCount1 >= 0; intCount1--)
            {

                DataRow drDtl1 = dtDetail1.NewRow();

                drDtl1["DTLID"] = dt1.Rows[intCount1]["HRCHY_DTL_ID"].ToString();

                if (dt1.Rows[intCount1]["HRCHY_PARENT_DTL_ID"].ToString() != hro)
                {
                    int pr = 0;
                    if (dt1.Rows[intCount1]["HRCHY_PARENT_DTL_ID"].ToString() != "" && hro != "" && hro != "0")
                    {
                        int sum1 = sum;
                        pr = Convert.ToInt32(dt1.Rows[intCount1]["HRCHY_DTL_ID"].ToString()) - Convert.ToInt32(dt1.Rows[intCount1]["HRCHY_PARENT_DTL_ID"].ToString());
                        sum1 = sum1 - pr;
                        //Msgbox(sum1.ToString());
                        if (sum1 <= 1)
                        {
                            sum = sum + pr;
                        }
                        else
                        {
                            sum = sum - pr;
                        }
                    }
                    else if (dt1.Rows[intCount1]["HRCHY_PARENT_DTL_ID"].ToString() != "" && hro == "")
                    {
                        hro = dtld;
                        pr = Convert.ToInt32(hro) - Convert.ToInt32(dt1.Rows[intCount1]["HRCHY_PARENT_DTL_ID"].ToString());

                        sum = sum - pr;
                        sum = sum + 1;

                    }
                    else if (dt1.Rows[intCount1]["HRCHY_PARENT_DTL_ID"].ToString() != "" && hro == "0")
                    {

                        pr = Convert.ToInt32(dt1.Rows[intCount1]["HRCHY_DTL_ID"].ToString()) - Convert.ToInt32(dt1.Rows[intCount1]["HRCHY_PARENT_DTL_ID"].ToString());

                        sum = sum - pr;

                        sum = sum + 1;
                        //Msgbox(sum.ToString());
                    }
                    else
                    {
                        pr = 1;
                        sum = sum - pr;
                    }


                }
                else
                {
                    // sum = sum - 1;

                }

                if (dt1.Rows[intCount1]["HRCHY_LEVEL"].ToString() == "0")
                {
                    a = a - 1;
                }

                drDtl1["TRAIL"] = a.ToString();
                drDtl1["LEVEL"] = dt1.Rows[intCount1]["HRCHY_LEVEL"].ToString();
                drDtl1["DESGID"] = dt1.Rows[intCount1]["DSGN_ID"].ToString();
                drDtl1["EMPID"] = dt1.Rows[intCount1]["USR_ID"].ToString();
                drDtl1["APPRVMANSTS"] = dt1.Rows[intCount1]["HRCHY_APRVL_MNDTRY_STS"].ToString();
                drDtl1["SUBEMPSTS"] = dt1.Rows[intCount1]["HRCHY_SUBSTUTE_STS"].ToString();
                drDtl1["THRESMODE"] = dt1.Rows[intCount1]["HRCHY_THRSHOLD_PRD_STS"].ToString();
                drDtl1["PERIOD"] = dt1.Rows[intCount1]["HRCHY_THRSHOLD_PERIOD"].ToString();
                drDtl1["APPRVPENSTS"] = dt1.Rows[intCount1]["HRCHY_APRVL_PENDING_MSG_STS"].ToString();
                drDtl1["TTCSTS"] = dt1.Rows[intCount1]["HRCHY_TTC_EXCD_MSG_STS"].ToString();
                drDtl1["SMSSTS"] = dt1.Rows[intCount1]["HRCHY_SMS_MSG_STS"].ToString();
                drDtl1["SYSSTS"] = dt1.Rows[intCount1]["HRCHY_DASHBRD_MSG_STS"].ToString();
                drDtl1["SUBORDNUM"] = dt1.Rows[intCount1]["SUBORD_NUM"].ToString();
                drDtl1["NAME"] = dt1.Rows[intCount1]["USR_NAME"].ToString();
                drDtl1["DESGNAME"] = dt1.Rows[intCount1]["DSGN_NAME"].ToString();
                drDtl1["RO"] = sum.ToString();
                drDtl1["PARENTID"] = dt1.Rows[intCount1]["HRCHY_PARENT_DTL_ID"].ToString();
                if (hro == "0")
                {
                    sum = dt1.Rows.Count;
                }
                hro = dt1.Rows[intCount1]["HRCHY_PARENT_DTL_ID"].ToString();
                dtld = dt1.Rows[intCount1]["HRCHY_DTL_ID"].ToString();

                dtDetail1.Rows.Add(drDtl1);
            }

        }

        string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail1);
        HiddenSun.Value = strJson;

    }

    public string bindSubmenu(string DtlId)
    {
        HiddenFieldwrkId.Value = "0";
        StringBuilder objstr = new StringBuilder();

        clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
        clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();

        objentityPassport.TempId = Convert.ToInt32(DtlId);

        DataTable dt = objBussinesspasprt.ReadSubtableDtls(objentityPassport);

        if (dt.Rows.Count > 0)
        {
            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("DTLID", typeof(string));
            dtDetail.Columns.Add("TRAIL", typeof(string));
            dtDetail.Columns.Add("LEVEL", typeof(string));
            dtDetail.Columns.Add("DESGID", typeof(string));
            dtDetail.Columns.Add("EMPID", typeof(string));
            dtDetail.Columns.Add("APPRVMANSTS", typeof(string));
            dtDetail.Columns.Add("SUBEMPSTS", typeof(string));
            dtDetail.Columns.Add("THRESMODE", typeof(string));
            dtDetail.Columns.Add("PERIOD", typeof(string));
            dtDetail.Columns.Add("APPRVPENSTS", typeof(string));
            dtDetail.Columns.Add("TTCSTS", typeof(string));
            dtDetail.Columns.Add("SMSSTS", typeof(string));
            dtDetail.Columns.Add("SYSSTS", typeof(string));
            dtDetail.Columns.Add("SUBORDNUM", typeof(string));
            dtDetail.Columns.Add("NAME", typeof(string));
            dtDetail.Columns.Add("DESGNAME", typeof(string));
            dtDetail.Columns.Add("RO", typeof(string));

            objstr.Append("<ul>");
            int sum = 0;
            var row = "0";
            for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
            {
                int a = intCount + 1;

                sum = sum + 1;
                DataRow drDtl = dtDetail.NewRow();
                drDtl["DTLID"] = dt.Rows[intCount]["HRCHY_DTL_ID"].ToString();
                drDtl["TRAIL"] = a.ToString();
                drDtl["LEVEL"] = dt.Rows[intCount]["HRCHY_LEVEL"].ToString();
                drDtl["DESGID"] = dt.Rows[intCount]["DSGN_ID"].ToString();
                drDtl["EMPID"] = dt.Rows[intCount]["USR_ID"].ToString();
                drDtl["APPRVMANSTS"] = dt.Rows[intCount]["HRCHY_APRVL_MNDTRY_STS"].ToString();
                drDtl["SUBEMPSTS"] = dt.Rows[intCount]["HRCHY_SUBSTUTE_STS"].ToString();
                drDtl["THRESMODE"] = dt.Rows[intCount]["HRCHY_THRSHOLD_PRD_STS"].ToString();
                drDtl["PERIOD"] = dt.Rows[intCount]["HRCHY_THRSHOLD_PERIOD"].ToString();
                drDtl["APPRVPENSTS"] = dt.Rows[intCount]["HRCHY_APRVL_PENDING_MSG_STS"].ToString();
                drDtl["TTCSTS"] = dt.Rows[intCount]["HRCHY_TTC_EXCD_MSG_STS"].ToString();
                drDtl["SMSSTS"] = dt.Rows[intCount]["HRCHY_SMS_MSG_STS"].ToString();
                drDtl["SYSSTS"] = dt.Rows[intCount]["HRCHY_DASHBRD_MSG_STS"].ToString();
                drDtl["SUBORDNUM"] = dt.Rows[intCount]["SUBORD_NUM"].ToString();
                drDtl["NAME"] = dt.Rows[intCount]["USR_NAME"].ToString();
                drDtl["DESGNAME"] = dt.Rows[intCount]["DSGN_NAME"].ToString();
                drDtl["RO"] = sum.ToString();
                dtDetail.Rows.Add(drDtl);

                objstr.Append("<li>");

                objstr.Append("<span ><i class=\"fa fa-black-tie\"></i>" + dt.Rows[intCount]["USR_NAME"].ToString() + "</span>");

                objstr.Append("<button onclick=\"return FuctionOrganize('" + dt.Rows[intCount]["HRCHY_DTL_ID"].ToString() + "','" + dt.Rows[intCount]["HRCHY_LEVEL"].ToString() + "','" + dt.Rows[intCount]["USR_NAME"].ToString() + "','" + HiddenFieldwrkId.Value + "');\" class=\"edt_1 tablinks notv\"><i class=\"fa fa-edit\"></i></button>");
                objstr.Append(bindSubmenu(dt.Rows[intCount]["HRCHY_DTL_ID"].ToString()));
                objstr.Append("</li>");
            }


            objstr.Append("</ul>");
        }
        return objstr.ToString();
    }
    [WebMethod]
    public static string ReadSubtableDtls(string orgID, string corptID, string DtlId)
    {
        string arr = "";
        try
        {
            clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
            clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
            objentityPassport.Corporate_id = Convert.ToInt32(corptID);
            objentityPassport.Organisation_id = Convert.ToInt32(orgID);
            objentityPassport.TempId = Convert.ToInt32(DtlId);

            DataTable dt = objBussinesspasprt.ReadSubtableDtls(objentityPassport);
            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("DTLID", typeof(string));
            dtDetail.Columns.Add("TRAIL", typeof(string));
            dtDetail.Columns.Add("LEVEL", typeof(string));
            dtDetail.Columns.Add("DESGID", typeof(string));
            dtDetail.Columns.Add("EMPID", typeof(string));
            dtDetail.Columns.Add("APPRVMANSTS", typeof(string));
            dtDetail.Columns.Add("SUBEMPSTS", typeof(string));
            dtDetail.Columns.Add("THRESMODE", typeof(string));
            dtDetail.Columns.Add("PERIOD", typeof(string));
            dtDetail.Columns.Add("APPRVPENSTS", typeof(string));
            dtDetail.Columns.Add("TTCSTS", typeof(string));
            dtDetail.Columns.Add("SMSSTS", typeof(string));
            dtDetail.Columns.Add("SYSSTS", typeof(string));
            dtDetail.Columns.Add("SUBORDNUM", typeof(string));
            dtDetail.Columns.Add("NAME", typeof(string));
            dtDetail.Columns.Add("DESGNAME", typeof(string));
            dtDetail.Columns.Add("RO", typeof(string));
            int sum = 0;
            //var row = "0";
            for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
            {
                DataRow drDtl = dtDetail.NewRow();
                drDtl["DTLID"] = dt.Rows[intCount]["HRCHY_DTL_ID"].ToString();
                int a = intCount + 1;
                drDtl["TRAIL"] = a.ToString();
                drDtl["LEVEL"] = dt.Rows[intCount]["HRCHY_LEVEL"].ToString();
                drDtl["DESGID"] = dt.Rows[intCount]["DSGN_ID"].ToString();
                drDtl["EMPID"] = dt.Rows[intCount]["USR_ID"].ToString();
                drDtl["APPRVMANSTS"] = dt.Rows[intCount]["HRCHY_APRVL_MNDTRY_STS"].ToString();
                drDtl["SUBEMPSTS"] = dt.Rows[intCount]["HRCHY_SUBSTUTE_STS"].ToString();
                drDtl["THRESMODE"] = dt.Rows[intCount]["HRCHY_THRSHOLD_PRD_STS"].ToString();
                drDtl["PERIOD"] = dt.Rows[intCount]["HRCHY_THRSHOLD_PERIOD"].ToString();
                drDtl["APPRVPENSTS"] = dt.Rows[intCount]["HRCHY_APRVL_PENDING_MSG_STS"].ToString();
                drDtl["TTCSTS"] = dt.Rows[intCount]["HRCHY_TTC_EXCD_MSG_STS"].ToString();
                drDtl["SMSSTS"] = dt.Rows[intCount]["HRCHY_SMS_MSG_STS"].ToString();
                drDtl["SYSSTS"] = dt.Rows[intCount]["HRCHY_DASHBRD_MSG_STS"].ToString();
                drDtl["SUBORDNUM"] = dt.Rows[intCount]["SUBORD_NUM"].ToString();
                drDtl["NAME"] = dt.Rows[intCount]["USR_NAME"].ToString();
                drDtl["DESGNAME"] = dt.Rows[intCount]["DSGN_NAME"].ToString();
                drDtl["RO"] = sum.ToString();
                dtDetail.Rows.Add(drDtl);
            }
            if (dt.Rows.Count > 0)
            {
                arr = DataTableToJSONWithJavaScriptSerializer(dtDetail);

            }
        }
        catch (Exception ex)
        {
        }
        return arr;
    }

    [WebMethod]
    public static string ReadSubtableDtlsHr(string orgID, string corptID, string DtlId)
    {
        string arr = "";
        try
        {
            clsEntityApprovalHierarchyTemp objEntityAcco = new clsEntityApprovalHierarchyTemp();
            clsBusinessLayerPMS objBussinesspasprt = new clsBusinessLayerPMS();
            objEntityAcco.Corporate_id = Convert.ToInt32(corptID);
            objEntityAcco.Organisation_id = Convert.ToInt32(orgID);
            objEntityAcco.TempId = Convert.ToInt32(DtlId);

            DataTable dt = objBussinesspasprt.ReadSubtableDtls(objEntityAcco);
            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("DTLID", typeof(string));
            dtDetail.Columns.Add("LEVEL", typeof(string));
            dtDetail.Columns.Add("DESGID", typeof(string));
            dtDetail.Columns.Add("EMPID", typeof(string));
            dtDetail.Columns.Add("APPRVMANSTS", typeof(string));
            dtDetail.Columns.Add("SUBEMPSTS", typeof(string));
            dtDetail.Columns.Add("THRESMODE", typeof(string));
            dtDetail.Columns.Add("PERIOD", typeof(string));
            dtDetail.Columns.Add("APPRVPENSTS", typeof(string));
            dtDetail.Columns.Add("TTCSTS", typeof(string));
            dtDetail.Columns.Add("SMSSTS", typeof(string));
            dtDetail.Columns.Add("SYSSTS", typeof(string));
            dtDetail.Columns.Add("SUBORDNUM", typeof(string));
            dtDetail.Columns.Add("NAME", typeof(string));
            dtDetail.Columns.Add("DESGNAME", typeof(string));
            for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
            {
                DataRow drDtl = dtDetail.NewRow();
                drDtl["DTLID"] = dt.Rows[intCount]["HRCHY_DTL_ID"].ToString();
                drDtl["LEVEL"] = dt.Rows[intCount]["HRCHY_LEVEL"].ToString();
                drDtl["DESGID"] = dt.Rows[intCount]["DSGN_ID"].ToString();
                drDtl["EMPID"] = dt.Rows[intCount]["USR_ID"].ToString();
                drDtl["APPRVMANSTS"] = dt.Rows[intCount]["HRCHY_APRVL_MNDTRY_STS"].ToString();
                drDtl["SUBEMPSTS"] = dt.Rows[intCount]["HRCHY_SUBSTUTE_STS"].ToString();
                drDtl["THRESMODE"] = dt.Rows[intCount]["HRCHY_THRSHOLD_PRD_STS"].ToString();
                drDtl["PERIOD"] = dt.Rows[intCount]["HRCHY_THRSHOLD_PERIOD"].ToString();
                drDtl["APPRVPENSTS"] = dt.Rows[intCount]["HRCHY_APRVL_PENDING_MSG_STS"].ToString();
                drDtl["TTCSTS"] = dt.Rows[intCount]["HRCHY_TTC_EXCD_MSG_STS"].ToString();
                drDtl["SMSSTS"] = dt.Rows[intCount]["HRCHY_SMS_MSG_STS"].ToString();
                drDtl["SYSSTS"] = dt.Rows[intCount]["HRCHY_DASHBRD_MSG_STS"].ToString();
                drDtl["SUBORDNUM"] = dt.Rows[intCount]["SUBORD_NUM"].ToString();
                drDtl["NAME"] = dt.Rows[intCount]["USR_NAME"].ToString();
                drDtl["DESGNAME"] = dt.Rows[intCount]["DSGN_NAME"].ToString();
                dtDetail.Rows.Add(drDtl);
            }
            if (dt.Rows.Count > 0)
            {
                arr = DataTableToJSONWithJavaScriptSerializer(dtDetail);

            }
        }
        catch (Exception ex)
        {
        }
        return arr;
    }

    public static string DataTableToJSONWithJavaScriptSerializer(DataTable table)
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
    protected void btnUpdateS_Click(object sender, EventArgs e)
    {

    }

    public void Msgbox(String s)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('" + s + "');", true);
    }

    public void Read_Document()
    {
        clsBusinessLayerPMS objEntitybuspms = new clsBusinessLayerPMS();

        DataTable doc = objEntitybuspms.Read_Document();
        docsection.Items.Clear();
        docsection.DataSource = doc;
        docsection.DataValueField = "DOC_ID";
        docsection.DataTextField = "DOC_NAME";
        docsection.DataBind();
    }

    public void Read_Departments()
    {
        clsBusinessLayerPMS objEntitybuspms = new clsBusinessLayerPMS();
        clsEntityApprovalHierarchyTemp objEntity = new clsEntityApprovalHierarchyTemp();
        if (Session["ORGID"] != null)
        {
            objEntity.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntity.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);

        }

        DataTable doc = objEntitybuspms.Read_Departments(objEntity);
        // string a = doc.Rows[0][0].ToString();
        // Msgbox(doc.Rows.Count.ToString());
        lstDpt.Items.Clear();
        lstDpt.DataSource = doc;
        lstDpt.DataValueField = "CPRDEPT_ID";
        lstDpt.DataTextField = "CPRDEPT_NAME";
        lstDpt.DataBind();
    }
    public void Read_Divisions()
    {
        clsBusinessLayerPMS objEntitybuspms = new clsBusinessLayerPMS();
        clsEntityApprovalHierarchyTemp objEntity = new clsEntityApprovalHierarchyTemp();
        if (Session["ORGID"] != null)
        {
            objEntity.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntity.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        DataTable doc = objEntitybuspms.Read_Divisions(objEntity);
        lstDiv.Items.Clear();
        lstDiv.DataSource = doc;
        lstDiv.DataValueField = "CPRDIV_ID";
        lstDiv.DataTextField = "CPRDIV_NAME";
        lstDiv.DataBind();
    }

    public void Read_hrchyname()
    {
        clsBusinessLayerPMS objEntitybuspms = new clsBusinessLayerPMS();

        DataTable doc = objEntitybuspms.Read_hrchyname();
        dlHrchy.Items.Clear();
        dlHrchy.DataSource = doc;
        dlHrchy.DataValueField = "HRCHY_ID";
        dlHrchy.DataTextField = "HRCHY_NAME";
        dlHrchy.DataBind();
        dlHrchy.Items.Insert(0, "--Select--");
    }

    protected void dlHrchy_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.dlhr.Focus();
        cbxhrsts.Checked = false;
        cbsdate.Checked = false;
        cbEdate.Checked = false;

        dte_1.Value = "";
        dte_1_a.Value = "";

        clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
        clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();

        HiddenHrchyId.Value = dlHrchy.SelectedValue;
        HiddenHrchyname.Value = dlHrchy.SelectedItem.ToString();

        if (dlHrchy.SelectedValue != "" && dlHrchy.SelectedValue != "--Select--" && dlHrchy.SelectedValue != "0")
        {
            objentityPassport.TempId = Convert.ToInt32(dlHrchy.SelectedValue);
            DataTable dt = objBussinesspasprt.ReadTemplatedtls(objentityPassport);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["HRCHY_STATUS"].ToString() == "0")
                {
                    cbxhrsts.Checked = false;
                    dte_1_a.Disabled = true;
                }
                else
                {
                    cbxhrsts.Checked = true;
                    dte_1_a.Disabled = false;
                }

                if (dt.Rows[0]["HRCHY_STRTDATE"].ToString() != "")
                {
                    cbsdate.Checked = true;
                    dte_1_a.Value = dt.Rows[0]["HRCHY_STRTDATE"].ToString();
                }
                if (dt.Rows[0]["HRCHY_ENDDATE"].ToString() != "")
                {
                    cbEdate.Checked = true;
                    dte_1.Value = dt.Rows[0]["HRCHY_ENDDATE"].ToString();
                }
            }

            string strId = HiddenHrchyId.Value;
            string DtlId = HiddenHrchyId.Value;

            Update(strId, 1);
            Updatesub(strId, 1);

            HiddenFieldView.Value = "1";
            hiddenHrchyChngdMode.Value = "1";
        }
    }

    //protected void btnSave_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        Button clickedButton = sender as Button;

    //        clsCommonLibrary objCommon = new clsCommonLibrary();
    //        clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
    //        clsEntityApprovalHierarchyTemp objentityPass = new clsEntityApprovalHierarchyTemp();
    //        clsEntityApprovalHierarchyTemp objentityPass1 = new clsEntityApprovalHierarchyTemp();
    //        clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
    //        if (Session["CORPOFFICEID"] != null)
    //        {
    //            objentityPassport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
    //            objentityPass.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
    //        }
    //        else if (Session["CORPOFFICEID"] == null)
    //        {
    //            Response.Redirect("/Default.aspx");
    //        }
    //        if (Session["ORGID"] != null)
    //        {
    //            objentityPassport.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
    //            objentityPass.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
    //        }
    //        else if (Session["ORGID"] == null)
    //        {
    //            Response.Redirect("/Default.aspx");
    //        }
    //        if (Session["USERID"] != null)
    //        {
    //            objentityPassport.User_Id = Convert.ToInt32(Session["USERID"]);
    //            objentityPass.User_Id = Convert.ToInt32(Session["USERID"]);
    //        }
    //        else if (Session["USERID"] == null)
    //        {
    //            Response.Redirect("/Default.aspx");
    //        }
    //        objentityPassport.Name = txtName.Text;

    //        //Msgbox(dte_1_a.Value.Trim());
    //        if (dte_1_a.Value.Trim() != "")
    //        {
    //            objentityPassport.StartDate = objCommon.textToDateTime(dte_1_a.Value.Trim());
    //            objentityPass.StartDate = objCommon.textToDateTime(dte_1_a.Value.Trim());
    //        }
    //        if (dte_1.Value.Trim() != "")
    //        {
    //            objentityPassport.EndDate = objCommon.textToDateTime(dte_1.Value.Trim());
    //            objentityPass.EndDate = objCommon.textToDateTime(dte_1.Value.Trim());
    //        }
    //        objentityPass.Name = txtName.Text.Trim();
    //        objentityPass.Doc = docsection.SelectedItem.ToString();
    //        if (cbxsts.Checked == true)
    //        {
    //            objentityPass.Status_id = 1;
    //        }
    //        else
    //        {
    //            objentityPass.Status_id = 0;

    //        }
    //        objentityPass.descr = txtDescr.Text.Trim();
    //        if (cbxapr.Checked == true)
    //        {
    //            objentityPass.apptrans = 1;
    //        }
    //        else
    //        {
    //            objentityPass.apptrans = 0;
    //        }
    //        if (cbxmdfy.Checked == true)
    //        {
    //            objentityPass.appmdf = 1;
    //        }
    //        else
    //        {
    //            objentityPass.appmdf = 0;
    //        }
    //        string dept = "";

    //        for (int j = 0; j < lstDpt.Items.Count; j++)
    //        {
    //            if (lstDpt.Items[j].Selected == true)
    //            {
    //                if (dept == "")
    //                {

    //                    dept = lstDpt.Items[j].Value;
    //                }
    //                else
    //                {
    //                    dept = dept + "," + lstDpt.Items[j].Value;
    //                }
    //            }
    //        }
    //        //Msgbox(dept.ToString());
    //        objentityPass.Dep = dept.ToString();
    //        string divd = "";
    //        for (int k = 0; k < lstDiv.Items.Count; k++)
    //        {
    //            if (lstDiv.Items[k].Selected == true)
    //            {
    //                if (divd == "")
    //                {
    //                    divd = lstDiv.Items[k].Value;
    //                }
    //                else
    //                {
    //                    divd = divd + "," + lstDiv.Items[k].Value;
    //                }
    //            }
    //        }
    //        objentityPass.div = divd.ToString();
    //        objentityPass.hrid = Convert.ToInt32(HiddenHrchyId.Value);
    //        if (cbxaprpnd.Checked == true)
    //        {
    //            objentityPass.appnd = 1;
    //        }
    //        else
    //        {
    //            objentityPass.appnd = 0;
    //        }
    //        if (cbxsm.Checked == true)
    //        {
    //            objentityPass.sms = 1;
    //        }
    //        else
    //        {
    //            objentityPass.sms = 0;
    //        }
    //        if (cbxnt.Checked == true)
    //        {
    //            objentityPass.dash = 1;
    //        }
    //        else
    //        {
    //            objentityPass.dash = 0;
    //        }
    //        if (cbxTmExd.Checked == true)
    //        {
    //            objentityPass.ttc = 1;
    //        }
    //        else
    //        {
    //            objentityPass.ttc = 0;
    //        }
    //        if (rbHigh.Checked == true)
    //        {
    //            objentityPass.prity = 1;
    //        }
    //        else
    //        {
    //            objentityPass.prity = 0;
    //        }
    //        DateTime dd = DateTime.Parse(DateTime.Now.ToShortDateString());
    //        string dat = dd.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
    //        if (dat.Trim() != "")
    //        {
    //            objentityPass.cDate = objCommon.textToDateTime(dat.Trim());
    //        }

    //        objentityPass1.Name = txtName.Text.Trim();


    //        objentityPassport.TempId = Convert.ToInt32(HiddenHrchyId.Value);
    //        objentityPassport.Name = HiddenHrchyname.Value.Trim();
    //        if (cbxsts.Checked == true)
    //        {
    //            objentityPassport.Status_id = 1;
    //        }
    //        else
    //        {
    //            objentityPassport.Status_id = 0;

    //        }

    //        clsBusinessLayerPMS objEntitybuspms = new clsBusinessLayerPMS();
    //        DataTable dt1 = objEntitybuspms.Readwrkflwdi(objentityPassport);
    //        string sds = "1";

    //        if (dt1.Rows[0][0].ToString() != "")
    //        {

    //            int a = Convert.ToInt32(dt1.Rows[0][0].ToString());
    //            int b = a + 1;
    //            sds = b.ToString();
    //        }

    //        else
    //        {
    //            sds = "1";
    //        }

    //        DataTable dt3 = objEntitybuspms.ReadDocwrkflwparent();
    //        string a1 = dt3.Rows[0][0].ToString();

    //        List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltn = new List<clsEntityApprovalHierarchyTemp>();
    //        List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListDele = new List<clsEntityApprovalHierarchyTemp>();
    //        string jsonData1 = HiddenFieldSubData.Value;

    //        string c1 = jsonData1.Replace("\"{", "\\{");
    //        string d1 = c1.Replace("\\n", "\r\n");
    //        string g1 = d1.Replace("\\", "");
    //        string h1 = g1.Replace("}\"]", "}]");
    //        string i1 = h1.Replace("}\",", "},");

    //        List<clsTVData> objTVDataList51 = new List<clsTVData>();

    //        // Msgbox(HiddenFieldSubData.Value);
    //        objTVDataList51 = JsonConvert.DeserializeObject<List<clsTVData>>(i1);
    //        //  Msgbox(HiddenFieldSubData.Value);

    //        if (HiddenFieldSubData.Value != "" && HiddenFieldSubData.Value != null)
    //        {

    //            foreach (clsTVData objclsTVData in objTVDataList51)
    //            {

    //                clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
    //                if (objclsTVData.EMPID != "-Select-" && objclsTVData.DESGID != "-Select-" && objclsTVData.PERIOD != "")
    //                {

    //                    objEntityDetails.TempId = Convert.ToInt32(sds);
    //                    objEntityDetails.Level = Convert.ToInt32(objclsTVData.LEVEL);
    //                    DataTable dt2 = objEntitybuspms.Readwrkflwparentid(objentityPass1);
    //                    string sds1 = "0";
    //                    if (dt2.Rows.Count != 0 && dt2.Rows[0][0].ToString() != "")
    //                    {

    //                        sds1 = dt2.Rows[0][0].ToString();
    //                    }
    //                    else
    //                    {
    //                        sds1 = "0";
    //                    }
    //                    HiddenWrkParentId.Value = sds1;
    //                    if (objEntityDetails.Level == 0)
    //                    {
    //                        objEntityDetails.ParentId = 0;
    //                    }
    //                    else
    //                    {

    //                        int pt = Convert.ToInt32(HiddenWrkParentId.Value) + Convert.ToInt32(objclsTVData.RO);

    //                        objEntityDetails.ParentId = pt;

    //                    }
    //                    objEntityDetails.User_Id = 0;
    //                    objEntityDetails.DesgId = Convert.ToInt32(objclsTVData.DESGID);
    //                    objEntityDetails.EmployeeId = Convert.ToInt32(objclsTVData.EMPID);
    //                    objEntityDetails.MajorityAprvSts = Convert.ToInt32(objclsTVData.APPRVMANSTS);
    //                    objEntityDetails.SubstituteEmpSts = Convert.ToInt32(objclsTVData.SUBEMPSTS);
    //                    objEntityDetails.ThresholdPeriodMode = Convert.ToInt32(objclsTVData.THRESMODE);
    //                    objEntityDetails.ThresholdPeriodDays = Convert.ToInt32(objclsTVData.PERIOD);
    //                    objEntityDetails.AprvPendingSts = Convert.ToInt32(objclsTVData.APPRVPENSTS);
    //                    objEntityDetails.TtExceededSts = Convert.ToInt32(objclsTVData.TTCSTS);
    //                    objEntityDetails.SmsSts = Convert.ToInt32(objclsTVData.SMSSTS);
    //                    objEntityDetails.SystemSts = Convert.ToInt32(objclsTVData.SYSSTS);

    //                    objEntityTrficVioltn.Add(objEntityDetails);

    //                }
    //            }
    //            objEntityTrficVioltn.Reverse();
    //        }
    //        objBussinesspasprt.insertDocwrkData(objentityPass, objEntityTrficVioltn);

    //        HiddenSubTable.Value = "";
    //        HiddenFieldSubData.Value = "";
    //        HiddenFieldMainData.Value = "";

    //        if (clickedButton.ID == "btnSave" || clickedButton.ID == "btnSaveFloat")
    //        {
    //            Response.Redirect("gen_Document_Workflow.aspx?InsUpd=Ins");
    //        }
    //        else if (clickedButton.ID == "btnsaveclose" || clickedButton.ID == "btnsavecloseFloat")
    //        {
    //            Response.Redirect("gen_Document_Workflow_List.aspx?InsUpd=Ins");
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;

            clsCommonLibrary objCommon = new clsCommonLibrary();

            clsBusinessLayerPMS objBusinessWrkFlow = new clsBusinessLayerPMS();
            clsEntityApprovalHierarchyTemp objEntityWrkFlow = new clsEntityApprovalHierarchyTemp();

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityWrkFlow.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityWrkFlow.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objEntityWrkFlow.User_Id = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityWrkFlow.Name = txtName.Text.Trim();
            objEntityWrkFlow.Doc = docsection.SelectedItem.Value;
            if (cbxsts.Checked == true)
            {
                objEntityWrkFlow.Status_id = 1;
            }
            else
            {
                objEntityWrkFlow.Status_id = 0;
            }
            objEntityWrkFlow.descr = txtDescr.Text.Trim();
            if (cbxapr.Checked == true)
            {
                objEntityWrkFlow.apptrans = 1;
            }
            else
            {
                objEntityWrkFlow.apptrans = 0;
            }
            if (cbxmdfy.Checked == true)
            {
                objEntityWrkFlow.appmdf = 1;
            }
            else
            {
                objEntityWrkFlow.appmdf = 0;
            }

            string dept = "";
            for (int j = 0; j < lstDpt.Items.Count; j++)
            {
                if (lstDpt.Items[j].Selected == true)
                {
                    if (dept == "")
                    {
                        dept = lstDpt.Items[j].Value;
                    }
                    else
                    {
                        dept = dept + "," + lstDpt.Items[j].Value;
                    }
                }
            }
            objEntityWrkFlow.Dep = dept.ToString();

            string divd = "";
            for (int k = 0; k < lstDiv.Items.Count; k++)
            {
                if (lstDiv.Items[k].Selected == true)
                {
                    if (divd == "")
                    {
                        divd = lstDiv.Items[k].Value;
                    }
                    else
                    {
                        divd = divd + "," + lstDiv.Items[k].Value;
                    }
                }
            }
            objEntityWrkFlow.div = divd.ToString();

            objEntityWrkFlow.hrid = Convert.ToInt32(HiddenHrchyId.Value);

            if (dte_1_a.Value.Trim() != "")
            {
                objEntityWrkFlow.StartDate = objCommon.textToDateTime(dte_1_a.Value.Trim());
            }
            if (dte_1.Value.Trim() != "")
            {
                objEntityWrkFlow.EndDate = objCommon.textToDateTime(dte_1.Value.Trim());
            }

            if (cbxaprpnd.Checked == true)
            {
                objEntityWrkFlow.appnd = 1;
            }
            else
            {
                objEntityWrkFlow.appnd = 0;
            }
            if (cbxsm.Checked == true)
            {
                objEntityWrkFlow.sms = 1;
            }
            else
            {
                objEntityWrkFlow.sms = 0;
            }
            if (cbxnt.Checked == true)
            {
                objEntityWrkFlow.dash = 1;
            }
            else
            {
                objEntityWrkFlow.dash = 0;
            }
            if (cbxTmExd.Checked == true)
            {
                objEntityWrkFlow.ttc = 1;
            }
            else
            {
                objEntityWrkFlow.ttc = 0;
            }
            if (rbHigh.Checked == true)
            {
                objEntityWrkFlow.prity = 1;
            }
            else
            {
                objEntityWrkFlow.prity = 0;
            }

            List<clsEntityApprovalHierarchyTemp> objEntityWrkFlowMainList = new List<clsEntityApprovalHierarchyTemp>();

            string jsonData = HiddenFieldMainData.Value;
            string c = jsonData.Replace("\"{", "\\{");
            string d = c.Replace("\\n", "\r\n");
            string g = d.Replace("\\", "");
            string h = g.Replace("}\"]", "}]");
            string i = h.Replace("}\",", "},");

            List<clsTVData> objDataMainList = new List<clsTVData>();
            objDataMainList = JsonConvert.DeserializeObject<List<clsTVData>>(i);

            if (HiddenFieldMainData.Value != "" && HiddenFieldMainData.Value != null)
            {
                foreach (clsTVData objData in objDataMainList)
                {
                    clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
                    if (objData.EMPID != "-Select-" && objData.DESGID != "-Select-" && objData.PERIOD != "")
                    {
                        if (objData.DTLID != "" && objData.DTLID != null && objData.DTLID != "null")
                        {
                            objEntityDetails.TempDtlId = Convert.ToInt32(objData.DTLID);//HrchyId
                        }
                        if (objData.PARENT != "")
                        {
                            objEntityDetails.ParentId = Convert.ToInt32(objData.PARENT);//HrchyId
                        }
                        objEntityDetails.Level = Convert.ToInt32(objData.LEVEL);
                        objEntityDetails.DesgId = Convert.ToInt32(objData.DESGID);
                        objEntityDetails.EmployeeId = Convert.ToInt32(objData.EMPID);
                        objEntityDetails.ThresholdPeriodMode = Convert.ToInt32(objData.THRESMODE);
                        objEntityDetails.ThresholdPeriodDays = Convert.ToInt32(objData.PERIOD);
                        objEntityDetails.MajorityAprvSts = Convert.ToInt32(objData.APPRVMANSTS);
                        objEntityDetails.SubstituteEmpSts = Convert.ToInt32(objData.SUBEMPSTS);
                        objEntityDetails.AprvPendingSts = Convert.ToInt32(objData.APPRVPENSTS);
                        objEntityDetails.TtExceededSts = Convert.ToInt32(objData.TTCSTS);
                        objEntityDetails.SmsSts = Convert.ToInt32(objData.SMSSTS);
                        objEntityDetails.SystemSts = Convert.ToInt32(objData.SYSSTS);

                        objEntityWrkFlowMainList.Add(objEntityDetails);
                    }
                }
            }

            List<clsEntityApprovalHierarchyTemp> objEntityWrkFlowSubList = new List<clsEntityApprovalHierarchyTemp>();

            string jsonData1 = HiddenFieldSubData.Value;
            string c1 = jsonData1.Replace("\"{", "\\{");
            string d1 = c1.Replace("\\n", "\r\n");
            string g1 = d1.Replace("\\", "");
            string h1 = g1.Replace("}\"]", "}]");
            string i1 = h1.Replace("}\",", "},");

            List<clsTVData> objDataSubList = new List<clsTVData>();
            objDataSubList = JsonConvert.DeserializeObject<List<clsTVData>>(i1);

            if (HiddenFieldSubData.Value != "" && HiddenFieldSubData.Value != null)
            {
                foreach (clsTVData objData in objDataSubList)
                {
                    clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
                    if (objData.EMPID != "-Select-" && objData.DESGID != "-Select-" && objData.PERIOD != "")
                    {
                        if (objData.DTLID != "" && objData.DTLID != null && objData.DTLID != "null")
                        {
                            objEntityDetails.TempDtlId = Convert.ToInt32(objData.DTLID);//HrchyId
                        }
                        if (objData.PARENT != "")
                        {
                            objEntityDetails.ParentId = Convert.ToInt32(objData.PARENT);//HrchyId
                        }
                        objEntityDetails.Level = Convert.ToInt32(objData.LEVEL);
                        objEntityDetails.DesgId = Convert.ToInt32(objData.DESGID);
                        objEntityDetails.EmployeeId = Convert.ToInt32(objData.EMPID);
                        objEntityDetails.ThresholdPeriodMode = Convert.ToInt32(objData.THRESMODE);
                        objEntityDetails.ThresholdPeriodDays = Convert.ToInt32(objData.PERIOD);
                        objEntityDetails.MajorityAprvSts = Convert.ToInt32(objData.APPRVMANSTS);
                        objEntityDetails.SubstituteEmpSts = Convert.ToInt32(objData.SUBEMPSTS);
                        objEntityDetails.AprvPendingSts = Convert.ToInt32(objData.APPRVPENSTS);
                        objEntityDetails.TtExceededSts = Convert.ToInt32(objData.TTCSTS);
                        objEntityDetails.SmsSts = Convert.ToInt32(objData.SMSSTS);
                        objEntityDetails.SystemSts = Convert.ToInt32(objData.SYSSTS);

                        objEntityWrkFlowSubList.Add(objEntityDetails);
                    }
                }
            }

            //objBusinessWrkFlow.InsertDocumentWorkflow(objEntityWrkFlow, objEntityWrkFlowMainList, objEntityWrkFlowSubList);

            if (clickedButton.ID == "btnSave" || clickedButton.ID == "btnSaveFloat")
            {
                Response.Redirect("gen_Document_Workflow.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnsaveclose" || clickedButton.ID == "btnsavecloseFloat")
            {
                Response.Redirect("gen_Document_Workflow_List.aspx?InsUpd=Ins");
            }

        }
        catch (Exception ex)
        {
        }
    }

    //protected void btnCnfrm_Click(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        Button clickedButton = sender as Button;
    //        clsCommonLibrary objCommon = new clsCommonLibrary();
    //        clsBusinessLayerPMS objEntitybuspms = new clsBusinessLayerPMS();

    //        clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
    //        clsEntityApprovalHierarchyTemp objentityPass = new clsEntityApprovalHierarchyTemp();
    //        clsEntityApprovalHierarchyTemp objentityPasspo = new clsEntityApprovalHierarchyTemp();
    //        clsEntityApprovalHierarchyTemp objentityPass1 = new clsEntityApprovalHierarchyTemp();
    //        clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
    //        if (Session["CORPOFFICEID"] != null)
    //        {
    //            objentityPassport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
    //            objentityPass.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
    //        }
    //        else if (Session["CORPOFFICEID"] == null)
    //        {
    //            Response.Redirect("/Default.aspx");
    //        }
    //        if (Session["ORGID"] != null)
    //        {
    //            objentityPassport.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
    //            objentityPass.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
    //        }
    //        else if (Session["ORGID"] == null)
    //        {
    //            Response.Redirect("/Default.aspx");
    //        }
    //        if (Session["USERID"] != null)
    //        {
    //            objentityPassport.User_Id = Convert.ToInt32(Session["USERID"]);
    //            objentityPass.User_Id = Convert.ToInt32(Session["USERID"]);
    //        }
    //        else if (Session["USERID"] == null)
    //        {
    //            Response.Redirect("/Default.aspx");
    //        }
    //        objentityPassport.Name = txtName.Text;

    //        if (dte_1_a.Value.Trim() != "")
    //        {
    //            objentityPassport.StartDate = objCommon.textToDateTime(dte_1_a.Value.Trim());
    //            objentityPass.StartDate = objCommon.textToDateTime(dte_1_a.Value.Trim());
    //            objentityPasspo.StartDate = objCommon.textToDateTime(dte_1_a.Value.Trim());
    //        }
    //        if (dte_1.Value.Trim() != "")
    //        {
    //            objentityPassport.EndDate = objCommon.textToDateTime(dte_1.Value.Trim());
    //            objentityPass.EndDate = objCommon.textToDateTime(dte_1.Value.Trim());
    //            objentityPasspo.EndDate = objCommon.textToDateTime(dte_1.Value.Trim());
    //        }
    //        objentityPass.Name = txtName.Text.Trim();
    //        objentityPassport.Doc = docsection.SelectedItem.ToString();
    //        if (cbxsts.Checked == true)
    //        {
    //            objentityPassport.Status_id = 1;
    //        }
    //        else
    //        {
    //            objentityPassport.Status_id = 0;

    //        }
    //        objentityPassport.descr = txtDescr.Text;
    //        if (cbxapr.Checked == true)
    //        {
    //            objentityPassport.apptrans = 1;
    //        }
    //        else
    //        {
    //            objentityPassport.apptrans = 0;
    //        }
    //        if (cbxmdfy.Checked == true)
    //        {
    //            objentityPassport.appmdf = 1;
    //        }
    //        else
    //        {
    //            objentityPassport.appmdf = 0;
    //        }
    //        string dept = "";
    //        for (int j = 0; j < lstDpt.Items.Count; j++)
    //        {
    //            if (lstDpt.Items[j].Selected == true)
    //            {
    //                if (dept == "")
    //                {
    //                    dept = lstDpt.Items[j].Value;
    //                }
    //                else
    //                {
    //                    dept = dept + "," + lstDpt.Items[j].Value;
    //                }
    //            }
    //        }

    //        objentityPassport.Dep = dept.ToString();
    //        string divd = "";
    //        for (int k = 0; k < lstDiv.Items.Count; k++)
    //        {
    //            if (lstDiv.Items[k].Selected == true)
    //            {
    //                if (divd == "")
    //                {
    //                    divd = lstDiv.Items[k].Value;
    //                }
    //                else
    //                {
    //                    divd = divd + "," + lstDiv.Items[k].Value;
    //                }
    //            }
    //        }
    //        objentityPassport.div = divd.ToString();
    //        objentityPassport.hrid = Convert.ToInt32(dlHrchy.SelectedValue);
    //        if (cbxaprpnd.Checked == true)
    //        {
    //            objentityPassport.appnd = 1;
    //        }
    //        else
    //        {
    //            objentityPassport.appnd = 0;
    //        }
    //        if (cbxsm.Checked == true)
    //        {
    //            objentityPassport.sms = 1;
    //        }
    //        else
    //        {
    //            objentityPassport.sms = 0;
    //        }
    //        if (cbxnt.Checked == true)
    //        {
    //            objentityPassport.dash = 1;
    //        }
    //        else
    //        {
    //            objentityPassport.dash = 0;
    //        }
    //        if (cbxTmExd.Checked == true)
    //        {
    //            objentityPassport.ttc = 1;
    //        }
    //        else
    //        {
    //            objentityPassport.ttc = 0;
    //        }
    //        if (rbHigh.Checked == true)
    //        {
    //            objentityPassport.prity = 1;
    //        }
    //        else
    //        {
    //            objentityPassport.prity = 0;
    //        }
    //        DateTime dd = DateTime.Parse(DateTime.Now.ToShortDateString());
    //        string dat = dd.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
    //        if (dat.Trim() != "")
    //        {
    //            objentityPassport.cDate = objCommon.textToDateTime(dat.Trim());
    //        }

    //        objentityPassport.Name = txtName.Text.Trim();
    //        objentityPassport.Name1 = HiddenWrkname.Value;
    //        objentityPass1.Name = txtName.Text.Trim();
    //        DataTable dts = objEntitybuspms.Readwrkflwdid1(objentityPass1);
    //        if (dts.Rows.Count > 0)
    //        {
    //            string tempid = dts.Rows[0]["WRKFLW_ID"].ToString();
    //        }

    //        string strId = "";
    //        if (Request.QueryString["Id"] != null)
    //        {
    //            string strRandomMixedId = Request.QueryString["Id"].ToString();
    //            string strLenghtofId = strRandomMixedId.Substring(0, 2);
    //            int intLenghtofId = Convert.ToInt16(strLenghtofId);
    //            strId = strRandomMixedId.Substring(2, intLenghtofId);
    //        }

    //        objentityPassport.TempId = Convert.ToInt32(strId);

    //        int CnclSts = 0;
    //        DataTable dt = objBussinesspasprt.ReadDocumentdtls(objentityPassport);
    //        if (dt.Rows.Count > 0 && dt.Rows[0]["WRKFLW_CNCL_USR_ID"].ToString() != "")
    //        {
    //            CnclSts++;
    //        }

    //        if (cbxsts.Checked == true)
    //        {
    //            objentityPassport.Status_id = 1;
    //        }
    //        else
    //        {
    //            objentityPassport.Status_id = 0;

    //        }
    //        objentityPasspo.TempId = Convert.ToInt32(HiddenFieldwrkId.Value);
    //        //  Msgbox(HiddenFieldwrkId.Value);
    //        List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListIns = new List<clsEntityApprovalHierarchyTemp>();
    //        List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListDele = new List<clsEntityApprovalHierarchyTemp>();
    //        string jsonData = HiddenFieldMainData.Value;
    //        string c = jsonData.Replace("\"{", "\\{");
    //        string d = c.Replace("\\n", "\r\n");
    //        string g = d.Replace("\\", "");
    //        string h = g.Replace("}\"]", "}]");
    //        string i = h.Replace("}\",", "},");
    //        List<clsTVData> objTVDataList5 = new List<clsTVData>();
    //        objTVDataList5 = JsonConvert.DeserializeObject<List<clsTVData>>(i);
    //        //  Msgbox(HiddenFieldMainData.Value);
    //        if (HiddenFieldMainData.Value != "" && HiddenFieldMainData.Value != null)
    //        {
    //            foreach (clsTVData objclsTVData in objTVDataList5)
    //            {
    //                clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
    //                if (objclsTVData.EMPID != "-Select-" && objclsTVData.DESGID != "-Select-" && objclsTVData.PERIOD != "")
    //                {
    //                    objEntityDetails.DesgId = Convert.ToInt32(objclsTVData.DESGID);
    //                    objEntityDetails.EmployeeId = Convert.ToInt32(objclsTVData.EMPID);
    //                    objEntityDetails.MajorityAprvSts = Convert.ToInt32(objclsTVData.APPRVMANSTS);
    //                    objEntityDetails.SubstituteEmpSts = Convert.ToInt32(objclsTVData.SUBEMPSTS);
    //                    objEntityDetails.ThresholdPeriodMode = Convert.ToInt32(objclsTVData.THRESMODE);
    //                    objEntityDetails.ThresholdPeriodDays = Convert.ToInt32(objclsTVData.PERIOD);
    //                    objEntityDetails.AprvPendingSts = Convert.ToInt32(objclsTVData.APPRVPENSTS);
    //                    objEntityDetails.TtExceededSts = Convert.ToInt32(objclsTVData.TTCSTS);
    //                    objEntityDetails.SmsSts = Convert.ToInt32(objclsTVData.SMSSTS);
    //                    objEntityDetails.SystemSts = Convert.ToInt32(objclsTVData.SYSSTS);
    //                    if (objclsTVData.DTLID != "" && objclsTVData.DTLID != "null" && objclsTVData.DTLID != null)
    //                    {
    //                        objEntityDetails.TempId = Convert.ToInt32(objclsTVData.DTLID);
    //                    }

    //                    objEntityTrficVioltnDetilsListIns.Add(objEntityDetails);
    //                }
    //            }

    //            objEntityTrficVioltnDetilsListIns.Reverse();



    //            string strCanclDtlId = "";
    //            string[] strarrCancldtlIdsGrp = strCanclDtlId.Split(',');

    //            if (hiddenMainCanclDbId.Value != "" && hiddenMainCanclDbId.Value != null)
    //            {

    //                strCanclDtlId = hiddenMainCanclDbId.Value;
    //                strarrCancldtlIdsGrp = strCanclDtlId.Split(',');
    //            }
    //            foreach (string strDtlId in strarrCancldtlIdsGrp)
    //            {

    //                if (strDtlId != "" && strDtlId != null)
    //                {

    //                    int intDtlId = Convert.ToInt32(strDtlId);
    //                    clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
    //                    objEntityDetails.TempId = Convert.ToInt32(strDtlId);
    //                    objEntityTrficVioltnDetilsListDele.Add(objEntityDetails);
    //                }
    //            }


    //            List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsList = new List<clsEntityApprovalHierarchyTemp>();
    //            List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDele = new List<clsEntityApprovalHierarchyTemp>();
    //            string jsonData1 = HiddenFieldSubData.Value;
    //            string c1 = jsonData1.Replace("\"{", "\\{");
    //            string d1 = c1.Replace("\\n", "\r\n");
    //            string g1 = d1.Replace("\\", "");
    //            string h1 = g1.Replace("}\"]", "}]");
    //            string i1 = h1.Replace("}\",", "},");
    //            List<clsTVData> objTVDataList51 = new List<clsTVData>();
    //            objTVDataList51 = JsonConvert.DeserializeObject<List<clsTVData>>(i1);

    //            //Msgbox(HiddenFieldSubData.Value);
    //            if (HiddenFieldSubData.Value != "" && HiddenFieldSubData.Value != null)
    //            {
    //                foreach (clsTVData objclsTVData in objTVDataList51)
    //                {
    //                    clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
    //                    if (objclsTVData.EMPID != "-Select-" && objclsTVData.DESGID != "-Select-" && objclsTVData.PERIOD != "")
    //                    {
    //                        objEntityDetails.Status_id = Convert.ToInt32(HiddenFieldwrkId.Value);

    //                        objEntityDetails.ParentId = Convert.ToInt32(HiddenFieldCurrentDtlId.Value);

    //                        objEntityDetails.Level = Convert.ToInt32(objclsTVData.LEVEL);
    //                        objEntityDetails.User_Id = 0;


    //                        objEntityDetails.DesgId = Convert.ToInt32(objclsTVData.DESGID);
    //                        objEntityDetails.EmployeeId = Convert.ToInt32(objclsTVData.EMPID);
    //                        objEntityDetails.MajorityAprvSts = Convert.ToInt32(objclsTVData.APPRVMANSTS);
    //                        objEntityDetails.SubstituteEmpSts = Convert.ToInt32(objclsTVData.SUBEMPSTS);
    //                        objEntityDetails.ThresholdPeriodMode = Convert.ToInt32(objclsTVData.THRESMODE);
    //                        objEntityDetails.ThresholdPeriodDays = Convert.ToInt32(objclsTVData.PERIOD);
    //                        objEntityDetails.AprvPendingSts = Convert.ToInt32(objclsTVData.APPRVPENSTS);
    //                        objEntityDetails.TtExceededSts = Convert.ToInt32(objclsTVData.TTCSTS);
    //                        objEntityDetails.SmsSts = Convert.ToInt32(objclsTVData.SMSSTS);
    //                        objEntityDetails.SystemSts = Convert.ToInt32(objclsTVData.SYSSTS);
    //                        if (objclsTVData.DTLID != "" && objclsTVData.DTLID != "null" && objclsTVData.DTLID != null)
    //                        {
    //                            objEntityDetails.TempId = Convert.ToInt32(objclsTVData.DTLID);
    //                        }
    //                        else
    //                        {
    //                            objEntityDetails.TempId = 0;
    //                        }

    //                        objEntityTrficVioltnDetilsList.Add(objEntityDetails);

    //                    }
    //                }

    //                objEntityTrficVioltnDetilsList.Reverse();
    //            }

    //            string strCanclDtlId1 = "";
    //            string[] strarrCancldtlIdsGrp1 = strCanclDtlId1.Split(',');

    //            if (hiddenSubCanclDbId.Value != "" && hiddenSubCanclDbId.Value != null)
    //            {

    //                strCanclDtlId1 = hiddenSubCanclDbId.Value;
    //                strarrCancldtlIdsGrp1 = strCanclDtlId1.Split(',');
    //            }
    //            foreach (string strDtlId in strarrCancldtlIdsGrp1)
    //            {
    //                //    //Msgbox(strDtlId);
    //                if (strDtlId != "" && strDtlId != null)
    //                {
    //                    int intDtlId1 = Convert.ToInt32(strDtlId);
    //                    //Msgbox(intDtlId1.ToString());
    //                    clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
    //                    objEntityDetails.TempId = Convert.ToInt32(strDtlId);

    //                    objEntityTrficVioltnDele.Add(objEntityDetails);
    //                }
    //            }

    //            if (CnclSts == 0)
    //            {
    //                objBussinesspasprt.insertdoccnfm(objentityPassport, objEntityTrficVioltnDetilsListIns, objEntityTrficVioltnDetilsListDele, objEntityTrficVioltnDetilsList, objEntityTrficVioltnDele, objentityPasspo);
    //            }
    //            HiddenFieldSubData.Value = "";

    //            if (CnclSts == 0)
    //            {
    //                if (clickedButton.ID == "btnCnfrm")
    //                {
    //                    Response.Redirect("gen_Document_Workflow_List.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Cnfm");
    //                }
    //            }
    //            else
    //            {
    //                Response.Redirect("gen_Document_Workflow_List.aspx?InsUpd=AlrdyCncl");
    //            }
    //        }

    //    }

    //    catch (Exception ex)
    //    {
    //    }
    //    btnReopen.Enabled = true;
    //    btnReopen1.Enabled = true;
    //    btnReopen1Float.Enabled = true;
    //}

    protected void btnCnfrm_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;

            clsCommonLibrary objCommon = new clsCommonLibrary();

            clsBusinessLayerPMS objBusinessWrkFlow = new clsBusinessLayerPMS();
            clsEntityApprovalHierarchyTemp objEntityWrkFlow = new clsEntityApprovalHierarchyTemp();

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityWrkFlow.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityWrkFlow.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objEntityWrkFlow.User_Id = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            string strId = "";
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                strId = strRandomMixedId.Substring(2, intLenghtofId);
            }

            objEntityWrkFlow.TempId = Convert.ToInt32(strId);

            objEntityWrkFlow.Name = txtName.Text.Trim();
            objEntityWrkFlow.Doc = docsection.SelectedItem.Value;
            if (cbxsts.Checked == true)
            {
                objEntityWrkFlow.Status_id = 1;
            }
            else
            {
                objEntityWrkFlow.Status_id = 0;
            }
            objEntityWrkFlow.descr = txtDescr.Text.Trim();
            if (cbxapr.Checked == true)
            {
                objEntityWrkFlow.apptrans = 1;
            }
            else
            {
                objEntityWrkFlow.apptrans = 0;
            }
            if (cbxmdfy.Checked == true)
            {
                objEntityWrkFlow.appmdf = 1;
            }
            else
            {
                objEntityWrkFlow.appmdf = 0;
            }

            string dept = "";
            for (int j = 0; j < lstDpt.Items.Count; j++)
            {
                if (lstDpt.Items[j].Selected == true)
                {
                    if (dept == "")
                    {
                        dept = lstDpt.Items[j].Value;
                    }
                    else
                    {
                        dept = dept + "," + lstDpt.Items[j].Value;
                    }
                }
            }
            objEntityWrkFlow.Dep = dept.ToString();

            string divd = "";
            for (int k = 0; k < lstDiv.Items.Count; k++)
            {
                if (lstDiv.Items[k].Selected == true)
                {
                    if (divd == "")
                    {
                        divd = lstDiv.Items[k].Value;
                    }
                    else
                    {
                        divd = divd + "," + lstDiv.Items[k].Value;
                    }
                }
            }
            objEntityWrkFlow.div = divd.ToString();

            objEntityWrkFlow.hrid = Convert.ToInt32(dlHrchy.SelectedItem.Value);

            if (dte_1_a.Value.Trim() != "")
            {
                objEntityWrkFlow.StartDate = objCommon.textToDateTime(dte_1_a.Value.Trim());
            }
            if (dte_1.Value.Trim() != "")
            {
                objEntityWrkFlow.EndDate = objCommon.textToDateTime(dte_1.Value.Trim());
            }

            if (cbxaprpnd.Checked == true)
            {
                objEntityWrkFlow.appnd = 1;
            }
            else
            {
                objEntityWrkFlow.appnd = 0;
            }
            if (cbxsm.Checked == true)
            {
                objEntityWrkFlow.sms = 1;
            }
            else
            {
                objEntityWrkFlow.sms = 0;
            }
            if (cbxnt.Checked == true)
            {
                objEntityWrkFlow.dash = 1;
            }
            else
            {
                objEntityWrkFlow.dash = 0;
            }
            if (cbxTmExd.Checked == true)
            {
                objEntityWrkFlow.ttc = 1;
            }
            else
            {
                objEntityWrkFlow.ttc = 0;
            }
            if (rbHigh.Checked == true)
            {
                objEntityWrkFlow.prity = 1;
            }
            else
            {
                objEntityWrkFlow.prity = 0;
            }

            int CnclSts = 0;
            DataTable dt = objBusinessWrkFlow.Readwrkflwdtls11(objEntityWrkFlow);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["WRKFLW_CNCL_USR_ID"].ToString() != "")
                {
                    CnclSts++;
                }
            }

            List<clsEntityApprovalHierarchyTemp> objEntityWrkFlowUPDATEList = new List<clsEntityApprovalHierarchyTemp>();

            List<clsEntityApprovalHierarchyTemp> objEntityWrkFlowDELETEList = new List<clsEntityApprovalHierarchyTemp>();

            List<clsEntityApprovalHierarchyTemp> objEntityWrkFlowMainINSERTList = new List<clsEntityApprovalHierarchyTemp>();
            List<clsEntityApprovalHierarchyTemp> objEntityWrkFlowSubINSERTList = new List<clsEntityApprovalHierarchyTemp>();

            //Hierarchy changed
            if (hiddenHrchyChngdMode.Value == "1")
            {
                string jsonData = HiddenFieldMainData.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string i = h.Replace("}\",", "},");

                List<clsTVData> objDataMainList = new List<clsTVData>();
                objDataMainList = JsonConvert.DeserializeObject<List<clsTVData>>(i);

                if (HiddenFieldMainData.Value != "" && HiddenFieldMainData.Value != null)
                {
                    foreach (clsTVData objData in objDataMainList)
                    {
                        clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
                        if (objData.EMPID != "-Select-" && objData.DESGID != "-Select-" && objData.PERIOD != "")
                        {
                            objEntityDetails.TempDtlId = Convert.ToInt32(objData.DTLID);//HrchyId
                            if (objData.PARENT != "")
                            {
                                objEntityDetails.ParentId = Convert.ToInt32(objData.PARENT);//HrchyId
                            }
                            objEntityDetails.Level = Convert.ToInt32(objData.LEVEL);
                            objEntityDetails.DesgId = Convert.ToInt32(objData.DESGID);
                            objEntityDetails.EmployeeId = Convert.ToInt32(objData.EMPID);
                            objEntityDetails.ThresholdPeriodMode = Convert.ToInt32(objData.THRESMODE);
                            objEntityDetails.ThresholdPeriodDays = Convert.ToInt32(objData.PERIOD);
                            objEntityDetails.MajorityAprvSts = Convert.ToInt32(objData.APPRVMANSTS);
                            objEntityDetails.SubstituteEmpSts = Convert.ToInt32(objData.SUBEMPSTS);
                            objEntityDetails.AprvPendingSts = Convert.ToInt32(objData.APPRVPENSTS);
                            objEntityDetails.TtExceededSts = Convert.ToInt32(objData.TTCSTS);
                            objEntityDetails.SmsSts = Convert.ToInt32(objData.SMSSTS);
                            objEntityDetails.SystemSts = Convert.ToInt32(objData.SYSSTS);

                            objEntityWrkFlowMainINSERTList.Add(objEntityDetails);
                        }
                    }
                }

                string jsonData1 = HiddenFieldSubData.Value;
                string c1 = jsonData1.Replace("\"{", "\\{");
                string d1 = c1.Replace("\\n", "\r\n");
                string g1 = d1.Replace("\\", "");
                string h1 = g1.Replace("}\"]", "}]");
                string i1 = h1.Replace("}\",", "},");

                List<clsTVData> objDataSubList = new List<clsTVData>();
                objDataSubList = JsonConvert.DeserializeObject<List<clsTVData>>(i1);

                if (HiddenFieldSubData.Value != "" && HiddenFieldSubData.Value != null)
                {
                    foreach (clsTVData objData in objDataSubList)
                    {
                        clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
                        if (objData.EMPID != "-Select-" && objData.DESGID != "-Select-" && objData.PERIOD != "")
                        {
                            objEntityDetails.TempDtlId = Convert.ToInt32(objData.DTLID);//HrchyId
                            if (objData.PARENT != "")
                            {
                                objEntityDetails.ParentId = Convert.ToInt32(objData.PARENT);//HrchyId
                            }
                            objEntityDetails.Level = Convert.ToInt32(objData.LEVEL);
                            objEntityDetails.DesgId = Convert.ToInt32(objData.DESGID);
                            objEntityDetails.EmployeeId = Convert.ToInt32(objData.EMPID);
                            objEntityDetails.ThresholdPeriodMode = Convert.ToInt32(objData.THRESMODE);
                            objEntityDetails.ThresholdPeriodDays = Convert.ToInt32(objData.PERIOD);
                            objEntityDetails.MajorityAprvSts = Convert.ToInt32(objData.APPRVMANSTS);
                            objEntityDetails.SubstituteEmpSts = Convert.ToInt32(objData.SUBEMPSTS);
                            objEntityDetails.AprvPendingSts = Convert.ToInt32(objData.APPRVPENSTS);
                            objEntityDetails.TtExceededSts = Convert.ToInt32(objData.TTCSTS);
                            objEntityDetails.SmsSts = Convert.ToInt32(objData.SMSSTS);
                            objEntityDetails.SystemSts = Convert.ToInt32(objData.SYSSTS);

                            objEntityWrkFlowSubINSERTList.Add(objEntityDetails);
                        }
                    }
                }
            }
            else
            {

                string jsonData = HiddenFieldMainData.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string i = h.Replace("}\",", "},");

                List<clsTVData> objDataMainList = new List<clsTVData>();
                objDataMainList = JsonConvert.DeserializeObject<List<clsTVData>>(i);

                if (HiddenFieldMainData.Value != "" && HiddenFieldMainData.Value != null)
                {
                    foreach (clsTVData objData in objDataMainList)
                    {
                        clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
                        if (objData.EMPID != "-Select-" && objData.DESGID != "-Select-" && objData.PERIOD != "")
                        {
                            objEntityDetails.DtlId = Convert.ToInt32(objData.DTLID);//WrkflowDtlId
                            if (objData.PARENT != "")
                            {
                                objEntityDetails.ParentId = Convert.ToInt32(objData.PARENT);//WrkflowDtlId
                            }
                            objEntityDetails.Level = Convert.ToInt32(objData.LEVEL);
                            objEntityDetails.DesgId = Convert.ToInt32(objData.DESGID);
                            objEntityDetails.EmployeeId = Convert.ToInt32(objData.EMPID);
                            objEntityDetails.ThresholdPeriodMode = Convert.ToInt32(objData.THRESMODE);
                            objEntityDetails.ThresholdPeriodDays = Convert.ToInt32(objData.PERIOD);
                            objEntityDetails.MajorityAprvSts = Convert.ToInt32(objData.APPRVMANSTS);
                            objEntityDetails.SubstituteEmpSts = Convert.ToInt32(objData.SUBEMPSTS);
                            objEntityDetails.AprvPendingSts = Convert.ToInt32(objData.APPRVPENSTS);
                            objEntityDetails.TtExceededSts = Convert.ToInt32(objData.TTCSTS);
                            objEntityDetails.SmsSts = Convert.ToInt32(objData.SMSSTS);
                            objEntityDetails.SystemSts = Convert.ToInt32(objData.SYSSTS);

                            objEntityWrkFlowUPDATEList.Add(objEntityDetails);
                        }
                    }
                }

                string jsonData1 = HiddenFieldSubData.Value;
                string c1 = jsonData1.Replace("\"{", "\\{");
                string d1 = c1.Replace("\\n", "\r\n");
                string g1 = d1.Replace("\\", "");
                string h1 = g1.Replace("}\"]", "}]");
                string i1 = h1.Replace("}\",", "},");

                List<clsTVData> objDataSubList = new List<clsTVData>();
                objDataSubList = JsonConvert.DeserializeObject<List<clsTVData>>(i1);

                if (HiddenFieldSubData.Value != "" && HiddenFieldSubData.Value != null)
                {
                    foreach (clsTVData objData in objDataSubList)
                    {
                        clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
                        if (objData.EMPID != "-Select-" && objData.DESGID != "-Select-" && objData.PERIOD != "")
                        {
                            if (objData.DTLID != "" && objData.DTLID != null && objData.DTLID != "null")
                            {
                                objEntityDetails.DtlId = Convert.ToInt32(objData.DTLID);//WrkflowDtlId
                            }
                            if (objData.PARENT != "")
                            {
                                objEntityDetails.ParentId = Convert.ToInt32(objData.PARENT);//WrkflowDtlId
                            }
                            objEntityDetails.Level = Convert.ToInt32(objData.LEVEL);
                            objEntityDetails.DesgId = Convert.ToInt32(objData.DESGID);
                            objEntityDetails.EmployeeId = Convert.ToInt32(objData.EMPID);
                            objEntityDetails.ThresholdPeriodMode = Convert.ToInt32(objData.THRESMODE);
                            objEntityDetails.ThresholdPeriodDays = Convert.ToInt32(objData.PERIOD);
                            objEntityDetails.MajorityAprvSts = Convert.ToInt32(objData.APPRVMANSTS);
                            objEntityDetails.SubstituteEmpSts = Convert.ToInt32(objData.SUBEMPSTS);
                            objEntityDetails.AprvPendingSts = Convert.ToInt32(objData.APPRVPENSTS);
                            objEntityDetails.TtExceededSts = Convert.ToInt32(objData.TTCSTS);
                            objEntityDetails.SmsSts = Convert.ToInt32(objData.SMSSTS);
                            objEntityDetails.SystemSts = Convert.ToInt32(objData.SYSSTS);

                            objEntityWrkFlowUPDATEList.Add(objEntityDetails);
                        }
                    }
                }

                if (hiddenMainCanclDbId.Value != "" && hiddenMainCanclDbId.Value != null)
                {
                    foreach (string strDtlId in hiddenMainCanclDbId.Value.Split(','))
                    {
                        if (strDtlId != "" && strDtlId != null)
                        {
                            clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
                            objEntityDetails.DtlId = Convert.ToInt32(strDtlId);

                            DataTable dtLower = objBusinessWrkFlow.ReadLowerHierarchyIds(objEntityDetails);
                            if (dtLower.Rows.Count > 0)
                            {
                                for (int intCount = 0; intCount < dtLower.Rows.Count; intCount++)
                                {
                                    clsEntityApprovalHierarchyTemp objEntity = new clsEntityApprovalHierarchyTemp();
                                    objEntity.DtlId = Convert.ToInt32(dtLower.Rows[intCount]["WRKFLW_DTL_ID"].ToString());
                                    objEntityWrkFlowDELETEList.Add(objEntity);
                                }
                            }

                        }
                    }
                }

                if (hiddenSubCanclDbId.Value != "" && hiddenSubCanclDbId.Value != null)
                {
                    foreach (string strDtlId in hiddenSubCanclDbId.Value.Split(','))
                    {
                        if (strDtlId != "" && strDtlId != null)
                        {
                            clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
                            objEntityDetails.DtlId = Convert.ToInt32(strDtlId);

                            DataTable dtLower = objBusinessWrkFlow.ReadLowerHierarchyIds(objEntityDetails);
                            if (dtLower.Rows.Count > 0)
                            {
                                for (int intCount = 0; intCount < dtLower.Rows.Count; intCount++)
                                {
                                    clsEntityApprovalHierarchyTemp objEntity = new clsEntityApprovalHierarchyTemp();
                                    objEntity.DtlId = Convert.ToInt32(dtLower.Rows[intCount]["WRKFLW_DTL_ID"].ToString());
                                    objEntityWrkFlowDELETEList.Add(objEntity);
                                }
                            }

                        }
                    }
                }
            }

            objEntityWrkFlow.ConfirmSts = 1;

            if (CnclSts == 0)
            {
                //objBusinessWrkFlow.UpdateDocumentWorkflow(objEntityWrkFlow, objEntityWrkFlowUPDATEList, objEntityWrkFlowDELETEList, objEntityWrkFlowMainINSERTList, objEntityWrkFlowSubINSERTList);


                if (clickedButton.ID == "btnCnfrm")
                {
                    Response.Redirect("gen_Document_Workflow_List.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Cnfm");
                }
            }
            else
            {
                Response.Redirect("gen_Document_Workflow_List.aspx?InsUpd=AlrdyCncl");
            }
        }

        catch (Exception ex)
        {
        }
        btnReopen.Enabled = true;
        btnReopen1.Enabled = true;
        btnReopen1Float.Enabled = true;
    }

    protected void btnEcnfrm_Click(object sender, EventArgs e)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
        clsEntityApprovalHierarchyTemp objentityPass = new clsEntityApprovalHierarchyTemp();
        clsEntityApprovalHierarchyTemp objentityPass1 = new clsEntityApprovalHierarchyTemp();
        clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
        if (Session["CORPOFFICEID"] != null)
        {
            objentityPassport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
            objentityPass.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objentityPassport.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            objentityPass.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objentityPassport.User_Id = Convert.ToInt32(Session["USERID"]);
            objentityPass.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objentityPass.Name = txtName.Text.Trim();
        DateTime dd = DateTime.Parse(DateTime.Now.ToShortDateString());
        string dat = dd.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
        if (dat.Trim() != "")
        {
            objentityPass.cDate = objCommon.textToDateTime(dat.Trim());
        }
        objBussinesspasprt.updateDocwrkDataconform(objentityPass);
        Response.Redirect("gen_Document_Workflow_List.aspx");
    }
    //protected void btnReopen_Click(object sender, EventArgs e)
    //{
    //    Button clickedButton = sender as Button;

    //    this.lstDiv.Attributes.Add("disabled", "");
    //    this.lstDpt.Attributes.Add("disabled", "");
        
    //    btnUpdateClose.Enabled = true;
    //    btnReUpdate.Enabled = true;
    //    btnCnfrm1.Enabled = true;

    //    btnSave.Visible = false;
    //    btnSaveFloat.Visible = false;

    //    btnUpdate.Visible = false;
    //    btnUpdateFloat.Visible = false;
    //    btnUpdateClose.Visible = true;
    //    btnUpdateCloseFloat.Visible = true;
    //    btnReUpdate.Visible = true;
    //    btnCnfrm1.Visible = true;
    //    btnCnfrm1Float.Visible = true;
    //    btnEcnfrm.Visible = false;

    //    btnReopen1.Visible = false;
    //    btnReopen1Float.Visible = false;

    //    Hiddenview.Value = "0";
    //    HiddenReopen.Value = "1";
        

    //    string strId = HiddenHrchyId.Value;
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
    //    clsEntityApprovalHierarchyTemp objentityPass = new clsEntityApprovalHierarchyTemp();
    //    objentityPass.TempId = Convert.ToInt32(strId);
    //    objentityPass.User_Id = Convert.ToInt32(Session["USERID"]);
    //    DateTime dd = DateTime.Parse(DateTime.Now.ToShortDateString());
    //    string dat = dd.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
    //    if (dat.Trim() != "")
    //    {
    //        objentityPass.cDate = objCommon.textToDateTime(dat.Trim());
    //    }

    //    objBussinesspasprt.updateDocwrkDataReopen(objentityPass);
    //    HiddenFieldwrkId.Value = strId;
    //    if (clickedButton.ID == "btnReopen")
    //    {
    //        Response.Redirect("gen_Document_Workflow.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Reopen");
    //    }
    //}

    protected void btnReopen_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;

        clsBusinessLayerPMS objBusinessWrkFlow = new clsBusinessLayerPMS();
        clsEntityApprovalHierarchyTemp objEntityWrkFlow = new clsEntityApprovalHierarchyTemp();

        if (Session["USERID"] != null)
        {
            objEntityWrkFlow.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        string strId = "";
        if (Request.QueryString["Id"] != null)
        {
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            strId = strRandomMixedId.Substring(2, intLenghtofId);
        }
        objEntityWrkFlow.TempId = Convert.ToInt32(strId);

        objBusinessWrkFlow.ReopenWrkflow(objEntityWrkFlow);
        HiddenFieldwrkId.Value = strId;

        if (clickedButton.ID == "btnReopen" || clickedButton.ID == "btnReopenFloat")
        {
            Response.Redirect("gen_Document_Workflow.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Reopen");
        }
    }


    //protected void btnUpdate_Click(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        Button clickedButton = sender as Button;
    //        clsCommonLibrary objCommon = new clsCommonLibrary();
    //        clsBusinessLayerPMS objEntitybuspms = new clsBusinessLayerPMS();

    //        clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
    //        clsEntityApprovalHierarchyTemp objentityPass = new clsEntityApprovalHierarchyTemp();
    //        clsEntityApprovalHierarchyTemp objentityPass1 = new clsEntityApprovalHierarchyTemp();
    //        clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
    //        if (Session["CORPOFFICEID"] != null)
    //        {
    //            objentityPassport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
    //            objentityPass.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
    //        }
    //        else if (Session["CORPOFFICEID"] == null)
    //        {
    //            Response.Redirect("/Default.aspx");
    //        }
    //        if (Session["ORGID"] != null)
    //        {
    //            objentityPassport.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
    //            objentityPass.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
    //        }
    //        else if (Session["ORGID"] == null)
    //        {
    //            Response.Redirect("/Default.aspx");
    //        }
    //        if (Session["USERID"] != null)
    //        {
    //            objentityPassport.User_Id = Convert.ToInt32(Session["USERID"]);
    //            objentityPass.User_Id = Convert.ToInt32(Session["USERID"]);
    //        }
    //        else if (Session["USERID"] == null)
    //        {
    //            Response.Redirect("/Default.aspx");
    //        }
    //        objentityPassport.Name = txtName.Text;

    //        if (dte_1_a.Value.Trim() != "")
    //        {
    //            objentityPassport.StartDate = objCommon.textToDateTime(dte_1_a.Value.Trim());
    //            objentityPass.StartDate = objCommon.textToDateTime(dte_1_a.Value.Trim());
    //        }
    //        if (dte_1.Value.Trim() != "")
    //        {
    //            objentityPassport.EndDate = objCommon.textToDateTime(dte_1.Value.Trim());
    //            objentityPass.EndDate = objCommon.textToDateTime(dte_1.Value.Trim());
    //        }
    //        objentityPass.Name = txtName.Text.Trim();
    //        objentityPassport.Doc = docsection.SelectedItem.ToString();
    //        if (cbxsts.Checked == true)
    //        {
    //            objentityPassport.Status_id = 1;
    //        }
    //        else
    //        {
    //            objentityPassport.Status_id = 0;

    //        }
    //        objentityPassport.descr = txtDescr.Text;
    //        if (cbxapr.Checked == true)
    //        {
    //            objentityPassport.apptrans = 1;
    //        }
    //        else
    //        {
    //            objentityPassport.apptrans = 0;
    //        }
    //        if (cbxmdfy.Checked == true)
    //        {
    //            objentityPassport.appmdf = 1;
    //        }
    //        else
    //        {
    //            objentityPassport.appmdf = 0;
    //        }
    //        string dept = "";
    //        for (int j = 0; j < lstDpt.Items.Count; j++)
    //        {
    //            if (lstDpt.Items[j].Selected == true)
    //            {
    //                if (dept == "")
    //                {
    //                    dept = lstDpt.Items[j].Value;
    //                }
    //                else
    //                {
    //                    dept = dept + "," + lstDpt.Items[j].Value;
    //                }
    //            }
    //        }

    //        objentityPassport.Dep = dept.ToString();
    //        string divd = "";
    //        for (int k = 0; k < lstDiv.Items.Count; k++)
    //        {
    //            if (lstDiv.Items[k].Selected == true)
    //            {
    //                if (divd == "")
    //                {
    //                    divd = lstDiv.Items[k].Value;
    //                }
    //                else
    //                {
    //                    divd = divd + "," + lstDiv.Items[k].Value;
    //                }
    //            }
    //        }
    //        objentityPassport.div = divd.ToString();
    //        objentityPassport.hrid = Convert.ToInt32(dlHrchy.SelectedValue);
    //        if (cbxaprpnd.Checked == true)
    //        {
    //            objentityPassport.appnd = 1;
    //        }
    //        else
    //        {
    //            objentityPassport.appnd = 0;
    //        }
    //        if (cbxsm.Checked == true)
    //        {
    //            objentityPassport.sms = 1;
    //        }
    //        else
    //        {
    //            objentityPassport.sms = 0;
    //        }
    //        if (cbxnt.Checked == true)
    //        {
    //            objentityPassport.dash = 1;
    //        }
    //        else
    //        {
    //            objentityPassport.dash = 0;
    //        }
    //        if (cbxTmExd.Checked == true)
    //        {
    //            objentityPassport.ttc = 1;
    //        }
    //        else
    //        {
    //            objentityPassport.ttc = 0;
    //        }
    //        if (rbHigh.Checked == true)
    //        {
    //            objentityPassport.prity = 1;
    //        }
    //        else
    //        {
    //            objentityPassport.prity = 0;
    //        }
    //        DateTime dd = DateTime.Parse(DateTime.Now.ToShortDateString());
    //        string dat = dd.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
    //        if (dat.Trim() != "")
    //        {
    //            objentityPassport.cDate = objCommon.textToDateTime(dat.Trim());
    //        }

    //        objentityPassport.Name = txtName.Text.Trim();
    //        objentityPassport.Name1 = HiddenWrkname.Value;
    //        objentityPass1.Name = txtName.Text.Trim();
    //        DataTable dts = objEntitybuspms.Readwrkflwdid1(objentityPass1);
    //        if (dts.Rows.Count > 0)
    //        {
    //            string tempid = dts.Rows[0]["WRKFLW_ID"].ToString();
    //        }

    //        string strId = "";
    //        if (Request.QueryString["Id"] != null)
    //        {
    //            string strRandomMixedId = Request.QueryString["Id"].ToString();
    //            string strLenghtofId = strRandomMixedId.Substring(0, 2);
    //            int intLenghtofId = Convert.ToInt16(strLenghtofId);
    //            strId = strRandomMixedId.Substring(2, intLenghtofId);
    //        }

    //        objentityPassport.TempId = Convert.ToInt32(strId);

    //        int CnclSts = 0;
    //        DataTable dt = objBussinesspasprt.ReadDocumentdtls(objentityPassport);
    //        if (dt.Rows.Count > 0 && dt.Rows[0]["WRKFLW_CNCL_USR_ID"].ToString() != "")
    //        {
    //            CnclSts++;
    //        }

    //        if (cbxsts.Checked == true)
    //        {
    //            objentityPassport.Status_id = 1;
    //        }
    //        else
    //        {
    //            objentityPassport.Status_id = 0;

    //        }
    //        List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListIns = new List<clsEntityApprovalHierarchyTemp>();
    //        List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListDele = new List<clsEntityApprovalHierarchyTemp>();
    //        string jsonData = HiddenFieldMainData.Value;
    //        string c = jsonData.Replace("\"{", "\\{");
    //        string d = c.Replace("\\n", "\r\n");
    //        string g = d.Replace("\\", "");
    //        string h = g.Replace("}\"]", "}]");
    //        string i = h.Replace("}\",", "},");
    //        List<clsTVData> objTVDataList5 = new List<clsTVData>();
    //        objTVDataList5 = JsonConvert.DeserializeObject<List<clsTVData>>(i);
    //        // Msgbox(HiddenFieldMainData.Value);
    //        if (HiddenFieldMainData.Value != "" && HiddenFieldMainData.Value != null)
    //        {
    //            foreach (clsTVData objclsTVData in objTVDataList5)
    //            {
    //                clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
    //                if (objclsTVData.EMPID != "-Select-" && objclsTVData.DESGID != "-Select-" && objclsTVData.PERIOD != "")
    //                {
    //                    objEntityDetails.DesgId = Convert.ToInt32(objclsTVData.DESGID);
    //                    objEntityDetails.EmployeeId = Convert.ToInt32(objclsTVData.EMPID);
    //                    objEntityDetails.MajorityAprvSts = Convert.ToInt32(objclsTVData.APPRVMANSTS);
    //                    objEntityDetails.SubstituteEmpSts = Convert.ToInt32(objclsTVData.SUBEMPSTS);
    //                    objEntityDetails.ThresholdPeriodMode = Convert.ToInt32(objclsTVData.THRESMODE);
    //                    objEntityDetails.ThresholdPeriodDays = Convert.ToInt32(objclsTVData.PERIOD);
    //                    objEntityDetails.AprvPendingSts = Convert.ToInt32(objclsTVData.APPRVPENSTS);
    //                    objEntityDetails.TtExceededSts = Convert.ToInt32(objclsTVData.TTCSTS);
    //                    objEntityDetails.SmsSts = Convert.ToInt32(objclsTVData.SMSSTS);
    //                    objEntityDetails.SystemSts = Convert.ToInt32(objclsTVData.SYSSTS);
    //                    if (objclsTVData.DTLID != "" && objclsTVData.DTLID != "null" && objclsTVData.DTLID != null)
    //                    {
    //                        objEntityDetails.TempId = Convert.ToInt32(objclsTVData.DTLID);
    //                    }

    //                    objEntityTrficVioltnDetilsListIns.Add(objEntityDetails);
    //                }
    //            }

    //            objEntityTrficVioltnDetilsListIns.Reverse();
    //            string strCanclDtlId = "";
    //            string[] strarrCancldtlIdsGrp = strCanclDtlId.Split(',');

    //            if (hiddenMainCanclDbId.Value != "" && hiddenMainCanclDbId.Value != null)
    //            {

    //                strCanclDtlId = hiddenMainCanclDbId.Value;
    //                strarrCancldtlIdsGrp = strCanclDtlId.Split(',');
    //            }
    //            foreach (string strDtlId in strarrCancldtlIdsGrp)
    //            {

    //                if (strDtlId != "" && strDtlId != null)
    //                {

    //                    int intDtlId = Convert.ToInt32(strDtlId);
    //                    clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
    //                    objEntityDetails.TempId = Convert.ToInt32(strDtlId);
    //                    objEntityTrficVioltnDetilsListDele.Add(objEntityDetails);
    //                }
    //            }

    //            if (CnclSts == 0)
    //            {
    //                objBussinesspasprt.updateDocumentData(objentityPassport, objEntityTrficVioltnDetilsListIns, objEntityTrficVioltnDetilsListDele);
    //            }

    //            List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsList = new List<clsEntityApprovalHierarchyTemp>();
    //            List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDele = new List<clsEntityApprovalHierarchyTemp>();
    //            string jsonData1 = HiddenFieldSubData.Value;
    //            string c1 = jsonData1.Replace("\"{", "\\{");
    //            string d1 = c1.Replace("\\n", "\r\n");
    //            string g1 = d1.Replace("\\", "");
    //            string h1 = g1.Replace("}\"]", "}]");
    //            string i1 = h1.Replace("}\",", "},");
    //            List<clsTVData> objTVDataList51 = new List<clsTVData>();
    //            objTVDataList51 = JsonConvert.DeserializeObject<List<clsTVData>>(i1);

    //            //  Msgbox(HiddenFieldSubData.Value);
    //            if (HiddenFieldSubData.Value != "" && HiddenFieldSubData.Value != null)
    //            {
    //                foreach (clsTVData objclsTVData in objTVDataList51)
    //                {
    //                    clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
    //                    if (objclsTVData.EMPID != "-Select-" && objclsTVData.DESGID != "-Select-" && objclsTVData.PERIOD != "")
    //                    {
    //                        objEntityDetails.Status_id = Convert.ToInt32(HiddenFieldwrkId.Value);

    //                        objEntityDetails.ParentId = Convert.ToInt32(HiddenFieldCurrentDtlId.Value);

    //                        objEntityDetails.Level = Convert.ToInt32(objclsTVData.LEVEL);
    //                        objEntityDetails.User_Id = 0;


    //                        objEntityDetails.DesgId = Convert.ToInt32(objclsTVData.DESGID);
    //                        objEntityDetails.EmployeeId = Convert.ToInt32(objclsTVData.EMPID);
    //                        objEntityDetails.MajorityAprvSts = Convert.ToInt32(objclsTVData.APPRVMANSTS);
    //                        objEntityDetails.SubstituteEmpSts = Convert.ToInt32(objclsTVData.SUBEMPSTS);
    //                        objEntityDetails.ThresholdPeriodMode = Convert.ToInt32(objclsTVData.THRESMODE);
    //                        objEntityDetails.ThresholdPeriodDays = Convert.ToInt32(objclsTVData.PERIOD);
    //                        objEntityDetails.AprvPendingSts = Convert.ToInt32(objclsTVData.APPRVPENSTS);
    //                        objEntityDetails.TtExceededSts = Convert.ToInt32(objclsTVData.TTCSTS);
    //                        objEntityDetails.SmsSts = Convert.ToInt32(objclsTVData.SMSSTS);
    //                        objEntityDetails.SystemSts = Convert.ToInt32(objclsTVData.SYSSTS);
    //                        if (objclsTVData.DTLID != "" && objclsTVData.DTLID != "null" && objclsTVData.DTLID != null)
    //                        {
    //                            objEntityDetails.TempId = Convert.ToInt32(objclsTVData.DTLID);
    //                        }
    //                        else
    //                        {
    //                            objEntityDetails.TempId = 0;
    //                        }
    //                        objEntityTrficVioltnDetilsList.Add(objEntityDetails);

    //                    }
    //                }

    //                objEntityTrficVioltnDetilsList.Reverse();

    //                string strCanclDtlId1 = "";
    //                string[] strarrCancldtlIdsGrp1 = strCanclDtlId1.Split(',');

    //                if (hiddenSubCanclDbId.Value != "" && hiddenSubCanclDbId.Value != null)
    //                {

    //                    strCanclDtlId1 = hiddenSubCanclDbId.Value;
    //                    strarrCancldtlIdsGrp1 = strCanclDtlId1.Split(',');
    //                }
    //                foreach (string strDtlId in strarrCancldtlIdsGrp1)
    //                {
    //                    //    //Msgbox(strDtlId);
    //                    if (strDtlId != "" && strDtlId != null)
    //                    {
    //                        int intDtlId1 = Convert.ToInt32(strDtlId);
    //                        //Msgbox(intDtlId1.ToString());
    //                        clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
    //                        objEntityDetails.TempId = Convert.ToInt32(strDtlId);

    //                        objEntityTrficVioltnDele.Add(objEntityDetails);
    //                    }
    //                }



    //                if (CnclSts == 0)
    //                {
    //                    objBussinesspasprt.insertDocumentDataDtlsSUB(objEntityTrficVioltnDetilsList, objEntityTrficVioltnDele);
    //                }

    //                HiddenFieldSubData.Value = "";

    //            }

    //            if (CnclSts == 0)
    //            {
    //                if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateFloat")
    //                {
    //                    Response.Redirect("gen_Document_Workflow.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Upd");
    //                }
    //                else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseFloat")
    //                {
    //                    Response.Redirect("gen_Document_Workflow_List.aspx?InsUpd=Upd");
    //                }
    //                else if (clickedButton.ID == "btnReUpdate")
    //                {
    //                    Response.Redirect("gen_Document_Workflow_List.aspx?InsUpd=Upd");
    //                }
    //            }
    //            else
    //            {
    //                Response.Redirect("gen_Document_Workflow_List.aspx?InsUpd=AlrdyCncl");
    //            }
    //        }
    //    }

    //    catch (Exception ex)
    //    {
    //    }
    //}

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;

            clsCommonLibrary objCommon = new clsCommonLibrary();

            clsBusinessLayerPMS objBusinessWrkFlow = new clsBusinessLayerPMS();
            clsEntityApprovalHierarchyTemp objEntityWrkFlow = new clsEntityApprovalHierarchyTemp();

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityWrkFlow.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityWrkFlow.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objEntityWrkFlow.User_Id = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            string strId = "";
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                strId = strRandomMixedId.Substring(2, intLenghtofId);
            }

            objEntityWrkFlow.TempId = Convert.ToInt32(strId);

            objEntityWrkFlow.Name = txtName.Text.Trim();
            objEntityWrkFlow.Doc = docsection.SelectedItem.Value;
            if (cbxsts.Checked == true)
            {
                objEntityWrkFlow.Status_id = 1;
            }
            else
            {
                objEntityWrkFlow.Status_id = 0;
            }
            objEntityWrkFlow.descr = txtDescr.Text.Trim();
            if (cbxapr.Checked == true)
            {
                objEntityWrkFlow.apptrans = 1;
            }
            else
            {
                objEntityWrkFlow.apptrans = 0;
            }
            if (cbxmdfy.Checked == true)
            {
                objEntityWrkFlow.appmdf = 1;
            }
            else
            {
                objEntityWrkFlow.appmdf = 0;
            }

            string dept = "";
            for (int j = 0; j < lstDpt.Items.Count; j++)
            {
                if (lstDpt.Items[j].Selected == true)
                {
                    if (dept == "")
                    {
                        dept = lstDpt.Items[j].Value;
                    }
                    else
                    {
                        dept = dept + "," + lstDpt.Items[j].Value;
                    }
                }
            }
            objEntityWrkFlow.Dep = dept.ToString();

            string divd = "";
            for (int k = 0; k < lstDiv.Items.Count; k++)
            {
                if (lstDiv.Items[k].Selected == true)
                {
                    if (divd == "")
                    {
                        divd = lstDiv.Items[k].Value;
                    }
                    else
                    {
                        divd = divd + "," + lstDiv.Items[k].Value;
                    }
                }
            }
            objEntityWrkFlow.div = divd.ToString();

            objEntityWrkFlow.hrid = Convert.ToInt32(dlHrchy.SelectedItem.Value);

            if (dte_1_a.Value.Trim() != "")
            {
                objEntityWrkFlow.StartDate = objCommon.textToDateTime(dte_1_a.Value.Trim());
            }
            if (dte_1.Value.Trim() != "")
            {
                objEntityWrkFlow.EndDate = objCommon.textToDateTime(dte_1.Value.Trim());
            }

            if (cbxaprpnd.Checked == true)
            {
                objEntityWrkFlow.appnd = 1;
            }
            else
            {
                objEntityWrkFlow.appnd = 0;
            }
            if (cbxsm.Checked == true)
            {
                objEntityWrkFlow.sms = 1;
            }
            else
            {
                objEntityWrkFlow.sms = 0;
            }
            if (cbxnt.Checked == true)
            {
                objEntityWrkFlow.dash = 1;
            }
            else
            {
                objEntityWrkFlow.dash = 0;
            }
            if (cbxTmExd.Checked == true)
            {
                objEntityWrkFlow.ttc = 1;
            }
            else
            {
                objEntityWrkFlow.ttc = 0;
            }
            if (rbHigh.Checked == true)
            {
                objEntityWrkFlow.prity = 1;
            }
            else
            {
                objEntityWrkFlow.prity = 0;
            }

            int CnclSts = 0;
            DataTable dt = objBusinessWrkFlow.Readwrkflwdtls11(objEntityWrkFlow);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["WRKFLW_CNCL_USR_ID"].ToString() != "")
                {
                    CnclSts++;
                }
            }

            List<clsEntityApprovalHierarchyTemp> objEntityWrkFlowUPDATEList = new List<clsEntityApprovalHierarchyTemp>();

            List<clsEntityApprovalHierarchyTemp> objEntityWrkFlowDELETEList = new List<clsEntityApprovalHierarchyTemp>();

            List<clsEntityApprovalHierarchyTemp> objEntityWrkFlowMainINSERTList = new List<clsEntityApprovalHierarchyTemp>();
            List<clsEntityApprovalHierarchyTemp> objEntityWrkFlowSubINSERTList = new List<clsEntityApprovalHierarchyTemp>();

            //Hierarchy changed
            if (hiddenHrchyChngdMode.Value == "1")
            {
                string jsonData = HiddenFieldMainData.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string i = h.Replace("}\",", "},");

                List<clsTVData> objDataMainList = new List<clsTVData>();
                objDataMainList = JsonConvert.DeserializeObject<List<clsTVData>>(i);

                if (HiddenFieldMainData.Value != "" && HiddenFieldMainData.Value != null)
                {
                    foreach (clsTVData objData in objDataMainList)
                    {
                        clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
                        if (objData.EMPID != "-Select-" && objData.DESGID != "-Select-" && objData.PERIOD != "")
                        {
                            if (objData.DTLID != "" && objData.DTLID != null && objData.DTLID != "null")
                            {
                                objEntityDetails.TempDtlId = Convert.ToInt32(objData.DTLID);//HrchyId
                            }
                            if (objData.PARENT != "")
                            {
                                objEntityDetails.ParentId = Convert.ToInt32(objData.PARENT);//HrchyId
                            }
                            objEntityDetails.Level = Convert.ToInt32(objData.LEVEL);
                            objEntityDetails.DesgId = Convert.ToInt32(objData.DESGID);
                            objEntityDetails.EmployeeId = Convert.ToInt32(objData.EMPID);
                            objEntityDetails.ThresholdPeriodMode = Convert.ToInt32(objData.THRESMODE);
                            objEntityDetails.ThresholdPeriodDays = Convert.ToInt32(objData.PERIOD);
                            objEntityDetails.MajorityAprvSts = Convert.ToInt32(objData.APPRVMANSTS);
                            objEntityDetails.SubstituteEmpSts = Convert.ToInt32(objData.SUBEMPSTS);
                            objEntityDetails.AprvPendingSts = Convert.ToInt32(objData.APPRVPENSTS);
                            objEntityDetails.TtExceededSts = Convert.ToInt32(objData.TTCSTS);
                            objEntityDetails.SmsSts = Convert.ToInt32(objData.SMSSTS);
                            objEntityDetails.SystemSts = Convert.ToInt32(objData.SYSSTS);

                            objEntityWrkFlowMainINSERTList.Add(objEntityDetails);
                        }
                    }
                }

                string jsonData1 = HiddenFieldSubData.Value;
                string c1 = jsonData1.Replace("\"{", "\\{");
                string d1 = c1.Replace("\\n", "\r\n");
                string g1 = d1.Replace("\\", "");
                string h1 = g1.Replace("}\"]", "}]");
                string i1 = h1.Replace("}\",", "},");

                List<clsTVData> objDataSubList = new List<clsTVData>();
                objDataSubList = JsonConvert.DeserializeObject<List<clsTVData>>(i1);

                if (HiddenFieldSubData.Value != "" && HiddenFieldSubData.Value != null)
                {
                    foreach (clsTVData objData in objDataSubList)
                    {
                        clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
                        if (objData.EMPID != "-Select-" && objData.DESGID != "-Select-" && objData.PERIOD != "")
                        {
                            if (objData.DTLID != "" && objData.DTLID != null && objData.DTLID != "null")
                            {
                                objEntityDetails.TempDtlId = Convert.ToInt32(objData.DTLID);//HrchyId
                            }
                            if (objData.PARENT != "")
                            {
                                objEntityDetails.ParentId = Convert.ToInt32(objData.PARENT);//HrchyId
                            }
                            objEntityDetails.Level = Convert.ToInt32(objData.LEVEL);
                            objEntityDetails.DesgId = Convert.ToInt32(objData.DESGID);
                            objEntityDetails.EmployeeId = Convert.ToInt32(objData.EMPID);
                            objEntityDetails.ThresholdPeriodMode = Convert.ToInt32(objData.THRESMODE);
                            objEntityDetails.ThresholdPeriodDays = Convert.ToInt32(objData.PERIOD);
                            objEntityDetails.MajorityAprvSts = Convert.ToInt32(objData.APPRVMANSTS);
                            objEntityDetails.SubstituteEmpSts = Convert.ToInt32(objData.SUBEMPSTS);
                            objEntityDetails.AprvPendingSts = Convert.ToInt32(objData.APPRVPENSTS);
                            objEntityDetails.TtExceededSts = Convert.ToInt32(objData.TTCSTS);
                            objEntityDetails.SmsSts = Convert.ToInt32(objData.SMSSTS);
                            objEntityDetails.SystemSts = Convert.ToInt32(objData.SYSSTS);

                            objEntityWrkFlowSubINSERTList.Add(objEntityDetails);
                        }
                    }
                }
            }
            else
            {

                string jsonData = HiddenFieldMainData.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string i = h.Replace("}\",", "},");

                List<clsTVData> objDataMainList = new List<clsTVData>();
                objDataMainList = JsonConvert.DeserializeObject<List<clsTVData>>(i);

                if (HiddenFieldMainData.Value != "" && HiddenFieldMainData.Value != null)
                {
                    foreach (clsTVData objData in objDataMainList)
                    {
                        clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
                        if (objData.EMPID != "-Select-" && objData.DESGID != "-Select-" && objData.PERIOD != "")
                        {
                            objEntityDetails.DtlId = Convert.ToInt32(objData.DTLID);//WrkflowDtlId
                            if (objData.PARENT != "")
                            {
                                objEntityDetails.ParentId = Convert.ToInt32(objData.PARENT);//WrkflowDtlId
                            }
                            objEntityDetails.Level = Convert.ToInt32(objData.LEVEL);
                            objEntityDetails.DesgId = Convert.ToInt32(objData.DESGID);
                            objEntityDetails.EmployeeId = Convert.ToInt32(objData.EMPID);
                            objEntityDetails.ThresholdPeriodMode = Convert.ToInt32(objData.THRESMODE);
                            objEntityDetails.ThresholdPeriodDays = Convert.ToInt32(objData.PERIOD);
                            objEntityDetails.MajorityAprvSts = Convert.ToInt32(objData.APPRVMANSTS);
                            objEntityDetails.SubstituteEmpSts = Convert.ToInt32(objData.SUBEMPSTS);
                            objEntityDetails.AprvPendingSts = Convert.ToInt32(objData.APPRVPENSTS);
                            objEntityDetails.TtExceededSts = Convert.ToInt32(objData.TTCSTS);
                            objEntityDetails.SmsSts = Convert.ToInt32(objData.SMSSTS);
                            objEntityDetails.SystemSts = Convert.ToInt32(objData.SYSSTS);

                            objEntityWrkFlowUPDATEList.Add(objEntityDetails);
                        }
                    }
                }

                string jsonData1 = HiddenFieldSubData.Value;
                string c1 = jsonData1.Replace("\"{", "\\{");
                string d1 = c1.Replace("\\n", "\r\n");
                string g1 = d1.Replace("\\", "");
                string h1 = g1.Replace("}\"]", "}]");
                string i1 = h1.Replace("}\",", "},");

                List<clsTVData> objDataSubList = new List<clsTVData>();
                objDataSubList = JsonConvert.DeserializeObject<List<clsTVData>>(i1);

                if (HiddenFieldSubData.Value != "" && HiddenFieldSubData.Value != null)
                {
                    foreach (clsTVData objData in objDataSubList)
                    {
                        clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
                        if (objData.EMPID != "-Select-" && objData.DESGID != "-Select-" && objData.PERIOD != "")
                        {
                            if (objData.DTLID != "" && objData.DTLID != null && objData.DTLID != "null")
                            {
                                objEntityDetails.DtlId = Convert.ToInt32(objData.DTLID);//WrkflowDtlId
                            }
                            if (objData.PARENT != "")
                            {
                                objEntityDetails.ParentId = Convert.ToInt32(objData.PARENT);//WrkflowDtlId
                            }
                            objEntityDetails.Level = Convert.ToInt32(objData.LEVEL);
                            objEntityDetails.DesgId = Convert.ToInt32(objData.DESGID);
                            objEntityDetails.EmployeeId = Convert.ToInt32(objData.EMPID);
                            objEntityDetails.ThresholdPeriodMode = Convert.ToInt32(objData.THRESMODE);
                            objEntityDetails.ThresholdPeriodDays = Convert.ToInt32(objData.PERIOD);
                            objEntityDetails.MajorityAprvSts = Convert.ToInt32(objData.APPRVMANSTS);
                            objEntityDetails.SubstituteEmpSts = Convert.ToInt32(objData.SUBEMPSTS);
                            objEntityDetails.AprvPendingSts = Convert.ToInt32(objData.APPRVPENSTS);
                            objEntityDetails.TtExceededSts = Convert.ToInt32(objData.TTCSTS);
                            objEntityDetails.SmsSts = Convert.ToInt32(objData.SMSSTS);
                            objEntityDetails.SystemSts = Convert.ToInt32(objData.SYSSTS);

                            objEntityWrkFlowUPDATEList.Add(objEntityDetails);
                        }
                    }
                }

                if (hiddenMainCanclDbId.Value != "" && hiddenMainCanclDbId.Value != null)
                {
                    foreach (string strDtlId in hiddenMainCanclDbId.Value.Split(','))
                    {
                        if (strDtlId != "" && strDtlId != null)
                        {
                            clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
                            objEntityDetails.DtlId = Convert.ToInt32(strDtlId);

                            DataTable dtLower = objBusinessWrkFlow.ReadLowerHierarchyIds(objEntityDetails);
                            if (dtLower.Rows.Count > 0)
                            {
                                for (int intCount = 0; intCount < dtLower.Rows.Count; intCount++)
                                {
                                    clsEntityApprovalHierarchyTemp objEntity = new clsEntityApprovalHierarchyTemp();
                                    objEntity.DtlId = Convert.ToInt32(dtLower.Rows[intCount]["WRKFLW_DTL_ID"].ToString());
                                    objEntityWrkFlowDELETEList.Add(objEntity);
                                }
                            }

                        }
                    }
                }

                if (hiddenSubCanclDbId.Value != "" && hiddenSubCanclDbId.Value != null)
                {
                    foreach (string strDtlId in hiddenSubCanclDbId.Value.Split(','))
                    {
                        if (strDtlId != "" && strDtlId != null)
                        {
                            clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
                            objEntityDetails.DtlId = Convert.ToInt32(strDtlId);

                            DataTable dtLower = objBusinessWrkFlow.ReadLowerHierarchyIds(objEntityDetails);
                            if (dtLower.Rows.Count > 0)
                            {
                                for (int intCount = 0; intCount < dtLower.Rows.Count; intCount++)
                                {
                                    clsEntityApprovalHierarchyTemp objEntity = new clsEntityApprovalHierarchyTemp();
                                    objEntity.DtlId = Convert.ToInt32(dtLower.Rows[intCount]["WRKFLW_DTL_ID"].ToString());
                                    objEntityWrkFlowDELETEList.Add(objEntity);
                                }
                            }

                        }
                    }
                }
            }

            objEntityWrkFlow.ConfirmSts = 0;

            if (CnclSts == 0)
            {
                //objBusinessWrkFlow.UpdateDocumentWorkflow(objEntityWrkFlow, objEntityWrkFlowUPDATEList, objEntityWrkFlowDELETEList, objEntityWrkFlowMainINSERTList, objEntityWrkFlowSubINSERTList);


                if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateFloat")
                {
                    Response.Redirect("gen_Document_Workflow.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseFloat")
                {
                    Response.Redirect("gen_Document_Workflow_List.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnReUpdate")
                {
                    Response.Redirect("gen_Document_Workflow_List.aspx?InsUpd=Upd");
                }
            }
            else
            {
                Response.Redirect("gen_Document_Workflow_List.aspx?InsUpd=AlrdyCncl");
            }
        }

        catch (Exception ex)
        {
        }
    }

}

