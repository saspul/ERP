using System;
using System.Data;
using System.Text;
using CL_Compzit;
using BL_Compzit;
using System.Web.Services;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit;
using System.IO;
public partial class HCM_HCM_Reports_hcm_VisaBundle_Report_hcm_employe_recrutement_report_hcm_Employe_Recrutiment_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownYearBind();
            ClsEntity_HCM_Common objEntityLayerHcmCommon = new ClsEntity_HCM_Common();
            ClsBusiness_Employee_Recruitment_Report objBussinessEmployeRecruitment = new ClsBusiness_Employee_Recruitment_Report();
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLayerHcmCommon.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                objEntityLayerHcmCommon.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                hiddenOrgId.Value = Session["ORGID"].ToString();
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                objEntityLayerHcmCommon.UserId = Convert.ToInt32(Session["USERID"].ToString());
                hiddenUserId.Value = Session["USERID"].ToString();
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }



            int Tdayyear = 0;
            //DateTime.Today.Year;
            DataTable dtVisaQuota = new DataTable();
            string strHtm = ConvertDataTableToHTML(Tdayyear);
            divReport.InnerHtml = strHtm;

            DataTable dtCorp = objBussinessEmployeRecruitment.ReadCorporateAddress(objEntityLayerHcmCommon);

            string strPrintReport = ConvertDataTableForPrint(dtCorp, Tdayyear);

            divPrintReport.InnerHtml = strPrintReport;
        }
    }



    public void DropDownYearBind()
    {
        int Year = Convert.ToInt32(DateTime.Now.Year.ToString());
        for (int i = 0; i < 15; i++)
        {
            int Years = Year - i;
            ddlYear.Items.Add(Years.ToString());

        }
        ddlYear.Items.Insert(0, "--SELECT--");
    }



    public string ConvertDataTableToHTML(int YEAR)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        ClsEntity_HCM_Common objEntityLayerHcmCommon = new ClsEntity_HCM_Common();
        ClsBusiness_Employee_Recruitment_Report objBussinessEmployeRecruitment = new ClsBusiness_Employee_Recruitment_Report();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLayerHcmCommon.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityLayerHcmCommon.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityLayerHcmCommon.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (ddlYear.SelectedItem.Value != "--SELECT--")
        {
            objEntityLayerHcmCommon.Year = Convert.ToInt32(ddlYear.SelectedItem.Value);
        }
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";


        strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">MONTH</th>";

        strHtml += "<th class=\"thT\" style=\"width:35%;text-align: center; word-wrap:break-word;\">NO.OF EMPLOYEES RECRUITED </th>";

        strHtml += "<th class=\"thT\" style=\"width:45%;text-align: center; word-wrap:break-word;\">MORE INFO</th>";

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        string strId = Convert.ToString(YEAR);
        if (YEAR != 0)
        {

            for (int Month = 0; Month < 11; Month++)
            {
                string count = "";
                string MonthName = "";
                if (Month == 0)
                {
                    MonthName = "JANUARY";

                    DateTime From = new DateTime(YEAR, 1, 1);
                    DateTime To = new DateTime(YEAR, 1, 31);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;
                }

                else if (Month == 1)
                {

                    MonthName = "FEBRUARY";
                    DateTime From = new DateTime(YEAR, 2, 1);
                    objEntityLayerHcmCommon.FrmDate = From;
                    if (DateTime.IsLeapYear(YEAR))
                    {
                        DateTime To = new DateTime(YEAR, 2, 29);
                        objEntityLayerHcmCommon.ToDate = To;

                    }
                    else
                    {
                        DateTime To = new DateTime(YEAR, 2, 28);
                        objEntityLayerHcmCommon.ToDate = To;


                    }
                }
                else if (Month == 2)
                {
                    MonthName = "MARCH";
                    DateTime From = new DateTime(YEAR, 3, 1);
                    DateTime To = new DateTime(YEAR, 3, 31);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;

                }
                else if (Month == 3)
                {
                    MonthName = "APRIL";
                    DateTime From = new DateTime(YEAR, 4, 1);
                    DateTime To = new DateTime(YEAR, 4, 30);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;

                }
                else if (Month == 4)
                {
                    MonthName = "MAY";
                    DateTime From = new DateTime(YEAR, 5, 1);
                    DateTime To = new DateTime(YEAR, 5, 31);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;

                }
                else if (Month == 5)
                {
                    MonthName = "JUNE";
                    DateTime From = new DateTime(YEAR, 6, 1);
                    DateTime To = new DateTime(YEAR, 6, 30);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;

                }
                else if (Month == 6)
                {
                    MonthName = "JULY";
                    DateTime From = new DateTime(YEAR, 7, 1);
                    DateTime To = new DateTime(YEAR, 7, 31);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;

                }
                else if (Month == 7)
                {
                    MonthName = "AUGUST";
                    DateTime From = new DateTime(YEAR, 8, 1);
                    DateTime To = new DateTime(YEAR, 8, 31);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;

                }
                else if (Month == 8)
                {
                    MonthName = "SEPTEMBER";
                    DateTime From = new DateTime(YEAR, 9, 1);
                    DateTime To = new DateTime(YEAR, 9, 30);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;

                }
                else if (Month == 9)
                {
                    MonthName = "OCTOBER";
                    DateTime From = new DateTime(YEAR, 10, 1);
                    DateTime To = new DateTime(YEAR, 10, 31);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;

                }
                else if (Month == 10)
                {
                    MonthName = "NOVEMBER";
                    DateTime From = new DateTime(YEAR, 11, 1);
                    DateTime To = new DateTime(YEAR, 11, 30);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;
                }
                else if (Month == 11)
                {
                    MonthName = "DECEMBER";
                    DateTime From = new DateTime(YEAR, 12, 1);
                    DateTime To = new DateTime(YEAR, 12, 31);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;
                }

                DataTable dtVisaQuota = new DataTable();
                dtVisaQuota = objBussinessEmployeRecruitment.ReadEmployeeRecruitment(objEntityLayerHcmCommon);
                count = dtVisaQuota.Rows[0][0].ToString();


                if (count != "0")
                {



                    strHtml += "<tr  >";

                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + MonthName + "</td>";

                    strHtml += "<td class=\"tdT\" style=\" width:40%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + count + "</td>";

                    strHtml += "<td class=\"tdT\" style=\"width:6%; word-wrap:break-word;text-align: center;\"><input type=\"button\" class=\"save\" style=\"height:22px;margin-top:3%\" value=\"More Info\" onclick=\"return OpenVisaDetails('" + strId + "' ,'" + MonthName + "');\" /></td>";

                    strHtml += "</tr>";
                }




            }
        }

        strHtml += "</tbody>";

        strHtml += "</table>";




        sb.Append(strHtml);
        return sb.ToString();
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();

        ClsEntity_HCM_Common objEntityLayerHcmCommon = new ClsEntity_HCM_Common();
        ClsBusiness_Employee_Recruitment_Report objBussinessEmployeRecruitment = new ClsBusiness_Employee_Recruitment_Report();
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLayerHcmCommon.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityLayerHcmCommon.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        int intUserId = 0;
        if (Session["USERID"] != null)
        {
            objEntityLayerHcmCommon.UserId = Convert.ToInt32(Session["USERID"].ToString());
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (ddlYear.SelectedItem.Value != "--SELECT--")
        {
            objEntityLayerHcmCommon.Year = Convert.ToInt32(ddlYear.SelectedItem.Value);

            DataTable dtVisaQuota = new DataTable();
            string strHtm = ConvertDataTableToHTML(objEntityLayerHcmCommon.Year);
            divReport.InnerHtml = strHtm;



            string strPrintReport = ConvertDataTableForPrint(dtVisaQuota, objEntityLayerHcmCommon.Year);

            divPrintReport.InnerHtml = strPrintReport;
        }

        else
        {
            int Tdayyear = 0;
            //DateTime.Today.Year;
            DataTable dtVisaQuota = new DataTable();
            string strHtm = ConvertDataTableToHTML(Tdayyear);
            divReport.InnerHtml = strHtm;
            string strPrintReport = ConvertDataTableForPrint(dtVisaQuota, objEntityLayerHcmCommon.Year);

            divPrintReport.InnerHtml = strPrintReport;
        }
    }




    [WebMethod]
    public static string[] EmployeeRecuirmentDetails(string stryear, string strmonth, int intCorpId, int intOrgId, int intUserId)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();

        string[] strJson = new string[10];

        ClsEntity_HCM_Common objEntityLayerHcmCommon = new ClsEntity_HCM_Common();
        ClsBusiness_Employee_Recruitment_Report objBussinessEmployeRecruitment = new ClsBusiness_Employee_Recruitment_Report();



        int year = Convert.ToInt32(stryear);

        objEntityLayerHcmCommon.CorpId = intCorpId;
        objEntityLayerHcmCommon.OrgId = intOrgId;
        objEntityLayerHcmCommon.UserId = intUserId;

        if (strmonth == "JANUARY")
        {
            DateTime From = new DateTime(year, 1, 1);
            DateTime To = new DateTime(year, 1, 31);
            objEntityLayerHcmCommon.FrmDate = From;
            objEntityLayerHcmCommon.ToDate = To;

        }

        else if (strmonth == "FEBRUARY")
        {


            DateTime From = new DateTime(year, 2, 1);
            objEntityLayerHcmCommon.FrmDate = From;
            if (DateTime.IsLeapYear(year))
            {
                DateTime To = new DateTime(year, 2, 29);
                objEntityLayerHcmCommon.ToDate = To;

            }
            else
            {

                DateTime To = new DateTime(year, 2, 28);
                objEntityLayerHcmCommon.ToDate = To;

            }
        }
        else if (strmonth == "MARCH")
        {

            DateTime From = new DateTime(year, 3, 1);
            DateTime To = new DateTime(year, 3, 31);
            objEntityLayerHcmCommon.FrmDate = From;
            objEntityLayerHcmCommon.ToDate = To;

        }
        else if (strmonth == "APRIL")
        {

            DateTime From = new DateTime(year, 4, 1);
            DateTime To = new DateTime(year, 4, 30);
            objEntityLayerHcmCommon.FrmDate = From;
            objEntityLayerHcmCommon.ToDate = To;

        }
        else if (strmonth == "MAY")
        {

            DateTime From = new DateTime(year, 5, 1);
            DateTime To = new DateTime(year, 5, 31);
            objEntityLayerHcmCommon.FrmDate = From;
            objEntityLayerHcmCommon.ToDate = To;

        }
        else if (strmonth == "JUNE")
        {

            DateTime From = new DateTime(year, 6, 1);
            DateTime To = new DateTime(year, 6, 30);
            objEntityLayerHcmCommon.FrmDate = From;
            objEntityLayerHcmCommon.ToDate = To;

        }
        else if (strmonth == "JULY")
        {

            DateTime From = new DateTime(year, 7, 1);
            DateTime To = new DateTime(year, 7, 31);
            objEntityLayerHcmCommon.FrmDate = From;
            objEntityLayerHcmCommon.ToDate = To;

        }
        else if (strmonth == "AUGUST")
        {

            DateTime From = new DateTime(year, 8, 1);
            DateTime To = new DateTime(year, 8, 31);
            objEntityLayerHcmCommon.FrmDate = From;
            objEntityLayerHcmCommon.ToDate = To;

        }
        else if (strmonth == "SEPTEMBER")
        {

            DateTime From = new DateTime(year, 9, 1);
            DateTime To = new DateTime(year, 9, 30);
            objEntityLayerHcmCommon.FrmDate = From;
            objEntityLayerHcmCommon.ToDate = To;
        }
        else if (strmonth == "OCTOBER")
        {

            DateTime From = new DateTime(year, 10, 1);
            DateTime To = new DateTime(year, 10, 31);
            objEntityLayerHcmCommon.FrmDate = From;
            objEntityLayerHcmCommon.ToDate = To;

        }
        else if (strmonth == "NOVEMBER")
        {

            DateTime From = new DateTime(year, 11, 1);
            DateTime To = new DateTime(year, 11, 30);
            objEntityLayerHcmCommon.FrmDate = From;
            objEntityLayerHcmCommon.ToDate = To;

        }
        else if (strmonth == "DECEMBER")
        {

            DateTime From = new DateTime(year, 12, 1);
            DateTime To = new DateTime(year, 12, 31);
            objEntityLayerHcmCommon.FrmDate = From;
            objEntityLayerHcmCommon.ToDate = To;


        }
        DataTable dtVisaQuota = new DataTable();
        dtVisaQuota = objBussinessEmployeRecruitment.ReadEmployeeRecruitment(objEntityLayerHcmCommon);
        //for table on visa details

        DataTable dtVisaDtls = new DataTable();
        dtVisaDtls = objBussinessEmployeRecruitment.ReadEmployeeRecruitmentById(objEntityLayerHcmCommon);


        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dtVisaDtls.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">" + dtVisaDtls.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:22%;text-align: center; word-wrap:break-word;\">" + dtVisaDtls.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:26%;text-align: center; word-wrap:break-word;\">" + dtVisaDtls.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: center; word-wrap:break-word;\">" + dtVisaDtls.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: center; word-wrap:break-word;\">" + dtVisaDtls.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: center; word-wrap:break-word;\">" + dtVisaDtls.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
        }
        if (dtVisaDtls.Columns.Count == 0)
        {
            strHtml += "<td class=\"thT\" style=\"width:25%;text-align: left; word-wrap:break-word;\">VISA TYPE</th>";
            strHtml += "<td class=\"thT\" style=\"width:25%;text-align: center; word-wrap:break-word;\">NATION</th>";
            strHtml += "<td class=\"thT\"  style=\"width:30%;text-align: center; word-wrap:break-word;\">COMPANY</th>";
            strHtml += "<td class=\"thT\"  style=\"width:20%;text-align: center; word-wrap:break-word;\">NO. OF VISA</th>";
        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dtVisaDtls.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr  >";

            string strId = dtVisaDtls.Rows[intRowBodyCount][0].ToString();

            for (int intColumnBodyCount = 0; intColumnBodyCount < dtVisaDtls.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtVisaDtls.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:22%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtVisaDtls.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:26%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtVisaDtls.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtVisaDtls.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtVisaDtls.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 6)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtVisaDtls.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
            }
            strHtml += "</tr>";
        }
        if (dtVisaDtls.Rows.Count == 0)
        {
            strHtml += "<td  class=\"thT\" colspan=\"8\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        strJson[1] = sb.ToString();

        //for printing the detail table

        DataTable dtCorp = objBussinessEmployeRecruitment.ReadCorporateAddress(objEntityLayerHcmCommon);

        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Employee Recruitment Report";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
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

        string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr + "</td></tr>";
        string strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        string strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strCaptionTabTitle + strCaptionTabstop;

        sbCap.Append(strPrintCaptionTable);


        strJson[2] = sbCap.ToString();

        dtVisaDtls = objBussinessEmployeRecruitment.ReadEmployeeRecruitmentById(objEntityLayerHcmCommon);


        // class="table table-bordered table-striped"
        StringBuilder sbPrntDtl = new StringBuilder();
        string strHtmlDL = "<table id=\"ReportTable\" class=\"tab\"  cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dtVisaDtls.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 1)
            {
                strHtmlDL += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">" + dtVisaDtls.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtmlDL += "<th class=\"thT\" style=\"width:22%;text-align: center; word-wrap:break-word;\">" + dtVisaDtls.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtmlDL += "<th class=\"thT\" style=\"width:26%;text-align: center; word-wrap:break-word;\">" + dtVisaDtls.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtmlDL += "<th class=\"thT\" style=\"width:20%;text-align: center; word-wrap:break-word;\">" + dtVisaDtls.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 5)
            {
                strHtmlDL += "<th class=\"thT\" style=\"width:20%;text-align: center; word-wrap:break-word;\">" + dtVisaDtls.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 6)
            {
                strHtmlDL += "<th class=\"thT\" style=\"width:20%;text-align: center; word-wrap:break-word;\">" + dtVisaDtls.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
        }
        if (dtVisaDtls.Columns.Count == 0)
        {
            strHtmlDL += "<td class=\"thT\" style=\"width:25%;text-align: left; word-wrap:break-word;\">VISA TYPE</th>";
            strHtmlDL += "<td class=\"thT\" style=\"width:25%;text-align: center; word-wrap:break-word;\">NATION</th>";
            strHtmlDL += "<td class=\"thT\"  style=\"width:30%;text-align: center; word-wrap:break-word;\">COMPANY</th>";
            strHtmlDL += "<td class=\"thT\"  style=\"width:20%;text-align: center; word-wrap:break-word;\">NO. OF VISA</th>";
        }

        strHtmlDL += "</tr>";
        strHtmlDL += "</thead>";
        //add rows

        strHtmlDL += "<tbody>";

        for (int intRowBodyCount = 0; intRowBodyCount < dtVisaDtls.Rows.Count; intRowBodyCount++)
        {
            strHtmlDL += "<tr  >";

            string strId = dtVisaDtls.Rows[intRowBodyCount][0].ToString();

            for (int intColumnBodyCount = 0; intColumnBodyCount < dtVisaDtls.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    strHtmlDL += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtVisaDtls.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtmlDL += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtVisaDtls.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 3)
                {
                    strHtmlDL += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtVisaDtls.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 4)
                {
                    strHtmlDL += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtVisaDtls.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 5)
                {
                    strHtmlDL += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtVisaDtls.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 6)
                {
                    strHtmlDL += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtVisaDtls.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
            }
            strHtmlDL += "</tr>";
        }
        if (dtVisaDtls.Rows.Count == 0)
        {
            strHtml += "<td  class=\"thT\" colspan=\"8\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
        }

        strHtmlDL += "</tbody>";

        strHtmlDL += "</table>";

        sbPrntDtl.Append(strHtmlDL);
        strJson[3] = sbPrntDtl.ToString();


        return strJson;

    }




    public string ConvertDataTableForPrint(DataTable dtCorp, int YEAR)
    {
        ClsEntity_HCM_Common objEntityLayerHcmCommon = new ClsEntity_HCM_Common();
        ClsBusiness_Employee_Recruitment_Report objBussinessEmployeRecruitment = new ClsBusiness_Employee_Recruitment_Report();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLayerHcmCommon.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityLayerHcmCommon.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityLayerHcmCommon.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }




        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Employee Recruitment Report";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string usrName = "";
        if (Session["USERFULLNAME"] != null)
        {
            usrName = "<B> Report Generated By: </B>" + Session["USERFULLNAME"];
        }

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
        string strCaptionTabRprtYear = "<tr><td class=\"RprtYear\">" + ddlYear.SelectedItem.Value + "</td></tr>";
        string strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strUsrName + strCaptionTabTitle + strCaptionTabstop;

        sbCap.Append(strPrintCaptionTable);
        //write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString();

        StringBuilder sb = new StringBuilder();

        string strHtml = "<table id=\"ReportTable\" class=\"tab\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">"; ;


        strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">MONTH</th>";

        strHtml += "<th class=\"thT\" style=\"width:40%;text-align: center; word-wrap:break-word;\">No.Of Employees Recruited </th>";



        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        string strId = Convert.ToString(YEAR);
        if (YEAR != 0)
        {

            for (int Month = 0; Month < 11; Month++)
            {

                string count = "";
                string MonthName = "";
                if (Month == 0)
                {
                    MonthName = "JANUARY";

                    DateTime From = new DateTime(YEAR, 1, 1);
                    DateTime To = new DateTime(YEAR, 1, 31);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;

                }


                else if (Month == 1)
                {

                    MonthName = "FEBRUARY";
                    DateTime From = new DateTime(YEAR, 2, 1);
                    objEntityLayerHcmCommon.FrmDate = From;
                    if (DateTime.IsLeapYear(YEAR))
                    {
                        DateTime To = new DateTime(YEAR, 2, 29);
                        objEntityLayerHcmCommon.ToDate = To;


                    }
                    else
                    {

                        DateTime To = new DateTime(YEAR, 2, 28);
                        objEntityLayerHcmCommon.ToDate = To;


                    }
                }
                else if (Month == 2)
                {
                    MonthName = "MARCH";
                    DateTime From = new DateTime(YEAR, 3, 1);
                    DateTime To = new DateTime(YEAR, 3, 31);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;

                }
                else if (Month == 3)
                {
                    MonthName = "APRIL";
                    DateTime From = new DateTime(YEAR, 4, 1);
                    DateTime To = new DateTime(YEAR, 4, 30);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;

                }
                else if (Month == 4)
                {
                    MonthName = "MAY";
                    DateTime From = new DateTime(YEAR, 5, 1);
                    DateTime To = new DateTime(YEAR, 5, 31);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;

                }
                else if (Month == 5)
                {
                    MonthName = "JUNE";
                    DateTime From = new DateTime(YEAR, 6, 1);
                    DateTime To = new DateTime(YEAR, 6, 30);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;

                }
                else if (Month == 6)
                {
                    MonthName = "JULY";
                    DateTime From = new DateTime(YEAR, 7, 1);
                    DateTime To = new DateTime(YEAR, 7, 31);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;

                }
                else if (Month == 7)
                {
                    MonthName = "AUGUST";
                    DateTime From = new DateTime(YEAR, 8, 1);
                    DateTime To = new DateTime(YEAR, 8, 31);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;

                }
                else if (Month == 8)
                {
                    MonthName = "SEPTEMBER";
                    DateTime From = new DateTime(YEAR, 9, 1);
                    DateTime To = new DateTime(YEAR, 9, 30);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;
                }
                else if (Month == 9)
                {
                    MonthName = "OCTOBER";
                    DateTime From = new DateTime(YEAR, 10, 1);
                    DateTime To = new DateTime(YEAR, 10, 31);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;
                }
                else if (Month == 10)
                {
                    MonthName = "NOVEMBER";
                    DateTime From = new DateTime(YEAR, 11, 1);
                    DateTime To = new DateTime(YEAR, 11, 30);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;
                }
                else if (Month == 11)
                {
                    MonthName = "DECEMBER";
                    DateTime From = new DateTime(YEAR, 12, 1);
                    DateTime To = new DateTime(YEAR, 12, 31);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;

                }
                DataTable dtVisaQuota = new DataTable();
                dtVisaQuota = objBussinessEmployeRecruitment.ReadEmployeeRecruitment(objEntityLayerHcmCommon);
                count = dtVisaQuota.Rows[0][0].ToString();
                if (count != "0")
                {

                    strHtml += "<tr  >";

                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + MonthName + "</td>";

                    strHtml += "<td class=\"tdT\" style=\" width:40%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + count + "</td>";

                    strHtml += "</tr>";
                }


            }
        }
        else
        {
            strHtml += "<tr  >";
            strHtml += "<td  class=\"tdT\" colspan=\"2\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
            strHtml += "</tr>";
        }
        strHtml += "</tbody>";

        strHtml += "</table>";


        sb.Append(strHtml);
        return sb.ToString();
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
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.EMPLOYEE_RECRUITMENT_CSV);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
            string newFilePath = Server.MapPath("/CustomFiles/HCM CSV/Employee Recruitment/Employee_Recruitment_Report_" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "Employee_Recruitment_Report_" + strNextId + ".csv";
            Response.ContentType = "csv";
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.EMPLOYEE_RECRUITMENT_CSV);
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
        clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport = new clsEntityEmployeeDetailsReport();
        DataTable table = new DataTable();
        table.Columns.Add("MONTH", typeof(string));
        table.Columns.Add("NO.OF EMPLOYEES RECRUITED ", typeof(string));


        ClsEntity_HCM_Common objEntityLayerHcmCommon = new ClsEntity_HCM_Common();
        ClsBusiness_Employee_Recruitment_Report objBussinessEmployeRecruitment = new ClsBusiness_Employee_Recruitment_Report();
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLayerHcmCommon.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityLayerHcmCommon.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        int intUserId = 0;
        if (Session["USERID"] != null)
        {
            objEntityLayerHcmCommon.UserId = Convert.ToInt32(Session["USERID"].ToString());
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
          int Tdayyear = 0;
        if (ddlYear.SelectedItem.Value != "--SELECT--")
        {
            objEntityLayerHcmCommon.Year = Convert.ToInt32(ddlYear.SelectedItem.Value);
            Tdayyear = Convert.ToInt32(ddlYear.SelectedItem.Value);

           // DataTable dtVisaQuota = new DataTable();
           // string strHtm = ConvertDataTableToHTML(objEntityLayerHcmCommon.Year);
      
           // string strPrintReport = ConvertDataTableForPrint(dtVisaQuota, objEntityLayerHcmCommon.Year);

          //  divPrintReport.InnerHtml = strPrintReport;
        }

        else
        {
             Tdayyear = 0;
            //DateTime.Today.Year;
         //   DataTable dtVisaQuota = new DataTable();
          //  string strHtm = ConvertDataTableToHTML(Tdayyear);
           
           // string strPrintReport = ConvertDataTableForPrint(dtVisaQuota, objEntityLayerHcmCommon.Year);

           // divPrintReport.InnerHtml = strPrintReport;
        }




        string strId = Convert.ToString(Tdayyear);
        if (Tdayyear != 0)
        {

            for (int Month = 0; Month < 11; Month++)
            {
                string count = "";
                string MonthName = "";
                if (Month == 0)
                {
                    MonthName = "JANUARY";

                    DateTime From = new DateTime(Tdayyear, 1, 1);
                    DateTime To = new DateTime(Tdayyear, 1, 31);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;
                }

                else if (Month == 1)
                {

                    MonthName = "FEBRUARY";
                    DateTime From = new DateTime(Tdayyear, 2, 1);
                    objEntityLayerHcmCommon.FrmDate = From;
                    if (DateTime.IsLeapYear(Tdayyear))
                    {
                        DateTime To = new DateTime(Tdayyear, 2, 29);
                        objEntityLayerHcmCommon.ToDate = To;

                    }
                    else
                    {
                        DateTime To = new DateTime(Tdayyear, 2, 28);
                        objEntityLayerHcmCommon.ToDate = To;


                    }
                }
                else if (Month == 2)
                {
                    MonthName = "MARCH";
                    DateTime From = new DateTime(Tdayyear, 3, 1);
                    DateTime To = new DateTime(Tdayyear, 3, 31);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;

                }
                else if (Month == 3)
                {
                    MonthName = "APRIL";
                    DateTime From = new DateTime(Tdayyear, 4, 1);
                    DateTime To = new DateTime(Tdayyear, 4, 30);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;

                }
                else if (Month == 4)
                {
                    MonthName = "MAY";
                    DateTime From = new DateTime(Tdayyear, 5, 1);
                    DateTime To = new DateTime(Tdayyear, 5, 31);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;

                }
                else if (Month == 5)
                {
                    MonthName = "JUNE";
                    DateTime From = new DateTime(Tdayyear, 6, 1);
                    DateTime To = new DateTime(Tdayyear, 6, 30);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;

                }
                else if (Month == 6)
                {
                    MonthName = "JULY";
                    DateTime From = new DateTime(Tdayyear, 7, 1);
                    DateTime To = new DateTime(Tdayyear, 7, 31);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;

                }
                else if (Month == 7)
                {
                    MonthName = "AUGUST";
                    DateTime From = new DateTime(Tdayyear, 8, 1);
                    DateTime To = new DateTime(Tdayyear, 8, 31);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;

                }
                else if (Month == 8)
                {
                    MonthName = "SEPTEMBER";
                    DateTime From = new DateTime(Tdayyear, 9, 1);
                    DateTime To = new DateTime(Tdayyear, 9, 30);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;

                }
                else if (Month == 9)
                {
                    MonthName = "OCTOBER";
                    DateTime From = new DateTime(Tdayyear, 10, 1);
                    DateTime To = new DateTime(Tdayyear, 10, 31);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;

                }
                else if (Month == 10)
                {
                    MonthName = "NOVEMBER";
                    DateTime From = new DateTime(Tdayyear, 11, 1);
                    DateTime To = new DateTime(Tdayyear, 11, 30);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;
                }
                else if (Month == 11)
                {
                    MonthName = "DECEMBER";
                    DateTime From = new DateTime(Tdayyear, 12, 1);
                    DateTime To = new DateTime(Tdayyear, 12, 31);
                    objEntityLayerHcmCommon.FrmDate = From;
                    objEntityLayerHcmCommon.ToDate = To;
                }

                DataTable dtVisaQuota = new DataTable();
                dtVisaQuota = objBussinessEmployeRecruitment.ReadEmployeeRecruitment(objEntityLayerHcmCommon);
                count = dtVisaQuota.Rows[0][0].ToString();

                string RcMonth = "";
                string EmpRecruted = "";

                if (count != "0")
                {
                    RcMonth = MonthName;
                    EmpRecruted = count;

                }
                if (RcMonth != "" && EmpRecruted != "")
                {
                    table.Rows.Add('"' + RcMonth + '"', '"' + EmpRecruted + '"');
                }
            }
        }
        return table;
    }
}











