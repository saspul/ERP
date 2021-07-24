using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using CL_Compzit;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Web.Services;
using MailUtility_ERP;
using System.Threading;



// CREATED BY:EVM-0002
// CREATED DATE:16/04/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class Transaction_Compzit_Mailbox_Compzit_Mailbox : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //setting corporate and organisation values to the hidden fields
        if (Session["CORPOFFICEID"] != null)
        {
            hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            hiddenOrgId.Value = Session["ORGID"].ToString();
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            hiddenUserId.Value = Session["USERID"].ToString();
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        //Allocating child roles
        int intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Mail_Box);
        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(Convert.ToInt32(hiddenUserId.Value), intUsrRolMstrId);

        if (dtChildRol.Rows.Count > 0)
        {
            string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            string[] strChildDefArrWords = strChildRolDeftn.Split('-');
            foreach (string strC_Role in strChildDefArrWords)
            {
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.All_Mails).ToString())
                {
                    hiddenAllMailEnable.Value = "1";
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Allocate).ToString())
                {
                    hiddenMailAllocate.Value = "1";
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Forward).ToString())
                {
                    hiddenMailForward.Value = "1";

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Attach).ToString())
                {
                    hiddenMailAttach.Value = "1";

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
        }

        int intUsrolSecnd= Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.New_Lead);
        DataTable dtChildSecond = objBusinessLayer.LoadChildRoleDefnDetail(Convert.ToInt32(hiddenUserId.Value), intUsrolSecnd);

        if (dtChildSecond.Rows.Count > 0)
        {
            string strChildRolDeftn = dtChildSecond.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            string[] strChildDefArrWords = strChildRolDeftn.Split('-');
            foreach (string strC_Role in strChildDefArrWords)
            {
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                {
                    HiddenMailNewLead.Value = "1";
                }
            }
        }


        //find the path
        string strPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
        clsCommonLibrary objCommonLib = new clsCommonLibrary();
        string strCommonPath = Convert.ToString(objCommonLib.GetImagePath(clsCommonLibrary.IMAGE_SECTION.Mail_Attachments));
        string strServerPath = strPath + strCommonPath;


        //string strCommonPath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.Mail_Attachments);
       // strCommonPath = Server.MapPath(strCommonPath);
        hiddenAttachPath.Value = strCommonPath;
        hiddenServerMapPath.Value = strServerPath;

        Division_Load();
        Employees_Load();
        Customers_Load();
        Set_Mail_Storage();
        //Read_Initial_Mail_Box();


        //Start:-EMP-0009
        clsBusinessLayerMail objBusinessLayerMail = new clsBusinessLayerMail();
        DataTable dtReopenRsnMstr = objBusinessLayerMail.ReadPushReason();
        divOptionsReopenReason.InnerHtml = ConvertDataTableToHTMLSelectOptions(dtReopenRsnMstr);
        //End:-EMP-0009

    }

    //enumeration for next and previous buttons
    private enum Buttons
    {
        Previous=1,
        Next=2
    }
    
    //fetch and set mail  storage details from mail storage table
    private void Set_Mail_Storage()
    {
        clsBusinessLayerMail objBusinessLayerMail = new clsBusinessLayerMail();
        DataTable dtMailStorage = objBusinessLayerMail.Read_Mail_Storage();
        if (dtMailStorage.Rows.Count != 0)
        {
            string strHTML = "";

            for (int intRowCount = 0; intRowCount < dtMailStorage.Rows.Count; intRowCount++)
            {
                string Image = "fa fa-inbox fa_stf";
                if (intRowCount == 1)
                    Image = "fa fa-hdd-o fa_stf";
                else if (intRowCount == 2)
                    Image = "fa fa-trash-o fa_stf";
                else if (intRowCount == 3)
                    Image = "fa fa-paper-plane fa_stf";

                if (intRowCount == 0)
                {
                    divMailStorageSelected.InnerHtml = "<span class=\"sp_msg1\"><i class=\"" + Image + "\"></i> <span>" + dtMailStorage.Rows[intRowCount]["MAILSTRE_NAME"].ToString() + "</span> <i class=\"fa fa-sort\"></i></span>";
                    divMailStorageSelectedDisp.InnerHtml = "<span class=\"sel_msg_sec sp_msg1\">" + dtMailStorage.Rows[intRowCount]["MAILSTRE_NAME"].ToString() + " <i class=\"" + Image + "\"></i> </span>";

                    strHTML = strHTML + "<li id=\"li" + dtMailStorage.Rows[intRowCount]["MAILSTRE_ID"] + "\" class=\"clsMailStorage sel_ms1 sel_act_msg\"><a id=" + dtMailStorage.Rows[intRowCount]["MAILSTRE_ID"] + " href=\"javascript:;\" onclick=\"GetMailByStore(" + dtMailStorage.Rows[intRowCount]["MAILSTRE_ID"] + ",0,'" + dtMailStorage.Rows[intRowCount]["MAILSTRE_NAME"].ToString() + "','" + Image + "');\" > <i id=\"itag" + dtMailStorage.Rows[intRowCount]["MAILSTRE_ID"] + "\" class=\"" + Image + "\"></i> <span id=\"span" + dtMailStorage.Rows[intRowCount]["MAILSTRE_ID"] + "\">" + dtMailStorage.Rows[intRowCount]["MAILSTRE_NAME"].ToString() + "</span></a></li>";
                }
                else
                {
                    strHTML = strHTML + "<li id=\"li" + dtMailStorage.Rows[intRowCount]["MAILSTRE_ID"] + "\" class=\"clsMailStorage sel_ms1\"><a id=" + dtMailStorage.Rows[intRowCount]["MAILSTRE_ID"] + " href=\"javascript:;\" onclick=\"GetMailByStore(" + dtMailStorage.Rows[intRowCount]["MAILSTRE_ID"] + ",0,'" + dtMailStorage.Rows[intRowCount]["MAILSTRE_NAME"].ToString() + "','" + Image + "');\" > <i id=\"itag" + dtMailStorage.Rows[intRowCount]["MAILSTRE_ID"] + "\" class=\"" + Image + "\"></i> <span id=\"span" + dtMailStorage.Rows[intRowCount]["MAILSTRE_ID"] + "\">" + dtMailStorage.Rows[intRowCount]["MAILSTRE_NAME"].ToString() + "</span></a></li>";
                }
            }

            divMailStorage.InnerHtml = strHTML;   // INBOX, TRASH, DRAFT, SENT
        }
    }
    //fetch mails from the mail box from the inbox mail ( its for the initial stage process )
    private void Read_Initial_Mail_Box()
    {
        clsBusinessLayerMail objBusinessLayerMail = new clsBusinessLayerMail();
        clsEntityMailConsole objEntityMail = new clsEntityMailConsole();


        if (Session["CORPOFFICEID"] != null)
        {
            objEntityMail.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityMail.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityMail.Email_Store = Convert.ToInt32(clsCommonLibrary.Mail_Storage.Inbox);
        if (Session["USERID"] != null)
        {
            objEntityMail.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityMail.All_Mail_Enable = Convert.ToInt32(hiddenAllMailEnable.Value);

        DataTable dtMails = objBusinessLayerMail.Read_Mail_Box(objEntityMail);
        HiddenFieldMailCount.Value = Convert.ToString(dtMails.Rows.Count);

        string strTableHTML = "";

        strTableHTML = strTableHTML + "<table  id=\"mailtable\" class=\"display table-bordered tbl_640\" cellspacing=\"0\" width=\"100%\">";
        strTableHTML = strTableHTML + "<thead class=\"thead1\">";
        strTableHTML = strTableHTML + "<tr>";
        strTableHTML = strTableHTML + "<th class=\"th_b1_4\">";
        strTableHTML = strTableHTML + "<span class=\"button-checkbox flt_l\">";
        strTableHTML = strTableHTML + "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>Â&nbsp;</button>";
        strTableHTML = strTableHTML + "<input type=\"checkbox\" class=\"hidden\">";
        strTableHTML = strTableHTML + "</span>";
        strTableHTML = strTableHTML + "<span class=\"spn_atc_ml\" title=\"Attachment\" data-placement=\"top\" data-toggle=\"tooltip\"><i class=\"fa fa-paperclip\"></i></span>";
        strTableHTML = strTableHTML + "<span class=\"spn_atc_ml flt_r\" title=\"New Mail\" data-placement=\"top\" data-toggle=\"tooltip\"><i class=\"fa fa-envelope\"></i></span>";
        strTableHTML = strTableHTML + "</th>";
        strTableHTML = strTableHTML + "<th class=\"th_b2 tr_l\">Subject </th>";
        strTableHTML = strTableHTML + "<th class=\"th_b4 tr_l\">From</th>";
        strTableHTML = strTableHTML + "<th class=\"th_b6 tr_l\">Division</th>";
        strTableHTML = strTableHTML + "<th class=\"th_b7\">Date and Time</th>";
        strTableHTML = strTableHTML + "<th class=\"th_b1\">Status</th>";
        strTableHTML = strTableHTML + "<th class=\"th_b4\">Actions</th>";
        strTableHTML = strTableHTML + "</tr>";
        strTableHTML = strTableHTML + "</thead>";
        strTableHTML = strTableHTML + "<tbody>";

        if (dtMails.Rows.Count != 0)
        {
            int intStartValue = 0;
            int intRowCount = 0;

            for (int intMailRow = intStartValue; intMailRow < dtMails.Rows.Count; intMailRow++)
            {
                string strId = "tr" + dtMails.Rows[intMailRow]["MLBOX_ID"].ToString();

                strTableHTML = strTableHTML + "<tr id=" + strId + " class=\"frst_row\" onclick=\"return ShowMail(" + dtMails.Rows[intMailRow]["MLBOX_ID"].ToString() + "," + dtMails.Rows[intMailRow]["MAIL_TRANS_ID"].ToString() + ",'0')\"> ";

                string strSubject = "";
                if (dtMails.Rows[intMailRow]["MLBOX_SUBJECT"] != DBNull.Value)
                {
                    strSubject = dtMails.Rows[intMailRow]["MLBOX_SUBJECT"].ToString();
                    if (strSubject.Length > 48)
                    {
                        strSubject = strSubject.Substring(0, 48);
                        strSubject = strSubject + "..";
                    }
                }

                strTableHTML = strTableHTML + "<th>";
                strTableHTML = strTableHTML + "<span class=\"button-checkbox flt_l\">";
                strTableHTML = strTableHTML + "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>Â&nbsp;</button>";
                strTableHTML = strTableHTML + "<input type=\"checkbox\" class=\"hidden\">";
                strTableHTML = strTableHTML + "</span>";

                objEntityMail.Mail_Box_Id = Convert.ToInt64(dtMails.Rows[intMailRow]["MLBOX_ID"].ToString());
                DataTable dtMailAttachments = objBusinessLayerMail.Read_Attachments_By_Id(objEntityMail);
                if (dtMailAttachments.Rows.Count > 0)
                {
                    strTableHTML = strTableHTML + "<span class=\"spn_atc_ml\" title=\"Attachment\" data-placement=\"top\" data-toggle=\"tooltip\"><i class=\"fa fa-paperclip\"></i></span>";
                }
                if (Convert.ToInt32(dtMails.Rows[intMailRow]["MLBOX_STATUS"]) == 0)//unread
                {
                    strTableHTML = strTableHTML + "<span class=\"spn_atc_ml flt_r\" title=\"New Mail\" data-placement=\"top\" data-toggle=\"tooltip\"><i class=\"fa fa-envelope\"></i></span>";
                }
                strTableHTML = strTableHTML + "</th>";

                strTableHTML = strTableHTML + "<td class=\"tr_l\">" + strSubject + "</td>";
                strTableHTML = strTableHTML + "<td class=\"tr_l\">" + dtMails.Rows[intMailRow]["MLBOX_FROM_MAIL"].ToString().Replace('"', ' ') + "</td>";
                strTableHTML = strTableHTML + "<td class=\"tr_l\">" + dtMails.Rows[intMailRow]["DIVISION NAME"].ToString() + "</td>";
                strTableHTML = strTableHTML + "<td>" + dtMails.Rows[intMailRow]["RECEIVE_DATE"].ToString() + "</td>";
                if (dtMails.Rows[intMailRow]["MAILACTN_ID"] == DBNull.Value)
                {
                    strTableHTML = strTableHTML + "<td>New</td>";
                }
                else
                {
                    if (Convert.ToInt32(dtMails.Rows[intMailRow]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Allocate))
                        strTableHTML = strTableHTML + "<td>Allocated</td>";
                    else if (Convert.ToInt32(dtMails.Rows[intMailRow]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Forward))
                        strTableHTML = strTableHTML + "<td>Forwarded</td>";
                    else if (Convert.ToInt32(dtMails.Rows[intMailRow]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Reject))
                        strTableHTML = strTableHTML + "<td>Rejected</td>";
                    else if (Convert.ToInt32(dtMails.Rows[intMailRow]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Attach))
                        strTableHTML = strTableHTML + "<td>Attached</td>";
                    else if (Convert.ToInt32(dtMails.Rows[intMailRow]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Lead))
                        strTableHTML = strTableHTML + "<td>Lead</td>";
                    else if (Convert.ToInt32(dtMails.Rows[intMailRow]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.User_New))
                        strTableHTML = strTableHTML + "<td>New</td>";
                }
                strTableHTML = strTableHTML + "<th>";
                strTableHTML = strTableHTML + "<a href=\"javascript:;\" class=\"btn btn_mail_bz mb_forward\" title=\"Forward\" data-toggle=\"modal\" data-target=\"#divModelForward\"><i class=\"fa fa-share\"></i></a>";
                strTableHTML = strTableHTML + "<a href=\"javascript:;\" class=\"btn btn_mail_bz mb_aloct\" title=\"Allocate\" data-toggle=\"modal\" data-target=\"#divModelAllocate\"><i class=\"fa fa-calendar-check-o\"></i></a>";
                strTableHTML = strTableHTML + "<a href=\"javascript:;\" class=\"btn btn_mail_bz mb_merge\" title=\"Merge\" data-toggle=\"modal\" data-target=\"#divModelAttach\"><i class=\"fa fa-compress\"></i></a>";
                strTableHTML = strTableHTML + "<a href=\"javascript:;\" class=\"btn btn_mail_bz mb_lead\" title=\"New Lead\"><i class=\"fa fa-file-text-o\"></i></a>";
                strTableHTML = strTableHTML + "<a href=\"javascript:;\" class=\"btn btn_mail_bz mb_rejct\" title=\"Reject\" data-toggle=\"modal\" data-target=\"#exampleModal_st\"><i class=\"fa fa-times\"></i></a>";
                strTableHTML = strTableHTML + "</th>";

                intRowCount++;
            }

        }
        else
        {
            strTableHTML = strTableHTML + "<td colspan=\"7\">No data available</td>";
        }

        strTableHTML = strTableHTML + "</tbody>";
        strTableHTML = strTableHTML + "</table>";

        //divMailtable.InnerHtml = strTableHTML;
    }

    //call for next and previous button click
    [WebMethod]

    public static string Read_Mail_Box_Full(DataTable dtMails, clsEntityMailConsole objEntityMail)
    {
        clsBusinessLayerMail objBusinessLayerMail = new clsBusinessLayerMail();

        string strReturn = "";
        string strTableHTML = "";

        StringBuilder sb = new StringBuilder();

        if (dtMails.Rows.Count != 0)
        {
            int intRowCount = 0;

            for (int intMailRow = 0; intMailRow < dtMails.Rows.Count; intMailRow++)
            {
                string strId = "tr" + dtMails.Rows[intMailRow]["MLBOX_ID"].ToString();
                //current mail have read status -- 1

                strTableHTML = strTableHTML + "<tr id=" + strId + " class=\"frst_row\"> ";

                string strSubject = "";
                if (dtMails.Rows[intMailRow]["MLBOX_SUBJECT"] != DBNull.Value)
                {
                    strSubject = dtMails.Rows[intMailRow]["MLBOX_SUBJECT"].ToString();
                    if (strSubject.Length > 48)
                    {
                        strSubject = strSubject.Substring(0, 48);
                        strSubject = strSubject + "..";
                    }
                }

                objEntityMail.Mail_Box_Id = Convert.ToInt64(dtMails.Rows[intMailRow]["MLBOX_ID"].ToString());
                DataTable dtMailAttachments = objBusinessLayerMail.Read_Attachments_By_Id(objEntityMail);

                strTableHTML = strTableHTML + "<td>";
                if (objEntityMail.Email_Store != 3)
                {
                    strTableHTML = strTableHTML + "<span class=\"button-checkbox flt_l\">";
                    strTableHTML = strTableHTML + "<button type=\"button\" class=\"active btn-p ChkCls\" data-color=\"p\" ng-model=\"all\" onclick=\"DisplayPushToTrash();\"><i class=\"state-icon fa fa-check-square-o\"></i>Â&nbsp;</button>";
                    strTableHTML = strTableHTML + "<input id=\"cbxChk_" + objEntityMail.Mail_Box_Id + "\" type=\"checkbox\" class=\"ChkCls hidden\">";
                    strTableHTML = strTableHTML + "</span>";
                }
                if (dtMailAttachments.Rows.Count > 0)
                {
                    strTableHTML = strTableHTML + "<span class=\"spn_atc_ml\" title=\"Attachment\" data-placement=\"top\" data-toggle=\"tooltip\"><i class=\"fa fa-paperclip\"></i></span>";
                }
                if (Convert.ToInt32(dtMails.Rows[intMailRow]["MLBOX_STATUS"]) == 0)//unread
                {
                    strTableHTML = strTableHTML + "<span class=\"spn_atc_ml flt_r\" title=\"New Mail\" data-placement=\"top\" data-toggle=\"tooltip\"><i class=\"fa fa-envelope\"></i></span>";
                }
                strTableHTML = strTableHTML + "</td>";

                strTableHTML = strTableHTML + "<td class=\"tr_l\" onclick=\"return ShowMail(" + dtMails.Rows[intMailRow]["MLBOX_ID"].ToString() + "," + dtMails.Rows[intMailRow]["MAIL_TRANS_ID"].ToString() + ",'0')\">" + strSubject + "</td>";
                strTableHTML = strTableHTML + "<td class=\"tr_l\" onclick=\"return ShowMail(" + dtMails.Rows[intMailRow]["MLBOX_ID"].ToString() + "," + dtMails.Rows[intMailRow]["MAIL_TRANS_ID"].ToString() + ",'0')\">" + dtMails.Rows[intMailRow]["MLBOX_FROM_MAIL"].ToString().Replace('"', ' ') + "</td>";
                strTableHTML = strTableHTML + "<td class=\"tr_l\" onclick=\"return ShowMail(" + dtMails.Rows[intMailRow]["MLBOX_ID"].ToString() + "," + dtMails.Rows[intMailRow]["MAIL_TRANS_ID"].ToString() + ",'0')\">" + dtMails.Rows[intMailRow]["DIVISION NAME"].ToString() + "</td>";
                strTableHTML = strTableHTML + "<td onclick=\"return ShowMail(" + dtMails.Rows[intMailRow]["MLBOX_ID"].ToString() + "," + dtMails.Rows[intMailRow]["MAIL_TRANS_ID"].ToString() + ",'0')\">" + dtMails.Rows[intMailRow]["RECEIVE_DATE"].ToString() + "</td>";
                strTableHTML = strTableHTML + "<td onclick=\"return ShowMail(" + dtMails.Rows[intMailRow]["MLBOX_ID"].ToString() + "," + dtMails.Rows[intMailRow]["MAIL_TRANS_ID"].ToString() + ",'0')\">";
                if (dtMails.Rows[intMailRow]["MAILACTN_ID"] == DBNull.Value)
                {
                    strTableHTML = strTableHTML + "New";
                }
                else
                {
                    if (Convert.ToInt32(dtMails.Rows[intMailRow]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Allocate))
                        strTableHTML = strTableHTML + "Allocated";
                    else if (Convert.ToInt32(dtMails.Rows[intMailRow]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Forward))
                        strTableHTML = strTableHTML + "Forwarded";
                    else if (Convert.ToInt32(dtMails.Rows[intMailRow]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Reject))
                        strTableHTML = strTableHTML + "Rejected";
                    else if (Convert.ToInt32(dtMails.Rows[intMailRow]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Attach))
                        strTableHTML = strTableHTML + "Attached";
                    else if (Convert.ToInt32(dtMails.Rows[intMailRow]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Lead))
                        strTableHTML = strTableHTML + "Lead";
                    else if (Convert.ToInt32(dtMails.Rows[intMailRow]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.User_New))
                        strTableHTML = strTableHTML + "New";
                }
                strTableHTML = strTableHTML + "</td>";

                strTableHTML = strTableHTML + "<td>";
                strTableHTML = strTableHTML + "<a href=\"javascript:;\" class=\"btn btn_mail_bz mb_forward\" title=\"Forward\" data-toggle=\"modal\" data-target=\"#divModelForward\" onclick=\"return OpenModalForward(" + dtMails.Rows[intMailRow]["MLBOX_ID"].ToString() + ");\"><i class=\"fa fa-share\"></i></a>";
                strTableHTML = strTableHTML + "<a href=\"javascript:;\" class=\"btn btn_mail_bz mb_aloct\" title=\"Allocate\" data-toggle=\"modal\" data-target=\"#divModelAllocate\" onclick=\"return OpenModalAllocate(" + dtMails.Rows[intMailRow]["MLBOX_ID"].ToString() + ");\"><i class=\"fa fa-calendar-check-o\"></i></a>";
                strTableHTML = strTableHTML + "<a href=\"javascript:;\" class=\"btn btn_mail_bz mb_merge\" title=\"Merge\" data-toggle=\"modal\" data-target=\"#divModelAttach\" onclick=\"return OpenModalMerge(" + dtMails.Rows[intMailRow]["MLBOX_ID"].ToString() + ");\"><i class=\"fa fa-compress\"></i></a>";
                strTableHTML = strTableHTML + "<a href=\"javascript:;\" class=\"btn btn_mail_bz mb_lead\" title=\"New Lead\" onclick=\"return OpenModalLead(" + dtMails.Rows[intMailRow]["MLBOX_ID"].ToString() + ");\"><i class=\"fa fa-file-text-o\"></i></a>";
                if (objEntityMail.Email_Store != 3)
                {
                    strTableHTML = strTableHTML + "<a href=\"javascript:;\" class=\"btn btn_mail_bz mb_trash\" title=\"Push To Trash\" onclick=\"return OpenModalPushToTrash(" + dtMails.Rows[intMailRow]["MLBOX_ID"].ToString() + ");\" data-toggle=\"modal\" data-target=\"#myModalReopenReason\"><i class=\"fa fa-trash\"></i></a>";
                }
                if (dtMails.Rows[intMailRow]["MAILACTN_ID"] != DBNull.Value && Convert.ToInt32(dtMails.Rows[intMailRow]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Allocate))
                {
                    strTableHTML = strTableHTML + "<a href=\"javascript:;\" class=\"btn btn_mail_bz mb_rejct\" title=\"Reject\" onclick=\"return OpenModalReject(" + dtMails.Rows[intMailRow]["MLBOX_ID"].ToString() + ");\"><i class=\"fa fa-times\"></i></a>";
                }
                strTableHTML = strTableHTML + "</td>";

                intRowCount++;

            }
        }
        else
        {
            strTableHTML = strTableHTML + "<td class=\"tr_c\" colspan=\"7\">No data available</td>";
        }

        sb.Append(strTableHTML);

        strReturn = sb.ToString();

        return strReturn;
    }

    //fetch mail details based on mail id
    [WebMethod]

    public static string[] Read_Mail_DetailsById(string intMailId, string strUserId)
    {
        clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
        clsBusinessLayerMail objBusinessLayerMail = new clsBusinessLayerMail();

        string[] strOut = new string[7];

        objEntityMail.Mail_Box_Id = Convert.ToInt64(intMailId);
        objEntityMail.User_Id = Convert.ToInt32(strUserId);
        objBusinessLayerMail.ChangeToRead(objEntityMail);
        DataTable dtMailDtls = objBusinessLayerMail.Read_MailDetails_ById(objEntityMail);
        DataTable dtMailAttachments = objBusinessLayerMail.Read_Attachments_By_Id(objEntityMail);

        //find the path
        string strPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
        clsCommonLibrary objCommonLib = new clsCommonLibrary();
        string strCommonPath = Convert.ToString(objCommonLib.GetImagePath(clsCommonLibrary.IMAGE_SECTION.Mail_Attachments));
        string strServerPath = @"..\..\" + strCommonPath;

        string strHtml = "";
        string strFromMail = "";
        string strDivision = "";
        string strContent = "";

        if (dtMailDtls.Rows.Count != 0)
        {
            strDivision = dtMailDtls.Rows[0]["MAIL_TRANS_ID"].ToString();

            strFromMail = dtMailDtls.Rows[0]["MLBOX_FROM_MAIL"].ToString();
            strFromMail = strFromMail.Replace('<', ' ');
            strFromMail = strFromMail.Replace('>', ' ');

            string strSubject = "";
            if (dtMailDtls.Rows[0]["MLBOX_SUBJECT"] != DBNull.Value)
            {
                strSubject = dtMailDtls.Rows[0]["MLBOX_SUBJECT"].ToString();
            }

            if (dtMailDtls.Rows[0]["MLBOX_CONTENT"] != DBNull.Value)
            {
                strContent = dtMailDtls.Rows[0]["MLBOX_CONTENT"].ToString();
            }

            strHtml += "<div id=\"FromMailHead\" class=\"spn_bdge\">From: <span class=\"cnt_from\" title=\"" + strFromMail + "\">" + strFromMail + "</span></div>";
            strHtml += "<div class=\"spn_bdge\">To: <span class=\"cnt_to\" title=\"" + dtMailDtls.Rows[0]["MLBOX_TO_MAIL"].ToString() + "\">" + dtMailDtls.Rows[0]["MLBOX_TO_MAIL"].ToString() + "</span></div>";
            strHtml += "<div class=\"spn_bdge\">Subject: <span class=\"cnt_msg\" title=\"" + strSubject + "\">" + strSubject + "</span></div>";
            strHtml += "<div class=\"msg_1_hdr_rgt flt_r\">";
            strHtml += "<a id=\"divForward\" class=\"btn btn_mail_bz mb_forward\" title=\"Forward\" data-toggle=\"modal\" data-target=\"#divModelForward\" onclick=\"OpenForward()\"><i class=\"fa fa-share\"></i></a>";
            strHtml += "<a id=\"divAllocate\" class=\"btn btn_mail_bz mb_aloct\" title=\"Allocate\" data-toggle=\"modal\" data-target=\"#divModelAllocate\" onclick=\"OpenAllocate()\"><i class=\"fa fa-calendar-check-o\"></i></a>";
            strHtml += "<a id=\"divAttach\" class=\"btn btn_mail_bz mb_merge\" title=\"Merge\" data-toggle=\"modal\" data-target=\"#divModelAttach\" onclick=\"OpenAttach()\"><i class=\"fa fa-compress\"></i></a>";
            strHtml += "<a id=\"divNewLead\" class=\"btn btn_mail_bz mb_lead\" title=\"New Lead\" onclick=\"NewLead()\"><i class=\"fa fa-file-text-o\"></i></a>";
            strHtml += "<a id=\"divTrash\" class=\"btn btn_mail_bz mb_rejct\" title=\"Push to Trash\" onclick=\"PushToTrash()\"><i class=\"fa fa-trash\"></i></a>";
            strHtml += "<a id=\"divReject\" class=\"btn btn_mail_bz mb_rejct\" title=\"Reject\" onclick=\"OpenReject()\"><i class=\"fa fa-times\"></i></a>";
            strHtml += "</div>";

            Int64 intSize = System.Text.ASCIIEncoding.ASCII.GetByteCount(strHtml);

            if (intSize > 2500000)
            {
                strContent = "We Cant Fetch The Content, Sorry For The Inconvience";
            }
        }

        string strAttHtml = "";
        if (dtMailAttachments.Rows.Count != 0)
        {
            for (int intRowCount = 0; intRowCount < dtMailAttachments.Rows.Count; intRowCount++)
            {
                strAttHtml = strAttHtml + "<li class=\"list_m_atch\"><a id=" + dtMailAttachments.Rows[intRowCount]["MLBXATCH_ID"].ToString() + "  target=\"_balnk\" href=" + strServerPath + dtMailAttachments.Rows[intRowCount]["MLBXATCH_FLNAME"].ToString() + ">" + dtMailAttachments.Rows[intRowCount]["MLBXATCH_ACT_FLNM"].ToString() + "</a></li>";
            }
        }

        string strMailAction = "";
        if (dtMailDtls.Rows[0]["MAILACTN_ID"] != DBNull.Value)
            strMailAction = dtMailDtls.Rows[0]["MAILACTN_ID"].ToString();

        strOut[0] = strHtml;
        strOut[1] = strAttHtml;
        strOut[2] = strMailAction;
        strOut[3] = strFromMail;
        strOut[4] = strDivision;
        strOut[5] = strContent;
        strOut[6] = dtMailAttachments.Rows.Count.ToString();

        return strOut;
    }


    //fetch mails based on mail storage
    [WebMethod]
    public static string[] Read_Mail_ByStorage(string evt, string CorpId, string OrgId, string UserId, string AllMail)
    {
        clsBusinessLayerMail objBusinessLayerMail = new clsBusinessLayerMail();
        clsEntityMailConsole objEntityMail = new clsEntityMailConsole();

        string[] StrOutArray = new string[4];

        objEntityMail.Corporate_Id = Convert.ToInt32(CorpId);

        objEntityMail.Organisation_Id = Convert.ToInt32(OrgId);

        objEntityMail.Email_Store = Convert.ToInt32(evt);

        objEntityMail.User_Id = Convert.ToInt32(UserId);

        objEntityMail.All_Mail_Enable = Convert.ToInt32(AllMail);

        DataTable dtMails = objBusinessLayerMail.Read_Mail_Box(objEntityMail);

        string strTableHTML = "";

        strTableHTML = strTableHTML + "<table  id=\"mailtable\" class=\"display table-bordered tbl_640\" cellspacing=\"0\" width=\"100%\">";
        strTableHTML = strTableHTML + "<thead class=\"thead1\">";
        strTableHTML = strTableHTML + "<tr>";
        strTableHTML = strTableHTML + "<th class=\"th_b1_4\">";
        strTableHTML = strTableHTML + "<span class=\"button-checkbox flt_l\">";
        strTableHTML = strTableHTML + "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>Â&nbsp;</button>";
        strTableHTML = strTableHTML + "<input type=\"checkbox\" class=\"hidden\">";
        strTableHTML = strTableHTML + "</span>";
        strTableHTML = strTableHTML + "<span class=\"spn_atc_ml\" title=\"Attachment\" data-placement=\"top\" data-toggle=\"tooltip\"><i class=\"fa fa-paperclip\"></i></span>";
        strTableHTML = strTableHTML + "<span class=\"spn_atc_ml flt_r\" title=\"New Mail\" data-placement=\"top\" data-toggle=\"tooltip\"><i class=\"fa fa-envelope\"></i></span>";
        strTableHTML = strTableHTML + "</th>";
        strTableHTML = strTableHTML + "<th class=\"th_b2 tr_l\">Subject </th>";
        strTableHTML = strTableHTML + "<th class=\"th_b4 tr_l\">From</th>";
        strTableHTML = strTableHTML + "<th class=\"th_b6 tr_l\">Division</th>";
        strTableHTML = strTableHTML + "<th class=\"th_b7\">Date and Time</th>";
        strTableHTML = strTableHTML + "<th class=\"th_b1\">Status</th>";
        strTableHTML = strTableHTML + "<th class=\"th_b4\">Actions</th>";
        strTableHTML = strTableHTML + "</tr>";
        strTableHTML = strTableHTML + "</thead>";
        strTableHTML = strTableHTML + "<tbody>";

        if (dtMails.Rows.Count != 0)
        {
            int intStartValue = 0;
            int intRowCount = 0;

            string strNextValue = null;

            for (int intMailRow = intStartValue; intMailRow < dtMails.Rows.Count; intMailRow++)
            {
                string strId = "tr" + dtMails.Rows[intMailRow]["MLBOX_ID"].ToString();

                strTableHTML = strTableHTML + "<tr id=" + strId + " class=\"frst_row\" onclick=\"return ShowMail(" + dtMails.Rows[intMailRow]["MLBOX_ID"].ToString() + "," + dtMails.Rows[intMailRow]["MAIL_TRANS_ID"].ToString() + ",'0')\"> ";

                string strSubject = "";
                if (dtMails.Rows[intMailRow]["MLBOX_SUBJECT"] != DBNull.Value)
                {
                    strSubject = dtMails.Rows[intMailRow]["MLBOX_SUBJECT"].ToString();
                    if (strSubject.Length > 48)
                    {
                        strSubject = strSubject.Substring(0, 48);
                        strSubject = strSubject + "..";
                    }
                }

                strTableHTML = strTableHTML + "<th>";
                strTableHTML = strTableHTML + "<span class=\"button-checkbox flt_l\">";
                strTableHTML = strTableHTML + "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" ng-model=\"all\"><i class=\"state-icon fa fa-check-square-o\"></i>Â&nbsp;</button>";
                strTableHTML = strTableHTML + "<input type=\"checkbox\" class=\"hidden\">";
                strTableHTML = strTableHTML + "</span>";

                objEntityMail.Mail_Box_Id = Convert.ToInt64(dtMails.Rows[intMailRow]["MLBOX_ID"].ToString());
                DataTable dtMailAttachments = objBusinessLayerMail.Read_Attachments_By_Id(objEntityMail);
                if (dtMailAttachments.Rows.Count > 0)
                {
                    strTableHTML = strTableHTML + "<span class=\"spn_atc_ml\" title=\"Attachment\" data-placement=\"top\" data-toggle=\"tooltip\"><i class=\"fa fa-paperclip\"></i></span>";
                }
                if (Convert.ToInt32(dtMails.Rows[intMailRow]["MLBOX_STATUS"]) == 0)//unread
                {
                    strTableHTML = strTableHTML + "<span class=\"spn_atc_ml flt_r\" title=\"New Mail\" data-placement=\"top\" data-toggle=\"tooltip\"><i class=\"fa fa-envelope\"></i></span>";
                }
                strTableHTML = strTableHTML + "</th>";

                strTableHTML = strTableHTML + "<td class=\"tr_l\">" + strSubject + "</td>";
                strTableHTML = strTableHTML + "<td class=\"tr_l\">" + dtMails.Rows[intMailRow]["MLBOX_FROM_MAIL"].ToString().Replace('"', ' ') + "</td>";
                strTableHTML = strTableHTML + "<td class=\"tr_l\">" + dtMails.Rows[intMailRow]["DIVISION NAME"].ToString() + "</td>";
                strTableHTML = strTableHTML + "<td>" + dtMails.Rows[intMailRow]["RECEIVE_DATE"].ToString() + "</td>";
                if (dtMails.Rows[intMailRow]["MAILACTN_ID"] == DBNull.Value)
                {
                    strTableHTML = strTableHTML + "<td>New</td>";
                }
                else
                {
                    if (Convert.ToInt32(dtMails.Rows[intMailRow]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Allocate))
                        strTableHTML = strTableHTML + "<td>Allocated</td>";
                    else if (Convert.ToInt32(dtMails.Rows[intMailRow]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Forward))
                        strTableHTML = strTableHTML + "<td>Forwarded</td>";
                    else if (Convert.ToInt32(dtMails.Rows[intMailRow]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Reject))
                        strTableHTML = strTableHTML + "<td>Rejected</td>";
                    else if (Convert.ToInt32(dtMails.Rows[intMailRow]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Attach))
                        strTableHTML = strTableHTML + "<td>Attached</td>";
                    else if (Convert.ToInt32(dtMails.Rows[intMailRow]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Lead))
                        strTableHTML = strTableHTML + "<td>Lead</td>";
                    else if (Convert.ToInt32(dtMails.Rows[intMailRow]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.User_New))
                        strTableHTML = strTableHTML + "<td>New</td>";
                }

                strTableHTML = strTableHTML + "<th>";
                strTableHTML = strTableHTML + "<a href=\"javascript:;\" class=\"btn btn_mail_bz mb_forward\" title=\"Forward\" data-toggle=\"modal\" data-target=\"#divModelForward\"><i class=\"fa fa-share\"></i></a>";
                strTableHTML = strTableHTML + "<a href=\"javascript:;\" class=\"btn btn_mail_bz mb_aloct\" title=\"Allocate\" data-toggle=\"modal\" data-target=\"#divModelAllocate\"><i class=\"fa fa-calendar-check-o\"></i></a>";
                strTableHTML = strTableHTML + "<a href=\"javascript:;\" class=\"btn btn_mail_bz mb_merge\" title=\"Merge\" data-toggle=\"modal\" data-target=\"#divModelAttach\"><i class=\"fa fa-compress\"></i></a>";
                strTableHTML = strTableHTML + "<a href=\"javascript:;\" class=\"btn btn_mail_bz mb_lead\" title=\"New Lead\"><i class=\"fa fa-file-text-o\"></i></a>";
                strTableHTML = strTableHTML + "<a href=\"javascript:;\" class=\"btn btn_mail_bz mb_rejct\" title=\"Reject\" data-toggle=\"modal\" data-target=\"#exampleModal_st\"><i class=\"fa fa-times\"></i></a>";
                strTableHTML = strTableHTML + "</th>";

                intRowCount++;
            }
            string strNextEnable = null;

            //divMailtable.InnerHtml = strTableHTML;

            StrOutArray[1] = strNextValue;
            StrOutArray[2] = strNextEnable;
        }
        else
        {
            strTableHTML = strTableHTML + "<td colspan=\"7\">No data available</td>";

            StrOutArray[1] = "0";
            StrOutArray[2] = "0";
        }

        strTableHTML = strTableHTML + "</tbody>";
        strTableHTML = strTableHTML + "</table>";

        StrOutArray[0] = strTableHTML;

        StrOutArray[3] = Convert.ToString(dtMails.Rows.Count);
        return StrOutArray;

    }

         //at next records show button click
    protected void btnNext_Click(object sender, EventArgs e)
    {
        //Read_Mail_Box(Convert.ToInt32(Buttons.Next));
    }

         //at previous records show button click
    protected void btnPrevious_Click(object sender, EventArgs e)
     {
        //Read_Mail_Box(Convert.ToInt32(Buttons.Previous));
    }


    //fetch received mails from mail server to the database
    [WebMethod]
    public static string Read_Received_Mail(string strMapPath,string strOrgId, string strUserId)
    {
        if (strOrgId != "" && strUserId != "")
        {
            int intOrgId = 0, intUserId = 0;
            intOrgId = Convert.ToInt32(strOrgId);
            intUserId = Convert.ToInt32(strUserId);
            //first fetch pending mails from server put into the table
            clsMail objMail = new clsMail();
            //Thread thMailReceive = new Thread(objMail.Read_Receive_Mail);
            //thMailReceive.Start();
            objMail.Read_Receive_Mail("WEBSITE",intUserId, intOrgId);
        }
        return strMapPath;
    }

    //hidden the get message image
    public void HiddenLoadingImage()
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "HiddenGetMessageImage", "HiddenGetMessageImage();", true);
    }

    //Start:-EMP-0009
    //allocate mail from inbox to trash
    [WebMethod]
    public static string PushToTrash(string strMailId, string strUserId, string strDivId, string strReasnId, string strDesc)
    {
        clsBusinessLayerMail objBusinessMail = new clsBusinessLayerMail();
        clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
        objEntityMail.Mail_Box_Id = Convert.ToInt64(strMailId);

        objEntityMail.Transaction_Id = Convert.ToInt32(strDivId);
        objEntityMail.User_Id = Convert.ToInt32(strUserId);

        string strResponse = "YES";


        objEntityMail.ReasonId = Convert.ToInt32(strReasnId);
        objEntityMail.Desc = strDesc;

        DataTable dtMailSts = objBusinessMail.ReadMailSts(objEntityMail);
        if (dtMailSts.Rows.Count > 0)
        {
            if (dtMailSts.Rows[0]["MAILACTN_ID"] != DBNull.Value)
            {
                if (Convert.ToInt32(dtMailSts.Rows[0]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Attach))
                {
                    strResponse = "NO";
                    return strResponse;
                }
                else if (Convert.ToInt32(dtMailSts.Rows[0]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Allocate))
                {
                    if (Convert.ToInt32(dtMailSts.Rows[0]["MLBOX_ALLOCATE_USR_ID"]) == Convert.ToInt32(strUserId))
                    {

                    }
                    else
                    {
                        strResponse = "NO";
                        return strResponse;
                    }
                }
                else if (Convert.ToInt32(dtMailSts.Rows[0]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Forward))
                {
                    if (Convert.ToInt32(dtMailSts.Rows[0]["MAIL_TRANS_ID"]) == Convert.ToInt32(strDivId))
                    {

                    }
                    else
                    {
                        strResponse = "NO";
                        return strResponse;
                    }
                }
            }
        }

        if (strResponse == "YES")
        {
            objBusinessMail.PushToTrash(objEntityMail);
        }

        return strResponse;
    }
    //End:-EMP-0009
    //load corporate divisions on the division drop down list
    //Method for assigning corporate departments to the dropdown list
    public void Division_Load(int intItemtId = 0)
    {
        clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
        clsBusinessLayerMail objBusinessLayerMail=new clsBusinessLayerMail();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityMail.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityMail.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }

        DataTable dtDivisions = objBusinessLayerMail.LoadDivisions(objEntityMail);

        ddlDivisions.DataSource = dtDivisions;

        ddlDivisions.DataTextField = "CPRDIV_NAME";
        ddlDivisions.DataValueField = "CPRDIV_ID";
        ddlDivisions.DataBind();

        ddlDivisions.Items.Insert(0, "--SELECT DIVISION--");
       
    }


    //methode for assigning employees on list based on user's  division                   
    public void Employees_Load()
    {

        clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
        clsBusinessLayerMail objBusinessLayerMail = new clsBusinessLayerMail();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityMail.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityMail.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityMail.User_Id = Convert.ToInt32(Session["USERID"].ToString());

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }

        DataTable dtEmployees = objBusinessLayerMail.LoadAllocateUser(objEntityMail);

        ddlEmployee.DataSource = dtEmployees;

        ddlEmployee.DataTextField = "USR_NAME";
        ddlEmployee.DataValueField = "USER_ID";
        ddlEmployee.DataBind();

        ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");

    }


    //methode for all customers in the list based on corporate office
    public void Customers_Load()
    {

        clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
        clsBusinessLayerMail objBusinessLayerMail = new clsBusinessLayerMail();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityMail.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityMail.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityMail.User_Id = Convert.ToInt32(Session["USERID"].ToString());

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }

        DataTable dtCustomers = objBusinessLayerMail.ReadCustomers(objEntityMail);

        ddlCustomer.DataSource = dtCustomers;

        ddlCustomer.DataTextField = "CSTMR_NAME";
        ddlCustomer.DataValueField = "CSTMR_ID";
        ddlCustomer.DataBind();

        ddlCustomer.Items.Insert(0, "--SELECT CUSTOMER--");

    }

    //forward email from one division to other
    [WebMethod]
    public static string ForwardMail(string strDivId, string strMailId, string strUserId, string strCurrentDivision)
    {
        clsEntityMailConsole ObjEntityMail = new clsEntityMailConsole();
        clsBusinessLayerMail ObjBusinessLayerMail = new clsBusinessLayerMail();        

        ObjEntityMail.Mail_Box_Id = Convert.ToInt64(strMailId);
        ObjEntityMail.Transaction_Id = Convert.ToInt32(strDivId);
        ObjEntityMail.User_Id = Convert.ToInt32(strUserId);

        string strResponse = "YES";

        DataTable dtMailSts = ObjBusinessLayerMail.ReadMailSts(ObjEntityMail);
        if (dtMailSts.Rows.Count > 0)
        {
            if (dtMailSts.Rows[0]["MAILACTN_ID"] != DBNull.Value)
            {
                if (Convert.ToInt32(dtMailSts.Rows[0]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Attach))
                {
                    strResponse = "NO";
                    return strResponse;
                }
                else if (Convert.ToInt32(dtMailSts.Rows[0]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Allocate))
                {
                    if (Convert.ToInt32(dtMailSts.Rows[0]["MLBOX_ALLOCATE_USR_ID"]) == Convert.ToInt32(strUserId))
                    {

                    }
                    else
                    {
                        strResponse = "NO";
                        return strResponse;
                    }
                }
                else if (Convert.ToInt32(dtMailSts.Rows[0]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Forward))
                {
                    if (Convert.ToInt32(dtMailSts.Rows[0]["MAIL_TRANS_ID"]) == Convert.ToInt32(strCurrentDivision))
                    {

                    }
                    else
                    {
                        strResponse = "NO";
                        return strResponse;
                    }
                }
            }
        }

        ObjBusinessLayerMail.ForwardMail(ObjEntityMail);
        return strResponse;
    }

    //allocate email to a user
    [WebMethod]
    public static string AllocateEmail(string strMailId, string strUserId, string strDivId, string strCurrentUser)
    {
        clsEntityMailConsole ObjEntityMail = new clsEntityMailConsole();
        clsBusinessLayerMail ObjBusinessLayerMail = new clsBusinessLayerMail();
       
        ObjEntityMail.D_Date = System.DateTime.Now;
        ObjEntityMail.Mail_Box_Id = Convert.ToInt64(strMailId);        
        ObjEntityMail.User_Id = Convert.ToInt32(strUserId);

        string strResponse = "YES";

        DataTable dtMailSts = ObjBusinessLayerMail.ReadMailSts(ObjEntityMail);
        if (dtMailSts.Rows.Count > 0)
        {
            if (dtMailSts.Rows[0]["MAILACTN_ID"] != DBNull.Value)
            {

                if (Convert.ToInt32(dtMailSts.Rows[0]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Attach))
                {
                    strResponse = "NO";
                    return strResponse;
                }
                else if (Convert.ToInt32(dtMailSts.Rows[0]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Allocate))
                {
                    if (Convert.ToInt32(dtMailSts.Rows[0]["MLBOX_ALLOCATE_USR_ID"]) == Convert.ToInt32(strCurrentUser))
                    {

                    }
                    else
                    {
                        strResponse = "NO";
                        return strResponse;
                    }
                }
                else if (Convert.ToInt32(dtMailSts.Rows[0]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Forward))
                {
                    if (Convert.ToInt32(dtMailSts.Rows[0]["MAIL_TRANS_ID"]) == Convert.ToInt32(strDivId))
                    {

                    }
                    else
                    {
                        strResponse = "NO";
                        return strResponse;
                    }
                }
            }
        }


        ObjBusinessLayerMail.AllocateMail(ObjEntityMail);
        return strResponse;
    }

    //reject a allocated mail to previous position
    [WebMethod]
    public static void Reject_Mail(string strMailId)
    {
        clsEntityMailConsole ObjEntityMail = new clsEntityMailConsole();
        clsBusinessLayerMail ObjBusinessLayerMail = new clsBusinessLayerMail();

        ObjEntityMail.Mail_Box_Id = Convert.ToInt64(strMailId);

        ObjBusinessLayerMail.RejectMail(ObjEntityMail);
    }

    //fetch leads details based on date limit and customer id
    [WebMethod]
    public static string SearchLead(string strOrgId, string strCorpId, string strUserId, string strFromDate, string strToDate, string strCustomerId)
    {
        clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
        clsBusinessLayerMail objBusinessMail = new clsBusinessLayerMail();
        clsCommonLibrary objCommon=new clsCommonLibrary();

        objEntityMail.Organisation_Id = Convert.ToInt32(strOrgId);
        objEntityMail.Corporate_Id = Convert.ToInt32(strCorpId);
        objEntityMail.User_Id = Convert.ToInt32(strUserId);
        objEntityMail.From_Date = strFromDate;
        objEntityMail.To_Date = strToDate;
        objEntityMail.Customer_Id = Convert.ToInt32(strCustomerId);

        DataTable dtLeads = objBusinessMail.Search_Leads(objEntityMail);

        string strHtml= ConvertDataTableToHTML(dtLeads, 1);

        Int64 intSize = System.Text.ASCIIEncoding.ASCII.GetByteCount(strHtml);

        if (intSize > 100000)
        {
            strHtml = ConvertDataTableToHTML(dtLeads, 0);
        }

        return strHtml;
       
    }



    public static string ConvertDataTableToHTML(DataTable dt, int intEnableModify)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        string strHtml = "";
        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();

        strHtml = "<table id=\"ReportTable\" class=\"table table-bordered tbl_480\">";
        strHtml += "<thead class=\"thead1\">";
        strHtml += "<tr>";
        strHtml += "<th class=\"col-md-1 tr_l\">Ref#</th>";
        strHtml += "<th class=\"col-md-1\">Date </th>";
        strHtml += "<th class=\"col-md-4 tr_l\">Customer Name</th>";
        strHtml += "<th class=\"col-md-3\">Employee</th>";
        strHtml += "<th class=\"col-md-2\">Status</th>";
        strHtml += "<th class=\"col-md-1\">Actions</th>";
        strHtml += "</tr>";
        strHtml += "</thead>";
        strHtml += "<tbody>";

        if (intEnableModify == 1)
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                strHtml += "<tr>";
                string Id = dt.Rows[intRowBodyCount]["LEADS_ID"].ToString();

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {
                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a></td>";
                    }
                    if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 5)
                    {
                        strHtml += "<td style=\"word-break: break-all; word-wrap:break-word;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                }

                strHtml += "<td>";
                strHtml += "<button class=\"btn act_btn bn1\" title=\"Merge\" onclick='return MailLeadAttach(" + Id + ");'>";
                strHtml += "<i class=\"fa fa-compress\"></i>";
                strHtml += "</button>";
                strHtml += "</td>";

                strHtml += "</tr>";
            }

            if (dt.Rows.Count == 0)
            {
                strHtml += "<tr>";
                strHtml += "<td class=\"tr_c\" colspan=\"6\" >" + "There Is No Leads For Attach" + "</td>";
                strHtml += "</tr>";
            }
        }
        else if (intEnableModify == 0)
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tr_c\" colspan=\"6\" >" + "Please Reduce The Date Limit" + "</td>";
            strHtml += "</tr>";
        }

        strHtml += "</tbody>";
        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
    }

    //attach a mail to a lead
    [WebMethod]
    public static string MailLeadAttach(string strOrgId, string strCorpId, string strUserId, string strLeadId, string strMailId, string strDivId)
    {
        clsEntityMailConsole ObjEntityMail = new clsEntityMailConsole();
        clsBusinessLayerMail ObjBusinessLayerMail = new clsBusinessLayerMail();


        ObjEntityMail.Organisation_Id = Convert.ToInt32(strOrgId);
        ObjEntityMail.Corporate_Id = Convert.ToInt32(strCorpId);
        ObjEntityMail.User_Id = Convert.ToInt32(strUserId);
        ObjEntityMail.Lead_Id = Convert.ToInt64(strLeadId);
        ObjEntityMail.Mail_Box_Id = Convert.ToInt64(strMailId);

        string strResponse = "YES";

        DataTable dtMailSts = ObjBusinessLayerMail.ReadMailSts(ObjEntityMail);
        if (dtMailSts.Rows.Count > 0)
        {
            if (dtMailSts.Rows[0]["MAILACTN_ID"] != DBNull.Value)
            {

                if (Convert.ToInt32(dtMailSts.Rows[0]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Attach))
                {
                    strResponse = "NO";
                    return strResponse;
                }
                else if (Convert.ToInt32(dtMailSts.Rows[0]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Allocate))
                {
                    if (Convert.ToInt32(dtMailSts.Rows[0]["MLBOX_ALLOCATE_USR_ID"]) == Convert.ToInt32(strUserId))
                    {

                    }
                    else
                    {
                        strResponse = "NO";
                        return strResponse;
                    }
                }
                else if (Convert.ToInt32(dtMailSts.Rows[0]["MAILACTN_ID"]) == Convert.ToInt32(clsCommonLibrary.Mail_Actions.Forward))
                {
                    if (Convert.ToInt32(dtMailSts.Rows[0]["MAIL_TRANS_ID"]) == Convert.ToInt32(strDivId))
                    {

                    }
                    else
                    {
                        strResponse = "NO";
                        return strResponse;
                    }
                }
            }
        }

        ObjBusinessLayerMail.MailLeadAttach(ObjEntityMail);
        return strResponse;

    }


    //Start:-EMP-0009
    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTMLSelectOptions(DataTable dtSelect)
    {

        //add options

        string strOptn = "";
        for (int i = 0; i < dtSelect.Rows.Count; i++)
        {

            strOptn += "<option ";

            for (int j = 0; j < dtSelect.Columns.Count; j++)
            {
                if (j == 0)
                {//id
                    strOptn += "value=\"" + dtSelect.Rows[i][j].ToString() + "\">";
                }
                if (j == 1)
                {//name
                    strOptn += dtSelect.Rows[i][j].ToString();
                }


            }
            strOptn += "</option>";
        }
        string strDynamicOptions = strOptn;
        return strDynamicOptions;

    }
    //End:-EMP-0009
    [WebMethod]
    public static string[] CheckMailCount(string evt, string CorpId, string OrgId, string UserId, string AllMail)
    {
        clsBusinessLayerMail objBusinessLayerMail = new clsBusinessLayerMail();
        clsEntityMailConsole objEntityMail = new clsEntityMailConsole();

        string[] StrOutArray = new string[1];

        objEntityMail.Corporate_Id = Convert.ToInt32(CorpId);

        objEntityMail.Organisation_Id = Convert.ToInt32(OrgId);

        objEntityMail.Email_Store = Convert.ToInt32(evt);

        objEntityMail.User_Id = Convert.ToInt32(UserId);

        objEntityMail.All_Mail_Enable = Convert.ToInt32(AllMail);

        DataTable dtMails = objBusinessLayerMail.Read_Mail_Box(objEntityMail);



        StrOutArray[0] = Convert.ToString(dtMails.Rows.Count);
       
        return StrOutArray;

    }


    //------------------------------------------Pagination------------------------------------------------

    [WebMethod]
    public static string[] GetData(string OrgId, string CorpId, string UserId, string AllMailEnable, string MailStore, string PageNumber, string PageMaxSize, string strCommonSearchTerm, string OrderColumn, string OrderMethod, string strInputColumnSearch)
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        clsBusinessLayerMail objBusinessLayerMail = new clsBusinessLayerMail();
        clsEntityMailConsole objEntityMail = new clsEntityMailConsole();

        clsCommonLibrary objCommon = new clsCommonLibrary();

        string[] strResults = new string[3];
        try
        {
            if (OrgId != null && OrgId != "")
            {
                objEntityMail.Organisation_Id = Convert.ToInt32(OrgId);
            }
            if (CorpId != null && CorpId != "")
            {
                objEntityMail.Corporate_Id = Convert.ToInt32(CorpId);
            }
            if (UserId != null && UserId != "")
            {
                objEntityMail.User_Id = Convert.ToInt32(UserId);
            }
            objEntityMail.All_Mail_Enable = Convert.ToInt32(AllMailEnable);
            objEntityMail.Email_Store = Convert.ToInt32(MailStore);

            objEntityMail.PageNumber = Convert.ToInt32(PageNumber);
            objEntityMail.PageMaxSize = Convert.ToInt32(PageMaxSize);
            objEntityMail.OrderMethod = Convert.ToInt32(OrderMethod);
            objEntityMail.OrderColumn = Convert.ToInt32(OrderColumn);
            objEntityMail.CommonSearchTerm = strCommonSearchTerm;

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

            //ReadList
            DataTable dt = objBusinessLayerMail.Read_Mail_Box(objEntityMail);

            string strTableContents = "";
            strTableContents = Read_Mail_Box_Full(dt, objEntityMail);
            strResults[0] = strTableContents;

            strResults[1] = dt.Rows.Count.ToString();

            if (dt.Rows.Count > 0)
            {
                int intTotalItems = Convert.ToInt32(dt.Rows[0]["CNT"].ToString());
                int intCurrentRowCount = dt.Rows.Count;

                strResults[1] = intTotalItems.ToString();
                //Pagination
                strResults[2] = objBusinessLayer.GenereatePagination(intTotalItems, objEntityMail.PageNumber, objEntityMail.PageMaxSize, intCurrentRowCount);
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
    public static string[] LoadStaticDatafordt(string MailStore)//Filters
    {
        StringBuilder html = new StringBuilder();
        StringBuilder sbSearchInputColumns = new StringBuilder();

        string[] strResults = new string[3];
        html.Append("<div>");
        html.Append("</div>");
        strResults[0] = html.ToString();

        //custom search fields
        var values = Enum.GetValues(typeof(SearchInputColumns));
        int intSearchColumnCount = values.Length;

        string strTableHTML = "";
        
        strTableHTML = strTableHTML + "<th class=\"th_b1_4\">";
        if (MailStore != "3")
        {
            strTableHTML = strTableHTML + "<span class=\"button-checkbox flt_l\">";
            strTableHTML = strTableHTML + "<button type=\"button\" class=\"active btn-p\" data-color=\"p\" ng-model=\"all\" onclick=\"CheckAll();\"><i class=\"state-icon fa fa-check-square-o\"></i>Â&nbsp;</button>";
            strTableHTML = strTableHTML + "<input id=\"cbxAll\" type=\"checkbox\" class=\"hidden\">";
            strTableHTML = strTableHTML + "</span>";
        }
        strTableHTML = strTableHTML + "<span class=\"spn_atc_ml\" title=\"Attachment\" data-placement=\"top\" data-toggle=\"tooltip\"><i class=\"fa fa-paperclip\"></i></span>";
        strTableHTML = strTableHTML + "<span class=\"spn_atc_ml flt_r\" title=\"New Mail\" data-placement=\"top\" data-toggle=\"tooltip\"><i class=\"fa fa-envelope\"></i></span>";
        strTableHTML = strTableHTML + "</th>";
        strTableHTML = strTableHTML + "<th class=\"th_b2 tr_l\">Subject </th>";
        strTableHTML = strTableHTML + "<th class=\"th_b4 tr_l\">From</th>";
        strTableHTML = strTableHTML + "<th class=\"th_b6 tr_l\">Division</th>";
        strTableHTML = strTableHTML + "<th class=\"th_b7\">Date and Time</th>";
        strTableHTML = strTableHTML + "<th class=\"th_b1\">Status</th>";
        strTableHTML = strTableHTML + "<th class=\"th_b4\">Actions</th>";

        sbSearchInputColumns.Append(strTableHTML);

        //this is to adjust the non search  fields
        strResults[1] = sbSearchInputColumns.ToString();
        strResults[2] = intSearchColumnCount.ToString();
        return strResults;
    }

    public enum SearchInputColumns
    {
        //Must be sequential 
    }

    //------------------------------------------Pagination------------------------------------------------



}