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
// CREATED BY:EVM-0008
// CREATED DATE:12/04/2018
// REVIEWED BY:
// REVIEW DATE:

public partial class HCM_HCM_Reports_hcm_ManPowerProcess_Dtls_Report_hcm_ManPowerProcess_Dtls_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFromDate.Focus();
            clsEntityManpwr_Process_Report objEntityManpwrReqmt = new clsEntityManpwr_Process_Report();
            ClsBusiness_HCM_Reports objBusinessManpwrReqmt = new ClsBusiness_HCM_Reports();
            clsBusinessLayerInterviewProcess objBusinessIntervewProcess = new clsBusinessLayerInterviewProcess();
            clsEntityLayerInterviewProcess objEntityIntervewProcess = new clsEntityLayerInterviewProcess();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityIntervewProcess.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityManpwrReqmt.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                objEntityIntervewProcess.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

                objEntityManpwrReqmt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                hiddenOrgId.Value = Session["ORGID"].ToString();
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }



            if (Session["USERID"] != null)
            {
                objEntityManpwrReqmt.UserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            DataTable dtDivision = new DataTable();
            dtDivision = objBusinessManpwrReqmt.ReadProject(objEntityManpwrReqmt);
            ddlProjct.ClearSelection();
            ddlProjct.Items.Clear();
            if (dtDivision.Rows.Count > 0)
            {
                ddlProjct.DataSource = dtDivision;
                ddlProjct.DataTextField = "PROJECT_NAME";
                ddlProjct.DataValueField = "PROJECT_ID";
                ddlProjct.DataBind();
            }

            ddlProjct.Items.Insert(0, "--SELECT PROJECT--");

            DataTable dtDepts = new DataTable();
            dtDepts = objBusinessManpwrReqmt.ReadDepts(objEntityManpwrReqmt);
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


            DataTable dtemp = new DataTable();
            dtDepts = objBusinessManpwrReqmt.ReadEmployes(objEntityManpwrReqmt);
            ddlemployee.ClearSelection();
            ddlemployee.Items.Clear();
            if (dtDepts.Rows.Count > 0)
            {
                ddlemployee.DataSource = dtDepts;
                ddlemployee.DataTextField = "USR_NAME";
                ddlemployee.DataValueField = "USR_ID";
                ddlemployee.DataBind();
            }

          //  ddlemployee.Items.Insert(0, "--SELECT DEPARTMENT--");

            //for viewing table


            DataTable dtManpwr = new DataTable();
            objEntityManpwrReqmt.PrjctId = -1;
            objEntityManpwrReqmt.DeptId = -1;
            dtManpwr = objBusinessManpwrReqmt.ReadManpwrReqmtProcessDetls(objEntityManpwrReqmt);

            string strHtm = ConvertDataTableToHTML(dtManpwr, objEntityManpwrReqmt);
            divReport.InnerHtml = strHtm;

           // for printing table

            DataTable dtCorp = objBusinessIntervewProcess.Read_Corp_Details(objEntityIntervewProcess);


            string strPrintReport = ConvertDataTableForPrint(dtManpwr, dtCorp);
            divPrintReport.InnerHtml = strPrintReport;


        }

    }
    public string ConvertDataTableToHTML(DataTable dt,clsEntityManpwr_Process_Report objEnt)
    {

        clsEntityManpwr_Process_Report objEntityManpwrReqmt = new clsEntityManpwr_Process_Report();
        ClsBusiness_HCM_Reports objBusinessManpwrReqmt = new ClsBusiness_HCM_Reports();

        objEntityManpwrReqmt = objEnt;
        clsCommonLibrary objCommon = new clsCommonLibrary();
       // string strRandom = objCommon.Random_Number();

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
                    strHtml += "<th class=\"thT\" style=\"width:14%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 2)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 3)
                {
                    strHtml += "<th class=\"thT\" style=\"width:14%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 4)
                {
                    strHtml += "<th class=\"thT\" style=\"width:8%;text-align: right; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 5)
                {
                    strHtml += "<th class=\"thT\" style=\"width:8%;text-align: right; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 6)
                {
                    strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 7)
                {
                    strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }

            }
            strHtml += "<th class=\"thT\" style=\"width:8%;text-align: right; word-wrap:break-word;\">NO. OF CANDIDATES EVALUATED</th>";
            strHtml += "<th class=\"thT\" style=\"width:8%;text-align: right; word-wrap:break-word;\">NO. OF CANDIDATES SELECTED</th>";
        

       // strHtml += "<th class=\"thT\" style=\"width:11%; word-wrap:break-word;text-align: center;\">MORE INFO</th>";


        strHtml += "</tr>";


        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr  >";


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            hiddenManpwrId.Value = strId;

            string status = "";
            string StsChk = "";
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                int selctdCount = 0;
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                }
                if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                }
                if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                }

                if (intColumnBodyCount == 5)
                {
                    if (dt.Rows[intRowBodyCount]["MNPRQST_ID"].ToString() != "")
                        objEntityManpwrReqmt.ManPwrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["MNPRQST_ID"].ToString());
                    // dtManpwr = objBusinessManpwrReqmt.ReadManpwrShortListedById(objEntityManpwrReqmt);

                    int count = 0;
                    DataTable dtShrtlstdCandList = objBusinessManpwrReqmt.ReadShrtlistedCandidateList(objEntityManpwrReqmt);
                     count = dtShrtlstdCandList.Rows.Count;

                    strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + count + "</td>";
                }
                if (intColumnBodyCount == 6)
                {


                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                }
                if (intColumnBodyCount == 7)
                {


                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                }
                if (intColumnBodyCount == 8)
                {
                      
                   // DataTable dtManpwr = new DataTable();
                    if (dt.Rows[intRowBodyCount]["MNPRQST_ID"].ToString()!="")
                    objEntityManpwrReqmt.ManPwrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["MNPRQST_ID"].ToString());
                   // dtManpwr = objBusinessManpwrReqmt.ReadManpwrShortListedById(objEntityManpwrReqmt);
                    int numberOfRecords=0;

                    DataTable dtShrtlstdCandList = objBusinessManpwrReqmt.ReadShrtlistedCandidateList(objEntityManpwrReqmt);
                    if (dtShrtlstdCandList.Rows.Count > 0)
                    {
                        objEntityManpwrReqmt.UserId = Convert.ToInt32(dtShrtlstdCandList.Rows[0]["CAND_ID"].ToString());
                        numberOfRecords = dtShrtlstdCandList.Select("QUAL_LVLS >= '1'").Length;
                    }
                    DataTable dtCandSdlLvlNo = objBusinessManpwrReqmt.readSchdlList(objEntityManpwrReqmt);

                    for (int intRow = 0; intRow < dtShrtlstdCandList.Rows.Count; intRow++)
                    {
                        if (dtShrtlstdCandList.Rows[intRow]["QUAL_LVLS"].ToString() == dtCandSdlLvlNo.Rows.Count.ToString())
                        {
                            selctdCount++;
                        }
                    }

                    strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + numberOfRecords + "</td>";
                   
              
                    strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + selctdCount + "</td>";
                }
            }

           // strHtml += "<td class=\"tdT\" style=\"width:11%; word-wrap:break-word;text-align: center;\"><input type=\"button\" class=\"save\" style=\"height:22px;margin-top:3%\" value=\"More Info\" onclick=\"return OpenManPowerRequiremtDetails('" + strId + "','" + StsChk + "');\" /></td>";


            strHtml += "</tr>";

        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsEntityManpwr_Process_Report objEntityManpwrReqmt = new clsEntityManpwr_Process_Report();
        ClsBusiness_HCM_Reports objBusinessManpwrReqmt = new ClsBusiness_HCM_Reports();
        int intUserId = 0, intUsrRolMstrId, intEnableHRallocation = 0, intCorpId = 0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityManpwrReqmt.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityManpwrReqmt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            hiddenOrgId.Value = Session["ORGID"].ToString();
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }



        if (Session["USERID"] != null)
        {
            objEntityManpwrReqmt.UserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (txtFromDate.Text.Trim() != "")
        {
            objEntityManpwrReqmt.FromDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
          

        }
        if (txtToDate.Text.Trim() != "")
        {
            objEntityManpwrReqmt.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
           
        }
        if (ddlProjct.SelectedItem.Value != "--SELECT PROJECT--")
        {
            objEntityManpwrReqmt.PrjctId = Convert.ToInt32(ddlProjct.SelectedItem.Value);
          
        }
        if (ddlDepartmnt.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntityManpwrReqmt.DeptId = Convert.ToInt32(ddlDepartmnt.SelectedItem.Value);

        }
    
            //   string strEmpId = hiddenselectedlist.Value;


        if (hiddenselectedlist.Value != "" && hiddenselectedlist.Value != null)
        {
            string strEmpid = hiddenselectedlist.Value;
            objEntityManpwrReqmt.EmpId = hiddenselectedlist.Value;
        }
           // hiddenAssignedTo.Value = objEntityReqrmntAlctn.Employee_Id.ToString();


            DataTable dtManpwr = new DataTable();
            dtManpwr = objBusinessManpwrReqmt.ReadManpwrReqmtProcessDetls(objEntityManpwrReqmt);

            string strHtm = ConvertDataTableToHTML(dtManpwr, objEntityManpwrReqmt);
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

            string strprint = ConvertDataTableForPrint(dtManpwr, dtCorp);
            divPrintReport.InnerHtml = strprint;
    }

   // It build the Html table by using the datatable provided
    public string ConvertDataTableForPrint(DataTable dt, DataTable dtCorp)
    {
        clsEntityManpwr_Process_Report objEntityManpwrReqmt = new clsEntityManpwr_Process_Report();
        ClsBusiness_HCM_Reports objBusinessManpwrReqmt = new ClsBusiness_HCM_Reports();
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Manpower Process Details";
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
        string strUsrName = "";
        StringBuilder sbCap = new StringBuilder();
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

        string strFrom = "";
        if (txtFromDate.Text == "")
        {
            strFrom = "";
        }
        else
        {
            strFrom = "<tr>From date : " + txtFromDate.Text + "<br/></tr>";
        }
        string strTo = "";

        if (txtToDate.Text == "")
        {
            strTo = "";
        }
        else
        {
            strTo = "<tr>To date : " + txtToDate.Text + "<br/></tr>";
        }
       
        string strdept = "";
        if (ddlDepartmnt.SelectedItem.Text.ToString() == "--SELECT DEPARTMENT--")
        {
            strdept = "";
        }
        else
        {
            strdept = "<tr>Department : " + ddlDepartmnt.SelectedItem.Text.ToString() + "<br/></tr>";
        }
        string strAcc = "";
        if (hiddenselectedlist.Value != "")
        {
            if (Hiddenselectedtext.Value == "")
            {
                strAcc = "";
            }
            else
            {
                strAcc = "<tr>Assign To : " + Hiddenselectedtext.Value.TrimEnd(" , ".ToCharArray()) + "<br/></tr>";
            }
        }
        string strProject = "";
        if (ddlProjct.SelectedItem.Text.ToString() == "--SELECT PROJECT--")
        {
            strProject = "";
        }
        else
        {
            strProject = "<tr>Department : " + ddlProjct.SelectedItem.Text.ToString() + "<br/></tr>";
        }
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate +strUsrName+ strCaptionTabTitle + strCaptionTabstop+strFrom+strTo+strdept+strAcc+strProject;

        sbCap.Append(strPrintCaptionTable);
        //write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:14%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:22%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: right; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: right; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

        }
        strHtml += "<th class=\"thT\" style=\"width:8%;text-align: right; word-wrap:break-word;\">NO. OF CANDIDATES EVALUATED</th>";
        strHtml += "<th class=\"thT\" style=\"width:8%;text-align: right; word-wrap:break-word;\">NO. OF CANDIDATES SELECTED</th>";

        strHtml += "</tr>";

        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        if (dt.Rows.Count == 0)
        {
            strHtml += "<tr  ><td  class=\"thT\" colspan=\"9\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td></tr>";
        }
        else
        {
            int count = 1;
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                strHtml += "<tr  >";


                string strId = dt.Rows[intRowBodyCount][0].ToString();
                hiddenManpwrId.Value = strId;

                string status = "";
                string StsChk = "";
                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {
                    int selctdCount = 0;
                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                    }
                    if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                    }
                    if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                    }
                    if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                    }

                    if (intColumnBodyCount == 5)
                    {


                        strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                    }
                    if (intColumnBodyCount == 6)
                    {


                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                    }
                    if (intColumnBodyCount == 7)
                    {


                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                    }
                    if (intColumnBodyCount == 8)
                    {

                        // DataTable dtManpwr = new DataTable();
                        if (dt.Rows[intRowBodyCount]["MNPRQST_ID"].ToString() != "")
                            objEntityManpwrReqmt.ManPwrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["MNPRQST_ID"].ToString());
                        // dtManpwr = objBusinessManpwrReqmt.ReadManpwrShortListedById(objEntityManpwrReqmt);
                        int numberOfRecords = 0;

                        DataTable dtShrtlstdCandList = objBusinessManpwrReqmt.ReadShrtlistedCandidateList(objEntityManpwrReqmt);
                        if (dtShrtlstdCandList.Rows.Count > 0)
                        {
                            objEntityManpwrReqmt.UserId = Convert.ToInt32(dtShrtlstdCandList.Rows[0]["CAND_ID"].ToString());
                            numberOfRecords = dtShrtlstdCandList.Select("QUAL_LVLS >= '1'").Length;
                        }
                        DataTable dtCandSdlLvlNo = objBusinessManpwrReqmt.readSchdlList(objEntityManpwrReqmt);

                        for (int intRow = 0; intRow < dtShrtlstdCandList.Rows.Count; intRow++)
                        {
                            if (dtShrtlstdCandList.Rows[intRow]["QUAL_LVLS"].ToString() == dtCandSdlLvlNo.Rows.Count.ToString())
                            {
                                selctdCount++;
                            }
                        }

                        strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + numberOfRecords + "</td>";


                        strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + selctdCount + "</td>";
                    }
                }

                // strHtml += "<td class=\"tdT\" style=\"width:11%; word-wrap:break-word;text-align: center;\"><input type=\"button\" class=\"save\" style=\"height:22px;margin-top:3%\" value=\"More Info\" onclick=\"return OpenManPowerRequiremtDetails('" + strId + "','" + StsChk + "');\" /></td>";


                strHtml += "</tr>";

            }
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
        string strImagePath = "";
        string filepath = "";
        string strResult = DataTableToCSV(dt, ',');
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
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.MNPWR_PROCESS_DTL_RPRT_CSV);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
            string newFilePath = Server.MapPath("/CustomFiles/HCM CSV/Manpower_ProcessDtls/Manpower_Process_Details_Report_" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "Manpower_Process_Details_Report_" + strNextId + ".csv";
            Response.ContentType = "csv";
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.MNPWR_PROCESS_DTL_RPRT_CSV);
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
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        DataTable table = new DataTable();

        table.Columns.Add("REF#", typeof(string));
        table.Columns.Add("APPROVED DATE", typeof(string));
        table.Columns.Add("ASSIGNED TO", typeof(string));
        table.Columns.Add("NO. OF RESOURCES", typeof(string));
        table.Columns.Add("NO. OF RESOURCES SHORTLISTED", typeof(string));
        table.Columns.Add("PROJECT", typeof(string));
        table.Columns.Add("DEPARTMENT", typeof(string));
        table.Columns.Add("NO. OF CANDIDATES EVALUATED", typeof(string));
        table.Columns.Add("NO. OF CANDIDATES SELECTED", typeof(string));


        clsEntityManpwr_Process_Report objEntityManpwrReqmt = new clsEntityManpwr_Process_Report();
        ClsBusiness_HCM_Reports objBusinessManpwrReqmt = new ClsBusiness_HCM_Reports();
      
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
       
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityManpwrReqmt.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityManpwrReqmt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            hiddenOrgId.Value = Session["ORGID"].ToString();
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }



        if (Session["USERID"] != null)
        {
            objEntityManpwrReqmt.UserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (txtFromDate.Text.Trim() != "")
        {
            objEntityManpwrReqmt.FromDate = objCommon.textToDateTime(txtFromDate.Text.Trim());


        }
        if (txtToDate.Text.Trim() != "")
        {
            objEntityManpwrReqmt.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());

        }
        if (ddlProjct.SelectedItem.Value != "--SELECT PROJECT--")
        {
            objEntityManpwrReqmt.PrjctId = Convert.ToInt32(ddlProjct.SelectedItem.Value);

        }
        if (ddlDepartmnt.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntityManpwrReqmt.DeptId = Convert.ToInt32(ddlDepartmnt.SelectedItem.Value);

        }

        //   string strEmpId = hiddenselectedlist.Value;


        if (hiddenselectedlist.Value != "" && hiddenselectedlist.Value != null)
        {
            string strEmpid = hiddenselectedlist.Value;
            objEntityManpwrReqmt.EmpId = hiddenselectedlist.Value;
        }
        // hiddenAssignedTo.Value = objEntityReqrmntAlctn.Employee_Id.ToString();


        DataTable dt = new DataTable();
        dt = objBusinessManpwrReqmt.ReadManpwrReqmtProcessDetls(objEntityManpwrReqmt);




        //for printing table
        string Ref = "";
        string ApproveDate = "";
        string AssignedTo = "";
        string NoOfResources = "";
        string ResourceShortlisted = "";
        string Project = "";
        string Department = "";
        string CandidateEvaluvated = "";
        string CandidateSelected = "";

        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
          


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            hiddenManpwrId.Value = strId;

            string status = "";
            string StsChk = "";
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                int selctdCount = 0;
                if (intColumnBodyCount == 1)
                {
                    Ref = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper();
                }
                if (intColumnBodyCount == 2)
                {
                    ApproveDate = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper();
                }
                if (intColumnBodyCount == 3)
                {
                    AssignedTo = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper();
                }
                if (intColumnBodyCount == 4)
                {
                    NoOfResources = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper();
                }

                if (intColumnBodyCount == 5)
                {
                    if (dt.Rows[intRowBodyCount]["MNPRQST_ID"].ToString() != "")
                        objEntityManpwrReqmt.ManPwrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["MNPRQST_ID"].ToString());
                    // dtManpwr = objBusinessManpwrReqmt.ReadManpwrShortListedById(objEntityManpwrReqmt);

                    int count = 0;
                    DataTable dtShrtlstdCandList = objBusinessManpwrReqmt.ReadShrtlistedCandidateList(objEntityManpwrReqmt);
                    count = dtShrtlstdCandList.Rows.Count;
                    ResourceShortlisted = count.ToString();
                }
                if (intColumnBodyCount == 6)
                {

                    Project = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper();
                }
                if (intColumnBodyCount == 7)
                {
                    Department = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper();

                }
                if (intColumnBodyCount == 8)
                {

                    // DataTable dtManpwr = new DataTable();
                    if (dt.Rows[intRowBodyCount]["MNPRQST_ID"].ToString() != "")
                        objEntityManpwrReqmt.ManPwrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["MNPRQST_ID"].ToString());
                    // dtManpwr = objBusinessManpwrReqmt.ReadManpwrShortListedById(objEntityManpwrReqmt);
                    int numberOfRecords = 0;

                    DataTable dtShrtlstdCandList = objBusinessManpwrReqmt.ReadShrtlistedCandidateList(objEntityManpwrReqmt);
                    if (dtShrtlstdCandList.Rows.Count > 0)
                    {
                        objEntityManpwrReqmt.UserId = Convert.ToInt32(dtShrtlstdCandList.Rows[0]["CAND_ID"].ToString());
                        numberOfRecords = dtShrtlstdCandList.Select("QUAL_LVLS >= '1'").Length;
                    }
                    DataTable dtCandSdlLvlNo = objBusinessManpwrReqmt.readSchdlList(objEntityManpwrReqmt);

                    for (int intRow = 0; intRow < dtShrtlstdCandList.Rows.Count; intRow++)
                    {
                        if (dtShrtlstdCandList.Rows[intRow]["QUAL_LVLS"].ToString() == dtCandSdlLvlNo.Rows.Count.ToString())
                        {
                            selctdCount++;
                        }
                    }
                    CandidateEvaluvated = numberOfRecords.ToString();

                    CandidateSelected = selctdCount.ToString();
                }
            }
          
            table.Rows.Add('"' + Ref + '"', '"' + ApproveDate + '"', '"' + AssignedTo + '"', '"' + NoOfResources + '"', '"' + ResourceShortlisted + '"', '"' + Project + '"', '"' + Department + '"', '"' + CandidateEvaluvated + '"', '"' + CandidateSelected + '"');



        }


        return table;
    }
}