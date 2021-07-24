using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using BL_Compzit.BusineesLayer_FMS;
using EL_Compzit.EntityLayer_FMS;
using CL_Compzit;
using EL_Compzit;
using System.Data;
using System.Text;
using System.Web.Services;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using BL_Compzit.BusinessLayer_GMS;

public partial class FMS_FMS_Reports_fms_Supplier_Outstanding_fms_Supplier_Outstanding : System.Web.UI.Page
{
    public static int IntCorpIdSession = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FRMWRK_ID"] != null && Session["FRMWRK_ID"].ToString() == "2")
        {
            aHome.HRef = "/Home/Compzit_Home/Compzit_Home_Finance.aspx";
        }
        else
        {
            aHome.HRef = " /Home/Compzit_LandingPage/Compzit_LandingPage.aspx";
        }
        if (!IsPostBack)
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            cls_Business_SupplierOutstanding ObjBusinessCustomer = new cls_Business_SupplierOutstanding();
            clsEntitySupplierOutstanding objEntityCustomer = new clsEntitySupplierOutstanding();
            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
            int intCorpId = 0;

            if (Session["ORGID"] != null)
            {
                objEntityCustomer.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityCustomer.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
                IntCorpIdSession = intCorpId;
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityCustomer.Corporate_id = Convert.ToInt32(strId);
                intCorpId = Convert.ToInt32(strId);
                HiddenFieldCorpId.Value = strId;
            }
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CorporateID = objEntityCustomer.Corporate_id;
            objEntityCommon.Organisation_Id = objEntityCustomer.Organisation_Id;

