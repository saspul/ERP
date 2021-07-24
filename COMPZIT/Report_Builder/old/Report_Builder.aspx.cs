using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using CL_Compzit;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Web.Services;

public partial class Report_Builder_Report_Builder : System.Web.UI.Page
{
    clsEntityReportBuilder objEntityReportBuilder = new clsEntityReportBuilder();
    clsBusinessLayerReportBuilder objBusinessReportBuilder = new clsBusinessLayerReportBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hiddenPageLoad.Value = "0";

            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

            DateTime dtToday = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());

            int intOrgId = 0;
            if (Session["ORGID"] != null)
            {
                objEntityReportBuilder.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityReportBuilder.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERFULLNAME"] != null)
            {
                hiddenUsername.Value = Session["USERFULLNAME"].ToString();
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["CORPORATENAME"] != null)
            {
                hiddenCorporateName.Value = Session["CORPORATENAME"].ToString();
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            hiddenDate.Value = dtToday.ToString("dd/MM/yyyy hh:mm tt");

            hiddenCancelPrimaryId.Value = "";

            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDefaultCurrency.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            }

            try
            {
                if (Request.QueryString["ReportId"] != null)
                {
                    string strReportId = Request.QueryString["ReportId"].ToString();
                    objEntityReportBuilder.ReportId = Convert.ToInt32(strReportId);
                    hiddenReportId.Value = strReportId;

                    //Report Main datas
                    DataTable dtReport = objBusinessReportBuilder.ReadReportData(objEntityReportBuilder);

                    if (dtReport.Rows.Count > 0)
                    {
                        if (dtReport.Rows[0]["RPRT_DTACTIONS"].ToString() != "")
                        {
                            //head.InnerHtml = "<img src=\"" + dtReport.Rows[0]["RPRT_IMAGE"].ToString() + "\" style=\"vertical-align: middle;\" />" + dtReport.Rows[0]["RPRT_NAME"].ToString();
                            head.InnerHtml =dtReport.Rows[0]["RPRT_NAME"].ToString();
                            reportHead.InnerHtml = dtReport.Rows[0]["RPRT_NAME"].ToString();
                            hiddenDtActns.Value = dtReport.Rows[0]["RPRT_DTACTIONS"].ToString();
                        }
                        
                        //Report detail datas
                        DataTable dtReportDtls = objBusinessReportBuilder.ReadReportDtls(objEntityReportBuilder);

                        if (dtReportDtls.Rows.Count > 0)
                        {

                            //Filter load
                            LoadFilters(dtReportDtls);

                            string Procedure = dtReport.Rows[0]["RPRT_PACKAGE"].ToString();
                            string Action = dtReport.Rows[0]["RPRT_PROCEDURE"].ToString();

                            DataTable dtParameters = objBusinessReportBuilder.ReadProcedureParameters(Procedure, Action);
                            dtParameters.Columns.Add(new DataColumn("VALUE"));

                            //Filter search
                            GetSearchData(dtReportDtls, dtParameters);

                            DataTable dtData = objBusinessReportBuilder.ReadProcedure(Procedure, Action, intCorpId, intOrgId, dtParameters);

                            string strHtm = ConvertDataTableToHTML(dtData, dtReportDtls);
                            divReport.InnerHtml = strHtm;
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    public string ConvertDataTableToHTML(DataTable dt, DataTable dtReportData)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        StringBuilder sb = new StringBuilder();
        sb.Append("<table id=\"ReportTable\" class=\"display table-bordered\" style=\"width:100%;\">");

        sb.Append("<thead class=\"thead1\">");
        sb.Append("<tr >");

        string tdHeadings = "", tdFunctions = "", tdValues = "", tdTotal = "", tdActions = "", tdTableSpan = "";
        foreach (DataRow dtRow in dtReportData.Rows)
        {
            if (dtRow["RPRTSUB_SECTION"].ToString() == "1")//headings
            {
                tdHeadings = dtRow["RPRTSUB_DETAILS"].ToString();
            }
            else if (dtRow["RPRTSUB_SECTION"].ToString() == "7")//edit,delete actions
            {
                tdFunctions = dtRow["RPRTSUB_DETAILS"].ToString();
            }
            else if (dtRow["RPRTSUB_SECTION"].ToString() == "2")//fields
            {
                tdValues = dtRow["RPRTSUB_DETAILS"].ToString();
            }
            else if (dtRow["RPRTSUB_SECTION"].ToString() == "6")//total
            {
                tdTotal = dtRow["RPRTSUB_DETAILS"].ToString();
            }
            else if (dtRow["RPRTSUB_SECTION"].ToString() == "8")//Actions
            {
                tdActions = dtRow["RPRTSUB_DETAILS"].ToString();
            }
            else if (dtRow["RPRTSUB_SECTION"].ToString() == "9")//Span
            {
                tdTableSpan = dtRow["RPRTSUB_DETAILS"].ToString();
            }
        }


        string[] Headings = tdHeadings.Split('¦');
        string[] Functns = tdFunctions.Split('¦');
        string[] Fields = tdValues.Split('¦');
        string[] Total = tdTotal.Split('¦');
        string[] Actions = tdActions.Split('¦');
        string[] Span = tdTableSpan.Split('¦');

        HiddenFieldHeader.Value = tdHeadings;


        int flag = 0;
        if (Headings.Length == Fields.Length)
        {
            flag = 1;
        }

        if (flag == 1)
        {
            hiddenRowCnt.Value = Headings.Length.ToString();

            //----------HEADINGS--------

            for (int n = 0; n < Headings.Length; n++)
            {
                string Heading = Headings[n];
                if (Heading != "")
                {
                    string[] Dtl = Heading.Split('—');
                    string strtitle = Dtl[0];
                    string strAlign = Dtl[1];
                    //string strColspan = Dtl[2];
                    //string strRowspan = Dtl[3];
                    sb.Append("<th style=\"text-align:" + strAlign + "\">" + strtitle + "</th>");
                }
            }
            for (int n = 0; n < Functns.Length; n++)
            {
                string Functn = Functns[n];
                if (Functn != "")
                {
                    string[] Dtl = Functn.Split('—');
                    string strtitle = Dtl[0];
                    sb.Append("<th style=\"width:4%;text-align: center;\">" + strtitle + "</th>");
                }
            }

            //----------HEADINGS--------
        }

        sb.Append("</tr>");
        sb.Append("</thead>");

        sb.Append("<tbody>");

        string strRowA = "", strRowB = "";

        if (dt.Rows.Count > 0)
        {
            if (flag == 1)
            {
                hiddenTotalRows.Value = dt.Rows.Count.ToString();

                decimal decTotalUSD = 0;
                decimal decTotalQAR = 0;

                string usd = ""; string qar = "";

                for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
                {
                    string strRowC = "";

                    sb.Append("<tr>");

                    string strId = dt.Rows[intRowBodyCount][0].ToString();
                    int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                    string stridLength = intIdLength.ToString("00");
                    string Id = stridLength + strId + strRandom;

                    //----------VALUES--------

                    string IdLink = "";

                    for (int n = 0; n < Fields.Length; n++)
                    {
                        string Field = Fields[n];
                        string Action = "";
                        if (Actions[0] != "")
                        {
                            Action = Actions[n];
                        }

                        if (Field != "0")
                        {
                            string[] Dtl = Field.Split('—');
                            string strField = Dtl[0];
                            string strAlign = Dtl[1];
                            string strElement = Dtl[2];

                            string SpanValues = "";

                            if (Span[0] != "")
                            {
                                string SpanField = Span[n];
                                if (SpanField != "" && SpanField != "0")
                                {
                                    string[] SpanFieldDtl = SpanField.Split('—');
                                    foreach (string span in SpanFieldDtl)
                                    {
                                        if (span != "")
                                        {
                                            string[] spansplit = span.Split('^');

                                            string Name = spansplit[0];
                                            string Value = spansplit[1];
                                            if (dt.Rows[intRowBodyCount][Value].ToString() != "")
                                            {
                                                SpanValues += Name + ":" + dt.Rows[intRowBodyCount][Value].ToString() + "<br/>";
                                            }
                                        }
                                    }
                                }
                            }

                            if (strField == "0")
                            {
                                sb.Append("<td style=\"text-align:" + strAlign + "\">" + SpanValues + "</td>");
                            }
                            else
                            {
                                string QueryString = "";
                                string strPath = "";

                                if (strElement == "0")
                                {
                                    sb.Append("<td style=\"text-align:" + strAlign + "\">" + dt.Rows[intRowBodyCount][strField].ToString() + "</td>");
                                }
                                else if (strElement == "LINK")
                                {
                                    //----------------Field action--------------------

                                    if (Action != "" && Action != "0")
                                    {
                                        string[] ActnDtl = Action.Split('¦');

                                        for (int t = 0; t < ActnDtl.Length; t++)
                                        {
                                            string[] ActnDtlSplit = Action.Split('—');

                                            for (int s = 0; s < ActnDtlSplit.Length; s++)
                                            {
                                                string[] QueryStrngDtls = ActnDtlSplit[s].Split('^');

                                                for (int u = 0; u < QueryStrngDtls.Length; u++)
                                                {
                                                    strPath = QueryStrngDtls[0];

                                                    if (u != 0)
                                                    {
                                                        string[] QueryStrngDtlsSplit = QueryStrngDtls[u].Split('¥');

                                                        string QryName = QueryStrngDtlsSplit[0];
                                                        string ActnTyp = QueryStrngDtlsSplit[1];
                                                        string QryValue = QueryStrngDtlsSplit[2];

                                                        if (ActnTyp == "1")//table data in query string
                                                        {
                                                            if (dt.Rows[intRowBodyCount][QryValue].ToString() != "")
                                                            {
                                                                if (strRowA != intRowBodyCount.ToString())
                                                                {
                                                                    string strIdLink = dt.Rows[intRowBodyCount][QryValue].ToString();
                                                                    int intIdLengthLink = dt.Rows[intRowBodyCount][QryValue].ToString().Length;
                                                                    string stridLengthLink = intIdLengthLink.ToString("00");
                                                                    IdLink = stridLengthLink + strIdLink + strRandom;

                                                                    if (QueryString == "")
                                                                    {
                                                                        QueryString = strPath + "?" + QryName + "=" + IdLink;
                                                                    }
                                                                    else
                                                                    {
                                                                        QueryString = QueryString + "&" + QryName + "=" + IdLink;
                                                                    }

                                                                    strRowA = intRowBodyCount.ToString();
                                                                }
                                                            }

                                                            strRowC = intRowBodyCount.ToString();
                                                        }
                                                        else if (ActnTyp != "1")//added new query string
                                                        {
                                                            if (strRowB != intRowBodyCount.ToString())
                                                            {
                                                                if (strRowC == "" || (strRowC != "" && QueryString != ""))
                                                                {
                                                                    if (QueryString == "")
                                                                    {
                                                                        QueryString = strPath + "?" + QryName + "=" + QryValue;
                                                                    }
                                                                    else
                                                                    {
                                                                        QueryString = QueryString + "&" + QryName + "=" + QryValue;
                                                                    }

                                                                    strRowB = intRowBodyCount.ToString();
                                                                }
                                                            }
                                                        }

                                                        //----------------Field action--------------------
                                                    }
                                                    

                                                }
                                            }
                                        }
                                    }

                                    sb.Append("<td style=\"text-align:" + strAlign + "\">" + "<a title=\"Click to view\" href=\"javascript:;\" onclick=\"return LinkClick('" + QueryString + "');\" style=\"color:#0058a3;text-align:center\">" + dt.Rows[intRowBodyCount][strField].ToString() + "" + "</a></td>");

                                }
                                else if (strElement == "TXT")
                                {
                                    sb.Append("<td style=\"text-align:" + strAlign + "\"><input type=\"text\" style=\"text-align:left\" /></td>");
                                }
                                else if (strElement == "BTN")
                                {
                                    sb.Append("<td style=\"text-align:" + strAlign + "\"><input type=\"button\" value=\"Click\" onclick=\"return ButtonClick('" + Id + "');\" style=\"text-align:center\" /></td>");
                                }
                            }


                            //-------------Total colspan-------------------

                            StringBuilder sbTotalUSD = new StringBuilder();
                            StringBuilder sbTotalQAR = new StringBuilder();

                            foreach (string TotalField in Total)
                            {
                                if (TotalField != "")
                                {
                                    string[] TotalDtl = TotalField.Split('—');

                                    string strTotalField = TotalDtl[0];
                                    string strCurrency = TotalDtl[1];

                                    if (strField == strTotalField)
                                    {
                                        if (dt.Rows[intRowBodyCount][strTotalField].ToString() != "")
                                        {
                                            decTotalUSD += Convert.ToDecimal(dt.Rows[intRowBodyCount][strTotalField].ToString());
                                        }
                                    }

                                    sbTotalQAR.Append("<th style=\"text-align:right\">" + decTotalUSD + "</th>");
                                }
                            }

                            //-------------Total colspan-------------------
                        }

                    }

                    for (int n = 0; n < Functns.Length; n++)
                    {
                        string Functn = Functns[n];
                        if (Functn != "")
                        {
                            string[] Dtl = Functn.Split('—');

                            string strTitle = Dtl[0];
                            string strHref = Dtl[1];
                            string strAction = Dtl[2];
                            string strClass = Dtl[3];

                            if (strAction != "0")
                            {
                                sb.Append("<td  style=\"width:4%;text-align: center;\">" + " <a title=\"" + strTitle + "\" onclick='return " + strAction + "(this.href," + strId + ");'" +
                                    " href=\"" + strHref + "?ReportId=" + Request.QueryString["ReportId"].ToString() + "&Id=" + Id + "\">" + "<i class=\"" + strClass + "\"></i>" + "</a> </td>");
                            }
                            else
                            {
                                sb.Append("<td  style=\"width:4%;text-align: center;\">" + " <a title=\"" + strTitle + "\" onclick='return getdetails(this.href);' " +
                                    " href=\"" + strHref + "?Id=" + Id + "\">" + "<i class=\"" + strClass + "\"></i>" + "</a> </td>");
                            }
                        }
                    }
                    //----------VALUES--------

                    sb.Append("</tr>");
                }
                //---------------Total amount colspan-----------------

                sb.Append("<thead>");

                clsEntityCommon objEntityCommon = new clsEntityCommon();
                clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

                objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDefaultCurrency.Value);

                if (decTotalUSD != 0)
                {
                    sb.Append("<tr class=\"tr1\">");
                    sb.Append("<td class=\"tr_r txt_rd bg1\" colspan=\"" + (Fields.Length - Total.Length) + "\" style=\"text-align:right\">Grand total</th>");
                    //sb.Append(sbTotalUSD);
                    string strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(decTotalUSD.ToString(), objEntityCommon);
                    sb.Append("<td class=\"tr_r txt_rd bg1\" style=\"text-align:right\">" + strAmountComma + "</th>");
                    sb.Append("</tr>");
                }
                sb.Append("</thead>");
                //---------------Total amount colspan-----------------

            }
        }

        sb.Append("</tbody>");

        sb.Append("</table>");

        return sb.ToString();
    }

    public void LoadFilters(DataTable dt)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        StringBuilder sb = new StringBuilder();

        string FilterList = "", FiltrChangeList = "", DdlValues = "";
        foreach (DataRow dtRow in dt.Rows)
        {
            if (dtRow["RPRTSUB_SECTION"].ToString() == "3")//filters
            {
                FilterList = dtRow["RPRTSUB_DETAILS"].ToString();
                hiddenFilterArray.Value = FilterList;
            }
            else if (dtRow["RPRTSUB_SECTION"].ToString() == "5")//filter changes
            {
                FiltrChangeList = dtRow["RPRTSUB_DETAILS"].ToString();
                hiddenDisplayArray.Value = FiltrChangeList;
            }
            else if (dtRow["RPRTSUB_SECTION"].ToString() == "4")//filter values
            {
                DdlValues = dtRow["RPRTSUB_DETAILS"].ToString();
            }
        }

        string[] FilterChrctrs = FilterList.Split('¦');
        string[] FilterChangfn = FiltrChangeList.Split('¦');
        string[] FilterValue = DdlValues.Split('¦');

        int flag = 0;
        if (FilterChrctrs.Length == FilterChangfn.Length && FilterChrctrs.Length == FilterValue.Length)
        {
            flag = 1;
        }

        if (flag == 1)
        {
            int date = 0;
            string strDate = "";//default value for date
            DateTime dtToday = new DateTime();

            for (int n = 0; n < FilterChrctrs.Length; n++)
            {
                string Filter = FilterChrctrs[n];
                string FilterChange = FilterChangfn[n];
                string DDlValue = FilterValue[n];
                hiddenStrId.Value = "";
                if (Filter != "")
                {
                    string[] Dtl = Filter.Split('—');

                    string strType = Dtl[0];
                    string strName = Dtl[1];
                    string strid = Dtl[2];
                    string strSpValue = Dtl[3];

                    if (strType == "DDL")
                    {
                        sb.Append("<div id=\"div" + strid + "\" class=\"fg2\">");
                        sb.Append("<label id=\"lbl" + strid + "\" class=\"fg2_la1\">" + strName + "<span class=\"spn1\"></span></label>");
                        sb.Append("<div>");
                        sb.Append("<select id=\"" + strid + "\" class=\"form-control fg2_inp1 fg_chs1 clsDDl\" name=\"" + strid + "\" onchange=\"return ChangeFilter(1);\">");
                        if (strSpValue == "0")
                        {
                            sb.Append(LoadFilterDropdowns(strSpValue, DDlValue));
                        }
                        else
                        {
                            sb.Append("<option value=\"0\">-Select-</option>");
                        }
                        sb.Append("</select>");
                        sb.Append("</div></div>");
                    }
                    else if (strType == "CBX")
                    {
                        sb.Append("<div id=\"div" + strid + "\" class=\"form-group col-md-4\">");
                        sb.Append("<div class=\"form-group\" style=\"margin-top: 2%;\">");
                        sb.Append("<label id=\"lbl" + strid + "\" class=\"col-md-6 col-form-label\" style=\"visibility:hidden;\">" + strName + "</label>");
                        sb.Append("<input type=\"checkbox\" id=\"" + strid + "\"  name=\"" + strid + "\" onchange=\"ChangeCheckbox('" + strid + "');\" />");
                        sb.Append("<label for=\"" + strid + "\">" + strName + "</label>");
                        sb.Append("<input type=\"hidden\" id=\"hidden" + strid + "\" name=\"hidden" + strid + "\" value=\"0\" />");
                        sb.Append("</div></div>");
                    }
                    else if (strType == "RADIO")
                    {
                        sb.Append("<div id=\"div" + strid + "\" class=\"form-group col-md-4\">");
                        sb.Append("<div class=\"form-group\">");
                        sb.Append("<div class=\"radio-list\">");
                        //sb.Append("<label for=\"" + strid + "\" class=\"col-md-3 col-form-label\">Company status</label>");
                        sb.Append("<div class=\"radio-inline pl-0\">");
                        sb.Append("<input type=\"radio\" id=\"" + strid + "\"  name=\"radio\" checked=\"true\" onchange=\"ChangeRadio('" + strid + "');\" />");
                        sb.Append("<label id=\"lbl" + strid + "\">" + strName + "</label>");
                        sb.Append("<input type=\"hidden\" id=\"hidden" + strid + "\" name=\"hidden" + strid + "\" value=\"0\" />");
                        sb.Append("</div>");
                        sb.Append("<div class=\"radio-inline pl-0\">");
                        sb.Append("<input type=\"radio\" id=\"" + strid + "\"  name=\"radio\" onchange=\"ChangeRadio('" + strid + "');\" />");
                        sb.Append("<label for=\"" + strid + "\">" + strName + "</label>");
                        sb.Append("<input type=\"hidden\" id=\"hidden" + strid + "\" name=\"hidden" + strid + "\" value=\"0\" />");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("</div></div>");
                    }
                    else if (strType == "TXT")
                    {
                        sb.Append("<div id=\"div" + strid + "\" class=\"form-group col-md-4\">");
                        sb.Append("<label id=\"lbl" + strid + "\" class=\"col-md-5 col-form-label\">" + strName + "</label>");
                        sb.Append("<div class=\"col-md-7\">");
                        sb.Append("<input type=\"text\" id=\"" + strid + "\" name=\"" + strid + "\"  class=\"form-control\" onkeydown=\"return DisableEnter(event);\" onkeypress=\"return isTag(event);\" onblur=\"RemoveTag('" + strid + "')\" onchange=\"return ChangeFilter(1);\" />");
                        sb.Append("</div></div>");
                    }
                    else if (strType == "TXTDEC")
                    {
                        sb.Append("<div id=\"div" + strid + "\" class=\"form-group col-md-4\">");
                        sb.Append("<label id=\"lbl" + strid + "\" class=\"col-md-5 col-form-label\">" + strName + "</label>");
                        sb.Append("<div class=\"col-md-7\">");
                        sb.Append("<input type=\"text\" id=\"" + strid + "\" name=\"" + strid + "\"  class=\"form-control\" onkeydown=\"return isDecimal(event)\" onblur=\"return BlurAmount('" + strid + "');\" onkeypress=\"return isTag(event)\" onchange=\"return ChangeFilter(1);\" />");
                        sb.Append("</div></div>");
                    }
                    else if (strType == "TXTNUM")
                    {
                        sb.Append("<div id=\"div" + strid + "\" class=\"form-group col-md-4\">");
                        sb.Append("<label id=\"lbl" + strid + "\" class=\"col-md-5 col-form-label\">" + strName + "</label>");
                        sb.Append("<div class=\"col-md-7\">");
                        sb.Append("<input type=\"text\" id=\"" + strid + "\" name=\"" + strid + "\"  class=\"form-control\" onkeydown=\"return isNumber(event)\" onblur=\"return BlurNotNumber('" + strid + "');\" onkeypress=\"return isTag(event)\" onchange=\"return ChangeFilter(1);\" />");
                        sb.Append("</div></div>");
                    }
                    else if (strType == "DATEPICK")
                    {
                        if (Session["FINCYRID"] != null)
                        {
                            objEntityCommon.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
                        }
                        else
                        {
                            Response.Redirect("/Default.aspx");
                        }
                        DataTable dtfinaclYear = objBusinessLayer.ReadFinancialYearById(objEntityCommon);

                        if (dtfinaclYear.Rows.Count > 0)
                        {
                            HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                            HiddenEndDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();

                            if (date == 0)
                            {
                                dtToday = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());
                                if (dtToday >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && dtToday <= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                                {
                                    strDate = dtToday.ToString("dd-MM-yyyy");
                                }
                                else
                                {
                                    strDate = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                                }
                            }
                            else
                            {
                                dtToday = dtToday.AddDays(30);
                                if (dtToday >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && dtToday <= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                                {
                                    strDate = dtToday.ToString("dd-MM-yyyy");
                                }
                                else
                                {
                                    strDate = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                                }
                            }
                        }

                        hiddenStrId.Value = strid;
                        sb.Append("<div id=\"div" + strid + "\" class=\"form-group fg2\">");
                        sb.Append("<label id=\"lbl" + strid + "\" class=\"fg2_la1\">" + strName + "</label>");
                        sb.Append("<div class=\"input-group date datepicker\" data-date-format=\"mm-dd-yyyy\">");
                        sb.Append("<input id=\"" + strid + "\" name=\"" + strid + "\" value=\"" + strDate + "\" class=\"form-control inp_bdr inp_mst\" onblur=\"RemoveTag('" + strid + "')\" onkeypress=\"return isTag(event)\" onchange=\"return ChangeFilter(1);\" />");
                        sb.Append("<span class=\"input-group-addon date1\"><i class=\"fa fa-calendar\"></i></span></div>");
                        sb.Append("</div>");
                        date++;
                    }
                    else if (strType == "MNTH")
                    {
                        sb.Append("<div id=\"div" + strid + "\" class=\"form-group col-md-4\">");
                        sb.Append("<label id=\"lbl" + strid + "\" class=\"col-md-5 col-form-label\">" + strName + "</label>");
                        sb.Append("<div class=\"col-md-7\">");
                        sb.Append("<select id=\"" + strid + "\" name=\"" + strid + "\" class=\"form-control\" onchange=\"return ChangeFilter(1);\">");
                        sb.Append(LoadMonth());
                        sb.Append("</select>");
                        sb.Append("</div></div>");
                    }
                    else if (strType == "YEAR")
                    {
                        sb.Append("<div id=\"div" + strid + "\" class=\"form-group col-md-4\">");
                        sb.Append("<label id=\"lbl" + strid + "\" class=\"col-md-5 col-form-label\">" + strName + "</label>");
                        sb.Append("<div class=\"col-md-7\">");
                        sb.Append("<select id=\"" + strid + "\" name=\"" + strid + "\" class=\"form-control\" onchange=\"return ChangeFilter(1);\">");
                        sb.Append(LoadYears());
                        sb.Append("</select>");
                        sb.Append("</div></div>");
                    }
                    else if (strType == "QUARTR")
                    {
                        sb.Append("<div id=\"div" + strid + "\" class=\"form-group col-md-4\">");
                        sb.Append("<div class=\"col-md-7\">");
                        sb.Append("<label id=\"lbl" + strid + "\" class=\"col-md-5 col-form-label\">" + strName + "</label>");
                        sb.Append("<select id=\"" + strid + "\" name=\"" + strid + "\" class=\"form-control\" onchange=\"return ChangeFilter(1);\">");
                        sb.Append(LoadQuarter());
                        sb.Append("</select>");
                        sb.Append("</div></div>");
                    }
                    else if (strType == "HALFYR")
                    {
                        sb.Append("<div id=\"div" + strid + "\" class=\"form-group col-md-4\">");
                        sb.Append("<div class=\"col-md-7\">");
                        sb.Append("<label id=\"lbl" + strid + "\" class=\"col-md-5 col-form-label\">" + strName + "</label>");
                        sb.Append("<select id=\"" + strid + "\" name=\"" + strid + "\" class=\"form-control\" onchange=\"return ChangeFilter(1);\">");
                        sb.Append(LoadHalfYear());
                        sb.Append("</select>");
                        sb.Append("</div></div>");
                    }

                }
            }
        }

        divFilterList.InnerHtml = sb.ToString();
    }

    private string LoadFilterDropdowns(string SpValue, string Value)
    {
        StringBuilder sb = new StringBuilder();

        int intOrgId = 0;
        if (Session["ORGID"] != null)
        {
            objEntityReportBuilder.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReportBuilder.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        string[] Val = Value.Split('¦');
        foreach (string p in Val)
        {
            string[] ValSplit = p.Split('—');
            foreach (string dtl in ValSplit)
            {
                if (dtl.Split('^') != null)
                {
                    string[] Dtls = dtl.Split('^');
                    if (Dtls != null)
                    {
                        string strText = Dtls[1];
                        string strValue = Dtls[0];

                        sb.Append("<option value=\"" + strValue + "\">" + strText + "</option>");
                    }
                }
            }
        }

        return sb.ToString();
    }

    [WebMethod]
    public static string[] LoadFilterDropdownsWeb(string orgID, string corptID, string ReportID, string Dropdwn)
    {
        clsEntityReportBuilder objEntityReportBuilder = new clsEntityReportBuilder();
        clsBusinessLayerReportBuilder objBusinessReportBuilder = new clsBusinessLayerReportBuilder();

        objEntityReportBuilder.OrgId = Convert.ToInt32(orgID);
        objEntityReportBuilder.CorpId = Convert.ToInt32(corptID);
        int intCorpId = Convert.ToInt32(corptID);
        objEntityReportBuilder.ReportId = Convert.ToInt32(ReportID);
        int intOrgId = Convert.ToInt32(orgID);

        DataTable dtReportDtls = objBusinessReportBuilder.ReadReportDtls(objEntityReportBuilder);

        string DdlDtls = "", DdlValues = "";

        foreach (DataRow dtRow in dtReportDtls.Rows)
        {
            if (dtRow["RPRTSUB_SECTION"].ToString() == "3")//filters
            {
                DdlDtls = dtRow["RPRTSUB_DETAILS"].ToString();
            }
            if (dtRow["RPRTSUB_SECTION"].ToString() == "4")//filter values
            {
                DdlValues = dtRow["RPRTSUB_DETAILS"].ToString();
            }
        }

        string[] Filters = DdlDtls.Split('¦');
        string[] FilterVals = DdlValues.Split('¦');
        string[] DrpDwnValues = Dropdwn.Split('¦');

        int flag = 0;
        if (Filters.Length == FilterVals.Length)
        {
            flag = 1;
        }

        StringBuilder[] sb = new StringBuilder[Filters.Length];
        string[] Result = new string[Filters.Length];

        if (flag == 1)
        {
            int ddlCnt = 0;

            for (int n = 0; n < Filters.Length; n++)
            {
                string Filter = Filters[n];
                string Value = FilterVals[n];

                string[] FilterSplit = Filter.Split('—');
                string Type = FilterSplit[0];
                string Id = FilterSplit[2];
                string Sp = FilterSplit[3];

                if (Type == "DDL" && Sp == "1")
                {
                    string[] SpSplit = Value.Split('—');

                    string Procedure = SpSplit[0];
                    string Action = SpSplit[1];
                    string Paramtrs = SpSplit[2];

                    DataTable dtParameters = objBusinessReportBuilder.ReadProcedureParameters(Procedure, Action);
                    dtParameters.Columns.Add(new DataColumn("VALUE"));

                    if (Paramtrs != "0")
                    {
                        string[] parmtrsplit = Paramtrs.Split('^');
                        string ddlIdParmtr = parmtrsplit[0];
                        string ddlIdParmtrVal = parmtrsplit[1];

                        foreach (string strDdl in DrpDwnValues)
                        {
                            string[] ddl = strDdl.Split('–');
                            string ddlId = ddl[0];
                            string ddlVal = ddl[1];
                            if (ddlId == ddlIdParmtr)
                            {
                                foreach (DataRow dtRow in dtParameters.Rows)
                                {
                                    string PramtrName = dtRow["PARAMETER_NAME"].ToString();
                                    if (ddlIdParmtrVal == PramtrName)
                                    {
                                        dtRow["VALUE"] = ddlVal;
                                    }
                                }
                            }
                        }
                    }

                    DataTable dtData = objBusinessReportBuilder.ReadProcedure(Procedure, Action, intCorpId, intOrgId, dtParameters);

                    sb[ddlCnt] = new StringBuilder();

                    sb[ddlCnt].Append("<option value=\"\" selected=\"true\">-Select-</option>");
                    foreach (DataRow dtRow in dtData.Rows)
                    {
                        sb[ddlCnt].Append("<option value=\"" + dtRow[0].ToString() + "\">" + dtRow[1].ToString() + "</option>");
                    }

                    Result[ddlCnt] = sb[ddlCnt].ToString() + "|" + Id;

                    ddlCnt++;
                }
            }
        }

        return Result;
    }

    public string GetValues(string Type, string FiltrName)
    {
        string Val = "";

        if (Type == "DDL" || Type == "TXT" || Type == "TXTDEC" || Type == "TXTNUM" || Type == "DATEPICK" || Type == "MNTH" || Type == "YEAR" || Type == "QUARTR" || Type == "HALFYR")
        {
            if (!string.IsNullOrEmpty(Request.Form[FiltrName]))
            {
                Val = Request.Form[FiltrName];
            }
        }
        else if (Type == "CBX" || Type == "RADIO")
        {
            Val = Request.Form["hidden" + FiltrName];
        }

        return Val;
    }

    public void GetSearchData(DataTable dtReportDtls, DataTable dtParameters)
    {
        string FilterList = "", FiltrChangeList = "";
        foreach (DataRow dtRow in dtReportDtls.Rows)
        {
            if (dtRow["RPRTSUB_SECTION"].ToString() == "3")//filters
            {
                FilterList = dtRow["RPRTSUB_DETAILS"].ToString();
            }
            else if (dtRow["RPRTSUB_SECTION"].ToString() == "5")//filter changes
            {
                FiltrChangeList = dtRow["RPRTSUB_DETAILS"].ToString();
            }
        }

        string[] FilterChrctrs = FilterList.Split('¦');
        string[] FilterChanges = FiltrChangeList.Split('¦');

        int flag = 0;
        if (FilterChrctrs.Length == FilterChanges.Length)
        {
            flag = 1;
        }

        if (flag == 1)
        {

            string[] FilterIds = new string[FilterChrctrs.Length];

            for (int n = 0; n < FilterChrctrs.Length; n++)
            {
                string Filter = FilterChrctrs[n];
                string FilterDisplayNone = FilterChanges[n];

                if (Filter != "")
                {
                    string[] Fltr = Filter.Split('—');
                    string strType = Fltr[0];
                    string strFilterName = Fltr[2];
                    string Paramtr = Fltr[4];

                    string Values = GetValues(strType, strFilterName);

                    foreach (DataRow dtRow in dtParameters.Rows)
                    {
                        string PramtrName = dtRow["PARAMETER_NAME"].ToString();
                        if (Paramtr == PramtrName)
                        {
                            dtRow["VALUE"] = Values;
                        }
                    }
                }
            }
        }
    }

    private string LoadYears()
    {
        var currentYear = DateTime.Today.Year;

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i <= 30; i++)
        {
            sb.Append("<option>" + (currentYear - i).ToString() + "</option>");
        }
        return sb.ToString();
    }

    private string LoadMonth()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("<option value=\"0\">--SELECT--</option>");
        sb.Append("<option value=\"1\">January</option>");
        sb.Append("<option value=\"2\">February</option>");
        sb.Append("<option value=\"3\">March</option>");
        sb.Append("<option value=\"4\">April</option>");
        sb.Append("<option value=\"5\">May</option>");
        sb.Append("<option value=\"6\">June</option>");
        sb.Append("<option value=\"7\">July</option>");
        sb.Append("<option value=\"8\">August</option>");
        sb.Append("<option value=\"9\">September</option>");
        sb.Append("<option value=\"10\">October</option>");
        sb.Append("<option value=\"11\">November</option>");
        sb.Append("<option value=\"12\">December</option>");

        return sb.ToString();
    }

    private string LoadQuarter()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<option value=\"0\">--SELECT--</option>");
        sb.Append("<option value=\"1\">1st Quarter</option>");
        sb.Append("<option value=\"2\">2nd Quarter</option>");
        sb.Append("<option value=\"3\">3rd Quarter</option>");
        sb.Append("<option value=\"4\">4th Quarter</option>");
        return sb.ToString();
    }

    private string LoadHalfYear()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("<option value=\"0\">--SELECT--</option>");
        sb.Append("<option value=\"1\">1st Half</option>");
        sb.Append("<option value=\"2\">2nd Half</option>");
        return sb.ToString();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        hiddenPageLoad.Value = "1";

        string[] keys = Request.Form.AllKeys;

        int intOrgId = 0;
        if (Session["ORGID"] != null)
        {
            objEntityReportBuilder.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReportBuilder.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (Request.QueryString["ReportId"] != null)
        {
            string strReportId = Request.QueryString["ReportId"].ToString();
            objEntityReportBuilder.ReportId = Convert.ToInt32(strReportId);
            hiddenReportId.Value = strReportId;
        }

        DataTable dtReport = objBusinessReportBuilder.ReadReportData(objEntityReportBuilder);

        string Procedure = dtReport.Rows[0]["RPRT_PACKAGE"].ToString();
        string Action = dtReport.Rows[0]["RPRT_PROCEDURE"].ToString();

        DataTable dtParameters = objBusinessReportBuilder.ReadProcedureParameters(Procedure, Action);
        dtParameters.Columns.Add(new DataColumn("VALUE"));

        DataTable dtReportDtls = objBusinessReportBuilder.ReadReportDtls(objEntityReportBuilder);

        if (dtReportDtls.Rows.Count > 0)
        {
            GetSearchData(dtReportDtls, dtParameters);

            DataTable dtData = objBusinessReportBuilder.ReadProcedure(Procedure, Action, intCorpId, intOrgId, dtParameters);

            string strHtm = ConvertDataTableToHTML(dtData, dtReportDtls);
            divReport.InnerHtml = strHtm;
        }

    }

}