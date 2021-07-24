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

public partial class HCM_HCM_Master_hcm_Exit_Management_hcm_Exit_Procedure_hcm_Exit_Procedure_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        radioAssigned.Attributes.Add("onkeypress", "return DisableEnter(event)");
        radioNotAssigned.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlEmploy.Attributes.Add("onkeypress", "return DisableEnter(event)");


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
            clsBusiness_Exit_Procedure_List objBusinessOnboard = new clsBusiness_Exit_Procedure_List();
            clsEntity_Exit_Procedure_List objEntityOnBoard = new clsEntity_Exit_Procedure_List();
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

            FillDropdown();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Exit_Procedure);
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
          



            DataTable dtCandidateList = new DataTable();
            dtCandidateList = objBusinessOnboard.ReadEmployeesList(objEntityOnBoard);
            //if (dtCandidateList.Rows.Count <= 0)
            //{
            //    dtCandidateList.Columns.Add("EMPLOYEE ID", typeof(int));
            //    dtCandidateList.Columns.Add("EMPLOYEE", typeof(int));
            //    dtCandidateList.Columns.Add("DESIGNATION", typeof(string));
            //    dtCandidateList.Columns.Add("DIVISION", typeof(string));
            //    dtCandidateList.Columns.Add("DEPARTMENT", typeof(string));
            //    dtCandidateList.Columns.Add("MODE", typeof(string));
            //}


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
        clsBusiness_Exit_Procedure_List objBusinessOnboard = new clsBusiness_Exit_Procedure_List();
        clsEntity_Exit_Procedure_List objEntityOnBoard = new clsEntity_Exit_Procedure_List();

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
        clsBusiness_Exit_Procedure_List objBusinessOnboard = new clsBusiness_Exit_Procedure_List();
        clsEntity_Exit_Procedure_List objEntityOnBoard = new clsEntity_Exit_Procedure_List();
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

            Ddlsettlmnt.DataSource = dtEmployee;
            Ddlsettlmnt.DataTextField = "USR_NAME";
            Ddlsettlmnt.DataValueField = "USR_ID";
            Ddlsettlmnt.DataBind();

            ddlassgnSettlmnt.DataSource = dtEmployee;
            ddlassgnSettlmnt.DataTextField = "USR_NAME";
            ddlassgnSettlmnt.DataValueField = "USR_ID";
            ddlassgnSettlmnt.DataBind();

        }

       
    }

    public string ConvertDataTableToHTMLAssigned(DataTable dt)
    {

        clsBusiness_Exit_Procedure_List objBusinessOnboard = new clsBusiness_Exit_Procedure_List();
        clsEntity_Exit_Procedure_List objEntityOnBoard = new clsEntity_Exit_Procedure_List();
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
                strHtml += "<th class=\"thT\"  style=\"width:25%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";
            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:25%;text-align: left; word-wrap:break-word;\">EMPLOYEE NAME</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">DESIGNATION</th>";
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">DIVISION</th>";
            }
           
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";
            }

            

        }

        if (HiddenEdit.Value == "1")
        {
            strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">EDIT</th>";
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



           
            strHtml += "<td  class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  >No Data Available</td>";
            strHtml += "<td  class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
          
         
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
            DataTable dtClearnSts = objBusinessOnboard.ReadClearanceOfEmp(objEntityOnBoard);
            DataTable dtSettelment = objBusinessOnboard.ReadSettlementOfEmp(objEntityOnBoard);//evm-0024
            string SettleStst = "";
            string CLERNCESts="";
            if (dtClearnSts.Rows.Count > 0)
            {
                CLERNCESts = dtClearnSts.Rows[0]["LVECLRWKR_APPRVL_STS"].ToString();
            }
            if (dtSettelment.Rows.Count > 0) //evm-0024
            {
                SettleStst = dtSettelment.Rows[0]["SETTLEMENT_APPRVL_STS"].ToString();
            }
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
                    strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + "</td>";

                }
                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DESIGNATION"].ToString() + "</td>";


                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + strDivisions + "</td>";

                }
               
                else if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";

                }

                

            }



            if (HiddenEdit.Value == "1")
            {
                strHtml += "<td class=\"tdT\" style=\"width:10%; word-wrap:break-word;text-align: center;\"><a class=\"tooltip\" title=\"Edit\" onclick=\"return ProcessEdit('" + strId + "','" + CLERNCESts + "','"+SettleStst+"');\" ><img  style=\"cursor:pointer;margin-left: 28%;float: left;\" src='/Images/Icons/edit.png' /></a> </td>";
            }

            strHtml += "<td id=\"tdcandiateid" + intRowBodyCount + "\"  class=\"tdT\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount]["USR_ID"].ToString() + "</td>";

            strHtml += "</tr>";

        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }

    public string ConvertDataTableToHTMLNotAssigned(DataTable dt)
    {


        clsBusiness_Exit_Procedure_List objBusinessOnboard = new clsBusiness_Exit_Procedure_List();
        clsEntity_Exit_Procedure_List objEntityOnBoard = new clsEntity_Exit_Procedure_List();
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
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID </th>";
            }
            else  if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">EMPLOYEE NAME</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">DESIGNATION</th>";
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">DIVISION</th>";
            }
            
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";
            }
           

        }
   
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
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</td>";
                    }

                    else if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DESIGNATION"].ToString() + "</td>";


                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + strDivisions + "</td>";

                    }
                    
                    else if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";

                    }
                    
                }

                strHtml += "<td id=\"tdcandiateid" + intRowBodyCount + "\"  class=\"tdT\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount]["USR_ID"].ToString() + "</td>";
                
                strHtml += "</tr>";

            }
        }
        else
        {
            strHtml += "<td  class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            //strHtml += "<td  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;border-right: none;\"  >No Data Available</td>";
            strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            //strHtml += "<td  class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            //strHtml += "<td  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  ></td>";

            strHtml += "<td  class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
           
          
         
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }

    protected void btnProcessMultySave_Click(object sender, EventArgs e)
    {
        clsBusiness_Exit_Procedure_List objBusinessOnboard = new clsBusiness_Exit_Procedure_List();
        clsEntity_Exit_Procedure_List objEntityOnBoard = new clsEntity_Exit_Procedure_List();
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

        //string strTotalLeavId = HiddenLeavId.Value;
        //string[] strEachLeavId = strTotalLeavId.Split(',');


        string strTotalCandidate = Hiddenchecklist.Value;
        string[] strEachCandidate = strTotalCandidate.Split(',');


        //string strAirChk = HiddenAirLine.Value;
        //string[] strEachAirchk = strAirChk.Split(',');


        clsEntity_Exit_Procedure_List objEntityOnBoardFlight = new clsEntity_Exit_Procedure_List();
        clsEntity_Exit_Procedure_List objEntitySettlment = new clsEntity_Exit_Procedure_List();
        clsEntity_Exit_Procedure_List objEntityExitProcess = new clsEntity_Exit_Procedure_List();

        List<clsEntity_Exit_Procedure_List> objEntityOnBoardVisaEmpList2 = new List<clsEntity_Exit_Procedure_List>();
        List<clsEntity_Exit_Procedure_List> objEntityOnBoardVisaEmpList3 = new List<clsEntity_Exit_Procedure_List>();
        List<clsEntity_Exit_Procedure_List> objEntityOnBoardVisaEmpList4 = new List<clsEntity_Exit_Procedure_List>();
        int LevCount = 0;
        foreach (string strCandId in strEachCandidate)
        {
            if (strCandId != "")
            {
                
                

                    objEntityOnBoardFlight.ExitProcedure = intLeavFacltyId;
                    objEntityOnBoardFlight.CandId = Convert.ToInt32(strCandId);
                
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
                            clsEntity_Exit_Procedure_List objEntityOnBoardFlightEmp = new clsEntity_Exit_Procedure_List();
                            objEntityOnBoardFlightEmp.EmployeeId = Convert.ToInt32(EmpId2);
                            objEntityOnBoardVisaEmpList2.Add(objEntityOnBoardFlightEmp);
                        }
                    }
                

                objEntitySettlment.ExitProcedure = intLeavFacltyId;
                objEntitySettlment.CandId = Convert.ToInt32(strCandId);
            
                objEntitySettlment.ParticularId = 4;
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
                        clsEntity_Exit_Procedure_List objEntityOnBoardSettlment = new clsEntity_Exit_Procedure_List();
                        objEntityOnBoardSettlment.EmployeeId = Convert.ToInt32(EmpId3);
                        objEntityOnBoardVisaEmpList3.Add(objEntityOnBoardSettlment);
                    }
                }


                objEntityExitProcess.ExitProcedure = intLeavFacltyId;
                objEntityExitProcess.CandId = Convert.ToInt32(strCandId);
             
                objEntityExitProcess.ParticularId = 2;
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
                        clsEntity_Exit_Procedure_List objEntityOnBoardExitProcss = new clsEntity_Exit_Procedure_List();
                        objEntityOnBoardExitProcss.EmployeeId = Convert.ToInt32(EmpId4);
                        objEntityOnBoardVisaEmpList4.Add(objEntityOnBoardExitProcss);
                    }
                }


                objBusinessOnboard.Insert_Process_Detail(objEntityOnBoard, objEntityOnBoardFlight, objEntitySettlment, objEntityExitProcess, objEntityOnBoardVisaEmpList2, objEntityOnBoardVisaEmpList3, objEntityOnBoardVisaEmpList4);
            }
           
        }

        Response.Redirect("hcm_Exit_Procedure_List.aspx?InsUpd=PrcsAsgn");
    }

    protected void btnProcessSingleSave_Click(object sender, EventArgs e)
    {
        clsBusiness_Exit_Procedure_List objBusinessOnboard = new clsBusiness_Exit_Procedure_List();
        clsEntity_Exit_Procedure_List objEntityOnBoard = new clsEntity_Exit_Procedure_List();
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

        clsEntity_Exit_Procedure_List objEntityOnBoardFlight = new clsEntity_Exit_Procedure_List();
        clsEntity_Exit_Procedure_List objEntityOnBoardRoom = new clsEntity_Exit_Procedure_List();
        clsEntity_Exit_Procedure_List objEntityOnBoardAirport = new clsEntity_Exit_Procedure_List();

        List<clsEntity_Exit_Procedure_List> objEntityOnBoardVisaEmpList2 = new List<clsEntity_Exit_Procedure_List>();
        List<clsEntity_Exit_Procedure_List> objEntityOnBoardVisaEmpList3 = new List<clsEntity_Exit_Procedure_List>();
        List<clsEntity_Exit_Procedure_List> objEntityOnBoardVisaEmpList4 = new List<clsEntity_Exit_Procedure_List>();
        int intCandId = Convert.ToInt32(hiddenCandidateId.Value);

       
     

        string FinishStsTotal = hiddenFinishStatus.Value;
        string CoseStsTotal = hiddenCloseStatus.Value;

        string TotalEmp = hiddenEmp1.Value;



       

            objEntityOnBoardFlight.ExitProcedureDtlId = Convert.ToInt32(hiddenOnBoardDtlId2.Value);
            objEntityOnBoardFlight.CandId = Convert.ToInt32(intCandId);
       
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
                    clsEntity_Exit_Procedure_List objEntityOnBoardFlightEmp = new clsEntity_Exit_Procedure_List();
                    objEntityOnBoardFlightEmp.CorpOffice = objEntityOnBoard.CorpOffice;
                    objEntityOnBoardFlightEmp.ExitProcedureDtlId = Convert.ToInt32(hiddenOnBoardDtlId2.Value);
                    objEntityOnBoardFlightEmp.EmployeeId = Convert.ToInt32(EmpId2);
                    objEntityOnBoardVisaEmpList2.Add(objEntityOnBoardFlightEmp);
                }
            }
        


        objEntityOnBoardRoom.ExitProcedureDtlId = Convert.ToInt32(hiddenOnBoardDtlId3.Value);
        objEntityOnBoardRoom.CandId = Convert.ToInt32(intCandId);
 
        objEntityOnBoardRoom.ParticularId = 4;
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
                clsEntity_Exit_Procedure_List objEntityOnBoardRoomEmp = new clsEntity_Exit_Procedure_List();
                objEntityOnBoardRoomEmp.CorpOffice = objEntityOnBoard.CorpOffice;
                objEntityOnBoardRoomEmp.ExitProcedureDtlId = Convert.ToInt32(hiddenOnBoardDtlId3.Value);
                objEntityOnBoardRoomEmp.EmployeeId = Convert.ToInt32(EmpId3);
                objEntityOnBoardVisaEmpList3.Add(objEntityOnBoardRoomEmp);
            }
        }


        objEntityOnBoardAirport.ExitProcedureDtlId = Convert.ToInt32(hiddenOnBoardDtlId4.Value);
        objEntityOnBoardAirport.CandId = Convert.ToInt32(intCandId);
 
        objEntityOnBoardAirport.ParticularId = 2;
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
                clsEntity_Exit_Procedure_List objEntityOnBoardAirEmp = new clsEntity_Exit_Procedure_List();
                objEntityOnBoardAirEmp.CorpOffice = objEntityOnBoard.CorpOffice;
                objEntityOnBoardAirEmp.ExitProcedureDtlId = Convert.ToInt32(hiddenOnBoardDtlId4.Value);
                objEntityOnBoardAirEmp.EmployeeId = Convert.ToInt32(EmpId4);
                objEntityOnBoardVisaEmpList4.Add(objEntityOnBoardAirEmp);
            }
        }
       
            objBusinessOnboard.UpdateFlightDtl(objEntityOnBoardFlight);
        
        objBusinessOnboard.UpdateSettlmentDtl(objEntityOnBoardRoom);
        objBusinessOnboard.UpdateExitProcssDtl(objEntityOnBoardAirport);

      
            objBusinessOnboard.DeleteEmployee(objEntityOnBoardFlight);
        
        objBusinessOnboard.DeleteEmployee(objEntityOnBoardRoom);
        objBusinessOnboard.DeleteEmployee(objEntityOnBoardAirport);
   
            objBusinessOnboard.InsertEmployee(objEntityOnBoardVisaEmpList2);
        
        objBusinessOnboard.InsertEmployee(objEntityOnBoardVisaEmpList3);
        objBusinessOnboard.InsertEmployee(objEntityOnBoardVisaEmpList4);


        Response.Redirect("hcm_Exit_Procedure_List.aspx?InsUpd=PrcsAsgnUpd");
    }
    public class EmpDetails
    {
        public string[] empdatails;
        public string empdivision = "";

    }

    [WebMethod]
    public static EmpDetails ReadCandidateData(int intCandId)
    {
        string[] CandData = new string[7];

        clsBusiness_Exit_Procedure_List objBusinessOnboard = new clsBusiness_Exit_Procedure_List();
        clsEntity_Exit_Procedure_List objEntityOnBoard = new clsEntity_Exit_Procedure_List();
        EmpDetails objemp = new EmpDetails();
        objEntityOnBoard.EmployeeId = intCandId;
        DataTable dtCandData = objBusinessOnboard.ReadLevEmplyById(objEntityOnBoard);
        DataTable dtDivisions = objBusinessOnboard.ReadDivisionOfEmp(objEntityOnBoard);
        if (dtCandData.Rows.Count > 0)
        {
            CandData[0] = dtCandData.Rows[0]["EMPLOYEE NAME"].ToString();
            CandData[1] = dtCandData.Rows[0]["DESIGNATION"].ToString();
            CandData[2] = dtCandData.Rows[0]["DEPARTMENT"].ToString();


            CandData[3] = dtCandData.Rows[0]["CNTRY_NAME"].ToString();

            CandData[4] = dtCandData.Rows[0]["MODE"].ToString();


        }

        foreach (DataRow dtDiv in dtDivisions.Rows)
        {
            if (objemp.empdivision == "")
            {
                objemp.empdivision = dtDiv["DIVISION"].ToString();
            }
            else
            {
                objemp.empdivision = dtDiv["DIVISION"] + "," + objemp.empdivision;
            }
            //objemp.empdivision = dtDiv["DIVISION"] + "," + objemp.empdivision;
        }
        objemp.empdatails = CandData;

        return objemp;
    }

    [WebMethod]
    public static string[] ReadFlightData(int intCandId)
    {
        string[] CandData = new string[8];
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusiness_Exit_Procedure_List objBusinessOnboard = new clsBusiness_Exit_Procedure_List();
        clsEntity_Exit_Procedure_List objEntityOnBoard = new clsEntity_Exit_Procedure_List();
        objEntityOnBoard.EmployeeId = intCandId;
      
        DataTable dtCandData = objBusinessOnboard.ReadFlightDetailByCandId(objEntityOnBoard);
        if (dtCandData.Rows.Count > 0)
        {
            CandData[0] = dtCandData.Rows[0]["EXTPRDDTL_ID"].ToString();
            CandData[1] = dtCandData.Rows[0]["EXTPRDDTL_TICKET_STATUS"].ToString();
            CandData[2] = dtCandData.Rows[0]["EXTPRDDTL_DATE"].ToString();


            CandData[3] = dtCandData.Rows[0]["EXTPRDDTL_FNSH_STS"].ToString();
            CandData[4] = dtCandData.Rows[0]["EXTPRDDTL_CLOSE_STS"].ToString();


            objEntityOnBoard.ExitProcedureDtlId = Convert.ToInt32(dtCandData.Rows[0]["EXTPRDDTL_ID"]);
            DataTable dtEmpId = objBusinessOnboard.ReadEmpByLeavAssmntDtl(objEntityOnBoard);
            string strEmp = "";
            string Status = "";
            string UsrName = "";
            if (dtEmpId.Rows.Count > 0)
            {
                foreach (DataRow dt in dtEmpId.Rows)
                {
                    strEmp = strEmp + "," + dt["USR_ID"];
                    Status = Status + "," + dt["USR_STATUS"];
                    UsrName = UsrName + "," + dt["USR_NAME"];
                }
            }
            CandData[5] = strEmp;
            CandData[6] = Status;
            CandData[7] = UsrName;
        }

        return CandData;
    }

    [WebMethod]
    public static string[] ReadRoomData(int intCandId)
    {
        string[] CandData = new string[8];
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusiness_Exit_Procedure_List objBusinessOnboard = new clsBusiness_Exit_Procedure_List();
        clsEntity_Exit_Procedure_List objEntityOnBoard = new clsEntity_Exit_Procedure_List();
        objEntityOnBoard.EmployeeId = intCandId;
        
        DataTable dtCandData = objBusinessOnboard.ReadSettlmentByCandId(objEntityOnBoard);
        if (dtCandData.Rows.Count > 0)
        {
            CandData[0] = dtCandData.Rows[0]["EXTPRDDTL_ID"].ToString();
            CandData[1] = dtCandData.Rows[0]["EXTPRDDTL_VISANOC_STATUS"].ToString();
            CandData[2] = dtCandData.Rows[0]["EXTPRDDTL_DATE"].ToString();


            CandData[3] = dtCandData.Rows[0]["EXTPRDDTL_FNSH_STS"].ToString();
            CandData[4] = dtCandData.Rows[0]["EXTPRDDTL_CLOSE_STS"].ToString();



            objEntityOnBoard.ExitProcedureDtlId = Convert.ToInt32(dtCandData.Rows[0]["EXTPRDDTL_ID"]);
            DataTable dtEmpId = objBusinessOnboard.ReadEmpByLeavAssmntDtl(objEntityOnBoard);
            string strEmp = "";
            string Status = "";
            string UsrName = "";
            if (dtEmpId.Rows.Count > 0)
            {
                foreach (DataRow dt in dtEmpId.Rows)
                {
                    strEmp = strEmp + "," + dt["USR_ID"];
                    Status = Status + "," + dt["USR_STATUS"];
                    UsrName = UsrName + "," + dt["USR_NAME"];
                }
            }
            CandData[5] = strEmp;
            CandData[6] = Status;
            CandData[7] = UsrName;


        }

        return CandData;
    }
    [WebMethod]
    public static string[] ReadAirData(int intCandId)
    {
        string[] CandData = new string[8];
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusiness_Exit_Procedure_List objBusinessOnboard = new clsBusiness_Exit_Procedure_List();
        clsEntity_Exit_Procedure_List objEntityOnBoard = new clsEntity_Exit_Procedure_List();
        objEntityOnBoard.EmployeeId = intCandId;
      
        DataTable dtCandData = objBusinessOnboard.ReadExitProcssByCandId(objEntityOnBoard);
        if (dtCandData.Rows.Count > 0)
        {
            CandData[0] = dtCandData.Rows[0]["EXTPRDDTL_ID"].ToString();
            CandData[1] = dtCandData.Rows[0]["EXTPRDDTL_EXITPERMIT_STATUS"].ToString();
            CandData[2] = dtCandData.Rows[0]["EXTPRDDTL_DATE"].ToString();


            CandData[3] = dtCandData.Rows[0]["EXTPRDDTL_FNSH_STS"].ToString();
            CandData[4] = dtCandData.Rows[0]["EXTPRDDTL_CLOSE_STS"].ToString();


            objEntityOnBoard.ExitProcedureDtlId = Convert.ToInt32(dtCandData.Rows[0]["EXTPRDDTL_ID"]);


            DataTable dtEmpId = objBusinessOnboard.ReadEmpByLeavAssmntDtl(objEntityOnBoard);
            string strEmp = "";
            string Status = "";
            string UsrName = "";
            if (dtEmpId.Rows.Count > 0)
            {
                foreach (DataRow dt in dtEmpId.Rows)
                {
                    strEmp = strEmp + "," + dt["USR_ID"];
                    Status = Status + "," + dt["USR_STATUS"];
                    UsrName = UsrName + "," + dt["USR_NAME"];
                }
            }
            CandData[5] = strEmp;
            CandData[6] = Status;
            CandData[7] = UsrName;


        }

        return CandData;
    }

    [WebMethod]
    public static string RecallProcess(int ProcessDetailId)
    {
        string Sucess = "true";
        clsBusiness_Exit_Procedure_List objBusinessOnboard = new clsBusiness_Exit_Procedure_List();
        clsEntity_Exit_Procedure_List objEntityOnBoard = new clsEntity_Exit_Procedure_List();
        objEntityOnBoard.ExitProcedureDtlId = ProcessDetailId;

        objBusinessOnboard.RecallProcess(objEntityOnBoard);
        return Sucess;
    }
    [WebMethod]
    public static string[] CheckStatusBefrEdit(string Type, string CandId)
    {
        string[] CandData = new string[7];
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusiness_Exit_Procedure_List objBusinessOnboard = new clsBusiness_Exit_Procedure_List();
        clsEntity_Exit_Procedure_List objEntityOnBoard = new clsEntity_Exit_Procedure_List();
        objEntityOnBoard.CandId = Convert.ToInt32(CandId);
     
        objEntityOnBoard.ParticularId = Convert.ToInt32(Type);
        DataTable dtCandData = objBusinessOnboard.CheckStatusBefrEdit1(objEntityOnBoard);
        if (dtCandData.Rows.Count > 0)
        {




            CandData[0] = dtCandData.Rows[0]["EXTPRDDTL_FNSH_STS"].ToString();
            CandData[1] = dtCandData.Rows[0]["EXTPRDDTL_CLOSE_STS"].ToString();




        }
        return CandData;
    }






}