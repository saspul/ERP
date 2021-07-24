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
using System.Net;
using System.Globalization;


public partial class Master_gen_approval_set_gen_approval_set : System.Web.UI.Page
{

    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Request.QueryString["VId"] != null)
        {
            this.MasterPageFile = "~/MasterPage/MasterPageCompzitModal.master";
        }
        else
        {
            this.MasterPageFile = "~/MasterPage/MasterPageCompzit.master";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            this.txt_Name.Focus();

            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableConfirm = 0, intEnableReopne = 0;
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
            int intCorpId = 0;

            int corpid = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                corpid = intCorpId;
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            int orgid = 0;
            if (Session["ORGID"] == null)
            {
                orgid = Convert.ToInt32(Session["ORGID"].ToString());
                Response.Redirect("/Default.aspx");
            }

            Read_Document();
            Read_condlist();

            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Approval_Set);
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
                        HiddenFieldReopen.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intEnableReopne = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
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
            }

            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnsave.Visible = false;
                btnsaveclose.Visible = false;
                btnUpdate.Visible = true;
                btnUpdateClose.Visible = true;
                btnupdate2.Visible = true;
                btnupdateclose2.Visible = true;
                btnClear.Visible = false;
                btnclear2.Visible = false;
                btnCnfrm1.Visible = true;
                btncnfrm2.Visible = true;
                btnReopen.Visible = false;
                btnreopen2.Visible = false;

                if (intEnableConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    // Msgbox(intEnableConfirm.ToString());
                }
                else
                {
                    btnCnfrm1.Visible = false;
                    btncnfrm2.Visible = false;
                }
                Update(strId, 0);
                HiddenFieldView.Value = "1";
                HiddenCnfm.Value = "0";
                HiddenApprovalId.Value = strId;
                lblEntry.Text = "Edit Approval Set";

                clsEntityApprovalHierarchyTemp objentityPass1 = new clsEntityApprovalHierarchyTemp();
                clsBusinessLayerApprovalset objEntityApproval = new clsBusinessLayerApprovalset();
                objentityPass1.TempId = Convert.ToInt32(strId);

                DataTable dt = objEntityApproval.ReadApproval(objentityPass1);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["APRVLSET_CONFRM_STS"].ToString() == "1")
                    {
                        // DisableAllControls(Page);
                        txt_Name.Attributes.Add("disabled", "disabled");
                        txtdescr.Disabled = true;
                        docsection.Enabled = false;

                        btnReopen.Visible = true;
                        btnCancel.Visible = true;
                        btnAdd.Visible = false;
                        btnAddClose.Visible = false;
                        btnUpdate.Visible = false;
                        btnUpdateClose.Visible = false;
                        btnClear.Visible = false;
                        btnCnfrm1.Visible = false;
                        btnreopen2.Visible = true;
                        btncancel2.Visible = true;
                        btnsave.Visible = false;
                        btnsaveclose.Visible = false;
                        btnupdate2.Visible = false;
                        btnupdateclose2.Visible = false;
                        btnclear2.Visible = false;
                        btncnfrm2.Visible = false;

                        if (intEnableReopne == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {

                        }
                        else
                        {
                            btnReopen.Visible = false;
                            btnreopen2.Visible = false;
                        }

                        DataTable dt3 = objEntityApproval.ReadApprovalAss(objentityPass1);
                        if (dt3.Rows.Count > 0)
                        {
                            btnReopen.Visible = false;
                            btnreopen2.Visible = false;
                        }
                        else
                        {
                            btnReopen.Visible = true;
                            btnreopen2.Visible = true;
                        }
                        HiddenFieldView.Value = "1";
                        HiddenCnfm.Value = "1";
                        HiddenApprovalId.Value = strId;
                        lblEntry.Text = "View Approval Set";
                    }
                }
            }
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                txt_Name.Attributes.Add("disabled", "disabled");
                txtdescr.Disabled = true;
                docsection.Enabled = false;

                btnCancel.Visible = true;
                btncancel2.Visible = true;
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnsave.Visible = false;
                btnsaveclose.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnupdate2.Visible = false;
                btnupdateclose2.Visible = false;
                btnClear.Visible = false;
                btnclear2.Visible = false;
                btnCnfrm1.Visible = false;
                btncnfrm2.Visible = false;
                btnReopen.Visible = false;
                btnreopen2.Visible = false;

                Update(strId, 0);
                HiddenFieldView.Value = "1";
                HiddenApprovalId.Value = strId;
                HiddenCnfm.Value = "1";
                lblEntry.Text = "View Approval Set";
            }
            else
            {
                lblEntry.Text = "Add Approval Set";
                Update1(0);
            }

            if (Request.QueryString["VId"] != null)
            {
                divList.Visible = false;
                OlSection.Visible = false;
                btnreopen2.Visible = false;
                btnReopen.Visible = false;
                hiddenPopupSts.Value = Request.QueryString["VId"].ToString();
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
            }
        }
    }
    [WebMethod]
    public static string checkDup(string orgID, string corptID,  string Name)
    {
        string arr = "";
        try
        {
            clsEntityApprovalHierarchyTemp objentityPass1 = new clsEntityApprovalHierarchyTemp();
            clsBusinessLayerApprovalset objEntityApproval = new clsBusinessLayerApprovalset();
            objentityPass1.Organisation_id =Convert.ToInt32(orgID);
            objentityPass1.Corporate_id =Convert.ToInt32(corptID);
            objentityPass1.Name = Name;
            DataTable dtSubConrt = objEntityApproval.Readappwname(objentityPass1);

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
    public void Read_Document()
    {
        clsBusinessLayerPMS objEntitybuspms = new clsBusinessLayerPMS();

        DataTable doc = objEntitybuspms.Read_Document();
        docsection.Items.Clear();
        docsection.DataSource = doc;
        docsection.DataValueField = "DOC_ID";
        docsection.DataTextField = "DOC_NAME";
        docsection.DataBind();
        docsection.Items.Insert(0, new ListItem("--Select--","0"));
      
    }

    public void Read_condlist()
    {
        clsBusinessLayerApprovalset objEntityApproval = new clsBusinessLayerApprovalset();
        clsEntityApprovalHierarchyTemp objentityPass = new clsEntityApprovalHierarchyTemp();

        if (Session["CORPOFFICEID"] != null)
        {
            objentityPass.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
      
            objentityPass.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataSet doc = objEntityApproval.ReadProcedurecnd(objentityPass);
        
        lstproductcat.Items.Clear();
        lstproductcat.DataSource = doc.Tables[0];
        lstproductcat.DataValueField = "CTGRY_ID";
        lstproductcat.DataTextField = "CTGRY_NAME";
        lstproductcat.DataBind();

        lstproduct.Items.Clear();
        lstproduct.DataSource = doc.Tables[1];
        lstproduct.DataValueField = "PRDT_ID";
        lstproduct.DataTextField = "PRDT_NAME";
        lstproduct.DataBind();

        lstdept.Items.Clear();
        lstdept.DataSource = doc.Tables[2];
        lstdept.DataValueField = "CPRDEPT_ID";
        lstdept.DataTextField = "CPRDEPT_NAME";
        lstdept.DataBind();

        lstdivision.Items.Clear();
        lstdivision.DataSource = doc.Tables[3];
        lstdivision.DataValueField = "CPRDIV_ID";
        lstdivision.DataTextField = "CPRDIV_NAME";
        lstdivision.DataBind();
    }

    [WebMethod]
    public static string Loadcndtype(string ddlcond)
    {
        string arr = "";
        try
        {
            clsEntityApprovalHierarchyTemp objentityPass = new clsEntityApprovalHierarchyTemp();
            clsBusinessLayerApprovalset objEntityApproval = new clsBusinessLayerApprovalset();
            objentityPass.Cond = Convert.ToInt32(ddlcond);
            DataTable dt = objEntityApproval.LoadAppConditionType(objentityPass);
            StringBuilder objstr = new StringBuilder();

            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("TYPEID", typeof(string));
            dtDetail.Columns.Add("TYPENAME", typeof(string));
            for (int intRowCount = 0; intRowCount < dt.Rows.Count; intRowCount++)
            {
                DataRow drDtl = dtDetail.NewRow();
                drDtl["TYPEID"] = dt.Rows[intRowCount]["CNDTN_TYPE_ID"].ToString();
                drDtl["TYPENAME"] = dt.Rows[intRowCount]["CNDTN_TYPE_NAME"].ToString();
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

    public class clsTVData
    {
        public string DL { get; set; }
        public string DTLID { get; set; }
        public string COND { get; set; }
        public string TYPE { get; set; }
        public string MAX { get; set; }
        public string MIN { get; set; }
        public string LST { get; set; }
        public string TYPENAME { get; set; }
        public string TYPEID { get; set; }
        public string TYNAME { get; set; }
    }

    public void Update1(int mode)
    {
        if (docsection.SelectedItem.Value != "0" && docsection.SelectedItem.Value != "--Select--" && docsection.SelectedItem.Value != "")
        {
            divConditions.Visible = true;

            HiddenEditlist.Value = "0";

            StringBuilder objstr = new StringBuilder();

            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("COND", typeof(string));
            dtDetail.Columns.Add("TYPE", typeof(string));
            dtDetail.Columns.Add("MAX", typeof(string));
            dtDetail.Columns.Add("MIN", typeof(string));
            dtDetail.Columns.Add("DTLID", typeof(string));
            dtDetail.Columns.Add("DL", typeof(string));
            ddltype.Items.Clear();

            for (int count = 0; count < ddlcond.Items.Count; count++)
            {
                DataRow drDtl = dtDetail.NewRow();
                drDtl["COND"] = ddlcond.Items[count].Value;
                drDtl["MAX"] = "";
                drDtl["MIN"] = "";
                drDtl["DTLID"] = "";
                drDtl["DL"] = "";
                dtDetail.Rows.Add(drDtl);
            }

            string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
            HiddenEdit.Value = strJson;

            ScriptManager.RegisterStartupScript(this, GetType(), "LoadDatas", "LoadDatas('" + strJson + "');", true);
        }
        else
        {
            divConditions.Visible = false;
        }
    }

    public void Update(string id, int mode)
    {
        divConditions.Visible = true;

        clsEntityApprovalHierarchyTemp objentityPass1 = new clsEntityApprovalHierarchyTemp();
        clsBusinessLayerApprovalset objEntityApproval = new clsBusinessLayerApprovalset();

        objentityPass1.TempId = Convert.ToInt32(id);

        DataTable dt = objEntityApproval.ReadApproval(objentityPass1);
        if (dt.Rows.Count > 0)
        {
            txt_Name.Value = dt.Rows[0]["APRVLSET_NAME"].ToString();
            txtdescr.Value = dt.Rows[0]["APRVLSET_DESCRIPTN"].ToString();
            docsection.SelectedValue = dt.Rows[0]["DOC_ID"].ToString();
        }
        HiddenEditlist.Value = "1";

        StringBuilder objstr = new StringBuilder();

        clsEntityApprovalHierarchyTemp objentityPass = new clsEntityApprovalHierarchyTemp();
        objentityPass.DesgId = Convert.ToInt32(docsection.SelectedItem.Value);

        DataTable doc = objEntityApproval.LoadAppCondition(objentityPass);
        ddlcond.Items.Clear();
        ddlcond.DataSource = doc;
        ddlcond.DataValueField = "CNDTN_ID";
        ddlcond.DataTextField = "CNDTN_NAME";
        ddlcond.DataBind();

        DataTable dtDetail = new DataTable();
        dtDetail.Columns.Add("COND", typeof(string));
        dtDetail.Columns.Add("TYPE", typeof(string));
        dtDetail.Columns.Add("TYNAME", typeof(string));
        dtDetail.Columns.Add("MIN", typeof(string));
        dtDetail.Columns.Add("MAX", typeof(string));
        dtDetail.Columns.Add("DTLID", typeof(string));
        dtDetail.Columns.Add("DL", typeof(string));
        for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
        {
            DataRow drDtl = dtDetail.NewRow();

            drDtl["COND"] = dt.Rows[intCount]["CNDTN_ID"].ToString();
            drDtl["TYPE"] = dt.Rows[intCount]["CNDTN_TYPE_ID"].ToString();
            drDtl["TYNAME"] = dt.Rows[intCount]["CNDTN_TYPE_NAME"].ToString();
            drDtl["DTLID"] = dt.Rows[intCount]["APRVLSET_DTL_ID"].ToString();
            drDtl["DL"] = dt.Rows[intCount]["APRVLSET_DTLVAL_ID"].ToString();
            if (dt.Rows[intCount]["CNDTN_ID"].ToString() == "1")
            {
                drDtl["MIN"] = dt.Rows[intCount]["APRVLSET_DTL_MINVAL"].ToString();
                drDtl["MAX"] = dt.Rows[intCount]["APRVLSET_DTL_MAXVAL"].ToString();
            }

            if (dt.Rows[intCount]["CNDTN_ID"].ToString() == "2")
            {
                string div = dt.Rows[intCount]["APRVLSET_DTL_VALUES"].ToString();
                string[] words1 = div.Split(',');
                foreach (string word1 in words1)
                {
                    lstproductcat.SelectedValue = word1;
                    lstprc.Items.Add(lstproductcat.Items[lstproductcat.SelectedIndex]);
                    lstproductcat.Items.Remove(lstproductcat.Items[lstproductcat.SelectedIndex]);
                }
            }
            if (dt.Rows[intCount]["CNDTN_ID"].ToString() == "3")
            {
                string div = dt.Rows[intCount]["APRVLSET_DTL_VALUES"].ToString();
                string[] words1 = div.Split(',');
                foreach (string word1 in words1)
                {
                    lstproduct.SelectedValue = word1;
                    lstpr.Items.Add(lstproduct.Items[lstproduct.SelectedIndex]);
                    lstproduct.Items.Remove(lstproduct.Items[lstproduct.SelectedIndex]);
                }
            }
            if (dt.Rows[intCount]["CNDTN_ID"].ToString() == "4")
            {
                string div = dt.Rows[intCount]["APRVLSET_DTL_VALUES"].ToString();
                string[] words1 = div.Split(',');
                foreach (string word1 in words1)
                {
                    lstdept.SelectedValue = word1;
                    lstdp.Items.Add(lstdept.Items[lstdept.SelectedIndex]);
                    lstdept.Items.Remove(lstdept.Items[lstdept.SelectedIndex]);
                }
            }
            if (dt.Rows[intCount]["CNDTN_ID"].ToString() == "5")
            {
                string div = dt.Rows[intCount]["APRVLSET_DTL_VALUES"].ToString();
                string[] words1 = div.Split(',');
                foreach (string word1 in words1)
                {
                    lstdivision.SelectedValue = word1;
                    lstdiv.Items.Add(lstdivision.Items[lstdivision.SelectedIndex]);
                    lstdivision.Items.Remove(lstdivision.Items[lstdivision.SelectedIndex]);
                }
            }
            dtDetail.Rows.Add(drDtl);

            objstr.Append("<li>");
            objstr.Append("<li>");
        }
        string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
        HiddenEdit.Value = strJson;
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
    public void Msgbox(String s)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('" + s + "');", true);
    }


    protected void lstproductcat_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
            clsEntityApprovalHierarchyTemp objentityPass = new clsEntityApprovalHierarchyTemp();
            clsBusinessLayerApprovalset objEntityApproval = new clsBusinessLayerApprovalset();
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
            objentityPass.Name = txt_Name.Value.Trim();
            objentityPass.descr = txtdescr.Value;
            objentityPass.DesgId = Convert.ToInt32(docsection.SelectedItem.Value);

            DateTime dd = DateTime.Parse(DateTime.Now.ToShortDateString());
            string dat = dd.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
            if (dat.Trim() != "")
            {
                objentityPass.cDate = objCommon.textToDateTime(dat.Trim());
            }

            List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsList = new List<clsEntityApprovalHierarchyTemp>();
            string jsonData = HiddenFieldMainData.Value;
            string c = jsonData.Replace("\"{", "\\{");
            string d = c.Replace("\\n", "\r\n");
            string g = d.Replace("\\", "");
            string h = g.Replace("}\"]", "}]");
            string i = h.Replace("}\",", "},");
            List<clsTVData> objTVDataList5 = new List<clsTVData>();
            objTVDataList5 = JsonConvert.DeserializeObject<List<clsTVData>>(i);

            if (HiddenFieldMainData.Value != "" && HiddenFieldMainData.Value != null)
            {
                foreach (clsTVData objclsTVData in objTVDataList5)
                {
                    clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();

                    objEntityDetails.Cond = Convert.ToInt32(objclsTVData.COND);
                    objEntityDetails.type = Convert.ToInt32(objclsTVData.TYPE);
                    objEntityTrficVioltnDetilsList.Add(objEntityDetails);
                }
                objEntityTrficVioltnDetilsList.Reverse();

                List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltn = new List<clsEntityApprovalHierarchyTemp>();
                string jsonData1 = HiddenFieldSubData.Value;
                string c1 = jsonData1.Replace("\"{", "\\{");
                string d1 = c1.Replace("\\n", "\r\n");
                string g1 = d1.Replace("\\", "");
                string h1 = g1.Replace("}\"]", "}]");
                string i1 = h1.Replace("}\",", "},");
                List<clsTVData> objTVDataList51 = new List<clsTVData>();
                objTVDataList51 = JsonConvert.DeserializeObject<List<clsTVData>>(i1);

                if (HiddenFieldSubData.Value != "" && HiddenFieldSubData.Value != null)
                {
                    foreach (clsTVData objclsTVData in objTVDataList51)
                    {
                        clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();

                        objEntityDetails.Max = Convert.ToDouble(objclsTVData.MAX);
                        objEntityDetails.Min = Convert.ToDouble(objclsTVData.MIN);
                        objEntityDetails.Dep = objclsTVData.LST;
                        objEntityDetails.Cond = Convert.ToInt32(objclsTVData.COND);
                        objEntityTrficVioltn.Add(objEntityDetails);
                    }

                    objEntityTrficVioltn.Reverse();
                }

                objEntityApproval.insertApprovalSet(objentityPass, objEntityTrficVioltnDetilsList, objEntityTrficVioltn);

                HiddenFieldSubData.Value = "";

                if (clickedButton.ID == "btnAdd")
                {
                    Response.Redirect("gen_approval_set.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnsave")
                {
                    Response.Redirect("gen_approval_set.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnAddClose")
                {
                    Response.Redirect("gen_approval_set_list.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnsaveclose")
                {
                    Response.Redirect("gen_approval_set_list.aspx?InsUpd=Ins");
                }
                else
                {
                }
            }

        }
        catch (Exception ex)
        {
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
            clsEntityApprovalHierarchyTemp objentityPass = new clsEntityApprovalHierarchyTemp();
            clsBusinessLayerApprovalset objEntityApproval = new clsBusinessLayerApprovalset();

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
            objentityPass.TempId = Convert.ToInt32(HiddenApprovalId.Value);
            objentityPass.Name = txt_Name.Value.Trim();
            objentityPass.descr = txtdescr.Value;
            objentityPass.DesgId = Convert.ToInt32(docsection.SelectedItem.Value);

            List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsList = new List<clsEntityApprovalHierarchyTemp>();
            string jsonData = HiddenFieldMainData.Value;
            string c = jsonData.Replace("\"{", "\\{");
            string d = c.Replace("\\n", "\r\n");
            string g = d.Replace("\\", "");
            string h = g.Replace("}\"]", "}]");
            string i = h.Replace("}\",", "},");
            List<clsTVData> objTVDataList5 = new List<clsTVData>();
            objTVDataList5 = JsonConvert.DeserializeObject<List<clsTVData>>(i);

            if (HiddenFieldMainData.Value != "" && HiddenFieldMainData.Value != null)
            {
                foreach (clsTVData objclsTVData in objTVDataList5)
                {
                    clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
                    objEntityDetails.DesgId = 0;
                    if (objclsTVData.DTLID != "" && objclsTVData.DTLID != "null" && objclsTVData.DTLID != null && objclsTVData.DTLID != "undefined")
                    {
                        objEntityDetails.DesgId = Convert.ToInt32(objclsTVData.DTLID);
                    }
                    objEntityDetails.TempId = Convert.ToInt32(HiddenApprovalId.Value);
                    objEntityDetails.Cond = Convert.ToInt32(objclsTVData.COND);
                    objEntityDetails.type = Convert.ToInt32(objclsTVData.TYPE);
                    objEntityTrficVioltnDetilsList.Add(objEntityDetails);
                }

                objEntityTrficVioltnDetilsList.Reverse();

                List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltn = new List<clsEntityApprovalHierarchyTemp>();
                List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDele = new List<clsEntityApprovalHierarchyTemp>();
                string jsonData1 = HiddenFieldSubData.Value;
                string c1 = jsonData1.Replace("\"{", "\\{");
                string d1 = c1.Replace("\\n", "\r\n");
                string g1 = d1.Replace("\\", "");
                string h1 = g1.Replace("}\"]", "}]");
                string i1 = h1.Replace("}\",", "},");
                List<clsTVData> objTVDataList51 = new List<clsTVData>();
                objTVDataList51 = JsonConvert.DeserializeObject<List<clsTVData>>(i1);

                if (HiddenFieldSubData.Value != "" && HiddenFieldSubData.Value != null)
                {
                    foreach (clsTVData objclsTVData in objTVDataList51)
                    {
                        clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
                        objEntityDetails.TempId = 0;
                        if (objclsTVData.DL != "" && objclsTVData.DL != "null" && objclsTVData.DL != null && objclsTVData.DTLID != "undefined")
                        {
                            objEntityDetails.TempId = Convert.ToInt32(objclsTVData.DL);
                        }
                        objEntityDetails.DesgId = 0;
                        if (objclsTVData.DTLID != "" && objclsTVData.DTLID != "null" && objclsTVData.DTLID != null && objclsTVData.DTLID != "undefined")
                        {
                            objEntityDetails.DesgId = Convert.ToInt32(objclsTVData.DTLID);
                        }
                        objEntityDetails.Max = Convert.ToDouble(objclsTVData.MAX);
                        objEntityDetails.Min = Convert.ToDouble(objclsTVData.MIN);
                        objEntityDetails.Dep = objclsTVData.LST;
                        objEntityDetails.Cond = Convert.ToInt32(objclsTVData.COND);
                        objEntityTrficVioltn.Add(objEntityDetails);
                    }

                    objEntityTrficVioltn.Reverse();
                    string strCanclDtlId1 = "";
                    string strCanclDtlId = "";
                    string[] strarrCancldtlIdsGrp1 = strCanclDtlId1.Split(',');
                    string[] strarrCancldtlIdsGrp2 = strCanclDtlId.Split(',');
                    if (hiddenMainCanclDbId.Value != "" && hiddenMainCanclDbId.Value != null && HiddenMaincanceldl.Value != "" && HiddenMaincanceldl.Value != null)
                    {
                        strCanclDtlId1 = hiddenMainCanclDbId.Value;
                        strCanclDtlId = HiddenMaincanceldl.Value;
                        strarrCancldtlIdsGrp1 = strCanclDtlId1.Split(',');
                        strarrCancldtlIdsGrp2 = strCanclDtlId.Split(',');
                    }
                    foreach (string strDtlId in strarrCancldtlIdsGrp1)
                    {
                        foreach (string strDtlId1 in strarrCancldtlIdsGrp2)
                        {
                            if (strDtlId != "" && strDtlId != null)
                            {
                                if (strDtlId1 != "" && strDtlId1 != null)
                                {
                                    int intDtlId1 = Convert.ToInt32(strDtlId);
                                    clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
                                    objEntityDetails.TempId = Convert.ToInt32(strDtlId);
                                    objEntityDetails.DesgId = Convert.ToInt32(strDtlId);
                                    objEntityTrficVioltnDele.Add(objEntityDetails);
                                }
                            }
                        }
                    }
                }

                    int Cncl = 0;
                    DataTable dt = objEntityApproval.ReadApproval(objentityPass);
                    if (dt.Rows.Count > 0 && dt.Rows[0]["APRVLSET_CNCL_USR_ID"].ToString() != "")
                    {
                        Cncl++;
                    }

                    if (Cncl == 0)
                    {
                        objEntityApproval.UpdateApprovalSet(objentityPass, objEntityTrficVioltnDetilsList, objEntityTrficVioltn, objEntityTrficVioltnDele);

                        HiddenFieldSubData.Value = "";

                        if (clickedButton.ID == "btnUpdate")
                        {
                            Response.Redirect("gen_approval_set.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Upd");
                        }
                        else if (clickedButton.ID == "btnUpdateClose")
                        {
                            Response.Redirect("gen_approval_set_List.aspx?InsUpd=Upd");
                        }
                        else if (clickedButton.ID == "btnupdate2")
                        {
                            Response.Redirect("gen_approval_set.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Upd");
                        }
                        else if (clickedButton.ID == "btnupdateclose2")
                        {
                            Response.Redirect("gen_approval_set_List.aspx?InsUpd=Upd");
                        }
                    }
                    else
                    {
                        Response.Redirect("gen_approval_set_List.aspx?InsUpd=AlCancl");
                    }

            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnCnfrm_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
            clsEntityApprovalHierarchyTemp objentityPass = new clsEntityApprovalHierarchyTemp();
            clsBusinessLayerApprovalset objEntityApproval = new clsBusinessLayerApprovalset();

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
            objentityPass.TempId = Convert.ToInt32(HiddenApprovalId.Value);
            objentityPass.Name = txt_Name.Value.Trim();
            objentityPass.descr = txtdescr.Value;
            objentityPass.DesgId = Convert.ToInt32(docsection.SelectedItem.Value);

            List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsList = new List<clsEntityApprovalHierarchyTemp>();
            string jsonData = HiddenFieldMainData.Value;
            string c = jsonData.Replace("\"{", "\\{");
            string d = c.Replace("\\n", "\r\n");
            string g = d.Replace("\\", "");
            string h = g.Replace("}\"]", "}]");
            string i = h.Replace("}\",", "},");
            List<clsTVData> objTVDataList5 = new List<clsTVData>();
            objTVDataList5 = JsonConvert.DeserializeObject<List<clsTVData>>(i);

            if (HiddenFieldMainData.Value != "" && HiddenFieldMainData.Value != null)
            {
                foreach (clsTVData objclsTVData in objTVDataList5)
                {
                    clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
                    objEntityDetails.DesgId = 0;
                    if (objclsTVData.DTLID != "" && objclsTVData.DTLID != "null" && objclsTVData.DTLID != null && objclsTVData.DTLID != "undefined")
                    {
                        objEntityDetails.DesgId = Convert.ToInt32(objclsTVData.DTLID);
                    }
                    objEntityDetails.TempId = Convert.ToInt32(HiddenApprovalId.Value);
                    objEntityDetails.Cond = Convert.ToInt32(objclsTVData.COND);
                    objEntityDetails.type = Convert.ToInt32(objclsTVData.TYPE);
                    objEntityTrficVioltnDetilsList.Add(objEntityDetails);
                }

                objEntityTrficVioltnDetilsList.Reverse();

                List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltn = new List<clsEntityApprovalHierarchyTemp>();
                List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDele = new List<clsEntityApprovalHierarchyTemp>();
                string jsonData1 = HiddenFieldSubData.Value;
                string c1 = jsonData1.Replace("\"{", "\\{");
                string d1 = c1.Replace("\\n", "\r\n");
                string g1 = d1.Replace("\\", "");
                string h1 = g1.Replace("}\"]", "}]");
                string i1 = h1.Replace("}\",", "},");
                List<clsTVData> objTVDataList51 = new List<clsTVData>();
                objTVDataList51 = JsonConvert.DeserializeObject<List<clsTVData>>(i1);

                if (HiddenFieldSubData.Value != "" && HiddenFieldSubData.Value != null)
                {
                    foreach (clsTVData objclsTVData in objTVDataList51)
                    {
                        clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
                        objEntityDetails.TempId = 0;
                        if (objclsTVData.DL != "" && objclsTVData.DL != "null" && objclsTVData.DL != null && objclsTVData.DTLID != "undefined")
                        {
                            objEntityDetails.TempId = Convert.ToInt32(objclsTVData.DL);
                        }
                        objEntityDetails.DesgId = 0;
                        if (objclsTVData.DTLID != "" && objclsTVData.DTLID != "null" && objclsTVData.DTLID != null && objclsTVData.DTLID != "undefined")
                        {
                            objEntityDetails.DesgId = Convert.ToInt32(objclsTVData.DTLID);
                        }
                        objEntityDetails.Max = Convert.ToDouble(objclsTVData.MAX);
                        objEntityDetails.Min = Convert.ToDouble(objclsTVData.MIN);
                        objEntityDetails.Dep = objclsTVData.LST;
                        objEntityDetails.Cond = Convert.ToInt32(objclsTVData.COND);
                        objEntityTrficVioltn.Add(objEntityDetails);
                    }

                    objEntityTrficVioltn.Reverse();

                    string strCanclDtlId1 = "";
                    string strCanclDtlId = "";
                    string[] strarrCancldtlIdsGrp1 = strCanclDtlId1.Split(',');
                    string[] strarrCancldtlIdsGrp2 = strCanclDtlId.Split(',');

                    if (hiddenMainCanclDbId.Value != "" && hiddenMainCanclDbId.Value != null && HiddenMaincanceldl.Value != "" && HiddenMaincanceldl.Value != null)
                    {
                        strCanclDtlId1 = hiddenMainCanclDbId.Value;
                        strCanclDtlId = HiddenMaincanceldl.Value;
                        strarrCancldtlIdsGrp1 = strCanclDtlId1.Split(',');
                        strarrCancldtlIdsGrp2 = strCanclDtlId.Split(',');
                    }
                    foreach (string strDtlId in strarrCancldtlIdsGrp1)
                    {
                        foreach (string strDtlId1 in strarrCancldtlIdsGrp2)
                        {
                            if (strDtlId != "" && strDtlId != null)
                            {
                                if (strDtlId1 != "" && strDtlId1 != null)
                                {
                                    int intDtlId1 = Convert.ToInt32(strDtlId);
                                    clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
                                    objEntityDetails.TempId = Convert.ToInt32(strDtlId);
                                    objEntityDetails.DesgId = Convert.ToInt32(strDtlId);
                                    objEntityTrficVioltnDele.Add(objEntityDetails);
                                }
                            }
                        }
                    }
                }

                int Cncl = 0;
                DataTable dt = objEntityApproval.ReadApproval(objentityPass);
                if (dt.Rows.Count > 0 && dt.Rows[0]["APRVLSET_CNCL_USR_ID"].ToString() != "")
                {
                    Cncl++;
                }

                if (Cncl == 0)
                {

                    objEntityApproval.updateApprovalSetconfrm(objentityPass, objEntityTrficVioltnDetilsList, objEntityTrficVioltn, objEntityTrficVioltnDele);

                    HiddenFieldSubData.Value = "";

                    if (clickedButton.ID == "btnCnfrm")
                    {
                        Response.Redirect("gen_approval_set_list.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Cnfm");
                    }
                    else if (clickedButton.ID == "btncnfrm2")
                    {
                        Response.Redirect("gen_approval_set_list.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Cnfm");
                    }
                }
                else
                {
                    Response.Redirect("gen_approval_set_List.aspx?InsUpd=AlCancl");
                }

            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnReopen_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;

            clsCommonLibrary objCommon = new clsCommonLibrary();

            clsEntityApprovalHierarchyTemp objentityPass = new clsEntityApprovalHierarchyTemp();
            clsBusinessLayerApprovalset objEntityApproval = new clsBusinessLayerApprovalset();

            if (Session["CORPOFFICEID"] != null)
            {
                objentityPass.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objentityPass.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objentityPass.User_Id = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            objentityPass.TempId = Convert.ToInt32(HiddenApprovalId.Value);
            objEntityApproval.ReopenApprovalset(objentityPass);

            if (clickedButton.ID == "btnReopen3")
            {
                Response.Redirect("gen_approval_set.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Reopen");
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void docsection_SelectedIndexChanged(object sender, EventArgs e)
    {
        clsBusinessLayerApprovalset objEntityApproval = new clsBusinessLayerApprovalset();
        clsEntityApprovalHierarchyTemp objentityPass = new clsEntityApprovalHierarchyTemp();
        objentityPass.DesgId = Convert.ToInt32(docsection.SelectedItem.Value);
        DataTable doc = objEntityApproval.LoadAppCondition(objentityPass);
        //Msgbox(docsection.SelectedItem.Value);
        ddlcond.Items.Clear();
        ddlcond.DataSource = doc;
        ddlcond.DataValueField = "CNDTN_ID";
        ddlcond.DataTextField = "CNDTN_NAME";
        ddlcond.DataBind();

        Update1(0);
    }

   

    
}