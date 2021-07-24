using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using EL_Compzit.EntityLayer_FMS;
using BL_Compzit;
using BL_Compzit.BusinessLayer_FMS;
using CL_Compzit;
using System.Data;
using BL_Compzit.BusineesLayer_FMS;
using System.Text;
using System.Web.Services;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Threading.Tasks;

public partial class FMS_FMS_Master_fms_Sales_Master_fms_Sales_Master_List : System.Web.UI.Page
{
    clsBusinessSales objBusinessSales = new clsBusinessSales();
    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
    clsCommonLibrary objCommon = new clsCommonLibrary();
    public static int TaxEnable = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        clsEntitySales objEntity = new clsEntitySales();
        if (!IsPostBack)
        {
            //ddlCustomer.Focus();


            loadCustomerLedger();
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intCorpId = 0;
            HiddenEnableModify.Value = Convert.ToString(intEnableModify);
            HiddenEnableDelete.Value = Convert.ToString(intEnableCancel);

            clsEntityCommon objentcommn = new clsEntityCommon();




            if (Session["USERID"] != null)
            {
                objEntity.User_Id = Convert.ToInt32(Session["USERID"]);
                intUserId = Convert.ToInt32(Session["USERID"]);
                //HiddenusrId.Value = intUserId.ToString();
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["CORPOFFICEID"] != null)
            {
                objEntity.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objentcommn.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objentcommn.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                objEntity.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["FINCYRID"] != null)
            {
                objentcommn.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            string caption = PrintCaption(objEntity);
            divPrintCaption.InnerHtml = caption;

            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.SALES);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            HiddenReopen.Value = "0";
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intEnableAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        // Hiddenenabladd.Value = intEnableAdd.ToString();
                    }

                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenEnableModify.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenEnableDelete.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_ACCOUNT).ToString())
                    {
                        HiddenProvisionSts.Value = (clsCommonLibrary.StatusAll.Active).ToString();

                        // HiddenHrCnfrm.Value = intEnableHrConfirm.ToString(); ;

                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        HiddenConfirmStatus.Value = "1";
                    }

                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        HiddenReopen.Value = "1";
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString())
                    {
                        HiddenFieldAuditCloseReopenSts.Value = "1";
                    }

                }
            }

            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                divAdd.Visible = true;
            }
            else
            {
                divAdd.Visible = false;
            }
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                            clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_TAX_ENABLED
                                                       };

            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenCurrncyId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                HiddenCancelReasonMust.Value = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                if (dtCorpDetail.Rows[0]["GN_TAX_ENABLED"].ToString() != "")
                {
                    TaxEnable = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_TAX_ENABLED"].ToString());
                }
            }




            DataTable dtfinaclYear = objBusinessLayer.ReadFinancialYearById(objentcommn);

            if (dtfinaclYear.Rows.Count > 0)
            {
                objEntity.FromPeriod = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString());
                objEntity.ToPeriod = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString());
                HiddenFinancialStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                HiddenFnancialEndDeate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();

                objEntity.StartDate = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString());
                objEntity.EndDate = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString());
                DataTable dtAcntClsDate = objBusinessLayer.ReadAccountClsDate(objentcommn);
                objBusinessSales.readAcntClsDate(objEntity);

                int YearEndCls = 0;
                if (Session["FINCYRID"] != null)
                {
                    objentcommn.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
                }
                else
                {
                    Response.Redirect("/Default.aspx");
                }
                DataTable dtYearEndClsDate = objBusinessLayer.ReadYearEndCloseDate(objentcommn);
                if (dtYearEndClsDate.Rows.Count > 0)
                {
                    YearEndCls = 1;
                }

                if (YearEndCls == 1)
                {
                    divAdd.Visible = false;
                }

                DateTime curdate = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());


                if (curdate >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate <= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                {
                    txtTodate.Value = objBusinessLayer.LoadCurrentDateInString();
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
                else if (strInsUpd == "CNFM")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationcnfrm", "SuccessConfirmationcnfrm();", true);
                }
                else if (strInsUpd == "CNFMERROR")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ConfirmError", "ConfirmError();", true);
                }
                if (Request.QueryString["InsUpd"] == "Cncl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessClose", "SuccessClose();", true);
                }
                if (Request.QueryString["InsUpd"] == "StsCh")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessStatusChange", "SuccessStatusChange();", true);
                }
                if (Request.QueryString["InsUpd"] == "AuditClosed")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AuditClosed", "AuditClosed();", true);
                }
                if (Request.QueryString["InsUpd"] == "AcntClosed")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AcntClosed", "AcntClosed();", true);
                }
                else if (strInsUpd == "ERROR")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Error", "Error();", true);
                }

            }

            //objEntity.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
            //objEntity.SalesSts = Convert.ToInt32(ddlsaleSts.SelectedItem.Value);
            //if (cbxCnclStatus.Checked == true)
            //{
            //    objEntity.cnclStatus = 1;
            //}
            //else
            //{
            //    objEntity.cnclStatus = 0;
            //}
            //if (ddlCustomer.SelectedItem.Value != "--SELECT CUSTOMER--")
            //{
            //    objEntity.LedgerId = Convert.ToInt32(ddlCustomer.SelectedItem.Value);
            //}
            //DataTable dtCategory = objBusinessSales.ReadSalesDetailsList_Sum(objEntity);
            //if (dtCategory.Rows.Count > 0)
            //{
            //  //  tdtotal.InnerHtml = dtCategory.Rows[0]["TOTAL"].ToString();
            //}
        }

    }

    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string ConfirmSalesDetails(string strUserID, string strPayemntId, string strOrgIdID, string strCorpID, string strFinID)
    {


        clsBusinessSales objBussiness = new clsBusinessSales();
        clsEntitySales ObjEntityRequest = new clsEntitySales();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successConfirm";
        string NewRev = "";

        string strRandomMixedId = strPayemntId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        ObjEntityRequest.SalesId = Convert.ToInt32(strId);
        ObjEntityRequest.Organisation_id = Convert.ToInt32(strOrgIdID);
        ObjEntityRequest.Corporate_id = Convert.ToInt32(strCorpID);
        ObjEntityRequest.User_Id = Convert.ToInt32(strUserID);
        ObjEntityRequest.FinancialYrId = Convert.ToInt32(strFinID);
        ObjEntityRequest.Status = 1;
        try
        {
            DataTable dt = objBussiness.ReadSalesDetailsById(ObjEntityRequest);
            DataTable dtProduct = objBussiness.ReadProductSalesById(ObjEntityRequest);

            List<clsEntitySales> objEntitySalesList = new List<clsEntitySales>();

            string strdate = "";

            if (dt.Rows.Count > 0)
            {
                ObjEntityRequest.NetTotal = Convert.ToDecimal(dt.Rows[0]["SALES_NET_TOTAL"].ToString());
                ObjEntityRequest.LedgerId = Convert.ToInt32(dt.Rows[0]["CSTMR_ID"].ToString());

                if (dtProduct.Rows.Count > 0)
                {
                    for (int i = 0; i < dtProduct.Rows.Count; i++)
                    {
                        clsEntitySales objEntitySub = new clsEntitySales();

                        objEntitySub.SalesProductId = Convert.ToInt32(dtProduct.Rows[i]["SALS_PRODUCT_ID"].ToString());
                        objEntitySalesList.Add(objEntitySub);
                    }
                }

                if (dt.Rows[0]["SALES_CNCL_USR_ID"].ToString() != "")
                {
                    strRets = "alrdydeleted";
                }
                else if (dt.Rows[0]["SALES_CNFRM_STS"].ToString() != "0")
                {
                    strRets = "alrdyconfrm";
                }
                else
                {
                    objBussiness.ConfirmSales(ObjEntityRequest, objEntitySalesList);
                }
            }
        }
        // }
        catch
        {
            strRets = "failed";
        }
        //HttpContext.Current.Session["CONFIRM_STS"] = strRets;
        return strRets;

    }

    public void loadCustomerLedger()
    {

        clsEntitySales ObjEntitySales = new clsEntitySales();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntitySales.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntitySales.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            //intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntitySales.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ObjEntitySales.LedgerType = "SALE";
        DataTable dtlCstmrLedger = objBusinessSales.ReadCustomerLedger(ObjEntitySales);
        if (dtlCstmrLedger.Rows.Count > 0)
        {
            ddlCustomer.DataSource = dtlCstmrLedger;
            ddlCustomer.DataTextField = "LDGR_NAME";
            ddlCustomer.DataValueField = "LDGR_ID";
            ddlCustomer.DataBind();

        }

        ddlCustomer.Items.Insert(0, "--SELECT CUSTOMER--");
    }
    [WebMethod]
    public static string CancelSalesMstr(string strmemotId, string reasonmust, string usrId, string cnclRsn)
    {

        clsBusinessSales objBusinessSales = new clsBusinessSales();
        clsEntitySales ObjEntitySales = new clsEntitySales();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successcncl";
        string strRandomMixedId = strmemotId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        ObjEntitySales.SalesId = Convert.ToInt32(strId);
        ObjEntitySales.User_Id = Convert.ToInt32(usrId);

        if (reasonmust == "1")
        {
            ObjEntitySales.CancelReason = cnclRsn;
        }

        else
        {
            ObjEntitySales.CancelReason = objCommon.CancelReason();
        }

        try
        {
            objBusinessSales.CancelSalesDtlsById(ObjEntitySales);

        }
        catch
        {
            strRets = "failed";
        }

        return strRets;

    }
    [WebMethod]
    public static string ChangeSaleStatus(string StrId, string stsmode, string usrId)
    {

        clsBusinessSales objBusinessSales = new clsBusinessSales();
        clsEntitySales ObjEntitySales = new clsEntitySales();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "success";
        string strRandomMixedId = StrId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        ObjEntitySales.SalesId = Convert.ToInt32(strId);
        ObjEntitySales.User_Id = Convert.ToInt32(usrId);
        if (stsmode == "1")
        {
            ObjEntitySales.Status = 0;
        }
        if (stsmode == "0")
        {
            ObjEntitySales.Status = 1;
        }
        try
        {
            objBusinessSales.ChangeStatusById(ObjEntitySales);

        }
        catch
        {
            strRets = "failed";
        }

        return strRets;

    }
    [WebMethod]
    public static string PrintPDF(string saleId, string orgID, string corptID, string UsrName)
    {

        string strRandomMixedId = saleId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        clsBusinessSales objBusinessSales = new clsBusinessSales();
        clsCommonLibrary objCommn = new clsCommonLibrary();
        clsEntitySales ObjEntitySales = new clsEntitySales();
        if (corptID != null)
        {
            ObjEntitySales.Corporate_id = Convert.ToInt32(corptID);
        }
        if (orgID != null)
        {
            ObjEntitySales.Organisation_id = Convert.ToInt32(orgID);
        }
        ObjEntitySales.SalesId = Convert.ToInt32(strId);
        string PreparedBy = "";
        if (UsrName != null)
        {
            PreparedBy = UsrName;
        }


        DataTable dt = objBusinessSales.ReadSalesDetailsById(ObjEntitySales);
        DataTable dtProduct = objBusinessSales.ReadProductSalesById(ObjEntitySales);
        ObjEntitySales.LedgerId = Convert.ToInt32(dt.Rows[0]["CSTMR_ID"].ToString());
        DataTable dtCust = new DataTable();
        if (Convert.ToInt32(dt.Rows[0]["SALES_CUST_TYP"].ToString()) == 0)
        {
            dtCust = objBusinessSales.ReadCustomerDtls(ObjEntitySales);
            if (dtCust.Rows.Count == 0)
            {
                //dtCust.Columns.Add("CSTMR_NAME", typeof(string));
                //dtCust.Columns.Add("CSTMR_ADDRESS1", typeof(string));
                //dtCust.Columns.Add("CSTMR_ADDRESS2", typeof(string));
                //dtCust.Columns.Add("CSTMR_ADDRESS3", typeof(string));
                //dtCust.Columns.Add("CSTMR_EMAIL", typeof(string));
                DataRow drDtl = dtCust.NewRow();

                drDtl["CSTMR_NAME"] = dt.Rows[0]["LDGR_COMTN_NAME"].ToString();

                drDtl["CSTMR_ADDRESS1"] = dt.Rows[0]["LDGR_ADDRESS"].ToString();
                drDtl["CSTMR_ADDRESS2"] = "";

                drDtl["CSTMR_ADDRESS3"] = "";
                drDtl["CSTMR_EMAIL"] = "";
                dtCust.Rows.Add(drDtl);


            }


        }
        else
        {
            dtCust.Columns.Add("CSTMR_NAME", typeof(string));
            dtCust.Columns.Add("CSTMR_ADDRESS1", typeof(string));
            dtCust.Columns.Add("CSTMR_ADDRESS2", typeof(string));
            dtCust.Columns.Add("CSTMR_ADDRESS3", typeof(string));
            dtCust.Columns.Add("CSTMR_EMAIL", typeof(string));
            DataRow drDtl = dtCust.NewRow();

            drDtl["CSTMR_NAME"] = dt.Rows[0]["SALES_CUST_NAME"].ToString();

            drDtl["CSTMR_ADDRESS1"] = dt.Rows[0]["SALES_CUST_ADDRS_ONE"].ToString();
            drDtl["CSTMR_ADDRESS2"] = dt.Rows[0]["SALES_CUST_ADDRS_TWO"].ToString();

            drDtl["CSTMR_ADDRESS3"] = dt.Rows[0]["SALES_CUST_ADDRS_THREE"].ToString();
            drDtl["CSTMR_EMAIL"] = "";
            dtCust.Rows.Add(drDtl);



        }
        DataTable dtCorp = objBusinessSales.ReadCorpDtls(ObjEntitySales);

        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        objEntityCommon.CorporateID = ObjEntitySales.Corporate_id;
        objEntityCommon.Organisation_Id = ObjEntitySales.Organisation_id;
        objEntityCommon.Vouchar_Type = Convert.ToInt32(clsCommonLibrary.VOUCHER_TYPE.SALE);

        DataTable dtVersion = objBusinessLayer.ReadPrintVersion(objEntityCommon);

        string strReturn = "";

        if (dtVersion.Rows.Count > 0)
        {
            int Version_flg = Convert.ToInt32(dtVersion.Rows[0][0].ToString());

            if (dtVersion.Rows[0][0].ToString() == "1")
            {
                strReturn = objBusinessSales.PdfPrintVersion1(strId, dt, dtProduct, dtCust, dtCorp, ObjEntitySales, PreparedBy, Version_flg);
            }
            else if (dtVersion.Rows[0][0].ToString() == "2")
            {
                strReturn = objBusinessSales.PdfPrintVersion2(strId, dt, dtProduct, dtCust, dtCorp, ObjEntitySales, PreparedBy, Version_flg);
            }
            else if (dtVersion.Rows[0][0].ToString() == "3")
            {
                strReturn = objBusinessSales.PdfPrintVersion2(strId, dt, dtProduct, dtCust, dtCorp, ObjEntitySales, PreparedBy, Version_flg);
            }
        }
        return strReturn;
    }

    //public string PdfPrintVersion1(string strId, DataTable dt, DataTable dtProduct, DataTable dtCust, DataTable dtCorp, clsEntitySales ObjEntitySales, string PreparedBy, int Version_flg)
    //{
    //    string strRet = "true";
    //    //clsCommonLibrary objCommon = new clsCommonLibrary();
    //    //   int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.SALE_INVOICE);
    //    //string strImageName = "Sale_Invoice" + strId + ".pdf";
    //    // string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.SALE_INVOICE);

    //    //strRet = strImagePath + strImageName;

    //    clsBusinessLayer objBusiness = new clsBusinessLayer();
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.SALE_INVOICE);
    //    string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.SALE_INVOICE);


    //    clsEntityCommon objEntityCommon = new clsEntityCommon();
    //    if (ObjEntitySales.Corporate_id != 0)
    //    {
    //        objEntityCommon.CorporateID = ObjEntitySales.Corporate_id;
    //    }
    //    if (ObjEntitySales.Organisation_id != 0)
    //    {
    //        objEntityCommon.Organisation_Id = ObjEntitySales.Organisation_id;
    //    }

    //    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
    //    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SALES_PRINT);
    //    string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
    //    string strImageName = "Sale_Invoice" + strId + "_" + strNextNumber + ".pdf";

    //    Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);
    //    Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
    //    try
    //    {

    //        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
    //        {
    //            System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(strImagePath));

    //            FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
    //            PdfWriter writer = PdfWriter.GetInstance(document, file);
    //            document.Open();

    //            //  string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CORPORATE_LOGOS) + "corporate-logo.jpg";
    //            string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DEFAULT_LOGO);
    //            if (dtCorp.Rows.Count > 0)
    //            {
    //                if (dtCorp.Rows[0]["CORPRT_ICON"].ToString() != "")
    //                {
    //                    string imaeposition = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
    //                    string icon = dtCorp.Rows[0]["CORPRT_ICON"].ToString();

    //                    strImageLogo = imaeposition + icon;
    //                    //objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit) + dtCorp.Rows[0]["CORPRT_ICON"].ToString();
    //                }
    //            }

    //            var FontBlue = new BaseColor(0, 174, 239);
    //            var FontBlueGrey = new BaseColor(79, 167, 206);

    //            PdfPTable headImg = new PdfPTable(2);

    //            if (strImageLogo != "")
    //            {


    //                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));

    //                image.ScalePercent(PdfPCell.ALIGN_CENTER);
    //                image.ScaleToFit(100f, 80f);

    //                headImg.AddCell(new PdfPCell(image) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });


    //            }
    //            else
    //            {
    //                headImg.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });
    //            }

    //            if (dt.Rows[0]["SALES_CNFRM_STS"].ToString() == "1")
    //                headImg.AddCell(new PdfPCell(new Phrase("SALES INVOICE", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_RIGHT });
    //            else
    //                headImg.AddCell(new PdfPCell(new Phrase("PROFORMA INVOICE", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_RIGHT });



    //            float[] headersHeading = { 70, 30 };
    //            headImg.SetWidths(headersHeading);
    //            headImg.WidthPercentage = 100;

    //            document.Add(headImg);



    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            PdfPTable footrtable = new PdfPTable(2);
    //            float[] footrsBody = { 50, 50 };
    //            footrtable.SetWidths(footrsBody);
    //            footrtable.WidthPercentage = 100;



    //            footrtable.AddCell(new PdfPCell(new Phrase("From", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            footrtable.AddCell(new PdfPCell(new Phrase("For", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            if (dtCust.Rows.Count > 0)
    //            {
    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            }
    //            if (dtCust.Rows.Count > 0)
    //            {
    //                if (dtCust.Rows[0][4].ToString().Trim() != "")
    //                {
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                }

    //                else
    //                {
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                }
    //            }
    //            else
    //            {
    //                footrtable.AddCell(new PdfPCell(new Phrase("                          ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase("                          ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });


    //            }
    //            document.Add(footrtable);



    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //            PdfPTable footrtables = new PdfPTable(2);
    //            float[] footrsBodys = { 15, 85 };
    //            footrtables.SetWidths(footrsBodys);
    //            footrtables.WidthPercentage = 100;




    //            footrtables.AddCell(new PdfPCell(new Phrase("Order No.", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["SALES_ORDERNO"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtables.AddCell(new PdfPCell(new Phrase("Sales Ref #", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["SALES_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtables.AddCell(new PdfPCell(new Phrase("Date", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["SALES_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });


    //            document.Add(footrtables);



    //            var FontGrey = new BaseColor(134, 152, 160);
    //            var FontBordrGrey = new BaseColor(236, 236, 236);


    //            if (dtProduct.Rows.Count > 0)
    //            {

    //                string netTotal = "", grossTotal = "", taxTotal = "", discTotal = "";
    //                string strcurrenWord = "", strCrncyAbbrv="";

    //                if (dt.Rows[0]["CRNCY_STS"].ToString() == "1")
    //                {
    //                    strCrncyAbbrv = dt.Rows[0]["CRNCMST_ABBRV"].ToString();

    //                    if (dt.Rows[0]["SALES_GROSS_TOTAL"].ToString() != "")
    //                    {

    //                        grossTotal = dt.Rows[0]["SALES_GROSS_TOTAL"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);


    //                        grossTotal = strNetAmountDebitComma;
    //                    }
    //                    if (dt.Rows[0]["SALES_TAX_TOTAL"].ToString() != "")
    //                    {


    //                        taxTotal = dt.Rows[0]["SALES_TAX_TOTAL"].ToString();

    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);

    //                        taxTotal = strNetAmountDebitComma;

    //                    }
    //                    if (dt.Rows[0]["SALES_DISCOUNT"].ToString() != "")
    //                    {



    //                        discTotal = dt.Rows[0]["SALES_DISCOUNT"].ToString();

    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);

    //                        discTotal = strNetAmountDebitComma;

    //                    }
    //                    if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
    //                    {

    //                        netTotal = dt.Rows[0]["SALES_NET_TOTAL"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);

    //                        netTotal = strNetAmountDebitComma;

    //                    }
    //                    objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());

    //                    if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
    //                    {
    //                        clsBusinessLayer ObjBusiness = new clsBusinessLayer();
    //                        strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, dt.Rows[0]["SALES_NET_TOTAL"].ToString());
    //                    }
    //                }
    //                else
    //                {
    //                    strCrncyAbbrv = dt.Rows[0]["DEFULT_ABRVTN"].ToString();

    //                    if (dt.Rows[0]["SALES_GROSS_TOTAL"].ToString() != "")
    //                    {
    //                        grossTotal = dt.Rows[0]["SALES_GROSS_TOTAL"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);

    //                        grossTotal = strNetAmountDebitComma;



    //                    }
    //                    if (dt.Rows[0]["SALES_TAX_TOTAL"].ToString() != "")
    //                    {
    //                        taxTotal = dt.Rows[0]["SALES_TAX_TOTAL"].ToString();

    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);

    //                        taxTotal = strNetAmountDebitComma;

    //                    }
    //                    if (dt.Rows[0]["SALES_DISCOUNT"].ToString() != "")
    //                    {
    //                        discTotal = dt.Rows[0]["SALES_DISCOUNT"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);
    //                        discTotal = strNetAmountDebitComma;


    //                    }
    //                    if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
    //                    {
    //                        netTotal = dt.Rows[0]["SALES_NET_TOTAL"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);
    //                        netTotal = strNetAmountDebitComma;

    //                    }
    //                    objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["DEFULT_CRNCMST_ID"].ToString());

    //                    if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
    //                    {
    //                        clsBusinessLayer ObjBusiness = new clsBusinessLayer();
    //                        strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, dt.Rows[0]["SALES_NET_TOTAL"].ToString());
    //                    }
    //                }



    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //                var FontRed = new BaseColor(202, 3, 20);
    //                var FontGreen = new BaseColor(46, 179, 51);
    //                var FontGray = new BaseColor(138, 138, 138);


    //                if (TaxEnable == 1)
    //                {


    //                    PdfPTable table2 = new PdfPTable(6);
    //                    float[] tableBody2 = { 34, 10, 14, 12, 15, 15 };
    //                    table2.SetWidths(tableBody2);
    //                    table2.WidthPercentage = 100;
    //                    table2.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    // table2.AddCell(new PdfPCell(new Phrase("DISCOUNT %", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });
    //                    table2.AddCell(new PdfPCell(new Phrase("DISC", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    //table2.AddCell(new PdfPCell(new Phrase("TAX", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("TAX", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("TOTAL" + " (" + strCrncyAbbrv + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });

    //                    for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
    //                    {
    //                        string ProductPrice = "";
    //                        string ProductDisAmt = "";
    //                        string ProductTaxAmt = "";
    //                        string ProductTtlAmt = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString() != "")
    //                        {
    //                            ProductPrice = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
    //                            ProductPrice = strNetAmountDebitComma;

    //                        }
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString() != "")
    //                        {
    //                            ProductDisAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
    //                            ProductDisAmt = strNetAmountDebitComma;

    //                        }

    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_TAX_AMT"].ToString() != "")
    //                        {
    //                            ProductTaxAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_TAX_AMT"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTaxAmt, objEntityCommon);
    //                            ProductTaxAmt = strNetAmountDebitComma;

    //                        }
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString() != "")
    //                        {
    //                            ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
    //                            ProductTtlAmt = strNetAmountDebitComma;

    //                        }


    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_QTY"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        //  table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        //table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["TAX_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductTaxAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6 });
    //                    //  table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                    table2.AddCell(new PdfPCell(new Phrase("Gross Total  ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
    //                    table2.AddCell(new PdfPCell(new Phrase(grossTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                    table2.AddCell(new PdfPCell(new Phrase("Tax Amount   ", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontRed))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
    //                    table2.AddCell(new PdfPCell(new Phrase(taxTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, FontRed))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
    //                    table2.AddCell(new PdfPCell(new Phrase("Discount   ", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontGreen))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
    //                    table2.AddCell(new PdfPCell(new Phrase(discTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, FontGreen))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
    //                    table2.AddCell(new PdfPCell(new Phrase("Net Total   ", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
    //                    table2.AddCell(new PdfPCell(new Phrase(netTotal, FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                    //table2.AddCell(new PdfPCell(new Phrase("Net Total (In words)", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });
    //                    //table2.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });



    //                    //table2.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontBlue });



    //                    document.Add(table2);

    //                }
    //                else
    //                {
    //                    PdfPTable table2 = new PdfPTable(5);
    //                    float[] tableBody2 = { 38, 12, 12, 16, 22 };
    //                    table2.SetWidths(tableBody2);
    //                    table2.WidthPercentage = 100;
    //                    table2.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });
    //                    table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });
    //                    table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });
    //                    // table2.AddCell(new PdfPCell(new Phrase("DISCOUNT %", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });
    //                    table2.AddCell(new PdfPCell(new Phrase("DISC", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });
    //                    table2.AddCell(new PdfPCell(new Phrase("TOTAL" + " (" + strCrncyAbbrv + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });

    //                    for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
    //                    {

    //                        string ProductPrice = "";
    //                        string ProductDisAmt = "";

    //                        string ProductTtlAmt = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString() != "")
    //                        {
    //                            ProductPrice = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
    //                            ProductPrice = strNetAmountDebitComma;

    //                        }
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString() != "")
    //                        {
    //                            ProductDisAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
    //                            ProductDisAmt = strNetAmountDebitComma;

    //                        }

    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString() != "")
    //                        {
    //                            ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
    //                            ProductTtlAmt = strNetAmountDebitComma;

    //                        }

    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_QTY"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        //       table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
    //                    //  table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                    table2.AddCell(new PdfPCell(new Phrase("Gross Total", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 4 });
    //                    table2.AddCell(new PdfPCell(new Phrase(grossTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                    table2.AddCell(new PdfPCell(new Phrase("Discount", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontGreen))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 4 });
    //                    table2.AddCell(new PdfPCell(new Phrase(discTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, FontGreen))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                    table2.AddCell(new PdfPCell(new Phrase("Net Total", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 4 });
    //                    table2.AddCell(new PdfPCell(new Phrase(netTotal, FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                    document.Add(table2);
    //                }

    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));


    //                PdfPTable tablettl = new PdfPTable(2);
    //                float[] tablettlBody = { 0, 100 };
    //                tablettl.SetWidths(tablettlBody);
    //                tablettl.WidthPercentage = 100;

    //                tablettl.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                tablettl.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontBlue });
    //                document.Add(tablettl);


    //            }


    //            if (dt.Rows[0]["SALES_DESC"].ToString().Trim() != "")
    //            {
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk("Remarks", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //                document.Add(new Paragraph(new Chunk(dt.Rows[0]["SALES_DESC"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //            }


    //            string CheckedBy = "";
    //            if (dt.Rows[0]["SALES_CNFRM_STS"].ToString() == "1")
    //            {
    //                CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
    //            }

    //            var FontColourPrprd = new BaseColor(33, 150, 243);
    //            var FontColourChkd = new BaseColor(76, 175, 80);
    //            var FontColourAuthrsd = new BaseColor(255, 87, 34);

    //            PdfPTable table3 = new PdfPTable(3);
    //            float[] tableBody3 = { 33, 33, 33 };
    //            table3.SetWidths(tableBody3);
    //            table3.WidthPercentage = 100;
    //            table3.TotalWidth = 600F;

    //            table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourPrprd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("Checked by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourChkd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("Authorized by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourAuthrsd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });

    //            table3.WriteSelectedRows(0, -1, 0, 80, writer.DirectContent);

    //            document.Close();

    //            strRet = strImagePath + strImageName;
    //        }


    //    }
    //    catch (Exception)
    //    {
    //        document.Close();
    //        strRet = "false";

    //    }

    //    return strRet;
    //}

    //public string PdfPrintVersion2(string strId, DataTable dt, DataTable dtProduct, DataTable dtCust, DataTable dtCorp, clsEntitySales ObjEntitySales, string PreparedBy, int Version_flg)
    //{
    //    string strRet = "true";
    //    //clsCommonLibrary objCommon = new clsCommonLibrary();
    //    //   int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.SALE_INVOICE);
    //    //string strImageName = "Sale_Invoice" + strId + ".pdf";
    //    // string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.SALE_INVOICE);

    //    //strRet = strImagePath + strImageName;

    //    clsBusinessLayer objBusiness = new clsBusinessLayer();
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.SALE_INVOICE);
    //    string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.SALE_INVOICE);


    //    clsEntityCommon objEntityCommon = new clsEntityCommon();
    //    if (ObjEntitySales.Corporate_id != 0)
    //    {
    //        objEntityCommon.CorporateID = ObjEntitySales.Corporate_id;
    //    }
    //    if (ObjEntitySales.Organisation_id != 0)
    //    {
    //        objEntityCommon.Organisation_Id = ObjEntitySales.Organisation_id;
    //    }

    //    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
    //    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SALES_PRINT);
    //    string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
    //    string strImageName = "Sale_Invoice" + strId + "_" + strNextNumber + ".pdf";

    //    DataTable dtBankDtls = objBusinessLayer.ReadBankDetails(objEntityCommon);

    //    Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);
    //    Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
    //    try
    //    {

    //        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
    //        {
    //            System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(strImagePath));

    //            FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
    //            PdfWriter writer = PdfWriter.GetInstance(document, file);
    //            document.Open();

    //            //  string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CORPORATE_LOGOS) + "corporate-logo.jpg";
    //            string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DEFAULT_LOGO);
    //            if (dtCorp.Rows.Count > 0)
    //            {
    //                if (dtCorp.Rows[0]["CORPRT_ICON"].ToString() != "")
    //                {
    //                    string imaeposition = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
    //                    string icon = dtCorp.Rows[0]["CORPRT_ICON"].ToString();

    //                    strImageLogo = imaeposition + icon;
    //                    //objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit) + dtCorp.Rows[0]["CORPRT_ICON"].ToString();
    //                }
    //            }

    //            var FontBlue = new BaseColor(0, 174, 239);
    //            var FontBlueGrey = new BaseColor(79, 167, 206);

    //            if (Version_flg == 2)
    //            {

    //                PdfPTable headImg = new PdfPTable(2);

    //                if (strImageLogo != "")
    //                {


    //                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));

    //                    image.ScalePercent(PdfPCell.ALIGN_CENTER);
    //                    image.ScaleToFit(100f, 80f);

    //                    headImg.AddCell(new PdfPCell(image) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });


    //                }
    //                else
    //                {
    //                    headImg.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });
    //                }

    //                headImg.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 16, Font.BOLD))) { Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_LEFT });



    //                float[] headersHeading = { 70, 30 };
    //                headImg.SetWidths(headersHeading);
    //                headImg.WidthPercentage = 100;

    //                document.Add(headImg);



    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //            }
    //            else
    //            {
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            }

    //            PdfPTable footrtable = new PdfPTable(2);
    //            float[] footrsBody = { 50, 50 };
    //            footrtable.SetWidths(footrsBody);
    //            footrtable.WidthPercentage = 100;

    //            if (dt.Rows[0]["SALES_CNFRM_STS"].ToString() == "1")
    //                footrtable.AddCell(new PdfPCell(new Phrase("SALES INVOICE", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, PaddingTop = 15 });
    //            else
    //                footrtable.AddCell(new PdfPCell(new Phrase("PROFORMA INVOICE", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, PaddingTop = 15 });

    //            footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtable.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["SALES_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });


    //            footrtable.AddCell(new PdfPCell(new Phrase("To", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, PaddingTop = 20 });

    //            footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });


    //            if (dtCust.Rows.Count > 0)
    //            {
    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //                footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            }
    //            if (dtCust.Rows.Count > 0)
    //            {
    //                if (dtCust.Rows[0][4].ToString().Trim() != "")
    //                {
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                }

    //                else
    //                {
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                }
    //            }
    //            else
    //            {
    //                footrtable.AddCell(new PdfPCell(new Phrase("                          ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase("                          ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });


    //            }
    //            document.Add(footrtable);



    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //            //PdfPTable footrtables = new PdfPTable(2);
    //            //float[] footrsBodys = { 15, 85 };
    //            //footrtables.SetWidths(footrsBodys);
    //            //footrtables.WidthPercentage = 100;




    //            //footrtables.AddCell(new PdfPCell(new Phrase("Order No.", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["SALES_ORDERNO"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //footrtables.AddCell(new PdfPCell(new Phrase("Sales Ref #", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["SALES_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //footrtables.AddCell(new PdfPCell(new Phrase("Date", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["SALES_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });


    //            //document.Add(footrtables);



    //            var FontGrey = new BaseColor(134, 152, 160);
    //            var FontBordrGrey = new BaseColor(236, 236, 236);


    //            if (dtProduct.Rows.Count > 0)
    //            {

    //                string netTotal = "", grossTotal = "", taxTotal = "", discTotal = "";
    //                string strcurrenWord = "", strCrncyAbbrv = "";

    //                if (dt.Rows[0]["CRNCY_STS"].ToString() == "1")
    //                {
    //                    strCrncyAbbrv = dt.Rows[0]["CRNCMST_ABBRV"].ToString();

    //                    if (dt.Rows[0]["SALES_GROSS_TOTAL"].ToString() != "")
    //                    {

    //                        grossTotal = dt.Rows[0]["SALES_GROSS_TOTAL"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);


    //                        grossTotal = strNetAmountDebitComma;
    //                    }
    //                    if (dt.Rows[0]["SALES_TAX_TOTAL"].ToString() != "")
    //                    {


    //                        taxTotal = dt.Rows[0]["SALES_TAX_TOTAL"].ToString();

    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);

    //                        taxTotal = strNetAmountDebitComma;

    //                    }
    //                    if (dt.Rows[0]["SALES_DISCOUNT"].ToString() != "")
    //                    {



    //                        discTotal = dt.Rows[0]["SALES_DISCOUNT"].ToString();

    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);

    //                        discTotal = strNetAmountDebitComma;

    //                    }
    //                    if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
    //                    {

    //                        netTotal = dt.Rows[0]["SALES_NET_TOTAL"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);

    //                        netTotal = strNetAmountDebitComma;

    //                    }
    //                    objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());

    //                    if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
    //                    {
    //                        clsBusinessLayer ObjBusiness = new clsBusinessLayer();
    //                        strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, dt.Rows[0]["SALES_NET_TOTAL"].ToString());
    //                    }
    //                }
    //                else
    //                {
    //                    strCrncyAbbrv = dt.Rows[0]["DEFULT_ABRVTN"].ToString();

    //                    if (dt.Rows[0]["SALES_GROSS_TOTAL"].ToString() != "")
    //                    {
    //                        grossTotal = dt.Rows[0]["SALES_GROSS_TOTAL"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);

    //                        grossTotal = strNetAmountDebitComma;



    //                    }
    //                    if (dt.Rows[0]["SALES_TAX_TOTAL"].ToString() != "")
    //                    {
    //                        taxTotal = dt.Rows[0]["SALES_TAX_TOTAL"].ToString();

    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);

    //                        taxTotal = strNetAmountDebitComma;

    //                    }
    //                    if (dt.Rows[0]["SALES_DISCOUNT"].ToString() != "")
    //                    {
    //                        discTotal = dt.Rows[0]["SALES_DISCOUNT"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);
    //                        discTotal = strNetAmountDebitComma;


    //                    }
    //                    if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
    //                    {
    //                        netTotal = dt.Rows[0]["SALES_NET_TOTAL"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);
    //                        netTotal = strNetAmountDebitComma;

    //                    }
    //                    objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["DEFULT_CRNCMST_ID"].ToString());

    //                    if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
    //                    {
    //                        clsBusinessLayer ObjBusiness = new clsBusinessLayer();
    //                        strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, dt.Rows[0]["SALES_NET_TOTAL"].ToString());
    //                    }
    //                }



    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //                var FontRed = new BaseColor(202, 3, 20);
    //                var FontGreen = new BaseColor(46, 179, 51);
    //                var FontGray = new BaseColor(138, 138, 138);
    //                var FontColour = new BaseColor(134, 152, 160);
    //                var FontWhite = new BaseColor(255, 255, 255);

    //                if (TaxEnable == 1)
    //                {
    //                    PdfPTable table2 = new PdfPTable(8);
    //                    float[] tableBody2 = { 4, 24, 8, 12, 10, 9, 15, 18 };
    //                    table2.SetWidths(tableBody2);
    //                    table2.WidthPercentage = 100;
    //                    table2.AddCell(new PdfPCell(new Phrase("SL#", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    table2.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    table2.AddCell(new PdfPCell(new Phrase("DISC", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    //table2.AddCell(new PdfPCell(new Phrase("TAX", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    table2.AddCell(new PdfPCell(new Phrase("TAX", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    table2.AddCell(new PdfPCell(new Phrase("TOTAL" + " (" + strCrncyAbbrv + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });

    //                    for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
    //                    {
    //                        string ProductPrice = "";
    //                        string ProductDisAmt = "";
    //                        string ProductTaxAmt = "";
    //                        string ProductTtlAmt = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString() != "")
    //                        {
    //                            ProductPrice = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
    //                            ProductPrice = strNetAmountDebitComma;

    //                        }
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString() != "")
    //                        {
    //                            ProductDisAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
    //                            ProductDisAmt = strNetAmountDebitComma;

    //                        }

    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_TAX_AMT"].ToString() != "")
    //                        {
    //                            ProductTaxAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_TAX_AMT"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTaxAmt, objEntityCommon);
    //                            ProductTaxAmt = strNetAmountDebitComma;

    //                        }
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString() != "" && dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString() != null)
    //                        {
    //                            ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
    //                            ProductTtlAmt = strNetAmountDebitComma;

    //                        }
    //                        string strRemark = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_REMARK"].ToString() != "")
    //                        {
    //                            strRemark = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_REMARK"].ToString();

    //                        }
    //                        int SlNo = intRowBodyCount + 1;
    //                        table2.AddCell(new PdfPCell(new Phrase(SlNo.ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_QTY"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        //table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["TAX_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductTaxAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(strRemark, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    table2.AddCell(new PdfPCell(new Phrase("Total  ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7, BorderColorTop = FontGray, BorderColorLeft = FontGray, BorderColorRight = FontGray, BorderColorBottom = FontGray, });
    //                    table2.AddCell(new PdfPCell(new Phrase(grossTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("Discount  ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7, BorderColorTop = FontGray, BorderColorLeft = FontGray, BorderColorRight = FontGray, BorderColorBottom = FontGray, });
    //                    table2.AddCell(new PdfPCell(new Phrase(discTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("Tax  ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7, BorderColorTop = FontGray, BorderColorLeft = FontGray, BorderColorRight = FontGray, BorderColorBottom = FontGray, });
    //                    table2.AddCell(new PdfPCell(new Phrase(taxTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                    table2.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, Colspan = 7, });
    //                    table2.AddCell(new PdfPCell(new Phrase(netTotal, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });

    //                    document.Add(table2);

    //                }
    //                else
    //                {
    //                    PdfPTable table2 = new PdfPTable(7);
    //                    float[] tableBody2 = { 4, 30, 8, 12, 12, 14, 20 };
    //                    table2.SetWidths(tableBody2);
    //                    table2.WidthPercentage = 100;
    //                    table2.AddCell(new PdfPCell(new Phrase("SL#", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    table2.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    table2.AddCell(new PdfPCell(new Phrase("DISC", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    table2.AddCell(new PdfPCell(new Phrase("TOTAL" + " (" + strCrncyAbbrv + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });

    //                    for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
    //                    {

    //                        string ProductPrice = "";
    //                        string ProductDisAmt = "";

    //                        string ProductTtlAmt = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString() != "")
    //                        {
    //                            ProductPrice = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
    //                            ProductPrice = strNetAmountDebitComma;

    //                        }
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString() != "")
    //                        {
    //                            ProductDisAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
    //                            ProductDisAmt = strNetAmountDebitComma;

    //                        }

    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString() != "")
    //                        {
    //                            ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
    //                            ProductTtlAmt = strNetAmountDebitComma;

    //                        }
    //                        string strRemark = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_REMARK"].ToString() != "")
    //                        {
    //                            strRemark = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_REMARK"].ToString();

    //                        }
    //                        int slNo = intRowBodyCount + 1;
    //                        table2.AddCell(new PdfPCell(new Phrase(slNo.ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_QTY"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(strRemark, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    table2.AddCell(new PdfPCell(new Phrase("Total  ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6, BorderColorTop = FontGray, BorderColorLeft = FontGray, BorderColorRight = FontGray, BorderColorBottom = FontGray, });
    //                    table2.AddCell(new PdfPCell(new Phrase(grossTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("Discount  ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6, BorderColorTop = FontGray, BorderColorLeft = FontGray, BorderColorRight = FontGray, BorderColorBottom = FontGray, });
    //                    table2.AddCell(new PdfPCell(new Phrase(discTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


    //                    table2.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, Colspan = 6, });
    //                    table2.AddCell(new PdfPCell(new Phrase(netTotal, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });


    //                    document.Add(table2);
    //                }

    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //                if (Version_flg == 2)
    //                {

    //                    PdfPTable footrtables = new PdfPTable(2);
    //                    float[] footrsBodys = { 30, 70 };
    //                    footrtables.SetWidths(footrsBodys);
    //                    footrtables.WidthPercentage = 100;




    //                    footrtables.AddCell(new PdfPCell(new Phrase("Sale Order No.", FontFactory.GetFont("Arial", 9, Font.NORMAL))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["SALES_ORDERNO"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtables.AddCell(new PdfPCell(new Phrase("Reference No.", FontFactory.GetFont("Arial", 9, Font.NORMAL))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["SALES_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    document.Add(footrtables);


    //                    if (dt.Rows[0]["SALES_DESC"].ToString().Trim() != "")
    //                    {
    //                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                        document.Add(new Paragraph(new Chunk("Remarks", FontFactory.GetFont("Arial", 9, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //                        document.Add(new Paragraph(new Chunk(dt.Rows[0]["SALES_DESC"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //                    }
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));


    //                    var phrase2 = new Phrase();
    //                    var phrase5 = new Phrase();

    //                    if (dtBankDtls.Rows.Count > 0)
    //                    {
    //                        phrase2.Add(new Chunk("Make all cheques payable to ", FontFactory.GetFont("Arial", 9, BaseColor.BLACK)));

    //                        if (dtCorp.Rows.Count > 0)
    //                        {
    //                            if (dtCorp.Rows[0][0].ToString() != "")
    //                            {
    //                                phrase2.Add(new Chunk(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)));

    //                                phrase5.Add(new Chunk(" Bank Details for ", FontFactory.GetFont("Arial", 9, Font.UNDERLINE)));
    //                                phrase5.Add(new Chunk(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD | Font.UNDERLINE)));
    //                                phrase5.Add(new Chunk("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)));

    //                            }
    //                        }


    //                        document.Add(new Paragraph(phrase2) { Alignment = Element.ALIGN_CENTER });
    //                        document.Add(new Paragraph(phrase5) { Alignment = Element.ALIGN_CENTER, });

    //                        var phrase4 = new Phrase();
    //                        var phrase6 = new Phrase();
    //                        var phrase7 = new Phrase();
    //                        var phrase9 = new Phrase();


    //                        if (dtBankDtls.Rows[0]["BANK_I_BAN_NO"].ToString().Trim() != "")
    //                        {
    //                            phrase6.Add(new Chunk(" IBAN ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)));
    //                            phrase6.Add(new Chunk(dtBankDtls.Rows[0]["BANK_I_BAN_NO"].ToString(), FontFactory.GetFont("Arial", 9, BaseColor.BLACK)));

    //                        }
    //                        if (dtBankDtls.Rows[0]["BANK_ACC_NO"].ToString().Trim() != "")
    //                        {
    //                            phrase7.Add(new Chunk(" A/C No. ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)));
    //                            phrase7.Add(new Chunk(dtBankDtls.Rows[0]["BANK_ACC_NO"].ToString(), FontFactory.GetFont("Arial", 9, BaseColor.BLACK)));
    //                        }
    //                        if (dtBankDtls.Rows[0]["BANK_NAME"].ToString().Trim() != "")
    //                        {
    //                            phrase7.Add(new Chunk(" Bank ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)));
    //                            phrase7.Add(new Chunk(dtBankDtls.Rows[0]["BANK_NAME"].ToString(), FontFactory.GetFont("Arial", 9, BaseColor.BLACK)));
    //                        }
    //                        if (dtBankDtls.Rows[0]["BANK_SWIFT_CODE"].ToString().Trim() != "")
    //                        {
    //                            phrase9.Add(new Chunk(" Swift Code ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)));
    //                            phrase9.Add(new Chunk(dtBankDtls.Rows[0]["BANK_SWIFT_CODE"].ToString(), FontFactory.GetFont("Arial", 9, BaseColor.BLACK)));
    //                        }
    //                        document.Add(new Paragraph(phrase4) { Alignment = Element.ALIGN_CENTER });
    //                        document.Add(new Paragraph(phrase6) { Alignment = Element.ALIGN_CENTER });
    //                        document.Add(new Paragraph(phrase7) { Alignment = Element.ALIGN_CENTER });
    //                        document.Add(new Paragraph(phrase9) { Alignment = Element.ALIGN_CENTER });
    //                    }


    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //                    PdfPTable pdfCorprt = new PdfPTable(1);
    //                    pdfCorprt.WidthPercentage = 100;

    //                    pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    document.Add(pdfCorprt);

    //                }

    //            }

    //            string CheckedBy = "";
    //            if (dt.Rows[0]["SALES_CNFRM_STS"].ToString() == "1")
    //            {
    //                CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
    //            }

    //            PdfPTable table3 = new PdfPTable(3);
    //            float[] tableBody3 = { 33, 33, 33 };
    //            table3.SetWidths(tableBody3);
    //            table3.WidthPercentage = 100;
    //            table3.TotalWidth = 600F;

    //            table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("Checked by", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("Authorized by", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });

    //            table3.WriteSelectedRows(0, -1, 0, 80, writer.DirectContent);


    //            document.Close();
    //            strRet = strImagePath + strImageName;

    //        }

    //    }
    //    catch (Exception)
    //    {
    //        document.Close();
    //        strRet = "false";

    //    }

    //    return strRet;
    //}

    //public string PdfPrintVersion3(string strId, DataTable dt, DataTable dtProduct, DataTable dtCust, DataTable dtCorp, clsEntitySales ObjEntitySales, string PreparedBy)
    //{
    //    string strRet = "true";
    //    //clsCommonLibrary objCommon = new clsCommonLibrary();
    //    //   int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.SALE_INVOICE);
    //    //string strImageName = "Sale_Invoice" + strId + ".pdf";
    //    // string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.SALE_INVOICE);

    //    //strRet = strImagePath + strImageName;

    //    clsBusinessLayer objBusiness = new clsBusinessLayer();
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.SALE_INVOICE);
    //    string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.SALE_INVOICE);


    //    clsEntityCommon objEntityCommon = new clsEntityCommon();
    //    if (ObjEntitySales.Corporate_id != 0)
    //    {
    //        objEntityCommon.CorporateID = ObjEntitySales.Corporate_id;
    //    }
    //    if (ObjEntitySales.Organisation_id != 0)
    //    {
    //        objEntityCommon.Organisation_Id = ObjEntitySales.Organisation_id;
    //    }

    //    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
    //    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SALES_PRINT);
    //    string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
    //    string strImageName = "Sale_Invoice" + strId + "_" + strNextNumber + ".pdf";
    //    DataTable dtBankDtls = objBusinessSales.ReadBankDetails(ObjEntitySales);

    //    Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);
    //    Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
    //    try
    //    {

    //        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
    //        {
    //            System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(strImagePath));

    //            FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
    //            PdfWriter writer = PdfWriter.GetInstance(document, file);
    //            document.Open();

    //            //  string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CORPORATE_LOGOS) + "corporate-logo.jpg";
    //            string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DEFAULT_LOGO);
    //            if (dtCorp.Rows.Count > 0)
    //            {
    //                if (dtCorp.Rows[0]["CORPRT_ICON"].ToString() != "")
    //                {
    //                    string imaeposition = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
    //                    string icon = dtCorp.Rows[0]["CORPRT_ICON"].ToString();

    //                    strImageLogo = imaeposition + icon;
    //                    //objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit) + dtCorp.Rows[0]["CORPRT_ICON"].ToString();
    //                }
    //            }

    //            var FontBlue = new BaseColor(0, 174, 239);
    //            var FontBlueGrey = new BaseColor(79, 167, 206);


    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            PdfPTable footrtable = new PdfPTable(2);
    //            float[] footrsBody = { 50, 50 };
    //            footrtable.SetWidths(footrsBody);
    //            footrtable.WidthPercentage = 100;


    //            footrtable.AddCell(new PdfPCell(new Phrase("INVOICE", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, PaddingTop = 15 });
    //            footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtable.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["SALES_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });


    //            footrtable.AddCell(new PdfPCell(new Phrase("To", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, PaddingTop = 20 });

    //            footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });


    //            if (dtCust.Rows.Count > 0)
    //            {
    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //                footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            }
    //            if (dtCust.Rows.Count > 0)
    //            {
    //                if (dtCust.Rows[0][4].ToString().Trim() != "")
    //                {
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                }

    //                else
    //                {
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                }
    //            }
    //            else
    //            {
    //                footrtable.AddCell(new PdfPCell(new Phrase("                          ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase("                          ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });


    //            }
    //            document.Add(footrtable);



    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //            var FontGrey = new BaseColor(134, 152, 160);
    //            var FontBordrGrey = new BaseColor(236, 236, 236);


    //            if (dtProduct.Rows.Count > 0)
    //            {

    //                string netTotal = "", grossTotal = "", taxTotal = "", discTotal = "";
    //                string strcurrenWord = "";

    //                if (dt.Rows[0]["CRNCY_STS"].ToString() == "1")
    //                {
    //                    if (dt.Rows[0]["SALES_GROSS_TOTAL"].ToString() != "")
    //                    {

    //                        grossTotal = dt.Rows[0]["SALES_GROSS_TOTAL"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);


    //                        grossTotal = strNetAmountDebitComma + " " + dt.Rows[0]["CRNCMST_ABBRV"].ToString();
    //                    }
    //                    if (dt.Rows[0]["SALES_TAX_TOTAL"].ToString() != "")
    //                    {


    //                        taxTotal = dt.Rows[0]["SALES_TAX_TOTAL"].ToString();

    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);

    //                        taxTotal = strNetAmountDebitComma + " " + dt.Rows[0]["CRNCMST_ABBRV"].ToString();

    //                    }
    //                    if (dt.Rows[0]["SALES_DISCOUNT"].ToString() != "")
    //                    {



    //                        discTotal = dt.Rows[0]["SALES_DISCOUNT"].ToString();

    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);

    //                        discTotal = strNetAmountDebitComma + " " + dt.Rows[0]["CRNCMST_ABBRV"].ToString();

    //                    }
    //                    if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
    //                    {

    //                        netTotal = dt.Rows[0]["SALES_NET_TOTAL"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);

    //                        netTotal = strNetAmountDebitComma + " " + dt.Rows[0]["CRNCMST_ABBRV"].ToString();

    //                    }
    //                    objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());

    //                    if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
    //                    {
    //                        clsBusinessLayer ObjBusiness = new clsBusinessLayer();
    //                        strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, dt.Rows[0]["SALES_NET_TOTAL"].ToString());
    //                    }
    //                }
    //                else
    //                {
    //                    if (dt.Rows[0]["SALES_GROSS_TOTAL"].ToString() != "")
    //                    {
    //                        grossTotal = dt.Rows[0]["SALES_GROSS_TOTAL"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);

    //                        grossTotal = strNetAmountDebitComma + " " + dt.Rows[0]["DEFULT_ABRVTN"].ToString();



    //                    }
    //                    if (dt.Rows[0]["SALES_TAX_TOTAL"].ToString() != "")
    //                    {
    //                        taxTotal = dt.Rows[0]["SALES_TAX_TOTAL"].ToString();

    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);

    //                        taxTotal = strNetAmountDebitComma + " " + dt.Rows[0]["DEFULT_ABRVTN"].ToString();

    //                    }
    //                    if (dt.Rows[0]["SALES_DISCOUNT"].ToString() != "")
    //                    {
    //                        discTotal = dt.Rows[0]["SALES_DISCOUNT"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);
    //                        discTotal = strNetAmountDebitComma + " " + dt.Rows[0]["DEFULT_ABRVTN"].ToString();


    //                    }
    //                    if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
    //                    {
    //                        netTotal = dt.Rows[0]["SALES_NET_TOTAL"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);
    //                        netTotal = strNetAmountDebitComma + " " + dt.Rows[0]["DEFULT_ABRVTN"].ToString();

    //                    }
    //                    objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["DEFULT_CRNCMST_ID"].ToString());

    //                    if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
    //                    {
    //                        clsBusinessLayer ObjBusiness = new clsBusinessLayer();
    //                        strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, dt.Rows[0]["SALES_NET_TOTAL"].ToString());
    //                    }
    //                }



    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //                var FontRed = new BaseColor(202, 3, 20);
    //                var FontGreen = new BaseColor(46, 179, 51);
    //                var FontGray = new BaseColor(138, 138, 138);


    //                if (TaxEnable == 1)
    //                {


    //                    PdfPTable table2 = new PdfPTable(9);
    //                    float[] tableBody2 = { 4, 20, 15, 12, 10, 10, 7, 10, 12 };
    //                    table2.SetWidths(tableBody2);
    //                    table2.WidthPercentage = 100;
    //                    table2.AddCell(new PdfPCell(new Phrase("SR.", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("DIS. AMOUNT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("TAX", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("TAX AMOUNT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });

    //                    for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
    //                    {
    //                        string ProductPrice = "";
    //                        string ProductDisAmt = "";
    //                        string ProductTaxAmt = "";
    //                        string ProductTtlAmt = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString() != "")
    //                        {
    //                            ProductPrice = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
    //                            ProductPrice = strNetAmountDebitComma;

    //                        }
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString() != "")
    //                        {
    //                            ProductDisAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
    //                            ProductDisAmt = strNetAmountDebitComma;

    //                        }

    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_TAX_AMT"].ToString() != "")
    //                        {
    //                            ProductTaxAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_TAX_AMT"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTaxAmt, objEntityCommon);
    //                            ProductTaxAmt = strNetAmountDebitComma;

    //                        }
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString() != "" && dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString() != null)
    //                        {
    //                            ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
    //                            ProductTtlAmt = strNetAmountDebitComma;

    //                        }
    //                        string strRemark = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_REMARK"].ToString() != "")
    //                        {
    //                            strRemark = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_REMARK"].ToString();

    //                        }
    //                        int SlNo = intRowBodyCount + 1;
    //                        table2.AddCell(new PdfPCell(new Phrase(SlNo.ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(strRemark, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["TAX_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductTaxAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_QTY"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    table2.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 8, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase(grossTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("Discount", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 8, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase(discTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("Tax", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 8, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase(taxTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    //   table2.AddCell(new PdfPCell(new Phrase("Net Total", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2, BorderColor = FontGray });
    //                    //    table2.AddCell(new PdfPCell(new Phrase(netTotal, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    //table2.AddCell(new PdfPCell(new Phrase("Net Total (In words)", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });
    //                    //table2.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });



    //                    //table2.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontBlue });



    //                    document.Add(table2);

    //                }
    //                else
    //                {
    //                    PdfPTable table2 = new PdfPTable(7);
    //                    float[] tableBody2 = { 4, 32, 16, 12, 12, 12, 12 };
    //                    table2.SetWidths(tableBody2);
    //                    table2.WidthPercentage = 100;
    //                    table2.AddCell(new PdfPCell(new Phrase("SR.", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("DIS. AMOUNT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });

    //                    for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
    //                    {

    //                        string ProductPrice = "";
    //                        string ProductDisAmt = "";

    //                        string ProductTtlAmt = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString() != "")
    //                        {
    //                            ProductPrice = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
    //                            ProductPrice = strNetAmountDebitComma;

    //                        }
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString() != "")
    //                        {
    //                            ProductDisAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
    //                            ProductDisAmt = strNetAmountDebitComma;

    //                        }

    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString() != "")
    //                        {
    //                            ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
    //                            ProductTtlAmt = strNetAmountDebitComma;

    //                        }
    //                        string strRemark = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_REMARK"].ToString() != "")
    //                        {
    //                            strRemark = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_REMARK"].ToString();

    //                        }
    //                        int SlNo = intRowBodyCount + 1;
    //                        table2.AddCell(new PdfPCell(new Phrase(SlNo.ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(strRemark, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_QTY"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    table2.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase(grossTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("Discount", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase(discTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("Tax", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase(taxTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    document.Add(table2);
    //                }

    //                //   document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));


    //                //PdfPTable tablettl = new PdfPTable(2);
    //                //float[] tablettlBody = { 88, 12 };
    //                //tablettl.SetWidths(tablettlBody);
    //                //tablettl.WidthPercentage = 100;

    //                ////  tablettl.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                //tablettl.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray });
    //                //tablettl.AddCell(new PdfPCell(new Phrase(netTotal, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });
    //                //document.Add(tablettl);

    //                //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //                //PdfPTable footrtables = new PdfPTable(2);
    //                //float[] footrsBodys = { 30, 70 };
    //                //footrtables.SetWidths(footrsBodys);
    //                //footrtables.WidthPercentage = 100;




    //                //footrtables.AddCell(new PdfPCell(new Phrase("Sale Order No.", FontFactory.GetFont("Arial", 9, Font.NORMAL))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                //footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["SALES_ORDERNO"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                //footrtables.AddCell(new PdfPCell(new Phrase("Proforma INV Reference No.", FontFactory.GetFont("Arial", 9, Font.NORMAL))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                //footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["SALES_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                //document.Add(footrtables);
    //            }


    //            //if (dt.Rows[0]["SALES_DESC"].ToString().Trim() != "")
    //            //{
    //            //    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //    document.Add(new Paragraph(new Chunk("Remarks", FontFactory.GetFont("Arial", 9, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //            //    document.Add(new Paragraph(new Chunk(dt.Rows[0]["SALES_DESC"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //            //}
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //var phrase2 = new Phrase();
    //            //if (dtBankDtls.Rows.Count > 0)
    //            //{
    //            //    phrase2.Add(new Chunk("Make all checks payable to ", FontFactory.GetFont("Arial", 9, BaseColor.BLACK)));

    //            //    if (dtCorp.Rows.Count > 0)
    //            //    {
    //            //        if (dtCorp.Rows[0][0].ToString() != "")
    //            //        {
    //            //            phrase2.Add(new Chunk(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)));
    //            //            phrase2.Add(new Chunk(" or Bank Details for ", FontFactory.GetFont("Arial", 9, BaseColor.BLACK)));
    //            //            phrase2.Add(new Chunk(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)));
    //            //        }
    //            //    }
    //            //    document.Add(new Paragraph(phrase2) { Alignment = Element.ALIGN_CENTER });

    //            //    var phrase4 = new Phrase();

    //            //    if (dtBankDtls.Rows[0]["BANK_I_BAN_NO"].ToString().Trim() != "")
    //            //    {
    //            //        phrase4.Add(new Chunk(" IBAN ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)));
    //            //        phrase4.Add(new Chunk(dtBankDtls.Rows[0]["BANK_I_BAN_NO"].ToString(), FontFactory.GetFont("Arial", 9, BaseColor.BLACK)));

    //            //    }
    //            //    if (dtBankDtls.Rows[0]["BANK_ACC_NO"].ToString().Trim() != "")
    //            //    {
    //            //        phrase4.Add(new Chunk(" A/C No. ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)));
    //            //        phrase4.Add(new Chunk(dtBankDtls.Rows[0]["BANK_ACC_NO"].ToString(), FontFactory.GetFont("Arial", 9, BaseColor.BLACK)));
    //            //    }
    //            //    if (dtBankDtls.Rows[0]["BANK_NAME"].ToString().Trim() != "")
    //            //    {
    //            //        phrase4.Add(new Chunk(" Bank ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)));
    //            //        phrase4.Add(new Chunk(dtBankDtls.Rows[0]["BANK_NAME"].ToString(), FontFactory.GetFont("Arial", 9, BaseColor.BLACK)));
    //            //    }
    //            //    if (dtBankDtls.Rows[0]["BANK_SWIFT_CODE"].ToString().Trim() != "")
    //            //    {
    //            //        phrase4.Add(new Chunk(" Swift Code ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)));
    //            //        phrase4.Add(new Chunk(dtBankDtls.Rows[0]["BANK_SWIFT_CODE"].ToString(), FontFactory.GetFont("Arial", 9, BaseColor.BLACK)));
    //            //    }
    //            //    document.Add(new Paragraph(phrase4) { Alignment = Element.ALIGN_CENTER });

    //            //}

    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk("Accounting Department ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { PaddingTop = 25 });
    //            //document.Add(new Paragraph(new Chunk(".......................................", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));



    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //            //PdfPTable pdfCorprt = new PdfPTable(2);
    //            //float[] CorprtBody = { 100, 0 };
    //            //pdfCorprt.SetWidths(CorprtBody);
    //            //pdfCorprt.WidthPercentage = 100;

    //            //pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //document.Add(pdfCorprt);

    //            document.Close();
    //            strRet = strImagePath + strImageName;

    //        }
    //    }
    //    catch (Exception)
    //    {
    //        document.Close();
    //        strRet = "false";

    //    }

    //    return strRet;
    //}


    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string ReopenReceiptDetails(string strUserID, string strPayemntId, string strOrgIdID, string strCorpID, string strAuditPrvsn, string strAcntPrvsn)
    {
        clsEntitySales ObjEntityRequest = new clsEntitySales();
        //  clsBusiness_PaymentAccount objBussiness = new clsBusiness_PaymentAccount();
        List<clsEntityPaymentAccount> objEntityLedger = new List<clsEntityPaymentAccount>();
        List<clsEntityPaymentAccount> objEntityLedgerCostCenter = new List<clsEntityPaymentAccount>();
        clsBusinessSales objBussiness = new clsBusinessSales();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successReopen";
        string NewRev = "";

        string strRandomMixedId = strPayemntId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        ObjEntityRequest.SalesId = Convert.ToInt32(strId);
        ObjEntityRequest.Organisation_id = Convert.ToInt32(strOrgIdID);
        ObjEntityRequest.Corporate_id = Convert.ToInt32(strCorpID);
        ObjEntityRequest.User_Id = Convert.ToInt32(strUserID);
        try
        {
            DataTable dt = objBussiness.ReadSalesDetailsById(ObjEntityRequest);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["CSTMR_ID"].ToString() != null)
                {
                    ObjEntityRequest.LedgerId = Convert.ToInt32(dt.Rows[0]["CSTMR_ID"].ToString());
                }
            }
            ObjEntityRequest.NetTotal = Convert.ToDecimal(dt.Rows[0]["SALES_NET_TOTAL"].ToString());



            string strdate = "";
            DataTable dtCHK = objBussiness.SaleCancelChk(ObjEntityRequest);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["SALES_DATE"].ToString() != "")
                {
                    strdate = dt.Rows[0]["SALES_DATE"].ToString();


                    int AuditCloseSts = AuditCloseCheck(strdate, strOrgIdID, strCorpID);
                    int AcntCloseSts = AccountCloseCheck(strdate, strOrgIdID, strCorpID);

                    if (dt.Rows[0]["SALES_REOPEN_USRID"].ToString() != "" && dt.Rows[0]["SALES_CNFRM_STS"].ToString() == "0")
                    {
                        strRets = "alrdyreopend";
                    }
                    else
                    {
                        if ((AuditCloseSts == 1 && AcntCloseSts == 1) || (AuditCloseSts == 1 && AcntCloseSts != 1))
                        {
                            if (strAuditPrvsn == "1")
                            {
                                if (dtCHK.Rows.Count > 0)
                                {
                                    if (dtCHK.Rows[0][0].ToString() != "")
                                    {
                                        strRets = "alrdydeleted";
                                    }
                                }
                                else
                                {
                                    objBussiness.ReopenSales(ObjEntityRequest);
                                }
                            }
                            else
                            {
                                strRets = "Auditclosed";
                            }
                        }
                        else if (AuditCloseSts != 1 && AcntCloseSts == 1)
                        {
                            if (strAcntPrvsn == "Active")
                            {
                                if (dtCHK.Rows.Count > 0)
                                {
                                    if (dtCHK.Rows[0][0].ToString() != "")
                                    {
                                        strRets = "alrdydeleted";
                                    }
                                }
                                else
                                {
                                    objBussiness.ReopenSales(ObjEntityRequest);
                                }
                            }
                            else
                            {
                                strRets = "acntclosed";
                            }
                        }
                        else
                        {
                            if (dtCHK.Rows.Count > 0)
                            {
                                if (dtCHK.Rows[0][0].ToString() != "")
                                {
                                    strRets = "alrdydeleted";
                                }
                            }
                            else
                            {
                                objBussiness.ReopenSales(ObjEntityRequest);
                            }
                        }
                    }

                }
            }
        }
        catch
        {
            strRets = "failed";
        }

        return strRets;
    }

    public string PrintCaption(clsEntitySales ObjEntityRequest)
    {
        clsBusinessLayerReports objBusinessLayerReports = new clsBusinessLayerReports();
        clsEntityReports objEntityReports = new clsEntityReports();
        objEntityReports.Corporate_Id = ObjEntityRequest.Corporate_id;
        objEntityReports.Organisation_Id = ObjEntityRequest.Organisation_id;
        //    objEntityReports.User_Id = ObjEntityRequest.User_Id;
        DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(objEntityReports);
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "SALES";
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


    public static int AccountCloseCheck(string strDate, string strOrgIdID, string strcorpId)
    {
        int sts = 0;
        clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
        clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
        if (strcorpId != "")
        {
            objEntityAccnt.Corporate_id = Convert.ToInt32(strcorpId);
        }

        if (strOrgIdID != "")
        {
            objEntityAccnt.Organisation_id = Convert.ToInt32(strOrgIdID);
        }

        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityAccnt.FromDate = objCommon.textToDateTime(strDate);
        DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
        if (dtAccntCls.Rows.Count > 0)
        {
            sts = 1;
        }
        return sts;
    }

    public static int AuditCloseCheck(string strDate, string strOrgIdID, string strcorpId)
    {

        int sts = 0;
        cls_Business_Audit_Closeing objEmpAccntCls = new cls_Business_Audit_Closeing();
        clsEntityLayerAuditClosing objEntityAccnt = new clsEntityLayerAuditClosing();
        if (strcorpId != "")
        {
            objEntityAccnt.Corporate_id = Convert.ToInt32(strcorpId);
        }

        if (strOrgIdID != "")
        {
            objEntityAccnt.Organisation_id = Convert.ToInt32(strOrgIdID);
        }
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityAccnt.FromDate = objCommon.textToDateTime(strDate);
        DataTable dtAccntCls = objEmpAccntCls.CheckAuditClosingDate(objEntityAccnt);
        if (dtAccntCls.Rows.Count > 0)
        {
            sts = 1;
        }
        return sts;
    }


    [WebMethod]
    public static string PrintList(string orgID, string corptID, string EnableEdit, string EnableDelete, string AuditPrvision, string FinancialStartDate, string FinancialEndDate, string reOpenSts, string acntClsDate, string EnableAudit, string CurrencyID, string EnableConfirm, string Status, string SalesStatus, string customer, string from, string toDt, string CnclSts, string customerName, string PageMaxSize, string PageNumber, string strCommonSearchTerm, string OrderColumn, string OrderMethod, string strInputColumnSearch)
    {
        string strReturn = "";
        string Org_Id = orgID;
        string Corpt_Id = corptID;
        string Customer = customer;
        string fromdt = from;
        string todt = toDt;
        string AcntClsDate = acntClsDate;
        string startDate = FinancialStartDate;
        string EndDate = FinancialEndDate;
        string AuditSts = AuditPrvision;
        string ReOpen = reOpenSts;
        string SalesSts = SalesStatus;
        string CurrencyId = CurrencyID;

        //0039
        string PageMxSize = PageMaxSize;
        string PageNmbr = PageNumber;

        //end
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsBusinessSales objBusinessSales = new clsBusinessSales();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntitySales objEntity = new clsEntitySales();
        if (CurrencyId != "")
        objEntityCommon.CurrencyId = Convert.ToInt32(CurrencyId);
        objEntity.Organisation_id = Convert.ToInt32(Org_Id);
        objEntity.Corporate_id = Convert.ToInt32(Corpt_Id);
        objEntity.Status = Convert.ToInt32(Status);
        objEntity.SalesSts = Convert.ToInt32(SalesSts);
        objEntity.cnclStatus = Convert.ToInt32(CnclSts);

        //0039
        objEntity.PageMaxSize = Convert.ToInt32(PageMxSize);
        objEntity.PageNumber = Convert.ToInt32(PageNmbr);

        objEntity.OrderMethod = Convert.ToInt32(OrderMethod);
        objEntity.OrderColumn = Convert.ToInt32(OrderColumn);
        objEntity.CommonSearchTerm = strCommonSearchTerm;

        var values = Enum.GetValues(typeof(SearchInputColumns));
        int intSearchColumnCount = values.Length;

        string[] strSearchInputs = new string[intSearchColumnCount];
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
        //end

        if (Customer != "--SELECT CUSTOMER--")
        {
            objEntity.LedgerId = Convert.ToInt32(Customer);
        }
        if (fromdt != "")
        {
            objEntity.FromPeriod = objCommon.textToDateTime(fromdt);
        }
        if (todt != "")
        {
            objEntity.ToPeriod = objCommon.textToDateTime(todt);
        }
        if (startDate != "")
        {
            objEntity.StartDate = objCommon.textToDateTime(startDate);
        }
        if (EndDate != "")
        {
            objEntity.EndDate = objCommon.textToDateTime(EndDate);
        }
      
    
      


        DataTable dtCategory = objBusinessSales.ReadSalesDetailsList(objEntity);

        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.TRANSACTION_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SALES_PDF);
        objEntityCommon.CorporateID = objEntity.Corporate_id;
        objEntityCommon.Organisation_Id = objEntity.Organisation_id;
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "SalesList_" + strNextNumber + ".pdf";

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

                footrtable.AddCell(new PdfPCell(new Phrase("FROM DATE     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(from, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase("TO DATE     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(toDt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (customerName != "")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("CUSTOMER  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(customerName, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
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
                footrtable.AddCell(new PdfPCell(new Phrase("SALES STATUS  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (SalesStatus == "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Pending", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else if (SalesStatus == "1")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Confirmed", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else if (SalesStatus == "2")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Reopened", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else if (SalesStatus == "3")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("All", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                document.Add(footrtable);

                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(5);
                float[] footrsBody = { 20, 11, 38, 20, 13 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("REFERENCE NUMBER", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("DATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("CUSTOMER", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("NET AMOUNT ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("STATUS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                int intCount = 0;
                string strRandom = objCommon.Random_Number();
                decimal Total = 0;

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
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["SALES_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["SALES_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        string CustmrName = "";
                        if (dtCategory.Rows[intRowBodyCount]["SALES_CUST_TYP"].ToString() == "0")
                        {
                            CustmrName = dtCategory.Rows[intRowBodyCount]["LDGR_NAME"].ToString();
                        }
                        else
                        {
                            CustmrName = dtCategory.Rows[intRowBodyCount]["SALES_CUST_NAME"].ToString();
                        }
                        TBCustomer.AddCell(new PdfPCell(new Phrase(CustmrName, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        string NetAmountWithCommaFrm = "";
                        string totalAmnt = "";
                        if (dtCategory.Rows[intRowBodyCount]["SALES_NET_TOTAL"].ToString() != "")
                        {
                            totalAmnt = dtCategory.Rows[intRowBodyCount]["SALES_NET_TOTAL"].ToString();
                        }
                        Total = Total + Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["SALES_NET_TOTAL"].ToString());
                        NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(totalAmnt.ToString(), objEntityCommon);
                        TBCustomer.AddCell(new PdfPCell(new Phrase(NetAmountWithCommaFrm, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        string strStatusImg = "";
                        if (dtCategory.Rows[intRowBodyCount]["SALES_CNFRM_STS"].ToString() == "1")
                        {
                            strStatusImg = "CONFIRMED";
                        }
                        else
                        {
                            if (dtCategory.Rows[intRowBodyCount]["SALES_REOPEN_USRID"].ToString() != "")
                            {
                                strStatusImg = "REOPENED";
                            }
                            else
                            {
                                strStatusImg = "PENDING";
                            }
                        }
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strStatusImg, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }
                    if (dtCategory.Rows.Count > 0)
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(Total.ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    }
                }
                else
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase(" No data available in table", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 5 });
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
    [WebMethod]                         
    public static string PrintCSV(string orgID, string corptID, string EnableEdit, string EnableDelete, string AuditPrvision, string FinancialStartDate, string FinancialEndDate, string reOpenSts, string acntClsDate, string EnableAudit, string CurrencyID, string EnableConfirm, string Status, string SalesStatus, string customer, string from, string toDt, string CnclSts, string customerName, string PageMaxSize, string PageNumber, string strCommonSearchTerm, string OrderColumn, string OrderMethod, string strInputColumnSearch)
    {
        string strReturn = "";
        string Org_Id = orgID;
        string Corpt_Id = corptID;
        string Customer = customer;
        string fromdt = from;
        string todt = toDt;
        string AcntClsDate = acntClsDate;
        string startDate = FinancialStartDate;
        string EndDate = FinancialEndDate;
        string AuditSts = AuditPrvision;
        string ReOpen = reOpenSts;
        string SalesSts = SalesStatus;
        string CurrencyId = CurrencyID;

        //0039
        string PageMxSize = PageMaxSize;
        string PageNmbr = PageNumber;

        //end
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsBusinessSales objBusinessSales = new clsBusinessSales();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntitySales objEntity = new clsEntitySales();
        FMS_FMS_Master_fms_Sales_Master_fms_Sales_Master_List OBJ = new FMS_FMS_Master_fms_Sales_Master_fms_Sales_Master_List();
        if (CurrencyId != "")
            objEntityCommon.CurrencyId = Convert.ToInt32(CurrencyId);
        objEntity.Organisation_id = Convert.ToInt32(Org_Id);
        objEntity.Corporate_id = Convert.ToInt32(Corpt_Id);
        objEntity.Status = Convert.ToInt32(Status);
        objEntity.SalesSts = Convert.ToInt32(SalesSts);
        objEntity.cnclStatus = Convert.ToInt32(CnclSts);
        //0039
        objEntity.PageMaxSize = Convert.ToInt32(PageMxSize);
        objEntity.PageNumber = Convert.ToInt32(PageNmbr);

        objEntity.OrderMethod = Convert.ToInt32(OrderMethod);
        objEntity.OrderColumn = Convert.ToInt32(OrderColumn);
        objEntity.CommonSearchTerm = strCommonSearchTerm;

        var values = Enum.GetValues(typeof(SearchInputColumns));
        int intSearchColumnCount = values.Length;

        string[] strSearchInputs = new string[intSearchColumnCount];
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
        //end
        if (Customer != "--SELECT CUSTOMER--")
        {
            objEntity.LedgerId = Convert.ToInt32(Customer);
        }
        if (fromdt != "")
        {
            objEntity.FromPeriod = objCommon.textToDateTime(fromdt);
        }
        if (todt != "")
        {
            objEntity.ToPeriod = objCommon.textToDateTime(todt);
        }
        if (startDate != "")
        {
            objEntity.StartDate = objCommon.textToDateTime(startDate);
        }
        if (EndDate != "")
        {
            objEntity.EndDate = objCommon.textToDateTime(EndDate);
        }
        DataTable dtCategory = objBusinessSales.ReadSalesDetailsList(objEntity);
        strReturn = OBJ.LoadTable_CSV(dtCategory, objEntity, CurrencyId, from, toDt, customerName, SalesStatus, Status);
        return strReturn;
    }
    public string LoadTable_CSV(DataTable dtCategory, clsEntitySales ObjEntityRequest, string CurrencyId, string from, string toDt, string customerName, string SalesStatus, string Status)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dt = GetTable(dtCategory, ObjEntityRequest, CurrencyId, from, toDt, customerName, SalesStatus, Status);
        string strResult = DataTableToCSV(dt, ',');
        string strImagePath = "";
        string filepath = "";
        if (ObjEntityRequest.Corporate_id != 0)
        {
            objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        }
        if (ObjEntityRequest.Organisation_id != 0)
        {
            objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        }
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SALE_CSV);
        string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
        string newFilePath = Server.MapPath("/CustomFiles/FMS CSV/Sale/SalesList_" + strNextId + ".csv");
        System.IO.File.WriteAllText(newFilePath, strResult);
        filepath = "SalesList_" + strNextId + ".csv";
        strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.SALE_CSV);
        return strImagePath + filepath;
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
    public DataTable GetTable(DataTable dtCategory, clsEntitySales ObjEntityRequest, string CurrencyId, string from, string toDt, string Suplier, string PurchaseStatus, string Status)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,                                                           
                                                      clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,    
                                                              };
        int intCorpId = 0;
        if (ObjEntityRequest.Corporate_id != 0)
        {
            intCorpId = ObjEntityRequest.Corporate_id;
        }

        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        int Decimalcount = 0;
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }

        string FORNULL = "";
        DataTable table = new DataTable();
        string strRandom = objCommon.Random_Number();
        table.Columns.Add("SALES LIST", typeof(string));
        table.Columns.Add(" ", typeof(string));
        table.Columns.Add("  ", typeof(string));
        table.Columns.Add("   ", typeof(string));
        table.Columns.Add("    ", typeof(string));

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("FROM DATE :", '"' + from + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("TO DATE :", '"' + toDt + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        if (Suplier != "")
            table.Rows.Add("CUSTOMER :", '"' + Suplier.TrimEnd(',', ' ') + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        if (Status == "1")
            table.Rows.Add("STATUS :", "Active", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        else if (Status == "0")
            table.Rows.Add("STATUS :", "Inactive", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        else
            table.Rows.Add("STATUS :", "All", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        if (PurchaseStatus == "1")
            table.Rows.Add("SALES STATUS :", "Confirmed", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        else if (PurchaseStatus == "0")
            table.Rows.Add("SALES STATUS :", "Pending", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        else if (PurchaseStatus == "2")
            table.Rows.Add("SALES STATUS :", "Reopened", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        else
            table.Rows.Add("SALES STATUS :", "All", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("REF #", "DATE", "CUSTOMER", "TOTAL AMOUNT", "STATUS");
        int intCount = 0;
        decimal Total = 0;

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

                string CustmrName = "";
                if (dtCategory.Rows[intRowBodyCount]["SALES_CUST_TYP"].ToString() == "0")
                {
                    CustmrName = dtCategory.Rows[intRowBodyCount]["LDGR_NAME"].ToString();
                }
                else
                {
                    CustmrName = dtCategory.Rows[intRowBodyCount]["SALES_CUST_NAME"].ToString();
                }
                string NetAmountWithCommaFrm = "";
                string totalAmnt = "";
                if (dtCategory.Rows[intRowBodyCount]["SALES_NET_TOTAL"].ToString() != "")
                {
                    totalAmnt = dtCategory.Rows[intRowBodyCount]["SALES_NET_TOTAL"].ToString();
                }
                Total = Total + Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["SALES_NET_TOTAL"].ToString());
                NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(totalAmnt.ToString(), objEntityCommon);
                string strStatusImg = "";
                if (dtCategory.Rows[intRowBodyCount]["SALES_CNFRM_STS"].ToString() == "1")
                {
                    strStatusImg = "CONFIRMED";
                }
                else
                {
                    if (dtCategory.Rows[intRowBodyCount]["SALES_REOPEN_USRID"].ToString() != "")
                    {
                        strStatusImg = "REOPENED";
                    }
                    else
                    {
                        strStatusImg = "PENDING";
                    }
                }
                table.Rows.Add('"' + dtCategory.Rows[intRowBodyCount]["SALES_REF"].ToString() + '"', '"' + dtCategory.Rows[intRowBodyCount]["SALES_DATE"].ToString() + '"', '"' + CustmrName + '"', '"' + NetAmountWithCommaFrm + '"', '"' + strStatusImg + '"');

            }
            if (dtCategory.Rows.Count > 0)
            {
                table.Rows.Add("TOTAL", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + objBusiness.AddCommasForNumberSeperation(Total.ToString(), objEntityCommon) + '"', '"' + FORNULL + '"');
            }
        }
        else
        {
            table.Rows.Add("No data available in table", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        return table;

        //0039
        //ReadList

        //DataTable dtCategory1 = objBusinessSales.ReadSalesDetailsList(ObjEntityRequest);

        //int intCancelStatus = Convert.ToInt32(CancelStatus);
        //int intEnableModify = Convert.ToInt32(EnableModify);
        //int intEnableCancel = Convert.ToInt32(EnableCancel);

        //string[] strTableContents = new string[2];
        //strTableContents = ConvertDatatable(dtCategory1, intCancelStatus, intEnableModify, intEnableCancel);
        //strResults[0] = strTableContents[0];
        //strResults[1] = strTableContents[1];

        //end
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
            headtable.AddCell(new PdfPCell(new Phrase("SALES LIST ", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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
    public static string SaleAmountSum(string orgID, string corptID, string EnableEdit, string EnableDelete, string AuditPrvision, string FinancialStartDate, string FinancialEndDate, string reOpenSts, string acntClsDate, string EnableAudit, string CurrencyID, string EnableConfirm, string Status, string SalesStatus, string customer, string from, string toDt, string CnclSts)
    {
        string strReturn = "";
        string Org_Id = orgID;
        string Corpt_Id = corptID;
        string Customer = customer;
        string fromdt = from;
        string todt = toDt;
        string AcntClsDate = acntClsDate;
        string startDate = FinancialStartDate;
        string EndDate = FinancialEndDate;
        string AuditSts = AuditPrvision;
        string ReOpen = reOpenSts;
        string SalesSts = SalesStatus;
        string CurrencyId = CurrencyID;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsBusinessSales objBusinessSales = new clsBusinessSales();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntitySales objEntity = new clsEntitySales();
        if (CurrencyId != "")
            objEntityCommon.CurrencyId = Convert.ToInt32(CurrencyId);
        objEntity.Organisation_id = Convert.ToInt32(Org_Id);
        objEntity.Corporate_id = Convert.ToInt32(Corpt_Id);
        objEntity.Status = Convert.ToInt32(Status);
        objEntity.SalesSts = Convert.ToInt32(SalesSts);
        objEntity.cnclStatus = Convert.ToInt32(CnclSts);
        if (Customer != "--SELECT CUSTOMER--")
        {
            objEntity.LedgerId = Convert.ToInt32(Customer);
        }
        if (fromdt != "")
        {
            objEntity.FromPeriod = objCommon.textToDateTime(fromdt);
        }
        if (todt != "")
        {
            objEntity.ToPeriod = objCommon.textToDateTime(todt);
        }
        if (startDate != "")
        {
            objEntity.StartDate = objCommon.textToDateTime(startDate);
        }
        if (EndDate != "")
        {
            objEntity.EndDate = objCommon.textToDateTime(EndDate);
        }

        StringBuilder sb = new StringBuilder();
        DataTable dtCategory = objBusinessSales.ReadSalesDetailsList_Sum(objEntity);

        string strHtml = "";
        if (dtCategory.Rows.Count > 0 && dtCategory.Rows[0]["TOTAL"].ToString() != "")
        {
            //   strHtml = dtCategory.Rows[0]["TOTAL"].ToString();
            //strHtml = "<tr>";
            strHtml += "<td class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > TOTAL</td>";
            strHtml += "<td class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </td>";
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
            strHtml += "<td class=\"tr_r bg1 txt_rd\" style=\"text-align:right !important;\" id=\"tdtotal\">" + objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[0]["TOTAL"].ToString(), objEntityCommon) + " </td>";
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
        }
        sb.Append(strHtml);
        return sb.ToString();
    }



    public static string[] ConvertDataTableToHTML(DataTable dt, string CnclSts, string intEnableModify, string intEnableCancel, string Confirm, string ReOpen, DateTime acntClsDate, int YearEndCls, string EnableAudit, string AcntPrvsn, string CurrencyID, string Org_Id, string Corpt_Id, string Sum)
    {

        //0039
        string strHtml = "";
        string[] strReturn = new string[2];

        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        objEntityCommon.CurrencyId = Convert.ToInt32(CurrencyID);

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        StringBuilder sbHead = new StringBuilder();
        StringBuilder sb = new StringBuilder();

        sbHead.Append("<th id=\"tdColumnHead_1\" onclick=\"SetOrderByValue(1)\" class=\"sorting col-md-2 tr_l\" style=\"word-wrap:break-word;\">REF#<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbHead.Append("<th id=\"tdColumnHead_2\" onclick=\"SetOrderByValue(2)\" class=\"sorting col-md-2 tr_c\" style=\"word-wrap:break-word;\">DATE<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbHead.Append("<th id=\"tdColumnHead_3\" onclick=\"SetOrderByValue(3)\" class=\"sorting col-md-2 tr_l\" style=\"word-wrap:break-word;\">CUSTOMER<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbHead.Append("<th id=\"tdColumnHead_4\" onclick=\"SetOrderByValue(4)\" class=\"sorting col-md-2 tr_r\" style=\"word-wrap:break-word;\">TOTAL AMOUNT<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        if (CnclSts != "1")
        {
            sbHead.Append("<th id=\"tdColumnHead_5\" onclick=\"SetOrderByValue(5)\" class=\"sorting col-md-2 tr_c\" style=\"word-wrap:break-word;\">STATUS</th>");
        }

        sbHead.Append("<th class=\"col-md-2\" style=\"word-wrap:break-word;\">ACTIONS</th>");

        int intCount = 0;
        foreach (DataRow dtRowsIn in dt.Rows)
        {
            string strConfirm = "";
            string strPrint = "";
            string strDelete = "";
            intCount = intCount + 1;
            string strEdit = "";
            string strCount = Convert.ToString(intCount);

            string strId = dtRowsIn[0].ToString();
            int usrId = Convert.ToInt32(strId);
            int intIdLength = dtRowsIn[0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

            string strStatus = "";
            string stsmode;
            string totalAmnt = "";
            string strStatusImg = "";
            string NetAmountWithCommaFrm = "";
            string CustmrName = "";
            stsmode = dtRowsIn["STATUS"].ToString();
            string cnclusrId = dtRowsIn["SALES_CNCL_USR_ID"].ToString();
            int Category = 0;
            string strReopen = "";
            string strRefNo = "";
            decimal DecimalTotl = 0;
            string StrTotl = "";
            // int Category =Convert.ToInt32(dtRowsIn["LDGR_ACCOUNT"].ToString());
            string confrm = "";

            cls_Business_Audit_Closeing objEmpAuditCls = new cls_Business_Audit_Closeing();
            clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();

            objEntityAudit.Organisation_id = Convert.ToInt32(Org_Id);
            objEntityAudit.Corporate_id = Convert.ToInt32(Corpt_Id);

            if (dtRowsIn["SALES_CUST_TYP"].ToString() == "0")
            {
                CustmrName = dtRowsIn["LDGR_NAME"].ToString();
            }
            else
            {
                CustmrName = dtRowsIn["SALES_CUST_NAME"].ToString();
            }

            if (dtRowsIn["SALES_NET_TOTAL"].ToString() != "")
            {
                totalAmnt = dtRowsIn["SALES_NET_TOTAL"].ToString();
                DecimalTotl = Convert.ToDecimal(dtRowsIn["SALES_NET_TOTAL"].ToString());
            }
            NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(totalAmnt.ToString(), objEntityCommon);


            confrm = dtRowsIn["SALES_CNFRM_STS"].ToString();
            objEntityAudit.FromDate = objCommon.textToDateTime(dtRowsIn["SALES_DATE"].ToString());
            DataTable dtAuditClsDate = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);

            string SettleCnt = dtRowsIn["CNT_SETTLE"].ToString();
            if (CnclSts != "1")
            {
                if (confrm == "1")
                {
                    strStatusImg = "<td  id=\"tdstatus\">CONFIRMED </td>";
                }
                else if (dtRowsIn["SALES_REOPEN_STATUS"].ToString() == "1")
                {
                    if (dtRowsIn["SALES_REOPEN_USRID"].ToString() != "")
                    {
                        strStatusImg = "<td id=\"tdstatus\" >REOPENED </td>";
                    }
                }
                else
                {
                    strStatusImg = "<td  id=\"tdstatus\">PENDING </td>";
                }
            }

            strHtml += "<tr>";
            strHtml += "<td class=\"tr_l\"  style=\"word-break: break-all; word-wrap:break-word;\" > " + dtRowsIn["SALES_REF"].ToString() + "</td>";
            strHtml += "<td class=\"tr_c\"  style=\"word-break: break-all; word-wrap:break-word;\" > " + dtRowsIn["SALES_DATE"].ToString() + "</td>";
            strHtml += "<td class=\"tr_l\"  style=\"word-break: break-all; word-wrap:break-word;\" > " + CustmrName + "</td>";
            strHtml += "<td class=\"tr_r\"  style=\"word-break: break-all; word-wrap:break-word;\"> " + NetAmountWithCommaFrm + "</td>";
            strHtml += strStatusImg;

            strHtml += "<td>";
            strHtml += "<div class=\"btn_stl1\">";

            int ID = Convert.ToInt32(dtRowsIn["SALES_REF_NEXTNUM"].ToString());

            string strView = "";
            if (CnclSts == "1")
            {
                strView = "<a class=\"btn act_btn bn4\" title=\"View\"onclick='return getdetails(this.href);' href=\"fms_Sales_Master.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";
            }
            else
            {
                if (YearEndCls == 0)
                {

                    if (confrm == "1")
                    {
                        strDelete = "<a class=\"btn act_btn bn3\" disabled=\"true\" title=\"Delete\" href=\"javascript:;\"  onclick=\"return CancelNotPossible();\"><i class=\"fa fa-trash\"></i></a>";
                        strPrint = "<a class=\"btn act_btn bn6\" title=\"Print Invoice\" href=\"javascript:;\" onclick=\"return OpenPrint('" + Id + "');\"><i class=\"fa fa-print\"></i></a>";
                        strEdit = "<a class=\"btn act_btn bn4 \" title=\"View\"onclick='return getdetails(this.href);' href=\"fms_Sales_Master.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";
                        if (ReOpen == "1")
                        {
                            if (SettleCnt == "0")
                            {
                                if (dtAuditClsDate.Rows.Count > 0)
                                {

                                    if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dtRowsIn["SALES_DATE"].ToString()))
                                    {

                                        if (EnableAudit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                                        {
                                            strReopen = "<a class=\"btn act_btn bn2 \" title=\"REOPEN\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" ></i></a>";

                                        }
                                        else
                                        {
                                            strReopen = "<a disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"REOPEN\" " + "><i class=\"fa fa-unlock\" ></i></a>";

                                        }
                                    }
                                    else
                                    {
                                        strReopen = "<a class=\"btn act_btn bn2 \" title=\"REOPEN\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" ></i></a>";

                                    }

                                }

                                else if (acntClsDate >= objCommon.textToDateTime(dtRowsIn["SALES_DATE"].ToString()))
                                {
                                    if (AcntPrvsn == "Active")
                                    {
                                        strReopen = "<a class=\"btn act_btn bn2 \" title=\"REOPEN\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" ></i></a>";
                                    }
                                    else
                                    {
                                        strReopen = "<a disabled=\"true\" class=\"btn act_btn bn2\" href=\"javascript:;\" title=\"REOPEN\" " + "><i class=\"fa fa-unlock\" ></i></a>";
                                    }
                                }
                                else
                                {
                                    strReopen = "<a class=\"btn act_btn bn2\" title=\"REOPEN\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" ></i></a>";
                                }
                            }
                            else
                            {
                                strReopen = "<a disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" onclick=\"return ReopenNotPossible();\" title=\"REOPEN\" " + "><i class=\"fa fa-unlock\" ></i></a>";
                            }
                        }
                        else
                        {
                            strReopen = "<a disabled=\"true\" class=\"btn act_btn bn2\" href=\"javascript:;\" title=\"REOPEN\" " + "><i class=\"fa fa-unlock\" ></i></a>";
                        }



                        strConfirm = "<a disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";



                    }
                    else
                    {
                        if (dtAuditClsDate.Rows.Count > 0)
                        {

                            if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dtRowsIn["SALES_DATE"].ToString()))
                            {

                                if (EnableAudit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                                {
                                    strDelete = " <a class=\"btn act_btn bn3\" title=\"Delete\" href=\"javascript:;\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>";

                                }
                                else
                                {
                                    strDelete = " <a class=\"btn act_btn bn3\"  disabled=\"true\" title=\"Delete\" href=\"javascript:;\"  onclick=\"return CancelNotPossible();\"><i disabled=\"true\" class=\"fa fa-trash\"></i></a>";

                                }
                            }
                            else
                            {
                                strDelete = "<a class=\"btn act_btn bn3\" title=\"Delete\" href=\"javascript:;\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>";

                            }

                        }

                        else if (acntClsDate >= objCommon.textToDateTime(dtRowsIn["SALES_DATE"].ToString()))
                        {
                            if (AcntPrvsn == "Active")
                            {
                                strDelete = "<a class=\"btn act_btn bn3\" title=\"Delete\" href=\"javascript:;\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>";
                            }
                            else
                            {
                                strDelete = " <a class=\"btn act_btn bn3\" disabled=\"true\" title=\"Delete\" href=\"javascript:;\"  onclick=\"return CancelNotPossible();\"><i disabled=\"true\" class=\"fa fa-trash\"></i></a>";
                            }
                        }
                        else
                        {
                            strDelete = " <a class=\"btn act_btn bn3\" title=\"Delete\" href=\"javascript:;\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>";
                        }
                        strPrint = " <a class=\"btn act_btn bn6\" title=\"Print Invoice\" href=\"javascript:;\" onclick=\"return OpenPrint('" + Id + "');\"><i class=\"fa fa-print\"></i></a>";
                        if (dtAuditClsDate.Rows.Count > 0)
                        {

                            if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dtRowsIn["SALES_DATE"].ToString()))
                            {

                                if (EnableAudit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                                {
                                    strEdit = "<a class=\"btn act_btn bn1\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"fms_Sales_Master.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";

                                }
                                else
                                {
                                    strEdit = "<a class=\"btn act_btn bn4\" title=\"View\"onclick='return getdetails(this.href);' href=\"fms_Sales_Master.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";

                                }
                            }
                            else
                            {
                                strEdit = "<a class=\"btn act_btn bn1\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"fms_Sales_Master.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";

                            }

                        }

                        else if (acntClsDate >= objCommon.textToDateTime(dtRowsIn["SALES_DATE"].ToString()))
                        {
                            if (AcntPrvsn == "Active")
                            {
                                strEdit = "<a class=\"btn act_btn bn1\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"fms_Sales_Master.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";
                            }
                            else
                            {
                                strEdit = "<a class=\"btn act_btn bn4 \" title=\"View\"onclick='return getdetails(this.href);' href=\"fms_Sales_Master.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";
                            }
                        }
                        else
                        {
                            strEdit = "<a class=\"btn act_btn bn1\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"fms_Sales_Master.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";
                        }
                        strReopen = "<a disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"REOPEN\" " + "><i class=\"fa fa-unlock\" ></i></a>";
                        if (Confirm == "1")
                        {
                            if (dtAuditClsDate.Rows.Count > 0)
                            {

                                if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dtRowsIn["SALES_DATE"].ToString()))
                                {

                                    if (EnableAudit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                                    {
                                        strConfirm = "<a class=\"btn act_btn bn2  \" title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";

                                    }
                                    else
                                    {
                                        strConfirm = "<a disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";

                                    }
                                }
                                else
                                {
                                    strConfirm = "<a class=\"btn act_btn bn2  \" title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";

                                }

                            }

                            else if (acntClsDate >= objCommon.textToDateTime(dtRowsIn["SALES_DATE"].ToString()))
                            {
                                if (AcntPrvsn == "Active")
                                {
                                    strConfirm = "<a class=\"btn act_btn bn2 \" title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";
                                }
                                else
                                {
                                    strConfirm = "<a disabled=\"true\" class=\"btn act_btn bn2  \" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";
                                }
                            }
                            else
                            {
                                strConfirm = "<a class=\"btn act_btn bn2  \" title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";
                            }



                        }
                        else
                        {
                            strConfirm = "<a disabled=\"true\" class=\"btn act_btn bn2  \" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";

                        }
                    }

                }
                else
                {
                    strConfirm = "<a disabled=\"true\" class=\"btn act_btn bn2  \" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";
                    strEdit = "<a class=\"btn act_btn bn4 \" title=\"View\"onclick='return getdetails(this.href);' href=\"fms_Sales_Master.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";
                    strDelete = " <a class=\"btn act_btn bn3\" disabled=\"true\" title=\"Delete\" href=\"javascript:;\"  onclick=\"return CancelNotPossible();\"><i disabled=\"true\" class=\"fa fa-trash\"></i></a>";
                    strReopen = "<a disabled=\"true\" class=\"btn act_btn bn2\" href=\"javascript:;\" title=\"REOPEN\" " + "><i class=\"fa fa-unlock\" ></i></a>";
                    strPrint = "<a class=\"btn act_btn bn6\" title=\"Print Invoice\" href=\"javascript:;\" onclick=\"return OpenPrint('" + Id + "');\"><i class=\"fa fa-print\"></i></a>";
                }


                if (stsmode == "INACTIVE")
                {
                    strConfirm = "<a disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";
                }
            }


            if (dtRowsIn["SALES_REF_NEXTNUM"].ToString() != "")
            {
                strRefNo = "<td =id=\"sdggfgdfg\" style=\"display:none;\">  " + dtRowsIn["SALES_REF_NEXTNUM"].ToString() + " </td>";
            }

            if (dtRowsIn["SALES_CUST_TYP"].ToString() == "0")
            {
                CustmrName = dtRowsIn["LDGR_NAME"].ToString();
            }
            else
            {
                CustmrName = dtRowsIn["SALES_CUST_NAME"].ToString();
            }
            StrTotl = "<td =id=\"sdggfgdfg\" style=\"display:none;\">  " + dtRowsIn["SALES_NET_TOTAL"].ToString() + " </td>";
            int strnn = Convert.ToInt32(dtRowsIn["SALES_REF_NEXTNUM"].ToString());

            strHtml +=  strView + strEdit + strConfirm + strReopen + strDelete + strPrint;

            strHtml += "</div>";
            strHtml += "</td>";

            strHtml += "</tr>";
        }

        if (Sum != "")
        {
            strHtml += "<td class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > TOTAL</td>";
            strHtml += "<td class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </td>";
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
            strHtml += "<td class=\"tr_r bg1 txt_rd\" style=\"text-align:right !important;\" id=\"tdtotal\">" + objBusiness.AddCommasForNumberSeperation(Sum, objEntityCommon) + " </td>";
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
            if (CnclSts != "1")
            {
                strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
            }
        }

        strReturn[0] = sbHead.ToString();
        strReturn[1] = strHtml;

        return strReturn;

        //end
    }

    [WebMethod]
    public static string[] GetData(string CorpId, string OrgId,string ddlStatus, string CancelStatus, string Customer, string From, string ToDt, string FinncialStartDate, string FinncialEndDate, string EnableModify, string EnableCancel, string ROpenSts, string AccntPrvision, string EnbleAudit, string SalsStatus, string EnbleConfirm, string CurencyID, string UserId, string PageNumber,string PageMaxSize, string strCommonSearchTerm, string OrderColumn, string OrderMethod, string strInputColumnSearch)
    {
        string[] strResults = new string[3];

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessSales objBusinessSales = new clsBusinessSales();
        clsEntitySales objEntity = new clsEntitySales();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        cls_Business_Audit_Closeing objEmpAuditCls = new cls_Business_Audit_Closeing();
        clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
        clsEntityCommon objentcommn = new clsEntityCommon();
        if (CurencyID != "")
            objEntityCommon.CurrencyId = Convert.ToInt32(CurencyID);
        objEntity.Organisation_id = Convert.ToInt32(OrgId);
        objEntity.Corporate_id = Convert.ToInt32(CorpId);
        objEntity.Status = Convert.ToInt32(ddlStatus);
        objEntity.SalesSts = Convert.ToInt32(SalsStatus);
        objEntityAudit.Organisation_id = Convert.ToInt32(OrgId);
        objEntityAudit.Corporate_id = Convert.ToInt32(CorpId);
        objEntity.cnclStatus = Convert.ToInt32(CancelStatus);
        objentcommn.Organisation_Id = Convert.ToInt32(OrgId);
        objentcommn.CorporateID = Convert.ToInt32(CorpId);
        if (Customer != "--SELECT CUSTOMER--")
        {
            objEntity.LedgerId = Convert.ToInt32(Customer);
        }
        if (From != "")
        {
            objEntity.FromPeriod = objCommon.textToDateTime(From);
        }
        if (ToDt != "")
        {
            objEntity.ToPeriod = objCommon.textToDateTime(ToDt);
        }
        if (FinncialStartDate != "")
        {
            objEntity.StartDate = objCommon.textToDateTime(FinncialStartDate);
        }
        if (FinncialEndDate != "")
        {
            objEntity.EndDate = objCommon.textToDateTime(FinncialEndDate);
        }

        DataTable dtCategory = objBusinessSales.ReadSalesDetailsList_Sum(objEntity);
        string Sum = dtCategory.Rows[0]["TOTAL"].ToString();

        DataTable dtAcntClsDate = objBusiness.ReadAccountClsDate(objentcommn);
        DateTime acntClsDate = DateTime.MinValue;

        int YearEndCls = 0;

        objEntityCommon.Organisation_Id = Convert.ToInt32(OrgId);
        objEntityCommon.CorporateID = Convert.ToInt32(CorpId);

        if (HttpContext.Current.Session["FINCYRID"] != null)
        {
            objEntityCommon.FinancialYrId = Convert.ToInt32(HttpContext.Current.Session["FINCYRID"]);
        }
        DataTable dtYearEndClsDate = objBusinessLayer.ReadYearEndCloseDate(objEntityCommon);
        if (dtYearEndClsDate.Rows.Count > 0)
        {
            YearEndCls = 1;
        }

        if (dtAcntClsDate.Rows.Count > 0)
        {
            if (dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString() != "")
            {
                acntClsDate = objCommon.textToDateTime(dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString());
            }
        }

        objEntity.PageNumber = Convert.ToInt32(PageNumber);
        objEntity.PageMaxSize = Convert.ToInt32(PageMaxSize);
        objEntity.OrderMethod = Convert.ToInt32(OrderMethod);
        objEntity.OrderColumn = Convert.ToInt32(OrderColumn);
        objEntity.CommonSearchTerm = strCommonSearchTerm;

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

        objEntity.SearchRef = strSearchInputs[Convert.ToInt32(SearchInputColumns.REF)];
        objEntity.SearchDate = strSearchInputs[Convert.ToInt32(SearchInputColumns.DATE)];
        objEntity.SearchCusto = strSearchInputs[Convert.ToInt32(SearchInputColumns.CUSTOMER)];
        objEntity.SearchAmount = strSearchInputs[Convert.ToInt32(SearchInputColumns.TOTALAMOUNT)];

        
        //ReadList

        DataTable dtList = objBusinessSales.ReadSalesDetailsList(objEntity);

        string intCancelStatus = CancelStatus;
        string intEnableModify = EnableModify;
        string intEnableCancel = EnableCancel;
        string intConfirmSts = EnbleConfirm;
        string intReopenSts = ROpenSts;
        string intAuditProvisionSts = EnbleAudit;
        string intAcntPrvsnSts = AccntPrvision;
        string intorGID = OrgId;
        string intcorPID = CorpId;
        string intCurencyID = CurencyID;

        string[] strTableContents = new string[2];
        strTableContents = ConvertDataTableToHTML(dtList, intCancelStatus, intEnableModify, intEnableCancel, intConfirmSts, intReopenSts, acntClsDate, YearEndCls, intAuditProvisionSts, intAcntPrvsnSts, intCurencyID, intorGID, intcorPID, Sum);
        strResults[0] = strTableContents[0];
        strResults[1] = strTableContents[1];


        if (dtList.Rows.Count > 0)
        {
            int intTotalItems = Convert.ToInt32(dtList.Rows[0]["CNT"].ToString());
            int intCurrentRowCount = dtList.Rows.Count;

            //Pagination
            strResults[2] = objBusinessLayer.GenereatePagination(intTotalItems, objEntity.PageNumber, objEntity.PageMaxSize, intCurrentRowCount);
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
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"REF#\" placeholder=\"Ref\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "1")
            {
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"DATE\" placeholder=\"Date\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "2")
            {
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"CUSTOMER\" placeholder=\"Customer\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "3")
            {
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"TOTAL AMOUNT\" placeholder=\"Amount\"></th>");
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
        REF = 0,
        DATE = 1,
        CUSTOMER = 2,
        TOTALAMOUNT =3,
    }

}
