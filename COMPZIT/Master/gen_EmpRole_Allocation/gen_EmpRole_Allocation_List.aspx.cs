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
public partial class Master_gen_EmpRole_Allocation_gen_EmpRole_Allocation_List : System.Web.UI.Page
{
     #region Enumerations;
    //Enumeration for identifying apllication typeid 
    private enum APPS
    {
        APP_ADMINSTRATION = 1,
        SALES_FORCE_AUTOMATION = 2,
        AUTO_WORKSHOP_MANAGEMENT_SYSTEM = 3,
        GUARANTEE_MANAGEMENT_SYSTEM=4
    }
    private enum USERLIMITED
    {
        ISLIMITED = 1,
        NOTLIMITED = 2

    }

    #endregion
    clsBusinessLayerEmpRoleAllocation objBusinessEmpRoleAllocation = new clsBusinessLayerEmpRoleAllocation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //DesignationLoad();
            DropDownBind();
            ddlDesignation.Focus();

            //start new code
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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Employee_Role_Allocation);

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


            
                clsEntityEmpRoleAllocation objEmpRoleAllocation = new clsEntityEmpRoleAllocation();


               

                if (Session["ORGID"] != null)
                {
                    objEmpRoleAllocation.OrgId = Convert.ToInt32(Session["ORGID"].ToString());

                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("../../Default.aspx");
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

            
            else
            {

                myBtn.Visible = false;
            }

            //end new code
        }
    }
    //Method for binding Designation details to dropdown list.
    public void DesignationLoad()
    {

        if (Session["ORGID"] != null)
        

            if (Session["USERID"] != null)
            {
                int UserId = Convert.ToInt32(Session["USERID"]);


                int orgID = Convert.ToInt32(Session["ORGID"].ToString());
                DataTable dtCountry = objBusinessEmpRoleAllocation.ReadDesignation(orgID, UserId);
                ddlDesignation.DataSource = dtCountry;
                ddlDesignation.DataTextField = "DSGN_NAME";
                ddlDesignation.DataValueField = "DSGN_ID";
                ddlDesignation.DataBind();
                ddlDesignation.Items.Insert(0, "--Select Designation--");
            }
        }
   
    //It build the Html table by using the datatable provided
    public static string ConvertDataTableToHTML(DataTable dt, int intEnableModify)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        string strHtml = "";
       
        if (dt.Rows.Count > 0)
        {
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            strHtml += "<tr  >";         
            strHtml += "<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][0].ToString() + "</td>";
              

            string strId = dt.Rows[intRowBodyCount][1].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][1].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

               strHtml += "<td>";
                   strHtml += " <div class=\"btn_stl1\">";

            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                 strHtml += " <button class=\"btn act_btn bn1 bt_e\"  title=\"Edit\" onclick='return getdetails(\"gen_EmpRole_Allocation.aspx?Id=" + Id + "\");'>"
                              + "<i class=\"fa fa-edit\"></i>" + "</button>";

                               
               
            }
             strHtml += " <button  class=\"btn act_btn bn4 bt_v\" title=\"View\" onclick='return getdetails(\"gen_EmpRole_Allocation.aspx?ViewId=" + Id + "\");'>" +
                           "<i class=\"fa fa-list-alt\"></i>" + "</button>";
             
         
            
            strHtml += " </div>";
                   strHtml += "</td>";
                   strHtml += "</tr>";

        }
        }
        else
        {
            strHtml += "<td class=\"tr_c\" colspan=\"2\">No data available in table</td>";
        }
        return strHtml;

    }
    protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        clsEntityEmpRoleAllocation objEmpRoleAllocation = new clsEntityEmpRoleAllocation();
        if (ddlDesignation.SelectedItem.Value != "--Select Designation--")
        {
            objEmpRoleAllocation.DesgId = Convert.ToInt32(ddlDesignation.SelectedItem.Value);
            DataTable dtState = objBusinessEmpRoleAllocation.ReadJobRole(objEmpRoleAllocation);
            ddlJobrole.DataSource = dtState;
            ddlJobrole.DataTextField = "JOBRL_NAME";
            ddlJobrole.DataValueField = "JOBRL_ID";
            ddlJobrole.DataBind();
           
        }
        else
        {
            ddlJobrole.Items.Clear();
            
        }
        ddlJobrole.Items.Insert(0, "--Select Job Role--");
        ScriptManager.RegisterStartupScript(this, GetType(), "AutoCo", "AutoCo();", true);
    }
 //Assign Designation from GN_DESG_TYPE table to dropdownlist.
    public void DropDownBind(string strDsgnTypeName = null)
    {


        int intUserAppAdminstrtn = 0, intUserComzitSFA = 0, intUserCompzitAWMS = 0,intUserCompzitGMS=0, intUserId = 0;
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
            int intDsgnAppAdminstrtn = 0, intDsgnComzitSFA = 0, intDsgnCompzitAWMS = 0, intDsgnCompzitGMS=0;
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
    public static string PrintList(string orgID, string corptID, string Status, string CnclSts, string Divs, string DivsT,string Jobr,string JobrT)
    {
        string strReturn = "";
        //end
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerEmpRoleAllocation objBusinessEmpRoleAllocation = new clsBusinessLayerEmpRoleAllocation();
        clsEntityEmpRoleAllocation objEmpRoleAllocation = new clsEntityEmpRoleAllocation();
        objEmpRoleAllocation.OrgId = Convert.ToInt32(orgID);
        if (Divs == "--SELECT--")
        {

        }
        else
        {
            objEmpRoleAllocation.DesgId = Convert.ToInt32(Divs);
            if (Jobr != "--Select Job Role--")
            {
                objEmpRoleAllocation.JobroleId = Convert.ToInt32(Jobr);
            }
        }
        DataTable dtUser = new DataTable();
        dtUser = objBusinessEmpRoleAllocation.ReadEmproleList(objEmpRoleAllocation);
      
        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.EMPLOYEE_ROLE_ALLOCATION_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.EMPLOYEE_ROLE_ALLOCATION_PDF);

        objEntityCommon.CorporateID = Convert.ToInt32(corptID);
        objEntityCommon.Organisation_Id = Convert.ToInt32(orgID);
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "EmployeeReoleAllocationList_" + corptID + "_" + strNextNumber + ".pdf";

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
                if (Divs != "--SELECT--" && Divs != "")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("DESIGNATION  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(DivsT, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (JobrT != "--Select Job Role--")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("JOB ROLE  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(JobrT, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }



                document.Add(footrtable);


                //adding table to pdf



                PdfPTable TBCustomer = new PdfPTable(1);
                float[] footrsBody = { 100 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("EMPLOYEE NAME", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                string strRandom = objCommon.Random_Number();


                if (dtUser.Rows.Count > 0)
                {
                    for (int intRowBodyCount = 0; intRowBodyCount < dtUser.Rows.Count; intRowBodyCount++)
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][0].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }
                }
                else
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase(" No data available in table", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 1 });
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
            headtable.AddCell(new PdfPCell(new Phrase("EMPLOYEE ROLE ALLOCATION LIST ", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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
    public static string[] GetData(string OrgId, string CorpId, string ddlStatus, string CancelStatus, string EnableModify, string EnableCancel, string PageNumber, string PageMaxSize, string strCommonSearchTerm, string OrderColumn, string OrderMethod, string strInputColumnSearch, string Divs, string Jobr)
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBusinessLayerEmpRoleAllocation objBusinessEmpRoleAllocation = new clsBusinessLayerEmpRoleAllocation();
        clsEntityEmpRoleAllocation objEmpRoleAllocation = new clsEntityEmpRoleAllocation();
        objEmpRoleAllocation.OrgId = Convert.ToInt32(OrgId);
        if (Divs == "--SELECT--")
        {

        }
        else
        {
            objEmpRoleAllocation.DesgId = Convert.ToInt32(Divs);
            if (Jobr != "--Select Job Role--")
            {
                objEmpRoleAllocation.JobroleId = Convert.ToInt32(Jobr);
            }
        }
        

        string[] strResults = new string[2];
        objEmpRoleAllocation.PageNumber = Convert.ToInt32(PageNumber);
        objEmpRoleAllocation.PageMaxSize = Convert.ToInt32(PageMaxSize);
        objEmpRoleAllocation.OrderMethod = Convert.ToInt32(OrderMethod);
        objEmpRoleAllocation.OrderColumn = Convert.ToInt32(OrderColumn);
        objEmpRoleAllocation.CommonSearchTerm = strCommonSearchTerm;

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
        objEmpRoleAllocation.SearchName = strSearchInputs[Convert.ToInt32(SearchInputColumns.NAME)];
       
        DataTable dt = new DataTable();
        dt = objBusinessEmpRoleAllocation.ReadEmproleList(objEmpRoleAllocation);


        int intEnableUpdate = Convert.ToInt32(EnableModify);
        strResults[0] = ConvertDataTableToHTML(dt, intEnableUpdate);
        if (dt.Rows.Count > 0)
        {
            int intTotalItems = Convert.ToInt32(dt.Rows[0]["CNT"].ToString());
            int intCurrentRowCount = dt.Rows.Count;
            //Pagination
            strResults[1] = objBusinessLayer.GenereatePagination(intTotalItems, objEmpRoleAllocation.PageNumber, objEmpRoleAllocation.PageMaxSize, intCurrentRowCount);
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
                sbSearchInputColumns.Append("<th id=\"tdColumnHead_1\" onclick=\"SetOrderByValue(1)\" class=\"sorting col-md-10 tr_l\" style=\"word-wrap:break-word;\">EMPLOYEE NAME<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"EMPLOYEE NAME\" placeholder=\"Employee Name\"></th>");
            }
        }
        sbSearchInputColumns.Append("<th class=\"col-md-2\"  style=\"word-wrap:break-word;\">ACTIONS</th>");
        strResults[1] = sbSearchInputColumns.ToString();
        strResults[2] = intSearchColumnCount.ToString();
        return strResults;
    }

    public enum SearchInputColumns
    {
        //Must be sequential 
        NAME = 0,
    }


}