using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using BL_Compzit.BusinessLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.Entity_Layer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Text;
public partial class HCM_HCM_Master_hcm_PayrollSystem_hcm_Monthly_Salary_statement_hcm_Monthly_Salary_Statement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["SALARPRSS"] = null;
        if (!IsPostBack)
        {
            BindDdlYears();
            BindDdlMonths();     
            Session["SALARPRSS"] = null;
            int intUserId = 0;
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
            clsBusinessMonthlySalaryStatement objBuss = new clsBusinessMonthlySalaryStatement();
            clsEntityMonthlySalaryStatement objEnt = new clsEntityMonthlySalaryStatement();
            objEnt.CorpOffice = intCorpId;
            objEnt.UserId = intUserId;
            objEnt.Orgid = intOrgId;
            objEnt.PendFinshId = Convert.ToInt32(ddlType.SelectedItem.Value);
            objEnt.Year = Convert.ToInt32(ddlyear.SelectedItem.Value);
            objEnt.Mode = Convert.ToInt32(ddlMode.SelectedItem.Value);
            objEnt.Month = Convert.ToInt32(ddlMonth.SelectedItem.Value);
            DataTable dtList = objBuss.LoadMonthlySalList(objEnt);
            string STRLIST = ConvertDataTableToHTML(dtList);
            divlistview.InnerHtml = STRLIST;
        }
    }
    public void BindDdlYears(string strYear = null)
    {
        ddlyear.Items.Clear();
        strYear = DateTime.Today.Year.ToString();
        var currentYear = DateTime.Today.Year;
        for (int i = -1; i <= 8; i++)
        {
            ddlyear.Items.Add((currentYear - i).ToString());
        }
        ddlyear.ClearSelection();
        if (strYear != null)
        {
            if (ddlyear.Items.FindByValue(strYear) != null)
            {
                ddlyear.Items.FindByValue(strYear).Selected = true;
            }
        }
    }
    public void BindDdlMonths(string strMonth = null)
    {
        strMonth = DateTime.Today.Month.ToString();
        ddlMonth.Items.Clear();
        var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
        for (int i = 0; i < months.Length - 1; i++)
        {
            ddlMonth.Items.Add(new ListItem(months[i], (i + 1).ToString()));
        }
        ddlMonth.ClearSelection();
        if (strMonth != null)
        {
            if (ddlMonth.Items.FindByValue(strMonth) != null)
            {
                ddlMonth.Items.FindByValue(strMonth).Selected = true;
            }
        }
    }
    public string ConvertDataTableToHTML(DataTable dt)
    {
        int intOrgId = 0;
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"table table-striped table-bordered\" width=\"100%\" style=\"border-spacing: 1px;background-color: #e7e6e6;\">";
        strHtml += "<thead>";
        strHtml += "<tr >";      
        strHtml += "<th class=\"hasinput\" style=\"width:25%\"> MONTH & YEAR";
        strHtml += "<input class=\"form-control\" placeholder=\"MONTH & YEAR\" type=\"text\">";
        strHtml += "</th >";
        strHtml += "<th class=\"hasinput\" style=\"width:24%\">TYPE ";
        strHtml += "<input class=\"form-control\" placeholder=\"TYPE\" type=\"text\">";
        strHtml += "</th >";     
        if (ddlMode.SelectedItem.Value == "0")
        {
         strHtml += "<th class=\"hasinput\" style=\"width:20%;\"> DEPARTMENT";
         strHtml += "<input class=\"form-control\" placeholder=\"DEPARTMENT\" type=\"text\">";
         strHtml += "</th >";
        }
        strHtml += "<th class=\"hasinput\" style=\"width:20%;\">NO. Of EMPLOYEE ";
        strHtml += "<input class=\"form-control\" placeholder=\"NO. Of EMPLOYEE \" type=\"text\">";
        strHtml += "</th >";      
        strHtml += "<th class=\"hasinput\" style=\"width:1%;text-align: center;\"> PRINT";      
        strHtml += "<th class=\"hasinput\" style=\"width:1%;text-align: center;display:none\"> Edit";
        strHtml += "</th >";
        strHtml += "</tr>";
        strHtml += "</thead>";
        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["MNTH_NAME"].ToString() + " " + dt.Rows[intRowBodyCount]["SLPRCDMNTH_YEAR"].ToString() + "</td>";
            string StaffWork = "";
            if (dt.Rows[intRowBodyCount]["STAFF_WORKER"].ToString() == "0")
            {
                StaffWork = "Staff";
            }
            else
            {
                StaffWork = "Worker";
            }
            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + StaffWork + "</td>";
            if (ddlMode.SelectedItem.Value == "0")
            {
                strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CPRDEPT_NAME"].ToString() + "</td>";
            }
            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CNT_NUM"].ToString() + "</td>";  
            int CorpdepId = 0;
            if (ddlMode.SelectedItem.Value == "0" && dt.Rows[intRowBodyCount]["CPRDEPT_ID"].ToString() != "")
            {
                CorpdepId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CPRDEPT_ID"].ToString());
            }
            string staffWrk = dt.Rows[intRowBodyCount]["STAFF_WORKER"].ToString();
            string pMonth = dt.Rows[intRowBodyCount]["SLPRCDMNTH_NUMBR"].ToString();
            string pYear = dt.Rows[intRowBodyCount]["SLPRCDMNTH_YEAR"].ToString();
            string passingvalues = ddlType.SelectedItem.Value + "~" + CorpdepId + "~" + staffWrk + "~" + pMonth + "~" + pYear;    
            strHtml += " <td style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\"   onclick=\"return PrintSalaryDetails(" + intRowBodyCount + ");\"><i class=\"fa fa-print\"></i></button></td>";
            strHtml += "<td  style=\" word-break: break-all; word-wrap:break-word;text-align: left;display:none\" > <input type=\"text\"  value=\"" + passingvalues + "\" id=\"Para" + intRowBodyCount + "\"></td>";
            strHtml += "</tr>";
        }
        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    protected void btnSrch_Click(object sender, EventArgs e)
    {
        int intUserId = 0;
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
        clsBusinessMonthlySalaryStatement objBuss = new clsBusinessMonthlySalaryStatement();
        clsEntityMonthlySalaryStatement objEnt = new clsEntityMonthlySalaryStatement();
        objEnt.CorpOffice = intCorpId;
        objEnt.UserId = intUserId;
        objEnt.Orgid = intOrgId;
        objEnt.PendFinshId = Convert.ToInt32(ddlType.SelectedItem.Value);
        objEnt.Year = Convert.ToInt32(ddlyear.SelectedItem.Value);
        objEnt.Mode = Convert.ToInt32(ddlMode.SelectedItem.Value);
        objEnt.Month = Convert.ToInt32(ddlMonth.SelectedItem.Value);
        DataTable dtList = objBuss.LoadMonthlySalList(objEnt);
        string STRLIST = ConvertDataTableToHTML(dtList);
        divlistview.InnerHtml = STRLIST;
    }
    protected void btnRedirect2_Click(object sender, EventArgs e)
    {
        Session["SALARPRSS"] = HiddenViewId.Value;
        Response.Redirect("hcm_Monthly_Salary_Statement_print.aspx");
    }
}