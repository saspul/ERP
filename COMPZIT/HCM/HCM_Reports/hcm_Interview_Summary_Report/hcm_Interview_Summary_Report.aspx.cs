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

public partial class HCM_HCM_Reports_hcm_Interview_Summary_Report_hcm_Interview_Summary_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlDepartmnt.Focus();
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
            dtDepts = objBusinessManpwrReqmt.ReadAprvdManpwrRqst(objEntityManpwrReqmt);
            ddlDepartmnt.ClearSelection();
            ddlDepartmnt.Items.Clear();
            if (dtDepts.Rows.Count > 0)
            {
                ddlDepartmnt.DataSource = dtDepts;
                ddlDepartmnt.DataTextField = "REF#";
                ddlDepartmnt.DataValueField = "MNPRQST_ID";
                ddlDepartmnt.DataBind();
            }

            ddlDepartmnt.Items.Insert(0, "--SELECT MANPOWER--");



            //  ddlemployee.Items.Insert(0, "--SELECT DEPARTMENT--");

            //for viewing table

             DataTable dtManpwr = new DataTable();
             dtManpwr = objBusinessManpwrReqmt.ReadManpwrSummaryDetls(objEntityManpwrReqmt);
           // string strHtm = "";
               string strHtm = ConvertDataTableToHTML(dtManpwr, objEntityManpwrReqmt);
            divReport.InnerHtml = strHtm;

            //for printing table

            DataTable dtCorp = objBusinessIntervewProcess.Read_Corp_Details(objEntityIntervewProcess);


            string strPrintReport = ConvertDataTableForPrint(dtManpwr, dtCorp);
            divPrintReport.InnerHtml = strPrintReport;


        }

    }

    public string ConvertDataTableToHTML(DataTable dt, clsEntityManpwr_Process_Report objEnt)
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

                strHtml += "<th class=\"thT\" style=\"width:30%;text-align: left; word-wrap:break-word;\">CANDIDATE NAME</th>";


                strHtml += "<th class=\"thT\" style=\"width:25%;text-align: left; word-wrap:break-word;\">PROJECT</th>";
         
          
                strHtml += "<th class=\"thT\" style=\"width:25%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";
        
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">INTERVIEW DATE</th>";

                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">DECISION</th>";
           
               

        
     

        // strHtml += "<th class=\"thT\" style=\"width:11%; word-wrap:break-word;text-align: center;\">MORE INFO</th>";


        strHtml += "</tr>";


        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr  >";

            string rejected = "false";
            string qualified = "false";
            string completeAll = "false";
             string hold ="false";

            clsBusinessLayerInterviewProcess objBusinessIntervewProcess = new clsBusinessLayerInterviewProcess();
            clsEntityLayerInterviewProcess objEntityIntervewProcess = new clsEntityLayerInterviewProcess();
            objEntityIntervewProcess.User_Id = Convert.ToInt32(dt.Rows[intRowBodyCount][0].ToString());

            if (ddlDepartmnt.SelectedItem.Value != "--SELECT MANPOWER--")
            {
                objEntityIntervewProcess.ReqrmntId = Convert.ToInt32(ddlDepartmnt.SelectedItem.Value);

            }
    
            //objEntityIntervewProcess.ReqrmntId = Convert.ToInt32(HiddenFieldReqrmntId.Value);
            DataTable dtCandRejectSts = objBusinessIntervewProcess.checkCandStatus(objEntityIntervewProcess);
            if (dtCandRejectSts.Rows.Count > 0)
            {
                rejected = "true";
            }
            //End:-For Checking candidate interview status

            //Start:-For checking candidate complete all levels and all are qualified
            DataTable dtCandSdlLvlNo = objBusinessIntervewProcess.readSchdlList(objEntityIntervewProcess);
            DataTable dtCandQulfdLvlNo = objBusinessIntervewProcess.readQualifiedLevel(objEntityIntervewProcess);
            int candTotalLvlNo = dtCandSdlLvlNo.Rows.Count;
            int candQlfiedLvlNo = Convert.ToInt32(dtCandQulfdLvlNo.Rows[0][0].ToString());

            DataTable dtComltAllLvl = objBusinessIntervewProcess.readCompleteLevel(objEntityIntervewProcess);
            int CompltAll = Convert.ToInt32(dtComltAllLvl.Rows[0][0].ToString());

            if (candTotalLvlNo == CompltAll && candTotalLvlNo != 0)
            {

                completeAll = "true";
            }

            if (candTotalLvlNo == candQlfiedLvlNo && candTotalLvlNo != 0)
            {
               // selctdCount++;
                qualified = "true";
            }

           if( dt.Rows[intRowBodyCount]["HOLD_STATUS"].ToString()=="1")
            {
                hold = "true";
            }

            string strId = dt.Rows[intRowBodyCount][0].ToString();
            hiddenManpwrId.Value = strId;

            string status = "";
            string StsChk = "";
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                int selctdCount = 0;
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CAND_NAME"].ToString().ToUpper() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PROJECT"].ToString().ToUpper() + "</td>";
                }
                if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DEPARTMENT"].ToString().ToUpper() + "</td>";
                }
                if (intColumnBodyCount == 4)
                {
                    string Strdate = "";
                    DataTable dtSchdlLvlEditInfo = objBusinessIntervewProcess.readSchdlLVlEditInfoDtls(objEntityIntervewProcess);
                    if (dtSchdlLvlEditInfo.Rows.Count > 0)
                    {
                        Strdate = dtSchdlLvlEditInfo.Rows[0]["INTERDATE"].ToString();
                    }

                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + Strdate + "</td>";
                }

                if (intColumnBodyCount == 5)
                {
                    string strDecision = "";
                    if (rejected == "true")
                    {
                        strDecision = "REJECTED";
                    }
                    else if (qualified == "true")
                    {
                        strDecision = "QUALIFIED";
                    }
                    else if (hold == "true")
                    {
                        strDecision = "HOLD";
                    }

                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >"+strDecision+"</td>";
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
     
        if (ddlProjct.SelectedItem.Value != "--SELECT PROJECT--")
        {
            objEntityManpwrReqmt.PrjctId = Convert.ToInt32(ddlProjct.SelectedItem.Value);

        }
        if (ddlDepartmnt.SelectedItem.Value != "--SELECT MANPOWER--")
        {
            objEntityManpwrReqmt.ManPwrId = Convert.ToInt32(ddlDepartmnt.SelectedItem.Value);

        }

        //   string strEmpId = hiddenselectedlist.Value;




        DataTable dtManpwr = new DataTable();
        dtManpwr = objBusinessManpwrReqmt.ReadManpwrSummaryDetls(objEntityManpwrReqmt);

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
        strTitle = "Interview Summary Report";
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
        string strMan = "";
        if (ddlDepartmnt.SelectedItem.Text.ToString() == "--SELECT MANPOWER--")
        {
            strMan = "";
        }
        else
        {
            strMan = "<tr>MPR Ref# : " + ddlDepartmnt.SelectedItem.Text.ToString() + "<br/></tr>";
        }
        string strAcc = "";

        if (ddlProjct.SelectedItem.Text.ToString() == "--SELECT PROJECT--")
        {
            strAcc = "";
        }
        else
        {
            strAcc = "<tr>Candidate : " + ddlProjct.SelectedItem.Text.ToString() + "<br/></tr>";
        }


        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strUsrName + strCaptionTabTitle + strCaptionTabstop+strMan+strAcc;

        sbCap.Append(strPrintCaptionTable);
        //write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";
        strHtml += "<th class=\"thT\" style=\"width:30%;text-align: left; word-wrap:break-word;\">CANDIDATE NAME</th>";


        strHtml += "<th class=\"thT\" style=\"width:25%;text-align: left; word-wrap:break-word;\">PROJECT</th>";


        strHtml += "<th class=\"thT\" style=\"width:25%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";

        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">INTERVIEW DATE</th>";

        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">DECISION</th>";
           

       

        strHtml += "</tr>";

        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        if (dt.Rows.Count == 0)
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"thT\"colspan=5 style=\"width:100%;text-align: center; word-wrap:break-word;\">No data available</td></tr>";
        }
        else
        {
            int count = 1;
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                strHtml += "<tr  >";

                string rejected = "false";
                string qualified = "false";
                string completeAll = "false";
                string hold = "false";

                clsBusinessLayerInterviewProcess objBusinessIntervewProcess = new clsBusinessLayerInterviewProcess();
                clsEntityLayerInterviewProcess objEntityIntervewProcess = new clsEntityLayerInterviewProcess();
                objEntityIntervewProcess.User_Id = Convert.ToInt32(dt.Rows[intRowBodyCount][0].ToString());

                if (ddlDepartmnt.SelectedItem.Value != "--SELECT MANPOWER--")
                {
                    objEntityIntervewProcess.ReqrmntId = Convert.ToInt32(ddlDepartmnt.SelectedItem.Value);

                }

                //objEntityIntervewProcess.ReqrmntId = Convert.ToInt32(HiddenFieldReqrmntId.Value);
                DataTable dtCandRejectSts = objBusinessIntervewProcess.checkCandStatus(objEntityIntervewProcess);
                if (dtCandRejectSts.Rows.Count > 0)
                {
                    rejected = "true";
                }
                //End:-For Checking candidate interview status

                //Start:-For checking candidate complete all levels and all are qualified
                DataTable dtCandSdlLvlNo = objBusinessIntervewProcess.readSchdlList(objEntityIntervewProcess);
                DataTable dtCandQulfdLvlNo = objBusinessIntervewProcess.readQualifiedLevel(objEntityIntervewProcess);
                int candTotalLvlNo = dtCandSdlLvlNo.Rows.Count;
                int candQlfiedLvlNo = Convert.ToInt32(dtCandQulfdLvlNo.Rows[0][0].ToString());

                DataTable dtComltAllLvl = objBusinessIntervewProcess.readCompleteLevel(objEntityIntervewProcess);
                int CompltAll = Convert.ToInt32(dtComltAllLvl.Rows[0][0].ToString());

                if (candTotalLvlNo == CompltAll && candTotalLvlNo != 0)
                {

                    completeAll = "true";
                }

                if (candTotalLvlNo == candQlfiedLvlNo && candTotalLvlNo != 0)
                {
                    // selctdCount++;
                    qualified = "true";
                }

                if (dt.Rows[intRowBodyCount]["HOLD_STATUS"].ToString() == "1")
                {
                    hold = "true";
                }

                string strId = dt.Rows[intRowBodyCount][0].ToString();
                hiddenManpwrId.Value = strId;

                string status = "";
                string StsChk = "";
                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {
                    int selctdCount = 0;
                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CAND_NAME"].ToString().ToUpper() + "</td>";
                    }
                    if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PROJECT"].ToString().ToUpper() + "</td>";
                    }
                    if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DEPARTMENT"].ToString().ToUpper() + "</td>";
                    }
                    if (intColumnBodyCount == 4)
                    {
                        string Strdate = "";
                        DataTable dtSchdlLvlEditInfo = objBusinessIntervewProcess.readSchdlLVlEditInfoDtls(objEntityIntervewProcess);
                        if (dtSchdlLvlEditInfo.Rows.Count > 0)
                        {
                            Strdate = dtSchdlLvlEditInfo.Rows[0]["INTERDATE"].ToString();
                        }

                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + Strdate + "</td>";
                    }

                    if (intColumnBodyCount == 5)
                    {
                        string strDecision = "";
                        if (rejected == "true")
                        {
                            strDecision = "REJECTED";
                        }
                        else if (qualified == "true")
                        {
                            strDecision = "QUALIFIED";
                        }
                        else if (hold == "true")
                        {
                            strDecision = "HOLD";
                        }

                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + strDecision + "</td>";
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
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INTERVIEW_SUMMARY_CSV);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
            string newFilePath = Server.MapPath("/CustomFiles/HCM CSV/InterviewSummary/InterviewSummary" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "InterviewSummary" + strNextId + ".csv";
            Response.ContentType = "csv";
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.INTERVIEW_SUMMARY_CSV);
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

        table.Columns.Add("CANDIDATE NAME", typeof(string));
        table.Columns.Add("PROJECT", typeof(string));
        table.Columns.Add("DEPARTMENT", typeof(string));
        table.Columns.Add("INTERVIEW DATE", typeof(string));
        table.Columns.Add("DECISION", typeof(string));


        clsEntityManpwr_Process_Report objEntityManpwrReqmt = new clsEntityManpwr_Process_Report();
        ClsBusiness_HCM_Reports objBusinessManpwrReqmt = new ClsBusiness_HCM_Reports();
        int intUserId = 0, intUsrRolMstrId, intEnableHRallocation = 0, intCorpId = 0;
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

        if (ddlProjct.SelectedItem.Value != "--SELECT PROJECT--")
        {
            objEntityManpwrReqmt.PrjctId = Convert.ToInt32(ddlProjct.SelectedItem.Value);

        }
        if (ddlDepartmnt.SelectedItem.Value != "--SELECT MANPOWER--")
        {
            objEntityManpwrReqmt.ManPwrId = Convert.ToInt32(ddlDepartmnt.SelectedItem.Value);

        }

        //   string strEmpId = hiddenselectedlist.Value;




        DataTable dt = new DataTable();
        dt = objBusinessManpwrReqmt.ReadManpwrSummaryDetls(objEntityManpwrReqmt);


        //for printing table
        string CandName = "";
        string Project = "";
        string Department = "";
        string InterviewDate = "";
        string Decision = "";
       
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
           

            string rejected = "false";
            string qualified = "false";
            string completeAll = "false";
            string hold = "false";

            clsBusinessLayerInterviewProcess objBusinessIntervewProcess = new clsBusinessLayerInterviewProcess();
            clsEntityLayerInterviewProcess objEntityIntervewProcess = new clsEntityLayerInterviewProcess();
            objEntityIntervewProcess.User_Id = Convert.ToInt32(dt.Rows[intRowBodyCount][0].ToString());

            if (ddlDepartmnt.SelectedItem.Value != "--SELECT MANPOWER--")
            {
                objEntityIntervewProcess.ReqrmntId = Convert.ToInt32(ddlDepartmnt.SelectedItem.Value);

            }

            //objEntityIntervewProcess.ReqrmntId = Convert.ToInt32(HiddenFieldReqrmntId.Value);
            DataTable dtCandRejectSts = objBusinessIntervewProcess.checkCandStatus(objEntityIntervewProcess);
            if (dtCandRejectSts.Rows.Count > 0)
            {
                rejected = "true";
            }
            //End:-For Checking candidate interview status

            //Start:-For checking candidate complete all levels and all are qualified
            DataTable dtCandSdlLvlNo = objBusinessIntervewProcess.readSchdlList(objEntityIntervewProcess);
            DataTable dtCandQulfdLvlNo = objBusinessIntervewProcess.readQualifiedLevel(objEntityIntervewProcess);
            int candTotalLvlNo = dtCandSdlLvlNo.Rows.Count;
            int candQlfiedLvlNo = Convert.ToInt32(dtCandQulfdLvlNo.Rows[0][0].ToString());

            DataTable dtComltAllLvl = objBusinessIntervewProcess.readCompleteLevel(objEntityIntervewProcess);
            int CompltAll = Convert.ToInt32(dtComltAllLvl.Rows[0][0].ToString());

            if (candTotalLvlNo == CompltAll && candTotalLvlNo != 0)
            {

                completeAll = "true";
            }

            if (candTotalLvlNo == candQlfiedLvlNo && candTotalLvlNo != 0)
            {
                // selctdCount++;
                qualified = "true";
            }

            if (dt.Rows[intRowBodyCount]["HOLD_STATUS"].ToString() == "1")
            {
                hold = "true";
            }

            string strId = dt.Rows[intRowBodyCount][0].ToString();
            hiddenManpwrId.Value = strId;

            string status = "";
            string StsChk = "";
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                int selctdCount = 0;
                if (intColumnBodyCount == 1)
                {
                    CandName = dt.Rows[intRowBodyCount]["CAND_NAME"].ToString().ToUpper();
                }
                if (intColumnBodyCount == 2)
                {
                    Project = dt.Rows[intRowBodyCount]["PROJECT"].ToString().ToUpper();
                }
                if (intColumnBodyCount == 3)
                {
                    Department = dt.Rows[intRowBodyCount]["DEPARTMENT"].ToString().ToUpper();
                }
                if (intColumnBodyCount == 4)
                {
                    string Strdate = "";
                    DataTable dtSchdlLvlEditInfo = objBusinessIntervewProcess.readSchdlLVlEditInfoDtls(objEntityIntervewProcess);
                    if (dtSchdlLvlEditInfo.Rows.Count > 0)
                    {
                        Strdate = dtSchdlLvlEditInfo.Rows[0]["INTERDATE"].ToString();
                    }
                    InterviewDate = Strdate;
                }

                if (intColumnBodyCount == 5)
                {
                    string strDecision = "";
                    if (rejected == "true")
                    {
                        strDecision = "REJECTED";
                    }
                    else if (qualified == "true")
                    {
                        strDecision = "QUALIFIED";
                    }
                    else if (hold == "true")
                    {
                        strDecision = "HOLD";
                    }
                    Decision = strDecision;
                }


            }


            table.Rows.Add('"' + CandName + '"', '"' + Project + '"', '"' + Department + '"', '"' + InterviewDate + '"', '"' + Decision + '"');


        }


        return table;
    }

}