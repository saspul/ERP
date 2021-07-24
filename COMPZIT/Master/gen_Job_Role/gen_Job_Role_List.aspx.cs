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


public partial class Master_gen_Job_Role_gen_Job_Role_List : System.Web.UI.Page
{

    #region Enumerations;
    //Enumeration for identifying apllication typeid 
    private enum APPS
    {
        APP_ADMINSTRATION = 1,
        SALES_FORCE_AUTOMATION = 2,
        AUTO_WORKSHOP_MANAGEMENT_SYSTEM = 3,
        GUARANTEE_MANAGEMENT_SYSTEM = 4,
        HUMAN_CAPITAL_MANAGEMENT = 5
    }
    private enum USERLIMITED
    {
        ISLIMITED = 1,
        NOTLIMITED = 2

    }

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            //DesignationLoad();
            DropDownBind();
            //ddlDesignation.Focus();

           // DesignationLoad();

            //start new code
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intcorpid=0;
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
            if (Session["CORPOFFICEID"] != null)
            {
                intcorpid = Convert.ToInt32(Session["CORPOFFICEID"]);

            }
            else if (Session["CORPOFFICEID"] == null)
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


            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Job_role);

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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                    {
                        //future

                    }

                }

                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    myBtn.Visible = true;

                }
                else
                {

                    myBtn.Visible = false;

                }


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

               
            }



        }
    }



    public void DesignationLoad()
    {

        if (Session["ORGID"] != null)


            if (Session["USERID"] != null)
            {
                int UserId = Convert.ToInt32(Session["USERID"]);


                int orgID = Convert.ToInt32(Session["ORGID"].ToString());
                clsBusinessLayerEmpRoleAllocation objBusinessEmpRoleAllocation = new clsBusinessLayerEmpRoleAllocation();
                DataTable dtCountry = objBusinessEmpRoleAllocation.ReadDesignation(orgID, UserId);
                ddlDesignation.DataSource = dtCountry;
                ddlDesignation.DataTextField = "DSGN_NAME";
                ddlDesignation.DataValueField = "DSGN_ID";
                ddlDesignation.DataBind();
                ddlDesignation.Items.Insert(0, "--Select Designation--");
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
      //  html.Append("</br>");
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
                sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" onclick=\"SetOrderByValue(" + (Item + 1) + ")\" class=\"col-md-10 tr_l sorting_asc\" >JOB ROLE<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br>");
                sbSearchInputColumns.Append("<input type=\"text\" id=\"txtSearchColumn_" + Item + "\" autocomplete=\"off\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" placeholder=\"Job Role\" title=\" JOB ROLE\" >");
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
       
        JOB = 0
        
    }


     //Assign Designation from GN_DESG_TYPE table to dropdownlist.
     public void DropDownBind(string strDsgnTypeName = null)
     {


         int intUserAppAdminstrtn = 0, intUserComzitSFA = 0, intUserCompzitAWMS = 0, intUserCompzitGMS = 0, intUserId = 0;
         ddlDesignation.Items.Clear();
         clsEntityLayerJobRole objEntityJobRl = null;
         objEntityJobRl = new clsEntityLayerJobRole();
         DataTable dtDsgnTypeDetails = new DataTable();
         if (Session["DSGN_CONTROL"] == null)
         {
             Response.Redirect("../../Default.aspx");

         }
         else
         {
             objEntityJobRl.DsgControl = Convert.ToChar(Session["DSGN_CONTROL"].ToString());
         }
         if (Session["ORGID"] != null)
         {
             objEntityJobRl.DsgnOrgId = Convert.ToInt32(Session["ORGID"].ToString());

         }
         else if (Session["ORGID"] == null)
         {
             Response.Redirect("~/Default.aspx");
         }
         if (Session["DSGN_TYPID"] != null)
         {
             objEntityJobRl.DesignationTypeId = Convert.ToInt32(Session["DSGN_TYPID"].ToString());

         }
         else if (Session["DSGN_TYPID"] == null)
         {
             Response.Redirect("../../Default.aspx");
         }
         if (Session["USERID"] != null)
         {
             objEntityJobRl.UserID = Convert.ToInt32(Session["USERID"]);
             intUserId = Convert.ToInt32(Session["USERID"]);
         }
         else if (Session["USERID"] == null)
         {
             Response.Redirect("~/Default.aspx");
         }



         clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
         DataTable dtUserAppRole = new DataTable();
         dtUserAppRole = objBusinessLayer.ReadUserAppRoleByUserId(intUserId);

         for (int intRowCountUserAppRole = 0; intRowCountUserAppRole < dtUserAppRole.Rows.Count; intRowCountUserAppRole++)
         {
             int intPrmntzId = Convert.ToInt32(dtUserAppRole.Rows[intRowCountUserAppRole]["PRTZAPP_ID"].ToString());
             if (intPrmntzId == Convert.ToInt32(APPS.APP_ADMINSTRATION))
             {
                 intUserAppAdminstrtn = 1;
             }
             else if (intPrmntzId == Convert.ToInt32(APPS.SALES_FORCE_AUTOMATION))
             {
                 intUserComzitSFA = 1;
             }
             else if (intPrmntzId == Convert.ToInt32(APPS.AUTO_WORKSHOP_MANAGEMENT_SYSTEM))
             {
                 intUserCompzitAWMS = 1;
             }
             else if (intPrmntzId == Convert.ToInt32(APPS.GUARANTEE_MANAGEMENT_SYSTEM))
             {
                 intUserCompzitGMS = 1;
             }
         }
         //BL
         clsBusinessLayerJobRole objBusinessLayerJobRole = new clsBusinessLayerJobRole();
         dtDsgnTypeDetails = objBusinessLayerJobRole.ReadDsgnDetails(objEntityJobRl);

         for (int intRowBodyCount = 0; intRowBodyCount < dtDsgnTypeDetails.Rows.Count; intRowBodyCount++)
         {
             int intDsgnAppAdminstrtn = 0, intDsgnComzitSFA = 0, intDsgnCompzitAWMS = 0, intDsgnCompzitGMS = 0;
             int intDsgId = Convert.ToInt32(dtDsgnTypeDetails.Rows[intRowBodyCount]["DSGN_ID"].ToString());
             objEntityJobRl.DesignationId = intDsgId;
             DataTable dtDsgnAppRole = new DataTable();
             dtDsgnAppRole = objBusinessLayerJobRole.ReadDsgnAppRoleByDsgnId(objEntityJobRl);
             for (int intRowCountDsgnAppRole = 0; intRowCountDsgnAppRole < dtDsgnAppRole.Rows.Count; intRowCountDsgnAppRole++)
             {
                 int intPrmntzId = Convert.ToInt32(dtDsgnAppRole.Rows[intRowCountDsgnAppRole]["PRTZAPP_ID"].ToString());
                 if (intPrmntzId == Convert.ToInt32(APPS.APP_ADMINSTRATION))
                 {
                     intDsgnAppAdminstrtn = 1;
                 }
                 else if (intPrmntzId == Convert.ToInt32(APPS.SALES_FORCE_AUTOMATION))
                 {
                     intDsgnComzitSFA = 1;
                 }
                 else if (intPrmntzId == Convert.ToInt32(APPS.AUTO_WORKSHOP_MANAGEMENT_SYSTEM))
                 {
                     intDsgnCompzitAWMS = 1;
                 }
                 else if (intPrmntzId == Convert.ToInt32(APPS.GUARANTEE_MANAGEMENT_SYSTEM))
                 {
                     intDsgnCompzitGMS = 1;
                 }
             }
             if ((intUserAppAdminstrtn == intDsgnAppAdminstrtn || intUserAppAdminstrtn > intDsgnAppAdminstrtn) && (intUserComzitSFA == intDsgnComzitSFA || intUserComzitSFA > intDsgnComzitSFA) && (intUserCompzitAWMS == intDsgnCompzitAWMS || intUserCompzitAWMS > intDsgnCompzitAWMS) && (intUserCompzitGMS == intDsgnCompzitGMS || intUserCompzitGMS > intDsgnCompzitGMS))
             {
                 //bind one by one here

             }
             else
             {
                 DataRow dr = dtDsgnTypeDetails.Rows[intRowBodyCount];
                 dr.Delete();
             }

         }

         ddlDesignation.DataSource = dtDsgnTypeDetails;
         ddlDesignation.DataTextField = "DSGN_NAME";


         ddlDesignation.DataValueField = "DSGN_ID";
         ddlDesignation.DataBind();
         ddlDesignation.Items.Insert(0, "--SELECT--");
         if (strDsgnTypeName != null)
         {
             if (ddlDesignation.Items.FindByText(strDsgnTypeName) != null)
             {
                 ddlDesignation.Items.FindByText(strDsgnTypeName).Selected = true;
             }
         }
     }


    
     [WebMethod]
     public static string[] GetData(string OrgId, string CorpId, string ddlStatus, string CancelStatus, string EnableModify, string EnableCancel, string PageNumber, string PageMaxSize, string strCommonSearchTerm, string OrderColumn, string DsnContrl,string Usrid, string DsgnTyp, string OrderMethod, string strInputColumnSearch, string Divs)
     {

         clsBusinessLayerJobRole objBusinessLayerJobRole = new clsBusinessLayerJobRole();
         clsEntityLayerJobRole objEntityJobRol = new clsEntityLayerJobRole();
         clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

         string[] strResults = new string[3];

         if (OrgId != null && OrgId != "")
         {
             objEntityJobRol.DsgnOrgId = Convert.ToInt32(OrgId);
         }
         if (CorpId != null && CorpId != "")
         {
             objEntityJobRol.CorpOfficeId = Convert.ToInt32(CorpId);
         }
         objEntityJobRol.JobRoleStatus = Convert.ToInt32(ddlStatus);
         objEntityJobRol.Cancel_Status = Convert.ToInt32(CancelStatus);

         if (Divs != "--SELECT--")
         {

             objEntityJobRol.DesignationId = Convert.ToInt32(Divs);
         
         }

         //objEntityJobRol.Cancel_Status = 0;
         objEntityJobRol.UserID = Convert.ToInt32(Usrid);

         objEntityJobRol.DsgControl = Convert.ToChar(DsnContrl);
         objEntityJobRol.DesignationTypeId = Convert.ToInt32(DsgnTyp);

         objEntityJobRol.PageNumber = Convert.ToInt32(PageNumber);
         objEntityJobRol.PageMaxSize = Convert.ToInt32(PageMaxSize);
         objEntityJobRol.OrderMethod = Convert.ToInt32(OrderMethod);
         objEntityJobRol.OrderColumn = Convert.ToInt32(OrderColumn);
         int clumn = Convert.ToInt32(OrderColumn); ;

        
         objEntityJobRol.OrderColumn = clumn;
         objEntityJobRol.CommonSearchTerm = strCommonSearchTerm;

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

         objEntityJobRol.SearchJOB = strSearchInputs[Convert.ToInt32(SearchInputColumns.JOB)];
        


         //ReadList
         DataTable dt = objBusinessLayerJobRole.GridDisplayJobRolelist(objEntityJobRol);

         //  int intCancelStatus = Convert.ToInt32(CancelStatus);
         //int intEnableModify = Convert.ToInt32(EnableModify);
         //int intEnableCancel = Convert.ToInt32(EnableCancel);

         string strTableContents = "";
         strTableContents = ConvertDataTableToHTML(dt, objEntityJobRol,EnableModify, EnableCancel);
         strResults[0] = strTableContents;


         if (dt.Rows.Count > 0)
         {
             int intTotalItems = Convert.ToInt32(dt.Rows[0]["CNT"].ToString());
             int intCurrentRowCount = dt.Rows.Count;

             strResults[1] = intCurrentRowCount.ToString();

             //Pagination
             strResults[2] = objBusinessLayer.GenereatePagination(intTotalItems, objEntityJobRol.PageNumber, objEntityJobRol.PageMaxSize, intCurrentRowCount);
         }

         return strResults;
     }



     public static string ConvertDataTableToHTML(DataTable dt, clsEntityLayerJobRole objEntitypayrol,  string modifyenable, string cancelenable)
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
                 int Status = 0;

                 if (dt.Rows[intRowBodyCount]["STATUS"].ToString()=="ACTIVE")
                 {

                     Status = 1;
                 
                 }

                 int counttransc = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());


                 sb.Append("<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][1].ToString() + "</td>");
                // sb.Append("<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount]["PAYRL_CODE"].ToString() + "</td>");

               
                 




                 sb.Append("<td>");




                 if (modifyenable == "1" && objEntitypayrol.Cancel_Status == 0)
                 {
                     if (dt.Rows[intRowBodyCount]["STATUS"].ToString() == "ACTIVE")
                     {

                         //sb.Append("<a class=\"btn tab_but1 butn1 btn_sta\"  title=\"Change Status\" onclick='' " +
                         //                          " href=\"" + Id + "\"><i class=\"fa fa-check-circle\"></i></a>");

                         sb.Append("<a href=\"javascript:;\" class=\"btn tab_but1 butn1 btn_sta\" title=\"Change Status\"  onclick=\"return ChangeStatus('" + Id + "','" + Status + "');\"><i class=\"fa fa-check-circle\"></i></a>");
                     }

                     else
                     {

                         //sb.Append("<a class=\"btn tab_but1 butn4 btn_sti\" title=\"Change Status\" onclick='' " +
                         //                         " href=\"" + Id + "\"><i class=\"fa fa-times-circle\"></i></a>");

                         sb.Append("<a href=\"javascript:;\" class=\"btn tab_but1 butn4 btn_sti\" title=\"Change Status\"  onclick=\"return ChangeStatus('" + Id + "','" + Status + "');\"><i class=\"fa fa-times-circle\"></i></a>");

                     }
                     //sb.Append("<a class=\"btn act_btn bn1 bt_e\" title=\"Edit\" onclick='' " +
                     //                             " href=\"" + Id + "\"><i class=\"fa fa-edit\"></i></a>");

                     sb.Append("<a class=\"btn act_btn bn1 bt_e\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                                " href=\"gen_Job_Role.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>");
                 }

                 else
                 {


                     if (dt.Rows[intRowBodyCount]["STATUS"].ToString() == "ACTIVE" && objEntitypayrol.Cancel_Status == 1)
                     {

                        // sb.Append("<div class='btn_stl1'>");
                         sb.Append("<a class=\"btn tab_but1 butn1 btn_sta\" disabled=\"\" style='background-color: #8080805c;'  title=\"Change Status\" ><i class=\"fa fa-check-circle\"></i></a>");
                       //  sb.Append("</div>");



                     }

                     else if (objEntitypayrol.Cancel_Status == 1)
                     {

                        // sb.Append("<div class='btn_stl1'>");
                         sb.Append("<a class=\"btn tab_but1 butn4 btn_sti\" disabled=\"\" style='background-color: #8080805c;' title=\"Change Status\" ><i class=\"fa fa-times-circle\"></i></a>");

                        // sb.Append("</div>");




                     }
                     //sb.Append("<a class=\"btn act_btn bn4 bt_v\" title=\"View\" onclick='' " +
                     //                               " href=\"" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>");


                     sb.Append("<a class=\"btn act_btn bn4 bt_v\" title=\"View\" onclick='return getdetails(this.href);' " +
                                  " href=\"gen_Job_Role.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>");
                 }

                 if (cancelenable == "1" && counttransc == 0 && objEntitypayrol.Cancel_Status == 0)
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
     public static string PrintList(string OrgId, string CorpId, string ddlStatus, string CancelStatus, string Usrid, string DsnContrl, string DsgnTyp, string Divs)
     {

         


         clsBusinessLayerJobRole objBusinessLayerJobRole = new clsBusinessLayerJobRole();
         clsEntityLayerJobRole objEntityJobRol = new clsEntityLayerJobRole();
         clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

         clsEntityCommon objEntityCommon = new clsEntityCommon();
         clsBusinessLayer objBusiness = new clsBusinessLayer();
         // clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
         clsCommonLibrary objCommon = new clsCommonLibrary();


         if (OrgId != null && OrgId != "")
         {
             objEntityJobRol.DsgnOrgId = Convert.ToInt32(OrgId);
         }
         if (CorpId != null && CorpId != "")
         {
             objEntityJobRol.CorpOfficeId = Convert.ToInt32(CorpId);
         }
         objEntityJobRol.JobRoleStatus = Convert.ToInt32(ddlStatus);
         objEntityJobRol.Cancel_Status = Convert.ToInt32(CancelStatus);

         objEntityJobRol.UserID = Convert.ToInt32(Usrid);
         objEntityJobRol.DsgControl = Convert.ToChar(DsnContrl);

         if (Divs != "--SELECT--")
         {
             objEntityJobRol.DesignationId = Convert.ToInt32(Divs);

         }
         objEntityJobRol.DesignationTypeId = Convert.ToInt32(DsgnTyp);

         DataTable dt = objBusinessLayerJobRole.GridDisplayJobRole(objEntityJobRol);

         string strRet = "";
         string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.JOB_ROLE_PDF);
         objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.JOB_ROLE_PDF);

         objEntityCommon.CorporateID = Convert.ToInt32(CorpId);
         objEntityCommon.Organisation_Id = Convert.ToInt32(OrgId);
         string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
         string strImageName = "JOB_ROLE_" + CorpId + "_" + strNextNumber + ".pdf";

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

                 if (ddlStatus == "1")
                 {
                     footrtable.AddCell(new PdfPCell(new Phrase("ACTIVE", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                 }
                 else if (ddlStatus == "0")
                 {

                     footrtable.AddCell(new PdfPCell(new Phrase("INACTIVE", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                 }

                 else if (ddlStatus == "2")
                 {

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
                 PdfPTable TBCustomer = new PdfPTable(1);
                 float[] footrsBody = { 14};
                 TBCustomer.SetWidths(footrsBody);
                 TBCustomer.WidthPercentage = 100;
                 TBCustomer.HeaderRows = 1;

                 var FontGray = new BaseColor(138, 138, 138);
                 var FontColour = new BaseColor(134, 152, 160);
                 var FontSmallGray = new BaseColor(230, 230, 230);

                 TBCustomer.AddCell(new PdfPCell(new Phrase("JOB ROLE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                 

                 if (dt.Rows.Count > 0)
                 {
                     for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
                     {


                         TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount][1].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                         
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
             headtable.AddCell(new PdfPCell(new Phrase("JOB ROLE LIST ", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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
     public static string CancelReason(string strCnclId, string strCancelMust, string strUserID, string strCancelReason, string strOrgIdID, string strCorpID)
     {
         clsEntityLayerJobRole objEntityJobRl = new clsEntityLayerJobRole();

         clsBusinessLayerJobRole objBusinessLayerDsgnMaster = new clsBusinessLayerJobRole();

         clsCommonLibrary objCommon = new clsCommonLibrary();
         string strRets = "successcncl";
         string strRandomMixedId = strCnclId;

         string id = strRandomMixedId;
         string strLenghtofId = strRandomMixedId.Substring(0, 2);
         int intLenghtofId = Convert.ToInt16(strLenghtofId);
         string strId = strRandomMixedId.Substring(2, intLenghtofId);

         objEntityJobRl.JobRoleId = Convert.ToInt32(strId);
         objEntityJobRl.UserID = Convert.ToInt32(strUserID);
         objEntityJobRl.DsgnOrgId = Convert.ToInt32(strOrgIdID);
         objEntityJobRl.CorpOfficeId = Convert.ToInt32(strCorpID);
         if (strCancelMust == "1")
         {
             objEntityJobRl.DesignationCancelReason = strCancelReason;
         }

         else
         {
             objEntityJobRl.DesignationCancelReason = objCommon.CancelReason();
         }

         try
         {
             objBusinessLayerDsgnMaster.UpdateJobRlCancel(objEntityJobRl);
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
         clsEntityLayerJobRole objEntityJobRl = new clsEntityLayerJobRole();

         clsBusinessLayerJobRole objBusinessLayerDsgnMaster = new clsBusinessLayerJobRole();

         clsCommonLibrary objCommon = new clsCommonLibrary();
         string strRets = "successchng";
         string strRandomMixedId = strStsId;

         string id = strRandomMixedId;
         string strLenghtofId = strRandomMixedId.Substring(0, 2);
         int intLenghtofId = Convert.ToInt16(strLenghtofId);
         string strId = strRandomMixedId.Substring(2, intLenghtofId);

         objEntityJobRl.JobRoleId = Convert.ToInt32(strId);
         if (Status == "1")
         {
             objEntityJobRl.JobRoleStatus = 0;
         }
         else
         {
             objEntityJobRl.JobRoleStatus = 1;
         }
         try
         {
             objBusinessLayerDsgnMaster.CanclJobRl(objEntityJobRl);
         }
         catch
         {
             strRets = "failed";
         }

         return strRets;

     }


}
// //On not is post back
//        txtCnclReason.Attributes.Add("onkeypress", "return isTag(event)");
//        cbxCnclStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
//        if (!IsPostBack)
//        {
//            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0;
//            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
//            clsCommonLibrary objCommon = new clsCommonLibrary();
//            //Created objects for business layer
//            clsBusinessLayerJobRole objBusinessLayerJobRole = new clsBusinessLayerJobRole();
//            clsEntityLayerJobRole objEntityJobRol = new clsEntityLayerJobRole();
//            if (Session["USERID"] != null)
//            {
//                intUserId = Convert.ToInt32(Session["USERID"]);
//                objEntityJobRol.UserID = Convert.ToInt32(Session["USERID"]);
//            }
//            else if (Session["USERID"] == null)
//            {
//                Response.Redirect("~/Default.aspx");
//            }
//            //recall option enabled or not
          
//            int intUserRoleRecall = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
//            DataTable dtCancelRecall = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUserRoleRecall);
//            if (dtCancelRecall.Rows.Count > 0)
//            {
//                intEnableRecall = 1;
//                hiddenRoleRecall.Value = "1";
//            }
//            else
//            {
//                intEnableRecall = 0;
//                hiddenRoleRecall.Value = "0";
//            }
//            //Allocating child roles
//            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Job_role);

//            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

//            if (dtChildRol.Rows.Count > 0)
//            {
//                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

//                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
//                foreach (string strC_Role in strChildDefArrWords)
//                {
//                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
//                    {
//                        intEnableAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
//                    }
//                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
//                    {
//                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
//                    }
//                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
//                    {
//                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

//                    }
//                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString())
//                    {
//                        //future

//                    }
//                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString())
//                    {
//                        //future

//                    }
//                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
//                    {
//                        //future

//                    }
//                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
//                    {
//                        //future

//                    }

//                }

//                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
//                {
//                    divAdd.Visible = true;

//                }
//                else
//                {

//                    divAdd.Visible = false;

//                }


                


//                hiddenDsgnControlId.Value = "C";

//                if (Session["DSGN_CONTROL"] != null)
//                {
//                    hiddenDsgnControlId.Value = Session["DSGN_CONTROL"].ToString();
//                    objEntityJobRol.DsgControl = Convert.ToChar(Session["DSGN_CONTROL"].ToString());
//                }
//                else
//                {
//                    Response.Redirect("~/Default.aspx");
//                }

//                if (Session["ORGID"] != null)
//                {
//                    objEntityJobRol.DsgnOrgId = Convert.ToInt32(Session["ORGID"].ToString());

//                }
//                else if (Session["ORGID"] == null)
//                {
//                    Response.Redirect("../../Default.aspx");
//                }

//                if (Session["DSGN_TYPID"] != null)
//                {
//                    objEntityJobRol.DesignationTypeId = Convert.ToInt32(Session["DSGN_TYPID"].ToString());

//                }
//                else
//                {
//                    Response.Redirect("../../Default.aspx");
//                }
               
//                if (hiddenDsgnControlId.Value == "C" || hiddenDsgnControlId.Value == "c")
//                {

//                    if (Session["CORPOFFICEID"] != null)
//                    {

//                        objEntityJobRol.CorpOfficeId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

//                    }
//                    else if (Session["CORPOFFICEID"] == null)
//                    {
//                        Response.Redirect("~/Default.aspx");
//                    }
//                }
//                if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
//                {
//                    string strHidden = Request.QueryString["Srch"].ToString();
//                    hiddenSearchField.Value = strHidden;

//                    string[] strSearchFields = strHidden.Split('_');

//                    string strddlStatus = strSearchFields[0];
//                    string strCbxShowCancel = strSearchFields[1];





//                    if (strddlStatus != null && strddlStatus != "")
//                    {
//                        if (ddlStatus.Items.FindByValue(strddlStatus) != null)
//                        {
//                            ddlStatus.Items.FindByValue(strddlStatus).Selected = true;
//                        }
//                    }
//                    if (strCbxShowCancel == "1")
//                    {
//                        cbxCnclStatus.Checked = true;
//                    }
//                    else
//                    {
//                        cbxCnclStatus.Checked = false;
//                    }

//                }

//                //when recalled
//                if (Request.QueryString["ReId"] != null)
//                {
//                    string strRandomMixedId = Request.QueryString["ReId"].ToString();
//                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
//                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
//                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

//                    objEntityJobRol.JobRoleId = Convert.ToInt32(strId);
//                    objEntityJobRol.UserID = intUserId;

//                    objEntityJobRol.DsgnDate = System.DateTime.Now;

//                    DataTable dtJobRlDetails = objBusinessLayerJobRole.ReadJobRLMasterById(objEntityJobRol);
//                    string strName = "", strNameCount = "0";
//                    if (dtJobRlDetails.Rows.Count > 0)
//                    {

//                        strName = dtJobRlDetails.Rows[0]["JOB ROLE NAME"].ToString();
//                    }

//                    if (strName != "")
//                    {
//                        objEntityJobRol.JobRoleName = strName;
//                    }
//                    strNameCount = objBusinessLayerJobRole.CheckDupJobRlNameIns(objEntityJobRol);


//                    if (strNameCount == "0")
//                    {

//                        objBusinessLayerJobRole.ReCallJobRl(objEntityJobRol);

//                        Response.Redirect("gen_Job_Role_List.aspx?InsUpd=Recl");
//                    }
//                    else
//                    {


//                        if (strNameCount != "0")
//                        {
//                            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationJobRlName", "DuplicationJobRlName();", true);

//                        }
//                    }


//                }
//                if (Request.QueryString["Id"] != null)
//                {//when Canceled

//                    string strRandomMixedId = Request.QueryString["Id"].ToString();
//                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
//                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
//                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

//                    objEntityJobRol.JobRoleId = Convert.ToInt32(strId);
//                    objEntityJobRol.UserID = intUserId;

//                    objEntityJobRol.DsgnDate = System.DateTime.Now;

//                    if (hiddenDsgnControlId.Value == "C")
//                    {
//                        int intCorpId = 0;
//                        if (Session["CORPOFFICEID"] != null)
//                        {

//                            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

//                        }
//                        else if (Session["CORPOFFICEID"] == null)
//                        {
//                            Response.Redirect("~/Default.aspx");
//                        }

//                        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
//                                                              };
//                        DataTable dtCorpDetail = new DataTable();
//                        dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
//                        if (dtCorpDetail.Rows.Count > 0)
//                        {
//                            string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
//                            if (CnclrsnMust == "0")
//                            {
//                                objEntityJobRol.DesignationCancelReason = objCommon.CancelReason();
//                                objBusinessLayerJobRole.UpdateJobRlCancel(objEntityJobRol);
//                                if (hiddenSearchField.Value == "")
//                                {
//                                    Response.Redirect("gen_Job_Role_List.aspx?InsUpd=Cncl");
//                                }
//                                else
//                                {
//                                    Response.Redirect("gen_Job_Role_List.aspx?InsUpd=Cncl&Srch=" + this.hiddenSearchField.Value);

//                                }

//                            }
//                            else
//                            {

//                                DataTable dtDsgn = new DataTable();
//                                if (hiddenSearchField.Value == "")
//                                {
//                                    objEntityJobRol.JobRoleStatus = 1;
//                                    objEntityJobRol.Cancel_Status = 0;


//                                }
//                                else
//                                {
//                                    string strHidden = hiddenSearchField.Value;

//                                    string[] strSearchFields = strHidden.Split('_');

//                                    string strddlStatus = strSearchFields[0];
//                                    string strCbxShowCancel = strSearchFields[1];

//                                    objEntityJobRol.JobRoleStatus = Convert.ToInt32(strddlStatus);
//                                    objEntityJobRol.Cancel_Status = Convert.ToInt32(strCbxShowCancel);

//                                }
//                                dtDsgn = objBusinessLayerJobRole.GridDisplayJobRole(objEntityJobRol);

//                                string strHtm = ConvertDataTableToHTML(dtDsgn, intEnableModify, intEnableCancel, intUserId, intEnableRecall);
//                                //Write to divReport
//                                divReport.InnerHtml = strHtm;
//                                hiddenCancelPrimaryId.Value = strId;
//                                //    ScriptManager.RegisterStartupScript(this, GetType(), "OpenCancelView", "OpenCancelView("+strId+");", true);
//                                //  ModalPopupExtenderCncl.Show();

//                            }

//                        }

//                    }
//                    else
//                    {
//                        objEntityJobRol.DesignationCancelReason = objCommon.CancelReason();
//                        objBusinessLayerJobRole.UpdateJobRlCancel(objEntityJobRol);
//                        if (hiddenSearchField.Value == "")
//                        {
//                            Response.Redirect("gen_Job_Role_List.aspx?InsUpd=Cncl");
//                        }
//                        else
//                        {
//                            Response.Redirect("gen_Job_Role_List.aspx?InsUpd=Cncl&Srch=" + this.hiddenSearchField.Value);

//                        }

//                    }
//                }
//                else
//                {
//                    if (hiddenSearchField.Value == "")
//                    {
//                        objEntityJobRol.JobRoleStatus = 1;
//                        objEntityJobRol.Cancel_Status = 0;


//                    }
//                    else
//                    {
//                        string strHidden = hiddenSearchField.Value;

//                        string[] strSearchFields = strHidden.Split('_');

//                        string strddlStatus = strSearchFields[0];
//                        string strCbxShowCancel = strSearchFields[1];

//                        objEntityJobRol.JobRoleStatus = Convert.ToInt32(strddlStatus);
//                        objEntityJobRol.Cancel_Status = Convert.ToInt32(strCbxShowCancel);

//                    }
//                    DataTable dtDsgn = new DataTable();
//                    dtDsgn = objBusinessLayerJobRole.GridDisplayJobRole(objEntityJobRol);

//                    string strHtm = ConvertDataTableToHTML(dtDsgn, intEnableModify, intEnableCancel, intUserId, intEnableRecall);
//                    //Write to divReport
//                    divReport.InnerHtml = strHtm;

//                    if (Request.QueryString["InsUpd"] != null)
//                    {
//                        string strInsUpd = Request.QueryString["InsUpd"].ToString();
//                        if (strInsUpd == "Ins")
//                        {
//                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
//                        }
//                        else if (strInsUpd == "Upd")
//                        {
//                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
//                        }
//                        else if (strInsUpd == "Cncl")
//                        {
//                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
//                        }
//                        else if (strInsUpd == "Recl")
//                        {
//                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessRecall", "SuccessRecall();", true);
//                        }
//                    }
//                }

//            }
//            else
//            {
                
//                divAdd.Visible = false; 
//            }
//            DropDownBind();
//        }
//    }
//    //It build the Html table by using the datatable provided
//    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intUserId, int intEnableRecall)
//    {
//        int intUserAppAdminstrtn = 0, intUserComzitSFA = 0, intUserCompzitAWMS = 0, intUserCompzitGMS = 0, intUserCompzitHCM = 0;
//        clsCommonLibrary objCommon = new clsCommonLibrary();
//        string strRandom = objCommon.Random_Number();
//        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
//        clsBusinessLayerJobRole objBusinessLayerJobRole = new clsBusinessLayerJobRole();
//        clsEntityLayerJobRole objEntityJobRl = new clsEntityLayerJobRole();
//        DataTable dtUserAppRole = new DataTable();
//        dtUserAppRole = objBusinessLayer.ReadUserAppRoleByUserId(intUserId);

//        for (int intRowCountUserAppRole = 0; intRowCountUserAppRole < dtUserAppRole.Rows.Count; intRowCountUserAppRole++)
//        {
//            int intPrmntzId = Convert.ToInt32(dtUserAppRole.Rows[intRowCountUserAppRole]["PRTZAPP_ID"].ToString());
//            if (intPrmntzId == Convert.ToInt32(APPS.APP_ADMINSTRATION))
//            {
//                intUserAppAdminstrtn = 1;
//            }
//            else if (intPrmntzId == Convert.ToInt32(APPS.SALES_FORCE_AUTOMATION))
//            {
//                intUserComzitSFA = 1;
//            }
//            else if (intPrmntzId == Convert.ToInt32(APPS.AUTO_WORKSHOP_MANAGEMENT_SYSTEM))
//            {
//                intUserCompzitAWMS = 1;
//            }
//            else if (intPrmntzId == Convert.ToInt32(APPS.GUARANTEE_MANAGEMENT_SYSTEM))
//            {
//                intUserCompzitGMS = 1;
//            }
//            else if (intPrmntzId == Convert.ToInt32(APPS.HUMAN_CAPITAL_MANAGEMENT))
//            {
//                intUserCompzitHCM=1;
//            }

//        }
//        // class="table table-bordered table-striped"
//        StringBuilder sb = new StringBuilder();
//        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
//        //add header row
//        strHtml += "<thead>";
//        strHtml += "<tr class=\"main_table_head\">";

//        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
//        {
//            //if (i == 0)
//            //{
//            //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
//            //}
//            if (intColumnHeaderCount == 1)
//            {
//                strHtml += "<th class=\"thT\" style=\"width:70%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
//            }
//            if (intColumnHeaderCount == 2)
//            {
//                strHtml += "<th class=\"thT\" style=\"width:10%;text-align:center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
//            }
//            //else if (intColumnHeaderCount == 3)
//            //{
//            //    strHtml += "<th class=\"thT\"  style=\"width:7%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
//            //}




//        }

//        if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
//        {
//            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";
//        }
//        if (cbxCnclStatus.Checked == false)
//        {
//            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
//            {
//                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";
//            }
//        }
//        if (cbxCnclStatus.Checked == true)
//        {
//            if (intEnableRecall == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
//            {
//                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";
//            }
//        }


//        strHtml += "</tr>";
//        strHtml += "</thead>";
//        //add rows

//        strHtml += "<tbody>";
//        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
//        {
//            int intDsgnAppAdminstrtn = 0, intDsgnComzitSFA = 0, intDsgnCompzitAWMS = 0, intDsgnCompzitGMS = 0, intDsgnCompzitHCM=0;
//            int intDsgId = Convert.ToInt32(dt.Rows[intRowBodyCount]["JOBRL_ID"].ToString());
//            objEntityJobRl.JobRoleId = intDsgId;
//            DataTable dtDsgnAppRole = new DataTable();
//            dtDsgnAppRole = objBusinessLayerJobRole.ReadJobRlAppRoleByJobRl(objEntityJobRl);
//            for (int intRowCountDsgnAppRole = 0; intRowCountDsgnAppRole < dtDsgnAppRole.Rows.Count; intRowCountDsgnAppRole++)
//            {
//                int intPrmntzId = Convert.ToInt32(dtDsgnAppRole.Rows[intRowCountDsgnAppRole]["PRTZAPP_ID"].ToString());
//                if (intPrmntzId == Convert.ToInt32(APPS.APP_ADMINSTRATION))
//                {
//                    intDsgnAppAdminstrtn = 1;
//                }
//                else if (intPrmntzId == Convert.ToInt32(APPS.SALES_FORCE_AUTOMATION))
//                {
//                    intDsgnComzitSFA = 1;
//                }
//                else if (intPrmntzId == Convert.ToInt32(APPS.AUTO_WORKSHOP_MANAGEMENT_SYSTEM))
//                {
//                    intDsgnCompzitAWMS = 1;
//                }
//                else if (intPrmntzId == Convert.ToInt32(APPS.GUARANTEE_MANAGEMENT_SYSTEM))
//                {
//                    intDsgnCompzitGMS = 1;
//                }
//                else if (intPrmntzId == Convert.ToInt32(APPS.HUMAN_CAPITAL_MANAGEMENT))
//                {
//                    intDsgnCompzitHCM = 1;
//                }
//            }
//            if ((intUserAppAdminstrtn == intDsgnAppAdminstrtn || intUserAppAdminstrtn > intDsgnAppAdminstrtn) && (intUserComzitSFA == intDsgnComzitSFA || intUserComzitSFA > intDsgnComzitSFA) && (intUserCompzitAWMS == intDsgnCompzitAWMS || intUserCompzitAWMS > intDsgnCompzitAWMS) && (intUserCompzitGMS == intDsgnCompzitGMS || intUserCompzitGMS > intDsgnCompzitGMS) && (intUserCompzitHCM == intDsgnCompzitHCM || intUserCompzitHCM > intDsgnCompzitHCM))
//            {
          
//            //
//            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
//            int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

//            strHtml += "<tr  >";



//            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
//            {
//                //if (j == 0)
//                //{
//                //    int intCnt = i + 1;
//                //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
//                //}
//                if (intColumnBodyCount == 1)
//                {
//                    strHtml += "<td class=\"tdT\" style=\" width:70%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
//                }
//                if (intColumnBodyCount == 2)
//                {
//                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
//                }
//                //else if (intColumnBodyCount == 3)
//                //{
//                //    strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
//                //}

//            }


//            string strId = dt.Rows[intRowBodyCount][0].ToString();
//            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
//            string stridLength = intIdLength.ToString("00");
//            string Id = stridLength + strId + strRandom;



//            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
//            {
//                if (intCnclUsrId == 0)
//                {
//                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return getdetails(this.href);' " +
//                          " href=\"gen_Job_Role.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
//                }
//                else
//                {

//                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return getdetails(this.href);' " +
//                            " href=\"gen_Job_Role.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";
//                }
//            }
//            if (cbxCnclStatus.Checked == false)
//            {
//                if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
//                {

//                    if (intCnclUsrId == 0)
//                    {


//                        if (intCancTransaction == 0)
//                        {
//                            if (hiddenSearchField.Value == "")
//                            {
//                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelAlert(this.href);' " +
//                                 " href=\"gen_Job_Role_List.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
//                            }
//                            else
//                            {

//                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelAlert(this.href);' " +
//                                    " href=\"gen_Job_Role_List.aspx?Id=" + Id + "&Srch=" + this.hiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
//                            }
//                        }
//                        else
//                        {

//                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >" +
//                                    "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";

//                        }


//                    }

//                    else
//                    {

//                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
//                    }

//                }
//            }
//            if (cbxCnclStatus.Checked == true)
//            {
//                if (intEnableRecall == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
//                {
//                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return ReCallAlert(this.href);' " +
//                                   " href=\"gen_Job_Role_List.aspx?ReId=" + Id + "&Srch=" + this.hiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
//                }
//                }
//            strHtml += "</tr>";
//        }
//        }

//        strHtml += "</tbody>";

//        strHtml += "</table>";

//        sb.Append(strHtml);
//        return sb.ToString();

       
//    }

       
  
//    protected void btnSearch_Click(object sender, EventArgs e)
//    {
//        clsBusinessLayerJobRole objBusinessLayerJobRole = new clsBusinessLayerJobRole();
//        clsEntityLayerJobRole objEntityJobRol = new clsEntityLayerJobRole();
//        objEntityJobRol.JobRoleStatus = Convert.ToInt32(ddlStatus.SelectedItem.Value);
//        //int intCorpId = 0;
//        if (cbxCnclStatus.Checked == true)
//        {
//            objEntityJobRol.Cancel_Status = 1;
//        }
//        else
//        {
//            objEntityJobRol.Cancel_Status = 0;
//        }

//        //if (Session["CORPOFFICEID"] != null)
//        //{

//        //    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

//        //}
//        //else
//        //{
//        //    Response.Redirect("~/Default.aspx");
//        //}
//        if (Session["USERID"] != null)
//        {
//            objEntityJobRol.UserID = Convert.ToInt32(Session["USERID"]);

//        }
//        else if (Session["USERID"] == null)
//        {
//            Response.Redirect("~/Default.aspx");
//        }
//        if (Session["DSGN_CONTROL"] != null)
//        {

//            objEntityJobRol.DsgControl = Convert.ToChar(Session["DSGN_CONTROL"].ToString());
//        }
//        else
//        {
//            Response.Redirect("~/Default.aspx");
//        }

//        if (Session["ORGID"] != null)
//        {
//            objEntityJobRol.DsgnOrgId = Convert.ToInt32(Session["ORGID"].ToString());

//        }
//        else
//        {
//            Response.Redirect("../../Default.aspx");
//        }
//        if (Session["DSGN_TYPID"] != null)
//        {
//            objEntityJobRol.DesignationTypeId = Convert.ToInt32(Session["DSGN_TYPID"].ToString());

//        }
//        else
//        {
//            Response.Redirect("../../Default.aspx");
//        }
//        if (hiddenDsgnControlId.Value == "C" || hiddenDsgnControlId.Value == "c")
//        {

//            if (Session["CORPOFFICEID"] != null)
//            {

//                objEntityJobRol.CorpOfficeId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

//            }
//            else if (Session["CORPOFFICEID"] == null)
//            {
//                Response.Redirect("~/Default.aspx");
//            }
//        }
//        if (ddlDesignation.SelectedValue == "--SELECT--")
//        {
            
//        }
//        else
//        {
//            objEntityJobRol.DesignationId = Convert.ToInt32(ddlDesignation.SelectedValue);
//        }
//        DataTable dtDsgn = new DataTable();
//        dtDsgn = objBusinessLayerJobRole.GridDisplayJobRole(objEntityJobRol);
//        int intUserId = 0, intUsrRolMstrId,  intEnableModify = 0, intEnableCancel = 0;
//        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
//        clsCommonLibrary objCommon = new clsCommonLibrary();
//        if (Session["USERID"] != null)
//        {
//            intUserId = Convert.ToInt32(Session["USERID"]);

//        }
//        else if (Session["USERID"] == null)
//        {
//            Response.Redirect("~/Default.aspx");
//        }
//        //recall option enabled or not

//        int intUserRoleRecall = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
//        DataTable dtCancelRecall = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUserRoleRecall);
//        int intEnableRecall = 0;
//        if (dtCancelRecall.Rows.Count > 0)
//        {
//            intEnableRecall = 1;
//            //hiddenRoleRecall.Value = "1";
//        }
//        else
//        {
//            intEnableRecall = 0;
//            //hiddenRoleRecall.Value = "0";
//        }
//        //Allocating child roles
//        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Job_role);
//        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

//        if (dtChildRol.Rows.Count > 0)
//        {
//            string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

//            string[] strChildDefArrWords = strChildRolDeftn.Split('-');
//            foreach (string strC_Role in strChildDefArrWords)
//            {
//               if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
//                {
//                    intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
//                }
//                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
//                {
//                    intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

//                }
//            }
//        }
//        //int intEnableRecall=Convert.ToInt32(hiddenRoleRecall.Value);
//        string strHtm = ConvertDataTableToHTML(dtDsgn, intEnableModify, intEnableCancel, intUserId, intEnableRecall);
//        //Write to divReport
//        divReport.InnerHtml = strHtm;
//    }
//    protected void btnRsnSave_Click(object sender, EventArgs e)
//    {

//        //Created objects for business layer
//        clsBusinessLayerJobRole objBusinessLayerJobRole = new clsBusinessLayerJobRole();
//        clsEntityLayerJobRole objEntityJobRol = new clsEntityLayerJobRole();

//        if (hiddenCancelPrimaryId.Value != null && hiddenCancelPrimaryId.Value != "")
//        {
//            objEntityJobRol.JobRoleId = Convert.ToInt32(hiddenCancelPrimaryId.Value);


//            if (Session["USERID"] != null)
//            {
//                objEntityJobRol.UserID = Convert.ToInt32(Session["USERID"]);

//            }
//            else if (Session["USERID"] == null)
//            {
//                Response.Redirect("~/Default.aspx");
//            }

//            objEntityJobRol.DsgnDate = System.DateTime.Now;

//            objEntityJobRol.DesignationCancelReason = txtCnclReason.Text.Trim();
//            objBusinessLayerJobRole.UpdateJobRlCancel(objEntityJobRol);


//            if (hiddenSearchField.Value == "")
//            {
//                Response.Redirect("gen_Job_Role_List.aspx?InsUpd=Cncl");
//            }
//            else
//            {
//                Response.Redirect("gen_Job_Role_List.aspx?InsUpd=Cncl&Srch=" + this.hiddenSearchField.Value);

//            }


//        }
//    }
//    //Assign Designation from GN_DESG_TYPE table to dropdownlist.
//    public void DropDownBind(string strDsgnTypeName = null)
//    {


//        int intUserAppAdminstrtn = 0, intUserComzitSFA = 0, intUserCompzitAWMS = 0,intUserCompzitGMS=0, intUserId = 0;
//        ddlDesignation.Items.Clear();
//        clsEntityLayerJobRole objEntityJobRl = null;
//        objEntityJobRl = new clsEntityLayerJobRole();
//        DataTable dtDsgnTypeDetails = new DataTable();
//        if (Session["DSGN_CONTROL"] == null)
//        {
//            Response.Redirect("../../Default.aspx");

//        }
//        else
//        {
//            objEntityJobRl.DsgControl = Convert.ToChar(Session["DSGN_CONTROL"].ToString());
//        }
//        if (Session["ORGID"] != null)
//        {
//            objEntityJobRl.DsgnOrgId = Convert.ToInt32(Session["ORGID"].ToString());

//        }
//        else if (Session["ORGID"] == null)
//        {
//            Response.Redirect("~/Default.aspx");
//        }
//        if (Session["DSGN_TYPID"] != null)
//        {
//            objEntityJobRl.DesignationTypeId = Convert.ToInt32(Session["DSGN_TYPID"].ToString());

//        }
//        else if (Session["DSGN_TYPID"] == null)
//        {
//            Response.Redirect("../../Default.aspx");
//        }
//        if (Session["USERID"] != null)
//        {
//            objEntityJobRl.UserID = Convert.ToInt32(Session["USERID"]);
//            intUserId = Convert.ToInt32(Session["USERID"]);
//        }
//        else if (Session["USERID"] == null)
//        {
//            Response.Redirect("~/Default.aspx");
//        }
        


//        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
//        DataTable dtUserAppRole = new DataTable();
//        dtUserAppRole = objBusinessLayer.ReadUserAppRoleByUserId(intUserId);

//        for (int intRowCountUserAppRole = 0; intRowCountUserAppRole < dtUserAppRole.Rows.Count; intRowCountUserAppRole++)
//        {
//            int intPrmntzId = Convert.ToInt32(dtUserAppRole.Rows[intRowCountUserAppRole]["PRTZAPP_ID"].ToString());
//            if (intPrmntzId == Convert.ToInt32(APPS.APP_ADMINSTRATION))
//            {
//                intUserAppAdminstrtn = 1;
//            }
//            else if (intPrmntzId == Convert.ToInt32(APPS.SALES_FORCE_AUTOMATION))
//            {
//                intUserComzitSFA = 1;
//            }
//            else if (intPrmntzId == Convert.ToInt32(APPS.AUTO_WORKSHOP_MANAGEMENT_SYSTEM))
//            {
//                intUserCompzitAWMS = 1;
//            }
//            else if (intPrmntzId == Convert.ToInt32(APPS.GUARANTEE_MANAGEMENT_SYSTEM))
//            {
//                intUserCompzitGMS = 1;
//            }
//        }
//        //BL
//        clsBusinessLayerJobRole objBusinessLayerJobRole = new clsBusinessLayerJobRole();
//        dtDsgnTypeDetails = objBusinessLayerJobRole.ReadDsgnDetails(objEntityJobRl);
      
//        for (int intRowBodyCount = 0; intRowBodyCount < dtDsgnTypeDetails.Rows.Count; intRowBodyCount++)
//        {
//            int intDsgnAppAdminstrtn = 0, intDsgnComzitSFA = 0, intDsgnCompzitAWMS = 0, intDsgnCompzitGMS=0;
//            int intDsgId = Convert.ToInt32(dtDsgnTypeDetails.Rows[intRowBodyCount]["DSGN_ID"].ToString());
//            objEntityJobRl.DesignationId = intDsgId;
//            DataTable dtDsgnAppRole = new DataTable();
//            dtDsgnAppRole = objBusinessLayerJobRole.ReadDsgnAppRoleByDsgnId(objEntityJobRl);
//            for (int intRowCountDsgnAppRole = 0; intRowCountDsgnAppRole < dtDsgnAppRole.Rows.Count; intRowCountDsgnAppRole++)
//            {
//                int intPrmntzId = Convert.ToInt32(dtDsgnAppRole.Rows[intRowCountDsgnAppRole]["PRTZAPP_ID"].ToString());
//                if (intPrmntzId == Convert.ToInt32(APPS.APP_ADMINSTRATION))
//                {
//                    intDsgnAppAdminstrtn = 1;
//                }
//                else if (intPrmntzId == Convert.ToInt32(APPS.SALES_FORCE_AUTOMATION))
//                {
//                    intDsgnComzitSFA = 1;
//                }
//                else if (intPrmntzId == Convert.ToInt32(APPS.AUTO_WORKSHOP_MANAGEMENT_SYSTEM))
//                {
//                    intDsgnCompzitAWMS = 1;
//                }
//                else if (intPrmntzId == Convert.ToInt32(APPS.GUARANTEE_MANAGEMENT_SYSTEM))
//                {
//                    intDsgnCompzitGMS = 1;
//                }
//            }
//            if ((intUserAppAdminstrtn == intDsgnAppAdminstrtn || intUserAppAdminstrtn > intDsgnAppAdminstrtn) && (intUserComzitSFA == intDsgnComzitSFA || intUserComzitSFA > intDsgnComzitSFA) && (intUserCompzitAWMS == intDsgnCompzitAWMS || intUserCompzitAWMS > intDsgnCompzitAWMS) && (intUserCompzitGMS == intDsgnCompzitGMS || intUserCompzitGMS > intDsgnCompzitGMS))
//            {
//                //bind one by one here

//            }
//            else
//            {
//                DataRow dr = dtDsgnTypeDetails.Rows[intRowBodyCount];
//                    dr.Delete();
//            }
            
//        }

//        ddlDesignation.DataSource = dtDsgnTypeDetails;
//        ddlDesignation.DataTextField = "DSGN_NAME";


//        ddlDesignation.DataValueField = "DSGN_ID";
//        ddlDesignation.DataBind();
//        ddlDesignation.Items.Insert(0, "--SELECT--");
//        if (strDsgnTypeName != null)
//        {
//            if (ddlDesignation.Items.FindByText(strDsgnTypeName) != null)
//            {
//                ddlDesignation.Items.FindByText(strDsgnTypeName).Selected = true;
//            }
//        }
//    }
//}
