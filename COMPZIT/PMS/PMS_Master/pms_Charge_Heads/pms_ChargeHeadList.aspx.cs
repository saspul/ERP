using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CL_Compzit;
using EL_Compzit;
using BL_Compzit;
using DL_Compzit.DataLayer_PMS;
using BL_Compzit.BusinessLayer_PMS;
using EL_Compzit.EntityLayer_PMS;
using System.Data;
using System.Text;
using System.Web.Services;
using Newtonsoft.Json;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web.Script.Serialization;
using System.IO;
public partial class PMS_PMS_Master_pms_Charge_Heads_pms_ChargeHeadList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int intFrmwrkId = 1;
        if (Session["FRMWRK_ID"] != null)
        {
            intFrmwrkId = Convert.ToInt32(Session["FRMWRK_ID"].ToString());
            //intFrmwrkId = 2;
        }
        if (intFrmwrkId == 1)
        {
            aHome.HRef = " /Home/Compzit_LandingPage/Compzit_LandingPage.aspx";
        }
        else
        {
            aHome.HRef = "/Home/Compzit_Home/Compzit_Home_Pms.aspx";
        } if (!IsPostBack)
        {
            LoadChargeHeadCategory();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityCommon objEntityCommon = new clsEntityCommon();


            clsBusinessLayerChargeHeads objBusinessChargeHead = new clsBusinessLayerChargeHeads();
            clsEntityChargeHeads objEntityChargeHead = new clsEntityChargeHeads();
            int intCorpId = 0, intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                objEntityChargeHead.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityChargeHead.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }


            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityChargeHead.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.PMS_Charge_Head);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        //HiddenRoleConf.Value = "1";
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intUpdate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        // HiddenRoleEdit.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active); ;
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenEnableCancl.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                    }
                }
            }
            if (intAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

            }
            else
            {
                // divAdd.Visible = false;
            }

            if (cbxCnclStatus.Checked == true)
            {
                objEntityChargeHead.Cancel_status = 0;
            }
            else
            {
                objEntityChargeHead.Cancel_status = 1;
            }
            objEntityChargeHead.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
            DataTable dtVendorCategory = objBusinessChargeHead.ReadChargeHead(objEntityChargeHead);
            divList.InnerHtml = ConvertDataTableToHTML(dtVendorCategory, intUpdate, intEnableCancel);
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                       };

            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenCancelReasonMust.Value = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
            }
        }
        if (Request.QueryString["InsUpd"] != null)
        {
            string strInsUpd = Request.QueryString["InsUpd"].ToString();
            if (strInsUpd == "Upd")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdate", "SuccessUpdate();", true);
            }
            if (strInsUpd == "Cncl")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
            }
            else if (strInsUpd == "Error")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ErrorCancelation", "ErrorCancelation();", true);
            }
        }
    }
    public string ConvertDataTableToHTML(DataTable dt, int intUpdate, int intEnableCancel)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        String Status = "";
        int intOrgId = 0;
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());


        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\" table-bordered display\"  width=\"100%\">";
        strHtml += "<thead class=\"thead1\">";
        strHtml += "<tr >";
        strHtml += "<th class=\"col-md-3 tr_l \" > CHARGE HEAD";
        strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input class=\"tb_inp_1 tb_in\" placeholder=\" CHARGE HEAD\" onkeydown=\"return DisableEnter(event)\"  type=\"text\"/>";
        strHtml += "</th >";
        strHtml += "<th class=\"col-md-2 tr_l hasinput\" >CALCULATION METHOD";
        strHtml += " <i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input class=\"tb_inp_1 tb_in\" placeholder=\"CALCULATION METHOD\" type=\"text\"/>";
        strHtml += "</th >";
        strHtml += "<th class=\"col-md-2 hasinput\" >STATUS ";
        strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input class=\"tb_inp_1 tb_in tr_c\" placeholder=\"STATUS\"  type=\"text\"/>";
        strHtml += "</th >";
        strHtml += "<th class=\"col-md-3 \" > ACTIONS <i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>";
        strHtml += "</tr>";
        strHtml += "</thead>";

        strHtml += "<tbody>";
        int COUNT = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            COUNT++;

            for (int intColumnBodyCount = 0; intColumnBodyCount < 4; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 0)
                {
                    strHtml += "<td class=\"tr_l\">" + dt.Rows[intRowBodyCount]["CHRGHD_NAME"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 1)
                {
                    string strCalculationMethod = "";
                    if (Convert.ToInt32(dt.Rows[intRowBodyCount]["CHRGHD_CALCULATE"].ToString())== 0)
                    {
                        strCalculationMethod = "Addition";
                    }
                    else if (Convert.ToInt32(dt.Rows[intRowBodyCount]["CHRGHD_CALCULATE"].ToString())== 1)
                    {
                        strCalculationMethod = "Deduction";
                    }

                    strHtml += "<td class=\"tr_l\"> " + strCalculationMethod + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    string strstatus = "";
                    if (dt.Rows[intRowBodyCount]["CHRGHD_STATUS"].ToString() == "1")
                        strstatus = "Active";
                    else
                        strstatus = "Inactive";
                    strHtml += "<td > " + strstatus + "</td>";
                }
                else if (intColumnBodyCount == 3)
                {
                    strHtml += " <td> <div class=\"btn_stl1\">";
                    if (intUpdate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (cbxCnclStatus.Checked == false)
                        {

                            strHtml += " <a style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn1 bt_e\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                            " href=\"pms_ChargeHead.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";

                        }

                    }
                    if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (cbxCnclStatus.Checked == false)
                        {
                            strHtml += "<a    href=\"#\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";

                        }

                    }


                    if (cbxCnclStatus.Checked == true)
                    {
                        strHtml += "<a style=\"opacity: 1;\" class=\"btn act_btn bn4 bt_v\" title=\"VIEW\" onclick='return getdetails(this.href);' " +
                                     " href=\"pms_ChargeHead.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";


                    }
                    strHtml += "</div></td>";
                }
            }
            strHtml += "</tr>";
        }
        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayerChargeHeads objBusinessChargeHead = new clsBusinessLayerChargeHeads();
        clsEntityChargeHeads objEntityChargeHead = new clsEntityChargeHeads();
        int intUserId = 0;
        if (Session["USERID"] != null)
        {
            objEntityChargeHead.UserId = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityChargeHead.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityChargeHead.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.PMS_Vendor_Category);
        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
        if (dtChildRol.Rows.Count > 0)
        {
            string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            string[] strChildDefArrWords = strChildRolDeftn.Split('-');
            foreach (string strC_Role in strChildDefArrWords)
            {
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                {
                    intAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    //HiddenRoleConf.Value = "1";
                }
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                {
                    intUpdate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    // HiddenRoleEdit.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active); ;
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                {
                    intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    hiddenEnableCancl.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                }
            }
        }
        if (cbxCnclStatus.Checked == true)
        {
            objEntityChargeHead.Cancel_status = 0;
        }
        else
        {
            objEntityChargeHead.Cancel_status = 1;
        }
        objEntityChargeHead.CHCategoryId = Convert.ToInt32(ddlCategory.SelectedValue);
        objEntityChargeHead.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        
        DataTable dtVendorCategory = objBusinessChargeHead.ReadChargeHead(objEntityChargeHead);
        divList.InnerHtml = ConvertDataTableToHTML(dtVendorCategory, intUpdate, intEnableCancel);
    }
    [WebMethod]
    public static string CancelChargeHeadReason(string strmemotId, string reasonmust, string usrId, string cnclRsn, string strOrgIdID, string strCorpID)
    {
        clsBusinessLayerChargeHeads objBusinessChargeHead = new clsBusinessLayerChargeHeads();
        clsEntityChargeHeads objEntityChargeHead = new clsEntityChargeHeads();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successcncl";
        string strRandomMixedId = strmemotId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityChargeHead.vendorCategoryID = Convert.ToInt32(strId);
        objEntityChargeHead.UserId = Convert.ToInt32(usrId);
        objEntityChargeHead.OrgId = Convert.ToInt32(strOrgIdID);
        objEntityChargeHead.CorpId = Convert.ToInt32(strCorpID);
        if (reasonmust == "1")
        {
            objEntityChargeHead.CancelReason = cnclRsn;
        }

        else
        {
            objEntityChargeHead.CancelReason = objCommon.CancelReason();
        }

        try
        {
            objBusinessChargeHead.CancelChargeHead(objEntityChargeHead);

        }
        catch
        {
            strRets = "failed";
        }

        return strRets;

    }
    public void LoadChargeHeadCategory()
    {
        clsBusinessLayerChargeHeads objBusinessChargeHead = new clsBusinessLayerChargeHeads();
        clsEntityChargeHeads objEntityChargeHead = new clsEntityChargeHeads();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityChargeHead.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityChargeHead.OrgId = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtAccount = objBusinessChargeHead.ReadChargeHeadCategory(objEntityChargeHead);
        ddlCategory.Items.Clear();

        ddlCategory.DataSource = dtAccount;
       
        ddlCategory.DataTextField = "CHRGCTGRY_NAME";
        ddlCategory.DataValueField = "CHRGCTGRY_ID";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new System.Web.UI.WebControls.ListItem("All", "0"));

        //int prmryVal = Convert.ToInt32(dtAccount.Rows[0]["PRIMARY"].ToString());

        //   Convert.ToInt32( (clsCommonLibrary.ACNT_GRP_ID.PRIMARY).ToString());
        //ListItem selectedListItem = ddlParntGrp.Items.FindByValue(prmryVal.ToString());

        //if (selectedListItem != null)
        //{
        //    selectedListItem.Selected = true;
        //}
    }
     public string PrintCaption(clsEntityVendorCategory ObjEntityRequest)
    {
        clsBusinessLayerReports objBusinessLayerReports = new clsBusinessLayerReports();
        clsEntityReports objEntityReports = new clsEntityReports();
        objEntityReports.Corporate_Id = ObjEntityRequest.CorpId;
        objEntityReports.Organisation_Id = ObjEntityRequest.OrgId;
        //    objEntityReports.User_Id = ObjEntityRequest.User_Id;
        DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(objEntityReports);
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "CHARGE HEAD";
        DateTime datetm = objBusiness.LoadCurrentDate(); ;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string usrName = "<B> Report Generated By: </B>" + Session["USERFULLNAME"];
        string strHidden = "", GuaranteDivsn = "";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        // GuaranteDivsn = "<B> DATE  : </B>" + ObjEntityRequest.FromDate.ToString("dd-MM-yyyy");
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
        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strGuaranteDivsn + strUsrName + strCaptionTabTitle + strCaptionTabstop;
        sbCap.Append(strPrintCaptionTable);
        ////write to  divPrintCaption
        return sbCap.ToString();


    }
    [WebMethod]
    public static string PrintList(string orgID, string corptID, string CnclSts, string statusid,string category,string cattext)
    {
        string strReturn = "";
        clsBusinessLayerChargeHeads objBusinessChargeHead = new clsBusinessLayerChargeHeads();
        clsEntityChargeHeads objEntityChargeHead = new clsEntityChargeHeads();
        clsBusinessLayer objBusinesslayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityChargeHead.OrgId = Convert.ToInt32(orgID);

        objEntityChargeHead.CorpId = Convert.ToInt32(corptID);
        objEntityChargeHead.Cancel_status = Convert.ToInt32(CnclSts);
        int intCorpId = 0;
        if (corptID != "")
            intCorpId = Convert.ToInt32(corptID);


        objEntityChargeHead.Status = Convert.ToInt32(statusid);

        objEntityChargeHead.CHCategoryId = Convert.ToInt32(category);
      

        DataTable dtCategory = objBusinessChargeHead.ReadChargeHead(objEntityChargeHead);
       
        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.CHARGE_HEAD);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CHARGE_HEAD);
        objEntityCommon.CorporateID = objEntityChargeHead.CorpId;
        objEntityCommon.Organisation_Id = objEntityChargeHead.OrgId;
        string strNextNumber = objBusinesslayer.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "chargeheadlist_" + strNextNumber + ".pdf";

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

               // footrtable.AddCell(new PdfPCell(new Phrase(toDt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
               // if (SupName != "")
                //{
                    //footrtable.AddCell(new PdfPCell(new Phrase("ACCOUNT BOOK  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                   // footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    //footrtable.AddCell(new PdfPCell(new Phrase(SupName, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
               // }
                footrtable.AddCell(new PdfPCell(new Phrase("CATEGORY ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                footrtable.AddCell(new PdfPCell(new Phrase(cattext, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                footrtable.AddCell(new PdfPCell(new Phrase("STATUS  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (statusid == "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Inactive", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else if (statusid == "1")
                {
                  footrtable.AddCell(new PdfPCell(new Phrase("Active", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
               }
                else if (statusid == "2")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("All", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                //else if (PurchaseStatus == "3")
               // {
               //     footrtable.AddCell(new PdfPCell(new Phrase("All", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
               // }
                document.Add(footrtable);

                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(3);
                float[] footrsBody = { 14, 18, 14 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

              TBCustomer.AddCell(new PdfPCell(new Phrase("CHARGE HEAD", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("CALCULATION METHOD", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("STATUS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                string strRandom = objCommon.Random_Number();
                if (dtCategory.Rows.Count > 0)
                {
                    for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
                    {
                        string strId = dtCategory.Rows[0][0].ToString();
                        int usrId = Convert.ToInt32(strId);
                        int intIdLength = dtCategory.Rows[0][0].ToString().Length;
                        string stridLength = intIdLength.ToString("00");
                        string Id = stridLength + strId + strRandom;
                        string strCancTransaction = dtCategory.Rows[intRowBodyCount][3].ToString();
                        int CNT = intRowBodyCount + 1;
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["CHRGHD_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        string calculate = "";
                        if (dtCategory.Rows[intRowBodyCount]["CHRGHD_CALCULATE"].ToString() == "0")
                        {
                            calculate = "Additon";
                        }

                        else
                        {
                            calculate = "Deduction";
                        }
                        TBCustomer.AddCell(new PdfPCell(new Phrase(calculate, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                        string strStatusImg = "";
                       if (dtCategory.Rows[intRowBodyCount]["CHRGHD_STATUS"].ToString() == "1")
                       {
                           strStatusImg = "Active";
                       }
                       
                          else
                           {
                               strStatusImg = "Inactive";
                           }
                           
                       
                        
                        
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strStatusImg, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    
                      
                        }
                       // TBCustomer.AddCell(new PdfPCell(new Phrase(strStatusImg, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    
                
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
             headtable.AddCell(new PdfPCell(new Phrase("CHARGE HEAD LIST ", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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
    public static string PrintCSV(string orgID, string corptID, string CnclSts, string statusid, string category, string cattext)
    {
        string strReturn = "";
        clsBusinessLayerChargeHeads objBusinessChargeHead = new clsBusinessLayerChargeHeads();
        clsEntityChargeHeads objEntityChargeHead = new clsEntityChargeHeads();
        clsBusinessLayer objBusinesslayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        PMS_PMS_Master_pms_Charge_Heads_pms_ChargeHeadList OBJ = new PMS_PMS_Master_pms_Charge_Heads_pms_ChargeHeadList();
        objEntityChargeHead.OrgId = Convert.ToInt32(orgID);

        objEntityChargeHead.CorpId = Convert.ToInt32(corptID);
        objEntityChargeHead.Cancel_status = Convert.ToInt32(CnclSts);
        int intCorpId = 0;
        if (corptID != "")
            intCorpId = Convert.ToInt32(corptID);
        objEntityChargeHead.Status = Convert.ToInt32(statusid);
        objEntityChargeHead.CHCategoryId = Convert.ToInt32(category);

        DataTable dtCategory = objBusinessChargeHead.ReadChargeHead(objEntityChargeHead); ;

        strReturn = OBJ.LoadTable_CSV(dtCategory, objEntityChargeHead, CnclSts, statusid,category,cattext);
        return strReturn;
    }
    public string LoadTable_CSV(DataTable dtCategory, clsEntityChargeHeads objEntityChargeHead, string CnclSts, string statusid, string category, string cattext)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dt = GetTable(dtCategory, objEntityChargeHead, CnclSts, statusid,category,cattext);
        string strResult = DataTableToCSV(dt, ',');
        string strImagePath = "";
        string filepath = "";
        if (objEntityChargeHead.CorpId != 0)
        {
            objEntityCommon.CorporateID = objEntityChargeHead.CorpId;
        }
        if (objEntityChargeHead.OrgId != 0)
        {
            objEntityCommon.Organisation_Id = objEntityChargeHead.OrgId;
        }
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CHARGEHEAD_CSV);
        string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
        string newFilePath = Server.MapPath("/CustomFiles/PMS_CSV/Charge_head/ChargeList_" + strNextId + ".csv");
        System.IO.File.WriteAllText(newFilePath, strResult);
        filepath = "ChargeList_" + strNextId + ".csv";
        strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CHARGEHEAD_CSV);
        return strImagePath + filepath;
    }
    public DataTable GetTable(DataTable dtCategory, clsEntityChargeHeads objEntityChargeHead, string CnclSts, string statusid, string category, string cattext)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,                                                           
                                                      clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,    
                                                              };
        int intCorpId = 0;
        if (objEntityChargeHead.CorpId != 0)
        {
            intCorpId = objEntityChargeHead.CorpId;
        }

        //DataTable dtCorpDetail = new DataTable();
        //dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        //int Decimalcount = 0;
        //if (dtCorpDetail.Rows.Count > 0)
        //{
        //    objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
        //    Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        //}

        string FORNULL = "";
        DataTable table = new DataTable();
        string strRandom = objCommon.Random_Number();
        table.Columns.Add("CHARGE HEAD LIST", typeof(string));
        table.Columns.Add(" ", typeof(string));
        table.Columns.Add("  ", typeof(string));
        table.Columns.Add("   ", typeof(string));
        //table.Columns.Add("    ", typeof(string));
        //table.Columns.Add("     ", typeof(string));
        //table.Columns.Add("      ", typeof(string));

        //table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        //table.Rows.Add("FROM DATE :", '"' + from + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        //table.Rows.Add("TO DATE :", '"' + toDt + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        //if (Suplier != "")
        //    table.Rows.Add("SUPPLIER :", '"' + Suplier.TrimEnd(',', ' ') + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        ////if (Status == "1")
        ////    table.Rows.Add("STATUS :", "Active", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        ////else if (Status == "0")
        ////    table.Rows.Add("STATUS :", "Inactive", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        ////else
            table.Rows.Add("CATEGORY :", '"'+cattext+'"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        if (statusid == "1")
            table.Rows.Add("VENDOR STATUS :", "Active", '"' + FORNULL + '"', '"' + FORNULL + '"');
        else if (statusid == "0")
            table.Rows.Add("VENDOR STATUS :", "Inactive", '"' + FORNULL + '"', '"' + FORNULL + '"');
        else
            table.Rows.Add("VENDOR STATUS :", "All", '"' + FORNULL + '"', '"' + FORNULL + '"');

        //table.Rows.Add("PURCHASE STATUS :", "All", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("CHARGE HEAD", "CALCULATION METHOD", "STATUS");

        if (dtCategory.Rows.Count > 0)
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
            {
                string strId = dtCategory.Rows[0][0].ToString();
                int usrId = Convert.ToInt32(strId);
                int intIdLength = dtCategory.Rows[0][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                string strCancTransaction = dtCategory.Rows[intRowBodyCount][3].ToString();
                int CNT = intRowBodyCount + 1;
                string calculate = "";
                if (dtCategory.Rows[intRowBodyCount]["CHRGHD_CALCULATE"].ToString() == "0")
                {
                    calculate = "Additon";
                }

                else
                {
                    calculate = "Deduction";
                }
                string strStatusImg = "";
                if (dtCategory.Rows[intRowBodyCount]["CHRGHD_STATUS"].ToString() == "1")
                {
                    strStatusImg = "ACTIVE";
                }
                else
                {

                    strStatusImg = "INACTIVE";

                }
                table.Rows.Add('"' + dtCategory.Rows[intRowBodyCount]["CHRGHD_NAME"].ToString() + '"', '"' + calculate+'"', '"' + strStatusImg + '"');

            }

        }
        else
        {
            table.Rows.Add(" No data available in table", '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        return table;
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
}