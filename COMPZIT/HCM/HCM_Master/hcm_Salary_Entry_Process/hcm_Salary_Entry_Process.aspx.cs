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

public partial class HCM_HCM_Master_hcm_Salary_Entry_Process_hcm_Salary_Entry_Process : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DepartmentLoad();
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
                }
            }
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            }
            // for adding comma
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
            }   
     
                divButtons.Visible = false;
                ddlDepartment.Focus();
                StringBuilder sb = new StringBuilder();
                sb.Append("<div class=\"col-lg-12 table-responsive\" style=\"background-color:#FFF;padding-top:14px;clear:both;\">");
                sb.Append("<table id=\"tableMain\" class=\"table table-bordered table-responsive\" style=\"font-size:13px;margin-bottom: 14px;\">");
                sb.Append("<thead><tr><th style=\"width:20.5%;padding:8px 13px;\">Employee Code</th><th style=\"width:24.7%;\">Employee</th><th style=\"width:24.4%;\">Pay Grade</th><th style=\"width:30.4%;\">Basic Pay</th></tr></thead>");
                sb.Append("<tbody>");
                sb.Append("<tr>");
                sb.Append("<td colspan=\"4\" style=\"padding:0;\">No data available</td>");
                sb.Append("</tr>");
                sb.Append("</tbody>");
                sb.Append("</table>");
                sb.Append("</div>");
                divEmployeeTable.InnerHtml = sb.ToString();
              
            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                }
            }
        }

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


   
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        try
        {
            divButtons.Visible = false;
            clsEntitySalaryEntryProcess objentityPassport = new clsEntitySalaryEntryProcess();
            clsBusinessSalaryEntryProcess objBussinesspasprt = new clsBusinessSalaryEntryProcess();
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
            //if (radioEmpCode.Checked == true)
            //{
                objentityPassport.SortBy = 1;
            //}
            DataTable dtEmployee = objBussinesspasprt.ReadEmployeeTableList(objentityPassport);
            DataTable dtPayGrade = PayGradeLoad();
            sb.Append("<div class=\"col-lg-12 table-responsive\" style=\"background-color:#FFF;padding-top:14px;clear:both;\">");
            if (dtEmployee.Rows.Count > 0 && dtPayGrade.Rows.Count>0)
            {
                divButtons.Visible = true;
                sb.Append("<input type=\"text\" id=\"myInput\" onkeyup=\"myFunction()\" onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" placeholder=\"Search by employee/employee code\" />");
            }
            sb.Append("<table id=\"tableMain\" class=\"table table-bordered table-responsive\" style=\"font-size:13px;margin-bottom: 14px;\">");
            sb.Append("<thead><tr><th id=\"thsl\" style=\"width:20.5%;padding:8px 13px;cursor:pointer;\">Employee Code<i style=\"float:right;cursor:pointer;\" id=\"sl\" class=\"glyphicon glyphicon-arrow-down\"></i></th><th id=\"thnm\" style=\"width:24.7%;cursor:pointer;\">Employee<i style=\"float:right;cursor:pointer;\" id=\"nm\" class=\"glyphicon glyphicon-arrow-down\"></i></th><th style=\"width:24.4%;\">Pay Grade</th><th style=\"width:30.4%;\">Basic Pay</th></tr></thead>");
            sb.Append("<tbody>");
            for (int intcnt = 0; intcnt < dtEmployee.Rows.Count; intcnt++)
            {
                string EmpName = dtEmployee.Rows[intcnt]["USR_NAME"].ToString();
                string EmpId = dtEmployee.Rows[intcnt]["USR_ID"].ToString();
                string EmpCode = dtEmployee.Rows[intcnt]["USR_CODE"].ToString();
                string DsgnId = dtEmployee.Rows[intcnt]["DSGN_ID"].ToString();

                clsBusinessLayerEmpSalary objEmpSalary = new clsBusinessLayerEmpSalary();
                clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
                objEntityEmpSlary.EmpSalaryId = Convert.ToInt32(EmpId);
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                     objEntityEmpSlary.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                string strEmplCheck = "";
                strEmplCheck = objEmpSalary.EpmlyCheckPayGrade(objEntityEmpSlary);
                if (strEmplCheck != "" && strEmplCheck != "0")
                {
                    DataTable dtSlry = objEmpSalary.ReadSalaryByEmpId(objEntityEmpSlary);
                    if (dtSlry.Rows.Count > 0)
                    {
                        //HiddenRestrctRange.Value = dtSlry.Rows[0]["PYGRD_RANGE_FRM"].ToString() + "," + dtSlry.Rows[0]["PYGRD_RANGE_TO"].ToString() + "," + dtSlry.Rows[0]["PYGRD_RANGE_RESTRICT_STS"].ToString();                      
                        objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(dtSlry.Rows[0]["PYGRD_ID"].ToString());
                        DataTable dtSubConrt = objEmpSalary.ReadAddnLoad(objEntityEmpSlary);
                        DataTable dtSubConrt2 = objEmpSalary.ReadDedctnLoad(objEntityEmpSlary);
                        string rowSpanCount = (dtSubConrt.Rows.Count + dtSubConrt2.Rows.Count ).ToString();
                        DataTable dtCrncy = objEmpSalary.ReadPayGradeCrncy(objEntityEmpSlary);
                        string currncy = "";
                        if (dtCrncy.Rows.Count > 0)
                        {
                            currncy = dtCrncy.Rows[0][0].ToString();
                        }

                        sb.Append("<tr>");
                        sb.Append("<td style=\"display:none;\">" + EmpId + "</td>");
                        sb.Append("<td style=\"display:none;\">" + EmpName + "</td>");
                        sb.Append("<td style=\"display:none;\">" + EmpCode + "</td>");
                        sb.Append("<td id=\"SalaryId" + EmpId + "\" style=\"display:none;\">" + dtSlry.Rows[0]["SLRY_ID"].ToString() + "</td>");
                        sb.Append("<td id=\"PayGradeIdSaved" + EmpId + "\" style=\"display:none;\">" + dtSlry.Rows[0]["PYGRD_ID"].ToString() + "</td>");
                        sb.Append("<td id=\"OldValue" + EmpId + "\" style=\"display:none;\">" + dtSlry.Rows[0]["PYGRD_ID"].ToString() + "</td>");
                        sb.Append("<td style=\"width:100%;\" colspan=\"4\" style=\"padding: 0px 0px !important;\">");
                        sb.Append("<table id=\"tableEmp" + EmpId + "\" class=\"table table-bordered\" style=\"font-size:13px;background-color: #f6f6f6;margin-bottom: 0px;border: 2px solid #ddd;\">");
                        sb.Append("<tr>");
                        sb.Append("<th style=\"width:20%;\">" + EmpCode + "</th>");
                        sb.Append("<th style=\"width:25%;\">" + EmpName + "</th>");
                        sb.Append("<td style=\"width:25%;\"> <select style=\"width:88%;float:left;\" id=\"ddlPayGrade" + EmpId + "\" onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" class=\"form-control\" onchange=\"return changePayGrade(" + EmpId + ");\"> <option>-Select-</option>");
                        int flagS = 0;
                        foreach (DataRow dr in dtPayGrade.Rows)
                        {
                            if (dtSlry.Rows[0]["PYGRD_ID"].ToString() == dr["PYGRD_ID"].ToString())
                            {
                                sb.Append("<option selected value=\"" + dr["PYGRD_ID"].ToString() + "\">" + dr["PYGRD_NAME"].ToString() + "</option>");
                                flagS = 1;
                            }
                            else
                            {
                                sb.Append("<option value=\"" + dr["PYGRD_ID"].ToString() + "\">" + dr["PYGRD_NAME"].ToString() + "</option>");
                            }                           
                        }
                        if (flagS == 0)
                        {
                            sb.Append("<option selected value=\"" + dtSlry.Rows[0]["PYGRD_ID"].ToString() + "\">" + dtSlry.Rows[0]["PYGRD_NAME"].ToString() + "</option>");
                        }
                        sb.Append("</select><label id=\"Currency" + EmpId + "\" style=\"float:right;margin-top: 2%;font-weight: 600;\">" + currncy + "</label></td>");
                        sb.Append("<td style=\"width:15%;\"><input id=\"txtBasicPay" + EmpId + "\" style=\"text-align:right;\" maxlength=12 onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeAmount(" + EmpId + ",'','txtBasicPay');\" type=\"text\"  class=\"form-control\" value=\"" + dtSlry.Rows[0]["AMOUNTFRM"].ToString() + "\" /></td>");
                        if (dtSubConrt.Rows.Count == 0 && dtSubConrt2.Rows.Count == 0)
                        {
                            sb.Append("<td id=\"tdSave" + EmpId + "\" style=\"width:15%;\"><button id=\"btnadd" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return SaveEmpData(" + EmpId + ");\">UPDATE</button><button id=\"btnCncl" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return CancelEmpData(" + EmpId + ");\">CANCEL</button></td>");
                        }
                        else
                        {
                            sb.Append("<td rowspan=\"" + rowSpanCount + "\" onclick=\"return ShowHide(" + EmpId + ");\"  style=\"width:15%;cursor:pointer;\"><i style=\"float:right;cursor:pointer;\" id=\"show" + EmpId + "\"  class=\"glyphicon glyphicon-chevron-down\"></i></td>");
                        }
                        sb.Append("</tr>");
                        //Start:-For additions & deductions
                        int i = 1;
                       
                        foreach (DataRow dr in dtSubConrt.Rows)
                        {
                            string TableId = "", Amount = "", PerOrAmntck = "0";
                            objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(dr["PGALLCE_ID"].ToString());
                            objEntityEmpSlary.User_Id = Convert.ToInt32(EmpId);
                            DataTable dtAllwce = objEmpSalary.ReadAllounceByAddId(objEntityEmpSlary);


                            if (dtAllwce.Rows.Count > 0)
                            {
                                TableId = dtAllwce.Rows[0]["SLRYALLCE_ID"].ToString();
                                Amount = dtAllwce.Rows[0]["AMOUNTFRM"].ToString();

                                //Evm-0023-25-2
                                if (Convert.ToInt32(dtAllwce.Rows[0]["SLRYALLCE_AMNT_PERCTGE_CHCK"].ToString()) == 1)
                                {
                                    Amount = dtAllwce.Rows[0]["PERC"].ToString();
                                }
                                PerOrAmntck = dtAllwce.Rows[0]["SLRYALLCE_AMNT_PERCTGE_CHCK"].ToString();
                            }
                            else
                            {
                                objEntityEmpSlary.SalaryMode = 0; //Allwnc
                                DataTable dtAmtORPercCheckAllwc = objEmpSalary.ReadAmtPercSts(objEntityEmpSlary);
                                PerOrAmntck = dtAmtORPercCheckAllwc.Rows[0]["AMNT_PERCTGE_CHCK"].ToString();
                            }

                            if (i == 1)
                            {
                                sb.Append("<tr style=\"display:none;\">");
                                sb.Append("<td style=\"display:none;\">" + dr["PGALLCE_ID"].ToString() + "</td>");
                                sb.Append("<td style=\"display:none;\">Add</td>");
                                sb.Append("<td style=\"display:none;\">" + TableId + "</td>");
                                sb.Append("<th rowspan=\"" + dtSubConrt.Rows.Count + "\" style=\"width:20%;\">Additions</th>");

                                //evm-0023-25-2
                                sb.Append("<td style=\"width:20%;\">");
                                if (PerOrAmntck == "1")
                                {
                                    sb.Append("<div style=\"width:100%;float:left;border: 1px solid #cecccc;\">");
                                    sb.Append("<input disabled  id=\"radioAmt" + EmpId + dr["PGALLCE_ID"].ToString() + "\"  name=\"RadioGroup1" + EmpId + dr["PGALLCE_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroupAllwnce(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 3%;\" for=\"Amount\">Amount</label>");
                                    sb.Append("<input checked style=\"margin-left: 7%;\" checked id=\"radioPerc" + EmpId + dr["PGALLCE_ID"].ToString() + "\" name=\"RadioGroup1" + EmpId + dr["PGALLCE_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroupAllwnce(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 3%;\" for=\"Percentage\">Percentage</label>");
                                    sb.Append("</div>");
                                }
                                else
                                {
                                    sb.Append("<div style=\"width:100%;float:left;border: 1px solid #cecccc;\">");
                                    sb.Append("<input checked  id=\"radioAmt" + EmpId + dr["PGALLCE_ID"].ToString() + "\"  name=\"RadioGroup1" + EmpId + dr["PGALLCE_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroupAllwnce(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 3%;\" for=\"Amount\">Amount</label>");
                                    sb.Append("<input disabled style=\"margin-left: 7%;\" id=\"radioPerc" + EmpId + dr["PGALLCE_ID"].ToString() + "\" name=\"RadioGroup1" + EmpId + dr["PGALLCE_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroupAllwnce(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 3%;\" for=\"Percentage\">Percentage</label>");
                                    sb.Append("</div>");
                                }
                                sb.Append("</td>");



                                sb.Append("<td style=\"width:25%;\">" + dr["PAYRL_NAME"].ToString() + "</td>");
                                sb.Append("<td  style=\"width:15%;border-right: 1px solid #ddd;\"><input style=\"text-align:right;\" id=\"txtAmntAdd" + EmpId + dr["PGALLCE_ID"].ToString() + "\" maxlength=12 onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeAmount(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ",'txtAmntAdd');\" type=\"text\"  class=\"form-control\" value=\"" + Amount + "\" /></td>");
                                if (i==dtSubConrt.Rows.Count && dtSubConrt2.Rows.Count == 0)
                                {
                                    sb.Append("<td id=\"tdSave" + EmpId + "\" style=\"width:15%;border-top: none;\"><button id=\"btnadd" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return SaveEmpData(" + EmpId + ");\">UPDATE</button><button id=\"btnCncl" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return CancelEmpData(" + EmpId + ");\">CANCEL</button></td>");
                                }
                                sb.Append("</tr>");
                            }
                            else
                            {
                                sb.Append("<tr style=\"display:none;\">");
                                sb.Append("<td style=\"display:none;\">" + dr["PGALLCE_ID"].ToString() + "</td>");
                                sb.Append("<td style=\"display:none;\">Add</td>");
                                sb.Append("<td style=\"display:none;\">" + TableId + "</td>");

                                //evm-0023-25-2
                                sb.Append("<td style=\"width:20%;\">");
                                if (PerOrAmntck == "1")
                                {
                                    sb.Append("<div style=\"width:100%;float:left;border: 1px solid #cecccc;\">");
                                    sb.Append("<input  disabled id=\"radioAmt" + EmpId + dr["PGALLCE_ID"].ToString() + "\"  name=\"RadioGroup1" + EmpId + dr["PGALLCE_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroupAllwnce(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 3%;\" for=\"Amount\">Amount</label>");
                                    sb.Append("<input checked style=\"margin-left: 7%;\"  id=\"radioPerc" + EmpId + dr["PGALLCE_ID"].ToString() + "\" name=\"RadioGroup1" + EmpId + dr["PGALLCE_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroupAllwnce(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 3%;\" for=\"Percentage\">Percentage</label>");
                                    sb.Append("</div>");
                                   
                                }
                                else
                                {
                                    sb.Append("<div style=\"width:100%;float:left;border: 1px solid #cecccc;\">");
                                    sb.Append("<input checked  id=\"radioAmt" + EmpId + dr["PGALLCE_ID"].ToString() + "\"  name=\"RadioGroup1" + EmpId + dr["PGALLCE_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroupAllwnce(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 3%;\" for=\"Amount\">Amount</label>");
                                    sb.Append("<input disabled style=\"margin-left: 7%;\" id=\"radioPerc" + EmpId + dr["PGALLCE_ID"].ToString() + "\" name=\"RadioGroup1" + EmpId + dr["PGALLCE_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroupAllwnce(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 3%;\" for=\"Percentage\">Percentage</label>");
                                    sb.Append("</div>");
                                }
                                sb.Append("</td>");




                                sb.Append("<td style=\"width:25%;\">" + dr["PAYRL_NAME"].ToString() + "</td>");
                                sb.Append("<td  style=\"width:15%;border-right: 1px solid #ddd;\"><input style=\"text-align:right;\" id=\"txtAmntAdd" + EmpId + dr["PGALLCE_ID"].ToString() + "\" maxlength=12 onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeAmount(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ",'txtAmntAdd');\" type=\"text\"  class=\"form-control\" value=\"" + Amount + "\" /></td>");
                                if (i == dtSubConrt.Rows.Count && dtSubConrt2.Rows.Count == 0)
                                {
                                    sb.Append("<td  id=\"tdSave" + EmpId + "\" style=\"width:15%;border-top: none;\"><button id=\"btnadd" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return SaveEmpData(" + EmpId + ");\">UPDATE</button><button id=\"btnCncl" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return CancelEmpData(" + EmpId + ");\">CANCEL</button></td>");
                                }
                                sb.Append("</tr>");
                            }

                            i++;
                        }
                        i = 1;
                        foreach (DataRow dr in dtSubConrt2.Rows)
                        {

                            string TableId = "", Amount = "", BasicOrTotl = "0", PerOrAmntck="0";
                            objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(dr["PGDEDTN_ID"].ToString());
                            objEntityEmpSlary.User_Id = Convert.ToInt32(EmpId);
                            DataTable dtAllwce = objEmpSalary.ReadDedctnByDedId(objEntityEmpSlary);

                           
                            DataTable dtAmtORPercCheck = objEmpSalary.ReadAmtPercSts(objEntityEmpSlary);

                            if (dtAllwce.Rows.Count > 0)
                            {
                                TableId = dtAllwce.Rows[0]["SLRYDEDTN_ID"].ToString();
                                Amount = dtAllwce.Rows[0]["AMOUNTFRM"].ToString();
                                if (Convert.ToInt32(dtAllwce.Rows[0]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString()) == 1)
                                {
                                    Amount = dtAllwce.Rows[0]["PERC"].ToString();
                                }
                                BasicOrTotl = dtAllwce.Rows[0]["SLRYDEDTN_BASIC_OR_TOTAL_AMNT"].ToString();
                                PerOrAmntck = dtAllwce.Rows[0]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString();                             
                            }
                            else
                            {
                                objEntityEmpSlary.SalaryMode = 1; //Deduction
                                DataTable dtAmtORPercCheckDedct = objEmpSalary.ReadAmtPercSts(objEntityEmpSlary);
                                PerOrAmntck = dtAmtORPercCheckDedct.Rows[0]["AMNT_PERCTGE_CHCK"].ToString();
                            }

                            if (i == 1)
                            {
                                sb.Append("<tr style=\"display:none;\">");
                                sb.Append("<td style=\"display:none;\">" + dr["PGDEDTN_ID"].ToString() + "</td>");
                                sb.Append("<td style=\"display:none;\">Ded</td>");
                                sb.Append("<td style=\"display:none;\">" + TableId + "</td>");
                                sb.Append("<th rowspan=\"" + dtSubConrt2.Rows.Count + "\" style=\"width:20%;\">Deductions</th>");
                                sb.Append("<td style=\"width:20%;\">");
                                if (PerOrAmntck == "1")
                                {
                                    sb.Append("<div style=\"width:100%;float:left;border: 1px solid #cecccc;\">");
                                    sb.Append("<input disabled  id=\"radio1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  name=\"RadioGroup1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroup1(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 3%;\" for=\"Amount\">Amount</label>");
                                    sb.Append("<input style=\"margin-left: 7%;\" checked id=\"radio2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" name=\"RadioGroup1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroup1(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 3%;\" for=\"Percentage\">Percentage</label>");
                                    sb.Append("</div>");
                                    sb.Append("<div id=\"divRadio" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" style=\"width:100%;float:left;border: 1px solid #cecccc;\"><label style=\"width: 100%;margin-top: 1%;margin-left: 2%;font-weight: 600;\">Percentage Deducted From </label>");
                                    if (BasicOrTotl == "1")
                                    {
                                        sb.Append("<input onchange=\"changeRadioGroup2(" + EmpId + ")();\" style=\"margin-top: 0%;\"  id=\"radio3" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 0.5%;\" for=\"BasicPay\">Basic Pay</label>");
                                        sb.Append("<input onchange=\"changeRadioGroup2(" + EmpId + ")();\" style=\"margin-top: 0%;margin-left: 5%;\" checked id=\"radio4" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\"  type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 0.5%;\" for=\"TotalAmount\">Total Amount</label>");
                                    }
                                    else
                                    {
                                        sb.Append("<input checked id=\"radio3" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" style=\"margin-top: 0%;\"  name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" onchange=\"changeRadioGroup2(" + EmpId + ")();\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 0.5%;\" for=\"BasicPay\">Basic Pay</label>");
                                        sb.Append("<input  style=\"margin-left: 5%;margin-top: 0%;\"  id=\"radio4" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" onchange=\"changeRadioGroup2(" + EmpId + ")();\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\"  type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 0.5%;\" for=\"TotalAmount\">Total Amount</label>");
                                    }
                                    sb.Append("</div>");
                                }
                                else
                                {
                                    sb.Append("<div style=\"width:100%;float:left;border: 1px solid #cecccc;\">");
                                    sb.Append("<input checked  id=\"radio1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  name=\"RadioGroup1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroup1(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 3%;\" for=\"Amount\">Amount</label>");
                                    sb.Append("<input disabled style=\"margin-left: 7%;\" id=\"radio2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" name=\"RadioGroup1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroup1(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 3%;\" for=\"Percentage\">Percentage</label>");
                                    sb.Append("</div>");
                                    sb.Append("<div id=\"divRadio" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" style=\"width:100%;float:left;border: 1px solid #cecccc;display:none;\"><label style=\"width: 100%;margin-top: 1%;margin-left: 2%;font-weight: 600;\">Percentage Deducted From </label>");
                                    sb.Append("<input checked id=\"radio3" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" style=\"margin-top: 0%;\"  name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" type=\"radio\" onchange=\"changeRadioGroup2(" + EmpId + ")();\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 0.5%;\" for=\"BasicPay\">Basic Pay</label>");
                                    sb.Append("<input style=\"margin-left: 5%;margin-top: 0%;\" id=\"radio4" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"changeRadioGroup2(" + EmpId + ")();\"  type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 0.5%;\" for=\"TotalAmount\">Total Amount</label>");
                                    sb.Append("</div>");
                                }
                                
                                sb.Append("</td>");
                                sb.Append("<td style=\"width:25%;\">" + dr["PAYRL_NAME"].ToString() + "</td>");
                                sb.Append("<td  style=\"width:15%;border-right: 1px solid #ddd;\"><input style=\"text-align:right;\" id=\"txtAmntDed" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" maxlength=12 onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeAmount(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ",'txtAmntDed');\" type=\"text\"  class=\"form-control\" value=\"" + Amount + "\" /></td>");
                                if (i== dtSubConrt2.Rows.Count)
                                {
                                    sb.Append("<td  id=\"tdSave" + EmpId + "\" style=\"width:15%;border-top: none;\"><button id=\"btnadd" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return SaveEmpData(" + EmpId + ");\">UPDATE</button><button id=\"btnCncl" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return CancelEmpData(" + EmpId + ");\">CANCEL</button></td>");
                                }
                                sb.Append("</tr>");
                            }
                            else
                            {
                                sb.Append("<tr style=\"display:none;\">");
                                sb.Append("<td style=\"display:none;\">" + dr["PGDEDTN_ID"].ToString() + "</td>");
                                sb.Append("<td style=\"display:none;\">Ded</td>");
                                sb.Append("<td style=\"display:none;\">" + TableId + "</td>");
                                sb.Append("<td style=\"width:20%;\">");
                                if (PerOrAmntck == "1")
                                {
                                    sb.Append("<div style=\"width:100%;float:left;border: 1px solid #cecccc;\">");
                                    sb.Append("<input disabled  id=\"radio1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  name=\"RadioGroup1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroup1(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 3%;\" for=\"Amount\">Amount</label>");
                                    sb.Append("<input style=\"margin-left: 7%;\" checked id=\"radio2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" name=\"RadioGroup1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroup1(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 3%;\" for=\"Percentage\">Percentage</label>");
                                    sb.Append("</div>");
                                    sb.Append("<div id=\"divRadio" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" style=\"width:100%;float:left;border: 1px solid #cecccc;\"><label style=\"width: 100%;margin-top: 1%;margin-left: 2%;font-weight: 600;\">Percentage Deducted From </label>");
                                    if (BasicOrTotl == "1")
                                    {
                                        sb.Append("<input  id=\"radio3" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" style=\"margin-top: 0%;\"  name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" onchange=\"changeRadioGroup2(" + EmpId + ")();\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 0.5%;\" for=\"BasicPay\">Basic Pay</label>");
                                        sb.Append("<input style=\"margin-left: 5%;margin-top: 0%;\" checked id=\"radio4" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" onchange=\"changeRadioGroup2(" + EmpId + ")();\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\"  type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 0.5%;\" for=\"TotalAmount\">Total Amount</label>");
                                    }
                                    else
                                    {
                                        sb.Append("<input checked id=\"radio3" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" style=\"margin-top: 0%;\"   name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" onchange=\"changeRadioGroup2(" + EmpId + ")();\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 0.5%;\" for=\"BasicPay\">Basic Pay</label>");
                                        sb.Append("<input style=\"margin-left: 5%;margin-top: 0%;\"  id=\"radio4" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" onchange=\"changeRadioGroup2(" + EmpId + ")();\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\"  type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 0.5%;\" for=\"TotalAmount\">Total Amount</label>");
                                    }
                                    sb.Append("</div>");
                                }
                                else
                                {
                                    sb.Append("<div style=\"width:100%;float:left;border: 1px solid #cecccc;\">");
                                    sb.Append("<input checked  id=\"radio1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  name=\"RadioGroup1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroup1(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 3%;\" for=\"Amount\">Amount</label>");
                                    sb.Append("<input disabled style=\"margin-left: 7%;\" id=\"radio2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" name=\"RadioGroup1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroup1(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 3%;\" for=\"Percentage\">Percentage</label>");
                                    sb.Append("</div>");
                                    sb.Append("<div id=\"divRadio" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" style=\"width:100%;float:left;border: 1px solid #cecccc;display:none;\"><label style=\"width: 100%;margin-top: 1%;margin-left: 2%;font-weight: 600;\">Percentage Deducted From </label>");
                                    sb.Append("<input checked id=\"radio3" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" style=\"margin-top: 0%;\"  name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" onchange=\"changeRadioGroup2(" + EmpId + ")();\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 0.5%;\" for=\"BasicPay\">Basic Pay</label>");
                                    sb.Append("<input style=\"margin-left: 5%;margin-top: 0%;\" id=\"radio4" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" onchange=\"changeRadioGroup2(" + EmpId + ")();\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\"  type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 0.5%;\" for=\"TotalAmount\">Total Amount</label>");
                                    sb.Append("</div>");
                                }
                                sb.Append("</td>");
                                sb.Append("<td style=\"width:25%;\">" + dr["PAYRL_NAME"].ToString() + "</td>");
                                sb.Append("<td  style=\"width:15%;border-right: 1px solid #ddd;\"><input style=\"text-align:right;\" id=\"txtAmntDed" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" maxlength=12 onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeAmount(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ",'txtAmntDed');\" type=\"text\"  class=\"form-control\" value=\"" + Amount + "\" /></td>");
                                if (i == dtSubConrt2.Rows.Count)
                                {
                                    sb.Append("<td id=\"tdSave" + EmpId + "\" style=\"width:15%;border-top: none;\"><button id=\"btnadd" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return SaveEmpData(" + EmpId + ");\">UPDATE</button><button id=\"btnCncl" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return CancelEmpData(" + EmpId + ");\">CANCEL</button></td>");
                                }
                                sb.Append("</tr>");
                            }
                            i++;
                        }
                        //End:-For additions & deductions
                        sb.Append("</table>");
                        sb.Append("</td>");
                        sb.Append("</tr>"); 
                    }
                }
                else
                {
                    sb.Append("<tr>");
                    sb.Append("<td style=\"display:none;\">" + EmpId + "</td>");
                    sb.Append("<td style=\"display:none;\">" + EmpName + "</td>");
                    sb.Append("<td style=\"display:none;\">" + EmpCode + "</td>");
                    sb.Append("<td id=\"SalaryId" + EmpId + "\" style=\"display:none;\"></td>");
                    sb.Append("<td id=\"PayGradeIdSaved" + EmpId + "\" style=\"display:none;\"></td>");
                    sb.Append("<td id=\"OldValue" + EmpId + "\" style=\"display:none;\"></td>");
                    sb.Append("<td style=\"width:100%;\" colspan=\"4\" style=\"padding: 0px 0px !important;\">");
                    sb.Append("<table id=\"tableEmp" + EmpId + "\" class=\"table table-bordered\" style=\"font-size:13px;background-color: #f6f6f6;margin-bottom: 0px;border: 2px solid #ddd;\">");
                    sb.Append("<tr>");
                    sb.Append("<th style=\"width:20%;\">" + EmpCode + "</th>");
                    sb.Append("<th style=\"width:25%;\">" + EmpName + "</th>");
                    sb.Append("<td style=\"width:25%;\"> <select style=\"width:88%;float:left;\" id=\"ddlPayGrade" + EmpId + "\" onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" class=\"form-control\" onchange=\"return changePayGrade(" + EmpId + ");\"> <option>-Select-</option>");
                    foreach (DataRow dr in dtPayGrade.Rows)
                    {
                        sb.Append("<option value=\"" + dr["PYGRD_ID"].ToString() + "\">" + dr["PYGRD_NAME"].ToString() + "</option>");
                    }
                    sb.Append("</select><label id=\"Currency" + EmpId + "\" style=\"float:right;margin-top: 2%;font-weight: 600;\"></label></td>");
                    sb.Append("<td style=\"width:15%;\"><input id=\"txtBasicPay" + EmpId + "\" style=\"text-align:right;\" maxlength=12 onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeAmount(" + EmpId + ",'','txtBasicPay');\" type=\"text\"  class=\"form-control\" /></td>");
                    sb.Append("<td id=\"tdSave" + EmpId + "\" style=\"width:15%;\"><button id=\"btnadd" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return SaveEmpData(" + EmpId + ");\">SAVE</button><button id=\"btnCncl" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return CancelEmpData(" + EmpId + ");\">CANCEL</button></td>");
                    sb.Append("</tr>");
                    sb.Append("</table>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }                                   
            }
            if (dtEmployee.Rows.Count == 0 || dtPayGrade.Rows.Count == 0)
            {
                sb.Append("<tr>");
                sb.Append("<td colspan=\"4\" style=\"padding:0;\">No data available</td>");
                sb.Append("</tr>");
            }
            else
            {
                sb.Append("<tr id=\"trLast\" style=\"display:none;\">");
                sb.Append("<td colspan=\"4\" style=\"padding:0;\">No data available</td>");
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
        
    }
   
    protected void btnSave_Click(object sender, EventArgs e)
    {
       Response.Redirect("hcm_Salary_Entry_Process.aspx"); 
    }

    [WebMethod]
    public static string[] ReadRangeInfo(string PayGrade, string orgID, string corptID, string AddDedId, string Obj,string PercAmt)
    {
        string[] arr = new string[3];
        try
        {
            clsBusinessLayerEmpSalary objEmpSalary = new clsBusinessLayerEmpSalary();
            clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
            objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(corptID);
            objEntityEmpSlary.Organisation_Id = Convert.ToInt32(orgID);

            objEntityEmpSlary.PercOrAmountChk = Convert.ToInt32(PercAmt);

            if (Obj == "txtBasicPay")
            {
                objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(PayGrade);
                objEntityEmpSlary.SalaryMode = 0; //Paygrade
            }
            else if (Obj == "txtAmntAdd")
            {
                objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(AddDedId);
                objEntityEmpSlary.SalaryMode = 1; //Allownc
            }
            else 
            {
                objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(AddDedId);
                objEntityEmpSlary.SalaryMode = 2; //Deduction
            }
            DataTable dtSubConrt = objEmpSalary.ReadRangeInfo(objEntityEmpSlary);
            if (dtSubConrt.Rows.Count > 0)
            {
                arr[0] = dtSubConrt.Rows[0][0].ToString();
                arr[1] = dtSubConrt.Rows[0][1].ToString();
                arr[2] = dtSubConrt.Rows[0][2].ToString();
            }

        }
        catch (Exception ex)
        {
        }
        return arr;
    }
    [WebMethod]
    public static string[] ReadPayGradedtls(string PayGrade, string orgID, string corptID, string EmpId, string EmpCode, string EmpName, string BtnText, string userID)
    {
        string[] arr = new string[3];
        try
        {
            StringBuilder sb = new StringBuilder();
            clsBusinessLayerEmpSalary objEmpSalary = new clsBusinessLayerEmpSalary();
            clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
            objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(corptID);
            objEntityEmpSlary.Organisation_Id = Convert.ToInt32(orgID);
            objEntityEmpSlary.User_Id = Convert.ToInt32(userID);

            

            DataTable dtPayGrade = objEmpSalary.ReadPayGrade(objEntityEmpSlary);
            if (PayGrade == "-Select-")
            {
                sb.Append("<tr>");
                sb.Append("<th style=\"width:20%;\">" + EmpCode + "</th>");
                sb.Append("<th style=\"width:25%;\">" + EmpName + "</th>");
                sb.Append("<td style=\"width:25%;\"> <select style=\"width:88%;float:left;\" id=\"ddlPayGrade" + EmpId + "\" onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" class=\"form-control\" onchange=\"return changePayGrade(" + EmpId + ");\"> <option>-Select-</option>");
                foreach (DataRow dr in dtPayGrade.Rows)
                {
                    sb.Append("<option value=\"" + dr["PYGRD_ID"].ToString() + "\">" + dr["PYGRD_NAME"].ToString() + "</option>");
                }
                sb.Append("</select><label id=\"Currency" + EmpId + "\" style=\"float:right;margin-top: 2%;font-weight: 600;\"></label></td>");
                sb.Append("<td style=\"width:15%;\"><input id=\"txtBasicPay" + EmpId + "\" style=\"text-align:right;\" maxlength=12 onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeAmount(" + EmpId + ",'','txtBasicPay');\" type=\"text\"  class=\"form-control\" /></td>");
                sb.Append("<td id=\"tdSave" + EmpId + "\" style=\"width:15%;\"><button id=\"btnadd" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return SaveEmpData(" + EmpId + ");\">" + BtnText + "</button><button id=\"btnCncl" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return CancelEmpData(" + EmpId + ");\">CANCEL</button></td>");
                sb.Append("</tr>");
            }
            else
            {
                objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(PayGrade);
                DataTable dtSubConrt = objEmpSalary.ReadAddnLoad(objEntityEmpSlary);
                DataTable dtSubConrt2 = objEmpSalary.ReadDedctnLoad(objEntityEmpSlary);
                DataTable dtCrncy = objEmpSalary.ReadPayGradeCrncy(objEntityEmpSlary);
                string rowSpanCount = (dtSubConrt.Rows.Count + dtSubConrt2.Rows.Count).ToString();
                if (dtCrncy.Rows.Count > 0)
                {
                    arr[2] = dtCrncy.Rows[0][0].ToString();
                }

                sb.Append("<tr>");
                sb.Append("<th style=\"width:20%;\">" + EmpCode + "</th>");
                sb.Append("<th style=\"width:25%;\">" + EmpName + "</th>");
                sb.Append("<td style=\"width:25%;\"> <select style=\"width:88%;float:left;\" id=\"ddlPayGrade" + EmpId + "\" onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" class=\"form-control\" onchange=\"return changePayGrade(" + EmpId + ");\"> <option>-Select-</option>");
                foreach (DataRow dr in dtPayGrade.Rows)
                {
                    if (PayGrade == dr["PYGRD_ID"].ToString())
                    {
                        sb.Append("<option selected value=\"" + dr["PYGRD_ID"].ToString() + "\">" + dr["PYGRD_NAME"].ToString() + "</option>");
                    }
                    else
                    {
                        sb.Append("<option value=\"" + dr["PYGRD_ID"].ToString() + "\">" + dr["PYGRD_NAME"].ToString() + "</option>");
                    }
                }
                sb.Append("</select><label id=\"Currency" + EmpId + "\" style=\"float:right;margin-top: 2%;font-weight: 600;\">" + arr[2] + "</label></td>");
                sb.Append("<td style=\"width:15%;\"><input id=\"txtBasicPay" + EmpId + "\" style=\"text-align:right;\" maxlength=12 onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeAmount(" + EmpId + ",'','txtBasicPay');\" type=\"text\"  class=\"form-control\" /></td>");
                if (dtSubConrt.Rows.Count == 0 && dtSubConrt2.Rows.Count == 0)
                {
                    sb.Append("<td id=\"tdSave" + EmpId + "\" style=\"width:15%;\"><button id=\"btnadd" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return SaveEmpData(" + EmpId + ");\">" + BtnText + "</button><button id=\"btnCncl" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return CancelEmpData(" + EmpId + ");\">CANCEL</button></td>");
                }
                else
                {
                    sb.Append("<td rowspan=\"" + rowSpanCount + "\" onclick=\"return ShowHide(" + EmpId + ");\"  style=\"width:15%;cursor:pointer;\"><i style=\"float:right;cursor:pointer;\" id=\"show" + EmpId + "\"  class=\"glyphicon glyphicon-chevron-up\"></i></td>");
                }
                sb.Append("</tr>");
                int i = 1;




                foreach (DataRow dr in dtSubConrt.Rows)
                {
                    
                    objEntityEmpSlary.SalaryMode = 0; //Allwnc
                    objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(dr["PGALLCE_ID"]);
                    DataTable dtAmtORPercCheckAllwc = objEmpSalary.ReadAmtPercSts(objEntityEmpSlary);
                    string PerOrAmntck = dtAmtORPercCheckAllwc.Rows[0]["AMNT_PERCTGE_CHCK"].ToString();

                    if (i == 1)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td style=\"display:none;\">" + dr["PGALLCE_ID"].ToString() + "</td>");
                        sb.Append("<td style=\"display:none;\">Add</td>");
                        sb.Append("<td style=\"display:none;\"></td>");
                        sb.Append("<th rowspan=\"" + dtSubConrt.Rows.Count + "\" style=\"width:20%;\">Additions</th>");


                        //evm-0023-25-2
                        sb.Append("<td style=\"width:20%;\">");
                        sb.Append("<div style=\"width:100%;float:left;border: 1px solid #cecccc;\">");

                        if (PerOrAmntck == "0")
                        {
                            sb.Append("<input checked  id=\"radioAmt" + EmpId + dr["PGALLCE_ID"].ToString() + "\"  name=\"RadioGroup1" + EmpId + dr["PGALLCE_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroupAllwnce(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 3%;\" for=\"Amount\">Amount</label>");
                            sb.Append("<input disabled style=\"margin-left: 7%;\" id=\"radioPerc" + EmpId + dr["PGALLCE_ID"].ToString() + "\" name=\"RadioGroup1" + EmpId + dr["PGALLCE_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroupAllwnce(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 3%;\" for=\"Percentage\">Percentage</label>");
                        }
                        else
                        {
                            sb.Append("<input disabled  id=\"radioAmt" + EmpId + dr["PGALLCE_ID"].ToString() + "\"  name=\"RadioGroup1" + EmpId + dr["PGALLCE_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroupAllwnce(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 3%;\" for=\"Amount\">Amount</label>");
                            sb.Append("<input checked style=\"margin-left: 7%;\" id=\"radioPerc" + EmpId + dr["PGALLCE_ID"].ToString() + "\" name=\"RadioGroup1" + EmpId + dr["PGALLCE_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroupAllwnce(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 3%;\" for=\"Percentage\">Percentage</label>");
                        }
                        sb.Append("</div>");




                        sb.Append("<td style=\"width:25%;\">" + dr["PAYRL_NAME"].ToString() + "</td>");
                        sb.Append("<td  style=\"width:15%;border-right: 1px solid #ddd;\"><input style=\"text-align:right;\" id=\"txtAmntAdd" + EmpId + dr["PGALLCE_ID"].ToString() + "\" maxlength=12 onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeAmount(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ",'txtAmntAdd');\" type=\"text\"  class=\"form-control\" /></td>");
                        if (i == dtSubConrt.Rows.Count && dtSubConrt2.Rows.Count == 0)
                        {
                            sb.Append("<td id=\"tdSave" + EmpId + "\" style=\"width:15%;border-top: none;\"><button id=\"btnadd" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return SaveEmpData(" + EmpId + ");\">" + BtnText + "</button><button id=\"btnCncl" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return CancelEmpData(" + EmpId + ");\">CANCEL</button></td>");
                        }
                        sb.Append("</tr>");
                    }
                    else
                    {
                        sb.Append("<tr>");
                        sb.Append("<td style=\"display:none;\">" + dr["PGALLCE_ID"].ToString() + "</td>");
                        sb.Append("<td style=\"display:none;\">Add</td>");
                        sb.Append("<td style=\"display:none;\"></td>");


                        //evm-0023-25-2
                        sb.Append("<td style=\"width:20%;\">");
                        sb.Append("<div style=\"width:100%;float:left;border: 1px solid #cecccc;\">");
                        if (PerOrAmntck == "0")
                        {
                            sb.Append("<input checked  id=\"radioAmt" + EmpId + dr["PGALLCE_ID"].ToString() + "\"  name=\"RadioGroup1" + EmpId + dr["PGALLCE_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroupAllwnce(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 3%;\" for=\"Amount\">Amount</label>");
                            sb.Append("<input disabled style=\"margin-left: 7%;\" id=\"radioPerc" + EmpId + dr["PGALLCE_ID"].ToString() + "\" name=\"RadioGroup1" + EmpId + dr["PGALLCE_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroupAllwnce(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 3%;\" for=\"Percentage\">Percentage</label>");
                        }
                        else
                        {
                            sb.Append("<input disabled  id=\"radioAmt" + EmpId + dr["PGALLCE_ID"].ToString() + "\"  name=\"RadioGroup1" + EmpId + dr["PGALLCE_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroupAllwnce(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 3%;\" for=\"Amount\">Amount</label>");
                            sb.Append("<input checked style=\"margin-left: 7%;\" id=\"radioPerc" + EmpId + dr["PGALLCE_ID"].ToString() + "\" name=\"RadioGroup1" + EmpId + dr["PGALLCE_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroupAllwnce(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 3%;\" for=\"Percentage\">Percentage</label>");                       
                        }
                        sb.Append("</div>");

                        sb.Append("<td style=\"width:25%;\">" + dr["PAYRL_NAME"].ToString() + "</td>");



                        sb.Append("<td  style=\"width:15%;border-right: 1px solid #ddd;\"><input style=\"text-align:right;\" id=\"txtAmntAdd" + EmpId + dr["PGALLCE_ID"].ToString() + "\" maxlength=12 onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeAmount(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ",'txtAmntAdd');\" type=\"text\"  class=\"form-control\" /></td>");
                        if (i == dtSubConrt.Rows.Count && dtSubConrt2.Rows.Count == 0)
                        {
                            sb.Append("<td id=\"tdSave" + EmpId + "\" style=\"width:15%;border-top: none;\"><button id=\"btnadd" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return SaveEmpData(" + EmpId + ");\">" + BtnText + "</button><button id=\"btnCncl" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return CancelEmpData(" + EmpId + ");\">CANCEL</button></td>");
                        }
                        sb.Append("</tr>");
                    }

                    i++;
                }
                i = 1;
                foreach (DataRow dr in dtSubConrt2.Rows)
                {

                    objEntityEmpSlary.SalaryMode = 1; //Allwnc
                    objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(dr["PGDEDTN_ID"]);
                    DataTable dtAmtORPercCheckAllwc = objEmpSalary.ReadAmtPercSts(objEntityEmpSlary);
                    string PerOrAmntck = dtAmtORPercCheckAllwc.Rows[0]["AMNT_PERCTGE_CHCK"].ToString();

                    if (i == 1)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td style=\"display:none;\">" + dr["PGDEDTN_ID"].ToString() + "</td>");
                        sb.Append("<td style=\"display:none;\">Ded</td>");
                        sb.Append("<td style=\"display:none;\"></td>");
                        sb.Append("<th rowspan=\"" + dtSubConrt2.Rows.Count + "\" style=\"width:20%;\">Deductions</th>");
                        sb.Append("<td style=\"width:20%;\">");
                        sb.Append("<div style=\"width:100%;float:left;border: 1px solid #cecccc;\">");
                        if (PerOrAmntck == "0")
                        {
                            sb.Append("<input checked  id=\"radio1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  name=\"RadioGroup1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroup1(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 3%;\" for=\"Amount\">Amount</label>");
                            sb.Append("<input disabled style=\"margin-left: 7%;\" id=\"radio2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" name=\"RadioGroup1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroup1(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 3%;\" for=\"Percentage\">Percentageta</label>");
                        }
                        else
                        {
                            sb.Append("<input disabled  id=\"radio1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  name=\"RadioGroup1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroup1(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 3%;\" for=\"Amount\">Amount</label>");
                            sb.Append("<input checked style=\"margin-left: 7%;\" id=\"radio2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" name=\"RadioGroup1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroup1(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 3%;\" for=\"Percentage\">Percentageta</label>");                      
                        }
                        sb.Append("</div>");
                        sb.Append("<div id=\"divRadio" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" style=\"width:100%;float:left;border: 1px solid #cecccc;display:none;\"><label style=\"width: 100%;margin-top: 1%;margin-left: 2%;font-weight: 600;\">Percentage Deducted From </label>");
                        sb.Append("<input checked id=\"radio3" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" style=\"margin-top: 0%;\"  name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" onchange=\"changeRadioGroup2(" + EmpId + ")();\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 0.5%;\" for=\"BasicPay\">Basic Pay</label>");
                        sb.Append("<input style=\"margin-left: 5%;margin-top: 0%;\" id=\"radio4" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" onchange=\"changeRadioGroup2(" + EmpId + ")();\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\"  type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 0.5%;\" for=\"TotalAmount\">Total Amount</label>");
                        sb.Append("</div>");
                        sb.Append("</td>");
                        sb.Append("<td style=\"width:25%;\">" + dr["PAYRL_NAME"].ToString() + "</td>");
                        sb.Append("<td  style=\"width:15%;border-right: 1px solid #ddd;\"><input style=\"text-align:right;\" id=\"txtAmntDed" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" maxlength=12 onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeAmount(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ",'txtAmntDed');\" type=\"text\"  class=\"form-control\" /></td>");
                        if (i == dtSubConrt2.Rows.Count)
                        {
                            sb.Append("<td id=\"tdSave" + EmpId + "\" style=\"width:15%;border-top: none;\"><button id=\"btnadd" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return SaveEmpData(" + EmpId + ");\">" + BtnText + "</button><button id=\"btnCncl" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return CancelEmpData(" + EmpId + ");\">CANCEL</button></td>");
                        }
                        sb.Append("</tr>");
                    }
                    else
                    {
                        sb.Append("<tr>");
                        sb.Append("<td style=\"display:none;\">" + dr["PGDEDTN_ID"].ToString() + "</td>");
                        sb.Append("<td style=\"display:none;\">Ded</td>");
                        sb.Append("<td style=\"display:none;\"></td>");
                        sb.Append("<td style=\"width:20%;\">");
                        sb.Append("<div style=\"width:100%;float:left;border: 1px solid #cecccc;\">");
                        if (PerOrAmntck == "0")
                        {
                            sb.Append("<input checked id=\"radio1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  name=\"RadioGroup1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroup1(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 3%;\" for=\"Amount\">Amount</label>");
                            sb.Append("<input disabled style=\"margin-left: 7%;\" id=\"radio2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" name=\"RadioGroup1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroup1(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 3%;\" for=\"Percentage\">Percentage</label>");
                        }
                        else
                        {
                            sb.Append("<input disabled id=\"radio1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  name=\"RadioGroup1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroup1(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 3%;\" for=\"Amount\">Amount</label>");
                            sb.Append("<input checked style=\"margin-left: 7%;\" id=\"radio2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" name=\"RadioGroup1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroup1(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 3%;\" for=\"Percentage\">Percentage</label>");                      
                        }
                        sb.Append("</div>");
                        sb.Append("<div id=\"divRadio" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" style=\"width:100%;float:left;border: 1px solid #cecccc;display:none;\"><label style=\"width: 100%;margin-top: 1%;margin-left: 2%;font-weight: 600;\">Percentage Deducted From </label>");
                        sb.Append("<input checked id=\"radio3" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" style=\"margin-top: 0%;\"  name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" onchange=\"changeRadioGroup2(" + EmpId + ")();\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 0.5%;\" for=\"BasicPay\">Basic Pay</label>");
                        sb.Append("<input style=\"margin-left: 5%;margin-top: 0%;\" id=\"radio4" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  onchange=\"changeRadioGroup2(" + EmpId + ")();\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\"  type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 0.5%;\" for=\"TotalAmount\">Total Amount</label>");
                        sb.Append("</div>");
                        sb.Append("</td>");
                        sb.Append("<td style=\"width:25%;\">" + dr["PAYRL_NAME"].ToString() + "</td>");
                        sb.Append("<td  style=\"width:15%;border-right: 1px solid #ddd;\"><input style=\"text-align:right;\" id=\"txtAmntDed" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" maxlength=12 onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeAmount(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ",'txtAmntDed');\" type=\"text\"  class=\"form-control\" /></td>");
                        if (i == dtSubConrt2.Rows.Count)
                        {
                            sb.Append("<td id=\"tdSave" + EmpId + "\" style=\"width:15%;border-top: none;\"><button id=\"btnadd" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return SaveEmpData(" + EmpId + ");\">" + BtnText + "</button><button id=\"btnCncl" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return CancelEmpData(" + EmpId + ");\">CANCEL</button></td>");
                        }
                        sb.Append("</tr>");
                    }
                    i++;
                }
            }
            arr[0] = sb.ToString();
        }
        catch (Exception ex)
        {
        }
        return arr;
    }
    public  DataTable PayGradeLoad()
    {
        clsBusinessLayerEmpSalary objEmpSalary = new clsBusinessLayerEmpSalary();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityEmpSlary.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityEmpSlary.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
      
        DataTable dtSubConrt = objEmpSalary.ReadPayGrade(objEntityEmpSlary);
        return dtSubConrt;
    }
    public class clsTVData
    {

        public string EMPID { get; set; }
        public string PAYGRADE { get; set; }
        public string BASICPAY { get; set; }
        public string MODE { get; set; }
        public string ADDCDEDCID { get; set; }
        public string AMNTPERSTS { get; set; }
        public string TOTBASICSTS { get; set; }
        public string AMNT { get; set; }
        public string MAINTABID { get; set; }
        public string SUBTABID { get; set; }
        public string CHANGESTS { get; set; }
    }
    [WebMethod]
    public static string[] SaveEmpData(string userId,string orgID, string corptID, string EmpId, string PayGrade, string BasicPay, string Mode, string AddDedId,
                                   string AmntPerSts, string TotBasicSts, string Amount, string MainTableId, string SubTableId, string ChangeSts)
    {
        string[] arr = new string[3];
        try
        {
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayerEmpSalary objEmpSalary = new clsBusinessLayerEmpSalary();
            clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
            objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(corptID);
            objEntityEmpSlary.Organisation_Id = Convert.ToInt32(orgID);
            objEntityEmpSlary.User_Id = Convert.ToInt32(userId);
            objEntityEmpSlary.EmplyUserId = Convert.ToInt32(EmpId);
            objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(PayGrade);
            objEntityEmpSlary.AmountRangeFrm = Convert.ToDecimal(BasicPay);
            if (MainTableId == "" && Mode=="")
            {                                         
                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.EMPLOYEE_SALARY);
                objEntityCommon.CorporateID = objEntityEmpSlary.CorpOffice_Id;
                objEntityCommon.Organisation_Id = objEntityEmpSlary.Organisation_Id;
                arr[0] = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
                objEntityEmpSlary.EmpSalaryId = Convert.ToInt32(arr[0]);
                objEmpSalary.AddPayGrade(objEntityEmpSlary);             
            }
            else if (MainTableId != "" && Mode == "")
            {
                objEntityEmpSlary.D_Date = DateTime.Now;
                if (ChangeSts == "1")
                {
                    objEmpSalary.UpdatePayGrade(objEntityEmpSlary);
                }
                else
                {
                    objEmpSalary.UpdatePayGradeBasicPay(objEntityEmpSlary);
                }
            }
            else if (MainTableId != "" && Mode == "Add" && SubTableId == "")
            {
                objEntityEmpSlary.EmpSalaryId = Convert.ToInt32(MainTableId);
                objEntityEmpSlary.AlownceId = Convert.ToInt32(AddDedId);

                objEntityEmpSlary.PercOrAmountChk = Convert.ToInt32(AmntPerSts);
                if (AmntPerSts == "0")
                {
                    objEntityEmpSlary.AmountRangeFrm = Convert.ToDecimal(Amount);
                    objEntityEmpSlary.Percentge = 0;
                }
                else if (AmntPerSts == "1")
                {
                    objEntityEmpSlary.AmountRangeFrm = 0;
                    objEntityEmpSlary.Percentge = Convert.ToDecimal(Amount);
                }

                objEmpSalary.AddSalaryAddnAllownce(objEntityEmpSlary);
                DataTable dt = objEmpSalary.ReadSalaryAddnTableId(objEntityEmpSlary);
                arr[2] = dt.Rows[0][0].ToString();
            }
            else if (MainTableId != "" && Mode == "Add" && SubTableId != "")
            {
                objEntityEmpSlary.D_Date = DateTime.Now;
                objEntityEmpSlary.SalaryAllwnceId = Convert.ToInt32(SubTableId);
                objEntityEmpSlary.AlownceId = Convert.ToInt32(AddDedId);

                objEntityEmpSlary.PercOrAmountChk = Convert.ToInt32(AmntPerSts);
                if (AmntPerSts == "0")
                {
                    objEntityEmpSlary.AmountRangeFrm = Convert.ToDecimal(Amount);
                    objEntityEmpSlary.Percentge = 0;

                }
                else if (AmntPerSts == "1")
                {
                    objEntityEmpSlary.AmountRangeFrm = 0;
                    objEntityEmpSlary.Percentge = Convert.ToDecimal(Amount);
                }

                objEmpSalary.UpdSalaryAddnAllownce(objEntityEmpSlary);
            }
            else if (MainTableId != "" && Mode == "Ded" && SubTableId == "")
            {
                objEntityEmpSlary.EmpSalaryId = Convert.ToInt32(MainTableId);
                objEntityEmpSlary.DedctnId = Convert.ToInt32(AddDedId);
                objEntityEmpSlary.PercOrAmountChk = Convert.ToInt32(AmntPerSts);
                if (AmntPerSts == "0")
                {
                    objEntityEmpSlary.AmountRangeFrm = Convert.ToDecimal(Amount);
                    objEntityEmpSlary.Percentge = 0;

                }
                else if (AmntPerSts == "1")
                {
                    objEntityEmpSlary.AmountRangeFrm = 0;
                    objEntityEmpSlary.Percentge = Convert.ToDecimal(Amount);
                }
                objEntityEmpSlary.BasicOrTotalAmtChk = Convert.ToInt32(TotBasicSts);
                objEmpSalary.AddSalaryDedction(objEntityEmpSlary);
                DataTable dt = objEmpSalary.ReadSalaryDeductnTableId(objEntityEmpSlary);
                arr[2] = dt.Rows[0][0].ToString();
            }
            else if (MainTableId != "" && Mode == "Ded" && SubTableId != "")
            {
                objEntityEmpSlary.D_Date = DateTime.Now;
                objEntityEmpSlary.EmpSalaryId = Convert.ToInt32(MainTableId);
                objEntityEmpSlary.SlaryDedctnId = Convert.ToInt32(SubTableId);
                objEntityEmpSlary.DedctnId = Convert.ToInt32(AddDedId);
                objEntityEmpSlary.PercOrAmountChk = Convert.ToInt32(AmntPerSts);
                if (AmntPerSts == "0")
                {
                    objEntityEmpSlary.AmountRangeFrm = Convert.ToDecimal(Amount);
                    objEntityEmpSlary.Percentge = 0;
                   // string Amnt = dtCorpDetail.Rows[0]["PGDEDTN_RANGE_FRM"].ToString() + "," + dtCorpDetail.Rows[0]["PGDEDTN_RANGE_TO"].ToString() + "," + dtCorpDetail.Rows[0]["PGDEDTN_RANGE_RESTRICT_STS"].ToString();
                }
                else if (AmntPerSts == "1")
                {
                    objEntityEmpSlary.AmountRangeFrm = 0;
                    objEntityEmpSlary.Percentge = Convert.ToDecimal(Amount);
                }
                objEntityEmpSlary.BasicOrTotalAmtChk = Convert.ToInt32(TotBasicSts);
                objEmpSalary.UpdateSalaryDedction(objEntityEmpSlary);
            }
            arr[1] = PayGrade;
        }
        catch (Exception ex)
        {
        }
        return arr;
    }
    [WebMethod]
    public static string[] ReadPayGradedtlsCancel(string orgID, string corptID, string EmpId, string EmpCode, string EmpName, string BtnText, string userID)
    {
        string[] arr = new string[1];
        try
        {
            StringBuilder sb = new StringBuilder();
            clsBusinessLayerEmpSalary objEmpSalary = new clsBusinessLayerEmpSalary();
            clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
            objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(corptID);
            objEntityEmpSlary.Organisation_Id = Convert.ToInt32(orgID);
            objEntityEmpSlary.User_Id = Convert.ToInt32(userID);
            DataTable dtPayGrade = objEmpSalary.ReadPayGrade(objEntityEmpSlary);
            if (BtnText == "SAVE")
            {
                sb.Append("<tr>");
                sb.Append("<th style=\"width:20%;\">" + EmpCode + "</th>");
                sb.Append("<th style=\"width:25%;\">" + EmpName + "</th>");
                sb.Append("<td style=\"width:25%;\"> <select style=\"width:88%;float:left;\" id=\"ddlPayGrade" + EmpId + "\" onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" class=\"form-control\" onchange=\"return changePayGrade(" + EmpId + ");\"> <option>-Select-</option>");
                foreach (DataRow dr in dtPayGrade.Rows)
                {
                    sb.Append("<option value=\"" + dr["PYGRD_ID"].ToString() + "\">" + dr["PYGRD_NAME"].ToString() + "</option>");
                }
                sb.Append("</select><label id=\"Currency" + EmpId + "\" style=\"float:right;margin-top: 2%;font-weight: 600;\"></label></td>");
                sb.Append("<td style=\"width:15%;\"><input id=\"txtBasicPay" + EmpId + "\" style=\"text-align:right;\" maxlength=12 onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeAmount(" + EmpId + ",'','txtBasicPay');\" type=\"text\"  class=\"form-control\" /></td>");
                sb.Append("<td id=\"tdSave" + EmpId + "\" style=\"width:15%;\"><button id=\"btnadd" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return SaveEmpData(" + EmpId + ");\">" + BtnText + "</button><button id=\"btnCncl" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return CancelEmpData(" + EmpId + ");\">CANCEL</button></td>");
                sb.Append("</tr>");
            }
            else
            {             
                    objEntityEmpSlary.EmpSalaryId = Convert.ToInt32(EmpId);                            
                    DataTable dtSlry = objEmpSalary.ReadSalaryByEmpId(objEntityEmpSlary);
                    if (dtSlry.Rows.Count > 0)
                    {
                        objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(dtSlry.Rows[0]["PYGRD_ID"].ToString());
                        DataTable dtSubConrt = objEmpSalary.ReadAddnLoad(objEntityEmpSlary);
                        DataTable dtSubConrt2 = objEmpSalary.ReadDedctnLoad(objEntityEmpSlary);
                        string rowSpanCount = (dtSubConrt.Rows.Count + dtSubConrt2.Rows.Count).ToString();
                        DataTable dtCrncy = objEmpSalary.ReadPayGradeCrncy(objEntityEmpSlary);
                        string currncy = "";
                        if (dtCrncy.Rows.Count > 0)
                        {
                            currncy = dtCrncy.Rows[0][0].ToString();
                        }
                        sb.Append("<tr>");
                        sb.Append("<th style=\"width:20%;\">" + EmpCode + "</th>");
                        sb.Append("<th style=\"width:25%;\">" + EmpName + "</th>");
                        sb.Append("<td style=\"width:25%;\"> <select style=\"width:88%;float:left;\" id=\"ddlPayGrade" + EmpId + "\" onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" class=\"form-control\" onchange=\"return changePayGrade(" + EmpId + ");\"> <option>-Select-</option>");
                        int flagS = 0;
                        foreach (DataRow dr in dtPayGrade.Rows)
                        {
                            if (dtSlry.Rows[0]["PYGRD_ID"].ToString() == dr["PYGRD_ID"].ToString())
                            {
                                sb.Append("<option selected value=\"" + dr["PYGRD_ID"].ToString() + "\">" + dr["PYGRD_NAME"].ToString() + "</option>");
                                flagS = 1;
                            }
                            else
                            {
                                sb.Append("<option value=\"" + dr["PYGRD_ID"].ToString() + "\">" + dr["PYGRD_NAME"].ToString() + "</option>");
                            }
                        }
                        if (flagS == 0)
                        {
                            sb.Append("<option selected value=\"" + dtSlry.Rows[0]["PYGRD_ID"].ToString() + "\">" + dtSlry.Rows[0]["PYGRD_NAME"].ToString() + "</option>");
                        }
                        sb.Append("</select><label id=\"Currency" + EmpId + "\" style=\"float:right;margin-top: 2%;font-weight: 600;\">" + currncy + "</label></td>");
                        sb.Append("<td style=\"width:15%;\"><input id=\"txtBasicPay" + EmpId + "\" style=\"text-align:right;\" maxlength=12 onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeAmount(" + EmpId + ",'','txtBasicPay');\" type=\"text\"  class=\"form-control\" value=\"" + dtSlry.Rows[0]["AMOUNTFRM"].ToString() + "\" /></td>");
                        if (dtSubConrt.Rows.Count == 0 && dtSubConrt2.Rows.Count == 0)
                        {
                            sb.Append("<td id=\"tdSave" + EmpId + "\" style=\"width:15%;\"><button id=\"btnadd" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return SaveEmpData(" + EmpId + ");\">UPDATE</button><button id=\"btnCncl" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return CancelEmpData(" + EmpId + ");\">CANCEL</button></td>");
                        }
                        else
                        {
                            sb.Append("<td rowspan=\"" + rowSpanCount + "\" onclick=\"return ShowHide(" + EmpId + ");\"  style=\"width:15%;cursor:pointer;\"><i style=\"float:right;cursor:pointer;\" id=\"show" + EmpId + "\"  class=\"glyphicon glyphicon-chevron-down\"></i></td>");
                        }
                        sb.Append("</tr>");
                        //Start:-For additions & deductions
                        int i = 1;

                        foreach (DataRow dr in dtSubConrt.Rows)
                        {
                            string TableId = "", Amount = "", PerOrAmntck = "0";
                            objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(dr["PGALLCE_ID"].ToString());
                            objEntityEmpSlary.User_Id = Convert.ToInt32(EmpId);
                            DataTable dtAllwce = objEmpSalary.ReadAllounceByAddId(objEntityEmpSlary);
                            if (dtAllwce.Rows.Count > 0)
                            {
                                TableId = dtAllwce.Rows[0]["SLRYALLCE_ID"].ToString();
                                Amount = dtAllwce.Rows[0]["AMOUNTFRM"].ToString();

                                PerOrAmntck = dtAllwce.Rows[0]["SLRYALLCE_AMNT_PERCTGE_CHCK"].ToString();
                            }

                            if (i == 1)
                            {
                                sb.Append("<tr style=\"display:none;\">");
                                sb.Append("<td style=\"display:none;\">" + dr["PGALLCE_ID"].ToString() + "</td>");
                                sb.Append("<td style=\"display:none;\">Add</td>");
                                sb.Append("<td style=\"display:none;\">" + TableId + "</td>");
                                sb.Append("<th rowspan=\"" + dtSubConrt.Rows.Count + "\" style=\"width:20%;\">Additions</th>");




                                //evm-0023-25-2
                                sb.Append("<td style=\"width:20%;\">");
                                if (PerOrAmntck == "1")
                                {
                                    sb.Append("<div style=\"width:100%;float:left;border: 1px solid #cecccc;\">");
                                    sb.Append("<input disabled  id=\"radioAmt" + EmpId + dr["PGALLCE_ID"].ToString() + "\"  name=\"RadioGroup1" + EmpId + dr["PGALLCE_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroupAllwnce(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 3%;\" for=\"Amount\">Amount</label>");
                                    sb.Append("<input style=\"margin-left: 7%;\" checked id=\"radioPerc" + EmpId + dr["PGALLCE_ID"].ToString() + "\" name=\"RadioGroup1" + EmpId + dr["PGALLCE_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroupAllwnce(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 3%;\" for=\"Percentage\">Percentage</label>");
                                    sb.Append("</div>");
                                }
                                else
                                {
                                    sb.Append("<div style=\"width:100%;float:left;border: 1px solid #cecccc;\">");
                                    sb.Append("<input checked  id=\"radioAmt" + EmpId + dr["PGALLCE_ID"].ToString() + "\"  name=\"RadioGroup1" + EmpId + dr["PGALLCE_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroupAllwnce(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 3%;\" for=\"Amount\">Amount</label>");
                                    sb.Append("<input disabled style=\"margin-left: 7%;\" id=\"radioPerc" + EmpId + dr["PGALLCE_ID"].ToString() + "\" name=\"RadioGroup1" + EmpId + dr["PGALLCE_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroupAllwnce(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 3%;\" for=\"Percentage\">Percentage</label>");
                                    sb.Append("</div>");
                                }
                                sb.Append("</td>");




                                sb.Append("<td style=\"width:25%;\">" + dr["PAYRL_NAME"].ToString() + "</td>");
                                sb.Append("<td  style=\"width:15%;border-right: 1px solid #ddd;\"><input style=\"text-align:right;\" id=\"txtAmntAdd" + EmpId + dr["PGALLCE_ID"].ToString() + "\" maxlength=12 onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeAmount(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ",'txtAmntAdd');\" type=\"text\"  class=\"form-control\" value=\"" + Amount + "\" /></td>");
                                if (i == dtSubConrt.Rows.Count && dtSubConrt2.Rows.Count == 0)
                                {
                                    sb.Append("<td id=\"tdSave" + EmpId + "\" style=\"width:15%;border-top: none;\"><button id=\"btnadd" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return SaveEmpData(" + EmpId + ");\">UPDATE</button><button id=\"btnCncl" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return CancelEmpData(" + EmpId + ");\">CANCEL</button></td>");
                                }
                                sb.Append("</tr>");
                            }
                            else
                            {
                                sb.Append("<tr style=\"display:none;\">");
                                sb.Append("<td style=\"display:none;\">" + dr["PGALLCE_ID"].ToString() + "</td>");
                                sb.Append("<td style=\"display:none;\">Add</td>");
                                sb.Append("<td style=\"display:none;\">" + TableId + "</td>");



                                //evm-0023-25-2
                                sb.Append("<td style=\"width:20%;\">");
                                if (PerOrAmntck == "1")
                                {
                                    sb.Append("<div style=\"width:100%;float:left;border: 1px solid #cecccc;\">");
                                    sb.Append("<input disabled  id=\"radioAmt" + EmpId + dr["PGALLCE_ID"].ToString() + "\"  name=\"RadioGroup1" + EmpId + dr["PGALLCE_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroupAllwnce(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 3%;\" for=\"Amount\">Amount</label>");
                                    sb.Append("<input style=\"margin-left: 7%;\" checked id=\"radioPerc" + EmpId + dr["PGALLCE_ID"].ToString() + "\" name=\"RadioGroup1" + EmpId + dr["PGALLCE_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroupAllwnce(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 3%;\" for=\"Percentage\">Percentage</label>");
                                    sb.Append("</div>");

                                }
                                else
                                {
                                    sb.Append("<div style=\"width:100%;float:left;border: 1px solid #cecccc;\">");
                                    sb.Append("<input checked  id=\"radioAmt" + EmpId + dr["PGALLCE_ID"].ToString() + "\"  name=\"RadioGroup1" + EmpId + dr["PGALLCE_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroupAllwnce(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 3%;\" for=\"Amount\">Amount</label>");
                                    sb.Append("<input disabled style=\"margin-left: 7%;\" id=\"radioPerc" + EmpId + dr["PGALLCE_ID"].ToString() + "\" name=\"RadioGroup1" + EmpId + dr["PGALLCE_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroupAllwnce(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 3%;\" for=\"Percentage\">Percentage</label>");
                                    sb.Append("</div>");
                                }
                                sb.Append("</td>");



                                sb.Append("<td style=\"width:25%;\">" + dr["PAYRL_NAME"].ToString() + "</td>");
                                sb.Append("<td  style=\"width:15%;border-right: 1px solid #ddd;\"><input style=\"text-align:right;\" id=\"txtAmntAdd" + EmpId + dr["PGALLCE_ID"].ToString() + "\" maxlength=12 onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeAmount(" + EmpId + "," + dr["PGALLCE_ID"].ToString() + ",'txtAmntAdd');\" type=\"text\"  class=\"form-control\" value=\"" + Amount + "\" /></td>");
                                if (i == dtSubConrt.Rows.Count && dtSubConrt2.Rows.Count == 0)
                                {
                                    sb.Append("<td  id=\"tdSave" + EmpId + "\" style=\"width:15%;border-top: none;\"><button id=\"btnadd" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return SaveEmpData(" + EmpId + ");\">UPDATE</button><button id=\"btnCncl" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return CancelEmpData(" + EmpId + ");\">CANCEL</button></td>");
                                }
                                sb.Append("</tr>");
                            }

                            i++;
                        }
                        i = 1;
                        foreach (DataRow dr in dtSubConrt2.Rows)
                        {

                            string TableId = "", Amount = "", BasicOrTotl = "0", PerOrAmntck = "0";
                            objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(dr["PGDEDTN_ID"].ToString());
                            objEntityEmpSlary.User_Id = Convert.ToInt32(EmpId);
                            DataTable dtAllwce = objEmpSalary.ReadDedctnByDedId(objEntityEmpSlary);
                            if (dtAllwce.Rows.Count > 0)
                            {
                                TableId = dtAllwce.Rows[0]["SLRYDEDTN_ID"].ToString();
                                Amount = dtAllwce.Rows[0]["AMOUNTFRM"].ToString();
                                if (Convert.ToInt32(dtAllwce.Rows[0]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString()) == 1)
                                {
                                    Amount = dtAllwce.Rows[0]["PERC"].ToString();
                                }
                                BasicOrTotl = dtAllwce.Rows[0]["SLRYDEDTN_BASIC_OR_TOTAL_AMNT"].ToString();
                                PerOrAmntck = dtAllwce.Rows[0]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString();
                            }
                            if (i == 1)
                            {
                                sb.Append("<tr style=\"display:none;\">");
                                sb.Append("<td style=\"display:none;\">" + dr["PGDEDTN_ID"].ToString() + "</td>");
                                sb.Append("<td style=\"display:none;\">Ded</td>");
                                sb.Append("<td style=\"display:none;\">" + TableId + "</td>");
                                sb.Append("<th rowspan=\"" + dtSubConrt2.Rows.Count + "\" style=\"width:20%;\">Deductions</th>");
                                sb.Append("<td style=\"width:20%;\">");
                                if (PerOrAmntck == "1")
                                {
                                    sb.Append("<div style=\"width:100%;float:left;border: 1px solid #cecccc;\">");
                                    sb.Append("<input  disabled id=\"radio1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  name=\"RadioGroup1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroup1(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 3%;\" for=\"Amount\">Amount</label>");
                                    sb.Append("<input style=\"margin-left: 7%;\" checked id=\"radio2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" name=\"RadioGroup1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroup1(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 3%;\" for=\"Percentage\">Percentage</label>");
                                    sb.Append("</div>");
                                    sb.Append("<div id=\"divRadio" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" style=\"width:100%;float:left;border: 1px solid #cecccc;\"><label style=\"width: 100%;margin-top: 1%;margin-left: 2%;font-weight: 600;\">Percentage Deducted From </label>");
                                    if (BasicOrTotl == "1")
                                    {
                                        sb.Append("<input onchange=\"changeRadioGroup2(" + EmpId + ")();\" style=\"margin-top: 0%;\"  id=\"radio3" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 0.5%;\" for=\"BasicPay\">Basic Pay</label>");
                                        sb.Append("<input onchange=\"changeRadioGroup2(" + EmpId + ")();\" style=\"margin-top: 0%;margin-left: 5%;\" checked id=\"radio4" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\"  type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 0.5%;\" for=\"TotalAmount\">Total Amount</label>");
                                    }
                                    else
                                    {
                                        sb.Append("<input checked id=\"radio3" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" style=\"margin-top: 0%;\"  name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" onchange=\"changeRadioGroup2(" + EmpId + ")();\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 0.5%;\" for=\"BasicPay\">Basic Pay</label>");
                                        sb.Append("<input style=\"margin-left: 5%;margin-top: 0%;\"  id=\"radio4" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" onchange=\"changeRadioGroup2(" + EmpId + ")();\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\"  type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 0.5%;\" for=\"TotalAmount\">Total Amount</label>");
                                    }
                                    sb.Append("</div>");
                                }
                                else
                                {
                                    sb.Append("<div style=\"width:100%;float:left;border: 1px solid #cecccc;\">");
                                    sb.Append("<input checked  id=\"radio1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  name=\"RadioGroup1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroup1(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 3%;\" for=\"Amount\">Amount</label>");
                                    sb.Append("<input disabled style=\"margin-left: 7%;\" id=\"radio2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" name=\"RadioGroup1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroup1(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 3%;\" for=\"Percentage\">Percentage</label>");
                                    sb.Append("</div>");
                                    sb.Append("<div id=\"divRadio" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" style=\"width:100%;float:left;border: 1px solid #cecccc;display:none;\"><label style=\"width: 100%;margin-top: 1%;margin-left: 2%;font-weight: 600;\">Percentage Deducted From </label>");
                                    sb.Append("<input checked id=\"radio3" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" style=\"margin-top: 0%;\"  name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" type=\"radio\" onchange=\"changeRadioGroup2(" + EmpId + ")();\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 0.5%;\" for=\"BasicPay\">Basic Pay</label>");
                                    sb.Append("<input style=\"margin-left: 5%;margin-top: 0%;\" id=\"radio4" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"changeRadioGroup2(" + EmpId + ")();\"  type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 0.5%;\" for=\"TotalAmount\">Total Amount</label>");
                                    sb.Append("</div>");
                                }

                                sb.Append("</td>");
                                sb.Append("<td style=\"width:25%;\">" + dr["PAYRL_NAME"].ToString() + "</td>");
                                sb.Append("<td  style=\"width:15%;border-right: 1px solid #ddd;\"><input style=\"text-align:right;\" id=\"txtAmntDed" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" maxlength=12 onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeAmount(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ",'txtAmntDed');\" type=\"text\"  class=\"form-control\" value=\"" + Amount + "\" /></td>");
                                if (i == dtSubConrt2.Rows.Count)
                                {
                                    sb.Append("<td  id=\"tdSave" + EmpId + "\" style=\"width:15%;border-top: none;\"><button id=\"btnadd" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return SaveEmpData(" + EmpId + ");\">UPDATE</button><button id=\"btnCncl" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return CancelEmpData(" + EmpId + ");\">CANCEL</button></td>");
                                }
                                sb.Append("</tr>");
                            }
                            else
                            {
                                sb.Append("<tr style=\"display:none;\">");
                                sb.Append("<td style=\"display:none;\">" + dr["PGDEDTN_ID"].ToString() + "</td>");
                                sb.Append("<td style=\"display:none;\">Ded</td>");
                                sb.Append("<td style=\"display:none;\">" + TableId + "</td>");
                                sb.Append("<td style=\"width:20%;\">");
                                if (PerOrAmntck == "1")
                                {
                                    sb.Append("<div style=\"width:100%;float:left;border: 1px solid #cecccc;\">");
                                    sb.Append("<input  disabled id=\"radio1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  name=\"RadioGroup1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroup1(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 3%;\" for=\"Amount\">Amount</label>");
                                    sb.Append("<input style=\"margin-left: 7%;\" checked id=\"radio2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" name=\"RadioGroup1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroup1(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 3%;\" for=\"Percentage\">Percentage</label>");
                                    sb.Append("</div>");
                                    sb.Append("<div id=\"divRadio" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" style=\"width:100%;float:left;border: 1px solid #cecccc;\"><label style=\"width: 100%;margin-top: 1%;margin-left: 2%;font-weight: 600;\">Percentage Deducted From </label>");
                                    if (BasicOrTotl == "1")
                                    {
                                        sb.Append("<input  id=\"radio3" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" style=\"margin-top: 0%;\"  name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" onchange=\"changeRadioGroup2(" + EmpId + ")();\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 0.5%;\" for=\"BasicPay\">Basic Pay</label>");
                                        sb.Append("<input style=\"margin-left: 5%;margin-top: 0%;\" checked id=\"radio4" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" onchange=\"changeRadioGroup2(" + EmpId + ")();\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\"  type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 0.5%;\" for=\"TotalAmount\">Total Amount</label>");
                                    }
                                    else
                                    {
                                        sb.Append("<input checked id=\"radio3" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" style=\"margin-top: 0%;\"   name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" onchange=\"changeRadioGroup2(" + EmpId + ")();\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 0.5%;\" for=\"BasicPay\">Basic Pay</label>");
                                        sb.Append("<input style=\"margin-left: 5%;margin-top: 0%;\"  id=\"radio4" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" onchange=\"changeRadioGroup2(" + EmpId + ")();\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\"  type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 0.5%;\" for=\"TotalAmount\">Total Amount</label>");
                                    }
                                    sb.Append("</div>");
                                }
                                else
                                {
                                    sb.Append("<div style=\"width:100%;float:left;border: 1px solid #cecccc;\">");
                                    sb.Append("<input checked  id=\"radio1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  name=\"RadioGroup1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroup1(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 3%;\" for=\"Amount\">Amount</label>");
                                    sb.Append("<input disabled style=\"margin-left: 7%;\" id=\"radio2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" name=\"RadioGroup1" + EmpId + dr["PGDEDTN_ID"].ToString() + "\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeRadioGroup1(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ");\" type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 3%;\" for=\"Percentage\">Percentage</label>");
                                    sb.Append("</div>");
                                    sb.Append("<div id=\"divRadio" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" style=\"width:100%;float:left;border: 1px solid #cecccc;display:none;\"><label style=\"width: 100%;margin-top: 1%;margin-left: 2%;font-weight: 600;\">Percentage Deducted From </label>");
                                    sb.Append("<input checked id=\"radio3" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" style=\"margin-top: 0%;\"  name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" onchange=\"changeRadioGroup2(" + EmpId + ")();\"  onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" type=\"radio\"  class=\"form-control\"  /><label style=\"float;left;margin-top: 0.5%;\" for=\"BasicPay\">Basic Pay</label>");
                                    sb.Append("<input style=\"margin-left: 5%;margin-top: 0%;\" id=\"radio4" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" name=\"RadioGroup2" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" onchange=\"changeRadioGroup2(" + EmpId + ")();\"   onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\"  type=\"radio\"  class=\"form-control\" /><label style=\"float;left;margin-top: 0.5%;\" for=\"TotalAmount\">Total Amount</label>");
                                    sb.Append("</div>");
                                }
                                sb.Append("</td>");
                                sb.Append("<td style=\"width:25%;\">" + dr["PAYRL_NAME"].ToString() + "</td>");
                                sb.Append("<td  style=\"width:15%;border-right: 1px solid #ddd;\"><input style=\"text-align:right;\" id=\"txtAmntDed" + EmpId + dr["PGDEDTN_ID"].ToString() + "\" maxlength=12 onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"return changeAmount(" + EmpId + "," + dr["PGDEDTN_ID"].ToString() + ",'txtAmntDed');\" type=\"text\"  class=\"form-control\" value=\"" + Amount + "\" /></td>");
                                if (i == dtSubConrt2.Rows.Count)
                                {
                                    sb.Append("<td id=\"tdSave" + EmpId + "\" style=\"width:15%;border-top: none;\"><button id=\"btnadd" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return SaveEmpData(" + EmpId + ");\">UPDATE</button><button id=\"btnCncl" + EmpId + "\" style=\"width:50%;\" type=\"button\" class=\"btn btn-default btn-sm small-btn\" onclick=\"return CancelEmpData(" + EmpId + ");\">CANCEL</button></td>");
                                }
                                sb.Append("</tr>");
                            }
                            i++;
                        }
                        //End:-For additions & deductions
                    }
            }
            arr[0] = sb.ToString();
        }
        catch (Exception ex)
        {
        }
        return arr;
    }
    
}