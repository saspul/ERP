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

public partial class AWMS_AWMS_Reports_flt_Duty_Roster_Report_flt_Duty_Roster_Report_EmpList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            DateTime dateCheck = new DateTime();
            dateCheck = DateTime.Now;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            //Creating objects for business layer
            clsBusinessLayerDutyRosterReports objBusinessDutyRosterReptr = new clsBusinessLayerDutyRosterReports();
            clsEntityLayerDutyRosterReports objEntityDutyRosterReptr = new clsEntityLayerDutyRosterReports();
   
            clsEntityReports objEntityReports = new clsEntityReports();

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

            DataTable dtEmplyddl = objBusinessDutyRosterReptr.ReadAllEmployee(objEntityDutyRosterReptr);

            if (dtEmplyddl.Rows.Count > 0)
            {
                ddlmodeSearch.DataSource = dtEmplyddl;
                ddlmodeSearch.DataTextField = "EMPLOYEE NAME";
                ddlmodeSearch.DataValueField = "USR_ID";
                ddlmodeSearch.DataBind();
            }

          
            DataTable dtDutyRosterList = objBusinessDutyRosterReptr.ReadAllEmployee(objEntityDutyRosterReptr);


            string strReport = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
            strReport += "<thead>";
            strReport += "<tr class=\"main_table_head\">";

       
           
                    strReport += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE NAME</th>";




                    strReport += "</tr>";
                    strReport += "</thead>";
            //add rows

                    strReport += "<tbody>";
                    strReport += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >No Data Availabe</td>";
                         strReport += "</tr>";

        

        strReport += "</tbody>";

        strReport += "</table>";
    
            //                ConvertDataTableToHTML(dtDutyRosterList);
            divReport.InnerHtml = strReport;
            clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();

            DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(objEntityReports);



            if (Request.QueryString != null)
            {
                if (Request.QueryString.Count > 0)
                {

                    hiddenselectedlist.Value = Request.QueryString["Id"].ToString();

                    DateTime fromdate, todate;
                    List<clsEntityDutyRosterReportEmpselection> objlistEmplyList = new List<clsEntityDutyRosterReportEmpselection>();
                    if (hiddenselectedlist.Value == "")
                    {

                        ddlmodeSearch.SelectedItem.Value = "";

                    }

                    else
                    {

                        string[] tokens = hiddenselectedlist.Value.Split(',');
                        //  foreach (ListItem itemCheckBoxModules in cblcandidatelist.Items)
                        // {
                        if (tokens.Count() == 1)
                        {
                            hiddenSelectdNo.Value = "1";
                        }
                        for (int i = 0; i < tokens.Count(); i++)
                        {

                            clsEntityDutyRosterReportEmpselection objEntityViolationReportforlist = new clsEntityDutyRosterReportEmpselection();
                            objEntityViolationReportforlist.EmpSelectionId = Convert.ToInt32(tokens[i]);
                            objEntityViolationReportforlist.DateSelection = 0;
                            objlistEmplyList.Add(objEntityViolationReportforlist);

                        }


                    }



                    txtToDate.Text = Request.QueryString["todate"].ToString();
                    txtFromDate.Text = Request.QueryString["fromdate"].ToString();



                    if (txtFromDate.Text != "")
                    {
                        string ans = txtFromDate.Text;
                        ans = String.Format("{0:dd-MM-yyyy}", ans);
                        fromdate = objCommon.textToDateTime(ans);
                        objEntityDutyRosterReptr.dateFromDate = fromdate;
                    }
                    if (txtToDate.Text != "")
                    {
                        todate = objCommon.textToDateTime(txtToDate.Text);
                        objEntityDutyRosterReptr.dateToDate = todate;
                    }


                    dtEmplyddl = objBusinessDutyRosterReptr.ReadDutyRosterReptr(objEntityDutyRosterReptr, objlistEmplyList);
                    lblNumRec.Text = "Total number of records : " + dtEmplyddl.Rows.Count.ToString();
                    strReport = ConvertDataTableToHTML(dtEmplyddl);
                    divReport.InnerHtml = strReport;




                }
                else
                {
                    lblNumRec.Text = "Total number of records : 0";
                }
            }
            else
            {
                lblNumRec.Text = "Total number of records : 0" ;
            }


        }
    }

    public string ConvertDataTableToHTML(DataTable dt)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();

        DateTime datenow, datenext;
       
        datenext = DateTime.Today;
  
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
        if (dt.Rows.Count > 0)
        {
            for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
            {
                if (intColumnHeaderCount == 1)
                {
                    strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE NAME</th>";
                }

            }
        }

        else
        {


            strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE NAME</th>";
          
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

        string[] arrayEmployeeId = new string[dt.Rows.Count];
        int i = 0;
      //  string[] arrayEmployeeId = new string[dt.Rows.Count];
       // int i = 0;
       //foreach (DataRow r in dt.Rows)
       // {
       //     arrayEmployeeId[i] = r["USR_ID"].ToString();
       //    i++;
       // }

        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            int flag = 0;

            foreach (string p in arrayEmployeeId)
            {
                if (p == dt.Rows[intRowBodyCount]["USR_ID"].ToString())
                {
                    flag = 1;
                    break;
                }
            }
            arrayEmployeeId[intRowBodyCount] = dt.Rows[intRowBodyCount]["USR_ID"].ToString();
            
            
            string strId = dt.Rows[intRowBodyCount]["USR_ID"].ToString();
            int intIdLength = dt.Rows[intRowBodyCount]["USR_ID"].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string strrandomnumm = Convert.ToString(strRandom.Length);
        
            string Id = stridLength + strId + strRandom;
               
            string fromdate;
            string todate;
            if (txtFromDate.Text != "")
            {
                fromdate = txtFromDate.Text;
            }
            else 
            {
                 fromdate = "_NA";
            }
            if (txtToDate.Text != "")
            {
                todate = txtToDate.Text;
            }
            else
            {
                todate = "_NA";
            }

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                if (flag != 1)
                {
                    if (intColumnBodyCount == 0)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + " <a title=\"Job Details\" onclick='return getdetails(this.href);' " +
                                  " href=\"flt_Duty_Roster_Report.aspx?Id=" + Id + "&fromdate=" + fromdate + "&todate=" + todate + "&EmpList=" + hiddenselectedlist.Value + "\">" + dt.Rows[intRowBodyCount]["EMPLOYEE NAME"].ToString() + "</td>";
                        break;
                    }
                }
            }
          
            strHtml += "</tr>";

        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
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
        if (hiddenselectedlist.Value == "")
        {

            ddlmodeSearch.SelectedItem.Value = "";
            // ddlvechcle.SelectedItem.Text = "";
        }
        //if (RadioBtnEmply.Checked == true)
        //{
        //    if (ddlmodeSearch.SelectedItem.Value == "")
        //    {
        //        objEntityDutyRosterReptr.EmplyId = 0;
        //    }
        else
        {

            string[] tokens = hiddenselectedlist.Value.Split(',');
            //  foreach (ListItem itemCheckBoxModules in cblcandidatelist.Items)
            // {
            if (tokens.Count() == 1)
            {
                hiddenSelectdNo.Value = "1";
            }
            for (int i = 0; i < tokens.Count(); i++)
            {

                clsEntityDutyRosterReportEmpselection objEntityViolationReportforlist = new clsEntityDutyRosterReportEmpselection();
                objEntityViolationReportforlist.EmpSelectionId = Convert.ToInt32(tokens[i]);
                objEntityViolationReportforlist.DateSelection = 0;
                objlistEmplyList.Add(objEntityViolationReportforlist);

            }


        }



        //    if (txtFromDate.Text != "")
        //    {
        //        string ans = txtFromDate.Text;
        //        ans = String.Format("{0:dd-MM-yyyy}", ans);
        //        fromdate = objCommon.textToDateTime(ans);
        //        objEntityDutyRosterReptr.dateFromDate = fromdate;
        //    }
        //    if (txtToDate.Text != "")
        //    {
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
        //else
        //{
        //    if (ddlmodeSearch.SelectedItem.Value == "" && hiddenselectedlist.Value!="")
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



            if (txtFromDate.Text != "")
            {
                string ans = txtFromDate.Text;
                ans = String.Format("{0:dd-MM-yyyy}", ans);
                fromdate = objCommon.textToDateTime(ans);
                objEntityDutyRosterReptr.dateFromDate = fromdate;
            }
            if (txtToDate.Text != "")
            {
                todate = objCommon.textToDateTime(txtToDate.Text);
                objEntityDutyRosterReptr.dateToDate = todate;
            }
        
        //}
            DataTable dtEmplyddl = objBusinessDutyRosterReptr.ReadDutyRosterReptr(objEntityDutyRosterReptr, objlistEmplyList);
        //if (dtEmplyddl.Rows.Count > 0)
        //{
        //    objEntityDutyRosterReptr.dateToDate = objCommon.textToDateTime(dtEmplyddl.Rows[0]["DATE"].ToString());
        //    objEntityDutyRosterReptr.dateFromDate = objCommon.textToDateTime(dtEmplyddl.Rows[dtEmplyddl.Rows.Count - 1]["DATE"].ToString());
        //}
        //DataTable dtHoliday = objBusinessDutyRosterReptr.ReadHolidayDate(objEntityDutyRosterReptr);
        clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();
        lblNumRec.Text = "Total number of records : " + dtEmplyddl.Rows.Count.ToString();
        string strReport = ConvertDataTableToHTML(dtEmplyddl);
        divReport.InnerHtml = strReport;
        DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(objEntityReports);

        //string strPrintReport = ConvertDataTableForPrint(dtEmplyddl, dtCorp);
        //divPrintReport.InnerHtml = strPrintReport;
    }
    }