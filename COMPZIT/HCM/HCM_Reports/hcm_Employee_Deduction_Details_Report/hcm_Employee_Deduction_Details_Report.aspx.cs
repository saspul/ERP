using BL_Compzit.BusinessLayer_GMS;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_GMS;
using BL_Compzit;
using System.Web.Services;
using BL_Compzit.BusinessLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using System.IO;
using System.Collections.Generic;
using System.Linq;
public partial class HCM_hcm_Employee_Deduction_Details_Report_hcm_Employee_Deduction_Details_Reportaspx : System.Web.UI.Page
{
    int intOrgId;
    int intCorpId;
    int intUserId = 0;
    clsBusinessEmployee_DeductionDetails_Report objBusinessDeductiioDetails = new clsBusinessEmployee_DeductionDetails_Report();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlDep.Focus();
            Corp_DepartmentLoad();
            DesignationLoad();
            clsEntityEmployee_DeductionDetails_Report objEntityEmployeeDeductionReport = new clsEntityEmployee_DeductionDetails_Report();

           

            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
                hiddenCorpId.Value = intCorpId.ToString();
           objEntityEmployeeDeductionReport.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"]);
                hiddenOrgId.Value = intOrgId.ToString();
              objEntityEmployeeDeductionReport.orgid = Convert.ToInt32(Session["ORGID"]);
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (ddlDep.SelectedItem.Text != "--SELECT DEPARTMENT--")
            {
                objEntityEmployeeDeductionReport.DeptId =Convert.ToInt32( ddlDep.SelectedItem.Value);
            }

            if (ddlDivision.SelectedItem.Text != "--SELECT DIVISION--")
            {
                objEntityEmployeeDeductionReport.divisionId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
            }
            if (ddlDesignation.SelectedItem.Text != "--SELECT DESIGNATION--")
            {
                objEntityEmployeeDeductionReport.desgId = Convert.ToInt32(ddlDesignation.SelectedItem.Value);
            }
            if (radioStaff.Checked == true)
            {
                objEntityEmployeeDeductionReport.type = 0;
            }
            else
            {
                objEntityEmployeeDeductionReport.type = 1;
            }
          
            DataTable dtManpwr = new DataTable();
            dtManpwr = objBusinessDeductiioDetails.ReadDeductionList(objEntityEmployeeDeductionReport);

            string strHtm = ConvertDataTableToHTML(dtManpwr,"Load");
            divReport.InnerHtml = strHtm;


