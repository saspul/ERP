using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit.BusineesLayer_FMS;
using EL_Compzit.EntityLayer_FMS;
using System.Data;
using System.Web.Services;
using CL_Compzit;
using BL_Compzit;
using EL_Compzit;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text;
using System.Collections.Generic;
using System.Linq;

public partial class FMS_FMS_Master_fms_Purchase_Master_Purchase_Master_List : System.Web.UI.Page
{
    public static int TaxEnable = 0;
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
        ddlSupplier.Focus();
        if(!IsPostBack)
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityPurchaseMaster objEntityPurchase = new clsEntityPurchaseMaster();
            clsBusiness_purchaseMaster objBusinesspurchase = new clsBusiness_purchaseMaster();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objentcommn = new clsEntityCommon();
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, IntCorpId = 0, intReopen=0;
            CustomerLedgerLoad();

          //  txtTodate.Value = objBusinessLayer.LoadCurrentDate().ToString("dd-MM-yyyy");

          
            DateTime curdate = objBusinessLayer.LoadCurrentDate();
            curdate = curdate.AddDays(-30);
        //    txtFromdate.Value = curdate.ToString("dd-MM-yyyy");
           

            //   int intCorpId = 0, intOrgId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objentcommn.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityPurchase.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                IntCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objentcommn.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityPurchase.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                objEntityPurchase.UserId = Convert.ToInt32(Session["USERID"].ToString());
                intUserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = { clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                       ,     clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_TAX_ENABLED
                                                       
                                                       };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, IntCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenCancelReasonMust.Value = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                if (dtCorpDetail.Rows[0]["GN_TAX_ENABLED"].ToString() != "")
                {
                    TaxEnable = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_TAX_ENABLED"].ToString());
                }
                HiddenCurrncyId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            }

            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.PurchaseMaster);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

            HiddenReopen.Value = "0";
            HiddenConfirmStatus.Value = "0";

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
                        HiddenEnableModify.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenEnableDelete.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_ACCOUNT).ToString())
                    {
                        HiddenProvisionSts.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                       // 

                        intReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                            
                            HiddenReopen.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString())
                    {
                        HiddenFieldAuditCloseReopenSts.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        HiddenConfirmStatus.Value = "1";
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

            objEntityPurchase.FromDate = DateTime.MinValue; ;
            objEntityPurchase.ToDate = DateTime.MinValue;
            if (Session["FINCYRID"] != null)
            {
                objentcommn.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            DataTable dtfinaclYear = objBusinessLayer.ReadFinancialYearById(objentcommn);

            if (dtfinaclYear.Rows.Count > 0)
            {
                objEntityPurchase.FromDate = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString());
                objEntityPurchase.ToDate = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString());

                HiddenFinancialStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                HiddenFnancialEndDeate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();

                DataTable dtAcntClsDate = objBusinessLayer.ReadAccountClsDate(objentcommn);
                DateTime startDate = new DateTime();
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

                if (dtAcntClsDate.Rows.Count > 0)
                {
                    if (dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString() != "")
                    {
                        HiddenAccountCloseDate.Value = dtAcntClsDate.Rows[0][0].ToString();
                    }

                    if (YearEndCls == 1)
                    {
                        divAdd.Visible = false;
                    }

                    if (HiddenProvisionSts.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                    {
                        if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            divAdd.Visible = true;
                        }
                        if (intReopen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            HiddenReopen.Value = "1";
                        }
                        
                    }
                    else
                    {
                        startDate = objCommon.textToDateTime(dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString());
                        if (startDate > objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                        {
                            divAdd.Visible = false;
                        }
                        else
                        {

                        }
                    }

                    if (intReopen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        HiddenReopen.Value = "1";
                    }
                }
                else
                {
                    if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        divAdd.Visible = true;
                    }
                    if (intReopen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        HiddenReopen.Value = "1";
                    }
                }

                DateTime curntdate = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());


                if (curntdate >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curntdate <= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                {
                    txtTodate.Value = objBusinessLayer.LoadCurrentDateInString();
                    curntdate = curntdate.AddDays(-30);
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





        //                    if (curdate >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate <= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
        //    {
        //        txtTodate.Value = objBusinessLayer.LoadCurrentDateInString();
        //        curdate = curdate.AddDays(-30);
        //        if (curdate >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()))
        //        {
        //            txtFromdate.Value = curdate.ToString("dd-MM-yyyy");
        //        }
        //        else
        //        {
        //            txtFromdate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
        //        }
        //    }
        //    else
        //    {
        //        txtTodate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
        //        curdate = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString());
        //        curdate = curdate.AddDays(-30);
        //        if (curdate >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()))
        //        {
        //            txtFromdate.Value = curdate.ToString("dd-MM-yyyy");
        //        }
        //        else
        //        {
        //            txtFromdate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
        //        }
        //    }
        //}










            }


            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();

                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationaddclose", "SuccessConfirmationaddclose();", true);
                }
                if (strInsUpd == "StsCh")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessStatusChange", "SuccessStatusChange();", true);
                }
                else if (strInsUpd == "Cncl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                }
                else if (strInsUpd == "Confrm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                }
                    //0039
                else if (strInsUpd == "AlreadyConfirm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AlreadyConfirmed", "AlreadyConfirmed();", true);
                }
                    //end
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
                else if (Request.QueryString["InsUpd"] == "AuditClosed")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AuditClosed", "AuditClosed();", true);
                }
                else if (Request.QueryString["InsUpd"] == "AcntClosed")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AcntClosed", "AcntClosed();", true);
                }
                else if (strInsUpd == "ERROR")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Error", "Error();", true);
                }
            }
            divPrintCaption.InnerHtml = PrintCaption(objEntityPurchase);
        } 
    }
    public void CustomerLedgerLoad()
    {
        clsBusiness_purchaseMaster objBusinesspurchase = new clsBusiness_purchaseMaster();
        clsEntityPurchaseMaster objEntityPurchase = new clsEntityPurchaseMaster();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPurchase.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityPurchase.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtDivision = objBusinesspurchase.ReadCustomerLdger(objEntityPurchase);
        ddlSupplier.Items.Clear();
        ddlSupplier.DataSource = dtDivision;
        ddlSupplier.DataTextField = "LDGR_NAME";
        ddlSupplier.DataValueField = "LDGR_ID";
        ddlSupplier.DataBind();
        ddlSupplier.Items.Insert(0, "--SELECT SUPPLIER --");

    }
    [WebMethod]
    public static string ChangePurchaseStatus(string strmemotId, string strStatus, string UsrId)
    {
        clsBusiness_purchaseMaster objBusinesspurchase = new clsBusiness_purchaseMaster();
        clsEntityPurchaseMaster objEntityPurchase = new clsEntityPurchaseMaster();
        string strRet = "success";
        string strRandomMixedId = strmemotId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityPurchase.PurchaseId = Convert.ToInt32(strId);
        objEntityPurchase.UserId = Convert.ToInt32(UsrId);
        if (strStatus == "0")
        {
            objEntityPurchase.AccountStatus = 1;
        }
        else
        {
            objEntityPurchase.AccountStatus = 0;
        }
        objBusinesspurchase.ChangeProducStatus(objEntityPurchase);
        return strRet;
    }

    [WebMethod]
    public static string CancelPurchaseMstr(string strCatId, string reasonmust, string usrId, string cnclRsn, string strOrgIdID, string strCorpID)
    {
        clsBusiness_purchaseMaster objBusinesspurchase = new clsBusiness_purchaseMaster();
        clsEntityPurchaseMaster objEntityPurchase = new clsEntityPurchaseMaster();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successcncl";
        string strRandomMixedId = strCatId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityPurchase.PurchaseId = Convert.ToInt32(strId);///1
        objEntityPurchase.UserId = Convert.ToInt32(usrId);

        if (reasonmust == "1")
        {
            objEntityPurchase.CancelReason = cnclRsn;
        }

        else
        {
            objEntityPurchase.CancelReason = objCommon.CancelReason();
        }
        //0039
        clsEntityPurchaseMaster ObjEntityRequest = new clsEntityPurchaseMaster();

        //ObjEntityRequest.PurchaseId = Convert.ToInt32(strId);
        objEntityPurchase.OrgId = Convert.ToInt32(strOrgIdID);//2
        objEntityPurchase.CorpId = Convert.ToInt32(strCorpID);//3
        clsBusiness_purchaseMaster objBusinessSales = new clsBusiness_purchaseMaster();
        clsEntityPurchaseMaster ObjEntitySales = new clsEntityPurchaseMaster();

        DataTable dt = objBusinesspurchase.ReadPurchaseById(objEntityPurchase);
        try
        {

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["PURCHS_CNCL_USR_ID"].ToString() != "" && dt.Rows[0]["PURCHS_CNCL_REASN"].ToString() != "")
                {
                    strRets = "AlreadyCancl";
                }
                else
                {
                    //end
                    objBusinesspurchase.CancelProductMaster(objEntityPurchase);
                }
                //Page objpage = new Page();
                //objpage.Session["SuccessMsg"] = "DELETE";
            }
        }
        catch
        {
            strRets = "failed";
        }
        return strRets;
    }
    [WebMethod]
    public static string PrintPDF(string saleId, string orgID, string corptID, string PreparedBy,string CurrencyId)
    {

        string strRandomMixedId = saleId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        clsCommonLibrary objCommn = new clsCommonLibrary();
        clsBusiness_purchaseMaster objBusinessSales = new clsBusiness_purchaseMaster();
        clsEntityPurchaseMaster ObjEntitySales = new clsEntityPurchaseMaster();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        if (corptID != null)
        {
            ObjEntitySales.CorpId = Convert.ToInt32(corptID);
            objEntityCommon.CorporateID = Convert.ToInt32(corptID);
        }
        if (orgID != null)
        {
            ObjEntitySales.OrgId = Convert.ToInt32(orgID);
        }
        ObjEntitySales.PurchaseId = Convert.ToInt32(strId);

        if (CurrencyId != "")
            objEntityCommon.CurrencyId = Convert.ToInt32(CurrencyId);

        // for adding comma
        // clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityCommon.CurrencyId = Convert.ToInt32(CurrencyId);
        //DataTable dtCurrencyDetail = new DataTable();
        //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        //dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
        //if (dtCurrencyDetail.Rows.Count > 0)
        //{
        //    objEntityCommon.CurrencyId =Convert.ToInt32(dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString());
        //   // HiddenDefultCrncAbrvtn.Value = dtCurrencyDetail.Rows[0]["CRNCMST_ABBRV"].ToString();
        //}

        DataTable dt = objBusinessSales.ReadPurchaseById(ObjEntitySales);
        DataTable dtProduct = objBusinessSales.ReadProductPurchaseById(ObjEntitySales);

        DataTable dtCorp = objBusinessSales.ReadCorpDtls(ObjEntitySales);


        FMS_FMS_Master_fms_Purchase_Master_Purchase_Master_List objPage = new FMS_FMS_Master_fms_Purchase_Master_Purchase_Master_List();
        //    .ObjEntitySales.return objPage.PdfPrint(strId, dt, dtProduct, dtCorp, ObjEntitySales, PreparedBy);
        objEntityCommon.Vouchar_Type = Convert.ToInt32(clsCommonLibrary.VOUCHER_TYPE.PURCHASE);
        string strReturn = "";
        DataTable dtVersion = objBusiness.ReadPrintVersion(objEntityCommon);
        if (dtVersion.Rows.Count > 0)
        {
            if (dtVersion.Rows[0][0].ToString() == "1")
            {
                // strReturn = objPage.PdfPrintVersion1(dt, dtProduct, dtCorp, ObjEntitySales, PreparedBy);
                strReturn = objBusinessSales.PdfPrintVersion1(dt, dtProduct, dtCorp, ObjEntitySales, PreparedBy);
            }
            else if (dtVersion.Rows[0][0].ToString() == "2")
            {
                strReturn = objBusinessSales.PdfPrintVersion2And3(dt, dtProduct, dtCorp, ObjEntitySales, PreparedBy, 2);
            }
            else if (dtVersion.Rows[0][0].ToString() == "3")
            {
                strReturn = objBusinessSales.PdfPrintVersion2And3(dt, dtProduct, dtCorp, ObjEntitySales, PreparedBy, 3);
            }
        }
        return strReturn;

    }
    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string ReopenPurchaseDetails(string strUserID,string strPayemntId, string strOrgIdID, string strCorpID)
    {
        clsEntityPurchaseMaster ObjEntityRequest = new clsEntityPurchaseMaster();
        //  clsBusiness_PaymentAccount objBussiness = new clsBusiness_PaymentAccount();
        List<clsEntityPaymentAccount> objEntityLedger = new List<clsEntityPaymentAccount>();
        List<clsEntityPaymentAccount> objEntityLedgerCostCenter = new List<clsEntityPaymentAccount>();
        clsBusiness_purchaseMaster objBussiness = new clsBusiness_purchaseMaster();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successReopen";
        string NewRev = "";

        string strRandomMixedId = strPayemntId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        ObjEntityRequest.PurchaseId = Convert.ToInt32(strId);
        ObjEntityRequest.OrgId = Convert.ToInt32(strOrgIdID);
        ObjEntityRequest.CorpId = Convert.ToInt32(strCorpID);
        ObjEntityRequest.UserId = Convert.ToInt32(strUserID);
        try
        {
            DataTable dt = objBussiness.ReadPurchaseById(ObjEntityRequest);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["LDGR_ID"].ToString() != null)
                {
                    ObjEntityRequest.LedgerCustomer = Convert.ToInt32(dt.Rows[0]["LDGR_ID"].ToString());
                }
            }
            ObjEntityRequest.NetAmount = Convert.ToDecimal(dt.Rows[0]["PURCHS_NET_TOTAL"].ToString());

            string strdate = "";
        
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["PURCHS_CNCL_USR_ID"].ToString() != "")
                {
                    strRets = "alrdydeleted";
                }
                else if (dt.Rows[0]["PURCHS_REOPEN_USRID"].ToString() != "" && dt.Rows[0]["PURCHS_CNFRM_STS"].ToString() == "0")
                {
                    strRets = "alrdyreopened";
                }
                else
                {
                    objBussiness.ReopenPurchase(ObjEntityRequest);
                }
            }
        }
        catch
        {
            strRets = "failed";
        }
        return strRets;

    }
    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string ConfirmPurchaseDetails(string strUserID, string strPayemntId, string strOrgIdID, string strCorpID, string FinYrID)
    {
        clsEntityPurchaseMaster ObjEntityRequest = new clsEntityPurchaseMaster();
        List<clsEntityPaymentAccount> objEntityLedger = new List<clsEntityPaymentAccount>();
        List<clsEntityPaymentAccount> objEntityLedgerCostCenter = new List<clsEntityPaymentAccount>();
        clsBusiness_purchaseMaster objBussiness = new clsBusiness_purchaseMaster();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successConfirm";
        string NewRev = "";

        string strRandomMixedId = strPayemntId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        ObjEntityRequest.PurchaseId = Convert.ToInt32(strId);
        ObjEntityRequest.OrgId = Convert.ToInt32(strOrgIdID);
        ObjEntityRequest.CorpId = Convert.ToInt32(strCorpID);
        ObjEntityRequest.UserId = Convert.ToInt32(strUserID);
        ObjEntityRequest.FinancialYrID = Convert.ToInt32(FinYrID);
        ObjEntityRequest.ConfirmStatus = 1;
        try
        {
            DataTable dt = objBussiness.ReadPurchaseById(ObjEntityRequest);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["LDGR_ID"].ToString() != null)
                {
                    ObjEntityRequest.LedgerCustomer = Convert.ToInt32(dt.Rows[0]["LDGR_ID"].ToString());
                }
            }
            ObjEntityRequest.NetAmount = Convert.ToDecimal(dt.Rows[0]["PURCHS_NET_TOTAL"].ToString());
            ObjEntityRequest.AccountRef = dt.Rows[0]["PURCHS_REF"].ToString();
            ObjEntityRequest.AccountDate = objCommon.textToDateTime(dt.Rows[0]["PURCHS_DATE"].ToString());
            ObjEntityRequest.Description = dt.Rows[0]["PURCHS_DESCRIPTION"].ToString();

            List<clsEntityPurchaseMaster_list> objEntityPurchaseList = new List<clsEntityPurchaseMaster_list>();

            DataTable dtProduct = objBussiness.ReadProductPurchaseById(ObjEntityRequest);

            if (dtProduct.Rows.Count > 0)
            {
                for (int i = 0; i < dtProduct.Rows.Count; i++)
                {
                    clsEntityPurchaseMaster_list objEntitySub = new clsEntityPurchaseMaster_list();

                    objEntitySub.PurchaseProductId = Convert.ToInt32(dtProduct.Rows[i]["PURCHS_PRDUCT_ID"].ToString());
                    objEntityPurchaseList.Add(objEntitySub);
                }
            }

            string strdate = "";

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["PURCHS_CNCL_USR_ID"].ToString() != "")
                {
                    strRets = "alrdydeleted";
                }
                else if (dt.Rows[0]["PURCHS_CNFRM_STS"].ToString() != "0")
                {
                    strRets = "alrdyCnfrmd";
                }
                else
                {
                    objBussiness.ConfirmPurchase(ObjEntityRequest, objEntityPurchaseList);
                }
            }
        }
        catch
        {
            strRets = "failed";
        }

        return strRets;
    }
    
    public string PrintCaption(clsEntityPurchaseMaster ObjEntityRequest)
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
        strTitle = "PURCHASE";
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
    public DataTable GetTable(DataTable dtCategory, clsEntityPurchaseMaster ObjEntityRequest, string CurrencyId, string from, string toDt, string Suplier, string PurchaseStatus, string Status)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,                                                           
                                                      clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,    
                                                              };
        int intCorpId = 0;
        if (ObjEntityRequest.CorpId != 0)
        {
            intCorpId = ObjEntityRequest.CorpId;
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
        table.Columns.Add("PURCHASE LIST", typeof(string));
        table.Columns.Add(" ", typeof(string));
        table.Columns.Add("  ", typeof(string));
        table.Columns.Add("   ", typeof(string));
        table.Columns.Add("    ", typeof(string));

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("FROM DATE :", '"' + from + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("TO DATE :", '"' + toDt + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        if (Suplier != "")
            table.Rows.Add("SUPPLIER :", '"' + Suplier.TrimEnd(',', ' ') + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        if (Status == "1")
            table.Rows.Add("STATUS :", "Active", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        else if (Status == "0")
            table.Rows.Add("STATUS :", "Inactive", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        else
            table.Rows.Add("STATUS :", "All", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        if (PurchaseStatus == "1")
            table.Rows.Add("PURCHASE STATUS :", "Confirmed", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        else if (PurchaseStatus == "0")
            table.Rows.Add("PURCHASE STATUS :", "Pending", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        else if (PurchaseStatus == "2")
            table.Rows.Add("PURCHASE STATUS :", "Reopened", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        else
            table.Rows.Add("PURCHASE STATUS :", "All", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        //if (dtCategory.Rows.Count > 0)
        //{
            table.Rows.Add("REF #", "DATE", "SUPPLIER", "TOTAL AMOUNT", "STATUS");
        //}
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
                string SuplierName = "";

                if (dtCategory.Rows[intRowBodyCount]["PURCH_SUP_TYP"].ToString() == "0")
                {
                    SuplierName = dtCategory.Rows[intRowBodyCount]["LDGR_NAME"].ToString();
                }
                else
                {
                    SuplierName = dtCategory.Rows[intRowBodyCount]["PURCH_SUP_NAME"].ToString();
                }
                string NetAmountWithCommaFrm = "";
                string totalAmnt = "";
                if (dtCategory.Rows[intRowBodyCount]["PURCHS_NET_TOTAL"].ToString() != "")
                {
                    totalAmnt = dtCategory.Rows[intRowBodyCount]["PURCHS_NET_TOTAL"].ToString();
                }
                NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(totalAmnt.ToString(), objEntityCommon);

                Total = Total + Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["PURCHS_NET_TOTAL"].ToString());
                string strStatusImg = "";
                if (dtCategory.Rows[intRowBodyCount]["PURCHS_CNFRM_STS"].ToString() == "1")
                {
                    strStatusImg = "CONFIRMED";
                }
                else
                {
                    if (dtCategory.Rows[intRowBodyCount]["PURCHS_REOPEN_USRID"].ToString() != "")
                    {
                        strStatusImg = "REOPENED";
                    }
                    else
                    {
                        strStatusImg = "PENDING";
                    }
                }
                table.Rows.Add('"' + dtCategory.Rows[intRowBodyCount]["PURCHS_REF"].ToString() + '"', '"' + dtCategory.Rows[intRowBodyCount]["PURCHS_DATE"].ToString() + '"', '"' + SuplierName + '"', '"' + NetAmountWithCommaFrm + '"', '"' + strStatusImg + '"');

            }
            if (dtCategory.Rows.Count > 0)
            {
                table.Rows.Add("TOTAL", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + objBusiness.AddCommasForNumberSeperation(Total.ToString(), objEntityCommon) + '"', '"' + FORNULL + '"');
            }
        }
        else
        {
            table.Rows.Add(" No data available in table", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
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
    public string LoadTable_CSV(DataTable dtCategory, clsEntityPurchaseMaster ObjEntityRequest, string CurrencyId, string from, string toDt, string Suplier, string PurchaseStatus, string Status)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dt = GetTable(dtCategory, ObjEntityRequest, CurrencyId, from, toDt, Suplier, PurchaseStatus, Status);
        string strResult = DataTableToCSV(dt, ',');
        string strImagePath = "";
        string filepath = "";
        if (ObjEntityRequest.CorpId != 0)
        {
            objEntityCommon.CorporateID = ObjEntityRequest.CorpId;
        }
        if (ObjEntityRequest.OrgId != 0)
        {
            objEntityCommon.Organisation_Id = ObjEntityRequest.OrgId;
        }
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PURCHASE_CSV);
        string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
        string newFilePath = Server.MapPath("/CustomFiles/FMS CSV/Purchase/Purchase_" + strNextId + ".csv");
        System.IO.File.WriteAllText(newFilePath, strResult);
        filepath = "Purchase_" + strNextId + ".csv";
        strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.PURCHASE_CSV);
        return strImagePath + filepath;
    }
    [WebMethod]
    public static string PrintCSV(string orgID, string corptID, string Status, string PurchaseStatus, string Suplier, string from, string toDt, string CnclSts, string CurrencyId, string startDate, string EndDate, string SupName, string PageMaxSize, string PageNumber, string strCommonSearchTerm, string OrderColumn, string OrderMethod, string strInputColumnSearch)
    {
        string strReturn = "";
        //0039
        string PageMxSize = PageMaxSize;
        string PageNmbr = PageNumber;

        //end
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsBusiness_purchaseMaster objBusinesspurchase = new clsBusiness_purchaseMaster();
        clsEntityPurchaseMaster objEntityPurchase = new clsEntityPurchaseMaster();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        FMS_FMS_Master_fms_Purchase_Master_Purchase_Master_List OBJ = new FMS_FMS_Master_fms_Purchase_Master_Purchase_Master_List();
        if (CurrencyId != "")
            objEntityCommon.CurrencyId = Convert.ToInt32(CurrencyId);
        objEntityPurchase.OrgId = Convert.ToInt32(orgID);
        objEntityPurchase.CorpId = Convert.ToInt32(corptID);
        objEntityPurchase.AccountStatus = Convert.ToInt32(Status);
        objEntityPurchase.CancelStatus = Convert.ToInt32(CnclSts);

        //0039
        objEntityPurchase.PageMaxSize = Convert.ToInt32(PageMxSize);
        objEntityPurchase.PageNumber = Convert.ToInt32(PageNmbr);

        objEntityPurchase.OrderMethod = Convert.ToInt32(OrderMethod);
        objEntityPurchase.OrderColumn = Convert.ToInt32(OrderColumn);
        objEntityPurchase.CommonSearchTerm = strCommonSearchTerm;

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
        if (Suplier != "--SELECT SUPPLIER --" && Suplier != "0")
        {
            objEntityPurchase.LedgerCustomer = Convert.ToInt32(Suplier);
        }
        if (from != "")
        {
            objEntityPurchase.FromDate = objCommon.textToDateTime(from);
        }
        if (toDt != "")
        {
            objEntityPurchase.ToDate = objCommon.textToDateTime(toDt);
        }

        if (startDate != "")
        {
            objEntityPurchase.StartDate = objCommon.textToDateTime(startDate);
        }
        if (EndDate != "")
        {
            objEntityPurchase.EndDate = objCommon.textToDateTime(EndDate);
        } if (PurchaseStatus != "")
        {
            objEntityPurchase.ConfirmStatus = Convert.ToInt32(PurchaseStatus);
        }
        DataTable dtCategory = objBusinesspurchase.ReadPurchseOnList(objEntityPurchase);

        strReturn = OBJ.LoadTable_CSV(dtCategory, objEntityPurchase, CurrencyId, from, toDt, SupName, PurchaseStatus, Status);

        return strReturn;
    }

    [WebMethod]
    public static string PrintList(string orgID, string corptID, string Status, string PurchaseStatus, string Suplier, string from, string toDt, string CnclSts, string CurrencyId, string startDate, string EndDate, string SupName, string PageMaxSize, string PageNumber, string strCommonSearchTerm, string OrderColumn, string OrderMethod, string strInputColumnSearch)
    {
        string strReturn = "";
        //0039
        string PageMxSize = PageMaxSize;
        string PageNmbr = PageNumber;

        //end
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsBusiness_purchaseMaster objBusinesspurchase = new clsBusiness_purchaseMaster();
        clsEntityPurchaseMaster objEntityPurchase = new clsEntityPurchaseMaster();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (CurrencyId != "")
        objEntityCommon.CurrencyId = Convert.ToInt32(CurrencyId);
        objEntityPurchase.OrgId = Convert.ToInt32(orgID);
        objEntityPurchase.CorpId = Convert.ToInt32(corptID);
        objEntityPurchase.AccountStatus = Convert.ToInt32(Status);
        objEntityPurchase.CancelStatus = Convert.ToInt32(CnclSts);
        //0039
        objEntityPurchase.PageMaxSize = Convert.ToInt32(PageMxSize);
        objEntityPurchase.PageNumber = Convert.ToInt32(PageNmbr);

        objEntityPurchase.OrderMethod = Convert.ToInt32(OrderMethod);
        objEntityPurchase.OrderColumn = Convert.ToInt32(OrderColumn);
        objEntityPurchase.CommonSearchTerm = strCommonSearchTerm;

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
        if (Suplier != "--SELECT SUPPLIER --" && Suplier != "0")
        {
            objEntityPurchase.LedgerCustomer = Convert.ToInt32(Suplier);
        }
        if (from != "")
        {
            objEntityPurchase.FromDate = objCommon.textToDateTime(from);
        }
        if (toDt != "")
        {
            objEntityPurchase.ToDate = objCommon.textToDateTime(toDt);
        }

        if (startDate != "")
        {
            objEntityPurchase.StartDate = objCommon.textToDateTime(startDate);
        }
        if (EndDate != "")
        {
            objEntityPurchase.EndDate = objCommon.textToDateTime(EndDate);
        } if (PurchaseStatus != "")
        {
            objEntityPurchase.ConfirmStatus = Convert.ToInt32(PurchaseStatus);
        }




        DataTable dtCategory = objBusinesspurchase.ReadPurchseOnList(objEntityPurchase);
        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.TRANSACTION_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PURCHASE_PDF);
        objEntityCommon.CorporateID = objEntityPurchase.CorpId;
        objEntityCommon.Organisation_Id = objEntityPurchase.OrgId;
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "PurchaseList_" + strNextNumber + ".pdf";

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
                if (SupName != "")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("SUPPLIER  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(SupName, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
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
                footrtable.AddCell(new PdfPCell(new Phrase("PURCHASE STATUS  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (PurchaseStatus == "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Pending", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else if (PurchaseStatus == "1")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Confirmed", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else if (PurchaseStatus == "2")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Reopened", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else if (PurchaseStatus == "3")
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
                TBCustomer.AddCell(new PdfPCell(new Phrase("SUPPLIER", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("TOTAL AMOUNT ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("STATUS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
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
                        string SuplierName = "";
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["PURCHS_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["PURCHS_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        if (dtCategory.Rows[intRowBodyCount]["PURCH_SUP_TYP"].ToString() == "0")
                        {
                            SuplierName = dtCategory.Rows[intRowBodyCount]["LDGR_NAME"].ToString();
                        }
                        else
                        {
                            SuplierName = dtCategory.Rows[intRowBodyCount]["PURCH_SUP_NAME"].ToString();
                        }
                        TBCustomer.AddCell(new PdfPCell(new Phrase(SuplierName, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        string NetAmountWithCommaFrm = "";
                        string totalAmnt = "";
                        if (dtCategory.Rows[intRowBodyCount]["PURCHS_NET_TOTAL"].ToString() != "")
                        {
                            totalAmnt = dtCategory.Rows[intRowBodyCount]["PURCHS_NET_TOTAL"].ToString();
                        }
                        NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(totalAmnt.ToString(), objEntityCommon);

                        Total = Total + Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["PURCHS_NET_TOTAL"].ToString());
                        TBCustomer.AddCell(new PdfPCell(new Phrase(NetAmountWithCommaFrm, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        string strStatusImg = "";
                        if (dtCategory.Rows[intRowBodyCount]["PURCHS_CNFRM_STS"].ToString() == "1")
                        {
                            strStatusImg = "CONFIRMED";
                        }
                        else
                        {
                            if (dtCategory.Rows[intRowBodyCount]["PURCHS_REOPEN_USRID"].ToString() != "")
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
                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(Total.ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
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
            headtable.AddCell(new PdfPCell(new Phrase("PURCHASE LIST ", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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
    public static string PurchaseAmountSum(string orgID, string corptID, string Status, string PurchaseStatus, string Suplier, string from, string toDt, string CnclSts, string CurrencyId, string startDate, string EndDate)
    {
        string strReturn = "";

        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsBusiness_purchaseMaster objBusinesspurchase = new clsBusiness_purchaseMaster();
        clsEntityPurchaseMaster objEntityPurchase = new clsEntityPurchaseMaster();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (CurrencyId != "")
        objEntityCommon.CurrencyId = Convert.ToInt32(CurrencyId);
        objEntityPurchase.OrgId = Convert.ToInt32(orgID);
        objEntityPurchase.CorpId = Convert.ToInt32(corptID);
        objEntityPurchase.AccountStatus = Convert.ToInt32(Status);
        objEntityPurchase.CancelStatus = Convert.ToInt32(CnclSts);
        if (Suplier != "--SELECT SUPPLIER --" && Suplier != "0")
        {
            objEntityPurchase.LedgerCustomer = Convert.ToInt32(Suplier);
        }
        if (from != "")
        {
            objEntityPurchase.FromDate = objCommon.textToDateTime(from);
        }
        if (toDt != "")
        {
            objEntityPurchase.ToDate = objCommon.textToDateTime(toDt);
        }

        if (startDate != "")
        {
            objEntityPurchase.StartDate = objCommon.textToDateTime(startDate);
        }
        if (EndDate != "")
        {
            objEntityPurchase.EndDate = objCommon.textToDateTime(EndDate);
        } if (PurchaseStatus != "")
        {
            objEntityPurchase.ConfirmStatus = Convert.ToInt32(PurchaseStatus);
        }
        DataTable dtCategory = objBusinesspurchase.ReadPurchseOnList_Sum(objEntityPurchase);
        StringBuilder sb = new StringBuilder();

        string strHtml = "";
        if (dtCategory.Rows.Count > 0 && dtCategory.Rows[0]["TOTAL"].ToString()!="")
        {
         //   strHtml = dtCategory.Rows[0]["TOTAL"].ToString();
            //strHtml = "<tr>";
            strHtml +="<td class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > TOTAL</td>";
            strHtml +="<td class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </td>";
            strHtml +="<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
            strHtml += "<td class=\"tr_r bg1 txt_rd\" style=\"text-align:right !important;\" id=\"tdtotal\">" + objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[0]["TOTAL"].ToString(), objEntityCommon) + " </td>";
            strHtml +="<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
            
            //strHtml +="</tr>";
        }
        sb.Append(strHtml);
        return sb.ToString();
    }

    //0039
    public static string[] ConvertDataTableToHTML(DataTable dt, string CnclSts, string intEnableModify, string intEnableCancel, string Confirm, string ReOpen, DateTime acntClsDate, int YearEndCls, string EnableAudit, string AcntPrvsn, string CurrencyID, string Org_Id, string Corpt_Id, string Sum)
    {

        //0039

        cls_Business_Audit_Closeing objEmpAuditCls = new cls_Business_Audit_Closeing();
        clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        string strHtml = "";
        string[] strReturn = new string[2];


        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        StringBuilder sbHead = new StringBuilder();
        StringBuilder sb = new StringBuilder();

        sbHead.Append("<th id=\"tdColumnHead_1\" onclick=\"SetOrderByValue(1)\" class=\"sorting col-md-2 tr_l\" style=\"word-wrap:break-word;\">REF#<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbHead.Append("<th id=\"tdColumnHead_2\" onclick=\"SetOrderByValue(2)\" class=\"sorting col-md-2 tr_c\" style=\"word-wrap:break-word;\">DATE<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbHead.Append("<th id=\"tdColumnHead_3\" onclick=\"SetOrderByValue(3)\" class=\"sorting col-md-2 tr_l\" style=\"word-wrap:break-word;\">SUPPLIER<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbHead.Append("<th id=\"tdColumnHead_4\" onclick=\"SetOrderByValue(4)\" class=\"sorting col-md-2 tr_r\" style=\"word-wrap:break-word;\">TOTAL AMOUNT<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        if (CnclSts != "1")
        {
            sbHead.Append("<th id=\"tdColumnHead_5\" onclick=\"SetOrderByValue(5)\" class=\"sorting col-md-2 tr_c\" style=\"word-wrap:break-word;\">STATUS</th>");
        }

        sbHead.Append("<th class=\"col-md-2\" style=\"word-wrap:break-word;\">ACTIONS</th>");

        int intCount = 0;
        foreach (DataRow dtRowsIn in dt.Rows)
        {
            string strDelete = "";
            string strEdit = "";
            intCount = intCount + 1;
            string strCount = Convert.ToString(intCount);
            string strId = dtRowsIn[0].ToString();
            int usrId = Convert.ToInt32(strId);
            int intIdLength = dtRowsIn[0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            string strStatus = "";
            string stsmode;
            string strStatusImg = "";
            string totalAmnt = "";
            string SuplierName = "";
            string NetAmountWithCommaFrm = "";
            string strPrint = "";
            string strReopen = "";
            string strConfirm = "";
            decimal DecimalTotl = 0;
            string StrTotl = "";

            stsmode = dtRowsIn["STATUS"].ToString();
            string cnclusrId = dtRowsIn["PURCHS_CNCL_USR_ID"].ToString();

            int confrm = 0;
            confrm = Convert.ToInt32(dtRowsIn["PURCHS_CNFRM_STS"].ToString());
            objEntityAudit.FromDate = objCommon.textToDateTime(dtRowsIn["PURCHS_DATE"].ToString());
            DataTable dtAuditClsDate = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);

            string SettleCnt = dtRowsIn["CNT_SETTLE"].ToString();
            if (CnclSts != "1")
            {
                if (confrm > 0)
                {
                    strStatusImg = "<td class=\"tdT\"  >Confirmed </td>";
                }
                else if (dtRowsIn["PURCHS_REOPEN_STATUS"].ToString() == "1")
                {
                    if (dtRowsIn["PURCHS_REOPEN_USRID"].ToString() != "")
                    {
                        strStatusImg = "<td class=\"tdT\" >Reopened </td>";
                    }
                }
                else
                {
                    strStatusImg = "<td class=\"tdT\"  >Pending </td>";
                }
            }
            //0039
            if (dtRowsIn["PURCH_SUP_TYP"].ToString() == "0")
            {
                SuplierName = dtRowsIn["LDGR_NAME"].ToString();
            }
            else
            {
                SuplierName = dtRowsIn["PURCH_SUP_NAME"].ToString();
            }
            if (dtRowsIn["PURCHS_NET_TOTAL"].ToString() != "")
            {
                totalAmnt = dtRowsIn["PURCHS_NET_TOTAL"].ToString();
                DecimalTotl = Convert.ToDecimal(dtRowsIn["PURCHS_NET_TOTAL"].ToString());
            }

            NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(totalAmnt.ToString(), objEntityCommon);
            //end
            strHtml += "<tr>";
            strHtml += "<td class=\"tr_l\"  style=\"word-break: break-all; word-wrap:break-word;\" > " + dtRowsIn["PURCHS_REF"].ToString() + "</td>";
            strHtml += "<td class=\"tr_c\"  style=\"word-break: break-all; word-wrap:break-word;\" > " + dtRowsIn["PURCHS_DATE"].ToString() + "</td>";
            strHtml += "<td class=\"tr_l\"  style=\"word-break: break-all; word-wrap:break-word;\" > " + SuplierName + "</td>";
            strHtml += "<td class=\"tr_r\"  style=\"word-break: break-all; word-wrap:break-word;\"> " + NetAmountWithCommaFrm + "</td>";
            strHtml += strStatusImg;

            strHtml += "<td>";
            strHtml += "<div class=\"btn_stl1\">";

            int ID = Convert.ToInt32(dtRowsIn["PURCHS_REF_SEQNUM"].ToString());

            string strView = "";
            if (CnclSts == "1")
            {
                strView = "<a class=\"btn act_btn bn4 \" title=\"View\"onclick='return getdetails(this.href);' href=\"Purchase_master.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";
            }
            else
            {
                if (YearEndCls == 0)
                {

                    if (confrm > 0)
                    {
                        strDelete = " <a class=\"btn act_btn bn3\" href=\"javascript:;\" title=\"Delete\" disabled=\"true\"  onclick=\"return CancelNotPossible();\"><i style=\"opacity: 0.5\"disabled=\"true\"  class=\"fa fa-trash\"></i></a>";
                        strEdit = "<a class=\"btn act_btn bn4\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"Purchase_master.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";



                        if (ReOpen == "1")
                        {
                            if (SettleCnt == "0")
                            {
                                if (dtAuditClsDate.Rows.Count > 0)
                                {

                                    if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dtRowsIn["PURCHS_DATE"].ToString()))
                                    {

                                        if (EnableAudit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                                        {
                                            strReopen = "<a class=\"btn act_btn bn2 \" title=\"REOPEN\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" ></i></a>";

                                        }
                                        else
                                        {
                                            strReopen = "<a style=\"opacity: 0.5;\" disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"REOPEN\" " + "><i class=\"fa fa-unlock\"></i></a>";

                                        }
                                    }
                                    else
                                    {
                                        strReopen = "<a class=\"btn act_btn bn2 \" title=\"REOPEN\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" ></i></a>";

                                    }

                                }

                                //else if (acntClsDate != "")
                                //{
                                if (acntClsDate >= objCommon.textToDateTime(dtRowsIn["PURCHS_DATE"].ToString()))
                                {

                                    if (EnableAudit == "1")
                                    {
                                        strReopen = "<a class=\"btn act_btn bn2 \" title=\"REOPEN\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" ></i></a>";

                                    }
                                    else
                                    {
                                        strReopen = "<a style=\"opacity: 0.5;\" disabled=\"true\" class=\"btn act_btn bn2\" href=\"javascript:;\" title=\"REOPEN\" " + "><i class=\"fa fa-unlock\" ></i></a>";
                                    }
                                }
                                else
                                {
                                    strReopen = "<a class=\"btn act_btn bn2 \" title=\"REOPEN\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" ></i></a>";

                                }
                                //}
                                //else
                                //{
                                //    strReopen = "<a class=\"btn act_btn bn2 \" title=\"REOPEN\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" ></i></a>";
                                //}

                            }
                            else
                            {
                                strReopen = "<a style=\"opacity: 0.5;\" disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" onclick=\"return ReopenNotPossible();\" title=\"REOPEN\" " + "><i class=\"fa fa-unlock\" ></i></a>";
                            }
                        }
                        else
                        {
                            strReopen = "<a style=\"opacity: 0.5;\" disabled=\"true\" class=\"btn act_btn bn2\" href=\"javascript:;\" title=\"REOPEN\" " + "><i class=\"fa fa-unlock\" ></i></a>";

                        }
                        strConfirm = "<a style=\"opacity: 0.5;\" disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";

                    }
                    else
                    {
                        if (dtAuditClsDate.Rows.Count > 0)
                        {

                            if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dtRowsIn["PURCHS_DATE"].ToString()))
                            {

                                if (EnableAudit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                                {
                                    strDelete = " <a class=\"btn act_btn bn3\" href=\"javascript:;\" title=\"Delete\"  onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>";

                                }
                                else
                                {
                                    strDelete = " <a class=\"btn act_btn bn3\" href=\"javascript:;\" title=\"Delete\" disabled=\"true\"  onclick=\"return CancelNotPossible();\"><i style=\"opacity: 0.5\" disabled=\"true\" class=\"fa fa-trash\"></i></a>";

                                }
                            }
                            else
                            {
                                strDelete = " <a class=\"btn act_btn bn3\" href=\"javascript:;\" title=\"Delete\"  onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>";

                            }

                        }

                        //else if (acntClsDate != "")
                        //{
                        if (acntClsDate >= objCommon.textToDateTime(dtRowsIn["PURCHS_DATE"].ToString()))
                        {

                            if (EnableAudit == "1")
                            {
                                strDelete = " <a class=\"btn act_btn bn3\" href=\"javascript:;\" title=\"Delete\"  onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>";

                            }
                            else
                            {
                                strDelete = " <a class=\"btn act_btn bn3\" href=\"javascript:;\" title=\"Delete\" disabled=\"true\" onclick=\"return CancelNotPossible();\"><i style=\"opacity: 0.5\" disabled=\"true\" class=\"fa fa-trash\"></i></a>";
                            }
                        }
                        else
                        {
                            strDelete = " <a class=\"btn act_btn bn3\" href=\"javascript:;\" title=\"Delete\"  onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>";

                        }
                        //}
                        //else
                        //{
                        //    strDelete = " <a class=\"btn act_btn bn3\" href=\"javascript:;\" title=\"Delete\"  onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>";
                        //}



                        if (dtAuditClsDate.Rows.Count > 0)
                        {

                            if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dtRowsIn["PURCHS_DATE"].ToString()))
                            {

                                if (EnableAudit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                                {
                                    strEdit = "<a class=\"btn act_btn bn1\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"Purchase_master.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";


                                }
                                else
                                {
                                    strEdit = "<a class=\"btn act_btn bn4\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"Purchase_master.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";

                                }
                            }
                            else
                            {
                                strEdit = "<a class=\"btn act_btn bn1\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"Purchase_master.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";


                            }

                        }

                        //else if (acntClsDate != "")
                        //{
                        if (acntClsDate >= objCommon.textToDateTime(dtRowsIn["PURCHS_DATE"].ToString()))
                        {

                            if (EnableAudit == "1")
                            {
                                strEdit = "<a class=\"btn act_btn bn1\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"Purchase_master.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";


                            }
                            else
                            {
                                strEdit = "<a class=\"btn act_btn bn4\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"Purchase_master.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";
                            }
                        }
                        else
                        {
                            strEdit = "<a class=\"btn act_btn bn1\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"Purchase_master.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";


                        }
                        //}
                        //else
                        //{
                        //    strEdit = "<a class=\"btn act_btn bn1\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"Purchase_master.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";

                        //}

                        //strPrint = "<td style=\"width:1%;opacity: 0.2;cursor: pointer;  word-break: break-all;word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn btn-xs btn-default\" title=\"Print Invoice\" href=\"javascript:;\" onclick=\"return PrintNotPossible();\"><i style=\"opacity: 0.5\" class=\"fa fa-print\"></i></a>";

                        strReopen = "<a style=\"opacity: 0.5;\" disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-unlock\" ></i></a>";
                        if (Confirm == "1")
                        {
                            if (dtAuditClsDate.Rows.Count > 0)
                            {

                                if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dtRowsIn["PURCHS_DATE"].ToString()))
                                {

                                    if (EnableAudit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                                    {
                                        strConfirm = "<a class=\"btn act_btn bn2 \" title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";


                                    }
                                    else
                                    {
                                        strConfirm = "<a style=\"opacity: 0.5;\" disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";

                                    }
                                }
                                else
                                {
                                    strConfirm = "<a class=\"btn act_btn bn2 \" title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";


                                }

                            }

                            //else if (acntClsDate != "")
                            //{
                            if (acntClsDate >= objCommon.textToDateTime(dtRowsIn["PURCHS_DATE"].ToString()))
                            {

                                if (EnableAudit == "1")
                                {
                                    strConfirm = "<a class=\"btn act_btn bn2 \" title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";


                                }
                                else
                                {
                                    strConfirm = "<a style=\"opacity: 0.5;\" disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";
                                }
                            }
                            else
                            {
                                strConfirm = "<a class=\"btn act_btn bn2 \" title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";


                            }
                            //}
                            //else
                            //{
                            //    strConfirm = "<a class=\"btn act_btn bn2\" title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";

                            //}


                        }
                        else
                        {
                            strConfirm = "<a style=\"opacity: 0.5;\" disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";

                        }

                    }

                }
                else
                {
                    strReopen = "<a style=\"opacity: 0.5;\" disabled=\"true\" class=\"btn act_btn bn2\" href=\"javascript:;\" title=\"REOPEN\" " + "><i class=\"fa fa-unlock\" ></i></a>";
                    strDelete = " <a class=\"btn act_btn bn3\" href=\"javascript:;\" title=\"Delete\" disabled=\"true\"  onclick=\"return CancelNotPossible();\"><i style=\"opacity: 0.5\" disabled=\"true\" class=\"fa fa-trash\"></i></a>";
                    strEdit = "<a class=\"btn act_btn bn4\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"Purchase_master.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";
                    strConfirm = "<a style=\"opacity: 0.5;\" disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";

                }

                strPrint = " <a class=\"btn act_btn bn6\" title=\"Print Invoice\" href=\"javascript:;\" onclick=\"return OpenPrint('" + Id + "');\"><i class=\"fa fa-print\"></i></a>";
            }

            if (dtRowsIn["PURCHS_NET_TOTAL"].ToString() != "")
            {
                totalAmnt = dtRowsIn["PURCHS_NET_TOTAL"].ToString();
            }

            if (dtRowsIn["PURCH_SUP_TYP"].ToString() == "0")
            {
                SuplierName = dtRowsIn["LDGR_NAME"].ToString();
            }
            else
            {
                SuplierName = dtRowsIn["PURCH_SUP_NAME"].ToString();
            }

            NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(totalAmnt.ToString(), objEntityCommon);

            StrTotl = "<td =id=\"sdggfgdfg\" style=\"display:none;\">  " + dtRowsIn["PURCHS_NET_TOTAL"].ToString() + " </td>";
            int strnn = Convert.ToInt32(dtRowsIn["PURCHS_REF_SEQNUM"].ToString());

            strHtml += strView + strEdit + strConfirm + strReopen + strDelete + strPrint;

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
    }

       

   [WebMethod]
    public static string[] GetData(string CorpId, string OrgId, string ddlStatus, string CancelStatus, string Supplier, string From, string ToDt, string FinncialStartDate, string FinncialEndDate, string EnableModify, string EnableCancel, string ROpenSts, string AccntPrvision, string EnbleAudit, string PurchsStatus, string EnbleConfirm, string CurencyID, string UserId, string PageMaxSize, string strCommonSearchTerm, string OrderColumn, string OrderMethod, string strInputColumnSearch, string PageNumber)
    {
        string[] strResults = new string[3];

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityPurchaseMaster objEntityPurchase = new clsEntityPurchaseMaster();
        clsBusiness_purchaseMaster objBusinesspurchase = new clsBusiness_purchaseMaster();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        cls_Business_Audit_Closeing objEmpAuditCls = new cls_Business_Audit_Closeing();
        clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();

        if (CurencyID != "")
            objEntityCommon.CurrencyId = Convert.ToInt32(CurencyID);
        objEntityPurchase.OrgId = Convert.ToInt32(OrgId);
        objEntityPurchase.CorpId = Convert.ToInt32(CorpId);
        objEntityPurchase.AccountStatus = Convert.ToInt32(ddlStatus);//
        objEntityPurchase.CancelStatus = Convert.ToInt32(CancelStatus);
        objEntityAudit.Organisation_id = Convert.ToInt32(OrgId);
        objEntityAudit.Corporate_id = Convert.ToInt32(CorpId);
        if (Supplier != "--SELECT SUPPLIER --" && Supplier != "0")
        {
            objEntityPurchase.LedgerCustomer = Convert.ToInt32(Supplier);
        }
        if (From != "")
        {
            objEntityPurchase.FromDate = objCommon.textToDateTime(From);
        }
        if (ToDt != "")
        {
            objEntityPurchase.ToDate = objCommon.textToDateTime(ToDt);
        }

        if (FinncialStartDate != "")
        {
            objEntityPurchase.StartDate = objCommon.textToDateTime(FinncialStartDate);
        }
        if (FinncialEndDate != "")
        {
            objEntityPurchase.EndDate = objCommon.textToDateTime(FinncialEndDate);
        } if (PurchsStatus != "")
        {
            objEntityPurchase.ConfirmStatus = Convert.ToInt32(PurchsStatus);
        }

        objEntityCommon.Organisation_Id = objEntityPurchase.OrgId;
        objEntityCommon.CorporateID = objEntityPurchase.CorpId;


        DataTable dtCategory = objBusinesspurchase.ReadPurchseOnList_Sum(objEntityPurchase);
        string Sum = dtCategory.Rows[0]["TOTAL"].ToString();


        DataTable dtAcntClsDate = objBusiness.ReadAccountClsDate(objEntityCommon);
        DateTime acntClsDate = DateTime.MinValue;
        int YearEndCls = 0;

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

        objEntityPurchase.PageNumber = Convert.ToInt32(PageNumber);
        objEntityPurchase.PageMaxSize = Convert.ToInt32(PageMaxSize);
        objEntityPurchase.OrderMethod = Convert.ToInt32(OrderMethod);
        objEntityPurchase.OrderColumn = Convert.ToInt32(OrderColumn);
        objEntityPurchase.CommonSearchTerm = strCommonSearchTerm;

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

        objEntityPurchase.SearchRef = strSearchInputs[Convert.ToInt32(SearchInputColumns.REF)];
        objEntityPurchase.SearchDate = strSearchInputs[Convert.ToInt32(SearchInputColumns.DATE)];
        objEntityPurchase.SearchSuppl = strSearchInputs[Convert.ToInt32(SearchInputColumns.SUPPLIER)];
        objEntityPurchase.SearchAmount = strSearchInputs[Convert.ToInt32(SearchInputColumns.TOTALAMOUNT)];


        //ReadList


        DataTable dtList = objBusinesspurchase.ReadPurchseOnList(objEntityPurchase);


        string intCancelStatus = CancelStatus;
        string intEnableModify = EnableModify;
        string intEnableCancel = EnableCancel;
        string intConfirmSts = EnbleConfirm;
        string intReopenSts = ROpenSts;
        //string acntClsDate = ROpenSts;
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
            strResults[2] = objBusinessLayer.GenereatePagination(intTotalItems, objEntityPurchase.PageNumber, objEntityPurchase.PageMaxSize, intCurrentRowCount);
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
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"SUPPLIER\" placeholder=\"Supplier\"></th>");
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
        SUPPLIER = 2,
        TOTALAMOUNT = 3,
    }
    //end

}