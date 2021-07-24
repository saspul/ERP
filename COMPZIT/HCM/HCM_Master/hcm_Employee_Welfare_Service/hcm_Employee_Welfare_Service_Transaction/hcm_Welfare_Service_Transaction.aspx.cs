using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Collections;
using System.Web.Script.Serialization;
using System.Web.Services;

public partial class HCM_HCM_Master_hcm_Employee_Welfare_Service_hcm_Employee_Welfare_Service_Transaction_hcm_Welfare_Service_Transaction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {

            Corp_DivisionLoad();
            DesignationLoad();
            DepartmentLoad();
            ServiceLoad();

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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Emp_Welfare_Service_Master_Trans);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            HiddenEnableModify.Value = "0";
            HiddenEnableConfirm.Value = "0";
            HiddenEnableAdd.Value = "0";
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intEnableAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenEnableAdd.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenEnableModify.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        HiddenEnableConfirm.Value = "1"; 
                    }
                }
            }

            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId);
                lblEntry.InnerText = "Edit Employee Welfare Service Transaction";
                btnSave.Visible = false;
                btnSaveClose.Visible = false;
                btnSearch.Visible = false;
                if (HiddenEnableConfirm.Value == "0")
                {
                    btnConfirm.Visible = false;
                }
            }

            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId);
                lblEntry.InnerText = "View Employee Welfare Service Transaction";
                btnSave.Visible = false;
                btnSaveClose.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnConfirm.Visible = false;
                btnSearch.Visible = false;
            }

            else
            {
                lblEntry.InnerText = "Add Welfare Service Transaction";
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnConfirm.Visible = false;
                divButtons.Visible = false;
                ddlDesignation.Focus();
                StringBuilder sb = new StringBuilder();
                sb.Append("<div class=\"col-lg-12 table-responsive\" style=\"background-color:#FFF;padding-top:14px;clear:both;\">");
                sb.Append("<table id=\"tableMain\" class=\"table table-bordered table-responsive\" style=\"font-size:13px;margin-bottom: 14px;\">");
                sb.Append("<thead><tr><th>Employee name</th><th colspan=\"8\">Employee code</th></tr></thead>");
                sb.Append("<tbody>");         
                sb.Append("<tr>");
                sb.Append("<td colspan=\"2\" style=\"padding:0;\">No data available</td>");
                sb.Append("</tr>");          
                sb.Append("</tbody>");
                sb.Append("</table>");
                sb.Append("</div>");      
                divEmployeeTable.InnerHtml = sb.ToString();
                ddlDesignation.Focus();
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
                else if (strInsUpd == "Con")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdationConfirm", "SuccessUpdationConfirm();", true);
                }
            }
        }
       
    }
    public void ServiceLoad()
    {
        clsEntityWelfareServiceTransaction objentityPassport = new clsEntityWelfareServiceTransaction();
        clsBusinessWelfareServiceTransaction objBussinesspasprt = new clsBusinessWelfareServiceTransaction();

        if (Session["CORPOFFICEID"] != null)
        {
            objentityPassport.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objentityPassport.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objentityPassport.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtEmployee = objBussinesspasprt.ReadServiceSearch(objentityPassport);

        ddlService.Items.Clear();

        if (dtEmployee.Rows.Count > 0)
        {
            ddlService.DataSource = dtEmployee;
            ddlService.DataTextField = "WLFRSRVC_NAME";
            ddlService.DataValueField = "WLFRSRVC_ID";
            ddlService.DataBind();
        }

        ddlService.Items.Insert(0, "--SELECT SERVICE--");

    }
   
    public void Corp_DivisionLoad()
    {
        ClsEntity_Passport_Handover_Sts objentityPassport = new ClsEntity_Passport_Handover_Sts();
        ClsBussiness_Passport_Handover_Sts objBussinesspasprt = new ClsBussiness_Passport_Handover_Sts();

        if (Session["CORPOFFICEID"] != null)
        {
            objentityPassport.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objentityPassport.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objentityPassport.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBussinesspasprt.ReadDivision(objentityPassport);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlDivision.DataSource = dtSubConrt;
            ddlDivision.DataTextField = "CPRDIV_NAME";
            ddlDivision.DataValueField = "CPRDIV_ID";
            ddlDivision.DataBind();
        }

        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");

    }
    public void DesignationLoad()
    {
        ClsEntity_Passport_Handover_Sts objentityPassport = new ClsEntity_Passport_Handover_Sts();
        ClsBussiness_Passport_Handover_Sts objBussinesspasprt = new ClsBussiness_Passport_Handover_Sts();

        if (Session["CORPOFFICEID"] != null)
        {
            objentityPassport.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objentityPassport.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objentityPassport.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBussinesspasprt.ReadDesignation(objentityPassport);

        if (dtSubConrt.Rows.Count > 0)
        {

            ddlDesignation.DataSource = dtSubConrt;
            ddlDesignation.DataTextField = "DSGN_NAME";
            ddlDesignation.DataValueField = "DSGN_ID";
            ddlDesignation.DataBind();

        }
        ddlDesignation.Items.Insert(0, "--SELECT DESIGNATION--");

    }
    public void DepartmentLoad()
    {
        ClsEntity_Passport_Handover_Sts objentityPassport = new ClsEntity_Passport_Handover_Sts();
        ClsBussiness_Passport_Handover_Sts objBussinesspasprt = new ClsBussiness_Passport_Handover_Sts();

        if (Session["CORPOFFICEID"] != null)
        {
            objentityPassport.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objentityPassport.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objentityPassport.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBussinesspasprt.ReadDepartment(objentityPassport);

        if (dtSubConrt.Rows.Count > 0)
        {

            ddlDepartment.DataSource = dtSubConrt;
            ddlDepartment.DataTextField = "CPRDEPT_NAME";
            ddlDepartment.DataValueField = "CPRDEPT_ID";
            ddlDepartment.DataBind();

        }
        ddlDepartment.Items.Insert(0, "--SELECT DEPARTMENT--");
    }


    public void Employee_load()
    {
        clsEntityWelfareServiceTransaction objentityPassport = new clsEntityWelfareServiceTransaction();
        clsBusinessWelfareServiceTransaction objBussinesspasprt = new clsBusinessWelfareServiceTransaction();

        if (Session["CORPOFFICEID"] != null)
        {
            objentityPassport.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objentityPassport.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objentityPassport.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
        {
            objentityPassport.division = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        }
        else
        {
            objentityPassport.division = 0;
        }

        if (ddlDesignation.SelectedItem.Value != "--SELECT DESIGNATION--")
        {
            objentityPassport.designation = Convert.ToInt32(ddlDesignation.SelectedItem.Value);
        }
        else
        {
            objentityPassport.designation = 0;
        }
        if (ddlDepartment.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objentityPassport.department = Convert.ToInt32(ddlDepartment.SelectedItem.Value);
        }
        else
        {
            objentityPassport.department = 0;
        }
        if (radioCustType1.Checked == true)
        {
            objentityPassport.EmployeeType = 1;
        }
       

        DataTable dtEmployee = objBussinesspasprt.ReadEmployeeDDL(objentityPassport);

        ddlEmployee.Items.Clear();

        if (dtEmployee.Rows.Count > 0)
        {
            ddlEmployee.DataSource = dtEmployee;
            ddlEmployee.DataTextField = "USR_NAME";
            ddlEmployee.DataValueField = "USR_ID";
            ddlEmployee.DataBind();
        }

        ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");     
    }

    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        Employee_load();
        ddlDivision.Focus();
        HiddenFieldFocus.Value = "div";
    }
    protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        Employee_load();
        ddlDesignation.Focus();
        HiddenFieldFocus.Value = "des";
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        int flag = 0;
        try
        {
            clsEntityWelfareServiceTransaction objentityPassport = new clsEntityWelfareServiceTransaction();
            clsBusinessWelfareServiceTransaction objBussinesspasprt = new clsBusinessWelfareServiceTransaction();
            if (Session["CORPOFFICEID"] != null)
            {
                objentityPassport.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objentityPassport.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objentityPassport.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
            {
                objentityPassport.division = Convert.ToInt32(ddlDivision.SelectedItem.Value);
            }
            else
            {
                objentityPassport.division = 0;
            }

            if (ddlDesignation.SelectedItem.Value != "--SELECT DESIGNATION--")
            {
                objentityPassport.designation = Convert.ToInt32(ddlDesignation.SelectedItem.Value);
            }
            else
            {
                objentityPassport.designation = 0;
            }
            if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
            {
                objentityPassport.employee = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
            }
            else
            {
                objentityPassport.employee = 0;
            }
            if (ddlDepartment.SelectedItem.Value != "--SELECT DEPARTMENT--")
            {
                objentityPassport.department = Convert.ToInt32(ddlDepartment.SelectedItem.Value);
            }
            else
            {
                objentityPassport.department = 0;
            }
            if (radioCustType1.Checked == true)
            {
                objentityPassport.EmployeeType = 1;
            }
           

            string MainService = "";
            if (ddlService.SelectedItem.Value != "--SELECT SERVICE--")
            {
                MainService = ddlService.SelectedItem.Value;
            }
            if (ddlService.SelectedItem.Value != "--SELECT SERVICE--")
            {
                objentityPassport.ServiceDateId = Convert.ToInt32(ddlService.SelectedItem.Value);
            }
            else
            {
                objentityPassport.ServiceDateId = 0;
            }
            HiddenFieldDesg.Value = Convert.ToString(objentityPassport.designation);
            HiddenFieldDept.Value = Convert.ToString(objentityPassport.department);
            HiddenFieldDiv.Value = Convert.ToString(objentityPassport.division);
            HiddenFieldType.Value = Convert.ToString(objentityPassport.EmployeeType);
            HiddenFieldEmp.Value = Convert.ToString(objentityPassport.employee);
            HiddenFieldServ.Value = Convert.ToString(objentityPassport.ServiceDateId);




            DataTable dtEmployee = objBussinesspasprt.ReadEmployeeTableList(objentityPassport);
            sb.Append("<div class=\"col-lg-12 table-responsive\" style=\"background-color:#FFF;padding-top:14px;clear:both;\">");
            if (dtEmployee.Rows.Count > 0)
            {
                sb.Append("<input type=\"text\" id=\"myInput\" onkeyup=\"myFunction()\" onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" placeholder=\"Search employees..\" />");
            }
            sb.Append("<table id=\"tableMain\" class=\"table table-bordered table-responsive\" style=\"font-size:13px;margin-bottom: 14px;\">");
            sb.Append("<thead><tr><th>Employee name</th><th colspan=\"8\">Employee code</th></tr></thead>");
            sb.Append("<tbody>");
            for (int intcnt = 0; intcnt < dtEmployee.Rows.Count; intcnt++)
            {
                string EmpName = dtEmployee.Rows[intcnt]["USR_NAME"].ToString();
                string EmpId = dtEmployee.Rows[intcnt]["USR_ID"].ToString();
                string EmpCode = dtEmployee.Rows[intcnt]["USR_CODE"].ToString();
                string DsgnId = dtEmployee.Rows[intcnt]["DSGN_ID"].ToString();

                clsEntityWelfareServiceTransaction objentityPassport1 = new clsEntityWelfareServiceTransaction();
                objentityPassport1.employee = Convert.ToInt32(EmpId);
                objentityPassport1.designation = Convert.ToInt32(DsgnId);
                DataTable dtServiceCtgry = objBussinesspasprt.ReadEmpServiceCtgry(objentityPassport1);
                if (dtServiceCtgry.Rows.Count > 0)
                {
                    sb.Append("<tr>");
                    sb.Append("<td style=\"display:none;\">" + EmpId + "</td>");
                    sb.Append("<td style=\"width:12%;\">" + EmpName + "</td>");
                    sb.Append("<td style=\"width:10%;\">" + EmpCode + "</td>");
                    sb.Append("<td id=\"DsgnId" + EmpId + "\" style=\"display:none;\">" + DsgnId + "</td>");
                    sb.Append("<td style=\"width:78%;\" colspan=\"8\" style=\"padding:0;\">");
                    sb.Append("<table id=\"tableEmp" + EmpId + "\" class=\"table table-bordered\" style=\"font-size:13px;background-color: #f6f6f6;margin-bottom: 0px;\">");
                    sb.Append("<tr>");
                    sb.Append("<td>Service</td><td>Date</td><td>Availability</td><td>Limit</td> <td>Allotted</td> <td>Remaining</td> <td colspan=\"2\">Allot</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr id=\"empRow" + EmpId + "1\">");
                    sb.Append("<td style=\"display:none;\">" + EmpId + "1</td>");
                    sb.Append("<td id=\"Mandatory" + EmpId + "1\" style=\"display:none;\"></td>");
                    sb.Append("<td id=\"Freqncy" + EmpId + "1\" style=\"display:none;\"></td>");
                    sb.Append("<td id=\"ServiceDateId" + EmpId + "1\" style=\"display:none;\"></td>");
                    sb.Append("<td style=\"width:19%;\"> <select id=\"ddlService" + EmpId + "1\" onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" class=\"form-control\" onchange=\"return changeService(" + EmpId + ",1);\"> <option>-Select-</option>");
                    foreach (DataRow dr in dtServiceCtgry.Rows)
                    {
                        if (MainService == dr["WLFRSRVC_ID"].ToString())
                        {
                            sb.Append("<option selected value=\"" + dr["WLFRSRVC_ID"].ToString() + "\">" + dr["WLFRSRVC_NAME"].ToString() + "</option>");
                        }
                        else
                        {
                            sb.Append("<option value=\"" + dr["WLFRSRVC_ID"].ToString() + "\">" + dr["WLFRSRVC_NAME"].ToString() + "</option>");
                        }
                    }
                    sb.Append("</select></td>");
                    sb.Append("<td style=\"width:13%;\"><input id=\"AllotDate" + EmpId + "1\" maxlength=10 onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" onchange=\"return changeAllotDate(" + EmpId + ",1);\" type=\"text\" placeholder=\"dd-mm-yyyy\" class=\"form-control datepicker\" /></td>");
                    sb.Append("<td style=\"width:14%;\"><label id=\"availability" + EmpId + "1\"></label></td>");
                    sb.Append("<td style=\"width:12%;\" id=\"limit" + EmpId + "1\"></td>");
                    sb.Append("<td style=\"width:10%;\" id=\"allotted" + EmpId + "1\"></td>");
                    sb.Append("<td style=\"width:10%;\" id=\"remaining" + EmpId + "1\"></td> ");
                    sb.Append("<td style=\"width:12%;\"><input id=\"allot" + EmpId + "1\" maxlength=8 onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeAllotNum(" + EmpId + ",1);\" type=\"text\"  class=\"form-control\" /></td>");
                    sb.Append("<td style=\"width:10%;\"><button id=\"btnadd" + EmpId + "1\" style=\"width:100%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return addRow(" + EmpId + ",1," + DsgnId + ");\"><span class=\"glyphicon glyphicon-plus\"></span> Add </button><button id=\"btnDele" + EmpId + "1\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return deleRow(" + EmpId + ",1," + DsgnId + ");\"><span class=\"glyphicon glyphicon-trash\"></span> Delete </button></td>");
                    sb.Append("</tr>");
                    sb.Append("</table>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    flag++;
                }
            }
            if (dtEmployee.Rows.Count == 0 || flag==0)
            {
                divButtons.Visible = false;
                sb.Append("<tr>");
                sb.Append("<td colspan=\"2\" style=\"padding:0;\">No data available</td>");
                sb.Append("</tr>");
            }
            else
            {
                divButtons.Visible = true;
                sb.Append("<tr id=\"trLast\" style=\"display:none;\">");
                sb.Append("<td colspan=\"2\" style=\"padding:0;\">No data available</td>");
                sb.Append("</tr>");

            }
            sb.Append("</tbody>");
            sb.Append("</table>");
            sb.Append("</div>");
        }
        catch (Exception)
        {
        }
        divEmployeeTable.InnerHtml = sb.ToString();
        ScriptManager.RegisterStartupScript(this, GetType(), "radioChange", "radioChange();", true);
    }
    public class clsTVData
    {

        public string EMPID { get; set; }
        public string SERVID { get; set; }
        public string ALLOTDATE { get; set; }
        public string ALLOTNUM { get; set; }
        public string REMAIN { get; set; }
        public string TOTALLOT { get; set; }
        public string COLORSTS { get; set; }
        public string AVABLTY { get; set; }
        public string LIMIT { get; set; }
        public string SERVDATEID { get; set; }
    
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityWelfareServiceTransaction objentityPassport = new clsEntityWelfareServiceTransaction();
            clsBusinessWelfareServiceTransaction objBussinesspasprt = new clsBusinessWelfareServiceTransaction();
            if (Session["CORPOFFICEID"] != null)
            {
                objentityPassport.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objentityPassport.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objentityPassport.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

           
           objentityPassport.designation= Convert.ToInt32(HiddenFieldDesg.Value);
           objentityPassport.department=  Convert.ToInt32(HiddenFieldDept.Value);
           objentityPassport.division= Convert.ToInt32( HiddenFieldDiv.Value );
           objentityPassport.EmployeeType=  Convert.ToInt32(HiddenFieldType.Value);
           objentityPassport.employee=Convert.ToInt32( HiddenFieldEmp.Value);
           objentityPassport.ServiceDateId=Convert.ToInt32( HiddenFieldServ.Value);




            List<clsEntityWelfareServiceTransactionDtl> objEntityTrficVioltnDetilsList = new List<clsEntityWelfareServiceTransactionDtl>();
            string jsonData = HiddenFieldEmpServData.Value;
            string c = jsonData.Replace("\"{", "\\{");
            string d = c.Replace("\\n", "\r\n");
            string g = d.Replace("\\", "");
            string h = g.Replace("}\"]", "}]");
            string i = h.Replace("}\",", "},");
            List<clsTVData> objTVDataList5 = new List<clsTVData>();
            //   UserData  data
            objTVDataList5 = JsonConvert.DeserializeObject<List<clsTVData>>(i);
            if (HiddenFieldEmpServData.Value != "" && HiddenFieldEmpServData.Value != null)
            {
                foreach (clsTVData objclsTVData in objTVDataList5)
                {
                    clsEntityWelfareServiceTransactionDtl objEntityDetails = new clsEntityWelfareServiceTransactionDtl();

                    if (objclsTVData.SERVID != "" && objclsTVData.ALLOTDATE != "" && objclsTVData.ALLOTNUM != "")
                    {
                        objEntityDetails.EmployeeId = Convert.ToInt32(objclsTVData.EMPID);
                        objEntityDetails.ServiceId = Convert.ToInt32(objclsTVData.SERVID);
                        objEntityDetails.AllotedNum = Convert.ToDecimal(objclsTVData.ALLOTNUM);
                        objEntityDetails.AllotedDate = objCommon.textToDateTime(objclsTVData.ALLOTDATE);
                        if (objclsTVData.REMAIN != "")
                        {
                            objEntityDetails.RemainingNum = Convert.ToDecimal(objclsTVData.REMAIN);
                        }
                        if (objclsTVData.TOTALLOT != "")
                        {
                            objEntityDetails.TotalAllot = Convert.ToDecimal(objclsTVData.TOTALLOT);
                        }
                        objEntityDetails.ColorStatus = Convert.ToInt32(objclsTVData.COLORSTS);
                        objEntityDetails.Availability = objclsTVData.AVABLTY;
                        objEntityDetails.Limit = objclsTVData.LIMIT;
                        objEntityDetails.ServiceDateId = Convert.ToInt32(objclsTVData.SERVDATEID);
                        objEntityTrficVioltnDetilsList.Add(objEntityDetails);
                    }
                }
                objBussinesspasprt.insertServEmpData(objentityPassport, objEntityTrficVioltnDetilsList);
            }
            if (clickedButton.ID == "btnSave")
            {
                Response.Redirect("hcm_Welfare_Service_Transaction.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnSaveClose")
            {
                Response.Redirect("hcm_Welfare_Service_Transaction_List.aspx?InsUpd=Ins");
            }

        }
        catch(Exception ex){
        }
    }
    
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityWelfareServiceTransaction objentityPassport = new clsEntityWelfareServiceTransaction();
            clsBusinessWelfareServiceTransaction objBussinesspasprt = new clsBusinessWelfareServiceTransaction();
            if (Session["CORPOFFICEID"] != null)
            {
                objentityPassport.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objentityPassport.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objentityPassport.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                objentityPassport.ServiceId = Convert.ToInt32(strId);

                List<clsEntityWelfareServiceTransactionDtl> objEntityTrficVioltnDetilsList = new List<clsEntityWelfareServiceTransactionDtl>();
                string jsonData = HiddenFieldEmpServData.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string i = h.Replace("}\",", "},");
                List<clsTVData> objTVDataList5 = new List<clsTVData>();
                //   UserData  data
                objTVDataList5 = JsonConvert.DeserializeObject<List<clsTVData>>(i);
                if (HiddenFieldEmpServData.Value != "" && HiddenFieldEmpServData.Value != null)
                {
                    foreach (clsTVData objclsTVData in objTVDataList5)
                    {
                        clsEntityWelfareServiceTransactionDtl objEntityDetails = new clsEntityWelfareServiceTransactionDtl();

                        if (objclsTVData.SERVID != "" && objclsTVData.ALLOTDATE != "" && objclsTVData.ALLOTNUM != "")
                        {
                            objEntityDetails.EmployeeId = Convert.ToInt32(objclsTVData.EMPID);
                            objEntityDetails.ServiceId = Convert.ToInt32(objclsTVData.SERVID);
                            objEntityDetails.AllotedNum = Convert.ToDecimal(objclsTVData.ALLOTNUM);
                            objEntityDetails.AllotedDate = objCommon.textToDateTime(objclsTVData.ALLOTDATE);
                            if (objclsTVData.REMAIN != "")
                            {
                                objEntityDetails.RemainingNum = Convert.ToDecimal(objclsTVData.REMAIN);
                            }
                            if (objclsTVData.TOTALLOT != "")
                            {
                                objEntityDetails.TotalAllot = Convert.ToDecimal(objclsTVData.TOTALLOT);
                            }
                            objEntityDetails.ColorStatus = Convert.ToInt32(objclsTVData.COLORSTS);
                            objEntityDetails.Availability = objclsTVData.AVABLTY;
                            objEntityDetails.Limit = objclsTVData.LIMIT;
                            objEntityDetails.ServiceDateId = Convert.ToInt32(objclsTVData.SERVDATEID);
                            objEntityTrficVioltnDetilsList.Add(objEntityDetails);
                        }
                    }

                    DataTable dt = objBussinesspasprt.checkConfrmSts(objentityPassport);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            Response.Redirect("hcm_Welfare_Service_Transaction_List.aspx?InsUpd=ConfPrev");
                        }
                        if (dt.Rows[0][1].ToString() != "")
                        {
                        Response.Redirect("hcm_Welfare_Service_Transaction_List.aspx?InsUpd=ConfPrevDele");
                        }
                       
                    }


                    if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateClose")
                    {
                        objentityPassport.CancelStatus = 0;
                    }
                    else if (clickedButton.ID == "btnConfirm")
                    {
                        objentityPassport.CancelStatus = 1;                     
                    }

                    objBussinesspasprt.updateServEmpData(objentityPassport, objEntityTrficVioltnDetilsList);
                }

                if (clickedButton.ID == "btnUpdate")
                {
                    if (HiddenEnableAdd.Value == "1")
                    {
                        Response.Redirect("hcm_Welfare_Service_Transaction.aspx?InsUpd=Upd");
                    }
                    else
                    {
                        Response.Redirect("hcm_Welfare_Service_Transaction_List.aspx?InsUpd=Upd");
                    }
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("hcm_Welfare_Service_Transaction_List.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnConfirm")
                {
                    Response.Redirect("hcm_Welfare_Service_Transaction_List.aspx?InsUpd=Con");
                }

            }
        }
        catch(Exception ex){
        }
    }
    public void Update(string Id)
    {
        try
        {
            clsEntityWelfareServiceTransaction objentityPassport = new clsEntityWelfareServiceTransaction();
            clsBusinessWelfareServiceTransaction objBussinesspasprt = new clsBusinessWelfareServiceTransaction();
            if (Session["CORPOFFICEID"] != null)
            {
                objentityPassport.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objentityPassport.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objentityPassport.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            objentityPassport.ServiceId = Convert.ToInt32(Id);
            DataTable dtService = objBussinesspasprt.readServTransDtlById(objentityPassport);
            if (dtService.Rows.Count > 0)
            {

                if (dtService.Rows[0][2].ToString() != "")
                {
                    ddlDesignation.SelectedValue = dtService.Rows[0][2].ToString();
                    objentityPassport.designation = Convert.ToInt32(dtService.Rows[0][2].ToString());
                }
                if (dtService.Rows[0]["CPRDIV_ID"].ToString() != "")
                {
                    ddlDivision.SelectedValue = dtService.Rows[0]["CPRDIV_ID"].ToString();
                    objentityPassport.division = Convert.ToInt32(dtService.Rows[0]["CPRDIV_ID"].ToString());
                }
                if (dtService.Rows[0][3].ToString() != "")
                {
                    ddlEmployee.SelectedValue = dtService.Rows[0][3].ToString();
                    objentityPassport.employee = Convert.ToInt32(dtService.Rows[0][3].ToString());
                }
                if (dtService.Rows[0]["CPRDEPT_ID"].ToString() != "")
                {
                    ddlDepartment.SelectedValue = dtService.Rows[0]["CPRDEPT_ID"].ToString();
                    objentityPassport.department = Convert.ToInt32(dtService.Rows[0]["CPRDEPT_ID"].ToString());
                }
                if (dtService.Rows[0]["WLFRSRVC_ID"].ToString() != "")
                {
                    ddlService.SelectedValue = dtService.Rows[0]["WLFRSRVC_ID"].ToString();
                }
                if (dtService.Rows[0]["EMP_TYPE"].ToString() == "1")
                {
                    radioCustType1.Checked = true;
                    objentityPassport.EmployeeType = 1;
                }



                ddlDesignation.Enabled = false;
                ddlDivision.Enabled = false;
                ddlEmployee.Enabled = false;
                ddlDepartment.Enabled = false;
                ddlService.Enabled = false;
                radioCustType1.Disabled = true;
                radioCustType2.Disabled = true;
             
                //start:-For employee table

                StringBuilder sb = new StringBuilder();           
                DataTable dtEmployees = objBussinesspasprt.ReadEmployeeTableList(objentityPassport);
                sb.Append("<div class=\"col-lg-12 table-responsive\" style=\"background-color:#FFF;padding-top:14px;clear:both;\">");
                if (dtEmployees.Rows.Count > 0)
                {
                    sb.Append("<input type=\"text\" id=\"myInput\" onkeyup=\"myFunction()\" onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" placeholder=\"Search employees..\" />");
                }
                sb.Append("<table id=\"tableMain\" class=\"table table-bordered table-responsive\" style=\"font-size:13px;margin-bottom: 14px;\">");
                sb.Append("<thead><tr><th>Employee name</th><th colspan=\"8\">Employee code</th></tr></thead>");
                sb.Append("<tbody>");
                for (int intcnt = 0; intcnt < dtEmployees.Rows.Count; intcnt++)
                {
                     string EmpName = dtEmployees.Rows[intcnt]["USR_NAME"].ToString();
                     string EmpId = dtEmployees.Rows[intcnt]["USR_ID"].ToString();
                     string EmpCode = dtEmployees.Rows[intcnt]["USR_CODE"].ToString();
                     string DsgnId = dtEmployees.Rows[intcnt]["DSGN_ID"].ToString();

                     objentityPassport.UserId = Convert.ToInt32(EmpId);
                     DataTable dtEmployee = objBussinesspasprt.readEmpWiseData(objentityPassport);

                    clsEntityWelfareServiceTransaction objentityPassport1 = new clsEntityWelfareServiceTransaction();
                    objentityPassport1.employee = Convert.ToInt32(EmpId);
                    objentityPassport1.designation = Convert.ToInt32(DsgnId);
                    DataTable dtServiceCtgry = objBussinesspasprt.ReadEmpServiceCtgry(objentityPassport1);
                    //if (dtServiceCtgry.Rows.Count > 0)
                    //{
                        sb.Append("<tr>");
                        sb.Append("<td style=\"display:none;\">" + EmpId + "</td>");
                        sb.Append("<td style=\"width:12%;\">" + EmpName + "</td>");
                        sb.Append("<td style=\"width:10%;\">" + EmpCode + "</td>");
                        sb.Append("<td id=\"DsgnId" + EmpId + "\" style=\"display:none;\">" + DsgnId + "</td>");
                        sb.Append("<td style=\"width:78%;\" colspan=\"8\" style=\"padding:0;\">");
                        sb.Append("<table id=\"tableEmp" + EmpId + "\" class=\"table table-bordered\" style=\"font-size:13px;background-color: #f6f6f6;margin-bottom: 0px;\">");
                        sb.Append("<tr>");
                        sb.Append("<td>Service</td><td>Date</td><td>Availability</td><td>Limit</td> <td>Allotted</td> <td>Remaining</td> <td colspan=\"2\">Allot</td>");
                        sb.Append("</tr>");

                        
                        for (int i = 1; i <= dtEmployee.Rows.Count; i++)
                        {

                            string ServId = dtEmployee.Rows[i - 1]["WLFRSRVC_ID"].ToString();
                            string Allot = dtEmployee.Rows[i - 1]["WLFRSUBDTL_ALOT"].ToString();
                            string Remain = dtEmployee.Rows[i - 1]["WLFRSUBDTL_REMIN"].ToString();
                            string TotAllot = dtEmployee.Rows[i - 1]["WLFRSUBDTL_ALOT_TOTAL"].ToString();
                            DateTime dtFromDate = Convert.ToDateTime(dtEmployee.Rows[i - 1]["WLFRSUBDTL_DATE"].ToString());
                            string AllotDate = dtFromDate.ToString("dd-MM-yyyy");
                            string colorSts = dtEmployee.Rows[i - 1]["WLFRSUBDTL_COLOR_STS"].ToString();
                            string avalblty = dtEmployee.Rows[i - 1]["WLFRSUBDTL_AVALBLTY"].ToString();
                            string limit = dtEmployee.Rows[i - 1]["WLFRSUBDTL_LIMIT"].ToString();
                            string ServDateId = dtEmployee.Rows[i - 1]["WLFSRVCDTL_ID"].ToString();

                            string[] arrli = new string[10];
                            arrli = limit.Split('/');
                            limit = arrli[0] + "/<br>" + arrli[1];


                            string[] arr = new string[10];
                            arr = ReadServDtlDate(ServId, EmpId, AllotDate, DsgnId);
                            sb.Append("<tr id=\"empRow" + EmpId + i + "\">");
                            sb.Append("<td style=\"display:none;\">" + EmpId + i + "</td>");
                            sb.Append("<td id=\"Mandatory" + EmpId + i + "\" style=\"display:none;\">" + arr[2] + "</td>");
                            sb.Append("<td id=\"Freqncy" + EmpId + i + "\" style=\"display:none;\">" + arr[3] + "</td>");
                            sb.Append("<td id=\"ServiceDateId" + EmpId + i + "\" style=\"display:none;\">" + ServDateId + "</td>");
                            sb.Append("<td style=\"width:19%;\"> <select id=\"ddlService" + EmpId + i + "\" onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" class=\"form-control\" onchange=\"return changeService(" + EmpId + "," + i + ");\"> <option>-Select-</option>");
                            int flagS = 0;
                            foreach (DataRow dr in dtServiceCtgry.Rows)
                            {
                                if (ServId == dr["WLFRSRVC_ID"].ToString())
                                {
                                    sb.Append("<option selected value=\"" + dr["WLFRSRVC_ID"].ToString() + "\">" + dr["WLFRSRVC_NAME"].ToString() + "</option>");
                                    flagS = 1;
                                }
                                else
                                {
                                    sb.Append("<option value=\"" + dr["WLFRSRVC_ID"].ToString() + "\">" + dr["WLFRSRVC_NAME"].ToString() + "</option>");
                                }
                            }
                            if (flagS == 0)
                            {
                                sb.Append("<option selected value=\"" + ServId + "\">" + dtEmployee.Rows[i - 1]["WLFRSRVC_NAME"].ToString() + "</option>");
                            }

                            sb.Append("</select></td>");
                            sb.Append("<td style=\"width:13%;\"><input id=\"AllotDate" + EmpId + i + "\" maxlength=10 onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" onchange=\"return changeAllotDate(" + EmpId + "," + i + ");\" value=\"" + AllotDate + "\" type=\"text\" placeholder=\"dd-mm-yyyy\" class=\"form-control datepicker\" /></td>");
                            sb.Append("<td style=\"width:14%;\"><label id=\"availability" + EmpId + i + "\">" + avalblty + "</label></td>");
                            sb.Append("<td style=\"width:12%;\" id=\"limit" + EmpId + i + "\">" + limit + "</td>");
                            sb.Append("<td style=\"width:10%;\" id=\"allotted" + EmpId + i + "\">" + TotAllot + "</td>");
                            sb.Append("<td style=\"width:10%;\" id=\"remaining" + EmpId + i + "\">" + Remain + "</td> ");
                            if (colorSts == "0")
                            {
                                sb.Append("<td style=\"width:12%;\"><input id=\"allot" + EmpId + i + "\" maxlength=8 onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeAllotNum(" + EmpId + "," + i + ");\" value=\"" + Allot + "\" type=\"text\"  class=\"form-control\" /></td>");
                            }
                            else
                            {
                                sb.Append("<td style=\"width:12%;\"><input id=\"allot" + EmpId + i + "\" style=\"background-color:#fcb8b8;\" maxlength=8 onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeAllotNum(" + EmpId + "," + i + ");\" value=\"" + Allot + "\" type=\"text\"  class=\"form-control\" /></td>");
                            }
                            if (i == dtEmployee.Rows.Count)
                            {
                                sb.Append("<td style=\"width:10%;\"><button id=\"btnadd" + EmpId + i + "\" style=\"width:100%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return addRow(" + EmpId + "," + i + "," + DsgnId + ");\"><span class=\"glyphicon glyphicon-plus\"></span> Add </button><button id=\"btnDele" + EmpId + i + "\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return deleRow(" + EmpId + "," + i + "," + DsgnId + ");\"><span class=\"glyphicon glyphicon-trash\"></span> Delete </button></td>");
                            }
                            else
                            {
                                sb.Append("<td style=\"width:10%;\"><button disabled id=\"btnadd" + EmpId + i + "\" style=\"width:100%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return addRow(" + EmpId + "," + i + "," + DsgnId + ");\"><span class=\"glyphicon glyphicon-plus\"></span> Add </button><button id=\"btnDele" + EmpId + i + "\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return deleRow(" + EmpId + "," + i + "," + DsgnId + ");\"><span class=\"glyphicon glyphicon-trash\"></span> Delete </button></td>");
                            }
                            sb.Append("</tr>");
                        }

                        if (dtEmployee.Rows.Count == 0)
                        {
                            
                            sb.Append("<tr id=\"empRow" + EmpId + "1\">");
                            sb.Append("<td style=\"display:none;\">" + EmpId + "1</td>");
                            sb.Append("<td id=\"Mandatory" + EmpId + "1\" style=\"display:none;\"></td>");
                            sb.Append("<td id=\"Freqncy" + EmpId + "1\" style=\"display:none;\"></td>");
                            sb.Append("<td id=\"ServiceDateId" + EmpId + "1\" style=\"display:none;\"></td>");
                            sb.Append("<td style=\"width:19%;\"> <select id=\"ddlService" + EmpId + "1\" onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" class=\"form-control\" onchange=\"return changeService(" + EmpId + ",1);\"> <option>-Select-</option>");
                            foreach (DataRow dr in dtServiceCtgry.Rows)
                            {
                                sb.Append("<option value=\"" + dr["WLFRSRVC_ID"].ToString() + "\">" + dr["WLFRSRVC_NAME"].ToString() + "</option>");
                            }
                            sb.Append("</select></td>");
                            sb.Append("<td style=\"width:13%;\"><input id=\"AllotDate" + EmpId + "1\" maxlength=10 onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" onchange=\"return changeAllotDate(" + EmpId + ",1);\" type=\"text\" placeholder=\"dd-mm-yyyy\" class=\"form-control datepicker\" /></td>");
                            sb.Append("<td style=\"width:14%;\"><label id=\"availability" + EmpId + "1\"></label></td>");
                            sb.Append("<td style=\"width:12%;\" id=\"limit" + EmpId + "1\"></td>");
                            sb.Append("<td style=\"width:10%;\" id=\"allotted" + EmpId + "1\"></td>");
                            sb.Append("<td style=\"width:10%;\" id=\"remaining" + EmpId + "1\"></td> ");
                            sb.Append("<td style=\"width:12%;\"><input id=\"allot" + EmpId + "1\" maxlength=8 onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeAllotNum(" + EmpId + ",1);\" type=\"text\"  class=\"form-control\" /></td>");
                            sb.Append("<td style=\"width:10%;\"><button id=\"btnadd" + EmpId + "1\" style=\"width:100%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return addRow(" + EmpId + ",1," + DsgnId + ");\"><span class=\"glyphicon glyphicon-plus\"></span> Add </button><button id=\"btnDele" + EmpId + "1\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return deleRow(" + EmpId + ",1," + DsgnId + ");\"><span class=\"glyphicon glyphicon-trash\"></span> Delete </button></td>");
                            sb.Append("</tr>");
                        }

                        sb.Append("</table>");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                    //}
                }
                sb.Append("<tr id=\"trLast\" style=\"display:none;\">");
                sb.Append("<td colspan=\"2\" style=\"padding:0;\">No data available</td>");
                sb.Append("</tr>");

                sb.Append("</tbody>");
                sb.Append("</table>");
                sb.Append("</div>");

                divEmployeeTable.InnerHtml = sb.ToString();
                //end:-For employee table

            }
        }
        catch(Exception ex){
        }
    }
    public void View(string Id)
    {
        try
        {
            clsEntityWelfareServiceTransaction objentityPassport = new clsEntityWelfareServiceTransaction();
            clsBusinessWelfareServiceTransaction objBussinesspasprt = new clsBusinessWelfareServiceTransaction();
            if (Session["CORPOFFICEID"] != null)
            {
                objentityPassport.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objentityPassport.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objentityPassport.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            objentityPassport.ServiceId = Convert.ToInt32(Id);
            DataTable dtService = objBussinesspasprt.readServTransDtlById(objentityPassport);
            if (dtService.Rows.Count > 0)
            {

                if (dtService.Rows[0][2].ToString() != "")
                {
                    ddlDesignation.SelectedValue = dtService.Rows[0][2].ToString();
                    objentityPassport.designation = Convert.ToInt32(dtService.Rows[0][2].ToString());
                }
                if (dtService.Rows[0]["CPRDIV_ID"].ToString() != "")
                {
                    ddlDivision.SelectedValue = dtService.Rows[0]["CPRDIV_ID"].ToString();
                    objentityPassport.division = Convert.ToInt32(dtService.Rows[0]["CPRDIV_ID"].ToString());
                }
                if (dtService.Rows[0][3].ToString() != "")
                {
                    ddlEmployee.SelectedValue = dtService.Rows[0][3].ToString();
                    objentityPassport.employee = Convert.ToInt32(dtService.Rows[0][3].ToString());
                }
                if (dtService.Rows[0]["CPRDEPT_ID"].ToString() != "")
                {
                    ddlDepartment.SelectedValue = dtService.Rows[0]["CPRDEPT_ID"].ToString();
                    objentityPassport.department = Convert.ToInt32(dtService.Rows[0]["CPRDEPT_ID"].ToString());
                }
                if (dtService.Rows[0]["WLFRSRVC_ID"].ToString() != "")
                {
                    ddlService.SelectedValue = dtService.Rows[0]["WLFRSRVC_ID"].ToString();
                }
                if (dtService.Rows[0]["EMP_TYPE"].ToString() == "1")
                {
                    radioCustType1.Checked = true;
                    objentityPassport.EmployeeType = 1;
                }

                ddlDesignation.Enabled = false;
                ddlDivision.Enabled = false;
                ddlEmployee.Enabled = false;
                ddlDepartment.Enabled = false;
                ddlService.Enabled = false;
                radioCustType1.Disabled = true;
                radioCustType2.Disabled = true;

                //start:-For employee table

                StringBuilder sb = new StringBuilder();
                sb.Append("<div class=\"col-lg-12 table-responsive\" style=\"background-color:#FFF;padding-top:14px;clear:both;\">");
                if (dtService.Rows.Count > 0)
                {
                    sb.Append("<input type=\"text\" id=\"myInput\" onkeyup=\"myFunction()\" onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" placeholder=\"Search employees..\" />");
                }
                sb.Append("<table id=\"tableMain\" class=\"table table-bordered table-responsive\" style=\"font-size:13px;margin-bottom: 14px;\">");
                sb.Append("<thead><tr><th>Employee name</th><th colspan=\"8\">Employee code</th></tr></thead>");
                sb.Append("<tbody>");
                for (int intcnt = 0; intcnt < dtService.Rows.Count; intcnt++)
                {
                    string EmpName = dtService.Rows[intcnt]["USR_NAME"].ToString();
                    string EmpId = dtService.Rows[intcnt][0].ToString();
                    string EmpCode = dtService.Rows[intcnt]["USR_CODE"].ToString();
                    string DsgnId = dtService.Rows[intcnt]["DSGN_ID"].ToString();


                    objentityPassport.UserId = Convert.ToInt32(EmpId);
                    DataTable dtEmployee = objBussinesspasprt.readEmpWiseData(objentityPassport);

                    clsEntityWelfareServiceTransaction objentityPassport1 = new clsEntityWelfareServiceTransaction();
                    objentityPassport1.employee = Convert.ToInt32(EmpId);
                    objentityPassport1.designation = Convert.ToInt32(DsgnId);
                    DataTable dtServiceCtgry = objBussinesspasprt.ReadEmpServiceCtgry(objentityPassport1);
                    //if (dtServiceCtgry.Rows.Count > 0)
                    //{
                        sb.Append("<tr>");
                        sb.Append("<td style=\"display:none;\">" + EmpId + "</td>");
                        sb.Append("<td style=\"width:12%;\">" + EmpName + "</td>");
                        sb.Append("<td style=\"width:10%;\">" + EmpCode + "</td>");
                        sb.Append("<td id=\"DsgnId" + EmpId + "\" style=\"display:none;\">" + DsgnId + "</td>");
                        sb.Append("<td style=\"width:78%;\" colspan=\"8\" style=\"padding:0;\">");
                        sb.Append("<table id=\"tableEmp" + EmpId + "\" class=\"table table-bordered\" style=\"font-size:13px;background-color: #f6f6f6;margin-bottom: 0px;\">");
                        sb.Append("<tr>");
                        sb.Append("<td>Service</td><td>Date</td><td>Availability</td><td>Limit</td> <td>Allotted</td> <td>Remaining</td> <td colspan=\"2\">Allot</td>");
                        sb.Append("</tr>");

                        for (int i = 1; i <= dtEmployee.Rows.Count; i++)
                        {

                            string ServId = dtEmployee.Rows[i - 1]["WLFRSRVC_ID"].ToString();
                            string Allot = dtEmployee.Rows[i - 1]["WLFRSUBDTL_ALOT"].ToString();
                            string Remain = dtEmployee.Rows[i - 1]["WLFRSUBDTL_REMIN"].ToString();
                            string TotAllot = dtEmployee.Rows[i - 1]["WLFRSUBDTL_ALOT_TOTAL"].ToString();
                            DateTime dtFromDate = Convert.ToDateTime(dtEmployee.Rows[i - 1]["WLFRSUBDTL_DATE"].ToString());
                            string AllotDate = dtFromDate.ToString("dd-MM-yyyy");
                            string colorSts = dtEmployee.Rows[i - 1]["WLFRSUBDTL_COLOR_STS"].ToString();
                            string avalblty = dtEmployee.Rows[i - 1]["WLFRSUBDTL_AVALBLTY"].ToString();
                            string limit = dtEmployee.Rows[i - 1]["WLFRSUBDTL_LIMIT"].ToString();

                            string[] arrli = new string[10];
                            arrli = limit.Split('/');
                            limit = arrli[0] + "/<br>" + arrli[1];

                            string[] arr = new string[10];
                            arr = ReadServDtlDate(ServId, EmpId, AllotDate, DsgnId);

                            sb.Append("<tr>");
                            sb.Append("<td style=\"display:none;\">" + EmpId + i + "</td>");
                            sb.Append("<td style=\"width:19%;\"> <select disabled id=\"ddlService" + EmpId + i + "\" class=\"form-control\" onchange=\"return changeService(" + EmpId + "," + i + ");\"> <option>-Select-</option>");
                            int flagS = 0;
                            foreach (DataRow dr in dtServiceCtgry.Rows)
                            {
                                if (ServId == dr["WLFRSRVC_ID"].ToString())
                                {
                                    sb.Append("<option selected value=\"" + dr["WLFRSRVC_ID"].ToString() + "\">" + dr["WLFRSRVC_NAME"].ToString() + "</option>");
                                    flagS = 1;
                                }
                                else
                                {
                                    sb.Append("<option value=\"" + dr["WLFRSRVC_ID"].ToString() + "\">" + dr["WLFRSRVC_NAME"].ToString() + "</option>");
                                }
                            }
                            if (flagS == 0)
                            {
                                sb.Append("<option selected value=\"" + ServId + "\">" + dtEmployee.Rows[i - 1]["WLFRSRVC_NAME"].ToString() + "</option>");
                            }
                            sb.Append("</select></td>");
                            sb.Append("<td style=\"width:13%;\"><input disabled id=\"AllotDate" + EmpId + i + "\" value=\"" + AllotDate + "\" type=\"text\" placeholder=\"dd/mm/yyyy\" class=\"form-control datepicker\" /></td>");
                            sb.Append("<td style=\"width:14%;\"><label id=\"availability" + EmpId + i + "\">" + avalblty + "</label></td>");
                            sb.Append("<td style=\"width:12%;\" id=\"limit" + EmpId + i + "\">" + limit + "</td>");
                            sb.Append("<td style=\"width:10%;\" id=\"allotted" + EmpId + i + "\">" + TotAllot + "</td>");
                            sb.Append("<td style=\"width:10%;\" id=\"remaining" + EmpId + i + "\">" + Remain + "</td> ");
                            if (colorSts == "0")
                            {
                                sb.Append("<td style=\"width:12%;\"><input disabled id=\"allot" + EmpId + i + "\" value=\"" + Allot + "\" type=\"text\"  class=\"form-control\" /></td>");
                            }
                            else
                            {
                                sb.Append("<td style=\"width:12%;\"><input disabled id=\"allot" + EmpId + i + "\" style=\"background-color:#fcb8b8;\" value=\"" + Allot + "\" type=\"text\"  class=\"form-control\" /></td>");
                            }
                            sb.Append("<td style=\"width:10%;\"><button disabled id=\"btnadd" + EmpId + i + "\" style=\"width:100%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return addRow(" + EmpId + "," + i + "," + DsgnId + ");\"><span class=\"glyphicon glyphicon-plus\"></span> Add </button><button disabled id=\"btnDele" + EmpId + i + "\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return deleRow(" + EmpId + "," + i + "," + DsgnId + ");\"><span class=\"glyphicon glyphicon-trash\"></span> Delete </button></td>");

                            sb.Append("</tr>");
                        }
                        if (dtEmployee.Rows.Count == 0)
                        {

                            sb.Append("<tr id=\"empRow" + EmpId + "1\">");
                            sb.Append("<td style=\"display:none;\">" + EmpId + "1</td>");
                            sb.Append("<td id=\"Mandatory" + EmpId + "1\" style=\"display:none;\"></td>");
                            sb.Append("<td id=\"Freqncy" + EmpId + "1\" style=\"display:none;\"></td>");
                            sb.Append("<td id=\"ServiceDateId" + EmpId + "1\" style=\"display:none;\"></td>");
                            sb.Append("<td style=\"width:19%;\"> <select disabled id=\"ddlService" + EmpId + "1\" onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" class=\"form-control\" onchange=\"return changeService(" + EmpId + ",1);\"> <option>-Select-</option>");
                            foreach (DataRow dr in dtServiceCtgry.Rows)
                            {
                                sb.Append("<option value=\"" + dr["WLFRSRVC_ID"].ToString() + "\">" + dr["WLFRSRVC_NAME"].ToString() + "</option>");
                            }
                            sb.Append("</select></td>");
                            sb.Append("<td style=\"width:13%;\"><input disabled id=\"AllotDate" + EmpId + "1\" maxlength=10 onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" onchange=\"return changeAllotDate(" + EmpId + ",1);\" type=\"text\" placeholder=\"dd-mm-yyyy\" class=\"form-control datepicker\" /></td>");
                            sb.Append("<td style=\"width:14%;\"><label id=\"availability" + EmpId + "1\"></label></td>");
                            sb.Append("<td style=\"width:15%;\" id=\"limit" + EmpId + "1\"></td>");
                            sb.Append("<td style=\"width:10%;\" id=\"allotted" + EmpId + "1\"></td>");
                            sb.Append("<td style=\"width:10%;\" id=\"remaining" + EmpId + "1\"></td> ");
                            sb.Append("<td style=\"width:12%;\"><input disabled id=\"allot" + EmpId + "1\" maxlength=8 onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeAllotNum(" + EmpId + ",1);\" type=\"text\"  class=\"form-control\" /></td>");
                            sb.Append("<td style=\"width:10%;\"><button disabled id=\"btnadd" + EmpId + "1\" style=\"width:100%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return addRow(" + EmpId + ",1," + DsgnId + ");\"><span class=\"glyphicon glyphicon-plus\"></span> Add </button><button disabled id=\"btnDele" + EmpId + "1\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return deleRow(" + EmpId + ",1," + DsgnId + ");\"><span class=\"glyphicon glyphicon-trash\"></span> Delete </button></td>");
                            sb.Append("</tr>");
                        }

                        sb.Append("</table>");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                    //}
                }

                sb.Append("<tr id=\"trLast\" style=\"display:none;\">");
                sb.Append("<td colspan=\"2\" style=\"padding:0;\">No data available</td>");
                sb.Append("</tr>");

                sb.Append("</tbody>");
                sb.Append("</table>");
                sb.Append("</div>");

                divEmployeeTable.InnerHtml = sb.ToString();
                //end:-For employee table

            }
        }
        catch(Exception ex){
        }
    }

    [WebMethod]
    public static string[] ReadServDtlDate(string service, string EmpId, string allotDate, string DesgId)
    {
        string[] arr = new string[13];
        try
        {
            clsBusinessWelfareServiceTransaction objBussinesspasprt = new clsBusinessWelfareServiceTransaction();
            if (allotDate != "")
            {
                clsCommonLibrary objCommon = new clsCommonLibrary();
                clsEntityWelfareServiceTransaction objentityPassport = new clsEntityWelfareServiceTransaction();          
                objentityPassport.ServiceId = Convert.ToInt32(service);
                objentityPassport.employee = Convert.ToInt32(EmpId);
                objentityPassport.Date = objCommon.textToDateTime(allotDate);
                objentityPassport.Date1Month = objentityPassport.Date.ToString("MM-yyyy");
                objentityPassport.DateYear = objentityPassport.Date.ToString("yyyy");
                DataTable dtService = objBussinesspasprt.ReadServiceDtlEmp(objentityPassport);
                if (dtService.Rows.Count > 0)
                {
                    //Start:-For read quantity
                    if (dtService.Rows[0]["USR_QNTY"].ToString() != "")
                    {
                        arr[0] = dtService.Rows[0]["USR_QNTY"].ToString();
                    }
                    else if (dtService.Rows[0]["DESG_QNTY"].ToString() != "")
                    {
                        arr[0] = dtService.Rows[0]["DESG_QNTY"].ToString();
                    }
                    else if (dtService.Rows[0]["DEPT_QNTY"].ToString() != "")
                    {
                        arr[0] = dtService.Rows[0]["DEPT_QNTY"].ToString();
                    }
                    else if (dtService.Rows[0]["MASTER_QNTY"].ToString() != "")
                    {
                        arr[0] = dtService.Rows[0]["MASTER_QNTY"].ToString();
                    }
                    //End:-For read quantity

                    if (dtService.Rows[0]["WLFRSRVC_UNIT"].ToString() != "")
                    {
                        if (dtService.Rows[0]["WLFRSRVC_UNIT"].ToString() == "0")
                        {
                            arr[1] = "Liter";
                        }
                        else if (dtService.Rows[0]["WLFRSRVC_UNIT"].ToString() == "1")
                        {
                            arr[1] = "Amount";
                        }
                        else if (dtService.Rows[0]["WLFRSRVC_UNIT"].ToString() == "2")
                        {
                            arr[1] = "Count";
                        }
                        else if (dtService.Rows[0]["WLFRSRVC_UNIT"].ToString() == "3")
                        {
                            arr[1] = "KiloGram";
                        }
                        else if (dtService.Rows[0]["WLFRSRVC_UNIT"].ToString() == "4")
                        {
                            arr[1] = "Meter";
                        }

                    }
                    arr[2] = dtService.Rows[0]["WLFRSRVC_MANDTRY"].ToString();

                    if (dtService.Rows[0]["WLFRSRVC_FRQNCY"].ToString() != "")
                    {
                        if (dtService.Rows[0]["WLFRSRVC_FRQNCY"].ToString() == "0")
                        {
                            arr[3] = "1 month";
                        }
                        else if (dtService.Rows[0]["WLFRSRVC_FRQNCY"].ToString() == "1")
                        {
                            arr[3] = "2 month";
                            if (dtService.Rows[0]["WLFRSRVC_FRMPERD"].ToString() != "")
                            {
                                DateTime dtFromDate = Convert.ToDateTime(dtService.Rows[0]["WLFRSRVC_FRMPERD"].ToString());
                                int m1 = Convert.ToInt32(dtFromDate.ToString("MM"));
                                int m2 = Convert.ToInt32(objentityPassport.Date.ToString("MM"));
                                if (m1 % 2 == 0)
                                {
                                    if (m2 % 2 == 0)
                                    {
                                        m2 = m2 + 1;
                                    }
                                    else
                                    {
                                        m2 = m2 - 1;
                                    }
                                }
                                else
                                {
                                    if (m2 % 2 == 0)
                                    {
                                        m2 = m2 - 1;
                                    }
                                    else
                                    {
                                        m2 = m2 + 1;
                                    }
                                }
                                string mnth2 = m2.ToString();
                                if (mnth2.Length == 1)
                                {
                                    mnth2 = "0" + mnth2;
                                }
                                objentityPassport.Date2Month = mnth2 + "-" + objentityPassport.Date.Year;

                            }

                        }
                        else if (dtService.Rows[0]["WLFRSRVC_FRQNCY"].ToString() == "2")
                        {
                            arr[3] = "1 year";
                        }
                        else if (dtService.Rows[0]["WLFRSRVC_FRQNCY"].ToString() == "3")
                        {
                            arr[3] = "visit";
                        }
                    }

                    if (dtService.Rows[0]["WLFRSRVC_FRMPERD"].ToString() != "")
                    {
                        DateTime dtFromDate = Convert.ToDateTime(dtService.Rows[0]["WLFRSRVC_FRMPERD"].ToString());
                        arr[4] = dtFromDate.ToString("dd-MM-yyyy");
                    }
                    if (dtService.Rows[0]["WLFRSRVC_TOPERD"].ToString() != "")
                    {
                        DateTime dtToDate = Convert.ToDateTime(dtService.Rows[0]["WLFRSRVC_TOPERD"].ToString());
                        arr[5] = dtToDate.ToString("dd-MM-yyyy");
                        arr[6] = arr[4] + " To " + arr[5];
                    }
                    else
                    {
                        arr[6] = arr[4] + " Onwards";
                    }
                    arr[7] = arr[0] + " " + arr[1] + "/<br>" + arr[3];

                    arr[10] = dtService.Rows[0]["WLFSRVCDTL_ID"].ToString();


                    objentityPassport.ServiceId = Convert.ToInt32(arr[10]);
                    objentityPassport.CancelStatus = Convert.ToInt32(dtService.Rows[0]["WLFRSRVC_FRQNCY"].ToString());
                    DataTable dtServiceDate = objBussinesspasprt.ReadServiceDtlEmpDate(objentityPassport);
                    if (dtServiceDate.Rows.Count > 0)
                    {
                        if (dtServiceDate.Rows[0][0].ToString() == "" || dtServiceDate.Rows[0][0].ToString() == "0")
                        {
                            arr[8] = "0";
                            arr[9] = arr[0];
                            if (objentityPassport.CancelStatus == 3)
                            {
                                arr[9] = "";
                            }
                        }
                        else
                        {
                            arr[8] = dtServiceDate.Rows[0][0].ToString();
                            arr[9] = (Convert.ToDecimal(arr[0]) - Convert.ToDecimal(arr[8])).ToString();
                            if (objentityPassport.CancelStatus == 3)
                            {
                                arr[9] = "";
                            }
                        }
                    }

                }
            }
                clsEntityWelfareServiceTransaction objentityPassport1 = new clsEntityWelfareServiceTransaction();
                objentityPassport1.employee = Convert.ToInt32(EmpId);
                objentityPassport1.designation = Convert.ToInt32(DesgId);
                DataTable dtServiceCtgry = objBussinesspasprt.ReadEmpServiceCtgry(objentityPassport1);
                dtServiceCtgry.TableName = "dtServiceCtgry";
                if (dtServiceCtgry.Rows.Count > 0)
                {
                    using (StringWriter sw = new StringWriter())
                    {
                        dtServiceCtgry.WriteXml(sw);
                        arr[11] = sw.ToString();
                    }

                }
                foreach (DataRow dr in dtServiceCtgry.Rows)
                {
                    if (service == dr["WLFRSRVC_ID"].ToString())
                    {
                        arr[12] = "Y";
                    }
                }

        }
        catch (Exception ex)
        {
        }

        return arr;
    }

    [WebMethod]
    public static string[] CheckServDtlDateDup(string service, string EmpId, string allotDate)
    {
        string[] arr = new string[1];
        try
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityWelfareServiceTransaction objentityPassport = new clsEntityWelfareServiceTransaction();
            clsBusinessWelfareServiceTransaction objBussinesspasprt = new clsBusinessWelfareServiceTransaction();
            objentityPassport.ServiceId = Convert.ToInt32(service);
            objentityPassport.employee = Convert.ToInt32(EmpId);
            objentityPassport.Date = objCommon.textToDateTime(allotDate);
            DataTable dtService = objBussinesspasprt.CheckServDtlDateDup(objentityPassport);
            if (dtService.Rows.Count > 0)
            {
                arr[0] = "1";
            }
        }
        catch(Exception ex){
          }
        return arr;
    }

    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        clsEntityWelfareServiceTransaction objentityPassport = new clsEntityWelfareServiceTransaction();
        clsBusinessWelfareServiceTransaction objBussinesspasprt = new clsBusinessWelfareServiceTransaction();

        if (Session["CORPOFFICEID"] != null)
        {
            objentityPassport.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objentityPassport.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objentityPassport.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ddlDivision.Items.Clear();
        if (ddlDepartment.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objentityPassport.department = Convert.ToInt32(ddlDepartment.SelectedItem.Value);
            DataTable dtEmployee = objBussinesspasprt.ReadDivisionDDL(objentityPassport);
            if (dtEmployee.Rows.Count > 0)
            {
                ddlDivision.DataSource = dtEmployee;
                ddlDivision.DataTextField = "CPRDIV_NAME";
                ddlDivision.DataValueField = "CPRDIV_ID";
                ddlDivision.DataBind();
            }

            ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
        }
        else
        {
            Corp_DivisionLoad();
        }
        Employee_load();
        ddlDepartment.Focus();
        HiddenFieldFocus.Value = "dep";
       
    }
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        Employee_load();
        if (radioCustType2.Checked == true)
        {
            radioCustType2.Focus();
        }
        else
        {
            radioCustType1.Focus();
        }
    }
}