using System;
using System.Collections.Generic;
using CL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Web.Script.Serialization;
using EL_Compzit;
using System.Text;
using System.Web.Services;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using BL_Compzit.BusinessLayer_HCM;

using EL_Compzit.Entity_Layer_HCM;

public partial class HCM_HCM_Master_Employee_Performance_Mangmnt_Issue_Performance_Form_Emp_Issue_Prfrmnce_Form : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HiddenConfirm.Value = "0";
        clsEntity_Issue_Performance objEntityIssue_Performance = new clsEntity_Issue_Performance();
        cls_Business_Issue_performance objBusiness_Issue_Performance = new cls_Business_Issue_performance();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        if (!IsPostBack)
        {
            txtIssue.Focus();
            Performnceload();
        
            //evm-0027
           

            //  txtdate.Value =objBusinessLayer.LoadCurrentDate().ToString("dd-MM-yyyy");
            txtIssuedate.Value = objBusinessLayer.LoadCurrentDate().ToString("dd-MM-yyyy");
       //     txtIssuedate.Value =DateTime.Today.ToString();
            //END

            int intCorpId=0, intOrgId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityIssue_Performance.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityIssue_Performance.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString()); 
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                lblEntry.Text = "Edit Performance Form";
                
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                Update(strId);
                HiddenIssueId.Value = strId;

            }
            else if (Request.QueryString["DashBrdId"] != null)
            {
                lblEntry.Text = "Add Performance Form";
                string strRandomMixedId = Request.QueryString["DashBrdId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                Update(strId);

            }
            else if (Request.QueryString["ViewId"] != null)
            {
                lblEntry.Text = "View Performance Form";
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                btnEmpAdd.Disabled = true;
                btnrevmoveEmp.Disabled = true;
                btnRemoveEval.Disabled = true;
                BtnAddEval.Disabled = true;
                View(strId);

            }
            else
            {
                lblEntry.Text = "Add Performance Form";
                Departmentload();
                Designationload();
                // Employeeload();
            
                btnUpdate.Visible = false;
                btnConfirm.Visible = false;
                divDsgnList.Attributes["style"] = "display:none;height:300px;overflow:auto;line-height:2;border:1px solid #dddddd;padding: 3px; width: 98%;";
                divDeptList.Attributes["style"] = "display:none;height:300px;overflow:auto;line-height:2;border:1px solid #dddddd;padding: 3px; width: 98%;";
                divEvalDsgn.Attributes["style"] = "display:none;height:300px;overflow:auto;line-height:2;border:1px solid #dddddd;padding: 3px; width: 98%;";
                divevalDept.Attributes["style"] = "display:none;height:300px;overflow:auto;line-height:2;border:1px solid #dddddd;padding: 3px; width: 98%;";
                clsEntityCommon objEntityCommon = new clsEntityCommon();
                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PERFORMANCE_ISSUE_REFNO);
                objEntityCommon.CorporateID = intCorpId;
                objEntityCommon.Organisation_Id = intOrgId;
                string strNextId = objBusinessLayer.ReadNextNumber(objEntityCommon);
                string year = DateTime.Today.Year.ToString();
                txtRefNo.InnerHtml = "REF#" + year + "" + strNextId;
                txtRevNo.InnerHtml = "1";
                //EVM-0027
                txtReferenceNo.Text = txtRefNo.InnerHtml + "-" + txtRevNo.InnerHtml;
                //end

            }
        }
        if (Request.QueryString["InsUpd"] != null)
        {
            string strInsUpd = Request.QueryString["InsUpd"].ToString();
            if (strInsUpd == "Ins")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessInsertion", "SuccessInsertion();", true);
            }
            else if (strInsUpd == "Upd")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
            }
    
            else if (strInsUpd == "CantConfrm")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "CantConfirmation", "CantConfirmation();", true);
            } 
        }

    }
    public void Designationload()
    {
        clsEntity_Issue_Performance objEntityIssue_Performance = new clsEntity_Issue_Performance();
        cls_Business_Issue_performance objBusiness_Issue_Performance = new cls_Business_Issue_performance();
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityIssue_Performance.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityIssue_Performance.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
   
        DataTable dtDesignation = objBusiness_Issue_Performance.ReadDesignation(objEntityIssue_Performance);
        ddlEmpDsgn.Items.Clear();

        ddlEmpDsgn.DataSource = dtDesignation;
        ddlEmpDsgn.DataTextField = "DSGN_NAME";
        ddlEmpDsgn.DataValueField = "DSGN_ID";
        ddlEmpDsgn.DataBind();
        ddlEmpDsgn.Items.Insert(0, "--SELECT DESIGNATION--");
        ddlEvalDsgn.DataSource = dtDesignation;
        ddlEvalDsgn.DataTextField = "DSGN_NAME";
        ddlEvalDsgn.DataValueField = "DSGN_ID";
        ddlEvalDsgn.DataBind();
        ddlEvalDsgn.Items.Insert(0, "--SELECT DESIGNATION--");
        if (Request.QueryString["Id"] == null && Request.QueryString["ViewId"] == null)
        {
            string strPrintReport = ConvertDataTableDesign(dtDesignation);
            divDsgnList.InnerHtml = strPrintReport;
            string strPrintEval = ConvertDataTableDesignEval(dtDesignation);
            divEvalDsgn.InnerHtml = strPrintEval;
        }
    }
    public string ConvertDataTableDesign(DataTable dtDesignation)
    {

        int DgnNum = 0;

        StringBuilder sb = new StringBuilder();

        sb.Append("<table id=\"TableDsgn\"  cellspacing=\"0\" cellpadding=\"2px\" style=\"width: 100%;\" >");
        sb.Append("<tbody>");
        HiddenDsgn.Value =Convert.ToString(dtDesignation.Rows.Count);
        for (int intRowBodyCount = 0; intRowBodyCount < dtDesignation.Rows.Count; intRowBodyCount++)
        {
            DgnNum++;
            int flag = 0;
            if (HiddenDsgnId.Value != "")
            {
                string[] tokens = HiddenDsgnId.Value.Split(',');
                for (int i = 0; i < tokens.Count(); i++)
                {
                    if (tokens[i] == dtDesignation.Rows[intRowBodyCount]["DSGN_ID"].ToString())
                    {
                        sb.Append("<tr id=\"SelectRowDsgn" + dtDesignation.Rows[intRowBodyCount]["DSGN_ID"].ToString() + "\" class=\"list-group-item\"style=\"display:none;\">");
                        flag++;
                    }
                }
            }
            if (flag == 0)
            {
                sb.Append("<tr id=\"SelectRowDsgn" + dtDesignation.Rows[intRowBodyCount]["DSGN_ID"].ToString() + "\" class=\"list-group-item\">");
            }
            sb.Append("<td class=\"smart-form\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;\" > <label class=\"checkbox \" ><input type=\"checkbox\" tabindex=\"9\"  value=\"" + dtDesignation.Rows[intRowBodyCount]["DSGN_ID"].ToString() + "\" id=\"cbMandatoryAllDsgn" + dtDesignation.Rows[intRowBodyCount]["DSGN_ID"].ToString() + "\"  onkeypress=\"return NotEnter(event);\"><i  style=\"margin-top:-45%;\"></i></label></td>");
            sb.Append("<td id=\"tdDsgnName" + dtDesignation.Rows[intRowBodyCount]["DSGN_ID"].ToString() + "\" style=\"width:100%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + dtDesignation.Rows[intRowBodyCount]["DSGN_NAME"].ToString() + "</td>");
            sb.Append("<td id=\"tdDsgnId" + dtDesignation.Rows[intRowBodyCount]["DSGN_ID"].ToString() + "\" style=\"display: none;\">" + dtDesignation.Rows[intRowBodyCount]["DSGN_ID"].ToString() + "</td>");
            sb.Append("</tr>");
        }
        sb.Append("</tbody>");
        sb.Append("</table>");
        return sb.ToString();
    }
    public string ConvertDataTableDesignEval(DataTable dtDesignation)
    {

        int DgnNum = 0;

        StringBuilder sb = new StringBuilder();

        sb.Append("<table id=\"TableEvalDsgn\"  cellspacing=\"0\" cellpadding=\"2px\" style=\"width: 100%;\">");
        sb.Append("<tbody>");
        for (int intRowBodyCount = 0; intRowBodyCount < dtDesignation.Rows.Count; intRowBodyCount++)
        {
            DgnNum++;
            int flag = 0;
            if (HiddenEvalDsgnId.Value != "")
            {
                string[] tokens = HiddenEvalDsgnId.Value.Split(',');
                for (int i = 0; i < tokens.Count(); i++)
                {
                    if (tokens[i] == dtDesignation.Rows[intRowBodyCount]["DSGN_ID"].ToString())
                    {
                        sb.Append("<tr id=\"SelectRow" + dtDesignation.Rows[intRowBodyCount]["DSGN_ID"].ToString() + "\" class=\"list-group-item\"style=\"display:none;\">");
                        flag++;
                    }
                }
            }
            if (flag == 0)
            {
                sb.Append("<tr id=\"SelectRow" + dtDesignation.Rows[intRowBodyCount]["DSGN_ID"].ToString() + "\" class=\"list-group-item\">");
            }
            sb.Append("<td class=\"smart-form\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;\" > <label class=\"checkbox \" ><input type=\"checkbox\" tabindex=\"25\"  value=\"" + dtDesignation.Rows[intRowBodyCount]["DSGN_ID"].ToString() + "\" id=\"cbMandatoryEvalDsgn" + dtDesignation.Rows[intRowBodyCount]["DSGN_ID"].ToString() + "\"  onkeypress=\"return NotEnter(event);\"><i  style=\"margin-top:-45%;\"></i></label></td>");
            sb.Append("<td id=\"tdEvalDsgntName" + dtDesignation.Rows[intRowBodyCount]["DSGN_ID"].ToString() + "\" style=\"width:100%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + dtDesignation.Rows[intRowBodyCount]["DSGN_NAME"].ToString() + "</td>");
            sb.Append("<td id=\"tdEvalDsgnId" + dtDesignation.Rows[intRowBodyCount]["DSGN_ID"].ToString() + "\" style=\"display: none;\">" + dtDesignation.Rows[intRowBodyCount]["DSGN_ID"].ToString() + "</td>");
            sb.Append("</tr>");
        }
        sb.Append("</tbody>");
        sb.Append("</table>");
        
        return sb.ToString();
    }
    public void Departmentload()
    {
        clsEntity_Issue_Performance objEntityIssue_Performance = new clsEntity_Issue_Performance();
        cls_Business_Issue_performance objBusiness_Issue_Performance = new cls_Business_Issue_performance();
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityIssue_Performance.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityIssue_Performance.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtDept = objBusiness_Issue_Performance.ReadDepartment(objEntityIssue_Performance);
        ddlEmpDept.Items.Clear();

        ddlEmpDept.DataSource = dtDept;
        ddlEmpDept.DataTextField = "CPRDEPT_NAME";
        ddlEmpDept.DataValueField = "CPRDEPT_ID";
        ddlEmpDept.DataBind();
        ddlEmpDept.Items.Insert(0, "--SELECT DEPARTMENT--");
        ddlEvalDept.DataSource = dtDept;
        ddlEvalDept.DataTextField = "CPRDEPT_NAME";
        ddlEvalDept.DataValueField = "CPRDEPT_ID";
        ddlEvalDept.DataBind();
        ddlEvalDept.Items.Insert(0, "--SELECT DEPARTMENT--");
        if (Request.QueryString["Id"] == null && Request.QueryString["ViewId"] == null)
        {
            string strPrintReport = ConvertDataTableDept(dtDept);
            divDeptList.InnerHtml = strPrintReport;
            string strPrintEval = ConvertDataTableDeptEval(dtDept);
            divevalDept.InnerHtml = strPrintEval;
        }
    }
    public string ConvertDataTableDept(DataTable dtDept)
    {

        int RowDept = 0;

        StringBuilder sb = new StringBuilder();

        sb.Append("<table id=\"TableDept\"  cellspacing=\"0\" cellpadding=\"2px\" style=\"width: 100%;\">");
        sb.Append("<tbody>");
        HiddenDept.Value = Convert.ToString(dtDept.Rows.Count);
        for (int intRowBodyCount = 0; intRowBodyCount < dtDept.Rows.Count; intRowBodyCount++)
        {
            RowDept++;
            int flag = 0;
            if (HiddenDeptId.Value != "")
            {
                string[] tokens = HiddenDeptId.Value.Split(',');
                for (int i = 0; i < tokens.Count(); i++)
                {
                    if (tokens[i] == dtDept.Rows[intRowBodyCount]["CPRDEPT_ID"].ToString())
                    {
                        sb.Append("<tr id=\"SelectRowDept" + dtDept.Rows[intRowBodyCount]["CPRDEPT_ID"].ToString() + "\" class=\"list-group-item\"style=\"display:none;\">");
                        flag++;
                    }
                }
            }
            if (flag == 0)
            {
                sb.Append("<tr id=\"SelectRowDept" + dtDept.Rows[intRowBodyCount]["CPRDEPT_ID"].ToString() + "\" class=\"list-group-item\">");
            }
            sb.Append("<td class=\"smart-form\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;\" > <label class=\"checkbox \" ><input type=\"checkbox\" value=\"" + dtDept.Rows[intRowBodyCount]["CPRDEPT_ID"].ToString() + "\" tabindex=\"9\" id=\"cbMandatoryAllDept" + dtDept.Rows[intRowBodyCount]["CPRDEPT_ID"].ToString() + "\"  onkeypress=\"return NotEnter(event);\"><i  style=\"margin-top:-45%;\"></i></label></td>");
            sb.Append("<td id=\"tdDeptName" + dtDept.Rows[intRowBodyCount]["CPRDEPT_ID"].ToString() + "\" style=\"width:100%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + dtDept.Rows[intRowBodyCount]["CPRDEPT_NAME"].ToString() + "</td>");
                sb.Append("<td id=\"tdDeptId" + dtDept.Rows[intRowBodyCount]["CPRDEPT_ID"].ToString() + "\"  style=\"display: none;\">" + dtDept.Rows[intRowBodyCount]["CPRDEPT_ID"].ToString() + "</td>");
                sb.Append("</tr>");
        }
        sb.Append("</tbody>");
        sb.Append("</table>");
        return sb.ToString();
    }
    public string ConvertDataTableDeptEval(DataTable dtDept)
    {

        int RowDept = 0;

        StringBuilder sb = new StringBuilder();

        sb.Append("<table id=\"TableEvalDept\"  cellspacing=\"0\" cellpadding=\"2px\" style=\"width: 100%;\">");
        sb.Append("<tbody>");
        for (int intRowBodyCount = 0; intRowBodyCount < dtDept.Rows.Count; intRowBodyCount++)
        {
            RowDept++;
            int flag = 0;
            if (HiddenEvalDeptId.Value != "")
            {
                string[] tokens = HiddenEvalDeptId.Value.Split(',');
                for (int i = 0; i < tokens.Count(); i++)
                {
                    if (tokens[i] == dtDept.Rows[intRowBodyCount]["CPRDEPT_ID"].ToString())
                    {
                        sb.Append("<tr id=\"SelectDeptRow" + dtDept.Rows[intRowBodyCount]["CPRDEPT_ID"].ToString() + "\" class=\"list-group-item\"style=\"display:none;\">");
                        flag++;
                    }
                }
            }
            if (flag == 0)
            {
                sb.Append("<tr id=\"SelectDeptRow" + dtDept.Rows[intRowBodyCount]["CPRDEPT_ID"].ToString() + "\" class=\"list-group-item\">");
            }
            sb.Append("<td class=\"smart-form\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;\" > <label class=\"checkbox \" ><input type=\"checkbox\" value=\"" + dtDept.Rows[intRowBodyCount]["CPRDEPT_ID"].ToString() + "\" tabindex=\"25\" id=\"cbMandatoryEvalDept" + dtDept.Rows[intRowBodyCount]["CPRDEPT_ID"].ToString() + "\"  onkeypress=\"return NotEnter(event);\"><i  style=\"margin-top:-45%;\"></i></label></td>");

            sb.Append("<td id=\"tdEvalDeptName" + dtDept.Rows[intRowBodyCount]["CPRDEPT_ID"].ToString() + "\" style=\"width:100%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + dtDept.Rows[intRowBodyCount]["CPRDEPT_NAME"].ToString() + "</td>");
            sb.Append("<td id=\"tdEvalDeptId" + dtDept.Rows[intRowBodyCount]["CPRDEPT_ID"].ToString() + "\"  style=\"display: none;\">" + dtDept.Rows[intRowBodyCount]["CPRDEPT_ID"].ToString() + "</td>");
            sb.Append("</tr>");
        }
        sb.Append("</tbody>");
        sb.Append("</table>");
        
        return sb.ToString();
    }
    //public void Employeeload()
    //{
    //    clsEntity_Issue_Performance objEntityIssue_Performance = new clsEntity_Issue_Performance();
    //    cls_Business_Issue_performance objBusiness_Issue_Performance = new cls_Business_Issue_performance();
    //    int intCorpId = 0;
    //    if (Session["CORPOFFICEID"] != null)
    //    {
    //        objEntityIssue_Performance.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
    //        intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
    //    }
    //    else if (Session["CORPOFFICEID"] == null)
    //    {
    //        Response.Redirect("/Default.aspx");
    //    }
    //    if (Session["ORGID"] != null)
    //    {
    //        objEntityIssue_Performance.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
    //    }
    //    else if (Session["ORGID"] == null)
    //    {
    //        Response.Redirect("/Default.aspx");
    //    }
    //    if (ddlEmpDept.SelectedItem.Value != "--SELECT DEPARTMENT--")
    //    {
    //        objEntityIssue_Performance.DeptID = Convert.ToInt32(ddlEmpDept.SelectedItem.Value);
    //    }
    //    if (ddlEmpDsgn.SelectedItem.Value != "--SELECT DESIGNATION--")
    //    {
    //        objEntityIssue_Performance.DsgnID = Convert.ToInt32(ddlEmpDsgn.SelectedItem.Value);
    //    }
    //    DataTable dtEmpl = objBusiness_Issue_Performance.ReadEmployee(objEntityIssue_Performance);

    //    string strPrintReport = ConvertDataTable(dtEmpl);
    //    divEmpList.InnerHtml = strPrintReport;
    //    string strPrinEvalEmp = ConvertDataTableEvalEmp(dtEmpl);
    //    DivEvaluator.InnerHtml = strPrinEvalEmp;

    //}

    public string ConvertDataTable(DataTable dtEmpl)
    {

        int RowNum = 0;
        StringBuilder sb = new StringBuilder();

        sb.Append("<table id=\"TableEmp\"  cellspacing=\"0\" cellpadding=\"2px\" style=\"width: 100%;\">");
        sb.Append("<tbody>");
        HiddeEmp.Value = Convert.ToString(dtEmpl.Rows.Count);

        for (int intRowBodyCount = 0; intRowBodyCount < dtEmpl.Rows.Count; intRowBodyCount++)
        {
            RowNum++;
            int flag = 0;
            if (HiddenUsrId.Value != "")
            {
                string[] tokens = HiddenUsrId.Value.Split(',');
                for (int i = 0; i < tokens.Count(); i++)
                {
                    if (tokens[i] == dtEmpl.Rows[intRowBodyCount]["USR_ID"].ToString())
                    {
                        sb.Append("<tr id=\"EmpRow" + dtEmpl.Rows[intRowBodyCount]["USR_ID"].ToString() + "\" class=\"list-group-item\"style=\"display:none;\">");
                        flag++;
                    }
                }
            }
            if (flag == 0)
            {
                sb.Append("<tr id=\"EmpRow" + dtEmpl.Rows[intRowBodyCount]["USR_ID"].ToString() + "\" class=\"list-group-item\">");
            }
            sb.Append("<td class=\"smart-form\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;\" > <label class=\"checkbox \" ><input type=\"checkbox\" tabindex=\"9\" value=\"" + dtEmpl.Rows[intRowBodyCount]["USR_ID"].ToString() + "\" id=\"cbMandatory" + dtEmpl.Rows[intRowBodyCount]["USR_ID"].ToString() + "\"  onkeypress=\"return NotEnter(event);\"><i  style=\"margin-top:-45%;\"></i></label></td>");
            sb.Append("<td id=\"tdUsrName" + dtEmpl.Rows[intRowBodyCount]["USR_ID"].ToString() + "\" style=\"width:100%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + dtEmpl.Rows[intRowBodyCount]["USR_NAME"].ToString() + "</td>");
            sb.Append("<td id=\"tdUsrId" + dtEmpl.Rows[intRowBodyCount]["USR_ID"].ToString() + "\" style=\"display: none;\">" + dtEmpl.Rows[intRowBodyCount]["USR_ID"].ToString() + "</td>");
            sb.Append("</tr>");
        }
        sb.Append("</tbody>");
        sb.Append("</table>"); 
        return sb.ToString();
    }
    public string ConvertDataTableEvalEmp(DataTable dtEmpl)
    {

        int RowNum = 0;

        StringBuilder sb = new StringBuilder();

        sb.Append("<table id=\"TableAddEvaluator\"  cellspacing=\"0\" cellpadding=\"2px\" style=\"width: 100%;\">");
        sb.Append("<tbody>");
        for (int intRowBodyCount = 0; intRowBodyCount < dtEmpl.Rows.Count; intRowBodyCount++)
        {
            RowNum++;
            int flag = 0;
            if (HiddenEvalId.Value != "")
            {
                string[] tokens = HiddenEvalId.Value.Split(',');
                for (int i = 0; i < tokens.Count(); i++)
                {
                    if (tokens[i] == dtEmpl.Rows[intRowBodyCount]["USR_ID"].ToString())
                    {
                        sb.Append("<tr id=\"EvalEmpRow" + dtEmpl.Rows[intRowBodyCount]["USR_ID"].ToString() + "\" class=\"list-group-item\"style=\"display:none;\">");
                        flag++;
                    }
                }
            }
            if (flag == 0)
            {
                sb.Append("<tr id=\"EvalEmpRow" + dtEmpl.Rows[intRowBodyCount]["USR_ID"].ToString() + "\" class=\"list-group-item\">");
            }
            sb.Append("<td class=\"smart-form\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;\" > <label class=\"checkbox \" ><input type=\"checkbox\" tabindex=\"25\" value=\"" + dtEmpl.Rows[intRowBodyCount]["USR_ID"].ToString() + "\" id=\"cbMandatoryEval" + dtEmpl.Rows[intRowBodyCount]["USR_ID"].ToString() + "\"  onkeypress=\"return NotEnter(event);\"><i  style=\"margin-top:-45%;\"></i></label></td>");
            sb.Append("<td id=\"tdEvalUsrName" + dtEmpl.Rows[intRowBodyCount]["USR_ID"].ToString() + "\" style=\"width:100%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + dtEmpl.Rows[intRowBodyCount]["USR_NAME"].ToString() + "</td>");
            sb.Append("<td id=\"tdEvalUsrId" + dtEmpl.Rows[intRowBodyCount]["USR_ID"].ToString() + "\" style=\"display: none;\">" + dtEmpl.Rows[intRowBodyCount]["USR_ID"].ToString() + "</td>");
            sb.Append("</tr>");
        }
        sb.Append("</tbody>");
        sb.Append("</table>");
        return sb.ToString();
    }

    public void Performnceload()
    {
        clsEntity_Issue_Performance objEntityIssue_Performance = new clsEntity_Issue_Performance();
        cls_Business_Issue_performance objBusiness_Issue_Performance = new cls_Business_Issue_performance();
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityIssue_Performance.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityIssue_Performance.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
   
        DataTable dtDept = objBusiness_Issue_Performance.ReadPerformanceTemplate(objEntityIssue_Performance);

        ddlTemplte.Items.Clear();

        ddlTemplte.DataSource = dtDept;
        ddlTemplte.DataTextField = "PRFMNC_TMPLT_FORM";
        ddlTemplte.DataValueField = "PRFMNC_TMPLT_ID";
        ddlTemplte.DataBind();
        ddlTemplte.Items.Insert(0, "--SELECT TEMPLATE--");
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
        
        clsEntity_Issue_Performance objEntityIssue_Performance = new clsEntity_Issue_Performance();
        cls_Business_Issue_performance objBusiness_Issue_Performance = new cls_Business_Issue_performance();
        List<clsEntity_Employees_list> ObjEntityEmployeeList = new List<clsEntity_Employees_list>();
        List<clsEntity_Evaluator_list> ObjEntityEvaluatorList = new List<clsEntity_Evaluator_list>();
        Button clickedButton = sender as Button;

        clsCommonLibrary objCommon = new clsCommonLibrary();

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityIssue_Performance.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityIssue_Performance.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityIssue_Performance.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityIssue_Performance.Ref_No = txtRefNo.InnerHtml;
        objEntityIssue_Performance.IssueDate = objCommon.textToDateTime(txtIssuedate.Value);
        objEntityIssue_Performance.Issue = txtIssue.Text;
        objEntityIssue_Performance.Rev_No = Convert.ToInt32(txtRevNo.InnerHtml);
        if (ddlFrequency.SelectedItem.Value != "--SELECT FREQUENCY--")
        {
            objEntityIssue_Performance.Frequency = Convert.ToInt32(ddlFrequency.SelectedItem.Value);
        }
        if (ddlTemplte.SelectedItem.Value != "--SELECT TEMPLATE--")
        {
            objEntityIssue_Performance.PerfrmTempltId = Convert.ToInt32(ddlTemplte.SelectedItem.Value);
        }
        if (ddlEDD.SelectedItem.Value != "")
        {
            objEntityIssue_Performance.EmpDeptDsgn = Convert.ToInt32(ddlEDD.SelectedItem.Value);
        }
        if (ddlEvaluators.SelectedItem.Value != "")
        {
            objEntityIssue_Performance.EDDEval = Convert.ToInt32(ddlEvaluators.SelectedItem.Value);
        }
        if (cbxStatus.Checked)
        {
            objEntityIssue_Performance.Status = 1;
        }
        else
        {
            objEntityIssue_Performance.Status = 0;
        }
        if (cbxSelfEval.Checked)
        {
            objEntityIssue_Performance.SelfEvaluate = 1;
        }
        else
        {
            objEntityIssue_Performance.SelfEvaluate = 0;
        }
        if (cbxselGoal.Checked)
        {
            objEntityIssue_Performance.SelfGoal = 1;
        }
        else
        {
            objEntityIssue_Performance.SelfGoal = 0;
        }
        if (cbxDMEval.Checked)
        {
            objEntityIssue_Performance.DMEvaluate = 1;
        }
        else
        {
            objEntityIssue_Performance.DMEvaluate = 0;
        }
        if (cbxDMGoal.Checked)
        {
            objEntityIssue_Performance.DMGoal = 1;
        }
        else
        {
            objEntityIssue_Performance.DMGoal = 0;
        }
        if (cbxROEval.Checked)
        {
            objEntityIssue_Performance.ROEvaluate = 1;
        }
        else
        {
            objEntityIssue_Performance.ROEvaluate = 0;
        }
        if (cbxROGoal.Checked)
        {
            objEntityIssue_Performance.ROGoal = 1;
        }
        else
        {
            objEntityIssue_Performance.ROGoal = 0;
        }
        if (cbxHREval.Checked)
        {
            objEntityIssue_Performance.HREvaluate = 1;
        }
        else
        {
            objEntityIssue_Performance.HREvaluate = 0;
        }
        if (cbxHRGoal.Checked)
        {
            objEntityIssue_Performance.HRGoal = 1;
        }
        else
        {
            objEntityIssue_Performance.HRGoal = 0;
        }
        if (cbxGMEval.Checked)
        {
            objEntityIssue_Performance.GMEvaluate = 1;
        }
        else
        {
            objEntityIssue_Performance.GMEvaluate = 0;
        }
        if (cbxGMGoal.Checked)
        {
            objEntityIssue_Performance.GMGoal = 1;
        }
        else
        {
            objEntityIssue_Performance.GMGoal = 0;
        }
        if (cbxEvalGoal.Checked)
        {
            objEntityIssue_Performance.EvalutorGoal = 1;
        }
        else
        {
            objEntityIssue_Performance.EvalutorGoal = 0;
        }

        if (ddlEmpDept.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntityIssue_Performance.DeptID = Convert.ToInt32(ddlEmpDept.SelectedItem.Value);
        }
        if (ddlEmpDsgn.SelectedItem.Value != "--SELECT DESIGNATION--")
        {
            objEntityIssue_Performance.DsgnID = Convert.ToInt32(ddlEmpDsgn.SelectedItem.Value);
        }
        if (ddlEvalDept.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntityIssue_Performance.EvalDeptID = Convert.ToInt32(ddlEvalDept.SelectedItem.Value);
        }
        if (ddlEvalDsgn.SelectedItem.Value != "--SELECT DESIGNATION--")
        {
            objEntityIssue_Performance.EvalDsgnID = Convert.ToInt32(ddlEvalDsgn.SelectedItem.Value);
        }
        if (ddlEDD.SelectedItem.Value == "1")
        {
            if (HiddenUsrId.Value != "")
            {

                string[] tokens = HiddenUsrId.Value.Split(',');
                tokens=tokens.Distinct().ToArray();
                for (int i = 0; i < tokens.Count(); i++)
                {

                    int empId = Convert.ToInt32(tokens[i]);
                    clsEntity_Employees_list objentityEmp = new clsEntity_Employees_list();
                    objentityEmp.EmpId = empId;
                    ObjEntityEmployeeList.Add(objentityEmp);
                }
            }
        }
        if (ddlEDD.SelectedItem.Value == "2")
        {
            if (HiddenDeptId.Value != "")
            {
                string[] tokens = HiddenDeptId.Value.Split(',');
                tokens = tokens.Distinct().ToArray();

                for (int i = 0; i < tokens.Count(); i++)
                {

                    int DeptmntId = Convert.ToInt32(tokens[i]);
                    clsEntity_Employees_list objentityEmp = new clsEntity_Employees_list();
                    objentityEmp.DeptId = DeptmntId;
                    ObjEntityEmployeeList.Add(objentityEmp);
                }
            }
        }
        if (ddlEDD.SelectedItem.Value == "3")
        {
            if (HiddenDsgnId.Value != "")
            {
                string[] tokens = HiddenDsgnId.Value.Split(',');
                tokens = tokens.Distinct().ToArray();

                for (int i = 0; i < tokens.Count(); i++)
                {

                    int DsgnId = Convert.ToInt32(tokens[i]);
                    clsEntity_Employees_list objentityEmp = new clsEntity_Employees_list();
                    objentityEmp.DesignationId = DsgnId;
                    ObjEntityEmployeeList.Add(objentityEmp);
                }
            }
        }
        
        if (ddlEvaluators.SelectedItem.Value == "1")
        {
            if (HiddenEvalId.Value != "")
            {
                string[] tokens = HiddenEvalId.Value.Split(',');
                tokens = tokens.Distinct().ToArray();

                for (int i = 0; i < tokens.Count(); i++)
                {

                    int empId = Convert.ToInt32(tokens[i]);
                    clsEntity_Evaluator_list objentityEmp = new clsEntity_Evaluator_list();
                    objentityEmp.EvaluaterEmpId = empId;
                    ObjEntityEvaluatorList.Add(objentityEmp);
                }
            }
        }
        if (ddlEvaluators.SelectedItem.Value == "2")
        {
            if (HiddenEvalDeptId.Value != "")
            {
                string[] tokens = HiddenEvalDeptId.Value.Split(',');
                tokens = tokens.Distinct().ToArray();

                for (int i = 0; i < tokens.Count(); i++)
                {

                    int DeptmntId = Convert.ToInt32(tokens[i]);
                    clsEntity_Evaluator_list objentityEmp = new clsEntity_Evaluator_list();
                    objentityEmp.EvaluaterDeptId = DeptmntId;
                    ObjEntityEvaluatorList.Add(objentityEmp);
                }
            }
        }
        if (ddlEvaluators.SelectedItem.Value == "3")
        {
            if (HiddenEvalDsgnId.Value != "")
            {
                string[] tokens = HiddenEvalDsgnId.Value.Split(',');
                tokens = tokens.Distinct().ToArray();
                for (int i = 0; i < tokens.Count(); i++)
                {

                    int DsgnId = Convert.ToInt32(tokens[i]);
                    clsEntity_Evaluator_list objentityEmp = new clsEntity_Evaluator_list();
                    objentityEmp.EvaluaterDsgntId = DsgnId;
                    objentityEmp.EvaluaterDsgntId = DsgnId;
                    ObjEntityEvaluatorList.Add(objentityEmp);
                }
            }
        }
       objBusiness_Issue_Performance.InsertPerformanceIssue(objEntityIssue_Performance, ObjEntityEmployeeList, ObjEntityEvaluatorList);
        if (clickedButton.ID == "btnSave")
        {
            Response.Redirect("Emp_Issue_Prfrmnce_Form.aspx?InsUpd=Ins");
        }

    }

    public void Update(string strId)
    {
        HiddenConfirm.Value = "0";

        btnSave.Visible = false;
        btnClear.Visible = false;
        Performnceload();
        Departmentload();
        Designationload();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntity_Issue_Performance objEntityIssue_Performance = new clsEntity_Issue_Performance();
        cls_Business_Issue_performance objBusiness_Issue_Performance = new cls_Business_Issue_performance();
        List<clsEntity_Employees_list> ObjEntityEmployeeList = new List<clsEntity_Employees_list>();
        List<clsEntity_Evaluator_list> ObjEntityEvaluatorList = new List<clsEntity_Evaluator_list>();
        objEntityIssue_Performance.IssueId = Convert.ToInt32(strId);
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityIssue_Performance.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityIssue_Performance.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        DataTable dtDetail1 = new DataTable();
        dtDetail1.Columns.Add("IEVLTR_ID", typeof(int));
        dtDetail1.Columns.Add("IISSUE_ID", typeof(int));
        dtDetail1.Columns.Add("IUSR_ID", typeof(int));
        dtDetail1.Columns.Add("IDEPT_ID", typeof(int));
        dtDetail1.Columns.Add("IDESGN_ID", typeof(int));
        dtDetail1.Columns.Add("IGOAL", typeof(int));
        dtDetail1.Columns.Add("IDEPT", typeof(string));
        dtDetail1.Columns.Add("IDESGN", typeof(string));
        dtDetail1.Columns.Add("IUSR", typeof(string));
        DataTable dtIssueEval = objBusiness_Issue_Performance.ReadEvaluatorsById(objEntityIssue_Performance);

        for (int intcnt = 0; intcnt < dtIssueEval.Rows.Count; intcnt++)
        {
            DataRow drDtl = dtDetail1.NewRow();
            drDtl["IEVLTR_ID"] = Convert.ToInt32(dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_ID"].ToString());
            drDtl["IISSUE_ID"] = Convert.ToInt32(dtIssueEval.Rows[intcnt]["ISSUE_ID"].ToString());
            if (dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_USR_ID"].ToString() != "")
            {
                drDtl["IUSR_ID"] = dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_USR_ID"].ToString();
                drDtl["IUSR"] = dtIssueEval.Rows[intcnt]["USR_NAME"].ToString();
                if (HiddenEvalId.Value == "")
                {
                    HiddenEvalId.Value = dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_USR_ID"].ToString();
                }
                else
                {
                    HiddenEvalId.Value += "," + dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_USR_ID"].ToString();
                }

            }
            if (dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_DEPTID"].ToString() != "")
            {
                drDtl["IDEPT_ID"] = dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_DEPTID"].ToString();
                drDtl["IDEPT"] = dtIssueEval.Rows[intcnt]["CPRDEPT_NAME"].ToString();
                if (HiddenEvalDeptId.Value == "")
                {
                    HiddenEvalDeptId.Value = dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_DEPTID"].ToString();
                }
                else
                {
                    HiddenEvalDeptId.Value += "," + dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_DEPTID"].ToString();
                }

            }
            if (dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_DSGNID"].ToString() != "")
            {
                drDtl["IDESGN_ID"] = Convert.ToInt32(dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_DSGNID"].ToString());
                drDtl["IDESGN"] = dtIssueEval.Rows[intcnt]["DSGN_NAME"].ToString();
                if (HiddenEvalDsgnId.Value == "")
                {
                    HiddenEvalDsgnId.Value = dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_DSGNID"].ToString();
                }
                else
                {
                    HiddenEvalDsgnId.Value += "," + dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_DSGNID"].ToString();
                }
            }
            drDtl["IGOAL"] = Convert.ToInt32(dtIssueEval.Rows[intcnt]["ISSUE_ID"].ToString());
            if (dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_GOAL"].ToString() == "1")
            {
                cbxEvalGoal.Checked = true;
            }
            else
            {
                cbxEvalGoal.Checked = false;
            }

            dtDetail1.Rows.Add(drDtl);
        }
        string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail1);
        HiddenEditEval.Value = strJson;


        DataTable dtDetail = new DataTable();
        dtDetail.Columns.Add("ISSUE_EMP_ID", typeof(int));
        dtDetail.Columns.Add("ISSUE_ID", typeof(int));
        dtDetail.Columns.Add("USR_ID", typeof(int));
        dtDetail.Columns.Add("DEPT_ID", typeof(int));
        dtDetail.Columns.Add("DESGN_ID", typeof(int));
        dtDetail.Columns.Add("DEPT", typeof(string));
        dtDetail.Columns.Add("DESGN", typeof(string));
        dtDetail.Columns.Add("USR", typeof(string));
        DataTable dtIssueEmp = objBusiness_Issue_Performance.ReadEmployeeById(objEntityIssue_Performance);

        for (int intcnt = 0; intcnt < dtIssueEmp.Rows.Count; intcnt++)
        {
            DataRow drDtl = dtDetail.NewRow();
            drDtl["ISSUE_EMP_ID"] = Convert.ToInt32(dtIssueEmp.Rows[intcnt]["ISSUE_EMP_ID"].ToString());
            drDtl["ISSUE_ID"] = Convert.ToInt32(dtIssueEmp.Rows[intcnt]["ISSUE_ID"].ToString());
            if (dtIssueEmp.Rows[intcnt]["ISSUE_EMP_USR_ID"].ToString() != "")
            {
                drDtl["USR_ID"] = dtIssueEmp.Rows[intcnt]["ISSUE_EMP_USR_ID"].ToString();
                drDtl["USR"] = dtIssueEmp.Rows[intcnt]["USR_NAME"].ToString();
                if (HiddenUsrId.Value == "")
                {
                    HiddenUsrId.Value = dtIssueEmp.Rows[intcnt]["ISSUE_EMP_USR_ID"].ToString();
                }
                else
                {
                    HiddenUsrId.Value += "," + dtIssueEmp.Rows[intcnt]["ISSUE_EMP_USR_ID"].ToString();
                }
            }
            if (dtIssueEmp.Rows[intcnt]["ISSUE_EMP_DEPT_ID"].ToString() != "")
            {
                drDtl["DEPT_ID"] = dtIssueEmp.Rows[intcnt]["ISSUE_EMP_DEPT_ID"].ToString();
                drDtl["DEPT"] = dtIssueEmp.Rows[intcnt]["CPRDEPT_NAME"].ToString();
                if (HiddenDeptId.Value == "")
                {
                    HiddenDeptId.Value = dtIssueEmp.Rows[intcnt]["ISSUE_EMP_DEPT_ID"].ToString();
                }
                else
                {
                    HiddenDeptId.Value += "," + dtIssueEmp.Rows[intcnt]["ISSUE_EMP_DEPT_ID"].ToString();
                }
            }
            if (dtIssueEmp.Rows[intcnt]["ISSUE_EMP_DESGN_ID"].ToString() != "")
            {
                drDtl["DESGN_ID"] = Convert.ToInt32(dtIssueEmp.Rows[intcnt]["ISSUE_EMP_DESGN_ID"].ToString());
                drDtl["DESGN"] = dtIssueEmp.Rows[intcnt]["DSGN_NAME"].ToString();
                if (HiddenDsgnId.Value == "")
                {
                    HiddenDsgnId.Value = dtIssueEmp.Rows[intcnt]["ISSUE_EMP_DESGN_ID"].ToString();
                }
                else
                {
                    HiddenDsgnId.Value += "," + dtIssueEmp.Rows[intcnt]["ISSUE_EMP_DESGN_ID"].ToString();
                }
            }
            dtDetail.Rows.Add(drDtl);
        }

        DataTable dtService = objBusiness_Issue_Performance.ReadServiceDetailsById(objEntityIssue_Performance);
        if (dtService.Rows.Count > 0)
        {
            if (dtService.Rows[0]["ISSUE_CNFRM_STATS"].ToString() == "1")
            {
                btnConfirm.Visible = false;
                btnUpdate.Visible = false;

            }
            else
            {
                btnUpdate.Visible = true;
                btnConfirm.Visible = true;
            }
            if (dtService.Rows[0]["ISSUE_REFNO"].ToString() != "")
            {
                txtRefNo.InnerHtml = dtService.Rows[0]["ISSUE_REFNO"].ToString();
            }
            if (dtService.Rows[0]["ISSUE_DATE"].ToString() != "")
            {
                DateTime dtIssue = objCommon.textToDateTime(dtService.Rows[0]["ISSUE_DATE"].ToString());
                string strDate = dtIssue.ToString("dd-MM-yyyy");
                txtIssuedate.Value = strDate;
            }
            if (dtService.Rows[0]["ISSUE_PRFM"].ToString() != "")
            {
                txtIssue.Text = dtService.Rows[0]["ISSUE_PRFM"].ToString();
            }
            if (dtService.Rows[0]["ISSUE_REVNO"].ToString() != "")
            {
                txtRevNo.InnerHtml = dtService.Rows[0]["ISSUE_REVNO"].ToString();
            }
            //EVM-0027
            txtReferenceNo.Text = txtRefNo.InnerHtml + "-" + txtRevNo.InnerHtml;
            //end
            if (dtService.Rows[0]["ISSUE_FRQNCY"].ToString() != "" && dtService.Rows[0]["ISSUE_FRQNCY"].ToString() != "0")
            {
                ddlFrequency.ClearSelection();
                ddlFrequency.Items.FindByValue(dtService.Rows[0]["ISSUE_FRQNCY"].ToString()).Selected = true;
            }
            if (dtService.Rows[0]["PRFMNC_TMPLT_ID"].ToString() != "" && dtService.Rows[0]["PRFMNC_TMPLT_ID"].ToString() != "0")
            {
                ddlTemplte.ClearSelection();
                ddlTemplte.Items.FindByValue(dtService.Rows[0]["PRFMNC_TMPLT_ID"].ToString()).Selected = true;
            }
            if (dtService.Rows[0]["ISSUE_EMP"].ToString() != "")
            {
                ddlEDD.ClearSelection();
                ddlEDD.Items.FindByValue(dtService.Rows[0]["ISSUE_EMP"].ToString()).Selected = true;
       
            }
     
            if (dtService.Rows[0]["ISSUE_EVAL"].ToString() != "")
            {
                ddlEvaluators.ClearSelection();
                ddlEvaluators.Items.FindByValue(dtService.Rows[0]["ISSUE_EVAL"].ToString()).Selected = true;
            }
            if (dtService.Rows[0]["ISSUE_STATS"].ToString() == "0")
            {
                cbxStatus.Checked = false;
            }
            else
            {
                cbxStatus.Checked = true;
            }
            if (dtService.Rows[0]["ISSUE_SELF_EVLTOR"].ToString() == "0")
            {
                cbxSelfEval.Checked = false;
                cbxselGoal.Disabled = true;

            }
            else
            {
                cbxSelfEval.Checked = true;
            }
            if (dtService.Rows[0]["ISSUE_SELF_EVLTOR_GOAL"].ToString() == "0")
            {
                cbxselGoal.Checked = false;
            }
            else
            {
                cbxselGoal.Checked = true;
                cbxselGoal.Disabled = false;
            }
            if (dtService.Rows[0]["ISSUE_RO_EVLTOR"].ToString() == "0")
            {
                cbxROEval.Checked = false;
                cbxROGoal.Disabled = true;

            }
            else
            {
                cbxROEval.Checked = true;
            }
            if (dtService.Rows[0]["ISSUE_RO_EVLTOR_GOAL"].ToString() == "0")
            {
                cbxROGoal.Checked = false;
            }
            else
            {
                cbxROGoal.Checked = true;
                cbxROGoal.Disabled = false;

            }
            if (dtService.Rows[0]["ISSUE_DM_EVLTOR"].ToString() == "0")
            {
                cbxDMEval.Checked = false;
                cbxDMGoal.Disabled = true;
            }
            else
            {
                cbxDMEval.Checked = true;
            }
            if (dtService.Rows[0]["ISSUE_DM_EVLTOR_GOAL"].ToString() == "0")
            {
                cbxDMGoal.Checked = false;

            }
            else
            {
                cbxDMGoal.Checked = true;
                cbxDMGoal.Disabled = false;

            }
            if (dtService.Rows[0]["ISSUE_HR_EVLTOR"].ToString() == "0")
            {
                cbxHREval.Checked = false;
                cbxHRGoal.Disabled = true;
            }
            else
            {
                cbxHREval.Checked = true;
            }
            if (dtService.Rows[0]["ISSUE_HR_EVLTOR_GOAL"].ToString() == "0")
            {
                cbxHRGoal.Checked = false;
            }
            else
            {
                cbxHRGoal.Checked = true;
                cbxHRGoal.Disabled = false;

            }
            if (dtService.Rows[0]["ISSUE_GM_EVLTOR"].ToString() == "0")
            {
                cbxGMEval.Checked = false;
                cbxGMGoal.Disabled = true;
            }

            else
            {
                cbxGMEval.Checked = true;
            }
            if (dtService.Rows[0]["ISSUE_GM_EVLTOR_GOAL"].ToString() == "0")
            {
                cbxGMGoal.Checked = false;
            }
            else
            {
                cbxGMGoal.Checked = true;
                cbxGMGoal.Disabled = false;

            }
            //if (dtService.Rows[0]["ISSUE_EMPDEPT"].ToString() != "" )
            //{
            //    ddlEmpDept.ClearSelection();
            //    ddlEmpDept.Items.FindByValue(dtService.Rows[0]["ISSUE_EMPDEPT"].ToString()).Selected = true;
            //    objEntityIssue_Performance.DeptID = Convert.ToInt32(ddlEmpDept.SelectedItem.Value);
            //}
            //if (dtService.Rows[0]["ISSUE_EMPDSGN"].ToString() != "" )
            //{
            //    ddlEmpDsgn.ClearSelection();
            //    ddlEmpDsgn.Items.FindByValue(dtService.Rows[0]["ISSUE_EMPDSGN"].ToString()).Selected = true;
            //    objEntityIssue_Performance.DsgnID = Convert.ToInt32(ddlEmpDsgn.SelectedItem.Value);
            //}

            //if (dtService.Rows[0]["ISSUE_EVLDEPT"].ToString() != "" )
            //{
            //    ddlEvalDept.ClearSelection();
            //    ddlEvalDept.Items.FindByValue(dtService.Rows[0]["ISSUE_EVLDEPT"].ToString()).Selected = true;
            //    objEntityIssue_Performance.DeptID = Convert.ToInt32(ddlEvalDept.SelectedItem.Value);

            //}
            //if (dtService.Rows[0]["ISSUE_EVLDSGN"].ToString() != "" )
            //{
            //    ddlEvalDsgn.ClearSelection();
            //    ddlEvalDsgn.Items.FindByValue(dtService.Rows[0]["ISSUE_EVLDSGN"].ToString()).Selected = true;
            //    objEntityIssue_Performance.DsgnID = Convert.ToInt32(ddlEvalDsgn.SelectedItem.Value);

            //}
        
        }
        if (Request.QueryString["DashBrdId"] != null)
        {
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            int intOldRevNo = 0;
            intOldRevNo = Convert.ToInt32(dtService.Rows[0]["ISSUE_REVNO"].ToString());
            intOldRevNo++;
            txtRevNo.InnerHtml = Convert.ToString(intOldRevNo);
            string strCurrentDate = objBusiness.LoadCurrentDateInString();
            txtIssuedate.Value = strCurrentDate;
            btnConfirm.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;

        }
     
      //  Employeeload();


        string strJson1 = DataTableToJSONWithJavaScriptSerializer(dtDetail);
        HiddenEditEmp.Value = strJson1;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        clsEntity_Issue_Performance objEntityIssue_Performance = new clsEntity_Issue_Performance();
        cls_Business_Issue_performance objBusiness_Issue_Performance = new cls_Business_Issue_performance();
        List<clsEntity_Employees_list> ObjEntityEmployeeList = new List<clsEntity_Employees_list>();
        List<clsEntity_Evaluator_list> ObjEntityEvaluatorList = new List<clsEntity_Evaluator_list>();
        Button clickedButton = sender as Button;

        clsCommonLibrary objCommon = new clsCommonLibrary();

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityIssue_Performance.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityIssue_Performance.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityIssue_Performance.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Request.QueryString["Id"] != null)
        {
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityIssue_Performance.IssueId = Convert.ToInt32(strId);

        }
        objEntityIssue_Performance.Ref_No = txtRefNo.InnerHtml;
        objEntityIssue_Performance.IssueDate = objCommon.textToDateTime(txtIssuedate.Value);
        objEntityIssue_Performance.Issue = txtIssue.Text;
        objEntityIssue_Performance.Rev_No = Convert.ToInt32(txtRevNo.InnerHtml);
        if (ddlFrequency.SelectedItem.Value != "--SELECT FREQUENCY--")
        {
            objEntityIssue_Performance.Frequency = Convert.ToInt32(ddlFrequency.SelectedItem.Value);
        }
        if (ddlTemplte.SelectedItem.Value != "--SELECT TEMPLATE--")
        {
            objEntityIssue_Performance.PerfrmTempltId = Convert.ToInt32(ddlTemplte.SelectedItem.Value);
        }
        if (ddlEDD.SelectedItem.Value != "")
        {
            objEntityIssue_Performance.EmpDeptDsgn = Convert.ToInt32(ddlEDD.SelectedItem.Value);
        }
        if (ddlEvaluators.SelectedItem.Value != "")
        {
            objEntityIssue_Performance.EDDEval = Convert.ToInt32(ddlEvaluators.SelectedItem.Value);
        }
        if (cbxStatus.Checked)
        {
            objEntityIssue_Performance.Status = 1;
        }
        else
        {
            objEntityIssue_Performance.Status = 0;
        }
        if (cbxSelfEval.Checked)
        {
            objEntityIssue_Performance.SelfEvaluate = 1;
        }
        else
        {
            objEntityIssue_Performance.SelfEvaluate = 0;
        }
        if (cbxselGoal.Checked)
        {
            objEntityIssue_Performance.SelfGoal = 1;
        }
        else
        {
            objEntityIssue_Performance.SelfGoal = 0;
        }
        if (cbxDMEval.Checked)
        {
            objEntityIssue_Performance.DMEvaluate = 1;
        }
        else
        {
            objEntityIssue_Performance.DMEvaluate = 0;
        }
        if (cbxDMGoal.Checked)
        {
            objEntityIssue_Performance.DMGoal = 1;
        }
        else
        {
            objEntityIssue_Performance.DMGoal = 0;
        }
        if (cbxROEval.Checked)
        {
            objEntityIssue_Performance.ROEvaluate = 1;
        }
        else
        {
            objEntityIssue_Performance.ROEvaluate = 0;
        }
        if (cbxROGoal.Checked)
        {
            objEntityIssue_Performance.ROGoal = 1;
        }
        else
        {
            objEntityIssue_Performance.ROGoal = 0;
        }
        if (cbxHREval.Checked)
        {
            objEntityIssue_Performance.HREvaluate = 1;
        }
        else
        {
            objEntityIssue_Performance.HREvaluate = 0;
        }
        if (cbxHRGoal.Checked)
        {
            objEntityIssue_Performance.HRGoal = 1;
        }
        else
        {
            objEntityIssue_Performance.HRGoal = 0;
        }
        if (cbxGMEval.Checked)
        {
            objEntityIssue_Performance.GMEvaluate = 1;
        }
        else
        {
            objEntityIssue_Performance.GMEvaluate = 0;
        }
        if (cbxGMGoal.Checked)
        {
            objEntityIssue_Performance.GMGoal = 1;
        }
        else
        {
            objEntityIssue_Performance.GMGoal = 0;
        }
        if (cbxEvalGoal.Checked)
        {
            objEntityIssue_Performance.EvalutorGoal = 1;
        }
        else
        {
            objEntityIssue_Performance.EvalutorGoal = 0;
        }
        if (ddlEmpDept.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntityIssue_Performance.DeptID = Convert.ToInt32(ddlEmpDept.SelectedItem.Value);
        }
        if (ddlEmpDsgn.SelectedItem.Value != "--SELECT DESIGNATION--")
        {
            objEntityIssue_Performance.DsgnID = Convert.ToInt32(ddlEmpDsgn.SelectedItem.Value);
        }
        if (ddlEvalDept.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntityIssue_Performance.EvalDeptID = Convert.ToInt32(ddlEvalDept.SelectedItem.Value);
        }
        if (ddlEvalDsgn.SelectedItem.Value != "--SELECT DESIGNATION--")
        {
            objEntityIssue_Performance.EvalDsgnID = Convert.ToInt32(ddlEvalDsgn.SelectedItem.Value);
        }
        if (ddlEDD.SelectedItem.Value == "1")
        {
            if (HiddenUsrId.Value != "")
            {
                string[] tokens = HiddenUsrId.Value.Split(',');
                tokens = tokens.Distinct().ToArray();
                for (int i = 0; i < tokens.Count(); i++)
                {

                    int empId = Convert.ToInt32(tokens[i]);
                    clsEntity_Employees_list objentityEmp = new clsEntity_Employees_list();
                    objentityEmp.EmpId = empId;
                    ObjEntityEmployeeList.Add(objentityEmp);
                }
            }
        }
        if (ddlEDD.SelectedItem.Value == "2")
        {
            if (HiddenDeptId.Value != "")
            {
                string[] tokens = HiddenDeptId.Value.Split(',');
                tokens = tokens.Distinct().ToArray();
                for (int i = 0; i < tokens.Count(); i++)
                {

                    int DeptmntId = Convert.ToInt32(tokens[i]);
                    clsEntity_Employees_list objentityEmp = new clsEntity_Employees_list();
                    objentityEmp.DeptId = DeptmntId;
                    ObjEntityEmployeeList.Add(objentityEmp);
                }
            }
        }
        if (ddlEDD.SelectedItem.Value == "3")
        {
            if (HiddenDsgnId.Value != "")
            {
                string[] tokens = HiddenDsgnId.Value.Split(',');
                tokens = tokens.Distinct().ToArray();
                for (int i = 0; i < tokens.Count(); i++)
                {

                    int DsgnId = Convert.ToInt32(tokens[i]);
                    clsEntity_Employees_list objentityEmp = new clsEntity_Employees_list();
                    objentityEmp.DesignationId = DsgnId;
                    ObjEntityEmployeeList.Add(objentityEmp);
                }
            }
        }

        if (ddlEvaluators.SelectedItem.Value == "1")
        {
            if (HiddenEvalId.Value != "")
            {
                string[] tokens = HiddenEvalId.Value.Split(',');
                tokens = tokens.Distinct().ToArray();
                for (int i = 0; i < tokens.Count(); i++)
                {

                    int empId = Convert.ToInt32(tokens[i]);
                    clsEntity_Evaluator_list objentityEmp = new clsEntity_Evaluator_list();
                    objentityEmp.EvaluaterEmpId = empId;
                    ObjEntityEvaluatorList.Add(objentityEmp);
                }
            }
        }
        if (ddlEvaluators.SelectedItem.Value == "2")
        {
            if (HiddenEvalDeptId.Value != "")
            {
                string[] tokens = HiddenEvalDeptId.Value.Split(',');
                tokens = tokens.Distinct().ToArray();
                for (int i = 0; i < tokens.Count(); i++)
                {

                    int DeptmntId = Convert.ToInt32(tokens[i]);
                    clsEntity_Evaluator_list objentityEmp = new clsEntity_Evaluator_list();
                    objentityEmp.EvaluaterDeptId = DeptmntId;
                    ObjEntityEvaluatorList.Add(objentityEmp);
                }
            }
        }
        if (ddlEvaluators.SelectedItem.Value == "3")
        {
            if (HiddenEvalDsgnId.Value != "")
            {
                string[] tokens = HiddenEvalDsgnId.Value.Split(',');
                tokens = tokens.Distinct().ToArray();
                for (int i = 0; i < tokens.Count(); i++)
                {

                    int DsgnId = Convert.ToInt32(tokens[i]);
                    clsEntity_Evaluator_list objentityEmp = new clsEntity_Evaluator_list();
                    objentityEmp.EvaluaterDsgntId = DsgnId;
                    objentityEmp.EvaluaterDsgntId = DsgnId;
                    ObjEntityEvaluatorList.Add(objentityEmp);
                }
            }
        }
        DataTable dtConfirm = objBusiness_Issue_Performance.ReadConfirmPerform(objEntityIssue_Performance);
        if (dtConfirm.Rows.Count > 0)
        {
            Response.Redirect("Emp_Issue_Prfrmnce_Form.aspx?InsUpd=CantConfrm");
        }
        else
        {
            if (clickedButton.ID == "BtnDemoConfirm")
            {
                objBusiness_Issue_Performance.Confirm_PerfrmIssue(objEntityIssue_Performance);
                objBusiness_Issue_Performance.UpdatePerformanceIssue(objEntityIssue_Performance, ObjEntityEmployeeList, ObjEntityEvaluatorList);
                Response.Redirect("Emp_Issue_Prfrmnce_List.aspx?InsUpd=Confrm");
            }
            if (clickedButton.ID == "btnUpdate")
            {
                objBusiness_Issue_Performance.UpdatePerformanceIssue(objEntityIssue_Performance, ObjEntityEmployeeList, ObjEntityEvaluatorList);
                Response.Redirect("Emp_Issue_Prfrmnce_Form.aspx?InsUpd=Upd");
            }
        }
    

    }
    public void View(string strId)
    {
        HiddenConfirm.Value = "1";
        DivContent.Disabled = true;
        ddlFrequency.Enabled = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
        btnConfirm.Visible = false;
        btnClear.Visible = false;
        cbxDMEval.Disabled = true;
        cbxDMGoal.Disabled = true;
        cbxEvalGoal.Disabled = true;
        cbxGMEval.Disabled = true;
        cbxGMGoal.Disabled = true;
        cbxHREval.Disabled = true;
        cbxHRGoal.Disabled = true;
        cbxROEval.Disabled = true;
        cbxROGoal.Disabled = true;
        cbxSelfEval.Disabled = true;
        cbxselGoal.Disabled = true;
        cbxStatus.Disabled = true;
        Performnceload();
        Departmentload();
        Designationload();
        ddlEmpDept.Enabled = false;
        ddlEmpDsgn.Enabled = false;
        ddlEvalDept.Enabled = false;
        ddlEvalDsgn.Enabled = false;
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntity_Issue_Performance objEntityIssue_Performance = new clsEntity_Issue_Performance();
        cls_Business_Issue_performance objBusiness_Issue_Performance = new cls_Business_Issue_performance();
        List<clsEntity_Employees_list> ObjEntityEmployeeList = new List<clsEntity_Employees_list>();
        List<clsEntity_Evaluator_list> ObjEntityEvaluatorList = new List<clsEntity_Evaluator_list>();
        objEntityIssue_Performance.IssueId = Convert.ToInt32(strId);
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityIssue_Performance.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityIssue_Performance.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtService = objBusiness_Issue_Performance.ReadServiceDetailsById(objEntityIssue_Performance);
        if (dtService.Rows.Count > 0)
        {
            if (dtService.Rows[0]["ISSUE_REFNO"].ToString() != "")
            {
                txtRefNo.InnerHtml = dtService.Rows[0]["ISSUE_REFNO"].ToString();
            }
            if (dtService.Rows[0]["ISSUE_DATE"].ToString() != "")
            {
                DateTime dtIssue = objCommon.textToDateTime(dtService.Rows[0]["ISSUE_DATE"].ToString());
                string strDate = dtIssue.ToString("dd-MM-yyyy");
                txtIssuedate.Value = strDate;
                txtIssuedate.Disabled = true;

            }
            if (dtService.Rows[0]["ISSUE_PRFM"].ToString() != "")
            {
                txtIssue.Text = dtService.Rows[0]["ISSUE_PRFM"].ToString();
                txtIssue.Enabled = false;

            }
            if (dtService.Rows[0]["ISSUE_REVNO"].ToString() != "")
            {
                txtRevNo.InnerHtml = dtService.Rows[0]["ISSUE_REVNO"].ToString();
            }
            //evm-0027
            txtReferenceNo.Text = txtRefNo.InnerHtml + "-" + txtRevNo.InnerHtml;
            //end
            if (dtService.Rows[0]["ISSUE_FRQNCY"].ToString() != "" && dtService.Rows[0]["ISSUE_FRQNCY"].ToString() != "0")
            {
                ddlFrequency.ClearSelection();
                ddlFrequency.Items.FindByValue(dtService.Rows[0]["ISSUE_FRQNCY"].ToString()).Selected = true;
                ddlFrequency.Enabled = false;
            }
            if (dtService.Rows[0]["PRFMNC_TMPLT_ID"].ToString() != "")
            {
                ddlTemplte.ClearSelection();
                ddlTemplte.Items.FindByValue(dtService.Rows[0]["PRFMNC_TMPLT_ID"].ToString()).Selected = true;
                ddlTemplte.Enabled = false;
            }
            if (dtService.Rows[0]["ISSUE_EMP"].ToString() != "")
            {
                ddlEDD.ClearSelection();
                ddlEDD.Items.FindByValue(dtService.Rows[0]["ISSUE_EMP"].ToString()).Selected = true;
                ddlEDD.Enabled = false;
            }
            if (dtService.Rows[0]["ISSUE_EVAL"].ToString() != "")
            {
                ddlEvaluators.ClearSelection();
                ddlEvaluators.Items.FindByValue(dtService.Rows[0]["ISSUE_EVAL"].ToString()).Selected = true;
                ddlEvaluators.Enabled = false;
            }
            if (dtService.Rows[0]["ISSUE_STATS"].ToString() == "0")
            {
                cbxStatus.Checked = false;
            }
            else
            {
                cbxStatus.Checked = true;
            }
            if (dtService.Rows[0]["ISSUE_SELF_EVLTOR"].ToString() == "0")
            {
                cbxSelfEval.Checked = false;
            }
            else
            {
                cbxSelfEval.Checked = true;
            }
            if (dtService.Rows[0]["ISSUE_SELF_EVLTOR_GOAL"].ToString() == "0")
            {
                cbxselGoal.Checked = false;
            }
            else
            {
                cbxselGoal.Checked = true;
            }
            if (dtService.Rows[0]["ISSUE_RO_EVLTOR"].ToString() == "0")
            {
                cbxROEval.Checked = false;
            }
            else
            {
                cbxROEval.Checked = true;
            }
            if (dtService.Rows[0]["ISSUE_RO_EVLTOR_GOAL"].ToString() == "0")
            {
                cbxROGoal.Checked = false;
            }
            else
            {
                cbxROGoal.Checked = true;
            }
            if (dtService.Rows[0]["ISSUE_DM_EVLTOR"].ToString() == "0")
            {
                cbxDMEval.Checked = false;
            }
            else
            {
                cbxDMEval.Checked = true;
            }
            if (dtService.Rows[0]["ISSUE_DM_EVLTOR_GOAL"].ToString() == "0")
            {
                cbxDMGoal.Checked = false;
            }
            else
            {
                cbxDMGoal.Checked = true;

            }
            if (dtService.Rows[0]["ISSUE_HR_EVLTOR"].ToString() == "0")
            {
                cbxHREval.Checked = false;
            }
            else
            {
                cbxHREval.Checked = true;
            }
            if (dtService.Rows[0]["ISSUE_HR_EVLTOR_GOAL"].ToString() == "0")
            {
                cbxHRGoal.Checked = false;
            }
            else
            {
                cbxHRGoal.Checked = true;
            }
            if (dtService.Rows[0]["ISSUE_GM_EVLTOR"].ToString() == "0")
            {
                cbxGMEval.Checked = false;
            }
            else
            {
                cbxGMEval.Checked = true;
            }
            if (dtService.Rows[0]["ISSUE_GM_EVLTOR_GOAL"].ToString() == "0")
            {
                cbxGMGoal.Checked = false;
            }
            else
            {
                cbxGMGoal.Checked = true;
            }
            //if (dtService.Rows[0]["ISSUE_EMPDEPT"].ToString() != "" )
            //{
            //    ddlEmpDept.ClearSelection();
            //    ddlEmpDept.Items.FindByValue(dtService.Rows[0]["ISSUE_EMPDEPT"].ToString()).Selected = true;
            //}
            //if (dtService.Rows[0]["ISSUE_EMPDSGN"].ToString() != "" )
            //{
            //    ddlEmpDsgn.ClearSelection();
            //    ddlEmpDsgn.Items.FindByValue(dtService.Rows[0]["ISSUE_EMPDSGN"].ToString()).Selected = true;
            //}
            //if (dtService.Rows[0]["ISSUE_EVLDEPT"].ToString() != "")
            //{
            //    ddlEvalDept.ClearSelection();
            //    ddlEvalDept.Items.FindByValue(dtService.Rows[0]["ISSUE_EVLDEPT"].ToString()).Selected = true;
            //}
            //if (dtService.Rows[0]["ISSUE_EVLDSGN"].ToString() != "")
            //{
            //    ddlEmpDsgn.ClearSelection();
            //    ddlEmpDsgn.Items.FindByValue(dtService.Rows[0]["ISSUE_EVLDSGN"].ToString()).Selected = true;
            //}
        }


        DataTable dtDetail1 = new DataTable();
        dtDetail1.Columns.Add("IEVLTR_ID", typeof(int));
        dtDetail1.Columns.Add("IISSUE_ID", typeof(int));
        dtDetail1.Columns.Add("IUSR_ID", typeof(int));
        dtDetail1.Columns.Add("IDEPT_ID", typeof(int));
        dtDetail1.Columns.Add("IDESGN_ID", typeof(int));
        dtDetail1.Columns.Add("IGOAL", typeof(int));
        dtDetail1.Columns.Add("IDEPT", typeof(string));
        dtDetail1.Columns.Add("IDESGN", typeof(string));
        dtDetail1.Columns.Add("IUSR", typeof(string));
        DataTable dtIssueEval = objBusiness_Issue_Performance.ReadEvaluatorsById(objEntityIssue_Performance);

        for (int intcnt = 0; intcnt < dtIssueEval.Rows.Count; intcnt++)
        {
            DataRow drDtl = dtDetail1.NewRow();
            drDtl["IEVLTR_ID"] = Convert.ToInt32(dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_ID"].ToString());
            drDtl["IISSUE_ID"] = Convert.ToInt32(dtIssueEval.Rows[intcnt]["ISSUE_ID"].ToString());
            if (dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_USR_ID"].ToString() != "")
            {
                drDtl["IUSR_ID"] = dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_USR_ID"].ToString();
                drDtl["IUSR"] = dtIssueEval.Rows[intcnt]["USR_NAME"].ToString();
                if (HiddenEvalId.Value == "")
                {
                    HiddenEvalId.Value = dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_USR_ID"].ToString();
                }
                else
                {
                    HiddenEvalId.Value += "," + dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_USR_ID"].ToString();
                }

            }
            if (dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_DEPTID"].ToString() != "")
            {
                drDtl["IDEPT_ID"] = dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_DEPTID"].ToString();
                drDtl["IDEPT"] = dtIssueEval.Rows[intcnt]["CPRDEPT_NAME"].ToString();
                if (HiddenEvalDeptId.Value == "")
                {
                    HiddenEvalDeptId.Value = dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_DEPTID"].ToString();
                }
                else
                {
                    HiddenEvalDeptId.Value += "," + dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_DEPTID"].ToString();
                }

            }
            if (dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_DSGNID"].ToString() != "")
            {
                drDtl["IDESGN_ID"] = Convert.ToInt32(dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_DSGNID"].ToString());
                drDtl["IDESGN"] = dtIssueEval.Rows[intcnt]["DSGN_NAME"].ToString();
                if (HiddenEvalDsgnId.Value == "")
                {
                    HiddenEvalDsgnId.Value = dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_DSGNID"].ToString();
                }
                else
                {
                    HiddenEvalDsgnId.Value += "," + dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_DSGNID"].ToString();
                }
            }
            drDtl["IGOAL"] = Convert.ToInt32(dtIssueEval.Rows[intcnt]["ISSUE_ID"].ToString());
            if (dtIssueEval.Rows[intcnt]["ISSUE_EVLTR_GOAL"].ToString() == "1")
            {
                cbxEvalGoal.Checked = true;
            }
            else
            {
                cbxEvalGoal.Checked = false;
            }

            dtDetail1.Rows.Add(drDtl);
        }
        string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail1);
        HiddenEditEval.Value = strJson;


        DataTable dtDetail = new DataTable();
        dtDetail.Columns.Add("ISSUE_EMP_ID", typeof(int));
        dtDetail.Columns.Add("ISSUE_ID", typeof(int));
        dtDetail.Columns.Add("USR_ID", typeof(int));
        dtDetail.Columns.Add("DEPT_ID", typeof(int));
        dtDetail.Columns.Add("DESGN_ID", typeof(int));
        dtDetail.Columns.Add("DEPT", typeof(string));
        dtDetail.Columns.Add("DESGN", typeof(string));
        dtDetail.Columns.Add("USR", typeof(string));
        DataTable dtIssueEmp = objBusiness_Issue_Performance.ReadEmployeeById(objEntityIssue_Performance);

        for (int intcnt = 0; intcnt < dtIssueEmp.Rows.Count; intcnt++)
        {
            DataRow drDtl = dtDetail.NewRow();
            drDtl["ISSUE_EMP_ID"] = Convert.ToInt32(dtIssueEmp.Rows[intcnt]["ISSUE_EMP_ID"].ToString());
            drDtl["ISSUE_ID"] = Convert.ToInt32(dtIssueEmp.Rows[intcnt]["ISSUE_ID"].ToString());
            if (dtIssueEmp.Rows[intcnt]["ISSUE_EMP_USR_ID"].ToString() != "")
            {
                drDtl["USR_ID"] = dtIssueEmp.Rows[intcnt]["ISSUE_EMP_USR_ID"].ToString();
                drDtl["USR"] = dtIssueEmp.Rows[intcnt]["USR_NAME"].ToString();
                if (HiddenUsrId.Value == "")
                {
                    HiddenUsrId.Value = dtIssueEmp.Rows[intcnt]["ISSUE_EMP_USR_ID"].ToString();
                }
                else
                {
                    HiddenUsrId.Value += "," + dtIssueEmp.Rows[intcnt]["ISSUE_EMP_USR_ID"].ToString();
                }
            }
            if (dtIssueEmp.Rows[intcnt]["ISSUE_EMP_DEPT_ID"].ToString() != "")
            {
                drDtl["DEPT_ID"] = dtIssueEmp.Rows[intcnt]["ISSUE_EMP_DEPT_ID"].ToString();
                drDtl["DEPT"] = dtIssueEmp.Rows[intcnt]["CPRDEPT_NAME"].ToString();
                if (HiddenDeptId.Value == "")
                {
                    HiddenDeptId.Value = dtIssueEmp.Rows[intcnt]["ISSUE_EMP_DEPT_ID"].ToString();
                }
                else
                {
                    HiddenDeptId.Value += "," + dtIssueEmp.Rows[intcnt]["ISSUE_EMP_DEPT_ID"].ToString();
                }
            }
            if (dtIssueEmp.Rows[intcnt]["ISSUE_EMP_DESGN_ID"].ToString() != "")
            {
                drDtl["DESGN_ID"] = Convert.ToInt32(dtIssueEmp.Rows[intcnt]["ISSUE_EMP_DESGN_ID"].ToString());
                drDtl["DESGN"] = dtIssueEmp.Rows[intcnt]["DSGN_NAME"].ToString();
                if (HiddenDsgnId.Value == "")
                {
                    HiddenDsgnId.Value = dtIssueEmp.Rows[intcnt]["ISSUE_EMP_DESGN_ID"].ToString();
                }
                else
                {
                    HiddenDsgnId.Value += "," + dtIssueEmp.Rows[intcnt]["ISSUE_EMP_DESGN_ID"].ToString();
                }
            }
            dtDetail.Rows.Add(drDtl);
        }
        //Departmentload();
        //Designationload();
       // Employeeload();


        string strJson1 = DataTableToJSONWithJavaScriptSerializer(dtDetail);
        HiddenEditEmp.Value = strJson1;

    }
    [WebMethod]
    public static string RemoveEmp(string strTable, string rowid, string IssueId)
    {
        clsEntity_Issue_Performance objEntityIssue_Performance = new clsEntity_Issue_Performance();
        cls_Business_Issue_performance objBusiness_Issue_Performance = new cls_Business_Issue_performance();
        string strRet = "success";
       
        if (strTable == "TableSelectedEmp")
        {
            objEntityIssue_Performance.EmpID = Convert.ToInt32(rowid);
        }
        else if (strTable == "TableSelectedDept")
        {
            objEntityIssue_Performance.DeptID = Convert.ToInt32(rowid);
        }
        else if (strTable == "TableSelectedDsgn")
        {
            objEntityIssue_Performance.DsgnID = Convert.ToInt32(rowid);
        }
        if (IssueId != "")
        {
            objEntityIssue_Performance.IssueId = Convert.ToInt32(IssueId);
        }
            objBusiness_Issue_Performance.RemovePerform(objEntityIssue_Performance);
        return strRet;
    }
    [WebMethod]
    public static string RemoveEvaltorEmp(string strTable, string rowid, string IssueId)
    {
        clsEntity_Issue_Performance objEntityIssue_Performance = new clsEntity_Issue_Performance();
        cls_Business_Issue_performance objBusiness_Issue_Performance = new cls_Business_Issue_performance();
        string strRet = "success";

        if (strTable == "TableSelectEval")
        {
            objEntityIssue_Performance.EvalEmpID = Convert.ToInt32(rowid);
        }
        else if (strTable == "TableselEvalDept")
        {
            objEntityIssue_Performance.EvalDeptID = Convert.ToInt32(rowid);
        }
        else if (strTable == "TableselEvalDsgn")
        {
            objEntityIssue_Performance.EvalDsgnID = Convert.ToInt32(rowid);
        }
        if (IssueId != "")
        {
            objEntityIssue_Performance.IssueId = Convert.ToInt32(IssueId);
        }
            objBusiness_Issue_Performance.RemoveEvalEmp(objEntityIssue_Performance);
        return strRet;
    }
  
    protected void ddlEvalDept_SelectedIndexChanged(object sender, EventArgs e)
    {

        clsEntity_Issue_Performance objEntityIssue_Performance = new clsEntity_Issue_Performance();
        cls_Business_Issue_performance objBusiness_Issue_Performance = new cls_Business_Issue_performance();
        int intCorpId = 0;
        DataTable dtEmpl = new DataTable();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityIssue_Performance.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityIssue_Performance.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (ddlEvalDept.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntityIssue_Performance.DeptID = Convert.ToInt32(ddlEvalDept.SelectedItem.Value);
        }
        if (ddlEvalDsgn.SelectedItem.Value != "--SELECT DESIGNATION--")
        {
            objEntityIssue_Performance.DsgnID = Convert.ToInt32(ddlEvalDsgn.SelectedItem.Value);
        }
        if (ddlEvalDept.SelectedItem.Value != "--SELECT DEPARTMENT--" || ddlEvalDsgn.SelectedItem.Value != "--SELECT DESIGNATION--")
        {
            dtEmpl = objBusiness_Issue_Performance.ReadEmployee(objEntityIssue_Performance);
        }
        string strPrinEvalEmp = ConvertDataTableEvalEmp(dtEmpl);
        DivEvaluator.InnerHtml = strPrinEvalEmp;
        ScriptManager.RegisterStartupScript(this, GetType(), "searchChange", "searchChange();", true);
    }
    protected void ddlEmpDept_SelectedIndexChanged(object sender, EventArgs e)
    {

        clsEntity_Issue_Performance objEntityIssue_Performance = new clsEntity_Issue_Performance();
        cls_Business_Issue_performance objBusiness_Issue_Performance = new cls_Business_Issue_performance();
        DataTable dtEmpl = new DataTable();
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityIssue_Performance.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityIssue_Performance.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (ddlEmpDept.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntityIssue_Performance.DeptID = Convert.ToInt32(ddlEmpDept.SelectedItem.Value);
        }
        if (ddlEmpDsgn.SelectedItem.Value != "--SELECT DESIGNATION--")
        {
            objEntityIssue_Performance.DsgnID = Convert.ToInt32(ddlEmpDsgn.SelectedItem.Value);
        }
        if (ddlEmpDept.SelectedItem.Value != "--SELECT DEPARTMENT--" || ddlEmpDsgn.SelectedItem.Value != "--SELECT DESIGNATION--")
        {
             dtEmpl = objBusiness_Issue_Performance.ReadEmployee(objEntityIssue_Performance);
        }
        string strPrintReport = ConvertDataTable(dtEmpl);
        divEmpList.InnerHtml = strPrintReport;
        ScriptManager.RegisterStartupScript(this, GetType(), "searchChange", "searchChange();", true);
    }
}