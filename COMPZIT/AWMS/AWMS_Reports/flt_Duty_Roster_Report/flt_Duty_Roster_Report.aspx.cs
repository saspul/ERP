using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusinessLayer_AWMS;
using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using System.Web.UI.WebControls;
using System.Text;
using System.Globalization;
using BL_Compzit.BusinessLayer_GMS;
public partial class AWMS_AWMS_Reports_flt_Duty_Roster_Report_flt_Duty_Roster_Report : System.Web.UI.Page
{
    public class clsDaysList
    {
        public DateTime Date;
        public int intDateType = 0;
        //0- holiday
        //1-Duty off
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

           
            // List<DateTime> MonthlyOffDates = CheckDutyOff(dateCheck);
            EmployeeLoad();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            //Creating objects for business layer
            clsBusinessLayerDutyRosterReports objBusinessDutyRosterReptr = new clsBusinessLayerDutyRosterReports();
            clsEntityLayerDutyRosterReports objEntityDutyRosterReptr = new clsEntityLayerDutyRosterReports();
            List<clsEntityDutyRosterReportEmpselection> objlistEmplyList = new List<clsEntityDutyRosterReportEmpselection>();
            clsEntityReports objEntityReports = new clsEntityReports();
            DateTime dateCheck = new DateTime();
            string strdate = DateTime.Now.ToString("dd/MM/yyyy");
            dateCheck = objCommon.textToDateTime(strdate);
            int intCorpId = 0;

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityDutyRosterReptr.CorprtId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

