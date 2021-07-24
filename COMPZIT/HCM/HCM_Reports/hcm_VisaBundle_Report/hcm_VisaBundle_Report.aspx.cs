using System;
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
// CREATED DATE:11/07/2017
// REVIEWED BY:
// REVIEW DATE:
public partial class HCM_HCM_Reports_Visa_Bundle_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            int intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            clsEntityVisaBundleReports objEntityVisaBundle = new clsEntityVisaBundleReports();
            clsBusinessLayer_VisaBundleReports objBusinessVisaBundle = new clsBusinessLayer_VisaBundleReports();

            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityVisaBundle.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                objEntityVisaBundle.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                hiddenOrgId.Value = Session["ORGID"].ToString();
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                objEntityVisaBundle.UserId = Convert.ToInt32(Session["USERID"].ToString());
                hiddenUserId.Value = Session["USERID"].ToString();
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            DataTable dtCorp = objBusinessVisaBundle.ReadCorporateAddress(objEntityVisaBundle);

            //for viewing table
            objEntityVisaBundle.CorpId = 0;
            objEntityVisaBundle.OrgId = 0;
            DataTable dtVisaQuota = new DataTable();
            dtVisaQuota = objBusinessVisaBundle.ReadVisaQuota(objEntityVisaBundle);

            string strHtm = ConvertDataTableToHTML(dtVisaQuota);
            divReport.InnerHtml = strHtm;

            //for printing table


            string strPrintReport = ConvertDataTableForPrint(dtVisaQuota, dtCorp);
            divPrintReport.InnerHtml = strPrintReport;


        }

    }


    public string ConvertDataTableToHTML(DataTable dt)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:55%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
        }

        strHtml += "<th class=\"thT\" style=\"width:15%; word-wrap:break-word;text-align: center;\">MORE INFO</th>";

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        if (txtFromDate.Text != "" || txtToDate.Text != "")
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                strHtml += "<tr  >";


                string strId = dt.Rows[intRowBodyCount][0].ToString();


                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:55%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                }

                strHtml += "<td class=\"tdT\" style=\"width:15%; word-wrap:break-word;text-align: center;\"><input type=\"button\" class=\"save\" style=\"height:22px;margin-top:3%\" value=\"More Info\" onclick=\"return OpenVisaDetails('" + strId + "');\" /></td>";

                strHtml += "</tr>";
            }
        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
    }





    protected void btnSearch_Click(object sender, EventArgs e)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntityVisaBundleReports objEntityVisaBundle = new clsEntityVisaBundleReports();
        clsBusinessLayer_VisaBundleReports objBusinessVisaBundle = new clsBusinessLayer_VisaBundleReports();

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVisaBundle.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityVisaBundle.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        int intUserId = 0;
        if (Session["USERID"] != null)
        {
            objEntityVisaBundle.UserId = Convert.ToInt32(Session["USERID"].ToString());
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (txtFromDate.Text != null && txtFromDate.Text != "")
        {
            objEntityVisaBundle.FrmDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
        }
        if (txtToDate.Text != null && txtToDate.Text != "")
        {
            objEntityVisaBundle.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
        }

        DataTable dtVisaQuota = new DataTable();
        dtVisaQuota = objBusinessVisaBundle.ReadVisaQuota(objEntityVisaBundle);

        string strHtm = ConvertDataTableToHTML(dtVisaQuota);
        divReport.InnerHtml = strHtm;

        //for printing table

        DataTable dtCorp = objBusinessVisaBundle.ReadCorporateAddress(objEntityVisaBundle);

        string strPrintReport = ConvertDataTableForPrint(dtVisaQuota, dtCorp);
        divPrintReport.InnerHtml = strPrintReport;

    }


    [WebMethod]
    public static string[] VisaBundleDetails(string strVisaId, int intCorpId, int intOrgId, int intUserId)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();

        string[] strJson = new string[10];

        clsEntityVisaBundleReports objEntityVisaBundle = new clsEntityVisaBundleReports();
        clsBusinessLayer_VisaBundleReports objBusinessVisaBundle = new clsBusinessLayer_VisaBundleReports();

        objEntityVisaBundle.VisaQuotaId = Convert.ToInt32(strVisaId);

        objEntityVisaBundle.CorpId = intCorpId;
        objEntityVisaBundle.OrgId = intOrgId;
        objEntityVisaBundle.UserId = intUserId;

        DataTable dtVisaBundleDtls = new DataTable();
        dtVisaBundleDtls = objBusinessVisaBundle.ReadVisaQuotaById(objEntityVisaBundle);

        strJson[0] = dtVisaBundleDtls.Rows[0]["VISQT_NUM"].ToString();
        strJson[1] = dtVisaBundleDtls.Rows[0]["VISQT_ISSUE_DATE"].ToString();
        strJson[2] = dtVisaBundleDtls.Rows[0]["VISQT_EXPIRY_DATE"].ToString();

        //for table on visa details

        DataTable dtVisaDtls = new DataTable();
        dtVisaDtls = objBusinessVisaBundle.ReadVisaDetailsById(objEntityVisaBundle);


        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dtVisaDtls.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:25%;text-align: left; word-wrap:break-word;\">" + dtVisaDtls.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:25%;text-align: center; word-wrap:break-word;\">" + dtVisaDtls.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:30%;text-align: center; word-wrap:break-word;\">" + dtVisaDtls.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: center; word-wrap:break-word;\">" + dtVisaDtls.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
        }
        if (dtVisaDtls.Columns.Count == 0)
        {
            strHtml += "<td class=\"thT\" style=\"width:25%;text-align: left; word-wrap:break-word;\">VISA TYPE</th>";
            strHtml += "<td class=\"thT\" style=\"width:25%;text-align: center; word-wrap:break-word;\">NATION</th>";
            strHtml += "<td class=\"thT\"  style=\"width:30%;text-align: center; word-wrap:break-word;\">COMPANY</th>";
            strHtml += "<td class=\"thT\"  style=\"width:20%;text-align: center; word-wrap:break-word;\">NO. OF VISA</th>";
        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dtVisaDtls.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr  >";

            string strId = dtVisaDtls.Rows[intRowBodyCount][0].ToString();

            for (int intColumnBodyCount = 0; intColumnBodyCount < dtVisaDtls.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtVisaDtls.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtVisaDtls.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtVisaDtls.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtVisaDtls.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
            }
            strHtml += "</tr>";
        }
        if (dtVisaDtls.Rows.Count == 0)
        {
            strHtml += "<td  class=\"thT\" colspan=\"8\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        strJson[3] = sb.ToString();

        //for printing the detail table

        DataTable dtCorp = objBusinessVisaBundle.ReadCorporateAddress(objEntityVisaBundle);

        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Visa Bundle Informations";
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
        strJson[4] = sbCap.ToString();


        dtVisaBundleDtls = objBusinessVisaBundle.ReadVisaQuotaById(objEntityVisaBundle);

        StringBuilder sbBndlDtls = new StringBuilder();
         

        string strbrk = "<br/>";
        string strBundleTbl = "<table>";
        string strBundleNo = "<tr><td><b>BUNDLE NUMBER : " + strJson[0] + "</b></td></tr>";
        string strIssueDt = "<tr><td><b>ISSUED DATE : " + strJson[1] + "</b></td></tr>";
        string strExpiryDt = "<tr><td><b>EXPIRY DATE : " + strJson[2] + "</b></td></tr>";
        string strBndlTblCls = "</table>";
        string strPrintBndlTable = strbrk + strBundleTbl + strBundleNo + strIssueDt + strExpiryDt + strBndlTblCls + strbrk;
        sbBndlDtls.Append(strPrintBndlTable);
        //write to  lblPrintBndlDtls
        strJson[5] = sbBndlDtls.ToString();



        dtVisaDtls = objBusinessVisaBundle.ReadVisaDetailsById(objEntityVisaBundle);

        // class="table table-bordered table-striped"
        StringBuilder sbPrntDtl = new StringBuilder();
        string strHtmlDtl = "<table id=\"PrintTable\" class=\"tab\"  >";
        //add header row
        strHtmlDtl += "<thead>";
        strHtmlDtl += "<tr class=\"top_row\">";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dtVisaDtls.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtmlDtl += "<th class=\"thT\" style=\"width:25%;text-align: left; word-wrap:break-word;\">" + dtVisaDtls.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtmlDtl += "<th class=\"thT\" style=\"width:25%;text-align: center; word-wrap:break-word;\">" + dtVisaDtls.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtmlDtl += "<th class=\"thT\" style=\"width:30%;text-align: center; word-wrap:break-word;\">" + dtVisaDtls.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtmlDtl += "<th class=\"thT\" style=\"width:20%;text-align: center; word-wrap:break-word;\">" + dtVisaDtls.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
        }
        if (dtVisaDtls.Columns.Count == 0)
        {
            strHtmlDtl += "<td class=\"thT\" style=\"width:25%;text-align: left; word-wrap:break-word;\">VISA TYPE</th>";
            strHtmlDtl += "<td class=\"thT\" style=\"width:25%;text-align: center; word-wrap:break-word;\">NATION</th>";
            strHtmlDtl += "<td class=\"thT\"  style=\"width:30%;text-align: center; word-wrap:break-word;\">COMPANY</th>";
            strHtmlDtl += "<td class=\"thT\"  style=\"width:20%;text-align: center; word-wrap:break-word;\">NO. OF VISA</th>";
        }

        strHtmlDtl += "</tr>";
        strHtmlDtl += "</thead>";
        //add rows

        strHtmlDtl += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dtVisaDtls.Rows.Count; intRowBodyCount++)
        {
            strHtmlDtl += "<tr  >";

            string strId = dtVisaDtls.Rows[intRowBodyCount][0].ToString();

            for (int intColumnBodyCount = 0; intColumnBodyCount < dtVisaDtls.Columns.Count; intColumnBodyCount++)
            {
                if (intColumnBodyCount == 1)
                {
                    strHtmlDtl += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtVisaDtls.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtmlDtl += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtVisaDtls.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 3)
                {
                    strHtmlDtl += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtVisaDtls.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 4)
                {
                    strHtmlDtl += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtVisaDtls.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
            }
            strHtmlDtl += "</tr>";
        }
        if (dtVisaDtls.Rows.Count == 0)
        {
            strHtmlDtl += "<td  class=\"thT\" colspan=\"8\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
        }

        strHtmlDtl += "</tbody>";

        strHtmlDtl += "</table>";

        sbPrntDtl.Append(strHtmlDtl);
        //write to  divPrintReportDetails
        strJson[6] = sbPrntDtl.ToString();


        return strJson;

    }



    //It build the Html table by using the datatable provided
    public string ConvertDataTableForPrint(DataTable dt, DataTable dtCorp)
    {
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = " Visa Bundle Report";
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
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:60%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
        }

        if (dt.Columns.Count == 0)
        {
            strHtml += "<td class=\"thT\" style=\"width:60%;text-align: left; word-wrap:break-word;\">BUNDLE NUMBER</th>";
            strHtml += "<td class=\"thT\" style=\"width:20%;text-align: center; word-wrap:break-word;\">ISSUED DATE</th>";
            strHtml += "<td class=\"thT\"  style=\"width:20%;text-align: center; word-wrap:break-word;\">EXPIRY DATE</th>";
        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        if (txtFromDate.Text != "" || txtToDate.Text != "")
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                strHtml += "<tr  >";

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {
                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:60%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                }

                strHtml += "</tr>";
            }
        }
        else 
        {
            strHtml += "<td  class=\"thT\" colspan=\"8\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
        }
        //if (dt.Rows.Count == 0)
        //{
        //    strHtml += "<td  class=\"thT\" colspan=\"8\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
        //}

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
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
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.VISA_BUNDLE_CSV);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
            string newFilePath = Server.MapPath("/CustomFiles/HCM CSV/Visa Bundle/Visa_Bundle_Report_" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "Visa_Bundle_Report_" + strNextId + ".csv";
            Response.ContentType = "csv";
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VISA_BUNDLE_CSV);
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
        clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport = new clsEntityEmployeeDetailsReport();
        DataTable table = new DataTable();
        table.Columns.Add("BUNDLE NUMBER", typeof(string));
        table.Columns.Add("ISSUED DATE ", typeof(string));
        table.Columns.Add("EXPIRY DATE", typeof(string));
        clsEntityVisaBundleReports objEntityVisaBundle = new clsEntityVisaBundleReports();
        clsBusinessLayer_VisaBundleReports objBusinessVisaBundle = new clsBusinessLayer_VisaBundleReports();

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVisaBundle.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityVisaBundle.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        int intUserId = 0;
        if (Session["USERID"] != null)
        {
            objEntityVisaBundle.UserId = Convert.ToInt32(Session["USERID"].ToString());
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (txtFromDate.Text != null && txtFromDate.Text != "")
        {
            objEntityVisaBundle.FrmDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
        }
        if (txtToDate.Text != null && txtToDate.Text != "")
        {
            objEntityVisaBundle.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
        }

        DataTable dt = new DataTable();
        dt = objBusinessVisaBundle.ReadVisaQuota(objEntityVisaBundle);

        //for printing table
        string bundleNo="";
        string issueDate="";
        string ExpiryDate="";

        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
           

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    bundleNo = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                }
                if (intColumnBodyCount == 2)
                {
                    issueDate = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                }
                if (intColumnBodyCount == 3)
                {
                    ExpiryDate = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                }
            }
            table.Rows.Add('"' + bundleNo + '"', '"' + issueDate + '"', '"' + ExpiryDate + '"');
        }
        return table;
    }
}





