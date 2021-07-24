using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HCM_HCM_Master_hcm_Exit_Management_hcm_Exit_intrvw_Process_hcm_Exit_intrvw_Process_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Designation();
            EmployeeLoad();
            int intUserId = 0, intUsrRolMstrId = 0, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
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
            clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess = new clsEntityLayer_Exit_Intrvw_Process();
            clsBusinessLayer_Exit_Intrvw_Process objBusinessExitIntrvwProcess = new clsBusinessLayer_Exit_Intrvw_Process();

            DataTable dtCorpDetail = new DataTable();
            int intCorpId = 0;

            if (Session["CORPOFFICEID"] != null)
            {
                //objEntityExitIntrvwProcess.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                //intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                //objEntityExitIntrvwProcess.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Request.QueryString["InsUpd"] == "Ins")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessIns", "SuccessIns();", true);
            }
            else if (Request.QueryString["InsUpd"] == "Upd")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
            }
            DataTable dtProductSrch = new DataTable();

            dtProductSrch = objBusinessExitIntrvwProcess.ReadDtlsList(objEntityExitIntrvwProcess);

            string strHtm = ConvertDataTableToHTML(dtProductSrch);
            //Write to divReport
            divReport.InnerHtml = strHtm;
        }
    }
    public void Designation()
    {
        clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess = new clsEntityLayer_Exit_Intrvw_Process();
        clsBusinessLayer_Exit_Intrvw_Process objBusinessExitIntrvwProcess = new clsBusinessLayer_Exit_Intrvw_Process();
        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityExitIntrvwProcess.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityExitIntrvwProcess.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtDivision = objBusinessExitIntrvwProcess.ReadDesignation(objEntityExitIntrvwProcess);
        if (dtDivision.Rows.Count > 0)
        {
            ddlDesg.Items.Clear();
            ddlDesg.DataSource = dtDivision;


            ddlDesg.DataValueField = "DSGN_ID";
            ddlDesg.DataTextField = "DSGN_NAME";



            //ddlProjct.DataValueField = "PROJECT_ID";
            ddlDesg.DataBind();

        }
        ddlDesg.Items.Insert(0, "--SELECT DESIGNATION--");

    }

    public void EmployeeLoad()
    {
        clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess = new clsEntityLayer_Exit_Intrvw_Process();
        clsBusinessLayer_Exit_Intrvw_Process objBusinessExitIntrvwProcess = new clsBusinessLayer_Exit_Intrvw_Process();
        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityExitIntrvwProcess.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityExitIntrvwProcess.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtDivision = objBusinessExitIntrvwProcess.ReadEmployee(objEntityExitIntrvwProcess);
        if (dtDivision.Rows.Count > 0)
        {
            ddlEmp.Items.Clear();
            ddlEmp.DataSource = dtDivision;
            

            ddlEmp.DataValueField = "USR_ID";
            ddlEmp.DataTextField = "USR_NAME";



            //ddlProjct.DataValueField = "PROJECT_ID";
            ddlEmp.DataBind();

        }
        ddlEmp.Items.Insert(0, "--SELECT EMPLOYEE--");
        //ddlEmp.Items.FindByValue(intUserId.ToString()).Selected = true;
    }
    public string ConvertDataTableToHTML(DataTable dt)
    {
       
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
            //if (i == 0)
            //{
            //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
            //}
            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:25%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";
            }
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:30%;text-align: left; word-wrap:break-word;\">EMPLOYEE NAME</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:25%;text-align: left; word-wrap:break-word;\">DESIGNATION</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:30%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";
            }

        }
        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\"></th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">INTERVIEW</th>";
        
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";


        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            //int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            // int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

            strHtml += "<tr  >";

            string strId = dt.Rows[intRowBodyCount][4].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][4].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

            string strUsrId = dt.Rows[intRowBodyCount][0].ToString();
            int intUsrIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string strUsridLength = intUsrIdLength.ToString("00");
            string UsrId = strUsridLength + strUsrId + strRandom;

            string strMstrId = dt.Rows[intRowBodyCount][6].ToString();
            int intMstrIdLength = dt.Rows[intRowBodyCount][6].ToString().Length;
            string strMstridLength = intMstrIdLength.ToString("00");
            string MstrId = strMstridLength + strMstrId + strRandom;
            
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 0)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</td>";
                }
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_NAME"].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DSGN_NAME"].ToString() + "</td>";
                }
                if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CPRDEPT_NAME"].ToString() + "</td>";
                
                   
                }
                if (intColumnBodyCount == 4)
                {
                    if (dt.Rows[intRowBodyCount]["QUESTION DESG"].ToString() != "" && dt.Rows[intRowBodyCount]["INTRVW_MSTR_ID"].ToString() != "")
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\"><input type=\"button\" class=\"save\" style=\"height:22px;margin-top:3%\" value=\"VIEW\" onclick=\"return IntervPrssWithMstrId('" + Id + "','" + UsrId + "','" + MstrId + "');\" /></td>";
                        strHtml += "<td class=\"tdT\" style=\"width:10%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Interview\" " +
                                                 " href=\"hcm_Exit_intrvw_Process.aspx?Id=" + Id + "&UserId=" + UsrId + "&MstrId=" + MstrId + "\">" + "<img style=\"width:25%;\"  src='/Images/Icons/interviewprocess.png' /> " + "</a> </td>";
                    }
                    //if (dt.Rows[intRowBodyCount]["QUESTION DESG"].ToString() != "" && dt.Rows[intRowBodyCount]["INTRVW_MSTR_ID"].ToString() == "")
                    //{  
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\"><input type=\"button\" class=\"save\" style=\"height:22px;margin-top:3%\" value=\"VIEW\" onclick=\"return IntervPrssId('" + Id + "','" + UsrId + "');\" /></td>";
                        strHtml += "<td class=\"tdT\" style=\"width:10%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Interview\" " +
                                                 " href=\"hcm_Exit_intrvw_Process.aspx?Id=" + Id + "&UserId=" + UsrId + "&MstrId=\">" + "<img style=\"width:25%;\"  src='/Images/Icons/interviewprocess.png' /> " + "</a> </td>";
                    }
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
        clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess = new clsEntityLayer_Exit_Intrvw_Process();
        clsBusinessLayer_Exit_Intrvw_Process objBusinessExitIntrvwProcess = new clsBusinessLayer_Exit_Intrvw_Process();
        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityExitIntrvwProcess.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityExitIntrvwProcess.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (ddlDesg.SelectedItem.Value != "--SELECT DESIGNATION--" && ddlEmp.SelectedItem.Value == "--SELECT EMPLOYEE--")
            {
                int desg= Convert.ToInt32(ddlDesg.SelectedItem.Value);
                objEntityExitIntrvwProcess.DesgId = desg;
                objEntityExitIntrvwProcess.SearchSts = 0;
            }
        if (ddlEmp.SelectedItem.Value != "--SELECT EMPLOYEE--" && ddlEmp.SelectedItem.Value == "--SELECT DESIGNATION--")
            {
                int emp = Convert.ToInt32(ddlEmp.SelectedItem.Value);
                objEntityExitIntrvwProcess.EmpId = emp;
                objEntityExitIntrvwProcess.SearchSts = 1;
            }
        if (ddlDesg.SelectedItem.Value != "--SELECT DESIGNATION--" && ddlEmp.SelectedItem.Value != "--SELECT EMPLOYEE--")
            {
                int desg1 = Convert.ToInt32(ddlDesg.SelectedItem.Value);
                objEntityExitIntrvwProcess.DesgId = desg1;
                
                int emp1 = Convert.ToInt32(ddlEmp.SelectedItem.Value);
                objEntityExitIntrvwProcess.EmpId = emp1;
                objEntityExitIntrvwProcess.SearchSts = 2;
            }
        if (ddlDesg.SelectedItem.Value == "--SELECT DESIGNATION--" && ddlEmp.SelectedItem.Value == "--SELECT EMPLOYEE--")
        {
            objEntityExitIntrvwProcess.SearchSts = 3;
        }
        DataTable dtProductSrch = new DataTable();

        dtProductSrch = objBusinessExitIntrvwProcess.ReadBySearch(objEntityExitIntrvwProcess);

        string strHtm = ConvertDataTableToHTML(dtProductSrch);
        divReport.InnerHtml = strHtm;
    }
}