                objEntityDutyRosterReptr.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objEntityDutyRosterReptr.UserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Request.QueryString != null)
            {
                if (Request.QueryString.Count > 0)
                {
                    //string strRandomMixeddaste = Request.QueryString["fromdate"].ToString();
                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);
                    string frmdate = Request.QueryString["fromdate"].ToString();
                    hiddenDate.Value = frmdate;
                    string todate = Request.QueryString["todate"].ToString();
                    Hiddenstoretodate.Value = todate;                                     
                    objEntityDutyRosterReptr.EmplyId = Convert.ToInt32(strId);

                    if (Request.QueryString["EmpList"] != null)
                    {
                        HiddenFieldBackIn.Value = Request.QueryString["EmpList"].ToString();
                    }

                    HiddenFieldBack.Value = Request.QueryString["Id"].ToString() + "," + Request.QueryString["fromdate"].ToString() + "," + Request.QueryString["todate"].ToString();
                }
            }

            DataTable dtDutyRosterList = objBusinessDutyRosterReptr.ReadDutyRosterReptr(objEntityDutyRosterReptr, objlistEmplyList);
            DataTable dtHoliday = new DataTable();
            dtHoliday = objBusinessDutyRosterReptr.ReadHolidayDate(objEntityDutyRosterReptr);
            string strReport = ConvertDataTableToHTML(dtDutyRosterList, dtHoliday);
            lblEmply.Text = "";
            if (dtDutyRosterList.Rows.Count > 0)
            {
                lblEmply.Text = dtDutyRosterList.Rows[0]["EMPLOYEE NAME"].ToString();
            }
            divReport.InnerHtml = strReport;
            clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();

            DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(objEntityReports);
            // string strPrintReport = ConvertDataTableForPrint(dtDutyRosterList, dtCorp);
            //divPrintReport.InnerHtml = strPrintReport;


        }

    }

    public string ConvertDataTableToHTML(DataTable dt, DataTable dtHoliday)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();

        DateTime datenow, datenext;

        datenext = DateTime.Today;

        //add
        int intHolydatcount = dtHoliday.Rows.Count;
        DateTime dateHoliday = new DateTime();
        if (dtHoliday.Rows.Count > 0)
        {

        }
        //add ends


        // DataTable dtHOLIDAY = new DataTable();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayerDutyRosterReports objBusinessDutyRosterReptr = new clsBusinessLayerDutyRosterReports();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityLayerDutyRosterReports objEntityDutyRosterReptr = new clsEntityLayerDutyRosterReports();

        string strRandom = objCommon.Random_Number();


        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";





        strHtml += "<th class=\"thT\" colspan=\"4\" style=\"width:7%;text-align: left; word-wrap:break-word;text-align:center;\">DATE</th>";
          
        
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";

      
        strHtml += ConvertDate(dt);
        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }

    public void EmployeeLoad()
    {
        clsEntityLayerDutyRosterReports objEntityDutyRosterReptr = new clsEntityLayerDutyRosterReports();
        clsBusinessLayerDutyRosterReports objBusinessDutyRosterReptr = new clsBusinessLayerDutyRosterReports();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityDutyRosterReptr.CorprtId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityDutyRosterReptr.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityDutyRosterReptr.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtEmplyddl = objBusinessDutyRosterReptr.ReadEmployeeDetails(objEntityDutyRosterReptr);

        //if (dtEmplyddl.Rows.Count > 0)
        //{
        //    ddlmodeSearch.DataSource = dtEmplyddl;
        //    ddlmodeSearch.DataTextField = "USR_NAME";
        //    ddlmodeSearch.DataValueField = "USR_ID";
        //    ddlmodeSearch.DataBind();
        //}

    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        List<clsEntityDutyRosterReportEmpselection> objlistEmplyList = new List<clsEntityDutyRosterReportEmpselection>();
        clsEntityLayerDutyRosterReports objEntityDutyRosterReptr = new clsEntityLayerDutyRosterReports();
        clsBusinessLayerDutyRosterReports objBusinessDutyRosterReptr = new clsBusinessLayerDutyRosterReports();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityReports objEntityReports = new clsEntityReports();

        DateTime fromdate, todate;

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntityDutyRosterReptr.CorprtId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

            objEntityDutyRosterReptr.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityDutyRosterReptr.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        //if (hiddenselectedlist.Value == "")
        //{

        //    ddlmodeSearch.SelectedItem.Value = "";
        //    // ddlvechcle.SelectedItem.Text = "";
        //}
        //if (RadioBtnEmply.Checked == true)
        //{
        //    if (ddlmodeSearch.SelectedItem.Value == "")
        //    {
        //        objEntityDutyRosterReptr.EmplyId = 0;
        //    }
        //    else
        //    {

        //        string[] tokens = hiddenselectedlist.Value.Split(',');
        //        //  foreach (ListItem itemCheckBoxModules in cblcandidatelist.Items)
        //        // {
        //        if (tokens.Count() == 1)
        //        {
        //            hiddenSelectdNo.Value = "1";
        //        }
        //        for (int i = 0; i < tokens.Count(); i++)
        //        {

        //            clsEntityDutyRosterReportEmpselection objEntityViolationReportforlist = new clsEntityDutyRosterReportEmpselection();
        //            objEntityViolationReportforlist.EmpSelectionId = Convert.ToInt32(tokens[i]);
        //            objEntityViolationReportforlist.DateSelection = 0;
        //            objlistEmplyList.Add(objEntityViolationReportforlist);

        //        }


        //    }



        //    if (txtFromDate.Text != "")
        //    {
        //        string ans = txtFromDate.Text;
        //        ans = String.Format("{0:dd-MM-yyyy}", ans);
        //        fromdate = objCommon.textToDateTime(ans);
        //        objEntityDutyRosterReptr.dateFromDate = fromdate;
        //    }
        //    if (txtToDate.Text != "")
        //    {txtFromDate.Text
        //        todate = objCommon.textToDateTime(txtToDate.Text);
        //        objEntityDutyRosterReptr.dateToDate = todate;
        //    }

        //}

        //else if (RadioBtnDate.Checked == true)
        //{
        //    clsEntityDutyRosterReportEmpselection objEntityViolationReportforlist = new clsEntityDutyRosterReportEmpselection();
        //    objlistEmplyList.Add(objEntityViolationReportforlist);
        //    // clsEntityDutyRosterReportEmpselection objEntityViolationReportforlist = new clsEntityDutyRosterReportEmpselection();
        //    // objEntityViolationReportforlist.DateSelection = objCommon.textToDateTime(txtFromDate.Text);
        //    // objEntityViolationReportforlist.DateSelection = objCommon.textToDateTime(txtToDate.Text);
        //    //objlistEmplyList.Add(objEntityViolationReportforlist);


        //    fromdate = objCommon.textToDateTime(txtFromDate.Text);
        //    objEntityDutyRosterReptr.dateFromDate = fromdate;
        //    todate = objCommon.textToDateTime(txtToDate.Text);
        //    objEntityDutyRosterReptr.dateToDate = todate;


        //}
        DataTable dtEmplyddl = objBusinessDutyRosterReptr.ReadDutyRosterReptr(objEntityDutyRosterReptr, objlistEmplyList);
        if (dtEmplyddl.Rows.Count > 0)
        {
            objEntityDutyRosterReptr.dateToDate = objCommon.textToDateTime(dtEmplyddl.Rows[0]["DATE"].ToString());
            objEntityDutyRosterReptr.dateFromDate = objCommon.textToDateTime(dtEmplyddl.Rows[dtEmplyddl.Rows.Count - 1]["DATE"].ToString());
        }
        DataTable dtHoliday = objBusinessDutyRosterReptr.ReadHolidayDate(objEntityDutyRosterReptr);
        clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();

        string strReport = ConvertDataTableToHTML(dtEmplyddl, dtHoliday);
        divReport.InnerHtml = strReport;
        DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(objEntityReports);

        //  string strPrintReport = ConvertDataTableForPrint(dtEmplyddl, dtCorp);
        //  divPrintReport.InnerHtml = strPrintReport;

    }
    public string checkholiday(DateTime day, DateTime datenow, DateTime enddate)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityLayerDutyRosterReports objEntityDutyRosterReptr = new clsEntityLayerDutyRosterReports();
        clsBusinessLayerDutyRosterReports objBusinessDutyRosterReptr = new clsBusinessLayerDutyRosterReports();
        DateTime fromdate, todate;
        //fromdate = objCommon.textToDateTime(txtFromDate.Text);
        objEntityDutyRosterReptr.dateFromDate = datenow;
        //todate = objCommon.textToDateTime(txtToDate.Text);
        objEntityDutyRosterReptr.dateToDate = enddate;
        DataTable dtHoliday = objBusinessDutyRosterReptr.ReadHolidayDate(objEntityDutyRosterReptr);


        string HoliName = "", Holi1 = "false";
        foreach (DataRow RowHoli in dtHoliday.Rows)
        {
            string ans;
            ans = day.ToString("dd-MM-yyyy");
            ans = String.Format("{0:dd-MM-yyyy}", ans);
            fromdate = objCommon.textToDateTime(ans);
            if (RowHoli["HLDAYMSTR_DATE"].ToString() != "")
            {
                if (objCommon.textToDateTime(RowHoli["HLDAYMSTR_DATE"].ToString()) == fromdate)
                {
                    HoliName = RowHoli["HLDAYMSTR_DATE"].ToString();
                    Holi1 = "true";
                    //return Holi1;
                }
            }
        }
        return Holi1;
    }
    public string checkleave(DateTime day, DateTime datenow, DateTime enddate, string USR_ID)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityLayerDutyRoster objEntityDutyRoster = new clsEntityLayerDutyRoster();
        clsBusinessLayerDutyRoster objBusinessDutyRoster = new clsBusinessLayerDutyRoster();
        objEntityDutyRoster.EmployeeId = Convert.ToInt32(USR_ID);
        objEntityDutyRoster.FromDate = datenow;
        objEntityDutyRoster.ToDate = enddate;
        DataTable dtEmployeLeaveDtl = objBusinessDutyRoster.ReadLeaveDtlByEmp(objEntityDutyRoster);
        DataTable dtEmployeeSingle_Leave = objBusinessDutyRoster.ReadSingleLeaveDtlByEmp(objEntityDutyRoster);

        string leave1 = "false";
        string halfday1 = "false";
        int section1 = 1;
        foreach (DataRow Rows in dtEmployeLeaveDtl.Rows)
        {
            DateTime Start = new DateTime();
            DateTime End = new DateTime();
            if (Rows[2].ToString() == "1")
            {
                Start = objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString());
            }
            else
            {
                Start = objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()).AddDays(1);
                if (objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()) == day)
                {
                    halfday1 = "true";
                    section1 = Convert.ToInt32(Rows[2].ToString());
                }

            }

            if (Rows[4].ToString() == "1")
            {
                End = objCommon.textToDateTime(Rows["LEAVE_TO_DATE"].ToString());
            }
            else
            {
                End = objCommon.textToDateTime(Rows["LEAVE_TO_DATE"].ToString()).AddDays(-1);
                if (objCommon.textToDateTime(Rows["LEAVE_TO_DATE"].ToString()) == day)
                {
                    halfday1 = "true";
                    section1 = Convert.ToInt32(Rows[4].ToString());
                }
            }


            if (Start <= day && End >= day)
            {
                leave1 = "true";
                break;
            }
        }

        foreach (DataRow Rows in dtEmployeeSingle_Leave.Rows)
        {
            if (Rows[2].ToString() == "1")
            {
                if (objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()) == day)
                {
                    leave1 = "true";
                    break;
                }
            }
            else
            {
                if (objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()) == day)
                {
                    halfday1 = "true";
                    section1 = Convert.ToInt32(Rows[2].ToString());

                }

            }
        }


        return leave1;

    }
    public string ConvertDataTableForPrint(DataTable dt, DataTable dtcorp)
    {
        DateTime datenow, datenext;
        DateTime datetm = DateTime.Now;
        datenext = DateTime.Today;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        int intCurrentQtr = 0, intMonthQtr = 0, intPrevQtr = 0, intIncrmntQtr = 1, intQtrRowCounter = 0;
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        decimal decQtrTotal = 0;
        string[] strArrQtr = new string[5];
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strRandom = objCommon.Random_Number();

        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayerDutyRosterReports objBusinessDutyRosterReptr = new clsBusinessLayerDutyRosterReports();
        clsEntityLayerDutyRosterReports objEntityDutyRosterReptr = new clsEntityLayerDutyRosterReports();
        List<clsEntityDutyRosterReportEmpselection> objlistEmplyList = new List<clsEntityDutyRosterReportEmpselection>();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityDutyRosterReptr.CorprtId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityDutyRosterReptr.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //  DataTable dtcorp = objBusinessDutyRosterReptr.ReadDutyRosterReptr(objEntityDutyRosterReptr, objlistEmplyList);
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

        StringBuilder sbCap = new StringBuilder();
        string strCapTable = "";
        strCapTable = "<table class=\"PrintCaptionTable\" >";
        strCapTable += "<tr><th class=\"CompanyName\" style=\"text-align: left; word-wrap:break-word;\">" + strCompanyName + "</th><td></td></tr>";
        strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">" + strCompanyAddr + "</th><td></td></tr>";
        strCapTable += "<tr><td><b>Report Date : </b>" + DateTime.Now.ToString("R") + "</td></tr>";

        //if (RadioBtnDate.Checked == true)
        //{
        //    strCapTable += "<tr><td><b>To Date : </b>" + txtFromDate.Text + "</td></tr>";
        //    strCapTable += "<tr><td><b>To Date : </b>" + txtToDate.Text + "</td></tr>";
        strCapTable += "<tr><th colspan=\"2\" style=\"text-align: left; word-wrap:break-word;\">Report</th><td></td></tr>";
        strCapTable += "</table>";
        sbCap.Append(strCapTable);

        // }
        //if (RadioBtnEmply.Checked == true)
        // {
        if (dt.Rows.Count == 0)
        {


            //strCapTable += "<tr><td><b>Employee : </b>" + Hiddenselectedtext.Value + "</td></tr>";


            strCapTable += "<tr><td><b>From Date : </b>" + "" + "</td></tr>";


            strCapTable += "<tr><td><b>To Date : </b>" + "" + "</td></tr>";


        }
        //else
        //{
        //    strCapTable += "<tr><td><b>Employee : </b>" + Hiddenselectedtext.Value + "</td></tr>";


        //    strCapTable += "<tr><td><b>From Date : </b>" + txtFromDate.Text + "</td></tr>";


        //    strCapTable += "<tr><td><b>To Date : </b>" + txtToDate.Text + "</td></tr>";

        //    ////write to  divPrintCaption
        //}
        strCapTable += "<tr><th colspan=\"2\" style=\"text-align: left; word-wrap:break-word;\">Report</th><td></td></tr>";
        strCapTable += "</table>";
        sbCap.Append(strCapTable);

        //}

        //    clsEntityCommon objEntityCommon = new clsEntityCommon();

        //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();


        //clsCommonLibrary objCommon = new clsCommonLibrary();
        //string strRandom = objCommon.Random_Number();
        divPrintCaption.InnerHtml = sbCap.ToString();


        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";

        string tempvehcle = "", tempvehcle2 = "";
        string tempemply = "", tempemply2 = "";
        if (dt.Rows.Count > 0)
        {

            for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
            {
                //if (intColumnHeaderCount == 0)
                //{
                //    strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                //}
                //if (hiddenSelectdNo.Value != "1")
                //{
                //if (RadioBtnDate.Checked == true)
                //{
                if (intColumnHeaderCount == 1)
                {
                    strHtml += "<th class=\"thT\" style=\"width:7%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";

                }
                // }
                // if (RadioBtnEmply.Checked == true)
                //{
                if (intColumnHeaderCount == 2)
                {
                    strHtml += "<th class=\"thT\" style=\"width:11%;text-align: center; word-wrap:break-word;text-align:center;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                //}
                // }
                else
                {
                    //if (RadioBtnDate.Checked == true)
                    //{
                    if (intColumnHeaderCount == 1)
                    {
                        strHtml += "<th class=\"thT\" style=\"width:7%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";

                    }
                    //}
                    //if (RadioBtnEmply.Checked == true)
                    //{
                    if (intColumnHeaderCount == 2)
                    {
                        strHtml += "<th class=\"thT\" style=\"width:11%;text-align: center; word-wrap:break-word;text-align:center;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                    }
                    // }
                }


                if (intColumnHeaderCount == 3)
                {
                    strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 4)
                {
                    strHtml += "<th  class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word; text-align:center;\">TIME RANGE</th>";
                }
                //if (intColumnHeaderCount == 5)
                //{
                //    strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                //}


            }
        }
        else
        {


            strHtml += "<th class=\"thT\" style=\"width:7%;text-align: left; word-wrap:break-word;text-align:center;\">DATE</th>";

            strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">TIME SLOT NAME</th>";

            strHtml += "<th  class=\"thT\"  style=\"width:15%;text-align: left; text-align:center; word-wrap:break-word;\">TIME RANGE</th>";
            strHtml += "<tr>";
            strHtml += "<tfooter>";

            strHtml += "<td  class=\"thT\" colspan=\"3\" style=\"font-weight: unset; background: #dbd8d8;border-right: navajowhite;width:6%;word-break: break-all; height:35px; word-wrap:break-word;text-align: center;\" >No data available</td>";

            strHtml += "</tfooter>";
            strHtml += "</tr>";
        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        //for (var day = datenow; day <= datenext; day = day.AddDays(1))
        //{
        //     int flag = 0;
        //    int i = 0, j = 0; ;
        //    string HoliName = "";
        //    string Holi1 = "false";

        //        Holi1 = "false";
        //        foreach (DataRow RowHoli in dtHoliday.Rows)
        //        {
        //            if (objCommon.textToDateTime(RowHoli["HLDAYMSTR_DATE"].ToString()) == day)
        //            {
        //                HoliName = RowHoli["HLDAYMSTR_DATE"].ToString();
        //                Holi1 = "true";
        //            }
        //        }

        //  for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        //{
        //    //int id = Convert.ToInt32( dt.Rows[intRowBodyCount][6].ToString());
        //    string strId = dt.Rows[intRowBodyCount][0].ToString();
        //    int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
        //    string stridLength = intIdLength.ToString("00");
        //    string Id = stridLength + strId + strRandom;

        //    // int id = Convert.ToInt32(Id);

        //    //if (Holi1 == "true")
        //    //{
        //    //    strHtml += "<tr  >";
        //    //    flag = 1;
        //    //    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" colspan=\"4\" >" + dtHoliday.Rows[i][0].ToString() + "Holiday</td>";

        //    //    strHtml += "</tr>";
        //    //    break;
        //    //}
        //    //else
        //    //{
        //    //for (var day = datenow; day <= datenext; day = day.AddDays(1))
        //    //{
        //    //   if(dt.Rows[intRowBodyCount]["DATE"].ToString()== day)
        //    //       break;
        //    //  string hol=  checkholiday(day);
        //    //    if(hol=="true")
        //    //    {
        //    //        strHtml += "<tr  >";
        //    ////    flag = 1;
        //    //   strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" colspan=\"4\" >" + dtHoliday.Rows[i][0].ToString() + "Holiday</td>";

        //    // strHtml += "</tr>";
        //    ////    break;
        //    //    }
        //    //}

        //    //}
        //    tempemply2 = tempemply;
        //    tempvehcle2 = tempvehcle;
        //    tempemply = dt.Rows[intRowBodyCount][1].ToString();



        //    tempvehcle = dt.Rows[intRowBodyCount][2].ToString();
        //    if (tempemply2 != tempemply)
        //    {
        //        if (RadioBtnEmply.Checked == true)
        //        {
        //            strHtml += "<tr style=\"background:#dadada;text-align: center;\" >";
        //            strHtml += "<td class=\"thT\"colspan=3 \"style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][1].ToString() + "</td>";

        //            strHtml += "</tr>";
        //            datenext = DateTime.Today;
        //        }

        //    }
        //    if (tempvehcle2 != tempvehcle)
        //    {
        //        if (RadioBtnDate.Checked == true)
        //        {
        //            strHtml += "<tr style=\"background:#dadada;text-align: center;\" >";
        //            strHtml += "<td class=\"thT\"colspan=3 \"style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align:center;\" >" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";

        //            strHtml += "</tr>";
        //            datenext = DateTime.Today;
        //        }

        //    }
        //    strHtml += "<tr  >";

        //    datenow = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["DATE"].ToString());
        //    int flag = 0;
        //    DateTime enddate = objCommon.textToDateTime(dt.Rows[dt.Rows.Count - 1]["DATE"].ToString());
        //    if (datenext != datenow && datenext != DateTime.Today)
        //    {
        //        int diff = Convert.ToInt32((datenext - datenow).TotalDays);
        //        for (int i = 0; i < Math.Abs(diff); i++)
        //        {
        //            if (checkholiday(datenext, datenow, enddate) == "true")
        //            {
        //                strHtml += "<td class=\"thT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: center;\" colspan=\"3\" >" + datenext.ToString("dd-MM-yyyy") + "      Holiday</td>";

        //                strHtml += "</tr>";


        //            }
        //            else if (checkleave(datenext, datenow, enddate) == "true")
        //            {
        //                strHtml += "<td class=\"thT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: center;\" colspan=\"3\" >" + datenext.ToString("dd-MM-yyyy") + "      Leave</td>";

        //                strHtml += "</tr>";


        //            }
        //            else
        //            {
        //                strHtml += "<td class=\"thT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: center;\" colspan=\"3\" >" + datenext.ToString("dd-MM-yyyy") + "        Duty Off</td>";

        //                strHtml += "</tr>";
        //            }
        //            datenext = datenext.AddDays(1);
        //            if (datenext == datenow)
        //            {
        //                flag = 1;
        //                break;
        //            }
        //        }

        //    }
        //    else
        //    {
        //        datenext = datenow.AddDays(1);



        //        for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
        //        {
        //            //if (intColumnBodyCount == 0)
        //            //{
        //            //    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";


        //            if (hiddenSelectdNo.Value != "1")
        //            {
        //                if (RadioBtnDate.Checked == true)
        //                {
        //                    if (intColumnBodyCount == 1)
        //                    {
        //                        strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + " <a title=\"Job Details\" onclick='return getdetails(this.href);' " +
        //                          " href=\"flt_Duty_Roster_Report_Details.aspx?Id=" + Id + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a></td>";

        //                    }

        //                }
        //                if (RadioBtnEmply.Checked == true)
        //                {

        //                    if (intColumnBodyCount == 2)
        //                    {
        //                        strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + " <a  title=\"Job Details\" onclick='return getdetails(this.href);' " +
        //                          " href=\"flt_Duty_Roster_Report_Details.aspx?Id=" + Id + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
        //                    }
        //                }
        //            }

        //            else
        //            {
        //                if (RadioBtnDate.Checked == true)
        //                {
        //                    if (intColumnBodyCount == 1)
        //                    {
        //                        strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + " <a  title=\"Job Details\" onclick='return getdetails(this.href);' " +
        //                          " href=\"flt_Duty_Roster_Report_Details.aspx?Id=" + Id + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a></td>";
        //                    }
        //                }
        //                if (RadioBtnEmply.Checked == true)
        //                {
        //                    if (intColumnBodyCount == 2)
        //                    {
        //                        strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + " <a  title=\"Job Details\" onclick='return getdetails(this.href);' " +
        //                          " href=\"flt_Duty_Roster_Report_Details.aspx?Id=" + Id + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
        //                    }
        //                }
        //            }
        //            if (intColumnBodyCount == 3)
        //            {
        //                strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
        //            }
        //            if (intColumnBodyCount == 4)
        //            {
        //                strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + " - " + dt.Rows[intRowBodyCount][5].ToString() + "</td>";
        //                //strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" ++ "</td>";
        //            }

        //            //if (intColumnBodyCount == 5)
        //            //{
        //            //    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
        //            //}


        //        }



        //        strHtml += "</tr>";





        //    }


        //    if (flag == 1)
        //    {
        //        datenext = datenow.AddDays(1);



        //        for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
        //        {
        //            //if (intColumnBodyCount == 0)
        //            //{
        //            //    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
        //            //}


        //            if (hiddenSelectdNo.Value != "1")
        //            {
        //                if (RadioBtnDate.Checked == true)
        //                {
        //                    if (intColumnBodyCount == 1)
        //                    {
        //                        strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + " <a title=\"Job Details\" onclick='return getdetails(this.href);' " +
        //                          " href=\"flt_Duty_Roster_Report_Details.aspx?Id=" + Id + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a></td>";

        //                    }

        //                }
        //                if (RadioBtnEmply.Checked == true)
        //                {

        //                    if (intColumnBodyCount == 2)
        //                    {
        //                        strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + " <a title=\"Job Details\" onclick='return getdetails(this.href);' " +
        //                          " href=\"flt_Duty_Roster_Report_Details.aspx?Id=" + Id + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
        //                    }
        //                }
        //            }

        //            else
        //            {
        //                if (RadioBtnDate.Checked == true)
        //                {
        //                    if (intColumnBodyCount == 1)
        //                    {
        //                        strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + " <a title=\"Job Details\" onclick='return getdetails(this.href);' " +
        //                          " href=\"flt_Duty_Roster_Report_Details.aspx?Id=" + Id + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a></td>";
        //                    }
        //                }
        //                if (RadioBtnEmply.Checked == true)
        //                {
        //                    if (intColumnBodyCount == 2)
        //                    {
        //                        strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + " <a title=\"Job Details\" onclick='return getdetails(this.href);' " +
        //                          " href=\"flt_Duty_Roster_Report_Details.aspx?Id=" + Id + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
        //                    }
        //                }
        //            }
        //            if (intColumnBodyCount == 3)
        //            {
        //                strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
        //            }
        //            if (intColumnBodyCount == 4)
        //            {
        //                strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + " - " + dt.Rows[intRowBodyCount][5].ToString() + "</td>";
        //                //strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" ++ "</td>";
        //            }

        //            //if (intColumnBodyCount == 5)
        //            //{
        //            //    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
        //            //}


        //        }



        //        strHtml += "</tr>";




        //    }
        //}
        strHtml += ConvertDate(dt);
        strHtml += "</tbody>";

        strHtml += "</table>";





        sb.Append(strHtml);
        return sb.ToString();
    }

    public string CheckDutyOff(DateTime dateCheck)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerDutyRoster objEntityDutyRoster = new clsEntityLayerDutyRoster();
        clsBusinessLayerDutyRoster objBusinessDutyRoster = new clsBusinessLayerDutyRoster();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityDutyRoster.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityDutyRoster.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
      



        //FOR READING DUTY OFF
        DataTable dtDutyOffWeekly = objBusinessDutyRoster.ReadWeeklyDutyOff(objEntityDutyRoster);
        string strJbWklyOffDay = "";
        if (dtDutyOffWeekly.Rows.Count > 0)
        {
            string DutyOffDays = dtDutyOffWeekly.Rows[0]["WK_OFFDUTYDTL_DAYS"].ToString();
            string[] DutyOffDay = DutyOffDays.Split(',');
            foreach (string DutyOfwk in DutyOffDay)
            {
                switch (DutyOfwk)
                {
                    case "1":
                        strJbWklyOffDay += "Sunday";
                        break;
                    case "2":
                        strJbWklyOffDay += "Monday";
                        break;
                    case "3":
                        strJbWklyOffDay += "Tuesday";
                        break;
                    case "4":
                        strJbWklyOffDay += "Wednesday";
                        break;
                    case "5":
                        strJbWklyOffDay += "Thursday";
                        break;
                    case "6":
                        strJbWklyOffDay += "Friday";
                        break;
                    case "7":
                        strJbWklyOffDay += "Saturday";
                        break;

                }
            }
        }

        List<DateTime> MonthlyOffDates = new List<DateTime>();

        //for date and month section
        string strTodayDate = DateTime.Now.ToString("dd/MM/yyyy");

        DateTime DateTodayDate = new DateTime();
        DateTodayDate = objCommon.textToDateTime(strTodayDate);

        DateTime now = new DateTime();
        now = objCommon.textToDateTime(hiddenDate.Value);





        DataTable dtDutyOffMonthly = objBusinessDutyRoster.ReadMonthlyDutyOff(objEntityDutyRoster);
        if (dtDutyOffMonthly.Rows.Count > 0)
        {


            DateTime leaveDate = new DateTime();


            //Start:-EMP-0009
            DateTime now1 = new DateTime();
            now1 = objCommon.textToDateTime(Hiddenstoretodate.Value);

            foreach (DataRow Rowd in dtDutyOffMonthly.Rows)
            {
                if (Rowd["OFFDUTYDTL_DAYS"].ToString() != "")
                {
                    int firstdate = 0;


                    //First two
                    if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "2")
                    {
                        for (int i = 0; i <= 1; i++)
                        {
                            if (i == 0)
                            {
                                firstdate = 1;
                            }
                            else if (i == 1)
                            {
                                firstdate = 8;
                            }


                            string DaysStr = Rowd["OFFDUTYDTL_DAYS"].ToString();
                            string[] spitDayStr = DaysStr.Split(',');
                            foreach (string strSpliSlice in spitDayStr)
                            {
                                if (strSpliSlice != "")
                                {
                                    switch (strSpliSlice)
                                    {
                                        case "2":
                                            DateTime FirstMonday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < 7; count++)
                                            {
                                                if (FirstMonday.DayOfWeek == DayOfWeek.Monday)
                                                {
                                                    leaveDate = FirstMonday;
                                                    if (leaveDate != DateTime.MinValue)
                                                    {
                                                        MonthlyOffDates.Add(leaveDate);
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstMonday = FirstMonday.AddDays(1);
                                                }
                                            }

                                            if (now.Month < now1.Month || now.Year < now1.Year)
                                            {
                                                FirstMonday = new DateTime(now1.Year, now1.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstMonday.DayOfWeek == DayOfWeek.Monday)
                                                    {
                                                        leaveDate = FirstMonday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstMonday = FirstMonday.AddDays(1);
                                                    }
                                                }

                                            }


                                            break;
                                        case "3":
                                            DateTime FirstTuesday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < 7; count++)
                                            {
                                                if (FirstTuesday.DayOfWeek == DayOfWeek.Tuesday)
                                                {

                                                    leaveDate = FirstTuesday;
                                                    if (leaveDate != DateTime.MinValue)
                                                    {
                                                        MonthlyOffDates.Add(leaveDate);
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstTuesday = FirstTuesday.AddDays(1);
                                                }
                                            }
                                            if (now.Month < now1.Month || now.Year < now1.Year)
                                            {

                                                FirstTuesday = new DateTime(now1.Year, now1.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstTuesday.DayOfWeek == DayOfWeek.Tuesday)
                                                    {

                                                        leaveDate = FirstTuesday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstTuesday = FirstTuesday.AddDays(1);
                                                    }
                                                }
                                            }
                                            break;
                                        case "4":
                                            DateTime FirstWednesday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < 7; count++)
                                            {
                                                if (FirstWednesday.DayOfWeek == DayOfWeek.Wednesday)
                                                {
                                                    leaveDate = FirstWednesday;
                                                    if (leaveDate != DateTime.MinValue)
                                                    {
                                                        MonthlyOffDates.Add(leaveDate);
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstWednesday = FirstWednesday.AddDays(1);
                                                }
                                            }

                                            if (now.Month < now1.Month || now.Year < now1.Year)
                                            {
                                                FirstWednesday = new DateTime(now1.Year, now1.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstWednesday.DayOfWeek == DayOfWeek.Wednesday)
                                                    {
                                                        leaveDate = FirstWednesday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstWednesday = FirstWednesday.AddDays(1);
                                                    }
                                                }
                                            }
                                            break;
                                        case "5":
                                            DateTime FirstThursday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < 7; count++)
                                            {
                                                if (FirstThursday.DayOfWeek == DayOfWeek.Thursday)
                                                {
                                                    leaveDate = FirstThursday;
                                                    if (leaveDate != DateTime.MinValue)
                                                    {
                                                        MonthlyOffDates.Add(leaveDate);
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstThursday = FirstThursday.AddDays(1);
                                                }
                                            }
                                            if (now.Month < now1.Month || now.Year < now1.Year)
                                            {
                                                FirstThursday = new DateTime(now1.Year, now1.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstThursday.DayOfWeek == DayOfWeek.Thursday)
                                                    {
                                                        leaveDate = FirstThursday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstThursday = FirstThursday.AddDays(1);
                                                    }
                                                }
                                            }
                                            break;
                                        case "6":
                                            DateTime FirstFriday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < 7; count++)
                                            {
                                                if (FirstFriday.DayOfWeek == DayOfWeek.Friday)
                                                {
                                                    leaveDate = FirstFriday;
                                                    if (leaveDate != DateTime.MinValue)
                                                    {
                                                        MonthlyOffDates.Add(leaveDate);
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstFriday = FirstFriday.AddDays(1);
                                                }
                                            }

                                            if (now.Month < now1.Month || now.Year < now1.Year)
                                            {
                                                FirstFriday = new DateTime(now1.Year, now1.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstFriday.DayOfWeek == DayOfWeek.Friday)
                                                    {
                                                        leaveDate = FirstFriday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstFriday = FirstFriday.AddDays(1);
                                                    }
                                                }
                                            }
                                            break;
                                        case "7":
                                            DateTime FirstSaturday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < 7; count++)
                                            {
                                                if (FirstSaturday.DayOfWeek == DayOfWeek.Saturday)
                                                {
                                                    leaveDate = FirstSaturday;
                                                    if (leaveDate != DateTime.MinValue)
                                                    {
                                                        MonthlyOffDates.Add(leaveDate);
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstSaturday = FirstSaturday.AddDays(1);
                                                }
                                            }


                                            if (now.Month < now1.Month || now.Year < now1.Year)
                                            {

                                                FirstSaturday = new DateTime(now1.Year, now1.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstSaturday.DayOfWeek == DayOfWeek.Saturday)
                                                    {
                                                        leaveDate = FirstSaturday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstSaturday = FirstSaturday.AddDays(1);
                                                    }
                                                }

                                            }

                                            break;
                                        case "1":
                                            DateTime FirstSunday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < 7; count++)
                                            {
                                                if (FirstSunday.DayOfWeek == DayOfWeek.Sunday)
                                                {
                                                    leaveDate = FirstSunday;
                                                    if (leaveDate != DateTime.MinValue)
                                                    {
                                                        MonthlyOffDates.Add(leaveDate);
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstSunday = FirstSunday.AddDays(1);
                                                }
                                            }

                                            if (now.Month < now1.Month || now.Year < now1.Year)
                                            {
                                                FirstSunday = new DateTime(now1.Year, now1.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstSunday.DayOfWeek == DayOfWeek.Sunday)
                                                    {
                                                        leaveDate = FirstSunday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstSunday = FirstSunday.AddDays(1);
                                                    }
                                                }
                                            }
                                            break;
                                    }
                                }

                            }
                        }

                    }


                    //Last two

                    if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "3")
                    {


                        for (int i = 0; i <= 1; i++)
                        {
                            if (i == 0)
                            {
                                firstdate = DateTime.DaysInMonth(now.Year, now.Month);
                            }
                            else if (i == 1)
                            {
                                firstdate = DateTime.DaysInMonth(now.Year, now.Month) - 7;
                            }


                            string DaysStr = Rowd["OFFDUTYDTL_DAYS"].ToString();
                            string[] spitDayStr = DaysStr.Split(',');
                            foreach (string strSpliSlice in spitDayStr)
                            {
                                if (strSpliSlice != "")
                                {
                                    switch (strSpliSlice)
                                    {
                                        case "2":
                                            DateTime FirstMonday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < 7; count++)
                                            {
                                                if (FirstMonday.DayOfWeek == DayOfWeek.Monday)
                                                {
                                                    leaveDate = FirstMonday;
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstMonday = FirstMonday.AddDays(-1);
                                                }
                                            }
                                            break;
                                        case "3":
                                            DateTime FirstTuesday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < 7; count++)
                                            {
                                                if (FirstTuesday.DayOfWeek == DayOfWeek.Tuesday)
                                                {

                                                    leaveDate = FirstTuesday;
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstTuesday = FirstTuesday.AddDays(-1);
                                                }
                                            }
                                            break;
                                        case "4":
                                            DateTime FirstWednesday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < 7; count++)
                                            {
                                                if (FirstWednesday.DayOfWeek == DayOfWeek.Wednesday)
                                                {
                                                    leaveDate = FirstWednesday;
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstWednesday = FirstWednesday.AddDays(-1);
                                                }
                                            }
                                            break;
                                        case "5":
                                            DateTime FirstThursday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < 7; count++)
                                            {
                                                if (FirstThursday.DayOfWeek == DayOfWeek.Thursday)
                                                {
                                                    leaveDate = FirstThursday;
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstThursday = FirstThursday.AddDays(-1);
                                                }
                                            }
                                            break;
                                        case "6":
                                            DateTime FirstFriday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < 7; count++)
                                            {
                                                if (FirstFriday.DayOfWeek == DayOfWeek.Friday)
                                                {
                                                    leaveDate = FirstFriday;
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstFriday = FirstFriday.AddDays(-1);
                                                }
                                            }
                                            break;
                                        case "7":
                                            DateTime FirstSaturday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < 7; count++)
                                            {
                                                if (FirstSaturday.DayOfWeek == DayOfWeek.Saturday)
                                                {
                                                    leaveDate = FirstSaturday;
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstSaturday = FirstSaturday.AddDays(-1);
                                                }
                                            }
                                            break;
                                        case "1":
                                            DateTime FirstSunday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < 7; count++)
                                            {
                                                if (FirstSunday.DayOfWeek == DayOfWeek.Sunday)
                                                {
                                                    leaveDate = FirstSunday;
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstSunday = FirstSunday.AddDays(-1);
                                                }
                                            }
                                            break;
                                    }
                                }
                                if (leaveDate != DateTime.MinValue)
                                {
                                    MonthlyOffDates.Add(leaveDate);
                                }
                            }
                        }

                    }








                }
            }


            //End:EMP-0009



            foreach (DataRow Rowd in dtDutyOffMonthly.Rows)
            {
                if (Rowd["OFFDUTYDTL_DAYS"].ToString() != "")
                {
                    int firstdate = 0;

                    if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "1")
                    {
                        for (int i = 0; i <= 2; i++)
                        {
                            if (i == 0)
                            {
                                firstdate = 1;
                            }
                            else if (i == 1)
                            {
                                firstdate = 15;
                            }
                            else if (i == 2)
                            {
                                firstdate = 29;
                            }

                            string DaysStr = Rowd["OFFDUTYDTL_DAYS"].ToString();
                            string[] spitDayStr = DaysStr.Split(',');
                            foreach (string strSpliSlice in spitDayStr)
                            {
                                if (strSpliSlice != "")
                                {
                                    switch (strSpliSlice)
                                    {
                                        case "2":
                                            DateTime FirstMonday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < 7; count++)
                                            {
                                                if (FirstMonday.DayOfWeek == DayOfWeek.Monday)
                                                {
                                                    leaveDate = FirstMonday;
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstMonday = FirstMonday.AddDays(1);
                                                }
                                            }
                                            break;
                                        case "3":
                                            DateTime FirstTuesday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < 7; count++)
                                            {
                                                if (FirstTuesday.DayOfWeek == DayOfWeek.Tuesday)
                                                {

                                                    leaveDate = FirstTuesday;
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstTuesday = FirstTuesday.AddDays(1);
                                                }
                                            }
                                            break;
                                        case "4":
                                            DateTime FirstWednesday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < 7; count++)
                                            {
                                                if (FirstWednesday.DayOfWeek == DayOfWeek.Wednesday)
                                                {
                                                    leaveDate = FirstWednesday;
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstWednesday = FirstWednesday.AddDays(1);
                                                }
                                            }
                                            break;
                                        case "5":
                                            DateTime FirstThursday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < 7; count++)
                                            {
                                                if (FirstThursday.DayOfWeek == DayOfWeek.Thursday)
                                                {
                                                    leaveDate = FirstThursday;
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstThursday = FirstThursday.AddDays(1);
                                                }
                                            }
                                            break;
                                        case "6":
                                            DateTime FirstFriday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < 7; count++)
                                            {
                                                if (FirstFriday.DayOfWeek == DayOfWeek.Friday)
                                                {
                                                    leaveDate = FirstFriday;
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstFriday = FirstFriday.AddDays(1);
                                                }
                                            }
                                            break;
                                        case "7":
                                            DateTime FirstSaturday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < 7; count++)
                                            {
                                                if (FirstSaturday.DayOfWeek == DayOfWeek.Saturday)
                                                {
                                                    leaveDate = FirstSaturday;
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstSaturday = FirstSaturday.AddDays(1);
                                                }
                                            }
                                            break;
                                        case "1":
                                            DateTime FirstSunday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < 7; count++)
                                            {
                                                if (FirstSunday.DayOfWeek == DayOfWeek.Sunday)
                                                {
                                                    leaveDate = FirstSunday;
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstSunday = FirstSunday.AddDays(1);
                                                }
                                            }
                                            break;
                                    }
                                }
                                if (leaveDate != DateTime.MinValue)
                                {
                                    MonthlyOffDates.Add(leaveDate);
                                }
                            }
                        }

                    }


                    if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "4" || Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "5" || Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "6" || Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "7" || Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "8")
                    {
                        int lastWeekDays = DateTime.DaysInMonth(now.Year, now.Month);
                        lastWeekDays = lastWeekDays - 28;
                        int limit = 7;

                        for (int i = 0; i < 1; i++)
                        {
                            if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "4")
                            {
                                firstdate = 1;
                            }
                            else if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "5")
                            {
                                firstdate = 8;
                            }
                            else if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "6")
                            {
                                firstdate = 15;
                            }
                            else if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "7")
                            {
                                firstdate = 22;
                            }
                            else if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "8")
                            {

                                limit = lastWeekDays;

                                if (now.Month == 2)
                                {
                                    if ((now.Year % 4 == 0 && now.Year % 100 != 0) || (now.Year % 400 == 0))
                                    {
                                        firstdate = 29;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    firstdate = 29;
                                }

                            }




                            string DaysStr = Rowd["OFFDUTYDTL_DAYS"].ToString();
                            string[] spitDayStr = DaysStr.Split(',');
                            foreach (string strSpliSlice in spitDayStr)
                            {
                                if (strSpliSlice != "")
                                {
                                    switch (strSpliSlice)
                                    {
                                        case "2":
                                            DateTime FirstMonday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < limit; count++)
                                            {
                                                if (FirstMonday.DayOfWeek == DayOfWeek.Monday)
                                                {
                                                    leaveDate = FirstMonday;
                                                    if (leaveDate != DateTime.MinValue)
                                                    {
                                                        MonthlyOffDates.Add(leaveDate);
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstMonday = FirstMonday.AddDays(1);
                                                }
                                            }

                                            if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() != "8" && (now.Month < now1.Month || now.Year < now1.Year))
                                            {
                                                FirstMonday = new DateTime(now1.Year, now1.Month, firstdate);
                                                for (int count = 0; count < limit; count++)
                                                {
                                                    if (FirstMonday.DayOfWeek == DayOfWeek.Monday)
                                                    {
                                                        leaveDate = FirstMonday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstMonday = FirstMonday.AddDays(1);
                                                    }
                                                }
                                            }
                                            break;
                                        case "3":
                                            DateTime FirstTuesday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < limit; count++)
                                            {
                                                if (FirstTuesday.DayOfWeek == DayOfWeek.Tuesday)
                                                {

                                                    leaveDate = FirstTuesday;
                                                    if (leaveDate != DateTime.MinValue)
                                                    {
                                                        MonthlyOffDates.Add(leaveDate);
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstTuesday = FirstTuesday.AddDays(1);
                                                }
                                            }
                                            if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() != "8" && (now.Month < now1.Month || now.Year < now1.Year))
                                            {
                                                FirstTuesday = new DateTime(now1.Year, now1.Month, firstdate);
                                                for (int count = 0; count < limit; count++)
                                                {
                                                    if (FirstTuesday.DayOfWeek == DayOfWeek.Tuesday)
                                                    {

                                                        leaveDate = FirstTuesday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstTuesday = FirstTuesday.AddDays(1);
                                                    }
                                                }
                                            }
                                            break;
                                        case "4":
                                            DateTime FirstWednesday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < limit; count++)
                                            {
                                                if (FirstWednesday.DayOfWeek == DayOfWeek.Wednesday)
                                                {
                                                    leaveDate = FirstWednesday;
                                                    if (leaveDate != DateTime.MinValue)
                                                    {
                                                        MonthlyOffDates.Add(leaveDate);
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstWednesday = FirstWednesday.AddDays(1);
                                                }
                                            }

                                            if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() != "8" && (now.Month < now1.Month || now.Year < now1.Year))
                                            {
                                                FirstWednesday = new DateTime(now1.Year, now1.Month, firstdate);
                                                for (int count = 0; count < limit; count++)
                                                {
                                                    if (FirstWednesday.DayOfWeek == DayOfWeek.Wednesday)
                                                    {
                                                        leaveDate = FirstWednesday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstWednesday = FirstWednesday.AddDays(1);
                                                    }
                                                }
                                            }
                                            break;
                                        case "5":
                                            DateTime FirstThursday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < limit; count++)
                                            {
                                                if (FirstThursday.DayOfWeek == DayOfWeek.Thursday)
                                                {
                                                    leaveDate = FirstThursday;
                                                    if (leaveDate != DateTime.MinValue)
                                                    {
                                                        MonthlyOffDates.Add(leaveDate);
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstThursday = FirstThursday.AddDays(1);
                                                }
                                            }
                                            if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() != "8" && (now.Month < now1.Month || now.Year < now1.Year))
                                            {
                                                FirstThursday = new DateTime(now1.Year, now1.Month, firstdate);
                                                for (int count = 0; count < limit; count++)
                                                {
                                                    if (FirstThursday.DayOfWeek == DayOfWeek.Thursday)
                                                    {
                                                        leaveDate = FirstThursday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstThursday = FirstThursday.AddDays(1);
                                                    }
                                                }
                                            }
                                            break;
                                        case "6":
                                            DateTime FirstFriday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < limit; count++)
                                            {
                                                if (FirstFriday.DayOfWeek == DayOfWeek.Friday)
                                                {
                                                    leaveDate = FirstFriday;
                                                    if (leaveDate != DateTime.MinValue)
                                                    {
                                                        MonthlyOffDates.Add(leaveDate);
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstFriday = FirstFriday.AddDays(1);
                                                }
                                            }
                                            if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() != "8" && (now.Month < now1.Month || now.Year < now1.Year))
                                            {
                                                FirstFriday = new DateTime(now1.Year, now1.Month, firstdate);
                                                for (int count = 0; count < limit; count++)
                                                {
                                                    if (FirstFriday.DayOfWeek == DayOfWeek.Friday)
                                                    {
                                                        leaveDate = FirstFriday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstFriday = FirstFriday.AddDays(1);
                                                    }
                                                }
                                            }
                                            break;
                                        case "7":

                                            DateTime FirstSaturday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < limit; count++)
                                            {
                                                if (FirstSaturday.DayOfWeek == DayOfWeek.Saturday)
                                                {
                                                    leaveDate = FirstSaturday;
                                                    if (leaveDate != DateTime.MinValue)
                                                    {
                                                        MonthlyOffDates.Add(leaveDate);
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstSaturday = FirstSaturday.AddDays(1);
                                                }
                                            }
                                            if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() != "8" && (now.Month < now1.Month || now.Year < now1.Year))
                                            {
                                                FirstSaturday = new DateTime(now1.Year, now1.Month, firstdate);
                                                for (int count = 0; count < limit; count++)
                                                {
                                                    if (FirstSaturday.DayOfWeek == DayOfWeek.Saturday)
                                                    {
                                                        leaveDate = FirstSaturday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstSaturday = FirstSaturday.AddDays(1);
                                                    }
                                                }
                                            }
                                            break;
                                        case "1":
                                            DateTime FirstSunday = new DateTime(now.Year, now.Month, firstdate);
                                            for (int count = 0; count < limit; count++)
                                            {
                                                if (FirstSunday.DayOfWeek == DayOfWeek.Sunday)
                                                {
                                                    leaveDate = FirstSunday;
                                                    if (leaveDate != DateTime.MinValue)
                                                    {
                                                        MonthlyOffDates.Add(leaveDate);
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    FirstSunday = FirstSunday.AddDays(1);
                                                }
                                            }
                                            if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() != "8" && (now.Month < now1.Month || now.Year < now1.Year))
                                            {
                                                FirstSunday = new DateTime(now1.Year, now1.Month, firstdate);
                                                for (int count = 0; count < limit; count++)
                                                {
                                                    if (FirstSunday.DayOfWeek == DayOfWeek.Sunday)
                                                    {
                                                        leaveDate = FirstSunday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstSunday = FirstSunday.AddDays(1);
                                                    }
                                                }
                                            }
                                            break;
                                    }
                                }

                            }
                        }

                    }

                }

            }
        }



       



        string HoliName = "", Holi1 = "false";
        if (MonthlyOffDates.Count > 0)
        {

          
            foreach (var RowHoli in MonthlyOffDates)
            {
                DateTime fromdate;
                string ans;
                ans = dateCheck.ToString("dd-MM-yyyy");
                ans = String.Format("{0:dd-MM-yyyy}", ans);
                fromdate = objCommon.textToDateTime(ans);

                if (RowHoli == fromdate)
                {
                    //HoliName = RowHoli["HLDAYMSTR_DATE"].ToString();
                    Holi1 = "true";
                    return Holi1;
                }
            }
        }


        string strDayWkString1 = dateCheck.ToString("dddd");
        if (strJbWklyOffDay.Contains(strDayWkString1))
        {
            Holi1 = "true";
        }



        return Holi1;


       
    }
    public static string GetWeekOfMonth(DateTime date)
    {

        DateTime beginningOfMonth = new DateTime(date.Year, date.Month, 1);

        //while (date.Date.AddDays(1).DayOfWeek != CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)

        //    date = date.AddDays(1);
        while (date.Date.AddDays(1).DayOfWeek != CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)

            date = date.AddDays(1);

        int weekNumber = (int)Math.Truncate((double)date.Subtract(beginningOfMonth).TotalDays / 7f) + 1;

        string[] weeks = { "first", "second", "third", "fourth", "fifth", "sixth" };

        return weeks[weekNumber - 1];

    }


    public string ConvertDate(DataTable dt)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsBusinessLayerDutyRosterReports objBusinessDutyRosterReptr = new clsBusinessLayerDutyRosterReports();
        clsEntityLayerDutyRosterReports objEntityDutyRosterReptr = new clsEntityLayerDutyRosterReports();
        string strHtml = "";
        DateTime datenow, enddate;
        string strRandom = objCommon.Random_Number();
        DateTime datfrmdate = DateTime.Today;
        DateTime dattodate = DateTime.Today;
        string todate = "";
        string frmdate = "";

        //string strRandomMixeddaste = Request.QueryString["fromdate"].ToString();
        if (hiddenDate.Value != "")
        {
            frmdate = hiddenDate.Value;
            datfrmdate = objCommon.textToDateTime(frmdate);
            todate = Hiddenstoretodate.Value;
            frmdate = datfrmdate.ToString("dd-MM-yyyy");

            dattodate = objCommon.textToDateTime(todate);
            todate = dattodate.ToString("dd-MM-yyyy");

            // objEntityDutyRosterReptr.EmplyId = Convert.ToInt32(strId);
        }
        if (frmdate != "" && todate != null)
        {
            datenow = objCommon.textToDateTime(frmdate);
            enddate = objCommon.textToDateTime(todate);

            for (var day = datenow; day <= enddate; day = day.AddDays(1))
            {

                strHtml += "<tr  >";
                //    flag = 1;
                strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: center;\" colspan=\"4\" >" + day.ToString("dd-MM-yyyy") + "</td>";

                strHtml += "</tr>";



                string hol = checkholiday(day, datenow, enddate);
                if (hol == "true")
                {
                    strHtml += "<tr  >";
                    //    flag = 1;
                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" colspan=\"4\" >HOLIDAY</td>";

                    strHtml += "</tr>";
                   //  break;
                    continue;
                }

                string off = CheckDutyOff(day);
                if (off == "true")
                {
                    strHtml += "<tr  >";
                    //    flag = 1;
                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" colspan=\"4\" >DUTY OFF</td>";

                    strHtml += "</tr>";
                    //    break;
                }

                else
                {
                    string[] arrayEmployeeId = new string[dt.Rows.Count];
                    int i = 0;
                   
                    int flag = 0;
                    for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
                    {
                      

                        arrayEmployeeId[intRowBodyCount] = dt.Rows[intRowBodyCount]["DATE"].ToString();
                        string ursid = "";
                        string strId = dt.Rows[intRowBodyCount][0].ToString();
                        int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                        string stridLength = intIdLength.ToString("00");
                        string Id = stridLength + strId + strRandom;
                        ursid = dt.Rows[intRowBodyCount]["USR_ID"].ToString();
                        if (day == objCommon.textToDateTime(dt.Rows[intRowBodyCount]["DATE"].ToString()) && flag != 1)
                        {




                            strHtml += "<tr  >";

                            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                            {
                                //if (intColumnBodyCount == 0)
                                //{
                                //    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";


                                //if (hiddenSelectdNo.Value != "1")
                                //{
                                // if (RadioBtnDate.Checked == true)
                                ///  {
                                //if (intColumnBodyCount == 1)
                                //{
                                //    strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + " <a title=\"Job Details\" onclick='return getdetails(this.href);' " +
                                //      " href=\"flt_Duty_Roster_Report_Details.aspx?Id=" + Id + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a></td>";

                                //}

                                // }
                                //if (RadioBtnEmply.Checked == true)
                                //{

                                //if (intColumnBodyCount == 2)
                                //{
                                //    strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + " <a  title=\"Job Details\" onclick='return getdetails(this.href);' " +
                                //      " href=\"flt_Duty_Roster_Report_Details.aspx?Id=" + Id + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                                //}
                                //}
                                // }

                                //else
                                //{
                                    //if (RadioBtnDate.Checked == true)
                                    // {
                                    //if (intColumnBodyCount == 1)
                                    //{
                                    //    strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + " <a  title=\"Job Details\" onclick='return getdetails(this.href);' " +
                                    //      " href=\"flt_Duty_Roster_Report_Details.aspx?Id=" + Id + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a></td>";
                                    //}
                                    //}
                                    //if (RadioBtnEmply.Checked == true)
                                    //{
                                    if (intColumnBodyCount == 2)
                                    {
                                        strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + " <a  title=\"Job Details\" onclick='return getdetails(this.href);' " +
                                          " href=\"flt_Duty_Roster_Report_Details.aspx?Id=" + Id + "&Back="+ HiddenFieldBack.Value+"&EmpList="+HiddenFieldBackIn.Value+"\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                                    }
                                    //}
                               // }
                                if (intColumnBodyCount == 3)
                                {
                                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                                }
                                if (intColumnBodyCount == 4)
                                {
                                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + " - " + dt.Rows[intRowBodyCount][5].ToString() + "</td>";
                                }

                             

                                flag = 1;
                            }
                            strHtml += "</tr>";
                           
                        }
                        else
                        {
                            if (flag != 1)
                            {
                                string leave = checkleave(day, datenow, enddate, ursid);
                                if (leave == "true")
                                {
                                    strHtml += "<tr>";
                                    strHtml += "<td class=\"tdT\" colspan=\"4\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: left;\" > LEAVE </td>";
                                    strHtml += "</tr>";
                                    flag = 1;
                                }
                                else
                                {
                                    //string dutyoff = CheckDutyOff(day);
                                    if (intRowBodyCount == (dt.Rows.Count - 1))
                                    {
                                        strHtml += "<tr>";
                                        strHtml += "<td class=\"tdT\" colspan=\"4\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: left;\" >  NO WORK SCHEDULED </a></td>";
                                        strHtml += "</tr>";
                                        flag = 1;
                                    }
                                }
                            }
                        }

                    }

                }
            }
        }
        return strHtml;
    }
}