using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using CL_Compzit;
using System.Web.Services;
using BL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;

public partial class HCM_HCM_Master_hcm_Exit_Management_hcm_Exit_Partial_Process_hcm_Exit_Partial_Process_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //creating object for business layer

            clsEntityLayerExitPartialProcess objEntityExitPartialProcess = new clsEntityLayerExitPartialProcess();
            clsBusinessLayerExitPartialProcess objBusinessExitPartialProcess = new clsBusinessLayerExitPartialProcess();

            EmployeeLoad();

            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();


            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                objEntityExitPartialProcess.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityExitPartialProcess.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityExitPartialProcess.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Exit_Partial_Process);
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
                }

                hiddenEnableModify.Value = Convert.ToString(intEnableModify);
                hiddenEnableAdd.Value = Convert.ToString(intEnableAdd);

                objEntityExitPartialProcess.Mode = 2;

                DataTable dtEmpList = new DataTable();
                dtEmpList = objBusinessExitPartialProcess.ReadEmployeeExit(objEntityExitPartialProcess);

                string strHtm = ConvertDataTableToHTML(dtEmpList, intEnableAdd, intEnableModify);
                //Write to divReport
                divReport.InnerHtml = strHtm;

            }


        }
    }
    //load employees

    public void EmployeeLoad()
    {
        clsEntityLayerExitPartialProcess objEntityExitPartialProcess = new clsEntityLayerExitPartialProcess();
        clsBusinessLayerExitPartialProcess objBusinessExitPartialProcess = new clsBusinessLayerExitPartialProcess();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityExitPartialProcess.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityExitPartialProcess.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityExitPartialProcess.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtEmp = new DataTable();
        dtEmp = objBusinessExitPartialProcess.ReadToddlDesignation(objEntityExitPartialProcess);
        ddlDesig.Items.Clear();

        if (dtEmp.Rows.Count > 0)
        {
            ddlDesig.DataSource = dtEmp;
            ddlDesig.DataTextField = "DSGN_NAME";
            ddlDesig.DataValueField = "DSGN_ID";
            ddlDesig.DataBind();
        }

        ddlDesig.Items.Insert(0, "--SELECT DESIGNATION--");
    }


    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableAdd, int intEnableModify)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:25%;text-align: left; word-wrap:break-word;\"> EMPLOYEE ID</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:21%;text-align: center; word-wrap:break-word;\">EMPLOYEE NAME</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: center; word-wrap:break-word;\">DESIGNATION</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:25%;text-align: center; word-wrap:break-word;\">DEPARTMET</th>";
            }
            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:25%;text-align: center; word-wrap:break-word;\">LEAVING DATE</th>";
            }
        }
        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: center; word-wrap:break-word;\"></th>";

        strHtml += "<th class=\"thT\" style=\"width:4%;text-align: center; word-wrap:break-word;\">EDIT</th>";


        strHtml += "</tr>";


        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr  >";

            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

              string strUserID = dt.Rows[intRowBodyCount]["USR_ID"].ToString();
            int intUserIDLength = dt.Rows[intRowBodyCount]["USR_ID"].ToString().Length;
            string strUserIDLength = intUserIDLength.ToString("00");
            string UserID = strUserIDLength + strUserID + strRandom;

            
         


            string mode = "";


            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE ID"].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:21%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE NAME"].ToString() + "</td>";
                }
                if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["DESIGNATION"].ToString() + "</td>";

                }
                if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";

                }
                if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["LEAVING DATE"].ToString() + "</td>";

                }

            }
            strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\"><input type=\"button\" class=\"save\" style=\"height:22px;margin-top:3%\" value=\"VIEW\" onclick=\"return JobDescrpId('" + Id + "','" + UserID + "');\" /></td>";
            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a style=\"opacity:2;\"  title=\"Edit\" onclick='return getdetails(this.href);' " +
                        " href=\"hcm_Exit_Partial_Process.aspx?Id=" + Id + "&Usr=" + UserID + "\">" + "<img  style=\" cursor:pointer;\" src='/Images/Icons/edit.png' /> " + "</a> </td>";


            strHtml += "</tr>";

        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
    }



    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsEntityLayerExitPartialProcess objEntityExitPartialProcess = new clsEntityLayerExitPartialProcess();
        clsBusinessLayerExitPartialProcess objBusinessExitPartialProcess = new clsBusinessLayerExitPartialProcess();

        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityExitPartialProcess.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityExitPartialProcess.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityExitPartialProcess.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (ddlDesig.SelectedItem.Value != "--SELECT DESIGNATION--")
        {
            objEntityExitPartialProcess.DesigID = Convert.ToInt32(ddlDesig.SelectedItem.Value);
        }

        if (txtAssgndDate.Text != null && txtAssgndDate.Text != "")
        {
            objEntityExitPartialProcess.AsgndDate = objCommon.textToDateTime(txtAssgndDate.Text.Trim());
        }
        if (txtToDate.Text != null && txtToDate.Text != "")
        {
            objEntityExitPartialProcess.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
        }

     

        int intEnableModify = 0, intEnableAdd = 0;

        intEnableModify = Convert.ToInt32(hiddenEnableModify.Value);
        intEnableAdd = Convert.ToInt32(hiddenEnableAdd.Value);

        DataTable dtEmpList = new DataTable();
        dtEmpList = objBusinessExitPartialProcess.ReadEmployeeExit(objEntityExitPartialProcess);

        string strHtm = ConvertDataTableToHTML(dtEmpList, intEnableAdd, intEnableModify);
        //Write to divReport
        divReport.InnerHtml = strHtm;

    }




}