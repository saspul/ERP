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
public partial class HCM_HCM_Reports_hcm_Onboarding_Assignment_Report_hcm_Onboarding_Assignment_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ProjectLoad();
            Employee_load();
            Candidate_load();
            clsBusiness_OnBoardingProcess objBusinessOnboard = new clsBusiness_OnBoardingProcess();
            ClsEntityOnBoardingProcess objEntityOnBoard = new ClsEntityOnBoardingProcess();         
            objEntityOnBoard.StatusId = 1;
            DataTable dtCandidateList = objBusinessOnboard.ReadCandidates(objEntityOnBoard);
              
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
            DataTable dtCorp = objBusinessIntervewProcess.Read_Corp_Details(objEntityIntervewProcess);
            DataView dv = dtCandidateList.DefaultView;
            dv.Sort = "CANDIDATE NAME";
            dtCandidateList = dv.ToTable();

            string strHtm = ConvertDataTableToHTML(dtCandidateList,"page load");
            divReport.InnerHtml = strHtm;
            string strprint = ConvertDataTableForPrint(dtCandidateList, dtCorp,"page load");
            divPrintReport.InnerHtml = strprint;

        }

    }
    public void ProjectLoad()
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
        ddlProject.Items.Insert(0, "--SELECT PROJECT--");
    }

    public void Candidate_load()
    {
        clsBusiness_OnBoardingProcess objBusinessOnboard = new clsBusiness_OnBoardingProcess();
        ClsEntityOnBoardingProcess objEntityOnBoard = new ClsEntityOnBoardingProcess();
        objEntityOnBoard.StatusId = 1;
        DataTable dtCandidateList = objBusinessOnboard.ReadCandidates(objEntityOnBoard);
        ddlCandidate.Items.Clear();
        if (dtCandidateList.Rows.Count > 0)
        {
            ddlCandidate.DataSource = dtCandidateList;
            ddlCandidate.DataTextField = "CANDIDATE NAME";
            ddlCandidate.DataValueField = "CAND_ID";
            ddlCandidate.DataBind();
        }
      
    }
    public void Employee_load()
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
        objentityPassport.division = 0;
        objentityPassport.designation = 0;
        objentityPassport.department = 0;

        DataTable dtEmployee = objBussinesspasprt.ReadEmployee(objentityPassport);
        ddlAssgndTo.Items.Clear();
        if (dtEmployee.Rows.Count > 0)
        {
            ddlAssgndTo.DataSource = dtEmployee;
            ddlAssgndTo.DataTextField = "USR_NAME";
            ddlAssgndTo.DataValueField = "USR_ID";
            ddlAssgndTo.DataBind();
        }
        ddlAssgndTo.Items.Insert(0, "--SELECT EMPLOYEE--");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

        clsBusiness_OnBoardingProcess objBusinessOnboard = new clsBusiness_OnBoardingProcess();
        ClsEntityOnBoardingProcess objEntityOnBoard = new ClsEntityOnBoardingProcess();
        objEntityOnBoard.StatusId = 1;
        DataTable dtCandidateList = objBusinessOnboard.ReadCandidates(objEntityOnBoard);

        DataView dv = dtCandidateList.DefaultView;
        dv.Sort = "CANDIDATE NAME";
        dtCandidateList = dv.ToTable();

        string strHtm = ConvertDataTableToHTML(dtCandidateList, "Search");
        divReport.InnerHtml = strHtm;

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
        DataTable dtCorp = objBusinessIntervewProcess.Read_Corp_Details(objEntityIntervewProcess);
        string strprint = ConvertDataTableForPrint(dtCandidateList, dtCorp,"Search");
        divPrintReport.InnerHtml = strprint;

    }


    public string ConvertDataTableToHTML(DataTable dtCandData, string load)
    {
       
        int flag = 0;
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">CANDIDATE NAME</th>";
        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">PROJECT</th>";
        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";
        strHtml += "<th class=\"thT\" style=\"width:11%;text-align: left; word-wrap:break-word;\">PARTICULARS</th>";
        strHtml += "<th class=\"thT\" style=\"width:19%;text-align: left; word-wrap:break-word;\">STATUS</th>";
        strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">ASSIGNED TO</th>";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        strHtml += "<tbody>";
        if (load != "page load")
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dtCandData.Rows.Count; intRowBodyCount++)
            {

                string strCandSts = "T", strPrjctSts = "T";
                if (Hiddenselectedtext.Value != "")
                {
                    if (Hiddenselectedtext.Value.Contains(dtCandData.Rows[intRowBodyCount][0].ToString()) == false)
                    {
                        strCandSts = "F";
                    }
                }
                if (ddlProject.SelectedItem.Value != "--SELECT PROJECT--")
                {
                    if (ddlProject.SelectedItem.Value != dtCandData.Rows[intRowBodyCount]["PROJECT_ID"].ToString())
                    {
                        strPrjctSts = "F";
                    }
                }

                if (strCandSts == "T" && strPrjctSts == "T")
                {

                    clsBusiness_OnBoardingProcess objBusinessOnboard = new clsBusiness_OnBoardingProcess();
                    ClsEntityOnBoardingProcess objEntityOnBoard = new ClsEntityOnBoardingProcess();
                    objEntityOnBoard.CandId = Convert.ToInt32(dtCandData.Rows[intRowBodyCount][0].ToString());
                    DataTable dtCandData1 = objBusinessOnboard.ReadVisaDetailByCandId(objEntityOnBoard);
                    DataTable dtCandData2 = objBusinessOnboard.ReadFlightDetailByCandId(objEntityOnBoard);
                    DataTable dtCandData3 = objBusinessOnboard.ReadRoomDetailByCandId(objEntityOnBoard);
                    DataTable dtCandData4 = objBusinessOnboard.ReadAirDetailByCandId(objEntityOnBoard);
                    int PertclrCount = 4;
                    int i = 1;

                    string strAsgnSts1 = "T", strAsgnSts2 = "T", strAsgnSts3 = "T", strAsgnSts4 = "T";
                    string UsrName1 = "", UserId1 = "";
                    string UsrName2 = "", UserId2 = "";
                    string UsrName3 = "", UserId3 = "";
                    string UsrName4 = "", UserId4 = "";
                    string status1 = "", status2 = "", status3 = "", status4 = "";


                    if (ddlParticular.SelectedItem.Value != "0")
                    {
                        PertclrCount = 1;
                        if (ddlParticular.SelectedItem.Value == "1")
                        {
                            strAsgnSts2 = "F";
                            strAsgnSts3 = "F";
                            strAsgnSts4 = "F";
                        }
                        else if (ddlParticular.SelectedItem.Value == "2")
                        {
                            strAsgnSts1 = "F";
                            strAsgnSts3 = "F";
                            strAsgnSts4 = "F";
                        }
                        else if (ddlParticular.SelectedItem.Value == "3")
                        {
                            strAsgnSts1 = "F";
                            strAsgnSts2 = "F";
                            strAsgnSts4 = "F";
                        }
                        else if (ddlParticular.SelectedItem.Value == "4")
                        {
                            strAsgnSts1 = "F";
                            strAsgnSts2 = "F";
                            strAsgnSts3 = "F";
                        }
                    }


                    if (dtCandData1.Rows.Count > 0 && strAsgnSts1 == "T")
                    {

                        if (dtCandData1.Rows[0]["ONBRD_FNSH_STS"].ToString() == "1")
                        {
                            status1 = "FINISHED";
                        }
                        else if (dtCandData1.Rows[0]["ONBRD_CLOSE_STS"].ToString() == "1")
                        {
                            status1 = "CLOSED";
                        }
                        else if (dtCandData1.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "0")
                        {
                            status1 = "Job Assigned";
                        }
                        else if (dtCandData1.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "1")
                        {
                            status1 = "Document Preparation";
                        }
                        else if (dtCandData1.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "2")
                        {
                            status1 = "Applied, Awaiting MOI Approval";
                        }
                        else if (dtCandData1.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "3")
                        {
                            status1 = "MOI Approved, ready to print";
                        }
                        else if (dtCandData1.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "4")
                        {
                            status1 = "MOI rejected – Close";
                        }
                        else if (dtCandData1.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "5")
                        {
                            status1 = "MOI Rejected – Reapply";
                        }
                        else if (dtCandData1.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "6")
                        {
                            status1 = "Visa print complete";
                        }


                        objEntityOnBoard.OnboardingDetailId = Convert.ToInt32(dtCandData1.Rows[0]["ONBRDDTL_ID"]);
                        DataTable dtEmpId = objBusinessOnboard.ReadEmpByBoardDtl(objEntityOnBoard);
                        if (dtEmpId.Rows.Count > 0)
                        {
                            foreach (DataRow dt1 in dtEmpId.Rows)
                            {
                                if (UsrName1 == "")
                                {
                                    UsrName1 = dt1["USR_NAME1"].ToString();
                                    UserId1 = dt1["USR_ID"].ToString();
                                }
                                else
                                {
                                    UsrName1 = UsrName1 + "," + dt1["USR_NAME1"];
                                    UserId1 = UserId1 + "," + dt1["USR_ID"];
                                }
                            }
                        }
                        else
                        {
                            status1 = "Not Assigned";
                        }
                        if (ddlAssgndTo.SelectedItem.Value != "--SELECT EMPLOYEE--")
                        {
                            if (UserId1.Contains(ddlAssgndTo.SelectedItem.Value) == false)
                            {
                                strAsgnSts1 = "F";
                                PertclrCount = PertclrCount - 1;
                            }
                        }
                    }
                    if (dtCandData2.Rows.Count > 0 && strAsgnSts2 == "T")
                    {

                        if (dtCandData2.Rows[0]["ONBRD_FNSH_STS"].ToString() == "1")
                        {
                            status2 = "FINISHED";
                        }
                        else if (dtCandData2.Rows[0]["ONBRD_CLOSE_STS"].ToString() == "1")
                        {
                            status2 = "CLOSED";
                        }
                        else if (dtCandData2.Rows[0]["ONBRDDTL_FLIGHT_STATUS"].ToString() == "0")
                        {
                            status2 = "Job Assigned";
                        }
                        else if (dtCandData2.Rows[0]["ONBRDDTL_FLIGHT_STATUS"].ToString() == "1")
                        {
                            status2 = "Availability Check";
                        }
                        else if (dtCandData2.Rows[0]["ONBRDDTL_FLIGHT_STATUS"].ToString() == "2")
                        {
                            status2 = "Awaiting, Approval from candidate";
                        }
                        else if (dtCandData2.Rows[0]["ONBRDDTL_FLIGHT_STATUS"].ToString() == "3")
                        {
                            status2 = "Booking Confirm, ticket copy attach";
                        }

                        objEntityOnBoard.OnboardingDetailId = Convert.ToInt32(dtCandData2.Rows[0]["ONBRDDTL_ID"]);
                        DataTable dtEmpId = objBusinessOnboard.ReadEmpByBoardDtl(objEntityOnBoard);
                        if (dtEmpId.Rows.Count > 0)
                        {
                            foreach (DataRow dt2 in dtEmpId.Rows)
                            {
                                if (UsrName2 == "")
                                {
                                    UsrName2 = dt2["USR_NAME1"].ToString();
                                    UserId2 = dt2["USR_ID"].ToString();
                                }
                                else
                                {
                                    UsrName2 = UsrName2 + "," + dt2["USR_NAME1"];
                                    UserId2 = UserId2 + "," + dt2["USR_ID"];
                                }
                            }
                        }
                        else
                        {
                            status2 = "Not Assigned";
                        }
                        if (ddlAssgndTo.SelectedItem.Value != "--SELECT EMPLOYEE--")
                        {
                            if (UserId2.Contains(ddlAssgndTo.SelectedItem.Value) == false)
                            {
                                strAsgnSts2 = "F";
                                PertclrCount = PertclrCount - 1;
                            }
                        }
                    }
                    if (dtCandData3.Rows.Count > 0 && strAsgnSts3 == "T")
                    {
                        if (dtCandData3.Rows[0]["ONBRD_FNSH_STS"].ToString() == "1")
                        {
                            status3 = "FINISHED";
                        }
                        else if (dtCandData3.Rows[0]["ONBRD_CLOSE_STS"].ToString() == "1")
                        {
                            status3 = "CLOSED";
                        }
                        else if (dtCandData3.Rows[0]["ONBRDDTL_ROOM_STATUS"].ToString() == "0")
                        {
                            status3 = "Job Assigned";
                        }
                        else if (dtCandData3.Rows[0]["ONBRDDTL_ROOM_STATUS"].ToString() == "1")
                        {
                            status3 = "Availability Check";
                        }
                        else if (dtCandData3.Rows[0]["ONBRDDTL_ROOM_STATUS"].ToString() == "2")
                        {
                            status3 = "Facility Procurement";
                        }
                        else if (dtCandData3.Rows[0]["ONBRDDTL_ROOM_STATUS"].ToString() == "3")
                        {
                            status3 = "Complete";
                        }
                        else if (dtCandData3.Rows[0]["ONBRDDTL_ROOM_STATUS"].ToString() == "4")
                        {
                            status3 = "Closed Without Allotment";
                        }

                        objEntityOnBoard.OnboardingDetailId = Convert.ToInt32(dtCandData3.Rows[0]["ONBRDDTL_ID"]);
                        DataTable dtEmpId = objBusinessOnboard.ReadEmpByBoardDtl(objEntityOnBoard);
                        if (dtEmpId.Rows.Count > 0)
                        {
                            foreach (DataRow dt3 in dtEmpId.Rows)
                            {
                                if (UsrName3 == "")
                                {
                                    UsrName3 = dt3["USR_NAME1"].ToString();
                                    UserId3 = dt3["USR_ID"].ToString();
                                }
                                else
                                {
                                    UsrName3 = UsrName3 + "," + dt3["USR_NAME1"];
                                    UserId3 = UserId3 + "," + dt3["USR_ID"];
                                }
                            }
                        }
                        else
                        {
                            status3 = "Not Assigned";
                        }

                        if (ddlAssgndTo.SelectedItem.Value != "--SELECT EMPLOYEE--")
                        {
                            if (UserId3.Contains(ddlAssgndTo.SelectedItem.Value) == false)
                            {
                                strAsgnSts3 = "F";
                                PertclrCount = PertclrCount - 1;
                            }
                        }
                    }
                    if (dtCandData4.Rows.Count > 0 && strAsgnSts4 == "T")
                    {

                        if (dtCandData4.Rows[0]["ONBRD_FNSH_STS"].ToString() == "1")
                        {
                            status4 = "FINISHED";
                        }
                        else if (dtCandData4.Rows[0]["ONBRD_CLOSE_STS"].ToString() == "1")
                        {
                            status4 = "CLOSED";
                        }
                        else if (dtCandData4.Rows[0]["ONBRDDTL_AIRPT_STATUS"].ToString() == "0")
                        {
                            status4 = "Job Assigned";
                        }

                        objEntityOnBoard.OnboardingDetailId = Convert.ToInt32(dtCandData4.Rows[0]["ONBRDDTL_ID"]);
                        DataTable dtEmpId = objBusinessOnboard.ReadEmpByBoardDtl(objEntityOnBoard);
                        if (dtEmpId.Rows.Count > 0)
                        {
                            foreach (DataRow dt4 in dtEmpId.Rows)
                            {
                                if (UsrName4 == "")
                                {
                                    UsrName4 = dt4["USR_NAME1"].ToString();
                                    UserId4 = dt4["USR_ID"].ToString();
                                }
                                else
                                {
                                    UsrName4 = UsrName4 + "," + dt4["USR_NAME1"];
                                    UserId4 = UserId4 + "," + dt4["USR_ID"];
                                }
                            }
                        }
                        else
                        {
                            status4 = "Not Assigned";
                        }
                        if (ddlAssgndTo.SelectedItem.Value != "--SELECT EMPLOYEE--")
                        {
                            if (UserId4.Contains(ddlAssgndTo.SelectedItem.Value) == false)
                            {
                                strAsgnSts4 = "F";
                                PertclrCount = PertclrCount - 1;
                            }
                        }
                    }


                    if (strAsgnSts1 == "T")
                    {
                        strHtml += "<tr>";
                        if (i == 1)
                        {
                            if (intRowBodyCount == dtCandData.Rows.Count - 1)
                            {

                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtCandData.Rows[intRowBodyCount]["CANDIDATE NAME"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtCandData.Rows[intRowBodyCount]["PROJECT"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtCandData.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtCandData.Rows[intRowBodyCount]["CANDIDATE NAME"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtCandData.Rows[intRowBodyCount]["PROJECT"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtCandData.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";
                            }
                        }


                        if (i == PertclrCount && intRowBodyCount != dtCandData.Rows.Count - 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >VISA</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:19%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + status1.ToUpper() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + UsrName1 + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;\" >VISA</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:19%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + status1.ToUpper() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + UsrName1 + "</td>";
                        }

                        strHtml += "</tr>";
                        i++;
                        flag++;

                    }


                    if (strAsgnSts2 == "T")
                    {
                        strHtml += "<tr>";
                        if (i == 1)
                        {
                            if (intRowBodyCount == dtCandData.Rows.Count - 1)
                            {

                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtCandData.Rows[intRowBodyCount]["CANDIDATE NAME"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtCandData.Rows[intRowBodyCount]["PROJECT"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtCandData.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtCandData.Rows[intRowBodyCount]["CANDIDATE NAME"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtCandData.Rows[intRowBodyCount]["PROJECT"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtCandData.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";
                            }
                        }



                        if (i == PertclrCount && intRowBodyCount != dtCandData.Rows.Count - 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >FLIGHT TICKET</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:19%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + status2.ToUpper() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + UsrName2 + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;\" >FLIGHT TICKET</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:19%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + status2.ToUpper() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + UsrName2 + "</td>";
                        }

                        strHtml += "</tr>";
                        i++;
                        flag++;
                    }

                    if (strAsgnSts3 == "T")
                    {
                        strHtml += "<tr>";
                        if (i == 1)
                        {

                            if (intRowBodyCount == dtCandData.Rows.Count - 1)
                            {

                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtCandData.Rows[intRowBodyCount]["CANDIDATE NAME"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtCandData.Rows[intRowBodyCount]["PROJECT"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtCandData.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtCandData.Rows[intRowBodyCount]["CANDIDATE NAME"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtCandData.Rows[intRowBodyCount]["PROJECT"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtCandData.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";
                            }
                        }


                        if (i == PertclrCount && intRowBodyCount != dtCandData.Rows.Count - 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >ROOM ALLOTMENT</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:19%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + status3.ToUpper() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + UsrName3 + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;\" >ROOM ALLOTMENT</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:19%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + status3.ToUpper() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + UsrName3 + "</td>";
                        }


                        strHtml += "</tr>";
                        i++;
                        flag++;
                    }


                    if (strAsgnSts4 == "T")
                    {
                        strHtml += "<tr>";
                        if (i == 1)
                        {

                            if (intRowBodyCount == dtCandData.Rows.Count - 1)
                            {

                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtCandData.Rows[intRowBodyCount]["CANDIDATE NAME"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtCandData.Rows[intRowBodyCount]["PROJECT"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtCandData.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtCandData.Rows[intRowBodyCount]["CANDIDATE NAME"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtCandData.Rows[intRowBodyCount]["PROJECT"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtCandData.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";
                            }

                        }

                        if (i == PertclrCount && intRowBodyCount != dtCandData.Rows.Count - 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >AIRPORT PICKUP</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:19%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + status4.ToUpper() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + UsrName4 + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;\" >AIRPORT PICKUP</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:19%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + status4.ToUpper() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + UsrName4 + "</td>";
                        }


                        strHtml += "</tr>";
                        i++;
                        flag++;
                    }
                }
            }
        }
        if (flag == 0)
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"thT\"colspan=6 style=\"width:100%;text-align: center; word-wrap:break-word;\">No Data Available</td></tr>";
        }
        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }

    //It build the Html table by using the datatable provided
    public string ConvertDataTableForPrint(DataTable dtCandData, DataTable dtCorp,string load)
    {

        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "On Boarding Job Assignment Report";
        int flag = 0;
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
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strUsrName + strCaptionTabTitle + strCaptionTabstop;

        sbCap.Append(strPrintCaptionTable);
        //write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";
        strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">CANDIDATE NAME</th>";
        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">PROJECT</th>";
        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";
        strHtml += "<th class=\"thT\" style=\"width:11%;text-align: left; word-wrap:break-word;\">PARTICULARS</th>";
        strHtml += "<th class=\"thT\" style=\"width:19%;text-align: left; word-wrap:break-word;\">STATUS</th>";
        strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">ASSIGNED TO</th>";
        strHtml += "</tr>";

        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        if (load != "page load")
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dtCandData.Rows.Count; intRowBodyCount++)
            {

                string strCandSts = "T", strPrjctSts = "T";
                if (Hiddenselectedtext.Value != "")
                {
                    if (Hiddenselectedtext.Value.Contains(dtCandData.Rows[intRowBodyCount][0].ToString()) == false)
                    {
                        strCandSts = "F";
                    }
                }
                if (ddlProject.SelectedItem.Value != "--SELECT PROJECT--")
                {
                    if (ddlProject.SelectedItem.Value != dtCandData.Rows[intRowBodyCount]["PROJECT_ID"].ToString())
                    {
                        strPrjctSts = "F";
                    }
                }

                if (strCandSts == "T" && strPrjctSts == "T")
                {

                    clsBusiness_OnBoardingProcess objBusinessOnboard = new clsBusiness_OnBoardingProcess();
                    ClsEntityOnBoardingProcess objEntityOnBoard = new ClsEntityOnBoardingProcess();
                    objEntityOnBoard.CandId = Convert.ToInt32(dtCandData.Rows[intRowBodyCount][0].ToString());
                    DataTable dtCandData1 = objBusinessOnboard.ReadVisaDetailByCandId(objEntityOnBoard);
                    DataTable dtCandData2 = objBusinessOnboard.ReadFlightDetailByCandId(objEntityOnBoard);
                    DataTable dtCandData3 = objBusinessOnboard.ReadRoomDetailByCandId(objEntityOnBoard);
                    DataTable dtCandData4 = objBusinessOnboard.ReadAirDetailByCandId(objEntityOnBoard);
                    int PertclrCount = 4;
                    int i = 1;

                    string strAsgnSts1 = "T", strAsgnSts2 = "T", strAsgnSts3 = "T", strAsgnSts4 = "T";
                    string UsrName1 = "", UserId1 = "";
                    string UsrName2 = "", UserId2 = "";
                    string UsrName3 = "", UserId3 = "";
                    string UsrName4 = "", UserId4 = "";
                    string status1 = "", status2 = "", status3 = "", status4 = "";


                    if (ddlParticular.SelectedItem.Value != "0")
                    {
                        PertclrCount = 1;
                        if (ddlParticular.SelectedItem.Value == "1")
                        {
                            strAsgnSts2 = "F";
                            strAsgnSts3 = "F";
                            strAsgnSts4 = "F";
                        }
                        else if (ddlParticular.SelectedItem.Value == "2")
                        {
                            strAsgnSts1 = "F";
                            strAsgnSts3 = "F";
                            strAsgnSts4 = "F";
                        }
                        else if (ddlParticular.SelectedItem.Value == "3")
                        {
                            strAsgnSts1 = "F";
                            strAsgnSts2 = "F";
                            strAsgnSts4 = "F";
                        }
                        else if (ddlParticular.SelectedItem.Value == "4")
                        {
                            strAsgnSts1 = "F";
                            strAsgnSts2 = "F";
                            strAsgnSts3 = "F";
                        }
                    }


                    if (dtCandData1.Rows.Count > 0 && strAsgnSts1 == "T")
                    {

                        if (dtCandData1.Rows[0]["ONBRD_FNSH_STS"].ToString() == "1")
                        {
                            status1 = "FINISHED";
                        }
                        else if (dtCandData1.Rows[0]["ONBRD_CLOSE_STS"].ToString() == "1")
                        {
                            status1 = "CLOSED";
                        }
                        else if (dtCandData1.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "0")
                        {
                            status1 = "Job Assigned";
                        }
                        else if (dtCandData1.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "1")
                        {
                            status1 = "Document Preparation";
                        }
                        else if (dtCandData1.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "2")
                        {
                            status1 = "Applied, Awaiting MOI Approval";
                        }
                        else if (dtCandData1.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "3")
                        {
                            status1 = "MOI Approved, ready to print";
                        }
                        else if (dtCandData1.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "4")
                        {
                            status1 = "MOI rejected – Close";
                        }
                        else if (dtCandData1.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "5")
                        {
                            status1 = "MOI Rejected – Reapply";
                        }
                        else if (dtCandData1.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "6")
                        {
                            status1 = "Visa print complete";
                        }


                        objEntityOnBoard.OnboardingDetailId = Convert.ToInt32(dtCandData1.Rows[0]["ONBRDDTL_ID"]);
                        DataTable dtEmpId = objBusinessOnboard.ReadEmpByBoardDtl(objEntityOnBoard);
                        if (dtEmpId.Rows.Count > 0)
                        {
                            foreach (DataRow dt1 in dtEmpId.Rows)
                            {
                                if (UsrName1 == "")
                                {
                                    UsrName1 = dt1["USR_NAME1"].ToString();
                                    UserId1 = dt1["USR_ID"].ToString();
                                }
                                else
                                {
                                    UsrName1 = UsrName1 + "," + dt1["USR_NAME1"];
                                    UserId1 = UserId1 + "," + dt1["USR_ID"];
                                }
                            }
                        }
                        else
                        {
                            status1 = "Not Assigned";
                        }
                        if (ddlAssgndTo.SelectedItem.Value != "--SELECT EMPLOYEE--")
                        {
                            if (UserId1.Contains(ddlAssgndTo.SelectedItem.Value) == false)
                            {
                                strAsgnSts1 = "F";
                                PertclrCount = PertclrCount - 1;
                            }
                        }
                    }
                    if (dtCandData2.Rows.Count > 0 && strAsgnSts2 == "T")
                    {

                        if (dtCandData2.Rows[0]["ONBRD_FNSH_STS"].ToString() == "1")
                        {
                            status2 = "FINISHED";
                        }
                        else if (dtCandData2.Rows[0]["ONBRD_CLOSE_STS"].ToString() == "1")
                        {
                            status2 = "CLOSED";
                        }
                        else if (dtCandData2.Rows[0]["ONBRDDTL_FLIGHT_STATUS"].ToString() == "0")
                        {
                            status2 = "Job Assigned";
                        }
                        else if (dtCandData2.Rows[0]["ONBRDDTL_FLIGHT_STATUS"].ToString() == "1")
                        {
                            status2 = "Availability Check";
                        }
                        else if (dtCandData2.Rows[0]["ONBRDDTL_FLIGHT_STATUS"].ToString() == "2")
                        {
                            status2 = "Awaiting, Approval from candidate";
                        }
                        else if (dtCandData2.Rows[0]["ONBRDDTL_FLIGHT_STATUS"].ToString() == "3")
                        {
                            status2 = "Booking Confirm, ticket copy attach";
                        }

                        objEntityOnBoard.OnboardingDetailId = Convert.ToInt32(dtCandData2.Rows[0]["ONBRDDTL_ID"]);
                        DataTable dtEmpId = objBusinessOnboard.ReadEmpByBoardDtl(objEntityOnBoard);
                        if (dtEmpId.Rows.Count > 0)
                        {
                            foreach (DataRow dt2 in dtEmpId.Rows)
                            {
                                if (UsrName2 == "")
                                {
                                    UsrName2 = dt2["USR_NAME1"].ToString();
                                    UserId2 = dt2["USR_ID"].ToString();
                                }
                                else
                                {
                                    UsrName2 = UsrName2 + "," + dt2["USR_NAME1"];
                                    UserId2 = UserId2 + "," + dt2["USR_ID"];
                                }
                            }
                        }
                        else
                        {
                            status2 = "Not Assigned";
                        }
                        if (ddlAssgndTo.SelectedItem.Value != "--SELECT EMPLOYEE--")
                        {
                            if (UserId2.Contains(ddlAssgndTo.SelectedItem.Value) == false)
                            {
                                strAsgnSts2 = "F";
                                PertclrCount = PertclrCount - 1;
                            }
                        }
                    }
                    if (dtCandData3.Rows.Count > 0 && strAsgnSts3 == "T")
                    {
                        if (dtCandData3.Rows[0]["ONBRD_FNSH_STS"].ToString() == "1")
                        {
                            status3 = "FINISHED";
                        }
                        else if (dtCandData3.Rows[0]["ONBRD_CLOSE_STS"].ToString() == "1")
                        {
                            status3 = "CLOSED";
                        }
                        else if (dtCandData3.Rows[0]["ONBRDDTL_ROOM_STATUS"].ToString() == "0")
                        {
                            status3 = "Job Assigned";
                        }
                        else if (dtCandData3.Rows[0]["ONBRDDTL_ROOM_STATUS"].ToString() == "1")
                        {
                            status3 = "Availability Check";
                        }
                        else if (dtCandData3.Rows[0]["ONBRDDTL_ROOM_STATUS"].ToString() == "2")
                        {
                            status3 = "Facility Procurement";
                        }
                        else if (dtCandData3.Rows[0]["ONBRDDTL_ROOM_STATUS"].ToString() == "3")
                        {
                            status3 = "Complete";
                        }
                        else if (dtCandData3.Rows[0]["ONBRDDTL_ROOM_STATUS"].ToString() == "4")
                        {
                            status3 = "Closed Without Allotment";
                        }

                        objEntityOnBoard.OnboardingDetailId = Convert.ToInt32(dtCandData3.Rows[0]["ONBRDDTL_ID"]);
                        DataTable dtEmpId = objBusinessOnboard.ReadEmpByBoardDtl(objEntityOnBoard);
                        if (dtEmpId.Rows.Count > 0)
                        {
                            foreach (DataRow dt3 in dtEmpId.Rows)
                            {
                                if (UsrName3 == "")
                                {
                                    UsrName3 = dt3["USR_NAME1"].ToString();
                                    UserId3 = dt3["USR_ID"].ToString();
                                }
                                else
                                {
                                    UsrName3 = UsrName3 + "," + dt3["USR_NAME1"];
                                    UserId3 = UserId3 + "," + dt3["USR_ID"];
                                }
                            }
                        }
                        else
                        {
                            status3 = "Not Assigned";
                        }

                        if (ddlAssgndTo.SelectedItem.Value != "--SELECT EMPLOYEE--")
                        {
                            if (UserId3.Contains(ddlAssgndTo.SelectedItem.Value) == false)
                            {
                                strAsgnSts3 = "F";
                                PertclrCount = PertclrCount - 1;
                            }
                        }
                    }
                    if (dtCandData4.Rows.Count > 0 && strAsgnSts4 == "T")
                    {

                        if (dtCandData4.Rows[0]["ONBRD_FNSH_STS"].ToString() == "1")
                        {
                            status4 = "FINISHED";
                        }
                        else if (dtCandData4.Rows[0]["ONBRD_CLOSE_STS"].ToString() == "1")
                        {
                            status4 = "CLOSED";
                        }
                        else if (dtCandData4.Rows[0]["ONBRDDTL_AIRPT_STATUS"].ToString() == "0")
                        {
                            status4 = "Job Assigned";
                        }

                        objEntityOnBoard.OnboardingDetailId = Convert.ToInt32(dtCandData4.Rows[0]["ONBRDDTL_ID"]);
                        DataTable dtEmpId = objBusinessOnboard.ReadEmpByBoardDtl(objEntityOnBoard);
                        if (dtEmpId.Rows.Count > 0)
                        {
                            foreach (DataRow dt4 in dtEmpId.Rows)
                            {
                                if (UsrName4 == "")
                                {
                                    UsrName4 = dt4["USR_NAME1"].ToString();
                                    UserId4 = dt4["USR_ID"].ToString();
                                }
                                else
                                {
                                    UsrName4 = UsrName4 + "," + dt4["USR_NAME1"];
                                    UserId4 = UserId4 + "," + dt4["USR_ID"];
                                }
                            }
                        }
                        else
                        {
                            status4 = "Not Assigned";
                        }
                        if (ddlAssgndTo.SelectedItem.Value != "--SELECT EMPLOYEE--")
                        {
                            if (UserId4.Contains(ddlAssgndTo.SelectedItem.Value) == false)
                            {
                                strAsgnSts4 = "F";
                                PertclrCount = PertclrCount - 1;
                            }
                        }
                    }


                    if (strAsgnSts1 == "T")
                    {
                        strHtml += "<tr>";
                        if (i == 1)
                        {
                            if (intRowBodyCount == dtCandData.Rows.Count - 1)
                            {

                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtCandData.Rows[intRowBodyCount]["CANDIDATE NAME"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtCandData.Rows[intRowBodyCount]["PROJECT"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtCandData.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtCandData.Rows[intRowBodyCount]["CANDIDATE NAME"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtCandData.Rows[intRowBodyCount]["PROJECT"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtCandData.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";
                            }
                        }


                        if (i == PertclrCount && intRowBodyCount != dtCandData.Rows.Count - 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >VISA</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:19%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + status1.ToUpper() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + UsrName1 + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;\" >VISA</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:19%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + status1.ToUpper() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + UsrName1 + "</td>";
                        }

                        strHtml += "</tr>";
                        i++;
                        flag++;

                    }


                    if (strAsgnSts2 == "T")
                    {
                        strHtml += "<tr>";
                        if (i == 1)
                        {
                            if (intRowBodyCount == dtCandData.Rows.Count - 1)
                            {

                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtCandData.Rows[intRowBodyCount]["CANDIDATE NAME"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtCandData.Rows[intRowBodyCount]["PROJECT"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtCandData.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtCandData.Rows[intRowBodyCount]["CANDIDATE NAME"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtCandData.Rows[intRowBodyCount]["PROJECT"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtCandData.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";
                            }
                        }



                        if (i == PertclrCount && intRowBodyCount != dtCandData.Rows.Count - 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >FLIGHT TICKET</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:19%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + status2.ToUpper() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + UsrName2 + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;\" >FLIGHT TICKET</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:19%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + status2.ToUpper() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + UsrName2 + "</td>";
                        }

                        strHtml += "</tr>";
                        i++;
                        flag++;
                    }

                    if (strAsgnSts3 == "T")
                    {
                        strHtml += "<tr>";
                        if (i == 1)
                        {

                            if (intRowBodyCount == dtCandData.Rows.Count - 1)
                            {

                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtCandData.Rows[intRowBodyCount]["CANDIDATE NAME"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtCandData.Rows[intRowBodyCount]["PROJECT"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtCandData.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtCandData.Rows[intRowBodyCount]["CANDIDATE NAME"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtCandData.Rows[intRowBodyCount]["PROJECT"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtCandData.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";
                            }
                        }


                        if (i == PertclrCount && intRowBodyCount != dtCandData.Rows.Count - 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >ROOM ALLOTMENT</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:19%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + status3.ToUpper() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + UsrName3 + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;\" >ROOM ALLOTMENT</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:19%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + status3.ToUpper() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + UsrName3 + "</td>";
                        }


                        strHtml += "</tr>";
                        i++;
                        flag++;
                    }


                    if (strAsgnSts4 == "T")
                    {
                        strHtml += "<tr>";
                        if (i == 1)
                        {

                            if (intRowBodyCount == dtCandData.Rows.Count - 1)
                            {

                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtCandData.Rows[intRowBodyCount]["CANDIDATE NAME"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtCandData.Rows[intRowBodyCount]["PROJECT"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtCandData.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtCandData.Rows[intRowBodyCount]["CANDIDATE NAME"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtCandData.Rows[intRowBodyCount]["PROJECT"].ToString() + "</td>";
                                strHtml += "<td class=\"tdT\" rowspan=\"" + PertclrCount + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + dtCandData.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";
                            }

                        }

                        if (i == PertclrCount && intRowBodyCount != dtCandData.Rows.Count - 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >AIRPORT PICKUP</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:19%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + status4.ToUpper() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-bottom: 1px solid #c9c9c9;\" >" + UsrName4 + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;\" >AIRPORT PICKUP</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:19%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + status4.ToUpper() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + UsrName4 + "</td>";
                        }


                        strHtml += "</tr>";
                        i++;
                        flag++;
                    }
                }
            }
        }
        if (flag == 0)
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"thT\"colspan=6 style=\"width:100%;text-align: center; word-wrap:break-word;\">No Data Available</td></tr>";
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
        clsBusiness_OnBoardingProcess objBusinessOnboard = new clsBusiness_OnBoardingProcess();
        ClsEntityOnBoardingProcess objEntityOnBoard = new ClsEntityOnBoardingProcess();
        objEntityOnBoard.StatusId = 1;
        DataTable dtCandData = objBusinessOnboard.ReadCandidates(objEntityOnBoard);

        DataView dv = dtCandData.DefaultView;
        dv.Sort = "CANDIDATE NAME";
        dtCandData = dv.ToTable();
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
        DataTable table = new DataTable();
        table.Columns.Add("CANDIDATE NAME", typeof(string));
        table.Columns.Add("PROJECT", typeof(string));
        table.Columns.Add("DEPARTMENT", typeof(string));
        table.Columns.Add("PARTICULARS", typeof(string));
        table.Columns.Add("STATUS", typeof(string));
        table.Columns.Add("ASSIGNED TO", typeof(string));
        int flag = 0;

        for (int intRowBodyCount = 0; intRowBodyCount < dtCandData.Rows.Count; intRowBodyCount++)
        {
            string EMP = "";
            string PRJCT = "";
            string DEPT = "";
            string PARTICULAR = "";
            string STATUS = "";
            string ASSIGN = "";
            string strCandSts = "T", strPrjctSts = "T";
            if (Hiddenselectedtext.Value != "")
            {
                if (Hiddenselectedtext.Value.Contains(dtCandData.Rows[intRowBodyCount][0].ToString()) == false)
                {
                    strCandSts = "F";
                }
            }
            if (ddlProject.SelectedItem.Value != "--SELECT PROJECT--")
            {
                if (ddlProject.SelectedItem.Value != dtCandData.Rows[intRowBodyCount]["PROJECT_ID"].ToString())
                {
                    strPrjctSts = "F";
                }
            }

            if (strCandSts == "T" && strPrjctSts == "T")
            {


                objEntityOnBoard.CandId = Convert.ToInt32(dtCandData.Rows[intRowBodyCount][0].ToString());
                DataTable dtCandData1 = objBusinessOnboard.ReadVisaDetailByCandId(objEntityOnBoard);
                DataTable dtCandData2 = objBusinessOnboard.ReadFlightDetailByCandId(objEntityOnBoard);
                DataTable dtCandData3 = objBusinessOnboard.ReadRoomDetailByCandId(objEntityOnBoard);
                DataTable dtCandData4 = objBusinessOnboard.ReadAirDetailByCandId(objEntityOnBoard);
                int PertclrCount = 4;
                int i = 1;
                string strAsgnSts1 = "T", strAsgnSts2 = "T", strAsgnSts3 = "T", strAsgnSts4 = "T";
                string UsrName1 = "", UserId1 = "";
                string UsrName2 = "", UserId2 = "";
                string UsrName3 = "", UserId3 = "";
                string UsrName4 = "", UserId4 = "";
                string status1 = "", status2 = "", status3 = "", status4 = "";
                if (ddlParticular.SelectedItem.Value != "0")
                {
                    PertclrCount = 1;
                    if (ddlParticular.SelectedItem.Value == "1")
                    {
                        strAsgnSts2 = "F";
                        strAsgnSts3 = "F";
                        strAsgnSts4 = "F";
                    }
                    else if (ddlParticular.SelectedItem.Value == "2")
                    {
                        strAsgnSts1 = "F";
                        strAsgnSts3 = "F";
                        strAsgnSts4 = "F";
                    }
                    else if (ddlParticular.SelectedItem.Value == "3")
                    {
                        strAsgnSts1 = "F";
                        strAsgnSts2 = "F";
                        strAsgnSts4 = "F";
                    }
                    else if (ddlParticular.SelectedItem.Value == "4")
                    {
                        strAsgnSts1 = "F";
                        strAsgnSts2 = "F";
                        strAsgnSts3 = "F";
                    }
                }
                if (dtCandData1.Rows.Count > 0 && strAsgnSts1 == "T")
                {
                    if (dtCandData1.Rows[0]["ONBRD_FNSH_STS"].ToString() == "1")
                    {
                        status1 = "FINISHED";
                    }
                    else if (dtCandData1.Rows[0]["ONBRD_CLOSE_STS"].ToString() == "1")
                    {
                        status1 = "CLOSED";
                    }
                    else if (dtCandData1.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "0")
                    {
                        status1 = "Job Assigned";
                    }
                    else if (dtCandData1.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "1")
                    {
                        status1 = "Document Preparation";
                    }
                    else if (dtCandData1.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "2")
                    {
                        status1 = "Applied, Awaiting MOI Approval";
                    }
                    else if (dtCandData1.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "3")
                    {
                        status1 = "MOI Approved, ready to print";
                    }
                    else if (dtCandData1.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "4")
                    {
                        status1 = "MOI rejected – Close";
                    }
                    else if (dtCandData1.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "5")
                    {
                        status1 = "MOI Rejected – Reapply";
                    }
                    else if (dtCandData1.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "6")
                    {
                        status1 = "Visa print complete";
                    }
                    objEntityOnBoard.OnboardingDetailId = Convert.ToInt32(dtCandData1.Rows[0]["ONBRDDTL_ID"]);
                    DataTable dtEmpId = objBusinessOnboard.ReadEmpByBoardDtl(objEntityOnBoard);
                    if (dtEmpId.Rows.Count > 0)
                    {
                        foreach (DataRow dt1 in dtEmpId.Rows)
                        {
                            if (UsrName1 == "")
                            {
                                UsrName1 = dt1["USR_NAME1"].ToString();
                                UserId1 = dt1["USR_ID"].ToString();
                            }
                            else
                            {
                                UsrName1 = UsrName1 + "," + dt1["USR_NAME1"];
                                UserId1 = UserId1 + "," + dt1["USR_ID"];
                            }
                        }
                    }
                    else
                    {
                        status1 = "Not Assigned";
                    }
                    if (ddlAssgndTo.SelectedItem.Value != "--SELECT EMPLOYEE--")
                    {
                        if (UserId1.Contains(ddlAssgndTo.SelectedItem.Value) == false)
                        {
                            strAsgnSts1 = "F";
                            PertclrCount = PertclrCount - 1;
                        }
                    }
                }
                if (dtCandData2.Rows.Count > 0 && strAsgnSts2 == "T")
                {

                    if (dtCandData2.Rows[0]["ONBRD_FNSH_STS"].ToString() == "1")
                    {
                        status2 = "FINISHED";
                    }
                    else if (dtCandData2.Rows[0]["ONBRD_CLOSE_STS"].ToString() == "1")
                    {
                        status2 = "CLOSED";
                    }
                    else if (dtCandData2.Rows[0]["ONBRDDTL_FLIGHT_STATUS"].ToString() == "0")
                    {
                        status2 = "Job Assigned";
                    }
                    else if (dtCandData2.Rows[0]["ONBRDDTL_FLIGHT_STATUS"].ToString() == "1")
                    {
                        status2 = "Availability Check";
                    }
                    else if (dtCandData2.Rows[0]["ONBRDDTL_FLIGHT_STATUS"].ToString() == "2")
                    {
                        status2 = "Awaiting, Approval from candidate";
                    }
                    else if (dtCandData2.Rows[0]["ONBRDDTL_FLIGHT_STATUS"].ToString() == "3")
                    {
                        status2 = "Booking Confirm, ticket copy attach";
                    }

                    objEntityOnBoard.OnboardingDetailId = Convert.ToInt32(dtCandData2.Rows[0]["ONBRDDTL_ID"]);
                    DataTable dtEmpId = objBusinessOnboard.ReadEmpByBoardDtl(objEntityOnBoard);
                    if (dtEmpId.Rows.Count > 0)
                    {
                        foreach (DataRow dt2 in dtEmpId.Rows)
                        {
                            if (UsrName2 == "")
                            {
                                UsrName2 = dt2["USR_NAME1"].ToString();
                                UserId2 = dt2["USR_ID"].ToString();
                            }
                            else
                            {
                                UsrName2 = UsrName2 + "," + dt2["USR_NAME1"];
                                UserId2 = UserId2 + "," + dt2["USR_ID"];
                            }
                        }
                    }
                    else
                    {
                        status2 = "Not Assigned";
                    }
                    if (ddlAssgndTo.SelectedItem.Value != "--SELECT EMPLOYEE--")
                    {
                        if (UserId2.Contains(ddlAssgndTo.SelectedItem.Value) == false)
                        {
                            strAsgnSts2 = "F";
                            PertclrCount = PertclrCount - 1;
                        }
                    }
                }
                if (dtCandData3.Rows.Count > 0 && strAsgnSts3 == "T")
                {
                    if (dtCandData3.Rows[0]["ONBRD_FNSH_STS"].ToString() == "1")
                    {
                        status3 = "FINISHED";
                    }
                    else if (dtCandData3.Rows[0]["ONBRD_CLOSE_STS"].ToString() == "1")
                    {
                        status3 = "CLOSED";
                    }
                    else if (dtCandData3.Rows[0]["ONBRDDTL_ROOM_STATUS"].ToString() == "0")
                    {
                        status3 = "Job Assigned";
                    }
                    else if (dtCandData3.Rows[0]["ONBRDDTL_ROOM_STATUS"].ToString() == "1")
                    {
                        status3 = "Availability Check";
                    }
                    else if (dtCandData3.Rows[0]["ONBRDDTL_ROOM_STATUS"].ToString() == "2")
                    {
                        status3 = "Facility Procurement";
                    }
                    else if (dtCandData3.Rows[0]["ONBRDDTL_ROOM_STATUS"].ToString() == "3")
                    {
                        status3 = "Complete";
                    }
                    else if (dtCandData3.Rows[0]["ONBRDDTL_ROOM_STATUS"].ToString() == "4")
                    {
                        status3 = "Closed Without Allotment";
                    }
                    objEntityOnBoard.OnboardingDetailId = Convert.ToInt32(dtCandData3.Rows[0]["ONBRDDTL_ID"]);
                    DataTable dtEmpId = objBusinessOnboard.ReadEmpByBoardDtl(objEntityOnBoard);
                    if (dtEmpId.Rows.Count > 0)
                    {
                        foreach (DataRow dt3 in dtEmpId.Rows)
                        {
                            if (UsrName3 == "")
                            {
                                UsrName3 = dt3["USR_NAME1"].ToString();
                                UserId3 = dt3["USR_ID"].ToString();
                            }
                            else
                            {
                                UsrName3 = UsrName3 + "," + dt3["USR_NAME1"];
                                UserId3 = UserId3 + "," + dt3["USR_ID"];
                            }
                        }
                    }
                    else
                    {
                        status3 = "Not Assigned";
                    }
                    if (ddlAssgndTo.SelectedItem.Value != "--SELECT EMPLOYEE--")
                    {
                        if (UserId3.Contains(ddlAssgndTo.SelectedItem.Value) == false)
                        {
                            strAsgnSts3 = "F";
                            PertclrCount = PertclrCount - 1;
                        }
                    }
                }
                if (dtCandData4.Rows.Count > 0 && strAsgnSts4 == "T")
                {

                    if (dtCandData4.Rows[0]["ONBRD_FNSH_STS"].ToString() == "1")
                    {
                        status4 = "FINISHED";
                    }
                    else if (dtCandData4.Rows[0]["ONBRD_CLOSE_STS"].ToString() == "1")
                    {
                        status4 = "CLOSED";
                    }
                    else if (dtCandData4.Rows[0]["ONBRDDTL_AIRPT_STATUS"].ToString() == "0")
                    {
                        status4 = "Job Assigned";
                    }
                    objEntityOnBoard.OnboardingDetailId = Convert.ToInt32(dtCandData4.Rows[0]["ONBRDDTL_ID"]);
                    DataTable dtEmpId = objBusinessOnboard.ReadEmpByBoardDtl(objEntityOnBoard);
                    if (dtEmpId.Rows.Count > 0)
                    {
                        foreach (DataRow dt4 in dtEmpId.Rows)
                        {
                            if (UsrName4 == "")
                            {
                                UsrName4 = dt4["USR_NAME1"].ToString();
                                UserId4 = dt4["USR_ID"].ToString();
                            }
                            else
                            {
                                UsrName4 = UsrName4 + "," + dt4["USR_NAME1"];
                                UserId4 = UserId4 + "," + dt4["USR_ID"];
                            }
                        }
                    }
                    else
                    {
                        status4 = "Not Assigned";
                    }
                    if (ddlAssgndTo.SelectedItem.Value != "--SELECT EMPLOYEE--")
                    {
                        if (UserId4.Contains(ddlAssgndTo.SelectedItem.Value) == false)
                        {
                            strAsgnSts4 = "F";
                            PertclrCount = PertclrCount - 1;
                        }
                    }
                }

                int flagSpan = 0;
                if (strAsgnSts1 == "T")
                {
                   
                    if (i == 1)
                    {
                        if (intRowBodyCount == dtCandData.Rows.Count - 1)
                        {

                            EMP = dtCandData.Rows[intRowBodyCount]["CANDIDATE NAME"].ToString();
                            PRJCT = dtCandData.Rows[intRowBodyCount]["PROJECT"].ToString();
                            DEPT = dtCandData.Rows[intRowBodyCount]["DEPARTMENT"].ToString();
                        }
                        else
                        {
                            EMP = dtCandData.Rows[intRowBodyCount]["CANDIDATE NAME"].ToString();
                            PRJCT = dtCandData.Rows[intRowBodyCount]["PROJECT"].ToString();
                            DEPT = dtCandData.Rows[intRowBodyCount]["DEPARTMENT"].ToString();
                        }
                    }


                    if (i == PertclrCount && intRowBodyCount != dtCandData.Rows.Count - 1)
                    {
                        PARTICULAR = "VISA";
                        STATUS = status1.ToUpper();
                        ASSIGN = UsrName1;
                    }
                    else
                    {
                        PARTICULAR = "VISA";
                        STATUS = status1.ToUpper();
                        ASSIGN = UsrName1;
                    }

                    i++;
                    flag++;
                    if (flagSpan == 0)
                    {
                        table.Rows.Add('"' + EMP + '"', '"' + PRJCT + '"', '"' + DEPT + '"', '"' + PARTICULAR + '"', '"' + STATUS + '"', '"' + ASSIGN + '"');
                        flagSpan = 1;
                    }
                    else
                    {
                        table.Rows.Add('"' + "" + '"', '"' + "" + '"', '"' + "" + '"', '"' + PARTICULAR + '"', '"' + STATUS + '"', '"' + ASSIGN + '"');
                    }
                }


                if (strAsgnSts2 == "T")
                {
                    if (i == 1)
                    {
                        if (intRowBodyCount == dtCandData.Rows.Count - 1)
                        {

                            EMP = dtCandData.Rows[intRowBodyCount]["CANDIDATE NAME"].ToString();
                            PRJCT = dtCandData.Rows[intRowBodyCount]["PROJECT"].ToString();
                            DEPT = dtCandData.Rows[intRowBodyCount]["DEPARTMENT"].ToString();
                        }
                        else
                        {
                            EMP = dtCandData.Rows[intRowBodyCount]["CANDIDATE NAME"].ToString();
                            PRJCT = dtCandData.Rows[intRowBodyCount]["PROJECT"].ToString();
                            DEPT = dtCandData.Rows[intRowBodyCount]["DEPARTMENT"].ToString();
                        }
                    }



                    if (i == PertclrCount && intRowBodyCount != dtCandData.Rows.Count - 1)
                    {
                        PARTICULAR = "FLIGHT TICKET";
                        STATUS = status2.ToUpper();
                        ASSIGN = UsrName2;
                    }
                    else
                    {
                        PARTICULAR = "FLIGHT TICKET";
                        STATUS = status2.ToUpper();
                        ASSIGN = UsrName2;
                    }

                    //   strHtml += "</tr>";
                    i++;
                    flag++;
                    if (flagSpan == 0)
                    {
                        table.Rows.Add('"' + EMP + '"', '"' + PRJCT + '"', '"' + DEPT + '"', '"' + PARTICULAR + '"', '"' + STATUS + '"', '"' + ASSIGN + '"');
                        flagSpan = 1;
                    }
                    else
                    {
                        table.Rows.Add('"' + "" + '"', '"' + "" + '"', '"' + "" + '"', '"' + PARTICULAR + '"', '"' + STATUS + '"', '"' + ASSIGN + '"');
                    }
                }

                if (strAsgnSts3 == "T")
                {
                    // strHtml += "<tr>";
                    if (i == 1)
                    {

                        if (intRowBodyCount == dtCandData.Rows.Count - 1)
                        {

                            EMP = dtCandData.Rows[intRowBodyCount]["CANDIDATE NAME"].ToString();
                            PRJCT = dtCandData.Rows[intRowBodyCount]["PROJECT"].ToString();
                            DEPT = dtCandData.Rows[intRowBodyCount]["DEPARTMENT"].ToString();
                        }
                        else
                        {
                            EMP = dtCandData.Rows[intRowBodyCount]["CANDIDATE NAME"].ToString();
                            PRJCT = dtCandData.Rows[intRowBodyCount]["PROJECT"].ToString();
                            DEPT = dtCandData.Rows[intRowBodyCount]["DEPARTMENT"].ToString();
                        }
                    }


                    if (i == PertclrCount && intRowBodyCount != dtCandData.Rows.Count - 1)
                    {
                        PARTICULAR = "ROOM ALLOTMENT";
                        STATUS = status3.ToUpper();
                        ASSIGN = UsrName3;
                    }
                    else
                    {
                        PARTICULAR = "ROOM ALLOTMENT";
                        STATUS = status3.ToUpper();
                        ASSIGN = UsrName3;
                    }


                    //   strHtml += "</tr>";
                    i++;
                    flag++;
                    if (flagSpan == 0)
                    {
                        table.Rows.Add('"' + EMP + '"', '"' + PRJCT + '"', '"' + DEPT + '"', '"' + PARTICULAR + '"', '"' + STATUS + '"', '"' + ASSIGN + '"');
                        flagSpan = 1;
                    }
                    else
                    {
                        table.Rows.Add('"' + "" + '"', '"' + "" + '"', '"' + "" + '"', '"' + PARTICULAR + '"', '"' + STATUS + '"', '"' + ASSIGN + '"');
                    }
                }


                if (strAsgnSts4 == "T")
                {
                    // strHtml += "<tr>";
                    if (i == 1)
                    {

                        if (intRowBodyCount == dtCandData.Rows.Count - 1)
                        {
                            EMP = dtCandData.Rows[intRowBodyCount]["CANDIDATE NAME"].ToString();
                            PRJCT = dtCandData.Rows[intRowBodyCount]["PROJECT"].ToString();
                            DEPT = dtCandData.Rows[intRowBodyCount]["DEPARTMENT"].ToString();
                        }
                        else
                        {
                            EMP = dtCandData.Rows[intRowBodyCount]["CANDIDATE NAME"].ToString();
                            PRJCT = dtCandData.Rows[intRowBodyCount]["PROJECT"].ToString();
                            DEPT = dtCandData.Rows[intRowBodyCount]["DEPARTMENT"].ToString();
                        }

                    }

                    if (i == PertclrCount && intRowBodyCount != dtCandData.Rows.Count - 1)
                    {
                        PARTICULAR = "AIRPORT PICKUP";
                        STATUS = status4.ToUpper();
                        ASSIGN = UsrName4;
                    }
                    else
                    {
                        PARTICULAR = "AIRPORT PICKUP";
                        STATUS = status4.ToUpper();
                        ASSIGN = UsrName4;
                    }


                    //  strHtml += "</tr>";
                    i++;
                    flag++;
                    if (flagSpan == 0)
                    {
                        table.Rows.Add('"' + EMP + '"', '"' + PRJCT + '"', '"' + DEPT + '"', '"' + PARTICULAR + '"', '"' + STATUS + '"', '"' + ASSIGN + '"');
                        flagSpan = 1;
                    }
                    else
                    {
                        table.Rows.Add('"' + "" + '"', '"' + "" + '"', '"' + "" + '"', '"' + PARTICULAR + '"', '"' + STATUS + '"', '"' + ASSIGN + '"');
                    }
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
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.ONBOARDING_JOB_ASGNMNT_RPRT_CSV);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
            string newFilePath = Server.MapPath("/CustomFiles/HCM CSV/On Boarding Job Assignment/On_Boarding_Job_Assignment_Report_" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "On_Boarding_Job_Assignment_Report_" + strNextId + ".csv";
            Response.ContentType = "csv";
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.ONBOARDING_JOB_ASGNMNT_RPRT_CSV);
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