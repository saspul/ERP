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

public partial class Master_gen_Product_Category_gen_Product_CategoryList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtCancelReason.Attributes.Add("onkeypress", "return isTag(event)");
        if (!IsPostBack)
        {
            ddlStatus.Focus();
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
            hiddenRoleAdd.Value = "0";
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
            int intBusinessSpecific = 0, intAccountSpecific = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Product_Category);
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
                        hiddenRoleAdd.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenFieldUpdRole.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenFieldCnclRole.Value = "1";
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
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.BUSINESS_SPECIFIC).ToString())
                    {
                        intBusinessSpecific = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ACCOUNT_SPECIFIC).ToString())
                    {
                        intAccountSpecific = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenAccountSpecific.Value = intAccountSpecific.ToString();
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
                //Creating objects for business layer
                clsBusinessLayerCategory objBusinessLayerCategory = new clsBusinessLayerCategory();
                clsEntityCategory objEntityCategory = new clsEntityCategory();
                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityCategory.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

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


                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {   clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE,
                                                               clsCommonLibrary.CORP_GLOBAL.CMDTY_MANTN_OFFCE
                                                              };
                DataTable dtCorpDetail = new DataTable();
                dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                if (dtCorpDetail.Rows.Count > 0)
                {
                    hiddenCommodityValue.Value = dtCorpDetail.Rows[0]["CMDTY_MANTN_OFFCE"].ToString();
                    string strListingMode = dtCorpDetail.Rows[0]["LISTING_MODE"].ToString();
                    string strLstingModeSize = dtCorpDetail.Rows[0]["LISTING_MODE_SIZE"].ToString();
                }

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
                        else if (strInsUpd == "AlSts")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "AlreadySts", "AlreadySts();", true);
                        }
                    }
                }
        }
    }  //It build the Html table by using the datatable provided
    public static string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intAccountSpecific,string hiddenCommodityValue)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        string strHtml = "";
        if (dt.Rows.Count > 0)
        {
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            string strId = dt.Rows[intRowBodyCount][8].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][8].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;


                        int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
                        int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

                        strHtml += "<tr  >";

                                                     
                                    strHtml += "<td class=\"tr_l\">" + dt.Rows[intRowBodyCount][0].ToString() + "</td>";

                                    if (hiddenCommodityValue == "1" && intAccountSpecific == 1)
                                    {
                                        if (dt.Rows[intRowBodyCount][1].ToString() == "MAIN CATEGORY")
                                        {
                                            strHtml += "<td class=\"tr_l\"><i class=\"i_cm\"><img src=\"/Images/opp/c1.png\"> </i> <span style=\"margin-left: -7px;\">MAIN CATEGORY</span></td>";
                                        }
                                        else if (dt.Rows[intRowBodyCount][1].ToString() == "SUB CATEGORY")
                                        {
                                            strHtml += "<td class=\"tr_l\"><i class=\"i_cm\"><img src=\"/Images/opp/c2.png\"> </i> <span style=\"margin-left: -7px;\">SUB CATEGORY</span></td>";
                                        }
                                        else if (dt.Rows[intRowBodyCount][1].ToString() == "SMALL CATEGORY")
                                        {
                                            strHtml += "<td class=\"tr_l\"><i class=\"i_cm\"><img src=\"/Images/opp/c3.png\"> </i><span style=\"margin-left: -7px;\"> SMALL CATEGORY</span></td>";
                                        }
                                        else if (dt.Rows[intRowBodyCount][1].ToString() == "LEAST CATEGORY")
                                        {
                                            strHtml += "<td class=\"tr_l\"><i class=\"i_cm\"><img src=\"/Images/opp/c4.png\"> </i> <span style=\"margin-left: -7px;\">LEAST CATEGORY</span></td>";
                                        }
                                    }
                                    else
                                    {
                                        if (dt.Rows[intRowBodyCount][1].ToString() == "MAIN CATEGORY")
                                        {
                                            strHtml += "<td class=\"tr_l\"><i class=\"i_cm\"><img src=\"/Images/opp/c1.png\"> </i> <span>MAIN CATEGORY</span></td>";
                                        }
                                        else if (dt.Rows[intRowBodyCount][1].ToString() == "SUB CATEGORY")
                                        {
                                            strHtml += "<td class=\"tr_l\"><i class=\"i_cm\"><img src=\"/Images/opp/c2.png\"> </i> <span>SUB CATEGORY</span></td>";
                                        }
                                        else if (dt.Rows[intRowBodyCount][1].ToString() == "SMALL CATEGORY")
                                        {
                                            strHtml += "<td class=\"tr_l\"><i class=\"i_cm\"><img src=\"/Images/opp/c3.png\"> </i><span> SMALL CATEGORY</span></td>";
                                        }
                                        else if (dt.Rows[intRowBodyCount][1].ToString() == "LEAST CATEGORY")
                                        {
                                            strHtml += "<td class=\"tr_l\"><i class=\"i_cm\"><img src=\"/Images/opp/c4.png\"> </i> <span>LEAST CATEGORY</span></td>";
                                        }
                                    }

                                    strHtml += "<td class=\"tr_l\">" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";                              
                                    strHtml += "<td class=\"tr_l\">" + dt.Rows[intRowBodyCount][3].ToString() + "</td>";
                                    if (hiddenCommodityValue == "1")
                                    {
                                        strHtml += "<td class=\"tr_l\">" + dt.Rows[intRowBodyCount][4].ToString() + "</td>";
                                    }                  
                                if (intAccountSpecific == 1)
                                {
                                    strHtml += "<td class=\"tr_l\">" + dt.Rows[intRowBodyCount][6].ToString() + "</td>";
                                }                          
                                if (intAccountSpecific == 1)
                                {
                                    strHtml += "<td class=\"tr_l\">" + dt.Rows[intRowBodyCount][7].ToString() + "</td>";
                                }



                                strHtml += "<td>";
                                strHtml += " <div class=\"btn_stl1\">";
                                if (intCnclUsrId == 0 && intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                                {
                                    if (dt.Rows[intRowBodyCount][5].ToString() == "ACTIVE")
                                        strHtml += "<button class=\"btn tab_but1 butn1 btn_sta\" title=\"Change Status\" onclick=\"return ChangeStatus('" + Id + "','1','" + intCnclUsrId + "');\"><i class=\"fa fa-check-circle\"></i></button>";
                                    else
                                        strHtml += "<button class=\"btn tab_but1 butn4 btn_sti\" title=\"Change Status\" onclick=\"return ChangeStatus('" + Id + "','0','" + intCnclUsrId + "');\"><i class=\"fa fa-times-circle\"></i></button>";

                                }
                                else
                                {
                                    if (dt.Rows[intRowBodyCount][5].ToString() == "ACTIVE")
                                        strHtml += "<button disabled class=\"btn tab_but1 butn1 btn_sta\" title=\"Change Status\" ><i class=\"fa fa-check-circle\"></i></button>";
                                    else
                                        strHtml += "<button disabled class=\"btn tab_but1 butn4 btn_sti\" title=\"Change Status\" ><i class=\"fa fa-times-circle\"></i></button>";
                                }
                                if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                                {
                                    if (intCnclUsrId == 0)
                                    {
                                        strHtml += " <button class=\"btn act_btn bn1 bt_e\"  title=\"Edit\" onclick='return getdetails(\"gen_Product_Category.aspx?Id=" + Id + "\");'>"
                                           + "<i class=\"fa fa-edit\"></i>" + "</button>";
                                    }
                                    else
                                    {
                                        strHtml += " <button  class=\"btn act_btn bn4 bt_v\" title=\"View\" onclick='return getdetails(\"gen_Product_Category.aspx?ViewId=" + Id + "\");'>" +
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
            int colCnt = 5;
            if (intAccountSpecific == 1){
                colCnt+=2;
            }
            if (hiddenCommodityValue == "1"){
                colCnt+=1;
            }
            strHtml += "<td class=\"tr_c\" colspan=\"" + colCnt + "\">No data available in table</td>";
        }
        return strHtml;
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
            clsBusinessLayerCategory objBusinessLayerCategory = new clsBusinessLayerCategory();
            clsEntityCategory objEntityCategory = new clsEntityCategory();
            objEntityCategory.Category_Id = Convert.ToInt32(strId);
            objEntityCategory.User_Id = Convert.ToInt32(userID);
            objEntityCategory.D_Date = System.DateTime.Now;
            objEntityCategory.Corp_Id = Convert.ToInt32(corptID);
            if (Mode == "0")
            {
                if (reasonmust == "1")
                {
                    objEntityCategory.Cancel_Reason = cnclRsn;
                }
                else
                {
                    objEntityCategory.Cancel_Reason = objCommon.CancelReason();
                }
                DataTable dtComplaintDetail = objBusinessLayerCategory.ReadCategoryById(objEntityCategory);
                if (dtComplaintDetail.Rows.Count > 0)
                {
                    if (dtComplaintDetail.Rows[0]["CTGRY_CNCL_USR_ID"].ToString() == "" || dtComplaintDetail.Rows[0]["CTGRY_CNCL_USR_ID"].ToString() == null)
                    {
                        objBusinessLayerCategory.CancelCategory(objEntityCategory);
                        sts = "Cncl";
                    }
                    else
                    {
                        sts = "AlCncl";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            sts = "Err";
        }
        return sts;
    }
    [WebMethod]
    public static string ChangeStatus(string strmemotId, string strStatus, string UsrId, string corptID)
    {
        string strRet = "success";
        string strRandomMixedId = strmemotId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        clsBusinessLayerCategory objBusinessLayerCategory = new clsBusinessLayerCategory();
        clsEntityCategory objEntityCategory = new clsEntityCategory();
        objEntityCategory.Category_Id = Convert.ToInt32(strId);
        objEntityCategory.User_Id = Convert.ToInt32(UsrId);
        objEntityCategory.D_Date = System.DateTime.Now;
        objEntityCategory.Corp_Id = Convert.ToInt32(corptID);
        if (strStatus == "1")
        {
            strStatus = "0";
        }
        else
        {
            strStatus = "1";
        }
        objEntityCategory.Status = Convert.ToInt32(strStatus);

        DataTable dtComplaintDetail = objBusinessLayerCategory.ReadCategoryById(objEntityCategory);
        if (dtComplaintDetail.Rows.Count > 0)
        {
            if (dtComplaintDetail.Rows[0]["CTGRY_CNCL_USR_ID"].ToString() == "" || dtComplaintDetail.Rows[0]["CTGRY_CNCL_USR_ID"].ToString() == null)
            {
                if (dtComplaintDetail.Rows[0]["CTGRY_STATUS"].ToString() != strStatus)
                {
                    objBusinessLayerCategory.CategoryStausChange(objEntityCategory);
                    strRet = "success";
                }
                else
                {
                    strRet = "AlSts";
                }
            }
            else
            {
                strRet = "AlCncl";
            }
        }
        return strRet;
    }
    [WebMethod]
    public static string PrintList(string orgID, string corptID, string Status, string CnclSts, string intAccountSpecific, string hiddenCommodityValue)
    {
        string strReturn = "";
        //end
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerCategory objBusinessLayerCategory = new clsBusinessLayerCategory();
        clsEntityCategory objEntityCategory = new clsEntityCategory();
        objEntityCategory.Status = Convert.ToInt32(Status);
        objEntityCategory.Cancel_Status = Convert.ToInt32(CnclSts);
        objEntityCategory.Org_Id = Convert.ToInt32(orgID);
        objEntityCategory.Corp_Id = Convert.ToInt32(corptID);
        DataTable dtUser = new DataTable();
        dtUser = objBusinessLayerCategory.Read_CategoryList_BySearch(objEntityCategory);

        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.PRODUCT_CATEGORY_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PRODUCT_CATEGORY_PDF);

        objEntityCommon.CorporateID = Convert.ToInt32(corptID);
        objEntityCommon.Organisation_Id = Convert.ToInt32(orgID);
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "ProductCategoryList_" + corptID + "_" + strNextNumber + ".pdf";

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
                footrtable.AddCell(new PdfPCell(new Phrase("STATUS  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (Status == "2")
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

                if (intAccountSpecific == "1" && hiddenCommodityValue=="1")
                {

                    PdfPTable TBCustomer = new PdfPTable(8);
                    float[] footrsBody = { 15, 10, 13, 13, 13, 13,13, 10 };
                    TBCustomer.SetWidths(footrsBody);
                    TBCustomer.WidthPercentage = 100;
                    TBCustomer.HeaderRows = 1;

                    var FontGray = new BaseColor(138, 138, 138);
                    var FontColour = new BaseColor(134, 152, 160);
                    var FontSmallGray = new BaseColor(230, 230, 230);

                    TBCustomer.AddCell(new PdfPCell(new Phrase("CATEGORY NAME", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("CATEGORY TYPE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("PARENT CATEGORY", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("PRODUCT GROUP", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("PRODUCT CODE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("SALE LEDGER", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("PURCHASE LEDGER", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("STATUS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    string strRandom = objCommon.Random_Number();


                    if (dtUser.Rows.Count > 0)
                    {
                        for (int intRowBodyCount = 0; intRowBodyCount < dtUser.Rows.Count; intRowBodyCount++)
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][0].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][1].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][2].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][3].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][4].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][6].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][7].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][5].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                    }
                    else
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" No data available in table", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 8 });
                    }
                    document.Add(TBCustomer);

                }
                else if (intAccountSpecific == "0" && hiddenCommodityValue != "1")
                {

                    PdfPTable TBCustomer = new PdfPTable(5);
                    float[] footrsBody = { 30, 15, 20, 20, 15 };
                    TBCustomer.SetWidths(footrsBody);
                    TBCustomer.WidthPercentage = 100;
                    TBCustomer.HeaderRows = 1;

                    var FontGray = new BaseColor(138, 138, 138);
                    var FontColour = new BaseColor(134, 152, 160);
                    var FontSmallGray = new BaseColor(230, 230, 230);

                    TBCustomer.AddCell(new PdfPCell(new Phrase("CATEGORY NAME", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("CATEGORY TYPE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("PARENT CATEGORY", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("PRODUCT GROUP", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("STATUS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    string strRandom = objCommon.Random_Number();


                    if (dtUser.Rows.Count > 0)
                    {
                        for (int intRowBodyCount = 0; intRowBodyCount < dtUser.Rows.Count; intRowBodyCount++)
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][0].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][1].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][2].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][3].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][5].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                    }
                    else
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" No data available in table", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 5 });
                    }
                    document.Add(TBCustomer);

                }
                else if (intAccountSpecific == "1" && hiddenCommodityValue != "1")
                {

                    PdfPTable TBCustomer = new PdfPTable(7);
                    float[] footrsBody = { 20, 10, 15, 15, 15, 15, 10 };
                    TBCustomer.SetWidths(footrsBody);
                    TBCustomer.WidthPercentage = 100;
                    TBCustomer.HeaderRows = 1;

                    var FontGray = new BaseColor(138, 138, 138);
                    var FontColour = new BaseColor(134, 152, 160);
                    var FontSmallGray = new BaseColor(230, 230, 230);

                    TBCustomer.AddCell(new PdfPCell(new Phrase("CATEGORY NAME", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("CATEGORY TYPE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("PARENT CATEGORY", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("PRODUCT GROUP", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("SALE LEDGER", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("PURCHASE LEDGER", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("STATUS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    string strRandom = objCommon.Random_Number();


                    if (dtUser.Rows.Count > 0)
                    {
                        for (int intRowBodyCount = 0; intRowBodyCount < dtUser.Rows.Count; intRowBodyCount++)
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][0].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][1].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][2].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][3].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][6].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][7].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][5].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                    }
                    else
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" No data available in table", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 7 });
                    }
                    document.Add(TBCustomer);

                }
                else if (intAccountSpecific == "0" && hiddenCommodityValue == "1")
                {

                    PdfPTable TBCustomer = new PdfPTable(6);
                    float[] footrsBody = { 25, 12, 17, 17, 17, 12 };
                    TBCustomer.SetWidths(footrsBody);
                    TBCustomer.WidthPercentage = 100;
                    TBCustomer.HeaderRows = 1;

                    var FontGray = new BaseColor(138, 138, 138);
                    var FontColour = new BaseColor(134, 152, 160);
                    var FontSmallGray = new BaseColor(230, 230, 230);

                    TBCustomer.AddCell(new PdfPCell(new Phrase("CATEGORY NAME", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("CATEGORY TYPE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("PARENT CATEGORY", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("PRODUCT GROUP", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("PRODUCT CODE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("STATUS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    string strRandom = objCommon.Random_Number();


                    if (dtUser.Rows.Count > 0)
                    {
                        for (int intRowBodyCount = 0; intRowBodyCount < dtUser.Rows.Count; intRowBodyCount++)
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][0].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][1].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][2].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][3].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][4].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][5].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                    }
                    else
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" No data available in table", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 6 });
                    }
                    document.Add(TBCustomer);

                }
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
            headtable.AddCell(new PdfPCell(new Phrase("PRODUCT CATEGORY LIST ", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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
    public static string[] GetData(string OrgId, string CorpId, string ddlStatus, string CancelStatus, string EnableModify, string EnableCancel, string PageNumber, string PageMaxSize, string strCommonSearchTerm, string OrderColumn, string OrderMethod, string strInputColumnSearch, string intAccountSpecific, string hiddenCommodityValue)
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBusinessLayerCategory objBusinessLayerCategory = new clsBusinessLayerCategory();
        clsEntityCategory objEntityCategory = new clsEntityCategory();
        objEntityCategory.Status = Convert.ToInt32(ddlStatus);
        objEntityCategory.Cancel_Status = Convert.ToInt32(CancelStatus);
        objEntityCategory.Org_Id = Convert.ToInt32(OrgId);
        objEntityCategory.Corp_Id = Convert.ToInt32(CorpId);
        objEntityCategory.User_Id = Convert.ToInt32(intAccountSpecific);
        objEntityCategory.PurchaseLedgerID = Convert.ToInt32(hiddenCommodityValue);
      

        string[] strResults = new string[2];
        objEntityCategory.PageNumber = Convert.ToInt32(PageNumber);
        objEntityCategory.PageMaxSize = Convert.ToInt32(PageMaxSize);
        objEntityCategory.OrderMethod = Convert.ToInt32(OrderMethod);
        objEntityCategory.OrderColumn = Convert.ToInt32(OrderColumn);
        objEntityCategory.CommonSearchTerm = strCommonSearchTerm;

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
        objEntityCategory.SearchName = strSearchInputs[Convert.ToInt32(SearchInputColumns.NAME)];
        objEntityCategory.SearchType = strSearchInputs[Convert.ToInt32(SearchInputColumns.TYPE)];
        objEntityCategory.SearchCategory = strSearchInputs[Convert.ToInt32(SearchInputColumns.CATEGORY)];
        objEntityCategory.SearchGroup = strSearchInputs[Convert.ToInt32(SearchInputColumns.GROUP)];
        objEntityCategory.SearchCode = strSearchInputs[Convert.ToInt32(SearchInputColumns.CODE)];
        objEntityCategory.SearchSale = strSearchInputs[Convert.ToInt32(SearchInputColumns.SALE)];
        objEntityCategory.SearchPurchase = strSearchInputs[Convert.ToInt32(SearchInputColumns.PURCHASE)];

        DataTable dt = new DataTable();
        dt = objBusinessLayerCategory.Read_CategoryList_BySearch(objEntityCategory);

        int intEnableUpdate = Convert.ToInt32(EnableModify);
        int intEnableCancel = Convert.ToInt32(EnableCancel);
        strResults[0] = ConvertDataTableToHTML(dt, intEnableUpdate, intEnableCancel, Convert.ToInt32(intAccountSpecific), hiddenCommodityValue);
        if (dt.Rows.Count > 0)
        {
            int intTotalItems = Convert.ToInt32(dt.Rows[0]["CNT"].ToString());
            int intCurrentRowCount = dt.Rows.Count;
            //Pagination
            strResults[1] = objBusinessLayer.GenereatePagination(intTotalItems, objEntityCategory.PageNumber, objEntityCategory.PageMaxSize, intCurrentRowCount);
        }

        return strResults;
    }
    [WebMethod]
    public static string[] LoadStaticDatafordt(string intAccountSpecific, string hiddenCommodityValue)//Filters
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
                if (hiddenCommodityValue == "1" && intAccountSpecific == "1")
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_1\" onclick=\"SetOrderByValue(1)\" class=\"sorting th_b2 tr_l\" style=\"word-wrap:break-word;width: 11% !important;\">CATEGORY NAME<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"CATEGORY NAME\" placeholder=\"Category Name\"></th>");
                }
                else
                {
                    sbSearchInputColumns.Append("<th id=\"tdColumnHead_1\" onclick=\"SetOrderByValue(1)\" class=\"sorting th_b2 tr_l\" style=\"word-wrap:break-word;\">CATEGORY NAME<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"CATEGORY NAME\" placeholder=\"Category Name\"></th>");
                }
            }
            else if (Convert.ToInt32(item).ToString() == "1")
            {

                sbSearchInputColumns.Append("<th id=\"tdColumnHead_2\" onclick=\"SetOrderByValue(2)\" class=\"sorting th_b6 tr_l\" style=\"word-wrap:break-word;\">CATEGORY TYPE<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"CATEGORY TYPE\" placeholder=\"Category Type\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "2")
            {

                sbSearchInputColumns.Append("<th id=\"tdColumnHead_3\" onclick=\"SetOrderByValue(3)\" class=\"sorting th_b6 tr_l\" style=\"word-wrap:break-word;\">PARENT CATEGORY<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"PARENT CATEGORY\" placeholder=\"Parent Category\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "3")
            {

                sbSearchInputColumns.Append("<th id=\"tdColumnHead_4\" onclick=\"SetOrderByValue(4)\" class=\"sorting th_b6 tr_l\" style=\"word-wrap:break-word;\">PRODUCT GROUP<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"PRODUCT GROUP\" placeholder=\"Product Group\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "4" && hiddenCommodityValue=="1")
            {

                sbSearchInputColumns.Append("<th id=\"tdColumnHead_5\" onclick=\"SetOrderByValue(5)\" class=\"sorting th_b6 tr_l\" style=\"word-wrap:break-word;\">PRODUCT CODE<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"PRODUCT CODE\" placeholder=\"Product Code\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "5" && intAccountSpecific=="1")
            {

                sbSearchInputColumns.Append("<th id=\"tdColumnHead_7\" onclick=\"SetOrderByValue(7)\" class=\"sorting th_b6 tr_l\" style=\"word-wrap:break-word;\">SALE LEDGER<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"SALE LEDGER\" placeholder=\"Sale Ledger\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "6" && intAccountSpecific == "1")
            {

                sbSearchInputColumns.Append("<th id=\"tdColumnHead_8\" onclick=\"SetOrderByValue(8)\" class=\"sorting th_b6 tr_l\" style=\"word-wrap:break-word;\">PURCHASE LEDGER<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"PURCHASE LEDGER\" placeholder=\"Purchase Ledger\"></th>");
            }
        }
        if (hiddenCommodityValue == "1" && intAccountSpecific == "1")
        {
            sbSearchInputColumns.Append("<th class=\"th_b8\"  style=\"word-wrap:break-word;width: 7% !important;\">ACTIONS</th>");
        }
        else
        {
            sbSearchInputColumns.Append("<th class=\"th_b8\"  style=\"word-wrap:break-word;\">ACTIONS</th>");
        }
        strResults[1] = sbSearchInputColumns.ToString();
        strResults[2] = intSearchColumnCount.ToString();
        return strResults;
    }

    public enum SearchInputColumns
    {
        //Must be sequential 
        NAME = 0,
        TYPE = 1,
        CATEGORY=2,
        GROUP=3,
        CODE = 4,
        SALE=5,
        PURCHASE=6
    }
}