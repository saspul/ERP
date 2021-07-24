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
using BL_Compzit.BusinessLayer_AWMS;
using EL_Compzit.EntityLayer_AWMS;
using System.IO;
using EL_Compzit;
public partial class HCM_HCM_Reports_hcm_Leave_Management_Report_hcm_Leave_Management_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clsEntity_Leave_Management_Report objEntityManpwrReqmt = new clsEntity_Leave_Management_Report();
            clsBusiness_Leave_Management_Report objBusinessManpwrReqmt = new clsBusiness_Leave_Management_Report();
            BindDdlYears();
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

            DataTable dtDivision = new DataTable();
            dtDivision = objBusinessManpwrReqmt.ReadLeaveTyp(objEntityManpwrReqmt);
            ddlLeavTyp.ClearSelection();
            ddlLeavTyp.Items.Clear();
            if (dtDivision.Rows.Count > 0)
            {
                ddlLeavTyp.DataSource = dtDivision;
                ddlLeavTyp.DataTextField = "LEAVETYP_NAME";
                ddlLeavTyp.DataValueField = "LEAVETYP_ID";
                ddlLeavTyp.DataBind();
            }

            ddlLeavTyp.Items.Insert(0, "--SELECT LEAVE TYPE--");

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




            ddlDiv.Items.Insert(0, "--SELECT DIVISION--");

            //for viewing table


            DataTable dtManpwr = new DataTable();

            dtManpwr = objBusinessManpwrReqmt.ReadLeaveManagementReport(objEntityManpwrReqmt);

            string strHtm = ConvertDataTableToHTML(dtManpwr);
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

    }

    public string ConvertDataTableToHTML(DataTable dt)
    {

        clsEntity_Leave_Management_Report objEntityManpwrReqmt = new clsEntity_Leave_Management_Report();
        clsBusiness_Leave_Management_Report objBusinessManpwrReqmt = new clsBusiness_Leave_Management_Report();

     
        clsCommonLibrary objCommon = new clsCommonLibrary();
        // string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";



        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";


        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE</th>";


        strHtml += "<th class=\"thT\" style=\"width:25%;text-align: left; word-wrap:break-word;\">DIVISION</th>";


        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">LEAVE TYPE</th>";


        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: right; word-wrap:break-word;\">TOTAL LEAVES</th>";

        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: right; word-wrap:break-word;\">LEAVES TAKEN</th>";


        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: right; word-wrap:break-word;\">AVAILABLE LEAVES</th>";






       


        strHtml += "</tr>";


        strHtml += "</thead>";
        //add rows
        int innertable = 0;
        strHtml += "<tbody>";
        clsBusiness_Leave_Type objBusinessLeave_Type = new clsBusiness_Leave_Type();
        clsEntity_Leave_Type objEntityLeave_Type = new clsEntity_Leave_Type();
        DataTable dtExpDtls = objBusinessLeave_Type.ReadExperienceByID(objEntityLeave_Type);
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
           // strHtml += "<tr  >";


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            hiddenManpwrId.Value = strId;

            string status = "";
            string StsChk = "";
            //for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            //{
                int selctdCount = 0;
                clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
                clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
                string UsrJoinDate = "";
                decimal ExpYears = 0;
                int ExpChck = 0;
                UsrJoinDate = dt.Rows[intRowBodyCount]["EMP_JOINED_DATE"].ToString();
               
                if (UsrJoinDate != "")
                {

                    DateTime Dob = objCommon.textToDateTime(UsrJoinDate);
                    //ExpYears = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
                    ExpYears = (DateTime.Now.Month - Dob.Month) + 12 * (DateTime.Now.Year - Dob.Year);
                    ExpYears = ExpYears / 12;
                    for (int intRowCount = 0; intRowCount < dtExpDtls.Rows.Count; intRowCount++)
                    {
                        int intMinYear = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["EXPMASTR_MIN_YEAR"]);
                        int intMaxYear = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["EXPMASTR_MAX_YEAR"]);
                        if (ExpYears >= intMinYear && ExpYears <= intMaxYear)
                        {
                            ExpChck = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["LEAVDTLS_EXPMASTR_ID"]);
                        }
                    }

                    //if (ExpYears != 0)
                    //{
                    //    if (ExpYears >= 0 && ExpYears <= 2)
                    //    {
                    //        ExpChck = 1;
                    //    }
                    //    else if (ExpYears >= 2 && ExpYears <= 4)
                    //    {
                    //        ExpChck = 2;
                    //    }
                    //    else if (ExpYears >= 4 && ExpYears <= 6)
                    //    {
                    //        ExpChck = 3;
                    //    }
                    //    else if (ExpYears >= 6 && ExpYears <= 8)
                    //    {
                    //        ExpChck = 4;
                    //    }
                    //    else if (ExpYears >= 8 && ExpYears <= 10)
                    //    {
                    //        ExpChck = 5;
                    //    }
                    //    else if (ExpYears >= 10 && ExpYears <= 15)
                    //    {
                    //        ExpChck = 6;
                    //    }

                    //    else if (ExpYears >= 15 && ExpYears <= 20)
                    //    {
                    //        ExpChck = 7;
                    //    }
                    //}
                }




                objEntLevAllocn.EmployeeId = Convert.ToInt32(strId);
                DataTable DtLevAlloDetails = new DataTable();
                DtLevAlloDetails = objBusLevAllocn.ReadLeavTypdtl(objEntLevAllocn, ExpChck);
                selctdCount = DtLevAlloDetails.Rows.Count;

                if (ddlLeavTyp.SelectedItem.Value != "--SELECT LEAVE TYPE--")
                {
                    string Levid = ddlLeavTyp.SelectedItem.Value;
                    for (int i = DtLevAlloDetails.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow dr = DtLevAlloDetails.Rows[i];
                        string a = dr["LEAVETYP_ID"].ToString();
                        if (a != Levid)
                            dr.Table.Rows.Remove(dr);
                    }

                }
            
             objEntityManpwrReqmt.User_Id = Convert.ToInt32(dt.Rows[intRowBodyCount]["USR_ID"].ToString());

               DataTable dtdIVISION = new DataTable();

               dtdIVISION = objBusinessManpwrReqmt.READ_DIVISION_BYEMPID(objEntityManpwrReqmt);
            string Strdivion="";

            int divCheck=0;
               if (dtdIVISION.Rows.Count>0)
               {
                   foreach (DataRow dr in dtdIVISION.Rows)
                   {
                       if (Strdivion == "")
                           Strdivion = dr["CPRDIV_NAME"].ToString().ToUpper();
                       else
                           Strdivion = Strdivion + "," + dr["CPRDIV_NAME"].ToString().ToUpper();
                       if (ddlDiv.SelectedItem.Value != "--SELECT DIVISION--")
                       {
                           string Divid = ddlDiv.SelectedItem.Value;
                           string ddldivId=dr["CPRDIV_ID"].ToString();
                           if (Divid == ddldivId)
                               divCheck = 1;
                           
                              
                       }

                   }

               }

               if (ddlDiv.SelectedItem.Value != "--SELECT DIVISION--")
               {
                   if (divCheck==0)
                    DtLevAlloDetails.Rows.Clear();
               }

          
        
                    for (int intRowBodyCount1 = 0; intRowBodyCount1 < DtLevAlloDetails.Rows.Count; intRowBodyCount1++)
                    {
                        objEntityManpwrReqmt.LeaveTypeMasterId =Convert.ToInt32(DtLevAlloDetails.Rows[intRowBodyCount1]["LEAVETYP_ID"].ToString());
                        objEntityManpwrReqmt.NoOfDays = Convert.ToInt32(ddlYear.SelectedItem.Value);
                       
                        DataTable dtManpwr = new DataTable();

                        dtManpwr = objBusinessManpwrReqmt.ReadTotalNumLeavesTaken(objEntityManpwrReqmt);
                        decimal DopeningLeav = 0;
                        decimal DLeavTaken = 0;
                        decimal DbalaceLeave = 0;
                        if (dtManpwr.Rows.Count > 0)
                        {
                            if (dtManpwr.Rows[0]["OPENING_NUMLEAVE"].ToString() != "")
                                DopeningLeav = Convert.ToDecimal(dtManpwr.Rows[0]["OPENING_NUMLEAVE"].ToString());

                            if (dtManpwr.Rows[0]["BALANCE_NUMLEAVE"].ToString() != "")
                                DbalaceLeave = Convert.ToDecimal(dtManpwr.Rows[0]["BALANCE_NUMLEAVE"].ToString());

                            DLeavTaken = DopeningLeav - DbalaceLeave;

                            

                        }

                        string LeavTypName="";
                           string NumDays="";
                           if (DtLevAlloDetails.Rows.Count > 0)
                        {
                            LeavTypName = DtLevAlloDetails.Rows[intRowBodyCount1]["LEAVETYP_NAME"].ToString().ToUpper();
                          NumDays=     DtLevAlloDetails.Rows[intRowBodyCount1]["LEAVETYP_NUMDAYS"].ToString().ToUpper();
                        }
                        //if (intRowBodyCount1 != 0)
                        //{
                            strHtml += "<tr>";
                            
                       // }
                            innertable = 1;

                            if (DLeavTaken == 0)
                            {
                                if (NumDays!="")
                                DbalaceLeave = Convert.ToDecimal(NumDays);
                            }


                            strHtml += "<td class=\"tdT\"  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString().ToUpper() + "</td>";

                            strHtml += "<td class=\"tdT\"  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_NAME"].ToString().ToUpper() + "</td>";

                            strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + Strdivion + "</td>";


                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + LeavTypName + "</td>";
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + NumDays + "</td>";
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + DLeavTaken + "</td>";
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + DbalaceLeave + "</td>";

                        strHtml += "</tr>";
                    }
           

        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
    }



    // It build the Html table by using the datatable provided
        public string ConvertDataTableForPrint(DataTable dt, DataTable dtCorp)
    {
     //   clsEntityManpwr_Process_Report objEntityManpwrReqmt = new clsEntityManpwr_Process_Report();
        //ClsBusiness_HCM_Reports objBusinessManpwrReqmt = new ClsBusiness_HCM_Reports();


        clsEntity_Leave_Management_Report objEntityManpwrReqmt = new clsEntity_Leave_Management_Report();
        clsBusiness_Leave_Management_Report objBusinessManpwrReqmt = new clsBusiness_Leave_Management_Report();


        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Leave Management Report";
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

        string strFrom = "";

        strFrom = "<tr>Year : " + ddlYear.SelectedItem.Text + "<br/></tr>";
        
        string strTo = "";

     

        string strdept = "";
        if (ddlDepartmnt.SelectedItem.Text.ToString() == "--SELECT DEPARTMENT--")
        {
            strdept = "";
        }
        else
        {
            strdept = "<tr>Department : " + ddlDepartmnt.SelectedItem.Text.ToString() + "<br/></tr>";
        }
    
    
        string strProject = "";
        if (ddlDiv.SelectedItem.Text.ToString() == "--SELECT DIVISION--")
        {
            strProject = "";
        }
        else
        {
            strProject = "<tr>Division : " + ddlDiv.SelectedItem.Text.ToString() + "<br/></tr>";
        }

               string strLeavtyp = "";
        if (ddlLeavTyp.SelectedItem.Text.ToString() == "--SELECT LEAVE TYPE--")
        {
            strLeavtyp = "";
        }
        else
        {
            strLeavtyp = "<tr>Leave Type : " + ddlLeavTyp.SelectedItem.Text.ToString() + "<br/></tr>";
        }
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate +strUsrName+ strCaptionTabTitle + strCaptionTabstop + strFrom + strTo + strdept  + strProject+strLeavtyp;

        sbCap.Append(strPrintCaptionTable);
        //write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
      //  add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";
      
       
        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";


        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE</th>";


        strHtml += "<th class=\"thT\" style=\"width:25%;text-align: left; word-wrap:break-word;\">DIVISION</th>";


        strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">LEAVE TYPE</th>";


        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: right; word-wrap:break-word;\">TOTA LEAVES</th>";

        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: right; word-wrap:break-word;\">LEAVES TAKEN</th>";


        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: right; word-wrap:break-word;\">AVAILABLE LEAVES</th>";






        strHtml += "</tr>";

        strHtml += "</thead>";
       // add rows

        strHtml += "<tbody>";
        if (dt.Rows.Count == 0)
        {
            strHtml += "<tr  ><td  class=\"thT\" colspan=\"9\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td></tr>";
        }
        else
        {
            int ToCheckRows = 0;
            clsBusiness_Leave_Type objBusinessLeave_Type = new clsBusiness_Leave_Type();
            clsEntity_Leave_Type objEntityLeave_Type = new clsEntity_Leave_Type();
            DataTable dtExpDtls = objBusinessLeave_Type.ReadExperienceByID(objEntityLeave_Type);
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                // strHtml += "<tr  >";


                string strId = dt.Rows[intRowBodyCount][0].ToString();
                hiddenManpwrId.Value = strId;

                string status = "";
                string StsChk = "";
                //for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                //{
                int selctdCount = 0;
                clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
                clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
                string UsrJoinDate = "";
                decimal ExpYears = 0;
                int ExpChck = 0;
                UsrJoinDate = dt.Rows[intRowBodyCount]["EMP_JOINED_DATE"].ToString();
             
                if (UsrJoinDate != "")
                {

                    DateTime Dob = objCommon.textToDateTime(UsrJoinDate);
                    //ExpYears = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
                    ExpYears = (DateTime.Now.Month - Dob.Month) + 12 * (DateTime.Now.Year - Dob.Year);
                    ExpYears = ExpYears / 12;
                    for (int intRowCount = 0; intRowCount < dtExpDtls.Rows.Count; intRowCount++)
                    {
                        int intMinYear = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["EXPMASTR_MIN_YEAR"]);
                        int intMaxYear = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["EXPMASTR_MAX_YEAR"]);
                        if (ExpYears >= intMinYear && ExpYears <= intMaxYear)
                        {
                            ExpChck = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["LEAVDTLS_EXPMASTR_ID"]);
                        }
                    }
                    //if (ExpYears != 0)
                    //{
                    //    if (ExpYears >= 0 && ExpYears <= 2)
                    //    {
                    //        ExpChck = 1;
                    //    }
                    //    else if (ExpYears >= 2 && ExpYears <= 4)
                    //    {
                    //        ExpChck = 2;
                    //    }
                    //    else if (ExpYears >= 4 && ExpYears <= 6)
                    //    {
                    //        ExpChck = 3;
                    //    }
                    //    else if (ExpYears >= 6 && ExpYears <= 8)
                    //    {
                    //        ExpChck = 4;
                    //    }
                    //    else if (ExpYears >= 8 && ExpYears <= 10)
                    //    {
                    //        ExpChck = 5;
                    //    }
                    //    else if (ExpYears >= 10 && ExpYears <= 15)
                    //    {
                    //        ExpChck = 6;
                    //    }

                    //    else if (ExpYears >= 15 && ExpYears <= 20)
                    //    {
                    //        ExpChck = 7;
                    //    }

                    //}
                }

                objEntLevAllocn.EmployeeId = Convert.ToInt32(strId);
                DataTable DtLevAlloDetails = new DataTable();
                DtLevAlloDetails = objBusLevAllocn.ReadLeavTypdtl(objEntLevAllocn, ExpChck);
                selctdCount = DtLevAlloDetails.Rows.Count;

                if (ddlLeavTyp.SelectedItem.Value != "--SELECT LEAVE TYPE--")
                {
                    string Levid = ddlLeavTyp.SelectedItem.Value;
                    for (int i = DtLevAlloDetails.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow dr = DtLevAlloDetails.Rows[i];
                        string a = dr["LEAVETYP_ID"].ToString();
                        if (a != Levid)
                            dr.Table.Rows.Remove(dr);
                    }

                }

                objEntityManpwrReqmt.User_Id = Convert.ToInt32(dt.Rows[intRowBodyCount]["USR_ID"].ToString());

                DataTable dtdIVISION = new DataTable();

                dtdIVISION = objBusinessManpwrReqmt.READ_DIVISION_BYEMPID(objEntityManpwrReqmt);
                string Strdivion = "";

                int divCheck = 0;
                if (dtdIVISION.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtdIVISION.Rows)
                    {
                        if (Strdivion == "")
                            Strdivion = dr["CPRDIV_NAME"].ToString().ToUpper();
                        else
                            Strdivion = Strdivion + "," + dr["CPRDIV_NAME"].ToString().ToUpper();
                        if (ddlDiv.SelectedItem.Value != "--SELECT DIVISION--")
                        {
                            string Divid = ddlDiv.SelectedItem.Value;
                            string ddldivId = dr["CPRDIV_ID"].ToString();
                            if (Divid == ddldivId)
                                divCheck = 1;


                        }

                    }

                }

                if (ddlDiv.SelectedItem.Value != "--SELECT DIVISION--")
                {
                    if (divCheck == 0)
                        DtLevAlloDetails.Rows.Clear();
                }



                for (int intRowBodyCount1 = 0; intRowBodyCount1 < DtLevAlloDetails.Rows.Count; intRowBodyCount1++)
                {
                    objEntityManpwrReqmt.LeaveTypeMasterId = Convert.ToInt32(DtLevAlloDetails.Rows[intRowBodyCount1]["LEAVETYP_ID"].ToString());
                    objEntityManpwrReqmt.NoOfDays = Convert.ToInt32(ddlYear.SelectedItem.Value);

                    DataTable dtManpwr = new DataTable();

                    dtManpwr = objBusinessManpwrReqmt.ReadTotalNumLeavesTaken(objEntityManpwrReqmt);
                    decimal DopeningLeav = 0;
                    decimal DLeavTaken = 0;
                    decimal DbalaceLeave = 0;
                    if (dtManpwr.Rows.Count > 0)
                    {
                        if (dtManpwr.Rows[0]["OPENING_NUMLEAVE"].ToString() != "")
                            DopeningLeav = Convert.ToDecimal(dtManpwr.Rows[0]["OPENING_NUMLEAVE"].ToString());

                        if (dtManpwr.Rows[0]["BALANCE_NUMLEAVE"].ToString() != "")
                            DbalaceLeave = Convert.ToDecimal(dtManpwr.Rows[0]["BALANCE_NUMLEAVE"].ToString());

                        DLeavTaken = DopeningLeav - DbalaceLeave;



                    }

                    string LeavTypName = "";
                    string NumDays = "";
                    if (DtLevAlloDetails.Rows.Count > 0)
                    {
                        LeavTypName = DtLevAlloDetails.Rows[intRowBodyCount1]["LEAVETYP_NAME"].ToString().ToUpper();
                        NumDays = DtLevAlloDetails.Rows[intRowBodyCount1]["LEAVETYP_NUMDAYS"].ToString().ToUpper();
                    }
                    //if (intRowBodyCount1 != 0)
                    //{
                    strHtml += "<tr>";

                    // }


                    if (DLeavTaken == 0)
                    {
                        if (NumDays != "")
                            DbalaceLeave = Convert.ToDecimal(NumDays);
                    }

                    ToCheckRows = 1;
                    strHtml += "<td class=\"tdT\"  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString().ToUpper() + "</td>";

                    strHtml += "<td class=\"tdT\"  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_NAME"].ToString().ToUpper() + "</td>";

                    strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + Strdivion + "</td>";


                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + LeavTypName + "</td>";
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + NumDays + "</td>";
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + DLeavTaken + "</td>";
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + DbalaceLeave + "</td>";

                    strHtml += "</tr>";
                }
                


            }
            if (ToCheckRows == 0)
            {
                strHtml += "<tr  ><td  class=\"thT\" colspan=\"9\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td></tr>";
            }
        }

        strHtml += "</tbody>";
        strHtml += "</table>";

        sb.Append(strHtml);
      //  write to divPrintReport
        return sb.ToString();
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
          DataTable dtDiv=  objBusinessManpwrReqmt.ReadDivision(objEntityManpwrReqmt);
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsEntity_Leave_Management_Report objEntityManpwrReqmt = new clsEntity_Leave_Management_Report();
        clsBusiness_Leave_Management_Report objBusinessManpwrReqmt = new clsBusiness_Leave_Management_Report();
        int intUserId = 0, intUsrRolMstrId, intEnableHRallocation = 0, intCorpId = 0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
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

        if (ddlDiv.SelectedItem.Value != "--SELECT DIVISION--")
        {
            objEntityManpwrReqmt.DivId = Convert.ToInt32(ddlDiv.SelectedItem.Value);

        }
        if (ddlDepartmnt.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntityManpwrReqmt.DepId = Convert.ToInt32(ddlDepartmnt.SelectedItem.Value);

        }

       
        // hiddenAssignedTo.Value = objEntityReqrmntAlctn.Employee_Id.ToString();


        DataTable dtManpwr = new DataTable();
      
        dtManpwr = objBusinessManpwrReqmt.ReadLeaveManagementReport(objEntityManpwrReqmt);

        string strHtm = ConvertDataTableToHTML(dtManpwr);
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
        clsEntity_Leave_Management_Report objEntityManpwrReqmt = new clsEntity_Leave_Management_Report();
        clsBusiness_Leave_Management_Report objBusinessManpwrReqmt = new clsBusiness_Leave_Management_Report();
        int intUserId = 0, intUsrRolMstrId, intEnableHRallocation = 0, intCorpId = 0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
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

        if (ddlDiv.SelectedItem.Value != "--SELECT DIVISION--")
        {
            objEntityManpwrReqmt.DivId = Convert.ToInt32(ddlDiv.SelectedItem.Value);

        }
        if (ddlDepartmnt.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntityManpwrReqmt.DepId = Convert.ToInt32(ddlDepartmnt.SelectedItem.Value);
        }
        DataTable dt = new DataTable();
        dt = objBusinessManpwrReqmt.ReadLeaveManagementReport(objEntityManpwrReqmt);
        DataTable table = new DataTable();
        table.Columns.Add("EMPLOYEE ID", typeof(string));
        table.Columns.Add("EMPLOYEE", typeof(string));
        table.Columns.Add("DIVISION", typeof(string));
        table.Columns.Add("LEAVE TYPE", typeof(string));
        table.Columns.Add("TOTAL LEAVES", typeof(string));
        table.Columns.Add("LEAVES TAKEN", typeof(string));
        table.Columns.Add("AVAILABLE LEAVES", typeof(string));
        //add rows
        int innertable = 0;
        clsBusiness_Leave_Type objBusinessLeave_Type = new clsBusiness_Leave_Type();
        clsEntity_Leave_Type objEntityLeave_Type = new clsEntity_Leave_Type();
        DataTable dtExpDtls = objBusinessLeave_Type.ReadExperienceByID(objEntityLeave_Type);
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string EMPID = "";
            string EMP = "";
            string DIVISION = "";
            string LVTYPE = "";
            string TOTALLVE = "";
            string TAKEN = "";
            string AVALIABLE = "";
            string strId = dt.Rows[intRowBodyCount][0].ToString();
            hiddenManpwrId.Value = strId;
            string status = "";
            string StsChk = "";
            int selctdCount = 0;
            clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
            clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
            string UsrJoinDate = "";
            decimal ExpYears = 0;
            int ExpChck = 0;
            UsrJoinDate = dt.Rows[intRowBodyCount]["EMP_JOINED_DATE"].ToString();
          
            if (UsrJoinDate != "")
            {
                DateTime Dob = objCommon.textToDateTime(UsrJoinDate);
                ExpYears = (DateTime.Now.Month - Dob.Month) + 12 * (DateTime.Now.Year - Dob.Year);
                ExpYears = ExpYears / 12;
                for (int intRowCount = 0; intRowCount < dtExpDtls.Rows.Count; intRowCount++)
                {
                    int intMinYear = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["EXPMASTR_MIN_YEAR"]);
                    int intMaxYear = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["EXPMASTR_MAX_YEAR"]);
                    if (ExpYears >= intMinYear && ExpYears <= intMaxYear)
                    {
                        ExpChck = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["LEAVDTLS_EXPMASTR_ID"]);
                    }
                }
            }

            objEntLevAllocn.EmployeeId = Convert.ToInt32(strId);
            DataTable DtLevAlloDetails = new DataTable();
            DtLevAlloDetails = objBusLevAllocn.ReadLeavTypdtl(objEntLevAllocn, ExpChck);
            selctdCount = DtLevAlloDetails.Rows.Count;

            if (ddlLeavTyp.SelectedItem.Value != "--SELECT LEAVE TYPE--")
            {
                string Levid = ddlLeavTyp.SelectedItem.Value;
                for (int i = DtLevAlloDetails.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = DtLevAlloDetails.Rows[i];
                    string a = dr["LEAVETYP_ID"].ToString();
                    if (a != Levid)
                        dr.Table.Rows.Remove(dr);
                }

            }

            objEntityManpwrReqmt.User_Id = Convert.ToInt32(dt.Rows[intRowBodyCount]["USR_ID"].ToString());

            DataTable dtdIVISION = new DataTable();

            dtdIVISION = objBusinessManpwrReqmt.READ_DIVISION_BYEMPID(objEntityManpwrReqmt);
            string Strdivion = "";

            int divCheck = 0;
            if (dtdIVISION.Rows.Count > 0)
            {
                foreach (DataRow dr in dtdIVISION.Rows)
                {
                    if (Strdivion == "")
                        Strdivion = dr["CPRDIV_NAME"].ToString().ToUpper();
                    else
                        Strdivion = Strdivion + "," + dr["CPRDIV_NAME"].ToString().ToUpper();
                    if (ddlDiv.SelectedItem.Value != "--SELECT DIVISION--")
                    {
                        string Divid = ddlDiv.SelectedItem.Value;
                        string ddldivId = dr["CPRDIV_ID"].ToString();
                        if (Divid == ddldivId)
                            divCheck = 1;


                    }

                }

            }

            if (ddlDiv.SelectedItem.Value != "--SELECT DIVISION--")
            {
                if (divCheck == 0)
                    DtLevAlloDetails.Rows.Clear();
            }



            for (int intRowBodyCount1 = 0; intRowBodyCount1 < DtLevAlloDetails.Rows.Count; intRowBodyCount1++)
            {
                objEntityManpwrReqmt.LeaveTypeMasterId = Convert.ToInt32(DtLevAlloDetails.Rows[intRowBodyCount1]["LEAVETYP_ID"].ToString());
                objEntityManpwrReqmt.NoOfDays = Convert.ToInt32(ddlYear.SelectedItem.Value);

                DataTable dtManpwr = new DataTable();

                dtManpwr = objBusinessManpwrReqmt.ReadTotalNumLeavesTaken(objEntityManpwrReqmt);
                decimal DopeningLeav = 0;
                decimal DLeavTaken = 0;
                decimal DbalaceLeave = 0;
                if (dtManpwr.Rows.Count > 0)
                {
                    if (dtManpwr.Rows[0]["OPENING_NUMLEAVE"].ToString() != "")
                        DopeningLeav = Convert.ToDecimal(dtManpwr.Rows[0]["OPENING_NUMLEAVE"].ToString());

                    if (dtManpwr.Rows[0]["BALANCE_NUMLEAVE"].ToString() != "")
                        DbalaceLeave = Convert.ToDecimal(dtManpwr.Rows[0]["BALANCE_NUMLEAVE"].ToString());

                    DLeavTaken = DopeningLeav - DbalaceLeave;



                }

                string LeavTypName = "";
                string NumDays = "";
                if (DtLevAlloDetails.Rows.Count > 0)
                {
                    LeavTypName = DtLevAlloDetails.Rows[intRowBodyCount1]["LEAVETYP_NAME"].ToString().ToUpper();
                    NumDays = DtLevAlloDetails.Rows[intRowBodyCount1]["LEAVETYP_NUMDAYS"].ToString().ToUpper();
                }
                innertable = 1;

                if (DLeavTaken == 0)
                {
                    if (NumDays != "")
                        DbalaceLeave = Convert.ToDecimal(NumDays);
                }


                EMPID= dt.Rows[intRowBodyCount]["USR_CODE"].ToString().ToUpper();

                EMP= dt.Rows[intRowBodyCount]["USR_NAME"].ToString().ToUpper();

                DIVISION= Strdivion;


                LVTYPE= LeavTypName;
                TOTALLVE= NumDays;
                TAKEN = Convert.ToString(DLeavTaken) ;
               AVALIABLE= Convert.ToString(DbalaceLeave);
               table.Rows.Add('"' + EMPID + '"', '"' + EMP + '"', '"' + DIVISION + '"', '"' + LVTYPE + '"', '"' + TOTALLVE + '"', '"' + TAKEN + '"', '"' + AVALIABLE + '"');

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
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.LEAVE_MNGMNT_RPRT_CSV);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
            string newFilePath = Server.MapPath("/CustomFiles/HCM CSV/Leave Management/Leave_Management_Report_" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "Leave_Management_Report_" + strNextId + ".csv";
            Response.ContentType = "csv";
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.LEAVE_MNGMNT_RPRT_CSV);
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