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

public partial class Reports_gen_Division_Manager_Booking_Report_gen_Division_Manager_Booking_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clsBusinessLayerReports ObjBussinessReport = new clsBusinessLayerReports();
            clsEntityReports ObjEntityLeadDiv = new clsEntityReports();

            clsEntityReports ObjLeadReport = new clsEntityReports();
            clsBusinessLayerReports ObjBussinessReports = new clsBusinessLayerReports();
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                ObjEntityLeadDiv.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                ObjLeadReport.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                ObjEntityLeadDiv.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                ObjLeadReport.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {

                ObjEntityLeadDiv.User_Id = Convert.ToInt32(Session["USERID"]);
                // intUserId = Convert.ToInt32(Session["USERID"]);
                ObjLeadReport.User_Id = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            Response.Flush();
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
            strQuarter = SelectQuarter(strMonth);
            if (strQuarter != "")
            {
                //if (ddlQuarter.Items.FindByValue(strQuarter) != null)
                //{
                //    ddlQuarter.Items.FindByValue(strQuarter).Selected = true;
                //}
                ddlQuarterName.InnerHtml = "Quarter " + strQuarter;
                ddlQuarter.InnerHtml = strQuarter;
            }
            BindDdlCustomer();
            BindDdlSalesExecutive();
            //evm-20
            ReadCurrency();
            if (ObjLeadReport.CurrencyId != null)
            {
                ObjLeadReport.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            }

            string strYear = DateTime.Today.Year.ToString();
            BindDdlYears(strYear);

            //Yearly
            ObjLeadReport.Year = Convert.ToInt32(strYear);
            DataTable dtYearly = ObjBussinessReports.ReadDivisionManagerBkngRpt(ObjLeadReport);
            DataTable dtCorp = ObjBussinessReport.Read_Corp_Details(ObjEntityLeadDiv);

            //Monthly
            ObjLeadReport.Month = String.Format("{0:D2}", DateTime.Now.Month);
            DataTable dtMonthly = ObjBussinessReports.ReadDivisionManagerBkngRpt(ObjLeadReport);
            DataTable dtCorp1 = ObjBussinessReport.Read_Corp_Details(ObjEntityLeadDiv);

            //Quarterly
            ObjLeadReport.Quarter = Convert.ToInt32(strQuarter);
            ObjLeadReport.Month = null;
            DataTable dtQuarterly = ObjBussinessReports.ReadDivisionManagerBkngRpt(ObjLeadReport);
            DataTable dtCorp2 = ObjBussinessReport.Read_Corp_Details(ObjEntityLeadDiv);
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
        currentYear = currentYear + 10;

        StringBuilder sb = new StringBuilder();

        for (int i = 10; i > 0; i--)
        {
            //ddlYears.Items.Add((currentYear - i).ToString());

            if ((strYear == (currentYear - i).ToString()) && (strYear != null))//current year
            {
                sb.Append("<button id=\"btnYear" + i + "\" class=\"y" + i + " clsYear act\" onclick=\"return ClickYear(" + i + ");\">" + (currentYear - i) + "</button>");
            }
            else
            {
                sb.Append("<button id=\"btnYear" + i + "\" class=\"y" + i + " clsYear\" onclick=\"return ClickYear(" + i + ");\">" + (currentYear - i) + "</button>");
            }
        }
        //if (strYear != null)
        //{
        //    if (ddlYears.Items.FindByValue(strYear) != null)
        //    {
        //        ddlYears.Items.FindByValue(strYear).Selected = true;
        //    }
        //}

        ddlYears.InnerHtml = strYear;

        sb.Append("<div class=\"devider\"></div>");
        sb.Append("<button class=\"bck flt_l\" title=\"Back\" onclick=\"return PrvsYears(1," + (currentYear - 10) + ");\"><i class=\"fa fa-angle-left\"></i> </button>");
        sb.Append("<button class=\"nxt flt_r\" title=\"Next\" onclick=\"return NextYears(2," + (currentYear) + ");\"><i class=\"fa fa-angle-right\"></i></button>");

        divddlYears.InnerHtml = sb.ToString();

    }
    public void BindDdlMonths(string strMonth = null)
    {
        var monthfull = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
        var months = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames;

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < months.Length - 1; i++)
        {
            //ddlMonths.Items.Add(new System.Web.UI.WebControls.ListItem(months[i], (i + 1).ToString()));

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
        //if (strMonth != null)
        //{
        //    if (ddlMonths.Items.FindByValue(strMonth) != null)
        //    {
        //        ddlMonths.Items.FindByValue(strMonth).Selected = true;
        //    }
        //}
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
    public void BindDdlSalesExecutive()
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
        DataTable dtProject = ObjBussinessReports.ReadSalesExecutiveList(ObjLeadReport);
        if (dtProject.Rows.Count > 0)
        {
            ddlSalesExecutive.DataSource = dtProject;
            ddlSalesExecutive.DataTextField = "USR_NAME";
            ddlSalesExecutive.DataValueField = "USR_ID";
            ddlSalesExecutive.DataBind();

        }

        ddlSalesExecutive.Items.Insert(0, "--ALL--");
    }
    //It build the Html table by using the datatable provided
    public static string ConvertDataTableToHTML(DataTable dt, string strType, clsEntityReports ObjLeadReport)
    {
        int intCurrentQtr = 0, intMonthQtr = 0, intPrevQtr = 0, intIncrmntQtr = 1, intQtrRowCounter = 0;
        decimal decQtrTotal = 0;
        string[] strArrQtr = new string[5];

        clsEntityCommon objEntityCommon = new clsEntityCommon();

        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon ObjEntityCommon = new clsEntityCommon();
        clsBusinessLayerReports ObjBussinessReports = new clsBusinessLayerReports();

        string strRandom = objCommon.Random_Number();

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                               clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                                  };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, ObjLeadReport.Corporate_Id);
        if (dtCorpDetail.Rows.Count > 0)
        {
            ObjEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
        }

        if (strType != "1")//1=monthly,2=quarterly,3=yearly
        {
            strArrQtr[1] = dt.Select("MONTH = '01' OR MONTH = '02' OR MONTH = '03'").Length.ToString();
            strArrQtr[2] = dt.Select("MONTH = '04' OR MONTH = '05' OR MONTH = '06'").Length.ToString();
            strArrQtr[3] = dt.Select("MONTH = '07' OR MONTH = '08' OR MONTH = '09'").Length.ToString();
            strArrQtr[4] = dt.Select("MONTH = '10' OR MONTH = '11' OR MONTH = '12'").Length.ToString();
        }

        StringBuilder sb = new StringBuilder();

        string strHtml = "";

        if (dt.Rows.Count > 0)
        {
            decimal intTotal = 0;
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                if (dt.Rows[intRowBodyCount]["LDQUOT_ID"].ToString() != "")
                {
                    ObjLeadReport.LdQtnId = Convert.ToInt32(dt.Rows[intRowBodyCount]["LDQUOT_ID"].ToString());
                }
                DataTable dtGrp = ObjBussinessReports.ReadGroupAmount(ObjLeadReport);

                strHtml += "<tr>";
                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    DateTime dateExDate = DateTime.MinValue;
                    string strCurrentDate = objBusiness.LoadCurrentDateInString();
                    DateTime dateCurrntdte = objCommon.textToDateTime(strCurrentDate);

                    if (intColumnBodyCount == 0)
                    {
                        strHtml += "<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        if (strType != "1")
                        {
                            intMonthQtr = Convert.ToInt32(dt.Rows[intRowBodyCount]["QUARTER"].ToString());
                            //if (intCurrentQtr <= intMonthQtr)
                            //{
                            //rowspan=" + strArrQtr[intMonthQtr] + "
                                intQtrRowCounter = intQtrRowCounter + Convert.ToInt32(strArrQtr[intMonthQtr]);
                                strHtml += "<td class=\"tr_c\"  style=\"word-break: break-all; word-wrap:break-word;\" >QUARTER " + intMonthQtr + "</td>";
                                intCurrentQtr = intMonthQtr + 1;
                            //}
                            strHtml += "<td class=\"tr_c\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount]["MONTH_NAME"].ToString() + "</td>";
                        }
                    }
                    else if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }


                    else if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][3].ToString() + "</td>";
                    }


                    else if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >";
                        if (dt.Rows[intRowBodyCount][12].ToString() == "SUCCESS")
                        {
                            strHtml += "<div class=\"bo_not1 mrl_bon flt_l\">";
                            strHtml += "<i class=\"fa fa-square\"></i></div> Win</td>";
                        }
                        else if (dt.Rows[intRowBodyCount][12].ToString() == "PARTIAL WIN")
                        {
                            strHtml += "<div class=\"bo_not2 mrl_bon flt_l\" title=\"Partially win\">";
                            strHtml += "<i class=\"fa fa-square\"></i></div> PARTIALLY WIN</td>";
                        }
                        else if (dt.Rows[intRowBodyCount][12].ToString() == "LOSS")
                        {
                            strHtml += "<div class=\"bo_not3 mrl_bon flt_l\" title=\"Loss\">";
                            strHtml += " <i class=\"fa fa-square\"></i></div> LOSS</td>";
                        }
                        else
                        {
                            strHtml += "" + dt.Rows[intRowBodyCount][12].ToString() + "</td>";
                        }
                    }
                    else if (intColumnBodyCount == 5)
                    {
                        strHtml += "<td style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][13].ToString() + "</td>";
                    }










                    else if (intColumnBodyCount == 6)
                    {
                        strHtml += "<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][4].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 7)
                    {
                        decimal intGroupAmount = 0;
                        if (dtGrp.Rows.Count > 0)
                        {
                            strHtml += "<td class=\"tr_r\" style=\"word-break: break-all;word-wrap:break-word;\">";
                            strHtml += "<table>";
                            for (int intLoopCount = 0; intLoopCount < dtGrp.Rows.Count; intLoopCount++)
                            {
                                if (intGroupAmount < Convert.ToDecimal(dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"]))
                                {
                                    intGroupAmount = Convert.ToDecimal(dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"]);
                                }
                                ObjLeadReport.GroupName = dtGrp.Rows[intLoopCount]["QTNDTLGRP_NAME"].ToString();
                                strHtml += "<tr>";
                                strHtml += "<td class=\"tr_r\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"].ToString() + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"] + "(" + dtGrp.Rows[intLoopCount]["QTNDTLGRP_NAME"].ToString() + ")</td>";
                                strHtml += "</tr>";
                            }
                            strHtml += "</table>";
                            strHtml += "</td>";
                            intTotal = intTotal + intGroupAmount;
                            decQtrTotal = decQtrTotal + intGroupAmount;
                        }
                        else
                        {
                            string strNetAmount = dt.Rows[intRowBodyCount][5].ToString();
                            string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);

                            strHtml += "<td class=\"tr_r\" style=\"word-break: break-all; word-wrap:break-word;\" >" + strNetAmountWithComma.ToString() + "    " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                            if (dt.Rows[intRowBodyCount][5].ToString() != "" && dt.Rows[intRowBodyCount][5].ToString() != null)
                            {
                                intTotal = intTotal + Convert.ToDecimal(dt.Rows[intRowBodyCount][5].ToString());
                                decQtrTotal = decQtrTotal + Convert.ToDecimal(dt.Rows[intRowBodyCount][5].ToString());
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
                        strHtml += "<td class=\"tr_r\" colspan=\"9\" >QUARTER " + intMonthQtr + " SUB TOTAL</td>";
                        strHtml += "<td class=\"tr_r\" >" + decQtrTotal + "    " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";
                        strHtml += "</tr>";
                        decQtrTotal = 0;
                        intIncrmntQtr++;
                    }
                }
            }


            if (intTotal != 0)
            {
                strHtml += "<tr style=\"background-color:#eceff1!important;\">";

                if (strType != "1")
                {
                    strHtml += "<td class=\"txt_rd bg1 tr_l\" colspan=\"9\" style=\"background-color:#eceff1!important;\">Total</td>";
                }
                else
                {
                    strHtml += "<td class=\"txt_rd bg1 tr_l\" colspan=\"7\" style=\"background-color:#eceff1!important;\">Total</td>";
                }

                string strNetAmount = intTotal.ToString();
                string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                strHtml += "<td class=\"txt_rd bg1 tr_r\" >" + strNetAmountWithComma.ToString() + "    " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";

                strHtml += "</tr>";
            }

        }
        else
        {
            if (strType != "1")
            {
                strHtml += "<td class=\"tr_c\" colspan=\"10\">No data available in table</td>";
            }
            else
            {
                strHtml += "<td class=\"tr_c\" colspan=\"8\">No data available in table</td>";
            }
        }


        sb.Append(strHtml);
        return sb.ToString();
    }
    //public string ConvertDataTableForPrint(DataTable dt, string strType, DataTable dtcorp)
    //{
    //    string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
    //    int intCurrentQtr = 0, intMonthQtr = 0, intPrevQtr = 0, intIncrmntQtr = 1, intQtrRowCounter = 0;
    //    decimal decQtrTotal = 0;
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    clsCommonLibrary objClsCommon = new clsCommonLibrary();
    //    clsEntityReports ObjLeadReport = new clsEntityReports();
    //    clsBusinessLayerReports ObjBussinessReports = new clsBusinessLayerReports();
    //    if (Session["CORPOFFICEID"] != null)
    //    {
    //        ObjLeadReport.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
    //    }
    //    else if (Session["CORPOFFICEID"] == null)
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }
    //    string[] strArrQtr = new string[5];

    //    clsBusinessLayer objBusiness = new clsBusinessLayer();
    //    string strRandom = objCommon.Random_Number();

    //    clsEntityCommon objEntityCommon = new clsEntityCommon();
    //    objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
    //    if (dtcorp.Rows.Count > 0)
    //    {
    //        strCompanyName = dtcorp.Rows[0]["CORPRT_NAME"].ToString();
    //        strCompanyAddr1 = dtcorp.Rows[0]["CORPRT_ADDR1"].ToString();
    //        strCompanyAddr2 = dtcorp.Rows[0]["CORPRT_ADDR2"].ToString();
    //        strCompanyAddr3 = dtcorp.Rows[0]["CORPRT_ADDR3"].ToString();
    //        strCompanyAddrCntry = dtcorp.Rows[0]["CNTRY_NAME"].ToString();
    //    }

    //    string strCompanyAddr = objClsCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);
    //    //title

    //    //Create Caption Table
    //    if (strType == "Monthly")
    //    {
    //        StringBuilder sbCap = new StringBuilder();
    //        string strCapTable = "";
    //        strCapTable = "<table class=\"PrintCaptionTable\" >";
    //        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
    //        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr + "</td></tr>";

    //        strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\"></th><td>" + strCaptionTabCompanyNameRow + "</td></tr>";
    //        strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\"></th><td>" + strCaptionTabCompanyAddrRow + "</td></tr>";
    //        strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">Report Date</th><td>" + DateTime.Now.ToString("R") + "</td></tr>";
    //        if (ddlCustomer.SelectedItem.Value != "--ALL--")
    //        {
    //            strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">Customer:</th><td>" + ddlCustomer.SelectedItem.Text + "</td></tr>";
    //        }
    //        if (ddlSalesExecutive.SelectedItem.Value != "--ALL--")
    //        {
    //            strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">Sales Executive:</th><td>" + ddlSalesExecutive.SelectedItem.Text + "</td></tr>";
    //        }
    //        //evm-0020

    //        if (ddlCurrency.SelectedItem.Text != "")
    //        {
    //            strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">Currency :</th><td>" + ddlCurrency.SelectedItem.Text + "</td></tr>";
    //        }
    //        strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">Year:</th><td>" + ddlYears.SelectedItem.Text + "</td></tr>";


    //        strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">Month:</th><td>" + ddlMonths.SelectedItem.Text + "</td></tr>";

    //       strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">Report Generated By:</th><td>" + Session["USERFULLNAME"] + "</td></tr>";


    //        strCapTable += "<tr><th colspan=\"2\" style=\"text-align: left; word-wrap:break-word;\">Booking Report For Divison Manager</th><td></td></tr>";  //emp17
    //        strCapTable += "</table>";
    //        sbCap.Append(strCapTable);



    //    }
    //    else if (strType == "Quarterly")
    //    {
    //        StringBuilder sbCap = new StringBuilder();
    //        string strCapTable = "";
    //        strCapTable = "<table class=\"PrintCaptionTable\" >";
    //        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
    //        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr + "</td></tr>";

    //        strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\"></th><td>" + strCaptionTabCompanyNameRow + "</td></tr>";
    //        strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\"></th><td>" + strCaptionTabCompanyAddrRow + "</td></tr>";
    //        strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">Report Date:</th><td>" + DateTime.Now.ToString("R") + "</td></tr>";
    //        if (ddlCustomer.SelectedItem.Value != "--ALL--")
    //        {
    //            strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">Customer:</th><td>" + ddlCustomer.SelectedItem.Text + "</td></tr>";
    //        }
    //        if (ddlSalesExecutive.SelectedItem.Value != "--ALL--")
    //        {
    //            strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">Sales Executive:</th><td>" + ddlSalesExecutive.SelectedItem.Text + "</td></tr>";
    //        }
    //        //evm-0020

    //        if (ddlCurrency.SelectedItem.Text != "")
    //        {
    //            strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">Currency :</th><td>" + ddlCurrency.SelectedItem.Text + "</td></tr>";
    //        }
    //        strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">Year:</th><td>" + ddlYears.SelectedItem.Text + "</td></tr>";

    //        strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">Quarter:</th><td>" + ddlQuarter.SelectedItem.Text + "</td></tr>";
    //        strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">Report Generated By:</th><td>" + Session["USERFULLNAME"] + "</td></tr>";
    //        strCapTable += "<tr><th colspan=\"2\" style=\"text-align: left; word-wrap:break-word;\">Quarterly Booking Report For Division Manager</th><td></td></tr>";

    //        strCapTable += "</table>";
    //        //string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strcust + strproj + strstat + strDivis + stremp + strCaptionTabTitle + strCaptionTabstop;
    //        sbCap.Append(strCapTable);


    //    }
    //    else
    //    {
    //        StringBuilder sbCap = new StringBuilder();
    //        string strCapTable = "";
    //        strCapTable = "<table class=\"PrintCaptionTable\" >";
    //        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
    //        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr + "</td></tr>";

    //        strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\"></th><td>" + strCaptionTabCompanyNameRow + "</td></tr>";
    //        strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\"></th><td>" + strCaptionTabCompanyAddrRow + "</td></tr>";
    //        strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">Report Date:</th><td>" + DateTime.Now.ToString("R") + "</td></tr>";
    //        if (ddlCustomer.SelectedItem.Value != "--ALL--")
    //        {
    //            strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">Customer:</th><td>" + ddlCustomer.SelectedItem.Text + "</td></tr>";
    //        }
    //        if (ddlSalesExecutive.SelectedItem.Value != "--ALL--")
    //        {
    //            strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">Sales Executive:</th><td>" + ddlSalesExecutive.SelectedItem.Text + "</td></tr>";
    //        }

    //        //evm-0020

    //        if (ddlCurrency.SelectedItem.Text != "")
    //        {
    //            strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">Currency :</th><td>" + ddlCurrency.SelectedItem.Text + "</td></tr>";
    //        }

    //        strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">Year:</th><td>" + ddlYears.SelectedItem.Text + "</td></tr>";


    //        strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">Report Generated By:</th><td>" + Session["USERFULLNAME"] + "</td></tr>";
    //        strCapTable += "<tr><th colspan=\"2\" style=\"text-align: left; word-wrap:break-word;\">Yearly Booking Report For Division Manager</th><td></td></tr>";

    //        strCapTable += "</table>";
    //        sbCap.Append(strCapTable);
    //    }

    //    //Print table
    //    if (strType != "Monthly")
    //    {

    //        strArrQtr[1] = dt.Select("MONTH = '01'  OR MONTH = '02' OR MONTH = '03'").Length.ToString();
    //        strArrQtr[2] = dt.Select("MONTH = '04' OR MONTH = '05' OR MONTH = '06'").Length.ToString();
    //        strArrQtr[3] = dt.Select("MONTH = '07' OR MONTH = '08' OR MONTH = '09'").Length.ToString();
    //        strArrQtr[4] = dt.Select("MONTH = '10' OR MONTH = '11' OR MONTH = '12'").Length.ToString();
    //    }
    //    StringBuilder sb = new StringBuilder();
    //    string strHtml = "<table id=\"PrintTable\" class=\"tab\" cellspacing=\"0\" cellpadding=\"2px\" >";
    //    //add header row
    //    strHtml += "<thead>";
    //    strHtml += "<tr class=\"top_row\">";
    //    strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">SL#</th>";

    //    //strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">SL#</th>";
    //    for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
    //    {

    //        if (intColumnHeaderCount == 0)
    //        {
    //            strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">REF #</th>";
    //            if (strType != "Monthly")
    //            {
    //                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">QUARTER</th>";
    //                strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">MONTH</th>";
    //            }
    //        }

    //        else if (intColumnHeaderCount == 1)
    //        {
    //            strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: CENTER; word-wrap:break-word;\">QUOTE REF #</th>";
    //        }
    //        else if (intColumnHeaderCount == 2)
    //        {
    //            strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">ASSIGNED TO</th>";
    //        }
    //        else if (intColumnHeaderCount == 3)
    //        {
    //            strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">PROJECT</th>";
    //        }
    //        else if (intColumnHeaderCount == 4)
    //        {
    //            strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">CUSTOMER NAME</th>";
    //        }
    //        else if (intColumnHeaderCount == 5)
    //        {
    //            strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: right; word-wrap:break-word;\">QUOTE VALUE</th>";
    //        }



    //    }





    //    strHtml += "</tr>";
    //    strHtml += "</thead>";
    //    //add rows

    //    strHtml += "<tbody>";
    //    decimal intTotal = 0;
    //    int count = 1;
    //    for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
    //    {
    //        if (dt.Rows[intRowBodyCount]["LDQUOT_ID"].ToString() != "")
    //        {
    //            ObjLeadReport.LdQtnId = Convert.ToInt32(dt.Rows[intRowBodyCount]["LDQUOT_ID"].ToString());
    //        }
    //        DataTable dtGrp = ObjBussinessReports.ReadGroupAmount(ObjLeadReport);

    //        strHtml += "<tr  >";
    //        strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count.ToString() + "</td>";
    //        count++;
    //        for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
    //        {

    //            DateTime dateExDate = DateTime.MinValue;
    //            string strCurrentDate = objBusiness.LoadCurrentDateInString();
    //            DateTime dateCurrntdte = objCommon.textToDateTime(strCurrentDate);

    //            if (intColumnBodyCount == 0)
    //            {
    //                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //                if (strType != "Monthly")
    //                {
    //                    //<td rowspan="2">$50</td>


    //                    //row span
    //                    intMonthQtr = Convert.ToInt32(SelectQuarter(dt.Rows[intRowBodyCount][6].ToString()));

    //                    if (intCurrentQtr <= intMonthQtr)
    //                    {
    //                        intQtrRowCounter = intQtrRowCounter + Convert.ToInt32(strArrQtr[intMonthQtr]);
    //                        strHtml += "<td class=\"tdT\" rowspan=" + strArrQtr[intMonthQtr] + " style=\" width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >QUARTER " + intMonthQtr + "</td>";
    //                        intCurrentQtr = intMonthQtr + 1;

    //                    }

    //                    DateTime dateMonth = Convert.ToDateTime(dt.Rows[intRowBodyCount][7]);
    //                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + String.Format("{0:MMM }", dateMonth) + "</td>";
    //                }
    //            }
    //            else if (intColumnBodyCount == 1)
    //            {
    //                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //            }
    //            else if (intColumnBodyCount == 2)
    //            {
    //                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //            }
    //            else if (intColumnBodyCount == 3)
    //            {
    //                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //            }
    //            else if (intColumnBodyCount == 4)
    //            {
    //                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //            }
    //            else if (intColumnBodyCount == 5)
    //            {
    //                decimal intGroupAmount = 0;
    //                if (dtGrp.Rows.Count > 0)
    //                {
    //                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all;padding: 0px; word-wrap:break-word;text-align: right;\"><table id=\"tab2\" cellspacing=\"0\" style=\"width: 100%;\" cellpadding=\"2px\" >";
    //                    for (int intLoopCount = 0; intLoopCount < dtGrp.Rows.Count; intLoopCount++)
    //                    {
    //                        if (intGroupAmount < Convert.ToDecimal(dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"]))
    //                        {
    //                            intGroupAmount = Convert.ToDecimal(dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"]);
    //                        }
    //                        ObjLeadReport.GroupName = dtGrp.Rows[intLoopCount]["QTNDTLGRP_NAME"].ToString();
    //                        strHtml += "<tr style=\"background-color: inherit;\"><td class=\"tdT\" style=\" width:100%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;padding-right: 0px;padding-left: 0px;text-align: right;border: none; \" >" + dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"].ToString() + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"] + "(" + dtGrp.Rows[intLoopCount]["QTNDTLGRP_NAME"].ToString() + ")</td></tr>";
    //                    }
    //                    strHtml += "</table></td>";
    //                    intTotal = intTotal + intGroupAmount;
    //                    decQtrTotal = decQtrTotal + intGroupAmount;
    //                }
    //                else
    //                {

    //                    string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
    //                    string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);

    //                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strNetAmountWithComma.ToString() + "    " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
    //                    if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() != "" && dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() != null)
    //                    {
    //                        intTotal = intTotal + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
    //                        decQtrTotal = decQtrTotal + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
    //                    }
    //                }
    //            }


    //            //count++;
    //        }








    //        strHtml += "</tr>";
    //        if (strType == "Yearly")
    //        {
    //            if (intQtrRowCounter == (intRowBodyCount + 1))
    //            {
    //                strHtml += "<tr>";

    //                strHtml += "<td  class=\"thT\" colspan=\"8\" style=\"font-weight: bold;color: \"black\"; width:85%;word-break: break-all; word-wrap:break-word;text-align: left;\" >QUARTER " + intMonthQtr + " SUB TOTAL</td>";
    //                strHtml += "<td  class=\"thT\"  style=\"font-weight: bold;  width:15%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + decQtrTotal + "    " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";

    //                decQtrTotal = 0;


    //                strHtml += "</tr>";
    //                intIncrmntQtr++;
    //            }
    //        }


    //    }
    //    if (intTotal != 0)
    //    {
    //        strHtml += "</tbody>";
    //        strHtml += "<tfooter>";
    //        strHtml += "<tr>";

    //        // strHtml += "<td class=\"tdT\" style=\" border-right: navajowhite;width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >TOTAL</td>";

    //        //strHtml += "<td  class=\"tdT\" style=\" border-right: navajowhite;width:7%;word-break: break-all; word-wrap:break-word;text-align: left;\" >TOTAL</td>";
    //        //strHtml += "<td class=\"tdT\"   style=\"border-right: navajowhite;width:9%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";
    //        //strHtml += "<td class=\"tdT\"  style=\"border-right: navajowhite;width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";
    //        //strHtml += "<td class=\"tdT\"  style=\"border-right: navajowhite;width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";
    //        //strHtml += "<td class=\"tdT\"   style=\"border-right: navajowhite;width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";
    //        //strHtml += "<td class=\"tdT\"   style=\"border-right: navajowhite;width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";
    //        //strHtml += "<td class=\"tdT\"  style=\"width:9%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";

    //        if (strType != "Monthly")
    //        {
    //            strHtml += "<td  class=\"thT\" colspan=\"8\" style=\"font-weight: bold;color: \"black\"; width:85%;word-break: break-all; word-wrap:break-word;text-align: left;\">TOTAL</td>";


    //        }
    //        else
    //        {
    //            strHtml += "<td  class=\"thT\" colspan=\"6\" style=\"font-weight: bold;color: \"black\"; width:85%;word-break: break-all; word-wrap:break-word;text-align: left;\" >TOTAL</td>";

    //        }


    //        string strNetAmount = intTotal.ToString();
    //        string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);

    //        strHtml += "<td class=\"thT\" style=\"font-weight: bold;  width:15%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strNetAmountWithComma.ToString() + "    " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";
    //        strHtml += "</tr>";
    //        strHtml += "</tfooter>";
    //    }
    //    //  strHtml += "</tbody>";
    //    if (dt.Rows.Count == 0)
    //    {
    //        strHtml += "<tr>";
    //        strHtml += "<tfooter>";
    //        if (strType != "Monthly")
    //        {
    //            strHtml += "<td  class=\"thT\" colspan=\"9\" style=\"width:100%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";


    //        }
    //        else
    //        {
    //            strHtml += "<td  class=\"thT\" colspan=\"7\" style=\" width:100%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";

    //        }

    //        strHtml += "</tfooter>";
    //        strHtml += "</tr>";
    //    }
    //    strHtml += "</table>";



    //    sb.Append(strHtml);
    //    return sb.ToString();
    //}
    //protected void btnSearchMonthly_Click(object sender, EventArgs e)
    //{

    //    clsBusinessLayerReports ObjBussinessReport = new clsBusinessLayerReports();
    //    clsEntityReports ObjEntityLeadDiv = new clsEntityReports();
    //    clsBusinessLayerReports ObjBussinessReports = new clsBusinessLayerReports();
    //    clsEntityReports ObjLeadReport = new clsEntityReports();

    //    int intCorpId = 0;
    //    if (Session["CORPOFFICEID"] != null)
    //    {
    //        ObjEntityLeadDiv.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
    //        ObjLeadReport.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
    //        intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
    //    }
    //    else if (Session["CORPOFFICEID"] == null)
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }
    //    if (Session["ORGID"] != null)
    //    {
    //        ObjEntityLeadDiv.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
    //        ObjLeadReport.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
    //    }
    //    else if (Session["ORGID"] == null)
    //    {
    //        Response.Redirect("/Default.aspx");
    //    }
    //    if (Session["USERID"] != null)
    //    {
    //        // intUserId = Convert.ToInt32(Session["USERID"]);
    //        ObjEntityLeadDiv.User_Id = Convert.ToInt32(Session["USERID"]);
    //        ObjLeadReport.User_Id = Convert.ToInt32(Session["USERID"]);
    //    }
    //    else if (Session["USERID"] == null)
    //    {
    //        Response.Redirect("/Default.aspx");
    //    }
    //    //Monthly
    //    ObjLeadReport.Month = String.Format("{0:D2}", Convert.ToInt32(ddlMonths.SelectedValue));
    //    ObjLeadReport.Year = Convert.ToInt32(ddlYears.SelectedValue);
    //    if (ddlCustomer.SelectedValue != "--ALL--")
    //    {

    //        ObjLeadReport.CustomerId = Convert.ToInt32(ddlCustomer.SelectedItem.Value );
    //    }
    //    if (ddlSalesExecutive.SelectedValue != "--ALL--")
    //    {
    //        ObjLeadReport.SalesExecutiveId =Convert.ToInt32(ddlSalesExecutive.SelectedItem.Value);
    //    }
    //    //evm-0020
    //    if (ddlCurrency.SelectedItem.Text != "")
    //    {
    //        ObjLeadReport.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
    //    }

    //    DataTable dtMonthly = ObjBussinessReports.ReadDivisionManagerBkngRpt(ObjLeadReport);
    //    DataTable dtCorp = ObjBussinessReport.Read_Corp_Details(ObjEntityLeadDiv);

    //    ScriptManager.RegisterStartupScript(this, GetType(), "divButtonMonthlyClick", "divButtonMonthlyClick();", true);
    //}
    //protected void btnSearchQuarterly_Click(object sender, EventArgs e)
    //{
    //    clsBusinessLayerReports ObjBussinessReport = new clsBusinessLayerReports();
    //    clsEntityReports ObjEntityLeadDiv = new clsEntityReports();
    //    clsEntityReports ObjLeadReport = new clsEntityReports();
    //    clsBusinessLayerReports ObjBussinessReports = new clsBusinessLayerReports();
    //    int intCorpId = 0;
    //    if (Session["CORPOFFICEID"] != null)
    //    {
    //        ObjEntityLeadDiv.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
    //        ObjLeadReport.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
    //        intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
    //    }
    //    else if (Session["CORPOFFICEID"] == null)
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }
    //    if (Session["ORGID"] != null)
    //    {
    //        ObjEntityLeadDiv.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
    //        ObjLeadReport.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
    //    }
    //    else if (Session["ORGID"] == null)
    //    {
    //        Response.Redirect("/Default.aspx");
    //    }
    //    if (Session["USERID"] != null)
    //    {
    //        // intUserId = Convert.ToInt32(Session["USERID"]);
    //        ObjLeadReport.User_Id = Convert.ToInt32(Session["USERID"]);
    //        ObjEntityLeadDiv.User_Id = Convert.ToInt32(Session["USERID"]);
    //    }
    //    else if (Session["USERID"] == null)
    //    {
    //        Response.Redirect("/Default.aspx");
    //    }

    //    ObjLeadReport.Year = Convert.ToInt32(ddlYears.SelectedValue);
    //    if (ddlCustomer.SelectedValue != "--ALL--")
    //    {
    //        ObjLeadReport.CustomerId = Convert.ToInt32(ddlCustomer.SelectedItem.Value);
    //    }
    //    if (ddlSalesExecutive.SelectedValue != "--ALL--")
    //    {
    //        ObjLeadReport.SalesExecutiveId = Convert.ToInt32(ddlSalesExecutive.SelectedItem.Value);
    //    }
    //            //evm-0020
    //    if (ddlCurrency.SelectedItem.Text != "")
    //    {
    //        ObjLeadReport.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
    //    }

    //    //Quarterly
    //    ObjLeadReport.Quarter = Convert.ToInt32(ddlQuarter.SelectedValue);
    //    ObjLeadReport.Month = null;
    //    DataTable dtQuarterly = ObjBussinessReports.ReadDivisionManagerBkngRpt(ObjLeadReport);
    //    DataTable dtCorp = ObjBussinessReport.Read_Corp_Details(ObjEntityLeadDiv);

    //    ScriptManager.RegisterStartupScript(this, GetType(), "divQuarterlyClick", "divQuarterlyClick();", true);
    //}
    //protected void btnSearchYearly_Click(object sender, EventArgs e)
    //{
    //    clsBusinessLayerReports ObjBussinessReport = new clsBusinessLayerReports();
    //    clsEntityReports ObjEntityLeadDiv = new clsEntityReports();
    //    clsEntityReports ObjLeadReport = new clsEntityReports();
    //    clsBusinessLayerReports ObjBussinessReports = new clsBusinessLayerReports();
    //    int intCorpId = 0;
    //    if (Session["CORPOFFICEID"] != null)
    //    {
    //        ObjEntityLeadDiv.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
    //        ObjLeadReport.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
    //        intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
    //    }
    //    else if (Session["CORPOFFICEID"] == null)
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }
    //    if (Session["ORGID"] != null)
    //    {
    //        ObjEntityLeadDiv.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
    //        ObjLeadReport.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
    //    }
    //    else if (Session["ORGID"] == null)
    //    {
    //        Response.Redirect("/Default.aspx");
    //    }
    //    if (Session["USERID"] != null)
    //    {
    //        ObjEntityLeadDiv.User_Id = Convert.ToInt32(Session["USERID"]);
    //        // intUserId = Convert.ToInt32(Session["USERID"]);
    //        ObjLeadReport.User_Id = Convert.ToInt32(Session["USERID"]);
    //    }
    //    else if (Session["USERID"] == null)
    //    {
    //        Response.Redirect("/Default.aspx");
    //    }
    //    ObjLeadReport.Month = null;
    //    ObjLeadReport.Quarter = 0;
    //    ObjLeadReport.Year = Convert.ToInt32(ddlYears.SelectedValue);
    //    if (ddlCustomer.SelectedValue != "--ALL--")
    //    {
    //        ObjLeadReport.CustomerId = Convert.ToInt32(ddlCustomer.SelectedItem.Value);
    //    }
    //    if (ddlSalesExecutive.SelectedValue != "--ALL--")
    //    {
    //        ObjLeadReport.SalesExecutiveId = Convert.ToInt32(ddlSalesExecutive.SelectedItem.Value);
    //    }
    //    //evm-0020
    //    if (ddlCurrency.SelectedItem.Text != "")
    //    {
    //        ObjLeadReport.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
    //    }
    //    //Yearly
    //    DataTable dtYearly = ObjBussinessReports.ReadDivisionManagerBkngRpt(ObjLeadReport);
    //    DataTable dtCorp = ObjBussinessReport.Read_Corp_Details(ObjEntityLeadDiv);

    //    ScriptManager.RegisterStartupScript(this, GetType(), "divButtonYearlyClick", "divButtonYearlyClick();", true);
    //}


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

        ddlCurrency.DataSource = dtTerms;
        ddlCurrency.DataTextField = "CRNCMST_NAME";
        ddlCurrency.DataValueField = "CRNCMST_ID";
        ddlCurrency.DataBind();
        if (hiddenDfltCurrencyMstrId.Value != "")
        {
            ddlCurrency.Items.FindByValue(hiddenDfltCurrencyMstrId.Value).Selected = true;
        }

        clsEntityCommon ObjEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.COUNTRY_ICON_IMAGES);

        if (ddlCurrency != null)
        {
            foreach (System.Web.UI.WebControls.ListItem li in ddlCurrency.Items)
            {
                if (li.Text != "--SELECT CURRENCY--")
                {
                    ObjEntityCommon.CurrencyId = Convert.ToInt32(li.Value);
                    DataTable dtCurrencyDtls = objBusinessLayer.ReadCurrencyDetails(ObjEntityCommon);

                    li.Attributes["data-imagecss"] = "flag ad";
                    li.Attributes["title"] = li.Text;
                    if (dtCurrencyDtls.Rows[0]["CNTRY_FLAG_ICON_NAME"].ToString() != "")
                    {
                        li.Attributes["data-image"] = strImagePath + dtCurrencyDtls.Rows[0]["CNTRY_FLAG_ICON_NAME"].ToString();
                    }
                }
            }
        }

    }


    //------------------------------------------Pagination------------------------------------------------

    [WebMethod]
    public static string[] GetData(string OrgId, string CorpId, string UserId, string Customer, string SalesExec, string Currency, string Year, string Month, string Quarter, string Mode, string PageNumber, string PageMaxSize, string strCommonSearchTerm, string OrderColumn, string OrderMethod, string strInputColumnSearch)
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
            if (SalesExec != "" && SalesExec != "--ALL--")
            {
                ObjLeadReport.SalesExecutiveId = Convert.ToInt32(SalesExec);
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
            ObjLeadReport.SearchAssignTo = strSearchInputs[Convert.ToInt32(SearchInputColumns.ASSIGNTO)];
            ObjLeadReport.SearchProject = strSearchInputs[Convert.ToInt32(SearchInputColumns.PROJECT)];
            ObjLeadReport.SearchCustomer = strSearchInputs[Convert.ToInt32(SearchInputColumns.CUSTOMER)];
            ObjLeadReport.SearchQuotRef = strSearchInputs[Convert.ToInt32(SearchInputColumns.QUOTREF)];
            ObjLeadReport.SearchStatus = strSearchInputs[Convert.ToInt32(SearchInputColumns.STATUS)];

            //ReadList
            DataTable dt = ObjBussinessReport.ReadDivisionManagerBkngRpt(ObjLeadReport);

            string strTableContents = "";
            strTableContents = ConvertDataTableToHTML(dt, Mode, ObjLeadReport);
            strResults[0] = strTableContents;

            strResults[1] = dt.Rows.Count.ToString();

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
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" class=\"sorting th_b5 tr_l\" onclick=\"SetOrderByValue(1)\">Ref#<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Ref#\" title=\"Ref#\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                    sbSearchInputColumns.Append("</th>");
                }
                if (Item.ToString() == "3")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" class=\"sorting th_b1 tr_l\" onclick=\"SetOrderByValue(1)\">Assigned To<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Assigned To\" title=\"Assigned To\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                    sbSearchInputColumns.Append("</th>");
                }
                if (Item.ToString() == "4")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" class=\"sorting th_b8 tr_l\" onclick=\"SetOrderByValue(1)\">Project<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Project\" title=\"Project\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                    sbSearchInputColumns.Append("</th>");
                }
                if (Item.ToString() == "5")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" class=\"sorting th_b8 tr_l\" onclick=\"SetOrderByValue(1)\">Customer<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Customer\" title=\"Customer\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                    sbSearchInputColumns.Append("</th>");
                }



                if (Item.ToString() == "6")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_13\" class=\"sorting th_b1 tr_l\" onclick=\"SetOrderByValue(13)\">Status<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Status\" title=\"Status\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                    sbSearchInputColumns.Append("</th>");
                }
            }

            sbSearchInputColumns.Append("<th id=\"tdColumnHead_14\" class=\"sorting th_b5\" onclick=\"SetOrderByValue(14)\">LAST<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br>UPDATION");
            sbSearchInputColumns.Append("</th>");
            foreach (var item in values)
            {
                int Item = Convert.ToInt32(item);
                if (Item.ToString() == "7")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_7\" class=\"sorting th_b1 tr_l\" onclick=\"SetOrderByValue(1)\">Quote Ref#<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Quote Ref#\" title=\"Quote Ref#\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                    sbSearchInputColumns.Append("</th>");
                }
            }
            sbSearchInputColumns.Append("<th id=\"tdColumnHead_8\" class=\"th_b1 tr_r\">Quote Value</th>");
        }
        else if (Mode == "2")
        {
            foreach (var item in values)
            {
                int Item = Convert.ToInt32(item);
                // use item number to customize names using if
                if (Item.ToString() == "0")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" onclick=\"SetOrderByValue(1)\" class=\"sorting th_b5 tr_l\">Ref#<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Ref#\" title=\"Ref#\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                    sbSearchInputColumns.Append("</th>");
                }
                if (Item.ToString() == "1")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" onclick=\"SetOrderByValue(1)\" class=\"sorting th_b1\">Quarter<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Quarter\" title=\"Quarter\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                    sbSearchInputColumns.Append("</th>");
                }
                if (Item.ToString() == "2")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" onclick=\"SetOrderByValue(1)\" class=\"sorting th_b1\">Month<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Month\" title=\"Month\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                    sbSearchInputColumns.Append("</th>");
                }
                if (Item.ToString() == "3")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" onclick=\"SetOrderByValue(1)\" class=\"sorting th_b1 tr_l\" style=\"width: 6% !important;\">Assigned To<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Assigned To\" title=\"Assigned To\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                    sbSearchInputColumns.Append("</th>");
                }
                if (Item.ToString() == "4")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" onclick=\"SetOrderByValue(1)\" class=\"sorting th_b8 tr_l\" style=\"width: 8% !important;\">Project<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Project\" title=\"Project\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                    sbSearchInputColumns.Append("</th>");
                }
                if (Item.ToString() == "5")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" onclick=\"SetOrderByValue(1)\" class=\"sorting th_b8 tr_l\">Customer<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Customer\" title=\"Customer\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                    sbSearchInputColumns.Append("</th>");
                }
                if (Item.ToString() == "6")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_13\" class=\"sorting th_b1 tr_l\" onclick=\"SetOrderByValue(13)\">Status<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Status\" title=\"Status\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                    sbSearchInputColumns.Append("</th>");
                }
            }


            sbSearchInputColumns.Append("<th id=\"tdColumnHead_14\" class=\"sorting th_b1\" onclick=\"SetOrderByValue(14)\">LAST UPDATION<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>");
            sbSearchInputColumns.Append("</th>");
            foreach (var item in values)
            {
                int Item = Convert.ToInt32(item);
                if (Item.ToString() == "7")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_7\" class=\"sorting th_b1 tr_l\" onclick=\"SetOrderByValue(1)\">Quote Ref#<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Quote Ref#\" title=\"Quote Ref#\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                    sbSearchInputColumns.Append("</th>");
                }
            }

            sbSearchInputColumns.Append("<th id=\"tdColumnHead_8\" class=\"th_b1 tr_r\">Quote Value</th>");
        }
        else if (Mode == "3")
        {
            foreach (var item in values)
            {
                int Item = Convert.ToInt32(item);
                // use item number to customize names using if
                if (Item.ToString() == "0")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" class=\"sorting th_b5 tr_l\">Ref#");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Ref#\" title=\"Ref#\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                    sbSearchInputColumns.Append("</th>");
                }
                if (Item.ToString() == "1")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" class=\"sorting th_b1\">Quarter");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Quarter\" title=\"Quarter\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                    sbSearchInputColumns.Append("</th>");
                }
                if (Item.ToString() == "2")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" class=\"sorting th_b1\">Month");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Month\" title=\"Month\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                    sbSearchInputColumns.Append("</th>");
                }
                if (Item.ToString() == "3")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" class=\"sorting th_b1 tr_l\">Assigned To");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Assigned To\" title=\"Assigned To\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                    sbSearchInputColumns.Append("</th>");
                }
                if (Item.ToString() == "4")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" class=\"sorting th_b8 tr_l\">Project");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Project\" title=\"Project\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                    sbSearchInputColumns.Append("</th>");
                }
                if (Item.ToString() == "5")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" class=\"sorting th_b8 tr_l\">Customer");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Customer\" title=\"Customer\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                    sbSearchInputColumns.Append("</th>");
                }
                if (Item.ToString() == "6")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_13\" class=\"sorting th_b1 tr_l\">Status");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Status\" title=\"Status\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                    sbSearchInputColumns.Append("</th>");
                }
            }
            sbSearchInputColumns.Append("<th id=\"tdColumnHead_14\" class=\"sorting th_b1\" >LAST<br> UPDATION");
            sbSearchInputColumns.Append("</th>");
            foreach (var item in values)
            {
                int Item = Convert.ToInt32(item);
                if (Item.ToString() == "7")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_7\" class=\"sorting th_b1 tr_l\">Quote Ref#");
                    sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Quote Ref#\" title=\"Quote Ref#\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                    sbSearchInputColumns.Append("</th>");
                }
            }
            sbSearchInputColumns.Append("<th id=\"tdColumnHead_8\" class=\"th_b1 tr_r\">Quote Value</th>");
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
        ASSIGNTO = 3,
        PROJECT = 4,
        CUSTOMER = 5,
        STATUS = 6,
        QUOTREF = 7,
    }

    //------------------------------------------Pagination------------------------------------------------

    [WebMethod]
    public static string PrintList(string OrgId, string CorpId, string UserId, string Customer, string SalesExec, string Currency, string CustomerText, string SalesExecText, string CurrencyText, string Year, string Month, string Quarter, string YearText, string MonthText, string QuarterText, string Mode)
    {
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
        if (SalesExec != "" && SalesExec != "--ALL--")
        {
            ObjLeadReport.SalesExecutiveId = Convert.ToInt32(SalesExec);
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

        DataTable dt = ObjBussinessReport.ReadDivisionManagerBkngRpt(ObjLeadReport);

        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, ObjLeadReport.Corporate_Id);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
        }

        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.BOOKING_DM_REPORT_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.BOOKING_DM_REPORT_PDF);
        objEntityCommon.CorporateID = ObjLeadReport.Corporate_Id;
        objEntityCommon.Organisation_Id = ObjLeadReport.Organisation_Id;
        string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "BookingDMReport_" + strNextNumber + ".pdf";

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
                float[] footrsBody1 = { 20, 5, 75 };
                footrtable.SetWidths(footrsBody1);
                footrtable.WidthPercentage = 100;

                if (Customer != "" && Customer != "--ALL--")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("CUSTOMER  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(CustomerText, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (SalesExec != "" && SalesExec != "--ALL--")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("EMPLOYEE  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(SalesExecText, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (Currency != "" && Currency != "--SELECT CURRENCY--")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("CURRENCY  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(CurrencyText, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }

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

                document.Add(footrtable);

                if (Mode != "1")
                {
                    //adding table to pdf
                    PdfPTable TBCustomer = new PdfPTable(10);
                    float[] footrsSubBody = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
                    TBCustomer.SetWidths(footrsSubBody);
                    TBCustomer.WidthPercentage = 100;
                    TBCustomer.HeaderRows = 1;

                    string[] strArrQtr = new string[5];
                    int intCurrentQtr = 0, intQtrRowCounter = 0;

                    strArrQtr[1] = dt.Select("MONTH = '01' OR MONTH = '02' OR MONTH = '03'").Length.ToString();
                    strArrQtr[2] = dt.Select("MONTH = '04' OR MONTH = '05' OR MONTH = '06'").Length.ToString();
                    strArrQtr[3] = dt.Select("MONTH = '07' OR MONTH = '08' OR MONTH = '09'").Length.ToString();
                    strArrQtr[4] = dt.Select("MONTH = '10' OR MONTH = '11' OR MONTH = '12'").Length.ToString();

                    var FontGray = new BaseColor(138, 138, 138);
                    var FontColour = new BaseColor(134, 152, 160);
                    var FontSmallGray = new BaseColor(230, 230, 230);

                    TBCustomer.AddCell(new PdfPCell(new Phrase("REF#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("Quarter", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("Month", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("Assigned To", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("Project", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("Customer", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });


                    TBCustomer.AddCell(new PdfPCell(new Phrase("Status", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("Last Updation", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });


                    TBCustomer.AddCell(new PdfPCell(new Phrase("Quote Ref#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("Quote Value", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });

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

                            intMonthQtr = Convert.ToInt32(dt.Rows[intRowBodyCount]["QUARTER"].ToString());
                            //if (intCurrentQtr <= intMonthQtr)
                            //{
                                intQtrRowCounter = intQtrRowCounter + Convert.ToInt32(strArrQtr[intMonthQtr]);
                                TBCustomer.AddCell(new PdfPCell(new Phrase("QUARTER " + intMonthQtr, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });//, Rowspan = Convert.ToInt32(strArrQtr[intMonthQtr])
                                intCurrentQtr = intMonthQtr + 1;
                            //}
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount]["MONTH_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount][1].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount][2].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount][3].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                         

                            if (dt.Rows[intRowBodyCount][12].ToString() == "SUCCESS")
                            {
                                TBCustomer.AddCell(new PdfPCell(new Phrase("WIN", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            }
                            else if (dt.Rows[intRowBodyCount][12].ToString() == "PARTIAL WIN")
                            {
                                TBCustomer.AddCell(new PdfPCell(new Phrase("PARTIALLY WIN", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            }
                            else
                            {
                                TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount][12].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            }
                            
                            
                            
                            
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount][13].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount][4].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                            decimal intGroupAmount = 0;
                            if (dtGrp.Rows.Count > 0)
                            {
                                for (int intLoopCount = 0; intLoopCount < dtGrp.Rows.Count; intLoopCount++)
                                {
                                    if (intGroupAmount < Convert.ToDecimal(dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"]))
                                    {
                                        intGroupAmount = Convert.ToDecimal(dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"]);
                                    }
                                    ObjLeadReport.GroupName = dtGrp.Rows[intLoopCount]["QTNDTLGRP_NAME"].ToString();

                                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"].ToString() + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"] + "(" + dtGrp.Rows[intLoopCount]["QTNDTLGRP_NAME"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                }
                                intTotal = intTotal + intGroupAmount;
                                decQtrTotal = decQtrTotal + intGroupAmount;
                            }
                            else
                            {
                                string strNetAmount = dt.Rows[intRowBodyCount][5].ToString();
                                string strNetAmountWithComma = objBusinessLayer.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);

                                TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithComma.ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                if (dt.Rows[intRowBodyCount][5].ToString() != "" && dt.Rows[intRowBodyCount][5].ToString() != null)
                                {
                                    intTotal = intTotal + Convert.ToDecimal(dt.Rows[intRowBodyCount][5].ToString());
                                    decQtrTotal = decQtrTotal + Convert.ToDecimal(dt.Rows[intRowBodyCount][5].ToString());
                                }
                            }


                            if (Mode == "3")
                            {
                                if (intQtrRowCounter == (intRowBodyCount + 1))
                                {
                                    TBCustomer.AddCell(new PdfPCell(new Phrase("QUARTER " + intMonthQtr, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 9 });
                                    TBCustomer.AddCell(new PdfPCell(new Phrase(decQtrTotal + " " + dt.Rows[0]["CRNCMST_ABBRV"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                    decQtrTotal = 0;
                                    intIncrmntQtr++;
                                }
                            }
                        }
                    }
                    else
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase("No data available in table", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 11 });
                    }
                    document.Add(TBCustomer);
                }
                else
                {

                    //adding table to pdf
                    PdfPTable TBCustomer = new PdfPTable(8);
                    float[] footrsBody = { 10, 15, 15, 15, 10, 10, 10, 15 };
                    TBCustomer.SetWidths(footrsBody);
                    TBCustomer.WidthPercentage = 100;
                    TBCustomer.HeaderRows = 1;

                    string[] strArrQtr = new string[5];
                    int intCurrentQtr = 0, intQtrRowCounter = 0;

                    var FontGray = new BaseColor(138, 138, 138);
                    var FontColour = new BaseColor(134, 152, 160);
                    var FontSmallGray = new BaseColor(230, 230, 230);

                    TBCustomer.AddCell(new PdfPCell(new Phrase("REF#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("Assigned To", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("Project", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("Customer", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });


                    TBCustomer.AddCell(new PdfPCell(new Phrase("Status", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("Last Updation", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });


                    TBCustomer.AddCell(new PdfPCell(new Phrase("Quote Ref#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("Quote Value", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });

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
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount][1].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount][2].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount][3].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount][12].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount][13].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


                            TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount][4].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                            decimal intGroupAmount = 0;
                            if (dtGrp.Rows.Count > 0)
                            {
                                for (int intLoopCount = 0; intLoopCount < dtGrp.Rows.Count; intLoopCount++)
                                {
                                    if (intGroupAmount < Convert.ToDecimal(dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"]))
                                    {
                                        intGroupAmount = Convert.ToDecimal(dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"]);
                                    }
                                    ObjLeadReport.GroupName = dtGrp.Rows[intLoopCount]["QTNDTLGRP_NAME"].ToString();

                                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"].ToString() + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"] + "(" + dtGrp.Rows[intLoopCount]["QTNDTLGRP_NAME"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                }
                                intTotal = intTotal + intGroupAmount;
                                decQtrTotal = decQtrTotal + intGroupAmount;
                            }
                            else
                            {
                                string strNetAmount = dt.Rows[intRowBodyCount][5].ToString();
                                string strNetAmountWithComma = objBusinessLayer.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);

                                TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithComma.ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                if (dt.Rows[intRowBodyCount][5].ToString() != "" && dt.Rows[intRowBodyCount][5].ToString() != null)
                                {
                                    intTotal = intTotal + Convert.ToDecimal(dt.Rows[intRowBodyCount][5].ToString());
                                    decQtrTotal = decQtrTotal + Convert.ToDecimal(dt.Rows[intRowBodyCount][5].ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase("No data available in table", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 11 });
                    }
                    document.Add(TBCustomer);
                }
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
            headtable.AddCell(new PdfPCell(new Phrase("Booking Report for Division Manager", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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


    [WebMethod]
    public static string LoadNextYears(string Count, string LastYr, string SelectedYear)
    {
        StringBuilder sb = new StringBuilder();

        if (Count != "")
        {
            int intCount = Convert.ToInt32(Count);

            clsCommonLibrary objCommon = new clsCommonLibrary();
            var LoopYear = Convert.ToInt32(LastYr) + 10;
            var SelctdYr = Convert.ToInt32(SelectedYear);

            for (int i = 10; i > 0; i--)
            {
                if ((LoopYear - i).ToString() == SelctdYr.ToString())//current year
                {
                    sb.Append("<button id=\"btnYear" + i + "\" class=\"y" + i + " clsYear act\" onclick=\"return ClickYear(" + i + ");\">" + (LoopYear - i) + "</button>");
                }
                else
                {
                    sb.Append("<button id=\"btnYear" + i + "\" class=\"y" + i + " clsYear\" onclick=\"return ClickYear(" + i + ");\">" + (LoopYear - i) + "</button>");
                }
            }

            sb.Append("<div class=\"devider\"></div>");
            sb.Append("<button class=\"bck flt_l\" title=\"Back\" onclick=\"return PrvsYears(" + (intCount) + "," + (LoopYear - 10) + ");\"><i class=\"fa fa-angle-left\"></i> </button>");
            sb.Append("<button class=\"nxt flt_r\" title=\"Next\" onclick=\"return NextYears(" + (intCount + 1) + "," + (LoopYear) + ");\"><i class=\"fa fa-angle-right\"></i></button>");
        }
        return sb.ToString();
    }

    [WebMethod]
    public static string LoadPrvsYears(string Count, string StrtYr, string SelectedYear)
    {
        StringBuilder sb = new StringBuilder();

        if (Count != "")
        {
            int intCount = Convert.ToInt32(Count);

            clsCommonLibrary objCommon = new clsCommonLibrary();
            var LoopYear = Convert.ToInt32(StrtYr);
            var SelctdYr = Convert.ToInt32(SelectedYear);

            for (int i = 10; i > 0; i--)
            {
                if ((LoopYear - i).ToString() == SelctdYr.ToString())//current year
                {
                    sb.Append("<button id=\"btnYear" + i + "\" class=\"y" + i + " clsYear act\" onclick=\"return ClickYear(" + i + ");\">" + (LoopYear - i) + "</button>");
                }
                else
                {
                    sb.Append("<button id=\"btnYear" + i + "\" class=\"y" + i + " clsYear\" onclick=\"return ClickYear(" + i + ");\">" + (LoopYear - i) + "</button>");
                }
            }

            sb.Append("<div class=\"devider\"></div>");
            sb.Append("<button class=\"bck flt_l\" title=\"Back\" onclick=\"return PrvsYears(" + (intCount) + "," + (LoopYear - 10) + ");\"><i class=\"fa fa-angle-left\"></i> </button>");
            sb.Append("<button class=\"nxt flt_r\" title=\"Next\" onclick=\"return NextYears(" + (intCount + 1) + "," + (LoopYear) + ");\"><i class=\"fa fa-angle-right\"></i></button>");
        }
        return sb.ToString();
    }


}