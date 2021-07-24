using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using CL_Compzit;
using BL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using System.Web.Services;
using BL_Compzit.BusinessLayer_AWMS;
using EL_Compzit.EntityLayer_AWMS;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using System.Linq;
public partial class HCM_HCM_Reports_hcm_Mess_Calculation_Report_hcm_Mess_Calculation_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlYear.Focus();
            clsEntity_Mess_Bill_Report objEntityManpwrReqmt = new clsEntity_Mess_Bill_Report();
            clsBusiness_Mess_Bill_Report objBusinessManpwrReqmt = new clsBusiness_Mess_Bill_Report();

            clsEntity_Leave_Management_Report objEntityManpwrReqmt1 = new clsEntity_Leave_Management_Report();
            clsBusiness_Leave_Management_Report objBusinessManpwrReqmt1 = new clsBusiness_Leave_Management_Report();
            BindDdlYears();

            BindDdlMonths();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityManpwrReqmt.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityManpwrReqmt1.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                objEntityManpwrReqmt.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityManpwrReqmt1.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
                hiddenOrgId.Value = Session["ORGID"].ToString();
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }



            if (Session["USERID"] != null)
            {
                objEntityManpwrReqmt.User_Id = Convert.ToInt32(Session["USERID"]);
                objEntityManpwrReqmt1.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            DataTable dtDivision = new DataTable();
            dtDivision = objBusinessManpwrReqmt.ReadAccomodation(objEntityManpwrReqmt);
            ddlLeavTyp.ClearSelection();
            ddlLeavTyp.Items.Clear();
            if (dtDivision.Rows.Count > 0)
            {
                ddlLeavTyp.DataSource = dtDivision;
                ddlLeavTyp.DataTextField = "ACCMDTN_NAME";
                ddlLeavTyp.DataValueField = "ACCMDTN_ID";
                ddlLeavTyp.DataBind();
            }

            ddlLeavTyp.Items.Insert(0, "--SELECT MESS--");


         

            DataTable dtDepts = new DataTable();
            dtDepts = objBusinessManpwrReqmt1.ReadDepts(objEntityManpwrReqmt1);
            ddlDepartmnt.ClearSelection();
            ddlDepartmnt.Items.Clear();
            if (dtDepts.Rows.Count > 0)
            {
                ddlDepartmnt.DataSource = dtDepts;
                ddlDepartmnt.DataTextField = "CPRDEPT_NAME";
                ddlDepartmnt.DataValueField = "CPRDEPT_ID";
                ddlDepartmnt.DataBind();
            }

            ddlDepartmnt.Items.Insert(0, "--SELECT DEPARTMENT--");




            ddlDiv.Items.Insert(0, "--SELECT DIVISION--");

            //for viewing table


            DataTable dtManpwr = new DataTable();

          //  ConvertDataTableToHTML();

            //dtManpwr = objBusinessManpwrReqmt.ReadLeaveManagementReport(objEntityManpwrReqmt);

            string strHtm = ConvertDataTableToHTML();
            divReport.InnerHtml = strHtm;

            clsBusinessLayerInterviewProcess objBusinessIntervewProcess = new clsBusinessLayerInterviewProcess();
            clsEntityLayerInterviewProcess objEntityIntervewProcess = new clsEntityLayerInterviewProcess();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityIntervewProcess.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityIntervewProcess.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            DataTable dtCorp = objBusinessIntervewProcess.Read_Corp_Details(objEntityIntervewProcess);

            string strprint = ConvertDataTableForPrint( dtCorp);
            divPrintReport.InnerHtml = strprint;

        }

    }
    public void BindDdlYears()
    {
        string strYear = "";
        ddlYear.Items.Clear();
        strYear = DateTime.Today.Year.ToString();
        var currentYear = DateTime.Today.Year;
        for (int i = 25; i >= -25; i--)
        {

            ddlYear.Items.Add((currentYear - i).ToString());
        }
        ddlYear.ClearSelection();
        if (strYear != null)
        {
            if (ddlYear.Items.FindByValue(strYear) != null)
            {
                ddlYear.Items.FindByValue(strYear).Selected = true;
            }
        }
        else
        {
            ddlYear.Items.Insert(0, "--YEAR--");
        }
    }

    public void BindDdlMonths()
    {
        string strMonth = "";
        strMonth = DateTime.Today.Month.ToString();
        ddlMonth.Items.Clear();
        var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
        for (int i = 0; i < months.Length - 1; i++)
        {
            ddlMonth.Items.Add(new ListItem(months[i], (i + 1).ToString()));
        }
        ddlMonth.ClearSelection();
        if (strMonth != null)
        {
            if (ddlMonth.Items.FindByValue(strMonth) != null)
            {
                ddlMonth.Items.FindByValue(strMonth).Selected = true;
            }
        }
        else
        {
            ddlMonth.Items.Insert(0, "--MONTH--");
        }
    }


    public string ConvertDataTableToHTML()
    {

        clsEntity_Mess_Bill_Report objEntityManpwrReqmt = new clsEntity_Mess_Bill_Report();
        clsBusiness_Mess_Bill_Report objBusinessManpwrReqmt = new clsBusiness_Mess_Bill_Report();
          clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityManpwrReqmt.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityManpwrReqmt.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            hiddenOrgId.Value = Session["ORGID"].ToString();
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }



        if (Session["USERID"] != null)
        {
            objEntityManpwrReqmt.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }



        if (ddlDiv.SelectedItem.Value != "--SELECT DIVISION--")
        {
            objEntityManpwrReqmt.DivsnId = Convert.ToInt32(ddlDiv.SelectedItem.Value);

        }
        if (ddlDepartmnt.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntityManpwrReqmt.DeptId = Convert.ToInt32(ddlDepartmnt.SelectedItem.Value);

        }

        if (ddlLeavTyp.SelectedItem.Value != "--SELECT MESS--")
        {
            objEntityManpwrReqmt.MessBillId = Convert.ToInt32(ddlLeavTyp.SelectedItem.Value);
        }

        clsCommonLibrary objCommon = new clsCommonLibrary();

        int intYear = Convert.ToInt32(ddlYear.SelectedItem.Text);
        int intMonth = Convert.ToInt32(ddlMonth.SelectedItem.Value);
        string EmDate = new DateTime(intYear, intMonth, 1).ToString("dd-MM-yyyy");
        DateTime ddateFrom = objCommon.textToDateTime(EmDate);

        int days = DateTime.DaysInMonth(intYear, intMonth);

        string EmToDate = new DateTime(intYear, intMonth, days).ToString("dd-MM-yyyy");
        DateTime ddateTo = objCommon.textToDateTime(EmToDate);

        objEntityManpwrReqmt.Fromdate = ddateFrom;
        objEntityManpwrReqmt.Todate = ddateTo;


        double intNumDayCal = 0;

       // intNumDayCal = (ddateTo - ddateFrom).TotalDays;

        DataTable dtAccomdtn = new DataTable();
        dtAccomdtn = objBusinessManpwrReqmt.ReadAccomodationDetails(objEntityManpwrReqmt);




        if (ddlLeavTyp.SelectedItem.Value != "--SELECT MESS--")
        {
            string LevMessid = ddlLeavTyp.SelectedItem.Value;
            for (int i = dtAccomdtn.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dtAccomdtn.Rows[i];
                string a = dr["ACCMDTN_ID"].ToString();
                if (a != LevMessid)
                    dr.Table.Rows.Remove(dr);
            }

        }
       

        // string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";



        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID#</th>";


        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE</th>";


        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">DESIGNATION</th>";

        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">ACCOMMODATION/MESS</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">FROM DATE</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">TO DATE</th>";


        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: right; word-wrap:break-word;\">NO. OF DAYS</th>";


        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: right; word-wrap:break-word;\">AMOUNT</th>";

       








        strHtml += "</tr>";


        strHtml += "</thead>";
        //add rows
        int innertable = 0;
        strHtml += "<tbody>";
        string strUserIds = "";
        int inFirstloop = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dtAccomdtn.Rows.Count; intRowBodyCount++)
        {
          
            int innertableflag = 0;

            string Useridid = dtAccomdtn.Rows[intRowBodyCount]["USR_ID"].ToString();
            DataTable Copy=new DataTable();
            Copy = dtAccomdtn.Copy();
           // DataView view = new DataView(dtAccomdtn);

            for (int i = Copy.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = Copy.Rows[i];
                string a = dr["USR_ID"].ToString();
                if (a != Useridid)
                    Copy.Rows.Remove(dr);
                  // dr.Table.Rows.Remove(dr);
                   
            }
      
            int intRowspan = Copy.Rows.Count;

            DateTime EndDate = new DateTime(); DateTime StartDate = new DateTime(); decimal decAmount = 0, decAmountperday = 0 ;
             if (dtAccomdtn.Rows[intRowBodyCount]["MESSBILL_TO"].ToString() != "")
                 EndDate = objCommon.textToDateTime(dtAccomdtn.Rows[intRowBodyCount]["MESSBILL_TO"].ToString());

            if (dtAccomdtn.Rows[intRowBodyCount]["MESSBILL_FROM"].ToString() != "")
                StartDate = objCommon.textToDateTime(dtAccomdtn.Rows[intRowBodyCount]["MESSBILL_FROM"].ToString());

            double INTNUMDAYS = 0;

            INTNUMDAYS = (EndDate - StartDate).TotalDays;

            if (dtAccomdtn.Rows[intRowBodyCount]["MESSEMP_AMNT"].ToString() != "")
                decAmount = Convert.ToDecimal(dtAccomdtn.Rows[intRowBodyCount]["MESSEMP_AMNT"].ToString());

            int NumMessbilDays = Convert.ToInt32(dtAccomdtn.Rows[intRowBodyCount]["MESSEMP_DAYS"].ToString());
       



            if (decAmount != 0)
                decAmountperday = decAmount / (decimal)NumMessbilDays;

            decimal EmpAmount = 0;

         

            EmpAmount = decAmountperday * (decimal)days;

            strHtml += "<tr  >";


            //string strId = dt.Rows[intRowBodyCount][0].ToString();
            //hiddenManpwrId.Value = strId;

            string status = "";
            string StsChk = "";
            if (!(strUserIds.Split(',').Contains(dtAccomdtn.Rows[intRowBodyCount]["USR_ID"].ToString())))
            {
                inFirstloop = 1;
            strHtml += "<td class=\"tdT\" rowspan=\"" + intRowspan + "\"  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtAccomdtn.Rows[intRowBodyCount]["USR_CODE"].ToString().ToUpper() + "</td>";

            strHtml += "<td class=\"tdT\" rowspan=\"" + intRowspan + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtAccomdtn.Rows[intRowBodyCount]["USR_NAME"].ToString().ToUpper() + "</td>";

            strHtml += "<td class=\"tdT\" rowspan=\"" + intRowspan + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtAccomdtn.Rows[intRowBodyCount]["DSGN_NAME"].ToString().ToUpper() + "</td>";
          
            string strAccomdtn = "";
            string strfrom = "";
            string strTo = "";
            string strdays = "";
            string stramnt = "";
            for (int intRowBodyCount1 = 0; intRowBodyCount1 < Copy.Rows.Count; intRowBodyCount1++)
            {
                if (intRowBodyCount1!=0)
                    strHtml += "<tr  >";
                innertableflag = 1;
                strAccomdtn = Copy.Rows[intRowBodyCount1]["ACCMDTN_NAME"].ToString().ToUpper();
                strfrom = Copy.Rows[intRowBodyCount1]["MESSBILL_FROM"].ToString().ToUpper();

                strTo = Copy.Rows[intRowBodyCount1]["MESSBILL_TO"].ToString().ToUpper();
                strdays = Copy.Rows[intRowBodyCount1]["MESSEMP_DAYS"].ToString().ToUpper();
                stramnt = Copy.Rows[intRowBodyCount1]["MESSEMP_AMNT"].ToString().ToUpper();
                strHtml += "<td class=\"tdT\"   style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9\" >" + strAccomdtn + "</td>";

                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: CENTER;border-bottom: 1px solid #c9c9c9\" >" + strfrom + "</td>";
                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: CENTER;border-bottom: 1px solid #c9c9c9\" >" + strTo + "</td>";

                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;border-bottom: 1px solid #c9c9c9\" >" + strdays + "</td>";

                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;border-bottom: 1px solid #c9c9c9\" >" + stramnt + "</td>";
               
            }

            strHtml += "</tr>";
            }


            if (strUserIds == "")
                strUserIds = dtAccomdtn.Rows[intRowBodyCount]["USR_ID"].ToString();
            else
            {


                strUserIds = strUserIds + "," + dtAccomdtn.Rows[intRowBodyCount]["USR_ID"].ToString();

            }
            //if (innertableflag == 0)
            //{
            //    strHtml += "<td  class=\"thT\"colspan=8 style=\"width:100%;text-align: center; word-wrap:break-word;\">NO DATA AVAILABLE</td></tr>";
            //}
        
           if(innertableflag!=1)
               strHtml += "</tr>";

        }
        if (inFirstloop == 0)
        {
            strHtml += "<tr id=\"Remdisplay\"  >";
            strHtml += "<td class=\"thT\"colspan=8 style=\"width:100%;text-align: center; word-wrap:break-word;\">NO DATA AVAILABLE</td></tr>";
            strHtml += "</tr>";
        }
        strHtml += "<tr id=\"Tdisplay\" style=\"display:none\">";
        strHtml += "<td class=\"thT\"colspan=8 style=\"width:100%;text-align: center; word-wrap:break-word;\">NO DATA AVAILABLE</td></tr>";
        strHtml += "</tr>";
        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsEntity_Mess_Bill_Report objEntityManpwrReqmt = new clsEntity_Mess_Bill_Report();
        clsBusiness_Mess_Bill_Report objBusinessManpwrReqmt = new clsBusiness_Mess_Bill_Report();
        int intUserId = 0, intUsrRolMstrId, intEnableHRallocation = 0, intCorpId = 0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityManpwrReqmt.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityManpwrReqmt.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            hiddenOrgId.Value = Session["ORGID"].ToString();
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }



        if (Session["USERID"] != null)
        {
            objEntityManpwrReqmt.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (ddlDiv.SelectedItem.Value != "--SELECT DIVISION--")
        {
            objEntityManpwrReqmt.DivsnId = Convert.ToInt32(ddlDiv.SelectedItem.Value);

        }
        if (ddlDepartmnt.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntityManpwrReqmt.DeptId = Convert.ToInt32(ddlDepartmnt.SelectedItem.Value);

        }

        if (ddlLeavTyp.SelectedItem.Value != "--SELECT MESS--")
        {
            objEntityManpwrReqmt.MessBillId = Convert.ToInt32(ddlLeavTyp.SelectedItem.Value);
        }
        // hiddenAssignedTo.Value = objEntityReqrmntAlctn.Employee_Id.ToString();


        string strHtm = ConvertDataTableToHTML();
        divReport.InnerHtml = strHtm;


        clsBusinessLayerInterviewProcess objBusinessIntervewProcess = new clsBusinessLayerInterviewProcess();
        clsEntityLayerInterviewProcess objEntityIntervewProcess = new clsEntityLayerInterviewProcess();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityIntervewProcess.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityIntervewProcess.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtCorp = objBusinessIntervewProcess.Read_Corp_Details(objEntityIntervewProcess);

        string strprint = ConvertDataTableForPrint( dtCorp);
        divPrintReport.InnerHtml = strprint;
    }

    protected void ddlDepartmnt_SelectedIndexChanged(object sender, EventArgs e)
    {
        clsEntity_Leave_Management_Report objEntityManpwrReqmt = new clsEntity_Leave_Management_Report();
        clsBusiness_Leave_Management_Report objBusinessManpwrReqmt = new clsBusiness_Leave_Management_Report();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityManpwrReqmt.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityManpwrReqmt.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            hiddenOrgId.Value = Session["ORGID"].ToString();
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }



        if (Session["USERID"] != null)
        {
            objEntityManpwrReqmt.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (ddlDepartmnt.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntityManpwrReqmt.DepId = Convert.ToInt32(ddlDepartmnt.SelectedItem.Value);
            DataTable dtDiv = objBusinessManpwrReqmt.ReadDivision(objEntityManpwrReqmt);
            ddlDiv.ClearSelection();
            ddlDiv.Items.Clear();
            if (dtDiv.Rows.Count > 0)
            {
                ddlDiv.DataSource = dtDiv;
                ddlDiv.DataTextField = "CPRDIV_NAME";
                ddlDiv.DataValueField = "CPRDIV_ID";
                ddlDiv.DataBind();
            }
            ddlDiv.Items.Insert(0, "--SELECT DIVISION--");
        }
    }
    // It build the Html table by using the datatable provided
    public string ConvertDataTableForPrint( DataTable dtCorp)
    {
        divTitle.InnerHtml = "Mess Calculation Report";
        //clsEntityManpwr_Process_Report objEntityManpwrReqmt = new clsEntityManpwr_Process_Report();
        //ClsBusiness_HCM_Reports objBusinessManpwrReqmt = new ClsBusiness_HCM_Reports();
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Mess Calculation Report";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string usrName = "";
        if (Session["USERFULLNAME"] != null)
        {
            usrName = "<B> Report Generated By: </B>" + Session["USERFULLNAME"];
        }
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
        string strUsrName = "";

        string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr + "</td></tr>";
        string strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        if (usrName != "")
        {
            strUsrName = "<tr><td class=\"RprtDiv\">" + usrName + "</td></tr>";
        }
        string strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
        string strCaptionTabstop = "</table>";

        string strYear= "";

        strYear = "<tr>Year : " + ddlYear.SelectedItem.Value + "<br/></tr>";

        string strMonth = "";

        strMonth = "<tr>Month : " + ddlMonth.SelectedItem.Text + "<br/></tr>";

        string strDep = "";

        if (ddlDepartmnt.SelectedItem.Value == "--SELECT DEPARTMENT--")
        {
            strDep = "";
        }
        else
        {
            strDep = "<tr>Department : " + ddlDepartmnt.SelectedItem.Text + "<br/></tr>";
        }


        string strDiv = "";

        if (ddlDiv.SelectedItem.Value == "--SELECT DIVISION--")
        {
            strDiv = "";
        }
        else
        {
            strDiv = "<tr>Division : " + ddlDiv.SelectedItem.Text + "<br/></tr>";
        }

        string strMess = "";
        if (ddlLeavTyp.SelectedItem.Text.ToString() == "--SELECT MESS--")
        {
            strMess = "";
        }
        else
        {
            strMess = "<tr>Mess : " + ddlLeavTyp.SelectedItem.Text.ToString() + "<br/></tr>";
        }

        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strUsrName + strCaptionTabTitle + strCaptionTabstop + strYear + strMonth + strDep + strDiv + strMess;

        sbCap.Append(strPrintCaptionTable);
        //write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString();
        clsEntity_Mess_Bill_Report objEntityManpwrReqmt = new clsEntity_Mess_Bill_Report();
        clsBusiness_Mess_Bill_Report objBusinessManpwrReqmt = new clsBusiness_Mess_Bill_Report();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityManpwrReqmt.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityManpwrReqmt.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            hiddenOrgId.Value = Session["ORGID"].ToString();
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }



        if (Session["USERID"] != null)
        {
            objEntityManpwrReqmt.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }



        if (ddlDiv.SelectedItem.Value != "--SELECT DIVISION--")
        {
            objEntityManpwrReqmt.DivsnId = Convert.ToInt32(ddlDiv.SelectedItem.Value);

        }
        if (ddlDepartmnt.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntityManpwrReqmt.DeptId = Convert.ToInt32(ddlDepartmnt.SelectedItem.Value);

        }

        if (ddlLeavTyp.SelectedItem.Value != "--SELECT MESS--")
        {
            objEntityManpwrReqmt.MessBillId = Convert.ToInt32(ddlLeavTyp.SelectedItem.Value);
        }

        clsCommonLibrary objCommon = new clsCommonLibrary();

        int intYear = Convert.ToInt32(ddlYear.SelectedItem.Text);
        int intMonth = Convert.ToInt32(ddlMonth.SelectedItem.Value);
        string EmDate = new DateTime(intYear, intMonth, 1).ToString("dd-MM-yyyy");
        DateTime ddateFrom = objCommon.textToDateTime(EmDate);

        int days = DateTime.DaysInMonth(intYear, intMonth);

        string EmToDate = new DateTime(intYear, intMonth, days).ToString("dd-MM-yyyy");
        DateTime ddateTo = objCommon.textToDateTime(EmToDate);

        objEntityManpwrReqmt.Fromdate = ddateFrom;
        objEntityManpwrReqmt.Todate = ddateTo;


        double intNumDayCal = 0;

        // intNumDayCal = (ddateTo - ddateFrom).TotalDays;

        DataTable dtAccomdtn = new DataTable();
        dtAccomdtn = objBusinessManpwrReqmt.ReadAccomodationDetails(objEntityManpwrReqmt);




        if (ddlLeavTyp.SelectedItem.Value != "--SELECT MESS--")
        {
            string LevMessid = ddlLeavTyp.SelectedItem.Value;
            for (int i = dtAccomdtn.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dtAccomdtn.Rows[i];
                string a = dr["ACCMDTN_ID"].ToString();
                if (a != LevMessid)
                    dr.Table.Rows.Remove(dr);
            }

        }


        // string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";



        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMP#</th>";


        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE</th>";


        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">DESIGNATION</th>";

        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">ACCOMMODATION/MESS</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">FROM DATE</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">TO DATE</th>";


        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: right; word-wrap:break-word;\">NO. OF DAYS</th>";


        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: right; word-wrap:break-word;\">AMOUNT</th>";










        strHtml += "</tr>";


        strHtml += "</thead>";
        //add rows
        int innertable = 0;
        strHtml += "<tbody>";
        string strUserIds = "";
        int inFirstloop = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dtAccomdtn.Rows.Count; intRowBodyCount++)
        {

            int innertableflag = 0;

            string Useridid = dtAccomdtn.Rows[intRowBodyCount]["USR_ID"].ToString();
            DataTable Copy = new DataTable();
            Copy = dtAccomdtn.Copy();
            // DataView view = new DataView(dtAccomdtn);

            for (int i = Copy.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = Copy.Rows[i];
                string a = dr["USR_ID"].ToString();
                if (a != Useridid)
                    Copy.Rows.Remove(dr);
                // dr.Table.Rows.Remove(dr);

            }

            int intRowspan = Copy.Rows.Count;

            DateTime EndDate = new DateTime(); DateTime StartDate = new DateTime(); decimal decAmount = 0, decAmountperday = 0;
            if (dtAccomdtn.Rows[intRowBodyCount]["MESSBILL_TO"].ToString() != "")
                EndDate = objCommon.textToDateTime(dtAccomdtn.Rows[intRowBodyCount]["MESSBILL_TO"].ToString());

            if (dtAccomdtn.Rows[intRowBodyCount]["MESSBILL_FROM"].ToString() != "")
                StartDate = objCommon.textToDateTime(dtAccomdtn.Rows[intRowBodyCount]["MESSBILL_FROM"].ToString());

            double INTNUMDAYS = 0;

            INTNUMDAYS = (EndDate - StartDate).TotalDays;

            if (dtAccomdtn.Rows[intRowBodyCount]["MESSEMP_AMNT"].ToString() != "")
                decAmount = Convert.ToDecimal(dtAccomdtn.Rows[intRowBodyCount]["MESSEMP_AMNT"].ToString());

            int NumMessbilDays = Convert.ToInt32(dtAccomdtn.Rows[intRowBodyCount]["MESSEMP_DAYS"].ToString());




            if (decAmount != 0)
                decAmountperday = decAmount / (decimal)NumMessbilDays;

            decimal EmpAmount = 0;



            EmpAmount = decAmountperday * (decimal)days;

            strHtml += "<tr  >";


            //string strId = dt.Rows[intRowBodyCount][0].ToString();
            //hiddenManpwrId.Value = strId;

            string status = "";
            string StsChk = "";
            if (!(strUserIds.Split(',').Contains(dtAccomdtn.Rows[intRowBodyCount]["USR_ID"].ToString())))
            {
                inFirstloop = 1;
                strHtml += "<td class=\"tdT\" rowspan=\"" + intRowspan + "\"  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtAccomdtn.Rows[intRowBodyCount]["USR_CODE"].ToString().ToUpper() + "</td>";

                strHtml += "<td class=\"tdT\" rowspan=\"" + intRowspan + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtAccomdtn.Rows[intRowBodyCount]["USR_NAME"].ToString().ToUpper() + "</td>";

                strHtml += "<td class=\"tdT\" rowspan=\"" + intRowspan + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtAccomdtn.Rows[intRowBodyCount]["DSGN_NAME"].ToString().ToUpper() + "</td>";

                string strAccomdtn = "";
                string strfrom = "";
                string strTo = "";
                string strdays = "";
                string stramnt = "";
                for (int intRowBodyCount1 = 0; intRowBodyCount1 < Copy.Rows.Count; intRowBodyCount1++)
                {
                    if (intRowBodyCount1 != 0)
                        strHtml += "<tr  >";
                    innertableflag = 1;
                    strAccomdtn = Copy.Rows[intRowBodyCount1]["ACCMDTN_NAME"].ToString().ToUpper();
                    strfrom = Copy.Rows[intRowBodyCount1]["MESSBILL_FROM"].ToString().ToUpper();

                    strTo = Copy.Rows[intRowBodyCount1]["MESSBILL_TO"].ToString().ToUpper();
                    strdays = Copy.Rows[intRowBodyCount1]["MESSEMP_DAYS"].ToString().ToUpper();
                    stramnt = Copy.Rows[intRowBodyCount1]["MESSEMP_AMNT"].ToString().ToUpper();
                    strHtml += "<td class=\"tdT\"   style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + strAccomdtn + "</td>";

                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: CENTER;\" >" + strfrom + "</td>";
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: CENTER;\" >" + strTo + "</td>";

                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strdays + "</td>";

                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + stramnt + "</td>";

                }

                strHtml += "</tr>";
            }


            if (strUserIds == "")
                strUserIds = dtAccomdtn.Rows[intRowBodyCount]["USR_ID"].ToString();
            else
            {


                strUserIds = strUserIds + "," + dtAccomdtn.Rows[intRowBodyCount]["USR_ID"].ToString();

            }
            //if (innertableflag == 0)
            //{
            //    strHtml += "<td  class=\"thT\"colspan=8 style=\"width:100%;text-align: center; word-wrap:break-word;\">NO DATA AVAILABLE</td></tr>";
            //}

            if (innertableflag != 1)
                strHtml += "</tr>";

        }
        if (inFirstloop == 0)
        {
            strHtml += "<tr  >";
            strHtml += "<td class=\"thT\"colspan=8 style=\"width:100%;text-align: center; word-wrap:break-word;\">NO DATA AVAILABLE</td></tr>";
            strHtml += "</tr>";
        }
        strHtml += "<tr id=\"Tdisplay\" style=\"display:none\">";
        strHtml += "<td class=\"thT\"colspan=8 style=\"width:100%;text-align: center; word-wrap:break-word;\">NO DATA AVAILABLE</td></tr>";
        strHtml += "</tr>";
        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
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
    public DataTable GetTable()
    {
        clsEntity_Mess_Bill_Report objEntityManpwrReqmt = new clsEntity_Mess_Bill_Report();
        clsBusiness_Mess_Bill_Report objBusinessManpwrReqmt = new clsBusiness_Mess_Bill_Report();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityManpwrReqmt.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityManpwrReqmt.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            hiddenOrgId.Value = Session["ORGID"].ToString();
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityManpwrReqmt.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (ddlDiv.SelectedItem.Value != "--SELECT DIVISION--")
        {
            objEntityManpwrReqmt.DivsnId = Convert.ToInt32(ddlDiv.SelectedItem.Value);
        }
        if (ddlDepartmnt.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntityManpwrReqmt.DeptId = Convert.ToInt32(ddlDepartmnt.SelectedItem.Value);
        }

        if (ddlLeavTyp.SelectedItem.Value != "--SELECT MESS--")
        {
            objEntityManpwrReqmt.MessBillId = Convert.ToInt32(ddlLeavTyp.SelectedItem.Value);
        }
        clsCommonLibrary objCommon = new clsCommonLibrary();
        int intYear = Convert.ToInt32(ddlYear.SelectedItem.Text);
        int intMonth = Convert.ToInt32(ddlMonth.SelectedItem.Value);
        string EmDate = new DateTime(intYear, intMonth, 1).ToString("dd-MM-yyyy");
        DateTime ddateFrom = objCommon.textToDateTime(EmDate);
        int days = DateTime.DaysInMonth(intYear, intMonth);
        string EmToDate = new DateTime(intYear, intMonth, days).ToString("dd-MM-yyyy");
        DateTime ddateTo = objCommon.textToDateTime(EmToDate);
        objEntityManpwrReqmt.Fromdate = ddateFrom;
        objEntityManpwrReqmt.Todate = ddateTo;
        double intNumDayCal = 0;
        DataTable dtAccomdtn = new DataTable();
        dtAccomdtn = objBusinessManpwrReqmt.ReadAccomodationDetails(objEntityManpwrReqmt);
        if (ddlLeavTyp.SelectedItem.Value != "--SELECT MESS--")
        {
            string LevMessid = ddlLeavTyp.SelectedItem.Value;
            for (int i = dtAccomdtn.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dtAccomdtn.Rows[i];
                string a = dr["ACCMDTN_ID"].ToString();
                if (a != LevMessid)
                    dr.Table.Rows.Remove(dr);
            }

        }
        DataTable table = new DataTable();
        table.Columns.Add("EMP#", typeof(string));
        table.Columns.Add("EMPLOYEE", typeof(string));
        table.Columns.Add("DESIGNATION", typeof(string));
        table.Columns.Add("ACCOMMODATION/MESS", typeof(string));
        table.Columns.Add("FROM DATE", typeof(string));
        table.Columns.Add("TO DATE", typeof(string));
        table.Columns.Add("NO. OF DAYS", typeof(string));
        table.Columns.Add("AMOUNT", typeof(string));
       
        string strUserIds = "";
        int inFirstloop = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dtAccomdtn.Rows.Count; intRowBodyCount++)
        {
            string EMPNO = "";
            string EMP = "";
            string DSGN = "";
   
            int innertableflag = 0;

            string Useridid = dtAccomdtn.Rows[intRowBodyCount]["USR_ID"].ToString();
            DataTable Copy = new DataTable();
            Copy = dtAccomdtn.Copy();
            for (int i = Copy.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = Copy.Rows[i];
                string a = dr["USR_ID"].ToString();
                if (a != Useridid)
                    Copy.Rows.Remove(dr);
            }
            int intRowspan = Copy.Rows.Count;
            DateTime EndDate = new DateTime(); DateTime StartDate = new DateTime(); decimal decAmount = 0, decAmountperday = 0;
            if (dtAccomdtn.Rows[intRowBodyCount]["MESSBILL_TO"].ToString() != "")
                EndDate = objCommon.textToDateTime(dtAccomdtn.Rows[intRowBodyCount]["MESSBILL_TO"].ToString());

            if (dtAccomdtn.Rows[intRowBodyCount]["MESSBILL_FROM"].ToString() != "")
                StartDate = objCommon.textToDateTime(dtAccomdtn.Rows[intRowBodyCount]["MESSBILL_FROM"].ToString());

            double INTNUMDAYS = 0;

            INTNUMDAYS = (EndDate - StartDate).TotalDays;

            if (dtAccomdtn.Rows[intRowBodyCount]["MESSEMP_AMNT"].ToString() != "")
                decAmount = Convert.ToDecimal(dtAccomdtn.Rows[intRowBodyCount]["MESSEMP_AMNT"].ToString());

            int NumMessbilDays = Convert.ToInt32(dtAccomdtn.Rows[intRowBodyCount]["MESSEMP_DAYS"].ToString());
            if (decAmount != 0)
                decAmountperday = decAmount / (decimal)NumMessbilDays;
            decimal EmpAmount = 0;
            EmpAmount = decAmountperday * (decimal)days;

            int flag= 0;
            if (!(strUserIds.Split(',').Contains(dtAccomdtn.Rows[intRowBodyCount]["USR_ID"].ToString())))
            {
                inFirstloop = 1;

                EMPNO= dtAccomdtn.Rows[intRowBodyCount]["USR_CODE"].ToString().ToUpper();

                EMP= dtAccomdtn.Rows[intRowBodyCount]["USR_NAME"].ToString().ToUpper();

                DSGN= dtAccomdtn.Rows[intRowBodyCount]["DSGN_NAME"].ToString().ToUpper();

                string strAccomdtn = "";
                string strfrom = "";
                string strTo = "";
                string strdays = "";
                string stramnt = "";
                for (int intRowBodyCount1 = 0; intRowBodyCount1 < Copy.Rows.Count; intRowBodyCount1++)
                {
                    innertableflag = 1;
                    strAccomdtn = Copy.Rows[intRowBodyCount1]["ACCMDTN_NAME"].ToString().ToUpper();
                    strfrom = Copy.Rows[intRowBodyCount1]["MESSBILL_FROM"].ToString().ToUpper();
                    strTo = Copy.Rows[intRowBodyCount1]["MESSBILL_TO"].ToString().ToUpper();
                    strdays = Copy.Rows[intRowBodyCount1]["MESSEMP_DAYS"].ToString().ToUpper();
                    stramnt = Copy.Rows[intRowBodyCount1]["MESSEMP_AMNT"].ToString().ToUpper();
                    if (flag == 0)
                    {
                        table.Rows.Add('"' + EMPNO + '"', '"' + EMP + '"', '"' + DSGN + '"', '"' + strAccomdtn + '"', '"' + strfrom + '"', '"' + strTo + '"', '"' + strdays + '"', '"' + stramnt + '"');
                        flag = 1;
                    }
                    else
                    {
                        table.Rows.Add('"' +"" +'"', '"' +"" +'"', '"' + ""+'"', '"' + strAccomdtn + '"', '"' + strfrom + '"', '"' + strTo + '"', '"' + strdays + '"', '"' + stramnt + '"');
                    }
                }
            }
            if (strUserIds == "")
                strUserIds = dtAccomdtn.Rows[intRowBodyCount]["USR_ID"].ToString();
            else
            {
                strUserIds = strUserIds + "," + dtAccomdtn.Rows[intRowBodyCount]["USR_ID"].ToString();
            }
     
        }
        return table;
    }
     protected void BtnCSV_Click(object sender, EventArgs e)
        {
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            DataTable dt = GetTable();
            string strResult = DataTableToCSV(dt, ',');
            string strImagePath = "";
            string filepath = "";
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            if (Session["ORGID"] != null)
            {
                objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            try
            {
                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.MESS_CALCULTN_RPRT_CSV);
                string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
                string newFilePath = Server.MapPath("/CustomFiles/HCM CSV/Mess Calculation/Mess Calculation_Report_" + strNextId + ".csv");
                System.IO.File.WriteAllText(newFilePath, strResult);
                filepath = "Mess Calculation_Report_" + strNextId + ".csv";
                Response.ContentType = "csv";
                strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.MESS_CALCULTN_RPRT_CSV);
                Response.AddHeader("content-Disposition", "attachment;filename=\"" + filepath + "\"");
                Response.TransmitFile(Server.MapPath(strImagePath) + filepath);
                Response.End();
                if (File.Exists(MapPath(strImagePath) + filepath))
                {
                    File.Delete(MapPath(strImagePath) + filepath);
                }

            }
            catch (Exception)
            { }
        }

}