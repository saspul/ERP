using BL_Compzit;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CL_Compzit;
using EL_Compzit;
using System.Web.Services;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
// CREATED BY:WEM-0006
// CREATED DATE:20/09/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class Reports_gen_Quotation_Summary_gen_Quotation_Summary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Division_Load();
            txtFromDate.Focus();
            //this for automatically load table to previous position if it comes from popup page
            clsBusinessLayerReports objBusinessLayerReports = new clsBusinessLayerReports();
            clsEntityReports objEntityReports = new clsEntityReports();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();

            txtFromDate.Value = strCurrentDate;
            hiddenFromDtae.Value = strCurrentDate;

            txtToDate.Value = strCurrentDate;
            hiddenToDtae.Value = strCurrentDate; 

            if (Request.QueryString["fd"] != null)
            {
                objEntityReports.From_Date = Request.QueryString["fd"].ToString();
                txtFromDate.Value = objEntityReports.From_Date;
                hiddenFromDtae.Value = objEntityReports.From_Date; 
            }

            if (Request.QueryString["td"] != null)
            {
                objEntityReports.To_Date = Request.QueryString["td"].ToString();
                txtToDate.Value = objEntityReports.To_Date;
                hiddenToDtae.Value = objEntityReports.To_Date;
            }

            if (Request.QueryString["di"] != null)
            {
                objEntityReports.Division_Id = Convert.ToInt32(Request.QueryString["di"]);
                try
                {
                    ddlDivisions.Items.FindByValue(objEntityReports.Division_Id.ToString()).Selected = true;
                }
                catch
                {
                }
            }

        }
    }

     //It build the Html table by using the datatable provided
    public static string[] ConvertDataTableToHTML(DataTable dt, string strFromDate = "", string strToDate = "", string strDivId = "")
    {
        string[] strReturn = new string[2];
        string strHtml = "", strHtmlF = ""; 
        if (dt.Rows.Count > 0)
        {
        int tot1=0, tot2=0, tot3=0, tot4=0, tot5=0, tot6=0, tot7=0, tot8=0;
        
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr  >";
           
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                if (intColumnBodyCount == 0)
                {
                    strHtml += "<td class=\"tr_l\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 1)
                {

                    if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "0")
                        strHtml += "<td class=\"tr_c\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    else
                    {
                        string strHref = "gen_Quotation_Summary_Popup.aspx?Id=" + dt.Rows[intRowBodyCount][9].ToString();
                        strHtml += "<td class=\"tr_c\"  >" +
                            " <a  onclick='return getdetails(this.href);' href=\"gen_Quotation_Summary_Popup.aspx?Id=" + dt.Rows[intRowBodyCount][9].ToString() +
                            "&st=0&fd=" + strFromDate + "&td=" + strToDate + "&di=" + strDivId + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() +
                            " </a> </td>";
                        tot1 += Convert.ToInt32(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                    }
                }

                if (intColumnBodyCount == 2)
                {
                    if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "0")
                        strHtml += "<td class=\"tr_c\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    else
                    {
                        string strHref = "gen_Quotation_Summary_Popup.aspx?Id=" + dt.Rows[intRowBodyCount][9].ToString();
                        strHtml += "<td class=\"tr_c\"  >" +
                            " <a  onclick='return getdetails(this.href);' href=\"gen_Quotation_Summary_Popup.aspx?Id=" + dt.Rows[intRowBodyCount][9].ToString() +
                            "&st=1&fd=" + strFromDate + "&td=" + strToDate + "&di=" + strDivId + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() +
                            " </a> </td>";
                        tot2 += Convert.ToInt32(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                    }
                }
                else if (intColumnBodyCount == 3)
                {
                    if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "0")
                        strHtml += "<td class=\"tr_c\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    else
                    {
                        string strHref = "gen_Quotation_Summary_Popup.aspx?Id=" + dt.Rows[intRowBodyCount][9].ToString();
                        strHtml += "<td class=\"tr_c\"   >" +
                            " <a  onclick='return getdetails(this.href);' href=\"gen_Quotation_Summary_Popup.aspx?Id=" + dt.Rows[intRowBodyCount][9].ToString() +
                            "&st=2&fd=" + strFromDate + "&td=" + strToDate + "&di=" + strDivId + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() +
                            " </a> </td>";
                        tot3 += Convert.ToInt32(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                    }
                }
                else if (intColumnBodyCount == 4)
                {
                    if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "0")
                        strHtml += "<td class=\"tr_c\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    else
                    {
                        string strHref = "gen_Quotation_Summary_Popup.aspx?Id=" + dt.Rows[intRowBodyCount][9].ToString();
                        strHtml += "<td class=\"tr_c\"  >" +
                            " <a onclick='return getdetails(this.href);' href=\"gen_Quotation_Summary_Popup.aspx?Id=" + dt.Rows[intRowBodyCount][9].ToString() +
                            "&st=3&fd=" + strFromDate + "&td=" + strToDate + "&di=" + strDivId + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() +
                            " </a> </td>";
                        tot4 += Convert.ToInt32(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                    }
                }
                else if (intColumnBodyCount == 5)
                {
                    if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "0")
                        strHtml += "<td class=\"tr_c\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    else
                    {
                        string strHref = "gen_Quotation_Summary_Popup.aspx?Id=" + dt.Rows[intRowBodyCount][9].ToString();
                        strHtml += "<td class=\"tr_c\"   >" +
                            " <a onclick='return getdetails(this.href);' href=\"gen_Quotation_Summary_Popup.aspx?Id=" + dt.Rows[intRowBodyCount][9].ToString() +
                            "&st=4&fd=" + strFromDate + "&td=" + strToDate + "&di=" + strDivId + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() +
                            " </a> </td>";
                        tot5 += Convert.ToInt32(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                    }
                }
                else if (intColumnBodyCount == 6)
                {
                    if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "0")
                        strHtml += "<td class=\"tr_c\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    else
                    {
                        string strHref = "gen_Quotation_Summary_Popup.aspx?Id=" + dt.Rows[intRowBodyCount][9].ToString();
                        strHtml += "<td class=\"tr_c\"  >" +
                            " <a  onclick='return getdetails(this.href);' href=\"gen_Quotation_Summary_Popup.aspx?Id=" + dt.Rows[intRowBodyCount][9].ToString() +
                            "&st=5&fd=" + strFromDate + "&td=" + strToDate + "&di=" + strDivId + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() +
                            " </a> </td>";
                        tot6 += Convert.ToInt32(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                    }
                }
                else if (intColumnBodyCount == 7)
                {
                    if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "0")
                        strHtml += "<td class=\"tr_c\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    else
                    {
                        string strHref = "gen_Quotation_Summary_Popup.aspx?Id=" + dt.Rows[intRowBodyCount][9].ToString();
                        strHtml += "<td class=\"tr_c\"  >" +
                            " <a  color:Green;\"; onclick='return getdetails(this.href);' href=\"gen_Quotation_Summary_Popup.aspx?Id=" + dt.Rows[intRowBodyCount][9].ToString() +
                            "&st=6&fd=" + strFromDate + "&td=" + strToDate + "&di=" + strDivId + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() +
                            " </a> </td>";
                        tot7 += Convert.ToInt32(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                    }
                }

                else if (intColumnBodyCount == 8)
                {
                    if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "0")
                        strHtml += "<td class=\"tr_c\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    else
                    {
                        string strHref = "gen_Quotation_Summary_Popup.aspx?Id=" + dt.Rows[intRowBodyCount][9].ToString();
                        strHtml += "<td class=\"tr_c\"  >" +
                            " <a  onclick='return getdetails(this.href);' href=\"gen_Quotation_Summary_Popup.aspx?Id=" + dt.Rows[intRowBodyCount][9].ToString() +
                            "&st=7&fd=" + strFromDate + "&td=" + strToDate + "&di=" + strDivId + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() +
                            " </a> </td>";
                        tot8 += Convert.ToInt32(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                    }
                }

            }
            strHtml += "</tr>";
        }

        strHtml += "<tr style=\"background-color:#eceff1!important;\">";
        strHtml += "<td colspan=\"1\" class=\" txt_rd tr_l\" style=\"background-color:#eceff1!important;\">Total</th>";
        strHtml += "<td class=\" txt_rd\">" + tot1 + "</td>";
        strHtml += "<td class=\" txt_rd\">" + tot2 + "</td>";
        strHtml += "<td class=\" txt_rd\">" + tot3 + "</td>";
        strHtml += "<td class=\" txt_rd\">" + tot4 + "</td>";
        strHtml += "<td class=\" txt_rd\">" + tot5 + "</td>";
        strHtml += "<td class=\" txt_rd\">" + tot6 + "</td>";
        strHtml += "<td class=\" txt_rd\">" + tot7 + "</td>";
        strHtml += "<td class=\" txt_rd\">" + tot8 + "</td>";
        strHtml += "</tr>";
        }
        else
        {
            strHtml += "<td class=\"tr_c\" colspan=\"9\">No data available in table</td>";
        }
        strReturn[0] = strHtml;
        strReturn[1] = strHtmlF;
        return strReturn;

    }

    //set divisions based on organisation id and corporate id
    private void Division_Load()
    {
        clsEntityReports objEntityReport = new clsEntityReports();
        clsBusinessLayerReports objBusinessLayerReports = new clsBusinessLayerReports();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReport.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityReport.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityReport.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }



        DataTable dtDivisions = objBusinessLayerReports.Read_Divisions(objEntityReport);

        ddlDivisions.DataSource = dtDivisions;

        ddlDivisions.DataTextField = "CPRDIV_NAME";
        ddlDivisions.DataValueField = "CPRDIV_ID";
        ddlDivisions.DataBind();

        //ddlDivisions.Items.Insert(0, "--SELECT DIVISION--");

    }
    [WebMethod]
    public static string[] GetData(string OrgId, string CorpId, string PageNumber, string PageMaxSize, string strCommonSearchTerm, string OrderColumn, string OrderMethod, string strInputColumnSearch, string FromDate, string ToDate, string DivID)
    {
        string[] strResults = new string[4];
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityReports objEntityReport = new clsEntityReports();
        clsBusinessLayerReports objBusinessLayerReports = new clsBusinessLayerReports();
        objEntityReport.Organisation_Id = Convert.ToInt32(OrgId);
        objEntityReport.Corporate_Id = Convert.ToInt32(CorpId);
        objEntityReport.From_Date = FromDate;
        objEntityReport.To_Date = ToDate;
        if (FromDate != "" && ToDate != "" && DivID != "")
        {
            objEntityReport.Division_Id = Convert.ToInt32(DivID);
        }
        objEntityReport.PageNumber = Convert.ToInt32(PageNumber);
        objEntityReport.PageMaxSize = Convert.ToInt32(PageMaxSize);
        objEntityReport.OrderMethod = Convert.ToInt32(OrderMethod);
        objEntityReport.OrderColumn = Convert.ToInt32(OrderColumn);
        objEntityReport.CommonSearchTerm = strCommonSearchTerm;

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
        objEntityReport.SearchName = strSearchInputs[Convert.ToInt32(SearchInputColumns.NAME)];
        DataTable dt = new DataTable();
        dt = objBusinessLayerReports.Read_Qtn_Summary(objEntityReport);

        string[] strTableContents = new string[2];
        strTableContents = ConvertDataTableToHTML(dt, objEntityReport.From_Date, objEntityReport.To_Date, objEntityReport.Division_Id.ToString());
        strResults[0] = strTableContents[0];
        strResults[1] = strTableContents[1];
        strResults[3] = "0";
        if (dt.Rows.Count > 0)
        {
            int intTotalItems = Convert.ToInt32(dt.Rows[0]["CNT"].ToString());
            int intCurrentRowCount = dt.Rows.Count;
            //Pagination
            strResults[2] = objBusinessLayer.GenereatePagination(intTotalItems, objEntityReport.PageNumber, objEntityReport.PageMaxSize, intCurrentRowCount);
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
                sbSearchInputColumns.Append("<th id=\"tdColumnHead_1\" onclick=\"SetOrderByValue(1)\" class=\"sorting th_b11 tr_l\" style=\"word-wrap:break-word;\">EMPLOYEE<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"EMPLOYEE\" placeholder=\"Employee Name\"></th>");
            }
        }
        sbSearchInputColumns.Append("<th id=\"tdColumnHead_2\"  onclick=\"SetOrderByValue(2)\" class=\"sorting th_b4\" style=\"word-wrap:break-word;\">Not Confirmed<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbSearchInputColumns.Append("<th id=\"tdColumnHead_3\"  onclick=\"SetOrderByValue(3)\" class=\"sorting th_b6\" style=\"word-wrap:break-word;\">Confirmed<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbSearchInputColumns.Append("<th id=\"tdColumnHead_4\"  onclick=\"SetOrderByValue(4)\" class=\"sorting th_b6\" style=\"word-wrap:break-word;\">Returned<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbSearchInputColumns.Append("<th id=\"tdColumnHead_5\"  onclick=\"SetOrderByValue(5)\" class=\"sorting th_b6\" style=\"word-wrap:break-word;\">Approved<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbSearchInputColumns.Append("<th id=\"tdColumnHead_6\"  onclick=\"SetOrderByValue(6)\" class=\"sorting th_b6\" style=\"word-wrap:break-word;\">Delivered<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbSearchInputColumns.Append("<th id=\"tdColumnHead_7\"  onclick=\"SetOrderByValue(7)\" class=\"sorting th_b6\" style=\"word-wrap:break-word;\">Reopened<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbSearchInputColumns.Append("<th id=\"tdColumnHead_8\"  onclick=\"SetOrderByValue(8)\" class=\"sorting th_b6\" style=\"word-wrap:break-word;\">Success<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbSearchInputColumns.Append("<th id=\"tdColumnHead_9\"  onclick=\"SetOrderByValue(9)\" class=\"sorting th_b6\" style=\"word-wrap:break-word;\">Lost<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        strResults[1] = sbSearchInputColumns.ToString();
        strResults[2] = intSearchColumnCount.ToString();
        return strResults;
    }

    public enum SearchInputColumns
    {
        //Must be sequential 
        NAME = 0,
    }
    [WebMethod]
    public static string PrintList(string orgID, string corptID, string FromDate, string ToDate, string DivID, string divText)
    {
        string strReturn = "";
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityReports objEntityReport = new clsEntityReports();
        clsBusinessLayerReports objBusinessLayerReports = new clsBusinessLayerReports();
        objEntityReport.Organisation_Id = Convert.ToInt32(orgID);
        objEntityReport.Corporate_Id = Convert.ToInt32(corptID);
        objEntityReport.From_Date = FromDate;
        objEntityReport.To_Date = ToDate;
        objEntityReport.Division_Id = Convert.ToInt32(DivID);
        DataTable dtUser = new DataTable();
        dtUser = objBusinessLayerReports.Read_Qtn_Summary(objEntityReport);

        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.QUOTATION_SUMMARY_RPT_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.QUOTATION_SUMMARY_RPT_PDF);

        objEntityCommon.CorporateID = Convert.ToInt32(corptID);
        objEntityCommon.Organisation_Id = Convert.ToInt32(orgID);
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "QuotationSummaryRpt_" + corptID + "_" + strNextNumber + ".pdf";

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

                footrtable.AddCell(new PdfPCell(new Phrase("From Date  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(FromDate, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase("To Date  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(ToDate, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase("Division  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(divText, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                footrtable.AddCell(new PdfPCell(new Phrase("Total number of records  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(dtUser.Rows.Count.ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                document.Add(footrtable);


                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(9);
                float[] footrsBody = { 15, 14, 11, 10, 10, 10, 10, 10, 10 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("EMPLOYEE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("NOT CONFIRMED", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("CONFIRMED", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("RETURNED", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("APPROVED", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("DELIVERED", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("REOPENED", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("SUCCESS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("LOST", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                string strRandom = objCommon.Random_Number();


                if (dtUser.Rows.Count > 0)
                {
                    int tot1 = 0, tot2 = 0, tot3 = 0, tot4 = 0, tot5 = 0, tot6 = 0, tot7 = 0, tot8 = 0;
                    for (int intRowBodyCount = 0; intRowBodyCount < dtUser.Rows.Count; intRowBodyCount++)
                    {

                        tot1 += Convert.ToInt32(dtUser.Rows[intRowBodyCount][1].ToString());
                        tot2 += Convert.ToInt32(dtUser.Rows[intRowBodyCount][2].ToString());
                        tot3 += Convert.ToInt32(dtUser.Rows[intRowBodyCount][3].ToString());
                        tot4 += Convert.ToInt32(dtUser.Rows[intRowBodyCount][4].ToString());
                        tot5 += Convert.ToInt32(dtUser.Rows[intRowBodyCount][5].ToString());
                        tot6 += Convert.ToInt32(dtUser.Rows[intRowBodyCount][6].ToString());
                        tot7 += Convert.ToInt32(dtUser.Rows[intRowBodyCount][7].ToString());
                        tot8 += Convert.ToInt32(dtUser.Rows[intRowBodyCount][8].ToString());
                      

                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][0].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][1].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][2].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][3].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][4].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][5].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][6].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][7].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][8].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }
                    TBCustomer.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(tot1.ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(tot2.ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(tot3.ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(tot4.ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(tot5.ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(tot6.ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(tot7.ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(tot8.ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
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
            headtable.AddCell(new PdfPCell(new Phrase("QUOTATION SUMMARY", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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


