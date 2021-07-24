using BL_Compzit;
using BL_Compzit.BusinessLayer_GMS;
using CL_Compzit;
using EL_Compzit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;



public partial class GMS_Reports_Rep_Ins_Expiry_Range_Rep_Ins_Expiry_Range : System.Web.UI.Page
{

    DateTime tempdate;
    protected void Page_Load(object sender, EventArgs e)
    {
        ddlDivisionSearch.Attributes.Add("onkeypress", "return DisableEnter(event)");
        hiddensysdate.Value = DateTime.Today.ToString("dd-MM-yyyy");
        if (!IsPostBack)
        {
            ddlDivisionSearch.Focus();
            btnNext.Enabled = false;
            btnPrevious.Enabled = false;

            Division_Load();
            Category_Load();
            CurrencyLoad();

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            clsBusinessLayerInsuranceReports objBusinessLayerReports = new clsBusinessLayerInsuranceReports();
            clsEntityInsuraceReports objEntityReports = new clsEntityInsuraceReports();
            DataTable dtList = new DataTable();
            int intCorpId = 0;

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objEntityReports.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (ddlDivisionSearch.SelectedItem.Text == "--SELECT ALL DIVISION--")
            {
                objEntityReports.Division_Id = 0;
            }
            else
            {
                objEntityReports.Division_Id = Convert.ToInt32(ddlDivisionSearch.SelectedItem.Value);

            }
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE ,
                                                                clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                                clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT
                                                               };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);

            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            }

            //EVM-0027
            // for adding comma
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();

            }



          
            //END

            dtList = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);


            if (dtList.Rows.Count > 0)
            {
                string strListingMode = dtList.Rows[0]["LISTING_MODE"].ToString();
                string strLstingModeSize = dtList.Rows[0]["LISTING_MODE_SIZE"].ToString();


                int intListingMode = Convert.ToInt32(strListingMode);
                if (intListingMode == 2)//variant
                {
                    btnNext.Text = "Show Next Records";
                    btnPrevious.Text = "Show Previous Records";
                    hiddenMemorySize.Value = strLstingModeSize;
                }
                else if (intListingMode == 1)//fixed
                {
                    btnNext.Text = "Show Next " + strLstingModeSize + " Records";
                    btnPrevious.Text = "Show Previous " + strLstingModeSize + " Records";
                    hiddenTotalRowCount.Value = strLstingModeSize;
                    hiddenNext.Value = strLstingModeSize;
                }
                hiddenPrevious.Value = "0";
                objEntityReports.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
                if (ddlDivisionSearch.Items.Count > 1)                   //emp17
                {
                    DataTable dtExpiryListing = objBusinessLayerReports.Read_ExpiryRange_LIstDetails(objEntityReports);
                    string strReport = ConvertDataTableToHTML(dtExpiryListing);
                    divReport.InnerHtml = strReport;
                    DataTable dtCorp = objBusinessLayerReports.ReadCorporateAddress(objEntityReports);
                    string strPrintReport = ConvertDataTableForPrint(dtExpiryListing, dtCorp);
                    divPrintReport.InnerHtml = strPrintReport;
                }
            }    


        }
    }
    public void Division_Load()
    {
        clsBusinessLayerInsuranceReports objBusinessLayerReports = new clsBusinessLayerInsuranceReports();
        clsEntityInsuraceReports objEntityReports = new clsEntityInsuraceReports();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityReports.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        DataTable dtDivision = objBusinessLayerReports.ReadDivision(objEntityReports);

        //Division
        ddlDivisionSearch.DataSource = dtDivision;
        ddlDivisionSearch.DataTextField = "CPRDIV_NAME";
        ddlDivisionSearch.DataValueField = "CPRDIV_ID";
        ddlDivisionSearch.DataBind();
        ddlDivisionSearch.Items.Insert(0, "--SELECT ALL DIVISION--");


    }
    public void Category_Load()
    {
        clsBusinessLayerInsuranceReports objBusinessLayerReports = new clsBusinessLayerInsuranceReports();
        clsEntityInsuraceReports objEntityReports = new clsEntityInsuraceReports();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityReports.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        ddlmodeSearch.Items.Insert(0, "--SELECT ALL TYPE--");
        ddlmodeSearch.Items.Insert(1, "1 month");
        ddlmodeSearch.Items.Insert(2, "3 months");
        ddlmodeSearch.Items.Insert(3, "Custom period");

    }
    public void CurrencyLoad()
    {
        clsBusinessLayerInsuranceReports objBusinessLayerReports = new clsBusinessLayerInsuranceReports();
        clsEntityInsuraceReports objEntityReports = new clsEntityInsuraceReports();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityReports.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBusinessLayerReports.ReadCurrency(objEntityReports);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlCurrency.DataSource = dtSubConrt;
            ddlCurrency.DataTextField = "CRNCMST_NAME";
            ddlCurrency.DataValueField = "CRNCMST_ID";
            ddlCurrency.DataBind();
        }
        DataTable dtDefaultcurc = objBusinessLayerReports.ReadDefualtCurrency(objEntityReports);
        string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        //ddlCurrency.Items.Insert(0, "--SELECT CURRENCY--");
        if (ddlCurrency.Items.FindByValue(strdefltcurrcy) != null)
            ddlCurrency.Items.FindByValue(strdefltcurrcy).Selected = true;
    }
    public string ConvertDataTableToHTML(DataTable dt)
    {

        clsEntityCommon objEntityCommon = new clsEntityCommon();

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        int first = Convert.ToInt32(hiddenPrevious.Value);
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();


        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">SL#</th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:12%;text-align: left; word-wrap:break-word;\">INSURANCE REF#</th>";
            }
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">DATE OF INSURANCE</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:11%;text-align: left; word-wrap:break-word;\">INSURANCE TYPE</th>";
            }

            if (intColumnHeaderCount == 3)
            {
              //  strHtml += "<th class=\"thT\" style=\"width:16%;text-align: left; word-wrap:break-word;\">INSURANCE PERSON</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">PROJECT REF#</th>";
            }
            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: left; word-wrap:break-word;\">INSURANCE PROVIDER</th>";
            }

            if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">EXPIRY DATE</th>";
            }
            if (intColumnHeaderCount == 7)
            {
               // strHtml += "<th class=\"thT\" style=\"width:8%;text-align: left; word-wrap:break-word;\">JOB CODE</th>";
            }
            if (intColumnHeaderCount == 8)
            {
                strHtml += "<th class=\"thT\" style=\"width:14%;text-align: right; word-wrap:break-word;\">AMOUNT</th>";
            }
            //EVM-0024
            if (intColumnHeaderCount == 9)
            {
                strHtml += "<th class=\"thT\" style=\"width:7%;text-align: left; word-wrap:break-word;\">CURRENCY</th>";
            }
            //END

        }
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        int count = 0;
        lblToalRowCount.Text = "0";
        if ((ddlDivisionSearch.SelectedItem.Text != "--SELECT ALL DIVISION--") || (ddlmodeSearch.SelectedItem.Text != "--SELECT ALL TYPE--"))
        {
            lblToalRowCount.Text = dt.Rows.Count.ToString();
            for (int intRowBodyCount = first; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                strHtml += "<tr  >";
                count++;
                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count + "</td>";

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 0)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["INSURANCE REF#"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 1)
                    {

                        strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" ><span style=\"display:none;\">" + dt.Rows[intRowBodyCount]["DATE OF INSURANCE"].ToString() + "</span>" + dt.Rows[intRowBodyCount]["DATE OF INSURANCE"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["INSURANCE TYPE"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 3)
                    {
                       // strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["INSURANCE PERSON"].ToString() + "</td>";

                      

                    }
                    if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td title=\"" + dt.Rows[intRowBodyCount][8].ToString() + "\"  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left; \" >" + dt.Rows[intRowBodyCount]["PROJECT REF#"].ToString() + "</td>";
                    }

                    //END
                    if (intColumnBodyCount == 5)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["INSURANCE PROVIDER"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 6)
                    {
                    
                        strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" ><span style=\"display:none;\">" + dt.Rows[intRowBodyCount]["EXPIRY DATE"].ToString() + "</span>" + dt.Rows[intRowBodyCount]["EXPIRY DATE"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 7)
                    {
                     //   strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["JOB CODE"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 8)
                    {

                        string rchgAmnt = dt.Rows[intRowBodyCount]["AMOUNT"].ToString();

                        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                        string commarchgAmnt = objBusinessLayer.AddCommasForNumberSeperation(rchgAmnt, objEntityCommon);

                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: end;\" >" + commarchgAmnt + " </td>";
                    }
                    
                    if (intColumnBodyCount == 9)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CURRENCY"].ToString() + "</td>";
                        //EVM-0027
                        HiddenCurrency.Value = dt.Rows[intRowBodyCount]["CURRENCY"].ToString();
                        //END
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
    public string ConvertDataTableForPrint(DataTable dt, DataTable dtCorp)
    {
       // return "";
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Insurance Expiry Range Report";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string usrName = "<B> Report Generated By: </B>" + Session["USERFULLNAME"];
        //   string TotalRowCnt = "<B> Expiry Range Wise Total Guarantee: </B>" + dt.Rows.Count;
        //for printing product division on print
        string division;
        string date;
        string todate = "";
        if (ddlDivisionSearch.SelectedItem.Text.ToString() == "--SELECT ALL DIVISION--")
        {
            division = ""; 
        }
        else
        {
            division = "<B>Division : </B>" + ddlDivisionSearch.SelectedItem.Text;
        }

        if (dtCorp.Rows.Count > 0)
        {
            strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
            strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
            strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
            strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
            strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
        }

        if (ddlmodeSearch.SelectedItem.Text.ToString() == "--SELECT ALL TYPE--")
        {
            date = "";                                 //EMP17
        }
        else if (ddlmodeSearch.SelectedItem.Text.ToString() == "Custom period")
        {
            date = "<B> Insurance Expiry : </B>" + ddlmodeSearch.SelectedItem.Text;
            todate = "<B> To Date : </B>" + Request.Form["ctl00$cphMain$txtToDate"];
        }
        else
        {
            date = "<B> Insurance Expiry : </B>" + ddlmodeSearch.SelectedItem.Text;
        }

        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        string strCompanyAddr = objClsCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);

        StringBuilder sbCap = new StringBuilder();

        string strUsrName = "";


        string strCaptionTabstart = "<table id=\"ReportTable\" class=\"PrintCaptionTable\" >";
        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr + "</td></tr>";
        string strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        string strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
        string strDivisionTitle = "<tr><td class=\"RprtDiv\">" + division + "</td></tr>";        
        string strPeriodTitle = "<tr><td class=\"RprtDiv\">" + date + "</td></tr>";
        string strTOdateTitle = "<tr><td class=\"RprtDiv\">" + todate + "</td></tr>";
        if (usrName != "")
        {
            strUsrName = "<tr><td class=\"RprtDiv\">" + usrName + "</td></tr>";
        }
        //if (TotalRowCnt != "")
        //{
        //    strTotalCount = "<tr><td class=\"RprtDiv\">" + TotalRowCnt + "</td></tr>";
        //}
        string strCaptionTabstop = "</table><br>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strUsrName + strCaptionTabTitle + strDivisionTitle + strPeriodTitle + strTOdateTitle + strCaptionTabstop;



        sbCap.Append(strPrintCaptionTable);
        //write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString(); ;


        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";
        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">SL#</th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:12%;text-align: left; word-wrap:break-word;\">INSURANCE REF#</th>";
            }
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">DATE OF INSURANCE</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:11%;text-align: left; word-wrap:break-word;\">INSURANCE TYPE</th>";
            }

            if (intColumnHeaderCount == 3)
            {
             //   strHtml += "<th class=\"thT\" style=\"width:16%;text-align: left; word-wrap:break-word;\">INSURANCE PERSON</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">PROJECT REF#</th>";
            }
            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: left; word-wrap:break-word;\">INSURANCE PROVIDER</th>";
            }

            if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">EXPIRY DATE</th>";
            }
            if (intColumnHeaderCount == 7)
            {
               // strHtml += "<th class=\"thT\" style=\"width:8%;text-align: left; word-wrap:break-word;\">JOB CODE</th>";
            }
            if (intColumnHeaderCount == 8)
            {
                strHtml += "<th class=\"thT\" style=\"width:14%;text-align: right; word-wrap:break-word;\">AMOUNT</th>";
            }
            //EVM-0024
            if (intColumnHeaderCount == 9)
            {
                strHtml += "<th class=\"thT\" style=\"width:7%;text-align: left; word-wrap:break-word;\">CURRENCY</th>";
            }
            //END
        }

        strHtml += "</tr>";
        strHtml += "</thead>";

        //add rows

        decimal totalAmount = 0;
        string CurrencyName = "";
        strHtml += "<tbody>";
        int count = 0;
        if (dt.Rows.Count == 0)
        {
            strHtml += "<tr id=\"TableRprtRow\" >";
            strHtml += "<td class=\"thT\"colspan=11 style=\"width:11%;text-align: center; word-wrap:break-word;\">NO DATA AVAILABLE</th>";

        }
        else
        {
            var result = from tab in dt.AsEnumerable()
                         group tab by tab["CURRENCY"]
                             into groupDt
                             select new
                             {
                                 Group = groupDt.Key,
                                 Sum = groupDt.Sum((r) => decimal.Parse(r["AMOUNT"].ToString()))
                             };
            //if ((ddlDivisionSearch.SelectedItem.Text != "--SELECT ALL DIVISION--") || (ddlmodeSearch.SelectedItem.Text != "--SELECT ALL TYPE--") || (ddlCategorySearch.SelectedItem.Text != "--SELECT ALL TYPE--"))
            //{

            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                strHtml += "<tr id=\"TableRprtRow\" >";
                count++;
                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count + "</td>";
                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 0)
                    {
                        strHtml += "<td class=\"rowHeight1\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["INSURANCE REF#"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"rowHeight1\" style=\" width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["DATE OF INSURANCE"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"rowHeight1\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["INSURANCE TYPE"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 3)
                    {

                      //  strHtml += "<td class=\"rowHeight1\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["INSURANCE PERSON"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"rowHeight1\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PROJECT REF#"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 5)
                    {
                        strHtml += "<td class=\"rowHeight1\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["INSURANCE PROVIDER"].ToString() + "</td>";
                    }

                    //EVM-0016
                    if (intColumnBodyCount == 6)
                    {
                        strHtml += "<td class=\"rowHeight1\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["EXPIRY DATE"].ToString() + "</td>";
                    }
                    //EVM-0016
                    if (intColumnBodyCount == 7)
                    {
                    //    strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["JOB CODE"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 8)
                    {

                        string rchgAmnt = dt.Rows[intRowBodyCount]["AMOUNT"].ToString();

                        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                        string commarchgAmnt = objBusinessLayer.AddCommasForNumberSeperation(rchgAmnt, objEntityCommon);
                        strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: end;\" >" + commarchgAmnt + " </td>";
                        if (totalAmount == 0)
                        {
                            totalAmount = Convert.ToDecimal(rchgAmnt);
                        }
                        else
                        {
                            totalAmount = totalAmount + Convert.ToDecimal(rchgAmnt);
                        }
                    }
                    //EVM-0024
                    if (intColumnBodyCount == 9)
                    {
                        if (dt.Rows[intRowBodyCount]["CURRENCY"].ToString() != "")
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CURRENCY"].ToString() + "</td>";
                            CurrencyName = dt.Rows[intRowBodyCount]["CURRENCY"].ToString();
                        }
                    }
                    //END
                }
            }
            strHtml += "</tr>";

            foreach (var row in result)
            {
                strHtml += "<tr id=\"TableRprtRow\" >";
                strHtml += "<tfoot>";
                strHtml += "<td  class=\"tdT\" colspan=\"9\"; style=\"border-right-color: white;font-size: SMALL;width:6%;word-break: break-all; word-wrap:break-word;text-align: right;\" >Total</td>";
                string strtotalAmount = "";
                strtotalAmount = Convert.ToString(row.Sum);
                string strTotal = objBusiness.AddCommasForNumberSeperation(strtotalAmount, objEntityCommon);
                strHtml += "<td  class=\"tdT\"  style=\" border-right: navajowhite;font-size: SMALL;width:6%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strTotal + "</td>";
                strHtml += "<td  class=\"tdT\"  style=\" border-right: navajowhite;font-size: SMALL;width:6%;word-break: break-all; word-wrap:break-word;text-align: left;border-left-color: white;\" >" + row.Group + "</td>";
                strHtml += "</tfoot>";
            }
        }
        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    //Method for assigning  values to drop down list for Divisionfor search

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
    protected void BtnCSV_Click(object sender, EventArgs e)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dt = GetTable();
        string strImagePath;
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
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INSURANCE_EXPRY_RANGE);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.INSURANCE_EXPIRYRANG_CSV);
            string newFilePath = Server.MapPath(strImagePath+"/Insurance_Expiry_Range_Report_" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "Insurance_Expiry_Range_Report_" + strNextId + ".csv";
            ScriptManager.RegisterStartupScript(this, GetType(), "PrintClick", "PrintClick();", true);
            Response.ContentType = "csv";
     
            Response.AddHeader("content-Disposition", "attachment;filename=\"" + filepath + "\"");
            Response.TransmitFile(Server.MapPath(strImagePath) + filepath);
          
            Response.End();
            if (File.Exists(MapPath(strImagePath) + filepath))
            {
                File.Delete(MapPath(strImagePath) + filepath);
            }
        }
        catch (Exception)
        {
          //  throw;
        }
    }
    public DataTable GetTable()
    {
        ddlChange();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        btnNext.Enabled = false;
        btnPrevious.Enabled = false;
        hiddenPrevious.Value = "0";
        hiddenNext.Value = "";
        clsBusinessLayerInsuranceReports objBusinessLayerReports = new clsBusinessLayerInsuranceReports();
        clsEntityInsuraceReports objEntityReports = new clsEntityInsuraceReports();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityReports.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (ddlDivisionSearch.SelectedItem.Text == "--SELECT ALL DIVISION--")
        {
            objEntityReports.Division_Id = 0;
        }
        else
        {
            objEntityReports.Division_Id = Convert.ToInt32(ddlDivisionSearch.SelectedItem.Value);
        }

        if (ddlmodeSearch.SelectedItem.Text == "--SELECT ALL TYPE--")
        {
            objEntityReports.InsurExpiryRangeTO = new DateTime();
            objEntityReports.InsurTempID = 0;
        }
        else if (ddlmodeSearch.SelectedItem.Text == "1 month")
        {
            string todate = Hiddenstoretodate.Value;
            objEntityReports.InsurExpiryRangeTO = DateTime.ParseExact(todate, "dd-MM-yyyy", null);
            objEntityReports.InsurTempID = 1;
        }
        else if (ddlmodeSearch.SelectedItem.Text == "3 months")
        {
            string todate = Hiddenstoretodate.Value;
            objEntityReports.InsurExpiryRangeTO = DateTime.ParseExact(todate, "dd-MM-yyyy", null);
            objEntityReports.InsurTempID = 1;

        }
        else if (ddlmodeSearch.SelectedItem.Text == "Custom period")
        {
            objEntityReports.InsurExpiryRangeTO = tempdate;
            objEntityReports.InsurTempID = 1;
            string ans = Request.Form["ctl00$cphMain$txtToDate"];
            ans = String.Format("{0:dd-MM-yyyy}", ans);
            if (ans == "")
            {
                DateTime answer = DateTime.Today.Date;
                tempdate = answer;
            }
            else
            {
                DateTime answer = DateTime.ParseExact(ans, "dd-MM-yyyy", null);
                tempdate = answer;
            }
            objEntityReports.InsurExpiryRangeTO = tempdate;
        }
        hiddenSearch.Value = ddlDivisionSearch.SelectedItem.Value;
        string strDivisionSearch = ddlDivisionSearch.SelectedItem.Value;
        string strProductName = "";
        string strQueryString = strDivisionSearch + "_" + strProductName;
        DataTable dt = new DataTable();
        dt = objBusinessLayerReports.Read_ExpiryRange_LIstDetails(objEntityReports);
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        int first = Convert.ToInt32(hiddenPrevious.Value);
        clsCommonLibrary objCommon = new clsCommonLibrary();
        DataTable table = new DataTable();

        table.Columns.Add("INSURANCE REF#", typeof(string));
        table.Columns.Add("DATE OF INSURANCE", typeof(string));
        table.Columns.Add("INSURANCE TYPE", typeof(string));
       // table.Columns.Add("INSURANCE PERSON", typeof(string));
        table.Columns.Add("PROJECT REF#", typeof(string));
        table.Columns.Add("INSURANCE PROVIDER", typeof(string));
        table.Columns.Add("EXPIRY DATE", typeof(string));
       // table.Columns.Add("JOB CODE", typeof(string));
        table.Columns.Add("AMOUNT", typeof(string));
        table.Columns.Add("CURRENCY", typeof(string));
        for (int intRowBodyCount = first; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string TYPE = "";
            string DATE = "";
            string PERSON = "";
            string PROJECT = "";
            string EXPIRED = "";
            string JOB = "";
            string AMOUNT = "";
            string CURRENCY = "";
            string REf = "";
            string PROVIDER = "";
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                if (intColumnBodyCount == 0)
                {
                    REf = dt.Rows[intRowBodyCount]["INSURANCE REF#"].ToString();
                }
                if (intColumnBodyCount == 1)
                {
                    if (dt.Rows[intRowBodyCount]["DATE OF INSURANCE"].ToString() != "" && dt.Rows[intRowBodyCount]["DATE OF INSURANCE"].ToString() != null)
                    {
                        DATE = dt.Rows[intRowBodyCount]["DATE OF INSURANCE"].ToString();
                    }
                }
                if (intColumnBodyCount == 2)
                {
                    TYPE = dt.Rows[intRowBodyCount]["INSURANCE TYPE"].ToString();
                }
                //if (intColumnBodyCount == 3)
                //{
                //    PERSON = dt.Rows[intRowBodyCount]["INSURANCE PERSON"].ToString();
                //}
                if (intColumnBodyCount == 4)
                {
                    PROJECT = dt.Rows[intRowBodyCount]["PROJECT REF#"].ToString();
                }
                if (intColumnBodyCount == 5)
                {
                    PROVIDER = dt.Rows[intRowBodyCount]["INSURANCE PROVIDER"].ToString();
                }
                if (intColumnBodyCount == 6)
                {
                    if (dt.Rows[intRowBodyCount]["EXPIRY DATE"].ToString() != "" && dt.Rows[intRowBodyCount]["EXPIRY DATE"].ToString() != null)
                    {
                        EXPIRED = dt.Rows[intRowBodyCount]["EXPIRY DATE"].ToString();
                    }
                }
                //if (intColumnBodyCount == 7)
                //{
                //    JOB = dt.Rows[intRowBodyCount]["JOB CODE"].ToString();
                //}
                if (intColumnBodyCount == 8)
                {

                    string rchgAmnt = dt.Rows[intRowBodyCount]["AMOUNT"].ToString();

                    objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                    string commarchgAmnt = objBusinessLayer.AddCommasForNumberSeperation(rchgAmnt, objEntityCommon);

                    AMOUNT = rchgAmnt;
                }
                if (intColumnBodyCount == 9)
                {

                    CURRENCY = dt.Rows[intRowBodyCount]["CURRENCY"].ToString();
                }

            }
            table.Rows.Add('"' + REf + '"', '"' + DATE + '"', '"' + TYPE + '"',  '"' + PROJECT + '"', '"' + PROVIDER + '"', '"' + EXPIRED + '"', '"' + AMOUNT + '"', '"' + CURRENCY + '"');
        }
        return table;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ddlChange();

        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        btnNext.Enabled = false;
        btnPrevious.Enabled = false;
        hiddenPrevious.Value = "0";
        hiddenNext.Value = "";
        //Creating objects for businesslayer

        clsBusinessLayerInsuranceReports objBusinessLayerReports = new clsBusinessLayerInsuranceReports();
        clsEntityInsuraceReports objEntityReports = new clsEntityInsuraceReports();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityReports.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (ddlDivisionSearch.SelectedItem.Text == "--SELECT ALL DIVISION--")
        {
            objEntityReports.Division_Id = 0;
        }
        else
        {
            objEntityReports.Division_Id = Convert.ToInt32(ddlDivisionSearch.SelectedItem.Value);

        }

        if (ddlmodeSearch.SelectedItem.Text == "--SELECT ALL TYPE--")
        {
            objEntityReports.InsurExpiryRangeTO = new DateTime();
            objEntityReports.InsurTempID = 0;
        }
        else if (ddlmodeSearch.SelectedItem.Text == "1 month")
        {
            string todate = Hiddenstoretodate.Value;     //emp17
            objEntityReports.InsurExpiryRangeTO = DateTime.ParseExact(todate, "dd-MM-yyyy", null);
            objEntityReports.InsurTempID = 1;
        }
        else if (ddlmodeSearch.SelectedItem.Text == "3 months")
        {
            string todate = Hiddenstoretodate.Value;     //emp17
            objEntityReports.InsurExpiryRangeTO = DateTime.ParseExact(todate, "dd-MM-yyyy", null);
            objEntityReports.InsurTempID = 1;

        }
        else if (ddlmodeSearch.SelectedItem.Text == "Custom period")
        {

            objEntityReports.InsurExpiryRangeTO = tempdate;
            objEntityReports.InsurTempID = 1;
            string ans = Request.Form["ctl00$cphMain$txtToDate"];
            ans = String.Format("{0:dd-MM-yyyy}", ans);
            if (ans == "")
            {
                DateTime answer = DateTime.Today.Date;
                tempdate = answer;
            }
            else
            {
                DateTime answer = DateTime.ParseExact(ans, "dd-MM-yyyy", null);
                tempdate = answer;
            }
            objEntityReports.InsurExpiryRangeTO = tempdate;
        }
        hiddenSearch.Value = ddlDivisionSearch.SelectedItem.Value;

        string strDivisionSearch = ddlDivisionSearch.SelectedItem.Value;
        string strProductName = "";
        string strQueryString = strDivisionSearch + "_" + strProductName;
        //hiddenSearch.Value = strQueryString;
        objEntityReports.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);

        DataTable dtProductSrch = new DataTable();
        dtProductSrch = objBusinessLayerReports.Read_ExpiryRange_LIstDetails(objEntityReports);
        string strHtm = ConvertDataTableToHTML(dtProductSrch);
        divReport.InnerHtml = strHtm;
        DataTable dtCorp = objBusinessLayerReports.ReadCorporateAddress(objEntityReports);
        string strPrintReport = ConvertDataTableForPrint(dtProductSrch, dtCorp);
        divPrintReport.InnerHtml = strPrintReport;
        if (tempdate != null)
            hiddenDate.Value = tempdate.ToString("dd-MM-yyyy");
    }
    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        ddlDivisionSearch.ClearSelection();
        if (ddlDivisionSearch.Items.FindByValue(hiddenSearch.Value.ToString()) != null)
        {
            ddlDivisionSearch.Items.FindByValue(hiddenSearch.Value.ToString()).Selected = true;
        }
        //Creating objects for businesslayer


        clsBusinessLayerInsuranceReports objBusinessLayerReports = new clsBusinessLayerInsuranceReports();
        clsEntityInsuraceReports objEntityReports = new clsEntityInsuraceReports();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityReports.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (hiddenSearch.Value.ToString() == "--SELECT ALL DIVISION--")
        {
            objEntityReports.Division_Id = 0;
        }
        else
        {
            objEntityReports.Division_Id = Convert.ToInt32(hiddenSearch.Value.ToString());

        }

        DataTable dtProductList = objBusinessLayerReports.Read_ExpiryRange_LIstDetails(objEntityReports);
        int first = Convert.ToInt32(hiddenPrevious.Value) - Convert.ToInt32(hiddenTotalRowCount.Value);
        int last = Convert.ToInt32(hiddenPrevious.Value);
        hiddenPrevious.Value = first.ToString();
        hiddenNext.Value = last.ToString();
        if (first == 0)
        {
            btnPrevious.Enabled = false;

        }
        else
        {
            btnPrevious.Enabled = true;
        }
        if (last < dtProductList.Rows.Count)
        {

            btnNext.Enabled = true;
        }
        else
        {
            btnNext.Enabled = false;
        }
        //Write to divReport
        string strHtm = ConvertDataTableToHTML(dtProductList);
        divReport.InnerHtml = strHtm;
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        ddlDivisionSearch.ClearSelection();
        if (ddlDivisionSearch.Items.FindByValue(hiddenSearch.Value.ToString()) != null)
        {
            ddlDivisionSearch.Items.FindByValue(hiddenSearch.Value.ToString()).Selected = true;
        }
        //Creating objects for businesslayer
        clsBusinessLayerInsuranceReports objBusinessLayerReports = new clsBusinessLayerInsuranceReports();
        clsEntityInsuraceReports objEntityReports = new clsEntityInsuraceReports();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityReports.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (hiddenSearch.Value.ToString() == "--SELECT ALL DIVISION--")
        {
            objEntityReports.Division_Id = 0;
        }
        else
        {
            objEntityReports.Division_Id = Convert.ToInt32(hiddenSearch.Value.ToString());

        }



        DataTable dtProductList = objBusinessLayerReports.Read_ExpiryRange_LIstDetails(objEntityReports);
        int first = Convert.ToInt32(hiddenNext.Value);
        int last = Convert.ToInt32(hiddenNext.Value) + Convert.ToInt32(hiddenTotalRowCount.Value);
        hiddenPrevious.Value = first.ToString();
        hiddenNext.Value = last.ToString();
        if (first == 0)
        {
            btnPrevious.Enabled = false;

        }
        else
        {
            btnPrevious.Enabled = true;
        }
        if (last < dtProductList.Rows.Count)
        {

            btnNext.Enabled = true;
        }
        else
        {
            btnNext.Enabled = false;
        }
        //Write to divReport
        string strHtm = ConvertDataTableToHTML(dtProductList);
        divReport.InnerHtml = strHtm;

    }
    protected void ddlmodeSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        clsCommonLibrary objClsCommon = new clsCommonLibrary();

        DateTime today = DateTime.Now;

        if (ddlmodeSearch.SelectedIndex == 1)
        {
            string modifieddate = today.AddDays(30).ToString("dd-MM-yyyy");
            if (modifieddate != null)
            {

                Hiddenstoretodate.Value = modifieddate.ToString();
                // tempdate = modifieddate;
            }

        }
        else if (ddlmodeSearch.SelectedIndex == 2)
        {
            string modifieddate = today.AddDays(90).ToString("dd-MM-yyyy");       //emp17
            //    DateTime modifieddate = objClsCommon.textToDateTime(strmodifieddate);
            if (modifieddate != null)
            {

                Hiddenstoretodate.Value = modifieddate.ToString();
                // tempdate = objClsCommon.textToDateTime(modifieddate);
            }
        }
        else if (ddlmodeSearch.SelectedIndex == 3)
        {
            String selecteddate = Request.Form["ctl00$cphMain$txtToDate"];
            if (selecteddate == "")
            {
                DateTime modifieddate = DateTime.Today.Date;
                if (modifieddate == null)
                {


                    tempdate = modifieddate;
                }
            }
            else
            {
                DateTime modifieddate = DateTime.ParseExact(selecteddate, "dd-MM-yyyy", null); ;
                if (modifieddate == null)
                {


                    tempdate = modifieddate;
                }
            }
        }
    }

    public void ddlChange()
    {
        clsCommonLibrary objClsCommon = new clsCommonLibrary();

        DateTime today = DateTime.Now;

        if (ddlmodeSearch.SelectedIndex == 1)
        {
            string modifieddate = today.AddDays(30).ToString("dd-MM-yyyy");
            if (modifieddate != null)
            {

                Hiddenstoretodate.Value = modifieddate.ToString();
                // tempdate = modifieddate;
            }

        }
        else if (ddlmodeSearch.SelectedIndex == 2)
        {
            string modifieddate = today.AddDays(90).ToString("dd-MM-yyyy");       //emp17
            //    DateTime modifieddate = objClsCommon.textToDateTime(strmodifieddate);
            if (modifieddate != null)
            {

                Hiddenstoretodate.Value = modifieddate.ToString();
                // tempdate = objClsCommon.textToDateTime(modifieddate);
            }
        }
        else if (ddlmodeSearch.SelectedIndex == 3)
        {
            String selecteddate = Request.Form["ctl00$cphMain$txtToDate"];
            if (selecteddate == "")
            {
                DateTime modifieddate = DateTime.Today.Date;
                if (modifieddate == null)
                {


                    tempdate = modifieddate;
                }
            }
            else
            {
                DateTime modifieddate = DateTime.ParseExact(selecteddate, "dd-MM-yyyy", null); ;
                if (modifieddate == null)
                {


                    tempdate = modifieddate;
                }
            }
        }
    }


}