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
// CREATED DATE:15/07/2017
// REVIEWED BY:
// REVIEW DATE:
public partial class HCM_HCM_Reports_hcm_OnBoarding_Status_Report_hcm_OnBoarding_Status_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            clsEntityOnBoarding_Status_Report objEntityOnBoarding_Status = new clsEntityOnBoarding_Status_Report();
            clsBusinessLayer_OnBoard_Status_Report objBusinessOnBoarding_Status = new clsBusinessLayer_OnBoard_Status_Report();

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


            DataTable dtCandidateDtls = new DataTable();
            dtCandidateDtls = objBusinessOnBoarding_Status.ReadCandidateDtls(objEntityOnBoarding_Status);

            string strHtm = ConvertDataTableToHTML(dtCandidateDtls);
            divReport.InnerHtml = strHtm;

            //for printing

            DataTable dtCorp = new DataTable();
            dtCorp = objBusinessOnBoarding_Status.ReadCorporateAddress(objEntityOnBoarding_Status);

            string strprint = ConvertDataTableForPrint(dtCandidateDtls, dtCorp);
            divPrintReport.InnerHtml = strprint;

        }

    }

        


    protected void btnSearch_Click(object sender, EventArgs e)
    {

        clsEntityOnBoarding_Status_Report objEntityOnBoarding_Status = new clsEntityOnBoarding_Status_Report();
        clsBusinessLayer_OnBoard_Status_Report objBusinessOnBoarding_Status = new clsBusinessLayer_OnBoard_Status_Report();

        if (ddlManPower.SelectedItem.Value != "--SELECT MANPOWER--")
        {
            objEntityOnBoarding_Status.ManPwrId = Convert.ToInt32(ddlManPower.SelectedItem.Value);
        }

        objEntityOnBoarding_Status.CorpId = Convert.ToInt32(hiddenCorpId.Value);
        objEntityOnBoarding_Status.OrgId = Convert.ToInt32(hiddenOrgId.Value);

        DataTable dtCandidateDtls = new DataTable();
        dtCandidateDtls = objBusinessOnBoarding_Status.ReadCandidateDtls(objEntityOnBoarding_Status);

        string strHtm = ConvertDataTableToHTML(dtCandidateDtls);
        divReport.InnerHtml = strHtm;

        //for printing

        DataTable dtCorp = new DataTable();
        dtCorp = objBusinessOnBoarding_Status.ReadCorporateAddress(objEntityOnBoarding_Status);

        string strprint = ConvertDataTableForPrint(dtCandidateDtls, dtCorp);
        divPrintReport.InnerHtml = strprint;

    }


    public string ConvertDataTableToHTML(DataTable dt)
    {
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
            //if (i == 0)
            //{
            //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
            //}
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:35%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
        }

        strHtml += "<th class=\"thT\" style=\"width:15%; word-wrap:break-word;text-align: center;\">MORE INFO</th>";

        
        strHtml += "</tr>";


        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr  >";


            string strId = dt.Rows[intRowBodyCount][0].ToString();

            string reference = "";

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                //if (j == 0)
                //{
                //    int intCnt = i + 1;
                //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                //}

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:35%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 3)
                {
                    if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "1")
                    {
                        reference = "CONSULTANCY";
                    }
                    else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "2")
                    {
                        reference = "DIVISION";
                    }
                    else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "3")
                    {
                        reference = "DEPARTMENT";
                    }
                    else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "4")
                    {
                        reference = "EMPLOYEE";
                    }

                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + reference + "</td>";
                }

                if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
            }

            strHtml += "<td class=\"tdT\" style=\"width:15%; word-wrap:break-word;text-align: center;\"><input type=\"button\" class=\"save\" style=\"height:22px;margin-top:3%\" value=\"More Info\" onclick=\"return OpenOnBoardingDetails('" + strId + "');\" /></td>";


            strHtml += "</tr>";

            
        }


        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
    }


    [WebMethod]
    public static string[] OnBoardingDetails(string strCandidateId)
    {

        string[] strJson = new string[30];

        clsEntityOnBoarding_Status_Report objEntityOnBoarding_Status = new clsEntityOnBoarding_Status_Report();
        clsBusinessLayer_OnBoard_Status_Report objBusinessOnBoarding_Status = new clsBusinessLayer_OnBoard_Status_Report();

        objEntityOnBoarding_Status.CandidtId = Convert.ToInt32(strCandidateId);

        DataTable dtCandidateDtlsId = new DataTable();
        dtCandidateDtlsId = objBusinessOnBoarding_Status.ReadCandidateDtls_ById(objEntityOnBoarding_Status);

        strJson[0] = dtCandidateDtlsId.Rows[0]["CAND_NAME"].ToString().ToUpper();
        strJson[1] = dtCandidateDtlsId.Rows[0]["CAND_LOC"].ToString().ToUpper();

        if (dtCandidateDtlsId.Rows[0]["CAND_REF"].ToString() == "1")
        {
            strJson[2] = "CONSULTANCY";
        }
        else if (dtCandidateDtlsId.Rows[0]["CAND_REF"].ToString() == "2")
        {
            strJson[2] = "DIVISION";
        }
        else if (dtCandidateDtlsId.Rows[0]["CAND_REF"].ToString() == "3")
        {
            strJson[2] = "DEPARTMENT";
        }
        else if (dtCandidateDtlsId.Rows[0]["CAND_REF"].ToString() == "4")
        {
            strJson[2] = "EMPLOYEE";
        }


        if (dtCandidateDtlsId.Rows[0]["CAND_VISA"].ToString() == "0")
        {
            strJson[3] = "NO";
        }
        else
        {
            strJson[3] = "YES";
        }

        strJson[4] = dtCandidateDtlsId.Rows[0]["CNTRY_NAME"].ToString();

        DataTable dt = new DataTable();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        strHtml += "<td class=\"thT\" style=\"width:3%;text-align: left; word-wrap:break-word;\">SL#</th>";
        strHtml += "<td class=\"thT\" style=\"width:20%;text-align: center; word-wrap:break-word;\">PARTICULARS</th>";
        strHtml += "<td class=\"thT\"  style=\"width:12%;text-align: center; word-wrap:break-word;\">CATEGORY</th>";
        strHtml += "<td class=\"thT\"  style=\"width:30%;text-align: center; word-wrap:break-word;\">ASSIGNED TO</th>";
        strHtml += "<td class=\"thT\"  style=\"width:23%;text-align: center; word-wrap:break-word;\">STATUS</th>";
        strHtml += "<td class=\"thT\"  style=\"width:12%;text-align: center; word-wrap:break-word;\">TARGET</th>";


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >1</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Visa</td>";

        DataTable dtVisaDtlsId = new DataTable();
        dtVisaDtlsId = objBusinessOnBoarding_Status.ReadVisaDtls_ById(objEntityOnBoarding_Status);

        string[] VisaData = new string[7];
        VisaData[0] = dtVisaDtlsId.Rows[0]["ONBRDDTL_ID"].ToString();
        VisaData[1] = dtVisaDtlsId.Rows[0]["VISA_NAME"].ToString();

        if(dtVisaDtlsId.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "0")
            VisaData[2] = "Job Assigned";
        else if(dtVisaDtlsId.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "1")
            VisaData[2] = "Document Preparartion";
        else if (dtVisaDtlsId.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "2")
            VisaData[2] = "Applied, Awaiting MOI Approval";
        else if (dtVisaDtlsId.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "3")
            VisaData[2] = "MOI Approved, ready to print";
        else if (dtVisaDtlsId.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "4")
            VisaData[2] = "MOI rejected – Close";
        else if (dtVisaDtlsId.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "5")
            VisaData[2] = "MOI Rejected – Reapply";
        else if (dtVisaDtlsId.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "6")
            VisaData[2] = "Visa print complete";

        VisaData[3] = dtVisaDtlsId.Rows[0]["ONBRDDTL_DATE"].ToString();

        objEntityOnBoarding_Status.Candidt_DtlId = Convert.ToInt32(dtVisaDtlsId.Rows[0]["ONBRDDTL_ID"].ToString());
        DataTable dtEmpOnBrdVisa = new DataTable();
        dtEmpOnBrdVisa = objBusinessOnBoarding_Status.ReadEmpOnBoard_ById(objEntityOnBoarding_Status);

        string strEmpVisa = "";
        if (dtEmpOnBrdVisa.Rows.Count > 0)
        {
            foreach (DataRow dtrow in dtEmpOnBrdVisa.Rows)
            {
                strEmpVisa = dtrow["USR_NAME"] + " , " + strEmpVisa;
            }
        }
        VisaData[4] = strEmpVisa.TrimEnd(" , ".ToCharArray());



        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + VisaData[1].ToUpper() + "</td>";
        strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + VisaData[4].ToUpper() + "</td>";
        strHtml += "<td class=\"tdT\" style=\" width:23%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + VisaData[2].ToUpper() + "</td>";
        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + VisaData[3].ToUpper() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >2</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Flight Ticket</td>";

        DataTable dtFlightDtlsId = new DataTable();
        dtFlightDtlsId = objBusinessOnBoarding_Status.ReadFlightDtls_ById(objEntityOnBoarding_Status);

        string[] FlightData = new string[7];
        FlightData[0] = dtFlightDtlsId.Rows[0]["ONBRDDTL_ID"].ToString();

        if (dtFlightDtlsId.Rows[0]["ONBRDDTL_FLIGHT_TYPE"].ToString() == "1")
            FlightData[1] = "ECONOMY CLASS";
        else if (dtFlightDtlsId.Rows[0]["ONBRDDTL_FLIGHT_TYPE"].ToString() == "2")
            FlightData[1] = "BUSSINESS CLASS";
        else if (dtFlightDtlsId.Rows[0]["ONBRDDTL_FLIGHT_TYPE"].ToString() == "3")
            FlightData[1] = "FIRST CLASS";

        if (dtFlightDtlsId.Rows[0]["ONBRDDTL_FLIGHT_STATUS"].ToString() == "0")
            FlightData[2] = "Job Assigned";
        else if (dtFlightDtlsId.Rows[0]["ONBRDDTL_FLIGHT_STATUS"].ToString() == "1")
            FlightData[2] = "Availability Check";
        else if (dtFlightDtlsId.Rows[0]["ONBRDDTL_FLIGHT_STATUS"].ToString() == "2")
            FlightData[2] = "Awaiting, Approval from candidate";
        else if (dtFlightDtlsId.Rows[0]["ONBRDDTL_FLIGHT_STATUS"].ToString() == "3")
            FlightData[2] = "Booking Confirm, ticket copy attach";

        FlightData[3] = dtFlightDtlsId.Rows[0]["ONBRDDTL_DATE"].ToString();

        objEntityOnBoarding_Status.Candidt_DtlId = Convert.ToInt32(dtFlightDtlsId.Rows[0]["ONBRDDTL_ID"].ToString());
        DataTable dtEmpOnBrdFlight = new DataTable();
        dtEmpOnBrdFlight = objBusinessOnBoarding_Status.ReadEmpOnBoard_ById(objEntityOnBoarding_Status);

        string strEmpFlight = "";
        if (dtEmpOnBrdFlight.Rows.Count > 0)
        {
            foreach (DataRow dtrow in dtEmpOnBrdFlight.Rows)
            {
                strEmpFlight = dtrow["USR_NAME"] + " , " + strEmpFlight;
            }
        }
        FlightData[4] = strEmpFlight.TrimEnd(" , ".ToCharArray());

        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + FlightData[1].ToUpper() + "</td>";
        strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + FlightData[4].ToUpper() + "</td>";
        strHtml += "<td class=\"tdT\" style=\" width:23%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + FlightData[2].ToUpper() + "</td>";
        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + FlightData[3].ToUpper() + "</td>";


        strHtml += "</tr>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >3</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Room Allotment</td>";

        DataTable dtRoomDtlsId = new DataTable();
        dtRoomDtlsId = objBusinessOnBoarding_Status.ReadRoomDtls_ById(objEntityOnBoarding_Status);

        string[] RoomData = new string[7];
        RoomData[0] = dtRoomDtlsId.Rows[0]["ONBRDDTL_ID"].ToString();

        if (dtRoomDtlsId.Rows[0]["ONBRDDTL_RMALTMNT_TYP"].ToString() == "1")
            RoomData[1] = "BED SPACE";
        else if (dtRoomDtlsId.Rows[0]["ONBRDDTL_RMALTMNT_TYP"].ToString() == "2")
            RoomData[1] = "1 BHK";
        else if (dtRoomDtlsId.Rows[0]["ONBRDDTL_RMALTMNT_TYP"].ToString() == "3")
            RoomData[1] = "2 BHK";
        else if (dtRoomDtlsId.Rows[0]["ONBRDDTL_RMALTMNT_TYP"].ToString() == "4")
            RoomData[1] = "3 BHK";
        else if (dtRoomDtlsId.Rows[0]["ONBRDDTL_RMALTMNT_TYP"].ToString() == "5")
            RoomData[1] = "VILLA";
        else if (dtRoomDtlsId.Rows[0]["ONBRDDTL_RMALTMNT_TYP"].ToString() == "3")
            RoomData[1] = "FLAT";

        if (dtRoomDtlsId.Rows[0]["ONBRDDTL_ROOM_STATUS"].ToString() == "0")
            RoomData[2] = "Job Assigned";
        else if (dtRoomDtlsId.Rows[0]["ONBRDDTL_ROOM_STATUS"].ToString() == "1")
            RoomData[2] = "Availability Check";
        else if (dtRoomDtlsId.Rows[0]["ONBRDDTL_ROOM_STATUS"].ToString() == "2")
            RoomData[2] = "Facility Procurement";
        else if (dtRoomDtlsId.Rows[0]["ONBRDDTL_ROOM_STATUS"].ToString() == "3")
            RoomData[2] = "Complete";
        else if (dtRoomDtlsId.Rows[0]["ONBRDDTL_ROOM_STATUS"].ToString() == "4")
            RoomData[2] = "Closed Without Allotment";

        RoomData[3] = dtRoomDtlsId.Rows[0]["ONBRDDTL_DATE"].ToString();

        objEntityOnBoarding_Status.Candidt_DtlId = Convert.ToInt32(dtRoomDtlsId.Rows[0]["ONBRDDTL_ID"].ToString());
        DataTable dtEmpOnBrdRoom = new DataTable();
        dtEmpOnBrdRoom = objBusinessOnBoarding_Status.ReadEmpOnBoard_ById(objEntityOnBoarding_Status);

        string strEmpRoom = "";
        if (dtEmpOnBrdRoom.Rows.Count > 0)
        {
            foreach (DataRow dtrow in dtEmpOnBrdRoom.Rows)
            {
                strEmpRoom = dtrow["USR_NAME"] + " , " + strEmpRoom;
            }
        }
        RoomData[4] = strEmpRoom.TrimEnd(" , ".ToCharArray());

        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + RoomData[1].ToUpper() + "</td>";
        strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + RoomData[4].ToUpper() + "</td>";
        strHtml += "<td class=\"tdT\" style=\" width:23%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + RoomData[2].ToUpper() + "</td>";
        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + RoomData[3].ToUpper() + "</td>";

        strHtml += "</tr>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >4</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >AirPort Pickup</td>";

        DataTable dtAirprtDtlsId = new DataTable();
        dtAirprtDtlsId = objBusinessOnBoarding_Status.ReadAirportDtls_ById(objEntityOnBoarding_Status);

        string[] AirprtData = new string[7];
        AirprtData[0] = dtAirprtDtlsId.Rows[0]["ONBRDDTL_ID"].ToString();
        AirprtData[1] = dtAirprtDtlsId.Rows[0]["VHCL_NUMBR"].ToString();

        if (dtAirprtDtlsId.Rows[0]["ONBRDDTL_AIRPT_STATUS"].ToString() == "0")
            AirprtData[2] = "Job Assigned";
        AirprtData[3] = dtRoomDtlsId.Rows[0]["ONBRDDTL_DATE"].ToString();

        objEntityOnBoarding_Status.Candidt_DtlId = Convert.ToInt32(dtAirprtDtlsId.Rows[0]["ONBRDDTL_ID"].ToString());
        DataTable dtEmpOnBrdAirprt = new DataTable();
        dtEmpOnBrdAirprt = objBusinessOnBoarding_Status.ReadEmpOnBoard_ById(objEntityOnBoarding_Status);

        string strEmpAirprt = "";
        if (dtEmpOnBrdAirprt.Rows.Count > 0)
        {
            foreach (DataRow dtrow in dtEmpOnBrdAirprt.Rows)
            {
                strEmpAirprt = dtrow["USR_NAME"] + " , " + strEmpAirprt;
            }
        }
        AirprtData[4] = strEmpAirprt.TrimEnd(" , ".ToCharArray());

        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + AirprtData[1].ToUpper() + "</td>";
        strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + AirprtData[4].ToUpper() + "</td>";
        strHtml += "<td class=\"tdT\" style=\" width:23%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + AirprtData[2].ToUpper() + "</td>";
        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + AirprtData[3].ToUpper() + "</td>";

        strHtml += "</tr>";

        strHtml += "</tbody>";

        strHtml += "</table>";
        sb.Append(strHtml);
        strJson[5] = sb.ToString();



        return strJson;

    }


    //It build the Html table by using the datatable provided
    public string ConvertDataTableForPrint(DataTable dt, DataTable dtCorp)
    {

        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "On Boarding Status Report";
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
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            //if (i == 0)
            //{
            //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
            //}
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:44%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
        }

        if (dt.Columns.Count == 0)
        {
            strHtml += "<td class=\"thT\" style=\"width:50%;text-align: left; word-wrap:break-word;\">CANDIDATE NAME</th>";
            strHtml += "<td class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">LOCATION</th>";
            strHtml += "<td class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">REFERENCE</th>";
            strHtml += "<td class=\"thT\"  style=\"width:20%;text-align: center; word-wrap:break-word;\">NATIONALITY</th>";
        }

        strHtml += "</tr>";

        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr  >";


            string strId = dt.Rows[intRowBodyCount][0].ToString();

            string reference = "";

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                //if (j == 0)
                //{
                //    int intCnt = i + 1;
                //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                //}

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:44%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 3)
                {
                    if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "1")
                    {
                        reference = "CONSULTANCY";
                    }
                    else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "2")
                    {
                        reference = "DIVISION";
                    }
                    else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "3")
                    {
                        reference = "DEPARTMENT";
                    }
                    else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "4")
                    {
                        reference = "EMPLOYEE";
                    }

                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + reference + "</td>";
                }

                if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
            }

            strHtml += "</tr>";
        }

        if (dt.Rows.Count == 0)
        {
            strHtml += "<td  class=\"thT\" colspan=\"8\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
        }


        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        //write to divPrintReport
        return sb.ToString();

    }


    [WebMethod]
    public static string[] OnBoardingDetailsPrint(string strCandidateId,int intCorpId,int intOrgId)
    {

        string[] strJsonPrint = new string[30];

        clsEntityOnBoarding_Status_Report objEntityOnBoarding_Status = new clsEntityOnBoarding_Status_Report();
        clsBusinessLayer_OnBoard_Status_Report objBusinessOnBoarding_Status = new clsBusinessLayer_OnBoard_Status_Report();

        objEntityOnBoarding_Status.CandidtId = Convert.ToInt32(strCandidateId);

        objEntityOnBoarding_Status.CorpId = intCorpId;
        objEntityOnBoarding_Status.OrgId = intOrgId;

        DataTable dtCorp = new DataTable();
        dtCorp = objBusinessOnBoarding_Status.ReadCorporateAddress(objEntityOnBoarding_Status);

        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "On Boarding Status Details";
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


        DataTable dtCandidateDtlsId = new DataTable();
        dtCandidateDtlsId = objBusinessOnBoarding_Status.ReadCandidateDtls_ById(objEntityOnBoarding_Status);

        string[] strJson = new string[30];

        strJson[1] = dtCandidateDtlsId.Rows[0]["CAND_NAME"].ToString();
        strJson[2] = dtCandidateDtlsId.Rows[0]["CAND_LOC"].ToString();

        if (dtCandidateDtlsId.Rows[0]["CAND_REF"].ToString() == "1")
        {
            strJson[3] = "Consultancy";
        }
        else if (dtCandidateDtlsId.Rows[0]["CAND_REF"].ToString() == "2")
        {
            strJson[3] = "Division";
        }
        else if (dtCandidateDtlsId.Rows[0]["CAND_REF"].ToString() == "3")
        {
            strJson[3] = "Department";
        }
        else if (dtCandidateDtlsId.Rows[0]["CAND_REF"].ToString() == "4")
        {
            strJson[3] = "Employee";
        }


        if (dtCandidateDtlsId.Rows[0]["CAND_VISA"].ToString() == "0")
        {
            strJson[4] = "NO";
        }
        else
        {
            strJson[4] = "YES";
        }

        strJson[5] = dtCandidateDtlsId.Rows[0]["CNTRY_NAME"].ToString();


        StringBuilder sbCapCandDtls = new StringBuilder();

        string strCandstart = "<table>";
        string strName = "<tr><td>Name : " + strJson[1] + "<br/></td></tr>";
        string strLocatn = "<tr><td>Location  : " + strJson[2] + "<br/></td></tr>";
        string strRef = "<tr><td>Reference : " + strJson[3] + "<br/></td></tr>";
        string strVisa = "<tr><td>Visa : " + strJson[4] + "<br/></td></tr>";
        string strNation = "<tr><td>Nationality : " + strJson[5] + "<br/></td></tr>";
        string strprint = strCandstart + strName + strLocatn + strRef + strVisa + strNation;

        sbCapCandDtls.Append(strprint);
        //write to  lblPrintOnBrdDtls
        strJsonPrint[1] = sbCapCandDtls.ToString();



        DataTable dt = new DataTable();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";
        strHtml += "<td class=\"thT\" style=\"width:3%;text-align: left; word-wrap:break-word;\">SL#</th>";
        strHtml += "<td class=\"thT\" style=\"width:20%;text-align: center; word-wrap:break-word;\">PARTICULARS</th>";
        strHtml += "<td class=\"thT\"  style=\"width:12%;text-align: center; word-wrap:break-word;\">CATEGORY</th>";
        strHtml += "<td class=\"thT\"  style=\"width:30%;text-align: center; word-wrap:break-word;\">ASSIGNED TO</th>";
        strHtml += "<td class=\"thT\"  style=\"width:23%;text-align: center; word-wrap:break-word;\">STATUS</th>";
        strHtml += "<td class=\"thT\"  style=\"width:12%;text-align: center; word-wrap:break-word;\">TARGET</th>";


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >1</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Visa</td>";

        DataTable dtVisaDtlsId = new DataTable();
        dtVisaDtlsId = objBusinessOnBoarding_Status.ReadVisaDtls_ById(objEntityOnBoarding_Status);

        string[] VisaData = new string[7];
        VisaData[0] = dtVisaDtlsId.Rows[0]["ONBRDDTL_ID"].ToString();
        VisaData[1] = dtVisaDtlsId.Rows[0]["VISA_NAME"].ToString();

        if (dtVisaDtlsId.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "0")
            VisaData[2] = "Job Assigned";
        else if (dtVisaDtlsId.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "1")
            VisaData[2] = "Document Preparartion";
        else if (dtVisaDtlsId.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "2")
            VisaData[2] = "Applied, Awaiting MOI Approval";
        else if (dtVisaDtlsId.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "3")
            VisaData[2] = "MOI Approved, ready to print";
        else if (dtVisaDtlsId.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "4")
            VisaData[2] = "MOI rejected – Close";
        else if (dtVisaDtlsId.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "5")
            VisaData[2] = "MOI Rejected – Reapply";
        else if (dtVisaDtlsId.Rows[0]["ONBRDDTL_VISA_STATUS"].ToString() == "6")
            VisaData[2] = "Visa print complete";

        VisaData[3] = dtVisaDtlsId.Rows[0]["ONBRDDTL_DATE"].ToString();

        objEntityOnBoarding_Status.Candidt_DtlId = Convert.ToInt32(dtVisaDtlsId.Rows[0]["ONBRDDTL_ID"].ToString());
        DataTable dtEmpOnBrdVisa = new DataTable();
        dtEmpOnBrdVisa = objBusinessOnBoarding_Status.ReadEmpOnBoard_ById(objEntityOnBoarding_Status);

        string strEmpVisa = "";
        if (dtEmpOnBrdVisa.Rows.Count > 0)
        {
            foreach (DataRow dtrow in dtEmpOnBrdVisa.Rows)
            {
                strEmpVisa = dtrow["USR_NAME"] + " , " + strEmpVisa;
            }
        }
        VisaData[4] = strEmpVisa.TrimEnd(" , ".ToCharArray());



        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + VisaData[1].ToUpper() + "</td>";
        strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + VisaData[4].ToUpper() + "</td>";
        strHtml += "<td class=\"tdT\" style=\" width:23%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + VisaData[2].ToUpper() + "</td>";
        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + VisaData[3].ToUpper() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >2</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Flight Ticket</td>";

        DataTable dtFlightDtlsId = new DataTable();
        dtFlightDtlsId = objBusinessOnBoarding_Status.ReadFlightDtls_ById(objEntityOnBoarding_Status);

        string[] FlightData = new string[7];
        FlightData[0] = dtFlightDtlsId.Rows[0]["ONBRDDTL_ID"].ToString();

        if (dtFlightDtlsId.Rows[0]["ONBRDDTL_FLIGHT_TYPE"].ToString() == "1")
            FlightData[1] = "ECONOMY CLASS";
        else if (dtFlightDtlsId.Rows[0]["ONBRDDTL_FLIGHT_TYPE"].ToString() == "2")
            FlightData[1] = "BUSSINESS CLASS";
        else if (dtFlightDtlsId.Rows[0]["ONBRDDTL_FLIGHT_TYPE"].ToString() == "3")
            FlightData[1] = "FIRST CLASS";

        if (dtFlightDtlsId.Rows[0]["ONBRDDTL_FLIGHT_STATUS"].ToString() == "0")
            FlightData[2] = "Job Assigned";
        else if (dtFlightDtlsId.Rows[0]["ONBRDDTL_FLIGHT_STATUS"].ToString() == "1")
            FlightData[2] = "Availability Check";
        else if (dtFlightDtlsId.Rows[0]["ONBRDDTL_FLIGHT_STATUS"].ToString() == "2")
            FlightData[2] = "Awaiting, Approval from candidate";
        else if (dtFlightDtlsId.Rows[0]["ONBRDDTL_FLIGHT_STATUS"].ToString() == "3")
            FlightData[2] = "Booking Confirm, ticket copy attach";

        FlightData[3] = dtFlightDtlsId.Rows[0]["ONBRDDTL_DATE"].ToString();

        objEntityOnBoarding_Status.Candidt_DtlId = Convert.ToInt32(dtFlightDtlsId.Rows[0]["ONBRDDTL_ID"].ToString());
        DataTable dtEmpOnBrdFlight = new DataTable();
        dtEmpOnBrdFlight = objBusinessOnBoarding_Status.ReadEmpOnBoard_ById(objEntityOnBoarding_Status);

        string strEmpFlight = "";
        if (dtEmpOnBrdFlight.Rows.Count > 0)
        {
            foreach (DataRow dtrow in dtEmpOnBrdFlight.Rows)
            {
                strEmpFlight = dtrow["USR_NAME"] + " , " + strEmpFlight;
            }
        }
        FlightData[4] = strEmpFlight.TrimEnd(" , ".ToCharArray());

        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + FlightData[1].ToUpper() + "</td>";
        strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + FlightData[4].ToUpper() + "</td>";
        strHtml += "<td class=\"tdT\" style=\" width:23%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + FlightData[2].ToUpper() + "</td>";
        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + FlightData[3].ToUpper() + "</td>";


        strHtml += "</tr>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >3</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Room Allotment</td>";

        DataTable dtRoomDtlsId = new DataTable();
        dtRoomDtlsId = objBusinessOnBoarding_Status.ReadRoomDtls_ById(objEntityOnBoarding_Status);

        string[] RoomData = new string[7];
        RoomData[0] = dtRoomDtlsId.Rows[0]["ONBRDDTL_ID"].ToString();

        if (dtRoomDtlsId.Rows[0]["ONBRDDTL_RMALTMNT_TYP"].ToString() == "1")
            RoomData[1] = "BED SPACE";
        else if (dtRoomDtlsId.Rows[0]["ONBRDDTL_RMALTMNT_TYP"].ToString() == "2")
            RoomData[1] = "1 BHK";
        else if (dtRoomDtlsId.Rows[0]["ONBRDDTL_RMALTMNT_TYP"].ToString() == "3")
            RoomData[1] = "2 BHK";
        else if (dtRoomDtlsId.Rows[0]["ONBRDDTL_RMALTMNT_TYP"].ToString() == "4")
            RoomData[1] = "3 BHK";
        else if (dtRoomDtlsId.Rows[0]["ONBRDDTL_RMALTMNT_TYP"].ToString() == "5")
            RoomData[1] = "VILLA";
        else if (dtRoomDtlsId.Rows[0]["ONBRDDTL_RMALTMNT_TYP"].ToString() == "3")
            RoomData[1] = "FLAT";

        if (dtRoomDtlsId.Rows[0]["ONBRDDTL_ROOM_STATUS"].ToString() == "0")
            RoomData[2] = "Job Assigned";
        else if (dtRoomDtlsId.Rows[0]["ONBRDDTL_ROOM_STATUS"].ToString() == "1")
            RoomData[2] = "Availability Check";
        else if (dtRoomDtlsId.Rows[0]["ONBRDDTL_ROOM_STATUS"].ToString() == "2")
            RoomData[2] = "Facility Procurement";
        else if (dtRoomDtlsId.Rows[0]["ONBRDDTL_ROOM_STATUS"].ToString() == "3")
            RoomData[2] = "Complete";
        else if (dtRoomDtlsId.Rows[0]["ONBRDDTL_ROOM_STATUS"].ToString() == "4")
            RoomData[2] = "Closed Without Allotment";

        RoomData[3] = dtRoomDtlsId.Rows[0]["ONBRDDTL_DATE"].ToString();

        objEntityOnBoarding_Status.Candidt_DtlId = Convert.ToInt32(dtRoomDtlsId.Rows[0]["ONBRDDTL_ID"].ToString());
        DataTable dtEmpOnBrdRoom = new DataTable();
        dtEmpOnBrdRoom = objBusinessOnBoarding_Status.ReadEmpOnBoard_ById(objEntityOnBoarding_Status);

        string strEmpRoom = "";
        if (dtEmpOnBrdRoom.Rows.Count > 0)
        {
            foreach (DataRow dtrow in dtEmpOnBrdRoom.Rows)
            {
                strEmpRoom = dtrow["USR_NAME"] + " , " + strEmpRoom;
            }
        }
        RoomData[4] = strEmpRoom.TrimEnd(" , ".ToCharArray());

        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + RoomData[1].ToUpper() + "</td>";
        strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + RoomData[4].ToUpper() + "</td>";
        strHtml += "<td class=\"tdT\" style=\" width:23%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + RoomData[2].ToUpper() + "</td>";
        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + RoomData[3].ToUpper() + "</td>";

        strHtml += "</tr>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >4</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >AirPort Pickup</td>";

        DataTable dtAirprtDtlsId = new DataTable();
        dtAirprtDtlsId = objBusinessOnBoarding_Status.ReadAirportDtls_ById(objEntityOnBoarding_Status);

        string[] AirprtData = new string[7];
        AirprtData[0] = dtAirprtDtlsId.Rows[0]["ONBRDDTL_ID"].ToString();
        AirprtData[1] = dtAirprtDtlsId.Rows[0]["VHCL_NUMBR"].ToString();

        if (dtAirprtDtlsId.Rows[0]["ONBRDDTL_AIRPT_STATUS"].ToString() == "0")
            AirprtData[2] = "Job Assigned";
        AirprtData[3] = dtRoomDtlsId.Rows[0]["ONBRDDTL_DATE"].ToString();

        objEntityOnBoarding_Status.Candidt_DtlId = Convert.ToInt32(dtAirprtDtlsId.Rows[0]["ONBRDDTL_ID"].ToString());
        DataTable dtEmpOnBrdAirprt = new DataTable();
        dtEmpOnBrdAirprt = objBusinessOnBoarding_Status.ReadEmpOnBoard_ById(objEntityOnBoarding_Status);

        string strEmpAirprt = "";
        if (dtEmpOnBrdAirprt.Rows.Count > 0)
        {
            foreach (DataRow dtrow in dtEmpOnBrdAirprt.Rows)
            {
                strEmpAirprt = dtrow["USR_NAME"] + " , " + strEmpAirprt;
            }
        }
        AirprtData[4] = strEmpAirprt.TrimEnd(" , ".ToCharArray());

        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + AirprtData[1].ToUpper() + "</td>";
        strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + AirprtData[4].ToUpper() + "</td>";
        strHtml += "<td class=\"tdT\" style=\" width:23%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + AirprtData[2].ToUpper() + "</td>";
        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + AirprtData[3].ToUpper() + "</td>";

        strHtml += "</tr>";

        strHtml += "</tbody>";

        strHtml += "</table>";
        sb.Append(strHtml);
        //write to  divPrintReportDetails
        strJsonPrint[2] = sb.ToString();



        return strJsonPrint;


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
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.ON_BOARDING_STS_CSV);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
            string newFilePath = Server.MapPath("/CustomFiles/HCM CSV/OnBoarding_Status/OnBoarding_Status_" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "OnBoarding_Status_" + strNextId + ".csv";
            Response.ContentType = "csv";
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.ON_BOARDING_STS_CSV);
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
        table.Columns.Add("LOCATION", typeof(string));
        table.Columns.Add("REFERENCE", typeof(string));
        table.Columns.Add("NATIONALITY", typeof(string));


        clsEntityOnBoarding_Status_Report objEntityOnBoarding_Status = new clsEntityOnBoarding_Status_Report();
        clsBusinessLayer_OnBoard_Status_Report objBusinessOnBoarding_Status = new clsBusinessLayer_OnBoard_Status_Report();

        if (ddlManPower.SelectedItem.Value != "--SELECT MANPOWER--")
        {
            objEntityOnBoarding_Status.ManPwrId = Convert.ToInt32(ddlManPower.SelectedItem.Value);
        }

        objEntityOnBoarding_Status.CorpId = Convert.ToInt32(hiddenCorpId.Value);
        objEntityOnBoarding_Status.OrgId = Convert.ToInt32(hiddenOrgId.Value);

        DataTable dt = new DataTable();
        dt = objBusinessOnBoarding_Status.ReadCandidateDtls(objEntityOnBoarding_Status);

     


        //for printing table
        string Cand_name = "";
        string Location = "";
        string Ref = "";
        string Nationality = "";
       



        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
           

            string strId = dt.Rows[intRowBodyCount][0].ToString();

            string reference = "";

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
              
                if (intColumnBodyCount == 1)
                {
                    Cand_name = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                }
                if (intColumnBodyCount == 2)
                {
                    Location = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                }
                if (intColumnBodyCount == 3)
                {
                    if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "1")
                    {
                        reference = "CONSULTANCY";
                    }
                    else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "2")
                    {
                        reference = "DIVISION";
                    }
                    else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "3")
                    {
                        reference = "DEPARTMENT";
                    }
                    else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "4")
                    {
                        reference = "EMPLOYEE";
                    }
                    Ref = reference;
                }

                if (intColumnBodyCount == 4)
                {
                    Nationality = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                }
            }

            table.Rows.Add('"' + Cand_name + '"', '"' + Location + '"', '"' + Ref + '"', '"' + Nationality+ '"');
         

        }


        return table;
    }
}