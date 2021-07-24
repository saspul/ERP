using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using EL_Compzit.EntityLayer_PMS;
using BL_Compzit.BusinessLayer_PMS;
using EL_Compzit;
using BL_Compzit;
using CL_Compzit;
using System.Web.Services;
using Newtonsoft.Json;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web.Script.Serialization;
using System.IO;

public partial class PMS_PMS_Master_pms_Purchase_Order_pms_Purchase_Order_List : System.Web.UI.Page
{

    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Request.QueryString["Inscopy"] != null)
        {
            this.MasterPageFile = "~/MasterPage/MasterPageCompzitModal.master";
        }
        else
        {
            this.MasterPageFile = "~/MasterPage/MasterPageCompzit.master";
        }
    }

    clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
    clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();

    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
    clsEntityCommon objEntityCommon = new clsEntityCommon();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int intUserId = 0;
            if (Session["USERID"] != null)
            {
                objEntityPurchaseOrder.UserId = Convert.ToInt32(Session["USERID"]);
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityPurchaseOrder.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                objEntityPurchaseOrder.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            this.Form.Enctype = "multipart/form-data";

            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {       clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                               clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                       };
            DataTable dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId); //GN_CORP_GLOBAL
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDefaultCurrencyId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                HiddenCancelReasonMust.Value = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
            }

            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDefaultCurrencyId.Value);
            DataTable dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon); //CURRENCY
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
                hiddenDefaultCrncyAbrvtn.Value = dtCurrencyDetail.Rows[0]["CRNCMST_ABBRV"].ToString();
            }

            LoadVendors();
            LoadDocumntWrkflw();

            int intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Purchase_Order_Master);
            int intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableDiscount = 0, intEnableConfirm = 0, intEnableReopen = 0;
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
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.DISCOUNT).ToString())
                    {
                        intEnableDiscount = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intEnableReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                }
            }

            hiddenEnableModify.Value = intEnableModify.ToString();
            hiddenEnableCancel.Value = intEnableCancel.ToString();
            hiddenEnableConfirm.Value = intEnableConfirm.ToString();
            hiddenEnableReopen.Value = intEnableReopen.ToString();


            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
            }
            else
            {
                divAdd.Visible = false;
            }

            // for copy
            if (Request.QueryString["Inscopy"] != null)
            {
                HiddenCopy.Value = "1";
                divAdd.Visible = false;
                OlSection.Visible = false;
                divCancel.Attributes.Add("style", "display:none;");
            }
            else
            {
                HiddenCopy.Value = "0";
            }
            //


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
                else if (strInsUpd == "Confrm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                }
                else if (strInsUpd == "Reopen")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReopen", "SuccessReopen();", true);
                }
                else if (strInsUpd == "AlrdyReopnd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AlreadyReopened", "AlreadyReopened();", true);
                }
                else if (strInsUpd == "AlrdyCnfrm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AlreadyConfirmed", "AlreadyConfirmed();", true);
                }
                else if (strInsUpd == "Note")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessNote", "SuccessNote();", true);
                }
                else if (strInsUpd == "NoteReply")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessNoteReply", "SuccessNoteReply();", true);
                }
                else if (strInsUpd == "AlrdyDeleted")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AlreadyDeleted", "AlreadyDeleted();", true);
                }
                else if (strInsUpd == "Cmnt")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessComment", "SuccessComment();", true);
                }
                
                
            }

            ddlPrchsOrdrType.Focus();

        }
    }

    public void LoadVendors()
    {
        DataTable dt = objBusinessPurchaseOrder.ReadVendor(objEntityPurchaseOrder);

        ddlVendor.Items.Clear();
        if (dt.Rows.Count > 0)
        {
            ddlVendor.DataSource = dt;
            ddlVendor.DataTextField = "SUPLIR_NAME";
            ddlVendor.DataValueField = "SUPLIR_ID";
            ddlVendor.DataBind();
        }
        ddlVendor.Items.Insert(0, "--SELECT VENDOR--");
    }

    public void LoadDocumntWrkflw()
    {
        DataTable dt = objBusinessPurchaseOrder.ReadDocumntWrkflow(objEntityPurchaseOrder);

        ddlDocumntWrkflw.Items.Clear();
        if (dt.Rows.Count > 0)
        {
            ddlDocumntWrkflw.DataSource = dt;
            ddlDocumntWrkflw.DataTextField = "WRKFLW_NAME";
            ddlDocumntWrkflw.DataValueField = "WRKFLW_ID";
            ddlDocumntWrkflw.DataBind();
        }
        ddlDocumntWrkflw.Items.Insert(0, "--SELECT DOCUMENT WORKFLOW--");
    }

    public static string[] ConvertDataTableToHTML(DataTable dt, clsEntityPurchaseOrder objEntity, int CancelSts, int intEnableModify, int intEnableCancel, int intEnableConfirm, int intEnableReopen, int intcopy)
    {
        string[] strReturn = new string[2];

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        StringBuilder sbHead = new StringBuilder();
        StringBuilder sb = new StringBuilder();

        sbHead.Append("<th id=\"tdColumnHead_1\" onclick=\"SetOrderByValue(1)\" class=\"sorting th_b6 tr_c\" style=\"word-wrap:break-word;\">Date<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbHead.Append("<th id=\"tdColumnHead_2\" onclick=\"SetOrderByValue(2)\" class=\"sorting th_b4 tr_l\" style=\"word-wrap:break-word;\">Purchase Order#<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbHead.Append("<th id=\"tdColumnHead_3\" onclick=\"SetOrderByValue(3)\" class=\"sorting th_b4 tr_l\" style=\"word-wrap:break-word;\">Purchase<br> Order Type<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbHead.Append("<th id=\"tdColumnHead_4\" onclick=\"SetOrderByValue(4)\" class=\"sorting th_b4 tr_l\" style=\"word-wrap:break-word;\">Vendor Name<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbHead.Append("<th id=\"tdColumnHead_5\" onclick=\"SetOrderByValue(5)\" class=\"sorting th_b4 tr_l\" style=\"word-wrap:break-word;\">Document<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        if (CancelSts == 0)
        {
            sbHead.Append("<th class=\"th_b6\" style=\"word-wrap:break-word;\">Status</th>");
        }
        sbHead.Append("<th id=\"tdColumnHead_6\" onclick=\"SetOrderByValue(6)\" class=\"sorting th_b8\" style=\"word-wrap:break-word;\">Expected Delivery Date<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbHead.Append("<th id=\"tdColumnHead_7\" onclick=\"SetOrderByValue(7)\" class=\"sorting th_b6 tr_r\" style=\"word-wrap:break-word;\">Amount<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        // for copy//
        if (intcopy != 1)
        {
            sbHead.Append("<th class=\"th_b4\" style=\"word-wrap:break-word;\">Actions</th>");
        }

        if (dt.Rows.Count > 0)
        {

            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                sb.Append("<tr>");

                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                // for copy//
                if (intcopy == 1)
                {
                    sb.Append("<td><a href=\"javascript:;\" onclick=\"return OpenCopyModal('" + Id + "');\" data-toggle=\"modal\" data-target=\"#CopyModal\">" + dt.Rows[intRowBodyCount]["PRCHSORDR_DATE"].ToString() + "</a></td>");
                    sb.Append("<td id=\"tdDate" + Id + "\" style=\"display:none;\">" + dt.Rows[intRowBodyCount]["PRCHSORDR_DATE"].ToString() + "</td>");
                }
                else
                {
                    sb.Append("<td id=\"tdDate" + Id + "\">" + dt.Rows[intRowBodyCount]["PRCHSORDR_DATE"].ToString() + "</td>");
                }

                sb.Append("<td id=\"tdRef" + Id + "\" class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount]["PRCHSORDR_REF"].ToString() + "</td>");
                sb.Append("<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount]["PO_TYP"].ToString() + "</td>");
                sb.Append("<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount]["SUPLIR_NAME"].ToString() + "</td>");
                sb.Append("<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount]["WRKFLW_NAME"].ToString() + "</td>");
                int Status = Convert.ToInt32(dt.Rows[intRowBodyCount]["PRCHSORDR_CONFRM_STS"].ToString());

                if (CancelSts == 0)
                {
                    if (Status == 0)//Pending
                    {
                        if (dt.Rows[intRowBodyCount]["PRCHSORDR_REOPN_USR_ID"].ToString() == "")
                        {
                            sb.Append("<td><button class=\"btn tab_but1 butn2\" onclick=\"return OpenStatus('" + Id + "');\" data-toggle=\"modal\" data-target=\"#ModalStatus\">Pending</button></td>");
                        }
                        else
                        {
                            sb.Append("<td><button class=\"btn tab_but1 butn4\" onclick=\"return OpenStatus('" + Id + "');\" data-toggle=\"modal\" data-target=\"#ModalStatus\">Reopened</button></td>");
                        }
                    }
                    else if (Status == 1)//Confirmed
                    {
                        sb.Append("<td><button class=\"btn tab_but1 butn1\" onclick=\"return OpenStatus('" + Id + "');\" data-toggle=\"modal\" data-target=\"#ModalStatus\">Confirmed</button></td>");
                    }
                }

                sb.Append("<td style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount]["PRCHSORDR_DLVRYDT"].ToString() + "</td>");

                clsEntityCommon objEntityCommon = new clsEntityCommon();
                clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

                objEntityCommon.CurrencyId = objEntity.CurrencyId;
                string strNetAmountWithComma = objBusinessLayer.AddCommasForNumberSeperation(dt.Rows[intRowBodyCount]["PRCHSORDR_NET_TOTAL"].ToString(), objEntityCommon);

                sb.Append("<td class=\"tr_r\" style=\"word-break: break-all; word-wrap:break-word;\" >" + strNetAmountWithComma + "</td>");

                // for copy//
                if (intcopy != 1)
                {
                    sb.Append("<td>");

                    if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (CancelSts == 0)
                        {
                            if (Status == 1)//Confirmed
                            {
                                sb.Append("<a class=\"btn act_btn bn4 bt_v\" title=\"View\" onclick='return getdetails(this.href);' " +
                                              "href=\"pms_Purchase_Order.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>");
                            }
                            else
                            {
                                sb.Append("<a class=\"btn act_btn bn1 bt_e\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                              "href=\"pms_Purchase_Order.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>");
                            }
                        }
                    }
                    if (CancelSts == 1)//Cancelled
                    {
                        sb.Append("<a class=\"btn act_btn bn4 bt_v\" title=\"View\" onclick='return getdetails(this.href);' " +
                                     "href=\"pms_Purchase_Order.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>");
                    }
                    if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (CancelSts == 0)
                        {
                            if (Status == 1)//Confirmed
                            {
                                sb.Append("<a disabled href=\"javascript:;\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return CancelNotPossible();\"><i class=\"fa fa-trash\"></i></a>");
                            }
                            else
                            {
                                sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn3\" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>");
                            }
                        }
                    }

                    //Note
                    string NoteReplyCnt = dt.Rows[intRowBodyCount]["USR_NOTECNT"].ToString();
                    string POCreator = dt.Rows[intRowBodyCount]["NOTE_TO_USRNAME"].ToString();
                    string POCreatorId = dt.Rows[intRowBodyCount]["PRCHSORDR_INS_USR_ID"].ToString();
                    string NoteCnt = dt.Rows[intRowBodyCount]["NOTECNT"].ToString();
                    string NoteRepliedCnt = dt.Rows[intRowBodyCount]["USR_REPLYCNT"].ToString();

                    if (CancelSts == 0)
                    {
                        if (Status == 0)
                        {
                            if (Convert.ToInt32(NoteCnt) > 0 && Convert.ToInt32(NoteReplyCnt) == 0)
                            {
                                sb.Append("<a disabled href=\"javascript:;\" class=\"btn act_btn bn8 bt_v\" title=\"Note\" onclick=\"return NoteNotPossible();\"><i class=\"fa fa-file-text\"></i></i></a>");
                            }
                            else
                            {
                                if (Convert.ToInt32(NoteReplyCnt) > 0)//GiveReplyModal
                                {
                                    sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn8 bt_v\" title=\"Note\" onclick=\"return OpenModalNote('" + Id + "','" + NoteReplyCnt + "','" + POCreator + "','" + POCreatorId + "','" + NoteRepliedCnt + "');\" data-toggle=\"modal\" data-target=\"#ModalNote\"><i class=\"fa fa-file-text\"><span class=\"grn_dot\"></span></i></a>");
                                }
                                else
                                {
                                    if (Convert.ToInt32(NoteRepliedCnt) > 0)//ShowReplyNoteModal
                                    {
                                        sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn8 bt_v\" title=\"Note\" onclick=\"return OpenModalNote('" + Id + "','" + NoteReplyCnt + "','" + POCreator + "','" + POCreatorId + "','" + NoteRepliedCnt + "');\" data-toggle=\"modal\" data-target=\"#ModalNote\"><i class=\"fa fa-file-text\"><span class=\"grn_dot\"></span></i></a>");
                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(POCreatorId) != objEntity.UserId)//AddNoteModal
                                        {
                                            sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn8 bt_v\" title=\"Note\" onclick=\"return OpenModalNote('" + Id + "','" + NoteReplyCnt + "','" + POCreator + "','" + POCreatorId + "','" + NoteRepliedCnt + "');\" data-toggle=\"modal\" data-target=\"#ModalNote\"><i class=\"fa fa-file-text\"></i></i></a>");
                                        }
                                        else
                                        {
                                            sb.Append("<a disabled href=\"javascript:;\" class=\"btn act_btn bn8 bt_v\" title=\"Note\" ><i class=\"fa fa-file-text\"></i></i></a>");
                                        }
                                    }
                                }
                            }
                        }
                    }

                    //Comment
                    if (CancelSts == 0)
                    {
                        if (Status == 0)
                        {
                            int CmntCount = Convert.ToInt32(dt.Rows[intRowBodyCount]["COMMNTCNT"].ToString());
                            if (CmntCount > 0)
                            {
                                sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn9\" title=\"Comment\" onclick=\"return OpenComments('" + Id + "');\" data-toggle=\"modal\" data-target=\"#ModalComment\"><i class=\"fa fa-commenting\"></i><span class=\"badge badge-success pro_bdg\">" + dt.Rows[intRowBodyCount]["COMMNTCNT"].ToString() + "</span></a>");
                            }
                            else
                            {
                                sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn9\" title=\"Comment\" onclick=\"return OpenComments('" + Id + "');\" data-toggle=\"modal\" data-target=\"#ModalComment\"><i class=\"fa fa-commenting\"></i></a>");
                            }
                        }
                    }

                    sb.Append("</td>");
                }

                sb.Append("</tr>");
            }

        }
        else
        {
            sb.Append("<td class=\"tr_c\" colspan=\"8\">No data available in table</td>");
        }

        strReturn[0] = sbHead.ToString();
        strReturn[1] = sb.ToString();

        return strReturn;
    }


    [WebMethod]
    public static string CancelReason(string strCnclId, string strCancelMust, string strUserID, string strCancelReason, string strOrgIdID, string strCorpID)
    {
        clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
        clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successcncl";
        string strRandomMixedId = strCnclId;

        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        objEntityPurchaseOrder.PurchsOrdrId = Convert.ToInt32(strId);
        objEntityPurchaseOrder.UserId = Convert.ToInt32(strUserID);
        objEntityPurchaseOrder.OrgId = Convert.ToInt32(strOrgIdID);
        objEntityPurchaseOrder.CorpId = Convert.ToInt32(strCorpID);
        if (strCancelMust == "1")
        {
            objEntityPurchaseOrder.CancelReason = strCancelReason;
        }

        else
        {
            objEntityPurchaseOrder.CancelReason = objCommon.CancelReason();
        }

        try
        {
            objBusinessPurchaseOrder.CancelPurchaseOrder(objEntityPurchaseOrder);
        }
        catch
        {
            strRets = "failed";
        }

        return strRets;

    }

    //------------------------------------------Pagination------------------------------------------------

    [WebMethod]
    public static string[] GetData(string OrgId, string CorpId, string UserId, string ddlStatus, string CancelStatus, string Vendor, string Wrkflw, string StrtDate, string EndDate, string POType, string EnableModify, string EnableCancel, string EnableConfirm, string EnableReopen, string DefltCrncy, string PageNumber, string PageMaxSize, string strCommonSearchTerm, string OrderColumn, string OrderMethod, string strInputColumnSearch, string intcop)
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
        clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();

        clsCommonLibrary objCommon = new clsCommonLibrary();

        string[] strResults = new string[3];

        try
        {
            if (OrgId != null && OrgId != "")
            {
                objEntityPurchaseOrder.OrgId = Convert.ToInt32(OrgId);
            }
            if (CorpId != null && CorpId != "")
            {
                objEntityPurchaseOrder.CorpId = Convert.ToInt32(CorpId);
            }
            if (UserId != null && UserId != "")
            {
                objEntityPurchaseOrder.UserId = Convert.ToInt32(UserId);
            }
            objEntityPurchaseOrder.Status = Convert.ToInt32(ddlStatus);
            objEntityPurchaseOrder.CancelStatus = Convert.ToInt32(CancelStatus);
            if (Vendor != "--SELECT VENDOR--")
            {
                objEntityPurchaseOrder.VendorId = Convert.ToInt32(Vendor);
            }
            if (Wrkflw != "--SELECT DOCUMENT WORKFLOW--")
            {
                objEntityPurchaseOrder.WrkFlowId = Convert.ToInt32(Wrkflw);
            }
            if (StrtDate != "")
            {
                objEntityPurchaseOrder.StartDate = objCommon.textToDateTime(StrtDate);
            }
            if (EndDate != "")
            {
                objEntityPurchaseOrder.EndDate = objCommon.textToDateTime(EndDate);
            }
            objEntityPurchaseOrder.PurchaseOrderType = Convert.ToInt32(POType);
            objEntityPurchaseOrder.CurrencyId = Convert.ToInt32(DefltCrncy);

            objEntityPurchaseOrder.PageNumber = Convert.ToInt32(PageNumber);
            objEntityPurchaseOrder.PageMaxSize = Convert.ToInt32(PageMaxSize);
            objEntityPurchaseOrder.OrderMethod = Convert.ToInt32(OrderMethod);
            objEntityPurchaseOrder.OrderColumn = Convert.ToInt32(OrderColumn);
            objEntityPurchaseOrder.CommonSearchTerm = strCommonSearchTerm;

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

            objEntityPurchaseOrder.SearchDate = strSearchInputs[Convert.ToInt32(SearchInputColumns.DATE)];
            objEntityPurchaseOrder.SearchRef = strSearchInputs[Convert.ToInt32(SearchInputColumns.REF)];
            objEntityPurchaseOrder.SearchPOType = strSearchInputs[Convert.ToInt32(SearchInputColumns.TYPE)];
            objEntityPurchaseOrder.SearchVendor = strSearchInputs[Convert.ToInt32(SearchInputColumns.VENDOR)];
            objEntityPurchaseOrder.SearchWrkflw = strSearchInputs[Convert.ToInt32(SearchInputColumns.WRKFLOW)];
            objEntityPurchaseOrder.SearchDelvryDt = strSearchInputs[Convert.ToInt32(SearchInputColumns.DLVRYDT)];
            objEntityPurchaseOrder.SearchAmnt = strSearchInputs[Convert.ToInt32(SearchInputColumns.AMNT)];

            //ReadList
            DataTable dt = objBusinessPurchaseOrder.ReadPurchaseOrderList(objEntityPurchaseOrder);

            int intCancelStatus = Convert.ToInt32(CancelStatus);
            int intEnableModify = Convert.ToInt32(EnableModify);
            int intEnableCancel = Convert.ToInt32(EnableCancel);
            int intEnableConfirm = Convert.ToInt32(EnableConfirm);
            int intEnableReopen = Convert.ToInt32(EnableReopen);

            //for copy
            int intcopy = Convert.ToInt32(intcop);

            string[] strTableContents = new string[2];
            strTableContents = ConvertDataTableToHTML(dt, objEntityPurchaseOrder, intCancelStatus, intEnableModify, intEnableCancel, intEnableConfirm, intEnableReopen, intcopy);
            strResults[0] = strTableContents[0];
            strResults[1] = strTableContents[1];


            if (dt.Rows.Count > 0)
            {
                int intTotalItems = Convert.ToInt32(dt.Rows[0]["CNT"].ToString());
                int intCurrentRowCount = dt.Rows.Count;

                //Pagination
                strResults[2] = objBusinessLayer.GenereatePagination(intTotalItems, objEntityPurchaseOrder.PageNumber, objEntityPurchaseOrder.PageMaxSize, intCurrentRowCount);
            }
        }
        catch (Exception ex)
        {
            clsBusineesLayerException objBusinessLayerException = new clsBusineesLayerException();
            objBusinessLayerException.ExceptionHandling(ex);
            throw ex;
        }

        return strResults;
    }

    [WebMethod]
    public static string[] LoadStaticDatafordt(string CancelStatus)//Filters
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
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"DATE\" placeholder=\"DATE\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "1")
            {
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"PURCHASE ORDER#\" placeholder=\"PURCHASE ORDER#\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "2")
            {
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"PURCHASE ORDER TYPE\" placeholder=\"PURCHASE ORDER TYPE\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "3")
            {
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"VENDOR NAME\" placeholder=\"VENDOR NAME\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "4")
            {
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"DOCUMENT\" placeholder=\"DOCUMENT\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "5")
            {
                if (CancelStatus == "0")
                {
                    sbSearchInputColumns.Append("<th></th>");
                }
            }
            else if (Convert.ToInt32(item).ToString() == "6")
            {
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"EXPECTED DELIVERY DATE\" placeholder=\"EXPECTED DELIVERY DATE\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "7")
            {
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"AMOUNT\" placeholder=\"AMOUNT\"></th>");
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
        DATE = 0,
        REF = 1,
        TYPE = 2,
        VENDOR = 3,
        WRKFLOW = 4,
        STATUS = 5,
        DLVRYDT = 6,
        AMNT = 7,
    }

    //------------------------------------------Pagination------------------------------------------------

    [WebMethod]
    public static string[] LoadNoteData(string Id, string UserId, string NoteNeedReplySts, string NoteReplyViewSts)
    {
        string[] strResults = new string[8];

        clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
        clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();

        string strRandomMixedId = Id;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        objEntityPurchaseOrder.PurchsOrdrId = Convert.ToInt32(strId);
        objEntityPurchaseOrder.UserId = Convert.ToInt32(UserId);
        objEntityPurchaseOrder.ReplySts = Convert.ToInt32(NoteReplyViewSts);

        DataTable dt = objBusinessPurchaseOrder.ReadNoteDetails(objEntityPurchaseOrder);

        StringBuilder sb = new StringBuilder();
        int intAttchCnt = 0;
        if (dt.Rows.Count > 0)
        {
            DataView view = new DataView(dt);
            DataTable dtNote = view.ToTable(true, "PRCHSORDR_NOTEID", "PRCHSORDRNOTE_MSG", "REPLY_TO_USRNAME", "REPLY_TO_USRID", "REPLY_FRM_USRNAME", "REPLY_FRM_USRID", "PRCHSORDRNOTE_REPLY_MSG");

            if (NoteNeedReplySts == "1")
            {
                //---------Note----------
                //To User
                strResults[0] = dtNote.Rows[0]["REPLY_FRM_USRNAME"].ToString();
                strResults[5] = dtNote.Rows[0]["REPLY_FRM_USRID"].ToString();


                //---------Reply----------
                //From User
                strResults[1] = dtNote.Rows[0]["REPLY_TO_USRNAME"].ToString();
                strResults[6] = dtNote.Rows[0]["REPLY_TO_USRID"].ToString();
            }

            if (NoteReplyViewSts == "0")
            {
                strResults[3] = dtNote.Rows[0]["PRCHSORDRNOTE_MSG"].ToString();
                strResults[2] = dtNote.Rows[0]["PRCHSORDR_NOTEID"].ToString();
            }
            else
            {
                strResults[3] = dtNote.Rows[0]["PRCHSORDRNOTE_REPLY_MSG"].ToString();
            }

            for (int intRow = 0; intRow < dt.Rows.Count; intRow++)
            {
                if (dtNote.Rows[0]["PRCHSORDR_NOTEID"].ToString() == dt.Rows[intRow]["ATTCH_NOTEID"].ToString())
                {
                    if (dt.Rows[intRow]["PRCHSORDRATCHNT_FILENM"].ToString() != "")
                    {
                        clsCommonLibrary objCommon = new clsCommonLibrary();
                        string strFilePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.PURCHASE_ORDER_NOTE_ATTACH) + dt.Rows[intRow]["PRCHSORDRATCHNT_FILENM"].ToString();
                        sb.Append("<span class=\"attc_h\" >");
                        sb.Append("<a href=\"" + strFilePath + "\" target=\"_blank\"><i class=\"fa fa-download\" aria-hidden=\"true\"></i> " + dt.Rows[intRow]["PRCHSORDRATCHNT_FILEACTNM"].ToString() + "</a>");
                        sb.Append("</span>");
                        intAttchCnt++;
                    }
                }
            }
        }

        strResults[4] = sb.ToString();
        strResults[7] = intAttchCnt.ToString();

        return strResults;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
            clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityPurchaseOrder.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                objEntityPurchaseOrder.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            string strRandomMixedId = hiddenPurchaseOrderId.Value;
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityPurchaseOrder.PurchsOrdrId = Convert.ToInt32(strId);

            if (hiddenNoteId.Value != "")//reply
            {
                objEntityPurchaseOrder.NoteId = Convert.ToInt32(hiddenNoteId.Value);
                objEntityPurchaseOrder.ReplySts = 1;
            }
            objEntityPurchaseOrder.NoteMsg = txtMessage.Value;
            objEntityPurchaseOrder.EmployeeId = Convert.ToInt32(hiddenToUserId.Value);
            objEntityPurchaseOrder.UserId = Convert.ToInt32(hiddenFromUserId.Value);

            List<clsEntityPurchaseOrder> objEntityPurchsOrdrAttchmntList = new List<clsEntityPurchaseOrder>();
            List<clsEntityMailAttachment> objEntityMailAttachList = new List<clsEntityMailAttachment>();

            if (hiddenAttchmntDtls.Value != "" && hiddenAttchmntDtls.Value != "[]")
            {
                string jsonData = hiddenAttchmntDtls.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string k = h.Replace("}\",", "},");
                string DataValue = k;

                List<clsData> objDataList = new List<clsData>();
                objDataList = JsonConvert.DeserializeObject<List<clsData>>(DataValue);
                for (int count = 0; count < objDataList.Count; count++)
                {
                    string jsonFileid = "fileAttach" + objDataList[count].ROWID;
                    for (int intCount = 0; intCount < Request.Files.Count; intCount++)
                    {
                        string fileId = Request.Files.AllKeys[intCount].ToString();
                        HttpPostedFile PostedFile = Request.Files[intCount];
                        if (fileId == jsonFileid)
                        {
                            if (PostedFile.ContentLength > 0)
                            {
                                clsEntityPurchaseOrder objEntity = new clsEntityPurchaseOrder();

                                string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                                objEntity.ActualFileName = strFileName;
                                string strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

                                int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.PURCHASE_ORDER_NOTE_ATTACH);
                                objEntityCommon.CorporateID = objEntityPurchaseOrder.CorpId;
                                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PURCHASE_ORDER_NOTE_ATTACH);
                                string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);

                                string strImageName = "PURCHASEORDERNOTE_" + intImageSection.ToString() + "_" + count + "_" + strNextNumber + "." + strFileExt;
                                objEntity.FileName = strImageName;
                                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.PURCHASE_ORDER_NOTE_ATTACH);

                                PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntity.FileName);
                                objEntityPurchsOrdrAttchmntList.Add(objEntity);


                                clsEntityMailAttachment objEntityMailAttach = new clsEntityMailAttachment();
                                objEntityMailAttach.Attch_Path = Server.MapPath(strImagePath + objEntity.FileName);
                                objEntityMailAttachList.Add(objEntityMailAttach);
                            }

                        }
                    }

                }
            }


            objBusinessPurchaseOrder.InsertNote(objEntityPurchaseOrder, objEntityPurchsOrdrAttchmntList);

            clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
            List<clsEntityMailCcBCc> objEntityMailCcBCcList = new List<clsEntityMailCcBCc>();
            List<classEntityToMailAddress> objEntityToMailAddressList = new List<classEntityToMailAddress>();

            clsEntityLayerUserRegistration objEntityUser = new clsEntityLayerUserRegistration();
            clsBusinessLayerUserRegisteration objBusinessUser = new clsBusinessLayerUserRegisteration();

            objEntityUser.UsrRegistrationId = objEntityPurchaseOrder.EmployeeId;
            DataTable dtEmp = objBusinessUser.ReadUsrMasterEdit(objEntityUser);
            string strToMail = "", strToName = "";
            if (dtEmp.Rows.Count > 0)
            {
                strToMail = dtEmp.Rows[0]["USR_EMAIL"].ToString();
                strToName = dtEmp.Rows[0]["USR_NAME"].ToString();
            }
            strToMail = "projectlead.democompany@gmail.com";

            objEntityUser.UsrRegistrationId = objEntityPurchaseOrder.UserId;
            DataTable dtUser = objBusinessUser.ReadUsrMasterEdit(objEntityUser);
            string strFromMail = "", strFromName = "";
            if (dtUser.Rows.Count > 0)
            {
                strFromMail = dtUser.Rows[0]["USR_EMAIL"].ToString();
                strFromName = dtUser.Rows[0]["USR_NAME"].ToString();
            }

            clsEntityPurchaseOrder objEntitySub = new clsEntityPurchaseOrder();
            objEntitySub.PurchsOrdrId = objEntityPurchaseOrder.PurchsOrdrId;
            if (objEntityPurchaseOrder.ReplySts == 0)
            {
                objEntitySub.UserId = objEntityPurchaseOrder.EmployeeId;
            }
            else
            {
                objEntitySub.UserId = objEntityPurchaseOrder.UserId;
            }
            objEntitySub.ReplySts = 0;
            DataTable dt = objBusinessPurchaseOrder.ReadNoteDetails(objEntitySub);
            string strMsg = "", strRef = "";
            if (dt.Rows.Count > 0)
            {
                strMsg = dt.Rows[0]["PRCHSORDRNOTE_MSG"].ToString();
                strRef = dt.Rows[0]["PRCHSORDR_REF"].ToString();
            }

            string strEmailSubject = "Note";
            if (objEntityPurchaseOrder.ReplySts == 1)
            {
                strEmailSubject = "Reply Note";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("Dear " + strToName + ",");
            if (objEntityPurchaseOrder.ReplySts == 0)
            {
                sb.Append("<br/><br/>This email is to notify you that a note has been created by " + strFromName + " against the purchase order Ref# " + strRef + ".");
            }
            else
            {
                sb.Append("<br/><br/>This email is to notify you that a reply note has been provided by " + strFromName + " for the note created against the purchase order Ref# " + strRef + ".");
            }
            sb.Append("<br/><br/>");
            if (objEntityPurchaseOrder.ReplySts == 0)
            {
                sb.Append("<b>Message</b> : " + objEntityPurchaseOrder.NoteMsg);
            }
            else
            {
                sb.Append("<b>Reply Message</b> : " + objEntityPurchaseOrder.NoteMsg);
            }

            if (objEntityMailAttachList.Count > 0)
            {
                sb.Append("Please find the attachments sent along with this mail.");
            }

            if (objEntityPurchaseOrder.ReplySts == 0)
            {
                sb.Append("<br/>Please reply to the note as soon as possible.");
            }

            string strEmailContent = sb.ToString();

            if (strToMail != "")
            {
                //SendMail(strToMail, strEmailSubject, strEmailContent, objEntityMail, objEntityMailAttachList, objEntityMailCcBCcList, objEntityToMailAddressList);
            }

            if (hiddenNoteId.Value != "")//reply
            {
                Response.Redirect("pms_Purchase_Order_List.aspx?InsUpd=NoteReply");
            }
            else
            {
                Response.Redirect("pms_Purchase_Order_List.aspx?InsUpd=Note");
            }
        }
        catch (Exception ex)
        {

        }
    }

    public class clsData
    {
        public string ROWID { get; set; }
        public string EVTACTION { get; set; }
        public string REPLYSTS { get; set; }
    }

    [WebMethod]
    public static string LoadStatus(string CorpId, string Id, string CurrencyId, string CurrencyAbrv)
    {
        string strReturn = "";

        clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
        clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();

        string strRandomMixedId = Id;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        objEntityPurchaseOrder.CorpId = Convert.ToInt32(CorpId);
        objEntityPurchaseOrder.PurchsOrdrId = Convert.ToInt32(strId);

        DataTable dt = objBusinessPurchaseOrder.ReadStatusDtls(objEntityPurchaseOrder);

        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        objEntityCommon.CurrencyId = Convert.ToInt32(CurrencyId);

        StringBuilder sb = new StringBuilder();
        for (int intRow = 0; intRow < dt.Rows.Count; intRow++)
        {
            string strNetAmountWithComma = objBusinessLayer.AddCommasForNumberSeperation(dt.Rows[intRow]["PRCHSORDR_NET_TOTAL"].ToString(), objEntityCommon);

            if (dt.Rows[intRow]["STS"].ToString() == "1")//note
            {
                if (intRow % 2 == 0)
                {
                    sb.Append("<div class=\"conta_r1 left1 not1\">");
                }
                else
                {
                    sb.Append("<div class=\"conta_r1 right1 not1\">");
                }
            }
            else
            {
                if (intRow % 2 == 0)
                {
                    sb.Append("<div class=\"conta_r1 left1\">");
                }
                else
                {
                    sb.Append("<div class=\"conta_r1 right1\">");
                }
            }

            sb.Append("<div class=\"cont_t1\">");

            string strHead = "";
            if (dt.Rows[intRow]["STS"].ToString() == "1")//note
            {
                if (dt.Rows[intRow]["APRVLCNSLFLT_APRVLSTS"].ToString() == "0")
                {
                    strHead = "Note added by ";
                }
                else
                {
                    if (dt.Rows[intRow]["APRVLCNSLFLT_STS"].ToString() == "1")
                    {
                        strHead = "Replied to note by ";
                    }
                    else
                    {
                        strHead = "Reply to note required from ";
                    }
                }
            }
            else
            {
                if (dt.Rows[intRow]["APRVLCNSLFLT_APRVLSTS"].ToString() == "0")
                {
                    if (dt.Rows[intRow]["APRVLCNSLFLT_LEVEL"].ToString() == "")
                    {
                        if (dt.Rows[intRow]["APRVLCNSLFLT_STS"].ToString() == "0")
                        {
                            strHead = "Purchase order created for " + strNetAmountWithComma + " " + CurrencyAbrv + " by";
                        }
                        else
                        {
                            strHead = "Purchase order confirmed by ";
                        }
                    }
                    else
                    {
                        strHead = "Approval required from ";
                    }
                }
                else if (dt.Rows[intRow]["APRVLCNSLFLT_APRVLSTS"].ToString() == "1")
                {
                    strHead = "Approved by ";
                }
                else if (dt.Rows[intRow]["APRVLCNSLFLT_APRVLSTS"].ToString() == "2")
                {
                    strHead = "Rejected by ";
                }
            }

            sb.Append("<h4>" + strHead + "</h4>");
            sb.Append("<p>" + dt.Rows[intRow]["USR_NAME"].ToString() + "</p>");
            sb.Append("<span>" + dt.Rows[intRow]["DATEVAL"].ToString() + "</span>");
            sb.Append("</div>");
            sb.Append("</div>");
        }
        strReturn = sb.ToString();

        return strReturn;
    }


    [WebMethod]
    public static string[] LoadComments(string Id, string UserId)
    {
        string[] strReturn = new string[3];

        clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
        clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();

        string strRandomMixedId = Id;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        objEntityPurchaseOrder.PurchsOrdrId = Convert.ToInt32(strId);

        DataTable dt = objBusinessPurchaseOrder.ReadCommentDtls(objEntityPurchaseOrder);

        int CmntCnt = 0;
        StringBuilder sb = new StringBuilder();
        StringBuilder sbCmnt = new StringBuilder();
        for (int intRow = 0; intRow < dt.Rows.Count; intRow++)
        {
            if ((dt.Rows[intRow]["PRCHSORDRCMNT_VISBLSTS"].ToString() == "0") || (dt.Rows[intRow]["PRCHSORDRCMNT_VISBLSTS"].ToString() == "1" && dt.Rows[intRow]["PRCHSORDRCMNT_INS_USR_ID"].ToString() == UserId))
            {
                sb.Append("<div class=\"evt\">");
                sb.Append("<div class=\"inq\">");
                sb.Append("<span class=\"datep\"><i class=\"fa fa-commenting\" aria-hidden=\"true\"></i></span>");
                sb.Append("<p class=\"data\">" + dt.Rows[intRow]["PRCHSORDRCMNT_INS_DATE"].ToString() + "</p>");
                sb.Append("</div>");
                sb.Append("</div>");

                sbCmnt.Append("<div class=\"evt2\">");
                sbCmnt.Append("<h2>" + dt.Rows[intRow]["PRCHSORDRCMNT_COMMENT"].ToString() + "<span class=\"sbf\"> by " + dt.Rows[intRow]["USR_NAME"].ToString() + "</span></h2>");
                sbCmnt.Append("</div>");
                CmntCnt++;
            }
        }
        strReturn[0] = sb.ToString();
        strReturn[1] = sbCmnt.ToString();
        strReturn[2] = CmntCnt.ToString();

        return strReturn;
    }

    protected void btnCmntSubmit_Click(object sender, EventArgs e)
    {
        clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
        clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPurchaseOrder.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityPurchaseOrder.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityPurchaseOrder.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        string strRandomMixedId = hiddenPurchaseOrderId.Value;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        objEntityPurchaseOrder.PurchsOrdrId = Convert.ToInt32(strId);
        objEntityPurchaseOrder.Comment = txtComment.Value;
        objEntityPurchaseOrder.VisibleSts = Convert.ToInt32(ddlVisibilitySts.SelectedItem.Value);

        objBusinessPurchaseOrder.InsertComments(objEntityPurchaseOrder);

        Response.Redirect("pms_Purchase_Order_List.aspx?InsUpd=Cmnt");
    }

    public void SendMail(string strToMail, string strEmailSubject, string strEmailContent, clsEntityMailConsole objEntityMail, List<clsEntityMailAttachment> objEntityMailAttachList, List<clsEntityMailCcBCc> objEntityMailCcBCcList, List<classEntityToMailAddress> objEntityToMailAddressList)
    {
        MailUtility_ERP.clsMail objMail = new MailUtility_ERP.clsMail();

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityLayerUserRegistration objEntityUserReg = new clsEntityLayerUserRegistration();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityUserReg.UserCrprtId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtFromMail = objBusinessLayer.ReadFromMailDetails(objEntityUserReg);

        objEntityMail.From_Email_Address = dtFromMail.Rows[0]["MLCNFG_EMAIL"].ToString();
        objEntityMail.Out_Service_Name = dtFromMail.Rows[0]["MLCNFG_OUT_SERVICE_NAME"].ToString();
        objEntityMail.Out_Port_Number = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_OUT_PORT_NUMBER"]);
        objEntityMail.SSL_Status = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_SSL_STATUS"]);
        objEntityMail.Password = dtFromMail.Rows[0]["MLCNFG_PASSWORD"].ToString();
        objEntityMail.D_Date = System.DateTime.Now;

        objEntityMail.To_Email_Address = strToMail;
        objEntityMail.Email_Subject = strEmailSubject;
        objEntityMail.Email_Content = strEmailContent;

        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon ObjEntityCommon = new clsEntityCommon();
        clsBusinessLayer objDataCommon = new clsBusinessLayer();

        ObjEntityCommon.CorporateID = Convert.ToInt32(HttpContext.Current.Session["CORPOFFICEID"].ToString());
        ObjEntityCommon.Organisation_Id = Convert.ToInt32(HttpContext.Current.Session["ORGID"].ToString());
        DataTable dtCorp = objDataCommon.ReadCorpDetails(ObjEntityCommon);
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyMobile = "", strCompanyPhone = "";
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
            strCompanyMobile = dtCorp.Rows[0]["CORPRT_MOBILE"].ToString();
            strCompanyPhone = dtCorp.Rows[0]["CORPRT_PHONE"].ToString();
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

        StringBuilder sb = new StringBuilder();

        sb.Append("<br/><br/><br/><b><u>NOTE</u></b>: <i>This is system generated email. Kindly do not reply to this email address. For any queries/feedback, please email to itsupport@albaalagh.com</i>");
        sb.Append("<br/><br/><br/>Best Regards,");
        sb.Append("<br/><font color=\"#0a409b\"><b>Admin Department</b></font><br/><font color=\"#438df8\">democlient Trading and Contracting Co. WLL </font><br/><font color=\"#438df8\">T: +974 44667714/15/16<br/>P O Box 5777, Doha - Qatar</font>");
        //sb.Append("<br/><br/><br/><b><u>NOTE</u></b>: <i>This is system generated email. Kindly do not reply to this email address. For any queries/feedback, please email to itsupport@albaalagh.com</i>");
        //sb.Append("<br/><br/><br/>Best Regards,");
        //sb.Append("<br/><font color=\"#0a409b\"><b>Admin Department</b></font><br/><font color=\"#438df8\">" + strCompanyName + "</font><br/><font color=\"#438df8\">T: " + strCompanyMobile + "<br/>" + strAddress + "</font>");

        objEntityMail.Signature = sb.ToString();

        objMail.SendMailAsHtml(objEntityMail, objEntityMailAttachList, objEntityMailCcBCcList, objEntityToMailAddressList);
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


    [WebMethod]
    public static string PrintList(string orgID, string corptID, string CnclSts, string statusid,string purchase,string venid,string docid,string vendor,string doc, string from, string toDt)
    {
        string strReturn = "";

        clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
        clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();
        clsBusinessLayer objBusinesslayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityPurchaseOrder.OrgId = Convert.ToInt32(orgID);

        objEntityPurchaseOrder.CorpId = Convert.ToInt32(corptID);
        objEntityPurchaseOrder.CancelStatus = Convert.ToInt32(CnclSts);
        if (vendor != "")
        {
            objEntityPurchaseOrder.VendorId = Convert.ToInt32(venid);
        }
        if (doc != "")
        {
            objEntityPurchaseOrder.WrkFlowId = Convert.ToInt32(docid);
        }
        if (from != "")
        {
            objEntityPurchaseOrder.StartDate = objCommon.textToDateTime(from);
        }
        if (toDt!= "")
        {
            objEntityPurchaseOrder.EndDate = objCommon.textToDateTime(toDt);
        }
        objEntityPurchaseOrder.PurchaseOrderType = Convert.ToInt32(purchase);
        int intCorpId = 0;
        if (corptID != "")
            intCorpId = Convert.ToInt32(corptID);


        objEntityPurchaseOrder.Status = Convert.ToInt32(statusid);


        DataTable dtCategory = objBusinessPurchaseOrder.ReadPurchaseOrderList(objEntityPurchaseOrder);
        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.PURCHASE_ORDER_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PURCHASE_ORDER_PDF);
        objEntityCommon.CorporateID = objEntityPurchaseOrder.CorpId;
        objEntityCommon.Organisation_Id = objEntityPurchaseOrder.OrgId;
        string strNextNumber = objBusinesslayer.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "purchaseorderlist_" + strNextNumber + ".pdf";

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

              

                footrtable.AddCell(new PdfPCell(new Phrase("PURCHASE ORDER TYPE  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (purchase == "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("All", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                else if( purchase == "1")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Products", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2});
                }
                else if (purchase == "2")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Car Rental", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }


                else 
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Air Ticket", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }

                if (vendor != "")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("VENDOR  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(vendor, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }

                if(from!="")
                { 
                footrtable.AddCell(new PdfPCell(new Phrase("FROM DATE     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(from, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if(toDt!="")
                { 
                    footrtable.AddCell(new PdfPCell(new Phrase("TO DATE     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(toDt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (doc != "")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("DOCUMENT WORKFLOW  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(doc, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                footrtable.AddCell(new PdfPCell(new Phrase("STATUS ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (statusid == "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Pending", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else if (statusid == "1")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Confirmed", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else if (statusid == "2")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Reopened", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("All", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });

                }
                document.Add(footrtable);

                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(8);
                float[] footrsBody = { 14, 18, 14, 10, 17, 15, 12,12 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("DATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("PURCHASE ORDER", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("PURCHASE ORDER TYPE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("VENDOR NAME", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("DOCUMENT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("STATUS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("EXPECTED DELIVERY DATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("AMOUNT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                
                

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
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["PRCHSORDR_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["PRCHSORDR_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                          TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["PO_TYP"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["SUPLIR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["WRKFLW_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                       string Statusids =dtCategory.Rows[intRowBodyCount]["PRCHSORDR_CONFRM_STS"].ToString();

                       if (Statusids == "0")//Pending
                        {

                            if (dtCategory.Rows[intRowBodyCount]["PRCHSORDR_REOPN_USR_ID"].ToString() == "")
                            {
                                TBCustomer.AddCell(new PdfPCell(new Phrase("Pending", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            }
                            else
                            {
                                TBCustomer.AddCell(new PdfPCell(new Phrase("Reopened", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            }

                        }
                        else if (Statusids =="1")//Confirmed
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase("Confirmed", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                        }
                    

                       TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["PRCHSORDR_DLVRYDT"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                       TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["PRCHSORDR_NET_TOTAL"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                

                    }
                    // TBCustomer.AddCell(new PdfPCell(new Phrase(strStatusImg, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


                }

                else
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase("No data available in table", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 8 });

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
            headtable.AddCell(new PdfPCell(new Phrase("PURCHASE ORDER LIST ", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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
    public static string PrintCSV(string orgID, string corptID, string CnclSts, string statusid, string purchase, string venid, string docid, string vendor, string doc, string from, string toDt)
    {
        string strReturn = "";
        clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
        clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();
        clsBusinessLayer objBusinesslayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        PMS_PMS_Master_pms_Purchase_Order_pms_Purchase_Order_List OBJ = new PMS_PMS_Master_pms_Purchase_Order_pms_Purchase_Order_List();
        objEntityPurchaseOrder.OrgId = Convert.ToInt32(orgID);

        objEntityPurchaseOrder.CorpId = Convert.ToInt32(corptID);
        objEntityPurchaseOrder.CancelStatus = Convert.ToInt32(CnclSts);
        if (vendor != "")
        {
            objEntityPurchaseOrder.VendorId = Convert.ToInt32(venid);
        }
        if (doc != "")
        {
            objEntityPurchaseOrder.WrkFlowId = Convert.ToInt32(docid);
        }
        if (from != "")
        {
            objEntityPurchaseOrder.StartDate = objCommon.textToDateTime(from);
        }
        if (toDt != "")
        {
            objEntityPurchaseOrder.EndDate = objCommon.textToDateTime(toDt);
        }
        objEntityPurchaseOrder.PurchaseOrderType = Convert.ToInt32(purchase);
        int intCorpId = 0;
        if (corptID != "")
            intCorpId = Convert.ToInt32(corptID);


        objEntityPurchaseOrder.Status = Convert.ToInt32(statusid);


        DataTable dtCategory = objBusinessPurchaseOrder.ReadPurchaseOrderList(objEntityPurchaseOrder);

        strReturn = OBJ.LoadTable_CSV(dtCategory, objEntityPurchaseOrder, CnclSts, statusid,purchase,venid,docid,vendor,doc,from,toDt);
        return strReturn;
    }
    public string LoadTable_CSV(DataTable dtCategory, clsEntityPurchaseOrder objEntityPurchaseOrder, string CnclSts, string statusid, string purchase, string venid, string docid, string vendor, string doc, string from, string toDt)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dt = GetTable(dtCategory, objEntityPurchaseOrder, CnclSts, statusid, purchase, venid, docid, vendor, doc, from, toDt);
        string strResult = DataTableToCSV(dt, ',');
        string strImagePath = "";
        string filepath = "";
        if (objEntityPurchaseOrder.CorpId != 0)
        {
            objEntityCommon.CorporateID = objEntityPurchaseOrder.CorpId;
        }
        if (objEntityPurchaseOrder.OrgId != 0)
        {
            objEntityCommon.Organisation_Id = objEntityPurchaseOrder.OrgId;
        }
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PURCHASE_ORDER_CSV);
        string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
        string newFilePath = Server.MapPath("/CustomFiles/PMS_CSV/Purchase_order/PurchaseorderList_" + strNextId + ".csv");
        System.IO.File.WriteAllText(newFilePath, strResult);
        filepath = "PurchaseorderList_" + strNextId + ".csv";
        strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.PURCHASE_ORDER_CSV);
        return strImagePath + filepath;
    }
    public DataTable GetTable(DataTable dtCategory, clsEntityPurchaseOrder objEntityPurchaseOrder, string CnclSts, string statusid, string purchase, string venid, string docid, string vendor, string doc, string from, string toDt)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,                                                           
                                                      clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,    
                                                              };
        int intCorpId = 0;
        if (objEntityPurchaseOrder.CorpId != 0)
        {
            intCorpId = objEntityPurchaseOrder.CorpId;
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
        table.Columns.Add("PURCHASE ORDER LIST", typeof(string));
        table.Columns.Add(" ", typeof(string));
        table.Columns.Add("  ", typeof(string));
        table.Columns.Add("   ", typeof(string));
        table.Columns.Add("    ", typeof(string));
        table.Columns.Add("     ", typeof(string));
        table.Columns.Add("      ", typeof(string));
        table.Columns.Add("       ", typeof(string));

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"','"'+FORNULL+'"');
     
            if (purchase == "0")
        {
            table.Rows.Add("PURCHASE ORDER TYPE  :", "All", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');


        }
        else if (purchase == "1")
        {
            table.Rows.Add("PURCHASE ORDER TYPE  :", "Products", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        else if (purchase == "2")
        {
            table.Rows.Add("PURCHASE ORDER TYPE  :", "Car Rental", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }


        else
        {
            table.Rows.Add("PURCHASE ORDER TYPE  :", "Air Ticket", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }




            if (vendor != "")
            {

                table.Rows.Add("VENDOR :", '"' + vendor + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
   }


            if (from != "")
            {
                table.Rows.Add("FROM DATE :", '"' + from + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
            }

            if (toDt != "")
            {
                table.Rows.Add("TO DATE :", '"' + toDt + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
            }
            if (doc != "")
            {
                table.Rows.Add("DOCUMENT WORKFLOW  :", '"' + doc + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
  }

if (statusid == "0")
            {
                table.Rows.Add("PURCHASE ORDER STATUS  :", "Pending", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

            }
            else if (statusid == "1")
            {
                table.Rows.Add("PURCHASE ORDER STATUS  :", "Confirmed", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
            }
            else if (statusid == "2")
            {
                table.Rows.Add("PURCHASE ORDER STATUS  :", "Reopened", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
            }
            else
            {
                table.Rows.Add("PURCHASE ORDER STATUS  :", "All", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

            }


table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');


table.Rows.Add("DATE", "PURCHASE ORDER", "PURCHASE ORDER TYPE", "VENDOR NAME", "DOCUMENT", "STATUS", "EXPECTED DELIVERY DATE","AMOUNT");

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
                string Statusids = dtCategory.Rows[intRowBodyCount]["PRCHSORDR_CONFRM_STS"].ToString();
                string statusImg="";
                if (Statusids == "0")//Pending
                {
                    if (dtCategory.Rows[intRowBodyCount]["PRCHSORDR_REOPN_USR_ID"].ToString() == "")
                    {
                        statusImg = "Pending";
                    }
                    else
                    {
                        statusImg = "Reopened";
                    }
                    
                }
                else if (Statusids == "1")//Confirmed
                {
                    statusImg="Confirmed";

                }
               

                table.Rows.Add('"' + dtCategory.Rows[intRowBodyCount]["PRCHSORDR_DATE"].ToString() + '"', '"' + dtCategory.Rows[intRowBodyCount]["PRCHSORDR_REF"].ToString() + '"', '"' +dtCategory.Rows[intRowBodyCount]["PO_TYP"].ToString()+ '"','"'+dtCategory.Rows[intRowBodyCount]["SUPLIR_NAME"].ToString()+'"','"'+dtCategory.Rows[intRowBodyCount]["WRKFLW_NAME"].ToString()+'"','"'+statusImg+'"','"'+dtCategory.Rows[intRowBodyCount]["PRCHSORDR_DLVRYDT"].ToString()+'"','"'+dtCategory.Rows[intRowBodyCount]["PRCHSORDR_NET_TOTAL"].ToString()+'"');

            }

        }
        else
        {
            table.Rows.Add(" No data available in table", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
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