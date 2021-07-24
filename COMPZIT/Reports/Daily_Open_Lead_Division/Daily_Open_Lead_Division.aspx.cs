using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CL_Compzit;
using EL_Compzit.EntityLayer_GMS;
using BL_Compzit;
using System.Web.Services;
using EL_Compzit;
using System.Text;
using BL_Compzit.BusinessLayer_GMS;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

public partial class Reports_Daily_Open_Lead_Division_Daily_Open_Lead_Division : System.Web.UI.Page
{
    private enum Button_type
    {
        Previous = 1,
        Next = 2
    }

    clsBusinessLayerReports ObjBussinessReport = new clsBusinessLayerReports();
    clsEntityReports ObjEntityLeadDiv = new clsEntityReports();
    clsEntityCommon ObjEntityCommon = new clsEntityCommon();
    decimal sum,sum2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //EVM-0016
            ReadDivision();
            //EVM-0016
            ReadCustom();
            ReadProject();
            ReadStatus();
            ReadEmployee();
            //evm-0020
            ReadCurrency();

            int intUserId = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                ObjEntityLeadDiv.User_Id = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                ObjEntityLeadDiv.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                ObjEntityLeadDiv.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }




            string strCustom = ddlCustomer.SelectedItem.Text;
            string strProject = ddlProject.SelectedItem.Text;
            string strStatus = ddlStatus.SelectedItem.Value;
            string strEmployee = ddlEmployee.SelectedItem.Text;
            ObjEntityLeadDiv.Division_Id = 0;

            if (strCustom != null && strCustom != "")
            {
                if (ddlCustomer.Items.FindByValue(strCustom) != null)
                {
                    if (ddlCustomer.SelectedItem.Text != "--SELECT CUSTOMER NAME--")
                    {
                        ObjEntityLeadDiv.CustomerId = Convert.ToInt32(ddlCustomer.SelectedItem.Value);
                    }
                }
            }
            if (strProject != null && strProject != "")
            {
                if (ddlProject.Items.FindByValue(strProject) != null)
                {
                    if (ddlProject.SelectedItem.Text != "--SELECT PROJECT NAME--")
                    {
                        ObjEntityLeadDiv.ProjectId = Convert.ToInt32(ddlProject.SelectedItem.Value);
                    }
                }
            }

            if (strStatus != null && strStatus != "")
            {
                if (ddlStatus.Items.FindByValue(strCustom) != null)
                {
                    if (ddlStatus.SelectedItem.Text != "--SELECT STATUS--")
                    {
                        ObjEntityLeadDiv.StatusId = Convert.ToInt32(ddlStatus.SelectedItem.Value);
                    }
                }
            }



            if (strEmployee != null && strEmployee != "")
            {
                if (ddlEmployee.Items.FindByValue(strCustom) != null)
                {
                    if (ddlEmployee.SelectedItem.Text != "--SELECT EMPLOYEE NAME--")
                    {
                        ObjEntityLeadDiv.EmployeeId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);

                    }
                }
            }

            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                               clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                                  };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDfltCurrency.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
            }
            //evm-0020
            if (ddlCurrency.SelectedItem.Text != "--SELECT CURRENCY--")
            {
                ObjEntityLeadDiv.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
            }

            ddlStatus.Focus();
        }

    }

    //EVM-0016
    public void ReadDivision()
    {

       
        clsBusinessLayerReports objBusinessLayerReports = new clsBusinessLayerReports();

        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityLeadDiv.User_Id = Convert.ToInt32(Session["USERID"]);
        }

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityLeadDiv.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityLeadDiv.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtdivision = ObjBussinessReport.Read_Division(ObjEntityLeadDiv);
        if (dtdivision.Rows.Count > 0)
        {
            ddlDivision.DataSource = dtdivision;
            ddlDivision.DataTextField = "CPRDIV_NAME";
            ddlDivision.DataValueField = "CPRDIV_ID";
            ddlDivision.DataBind();

        }

        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
    }
    //EVM-0016


    public static string ConvertDataTableToHTML(DataTable dt, clsEntityReports ObjLeadReport)
    {
        string strReturn = "";
        decimal sum = 0;

        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon ObjEntityCommon = new clsEntityCommon();
        clsBusinessLayerReports ObjBussinessReports = new clsBusinessLayerReports();

        string strRandom = objCommon.Random_Number();

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                               clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                                  };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, ObjLeadReport.Corporate_Id);
        if (dtCorpDetail.Rows.Count > 0)
        {
            ObjEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
        }
        string strHtml = "";
        StringBuilder sb = new StringBuilder();

        if (dt.Rows.Count > 0)
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                if (dt.Rows[intRowBodyCount]["LDQUOT_ID"].ToString() != "")
                {
                    ObjLeadReport.LdQtnId = Convert.ToInt32(dt.Rows[intRowBodyCount]["LDQUOT_ID"].ToString());
                }
                DataTable dtGrp = ObjBussinessReports.ReadGroupAmount(ObjLeadReport);

                strHtml += "<tr>";

                strHtml += "<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][0].ToString() + "</td>";
                strHtml += "<td class=\"tr_c\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][1].ToString() + "</td>";
                strHtml += "<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";
                strHtml += "<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][3].ToString() + "</td>";
                strHtml += "<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][4].ToString() + "</td>";
                strHtml += "<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][5].ToString() + "</td>";
                strHtml += "<td class=\"tr_c\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][6].ToString() + "</td>";
                strHtml += "<td class=\"tr_l\" style=\"word-break: break-all; word-wrap:break-word;\" >" + dt.Rows[intRowBodyCount][7].ToString() + "</td>";

                if (dtGrp.Rows.Count > 0)
                {
                    strHtml += "<td class=\"tr_r\" style=\"word-break: break-all; word-wrap:break-word;\" >";
                    strHtml += "<table cellspacing=\"0\" style=\"width: 100%;\" cellpadding=\"2px\" >";
                    for (int intLoopCount = 0; intLoopCount < dtGrp.Rows.Count; intLoopCount++)
                    {
                        ObjLeadReport.GroupName = dtGrp.Rows[intLoopCount]["QTNDTLGRP_NAME"].ToString();
                        string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"].ToString(), ObjEntityCommon);
                        strHtml += "<tr>";
                        strHtml += "<td class=\"tr_r\" style=\"word-break: break-all; word-wrap:break-word;\" >" + strNetAmountWithComma + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"] + "(" + dtGrp.Rows[intLoopCount]["QTNDTLGRP_NAME"].ToString() + ")</td>";
                        strHtml += "</tr>";
                    }
                    strHtml += "</table>";
                    strHtml += "</td>";
                }
                else
                {
                    string strAmount = "0.00";

                    if (dt.Rows[intRowBodyCount][8].ToString() != "")
                    {
                        strAmount = dt.Rows[intRowBodyCount][8].ToString();
                    }
                    string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strAmount, ObjEntityCommon);
                    strHtml += "<td class=\"tr_r\" style=\"word-break: break-all; word-wrap:break-word;\" >" + strNetAmountWithComma.ToString() + "    " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                    if (dt.Rows[intRowBodyCount][8].ToString() != null && dt.Rows[intRowBodyCount][8].ToString() != "")
                    {
                        sum = sum + Convert.ToDecimal((dt.Rows[intRowBodyCount][8].ToString()));
                    }
                }

                strHtml += "</tr>";
            }
        }
        else
        {
            strHtml += "<td class=\"tr_c\" colspan=\"9\">No data available in table</td>";
        }

        sb.Append(strHtml);

        strReturn = sb.ToString();

        return strReturn;
    }

    public void ReadCustom()
    {

        if (Session["USERID"] != null)
        {
            ObjEntityLeadDiv.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityLeadDiv.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityLeadDiv.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtCust = ObjBussinessReport.ReadCustomer(ObjEntityLeadDiv);
        if (dtCust.Rows.Count > 0)
        {
            ddlCustomer.DataSource = dtCust;
            ddlCustomer.DataTextField = "CSTMR_NAME";
            ddlCustomer.DataValueField = "CSTMR_ID";
            ddlCustomer.DataBind();
        }

        ddlCustomer.Items.Insert(0, "--SELECT CUSTOMER NAME--");
    }

    public void ReadProject()
    {
        if (Session["USERID"] != null)
        {
            
            ObjEntityLeadDiv.User_Id = Convert.ToInt32(Session["USERID"]);
        }

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityLeadDiv.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityLeadDiv.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtCust = ObjBussinessReport.ReadProject(ObjEntityLeadDiv);

        if (dtCust.Rows.Count > 0)
        {
            ddlProject.DataSource = dtCust;
            ddlProject.DataTextField = "PROJECT_NAME";
            ddlProject.DataValueField = "PROJECT_ID";
            ddlProject.DataBind();

        }

        ddlProject.Items.Insert(0, "--SELECT PROJECT NAME--");
    }

    public void ReadStatus()
    {

        if (Session["USERID"] != null)
        {
           
            ObjEntityLeadDiv.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityLeadDiv.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityLeadDiv.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtCust = ObjBussinessReport.ReadStatus(ObjEntityLeadDiv);

        if (dtCust.Rows.Count > 0)
        {
            ddlStatus.DataSource = dtCust;
            ddlStatus.DataTextField = "LDSTS_NAME";
            ddlStatus.DataValueField = "LDSTS_ID";
            ddlStatus.DataBind();

        }

        ddlStatus.Items.Insert(0, "--SELECT STATUS--");
    }

    public void ReadEmployee()
    {

        if (Session["USERID"] != null)
        {
            //intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityLeadDiv.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityLeadDiv.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityLeadDiv.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtCust = ObjBussinessReport.ReadEmployee(ObjEntityLeadDiv);

        if (dtCust.Rows.Count > 0)
        {
            ddlEmployee.DataSource = dtCust;
            ddlEmployee.DataTextField = "USR_NAME";
            ddlEmployee.DataValueField = "USR_ID";
            ddlEmployee.DataBind();

        }

        ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE NAME--");
    }

    public string ConvertDataTableForPrint(DataTable dt, DataTable dtcorp, clsEntityReports ObjEntityLead,string cust,string project,string status,string emp)
    {
        clsEntityReports ObjLeadReport = new clsEntityReports();
        clsBusinessLayerReports ObjBussinessReports = new clsBusinessLayerReports();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjLeadReport.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Daily Open Lead Report For Division Manager";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        //for printing product division on print
        string strDivision = ddlDivision.SelectedItem.Text;

        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        ObjEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrency.Value);
        StringBuilder sbCap = new StringBuilder();
        if (dtcorp.Rows.Count > 0)
        {
            strCompanyName = dtcorp.Rows[0]["CORPRT_NAME"].ToString();
            strCompanyAddr1 = dtcorp.Rows[0]["CORPRT_ADDR1"].ToString();
            strCompanyAddr2 = dtcorp.Rows[0]["CORPRT_ADDR2"].ToString();
            strCompanyAddr3 = dtcorp.Rows[0]["CORPRT_ADDR3"].ToString();
            strCompanyAddrCntry = dtcorp.Rows[0]["CNTRY_NAME"].ToString();
        }
       
        string strCompanyAddr = objClsCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);

        string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr + "</td></tr>";
        string strCaptionTabRprtDate = "", strCaptionTabTitle = "", strcust = "", strproj = "", strstat = "", stremp = "", strDivis = "", strcur = "", strusername="";
        if (dat != "")
        {
            strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        }

        if (strTitle != "")
        {
            strCaptionTabTitle = "<tr><td class=\"CapTitle\">Daily Open Lead Report For Division Manager</td></tr>";
        }
        if (cust != "" && cust != "--SELECT CUSTOMER NAME--")
        {
            strcust = "<tr><td class=\"RprtDiv\">" + "<B>Customer Name : </B>"+cust + "</td></tr>";

        }

        if (project != "" && project != "--SELECT PROJECT NAME--")
        {
            strproj = "<tr><td class=\"RprtDiv\">" +"<B>Project Name : </B>"+project + "</td></tr>";

        }
        if (status != "" && status != "--SELECT STATUS--")
        {
            strstat = "<tr><td class=\"RprtDiv\">" + "<B>Status : </B>"+ status + "</td></tr>";

        }
        if (strDivision != "" && strDivision != "--SELECT DIVISION--")
        {
            strDivis = "<tr><td class=\"RprtDiv\">" + "<B>Division : </B>" + strDivision + "</td></tr>";
        }
        if (emp != "" && emp !="--SELECT EMPLOYEE NAME--")
        {
            stremp = "<tr><td class=\"RprtDiv\">" + "<B>Employee Name : </B>"+ emp + "</td></tr>";
        }

        //evm-0020
        string strCurrency = ddlCurrency.SelectedItem.Text;
        if (strCurrency != "--SELECT CURRENCY--")
        {
            strcur = "<tr><td class=\"RprtDiv\">" + "<B>Currency : </B>" + strCurrency + "</td></tr>";
        }

        string UserName = "";
        if (Session["USERFULLNAME"] != null)
        {
            UserName = Session["USERFULLNAME"].ToString();
            strusername = "<tr><td class=\"RprtDiv\">" + "<B>Report Generated By : </B>" + UserName + "</td></tr>";
        }

        string strCaptionTabstop = "</table></br>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate  + strcust + strproj + strstat + strDivis + stremp + strcur + strusername+ strCaptionTabTitle + strCaptionTabstop;


        sbCap.Append(strPrintCaptionTable);
        ////write to  divPrintCaption
        //divPrintCaption.InnerHtml = sbCap.ToString();

         StringBuilder sb = new StringBuilder();
         
          string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";
        strHtml += "<th class=\"thT\" style=\"width:6%;text-align: left; word-wrap:break-word;\">SL# </th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:67px;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:67px;text-align: CENTER; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:70px;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:80px;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:90px;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:80px;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\"  style=\"width:67px;text-align: CENTER; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\"  style=\"width:100px;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 8)
            {
                strHtml += "<th class=\"thT\"  style=\"width:67px;text-align: right; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

        }

        strHtml += "</tr>";
        strHtml += "</thead>";

        //add rows

        strHtml += "<tbody>";
        if (dt.Rows.Count > 0)
        {
            int totRowCnt = dt.Rows.Count;
            int first = (Convert.ToInt32(hiddenNext.Value) - 1) * 100;
            int last = Convert.ToInt32(hiddenNext.Value) * 100;
            if (last > totRowCnt)
            {
                last = first + totRowCnt - first;
            }

            for (int intRowBodyCount = first; intRowBodyCount < last; intRowBodyCount++)
            {
                if (dt.Rows[intRowBodyCount]["LDQUOT_ID"].ToString() != "")
                {
                    ObjLeadReport.LdQtnId = Convert.ToInt32(dt.Rows[intRowBodyCount]["LDQUOT_ID"].ToString());
                }
                DataTable dtGrp = ObjBussinessReports.ReadGroupAmount(ObjLeadReport);


                strHtml += "<tr id=\"TableRprtRow\" >";
                int num2 = intRowBodyCount + 1;
                strHtml += "<td class=\"tdT\" style=\" width:6%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + num2 + "</td>";
                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    DateTime dateExDate = DateTime.MinValue;
                    string strCurrentDate = objBusiness.LoadCurrentDateInString();
                    DateTime dateCurrntdte = objCommon.textToDateTime(strCurrentDate);
                    if (intColumnBodyCount == 0)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:67px;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:67px;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:70px;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }

                    else if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:80px;word-break: break-all; word-wrap:break-word;text-align: left;\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:90px;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";


                    }
                    else if (intColumnBodyCount == 5)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:80px;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                    }
                    else if (intColumnBodyCount == 6)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:67px;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                    }
                    else if (intColumnBodyCount == 7)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:100px;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                    }
                    else if (intColumnBodyCount == 8)
                    {
                        if (dtGrp.Rows.Count > 0)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:67px;word-break: break-all; word-wrap:break-word;text-align: right;\" ><table cellspacing=\"0\" style=\"width: 100%;\" cellpadding=\"2px\" >";
                            for (int intLoopCount = 0; intLoopCount < dtGrp.Rows.Count; intLoopCount++)
                            {
                                ObjLeadReport.GroupName = dtGrp.Rows[intLoopCount]["QTNDTLGRP_NAME"].ToString();
                                strHtml += "<tr><td class=\"tdT\" style=\"  width:100%;word-break: break-all; word-wrap:break-word;border-right: none;padding-right: 0px;padding-left: 0px;text-align: right; border: none;\" >" + dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"].ToString() + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"] + "(" + dtGrp.Rows[intLoopCount]["QTNDTLGRP_NAME"].ToString() + ")</td></tr>";
                            }
                            strHtml += "</table></td>";
                        }
                        else
                        {
                            string strAmount = "0.00";

                            if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() != "")
                            {
                                strAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                            }


                            string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strAmount, ObjEntityCommon);

                            strHtml += "<td class=\"tdT\" style=\" width:67px;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strNetAmountWithComma.ToString() + "    " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                            if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() != null && dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() != "")
                            {
                                sum2 = sum2 + Convert.ToDecimal((dt.Rows[intRowBodyCount][intColumnBodyCount].ToString()));
                            }
                        }
                    }


                }
                strHtml += "</tr>";
            }

            strHtml += "</tbody>";

            //strHtml += "<tfoot>";
            //strHtml += "<td  class=\"thT\" colspan=\"9\"; style=\" border-right: navajowhite;width:6%;word-break: break-all; word-wrap:break-word;text-align: left;\" >TOTAL</td>";
            //string stamt = sum2.ToString();
            //string strNetAmo = objBusiness.AddCommasForNumberSeperation(stamt, ObjEntityCommon);
            //strHtml += "<th style=text-align:right;>" + strNetAmo + "   " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</th></tr";
            //strHtml += "</tfoot>";
        }
        else
        {
            strHtml += "<tr id=\"TableRprtRow\" >";
            strHtml += "<tfoot>";
            //strHtml += "<td  class=\"thT\" colspan=\"10\"; style=\" border-right: navajowhite;font-size: large;width:6%;word-break: break-all; word-wrap:break-word;text-align: left;\" > NO DATA AVAILABALE..</td>";
            strHtml += "<td  class=\"thT\" colspan=\"10\" style=\" border-right: navajowhite;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
           
            strHtml += "</tfoot>";
        }
        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();

    }
    //EVM-0016
    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDivision.SelectedItem.Value == "--SELECT DIVISION--")
        {
            ReadEmployee();
        }
        else
        {
            if (Session["USERID"] != null)
            {
                // intUserId = Convert.ToInt32(Session["USERID"]);
                ObjEntityLeadDiv.User_Id = Convert.ToInt32(Session["USERID"]);
            }

            if (Session["CORPOFFICEID"] != null)
            {
                ObjEntityLeadDiv.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                ObjEntityLeadDiv.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (ddlDivision.SelectedItem.Text != "--SELECT DIVISION--")
            {
                ObjEntityLeadDiv.Division_Id = Convert.ToInt32(ddlDivision.SelectedItem.Value);
                DataTable dtReadEmploye = new DataTable();
                dtReadEmploye = ObjBussinessReport.ReadEmployeeByDivisionId(ObjEntityLeadDiv);
                ddlEmployee.Items.Clear();

                if (dtReadEmploye.Rows.Count > 0)
                {
                    ddlEmployee.DataSource = dtReadEmploye;
                    ddlEmployee.DataTextField = "USR_NAME";
                    ddlEmployee.DataValueField = "USR_ID";
                    ddlEmployee.DataBind();

                }
                ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE NAME--");
            }
        }
    }
    //EVM-0016


    //evm-0020
    public void ReadCurrency()
    {
        ddlCurrency.Items.Clear();

        clsBusinessLayerReports ObjBussinessReport = new clsBusinessLayerReports();
        clsEntityReports ObjEntityLeadDiv = new clsEntityReports();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityLeadDiv.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityLeadDiv.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        DataTable dtTerms = ObjBussinessReport.ReadCurrencyLoad(ObjEntityLeadDiv);

        ddlCurrency.DataSource = dtTerms;
        ddlCurrency.DataTextField = "CRNCMST_NAME";
        ddlCurrency.DataValueField = "CRNCMST_ID";
        ddlCurrency.DataBind();
        ddlCurrency.Items.Insert(0, "--SELECT CURRENCY--");


        //if (hiddenDfltCurrency.Value != "")
        //{
        //    ddlCurrency.Items.FindByValue(hiddenDfltCurrency.Value).Selected = true;
        //}


        clsEntityCommon ObjEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.COUNTRY_ICON_IMAGES);
        
        if (ddlCurrency != null)
        {
            foreach (System.Web.UI.WebControls.ListItem li in ddlCurrency.Items)
            {
                if (li.Text != "--SELECT CURRENCY--")
                {
                    ObjEntityCommon.CurrencyId = Convert.ToInt32(li.Value);
                    DataTable dtCurrencyDtls = objBusinessLayer.ReadCurrencyDetails(ObjEntityCommon);

                    li.Attributes["data-imagecss"] = "flag ad";
                    li.Attributes["title"] = li.Text;
                    if (dtCurrencyDtls.Rows[0]["CNTRY_FLAG_ICON_NAME"].ToString() != "")
                    {
                        li.Attributes["data-image"] = strImagePath + dtCurrencyDtls.Rows[0]["CNTRY_FLAG_ICON_NAME"].ToString();
                    }
                }
            }
        }

    }


    //------------------------------------------Pagination------------------------------------------------

    [WebMethod]
    public static string[] GetData(string OrgId, string CorpId, string UserId, string ddlStatus, string Customer, string Project, string Division, string Employee, string Currency, string PageNumber, string PageMaxSize, string strCommonSearchTerm, string OrderColumn, string OrderMethod, string strInputColumnSearch)
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        clsBusinessLayerReports ObjBussinessReport = new clsBusinessLayerReports();
        clsEntityReports ObjEntityLeadDiv = new clsEntityReports();

        clsCommonLibrary objCommon = new clsCommonLibrary();

        string[] strResults = new string[3];
        try
        {
            if (OrgId != null && OrgId != "")
            {
                ObjEntityLeadDiv.Organisation_Id = Convert.ToInt32(OrgId);
            }
            if (CorpId != null && CorpId != "")
            {
                ObjEntityLeadDiv.Corporate_Id = Convert.ToInt32(CorpId);
            }
            if (UserId != null && UserId != "")
            {
                ObjEntityLeadDiv.User_Id = Convert.ToInt32(UserId);
            }

            if (ddlStatus != "" && ddlStatus != "--SELECT STATUS--")
            {
                ObjEntityLeadDiv.StatusId = Convert.ToInt32(ddlStatus);
            }
            if (Customer != "" && Customer != "--SELECT CUSTOMER NAME--")
            {
                ObjEntityLeadDiv.CustomerId = Convert.ToInt32(Customer);
            }
            if (Project != "" && Project != "--SELECT PROJECT NAME--")
            {
                ObjEntityLeadDiv.ProjectId = Convert.ToInt32(Project);
            }
            if (Division != "" && Division != "--SELECT DIVISION--")
            {
                ObjEntityLeadDiv.Division_Id = Convert.ToInt32(Division);
            }
            if (Employee != "" && Employee != "--SELECT EMPLOYEE NAME--")
            {
                ObjEntityLeadDiv.EmployeeId = Convert.ToInt32(Employee);
            }
            if (Currency != "" && Currency != "--SELECT CURRENCY--")
            {
                ObjEntityLeadDiv.CurrencyId = Convert.ToInt32(Currency);
            }

            ObjEntityLeadDiv.PageNumber = Convert.ToInt32(PageNumber);
            ObjEntityLeadDiv.PageMaxSize = Convert.ToInt32(PageMaxSize);
            ObjEntityLeadDiv.OrderMethod = Convert.ToInt32(OrderMethod);
            ObjEntityLeadDiv.OrderColumn = Convert.ToInt32(OrderColumn);
            ObjEntityLeadDiv.CommonSearchTerm = strCommonSearchTerm;

            var values = Enum.GetValues(typeof(SearchInputColumns));
            int intSearchColumnCount = values.Length;

            string[] strSearchInputs = new string[intSearchColumnCount];
            //— ‡
            if (strInputColumnSearch != "")
            {
                string[] InputColumnSearchList = strInputColumnSearch.Split('—');
                foreach (var InputColumnSearch in InputColumnSearchList)
                {
                    string[] strColumnSrch = InputColumnSearch.Split('‡');
                    int intColumnNo = Convert.ToInt32(strColumnSrch[0]);
                    string strSearchString = strColumnSrch[1];

                    if (intColumnNo <= intSearchColumnCount)
                    {
                        strSearchInputs[intColumnNo] = strSearchString;
                    }
                }
            }

            ObjEntityLeadDiv.SearchRef = strSearchInputs[Convert.ToInt32(SearchInputColumns.REF)];
            ObjEntityLeadDiv.SearchDate = strSearchInputs[Convert.ToInt32(SearchInputColumns.DATE)];
            ObjEntityLeadDiv.SearchAssignTo = strSearchInputs[Convert.ToInt32(SearchInputColumns.ASSIGNTO)];
            ObjEntityLeadDiv.SearchProject = strSearchInputs[Convert.ToInt32(SearchInputColumns.PROJECT)];
            ObjEntityLeadDiv.SearchCustomer = strSearchInputs[Convert.ToInt32(SearchInputColumns.CUSTOMER)];
            ObjEntityLeadDiv.SearchStatus = strSearchInputs[Convert.ToInt32(SearchInputColumns.STATUS)];
            ObjEntityLeadDiv.SearchQuotRef = strSearchInputs[Convert.ToInt32(SearchInputColumns.QUOTREF)];

            //ReadList
            DataTable dt = ObjBussinessReport.getDataLeadDivision(ObjEntityLeadDiv);

            string strTableContents = "";
            strTableContents = ConvertDataTableToHTML(dt, ObjEntityLeadDiv);
            strResults[0] = strTableContents;

            strResults[1] = dt.Rows.Count.ToString();

            if (dt.Rows.Count > 0)
            {
                int intTotalItems = Convert.ToInt32(dt.Rows[0]["CNT"].ToString());
                int intCurrentRowCount = dt.Rows.Count;

                strResults[1] = intTotalItems.ToString();
                //Pagination
                strResults[2] = objBusinessLayer.GenereatePagination(intTotalItems, ObjEntityLeadDiv.PageNumber, ObjEntityLeadDiv.PageMaxSize, intCurrentRowCount);
            }
        }
        catch (Exception ex)
        {
            clsBusineesLayerException objBusinessLayerException = new clsBusineesLayerException();
            objBusinessLayerException.ExceptionHandling(ex);
            throw ex;
        }

        return strResults;
    }

    [WebMethod]
    public static string[] LoadStaticDatafordt()//Filters
    {
        StringBuilder html = new StringBuilder();
        StringBuilder sbSearchInputColumns = new StringBuilder();

        string[] strResults = new string[3];
        html.Append("<div>");

        html.Append("<div class=\"col-md-2\">");//length
        html.Append("<p><span class=\"tbl_srt1\">Show</span> <select class=\"form-control tbl_srt\" onchange=\"getdata(1);\" id=\"ddl_page_size\">");
        html.Append("<option value=\"10\">10</option><option value=\"25\">25</option><option value=\"50\">50</option><option value=\"100\">100</option></select> entries");
        html.Append("</p></div>");
        //page length ends
        //common filter
        html.Append("<div class=\"col-md-2 pull-right\">");
        html.Append("<input  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"SettypingTimer();\" class=\"form-control tbl_ser_n\" id=\"txtCommonSearch_dt\"  type=\"search\" placeholder=\" Search \" aria-controls=\"example\">");
        html.Append("</div>");
        //common filter ends
        html.Append("</div>");
        strResults[0] = html.ToString();

        //custom search fields
        var values = Enum.GetValues(typeof(SearchInputColumns));
        int intSearchColumnCount = values.Length;

        foreach (var item in values)
        {
            int Item = Convert.ToInt32(item);
            // use item number to customize names using if
            if (Item.ToString() == "0")
            {
                sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" onclick=\"SetOrderByValue(1)\" class=\"sorting th_b1 tr_l\">Ref#<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>");
                sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Ref#\" title=\"Ref#\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                sbSearchInputColumns.Append("</th>");
            }
            if (Item.ToString() == "1")
            {
                sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" onclick=\"SetOrderByValue(1)\" class=\"sorting th_b8\">Opportunity Date<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>");
                sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Opportunity Date\" title=\"Opportunity Date\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                sbSearchInputColumns.Append("</th>");
            }
            if (Item.ToString() == "2")
            {
                sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" onclick=\"SetOrderByValue(1)\" class=\"sorting th_b8 tr_l\">Assigned To<br><i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>");
                sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Assigned To\" title=\"Assigned To\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                sbSearchInputColumns.Append("</th>");
            }
            if (Item.ToString() == "3")
            {
                sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" onclick=\"SetOrderByValue(1)\" class=\"sorting th_b2 tr_l\">Project<br><i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>");
                sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Project\" title=\"Project\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                sbSearchInputColumns.Append("</th>");
            }
            if (Item.ToString() == "4")
            {
                sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" onclick=\"SetOrderByValue(1)\" class=\"sorting th_b4 tr_l\">Customer<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>");
                sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Customer\" title=\"Customer\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                sbSearchInputColumns.Append("</th>");
            }
            if (Item.ToString() == "5")
            {
                sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" onclick=\"SetOrderByValue(1)\" class=\"sorting th_b4 tr_c\">Opportunity Status<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>");
                sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Opportunity Status\" title=\"Opportunity Status\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                sbSearchInputColumns.Append("</th>");
            }
            if (Item.ToString() == "6")
            {
                sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" class=\"th_b7 tr_c\">Last<br> Updation</th>");
            }
            if (Item.ToString() == "7")
            {
                sbSearchInputColumns.Append("<th id=\"tdColumnHead_" + (Item + 1) + "\" onclick=\"SetOrderByValue(1)\" class=\"sorting th_b7 tr_l\">Quote Ref#<br><i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>");
                sbSearchInputColumns.Append("<input id=\"txtSearchColumn_" + Item + "\" type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Quote Ref#\" title=\"Quote Ref#\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\">");
                sbSearchInputColumns.Append("</th>");
            }
        }
        sbSearchInputColumns.Append("<th id=\"tdColumnHead_9\" class=\"th_b7 tr_r\">Quote Value</th>");

        //this is to adjust the non search  fields
        strResults[1] = sbSearchInputColumns.ToString();
        strResults[2] = intSearchColumnCount.ToString();
        return strResults;
    }

    public enum SearchInputColumns
    {
        //Must be sequential 
        REF = 0,
        DATE = 1,
        ASSIGNTO = 2,
        PROJECT = 3,
        CUSTOMER = 4,
        STATUS = 5,
        LSTUPDTN = 6,
        QUOTREF = 7,
    }

    //------------------------------------------Pagination------------------------------------------------

    [WebMethod]
    public static string PrintList(string OrgId, string CorpId, string UserId, string ddlStatus, string Customer, string Project, string Division, string Employee, string Currency, string ddlStatusText, string CustomerText, string ProjectText, string DivisionText, string EmployeeText, string CurrencyText)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        clsBusinessLayerReports ObjBussinessReport = new clsBusinessLayerReports();
        clsEntityReports ObjEntityLeadDiv = new clsEntityReports();

        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                               clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                                  };

        if (OrgId != null && OrgId != "")
        {
            ObjEntityLeadDiv.Organisation_Id = Convert.ToInt32(OrgId);
        }
        if (CorpId != null && CorpId != "")
        {
            ObjEntityLeadDiv.Corporate_Id = Convert.ToInt32(CorpId);
        }
        if (UserId != null && UserId != "")
        {
            ObjEntityLeadDiv.User_Id = Convert.ToInt32(UserId);
        }

        if (ddlStatus != "" && ddlStatus != "--SELECT STATUS--")
        {
            ObjEntityLeadDiv.StatusId = Convert.ToInt32(ddlStatus);
        }
        if (Customer != "" && Customer != "--SELECT CUSTOMER NAME--")
        {
            ObjEntityLeadDiv.CustomerId = Convert.ToInt32(Customer);
        }
        if (Project != "" && Project != "--SELECT PROJECT NAME--")
        {
            ObjEntityLeadDiv.ProjectId = Convert.ToInt32(Project);
        }
        if (Division != "" && Division != "--SELECT DIVISION--")
        {
            ObjEntityLeadDiv.Division_Id = Convert.ToInt32(Division);
        }
        if (Employee != "" && Employee != "--SELECT EMPLOYEE NAME--")
        {
            ObjEntityLeadDiv.EmployeeId = Convert.ToInt32(Employee);
        }
        if (Currency != "" && Currency != "--SELECT CURRENCY--")
        {
            ObjEntityLeadDiv.CurrencyId = Convert.ToInt32(Currency);
        }

        DataTable dt = ObjBussinessReport.getDataLeadDivision(ObjEntityLeadDiv);

        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, ObjEntityLeadDiv.Corporate_Id);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
        }

        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.OPEN_DM_REPORT_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.OPEN_DM_REPORT_PDF);
        objEntityCommon.CorporateID = ObjEntityLeadDiv.Corporate_Id;
        objEntityCommon.Organisation_Id = ObjEntityLeadDiv.Organisation_Id;
        string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "OpenDMReport_" + strNextNumber + ".pdf";

        Document document = new Document(PageSize.A4, 50f, 40f, 120f, 30f);
        document = new Document(PageSize.LETTER, 50f, 40f, 20f, 40f);
        Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
        try
        {
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                PdfWriter writer = PdfWriter.GetInstance(document, file);
                writer.PageEvent = new PDFHeader();
                document.Open();


                PdfPTable footrtable = new PdfPTable(3);
                float[] footrsBody1 = { 20, 5, 75 };
                footrtable.SetWidths(footrsBody1);
                footrtable.WidthPercentage = 100;

                if (ddlStatus != "" && ddlStatus != "--SELECT STATUS--")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("STATUS  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(ddlStatusText, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (Customer != "" && Customer != "--SELECT CUSTOMER NAME--")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("CUSTOMER  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(CustomerText, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (Project != "" && Project != "--SELECT PROJECT NAME--")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("PROJECT  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(ProjectText, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (Division != "" && Division != "--SELECT DIVISION--")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("DIVISION  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(DivisionText, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (Employee != "" && Employee != "--SELECT EMPLOYEE NAME--")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("EMPLOYEE  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(EmployeeText, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (Currency != "" && Currency != "--SELECT CURRENCY--")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("CURRENCY  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(CurrencyText, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }

                document.Add(footrtable);


                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(9);
                float[] footrsBody = { 10, 10, 12, 13, 15, 10, 8, 7, 15 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("REF#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("Opportunity Date", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("Assigned To", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("Project", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("Customer", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("Opportunity Status", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("Last Updation", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("Quote Ref#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("Quote Value", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });

                if (dt.Rows.Count > 0)
                {
                    for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
                    {
                        if (dt.Rows[intRowBodyCount]["LDQUOT_ID"].ToString() != "")
                        {
                            ObjEntityLeadDiv.LdQtnId = Convert.ToInt32(dt.Rows[intRowBodyCount]["LDQUOT_ID"].ToString());
                        }
                        DataTable dtGrp = ObjBussinessReport.ReadGroupAmount(ObjEntityLeadDiv);

                        TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount][0].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount][1].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount][2].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount][3].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount][4].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount][5].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount][6].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount][7].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                        if (dtGrp.Rows.Count > 0)
                        {
                            for (int intLoopCount = 0; intLoopCount < dtGrp.Rows.Count; intLoopCount++)
                            {
                                ObjEntityLeadDiv.GroupName = dtGrp.Rows[intLoopCount]["QTNDTLGRP_NAME"].ToString();
                                string strNetAmountWithComma = objBusinessLayer.AddCommasForNumberSeperation(dtGrp.Rows[intLoopCount]["QTNDTLGRP_NET_AMT"].ToString(), objEntityCommon);
                                TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithComma + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"] + "(" + dtGrp.Rows[intLoopCount]["QTNDTLGRP_NAME"].ToString() + ")", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            }
                        }
                        else
                        {
                            string strAmount = "0.00";

                            if (dt.Rows[intRowBodyCount][8].ToString() != "")
                            {
                                strAmount = dt.Rows[intRowBodyCount][8].ToString();
                            }
                            string strNetAmountWithComma = objBusinessLayer.AddCommasForNumberSeperation(strAmount, objEntityCommon);
                            TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountWithComma.ToString() + "    " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }

                    }
                }
                else
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase("No data available in table", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 9 });
                }
                document.Add(TBCustomer);
                document.Close();
                strRet = strImagePath + strImageName;
            }
        }
        catch (Exception)
        {
            document.Close();
            strRet = "";
        }
        return strRet;
    }
    public class PDFHeader : PdfPageEventHelper
    {
        PdfContentByte cb;
        PdfTemplate footerTemplate;
        BaseFont bf = null;
        DateTime PrintTime = DateTime.Now;
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                PrintTime = DateTime.Now;
                bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb = writer.DirectContent;
                footerTemplate = cb.CreateTemplate(200, 200);
            }
            catch (DocumentException de)
            {
                //handle exception here
            }
            catch (System.IO.IOException ioe)
            {
                //handle exception here
            }
        }
        public override void OnStartPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityCommon ObjEntityCommon = new clsEntityCommon();
            clsBusinessLayer objDataCommon = new clsBusinessLayer();
            ObjEntityCommon.CorporateID = Convert.ToInt32(HttpContext.Current.Session["CORPOFFICEID"].ToString());
            ObjEntityCommon.Organisation_Id = Convert.ToInt32(HttpContext.Current.Session["ORGID"].ToString());
            DataTable dtCorp = objDataCommon.ReadCorpDetails(ObjEntityCommon);
            string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "";
            string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DEFAULT_LOGO);
            if (dtCorp.Rows.Count > 0)
            {
                if (dtCorp.Rows[0]["CORPRT_ICON"].ToString() != "")
                {
                    string imaeposition = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
                    string icon = dtCorp.Rows[0]["CORPRT_ICON"].ToString();
                    strImageLogo = imaeposition + icon;
                }
                strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
                strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
                strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
                strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
            }
            string strAddress = "";
            strAddress = strCompanyAddr1;
            if (strCompanyAddr2 != "")
            {
                strAddress += ", " + strCompanyAddr2;
            }
            if (strCompanyAddr3 != "")
            {
                strAddress += ", " + strCompanyAddr3;
            }
            //Head Table
            PdfPTable headtable = new PdfPTable(2);
            headtable.AddCell(new PdfPCell(new Phrase("Open Opportunities for Division Manager", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            if (strImageLogo != "")
            {
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
                image.ScalePercent(PdfPCell.ALIGN_CENTER);
                image.ScaleToFit(60f, 40f);
                headtable.AddCell(new PdfPCell(image) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
            }
            else
            {
                headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            }
            headtable.AddCell(new PdfPCell(new Phrase(strCompanyName, new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            headtable.AddCell(new PdfPCell(new Phrase(strAddress, new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            headtable.AddCell(new PdfPCell(new Phrase("______________________________________________________________________________________________________", new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 2 });
            headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 2 });
            float[] headersHeading = { 80, 20 };
            headtable.SetWidths(headersHeading);
            headtable.WidthPercentage = 100;
            document.Add(headtable);
            PdfPTable tableLine = new PdfPTable(1);
            float[] tableLineBody = { 100 };
            tableLine.SetWidths(tableLineBody);
            tableLine.WidthPercentage = 100;
            tableLine.TotalWidth = 650F;
            tableLine.AddCell(new PdfPCell(new Phrase("_____________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
            float pos9 = writer.GetVerticalPosition(false);
        }
        public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            // base.OnEndPage(writer, document);
            string strUsername = HttpContext.Current.Session["USERFULLNAME"].ToString();
            PdfPTable table3 = new PdfPTable(1);
            float[] tableBody3 = { 100 };
            table3.SetWidths(tableBody3);
            table3.WidthPercentage = 100;
            table3.TotalWidth = 650F;
            table3.AddCell(new PdfPCell(new Phrase("_________________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
            // document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
            PdfPTable headImg = new PdfPTable(3);
            string strImageLogo = "/Images/Design_Images/images/Compztlogo.png";
            //headImg.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 3 });

            headImg.AddCell(new PdfPCell(new Phrase("______________________________________________________________________________________________________", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 3, PaddingTop = 5 });
            if (strImageLogo != "")
            {
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
                image.ScalePercent(PdfPCell.ALIGN_CENTER);
                image.ScaleToFit(60f, 40f);
                headImg.AddCell(new PdfPCell(image) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_TOP });
            }

            headImg.AddCell(new PdfPCell(new Paragraph("Report generated in Compzit by:" + strUsername + "\nReport generated on:" + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
            headImg.AddCell(new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 3 });
            float[] headersHeading = { 20, 60, 20 };
            headImg.SetWidths(headersHeading);
            headImg.WidthPercentage = 100;
            headImg.TotalWidth = document.PageSize.Width - 80f;

            headImg.WriteSelectedRows(0, -1, 50, document.PageSize.GetBottom(50), writer.DirectContent);

            String text = "Page " + writer.PageNumber + " of ";
            //Add paging to footer
            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.SetTextMatrix(document.PageSize.GetRight(100), document.PageSize.GetBottom(15));
                cb.ShowText(text);
                cb.EndText();
                float len = bf.GetWidthPoint(text, 8);
                cb.AddTemplate(footerTemplate, document.PageSize.GetRight(100) + len, document.PageSize.GetBottom(15));
            }
        }
        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
            footerTemplate.BeginText();
            footerTemplate.SetFontAndSize(bf, 8);
            footerTemplate.SetTextMatrix(0, 0);
            footerTemplate.ShowText((writer.PageNumber).ToString());
            footerTemplate.EndText();
        }
    }


}