            if (Session["FINCYRID"] != null)
            {
                objEntityCommon.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            if (Request.QueryString["Id"] != null)
            {
                DataTable dtfinaclYear1 = objBusinessLayer.ReadFinancialYear(objEntityCommon);
                if (dtfinaclYear1.Rows.Count > 0)
                {
                    if (dtfinaclYear1.Rows[0]["FINCYR_ID"].ToString() != "")
                    {
                        objEntityCommon.FinancialYrId = Convert.ToInt32(dtfinaclYear1.Rows[0]["FINCYR_ID"].ToString());
                    }
                }
                else
                {
                    DataTable dtCorpDetail1 = new DataTable();
                    clsCommonLibrary.CORP_GLOBAL[] arrEnumer1 = { clsCommonLibrary.CORP_GLOBAL.ACTIVE_FINCYR_ID };
                    dtCorpDetail1 = objBusinessLayer.LoadGlobalDetail(arrEnumer1, intCorpId);
                    if (dtCorpDetail1.Rows.Count > 0)
                    {
                        if (dtCorpDetail1.Rows[0]["ACTIVE_FINCYR_ID"].ToString() != "")
                        {
                            objEntityCommon.FinancialYrId = Convert.ToInt32(dtCorpDetail1.Rows[0]["ACTIVE_FINCYR_ID"].ToString());
                        }
                    }
                }
            }
            DataTable dtfinaclYear = objBusinessLayer.ReadFinancialYearById(objEntityCommon);

            HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
            HiddenEndDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
            DateTime curdate = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());
            if (curdate >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate <= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
            {
                txtFromdate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                txtTodate.Value = objBusinessLayer.LoadCurrentDate().ToString("dd-MM-yyyy");
            }
            else
            {
                txtTodate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                curdate = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString());
                curdate = curdate.AddDays(-30);
                if (curdate >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()))
                {
                    txtFromdate.Value = curdate.ToString("dd-MM-yyyy");
                }
                else
                {
                    txtFromdate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                }
            }

            HiddenFieldSearchFromDate.Value = txtFromdate.Value;
            HiddenFieldSearchToDate.Value = txtTodate.Value;


            HiddenEndDate.Value=strCurrentDate;
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT
                                                       };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();

            }
            if (txtFromdate.Value != "")
            {
                objEntityCustomer.FinancialStartDate = objCommon.textToDateTime(txtFromdate.Value);
            }
            if (txtTodate.Value != "")
            {
                objEntityCustomer.SupplierDate = objCommon.textToDateTime(txtTodate.Value);
            }
            objEntityCustomer.PrimaryGrpIds = Convert.ToString(Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.SUNDRYCREDITR));
            objEntityCustomer.FinancialEndDate = objCommon.textToDateTime(HiddenEndDate.Value);
            DataTable dtCustomer = ObjBusinessCustomer.ReadSupplier(objEntityCustomer);
            divList.InnerHtml = ConvertDataTableToHTML(dtCustomer);

        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        cls_Business_SupplierOutstanding ObjBusinessCustomer = new cls_Business_SupplierOutstanding();
        clsEntitySupplierOutstanding objEntityCustomer = new clsEntitySupplierOutstanding();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (Session["ORGID"] != null)
        {
            objEntityCustomer.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCustomer.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Request.QueryString["Id"] != null)
        {
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityCustomer.Corporate_id = Convert.ToInt32(strId);
        }
        if (txtFromdate.Value != "")
        {
            objEntityCustomer.FinancialStartDate = objCommon.textToDateTime(txtFromdate.Value);
        }
        if (txtTodate.Value != "")
        {
            objEntityCustomer.SupplierDate = objCommon.textToDateTime(txtTodate.Value);
        }
        HiddenFieldSearchFromDate.Value = txtFromdate.Value;
        HiddenFieldSearchToDate.Value = txtTodate.Value;
        //objEntityCustomer.FinancialStartDate = objCommon.textToDateTime(HiddenStartDate.Value);
        objEntityCustomer.FinancialEndDate = objCommon.textToDateTime(HiddenEndDate.Value);
        objEntityCustomer.PrimaryGrpIds = Convert.ToString(Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.SUNDRYCREDITR));
        DataTable dtCustomer = ObjBusinessCustomer.ReadSupplier(objEntityCustomer);
        divList.InnerHtml = ConvertDataTableToHTML(dtCustomer);
       // divPrintReport.InnerHtml = ConvertDataTableToPrint(dtCustomer);
       // divPrintCaption.InnerHtml = PrintCaption(objEntityCustomer);
    }

    //main list table
    public string ConvertDataTableToHTML(DataTable dt)
    {
        cls_Business_SupplierOutstanding ObjBusinessCustomer = new cls_Business_SupplierOutstanding();
        clsEntitySupplierOutstanding objEntityCustomer = new clsEntitySupplierOutstanding();
          clsBusinessOutstandingAgeing objBussinessAging = new clsBusinessOutstandingAgeing();
        clsEntityOutstandingAgeing ObjEntityRequest1 = new clsEntityOutstandingAgeing();
        if (Session["ORGID"] != null)
        {
            objEntityCustomer.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCustomer.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        int intSLNo = 0;
        int precision = Convert.ToInt32(hiddenDecimalCount.Value);
        string format = String.Format("{{0:N{0}}}", precision);
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"display table-bordered\" width=\"100%\" >";
        //add header row
        strHtml += "<thead class=\"thead1\">";
        strHtml += "<tr >";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount <= 3; intColumnHeaderCount++)
        {
            //if (intColumnHeaderCount == 0)
            //{
            //    strHtml += "<th class=\"hasinput\" style=\"width:8%;text-align:left;\">SL #";
            //    strHtml += "</th >";
            //}
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"col-md-7 tr_l\" >SUPPLIER";
                strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in\" placeholder=\"SUPPLIER\" type=\"text\">";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:20%;text-align:right;display:none;\">CREDIT AMOUNT";
                strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input onkeypress=\"return disableenter(event)\" onkeydown=\"return disableenter(event)\" class=\"form-control\" placeholder=\"CREDIT AMOUNT\" style=\"text-align:right;\" type=\"text\">";
                strHtml += "</th >";
               

                strHtml += "<th class=\"col-md-2 tr_r\" >OUTSTANDING AMOUNT";
                strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_r\" placeholder=\"OUTSTANDING AMOUNT\"  type=\"text\">";
                strHtml += "</th >";
            }
            //else if (intColumnHeaderCount == 3)
            //{
            //    strHtml += "<th class=\"hasinput\" style=\"width:20%;text-align:right;\">DEBIT AMOUNT";
            //    strHtml += "<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"form-control\" placeholder=\"DEBIT AMOUNT\" style=\"text-align:right;\" type=\"text\">";
            //    strHtml += "</th >";
            //}
        }
        strHtml += "</th >";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        string valuestringAmnt = "";

        decimal decSumDebAmnt = 0, decSumCreAmnt = 0;
        int flag = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            
            string CrOrDr = "CR";
            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            string strOutAmt = "";

            decimal decAmnt1 = 0;
            if (dt.Rows[intRowBodyCount]["LDGR_BAL"].ToString() != "")
            {
                decAmnt1 = Convert.ToDecimal(dt.Rows[intRowBodyCount]["LDGR_BAL"].ToString());
            }
            decimal decAmnt = 0;
            if (dt.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString() != "")
            {
                decAmnt = Convert.ToDecimal(dt.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString());
            }
            if (dt.Rows[intRowBodyCount]["LDGR_MODE"].ToString() == "1")
            {
                strOutAmt = Convert.ToString(decAmnt1 - decAmnt);
            }
            else
            {
                strOutAmt = Convert.ToString(decAmnt1 + decAmnt);
            }
            if (Convert.ToDecimal(strOutAmt) < 0)
            {
                strOutAmt = strOutAmt.Substring(1);
                decSumCreAmnt += Convert.ToDecimal(strOutAmt);
            }
            else
            {
                decSumDebAmnt += Convert.ToDecimal(strOutAmt);
                CrOrDr = "DR";
            }
            valuestringAmnt = String.Format(format, Convert.ToDecimal(strOutAmt));

            if (Convert.ToDecimal(strOutAmt) != 0)
            {
                ObjEntityRequest1.CustomerId = Convert.ToInt32(dt.Rows[intRowBodyCount]["LDGR_ID"].ToString());
                ObjEntityRequest1.Corporate_id = objEntityCustomer.Corporate_id;
                ObjEntityRequest1.Organisation_id = objEntityCustomer.Organisation_Id;

                flag = 1;
                intSLNo++;
         //       strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + intSLNo + "</td>";
                strHtml += "<td class=\"tr_l\" > <a  title=\"View\"  onclick=\"return OpenCustomerDetails('" + Id + "','" + intRowBodyCount + "','0');\" href=\"javascript:;\">" + dt.Rows[intRowBodyCount]["LDGR_NAME"].ToString()+"</a>";
                    
                           //postdated chq
                DataTable dtPostDate = objBussinessAging.ReadPostdatedChqDtls(ObjEntityRequest1);
                if (dtPostDate.Rows.Count > 0)
                {
                    strHtml += "<span href=\"javascript:;\" class=\"pst_dt_bx pull-right\" title=\"Postdated Cheque\" onclick=\"return PostdatedChqDisplay('" + Id + "');\" data-toggle=\"modal\" data-target=\"#divPostdatedChq\" ><i class=\"fa fa-list-alt ad_fa ad_posd pa_fa\"></i></span>";
                }
                 strHtml += "</td>";
                strHtml += "<td class=\"tdT\" id=\"tdAmnt" + intRowBodyCount + "\" style=\"display:none;\">" + dt.Rows[intRowBodyCount]["LDGR_NAME"].ToString() ;
              
                    
               strHtml += "</td>";
                strHtml += "<td class=\"tr_r\" > ";
               

                strHtml += " <a  title=\"View\"  onclick=\"return OpenCustomerDetails('" + Id + "','" + intRowBodyCount + "','1');\" href=\"javascript:;\">";
                strHtml += "" + valuestringAmnt + " " + CrOrDr + "</td>";
                strHtml += "</tr>";
            }

        }
        if (flag == 0)
        {
            strHtml += "<td class=\"tdT\"colspan=\"2\" style=\" width:16%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No Data Available</td>";
            strHtml += "</tr>";
        }
        strHtml += "</tbody>";
        string strModeTot = "CR";
        decimal FinTot = decSumDebAmnt - decSumCreAmnt;
        if (FinTot < 0)
        {
            FinTot = FinTot * -1;
        }
        else
        {
            strModeTot = "DR";
        }
        valuestringAmnt = String.Format(format, FinTot);
        if (flag > 0)
        {
            strHtml += "<tfoot><tr>";
         //   strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";
            strHtml += "<td class=\"txt_rd bg1 tr_l\"  >TOTAL</td>";
            strHtml += "<td class=\"txt_rd bg1\" style=\"display:none;\"></td>";
            strHtml += "<td class=\"txt_rd bg1 tr_r\" >" + valuestringAmnt + " " + strModeTot + "</td>";
            strHtml += "</tr>";
            strHtml += "</tfoot>";
        }
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    public string ConvertDataTableToPrintPdf(DataTable dtCustomer, clsEntitySupplierOutstanding objEntityCustomer, string decimalCount)
    {
        string strRet = "";
        string strId1 = "";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        string strRandom = objCommon.Random_Number();
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.SUPPLIER_OUTSTANDING_PDF);

        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SUPPLIER_OUTSTANDING_PDF);
        objEntityCommon.CorporateID = objEntityCustomer.Corporate_id;
        objEntityCommon.Organisation_Id = objEntityCustomer.Organisation_Id;
        string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "SupplierOutstanding_" + strNextNumber + ".pdf";

        Document document = new Document(PageSize.A4, 50f, 40f, 120f, 30f);
        document = new Document(PageSize.LETTER, 50f, 40f, 20f, 40f);
        Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
        int precision = Convert.ToInt32(decimalCount);
        string format = String.Format("{{0:N{0}}}", precision);
        try
        {
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                PdfWriter writer = PdfWriter.GetInstance(document, file);
                writer.PageEvent = new PDFHeader();
                document.Open();

                string Sdate = objEntityCustomer.SupplierDate.ToString("dd-MM-yyyy");

                PdfPTable footrtable = new PdfPTable(3);
                float[] footrsBody1 = { 20, 5, 75 };
                footrtable.SetWidths(footrsBody1);
                footrtable.WidthPercentage = 100;

                footrtable.AddCell(new PdfPCell(new Phrase("FROM DATE     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(objEntityCustomer.FinancialStartDate.ToString("dd-MM-yyyy"), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase("TO DATE          ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(Sdate, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                document.Add(footrtable);

                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(2);
                float[] footrsBody = { 80, 20 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;//get header column in all pages

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("SUPPLIER", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("OUTSTANDING AMOUNT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                string valuestringAmnt = "";
                decimal decSumDebAmnt = 0, decSumCreAmnt = 0;
                int flag = 0;
                for (int intRowBodyCount = 0; intRowBodyCount < dtCustomer.Rows.Count; intRowBodyCount++)
                {
                    string strId = dtCustomer.Rows[intRowBodyCount][0].ToString();
                    int intIdLength = dtCustomer.Rows[intRowBodyCount][0].ToString().Length;
                    string stridLength = intIdLength.ToString("00");
                    string Id = stridLength + strId + strRandom;
                    string CrOrDr = "CR";
                    string strOutAmt = "";
                    decimal decAmnt1 = 0;
                    if (dtCustomer.Rows[intRowBodyCount]["LDGR_BAL"].ToString() != "")
                    {
                        decAmnt1 = Convert.ToDecimal(dtCustomer.Rows[intRowBodyCount]["LDGR_BAL"].ToString());
                    }
                    decimal decAmnt = 0;
                    if (dtCustomer.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString() != "")
                    {
                        decAmnt = Convert.ToDecimal(dtCustomer.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString());
                    }
                    if (dtCustomer.Rows[intRowBodyCount]["LDGR_MODE"].ToString() == "1")
                    {
                        strOutAmt = Convert.ToString(decAmnt1 - decAmnt);
                    }
                    else
                    {
                        strOutAmt = Convert.ToString(decAmnt1 + decAmnt);
                    }
                    if (Convert.ToDecimal(strOutAmt) < 0)
                    {
                        strOutAmt = strOutAmt.Substring(1);
                        decSumCreAmnt += Convert.ToDecimal(strOutAmt);
                    }
                    else
                    {
                        CrOrDr = "DR";
                        decSumDebAmnt += Convert.ToDecimal(strOutAmt);
                    }
                    valuestringAmnt = String.Format(format, Convert.ToDecimal(strOutAmt));
                    if (Convert.ToDecimal(strOutAmt) != 0)
                    {
                        flag = 1;
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCustomer.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }
                }
                if (flag == 0)
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase("No Data Available", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 2 });
                }
                string strModeTot = "CR";
                decimal FinTot = decSumDebAmnt - decSumCreAmnt;
                if (FinTot < 0)
                {
                    FinTot = FinTot * -1;
                }
                else
                {
                    strModeTot = "DR";
                }
                valuestringAmnt = String.Format(format, FinTot);
                if (flag > 0)
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(valuestringAmnt + " " + strModeTot, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                }
                document.Add(TBCustomer);
                document.Close();
            }
            strRet = strImagePath + strImageName;
        }
        catch (Exception)
        {
            document.Close();
            strRet = "false";
        }
        return strRet;
    }
    public string ConvertDataTableToPrintCSV(DataTable dtCustomer, clsEntitySupplierOutstanding objEntityCustomer, string decimalCount)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        DataTable dt = GetTableList(dtCustomer, objEntityCustomer, decimalCount);
        string strResult = DataTableToCSV(dt, ',');

        objEntityCommon.CorporateID = objEntityCustomer.Corporate_id;
        objEntityCommon.Organisation_Id = objEntityCustomer.Organisation_Id;
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SUPPLIER_OUTSTANDING_CSV);

        string strNextId = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string filepath = "SupplierOutstandingList_" + strNextId + ".csv";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.SUPPLIER_OUTSTANDING_CSV);
        string newFilePath = Server.MapPath(strImagePath + filepath);
        System.IO.File.WriteAllText(newFilePath, strResult);

        return strImagePath + filepath;
    }
    public DataTable GetTableList(DataTable dtCustomer, clsEntitySupplierOutstanding objEntityCustomer, string decimalCount)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();

        int intCorpId = 0;
        intCorpId = objEntityCustomer.Corporate_id;
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
        }

        int precision = Convert.ToInt32(decimalCount);
        string format = String.Format("{{0:N{0}}}", precision);

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        string FORNULL = "";
        DataTable table = new DataTable();

        table.Columns.Add("SUPPLIER OUTSTANDING REPORT", typeof(string));
        table.Columns.Add(" ", typeof(string));

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"');

        table.Rows.Add('"' + "FROM DATE :" + '"', '"' + objEntityCustomer.FinancialStartDate.ToString("dd-MM-yyyy") + '"');
        table.Rows.Add('"' + "TO DATE :" + '"', '"' + objEntityCustomer.SupplierDate.ToString("dd-MM-yyyy") + '"');

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"');

        table.Rows.Add('"' + "SUPPLIER" + '"', '"' + "OUTSTANDING AMOUNT" + '"');

        string valuestringAmnt = "";
        decimal decSumDebAmnt = 0, decSumCreAmnt = 0;
        int flag = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dtCustomer.Rows.Count; intRowBodyCount++)
        {
            string strId = dtCustomer.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dtCustomer.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

            string CrOrDr = "CR";
            string strOutAmt = "";
            decimal decAmnt1 = 0;
            if (dtCustomer.Rows[intRowBodyCount]["LDGR_BAL"].ToString() != "")
            {
                decAmnt1 = Convert.ToDecimal(dtCustomer.Rows[intRowBodyCount]["LDGR_BAL"].ToString());
            }
            decimal decAmnt = 0;
            if (dtCustomer.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString() != "")
            {
                decAmnt = Convert.ToDecimal(dtCustomer.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString());
            }
            if (dtCustomer.Rows[intRowBodyCount]["LDGR_MODE"].ToString() == "1")
            {
                strOutAmt = Convert.ToString(decAmnt1 - decAmnt);
            }
            else
            {
                strOutAmt = Convert.ToString(decAmnt1 + decAmnt);
            }
            if (Convert.ToDecimal(strOutAmt) < 0)
            {
                strOutAmt = strOutAmt.Substring(1);
                decSumCreAmnt += Convert.ToDecimal(strOutAmt);
            }
            else
            {
                CrOrDr = "DR";
                decSumDebAmnt += Convert.ToDecimal(strOutAmt);
            }
            valuestringAmnt = String.Format(format, Convert.ToDecimal(strOutAmt));
            if (Convert.ToDecimal(strOutAmt) != 0)
            {
                flag = 1;
                table.Rows.Add('"' + dtCustomer.Rows[intRowBodyCount]["LDGR_NAME"].ToString() + '"', '"' + valuestringAmnt + '"');
            }
        }

        string strModeTot = "CR";
        decimal FinTot = decSumDebAmnt - decSumCreAmnt;
        if (FinTot < 0)
        {
            FinTot = FinTot * -1;
        }
        else
        {
            strModeTot = "DR";
        }
        valuestringAmnt = String.Format(format, FinTot);
        if (flag > 0)
        {
            table.Rows.Add('"' + "TOTAL" + '"', '"' + valuestringAmnt + '"');
        }

        return table;
    }


    //list check which print
    [WebMethod]
    public static string[] CustomerDetails(string intorgid, string intcorpid, string intdatefrom, string decimalCount, string Financialfrom, string FinancialEnd, string strPrintMode)
    {
        string[] result = new string[10];
        cls_Business_SupplierOutstanding ObjBusinessCustomer = new cls_Business_SupplierOutstanding();
        clsEntitySupplierOutstanding objEntityCustomer = new clsEntitySupplierOutstanding();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        FMS_FMS_Reports_fms_Supplier_Outstanding_fms_Supplier_Outstanding obj = new FMS_FMS_Reports_fms_Supplier_Outstanding_fms_Supplier_Outstanding();
        int corp = Convert.ToInt32(intcorpid);
        objEntityCustomer.SupplierDate = ObjCommonlib.textToDateTime(intdatefrom.ToString());
        objEntityCustomer.Organisation_Id = Convert.ToInt32(intorgid);
        objEntityCustomer.Corporate_id = corp;
        StringBuilder sb = new StringBuilder();
        objEntityCustomer.FinancialStartDate = ObjCommonlib.textToDateTime(Financialfrom);
        objEntityCustomer.FinancialEndDate = ObjCommonlib.textToDateTime(FinancialEnd);
        objEntityCustomer.PrimaryGrpIds = Convert.ToString(Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.SUNDRYCREDITR));
        DataTable dtCustomer = ObjBusinessCustomer.ReadSupplier(objEntityCustomer);
        DataTable DT = new DataTable();
        //result[1] = obj.ConvertDataTableToPrint(dtCustomer, objEntityCustomer, decimalCount);
        //result[3] = obj.PrintCaption(objEntityCustomer, DT, 0);
        if (strPrintMode == "csv")
        {
            result[2] = obj.ConvertDataTableToPrintCSV(dtCustomer, objEntityCustomer, decimalCount);
        }
        else
        {
            result[2] = obj.ConvertDataTableToPrintPdf(dtCustomer, objEntityCustomer, decimalCount);
        }
        return result;
    }


    //popup check if statemnt/outstanding statmnt of accnt
    [WebMethod]
    public static string[] CustomerDetails_ById(string StrId, string intorgid, string intcorpid, string intdatefrom, string decimalCount, string Financialfrom, string FinancialEnd, string mode)
    {
        string[] result = new string[10];
        cls_Business_SupplierOutstanding ObjBusinessCustomer = new cls_Business_SupplierOutstanding();
        clsEntitySupplierOutstanding objEntityCustomer = new clsEntitySupplierOutstanding();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        FMS_FMS_Reports_fms_Supplier_Outstanding_fms_Supplier_Outstanding obj = new FMS_FMS_Reports_fms_Supplier_Outstanding_fms_Supplier_Outstanding();
        string strRandomMixedId = StrId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        int corp = Convert.ToInt32(intcorpid);
        objEntityCustomer.SupplierDate = ObjCommonlib.textToDateTime(intdatefrom.ToString());
        objEntityCustomer.Organisation_Id = Convert.ToInt32(intorgid);
        objEntityCustomer.Corporate_id = corp;
        objEntityCustomer.Ledger_id = Convert.ToInt32(strId);
        objEntityCustomer.FinancialStartDate = ObjCommonlib.textToDateTime(Financialfrom);
        objEntityCustomer.FinancialEndDate = ObjCommonlib.textToDateTime(FinancialEnd);
        objEntityCustomer.TransactionType = Convert.ToInt32(mode);
        DataTable dtCustDtl = ObjBusinessCustomer.ReadSupplierInfo(objEntityCustomer);
        StringBuilder sb = new StringBuilder();
        DataTable dtCustomer = ObjBusinessCustomer.ReadSuppliersDetails(objEntityCustomer);
        result[1] = obj.LoadCustomerDetails(dtCustomer, objEntityCustomer, decimalCount, mode);
       // result[4] = obj.LoadCustomerDetailsPrint(dtCustomer, objEntityCustomer, decimalCount, mode);
      //  result[5] = obj.CustomerDetailsToPrintPdf(dtCustomer, objEntityCustomer, decimalCount, mode);
        result[2] = strId;
        //result[3] = obj.PrintCaption(objEntityCustomer, dtCustDtl, Convert.ToInt32(mode));
        return result;

    }
    [WebMethod]
    public static string[] CustomerDetails_ById_Print(string StrId, string intorgid, string intcorpid, string intdatefrom, string decimalCount, string Financialfrom, string FinancialEnd, string mode,string strPrintMode)
    {
        string[] result = new string[10];
        cls_Business_SupplierOutstanding ObjBusinessCustomer = new cls_Business_SupplierOutstanding();
        clsEntitySupplierOutstanding objEntityCustomer = new clsEntitySupplierOutstanding();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        FMS_FMS_Reports_fms_Supplier_Outstanding_fms_Supplier_Outstanding obj = new FMS_FMS_Reports_fms_Supplier_Outstanding_fms_Supplier_Outstanding();
        string strRandomMixedId = StrId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        int corp = Convert.ToInt32(intcorpid);
        objEntityCustomer.SupplierDate = ObjCommonlib.textToDateTime(intdatefrom.ToString());
        objEntityCustomer.Organisation_Id = Convert.ToInt32(intorgid);
        objEntityCustomer.Corporate_id = corp;
        objEntityCustomer.Ledger_id = Convert.ToInt32(strId);
        objEntityCustomer.FinancialStartDate = ObjCommonlib.textToDateTime(Financialfrom);
        objEntityCustomer.FinancialEndDate = ObjCommonlib.textToDateTime(FinancialEnd);
        objEntityCustomer.TransactionType = Convert.ToInt32(mode);
        DataTable dtCustDtl = ObjBusinessCustomer.ReadSupplierInfo(objEntityCustomer);
        StringBuilder sb = new StringBuilder();
        DataTable dtCustomer = ObjBusinessCustomer.ReadSuppliersDetails(objEntityCustomer);

        if (strPrintMode == "csv")
        {
            result[0] = obj.CustomerDetailsToPrintCSV(dtCustomer, objEntityCustomer, decimalCount, mode);
        }
        else
        {
            result[0] = obj.CustomerDetailsToPrintPdf(dtCustomer, objEntityCustomer, decimalCount, mode);
        }
        return result;

    }


    //statement and outstanding statement of account
    public string LoadCustomerDetails(DataTable dt, clsEntitySupplierOutstanding ObjEntityRequest, string decimalcount, string mode)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intSLNo = 1;
        int precision = Convert.ToInt32(decimalcount);
        string format = String.Format("{{0:N{0}}}", precision);
        string strRandom = objCommon.Random_Number();


        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, ObjEntityRequest.Corporate_id);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
        }


        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"display table-bordered\" width=\"100%\" >";
        //add header row
        strHtml += "<thead class=\"thead1\">";
        strHtml += "<tr >";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount <= 6; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"col-md-2 td1\" >REF #";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"col-md-1\" >DATE";
                strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br></th >";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"col-md-2 tr_l\" >TRANSACTION";
                strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th >";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"col-md-1 tr_r\" >DEBIT";
                strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th >";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"col-md-1 tr_r\" style=\"width:12%;text-align:right;\">CREDIT";
                strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th >";
            }
            else if (intColumnHeaderCount == 6)
            {
                if (mode == "0")
                {
                    strHtml += "<th class=\"col-md-2 tr_r\">CLOSING BALANCE";
                }
                else
                {
                    strHtml += "<th class=\"col-md-2 tr_r\">BALANCE";
                }
                strHtml += "</th >";
            }

        }
        strHtml += "<th class=\"col-md-3 tr_l\" >NARRATION/REMARKS";
        strHtml += "</th >";

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        strHtml += "<tbody>";
        string valuestringAmnt = "";
        decimal decDebitSum = 0;
        decimal decCreditSum = 0;
        int intflag = 0;

        int intCount = dt.Rows.Count - 1;
        if (intflag == 0)
        {
            if (dt.Rows.Count > 0)
            {
                strHtml += "<td class=\"tdT\"  ></td>";
                strHtml += "<td class=\"tdT\" > </td>";

                strHtml += "<td class=\"tr_l\" >" + dt.Rows[intCount]["TRANTYPE"].ToString() + "</td>";
                decimal decOpenBalance = 0;
                if (dt.Rows[intCount]["LDGR_OPEN_BAL"].ToString() != "")
                    decOpenBalance = Convert.ToDecimal(dt.Rows[intCount]["LDGR_OPEN_BAL"].ToString());

                string strMode = "CR";
                if (decOpenBalance>=0)
                    strMode = "DR";
                else
                    strMode = "CR";
              

                if (decOpenBalance> 0)
                {
                    strHtml += "<td class=\"tr_r\"> " + objBusiness.AddCommasForNumberSeperation(decOpenBalance.ToString(), objEntityCommon) + " " + "DR</td>";
                    decDebitSum += decOpenBalance;
                }
                else
                {
                    strHtml += "<td class=\"tr_r\"  ></td>";
                }
                if (decOpenBalance < 0)
                {
                    decOpenBalance = decOpenBalance * -1;
                    strHtml += "<td class=\"tr_r\"  > " + objBusiness.AddCommasForNumberSeperation(decOpenBalance.ToString(), objEntityCommon) + " " + "CR</td>";
                    decCreditSum += decOpenBalance;
                }
                else
                {
                    strHtml += "<td class=\"tr_r\"  ></td>";
                }
                strHtml += "<td class=\"tr_r\"  > " + objBusiness.AddCommasForNumberSeperation(decOpenBalance.ToString(), objEntityCommon) + " " + strMode + "</td>";
                strHtml += "<td class=\"tr_l\"  > " + dt.Rows[intCount]["VOCHR_DSCRPTN"].ToString() + "</td>";
                intflag++;
            }
        }
        strHtml += "</tr>";
        decimal decClsingBalance = 0;
        decimal decTotalClsingBalance = 0;
        
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count - 1; intRowBodyCount++)
        {
            intSLNo++;
            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            strHtml += "<tr>";

        //    strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + intSLNo + "</td>";
            strHtml += "<td class=\"tr_l\"  > " + dt.Rows[intRowBodyCount]["VOCHR_REF"].ToString() + "</td>";
            strHtml += "<td > " + dt.Rows[intRowBodyCount]["VOCHR_DATE"].ToString() + "</td>";
            strHtml += "<td class=\"tr_l\"  > " + dt.Rows[intRowBodyCount]["TRANTYPE"].ToString() + "</td>";
            if (dt.Rows[intRowBodyCount]["VOCHR_STS"].ToString() == "0")
            {
                if (dt.Rows[intRowBodyCount]["VOCHR_AMT"].ToString() != "")
                {
                    strHtml += "<td class=\"tr_r\"  > " + objBusiness.AddCommasForNumberSeperation(dt.Rows[intRowBodyCount]["VOCHR_AMT"].ToString(), objEntityCommon) + " " + "DR</td>";
                    decDebitSum += Convert.ToDecimal(dt.Rows[intRowBodyCount]["VOCHR_AMT"].ToString());

                }
                else
                {
                    strHtml += "<td class=\"tr_r\"  ></td>";
                }
                strHtml += "<td class=\"tr_r\" ></td>";
            }
            else
            {
                strHtml += "<td class=\"tr_r\" ></td>";
                if (dt.Rows[intRowBodyCount]["VOCHR_AMT"].ToString() != "")
                {
                    strHtml += "<td class=\"tr_r\"  > " + objBusiness.AddCommasForNumberSeperation(dt.Rows[intRowBodyCount]["VOCHR_AMT"].ToString(), objEntityCommon) + " " + "CR</td>";
                    decCreditSum += Convert.ToDecimal(dt.Rows[intRowBodyCount]["VOCHR_AMT"].ToString());
                }
                else
                {
                    strHtml += "<td class=\"tr_r\"  ></td>";
                }
            }
            if (mode == "0")
            {
                decClsingBalance = decDebitSum - decCreditSum;
                decTotalClsingBalance = decClsingBalance;
            }
            else
            {
                decClsingBalance = Convert.ToDecimal(dt.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString());
                if (dt.Rows[intRowBodyCount]["VOCHR_STS"].ToString() == "1")
                {
                    decClsingBalance = decClsingBalance * -1;
                }
            }
            if (decClsingBalance < 0)
            {
                decClsingBalance = decClsingBalance * (-1);
                strHtml += "<td class=\"tr_r\"  > " + objBusiness.AddCommasForNumberSeperation(decClsingBalance.ToString(), objEntityCommon) + " CR</td>";
            }
            else
            {
                strHtml += "<td class=\"tr_r\" > " + objBusiness.AddCommasForNumberSeperation(decClsingBalance.ToString(), objEntityCommon) + " DR</td>";
            }
            strHtml += "<td class=\"tr_l\"  > " + dt.Rows[intRowBodyCount]["VOCHR_DSCRPTN"].ToString() + "</td>";
            //      strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: right;\" > " + valuestringAmnt + "  " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
            strHtml += "</tr>";
        }
        string strsum1 = "", strsum2 = "";
        if (decDebitSum == 0)
        {
            strsum1 = String.Format(format, decDebitSum);
        }
        else
        {
            strsum1 = objBusiness.AddCommasForNumberSeperation(decDebitSum.ToString(), objEntityCommon);
        }
        if (decCreditSum == 0)
        {
            strsum2 = String.Format(format, decCreditSum);
        }
        else
        {
            strsum2 = objBusiness.AddCommasForNumberSeperation(decCreditSum.ToString(), objEntityCommon);
        }
        strHtml += "<tr class=\"tr1 brd1\">";
        strHtml += "<td class=\"tr_r ft_bld\" colspan=\"3\" > TOTAL</td>";
        strHtml += "<td class=\"tr_r txt_gr\" > " + strsum1 + " DR</td>";
        strHtml += "<td class=\"tr_r txt_rd\" > " + strsum2 + " CR</td>";
        //if (mode == "1")
        //{
            decTotalClsingBalance = decDebitSum - decCreditSum;
        //}
       
            if (decTotalClsingBalance < 0)
            {
                decTotalClsingBalance = decTotalClsingBalance * (-1);
                strHtml += "<td class=\" tr_r txt_blu\"  > " + objBusiness.AddCommasForNumberSeperation(decTotalClsingBalance.ToString(), objEntityCommon) + " CR</td>";
            }
            else
            {
                if (decTotalClsingBalance == 0)
                {
                    strsum2 = String.Format(format, decTotalClsingBalance);
                }
                else
                {
                    strsum2 = objBusiness.AddCommasForNumberSeperation(decTotalClsingBalance.ToString(), objEntityCommon);
                }
                strHtml += "<td class=\"tr_r txt_blu\"  > " + strsum2 + " DR</td>";
            }

            strHtml += "<td class=\"tr_r txt_blu\" ></td>";
        strHtml += "</tr>";
        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();

    }
    public string CustomerDetailsToPrintPdf(DataTable dtCustomer, clsEntitySupplierOutstanding objEntityCustomer, string decimalCount, string mode)
    {
        string strRet = "";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        string strRandom = objCommon.Random_Number();
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, objEntityCustomer.Corporate_id);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
        }
        int precision = Convert.ToInt32(decimalCount);
        string format = String.Format("{{0:N{0}}}", precision);
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.SUPPLIER_OUTSTANDING_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SUPPLIER_OUTSTANDING_PDF);
        objEntityCommon.CorporateID = objEntityCustomer.Corporate_id;
        objEntityCommon.Organisation_Id = objEntityCustomer.Organisation_Id;
        string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "Supplier_Details" + strNextNumber + ".pdf";

        Document document = new Document(PageSize.A4, 50f, 40f, 120f, 30f);
        document = new Document(PageSize.LETTER, 50f, 40f, 20f, 40f);
        Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
        var FontSmallGray = new BaseColor(230, 230, 230);
        try
        {
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                PdfWriter writer = PdfWriter.GetInstance(document, file);
                writer.PageEvent = new PDFHeader();
                document.Open();

                string Sdate = objEntityCustomer.SupplierDate.ToString("dd-MM-yyyy");

                PdfPTable footrtable = new PdfPTable(3);
                float[] footrsBody1 = { 20, 5, 75 };
                footrtable.SetWidths(footrsBody1);
                footrtable.WidthPercentage = 100;
                if (mode == "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("STATEMENT OF ACCOUNT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, PaddingBottom = 5 });
                }
                else
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("OUTSTANDING STATEMENT OF ACCOUNT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, PaddingBottom = 5 });
                }
                footrtable.AddCell(new PdfPCell(new Phrase("FROM DATE        ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(objEntityCustomer.FinancialStartDate.ToString("dd-MM-yyyy"), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2});
                footrtable.AddCell(new PdfPCell(new Phrase("TO DATE             ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(Sdate, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase("SUPPLIER          ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(dtCustomer.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                document.Add(footrtable);

                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(7);
                float[] footrsBody = { 12, 9, 12, 13, 13, 16, 25 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;//get header column in all pages

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);

                TBCustomer.AddCell(new PdfPCell(new Phrase("REF #", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("DATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("TRANSACTION", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("DEBIT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("CREDIT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                if (mode == "0")
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase("CLOSING BALANCE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                }
                else
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase("BALANCE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });

                }
                TBCustomer.AddCell(new PdfPCell(new Phrase("NARRATION/REMARKS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });


                string valuestringAmnt = "";
                decimal decDebitSum = 0;
                decimal decCreditSum = 0;
                int intflag = 0;

                int intCount = dtCustomer.Rows.Count - 1;
                if (intflag == 0)
                {
                    if (dtCustomer.Rows.Count > 0)
                    {

                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCustomer.Rows[intCount]["TRANTYPE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                        decimal decOpenBalance = 0;
                        if (dtCustomer.Rows[intCount]["LDGR_OPEN_BAL"].ToString() != "")
                            decOpenBalance = Convert.ToDecimal(dtCustomer.Rows[intCount]["LDGR_OPEN_BAL"].ToString());
                        string strMode = "CR";
                        if (decOpenBalance >= 0)
                            strMode = "DR";
                        else
                            strMode = "CR";


                        if (decOpenBalance > 0)
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(decOpenBalance.ToString(), objEntityCommon) + " " + "DR", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            decDebitSum += decOpenBalance;
                        }
                        else
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


                        }
                        if (decOpenBalance < 0)
                        {
                            decOpenBalance = decOpenBalance * -1;
                            TBCustomer.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(decOpenBalance.ToString(), objEntityCommon) + " " + "CR", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            decCreditSum += decOpenBalance;
                        }
                        else
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                        }
                        TBCustomer.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(decOpenBalance.ToString(), objEntityCommon) + " " + strMode, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCustomer.Rows[intCount]["VOCHR_DSCRPTN"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        intflag++;
                    }
                }
                decimal decClsingBalance = 0;
                decimal decTotalClsingBalance = 0;

                for (int intRowBodyCount = 0; intRowBodyCount < dtCustomer.Rows.Count - 1; intRowBodyCount++)
                {
                    // intSLNo++;
                    string strId = dtCustomer.Rows[intRowBodyCount][0].ToString();
                    int intIdLength = dtCustomer.Rows[intRowBodyCount][0].ToString().Length;
                    string stridLength = intIdLength.ToString("00");
                    string Id = stridLength + strId + strRandom;

                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCustomer.Rows[intRowBodyCount]["VOCHR_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCustomer.Rows[intRowBodyCount]["VOCHR_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCustomer.Rows[intRowBodyCount]["TRANTYPE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    if (dtCustomer.Rows[intRowBodyCount]["VOCHR_STS"].ToString() == "0")
                    {
                        if (dtCustomer.Rows[intRowBodyCount]["VOCHR_AMT"].ToString() != "")
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(dtCustomer.Rows[intRowBodyCount]["VOCHR_AMT"].ToString(), objEntityCommon) + " " + "DR", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            decDebitSum += Convert.ToDecimal(dtCustomer.Rows[intRowBodyCount]["VOCHR_AMT"].ToString());
                        }
                        else
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }
                    else
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        if (dtCustomer.Rows[intRowBodyCount]["VOCHR_AMT"].ToString() != "")
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(dtCustomer.Rows[intRowBodyCount]["VOCHR_AMT"].ToString(), objEntityCommon) + " " + "CR", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            decCreditSum += Convert.ToDecimal(dtCustomer.Rows[intRowBodyCount]["VOCHR_AMT"].ToString());
                        }
                        else
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                    }
                    if (mode == "0")
                    {
                        decClsingBalance = decDebitSum - decCreditSum;
                        decTotalClsingBalance = decClsingBalance;
                    }
                    else
                    {
                        decClsingBalance = Convert.ToDecimal(dtCustomer.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString());
                        if (dtCustomer.Rows[intRowBodyCount]["VOCHR_STS"].ToString() == "1")
                        {
                            decClsingBalance = decClsingBalance * -1;
                        }
                    }

                    if (decClsingBalance < 0)
                    {
                        decClsingBalance = decClsingBalance * (-1);
                        TBCustomer.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(decClsingBalance.ToString(), objEntityCommon) + " CR", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }
                    else
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(decClsingBalance.ToString(), objEntityCommon) + " DR", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCustomer.Rows[intRowBodyCount]["VOCHR_DSCRPTN"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                }
                string strsum1 = "", strsum2 = "";
                if (decDebitSum == 0)
                {
                    strsum1 = String.Format(format, decDebitSum);
                }
                else
                {
                    strsum1 = objBusinessLayer.AddCommasForNumberSeperation(decDebitSum.ToString(), objEntityCommon);
                }
                if (decCreditSum == 0)
                {
                    strsum2 = String.Format(format, decCreditSum);
                }
                else
                {
                    strsum2 = objBusinessLayer.AddCommasForNumberSeperation(decCreditSum.ToString(), objEntityCommon);
                }
                TBCustomer.AddCell(new PdfPCell(new Phrase("TOTAL ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray, Colspan = 3 });
                TBCustomer.AddCell(new PdfPCell(new Phrase(strsum1 + " DR", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                TBCustomer.AddCell(new PdfPCell(new Phrase(strsum2 + " CR", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                decTotalClsingBalance = decDebitSum - decCreditSum;
                if (decTotalClsingBalance < 0)
                {
                    decTotalClsingBalance = decTotalClsingBalance * (-1);
                    TBCustomer.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(decTotalClsingBalance.ToString(), objEntityCommon) + " CR", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                }
                else
                {
                    if (decTotalClsingBalance == 0)
                    {
                        strsum2 = String.Format(format, decTotalClsingBalance);
                    }
                    else
                    {
                        strsum2 = objBusinessLayer.AddCommasForNumberSeperation(decTotalClsingBalance.ToString(), objEntityCommon);
                    }
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strsum2 + " DR", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                }
                TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                document.Add(TBCustomer);
                document.Close();
            }
            strRet = strImagePath + strImageName;
        }
        catch (Exception)
        {
            document.Close();
            strRet = "false";
        }
        return strRet;

    }
    public string CustomerDetailsToPrintCSV(DataTable dtCustomer, clsEntitySupplierOutstanding objEntityCustomer, string decimalCount, string mode)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        DataTable dt = GetTableDetail(dtCustomer, objEntityCustomer, decimalCount, mode);
        string strResult = DataTableToCSV(dt, ',');

        objEntityCommon.CorporateID = objEntityCustomer.Corporate_id;
        objEntityCommon.Organisation_Id = objEntityCustomer.Organisation_Id;
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SUPPLIER_OUTSTANDING_CSV);

        string strNextId = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string filepath = "SupplierOutstandingDetail_" + strNextId + ".csv";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.SUPPLIER_OUTSTANDING_CSV);
        string newFilePath = Server.MapPath(strImagePath + filepath);
        System.IO.File.WriteAllText(newFilePath, strResult);

        return strImagePath + filepath;
    }
    public DataTable GetTableDetail(DataTable dtCustomer, clsEntitySupplierOutstanding objEntityCustomer, string decimalCount, string mode)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        string strRandom = objCommon.Random_Number();
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, objEntityCustomer.Corporate_id);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
        }
        int precision = Convert.ToInt32(decimalCount);
        string format = String.Format("{{0:N{0}}}", precision);

        string FORNULL = "";
        DataTable table = new DataTable();

        table.Columns.Add("SUPPLIER OUTSTANDING REPORT", typeof(string));
        table.Columns.Add(" ", typeof(string));
        table.Columns.Add("  ", typeof(string));
        table.Columns.Add("   ", typeof(string));
        table.Columns.Add("    ", typeof(string));
        table.Columns.Add("     ", typeof(string));
        table.Columns.Add("      ", typeof(string));

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

        if (mode == "0")
        {
            table.Rows.Add('"' + "STATEMENT OF ACCOUNT" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        else
        {
            table.Rows.Add('"' + "OUTSTANDING STATEMENT OF ACCOUNT" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

        table.Rows.Add('"' + "FROM DATE :" + '"', '"' + objEntityCustomer.FinancialStartDate.ToString("dd-MM-yyyy") + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add('"' + "TO DATE :" + '"', '"' + objEntityCustomer.SupplierDate.ToString("dd-MM-yyyy") + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add('"' + "SUPPLIER :" + '"', '"' + dtCustomer.Rows[0]["LDGR_NAME"].ToString() + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

        if (mode == "0")
        {
            table.Rows.Add('"' + "REF #" + '"', '"' + "DATE" + '"', '"' + "TRANSACTION" + '"', '"' + "DEBIT" + '"', '"' + "CREDIT" + '"', '"' + "CLOSING BALANCE" + '"', '"' + "NARRATION/REMARKS" + '"');
        }
        else
        {
            table.Rows.Add('"' + "REF #" + '"', '"' + "DATE" + '"', '"' + "TRANSACTION" + '"', '"' + "DEBIT" + '"', '"' + "CREDIT" + '"', '"' + "BALANCE" + '"', '"' + "NARRATION/REMARKS" + '"');
        }

        string valuestringAmnt = "";
        decimal decDebitSum = 0;
        decimal decCreditSum = 0;
        int intflag = 0;

        int intCount = dtCustomer.Rows.Count - 1;
        if (intflag == 0)
        {
            if (dtCustomer.Rows.Count > 0)
            {
                decimal decOpenBalance = 0;
                if (dtCustomer.Rows[intCount]["LDGR_OPEN_BAL"].ToString() != "")
                    decOpenBalance = Convert.ToDecimal(dtCustomer.Rows[intCount]["LDGR_OPEN_BAL"].ToString());
                string strMode = "CR";
                if (decOpenBalance >= 0)
                    strMode = "DR";
                else
                    strMode = "CR";

                string DebitAmnt = "";
                string CreditAmnt = "";

                if (decOpenBalance > 0)
                {
                    DebitAmnt = objBusinessLayer.AddCommasForNumberSeperation(decOpenBalance.ToString(), objEntityCommon) + " " + "DR";
                    decDebitSum += decOpenBalance;
                }

                if (decOpenBalance < 0)
                {
                    decOpenBalance = decOpenBalance * -1;
                    CreditAmnt = objBusinessLayer.AddCommasForNumberSeperation(decOpenBalance.ToString(), objEntityCommon) + " " + "CR";
                    decCreditSum += decOpenBalance;
                }
 
                table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + dtCustomer.Rows[intCount]["TRANTYPE"].ToString() + '"', '"' + DebitAmnt + '"', '"' + CreditAmnt + '"', '"' + objBusinessLayer.AddCommasForNumberSeperation(decOpenBalance.ToString(), objEntityCommon) + " " + strMode + '"', '"' + dtCustomer.Rows[intCount]["VOCHR_DSCRPTN"].ToString() + '"');
                
                
                intflag++;
            }
        }
        decimal decClsingBalance = 0;
        decimal decTotalClsingBalance = 0;

        for (int intRowBodyCount = 0; intRowBodyCount < dtCustomer.Rows.Count - 1; intRowBodyCount++)
        {
            string strId = dtCustomer.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dtCustomer.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

            string DebitAmnt = "";
            string CreditAmnt = "";

            if (dtCustomer.Rows[intRowBodyCount]["VOCHR_STS"].ToString() == "0")
            {
                if (dtCustomer.Rows[intRowBodyCount]["VOCHR_AMT"].ToString() != "")
                {
                    DebitAmnt = objBusinessLayer.AddCommasForNumberSeperation(dtCustomer.Rows[intRowBodyCount]["VOCHR_AMT"].ToString(), objEntityCommon) + " " + "DR";
                    decDebitSum += Convert.ToDecimal(dtCustomer.Rows[intRowBodyCount]["VOCHR_AMT"].ToString());
                }
            }
            else
            {
                if (dtCustomer.Rows[intRowBodyCount]["VOCHR_AMT"].ToString() != "")
                {
                    CreditAmnt = objBusinessLayer.AddCommasForNumberSeperation(dtCustomer.Rows[intRowBodyCount]["VOCHR_AMT"].ToString(), objEntityCommon) + " " + "CR";
                    decCreditSum += Convert.ToDecimal(dtCustomer.Rows[intRowBodyCount]["VOCHR_AMT"].ToString());
                }
            }
            if (mode == "0")
            {
                decClsingBalance = decDebitSum - decCreditSum;
                decTotalClsingBalance = decClsingBalance;
            }
            else
            {
                decClsingBalance = Convert.ToDecimal(dtCustomer.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString());
                if (dtCustomer.Rows[intRowBodyCount]["VOCHR_STS"].ToString() == "1")
                {
                    decClsingBalance = decClsingBalance * -1;
                }
            }
            string strCurr = "DR";
            if (decClsingBalance < 0)
            {
                strCurr = "CR";
                decClsingBalance = decClsingBalance * (-1);
            }

            table.Rows.Add('"' + dtCustomer.Rows[intRowBodyCount]["VOCHR_REF"].ToString() + '"', '"' + dtCustomer.Rows[intRowBodyCount]["VOCHR_DATE"].ToString() + '"', '"' + dtCustomer.Rows[intRowBodyCount]["TRANTYPE"].ToString() + '"', '"' + DebitAmnt + '"', '"' + CreditAmnt + '"', '"' + objBusinessLayer.AddCommasForNumberSeperation(decClsingBalance.ToString(), objEntityCommon) + " " + strCurr + '"', '"' + dtCustomer.Rows[intRowBodyCount]["VOCHR_DSCRPTN"].ToString() + '"');        
        
        }
        string strsum1 = "", strsum2 = "";
        if (decDebitSum == 0)
        {
            strsum1 = String.Format(format, decDebitSum);
        }
        else
        {
            strsum1 = objBusinessLayer.AddCommasForNumberSeperation(decDebitSum.ToString(), objEntityCommon);
        }
        if (decCreditSum == 0)
        {
            strsum2 = String.Format(format, decCreditSum);
        }
        else
        {
            strsum2 = objBusinessLayer.AddCommasForNumberSeperation(decCreditSum.ToString(), objEntityCommon);
        }

        decTotalClsingBalance = decDebitSum - decCreditSum;

        string strsum = "";
        if (decTotalClsingBalance < 0)
        {
            decTotalClsingBalance = decTotalClsingBalance * (-1);
            strsum = objBusinessLayer.AddCommasForNumberSeperation(decTotalClsingBalance.ToString(), objEntityCommon) + " CR";
        }
        else
        {
            if (decTotalClsingBalance == 0)
            {
                strsum = String.Format(format, decTotalClsingBalance);
            }
            else
            {
                strsum = objBusinessLayer.AddCommasForNumberSeperation(decTotalClsingBalance.ToString(), objEntityCommon);
            }

            strsum = strsum + " DR";
        }

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + "TOTAL" + '"', '"' + strsum1 + " DR" + '"', '"' + strsum2 + " CR" + '"', '"' + strsum + '"', '"' + FORNULL + '"');


        return table;
    }


    public string PrintCaption(clsEntitySupplierOutstanding ObjEntityRequest, DataTable dtCust, int mode)
    {
        clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();
        clsEntityReports objEntityReports = new clsEntityReports();
        objEntityReports.Corporate_Id = IntCorpIdSession;
        objEntityReports.Organisation_Id = ObjEntityRequest.Organisation_Id;
        //    objEntityReports.User_Id = ObjEntityRequest.User_Id;
        DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(objEntityReports);
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "SUPPLIER OUTSTANDING";
        DateTime datetm = objBusiness.LoadCurrentDate(); ;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string usrName = "<B> Report Generated By: </B>" + Session["USERFULLNAME"];
        string strHidden = "", GuaranteDivsn = "", strFromDate = "", strCustName = "", strCustCode = "", strCurrency = "", strCreLmt = "";
        if (dtCust.Rows.Count > 0)
        {
            strCustName = "<B>SUPPLIER NAME : </B>" + dtCust.Rows[0]["SUPLIR_NAME"].ToString();
            if (dtCust.Rows[0]["SUPLIR_CODE"].ToString() != "")
                strCustCode = "<B>CODE : </B>" + dtCust.Rows[0]["SUPLIR_CODE"].ToString();
            strCurrency = "<B>CURRENCY: </B>" + dtCust.Rows[0]["CRNCMST_NAME"].ToString();
            if (dtCust.Rows[0]["SUPLIR_CR_LIMIT"].ToString() != "")
                strCreLmt = "<B>CREDIT LIMIT: </B>" + dtCust.Rows[0]["SUPLIR_CR_LIMIT"].ToString();
            if (mode == 0)
            {
                strTitle = "STATEMENT OF ACCOUNTS";
            }
            else
            {
                strTitle = "OUTSTANDING STATEMENT OF ACCOUNTS";
            }
        }
        clsCommonLibrary objCommon = new clsCommonLibrary();
        GuaranteDivsn = "<B>TO DATE  : </B>" + ObjEntityRequest.SupplierDate.ToString("dd-MM-yyyy");
        strFromDate = "<B>FROM DATE  : </B>" + ObjEntityRequest.FinancialStartDate.ToString("dd-MM-yyyy");
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
        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr1 + "</td></tr>";
        string strCaptionTabRprtDate = "", strCaptionTabTitle = "", strGuaranteDivsn = "", strGuaranteCatgry = "", strGuaranteBank = "", strUsrName = "";
        if (dat != "")
        {
            strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        }
        if (strTitle != "")
        {
            strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
        }
        if (GuaranteDivsn != "")
        {
            strGuaranteDivsn = "<tr><td class=\"RprtDiv\">" + GuaranteDivsn + "</td></tr>";

        }
        if (usrName != "")
        {
            strUsrName = "<tr><td class=\"RprtDiv\">" + usrName + "</td></tr>";
        }
        if (strFromDate != "")
        {
            strFromDate = "<tr><td class=\"RprtDiv\">" + strFromDate + "</td></tr>";

        }
        if (strCustName != "")
        {
            strCustName = "<tr><td class=\"RprtDiv\">" + strCustName + "</td></tr>";
        }
        if (strCustCode != "")
        {
            strCustCode = "<tr><td class=\"RprtDiv\">" + strCustCode + "</td></tr>";
        }
        if (strCreLmt != "")
        {
            strCreLmt = "<tr><td class=\"RprtDiv\">" + strCreLmt + "</td></tr>";
        }
        if (strCurrency != "")
        {
            strCurrency = "<tr><td class=\"RprtDiv\">" + strCurrency + "</td></tr>";
        }
        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strFromDate + strGuaranteDivsn + strCustName + strCustCode + strCreLmt + strCurrency + strUsrName + strCaptionTabTitle + strCaptionTabstop;
        sbCap.Append(strPrintCaptionTable);
        ////write to  divPrintCaption
        return sbCap.ToString();


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
            headtable.AddCell(new PdfPCell(new Phrase("SUPPLIER OUTSTANDING REPORT", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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

    [WebMethod]
    public static string LoadPostdatedChqDtls(string OrgId, string CorpId, string LdgrId)
    {
        clsBusinessOutstandingAgeing objBussinessAging = new clsBusinessOutstandingAgeing();
        clsEntityOutstandingAgeing ObjEntityRequest1 = new clsEntityOutstandingAgeing();

        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        ObjEntityRequest1.Organisation_id = Convert.ToInt32(OrgId);
        ObjEntityRequest1.Corporate_id = Convert.ToInt32(CorpId);

        string strRandomMixedId = LdgrId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        ObjEntityRequest1.CustomerId = Convert.ToInt32(strId);
        DataTable dtPostDate = objBussinessAging.ReadPostdatedChqDtls(ObjEntityRequest1);//Postdated chq

        StringBuilder sbPop = new StringBuilder();

        sbPop.Append("<thead class=\"thead1\">");
        sbPop.Append("<tr>");
        sbPop.Append("<th class=\"col-md-2 td1 tr_l\">Ref#</th>");
        sbPop.Append("<th class=\"col-md-3 tr_l\">Bank</th>");
        sbPop.Append("<th class=\"col-md-1 tr_l\">Cheque#</th>");
        sbPop.Append("<th class=\"col-md-2\">Cheque Date</th>");
        sbPop.Append("<th class=\"col-md-2 tr_r\">Amount</th>");
        sbPop.Append("<th class=\"col-md-2\">Status</th>");
        sbPop.Append("</tr>");
        sbPop.Append("</thead>");

        sbPop.Append("<tbody>");

        for (int intRow = 0; intRow < dtPostDate.Rows.Count; intRow++)
        {
            sbPop.Append("<tr>");
            sbPop.Append("<td class=\"tr_l\">" + dtPostDate.Rows[intRow]["PST_CHEQUE_REF"].ToString() + "</td>");
            sbPop.Append("<td class=\"tr_l\">" + dtPostDate.Rows[intRow]["LDGR_NAME"].ToString() + "</td>");
            sbPop.Append("<td class=\"tr_l\">" + dtPostDate.Rows[intRow]["CHQ_DTLS_NUMBER"].ToString() + "</td>");
            sbPop.Append("<td class=\"tr_c\">" + dtPostDate.Rows[intRow]["CHQ_DTLS_CHQ_DATE"].ToString() + "</td>");

            string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(dtPostDate.Rows[intRow]["CHQ_DTLS_AMOUNT"].ToString(), objEntityCommon);

            sbPop.Append("<td class=\"tr_r\">" + strNetAmountWithComma + "</td>");
            sbPop.Append("<td>" + dtPostDate.Rows[intRow]["CHQ_DTLS_PAID_RJCT_STATUS"].ToString() + "</td>");
            sbPop.Append("</tr>");
        }

        sbPop.Append("</tbody>");

        return sbPop.ToString();
    }
}