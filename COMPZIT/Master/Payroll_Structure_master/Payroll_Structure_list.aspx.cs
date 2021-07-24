using BL_Compzit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using EL_Compzit;
using CL_Compzit;
using Newtonsoft.Json;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web.Script.Serialization;

using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusinessLayer_HCM;
using System.IO;

public partial class Master_Payroll_Structure_master_Payroll_Structure_list : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {


            int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            int intorgid=0, intcorpid=0;



            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["CORPOFFICEID"] != null)
            {
                intcorpid = Convert.ToInt32(Session["CORPOFFICEID"]);

            }
            else if (Session["CORPOFFICEID"] == null)
            {

                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {

                intorgid = Convert.ToInt32(Session["ORGID"]);

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                       };

            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intcorpid);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenCancelReasonMust.Value = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
            }



            intUserRoleRecall = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
            DataTable dtCancelRecall = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUserRoleRecall);
            if (dtCancelRecall.Rows.Count > 0)
            {
                intEnableRecall = 1;
            }
            else
            {
                intEnableRecall = 0;
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Payroll_Structure);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intEnableAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenenableadd.Value = intEnableAdd.ToString();
                    }
                     if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenenablemodify.Value = intEnableModify.ToString();
                    }
                     if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        Hiddenenablecancel.Value = intEnableCancel.ToString();
                    }
                }




            }

            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessInsertion", "SuccessInsertion();", true);
                }
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
                else if (strInsUpd == "Cncl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                }
                else if (strInsUpd == "Sts")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessStatusChng", "SuccessStatusChng();", true);
                }
            }
        }
    }


    [WebMethod]
    public static string[] LoadStaticDatafordt()//Filters
    {
        StringBuilder html = new StringBuilder();
        StringBuilder sbSearchInputColumns = new StringBuilder();

        string[] strResults = new string[3];
        html.Append("<div>");

        html.Append("<div class=\"dataTables_length\">");//length
        html.Append("<p><span class=\"tbl_srt1\" style='margin-top: 4px;'>Show</span> <select class=\"form-control tbl_srt\" onchange=\"getdata(1);\" id=\"ddl_page_size\">");
        html.Append("<option value=\"10\">10</option><option value=\"25\">25</option><option value=\"50\">50</option><option value=\"100\">100</option></select><span class=\"tbl_srt1\" style='margin-top: 4px;'>entries</span>");
        html.Append("</p></div>");
        //page length ends
        //common filter
        html.Append("<div class=\"col-md-2 pull-right\">");
        html.Append("<input  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"SettypingTimer();\" class=\"form-control tbl_ser_n\" id=\"txtCommonSearch_dt\"  type=\"search\" placeholder=\" Search \" aria-controls=\"example\" style='width: 220px;'>");
        html.Append("</div>");
        //common filter ends
        html.Append("</div>");
        strResults[0] = html.ToString();
        //custom search fields
        var values = Enum.GetValues(typeof(SearchInputColumns));
        int intSearchColumnCount = values.Length;

        foreach (var item in values)
        {

            int Item = Convert.ToInt32(item);

            // use item number to customize names using if 
            if (Item.ToString() == "0")
            {
                sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" onclick=\"SetOrderByValue(" + (Item + 1) + ")\" class=\"col-md-4 tr_l sorting_asc\" >Name<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br>");
                sbSearchInputColumns.Append("<input type=\"text\" id=\"txtSearchColumn_" + Item + "\" autocomplete=\"off\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" placeholder=\" Name\" title=\" Name\">");
                sbSearchInputColumns.Append("</th>");
            }
            else if (Item.ToString() == "1")
            {
                sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" onclick=\"SetOrderByValue(" + (Item + 1) + ")\" class=\"col-md-3 tr_l sorting\" > code<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br>");
                sbSearchInputColumns.Append("<input type=\"text\" id=\"txtSearchColumn_" + Item + "\" autocomplete=\"off\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" placeholder=\" code\" title=\" code\">");
                sbSearchInputColumns.Append("</th>");
            }
            else if (Item.ToString() == "2")
            {
                sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" onclick=\"SetOrderByValue(" + (Item + 1) + ")\" class=\"col-md-3 tr_l sorting\" >mode<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br>");
                sbSearchInputColumns.Append("<input type=\"text\" id=\"txtSearchColumn_" + Item + "\" autocomplete=\"off\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" placeholder=\"Mode\" title=\"Mode\">");
                sbSearchInputColumns.Append("</th>");
            }
           

        }
        sbSearchInputColumns.Append("<th class=\"col-md-2 sorting\" style=\"word-wrap:break-word;\">ACTIONS</th>");

        

        strResults[1] = sbSearchInputColumns.ToString();
        strResults[2] = intSearchColumnCount.ToString();
        return strResults;
    }







    public enum SearchInputColumns
    {
        //Must be sequential 
        NAME=0,
        CODE = 1,
        MODE = 2
        
    }




    [WebMethod]
    public static string[] GetData(string OrgId,string addenable,string modifyenable,string cancelenable, string CorpId, string Userid, string ddlStatus, string CancelStatus, string PageNumber, string PageMaxSize, string strCommonSearchTerm, string OrderColumn, string OrderMethod, string strInputColumnSearch)
    {


        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        clsEntityLayerPayroll objEntityPayroll = new clsEntityLayerPayroll();
       
        clsBusinessLayerPayroll objBusinessPayrl = new clsBusinessLayerPayroll();


        string[] strResults = new string[3];

        if (OrgId != null && OrgId != "")
        {
            objEntityPayroll.Organisation_Id = Convert.ToInt32(OrgId);
        }
        if (CorpId != null && CorpId != "")
        {
            objEntityPayroll.CorpOffice_Id = Convert.ToInt32(CorpId);
        }
        objEntityPayroll.Status = Convert.ToInt32(ddlStatus);
        objEntityPayroll.Cancel_Status = Convert.ToInt32(CancelStatus);
        objEntityPayroll.User_Id = Convert.ToInt32(Userid);

        objEntityPayroll.PageNumber = Convert.ToInt32(PageNumber);
        objEntityPayroll.PageMaxSize = Convert.ToInt32(PageMaxSize);
        objEntityPayroll.OrderMethod = Convert.ToInt32(OrderMethod);
        objEntityPayroll.OrderColumn = Convert.ToInt32(OrderColumn);
        int clumn = Convert.ToInt32(OrderColumn); ;

        if (objEntityPayroll.OrderColumn == 1)
        {
            clumn = 2;
        
        }
        if (objEntityPayroll.OrderColumn == 2)
        {
            clumn = 7;

        }
        objEntityPayroll.OrderColumn = clumn;
        objEntityPayroll.CommonSearchTerm = strCommonSearchTerm;

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

        objEntityPayroll.SearchName = strSearchInputs[Convert.ToInt32(SearchInputColumns.NAME)];
        objEntityPayroll.SearchCode = strSearchInputs[Convert.ToInt32(SearchInputColumns.CODE)];
        objEntityPayroll.SearchMode = strSearchInputs[Convert.ToInt32(SearchInputColumns.MODE)];
      

        //ReadList
        DataTable dt = objBusinessPayrl.FetchPayrollDetails_List(objEntityPayroll);

      //  int intCancelStatus = Convert.ToInt32(CancelStatus);
        //int intEnableModify = Convert.ToInt32(EnableModify);
        //int intEnableCancel = Convert.ToInt32(EnableCancel);

        string strTableContents = "";
        strTableContents = ConvertDataTableToHTML(dt, objEntityPayroll, addenable,modifyenable,cancelenable);
        strResults[0] = strTableContents;


        if (dt.Rows.Count > 0)
        {
            int intTotalItems = Convert.ToInt32(dt.Rows[0]["CNT"].ToString());
            int intCurrentRowCount = dt.Rows.Count;

            strResults[1] = intCurrentRowCount.ToString();

            //Pagination
            strResults[2] = objBusinessLayer.GenereatePagination(intTotalItems, objEntityPayroll.PageNumber, objEntityPayroll.PageMaxSize, intCurrentRowCount);
        }

        return strResults;
    }



    [WebMethod]
    public static string PrintList(string strOrgId,string strCorpId, string strddlStatus , string strCancelStatus , string strUserId)
    {



        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        clsEntityLayerPayroll objEntityPayroll = new clsEntityLayerPayroll();

        clsBusinessLayerPayroll objBusinessPayrl = new clsBusinessLayerPayroll();

        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
       // clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();


        if (strOrgId != null && strOrgId != "")
        {
            objEntityPayroll.Organisation_Id = Convert.ToInt32(strOrgId);
        }
        if (strCorpId != null && strCorpId != "")
        {
            objEntityPayroll.CorpOffice_Id = Convert.ToInt32(strCorpId);
        }
        objEntityPayroll.Status = Convert.ToInt32(strddlStatus);
        objEntityPayroll.Cancel_Status = Convert.ToInt32(strCancelStatus);

        objEntityPayroll.User_Id = Convert.ToInt32(strUserId);


        DataTable dt = objBusinessPayrl.FetchPayrollDetails(objEntityPayroll);

        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.PAYROLL_LIST_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PAYROLL_LIST_PDF);

        objEntityCommon.CorporateID = Convert.ToInt32(strCorpId);
        objEntityCommon.Organisation_Id = Convert.ToInt32(strOrgId);
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "Payroll_" + strCorpId + "_" + strNextNumber + ".pdf";

         Document document = new Document(PageSize.A4, 50f, 40f, 120f, 30f);
        document = new Document(PageSize.LETTER, 50f, 40f, 20f, 40f);
        Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
        string format = String.Format("{{0:N{0}}}", 2);
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


                footrtable.AddCell(new PdfPCell(new Phrase("STATUS ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                   
                if(strddlStatus=="1"){
                footrtable.AddCell(new PdfPCell(new Phrase("ACTIVE", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                else if(strddlStatus=="2"){
                
                     footrtable.AddCell(new PdfPCell(new Phrase("INACTIVE", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                
                else if(strddlStatus=="0"){
                
                 footrtable.AddCell(new PdfPCell(new Phrase("ALL", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                
                }
                footrtable.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });



                 document.Add(footrtable);

                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(3);
                float[] footrsBody = { 14, 18, 14};
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("NAME", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("CODE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("MODE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });


                if (dt.Rows.Count > 0)
                {
                    for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
                    {


                         TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount]["NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount]["PAYRL_CODE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                      if(dt.Rows[intRowBodyCount]["MODE"].ToString()=="1"){
                          TBCustomer.AddCell(new PdfPCell(new Phrase("ADDITION", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                      }
                        else{


                          TBCustomer.AddCell(new PdfPCell(new Phrase("DEDUCTION", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                      }
            }

                }
                else
                {
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
    



    public static string ConvertDataTableToHTML(DataTable dt, clsEntityLayerPayroll objEntitypayrol,string addenable,string modifyenable,string cancelenable)
    {
        string strReturn = "";

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        StringBuilder sb = new StringBuilder();

        if (dt.Rows.Count > 0)
        {

            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                sb.Append("<tr>");

                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                int Status = Convert.ToInt32(dt.Rows[intRowBodyCount]["ACTIVE"].ToString());

                int counttransc = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString()) + Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION1"].ToString());


                sb.Append("<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount]["NAME"].ToString() + "</td>");
                sb.Append("<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount]["PAYRL_CODE"].ToString() + "</td>");

                if (dt.Rows[intRowBodyCount]["MODE"].ToString() == "1")
                {

                    sb.Append("<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >ADDITION</td>");
                }
                else {

                    sb.Append("<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >DEDUCTION</td>");
                
                }
                
               
                

                sb.Append("<td>");




                if (modifyenable == "1" && objEntitypayrol.Cancel_Status == 0)
                {
                    if (dt.Rows[intRowBodyCount]["ACTIVE"].ToString() == "1" )
                    {

                        //sb.Append("<a class=\"btn tab_but1 butn1 btn_sta\"  title=\"Change Status\" onclick='' " +
                        //                          " href=\"" + Id + "\"><i class=\"fa fa-check-circle\"></i></a>");

                        sb.Append("<a href=\"javascript:;\" class=\"btn tab_but1 butn1 btn_sta\" title=\"Change Status\"  onclick=\"return ChangeStatus('" + Id + "','" + Status + "');\"><i class=\"fa fa-check-circle\"></i></a>");
                    }

                    else {

                        //sb.Append("<a class=\"btn tab_but1 butn4 btn_sti\" title=\"Change Status\" onclick='' " +
                        //                         " href=\"" + Id + "\"><i class=\"fa fa-times-circle\"></i></a>");

                        sb.Append("<a href=\"javascript:;\" class=\"btn tab_but1 butn4 btn_sti\" title=\"Change Status\"  onclick=\"return ChangeStatus('" + Id + "','" + Status + "');\"><i class=\"fa fa-times-circle\"></i></a>");

                    }
                    //sb.Append("<a class=\"btn act_btn bn1 bt_e\" title=\"Edit\" onclick='' " +
                    //                             " href=\"" + Id + "\"><i class=\"fa fa-edit\"></i></a>");

                    sb.Append("<a class=\"btn act_btn bn1 bt_e\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                               " href=\"Payroll_Structure_Master.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>");
                }

                else
                {


                    if (dt.Rows[intRowBodyCount]["ACTIVE"].ToString() == "1" && objEntitypayrol.Cancel_Status == 1)
                    {

                        sb.Append("<a class=\"btn tab_but1 butn1 btn_sta\" disabled=\"true\" style='background-color: #8080805c;' title=\"Change Status\" ><i class=\"fa fa-check-circle\"></i></a>");
                                                  


                       
                    }

                    else if(objEntitypayrol.Cancel_Status==1)
                    {

                        sb.Append("<a class=\"btn tab_but1 butn4 btn_sti\" disabled=\"true\" style='background-color: #8080805c;'  title=\"Change Status\" ><i class=\"fa fa-times-circle\"></i></a>");
                                               



                        
                        
                    }
                    //sb.Append("<a class=\"btn act_btn bn4 bt_v\" title=\"View\" onclick='' " +
                    //                               " href=\"" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>");


                    sb.Append("<a class=\"btn act_btn bn4 bt_v\" title=\"View\" onclick='return getdetails(this.href);' " +
                                 " href=\"Payroll_Structure_Master.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>");
                }

                if (cancelenable == "1" && counttransc==0 &&  objEntitypayrol.Cancel_Status==0)
                {


                    sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>");
                }
                else if (objEntitypayrol.Cancel_Status == 0)
                {



                    sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return alreadys();\"   disabled=\"true\" ><i class=\"fa fa-trash\"></i></a>");
                }

              



              



               



                sb.Append("</td>");

                sb.Append("</tr>");
            }

        }
        else
        {
            sb.Append("<td class=\"tr_c\" colspan=\"6\">No data available in table</td>");
            //No matching records found//
        }

        strReturn = sb.ToString();

        return strReturn;
    }



    [WebMethod]
    public static string CancelReason(string strCnclId, string strCancelMust, string strUserID, string strCancelReason, string strOrgIdID, string strCorpID)
    {
        clsBusinessLayerPayroll ObjBusinesspayrol = new clsBusinessLayerPayroll();
        clsEntityLayerPayroll objEntitypayrl = new clsEntityLayerPayroll();

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successcncl";
        string strRandomMixedId = strCnclId;

        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        objEntitypayrl.Payrl_ID = Convert.ToInt32(strId);
        objEntitypayrl.User_Id = Convert.ToInt32(strUserID);
        objEntitypayrl.Organisation_Id = Convert.ToInt32(strOrgIdID);
        objEntitypayrl.CorpOffice_Id= Convert.ToInt32(strCorpID);
        if (strCancelMust == "1")
        {
            objEntitypayrl.Cancel_Reason = strCancelReason;
        }

        else
        {
            objEntitypayrl.Cancel_Reason = objCommon.CancelReason();
        }

        try
        {
            ObjBusinesspayrol.CancelPayroll(objEntitypayrl);
        }
        catch
        {
            strRets = "failed";
        }

        return strRets;

    }



    [WebMethod]
    public static string ChangeStatus(string strStsId, string Status)
    {
        clsBusinessLayerPayroll ObjBusinesspayrol = new clsBusinessLayerPayroll();
        clsEntityLayerPayroll objEntitypayrl = new clsEntityLayerPayroll();

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successchng";
        string strRandomMixedId = strStsId;

        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        objEntitypayrl.Payrl_ID = Convert.ToInt32(strId);
        if (Status == "1")
        {
            objEntitypayrl.Status = 0;
        }
        else
        {
            objEntitypayrl.Status = 1;
        }
        try
        {
            ObjBusinesspayrol.ChangeStatus(objEntitypayrl);
        }
        catch
        {
            strRets = "failed";
        }

        return strRets;

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
             headtable.AddCell(new PdfPCell(new Phrase("PAYROLL LIST ", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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