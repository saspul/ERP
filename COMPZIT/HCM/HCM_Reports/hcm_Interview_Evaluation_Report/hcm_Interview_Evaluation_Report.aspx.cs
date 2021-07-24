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
using System.IO;
public partial class HCM_HCM_Reports_hcm_Interview_Evaluation_Report_hcm_Interview_Evaluation_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            clsEntityInterviewEvaltnReport objEntityOnBoarding_Status = new clsEntityInterviewEvaltnReport();
            clsBusinessInterviewEvaltnReport objBusinessOnBoarding_Status = new clsBusinessInterviewEvaltnReport();

            if (Session["USERID"] != null)
            {
                objEntityOnBoarding_Status.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityOnBoarding_Status.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                objEntityOnBoarding_Status.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                hiddenOrgId.Value = Session["ORGID"].ToString();
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            DataTable dtAprvdManPwr = new DataTable();
            dtAprvdManPwr = objBusinessOnBoarding_Status.ReadAprvdManpwrRqst(objEntityOnBoarding_Status);

            if (dtAprvdManPwr.Rows.Count > 0)
            {
                ddlManPower.DataSource = dtAprvdManPwr;
                ddlManPower.DataTextField = "REF#";
                ddlManPower.DataValueField = "MNPRQST_ID";
                ddlManPower.DataBind();
            }

            ddlManPower.Items.Insert(0, "--SELECT MANPOWER--");
            ddlCandidate.Items.Insert(0, "--SELECT CANDIDATE--");

            clsBusinessLayerInterviewProcess objBusinessIntervewProcess = new clsBusinessLayerInterviewProcess();
            clsEntityLayerInterviewProcess objEntityIntervewProcess = new clsEntityLayerInterviewProcess();
            if (Session["USERID"] != null)
            {
                objEntityIntervewProcess.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

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
            //objEntityIntervewProcess.ReqrmntId = Convert.ToInt32(strId);
            DataTable dtCorp = objBusinessIntervewProcess.Read_Corp_Details(objEntityIntervewProcess);

            DataTable dtCandidateDtls = new DataTable();
            dtCandidateDtls = objBusinessIntervewProcess.ReadShrtlistedCandidateList(objEntityIntervewProcess);

            string strHtm = ConvertDataTableToHTML(dtCandidateDtls);
            divReport.InnerHtml = strHtm;

            //for printing
            string strprint = ConvertDataTableForPrint(dtCandidateDtls, dtCorp);
            divPrintReport.InnerHtml = strprint;

        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

        clsBusinessLayerInterviewProcess objBusinessIntervewProcess = new clsBusinessLayerInterviewProcess();
        clsEntityLayerInterviewProcess objEntityIntervewProcess = new clsEntityLayerInterviewProcess();
        if (Session["USERID"] != null)
        {
            objEntityIntervewProcess.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
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
        if (ddlManPower.SelectedItem.Value != "--SELECT MANPOWER--")
        {
            objEntityIntervewProcess.ReqrmntId = Convert.ToInt32(ddlManPower.SelectedItem.Value);
        }
        DataTable dtCandidateDtls = new DataTable();
        if (ddlCandidate.SelectedItem.Value != "--SELECT CANDIDATE--")
        {
            dtCandidateDtls.Columns.Add("CandId", typeof(string));
            dtCandidateDtls.Columns.Add("CandName", typeof(string));
            DataRow dr = dtCandidateDtls.NewRow();
            dr[0] = ddlCandidate.SelectedItem.Value;
            dr[1] = ddlCandidate.SelectedItem.Text;
            dtCandidateDtls.Rows.Add(dr);
        }
        else
        {
            dtCandidateDtls = objBusinessIntervewProcess.ReadShrtlistedCandidateList(objEntityIntervewProcess);
        }
       
        string strHtm = ConvertDataTableToHTML(dtCandidateDtls);
        divReport.InnerHtml = strHtm;

        //for printing

        DataTable dtCorp = objBusinessIntervewProcess.Read_Corp_Details(objEntityIntervewProcess);

        string strprint = ConvertDataTableForPrint(dtCandidateDtls, dtCorp);
        divPrintReport.InnerHtml = strprint;

    }


    public string ConvertDataTableToHTML(DataTable dt)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        int flag = 0;
        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";      
        strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">CANDIDATE NAME</th>";
        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">INTERVIEW TEMPLATE</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">INTERVIEW DATE</th>";
        strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">INTERVIEWER</th>";
        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EVALUATION ROUND</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">SCORE</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">DECISION</th>";       
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

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
        objEntityIntervewProcess.User_Id = Convert.ToInt32(dt.Rows[intRowBodyCount][0].ToString());
        objEntityIntervewProcess.ReqrmntId = Convert.ToInt32(ddlManPower.SelectedItem.Value);


            DataTable dtSchdlLvlEditInfo = objBusinessIntervewProcess.readSchdlLVlEditInfoDtls(objEntityIntervewProcess);      
            for (int intRowBodyCountss = 0; intRowBodyCountss < dtSchdlLvlEditInfo.Rows.Count; intRowBodyCountss++)
            {
                string id = dtSchdlLvlEditInfo.Rows[intRowBodyCountss][5].ToString();
                objEntityIntervewProcess.SchdlLvlId = Convert.ToInt32(id);
                DataTable dtPnl= objBusinessIntervewProcess.readPanelDtls(objEntityIntervewProcess);

                if (dtPnl.Rows.Count > 0)
                {

                        strHtml += "<tr>";
                        if (intRowBodyCountss == 0)
                        {
                            if (intRowBodyCount == dt.Rows.Count - 1)
                            {
                                strHtml += "<td class=\"tdT\" rowspan=\"" + dtSchdlLvlEditInfo.Rows.Count + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][1].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + dtSchdlLvlEditInfo.Rows.Count + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["INVTEM_NAME"].ToString() + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" rowspan=\"" + dtSchdlLvlEditInfo.Rows.Count + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dt.Rows[intRowBodyCount][1].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + dtSchdlLvlEditInfo.Rows.Count + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["INVTEM_NAME"].ToString() + "</td>";
                            }
                        }
                        if (intRowBodyCountss == dtSchdlLvlEditInfo.Rows.Count - 1 && intRowBodyCount != dt.Rows.Count - 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;border-bottom: 1px solid #c9c9c9;\" >" + dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["INTERDATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtPnl.Rows[0][1].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["INVTEM_DLS_SHEDL_NAME"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;border-bottom: 1px solid #c9c9c9;\" >" + dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["INTSCR_NAME"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;border-bottom: 1px solid #c9c9c9;\" >" + dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["DECNAME"].ToString() + "</td>";
                            strHtml += "</tr>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["INTERDATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtPnl.Rows[0][1].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["INVTEM_DLS_SHEDL_NAME"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["INTSCR_NAME"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["DECNAME"].ToString() + "</td>";
                            strHtml += "</tr>";
                        }
                        flag++;
                   
                }
            }



        }
        if (flag == 0)
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"thT\"colspan=7 style=\"width:100%;text-align: center; word-wrap:break-word;\">No Data Available</td></tr>";
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
        strTitle = "Interview Evaluation Report";
        int flag=0;
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
        if (ddlManPower.SelectedItem.Text.ToString() == "--SELECT MANPOWER--")
        {
            strMan = "";
        }
        else
        {
            strMan = "<tr>MPR Ref# : " + ddlManPower.SelectedItem.Text.ToString() + "<br/></tr>";
        }
        string strAcc = "";

        if (ddlCandidate.SelectedItem.Text.ToString() == "--SELECT CANDIDATE--")
        {
            strAcc = "";
        }
        else
        {
            strAcc = "<tr>Candidate : " + ddlCandidate.SelectedItem.Text.ToString() + "<br/></tr>";
        }


        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strUsrName + strCaptionTabTitle + strCaptionTabstop + strMan + strAcc;

        sbCap.Append(strPrintCaptionTable);
        //write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";   
            strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">CANDIDATE NAME</th>";
            strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">INTERVIEW TEMPLATE</th>";
            strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">INTERVIEW DATE</th>";
            strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">INTERVIEWER</th>";
            strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EVALUATION ROUND</th>";
            strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">SCORE</th>";
            strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">DECISION</th>"; 
            strHtml += "</tr>";

        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
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
        objEntityIntervewProcess.User_Id = Convert.ToInt32(dt.Rows[intRowBodyCount][0].ToString());
        objEntityIntervewProcess.ReqrmntId = Convert.ToInt32(ddlManPower.SelectedItem.Value);


            DataTable dtSchdlLvlEditInfo = objBusinessIntervewProcess.readSchdlLVlEditInfoDtls(objEntityIntervewProcess);      
            for (int intRowBodyCountss = 0; intRowBodyCountss < dtSchdlLvlEditInfo.Rows.Count; intRowBodyCountss++)
            {
                string id = dtSchdlLvlEditInfo.Rows[intRowBodyCountss][5].ToString();
                objEntityIntervewProcess.SchdlLvlId = Convert.ToInt32(id);
                DataTable dtPnl= objBusinessIntervewProcess.readPanelDtls(objEntityIntervewProcess);

                if (dtPnl.Rows.Count > 0)
                {

                        strHtml += "<tr>";
                        if (intRowBodyCountss == 0)
                        {
                            if (intRowBodyCount == dt.Rows.Count - 1)
                            {
                                strHtml += "<td class=\"tdT\" rowspan=\"" + dtSchdlLvlEditInfo.Rows.Count + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][1].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + dtSchdlLvlEditInfo.Rows.Count + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["INVTEM_NAME"].ToString() + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" rowspan=\"" + dtSchdlLvlEditInfo.Rows.Count + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dt.Rows[intRowBodyCount][1].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + dtSchdlLvlEditInfo.Rows.Count + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["INVTEM_NAME"].ToString() + "</td>";
                            }
                        }
                        if (intRowBodyCountss == dtSchdlLvlEditInfo.Rows.Count - 1 && intRowBodyCount != dt.Rows.Count - 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;border-bottom: 1px solid #c9c9c9;\" >" + dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["INTERDATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtPnl.Rows[0][1].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["INVTEM_DLS_SHEDL_NAME"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;border-bottom: 1px solid #c9c9c9;\" >" + dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["INTSCR_NAME"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;border-bottom: 1px solid #c9c9c9;\" >" + dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["DECNAME"].ToString() + "</td>";
                            strHtml += "</tr>";
                        }
                        else
                        {

                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["INTERDATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtPnl.Rows[0][1].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["INVTEM_DLS_SHEDL_NAME"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["INTSCR_NAME"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["DECNAME"].ToString() + "</td>";
                            strHtml += "</tr>";
                        }
                        flag++;
                   
                }
            }
        }
        if (flag == 0)
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"thT\"colspan=7 style=\"width:100%;text-align: center; word-wrap:break-word;\">No Data Available</td></tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        //write to divPrintReport
        return sb.ToString();
    }

    protected void ddlManPower_SelectedIndexChanged(object sender, EventArgs e)
    {
        clsBusinessLayerInterviewProcess objBusinessIntervewProcess = new clsBusinessLayerInterviewProcess();
        clsEntityLayerInterviewProcess objEntityIntervewProcess = new clsEntityLayerInterviewProcess();
        if (Session["USERID"] != null)
        {
            objEntityIntervewProcess.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
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
        ddlCandidate.Items.Clear();
        if (ddlManPower.SelectedItem.Value != "--SELECT MANPOWER--")
        {
            objEntityIntervewProcess.ReqrmntId = Convert.ToInt32(ddlManPower.SelectedItem.Value);
            DataTable dtCandidateDtls = new DataTable();
            dtCandidateDtls = objBusinessIntervewProcess.ReadShrtlistedCandidateList(objEntityIntervewProcess);        
            if (dtCandidateDtls.Rows.Count > 0)
            {
                ddlCandidate.DataSource = dtCandidateDtls;
                ddlCandidate.DataTextField = "CAND_NAME";
                ddlCandidate.DataValueField = "CAND_ID";
                ddlCandidate.DataBind();
            }
        }
        ddlCandidate.Items.Insert(0, "--SELECT CANDIDATE--");
        ddlManPower.Focus();
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
        clsBusinessLayerInterviewProcess objBusinessIntervewProcess = new clsBusinessLayerInterviewProcess();
        clsEntityLayerInterviewProcess objEntityIntervewProcess = new clsEntityLayerInterviewProcess();
        if (Session["USERID"] != null)
        {
            objEntityIntervewProcess.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
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
        if (ddlManPower.SelectedItem.Value != "--SELECT MANPOWER--")
        {
            objEntityIntervewProcess.ReqrmntId = Convert.ToInt32(ddlManPower.SelectedItem.Value);
        }
        DataTable dt = new DataTable();
        if (ddlCandidate.SelectedItem.Value != "--SELECT CANDIDATE--")
        {
            dt.Columns.Add("CandId", typeof(string));
            dt.Columns.Add("CandName", typeof(string));
            DataRow dr = dt.NewRow();
            dr[0] = ddlCandidate.SelectedItem.Value;
            dr[1] = ddlCandidate.SelectedItem.Text;
            dt.Rows.Add(dr);
        }
        else
        {
            dt = objBusinessIntervewProcess.ReadShrtlistedCandidateList(objEntityIntervewProcess);
        }
        DataTable table = new DataTable();
        table.Columns.Add("CANDIDATE NAME", typeof(string));
        table.Columns.Add("INTERVIEW TEMPLATE", typeof(string));
        table.Columns.Add("INTERVIEW DATE", typeof(string));
        table.Columns.Add("INTERVIEWER", typeof(string));
        table.Columns.Add("EVALUATION ROUND", typeof(string));
        table.Columns.Add("SCORE", typeof(string));
        table.Columns.Add("DECISION", typeof(string));
        int flag = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string EMP = "";
            string TEMPLATE = "";
            string DATE = "";
            string INTERVIEWER = "";
            string ROUND = "";
            string SCORE = "";
            string DECISION = "";

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
            objEntityIntervewProcess.User_Id = Convert.ToInt32(dt.Rows[intRowBodyCount][0].ToString());
            objEntityIntervewProcess.ReqrmntId = Convert.ToInt32(ddlManPower.SelectedItem.Value);
            DataTable dtSchdlLvlEditInfo = objBusinessIntervewProcess.readSchdlLVlEditInfoDtls(objEntityIntervewProcess);
            int flagSpan = 0;
            for (int intRowBodyCountss = 0; intRowBodyCountss < dtSchdlLvlEditInfo.Rows.Count; intRowBodyCountss++)
            {
                string id = dtSchdlLvlEditInfo.Rows[intRowBodyCountss][5].ToString();
                objEntityIntervewProcess.SchdlLvlId = Convert.ToInt32(id);
                DataTable dtPnl = objBusinessIntervewProcess.readPanelDtls(objEntityIntervewProcess);

                if (dtPnl.Rows.Count > 0)
                {
                    if (intRowBodyCountss == 0)
                    {
                        if (intRowBodyCount == dt.Rows.Count - 1)
                        {
                            EMP = dt.Rows[intRowBodyCount][1].ToString();
                            TEMPLATE = dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["INVTEM_NAME"].ToString();
                        }
                        else
                        {
                            EMP = dt.Rows[intRowBodyCount][1].ToString();
                            TEMPLATE = dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["INVTEM_NAME"].ToString();
                        }
                    }
                    if (intRowBodyCountss == dtSchdlLvlEditInfo.Rows.Count - 1 && intRowBodyCount != dt.Rows.Count - 1)
                    {
                        DATE = dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["INTERDATE"].ToString();
                        INTERVIEWER = dtPnl.Rows[0][1].ToString();
                        ROUND = dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["INVTEM_DLS_SHEDL_NAME"].ToString();
                        SCORE = dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["INTSCR_NAME"].ToString();
                        DECISION = dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["DECNAME"].ToString();
                        if (flagSpan == 0)
                        {
                            table.Rows.Add('"' + EMP + '"', '"' + TEMPLATE + '"', '"' + DATE + '"', '"' + INTERVIEWER + '"', '"' + ROUND + '"', '"' + SCORE + '"', '"' + DECISION + '"');
                            flagSpan = 1;
                        }
                        else
                        {
                            table.Rows.Add('"' + "" + '"', '"' + "" + '"', '"' + DATE + '"', '"' + INTERVIEWER + '"', '"' + ROUND + '"', '"' + SCORE + '"', '"' + DECISION + '"');

                        }
                    }
                    else
                    {
                        DATE = dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["INTERDATE"].ToString();
                        INTERVIEWER = dtPnl.Rows[0][1].ToString();
                        ROUND = dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["INVTEM_DLS_SHEDL_NAME"].ToString();
                        SCORE = dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["INTSCR_NAME"].ToString();
                        DECISION = dtSchdlLvlEditInfo.Rows[intRowBodyCountss]["DECNAME"].ToString();
                        if (flagSpan == 0)
                        {
                            table.Rows.Add('"' + EMP + '"', '"' + TEMPLATE + '"', '"' + DATE + '"', '"' + INTERVIEWER + '"', '"' + ROUND + '"', '"' + SCORE + '"', '"' + DECISION + '"');
                            flagSpan = 1;
                        }
                        else
                        {
                            table.Rows.Add('"' + "" + '"', '"' + "" + '"', '"' + DATE + '"', '"' + INTERVIEWER + '"', '"' + ROUND + '"', '"' + SCORE + '"', '"' + DECISION + '"');

                        }
                    }
                    flag++;

                }

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
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INTERVIEW_EVLVTN_RPRT_CSV);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
            string newFilePath = Server.MapPath("/CustomFiles/HCM CSV/Interview Evaluation/Interview_Evaluation_" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "Interview_Evaluation_" + strNextId + ".csv";
            Response.ContentType = "csv";
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.INTERVIEW_EVLVTN_RPRT_CSV);
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