using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using BL_Compzit.BusinessLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.Entity_Layer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Text;
using System.Web.Services;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Ionic.Zip;

using System.IO;


public partial class HCM_HCM_Master_hcm_PayrollSystem_hcm_Bulk_LabourCard_Print_hcm_Bulk_LabourCard_Print : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int intCorpId = 0;
            int intOrgId = 0;            
            int intUserId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            clsEntityCommon objEntCommon = new clsEntityCommon();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            cls_Business_Bulk_LabourCard_Print objBussBulkPrint = new cls_Business_Bulk_LabourCard_Print();
            cls_Entity_Bulk_LabourCard_Print objEntityBulkPrint = new cls_Entity_Bulk_LabourCard_Print();


            objEntCommon.Organisation_Id = Convert.ToInt32(intOrgId);
            objEntCommon.CorporateID = Convert.ToInt32(intCorpId);

            objEntityBulkPrint.CorpOffice = Convert.ToInt32(intCorpId);
            objEntityBulkPrint.Orgid = Convert.ToInt32(intOrgId);
            objEntityBulkPrint.UserId = Convert.ToInt32(intUserId);

            DataTable dtDep = objBussBulkPrint.LoadDep(objEntityBulkPrint);
            DataTable dtEmployeeCode = objBussBulkPrint.ReadEmployeeCode(objEntityBulkPrint);


            BindDdlMonths();
            BindDdlYears();
            LoadDep(dtDep);
            LoadEmployee(dtEmployeeCode);

            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "MailSent")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                }
                //else if (strInsUpd == "MissinggMailSent")
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "ErrorConfirmation", "ErrorConfirmation();", true);
                //}
            }
        }
    }

    public void BindDdlMonths(string strMonth = null)
    {
        strMonth = DateTime.Today.Month.ToString();
        ddlMonth.Items.Clear();
        var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
        for (int i = 0; i < months.Length - 1; i++)
        {
         //   ddlMonth.Items.Add(new ListItem(months[i], (i + 1).ToString()));
            ddlMonth.Items.Add(new System.Web.UI.WebControls.ListItem(months[i], (i + 1).ToString()));           
        }
        ddlMonth.ClearSelection();
        if (strMonth != null)
        {
            if (ddlMonth.Items.FindByValue(strMonth) != null)
            {
                ddlMonth.Items.FindByValue(strMonth).Selected = true;
            }
        }
        else
        {
            ddlMonth.Items.Insert(0, "--MONTH--");
        }
    }
    public void BindDdlYears(string strYear = null)
    {
        ddlyear.Items.Clear();
        strYear = DateTime.Today.Year.ToString();
        var currentYear = DateTime.Today.Year;
        for (int i = 1; i >= -1; i--)
        {

            ddlyear.Items.Add((currentYear - i).ToString());
        }
        ddlyear.ClearSelection();
        if (strYear != null)
        {
            if (ddlyear.Items.FindByValue(strYear) != null)
            {
                ddlyear.Items.FindByValue(strYear).Selected = true;
            }
        }
        else
        {
            ddlyear.Items.Insert(0, "--YEAR--");
        }
    }
    public void LoadDep(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            ddlDep.DataSource = dt;
            ddlDep.DataTextField = "CPRDEPT_NAME";
            ddlDep.DataValueField = "CPRDEPT_ID";
            ddlDep.DataBind();

        }
        // DataTable dtDefaultcurc = ObjBussinessBankGuarnt.ReadDefualtCurrency(ObjEntityRequest);
        //string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        ddlDep.ClearSelection();
        ddlDep.Items.Insert(0, "--SELECT DEPARTMENT--");
    }
    public void LoadEmployee(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            ddlEmployeeFirst.Items.Clear();
            ddlEmployeeFirst.DataSource = dt;
            ddlEmployeeFirst.DataTextField = "USR_CODE";
            ddlEmployeeFirst.DataValueField = "USR_ID";
            ddlEmployeeFirst.DataBind();
            ddlEmployeeFirst.Items.Insert(0, "--SELECT EMPLOYEE CODE--");

            ddlEmployeeSecond.Items.Clear();
            ddlEmployeeSecond.DataSource = dt;
            ddlEmployeeSecond.DataTextField = "USR_CODE";
            ddlEmployeeSecond.DataValueField = "USR_ID";
            ddlEmployeeSecond.DataBind();
            ddlEmployeeSecond.Items.Insert(0, "--SELECT EMPLOYEE CODE--");
        }
    }

    //------------------------------------------Pagination------------------------------------------------
    [WebMethod]
    public static string[] GetData(string OrgId, string CorpId, string ddlMonth, string ddlYear, string ddlDep, string ddlStffWrkr, string ddlEmpIdFirst, string ddlEmpIdSecond,
        string Print_Sts, string Mail_Sts, string PageNumber, string PageMaxSize, string strCommonSearchTerm, string OrderColumn, string OrderMethod, string strInputColumnSearch)
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        cls_Business_Bulk_LabourCard_Print objBussBulkPrint = new cls_Business_Bulk_LabourCard_Print();
        cls_Entity_Bulk_LabourCard_Print objEntityBulkPrint = new cls_Entity_Bulk_LabourCard_Print();

        string[] strResults = new string[3];

        if (OrgId != null && OrgId != "")
        {
            objEntityBulkPrint.Orgid = Convert.ToInt32(OrgId);
        }
        if (CorpId != null && CorpId != "")
        {
            objEntityBulkPrint.CorpOffice = Convert.ToInt32(CorpId);
        }

        objEntityBulkPrint.Month = Convert.ToInt32(ddlMonth);
        //objEntityBulkPrint.Month = 5;
        objEntityBulkPrint.Year = Convert.ToInt32(ddlYear);

        objEntityBulkPrint.Dep = Convert.ToInt32(ddlDep);
        objEntityBulkPrint.StffWrkr = Convert.ToInt32(ddlStffWrkr);
        objEntityBulkPrint.EmpIdFirst = Convert.ToInt32(ddlEmpIdFirst);
        objEntityBulkPrint.EmpIdSecond = Convert.ToInt32(ddlEmpIdSecond);
        objEntityBulkPrint.Print_Sts = Convert.ToInt32(Print_Sts);

        //EVM-0043 start
        objEntityBulkPrint.Mail_Sts = Convert.ToInt32(Mail_Sts);
        //EVM-0043 end

        objEntityBulkPrint.PageNumber = Convert.ToInt32(PageNumber);
        objEntityBulkPrint.PageMaxSize = Convert.ToInt32(PageMaxSize);
        objEntityBulkPrint.OrderMethod = Convert.ToInt32(OrderMethod);
        objEntityBulkPrint.OrderColumn = Convert.ToInt32(OrderColumn);
        objEntityBulkPrint.CommonSearchTerm = strCommonSearchTerm;

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

        objEntityBulkPrint.SearchCode = strSearchInputs[Convert.ToInt32(SearchInputColumns.CODE)];
        objEntityBulkPrint.SearchName = strSearchInputs[Convert.ToInt32(SearchInputColumns.NAME)];
        objEntityBulkPrint.SearchDesignation = strSearchInputs[Convert.ToInt32(SearchInputColumns.DESIGNATION)];
       // objEntityBulkPrint.Print_Sts=

        //ReadList
        DataTable dt = objBussBulkPrint.ReadEmployeeDetailsList(objEntityBulkPrint);



        string[] strTableContents = new string[2];
        strTableContents = ConvertDataTableToHTML(dt, objEntityBulkPrint);
        strResults[0] = strTableContents[0];
        strResults[1] = strTableContents[1];


        if (dt.Rows.Count > 0)
        {
            int intTotalItems = Convert.ToInt32(dt.Rows[0]["CNT"].ToString());
            int intCurrentRowCount = dt.Rows.Count;

            //Pagination
            strResults[2] = objBusinessLayer.GenereatePagination(intTotalItems, objEntityBulkPrint.PageNumber, objEntityBulkPrint.PageMaxSize, intCurrentRowCount);
        }

        return strResults;
    }

    public static string[] ConvertDataTableToHTML(DataTable dt, cls_Entity_Bulk_LabourCard_Print objEntityBulkPrint)
    {
        string[] strReturn = new string[2];
        
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        StringBuilder sbHead = new StringBuilder();
        StringBuilder sb = new StringBuilder();
        int TotalRowCount = dt.Rows.Count;
        sbHead.Append("<th class=\"th_b5\"> <input style=\"display:none;\" id=\"chkbxTotalRowCount\" value=\"" + TotalRowCount + "\">  <input type=\"checkbox\" title=\"SELECT ALL\"  onchange='return changeAll();'   onkeypress='return DisableEnter(event)'  id=\"cbMandatory\"></th>");
        sbHead.Append("<th id=\"tdColumnHead_2\" onclick=\"SetOrderByValue(2)\" class=\"th_b4 tr_l\" style=\"word-wrap:break-word;\">EMPLOYEE CODE<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbHead.Append("<th id=\"tdColumnHead_3\" onclick=\"SetOrderByValue(3)\" class=\"th_b4 tr_l\" style=\"word-wrap:break-word;\">EMPLOYEE NAME<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbHead.Append("<th id=\"tdColumnHead_4\" onclick=\"SetOrderByValue(4)\" class=\"th_b4\" style=\"word-wrap:break-word;\">DESIGNATION<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbHead.Append("<th class=\"th_b6 tr_r\" style=\"word-wrap:break-word;\">BASIC SALARY</th>");
        sbHead.Append("<th class=\"th_b8 tr_r\" style=\"word-wrap:break-word;\">ADDITIONAL TOTAL</th>");
        sbHead.Append("<th class=\"th_b8 tr_r\" style=\"word-wrap:break-word;\">DEDUCTION TOTAL</th>");
        sbHead.Append("<th class=\"th_b6 tr_r\" style=\"word-wrap:break-word;\">NET SALARY</th>");
        sbHead.Append("<th class=\"th_b6\" style=\"word-wrap:break-word;\">PRINT STATUS</th>");
        sbHead.Append("<th class=\"th_b6\" style=\"word-wrap:break-word;\">MAIL STATUS</th>");
        //EVM-0043 end
        if (dt.Rows.Count > 0)
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                string strDate = dt.Rows[intRowBodyCount]["SLPRCDMNTH_CONF_DATE"].ToString();
                int Dep_Id = Convert.ToInt32(dt.Rows[intRowBodyCount]["CPRDEPT_ID"].ToString());
                int Empid = Convert.ToInt32(dt.Rows[intRowBodyCount]["USR_ID"].ToString());

                sb.Append("<tr>");
                     
                    sb.Append( "<td class=\"tr_l\" >");
                    sb.Append("<input type=\"checkbox\" onkeypress='return DisableEnter(event)'   value=\"" + Empid + "\" id=\"cbMandatory" + intRowBodyCount + "\">");
                    sb.Append("<input id=\"EmpId" + intRowBodyCount + "\" style=\"display:none;\" id=\"chkbxTotalRowCount\" value=\"" + Empid + "\">");
                    sb.Append( " </td>");

                    sb.Append( "<td class=\"tr_l\" > " + dt.Rows[intRowBodyCount]["EID"].ToString() + "</td>");
                    sb.Append( "<td class=\"tr_l\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + "</td>");
                    sb.Append( "<td class=\"tr_l\" >" + dt.Rows[intRowBodyCount]["DESIGNATION"].ToString() + "</td>");
                    sb.Append("<td class=\" tr_r\" >" + dt.Rows[intRowBodyCount]["SLRY_BASIC_PAY"].ToString() + "</td>");
                    sb.Append("<td class=\" tr_r\" >" + dt.Rows[intRowBodyCount]["TOT_ALLWNC"].ToString() + "</td>");
                    sb.Append("<td class=\" tr_r\" >" + dt.Rows[intRowBodyCount]["TOT_DEDUCT"].ToString() + "</td>");
                    sb.Append("<td class=\" tr_r\" >" + dt.Rows[intRowBodyCount]["NET_AMT"].ToString() + "</td>");

                    if (dt.Rows[intRowBodyCount]["PRINT_STATUS"].ToString() == "0")
                    {
                        sb.Append("<td><button class=\"btn tab_but1 butn4\" onclick=\"return false;\">Not Printed</button></td>");
                    }
                    else
                    {
                        sb.Append("<td><button class=\"btn tab_but1 butn1\" onclick=\"return false;\" > Printed</button></td>");
                    }

                    //EVM-0043 start
                    if (dt.Rows[intRowBodyCount]["MAIL_STATUS"].ToString() == "0")
                    {
                        sb.Append("<td><button class=\"btn tab_but1 butn4\" onclick=\"return false;\">Not Mailed</button></td>");
                    }
                    else
                    {
                        sb.Append("<td><button class=\"btn tab_but1 butn1\" onclick=\"return false;\">Mailed</button></td>");
                    }
                    //EVM-0043 end

                    sb.Append("<td style=\"display:none\" > <input type=\"text\"   value=\"" + intRowBodyCount + "\" id=\"RowCount" + intRowBodyCount + "\"></td>");
                    sb.Append("<td style=\"display:none\" > <input type=\"text\"   value=\"" + dt.Rows[intRowBodyCount]["SLPRCDMNTH_ID"].ToString() + "\" id=\"SalaryPrcsdId" + intRowBodyCount + "\"></td>");
                    sb.Append("<td style=\"display:none\" > <input type=\"text\"   value=\"" + strDate + "\" id=\"SlryPrcssdConfDate" + intRowBodyCount + "\"></td>");
                    sb.Append("<td style=\"display:none\" > <input type=\"text\"   value=\"" + Dep_Id + "\" id=\"Dep_Id" + intRowBodyCount + "\"></td>");

                   sb.Append("</tr>");
            }
        }
        else
        {
            sb.Append("<td class=\"tr_c\" colspan=\"9\">No data available in table</td>");
            //No matching records found//
        }

        strReturn[0] = sbHead.ToString();
        strReturn[1] = sb.ToString();
        return strReturn;
    }
    
    [WebMethod]
    public static string[] LoadStaticDatafordt()//Filters    
    {
        StringBuilder html = new StringBuilder();
        StringBuilder sbSearchInputColumns = new StringBuilder();

        string[] strResults = new string[3];
        html.Append("<div>");

        html.Append("<div class=\"col-md-2\">");//length
        html.Append("<p><span class=\"tbl_srt1\">Show</span> <select class=\"form-control tbl_srt\" onchange=\"getdata(1);\" id=\"ddl_page_size\">");
        html.Append("<option value=\"10\">10</option><option value=\"25\">25</option><option value=\"50\">50</option><option value=\"100\">100</option></select> entries");
        html.Append("</p></div>");
        //page length ends
        //common filter
        html.Append("<div class=\"col-md-2 pull-right\">");
        html.Append("<input  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"SettypingTimer();\" class=\"form-control tbl_ser_n\" id=\"txtCommonSearch_dt\"  type=\"search\" placeholder=\" Search \" aria-controls=\"example\">");
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
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\" style=\"display:none;\" ></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "1")
            {
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"EMPLOYEE CODE\" placeholder=\"Employee code\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "2")
            {
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"EMPLOYEE NAME\" placeholder=\"Employee name\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "3")
            {
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"DESIGNATION\" placeholder=\"Designation\"></th>");
            }
        }
        //this is to adjust the non search  fields
        sbSearchInputColumns.Append("<td id=\"thPagingTable_thAdjuster\"></td>");
        strResults[1] = sbSearchInputColumns.ToString();
        strResults[2] = intSearchColumnCount.ToString();
        return strResults;
    }


    public enum SearchInputColumns
    {
        //Must be sequential 
        CHECKBOXALL =0,
        CODE = 1,
        NAME = 2,
        DESIGNATION = 3,
    }




    public class PDFHeader : PdfPageEventHelper
    {
        // This is the contentbyte object of the writer
        PdfContentByte cb;

        // we will put the final number of pages in a template
        PdfTemplate footerTemplate;

        // this is the BaseFont we are going to use for the header / footer
        BaseFont bf = null;

        // This keeps track of the creation time
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
        public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            base.OnEndPage(writer, document);
            clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
            clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
            objEntityLeavSettlmt.EmployeeId = Convert.ToInt32(HttpContext.Current.Session["USERID"].ToString());
            DataTable dtEmp = objBusinessLeavSettlmt.ReadEmpDtls(objEntityLeavSettlmt);


            PdfPTable table3 = new PdfPTable(1);
            float[] tableBody3 = { 100 };
            table3.SetWidths(tableBody3);
            table3.WidthPercentage = 100;
            table3.TotalWidth = 650F;
            table3.AddCell(new PdfPCell(new Phrase("__________________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
            table3.WriteSelectedRows(0, -1, 0, document.PageSize.GetBottom(50), writer.DirectContent);

            PdfPTable headImg = new PdfPTable(3);
            string strImageLogo = "/Images/Design_Images/images/Compztlogo.png";
            if (strImageLogo != "")
            {
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
                image.ScalePercent(PdfPCell.ALIGN_CENTER);
                image.ScaleToFit(60f, 40f);
                headImg.AddCell(new PdfPCell(image) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_TOP });
            }
            headImg.AddCell(new PdfPCell(new Paragraph("Report generated in Compzit by:" + dtEmp.Rows[0]["USR_CODE"].ToString() + ", " + dtEmp.Rows[0]["USR_FNAME"].ToString() + "\nReport generated on:" + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
            headImg.AddCell(new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            float[] headersHeading = { 20, 60, 20 };
            headImg.SetWidths(headersHeading);
            headImg.WidthPercentage = 100;
            headImg.TotalWidth = document.PageSize.Width - 80f;
            headImg.WriteSelectedRows(0, -1, 50, document.PageSize.GetBottom(40), writer.DirectContent);


            String text = "Page " + writer.PageNumber + " of ";
            //Add paging to footer
            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.SetTextMatrix(document.PageSize.GetRight(100), document.PageSize.GetBottom(30));
                cb.ShowText(text);
                cb.EndText();
                float len = bf.GetWidthPoint(text, 8);
                cb.AddTemplate(footerTemplate, document.PageSize.GetRight(100) + len, document.PageSize.GetBottom(30));
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
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
        cls_Entity_Monthly_Salary_Process objEntPrcss = new cls_Entity_Monthly_Salary_Process();
        int intCorpId = 0;
        int intOrgId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }

        clsCommonLibrary objCommon = new clsCommonLibrary();

        string EmpId = HiddenEmployeeId.Value;
        string RowCount = HiddenRowCount.Value;
        string SalaryPrcsdId = hiddenSalaryPrcsdId.Value;
        string PrcssdConfDate = hiddenSlryPrcssdConfDate.Value;

        int PaidFinish = 1;
        objEntPrcss.Dep = Convert.ToInt32(hiddenDep_Id.Value);

        objEntPrcss.StffWrkr = Convert.ToInt32(ddlEmpTyp.SelectedItem.Value);
        DateTime ddate = objCommon.textToDateTime(PrcssdConfDate);
       // objEntPrcss.Month = 5;
        objEntPrcss.Month = Convert.ToInt32(ddlMonth.SelectedItem.Value);
        objEntPrcss.Year = Convert.ToInt32(ddlyear.SelectedItem.Value);
        objEntPrcss.PaidFinish = 1;
        objEntPrcss.CorpOffice = intCorpId;
        objEntPrcss.date = ddate;

        if (HiddenEmployeeId.Value != "")
            objEntPrcss.Employee = Convert.ToInt32(HiddenEmployeeId.Value);

        DataTable dt = objBuss.LoadSalaryPrssPaymentTable(objEntPrcss);

        if (dt.Rows.Count > 0)
        {
            if (HiddenEmployeeId.Value != "")
                objEntPrcss.Employee = Convert.ToInt32(HiddenEmployeeId.Value);
            objEntPrcss.SalaryPrssId = Convert.ToInt32(hiddenSalaryPrcsdId.Value);
        }
        Generate_LabourCard_PDF(objEntPrcss);
        ScriptManager.RegisterStartupScript(this, GetType(), "PrintClick", "PrintClick();", true);      
    }

    public void Generate_LabourCard_PDF(cls_Entity_Monthly_Salary_Process OBJ)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
        cls_Entity_Monthly_Salary_Process objEntPrcss = new cls_Entity_Monthly_Salary_Process();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        StringBuilder sbCap = new StringBuilder();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntPrcss.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntPrcss.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }

        DataTable dtCorp = objBuss.ReadCorporateAddress(objEntPrcss);
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "", strCompanyLogo = "";

        string strTitle = "";
        //l1
        strTitle = "LABOR CARD";

        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");

        if (dtCorp.Rows.Count > 0)
        {
            strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
            strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
            strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
            strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
            strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
            strCompanyLogo = dtCorp.Rows[0]["CORPRT_ICON"].ToString();
        }
        if (strCompanyLogo != "")
        {
            strCompanyLogo = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit) + strCompanyLogo;
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


        cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
        objEnt.Employee = OBJ.Employee;
        objEnt.Month = OBJ.Month;
        objEnt.Year = OBJ.Year;
        DataTable dtSalPrssDtls;
        dtSalPrssDtls = objBuss.ReadSalaryProssDtlsById(objEnt);
        cls_Business_Monthly_Salary_Process objBuss1 = new cls_Business_Monthly_Salary_Process();
        cls_Entity_Monthly_Salary_Process objEnt1 = new cls_Entity_Monthly_Salary_Process();
        clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
        clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
        DataTable dt = objBusinessLeavSettlmt.ReadLeaveSettlmt_ById(objEntityLeavSettlmt);
        if (dtSalPrssDtls.Rows.Count > 0)
        {

            //    Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);
            Document document = new Document(PageSize.LETTER, 15f, 25f, 15f, 50f);
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                string strImageName = "LabourCard_" + OBJ.SalaryPrssId + ".pdf";
                string imgpath = "/CustomFiles/PaySlip/";
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.PAYSLIP_PDF);


                string fullPath = System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName;
                if ((System.IO.File.Exists(fullPath)))
                {
                    System.IO.File.Delete(fullPath);
                }

                FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(imgpath) + strImageName, FileMode.Create);
                PdfWriter.GetInstance(document, file);
                writer.PageEvent = new PDFHeader();
                document.Open();

                if (true)
                {
                    PdfPTable headtable = new PdfPTable(2);
                    //lbr -1 year 11
                    headtable.AddCell(new PdfPCell(new Phrase("LABOR CARD", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    if (strCompanyLogo != "")
                    {
                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strCompanyLogo));
                        image.ScalePercent(PdfPCell.ALIGN_CENTER);
                        image.ScaleToFit(60f, 40f);
                        headtable.AddCell(new PdfPCell(image) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                    }
                    else
                    {
                        headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    }
                    headtable.AddCell(new PdfPCell(new Phrase(strCompanyName, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    headtable.AddCell(new PdfPCell(new Phrase(strAddress, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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
                    tableLine.WriteSelectedRows(0, -1, 0, document.PageSize.GetTop(55), writer.DirectContent);



                    float pos9 = writer.GetVerticalPosition(false);
                    PdfPTable tableLayout = new PdfPTable(6);
                    float[] headersBody = { 19, 19, 14, 16, 16, 16 };
                    tableLayout.SetWidths(headersBody);
                    tableLayout.WidthPercentage = 100;

                    tableLayout.AddCell(new PdfPCell(new Phrase("DATE", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase("JOB#", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase("STATUS", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase("NORMAL HOURS", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase("NORMAL OT", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase("HOLIDAY OT", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });

                    int numMonth = DateTime.DaysInMonth(OBJ.Year, OBJ.Month);
                    string MonthName = "";

                    decimal NormlOT = 0, HoldayOt = 0;
                    decimal NormalOvertmRatePrHr = 0, HolidayOvertmRatePrHr = 0;

                    for (int intRowBodyCount = 1; intRowBodyCount <= numMonth; intRowBodyCount++)
                    {
                        string EmDate = new DateTime(OBJ.Year, OBJ.Month, intRowBodyCount).ToString("dd-MM-yyyy");
                        DateTime ddate = objCommon.textToDateTime(EmDate);

                        objEntPrcss.date = ddate;
                        MonthName = ddate.ToString("MMMM");
                        objEntPrcss.Employee = OBJ.Employee;
                        objEntPrcss.Month = OBJ.Month;
                        objEntPrcss.Year = OBJ.Year;
                        DataTable dtEmp_list = objBuss.ReadEmp_List_For_Print(objEntPrcss);

                        tableLayout.AddCell(new PdfPCell(new Phrase(ddate.ToString("dd-MM-yyyy"), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                        if (dtEmp_list.Rows.Count > 0)
                        {
                            tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["JOBMSTR_TITLE"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                            tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["ATTENDANCE"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });

                            if (dtEmp_list.Rows[0]["ATTENDANCE"].ToString() == "P")
                            {
                                tableLayout.AddCell(new PdfPCell(new Phrase("8", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                            }
                            else if (dtEmp_list.Rows[0]["ATTENDANCE"].ToString() == "A")
                            {
                                tableLayout.AddCell(new PdfPCell(new Phrase("0", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                            }

                            foreach (DataRow row in dtEmp_list.Rows)
                            {

                                if (row["OVRTMCATG_NAME"].ToString() == "NORMAL OT")
                                {
                                    tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                    NormlOT += Convert.ToDecimal(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString());
                                    NormalOvertmRatePrHr = Convert.ToDecimal(row["OVRTMCATG_RATE"].ToString());
                                }
                                else
                                {
                                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                }
                                if (row["OVRTMCATG_NAME"].ToString() == "HOLIDAY OT")
                                {
                                    tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                    HoldayOt += Convert.ToDecimal(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString());
                                    HolidayOvertmRatePrHr = Convert.ToDecimal(row["OVRTMCATG_RATE"].ToString());
                                }
                                else
                                {
                                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                }
                            }
                        }
                        else
                        {
                            tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                            tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                            tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                            tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                            tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                        }

                    }

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 4, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase(NormlOT.ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase(HoldayOt.ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 6, Padding = 2 });

                    PdfPTable pdfBodyTable = new PdfPTable(4);
                    pdfBodyTable.WidthPercentage = 100;

                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 4, Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 4, Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("EMPLOYEE CODE", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(dtSalPrssDtls.Rows[0]["USR_CODE"].ToString(), new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("DESIGNATION", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(dtSalPrssDtls.Rows[0]["DSGN_NAME"].ToString(), new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });


                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("MONTH & YEAR", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(MonthName.ToUpper() + " " + OBJ.Year, new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 2, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });


                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("EMPLOYEE NAME", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(dtSalPrssDtls.Rows[0]["USR_NAME"].ToString(), new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 3, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });

                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 4, Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    if (pos9 > 150)
                    {
                    }
                    else
                    {
                        document.NewPage();
                    }
                    document.Add(pdfBodyTable);


                    float pos8 = writer.GetVerticalPosition(false);
                    if (pos8 > 150)
                    {
                    }
                    else
                    {
                        document.NewPage();
                    }

                    document.Add(tableLayout);

                    string basicAmt = "", AllowaceAmt = "", AllowovertimeAmount = "", DedctionAmt = "", DedctionInstalmntAmnt = "", Total = "", OT_Hours = "", MessAmnt = "", LvArrearAmnt = "";
                    Decimal TotalBasicAllow = 0, TotalDedctn = 0, netsalary = 0, AllowovertimeAmount1 = 0, AllowaceAmt1 = 0, basicAmt1 = 0, instlmntDedctionAmt = 0, deductnamt = 0;
                    Decimal decMessAmnt = 0, decLvArrearAmnt = 0, decCurrMonthBasic = 0;

                    basicAmt = dtSalPrssDtls.Rows[0]["SLRY_BASIC_PAY"].ToString();
                    AllowaceAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_ALLOW_AMT"].ToString();
                    AllowovertimeAmount = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_OVERTIME_ALLOW_AMT"].ToString();
                    DedctionAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_DEDCTN_AMT"].ToString();
                    DedctionInstalmntAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_INSTLMNT_DEDCN_AMT"].ToString();
                    Total = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_TOTAL_AMT"].ToString();

                    if (dtSalPrssDtls.Rows.Count > 0)
                    {

                        if (dtSalPrssDtls.Rows[0]["SLPRCDMNTH_TOTAL_AMT"].ToString() != "")
                        {
                            OT_Hours = dtSalPrssDtls.Rows[0]["EMDLHRDTL_OT"].ToString();
                        }
                        MessAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_MESS_DEDCTN_AMT"].ToString();
                        LvArrearAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_LEV_ARREAR_AMT"].ToString();
                    }


                    //manual addition
                    objEnt.Orgid = objEntPrcss.Orgid;
                    objEnt.CorpOffice = objEntPrcss.CorpOffice;
                 

                    //DataTable dtOtherAddDedDetls = objBuss1.ReadEmpManualy_Add_Dedn(objEnt1);
                    DataTable dtOtherAddDedDetls = objBuss1.ReadEmpManualy_Add_Dedn_Dtls(objEnt);
                    decimal TotOthrAddAmt = 0, TotOthrDeductAmt = 0;
                    for (int j = 0; j < dtOtherAddDedDetls.Rows.Count; j++)
                    {
                        if (dtOtherAddDedDetls.Rows[j]["PAYRL_MODE"].ToString() == "1")
                        {
                            TotOthrAddAmt += Convert.ToDecimal(dtOtherAddDedDetls.Rows[j]["PAYINFDT_AMOUNT"].ToString());
                        }
                        else if (dtOtherAddDedDetls.Rows[j]["PAYRL_MODE"].ToString() == "2")
                        {
                            TotOthrDeductAmt += Convert.ToDecimal(dtOtherAddDedDetls.Rows[j]["PAYINFDT_AMOUNT"].ToString());
                        }

                    }

                    int daysInm = DateTime.DaysInMonth(objEntPrcss.Year, objEntPrcss.Month);
                    decimal decPerHourSal = Convert.ToDecimal(basicAmt) / daysInm;
                    if (decPerHourSal > 0)
                    {
                        decPerHourSal = decPerHourSal / 8;
                    }

                    decimal NormalOTAmnt = NormlOT * NormalOvertmRatePrHr * decPerHourSal;
                    decimal HolidayOTAmnt = HoldayOt * HolidayOvertmRatePrHr * decPerHourSal;
                    decimal TotOvertimeAmnt = NormalOTAmnt + HolidayOTAmnt;

                    string strHolidayOtAmt = objBusiness.AddCommasForNumberSeperation(HolidayOTAmnt.ToString("0.00"), objEntityCommon);
                    string strNormalOT = objBusiness.AddCommasForNumberSeperation(NormalOTAmnt.ToString("0.00"), objEntityCommon);
                   
                    if (basicAmt != "")
                    {
                        basicAmt1 = Convert.ToDecimal(basicAmt);
                        TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(basicAmt);
                    }
                    if (AllowaceAmt != "")
                    {
                        AllowaceAmt1 = Convert.ToDecimal(AllowaceAmt);
                        TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(AllowaceAmt);
                    }
                    if (AllowovertimeAmount != "")
                    {
                        AllowovertimeAmount1 = Convert.ToDecimal(AllowovertimeAmount);
                        TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(AllowovertimeAmount) + TotOthrAddAmt;
                    }
                    if (DedctionAmt != "")
                    {
                        deductnamt = Convert.ToDecimal(DedctionAmt);
                        TotalDedctn = TotalDedctn + Convert.ToDecimal(DedctionAmt);
                    }
                    if (DedctionInstalmntAmnt != "")
                    {
                        instlmntDedctionAmt = Convert.ToDecimal(DedctionInstalmntAmnt);
                        TotalDedctn = TotalDedctn + Convert.ToDecimal(DedctionInstalmntAmnt);
                    }
                    if (MessAmnt != "")
                    {
                        decMessAmnt = Convert.ToDecimal(MessAmnt);
                        TotalDedctn = TotalDedctn + Convert.ToDecimal(decMessAmnt);
                    }
                    if (LvArrearAmnt != "")
                    {
                        decLvArrearAmnt = Convert.ToDecimal(LvArrearAmnt);
                        TotalDedctn = TotalDedctn + Convert.ToDecimal(decLvArrearAmnt) + TotOthrDeductAmt;
                    }
                    if (Total != "")
                    {
                        // netsalary = Convert.ToDecimal(Total);
                        netsalary = TotalBasicAllow - TotalDedctn;

                    }



                    string strbasicAmt = objBusiness.AddCommasForNumberSeperation(basicAmt1.ToString("0.00"), objEntityCommon);
                    string strAllowaceAmt = objBusiness.AddCommasForNumberSeperation(AllowaceAmt1.ToString("0.00"), objEntityCommon);
                    string strAllowovertimeAmount = objBusiness.AddCommasForNumberSeperation(AllowovertimeAmount1.ToString("0.00"), objEntityCommon);
                    string strTotalBasicAllow = objBusiness.AddCommasForNumberSeperation(TotalBasicAllow.ToString("0.00"), objEntityCommon);
                    string strDeductnAmt = objBusiness.AddCommasForNumberSeperation(deductnamt.ToString("0.00"), objEntityCommon);
                    string strDeductnInstlmtAmount = objBusiness.AddCommasForNumberSeperation(instlmntDedctionAmt.ToString("0.00"), objEntityCommon);
                    string strTotalDedctn = objBusiness.AddCommasForNumberSeperation(TotalDedctn.ToString("0.00"), objEntityCommon);
                    string strnetsalary = objBusiness.AddCommasForNumberSeperation(netsalary.ToString("0.00"), objEntityCommon);
                    string strMessAmnt = objBusiness.AddCommasForNumberSeperation(decMessAmnt.ToString("0.00"), objEntityCommon);
                    string strLvArrearAmnt = objBusiness.AddCommasForNumberSeperation(decLvArrearAmnt.ToString("0.00"), objEntityCommon);

                    string strNormalOTAmnt = objBusiness.AddCommasForNumberSeperation(NormalOTAmnt.ToString("0.00"), objEntityCommon);
                    string strHolidayOTAmnt = objBusiness.AddCommasForNumberSeperation(HolidayOTAmnt.ToString("0.00"), objEntityCommon);

                    float pos4 = writer.GetVerticalPosition(false);
                    PdfPTable sumtable = new PdfPTable(6);
                    float[] footrsBody = { 14, 28, 16, 13, 15, 14 };
                    sumtable.SetWidths(footrsBody);
                    sumtable.WidthPercentage = 100;


                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Basic and Allowances", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = BaseColor.LIGHT_GRAY, Colspan = 4, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Description", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase("Days/Hrs", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Basic Pay", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(strbasicAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(numMonth.ToString(), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(strbasicAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    if (Convert.ToDecimal(strAllowaceAmt) != 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Special Allowance", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strAllowaceAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strAllowaceAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    }
                  
                    if (NormlOT != 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Normal OT @" + NormalOvertmRatePrHr.ToString() + "/hr", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(NormlOT.ToString(), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strNormalOT, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    }

                    if (HoldayOt != 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Holiday OT @" + HolidayOvertmRatePrHr.ToString() + "/hr", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(HoldayOt.ToString(), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strHolidayOtAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    }

                    //Manual Addition or deduction
                    for (int j = 0; j < dtOtherAddDedDetls.Rows.Count; j++)
                    {
                        if (dtOtherAddDedDetls.Rows[j]["PAYRL_MODE"].ToString() == "1")
                        {
                            string strTotOthrAddAmt = objBusiness.AddCommasForNumberSeperation(Convert.ToDecimal(dtOtherAddDedDetls.Rows[j]["PAYINFDT_AMOUNT"]).ToString("0.00"), objEntityCommon);
                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            sumtable.AddCell(new PdfPCell(new Phrase(dtOtherAddDedDetls.Rows[j]["PAYRL_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(strTotOthrAddAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(strTotOthrAddAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        }
                    }

                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Total Basic and Allowances", FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(strTotalBasicAllow, FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

               

                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Deductions", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = BaseColor.LIGHT_GRAY, Colspan = 4, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Deduction Types", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BackgroundColor = BaseColor.LIGHT_GRAY, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = BaseColor.LIGHT_GRAY, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    if (Convert.ToDecimal(strDeductnAmt) != 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Special Deductions", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strDeductnAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    }

                    if (Convert.ToDecimal(strDeductnInstlmtAmount) != 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Installment Deductions", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strDeductnInstlmtAmount, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    }

                    if (Convert.ToDecimal(strMessAmnt) != 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Mess Deductions", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strMessAmnt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    }

                    if (Convert.ToDecimal(strLvArrearAmnt) != 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Leave Arrear Deductions", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strLvArrearAmnt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    }

                    for (int J = 0; J < dtOtherAddDedDetls.Rows.Count; J++)
                    {
                        if (dtOtherAddDedDetls.Rows[J]["PAYRL_MODE"].ToString() == "2")
                        {
                            string strTotOthrDeductAmt = objBusiness.AddCommasForNumberSeperation(Convert.ToDecimal(dtOtherAddDedDetls.Rows[J]["PAYINFDT_AMOUNT"]).ToString("0.00"), objEntityCommon);
                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            sumtable.AddCell(new PdfPCell(new Phrase(dtOtherAddDedDetls.Rows[J]["PAYRL_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(strTotOthrDeductAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        }
                    }

                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Total Deductions", FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(strTotalDedctn, FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = BaseColor.LIGHT_GRAY, Colspan = 4, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Net Salary", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(strnetsalary + " " + dtSalPrssDtls.Rows[0]["CRNCMST_ABBRV"].ToString(), FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    if (pos4 > 200)
                    {
                    }
                    else
                    {
                        document.NewPage();
                    }

                    document.Add(sumtable);

                    float pos1 = writer.GetVerticalPosition(false);
                    PdfPTable endtable = new PdfPTable(6);
                    float[] endBody = { 25, 10, 25, 10, 25, 5 };
                    endtable.SetWidths(endBody);
                    endtable.WidthPercentage = 100;
                    endtable.TotalWidth = document.PageSize.Width - 80f;

                    endtable.AddCell(new PdfPCell(new Phrase("FINANCE MANAGER", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                    endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                    endtable.AddCell(new PdfPCell(new Phrase("GENERAL MANAGER", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                    endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                    endtable.AddCell(new PdfPCell(new Phrase("RECEIVER'S SIGNATURE", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                    endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });

                    if (pos1 > 70)
                    {
                        endtable.WriteSelectedRows(0, -1, 50, 65, writer.DirectContent);
                    }
                    else
                    {
                        document.NewPage();
                        endtable.WriteSelectedRows(0, -1, 50, 65, writer.DirectContent);
                    }
                }//if TRADE                                            
                document.Close();

                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=LabourCard_" + OBJ.SalaryPrssId + ".pdf");
                Response.Buffer = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();

            }
        }

    }



    public void btnSearch_Click()
    {
        cls_Business_Bulk_LabourCard_Print objBussBulkPrint = new cls_Business_Bulk_LabourCard_Print();
        cls_Entity_Bulk_LabourCard_Print objEntityBulkPrint = new cls_Entity_Bulk_LabourCard_Print();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityBulkPrint.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityBulkPrint.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (ddlDep.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntityBulkPrint.Dep = Convert.ToInt32(ddlDep.SelectedItem.Value);
        }

         objEntityBulkPrint.Month = Convert.ToInt32(ddlMonth.SelectedItem.Value);
       // objEntityBulkPrint.Month = 5;
        objEntityBulkPrint.Year = Convert.ToInt32(ddlyear.SelectedItem.Value);
        objEntityBulkPrint.StffWrkr = Convert.ToInt32(ddlEmpTyp.SelectedItem.Value);

        if (ddlEmployeeFirst.SelectedItem.Value != "--SELECT EMPLOYEE CODE--")
        {
            objEntityBulkPrint.EmpIdFirst = Convert.ToInt32(ddlEmployeeFirst.SelectedItem.Value);
        }
        if (ddlEmployeeSecond.SelectedItem.Value != "--SELECT EMPLOYEE CODE--")
        {
            objEntityBulkPrint.EmpIdSecond = Convert.ToInt32(ddlEmployeeSecond.SelectedItem.Value);
        }

        if (radio_Printed.Checked == true)
        {
            objEntityBulkPrint.Print_Sts = 1;
        }
        else if (radio_NotPrinted.Checked == true)
        {
            objEntityBulkPrint.Print_Sts = 0;
        }
      //  DataTable dtDetails = objBussBulkPrint.ReadEmployeeDetails(objEntityBulkPrint);

       
    }

    protected void btnBulkPrint_Click(object sender, EventArgs e)
    {

        cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
        cls_Business_Bulk_LabourCard_Print objBussBulkPrint = new cls_Business_Bulk_LabourCard_Print();
        cls_Entity_Bulk_LabourCard_Print OBJBulk = new cls_Entity_Bulk_LabourCard_Print();
        cls_Entity_Monthly_Salary_Process OBJ = new cls_Entity_Monthly_Salary_Process();
        clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
        clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        int intCorpId = 0;
        int intOrgId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }

        clsCommonLibrary objCommon = new clsCommonLibrary();

        string RowCount = HiddenRowCount.Value;
        string SalaryPrcsdId = hiddenSalaryPrcsdId.Value;
        string PrcssdConfDate = hiddenSlryPrcssdConfDate.Value;
        int PaidFinish = 1;
        //  OBJ.Dep = Convert.ToInt32(hiddenDep_Id.Value);
        OBJ.StffWrkr = Convert.ToInt32(ddlEmpTyp.SelectedItem.Value);




        if (hiddenAllEmpid.Value != "")
        {

            OBJBulk.MultipleEmpId = hiddenAllEmpid.Value;
            //OBJBulk.Month = 5;
            OBJBulk.Month = Convert.ToInt32(ddlMonth.SelectedItem.Value);
            OBJBulk.Year = Convert.ToInt32(ddlyear.SelectedItem.Value);
            OBJBulk.PaidFinish = 1;
            OBJBulk.CorpOffice = intCorpId;
            OBJBulk.Orgid = intOrgId;
            //OBJ.Month = 5;

            OBJ.Month = Convert.ToInt32(ddlMonth.SelectedItem.Value);
            OBJ.Year = Convert.ToInt32(ddlyear.SelectedItem.Value);
            OBJ.CorpOffice = intCorpId;
            OBJ.Orgid = intOrgId;


            //Manual Addition
            cls_Business_Monthly_Salary_Process objBuss1 = new cls_Business_Monthly_Salary_Process();
            cls_Entity_Monthly_Salary_Process objEnt1 = new cls_Entity_Monthly_Salary_Process();
            DataTable dt = objBusinessLeavSettlmt.ReadLeaveSettlmt_ById(objEntityLeavSettlmt);

            DataTable dtLeavMonth1 = objBuss1.ReadLastDatePrint(objEnt1);
            DataTable dtSal = new DataTable();
            dtSal = objBussBulkPrint.LoadSalaryPrssPaymentTable(OBJBulk);
            string[] EmpId = hiddenAllEmpid.Value.Split(',');
            // dtSal = objBussBulkPrint.LoadSalaryPrssPaymentTable(OBJBulk);
            string strid = (OBJ.Year + "_" + OBJ.Month + "_" + OBJ.Dep).ToString();
            DataTable dtCorp = objBuss.ReadCorporateAddress(OBJ);
            string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "", strCompanyLogo = "";

            string strTitle = "";
            //l1   objEntPrcss.date = ddate
            strTitle = "LABOR CARD";

            DateTime datetm = DateTime.Now;
            string dat = "<B>Report Date: </B>" + datetm.ToString("R");

            if (dtCorp.Rows.Count > 0)
            {
                strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
                strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
                strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
                strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
                strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
                strCompanyLogo = dtCorp.Rows[0]["CORPRT_ICON"].ToString();
            }
            if (strCompanyLogo != "")
            {
                strCompanyLogo = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit) + strCompanyLogo;
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

            //  DataTable dt = objBusinessLeavSettlmt.ReadLeaveSettlmt_ById(objEntityLeavSettlmt);

            Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);

            if (ddlEmpTyp.SelectedItem.Value == "1")
            {
                document = new Document(PageSize.LETTER, 15f, 25f, 15f, 45f);
            }

            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                string strImageName = "";
                if (ddlEmpTyp.SelectedItem.Value == "1")
                {
                    strImageName = "LabourCard_" + strid + ".pdf";
                }
                else
                {
                    strImageName = "Payslip_" + strid + ".pdf";
                }
                string imgpath = "/CustomFiles/PaySlip/";
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.PAYSLIP_PDF);

                string fullPath = System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName;
                if ((System.IO.File.Exists(fullPath)))
                {
                    System.IO.File.Delete(fullPath);
                }

                FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(imgpath) + strImageName, FileMode.Create);
                PdfWriter.GetInstance(document, file);
                writer.PageEvent = new PDFHeader();
                document.Open();

                if (true)
                {
                    for (int i = 0; i < dtSal.Rows.Count; i++)
                    {
                        if (i != 0)
                        {
                            document.NewPage();
                        }
                        int empid = Convert.ToInt32(dtSal.Rows[i]["USR_ID"]);
                        objEnt1.Employee = empid;
                        cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
                        objEnt.Employee = empid;
                        objEnt.Month = OBJ.Month;
                        objEnt.Year = OBJ.Year;
                        DataTable dtSalPrssDtls;
                        dtSalPrssDtls = objBuss.ReadSalaryProssDtlsById(objEnt);


                        if (ddlEmpTyp.SelectedItem.Value == "1")//labour card
                        {

                            PdfPTable headtable = new PdfPTable(2);
                            //lbr -1 year 11
                            headtable.AddCell(new PdfPCell(new Phrase("LABOR CARD", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                            if (strCompanyLogo != "")
                            {
                                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strCompanyLogo));
                                image.ScalePercent(PdfPCell.ALIGN_CENTER);
                                image.ScaleToFit(60f, 40f);
                                headtable.AddCell(new PdfPCell(image) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                            }
                            else
                            {
                                headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                            }
                            headtable.AddCell(new PdfPCell(new Phrase(strCompanyName, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                            headtable.AddCell(new PdfPCell(new Phrase(strAddress, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                            float[] headersHeading = { 80, 20 };
                            headtable.SetWidths(headersHeading);
                            headtable.WidthPercentage = 100;
                            document.Add(headtable);

                            PdfPTable tableLine = new PdfPTable(1);
                            float[] tableLineBody = { 100 };
                            tableLine.SetWidths(tableLineBody);
                            tableLine.WidthPercentage = 100;
                            tableLine.TotalWidth = 650F;
                            tableLine.AddCell(new PdfPCell(new Phrase("________________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                            tableLine.WriteSelectedRows(0, -1, 0, document.PageSize.GetTop(55), writer.DirectContent);


                            float pos9 = writer.GetVerticalPosition(false);
                            PdfPTable tableLayout = new PdfPTable(6);
                            float[] headersBody = { 19, 19, 14, 16, 16, 16 };
                            tableLayout.SetWidths(headersBody);
                            tableLayout.WidthPercentage = 100;

                            tableLayout.AddCell(new PdfPCell(new Phrase("DATE", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                            tableLayout.AddCell(new PdfPCell(new Phrase("JOB#", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                            tableLayout.AddCell(new PdfPCell(new Phrase("STATUS", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                            tableLayout.AddCell(new PdfPCell(new Phrase("NORMAL HOURS", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                            tableLayout.AddCell(new PdfPCell(new Phrase("NORMAL OT", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                            tableLayout.AddCell(new PdfPCell(new Phrase("HOLIDAY OT", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });

                            int numMonth = DateTime.DaysInMonth(OBJ.Year, OBJ.Month);
                            string MonthName = "";

                            decimal NormlOT = 0, HoldayOt = 0;
                            decimal NormalOvertmRatePrHr = 0, HolidayOvertmRatePrHr = 0;

                            for (int intRowBodyCount = 1; intRowBodyCount <= numMonth; intRowBodyCount++)
                            {
                                string EmDate = new DateTime(OBJ.Year, OBJ.Month, intRowBodyCount).ToString("dd-MM-yyyy");
                                DateTime ddate = objCommon.textToDateTime(EmDate);

                                OBJ.date = ddate;
                                MonthName = ddate.ToString("MMMM");
                                OBJ.Employee = empid;
                                OBJ.Month = OBJ.Month;
                                OBJ.Year = OBJ.Year;
                                DataTable dtEmp_list = objBuss.ReadEmp_List_For_Print(OBJ);

                                tableLayout.AddCell(new PdfPCell(new Phrase(ddate.ToString("dd-MM-yyyy"), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                if (dtEmp_list.Rows.Count > 0)
                                {
                                    tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["JOBMSTR_TITLE"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                    tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["ATTENDANCE"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });

                                    if (dtEmp_list.Rows[0]["ATTENDANCE"].ToString() == "P")
                                    {
                                        tableLayout.AddCell(new PdfPCell(new Phrase("8", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                    }
                                    else if (dtEmp_list.Rows[0]["ATTENDANCE"].ToString() == "A")
                                    {
                                        tableLayout.AddCell(new PdfPCell(new Phrase("0", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                    }

                                    foreach (DataRow row in dtEmp_list.Rows)
                                    {

                                        if (row["OVRTMCATG_NAME"].ToString() == "NORMAL OT")
                                        {
                                            tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                            NormlOT += Convert.ToDecimal(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString());
                                            NormalOvertmRatePrHr = Convert.ToDecimal(row["OVRTMCATG_RATE"].ToString());
                                        }
                                        else
                                        {
                                            tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                        }
                                        if (row["OVRTMCATG_NAME"].ToString() == "HOLIDAY OT")
                                        {
                                            tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                            HoldayOt += Convert.ToDecimal(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString());
                                            HolidayOvertmRatePrHr = Convert.ToDecimal(row["OVRTMCATG_RATE"].ToString());
                                        }
                                        else
                                        {
                                            tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                        }
                                    }
                                }
                                else
                                {
                                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                }

                            }

                            tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 4, Padding = 2, BorderColor = BaseColor.GRAY });
                            tableLayout.AddCell(new PdfPCell(new Phrase(NormlOT.ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                            tableLayout.AddCell(new PdfPCell(new Phrase(HoldayOt.ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                            tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 6, Padding = 2 });

                            PdfPTable pdfBodyTable = new PdfPTable(4);
                            pdfBodyTable.WidthPercentage = 100;

                            pdfBodyTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 4, Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            pdfBodyTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 4, Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                            pdfBodyTable.AddCell(new PdfPCell(new Phrase("EMPLOYEE CODE", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                            pdfBodyTable.AddCell(new PdfPCell(new Phrase(dtSalPrssDtls.Rows[0]["USR_CODE"].ToString(), new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                            pdfBodyTable.AddCell(new PdfPCell(new Phrase("DESIGNATION", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                            pdfBodyTable.AddCell(new PdfPCell(new Phrase(dtSalPrssDtls.Rows[0]["DSGN_NAME"].ToString(), new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });


                            pdfBodyTable.AddCell(new PdfPCell(new Phrase("MONTH & YEAR", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                            pdfBodyTable.AddCell(new PdfPCell(new Phrase(MonthName.ToUpper() + " " + OBJ.Year, new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                            pdfBodyTable.AddCell(new PdfPCell(new Phrase("", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 2, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });


                            pdfBodyTable.AddCell(new PdfPCell(new Phrase("EMPLOYEE NAME", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                            pdfBodyTable.AddCell(new PdfPCell(new Phrase(dtSalPrssDtls.Rows[0]["USR_NAME"].ToString(), new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 3, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });

                            pdfBodyTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 4, Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            if (pos9 > 150)
                            {
                            }
                            else
                            {
                                document.NewPage();
                            }
                            document.Add(pdfBodyTable);


                            float pos8 = writer.GetVerticalPosition(false);
                            if (pos8 > 150)
                            {
                            }
                            else
                            {
                                document.NewPage();
                            }

                            document.Add(tableLayout);

                            string basicAmt = "", AllowaceAmt = "", AllowovertimeAmount = "", DedctionAmt = "", DedctionInstalmntAmnt = "", Total = "", OT_Hours = "", MessAmnt = "", LvArrearAmnt = "";
                            Decimal TotalBasicAllow = 0, TotalDedctn = 0, netsalary = 0, AllowovertimeAmount1 = 0, AllowaceAmt1 = 0, basicAmt1 = 0, instlmntDedctionAmt = 0, deductnamt = 0;
                            Decimal decMessAmnt = 0, decLvArrearAmnt = 0, decCurrMonthBasic = 0;

                            basicAmt = dtSalPrssDtls.Rows[0]["SLRY_BASIC_PAY"].ToString();
                            AllowaceAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_ALLOW_AMT"].ToString();
                            AllowovertimeAmount = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_OVERTIME_ALLOW_AMT"].ToString();
                            DedctionAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_DEDCTN_AMT"].ToString();
                            DedctionInstalmntAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_INSTLMNT_DEDCN_AMT"].ToString();
                            Total = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_TOTAL_AMT"].ToString();

                            if (dtSalPrssDtls.Rows.Count > 0)
                            {

                                if (dtSalPrssDtls.Rows[0]["SLPRCDMNTH_TOTAL_AMT"].ToString() != "")
                                {
                                    OT_Hours = dtSalPrssDtls.Rows[0]["EMDLHRDTL_OT"].ToString();
                                }
                                MessAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_MESS_DEDCTN_AMT"].ToString();
                                LvArrearAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_LEV_ARREAR_AMT"].ToString();
                            }


                            //    DateTime dtFromDate = dtFinal;
                            //manual addition
                            objEnt1.Orgid = objEntityLeavSettlmt.OrgId;
                            objEnt1.CorpOffice = objEntityLeavSettlmt.CorpId;
                            objEnt1.Month = OBJ.Month;
                            objEnt1.Year = OBJ.Year;

                            //DataTable dtOtherAddDedDetls = objBuss1.ReadEmpManualy_Add_Dedn(objEnt1);
                            DataTable dtOtherAddDedDetls = objBuss1.ReadEmpManualy_Add_Dedn_Dtls(objEnt1);
                            decimal TotOthrAddAmt = 0, TotOthrDeductAmt = 0;
                            for (int j = 0; j < dtOtherAddDedDetls.Rows.Count; j++)
                            {
                                if (dtOtherAddDedDetls.Rows[j]["PAYRL_MODE"].ToString() == "1")
                                {
                                    TotOthrAddAmt += Convert.ToDecimal(dtOtherAddDedDetls.Rows[j]["PAYINFDT_AMOUNT"].ToString());
                                }
                                else if (dtOtherAddDedDetls.Rows[j]["PAYRL_MODE"].ToString() == "2")
                                {
                                    TotOthrDeductAmt += Convert.ToDecimal(dtOtherAddDedDetls.Rows[j]["PAYINFDT_AMOUNT"].ToString());
                                }

                            }
                            




                            int daysInm = DateTime.DaysInMonth(OBJ.Year, OBJ.Month);
                            decimal decPerHourSal = Convert.ToDecimal(basicAmt) / daysInm;
                            if (decPerHourSal > 0)
                            {
                                decPerHourSal = decPerHourSal / 8;
                            }

                            decimal NormalOTAmnt = NormlOT * NormalOvertmRatePrHr * decPerHourSal;
                            decimal HolidayOTAmnt = HoldayOt * HolidayOvertmRatePrHr * decPerHourSal;
                            decimal TotOvertimeAmnt = NormalOTAmnt + HolidayOTAmnt;

                            if (basicAmt != "")
                            {
                                basicAmt1 = Convert.ToDecimal(basicAmt);
                                TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(basicAmt);
                            }
                            if (AllowaceAmt != "")
                            {
                                AllowaceAmt1 = Convert.ToDecimal(AllowaceAmt);
                                TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(AllowaceAmt);
                            }
                            if (AllowovertimeAmount != "")
                            {
                                AllowovertimeAmount1 = Convert.ToDecimal(AllowovertimeAmount);
                                TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(AllowovertimeAmount) + TotOthrAddAmt;

                            }
                            if (DedctionAmt != "")
                            {
                                deductnamt = Convert.ToDecimal(DedctionAmt);
                                TotalDedctn = TotalDedctn + Convert.ToDecimal(DedctionAmt);
                            }
                            if (DedctionInstalmntAmnt != "")
                            {
                                instlmntDedctionAmt = Convert.ToDecimal(DedctionInstalmntAmnt);
                                TotalDedctn = TotalDedctn + Convert.ToDecimal(DedctionInstalmntAmnt);
                            }
                            if (MessAmnt != "")
                            {
                                decMessAmnt = Convert.ToDecimal(MessAmnt);
                                TotalDedctn = TotalDedctn + Convert.ToDecimal(decMessAmnt);
                            }
                            if (LvArrearAmnt != "")
                            {
                                decLvArrearAmnt = Convert.ToDecimal(LvArrearAmnt);
                                TotalDedctn = TotalDedctn + Convert.ToDecimal(decLvArrearAmnt) + TotOthrDeductAmt;
                            }
                            if (Total != "")
                            {
                                //  netsalary = Convert.ToDecimal(Total);
                                netsalary = TotalBasicAllow - TotalDedctn;
                            }



                            string strbasicAmt = objBusiness.AddCommasForNumberSeperation(basicAmt1.ToString("0.00"), objEntityCommon);
                            string strAllowaceAmt = objBusiness.AddCommasForNumberSeperation(AllowaceAmt1.ToString("0.00"), objEntityCommon);
                            string strAllowovertimeAmount = objBusiness.AddCommasForNumberSeperation(AllowovertimeAmount1.ToString("0.00"), objEntityCommon);
                            string strTotalBasicAllow = objBusiness.AddCommasForNumberSeperation(TotalBasicAllow.ToString("0.00"), objEntityCommon);
                            string strDeductnAmt = objBusiness.AddCommasForNumberSeperation(deductnamt.ToString("0.00"), objEntityCommon);
                            string strDeductnInstlmtAmount = objBusiness.AddCommasForNumberSeperation(instlmntDedctionAmt.ToString("0.00"), objEntityCommon);
                            string strTotalDedctn = objBusiness.AddCommasForNumberSeperation(TotalDedctn.ToString("0.00"), objEntityCommon);
                            string strnetsalary = objBusiness.AddCommasForNumberSeperation(netsalary.ToString("0.00"), objEntityCommon);
                            string strMessAmnt = objBusiness.AddCommasForNumberSeperation(decMessAmnt.ToString("0.00"), objEntityCommon);
                            string strLvArrearAmnt = objBusiness.AddCommasForNumberSeperation(decLvArrearAmnt.ToString("0.00"), objEntityCommon);

                            string strNormalOTAmnt = objBusiness.AddCommasForNumberSeperation(NormalOTAmnt.ToString("0.00"), objEntityCommon);
                            string strHolidayOTAmnt = objBusiness.AddCommasForNumberSeperation(HolidayOTAmnt.ToString("0.00"), objEntityCommon);

                            float pos4 = writer.GetVerticalPosition(false);
                            PdfPTable sumtable = new PdfPTable(6);
                            float[] footrsBody = { 14, 28, 16, 13, 15, 14 };
                            sumtable.SetWidths(footrsBody);
                            sumtable.WidthPercentage = 100;

                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            sumtable.AddCell(new PdfPCell(new Phrase("Basic and Allowances", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = BaseColor.LIGHT_GRAY, Colspan = 4, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            sumtable.AddCell(new PdfPCell(new Phrase("Description", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase("Days/Hrs", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            sumtable.AddCell(new PdfPCell(new Phrase("Basic Pay", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(strbasicAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(numMonth.ToString(), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(strbasicAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                            if (Convert.ToDecimal(strAllowaceAmt) != 0)
                            {
                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                sumtable.AddCell(new PdfPCell(new Phrase("Special Allowance", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                                sumtable.AddCell(new PdfPCell(new Phrase(strAllowaceAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                                sumtable.AddCell(new PdfPCell(new Phrase(strAllowaceAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            }
                            if (NormlOT != 0)
                            {
                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                sumtable.AddCell(new PdfPCell(new Phrase("Normal OT @" + NormalOvertmRatePrHr.ToString() + "/hr", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 2, BorderColor = BaseColor.GRAY });
                                sumtable.AddCell(new PdfPCell(new Phrase(NormlOT.ToString(), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                                sumtable.AddCell(new PdfPCell(new Phrase(strAllowovertimeAmount, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            }

                            if (HoldayOt != 0)
                            {
                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                sumtable.AddCell(new PdfPCell(new Phrase("Holiday OT @" + HolidayOvertmRatePrHr.ToString() + "/hr", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 2, BorderColor = BaseColor.GRAY });
                                sumtable.AddCell(new PdfPCell(new Phrase(HoldayOt.ToString(), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                                sumtable.AddCell(new PdfPCell(new Phrase(strAllowovertimeAmount, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            }
                            //Manual Addition or deduction
                            for (int j = 0; j < dtOtherAddDedDetls.Rows.Count; j++)
                            {
                                if (dtOtherAddDedDetls.Rows[j]["PAYRL_MODE"].ToString() == "1")
                                {
                                    string strTotOthrAddAmt = objBusiness.AddCommasForNumberSeperation(Convert.ToDecimal(dtOtherAddDedDetls.Rows[j]["PAYINFDT_AMOUNT"]).ToString("0.00"), objEntityCommon);
                                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                    sumtable.AddCell(new PdfPCell(new Phrase(dtOtherAddDedDetls.Rows[j]["PAYRL_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                                    sumtable.AddCell(new PdfPCell(new Phrase(strTotOthrAddAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                                    sumtable.AddCell(new PdfPCell(new Phrase(strTotOthrAddAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                }
                            }

                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            sumtable.AddCell(new PdfPCell(new Phrase("Total Basic and Allowances", FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(strTotalBasicAllow, FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            sumtable.AddCell(new PdfPCell(new Phrase("Deductions", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = BaseColor.LIGHT_GRAY, Colspan = 4, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            sumtable.AddCell(new PdfPCell(new Phrase("Deduction Types", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BackgroundColor = BaseColor.LIGHT_GRAY, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = BaseColor.LIGHT_GRAY, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                            if (Convert.ToDecimal(strDeductnAmt) != 0)
                            {
                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                sumtable.AddCell(new PdfPCell(new Phrase("Special Deductions", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                                sumtable.AddCell(new PdfPCell(new Phrase(strDeductnAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            }

                            if (Convert.ToDecimal(strDeductnInstlmtAmount) != 0)
                            {
                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                sumtable.AddCell(new PdfPCell(new Phrase("Installment Deductions", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                                sumtable.AddCell(new PdfPCell(new Phrase(strDeductnInstlmtAmount, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            }

                            if (Convert.ToDecimal(strMessAmnt) != 0)
                            {
                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                sumtable.AddCell(new PdfPCell(new Phrase("Mess Deductions", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                                sumtable.AddCell(new PdfPCell(new Phrase(strMessAmnt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            }

                            if (Convert.ToDecimal(strLvArrearAmnt) != 0)
                            {
                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                sumtable.AddCell(new PdfPCell(new Phrase("Leave Arrear Deductions", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                                sumtable.AddCell(new PdfPCell(new Phrase(strLvArrearAmnt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            }
                            for (int J = 0; J < dtOtherAddDedDetls.Rows.Count; J++)
                            {
                                if (dtOtherAddDedDetls.Rows[J]["PAYRL_MODE"].ToString() == "2")
                                {
                                    string strTotOthrDeductAmt = objBusiness.AddCommasForNumberSeperation(Convert.ToDecimal(dtOtherAddDedDetls.Rows[J]["PAYINFDT_AMOUNT"]).ToString("0.00"), objEntityCommon);
                                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                    sumtable.AddCell(new PdfPCell(new Phrase(dtOtherAddDedDetls.Rows[J]["PAYRL_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                                    sumtable.AddCell(new PdfPCell(new Phrase(strTotOthrDeductAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                }
                            }
                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            sumtable.AddCell(new PdfPCell(new Phrase("Total Deductions", FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(strTotalDedctn, FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            sumtable.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = BaseColor.LIGHT_GRAY, Colspan = 4, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            sumtable.AddCell(new PdfPCell(new Phrase("Net Salary", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(strnetsalary + " " + dtSalPrssDtls.Rows[0]["CRNCMST_ABBRV"].ToString(), FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                            int TableSize = sumtable.Size;

                            if (TableSize > 12)
                            {
                                document.NewPage();
                                PdfPTable headtableNewPag = new PdfPTable(2);
                                //lbr -1 year 11 
                                headtableNewPag.AddCell(new PdfPCell(new Phrase("LABOR CARD", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                                if (strCompanyLogo != "")
                                {
                                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strCompanyLogo));
                                    image.ScalePercent(PdfPCell.ALIGN_CENTER);
                                    image.ScaleToFit(60f, 40f);
                                    headtableNewPag.AddCell(new PdfPCell(image) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                                }
                                else
                                {
                                    headtableNewPag.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                                }
                                headtableNewPag.AddCell(new PdfPCell(new Phrase(strCompanyName, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                                headtableNewPag.AddCell(new PdfPCell(new Phrase(strAddress, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                                float[] headersHeadingNewPag = { 80, 20 };
                                headtableNewPag.SetWidths(headersHeadingNewPag);
                                headtableNewPag.WidthPercentage = 100;
                                document.Add(headtableNewPag);

                                PdfPTable tableLineNewPag = new PdfPTable(1);
                                float[] tableLineBodyNewPag = { 100 };
                                tableLineNewPag.SetWidths(tableLineBodyNewPag);
                                tableLineNewPag.WidthPercentage = 100;
                                tableLineNewPag.TotalWidth = 650F;
                                tableLineNewPag.AddCell(new PdfPCell(new Phrase("________________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                                tableLineNewPag.WriteSelectedRows(0, -1, 0, document.PageSize.GetTop(55), writer.DirectContent);

                                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 25, BaseColor.BLACK))));
                                //nexta                           
                            }


                            document.Add(sumtable);
                            float posSamp2 = writer.GetVerticalPosition(false);

                            float pos1 = writer.GetVerticalPosition(false);
                            PdfPTable endtable = new PdfPTable(6);
                            float[] endBody = { 25, 10, 25, 10, 25, 5 };
                            endtable.SetWidths(endBody);
                            endtable.WidthPercentage = 100;
                            endtable.TotalWidth = document.PageSize.Width - 80f;

                            endtable.AddCell(new PdfPCell(new Phrase("FINANCE MANAGER", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                            endtable.AddCell(new PdfPCell(new Phrase("GENERAL MANAGER", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                            endtable.AddCell(new PdfPCell(new Phrase("RECEIVER'S SIGNATURE", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });

                            if (pos1 > 70)
                            {
                                endtable.WriteSelectedRows(0, -1, 50, 65, writer.DirectContent);
                            }
                            else
                            {
                                document.NewPage();
                                endtable.WriteSelectedRows(0, -1, 50, 65, writer.DirectContent);
                            }
                        }
                        else //payslip
                        {
                            cls_Entity_Monthly_Salary_Process objEntPrcss = new cls_Entity_Monthly_Salary_Process();
                            cls_Entity_Monthly_Salary_Process objMonthlySalaryProcess = new cls_Entity_Monthly_Salary_Process();
                            DataTable dtEmp_list = objBuss.ReadEmp_List_For_PaySlip_Print(objEntPrcss);

                            objMonthlySalaryProcess.Month = OBJ.Month;
                            objMonthlySalaryProcess.Year = OBJ.Year;

                            OBJ.Month = objMonthlySalaryProcess.Month;
                            OBJ.Year = objMonthlySalaryProcess.Year;
                            //DataTable dtSalPrssDtls = objBuss.ReadSalaryProssDtlsById(objEntPrcss);
                            int NofDaysMonth = DateTime.DaysInMonth(objMonthlySalaryProcess.Year, objMonthlySalaryProcess.Month);

                            string strMonthstart = new DateTime(objMonthlySalaryProcess.Year, objMonthlySalaryProcess.Month, 1).ToString("dd-MM-yyyy");
                            string strMonthEnd = new DateTime(objMonthlySalaryProcess.Year, objMonthlySalaryProcess.Month, NofDaysMonth).ToString("dd-MM-yyyy");
                            DateTime dMonthstart = objCommon.textToDateTime(strMonthstart);
                            DateTime dMonthEnd = objCommon.textToDateTime(strMonthEnd);



                            objEntPrcss.date = dMonthstart;
                            objEntPrcss.CurrentDate = dMonthEnd;
                            string MonthName = dMonthstart.ToString("MMMM");
                            objEntPrcss.Employee = objMonthlySalaryProcess.Employee;
                            objEntPrcss.Month = objMonthlySalaryProcess.Month;
                            objEntPrcss.Year = objMonthlySalaryProcess.Year;
                            objEntPrcss.date = dMonthstart;

                            //OBJ.date = dMonthstart;
                            //OBJ.CurrentDate = dMonthEnd;
                            //string MonthName = dMonthstart.ToString("MMMM");
                            //OBJ.Employee = objMonthlySalaryProcess.Employee;
                            //OBJ.Month = objMonthlySalaryProcess.Month;
                            //OBJ.Year = objMonthlySalaryProcess.Year;
                            //OBJ.date = dMonthstart;
                            PdfPTable headtable = new PdfPTable(1);

                            string strImageLoc = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CORPORATE_LOGOS) + "quotation-header.png";
                            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLoc));
                            image.ScalePercent(PdfPCell.ALIGN_CENTER);
                            image.ScaleToFit(600f, 100f);

                            headtable.AddCell(new PdfPCell(image) { Border = 0, PaddingBottom = 20, HorizontalAlignment = Element.ALIGN_CENTER, });
                            document.Add(headtable);


                            PdfPTable headLayout = new PdfPTable(1);
                            headLayout.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                            headLayout.AddCell(new PdfPCell(new Phrase("Payslip for the Month of " + MonthName + ", " + objEntPrcss.Year, FontFactory.GetFont("Times New Roman", 14, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
                            headLayout.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Times New Roman", 30, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                            document.Add(headLayout);

                            int AttendncCount = 0;

                            for (int intRowBodyCount = 1; intRowBodyCount <= dtEmp_list.Rows.Count; intRowBodyCount++)
                            {
                                if (dtEmp_list.Rows[0]["ATTENDANCE"].ToString() == "P")
                                {
                                    AttendncCount++;
                                }
                            }

                            string basicAmt = "", SalaryProcssdBasicAmt = "", AllowaceAmt = "", AllowovertimeAmount = "", DedctionAmt = "", DedctionInstalmntAmnt = "", Total = "", OT_Hours = "", MessAmnt = "", LvArrearAmnt = "", OtherAddAmnt = "", OtherDeductAmnt = "";
                            Decimal TotalBasicAllow = 0, TotalDedctn = 0, netsalary = 0, AllowovertimeAmount1 = 0, AllowaceAmt1 = 0, basicAmt1 = 0, decSalaryProcssdBasicAmt = 0, spclDedctionAmt = 0, instlmntDedctionAmt = 0, decOtherAddAmnt = 0, decOtherDeductAmnt = 0;
                            Decimal decMessAmnt = 0, decLvArrearAmnt = 0, decPrevArrAmnt = 0;
                            if (dtSalPrssDtls.Rows.Count > 0)
                            {
                                basicAmt = dtSalPrssDtls.Rows[0]["SLRY_BASIC_PAY"].ToString();
                                SalaryProcssdBasicAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_PRSD_BASICPAY"].ToString();
                                AllowaceAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_ALLOW_AMT"].ToString();
                                AllowovertimeAmount = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_OVERTIME_ALLOW_AMT"].ToString();
                                DedctionAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_DEDCTN_AMT"].ToString();
                                DedctionInstalmntAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_INSTLMNT_DEDCN_AMT"].ToString();
                                Total = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_TOTAL_AMT"].ToString();
                                if (dtSalPrssDtls.Rows[0]["SLPRCDMNTH_TOTAL_AMT"].ToString() != "")
                                {
                                    OT_Hours = dtSalPrssDtls.Rows[0]["EMDLHRDTL_OT"].ToString();
                                }
                                MessAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_MESS_DEDCTN_AMT"].ToString();
                                LvArrearAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_LEV_ARREAR_AMT"].ToString();

                                OtherAddAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_OTHR_ADTION_AMT"].ToString();
                                OtherDeductAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_OTHR_DEDCTN_AMT"].ToString();
                                decPrevArrAmnt = Convert.ToDecimal(dtSalPrssDtls.Rows[0]["SLPRCDMNTH_PREV_MNTH_ARRE_AMNT"].ToString());
                            }
                            if (basicAmt != "")
                            {
                                basicAmt1 = Convert.ToDecimal(basicAmt);
                                //  TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(basicAmt);
                            }

                            if (SalaryProcssdBasicAmt != "")
                            {
                                decSalaryProcssdBasicAmt = Convert.ToDecimal(SalaryProcssdBasicAmt);
                                TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(SalaryProcssdBasicAmt);

                            }

                            if (AllowaceAmt != "")
                            {
                                AllowaceAmt1 = Convert.ToDecimal(AllowaceAmt);
                                TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(AllowaceAmt);
                            }
                            if (AllowovertimeAmount != "")
                            {
                                AllowovertimeAmount1 = Convert.ToDecimal(AllowovertimeAmount);
                                TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(AllowovertimeAmount);
                            }
                            if (OtherAddAmnt != "")
                            {
                                decOtherAddAmnt = Convert.ToDecimal(OtherAddAmnt);
                                TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(OtherAddAmnt);
                            }
                            if (decPrevArrAmnt > 0)
                            {
                                TotalBasicAllow = TotalBasicAllow + decPrevArrAmnt;
                            }
                            if (DedctionAmt != "")
                            {
                                spclDedctionAmt = Convert.ToDecimal(DedctionAmt);
                                TotalDedctn = TotalDedctn + Convert.ToDecimal(DedctionAmt);
                            }
                            if (DedctionInstalmntAmnt != "")
                            {
                                instlmntDedctionAmt = Convert.ToDecimal(DedctionInstalmntAmnt);
                                TotalDedctn = TotalDedctn + Convert.ToDecimal(DedctionInstalmntAmnt);
                            }
                            if (MessAmnt != "")
                            {
                                decMessAmnt = Convert.ToDecimal(MessAmnt);
                                TotalDedctn = TotalDedctn + Convert.ToDecimal(decMessAmnt);
                            }
                            if (LvArrearAmnt != "")
                            {
                                decLvArrearAmnt = Convert.ToDecimal(LvArrearAmnt);
                                TotalDedctn = TotalDedctn + Convert.ToDecimal(decLvArrearAmnt);
                            }
                            if (OtherDeductAmnt != "")
                            {
                                decOtherDeductAmnt = Convert.ToDecimal(OtherDeductAmnt);
                                TotalDedctn = TotalDedctn + Convert.ToDecimal(OtherDeductAmnt);
                            }
                            if (decPrevArrAmnt < 0)
                            {
                                TotalDedctn = TotalDedctn + (decPrevArrAmnt * -1);
                            }
                            if (Total != "")
                            {
                                netsalary = Convert.ToDecimal(Total);
                            }

                            //if (indvlRound == "0")
                            //{
                            //     roundInd = 2;
                            // }
                            string strbasicAmt = objBusiness.AddCommasForNumberSeperation(basicAmt1.ToString("0.00"), objEntityCommon);
                            string strSalaryProcssdBasicAmt = objBusiness.AddCommasForNumberSeperation(decSalaryProcssdBasicAmt.ToString("0.00"), objEntityCommon);
                            string strAllowaceAmt = objBusiness.AddCommasForNumberSeperation(AllowaceAmt1.ToString("0.00"), objEntityCommon);
                            string strAllowovertimeAmount = objBusiness.AddCommasForNumberSeperation(AllowovertimeAmount1.ToString("0.00"), objEntityCommon);
                            string strTotalBasicAllow = objBusiness.AddCommasForNumberSeperation(TotalBasicAllow.ToString("0.00"), objEntityCommon);
                            string strTotalDedctn = objBusiness.AddCommasForNumberSeperation(TotalDedctn.ToString("0.00"), objEntityCommon);
                            string strspclDedctionAmt = objBusiness.AddCommasForNumberSeperation(spclDedctionAmt.ToString("0.00"), objEntityCommon);
                            string strinstlmntDedctionAmt = objBusiness.AddCommasForNumberSeperation(instlmntDedctionAmt.ToString("0.00"), objEntityCommon);
                            string strMessAmnt = objBusiness.AddCommasForNumberSeperation(decMessAmnt.ToString("0.00"), objEntityCommon);
                            string strLvArrearAmnt = objBusiness.AddCommasForNumberSeperation(decLvArrearAmnt.ToString("0.00"), objEntityCommon);
                            string strnetsalary = objBusiness.AddCommasForNumberSeperation(netsalary.ToString("0.00"), objEntityCommon);
                            string strOtherAddAmt = objBusiness.AddCommasForNumberSeperation(decOtherAddAmnt.ToString("0.00"), objEntityCommon);
                            string strOtherDeductAmt = objBusiness.AddCommasForNumberSeperation(decOtherDeductAmnt.ToString("0.00"), objEntityCommon);
                            string strPrevArrAmnt = objBusiness.AddCommasForNumberSeperation(decPrevArrAmnt.ToString("0.00"), objEntityCommon);

                            PdfPTable tableheadlayout = new PdfPTable(5);
                            float[] tableheadlayoutBody = { 15, 43, 7, 23, 12 };
                            tableheadlayout.SetWidths(tableheadlayoutBody);
                            tableheadlayout.WidthPercentage = 100;

                            tableheadlayout.AddCell(new PdfPCell(new Phrase("Employee #", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            //tableheadlayout.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["EID"].ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tableheadlayout.AddCell(new PdfPCell(new Phrase(dtSal.Rows[i]["EID"].ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });


                            tableheadlayout.AddCell(new PdfPCell(new Phrase("Name", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            //tableheadlayout.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["EMPLOYEE"].ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tableheadlayout.AddCell(new PdfPCell(new Phrase(dtSal.Rows[i]["EMPLOYEE"].ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });

                            tableheadlayout.AddCell(new PdfPCell(new Phrase("Department", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            //tableheadlayout.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["CPRDEPT_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tableheadlayout.AddCell(new PdfPCell(new Phrase(dtSal.Rows[i]["CPRDEPT_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });

                            tableheadlayout.AddCell(new PdfPCell(new Phrase("Designation", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tableheadlayout.AddCell(new PdfPCell(new Phrase(dtSal.Rows[i]["DESIGNATION"].ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tableheadlayout.AddCell(new PdfPCell(new Phrase("Eligible Days", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tableheadlayout.AddCell(new PdfPCell(new Phrase(NofDaysMonth.ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });

                            tableheadlayout.AddCell(new PdfPCell(new Phrase("Job Title", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tableheadlayout.AddCell(new PdfPCell(new Phrase(dtSal.Rows[i]["JOBRL_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tableheadlayout.AddCell(new PdfPCell(new Phrase("Present Days", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tableheadlayout.AddCell(new PdfPCell(new Phrase(AttendncCount.ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });

                            document.Add(tableheadlayout);

                            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 20, BaseColor.BLACK))));
                            //   document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 20, BaseColor.BLACK))));

                            PdfPTable tablelayout = new PdfPTable(7);
                            float[] tablelayoutBody = { 22, 13, 8, 13, 7, 23, 12 };
                            tablelayout.SetWidths(tablelayoutBody);
                            tablelayout.WidthPercentage = 100;

                            tablelayout.AddCell(new PdfPCell(new Phrase("Basic and Allowances", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6, Colspan = 4, BackgroundColor = BaseColor.LIGHT_GRAY });
                            tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase("Deduction", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6, Colspan = 2, BackgroundColor = BaseColor.LIGHT_GRAY });

                            tablelayout.AddCell(new PdfPCell(new Phrase("Description", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase("Hours", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase("Earned", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6, Colspan = 2 });

                            tablelayout.AddCell(new PdfPCell(new Phrase("Basic Pay", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase(strbasicAmt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase(strSalaryProcssdBasicAmt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase("Special Deduction", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase(strspclDedctionAmt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });

                            tablelayout.AddCell(new PdfPCell(new Phrase("Special Allowance", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase(strAllowaceAmt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase(strAllowaceAmt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase("Installment Deduction", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase(strinstlmntDedctionAmt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });

                            tablelayout.AddCell(new PdfPCell(new Phrase("Over Time Allowance", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase(strAllowovertimeAmount, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase(OT_Hours, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase(strAllowovertimeAmount, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase("Mess Deduction", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase(strMessAmnt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });

                            tablelayout.AddCell(new PdfPCell(new Phrase("Other Addition", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase(strOtherAddAmt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase(strOtherAddAmt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase("Other Deduction", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tablelayout.AddCell(new PdfPCell(new Phrase(strOtherDeductAmt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });


                            if (decPrevArrAmnt >= 0)
                            {
                                tablelayout.AddCell(new PdfPCell(new Phrase("Arrear Amount", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                tablelayout.AddCell(new PdfPCell(new Phrase(strPrevArrAmnt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                tablelayout.AddCell(new PdfPCell(new Phrase(strPrevArrAmnt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                tablelayout.AddCell(new PdfPCell(new Phrase("Leave Arrear Deduction", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                tablelayout.AddCell(new PdfPCell(new Phrase(strLvArrearAmnt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });


                                tablelayout.AddCell(new PdfPCell(new Phrase("Total Basic & Allowances", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6, Colspan = 3 });
                                tablelayout.AddCell(new PdfPCell(new Phrase(strTotalBasicAllow, FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                                tablelayout.AddCell(new PdfPCell(new Phrase("Total Deduction", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                tablelayout.AddCell(new PdfPCell(new Phrase(strTotalDedctn, FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });

                            }
                            else
                            {


                                tablelayout.AddCell(new PdfPCell(new Phrase("Total Basic & Allowances", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6, Colspan = 3 });
                                tablelayout.AddCell(new PdfPCell(new Phrase(strTotalBasicAllow, FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                tablelayout.AddCell(new PdfPCell(new Phrase("Leave Arrear Deduction", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                tablelayout.AddCell(new PdfPCell(new Phrase(strLvArrearAmnt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });


                                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                tablelayout.AddCell(new PdfPCell(new Phrase("Arrear Amount", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                tablelayout.AddCell(new PdfPCell(new Phrase(strPrevArrAmnt.Replace("-", string.Empty), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });



                                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                tablelayout.AddCell(new PdfPCell(new Phrase("Total Deduction", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                tablelayout.AddCell(new PdfPCell(new Phrase(strTotalDedctn, FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                            }
                            document.Add(tablelayout);

                            PdfPTable tablelayoutnet = new PdfPTable(3);
                            float[] tablenetlayoutBody = { 68, 23, 12 };
                            tablelayoutnet.SetWidths(tablenetlayoutBody);
                            tablelayoutnet.WidthPercentage = 100;

                            //tablelayoutnet.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6, Colspan = 3 });
                            tablelayoutnet.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6, Colspan = 3 });

                            tablelayoutnet.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                            tablelayoutnet.AddCell(new PdfPCell(new Phrase("Net Salary", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                            tablelayoutnet.AddCell(new PdfPCell(new Phrase(strnetsalary, FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6, });

                            document.Add(tablelayoutnet);

                            PdfPTable endtable = new PdfPTable(6);
                            float[] endBody = { 25, 10, 25, 10, 25, 5 };
                            endtable.SetWidths(endBody);
                            endtable.WidthPercentage = 100;

                            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6, Colspan = 6 });
                            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6, Colspan = 6 });

                            endtable.AddCell(new PdfPCell(new Phrase("Prepared By", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                            endtable.AddCell(new PdfPCell(new Phrase("Checked By", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                            endtable.AddCell(new PdfPCell(new Phrase("Received By", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });

                            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthTop = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthTop = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthTop = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });

                            document.Add(endtable);

                            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 40, BaseColor.BLACK))));


                            PdfPTable footrtable = new PdfPTable(2);
                            float[] headersBodyfootr = { 0, 100 };
                            footrtable.SetWidths(headersBodyfootr);
                            footrtable.WidthPercentage = 100;

                            string strImageLocFooter = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CORPORATE_LOGOS) + "quotation-footer.png";
                            iTextSharp.text.Image imageFootr = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLocFooter));
                            imageFootr.ScalePercent(PdfPCell.ALIGN_LEFT);
                            imageFootr.ScaleToFit(520f, 60f);

                            footrtable.AddCell(new PdfPCell(new Phrase(" ")) { Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_LEFT });
                            footrtable.AddCell(new PdfPCell(imageFootr) { Border = 0, PaddingBottom = 10, HorizontalAlignment = Element.ALIGN_LEFT });
                            document.Add(footrtable);
                        }

                    }//if true

                }

                document.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                Response.Clear();
                Response.ContentType = "application/pdf";
                if (ddlEmpTyp.SelectedItem.Value == "1")
                {
                    Response.AddHeader("Content-Disposition", "attachment; filename=LabourCard_" + strid + ".pdf");
                }
                else
                {
                    Response.AddHeader("Content-Disposition", "attachment; filename=Payslip_" + strid + ".pdf");
                }
                Response.Buffer = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();
            }
        }

        PageRedirect();
        //ScriptManager.RegisterStartupScript(this, GetType(), "PrintClick1", "PrintClick1();", true);


    }

    public void PageRedirect()
    {
        Response.Redirect("hcm_Bulk_LabourCard_Print.aspx");
    }


    protected void btnmail_Click(object sender, EventArgs e)
    {


        cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
        cls_Business_Bulk_LabourCard_Print objBussBulkPrint = new cls_Business_Bulk_LabourCard_Print();
        cls_Entity_Bulk_LabourCard_Print OBJBulk = new cls_Entity_Bulk_LabourCard_Print();
        cls_Business_Bulk_LabourCard_Print objBusinessLabourCard = new cls_Business_Bulk_LabourCard_Print();
        cls_Entity_Monthly_Salary_Process OBJ = new cls_Entity_Monthly_Salary_Process();
        List<classEntityToMailAddress> objEntityToMailAddressList = new List<classEntityToMailAddress>();
        List<clsEntityMailCcBCc> objEntityMailCcBCcList = new List<clsEntityMailCcBCc>();
        clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
        clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        int intCorpId = 0, intOrgId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        clsCommonLibrary objCommon = new clsCommonLibrary();

        string RowCount = HiddenRowCount.Value;
        string SalaryPrcsdId = hiddenSalaryPrcsdId.Value;
        string PrcssdConfDate = hiddenSlryPrcssdConfDate.Value;
        int PaidFinish = 1;
        OBJ.StffWrkr = Convert.ToInt32(ddlEmpTyp.SelectedItem.Value);

        OBJ.Month = Convert.ToInt32(ddlMonth.SelectedItem.Value);
        OBJ.Year = Convert.ToInt32(ddlyear.SelectedItem.Value);
        OBJ.CorpOffice = intCorpId;
        OBJ.Orgid = intOrgId;


        if (hiddenAllEmpid.Value != "")
        {
            string[] EmpId = hiddenAllEmpid.Value.Split(',');
            string strid = (OBJ.Year + "_" + OBJ.Month + "_" + OBJ.Dep).ToString();
            string[] tokens = hiddenAllEmpid.Value.Split(',');
            DataTable dtCorp = objBuss.ReadCorporateAddress(OBJ);
            string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "", strCompanyLogo = "";

            string strTitle = "";
            if (ddlEmpTyp.SelectedItem.Value == "0")
            {
                strTitle = "PAY SLIP";
            }
            strTitle = "LABOR CARD";

            DateTime datetm = DateTime.Now;
            string dat = "<B>Report Date: </B>" + datetm.ToString("R");

            if (dtCorp.Rows.Count > 0)
            {
                strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
                strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
                strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
                strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
                strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
                strCompanyLogo = dtCorp.Rows[0]["CORPRT_ICON"].ToString();
            }
            if (strCompanyLogo != "")
            {
                strCompanyLogo = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit) + strCompanyLogo;
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
            int intmailSendChk = 0;

            try
            {
                string misslist = "";
                for (int i = 0; i < tokens.GetLength(0); i++)
                {
                    if (tokens[0] != null)
                    {
                        int a = Convert.ToInt32(tokens[i]);
                        cls_Entity_Bulk_LabourCard_Print objentityShortList = new cls_Entity_Bulk_LabourCard_Print();
                        objentityShortList.UserId = a;
                        DataTable dtEmailId = objBusinessLabourCard.EmailId(objentityShortList);

                        if (dtEmailId.Rows.Count > 0)
                        {
                            clsEntityLayerUserRegistration objEntityUser = new clsEntityLayerUserRegistration();
                            objEntityUser.UserCrprtId = intCorpId;
                            DataTable dtFromMail = objBusiness.ReadFromMailDetails(objEntityUser);
                            clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
                            objEntityMail.Email_Subject = "LABOUR_CARD";


                            if (ddlEmpTyp.SelectedItem.Value == "0")
                            {
                                objEntityMail.Email_Subject = "PAYSLIP";
                            }


                            objEntityMail.From_Email_Address = dtFromMail.Rows[0]["MLCNFG_EMAIL"].ToString();

                            objEntityMail.Out_Service_Name = dtFromMail.Rows[0]["MLCNFG_OUT_SERVICE_NAME"].ToString();
                            objEntityMail.Out_Port_Number = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_OUT_PORT_NUMBER"]);
                            objEntityMail.SSL_Status = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_SSL_STATUS"]);
                            objEntityMail.Password = dtFromMail.Rows[0]["MLCNFG_PASSWORD"].ToString();

                            string strFromAddrss = dtFromMail.Rows[0]["MLCNFG_EMAIL"].ToString();
                            string strServiceName = dtFromMail.Rows[0]["MLCNFG_OUT_SERVICE_NAME"].ToString();
                            int intPortNo = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_OUT_PORT_NUMBER"]);
                            int intSSlStatus = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_SSL_STATUS"]);
                            string strSslStatus = dtFromMail.Rows[0]["MLCNFG_PASSWORD"].ToString();

                            string empname = dtEmailId.Rows[0]["USR_NAME"].ToString();
                            objEntityMail.D_Date = System.DateTime.Now;
                            //EVM-0024
                            if (dtEmailId.Rows[0]["USR_EMAIL"].ToString() == "" || dtEmailId.Rows[0]["USR_EMAIL"].ToString() == null)
                            {
                                //0039
                                misslist = misslist + dtEmailId.Rows[0]["USR_NAME"].ToString() + ",";
                                //end
                            }
                            

                            objEntityMail.To_Email_Address = dtEmailId.Rows[0]["USR_EMAIL"].ToString();
                            //objEntityMail.To_Email_Address = "donyscaria@volviar.com";

                            if (objEntityMail.From_Email_Address != "" && objEntityMail.To_Email_Address != "")
                            {

                                string Content = "";

                                if (dtEmailId.Rows[0]["USR_NAME"].ToString() != "")
                                {
                                    Content = " Dear " + dtEmailId.Rows[0]["USR_NAME"].ToString() + ",";
                                }
                                else
                                {
                                    Content = " Dear Employee,";
                                }

                                Content += "<br/><br/><br/><b><u>NOTE</u></b>: <i>PLEASE FIND THE ATTACHED APPOINTMENT LETTER</i>";  //EMV0025
                                Content += "<br/><br/><br/><b><u>NOTE</u></b>: <i>This is system generated email. Kindly do not reply to this email address. For any queries/feedback, please email to itsupport@albaalagh.com</i>";
                                Content += "<br/><br/><br/>Best Regards,";
                                //0039
                                if (dtCorp.Rows[0]["CORPRT_NAME"].ToString() != "")
                                {
                                    Content += "<br/><font color=\"#0a409b\"><b>Compzit Administrator</b></font><br/><font color=\"#438df8\">" + dtCorp.Rows[0]["CORPRT_NAME"].ToString() + "</font><br/><font color=\"#438df8\">" + dtCorp.Rows[0]["CORPRT_MOBILE"].ToString() + "<br/> P O Box 5777," + dtCorp.Rows[0]["CORPRT_ADDR1"].ToString() + "-" + dtCorp.Rows[0]["CORPRT_ADDR3"].ToString() + "</font>";
                                }
                                //end
                                objEntityMail.Email_Content = Content;

                                Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);

                                if (ddlEmpTyp.SelectedItem.Value == "1")
                                {
                                    document = new Document(PageSize.LETTER, 15f, 25f, 15f, 45f);
                                }

                                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                                {
                                    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                                    string strImageName = "";
                                    if (ddlEmpTyp.SelectedItem.Value == "1")
                                    {
                                        strImageName = "LabourCard_" + strid + ".pdf";
                                    }
                                    else
                                    {
                                        strImageName = "Payslip_" + strid + ".pdf";
                                    }
                                    string imgpath = "/CustomFiles/PaySlip/";
                                    string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.PAYSLIP_PDF);

                                    string fullPath = System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName;
                                    if ((System.IO.File.Exists(fullPath)))
                                    {
                                        System.IO.File.Delete(fullPath);
                                    }

                                    FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(imgpath) + strImageName, FileMode.Create);
                                    PdfWriter.GetInstance(document, file);
                                    writer.PageEvent = new PDFHeader();
                                    document.Open();

                                    if (true)
                                    {
                                        OBJBulk.MultipleEmpId = objentityShortList.UserId.ToString();
                                        OBJBulk.Month = Convert.ToInt32(ddlMonth.SelectedItem.Value);
                                        OBJBulk.Year = Convert.ToInt32(ddlyear.SelectedItem.Value);
                                        OBJBulk.PaidFinish = 1;
                                        OBJBulk.CorpOffice = intCorpId;
                                        OBJBulk.Orgid = intOrgId;


                                        //Manual Addition
                                        cls_Business_Monthly_Salary_Process objBuss1 = new cls_Business_Monthly_Salary_Process();
                                        cls_Entity_Monthly_Salary_Process objEnt1 = new cls_Entity_Monthly_Salary_Process();
                                        DataTable dt = objBusinessLeavSettlmt.ReadLeaveSettlmt_ById(objEntityLeavSettlmt);

                                        DataTable dtLeavMonth1 = objBuss1.ReadLastDatePrint(objEnt1);
                                        DataTable dtSal = new DataTable();
                                        dtSal = objBussBulkPrint.LoadSalaryPrssPaymentTable(OBJBulk);


                                        for (int k = 0; k < dtSal.Rows.Count; k++)
                                        {
                                            if (k != 0)
                                            {
                                                document.NewPage();
                                            }
                                            int empid = Convert.ToInt32(dtSal.Rows[k]["USR_ID"]);
                                            objEnt1.Employee = empid;
                                            cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
                                            objEnt.Employee = empid;
                                            objEnt.Month = OBJ.Month;
                                            objEnt.Year = OBJ.Year;
                                            DataTable dtSalPrssDtls;
                                            dtSalPrssDtls = objBuss.ReadSalaryProssDtlsById(objEnt);


                                            if (ddlEmpTyp.SelectedItem.Value == "1")//labour card
                                            {

                                                PdfPTable headtable = new PdfPTable(2);
                                                //lbr -1 year 11
                                                headtable.AddCell(new PdfPCell(new Phrase("LABOR CARD", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                                                if (strCompanyLogo != "")
                                                {
                                                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strCompanyLogo));
                                                    image.ScalePercent(PdfPCell.ALIGN_CENTER);
                                                    image.ScaleToFit(60f, 40f);
                                                    headtable.AddCell(new PdfPCell(image) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                                                }
                                                else
                                                {
                                                    headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                                                }
                                                headtable.AddCell(new PdfPCell(new Phrase(strCompanyName, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                                                headtable.AddCell(new PdfPCell(new Phrase(strAddress, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                                                float[] headersHeading = { 80, 20 };
                                                headtable.SetWidths(headersHeading);
                                                headtable.WidthPercentage = 100;
                                                document.Add(headtable);

                                                PdfPTable tableLine = new PdfPTable(1);
                                                float[] tableLineBody = { 100 };
                                                tableLine.SetWidths(tableLineBody);
                                                tableLine.WidthPercentage = 100;
                                                tableLine.TotalWidth = 650F;
                                                tableLine.AddCell(new PdfPCell(new Phrase("________________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                                                tableLine.WriteSelectedRows(0, -1, 0, document.PageSize.GetTop(55), writer.DirectContent);


                                                float pos9 = writer.GetVerticalPosition(false);
                                                PdfPTable tableLayout = new PdfPTable(6);
                                                float[] headersBody = { 19, 19, 14, 16, 16, 16 };
                                                tableLayout.SetWidths(headersBody);
                                                tableLayout.WidthPercentage = 100;

                                                tableLayout.AddCell(new PdfPCell(new Phrase("DATE", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                                                tableLayout.AddCell(new PdfPCell(new Phrase("JOB#", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                                                tableLayout.AddCell(new PdfPCell(new Phrase("STATUS", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                                                tableLayout.AddCell(new PdfPCell(new Phrase("NORMAL HOURS", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                                                tableLayout.AddCell(new PdfPCell(new Phrase("NORMAL OT", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                                                tableLayout.AddCell(new PdfPCell(new Phrase("HOLIDAY OT", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });

                                                int numMonth = DateTime.DaysInMonth(OBJ.Year, OBJ.Month);
                                                string MonthName = "";

                                                decimal NormlOT = 0, HoldayOt = 0;
                                                decimal NormalOvertmRatePrHr = 0, HolidayOvertmRatePrHr = 0;

                                                for (int intRowBodyCount = 1; intRowBodyCount <= numMonth; intRowBodyCount++)
                                                {
                                                    string EmDate = new DateTime(OBJ.Year, OBJ.Month, intRowBodyCount).ToString("dd-MM-yyyy");
                                                    DateTime ddate = objCommon.textToDateTime(EmDate);

                                                    OBJ.date = ddate;
                                                    MonthName = ddate.ToString("MMMM");
                                                    OBJ.Employee = empid;
                                                    OBJ.Month = OBJ.Month;
                                                    OBJ.Year = OBJ.Year;
                                                    DataTable dtEmp_list = objBuss.ReadEmp_List_For_Print(OBJ);

                                                    tableLayout.AddCell(new PdfPCell(new Phrase(ddate.ToString("dd-MM-yyyy"), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                                    if (dtEmp_list.Rows.Count > 0)
                                                    {
                                                        tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["JOBMSTR_TITLE"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                                        tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["ATTENDANCE"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });

                                                        if (dtEmp_list.Rows[0]["ATTENDANCE"].ToString() == "P")
                                                        {
                                                            tableLayout.AddCell(new PdfPCell(new Phrase("8", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                                        }
                                                        else if (dtEmp_list.Rows[0]["ATTENDANCE"].ToString() == "A")
                                                        {
                                                            tableLayout.AddCell(new PdfPCell(new Phrase("0", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                                        }

                                                        foreach (DataRow row in dtEmp_list.Rows)
                                                        {

                                                            if (row["OVRTMCATG_NAME"].ToString() == "NORMAL OT")
                                                            {
                                                                tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                                                NormlOT += Convert.ToDecimal(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString());
                                                                NormalOvertmRatePrHr = Convert.ToDecimal(row["OVRTMCATG_RATE"].ToString());
                                                            }
                                                            else
                                                            {
                                                                tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                                            }
                                                            if (row["OVRTMCATG_NAME"].ToString() == "HOLIDAY OT")
                                                            {
                                                                tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                                                HoldayOt += Convert.ToDecimal(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString());
                                                                HolidayOvertmRatePrHr = Convert.ToDecimal(row["OVRTMCATG_RATE"].ToString());
                                                            }
                                                            else
                                                            {
                                                                tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                                        tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                                        tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                                        tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                                        tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                                    }

                                                }

                                                tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 4, Padding = 2, BorderColor = BaseColor.GRAY });
                                                tableLayout.AddCell(new PdfPCell(new Phrase(NormlOT.ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                                tableLayout.AddCell(new PdfPCell(new Phrase(HoldayOt.ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                                tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 6, Padding = 2 });

                                                PdfPTable pdfBodyTable = new PdfPTable(4);
                                                pdfBodyTable.WidthPercentage = 100;

                                                pdfBodyTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 4, Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                pdfBodyTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 4, Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                                                pdfBodyTable.AddCell(new PdfPCell(new Phrase("EMPLOYEE CODE", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                pdfBodyTable.AddCell(new PdfPCell(new Phrase(dtSalPrssDtls.Rows[0]["USR_CODE"].ToString(), new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                pdfBodyTable.AddCell(new PdfPCell(new Phrase("DESIGNATION", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                pdfBodyTable.AddCell(new PdfPCell(new Phrase(dtSalPrssDtls.Rows[0]["DSGN_NAME"].ToString(), new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });


                                                pdfBodyTable.AddCell(new PdfPCell(new Phrase("MONTH & YEAR", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                pdfBodyTable.AddCell(new PdfPCell(new Phrase(MonthName.ToUpper() + " " + OBJ.Year, new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                pdfBodyTable.AddCell(new PdfPCell(new Phrase("", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 2, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });


                                                pdfBodyTable.AddCell(new PdfPCell(new Phrase("EMPLOYEE NAME", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                pdfBodyTable.AddCell(new PdfPCell(new Phrase(dtSalPrssDtls.Rows[0]["USR_NAME"].ToString(), new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 3, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });

                                                pdfBodyTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 4, Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                if (pos9 > 150)
                                                {
                                                }
                                                else
                                                {
                                                    document.NewPage();
                                                }
                                                document.Add(pdfBodyTable);


                                                float pos8 = writer.GetVerticalPosition(false);
                                                if (pos8 > 150)
                                                {
                                                }
                                                else
                                                {
                                                    document.NewPage();
                                                }

                                                document.Add(tableLayout);

                                                string basicAmt = "", AllowaceAmt = "", AllowovertimeAmount = "", DedctionAmt = "", DedctionInstalmntAmnt = "", Total = "", OT_Hours = "", MessAmnt = "", LvArrearAmnt = "";
                                                Decimal TotalBasicAllow = 0, TotalDedctn = 0, netsalary = 0, AllowovertimeAmount1 = 0, AllowaceAmt1 = 0, basicAmt1 = 0, instlmntDedctionAmt = 0, deductnamt = 0;
                                                Decimal decMessAmnt = 0, decLvArrearAmnt = 0, decCurrMonthBasic = 0;

                                                basicAmt = dtSalPrssDtls.Rows[0]["SLRY_BASIC_PAY"].ToString();
                                                AllowaceAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_ALLOW_AMT"].ToString();
                                                AllowovertimeAmount = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_OVERTIME_ALLOW_AMT"].ToString();
                                                DedctionAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_DEDCTN_AMT"].ToString();
                                                DedctionInstalmntAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_INSTLMNT_DEDCN_AMT"].ToString();
                                                Total = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_TOTAL_AMT"].ToString();

                                                if (dtSalPrssDtls.Rows.Count > 0)
                                                {

                                                    if (dtSalPrssDtls.Rows[0]["SLPRCDMNTH_TOTAL_AMT"].ToString() != "")
                                                    {
                                                        OT_Hours = dtSalPrssDtls.Rows[0]["EMDLHRDTL_OT"].ToString();
                                                    }
                                                    MessAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_MESS_DEDCTN_AMT"].ToString();
                                                    LvArrearAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_LEV_ARREAR_AMT"].ToString();
                                                }

                                                //manual addition
                                                objEnt1.Orgid = objEntityLeavSettlmt.OrgId;
                                                objEnt1.CorpOffice = objEntityLeavSettlmt.CorpId;
                                                objEnt1.Month = OBJ.Month;
                                                objEnt1.Year = OBJ.Year;

                                                DataTable dtOtherAddDedDetls = objBuss1.ReadEmpManualy_Add_Dedn_Dtls(objEnt1);
                                                decimal TotOthrAddAmt = 0, TotOthrDeductAmt = 0;
                                                for (int j = 0; j < dtOtherAddDedDetls.Rows.Count; j++)
                                                {
                                                    if (dtOtherAddDedDetls.Rows[j]["PAYRL_MODE"].ToString() == "1")
                                                    {
                                                        TotOthrAddAmt += Convert.ToDecimal(dtOtherAddDedDetls.Rows[j]["PAYINFDT_AMOUNT"].ToString());
                                                    }
                                                    else if (dtOtherAddDedDetls.Rows[j]["PAYRL_MODE"].ToString() == "2")
                                                    {
                                                        TotOthrDeductAmt += Convert.ToDecimal(dtOtherAddDedDetls.Rows[j]["PAYINFDT_AMOUNT"].ToString());
                                                    }

                                                }
                                                //end




                                                int daysInm = DateTime.DaysInMonth(OBJ.Year, OBJ.Month);
                                                decimal decPerHourSal = Convert.ToDecimal(basicAmt) / daysInm;
                                                if (decPerHourSal > 0)
                                                {
                                                    decPerHourSal = decPerHourSal / 8;
                                                }

                                                decimal NormalOTAmnt = NormlOT * NormalOvertmRatePrHr * decPerHourSal;
                                                decimal HolidayOTAmnt = HoldayOt * HolidayOvertmRatePrHr * decPerHourSal;
                                                decimal TotOvertimeAmnt = NormalOTAmnt + HolidayOTAmnt;

                                                if (basicAmt != "")
                                                {
                                                    basicAmt1 = Convert.ToDecimal(basicAmt);
                                                    TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(basicAmt);
                                                }
                                                if (AllowaceAmt != "")
                                                {
                                                    AllowaceAmt1 = Convert.ToDecimal(AllowaceAmt);
                                                    TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(AllowaceAmt);
                                                }
                                                if (AllowovertimeAmount != "")
                                                {
                                                    AllowovertimeAmount1 = Convert.ToDecimal(AllowovertimeAmount);
                                                    TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(AllowovertimeAmount) + TotOthrAddAmt;

                                                }
                                                if (DedctionAmt != "")
                                                {
                                                    deductnamt = Convert.ToDecimal(DedctionAmt);
                                                    TotalDedctn = TotalDedctn + Convert.ToDecimal(DedctionAmt);
                                                }
                                                if (DedctionInstalmntAmnt != "")
                                                {
                                                    instlmntDedctionAmt = Convert.ToDecimal(DedctionInstalmntAmnt);
                                                    TotalDedctn = TotalDedctn + Convert.ToDecimal(DedctionInstalmntAmnt);
                                                }
                                                if (MessAmnt != "")
                                                {
                                                    decMessAmnt = Convert.ToDecimal(MessAmnt);
                                                    TotalDedctn = TotalDedctn + Convert.ToDecimal(decMessAmnt);
                                                }
                                                if (LvArrearAmnt != "")
                                                {
                                                    decLvArrearAmnt = Convert.ToDecimal(LvArrearAmnt);
                                                    TotalDedctn = TotalDedctn + Convert.ToDecimal(decLvArrearAmnt) + TotOthrDeductAmt;
                                                }
                                                if (Total != "")
                                                {
                                                    //  netsalary = Convert.ToDecimal(Total);
                                                    netsalary = TotalBasicAllow - TotalDedctn;
                                                }



                                                string strbasicAmt = objBusiness.AddCommasForNumberSeperation(basicAmt1.ToString("0.00"), objEntityCommon);
                                                string strAllowaceAmt = objBusiness.AddCommasForNumberSeperation(AllowaceAmt1.ToString("0.00"), objEntityCommon);
                                                string strAllowovertimeAmount = objBusiness.AddCommasForNumberSeperation(AllowovertimeAmount1.ToString("0.00"), objEntityCommon);
                                                string strTotalBasicAllow = objBusiness.AddCommasForNumberSeperation(TotalBasicAllow.ToString("0.00"), objEntityCommon);
                                                string strDeductnAmt = objBusiness.AddCommasForNumberSeperation(deductnamt.ToString("0.00"), objEntityCommon);
                                                string strDeductnInstlmtAmount = objBusiness.AddCommasForNumberSeperation(instlmntDedctionAmt.ToString("0.00"), objEntityCommon);
                                                string strTotalDedctn = objBusiness.AddCommasForNumberSeperation(TotalDedctn.ToString("0.00"), objEntityCommon);
                                                string strnetsalary = objBusiness.AddCommasForNumberSeperation(netsalary.ToString("0.00"), objEntityCommon);
                                                string strMessAmnt = objBusiness.AddCommasForNumberSeperation(decMessAmnt.ToString("0.00"), objEntityCommon);
                                                string strLvArrearAmnt = objBusiness.AddCommasForNumberSeperation(decLvArrearAmnt.ToString("0.00"), objEntityCommon);

                                                string strNormalOTAmnt = objBusiness.AddCommasForNumberSeperation(NormalOTAmnt.ToString("0.00"), objEntityCommon);
                                                string strHolidayOTAmnt = objBusiness.AddCommasForNumberSeperation(HolidayOTAmnt.ToString("0.00"), objEntityCommon);

                                                float pos4 = writer.GetVerticalPosition(false);
                                                PdfPTable sumtable = new PdfPTable(6);
                                                float[] footrsBody = { 14, 28, 16, 13, 15, 14 };
                                                sumtable.SetWidths(footrsBody);
                                                sumtable.WidthPercentage = 100;

                                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                sumtable.AddCell(new PdfPCell(new Phrase("Basic and Allowances", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = BaseColor.LIGHT_GRAY, Colspan = 4, BorderColor = BaseColor.GRAY });
                                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                sumtable.AddCell(new PdfPCell(new Phrase("Description", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                                                sumtable.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                                                sumtable.AddCell(new PdfPCell(new Phrase("Days/Hrs", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                                                sumtable.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                sumtable.AddCell(new PdfPCell(new Phrase("Basic Pay", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                sumtable.AddCell(new PdfPCell(new Phrase(strbasicAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                sumtable.AddCell(new PdfPCell(new Phrase(numMonth.ToString(), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                sumtable.AddCell(new PdfPCell(new Phrase(strbasicAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                                                if (Convert.ToDecimal(strAllowaceAmt) != 0)
                                                {
                                                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                    sumtable.AddCell(new PdfPCell(new Phrase("Special Allowance", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                    sumtable.AddCell(new PdfPCell(new Phrase(strAllowaceAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                    sumtable.AddCell(new PdfPCell(new Phrase(strAllowaceAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                }
                                                if (NormlOT != 0)
                                                {
                                                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                    sumtable.AddCell(new PdfPCell(new Phrase("Normal OT @" + NormalOvertmRatePrHr.ToString() + "/hr", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 2, BorderColor = BaseColor.GRAY });
                                                    sumtable.AddCell(new PdfPCell(new Phrase(NormlOT.ToString(), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                    sumtable.AddCell(new PdfPCell(new Phrase(strAllowovertimeAmount, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                }

                                                if (HoldayOt != 0)
                                                {
                                                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                    sumtable.AddCell(new PdfPCell(new Phrase("Holiday OT @" + HolidayOvertmRatePrHr.ToString() + "/hr", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 2, BorderColor = BaseColor.GRAY });
                                                    sumtable.AddCell(new PdfPCell(new Phrase(HoldayOt.ToString(), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                    sumtable.AddCell(new PdfPCell(new Phrase(strAllowovertimeAmount, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                }
                                                //Manual Addition or deduction
                                                for (int j = 0; j < dtOtherAddDedDetls.Rows.Count; j++)
                                                {
                                                    if (dtOtherAddDedDetls.Rows[j]["PAYRL_MODE"].ToString() == "1")
                                                    {
                                                        string strTotOthrAddAmt = objBusiness.AddCommasForNumberSeperation(Convert.ToDecimal(dtOtherAddDedDetls.Rows[j]["PAYINFDT_AMOUNT"]).ToString("0.00"), objEntityCommon);
                                                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                        sumtable.AddCell(new PdfPCell(new Phrase(dtOtherAddDedDetls.Rows[j]["PAYRL_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                        sumtable.AddCell(new PdfPCell(new Phrase(strTotOthrAddAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                        sumtable.AddCell(new PdfPCell(new Phrase(strTotOthrAddAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                    }
                                                }

                                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                sumtable.AddCell(new PdfPCell(new Phrase("Total Basic and Allowances", FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                                                sumtable.AddCell(new PdfPCell(new Phrase(strTotalBasicAllow, FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                sumtable.AddCell(new PdfPCell(new Phrase("Deductions", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = BaseColor.LIGHT_GRAY, Colspan = 4, BorderColor = BaseColor.GRAY });
                                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                sumtable.AddCell(new PdfPCell(new Phrase("Deduction Types", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BackgroundColor = BaseColor.LIGHT_GRAY, BorderColor = BaseColor.GRAY });
                                                sumtable.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = BaseColor.LIGHT_GRAY, BorderColor = BaseColor.GRAY });
                                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                                                if (Convert.ToDecimal(strDeductnAmt) != 0)
                                                {
                                                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                    sumtable.AddCell(new PdfPCell(new Phrase("Special Deductions", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                                                    sumtable.AddCell(new PdfPCell(new Phrase(strDeductnAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                }

                                                if (Convert.ToDecimal(strDeductnInstlmtAmount) != 0)
                                                {
                                                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                    sumtable.AddCell(new PdfPCell(new Phrase("Installment Deductions", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                                                    sumtable.AddCell(new PdfPCell(new Phrase(strDeductnInstlmtAmount, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                }

                                                if (Convert.ToDecimal(strMessAmnt) != 0)
                                                {
                                                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                    sumtable.AddCell(new PdfPCell(new Phrase("Mess Deductions", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                                                    sumtable.AddCell(new PdfPCell(new Phrase(strMessAmnt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                }

                                                if (Convert.ToDecimal(strLvArrearAmnt) != 0)
                                                {
                                                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                    sumtable.AddCell(new PdfPCell(new Phrase("Leave Arrear Deductions", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                                                    sumtable.AddCell(new PdfPCell(new Phrase(strLvArrearAmnt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                }
                                                for (int J = 0; J < dtOtherAddDedDetls.Rows.Count; J++)
                                                {
                                                    if (dtOtherAddDedDetls.Rows[J]["PAYRL_MODE"].ToString() == "2")
                                                    {
                                                        string strTotOthrDeductAmt = objBusiness.AddCommasForNumberSeperation(Convert.ToDecimal(dtOtherAddDedDetls.Rows[J]["PAYINFDT_AMOUNT"]).ToString("0.00"), objEntityCommon);
                                                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                        sumtable.AddCell(new PdfPCell(new Phrase(dtOtherAddDedDetls.Rows[J]["PAYRL_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                                                        sumtable.AddCell(new PdfPCell(new Phrase(strTotOthrDeductAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                    }
                                                }
                                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                sumtable.AddCell(new PdfPCell(new Phrase("Total Deductions", FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                                                sumtable.AddCell(new PdfPCell(new Phrase(strTotalDedctn, FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                sumtable.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = BaseColor.LIGHT_GRAY, Colspan = 4, BorderColor = BaseColor.GRAY });
                                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                                                sumtable.AddCell(new PdfPCell(new Phrase("Net Salary", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                                                sumtable.AddCell(new PdfPCell(new Phrase(strnetsalary + " " + dtSalPrssDtls.Rows[0]["CRNCMST_ABBRV"].ToString(), FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                                                int TableSize = sumtable.Size;

                                                if (TableSize > 12)
                                                {
                                                    document.NewPage();
                                                    PdfPTable headtableNewPag = new PdfPTable(2);
                                                    //lbr -1 year 11 
                                                    headtableNewPag.AddCell(new PdfPCell(new Phrase("LABOR CARD", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                                                    if (strCompanyLogo != "")
                                                    {
                                                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strCompanyLogo));
                                                        image.ScalePercent(PdfPCell.ALIGN_CENTER);
                                                        image.ScaleToFit(60f, 40f);
                                                        headtableNewPag.AddCell(new PdfPCell(image) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                                                    }
                                                    else
                                                    {
                                                        headtableNewPag.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                                                    }
                                                    headtableNewPag.AddCell(new PdfPCell(new Phrase(strCompanyName, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                                                    headtableNewPag.AddCell(new PdfPCell(new Phrase(strAddress, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                                                    float[] headersHeadingNewPag = { 80, 20 };
                                                    headtableNewPag.SetWidths(headersHeadingNewPag);
                                                    headtableNewPag.WidthPercentage = 100;
                                                    document.Add(headtableNewPag);

                                                    PdfPTable tableLineNewPag = new PdfPTable(1);
                                                    float[] tableLineBodyNewPag = { 100 };
                                                    tableLineNewPag.SetWidths(tableLineBodyNewPag);
                                                    tableLineNewPag.WidthPercentage = 100;
                                                    tableLineNewPag.TotalWidth = 650F;
                                                    tableLineNewPag.AddCell(new PdfPCell(new Phrase("________________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                                                    tableLineNewPag.WriteSelectedRows(0, -1, 0, document.PageSize.GetTop(55), writer.DirectContent);

                                                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 25, BaseColor.BLACK))));
                                                    //nexta                           
                                                }


                                                document.Add(sumtable);
                                                float posSamp2 = writer.GetVerticalPosition(false);

                                                float pos1 = writer.GetVerticalPosition(false);
                                                PdfPTable endtable = new PdfPTable(6);
                                                float[] endBody = { 25, 10, 25, 10, 25, 5 };
                                                endtable.SetWidths(endBody);
                                                endtable.WidthPercentage = 100;
                                                endtable.TotalWidth = document.PageSize.Width - 80f;

                                                endtable.AddCell(new PdfPCell(new Phrase("FINANCE MANAGER", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                                                endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                                                endtable.AddCell(new PdfPCell(new Phrase("GENERAL MANAGER", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                                                endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                                                endtable.AddCell(new PdfPCell(new Phrase("RECEIVER'S SIGNATURE", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                                                endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });

                                                if (pos1 > 70)
                                                {
                                                    endtable.WriteSelectedRows(0, -1, 50, 65, writer.DirectContent);
                                                }
                                                else
                                                {
                                                    document.NewPage();
                                                    endtable.WriteSelectedRows(0, -1, 50, 65, writer.DirectContent);
                                                }

                                            }


                                            //START
                                            //EVM040

                                            else //payslip
                                            {
                                                cls_Entity_Monthly_Salary_Process objEntPrcss = new cls_Entity_Monthly_Salary_Process();
                                                cls_Entity_Monthly_Salary_Process objMonthlySalaryProcess = new cls_Entity_Monthly_Salary_Process();
                                                DataTable dtEmp_list = objBuss.ReadEmp_List_For_PaySlip_Print(objEntPrcss);

                                                objMonthlySalaryProcess.Month = OBJ.Month;
                                                objMonthlySalaryProcess.Year = OBJ.Year;

                                                OBJ.Month = objMonthlySalaryProcess.Month;
                                                OBJ.Year = objMonthlySalaryProcess.Year;
                                                int NofDaysMonth = DateTime.DaysInMonth(objMonthlySalaryProcess.Year, objMonthlySalaryProcess.Month);

                                                string strMonthstart = new DateTime(objMonthlySalaryProcess.Year, objMonthlySalaryProcess.Month, 1).ToString("dd-MM-yyyy");
                                                string strMonthEnd = new DateTime(objMonthlySalaryProcess.Year, objMonthlySalaryProcess.Month, NofDaysMonth).ToString("dd-MM-yyyy");
                                                DateTime dMonthstart = objCommon.textToDateTime(strMonthstart);
                                                DateTime dMonthEnd = objCommon.textToDateTime(strMonthEnd);



                                                objEntPrcss.date = dMonthstart;
                                                objEntPrcss.CurrentDate = dMonthEnd;
                                                string MonthName = dMonthstart.ToString("MMMM");
                                                objEntPrcss.Employee = objMonthlySalaryProcess.Employee;
                                                objEntPrcss.Month = objMonthlySalaryProcess.Month;
                                                objEntPrcss.Year = objMonthlySalaryProcess.Year;
                                                objEntPrcss.date = dMonthstart;

                                                PdfPTable headtable = new PdfPTable(1);

                                                string strImageLoc = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CORPORATE_LOGOS) + "quotation-header.png";
                                                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLoc));
                                                image.ScalePercent(PdfPCell.ALIGN_CENTER);
                                                image.ScaleToFit(600f, 100f);

                                                headtable.AddCell(new PdfPCell(image) { Border = 0, PaddingBottom = 20, HorizontalAlignment = Element.ALIGN_CENTER, });
                                                document.Add(headtable);


                                                PdfPTable headLayout = new PdfPTable(1);
                                                headLayout.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                                                headLayout.AddCell(new PdfPCell(new Phrase("Payslip for the Month of " + MonthName + ", " + objEntPrcss.Year, FontFactory.GetFont("Times New Roman", 14, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
                                                headLayout.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Times New Roman", 30, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                                                document.Add(headLayout);

                                                int AttendncCount = 0;

                                                for (int intRowBodyCount = 1; intRowBodyCount <= dtEmp_list.Rows.Count; intRowBodyCount++)
                                                {
                                                    if (dtEmp_list.Rows[0]["ATTENDANCE"].ToString() == "P")
                                                    {
                                                        AttendncCount++;
                                                    }
                                                }

                                                string basicAmt = "", SalaryProcssdBasicAmt = "", AllowaceAmt = "", AllowovertimeAmount = "", DedctionAmt = "", DedctionInstalmntAmnt = "", Total = "", OT_Hours = "", MessAmnt = "", LvArrearAmnt = "", OtherAddAmnt = "", OtherDeductAmnt = "";
                                                Decimal TotalBasicAllow = 0, TotalDedctn = 0, netsalary = 0, AllowovertimeAmount1 = 0, AllowaceAmt1 = 0, basicAmt1 = 0, decSalaryProcssdBasicAmt = 0, spclDedctionAmt = 0, instlmntDedctionAmt = 0, decOtherAddAmnt = 0, decOtherDeductAmnt = 0;
                                                Decimal decMessAmnt = 0, decLvArrearAmnt = 0, decPrevArrAmnt = 0;
                                                if (dtSalPrssDtls.Rows.Count > 0)
                                                {
                                                    basicAmt = dtSalPrssDtls.Rows[0]["SLRY_BASIC_PAY"].ToString();
                                                    SalaryProcssdBasicAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_PRSD_BASICPAY"].ToString();
                                                    AllowaceAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_ALLOW_AMT"].ToString();
                                                    AllowovertimeAmount = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_OVERTIME_ALLOW_AMT"].ToString();
                                                    DedctionAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_DEDCTN_AMT"].ToString();
                                                    DedctionInstalmntAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_INSTLMNT_DEDCN_AMT"].ToString();
                                                    Total = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_TOTAL_AMT"].ToString();
                                                    if (dtSalPrssDtls.Rows[0]["SLPRCDMNTH_TOTAL_AMT"].ToString() != "")
                                                    {
                                                        OT_Hours = dtSalPrssDtls.Rows[0]["EMDLHRDTL_OT"].ToString();
                                                    }
                                                    MessAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_MESS_DEDCTN_AMT"].ToString();
                                                    LvArrearAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_LEV_ARREAR_AMT"].ToString();

                                                    OtherAddAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_OTHR_ADTION_AMT"].ToString();
                                                    OtherDeductAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_OTHR_DEDCTN_AMT"].ToString();
                                                    decPrevArrAmnt = Convert.ToDecimal(dtSalPrssDtls.Rows[0]["SLPRCDMNTH_PREV_MNTH_ARRE_AMNT"].ToString());
                                                }
                                                if (basicAmt != "")
                                                {
                                                    basicAmt1 = Convert.ToDecimal(basicAmt);
                                                }

                                                if (SalaryProcssdBasicAmt != "")
                                                {
                                                    decSalaryProcssdBasicAmt = Convert.ToDecimal(SalaryProcssdBasicAmt);
                                                    TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(SalaryProcssdBasicAmt);

                                                }

                                                if (AllowaceAmt != "")
                                                {
                                                    AllowaceAmt1 = Convert.ToDecimal(AllowaceAmt);
                                                    TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(AllowaceAmt);
                                                }
                                                if (AllowovertimeAmount != "")
                                                {
                                                    AllowovertimeAmount1 = Convert.ToDecimal(AllowovertimeAmount);
                                                    TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(AllowovertimeAmount);
                                                }
                                                if (OtherAddAmnt != "")
                                                {
                                                    decOtherAddAmnt = Convert.ToDecimal(OtherAddAmnt);
                                                    TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(OtherAddAmnt);
                                                }
                                                if (decPrevArrAmnt > 0)
                                                {
                                                    TotalBasicAllow = TotalBasicAllow + decPrevArrAmnt;
                                                }
                                                if (DedctionAmt != "")
                                                {
                                                    spclDedctionAmt = Convert.ToDecimal(DedctionAmt);
                                                    TotalDedctn = TotalDedctn + Convert.ToDecimal(DedctionAmt);
                                                }
                                                if (DedctionInstalmntAmnt != "")
                                                {
                                                    instlmntDedctionAmt = Convert.ToDecimal(DedctionInstalmntAmnt);
                                                    TotalDedctn = TotalDedctn + Convert.ToDecimal(DedctionInstalmntAmnt);
                                                }
                                                if (MessAmnt != "")
                                                {
                                                    decMessAmnt = Convert.ToDecimal(MessAmnt);
                                                    TotalDedctn = TotalDedctn + Convert.ToDecimal(decMessAmnt);
                                                }
                                                if (LvArrearAmnt != "")
                                                {
                                                    decLvArrearAmnt = Convert.ToDecimal(LvArrearAmnt);
                                                    TotalDedctn = TotalDedctn + Convert.ToDecimal(decLvArrearAmnt);
                                                }
                                                if (OtherDeductAmnt != "")
                                                {
                                                    decOtherDeductAmnt = Convert.ToDecimal(OtherDeductAmnt);
                                                    TotalDedctn = TotalDedctn + Convert.ToDecimal(OtherDeductAmnt);
                                                }
                                                if (decPrevArrAmnt < 0)
                                                {
                                                    TotalDedctn = TotalDedctn + (decPrevArrAmnt * -1);
                                                }
                                                if (Total != "")
                                                {
                                                    netsalary = Convert.ToDecimal(Total);
                                                }

                                                //if (indvlRound == "0")
                                                //{
                                                //     roundInd = 2;
                                                // }
                                                string strbasicAmt = objBusiness.AddCommasForNumberSeperation(basicAmt1.ToString("0.00"), objEntityCommon);
                                                string strSalaryProcssdBasicAmt = objBusiness.AddCommasForNumberSeperation(decSalaryProcssdBasicAmt.ToString("0.00"), objEntityCommon);
                                                string strAllowaceAmt = objBusiness.AddCommasForNumberSeperation(AllowaceAmt1.ToString("0.00"), objEntityCommon);
                                                string strAllowovertimeAmount = objBusiness.AddCommasForNumberSeperation(AllowovertimeAmount1.ToString("0.00"), objEntityCommon);
                                                string strTotalBasicAllow = objBusiness.AddCommasForNumberSeperation(TotalBasicAllow.ToString("0.00"), objEntityCommon);
                                                string strTotalDedctn = objBusiness.AddCommasForNumberSeperation(TotalDedctn.ToString("0.00"), objEntityCommon);
                                                string strspclDedctionAmt = objBusiness.AddCommasForNumberSeperation(spclDedctionAmt.ToString("0.00"), objEntityCommon);
                                                string strinstlmntDedctionAmt = objBusiness.AddCommasForNumberSeperation(instlmntDedctionAmt.ToString("0.00"), objEntityCommon);
                                                string strMessAmnt = objBusiness.AddCommasForNumberSeperation(decMessAmnt.ToString("0.00"), objEntityCommon);
                                                string strLvArrearAmnt = objBusiness.AddCommasForNumberSeperation(decLvArrearAmnt.ToString("0.00"), objEntityCommon);
                                                string strnetsalary = objBusiness.AddCommasForNumberSeperation(netsalary.ToString("0.00"), objEntityCommon);
                                                string strOtherAddAmt = objBusiness.AddCommasForNumberSeperation(decOtherAddAmnt.ToString("0.00"), objEntityCommon);
                                                string strOtherDeductAmt = objBusiness.AddCommasForNumberSeperation(decOtherDeductAmnt.ToString("0.00"), objEntityCommon);
                                                string strPrevArrAmnt = objBusiness.AddCommasForNumberSeperation(decPrevArrAmnt.ToString("0.00"), objEntityCommon);

                                                PdfPTable tableheadlayout = new PdfPTable(5);
                                                float[] tableheadlayoutBody = { 15, 43, 7, 23, 12 };
                                                tableheadlayout.SetWidths(tableheadlayoutBody);
                                                tableheadlayout.WidthPercentage = 100;

                                                tableheadlayout.AddCell(new PdfPCell(new Phrase("Employee #", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                //tableheadlayout.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["EID"].ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tableheadlayout.AddCell(new PdfPCell(new Phrase(dtSal.Rows[k]["EID"].ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });


                                                tableheadlayout.AddCell(new PdfPCell(new Phrase("Name", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                //tableheadlayout.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["EMPLOYEE"].ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tableheadlayout.AddCell(new PdfPCell(new Phrase(dtSal.Rows[k]["EMPLOYEE"].ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });

                                                tableheadlayout.AddCell(new PdfPCell(new Phrase("Department", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                //tableheadlayout.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["CPRDEPT_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tableheadlayout.AddCell(new PdfPCell(new Phrase(dtSal.Rows[k]["CPRDEPT_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });

                                                tableheadlayout.AddCell(new PdfPCell(new Phrase("Designation", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tableheadlayout.AddCell(new PdfPCell(new Phrase(dtSal.Rows[k]["DESIGNATION"].ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tableheadlayout.AddCell(new PdfPCell(new Phrase("Eligible Days", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tableheadlayout.AddCell(new PdfPCell(new Phrase(NofDaysMonth.ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });

                                                tableheadlayout.AddCell(new PdfPCell(new Phrase("Job Title", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tableheadlayout.AddCell(new PdfPCell(new Phrase(dtSal.Rows[k]["JOBRL_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tableheadlayout.AddCell(new PdfPCell(new Phrase("Present Days", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tableheadlayout.AddCell(new PdfPCell(new Phrase(AttendncCount.ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });

                                                document.Add(tableheadlayout);

                                                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 20, BaseColor.BLACK))));

                                                PdfPTable tablelayout = new PdfPTable(7);
                                                float[] tablelayoutBody = { 22, 13, 8, 13, 7, 23, 12 };
                                                tablelayout.SetWidths(tablelayoutBody);
                                                tablelayout.WidthPercentage = 100;

                                                tablelayout.AddCell(new PdfPCell(new Phrase("Basic and Allowances", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6, Colspan = 4, BackgroundColor = BaseColor.LIGHT_GRAY });
                                                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase("Deduction", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6, Colspan = 2, BackgroundColor = BaseColor.LIGHT_GRAY });

                                                tablelayout.AddCell(new PdfPCell(new Phrase("Description", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase("Hours", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase("Earned", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6, Colspan = 2 });

                                                tablelayout.AddCell(new PdfPCell(new Phrase("Basic Pay", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase(strbasicAmt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase(strSalaryProcssdBasicAmt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase("Special Deduction", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase(strspclDedctionAmt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });

                                                tablelayout.AddCell(new PdfPCell(new Phrase("Special Allowance", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase(strAllowaceAmt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase(strAllowaceAmt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase("Installment Deduction", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase(strinstlmntDedctionAmt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });

                                                tablelayout.AddCell(new PdfPCell(new Phrase("Over Time Allowance", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase(strAllowovertimeAmount, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase(OT_Hours, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase(strAllowovertimeAmount, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase("Mess Deduction", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase(strMessAmnt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });

                                                tablelayout.AddCell(new PdfPCell(new Phrase("Other Addition", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase(strOtherAddAmt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase(strOtherAddAmt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase("Other Deduction", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tablelayout.AddCell(new PdfPCell(new Phrase(strOtherDeductAmt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });


                                                if (decPrevArrAmnt >= 0)
                                                {
                                                    tablelayout.AddCell(new PdfPCell(new Phrase("Arrear Amount", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                    tablelayout.AddCell(new PdfPCell(new Phrase(strPrevArrAmnt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                                                    tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                    tablelayout.AddCell(new PdfPCell(new Phrase(strPrevArrAmnt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                                                    tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                    tablelayout.AddCell(new PdfPCell(new Phrase("Leave Arrear Deduction", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                    tablelayout.AddCell(new PdfPCell(new Phrase(strLvArrearAmnt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });


                                                    tablelayout.AddCell(new PdfPCell(new Phrase("Total Basic & Allowances", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6, Colspan = 3 });
                                                    tablelayout.AddCell(new PdfPCell(new Phrase(strTotalBasicAllow, FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                                                    tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                                                    tablelayout.AddCell(new PdfPCell(new Phrase("Total Deduction", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                    tablelayout.AddCell(new PdfPCell(new Phrase(strTotalDedctn, FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });

                                                }
                                                else
                                                {


                                                    tablelayout.AddCell(new PdfPCell(new Phrase("Total Basic & Allowances", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6, Colspan = 3 });
                                                    tablelayout.AddCell(new PdfPCell(new Phrase(strTotalBasicAllow, FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                                                    tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                    tablelayout.AddCell(new PdfPCell(new Phrase("Leave Arrear Deduction", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                    tablelayout.AddCell(new PdfPCell(new Phrase(strLvArrearAmnt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });


                                                    tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                    tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                    tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                    tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                    tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                    tablelayout.AddCell(new PdfPCell(new Phrase("Arrear Amount", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                    tablelayout.AddCell(new PdfPCell(new Phrase(strPrevArrAmnt.Replace("-", string.Empty), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });



                                                    tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                    tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                    tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                    tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                    tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                    tablelayout.AddCell(new PdfPCell(new Phrase("Total Deduction", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                    tablelayout.AddCell(new PdfPCell(new Phrase(strTotalDedctn, FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                                                }
                                                document.Add(tablelayout);

                                                PdfPTable tablelayoutnet = new PdfPTable(3);
                                                float[] tablenetlayoutBody = { 68, 23, 12 };
                                                tablelayoutnet.SetWidths(tablenetlayoutBody);
                                                tablelayoutnet.WidthPercentage = 100;

                                                //tablelayoutnet.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6, Colspan = 3 });
                                                tablelayoutnet.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6, Colspan = 3 });

                                                tablelayoutnet.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                                                tablelayoutnet.AddCell(new PdfPCell(new Phrase("Net Salary", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                                                tablelayoutnet.AddCell(new PdfPCell(new Phrase(strnetsalary, FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6, });

                                                document.Add(tablelayoutnet);

                                                PdfPTable endtable = new PdfPTable(6);
                                                float[] endBody = { 25, 10, 25, 10, 25, 5 };
                                                endtable.SetWidths(endBody);
                                                endtable.WidthPercentage = 100;

                                                endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6, Colspan = 6 });
                                                endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6, Colspan = 6 });

                                                endtable.AddCell(new PdfPCell(new Phrase("Prepared By", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                                                endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                                                endtable.AddCell(new PdfPCell(new Phrase("Checked By", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                                                endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                                                endtable.AddCell(new PdfPCell(new Phrase("Received By", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                                                endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });

                                                endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthTop = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                                                endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                                                endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthTop = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                                                endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                                                endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthTop = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                                                endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });

                                                document.Add(endtable);

                                                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 40, BaseColor.BLACK))));


                                                PdfPTable footrtable = new PdfPTable(2);
                                                float[] headersBodyfootr = { 0, 100 };
                                                footrtable.SetWidths(headersBodyfootr);
                                                footrtable.WidthPercentage = 100;

                                                string strImageLocFooter = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CORPORATE_LOGOS) + "quotation-footer.png";
                                                iTextSharp.text.Image imageFootr = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLocFooter));
                                                imageFootr.ScalePercent(PdfPCell.ALIGN_LEFT);
                                                imageFootr.ScaleToFit(520f, 60f);

                                                footrtable.AddCell(new PdfPCell(new Phrase(" ")) { Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_LEFT });
                                                footrtable.AddCell(new PdfPCell(imageFootr) { Border = 0, PaddingBottom = 10, HorizontalAlignment = Element.ALIGN_LEFT });
                                                document.Add(footrtable);
                                            }

                                            document.Close();

                                            Response.Write(document);

                                            if (File.Exists(Server.MapPath(imgpath + strImageName)))
                                            {
                                                List<clsEntityMailAttachment> objEntityMailAttachList = new List<clsEntityMailAttachment>();

                                                clsEntityMailAttachment objEntityAttach = new clsEntityMailAttachment();
                                                objEntityAttach.Attch_Path = Server.MapPath(imgpath + strImageName);
                                                objEntityMailAttachList.Add(objEntityAttach);

                                                MailUtility_ERP.clsMail objMail = new MailUtility_ERP.clsMail();
                                                objMail.SendMailAsHtml(objEntityMail, objEntityMailAttachList, objEntityMailCcBCcList, objEntityToMailAddressList);


                                                objentityShortList.Month = Convert.ToInt32(ddlMonth.SelectedItem.Value);
                                                objentityShortList.Year = Convert.ToInt32(ddlyear.SelectedItem.Value);

                                                objBusinessLabourCard.UpdateMailid(objentityShortList);
                                                intmailSendChk++;  
                                            
                                            }

                                            //END
                                            //EVM040

                                        }//if true

                                    }
                                }
                            }

                        }
                    }
                    
                }

                Session["MISS_LIST"] = misslist.TrimEnd(',');

                Response.Redirect("hcm_Bulk_LabourCard_Print.aspx?InsUpd=MailSent");

            }
            catch (Exception)
            {

            }
            //ScriptManager.RegisterStartupScript(this, GetType(), "HideLoading", "HideLoading();", true);
            //if (intmailSendChk != 0)
            //{
            //    Response.Redirect("hcm_Bulk_LabourCard_Print.aspx?InsUpd=Ins&&Id=" + Request.QueryString["Id"] + "");
            //}
            //else
            //{
            //    //Response.Redirect("hcm_Bulk_LabourCard_Print.aspx");
            //}

        }

    }


}