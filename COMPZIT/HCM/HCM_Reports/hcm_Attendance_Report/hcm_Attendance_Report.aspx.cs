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
using System.Globalization;
using System.IO;
public partial class HCM_HCM_Reports_hcm_Attendance_Report_hcm_Attendance_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ddlMonth.Focus(); 
        if (!IsPostBack)
        {
          //  hiddenYear.Value = "";
            Corp_DivisionLoad();
            DepartmentLoad();
            projectLoad();
            YearLoad();
            monthLoad();
            search(0);
        }
    }
    protected void YearLoad()
    {

        ddlYear.Items.Clear();
        // created object for business layer for compare the date
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strCurrentDate = objBusiness.LoadCurrentDateInString();
        string[] split = strCurrentDate.Split('-');

        var currentYear = Convert.ToInt32(split[2]);
        for (int i = 0; i <= 20; i++)
        {
            // Now just add an entry that's the current year minus the counter
            ddlYear.Items.Add((currentYear - i).ToString());

        }
        ddlYear.Items.Insert(0, "--SELECT--");
    }
    public void monthLoad()
    {
        DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
        for (int i = 1; i < 13; i++)
        {
            ddlMonth.Items.Add(new ListItem(info.GetMonthName(i).ToUpper(), i.ToString()));
        }
        ddlMonth.Items.Insert(0, "--SELECT--");
    }
    public void Corp_DivisionLoad()
    {
        clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport = new clsEntityEmployeeDetailsReport();
        clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEmployeeDetailsreport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityEmployeeDetailsreport.OrganisationId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityEmployeeDetailsreport.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtDivision = objBusinessEmployeeDetailsReport.ReadDivision(objEntityEmployeeDetailsreport);
        if (dtDivision.Rows.Count > 0)
        {
            ddlDivision.Items.Clear();
            ddlDivision.DataSource = dtDivision;
            ddlDivision.DataValueField = "CPRDIV_ID";
            ddlDivision.DataTextField = "CPRDIV_NAME";
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
    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport = new clsEntityEmployeeDetailsReport();
        clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEmployeeDetailsreport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityEmployeeDetailsreport.OrganisationId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityEmployeeDetailsreport.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ddlProject.Items.Clear();
        if (ddlDivision.SelectedItem.Text != "--SELECT--")
        {
            objEntityEmployeeDetailsreport.DivisionId = Convert.ToInt32(ddlDivision.SelectedValue);
            DataTable dtProject = objBusinessEmployeeDetailsReport.ReadProject(objEntityEmployeeDetailsreport);
            if (dtProject.Rows.Count > 0)
            {
                ddlProject.DataSource = dtProject;
                ddlProject.DataValueField = "PROJECT_ID";
                ddlProject.DataTextField = "PROJECT_NAME";
                ddlProject.DataBind();
            }
            ddlProject.Items.Insert(0, "--SELECT--");
        }
        else
        {
            projectLoad();
        }
        ddlDivision.Focus();
        HiddenFieldFocus.Value = "div";
    }
    public void projectLoad()
    {
        clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport = new clsEntityEmployeeDetailsReport();
        clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEmployeeDetailsreport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityEmployeeDetailsreport.OrganisationId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityEmployeeDetailsreport.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int divid = 0;
        objEntityEmployeeDetailsreport.DivisionId = divid;
        DataTable dtProject = objBusinessEmployeeDetailsReport.ReadProject(objEntityEmployeeDetailsreport);
        if (dtProject.Rows.Count > 0)
        {
            ddlProject.DataSource = dtProject;
            ddlProject.DataValueField = "PROJECT_ID";
            ddlProject.DataTextField = "PROJECT_NAME";
            ddlProject.DataBind();
        }
        ddlProject.Items.Insert(0, "--SELECT--");
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
        projectLoad();
        ddlDepartment.Focus();
        HiddenFieldFocus.Value = "dep";
    }

    public void search(int x)
    {
        DataTable dtShortlistcandidates = new DataTable();
        if (x == 1)
        {
            clsBusinessAttendanceReport objBusinessJoingIntimation = new clsBusinessAttendanceReport();
            clsEntityAttendanceReport objEntityJoiningList = new clsEntityAttendanceReport();
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
            //if (ddlMonth.SelectedItem.Value != "--SELECT--")
            //{
            //    objEntityJoiningList.Month = ddlMonth.SelectedItem.Value;
            //    if (ddlMonth.SelectedItem.Value.Length == 1)
            //    {
            //        objEntityJoiningList.Month = "0" + ddlMonth.SelectedItem.Value;
            //    }
            //}
            //if (hiddenYear.Value != "")
            //{
            //    objEntityJoiningList.Year = hiddenYear.Value;
            //}
            if (ddlOtType.SelectedItem.Value != "--SELECT--")
            {
                objEntityJoiningList.OtType = Convert.ToInt32(ddlOtType.SelectedItem.Value);
            }
            if (ddlDepartment.SelectedItem.Value != "--SELECT--")
            {
                objEntityJoiningList.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedItem.Value);
            }
            if (ddlDivision.SelectedItem.Value != "--SELECT--")
            {
                objEntityJoiningList.DivsnId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
            }
            if (ddlProject.SelectedItem.Value != "--SELECT--")
            {
                objEntityJoiningList.ProjectId = Convert.ToInt32(ddlProject.SelectedItem.Value);
            }
            dtShortlistcandidates = objBusinessJoingIntimation.ReadListReport(objEntityJoiningList);
        }

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
        search(1);
    }
    public string ConvertDataTableToHTML(DataTable dt)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        strHtml += "<th class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">DATE</th>";
        strHtml += "<th class=\"thT\" style=\"width:13%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";
        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE</th>";
        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">DESIGNATION</th>";
        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">PROJECT</th>";
        strHtml += "<th class=\"thT\" style=\"width:8%;text-align: left; word-wrap:break-word;\">IDLE HOURS</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">OT TYPE</th>";
        strHtml += "<th class=\"thT\" style=\"width:7%;text-align: left; word-wrap:break-word;\">OT HOURS</th>";
        strHtml += "<th class=\"thT\" style=\"width:9%;text-align: left; word-wrap:break-word;\">TOTAL HOURS</th>";
        strHtml += "</tr>";
        strHtml += "</thead>";
        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            strHtml += "<tr  >";
            strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["DATE ATT"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DSGN_NAME"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PROJECT_NAME"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMDLHRDTL_IDLE_HOUR"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["OVRTMCATG_NAME"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMDLHRDTL_OT"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMDLHRDTL_RNDED_OT"].ToString() + "</td>";
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
        strTitle = "Attendance Report";
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
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strUsrName+strCaptionTabTitle + strCaptionTabstop;

        sbCap.Append(strPrintCaptionTable);
        //write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";
        strHtml += "<th class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">DATE</th>";
        strHtml += "<th class=\"thT\" style=\"width:13%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";
        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE</th>";
        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">DESIGNATION</th>";
        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">PROJECT</th>";
        strHtml += "<th class=\"thT\" style=\"width:8%;text-align: left; word-wrap:break-word;\">IDLE HOURS</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">OT TYPE</th>";
        strHtml += "<th class=\"thT\" style=\"width:7%;text-align: left; word-wrap:break-word;\">OT HOURS</th>";
        strHtml += "<th class=\"thT\" style=\"width:9%;text-align: left; word-wrap:break-word;\">TOTAL HOURS</th>";
        strHtml += "</tr>";

        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            strHtml += "<tr  >";
            strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["DATE ATT"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DSGN_NAME"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PROJECT_NAME"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMDLHRDTL_IDLE_HOUR"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["OVRTMCATG_NAME"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMDLHRDTL_OT"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMDLHRDTL_RNDED_OT"].ToString() + "</td>";
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
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.ATTENTANCE_RPRT_CSV);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
            string newFilePath = Server.MapPath("/CustomFiles/HCM CSV/Attendance/Attendance_Report_" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "Attendance_Report_" + strNextId + ".csv";
            Response.ContentType = "csv";
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.ATTENTANCE_RPRT_CSV);
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
        clsBusinessAttendanceReport objBusinessJoingIntimation = new clsBusinessAttendanceReport();
        clsEntityAttendanceReport objEntityJoiningList = new clsEntityAttendanceReport();
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


        if (txtFromDate.Text != "")
        {
            objEntityJoiningList.FromDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
        }


        //if (ddlMonth.SelectedItem.Value != "--SELECT--")
        //{
        //    objEntityJoiningList.Month = ddlMonth.SelectedItem.Value;
        //    if (ddlMonth.SelectedItem.Value.Length == 1)
        //    {
        //        objEntityJoiningList.Month = "0" + ddlMonth.SelectedItem.Value;
        //    }
        //}
        //if (hiddenYear.Value != "")  FromDate
        //{
        //    objEntityJoiningList.Year = hiddenYear.Value;
        //}
        if (ddlOtType.SelectedItem.Value != "--SELECT--")
        {
            objEntityJoiningList.OtType = Convert.ToInt32(ddlOtType.SelectedItem.Value);
        }
        if (ddlDepartment.SelectedItem.Value != "--SELECT--")
        {
            objEntityJoiningList.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedItem.Value);
        }
        if (ddlDivision.SelectedItem.Value != "--SELECT--")
        {
            objEntityJoiningList.DivsnId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        }
        if (ddlProject.SelectedItem.Value != "--SELECT--")
        {
            objEntityJoiningList.ProjectId = Convert.ToInt32(ddlProject.SelectedItem.Value);
        }
        DataTable dt = objBusinessJoingIntimation.ReadListReport(objEntityJoiningList);
        string strRandom = objCommon.Random_Number();
        DataTable table = new DataTable();
        table.Columns.Add("DATE", typeof(string));
        table.Columns.Add("EMPLOYEE ID", typeof(string));
        table.Columns.Add("EMPLOYEE", typeof(string));
        table.Columns.Add("DESIGNATION", typeof(string));
        table.Columns.Add("PROJECT", typeof(string));
        table.Columns.Add("IDLE HOURS", typeof(string));
        table.Columns.Add("OT TYPE", typeof(string));
        table.Columns.Add("OT HOURS", typeof(string));
        table.Columns.Add("TOTAL HOURS", typeof(string));
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string DATE = "";
            string EMPID = "";
            string EMP = "";
            string DSGN = "";
            string PRJCT = "";
            string TYPE = "";
            string IDLEHRS = "";
            string OTHRS = "";
            string TOTALHRS = "";
            DATE = dt.Rows[intRowBodyCount]["DATE ATT"].ToString();
            EMPID = dt.Rows[intRowBodyCount]["USR_CODE"].ToString();
            EMP = dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString();
            DSGN = dt.Rows[intRowBodyCount]["DSGN_NAME"].ToString();
            PRJCT = dt.Rows[intRowBodyCount]["PROJECT_NAME"].ToString();
            IDLEHRS = dt.Rows[intRowBodyCount]["EMDLHRDTL_IDLE_HOUR"].ToString();
            TYPE = dt.Rows[intRowBodyCount]["OVRTMCATG_NAME"].ToString();
            OTHRS = dt.Rows[intRowBodyCount]["EMDLHRDTL_OT"].ToString();
            TOTALHRS = dt.Rows[intRowBodyCount]["EMDLHRDTL_RNDED_OT"].ToString();
            table.Rows.Add('"' + DATE + '"', '"' + EMPID + '"', '"' + EMP + '"', '"' + DSGN + '"', '"' + PRJCT + '"', '"' + IDLEHRS + '"', '"' + TYPE + '"', '"' + OTHRS + '"', '"' + TOTALHRS + '"');
        }
        return table ;
    }

}