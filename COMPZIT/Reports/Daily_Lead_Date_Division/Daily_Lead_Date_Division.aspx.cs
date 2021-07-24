using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CL_Compzit;
using BL_Compzit;
using System.Web.Services;
using EL_Compzit;
using System.Text;
using System.Web.Services;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;


public partial class Reports_Daily_Lead_Date_Division_Daily_Lead_Date_Division : System.Web.UI.Page
{
    clsBusinessLayerReports ObjBussinessReport = new clsBusinessLayerReports();
    clsEntityReports ObjEntityLeadDiv = new clsEntityReports();
    clsEntityCommon ObjEntityCommon = new clsEntityCommon();
    decimal sum;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

           ReadDivision();
           ReadCustom();
           ReadProject();
           ReadStatusWinLose();
           ReadEmployee();
      //evm-20
           ReadCurrency();
            int intUserId = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                ObjEntityLeadDiv.User_Id = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                ObjEntityLeadDiv.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

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

            string strCustom = ddlCustomer.SelectedItem.Text;
            string strProject = ddlProject.SelectedItem.Text;
            string strStatus = ddlStatus.SelectedItem.Text;
            string strEmployee = ddlEmployee.SelectedItem.Text;
            string strDivision = ddlDivision.SelectedItem.Text;
             string strHidden = "";
            //strHidden = HiddenSearchField.Value;
            //string[] strSearchFields = strHidden.Split(',');
             string strFdate = "";
             string strLdate = "";

            ObjEntityLeadDiv.Division_Id = 0;

            if (strCustom != null && strCustom != "")
            {
                if (ddlCustomer.Items.FindByValue(strCustom) != null)
                {
                    if (ddlCustomer.SelectedItem.Value != "--SELECT CUSTOMER NAME--")
                    {
                        ObjEntityLeadDiv.CustomerId = Convert.ToInt32(ddlCustomer.SelectedItem.Value);
                    }
                }
            }
            if (strProject != null && strProject != "")
            {
                if (ddlProject.Items.FindByValue(strProject) != null)
                {
                    if (ddlProject.SelectedItem.Value != "--SELECT PROJECT NAME--")
                    {
                        ObjEntityLeadDiv.ProjectId = Convert.ToInt32(ddlProject.SelectedItem.Value);
                    }
                }
            }

            if (strStatus != null && strStatus != "")
            {
                if (ddlStatus.Items.FindByValue(strCustom) != null)
                {
                    if (ddlStatus.SelectedItem.Value != "--SELECT STATUS--")
                    {
                        ObjEntityLeadDiv.StatusId = Convert.ToInt32(ddlStatus.SelectedItem.Value);
                    }
                }
            }



            if (strEmployee != null && strEmployee != "")
            {
                if (ddlEmployee.Items.FindByValue(strCustom) != null)
                {
                    if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE NAME--")
                    {
                        ObjEntityLeadDiv.EmployeeId =Convert.ToInt32(ddlEmployee.SelectedItem.Value);

                    }
                }
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
                hiddenDfltCurrency.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            }

