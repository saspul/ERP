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
using System.Web.Services;


public partial class HCM_HCM_Master_hcm_LeaveMaster_hcm_LeaveFacltyAssmntList_hcm_LeaveFacltyAssmntList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        radioAssigned.Attributes.Add("onkeypress", "return DisableEnter(event)");
        radioNotAssigned.Attributes.Add("onkeypress", "return DisableEnter(event)");
        RadioStaff.Attributes.Add("onkeypress", "return DisableEnter(event)");
        RadioWorker.Attributes.Add("onkeypress", "return DisableEnter(event)");
        RadioAll.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlEmploy.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtLeavRangeFrm.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtLeavRangeTo.Attributes.Add("onkeypress", "return DisableEnter(event)");

        txtTargetDate2.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtTargetDate3.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtTargetDate4.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtTargetDate6.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtTargetDate7.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtTargetDate8.Attributes.Add("onkeypress", "return DisableEnter(event)");
        


        if (!IsPostBack)
        {
            HiddenAirlinNoteneed.Value = "0";
            HiddenAirlineneed.Value = "0";
            HiddenUpdateChk.Value = "";
            HiddenAdd.Value = "0";
            HiddenEdit.Value = "0";
            clsBusiness_LeaveFacltyAssmntList objBusinessOnboard = new clsBusiness_LeaveFacltyAssmntList();
            clsEntity_LeaveFacltyAssmntList objEntityOnBoard = new clsEntity_LeaveFacltyAssmntList();
            int intUserId = 0, intUsrRolMstrId;
            if (Session["USERID"] != null)
            {
                objEntityOnBoard.UserId = Convert.ToInt32(Session["USERID"]);
                                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityOnBoard.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityOnBoard.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            FillDropdown();
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Leave_Facility_Assignment);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            int intEnableModify = 0, intEnableAdd = 0;
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intEnableAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenAdd.Value = "1";
                   
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenEdit.Value = "1";
                    }
                
                }
            }
            if (intEnableAdd == 0)
            {
                btnOnBoard.Visible = false;
            }
          
           radioNotAssigned.Checked = true;
           RadioAll.Checked = true;



            DataTable dtCandidateList = new DataTable();
            dtCandidateList = objBusinessOnboard.ReadEmployeesList(objEntityOnBoard);
            

            string strHtm = ConvertDataTableToHTMLNotAssigned(dtCandidateList);
           divReport.InnerHtml = strHtm;
            


            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "PrcsAsgn")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessIns", "SuccessIns();", true);
                }
                else if (strInsUpd == "PrcsAsgnUpd")
                {
                    HiddenUpdateChk.Value = "1";
                    btnOnBoard.Visible = false;
                    objEntityOnBoard.StatusId = 1;
                    radioAssigned.Checked = true;
                    radioNotAssigned.Checked = false;
                    dtCandidateList = objBusinessOnboard.ReadEmployeesList(objEntityOnBoard);
                    strHtm = ConvertDataTableToHTMLAssigned(dtCandidateList);
                    divReport.InnerHtml = strHtm;
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
                else if (strInsUpd == "Rcl")
                {
                    HiddenUpdateChk.Value = "1";
                    btnOnBoard.Visible = false;
                    objEntityOnBoard.StatusId = 1;
                    radioAssigned.Checked = true;
                    radioNotAssigned.Checked = false;
                    dtCandidateList = objBusinessOnboard.ReadEmployeesList(objEntityOnBoard);
                    strHtm = ConvertDataTableToHTMLAssigned(dtCandidateList);
                    divReport.InnerHtml = strHtm;
            
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessRecall", "SuccessRecall();", true);
                }
                else if (strInsUpd == "Cls")
                {
                    HiddenUpdateChk.Value = "1";
                    btnOnBoard.Visible = false;
                    objEntityOnBoard.StatusId = 1;
                    radioAssigned.Checked = true;
                    radioNotAssigned.Checked = false;
                    dtCandidateList = objBusinessOnboard.ReadEmployeesList(objEntityOnBoard);
                    strHtm = ConvertDataTableToHTMLAssigned(dtCandidateList);
                    divReport.InnerHtml = strHtm;
            
                   
                }
                

            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsBusiness_LeaveFacltyAssmntList objBusinessOnboard = new clsBusiness_LeaveFacltyAssmntList();
        clsEntity_LeaveFacltyAssmntList objEntityOnBoard = new clsEntity_LeaveFacltyAssmntList();

        if (Session["USERID"] != null)
        {
            objEntityOnBoard.UserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityOnBoard.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityOnBoard.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strHidden = "";
       strHidden= HiddenSearchField.Value;

        string[] strSearchFields = strHidden.Split(',');
        string strFromDate = strSearchFields[0];
        string strToDate = strSearchFields[1];


        if (strFromDate != null && strFromDate != "")
        {

            objEntityOnBoard.FromDate = objCommon.textToDateTime(strFromDate);

        }


        if (strToDate != null && strToDate != "")
        {
            objEntityOnBoard.ToDate= objCommon.textToDateTime(strToDate);
        }
       
        if (RadioStaff.Checked == true)
        {

            objEntityOnBoard.RadioStaffChk = 1;
        }
        else if (RadioWorker.Checked == true)
        {
            objEntityOnBoard.RadioStaffChk = 2;
        }
        else if (RadioAll.Checked == true)
        {
            objEntityOnBoard.RadioStaffChk = 0;
        }
        if (radioNotAssigned.Checked == true)
        {
            if (HiddenAdd.Value == "1")
            {
                btnOnBoard.Visible = true;
            }
            objEntityOnBoard.StatusId = 0;

            if (ddlEmploy.SelectedItem.Value != "--SELECT EMPLOYEE--")
            {
                objEntityOnBoard.EmployeeId = Convert.ToInt32(ddlEmploy.SelectedItem.Value);
            }
            DataTable dtCandidateList = objBusinessOnboard.ReadEmployeesList(objEntityOnBoard);
            string strHtm = ConvertDataTableToHTMLNotAssigned(dtCandidateList);
            divReport.InnerHtml = strHtm;

        }
        else
        {
            btnOnBoard.Visible = false;
            objEntityOnBoard.StatusId = 1;
            if (ddlEmploy.SelectedItem.Value != "--SELECT EMPLOYEE--")
            {
                objEntityOnBoard.EmployeeId = Convert.ToInt32(ddlEmploy.SelectedItem.Value);
            }

            DataTable dtCandidateList = objBusinessOnboard.ReadEmployeesList(objEntityOnBoard);
            string strHtm = ConvertDataTableToHTMLAssigned(dtCandidateList);
            divReport.InnerHtml = strHtm;
        }

    }
    public void FillDropdown()
    {
        clsBusiness_LeaveFacltyAssmntList objBusinessOnboard = new clsBusiness_LeaveFacltyAssmntList();
        clsEntity_LeaveFacltyAssmntList objEntityOnBoard = new clsEntity_LeaveFacltyAssmntList();
        if (Session["USERID"] != null)
        {
            objEntityOnBoard.UserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityOnBoard.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityOnBoard.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtLevEmployee = objBusinessOnboard.ReadLevEmployee(objEntityOnBoard);
        if (dtLevEmployee.Rows.Count > 0)
        {
            ddlEmploy.DataSource = dtLevEmployee;
            ddlEmploy.DataTextField = "USR_NAME";
            ddlEmploy.DataValueField = "USR_ID";
            ddlEmploy.DataBind();

        }

        ddlEmploy.Items.Insert(0, "--SELECT EMPLOYEE--");

        DataTable dtEmployee = objBusinessOnboard.ReadEmployee(objEntityOnBoard);
        if (dtEmployee.Rows.Count > 0)
        {

        

            ddlEmp1.DataSource = dtEmployee;
            ddlEmp1.DataTextField = "USR_NAME";
            ddlEmp1.DataValueField = "USR_ID";
            ddlEmp1.DataBind();

            ddlEmp2.DataSource = dtEmployee;
            ddlEmp2.DataTextField = "USR_NAME";
            ddlEmp2.DataValueField = "USR_ID";
            ddlEmp2.DataBind();

            ddlEmp3.DataSource = dtEmployee;
            ddlEmp3.DataTextField = "USR_NAME";
            ddlEmp3.DataValueField = "USR_ID";
            ddlEmp3.DataBind();

            ddlEmp4.DataSource = dtEmployee;
            ddlEmp4.DataTextField = "USR_NAME";
            ddlEmp4.DataValueField = "USR_ID";
            ddlEmp4.DataBind();

          

            ddlEmp6.DataSource = dtEmployee;
            ddlEmp6.DataTextField = "USR_NAME";
            ddlEmp6.DataValueField = "USR_ID";
            ddlEmp6.DataBind();

            ddlEmp7.DataSource = dtEmployee;
            ddlEmp7.DataTextField = "USR_NAME";
            ddlEmp7.DataValueField = "USR_ID";
            ddlEmp7.DataBind();

            ddlEmp8.DataSource = dtEmployee;
            ddlEmp8.DataTextField = "USR_NAME";
            ddlEmp8.DataValueField = "USR_ID";
            ddlEmp8.DataBind();


        }


    }

    public string ConvertDataTableToHTMLAssigned(DataTable dt)
    {

        clsBusiness_LeaveFacltyAssmntList objBusinessOnboard = new clsBusiness_LeaveFacltyAssmntList();
        clsEntity_LeaveFacltyAssmntList objEntityOnBoard = new clsEntity_LeaveFacltyAssmntList();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        //int intimgsection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
        //string imgpath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">SL#</th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {


            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE NAME</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">DESIGNATION</th>";
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";
            }
           
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">DIVISION</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: left; word-wrap:break-word;\">MODE</th>";
            }
           
              
            
        }
        strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: center; word-wrap:break-word;\">LEAVE RANGE</th>";
        if (HiddenEdit.Value == "1")
        {
            strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: center; word-wrap:break-word;\">EDIT</th>";
        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        hiddenRowCount.Value = dt.Rows.Count.ToString();
        strHtml += "<tbody>";
        int count = 0;
        string strdidchk = "";
        if (dt.Rows.Count == 0)
        {
           


            strHtml += "<td  class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  >No Data Available</td>";
            strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
           //strHtml += "<td  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            if (HiddenEdit.Value == "1")
            {
                strHtml += "<td  class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  ></td>";
            }
        }
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            count++;
            strHtml += "<tr  >";

            strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count + "</td>";

            string strId = dt.Rows[intRowBodyCount][0].ToString();
            

            objEntityOnBoard.EmployeeId = Convert.ToInt32(dt.Rows[intRowBodyCount]["EMPLOYEE ID"]);
            DataTable dtDivisions = objBusinessOnboard.ReadDivisionOfEmp(objEntityOnBoard);

            string strDivisions = "";
            foreach (DataRow dtDiv in dtDivisions.Rows)
            {
                if (strDivisions == "")
                {
                    strDivisions = strDivisions + dtDiv["DIVISION"];
                }
                else
                {
                    strDivisions = dtDiv["DIVISION"] + "," + strDivisions;
                }
            }
               

            string reference = "";
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DESIGNATION"].ToString() + "</td>";

                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";

                }
                
                else if (intColumnBodyCount == 4)
                {
                    

                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + strDivisions + "</td>";
                }
                else if (intColumnBodyCount ==5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["MODE"].ToString() + "</td>";

                }
               
            }
            if (dt.Rows[intRowBodyCount]["LEAVE_TO_DATE"].ToString() != "" && dt.Rows[intRowBodyCount]["LEAVE_TO_DATE"].ToString()!=null)
                strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["LEAVE_FROM_DATE"].ToString() + " TO " + dt.Rows[intRowBodyCount]["LEAVE_TO_DATE"].ToString() + "</td>";
            else
                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["LEAVE_FROM_DATE"].ToString() + "</td>";
            string FlightChk = "0";
            if (dt.Rows[intRowBodyCount]["LEAVE_NEED_TRVL_TCKT"].ToString() == "1")
            {
                FlightChk = "1";
            }
            string LeavId = dt.Rows[intRowBodyCount]["LEAVE_ID"].ToString();
            string StffWrkr = dt.Rows[intRowBodyCount]["STAFF_WORKER"].ToString();
            objEntityOnBoard.LeavId =Convert.ToInt32( LeavId);
            DataTable dtStaffWorker;
            if (StffWrkr == "0")
            {
                 dtStaffWorker = objBusinessOnboard.ReadStaffdtl(objEntityOnBoard);
            }
            else
            {
                 dtStaffWorker = objBusinessOnboard.ReadWorkerDtl(objEntityOnBoard);
            }
            string staffworker = "";
            if (dtStaffWorker.Rows.Count > 0)
            {
                staffworker = dtStaffWorker.Rows[0]["LVECLRWKR_APPRVL_STS"].ToString();
            }
            if (HiddenEdit.Value == "1")
            {
                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"><a class=\"tooltip\" title=\"Edit\" onclick=\"return ProcessEdit('" + strId + "','" + FlightChk + "','" + LeavId + "','" + staffworker + "');\" ><img  style=\"cursor:pointer;margin-left: 10%;float: left;\" src='/Images/Icons/edit.png' /></a> </td>";
            }


            strHtml += "<td id=\"tdcandiateid" + intRowBodyCount + "\"  class=\"tdT\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount][0].ToString() + "</td>";
            strHtml += "<td id=\"tdLevid" + intRowBodyCount + "\"  class=\"tdT\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount]["LEAVE_ID"].ToString() + "</td>";
            strHtml += "<td id=\"tdAirlinePrfed" + intRowBodyCount + "\"  class=\"tdT\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount]["LEAVE_NEED_TRVL_TCKT"].ToString() + "</td>";
            strHtml += "</tr>";

        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }

    public string ConvertDataTableToHTMLNotAssigned(DataTable dt)
    {


        clsBusiness_LeaveFacltyAssmntList objBusinessOnboard = new clsBusiness_LeaveFacltyAssmntList();
        clsEntity_LeaveFacltyAssmntList objEntityOnBoard = new clsEntity_LeaveFacltyAssmntList();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">SL#</th>";
        strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: left; word-wrap:break-word;\"><input type=\"checkbox\" Id=\"cbxSelectAll\" style=\"margin-left: 23%;\"onkeypress=\"return DisableEnter(event);\" onchange=\"selectAllCandidate()\"></th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {


            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";
            }
            if (intColumnHeaderCount ==2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE NAME</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">DESIGNATION</th>";
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";
            }
          
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">DIVISION</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: left; word-wrap:break-word;\">MODE</th>";
            }
           

        }
        strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: center; word-wrap:break-word;\">LEAVE RANGE</th>";
        strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: center; word-wrap:break-word;display:none\">LEAVE RANGE</th>";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        hiddenRowCount.Value = dt.Rows.Count.ToString();
        strHtml += "<tbody>";
        int count = 0;
        string strdidchk = "";
        if (dt.Rows.Count > 0)
        {
           
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                count++;
                strHtml += "<tr  >";

                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count + "</td>";
                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" Id=\"cblcandidatelist" + intRowBodyCount + "\"true\" onkeypress=\"return DisableEnter(event);\" onchange=\"IncrmntConfrmCounter()\"></td>";

                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                objEntityOnBoard.EmployeeId = Convert.ToInt32(dt.Rows[intRowBodyCount]["EMPLOYEE ID"]);
                DataTable dtDivisions = objBusinessOnboard.ReadDivisionOfEmp(objEntityOnBoard);

                string strDivisions = "";
                foreach (DataRow dtDiv in dtDivisions.Rows)
                {
                    if (strDivisions == "")
                    {
                        strDivisions = strDivisions + dtDiv["DIVISION"];
                    }
                    else
                    {
                        strDivisions = dtDiv["DIVISION"] + "," + strDivisions;
                    }
                }
               
                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DESIGNATION"].ToString() + "</td>";

                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";
                    
                        
                    }
                   
                    else if (intColumnBodyCount == 4)
                    {

                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + strDivisions + "</td>";
                    }
                    else if (intColumnBodyCount ==5)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["MODE"].ToString() + "</td>";

                    }
                   

                }
                if (dt.Rows[intRowBodyCount]["LEAVE_TO_DATE"].ToString() != "" && dt.Rows[intRowBodyCount]["LEAVE_TO_DATE"].ToString() != null)
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["LEAVE_FROM_DATE"].ToString() + " TO " + dt.Rows[intRowBodyCount]["LEAVE_TO_DATE"].ToString() + "</td>";
                else
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["LEAVE_FROM_DATE"].ToString() + "</td>";
                strHtml += "<td id=\"tdcandiateid" + intRowBodyCount + "\"  class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount][0].ToString() + "</td>";
                strHtml += "<td id=\"tdLevid" + intRowBodyCount + "\"  class=\"tdT\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount]["LEAVE_ID"].ToString() + "</td>";
                strHtml += "<td id=\"tdAirlinePrfed" + intRowBodyCount + "\"  class=\"tdT\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount]["LEAVE_NEED_TRVL_TCKT"].ToString() + "</td>";
                strHtml += "</tr>";

            }
        }
        else
        {
            strHtml += "<td  class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  >No Data Available</td>";
            strHtml += "<td  class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
           strHtml += "<td  class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  ></td>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }

    protected void btnProcessMultySave_Click(object sender, EventArgs e)
    {
        clsBusiness_LeaveFacltyAssmntList objBusinessOnboard = new clsBusiness_LeaveFacltyAssmntList();
        clsEntity_LeaveFacltyAssmntList objEntityOnBoard = new clsEntity_LeaveFacltyAssmntList();
        clsCommonLibrary ObjCommon = new clsCommonLibrary();

        if (Session["USERID"] != null)
        {
            objEntityOnBoard.UserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityOnBoard.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityOnBoard.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

       // objEntityOnBoard.ReqstID = Convert.ToInt32(ddlManPower.SelectedItem.Value);

        int intLeavFacltyId = objBusinessOnboard.Insert_LeaveFacltyAssmnt(objEntityOnBoard);

        string strTotalLeavId = HiddenLeavId.Value;
        string[] strEachLeavId = strTotalLeavId.Split(',');


        string strTotalCandidate = Hiddenchecklist.Value;
        string[] strEachCandidate = strTotalCandidate.Split(',');


        string strAirChk = HiddenAirLine.Value;
        string[] strEachAirchk = strAirChk.Split(',');


        clsEntity_LeaveFacltyAssmntList objEntityOnBoardFlight = new clsEntity_LeaveFacltyAssmntList();
        clsEntity_LeaveFacltyAssmntList objEntitySettlment = new clsEntity_LeaveFacltyAssmntList();
        clsEntity_LeaveFacltyAssmntList objEntityExitProcess = new clsEntity_LeaveFacltyAssmntList();

        List<clsEntity_LeaveFacltyAssmntList> objEntityOnBoardVisaEmpList2 = new List<clsEntity_LeaveFacltyAssmntList>();
        List<clsEntity_LeaveFacltyAssmntList> objEntityOnBoardVisaEmpList3 = new List<clsEntity_LeaveFacltyAssmntList>();
        List<clsEntity_LeaveFacltyAssmntList> objEntityOnBoardVisaEmpList4 = new List<clsEntity_LeaveFacltyAssmntList>();
        int LevCount=0;
        foreach (string strCandId in strEachCandidate)
        {
            if (strCandId != "")
            {
               string FlihtChk= strEachAirchk[LevCount];
               string Levid = strEachLeavId[LevCount];
               if (FlihtChk=="1")
                {

            
                objEntityOnBoardFlight.LevFacltyAssmntId = intLeavFacltyId;
                objEntityOnBoardFlight.CandId = Convert.ToInt32(strCandId);
                objEntityOnBoardFlight.LeavId =Convert.ToInt32(Levid);
                objEntityOnBoardFlight.ParticularId = 0;
                objEntityOnBoardFlight.StatusId = Convert.ToInt32(ddlFlightStatus.SelectedItem.Value);
                objEntityOnBoardFlight.UsrDate = ObjCommon.textToDateTime(txtTargetDate2.Text);
               // objEntityOnBoardFlight.FlightTypeId = Convert.ToInt32(ddlFlightTcktType.SelectedItem.Value);

                objEntityOnBoardFlight.Finishstatus = 0;

                objEntityOnBoardFlight.CloseStatusId = 0;

                string TotalEmp2 = hiddenEmp2.Value;

                string[] EachEmpId2 = TotalEmp2.Split(',');

                foreach (string EmpId2 in EachEmpId2)
                {
                    if (EmpId2 != "")
                    {
                        clsEntity_LeaveFacltyAssmntList objEntityOnBoardFlightEmp = new clsEntity_LeaveFacltyAssmntList();
                        objEntityOnBoardFlightEmp.EmployeeId = Convert.ToInt32(EmpId2);
                        objEntityOnBoardVisaEmpList2.Add(objEntityOnBoardFlightEmp);
                    }
                }
                }

                objEntitySettlment.LevFacltyAssmntId = intLeavFacltyId;
                objEntitySettlment.CandId = Convert.ToInt32(strCandId);
                objEntitySettlment.LeavId = Convert.ToInt32(Levid);
                objEntitySettlment.ParticularId = 2;
                objEntitySettlment.StatusId = Convert.ToInt32(ddlSettlment.SelectedItem.Value);
                DateTime date1 = new DateTime();
                date1 = ObjCommon.textToDateTime(txtTargetDate3.Text);
                string strdate1 = date1.ToString("dd/MM/yyyy");
                objEntitySettlment.UsrDate = ObjCommon.textToDateTime(strdate1);
              //  objEntitySettlment.RoomTypeId = Convert.ToInt32(ddlRoomAltmntType.SelectedItem.Value);

                objEntitySettlment.Finishstatus = 0;

                objEntitySettlment.CloseStatusId = 0;

                string TotalEmp3 = hiddenEmp3.Value;

                string[] EachEmpId3 = TotalEmp3.Split(',');

                foreach (string EmpId3 in EachEmpId3)
                {
                    if (EmpId3 != "")
                    {
                        clsEntity_LeaveFacltyAssmntList objEntityOnBoardSettlment = new clsEntity_LeaveFacltyAssmntList();
                        objEntityOnBoardSettlment.EmployeeId = Convert.ToInt32(EmpId3);
                        objEntityOnBoardVisaEmpList3.Add(objEntityOnBoardSettlment);
                    }
                }


                objEntityExitProcess.LevFacltyAssmntId = intLeavFacltyId;
                objEntityExitProcess.CandId = Convert.ToInt32(strCandId);
                objEntityOnBoardFlight.LeavId = Convert.ToInt32(Levid);
                objEntityExitProcess.ParticularId = 3;
                objEntityExitProcess.StatusId = Convert.ToInt32(ddlExitprcss.SelectedItem.Value);
                objEntityExitProcess.UsrDate = ObjCommon.textToDateTime(txtTargetDate4.Text);
              //  objEntityOnBoardAirport.VehicleId = Convert.ToInt32(ddlVehicle.SelectedItem.Value);

                objEntityExitProcess.Finishstatus = 0;

                objEntityExitProcess.CloseStatusId = 0;

                string TotalEmp4 = hiddenEmp4.Value;

                string[] EachEmpId4 = TotalEmp4.Split(',');

                foreach (string EmpId4 in EachEmpId4)
                {
                    if (EmpId4 != "")
                    {
                        clsEntity_LeaveFacltyAssmntList objEntityOnBoardExitProcss = new clsEntity_LeaveFacltyAssmntList();
                        objEntityOnBoardExitProcss.EmployeeId = Convert.ToInt32(EmpId4);
                        objEntityOnBoardVisaEmpList4.Add(objEntityOnBoardExitProcss);
                    }
                }


                objBusinessOnboard.Insert_Process_Detail(objEntityOnBoard, objEntityOnBoardFlight, objEntitySettlment, objEntityExitProcess, objEntityOnBoardVisaEmpList2, objEntityOnBoardVisaEmpList3, objEntityOnBoardVisaEmpList4, FlihtChk);
            }
            LevCount++;

        }

        Response.Redirect("hcm_LeaveFacltyAssmntList.aspx?InsUpd=PrcsAsgn");
    }

    protected void btnProcessSingleSave_Click(object sender, EventArgs e)
    {
        clsBusiness_LeaveFacltyAssmntList objBusinessOnboard = new clsBusiness_LeaveFacltyAssmntList();
        clsEntity_LeaveFacltyAssmntList objEntityOnBoard = new clsEntity_LeaveFacltyAssmntList();
        clsCommonLibrary ObjCommon = new clsCommonLibrary();
        if (Session["USERID"] != null)
        {
            objEntityOnBoard.UserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityOnBoard.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityOnBoard.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
     
        clsEntity_LeaveFacltyAssmntList objEntityOnBoardFlight = new clsEntity_LeaveFacltyAssmntList();
        clsEntity_LeaveFacltyAssmntList objEntityOnBoardRoom = new clsEntity_LeaveFacltyAssmntList();
        clsEntity_LeaveFacltyAssmntList objEntityOnBoardAirport = new clsEntity_LeaveFacltyAssmntList();
       
        List<clsEntity_LeaveFacltyAssmntList> objEntityOnBoardVisaEmpList2 = new List<clsEntity_LeaveFacltyAssmntList>();
        List<clsEntity_LeaveFacltyAssmntList> objEntityOnBoardVisaEmpList3 = new List<clsEntity_LeaveFacltyAssmntList>();
        List<clsEntity_LeaveFacltyAssmntList> objEntityOnBoardVisaEmpList4 = new List<clsEntity_LeaveFacltyAssmntList>();
        int intCandId = Convert.ToInt32(hiddenCandidateId.Value);
        
int Levid=Convert.ToInt32(HiddenUpdLevid.Value);
int FlghtChk = Convert.ToInt32(HiddenUpdFlghtChk.Value);

       
        string FinishStsTotal = hiddenFinishStatus.Value;
        string CoseStsTotal = hiddenCloseStatus.Value;
     
        string TotalEmp = hiddenEmp1.Value;

        if (HiddenPrtclrChk.Value != "0")
        {

            if (FlghtChk == 1)
            {

                objEntityOnBoardFlight.LevFacltyAssmntDtlId = Convert.ToInt32(hiddenOnBoardDtlId2.Value);
                objEntityOnBoardFlight.CandId = Convert.ToInt32(intCandId);
                objEntityOnBoardFlight.LeavId = Levid;
                objEntityOnBoardFlight.ParticularId = 0;
                objEntityOnBoardFlight.StatusId = Convert.ToInt32(ddlFlightStatus2.SelectedItem.Value);
                DateTime date1 = new DateTime();
                date1 = ObjCommon.textToDateTime(txtTargetDate6.Text);
                string strdate1 = date1.ToString("dd/MM/yyyy");
                objEntityOnBoardFlight.UsrDate = ObjCommon.textToDateTime(strdate1);

                if (FinishStsTotal.Contains("Flight"))
                {
                    objEntityOnBoardFlight.Finishstatus = 1;
                    objEntityOnBoardFlight.FinishDate = DateTime.Today;
                }
                else
                {
                    objEntityOnBoardFlight.Finishstatus = 0;
                }

                if (CoseStsTotal.Contains("Flight"))
                {
                    objEntityOnBoardFlight.CloseStatusId = 1;
                    objEntityOnBoardFlight.CloseDate = DateTime.Today;
                }
                else
                {
                    objEntityOnBoardFlight.CloseStatusId = 0;
                }

                string TotalEmp2 = hiddenEmp2.Value;

                string[] EachEmpId2 = TotalEmp2.Split(',');

                foreach (string EmpId2 in EachEmpId2)
                {
                    if (EmpId2 != "")
                    {
                        clsEntity_LeaveFacltyAssmntList objEntityOnBoardFlightEmp = new clsEntity_LeaveFacltyAssmntList();
                        objEntityOnBoardFlightEmp.CorpOffice = objEntityOnBoard.CorpOffice;
                        objEntityOnBoardFlightEmp.LevFacltyAssmntDtlId = Convert.ToInt32(hiddenOnBoardDtlId2.Value);
                        objEntityOnBoardFlightEmp.EmployeeId = Convert.ToInt32(EmpId2);
                        objEntityOnBoardVisaEmpList2.Add(objEntityOnBoardFlightEmp);
                    }
                }
            }
        }

        if (HiddenPrtclrChk.Value != "2" && HiddenPrtclrChk1.Value !="2")
        {
            objEntityOnBoardRoom.LevFacltyAssmntDtlId = Convert.ToInt32(hiddenOnBoardDtlId3.Value);
            objEntityOnBoardRoom.CandId = Convert.ToInt32(intCandId);
            objEntityOnBoardRoom.LeavId = Levid;
            objEntityOnBoardRoom.ParticularId = 2;
            objEntityOnBoardRoom.StatusId = Convert.ToInt32(ddlSettlment7.SelectedItem.Value);
            DateTime date2 = new DateTime();
            date2 = ObjCommon.textToDateTime(txtTargetDate7.Text);
            string strdate2 = date2.ToString("dd/MM/yyyy");
            objEntityOnBoardRoom.UsrDate = ObjCommon.textToDateTime(strdate2);

            if (FinishStsTotal.Contains("Room"))
            {
                objEntityOnBoardRoom.Finishstatus = 1;
                objEntityOnBoardRoom.FinishDate = DateTime.Today;
            }
            else
            {
                objEntityOnBoardRoom.Finishstatus = 0;
            }
            if (CoseStsTotal.Contains("Room"))
            {
                objEntityOnBoardRoom.CloseStatusId = 1;
                objEntityOnBoardRoom.CloseDate = DateTime.Today;
            }
            else
            {
                objEntityOnBoardRoom.CloseStatusId = 0;
            }

            string TotalEmp3 = hiddenEmp3.Value;

            string[] EachEmpId3 = TotalEmp3.Split(',');

            foreach (string EmpId3 in EachEmpId3)
            {
                if (EmpId3 != "")
                {
                    clsEntity_LeaveFacltyAssmntList objEntityOnBoardRoomEmp = new clsEntity_LeaveFacltyAssmntList();
                    objEntityOnBoardRoomEmp.CorpOffice = objEntityOnBoard.CorpOffice;
                    objEntityOnBoardRoomEmp.LevFacltyAssmntDtlId = Convert.ToInt32(hiddenOnBoardDtlId3.Value);
                    objEntityOnBoardRoomEmp.EmployeeId = Convert.ToInt32(EmpId3);
                    objEntityOnBoardVisaEmpList3.Add(objEntityOnBoardRoomEmp);
                }
            }
        }

        if (HiddenPrtclrChk.Value != "3")
        {
            objEntityOnBoardAirport.LevFacltyAssmntDtlId = Convert.ToInt32(hiddenOnBoardDtlId4.Value);
            objEntityOnBoardAirport.CandId = Convert.ToInt32(intCandId);
            objEntityOnBoardAirport.LeavId = Levid;
            objEntityOnBoardAirport.ParticularId = 3;
            objEntityOnBoardAirport.StatusId = Convert.ToInt32(ddlExitprcss8.SelectedItem.Value);
            DateTime date3 = new DateTime();
            date3 = ObjCommon.textToDateTime(txtTargetDate8.Text);
            string strdate3 = date3.ToString("dd/MM/yyyy");
            objEntityOnBoardAirport.UsrDate = ObjCommon.textToDateTime(strdate3);

            if (FinishStsTotal.Contains("AirPick"))
            {
                objEntityOnBoardAirport.Finishstatus = 1;
                objEntityOnBoardAirport.FinishDate = DateTime.Today;
            }
            else
            {
                objEntityOnBoardAirport.Finishstatus = 0;
            }

            if (CoseStsTotal.Contains("AirPick"))
            {
                objEntityOnBoardAirport.CloseStatusId = 1;
                objEntityOnBoardAirport.CloseDate = DateTime.Today;
            }
            else
            {
                objEntityOnBoardAirport.CloseStatusId = 0;
            }

            string TotalEmp4 = hiddenEmp4.Value;

            string[] EachEmpId4 = TotalEmp4.Split(',');

            foreach (string EmpId4 in EachEmpId4)
            {
                if (EmpId4 != "")
                {
                    clsEntity_LeaveFacltyAssmntList objEntityOnBoardAirEmp = new clsEntity_LeaveFacltyAssmntList();
                    objEntityOnBoardAirEmp.CorpOffice = objEntityOnBoard.CorpOffice;
                    objEntityOnBoardAirEmp.LevFacltyAssmntDtlId = Convert.ToInt32(hiddenOnBoardDtlId4.Value);
                    objEntityOnBoardAirEmp.EmployeeId = Convert.ToInt32(EmpId4);
                    objEntityOnBoardVisaEmpList4.Add(objEntityOnBoardAirEmp);
                }
            }
        }
        if (HiddenPrtclrChk.Value != "0")
        {
            if (FlghtChk == 1)
            {
                objBusinessOnboard.UpdateFlightDtl(objEntityOnBoardFlight);
            }
        }
        if (HiddenPrtclrChk.Value != "2")
        {
            objBusinessOnboard.UpdateSettlmentDtl(objEntityOnBoardRoom);
        }
        if (HiddenPrtclrChk.Value != "3")
        {
            objBusinessOnboard.UpdateExitProcssDtl(objEntityOnBoardAirport);
        }
        if (HiddenPrtclrChk.Value != "0")
        {
            if (FlghtChk == 1)
            {
                objBusinessOnboard.DeleteEmployee(objEntityOnBoardFlight);
            }
        }
        if (HiddenPrtclrChk.Value != "2")
        {
            objBusinessOnboard.DeleteEmployee(objEntityOnBoardRoom);
        }
        if (HiddenPrtclrChk.Value != "3")
        {
            objBusinessOnboard.DeleteEmployee(objEntityOnBoardAirport);
        }
        if (HiddenPrtclrChk.Value != "0")
        {
            if (FlghtChk == 1)
            {
                objBusinessOnboard.InsertEmployee(objEntityOnBoardVisaEmpList2);
            }
        }
        if (HiddenPrtclrChk.Value != "2")
        {
            objBusinessOnboard.InsertEmployee(objEntityOnBoardVisaEmpList3);
        }
        if (HiddenPrtclrChk.Value != "3")
        {
            objBusinessOnboard.InsertEmployee(objEntityOnBoardVisaEmpList4);
        }


        Response.Redirect("hcm_LeaveFacltyAssmntList.aspx?InsUpd=PrcsAsgnUpd");
    }
    public class EmpDetails
    {
        public string [] empdatails ;
        public string empdivision="";
    
    }

    [WebMethod]
    public static EmpDetails ReadCandidateData(int intCandId)
    {
        string[] CandData = new string[7];
        
        clsBusiness_LeaveFacltyAssmntList objBusinessOnboard = new clsBusiness_LeaveFacltyAssmntList();
        clsEntity_LeaveFacltyAssmntList objEntityOnBoard = new clsEntity_LeaveFacltyAssmntList();
        EmpDetails objemp = new EmpDetails();
        objEntityOnBoard.EmployeeId = intCandId;
        DataTable dtCandData = objBusinessOnboard.ReadLevEmplyById(objEntityOnBoard);
        DataTable dtDivisions = objBusinessOnboard.ReadDivisionOfEmp(objEntityOnBoard);
        if (dtCandData.Rows.Count > 0)
        {
            CandData[0] = dtCandData.Rows[0]["EMPLOYEE"].ToString();
            CandData[1] = dtCandData.Rows[0]["DESIGNATION"].ToString();
            CandData[2] = dtCandData.Rows[0]["DEPARTMENT"].ToString();


            CandData[3] = dtCandData.Rows[0]["CNTRY_NAME"].ToString();
          
            CandData[4] = dtCandData.Rows[0]["MODE"].ToString();

           
        }
      
        foreach (DataRow dtDiv in dtDivisions.Rows)
        {
            objemp.empdivision = dtDiv["DIVISION"] + "," + objemp.empdivision;
        }
        objemp.empdatails = CandData;

        return objemp;
    }

    [WebMethod]
    public static string[] ReadFlightData(int intCandId, string intLevid)
    {
        string[] CandData = new string[7];
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusiness_LeaveFacltyAssmntList objBusinessOnboard = new clsBusiness_LeaveFacltyAssmntList();
        clsEntity_LeaveFacltyAssmntList objEntityOnBoard = new clsEntity_LeaveFacltyAssmntList();
        objEntityOnBoard.EmployeeId = intCandId;
        objEntityOnBoard.LeavId = Convert.ToInt32(intLevid);
        DataTable dtCandData = objBusinessOnboard.ReadFlightDetailByCandId(objEntityOnBoard);
        if (dtCandData.Rows.Count > 0)
        {
            CandData[0] = dtCandData.Rows[0]["LEVFCLTYDTL_ID"].ToString();
            CandData[1] = dtCandData.Rows[0]["LEVFCLTYDTL_TICKET_STATUS"].ToString();
            CandData[2] = dtCandData.Rows[0]["LEVFCLTYDTL_DATE"].ToString();


            CandData[3] = dtCandData.Rows[0]["LEVFCLTYDTL_FNSH_STS"].ToString();
            CandData[4] = dtCandData.Rows[0]["LEVFCLTYDTL_CLOSE_STS"].ToString();


            objEntityOnBoard.LevFacltyAssmntDtlId = Convert.ToInt32(dtCandData.Rows[0]["LEVFCLTYDTL_ID"]);
            DataTable dtEmpId = objBusinessOnboard.ReadEmpByLeavAssmntDtl(objEntityOnBoard);
            string strEmp = "";
            if (dtEmpId.Rows.Count > 0)
            {
                foreach (DataRow dt in dtEmpId.Rows)
                {
                    strEmp = strEmp + "," + dt["USR_ID"];
                }
            }
            CandData[5] = strEmp;


        }

        return CandData;
    }

    [WebMethod]
    public static string[] ReadRoomData(int intCandId, string intLevid)
    {
        string[] CandData = new string[7];
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusiness_LeaveFacltyAssmntList objBusinessOnboard = new clsBusiness_LeaveFacltyAssmntList();
        clsEntity_LeaveFacltyAssmntList objEntityOnBoard = new clsEntity_LeaveFacltyAssmntList();
        objEntityOnBoard.EmployeeId = intCandId;
        objEntityOnBoard.LeavId = Convert.ToInt32(intLevid);
        DataTable dtCandData = objBusinessOnboard.ReadSettlmentByCandId(objEntityOnBoard);
        if (dtCandData.Rows.Count > 0)
        {
            CandData[0] = dtCandData.Rows[0]["LEVFCLTYDTL_ID"].ToString();
            CandData[1] = dtCandData.Rows[0]["LEVFCLTYDTL_SETTLEMENT_STATUS"].ToString();
            CandData[2] = dtCandData.Rows[0]["LEVFCLTYDTL_DATE"].ToString();


            CandData[3] = dtCandData.Rows[0]["LEVFCLTYDTL_FNSH_STS"].ToString();
            CandData[4] = dtCandData.Rows[0]["LEVFCLTYDTL_CLOSE_STS"].ToString();


            objEntityOnBoard.LevFacltyAssmntDtlId = Convert.ToInt32(dtCandData.Rows[0]["LEVFCLTYDTL_ID"]);
            DataTable dtEmpId = objBusinessOnboard.ReadEmpByLeavAssmntDtl(objEntityOnBoard);
            string strEmp = "";
            if (dtEmpId.Rows.Count > 0)
            {
                foreach (DataRow dt in dtEmpId.Rows)
                {
                    strEmp = strEmp + "," + dt["USR_ID"];
                }
            }
            CandData[5] = strEmp;


        }

        return CandData;
    }
    [WebMethod]
    public static string[] ReadAirData(int intCandId, string intLevid)
    {
        string[] CandData = new string[7];
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusiness_LeaveFacltyAssmntList objBusinessOnboard = new clsBusiness_LeaveFacltyAssmntList();
        clsEntity_LeaveFacltyAssmntList objEntityOnBoard = new clsEntity_LeaveFacltyAssmntList();
        objEntityOnBoard.EmployeeId = intCandId;
        objEntityOnBoard.LeavId = Convert.ToInt32(intLevid);
        DataTable dtCandData = objBusinessOnboard.ReadExitProcssByCandId(objEntityOnBoard);
        if (dtCandData.Rows.Count > 0)
        {
            CandData[0] = dtCandData.Rows[0]["LEVFCLTYDTL_ID"].ToString();
            CandData[1] = dtCandData.Rows[0]["LEVFCLTYDTL_EXITPROCESS_STATUS"].ToString();
            CandData[2] = dtCandData.Rows[0]["LEVFCLTYDTL_DATE"].ToString();


            CandData[3] = dtCandData.Rows[0]["LEVFCLTYDTL_FNSH_STS"].ToString();
            CandData[4] = dtCandData.Rows[0]["LEVFCLTYDTL_CLOSE_STS"].ToString();


            objEntityOnBoard.LevFacltyAssmntDtlId = Convert.ToInt32(dtCandData.Rows[0]["LEVFCLTYDTL_ID"]);

        
            DataTable dtEmpId = objBusinessOnboard.ReadEmpByLeavAssmntDtl(objEntityOnBoard);
            string strEmp = "";
            if (dtEmpId.Rows.Count > 0)
            {
                foreach (DataRow dt in dtEmpId.Rows)
                {
                    strEmp = strEmp + "," + dt["USR_ID"];
                }
            }
            CandData[5] = strEmp;


        }

        return CandData;
    }

    [WebMethod]
    public static string RecallProcess(int ProcessDetailId)
    {
        string Sucess = "true";
        clsBusiness_LeaveFacltyAssmntList objBusinessOnboard = new clsBusiness_LeaveFacltyAssmntList();
        clsEntity_LeaveFacltyAssmntList objEntityOnBoard = new clsEntity_LeaveFacltyAssmntList();
        objEntityOnBoard.LevFacltyAssmntDtlId = ProcessDetailId;

        objBusinessOnboard.RecallProcess(objEntityOnBoard);
        return Sucess;
    }



    [WebMethod]
    public static string[] CheckStatusBefrEdit(string Type, string CandId, string LeavId)
    {
        string[] CandData = new string[7];
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusiness_LeaveFacltyAssmntList objBusinessOnboard = new clsBusiness_LeaveFacltyAssmntList();
        clsEntity_LeaveFacltyAssmntList objEntityOnBoard = new clsEntity_LeaveFacltyAssmntList();
        objEntityOnBoard.CandId =Convert.ToInt32(CandId);
        objEntityOnBoard.LeavId = Convert.ToInt32(LeavId);
        objEntityOnBoard.ParticularId = Convert.ToInt32(Type);
        DataTable dtCandData = objBusinessOnboard.CheckStatusBefrEdit1(objEntityOnBoard);
        if (dtCandData.Rows.Count > 0)
        {
          
        


            CandData[0] = dtCandData.Rows[0]["LEVFCLTYDTL_FNSH_STS"].ToString();
            CandData[1] = dtCandData.Rows[0]["LEVFCLTYDTL_CLOSE_STS"].ToString();




        }
        return CandData;
    }


}