            DataTable dtCorp = objBusinessDeductiioDetails.ReadCorporateAddress(objEntityEmployeeDeductionReport);
            string strPrintReport = ConvertDataTableForPrint(dtManpwr, dtCorp, "Load");
            divPrintReportDetails.InnerHtml = strPrintReport;
        }
    }
    //It build the Html table by using the datatable provided

    public string ConvertDataTableToHTML(DataTable dt,string sts)
    {
        //int intUserId = 0, intUsrRolMstrId, intEnableHRall = 0, intEnableAllBuint = 0;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();






        clsEntityEmployee_DeductionDetails_Report objEntityVisQuotInfo = new clsEntityEmployee_DeductionDetails_Report();
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">EMPLOYEE</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">DEDUCTION TYPE</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">DEDUCTION PERIOD</th>";
            }
            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:13%;text-align: right; word-wrap:break-word;\">TOTAL AMOUNT TO BE DEDUCTED</th>";
               
            }
            if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\" style=\"width:13%;text-align: right; word-wrap:break-word;\"> AMOUNT  DEDUCTED</th>";
            }
            if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\" style=\"width:13%;text-align: right; word-wrap:break-word;\">PENDING AMOUNT TO BE DEDUCTED</th>";
            }
            
        }


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";

        if (sts == "Search")
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                strHtml += "<tr  >";

                objEntityVisQuotInfo.orgid = Convert.ToInt32(hiddenOrgId.Value);
                objEntityVisQuotInfo.CorpId = Convert.ToInt32(hiddenCorpId.Value);
                objEntityVisQuotInfo.UserId = Convert.ToInt32(dt.Rows[intRowBodyCount]["EMPDEDTN_ID"].ToString());
                DataTable dtdeductionList = objBusinessDeductiioDetails.ReadDeductionById(objEntityVisQuotInfo);
                string strId = dt.Rows[intRowBodyCount][0].ToString();



                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPNAME"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 3)
                    {
                        string deduction = "";
                        int deductionId = Convert.ToInt32(dt.Rows[intRowBodyCount]["EMPDEDTN_DEDCTNID"].ToString());
                        if (deductionId == 1)
                        {
                            deduction = "Loan";
                        }
                        else if (deductionId == 2)
                        {
                            deduction = "Advance Amount";
                        }
                        else
                        {
                            deduction = "Other";
                        }


                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + deduction + "</td>";
                    }
                    if (intColumnBodyCount == 4)
                    {

                        int plan = Convert.ToInt32(dtdeductionList.Rows[0]["EMPDEDTN_INSTLMNTPLAN"].ToString());
                        string dedplan = "";
                        if (plan == 1)
                        {
                            dedplan = "MONTHLY";
                        }
                        else if (plan == 2)
                        {
                            dedplan = "TWO MONTHS";
                        }
                        else if (plan == 3)
                        {
                            dedplan = "SIX MONTHS";
                        }
                        else if (plan == 4)
                        {
                            dedplan = "ANNUALLY";
                        }
                        strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dedplan + "</td>";
                    }
                    if (intColumnBodyCount == 5)
                    {

                        strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + dt.Rows[intRowBodyCount]["EMPDEDTN_AMOUNT"].ToString() + " " + dtdeductionList.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 6)
                    {


                        string TOTALPAID = dt.Rows[intRowBodyCount]["TOTALPAID"].ToString();
                        string deductedamt = "";
                        if (TOTALPAID == "")
                        {
                            deductedamt = "0.0";
                        }
                        else
                        {
                            deductedamt = dt.Rows[intRowBodyCount]["TOTALPAID"].ToString();
                        }

                        strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + deductedamt + " " + dtdeductionList.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";


                    }
                    if (intColumnBodyCount == 7)
                    {
                        decimal totalamt = Convert.ToDecimal(dt.Rows[intRowBodyCount]["EMPDEDTN_AMOUNT"].ToString());
                        string TOTALPAID = dt.Rows[intRowBodyCount]["TOTALPAID"].ToString();
                        decimal deductedamt;
                        if (TOTALPAID == "")
                        {
                            deductedamt = 0;
                        }
                        else
                        {
                            deductedamt = Convert.ToDecimal(dt.Rows[intRowBodyCount]["TOTALPAID"].ToString());
                        }
                        decimal pendingAmt = totalamt - deductedamt;

                        strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + pendingAmt + " " + dtdeductionList.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";

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

    public string ConvertDataTableForPrint(DataTable dt, DataTable dtCorp,string sts)
    {
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityEmployee_DeductionDetails_Report objEntityVisQuotInfo = new clsEntityEmployee_DeductionDetails_Report();

        string strTitle = "";
        strTitle = "Employee Deduction Details Report";
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

        string strdept = "";
        if (ddlDep.SelectedItem.Text.ToString() == "--SELECT DEPARTMENT--")
        {
            strdept = "";
        }
        else
        {
            strdept = "<tr>Department : " + ddlDep.SelectedItem.Text.ToString() + "<br/></tr>";
        }

        string strdvsn = "";
        if (ddlDivision.SelectedItem.Text.ToString() == "--SELECT DIVISION--")
        {
            strdvsn = "";
        }
        else
        {
            strdvsn = "<tr>Division : " + ddlDivision.SelectedItem.Text.ToString() + "<br/></tr>";
        }
        string strdesg = "";

        if (ddlDesignation.SelectedItem.Text.ToString() == "--SELECT DESIGNATION--")
        {
            strdesg = "";
        }
        else
        {
            strdesg = "<tr>Project : " + ddlDesignation.SelectedItem.Text.ToString() + "<br/></tr>";
        }
        string strType = "";

        if (radioStaff.Checked==true)
        {
            strType = "<tr>Type : Staff<br/></tr>";
        }
        else
        {
            strType = "<tr>Type : Worker<br/></tr>";
        }
       



        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate +strUsrName+ strCaptionTabTitle + strCaptionTabstop + strdept + strdvsn + strdesg + strType;

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
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">EMPLOYEE</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">DEDUCTION TYPE</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">DEDUCTION PERIOD</th>";
            }
            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:13%;text-align: right; word-wrap:break-word;\">TOTAL AMOUNT TO BE DEDUCTED</th>";
              
            }
            if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\" style=\"width:13%;text-align: right; word-wrap:break-word;\"> AMOUNT DEDUCTED</th>";
            }
            if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\" style=\"width:13%;text-align: right; word-wrap:break-word;\">PENDING AMOUNT TO BE DEDUCTED</th>";
            }

        }
        if (dt.Columns.Count == 0)
        {
            strHtml += "<td class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";
            strHtml += "<td class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">EMPLOYEE</th>";
            strHtml += "<td class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">DEDUCTION TYPE</th>";
            strHtml += "<td class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">DEDUCTION PERIOD</th>";
            strHtml += "<td class=\"thT\"  style=\"width:20%;text-align: right; word-wrap:break-word;\">TOTAL AMOUNT TO BE DEDUCTED</th>";
            strHtml += "<td class=\"thT\"  style=\"width:20%;text-align: right; word-wrap:break-word;\"> AMOUNT DEDUCTED</th>";
            strHtml += "<td class=\"thT\"  style=\"width:20%;text-align: right; word-wrap:break-word;\">PENDING AMOUNT TO BE DEDUCTED</th>";

        }


        strHtml += "</tr>";


        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";


        if (dt.Rows.Count == 0)
        {
            strHtml += "<tr  >";
            strHtml += "<td  class=\"thT\" colspan=\"7\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
            strHtml += "</tr>";
        }

        if (sts == "Search")
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                strHtml += "<tr  >";

                objEntityVisQuotInfo.orgid = Convert.ToInt32(hiddenOrgId.Value);
                objEntityVisQuotInfo.CorpId = Convert.ToInt32(hiddenCorpId.Value);
                objEntityVisQuotInfo.UserId = Convert.ToInt32(dt.Rows[intRowBodyCount]["EMPDEDTN_ID"].ToString());
                DataTable dtdeductionList = objBusinessDeductiioDetails.ReadDeductionById(objEntityVisQuotInfo);
                string strId = dt.Rows[intRowBodyCount][0].ToString();



                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPNAME"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 3)
                    {
                        string deduction = "";
                        int deductionId = Convert.ToInt32(dt.Rows[intRowBodyCount]["EMPDEDTN_DEDCTNID"].ToString());
                        if (deductionId == 1)
                        {
                            deduction = "Loan";
                        }
                        else if (deductionId == 2)
                        {
                            deduction = "Advance Amount";
                        }
                        else
                        {
                            deduction = "Other";
                        }


                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + deduction + "</td>";
                    }
                    if (intColumnBodyCount == 4)
                    {

                        int plan = Convert.ToInt32(dtdeductionList.Rows[0]["EMPDEDTN_INSTLMNTPLAN"].ToString());
                        string dedplan = "";
                        if (plan == 1)
                        {
                            dedplan = "MONTHLY";
                        }
                        else if (plan == 2)
                        {
                            dedplan = "TWO MONTHS";
                        }
                        else if (plan == 3)
                        {
                            dedplan = "SIX MONTHS";
                        }
                        else if (plan == 4)
                        {
                            dedplan = "ANNUALLY";
                        }
                        strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dedplan + "</td>";
                    }
                    if (intColumnBodyCount == 5)
                    {

                        strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + dt.Rows[intRowBodyCount]["EMPDEDTN_AMOUNT"].ToString() + " " + dtdeductionList.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 6)
                    {


                        string TOTALPAID = dt.Rows[intRowBodyCount]["TOTALPAID"].ToString();
                        string deductedamt = "";
                        if (TOTALPAID == "")
                        {
                            deductedamt = "0.0";
                        }
                        else
                        {
                            deductedamt = dt.Rows[intRowBodyCount]["TOTALPAID"].ToString();
                        }

                        strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + deductedamt + " " + dtdeductionList.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";


                    }
                    if (intColumnBodyCount == 7)
                    {
                        decimal totalamt = Convert.ToDecimal(dt.Rows[intRowBodyCount]["EMPDEDTN_AMOUNT"].ToString());
                        string TOTALPAID = dt.Rows[intRowBodyCount]["TOTALPAID"].ToString();
                        decimal deductedamt;
                        if (TOTALPAID == "")
                        {
                            deductedamt = 0;
                        }
                        else
                        {
                            deductedamt = Convert.ToDecimal(dt.Rows[intRowBodyCount]["TOTALPAID"].ToString());
                        }
                        decimal pendingAmt = totalamt - deductedamt;

                        strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + pendingAmt + " " + dtdeductionList.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";

                    }

                }



                strHtml += "</tr>";








            }
        }
        else
        {
            strHtml += "<td  class=\"thT\" colspan=\"7\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
        }
        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();


   
      

      


    }

    public void DesignationLoad()
    {
        int intOrgId;
        int intCorpId;
        int intUserId = 0;
        clsEntityEmployee_DeductionDetails_Report objEntityDeductionReport = new clsEntityEmployee_DeductionDetails_Report();

        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            hiddenCorpId.Value = intCorpId.ToString();
            objEntityDeductionReport.CorpId = intCorpId;
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"]);
            hiddenOrgId.Value = intOrgId.ToString();
            objEntityDeductionReport.orgid = intOrgId;
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityDeductionReport.UserId = intUserId;
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBusinessDeductiioDetails.ReadDesignation(objEntityDeductionReport);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlDesignation.DataSource = dtSubConrt;
            ddlDesignation.DataTextField = "DSGN_NAME";
            ddlDesignation.DataValueField = "DSGN_ID";
            ddlDesignation.DataBind();

        }

        ddlDesignation.Items.Insert(0, "--SELECT DESIGNATION--");
     

    }
    public void Corp_DepartmentLoad()
    {
        int intOrgId;
        int intCorpId;
        int intUserId = 0;
        clsEntityEmployee_DeductionDetails_Report objEntityDeductionReport = new clsEntityEmployee_DeductionDetails_Report();

        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            hiddenCorpId.Value = intCorpId.ToString();
            objEntityDeductionReport.CorpId = intCorpId;
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"]);
            hiddenOrgId.Value = intOrgId.ToString();
            objEntityDeductionReport.orgid = intOrgId;
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityDeductionReport.UserId = intUserId;
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBusinessDeductiioDetails.ReadDepartment(objEntityDeductionReport);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlDep.DataSource = dtSubConrt;
            ddlDep.DataTextField = "CPRDEPT_NAME";
            ddlDep.DataValueField = "CPRDEPT_ID";
            ddlDep.DataBind();

        }

        ddlDep.Items.Insert(0, "--SELECT DEPARTMENT--");
        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");

    }

  
    protected void btnRsnSave_Click(object sender, EventArgs e)
    {
    }






    protected void ddlDep_SelectedIndexChanged(object sender, EventArgs e)
    {

        int intOrgId;
        int intCorpId;
        int intUserId = 0;
        clsEntityEmployee_DeductionDetails_Report objEntityDeductionReport = new clsEntityEmployee_DeductionDetails_Report();

        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            hiddenCorpId.Value = intCorpId.ToString();
            objEntityDeductionReport.CorpId = intCorpId;
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"]);
            hiddenOrgId.Value = intOrgId.ToString();
            objEntityDeductionReport.orgid = intOrgId;
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityDeductionReport.UserId = intUserId;
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ddlDivision.Items.Clear();
        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
        if (ddlDep.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            int Dept = Convert.ToInt32(ddlDep.SelectedItem.Value);
            objEntityDeductionReport.DeptId = Dept;
            DataTable dtSubConrt = objBusinessDeductiioDetails.ReadDivision(objEntityDeductionReport);
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int intOrgId;
        int intCorpId;
        int intUserId = 0;
        clsEntityEmployee_DeductionDetails_Report objEntityDeductionReport = new clsEntityEmployee_DeductionDetails_Report();

        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            hiddenCorpId.Value = intCorpId.ToString();
            objEntityDeductionReport.CorpId = intCorpId;
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"]);
            hiddenOrgId.Value = intOrgId.ToString();
            objEntityDeductionReport.orgid = intOrgId;
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityDeductionReport.UserId = intUserId;
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (ddlDep.SelectedItem.Text != "--SELECT DEPARTMENT--")
        {
            objEntityDeductionReport.DeptId = Convert.ToInt32(ddlDep.SelectedItem.Value);
        }

        if (ddlDivision.SelectedItem.Text != "--SELECT DIVISION--")
        {
            objEntityDeductionReport.divisionId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        }
        if (ddlDesignation.SelectedItem.Text != "--SELECT DESIGNATION--")
        {
            objEntityDeductionReport.desgId = Convert.ToInt32(ddlDesignation.SelectedItem.Value);
        }
        if (radioStaff.Checked == true)
        {
            objEntityDeductionReport.type = 0;
        }
        else
        {
            objEntityDeductionReport.type = 1;
        }
        DataTable dtManpwr = new DataTable();
        dtManpwr = objBusinessDeductiioDetails.ReadDeductionList(objEntityDeductionReport);

        string strHtm = ConvertDataTableToHTML(dtManpwr,"Search");
        divReport.InnerHtml = strHtm;


        DataTable dtCorp = objBusinessDeductiioDetails.ReadCorporateAddress(objEntityDeductionReport);
        string strPrintReport = ConvertDataTableForPrint(dtManpwr, dtCorp, "Search");
        divPrintReportDetails.InnerHtml = strPrintReport;
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
        int intOrgId;
        int intCorpId;
        int intUserId = 0;
        clsEntityEmployee_DeductionDetails_Report objEntityDeductionReport = new clsEntityEmployee_DeductionDetails_Report();
         clsBusinessEmployee_DeductionDetails_Report objBusinessDeductiioDetails = new clsBusinessEmployee_DeductionDetails_Report();

        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            hiddenCorpId.Value = intCorpId.ToString();
            objEntityDeductionReport.CorpId = intCorpId;
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"]);
            hiddenOrgId.Value = intOrgId.ToString();
            objEntityDeductionReport.orgid = intOrgId;
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityDeductionReport.UserId = intUserId;
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (ddlDep.SelectedItem.Text != "--SELECT DEPARTMENT--")
        {
            objEntityDeductionReport.DeptId = Convert.ToInt32(ddlDep.SelectedItem.Value);
        }

        if (ddlDivision.SelectedItem.Text != "--SELECT DIVISION--")
        {
            objEntityDeductionReport.divisionId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        }
        if (ddlDesignation.SelectedItem.Text != "--SELECT DESIGNATION--")
        {
            objEntityDeductionReport.desgId = Convert.ToInt32(ddlDesignation.SelectedItem.Value);
        }
        if (radioStaff.Checked == true)
        {
            objEntityDeductionReport.type = 0;
        }
        else
        {
            objEntityDeductionReport.type = 1;
        }
        DataTable dt = new DataTable();
        dt = objBusinessDeductiioDetails.ReadDeductionList(objEntityDeductionReport);
        DataTable table = new DataTable();
        table.Columns.Add("EMPLOYEE ID", typeof(string));
        table.Columns.Add("EMPLOYEE", typeof(string));
        table.Columns.Add("DEDUCTION TYPE", typeof(string));
        table.Columns.Add("DEDUCTION PERIOD", typeof(string));
        table.Columns.Add("TOTAL AMOUNT TO BE DEDUCTED", typeof(string));
        table.Columns.Add("AMOUNT  DEDUCTED", typeof(string));
        table.Columns.Add("PENDING AMOUNT TO BE DEDUCTED", typeof(string));
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        clsEntityEmployee_DeductionDetails_Report objEntityVisQuotInfo = new clsEntityEmployee_DeductionDetails_Report();
        StringBuilder sb = new StringBuilder();
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string EMPID = "";
            string EMP = "";
            string TYPE = "";
            string PERIOD = "";
            string TOTAL = "";
            string DEDUCTED = "";
            string PENDING = "";
            objEntityVisQuotInfo.orgid = Convert.ToInt32(hiddenOrgId.Value);
            objEntityVisQuotInfo.CorpId = Convert.ToInt32(hiddenCorpId.Value);
            objEntityVisQuotInfo.UserId = Convert.ToInt32(dt.Rows[intRowBodyCount]["EMPDEDTN_ID"].ToString());
            DataTable dtdeductionList = objBusinessDeductiioDetails.ReadDeductionById(objEntityVisQuotInfo);
            string strId = dt.Rows[intRowBodyCount][0].ToString();
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                if (intColumnBodyCount == 1)
                {
                    EMPID = dt.Rows[intRowBodyCount]["USR_CODE"].ToString();
                }
                if (intColumnBodyCount == 2)
                {
                    EMP = dt.Rows[intRowBodyCount]["EMPNAME"].ToString();
                }
                if (intColumnBodyCount == 3)
                {
                    string deduction = "";
                    int deductionId = Convert.ToInt32(dt.Rows[intRowBodyCount]["EMPDEDTN_DEDCTNID"].ToString());
                    if (deductionId == 1)
                    {
                        deduction = "Loan";
                    }
                    else if (deductionId == 2)
                    {
                        deduction = "Advance Amount";
                    }
                    else
                    {
                        deduction = "Other";
                    }
                    TYPE = deduction;
                }
                if (intColumnBodyCount == 4)
                {

                    int plan = Convert.ToInt32(dtdeductionList.Rows[0]["EMPDEDTN_INSTLMNTPLAN"].ToString());
                    string dedplan = "";
                    if (plan == 1)
                    {
                        dedplan = "MONTHLY";
                    }
                    else if (plan == 2)
                    {
                        dedplan = "TWO MONTHS";
                    }
                    else if (plan == 3)
                    {
                        dedplan = "SIX MONTHS";
                    }
                    else if (plan == 4)
                    {
                        dedplan = "ANNUALLY";
                    }
                    PERIOD = dedplan;
                }
                if (intColumnBodyCount == 5)
                {

                    TOTAL = dt.Rows[intRowBodyCount]["EMPDEDTN_AMOUNT"].ToString() + " " + dtdeductionList.Rows[0]["CRNCMST_ABBRV"].ToString();
                }
                if (intColumnBodyCount == 6)
                {


                    string TOTALPAID = dt.Rows[intRowBodyCount]["TOTALPAID"].ToString();
                    string deductedamt = "";
                    if (TOTALPAID == "")
                    {
                        deductedamt = "0.0";
                    }
                    else
                    {
                        deductedamt = dt.Rows[intRowBodyCount]["TOTALPAID"].ToString();
                    }

                    DEDUCTED = deductedamt + " " + dtdeductionList.Rows[0]["CRNCMST_ABBRV"].ToString();


                }
                if (intColumnBodyCount == 7)
                {
                    decimal totalamt = Convert.ToDecimal(dt.Rows[intRowBodyCount]["EMPDEDTN_AMOUNT"].ToString());
                    string TOTALPAID = dt.Rows[intRowBodyCount]["TOTALPAID"].ToString();
                    decimal deductedamt;
                    if (TOTALPAID == "")
                    {
                        deductedamt = 0;
                    }
                    else
                    {
                        deductedamt = Convert.ToDecimal(dt.Rows[intRowBodyCount]["TOTALPAID"].ToString());
                    }
                    decimal pendingAmt = totalamt - deductedamt;
                    PENDING = pendingAmt + " " + dtdeductionList.Rows[0]["CRNCMST_ABBRV"].ToString();
                }

            }
            table.Rows.Add('"' + EMPID + '"', '"' + EMP + '"', '"' + TYPE + '"', '"' + PERIOD + '"','"' + TOTAL + '"', '"' + DEDUCTED + '"', '"' + PENDING + '"');
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
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.EMP_DEDUCTN_RPRT_CSV);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
            string newFilePath = Server.MapPath("/CustomFiles/HCM CSV/Employee Deducation/Employee_Deducation_Report_" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "Employee_Deducation_Report_" + strNextId + ".csv";
            Response.ContentType = "csv";
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.EMP_DEDUCTN_RPRT_CSV);
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