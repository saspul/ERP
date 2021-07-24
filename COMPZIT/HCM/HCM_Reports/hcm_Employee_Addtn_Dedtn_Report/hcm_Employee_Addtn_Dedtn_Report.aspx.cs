using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Globalization;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using BL_Compzit.BusinessLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.Entity_Layer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Text;
using System.Web.Services;
using iTextSharp.text;
using iTextSharp.text.pdf;

public partial class HCM_HCM_Reports_hcm_Employee_Addtn_Dedtn_Report_hcm_Employee_Addtn_Dedtn_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = { clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                         };
            DataTable dtCorpDetail = new DataTable();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenFieldDecCnt.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                HiddenFieldCrncyId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            }
          LoadDDLs();
          BindDdlYears();
          BindDdlMonths();
          HiddenFieldYear.Value = ddlYear.Value;
          HiddenFieldCategory.Value = ddlCategory.Value;
          HiddenFieldMethod.Value = ddlMethod.Value;
          Search();
          
        }
    }
    public void LoadDDLs()
    {
        clsEntityEmployeeAddDedReport objEntityBulkPrint = new clsEntityEmployeeAddDedReport();
        clsBusinessEmployeeAddDedReport objBusiness = new clsBusinessEmployeeAddDedReport();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityBulkPrint.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityBulkPrint.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtDep = objBusiness.LoadDepartment(objEntityBulkPrint);
        DataTable dtDiv = objBusiness.LoadDivison(objEntityBulkPrint);
        DataTable dtDes = objBusiness.LoadDesignation(objEntityBulkPrint);
        DataTable dtEmp = objBusiness.LoadEmployee(objEntityBulkPrint);
        DataTable dtAdd = objBusiness.LoadAddition(objEntityBulkPrint);
        DataTable dtDed = objBusiness.LoadDeduction(objEntityBulkPrint);
        if (dtDep.Rows.Count > 0)
        {
            ddlDepartment.DataSource = dtDep;
            ddlDepartment.DataTextField = "CPRDEPT_NAME";
            ddlDepartment.DataValueField = "CPRDEPT_ID";
            ddlDepartment.DataBind();
        }
        if (dtDiv.Rows.Count > 0)
        {
            ddlDivision.DataSource = dtDiv;
            ddlDivision.DataTextField = "CPRDIV_NAME";
            ddlDivision.DataValueField = "CPRDIV_ID";
            ddlDivision.DataBind();
        }
        if (dtDes.Rows.Count > 0)
        {
            ddlDesignation.DataSource = dtDes;
            ddlDesignation.DataTextField = "DSGN_NAME";
            ddlDesignation.DataValueField = "DSGN_ID";
            ddlDesignation.DataBind();
        }
        if (dtEmp.Rows.Count > 0)
        {
            ddlEmployee.DataSource = dtEmp;
            ddlEmployee.DataTextField = "USR_NAME";
            ddlEmployee.DataValueField = "USR_ID";
            ddlEmployee.DataBind();
        }
        if (dtAdd.Rows.Count > 0)
        {
            ddlAddition.DataSource = dtAdd;
            ddlAddition.DataTextField = "PAYRL_NAME";
            ddlAddition.DataValueField = "PAYRL_ID";
            ddlAddition.DataBind();
        }
        if (dtDed.Rows.Count > 0)
        {
            ddlDeduction.DataSource = dtDed;
            ddlDeduction.DataTextField = "PAYRL_NAME";
            ddlDeduction.DataValueField = "PAYRL_ID";
            ddlDeduction.DataBind();
        }

    }
    public void BindDdlYears(string strYear = null)
    {
        ddlYear.Items.Clear();
        strYear = DateTime.Today.Year.ToString();
        var currentYear = DateTime.Today.Year;
        for (int i = -1; i <= 8; i++)
        {
            ddlYear.Items.Add((currentYear - i).ToString());
        }
        if (strYear != null)
        {
            if (ddlYear.Items.FindByValue(strYear) != null)
            {
                ddlYear.Items.FindByValue(strYear).Selected = true;
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
            ddlMonth.Items.Add(new System.Web.UI.WebControls.ListItem(months[i], (i + 1).ToString()));
        }
        ddlMonth.ClearSelection();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Search();
    }
    public void Search()
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityCommon.CurrencyId = Convert.ToInt32(HiddenFieldCrncyId.Value);
        int roundNum= Convert.ToInt32(HiddenFieldDecCnt.Value);
        
        clsEntityEmployeeAddDedReport objEntityBulkPrint = new clsEntityEmployeeAddDedReport();
        clsBusinessEmployeeAddDedReport objBusiness = new clsBusinessEmployeeAddDedReport();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityBulkPrint.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityBulkPrint.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityBulkPrint.Year = Convert.ToInt32(HiddenFieldYear.Value);
        objEntityBulkPrint.Months = HiddenFieldMonths.Value;
        objEntityBulkPrint.DepartmentIds = HiddenFieldDept.Value;
        objEntityBulkPrint.DivisionIds = HiddenFieldDivision.Value;
        objEntityBulkPrint.DesignationIds = HiddenFieldDesg.Value;
        objEntityBulkPrint.EmployeeIds = HiddenFieldEmployee.Value;
        objEntityBulkPrint.AdditionIds = HiddenFieldAddition.Value;
        objEntityBulkPrint.DeductionIds = HiddenFieldDeduction.Value;
        objEntityBulkPrint.CategoryId = Convert.ToInt32(ddlCategory.Value);

        DataTable DtTotal = new DataTable();
        DtTotal.Columns.Add("MONTH", typeof(string));
        DtTotal.Columns.Add("BA", typeof(decimal));
        DtTotal.Columns.Add("BD", typeof(decimal));
        DtTotal.Columns.Add("MA", typeof(decimal));
        DtTotal.Columns.Add("MD", typeof(decimal));

        if (ddlMethod.Value == "1")
        {

            DataTable dt = objBusiness.ReadSummaryFirst(objEntityBulkPrint);
            string strHtml = "";
            decimal decBA = 0, decBD = 0, decMA = 0, decMD = 0, decTA = 0, decTD = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                decBA += Convert.ToDecimal(dt.Rows[i]["BA"].ToString());
                decBD += Convert.ToDecimal(dt.Rows[i]["BD"].ToString());
                decMA += Convert.ToDecimal(dt.Rows[i]["MA"].ToString());
                decMD += Convert.ToDecimal(dt.Rows[i]["MD"].ToString());
                decTA += Convert.ToDecimal(dt.Rows[i]["TA"].ToString());
                decTD += Convert.ToDecimal(dt.Rows[i]["TD"].ToString());

                String month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(dt.Rows[i]["SLPRCDMNTH_NUMBR"].ToString()));
                DataRow drDtl = DtTotal.NewRow();
                drDtl["MONTH"] = month;
                drDtl["BA"] = Convert.ToDecimal(dt.Rows[i]["BA"].ToString());
                drDtl["BD"] = Convert.ToDecimal(dt.Rows[i]["BD"].ToString());
                drDtl["MA"] = Convert.ToDecimal(dt.Rows[i]["MA"].ToString());
                drDtl["MD"] = Convert.ToDecimal(dt.Rows[i]["MD"].ToString());
                DtTotal.Rows.Add(drDtl);

                strHtml += "<tr>";
                strHtml += " <td class=\"tr_l\">";
                strHtml += " <a onclick=\"return ShowLevel2(" + dt.Rows[i]["SLPRCDMNTH_NUMBR"].ToString() + ",'','');\" href=\"#\" class=\"bt_sumry_2_6\">" + month + "</a>";
                strHtml += "</td>";
                strHtml += "<td class=\"tr_r\">";
                strHtml += " <a onclick=\"return ShowLevel2(" + dt.Rows[i]["SLPRCDMNTH_NUMBR"].ToString() + ",'1'," + dt.Rows[i]["BA"].ToString() + ");\" href=\"#\" class=\"bt_sumry_2\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["BA"].ToString()), roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                strHtml += " </td>";
                strHtml += " <td class=\"tr_r\">";
                strHtml += "<a onclick=\"return ShowLevel2(" + dt.Rows[i]["SLPRCDMNTH_NUMBR"].ToString() + ",'2'," + dt.Rows[i]["BD"].ToString() + ");\" href=\"#\" class=\"bt_sumry_2\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["BD"].ToString()), roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                strHtml += "</td>";
                strHtml += "<td class=\"tr_r\">";
                strHtml += "<a onclick=\"return ShowLevel2(" + dt.Rows[i]["SLPRCDMNTH_NUMBR"].ToString() + ",'3'," + dt.Rows[i]["MA"].ToString() + ");\" href=\"#\" class=\"bt_sumry_2_2\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["MA"].ToString()), roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                strHtml += " </td>";
                strHtml += "<td class=\"tr_r\">";
                strHtml += "<a onclick=\"return ShowLevel2(" + dt.Rows[i]["SLPRCDMNTH_NUMBR"].ToString() + ",'4'" + dt.Rows[i]["MD"].ToString() + ");\" href=\"#\" class=\"bt_sumry_2_3\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["MD"].ToString()), roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                strHtml += "</td>";
                strHtml += "<td class=\"tr_r\">";
                strHtml += "<a onclick=\"return ShowLevel2(" + dt.Rows[i]["SLPRCDMNTH_NUMBR"].ToString() + ",'5'," + dt.Rows[i]["TA"].ToString() + ");\" href=\"#\" class=\"bt_sumry_2_4\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["TA"].ToString()), roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                strHtml += "</td>";
                strHtml += "<td class=\"tr_r\">";
                strHtml += "<a onclick=\"return ShowLevel2(" + dt.Rows[i]["SLPRCDMNTH_NUMBR"].ToString() + ",'6'," + dt.Rows[i]["TD"].ToString() + ");\" href=\"#\" class=\"bt_sumry_2_5\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["TD"].ToString()), roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                strHtml += "</td>";
                strHtml += "</tr>";

            }
            if (dt.Rows.Count == 0)
            {
                strHtml = "<tr><td class=\"tr_c\" colspan=\"7\">No data available</td></tr>";
                HiddenFieldNodataSts.Value = "1";
            }
            tBodyLevel1.InnerHtml = strHtml;
            strHtml = "";
            if (dt.Rows.Count > 0)
            {
                strHtml += "<tr>";
                strHtml += "<th>";
                strHtml += "<a onclick=\"return ShowLevel2('','','');\" href=\"#\" class=\"bt_sumry_2_6\">Total</a>";
                strHtml += "</th>";
                strHtml += "<th class=\"tr_r\">";
                strHtml += "<a onclick=\"return ShowLevel2('','1'," + decBA + ");\" href=\"#\" class=\"bt_sumry_2_4\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decBA, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                strHtml += "</th>";
                strHtml += "<th class=\"tr_r\">";
                strHtml += "<a onclick=\"return ShowLevel2('','2'," + decBD + ");\" href=\"#\" class=\"bt_sumry_2_1\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decBD, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                strHtml += "</th>";
                strHtml += "<th class=\"tr_r\">";
                strHtml += "<a onclick=\"return ShowLevel2('','3'," + decMA + ");\" href=\"#\" class=\"bt_sumry_2_2\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decMA, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                strHtml += "</th>";
                strHtml += "<th class=\"tr_r\">";
                strHtml += "<a onclick=\"return ShowLevel2('','4'," + decMD + ");\" href=\"#\" class=\"bt_sumry_2_3\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decMD, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                strHtml += "</th>";
                strHtml += "<th class=\"tr_r\">";
                strHtml += "<a onclick=\"return ShowLevel2('','5'," + decTA + ");\" href=\"#\" class=\"bt_sumry_2_4\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTA, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                strHtml += "</th>";
                strHtml += "<th class=\"tr_r\">";
                strHtml += "<a onclick=\"return ShowLevel2('','6'," + decTD + ");\" href=\"#\" class=\"bt_sumry_2_5\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTD, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                strHtml += "</th>";
                strHtml += "</tr>";
            }
            tFootLevel1.InnerHtml = strHtml;
        }
        else
        {
            DataTable dt = objBusiness.ReadSummaryFirstMtdTwo(objEntityBulkPrint);
            string strHtml = "";
            if (dt.Rows.Count > 0)
            {
                DataView dtview = new DataView(dt);
                dtview.Sort = "SLPRCDMNTH_NUMBR ASC";

                DataTable dtDistdept = dtview.ToTable(true, "SLPRCDMNTH_NUMBR");

                DataView dtviewAD = new DataView(dt);
                DataTable dtDistdeptAD = dtviewAD.ToTable(true, "PAYRL_ID", "PAYRL_NAME", "MODE1");

                DataRow[] drMode1 = dtDistdeptAD.Select("MODE1=1");
                DataRow[] drMode2 = dtDistdeptAD.Select("MODE1=2");
                DataRow[] drMode3 = dtDistdeptAD.Select("MODE1=3");
                DataRow[] drMode4 = dtDistdeptAD.Select("MODE1=4");
                int Mode1Cnt = drMode1.Length + 1;
                int Mode2Cnt = drMode2.Length + 1;
                int Mode3Cnt = drMode3.Length + 1;
                int Mode4Cnt = drMode4.Length + 1;

                strHtml += "<table class=\"display table-bordered pro_tab1 tbl_fl3 tbl_ad_de\" cellspacing=\"0\" width=\"100%\" ><thead class=\"thead1\">";
                strHtml += "<tr>";
                strHtml += "<th class=\"th_b7 tr_l\" rowspan=\"2\">Month</th>";
                strHtml += "<th class=\"tr_c\" colspan=\"" + Mode1Cnt + "\">Addition</th>";
                strHtml += "<th class=\"tr_c\" colspan=\"" + Mode2Cnt + "\">Deduction</th>";
                strHtml += "<th class=\"tr_c\" colspan=\"" + Mode3Cnt + "\">Manual Addition</th>";
                strHtml += "<th class=\"tr_c\" colspan=\"" + Mode4Cnt + "\">Manual Deduction</th>";
                strHtml += "<th class=\"th_b1 tr_r\" rowspan=\"2\">Total<br>Addition</th>";
                strHtml += "<th class=\"th_b1 tr_r\" rowspan=\"2\">Total<br>Deduction</th>";
                strHtml += "</tr>";
                strHtml += "<tr>";
                foreach (DataRow dr1 in drMode1)
                {
                    strHtml += "<th class=\"tr_r\">" + dr1["PAYRL_NAME"].ToString() + "</th>";
                }
                strHtml += "<th class=\"tr_r\">Total</th>";
                foreach (DataRow dr1 in drMode2)
                {
                    strHtml += "<th class=\"tr_r\">" + dr1["PAYRL_NAME"].ToString() + "</th>";
                }
                strHtml += "<th class=\"tr_r\">Total</th>";
                foreach (DataRow dr1 in drMode3)
                {
                    strHtml += "<th class=\"tr_r\">" + dr1["PAYRL_NAME"].ToString() + "</th>";
                }
                strHtml += "<th class=\"tr_r\">Total</th>";
                foreach (DataRow dr1 in drMode4)
                {
                    strHtml += "<th class=\"tr_r\">" + dr1["PAYRL_NAME"].ToString() + "</th>";
                }
                strHtml += "<th class=\"tr_r\">Total</th>";
                strHtml += "</tr>";
                strHtml += "</thead>";
                strHtml += "<tbody>";
                for (int i = 0; i < dtDistdept.Rows.Count; i++)
                {
                    string month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(dtDistdept.Rows[i][0].ToString()));
                    DataRow drDtl = DtTotal.NewRow();
                    drDtl["MONTH"] = month;
                    strHtml += "<tr>";
                    strHtml += "<td class=\"tr_l\">";
                    strHtml += "<a onclick=\"return ShowLevel2M2(" + dtDistdept.Rows[i][0].ToString() + ",'','','0','1');\" href=\"#\" class=\"bt_spl1\">" + month + "</a>";
                    strHtml += "</td>";
                    decimal decTotBa = 0;
                    foreach (DataRow dr1 in drMode1)
                    {
                        decimal curr = 0;
                        string StrCurr = dt.Compute("Sum(AMT)", "MODE1=1 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + " AND SLPRCDMNTH_NUMBR=" + dtDistdept.Rows[i][0].ToString() + "").ToString();
                        if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                            curr = Convert.ToDecimal(StrCurr);
                        strHtml += "<td class=\"tr_r\">";
                        strHtml += "<a href=\"#\" class=\"\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                        strHtml += "</td>";
                        decTotBa += curr;
                    }
                    strHtml += "<td class=\"tr_r\">";
                    strHtml += "<a href=\"#\" class=\"\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotBa, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                    strHtml += "</td>";
                    drDtl["BA"] = Convert.ToDecimal(Math.Round(decTotBa, roundNum).ToString("0.00"));
                    decimal decTotBd = 0;
                    foreach (DataRow dr1 in drMode2)
                    {
                        decimal curr = 0;
                        string StrCurr = dt.Compute("Sum(AMT)", "MODE1=2 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + " AND SLPRCDMNTH_NUMBR=" + dtDistdept.Rows[i][0].ToString() + "").ToString();
                        if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                            curr = Convert.ToDecimal(StrCurr);
                        strHtml += "<td class=\"tr_r\">";
                        strHtml += "<a href=\"#\" class=\"\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                        strHtml += "</td>";
                        decTotBd += curr;
                    }
                    strHtml += "<td class=\"tr_r\">";
                    strHtml += "<a href=\"#\" class=\"\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotBd, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                    strHtml += "</td>";
                    drDtl["BD"] = Convert.ToDecimal(Math.Round(decTotBd, roundNum).ToString("0.00")); ;
                    decimal decTotMa = 0;
                    foreach (DataRow dr1 in drMode3)
                    {
                        decimal curr = 0;
                        string StrCurr = dt.Compute("Sum(AMT)", "MODE1=3 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + " AND SLPRCDMNTH_NUMBR=" + dtDistdept.Rows[i][0].ToString() + "").ToString();
                        if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                            curr = Convert.ToDecimal(StrCurr);
                        strHtml += "<td class=\"tr_r\">";
                        strHtml += "<a href=\"#\" class=\"\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                        strHtml += "</td>";
                        decTotMa += curr;
                    }
                    strHtml += "<td class=\"tr_r\">";
                    strHtml += "<a href=\"#\" class=\"\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotMa, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                    strHtml += "</td>";
                    drDtl["MA"] = Convert.ToDecimal(Math.Round(decTotMa, roundNum).ToString("0.00")); ;
                    decimal decTotMd = 0;
                    foreach (DataRow dr1 in drMode4)
                    {
                        decimal curr = 0;
                        string StrCurr = dt.Compute("Sum(AMT)", "MODE1=4 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + " AND SLPRCDMNTH_NUMBR=" + dtDistdept.Rows[i][0].ToString() + "").ToString();
                        if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                            curr = Convert.ToDecimal(StrCurr);
                        strHtml += "<td class=\"tr_r\">";
                        strHtml += "<a href=\"#\" class=\"\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                        strHtml += "</td>";
                        decTotMd += curr;
                    }
                    strHtml += "<td class=\"tr_r\">";
                    strHtml += "<a href=\"#\" class=\"\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotMd, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                    strHtml += "</td>";
                    drDtl["MD"] = Convert.ToDecimal(Math.Round(decTotMd, roundNum).ToString("0.00")); ;
                    strHtml += "<td class=\"tr_r\">";
                    strHtml += "<a href=\"#\" class=\"\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotBa + decTotMa, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                    strHtml += "</td>";
                    strHtml += "<td class=\"tr_r\">";
                    strHtml += "<a href=\"#\" class=\"\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotBd + decTotMd, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                    strHtml += "</td>";
                    strHtml += "</tr>";
                    DtTotal.Rows.Add(drDtl);
                }
                strHtml += "</tbody>";
                strHtml += "<tfoot class=\"clr_hrd\">";
                strHtml += "<tr>";
                strHtml += "<th colspan=\"1\" class=\"tr_r\">";
                strHtml += "<a onclick=\"return ShowLevel2M2('','','','0','1');\" href=\"#\" class=\"bt_spl1\">Total</a>";
                strHtml += "</th>";
                decimal decNetBa = 0;
                foreach (DataRow dr1 in drMode1)
                {
                    decimal curr = 0;
                    string StrCurr = dt.Compute("Sum(AMT)", "MODE1=1 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                    if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                        curr = Convert.ToDecimal(StrCurr);
                    strHtml += "<th class=\"tr_r\">";
                    strHtml += "<a onclick=\"return ShowLevel2M2(''," + dr1["PAYRL_ID"].ToString() + ",'1','0'," + curr + ");\" href=\"#\" class=\"bt_spl1\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                    strHtml += "</th>";
                    decNetBa += curr;
                }
                strHtml += "<th class=\"tr_r\">";
                strHtml += "<a onclick=\"return ShowLevel2M2('','','1','0'," + decNetBa + ");\" href=\"#\" class=\"bt_spl1\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decNetBa, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                strHtml += "</th>";
                decimal decNetBd = 0;
                foreach (DataRow dr1 in drMode2)
                {
                    decimal curr = 0;
                    string StrCurr = dt.Compute("Sum(AMT)", "MODE1=2 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                    if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                        curr = Convert.ToDecimal(StrCurr);
                    strHtml += "<th class=\"tr_r\">";
                    strHtml += "<a onclick=\"return ShowLevel2M2(''," + dr1["PAYRL_ID"].ToString() + ",'2','0'," + curr + ");\" href=\"#\" class=\"bt_spl1\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                    strHtml += "</th>";
                    decNetBd += curr;
                }
                strHtml += "<th class=\"tr_r\">";
                strHtml += "<a onclick=\"return ShowLevel2M2('','','2','0'," + decNetBd + ");\" href=\"#\" class=\"bt_spl1\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decNetBd, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                strHtml += "</th>";
                decimal decNetMa = 0;
                foreach (DataRow dr1 in drMode3)
                {
                    decimal curr = 0;
                    string StrCurr = dt.Compute("Sum(AMT)", "MODE1=3 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                    if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                        curr = Convert.ToDecimal(StrCurr);
                    strHtml += "<th class=\"tr_r\">";
                    strHtml += "<a onclick=\"return ShowLevel2M2(''," + dr1["PAYRL_ID"].ToString() + ",'3','0'," + curr + ");\" href=\"#\" class=\"bt_spl1\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                    strHtml += "</th>";
                    decNetMa += curr;
                }
                strHtml += "<th class=\"tr_r\">";
                strHtml += "<a onclick=\"return ShowLevel2M2('','','3','0'," + decNetMa + ");\" href=\"#\" class=\"bt_spl1\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decNetMa, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                strHtml += "</th>";
                decimal decNetMd = 0;
                foreach (DataRow dr1 in drMode4)
                {
                    decimal curr = 0;
                    string StrCurr = dt.Compute("Sum(AMT)", "MODE1=4 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                    if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                        curr = Convert.ToDecimal(StrCurr);
                    strHtml += "<th class=\"tr_r\">";
                    strHtml += "<a onclick=\"return ShowLevel2M2(''," + dr1["PAYRL_ID"].ToString() + ",'4','0'," + curr + ");\" href=\"#\" class=\"bt_spl1\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                    strHtml += "</th>";
                    decNetMd += curr;
                }
                strHtml += "<th class=\"tr_r\">";
                strHtml += "<a onclick=\"return ShowLevel2M2('','','4','0'," + decNetMd + ");\" href=\"#\" class=\"bt_spl1\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decNetMd, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                strHtml += "</th>";
                strHtml += "<th class=\"tr_r\">";
                strHtml += "<a onclick=\"return ShowLevel2M2('','','5','0'," + (decNetBa + decNetMa) + ");\" href=\"#\" class=\"bt_spl1\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decNetBa + decNetMa, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                strHtml += "</th>";
                strHtml += "<th class=\"tr_r\">";
                strHtml += "<a onclick=\"return ShowLevel2M2('','','6','0'," + (decNetBd + decNetMd) + ");\" href=\"#\" class=\"bt_spl1\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decNetBd + decNetMd, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
                strHtml += "</th>";
                strHtml += "</tr>";
                strHtml += "</tfoot></table>";
                tabFirstMthd2.InnerHtml = strHtml;
            }
            else
            {
                strHtml += "<table class=\"display table-bordered pro_tab1 tbl_fl3 tbl_ad_de\" cellspacing=\"0\" width=\"100%\" ><thead class=\"thead1\">";
                strHtml += "<tr>";
                strHtml += "<th class=\"th_b7 tr_l\" >Month</th>";
                strHtml += "<th class=\"tr_c\" >Addition</th>";
                strHtml += "<th class=\"tr_c\">Deduction</th>";
                strHtml += "<th class=\"tr_c\">Manual Addition</th>";
                strHtml += "<th class=\"tr_c\">Manual Deduction</th>";
                strHtml += "<th class=\"th_b1 tr_r\">Total<br>Addition</th>";
                strHtml += "<th class=\"th_b1 tr_r\">Total<br>Deduction</th>";
                strHtml += "</tr></thead><tbody><tr><td class=\"tr_l\" colspan=\"7\">&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp  No data available</td></tr></tbody></table>";
                tabFirstMthd2.InnerHtml = strHtml;
                HiddenFieldNodataSts.Value = "1";
            }
        }
        string strJson = DataTableToJSONWithJavaScriptSerializer(DtTotal);
        HiddenFieldGraphData.Value = strJson;

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
    [System.Web.Services.WebMethod]
    public static string changeEmployee(string orgID, string corpId, string Dept, string Divs, string Desg, string Catgry)
    {
        string sts = "";
        try
        {
            StringBuilder sb = new StringBuilder();
            clsEntityEmployeeAddDedReport objEntityBulkPrint = new clsEntityEmployeeAddDedReport();
            clsBusinessEmployeeAddDedReport objBusiness = new clsBusinessEmployeeAddDedReport();
            objEntityBulkPrint.OrgId = Convert.ToInt32(orgID);
            objEntityBulkPrint.CorpId = Convert.ToInt32(corpId);
            objEntityBulkPrint.CategoryId = Convert.ToInt32(Catgry);
            if(Dept!="null")
            objEntityBulkPrint.DepartmentIds = Dept.Replace('-', ',');
            if (Divs != "null")
            objEntityBulkPrint.DivisionIds = Divs.Replace('-', ',');
            if (Desg != "null")
            objEntityBulkPrint.DesignationIds = Desg.Replace('-', ',');
            DataTable dt = objBusiness.LoadEmployee(objEntityBulkPrint);
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<option value=\"" + dr["USR_ID"].ToString() + "\">" + dr["USR_NAME"].ToString() + "</option>");
            }
            sts = sb.ToString();
        }
        catch (Exception ex)
        {

        }
        return sts;
    }
    [System.Web.Services.WebMethod]
    public static string[] ShowLevel2(string orgID, string corpId, string year, string month, string dept, string divsn, string job, string desg, string emp, string Addtn, string Dedtn, string catgry, string method, string ShowDep, string ShowDiv, string ShowJob, string ShowCat, string ShowMon, string Dcm, string Crn, string mode)
    {          
        string[] sts =new string[2];
        try
        {
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(Crn);
            int roundNum = Convert.ToInt32(Dcm);

            clsEntityEmployeeAddDedReport objEntityBulkPrint = new clsEntityEmployeeAddDedReport();
            clsBusinessEmployeeAddDedReport objBusiness = new clsBusinessEmployeeAddDedReport();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            objEntityBulkPrint.CorpId = Convert.ToInt32(corpId);
            objEntityBulkPrint.OrgId = Convert.ToInt32(orgID);
            objEntityBulkPrint.Year = Convert.ToInt32(year);
            objEntityBulkPrint.Months = month;
            objEntityBulkPrint.DepartmentIds = dept;
            objEntityBulkPrint.DivisionIds = divsn;
            objEntityBulkPrint.DesignationIds = desg;
            objEntityBulkPrint.EmployeeIds = emp;
            objEntityBulkPrint.AdditionIds = Addtn;
            objEntityBulkPrint.DeductionIds = Dedtn;
            objEntityBulkPrint.CategoryId = Convert.ToInt32(catgry);
            string queryCol = "";
            if (ShowDep == "1")
            {
               queryCol = "CPRDEPT_ID,CPRDEPT_NAME";
            }
            if (ShowDiv == "1")
            {
                if (queryCol == "")
                {
                    queryCol = "CPRDIV_ID,CPRDIV_NAME";
                }
                else
                {
                    queryCol += ",CPRDIV_ID,CPRDIV_NAME";
                }
            }
            if (ShowCat == "1")
            {
                if (queryCol == "")
                {
                    queryCol = "STAFF_WORKER,STAFF_WORKER_NAME";
                }
                else
                {
                    queryCol += ",STAFF_WORKER,STAFF_WORKER_NAME";
                }
            }
            if (ShowMon == "1")
            {
                if (queryCol == "")
                {
                    queryCol = "SLPRCDMNTH_NUMBR";
                }
                else
                {
                    queryCol += ",SLPRCDMNTH_NUMBR";
                }
            }
            objEntityBulkPrint.QueryColumns = queryCol;
            DataTable dt = objBusiness.ReadSummarySecond(objEntityBulkPrint);
            string strHtml="";
            decimal decBA = 0, decBD = 0, decMA = 0, decMD = 0, decTA = 0, decTD = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strDept = "", strDiv = "", strCtgry = "", strJob = "",strMon="";
                string strDeptI = "", strDivI = "", strCtgryI = "", strJobI = "", strMonI = "";

                if (ShowDep == "1")
                {
                    strDept = dt.Rows[i]["CPRDEPT_NAME"].ToString();
                    strDeptI = dt.Rows[i]["CPRDEPT_ID"].ToString();
                }
                if (ShowDiv == "1")
                {
                    strDiv = dt.Rows[i]["CPRDIV_NAME"].ToString();
                    strDivI = dt.Rows[i]["CPRDIV_ID"].ToString();
                }
                if (ShowCat == "1")
                {
                    strCtgry = dt.Rows[i]["STAFF_WORKER_NAME"].ToString();
                    strCtgryI = dt.Rows[i]["STAFF_WORKER"].ToString();
                }
                if (ShowMon == "1")
                {
                    strMon = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(dt.Rows[i]["SLPRCDMNTH_NUMBR"].ToString()));
                    strMonI = dt.Rows[i]["SLPRCDMNTH_NUMBR"].ToString();
                }

               decBA += Convert.ToDecimal(dt.Rows[i]["BA"].ToString());
               decBD += Convert.ToDecimal(dt.Rows[i]["BD"].ToString());
               decMA += Convert.ToDecimal(dt.Rows[i]["MA"].ToString());
               decMD += Convert.ToDecimal(dt.Rows[i]["MD"].ToString());
               decTA += Convert.ToDecimal(dt.Rows[i]["TA"].ToString());
               decTD += Convert.ToDecimal(dt.Rows[i]["TD"].ToString());

               strHtml += "<tr>";
               strHtml += "<td class=\"tr_l dep_1 grq0\">" + strDept + "</td>";
               strHtml += "<td class=\"tr_l div_1 grq1\">" + strDiv + "</td>";
               strHtml += "<td class=\"tr_l cat_1 grq2\">" + strCtgry + "</td>";
               strHtml += "<td class=\"tr_l job_1 grq3\"></td>";
               strHtml += "<td class=\"tr_c sta_1 grq4\">" + strMon + "</td>";
               strHtml += "<td class=\" tr_r m1\">";
               strHtml += "<a onclick=\"return ShowSummaryLevel3('" + strDeptI + "','" + strDivI + "','" + strCtgryI + "','" + strMonI + "',1,0);\" href=\"#\" class=\"bt_dtl_1\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["BA"].ToString()), roundNum).ToString("0.00"), objEntityCommon) + "</a>";
               strHtml += "</td>";
               strHtml += "<td class=\"tr_r m2\">";
               strHtml += "<a onclick=\"return ShowSummaryLevel3('" + strDeptI + "','" + strDivI + "','" + strCtgryI + "','" + strMonI + "',2,0);\" href=\"#\" class=\"bt_dtl_1\">" +objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["BD"].ToString()), roundNum).ToString("0.00"), objEntityCommon) + "</a>";
               strHtml += "</td>";
               strHtml += "<td class=\"tr_r m3\">";
               strHtml += "<a onclick=\"return ShowSummaryLevel3('" + strDeptI + "','" + strDivI + "','" + strCtgryI + "','" + strMonI + "',3,0);\" href=\"#\" class=\"bt_dtl_1\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["MA"].ToString()), roundNum).ToString("0.00"), objEntityCommon)+ "</a>";
               strHtml += "</td>";
               strHtml += "<td class=\"tr_r m4\">";
               strHtml += "<a onclick=\"return ShowSummaryLevel3('" + strDeptI + "','" + strDivI + "','" + strCtgryI + "','" + strMonI + "',4,0);\" href=\"#\" class=\"bt_dtl_1\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["MD"].ToString()), roundNum).ToString("0.00"), objEntityCommon) + "</a>";
               strHtml += "</td>";
               strHtml += "<td class=\" tr_r m5\">";
               strHtml += "<a onclick=\"return ShowSummaryLevel3('" + strDeptI + "','" + strDivI + "','" + strCtgryI + "','" + strMonI + "',5,0);\" href=\"#\" class=\"bt_dtl_1\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["TA"].ToString()), roundNum).ToString("0.00"), objEntityCommon) + "</a>";
               strHtml += "</td>";
               strHtml += "<td class=\" tr_r m6\">";
               strHtml += "<a onclick=\"return ShowSummaryLevel3('" + strDeptI + "','" + strDivI + "','" + strCtgryI + "','" + strMonI + "',6,0);\" href=\"#\" class=\"bt_dtl_1\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["TD"].ToString()), roundNum).ToString("0.00"), objEntityCommon) + "</a>";
               strHtml += "</td>";
               strHtml += "</tr>";                          
            }
            sts[0] = strHtml;
            strHtml = "";
            strHtml += "<tr>";
            strHtml += "<th class=\"dep_1 grq0\"></th>";
            strHtml += "<th class=\"div_1 grq1\"></th>";
            strHtml += "<th class=\"cat_1 grq2\"></th>";
            strHtml += "<th class=\"job_1 grq3\"></th>";
            strHtml += "<th class=\"tr_r grq4\">Total</th>";
            strHtml += "<th class=\"tr_r m1\">";
            strHtml += "<a onclick=\"return ShowSummaryLevel3('','','','" + month + "',1,0);\" href=\"#area_sec1\" class=\"bt_dtl_1\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decBA, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
            strHtml += "</th>";
            strHtml += "<th class=\"tr_r m2\">";
            strHtml += "<a onclick=\"return ShowSummaryLevel3('','','','" + month + "',2,0);\" href=\"#area_sec1\" class=\"bt_dtl_1\">" +objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decBD, roundNum).ToString("0.00"), objEntityCommon)  + "</a>";
            strHtml += "</th>";
            strHtml += "<th class=\"tr_r m3\">";
            strHtml += "<a onclick=\"return ShowSummaryLevel3('','','','" + month + "',3,0);\" href=\"#area_sec1\" class=\"bt_dtl_1\">" +objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decMA, roundNum).ToString("0.00"), objEntityCommon)  + "</a>";
            strHtml += "</th>";
            strHtml += "<th class=\"tr_r m4\">";
            strHtml += "<a onclick=\"return ShowSummaryLevel3('','','','" + month + "',4,0);\" href=\"#area_sec1\" class=\"bt_dtl_1\">" +objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decMD, roundNum).ToString("0.00"), objEntityCommon)  + "</a>";
            strHtml += "</th>";
            strHtml += "<th class=\"tr_r m5\">";
            strHtml += "<a onclick=\"return ShowSummaryLevel3('','','','" + month + "',5,0);\" href=\"#area_sec1\" class=\"bt_dtl_1\">" +objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTA, roundNum).ToString("0.00"), objEntityCommon)  + "</a>";
            strHtml += "</th>";
            strHtml += "<th class=\"tr_r m6\">";
            strHtml += "<a onclick=\"return ShowSummaryLevel3('','','','" + month + "',6,0);\" href=\"#area_sec1\" class=\"bt_dtl_1\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTD, roundNum).ToString("0.00"), objEntityCommon) + "</a>";
            strHtml += "</th>";
            strHtml += "</tr>";
            sts[1] = strHtml;
        }
        catch (Exception ex)
        {

        }
        return sts;
    }
    [System.Web.Services.WebMethod]
    public static string[] ShowLevel3(string orgID, string corpId, string year, string month, string dept, string divsn, string job, string desg, string emp, string Addtn, string Dedtn, string catgry, string method, string Level, string source,
        string ShowEmpCode,string ShowEmpName,string ShowDept,string ShowDesg,string ShowJob,string BAids,string BDids,string MAids,string MDids,string Dcm,string Crn)
    {
        string[] sts = new string[2];
        try
        {
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(Crn);
            int roundNum = Convert.ToInt32(Dcm);


            clsEntityEmployeeAddDedReport objEntityBulkPrint = new clsEntityEmployeeAddDedReport();
            clsBusinessEmployeeAddDedReport objBusiness = new clsBusinessEmployeeAddDedReport();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            objEntityBulkPrint.CorpId = Convert.ToInt32(corpId);
            objEntityBulkPrint.OrgId = Convert.ToInt32(orgID);
            objEntityBulkPrint.Year = Convert.ToInt32(year);
            objEntityBulkPrint.Months = month;
            objEntityBulkPrint.DepartmentIds = dept;
            objEntityBulkPrint.DivisionIds = divsn;
            objEntityBulkPrint.DesignationIds = desg;
            objEntityBulkPrint.EmployeeIds = emp;
            objEntityBulkPrint.AdditionIds = Addtn;
            objEntityBulkPrint.DeductionIds = Dedtn;
            objEntityBulkPrint.CategoryId = Convert.ToInt32(catgry);
            string queryCol = "";
            if (ShowDept == "1" || Level=="0")
            {
                queryCol = "CPRDEPT_ID,CPRDEPT_NAME";
            }
            if (Level == "1")
            {
                if (queryCol == "")
                {
                    queryCol = "CPRDIV_ID,CPRDIV_NAME";
                }
                else
                {
                    queryCol += ",CPRDIV_ID,CPRDIV_NAME";
                }
            }
            if (Level == "2")
            {
                if (queryCol == "")
                {
                    queryCol = "STAFF_WORKER,STAFF_WORKER_NAME";
                }
                else
                {
                    queryCol += ",STAFF_WORKER,STAFF_WORKER_NAME";
                }
            }
            if (Level == "4")
            {
                if (queryCol == "")
                {
                    queryCol = "SLPRCDMNTH_NUMBR";
                }
                else
                {
                    queryCol += ",SLPRCDMNTH_NUMBR";
                }
            }
            if (ShowEmpCode == "1" || ShowEmpName=="1")
            {
                if (queryCol == "")
                {
                    queryCol = "USR_CODE,USR_NAME";
                }
                else
                {
                    queryCol += ",USR_CODE,USR_NAME";
                }
            }
            if (ShowDesg == "1")
            {
                if (queryCol == "")
                {
                    queryCol = "DSGN_ID,DSGN_NAME";
                }
                else
                {
                    queryCol += ",DSGN_ID,DSGN_NAME";
                }
            }
            objEntityBulkPrint.QueryColumns = queryCol;
            if (source == "0")
            {
                objEntityBulkPrint.BAids = "ALL";
                objEntityBulkPrint.BDids = "ALL";
                objEntityBulkPrint.MAids = "ALL";
                objEntityBulkPrint.MDids = "ALL";
            }
            else
            {
                if (BAids == "")
                {
                    BAids = "0";
                }
                if (BDids == "")
                {
                    BDids = "0";
                }
                if (MAids == "")
                {
                    MAids = "0";
                }
                if (MDids == "")
                {
                    MDids = "0";
                }
                objEntityBulkPrint.BAids = BAids;
                objEntityBulkPrint.BDids = BDids;
                objEntityBulkPrint.MAids = MAids;
                objEntityBulkPrint.MDids = MDids;
            }
            DataTable dt = objBusiness.ReadSummaryThird(objEntityBulkPrint);
            DataTable dtGrp = objBusiness.ReadSummaryThirdGrp(objEntityBulkPrint);
            DataView dtview = new DataView(dtGrp);


            DataView dtviewAD = new DataView(dt);
            DataTable dtDistdeptAD = dtviewAD.ToTable(true, "PAYRL_ID", "PAYRL_NAME", "MODE1");



            DataTable dtDistdept = new DataTable();          
            string strSumTypCol = "";
            if (Level == "0")
            {
                dtDistdept = dtview.ToTable(true, "CPRDEPT_ID", "CPRDEPT_NAME");
                strSumTypCol = "CPRDEPT_ID";
            }
            else if (Level == "1")
            {
                dtDistdept = dtview.ToTable(true,"CPRDIV_ID", "CPRDIV_NAME");
                strSumTypCol = "CPRDIV_ID";
            }
            else if (Level == "2")
            {
                dtDistdept = dtview.ToTable(true,"STAFF_WORKER", "STAFF_WORKER_NAME");
                strSumTypCol = "STAFF_WORKER";
            }
            else if (Level == "4")
            {
                dtDistdept = dtview.ToTable(true, "SLPRCDMNTH_NUMBR");
                strSumTypCol = "SLPRCDMNTH_NUMBR";
            }
            DataRow[] drMode1 = dtDistdeptAD.Select("MODE1=1");
            DataRow[] drMode2 = dtDistdeptAD.Select("MODE1=2");
            DataRow[] drMode3 = dtDistdeptAD.Select("MODE1=3");
            DataRow[] drMode4 = dtDistdeptAD.Select("MODE1=4");
            int Mode1Cnt = drMode1.Length+1;
            int Mode2Cnt = drMode2.Length+1;
            int Mode3Cnt = drMode3.Length+1;
            int Mode4Cnt = drMode4.Length+1;

            int ColSpanB = 0;
            string strFilterCbx = "";
            if (source == "0")
            {
                strFilterCbx += "<button class=\"pull-right cls_ad2\" onclick=\"return false;\"><i class=\"fa fa-close\"></i></button>";
                strFilterCbx += "<li class=\"dropdown-item\" href=\"#\">";
                strFilterCbx += "<label class=\"form1 mar_bo\">";
                strFilterCbx += "<span class=\"button-checkbox\">";
                strFilterCbx += "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" onclick=\"ClickCbxColLevel3('')\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>&nbsp;</button>";
                strFilterCbx += "<input type=\"checkbox\" class=\"hidden\" checked=\"\" id=\"cbx3Lev0\" value=\"0\">";
                strFilterCbx += "</span>";
                strFilterCbx += "<p class=\"pz_s\">Employee ID</p>";
                strFilterCbx += "</li>";
                strFilterCbx += "<li class=\"dropdown-item\" href=\"#\">";
                strFilterCbx += "<label class=\"form1 mar_bo\">";
                strFilterCbx += "<span class=\"button-checkbox\">";
                strFilterCbx += "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" onclick=\"ClickCbxColLevel3('')\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>&nbsp;</button>";
                strFilterCbx += "<input type=\"checkbox\" class=\"hidden\" checked=\"\" id=\"cbx3Lev1\" value=\"1\">";
                strFilterCbx += "</span>";
                strFilterCbx += " <p class=\"pz_s\">Employee</p>";
                strFilterCbx += "</li>";
                strFilterCbx += "<li class=\"dropdown-item\" href=\"#\">";
                strFilterCbx += "<label class=\"form1 mar_bo\">";
                strFilterCbx += "<span class=\"button-checkbox\">";
                strFilterCbx += "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" onclick=\"ClickCbxColLevel3('')\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>&nbsp;</button>";
                strFilterCbx += "<input type=\"checkbox\" class=\"hidden\" checked=\"\" id=\"cbx3Lev2\" value=\"2\">";
                strFilterCbx += "</span>";
                strFilterCbx += "<p class=\"pz_s\">Department</p>";
                strFilterCbx += "</label>";
                strFilterCbx += "</li>";
                strFilterCbx += "<li class=\"dropdown-item\" href=\"#\">";
                strFilterCbx += "<label class=\"form1 mar_bo\">";
                strFilterCbx += "<span class=\"button-checkbox\">";
                strFilterCbx += "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" onclick=\"ClickCbxColLevel3('')\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>&nbsp;</button>";
                strFilterCbx += "<input type=\"checkbox\" class=\"hidden\" checked=\"\" id=\"cbx3Lev3\" value=\"3\">";
                strFilterCbx += "</span>";
                strFilterCbx += "<p class=\"pz_s\">Designation</p>";
                strFilterCbx += "</label>";
                strFilterCbx += "</li>";
                strFilterCbx += "<li class=\"dropdown-item\" href=\"#\">";
                strFilterCbx += "<label class=\"form1 mar_bo\">";
                strFilterCbx += "<span class=\"button-checkbox\">";
                strFilterCbx += "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" onclick=\"ClickCbxColLevel3('')\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>&nbsp;</button>";
                strFilterCbx += "<input type=\"checkbox\" class=\"hidden\" checked=\"\" id=\"cbx3Lev4\" value=\"4\">";
                strFilterCbx += "</span>";
                strFilterCbx += "<p class=\"pz_s\">Job</p>";
                strFilterCbx += "</label>";
                strFilterCbx += "</li>";
            }

             string strHtml="";
             strHtml += "<thead class=\"thead1\">";
             strHtml += "<tr>";
             if (ShowEmpCode == "1")
             {
                 ColSpanB++;
                 strHtml += "<th class=\"th_b1 tr_l em_r\" rowspan=\"2\">Employee ID</th>";
             }
             if (ShowEmpName == "1")
             {
                 ColSpanB++;
                 strHtml += "<th class=\"th_b7 tr_l em_r1\" rowspan=\"2\">Employee</th>";
             }
             if (ShowDept == "1" && Level!="0")
             {
                 ColSpanB++;
                 strHtml += "<th class=\"th_b7 tr_l em_r\" rowspan=\"2\">Department</th>";
             }
             if (ShowDesg == "1")
             {
                 ColSpanB++;
                 strHtml += "<th class=\"th_b7 tr_l em_r1\" rowspan=\"2\">Designation</th>";
             }
             if (ShowJob == "1")
             {
                 ColSpanB++;
                 strHtml += "<th class=\"th_b7 tr_l em_r1\" rowspan=\"2\">Job</th>";
             }
             if(objEntityBulkPrint.BAids!="0")
             strHtml += "<th class=\"tr_c\" colspan=\"" + Mode1Cnt + "\">Additions</th>";
             if (objEntityBulkPrint.BDids != "0")
             strHtml += "<th class=\"\" colspan=\"" + Mode2Cnt + "\">Deductions</th>";
             if (objEntityBulkPrint.MAids != "0")
             strHtml += "<th class=\"\" colspan=\"" + Mode3Cnt + "\">Other Additions (Manual)</th>";
             if (objEntityBulkPrint.MDids != "0")
             strHtml += "<th class=\"\" colspan=\"" + Mode4Cnt + "\">Other Deductions (Manual)</th>";
             strHtml += "<th class=\"th_b5\" rowspan=\"2\">Total<br>Additions</th>";
             strHtml += "<th class=\"th_b1_4\" rowspan=\"2\">Total<br>Deductions</th>";
             strHtml += "</tr>";
             strHtml += "<tr>";


             if (source == "0")
             {
                 strFilterCbx += "<ul class=\"ul_grp1\" id=\"lev3BA\">";
                 strFilterCbx += "<li class=\"dropdown-item li_g\" href=\"#\">";
                 strFilterCbx += "<label class=\"form1 mar_bo\">";
                 strFilterCbx += "<span class=\"button-checkbox lbr_chk\">";
                 strFilterCbx += "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" onclick=\"ClickCbxColLevel3('BA')\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>&nbsp;</button>";
                 strFilterCbx += "<input type=\"checkbox\" class=\"hidden\" checked=\"\" id=\"lev3cbxBA\">";
                 strFilterCbx += "</span>";
                 strFilterCbx += "<p class=\"pz_s\">Additions</p>";
                 strFilterCbx += "</label>";
                 strFilterCbx += "</li>";
             }
             foreach (DataRow dr1 in drMode1)
             {
                 strHtml += "<th title=\"Title Name\">" + dr1["PAYRL_NAME"].ToString() + "</th>";
                 if (source == "0")                 
                 {
                     strFilterCbx += "<li class=\"dropdown-item\" href=\"#\">";
                     strFilterCbx += "<label class=\"form1 mar_bo\">";
                     strFilterCbx += "<span class=\"button-checkbox\">";
                     strFilterCbx += "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" onclick=\"ClickCbxColLevel3('')\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>&nbsp;</button>";
                     strFilterCbx += "<input type=\"checkbox\" class=\"hidden\" checked=\"\" id=\"cbx3LevBA" + dr1["PAYRL_ID"].ToString() + "\" value=\"" + dr1["PAYRL_ID"].ToString() + "\">";
                     strFilterCbx += "</span>";
                     strFilterCbx += "<p class=\"pz_s\">" + dr1["PAYRL_NAME"].ToString() + "</p>";
                     strFilterCbx += "</label>";
                     strFilterCbx += "</li>";
                 }

             }
             if (source == "0")
             {
                 strFilterCbx += "</ul>";
             }
             if (objEntityBulkPrint.BAids != "0")
             strHtml += "<th title=\"Title Name\">Total</th>";


             if (source == "0")
             {
                 strFilterCbx += "<ul class=\"ul_grp1\" id=\"lev3BD\">";
                 strFilterCbx += "<li class=\"dropdown-item li_g\" href=\"#\">";
                 strFilterCbx += "<label class=\"form1 mar_bo\">";
                 strFilterCbx += "<span class=\"button-checkbox lbr_chk\">";
                 strFilterCbx += "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" onclick=\"ClickCbxColLevel3('BD')\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>&nbsp;</button>";
                 strFilterCbx += "<input type=\"checkbox\" class=\"hidden\" checked=\"\" id=\"lev3cbxBD\">";
                 strFilterCbx += "</span>";
                 strFilterCbx += "<p class=\"pz_s\">Deductions</p>";
                 strFilterCbx += "</label>";
                 strFilterCbx += "</li>";
             }
             foreach (DataRow dr1 in drMode2)
             {
                 strHtml += "<th title=\"Title Name\">" + dr1["PAYRL_NAME"].ToString() + "</th>";
                 if (source == "0")
                 {
                     strFilterCbx += "<li class=\"dropdown-item\" href=\"#\">";
                     strFilterCbx += "<label class=\"form1 mar_bo\">";
                     strFilterCbx += "<span class=\"button-checkbox\">";
                     strFilterCbx += "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" onclick=\"ClickCbxColLevel3('')\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>&nbsp;</button>";
                     strFilterCbx += "<input type=\"checkbox\" class=\"hidden\" checked=\"\" id=\"cbx3LevBD" + dr1["PAYRL_ID"].ToString() + "\" value=\"" + dr1["PAYRL_ID"].ToString() + "\">";
                     strFilterCbx += "</span>";
                     strFilterCbx += "<p class=\"pz_s\">" + dr1["PAYRL_NAME"].ToString() + "</p>";
                     strFilterCbx += "</label>";
                     strFilterCbx += "</li>";
                 }
             }
             if (source == "0")
             {
                 strFilterCbx += "</ul>";
             }
             if (objEntityBulkPrint.BDids != "0")
             strHtml += "<th title=\"Title Name\">Total</th>";

             if (source == "0")
             {
                 strFilterCbx += "<ul class=\"ul_grp1\" id=\"lev3MA\">";
                 strFilterCbx += "<li class=\"dropdown-item li_g\" href=\"#\">";
                 strFilterCbx += "<label class=\"form1 mar_bo\">";
                 strFilterCbx += "<span class=\"button-checkbox lbr_chk\">";
                 strFilterCbx += "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" onclick=\"ClickCbxColLevel3('MA')\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>&nbsp;</button>";
                 strFilterCbx += "<input type=\"checkbox\" class=\"hidden\" checked=\"\" id=\"lev3cbxMA\">";
                 strFilterCbx += "</span>";
                 strFilterCbx += "<p class=\"pz_s\">Manual Additions</p>";
                 strFilterCbx += "</label>";
                 strFilterCbx += "</li>";
             }
             foreach (DataRow dr1 in drMode3)
             {
                 strHtml += "<th title=\"Title Name\">" + dr1["PAYRL_NAME"].ToString() + "</th>";
                 if (source == "0")
                 {
                     strFilterCbx += "<li class=\"dropdown-item\" href=\"#\">";
                     strFilterCbx += "<label class=\"form1 mar_bo\">";
                     strFilterCbx += "<span class=\"button-checkbox\">";
                     strFilterCbx += "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" onclick=\"ClickCbxColLevel3('')\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>&nbsp;</button>";
                     strFilterCbx += "<input type=\"checkbox\" class=\"hidden\" checked=\"\" id=\"cbx3LevMA" + dr1["PAYRL_ID"].ToString() + "\" value=\"" + dr1["PAYRL_ID"].ToString() + "\">";
                     strFilterCbx += "</span>";
                     strFilterCbx += "<p class=\"pz_s\">" + dr1["PAYRL_NAME"].ToString() + "</p>";
                     strFilterCbx += "</label>";
                     strFilterCbx += "</li>";
                 }
             }
             if (source == "0")
             {
                 strFilterCbx += "</ul>";
             }
             if (objEntityBulkPrint.MAids != "0")
             strHtml += "<th title=\"Title Name\">Total</th>";
             if (source == "0")
             {
                 strFilterCbx += "<ul class=\"ul_grp1\" id=\"lev3MD\">";
                 strFilterCbx += "<li class=\"dropdown-item li_g\" href=\"#\">";
                 strFilterCbx += "<label class=\"form1 mar_bo\">";
                 strFilterCbx += "<span class=\"button-checkbox lbr_chk\">";
                 strFilterCbx += "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" onclick=\"ClickCbxColLevel3('MD')\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>&nbsp;</button>";
                 strFilterCbx += "<input type=\"checkbox\" class=\"hidden\" checked=\"\" id=\"lev3cbxMD\">";
                 strFilterCbx += "</span>";
                 strFilterCbx += "<p class=\"pz_s\">Manual Deductions</p>";
                 strFilterCbx += "</label>";
                 strFilterCbx += "</li>";
             }
             foreach (DataRow dr1 in drMode4)
             {
                 strHtml += "<th title=\"Title Name\">" + dr1["PAYRL_NAME"].ToString() + "</th>";
                 if (source == "0")
                 {
                     strFilterCbx += "<li class=\"dropdown-item\" href=\"#\">";
                     strFilterCbx += "<label class=\"form1 mar_bo\">";
                     strFilterCbx += "<span class=\"button-checkbox\">";
                     strFilterCbx += "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" onclick=\"ClickCbxColLevel3('')\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>&nbsp;</button>";
                     strFilterCbx += "<input type=\"checkbox\" class=\"hidden\" checked=\"\"id=\"cbx3LevMD" + dr1["PAYRL_ID"].ToString() + "\" value=\"" + dr1["PAYRL_ID"].ToString() + "\">";
                     strFilterCbx += "</span>";
                     strFilterCbx += "<p class=\"pz_s\">" + dr1["PAYRL_NAME"].ToString() + "</p>";
                     strFilterCbx += "</label>";
                     strFilterCbx += "</li>";
                 }
             }
             if (source == "0")
             {
                 strFilterCbx += "</ul>";
             }
             if (objEntityBulkPrint.MDids != "0")
             strHtml += "<th title=\"Title Name\">Total</th>";

             strHtml += "</tr>";
             strHtml += "</thead> <tbody>";


            string GrpName = "", SumQry = "", SumQry1 = "";
            decimal GrandBa = 0, GrandBd = 0, GrandMa = 0, GrandMd = 0;
            for (int i = 0; i < dtDistdept.Rows.Count; i++)
            {    
             
                  if (Level == "4")
                  {
                      GrpName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(dtDistdept.Rows[i][0].ToString()));
                  }
                  else
                  {
                      GrpName = dtDistdept.Rows[i][1].ToString();
                  }
                  strHtml += "<tr>";
                  strHtml += "<td class=\"tr_l clr_hrd1\" colspan=\"" + ColSpanB + "\">" + GrpName + "</td>";
                 
                  foreach (DataRow dr1 in drMode1)
                  {
                  strHtml += "<td class=\"tr_l clr_hrd1\"></td>";
                  }
                  if (objEntityBulkPrint.BAids != "0")
                  strHtml += "<td class=\"tr_l clr_hrd1\"></td>";
                  foreach (DataRow dr1 in drMode2)
                  {
                  strHtml += "<td class=\"tr_l clr_hrd1\"></td>";
                  }
                  if (objEntityBulkPrint.BDids != "0")
                 strHtml += "<td class=\"tr_l clr_hrd1\"></td>";
                 foreach (DataRow dr1 in drMode3)
                  {
                  strHtml += "<td class=\"tr_l clr_hrd1\"></td>";
                  }
                 if (objEntityBulkPrint.MAids != "0")
                 strHtml += "<td class=\"tr_l clr_hrd1\"></td>";
                 foreach (DataRow dr1 in drMode4)
                  {
                  strHtml += "<td class=\"tr_l clr_hrd1\"></td>";
                  }
                 if (objEntityBulkPrint.MDids != "0")
                 strHtml += "<td class=\"tr_l clr_hrd1\"></td>";


                 strHtml += "<td class=\"tr_l clr_hrd1\"></td>";
                 strHtml += "<td class=\"tr_l clr_hrd1\"></td>";
                 strHtml += "</tr>";

                 SumQry=strSumTypCol + "=" + dtDistdept.Rows[i][0].ToString();

                 decimal GrpwiseTotBa = 0, GrpwiseTotBd = 0, GrpwiseTotMa = 0, GrpwiseTotMd = 0;

                 DataRow[] dr = dtGrp.Select("" + strSumTypCol + "='" + dtDistdept.Rows[i][0].ToString() + "'");

                 foreach (DataRow dRow in dr)
                 {
                     SumQry1 = "";
                     strHtml += "<tr>";
                     if(ShowEmpCode=="1"){
                         strHtml += "<td class=\"tr_l\">" + dRow["USR_CODE"].ToString() + "</td>";
                         SumQry1 += " AND  USR_CODE='" + dRow["USR_CODE"].ToString() + "'";
                     }
                     if (ShowEmpName == "1"){
                         strHtml += "<td class=\"tr_l\">" + dRow["USR_NAME"].ToString() + "</td>";
                         SumQry1 += " AND  USR_NAME='" + dRow["USR_NAME"].ToString() + "'";
                     }
                     if (ShowDept == "1"){
                         if (Level != "0")
                         strHtml += "<td class=\"tr_l\">" + dRow["CPRDEPT_NAME"].ToString() + "</td>";
                         SumQry1 += " AND  CPRDEPT_ID=" + dRow["CPRDEPT_ID"].ToString();
                     }
                     if (ShowDesg == "1"){
                         strHtml += "<td class=\"tr_l\">" + dRow["DSGN_NAME"].ToString() + "</td>";
                         SumQry1 += " AND  DSGN_ID=" + dRow["DSGN_ID"].ToString();
                     }
                     if (ShowJob == "1")
                     strHtml += "<td class=\"tr_l\"></td>";
                     decimal decTotBa = 0;
                     foreach (DataRow dr1 in drMode1)
                     {
                         decimal curr = 0;
                         string StrCurr = dt.Compute("Sum(AMT)", "" + SumQry + SumQry1 + " AND MODE1=1 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                         if(StrCurr!="" && StrCurr!=null && StrCurr!="null")
                         curr = Convert.ToDecimal(StrCurr);
                         strHtml += "<td class=\"tr_r\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</td>";
                         decTotBa += curr;
                     }
                     if (objEntityBulkPrint.BAids != "0")
                     strHtml += "<td class=\"tr_r\">" +objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotBa, roundNum).ToString("0.00"), objEntityCommon)  + "</td>";
                     GrpwiseTotBa += decTotBa;
                     decimal decTotBd = 0;
                     foreach (DataRow dr1 in drMode2)
                     {
                         decimal curr = 0;
                         string StrCurr = dt.Compute("Sum(AMT)", "" + SumQry + SumQry1 + " AND MODE1=2 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                         if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                             curr = Convert.ToDecimal(StrCurr);
                         strHtml += "<td class=\"tr_r\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</td>";
                         decTotBd += curr;
                     }
                     if (objEntityBulkPrint.BDids != "0")
                     strHtml += "<td class=\"tr_r\">" +objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotBd, roundNum).ToString("0.00"), objEntityCommon)  + "</td>";
                     GrpwiseTotBd += decTotBd;
                     decimal decTotMa = 0;
                     foreach (DataRow dr1 in drMode3)
                     {
                         decimal curr = 0;
                         string StrCurr = dt.Compute("Sum(AMT)", "" + SumQry + SumQry1 + " AND MODE1=3 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                         if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                             curr = Convert.ToDecimal(StrCurr);
                         strHtml += "<td class=\"tr_r\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</td>";
                         decTotMa += curr;
                     }
                     if (objEntityBulkPrint.MAids != "0")
                     strHtml += "<td class=\"tr_r\">" +objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotMa, roundNum).ToString("0.00"), objEntityCommon)  + "</td>";
                     GrpwiseTotMa += decTotMa;
                     decimal decTotMd = 0;
                     foreach (DataRow dr1 in drMode4)
                     {
                         decimal curr = 0;
                         string StrCurr = dt.Compute("Sum(AMT)", "" + SumQry + SumQry1 + " AND MODE1=4 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                         if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                             curr = Convert.ToDecimal(StrCurr);
                         strHtml += "<td class=\"tr_r\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</td>";
                         decTotMd += curr;
                     }
                     if (objEntityBulkPrint.MDids != "0")
                     strHtml += "<td class=\"tr_r\">" +objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotMd, roundNum).ToString("0.00"), objEntityCommon)  + "</td>";
                     GrpwiseTotMd += decTotMd;
                     strHtml += "<td class=\"tr_r clr_hrd\">" +objBusinessLayer.AddCommasForNumberSeperation(Math.Round((decTotBa + decTotMa) , roundNum).ToString("0.00"), objEntityCommon) + "</td>";
                     strHtml += "<td class=\"tr_r clr_hrd\">" +objBusinessLayer.AddCommasForNumberSeperation(Math.Round((decTotBd + decTotMd) , roundNum).ToString("0.00"), objEntityCommon) + "</td>";
                     strHtml += "</tr>";
                 }

                    strHtml += "<tr class=\"clr_hrd_ttl\">";
                    strHtml += "<td class=\"tr_r\" colspan=\"" + ColSpanB + "\">Total</td>";
                    foreach (DataRow dr1 in drMode1)
                    {
                        decimal curr = 0;
                        string StrCurr = dt.Compute("Sum(AMT)", "" + SumQry + " AND MODE1=1 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                        if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                            curr = Convert.ToDecimal(StrCurr);
                        strHtml += "<td class=\"tr_r\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</td>";
                    }
                    if (objEntityBulkPrint.BAids != "0")
                    strHtml += "<td class=\"tr_r\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrpwiseTotBa, roundNum).ToString("0.00"), objEntityCommon) + "</td>";
                     foreach (DataRow dr1 in drMode2)
                     {
                         decimal curr = 0;
                         string StrCurr = dt.Compute("Sum(AMT)", "" + SumQry + " AND MODE1=2 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                         if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                             curr = Convert.ToDecimal(StrCurr);
                         strHtml += "<td class=\"tr_r\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</td>";
                     }
                     if (objEntityBulkPrint.BDids != "0")
                     strHtml += "<td class=\"tr_r\">" +objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrpwiseTotBd, roundNum).ToString("0.00"), objEntityCommon)  + "</td>";
                     foreach (DataRow dr1 in drMode3)
                     {
                         decimal curr = 0;
                         string StrCurr = dt.Compute("Sum(AMT)", "" + SumQry + " AND MODE1=3 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                         if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                             curr = Convert.ToDecimal(StrCurr);
                         strHtml += "<td class=\"tr_r\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</td>";
                     }
                     if (objEntityBulkPrint.MAids != "0")
                     strHtml += "<td class=\"tr_r\">" +objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrpwiseTotMa, roundNum).ToString("0.00"), objEntityCommon)  + "</td>";
                     foreach (DataRow dr1 in drMode4)
                     {
                         decimal curr = 0;
                         string StrCurr = dt.Compute("Sum(AMT)", "" + SumQry + " AND MODE1=4 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                         if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                             curr = Convert.ToDecimal(StrCurr);
                         strHtml += "<td class=\"tr_r\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</td>";
                     }
                     if (objEntityBulkPrint.MDids != "0")
                     strHtml += "<td class=\"tr_r\">" +objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrpwiseTotMd, roundNum).ToString("0.00"), objEntityCommon)  + "</td>";
                     strHtml += "<td class=\"tr_r\">" +objBusinessLayer.AddCommasForNumberSeperation(Math.Round((GrpwiseTotBa + GrpwiseTotMa), roundNum).ToString("0.00"), objEntityCommon)  + "</td>";
                     strHtml += "<td class=\"tr_r\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round((GrpwiseTotBd + GrpwiseTotMd), roundNum).ToString("0.00"), objEntityCommon) + "</td>";
                     strHtml += "</tr>";

                     GrandBa += GrpwiseTotBa;
                     GrandBd += GrpwiseTotBd;
                     GrandMa += GrpwiseTotMa;
                     GrandMd += GrpwiseTotMd;
            }

                    strHtml += " </tbody><tfoot class=\"clr_hrd\">";
                    strHtml += "<tr>";
                    strHtml += "<th class=\"tr_r\" colspan=\"" + ColSpanB + "\">Net Total</th>";
                    foreach (DataRow dr1 in drMode1)
                    {
                        decimal curr = 0;
                        string StrCurr = dt.Compute("Sum(AMT)", "MODE1=1 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                        if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                            curr = Convert.ToDecimal(StrCurr);
                        strHtml += "<th class=\"tr_r\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</th>";
                    }
                    if (objEntityBulkPrint.BAids != "0")
                    strHtml += "<th class=\"tr_r\">" +objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrandBa, roundNum).ToString("0.00"), objEntityCommon)  + "</th>";
                    foreach (DataRow dr1 in drMode2)
                    {
                        decimal curr = 0;
                        string StrCurr = dt.Compute("Sum(AMT)", "MODE1=2 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                        if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                            curr = Convert.ToDecimal(StrCurr);
                        strHtml += "<th class=\"tr_r\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</th>";
                    }
                    if (objEntityBulkPrint.BDids != "0")
                    strHtml += "<th class=\"tr_r\">" +objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrandBd, roundNum).ToString("0.00"), objEntityCommon)  + "</th>";
                    foreach (DataRow dr1 in drMode3)
                    {
                        decimal curr = 0;
                        string StrCurr = dt.Compute("Sum(AMT)", "MODE1=3 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                        if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                            curr = Convert.ToDecimal(StrCurr);
                        strHtml += "<th class=\"tr_r\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</th>";
                    }
                    if (objEntityBulkPrint.MAids != "0")
                    strHtml += "<th class=\"tr_r\">" +objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrandMa, roundNum).ToString("0.00"), objEntityCommon)  + "</th>";
                    foreach (DataRow dr1 in drMode4)
                    {
                        decimal curr = 0;
                        string StrCurr = dt.Compute("Sum(AMT)", "MODE1=4 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                        if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                            curr = Convert.ToDecimal(StrCurr);
                        strHtml += "<th class=\"tr_r\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</th>";
                    }
                    if (objEntityBulkPrint.MDids != "0")
                        strHtml += "<th class=\"tr_r\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrandMd, roundNum).ToString("0.00"), objEntityCommon) + "</th>";
                    strHtml += "<th class=\"tr_r\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round((GrandBa + GrandMa), roundNum).ToString("0.00"), objEntityCommon) + "</th>";
                    strHtml += "<th class=\"tr_r\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round((GrandBd + GrandMd), roundNum).ToString("0.00"), objEntityCommon) + "</th>";
                    strHtml += " </tr>";
                    strHtml += "</tfoot>";


                    sts[0] = strHtml;
                    sts[1] = strFilterCbx;


        }
        catch (Exception ex)
        {

        }
        return sts;
    }

    [System.Web.Services.WebMethod]
    public static string[] ShowLevel2M2(string orgID, string corpId, string year, string month, string dept, string divsn, string job, string desg, string emp, string Addtn, string Dedtn, string catgry, string method, string source,
        string ShowDep, string ShowDiv, string ShowCat, string ShowJob, string BAids, string BDids, string MAids, string MDids, string Mode, string Dcm, string Crn)
    {
        string[] sts = new string[2];
        try
        {
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(Crn);
            int roundNum = Convert.ToInt32(Dcm);

            clsEntityEmployeeAddDedReport objEntityBulkPrint = new clsEntityEmployeeAddDedReport();
            clsBusinessEmployeeAddDedReport objBusiness = new clsBusinessEmployeeAddDedReport();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            objEntityBulkPrint.CorpId = Convert.ToInt32(corpId);
            objEntityBulkPrint.OrgId = Convert.ToInt32(orgID);
            objEntityBulkPrint.Year = Convert.ToInt32(year);
            objEntityBulkPrint.Months = month;
            objEntityBulkPrint.DepartmentIds = dept;
            objEntityBulkPrint.DivisionIds = divsn;
            objEntityBulkPrint.DesignationIds = desg;
            objEntityBulkPrint.EmployeeIds = emp;
            objEntityBulkPrint.AdditionIds = Addtn;
            objEntityBulkPrint.DeductionIds = Dedtn;
            objEntityBulkPrint.CategoryId = Convert.ToInt32(catgry);
            string queryCol = "SLPRCDMNTH_NUMBR";
            if (ShowDep == "1")
            {
                queryCol += ",CPRDEPT_ID,CPRDEPT_NAME";
            }
            if (ShowDiv == "1")
            {
                queryCol += ",CPRDIV_ID,CPRDIV_NAME";
            }
            if (ShowCat == "1")
            {
                queryCol += ",STAFF_WORKER,STAFF_WORKER_NAME";
            }
            objEntityBulkPrint.QueryColumns = queryCol;          
            objEntityBulkPrint.BAids = BAids;
            objEntityBulkPrint.BDids = BDids;
            objEntityBulkPrint.MAids = MAids;
            objEntityBulkPrint.MDids = MDids;
            DataTable dt = objBusiness.ReadSummaryThird(objEntityBulkPrint);
            DataTable dtGrp = objBusiness.ReadSummaryThirdGrp(objEntityBulkPrint);
            DataView dtviewAD = new DataView(dt);
            DataTable dtDistdeptAD = dtviewAD.ToTable(true, "PAYRL_ID", "PAYRL_NAME", "MODE1");

            DataRow[] drMode1 = dtDistdeptAD.Select("MODE1=1");
            DataRow[] drMode2 = dtDistdeptAD.Select("MODE1=2");
            DataRow[] drMode3 = dtDistdeptAD.Select("MODE1=3");
            DataRow[] drMode4 = dtDistdeptAD.Select("MODE1=4");
            int Mode1Cnt = drMode1.Length + 1;
            int Mode2Cnt = drMode2.Length + 1;
            int Mode3Cnt = drMode3.Length + 1;
            int Mode4Cnt = drMode4.Length + 1;

            int ColSpanB = 1;
            string strFilterCbx = "";
            if (source == "0")
            {
                strFilterCbx += "<button class=\"pull-right cls_adM2\" onclick=\"return false;\"><i class=\"fa fa-close\"></i></button>";
                strFilterCbx += "<li class=\"dropdown-item\" href=\"#\">";
                strFilterCbx += "<label class=\"form1 mar_bo\">";
                strFilterCbx += "<span class=\"button-checkbox\">";
                strFilterCbx += "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" onclick=\"ClickCbxColLevel2M2('')\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>&nbsp;</button>";
                strFilterCbx += "<input type=\"checkbox\" class=\"hidden\" checked=\"\" id=\"cbx2M2Lev0\" value=\"0\">";
                strFilterCbx += "</span>";
                strFilterCbx += "<p class=\"pz_s\">Department</p>";
                strFilterCbx += "</label>";
                strFilterCbx += "</li>";
                strFilterCbx += "<li class=\"dropdown-item\" href=\"#\">";
                strFilterCbx += "<label class=\"form1 mar_bo\">";
                strFilterCbx += "<span class=\"button-checkbox\">";
                strFilterCbx += "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" onclick=\"ClickCbxColLevel2M2('')\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>&nbsp;</button>";
                strFilterCbx += "<input type=\"checkbox\" class=\"hidden\" checked=\"\" id=\"cbx2M2Lev1\" value=\"1\">";
                strFilterCbx += "</span>";
                strFilterCbx += "<p class=\"pz_s\">Division</p>";
                strFilterCbx += "</label>";
                strFilterCbx += "</li>";
                strFilterCbx += "<li class=\"dropdown-item\" href=\"#\">";
                strFilterCbx += "<label class=\"form1 mar_bo\">";
                strFilterCbx += "<span class=\"button-checkbox\">";
                strFilterCbx += "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" onclick=\"ClickCbxColLevel2M2('')\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>&nbsp;</button>";
                strFilterCbx += "<input type=\"checkbox\" class=\"hidden\" checked=\"\" id=\"cbx2M2Lev2\" value=\"2\">";
                strFilterCbx += "</span>";
                strFilterCbx += "<p class=\"pz_s\">Category</p>";
                strFilterCbx += "</label>";
                strFilterCbx += "</li>";
                strFilterCbx += "<li class=\"dropdown-item\" href=\"#\">";
                strFilterCbx += "<label class=\"form1 mar_bo\">";
                strFilterCbx += "<span class=\"button-checkbox\">";
                strFilterCbx += "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" onclick=\"ClickCbxColLevel2M2('')\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>&nbsp;</button>";
                strFilterCbx += "<input type=\"checkbox\" class=\"hidden\" checked=\"\" id=\"cbx2M2Lev3\" value=\"3\">";
                strFilterCbx += "</span>";
                strFilterCbx += "<p class=\"pz_s\">Job</p>";
                strFilterCbx += "</label>";
                strFilterCbx += "</li>";
            }

            string strHtml = "";
            strHtml += "<thead class=\"thead1\">";
            strHtml += "<tr>";
            if (ShowDep == "1")
            {
                ColSpanB++;
                strHtml += "<th class=\"th_b7 tr_l\" rowspan=\"2\">Department</th>";
            }
            if (ShowDiv == "1")
            {
                ColSpanB++;
                strHtml += "<th class=\"th_b7 tr_l\" rowspan=\"2\">Division</th>";
            }
            if (ShowCat == "1")
            {
                ColSpanB++;
                strHtml += "<th class=\"th_b7 tr_l\" rowspan=\"2\">Category</th>";
            }
            if (ShowJob == "1")
            {
                ColSpanB++;
                strHtml += "<th class=\"th_b7 tr_l\" rowspan=\"2\">Job</th>";
            }
            strHtml += "<th class=\"th_b7 tr_l\" rowspan=\"2\">Month</th>";

            if (objEntityBulkPrint.BAids != "0")
                strHtml += "<th class=\"tr_c\" colspan=\"" + Mode1Cnt + "\">Additions</th>";
            if (objEntityBulkPrint.BDids != "0")
                strHtml += "<th class=\"tr_c\" colspan=\"" + Mode2Cnt + "\">Deductions</th>";
            if (objEntityBulkPrint.MAids != "0")
                strHtml += "<th class=\"tr_c\" colspan=\"" + Mode3Cnt + "\">Manual Addition</th>";
            if (objEntityBulkPrint.MDids != "0")
                strHtml += "<th class=\"tr_c\" colspan=\"" + Mode4Cnt + "\">Manual Deduction</th>";
            if (Mode == "1" || Mode == "3" || Mode == "5" || Mode == "")
            strHtml += "<th class=\"th_b1 tr_r\" rowspan=\"2\">Total<br>Addition</th>";
            if (Mode == "2" || Mode == "4" || Mode == "6" || Mode == "")
            strHtml += "<th class=\"th_b1 tr_r\" rowspan=\"2\">Total<br>Deduction</th>";
            strHtml += "</tr>";
            strHtml += "<tr>";
            if (source == "0" )
            {
                if (Mode == "1" || Mode == "5" || Mode == "")
                {
                    strFilterCbx += "<ul class=\"ul_grp1\" id=\"lev2MBA\">";
                    strFilterCbx += "<li class=\"dropdown-item li_g\" href=\"#\">";
                    strFilterCbx += "<label class=\"form1 mar_bo\">";
                    strFilterCbx += "<span class=\"button-checkbox lbr_chk\">";
                    strFilterCbx += "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" onclick=\"ClickCbxColLevel2M2('BA')\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>&nbsp;</button>";
                    strFilterCbx += "<input type=\"checkbox\" class=\"hidden\" checked=\"\" id=\"lev2McbxBA\">";
                    strFilterCbx += "</span>";
                    strFilterCbx += "<p class=\"pz_s\">Additions</p>";
                    strFilterCbx += "</label>";
                    strFilterCbx += "</li>";
                }
            }
            foreach (DataRow dr1 in drMode1)
            {
                strHtml += "<th class=\"tr_r\">" + dr1["PAYRL_NAME"].ToString() + "</th>";
                if (source == "0")
                {

                    strFilterCbx += "<li class=\"dropdown-item\" href=\"#\">";
                    strFilterCbx += "<label class=\"form1 mar_bo\">";
                    strFilterCbx += "<span class=\"button-checkbox\">";
                    strFilterCbx += "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" onclick=\"ClickCbxColLevel2M2('')\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>&nbsp;</button>";
                    strFilterCbx += "<input type=\"checkbox\" class=\"hidden\" checked=\"\" id=\"cbx2MLevBA" + dr1["PAYRL_ID"].ToString() + "\" value=\"" + dr1["PAYRL_ID"].ToString() + "\">";
                    strFilterCbx += "</span>";
                    strFilterCbx += "<p class=\"pz_s\">" + dr1["PAYRL_NAME"].ToString() + "</p>";
                    strFilterCbx += "</label>";
                    strFilterCbx += "</li>";
                }

            }
            if (source == "0")
            {
                if (Mode == "1" || Mode == "5" || Mode == "")
                {
                    strFilterCbx += "</ul>";
                }
            }
            if (objEntityBulkPrint.BAids != "0")
                strHtml += "<th class=\"tr_r\">Total</th>";


            if (source == "0")
            {
                if (Mode == "2" || Mode == "6" || Mode == "")
                {
                    strFilterCbx += "<ul class=\"ul_grp1\" id=\"lev2MBD\">";
                    strFilterCbx += "<li class=\"dropdown-item li_g\" href=\"#\">";
                    strFilterCbx += "<label class=\"form1 mar_bo\">";
                    strFilterCbx += "<span class=\"button-checkbox lbr_chk\">";
                    strFilterCbx += "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" onclick=\"ClickCbxColLevel2M2('BD')\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>&nbsp;</button>";
                    strFilterCbx += "<input type=\"checkbox\" class=\"hidden\" checked=\"\" id=\"lev2McbxBD\">";
                    strFilterCbx += "</span>";
                    strFilterCbx += "<p class=\"pz_s\">Deductions</p>";
                    strFilterCbx += "</label>";
                    strFilterCbx += "</li>";
                }
            }
            foreach (DataRow dr1 in drMode2)
            {
                strHtml += "<th class=\"tr_r\">" + dr1["PAYRL_NAME"].ToString() + "</th>";
                if (source == "0")
                {
                    strFilterCbx += "<li class=\"dropdown-item\" href=\"#\">";
                    strFilterCbx += "<label class=\"form1 mar_bo\">";
                    strFilterCbx += "<span class=\"button-checkbox\">";
                    strFilterCbx += "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" onclick=\"ClickCbxColLevel2M2('')\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>&nbsp;</button>";
                    strFilterCbx += "<input type=\"checkbox\" class=\"hidden\" checked=\"\" id=\"cbx2MLevBD" + dr1["PAYRL_ID"].ToString() + "\" value=\"" + dr1["PAYRL_ID"].ToString() + "\">";
                    strFilterCbx += "</span>";
                    strFilterCbx += "<p class=\"pz_s\">" + dr1["PAYRL_NAME"].ToString() + "</p>";
                    strFilterCbx += "</label>";
                    strFilterCbx += "</li>";
                }
            }
            if (source == "0")
            {
                if (Mode == "2" || Mode == "6" || Mode == "")
                {
                    strFilterCbx += "</ul>";
                }
            }
            if (objEntityBulkPrint.BDids != "0")
                strHtml += "<th class=\"tr_r\">Total</th>";

            if (source == "0")
            {
                if (Mode == "3" || Mode == "5" || Mode == "")
                {
                    strFilterCbx += "<ul class=\"ul_grp1\" id=\"lev2MMA\">";
                    strFilterCbx += "<li class=\"dropdown-item li_g\" href=\"#\">";
                    strFilterCbx += "<label class=\"form1 mar_bo\">";
                    strFilterCbx += "<span class=\"button-checkbox lbr_chk\">";
                    strFilterCbx += "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" onclick=\"ClickCbxColLevel2M2('MA')\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>&nbsp;</button>";
                    strFilterCbx += "<input type=\"checkbox\" class=\"hidden\" checked=\"\" id=\"lev2McbxMA\">";
                    strFilterCbx += "</span>";
                    strFilterCbx += "<p class=\"pz_s\">Manual Additions</p>";
                    strFilterCbx += "</label>";
                    strFilterCbx += "</li>";
                }
            }
            foreach (DataRow dr1 in drMode3)
            {
                strHtml += "<th class=\"tr_r\">" + dr1["PAYRL_NAME"].ToString() + "</th>";
                if (source == "0")
                {
                    strFilterCbx += "<li class=\"dropdown-item\" href=\"#\">";
                    strFilterCbx += "<label class=\"form1 mar_bo\">";
                    strFilterCbx += "<span class=\"button-checkbox\">";
                    strFilterCbx += "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" onclick=\"ClickCbxColLevel2M2('')\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>&nbsp;</button>";
                    strFilterCbx += "<input type=\"checkbox\" class=\"hidden\" checked=\"\" id=\"cbx2MLevMA" + dr1["PAYRL_ID"].ToString() + "\" value=\"" + dr1["PAYRL_ID"].ToString() + "\">";
                    strFilterCbx += "</span>";
                    strFilterCbx += "<p class=\"pz_s\">" + dr1["PAYRL_NAME"].ToString() + "</p>";
                    strFilterCbx += "</label>";
                    strFilterCbx += "</li>";
                }
            }
            if (source == "0")
            {
                if (Mode == "3" || Mode == "5" || Mode == "")
                {
                    strFilterCbx += "</ul>";
                }
            }
            if (objEntityBulkPrint.MAids != "0")
                strHtml += "<th class=\"tr_r\">Total</th>";
            if (source == "0")
            {
                if (Mode == "4" || Mode == "6" || Mode == "")
                {
                    strFilterCbx += "<ul class=\"ul_grp1\" id=\"lev2MMD\">";
                    strFilterCbx += "<li class=\"dropdown-item li_g\" href=\"#\">";
                    strFilterCbx += "<label class=\"form1 mar_bo\">";
                    strFilterCbx += "<span class=\"button-checkbox lbr_chk\">";
                    strFilterCbx += "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" onclick=\"ClickCbxColLevel2M2('MD')\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>&nbsp;</button>";
                    strFilterCbx += "<input type=\"checkbox\" class=\"hidden\" checked=\"\" id=\"lev2McbxMD\">";
                    strFilterCbx += "</span>";
                    strFilterCbx += "<p class=\"pz_s\">Manual Deductions</p>";
                    strFilterCbx += "</label>";
                    strFilterCbx += "</li>";
                }
            }
            foreach (DataRow dr1 in drMode4)
            {
                strHtml += "<th class=\"tr_r\">" + dr1["PAYRL_NAME"].ToString() + "</th>";
                if (source == "0")
                {
                    strFilterCbx += "<li class=\"dropdown-item\" href=\"#\">";
                    strFilterCbx += "<label class=\"form1 mar_bo\">";
                    strFilterCbx += "<span class=\"button-checkbox\">";
                    strFilterCbx += "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" onclick=\"ClickCbxColLevel2M2('')\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>&nbsp;</button>";
                    strFilterCbx += "<input type=\"checkbox\" class=\"hidden\" checked=\"\"id=\"cbx2MLevMD" + dr1["PAYRL_ID"].ToString() + "\" value=\"" + dr1["PAYRL_ID"].ToString() + "\">";
                    strFilterCbx += "</span>";
                    strFilterCbx += "<p class=\"pz_s\">" + dr1["PAYRL_NAME"].ToString() + "</p>";
                    strFilterCbx += "</label>";
                    strFilterCbx += "</li>";
                }
            }
            if (source == "0")
            {
                if (Mode == "4" || Mode == "6" || Mode == "")
                {
                    strFilterCbx += "</ul>";
                }
            }
            if (objEntityBulkPrint.MDids != "0")
                strHtml += "<th class=\"tr_r\">Total</th>";
            strHtml += "</tr>";
            strHtml += "</thead> <tbody>";

            string SumQry1 = "";
            decimal GrandBa = 0, GrandBd = 0, GrandMa = 0, GrandMd = 0;
            for (int i = 0; i < dtGrp.Rows.Count; i++)
            {
                    string strDeptI = "", strDivI = "", strCtgryI = "", strMonI = ""; 
                    SumQry1 = "SLPRCDMNTH_NUMBR=" + dtGrp.Rows[i]["SLPRCDMNTH_NUMBR"].ToString();
                    strHtml += "<tr>";
                    if (ShowDep == "1")
                    {
                        strDeptI = dtGrp.Rows[i]["CPRDEPT_ID"].ToString();
                        strHtml += "<td class=\"tr_l\">" + dtGrp.Rows[i]["CPRDEPT_NAME"].ToString() + "</td>";
                        SumQry1 += " AND  CPRDEPT_ID=" + dtGrp.Rows[i]["CPRDEPT_ID"].ToString();
                    }
                    if (ShowDiv == "1")
                    {
                        strDivI = dtGrp.Rows[i]["CPRDIV_ID"].ToString();
                        strHtml += "<td class=\"tr_l\">" + dtGrp.Rows[i]["CPRDIV_NAME"].ToString() + "</td>";
                        SumQry1 += " AND  CPRDIV_ID=" + dtGrp.Rows[i]["CPRDIV_ID"].ToString();
                    }
                    if (ShowCat == "1")
                    {
                        strCtgryI = dtGrp.Rows[i]["STAFF_WORKER"].ToString();
                        strHtml += "<td class=\"tr_l\">" + dtGrp.Rows[i]["STAFF_WORKER_NAME"].ToString() + "</td>";
                        SumQry1 += " AND  STAFF_WORKER=" + dtGrp.Rows[i]["STAFF_WORKER"].ToString();
                    }
                    if (ShowJob == "1")
                        strHtml += "<td class=\"tr_l\"></td>";
                    strHtml += "<td class=\"tr_l\">"+CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(dtGrp.Rows[i]["SLPRCDMNTH_NUMBR"].ToString()))+"</td>";
                    strMonI = dtGrp.Rows[i]["SLPRCDMNTH_NUMBR"].ToString();

                    decimal decTotBa = 0;
                    foreach (DataRow dr1 in drMode1)
                    {
                        decimal curr = 0;
                        string StrCurr = dt.Compute("Sum(AMT)", ""+ SumQry1 + " AND MODE1=1 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                        if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                            curr = Convert.ToDecimal(StrCurr);
                        strHtml += "<td class=\"tr_r\"><a onclick=\"return ShowSummaryLevel3('" + strDeptI + "','" + strDivI + "','" + strCtgryI + "','" + strMonI + "',1,0);\" href=\"#area_sec1\" class=\"bt_sumry_2_md\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</a></td>";                       
                        decTotBa += curr;
                    }
                    if (objEntityBulkPrint.BAids != "0")
                        strHtml += "<td class=\"tr_r\"><a onclick=\"return ShowSummaryLevel3('" + strDeptI + "','" + strDivI + "','" + strCtgryI + "','" + strMonI + "',1,0);\" href=\"#area_sec1\" class=\"bt_sumry_2_md\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotBa, roundNum).ToString("0.00"), objEntityCommon) + "</a></td>";
                    decimal decTotBd = 0;
                     foreach (DataRow dr1 in drMode2)
                    {
                        decimal curr = 0;
                        string StrCurr = dt.Compute("Sum(AMT)", ""+ SumQry1 + " AND MODE1=2 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                        if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                            curr = Convert.ToDecimal(StrCurr);
                        strHtml += "<td class=\"tr_r\"><a onclick=\"return ShowSummaryLevel3('" + strDeptI + "','" + strDivI + "','" + strCtgryI + "','" + strMonI + "',2,0);\" href=\"#area_sec1\" class=\"bt_sumry_2_md\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</a></td>";                       
                        decTotBd += curr;
                    }
                    if (objEntityBulkPrint.BDids != "0")
                        strHtml += "<td class=\"tr_r\"><a onclick=\"return ShowSummaryLevel3('" + strDeptI + "','" + strDivI + "','" + strCtgryI + "','" + strMonI + "',2,0);\" href=\"#area_sec1\" class=\"bt_sumry_2_md\">" +objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotBd, roundNum).ToString("0.00"), objEntityCommon)  + "</a></td>";
                    decimal decTotMa = 0;
                    foreach (DataRow dr1 in drMode3)
                    {
                        decimal curr = 0;
                        string StrCurr = dt.Compute("Sum(AMT)", ""+ SumQry1 + " AND MODE1=3 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                        if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                            curr = Convert.ToDecimal(StrCurr);
                        strHtml += "<td class=\"tr_r\"><a onclick=\"return ShowSummaryLevel3('" + strDeptI + "','" + strDivI + "','" + strCtgryI + "','" + strMonI + "',3,0);\" href=\"#area_sec1\" class=\"bt_sumry_2_md\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</a></td>";                       
                        decTotMa += curr;
                    }
                    if (objEntityBulkPrint.MAids != "0")
                        strHtml += "<td class=\"tr_r\"><a onclick=\"return ShowSummaryLevel3('" + strDeptI + "','" + strDivI + "','" + strCtgryI + "','" + strMonI + "',3,0);\" href=\"#area_sec1\" class=\"bt_sumry_2_md\">" +objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotMa, roundNum).ToString("0.00"), objEntityCommon)  + "</a></td>";
                    decimal decTotMd = 0;
                    foreach (DataRow dr1 in drMode4)
                    {
                        decimal curr = 0;
                        string StrCurr = dt.Compute("Sum(AMT)", ""+ SumQry1 + " AND MODE1=4 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                        if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                            curr = Convert.ToDecimal(StrCurr);
                        strHtml += "<td class=\"tr_r\"><a onclick=\"return ShowSummaryLevel3('" + strDeptI + "','" + strDivI + "','" + strCtgryI + "','" + strMonI + "',4,0);\" href=\"#area_sec1\" class=\"bt_sumry_2_md\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</a></td>";                       
                        decTotMd += curr;
                    }
                    if (objEntityBulkPrint.MDids != "0")
                        strHtml += "<td class=\"tr_r\"><a onclick=\"return ShowSummaryLevel3('" + strDeptI + "','" + strDivI + "','" + strCtgryI + "','" + strMonI + "',4,0);\" href=\"#area_sec1\" class=\"bt_sumry_2_md\">" +objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotMd, roundNum).ToString("0.00"), objEntityCommon)  + "</a></td>";
                    if (Mode == "1" || Mode == "3" || Mode == "5" || Mode == "")
                        strHtml += "<td class=\"tr_r\"><a onclick=\"return ShowSummaryLevel3('" + strDeptI + "','" + strDivI + "','" + strCtgryI + "','" + strMonI + "',5,0);\" href=\"#area_sec1\" class=\"bt_sumry_2_md\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round((decTotBa + decTotMa), roundNum).ToString("0.00"), objEntityCommon) + "</a></td>";
                    if (Mode == "2" || Mode == "4" || Mode == "6" || Mode == "")
                        strHtml += "<td class=\"tr_r\"><a onclick=\"return ShowSummaryLevel3('" + strDeptI + "','" + strDivI + "','" + strCtgryI + "','" + strMonI + "',6,0);\" href=\"#area_sec1\" class=\"bt_sumry_2_md\">" +objBusinessLayer.AddCommasForNumberSeperation(Math.Round((decTotBd + decTotMd), roundNum).ToString("0.00"), objEntityCommon)  + "</a></td>";
                    strHtml += "</tr>";
                }
            strHtml += " </tbody><tfoot class=\"clr_hrd\">";
            strHtml += "<tr>";
            strHtml += "<th class=\"tr_r\" colspan=\"" + ColSpanB + "\">Total</th>";
            foreach (DataRow dr1 in drMode1)
            {
                decimal curr = 0;
                string StrCurr = dt.Compute("Sum(AMT)", "MODE1=1 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                    curr = Convert.ToDecimal(StrCurr);
                strHtml += "<th class=\"tr_r\"><a onclick=\"return ShowSummaryLevel3('','','','" + month + "',1,0);\" href=\"#area_sec1\" class=\"bt_sumry_2_md\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</a></th>";
                GrandBa += curr;
            }
            if (objEntityBulkPrint.BAids != "0")
                strHtml += "<th class=\"tr_r\"><a onclick=\"return ShowSummaryLevel3('','','','" + month + "',1,0);\" href=\"#area_sec1\" class=\"bt_sumry_2_md\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrandBa, roundNum).ToString("0.00"), objEntityCommon) + "</a></th>";

            foreach (DataRow dr1 in drMode2)
            {
                decimal curr = 0;
                string StrCurr = dt.Compute("Sum(AMT)", "MODE1=2 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                    curr = Convert.ToDecimal(StrCurr);
                strHtml += "<th class=\"tr_r\"><a onclick=\"return ShowSummaryLevel3('','','','" + month + "',2,0);\" href=\"#area_sec1\" class=\"bt_sumry_2_md\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</a></th>";
                GrandBd += curr;
            }
            if (objEntityBulkPrint.BDids != "0")
                strHtml += "<th class=\"tr_r\"><a onclick=\"return ShowSummaryLevel3('','','','" + month + "',2,0);\" href=\"#area_sec1\" class=\"bt_sumry_2_md\">" +objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrandBd, roundNum).ToString("0.00"), objEntityCommon)  + "</a></th>";
            foreach (DataRow dr1 in drMode3)
            {
                decimal curr = 0;
                string StrCurr = dt.Compute("Sum(AMT)", "MODE1=3 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                    curr = Convert.ToDecimal(StrCurr);
                strHtml += "<th class=\"tr_r\"><a onclick=\"return ShowSummaryLevel3('','','','" + month + "',3,0);\" href=\"#area_sec1\" class=\"bt_sumry_2_md\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</a></th>";
                GrandMa += curr;
            }
            if (objEntityBulkPrint.MAids != "0")
                strHtml += "<th class=\"tr_r\"><a onclick=\"return ShowSummaryLevel3('','','','" + month + "',3,0);\" href=\"#area_sec1\" class=\"bt_sumry_2_md\">" +objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrandMa, roundNum).ToString("0.00"), objEntityCommon)  + "</a></th>";
            foreach (DataRow dr1 in drMode4)
            {
                decimal curr = 0;
                string StrCurr = dt.Compute("Sum(AMT)", "MODE1=4 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                    curr = Convert.ToDecimal(StrCurr);
                strHtml += "<th class=\"tr_r\"><a onclick=\"return ShowSummaryLevel3('','','','" + month + "',4,0);\" href=\"#area_sec1\" class=\"bt_sumry_2_md\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) + "</a></th>";
                GrandMd += curr;
            }
            if (objEntityBulkPrint.MDids != "0")
                strHtml += "<th class=\"tr_r\"><a onclick=\"return ShowSummaryLevel3('','','','" + month + "',4,0);\" href=\"#area_sec1\" class=\"bt_sumry_2_md\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrandMd, roundNum).ToString("0.00"), objEntityCommon) + "</a></th>";
            if (Mode == "1" || Mode == "3" || Mode == "5" || Mode == "")
                strHtml += "<th class=\"tr_r\"><a onclick=\"return ShowSummaryLevel3('','','','" + month + "',5,0);\" href=\"#area_sec1\" class=\"bt_sumry_2_md\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round((GrandBa + GrandMa), roundNum).ToString("0.00"), objEntityCommon) + "</a></th>";
            if (Mode == "2" || Mode == "4" || Mode == "6" || Mode == "")
                strHtml += "<th class=\"tr_r\"><a onclick=\"return ShowSummaryLevel3('','','','" + month + "',6,0);\" href=\"#area_sec1\" class=\"bt_sumry_2_md\">" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round((GrandBd + GrandMd), roundNum).ToString("0.00"), objEntityCommon) + "</a></th>";
            strHtml += " </tr>";
            strHtml += "</tfoot>";


            sts[0] = strHtml;
            sts[1] = strFilterCbx;

        }
        catch (Exception ex)
        {

        }
        return sts;
    }


    [System.Web.Services.WebMethod]
    public static string PrintSummaryM1(string orgID, string corpId, string year, string month, string dept, string divsn, string job, string desg, string emp, string Addtn, string Dedtn, string catgry, string Dcm, string Crn,string Method)
    {
        string strImageName = "", strImagePath = "";
        try
        {
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(Crn);
            int roundNum = Convert.ToInt32(Dcm);

            clsEntityEmployeeAddDedReport objEntityBulkPrint = new clsEntityEmployeeAddDedReport();
            clsBusinessEmployeeAddDedReport objBusiness = new clsBusinessEmployeeAddDedReport();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            objEntityBulkPrint.CorpId = Convert.ToInt32(corpId);
            objEntityBulkPrint.OrgId = Convert.ToInt32(orgID);
            objEntityBulkPrint.Year = Convert.ToInt32(year);
            objEntityBulkPrint.Months = month;
            objEntityBulkPrint.DepartmentIds = dept;
            objEntityBulkPrint.DivisionIds = divsn;
            objEntityBulkPrint.DesignationIds = desg;
            objEntityBulkPrint.EmployeeIds = emp;
            objEntityBulkPrint.AdditionIds = Addtn;
            objEntityBulkPrint.DeductionIds = Dedtn;
            objEntityBulkPrint.CategoryId = Convert.ToInt32(catgry);
           
            clsBusinessLayer objBusinessC = new clsBusinessLayer();
            clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
            clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
            objEntityLeavSettlmt.CorpId = Convert.ToInt32(corpId);
            objEntityCommon.CorporateID = Convert.ToInt32(corpId);
            objEntityLeavSettlmt.OrgId = Convert.ToInt32(orgID);
            DataTable dtCorp = objBusinessLeavSettlmt.ReadCorporateAddress(objEntityLeavSettlmt);
            string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "", strCompanyLogo = "";
            string strTitle = "";
            strTitle = "EMPLOYEE ADDITION & DEDUCTION REPORT";
            DateTime datetm = DateTime.Now;
            string dat = "<B>Report Date: </B>" + datetm.ToString("R");
            if (dtCorp.Rows.Count > 0)
            {
                strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
                strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
                strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
                strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
                strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
                strCompanyLogo = dtCorp.Rows[0]["CORPRT_ICON"].ToString();
            }
            if (strCompanyLogo != "")
            {
                strCompanyLogo = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit) + strCompanyLogo;
            }
            string strAddress = "";
            strAddress = strCompanyAddr1;
            if (strCompanyAddr2 != "")
            {
                strAddress += ", " + strCompanyAddr2;
            }
            if (strCompanyAddr3 != "")
            {
                strAddress += ", " + strCompanyAddr3;
            }
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.EMP_ADD_DED_REPORT_PDF);
            Document document = new Document(PageSize.LETTER.Rotate(), 30f, 30f, 19f, 50f);
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                string strNextNumber = objBusinessC.ReadNextNumberSequanceForUI(objEntityCommon);
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                strImageName = "EmpAddDedRpt_" + strNextNumber + ".pdf";
                strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.EMP_ADD_DED_REPORT_PDF);
                string fullPath = System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName;
                if ((System.IO.File.Exists(fullPath)))
                {
                    System.IO.File.Delete(fullPath);
                }
                FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                PdfWriter.GetInstance(document, file);
                writer.PageEvent = new PDFHeader();
                document.Open();


                PdfPTable headtable = new PdfPTable(2);
                headtable.AddCell(new PdfPCell(new Phrase("EMPLOYEE ADDITION & DEDUCTION SUMMARY", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                if (strCompanyLogo != "")
                {
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strCompanyLogo));
                    image.ScalePercent(PdfPCell.ALIGN_CENTER);
                    image.ScaleToFit(60f, 40f);
                    headtable.AddCell(new PdfPCell(image) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                }
                else
                {
                    headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                }
                headtable.AddCell(new PdfPCell(new Phrase(strCompanyName, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                headtable.AddCell(new PdfPCell(new Phrase(strAddress, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                float[] headersHeading = { 92, 8 };
                headtable.SetWidths(headersHeading);
                headtable.WidthPercentage = 100;
                document.Add(headtable);


                PdfPTable tableLine = new PdfPTable(1);
                float[] tableLineBody = { 100 };
                tableLine.SetWidths(tableLineBody);
                tableLine.WidthPercentage = 100;
                tableLine.TotalWidth = 950F;
                PdfPCell cell_headLine = (new PdfPCell(new Phrase("__________________________________________________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, });
                cell_headLine.Padding = -5;
                tableLine.AddCell(cell_headLine);
                tableLine.WriteSelectedRows(0, -1, 0, document.PageSize.GetTop(58), writer.DirectContent);

                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Tahoma,Arial", 10, Font.NORMAL, BaseColor.BLACK))));


                if (Method == "1")
                {
                    DataTable dt = objBusiness.ReadSummaryFirst(objEntityBulkPrint);
                    decimal decBA = 0, decBD = 0, decMA = 0, decMD = 0, decTA = 0, decTD = 0;

                    PdfPTable tabHeadMSP = new PdfPTable(7);
                    float[] headersHeadindg = { 10, 15, 15, 15, 15, 15, 15 };
                    tabHeadMSP.SetWidths(headersHeadindg);
                    tabHeadMSP.WidthPercentage = 100;
                    tabHeadMSP.HeaderRows = 1;
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("MONTH", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("ADDITION TOTAL", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("DEDUCTION TOTAL", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("MANUAL ADDITION TOTAL", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("MANUAL DEDUCTION TOTAL", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("TOTAL ADDITION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("TOTAL DEDUCTION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        decBA += Convert.ToDecimal(dt.Rows[i]["BA"].ToString());
                        decBD += Convert.ToDecimal(dt.Rows[i]["BD"].ToString());
                        decMA += Convert.ToDecimal(dt.Rows[i]["MA"].ToString());
                        decMD += Convert.ToDecimal(dt.Rows[i]["MD"].ToString());
                        decTA += Convert.ToDecimal(dt.Rows[i]["TA"].ToString());
                        decTD += Convert.ToDecimal(dt.Rows[i]["TD"].ToString());
                        String mont = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(dt.Rows[i]["SLPRCDMNTH_NUMBR"].ToString()));

                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(mont, FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["BA"].ToString()), roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["BD"].ToString()), roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["MA"].ToString()), roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["MD"].ToString()), roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["TA"].ToString()), roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["TD"].ToString()), roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });

                    }
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decBA, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decBD, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decMA, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decMD, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTA, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTD, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    document.Add(tabHeadMSP);

                }
                else
                {
                    DataTable dt = objBusiness.ReadSummaryFirstMtdTwo(objEntityBulkPrint);
                    DataView dtview = new DataView(dt);
                    dtview.Sort = "SLPRCDMNTH_NUMBR ASC";
                    DataTable dtDistdept = dtview.ToTable(true, "SLPRCDMNTH_NUMBR");
                    DataView dtviewAD = new DataView(dt);
                    DataTable dtDistdeptAD = dtviewAD.ToTable(true, "PAYRL_ID", "PAYRL_NAME", "MODE1");
                    DataRow[] drMode1 = dtDistdeptAD.Select("MODE1=1");
                    DataRow[] drMode2 = dtDistdeptAD.Select("MODE1=2");
                    DataRow[] drMode3 = dtDistdeptAD.Select("MODE1=3");
                    DataRow[] drMode4 = dtDistdeptAD.Select("MODE1=4");
                    int Mode1Cnt = drMode1.Length + 1;
                    int Mode2Cnt = drMode2.Length + 1;
                    int Mode3Cnt = drMode3.Length + 1;
                    int Mode4Cnt = drMode4.Length + 1;
                    int totCol = Mode1Cnt + Mode2Cnt + Mode3Cnt + Mode4Cnt + 3;

                    PdfPTable tabHeadMSP = new PdfPTable(totCol);
                    tabHeadMSP.WidthPercentage = 100;
                    tabHeadMSP.HeaderRows = 2;
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("MONTH", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Rowspan=2,HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("ADDITION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Colspan = Mode1Cnt, HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("DEDUCTION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Colspan = Mode2Cnt, HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("MANUAL ADDITION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Colspan = Mode3Cnt, HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("MANUAL DEDUCTION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Colspan = Mode4Cnt, HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("TOTAL ADDITION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Rowspan = 2, HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("TOTAL DEDUCTION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Rowspan = 2, HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    foreach (DataRow dr1 in drMode1)
                    {
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(dr1["PAYRL_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    }
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    foreach (DataRow dr1 in drMode2)
                    {
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(dr1["PAYRL_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    }
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    foreach (DataRow dr1 in drMode3)
                    {
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(dr1["PAYRL_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    }
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    foreach (DataRow dr1 in drMode4)
                    {
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(dr1["PAYRL_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    }
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });


                    for (int i = 0; i < dtDistdept.Rows.Count; i++)
                    {
                        string mont = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(dtDistdept.Rows[i][0].ToString()));
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(mont, FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                      
                        decimal decTotBa = 0;
                        foreach (DataRow dr1 in drMode1)
                        {
                            decimal curr = 0;
                            string StrCurr = dt.Compute("Sum(AMT)", "MODE1=1 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + " AND SLPRCDMNTH_NUMBR=" + dtDistdept.Rows[i][0].ToString() + "").ToString();
                            if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                                curr = Convert.ToDecimal(StrCurr);                      
                            tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon) , FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                            decTotBa += curr;
                        }
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotBa, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });

                        decimal decTotBd = 0;
                        foreach (DataRow dr1 in drMode2)
                        {
                            decimal curr = 0;
                            string StrCurr = dt.Compute("Sum(AMT)", "MODE1=2 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + " AND SLPRCDMNTH_NUMBR=" + dtDistdept.Rows[i][0].ToString() + "").ToString();
                            if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                                curr = Convert.ToDecimal(StrCurr);
                            tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                            decTotBd += curr;
                        }
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotBd, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });

                        decimal decTotMa = 0;
                        foreach (DataRow dr1 in drMode3)
                        {
                            decimal curr = 0;
                            string StrCurr = dt.Compute("Sum(AMT)", "MODE1=3 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + " AND SLPRCDMNTH_NUMBR=" + dtDistdept.Rows[i][0].ToString() + "").ToString();
                            if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                                curr = Convert.ToDecimal(StrCurr);
                            tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                            decTotMa += curr;
                        }
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotMa, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });

                        decimal decTotMd = 0;
                        foreach (DataRow dr1 in drMode4)
                        {
                            decimal curr = 0;
                            string StrCurr = dt.Compute("Sum(AMT)", "MODE1=4 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + " AND SLPRCDMNTH_NUMBR=" + dtDistdept.Rows[i][0].ToString() + "").ToString();
                            if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                                curr = Convert.ToDecimal(StrCurr);
                            tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                            decTotMd += curr;
                        }
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotMd, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotBa + decTotMa, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotBd + decTotMd, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    }


                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                    decimal decNetBa = 0;
                    foreach (DataRow dr1 in drMode1)
                    {
                        decimal curr = 0;
                        string StrCurr = dt.Compute("Sum(AMT)", "MODE1=1 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                        if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                            curr = Convert.ToDecimal(StrCurr);
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        decNetBa += curr;
                    }
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decNetBa, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });

                    decimal decNetBd = 0;
                    foreach (DataRow dr1 in drMode2)
                    {
                        decimal curr = 0;
                        string StrCurr = dt.Compute("Sum(AMT)", "MODE1=2 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                        if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                            curr = Convert.ToDecimal(StrCurr);
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        decNetBd += curr;
                    }
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decNetBd, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });

                    decimal decNetMa = 0;
                    foreach (DataRow dr1 in drMode3)
                    {
                        decimal curr = 0;
                        string StrCurr = dt.Compute("Sum(AMT)", "MODE1=3 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                        if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                            curr = Convert.ToDecimal(StrCurr);
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        decNetMa += curr;
                    }
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decNetMa, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });


                    decimal decNetMd = 0;
                    foreach (DataRow dr1 in drMode4)
                    {
                        decimal curr = 0;
                        string StrCurr = dt.Compute("Sum(AMT)", "MODE1=4 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                        if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                            curr = Convert.ToDecimal(StrCurr);
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        decNetMd += curr;
                    }
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decNetMd, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });

                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decNetBa + decNetMa, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decNetBd + decNetMd, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    document.Add(tabHeadMSP);
                }
                float pos1 = writer.GetVerticalPosition(false);
                PdfPTable endtable = new PdfPTable(6);
                float[] endBody = { 25, 10, 25, 10, 25, 5 };
                endtable.SetWidths(endBody);
                endtable.WidthPercentage = 100;
                endtable.TotalWidth = document.PageSize.Width - 80f;

                endtable.AddCell(new PdfPCell(new Phrase("FINANCE MANAGER", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                endtable.AddCell(new PdfPCell(new Phrase("GENERAL MANAGER", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                endtable.AddCell(new PdfPCell(new Phrase("RECEIVER’S SIGNATURE", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });

                endtable.TotalWidth = 555F;
                if (pos1 > 90)
                {
                    endtable.WriteSelectedRows(0, -1, 123, 65, writer.DirectContent);
                }
                else
                {
                    document.NewPage();
                    endtable.WriteSelectedRows(0, -1, 123, 65, writer.DirectContent);
                }
                document.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
            }
        }
        catch (Exception ex)
        {
            strImageName = "";
            strImagePath = "";
        }
        return strImagePath + strImageName;
    }
    [System.Web.Services.WebMethod]
    public static string PrintSummaryM1Lev2(string orgID, string corpId, string year, string month, string dept, string divsn, string job, string desg, string emp, string Addtn, string Dedtn, string catgry, string method, string ShowDep, string ShowDiv, string ShowJob, string ShowCat, string ShowMon, string Dcm, string Crn, string mode)
    {
        string strImageName = "", strImagePath = "";
        try
        {
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(Crn);
            int roundNum = Convert.ToInt32(Dcm);

            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayer objBusinessC = new clsBusinessLayer();
            clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
            clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
            objEntityLeavSettlmt.CorpId = Convert.ToInt32(corpId);
            objEntityCommon.CorporateID = Convert.ToInt32(corpId);
            objEntityLeavSettlmt.OrgId = Convert.ToInt32(orgID);
            DataTable dtCorp = objBusinessLeavSettlmt.ReadCorporateAddress(objEntityLeavSettlmt);
            string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "", strCompanyLogo = "";
            string strTitle = "";
            strTitle = "EMPLOYEE ADDITION & DEDUCTION REPORT";
            DateTime datetm = DateTime.Now;
            string dat = "<B>Report Date: </B>" + datetm.ToString("R");
            if (dtCorp.Rows.Count > 0)
            {
                strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
                strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
                strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
                strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
                strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
                strCompanyLogo = dtCorp.Rows[0]["CORPRT_ICON"].ToString();
            }
            if (strCompanyLogo != "")
            {
                strCompanyLogo = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit) + strCompanyLogo;
            }
            string strAddress = "";
            strAddress = strCompanyAddr1;
            if (strCompanyAddr2 != "")
            {
                strAddress += ", " + strCompanyAddr2;
            }
            if (strCompanyAddr3 != "")
            {
                strAddress += ", " + strCompanyAddr3;
            }
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.EMP_ADD_DED_REPORT_PDF);
            Document document = new Document(PageSize.LETTER.Rotate(), 30f, 30f, 19f, 50f);
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                string strNextNumber = objBusinessC.ReadNextNumberSequanceForUI(objEntityCommon);
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                strImageName = "EmpAddDedRpt_" + strNextNumber + ".pdf";
                strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.EMP_ADD_DED_REPORT_PDF);
                string fullPath = System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName;
                if ((System.IO.File.Exists(fullPath)))
                {
                    System.IO.File.Delete(fullPath);
                }
                FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                PdfWriter.GetInstance(document, file);
                writer.PageEvent = new PDFHeader();
                document.Open();


                PdfPTable headtable = new PdfPTable(2);
                headtable.AddCell(new PdfPCell(new Phrase("EMPLOYEE ADDITION & DEDUCTION SUMMARY", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                if (strCompanyLogo != "")
                {
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strCompanyLogo));
                    image.ScalePercent(PdfPCell.ALIGN_CENTER);
                    image.ScaleToFit(60f, 40f);
                    headtable.AddCell(new PdfPCell(image) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                }
                else
                {
                    headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                }
                headtable.AddCell(new PdfPCell(new Phrase(strCompanyName, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                headtable.AddCell(new PdfPCell(new Phrase(strAddress, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                float[] headersHeading = { 92, 8 };
                headtable.SetWidths(headersHeading);
                headtable.WidthPercentage = 100;
                document.Add(headtable);


                PdfPTable tableLine = new PdfPTable(1);
                float[] tableLineBody = { 100 };
                tableLine.SetWidths(tableLineBody);
                tableLine.WidthPercentage = 100;
                tableLine.TotalWidth = 950F;
                PdfPCell cell_headLine = (new PdfPCell(new Phrase("__________________________________________________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, });
                cell_headLine.Padding = -5;
                tableLine.AddCell(cell_headLine);
                tableLine.WriteSelectedRows(0, -1, 0, document.PageSize.GetTop(58), writer.DirectContent);
                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Tahoma,Arial", 10, Font.NORMAL, BaseColor.BLACK))));


                int TotCol = 0;
                int ColSp = 0;
                clsEntityEmployeeAddDedReport objEntityBulkPrint = new clsEntityEmployeeAddDedReport();
                clsBusinessEmployeeAddDedReport objBusiness = new clsBusinessEmployeeAddDedReport();
                objEntityBulkPrint.CorpId = Convert.ToInt32(corpId);
                objEntityBulkPrint.OrgId = Convert.ToInt32(orgID);
                objEntityBulkPrint.Year = Convert.ToInt32(year);
                objEntityBulkPrint.Months = month;
                objEntityBulkPrint.DepartmentIds = dept;
                objEntityBulkPrint.DivisionIds = divsn;
                objEntityBulkPrint.DesignationIds = desg;
                objEntityBulkPrint.EmployeeIds = emp;
                objEntityBulkPrint.AdditionIds = Addtn;
                objEntityBulkPrint.DeductionIds = Dedtn;
                objEntityBulkPrint.CategoryId = Convert.ToInt32(catgry);
                string queryCol = "";
                if (ShowDep == "1")
                {
                    queryCol = "CPRDEPT_ID,CPRDEPT_NAME";
                    TotCol++;
                    ColSp++;
                }
                if (ShowDiv == "1")
                {
                    if (queryCol == "")
                    {
                        queryCol = "CPRDIV_ID,CPRDIV_NAME";
                    }
                    else
                    {
                        queryCol += ",CPRDIV_ID,CPRDIV_NAME";
                    }
                    TotCol++;
                    ColSp++;
                }
                if (ShowCat == "1")
                {
                    if (queryCol == "")
                    {
                        queryCol = "STAFF_WORKER,STAFF_WORKER_NAME";
                    }
                    else
                    {
                        queryCol += ",STAFF_WORKER,STAFF_WORKER_NAME";
                    }
                    TotCol++;
                    ColSp++;
                }
                if (ShowMon == "1")
                {
                    if (queryCol == "")
                    {
                        queryCol = "SLPRCDMNTH_NUMBR";
                    }
                    else
                    {
                        queryCol += ",SLPRCDMNTH_NUMBR";
                    }
                    TotCol++;
                    ColSp++;
                }
                if (ShowJob == "1")
                {
                    TotCol++;
                    ColSp++;
                }
                if (mode == "1")
                {
                    TotCol++;
                }
                else if (mode == "2")
                {
                    TotCol++;
                }
                else if (mode == "3")
                {
                    TotCol++;
                }
                else if (mode == "4")
                {
                    TotCol++;
                }
                else if (mode == "5")
                {
                    TotCol += 3;
                }
                else if (mode == "6")
                {
                    TotCol += 3;
                }
                else
                {
                    TotCol += 6;
                }


                objEntityBulkPrint.QueryColumns = queryCol;
                DataTable dt = objBusiness.ReadSummarySecond(objEntityBulkPrint);
                decimal decBA = 0, decBD = 0, decMA = 0, decMD = 0, decTA = 0, decTD = 0;

                PdfPTable tabHeadMSP = new PdfPTable(TotCol);
                tabHeadMSP.WidthPercentage = 100;
                tabHeadMSP.HeaderRows = 1;
                if (ShowDep == "1")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("DEPARTMENT", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                if (ShowDiv == "1")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("DIVISION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                if (ShowCat == "1")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("CATEGORY", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                if (ShowJob == "1")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("JOB", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                if (ShowMon == "1")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("MONTH", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });


                if (mode == "1")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("ADDITION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                else if (mode == "2")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("DEDUCTION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                else if (mode == "3")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("MANUAL ADDITION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                else if (mode == "4")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("MANUAL DEDUCTION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                else if (mode == "5")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("ADDITION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("MANUAL ADDITION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("TOTAL ADDITION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                else if (mode == "6")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("DEDUCTION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("MANUAL DEDUCTION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("TOTAL DEDUCTION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                else
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("ADDITION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("DEDUCTION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("MANUAL ADDITION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("MANUAL DEDUCTION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("TOTAL ADDITION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("TOTAL DEDUCTION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    decBA += Convert.ToDecimal(dt.Rows[i]["BA"].ToString());
                    decBD += Convert.ToDecimal(dt.Rows[i]["BD"].ToString());
                    decMA += Convert.ToDecimal(dt.Rows[i]["MA"].ToString());
                    decMD += Convert.ToDecimal(dt.Rows[i]["MD"].ToString());
                    decTA += Convert.ToDecimal(dt.Rows[i]["TA"].ToString());
                    decTD += Convert.ToDecimal(dt.Rows[i]["TD"].ToString());

                    if (ShowDep == "1")
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(dt.Rows[i]["CPRDEPT_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    if (ShowDiv == "1")
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(dt.Rows[i]["CPRDIV_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    if (ShowCat == "1")
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(dt.Rows[i]["STAFF_WORKER_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    if (ShowJob == "1")
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    if (ShowMon == "1")
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(dt.Rows[i]["SLPRCDMNTH_NUMBR"].ToString())), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });

                    if (mode == "1")
                    {
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["BA"].ToString()), roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    }
                    else if (mode == "2")
                    {
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["BD"].ToString()), roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    }
                    else if (mode == "3")
                    {
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["MA"].ToString()), roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    }
                    else if (mode == "4")
                    {
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["MD"].ToString()), roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    }
                    else if (mode == "5")
                    {
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["BA"].ToString()), roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["MA"].ToString()), roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["TA"].ToString()), roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    }
                    else if (mode == "6")
                    {
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["BD"].ToString()), roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["MD"].ToString()), roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["TD"].ToString()), roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    }
                    else
                    {
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["BA"].ToString()), roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["BD"].ToString()), roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["MA"].ToString()), roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["MD"].ToString()), roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["TA"].ToString()), roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[i]["TD"].ToString()), roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    }


                }

                tabHeadMSP.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Colspan = ColSp, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });

                if (mode == "1")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decBA, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                else if (mode == "2")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decBD, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                else if (mode == "3")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decMA, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                else if (mode == "4")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decMD, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                else if (mode == "5")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decBA, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decMA, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTA, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                else if (mode == "6")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decBD, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decMD, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTD, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                else
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decBA, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decBD, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decMA, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decMD, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTA, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTD, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                document.Add(tabHeadMSP);


                float pos1 = writer.GetVerticalPosition(false);
                PdfPTable endtable = new PdfPTable(6);
                float[] endBody = { 25, 10, 25, 10, 25, 5 };
                endtable.SetWidths(endBody);
                endtable.WidthPercentage = 100;
                endtable.TotalWidth = document.PageSize.Width - 80f;

                endtable.AddCell(new PdfPCell(new Phrase("FINANCE MANAGER", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                endtable.AddCell(new PdfPCell(new Phrase("GENERAL MANAGER", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                endtable.AddCell(new PdfPCell(new Phrase("RECEIVER’S SIGNATURE", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });

                endtable.TotalWidth = 555F;
                if (pos1 > 90)
                {
                    endtable.WriteSelectedRows(0, -1, 123, 65, writer.DirectContent);
                }
                else
                {
                    document.NewPage();
                    endtable.WriteSelectedRows(0, -1, 123, 65, writer.DirectContent);
                }
                document.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
            }
        }
        catch (Exception ex)
        {
            strImageName = "";
            strImagePath = "";
        }
        return strImagePath + strImageName;
    }

    [System.Web.Services.WebMethod]
    public static string PrintSummaryM2Lev2(string orgID, string corpId, string year, string month, string dept, string divsn, string job, string desg, string emp, string Addtn, string Dedtn, string catgry, string method, string source,
        string ShowDep, string ShowDiv, string ShowCat, string ShowJob, string BAids, string BDids, string MAids, string MDids, string Mode, string Dcm, string Crn)
    {
        string strImageName = "", strImagePath = "";
        try
        {
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(Crn);
            int roundNum = Convert.ToInt32(Dcm);

            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayer objBusinessC = new clsBusinessLayer();
            clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
            clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
            objEntityLeavSettlmt.CorpId = Convert.ToInt32(corpId);
            objEntityCommon.CorporateID = Convert.ToInt32(corpId);
            objEntityLeavSettlmt.OrgId = Convert.ToInt32(orgID);
            DataTable dtCorp = objBusinessLeavSettlmt.ReadCorporateAddress(objEntityLeavSettlmt);
            string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "", strCompanyLogo = "";
            string strTitle = "";
            strTitle = "EMPLOYEE ADDITION & DEDUCTION REPORT";
            DateTime datetm = DateTime.Now;
            string dat = "<B>Report Date: </B>" + datetm.ToString("R");
            if (dtCorp.Rows.Count > 0)
            {
                strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
                strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
                strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
                strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
                strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
                strCompanyLogo = dtCorp.Rows[0]["CORPRT_ICON"].ToString();
            }
            if (strCompanyLogo != "")
            {
                strCompanyLogo = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit) + strCompanyLogo;
            }
            string strAddress = "";
            strAddress = strCompanyAddr1;
            if (strCompanyAddr2 != "")
            {
                strAddress += ", " + strCompanyAddr2;
            }
            if (strCompanyAddr3 != "")
            {
                strAddress += ", " + strCompanyAddr3;
            }
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.EMP_ADD_DED_REPORT_PDF);
            Document document = new Document(PageSize.LETTER.Rotate(), 30f, 30f, 19f, 50f);
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                string strNextNumber = objBusinessC.ReadNextNumberSequanceForUI(objEntityCommon);
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                strImageName = "EmpAddDedRpt_" + strNextNumber + ".pdf";
                strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.EMP_ADD_DED_REPORT_PDF);
                string fullPath = System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName;
                if ((System.IO.File.Exists(fullPath)))
                {
                    System.IO.File.Delete(fullPath);
                }
                FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                PdfWriter.GetInstance(document, file);
                writer.PageEvent = new PDFHeader();
                document.Open();


                PdfPTable headtable = new PdfPTable(2);
                headtable.AddCell(new PdfPCell(new Phrase("EMPLOYEE ADDITION & DEDUCTION SUMMARY", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                if (strCompanyLogo != "")
                {
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strCompanyLogo));
                    image.ScalePercent(PdfPCell.ALIGN_CENTER);
                    image.ScaleToFit(60f, 40f);
                    headtable.AddCell(new PdfPCell(image) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                }
                else
                {
                    headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                }
                headtable.AddCell(new PdfPCell(new Phrase(strCompanyName, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                headtable.AddCell(new PdfPCell(new Phrase(strAddress, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                float[] headersHeading = { 92, 8 };
                headtable.SetWidths(headersHeading);
                headtable.WidthPercentage = 100;
                document.Add(headtable);


                PdfPTable tableLine = new PdfPTable(1);
                float[] tableLineBody = { 100 };
                tableLine.SetWidths(tableLineBody);
                tableLine.WidthPercentage = 100;
                tableLine.TotalWidth = 950F;
                PdfPCell cell_headLine = (new PdfPCell(new Phrase("__________________________________________________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, });
                cell_headLine.Padding = -5;
                tableLine.AddCell(cell_headLine);
                tableLine.WriteSelectedRows(0, -1, 0, document.PageSize.GetTop(58), writer.DirectContent);
                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Tahoma,Arial", 10, Font.NORMAL, BaseColor.BLACK))));

                int TotCol= 0;
                int ColSpanB = 1;
                clsEntityEmployeeAddDedReport objEntityBulkPrint = new clsEntityEmployeeAddDedReport();
                clsBusinessEmployeeAddDedReport objBusiness = new clsBusinessEmployeeAddDedReport();
                objEntityBulkPrint.CorpId = Convert.ToInt32(corpId);
                objEntityBulkPrint.OrgId = Convert.ToInt32(orgID);
                objEntityBulkPrint.Year = Convert.ToInt32(year);
                objEntityBulkPrint.Months = month;
                objEntityBulkPrint.DepartmentIds = dept;
                objEntityBulkPrint.DivisionIds = divsn;
                objEntityBulkPrint.DesignationIds = desg;
                objEntityBulkPrint.EmployeeIds = emp;
                objEntityBulkPrint.AdditionIds = Addtn;
                objEntityBulkPrint.DeductionIds = Dedtn;
                objEntityBulkPrint.CategoryId = Convert.ToInt32(catgry);
                string queryCol = "SLPRCDMNTH_NUMBR";
                if (ShowDep == "1")
                {
                    queryCol += ",CPRDEPT_ID,CPRDEPT_NAME";
                    ColSpanB++;
                }
                if (ShowDiv == "1")
                {
                    queryCol += ",CPRDIV_ID,CPRDIV_NAME";
                    ColSpanB++;
                }
                if (ShowCat == "1")
                {
                    queryCol += ",STAFF_WORKER,STAFF_WORKER_NAME";
                    ColSpanB++;
                }
                if (ShowJob == "1")
                {
                    ColSpanB++;
                }
                objEntityBulkPrint.QueryColumns = queryCol;
                objEntityBulkPrint.BAids = BAids;
                objEntityBulkPrint.BDids = BDids;
                objEntityBulkPrint.MAids = MAids;
                objEntityBulkPrint.MDids = MDids;
                DataTable dt = objBusiness.ReadSummaryThird(objEntityBulkPrint);
                DataTable dtGrp = objBusiness.ReadSummaryThirdGrp(objEntityBulkPrint);
                DataView dtviewAD = new DataView(dt);
                DataTable dtDistdeptAD = dtviewAD.ToTable(true, "PAYRL_ID", "PAYRL_NAME", "MODE1");

                DataRow[] drMode1 = dtDistdeptAD.Select("MODE1=1");
                DataRow[] drMode2 = dtDistdeptAD.Select("MODE1=2");
                DataRow[] drMode3 = dtDistdeptAD.Select("MODE1=3");
                DataRow[] drMode4 = dtDistdeptAD.Select("MODE1=4");
                int Mode1Cnt = drMode1.Length + 1;
                int Mode2Cnt = drMode2.Length + 1;
                int Mode3Cnt = drMode3.Length + 1;
                int Mode4Cnt = drMode4.Length + 1;
                TotCol += ColSpanB;
                if (objEntityBulkPrint.BAids != "0")
                {
                    TotCol += Mode1Cnt;
                }
                if (objEntityBulkPrint.BDids != "0")
                {
                    TotCol += Mode2Cnt;
                }
                if (objEntityBulkPrint.MAids != "0")
                {
                    TotCol += Mode3Cnt;
                }
                if (objEntityBulkPrint.MDids != "0")
                {
                    TotCol += Mode4Cnt;
                }
                if (Mode == "1" || Mode == "3" || Mode == "5" || Mode == "")
                    TotCol++;
                if (Mode == "2" || Mode == "4" || Mode == "6" || Mode == "")
                    TotCol++;
                PdfPTable tabHeadMSP = new PdfPTable(TotCol);
                tabHeadMSP.WidthPercentage = 100;
                tabHeadMSP.HeaderRows = 2;
                if (ShowDep == "1")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("DEPARTMENT", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Rowspan=2,HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                if (ShowDiv == "1")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("DIVISION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Rowspan = 2, HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                if (ShowCat == "1")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("CATEGORY", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Rowspan = 2, HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                if (ShowJob == "1")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("JOB", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Rowspan = 2, HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                tabHeadMSP.AddCell(new PdfPCell(new Phrase("MONTH", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Rowspan = 2, HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });

                if (objEntityBulkPrint.BAids != "0")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("ADDITION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Colspan = Mode1Cnt, HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                if (objEntityBulkPrint.BDids != "0")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("DEDUCTION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Colspan = Mode2Cnt, HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                if (objEntityBulkPrint.MAids != "0")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("MANUAL ADDITION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Colspan = Mode3Cnt, HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                if (objEntityBulkPrint.MDids != "0")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("MANUAL DEDUCTION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Colspan = Mode4Cnt, HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                if (Mode == "1" || Mode == "3" || Mode == "5" || Mode == "")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("TOTAL ADDITION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Rowspan=2,HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                if (Mode == "2" || Mode == "4" || Mode == "6" || Mode == ""){
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("TOTAL DEDUCTION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Rowspan = 2, HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                foreach (DataRow dr1 in drMode1)
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(dr1["PAYRL_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                if (objEntityBulkPrint.BAids != "0")
                tabHeadMSP.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                foreach (DataRow dr1 in drMode2)
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(dr1["PAYRL_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                if (objEntityBulkPrint.BDids != "0")
                tabHeadMSP.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                foreach (DataRow dr1 in drMode3)
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(dr1["PAYRL_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                if (objEntityBulkPrint.MAids != "0")
                tabHeadMSP.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                foreach (DataRow dr1 in drMode4)
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(dr1["PAYRL_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                if (objEntityBulkPrint.MDids != "0")
                tabHeadMSP.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });

                string SumQry1 = "";
                decimal GrandBa = 0, GrandBd = 0, GrandMa = 0, GrandMd = 0;

                for (int i = 0; i < dtGrp.Rows.Count; i++)
                {

                    SumQry1 = "SLPRCDMNTH_NUMBR=" + dtGrp.Rows[i]["SLPRCDMNTH_NUMBR"].ToString();

                    if (ShowDep == "1")
                    {
                        SumQry1 += " AND  CPRDEPT_ID=" + dtGrp.Rows[i]["CPRDEPT_ID"].ToString();
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(dtGrp.Rows[i]["CPRDEPT_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    }
                    if (ShowDiv == "1")
                    {
                        SumQry1 += " AND  CPRDIV_ID=" + dtGrp.Rows[i]["CPRDIV_ID"].ToString();
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(dtGrp.Rows[i]["CPRDIV_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    }
                    if (ShowCat == "1")
                    {
                        SumQry1 += " AND  STAFF_WORKER=" + dtGrp.Rows[i]["STAFF_WORKER"].ToString();
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(dtGrp.Rows[i]["STAFF_WORKER_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    }
                    if (ShowJob == "1")
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(dtGrp.Rows[i]["SLPRCDMNTH_NUMBR"].ToString())), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });

                    decimal decTotBa = 0;
                    foreach (DataRow dr1 in drMode1)
                    {
                        decimal curr = 0;
                        string StrCurr = dt.Compute("Sum(AMT)", "" + SumQry1 + " AND MODE1=1 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                        if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                            curr = Convert.ToDecimal(StrCurr);
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        decTotBa += curr;
                    }
                    if (objEntityBulkPrint.BAids != "0")
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotBa, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });

                    decimal decTotBd = 0;
                    foreach (DataRow dr1 in drMode2)
                    {
                        decimal curr = 0;
                        string StrCurr = dt.Compute("Sum(AMT)", "" + SumQry1 + " AND MODE1=2 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                        if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                            curr = Convert.ToDecimal(StrCurr);
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        decTotBd += curr;
                    }
                    if (objEntityBulkPrint.BDids != "0")
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotBd, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });


                    decimal decTotMa = 0;
                    foreach (DataRow dr1 in drMode3)
                    {
                        decimal curr = 0;
                        string StrCurr = dt.Compute("Sum(AMT)", "" + SumQry1 + " AND MODE1=3 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                        if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                            curr = Convert.ToDecimal(StrCurr);
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        decTotMa += curr;
                    }
                    if (objEntityBulkPrint.MAids != "0")
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotMa, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });

                    decimal decTotMd = 0;
                    foreach (DataRow dr1 in drMode4)
                    {
                        decimal curr = 0;
                        string StrCurr = dt.Compute("Sum(AMT)", "" + SumQry1 + " AND MODE1=4 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                        if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                            curr = Convert.ToDecimal(StrCurr);
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        decTotMd += curr;
                    }
                    if (objEntityBulkPrint.MDids != "0")
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotMd, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    if (Mode == "1" || Mode == "3" || Mode == "5" || Mode == "")
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotBa + decTotMa, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    if (Mode == "2" || Mode == "4" || Mode == "6" || Mode == "")
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotBd + decTotMd, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                }

                tabHeadMSP.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Colspan = ColSpanB, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });

                foreach (DataRow dr1 in drMode1)
                {
                    decimal curr = 0;
                    string StrCurr = dt.Compute("Sum(AMT)", "MODE1=1 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                    if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                        curr = Convert.ToDecimal(StrCurr);
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    GrandBa += curr;
                }
                if (objEntityBulkPrint.BAids != "0")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrandBa, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });


                foreach (DataRow dr1 in drMode2)
                {
                    decimal curr = 0;
                    string StrCurr = dt.Compute("Sum(AMT)", "MODE1=2 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                    if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                        curr = Convert.ToDecimal(StrCurr);
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    GrandBd += curr;
                }
                if (objEntityBulkPrint.BDids != "0")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrandBd, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });

                foreach (DataRow dr1 in drMode3)
                {
                    decimal curr = 0;
                    string StrCurr = dt.Compute("Sum(AMT)", "MODE1=3 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                    if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                        curr = Convert.ToDecimal(StrCurr);
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    GrandMa += curr;
                }
                if (objEntityBulkPrint.MAids != "0")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrandMa, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                foreach (DataRow dr1 in drMode4)
                {
                    decimal curr = 0;
                    string StrCurr = dt.Compute("Sum(AMT)", "MODE1=4 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                    if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                        curr = Convert.ToDecimal(StrCurr);
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    GrandMd += curr;
                }
                if (objEntityBulkPrint.MDids != "0")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrandMd, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                if (Mode == "1" || Mode == "3" || Mode == "5" || Mode == "")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrandBa + GrandMa, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                if (Mode == "2" || Mode == "4" || Mode == "6" || Mode == "")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrandBd + GrandMd, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                document.Add(tabHeadMSP);




                float pos1 = writer.GetVerticalPosition(false);
                PdfPTable endtable = new PdfPTable(6);
                float[] endBody = { 25, 10, 25, 10, 25, 5 };
                endtable.SetWidths(endBody);
                endtable.WidthPercentage = 100;
                endtable.TotalWidth = document.PageSize.Width - 80f;

                endtable.AddCell(new PdfPCell(new Phrase("FINANCE MANAGER", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                endtable.AddCell(new PdfPCell(new Phrase("GENERAL MANAGER", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                endtable.AddCell(new PdfPCell(new Phrase("RECEIVER’S SIGNATURE", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });

                endtable.TotalWidth = 555F;
                if (pos1 > 90)
                {
                    endtable.WriteSelectedRows(0, -1, 123, 65, writer.DirectContent);
                }
                else
                {
                    document.NewPage();
                    endtable.WriteSelectedRows(0, -1, 123, 65, writer.DirectContent);
                }
                document.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
            }
        }
        catch (Exception ex)
        {
            strImageName = "";
            strImagePath = "";
        }
        return strImagePath + strImageName;
    }

    [System.Web.Services.WebMethod]
    public static string PrinLev3(string orgID, string corpId, string year, string month, string dept, string divsn, string job, string desg, string emp, string Addtn, string Dedtn, string catgry, string method, string Level, string source,
        string ShowEmpCode, string ShowEmpName, string ShowDept, string ShowDesg, string ShowJob, string BAids, string BDids, string MAids, string MDids, string Dcm, string Crn)
    {
        string strImageName = "", strImagePath = "";
        try
        {
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(Crn);
            int roundNum = Convert.ToInt32(Dcm);

            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayer objBusinessC = new clsBusinessLayer();
            clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
            clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
            objEntityLeavSettlmt.CorpId = Convert.ToInt32(corpId);
            objEntityCommon.CorporateID = Convert.ToInt32(corpId);
            objEntityLeavSettlmt.OrgId = Convert.ToInt32(orgID);
            DataTable dtCorp = objBusinessLeavSettlmt.ReadCorporateAddress(objEntityLeavSettlmt);
            string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "", strCompanyLogo = "";
            string strTitle = "";
            strTitle = "EMPLOYEE ADDITION & DEDUCTION REPORT";
            DateTime datetm = DateTime.Now;
            string dat = "<B>Report Date: </B>" + datetm.ToString("R");
            if (dtCorp.Rows.Count > 0)
            {
                strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
                strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
                strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
                strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
                strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
                strCompanyLogo = dtCorp.Rows[0]["CORPRT_ICON"].ToString();
            }
            if (strCompanyLogo != "")
            {
                strCompanyLogo = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit) + strCompanyLogo;
            }
            string strAddress = "";
            strAddress = strCompanyAddr1;
            if (strCompanyAddr2 != "")
            {
                strAddress += ", " + strCompanyAddr2;
            }
            if (strCompanyAddr3 != "")
            {
                strAddress += ", " + strCompanyAddr3;
            }
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.EMP_ADD_DED_REPORT_PDF);
            Document document = new Document(PageSize.LETTER.Rotate(), 30f, 30f, 19f, 50f);
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                string strNextNumber = objBusinessC.ReadNextNumberSequanceForUI(objEntityCommon);
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                strImageName = "EmpAddDedRpt_" + strNextNumber + ".pdf";
                strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.EMP_ADD_DED_REPORT_PDF);
                string fullPath = System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName;
                if ((System.IO.File.Exists(fullPath)))
                {
                    System.IO.File.Delete(fullPath);
                }
                FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                PdfWriter.GetInstance(document, file);
                writer.PageEvent = new PDFHeader();
                document.Open();


                PdfPTable headtable = new PdfPTable(2);
                headtable.AddCell(new PdfPCell(new Phrase("EMPLOYEE ADDITION & DEDUCTION DETAIL", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                if (strCompanyLogo != "")
                {
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strCompanyLogo));
                    image.ScalePercent(PdfPCell.ALIGN_CENTER);
                    image.ScaleToFit(60f, 40f);
                    headtable.AddCell(new PdfPCell(image) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                }
                else
                {
                    headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                }
                headtable.AddCell(new PdfPCell(new Phrase(strCompanyName, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                headtable.AddCell(new PdfPCell(new Phrase(strAddress, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                float[] headersHeading = { 92, 8 };
                headtable.SetWidths(headersHeading);
                headtable.WidthPercentage = 100;
                document.Add(headtable);


                PdfPTable tableLine = new PdfPTable(1);
                float[] tableLineBody = { 100 };
                tableLine.SetWidths(tableLineBody);
                tableLine.WidthPercentage = 100;
                tableLine.TotalWidth = 950F;
                PdfPCell cell_headLine = (new PdfPCell(new Phrase("__________________________________________________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, });
                cell_headLine.Padding = -5;
                tableLine.AddCell(cell_headLine);
                tableLine.WriteSelectedRows(0, -1, 0, document.PageSize.GetTop(58), writer.DirectContent);
                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Tahoma,Arial", 10, Font.NORMAL, BaseColor.BLACK))));





                int TotCol = 2;
                clsEntityEmployeeAddDedReport objEntityBulkPrint = new clsEntityEmployeeAddDedReport();
                clsBusinessEmployeeAddDedReport objBusiness = new clsBusinessEmployeeAddDedReport();
                objEntityBulkPrint.CorpId = Convert.ToInt32(corpId);
                objEntityBulkPrint.OrgId = Convert.ToInt32(orgID);
                objEntityBulkPrint.Year = Convert.ToInt32(year);
                objEntityBulkPrint.Months = month;
                objEntityBulkPrint.DepartmentIds = dept;
                objEntityBulkPrint.DivisionIds = divsn;
                objEntityBulkPrint.DesignationIds = desg;
                objEntityBulkPrint.EmployeeIds = emp;
                objEntityBulkPrint.AdditionIds = Addtn;
                objEntityBulkPrint.DeductionIds = Dedtn;
                objEntityBulkPrint.CategoryId = Convert.ToInt32(catgry);
                string queryCol = "";
                if (ShowDept == "1" || Level == "0")
                {
                    queryCol = "CPRDEPT_ID,CPRDEPT_NAME";
                }
                if (Level == "1")
                {
                    if (queryCol == "")
                    {
                        queryCol = "CPRDIV_ID,CPRDIV_NAME";
                    }
                    else
                    {
                        queryCol += ",CPRDIV_ID,CPRDIV_NAME";
                    }
                }
                if (Level == "2")
                {
                    if (queryCol == "")
                    {
                        queryCol = "STAFF_WORKER,STAFF_WORKER_NAME";
                    }
                    else
                    {
                        queryCol += ",STAFF_WORKER,STAFF_WORKER_NAME";
                    }
                }
                if (Level == "4")
                {
                    if (queryCol == "")
                    {
                        queryCol = "SLPRCDMNTH_NUMBR";
                    }
                    else
                    {
                        queryCol += ",SLPRCDMNTH_NUMBR";
                    }
                }
                if (ShowEmpCode == "1" || ShowEmpName == "1")
                {
                    if (queryCol == "")
                    {
                        queryCol = "USR_CODE,USR_NAME";
                    }
                    else
                    {
                        queryCol += ",USR_CODE,USR_NAME";
                    }
                }
                if (ShowDesg == "1")
                {
                    if (queryCol == "")
                    {
                        queryCol = "DSGN_ID,DSGN_NAME";
                    }
                    else
                    {
                        queryCol += ",DSGN_ID,DSGN_NAME";
                    }
                }
                objEntityBulkPrint.QueryColumns = queryCol;
                if (source == "0")
                {
                    objEntityBulkPrint.BAids = "ALL";
                    objEntityBulkPrint.BDids = "ALL";
                    objEntityBulkPrint.MAids = "ALL";
                    objEntityBulkPrint.MDids = "ALL";
                }
                else
                {
                    if (BAids == "")
                    {
                        BAids = "0";
                    }
                    if (BDids == "")
                    {
                        BDids = "0";
                    }
                    if (MAids == "")
                    {
                        MAids = "0";
                    }
                    if (MDids == "")
                    {
                        MDids = "0";
                    }
                    objEntityBulkPrint.BAids = BAids;
                    objEntityBulkPrint.BDids = BDids;
                    objEntityBulkPrint.MAids = MAids;
                    objEntityBulkPrint.MDids = MDids;
                }
                DataTable dt = objBusiness.ReadSummaryThird(objEntityBulkPrint);
                DataTable dtGrp = objBusiness.ReadSummaryThirdGrp(objEntityBulkPrint);
                DataView dtview = new DataView(dtGrp);
                DataView dtviewAD = new DataView(dt);
                DataTable dtDistdeptAD = dtviewAD.ToTable(true, "PAYRL_ID", "PAYRL_NAME", "MODE1");
                DataTable dtDistdept = new DataTable();
                string strSumTypCol = "";
                if (Level == "0")
                {
                    dtDistdept = dtview.ToTable(true, "CPRDEPT_ID", "CPRDEPT_NAME");
                    strSumTypCol = "CPRDEPT_ID";
                }
                else if (Level == "1")
                {
                    dtDistdept = dtview.ToTable(true, "CPRDIV_ID", "CPRDIV_NAME");
                    strSumTypCol = "CPRDIV_ID";
                }
                else if (Level == "2")
                {
                    dtDistdept = dtview.ToTable(true, "STAFF_WORKER", "STAFF_WORKER_NAME");
                    strSumTypCol = "STAFF_WORKER";
                }
                else if (Level == "4")
                {
                    dtDistdept = dtview.ToTable(true, "SLPRCDMNTH_NUMBR");
                    strSumTypCol = "SLPRCDMNTH_NUMBR";
                }
                DataRow[] drMode1 = dtDistdeptAD.Select("MODE1=1");
                DataRow[] drMode2 = dtDistdeptAD.Select("MODE1=2");
                DataRow[] drMode3 = dtDistdeptAD.Select("MODE1=3");
                DataRow[] drMode4 = dtDistdeptAD.Select("MODE1=4");
                int Mode1Cnt = drMode1.Length + 1;
                int Mode2Cnt = drMode2.Length + 1;
                int Mode3Cnt = drMode3.Length + 1;
                int Mode4Cnt = drMode4.Length + 1;
                int ColSpanB = 0;


                if (ShowEmpCode == "1")
                {
                    TotCol++;
                    ColSpanB++;
                }
                if (ShowEmpName == "1")
                {
                    TotCol++;
                    ColSpanB++;
                }
                if (ShowDept == "1" && Level != "0")
                {
                    TotCol++;
                    ColSpanB++;
                }
                if (ShowDesg == "1")
                {
                    TotCol++;
                    ColSpanB++;
                }
                if (ShowJob == "1")
                {
                    TotCol++;
                    ColSpanB++;
                }
                if (objEntityBulkPrint.BAids != "0")
                {
                    TotCol += Mode1Cnt;
                }
                if (objEntityBulkPrint.BDids != "0")
                {
                    TotCol += Mode2Cnt;
                }
                if (objEntityBulkPrint.MAids != "0")
                {
                    TotCol += Mode3Cnt;
                }
                if (objEntityBulkPrint.MDids != "0")
                {
                    TotCol += Mode4Cnt;
                }           


                PdfPTable tabHeadMSP = new PdfPTable(TotCol);
                tabHeadMSP.WidthPercentage = 100;
                tabHeadMSP.HeaderRows = 2;
                if (ShowEmpCode == "1")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("EMPLOYEE ID", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Rowspan = 2, HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                if (ShowEmpName == "1")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("EMPLOYEE", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Rowspan = 2, HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                if (ShowDept == "1" && Level != "0")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("DEPARTMENT", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Rowspan = 2, HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                if (ShowDesg == "1")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("DESIGNATION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Rowspan = 2, HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                if (ShowJob == "1")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("JOB", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Rowspan = 2, HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });               
                if (objEntityBulkPrint.BAids != "0")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("ADDITION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Colspan = Mode1Cnt, HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                if (objEntityBulkPrint.BDids != "0")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("DEDUCTION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Colspan = Mode2Cnt, HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                if (objEntityBulkPrint.MAids != "0")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("MANUAL ADDITION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Colspan = Mode3Cnt, HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                if (objEntityBulkPrint.MDids != "0")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("MANUAL DEDUCTION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Colspan = Mode4Cnt, HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                }               
                tabHeadMSP.AddCell(new PdfPCell(new Phrase("TOTAL ADDITION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Rowspan = 2, HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });               
                tabHeadMSP.AddCell(new PdfPCell(new Phrase("TOTAL DEDUCTION", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Rowspan = 2, HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                foreach (DataRow dr1 in drMode1)
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(dr1["PAYRL_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                if (objEntityBulkPrint.BAids != "0")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                foreach (DataRow dr1 in drMode2)
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(dr1["PAYRL_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                if (objEntityBulkPrint.BDids != "0")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                foreach (DataRow dr1 in drMode3)
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(dr1["PAYRL_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                if (objEntityBulkPrint.MAids != "0")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                foreach (DataRow dr1 in drMode4)
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(dr1["PAYRL_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                if (objEntityBulkPrint.MDids != "0")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });

                string GrpName = "", SumQry = "", SumQry1 = "";
                decimal GrandBa = 0, GrandBd = 0, GrandMa = 0, GrandMd = 0;
                for (int i = 0; i < dtDistdept.Rows.Count; i++)
                {
                    if (Level == "4")
                    {
                        GrpName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(dtDistdept.Rows[i][0].ToString()));
                    }
                    else
                    {
                        GrpName = dtDistdept.Rows[i][1].ToString();
                    }
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(GrpName, FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Colspan = TotCol, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });

                SumQry = strSumTypCol + "=" + dtDistdept.Rows[i][0].ToString();
                decimal GrpwiseTotBa = 0, GrpwiseTotBd = 0, GrpwiseTotMa = 0, GrpwiseTotMd = 0;
                DataRow[] dr = dtGrp.Select("" + strSumTypCol + "='" + dtDistdept.Rows[i][0].ToString() + "'");


                foreach (DataRow dRow in dr)
                 {
                    SumQry1 = "";
                    if (ShowEmpCode == "1")
                    {
                        SumQry1 += " AND  USR_CODE='" + dRow["USR_CODE"].ToString() + "'";
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(dRow["USR_CODE"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    }
                    if (ShowEmpName == "1")
                    {
                        SumQry1 += " AND  USR_NAME='" + dRow["USR_NAME"].ToString() + "'";
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(dRow["USR_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    }
                    if (ShowDept == "1" && Level != "0")
                    {
                        SumQry1 += " AND  CPRDEPT_ID=" + dRow["CPRDEPT_ID"].ToString();
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(dRow["CPRDEPT_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    }
                    if (ShowDesg == "1")
                    {
                         SumQry1 += " AND  DSGN_ID=" + dRow["DSGN_ID"].ToString();
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(dRow["DSGN_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    }
                    if (ShowJob == "1")
                    {
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    }

                    decimal decTotBa = 0;
                    foreach (DataRow dr1 in drMode1)
                    {
                        decimal curr = 0;
                        string StrCurr = dt.Compute("Sum(AMT)", "" + SumQry + SumQry1 + " AND MODE1=1 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                        if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                            curr = Convert.ToDecimal(StrCurr);
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        decTotBa += curr;
                    }
                    if (objEntityBulkPrint.BAids != "0")
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotBa, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    GrpwiseTotBa += decTotBa;



                    decimal decTotBd = 0;
                    foreach (DataRow dr1 in drMode2)
                    {
                        decimal curr = 0;
                        string StrCurr = dt.Compute("Sum(AMT)", "" + SumQry + SumQry1 + " AND MODE1=2 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                        if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                            curr = Convert.ToDecimal(StrCurr);
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        decTotBd += curr;
                    }
                    if (objEntityBulkPrint.BDids != "0")
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotBd, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    GrpwiseTotBd += decTotBd;




                    decimal decTotMa = 0;
                    foreach (DataRow dr1 in drMode3)
                    {
                        decimal curr = 0;
                        string StrCurr = dt.Compute("Sum(AMT)", "" + SumQry + SumQry1 + " AND MODE1=3 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                        if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                            curr = Convert.ToDecimal(StrCurr);
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        decTotMa += curr;
                    }
                    if (objEntityBulkPrint.MAids != "0")
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotMa, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    GrpwiseTotMa += decTotMa;


                    decimal decTotMd = 0;
                    foreach (DataRow dr1 in drMode4)
                    {
                        decimal curr = 0;
                        string StrCurr = dt.Compute("Sum(AMT)", "" + SumQry + SumQry1 + " AND MODE1=4 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                        if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                            curr = Convert.ToDecimal(StrCurr);
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        decTotMd += curr;
                    }
                    if (objEntityBulkPrint.MDids != "0")
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotMd, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    GrpwiseTotMd += decTotMd;

                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotBa + decTotMa, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(decTotBd + decTotMd, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                  



                tabHeadMSP.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Colspan = ColSpanB, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                foreach (DataRow dr1 in drMode1)
                {
                    decimal curr = 0;
                    string StrCurr = dt.Compute("Sum(AMT)", "" + SumQry + " AND MODE1=1 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                    if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                        curr = Convert.ToDecimal(StrCurr);
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                if (objEntityBulkPrint.BAids != "0")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrpwiseTotBa, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });


                foreach (DataRow dr1 in drMode2)
                {
                    decimal curr = 0;
                    string StrCurr = dt.Compute("Sum(AMT)", "" + SumQry + " AND MODE1=2 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                    if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                        curr = Convert.ToDecimal(StrCurr);
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                if (objEntityBulkPrint.BDids != "0")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrpwiseTotBd, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });

                     foreach (DataRow dr1 in drMode3)
                {
                    decimal curr = 0;
                    string StrCurr = dt.Compute("Sum(AMT)", "" + SumQry + " AND MODE1=3 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                    if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                        curr = Convert.ToDecimal(StrCurr);
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                if (objEntityBulkPrint.MAids != "0")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrpwiseTotMa, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });

                     foreach (DataRow dr1 in drMode4)
                {
                    decimal curr = 0;
                    string StrCurr = dt.Compute("Sum(AMT)", "" + SumQry + " AND MODE1=4 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                    if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                        curr = Convert.ToDecimal(StrCurr);
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                if (objEntityBulkPrint.MDids != "0")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrpwiseTotMd, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
               
                 
                tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrpwiseTotBa + GrpwiseTotMa, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrpwiseTotBd + GrpwiseTotMd, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });

                GrandBa += GrpwiseTotBa;
                GrandBd += GrpwiseTotBd;
                GrandMa += GrpwiseTotMa;
                GrandMd += GrpwiseTotMd;
                }






                tabHeadMSP.AddCell(new PdfPCell(new Phrase("NET TOTAL", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Colspan = ColSpanB, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                foreach (DataRow dr1 in drMode1)
                {
                    decimal curr = 0;
                    string StrCurr = dt.Compute("Sum(AMT)", "MODE1=1 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                    if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                        curr = Convert.ToDecimal(StrCurr);
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                if (objEntityBulkPrint.BAids != "0")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrandBa, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });

                foreach (DataRow dr1 in drMode2)
                {
                    decimal curr = 0;
                    string StrCurr = dt.Compute("Sum(AMT)", "MODE1=2 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                    if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                        curr = Convert.ToDecimal(StrCurr);
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                if (objEntityBulkPrint.BDids != "0")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrandBd, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });

                foreach (DataRow dr1 in drMode3)
                {
                    decimal curr = 0;
                    string StrCurr = dt.Compute("Sum(AMT)", "MODE1=3 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                    if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                        curr = Convert.ToDecimal(StrCurr);
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                if (objEntityBulkPrint.MAids != "0")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrandMa, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                foreach (DataRow dr1 in drMode4)
                {
                    decimal curr = 0;
                    string StrCurr = dt.Compute("Sum(AMT)", "MODE1=4 AND PAYRL_ID=" + dr1["PAYRL_ID"].ToString() + "").ToString();
                    if (StrCurr != "" && StrCurr != null && StrCurr != "null")
                        curr = Convert.ToDecimal(StrCurr);
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(curr, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                if (objEntityBulkPrint.MDids != "0")
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrandMd, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });

                tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrandBa + GrandMa, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                tabHeadMSP.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Math.Round(GrandBd + GrandMd, roundNum).ToString("0.00"), objEntityCommon), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });

                    
                    
              document.Add(tabHeadMSP);







                float pos1 = writer.GetVerticalPosition(false);
                PdfPTable endtable = new PdfPTable(6);
                float[] endBody = { 25, 10, 25, 10, 25, 5 };
                endtable.SetWidths(endBody);
                endtable.WidthPercentage = 100;
                endtable.TotalWidth = document.PageSize.Width - 80f;

                endtable.AddCell(new PdfPCell(new Phrase("FINANCE MANAGER", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                endtable.AddCell(new PdfPCell(new Phrase("GENERAL MANAGER", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                endtable.AddCell(new PdfPCell(new Phrase("RECEIVER’S SIGNATURE", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });

                endtable.TotalWidth = 555F;
                if (pos1 > 90)
                {
                    endtable.WriteSelectedRows(0, -1, 123, 65, writer.DirectContent);
                }
                else
                {
                    document.NewPage();
                    endtable.WriteSelectedRows(0, -1, 123, 65, writer.DirectContent);
                }
                document.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
            }
        }
        catch (Exception ex)
        {
            strImageName = "";
            strImagePath = "";
        }
        return strImagePath + strImageName;
    }



    public class PDFHeader : PdfPageEventHelper
    {
        // This is the contentbyte object of the writer
        PdfContentByte cb;

        // we will put the final number of pages in a template
        PdfTemplate footerTemplate;

        // this is the BaseFont we are going to use for the header / footer
        BaseFont bf = null;

        // This keeps track of the creation time
        DateTime PrintTime = DateTime.Now;

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                PrintTime = DateTime.Now;
                bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb = writer.DirectContent;
                footerTemplate = cb.CreateTemplate(200, 200);
            }
            catch (DocumentException de)
            {
                //handle exception here
            }
            catch (System.IO.IOException ioe)
            {
                //handle exception here
            }
        }
        public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            base.OnEndPage(writer, document);
            clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
            clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
            objEntityLeavSettlmt.EmployeeId = Convert.ToInt32(HttpContext.Current.Session["USERID"].ToString());
            DataTable dtEmp = objBusinessLeavSettlmt.ReadEmpDtls(objEntityLeavSettlmt);


            PdfPTable table3 = new PdfPTable(1);
            float[] tableBody3 = { 100 };
            table3.SetWidths(tableBody3);
            table3.WidthPercentage = 100;
            table3.TotalWidth = 950F;
            table3.AddCell(new PdfPCell(new Phrase("_____________________________________________________________________________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
            table3.WriteSelectedRows(0, -1, 0, document.PageSize.GetBottom(50), writer.DirectContent);

            PdfPTable headImg = new PdfPTable(3);
            string strImageLogo = "/Images/Design_Images/images/Compztlogo.png";
            if (strImageLogo != "")
            {
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
                image.ScalePercent(PdfPCell.ALIGN_CENTER);
                image.ScaleToFit(60f, 40f);
                headImg.AddCell(new PdfPCell(image) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_TOP });
            }
            headImg.AddCell(new PdfPCell(new Paragraph("Report generated in Compzit by:" + dtEmp.Rows[0]["USR_CODE"].ToString() + ", " + dtEmp.Rows[0]["USR_FNAME"].ToString() + "\nReport generated on:" + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
            headImg.AddCell(new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            float[] headersHeading = { 20, 60, 20 };
            headImg.SetWidths(headersHeading);
            headImg.WidthPercentage = 100;
            headImg.TotalWidth = document.PageSize.Width - 80f;
            headImg.WriteSelectedRows(0, -1, 50, document.PageSize.GetBottom(40), writer.DirectContent);


            String text = "Page " + writer.PageNumber + " of ";
            //Add paging to footer
            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.SetTextMatrix(document.PageSize.GetRight(100), document.PageSize.GetBottom(30));
                cb.ShowText(text);
                cb.EndText();
                float len = bf.GetWidthPoint(text, 8);
                cb.AddTemplate(footerTemplate, document.PageSize.GetRight(100) + len, document.PageSize.GetBottom(30));
            }
        }
        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
            footerTemplate.BeginText();
            footerTemplate.SetFontAndSize(bf, 8);
            footerTemplate.SetTextMatrix(0, 0);
            footerTemplate.ShowText((writer.PageNumber).ToString());
            footerTemplate.EndText();
        }
    }
}