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
// CREATED DATE:14/03/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class Master_gen_Customer_Master_gen_Customer_MasterList : System.Web.UI.Page
{
    //enumeration for previous and next button
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlCustomerType.Focus();
            Customer_Type_Load();
          
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Mail_Settings);
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
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenFieldUpdRole.Value = intEnableModify.ToString();
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenFieldCnclRole.Value = intEnableCancel.ToString();
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        //future

                    }

                }

           

                //Creating objects for business layer
                clsBusinessLayerMailConsole objBusinessLayerMailConsole = new clsBusinessLayerMailConsole();
                clsEntityMailConsole objEntityMailConsole = new clsEntityMailConsole();
                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityMailConsole.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityMailConsole.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }


                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
                DataTable dtCorpDetail = new DataTable();
                dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                if (dtCorpDetail.Rows.Count > 0)
                {
                    HiddenFieldCancelReasMust.Value = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                }

                if (Request.QueryString["InsUpd"] != null)
                {
                    string strInsUpd = Request.QueryString["InsUpd"].ToString();
                    if (strInsUpd == "Ins")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                    }
                    else if (strInsUpd == "Upd")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                    }
                    else if (strInsUpd == "Cncl")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                    }
                    else if (strInsUpd == "StsCh")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessSts", "SuccessSts();", true);
                    }
                    else if (strInsUpd == "Err")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ErrorCancelation", "ErrorCancelation();", true);
                    }
                    else if (strInsUpd == "AlCncl")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "AlreadyCncl", "AlreadyCncl();", true);
                    }
                }
            }
        }
    }


     public void Customer_Type_Load()
    {
        clsEntityCustomer objEntityCustomer = new clsEntityCustomer();
          clsBusinessLayerCustomer objBusinessLayerCustomer = new clsBusinessLayerCustomer();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCustomer.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCustomer.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        
                objEntityCustomer.Customer_Type_Id = 0;
          
            DataTable dtType = objBusinessLayerCustomer.Read_Customer_Type(objEntityCustomer);
            ddlCustomerType.Items.Clear();
            ddlCustomerType.DataSource = dtType;

            ddlCustomerType.DataTextField = "CSTMRTYP_NAME";
            ddlCustomerType.DataValueField = "CSTMRTYP_ID";
            ddlCustomerType.DataBind();
            ddlCustomerType.Items.Insert(0, "--SELECT TYPE--");
        }
     [WebMethod]
     public static string ChangeStatus(string strmemotId, string strStatus, string UsrId, string orgID, string corptID)
     {
         string strRet = "success";
         string strRandomMixedId = strmemotId;
         string id = strRandomMixedId;
         string strLenghtofId = strRandomMixedId.Substring(0, 2);
         int intLenghtofId = Convert.ToInt16(strLenghtofId);
         string strId = strRandomMixedId.Substring(2, intLenghtofId);
         clsBusinessLayerCustomer objBusinessLayerCustomer = new clsBusinessLayerCustomer();
         clsEntityCustomer objEntityCustomer = new clsEntityCustomer();
         objEntityCustomer.Customer_Id = Convert.ToInt32(strId);
         objEntityCustomer.UserId = Convert.ToInt32(UsrId);
         objEntityCustomer.Date = System.DateTime.Now;
         objEntityCustomer.Organisation_Id = Convert.ToInt32(orgID);
         objEntityCustomer.CorpId = Convert.ToInt32(corptID);
         if (strStatus == "1")
         {
             strStatus = "0";
         }
         else
         {
             strStatus = "1";
         }
         objEntityCustomer.Customer_Status = Convert.ToInt32(strStatus);

         try
         {
             objBusinessLayerCustomer.UpdateStatus(objEntityCustomer);
             strRet = "success";
         }
         catch
         {
             strRet = "AlCncl";
         }

         return strRet;
     }


     [WebMethod]
     public static string ReOpenConfByID(string orgID, string corptID, string userID, string MasterDbId, string Mode, string reasonmust, string cnclRsn)
     {


         string sts = "";
         try
         {
             string strRandomMixedId = MasterDbId;
             string id = strRandomMixedId;
             string strLenghtofId = strRandomMixedId.Substring(0, 2);
             int intLenghtofId = Convert.ToInt16(strLenghtofId);
             string strId = strRandomMixedId.Substring(2, intLenghtofId);

             clsCommonLibrary objCommon = new clsCommonLibrary();
             clsBusinessLayerCustomer objBusinessLayerCustomer = new clsBusinessLayerCustomer();
             clsEntityCustomer objEntityCustomer = new clsEntityCustomer();

             objEntityCustomer.Customer_Id = Convert.ToInt32(strId);
             objEntityCustomer.UserId = Convert.ToInt32(userID);
             objEntityCustomer.Date = System.DateTime.Now;
             objEntityCustomer.Organisation_Id = Convert.ToInt32(orgID);
             objEntityCustomer.CorpId = Convert.ToInt32(corptID);
             if (Mode == "0")
             {
                 if (reasonmust == "1")
                 {
                     objEntityCustomer.Cancel_Reason = cnclRsn;
                 }
                 else
                 {
                     objEntityCustomer.Cancel_Reason = objCommon.CancelReason();
                 }
                try{
                         objBusinessLayerCustomer.CancelCustomerMaster(objEntityCustomer);
                         sts = "Cncl";
                     }
                   catch
                     {
                         sts = "AlCncl";
                     }
                 }
             
         }
         catch (Exception ex)
         {
             sts = "Err";
         }
         return sts;
     }
     public static string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel)
     {
         clsCommonLibrary objCommon = new clsCommonLibrary();
         string strRandom = objCommon.Random_Number();
         string strHtml = "";
         if (dt.Rows.Count > 0)
         {
             for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
             {
                 int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
                 int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

                 string strId = dt.Rows[intRowBodyCount][0].ToString();
                 int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                 string stridLength = intIdLength.ToString("00");
                 string Id = stridLength + strId + strRandom;
                 strHtml += "<tr  >";

                 strHtml += "<td class=\"tr_l\">" + dt.Rows[intRowBodyCount][1].ToString() + "</td>";
                 strHtml += "<td class=\"tr_l\">" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";
                 strHtml += "<td class=\"tr_l\">" + dt.Rows[intRowBodyCount][3].ToString() + "</td>";
                 strHtml += "<td class=\"tr_l\">" + dt.Rows[intRowBodyCount][4].ToString() + "</td>";
                 strHtml += "<td class=\"tr_l\">" + dt.Rows[intRowBodyCount][5].ToString() + "</td>";
                 strHtml += "<td>";
                 strHtml += " <div class=\"btn_stl1\">";
                 if (intCnclUsrId == 0 && intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                 {
                     if (dt.Rows[intRowBodyCount][6].ToString() == "1")
                         strHtml += "<button class=\"btn tab_but1 butn1 btn_sta\" title=\"Change Status\" onclick=\"return ChangeStatus('" + Id + "','1','" + intCnclUsrId + "');\"><i class=\"fa fa-check-circle\"></i></button>";
                     else
                         strHtml += "<button class=\"btn tab_but1 butn4 btn_sti\" title=\"Change Status\" onclick=\"return ChangeStatus('" + Id + "','0','" + intCnclUsrId + "');\"><i class=\"fa fa-times-circle\"></i></button>";

                 }
                 else
                 {
                     if (dt.Rows[intRowBodyCount][6].ToString() == "1")
                         strHtml += "<button disabled class=\"btn tab_but1 butn1 btn_sta\" title=\"Change Status\" ><i class=\"fa fa-check-circle\"></i></button>";
                     else
                         strHtml += "<button disabled class=\"btn tab_but1 butn4 btn_sti\" title=\"Change Status\" ><i class=\"fa fa-times-circle\"></i></button>";
                 }
                 if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                 {
                     if (intCnclUsrId == 0)
                     {

                         strHtml += " <button class=\"btn act_btn bn1 bt_e\"  title=\"Edit\" onclick='return getdetails(\"gen_Customer_Master.aspx?Id=" + Id + "\");'>"
                            + "<i class=\"fa fa-edit\"></i>" + "</button>";
                     }

                     else
                     {
                         strHtml += " <button  class=\"btn act_btn bn4 bt_v\" title=\"View\" onclick='return getdetails(\"gen_Customer_Master.aspx?ViewId=" + Id + "\");'>" +
                         "<i class=\"fa fa-list-alt\"></i>" + "</button>";
                     }
                 }
                 if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                 {
                     if (intCnclUsrId == 0)
                     {
                         if (intCancTransaction == 0)
                         {
                             strHtml += "<button class=\"btn act_btn bn3\" onclick=\"return OpenCancelView('" + Id + "');\" title=\"Cancel\" >";
                             strHtml += " <i class=\"fa fa-trash\"></i>";
                             strHtml += "</button>";
                         }
                         else
                         {

                             strHtml += "<a class=\"btn act_btn bn3\" disabled=\"\" onclick='return CancelNotPossible();' title=\"Cancel\">";
                             strHtml += " <i class=\"fa fa-trash\"></i>";
                             strHtml += "</a>";

                         }
                     }
                 }
                 strHtml += " </div>";
                 strHtml += "</td>";
                 strHtml += "</tr>";
             }
         }
         else
         {
             strHtml += "<td class=\"tr_c\" colspan=\"6\">No data available in table</td>";
         }
         return strHtml;
     }
     [WebMethod]
    public static string[] GetData(string OrgId, string CorpId, string ddlStatus,string custype, string CancelStatus, string EnableModify, string EnableCancel, string PageNumber, string PageMaxSize, string strCommonSearchTerm, string OrderColumn, string OrderMethod, string strInputColumnSearch)
    {

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
       clsBusinessLayerCustomer objBusinessLayerCustomer = new clsBusinessLayerCustomer();
        clsEntityCustomer objEntityCustomer = new clsEntityCustomer();
        objEntityCustomer.Customer_Status= Convert.ToInt32(ddlStatus);
        objEntityCustomer.Customer_Type_Id = Convert.ToInt32(custype);
    objEntityCustomer.Cancel_Status = Convert.ToInt32(CancelStatus);
    objEntityCustomer.Organisation_Id = Convert.ToInt32(OrgId);
    objEntityCustomer.CorpId = Convert.ToInt32(CorpId);
        string[] strResults = new string[2];
        objEntityCustomer.PageNumber = Convert.ToInt32(PageNumber);
        objEntityCustomer.PageMaxSize = Convert.ToInt32(PageMaxSize);
        objEntityCustomer.OrderMethod = Convert.ToInt32(OrderMethod);
        objEntityCustomer.OrderColumn = Convert.ToInt32(OrderColumn);
        objEntityCustomer.CommonSearchTerm = strCommonSearchTerm;

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
        objEntityCustomer.SearchCusName = strSearchInputs[Convert.ToInt32(SearchInputColumns.NAME)];
        objEntityCustomer.SearchAdress = strSearchInputs[Convert.ToInt32(SearchInputColumns.ADDRESS)];
        objEntityCustomer.SearchGroup = strSearchInputs[Convert.ToInt32(SearchInputColumns.GROUP)];
        objEntityCustomer.SearchType = strSearchInputs[Convert.ToInt32(SearchInputColumns.TYPE)];
        objEntityCustomer.SearchRef = strSearchInputs[Convert.ToInt32(SearchInputColumns.REF)];
        DataTable dt = new DataTable();
        dt = objBusinessLayerCustomer.Read_Customer_List_BySearch(objEntityCustomer);

        int intEnableUpdate = Convert.ToInt32(EnableModify);
        int intEnableCancel = Convert.ToInt32(EnableCancel);

        strResults[0] = ConvertDataTableToHTML(dt, intEnableUpdate, intEnableCancel);
        if (dt.Rows.Count > 0)
        {
            int intTotalItems = Convert.ToInt32(dt.Rows[0]["CNT"].ToString());
            int intCurrentRowCount = dt.Rows.Count;
            //Pagination
            strResults[1] = objBusinessLayer.GenereatePagination(intTotalItems, objEntityCustomer.PageNumber, objEntityCustomer.PageMaxSize, intCurrentRowCount);
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
                sbSearchInputColumns.Append("<th id=\"tdColumnHead_1\" onclick=\"SetOrderByValue(1)\" class=\"th_b2 tr_l sorting_asc\" style=\"word-wrap:break-word;\">CUSTOMER NAME<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"Customer Name\" placeholder=\"Customer Name\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "1")
            {
                sbSearchInputColumns.Append("<th id=\"tdColumnHead_2\" onclick=\"SetOrderByValue(2)\" class=\"th_b11 tr_l sorting\" style=\"word-wrap:break-word;\">CUSTOMER ADDRESS<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"Customer Address\" placeholder=\"Customer Address\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "2")
            {
                sbSearchInputColumns.Append("<th id=\"tdColumnHead_2\" onclick=\"SetOrderByValue(2)\" class=\"th_b4 tr_l sorting\" style=\"word-wrap:break-word;\">CUSTOMER GROUP<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"Customer Group\" placeholder=\"Customer Group\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "3")
            {
                sbSearchInputColumns.Append("<th id=\"tdColumnHead_2\" onclick=\"SetOrderByValue(2)\" class=\"th_b4 tr_l sorting\" style=\"word-wrap:break-word;\">CUSTOMER TYPE<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"Customer Type\" placeholder=\"Customer Type\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "4")
            {
                sbSearchInputColumns.Append("<th id=\"tdColumnHead_2\" onclick=\"SetOrderByValue(2)\" class=\"th_b4 tr_l sorting\" style=\"word-wrap:break-word;\">CUSTOMER REF#<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in \" type=\"text\" title=\"Customer Ref#\" placeholder=\"Customer Ref#\"></th>");
            }
        }
        sbSearchInputColumns.Append("<th class=\"th_b4 sorting\" style=\"word-wrap:break-word;\">ACTIONS</th>");
        strResults[1] = sbSearchInputColumns.ToString();
        strResults[2] = intSearchColumnCount.ToString();
        return strResults;
    }

    public enum SearchInputColumns
    {
        //Must be sequential 
        NAME = 0,
        ADDRESS = 1,
        GROUP=2,
        TYPE=3,
        REF=4,

    }


    [WebMethod]
    public static string PrintList(string orgID, string corptID, string Status, string CnclSts,string custype,string cus)
    {

     


        string strReturn = "";
        //end
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerCustomer objBusinessLayerCustomer = new clsBusinessLayerCustomer();
        clsEntityCustomer objEntityCustomer = new clsEntityCustomer();
        objEntityCustomer.Customer_Status = Convert.ToInt32(Status);
        objEntityCustomer.Customer_Type_Id = Convert.ToInt32(custype);
        objEntityCustomer.Cancel_Status = Convert.ToInt32(CnclSts);
        objEntityCustomer.Organisation_Id = Convert.ToInt32(orgID);
        objEntityCustomer.CorpId = Convert.ToInt32(corptID);
        DataTable dtUser = new DataTable();
        dtUser = objBusinessLayerCustomer.Read_Customer_List_BySearch(objEntityCustomer);

        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.CUSTOMER_MASTER_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CUSTOMER_MASTER_PDF);

        objEntityCommon.CorporateID = Convert.ToInt32(corptID);
        objEntityCommon.Organisation_Id = Convert.ToInt32(orgID);
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "CustomerMasterList_" + corptID + "_" + strNextNumber + ".pdf";

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
                if (custype != "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("CUSTOMER TYPE ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(cus, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                }

                footrtable.AddCell(new PdfPCell(new Phrase("STATUS  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (Status == "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Inactive", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                else if (Status == "1")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Active", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                else
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("All", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
               
                footrtable.AddCell(new PdfPCell(new Phrase("CANCELLED STATUS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (CnclSts == "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Not Cancelled", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Cancelled", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }

                document.Add(footrtable);


                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(5);
                float[] footrsBody = { 20,30, 20,20,10 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("CUSTOMER NAME", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("CUSTOMER ADDRESS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("CUSTOMER GROUP", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("CUSTOMER TYPE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("CUSTOMER REF#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
               
                string strRandom = objCommon.Random_Number();


                if (dtUser.Rows.Count > 0)
                {
                    for (int intRowBodyCount = 0; intRowBodyCount < dtUser.Rows.Count; intRowBodyCount++)
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][1].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][2].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][3].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][4].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][5].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                  
                    }
                }
                else
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase(" No data available in table", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 5});
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
            headtable.AddCell(new PdfPCell(new Phrase("CUSTOMER MASTER LIST ", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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







    //    txtCnclReason.Attributes.Add("onkeypress", "return isTag(event)");
    //    txtCustomerName.Attributes.Add("onkeypress", "return isTag(event)");

    //    if (!IsPostBack)
    //    {
    //        if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
    //        {
    //            string strHidden = Request.QueryString["Srch"].ToString();
    //            HiddenSearchField.Value = strHidden;

    //            string[] strSearchFields = strHidden.Split(',');
    //            string strSearchWord = strSearchFields[0];
    //            string strddlStatus = strSearchFields[1];
    //            string strCbxStatus = strSearchFields[2];

    //            if (strSearchWord != null && strSearchWord != "")
    //            {

    //                txtCustomerName.Text = strSearchWord;
    //            }
    //            else
    //            {
    //                txtCustomerName.Text = "";
    //            }
    //            if (strddlStatus != null && strddlStatus != "")
    //            {
    //                if (ddlStatus.Items.FindByValue(strddlStatus) != null)
    //                {
    //                    ddlStatus.Items.FindByValue(strddlStatus).Selected = true;
    //                }
    //            }
    //            if (strCbxStatus == "1")
    //            {
    //                cbxCnclStatus.Checked = true;
    //            }
    //            else
    //            {
    //                cbxCnclStatus.Checked = false;
    //            }

    //        }
    //        Page_Load();
    //    }

    //}  //It build the Html table by using the datatable provided
    //public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel)
    //{

    //    int first = Convert.ToInt32(hiddenPrevious.Value);

    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    string strRandom = objCommon.Random_Number();

    //    // class="table table-bordered table-striped"
    //    StringBuilder sb = new StringBuilder();
    //    string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
    //    //add header row
    //    strHtml += "<thead>";
    //    strHtml += "<tr class=\"main_table_head\">";
    //    strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";
    //    for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
    //    {
    //        //if (i == 0)
    //        //{
    //        //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
    //        //}
    //        if (intColumnHeaderCount == 1)
    //        {
    //            strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">" + "CUSTOMER NAME" + "</th>";
    //        }
    //        if (intColumnHeaderCount == 2)
    //        {
    //            strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">" + "CUSTOMER ADDRESS" + "</th>";
    //        }
    //        else if (intColumnHeaderCount == 3)
    //        {
    //            strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">" + "CUSTOMER GROUP" + "</th>";
    //        }
    //        else if (intColumnHeaderCount == 4)
    //        {
    //            strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">" + "CUSTOMER TYPE" + "</th>";
    //        }
    //        else if (intColumnHeaderCount == 5)
    //        {
    //            strHtml += "<th class=\"thT\"  style=\"width:6%;text-align: center; word-wrap:break-word;\">" + "STATUS" + "</th>";
    //        }
    //        else if (intColumnHeaderCount == 8)
    //        {
    //            strHtml += "<th class=\"thT\"  style=\"width:12%;text-align: center; word-wrap:break-word;\">" + "CUSTOMER REF#" + "</th>";
    //        }




    //    }

    //    if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
    //    {
    //        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";
    //    }

    //    if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
    //    {
    //        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";
    //    }


    //    strHtml += "</tr>";
    //    strHtml += "</thead>";
    //    //add rows

    //    strHtml += "<tbody>";
    //    for (int intRowBodyCount = first; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
    //    {

    //        int intMemoryBytes = System.Text.ASCIIEncoding.Unicode.GetByteCount(strHtml);

    //        if (hiddenTotalRowCount.Value == "")
    //        {
    //            if (hiddenMemorySize.Value != "")
    //            {
    //                if (intMemoryBytes >= Convert.ToInt64(hiddenMemorySize.Value))
    //                {
    //                    hiddenTotalRowCount.Value = intRowBodyCount.ToString();
    //                    hiddenNext.Value = hiddenTotalRowCount.Value;
    //                    btnNext.Enabled = true;
    //                    break;
    //                }
    //                else
    //                {

    //                    int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
    //                    int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());
    //                    string strLdgrSts = dt.Rows[intRowBodyCount]["LDGR_ID"].ToString();
    //                    strHtml += "<tr  >";

    //                    //FOR CANCELED COLUMN IDENTIFICATION ICON
    //                    if (intCnclUsrId == 0)
    //                    {
    //                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
    //                    }
    //                    else
    //                    {
    //                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" +
    //                                 "<img   src='../../Images/Icons/cancel.png' /> " + " </td>";
    //                    }
    //                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
    //                    {
    //                        //if (j == 0)
    //                        //{
    //                        //    int intCnt = i + 1;
    //                        //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
    //                        //}
    //                        if (intColumnBodyCount == 1)
    //                        {
    //                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //                        }
    //                        if (intColumnBodyCount == 2)
    //                        {
    //                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //                        }
    //                        else if (intColumnBodyCount == 3)
    //                        {
    //                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //                        }
    //                        else if (intColumnBodyCount == 4)
    //                        {
    //                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //                        }
    //                        else if (intColumnBodyCount == 5)
    //                        {
    //                            strHtml += "<td class=\"tdT\" style=\" width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //                        }
    //                        else if (intColumnBodyCount == 8)
    //                        {
    //                            strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //                        }

    //                    }


    //                    string strId = dt.Rows[intRowBodyCount][0].ToString();
    //                    int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
    //                    string stridLength = intIdLength.ToString("00");
    //                    string Id = stridLength + strId + strRandom;



    //                    if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
    //                    {
    //                        if (intCnclUsrId == 0)
    //                        {


    //                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return getdetails(this.href);' " +
    //                                  " href=\"gen_Customer_Master.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='../../Images/Icons/edit.png' /> " + "</a> </td>";




    //                        }

    //                        else
    //                        {
    //                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return getdetails(this.href);' " +
    //                             " href=\"gen_Customer_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='../../Images/Icons/view.png' /> " + "</a> </td>";


    //                        }
    //                    }
    //                    if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
    //                    {
    //                        if (intCnclUsrId == 0)
    //                        {
    //                            if (intCancTransaction == 0)
    //                            {
    //                                if (HiddenSearchField.Value == "")
    //                                {

    //                                    if (dt.Rows[intRowBodyCount]["SAL_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["PAY_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["RCPT_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["BUDGT_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["PAY_CST_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["RCPT_CST_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["BUDGT_CST_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["DR_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["CR_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["JRNL_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["ACCSET_LED_ID"].ToString() != "0")
    //                                    {
    //                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >"
    //                                                                                 + "<img style=\"opacity: 0.2;cursor: pointer; \" src='../../Images/Icons/delete.png' /> " + "</a> </td>";

    //                                    }
    //                                    else
    //                                    {


    //                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelAlert(this.href);' " +
    //                                         " href=\"gen_Customer_MasterList.aspx?Id=" + Id + "\">" + "<img  src='../../Images/Icons/delete.png' /> " + "</a> </td>";
    //                                    }
    //                                    }
    //                                else
    //                                {
    //                                    if (dt.Rows[intRowBodyCount]["SAL_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["PAY_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["RCPT_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["BUDGT_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["PAY_CST_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["RCPT_CST_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["BUDGT_CST_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["DR_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["CR_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["JRNL_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["ACCSET_LED_ID"].ToString() != "0")
    //                                    {
    //                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >"
    //                                                                                 + "<img style=\"opacity: 0.2;cursor: pointer; \" src='../../Images/Icons/delete.png' /> " + "</a> </td>";

    //                                    }
    //                                    else
    //                                    {


    //                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelAlert(this.href);' " +
    //                                         " href=\"gen_Customer_MasterList.aspx?Id=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='../../Images/Icons/delete.png' /> " + "</a> </td>";
    //                                    }
                                        
    //                                    }
    //                            }
    //                            else 
    //                            {

    //                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >"
    //                                        + "<img style=\"opacity: 0.2;cursor: pointer; \" src='../../Images/Icons/delete.png' /> " + "</a> </td>";

    //                            }



    //                        }
    //                        else
    //                        {

    //                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
    //                        }
    //                    }
    //                    strHtml += "</tr>";


    //                }
    //            }
    //        }
    //        else
    //        {
    //            if (hiddenNext.Value == "")
    //            {
    //                hiddenNext.Value = hiddenTotalRowCount.Value;
    //            }
    //            int last = Convert.ToInt32(hiddenNext.Value);
    //            if (intRowBodyCount < last)
    //            {


    //                int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
    //                int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());
    //                string strLdgrSts = dt.Rows[intRowBodyCount]["LDGR_ID"].ToString();
    //                strHtml += "<tr  >";

    //                //FOR CANCELED COLUMN IDENTIFICATION ICON
    //                if (intCnclUsrId == 0)
    //                {
    //                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
    //                }
    //                else
    //                {
    //                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" +
    //                             "<img   src='../../Images/Icons/cancel.png' /> " + " </td>";
    //                }
    //                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
    //                {
    //                    //if (j == 0)
    //                    //{
    //                    //    int intCnt = i + 1;
    //                    //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
    //                    //}
    //                    if (intColumnBodyCount == 1)
    //                    {
    //                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //                    }
    //                    if (intColumnBodyCount == 2)
    //                    {
    //                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //                    }
    //                    else if (intColumnBodyCount == 3)
    //                    {
    //                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //                    }
    //                    else if (intColumnBodyCount == 4)
    //                    {
    //                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //                    }
    //                    else if (intColumnBodyCount == 5)
    //                    {
    //                        strHtml += "<td class=\"tdT\" style=\" width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //                    }
    //                    else if (intColumnBodyCount == 8)
    //                    {
    //                        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //                    }

    //                }


    //                string strId = dt.Rows[intRowBodyCount][0].ToString();
    //                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
    //                string stridLength = intIdLength.ToString("00");
    //                string Id = stridLength + strId + strRandom;



    //                if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
    //                {
    //                    if (intCnclUsrId == 0)
    //                    {

    //                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return getdetails(this.href);' " +
    //                              " href=\"gen_Customer_Master.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='../../Images/Icons/edit.png' /> " + "</a> </td>";

    //                    }

    //                    else
    //                    {
    //                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return getdetails(this.href);' " +
    //                         " href=\"gen_Customer_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='../../Images/Icons/view.png' /> " + "</a> </td>";


    //                    }
    //                }
    //                if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
    //                {
    //                    if (intCnclUsrId == 0)
    //                    {
    //                        if (intCancTransaction == 0 )
    //                        {
    //                            if (HiddenSearchField.Value == "")
    //                            {
    //                                if (dt.Rows[intRowBodyCount]["SAL_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["PAY_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["RCPT_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["BUDGT_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["PAY_CST_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["RCPT_CST_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["BUDGT_CST_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["DR_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["CR_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["JRNL_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["ACCSET_LED_ID"].ToString() != "0")
    //                                {
    //                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >"
    //                                                                             + "<img style=\"opacity: 0.2;cursor: pointer; \" src='../../Images/Icons/delete.png' /> " + "</a> </td>";

    //                                }
    //                                else
    //                                {
    //                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelAlert(this.href);' " +
    //                                     " href=\"gen_Customer_MasterList.aspx?Id=" + Id + "\">" + "<img  src='../../Images/Icons/delete.png' /> " + "</a> </td>";
    //                                }
                                     
                                     
    //                                 }
    //                            else
    //                            {
    //                                if (dt.Rows[intRowBodyCount]["SAL_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["PAY_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["RCPT_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["BUDGT_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["PAY_CST_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["RCPT_CST_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["BUDGT_CST_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["DR_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["CR_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["JRNL_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["ACCSET_LED_ID"].ToString() != "0")
    //                                {
    //                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >"
    //                                                                             + "<img style=\"opacity: 0.2;cursor: pointer; \" src='../../Images/Icons/delete.png' /> " + "</a> </td>";

    //                                }
    //                                else
    //                                {

    //                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelAlert(this.href);' " +
    //                                     " href=\"gen_Customer_MasterList.aspx?Id=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='../../Images/Icons/delete.png' /> " + "</a> </td>";
    //                                }
                                     
    //                                 }
    //                        }
    //                        else
    //                        {

    //                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >"
    //                                    + "<img style=\"opacity: 0.2;cursor: pointer; \" src='../../Images/Icons/delete.png' /> " + "</a> </td>";

    //                        }



    //                    }
    //                    else
    //                    {

    //                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
    //                    }
    //                }
    //                strHtml += "</tr>";
    //            }
    //            else
    //            {
    //                btnNext.Enabled = true;
    //            }

    //        }

    //    }

    //    strHtml += "</tbody>";

    //    strHtml += "</table>";

    //    sb.Append(strHtml);
    //    return sb.ToString();
    //}
    ////for creating HTML Title
    //private string SetTitle(string size, string value)
    //{

    //    return "<h" + size + "><p align=center>" + value + "</p align></h" + size + ">";

    //}

    //protected void btnRsnSave_Click(object sender, EventArgs e)
    //{

    //    //Creating objects for business layer
    //    clsBusinessLayerCustomer objBusinessLayerCustomer = new clsBusinessLayerCustomer();
    //    clsEntityCustomer objEntityCustomer = new clsEntityCustomer();

    //    if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
    //    {
    //        objEntityCustomer.Customer_Id = Convert.ToInt32(hiddenRsnid.Value);


    //        if (Session["USERID"] != null)
    //        {
    //            objEntityCustomer.UserId = Convert.ToInt32(Session["USERID"]);

    //        }
    //        else if (Session["USERID"] == null)
    //        {
    //            Response.Redirect("~/Default.aspx");
    //        }

    //        objEntityCustomer.Date = System.DateTime.Now;

    //        objEntityCustomer.Cancel_Reason = txtCnclReason.Text.Trim();
    //        objBusinessLayerCustomer.CancelCustomerMaster(objEntityCustomer);

    //        if (HiddenSearchField.Value == "")
    //        {
    //            Response.Redirect("gen_Customer_MasterList.aspx?InsUpd=Cncl");
    //        }
    //        else
    //        {
    //            Response.Redirect("gen_Customer_MasterList.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
    //        }


    //    }
    //}

    //    //at search button click
    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
    //    Page_Load();
    //}

    //    //at next records show button click
    //protected void btnNext_Click(object sender, EventArgs e)
    //{
    //    Set_Table(Convert.ToInt32(Button_type.Next));
    //}

    //    //at previous records show button click
    //protected void btnPrevious_Click(object sender, EventArgs e)
    //{
    //    Set_Table(Convert.ToInt32(Button_type.Previous));
    //}



    ////prepare table set datatable
    //public void Set_Table(int intButtonId)
    //{
    //    int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
    //    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

    //    //Allocating child roles

    //    if (hiddenRoleAdd.Value == "1")
    //    {
    //        intEnableAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
    //    }
    //    if (hiddenRoleUpdate.Value == "1")
    //    {
    //        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
    //    }
    //    if (hiddenRoleCancel.Value == "1")
    //    {
    //        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
    //    }

    //    if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
    //    {
    //        divAdd.Visible = true;

    //    }
    //    else
    //    {

    //        divAdd.Visible = false;

    //    }

    //    //Creating objects for business layer
        //clsBusinessLayerCustomer objBusinessLayerCustomer = new clsBusinessLayerCustomer();
        //clsEntityCustomer objEntityCustomer = new clsEntityCustomer();
    //    int intCorpId = 0;
    //    if (Session["CORPOFFICEID"] != null)
    //    {
    //        objEntityCustomer.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
    //        intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

    //    }
    //    else if (Session["CORPOFFICEID"] == null)
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }
    //    if (Session["ORGID"] != null)
    //    {
    //        objEntityCustomer.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
    //    }
    //    else if (Session["ORGID"] == null)
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }

        //DataTable dtCustomer = new DataTable();
    //    if (HiddenSearchField.Value == "")
    //    {
    //        objEntityCustomer.Customer_Status = 1;
    //        objEntityCustomer.Cancel_Status = 0;
        //dtCustomer = objBusinessLayerCustomer.Read_Customer_List_BySearch(objEntityCustomer);
    //    }
    //    else
    //    {
    //        string strHidden = "";
    //        strHidden = HiddenSearchField.Value;
    //        string[] strSearchFields = strHidden.Split(',');
    //        string strSearchWord = strSearchFields[0];
    //        string strddlStatus = strSearchFields[1];
    //        string strCbxStatus = strSearchFields[2];

    //        objEntityCustomer.Customer_Name = strSearchWord;
    //        objEntityCustomer.Customer_Status = Convert.ToInt32(strddlStatus);
    //        objEntityCustomer.Cancel_Status = Convert.ToInt32(strCbxStatus);
    //        dtCustomer = objBusinessLayerCustomer.Read_Customer_List_BySearch(objEntityCustomer);
    //    }

    //    int first = 0;
    //    int last = 0;

    //    if (intButtonId == Convert.ToInt32(Button_type.Next))
    //    {
    //        first = Convert.ToInt32(hiddenNext.Value);
    //        last = Convert.ToInt32(hiddenNext.Value) + Convert.ToInt32(hiddenTotalRowCount.Value);
    //        hiddenPrevious.Value = first.ToString();
    //        hiddenNext.Value = last.ToString();
    //    }

    //    if (intButtonId == Convert.ToInt32(Button_type.Previous))
    //    {
    //        first = Convert.ToInt32(hiddenPrevious.Value) - Convert.ToInt32(hiddenTotalRowCount.Value);
    //        last = Convert.ToInt32(hiddenPrevious.Value);
    //        hiddenPrevious.Value = first.ToString();
    //        hiddenNext.Value = last.ToString();
    //    }
    //    if (first == 0)
    //    {
    //        btnPrevious.Enabled = false;

    //    }
    //    else
    //    {
    //        btnPrevious.Enabled = true;
    //    }
    //    if (last < dtCustomer.Rows.Count)
    //    {

    //        btnNext.Enabled = true;
    //    }
    //    else
    //    {
    //        btnNext.Enabled = false;
    //    }

    //    string strHtm = ConvertDataTableToHTML(dtCustomer, intEnableModify, intEnableCancel);
    //    //Write to divReport
    //    divReport.InnerHtml = strHtm;
    //}



    ////the methode needs to perform on the initial stage of page
    //private void Page_Load()
    //{

    //    btnNext.Enabled = false;
    //    btnPrevious.Enabled = false;
    //    int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intAcntSpecific = 0, intBusinessSpecific = 0;
    //    hiddenRoleAdd.Value = "0";
    //    hiddenRoleUpdate.Value = "0";
    //    hiddenRoleCancel.Value = "0";
    //    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    if (Session["USERID"] != null)
    //    {
    //        intUserId = Convert.ToInt32(Session["USERID"]);

    //    }
    //    else if (Session["USERID"] == null)
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }
    //    //Allocating child roles
    //    intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Customer_Master);
    //    DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

    //    if (dtChildRol.Rows.Count > 0)
    //    {
    //        string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

    //        string[] strChildDefArrWords = strChildRolDeftn.Split('-');
    //        foreach (string strC_Role in strChildDefArrWords)
    //        {
    //            if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
    //            {
    //                intEnableAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
    //                hiddenRoleAdd.Value = "1";
    //            }
    //            else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
    //            {
    //                intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
    //                hiddenRoleUpdate.Value = "1";
    //            }
    //            else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
    //            {
    //                intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
    //                hiddenRoleCancel.Value = "1";

    //            }
    //            else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString())
    //            {
    //                //future

    //            }
    //            else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString())
    //            {
    //                //future

    //            }
    //            else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
    //            {
    //                //future

    //            }
    //            else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.BUSINESS_SPECIFIC).ToString())
    //            {
    //                intBusinessSpecific = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
    //            }
    //            if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ACCOUNT_SPECIFIC).ToString())
    //            {
    //                intAcntSpecific = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
    //            }

    //        }

    //        if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
    //        {
    //            divAdd.Visible = true;

    //        }
    //        else
    //        {

    //            divAdd.Visible = false;

    //        }



    //        if ((intBusinessSpecific != Convert.ToInt32(clsCommonLibrary.StatusAll.Active)) && (intAcntSpecific == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
    //        {
    //            divAdd.Visible = false;
    //        }
    //        //Creating objects for business layer
    //        clsBusinessLayerCustomer objBusinessCustomer = new clsBusinessLayerCustomer();
    //        clsEntityCustomer objEntityCustomer = new clsEntityCustomer();
    //        int intCorpId = 0;
    //        if (Session["CORPOFFICEID"] != null)
    //        {
    //            objEntityCustomer.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
    //            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

    //        }
    //        else if (Session["CORPOFFICEID"] == null)
    //        {
    //            Response.Redirect("~/Default.aspx");
    //        }
    //        if (Session["ORGID"] != null)
    //        {
    //            objEntityCustomer.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
    //        }
    //        else if (Session["ORGID"] == null)
    //        {
    //            Response.Redirect("~/Default.aspx");
    //        }

    //        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
    //                                                       clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
    //                                                       clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE
    //                                                          };
    //        DataTable dtCorpDetail = new DataTable();
    //        dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
    //        if (dtCorpDetail.Rows.Count > 0)
    //        {
                
    //            string strListingMode = dtCorpDetail.Rows[0]["LISTING_MODE"].ToString();
    //            string strLstingModeSize = dtCorpDetail.Rows[0]["LISTING_MODE_SIZE"].ToString();

    //            int intListingMode = Convert.ToInt32(strListingMode);

    //            if (intListingMode == 2)//variant
    //            {
    //                btnNext.Text = "Show Next Records";
    //                btnPrevious.Text = "Show Previous Records";
    //                hiddenMemorySize.Value = strLstingModeSize;
    //            }
    //            else if (intListingMode == 1)//fixed
    //            {
    //                btnNext.Text = "Show Next " + strLstingModeSize + " Records";
    //                btnPrevious.Text = "Show Previous " + strLstingModeSize + " Records";
    //                hiddenTotalRowCount.Value = strLstingModeSize;
    //                hiddenNext.Value = strLstingModeSize;
    //            }
    //            hiddenPrevious.Value = "0";

    //        }


    //        if (Request.QueryString["Id"] != null)
    //        {//when Canceled

    //            string strRandomMixedId = Request.QueryString["Id"].ToString();
    //            string strLenghtofId = strRandomMixedId.Substring(0, 2);
    //            int intLenghtofId = Convert.ToInt16(strLenghtofId);
    //            string strId = strRandomMixedId.Substring(2, intLenghtofId);

    //            objEntityCustomer.Customer_Id = Convert.ToInt32(strId);
    //            objEntityCustomer.UserId = intUserId;

    //            objEntityCustomer.Date = System.DateTime.Now;


    //            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
    //            if (dtCorpDetail.Rows.Count > 0)
    //            {
    //                string strListingMode = dtCorpDetail.Rows[0]["LISTING_MODE"].ToString();
    //                string strLstingModeSize = dtCorpDetail.Rows[0]["LISTING_MODE_SIZE"].ToString();
    //                string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
    //                if (CnclrsnMust == "0")
    //                {
    //                    objEntityCustomer.Cancel_Reason = objCommon.CancelReason();

    //                    objBusinessCustomer.CancelCustomerMaster(objEntityCustomer);

    //                    if (HiddenSearchField.Value == "")
    //                        Response.Redirect("gen_Customer_MasterList.aspx?InsUpd=Cncl");
    //                    else
    //                        Response.Redirect("gen_Customer_MasterList.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);


    //                }
    //                else
    //                {

    //                    DataTable dtCustomer = new DataTable();
    //                    if (HiddenSearchField.Value == "")
    //                    {
    //                        objEntityCustomer.Customer_Status = 1;
    //                        objEntityCustomer.Cancel_Status = 0;
    //                        dtCustomer = objBusinessCustomer.Read_Customer_List_BySearch(objEntityCustomer);
    //                    }
    //                    else
    //                    {
    //                        string strHidden = "";
    //                        strHidden = HiddenSearchField.Value;
    //                        string[] strSearchFields = strHidden.Split(',');
    //                        string strSearchWord = strSearchFields[0];
    //                        string strddlStatus = strSearchFields[1];
    //                        string strCbxStatus = strSearchFields[2];

    //                        objEntityCustomer.Customer_Name = strSearchWord;
    //                        objEntityCustomer.Customer_Status = Convert.ToInt32(strddlStatus);
    //                        objEntityCustomer.Cancel_Status = Convert.ToInt32(strCbxStatus);
    //                        dtCustomer = objBusinessCustomer.Read_Customer_List_BySearch(objEntityCustomer);
    //                    }

    //                    string strHtm = ConvertDataTableToHTML(dtCustomer, intEnableModify, intEnableCancel);
    //                    //Write to divReport
    //                    divReport.InnerHtml = strHtm;

    //                    hiddenRsnid.Value = strId;
    //                    ModalPopupExtenderCncl.Show();

    //                }

    //            }



    //        }
    //        else
    //        {
    //            //to view
    //            DataTable dtCustomer = new DataTable();
    //            if (HiddenSearchField.Value == "")
    //            {
    //                objEntityCustomer.Customer_Status = 1;
    //                objEntityCustomer.Cancel_Status = 0;
    //                dtCustomer = objBusinessCustomer.Read_Customer_List_BySearch(objEntityCustomer);
    //            }
    //            else
    //            {
    //                string strHidden = "";
    //                strHidden = HiddenSearchField.Value;
    //                string[] strSearchFields = strHidden.Split(',');
    //                string strSearchWord = strSearchFields[0];
    //                string strddlStatus = strSearchFields[1];
    //                string strCbxStatus = strSearchFields[2];

    //                objEntityCustomer.Customer_Name = strSearchWord;
    //                objEntityCustomer.Customer_Status = Convert.ToInt32(strddlStatus);
    //                objEntityCustomer.Cancel_Status = Convert.ToInt32(strCbxStatus);
    //                dtCustomer = objBusinessCustomer.Read_Customer_List_BySearch(objEntityCustomer);
    //            }


    //            string strHtm = ConvertDataTableToHTML(dtCustomer, intEnableModify, intEnableCancel);
    //            //Write to divReport
    //            divReport.InnerHtml = strHtm;

    //            if (Request.QueryString["InsUpd"] != null)
    //            {
    //                string strInsUpd = Request.QueryString["InsUpd"].ToString();
    //                if (strInsUpd == "Ins")
    //                {
    //                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
    //                }
    //                else if (strInsUpd == "Upd")
    //                {
    //                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
    //                }
    //                else if (strInsUpd == "Cncl")
    //                {
    //                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
    //                }
    //            }
    //        }

    //    }
    //}

}