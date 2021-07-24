using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using CL_Compzit;
using EL_Compzit;
using System.Data;
using System.Text;
using System.Web.Services;
using EL_Compzit.EntityLayer_FMS;
using BL_Compzit.BusineesLayer_FMS;
using System.IO;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

public partial class FMS_FMS_Reports_fms_DayBook_fms_Day_Book : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clsBusinessLayer_DayBook objBusinessDayBook = new clsBusinessLayer_DayBook();
        clsEntity_DayBook objEntityDayBook = new clsEntity_DayBook();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (!IsPostBack)
        {
            TransactionModeLoad();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityDayBook.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityDayBook.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            string strDate = "";
            txtDate.Value = DateTime.Now.ToString("dd-MM-yyyy");
            if (txtDate.Value != "")
            {
                strDate = txtDate.Value;
                DateTime dtDate = objCommon.textToDateTime(strDate.ToString());
                string strDate1 = dtDate.ToString("dd-MM-yyyy");
                objEntityDayBook.DayBook_Date = objCommon.textToDateTime(strDate1);
            }
            //   objEntityDayBook.DayBook_Date=objCommon.textToDateTime(DateTime.Now.ToString("dd-MM-yyyy"));
            objEntityDayBook.TransactionType = Convert.ToInt32(ddlMode.SelectedItem.Value);
            DataTable dtDayBook = objBusinessDayBook.ReadDayBook(objEntityDayBook);
            divDayBook.InnerHtml = ConvertDataTableToHTML(dtDayBook);
            divPrintReport.InnerHtml = ConvertDataTableToPrint(dtDayBook);

        }
    }
    public void TransactionModeLoad()
    {
        clsBusinessLayer_DayBook objBusinessDayBook = new clsBusinessLayer_DayBook();
        clsEntity_DayBook objEntityDayBook = new clsEntity_DayBook();
        DataTable dtTransactionMode = objBusinessDayBook.ReadTransactionMode(objEntityDayBook);
        if (dtTransactionMode.Rows.Count > 0)
        {
            ddlMode.DataSource = dtTransactionMode;
            ddlMode.DataTextField = "VOCHR_TYPE";
            ddlMode.DataValueField = "VOCHR_TYP_ID";
            ddlMode.DataBind();

        }
    }
    public string ConvertDataTableToHTML(DataTable dt)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
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
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"table table-striped table-bordered\" width=\"100%\" style=\"border-spacing: 1px;background-color: #e7e6e6;\">";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr >";


            strHtml += "<th class=\"hasinput\" style=\"width:5%;text-align:left;\">SL NO";

            strHtml += "</th >";
            strHtml += "<th class=\"hasinput\" style=\"width:20%;text-align:left;\">PARTICULARS ";
            strHtml += "	<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"form-control\" placeholder=\"PARTICULARS\" style=\"text-align:left;\" type=\"text\">";
            strHtml += "</th >";

            strHtml += "<th class=\"hasinput\" style=\"width:15%;text-align:left;\">TRANSACTION TYPE ";
            strHtml += "	<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"form-control\" placeholder=\"TRANSACTION TYPE\" style=\"text-align:left;\" type=\"text\">";
            strHtml += "</th >";

            strHtml += "<th class=\"hasinput\" style=\"width:20%;text-align:left;\">REFERENCE NUMBER";
            strHtml += "	<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"form-control\" placeholder=\"REFERENCE NUMBER\" style=\"text-align:left;\" type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"hasinput\" style=\"width:20%;text-align:right;\">DEBIT";
            strHtml += "	<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"form-control\" placeholder=\"DEBIT\" style=\"text-align:right;\" type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"hasinput\" style=\"width:20%;text-align:right;\">CREDIT";
            strHtml += "	<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"form-control\" placeholder=\"CREDIT\" style=\"text-align:right;\" type=\"text\">";
            strHtml += "</th >";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr>";
      
            int CNT = intRowBodyCount + 1;

            for (int intColumnBodyCount = 0; intColumnBodyCount < 7; intColumnBodyCount++)
            {
                string strNetAmount="";
                string strNetAmountWithComma = "";

                strNetAmount = dt.Rows[intRowBodyCount]["VOCHR_AMT"].ToString();
                strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + CNT + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {

                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" > " + dt.Rows[intRowBodyCount]["LDGR_NAME"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" > " + dt.Rows[intRowBodyCount]["VOCHR_TYP"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" > " + dt.Rows[intRowBodyCount]["VOCHR_REF"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 5)
                {
                    if (dt.Rows[intRowBodyCount]["VOCHR_STS"].ToString() == "1")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right;\" > " + strNetAmountWithComma + "</td>";

                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right;\" ></td>";

                    }
                }
                else if (intColumnBodyCount == 6)
                {
                    if (dt.Rows[intRowBodyCount]["VOCHR_STS"].ToString() == "1")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right;\" ></td>";
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right;\" > " + strNetAmountWithComma + "</td>";
                    }

                }
            }
            strHtml += "</tr>";
        }
        if (dt.Rows.Count == 0)
        {
            strHtml += "<td class=\"tdT\"colspan=\"6\" style=\" width:16%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No Data Available</td>";

        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    public string ConvertDataTableToPrint(DataTable dt)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
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

        string strTitle = "";
        strTitle = "Day Book";
        DateTime datetm = objCommon.textToDateTime(txtDate.Value);
   //     string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string dat = "<B>Report Date: </B>" + datetm.ToString("dd-MMMM-yyyy");
        StringBuilder sbCap = new StringBuilder();
        string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
        string strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
        string strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabTitle + strCaptionTabRprtDate + strCaptionTabstop;

        sbCap.Append(strPrintCaptionTable);
        //write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString();
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\" \">";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";
        strHtml += "<th class=\"thT\" style=\"width:5%;text-align:left;\">SL NO";
        strHtml += "</th >";
        strHtml += "<th class=\"thT\" style=\"width:20%;text-align:left;\">PARTICULARS ";
        strHtml += "</th >";
        strHtml += "<th class=\"thT\" style=\"width:15%;text-align:left;\">TRANSACTION TYPE ";
        strHtml += "</th >";
        strHtml += "<th class=\"thT\" style=\"width:20%;text-align:left;\">REFERENCE NUMBER";
        strHtml += "</th >";
        strHtml += "<th class=\"thT\" style=\"width:20%;text-align:right;\">DEBIT";
        strHtml += "</th >";
        strHtml += "<th class=\"thT\" style=\"width:20%;text-align:right;\">CREDIT";
        strHtml += "</th >";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr>";
            int CNT = intRowBodyCount + 1;
            for (int intColumnBodyCount = 0; intColumnBodyCount < 7; intColumnBodyCount++)
            {
                string strNetAmount = "";
                string strNetAmountWithComma = "";
                strNetAmount = dt.Rows[intRowBodyCount]["VOCHR_AMT"].ToString();
                strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + CNT + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" > " + dt.Rows[intRowBodyCount]["LDGR_NAME"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" > " + dt.Rows[intRowBodyCount]["VOCHR_TYP"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" > " + dt.Rows[intRowBodyCount]["VOCHR_REF"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 5)
                {
                    if (dt.Rows[intRowBodyCount]["VOCHR_STS"].ToString() == "1")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right;\" > " + strNetAmountWithComma + "</td>";
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right;\" ></td>";
                    }
                }
                else if (intColumnBodyCount == 6)
                {
                    if (dt.Rows[intRowBodyCount]["VOCHR_STS"].ToString() == "1")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right;\" ></td>";
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right;\" > " + strNetAmountWithComma + "</td>";
                    }
                }
            }
            strHtml += "</tr>";
        }
        if (dt.Rows.Count == 0)
        {
            strHtml += "<td class=\"tdT\"colspan=\"6\" style=\" width:16%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No Data Available</td>";
        }
        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsBusinessLayer_DayBook objBusinessDayBook = new clsBusinessLayer_DayBook();
        clsEntity_DayBook objEntityDayBook = new clsEntity_DayBook();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityDayBook.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityDayBook.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
       // txtDate.Value = DateTime.Now.ToString("dd-MM-yyyy");
        string strDate = "";
        if (txtDate.Value != "")
        {
            strDate = txtDate.Value;
            DateTime dtDate = objCommon.textToDateTime(strDate.ToString());
            string strDate1 = dtDate.ToString("dd-MM-yyyy");
            objEntityDayBook.DayBook_Date = objCommon.textToDateTime(strDate1);
        }
        objEntityDayBook.TransactionType = Convert.ToInt32(ddlMode.SelectedItem.Value);
        DataTable dtDayBook = objBusinessDayBook.ReadDayBook(objEntityDayBook);
        divDayBook.InnerHtml = ConvertDataTableToHTML(dtDayBook);
        divPrintReport.InnerHtml = ConvertDataTableToPrint(dtDayBook);

    }
}