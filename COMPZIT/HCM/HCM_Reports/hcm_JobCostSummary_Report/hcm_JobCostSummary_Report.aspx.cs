using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using BL_Compzit.BusinessLayer_GMS;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Globalization;
public partial class HCM_HCM_Reports_hcm_JobCostSummary_Report_hcm_JobCostSummary_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusiness_JobCostSummary_Report objBusiness_JobCostSummary_Report = new clsBusiness_JobCostSummary_Report();
            clsEntityJobCostSummary_Report objEntityJobCostSummary_Report = new clsEntityJobCostSummary_Report();

            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityJobCostSummary_Report.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityJobCostSummary_Report.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            objEntityJobCostSummary_Report.Month = 0;
            objEntityJobCostSummary_Report.Year = 0;
            objEntityJobCostSummary_Report.DivisionId = 0;


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
            }

            YearLoad();
            monthLoad();
            Corp_DivisionLoad();

          // DataTable dtJobCostReport = objBusiness_JobCostSummary_Report.Read_JobCostReport_List(objEntityJobCostSummary_Report);
             DataTable dtJobCostReport = objBusiness_JobCostSummary_Report.Read_ProjectCostReport_List(objEntityJobCostSummary_Report);
            string strReport = ConvertDataTableToHTML(dtJobCostReport);
            divReport.InnerHtml = strReport;

            DataTable dtCorp = objBusiness_JobCostSummary_Report.ReadCorporateAddress(objEntityJobCostSummary_Report);
            string strPrintReport = ConvertDataTableForPrint(dtJobCostReport, dtCorp);
            divPrintReport.InnerHtml = strPrintReport;
        }
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
        ddlDivision.Items.Insert(0, "--SELECT--");
    }

    protected void YearLoad()
    {

        ddlYear.Items.Clear();
        // created object for business layer for compare the date
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strCurrentDate = objBusiness.LoadCurrentDateInString();
        string[] split = strCurrentDate.Split('-');

        var currentYear = Convert.ToInt32(split[2]);
        for (int i = 0; i <= 20; i++)
        {
            // Now just add an entry that's the current year minus the counter
            ddlYear.Items.Add((currentYear - i).ToString());

        }
        ddlYear.Items.Insert(0, "--SELECT YEAR--");
    }
    public void monthLoad()
    {
        DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
        for (int i = 1; i < 13; i++)
        {
            ddlMonth.Items.Add(new ListItem(info.GetMonthName(i).ToUpper(), i.ToString()));
        }
        ddlMonth.Items.Insert(0, "--SELECT MONTH--");
    }

    public string ConvertDataTableToHTML(DataTable dt)
    {
        int precision = Convert.ToInt32(hiddenDecimalCount.Value);
        string format = String.Format("{{0:N{0}}}", precision);

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        StringBuilder sb = new StringBuilder();

        sb.Append("<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >");

        sb.Append("<thead>");

        sb.Append("<tr class=\"main_table_head\">");

        sb.Append("<th class=\"thT\" style=\"width:9%;text-align: left; word-wrap:break-word;\">JOB #</th>");

        sb.Append("<th class=\"thT\" style=\"width:23%;text-align: left; word-wrap:break-word;\">Job Description</th>");

        sb.Append("<th class=\"thT\" style=\"width:9%;text-align: center; word-wrap:break-word;\">Workers</th>");

        sb.Append("<th class=\"thT\" style=\"width:9%;text-align: center; word-wrap:break-word;\">OT Hrs</th>");

        sb.Append("<th class=\"thT\" style=\"width:18%;text-align: center; word-wrap:break-word;\">Currency</th>");

        sb.Append("<th class=\"thT\" style=\"width:9%;text-align: right; word-wrap:break-word;\">Basic + Allow</th>");

        sb.Append("<th class=\"thT\" style=\"width:9%;text-align: right; word-wrap:break-word;\">OT</th>");

        sb.Append("<th class=\"thT\" style=\"width:13%;text-align: right; word-wrap:break-word;\">Total</th>");

        sb.Append("</tr>");
        sb.Append("</thead>");



        //add rows
        sb.Append("<tbody>");

        if (dt.Rows.Count == 0)
        {
         //   sb.Append("<tr id=\"TableRprtRow\" >");
          //  sb.Append("<th class=\"thT\" colspan=\"10\" style=\"width:11%;text-align: center; word-wrap:break-word;\">NO DATA AVAILABLE</th>");
           // sb.Append("</tr>");
        }

        else
        {
            int samcount =0;
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
               /* samcount++;
                if (samcount > 15)break; else intRowBodyCount = 0;*/



                
               
                clsBusiness_JobCostSummary_Report objBusiness_JobCostSummary_Report = new clsBusiness_JobCostSummary_Report();
                clsEntityJobCostSummary_Report objEntityJobCostSummary_Report = new clsEntityJobCostSummary_Report();

                objEntityJobCostSummary_Report.PrjctId = Convert.ToInt32(dt.Rows[intRowBodyCount]["PROJECT_ID"].ToString());

                decimal BasicPayAvoid = 0, AllwnceAvoid = 0, BasicAllwnce = 0, OtAmt = 0, Total=0;

            //    DataTable dtPrjctDtls = objBusiness_JobCostSummary_Report.Read_Dates_ByPrjctId(objEntityJobCostSummary_Report);

               


                sb.Append("<tr>");

                sb.Append("<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["REF_NUM"].ToString() + "</td>");

                sb.Append("<td class=\"tdT\" style=\" width:23%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["JOB_DESCRIPTION"].ToString() + "</td>");

                sb.Append("<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["WORKERS"].ToString() + "</td>");

                sb.Append("<td class=\"tdT\"  style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["OT_HOURS"].ToString() + "</td>");

                sb.Append("<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["CRNCMST_NAME"].ToString() + "</td>");

                sb.Append("<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + String.Format(format,Convert.ToDecimal(dt.Rows[intRowBodyCount]["BASIC_ALLWNC"].ToString())) + "</td>");

                sb.Append("<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + String.Format(format,Convert.ToDecimal(dt.Rows[intRowBodyCount]["TOTAL_OT_COST"].ToString())) + "</td>");

                sb.Append("<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + String.Format(format,Convert.ToDecimal(dt.Rows[intRowBodyCount]["TOT_COST"].ToString())) + "</td>");

                sb.Append("</tr>");
            }
        }
        sb.Append("</tbody>");
        sb.Append("</table>");

        return sb.ToString();
    }

    

    public string ConvertDataTableForPrint(DataTable dt, DataTable dtCorp)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = strTitle = "JOB COST SUMMARY REPORT ";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string usrName = "";
        if (Session["USERFULLNAME"] != null)
        {
            usrName = "<B> Report Generated By: </B>" + Session["USERFULLNAME"];
        }
        string division = "";
        string category = "";
        string mode = "";

        if (dtCorp.Rows.Count > 0)
        {
            strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
            strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
            strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
            strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
            strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
        }
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        string strCompanyAddr = objClsCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);

        StringBuilder sbCap = new StringBuilder();
        string strUsrName = "";
        string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr + "</td></tr>";
        string strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        if (usrName != "")
        {
            strUsrName = "<tr><td class=\"RprtDiv\">" + usrName + "</td></tr>";
        }
        string strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
        string strDivisionTitle = "", strCategoryTitle = "", strTypeTitle = "";
        if (division != "")
        {
            strDivisionTitle = "<tr><td class=\"RprtDiv\">" + division + "</td></tr>";
        }
        if (category != "")
        {
            strCategoryTitle = "<tr><td class=\"RprtDiv\">" + category + "</td></tr>";
        }
        if (mode != "")
        {
            strTypeTitle = "<tr><td class=\"RprtDiv\">" + mode + "</td></tr>";
        }
        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strUsrName + strDivisionTitle + strCategoryTitle + strTypeTitle + strCaptionTabTitle + strCaptionTabstop;

        sbCap.Append(strPrintCaptionTable);
        //write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString(); ;

        int precision = Convert.ToInt32(hiddenDecimalCount.Value);
        string format = String.Format("{{0:N{0}}}", precision);

        StringBuilder sb = new StringBuilder();

        sb.Append("<table id=\"PrintTable\" class=\"tab\"  >");
        //add header row
        sb.Append("<thead>");

        sb.Append("<tr class=\"top_row\">");
        sb.Append("<th class=\"thT\" style=\"width:9%;text-align: left; word-wrap:break-word;\">JOB #</th>");

        sb.Append("<th class=\"thT\" style=\"width:23%;text-align: left; word-wrap:break-word;\">Job Description</th>");

        sb.Append("<th class=\"thT\" style=\"width:9%;text-align: center; word-wrap:break-word;\">Workers</th>");

        sb.Append("<th class=\"thT\" style=\"width:9%;text-align: center; word-wrap:break-word;\">OT Hrs</th>");

        sb.Append("<th class=\"thT\" style=\"width:18%;text-align: center; word-wrap:break-word;\">Currency</th>");

        sb.Append("<th class=\"thT\" style=\"width:9%;text-align: right; word-wrap:break-word;\">Basic + Allow</th>");

        sb.Append("<th class=\"thT\" style=\"width:9%;text-align: right; word-wrap:break-word;\">OT</th>");

        sb.Append("<th class=\"thT\" style=\"width:13%;text-align: right; word-wrap:break-word;\">Total</th>");
        sb.Append("</tr>");
        sb.Append("</thead>");

        //add rows
        sb.Append("<tbody>");

        if (dt.Rows.Count == 0)
        {
            sb.Append("<tr id=\"TableRprtRow\" >");
            sb.Append("<td class=\"thT\"colspan=10 style=\"width:11%;text-align: center; word-wrap:break-word;\">NO DATA AVAILABLE</th>");
        }
        else
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {

                clsBusiness_JobCostSummary_Report objBusiness_JobCostSummary_Report = new clsBusiness_JobCostSummary_Report();
                clsEntityJobCostSummary_Report objEntityJobCostSummary_Report = new clsEntityJobCostSummary_Report();


                sb.Append("<tr id=\"TableRprtRow\" >");
                sb.Append("<tr  >");

                sb.Append("<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["REF_NUM"].ToString() + "</td>");
                sb.Append("<td class=\"tdT\" style=\" width:23%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["JOB_DESCRIPTION"].ToString() + "</td>");
                sb.Append("<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["WORKERS"].ToString() + "</td>");               
                sb.Append("<td class=\"tdT\"  style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["OT_HOURS"].ToString() + "</td>");
                sb.Append("<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["CRNCMST_NAME"].ToString() + "</td>");
                sb.Append("<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + String.Format(format, Convert.ToDecimal(dt.Rows[intRowBodyCount]["BASIC_ALLWNC"].ToString())) + "</td>");
                sb.Append("<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + String.Format(format, Convert.ToDecimal(dt.Rows[intRowBodyCount]["TOTAL_OT_COST"].ToString())) + "</td>");
                sb.Append("<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + String.Format(format, Convert.ToDecimal(dt.Rows[intRowBodyCount]["TOT_COST"].ToString())) + "</td>");

                sb.Append("</tr>");
            }

           
            sb.Append("</tr>");

        }

        sb.Append("</tbody>");
        sb.Append("</table>");
        return sb.ToString();
    }

    public int TotalDays(int month, int year)
    {
        int daysinMnth = 0;

        if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
        {
            daysinMnth = 31;
        }
        else if (month == 4 || month == 6 || month == 9 || month == 11)
        {
            daysinMnth = 30;
        }
        else if (month == 2)
        {
            string LeapOrNot = "";
            if (year % 4 != 0)
            {
                LeapOrNot = "Not Leap";
            }
            else if (year % 400 == 0)
            {
                LeapOrNot = "Leap";
            }
            else if (year % 100 == 0)
            {
                LeapOrNot = "Not Leap";
            }
            else
            {
                LeapOrNot = "Leap";
            }

            if (LeapOrNot == "Leap")
            {
                daysinMnth = 29;
            }
            else
            {
                daysinMnth = 28;
            }
        }

        return daysinMnth;
    }

    protected void BtnCSV_Click(object sender, EventArgs e)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dt = GetTable();
        string strImagePath = "";
        string filepath = "";
        string strResult = DataTableToCSV(dt, ',');
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        if (Session["ORGID"] != null)
        {
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }

        try
        {
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.JOB_COST_SUMMARY_CSV);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
            string newFilePath = Server.MapPath("/CustomFiles/HCM CSV/Job_Cost_summary/JobCostSummary_" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "JobCostSummary_" + strNextId + ".csv";
            Response.ContentType = "csv";
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.JOB_COST_SUMMARY_CSV);
            Response.AddHeader("content-Disposition", "attachment;filename=\"" + filepath + "\"");
            Response.TransmitFile(Server.MapPath(strImagePath) + filepath);
            Response.End();
            if (File.Exists(MapPath(strImagePath) + filepath))
            {
                File.Delete(MapPath(strImagePath) + filepath);
            }

        }
        catch (Exception)
        { }
    }
    public string DataTableToCSV(DataTable dtSIFHeader, char seperator)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < dtSIFHeader.Columns.Count; i++)
        {
            sb.Append(dtSIFHeader.Columns[i]);
            if (i < dtSIFHeader.Columns.Count - 1)
                sb.Append(seperator);
        }
        sb.AppendLine();
        foreach (DataRow dr in dtSIFHeader.Rows)
        {
            for (int i = 0; i < dtSIFHeader.Columns.Count; i++)
            {
                sb.Append(dr[i].ToString());

                if (i < dtSIFHeader.Columns.Count - 1)
                    sb.Append(seperator);
            }
            sb.AppendLine();
        }
        return sb.ToString();

    }
    public DataTable GetTable()
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        int precision = Convert.ToInt32(hiddenDecimalCount.Value);
        string format = String.Format("{{0:N{0}}}", precision);
        DataTable table = new DataTable();

            table.Columns.Add("JOB #", typeof(string));
            table.Columns.Add("Job Description ", typeof(string));
            table.Columns.Add("Workers", typeof(string));
            table.Columns.Add("OT Hrs", typeof(string));
            table.Columns.Add("Currency", typeof(string));
            table.Columns.Add("Basic + Allow", typeof(string));
            table.Columns.Add("OT", typeof(string));
            table.Columns.Add("Total", typeof(string));


            clsBusiness_JobCostSummary_Report objBusiness_JobCostSummary_Report = new clsBusiness_JobCostSummary_Report();
            clsEntityJobCostSummary_Report objEntityJobCostSummary_Report = new clsEntityJobCostSummary_Report();

            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityJobCostSummary_Report.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityJobCostSummary_Report.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            objEntityJobCostSummary_Report.Month = 0;
            objEntityJobCostSummary_Report.Year = 0;
            objEntityJobCostSummary_Report.DivisionId = 0;

            if (ddlDivision.SelectedItem.Value != "--SELECT--")
            {
                objEntityJobCostSummary_Report.DivisionId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
            }

            if (ddlYear.SelectedItem.Value != "--SELECT YEAR--")
            {
                objEntityJobCostSummary_Report.Year = Convert.ToInt32(ddlYear.SelectedItem.Value);
            }

            if (ddlMonth.SelectedItem.Value != "--SELECT MONTH--")
            {
                objEntityJobCostSummary_Report.Month = Convert.ToInt32(ddlMonth.SelectedItem.Value);
            }         
             DataTable dt = objBusiness_JobCostSummary_Report.Read_ProjectCostReport_List(objEntityJobCostSummary_Report);

        //for printing table
        string job = "";
        string Description = "";
        string Worker = "";
        string Others = "";
        string Currency = "";
        string Bacic_plus_Alvnc = "";
        string ot = "";
        string total = "";

        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            job = dt.Rows[intRowBodyCount]["REF_NUM"].ToString();
            Description = dt.Rows[intRowBodyCount]["JOB_DESCRIPTION"].ToString();
            Worker = dt.Rows[intRowBodyCount]["WORKERS"].ToString();
            Others = dt.Rows[intRowBodyCount]["OT_HOURS"].ToString();
            Currency = dt.Rows[intRowBodyCount]["CRNCMST_NAME"].ToString();
            Bacic_plus_Alvnc = String.Format(format, dt.Rows[intRowBodyCount]["BASIC_ALLWNC"].ToString());
            ot = String.Format(format, dt.Rows[intRowBodyCount]["TOTAL_OT_COST"].ToString());
            total = String.Format(format, dt.Rows[intRowBodyCount]["TOT_COST"].ToString());

            table.Rows.Add('"' + job + '"', '"' + Description + '"', '"' + Worker + '"', '"' + Others + '"', '"' + Currency + '"', '"' + Bacic_plus_Alvnc + '"', '"' + ot + '"', '"' + total + '"');
        }
        return table;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsBusiness_JobCostSummary_Report objBusiness_JobCostSummary_Report = new clsBusiness_JobCostSummary_Report();
        clsEntityJobCostSummary_Report objEntityJobCostSummary_Report = new clsEntityJobCostSummary_Report();

        objEntityJobCostSummary_Report.Month = 0;
        objEntityJobCostSummary_Report.Year = 0;
        objEntityJobCostSummary_Report.DivisionId = 0;

        if (ddlDivision.SelectedItem.Value != "--SELECT--")
        {
            objEntityJobCostSummary_Report.DivisionId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        }

        if (ddlYear.SelectedItem.Value != "--SELECT YEAR--")
        {
            objEntityJobCostSummary_Report.Year = Convert.ToInt32(ddlYear.SelectedItem.Value);
        }

        if (ddlMonth.SelectedItem.Value != "--SELECT MONTH--")
        {
            objEntityJobCostSummary_Report.Month = Convert.ToInt32(ddlMonth.SelectedItem.Value);
        }

        DataTable dtJobCostReport = objBusiness_JobCostSummary_Report.Read_ProjectCostReport_List(objEntityJobCostSummary_Report);
        string strReport = ConvertDataTableToHTML(dtJobCostReport);
        divReport.InnerHtml = strReport;

    }
}