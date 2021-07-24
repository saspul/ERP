using BL_Compzit;
using BL_Compzit.BusinessLayer_GMS;
using CL_Compzit;
using EL_Compzit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections.Generic;
using System.Linq;
public partial class GMS_Reports_Rep_Guarantee_Type_Rep_Guarantee_Type : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        divTitle.InnerHtml = "Guarantee Category Wise Report ";
        ddlDivisionSearch.Attributes.Add("onkeypress", "return DisableEnter(event)");
        if (!IsPostBack)
        {
            ddlDivisionSearch.Focus();
            ddlmodeSearch.Items.Insert(0, "--SELECT GUARANTEE MODE--");
            btnNext.Enabled = false;
            btnPrevious.Enabled = false;
            Division_Load();
            Category_Load();
            CurrencyLoad();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            //Creating objects for business layer
            clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();
            clsEntityReports objEntityReports = new clsEntityReports();

            DataTable dtProductList = new DataTable();
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
                                                                clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                               };


            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            //  string CnclrsnMust = "";
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();

                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                //CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();





            }
            // for adding comma
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
            }
            dtProductList = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);


            if (dtProductList.Rows.Count > 0)
            {
                string strListingMode = dtProductList.Rows[0]["LISTING_MODE"].ToString();
                string strLstingModeSize = dtProductList.Rows[0]["LISTING_MODE_SIZE"].ToString();


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
                DataTable dtProductListing = objBusinessLayerReports.Read_Guarantee_List(objEntityReports);
                string strReport = ConvertDataTableToHTML(dtProductListing);
                divReport.InnerHtml = strReport;
                DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(objEntityReports);
                string strPrintReport = ConvertDataTableForPrint(dtProductListing, dtCorp);
                divPrintReport.InnerHtml = strPrintReport;
            }

        }
    }
    public void CurrencyLoad()
    {
        clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();
        clsEntityReports ObjEntityBankGuarantee = new clsEntityReports();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityBankGuarantee.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            ObjEntityBankGuarantee.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            ObjEntityBankGuarantee.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtSubConrt = objBusinessLayerReports.ReadCurrency(ObjEntityBankGuarantee);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlCurrency.DataSource = dtSubConrt;
            ddlCurrency.DataTextField = "CRNCMST_NAME";
            ddlCurrency.DataValueField = "CRNCMST_ID";
            ddlCurrency.DataBind();

        }
        //   ddlCurrency.Items.Insert(0, "--SELECT CURRENCY--");
        DataTable dtDefaultcurc = objBusinessLayerReports.ReadDefualtCurrency(ObjEntityBankGuarantee);
        string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        //ddlCurrency.Items.Insert(0, "--SELECT CURRENCY--");
        if (ddlCurrency.Items.FindByValue(strdefltcurrcy) != null)
            ddlCurrency.Items.FindByValue(strdefltcurrcy).Selected = true;
    }
    //Method for assigning  values to drop down list for Divisionfor search
    public void Division_Load()
    {
        clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();
        clsEntityReports objEntityReports = new clsEntityReports();
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

        DataTable dtDivision = objBusinessLayerReports.Read_Division(objEntityReports);



        //Division
        ddlDivisionSearch.DataSource = dtDivision;

        ddlDivisionSearch.DataTextField = "CPRDIV_NAME";
        ddlDivisionSearch.DataValueField = "CPRDIV_ID";
        ddlDivisionSearch.DataBind();
        ddlDivisionSearch.Items.Insert(0, "--SELECT ALL DIVISION--");


    }
    //cataegoryload
    public void Category_Load()
    {
        clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();
        clsEntityReports objEntityReports = new clsEntityReports();
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

        //   DataTable dtDivision = objBusinessLayerReports.Read_Division(objEntityReports);



        //Division
        //ddlCategorySearch.DataSource = dtDivision;


        ddlCategorySearch.Items.Insert(0, "--SELECT ALL METHOD--");
        ddlCategorySearch.Items.Insert(1, "Supplier Guarantee");
        ddlCategorySearch.Items.Insert(2, "Client Guarantee");

    }
    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt)
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        int first = Convert.ToInt32(hiddenPrevious.Value);
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

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
                strHtml += "<th class=\"thT\" style=\"width:16%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:12%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
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
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">EXPIRY DATE</th>";
            }
            //END
            if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns["BANK"].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\"  style=\"width:9%;text-align: left; word-wrap:break-word;\">" + dt.Columns["JOB CODE"].ColumnName + "</th>";
            }
               if (intColumnHeaderCount == 9)
            {
                strHtml += "<th class=\"thT\" style=\"width:9%;text-align: right; word-wrap:break-word;\">" + dt.Columns["AMOUNT"].ColumnName + "</th>";
            }
            //EVM-0024
            if (intColumnHeaderCount == 10)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: left; word-wrap:break-word;\">CURRENCY</th>";
            }
        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        int count = 0;
        lblToalRowCount.Text = "0";
        if ((ddlDivisionSearch.SelectedItem.Text != "--SELECT ALL DIVISION--") || (ddlmodeSearch.SelectedItem.Text != "--SELECT GUARANTEE MODE--") || (ddlCategorySearch.SelectedItem.Text != "--SELECT ALL METHOD--"))
        {
             lblToalRowCount.Text = dt.Rows.Count.ToString();
            for (int intRowBodyCount = first; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                count++;
                strHtml += "<tr  >";

                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count + "</td>";
                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {
                    if (intColumnBodyCount == 0)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:16%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["GUARANTEE REF#"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 1)
                    {
                        string hiddenDate = "";
                        if (dt.Rows[intRowBodyCount]["DATE OF GUARANTEE"].ToString() != "" && dt.Rows[intRowBodyCount]["DATE OF GUARANTEE"].ToString() != null)
                        {
                            string[] arr = new string[3];
                            arr = dt.Rows[intRowBodyCount]["DATE OF GUARANTEE"].ToString().Split('-');
                            hiddenDate = arr[2] + arr[1] + arr[0];
                        }
                        strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" ><span style=\"display:none;\">" + hiddenDate + "</span>" + dt.Rows[intRowBodyCount]["DATE OF GUARANTEE"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["GUARANTEE METHOD "].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 3)
                    {
                        if (dt.Rows[intRowBodyCount]["CSTMR_REFNUM"].ToString() == "")
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["SUPPLIER/CLIENT NAME"].ToString() + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["SUPPLIER/CLIENT NAME"].ToString() + " (" + dt.Rows[intRowBodyCount]["CSTMR_REFNUM"].ToString() + ")" + "</td>";
                        }
                    }
                    if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td title=\"" + dt.Rows[intRowBodyCount][7].ToString() + "\"  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left; \" >" + dt.Rows[intRowBodyCount]["PROJECT REF#"].ToString() + "</td>";
                    }


                    if (intColumnBodyCount == 5)
                    {
                        string hiddenDate = "";
                        if (dt.Rows[intRowBodyCount]["EXPIRY DATE"].ToString() != "" && dt.Rows[intRowBodyCount]["EXPIRY DATE"].ToString() != null)
                        {
                            string[] arr = new string[3];
                            arr = dt.Rows[intRowBodyCount]["EXPIRY DATE"].ToString().Split('-');
                            hiddenDate = arr[2] + arr[1] + arr[0];
                        }
                        strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" ><span style=\"display:none;\">" + hiddenDate + "</span>" + dt.Rows[intRowBodyCount]["EXPIRY DATE"].ToString() + "</td>";

                    }
                    if (intColumnBodyCount == 6)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["BANK"].ToString() + "</td>";

                    }
                    else if (intColumnBodyCount == 7)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["JOB CODE"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 9)
                    {
                        string rchgAmnt = dt.Rows[intRowBodyCount]["AMOUNT"].ToString();

                        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                        string commarchgAmnt = objBusinessLayer.AddCommasForNumberSeperation(rchgAmnt, objEntityCommon);

                        strHtml += "<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + commarchgAmnt + "</td>";


                    }
                    //EVM-24
                    if (intColumnBodyCount == 10)
                    {
                        string currency = dt.Rows[intRowBodyCount]["CURRENCY NAME"].ToString();
                        strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + currency + "</td>";
                        HiddenCurrency.Value = currency;
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
    //for creating HTML Title
    private string SetTitle(string size, string value)
    {

        return "<h" + size + "><p align=center>" + value + "</p align></h" + size + ">";

    }
    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        ddlDivisionSearch.ClearSelection();
        if (ddlDivisionSearch.Items.FindByValue(hiddenSearch.Value.ToString()) != null)
        {
            ddlDivisionSearch.Items.FindByValue(hiddenSearch.Value.ToString()).Selected = true;
        }
        //Creating objects for businesslayer
        clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();
        clsEntityReports objEntityReports = new clsEntityReports();

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
        objEntityReports.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);

        DataTable dtProductList = objBusinessLayerReports.Read_Guarantee_List(objEntityReports);
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
        clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();
        clsEntityReports objEntityReports = new clsEntityReports();
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
        objEntityReports.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);



        DataTable dtProductList = objBusinessLayerReports.Read_Guarantee_List(objEntityReports);
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

    //at search button click
    protected void btnSearch_Click(object sender, EventArgs e)
    {


        btnNext.Enabled = false;
        btnPrevious.Enabled = false;
        hiddenPrevious.Value = "0";
        hiddenNext.Value = "";
        //Creating objects for businesslayer
        clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();
        clsEntityReports objEntityReports = new clsEntityReports();
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
        if (ddlCategorySearch.SelectedItem.Text == "--SELECT ALL METHOD--")
        {
            objEntityReports.GuaranteeTypeId = 0;
        }
        else if (ddlCategorySearch.SelectedItem.Text == "Client Guarantee")
        {
            objEntityReports.GuaranteeTypeId = 101;

        }
        else if (ddlCategorySearch.SelectedItem.Text == "Supplier Guarantee")
        {
            objEntityReports.GuaranteeTypeId = 102;

        }
        if (ddlmodeSearch.SelectedItem.Text == "--SELECT GUARANTEE MODE--")
        {
            objEntityReports.GuaranteeModeId = 0;
        }
        else
        {
            objEntityReports.GuaranteeModeId = Convert.ToInt32(ddlmodeSearch.SelectedItem.Value);

        }


        hiddenSearch.Value = ddlDivisionSearch.SelectedItem.Value;

        string strDivisionSearch = ddlDivisionSearch.SelectedItem.Value;
        string strProductName = "";
        string strQueryString = strDivisionSearch + "_" + strProductName;
        //hiddenSearch.Value = strQueryString;
        DataTable dtProductSrch = new DataTable();
        objEntityReports.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);

        dtProductSrch = objBusinessLayerReports.Read_Guarantee_List(objEntityReports);
        string strHtm = ConvertDataTableToHTML(dtProductSrch);
        divReport.InnerHtml = strHtm;
        DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(objEntityReports);
        string strPrintReport = ConvertDataTableForPrint(dtProductSrch, dtCorp);
        divPrintReport.InnerHtml = strPrintReport;
    }


    //It build the Html table for printing by using the datatable provided
    public string ConvertDataTableForPrint(DataTable dt, DataTable dtCorp)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
     //   clsCommonLibrary objCommon = new clsCommonLibrary();
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Guarantee Category Wise Report ";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string usrName = "<B> Report Generated By: </B>" + Session["USERFULLNAME"];
       // string TotalRowCnt = "<B>Category Wise Total Guarantee: </B>" + dt.Rows.Count;
        //for printing product division on print
        string division="";
        string category="";
        string mode="";
        string strUsrName="";
        string strTotalCount = "";
        if (ddlDivisionSearch.SelectedItem.Text.ToString() == "--SELECT ALL DIVISION--")
        {
            division = "";
        }
        else
        {
            division = "<B>Guarantee Division : </B>" + ddlDivisionSearch.SelectedItem.Text;
        }
        if (ddlCategorySearch.SelectedItem.Text.ToString() == "--SELECT ALL METHOD--")
        {
            category = "";
        }
        else
        {
            category = "<B>Guarantee Method : </B>" + ddlCategorySearch.SelectedItem.Text;
        }

        if (ddlmodeSearch.SelectedItem.Text.ToString() == "--SELECT GUARANTEE MODE--")
        {
            mode = "";
        }
        else
        {
            mode = "<B>Guarantee Category : </B>" + ddlmodeSearch.SelectedItem.Text;
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



        string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr + "</td></tr>";
        string strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        string strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
        string strDivisionTitle = "", strCategoryTitle = "", strTypeTitle = "";
        if (division != "")
        {
             strDivisionTitle = "<tr><td class=\"RprtDiv\">" + division + "</td></tr>";
        }
        if (category != "")
        {
             strCategoryTitle = "<tr><td class=\"RprtDiv\">" + category + "</td></tr>";
        }
        if (mode != "")
        {
            strTypeTitle = "<tr><td class=\"RprtDiv\">" + mode + "</td></tr>";
        }
        if (usrName != "")
        {
            strUsrName = "<tr><td class=\"RprtDiv\">" + usrName + "</td></tr>";
        }
        //if (TotalRowCnt != "")
        //{
        //    strTotalCount = "<tr><td class=\"RprtDiv\">" + TotalRowCnt + "</td></tr>";
        //}
        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strDivisionTitle + strCategoryTitle + strTypeTitle + strUsrName +strCaptionTabTitle + strCaptionTabstop;



        sbCap.Append(strPrintCaptionTable);
        //write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString(); ;


        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"main_table\"  >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";
        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">SL#</th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 0)
            {
                strHtml += "<td class=\"thT\" style=\"width:11%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            if (intColumnHeaderCount == 1)
            {
                strHtml += "<td class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<td class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<td class=\"thT\" style=\"width:16%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<td class=\"thT\" style=\"width:12%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
     
            if (intColumnHeaderCount == 5)
            {
                strHtml += "<td class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">EXPIRY DATE</th>";
            }
            if (intColumnHeaderCount ==6)
            {
                strHtml += "<td class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns["BANK"].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns["JOB CODE"].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 9)
            {
                strHtml += "<td class=\"thT\" style=\"width:14%;text-align: right; word-wrap:break-word;\">" + dt.Columns["AMOUNT"].ColumnName + "</th>";

            }
            //EVM-0024
            if (intColumnHeaderCount == 10)
            {
                strHtml += "<td class=\"thT\" style=\"width:8%;text-align: left; word-wrap:break-word;\">CURRENCY</th>";
            }
            //END

        }

        strHtml += "</tr>";
        strHtml += "</thead>";

        //add rows
        decimal totalAmount = 0;
        string currency = "";
        strHtml += "<tbody>";
        int count = 0;
        if (dt.Rows.Count == 0)
        {
            strHtml += "<tr id=\"TableRprtRow\" >";

            strHtml += "<td class=\"thT\"colspan=10 style=\"width:11%;text-align: center; word-wrap:break-word;\">NO DATA AVAILABLE</th>";
            strHtml += "</tr>";
        }
        else
        {
            var result = from tab in dt.AsEnumerable()
                         group tab by tab["CURRENCY NAME"]
                             into groupDt
                             select new
                             {
                                 Group = groupDt.Key,
                                 Sum = groupDt.Sum((r) => decimal.Parse(r["AMOUNT"].ToString()))
                             };
            if ((ddlDivisionSearch.SelectedItem.Text != "--SELECT ALL DIVISION--") || (ddlmodeSearch.SelectedItem.Text != "--SELECT GUARANTEE MODE--") || (ddlCategorySearch.SelectedItem.Text != "--SELECT ALL METHOD--"))
            {
                for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
                {
                    count++;
                    strHtml += "<tr id=\"TableRprtRow\" >";
                    strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count + "</td>";
                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {
                        if (intColumnBodyCount == 0)
                        {
                            strHtml += "<td class=\"rowHeight1\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["GUARANTEE REF#"].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 1)
                        {
                            strHtml += "<td class=\"rowHeight1\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["DATE OF GUARANTEE"].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 2)
                        {
                            strHtml += "<td class=\"rowHeight1\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["GUARANTEE METHOD "].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 3)
                        {
                            if (dt.Rows[intRowBodyCount]["CSTMR_REFNUM"].ToString() == "")
                            {
                                strHtml += "<td class=\"rowHeight1\" style=\" width:16%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["SUPPLIER/CLIENT NAME"].ToString() + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"rowHeight1\" style=\" width:16%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["SUPPLIER/CLIENT NAME"].ToString() + " (" + dt.Rows[intRowBodyCount]["CSTMR_REFNUM"].ToString() + ")" + "</td>";
                            }
                        }
                        if (intColumnBodyCount == 4)
                        {
                            strHtml += "<td class=\"rowHeight1\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PROJECT REF#"].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 5)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["EXPIRY DATE"].ToString() + "</td>";


                        }
                        if (intColumnBodyCount == 6)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["BANK"].ToString() + "</td>";


                        }
                        else if (intColumnBodyCount == 7)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["JOB CODE"].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 9)
                        {
                            string rchgAmnt = dt.Rows[intRowBodyCount]["AMOUNT"].ToString();
                            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                            string commarchgAmnt = objBusinessLayer.AddCommasForNumberSeperation(rchgAmnt, objEntityCommon);
                            strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: end;\" >" + commarchgAmnt + "</td>";
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
                        if (intColumnBodyCount == 10)
                        {
                            currency = dt.Rows[intRowBodyCount]["CURRENCY NAME"].ToString();
                            strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + currency + "</td>";
                        }


                    }
                    strHtml += "</tr>";
                }
           
            
       
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
            else
            {

                strHtml += "<tr id=\"TableRprtRow\" >";
                strHtml += "<tfoot>";
                strHtml += "<td class=\"thT\"colspan=11 style=\"width:11%;text-align: center; word-wrap:break-word;\">NO DATA AVAILABLE</th>";
                strHtml += "</tfoot>";
                strHtml += "</tr>";
            }
        }
        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();

    }
    protected void ddlCategorySearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();
        clsEntityReports objEntityReports = new clsEntityReports();
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


        int id = ddlCategorySearch.SelectedIndex;
        objEntityReports.GuaranteeModeId = id;
        DataTable dtDivision = objBusinessLayerReports.Read_Category(objEntityReports);



        //Division
        ddlmodeSearch.DataSource = dtDivision;

        ddlmodeSearch.DataTextField = "GUANTCAT_NAME";
        ddlmodeSearch.DataValueField = "GUANTCAT_ID";
        ddlmodeSearch.DataBind();
        ddlmodeSearch.Items.Insert(0, "--SELECT GUARANTEE MODE--");


    }
    protected void ddlCategorySearch_SelectedIndexChanged1(object sender, EventArgs e)
    {


    }
    protected void ddlCategorySearch_SelectedIndexChanged2(object sender, EventArgs e)
    {
        clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();
        clsEntityReports objEntityReports = new clsEntityReports();
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


        int id = ddlCategorySearch.SelectedIndex;
        objEntityReports.GuaranteeModeId = id;
        DataTable dtDivision = objBusinessLayerReports.Read_Category(objEntityReports);



        //Division
        ddlmodeSearch.DataSource = dtDivision;

        ddlmodeSearch.DataTextField = "GUANTCAT_NAME";
        ddlmodeSearch.DataValueField = "GUANTCAT_ID";
        ddlmodeSearch.DataBind();
        ddlmodeSearch.Items.Insert(0, "--SELECT GUARANTEE MODE--");
    }
    //for sorting drop down
    private void SortDDL(ref DropDownList objDDL)
    {
        ArrayList textList = new ArrayList();
        ArrayList valueList = new ArrayList();


        foreach (ListItem li in objDDL.Items)
        {
            textList.Add(li.Text);
        }

        textList.Sort();


        foreach (object item in textList)
        {
            string value = objDDL.Items.FindByText(item.ToString()).Value;
            valueList.Add(value);
        }
        objDDL.Items.Clear();

        for (int i = 0; i < textList.Count; i++)
        {
            ListItem objItem = new ListItem(textList[i].ToString(), valueList[i].ToString());
            objDDL.Items.Add(objItem);
        }
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
        btnNext.Enabled = false;
        btnPrevious.Enabled = false;
        hiddenPrevious.Value = "0";
        hiddenNext.Value = "";
        //Creating objects for businesslayer
        clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();
        clsEntityReports objEntityReports = new clsEntityReports();
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
        if (ddlCategorySearch.SelectedItem.Text == "--SELECT ALL METHOD--")
        {
            objEntityReports.GuaranteeTypeId = 0;
        }
        else if (ddlCategorySearch.SelectedItem.Text == "Client Guarantee")
        {
            objEntityReports.GuaranteeTypeId = 101;

        }
        else if (ddlCategorySearch.SelectedItem.Text == "Supplier Guarantee")
        {
            objEntityReports.GuaranteeTypeId = 102;

        }
        if (ddlmodeSearch.SelectedItem.Text == "--SELECT GUARANTEE MODE--")
        {
            objEntityReports.GuaranteeModeId = 0;
        }
        else
        {
            objEntityReports.GuaranteeModeId = Convert.ToInt32(ddlmodeSearch.SelectedItem.Value);
        }
        hiddenSearch.Value = ddlDivisionSearch.SelectedItem.Value;
        string strDivisionSearch = ddlDivisionSearch.SelectedItem.Value;
        string strProductName = "";
        string strQueryString = strDivisionSearch + "_" + strProductName;
        DataTable dt = new DataTable();
        objEntityReports.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);

        dt = objBusinessLayerReports.Read_Guarantee_List(objEntityReports);
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        int first = Convert.ToInt32(hiddenPrevious.Value);
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable table = new DataTable();
        table.Columns.Add("GUARANTEE REF#", typeof(string));
        table.Columns.Add("DATE OF GUARANTEE", typeof(string));
        table.Columns.Add("GUARANTEE METHOD", typeof(string));
        table.Columns.Add("SUPPLIER/CLIENT NAME", typeof(string));
        table.Columns.Add("PROJECT REF#", typeof(string));
        table.Columns.Add("EXPIRY DATE", typeof(string));
        table.Columns.Add("BANK", typeof(string));
        table.Columns.Add("JOB CODE", typeof(string));
        table.Columns.Add("AMOUNT", typeof(string));
        table.Columns.Add("CURRENCY", typeof(string));
        if ((ddlDivisionSearch.SelectedItem.Text != "--SELECT ALL DIVISION--") || (ddlmodeSearch.SelectedItem.Text != "--SELECT GUARANTEE MODE--") || (ddlCategorySearch.SelectedItem.Text != "--SELECT ALL METHOD--"))
        {
            for (int intRowBodyCount = first; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                string method = "";
                string DATE = "";
                string CUSTOMER = "";
                string PROJECT = "";
                string EXPIRED = "";
                string JOB = "";
                string AMOUNT = "";
                string CURRENCY = "";
                string REf = "";
                string BANK = "";
                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {
                    if (intColumnBodyCount == 0)
                    {
                        REf = dt.Rows[intRowBodyCount]["GUARANTEE REF#"].ToString();
                    }
                    if (intColumnBodyCount == 1)
                    {
                        if (dt.Rows[intRowBodyCount]["DATE OF GUARANTEE"].ToString() != "" && dt.Rows[intRowBodyCount]["DATE OF GUARANTEE"].ToString() != null)
                        {
                            DATE = dt.Rows[intRowBodyCount]["DATE OF GUARANTEE"].ToString();
                        }
                    }
                    if (intColumnBodyCount == 2)
                    {
                        method = dt.Rows[intRowBodyCount]["GUARANTEE METHOD "].ToString();
                    }
                    if (intColumnBodyCount == 3)
                    {
                        if (dt.Rows[intRowBodyCount]["CSTMR_REFNUM"].ToString() == "")
                        {
                            CUSTOMER = dt.Rows[intRowBodyCount]["SUPPLIER/CLIENT NAME"].ToString();
                        }
                        else
                        {
                            CUSTOMER = dt.Rows[intRowBodyCount]["SUPPLIER/CLIENT NAME"].ToString() + " (" + dt.Rows[intRowBodyCount]["CSTMR_REFNUM"].ToString() + ")";
                        }
                    }
                    if (intColumnBodyCount == 4)
                    {
                        PROJECT = dt.Rows[intRowBodyCount]["PROJECT REF#"].ToString();
                    }


                    if (intColumnBodyCount == 5)
                    {
                        if (dt.Rows[intRowBodyCount]["EXPIRY DATE"].ToString() != "" && dt.Rows[intRowBodyCount]["EXPIRY DATE"].ToString() != null)
                        {
                            EXPIRED = dt.Rows[intRowBodyCount]["EXPIRY DATE"].ToString();
                        }

                    }
                    if (intColumnBodyCount == 6)
                    {
                        BANK = dt.Rows[intRowBodyCount]["BANK"].ToString();

                    }
                    else if (intColumnBodyCount == 7)
                    {
                        JOB = dt.Rows[intRowBodyCount]["JOB CODE"].ToString();
                    }
                    if (intColumnBodyCount == 9)
                    {
                        string rchgAmnt = dt.Rows[intRowBodyCount]["AMOUNT"].ToString();
                        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                        string commarchgAmnt = objBusinessLayer.AddCommasForNumberSeperation(rchgAmnt, objEntityCommon);
                        AMOUNT = rchgAmnt;
                    }
                    //EVM-24
                    if (intColumnBodyCount == 10)
                    {
                        string currency = dt.Rows[intRowBodyCount]["CURRENCY NAME"].ToString();
                        CURRENCY = currency;
                    }
                }
                table.Rows.Add('"' + REf + '"', '"' + DATE + '"', '"' + method + '"', '"' + CUSTOMER + '"', '"' + PROJECT + '"', '"' + EXPIRED + '"', '"' + BANK + '"', '"' + JOB + '"', '"' + AMOUNT + '"', '"' + CURRENCY + '"');


            }
        }
        else
        {
            string method = "";
            string DATE = "";
            string CUSTOMER = "";
            string PROJECT = "";
            string EXPIRED = "";
            string JOB = "";
            string AMOUNT = "";
            string CURRENCY = "";
            string REf = "";
            string BANK = "";
            table.Rows.Add('"' + REf + '"', '"' + DATE + '"', '"' + method + '"', '"' + CUSTOMER + '"', '"' + PROJECT + '"', '"' + EXPIRED + '"', '"' + BANK + '"', '"' + JOB + '"', '"' + AMOUNT + '"', '"' + CURRENCY + '"');

        }
        return table;
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
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.GUARATETYPE_CSV);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
            string newFilePath = Server.MapPath("/CustomFiles/GMS CSV/Guarantee Type/Guarantee_Category_Wise_Report_" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "Guarantee_Category_Wise_Report_" + strNextId + ".csv";
            Response.ContentType = "csv";
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.GUARANTEETYPE_CSV);
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


