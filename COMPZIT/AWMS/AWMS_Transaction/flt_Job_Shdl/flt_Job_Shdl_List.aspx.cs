using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using BL_Compzit;
using EL_Compzit;
using CL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_AWMS;
using System.Data;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
// CREATED BY:EVM-0001
// CREATED DATE:23/12/2016
// REVIEWED BY:
// REVIEW DATE:


public partial class AWMS_AWMS_Transaction_flt_Job_Shdl_flt_Job_Shdl_List : System.Web.UI.Page
{
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int intUserId = 0, intUsrRolMstrId, intUsrRolMstrIdRecallCancelled, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecallCancelled = 0;         
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            bool blShowCancel = false;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            HiddenUserId.Value = Convert.ToString(intUserId);



            intUsrRolMstrIdRecallCancelled = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
            DataTable dtChildRolRecallCancelled = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrIdRecallCancelled);
            if (dtChildRolRecallCancelled.Rows.Count > 0)
            {
                intEnableRecallCancelled = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Job_Schedule);
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

                }

               


                //Creating object for business layer and data table
                clsBusinessLayerJobShdl objBusinessLayerJobShdl = new clsBusinessLayerJobShdl();
                clsEntityLayerJobSchedule objEntityJobShdl = new clsEntityLayerJobSchedule();



                if (Session["ORGID"] != null)
                {
                    objEntityJobShdl.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }

                if (Session["CORPOFFICEID"] != null)
                {

                    objEntityJobShdl.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
            
                string strHtm = "";
                DataTable dtUser = new DataTable();
                dtUser = objBusinessLayerJobShdl.ReadEmployeeJSList(objEntityJobShdl);
                strHtm = ConvertDataTableToHTML(dtUser, intEnableModify, intEnableCancel, intEnableRecallCancelled, intUserId, blShowCancel);

                //Write to divReport
                divReport.InnerHtml = strHtm;
                if (Request.QueryString["InsUpd"] != null)
                {
                    string strInsUpd = Request.QueryString["InsUpd"].ToString();
                    if (strInsUpd == "Save")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationSave", "SuccessConfirmationSave();", true);
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
                    else if (strInsUpd == "Reopen")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReOpen", "SuccessReOpen();", true);
                    }
                    else if (strInsUpd == "NotReOpen")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "FailureReOpen", "FailureReOpen();", true);
                    }
                    else if (strInsUpd == "Confirm")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                    }
                }
            }
        }
    }
    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intEnableRecallCancelled, int intUserId, bool blShowCancelled)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerJobShdl objBusinessLayerJobShdl = new clsBusinessLayerJobShdl();
        clsEntityLayerJobSchedule objEntityJobShdl = new clsEntityLayerJobSchedule();
        DataTable dtNoJS = new DataTable();
        
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            //if (i == 0)
            //{
            //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
            //}
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
         


        }
        for (int i = 1; i <= 10; i++)
        {
            strHtml += "<th class=\"thT\" style=\"width:2%; word-wrap:break-word;text-align: center;\">schedule"+i+"</th>";
        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            
           // int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            //int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

            strHtml += "<tr  >";



            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                //if (j == 0)
                //{
                //    int intCnt = i + 1;
                //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                //}
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
               
            }
            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

            int redBn = 0, greenBn = 0;
            objEntityJobShdl.JobSchdlUserId = Convert.ToInt32(dt.Rows[intRowBodyCount][0]);
            dtNoJS = objBusinessLayerJobShdl.ReadEmployeeNoOfJSList(objEntityJobShdl);
            for (int i = 0; i < dtNoJS.Rows.Count; i++)
            {
                string strShdlId = dtNoJS.Rows[i][0].ToString();
                int intShdlIdLength = dtNoJS.Rows[i][0].ToString().Length;
                string strShdlIdLength = intShdlIdLength.ToString("00");
                string ShdlId = strShdlIdLength + strShdlId + strRandom;
                DateTime strFromDate = Convert.ToDateTime(dtNoJS.Rows[i]["JOBSHDL_FROM_DATE"].ToString());
                DateTime strToDate = Convert.ToDateTime(dtNoJS.Rows[i]["JOBSHDL_TO_DATE"].ToString());
                DateTime strToday = DateTime.Today;
                if ((strFromDate <= strToday) && (strToday <= strToDate))
                {

                    if (dtNoJS.Rows[i]["JOBSHDL_CNFRM_USR_ID"].ToString() != "" && dtNoJS.Rows[i]["JOBSHDL_CNFRM_USR_ID"].ToString() != null)
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" +

                        " <a  class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                              " href=\"flt_Job_Shdl.aspx?Id=" + Id + "&ShdlId=" + ShdlId + "\">" +

                              "<img  style=\"width:26%\" src='/Images/Icons/view.png' /> " + "</a>" +
                        " <a  class=\"tooltip\" title=\"Close\" onclick=\"CloseSchedule('" + ShdlId + "'); \">" +
                              "<img  style=\"width:20%;cursor:pointer\" src='/Images/Icons/close.png' /> " + "</a>" +
                               "</td>";
                    }
                    else
                    {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" +
                      
                     " <a  class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                           " href=\"flt_Job_Shdl.aspx?Id=" + Id + "&ShdlId=" + ShdlId + "\">" +

                           "<img  style=\"width:20%\" src='/Images/Icons/edit.png' /> " + "</a>" +
                     " <a  class=\"tooltip\" title=\"Close\" onclick=\"CloseSchedule('" + ShdlId + "'); \">" +
                           "<img  style=\"width:20%;cursor:pointer\" src='/Images/Icons/close.png' /> " + "</a>" +
                            "</td>";
                    }
                    //confirm
                   /* strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" +
                               " <a  class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                               " href=\"flt_Job_Shdl.aspx?ViewId=" + Id + "&ShdlId=" + ShdlId + "\">" + "<img  style=\"width:13%\" src='/Images/Icons/confirm.png' /> " +
                               "</a> </td>";*/
                    redBn = redBn + 1;
                }
            }
             for (int i = 0; i < dtNoJS.Rows.Count; i++)
            {
                string strShdlId = dtNoJS.Rows[i][0].ToString();
                int intShdlIdLength = dtNoJS.Rows[i][0].ToString().Length;
                string strShdlIdLength = intShdlIdLength.ToString("00");
                string ShdlId = strShdlIdLength + strShdlId + strRandom;
                DateTime strFromDate = Convert.ToDateTime(dtNoJS.Rows[i]["JOBSHDL_FROM_DATE"].ToString());
                DateTime strToDate = Convert.ToDateTime(dtNoJS.Rows[i]["JOBSHDL_TO_DATE"].ToString());
                DateTime strToday = DateTime.Today;
                if ((strFromDate <= strToday) == false || (strToday <= strToDate) == false)
                {
                    if ((strFromDate > strToday) && (strToDate > strToday))
                    {
                        if (dtNoJS.Rows[i]["JOBSHDL_CNFRM_USR_ID"].ToString() != "" && dtNoJS.Rows[i]["JOBSHDL_CNFRM_USR_ID"].ToString() != null)
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" +

                          " <a  class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                                " href=\"flt_Job_Shdl.aspx?Id=" + Id + "&ShdlId=" + ShdlId + "\">" +
                                "<img  style=\"width:26%\" src='/Images/Icons/view.png' /> " + "</a>" +
                          " <a  class=\"tooltip\" title=\"Close\" onclick=\"CloseSchedule('" + ShdlId + "'); \">" +
                                "<img  style=\"width:20%;cursor:pointer\" src='/Images/Icons/close.png' /> " + "</a>" +
                                 "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" +

                           " <a  class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                 " href=\"flt_Job_Shdl.aspx?Id=" + Id + "&ShdlId=" + ShdlId + "\">" +
                                 "<img  style=\"width:26%\" src='/Images/Icons/imgEdit.png' /> " + "</a>" +
                           " <a  class=\"tooltip\" title=\"Close\" onclick=\"CloseSchedule('" + ShdlId + "'); \">" +
                                 "<img  style=\"width:20%;cursor:pointer\" src='/Images/Icons/close.png' /> " + "</a>" +
                                  "</td>";
                        }
                        greenBn = greenBn + 1;
                    }
                    //Assign_symbol
                  /*  else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" +
                                     " <a  class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                                     " href=\"flt_Job_Shdl.aspx?ViewId=" + Id + "&ShdlId=" + ShdlId + "\">" + "<img  style=\"width:20%\" src='/Images/Icons/Assign_symbol.png' /> " +
                                     "</a> </td>";
                        greenBn = greenBn + 1;
                    }*/
                }
            }
           
           
     
           
            for (int i = 1; i <= 10 - (redBn + greenBn); i++)
            {
                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" +
                " <a  class=\"tooltip\" title=\"Add\" onclick='return getdetails(this.href);' " +
                " href=\"flt_Job_Shdl.aspx?EmpId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/add.png' /> " +
                "</a> </td>";

            }
            strHtml += "</tr>";

        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
    }
    //for creating HTML Title
    private string SetTitle(string size, string value)
    {

        return "<h" + size + "><p align=center>" + value + "</p align></h" + size + ">";

    }

    [WebMethod]
    public static string CloseSchedule(string strShdlId,string strUsrId)
    {
        string ret = "";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerJobShdl objBusinessLayerJobShdl = new clsBusinessLayerJobShdl();
        clsEntityLayerJobSchedule objEntityJobShdl = new clsEntityLayerJobSchedule();

        string strLenghtofId1 = strShdlId.Substring(0, 2);
        int intLenghtofId1 = Convert.ToInt16(strLenghtofId1);
        string strId1 = strShdlId.Substring(2, intLenghtofId1);
        int intJobSchdlId = Convert.ToInt32(strId1);
        objEntityJobShdl.JobSchdlId = Convert.ToInt32(intJobSchdlId);
        objEntityJobShdl.User_Id = Convert.ToInt32(strUsrId);      
        objEntityJobShdl.D_Date = System.DateTime.Now;
        objEntityJobShdl.CancelReason = objCommon.CancelReason();
       
        try
        {
            objBusinessLayerJobShdl.CloseSchedule(objEntityJobShdl);
            ret = "success";

        }
        catch
        {
            ret = "failed";
        }
        return ret;

    }
    protected void btnRsnSave_Click(object sender, EventArgs e)
    {


        
    }


    //at previous records show button click
    protected void btnPrevious_Click(object sender, EventArgs e)
    {
       
    }




    //at next records show button click
    protected void btnNext_Click(object sender, EventArgs e)
    {
    }





  

    //at search button click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
    }
}