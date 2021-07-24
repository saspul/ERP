using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using BL_Compzit;
using CL_Compzit;
using System.Globalization;
using System.Data;
using System.Text;
using System.Web.Services;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
public partial class Reports_gen_Sales_Executive_Booking_Report_gen_Sales_Executive_Booking_Report : System.Web.UI.Page
{
    public static string strHead = ""; 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clsEntityReports ObjLeadReport = new clsEntityReports();
            clsBusinessLayerReports ObjBussinessReports = new clsBusinessLayerReports();
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                ObjLeadReport.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                ObjLeadReport.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                ObjLeadReport.User_Id = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                               clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                                  };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            }

            string strMonth = DateTime.Now.Month.ToString();
            BindDdlMonths(strMonth);
            string strQuarter = "";
            strQuarter= SelectQuarter(strMonth);
            if (strQuarter != "")
            {
                ddlQuarterName.InnerHtml = "Quarter " + strQuarter;
                ddlQuarter.InnerHtml = strQuarter;
            }
            BindDdlCustomer();
            string strYear = DateTime.Today.Year.ToString();
            BindDdlYears(strYear);
            ObjLeadReport.Year = Convert.ToInt32(strYear);
            ReadCurrency();
        }
    }
    public static string SelectQuarter(string strMonth = null)
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
        else if (intMonth == 7 || intMonth == 8 || intMonth ==9)
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
        currentYear = currentYear + 10;
        StringBuilder sb = new StringBuilder();
        for (int i = 20; i >= 0; i--)
        {
            if ((strYear == (currentYear - i).ToString()) && (strYear != null))
            {
                sb.Append("<button id=\"btnYear" + i + "\" class=\"y" + i + " clsYear act\" onclick=\"return ClickYear(" + i + ");\">" + (currentYear - i) + "</button>");
            }
            else
            {
                sb.Append("<button id=\"btnYear" + i + "\" class=\"y" + i + " clsYear\" onclick=\"return ClickYear(" + i + ");\">" + (currentYear - i) + "</button>");
            }
        }
        ddlYears.InnerHtml = strYear;
        divddlYears.InnerHtml = sb.ToString();
    }
    public void BindDdlMonths(string strMonth=null)
    {
        var monthfull = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
        var months = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames;
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < months.Length - 1; i++)
        {
            if (strMonth != null && strMonth == (i + 1).ToString())
            {
                sb.Append("<button id=\"btnMnth_" + i + "\" class=\"m" + i + " clsMnth act\" onclick=\"return ClickMonth(" + i + ");\">" + months[i] + "</button>");
                ddlMonthName.InnerHtml = months[i];
                ddlMonths.InnerHtml = (i + 1).ToString();
            }
            else
            {
                sb.Append("<button id=\"btnMnth_" + i + "\" class=\"m" + i + " clsMnth\" onclick=\"return ClickMonth(" + i + ");\">" + months[i] + "</button>");
            }
        }
        divddlMonths.InnerHtml = sb.ToString();
    }
    public void BindDdlCustomer()
    {
        clsEntityReports ObjLeadReport = new clsEntityReports();
        clsBusinessLayerReports ObjBussinessReports = new clsBusinessLayerReports();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjLeadReport.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjLeadReport.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            ObjLeadReport.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtProject = ObjBussinessReports.ReadCustomerForBookingReport(ObjLeadReport);
        if (dtProject.Rows.Count > 0)
        {
            ddlCustomer.DataSource = dtProject;
            ddlCustomer.DataTextField = "CSTMR_NAME";
            ddlCustomer.DataValueField = "CSTMR_ID";
            ddlCustomer.DataBind();
        }
        ddlCustomer.Items.Insert(0, "--ALL--");
    }
    //It build the Html table by using the datatable provided
    public static string ConvertDataTableToHTML(DataTable dt, string strType, clsEntityReports ObjLeadReport)
    {

        int intCurrentQtr = 0, intMonthQtr = 0, intPrevQtr = 0, intIncrmntQtr = 1, intQtrRowCounter=0;
        decimal decQtrTotal = 0;
        string[] strArrQtr = new string[5];
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strRandom = objCommon.Random_Number();
        clsBusinessLayerReports ObjBussinessReports = new clsBusinessLayerReports();
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                               clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                                  };
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, ObjLeadReport.Corporate_Id);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
        } 
        if (strType != "Monthly")
        {
            
            strArrQtr[1] = dt.Select("MONTH = '01'  OR MONTH = '02' OR MONTH = '03'").Length.ToString();
            strArrQtr[2] = dt.Select("MONTH = '04' OR MONTH = '05' OR MONTH = '06'").Length.ToString();
            strArrQtr[3] = dt.Select("MONTH = '07' OR MONTH = '08' OR MONTH = '09'").Length.ToString();
            strArrQtr[4] = dt.Select("MONTH = '10' OR MONTH = '11' OR MONTH = '12'").Length.ToString();
        }
        StringBuilder sb = new StringBuilder();
        string strHtml = "";
        decimal intTotal = 0;
        int count = 1;
        if (dt.Rows.Count > 0)
        {
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            if (dt.Rows[intRowBodyCount]["LDQUOT_ID"].ToString() != "")
            {
                ObjLeadReport.LdQtnId = Convert.ToInt32(dt.Rows[intRowBodyCount]["LDQUOT_ID"].ToString());
            }
            DataTable dtGrp = ObjBussinessReports.ReadGroupAmount(ObjLeadReport);

            strHtml += "<tr  >";
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                DateTime dateExDate = DateTime.MinValue;
                string strCurrentDate = objBusiness.LoadCurrentDateInString();
                DateTime dateCurrntdte = objCommon.textToDateTime(strCurrentDate);
                int intGrpCount = 0;

                if (intColumnBodyCount == 0)
                {
                    strHtml += "<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    if (strType != "1")
                    {
                        //<td rowspan="2">$50</td>


                        //row span
                        intMonthQtr = Convert.ToInt32(SelectQuarter(dt.Rows[intRowBodyCount][5].ToString()));

                        //if (intCurrentQtr <= intMonthQtr)
                        //{
                            intQtrRowCounter = intQtrRowCounter + Convert.ToInt32(strArrQtr[intMonthQtr]);
                            //rowspan=" + strArrQtr[intMonthQtr] + "
                            strHtml += "<td class=\"tr_c\"  style=\"word-break: break-all; word-wrap:break-word;\" >QUARTER " + intMonthQtr + "</td>";
                            intCurrentQtr = intMonthQtr + 1;

                        //}

                        DateTime dateMonth = Convert.ToDateTime(dt.Rows[intRowBodyCount][8]);
                        strHtml += "<td class=\"tr_c\" style=\"word-break: break-all; word-wrap:break-word;\" >" + String.Format("{0:MMM }", dateMonth).ToUpper() + "</td>";
                    }
                }
                else if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][3].ToString() + "</td>";
                }



                else if (intColumnBodyCount == 3)
                {
                strHtml += "<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >";

                if (dt.Rows[intRowBodyCount][6].ToString() == "SUCCESS")
                {
                   strHtml += "<div class=\"bo_not1 mrl_bon flt_l\">";
                   strHtml += "<i class=\"fa fa-square\"></i></div> Win</td>";
                }
                else if (dt.Rows[intRowBodyCount][6].ToString() == "PARTIAL WIN")
                {
                    strHtml += "<div class=\"bo_not2 mrl_bon flt_l\" title=\"Partially win\">";
                 strHtml += "<i class=\"fa fa-square\"></i></div> PARTIALLY WIN</td>";
                }
                else if (dt.Rows[intRowBodyCount][6].ToString() == "LOSS")
                {
                    strHtml += "<div class=\"bo_not3 mrl_bon flt_l\" title=\"Loss\">";
                    strHtml += " <i class=\"fa fa-square\"></i></div> LOSS</td>";
                }
                else
                {
                    strHtml += ""+dt.Rows[intRowBodyCount][6].ToString()+"</td>";
                }
                  
                }
                else if (intColumnBodyCount == 4)
                {                  
                    strHtml += "<td style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][7].ToString() + "</td>";
                }



                else if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][1].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 6)
                {
                    decimal intGroupAmount = 0;
                    if (dtGrp.Rows.Count > 0)
                    {
                        strHtml += "<td class=\"tr_r\" style=\"word-break: break-all;padding: 0px; word-wrap:break-word;text-align: right;\"><table cellspacing=\"0\" style=\"width: 100%;\" cellpadding=\"2px\">";
                        for (int intLoopCount = 0; intLoopCount < dtGrp.Rows.Count; intLoopCount++)
                        {
                            if (intGroupAmount < Convert.ToDecimal(dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"]))
                            {
                                intGroupAmount = Convert.ToDecimal(dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"]);
                            }
                            ObjLeadReport.GroupName = dtGrp.Rows[intLoopCount]["QTNDTLGRP_NAME"].ToString();
                            strHtml += "<tr style=\"background-color: inherit !important;\"><td class=\"tr_r\" style=\" width:100%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;padding-right: 0px;padding-left: 0px;text-align: right; \" >" + dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"].ToString() + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"] + "(" + dtGrp.Rows[intLoopCount]["QTNDTLGRP_NAME"].ToString() + ")</td></tr>";
                        }
                        strHtml += "</table></td>";
                        intTotal = intTotal + intGroupAmount;
                        decQtrTotal = decQtrTotal + intGroupAmount;
                    }
                    else
                    {
                        string strNetAmount = dt.Rows[intRowBodyCount][4].ToString();
                        string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);

                        strHtml += "<td class=\"tr_r\" style=\"word-break: break-all; word-wrap:break-word;\" >" + strNetAmountWithComma.ToString() + "   " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";
                        if (dt.Rows[intRowBodyCount][4].ToString() != "" && dt.Rows[intRowBodyCount][4].ToString() != null)
                        {
                            intTotal = intTotal + Convert.ToDecimal(dt.Rows[intRowBodyCount][4].ToString());
                            decQtrTotal = decQtrTotal + Convert.ToDecimal(dt.Rows[intRowBodyCount][4].ToString());
                        }
                    }
                }

            }

            strHtml += "</tr>";
            if (strType == "3")
            {
                if (intQtrRowCounter == (intRowBodyCount + 1))
                {
                    strHtml += "<tr style=\"background-color:#eceff1!important;\">";

                    strHtml += "<td  class=\"tr_l\" colspan=\"8\">QUARTER " + intMonthQtr + " SUB TOTAL</td>";
                    strHtml += "<td  class=\"tr_r\" >" + decQtrTotal + "   " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";
                    decQtrTotal = 0;


                    strHtml += "</tr>";
                    intIncrmntQtr++;
                }
            }
            

        }
        if (intTotal != 0)
        {

            strHtml += "<tr style=\"background-color:#eceff1!important;\">";


            if (strType != "1")
            {
                strHtml += "<td  class=\"txt_rd bg1 tr_l\"  style=\"background-color:#eceff1!important;\" colspan=\"8\">TOTAL</td>";


            }
            else
            {
                strHtml += "<td class=\"txt_rd bg1 tr_l\" style=\"background-color:#eceff1!important;\" colspan=\"6\" >TOTAL</td>";

            }


            string strNetAmount = intTotal.ToString();
            string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
            strHtml += "<td class=\"txt_rd bg1 tr_r\" >" + strNetAmountWithComma.ToString() + "   " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";
            strHtml += "</tr>";
        }

        }
        else
        {
            if (strType != "1")
            {
                strHtml += "<td class=\"tr_c\" colspan=\"9\">No data available in table</td>";
            }
            else
            {
                strHtml += "<td class=\"tr_c\" colspan=\"7\">No data available in table</td>";
            }
        }
        return strHtml;
    }
    //evm-0020
    public void ReadCurrency()
    {
        ddlCurrency.Items.Clear();

        clsBusinessLayerReports ObjBussinessReport = new clsBusinessLayerReports();
        clsEntityReports ObjEntityLeadDiv = new clsEntityReports();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityLeadDiv.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityLeadDiv.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        DataTable dtTerms = ObjBussinessReport.ReadCurrencyLoad(ObjEntityLeadDiv);
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.COUNTRY_ICON_IMAGES);
        string strCntryDDL = "";
        for (int i = 0; i < dtTerms.Rows.Count; i++)
        {
            if (dtTerms.Rows[i]["CRNCMST_ID"].ToString() == hiddenDfltCurrencyMstrId.Value)
            {
                if (dtTerms.Rows[i]["CNTRY_FLAG_ICON_NAME"].ToString() != "")
                {
                    strCntryDDL += "<option selected=\"\" value=\"" + dtTerms.Rows[i]["CRNCMST_ID"].ToString() + "\" data-image=\"" + strImagePath + dtTerms.Rows[i]["CNTRY_FLAG_ICON_NAME"].ToString() + "\"  data-imagecss=\"flag\" data-title=\"" + dtTerms.Rows[i]["CRNCMST_NAME"].ToString() + "\">" + dtTerms.Rows[i]["CRNCMST_NAME"].ToString() + "</option>";
                }
                else
                {
                    strCntryDDL += "<option selected=\"\" value=\"" + dtTerms.Rows[i]["CRNCMST_ID"].ToString() + "\">" + dtTerms.Rows[i]["CRNCMST_NAME"].ToString() + "</option>";
                }
            }
            else
            {
                if (dtTerms.Rows[i]["CNTRY_FLAG_ICON_NAME"].ToString() != "")
                {
                    strCntryDDL += "<option value=\"" + dtTerms.Rows[i]["CRNCMST_ID"].ToString() + "\" data-image=\"" + strImagePath + dtTerms.Rows[i]["CNTRY_FLAG_ICON_NAME"].ToString() + "\"  data-imagecss=\"flag\" data-title=\"" + dtTerms.Rows[i]["CRNCMST_NAME"].ToString() + "\">" + dtTerms.Rows[i]["CRNCMST_NAME"].ToString() + "</option>";
                }
                else
                {
                    strCntryDDL += "<option value=\"" + dtTerms.Rows[i]["CRNCMST_ID"].ToString() + "\">" + dtTerms.Rows[i]["CRNCMST_NAME"].ToString() + "</option>";
                }
            }
        }
        HiddenFieldCurrencyDdl.Value = strCntryDDL;
    }

    [WebMethod]
    public static string[] GetData(string OrgId, string CorpId, string UserId, string Customer, string Currency, string Year, string Month, string Quarter, string Mode, string PageNumber, string PageMaxSize, string strCommonSearchTerm, string OrderColumn, string OrderMethod, string strInputColumnSearch)
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        clsBusinessLayerReports ObjBussinessReport = new clsBusinessLayerReports();
        clsEntityReports ObjLeadReport = new clsEntityReports();

        clsCommonLibrary objCommon = new clsCommonLibrary();

        string[] strResults = new string[3];
        try
        {
            if (OrgId != null && OrgId != "")
            {
                ObjLeadReport.Organisation_Id = Convert.ToInt32(OrgId);
            }
            if (CorpId != null && CorpId != "")
            {
                ObjLeadReport.Corporate_Id = Convert.ToInt32(CorpId);
            }
            if (UserId != null && UserId != "")
            {
                ObjLeadReport.User_Id = Convert.ToInt32(UserId);
            }

            if (Customer != "" && Customer != "--ALL--")
            {
                ObjLeadReport.CustomerId = Convert.ToInt32(Customer);
            }
            if (Currency != "" && Currency != "--SELECT CURRENCY--")
            {
                ObjLeadReport.CurrencyId = Convert.ToInt32(Currency);
            }
            ObjLeadReport.Year = Convert.ToInt32(Year);
            if (Mode == "1" && Month != "")//Monthly
            {
                ObjLeadReport.Month = String.Format("{0:D2}", Convert.ToInt32(Month));
            }
            else
            {
                ObjLeadReport.Month = null;
            }
            if (Mode == "2" && Quarter != "")//Quarterly
            {
                ObjLeadReport.Quarter = Convert.ToInt32(Quarter);
            }
            else
            {
                ObjLeadReport.Quarter = 0;
            }
            ObjLeadReport.PageNumber = Convert.ToInt32(PageNumber);
            ObjLeadReport.PageMaxSize = Convert.ToInt32(PageMaxSize);
            ObjLeadReport.OrderMethod = Convert.ToInt32(OrderMethod);
            ObjLeadReport.OrderColumn = Convert.ToInt32(OrderColumn);
            ObjLeadReport.CommonSearchTerm = strCommonSearchTerm;

            var values = Enum.GetValues(typeof(SearchInputColumns));
            int intSearchColumnCount = values.Length;

            string[] strSearchInputs = new string[intSearchColumnCount];
            //— ^
            if (strInputColumnSearch != "")
            {
                string[] InputColumnSearchList = strInputColumnSearch.Split('—');
                foreach (var InputColumnSearch in InputColumnSearchList)
                {
                    string[] strColumnSrch = InputColumnSearch.Split('^');
                    int intColumnNo = Convert.ToInt32(strColumnSrch[0]);
                    string strSearchString = strColumnSrch[1];

                    if (intColumnNo <= intSearchColumnCount)
                    {
                        strSearchInputs[intColumnNo] = strSearchString;
                    }
                }
            }

            ObjLeadReport.SearchRef = strSearchInputs[Convert.ToInt32(SearchInputColumns.REF)];
            if (Mode != "1")
            {
                ObjLeadReport.SearchQuarter = strSearchInputs[Convert.ToInt32(SearchInputColumns.QUARTER)];
                ObjLeadReport.SearchMonth = strSearchInputs[Convert.ToInt32(SearchInputColumns.MONTH)];
            }
            ObjLeadReport.SearchProject = strSearchInputs[Convert.ToInt32(SearchInputColumns.PROJECT)];
            ObjLeadReport.SearchCustomer = strSearchInputs[Convert.ToInt32(SearchInputColumns.CUSTOMER)];
            ObjLeadReport.SearchQuotRef = strSearchInputs[Convert.ToInt32(SearchInputColumns.QUOTREF)];

            ObjLeadReport.SearchStatus = strSearchInputs[Convert.ToInt32(SearchInputColumns.STATUS)];
            //ReadList
            DataTable dt = ObjBussinessReport.ReadSalesExecutiveBkngRpt(ObjLeadReport);

            string strTableContents = "";
            strTableContents = ConvertDataTableToHTML(dt, Mode, ObjLeadReport);
            strResults[0] = strTableContents;

            strResults[1] = "0";
            if (dt.Rows.Count > 0)
            {
                int intTotalItems = Convert.ToInt32(dt.Rows[0]["CNT"].ToString());
                int intCurrentRowCount = dt.Rows.Count;

                strResults[1] = intTotalItems.ToString();
                //Pagination
                strResults[2] = objBusinessLayer.GenereatePagination(intTotalItems, ObjLeadReport.PageNumber, ObjLeadReport.PageMaxSize, intCurrentRowCount);
            }
        }
        catch (Exception ex)
        {
            clsBusineesLayerException objBusinessLayerException = new clsBusineesLayerException();
            objBusinessLayerException.ExceptionHandling(ex);
            throw ex;
        }

        return strResults;
    }

    [WebMethod]
    public static string[] LoadStaticDatafordt(string Mode)//Filters
    {
        StringBuilder html = new StringBuilder();
        StringBuilder sbSearchInputColumns = new StringBuilder();

        string[] strResults = new string[3];
        html.Append("<div>");

        html.Append("<div class=\"col-md-2\" style=\"padding-left: 0px;\">");//length
        html.Append("<label><span>Show</span> <select onchange=\"getdata(1);\" id=\"ddl_page_size\" style=\"height: 24px;margin: 0px 2px;margin-right: 2px;\">");
        html.Append("<option value=\"10\">10</option><option value=\"25\">25</option><option value=\"50\">50</option><option value=\"100\">100</option></select> entries");
        html.Append("</label></div>");
        //page length ends
        //common filter
        html.Append("<div class=\"pull-right\" style=\"padding-right: 0px;\">");
        html.Append("<label>Search:");
        html.Append("<input  autocomplete=\"off\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"SettypingTimer(event);\" class=\"tbl_fil_s\" id=\"txtCommonSearch_dt\"  type=\"search\" aria-controls=\"example\">");
        html.Append("</label>");
        html.Append("</div>");
        //common filter ends
        html.Append("</div>");
        strResults[0] = html.ToString();

        //custom search fields
        var values = Enum.GetValues(typeof(SearchInputColumns));
        int intSearchColumnCount = values.Length;

        if (Mode == "1")
        {
            foreach (var item in values)
            {
                int Item = Convert.ToInt32(item);
                // use item number to customize names using if
                if (Item.ToString() == "0")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_1\" class=\"sorting th_b5 tr_l\" onclick=\"SetOrderByValue(1)\" style=\"word-wrap:break-word;\">Ref#<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Ref#\" title=\"Ref#\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\"></th>");
                }
                else if (Item.ToString() == "3")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_3\" class=\"sorting th_b8 tr_l\" onclick=\"SetOrderByValue(3)\" style=\"word-wrap:break-word;\">Project<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Project\" title=\"Project\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\"></th>");
                }
                else if (Item.ToString() == "4")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_4\" class=\"sorting th_b8 tr_l\" onclick=\"SetOrderByValue(4)\" style=\"word-wrap:break-word;width: 8% !important;\">Customer<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Customer\" title=\"Customer\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\"></th>");
                }
                else if (Item.ToString() == "5")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_7\" class=\"sorting th_b5 tr_l\" onclick=\"SetOrderByValue(7)\" style=\"word-wrap:break-word;width: 4% !important;\">Status<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Status\" title=\"Status\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\"></th>");
                }
            }
            sbSearchInputColumns.Append("<th id=\"tdColumnHead_8\" class=\"sorting th_b5\" onclick=\"SetOrderByValue(8)\" style=\"word-wrap:break-word;\">LAST<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br>UPDATION</th>");
           foreach (var item in values)
            {
                int Item = Convert.ToInt32(item);
                if (Item.ToString() == "6")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_2\" class=\"sorting th_b5 tr_l\" onclick=\"SetOrderByValue(2)\" style=\"word-wrap:break-word;\">Quote Ref#<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Quote Ref#\" title=\"Quote Ref#\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\"></th>");
                }
            }
            sbSearchInputColumns.Append("<th id=\"tdColumnHead_9\" class=\"th_b5 tr_r\">Quote Value</th>");
        }
        else if (Mode == "2")
        {
            foreach (var item in values)
            {
                int Item = Convert.ToInt32(item);
                // use item number to customize names using if
                if (Item.ToString() == "0")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_1\" onclick=\"SetOrderByValue(1)\" class=\"sorting th_b5 tr_l\">Ref#<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Ref#\" title=\"Ref#\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\"></th>");
                }
                else if (Item.ToString() == "1")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_6\" onclick=\"SetOrderByValue(6)\" class=\"sorting th_b1\">Quarter<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in tr_c\" placeholder=\"Quarter\" title=\"Quarter\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\"></th>");
                }
                else if (Item.ToString() == "2")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_7\" onclick=\"SetOrderByValue(7)\" class=\"sorting th_b1\">Month<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in tr_c\" placeholder=\"Month\" title=\"Month\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\"></th>");
                }
                else if (Item.ToString() == "3")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_3\" onclick=\"SetOrderByValue(3)\" class=\"sorting th_b8 tr_l\">Project<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Project\" title=\"Project\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\"></th>");
                }
                else if (Item.ToString() == "4")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_4\" onclick=\"SetOrderByValue(4)\" class=\"sorting th_b8 tr_l\">Customer<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Customer\" title=\"Customer\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\"></th>");
                }

                else if (Item.ToString() == "5")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_7\" class=\"sorting th_b1 tr_l\" onclick=\"SetOrderByValue(7)\" style=\"word-wrap:break-word;\">Status<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Status\" title=\"Status\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\"></th>");
                }
            }
            sbSearchInputColumns.Append("<th id=\"tdColumnHead_8\" class=\"th_b5\" onclick=\"SetOrderByValue(8)\" style=\"word-wrap:break-word;\">LAST<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br>UPDATION</th>");
            foreach (var item in values)
            {
                int Item = Convert.ToInt32(item);
                if (Item.ToString() == "6")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_2\" onclick=\"SetOrderByValue(2)\" class=\"sorting th_b1 tr_l\">Quote Ref#<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Quote Ref#\" title=\"Quote Ref#\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\"></th>");
                }
            }
            sbSearchInputColumns.Append("<th id=\"tdColumnHead_9\" class=\"th_b1 tr_r\">Quote Value</th>");
        }
        else if (Mode == "3")
        {
            foreach (var item in values)
            {
                int Item = Convert.ToInt32(item);
                // use item number to customize names using if
                if (Item.ToString() == "0")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_1\" class=\"sorting th_b5 tr_l\">Ref#");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Ref#\" title=\"Ref#\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\">");
                    sbSearchInputColumns.Append("</th>");
                }
                else if (Item.ToString() == "1")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_6\" class=\"sorting th_b1\">Quarter");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in tr_c\" placeholder=\"Quarter\" title=\"Quarter\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\">");
                    sbSearchInputColumns.Append("</th>");
                }
                else if (Item.ToString() == "2")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_7\" class=\"sorting th_b1\">Month");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in tr_c\" placeholder=\"Month\" title=\"Month\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\">");
                    sbSearchInputColumns.Append("</th>");
                }
                else if (Item.ToString() == "3")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_3\" class=\"sorting th_b8 tr_l\">Project<br>");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Project\" title=\"Project\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\">");
                    sbSearchInputColumns.Append("</th>");
                }
                else if (Item.ToString() == "4")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_4\" class=\"sorting th_b8 tr_l\">Customer<br>");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Customer\" title=\"Customer\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\">");
                    sbSearchInputColumns.Append("</th>");
                }
                else if (Item.ToString() == "5")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_7\" class=\"sorting th_b1 tr_l\"  style=\"word-wrap:break-word;\">Status<br><input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Status\" title=\"Status\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\"></th>");
                }
            }
            sbSearchInputColumns.Append("<th id=\"tdColumnHead_8\" class=\"th_b5\"  style=\"word-wrap:break-word;\">LAST<br> UPDATION</th>");
            foreach (var item in values)
            {
                int Item = Convert.ToInt32(item);
                if (Item.ToString() == "6")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_2\" class=\"sorting th_b1 tr_l\">Quote Ref#<br>");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Quote Ref#\" title=\"Quote Ref#\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\">");
                    sbSearchInputColumns.Append("</th>");
                }
            }
            sbSearchInputColumns.Append("<th id=\"tdColumnHead_9\" class=\"th_b1 tr_r\">Quote Value</th>");
        }

        //this is to adjust the non search  fields
        strResults[1] = sbSearchInputColumns.ToString();
        strResults[2] = intSearchColumnCount.ToString();
        return strResults;
    }

    public enum SearchInputColumns
    {
        //Must be sequential 
        REF = 0,
        QUARTER = 1,
        MONTH = 2,
        PROJECT = 3,
        CUSTOMER = 4,
        STATUS=5,
        QUOTREF = 6,
    }

    //------------------------------------------Pagination------------------------------------------------

    [WebMethod]
    public static string PrintList(string OrgId, string CorpId, string UserId, string Customer, string Currency, string CustomerText, string CurrencyText, string Year, string Month, string Quarter, string YearText, string MonthText, string QuarterText, string Mode)
    {
        if(Mode=="1"){
            strHead = "Monthly ";
        }
        else if(Mode=="2"){
            strHead = "Quarterly ";
        }
        else{
            strHead = "Yearly ";
        }
      


        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        clsBusinessLayerReports ObjBussinessReport = new clsBusinessLayerReports();
        clsEntityReports ObjLeadReport = new clsEntityReports();

        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                               clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                                  };
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        if (OrgId != null && OrgId != "")
        {
            ObjLeadReport.Organisation_Id = Convert.ToInt32(OrgId);
        }
        if (CorpId != null && CorpId != "")
        {
            ObjLeadReport.Corporate_Id = Convert.ToInt32(CorpId);
        }
        if (UserId != null && UserId != "")
        {
            ObjLeadReport.User_Id = Convert.ToInt32(UserId);
        }

        if (Customer != "" && Customer != "--ALL--")
        {
            ObjLeadReport.CustomerId = Convert.ToInt32(Customer);
        }
        if (Currency != "" && Currency != "--SELECT CURRENCY--")
        {
            ObjLeadReport.CurrencyId = Convert.ToInt32(Currency);
        }

        ObjLeadReport.Year = Convert.ToInt32(Year);

        if (Mode == "1" && Month != "")//Monthly
        {
            ObjLeadReport.Month = String.Format("{0:D2}", Convert.ToInt32(Month));
        }
        else
        {
            ObjLeadReport.Month = null;
        }
        if (Mode == "2" && Quarter != "")//Quarterly
        {
            ObjLeadReport.Quarter = Convert.ToInt32(Quarter);
        }
        else
        {
            ObjLeadReport.Quarter = 0;
        }
        DataTable dt = ObjBussinessReport.ReadSalesExecutiveBkngRpt(ObjLeadReport);

        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, ObjLeadReport.Corporate_Id);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
        }

        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.BOOKING_SE_REPORT_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.BOOKING_SE_REPORT_PDF);
        objEntityCommon.CorporateID = ObjLeadReport.Corporate_Id;
        objEntityCommon.Organisation_Id = ObjLeadReport.Organisation_Id;
        string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "BookingSEReport_" + strNextNumber + ".pdf";

        Document document = new Document(PageSize.A4, 50f, 40f, 120f, 30f);
        document = new Document(PageSize.LETTER, 50f, 40f, 20f, 40f);
        Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
        try
        {
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                PdfWriter writer = PdfWriter.GetInstance(document, file);
                writer.PageEvent = new PDFHeader();
                document.Open();


                PdfPTable footrtable = new PdfPTable(3);
                float[] footrsBody1 = { 25, 5, 70 };
                footrtable.SetWidths(footrsBody1);
                footrtable.WidthPercentage = 100;

                footrtable.AddCell(new PdfPCell(new Phrase("YEAR  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(YearText, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                if (Mode == "1" && Month != "")//Monthly
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("MONTH  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(MonthText, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (Mode == "2" && Quarter != "")//Quarterly
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("QUARTER  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(QuarterText, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (Customer != "" && Customer != "--ALL--")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("CUSTOMER  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(CustomerText, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (Currency != "" && Currency != "--SELECT CURRENCY--")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("CURRENCY  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(CurrencyText, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }

                footrtable.AddCell(new PdfPCell(new Phrase("TOTAL NUMBER OF RECORDS  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(dt.Rows.Count.ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });


                footrtable.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                document.Add(footrtable);


                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(7);
                float[] footrsBody = { 15, 13, 15, 15, 13,13,16 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;

                string[] strArrQtr = new string[5];
                int intCurrentQtr = 0, intQtrRowCounter = 0;

                if (Mode != "1")
                {
                    TBCustomer = new PdfPTable(9);
                    float[] footrsSubBody = { 10, 12, 12, 11, 10, 10, 10,10,15 };
                    TBCustomer.SetWidths(footrsSubBody);
                    TBCustomer.WidthPercentage = 100;
                    TBCustomer.HeaderRows = 1;

                    strArrQtr[1] = dt.Select("MONTH = '01' OR MONTH = '02' OR MONTH = '03'").Length.ToString();
                    strArrQtr[2] = dt.Select("MONTH = '04' OR MONTH = '05' OR MONTH = '06'").Length.ToString();
                    strArrQtr[3] = dt.Select("MONTH = '07' OR MONTH = '08' OR MONTH = '09'").Length.ToString();
                    strArrQtr[4] = dt.Select("MONTH = '10' OR MONTH = '11' OR MONTH = '12'").Length.ToString();
                }

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("REF#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                if (Mode != "1")
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase("QUARTER", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("MONTH", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                }
                TBCustomer.AddCell(new PdfPCell(new Phrase("PROJECT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("CUSTOMER", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });

                TBCustomer.AddCell(new PdfPCell(new Phrase("STATUS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("LAST UPDATION", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });

                TBCustomer.AddCell(new PdfPCell(new Phrase("QUOTE REF#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("QUOTE VALUE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });

                decimal decQtrTotal = 0; int intMonthQtr = 0, intIncrmntQtr = 1;
                if (dt.Rows.Count > 0)
                {
                    decimal intTotal = 0;
                    for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
                    {
                        if (dt.Rows[intRowBodyCount]["LDQUOT_ID"].ToString() != "")
                        {
                            ObjLeadReport.LdQtnId = Convert.ToInt32(dt.Rows[intRowBodyCount]["LDQUOT_ID"].ToString());
                        }
                        DataTable dtGrp = ObjBussinessReport.ReadGroupAmount(ObjLeadReport);

                        TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount][0].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                        if (Mode != "1")
                        {
                            intMonthQtr = Convert.ToInt32(SelectQuarter(dt.Rows[intRowBodyCount][5].ToString()));
                            //if (intCurrentQtr <= intMonthQtr)
                            //{
                                intQtrRowCounter = intQtrRowCounter + Convert.ToInt32(strArrQtr[intMonthQtr]);
                                TBCustomer.AddCell(new PdfPCell(new Phrase("QUARTER " + intMonthQtr, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });//Rowspan = Convert.ToInt32(strArrQtr[intMonthQtr])
                                intCurrentQtr = intMonthQtr + 1;
                            //}
                            DateTime dateMonth = Convert.ToDateTime(dt.Rows[intRowBodyCount][8]);
                            TBCustomer.AddCell(new PdfPCell(new Phrase(String.Format("{0:MMM }", dateMonth).ToUpper(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }

                        TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount][2].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount][3].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


                      

                        if (dt.Rows[intRowBodyCount][6].ToString() == "SUCCESS")
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase("WIN", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });                          
                        }
                        else if (dt.Rows[intRowBodyCount][6].ToString() == "PARTIAL WIN")
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase("PARTIALLY WIN", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                        else
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount][6].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }


                        TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount][7].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount][1].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


                      


                        decimal intGroupAmount = 0;
                        if (dtGrp.Rows.Count > 0)
                        {
                            string rs = "";
                            for (int intLoopCount = 0; intLoopCount < dtGrp.Rows.Count; intLoopCount++)
                            {
                                if (intGroupAmount < Convert.ToDecimal(dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"]))
                                {
                                    intGroupAmount = Convert.ToDecimal(dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"]);
                                }
                                ObjLeadReport.GroupName = dtGrp.Rows[intLoopCount]["QTNDTLGRP_NAME"].ToString();

                                rs += dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"].ToString() + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"] + "(" + dtGrp.Rows[intLoopCount]["QTNDTLGRP_NAME"].ToString() + ")\n";
                            }
                            TBCustomer.AddCell(new PdfPCell(new Phrase(rs, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            intTotal = intTotal + intGroupAmount;
                            decQtrTotal = decQtrTotal + intGroupAmount;
                        }
                        else
                        {
                            string strNetAmount = dt.Rows[intRowBodyCount][4].ToString();
                            string strNetAmountWithComma = objBusinessLayer.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);

                            TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithComma.ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            if (dt.Rows[intRowBodyCount][4].ToString() != "" && dt.Rows[intRowBodyCount][4].ToString() != null)
                            {
                                intTotal = intTotal + Convert.ToDecimal(dt.Rows[intRowBodyCount][4].ToString());
                                decQtrTotal = decQtrTotal + Convert.ToDecimal(dt.Rows[intRowBodyCount][4].ToString());
                            }
                        }


                        if (Mode == "3")
                        {
                            if (intQtrRowCounter == (intRowBodyCount + 1))
                            {
                                TBCustomer.AddCell(new PdfPCell(new Phrase("QUARTER " + intMonthQtr+" SUB TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 8 });
                                TBCustomer.AddCell(new PdfPCell(new Phrase(decQtrTotal + " " + dt.Rows[0]["CRNCMST_ABBRV"].ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                decQtrTotal = 0;
                                intIncrmntQtr++;
                            }
                        }
                    }
                    if (intTotal != 0)
                    {
                        string strNetAmount = intTotal.ToString();
                        string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                        if (Mode != "1")
                            TBCustomer.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 8 });
                        else
                            TBCustomer.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 6 });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithComma.ToString() + " " + dt.Rows[0]["CRNCMST_ABBRV"].ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                    }


                }
                else
                {
                    if (Mode != "1")
                    TBCustomer.AddCell(new PdfPCell(new Phrase("No data available in table", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 9 });
                    else
                    TBCustomer.AddCell(new PdfPCell(new Phrase("No data available in table", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 7 });
                }
                document.Add(TBCustomer);
                document.Close();
                strRet = strImagePath + strImageName;
            }
        }
        catch (Exception)
        {
            document.Close();
            strRet = "";
        }
        return strRet;
    }
    public class PDFHeader : PdfPageEventHelper
    {
        PdfContentByte cb;
        PdfTemplate footerTemplate;
        BaseFont bf = null;
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
        public override void OnStartPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityCommon ObjEntityCommon = new clsEntityCommon();
            clsBusinessLayer objDataCommon = new clsBusinessLayer();
            ObjEntityCommon.CorporateID = Convert.ToInt32(HttpContext.Current.Session["CORPOFFICEID"].ToString());
            ObjEntityCommon.Organisation_Id = Convert.ToInt32(HttpContext.Current.Session["ORGID"].ToString());
            DataTable dtCorp = objDataCommon.ReadCorpDetails(ObjEntityCommon);
            string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "";
            string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DEFAULT_LOGO);
            if (dtCorp.Rows.Count > 0)
            {
                if (dtCorp.Rows[0]["CORPRT_ICON"].ToString() != "")
                {
                    string imaeposition = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
                    string icon = dtCorp.Rows[0]["CORPRT_ICON"].ToString();
                    strImageLogo = imaeposition + icon;
                }
                strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
                strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
                strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
                strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
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
            //Head Table
            PdfPTable headtable = new PdfPTable(2);
            headtable.AddCell(new PdfPCell(new Phrase(strHead+"Booking Report for Sales Executive", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            if (strImageLogo != "")
            {
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
                image.ScalePercent(PdfPCell.ALIGN_CENTER);
                image.ScaleToFit(60f, 40f);
                headtable.AddCell(new PdfPCell(image) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
            }
            else
            {
                headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            }
            headtable.AddCell(new PdfPCell(new Phrase(strCompanyName, new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            headtable.AddCell(new PdfPCell(new Phrase(strAddress, new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            headtable.AddCell(new PdfPCell(new Phrase("______________________________________________________________________________________________________", new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 2 });
            headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 2 });
            float[] headersHeading = { 80, 20 };
            headtable.SetWidths(headersHeading);
            headtable.WidthPercentage = 100;
            document.Add(headtable);
            PdfPTable tableLine = new PdfPTable(1);
            float[] tableLineBody = { 100 };
            tableLine.SetWidths(tableLineBody);
            tableLine.WidthPercentage = 100;
            tableLine.TotalWidth = 650F;
            tableLine.AddCell(new PdfPCell(new Phrase("_____________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
            float pos9 = writer.GetVerticalPosition(false);
        }
        public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            // base.OnEndPage(writer, document);
            string strUsername = HttpContext.Current.Session["USERFULLNAME"].ToString();
            PdfPTable table3 = new PdfPTable(1);
            float[] tableBody3 = { 100 };
            table3.SetWidths(tableBody3);
            table3.WidthPercentage = 100;
            table3.TotalWidth = 650F;
            table3.AddCell(new PdfPCell(new Phrase("_________________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
            // document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
            PdfPTable headImg = new PdfPTable(3);
            string strImageLogo = "/Images/Design_Images/images/Compztlogo.png";
            //headImg.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 3 });

            headImg.AddCell(new PdfPCell(new Phrase("______________________________________________________________________________________________________", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 3, PaddingTop = 5 });
            if (strImageLogo != "")
            {
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
                image.ScalePercent(PdfPCell.ALIGN_CENTER);
                image.ScaleToFit(60f, 40f);
                headImg.AddCell(new PdfPCell(image) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_TOP });
            }

            headImg.AddCell(new PdfPCell(new Paragraph("Report generated in Compzit by:" + strUsername + "\nReport generated on:" + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
            headImg.AddCell(new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 3 });
            float[] headersHeading = { 20, 60, 20 };
            headImg.SetWidths(headersHeading);
            headImg.WidthPercentage = 100;
            headImg.TotalWidth = document.PageSize.Width - 80f;

            headImg.WriteSelectedRows(0, -1, 50, document.PageSize.GetBottom(50), writer.DirectContent);

            String text = "Page " + writer.PageNumber + " of ";
            //Add paging to footer
            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.SetTextMatrix(document.PageSize.GetRight(100), document.PageSize.GetBottom(15));
                cb.ShowText(text);
                cb.EndText();
                float len = bf.GetWidthPoint(text, 8);
                cb.AddTemplate(footerTemplate, document.PageSize.GetRight(100) + len, document.PageSize.GetBottom(15));
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