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
// CREATED BY:EVM-0002
// CREATED DATE:25/05/2016
// REVIEWED BY:
// REVIEW DATE:
public partial class Reports_gen_Active_Leads_gen_Active_Leads_Popup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page_Load();
        }

    }  //It build the Html table by using the datatable provided
    public static string[] ConvertDataTableToHTML(DataTable dt,int corpID)
    {
        string[] strReturn = new string[2];
        string strHtml = "", strHtmlF = "", crns = "";  

        clsEntityReports ObjLeadReport = new clsEntityReports();
        clsBusinessLayerReports ObjBussinessReports = new clsBusinessLayerReports();        
        ObjLeadReport.Corporate_Id = corpID;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strStatus = "";
        int count = 0;
         if (dt.Rows.Count > 0)
        {
            decimal tot=0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            count++;        
            if (dt.Rows[intRowBodyCount]["LDQUOT_ID"].ToString() != "")
            {
                ObjLeadReport.LdQtnId = Convert.ToInt32(dt.Rows[intRowBodyCount]["LDQUOT_ID"].ToString());
            }
            DataTable dtGrp = ObjBussinessReports.ReadGroupAmount(ObjLeadReport);
            
                        string strNewStatus = dt.Rows[intRowBodyCount]["LDSTS_NAME"].ToString();
                        if (strNewStatus == strStatus)
                        {

                        }
                        else
                        {
                            count++;
                            strHtml += "<tr class=\"tr_grp odd\" style=\"background-color: rgba(193, 179, 86, 0.2) !important;\">";
                            strHtml += "<td colspan=\"10\" class=\"tr_l\">"+dt.Rows[intRowBodyCount]["LDSTS_NAME"].ToString()+"</td>";
                            strHtml += " </tr>";
                            strStatus = strNewStatus;
                        }

                        strHtml += "<tr  >";
                        strHtml += "<td class=\" tr_l\">" + dt.Rows[intRowBodyCount][0].ToString() + "</td>";
                        strHtml += "<td>" + dt.Rows[intRowBodyCount][1].ToString() + "</td>";
                        strHtml += "<td>" + dt.Rows[intRowBodyCount][7].ToString() + "</td>";
                        strHtml += "<td class=\" tr_l\">" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";
                        strHtml += "<td class=\" tr_l\">" + dt.Rows[intRowBodyCount][4].ToString() + "</td>";
                        strHtml += "<td class=\" tr_l\">" + dt.Rows[intRowBodyCount][3].ToString() + "</td>";
                        strHtml += "<td>" + dt.Rows[intRowBodyCount][8].ToString() + "</td>";
                        if (dtGrp.Rows.Count > 0)
                        {
                            strHtml += "<td class=\"tr_r\" style=\"word-break: break-all;padding: 0px; word-wrap:break-word;text-align: right;\"><table cellspacing=\"0\" style=\"width: 100%;\" cellpadding=\"2px\">";
                            for (int intLoopCount = 0; intLoopCount < dtGrp.Rows.Count; intLoopCount++)
                            {
                                if(dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"].ToString()!="" && dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"].ToString()!=null){

                                    tot += Convert.ToDecimal(dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"].ToString());
                                }
                                ObjLeadReport.GroupName = dtGrp.Rows[intLoopCount]["QTNDTLGRP_NAME"].ToString();
                                strHtml += "<tr style=\"background-color: inherit !important;\"><td  class=\"tr_r\" style=\" width:100%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;padding-right: 0px;padding-left: 0px;text-align: right; \" >" + dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"].ToString() + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"] + "(" + dtGrp.Rows[intLoopCount]["QTNDTLGRP_NAME"].ToString() + ")</td></tr>";
                            }
                            strHtml += "</table></td>";
                        }
                        else
                        {
                             if(dt.Rows[intRowBodyCount][5].ToString().Trim()!="" && dt.Rows[intRowBodyCount][5].ToString().Trim()!=null){

                                 string[] amnt = dt.Rows[intRowBodyCount][5].ToString().Split(' ');
                                 tot += Convert.ToDecimal(amnt[0]);
                                }
                            strHtml += "<td class=\"tr_r\" >" + dt.Rows[intRowBodyCount][5].ToString() + "</td>";
                        }
               strHtml += "<td>" + dt.Rows[intRowBodyCount][6].ToString() + "</td>";
               strHtml += "<td>" + dt.Rows[intRowBodyCount][11].ToString() + "</td>";
               strHtml += "</tr>";
               if (dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString().Trim() != "")
               {
                   crns = dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString();
               }

        }
        if (tot != 0)
        {
            strHtmlF += "<tr style=\"background-color:#eceff1!important;\">";
            strHtmlF += "<td colspan=\"7\" class=\"txt_rd tr_l\" style=\"background-color:#eceff1!important;\">Total</td>";
            strHtmlF += "<td class=\"txt_rd tr_r\">" + tot + " " + crns + "</td>";
            strHtmlF += "<td class=\"txt_blu\"></td>";
            strHtmlF += "<td class=\"txt_blu\"></td>";
            strHtmlF += "</tr>";

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
    //the methode needs to perform on the initial stage of page
    private void Page_Load()
    {
        int intCorpId = 0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBusinessLayerReports objBusinessLayerReport = new clsBusinessLayerReports();
        clsEntityReports objEntityReport = new clsEntityReports();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReport.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityReport.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Request.QueryString["ID"] != null)
        {
            objEntityReport.Division_Id = Convert.ToInt32(Request.QueryString["id"]);
            hiddenDivisionId.Value = Request.QueryString["id"];
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Request.QueryString["CrnId"] != null)
        {
            hiddenCrncyId.Value = Request.QueryString["CrnId"];
        }
    }
    [WebMethod]
    public static string[] GetData(string OrgId, string CorpId, string PageNumber, string PageMaxSize, string strCommonSearchTerm, string OrderColumn, string OrderMethod, string divID, string crnID)
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBusinessLayerReports objBusinessLayerReport = new clsBusinessLayerReports();
        clsEntityReports objEntityReport = new clsEntityReports();
        objEntityReport.Organisation_Id = Convert.ToInt32(OrgId);
        objEntityReport.Corporate_Id = Convert.ToInt32(CorpId);
        objEntityReport.Division_Id = Convert.ToInt32(divID);
        objEntityReport.CurrencyId = Convert.ToInt32(crnID);
        string[] strResults = new string[5];
        objEntityReport.PageNumber = Convert.ToInt32(PageNumber);
        objEntityReport.PageMaxSize = Convert.ToInt32(PageMaxSize);
        objEntityReport.OrderMethod = Convert.ToInt32(OrderMethod);
        objEntityReport.OrderColumn = Convert.ToInt32(OrderColumn);
        objEntityReport.CommonSearchTerm = strCommonSearchTerm;
        DataTable dt = new DataTable();
        dt = objBusinessLayerReport.Read_Active_Leads_Popup(objEntityReport);

        string[] strTableContents = new string[2];
        strTableContents = ConvertDataTableToHTML(dt, objEntityReport.Corporate_Id);
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
            strResults[4] = dt.Rows[0]["CPRDIV_NAME"].ToString();
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
          sbSearchInputColumns.Append("<th class=\"th_b6 tr_l\">REF#</th>");
                 sbSearchInputColumns.Append("<th class=\"th_b8\">Opportunity</br>Date</th>");
                 sbSearchInputColumns.Append("<th class=\"th_b1\">Ageing</th>");
                 sbSearchInputColumns.Append("<th class=\"th_b2 tr_l\">Customer Name</th>");
                 sbSearchInputColumns.Append("<th class=\"th_b2 tr_l\">Project Name</th>");
                 sbSearchInputColumns.Append("<th class=\"th_b2 tr_l\">Opportunity</br> Owner</th>");
                 sbSearchInputColumns.Append("<th class=\"th_b1\">Rating</th>");
                 sbSearchInputColumns.Append("<th class=\"th_b4 tr_r\">Quote Value</th>");
                 sbSearchInputColumns.Append("<th class=\"th_b8\">Last Updation</th>");
                 sbSearchInputColumns.Append("<th class=\"th_b2\">Project Stage</th>");
       
        strResults[1] = sbSearchInputColumns.ToString();
        strResults[2] = "0";
        return strResults;
    }
    [WebMethod]
    public static string PrintList(string orgID, string corptID, string divID, string crnID)
    {
        string strReturn = "", crns = "";  
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityReports objEntityReport = new clsEntityReports();
        clsBusinessLayerReports objBusinessLayerReports = new clsBusinessLayerReports();
        objEntityReport.Organisation_Id = Convert.ToInt32(orgID);
        objEntityReport.Corporate_Id = Convert.ToInt32(corptID);
        objEntityReport.Division_Id = Convert.ToInt32(divID);
        objEntityReport.CurrencyId = Convert.ToInt32(crnID);
        DataTable dtUser = new DataTable();
        dtUser = objBusinessLayerReports.Read_Active_Leads_Popup(objEntityReport);

        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.ACTIVE_OPPORTUNITY_RPT_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.ACTIVE_OPPORTUNITY_RPT_PDF);

        objEntityCommon.CorporateID = Convert.ToInt32(corptID);
        objEntityCommon.Organisation_Id = Convert.ToInt32(orgID);
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "ActiveOpportunityRpt_" + corptID + "_" + strNextNumber + ".pdf";

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


                footrtable.AddCell(new PdfPCell(new Phrase("Total number of records  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(dtUser.Rows.Count.ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                document.Add(footrtable);


                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(10);
                float[] footrsBody = { 7, 12, 7, 12, 11, 12, 7, 14, 9,9 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("REF#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("OPPORTUNITY DATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("AGEING", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("CUSTOMER NAME", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("PROJECT NAME", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("OPPORTUNITY OWNER", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("RATING", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("QUOTE VALUE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("LAST UPDATION", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("PROJECT STAGE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
               
                string strRandom = objCommon.Random_Number();


                if (dtUser.Rows.Count > 0)
                {
                    string strStatus = "";
                    decimal tot1 = 0;
                    for (int intRowBodyCount = 0; intRowBodyCount < dtUser.Rows.Count; intRowBodyCount++)
                    {

                        if (dtUser.Rows[intRowBodyCount]["LDQUOT_ID"].ToString() != "")
                        {
                            objEntityReport.LdQtnId = Convert.ToInt32(dtUser.Rows[intRowBodyCount]["LDQUOT_ID"].ToString());
                        }
                        DataTable dtGrp = objBusinessLayerReports.ReadGroupAmount(objEntityReport);

                        string strNewStatus = dtUser.Rows[intRowBodyCount]["LDSTS_NAME"].ToString();
                        if (strNewStatus == strStatus)
                        {

                        }
                        else
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount]["LDSTS_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY, Colspan = 10 });
                            strStatus = strNewStatus;
                        }


                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][0].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][1].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][7].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][2].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][4].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][3].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][8].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                       
                        if (dtGrp.Rows.Count > 0)
                        {
                            string rs = "";
                            for (int intLoopCount = 0; intLoopCount < dtGrp.Rows.Count; intLoopCount++)
                            {
                                if (dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"].ToString() != "" && dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"].ToString() != null)
                                {
                                    tot1 += Convert.ToDecimal(dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"].ToString());
                                }
                                objEntityReport.GroupName = dtGrp.Rows[intLoopCount]["QTNDTLGRP_NAME"].ToString();
                                rs += dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"].ToString() + " " + dtUser.Rows[intRowBodyCount]["CRNCMST_ABBRV"] + "(" + dtGrp.Rows[intLoopCount]["QTNDTLGRP_NAME"].ToString() + ")\n";
                            }
                            TBCustomer.AddCell(new PdfPCell(new Phrase(rs, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                        else
                        {
                            if (dtUser.Rows[intRowBodyCount][5].ToString().Trim() != "" && dtUser.Rows[intRowBodyCount][5].ToString().Trim() != null)
                            {

                                string[] amnt = dtUser.Rows[intRowBodyCount][5].ToString().Split(' ');
                                tot1 += Convert.ToDecimal(amnt[0]);
                            }
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][5].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }                        
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][6].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][11].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                        if (dtUser.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString().Trim() != "")
                        {
                            crns = dtUser.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString();
                        }
                    }
                    if (tot1 != 0){
                    TBCustomer.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(tot1.ToString() + " " + crns, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                }
                }
                else
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase(" No data available in table", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 10 });
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
            headtable.AddCell(new PdfPCell(new Phrase("ACTIVE OPPORTUNITIES", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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