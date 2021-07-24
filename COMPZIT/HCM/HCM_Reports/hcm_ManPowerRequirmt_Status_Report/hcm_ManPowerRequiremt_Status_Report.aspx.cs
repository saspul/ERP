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
// CREATED BY:EVM-0020
// CREATED DATE:19/07/2017
// REVIEWED BY:
// REVIEW DATE:
public partial class HCM_HCM_Reports_hcm_ManPowerRequirmt_Status_Report_hcm_ManPowerRequiremt_Status_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //txtFromDate.Text = "";
        //txtTodate.Text = "";
        SetFocus(ddlDepartmnt);
        clsEntityManpwrReqmt_Status_Report objEntityManpwrReqmt = new clsEntityManpwrReqmt_Status_Report();
        clsBusinessLayerManpwr_Reqmt_Status_Report objBusinessManpwrReqmt = new clsBusinessLayerManpwr_Reqmt_Status_Report();
        if (!IsPostBack)
        {


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

            //Evm-27

            //DataTable dtDivision = new DataTable();
            //dtDivision = objBusinessManpwrReqmt.ReadDivision(objEntityManpwrReqmt);

            //ddlDivision.Items.Clear();
            //ddlDivision.DataSource = dtDivision;
            //ddlDivision.DataTextField = "CPRDIV_NAME";
            //ddlDivision.DataValueField = "CPRDIV_ID";
            //ddlDivision.DataBind();

            ddlDivision.Items.Insert(0, "--SELECT DIVISION--");


            //txtFromDate.Text = null;
            //txtTodate.Text = null;



            DataTable dtDesignation = new DataTable();
            dtDesignation = objBusinessManpwrReqmt.ReadDesignation(objEntityManpwrReqmt);

            ddlDesignation.Items.Clear();
            ddlDesignation.DataSource = dtDesignation;

            ddlDesignation.DataTextField = "DSGN_NAME";
            ddlDesignation.DataValueField = "DSGN_ID";
            ddlDesignation.DataBind();

            ddlDesignation.Items.Insert(0, "--SELECT DESIGNATION--");



            DataTable dtProject = new DataTable();
            dtProject = objBusinessManpwrReqmt.ReadProjects(objEntityManpwrReqmt);

            ddlProject.Items.Clear();
            ddlProject.DataSource = dtProject;

            ddlProject.DataTextField = "PROJECT_NAME";
            ddlProject.DataValueField = "PROJECT_ID";
            ddlProject.DataBind();

            ddlProject.Items.Insert(0, "--SELECT PROJECT--");
            //End

            DataTable dtDepts = new DataTable();
            dtDepts = objBusinessManpwrReqmt.ReadDepts(objEntityManpwrReqmt);

            ddlDepartmnt.Items.Clear();
            ddlDepartmnt.DataSource = dtDepts;
            ddlDepartmnt.DataTextField = "CPRDEPT_NAME";
            ddlDepartmnt.DataValueField = "CPRDEPT_ID";
            ddlDepartmnt.DataBind();

            ddlDepartmnt.Items.Insert(0, "--SELECT DEPARTMENT--");
            DdlStatus.Items.Clear();
            DdlStatus.Items.Insert(0, "--SELECT STATUS--");
            DdlStatus.Items.Insert(1, "GM APPROVED");
            DdlStatus.Items.Insert(2, "REQUIREMENT ALLOCATED");
            DdlStatus.Items.Insert(3, "JOB NOTIFIED");
            DdlStatus.Items.Insert(4, "CLOSED");
            DdlStatus.Items.Insert(5, "INTERVIEW DONE");
            DdlStatus.Items.Insert(6, "REJECTED");
            DataTable dtCorp = objBusinessManpwrReqmt.ReadCorporateAddress(objEntityManpwrReqmt);
            DataTable dtManpwr = new DataTable();
            objEntityManpwrReqmt.CorpId = 0;
            objEntityManpwrReqmt.OrgId = 0;
            dtManpwr = objBusinessManpwrReqmt.ReadManpwrReqmt(objEntityManpwrReqmt);

            string strHtm = ConvertDataTableToHTML(dtManpwr);
            divReport.InnerHtml = strHtm;
            //for printing table
            string strPrintReport = ConvertDataTableForPrint(dtManpwr, dtCorp);
            divPrintReport.InnerHtml = strPrintReport;

        }//for viewing table
    }



    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsCommonLibrary Comm = new clsCommonLibrary();
        clsEntityManpwrReqmt_Status_Report objEntityManpwrReqmt = new clsEntityManpwrReqmt_Status_Report();
        clsBusinessLayerManpwr_Reqmt_Status_Report objBusinessManpwrReqmt = new clsBusinessLayerManpwr_Reqmt_Status_Report();
        string Division = "";
        string designation = "";
        string department = "";
        string project = "";
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
            
            if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
            {
                objEntityManpwrReqmt.DivsnId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
                 Division = ddlDivision.Text;
            }
            if (ddlDesignation.SelectedItem.Value != "--SELECT DESIGNATION--")
            {
                objEntityManpwrReqmt.intDegsid = Convert.ToInt32(ddlDesignation.SelectedItem.Value);
                designation = ddlDesignation.Text;
            }

            if (ddlDepartmnt.SelectedItem.Value != "--SELECT DEPARTMENT--")
            {
                objEntityManpwrReqmt.DeptId = Convert.ToInt32(ddlDepartmnt.SelectedItem.Value);
                department = ddlDepartmnt.Text;
            }
            if (ddlProject.SelectedItem.Value != "--SELECT PROJECT--")
            {
                objEntityManpwrReqmt.intProjid = Convert.ToInt32(ddlProject.SelectedItem.Value);
                project = ddlProject.Text;
            }


            if ((txtFromDate.Text.Trim() != "") && (txtTodate.Text.Trim() != ""))
            {
                DateTime startDate = Comm.textToDateTime(txtFromDate.Text.Trim());
                DateTime EndDate = Comm.textToDateTime(txtTodate.Text.Trim());
                int diff = Convert.ToInt32((EndDate - startDate).TotalDays);

                if (diff > 0)
                {
                    objEntityManpwrReqmt.FromDt = Comm.textToDateTime(txtFromDate.Text.Trim());
                    objEntityManpwrReqmt.ToDate = Comm.textToDateTime(txtTodate.Text.Trim());
                }
            }
           


            if (DdlStatus.SelectedItem.Value != "--SELECT STATUS--")
            {
                if (DdlStatus.SelectedValue == "GM APPROVED")
                {
                    objEntityManpwrReqmt.intS = 4;
                }
                else if (DdlStatus.SelectedValue == "REQUIREMENT ALLOCATED")
                {
                    //if (dt.Rows[intRowBodyCount]["RQALCDTL_ID"].ToString() != "")
                    //{
                    //    status = "REQUIREMENT ALLOCATED";
                    //}
                    objEntityManpwrReqmt.intS = 4;
                }
                else if (DdlStatus.SelectedValue == "JOB NOTIFIED")
                {
                    objEntityManpwrReqmt.intS = 4;
                }
                else if (DdlStatus.SelectedValue == "CLOSED")
                {
                    objEntityManpwrReqmt.intS = 7;
                }
                else if (DdlStatus.SelectedValue == "INTERVIEW DONE")
                {
                    objEntityManpwrReqmt.intS = 4;
                }
                else if (DdlStatus.SelectedValue == "REJECTED")
                {
                    objEntityManpwrReqmt.intS = 4;
                }
            }

            //for viewing table

            DataTable dtManpwr = new DataTable();
            dtManpwr = objBusinessManpwrReqmt.ReadManpwrReqmt(objEntityManpwrReqmt);

            string strHtm = ConvertDataTableToHTML(dtManpwr);
            divReport.InnerHtml = strHtm;

            //for printing table

            DataTable dtCorp = objBusinessManpwrReqmt.ReadCorporateAddress(objEntityManpwrReqmt);

            string strPrintReport = ConvertDataTableForPrint(dtManpwr, dtCorp);
            divPrintReport.InnerHtml = strPrintReport;
       

      
        
    }

    public string ConvertDataTableToHTML(DataTable dt)
    {
        
    
        //Evm--27


        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
       
            for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
            {
                if (intColumnHeaderCount == 1)//Ref#
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 2)//Approved Date
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 3)//Department
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 4)//Designation
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 5)//Division
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 6)//Project
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 7)//No of Resourcs
                {
                    strHtml += "<th class=\"thT\" style=\"width:5%;text-align: right; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 8)//status
                {
                    strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                //if (intColumnHeaderCount == 9)//status
                //{
                //    strHtml += "<th class=\"thT\" style=\"width:20%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                //}
                if (intColumnHeaderCount == 9)//aging
                {
                    strHtml += "<th class=\"thT\" style=\"width:5%;text-align: right; word-wrap:break-word;\">AGING</th>";
                }
                if (intColumnHeaderCount == 10)//Requested By
                {
                    strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
            }

            // strHtml += "<th class=\"thT\" style=\"width:10%; word-wrap:break-word;text-align: center;\">MORE INFO</th>";
            strHtml += "<tbody>";

            strHtml += "</tr>";


            strHtml += "</thead>";
           
            //add rows

            //if (dt.Rows.Count == 0)
            //{
            //    strHtml += "<td  class=\"thT\" colspan=\"10\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
            //}
            //else
            //{


            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                 string status = "";
                string StsChk = "";
               


                string sts = dt.Rows[intRowBodyCount]["STATUS"].ToString();

                if (sts == "0")
                {
                    // status = "NEW";
                }
                if (sts == "1")
                {
                    // status = "REQUEST CREATED";

                }
                else if (sts == "2")
                {
                    // status = "REQUEST APPROVED";

                }
                else if (sts == "3")
                {
                    // status = "HR VERIFIED";
                }

                if (sts == "4")
                {
                    status = "GM APPROVED";

                    if (dt.Rows[intRowBodyCount]["RQALCDTL_ID"].ToString() != "")
                    {
                        status = "REQUIREMENT ALLOCATED";
                        //status = "GM APPROVED";
                    }

                    if (dt.Rows[intRowBodyCount]["JBNTFY_ID"].ToString() != "")
                    {
                        status = "JOB NOTIFIED";
                        //status = "GM APPROVED";
                    }

                    if (dt.Rows[intRowBodyCount]["CAND_MSTRID"].ToString() != "")
                    {
                        status = "CANDIDATE SELECTED";
                        //status = "GM APPROVED";
                    }

                    clsEntityManpwrReqmt_Status_Report objEntityManpwrReqmt = new clsEntityManpwrReqmt_Status_Report();
                    clsBusinessLayerManpwr_Reqmt_Status_Report objBusinessManpwrReqmt = new clsBusinessLayerManpwr_Reqmt_Status_Report();

                    //objEntityManpwrReqmt.ManPwrId = Convert.ToInt32(hiddenManpwrId.Value);

                    string strshtlst = objBusinessManpwrReqmt.ReadCountCandShrtlst(objEntityManpwrReqmt);

                    if (strshtlst != "0")
                    {
                        status = "CANDIDATE SHORTLISTED";
                        StsChk = "8";
                    }
                    string strintrvw = objBusinessManpwrReqmt.ReadCountIntrvwPrcs(objEntityManpwrReqmt);

                    if (strintrvw != "0")
                    {
                        status = "INTERVIEW DONE";
                        StsChk = "8";
                    }


                    if (dt.Rows[intRowBodyCount]["REJECT_STATUS"].ToString() == "1")
                    {
                        status = "REJECTED";
                    }
                }
                if (sts == "6")
                {
                    status = "CANDIDATE SELECTION";
                }
                if (sts == "7")

                    status = "CLOSED";

                if ((DdlStatus.Text != "--SELECT STATUS--"))
                {
                    if (DdlStatus.Text == status)
                    {
                        strHtml += "<tr  >";
                    }
                }
                else
                {
                    strHtml += "<tr  >";
                }

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

              

                      //strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + status + "</td>";

                    if ((DdlStatus.Text != "--SELECT STATUS--"))
                    {
                        if (DdlStatus.Text == status)
                        {

                            if (dt.Rows.Count == 0)
                            {
                                strHtml += "<td  class=\"thT\" colspan=\"10\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
                            }
                            else if (dt.Rows.Count > 0)
                            {
                                string strId = dt.Rows[intRowBodyCount][0].ToString();
                                hiddenManpwrId.Value = strId;
                                if (intColumnBodyCount == 1)
                                {
                                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                                }
                                if (intColumnBodyCount == 2)
                                {
                                    DateTime ApprovedDate = Convert.ToDateTime(dt.Rows[intRowBodyCount][intColumnBodyCount]).Date;
                                    string dateString = ApprovedDate.ToShortDateString();

                                    //DateTime ApprovedDate1 = ApprovedDate.Date;
                                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dateString + "</td>";
                                }
                                if (intColumnBodyCount == 3)
                                {
                                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                                }
                                if (intColumnBodyCount == 4)
                                {
                                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                                }
                                if (intColumnBodyCount == 5)
                                {
                                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                                }
                                if (intColumnBodyCount == 6)
                                {
                                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                                }
                                if (intColumnBodyCount == 7)
                                {
                                    strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                                }
                                if (intColumnBodyCount == 8)//Status
                                    //{
                                    //    string sts = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();

                                    //    if (sts == "0")
                                    //    {
                                    //        // status = "NEW";
                                    //    }
                                    //    if (sts == "1")
                                    //    {
                                    //        // status = "REQUEST CREATED";

                                    //    }
                                    //    else if (sts == "2")
                                    //    {
                                    //        // status = "REQUEST APPROVED";

                                    //    }
                                    //    else if (sts == "3")
                                    //    {
                                    //        // status = "HR VERIFIED";
                                    //    }

                                    //    if (sts == "4")
                                    //    {
                                    //        status = "GM APPROVED";

                                    //        if (dt.Rows[intRowBodyCount]["RQALCDTL_ID"].ToString() != "")
                                    //        {
                                    //            status = "REQUIREMENT ALLOCATED";
                                    //            //status = "GM APPROVED";
                                    //        }

                                    //        if (dt.Rows[intRowBodyCount]["JBNTFY_ID"].ToString() != "")
                                    //        {
                                    //            status = "JOB NOTIFIED";
                                    //            //status = "GM APPROVED";
                                    //        }

                                    //        if (dt.Rows[intRowBodyCount]["CAND_MSTRID"].ToString() != "")
                                    //        {
                                    //            status = "CANDIDATE SELECTED";
                                    //            //status = "GM APPROVED";
                                    //        }

                                    //        clsEntityManpwrReqmt_Status_Report objEntityManpwrReqmt = new clsEntityManpwrReqmt_Status_Report();
                                    //        clsBusinessLayerManpwr_Reqmt_Status_Report objBusinessManpwrReqmt = new clsBusinessLayerManpwr_Reqmt_Status_Report();

                                    //        objEntityManpwrReqmt.ManPwrId = Convert.ToInt32(hiddenManpwrId.Value);

                                    //        string strshtlst = objBusinessManpwrReqmt.ReadCountCandShrtlst(objEntityManpwrReqmt);

                                    //        if (strshtlst != "0")
                                    //        {
                                    //            status = "CANDIDATE SHORTLISTED";
                                    //            StsChk = "8";
                                    //        }
                                    //        string strintrvw = objBusinessManpwrReqmt.ReadCountIntrvwPrcs(objEntityManpwrReqmt);

                                    //        if (strintrvw != "0")
                                    //        {
                                    //            status = "INTERVIEW DONE";
                                    //            StsChk = "8";
                                    //        }
                                    //    }

                                    //    if (dt.Rows[intRowBodyCount]["REJECT_STATUS"].ToString() == "1")
                                    //    {
                                    //        status = "REJECTED";
                                    //    }

                                    //    if (sts == "6")
                                    //    {
                                    //        status = "CANDIDATE SELECTION";
                                    //    }
                                    //    if (sts == "7")

                                    //        status = "CLOSED";

                                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + status + "</td>";



                                if (intColumnBodyCount == 9)//Aging
                                {
                                    DateTime DtTody = DateTime.Now;
                                    DateTime DtApproved = Convert.ToDateTime(dt.Rows[intRowBodyCount]["APPROVED DATE"]);
                                    TimeSpan age = DtTody - DtApproved;
                                    int aa = age.Days;


                                    strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + aa + "</td>";
                                }
                                if (intColumnBodyCount == 10)//Requested By
                                {
                                    string FName = dt.Rows[intRowBodyCount]["EMPERDTL_FNAME"].ToString().ToUpper();
                                    string MName = dt.Rows[intRowBodyCount]["EMPERDTL_MNAME"].ToString().ToUpper();
                                    string Lname = dt.Rows[intRowBodyCount]["REQUESTED BY"].ToString().ToUpper();
                                    string FullName = FName + " " + MName + " " + Lname;
                                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + FullName + "</td>";
                                }
                            }
                            // strHtml += "</tr>";

                        }    //MoreInfo
                    }
                    //strHtml += "<td class=\"tdT\" style=\"width:10%; word-wrap:break-word;text-align: center;\"><input type=\"button\" class=\"save\" style=\"height:22px;margin-top:3%\" value=\"More Info\" onclick=\"return OpenManPowerRequiremtDetails('" + strId + "','" + StsChk + "');\" /></td>";
                    else
                    {
                        //  strHtml += "<tr  >";
                        if (dt.Rows.Count == 0)
                        {
                            strHtml += "<td  class=\"thT\" colspan=\"10\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
                        }
                        else if (dt.Rows.Count > 0)
                        {
                            string strId = dt.Rows[intRowBodyCount][0].ToString();
                            hiddenManpwrId.Value = strId;
                            if (intColumnBodyCount == 1)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                            }
                            if (intColumnBodyCount == 2)
                            {
                                DateTime ApprovedDate = Convert.ToDateTime(dt.Rows[intRowBodyCount][intColumnBodyCount]).Date;
                                string dateString = ApprovedDate.ToShortDateString();

                                //DateTime ApprovedDate1 = ApprovedDate.Date;
                                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dateString + "</td>";
                            }
                            if (intColumnBodyCount == 3)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                            }
                            if (intColumnBodyCount == 4)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                            }
                            if (intColumnBodyCount == 5)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                            }
                            if (intColumnBodyCount == 6)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                            }
                            if (intColumnBodyCount == 7)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                            }
                            if (intColumnBodyCount == 8)//Status
                            {
                                // string sts = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();

                                if (sts == "0")
                                {
                                    // status = "NEW";
                                }
                                if (sts == "1")
                                {
                                    // status = "REQUEST CREATED";

                                }
                                else if (sts == "2")
                                {
                                    // status = "REQUEST APPROVED";

                                }
                                else if (sts == "3")
                                {
                                    // status = "HR VERIFIED";
                                }

                                if (sts == "4")
                                {
                                    status = "GM APPROVED";

                                    if (dt.Rows[intRowBodyCount]["RQALCDTL_ID"].ToString() != "")
                                    {
                                        status = "REQUIREMENT ALLOCATED";
                                        //status = "GM APPROVED";
                                    }

                                    if (dt.Rows[intRowBodyCount]["JBNTFY_ID"].ToString() != "")
                                    {
                                        status = "JOB NOTIFIED";
                                        //status = "GM APPROVED";
                                    }

                                    if (dt.Rows[intRowBodyCount]["CAND_MSTRID"].ToString() != "")
                                    {
                                        status = "CANDIDATE SELECTED";
                                        //status = "GM APPROVED";
                                    }

                                    clsEntityManpwrReqmt_Status_Report objEntityManpwrReqmt = new clsEntityManpwrReqmt_Status_Report();
                                    clsBusinessLayerManpwr_Reqmt_Status_Report objBusinessManpwrReqmt = new clsBusinessLayerManpwr_Reqmt_Status_Report();

                                    objEntityManpwrReqmt.ManPwrId = Convert.ToInt32(hiddenManpwrId.Value);

                                    string strshtlst = objBusinessManpwrReqmt.ReadCountCandShrtlst(objEntityManpwrReqmt);

                                    if (strshtlst != "0")
                                    {
                                        status = "CANDIDATE SHORTLISTED";
                                        StsChk = "8";
                                    }
                                    string strintrvw = objBusinessManpwrReqmt.ReadCountIntrvwPrcs(objEntityManpwrReqmt);

                                    if (strintrvw != "0")
                                    {
                                        status = "INTERVIEW DONE";
                                        StsChk = "8";
                                    }
                                }

                                if (dt.Rows[intRowBodyCount]["REJECT_STATUS"].ToString() == "1")
                                {
                                    status = "REJECTED";
                                }

                                if (sts == "6")
                                {
                                    status = "CANDIDATE SELECTION";
                                }
                                if (sts == "7")

                                    status = "CLOSED";

                                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + status + "</td>";
                            }


                            if (intColumnBodyCount == 9)//Aging
                            {
                                DateTime DtTody = DateTime.Now;
                                DateTime DtApproved = Convert.ToDateTime(dt.Rows[intRowBodyCount]["APPROVED DATE"]);
                                TimeSpan age = DtTody - DtApproved;
                                int aa = age.Days;


                                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + aa + "</td>";
                            }
                            if (intColumnBodyCount == 10)//Requested By
                            {
                                string FName = dt.Rows[intRowBodyCount]["EMPERDTL_FNAME"].ToString().ToUpper();
                                string MName = dt.Rows[intRowBodyCount]["EMPERDTL_MNAME"].ToString().ToUpper();
                                string Lname = dt.Rows[intRowBodyCount]["REQUESTED BY"].ToString().ToUpper();
                                string FullName = FName + " " + MName + " " + Lname;
                                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + FullName + "</td>";
                            }
                        }
                        //  strHtml += "</tr>";

                    }
                }
                       
                        strHtml += "</tr>";
                    }

                   
                  
                   
            
               
            

 
          
                //if (dt.Rows.Count == 0)
                //{
                //    strHtml += "<td  class=\"thT\" colspan=\"8\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
                //}

        strHtml += "</tbody>";
       
        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
         
        //End

    }


    [WebMethod]
    public static string[] ManPowerRequiremtDetails(string strManPwrId,string Sts)
    {

        string[] strJson = new string[30];

        clsEntityManpwrReqmt_Status_Report objEntityManpwrReqmt = new clsEntityManpwrReqmt_Status_Report();
        clsBusinessLayerManpwr_Reqmt_Status_Report objBusinessManpwrReqmt = new clsBusinessLayerManpwr_Reqmt_Status_Report();

        objEntityManpwrReqmt.ManPwrId = Convert.ToInt32(strManPwrId);

        DataTable dtManPwrId = new DataTable();
        dtManPwrId = objBusinessManpwrReqmt.ReadManpwrReqmtById(objEntityManpwrReqmt);

        strJson[0] = dtManPwrId.Rows[0]["MNP_REFNUM"].ToString().ToUpper();
        strJson[1] = dtManPwrId.Rows[0]["MNP_RESOURCENUM"].ToString();
        strJson[2] = dtManPwrId.Rows[0]["CPRDIV_NAME"].ToString();
        strJson[3] = dtManPwrId.Rows[0]["DSGN_NAME"].ToString();

        DataTable dtManpwrCand = new DataTable();
        objEntityManpwrReqmt.StsChk = Sts;
        dtManpwrCand = objBusinessManpwrReqmt.ReadManpwrCandidts(objEntityManpwrReqmt);
        
        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTableDtl\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        string visa = "";
        string license = "";
        string reference = "";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dtManpwrCand.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">" + dtManpwrCand.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">" + dtManpwrCand.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">" + dtManpwrCand.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">" + dtManpwrCand.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">" + dtManpwrCand.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">" + dtManpwrCand.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dtManpwrCand.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dtManpwrCand.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr  >";

            string strId = dtManpwrCand.Rows[intRowBodyCount][0].ToString();


            for (int intColumnBodyCount = 0; intColumnBodyCount < dtManpwrCand.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtManpwrCand.Rows[intRowBodyCount][intColumnBodyCount].ToString()+ "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtManpwrCand.Rows[intRowBodyCount][intColumnBodyCount].ToString()+ "</td>";
                }
                if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtManpwrCand.Rows[intRowBodyCount][intColumnBodyCount].ToString()+ "</td>";
                }
                if (intColumnBodyCount == 4)
                {
                    if (dtManpwrCand.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "1")
                    {
                        reference = "CONSULTANCY"; 
                    }
                    else if (dtManpwrCand.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "2")
                    {
                        reference = "DIVISION";
                    }
                    else if (dtManpwrCand.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "3")
                    {
                        reference = "DEPARTMENT";
                    }
                    else if (dtManpwrCand.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "4")
                    {
                        reference = "EMPLOYEE";
                    }

                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + reference + "</td>";
                }
                if (intColumnBodyCount == 5)
                {
                    if (dtManpwrCand.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "0")
                    {
                        visa = "NO";
                    }
                    else
                    {
                        visa = "YES";
                    }

                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + visa + "</td>";
                }
                if (intColumnBodyCount == 6)
                {
                    if (dtManpwrCand.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "0")
                    {
                        license = "NO";
                    }
                    else
                    {
                        license = "YES";
                    }

                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + license + "</td>";
                }
                if (intColumnBodyCount == 7)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtManpwrCand.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
            }
            strHtml += "</tr>";
        }


        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        strJson[4] = sb.ToString();


        return strJson;

    }


    //It build the Html table by using the datatable provided
    public string ConvertDataTableForPrint(DataTable dt, DataTable dtCorp)
    {
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Manpower Requirements Status Report";
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
        

        string div = "";
        if (ddlDivision.SelectedItem.Text.ToString() == "--SELECT DIVISION--")
        {
            div = "";
        }
        else
        {
            div = "<tr>Division : "+ddlDivision.SelectedItem.Text.ToString()+"<br/></tr>";
        }

        string dept = "";
        if (ddlDepartmnt.SelectedItem.Text.ToString() == "--SELECT DEPARTMENT--")
        {
            dept = "";
        }
        else
        {
            dept = "<tr>Department : " + ddlDepartmnt.SelectedItem.Text.ToString() + "<br/></tr>";
        }
        //EVM--0024
        string desgn = "";
        if (ddlDesignation.SelectedItem.Text.ToString() == "--SELECT DESIGNATION--")
        {
            desgn = "";
        }
        else
        {
            desgn = "<tr>Designation : " + ddlDesignation.SelectedItem.Text.ToString() + "<br/></tr>";
        }
        string project = "";
        if (ddlProject.SelectedItem.Text.ToString() == "--SELECT PROJECT--")
        {
            project = "";
        }
        else
        {
            project = "<tr>Project : " + ddlProject.SelectedItem.Text.ToString() + "<br/></tr>";
        }
        string fromdate = "";
        if (txtFromDate.Text == "")
        {
            fromdate = "";
        }
        else
        {
            fromdate = "<tr>From date : " + txtFromDate.Text + "<br/></tr>";
        }
        string todate = "";
        if (txtTodate.Text == "")
        {
            todate = "";
        }
        else
        {
            todate = "<tr>To date : " + txtTodate.Text + "<br/></tr>";
        }
        string strstatus = "";
        if (DdlStatus.SelectedItem.Text.ToString() == "--SELECT STATUS--")
        {
            strstatus = "";
        }
        else
        {
            strstatus = "<tr>Status : " + DdlStatus.SelectedItem.Text.ToString() + "<br/></tr>";
        }
        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strUsrName+ strCaptionTabTitle + strCaptionTabstop + div + dept + desgn + project + fromdate + todate + strstatus;
        //END
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
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 6)//Project
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 7)//No of Resourcs
            {
                strHtml += "<th class=\"thT\" style=\"width:5%;text-align: right; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 8)//status
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            //if (intColumnHeaderCount == 9)//status
            //{
            //    strHtml += "<th class=\"thT\" style=\"width:20%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            //}
            if (intColumnHeaderCount == 9)//aging
            {
                strHtml += "<th class=\"thT\" style=\"width:5%;text-align: right; word-wrap:break-word;\">AGING</th>";
            }
            if (intColumnHeaderCount == 10)//Requested By
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
        }

        if (dt.Columns.Count == 0)
        {
            strHtml += "<td class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">REF#</th>";
            strHtml += "<td class=\"thT\" style=\"width:20%;text-align: center; word-wrap:break-word;\">NUMBER OF RESOURCES</th>";
            strHtml += "<td class=\"thT\"  style=\"width:20%;text-align: center; word-wrap:break-word;\">DIVISION</th>";
            strHtml += "<td class=\"thT\"  style=\"width:20%;text-align: center; word-wrap:break-word;\">DESIGNATION</th>";
            strHtml += "<td class=\"thT\"  style=\"width:20%;text-align: center; word-wrap:break-word;\">PROJECT</th>";
            strHtml += "<td class=\"thT\"  style=\"width:20%;text-align: center; word-wrap:break-word;\">NO OF RESOURCES</th>";
            strHtml += "<td class=\"thT\"  style=\"width:20%;text-align: center; word-wrap:break-word;\">STATUS</th>";
            strHtml += "<td class=\"thT\"  style=\"width:20%;text-align: center; word-wrap:break-word;\">AGING</th>";
            strHtml += "<td class=\"thT\"  style=\"width:20%;text-align: center; word-wrap:break-word;\">REQUESTED BY</th>";
        }


        strHtml += "</tr>";


        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";


        if (dt.Rows.Count == 0)
        {
            strHtml += "<tr  ><td  class=\"thT\" colspan=\"10\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td></tr>";
        }
        else
        {

            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                string status = "";
                string StsChk = "";



                string sts = dt.Rows[intRowBodyCount]["STATUS"].ToString();

                if (sts == "0")
                {
                    // status = "NEW";
                }
                if (sts == "1")
                {
                    // status = "REQUEST CREATED";

                }
                else if (sts == "2")
                {
                    // status = "REQUEST APPROVED";

                }
                else if (sts == "3")
                {
                    // status = "HR VERIFIED";
                }

                if (sts == "4")
                {
                    status = "GM APPROVED";

                    if (dt.Rows[intRowBodyCount]["RQALCDTL_ID"].ToString() != "")
                    {
                        status = "REQUIREMENT ALLOCATED";
                        //status = "GM APPROVED";
                    }

                    if (dt.Rows[intRowBodyCount]["JBNTFY_ID"].ToString() != "")
                    {
                        status = "JOB NOTIFIED";
                        //status = "GM APPROVED";
                    }

                    if (dt.Rows[intRowBodyCount]["CAND_MSTRID"].ToString() != "")
                    {
                        status = "CANDIDATE SELECTED";
                        //status = "GM APPROVED";
                    }

                    clsEntityManpwrReqmt_Status_Report objEntityManpwrReqmt = new clsEntityManpwrReqmt_Status_Report();
                    clsBusinessLayerManpwr_Reqmt_Status_Report objBusinessManpwrReqmt = new clsBusinessLayerManpwr_Reqmt_Status_Report();

                    //objEntityManpwrReqmt.ManPwrId = Convert.ToInt32(hiddenManpwrId.Value);

                    string strshtlst = objBusinessManpwrReqmt.ReadCountCandShrtlst(objEntityManpwrReqmt);

                    if (strshtlst != "0")
                    {
                        status = "CANDIDATE SHORTLISTED";
                        StsChk = "8";
                    }
                    string strintrvw = objBusinessManpwrReqmt.ReadCountIntrvwPrcs(objEntityManpwrReqmt);

                    if (strintrvw != "0")
                    {
                        status = "INTERVIEW DONE";
                        StsChk = "8";
                    }


                    if (dt.Rows[intRowBodyCount]["REJECT_STATUS"].ToString() == "1")
                    {
                        status = "REJECTED";
                    }
                }
                if (sts == "6")
                {
                    status = "CANDIDATE SELECTION";
                }
                if (sts == "7")

                    status = "CLOSED";

                if ((DdlStatus.Text != "--SELECT STATUS--"))
                {
                    if (DdlStatus.Text == status)
                    {
                        strHtml += "<tr  >";
                    }
                }
                else
                {
                    strHtml += "<tr  >";
                }

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {



                    //strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + status + "</td>";

                    if ((DdlStatus.Text != "--SELECT STATUS--"))
                    {
                        if (DdlStatus.Text == status)
                        {

                            if (dt.Rows.Count == 0)
                            {
                                strHtml += "<td  class=\"thT\" colspan=\"10\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
                            }
                            else if (dt.Rows.Count > 0)
                            {
                                string strId = dt.Rows[intRowBodyCount][0].ToString();
                                hiddenManpwrId.Value = strId;
                                if (intColumnBodyCount == 1)
                                {
                                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                                }
                                if (intColumnBodyCount == 2)
                                {
                                    DateTime ApprovedDate = Convert.ToDateTime(dt.Rows[intRowBodyCount][intColumnBodyCount]).Date;
                                    string dateString = ApprovedDate.ToShortDateString();

                                    //DateTime ApprovedDate1 = ApprovedDate.Date;
                                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dateString + "</td>";
                                }
                                if (intColumnBodyCount == 3)
                                {
                                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                                }
                                if (intColumnBodyCount == 4)
                                {
                                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                                }
                                if (intColumnBodyCount == 5)
                                {
                                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                                }
                                if (intColumnBodyCount == 6)
                                {
                                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                                }
                                if (intColumnBodyCount == 7)
                                {
                                    strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                                }
                                if (intColumnBodyCount == 8)
                                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + status + "</td>";



                                if (intColumnBodyCount == 9)//Aging
                                {
                                    DateTime DtTody = DateTime.Now;
                                    DateTime DtApproved = Convert.ToDateTime(dt.Rows[intRowBodyCount]["APPROVED DATE"]);
                                    TimeSpan age = DtTody - DtApproved;
                                    int aa = age.Days;


                                    strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + aa + "</td>";
                                }
                                if (intColumnBodyCount == 10)//Requested By
                                {
                                    string FName = dt.Rows[intRowBodyCount]["EMPERDTL_FNAME"].ToString().ToUpper();
                                    string MName = dt.Rows[intRowBodyCount]["EMPERDTL_MNAME"].ToString().ToUpper();
                                    string Lname = dt.Rows[intRowBodyCount]["REQUESTED BY"].ToString().ToUpper();
                                    string FullName = FName + " " + MName + " " + Lname;
                                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + FullName + "</td>";
                                }
                            }
                            // strHtml += "</tr>";

                        }    //MoreInfo
                    }
                    //strHtml += "<td class=\"tdT\" style=\"width:10%; word-wrap:break-word;text-align: center;\"><input type=\"button\" class=\"save\" style=\"height:22px;margin-top:3%\" value=\"More Info\" onclick=\"return OpenManPowerRequiremtDetails('" + strId + "','" + StsChk + "');\" /></td>";
                    else
                    {
                        //  strHtml += "<tr  >";
                        if (dt.Rows.Count == 0)
                        {
                            strHtml += "<td  class=\"thT\" colspan=\"10\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
                        }
                        else if (dt.Rows.Count > 0)
                        {
                            string strId = dt.Rows[intRowBodyCount][0].ToString();
                            hiddenManpwrId.Value = strId;
                            if (intColumnBodyCount == 1)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                            }
                            if (intColumnBodyCount == 2)
                            {
                                DateTime ApprovedDate = Convert.ToDateTime(dt.Rows[intRowBodyCount][intColumnBodyCount]).Date;
                                string dateString = ApprovedDate.ToShortDateString();

                                //DateTime ApprovedDate1 = ApprovedDate.Date;
                                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dateString + "</td>";
                            }
                            if (intColumnBodyCount == 3)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                            }
                            if (intColumnBodyCount == 4)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                            }
                            if (intColumnBodyCount == 5)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                            }
                            if (intColumnBodyCount == 6)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                            }
                            if (intColumnBodyCount == 7)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                            }
                            if (intColumnBodyCount == 8)//Status
                            {
                                // string sts = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();

                                if (sts == "0")
                                {
                                    // status = "NEW";
                                }
                                if (sts == "1")
                                {
                                    // status = "REQUEST CREATED";

                                }
                                else if (sts == "2")
                                {
                                    // status = "REQUEST APPROVED";

                                }
                                else if (sts == "3")
                                {
                                    // status = "HR VERIFIED";
                                }

                                if (sts == "4")
                                {
                                    status = "GM APPROVED";

                                    if (dt.Rows[intRowBodyCount]["RQALCDTL_ID"].ToString() != "")
                                    {
                                        status = "REQUIREMENT ALLOCATED";
                                        //status = "GM APPROVED";
                                    }

                                    if (dt.Rows[intRowBodyCount]["JBNTFY_ID"].ToString() != "")
                                    {
                                        status = "JOB NOTIFIED";
                                        //status = "GM APPROVED";
                                    }

                                    if (dt.Rows[intRowBodyCount]["CAND_MSTRID"].ToString() != "")
                                    {
                                        status = "CANDIDATE SELECTED";
                                        //status = "GM APPROVED";
                                    }

                                    clsEntityManpwrReqmt_Status_Report objEntityManpwrReqmt = new clsEntityManpwrReqmt_Status_Report();
                                    clsBusinessLayerManpwr_Reqmt_Status_Report objBusinessManpwrReqmt = new clsBusinessLayerManpwr_Reqmt_Status_Report();

                                    objEntityManpwrReqmt.ManPwrId = Convert.ToInt32(hiddenManpwrId.Value);

                                    string strshtlst = objBusinessManpwrReqmt.ReadCountCandShrtlst(objEntityManpwrReqmt);

                                    if (strshtlst != "0")
                                    {
                                        status = "CANDIDATE SHORTLISTED";
                                        StsChk = "8";
                                    }
                                    string strintrvw = objBusinessManpwrReqmt.ReadCountIntrvwPrcs(objEntityManpwrReqmt);

                                    if (strintrvw != "0")
                                    {
                                        status = "INTERVIEW DONE";
                                        StsChk = "8";
                                    }
                                }

                                if (dt.Rows[intRowBodyCount]["REJECT_STATUS"].ToString() == "1")
                                {
                                    status = "REJECTED";
                                }

                                if (sts == "6")
                                {
                                    status = "CANDIDATE SELECTION";
                                }
                                if (sts == "7")

                                    status = "CLOSED";

                                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + status + "</td>";
                            }


                            if (intColumnBodyCount == 9)//Aging
                            {
                                DateTime DtTody = DateTime.Now;
                                DateTime DtApproved = Convert.ToDateTime(dt.Rows[intRowBodyCount]["APPROVED DATE"]);
                                TimeSpan age = DtTody - DtApproved;
                                int aa = age.Days;


                                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + aa + "</td>";
                            }
                            if (intColumnBodyCount == 10)//Requested By
                            {
                                string FName = dt.Rows[intRowBodyCount]["EMPERDTL_FNAME"].ToString().ToUpper();
                                string MName = dt.Rows[intRowBodyCount]["EMPERDTL_MNAME"].ToString().ToUpper();
                                string Lname = dt.Rows[intRowBodyCount]["REQUESTED BY"].ToString().ToUpper();
                                string FullName = FName + " " + MName + " " + Lname;
                                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + FullName + "</td>";
                            }
                        }
                        //  strHtml += "</tr>";

                    }
                }

                strHtml += "</tr>";
            }

          
        }
        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();


    }

    [WebMethod]
    public static string[] ManpwrDetailsPrint(string strManpwrId, int intCorpId, int intOrgId)
    {

        //printing details

        string[] strJsonPrint = new string[30];

        clsEntityManpwrReqmt_Status_Report objEntityManpwrReqmt = new clsEntityManpwrReqmt_Status_Report();
        clsBusinessLayerManpwr_Reqmt_Status_Report objBusinessManpwrReqmt = new clsBusinessLayerManpwr_Reqmt_Status_Report();


        objEntityManpwrReqmt.ManPwrId = Convert.ToInt32(strManpwrId);

        objEntityManpwrReqmt.CorpId = intCorpId;
        objEntityManpwrReqmt.OrgId = intOrgId;

        DataTable dtCorp = new DataTable();
        dtCorp = objBusinessManpwrReqmt.ReadCorporateAddress(objEntityManpwrReqmt);

        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Manpower Requirement status Details";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
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

        string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr + "</td></tr>";
        string strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        string strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strCaptionTabTitle + strCaptionTabstop;

        sbCap.Append(strPrintCaptionTable);
        //write to  divPrintCaptionDetails
        strJsonPrint[0] = sbCap.ToString();

        string[] strJson = new string[30];

        DataTable dtManPwrId = new DataTable();
        dtManPwrId = objBusinessManpwrReqmt.ReadManpwrReqmtById(objEntityManpwrReqmt);

        strJson[1] = dtManPwrId.Rows[0]["MNP_REFNUM"].ToString().ToUpper();
        strJson[2] = dtManPwrId.Rows[0]["MNP_RESOURCENUM"].ToString();
        strJson[3] = dtManPwrId.Rows[0]["CPRDIV_NAME"].ToString();
        strJson[4] = dtManPwrId.Rows[0]["DSGN_NAME"].ToString();

        StringBuilder sbCapMnpwrDtls = new StringBuilder();

        string strMnpwrstart = "<table>";
        string strRef = "<tr><td>Ref# : " + strJson[1] + "</td></tr>";
        string strResrc = "<tr><td>No.of Resources  : " + strJson[2] + "</td></tr>";
        string strDiv = "<tr><td>Division : " + strJson[3] + "</td></tr>";
        string strDsgntn = "<tr><td>Designation : " + strJson[4] + "</td></tr>";
        string strprint = strMnpwrstart + strRef + strResrc + strDiv + strDsgntn;

        sbCapMnpwrDtls.Append(strprint);
        //write to  lblPrintOnBrdDtls
        strJsonPrint[1] = sbCapMnpwrDtls.ToString();


        DataTable dtManpwrCand = new DataTable();
        dtManpwrCand = objBusinessManpwrReqmt.ReadManpwrCandidts(objEntityManpwrReqmt);

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";

        string visa = "";
        string license = "";
        string reference = "";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dtManpwrCand.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dtManpwrCand.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dtManpwrCand.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dtManpwrCand.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dtManpwrCand.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dtManpwrCand.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">" + dtManpwrCand.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dtManpwrCand.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
        }
        if (dtManpwrCand.Columns.Count == 0)
        {
            strHtml += "<td class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">CANDIDATE NAME</th>";
            strHtml += "<td class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">LOCATION</th>";
            strHtml += "<td class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">NATIONALITY</th>";
            strHtml += "<td class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">REFERENCE</th>";
            strHtml += "<td class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">VISA</th>";
            strHtml += "<td class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">LICENSE</th>";
            strHtml += "<td class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">PASSPORT NUMBER</th>";
        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dtManpwrCand.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr  >";

            string strId = dtManpwrCand.Rows[intRowBodyCount][0].ToString();

            for (int intColumnBodyCount = 0; intColumnBodyCount < dtManpwrCand.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtManpwrCand.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtManpwrCand.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtManpwrCand.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 4)
                {
                    if (dtManpwrCand.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "1")
                    {
                        reference = "CONSULTANCY"; 
                    }
                    else if (dtManpwrCand.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "2")
                    {
                        reference = "DIVISION";
                    }
                    else if (dtManpwrCand.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "3")
                    {
                        reference = "DEPARTMENT";
                    }
                    else if (dtManpwrCand.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "4")
                    {
                        reference = "EMPLOYEE";
                    }

                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + reference + "</td>";
                }
                if (intColumnBodyCount == 5)
                {
                    if (dtManpwrCand.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "0")
                    {
                        visa = "NO";
                    }
                    else
                    {
                        visa = "YES";
                    }

                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + visa + "</td>";
                }
                if (intColumnBodyCount == 6)
                {
                    if (dtManpwrCand.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "0")
                    {
                        license = "NO";
                    }
                    else
                    {
                        license = "YES";
                    }

                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + license + "</td>";
                }
                if (intColumnBodyCount == 7)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtManpwrCand.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
            }
            strHtml += "</tr>";
        }
        if (dtManpwrCand.Rows.Count == 0)
        {
            strHtml += "<td  class=\"thT\" colspan=\"8\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        strJsonPrint[2] = sb.ToString();


        return strJsonPrint;
    }
    protected void ddlDepartmnt_SelectedIndexChanged(object sender, EventArgs e)     //emp25
    {
        clsEntityManpwrReqmt_Status_Report objEntityManpwrReqmt = new clsEntityManpwrReqmt_Status_Report();
        clsBusinessLayerManpwr_Reqmt_Status_Report objBusinessManpwrReqmt = new clsBusinessLayerManpwr_Reqmt_Status_Report();

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

        ddlDivision.Items.Clear();
        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
        if (ddlDepartmnt.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            int Dept = Convert.ToInt32(ddlDepartmnt.SelectedItem.Value);
            objEntityManpwrReqmt.DeptId = Dept;

            DataTable dtSubConrt = objBusinessManpwrReqmt.ReadDivision(objEntityManpwrReqmt); ;
            ddlDivision.Items.Clear();
            ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
            if (dtSubConrt.Rows.Count > 0)
            {
                ddlDivision.Items.Clear();
                ddlDivision.DataSource = dtSubConrt;


                ddlDivision.DataValueField = "CPRDIV_ID";
                ddlDivision.DataTextField = "CPRDIV_NAME";

                ddlDivision.DataBind();
                ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
            }

        }

       // ScriptManager.RegisterStartupScript(this, GetType(), "DropDepart", "DropDepart();", true);
      


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
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.MNPWR_REQRMNT_STS_CSV);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
            string newFilePath = Server.MapPath("/CustomFiles/HCM CSV/Manpower Requirement Status/Manpower_Requirement_Status_Report_" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "Manpower_Requirement_Status_Report_" + strNextId + ".csv";
            Response.ContentType = "csv";
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.MNPWR_REQRMNT_STS_CSV);
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
        table.Columns.Add("APPROVED DATE ", typeof(string));
        table.Columns.Add("DEPARTMENT", typeof(string));
        table.Columns.Add("DIVISION", typeof(string));
        table.Columns.Add("DESIGNATION", typeof(string));
        table.Columns.Add("PROJECT", typeof(string));
        table.Columns.Add("NUMBER OF RESOURCES", typeof(string));
        table.Columns.Add("STATUS", typeof(string));
        table.Columns.Add("AGING", typeof(string));
        table.Columns.Add("REQUESTED BY", typeof(string));

        clsEntityManpwrReqmt_Status_Report objEntityManpwrReqmt = new clsEntityManpwrReqmt_Status_Report();
        clsBusinessLayerManpwr_Reqmt_Status_Report objBusinessManpwrReqmt = new clsBusinessLayerManpwr_Reqmt_Status_Report();
        string Division = "";
        string designation = "";
        string department = "";
        string project = "";
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

        if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
        {
            objEntityManpwrReqmt.DivsnId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
            Division = ddlDivision.Text;
        }
        if (ddlDesignation.SelectedItem.Value != "--SELECT DESIGNATION--")
        {
            objEntityManpwrReqmt.intDegsid = Convert.ToInt32(ddlDesignation.SelectedItem.Value);
            designation = ddlDesignation.Text;
        }

        if (ddlDepartmnt.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntityManpwrReqmt.DeptId = Convert.ToInt32(ddlDepartmnt.SelectedItem.Value);
            department = ddlDepartmnt.Text;
        }
        if (ddlProject.SelectedItem.Value != "--SELECT PROJECT--")
        {
            objEntityManpwrReqmt.intProjid = Convert.ToInt32(ddlProject.SelectedItem.Value);
            project = ddlProject.Text;
        }


        if ((txtFromDate.Text.Trim() != "") && (txtTodate.Text.Trim() != ""))
        {
            DateTime startDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
            DateTime EndDate = objCommon.textToDateTime(txtTodate.Text.Trim());
            int diff = Convert.ToInt32((EndDate - startDate).TotalDays);

            if (diff > 0)
            {
                objEntityManpwrReqmt.FromDt = objCommon.textToDateTime(txtFromDate.Text.Trim());
                objEntityManpwrReqmt.ToDate = objCommon.textToDateTime(txtTodate.Text.Trim());
            }
        }



        if (DdlStatus.SelectedItem.Value != "--SELECT STATUS--")
        {
            if (DdlStatus.SelectedValue == "GM APPROVED")
            {
                objEntityManpwrReqmt.intS = 4;
            }
            else if (DdlStatus.SelectedValue == "REQUIREMENT ALLOCATED")
            {
                //if (dt.Rows[intRowBodyCount]["RQALCDTL_ID"].ToString() != "")
                //{
                //    status = "REQUIREMENT ALLOCATED";
                //}
                objEntityManpwrReqmt.intS = 4;
            }
            else if (DdlStatus.SelectedValue == "JOB NOTIFIED")
            {
                objEntityManpwrReqmt.intS = 4;
            }
            else if (DdlStatus.SelectedValue == "CLOSED")
            {
                objEntityManpwrReqmt.intS = 7;
            }
            else if (DdlStatus.SelectedValue == "INTERVIEW DONE")
            {
                objEntityManpwrReqmt.intS = 4;
            }
            else if (DdlStatus.SelectedValue == "REJECTED")
            {
                objEntityManpwrReqmt.intS = 4;
            }
        }

        //for viewing table

        DataTable dt = new DataTable();
        dt = objBusinessManpwrReqmt.ReadManpwrReqmt(objEntityManpwrReqmt);

        //for printing table
        string Ref = "";
        string ApproveDate = "";
        string Department = "";
        string Dvsn = "";
        string Designation = "";
        string pjt = "";
        string No_of_Resources = "";
        string mnsts = "";
        string aging = "";
        string RequestedBy = "";
       

        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string status = "";
            string StsChk = "";



            string sts = dt.Rows[intRowBodyCount]["STATUS"].ToString();

            if (sts == "0")
            {
                // status = "NEW";
            }
            if (sts == "1")
            {
                // status = "REQUEST CREATED";

            }
            else if (sts == "2")
            {
                // status = "REQUEST APPROVED";

            }
            else if (sts == "3")
            {
                // status = "HR VERIFIED";
            }

            if (sts == "4")
            {
                status = "GM APPROVED";

                if (dt.Rows[intRowBodyCount]["RQALCDTL_ID"].ToString() != "")
                {
                    status = "REQUIREMENT ALLOCATED";
                    //status = "GM APPROVED";
                }

                if (dt.Rows[intRowBodyCount]["JBNTFY_ID"].ToString() != "")
                {
                    status = "JOB NOTIFIED";
                    //status = "GM APPROVED";
                }

                if (dt.Rows[intRowBodyCount]["CAND_MSTRID"].ToString() != "")
                {
                    status = "CANDIDATE SELECTED";
                    //status = "GM APPROVED";
                }


                //objEntityManpwrReqmt.ManPwrId = Convert.ToInt32(hiddenManpwrId.Value);

                string strshtlst = objBusinessManpwrReqmt.ReadCountCandShrtlst(objEntityManpwrReqmt);

                if (strshtlst != "0")
                {
                    status = "CANDIDATE SHORTLISTED";
                    StsChk = "8";
                }
                string strintrvw = objBusinessManpwrReqmt.ReadCountIntrvwPrcs(objEntityManpwrReqmt);

                if (strintrvw != "0")
                {
                    status = "INTERVIEW DONE";
                    StsChk = "8";
                }


                if (dt.Rows[intRowBodyCount]["REJECT_STATUS"].ToString() == "1")
                {
                    status = "REJECTED";
                }
            }
            if (sts == "6")
            {
                status = "CANDIDATE SELECTION";
            }
            if (sts == "7")

                status = "CLOSED";

            if ((DdlStatus.Text != "--SELECT STATUS--"))
            {
                if (DdlStatus.Text == status)
                {
                   
                }
            }
            else
            {
               
            }

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {



                //strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + status + "</td>";

                if ((DdlStatus.Text != "--SELECT STATUS--"))
                {
                    if (DdlStatus.Text == status)
                    {

                        if (dt.Rows.Count == 0)
                        {
                           
                        }
                        else if (dt.Rows.Count > 0)
                        {
                            string strId = dt.Rows[intRowBodyCount][0].ToString();
                            hiddenManpwrId.Value = strId;
                            if (intColumnBodyCount == 1)
                            {
                                Ref = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper();
                            }
                            if (intColumnBodyCount == 2)
                            {
                                DateTime ApprovedDate = Convert.ToDateTime(dt.Rows[intRowBodyCount][intColumnBodyCount]).Date;
                                string dateString = ApprovedDate.ToShortDateString();

                                //DateTime ApprovedDate1 = ApprovedDate.Date;
                                ApproveDate = dateString;
                            }
                            if (intColumnBodyCount == 3)
                            {
                                Department = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper();
                            }
                            if (intColumnBodyCount == 4)
                            {
                                Dvsn = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper();
                            }
                            if (intColumnBodyCount == 5)
                            {
                                Designation = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper();
                            }
                            if (intColumnBodyCount == 6)
                            {
                                pjt = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper();
                            }
                            if (intColumnBodyCount == 7)
                            {
                                No_of_Resources = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper();
                            }
                            if (intColumnBodyCount == 8)//Status

                                mnsts = status;



                            if (intColumnBodyCount == 9)//Aging
                            {
                                DateTime DtTody = DateTime.Now;
                                DateTime DtApproved = Convert.ToDateTime(dt.Rows[intRowBodyCount]["APPROVED DATE"]);
                                TimeSpan age = DtTody - DtApproved;
                                int aa = age.Days;

                                aging = aa.ToString();
                            }
                            if (intColumnBodyCount == 10)//Requested By
                            {
                                string FName = dt.Rows[intRowBodyCount]["EMPERDTL_FNAME"].ToString().ToUpper();
                                string MName = dt.Rows[intRowBodyCount]["EMPERDTL_MNAME"].ToString().ToUpper();
                                string Lname = dt.Rows[intRowBodyCount]["REQUESTED BY"].ToString().ToUpper();
                                string FullName = FName + " " + MName + " " + Lname;
                                RequestedBy = FullName;
                            }
                        }
                        // strHtml += "</tr>";

                    }    //MoreInfo
                }
                else
                {
                    //  strHtml += "<tr  >";
                    if (dt.Rows.Count == 0)
                    {
                    }
                    else if (dt.Rows.Count > 0)
                    {
                        string strId = dt.Rows[intRowBodyCount][0].ToString();
                        hiddenManpwrId.Value = strId;
                        if (intColumnBodyCount == 1)
                        {
                            Ref = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper();
                        }
                        if (intColumnBodyCount == 2)
                        {
                            DateTime ApprovedDate = Convert.ToDateTime(dt.Rows[intRowBodyCount][intColumnBodyCount]).Date;
                            string dateString = ApprovedDate.ToShortDateString();

                            //DateTime ApprovedDate1 = ApprovedDate.Date;
                            ApproveDate = dateString;
                        }
                        if (intColumnBodyCount == 3)
                        {
                            Department = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper();
                        }
                        if (intColumnBodyCount == 4)
                        {
                            Dvsn = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper();
                        }
                        if (intColumnBodyCount == 5)
                        {
                            Designation = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper();
                        }
                        if (intColumnBodyCount == 6)
                        {
                            pjt = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper();
                        }
                        if (intColumnBodyCount == 7)
                        {
                            No_of_Resources = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper();
                        }
                        if (intColumnBodyCount == 8)//Status
                        {
                            // string sts = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();

                            if (sts == "0")
                            {
                                // status = "NEW";
                            }
                            if (sts == "1")
                            {
                                // status = "REQUEST CREATED";

                            }
                            else if (sts == "2")
                            {
                                // status = "REQUEST APPROVED";

                            }
                            else if (sts == "3")
                            {
                                // status = "HR VERIFIED";
                            }

                            if (sts == "4")
                            {
                                status = "GM APPROVED";

                                if (dt.Rows[intRowBodyCount]["RQALCDTL_ID"].ToString() != "")
                                {
                                    status = "REQUIREMENT ALLOCATED";
                                    //status = "GM APPROVED";
                                }

                                if (dt.Rows[intRowBodyCount]["JBNTFY_ID"].ToString() != "")
                                {
                                    status = "JOB NOTIFIED";
                                    //status = "GM APPROVED";
                                }

                                if (dt.Rows[intRowBodyCount]["CAND_MSTRID"].ToString() != "")
                                {
                                    status = "CANDIDATE SELECTED";
                                    //status = "GM APPROVED";
                                }

                              

                                objEntityManpwrReqmt.ManPwrId = Convert.ToInt32(hiddenManpwrId.Value);

                                string strshtlst = objBusinessManpwrReqmt.ReadCountCandShrtlst(objEntityManpwrReqmt);

                                if (strshtlst != "0")
                                {
                                    status = "CANDIDATE SHORTLISTED";
                                    StsChk = "8";
                                }
                                string strintrvw = objBusinessManpwrReqmt.ReadCountIntrvwPrcs(objEntityManpwrReqmt);

                                if (strintrvw != "0")
                                {
                                    status = "INTERVIEW DONE";
                                    StsChk = "8";
                                }
                            }

                            if (dt.Rows[intRowBodyCount]["REJECT_STATUS"].ToString() == "1")
                            {
                                status = "REJECTED";
                            }

                            if (sts == "6")
                            {
                                status = "CANDIDATE SELECTION";
                            }
                            if (sts == "7")

                                status = "CLOSED";
                            mnsts = status;

                        }


                        if (intColumnBodyCount == 9)//Aging
                        {
                            DateTime DtTody = DateTime.Now;
                            DateTime DtApproved = Convert.ToDateTime(dt.Rows[intRowBodyCount]["APPROVED DATE"]);
                            TimeSpan age = DtTody - DtApproved;
                            int aa = age.Days;

                            aging = aa.ToString();
                        }
                        if (intColumnBodyCount == 10)//Requested By
                        {
                            string FName = dt.Rows[intRowBodyCount]["EMPERDTL_FNAME"].ToString().ToUpper();
                            string MName = dt.Rows[intRowBodyCount]["EMPERDTL_MNAME"].ToString().ToUpper();
                            string Lname = dt.Rows[intRowBodyCount]["REQUESTED BY"].ToString().ToUpper();
                            string FullName = FName + " " + MName + " " + Lname;
                            RequestedBy = FullName;
                        }
                    }
                    //  strHtml += "</tr>";

                }
              
            }

            table.Rows.Add('"' + Ref + '"', '"' + ApproveDate + '"', '"' + Department + '"', '"' + Dvsn + '"', '"' + Designation + '"', '"' + pjt + '"', '"' + No_of_Resources + '"', '"' + mnsts + '"', '"' + aging + '"', '"' + RequestedBy + '"');

                   }

        return table;
    }
}