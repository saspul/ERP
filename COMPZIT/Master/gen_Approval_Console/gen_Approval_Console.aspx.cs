using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using EL_Compzit;
using BL_Compzit;
using CL_Compzit;
using System.Web.Services;
using Newtonsoft.Json;
using EL_Compzit.EntityLayer_PMS;
using BL_Compzit.BusinessLayer_PMS;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web.Script.Serialization;
using System.IO;
public partial class Master_gen_Approval_Console_gen_Approval_Console : System.Web.UI.Page
{
    clsEntityApprovalConsole objEntityApprvlCnsl = new clsEntityApprovalConsole();
    clsBusinessLayerApprovalConsole objBusinessApprvlCnsl = new clsBusinessLayerApprovalConsole();

    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
    clsEntityCommon objEntityCommon = new clsEntityCommon();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int intUserId = 0;
            if (Session["USERID"] != null)
            {
                objEntityApprvlCnsl.UserId = Convert.ToInt32(Session["USERID"]);
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityApprvlCnsl.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                objEntityApprvlCnsl.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            this.Form.Enctype = "multipart/form-data";

            LoadDocuments();

            int intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.ApprovalConsole);
            int intEnableHold = 0;
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.OnHold).ToString())
                    {
                        intEnableHold = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                }
            }

            hiddenEnableHold.Value = intEnableHold.ToString();

            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();

            clsEntityLayerUserRegistration objEntityUser = new clsEntityLayerUserRegistration();
            clsBusinessLayerUserRegisteration objBusinessUser = new clsBusinessLayerUserRegisteration();

            objEntityUser.UsrRegistrationId = objEntityApprvlCnsl.UserId;

            DataTable dtEmp = objBusinessUser.ReadUsrMasterEdit(objEntityUser);
            if (dtEmp.Rows.Count > 0)
            {
                string strId = dtEmp.Rows[0]["DSGN_ID"].ToString();
                int intIdLength = dtEmp.Rows[0]["DSGN_ID"].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                hiddenDesgnation.Value = Id;
            }


            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Aprvd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessApproval", "SuccessApproval();", true);
                }
                else if (strInsUpd == "Rejct")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessRejection", "SuccessRejection();", true);
                }
                else if (strInsUpd == "Hold")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessOnHold", "SuccessOnHold();", true);
                }
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
                else if (strInsUpd == "Note")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessNote", "SuccessNote();", true);
                }
                else if (strInsUpd == "NoteReply")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessNoteReply", "SuccessNoteReply();", true);
                }
                else if (strInsUpd == "Cmnt")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessComment", "SuccessComment();", true);
                }
                else if (strInsUpd == "Addtnl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessAddtnlDtls", "SuccessAddtnlDtls();", true);
                }
                else if (strInsUpd == "AddtnlReply")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessAddtnlDtlsReply", "SuccessAddtnlDtlsReply();", true);
                }
                else if (strInsUpd == "Delgt")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessDelegateDtls", "SuccessDelegateDtls();", true);
                }
            }

            ddlDocumentTyp.Focus();
        }
    }

    public void LoadDocuments()
    {
        DataTable dt = objBusinessApprvlCnsl.ReadDocuments();

        ddlDocumentTyp.Items.Clear();
        if (dt.Rows.Count > 0)
        {
            ddlDocumentTyp.DataSource = dt;
            ddlDocumentTyp.DataTextField = "DOC_NAME";
            ddlDocumentTyp.DataValueField = "DOC_ID";
            ddlDocumentTyp.DataBind();
        }
        ddlDocumentTyp.Items.Insert(0, "--SELECT DOCUMENT--");
    }

    public static string[] ConvertDataTableToHTML(DataTable dt, clsEntityApprovalConsole objEntity, int intEnableHold, string ddlStatus)
    {
        string[] strReturn = new string[2];

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        StringBuilder sbHead = new StringBuilder();
        StringBuilder sb = new StringBuilder();

        int NoteSts = 0;
        DataRow[] foundAuthors = dt.Select("TYPE_STATUS = '" + 1 + "'");
        if (foundAuthors.Length != 0)
        {
            NoteSts++;
        }

        int AddtnSts = 0;
        DataRow[] foundAuthors2 = dt.Select("TYPE_STATUS = '" + 2 + "'");
        if (foundAuthors2.Length != 0)
        {
            AddtnSts++;
        }

        if (ddlStatus == "0" && NoteSts == 0 && AddtnSts == 0)
        {
            sbHead.Append("<th class=\"th_b5\"><input id=\"cbxAll\" type=\"checkbox\" onchange=\"ChangeCheckAll();\" onkeypress=\"return DisableEnter(event);\" onkeydown=\"return DisableEnter(event);\" /></th>");
        }
        else
        {
            sbHead.Append("<th class=\"th_b5\"><input id=\"cbxAll\" type=\"checkbox\" disabled onkeypress=\"return DisableEnter(event);\" onkeydown=\"return DisableEnter(event);\" /></th>");
        }
        sbHead.Append("<th id=\"tdColumnHead_1\" onclick=\"SetOrderByValue(1)\" class=\"sorting th_b8 tr_l\" style=\"word-wrap:break-word;\">Ref#<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbHead.Append("<th id=\"tdColumnHead_2\" onclick=\"SetOrderByValue(2)\" class=\"sorting th_b4 tr_l\" style=\"word-wrap:break-word;\">Entity<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbHead.Append("<th id=\"tdColumnHead_3\" onclick=\"SetOrderByValue(3)\" class=\"sorting th_b4 tr_l\" style=\"word-wrap:break-word;\">Document Section<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbHead.Append("<th id=\"tdColumnHead_4\" onclick=\"SetOrderByValue(4)\" class=\"sorting th_b7\" style=\"word-wrap:break-word;\">Requested Date<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbHead.Append("<th id=\"tdColumnHead_5\" onclick=\"SetOrderByValue(5)\" class=\"sorting th_b8 tr_l\" style=\"word-wrap:break-word;\">Requestor<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbHead.Append("<th class=\"th_b5\" style=\"word-wrap:break-word;\">Status</th>");
        sbHead.Append("<th class=\"th_b1\" style=\"word-wrap:break-word;\">Priority</th>");
        sbHead.Append("<th class=\"th_b6 tr_l\" style=\"word-wrap:break-word;\">Importance</th>");
        if (ddlStatus == "0" || ddlStatus == "3")
        {
            sbHead.Append("<th class=\"th_b7\" style=\"word-wrap:break-word;\">Threshold Period</th>");
        }
        sbHead.Append("<th class=\"col-md-2\" style=\"word-wrap:break-word;\">Actions</th>");


        if (dt.Rows.Count > 0)
        {

            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                sb.Append("<tr>");

                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                string strCnslId = dt.Rows[intRowBodyCount]["APRVLCNSL_ID"].ToString();
                int intIdLengthCnsl = dt.Rows[intRowBodyCount]["APRVLCNSL_ID"].ToString().Length;
                string stridLengthCnsl = intIdLengthCnsl.ToString("00");
                string CnslId = stridLengthCnsl + strCnslId + strRandom;

                string strPrchsDate = dt.Rows[intRowBodyCount]["PRCHSORDR_DATE"].ToString();
                string strInsertDate = dt.Rows[intRowBodyCount]["APRVLCNSL_INS_DATE"].ToString();
                string strReqstDate = dt.Rows[intRowBodyCount]["REQUEST_DATE"].ToString();
                int Status = Convert.ToInt32(dt.Rows[intRowBodyCount]["APRVLCNSL_APRVLSTS"].ToString());

                int HoldUser = 0;
                if (dt.Rows[intRowBodyCount]["APRVLCNSL_HOLD_USR_ID"].ToString() != "")
                {
                    HoldUser = Convert.ToInt32(dt.Rows[intRowBodyCount]["APRVLCNSL_HOLD_USR_ID"].ToString());
                }

                if ((HoldUser == 0) || (Status == 0 && HoldUser != 0 && HoldUser == objEntity.UserId))
                {
                    if (ddlStatus == "0" && dt.Rows[intRowBodyCount]["TYPE_STATUS"].ToString() == "0")
                    {
                        sb.Append("<td class=\"tr_c\"><input id=\"cbxPrchs_" + Id + "\" type=\"checkbox\" class=\"Chkcls\" onchange=\"ChangeCheckAll();\" onkeypress=\"return DisableEnter(event);\" onkeydown=\"return DisableEnter(event);\" /></td>");
                    }
                    else
                    {
                        sb.Append("<td class=\"tr_c\"><input id=\"cbxPrchs_" + Id + "\" type=\"checkbox\" disabled class=\"Chkcls\" onkeypress=\"return DisableEnter(event);\" onkeydown=\"return DisableEnter(event);\" /></td>");
                    }
                }
                else
                {
                    sb.Append("<td class=\"tr_c\"><input id=\"cbxPrchs_" + Id + "\" type=\"checkbox\" disabled class=\"Chkcls\" onkeypress=\"return DisableEnter(event);\" onkeydown=\"return DisableEnter(event);\" /></td>");
                }

                sb.Append("<td id=\"tdRef" + Id + "\" class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount]["PRCHSORDR_REF"].ToString() + "</td>");
                sb.Append("<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount]["WRKFLW_NAME"].ToString() + "</td>");
                sb.Append("<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount]["DOC_NAME"].ToString() + "</td>");
                sb.Append("<td class=\"tr_c\" style=\"word-break: break-all; word-wrap:break-word;\" >" + strInsertDate + "</td>");
                sb.Append("<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount]["USR_NAME_CODE"].ToString() + "</td>");

                if (dt.Rows[intRowBodyCount]["TYPE_STATUS"].ToString() == "0")
                {
                    if (Status == 0)//Pending
                    {
                        sb.Append("<td><button class=\"btn tab_but1 butn2\" onclick=\"return false;\">Pending</button></td>");
                    }
                    else if (Status == 1)//Approved
                    {
                        sb.Append("<td><button class=\"btn tab_but1 butn1\" onclick=\"return false;\">Approved</button></td>");
                    }
                    else if (Status == 2)//Rejected
                    {
                        sb.Append("<td><button class=\"btn tab_but1 butn4\" onclick=\"return false;\">Rejected</button></td>");
                    }
                }
                else if (dt.Rows[intRowBodyCount]["TYPE_STATUS"].ToString() == "1")
                {
                    sb.Append("<td><button class=\"btn tab_but1 butn3\" onclick=\"return false;\">Note</button></td>");
                }
                else if (dt.Rows[intRowBodyCount]["TYPE_STATUS"].ToString() == "2")
                {
                    sb.Append("<td><button class=\"btn tab_but1 butn3\" onclick=\"return false;\">Additional Details</button></td>");
                }

                sb.Append("<td class=\"tr_c\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount]["WRKFLW_PRIORTY"].ToString() + "</td>");
                sb.Append("<td class=\"tr_c\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount]["PRCHSORDR_IMPORTNC"].ToString() + "</td>");

                clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                clsEntityCommon objEntityCommon = new clsEntityCommon();

                int ThresholdSts = Convert.ToInt32(dt.Rows[intRowBodyCount]["WRKFLWFLT_THRSHOLD_PRD_STS"].ToString());
                int Threshold = Convert.ToInt32(dt.Rows[intRowBodyCount]["WRKFLWFLT_THRSHOLD_PERIOD"].ToString());

                DateTime DateVal = objCommon.textWithTimeToDateTime(strReqstDate);
                DateTime Today = objBusinessLayer.LoadCurrentDate();

                decimal decThreshold = Convert.ToDecimal(Threshold);
                decimal decRemainDaysHrs = 0;

                if (dt.Rows[intRowBodyCount]["TYPE_STATUS"].ToString() == "0")
                {
                    if (ThresholdSts == 1)//Hours
                    {
                        DateTime HourNew = DateVal.AddHours(Threshold);
                        decRemainDaysHrs = Convert.ToDecimal((HourNew - Today).TotalHours);
                    }
                    else //Days
                    {
                        DateTime DateNew = DateVal.AddDays(Threshold);
                        decRemainDaysHrs = Convert.ToDecimal((DateNew - Today).TotalDays);
                    }

                    decimal decRemainDaysPrcnt = 100 - ((decRemainDaysHrs / decThreshold) * 100);
                    decimal RemainDaysPrcnt = Math.Round(decRemainDaysPrcnt);

                    if (RemainDaysPrcnt < 0)
                        RemainDaysPrcnt = 0;
                    if (RemainDaysPrcnt > 100)
                        RemainDaysPrcnt = 100;

                    if (ddlStatus == "0" || ddlStatus == "3")
                    {
                        sb.Append("<td>");
                        if (Status == 0)
                        {
                            if (RemainDaysPrcnt >= 0 && RemainDaysPrcnt < 35)
                            {
                                sb.Append("<div class=\"progress pink\"><span class=\"progress-left\"><span class=\"progress-bar\"></span></span><span class=\"progress-right\"><span class=\"progress-bar\"></span></span><div class=\"progress-value\">" + RemainDaysPrcnt + "%</div>");
                            }
                            if (RemainDaysPrcnt >= 35 && RemainDaysPrcnt < 50)
                            {
                                sb.Append("<div class=\"progress yellow\"><span class=\"progress-left\"><span class=\"progress-bar\"></span></span><span class=\"progress-right\"><span class=\"progress-bar\"></span></span><div class=\"progress-value\">" + RemainDaysPrcnt + "%</div>");
                            }
                            if (RemainDaysPrcnt >= 50 && RemainDaysPrcnt < 75)
                            {
                                sb.Append("<div class=\"progress blue\"><span class=\"progress-left\"><span class=\"progress-bar\"></span></span><span class=\"progress-right\"><span class=\"progress-bar\"></span></span><div class=\"progress-value\">" + RemainDaysPrcnt + "%</div>");
                            }
                            if (RemainDaysPrcnt >= 75 && RemainDaysPrcnt <= 100)
                            {
                                sb.Append("<div class=\"progress green\"><span class=\"progress-left\"><span class=\"progress-bar\"></span></span><span class=\"progress-right\"><span class=\"progress-bar\"></span></span><div class=\"progress-value\">" + RemainDaysPrcnt + "%</div>");
                            }
                        }
                        sb.Append("</td>");
                    }
                }
                else
                {
                    sb.Append("<td></td>");
                }

                sb.Append("<td>");

                sb.Append("<div class=\"btn_stl1\">");

                string NoteCnt = dt.Rows[intRowBodyCount]["NOTECNT"].ToString();
                string NoteReplyCnt = dt.Rows[intRowBodyCount]["USR_NOTECNT"].ToString();
                string AddtnlCnt = dt.Rows[intRowBodyCount]["ADDTNL_CNT"].ToString();
                string AddtnlReplyCnt = dt.Rows[intRowBodyCount]["USR_ADDTNL_CNT"].ToString();

                //Approve/Reject/Hold
                if (dt.Rows[intRowBodyCount]["TYPE_STATUS"].ToString() == "0")
                {
                    if (ddlStatus == "0")
                    {
                        if (Convert.ToInt32(AddtnlCnt) > 0 && Convert.ToInt32(AddtnlReplyCnt) == 0)
                        {
                            sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn2\" title=\"Approve\" onclick=\"return CheckAddtnlApprv('" + Id + "',1);\" ><i class=\"fa fa-check\"></i></a>");
                            sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn3\" title=\"Reject\" onclick=\"return CheckAddtnlApprv('" + Id + "',2);\" ><i class=\"fa fa-times\"></i></a>");
                            if (intEnableHold == 1)
                            {
                                sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn4 bt_v\" title=\"Hold\" onclick=\"return CheckAddtnlApprv('" + Id + "',3);\" ><i class=\"fa fa-pause\"></i></a>");
                            }
                        }
                        else if (Convert.ToInt32(NoteCnt) > 0 && Convert.ToInt32(NoteReplyCnt) == 0)
                        {
                            sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn2\" title=\"Approve\" disabled onclick=\"return NoteNotPossible();\" ><i class=\"fa fa-check\"></i></a>");
                            sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn3\" title=\"Reject\" disabled onclick=\"return NoteNotPossible();\" ><i class=\"fa fa-times\"></i></a>");
                            if (intEnableHold == 1)
                            {
                                sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn4 bt_v\" disabled title=\"Hold\" onclick=\"return NoteNotPossible();\" ><i class=\"fa fa-pause\"></i></a>");
                            }
                        }
                        else
                        {
                            if ((HoldUser == 0) || (Status == 0 && HoldUser != 0 && HoldUser == objEntity.UserId))
                            {
                                sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn2\" title=\"Approve\" onclick=\"return OpenApproveOrHold('" + Id + "',1);\" ><i class=\"fa fa-check\"></i></a>");
                                sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn3\" title=\"Reject\" onclick=\"return OpenRejectModal('" + Id + "');\" ><i class=\"fa fa-times\"></i></a>");
                                if (intEnableHold == 1)
                                {
                                    if (Status == 0 && HoldUser != 0 && HoldUser == objEntity.UserId)
                                    {
                                        sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn4 bt_v\" title=\"Hold\" onclick=\"return HoldNotPossible();\" ><i class=\"fa fa-pause\"></i></a>");
                                    }
                                    else
                                    {
                                        sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn4 bt_v\" title=\"Hold\" onclick=\"return OpenApproveOrHold('" + Id + "',3);\" ><i class=\"fa fa-pause\"></i></a>");
                                    }
                                }
                            }
                            else
                            {
                                sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn2\" title=\"Approve\" disabled onclick=\"return OnHoldMsg();\" ><i class=\"fa fa-check\"></i></a>");
                                sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn3\" title=\"Reject\" disabled onclick=\"return OnHoldMsg();\" ><i class=\"fa fa-times\"></i></a>");
                                if (intEnableHold == 1)
                                {
                                    sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn4 bt_v\" disabled title=\"Hold\" onclick=\"return OnHoldMsg();\" ><i class=\"fa fa-pause\"></i></a>");
                                }
                            }
                        }
                    }
                }

                if (Status == 0)
                {
                    int DelegateSts = Convert.ToInt32(dt.Rows[intRowBodyCount]["WRKFLWFLT_SUBSTUTE_STS"].ToString());
                    int DelegateCnt = Convert.ToInt32(dt.Rows[intRowBodyCount]["USR_DELEGATE_CNT"].ToString());
                    if (DelegateCnt > 0)
                    {
                        sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn7 bt_e\" title=\"Delegate\" onclick=\"return OpenDelegate('" + CnslId + "','" + Id + "','" + DelegateCnt + "','" + DelegateSts + "');\" data-toggle=\"modal\" data-target=\"#ModalDelegate\"><i class=\"fa fa-exchange\"><span class=\"grn_dot\"></span></i></a>");
                    }
                    else
                    {
                        if (DelegateSts == 1)
                        {
                            sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn7 bt_e\" title=\"Delegate\" onclick=\"return OpenDelegate('" + CnslId + "','" + Id + "','" + DelegateCnt + "','" + DelegateSts + "');\" data-toggle=\"modal\" data-target=\"#ModalDelegate\"><i class=\"fa fa-exchange\"></i></a>");
                        }
                    }
                }

                //Comment
                if (Status == 0)
                {
                    int CmntCount = Convert.ToInt32(dt.Rows[intRowBodyCount]["COMMNTCNT"].ToString());
                    if (CmntCount > 0)
                    {
                        sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn9 sp_1b\" title=\"Comment\" onclick=\"return OpenComments('" + CnslId + "','" + Id + "');\" data-toggle=\"modal\" data-target=\"#ModalComment\"><i class=\"fa fa-commenting\"></i><span class=\"badge badge-success pro_bdg\">" + dt.Rows[intRowBodyCount]["COMMNTCNT"].ToString() + "</span></a>");
                    }
                    else
                    {
                        sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn9 sp_1b\" title=\"Comment\" onclick=\"return OpenComments('" + CnslId + "','" + Id + "');\" data-toggle=\"modal\" data-target=\"#ModalComment\"><i class=\"fa fa-commenting\"></i></a>");
                    }
                }

                //Note
                string NoteRepliedCnt = dt.Rows[intRowBodyCount]["USR_REPLYCNT"].ToString();

                string POCreatorId = dt.Rows[intRowBodyCount]["PRCHSORDR_CONFRM_USR_ID"].ToString();//confirm_usr_id
                if (dt.Rows[intRowBodyCount]["NOTE_TO_USRID_HIERCHY"].ToString() != "")
                {
                    POCreatorId = dt.Rows[intRowBodyCount]["NOTE_TO_USRID_HIERCHY"].ToString();//last_approved_usr_id
                }

                string POCreator = dt.Rows[intRowBodyCount]["NOTE_TO_USRNAME"].ToString();
                if (dt.Rows[intRowBodyCount]["NOTE_TO_USRNAME_HIERCHY"].ToString() != "")
                {
                    POCreator = dt.Rows[intRowBodyCount]["NOTE_TO_USRNAME_HIERCHY"].ToString();
                }

                if (Status == 0)
                {
                    if (Convert.ToInt32(NoteCnt) > 0 && Convert.ToInt32(NoteReplyCnt) == 0)
                    {
                        sb.Append("<a disabled href=\"javascript:;\" class=\"btn act_btn bn8 bt_v\" title=\"Note\" onclick=\"return NoteNotPossible();\"><i class=\"fa fa-file-text\"></i></i></a>");
                    }
                    else
                    {
                        if (Convert.ToInt32(NoteRepliedCnt) > 0)//ShowReplyNoteModal
                        {
                            sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn8 bt_v\" title=\"Note\" onclick=\"return OpenModalNote('" + CnslId + "','" + Id + "','" + NoteReplyCnt + "','" + POCreator + "','" + POCreatorId + "','" + NoteRepliedCnt + "');\" data-toggle=\"modal\" data-target=\"#ModalNote\"><i class=\"fa fa-file-text\"><span class=\"grn_dot\"></span></i></a>");
                        }
                        else
                        {
                            if (Convert.ToInt32(NoteReplyCnt) > 0)//GiveReplyModal
                            {
                                sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn8 bt_v\" title=\"Note\" onclick=\"return OpenModalNote('" + CnslId + "','" + Id + "','" + NoteReplyCnt + "','" + POCreator + "','" + POCreatorId + "','" + NoteRepliedCnt + "');\" data-toggle=\"modal\" data-target=\"#ModalNote\"><i class=\"fa fa-file-text\"><span class=\"grn_dot\"></span></i></a>");
                            }
                            else
                            {
                                if (Convert.ToInt32(POCreatorId) != objEntity.UserId)//AddNoteModal
                                {
                                    sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn8 bt_v\" title=\"Note\" onclick=\"return OpenModalNote('" + CnslId + "','" + Id + "','" + NoteReplyCnt + "','" + POCreator + "','" + POCreatorId + "','" + NoteRepliedCnt + "');\" data-toggle=\"modal\" data-target=\"#ModalNote\"><i class=\"fa fa-file-text\"></i></i></a>");
                                }
                                else
                                {
                                    sb.Append("<a href=\"javascript:;\" disabled href=\"javascript:;\" class=\"btn act_btn bn8 bt_v\" title=\"Note\" ><i class=\"fa fa-file-text\"></i></i></a>");
                                }
                            }
                        }
                    }
                }

                //Additional details
                string AddtnlRepliedCnt = dt.Rows[intRowBodyCount]["USR_REPLY_ADDTNLCNT"].ToString();

                if (Status == 0)
                {
                    if (Convert.ToInt32(AddtnlCnt) > 0 && Convert.ToInt32(AddtnlReplyCnt) == 0)
                    {
                        sb.Append("<a disabled href=\"javascript:;\" class=\"btn act_btn bn7\" title=\"Support\" onclick=\"return AddtnlDtlsNotPossible();\"><i class=\"fa fa-user-plus\"></i></i></a>");
                    }
                    else
                    {
                        if (Convert.ToInt32(AddtnlRepliedCnt) > 0)//ShowReplyModal
                        {
                            sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn7\" title=\"Support\" onclick=\"return OpenModalAddtnl('" + CnslId + "','" + Id + "','" + AddtnlReplyCnt + "','" + AddtnlRepliedCnt + "');\" data-toggle=\"modal\" data-target=\"#ModalSupport\"><i class=\"fa fa-user-plus\"><span class=\"grn_dot\"></span></i></a>");
                        }
                        else
                        {
                            if (Convert.ToInt32(AddtnlReplyCnt) > 0)//GiveReplyModal
                            {
                                sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn7\" title=\"Support\" onclick=\"return OpenModalAddtnl('" + CnslId + "','" + Id + "','" + AddtnlReplyCnt + "','" + AddtnlRepliedCnt + "');\" data-toggle=\"modal\" data-target=\"#ModalSupport\"><i class=\"fa fa-user-plus\"><span class=\"grn_dot\"></span></i></a>");
                            }
                            else
                            {
                                sb.Append("<a href=\"javascript:;\" class=\"btn act_btn bn7\" title=\"Support\" onclick=\"return OpenModalAddtnl('" + CnslId + "','" + Id + "','" + AddtnlReplyCnt + "','" + AddtnlRepliedCnt + "');\" data-toggle=\"modal\" data-target=\"#ModalSupport\"><i class=\"fa fa-user-plus\"></i></i></a>");
                            }
                        }
                    }
                }

                string AprvrCanModifySts = dt.Rows[intRowBodyCount]["WRKFLW_APRVR_MODFY"].ToString();

                if (ddlStatus == "0")
                {
                    sb.Append("<a class=\"btn act_btn bn4 bt_v\" title=\"View\" onclick='return getdetails(this.href);' " +
                                 "href=\"/PMS/PMS_Master/pms_Purchase_Order/pms_Purchase_Order.aspx?Id=" + Id + "&VId=" + AprvrCanModifySts + "\"><i class=\"fa fa-list-alt\"></i></a>");
                }
                else
                {
                    sb.Append("<a class=\"btn act_btn bn4 bt_v\" title=\"View\" onclick='return getdetails(this.href);' " +
                                  "href=\"/PMS/PMS_Master/pms_Purchase_Order/pms_Purchase_Order.aspx?ViewId=" + Id + "&VId=0\"><i class=\"fa fa-list-alt\"></i></a>");
                }

                sb.Append("</div>");

                sb.Append("</td>");

                sb.Append("</tr>");
            }

        }
        else
        {
            sb.Append("<td class=\"tr_c\" colspan=\"11\">No data available in table</td>");
        }

        strReturn[0] = sbHead.ToString();
        strReturn[1] = sb.ToString();

        return strReturn;
    }

    //------------------------------------------Pagination------------------------------------------------

    [WebMethod]
    public static string[] GetData(string OrgId, string CorpId, string UserId, string ddlStatus, string Documnt, string StrtDate, string EndDate, string EnableHold, string PageNumber, string PageMaxSize, string strCommonSearchTerm, string OrderColumn, string OrderMethod, string strInputColumnSearch)
    {
        clsEntityApprovalConsole objEntityApprvlCnsl = new clsEntityApprovalConsole();
        clsBusinessLayerApprovalConsole objBusinessApprvlCnsl = new clsBusinessLayerApprovalConsole();

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        clsCommonLibrary objCommon = new clsCommonLibrary();

        string[] strResults = new string[3];

        try
        {
            if (OrgId != null && OrgId != "")
            {
                objEntityApprvlCnsl.OrgId = Convert.ToInt32(OrgId);
            }
            if (CorpId != null && CorpId != "")
            {
                objEntityApprvlCnsl.CorpId = Convert.ToInt32(CorpId);
            }
            if (UserId != null && UserId != "")
            {
                objEntityApprvlCnsl.UserId = Convert.ToInt32(UserId);
            }
            objEntityApprvlCnsl.Status = Convert.ToInt32(ddlStatus);

            if (Documnt != "--SELECT DOCUMENT--")
            {
                objEntityApprvlCnsl.DocId = Convert.ToInt32(Documnt);
            }
            if (StrtDate != "")
            {
                objEntityApprvlCnsl.FromDate = objCommon.textToDateTime(StrtDate);
            }
            if (EndDate != "")
            {
                objEntityApprvlCnsl.ToDate = objCommon.textToDateTime(EndDate);
            }

            objEntityApprvlCnsl.PageNumber = Convert.ToInt32(PageNumber);
            objEntityApprvlCnsl.PageMaxSize = Convert.ToInt32(PageMaxSize);
            objEntityApprvlCnsl.OrderMethod = Convert.ToInt32(OrderMethod);
            objEntityApprvlCnsl.OrderColumn = Convert.ToInt32(OrderColumn);
            objEntityApprvlCnsl.CommonSearchTerm = strCommonSearchTerm;

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

            objEntityApprvlCnsl.SearchRef = strSearchInputs[Convert.ToInt32(SearchInputColumns.REF)];
            objEntityApprvlCnsl.SearchWrkflw = strSearchInputs[Convert.ToInt32(SearchInputColumns.WRKFLOW)];
            objEntityApprvlCnsl.SearchDocumnt = strSearchInputs[Convert.ToInt32(SearchInputColumns.DOCUMENT)];
            objEntityApprvlCnsl.SearchDate = strSearchInputs[Convert.ToInt32(SearchInputColumns.DATE)];
            objEntityApprvlCnsl.SearchReqstor = strSearchInputs[Convert.ToInt32(SearchInputColumns.USER)];

            //ReadList
            DataTable dt = objBusinessApprvlCnsl.ReadApprovalPendingList(objEntityApprvlCnsl);

            //int intEnableApprove = Convert.ToInt32(EnableModify);
            //int intEnableReject = Convert.ToInt32(EnableModify);
            int intEnableHold = Convert.ToInt32(EnableHold);

            string[] strTableContents = new string[2];
            strTableContents = ConvertDataTableToHTML(dt, objEntityApprvlCnsl, intEnableHold, ddlStatus);
            strResults[0] = strTableContents[0];
            strResults[1] = strTableContents[1];


            if (dt.Rows.Count > 0)
            {
                int intTotalItems = Convert.ToInt32(dt.Rows[0]["CNT"].ToString());
                int intCurrentRowCount = dt.Rows.Count;

                //Pagination
                strResults[2] = objBusinessLayer.GenereatePagination(intTotalItems, objEntityApprvlCnsl.PageNumber, objEntityApprvlCnsl.PageMaxSize, intCurrentRowCount);
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
                sbSearchInputColumns.Append("<th></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "1")
            {
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"REF#\" placeholder=\"REF#\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "2")
            {
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"WORKFLOW\" placeholder=\"WORKFLOW\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "3")
            {
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"DOCUMENT\" placeholder=\"DOCUMENT\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "4")
            {
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"DATE\" placeholder=\"DATE\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "5")
            {
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"REQUESTOR\" placeholder=\"REQUESTOR\"></th>");
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
        CHKBX = 0,
        REF = 1,
        WRKFLOW = 2,
        DOCUMENT = 3,
        DATE = 4,
        USER = 5,
    }

    //------------------------------------------Pagination------------------------------------------------


    public List<clsEntityApprovalConsole> GetNextApprovalIds(string CorpId, string OrgId, string UserId, string strId)
    {
        List<clsEntityApprovalConsole> objEntityList = new List<clsEntityApprovalConsole>();

        clsEntityApprovalConsole objEntityApprvlCnsl = new clsEntityApprovalConsole();
        clsBusinessLayerApprovalConsole objBusinessApprvlCnsl = new clsBusinessLayerApprovalConsole();

        objEntityApprvlCnsl.PurchsOrdrId = Convert.ToInt32(strId);
        objEntityApprvlCnsl.UserId = Convert.ToInt32(UserId);
        objEntityApprvlCnsl.CorpId = Convert.ToInt32(CorpId);
        objEntityApprvlCnsl.OrgId = Convert.ToInt32(OrgId);

        DataTable dtHierarchy = objBusinessApprvlCnsl.ReadHierarchy(objEntityApprvlCnsl);//all employees not in approval console table

        if (dtHierarchy.Rows.Count > 0)
        {
            int Level = Convert.ToInt32(dtHierarchy.Rows[0]["WRKFLWFLT_LEVEL"].ToString());
            for (int intRow = 0; intRow < dtHierarchy.Rows.Count; intRow++)
            {
                int NewLevel = Convert.ToInt32(dtHierarchy.Rows[intRow]["WRKFLWFLT_LEVEL"].ToString());

                if (Level == NewLevel)
                {
                    objEntityApprvlCnsl.WrkFlowId = Convert.ToInt32(dtHierarchy.Rows[intRow]["WRKFLW_ID"].ToString());
                    objEntityApprvlCnsl.EmployeeId = Convert.ToInt32(dtHierarchy.Rows[intRow]["USR_ID"].ToString());
                    objEntityApprvlCnsl.DesignatnId = Convert.ToInt32(dtHierarchy.Rows[intRow]["DSGN_ID"].ToString());
                    objEntityApprvlCnsl.Level = Convert.ToInt32(Level);

                    clsEntityApprovalConsole objEntity = new clsEntityApprovalConsole();

                    DataTable dtConditions = objBusinessApprvlCnsl.ReadConditions(objEntityApprvlCnsl);
                    if (dtConditions.Rows.Count > 0)
                    {
                        int Flag = 0;
                        for (int intCRow = 0; intCRow < dtConditions.Rows.Count; intCRow++)
                        {
                            objEntityApprvlCnsl.ConditionId = Convert.ToInt32(dtConditions.Rows[intCRow]["CNDTN_ID"].ToString());
                            objEntityApprvlCnsl.ConditionType = Convert.ToInt32(dtConditions.Rows[intCRow]["CNDTN_TYPE_ID"].ToString());

                            objEntityApprvlCnsl.ConditionValues = dtConditions.Rows[intCRow]["APRVLSET_DTL_VALUES"].ToString();
                            objEntityApprvlCnsl.ConditionMinVal = Convert.ToInt32(dtConditions.Rows[intCRow]["APRVLSET_DTL_MINVAL"].ToString());
                            objEntityApprvlCnsl.ConditionMaxVal = Convert.ToInt32(dtConditions.Rows[intCRow]["APRVLSET_DTL_MAXVAL"].ToString());

                            DataTable dtChkConditions = objBusinessApprvlCnsl.CheckConditions(objEntityApprvlCnsl);
                            if (dtChkConditions.Rows[0]["CNT"].ToString() == "0")
                            {
                                Flag++;
                            }
                        }

                        if (Flag == dtConditions.Rows.Count)
                        {
                            objEntity.Level = objEntityApprvlCnsl.Level;
                            objEntity.EmployeeId = objEntityApprvlCnsl.EmployeeId;
                            objEntityList.Add(objEntity);
                        }
                    }
                    else
                    {
                        objEntity.PurchsOrdrId = objEntityApprvlCnsl.PurchsOrdrId;
                        objEntity.Level = objEntityApprvlCnsl.Level;
                        objEntity.EmployeeId = objEntityApprvlCnsl.EmployeeId;
                        objEntityList.Add(objEntity);
                    }

                }
                else
                {
                    if (objEntityList.Count == 0)
                    {
                        Level = NewLevel;
                        intRow = intRow - 1;
                    }
                }
            }
        }

        return objEntityList;
    }

    [WebMethod]
    public static string ApproveReject(string CorpId, string OrgId, string UserId, string Mode, string RejectReason, string OrderIds)
    {
        Master_gen_Approval_Console_gen_Approval_Console objMaster = new Master_gen_Approval_Console_gen_Approval_Console();

        string strReturn = "";

        clsEntityApprovalConsole objEntityApprvlCnsl = new clsEntityApprovalConsole();
        clsBusinessLayerApprovalConsole objBusinessApprvlCnsl = new clsBusinessLayerApprovalConsole();

        List<clsEntityApprovalConsole> objEntityApprvCnslList = new List<clsEntityApprovalConsole>();
        List<clsEntityApprovalConsole> objEntityApprvCnslAddList = new List<clsEntityApprovalConsole>();

        objEntityApprvlCnsl.UserId = Convert.ToInt32(UserId);
        objEntityApprvlCnsl.CorpId = Convert.ToInt32(CorpId);
        objEntityApprvlCnsl.OrgId = Convert.ToInt32(OrgId);
        objEntityApprvlCnsl.Mode = Convert.ToInt32(Mode);
        objEntityApprvlCnsl.RejectReason = RejectReason;

        string[] strSplit = OrderIds.Split(',');
        foreach (string strOrder in strSplit)
        {
            if (strOrder != "")
            {
                string strRandomMixedId = strOrder;
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                clsEntityApprovalConsole objEntity = new clsEntityApprovalConsole();

                objEntity.PurchsOrdrId = Convert.ToInt32(strId);
                objEntity.Mode = 1;
                objEntity.UserId = objEntityApprvlCnsl.UserId;
                DataTable dtHrchyLvl = objBusinessApprvlCnsl.ReadHierarchy(objEntity);//all employees in the current level


                objEntity.PurchsOrdrId = Convert.ToInt32(strId);
                objEntity.Mode = 0;
                DataTable dtHierarchy = objBusinessApprvlCnsl.ReadHierarchy(objEntity);//all employees not in approval console table

                DataView view = new DataView(dtHrchyLvl);
                DataTable dtView = view.ToTable(true, "WRKFLW_ID", "DSGN_ID");

                if (dtView.Rows.Count == 1 || Mode == "3")//only one entry in the level/ same designatn for all emps in current level /onhold
                {
                    for (int intRow = 0; intRow < dtHrchyLvl.Rows.Count; intRow++)
                    {
                        clsEntityApprovalConsole objEntitySub = new clsEntityApprovalConsole();

                        objEntitySub.PurchsOrdrId = Convert.ToInt32(strId);
                        objEntitySub.Mode = 1;
                        objEntitySub.UserId = objEntityApprvlCnsl.UserId;
                        objEntitySub.EmployeeId = Convert.ToInt32(dtHrchyLvl.Rows[intRow]["USR_ID"].ToString());//approving all employees in current level
                        objEntityApprvCnslList.Add(objEntitySub);

                        if (Mode == "1")
                        {
                            if (dtHierarchy.Rows.Count == 0)//all approved
                            {
                                objEntityApprvlCnsl.Status = 1;
                            }
                            else
                            {
                                if (dtHierarchy.Rows[0]["HRCHY_MAJORITY_APRVL"].ToString() != "0")//majority approval
                                {
                                    int Count = Convert.ToInt32(dtHierarchy.Rows[0]["CNT"].ToString());
                                    int HalfCnt = Count / 2;
                                    int Majority = HalfCnt + 1;
                                    int ApprvdCount = Convert.ToInt32(dtHierarchy.Rows[0]["APPRVL_CNT"].ToString());
                                    if (ApprvdCount >= Majority)
                                    {
                                        objEntityApprvlCnsl.Status = 1;
                                    }
                                }
                            }

                            if (objEntityApprvlCnsl.Status != 1)
                            {
                                objEntityApprvCnslAddList = objMaster.GetNextApprovalIds(CorpId, OrgId, UserId, strId);
                            }
                        }
                    }
                }
                else //approving/rejecting the login user only
                {
                    objEntity.EmployeeId = objEntityApprvlCnsl.UserId;
                    objEntityApprvCnslList.Add(objEntity);

                    if (Mode == "1")
                    {
                        if (dtHierarchy.Rows.Count == 0)//all approved
                        {
                            objEntityApprvlCnsl.Status = 1;
                        }
                        else
                        {
                            if (dtHierarchy.Rows[0]["HRCHY_MAJORITY_APRVL"].ToString() != "0")//majority approval
                            {
                                int Count = Convert.ToInt32(dtHierarchy.Rows[0]["CNT"].ToString());
                                int HalfCnt = Count / 2;
                                int Majority = HalfCnt + 1;
                                int ApprvdCount = Convert.ToInt32(dtHierarchy.Rows[0]["APPRVL_CNT"].ToString());
                                if (ApprvdCount >= Majority)
                                {
                                    objEntityApprvlCnsl.Status = 1;
                                }
                            }
                        }
                    }

                }

            }
        }

        try
        {
            objBusinessApprvlCnsl.ApproveRejectPurchaseOrder(objEntityApprvlCnsl, objEntityApprvCnslList, objEntityApprvCnslAddList);

            
            clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
            List<clsEntityMailAttachment> objEntityMailAttachList = new List<clsEntityMailAttachment>();
            List<clsEntityMailCcBCc> objEntityMailCcBCcList = new List<clsEntityMailCcBCc>();
            List<classEntityToMailAddress> objEntityToMailAddressList = new List<classEntityToMailAddress>();

            foreach (clsEntityApprovalConsole objEntity in objEntityApprvCnslList)
            {
                clsEntityLayerUserRegistration objEntityUser = new clsEntityLayerUserRegistration();
                clsBusinessLayerUserRegisteration objBusinessUser = new clsBusinessLayerUserRegisteration();

                objEntityUser.UsrRegistrationId = objEntity.EmployeeId;
                DataTable dtEmp = objBusinessUser.ReadUsrMasterEdit(objEntityUser);
                string strToMail = "", strToName = "";
                if (dtEmp.Rows.Count > 0)
                {
                    strToMail = dtEmp.Rows[0]["USR_EMAIL"].ToString();
                    strToName = dtEmp.Rows[0]["USR_NAME"].ToString();
                }
                strToMail = "projectlead.democompany@gmail.com";

                clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
                clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();
                objEntityPurchaseOrder.PurchsOrdrId = objEntity.PurchsOrdrId;
                string strRef = "";
                DataTable dt = objBusinessPurchaseOrder.ReadPurchaseOrderById(objEntityPurchaseOrder);
                if (dt.Rows.Count > 0)
                {
                    strRef = dt.Rows[0]["PRCHSORDR_REF"].ToString();
                }

                string strEmailSubject = "Approval Request";
                StringBuilder sb = new StringBuilder();
                sb.Append("Dear " + strToName + ",");
                sb.Append("<br/><br/>This email is to notify you that the purchase order with Ref# " + strRef + " requires approval.");
                sb.Append("<br/><br/>");
                sb.Append("<br/>Please do the needful as soon as possible.");

                string strEmailContent = sb.ToString();

                if (strToMail != "")
                {
                    //objMaster.SendMail(strToMail, strEmailSubject, strEmailContent, objEntityMail, objEntityMailAttachList, objEntityMailCcBCcList, objEntityToMailAddressList);
                }
            }


            if (Mode == "1")
                strReturn = "Aprvd";
            else if (Mode == "2")
                strReturn = "Rejct";
            else if (Mode == "3")
                strReturn = "Hold";
        }
        catch (Exception)
        {

        }

        return strReturn;
    }

    [WebMethod]
    public static string[] LoadNoteData(string CnslId, string UserId, string NoteNeedReplySts, string NoteReplyViewSts)
    {
        string[] strResults = new string[8];

        clsEntityApprovalConsole objEntityApprvlCnsl = new clsEntityApprovalConsole();
        clsBusinessLayerApprovalConsole objBusinessApprvlCnsl = new clsBusinessLayerApprovalConsole();

        string strRandomMixedId = CnslId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        objEntityApprvlCnsl.ApprvlCnslId = Convert.ToInt32(strId);
        objEntityApprvlCnsl.UserId = Convert.ToInt32(UserId);
        objEntityApprvlCnsl.ReplySts = Convert.ToInt32(NoteReplyViewSts);

        DataTable dt = objBusinessApprvlCnsl.ReadNoteDetails(objEntityApprvlCnsl);

        StringBuilder sb = new StringBuilder();
        int intAttchCnt = 0;
        if (dt.Rows.Count > 0)
        {
            DataView view = new DataView(dt);
            DataTable dtNote = view.ToTable(true, "APRVLCNSLNOTE_ID", "APRVLCNSLNOTE_MSG", "REPLY_TO_USRNAME", "REPLY_TO_USRID", "REPLY_FRM_USRNAME", "REPLY_FRM_USRID", "APRVLCNSLNOTE_REPLY_MSG");

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
                strResults[3] = dtNote.Rows[0]["APRVLCNSLNOTE_MSG"].ToString();
                strResults[2] = dtNote.Rows[0]["APRVLCNSLNOTE_ID"].ToString();
            }
            else
            {
                strResults[3] = dtNote.Rows[0]["APRVLCNSLNOTE_REPLY_MSG"].ToString();
            }

            for (int intRow = 0; intRow < dt.Rows.Count; intRow++)
            {
                if (dtNote.Rows[0]["APRVLCNSLNOTE_ID"].ToString() == dt.Rows[intRow]["ATTCH_NOTEID"].ToString())
                {
                    if (dt.Rows[intRow]["APRVLCNSLATCHNT_FILENM"].ToString() != "")
                    {
                        clsCommonLibrary objCommon = new clsCommonLibrary();
                        string strFilePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.APPROVAL_CONSOLE_NOTE_ATTACH) + dt.Rows[intRow]["APRVLCNSLATCHNT_FILENM"].ToString();
                        sb.Append("<span class=\"attc_h\" >");
                        sb.Append("<a href=\"" + strFilePath + "\" target=\"_blank\"><i class=\"fa fa-download\" aria-hidden=\"true\"></i> " + dt.Rows[intRow]["APRVLCNSLATCHNT_FILEACTNM"].ToString() + "</a>");
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
            clsEntityApprovalConsole objEntityApprvlCnsl = new clsEntityApprovalConsole();
            clsBusinessLayerApprovalConsole objBusinessApprvlCnsl = new clsBusinessLayerApprovalConsole();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityApprvlCnsl.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                objEntityApprvlCnsl.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            string strRandomMixedId = hiddenAprvlCnslId.Value;
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityApprvlCnsl.ApprvlCnslId = Convert.ToInt32(strId);

            if (hiddenNoteId.Value != "")//reply
            {
                objEntityApprvlCnsl.NoteId = Convert.ToInt32(hiddenNoteId.Value);
                objEntityApprvlCnsl.ReplySts = 1;
            }
            objEntityApprvlCnsl.NoteMsg = txtMessage.Value;
            objEntityApprvlCnsl.EmployeeId = Convert.ToInt32(hiddenToUserId.Value);
            objEntityApprvlCnsl.UserId = Convert.ToInt32(hiddenFromUserId.Value);

            List<clsEntityApprovalConsole> objEntityPurchsOrdrAttchmntList = new List<clsEntityApprovalConsole>();
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
                                clsEntityApprovalConsole objEntity = new clsEntityApprovalConsole();

                                string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                                objEntity.ActualFileName = strFileName;
                                string strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

                                int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.APPROVAL_CONSOLE_NOTE_ATTACH);
                                objEntityCommon.CorporateID = objEntityApprvlCnsl.CorpId;
                                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.APPROVAL_CONSOLE_NOTE_ATTACH);
                                string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);

                                string strImageName = "APPROVALCONSOLENOTE_" + intImageSection.ToString() + "_" + count + "_" + strNextNumber + "." + strFileExt;
                                objEntity.FileName = strImageName;
                                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.APPROVAL_CONSOLE_NOTE_ATTACH);

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


            objBusinessApprvlCnsl.InsertNote(objEntityApprvlCnsl, objEntityPurchsOrdrAttchmntList);


            clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
            List<clsEntityMailCcBCc> objEntityMailCcBCcList = new List<clsEntityMailCcBCc>();
            List<classEntityToMailAddress> objEntityToMailAddressList = new List<classEntityToMailAddress>();

            clsEntityLayerUserRegistration objEntityUser = new clsEntityLayerUserRegistration();
            clsBusinessLayerUserRegisteration objBusinessUser = new clsBusinessLayerUserRegisteration();

            objEntityUser.UsrRegistrationId = objEntityApprvlCnsl.EmployeeId;
            DataTable dtEmp = objBusinessUser.ReadUsrMasterEdit(objEntityUser);
            string strToMail = "", strToName = "";
            if (dtEmp.Rows.Count > 0)
            {
                strToMail = dtEmp.Rows[0]["USR_EMAIL"].ToString();
                strToName = dtEmp.Rows[0]["USR_NAME"].ToString();
            }
            strToMail = "projectlead.democompany@gmail.com";

            objEntityUser.UsrRegistrationId = objEntityApprvlCnsl.UserId;
            DataTable dtUser = objBusinessUser.ReadUsrMasterEdit(objEntityUser);
            string strFromMail = "", strFromName = "";
            if (dtUser.Rows.Count > 0)
            {
                strFromMail = dtUser.Rows[0]["USR_EMAIL"].ToString();
                strFromName = dtUser.Rows[0]["USR_NAME"].ToString();
            }

            clsEntityPurchaseOrder objEntitySub = new clsEntityPurchaseOrder();
            objEntitySub.PurchsOrdrId = objEntityApprvlCnsl.PurchsOrdrId;
            if (objEntityApprvlCnsl.ReplySts == 0)
            {
                objEntitySub.UserId = objEntityApprvlCnsl.EmployeeId;
            }
            else
            {
                objEntitySub.UserId = objEntityApprvlCnsl.UserId;
            }
            objEntitySub.ReplySts = 0;
            DataTable dt = objBusinessApprvlCnsl.ReadNoteDetails(objEntityApprvlCnsl);
            string strMsg = "", strRef = "";
            if (dt.Rows.Count > 0)
            {
                strMsg = dt.Rows[0]["APRVLCNSLNOTE_MSG"].ToString();
                strRef = dt.Rows[0]["PRCHSORDR_REF"].ToString();
            }

            string strEmailSubject = "Note";
            if (objEntityApprvlCnsl.ReplySts == 1)
            {
                strEmailSubject = "Reply Note";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("Dear " + strToName + ",");
            if (objEntityApprvlCnsl.ReplySts == 0)
            {
                sb.Append("<br/><br/>This email is to notify you that a note has been created by " + strFromName + " against the purchase order Ref# " + strRef + ".");
            }
            else
            {
                sb.Append("<br/><br/>This email is to notify you that a reply note has been provided by " + strFromName + " for the note created against the purchase order Ref# " + strRef + ".");
            }
            sb.Append("<br/><br/>");
            if (objEntityApprvlCnsl.ReplySts == 0)
            {
                sb.Append("<b>Message</b> : " + objEntityApprvlCnsl.NoteMsg);
            }
            else
            {
                sb.Append("<b>Reply Message</b> : " + objEntityApprvlCnsl.NoteMsg);
            }

            if (objEntityMailAttachList.Count > 0)
            {
                sb.Append("Please find the attachments sent along with this mail.");
            }

            if (objEntityApprvlCnsl.ReplySts == 0)
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
                Response.Redirect("gen_Approval_Console.aspx?InsUpd=NoteReply");
            }
            else
            {
                Response.Redirect("gen_Approval_Console.aspx?InsUpd=Note");
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
    public static string[] LoadComments(string Id, string UserId)
    {
        string[] strReturn = new string[3];

        clsEntityApprovalConsole objEntityApprvlCnsl = new clsEntityApprovalConsole();
        clsBusinessLayerApprovalConsole objBusinessApprvlCnsl = new clsBusinessLayerApprovalConsole();

        string strRandomMixedId = Id;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        objEntityApprvlCnsl.PurchsOrdrId = Convert.ToInt32(strId);

        DataTable dt = objBusinessApprvlCnsl.ReadCommentDtls(objEntityApprvlCnsl);

        int CmntCnt = 0;
        StringBuilder sb = new StringBuilder();
        StringBuilder sbCmnt = new StringBuilder();
        for (int intRow = 0; intRow < dt.Rows.Count; intRow++)
        {
            if ((dt.Rows[intRow]["APRVLCNSLCMNT_VISBLSTS"].ToString() == "0") || (dt.Rows[intRow]["APRVLCNSLCMNT_VISBLSTS"].ToString() == "1" && dt.Rows[intRow]["APRVLCNSLCMNT_INS_USR_ID"].ToString() == UserId))
            {
                sb.Append("<div class=\"evt\">");
                sb.Append("<div class=\"inq\">");
                sb.Append("<span class=\"datep\"><i class=\"fa fa-commenting\" aria-hidden=\"true\"></i></span>");
                sb.Append("<p class=\"data\">" + dt.Rows[intRow]["APRVLCNSLCMNT_INS_DATE"].ToString() + "</p>");
                sb.Append("</div>");
                sb.Append("</div>");

                sbCmnt.Append("<div class=\"evt2\">");
                sbCmnt.Append("<h2>" + dt.Rows[intRow]["APRVLCNSLCMNT_COMMENT"].ToString() + "<span class=\"sbf\"> by " + dt.Rows[intRow]["USR_NAME"].ToString() + "</span></h2>");
                sbCmnt.Append("</div>");
                CmntCnt++;
            }
        }
        strReturn[0] = sb.ToString();
        strReturn[1] = sbCmnt.ToString();
        strReturn[2] = CmntCnt.ToString();

        if (CmntCnt > 0)
        {
            objEntityApprvlCnsl.UserId = Convert.ToInt32(UserId);
            objEntityApprvlCnsl.Mode = CmntCnt;

            objBusinessApprvlCnsl.InsertUsrViewComments(objEntityApprvlCnsl);
        }

        return strReturn;
    }

    protected void btnCmntSubmit_Click(object sender, EventArgs e)
    {
        clsEntityApprovalConsole objEntityApprvlCnsl = new clsEntityApprovalConsole();
        clsBusinessLayerApprovalConsole objBusinessApprvlCnsl = new clsBusinessLayerApprovalConsole();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityApprvlCnsl.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityApprvlCnsl.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityApprvlCnsl.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        string strRandomMixedId = hiddenAprvlCnslId.Value;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityApprvlCnsl.ApprvlCnslId = Convert.ToInt32(strId);

        objEntityApprvlCnsl.Comment = txtComment.Value;
        objEntityApprvlCnsl.VisibleSts = Convert.ToInt32(ddlVisibilitySts.SelectedItem.Value);

        objBusinessApprvlCnsl.InsertComments(objEntityApprvlCnsl);

        Response.Redirect("gen_Approval_Console.aspx?InsUpd=Cmnt");
    }


    [WebMethod]
    public static string[] LoadEmployees(string CorpId, string OrgId, string strText)
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        objEntityCommon.CorporateID = Convert.ToInt32(CorpId);
        objEntityCommon.Organisation_Id = Convert.ToInt32(OrgId);
        objEntityCommon.Searchstring = strText;

        DataTable dt = objBusinessLayer.ReadEmployees(objEntityCommon);

        List<string> ListReturn = new List<string>();
        for (int intRow = 0; intRow < dt.Rows.Count; intRow++)
        {
            ListReturn.Add(string.Format("{0}<>{1}", dt.Rows[intRow]["USR_ID"].ToString(), dt.Rows[intRow]["USR_NAME_CODE"].ToString()));
        }
        return ListReturn.ToArray();
    }

    [WebMethod]
    public static string[] LoadAddtnalDtlsData(string CnslId, string UserId, string NeedReplySts, string ReplyViewSts)
    {
        string[] strResults = new string[8];

        clsEntityApprovalConsole objEntityApprvlCnsl = new clsEntityApprovalConsole();
        clsBusinessLayerApprovalConsole objBusinessApprvlCnsl = new clsBusinessLayerApprovalConsole();

        string strRandomMixedId = CnslId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        objEntityApprvlCnsl.ApprvlCnslId = Convert.ToInt32(strId);
        objEntityApprvlCnsl.UserId = Convert.ToInt32(UserId);
        objEntityApprvlCnsl.ReplySts = Convert.ToInt32(ReplyViewSts);

        DataTable dt = objBusinessApprvlCnsl.ReadAdditionalDetails(objEntityApprvlCnsl);

        StringBuilder sb = new StringBuilder();
        int intAttchCnt = 0;
        if (dt.Rows.Count > 0)
        {
            DataView view = new DataView(dt);
            DataTable dtNote = view.ToTable(true, "APRVLCNSLADTNL_ID", "APRVLCNSLADTNL_MSG", "REPLY_TO_USRNAME", "REPLY_TO_USRID", "REPLY_FRM_USRNAME", "REPLY_FRM_USRID", "APRVLCNSLADTNL_REPLY_MSG");

            if (NeedReplySts == "1")
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

            if (ReplyViewSts == "0")
            {
                strResults[3] = dtNote.Rows[0]["APRVLCNSLADTNL_MSG"].ToString();
                strResults[2] = dtNote.Rows[0]["APRVLCNSLADTNL_ID"].ToString();
            }
            else
            {
                strResults[3] = dtNote.Rows[0]["APRVLCNSLADTNL_REPLY_MSG"].ToString();
            }

            for (int intRow = 0; intRow < dt.Rows.Count; intRow++)
            {
                if (dtNote.Rows[0]["APRVLCNSLADTNL_ID"].ToString() == dt.Rows[intRow]["ATTCH_ADDTNLID"].ToString())
                {
                    if (dt.Rows[intRow]["APRVLCNSLATCHADDTN_FILENM"].ToString() != "")
                    {
                        clsCommonLibrary objCommon = new clsCommonLibrary();
                        string strFilePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.APPROVAL_CONSOLE_ADDTNL_ATTACH) + dt.Rows[intRow]["APRVLCNSLATCHADDTN_FILENM"].ToString();
                        sb.Append("<span class=\"attc_h\" >");
                        sb.Append("<a href=\"" + strFilePath + "\" target=\"_blank\"><i class=\"fa fa-download\" aria-hidden=\"true\"></i> " + dt.Rows[intRow]["APRVLCNSLATCHADDTN_FILEACTNM"].ToString() + "</a>");
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

    protected void btnSubmitAddtnl_Click(object sender, EventArgs e)
    {
        clsEntityApprovalConsole objEntityApprvlCnsl = new clsEntityApprovalConsole();
        clsBusinessLayerApprovalConsole objBusinessApprvlCnsl = new clsBusinessLayerApprovalConsole();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityApprvlCnsl.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityApprvlCnsl.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        string strRandomMixedId = hiddenAprvlCnslId.Value;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityApprvlCnsl.ApprvlCnslId = Convert.ToInt32(strId);

        if (hiddenAddtnlDtlId.Value != "")//reply
        {
            objEntityApprvlCnsl.AdditionalId = Convert.ToInt32(hiddenAddtnlDtlId.Value);
            objEntityApprvlCnsl.ReplySts = 1;
        }
        objEntityApprvlCnsl.NoteMsg = txtMessageAddtnl.Value;
        objEntityApprvlCnsl.EmployeeId = Convert.ToInt32(hiddenEmployeeId.Value);
        objEntityApprvlCnsl.UserId = Convert.ToInt32(hiddenFromUserIdAddtnl.Value);

        List<clsEntityApprovalConsole> objEntityPurchsOrdrAttchmntList = new List<clsEntityApprovalConsole>();
        List<clsEntityMailAttachment> objEntityMailAttachList = new List<clsEntityMailAttachment>();

        if (hiddenAttchmntDtlsAddtnl.Value != "" && hiddenAttchmntDtlsAddtnl.Value != "[]")
        {
            string jsonData = hiddenAttchmntDtlsAddtnl.Value;
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
                string jsonFileid = "fileAttachAddtnl" + objDataList[count].ROWID;
                for (int intCount = 0; intCount < Request.Files.Count; intCount++)
                {
                    string fileId = Request.Files.AllKeys[intCount].ToString();
                    HttpPostedFile PostedFile = Request.Files[intCount];
                    if (fileId == jsonFileid)
                    {
                        if (PostedFile.ContentLength > 0)
                        {
                            clsEntityApprovalConsole objEntity = new clsEntityApprovalConsole();

                            string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                            objEntity.ActualFileName = strFileName;
                            string strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

                            int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.APPROVAL_CONSOLE_ADDTNL_ATTACH);
                            objEntityCommon.CorporateID = objEntityApprvlCnsl.CorpId;
                            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.APPROVAL_CONSOLE_ADDTNL_ATTACH);
                            string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);

                            string strImageName = "APPROVALCONSOLEADDTNL_" + intImageSection.ToString() + "_" + count + "_" + strNextNumber + "." + strFileExt;
                            objEntity.FileName = strImageName;
                            string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.APPROVAL_CONSOLE_ADDTNL_ATTACH);

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

        objBusinessApprvlCnsl.InsertAdditionalDetails(objEntityApprvlCnsl, objEntityPurchsOrdrAttchmntList);

        clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
        List<clsEntityMailCcBCc> objEntityMailCcBCcList = new List<clsEntityMailCcBCc>();
        List<classEntityToMailAddress> objEntityToMailAddressList = new List<classEntityToMailAddress>();

        clsEntityLayerUserRegistration objEntityUser = new clsEntityLayerUserRegistration();
        clsBusinessLayerUserRegisteration objBusinessUser = new clsBusinessLayerUserRegisteration();

        objEntityUser.UsrRegistrationId = objEntityApprvlCnsl.EmployeeId;
        DataTable dtEmp = objBusinessUser.ReadUsrMasterEdit(objEntityUser);
        string strToMail = "", strToName = "";
        if (dtEmp.Rows.Count > 0)
        {
            strToMail = dtEmp.Rows[0]["USR_EMAIL"].ToString();
            strToName = dtEmp.Rows[0]["USR_NAME"].ToString();
        }
        strToMail = "projectlead.democompany@gmail.com";

        objEntityUser.UsrRegistrationId = objEntityApprvlCnsl.UserId;
        DataTable dtUser = objBusinessUser.ReadUsrMasterEdit(objEntityUser);
        string strFromMail = "", strFromName = "";
        if (dtUser.Rows.Count > 0)
        {
            strFromMail = dtUser.Rows[0]["USR_EMAIL"].ToString();
            strFromName = dtUser.Rows[0]["USR_NAME"].ToString();
        }

        clsEntityPurchaseOrder objEntitySub = new clsEntityPurchaseOrder();
        objEntitySub.PurchsOrdrId = objEntityApprvlCnsl.PurchsOrdrId;
        if (objEntityApprvlCnsl.ReplySts == 0)
        {
            objEntitySub.UserId = objEntityApprvlCnsl.EmployeeId;
        }
        else
        {
            objEntitySub.UserId = objEntityApprvlCnsl.UserId;
        }
        objEntitySub.ReplySts = 0;
        DataTable dt = objBusinessApprvlCnsl.ReadNoteDetails(objEntityApprvlCnsl);
        string strMsg = "", strRef = "";
        if (dt.Rows.Count > 0)
        {
            strMsg = dt.Rows[0]["APRVLCNSLADTNL_MSG"].ToString();
            strRef = dt.Rows[0]["PRCHSORDR_REF"].ToString();
        }

        string strEmailSubject = "Additional details request";
        if (objEntityApprvlCnsl.ReplySts == 1)
        {
            strEmailSubject = "Reply note to additional details request";
        }
        StringBuilder sb = new StringBuilder();
        sb.Append("Dear " + strToName + ",");
        if (objEntityApprvlCnsl.ReplySts == 0)
        {
            sb.Append("<br/><br/>This email is to notify you that an additional details has been created by " + strFromName + " against the purchase order Ref# " + strRef + ".");
        }
        else
        {
            sb.Append("<br/><br/>This email is to notify you that a reply note has been provided by " + strFromName + " for the note created against the purchase order Ref# " + strRef + ".");
        }
        sb.Append("<br/><br/>");
        if (objEntityApprvlCnsl.ReplySts == 0)
        {
            sb.Append("<b>Message</b> : " + objEntityApprvlCnsl.NoteMsg);
        }
        else
        {
            sb.Append("<b>Reply Message</b> : " + objEntityApprvlCnsl.NoteMsg);
        }

        if (objEntityMailAttachList.Count > 0)
        {
            sb.Append("Please find the attachments sent along with this mail.");
        }

        if (objEntityApprvlCnsl.ReplySts == 0)
        {
            sb.Append("<br/>Please reply to the note as soon as possible.");
        }

        string strEmailContent = sb.ToString();

        if (strToMail != "")
        {
            //SendMail(strToMail, strEmailSubject, strEmailContent, objEntityMail, objEntityMailAttachList, objEntityMailCcBCcList, objEntityToMailAddressList);
        }


        if (hiddenAddtnlDtlId.Value != "")//reply
        {
            Response.Redirect("gen_Approval_Console.aspx?InsUpd=AddtnlReply");
        }
        else
        {
            Response.Redirect("gen_Approval_Console.aspx?InsUpd=Addtnl");
        }
    }

    [WebMethod]
    public static string[] LoadEmployeesHierachy(string CorpId, string OrgId, string UserId, string Id, string strText)
    {
        clsEntityApprovalConsole objEntityApprvlCnsl = new clsEntityApprovalConsole();
        clsBusinessLayerApprovalConsole objBusinessApprvlCnsl = new clsBusinessLayerApprovalConsole();

        string strRandomMixedId = Id;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        objEntityApprvlCnsl.CorpId = Convert.ToInt32(CorpId);
        objEntityApprvlCnsl.OrgId = Convert.ToInt32(OrgId);
        objEntityApprvlCnsl.UserId = Convert.ToInt32(UserId);
        objEntityApprvlCnsl.PurchsOrdrId = Convert.ToInt32(strId);
        objEntityApprvlCnsl.Mode = 2;
        objEntityApprvlCnsl.CommonSearchTerm = strText;

        DataTable dt = objBusinessApprvlCnsl.ReadHierarchy(objEntityApprvlCnsl);//all employees not in approval console pending table

        List<string> ListReturn = new List<string>();
        for (int intRow = 0; intRow < dt.Rows.Count; intRow++)
        {
            ListReturn.Add(string.Format("{0}<>{1}", dt.Rows[intRow]["USR_ID"].ToString(), dt.Rows[intRow]["USR_NAME_CODE"].ToString()));
        }
        return ListReturn.ToArray();
    }

    [WebMethod]
    public static string[] LoadDelegateData(string CnslId, string UserId, string ReplyViewSts)
    {
        string[] strResults = new string[8];

        clsEntityApprovalConsole objEntityApprvlCnsl = new clsEntityApprovalConsole();
        clsBusinessLayerApprovalConsole objBusinessApprvlCnsl = new clsBusinessLayerApprovalConsole();

        string strRandomMixedId = CnslId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        objEntityApprvlCnsl.ApprvlCnslId = Convert.ToInt32(strId);
        objEntityApprvlCnsl.UserId = Convert.ToInt32(UserId);

        DataTable dt = objBusinessApprvlCnsl.ReadDelegateDtls(objEntityApprvlCnsl);

        if (dt.Rows.Count > 0)
        {
            //---------Note----------
            //To User
            strResults[1] = dt.Rows[0]["REPLY_FRM_USRNAME"].ToString();
            strResults[5] = dt.Rows[0]["REPLY_FRM_USRID"].ToString();

            strResults[3] = dt.Rows[0]["APRVLCNSLDLGT_MESSAGE"].ToString();
            strResults[2] = dt.Rows[0]["APRVLCNSLDLGT_ID"].ToString();
        }

        return strResults;
    }

    protected void btnSubmitDelegate_Click(object sender, EventArgs e)
    {
        try
        {
            clsEntityApprovalConsole objEntityApprvlCnsl = new clsEntityApprovalConsole();
            clsBusinessLayerApprovalConsole objBusinessApprvlCnsl = new clsBusinessLayerApprovalConsole();

            clsCommonLibrary objCommon = new clsCommonLibrary();

            if (Session["USERID"] != null)
            {
                objEntityApprvlCnsl.UserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityApprvlCnsl.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                objEntityApprvlCnsl.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            string strRandomMixedId = hiddenAprvlCnslId.Value;
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityApprvlCnsl.ApprvlCnslId = Convert.ToInt32(strId);

            objEntityApprvlCnsl.NoteMsg = txtMessageDelegate.Value;
            objEntityApprvlCnsl.EmployeeId = Convert.ToInt32(hiddenEmployeeId.Value);

            objBusinessApprvlCnsl.InsertDelegate(objEntityApprvlCnsl);

            clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
            List<clsEntityMailAttachment> objEntityMailAttachList = new List<clsEntityMailAttachment>();
            List<clsEntityMailCcBCc> objEntityMailCcBCcList = new List<clsEntityMailCcBCc>();
            List<classEntityToMailAddress> objEntityToMailAddressList = new List<classEntityToMailAddress>();

            clsEntityLayerUserRegistration objEntityUser = new clsEntityLayerUserRegistration();
            clsBusinessLayerUserRegisteration objBusinessUser = new clsBusinessLayerUserRegisteration();

            objEntityUser.UsrRegistrationId = objEntityApprvlCnsl.EmployeeId;
            DataTable dtEmp = objBusinessUser.ReadUsrMasterEdit(objEntityUser);
            string strToMail = "", strToName = "";
            if (dtEmp.Rows.Count > 0)
            {
                strToMail = dtEmp.Rows[0]["USR_EMAIL"].ToString();
                strToName = dtEmp.Rows[0]["USR_NAME"].ToString();
            }
            strToMail = "projectlead.democompany@gmail.com";

            clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
            clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();

            string strRandomMixedIdPrchs = hiddenPurchaseOrderId.Value;
            string strLenghtofIdPrchs = strRandomMixedIdPrchs.Substring(0, 2);
            int intLenghtofIdPrchs = Convert.ToInt16(strLenghtofIdPrchs);
            string strIdPrchs = strRandomMixedIdPrchs.Substring(2, intLenghtofIdPrchs);

            objEntityPurchaseOrder.PurchsOrdrId = Convert.ToInt32(strIdPrchs);
            string strRef = "";
            DataTable dt = objBusinessPurchaseOrder.ReadPurchaseOrderById(objEntityPurchaseOrder);
            if (dt.Rows.Count > 0)
            {
                strRef = dt.Rows[0]["PRCHSORDR_REF"].ToString();
            }

            string strEmailSubject = "Approval Request";
            StringBuilder sb = new StringBuilder();
            sb.Append("Dear " + strToName + ",");
            sb.Append("<br/><br/>This email is to notify you that the approval for purchase order with Ref# " + strRef + " has been delegated to you.");
            sb.Append("<br/><br/>");
            sb.Append("<br/>Please do the needful as soon as possible.");

            string strEmailContent = sb.ToString();

            if (strToMail != "")
            {
                //SendMail(strToMail, strEmailSubject, strEmailContent, objEntityMail, objEntityMailAttachList, objEntityMailCcBCcList, objEntityToMailAddressList);
            }


            Response.Redirect("gen_Approval_Console.aspx?InsUpd=Delgt");
        }
        catch (Exception ex)
        {

        }
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
        strTitle = "APPROVAL CONSOLE";
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
    public static string PrintList(string orgID, string corptID,string UserId, string statusid, string docid, string doc, string from, string toDt)
    {
        string strReturn = "";


        clsEntityApprovalConsole objEntityApprvlCnsl = new clsEntityApprovalConsole();
        clsBusinessLayerApprovalConsole objBusinessApprvlCnsl = new clsBusinessLayerApprovalConsole();
        clsBusinessLayer objBusinesslayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();


        objEntityApprvlCnsl.OrgId = Convert.ToInt32(orgID);

        objEntityApprvlCnsl.CorpId = Convert.ToInt32(corptID);

        if (UserId != null && UserId != "")
        {
            objEntityApprvlCnsl.UserId = Convert.ToInt32(UserId);
        }
        if (doc != "")
        {
            objEntityApprvlCnsl.DocId = Convert.ToInt32(docid);
        }
        if (from != "")
        {
            objEntityApprvlCnsl.FromDate = objCommon.textToDateTime(from);
        }
        if (toDt != "")
        {
            objEntityApprvlCnsl.ToDate = objCommon.textToDateTime(toDt);
        }
        int intCorpId = 0;
        if (corptID != "")
            intCorpId = Convert.ToInt32(corptID);


        objEntityApprvlCnsl.Status = Convert.ToInt32(statusid);


        DataTable dtCategory = objBusinessApprvlCnsl.ReadApprovalPendingList(objEntityApprvlCnsl);
        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.APPROVAL_CONSOLE_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.APPROVAL_CONSOLE_PDF);
        objEntityCommon.CorporateID = objEntityApprvlCnsl.CorpId;
        objEntityCommon.Organisation_Id = objEntityApprvlCnsl.OrgId;
        string strNextNumber = objBusinesslayer.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "approvalconsole_" + strNextNumber + ".pdf";

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

               
                   if (docid == "1")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("DOCUMENT TYPE  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
            
                    footrtable.AddCell(new PdfPCell(new Phrase("Purchase Order", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else if (docid == "2")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("DOCUMENT TYPE  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
            
                    footrtable.AddCell(new PdfPCell(new Phrase("Sales Order", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                

                footrtable.AddCell(new PdfPCell(new Phrase("STATUS ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (statusid == "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Pending", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else if (statusid == "1")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Approved", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else if (statusid == "2")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Rejected", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("All", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });

                }
                if (from != "")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("FROM DATE     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6  });
                    footrtable.AddCell(new PdfPCell(new Phrase(from, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                if (toDt != "")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("TO DATE     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding =2 ,PaddingBottom = 6  });
                    footrtable.AddCell(new PdfPCell(new Phrase(toDt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }

                document.Add(footrtable);
                if (statusid == "0" || statusid == "3")
                {
                PdfPTable TBCustomer = new PdfPTable(9);
                float[] footrsBody = { 7, 18, 18, 15, 17, 15, 12, 12,10 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);


                TBCustomer.AddCell(new PdfPCell(new Phrase("REF#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("ENTITY", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("DOCUEMNT SECTION", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("REQUESTED DATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("REQUESTOR", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("STATUS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("PRIORITY", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("IMPORTANCE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                
               
                    TBCustomer.AddCell(new PdfPCell(new Phrase("THRESHOLD PERIOD", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
               


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

                        int NoteSts = 0;
                        DataRow[] foundAuthors = dtCategory.Select("TYPE_STATUS = '" + 1 + "'");
                        if (foundAuthors.Length != 0)
                        {
                            NoteSts++;
                        }

                        int AddtnSts = 0;
                        DataRow[] foundAuthors2 = dtCategory.Select("TYPE_STATUS = '" + 2 + "'");
                        if (foundAuthors2.Length != 0)
                        {
                            AddtnSts++;
                        }
                        string strPrchsDate= dtCategory.Rows[intRowBodyCount]["PRCHSORDR_DATE"].ToString();
                        string strInsertDate = dtCategory.Rows[intRowBodyCount]["APRVLCNSL_INS_DATE"].ToString();
                        string strReqstDate = dtCategory.Rows[intRowBodyCount]["REQUEST_DATE"].ToString();
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["PRCHSORDR_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["WRKFLW_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["DOC_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase( strInsertDate  , FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["USR_NAME_CODE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        string Statusids = dtCategory.Rows[intRowBodyCount]["APRVLCNSL_APRVLSTS"].ToString();



                        int HoldUser = 0;
                        if (dtCategory.Rows[intRowBodyCount]["APRVLCNSL_HOLD_USR_ID"].ToString() != "")
                        {
                            HoldUser = Convert.ToInt32(dtCategory.Rows[intRowBodyCount]["APRVLCNSL_HOLD_USR_ID"].ToString());
                        }

                        if (dtCategory.Rows[intRowBodyCount]["TYPE_STATUS"].ToString() == "0")
                        {
                            if (Statusids == "0")//Pending
                            {
                                TBCustomer.AddCell(new PdfPCell(new Phrase("Pending", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                            }
                            else if (Statusids == " 1")//Confirmed
                            {
                                TBCustomer.AddCell(new PdfPCell(new Phrase("Approved", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                            }
                            else if (Statusids == "2")//Rejected
                            {
                                TBCustomer.AddCell(new PdfPCell(new Phrase("Rejected", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                            }
                        }
                        else if (dtCategory.Rows[intRowBodyCount]["TYPE_STATUS"].ToString() == "1")
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase("Note", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                            //sb.Append("<td><button class=\"btn tab_but1 butn3\" onclick=\"return false;\"></button></td>");
                        }
                        else if (dtCategory.Rows[intRowBodyCount]["TYPE_STATUS"].ToString() == "2")
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase("Additional Details", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                            //sb.Append("<td><button class=\"btn tab_but1 butn3\" onclick=\"return false;\">Additional Details</button></td>");
                        }


                    

                       
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["WRKFLW_PRIORTY"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["PRCHSORDR_IMPORTNC"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                    //    clsEntityCommon objEntityCommon = new clsEntityCommon();

                        
                        int ThresholdSts = Convert.ToInt32(dtCategory.Rows[intRowBodyCount]["WRKFLWFLT_THRSHOLD_PRD_STS"].ToString());
                        int Threshold = Convert.ToInt32(dtCategory.Rows[intRowBodyCount]["WRKFLWFLT_THRSHOLD_PERIOD"].ToString());

                        DateTime DateVal = objCommon.textWithTimeToDateTime(strReqstDate);
                        DateTime Today = objBusinessLayer.LoadCurrentDate();

                        decimal decThreshold = Convert.ToDecimal(Threshold);
                        decimal decRemainDaysHrs = 0;

                        if (dtCategory.Rows[intRowBodyCount]["TYPE_STATUS"].ToString() == "0")
                        {
                            if (ThresholdSts == 1)//Hours
                            {
                                DateTime HourNew = DateVal.AddHours(Threshold);
                                decRemainDaysHrs = Convert.ToDecimal((HourNew - Today).TotalHours);
                            }
                            else //Days
                            {
                                DateTime DateNew = DateVal.AddDays(Threshold);
                                decRemainDaysHrs = Convert.ToDecimal((DateNew - Today).TotalDays);
                            }

                            decimal decRemainDaysPrcnt = 100 - ((decRemainDaysHrs / decThreshold) * 100);
                            decimal RemainDaysPrcnt = Math.Round(decRemainDaysPrcnt);

                            if (RemainDaysPrcnt < 0)
                                RemainDaysPrcnt = 0;
                            if (RemainDaysPrcnt > 100)
                                RemainDaysPrcnt = 100;

                            if (statusid == "0" || statusid== "3")
                            {

                                if (Statusids == "0")
                                {
                                    
                                        TBCustomer.AddCell(new PdfPCell(new Phrase(RemainDaysPrcnt.ToString()+"%", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


                                }
                            }
                        }
                       
                        else
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                        }
                      
                    }
                    // TBCustomer.AddCell(new PdfPCell(new Phrase(strStatusImg, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


                }

                else
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase("No data available in table", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 9 });

                }
                document.Add(TBCustomer);
                document.Close();
                strRet = strImagePath + strImageName;
            }
                else
                {
                    PdfPTable TBCustomer = new PdfPTable(8);
                    float[] footrsBody = { 7, 18, 18, 15, 17, 15, 12, 12 };
                    TBCustomer.SetWidths(footrsBody);
                    TBCustomer.WidthPercentage = 100;
                    TBCustomer.HeaderRows = 1;

                    var FontGray = new BaseColor(138, 138, 138);
                    var FontColour = new BaseColor(134, 152, 160);
                    var FontSmallGray = new BaseColor(230, 230, 230);


                    TBCustomer.AddCell(new PdfPCell(new Phrase("REF#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("ENTITY", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("DOCUEMNT SECTION", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("REQUESTED DATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("REQUESTOR", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("STATUS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("PRIORITY", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("IMPORTANCE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });


                    //TBCustomer.AddCell(new PdfPCell(new Phrase("THRESHOLD PERIOD", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });



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

                            int NoteSts = 0;
                            DataRow[] foundAuthors = dtCategory.Select("TYPE_STATUS = '" + 1 + "'");
                            if (foundAuthors.Length != 0)
                            {
                                NoteSts++;
                            }

                            int AddtnSts = 0;
                            DataRow[] foundAuthors2 = dtCategory.Select("TYPE_STATUS = '" + 2 + "'");
                            if (foundAuthors2.Length != 0)
                            {
                                AddtnSts++;
                            }
                            string strPrchsDate = dtCategory.Rows[intRowBodyCount]["PRCHSORDR_DATE"].ToString();
                            string strInsertDate = dtCategory.Rows[intRowBodyCount]["APRVLCNSL_INS_DATE"].ToString();
                            string strReqstDate = dtCategory.Rows[intRowBodyCount]["REQUEST_DATE"].ToString();
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["PRCHSORDR_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["WRKFLW_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["DOC_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(strInsertDate, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["USR_NAME_CODE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            string Statusids = dtCategory.Rows[intRowBodyCount]["APRVLCNSL_APRVLSTS"].ToString();



                            int HoldUser = 0;
                            if (dtCategory.Rows[intRowBodyCount]["APRVLCNSL_HOLD_USR_ID"].ToString() != "")
                            {
                                HoldUser = Convert.ToInt32(dtCategory.Rows[intRowBodyCount]["APRVLCNSL_HOLD_USR_ID"].ToString());
                            }

                            if (dtCategory.Rows[intRowBodyCount]["TYPE_STATUS"].ToString() == "0")
                            {
                                if (Statusids == "0")//Pending
                                {
                                    TBCustomer.AddCell(new PdfPCell(new Phrase("Pending", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                                }
                                else if (Statusids == " 1")//Confirmed
                                {
                                    TBCustomer.AddCell(new PdfPCell(new Phrase("Approved", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                                }
                                else if (Statusids == "2")//Rejected
                                {
                                    TBCustomer.AddCell(new PdfPCell(new Phrase("Rejected", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                                }
                            }
                            else if (dtCategory.Rows[intRowBodyCount]["TYPE_STATUS"].ToString() == "1")
                            {
                                TBCustomer.AddCell(new PdfPCell(new Phrase("Note", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                                //sb.Append("<td><button class=\"btn tab_but1 butn3\" onclick=\"return false;\"></button></td>");
                            }
                            else if (dtCategory.Rows[intRowBodyCount]["TYPE_STATUS"].ToString() == "2")
                            {
                                TBCustomer.AddCell(new PdfPCell(new Phrase("Additional Details", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                                //sb.Append("<td><button class=\"btn tab_but1 butn3\" onclick=\"return false;\">Additional Details</button></td>");
                            }





                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["WRKFLW_PRIORTY"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["PRCHSORDR_IMPORTNC"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                            //    clsEntityCommon objEntityCommon = new clsEntityCommon();


                            int ThresholdSts = Convert.ToInt32(dtCategory.Rows[intRowBodyCount]["WRKFLWFLT_THRSHOLD_PRD_STS"].ToString());
                            int Threshold = Convert.ToInt32(dtCategory.Rows[intRowBodyCount]["WRKFLWFLT_THRSHOLD_PERIOD"].ToString());

                            DateTime DateVal = objCommon.textWithTimeToDateTime(strReqstDate);
                            DateTime Today = objBusinessLayer.LoadCurrentDate();

                            decimal decThreshold = Convert.ToDecimal(Threshold);
                            decimal decRemainDaysHrs = 0;

                            if (dtCategory.Rows[intRowBodyCount]["TYPE_STATUS"].ToString() == "0")
                            {
                                if (ThresholdSts == 1)//Hours
                                {
                                    DateTime HourNew = DateVal.AddHours(Threshold);
                                    decRemainDaysHrs = Convert.ToDecimal((HourNew - Today).TotalHours);
                                }
                                else //Days
                                {
                                    DateTime DateNew = DateVal.AddDays(Threshold);
                                    decRemainDaysHrs = Convert.ToDecimal((DateNew - Today).TotalDays);
                                }

                                decimal decRemainDaysPrcnt = 100 - ((decRemainDaysHrs / decThreshold) * 100);
                                decimal RemainDaysPrcnt = Math.Round(decRemainDaysPrcnt);

                                if (RemainDaysPrcnt < 0)
                                    RemainDaysPrcnt = 0;
                                if (RemainDaysPrcnt > 100)
                                    RemainDaysPrcnt = 100;

                                if (statusid == "0" || statusid == "3")
                                {

                                    if (Statusids == "0")
                                    {

                                        TBCustomer.AddCell(new PdfPCell(new Phrase(RemainDaysPrcnt.ToString() + "%", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


                                    }
                                }
                            }

                            else
                            {
                                TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                            }

                        }
                        // TBCustomer.AddCell(new PdfPCell(new Phrase(strStatusImg, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


                    }

                    else
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase("No data available in table", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 9 });

                    }
                    document.Add(TBCustomer);
                    document.Close();
                    strRet = strImagePath + strImageName;
                }
               
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
            headtable.AddCell(new PdfPCell(new Phrase("APPROVAL CONSOLE ", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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
    public static string PrintCSV(string orgID, string corptID, string UserId, string statusid, string docid, string doc, string from, string toDt)
    {
        string strReturn = "";
        clsEntityApprovalConsole objEntityApprvlCnsl = new clsEntityApprovalConsole();
        clsBusinessLayerApprovalConsole objBusinessApprvlCnsl = new clsBusinessLayerApprovalConsole();
        clsBusinessLayer objBusinesslayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        Master_gen_Approval_Console_gen_Approval_Console OBJ = new Master_gen_Approval_Console_gen_Approval_Console();


        objEntityApprvlCnsl.OrgId = Convert.ToInt32(orgID);

        objEntityApprvlCnsl.CorpId = Convert.ToInt32(corptID);

        if (UserId != null && UserId != "")
        {
            objEntityApprvlCnsl.UserId = Convert.ToInt32(UserId);
        }
        if (doc != "")
        {
            objEntityApprvlCnsl.DocId = Convert.ToInt32(docid);
        }
        if (from != "")
        {
            objEntityApprvlCnsl.FromDate = objCommon.textToDateTime(from);
        }
        if (toDt != "")
        {
            objEntityApprvlCnsl.ToDate = objCommon.textToDateTime(toDt);
        }
        int intCorpId = 0;
        if (corptID != "")
            intCorpId = Convert.ToInt32(corptID);


        objEntityApprvlCnsl.Status = Convert.ToInt32(statusid);


        DataTable dtCategory = objBusinessApprvlCnsl.ReadApprovalPendingList(objEntityApprvlCnsl);

        strReturn = OBJ.LoadTable_CSV(dtCategory, objEntityApprvlCnsl, statusid,docid,  doc, from, toDt);
        return strReturn;
    }
    public string LoadTable_CSV(DataTable dtCategory, clsEntityApprovalConsole objEntityApprvlCnsl, string statusid, string docid, string doc, string from, string toDt)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dt = GetTable(dtCategory, objEntityApprvlCnsl, statusid, docid, doc, from, toDt);
        string strResult = DataTableToCSV(dt, ',');
        string strImagePath = "";
        string filepath = "";
        if (objEntityApprvlCnsl.CorpId != 0)
        {
            objEntityCommon.CorporateID = objEntityApprvlCnsl.CorpId;
        }
        if (objEntityApprvlCnsl.OrgId != 0)
        {
            objEntityCommon.Organisation_Id = objEntityApprvlCnsl.OrgId;
        }
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.APPROVAL_CONSOLE_CSV);
        string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
        string newFilePath = Server.MapPath("/CustomFiles/PMS_CSV/Approval_console/Approvalconsole_" + strNextId + ".csv");
        System.IO.File.WriteAllText(newFilePath, strResult);
        filepath = "Approvalconsole_" + strNextId + ".csv";
        strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.APPROVAL_CONSOLE_CSV);
        return strImagePath + filepath;
    }
    public DataTable GetTable(DataTable dtCategory, clsEntityApprovalConsole objEntityApprvlCnsl, string statusid, string docid, string doc, string from, string toDt)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,                                                           
                                                      clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,    
                                                              };
        int intCorpId = 0;
        if (objEntityApprvlCnsl.CorpId != 0)
        {
            intCorpId = objEntityApprvlCnsl.CorpId;
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
        table.Columns.Add("APPROVAL CONSOLE", typeof(string));
        table.Columns.Add(" ", typeof(string));
        table.Columns.Add("  ", typeof(string));
        table.Columns.Add("   ", typeof(string));
        table.Columns.Add("    ", typeof(string));
        table.Columns.Add("     ", typeof(string));
        table.Columns.Add("      ", typeof(string));
        table.Columns.Add("       ", typeof(string));
        table.Columns.Add("        ", typeof(string));
        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');


        if (docid == "1")
        {


            table.Rows.Add("DOCUMENT TYPE  :", "Purchase Order", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
 }
        else if (docid == "2")
        {
            table.Rows.Add("DOCUMENT TYPE  :", "Sales Order", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

            }
        if (statusid == "0")
        {
            table.Rows.Add("STATUS  :", "Pending", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        else if (statusid == "1")
        {
            table.Rows.Add("STATUS  :", "Approved", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        else if (statusid == "2")
        {
            table.Rows.Add("STATUS  :", "Reopened", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        else
        {
            table.Rows.Add("STATUS  :", "All", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        if (from != "")
        {
            table.Rows.Add("FROM DATE :", '"' + from + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
  }
        if (toDt != "")
        {
            table.Rows.Add("TO DATE :", '"' + toDt + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }





        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

        if (statusid == "0" || statusid == "3")
        {
            table.Rows.Add("REF#", "ENTITY", "DOCUEMNT SECTION", "REQUESTED DATE", "REQUESTOR", "STATUS", "PRIORITY", "IMPORTANCE", "THRESHOLD PERIOD");

        }
        else
        {
            table.Rows.Add("REF#", "ENTITY", "DOCUEMNT SECTION", "REQUESTED DATE", "REQUESTOR", "STATUS", "PRIORITY", "IMPORTANCE", "");

        }

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


                int NoteSts = 0;
                DataRow[] foundAuthors = dtCategory.Select("TYPE_STATUS = '" + 1 + "'");
                if (foundAuthors.Length != 0)
                {
                    NoteSts++;
                }

                int AddtnSts = 0;
                DataRow[] foundAuthors2 = dtCategory.Select("TYPE_STATUS = '" + 2 + "'");
                if (foundAuthors2.Length != 0)
                {
                    AddtnSts++;
                }
                string strPrchsDate = dtCategory.Rows[intRowBodyCount]["PRCHSORDR_DATE"].ToString();
                string strInsertDate = dtCategory.Rows[intRowBodyCount]["APRVLCNSL_INS_DATE"].ToString();
                string strReqstDate = dtCategory.Rows[intRowBodyCount]["REQUEST_DATE"].ToString();
               string Statusids = dtCategory.Rows[intRowBodyCount]["APRVLCNSL_APRVLSTS"].ToString();
               string statuimg = "";





               int HoldUser = 0;
               if (dtCategory.Rows[intRowBodyCount]["APRVLCNSL_HOLD_USR_ID"].ToString() != "")
               {
                   HoldUser = Convert.ToInt32(dtCategory.Rows[intRowBodyCount]["APRVLCNSL_HOLD_USR_ID"].ToString());
               }

               if (dtCategory.Rows[intRowBodyCount]["TYPE_STATUS"].ToString() == "0")
               {
                   if (Statusids == "0")//Pending
                   {
                       statuimg = "Pending";
                   }
                   else if (Statusids == " 1")//Confirmed
                   {
                       statuimg = "Approved";
                   }
                   else if (Statusids == "2")//Rejected
                   {
                       statuimg = "Rejected";
                   }
               }
               else if (dtCategory.Rows[intRowBodyCount]["TYPE_STATUS"].ToString() == "1")
               {
                   statuimg = "Note";
                   //sb.Append("<td><button class=\"btn tab_but1 butn3\" onclick=\"return false;\"></button></td>");
               }
               else if (dtCategory.Rows[intRowBodyCount]["TYPE_STATUS"].ToString() == "2")
               {
                   statuimg = "Additional Details";
                   //sb.Append("<td><button class=\"btn tab_but1 butn3\" onclick=\"return false;\">Additional Details</button></td>");
               }








              

                clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                //    clsEntityCommon objEntityCommon = new clsEntityCommon();



                int ThresholdSts = Convert.ToInt32(dtCategory.Rows[intRowBodyCount]["WRKFLWFLT_THRSHOLD_PRD_STS"].ToString());
                int Threshold = Convert.ToInt32(dtCategory.Rows[intRowBodyCount]["WRKFLWFLT_THRSHOLD_PERIOD"].ToString());

                DateTime DateVal = objCommon.textWithTimeToDateTime(strReqstDate);
                DateTime Today = objBusinessLayer.LoadCurrentDate();

                decimal decThreshold = Convert.ToDecimal(Threshold);
                decimal decRemainDaysHrs = 0;
                string period = "";
                if (dtCategory.Rows[intRowBodyCount]["TYPE_STATUS"].ToString() == "0")
                {
                    if (ThresholdSts == 1)//Hours
                    {
                        DateTime HourNew = DateVal.AddHours(Threshold);
                        decRemainDaysHrs = Convert.ToDecimal((HourNew - Today).TotalHours);
                    }
                    else //Days
                    {
                        DateTime DateNew = DateVal.AddDays(Threshold);
                        decRemainDaysHrs = Convert.ToDecimal((DateNew - Today).TotalDays);
                    }

                    decimal decRemainDaysPrcnt = 100 - ((decRemainDaysHrs / decThreshold) * 100);
                    decimal RemainDaysPrcnt = Math.Round(decRemainDaysPrcnt);

                    if (RemainDaysPrcnt < 0)
                        RemainDaysPrcnt = 0;
                    if (RemainDaysPrcnt > 100)
                        RemainDaysPrcnt = 100;

                    if (statusid == "0" || statusid == "3")
                    {

                        if (Statusids == "0")
                        {
                           
                                period = Convert.ToString(RemainDaysPrcnt);

                           
                        }
                    }
                }
                if (statusid == "0" || statusid == "3")
                {
                    table.Rows.Add('"' + dtCategory.Rows[intRowBodyCount]["PRCHSORDR_REF"].ToString() + '"', '"' + dtCategory.Rows[intRowBodyCount]["WRKFLW_NAME"].ToString() + '"', '"' + dtCategory.Rows[intRowBodyCount]["DOC_NAME"].ToString() + '"', '"' + strInsertDate + '"', '"' + dtCategory.Rows[intRowBodyCount]["USR_NAME_CODE"].ToString() + '"', '"' + statuimg + '"', '"' + dtCategory.Rows[intRowBodyCount]["WRKFLW_PRIORTY"].ToString() + '"', '"' + dtCategory.Rows[intRowBodyCount]["PRCHSORDR_IMPORTNC"].ToString() + '"', '"' + period + '"' + "%");
                }
                else
                {
                    table.Rows.Add('"' + dtCategory.Rows[intRowBodyCount]["PRCHSORDR_REF"].ToString() + '"', '"' + dtCategory.Rows[intRowBodyCount]["WRKFLW_NAME"].ToString() + '"', '"' + dtCategory.Rows[intRowBodyCount]["DOC_NAME"].ToString() + '"', '"' + strInsertDate + '"', '"' + dtCategory.Rows[intRowBodyCount]["USR_NAME_CODE"].ToString() + '"', '"' + statuimg + '"', '"' + dtCategory.Rows[intRowBodyCount]["WRKFLW_PRIORTY"].ToString() + '"', '"' + dtCategory.Rows[intRowBodyCount]["PRCHSORDR_IMPORTNC"].ToString() + '"', "");

                }
            }

        }
        else
        {
            table.Rows.Add(" No data available in table", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
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