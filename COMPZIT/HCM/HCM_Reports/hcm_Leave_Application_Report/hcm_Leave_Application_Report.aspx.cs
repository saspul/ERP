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
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using System.Web.Services;
using EL_Compzit;
using System.IO;
public partial class HCM_HCM_Reports_hcm_Leave_Application_Report_hcm_Leave_Application_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtFromDate.Focus();
        if (!IsPostBack)
        {
            Corp_DivisionLoad();
            DepartmentLoad();
            LeaveTypeLoad();
            search();
        }
    }
    public void LeaveTypeLoad()
    {
        clsEntityLeaveApplicationReport objentityPassport = new clsEntityLeaveApplicationReport();
        clsBusinessLeaveApplicationReport objBussinesspasprt = new clsBusinessLeaveApplicationReport();
        if (Session["CORPOFFICEID"] != null)
        {
            objentityPassport.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objentityPassport.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objentityPassport.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBussinesspasprt.ReadLeaveType(objentityPassport);

        if (dtSubConrt.Rows.Count > 0)
        {
            ddlLeaveType.DataSource = dtSubConrt;
            ddlLeaveType.DataTextField = "LEAVETYP_NAME";
            ddlLeaveType.DataValueField = "LEAVETYP_ID";
            ddlLeaveType.DataBind();
        }
        ddlLeaveType.Items.Insert(0, "--SELECT--");
    }
    public void Corp_DivisionLoad()
    {
        ClsEntity_Passport_Handover_Sts objentityPassport = new ClsEntity_Passport_Handover_Sts();
        ClsBussiness_Passport_Handover_Sts objBussinesspasprt = new ClsBussiness_Passport_Handover_Sts();

        if (Session["CORPOFFICEID"] != null)
        {
            objentityPassport.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objentityPassport.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objentityPassport.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBussinesspasprt.ReadDivision(objentityPassport);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlDivision.DataSource = dtSubConrt;
            ddlDivision.DataTextField = "CPRDIV_NAME";
            ddlDivision.DataValueField = "CPRDIV_ID";
            ddlDivision.DataBind();
        }
        ddlDivision.Items.Insert(0, "--SELECT--");
    }
   
    public void DepartmentLoad()
    {
        ClsEntity_Passport_Handover_Sts objentityPassport = new ClsEntity_Passport_Handover_Sts();
        ClsBussiness_Passport_Handover_Sts objBussinesspasprt = new ClsBussiness_Passport_Handover_Sts();
        if (Session["CORPOFFICEID"] != null)
        {
            objentityPassport.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objentityPassport.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objentityPassport.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBussinesspasprt.ReadDepartment(objentityPassport);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlDepartment.DataSource = dtSubConrt;
            ddlDepartment.DataTextField = "CPRDEPT_NAME";
            ddlDepartment.DataValueField = "CPRDEPT_ID";
            ddlDepartment.DataBind();
        }
        ddlDepartment.Items.Insert(0, "--SELECT--");
    }
    protected void ddlDepartment_SelectedIndexChanged1(object sender, EventArgs e)
    {
        clsEntityWelfareServiceTransaction objentityPassport = new clsEntityWelfareServiceTransaction();
        clsBusinessWelfareServiceTransaction objBussinesspasprt = new clsBusinessWelfareServiceTransaction();
        if (Session["CORPOFFICEID"] != null)
        {
            objentityPassport.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objentityPassport.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objentityPassport.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ddlDivision.Items.Clear();
        if (ddlDepartment.SelectedItem.Value != "--SELECT--")
        {
            objentityPassport.department = Convert.ToInt32(ddlDepartment.SelectedItem.Value);
            DataTable dtEmployee = objBussinesspasprt.ReadDivisionDDL(objentityPassport);
            if (dtEmployee.Rows.Count > 0)
            {
                ddlDivision.DataSource = dtEmployee;
                ddlDivision.DataTextField = "CPRDIV_NAME";
                ddlDivision.DataValueField = "CPRDIV_ID";
                ddlDivision.DataBind();
            }
            ddlDivision.Items.Insert(0, "--SELECT--");
        }
        else
        {
            Corp_DivisionLoad();
        }
        ddlDepartment.Focus();
    }

    public void search()
    {

        clsBusinessLeaveApplicationReport objBusinessJoingIntimation = new clsBusinessLeaveApplicationReport();
        clsEntityLeaveApplicationReport objEntityJoiningList = new clsEntityLeaveApplicationReport();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["USERID"] != null)
        {
            objEntityJoiningList.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJoiningList.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityJoiningList.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (ddlLeaveType.SelectedItem.Value != "--SELECT--")
        {
            objEntityJoiningList.LeaveTypeId = Convert.ToInt32(ddlLeaveType.SelectedItem.Value);
        }
        if (ddlDepartment.SelectedItem.Value != "--SELECT--")
        {
            objEntityJoiningList.DesgnId = Convert.ToInt32(ddlDepartment.SelectedItem.Value);
        }
        if (ddlDivision.SelectedItem.Value != "--SELECT--")
        {
            objEntityJoiningList.DivsnId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        }
        objEntityJoiningList.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);

        if (txtFromDate.Text != "")
        {
            objEntityJoiningList.FromDate = objCommon.textToDateTime(txtFromDate.Text);
        }
        if (txtToDate.Text != "")
        {
            objEntityJoiningList.ToDate = objCommon.textToDateTime(txtToDate.Text);
        }

        DataTable dtShortlistcandidates = objBusinessJoingIntimation.ReadListReport(objEntityJoiningList);
        DataTable dtShortlistedcandidatelist = null;
        string strHtm = ConvertDataTableToHTML(dtShortlistcandidates, dtShortlistedcandidatelist);

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
        string strprint = ConvertDataTableForPrint(dtShortlistcandidates, dtCorp);
        divPrintReport.InnerHtml = strprint;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        search();
    }
    public string ConvertDataTableToHTML(DataTable dt, DataTable Shortlist)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">DATE OF REQUEST</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";
        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE</th>";
        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">DESIGNATION</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">LEAVE TYPE</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">FROM DATE</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">TO DATE</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">STATUS</th>";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            string status = "";
            if (ddlStatus.SelectedItem.Value == "9")
            {

                status = dt.Rows[intRowBodyCount]["STATUS"].ToString();
                if (dt.Rows[intRowBodyCount][12].ToString() == "0")
                {                   
                    if (dt.Rows[intRowBodyCount]["STATUS"].ToString() == "CANCELLED")
                    {
                        if (dt.Rows[intRowBodyCount]["STS3"].ToString() != "")
                        {
                            status = "CLOSED";
                        }
                        else if (dt.Rows[intRowBodyCount]["STS2"].ToString() == "0")
                        {
                            status = "CANCEL PENDING";
                        }
                        else if (dt.Rows[intRowBodyCount]["STS2"].ToString() == "1")
                        {
                            status = "CANCELLED";
                        }             
                    }                 
                }
                else
                {
                    if (dt.Rows[intRowBodyCount]["STS2"].ToString() != "")
                    {
                        status = "CANCELLED";
                    }
                }
            }
            else
            {
                status = ddlStatus.SelectedItem.Text;
            }


            strHtml += "<tr  >";
            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["DATE REQST"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DSGN_NAME"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CPRDEPT_NAME"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["LEAVE TYPE"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["LEAVE DATE FROM"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["LEAVE DATE TO"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + status + "</td>";
            strHtml += "</tr >";
        }
        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }

    //It build the Html table by using the datatable provided
    public string ConvertDataTableForPrint(DataTable dt, DataTable dtCorp)
    {

        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Leave Application Report";
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
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strUsrName+ strCaptionTabTitle + strCaptionTabstop;

        sbCap.Append(strPrintCaptionTable);
        //write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">DATE OF REQUEST</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";
        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE</th>";
        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">DESIGNATION</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">LEAVE TYPE</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">FROM DATE</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">TO DATE</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">STATUS</th>";
        strHtml += "</tr>";

        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            string status = "";
            if (ddlStatus.SelectedItem.Value == "9")
            {
                status = dt.Rows[intRowBodyCount]["STATUS"].ToString();
                if (dt.Rows[intRowBodyCount][12].ToString() == "0")
                {
                    if (dt.Rows[intRowBodyCount]["STATUS"].ToString() == "CANCELLED")
                    {
                        if (dt.Rows[intRowBodyCount]["STS3"].ToString() != "")
                        {
                            status = "CLOSED";
                        }
                        else if (dt.Rows[intRowBodyCount]["STS2"].ToString() == "0")
                        {
                            status = "CANCEL PENDING";
                        }
                        else if (dt.Rows[intRowBodyCount]["STS2"].ToString() == "1")
                        {
                            status = "CANCELLED";
                        }
                    }
                }
                else
                {
                    if (dt.Rows[intRowBodyCount]["STS2"].ToString() != "")
                    {
                        status = "CANCELLED";
                    }
                }
            }
            else
            {
                status = ddlStatus.SelectedItem.Text;
            }

            strHtml += "<tr  >";
            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["DATE REQST"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DSGN_NAME"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CPRDEPT_NAME"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["LEAVE TYPE"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["LEAVE DATE FROM"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["LEAVE DATE TO"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + status + "</td>";
            strHtml += "</tr >";
        }

        if (dt.Rows.Count == 0)
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"thT\"colspan=9 style=\"width:100%;text-align: center; word-wrap:break-word;padding: 0px 2px;\">No Data Available</td></tr>";
        }

        strHtml += "</tbody>";
        strHtml += "</table>";

        sb.Append(strHtml);
        //write to divPrintReport
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
        clsBusinessLeaveApplicationReport objBusinessJoingIntimation = new clsBusinessLeaveApplicationReport();
        clsEntityLeaveApplicationReport objEntityJoiningList = new clsEntityLeaveApplicationReport();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["USERID"] != null)
        {
            objEntityJoiningList.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJoiningList.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityJoiningList.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (ddlLeaveType.SelectedItem.Value != "--SELECT--")
        {
            objEntityJoiningList.LeaveTypeId = Convert.ToInt32(ddlLeaveType.SelectedItem.Value);
        }
        if (ddlDepartment.SelectedItem.Value != "--SELECT--")
        {
            objEntityJoiningList.DesgnId = Convert.ToInt32(ddlDepartment.SelectedItem.Value);
        }
        if (ddlDivision.SelectedItem.Value != "--SELECT--")
        {
            objEntityJoiningList.DivsnId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        }
        objEntityJoiningList.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);

        if (txtFromDate.Text != "")
        {
            objEntityJoiningList.FromDate = objCommon.textToDateTime(txtFromDate.Text);
        }
        if (txtToDate.Text != "")
        {
            objEntityJoiningList.ToDate = objCommon.textToDateTime(txtToDate.Text);
        }

        DataTable dt = objBusinessJoingIntimation.ReadListReport(objEntityJoiningList);
        DataTable table = new DataTable();
        table.Columns.Add("DATE OF REQUEST", typeof(string));
        table.Columns.Add("EMPLOYEE ID", typeof(string));
        table.Columns.Add("EMPLOYEE", typeof(string));
        table.Columns.Add("DESIGNATION", typeof(string));
        table.Columns.Add("DEPARTMENT", typeof(string));
        table.Columns.Add("LEAVE TYPE", typeof(string));
        table.Columns.Add("FROM DATE", typeof(string));
        table.Columns.Add("TO DATE", typeof(string));
        table.Columns.Add("STATUS", typeof(string));
        string strRandom = objCommon.Random_Number();
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string DATE = "";
            string EMPID = "";
            string EMP = "";
            string DSGN = "";
            string DEPT = "";
            string TYPE = "";
            string FROM = "";
            string TO = "";
            string STATUS = "";
            string status = "";
            if (ddlStatus.SelectedItem.Value == "9")
            {

                status = dt.Rows[intRowBodyCount]["STATUS"].ToString();
                if (dt.Rows[intRowBodyCount][12].ToString() == "0")
                {                   
                    if (dt.Rows[intRowBodyCount]["STATUS"].ToString() == "CANCELLED")
                    {
                        if (dt.Rows[intRowBodyCount]["STS3"].ToString() != "")
                        {
                            status = "CLOSED";
                        }
                        else if (dt.Rows[intRowBodyCount]["STS2"].ToString() == "0")
                        {
                            status = "CANCEL PENDING";
                        }
                        else if (dt.Rows[intRowBodyCount]["STS2"].ToString() == "1")
                        {
                            status = "CANCELLED";
                        }             
                    }                 
                }
                else
                {
                    if (dt.Rows[intRowBodyCount]["STS2"].ToString() != "")
                    {
                        status = "CANCELLED";
                    }
                }
            }
            else
            {
                status = ddlStatus.SelectedItem.Text;
            }
           DATE= dt.Rows[intRowBodyCount]["DATE REQST"].ToString();
           EMPID= dt.Rows[intRowBodyCount]["USR_CODE"].ToString();
           EMP= dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString();
           DSGN= dt.Rows[intRowBodyCount]["DSGN_NAME"].ToString();
           DEPT= dt.Rows[intRowBodyCount]["CPRDEPT_NAME"].ToString();
           TYPE= dt.Rows[intRowBodyCount]["LEAVE TYPE"].ToString();
           FROM= dt.Rows[intRowBodyCount]["LEAVE DATE FROM"].ToString();
           TO= dt.Rows[intRowBodyCount]["LEAVE DATE TO"].ToString();
           STATUS= status;
           table.Rows.Add('"' + DATE + '"', '"' + EMPID + '"', '"' + EMP + '"', '"' + DSGN + '"', '"' + DEPT + '"', '"' + TYPE + '"', '"' + FROM + '"', '"' + TO + '"', '"' + STATUS + '"');
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
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.LEAVE_APLICTN_RPRT_CSV);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
            string newFilePath = Server.MapPath("/CustomFiles/HCM CSV/Leave Application/Leave_Application_" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "Leave_Application_" + strNextId + ".csv";
            Response.ContentType = "csv";
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.LEAVE_APLICTN_RPRT_CSV);
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