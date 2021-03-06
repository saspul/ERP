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

[System.Web.Script.Services.ScriptService]
public partial class Master_gen_Document_Replace_approval_gen_Document_Replace_approval : System.Web.UI.Page
{



    protected void Page_Load(object sender, EventArgs e)
    {

        clsBusinessLayerPMS objEntitybuspms = new clsBusinessLayerPMS();
      
        if (!IsPostBack)
        {
            this.lstDiv.Attributes.Add("disabled", "");
            this.lstDpt.Attributes.Add("disabled", "");
            Read_Document();
            Read_Departments();
            Read_Divisions();
            Read_hrchyname();
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0;
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
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Approval_Hierarchy_Template);
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
                    }
                }
            }
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                //DisableAllControls(Page);
                DisableAllControls(Page);

                btnUpdate.Visible = true;
                btnUpdateFloat.Visible = true;
              
                HiddenFieldAprvlHierarchyId.Value = strId;
                HiddenwrkflwId.Value = strId;
                WRKFLW(strId, 0);



            }
            else
            {
                string strId = Session["ID"].ToString();
                //Msgbox(strId);
                DisableAllControls(Page);

                btnUpdate.Visible = true;
                btnUpdateFloat.Visible = true;

                HiddenFieldAprvlHierarchyId.Value = strId;
                HiddenwrkflwId.Value = strId;
                WRKFLW(strId, 0);

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
            }
        }

    }
        
       
    
    private void DisableAllControls(Control Page)
    {
        foreach (Control ctrl in Page.Controls)
        {
            if (ctrl is TextBox) ((TextBox)(ctrl)).Enabled = false;
            //else if (ctrl is Button) ((Button)(ctrl)).Enabled = false;
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
    public static string checkDup(string orgID, string corptID, string Id, string Name)
    {
        string arr = "";
        try
        {
            clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
            clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
            objentityPassport.Corporate_id = Convert.ToInt32(corptID);
            objentityPassport.Organisation_id = Convert.ToInt32(orgID);
            objentityPassport.TempId = Convert.ToInt32(Id);
            objentityPassport.Name = Name;
            DataTable dtSubConrt = objBussinesspasprt.CheckDupName(objentityPassport);
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
        public string DTLID { get; set; }
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
        public int ROWID { get; set; }
    }
    public void WRKFLW(string id, int mode)
    {
        clsBusinessLayerPMS objEntitybuspms = new clsBusinessLayerPMS();
        clsEntityApprovalHierarchyTemp objentityPass1 = new clsEntityApprovalHierarchyTemp();
        clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
        //if (Request.QueryString["Id"] == null)
        //{
        //    objentityPass1.Name = Session["name"].ToString();
        //}
        //else
        //{
        //    objentityPass1.Name = id;
        //}
        //DataTable dts = buspms1.Readwrkflwdid1(objentityPass1);
        objentityPass1.TempId = Convert.ToInt32(id);
        DataTable dt = objEntitybuspms.Readwrkflwdtls11(objentityPass1);
        DataTable dts = objEntitybuspms.Readwrkflwdid1(objentityPass1);

        if (dt.Rows.Count > 0)
        {

            HiddenWrkname.Value = dt.Rows[0]["WRKFLW_NAME"].ToString();
            txtName.Text = dt.Rows[0]["WRKFLW_NAME"].ToString();
            docsection.SelectedItem.Text = dt.Rows[0]["DOC_ID"].ToString();
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

            dlHrchy.SelectedItem.Value = dt.Rows[0]["HRCHY_ID"].ToString();
            dlHrchy.SelectedItem.Text = dt.Rows[0]["HRCHY_NAME"].ToString();

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

                //DataTable dt1 = objEntitybuspms.selectdep(objentityPass1);
                //for (int i = 0; i < dt1.Rows.Count; i++)
                //{
                //    string sd = dt1.Rows[i][0].ToString();
                for (int j = 0; j < lstDpt.Items.Count; j++)

                    if (word == lstDpt.Items[j].Value)
                    {

                        lstDpt.Items[j].Selected = true;
                    }
                //    }
            }
            string div = dt.Rows[0]["WRKFLW_CPRDIV_IDS"].ToString();
            string[] words1 = div.Split(',');
            //Msgbox(div);
            foreach (string word1 in words1)
            {

                objentityPass1.div = word1;

                DataTable dt2 = objEntitybuspms.selectdiv(objentityPass1);

                //for (int i = 0; i < dt2.Rows.Count; i++)
                //{

                //    string sd1 = dt2.Rows[i][0].ToString();

                for (int j = 0; j < lstDiv.Items.Count; j++)
                {
                    if (word1 == lstDiv.Items[j].Value)
                    {
                        //Msgbox(sd1);
                        lstDiv.Items[j].Selected = true;
                    }
                }
                //}
            }
            dte_1_a.Value = dt.Rows[0]["WRKFLW_STRTDATE"].ToString();
            dte_1.Value = dt.Rows[0]["WRKFLW_ENDDATE"].ToString();

         
            if (Request.QueryString["Id"] != null)
            {
                //string strId = dts.Rows[0]["WRKFLW_ID"].ToString();
                HiddenwrkflwId.Value = id;
                Update1(id, 0);

            }
            else
            {
                string strId = Session["ID"].ToString();
                HiddenwrkflwId.Value = Session["ID"].ToString();
                Update1(strId, 0);
            }
        }
    }
    public void Update1(string id, int mode)
    {

        HiddenFieldwrkId.Value = id;
        clsEntityApprovalHierarchyTemp objentityPass = new clsEntityApprovalHierarchyTemp();
        clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
        //Msgbox(id.ToString());
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
            //if (dt.Rows[0]["HRCHY_MAJORITY_APRVL"].ToString() == "0")
            //{
            //    cbxMajorityApr.Checked = false;
            //}
            //else
            //{
            //    cbxMajorityApr.Checked = true;
            //}
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
            for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
            {

                DataRow drDtl = dtDetail.NewRow();
                drDtl["DTLID"] = dt.Rows[intCount]["WRKFLW_DTL_ID"].ToString();
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
                dtDetail.Rows.Add(drDtl);

                objstr.Append("<li>");
                objstr.Append("<span><i class=\"fa fa-black-tie\"></i>" + dt.Rows[intCount]["USR_NAME"].ToString() + "</span>");
                objstr.Append("<button onclick=\"return FuctionOrganize1('" + dt.Rows[intCount]["WRKFLW_DTL_ID"].ToString() + "','" + dt.Rows[intCount]["WRKFLW_LEVEL"].ToString() + "','" + dt.Rows[intCount]["USR_NAME"].ToString() + "');\" class=\"edt_1 tablinks notv\"><i class=\"fa fa-edit\"></i></button>");
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
                objstr.Append("<li>");
                objstr.Append("<span><i class=\"fa fa-black-tie\"></i>" + dt.Rows[intCount]["USR_NAME"].ToString() + "</span>");
                objstr.Append("<button onclick=\"return FuctionOrganize1('" + dt.Rows[intCount]["WRKFLW_DTL_ID"].ToString() + "','" + dt.Rows[intCount]["WRKFLW_LEVEL"].ToString() + "','" + dt.Rows[intCount]["USR_NAME"].ToString() + "');\" class=\"edt_1 tablinks notv\"><i class=\"fa fa-edit\"></i></button>");
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
                drDtl["DTLID"] = dt.Rows[intCount]["WRKFLW_DTL_ID"].ToString();
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
        docsection.Items.Insert(0, "--Select--");




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
        ////string a = doc.Rows[0][0].ToString();
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
        
    }

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

            List<clsEntityApprovalHierarchyTemp> objEntityWrkFlowUPDATEList = new List<clsEntityApprovalHierarchyTemp>();

            List<clsEntityApprovalHierarchyTemp> objEntityWrkFlowDELETEList = new List<clsEntityApprovalHierarchyTemp>();

            List<clsEntityApprovalHierarchyTemp> objEntityWrkFlowMainINSERTList = new List<clsEntityApprovalHierarchyTemp>();
            List<clsEntityApprovalHierarchyTemp> objEntityWrkFlowSubINSERTList = new List<clsEntityApprovalHierarchyTemp>();

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

            objEntityWrkFlow.ReplaceApprvrSts = 1;

            //objBusinessWrkFlow.UpdateDocumentWorkflow(objEntityWrkFlow, objEntityWrkFlowUPDATEList, objEntityWrkFlowDELETEList, objEntityWrkFlowMainINSERTList, objEntityWrkFlowSubINSERTList);

            if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateFloat")
            {
                Response.Redirect("gen_Document_Replace_approval.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Upd");
            }
            else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseFloat")
            {
                Response.Redirect("gen_Document_Workflow_List.aspx?InsUpd=Upd");
            }
        }
        catch (Exception ex)
        {
        }
    }

}