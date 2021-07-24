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

public partial class HCM_HCM_Master_hcm_LeaveMaster_hcm_Leave_Partial_Process_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //creating object for business layer

            clsEntity_Leave_PartialProcess objEntityLeavePartialPrcs = new clsEntity_Leave_PartialProcess();
            clsBusiness_Leave_PartialProcess objBusinessLeavePartialPrcs = new clsBusiness_Leave_PartialProcess();

            EmployeeLoad();

            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

       
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                objEntityLeavePartialPrcs.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLeavePartialPrcs.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityLeavePartialPrcs.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Leave_Partial_Process);
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

                objEntityLeavePartialPrcs.Mode = 2;

                DataTable dtEmpList = new DataTable();
                dtEmpList = objBusinessLeavePartialPrcs.ReadEmployeeLeave(objEntityLeavePartialPrcs);
                
                string strHtm = ConvertDataTableToHTML(dtEmpList, intEnableAdd, intEnableModify);
                //Write to divReport
                divReport.InnerHtml = strHtm;

            }


        }

    }

    //load employees

    public void EmployeeLoad()
    {
        clsEntity_Leave_PartialProcess objEntityLeavePartialPrcs = new clsEntity_Leave_PartialProcess();
        clsBusiness_Leave_PartialProcess objBusinessLeavePartialPrcs = new clsBusiness_Leave_PartialProcess();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLeavePartialPrcs.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityLeavePartialPrcs.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtEmp = new DataTable();
        dtEmp = objBusinessLeavePartialPrcs.ReadToddlEmployee(objEntityLeavePartialPrcs);
        ddlEmployee.Items.Clear();

        if (dtEmp.Rows.Count > 0)
        {
            ddlEmployee.DataSource = dtEmp;
            ddlEmployee.DataTextField = "USR_NAME";
            ddlEmployee.DataValueField = "USR_ID";
            ddlEmployee.DataBind();
        }

        ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");
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
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE NAME</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                   
                strHtml += "<th class=\"thT\" style=\"width:18%;text-align: center; word-wrap:break-word;\">DESIGNATION</th>";
            }
            if (intColumnHeaderCount ==4)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">DEPARTMENT</th>";
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">DIVISION</th>";
            }

        }


        strHtml += "<th class=\"thT\" style=\"width:6%;text-align: center; word-wrap:break-word;\">MODE</th>";

        strHtml += "<th class=\"thT\" style=\"width:20%;text-align: center; word-wrap:break-word;\">LEAVE RANGE</th>";

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

            string strLevId = dt.Rows[intRowBodyCount]["LEAVE_ID"].ToString();
            int intLevIdLength = dt.Rows[intRowBodyCount]["LEAVE_ID"].ToString().Length;
            string stridLevLength = intLevIdLength.ToString("00");
            string levId = stridLevLength + strLevId + strRandom;


            string mode = "";


            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + " <a   style=\"cursor:pointer;color: blue;\"  title=\"View\" onclick=\"return PartPrssId('" + Id + "','" + levId + "');\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</a> </td>";
                  //  strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE NAME"].ToString() + "</td>";
                }
                if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["DESIGNATION"].ToString() + "</td>";
                }
                if (intColumnBodyCount == 4)
                {
                    clsEntity_Leave_PartialProcess objEntityLeavePartialPrcs = new clsEntity_Leave_PartialProcess();
                    clsBusiness_Leave_PartialProcess objBusinessLeavePartialPrcs = new clsBusiness_Leave_PartialProcess();

                    objEntityLeavePartialPrcs.EmpId = Convert.ToInt32(strId);

                    if (Session["CORPOFFICEID"] != null)
                    {
                        objEntityLeavePartialPrcs.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                    }
                    else if (Session["CORPOFFICEID"] == null)
                    {
                        Response.Redirect("/Default.aspx");
                    }
                    if (Session["ORGID"] != null)
                    {
                        objEntityLeavePartialPrcs.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                    }
                    else if (Session["ORGID"] == null)
                    {
                        Response.Redirect("/Default.aspx");
                    }

                    DataTable dtEmp = new DataTable();
                    dtEmp = objBusinessLeavePartialPrcs.ReadDivsnEmp(objEntityLeavePartialPrcs);

                    string strEmpDiv = "";
                    string[] DivData = new string[7];
                    if (dtEmp.Rows.Count > 0)
                    {
                        foreach (DataRow dtrow in dtEmp.Rows)
                        {
                            strEmpDiv = dtrow["CPRDIV_NAME"] + " , " + strEmpDiv;
                        }
                    }
                    DivData[0] = strEmpDiv.TrimEnd(" , ".ToCharArray());

                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + DivData[0] + "</td>";
                  
                }
                

            }
          
             
            if (dt.Rows[intRowBodyCount]["MODE"].ToString() == "0")
            {
                mode = "STAFF";
            }
            if (dt.Rows[intRowBodyCount]["MODE"].ToString() == "1")
            {
                mode = "WORKER";
            }
            strHtml += "<td class=\"tdT\" style=\" width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + mode + "</td>";

            if (dt.Rows[intRowBodyCount]["LEAVE_TO_DATE"].ToString() != "" && dt.Rows[intRowBodyCount]["LEAVE_TO_DATE"].ToString() != null)
            {
                strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["LEAVE_FROM_DATE"].ToString() + " TO " + dt.Rows[intRowBodyCount]["LEAVE_TO_DATE"].ToString() + "</td>";
            }
            else
            {
                strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["LEAVE_FROM_DATE"].ToString() + "</td>";
            }

            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a style=\"opacity:2;margin-top:-1.3%;\"  class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                        " href=\"hcm_Leave_Partial_Process.aspx?Id=" + Id +"&levId="+ levId + "\">" + "<img  style=\" cursor:pointer;\" src='/Images/Icons/edit.png' /> " + "</a> </td>";


            strHtml += "</tr>";

        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
    }



    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsEntity_Leave_PartialProcess objEntityLeavePartialPrcs = new clsEntity_Leave_PartialProcess();
        clsBusiness_Leave_PartialProcess objBusinessLeavePartialPrcs = new clsBusiness_Leave_PartialProcess();

        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLeavePartialPrcs.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityLeavePartialPrcs.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityLeavePartialPrcs.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
        {
            objEntityLeavePartialPrcs.EmpId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
        }

        if (txtAssgndDate.Text != null && txtAssgndDate.Text != "")
        {
            objEntityLeavePartialPrcs.AsgndDate = objCommon.textToDateTime(txtAssgndDate.Text.Trim());
        }
        if (txtToDate.Text != null && txtToDate.Text != "")
        {
            objEntityLeavePartialPrcs.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
        }

        if (radioStaff.Checked == true)
        {
            objEntityLeavePartialPrcs.Mode = 0;
        }
        else if (radioWorker.Checked == true)
        {
            objEntityLeavePartialPrcs.Mode = 1;
        }
        else if (radioAll.Checked == true)
        {
            objEntityLeavePartialPrcs.Mode = 2;
        }

        int intEnableModify = 0, intEnableAdd = 0;

        intEnableModify = Convert.ToInt32(hiddenEnableModify.Value);
        intEnableAdd = Convert.ToInt32(hiddenEnableAdd.Value);

        DataTable dtEmpList = new DataTable();
        dtEmpList = objBusinessLeavePartialPrcs.ReadEmployeeLeave(objEntityLeavePartialPrcs);

        string strHtm = ConvertDataTableToHTML(dtEmpList, intEnableAdd, intEnableModify);
        //Write to divReport
        divReport.InnerHtml = strHtm;

    }












}
