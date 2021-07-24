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
public partial class HCM_HCM_Reports_hcm_Accommodation_Report : System.Web.UI.Page
{
    clsEntity_Accomodation_Report objEntity_Accomodation_report = new clsEntity_Accomodation_Report();
    clsBusiness_Accomodation_Report objBus_Accomodation_report = new clsBusiness_Accomodation_Report();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            if (Session["CORPOFFICEID"] != null)
            {
                objEntity_Accomodation_report.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                objEntity_Accomodation_report.OrganizatonId = Convert.ToInt32(Session["ORGID"].ToString());
                hiddenOrgId.Value = Session["ORGID"].ToString();
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            DataTable dtDepts = new DataTable();
            dtDepts = objBus_Accomodation_report.ReadDepts(objEntity_Accomodation_report);

            ddlDepartmnt.Items.Clear();
            ddlDepartmnt.DataSource = dtDepts;
            ddlDepartmnt.DataTextField = "CPRDEPT_NAME";
            ddlDepartmnt.DataValueField = "CPRDEPT_ID";
            ddlDepartmnt.DataBind();
            ddlDepartmnt.Items.Insert(0, "--SELECT DEPARTMENT--");

            DataTable dtDivision = new DataTable();
            dtDivision = objBus_Accomodation_report.ReadDivision(objEntity_Accomodation_report);

            ddlDivision.Items.Clear();
            ddlDivision.DataSource = dtDivision;
            ddlDivision.DataTextField = "CPRDIV_NAME";
            ddlDivision.DataValueField = "CPRDIV_ID";
            ddlDivision.DataBind();

            ddlDivision.Items.Insert(0, "--SELECT DIVISION--");

            DataTable dtAccomodation = new DataTable();
            dtAccomodation = objBus_Accomodation_report.ReadAccommodation(objEntity_Accomodation_report);

            ddlAccomodation.Items.Clear();
            ddlAccomodation.DataSource = dtAccomodation;
            ddlAccomodation.DataTextField = "ACCMDTN_NAME";
            ddlAccomodation.DataValueField = "ACCMDTN_ID";
            ddlAccomodation.DataBind();

            ddlAccomodation.Items.Insert(0, "--SELECT ACCOMMODATION--");


            DataTable dtAccommodationList = new DataTable();
            dtAccommodationList = objBus_Accomodation_report.ReadAccommodationList(objEntity_Accomodation_report);

            string strHtm = ConvertDataTableToHTML(dtAccommodationList);
            divReport.InnerHtml = strHtm;
            DataTable dtCorp = objBus_Accomodation_report.ReadCorporateAddress(objEntity_Accomodation_report);

            string strPrintReport = ConvertDataTableForPrint(dtAccommodationList, dtCorp);
            divPrintReport.InnerHtml = strPrintReport;
        }
    }
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsEntity_Accomodation_Report objEntity_Accomodation_report = new clsEntity_Accomodation_Report();
        clsBusiness_Accomodation_Report objBus_Accomodation_report = new clsBusiness_Accomodation_Report();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntity_Accomodation_report.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntity_Accomodation_report.OrganizatonId = Convert.ToInt32(Session["ORGID"].ToString());
            hiddenOrgId.Value = Session["ORGID"].ToString();
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (ddlDepartmnt.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntity_Accomodation_report.DepartmentId = Convert.ToInt32(ddlDepartmnt.SelectedItem.Value);
        }
        if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
        {
            objEntity_Accomodation_report.DivisionId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        }
        if (ddlAccomodation.SelectedItem.Value != "--SELECT ACCOMMODATION--")
        {
            objEntity_Accomodation_report.Accomodation = Convert.ToInt32(ddlAccomodation.SelectedItem.Value);
        }
        if (txtFromDate.Text != "")
        {
            objEntity_Accomodation_report.FromDate = objCommon.textToDateTime(txtFromDate.Text);
        }
        if (txtTodate.Text != "")
        {
            objEntity_Accomodation_report.ToDate = objCommon.textToDateTime(txtTodate.Text);
        }
        //for viewing table

        DataTable dtAccomodation = new DataTable();
        dtAccomodation = objBus_Accomodation_report.ReadAccommodationList(objEntity_Accomodation_report);

        string strHtm = ConvertDataTableToHTML(dtAccomodation);
        divReport.InnerHtml = strHtm;
        DataTable dtCorp = objBus_Accomodation_report.ReadCorporateAddress(objEntity_Accomodation_report);

        string strPrintReport = ConvertDataTableForPrint(dtAccomodation, dtCorp);
        divPrintReport.InnerHtml = strPrintReport;
    }
    protected void ddlDepartmnt_SelectedIndexChanged(object sender, EventArgs e)
    {
        clsEntity_Accomodation_Report objEntity_Accomodation_report = new clsEntity_Accomodation_Report();
        clsBusiness_Accomodation_Report objBus_Accomodation_report = new clsBusiness_Accomodation_Report();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntity_Accomodation_report.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntity_Accomodation_report.OrganizatonId = Convert.ToInt32(Session["ORGID"].ToString());
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
            objEntity_Accomodation_report.DepartmentId  = Dept;

            DataTable dtSubConrt = objBus_Accomodation_report.ReadDivision(objEntity_Accomodation_report); ;
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
    }
    public string ConvertDataTableToHTML(DataTable dt)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
      


        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:12%;text-align: left; word-wrap:break-word;\">EMP #</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">DIVISION</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">ACCOMODATION</th>";
            }
            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">ACCOMODATION CATEGORY</th>";
            }
            if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">ACCOMODATION SUB CATEGORY</th>";
            }
            if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\" style=\"width:12%;text-align: center; word-wrap:break-word;\">DATE RANGE</th>";
            }
        }
        strHtml += "</tr>";
        strHtml += "</thead>";
        strHtml += "<tbody>";
        
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                string strDiv = "";
                int flag = 0;
                if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
                {
                    objEntity_Accomodation_report.DivisionId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
                    flag = 1;
                    strDiv = ddlDivision.SelectedItem.Text;
                }
                if (flag == 0)
                {
                    objEntity_Accomodation_report.UserId = Convert.ToInt32(dt.Rows[intRowBodyCount]["USR_ID"].ToString());
                    DataTable dtDivisions = objBus_Accomodation_report.ReadDivisionOfEmp(objEntity_Accomodation_report);
                    int intCount = 0;
                    intCount = dtDivisions.Rows.Count;
                    if (dtDivisions.Rows.Count != 0)
                    {
                        if (dtDivisions.Rows.Count == 1)
                        {
                            strDiv = dtDivisions.Rows[0]["DIVISION"].ToString();
                        }
                        else
                        {
                            string division = "";
                            string strdiv1 = "";
                            for (int i = 0; i < dtDivisions.Rows.Count; i++)
                            {
                                if (intCount != (i + 1))
                                {
                                    division = dtDivisions.Rows[i]["DIVISION"].ToString();
                                }

                                division = dtDivisions.Rows[i]["DIVISION"].ToString();
                                if (strdiv1 == "")
                                {
                                    strdiv1 = division;
                                }
                                else
                                {
                                    strdiv1 = strdiv1 + ", " + division;

                                }

                                strDiv = strdiv1;
                            }
                        }
                    }
                }
                strHtml += "<tr  >";
                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (intColumnBodyCount == 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 2)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USRNAME"].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 3)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + strDiv + "</td>";
                        }
                        if (intColumnBodyCount == 4)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["ACCMDTN_NAME"].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 5)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["ACCOMDTNCAT_NAME"].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 6)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["ACCOMDTNCATSUB_NAME"].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 7)
                        {
                            if (dt.Rows[intRowBodyCount]["FROMDATE"].ToString() != "" && dt.Rows[intRowBodyCount]["TODATE"].ToString() == "")
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["FROMDATE"].ToString()+" - " + "</td>";
                            }
                            else if (dt.Rows[intRowBodyCount]["FROMDATE"].ToString() != "" && dt.Rows[intRowBodyCount]["TODATE"].ToString() != "")
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["FROMDATE"].ToString() + " - " + dt.Rows[intRowBodyCount]["TODATE"].ToString() + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";
                            }
                        }
                    }
                }

                strHtml += "</tr>";
            }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();

        //End

    }
    public string ConvertDataTableForPrint(DataTable dt, DataTable dtCorp)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Accomodation Report";
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
        string strCompanyAddr = objCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);

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
        string strCaptionTabTitle = "<tr><td class=\"CapTitle\" >" + strTitle + "</td></tr>";


        string strdiv = "";
        if (ddlDivision.SelectedItem.Text.ToString() == "--SELECT DIVISION--")
        {
            strdiv = "";
        }
        else
        {
            strdiv = "<tr>Division : " + ddlDivision.SelectedItem.Text.ToString() + "<br/></tr>";
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

        if (ddlAccomodation.SelectedItem.Text.ToString() == "--SELECT ACCOMMODATION--")
        {
            strAcc = "";
        }
        else
        {
            strAcc = "<tr>Accommodation : " + ddlAccomodation.SelectedItem.Text.ToString() + "<br/></tr>";
        }
        string strFrom = "";

        if (txtFromDate.Text=="")
        {
            strFrom = "";
        }
        else
        {
            strFrom = "<tr>From date : " + txtFromDate.Text + "<br/></tr>";
        }
        string strTo = "";

        if (txtTodate.Text == "")
        {
            strTo = "";
        }
        else
        {
            strTo = "<tr>To date : " + txtTodate.Text + "<br/></tr>";
        }
        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strUsrName+strCaptionTabTitle + strCaptionTabstop + strdiv + strdept + strAcc + strFrom + strTo;

        sbCap.Append(strPrintCaptionTable);
        //write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString();

        StringBuilder sb = new StringBuilder();
        string strHtml = "</br><table id=\"PrintTable\" class=\"tab\"  >";
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:12%;text-align: left; word-wrap:break-word;\">EMP #</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">DIVISION</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:12%;text-align: left; word-wrap:break-word;\">ACCOMODATION</th>";
            }
            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:11%;text-align: left; word-wrap:break-word;\">ACCOMODATION CATEGORY</th>";
            }
            if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\" style=\"width:11%;text-align: left; word-wrap:break-word;\">ACCOMODATION SUB CATEGORY</th>";
            }
            if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">DATE RANGE</th>";
            }
        }
        strHtml += "</tr>";
        strHtml += "</thead>";
        strHtml += "<tbody>";

        if (dt.Rows.Count == 0)
        {
            strHtml += "<tr  ><td  class=\"thT\" colspan=\"7\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td></tr>";
        }
        else
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                string strDiv = "";
                int flag = 0;
                if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
                {
                    objEntity_Accomodation_report.DivisionId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
                    flag = 1;
                    strDiv = ddlDivision.SelectedItem.Text;
                }
                if (flag == 0)
                {
                    objEntity_Accomodation_report.UserId = Convert.ToInt32(dt.Rows[intRowBodyCount]["USR_ID"].ToString());
                    DataTable dtDivisions = objBus_Accomodation_report.ReadDivisionOfEmp(objEntity_Accomodation_report);
                    int intCount = 0;
                    intCount = dtDivisions.Rows.Count;
                    if (dtDivisions.Rows.Count != 0)
                    {
                        if (dtDivisions.Rows.Count == 1)
                        {
                            strDiv = dtDivisions.Rows[0]["DIVISION"].ToString();
                        }
                        else
                        {
                            string division = "";
                            string strdiv1 = "";
                            for (int i = 0; i < dtDivisions.Rows.Count; i++)
                            {
                                if (intCount != (i + 1))
                                {
                                    division = dtDivisions.Rows[i]["DIVISION"].ToString();
                                }

                                division = dtDivisions.Rows[i]["DIVISION"].ToString();
                                if (strdiv1 == "")
                                {
                                    strdiv1 = division;
                                }
                                else
                                {
                                    strdiv1 = strdiv1 + ", " + division;

                                }

                                strDiv = strdiv1;
                            }
                        }
                    }
                }
                strHtml += "<tr  >";
                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (intColumnBodyCount == 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 2)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USRNAME"].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 3)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + strDiv + "</td>";
                        }
                        if (intColumnBodyCount == 4)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["ACCMDTN_NAME"].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 5)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["ACCOMDTNCAT_NAME"].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 6)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["ACCOMDTNCATSUB_NAME"].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 7)
                        {
                            if (dt.Rows[intRowBodyCount]["FROMDATE"].ToString() != "" && dt.Rows[intRowBodyCount]["TODATE"].ToString() == "")
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["FROMDATE"].ToString() + " - " + "</td>";
                            }
                            else if (dt.Rows[intRowBodyCount]["FROMDATE"].ToString() != "" && dt.Rows[intRowBodyCount]["TODATE"].ToString() != "")
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["FROMDATE"].ToString() + " - " + dt.Rows[intRowBodyCount]["TODATE"].ToString() + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";
                            }
                        }
                    }
                }

                strHtml += "</tr>";
            }
        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();

        //End

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
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.ACCOMMODATION_REPORT_CSV);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
            string newFilePath = Server.MapPath("/CustomFiles/HCM CSV/Accommodation/Accommodation_Report" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "Accommodation_Report" + strNextId + ".csv";
            Response.ContentType = "csv";
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.ACCOMMODATION_REPORT_CSV);
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

        table.Columns.Add("EMP #", typeof(string));
        table.Columns.Add("EMPLOYEE", typeof(string));
        table.Columns.Add("DIVISION", typeof(string));
        table.Columns.Add("ACCOMODATION", typeof(string));
        table.Columns.Add("ACCOMODATION CATEGORY", typeof(string));
        table.Columns.Add("ACCOMODATION SUB CATEGORY", typeof(string));
        table.Columns.Add("DATE RANGE", typeof(string));


        clsEntity_Accomodation_Report objEntity_Accomodation_report = new clsEntity_Accomodation_Report();
        clsBusiness_Accomodation_Report objBus_Accomodation_report = new clsBusiness_Accomodation_Report();
      

        if (Session["CORPOFFICEID"] != null)
        {
            objEntity_Accomodation_report.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntity_Accomodation_report.OrganizatonId = Convert.ToInt32(Session["ORGID"].ToString());
            hiddenOrgId.Value = Session["ORGID"].ToString();
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (ddlDepartmnt.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntity_Accomodation_report.DepartmentId = Convert.ToInt32(ddlDepartmnt.SelectedItem.Value);
        }
        if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
        {
            objEntity_Accomodation_report.DivisionId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        }
        if (ddlAccomodation.SelectedItem.Value != "--SELECT ACCOMMODATION--")
        {
            objEntity_Accomodation_report.Accomodation = Convert.ToInt32(ddlAccomodation.SelectedItem.Value);
        }
        if (txtFromDate.Text != "")
        {
            objEntity_Accomodation_report.FromDate = objCommon.textToDateTime(txtFromDate.Text);
        }
        if (txtTodate.Text != "")
        {
            objEntity_Accomodation_report.ToDate = objCommon.textToDateTime(txtTodate.Text);
        }
        //for viewing table

        DataTable dt = new DataTable();
        dt = objBus_Accomodation_report.ReadAccommodationList(objEntity_Accomodation_report);



        //for printing table
        string EmpRef = "";
        string EmpName = "";
        string Dvsn = "";
        string Accomodatn = "";
        string AccomodatnCtgry = "";
        string AccomodatnSubCtgry = "";
        string DateRange = "";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string strDiv = "";
            int flag = 0;
            if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
            {
                objEntity_Accomodation_report.DivisionId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
                flag = 1;
                strDiv = ddlDivision.SelectedItem.Text;
            }
            if (flag == 0)
            {
                objEntity_Accomodation_report.UserId = Convert.ToInt32(dt.Rows[intRowBodyCount]["USR_ID"].ToString());
                DataTable dtDivisions = objBus_Accomodation_report.ReadDivisionOfEmp(objEntity_Accomodation_report);
                int intCount = 0;
                intCount = dtDivisions.Rows.Count;
                if (dtDivisions.Rows.Count != 0)
                {
                    if (dtDivisions.Rows.Count == 1)
                    {
                        strDiv = dtDivisions.Rows[0]["DIVISION"].ToString();
                    }
                    else
                    {
                        string division = "";
                        string strdiv1 = "";
                        for (int i = 0; i < dtDivisions.Rows.Count; i++)
                        {
                            if (intCount != (i + 1))
                            {
                                division = dtDivisions.Rows[i]["DIVISION"].ToString();
                            }

                            division = dtDivisions.Rows[i]["DIVISION"].ToString();
                            if (strdiv1 == "")
                            {
                                strdiv1 = division;
                            }
                            else
                            {
                                strdiv1 = strdiv1 + ", " + division;

                            }

                            strDiv = strdiv1;
                        }
                    }
                }
            }
           
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                if (dt.Rows.Count > 0)
                {
                    if (intColumnBodyCount == 1)
                    {
                        EmpRef = dt.Rows[intRowBodyCount]["USR_CODE"].ToString();
                    }
                    if (intColumnBodyCount == 2)
                    {
                        EmpName = dt.Rows[intRowBodyCount]["USRNAME"].ToString();
                    }
                    if (intColumnBodyCount == 3)
                    {
                        Dvsn = strDiv;
                    }
                    if (intColumnBodyCount == 4)
                    {
                        Accomodatn = dt.Rows[intRowBodyCount]["ACCMDTN_NAME"].ToString();
                    }
                    if (intColumnBodyCount == 5)
                    {
                        AccomodatnCtgry = dt.Rows[intRowBodyCount]["ACCOMDTNCAT_NAME"].ToString();
                    }
                    if (intColumnBodyCount == 6)
                    {
                        AccomodatnSubCtgry = dt.Rows[intRowBodyCount]["ACCOMDTNCATSUB_NAME"].ToString();
                    }
                    if (intColumnBodyCount == 7)
                    {
                        if (dt.Rows[intRowBodyCount]["FROMDATE"].ToString() != "" && dt.Rows[intRowBodyCount]["TODATE"].ToString() == "")
                        {
                            DateRange = dt.Rows[intRowBodyCount]["FROMDATE"].ToString() ;
                        }
                        else if (dt.Rows[intRowBodyCount]["FROMDATE"].ToString() != "" && dt.Rows[intRowBodyCount]["TODATE"].ToString() != "")
                        {
                            DateRange = dt.Rows[intRowBodyCount]["FROMDATE"].ToString() + " - " + dt.Rows[intRowBodyCount]["TODATE"].ToString();
                        }
                        else
                        {
                            DateRange = "";
                        }
                    }
                }
            }
            table.Rows.Add('"' + EmpRef + '"', '"' + EmpName + '"', '"' + Dvsn + '"', '"' + Accomodatn + '"', '"' + AccomodatnCtgry + '"', '"' + AccomodatnSubCtgry + '"', '"' + DateRange + '"');
            
        }

        return table;
    }
}