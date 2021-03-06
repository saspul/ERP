using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using System.Text;
using CL_Compzit;
using System.Collections;
using System.Web.Services;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
// CREATED BY:EVM-0005
// CREATED DATE:07/06/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class Reports_gen_Item_Listing_gen_Item_List : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
            ddlDivisionSearch.Attributes.Add("onkeypress", "return DisableEnter(event)");
         ddlProductGroup.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlProductGroup.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        if (!IsPostBack)
        {

            Product_Group_Load();
            Category_Type_Load();
            Division_Load();
        }
    }

     public void Product_Group_Load()
    {
        clsBusinessLayerCategory objBusinessLayerCategory = new clsBusinessLayerCategory();
        clsEntityCategory objEntityCategory = new clsEntityCategory();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCategory.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCategory.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtGroup = objBusinessLayerCategory.Read_Product_Group(objEntityCategory);

        ddlProductGroup.Items.Clear();

        ddlProductGroup.DataSource = dtGroup;

        ddlProductGroup.DataTextField = "PRDTGP_NAME";
        ddlProductGroup.DataValueField = "PRDTGP_ID";
        ddlProductGroup.DataBind();

        ddlProductGroup.Items.Insert(0, "--SELECT PRODUCT GROUP--");
    }
     public void Category_Type_Load()
     {
         clsBusinessLayerProductMaster objBusinessLayerProduct = new clsBusinessLayerProductMaster();
         clsEntityProduct_Master objEntityProduct = new clsEntityProduct_Master();
         if (Session["CORPOFFICEID"] != null)
         {
             objEntityProduct.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
         }
         else if (Session["CORPOFFICEID"] == null)
         {
             Response.Redirect("~/Default.aspx");
         }
         if (Session["ORGID"] != null)
         {
             objEntityProduct.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
         }
         else if (Session["ORGID"] == null)
         {
             Response.Redirect("~/Default.aspx");
         }
         DataTable dtType = objBusinessLayerProduct.ReadMainCategory(objEntityProduct);

         ddlCategoryType.Items.Clear();

         ddlCategoryType.DataSource = dtType;

         ddlCategoryType.DataTextField = "CTGRY_NAME";
         ddlCategoryType.DataValueField = "CTGRY_ID";
         ddlCategoryType.DataBind();
     }
    

   



    ////Method for assigning  values to drop down list for Divisionfor search
     public void Division_Load()
     {
         clsBusinessLayerReports objBusinessLayerReports = new clsBusinessLayerReports();
         clsEntityReports objEntityReports = new clsEntityReports();
         if (Session["CORPOFFICEID"] != null)
         {
             objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
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
         if (Session["USERID"] != null)
         {
             objEntityReports.User_Id = Convert.ToInt32(Session["USERID"].ToString());
         }
         else if (Session["USERID"] == null)
         {
             Response.Redirect("~/Default.aspx");
         }

         DataTable dtDivision = objBusinessLayerReports.Read_Division(objEntityReports);



         //Division
         ddlDivisionSearch.DataSource = dtDivision;

         ddlDivisionSearch.DataTextField = "CPRDIV_NAME";
         ddlDivisionSearch.DataValueField = "CPRDIV_ID";
         ddlDivisionSearch.DataBind();
         ddlDivisionSearch.Items.Insert(0, "--SELECT ALL DIVISION--");


     }


     public static string[] ConvertDataTableToHTML(DataTable dt)
     {
         string[] strReturn = new string[2];
         string strHtml = "", strHtmlF = "";

         if (dt.Rows.Count > 0)
         {
             // string tot1 = "";
             //string tot2="";
             //string tot3 = "", tot4 = "", tot5 = "";
             // string tot6 = "";
             //string tot7 = "";

             double tot8 = 0.00;
             for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
             {
                 //   string strDivId = dt.Rows[intRowBodyCount]["CPRDIV_ID"].ToString();
                 strHtml += "<tr  >";
                 //strHtml += "<td class=\" tr_l\"><a onclick='return getdetails(this.href);' href=\"gen_Active_Leads_Popup.aspx?Id</a></td>";
                 strHtml += "<td class=\"tr_l sorting_1\">" + dt.Rows[intRowBodyCount][0].ToString() + "</td>";
                 strHtml += "<td class=\"tr_1\">" + dt.Rows[intRowBodyCount][1].ToString() + "</td>";
                 strHtml += "<td class=\"tr_l\">" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";
                 strHtml += "<td class=\"tr_l\">" + dt.Rows[intRowBodyCount][3].ToString() + "</td>";
                 strHtml += "<td class=\"tr_1\">" + dt.Rows[intRowBodyCount][4].ToString() + "</td>";

                 strHtml += "<td class=\"tr_1\">" + dt.Rows[intRowBodyCount][5].ToString() + "</td>";
                 if (dt.Rows[intRowBodyCount][6].ToString() == "1" && dt.Rows[intRowBodyCount][7].ToString()=="0")
                 {
                     strHtml += "<td class=\"tr_l\"><i class=\"i_cm\"><img src=\"/Images/opp/sa1.png\"></i>Saleable</td>";
                 }
                 if (dt.Rows[intRowBodyCount][6].ToString() == "0" && dt.Rows[intRowBodyCount][7].ToString() == "1")
                 {
                     strHtml += "<td class=\"tr_l\"><i class=\"i_cm\"><img src=\"/Images/opp/st1.png\"> </i>Stockable</td>";
                 }
                 if (dt.Rows[intRowBodyCount][6].ToString() == "1" && dt.Rows[intRowBodyCount][7].ToString() == "1")
                 {
                     strHtml += "<td class=\"tr_l\"><i class=\"i_cm\"><img src=\"/Images/opp/ss1.png\">  </i>Both</td>";
                 }
                 if (dt.Rows[intRowBodyCount][6].ToString() == "0" && dt.Rows[intRowBodyCount][7].ToString() == "0")
                 {
                     strHtml += "<td class=\"tr_l\"></td>";
                 }
                 strHtml += "<td class=\"tr_r\">" + dt.Rows[intRowBodyCount][8].ToString() + "</td>";
                 strHtml += "<td class=\"tr_1\">" + dt.Rows[intRowBodyCount][9].ToString() + "</td>";
                 strHtml += "</tr>";
              
                 tot8 += Convert.ToDouble(dt.Rows[intRowBodyCount][8].ToString());

             }


             strHtmlF += "<tr style=\"background-color:#eceff1!important;\">";
             strHtmlF += "<td colspan=\"7\" class=\" txt_rd bg1 tr_l\" style=\"background-color:#eceff1!important;\">Total</td>";
            
          
             strHtmlF += "<td class= \"txt_rd bg1 tr_r\">" + tot8 + "</td>";
             strHtmlF += "<td class=\" txt_rd bg1\"></td>";
             strHtmlF += "</tr>";

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
     public static string[] GetData(string OrgId, string CorpId, string Userid, string ddlStatus, string nature, string productgrp, string categorytyp, string division, string PageNumber, string PageMaxSize, string strCommonSearchTerm, string OrderColumn, string OrderMethod, string strInputColumnSearch)
     {
         clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
         clsBusinessLayerReports objBusinessLayerReports = new clsBusinessLayerReports();
         clsEntityReports objEntityReport = new clsEntityReports();
         objEntityReport.Organisation_Id = Convert.ToInt32(OrgId);
         objEntityReport.Corporate_Id = Convert.ToInt32(CorpId);
         objEntityReport.User_Id = Convert.ToInt32(Userid);
         objEntityReport.StatusId = Convert.ToInt32(ddlStatus);
         objEntityReport.ProjectId = Convert.ToInt32(nature);
         objEntityReport.GroupId = Convert.ToInt32(productgrp);
         objEntityReport.GuarCatgryId = Convert.ToInt32(categorytyp);
         objEntityReport.Division_Id = Convert.ToInt32(division);
         string[] strResults = new string[4];
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
         clsCommonLibrary objCommon = new clsCommonLibrary();
         objEntityReport.SearchCode= strSearchInputs[Convert.ToInt32(SearchInputColumns.CODE)];
         objEntityReport.SearchProduct = strSearchInputs[Convert.ToInt32(SearchInputColumns.PRODUCT)];
         objEntityReport.SearchGroup = strSearchInputs[Convert.ToInt32(SearchInputColumns.GROUP)];
         objEntityReport.SearchCategory= strSearchInputs[Convert.ToInt32(SearchInputColumns.CATEGORY)];
         objEntityReport.SearchBrand= strSearchInputs[Convert.ToInt32(SearchInputColumns.BRAND)];
         objEntityReport.SearchDivision = strSearchInputs[Convert.ToInt32(SearchInputColumns.DIVISION)];
         objEntityReport.Searchnature = strSearchInputs[Convert.ToInt32(SearchInputColumns.NATURE)];
         objEntityReport.SearchExcode = strSearchInputs[Convert.ToInt32(SearchInputColumns.EXCODE)];
         DataTable dt = new DataTable();
         dt = objBusinessLayerReports.getReadProductlist(objEntityReport);

         string[] strTableContents = new string[2];
         strTableContents = ConvertDataTableToHTML(dt);
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
         html.Append("<p><span class=\"tbl_srt1\">Show</span> <select class=\"form-control tbl_srt\" onchange=\"getdata(1);\" id=\"ddl_page_size\">");
         html.Append("<option value=\"10\">10</option><option value=\"25\">25</option><option value=\"50\">50</option><option value=\"100\">100</option></select> entries");
         html.Append("</p></div>");
         //page length ends
         //common filter
         html.Append("<div class=\"col-md-2 pull-right\" style=\"padding-right: 0px;\">");
         html.Append("<input  autocomplete=\"off\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"SettypingTimer(event);\" class=\"form-control tbl_ser_n\" id=\"txtCommonSearch_dt\"  type=\"search\" placeholder=\" Search \" aria-controls=\"example\">");
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
                 sbSearchInputColumns.Append("<th id=\"tdColumnHead_1\" onclick=\"SetOrderByValue(1)\" class=\"th_b1 tr_l sorting_asc\" style=\"word-wrap:break-word;\">PRODUCT CODE<br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"Product Code\" placeholder=\"Product Code\"></th>");
             }
             if (Convert.ToInt32(item).ToString() == "1")
             {
                 sbSearchInputColumns.Append("<th id=\"tdColumnHead_2\" onclick=\"SetOrderByValue(2)\" class=\"th_b4 tr_l sorting_asc\" style=\"word-wrap:break-word;\">PRODUCT<br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"Product\" placeholder=\"Product\"></th>");

             }
             if (Convert.ToInt32(item).ToString() == "2")
             {
                 sbSearchInputColumns.Append("<th id=\"tdColumnHead_3\" onclick=\"SetOrderByValue(3)\" class=\"th_b6 tr_l sorting\" style=\"word-wrap:break-word;\">PRODUCT GROUP<br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"Prodcut Group\" placeholder=\"Product Group\"></th>");
             }
             if (Convert.ToInt32(item).ToString() == "3")
             {
                 sbSearchInputColumns.Append("<th id=\"tdColumnHead_4\" onclick=\"SetOrderByValue(4)\" class=\"th_b6 tr_l sorting\" style=\"word-wrap:break-word;\">MAIN CATEGORY<br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"Main Category\" placeholder=\"Main Category\"></th>");
             }
             if (Convert.ToInt32(item).ToString() == "4")
             {
                 sbSearchInputColumns.Append("<th id=\"tdColumnHead_5\" onclick=\"SetOrderByValue(5)\" class=\"th_b7 tr_l sorting_asc\" style=\"word-wrap:break-word;\">PRODUCT BRAND<br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"Product Brand\" placeholder=\"Product Brand\"></th>");
             }
             if (Convert.ToInt32(item).ToString() == "5")
             {
                 sbSearchInputColumns.Append("<th id=\"tdColumnHead_6\" onclick=\"SetOrderByValue(6)\" class=\"th_b7 tr_l sorting\" style=\"word-wrap:break-word;\">DIVISION<br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"Division\" placeholder=\"Division\"></th>");
             }
             if (Convert.ToInt32(item).ToString() == "6")
             {
                 sbSearchInputColumns.Append("<th id=\"tdColumnHead_7\" onclick=\"SetOrderByValue(7)\" class=\"th_b7 tr_l sorting\" style=\"word-wrap:break-word;\">PRODUCT NATURE<br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"Product Nature\" placeholder=\"Product Nature\"></th>");
             }

             if (Convert.ToInt32(item).ToString() == "7")
             {
                 sbSearchInputColumns.Append("<th id=\"tdColumnHead_8\"  onclick=\"SetOrderByValue(8)\" class=\"th_b1 tr_r sorting\" style=\"word-wrap:break-word;\">COST PRICE</th>");

             }
             if (Convert.ToInt32(item).ToString() == "8")
             {
                 sbSearchInputColumns.Append("<th id=\"tdColumnHead_9\" onclick=\"SetOrderByValue(9)\" class=\"th_b1 tr_l sorting\" style=\"word-wrap:break-word;width: 105px;\">EXTERNAL &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp APP CODE<br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"External App\" placeholder=\"External App\"></th>");

             }
         }


          strResults[1] = sbSearchInputColumns.ToString();
         strResults[2] = intSearchColumnCount.ToString();
         return strResults;
     }

     public enum SearchInputColumns
     {
         //Must be sequential 
        CODE = 0,
        PRODUCT = 1,
        GROUP = 2,
        CATEGORY = 3,
       BRAND = 4,
       DIVISION = 5,
         NATURE=6,
         COST=7,
         EXCODE=8,

     }


     [WebMethod]
     public static string PrintList(string orgID, string corptID, string userid,string status, string nature, string productgrp, string categorytyp,string division,string grp,string cty,string div,string sts,string nat)
    {
        string strReturn = "";
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerReports objBusinessLayerReports = new clsBusinessLayerReports();
        clsEntityReports objEntityReport = new clsEntityReports();
        objEntityReport.Organisation_Id = Convert.ToInt32(orgID);
        objEntityReport.Corporate_Id = Convert.ToInt32(corptID);
        objEntityReport.User_Id = Convert.ToInt32(userid);
        objEntityReport.StatusId = Convert.ToInt32(status);
        objEntityReport.ProjectId = Convert.ToInt32(nature);
        objEntityReport.GroupId = Convert.ToInt32(productgrp);
        objEntityReport.GuarCatgryId = Convert.ToInt32(categorytyp);
        objEntityReport.Division_Id = Convert.ToInt32(division);
    
      
        DataTable dtUser = new DataTable();
        dtUser =objBusinessLayerReports.getReadProductlist(objEntityReport);

        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.ITEM_LIST_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.ITEM_LIST_PDF);

        objEntityCommon.CorporateID = Convert.ToInt32(corptID);
        objEntityCommon.Organisation_Id = Convert.ToInt32(orgID);
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "ItemListing_" + corptID + "_" + strNextNumber + ".pdf";

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
                float[] footrsBody1 = { 30, 5, 65 };
                footrtable.SetWidths(footrsBody1);
                footrtable.WidthPercentage = 100;


                footrtable.AddCell(new PdfPCell(new Phrase("TOTAL NUMBER OF RECORDS  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(dtUser.Rows.Count.ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (status != "2")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("STATUS ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(sts, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
              
                if (nature != "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("PRODUCT NATURE ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(nat, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (productgrp != "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("PRODUCT GROUP", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(grp, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (categorytyp != "")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("CATEGORY TYPE ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(cty, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (division!= "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("DIVISION", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(div, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                document.Add(footrtable);


                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(9);
                float[] footrsBody = { 10,10,10,10,10,10,10,10,10 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("PRODUCT CODE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("PRODUCT GROUP", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("MAIN CATEGORY", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("PRODUCT BRAND", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("DIVISION", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("PRODUCT NATURE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("COST PRICE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("EXTERNAL APP CODE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                string strRandom = objCommon.Random_Number();


                if (dtUser.Rows.Count > 0)
                {
                    double tot8 = 0;
                    for (int intRowBodyCount = 0; intRowBodyCount < dtUser.Rows.Count; intRowBodyCount++)
                    {

                      
                        tot8 += Convert.ToDouble(dtUser.Rows[intRowBodyCount][8].ToString());

                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][0].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][1].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][2].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][3].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][4].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][5].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                        if (dtUser.Rows[intRowBodyCount][6].ToString() == "1" && dtUser.Rows[intRowBodyCount][7].ToString() == "0")
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase("Saleable", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                        }
                        else if (dtUser.Rows[intRowBodyCount][6].ToString() == "0" && dtUser.Rows[intRowBodyCount][7].ToString() == "1")
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase("Stockable", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                        else  if (dtUser.Rows[intRowBodyCount][6].ToString() == "1" && dtUser.Rows[intRowBodyCount][7].ToString() == "1")
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase("Both", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                    else    if (dtUser.Rows[intRowBodyCount][6].ToString() == "0" && dtUser.Rows[intRowBodyCount][7].ToString() == "0")
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                        else
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                    }
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][8].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][9].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }
                    TBCustomer.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
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
            headtable.AddCell(new PdfPCell(new Phrase("ITEM LISTING", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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


       