            //evm-0020
            if (ddlCurrency.SelectedItem.Text != "--SELECT CURRENCY--")
            {
                ObjEntityLeadDiv.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
            }
        }

    }
    //EVM-0016
    public void ReadDivision()
    {

       
        clsBusinessLayerReports objBusinessLayerReports = new clsBusinessLayerReports();

        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityLeadDiv.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityLeadDiv.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityLeadDiv.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtdivision = ObjBussinessReport.Read_Division(ObjEntityLeadDiv);
        if (dtdivision.Rows.Count > 0)
        {
            ddlDivision.DataSource = dtdivision;
            ddlDivision.DataTextField = "CPRDIV_NAME";
            ddlDivision.DataValueField = "CPRDIV_ID";
            ddlDivision.DataBind();

        }

        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
    }

    public static string[] ConvertDataTableToHTML(DataTable dt, string hiddenDfltCurrencyMstrId, string Corporate_Id)
    {
        string[] strReturn = new string[2];
        string strHtml = "", strHtmlF = ""; 
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        clsEntityCommon ObjEntityCommon = new clsEntityCommon();
        ObjEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId);
        clsEntityReports ObjLeadReport = new clsEntityReports();
        clsBusinessLayerReports ObjBussinessReports = new clsBusinessLayerReports();
        if (Corporate_Id != null)
        {
            ObjLeadReport.Corporate_Id = Convert.ToInt32(Corporate_Id);
        }
       
       
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

            strHtml += "<tr  >";

            strHtml += "<td class=\"tr_l\" >" + dt.Rows[intRowBodyCount][0].ToString() + "</td>";

            strHtml += "<td class=\"tr_c\" >" + dt.Rows[intRowBodyCount][1].ToString() + "</td>";

            strHtml += "<td class=\"tr_l\" >" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";

            strHtml += "<td class=\"tr_l\" >" + dt.Rows[intRowBodyCount][3].ToString() + "</td>";

            strHtml += "<td class=\"tr_l\" >" + dt.Rows[intRowBodyCount][4].ToString() + "</td>";

            strHtml += "<td class=\"tr_c\"  >" + dt.Rows[intRowBodyCount][5].ToString() + "</td>";


            strHtml += "<td class=\"tr_c\">" + dt.Rows[intRowBodyCount][6].ToString() + "</td>";


            strHtml += "<td class=\"tr_l\">" + dt.Rows[intRowBodyCount][7].ToString() + "</td>";

              
                    if (dtGrp.Rows.Count > 0)
                    {
                        strHtml += "<td class=\"tr_r\" style=\"word-break: break-all;padding: 0px; word-wrap:break-word;text-align: right;\"><table cellspacing=\"0\" style=\"width: 100%;\" cellpadding=\"2px\">";
                        for (int intLoopCount = 0; intLoopCount < dtGrp.Rows.Count; intLoopCount++)
                        {
                            if (dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"].ToString() != null && dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"].ToString() != "")
                            {
                                intTotal = intTotal + Convert.ToDecimal((dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"].ToString()));
                            }

                            ObjLeadReport.GroupName = dtGrp.Rows[intLoopCount]["QTNDTLGRP_NAME"].ToString();
                            strHtml += "<tr style=\"background-color: inherit !important;\"><td class=\"tr_r\" style=\" width:100%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;padding-right: 0px;padding-left: 0px;text-align: right; \">" + dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"].ToString() + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"] + "(" + dtGrp.Rows[intLoopCount]["QTNDTLGRP_NAME"].ToString() + ")</td></tr>";
                        }
                        strHtml += "</table></td>";
                    }
                    else
                    {
                        string strAmount = "0.00";
                        if (dt.Rows[intRowBodyCount][8].ToString() != "")
                        {
                            strAmount = dt.Rows[intRowBodyCount][8].ToString();
                        }
                        string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strAmount, ObjEntityCommon);
                        strHtml += "<td class=\"tr_r\">" + strNetAmountWithComma.ToString() + "    " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                        if (dt.Rows[intRowBodyCount][8].ToString() != null && dt.Rows[intRowBodyCount][8].ToString() != "")
                        {
                            intTotal = intTotal + Convert.ToDecimal((dt.Rows[intRowBodyCount][8].ToString()));
                        }
                    }

            strHtml += "</tr>";
            
        }
        if (intTotal != 0)
            {
               string strNetAmount = intTotal.ToString();
               string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, ObjEntityCommon);

               strHtml += "<tr style=\"background-color:#eceff1!important;\">";
               strHtml += " <td class=\"txt_rd tr_l\" colspan=\"8\" style=\"background-color:#eceff1!important;\">Total</th>";
               strHtml += "<td class=\"txt_rd tr_r\">" + strNetAmountWithComma + "    " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";
               strHtml += " </tr>";
               
            }
        }
          else
          {
              strHtml += "<td class=\"tr_c\" colspan=\"9\">No data available in table</td>";
          }
          strReturn[0] = strHtml;
          strReturn[1] = strHtmlF;
          return strReturn;
    }
    [WebMethod]
    public static string[] GetData(string OrgId, string CorpId, string PageNumber, string PageMaxSize, string strCommonSearchTerm, string OrderColumn, string OrderMethod, string strInputColumnSearch, string FromDate, string ToDate, string CurrencyId, string ProjectId, string StatusId, string CustomerId, string hiddenDfltCurrencyMstrId, string dateRange, string userId, string Division, string Employee)
    {
        string[] strResults = new string[4];
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBusinessLayerReports ObjBussinessReport = new clsBusinessLayerReports();
        clsEntityReports ObjEntityBankGuarantee = new clsEntityReports();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (Division != "--SELECT DIVISION--")
        {
            ObjEntityBankGuarantee.Division_Id = Convert.ToInt32(Division);
        }



        if (ToDate != null && ToDate != "" && ToDate != "undefined")
        {

            //TextBox1.Text = strToDate;

            ObjEntityBankGuarantee.LDate = objCommon.textToDateTime(ToDate);
        }

        if (FromDate != null && FromDate != "")
        {
            //txtDate.Text = strDate;
            ObjEntityBankGuarantee.FDate = objCommon.textToDateTime(FromDate);
        }

        if (CustomerId != "--SELECT CUSTOMER NAME--")
        {
            ObjEntityBankGuarantee.CustomerId = Convert.ToInt32(CustomerId);
        }



        if (StatusId != "--SELECT STATUS--")
        {
            ObjEntityBankGuarantee.StatusId = Convert.ToInt32(StatusId);


        }
        if (Employee != "--SELECT EMPLOYEE NAME--")
        {
            ObjEntityBankGuarantee.EmployeeId = Convert.ToInt32(Employee);
        }


        if (ProjectId != "--SELECT PROJECT NAME--")
        {
            ObjEntityBankGuarantee.ProjctId = Convert.ToInt32(ProjectId);
        }
        //evm-0020
        if (CurrencyId != "--SELECT CURRENCY--")
        {
            ObjEntityBankGuarantee.CurrencyId = Convert.ToInt32(CurrencyId);
        }


        if (userId != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityBankGuarantee.User_Id = Convert.ToInt32(userId);
            ObjEntityBankGuarantee.User_Id = Convert.ToInt32(userId);
        }

        if (CorpId != null)
        {
            ObjEntityBankGuarantee.Corporate_Id = Convert.ToInt32(CorpId);
            ObjEntityBankGuarantee.Corporate_Id = Convert.ToInt32(CorpId);
        }

        if (OrgId != null)
        {
            ObjEntityBankGuarantee.Organisation_Id = Convert.ToInt32(OrgId);
            ObjEntityBankGuarantee.Organisation_Id = Convert.ToInt32(OrgId);
        }



        ObjEntityBankGuarantee.PageNumber = Convert.ToInt32(PageNumber);
        ObjEntityBankGuarantee.PageMaxSize = Convert.ToInt32(PageMaxSize);
        ObjEntityBankGuarantee.OrderMethod = Convert.ToInt32(OrderMethod);
        ObjEntityBankGuarantee.OrderColumn = Convert.ToInt32(OrderColumn);
        ObjEntityBankGuarantee.CommonSearchTerm = strCommonSearchTerm;

        var values = Enum.GetValues(typeof(SearchInputColumns));
        int intSearchColumnCount = values.Length;

        string[] strSearchInputs = new string[intSearchColumnCount];
        //— ‡
        if (strInputColumnSearch != "")
        {
            string[] InputColumnSearchList = strInputColumnSearch.Split('—');
            foreach (var InputColumnSearch in InputColumnSearchList)
            {
                string[] strColumnSrch = InputColumnSearch.Split('‡');
                int intColumnNo = Convert.ToInt32(strColumnSrch[0]);
                string strSearchString = strColumnSrch[1];

                if (intColumnNo <= intSearchColumnCount)
                {
                    strSearchInputs[intColumnNo] = strSearchString;
                }
            }
        }
        ObjEntityBankGuarantee.SearchRef = strSearchInputs[Convert.ToInt32(SearchInputColumns.REF)];
        ObjEntityBankGuarantee.SearchDate = strSearchInputs[Convert.ToInt32(SearchInputColumns.DATE)];
        ObjEntityBankGuarantee.SearchAssignTo = strSearchInputs[Convert.ToInt32(SearchInputColumns.ASSIGN)];
        ObjEntityBankGuarantee.SearchProject = strSearchInputs[Convert.ToInt32(SearchInputColumns.PROJECT)];
        ObjEntityBankGuarantee.SearchCustomer = strSearchInputs[Convert.ToInt32(SearchInputColumns.CUSTOMER)];
      


        DataTable dt = new DataTable();
        dt = ObjBussinessReport.getLeadDataByDate(ObjEntityBankGuarantee);

        string[] strTableContents = new string[2];
        strTableContents = ConvertDataTableToHTML(dt, hiddenDfltCurrencyMstrId, CorpId);
        strResults[0] = strTableContents[0];
        strResults[1] = strTableContents[1];
        strResults[3] = "0";
        if (dt.Rows.Count > 0)
        {
            int intTotalItems = Convert.ToInt32(dt.Rows[0]["CNT"].ToString());
            int intCurrentRowCount = dt.Rows.Count;
            //Pagination
            strResults[2] = objBusinessLayer.GenereatePagination(intTotalItems, ObjEntityBankGuarantee.PageNumber, ObjEntityBankGuarantee.PageMaxSize, intCurrentRowCount);
            strResults[3] = intTotalItems.ToString();
        }
        return strResults;
    }
    [WebMethod]
    public static string[] LoadStaticDatafordt()//Filters
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

        foreach (var item in values)
        {
            // use item number to customize names using if 
            if (Convert.ToInt32(item).ToString() == "0")
            {
                sbSearchInputColumns.Append("<th id=\"tdColumnHead_1\" onclick=\"SetOrderByValue(1)\" class=\"sorting th_b8 tr_l\" style=\"word-wrap:break-word;\">REF#<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in tr_l\" type=\"text\" title=\"REF#\" placeholder=\"Ref#\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "1")
            {
                sbSearchInputColumns.Append("<th id=\"tdColumnHead_2\" onclick=\"SetOrderByValue(2)\" class=\"sorting th_b7\" style=\"word-wrap:break-word;width: 7% !important;\">ENQUIRY DATE<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in tr_c\" type=\"text\" title=\"ENQUIRY DATE\" placeholder=\"Enquiry Date\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "2")
            {
                sbSearchInputColumns.Append("<th id=\"tdColumnHead_3\" onclick=\"SetOrderByValue(3)\" class=\"sorting th_b8 tr_l\" style=\"word-wrap:break-word;\">ASSIGNED TO<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"ASSIGNED TO\" placeholder=\"Assigned To\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "3")
            {
                sbSearchInputColumns.Append("<th id=\"tdColumnHead_4\" onclick=\"SetOrderByValue(4)\" class=\"sorting th_b4 tr_l\" style=\"word-wrap:break-word;width: 10.5% !important;\">PROJECT<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"PROJECT\" placeholder=\"Project\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "4")
            {
                sbSearchInputColumns.Append("<th id=\"tdColumnHead_5\" onclick=\"SetOrderByValue(5)\" class=\"sorting th_b4 tr_l\" style=\"word-wrap:break-word;width: 10.5% !important;\">CUSTOMER<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"CUSTOMER\" placeholder=\"Customer\"></th>");
            }
        }
        sbSearchInputColumns.Append("<th id=\"tdColumnHead_6\"  onclick=\"SetOrderByValue(6)\" class=\"sorting th_b8 tr_c\" style=\"word-wrap:break-word;width: 10% !important;\">OPPORTUNITY STATUS<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbSearchInputColumns.Append("<th id=\"tdColumnHead_7\"  onclick=\"SetOrderByValue(7)\" class=\"sorting th_b6 tr_c\" style=\"word-wrap:break-word;width: 7.5% !important;\">LAST UPDATION<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbSearchInputColumns.Append("<th id=\"tdColumnHead_8\"  onclick=\"SetOrderByValue(8)\" class=\"sorting th_b7 tr_l\" style=\"word-wrap:break-word;\">QUOTE REF#<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbSearchInputColumns.Append("<th id=\"tdColumnHead_9\"  onclick=\"SetOrderByValue(9)\" class=\"sorting th_b7 tr_r\" style=\"word-wrap:break-word;width: 6.5% !important;\">QUOTE VALUE<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        strResults[1] = sbSearchInputColumns.ToString();
        strResults[2] = intSearchColumnCount.ToString();
        return strResults;
    }

    public enum SearchInputColumns
    {
        //Must be sequential 
        REF = 0,
        DATE = 1,
        ASSIGN = 2,
        PROJECT = 3,
        CUSTOMER = 4,
       
    }
    [WebMethod]
    public static string PrintList(string orgID, string corptID, string FromDate, string ToDate, string CurrencyId, string ProjectId, string StatusId, string CustomerId, string CurrencyIdT, string ProjectIdT, string StatusIdT, string CustomerIdT, string hiddenDfltCurrencyMstrId, string dateRange, string userId, string Division, string DivisionT, string Employee, string EmployeeT)
    {
        string strReturn = "";
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBusinessLayerReports ObjBussinessReport = new clsBusinessLayerReports();
        clsEntityReports ObjEntityBankGuarantee = new clsEntityReports();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId);
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        if (Division != "--SELECT DIVISION--")
        {
            ObjEntityBankGuarantee.Division_Id = Convert.ToInt32(Division);
        }



        if (ToDate != null && ToDate != "" && ToDate != "undefined")
        {

            //TextBox1.Text = strToDate;

            ObjEntityBankGuarantee.LDate = objCommon.textToDateTime(ToDate);
        }

        if (FromDate != null && FromDate != "")
        {
            //txtDate.Text = strDate;
            ObjEntityBankGuarantee.FDate = objCommon.textToDateTime(FromDate);
        }

        if (CustomerId != "--SELECT CUSTOMER NAME--")
        {
            ObjEntityBankGuarantee.CustomerId = Convert.ToInt32(CustomerId);
        }



        if (StatusId != "--SELECT STATUS--")
        {
            ObjEntityBankGuarantee.StatusId = Convert.ToInt32(StatusId);


        }
        if (Employee != "--SELECT EMPLOYEE NAME--")
        {
            ObjEntityBankGuarantee.EmployeeId = Convert.ToInt32(Employee);
        }


        if (ProjectId != "--SELECT PROJECT NAME--")
        {
            ObjEntityBankGuarantee.ProjctId = Convert.ToInt32(ProjectId);
        }
        //evm-0020
        if (CurrencyId != "--SELECT CURRENCY--")
        {
            ObjEntityBankGuarantee.CurrencyId = Convert.ToInt32(CurrencyId);
        }


        if (userId != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityBankGuarantee.User_Id = Convert.ToInt32(userId);
            ObjEntityBankGuarantee.User_Id = Convert.ToInt32(userId);
        }

        if (corptID != null)
        {
            ObjEntityBankGuarantee.Corporate_Id = Convert.ToInt32(corptID);
            ObjEntityBankGuarantee.Corporate_Id = Convert.ToInt32(corptID);
        }

        if (orgID != null)
        {
            ObjEntityBankGuarantee.Organisation_Id = Convert.ToInt32(orgID);
            ObjEntityBankGuarantee.Organisation_Id = Convert.ToInt32(orgID);
        }


        DataTable dtUser = new DataTable();
        dtUser = ObjBussinessReport.getLeadDataByDate(ObjEntityBankGuarantee);


        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.DEAL_CLOSURE_DM_RPT_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.DEAL_CLOSURE_DM_RPT_PDF);

        objEntityCommon.CorporateID = Convert.ToInt32(corptID);
        objEntityCommon.Organisation_Id = Convert.ToInt32(orgID);
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "DealClosureDmRpt_" + corptID + "_" + strNextNumber + ".pdf";

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

                footrtable.AddCell(new PdfPCell(new Phrase("Date Range  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(dateRange, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (StatusIdT != "--SELECT STATUS--")
                {

                    footrtable.AddCell(new PdfPCell(new Phrase("Status  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(StatusIdT, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                     if (CustomerId != "--SELECT CUSTOMER NAME--")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Customer  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(CustomerIdT, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                }
                if (ProjectId != "--SELECT PROJECT NAME--")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Project  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(ProjectIdT, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (Division != "--SELECT DIVISION--")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Division  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(DivisionT, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (Employee != "--SELECT EMPLOYEE NAME--")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Employee  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(EmployeeT, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (CurrencyId != "--SELECT CURRENCY--")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Currency  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(CurrencyIdT, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }

                footrtable.AddCell(new PdfPCell(new Phrase("Total number of records  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(dtUser.Rows.Count.ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                document.Add(footrtable);


                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(9);
                float[] footrsBody = { 9, 10,10, 12, 12, 12, 10, 9, 12 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("REF#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("ENQUIRY DATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("ASSIGNED TO", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("PROJECT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("CUSTOMER", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("OPPORTUNITY STATUS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("LAST UPDATION", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("QUOTE REF#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("QUOTE VALUE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });

                string strRandom = objCommon.Random_Number();


                if (dtUser.Rows.Count > 0)
                {
                    decimal tot1 = 0;
                    for (int intRowBodyCount = 0; intRowBodyCount < dtUser.Rows.Count; intRowBodyCount++)
                    {

                        if (dtUser.Rows[intRowBodyCount]["LDQUOT_ID"].ToString() != "")
                        {
                            ObjEntityBankGuarantee.LdQtnId = Convert.ToInt32(dtUser.Rows[intRowBodyCount]["LDQUOT_ID"].ToString());
                        }
                        DataTable dtGrp = ObjBussinessReport.ReadGroupAmount(ObjEntityBankGuarantee);

                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][0].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][1].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][2].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][3].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][4].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][5].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][6].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][7].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                        if (dtGrp.Rows.Count > 0)
                        {
                            string rs = "";
                            for (int intLoopCount = 0; intLoopCount < dtGrp.Rows.Count; intLoopCount++)
                            {
                                rs += dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"].ToString() + " " + dtUser.Rows[intRowBodyCount]["CRNCMST_ABBRV"] + "(" + dtGrp.Rows[intLoopCount]["QTNDTLGRP_NAME"].ToString() + ")\n";

                                if (dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"].ToString() != "" && dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"].ToString() != null)
                                {
                                    tot1 = tot1 + Convert.ToDecimal(dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"].ToString());
                                }
                            }
                            TBCustomer.AddCell(new PdfPCell(new Phrase(rs, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                        else
                        {
                            string strNetAmount = dtUser.Rows[intRowBodyCount][8].ToString();
                            if (strNetAmount == "")
                            {
                                TBCustomer.AddCell(new PdfPCell(new Phrase("0.00", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


                            }
                            else
                            {
                                string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                                TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithComma.ToString() + "    " + dtUser.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                if (dtUser.Rows[intRowBodyCount][8].ToString() != "" && dtUser.Rows[intRowBodyCount][8].ToString() != null)
                                {
                                    tot1 = tot1 + Convert.ToDecimal(dtUser.Rows[intRowBodyCount][8].ToString());
                                }
                            }
                        }
                    }

                    string strNetAmount1 = tot1.ToString();
                    string strNetAmountWithComma1 = objBusiness.AddCommasForNumberSeperation(strNetAmount1, objEntityCommon);


                    TBCustomer.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 8 });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithComma1 + " " + dtUser.Rows[0]["CRNCMST_ABBRV"].ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                }
                else
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase(" No data available in table", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 9 });
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
            headtable.AddCell(new PdfPCell(new Phrase("DEAL CLOSURE REPORT FOR DIVISION MANAGER", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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
    public void ReadCustom()
    {

        if (Session["USERID"] != null)
        {
            
            ObjEntityLeadDiv.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityLeadDiv.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityLeadDiv.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtCust = ObjBussinessReport.ReadCustomer(ObjEntityLeadDiv);
        if (dtCust.Rows.Count > 0)
        {
            ddlCustomer.DataSource = dtCust;
            ddlCustomer.DataTextField = "CSTMR_NAME";
            ddlCustomer.DataValueField = "CSTMR_ID";
            ddlCustomer.DataBind();

        }

        ddlCustomer.Items.Insert(0, "--SELECT CUSTOMER NAME--");
    }

    public void ReadProject()
    {


        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityLeadDiv.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityLeadDiv.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtCust = ObjBussinessReport.ReadProject(ObjEntityLeadDiv);

        if (dtCust.Rows.Count > 0)
        {
            ddlProject.DataSource = dtCust;
            ddlProject.DataTextField = "PROJECT_NAME";
            ddlProject.DataValueField = "PROJECT_ID";
            ddlProject.DataBind();

        }

        ddlProject.Items.Insert(0, "--SELECT PROJECT NAME--");
    }

    public void ReadStatusWinLose()
    {


        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityLeadDiv.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityLeadDiv.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtCust = ObjBussinessReport.ReadStatusWinLose(ObjEntityLeadDiv);

        if (dtCust.Rows.Count > 0)
        {
            ddlStatus.DataSource = dtCust;
            ddlStatus.DataTextField = "LDSTS_NAME";
            ddlStatus.DataValueField = "LDSTS_ID";
            ddlStatus.DataBind();

        }

        ddlStatus.Items.Insert(0, "--SELECT STATUS--");
    }

    public void ReadEmployee()
    {

        if (Session["USERID"] != null)
        {

            ObjEntityLeadDiv.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityLeadDiv.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityLeadDiv.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtCust = ObjBussinessReport.ReadEmployee(ObjEntityLeadDiv);

        if (dtCust.Rows.Count > 0)
        {
            ddlEmployee.DataSource = dtCust;
            ddlEmployee.DataTextField = "USR_NAME";
            ddlEmployee.DataValueField = "USR_ID";
            ddlEmployee.DataBind();

        }

        ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE NAME--");
    }

   
    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityLeadDiv.User_Id = Convert.ToInt32(Session["USERID"]);
        }

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityLeadDiv.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityLeadDiv.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (ddlDivision.SelectedItem.Text != "--SELECT DIVISION--")
        {
            ObjEntityLeadDiv.Division_Id = Convert.ToInt32(ddlDivision.SelectedItem.Value);
            DataTable dtReadEmploye = new DataTable();
            dtReadEmploye = ObjBussinessReport.ReadEmployeeByDivisionId(ObjEntityLeadDiv);
            DataTable dtReadPrjct= new DataTable();
            dtReadPrjct = ObjBussinessReport.ReadProjectByDivisionId(ObjEntityLeadDiv);
            ddlProject.Items.Clear();
            if (dtReadPrjct.Rows.Count > 0)
            {
                ddlProject.DataSource = dtReadPrjct;
                ddlProject.DataTextField = "PROJECT_NAME";
                ddlProject.DataValueField = "PROJECT_ID";
                ddlProject.DataBind();

            }

            ddlProject.Items.Insert(0, "--SELECT PROJECT NAME--");
            ddlEmployee.Items.Clear();

            if (dtReadEmploye.Rows.Count > 0)
            {
                ddlEmployee.DataSource = dtReadEmploye;
                ddlEmployee.DataTextField = "USR_NAME";
                ddlEmployee.DataValueField = "USR_ID";
                ddlEmployee.DataBind();

            }
            ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE NAME--");
        }
        else
        {
            ReadEmployee();
            ReadProject();
        }

        ScriptManager.RegisterStartupScript(this, GetType(), "AutocompleteEmp", "AutocompleteEmp();", true);
        //EVM-0016
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


        DataTable dtCountry = ObjBussinessReport.ReadCurrencyLoad(ObjEntityLeadDiv);

        ddlCurrency.Items.Insert(0, "--SELECT CURRENCY--");
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.COUNTRY_ICON_IMAGES);
        for (int i = 0; i < dtCountry.Rows.Count; i++)
        {
            System.Web.UI.WebControls.ListItem lstaLs = new System.Web.UI.WebControls.ListItem(dtCountry.Rows[i]["CRNCMST_NAME"].ToString(), dtCountry.Rows[i]["CRNCMST_ID"].ToString());
            if (dtCountry.Rows[i]["CNTRY_FLAG_ICON_NAME"].ToString() != "")
            {
                lstaLs.Attributes["data-imagecss"] = "flag ad";
                lstaLs.Attributes["title"] = lstaLs.Text;
                lstaLs.Attributes["data-image"] = strImagePath + dtCountry.Rows[i]["CNTRY_FLAG_ICON_NAME"].ToString();
            }
            ddlCurrency.Items.Insert(i + 1, lstaLs);
        }
    }
}