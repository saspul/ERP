using BL_Compzit.BusinessLayer_GMS;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CL_Compzit;
using EL_Compzit;
using BL_Compzit;
using System.Web.Services;
using BL_Compzit.BusinessLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using System.Xml;
using System.Web.Script.Serialization;
using System.Globalization;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public partial class HCM_HCM_Master_hcm_OnBoarding_hcm_Leave_Management_hcm_Leave_Management_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ddlStatus.Focus();
        ddlStatus.Attributes.Add("onkeypress", "return isTag(event)");
        ddlAprvlSts.Attributes.Add("onkeypress", "return isTag(event)");
        txtFromDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtTodate.Attributes.Add("onkeypress", "return isTag(event)");
        if (!IsPostBack)
        {
            clsBusinessLeaveRequest objBusinessLeaveRequest = new clsBusinessLeaveRequest();
            clsEntityLeaveRequest objEntityLeaveRequest = new clsEntityLeaveRequest();
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                objEntityLeaveRequest.User_Id = intUserId;
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Leave_Request);
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
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                }



                if (Session["USERID"] != null)
                {
                    objEntityLeaveRequest.User_Id = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityLeaveRequest.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityLeaveRequest.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                objEntityLeaveRequest.DateOfTrvl = System.DateTime.Now;
                objEntityLeaveRequest.Leave_Id = Convert.ToInt32(ddlStatus.SelectedItem.Value);
                DataTable dtAssgndProcess = new DataTable();
                dtAssgndProcess = objBusinessLeaveRequest.ReadLeaveRqstList(objEntityLeaveRequest);
                string strHtm = ConvertDataTableToHTML(dtAssgndProcess, intEnableAdd, intEnableModify);
                //Write to divReport
                divReport.InnerHtml = strHtm;

                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    divAdd.Visible = true;

                }
                else
                {

                    divAdd.Visible = false;

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
                else if (strInsUpd == "Cncl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                }
                else if (strInsUpd == "Recl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessRecall", "SuccessRecall();", true);
                }
                else if (strInsUpd == "ReOpen")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReOpen", "SuccessReOpen();", true);
                }
            }
        }
    }
      //at search button click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
           clsBusinessLeaveRequest objBusinessLeaveRequest = new clsBusinessLeaveRequest();
            clsEntityLeaveRequest objEntityLeaveRequest = new clsEntityLeaveRequest();
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                objEntityLeaveRequest.User_Id = intUserId;
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Leave_Request);
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
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                }



                if (Session["USERID"] != null)
                {
                    objEntityLeaveRequest.User_Id = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityLeaveRequest.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityLeaveRequest.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                objEntityLeaveRequest.DateOfTrvl = System.DateTime.Now;
                objEntityLeaveRequest.Leave_Id = Convert.ToInt32(ddlStatus.SelectedItem.Value);
                objEntityLeaveRequest.StatsSrch = Convert.ToInt32(ddlAprvlSts.SelectedItem.Value);
                if (txtFromDate.Text.Trim() != "")
                {
                    objEntityLeaveRequest.LeaveFrmDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
                }
                if (txtTodate.Text.Trim() != "")
                {
                    objEntityLeaveRequest.LeaveToDate = objCommon.textToDateTime(txtTodate.Text.Trim());
                }

                DataTable dtAssgndProcess = new DataTable();
                dtAssgndProcess = objBusinessLeaveRequest.ReadLeaveRqstList(objEntityLeaveRequest);
                string strHtm = ConvertDataTableToHTML(dtAssgndProcess, intEnableAdd, intEnableModify);
                //Write to divReport
                divReport.InnerHtml = strHtm;
            }
    }
    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableAdd, int intEnableModify)
    {
        clsEntityLeaveRequest objEntityLeaveRequest = new clsEntityLeaveRequest();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

    
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">DATE FROM</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">DATE TO</th>";
            }

            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:40%;text-align: left; word-wrap:break-word;\">LEAVE TYPE</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:25%;text-align: center; word-wrap:break-word;\">STATUS</th>";
            }
           

        }
        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: center; word-wrap:break-word;\"></th>";
        if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            strHtml += "<th class=\"thT\" style=\"width:4%;text-align: center; word-wrap:break-word;\">EDIT</th>";
        }
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";

        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            string status = dt.Rows[intRowBodyCount]["STATUS"].ToString();

            if (status=="NEW"){
                if (dt.Rows[intRowBodyCount]["LEAVE_CNFRM_STS"].ToString() == "1")
                {
                    status = "APPROVAL PENDING";
                }
            }
            else if (status == "CANCELLED")
            {

                if (dt.Rows[intRowBodyCount]["LEAVE_CLS_USR_ID"].ToString() != "")
                {
                    status = "CLOSED";
                }
                else if (dt.Rows[intRowBodyCount]["LEAVE_DIV_MAN_APPROVAL"].ToString() == "0")
                {
                    status = "CANCEL PENDING";
                }
                else if (dt.Rows[intRowBodyCount]["LEAVE_DIV_MAN_APPROVAL"].ToString() == "1")
                {
                    status = "CANCELLED";
                }
            }

            DateTime toate = System.DateTime.Now;
            DateTime fromdate = Convert.ToDateTime(dt.Rows[intRowBodyCount]["LEAVE_FROM_DATE"].ToString());
            if (dt.Rows[intRowBodyCount]["LEAVE_TO_DATE"].ToString() != "")
            {
            toate = Convert.ToDateTime(dt.Rows[intRowBodyCount]["LEAVE_TO_DATE"].ToString());
            }
            DateTime Now = System.DateTime.Now;

           
            string show = "false";

            if (ddlStatus.SelectedItem.Value == "0")
            {
                if (dt.Rows[intRowBodyCount]["TO DATE"].ToString() != "")
                {
                    if (toate.Date >= Now.Date)
                    {
                        show = "true";
                    }
                }
                else
                {
                    if (fromdate.Date >= Now.Date)
                    {
                        show = "true";
                    }

                }

            }
            else
            {

                if (dt.Rows[intRowBodyCount]["TO DATE"].ToString() != "")
                {
                    if (toate.Date < Now.Date)
                    {
                        show = "true";
                    }
                }
                else
                {
                    if (fromdate.Date < Now.Date)
                    {
                        show = "true";
                    }

                }
            }


            if (show == "true")
            {
                strHtml += "<tr>";



                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;


                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {
                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" +
                               dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }

                    else if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:40%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + status + "</td>";
                    }


                }
                if (ddlStatus.SelectedItem.Value == "0")
                {
                    strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\"><input type=\"button\" class=\"save\" style=\"height:22px;margin-top:3%\" value=\"VIEW\" onclick=\"return LeavRqstId('" + Id + "');\" /></td>";

                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\"><input type=\"button\" class=\"save\" style=\"height:22px;margin-top:3%\" value=\"VIEW\" onclick=\"return LeavRqstExpId('" + Id + "');\" /></td>";
                }
              
                if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                   
                    if (ddlStatus.SelectedItem.Value == "0")
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a style=\"opacity:2;margin-top:-1.3%;\"  class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                " href=\"hcm_Leave_Request.aspx?Id=" + Id + "\">" + "<img  style=\" cursor:pointer;\" src='/Images/Icons/edit.png' /> " + "</a> </td>";

                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a style=\"opacity:2;margin-top:-1.3%;\"  class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                                        " href=\"hcm_Leave_Request.aspx?Id=" + Id + "&Sts=Exp\">" + "<img  style=\" cursor:pointer;\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                    }
                }

                strHtml += "</tr>";

            }


        }




        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    protected void btnRsnSave_Click(object sender, EventArgs e)
    {

    }
}