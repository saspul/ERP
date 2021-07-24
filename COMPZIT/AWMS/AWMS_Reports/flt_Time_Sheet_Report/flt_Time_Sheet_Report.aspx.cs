using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.Text;
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_AWMS;
using CL_Compzit;
using BL_Compzit;
public partial class AWMS_AWMS_Reports_flt_Time_Sheet_Report_flt_Time_Sheet_Report : System.Web.UI.Page
{
    //enumeration for previous and next button
    private enum Button_type
    {
        Previous = 1,
        Next = 2
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnNext.Enabled = false;
            btnPrevious.Enabled = false;
            string strMonth = DateTime.Now.Month.ToString();
            BindDdlMonths(strMonth);
            string strQuarter = "";
            strQuarter = SelectQuarter(strMonth);
            if (strQuarter != "")
            {
                if (ddlQuarter.Items.FindByValue(strQuarter) != null)
                {
                    ddlQuarter.Items.FindByValue(strQuarter).Selected = true;
                }
            }
            string strYear = DateTime.Today.Year.ToString();
            BindDdlYears(strYear);
            LoadEmployee();
            LoadDepartment();
            LoadDivision();
            

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }



            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {   clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE ,
                                                                clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {

                string strListingMode = dtCorpDetail.Rows[0]["LISTING_MODE"].ToString();
                string strLstingModeSize = dtCorpDetail.Rows[0]["LISTING_MODE_SIZE"].ToString();

                //strLstingModeSize = "1";
                int intListingMode = Convert.ToInt32(strListingMode);

                if (intListingMode == 2)//variant
                {
                    btnNext.Text = "Show Next Records";
                    btnPrevious.Text = "Show Previous Records";
                    hiddenMemorySize.Value = strLstingModeSize;
                }
                else if (intListingMode == 1)//fixed
                {
                    btnNext.Text = "Show Next " + strLstingModeSize + " Records";
                    btnPrevious.Text = "Show Previous " + strLstingModeSize + " Records";
                    hiddenTotalRowCount.Value = strLstingModeSize;
                    hiddenNext.Value = strLstingModeSize;
                }
                hiddenPrevious.Value = "0";

            }
            LoadNoDataTable();
            //radioDaily.Checked = true;
            //RadioDivision.Checked = true;
            radioDaily.Focus();
        }
    }
    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        Set_Table(Convert.ToInt32(Button_type.Previous));
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Set_Table(Convert.ToInt32(Button_type.Next));
    }
  
    //prepare table set datatable
    public void Set_Table(int intButtonId)
    {

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        //Creating objects for business layer
        clsBusinessLayerTimeSheetReport objBusinessLayerTimeSheetReport = new clsBusinessLayerTimeSheetReport();
        clsEntityLayerTimeSheetReport objEntityTimeSheetReport = new clsEntityLayerTimeSheetReport();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityTimeSheetReport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityTimeSheetReport.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityTimeSheetReport.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtTimeSheetReport = new DataTable();

        if (hiddenSrchMode.Value == "Daily")
        {
            objEntityTimeSheetReport.Date = objCommon.textToDateTime(HiddenDailySrch.Value);
        }
        else if (hiddenSrchMode.Value == "Monthly")
        {
            string strMonthSrch = HiddenMonthlySrch.Value;
            string[] strSearchFields = strMonthSrch.Split(',');
            string strSearchMonth = strSearchFields[0];
            string strSrchYear = strSearchFields[1];
            objEntityTimeSheetReport.Month = String.Format("{0:D2}", Convert.ToInt32(strSearchMonth));
            objEntityTimeSheetReport.YearCommon = Convert.ToInt32(strSrchYear);
        }
        else if (hiddenSrchMode.Value == "Quarterly")
        {
            string strQurterlySrch = HiddenQurterlySrch.Value;
            string[] strSearchFields = strQurterlySrch.Split(',');
            string strSearchQurterly = strSearchFields[0];
            string strSrchYear = strSearchFields[1];
            objEntityTimeSheetReport.Quarter = Convert.ToInt32(strSearchQurterly);
            objEntityTimeSheetReport.YearCommon = Convert.ToInt32(strSrchYear);
        }
        else if (hiddenSrchMode.Value == "Yearly")
        {

            objEntityTimeSheetReport.Year = Convert.ToInt32(HiddenYearlySrch.Value);
        }
        else if (hiddenSrchMode.Value == "Custom")
        {
            string strCustomSrch = HiddenCustomSrch.Value;
            string[] strSearchFields = strCustomSrch.Split(',');
            string strFromDate = strSearchFields[0];
            string strToDate = strSearchFields[1];
            string strTempDate;
            DateTime dateFromDate = Convert.ToDateTime(strFromDate);
            strTempDate = dateFromDate.ToString("dd-MM-yyyy");
            strTempDate = String.Format("{0:dd-MM-yyyy}", strTempDate);
            objEntityTimeSheetReport.FromDate = objCommon.textToDateTime(strTempDate);
            DateTime dateToDate = Convert.ToDateTime(strToDate);
            strTempDate = dateToDate.ToString("dd-MM-yyyy");
            strTempDate = String.Format("{0:dd-MM-yyyy}", strTempDate);


            objEntityTimeSheetReport.ToDate = objCommon.textToDateTime(strTempDate);
        }

        if (HiddenEmployeeSrch.Value != "")
        {
            objEntityTimeSheetReport.EmployeeId = Convert.ToInt32(HiddenEmployeeSrch.Value);
        }
        //DIVISION OR DEPT
        if (hiddenSubSrchMode.Value == "Division")
        {
            if (HiddenDivSrch.Value != "")
            {
                objEntityTimeSheetReport.DivisionId = Convert.ToInt32(HiddenDivSrch.Value);
            }
        }
        else if( hiddenSubSrchMode.Value == "Dept")
        {
            if (HiddenDeptSrch.Value!= "")
            {
                objEntityTimeSheetReport.DepartmentId = Convert.ToInt32(HiddenDeptSrch.Value);
            }
        }
       
        dtTimeSheetReport = objBusinessLayerTimeSheetReport.ReadTimeSheetReport(objEntityTimeSheetReport);
        lblNumRec.Text = "Total number of records : " + dtTimeSheetReport.Rows.Count.ToString();
        //string strHtm = ConvertDataTableToHTML(dtTimeSheetReport);
        ////Write to divReport
        //divReport.InnerHtml = strHtm;


        ////string strPrintReport = ConvertDataTableForPrint(dtBankGurante);
        //string strPrintReport = ConvertDataTableForPrint(dtTimeSheetReport);

        //divPrintReport.InnerHtml = strPrintReport;


        int first = 0;
        int last = 0;

        if (intButtonId == Convert.ToInt32(Button_type.Next))
        {
            first = Convert.ToInt32(hiddenNext.Value);
            last = Convert.ToInt32(hiddenNext.Value) + Convert.ToInt32(hiddenTotalRowCount.Value);
            hiddenPrevious.Value = first.ToString();
            hiddenNext.Value = last.ToString();
        }

        if (intButtonId == Convert.ToInt32(Button_type.Previous))
        {
            first = Convert.ToInt32(hiddenPrevious.Value) - Convert.ToInt32(hiddenTotalRowCount.Value);
            last = Convert.ToInt32(hiddenPrevious.Value);
            hiddenPrevious.Value = first.ToString();
            hiddenNext.Value = last.ToString();
        }
        if (first == 0)
        {
            btnPrevious.Enabled = false;

        }
        else
        {
            btnPrevious.Enabled = true;
        }
        if (last < dtTimeSheetReport.Rows.Count)
        {

            btnNext.Enabled = true;
        }
        else
        {
            btnNext.Enabled = false;
        }
        string strHtm = ConvertDataTableToHTML(dtTimeSheetReport);
        //Write to divReport
        divReport.InnerHtml = strHtm;
    }
    public void BindDdlMonths(string strMonth = null)
    {
        var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
        for (int i = 0; i < months.Length - 1; i++)
        {
            ddlMonth.Items.Add(new ListItem(months[i], (i + 1).ToString()));
        }
        if (strMonth != null)
        {
            if (ddlMonth.Items.FindByValue(strMonth) != null)
            {
                ddlMonth.Items.FindByValue(strMonth).Selected = true;
            }
        }
    }
    public string SelectQuarter(string strMonth = null)
    {
        string strQuarter = "";
        int intMonth = Convert.ToInt32(strMonth);
        if (intMonth == 1 || intMonth == 2 || intMonth == 3)
        {
            strQuarter = "1";
        }
        else if (intMonth == 4 || intMonth == 5 || intMonth == 6)
        {
            strQuarter = "2";

        }
        else if (intMonth == 7 || intMonth == 8 || intMonth == 9)
        {
            strQuarter = "3";
        }
        else if (intMonth == 10 || intMonth == 11 || intMonth == 12)
        {
            strQuarter = "4";
        }
        return strQuarter;
    }
    public void BindDdlYears(string strYear = null)
    {
        var currentYear = DateTime.Today.Year;
        for (int i = 30; i >= 0; i--)
        {
            ddlMonthlyYear.Items.Add((currentYear - i).ToString());
            ddlQuarterlyYear.Items.Add((currentYear - i).ToString());
            ddlYearlyYear.Items.Add((currentYear - i).ToString());
        }
        if (strYear != null)
        {
            if (ddlMonthlyYear.Items.FindByValue(strYear) != null)
            {
                ddlMonthlyYear.Items.FindByValue(strYear).Selected = true;
            }
            if (ddlQuarterlyYear.Items.FindByValue(strYear) != null)
            {
                ddlQuarterlyYear.Items.FindByValue(strYear).Selected = true;
            }
            if (ddlYearlyYear.Items.FindByValue(strYear) != null)
            {
                ddlYearlyYear.Items.FindByValue(strYear).Selected = true;
            }
        }
    }
    public void LoadEmployee()
    {

        clsBusinessLayerTimeSheetReport objBusinessLayerTimeSheetReport = new clsBusinessLayerTimeSheetReport();
        clsEntityLayerTimeSheetReport objEntityTimeSheetReport = new clsEntityLayerTimeSheetReport();
        DataTable dtEmployees = new DataTable();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityTimeSheetReport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityTimeSheetReport.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityTimeSheetReport.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        //BL
        dtEmployees = objBusinessLayerTimeSheetReport.ReadEmployee(objEntityTimeSheetReport);

        ddlEmployee.DataSource = dtEmployees;
        ddlEmployee.DataTextField = "USR_NAME";
        ddlEmployee.DataValueField = "USR_ID";//DSGTYP_ID
        ddlEmployee.DataBind();
        ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");
    }
    public void LoadDivision()
    {

        clsBusinessLayerTimeSheetReport objBusinessLayerTimeSheetReport = new clsBusinessLayerTimeSheetReport();
        clsEntityLayerTimeSheetReport objEntityTimeSheetReport = new clsEntityLayerTimeSheetReport();
        DataTable dtDivision = new DataTable();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityTimeSheetReport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityTimeSheetReport.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityTimeSheetReport.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        //BL
        dtDivision = objBusinessLayerTimeSheetReport.ReadDivision(objEntityTimeSheetReport);

        ddlDivision.DataSource = dtDivision;
        ddlDivision.DataTextField = "CPRDIV_NAME";
        ddlDivision.DataValueField = "CPRDIV_ID";//DSGTYP_ID
        ddlDivision.DataBind();
        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
    }
    public void LoadDepartment()
    {


        clsBusinessLayerTimeSheetReport objBusinessLayerTimeSheetReport = new clsBusinessLayerTimeSheetReport();
        clsEntityLayerTimeSheetReport objEntityTimeSheetReport = new clsEntityLayerTimeSheetReport();
        DataTable dtDepartment = new DataTable();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityTimeSheetReport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityTimeSheetReport.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //BL
        dtDepartment = objBusinessLayerTimeSheetReport.ReadDepartment(objEntityTimeSheetReport);

        ddlDepartment.DataSource = dtDepartment;
        ddlDepartment.DataTextField = "CPRDEPT_NAME";
        ddlDepartment.DataValueField = "CPRDEPT_ID";//DSGTYP_ID
        ddlDepartment.DataBind();
        ddlDepartment.Items.Insert(0, "--SELECT DEPARTMENT--");
    }
    public void LoadNoDataTable()
    {
        clsBusinessLayerTimeSheetReport objBusinessLayerTimeSheetReport = new clsBusinessLayerTimeSheetReport();
        clsEntityLayerTimeSheetReport objEntityTimeSheetReport = new clsEntityLayerTimeSheetReport();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityTimeSheetReport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityTimeSheetReport.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityTimeSheetReport.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtTimeSheetReport = new DataTable();
        if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
        {
            objEntityTimeSheetReport.EmployeeId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
        }
        //DIVISION OR DEPT
        if (RadioDivision.Checked == true)
        {
            if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
            {
                objEntityTimeSheetReport.DivisionId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
            }
            //hiddenSubSrchMode.Value = "Division";
        }
        else
        {
            if (ddlDepartment.SelectedItem.Value != "--SELECT DEPARTMENT--")
            {
                objEntityTimeSheetReport.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedItem.Value);
            }
            //hiddenSubSrchMode.Value = "Dept";

        }


        objEntityTimeSheetReport.Year = 1000;
        hiddenSrchMode.Value = "";

        dtTimeSheetReport = objBusinessLayerTimeSheetReport.ReadTimeSheetReport(objEntityTimeSheetReport);
        string strHtm = ConvertDataTableToHTML(dtTimeSheetReport);
        //Write to divReport
        lblNumRec.Text = "Total number of records : " + dtTimeSheetReport.Rows.Count.ToString();
        divReport.InnerHtml = strHtm;


        //string strPrintReport = ConvertDataTableForPrint(dtBankGurante);
        string strPrintReport = ConvertDataTableForPrint(dtTimeSheetReport);

        divPrintReport.InnerHtml = strPrintReport;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsBusinessLayerTimeSheetReport objBusinessLayerTimeSheetReport = new clsBusinessLayerTimeSheetReport();
        clsEntityLayerTimeSheetReport objEntityTimeSheetReport = new clsEntityLayerTimeSheetReport();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        //add on
        btnNext.Enabled = false;
        btnPrevious.Enabled = false;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        //clsCommonLibrary objCommon = new clsCommonLibrary();
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else 
        {
            Response.Redirect("/Default.aspx");
        }



        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {   clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE ,
                                                                clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {

            string strListingMode = dtCorpDetail.Rows[0]["LISTING_MODE"].ToString();
            string strLstingModeSize = dtCorpDetail.Rows[0]["LISTING_MODE_SIZE"].ToString();

            //strLstingModeSize = "1";
            int intListingMode = Convert.ToInt32(strListingMode);

            if (intListingMode == 2)//variant
            {
                btnNext.Text = "Show Next Records";
                btnPrevious.Text = "Show Previous Records";
                hiddenMemorySize.Value = strLstingModeSize;
            }
            else if (intListingMode == 1)//fixed
            {
                btnNext.Text = "Show Next " + strLstingModeSize + " Records";
                btnPrevious.Text = "Show Previous " + strLstingModeSize + " Records";
                hiddenTotalRowCount.Value = strLstingModeSize;
                hiddenNext.Value = strLstingModeSize;
            }
            hiddenPrevious.Value = "0";

        }
        //add on ends
 
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityTimeSheetReport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityTimeSheetReport.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityTimeSheetReport.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else 
        {
            Response.Redirect("~/Default.aspx");
        }

        DataTable dtTimeSheetReport = new DataTable();
        if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
        {
            objEntityTimeSheetReport.EmployeeId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
            HiddenEmployeeSrch.Value = objEntityTimeSheetReport.EmployeeId.ToString();
        }
        else
        {
            HiddenEmployeeSrch.Value = "";
        }
        //DIVISION OR DEPT
        if (RadioDivision.Checked == true)
        {
            if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
            {
                objEntityTimeSheetReport.DivisionId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
                HiddenDivSrch.Value = objEntityTimeSheetReport.DivisionId.ToString();
            }
            hiddenSubSrchMode.Value = "Division";
        }
        else
        {
            if (ddlDepartment.SelectedItem.Value != "--SELECT DEPARTMENT--")
            {
                objEntityTimeSheetReport.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedItem.Value);
                HiddenDeptSrch.Value = objEntityTimeSheetReport.DepartmentId.ToString();
            }
            hiddenSubSrchMode.Value = "Dept";

        }
        //DAILY MONTHLY YEARLY QUARTERLY CUSTOM
        if (radioDaily.Checked == true)
        {
            objEntityTimeSheetReport.Date = objCommon.textToDateTime(txtDate.Text);
            HiddenDailySrch.Value = objEntityTimeSheetReport.Date.ToString();
            hiddenSrchMode.Value = "Daily";
        }
        else if (radioMonthly.Checked == true)
        {
            objEntityTimeSheetReport.Month = String.Format("{0:D2}", Convert.ToInt32(ddlMonth.SelectedItem.Value));
            objEntityTimeSheetReport.YearCommon = Convert.ToInt32(ddlMonthlyYear.SelectedItem.Value);
            HiddenMonthlySrch.Value = objEntityTimeSheetReport.Month.ToString() + "," + objEntityTimeSheetReport.YearCommon.ToString();
            hiddenSrchMode.Value = "Monthly";
        }
        else if (radioQuarterly.Checked == true)
        {
            objEntityTimeSheetReport.Quarter = Convert.ToInt32(ddlQuarter.SelectedItem.Value);
            objEntityTimeSheetReport.YearCommon = Convert.ToInt32(ddlQuarterlyYear.SelectedItem.Value);
            HiddenQurterlySrch.Value = objEntityTimeSheetReport.Quarter.ToString() + "," + objEntityTimeSheetReport.YearCommon.ToString();

            hiddenSrchMode.Value = "Quarterly";
        }
        else if (RadioYearly.Checked == true)
        {
            objEntityTimeSheetReport.Year = Convert.ToInt32(ddlYearlyYear.SelectedItem.Value);
            HiddenYearlySrch.Value = objEntityTimeSheetReport.Year.ToString();
            hiddenSrchMode.Value = "Yearly";
        }
        else if (RadioCustom.Checked == true)
        {
            objEntityTimeSheetReport.FromDate = objCommon.textToDateTime(txtFromDate.Text);
            objEntityTimeSheetReport.ToDate = objCommon.textToDateTime(txtTodate.Text);
            HiddenCustomSrch.Value = objEntityTimeSheetReport.FromDate.ToString() + "," + objEntityTimeSheetReport.ToDate.ToString();
            hiddenSrchMode.Value = "Custom";
        }
        dtTimeSheetReport = objBusinessLayerTimeSheetReport.ReadTimeSheetReport(objEntityTimeSheetReport);
        lblNumRec.Text = "Total number of records : " + dtTimeSheetReport.Rows.Count.ToString();
        string strHtm = ConvertDataTableToHTML(dtTimeSheetReport);
        //Write to divReport
        divReport.InnerHtml = strHtm;


        //string strPrintReport = ConvertDataTableForPrint(dtBankGurante);
        string strPrintReport = ConvertDataTableForPrint(dtTimeSheetReport);

        divPrintReport.InnerHtml = strPrintReport;
    }
    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt)
    {
        int first = Convert.ToInt32(hiddenPrevious.Value);
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        string strSrchMode = hiddenSrchMode.Value.ToString();
        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
           
           
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:22%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            //if (intColumnHeaderCount == 2)
            //{
            //    strHtml += "<th class=\"thT\" style=\"width:22%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            //}
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:13%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 8)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 9)
            {
                strHtml += "<th class=\"thT\"  style=\"width:16%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
        }
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";

        int intMonth = 0, intDay = 0, intQuarter = 0;
        for (int intRowBodyCount = first; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            int intMemoryBytes = System.Text.ASCIIEncoding.Unicode.GetByteCount(strHtml);
            if (hiddenTotalRowCount.Value == "")
            {
                if (hiddenMemorySize.Value != "")
                
                {//if(dt.Rows.Count>=30)
                    if (intMemoryBytes >= Convert.ToInt64(hiddenMemorySize.Value))
                    {
                        hiddenTotalRowCount.Value = intRowBodyCount.ToString();
                        hiddenNext.Value = hiddenTotalRowCount.Value;
                        btnNext.Enabled = true;
                        break;
                    }
                    else
                    {
                        //convertTohtml
                        DateTime dateTemp =objCommon.textToDateTime(dt.Rows[intRowBodyCount]["DATE"].ToString());
                        if (strSrchMode == "Monthly")
                        {

                            if (intDay != dateTemp.Day)
                            {
                                strHtml += "<tr  >";
                                strHtml += "<td class=\"tdT\" colspan=\"8\" style=\" background: #dbd8d8;font-weight: bold; width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";
                                strHtml += "</tr>";
                                intDay = dateTemp.Day;
                            }
                        }

                        if (strSrchMode == "Quarterly")
                        {

                            int intTempMonth = dateTemp.Month;
                            int intTempQuarter = Convert.ToInt32(SelectQuarter(intTempMonth.ToString()));
                            if (intQuarter != intTempQuarter)
                            {
                                intQuarter = intTempQuarter;
                                strHtml += "<tr  >";
                                strHtml += "<td class=\"tdT\" colspan=\"8\" style=\"color: #000;text-transform: uppercase;background: #cfcccc; font-weight: bold; width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >Quarter " + intQuarter + "</td>";
                                strHtml += "</tr>";

                            }
                            if (intDay != dateTemp.Day)
                            {
                                strHtml += "<tr  >";
                                strHtml += "<td class=\"tdT\" colspan=\"8\" style=\"color: #000;background: #dbd8d8; font-weight: bold; width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";
                                strHtml += "</tr>";
                                intDay = dateTemp.Day;
                            }
                        }
                        if (strSrchMode == "Yearly")
                        {
                            int intTempMonth = dateTemp.Month;
                            if (intMonth != intTempMonth)
                            {
                                strHtml += "<tr  >";
                                strHtml += "<td class=\"tdT\" colspan=\"8\" style=\"color: #000;text-transform: uppercase;background: #cfcccc; font-weight: bold; width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dateTemp.ToString("MMMM") + "</td>";
                                strHtml += "</tr>";
                                intMonth = intTempMonth;

                            }
                            if (intDay != dateTemp.Day)
                            {
                                strHtml += "<tr  >";
                                strHtml += "<td class=\"tdT\" colspan=\"8\" style=\"color: #000;background: #dbd8d8; font-weight: bold; width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";
                                strHtml += "</tr>";
                                intDay = dateTemp.Day;
                            }
                        }
                        if (strSrchMode == "Custom")
                        {
                            if (intDay != dateTemp.Day)
                            {
                                strHtml += "<tr  >";
                                strHtml += "<td class=\"tdT\" colspan=\"8\" style=\"color: #000;background: #dbd8d8; font-weight: bold; width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";
                                strHtml += "</tr>";
                                intDay = dateTemp.Day;
                            }
                        }
                        strHtml += "<tr  >";


                        for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                        {
                            //if (j == 0)
                            //{
                            //    int intCnt = i + 1;
                            //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                            //}

                            
                            if (intColumnBodyCount == 1)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            //if (intColumnBodyCount == 2)
                            //{
                            //    strHtml += "<td class=\"tdT\" style=\" width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            //}
                            else if (intColumnBodyCount == 3)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            else if (intColumnBodyCount == 4)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            else if (intColumnBodyCount == 5)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            else if (intColumnBodyCount == 6)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            else if (intColumnBodyCount == 7)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            else if (intColumnBodyCount == 8)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            else if (intColumnBodyCount == 9)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:16%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                        }
                        strHtml += "</tr>";
                    }
                }
            }
            else
            {
                if (hiddenNext.Value == "")
                {
                    hiddenNext.Value = hiddenTotalRowCount.Value;
                }
                int last = Convert.ToInt32(hiddenNext.Value);
                if (intRowBodyCount < last)
                {
                    //convertTohtml
                    DateTime dateTemp = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["DATE"].ToString());
                    if (strSrchMode == "Monthly")
                    {

                        if (intDay != dateTemp.Day)
                        {
                            strHtml += "<tr  >";
                            strHtml += "<td class=\"tdT\" colspan=\"8\" style=\"color: #000; background: #dbd8d8;font-weight: bold; width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";
                            strHtml += "</tr>";
                            intDay = dateTemp.Day;
                        }
                    }

                    if (strSrchMode == "Quarterly")
                    {

                        int intTempMonth = dateTemp.Month;
                        int intTempQuarter = Convert.ToInt32(SelectQuarter(intTempMonth.ToString()));
                        if (intQuarter != intTempQuarter)
                        {
                            intQuarter = intTempQuarter;
                            strHtml += "<tr  >";
                            strHtml += "<td class=\"tdT\" colspan=\"8\" style=\"color: #000;text-transform: uppercase;background: #cfcccc; font-weight: bold; width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >Quarter " + intQuarter + "</td>";
                            strHtml += "</tr>";

                        }
                        if (intDay != dateTemp.Day)
                        {
                            strHtml += "<tr  >";
                            strHtml += "<td class=\"tdT\" colspan=\"8\" style=\"color: #000;background: #dbd8d8; font-weight: bold; width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";
                            strHtml += "</tr>";
                            intDay = dateTemp.Day;
                        }
                    }
                    if (strSrchMode == "Yearly")
                    {
                        int intTempMonth = dateTemp.Month;
                        if (intMonth != intTempMonth)
                        {
                            strHtml += "<tr  >";
                            strHtml += "<td class=\"tdT\" colspan=\"8\" style=\"color: #000;text-transform: uppercase;background: #cfcccc; font-weight: bold; width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dateTemp.ToString("MMMM") + "</td>";
                            strHtml += "</tr>";
                            intMonth = intTempMonth;
                        }
                        if (intDay != dateTemp.Day)
                        {
                            strHtml += "<tr  >";
                            strHtml += "<td class=\"tdT\" colspan=\"8\" style=\"color: #000;background: #dbd8d8; font-weight: bold; width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";
                            strHtml += "</tr>";
                            intDay = dateTemp.Day;
                        }
                    }
                    if (strSrchMode == "Custom")
                    {
                        if (intDay != dateTemp.Day)
                        {
                            strHtml += "<tr  >";
                            strHtml += "<td class=\"tdT\" colspan=\"8\" style=\"color: #000;background: #dbd8d8; font-weight: bold; width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";
                            strHtml += "</tr>";
                            intDay = dateTemp.Day;
                        }
                    }
                    strHtml += "<tr  >";


                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {
                        //if (j == 0)
                        //{
                        //    int intCnt = i + 1;
                        //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                        //}


                        if (intColumnBodyCount == 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        //if (intColumnBodyCount == 2)
                        //{
                        //    strHtml += "<td class=\"tdT\" style=\" width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        //}
                        else if (intColumnBodyCount == 3)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 4)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 5)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 6)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 7)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 8)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 9)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:16%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                    }
                    strHtml += "</tr>";
                }
                else
                {
                    btnNext.Enabled = true;
                }
            }
            //int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());

        }
        if (dt.Rows.Count == 0)
        {
            strHtml += "<tr>";
            strHtml += "<tfooter>";

            strHtml += "<td  class=\"thT\" colspan=\"8\" style=\"font-weight: unset; background: #dbd8d8;border-right: navajowhite;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";

            strHtml += "</tfooter>";
            strHtml += "</tr>";
        }
        strHtml += "</tbody>";

        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    //It build the Html table by using the datatable provided
    public string ConvertDataTableForPrint(DataTable dt)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        string strSrchMode = hiddenSrchMode.Value.ToString();
        clsEntityLayerTimeSheetReport objEntityTimeSheetReport = new clsEntityLayerTimeSheetReport();
        clsBusinessLayerTimeSheetReport objBusinessTimeSheetReport = new clsBusinessLayerTimeSheetReport();
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        divtile.InnerHtml = "Time Sheet Report";
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityTimeSheetReport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityTimeSheetReport.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtcorp = objBusinessTimeSheetReport.Read_Corp_Details(objEntityTimeSheetReport);
        //title
        if (dtcorp.Rows.Count > 0)
        {
            strCompanyName = dtcorp.Rows[0]["CORPRT_NAME"].ToString();
            strCompanyAddr1 = dtcorp.Rows[0]["CORPRT_ADDR1"].ToString();
            strCompanyAddr2 = dtcorp.Rows[0]["CORPRT_ADDR2"].ToString();
            strCompanyAddr3 = dtcorp.Rows[0]["CORPRT_ADDR3"].ToString();
            strCompanyAddrCntry = dtcorp.Rows[0]["CNTRY_NAME"].ToString();
        }

        string strCompanyAddr = objCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);
        //Create Caption Table Daily
        if (strSrchMode == "Daily")
        {
            StringBuilder sbCap = new StringBuilder();
            string strCapTable = "";
            strCapTable = "<table class=\"PrintCaptionTable\" >";
            strCapTable += "<tr><th class=\"CompanyName\" style=\"text-align: left; word-wrap:break-word;\">" + strCompanyName + "</th><td></td></tr>";
            strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">" + strCompanyAddr + "</th><td></td></tr>";
            strCapTable += "<tr><td><b>Report Date : </b>" + DateTime.Now.ToString("R") + "</td></tr>";
            strCapTable += "<tr><th colspan=\"2\" style=\"text-align: left; word-wrap:break-word;\">Time Sheet Report</th><td></td></tr>";
            if (RadioDivision.Checked == true)
            {
                if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
                {
                    strCapTable += "<tr><td><b>Division : </b>" + ddlDivision.SelectedItem.Text + "</td></tr>";
                }

            }
            else if (RadioDept.Checked == true)
            {
                if (ddlDepartment.SelectedItem.Value != "--SELECT DEPARTMENT--")
                {
                    strCapTable += "<tr><td><b>Department : </b>" + ddlDepartment.SelectedItem.Text + "</td></tr>";
                }
            }
            if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
            {
                strCapTable += "<tr><td><b>Employee : </b>" + ddlEmployee.SelectedItem.Text + "</td></tr>";
            }

            strCapTable += "<tr><td><b>Date : </b>" + txtDate.Text + "</td></tr>";


            
            strCapTable += "</table>";
            sbCap.Append(strCapTable);
            ////write to  divPrintCaption
            divPrintCaption.InnerHtml = sbCap.ToString();

        }
        else if (strSrchMode == "Monthly")
        {
            StringBuilder sbCap = new StringBuilder();
            string strCapTable = "";
            strCapTable = "<table class=\"PrintCaptionTable\" >";
            strCapTable += "<tr><th class=\"CompanyName\" style=\"text-align: left; word-wrap:break-word;\">" + strCompanyName + "</th><td></td></tr>";
            strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">" + strCompanyAddr + "</th><td></td></tr>";
            strCapTable += "<tr><td><b>Report Date : </b>" + DateTime.Now.ToString("R") + "</td></tr>";
            strCapTable += "<tr><th colspan=\"2\" style=\"text-align: left; word-wrap:break-word;\">Time Sheet Report</th><td></td></tr>";
            if (RadioDivision.Checked == true)
            {
                if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
                {
                    strCapTable += "<tr><td><b>Division : </b>" + ddlDivision.SelectedItem.Text + "</td></tr>";
                }

            }
            else if (RadioDept.Checked == true)
            {
                if (ddlDepartment.SelectedItem.Value != "--SELECT DEPARTMENT--")
                {
                    strCapTable += "<tr><td><b>Department : </b>" + ddlDepartment.SelectedItem.Text + "</td></tr>";
                }
            }
            if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
            {
                strCapTable += "<tr><td><b>Employee : </b>" + ddlEmployee.SelectedItem.Text + "</td></tr>";
            }
            strCapTable += "<tr><td><b>Month : </b>" + ddlMonth.SelectedItem.Text + "</td></tr>";

            strCapTable += "<tr><td><b>Year : </b>" + ddlMonthlyYear.SelectedItem.Text + "</td></tr>";



            
            strCapTable += "</table>";
            sbCap.Append(strCapTable);
            ////write to  divPrintCaption
            divPrintCaption.InnerHtml = sbCap.ToString();
        }
        else if (strSrchMode == "Quarterly")
        {
            StringBuilder sbCap = new StringBuilder();
            string strCapTable = "";
            strCapTable = "<table class=\"PrintCaptionTable\" >";
            strCapTable += "<tr><th class=\"CompanyName\" style=\"text-align: left; word-wrap:break-word;\">" + strCompanyName + "</th><td></td></tr>";
            strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">" + strCompanyAddr + "</th><td></td></tr>";
            strCapTable += "<tr><td><b>Report Date : </b>" + DateTime.Now.ToString("R") + "</td></tr>";
            strCapTable += "<tr><th colspan=\"2\" style=\"text-align: left; word-wrap:break-word;\">Time Sheet Report</th><td></td></tr>";
            if (RadioDivision.Checked == true)
            {
                if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
                {
                    strCapTable += "<tr><td><b>Division : </b>" + ddlDivision.SelectedItem.Text + "</td></tr>";
                }

            }
            else if (RadioDept.Checked == true)
            {
                if (ddlDepartment.SelectedItem.Value != "--SELECT DEPARTMENT--")
                {
                    strCapTable += "<tr><td><b>Department : </b>" + ddlDepartment.SelectedItem.Text + "</td></tr>";
                }
            }
            if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
            {
                strCapTable += "<tr><td><b>Employee : </b>" + ddlEmployee.SelectedItem.Text + "</td></tr>";
            }

            strCapTable += "<tr><td><b>Quarter : </b>" + ddlQuarter.SelectedItem.Text + "</td></tr>";
            strCapTable += "<tr><td><b>Year : </b>" + ddlQuarterlyYear.SelectedItem.Text + "</td></tr>";

            
            strCapTable += "</table>";
            sbCap.Append(strCapTable);
            ////write to  divPrintCaption
            divPrintCaption.InnerHtml = sbCap.ToString();
        }
        else if (strSrchMode == "Yearly")
        {
            StringBuilder sbCap = new StringBuilder();
            string strCapTable = "";
            strCapTable = "<table class=\"PrintCaptionTable\" >";
            strCapTable += "<tr><th class=\"CompanyName\" style=\"text-align: left; word-wrap:break-word;\">" + strCompanyName + "</th><td></td></tr>";
            strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">" + strCompanyAddr + "</th><td></td></tr>";
            strCapTable += "<tr><td><b>Report Date : </b>" + DateTime.Now.ToString("R") + "</td></tr>";
            strCapTable += "<tr><th colspan=\"2\" style=\"text-align: left; word-wrap:break-word;\">Time Sheet Report</th><td></td></tr>";
            if (RadioDivision.Checked == true)
            {
                if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
                {
                    strCapTable += "<tr><td><b>Division : </b>" + ddlDivision.SelectedItem.Text + "</td></tr>";
                }

            }
            else if (RadioDept.Checked == true)
            {
                if (ddlDepartment.SelectedItem.Value != "--SELECT DEPARTMENT--")
                {
                    strCapTable += "<tr><td><b>Department : </b>" + ddlDepartment.SelectedItem.Text + "</td></tr>";
                }
            }
            if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
            {
                strCapTable += "<tr><td><b>Employee : </b>" + ddlEmployee.SelectedItem.Text + "</td></tr>";
            }

            strCapTable += "<tr><td><b>Year : </b>" + ddlYearlyYear.SelectedItem.Text + "</td></tr>";

          
            strCapTable += "</table>";
            sbCap.Append(strCapTable);
            ////write to  divPrintCaption
            divPrintCaption.InnerHtml = sbCap.ToString();
        }
        else if (strSrchMode == "Custom")
        {
            StringBuilder sbCap = new StringBuilder();
            string strCapTable = "";
            strCapTable = "<table class=\"PrintCaptionTable\">";
            strCapTable += "<tr><th class=\"CompanyName\" style=\"text-align: left; word-wrap:break-word;\">" + strCompanyName + "</th><td></td></tr>";
            strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">" + strCompanyAddr + "</th><td></td></tr>";
            strCapTable += "<tr><td><b>Report Date : </b>" + DateTime.Now.ToString("R") + "</td></tr>";
            strCapTable += "<tr><th colspan=\"2\" style=\"text-align: left; word-wrap:break-word;\">Time Sheet Report</th><td></td></tr>";
            if (RadioDivision.Checked == true)
            {
                if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
                {
                    strCapTable += "<tr><td><b>Division : </b>" + ddlDivision.SelectedItem.Text + "</td></tr>";
                }

            }
            else if (RadioDept.Checked == true)
            {
                if (ddlDepartment.SelectedItem.Value != "--SELECT DEPARTMENT--")
                {
                    strCapTable += "<tr><td><b>Department : </b>" + ddlDepartment.SelectedItem.Text + "</td></tr>";
                }
            }
            if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
            {
                strCapTable += "<tr><td><b>Employee : </b>" + ddlEmployee.SelectedItem.Text + "</td></tr>";
            }

            strCapTable += "<tr><td><b>From Date : </b>" + txtFromDate.Text + "</td></tr>";
            strCapTable += "<tr><td><b>To Date : </b>" + txtTodate.Text + "</td></tr>";

           
            strCapTable += "</table>";
            sbCap.Append(strCapTable);
            ////write to  divPrintCaption
            divPrintCaption.InnerHtml = sbCap.ToString();
        }
        else
        {
            StringBuilder sbCap = new StringBuilder();
            string strCapTable = "";
            strCapTable = "<table class=\"PrintCaptionTable\" >";
            strCapTable += "<tr><th class=\"CompanyName\" style=\"text-align: left; word-wrap:break-word;\">" + strCompanyName + "</th><td></td></tr>";
            strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">" + strCompanyAddr + "</th><td></td></tr>";
            strCapTable += "<tr><td><b>Report Date : </b>" + DateTime.Now.ToString("R") + "</td></tr>";
            strCapTable += "<tr><th colspan=\"2\" style=\"text-align: left; word-wrap:break-word;\">Time Sheet Report</th><td></td></tr>";
            if (RadioDivision.Checked == true)
            {
                if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
                {
                    strCapTable += "<tr><td><b>Division : </b>" + ddlDivision.SelectedItem.Text + "</td></tr>";
                }

            }
            else if (RadioDept.Checked == true)
            {
                if (ddlDepartment.SelectedItem.Value != "--SELECT DEPARTMENT--")
                {
                    strCapTable += "<tr><td><b>Department : </b>" + ddlDepartment.SelectedItem.Text + "</td></tr>";
                }
            }
            if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
            {
                strCapTable += "<tr><td><b>Employee : </b>" + ddlEmployee.SelectedItem.Text + "</td></tr>";
            }

            strCapTable += "<tr><td><b>Date : </b>" + txtDate.Text + "</td></tr>";


            
            strCapTable += "</table>";
            sbCap.Append(strCapTable);
            ////write to  divPrintCaption
            divPrintCaption.InnerHtml = sbCap.ToString();
        }
        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\" cellspacing=\"0\" cellpadding=\"2px\">";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            //if (i == 0)
            //{
            //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
            //}
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:22%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            //if (intColumnHeaderCount == 2)
            //{
            //    strHtml += "<th class=\"thT\" style=\"width:22%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            //}
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:13%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 8)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 9)
            {
                strHtml += "<th class=\"thT\"  style=\"width:16%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
        }
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";

        int intMonth = 0, intDay = 0, intQuarter = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            //int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            DateTime dateTemp = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["DATE"].ToString());
            if (strSrchMode == "Monthly")
            {

                if (intDay != dateTemp.Day)
                {
                    strHtml += "<tr  >";
                    strHtml += "<td class=\"tdT\" colspan=\"8\" style=\"font-weight: bold; width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";
                    strHtml += "</tr>";
                    intDay = dateTemp.Day;
                }
            }

            if (strSrchMode == "Quarterly")
            {

                int intTempMonth = dateTemp.Month;
                int intTempQuarter = Convert.ToInt32(SelectQuarter(intTempMonth.ToString()));
                if (intQuarter != intTempQuarter)
                {
                    intQuarter = intTempQuarter;
                    strHtml += "<tr  >";
                    strHtml += "<td class=\"tdT\" colspan=\"8\" style=\"text-transform: uppercase; font-weight: bold; width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >Quarter " + intQuarter + "</td>";
                    strHtml += "</tr>";

                }
                if (intDay != dateTemp.Day)
                {
                    strHtml += "<tr  >";
                    strHtml += "<td class=\"tdT\" colspan=\"8\" style=\" font-weight: bold; width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";
                    strHtml += "</tr>";
                    intDay = dateTemp.Day;
                }
            }
            if (strSrchMode == "Yearly")
            {
                int intTempMonth = dateTemp.Month;
                if (intMonth != intTempMonth)
                {
                    strHtml += "<tr  >";
                    strHtml += "<td class=\"tdT\" colspan=\"8\" style=\"text-transform: uppercase;font-weight: bold; width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dateTemp.ToString("MMMM") + "</td>";
                    strHtml += "</tr>";
                    intMonth = intTempMonth;
                }
                if (intDay != dateTemp.Day)
                {
                    strHtml += "<tr  >";
                    strHtml += "<td class=\"tdT\" colspan=\"8\" style=\" font-weight: bold; width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";
                    strHtml += "</tr>";
                    intDay = dateTemp.Day;
                }
            }
            if (strSrchMode == "Custom")
            {
                if (intDay != dateTemp.Day)
                {
                    strHtml += "<tr  >";
                    strHtml += "<td class=\"tdT\" colspan=\"8\" style=\" font-weight: bold; width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";
                    strHtml += "</tr>";
                    intDay = dateTemp.Day;
                }
            }
            strHtml += "<tr  >";


            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                //if (j == 0)
                //{
                //    int intCnt = i + 1;
                //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                //}


                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                //if (intColumnBodyCount == 2)
                //{
                //    strHtml += "<td class=\"tdT\" style=\" width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                //}
                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 6)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 7)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 8)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 9)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:16%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
            }
            strHtml += "</tr>";
        } if (dt.Rows.Count == 0)
        {
            strHtml += "<tr>";
            strHtml += "<tfooter>";

            strHtml += "<td  class=\"thT\" colspan=\"8\" style=\"font-weight: unset; width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";

            strHtml += "</tfooter>";
            strHtml += "</tr>";
        }
        strHtml += "</tbody>";

        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }

    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        clsBusinessLayerTimeSheetReport objBusinessLayerTimeSheetReport = new clsBusinessLayerTimeSheetReport();
        clsEntityLayerTimeSheetReport objEntityTimeSheetReport = new clsEntityLayerTimeSheetReport();
        DataTable dtEmployees = new DataTable();
        if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
        {
            objEntityTimeSheetReport.DivisionId = Convert.ToInt32(ddlDivision.SelectedItem.Value);

        }
        

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityTimeSheetReport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityTimeSheetReport.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            //BL
            if (Session["USERID"] != null)
            {
                objEntityTimeSheetReport.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            dtEmployees = objBusinessLayerTimeSheetReport.ReadEmployee(objEntityTimeSheetReport);

            ddlEmployee.DataSource = dtEmployees;
            ddlEmployee.DataTextField = "USR_NAME";
            ddlEmployee.DataValueField = "USR_ID";//DSGTYP_ID
            ddlEmployee.DataBind();
            ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");
        

        //DIVISION OR DEPT
        
            hiddenSubSrchMode.Value = "Division";
        
       
        //DAILY MONTHLY YEARLY QUARTERLY CUSTOM
        if (radioDaily.Checked == true)
        {
          
            hiddenSrchMode.Value = "Daily";
        }
        else if (radioMonthly.Checked == true)
        {
           
            hiddenSrchMode.Value = "Monthly";
        }
        else if (radioQuarterly.Checked == true)
        {
          

            hiddenSrchMode.Value = "Quarterly";
        }
        else if (RadioYearly.Checked == true)
        {
          
            hiddenSrchMode.Value = "Yearly";
        }
        else if (RadioCustom.Checked == true)
        {
           
            hiddenSrchMode.Value = "Custom";
        }
        ddlDivision.Focus();
    }
    protected void RadioDept_CheckedChanged(object sender, EventArgs e)
    {
        LoadEmployee();
        //DIVISION OR DEPT
        if (RadioDivision.Checked == true)
        {

            hiddenSubSrchMode.Value = "Division";
        }
        else
        {

            hiddenSubSrchMode.Value = "Dept";

        }
        //DAILY MONTHLY YEARLY QUARTERLY CUSTOM
        if (radioDaily.Checked == true)
        {

            hiddenSrchMode.Value = "Daily";
        }
        else if (radioMonthly.Checked == true)
        {

            hiddenSrchMode.Value = "Monthly";
        }
        else if (radioQuarterly.Checked == true)
        {


            hiddenSrchMode.Value = "Quarterly";
        }
        else if (RadioYearly.Checked == true)
        {

            hiddenSrchMode.Value = "Yearly";
        }
        else if (RadioCustom.Checked == true)
        {

            hiddenSrchMode.Value = "Custom";
        }
        //evm-0023 changed RadioDept button Focus  
        RadioDept.Focus();
    }
    
}