using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using BL_Compzit.BusinessLayer_GMS;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using System.IO;
public partial class HCM_HCM_Reports_hcm_OnBoard_Status_Report_hcm_Onboard_Status_Report : System.Web.UI.Page
{
    ClsBusinessExpiryNotificationReport objBusinessLayerReports = new ClsBusinessExpiryNotificationReport();
    ClsEntityExpiryNotificationReport objEntityReports = new ClsEntityExpiryNotificationReport();
    clsCommonLibrary objCommon = new clsCommonLibrary();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
           
            //Creating objects for business layer
           
            // ddlDivisionSearch.Focus();
            //  ddlmodeSearch.Items.Insert(0, "--SELECT ALL CATEGORY--");
            btnNext.Enabled = false;
            btnPrevious.Enabled = false;



            // Division_Load();
            // Category_Load();
          

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

            DataTable dtDivision = new DataTable();
            dtDivision = objBusinessLayerReports.ReadDivision(objEntityReports);

            ddlDivision.Items.Clear();
            ddlDivision.DataSource = dtDivision;

            ddlDivision.DataTextField = "CPRDIV_NAME";
            ddlDivision.DataValueField = "CPRDIV_ID";
            ddlDivision.DataBind();

            ddlDivision.Items.Insert(0, "--SELECT DIVISION--");



            DataTable dtDepts = new DataTable();
            dtDepts = objBusinessLayerReports.ReadDepts(objEntityReports);

            ddlDepartmnt.Items.Clear();
            ddlDepartmnt.DataSource = dtDepts;
            ddlDepartmnt.DataTextField = "CPRDEPT_NAME";
            ddlDepartmnt.DataValueField = "CPRDEPT_ID";
            ddlDepartmnt.DataBind();
            ddlDepartmnt.Items.Insert(0, "--SELECT DEPARTMENT--");
            //END


            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE ,
                                                                clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                               };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            //  string CnclrsnMust = "";
            if (dtCorpDetail.Rows.Count > 0)
            {


                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                //CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();





            } dtProductList = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);


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
                if (ddlStatus.SelectedItem.Text == "-- SELECT STATUS--")
                {
                    objEntityReports.Status = 0;
                }
                else
                {
                    objEntityReports.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
                }
                DataTable dtCorp = objBusinessLayerReports.ReadCorporateAddress(objEntityReports);
                objEntityReports.Organisation_Id = 0;
                objEntityReports.Corporate_Id = 0;
                DataTable dtProductListing = objBusinessLayerReports.Read_Expiry_Notification_List(objEntityReports);
                string strReport = ConvertDataTableToHTML(dtProductListing);
                divReport.InnerHtml = strReport;
                string strPrintReport = ConvertDataTableForPrint(dtProductListing, dtCorp);
                divPrintReport.InnerHtml = strPrintReport;
            }
            //EVM-0027



        }

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
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">HOLDER ID</th>";
            }
            if (intColumnHeaderCount == 1)
            {
             strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">HOLDER NAME</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: right; word-wrap:break-word;\">NUMBER</th>";
            }
            if (intColumnHeaderCount == 3)
            {

                if (Radiovisa.Checked == true)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">EXPIRY DATE</th>";
                }
                else if (RadioNationlid.Checked == true||Radiopassport.Checked == true)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">ISSUED DATE</th>";

                }
                
            }
            if (intColumnHeaderCount == 4)
            {
                if (Radiovisa.Checked == true)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">ISSUED BY</th>";
                }
                else if (RadioNationlid.Checked == true||Radiopassport.Checked == true||RadioHC.Checked==true)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">EXPIRY DATE</th>";
                }
               
            }
            if (intColumnHeaderCount ==5)
            {
                if (Radiovisa.Checked == true)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">TYPE</th>";
                }
                else if (RadioNationlid.Checked == true || Radiopassport.Checked == true )
                {
                    strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">ISSUED BY</th>";

                }
                else if (RadioHC.Checked == true)
                {
                    strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">ISSUED BY</th>";
                    
                }
               
            }
            if (intColumnHeaderCount == 6)
            {
              strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">STATUS</th>";
               
            }
        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        string status="";
        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr  >";
     
           
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                if (intColumnBodyCount == 0)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</td>";
                }
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_NAME"].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + dt.Rows[intRowBodyCount]["EMPIMG_DOC_NUMBER"].ToString() + "</td>";
                }

                if (intColumnBodyCount == 3)
                {
                                        
                    if (Radiovisa.Checked == true)
                    {
                                              
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["EMPIMG_DOC_EXPDATE"].ToString() + "</td>";
                    }
                    ////else if (RadioHC.Checked == true)
                    ////{
                    ////    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["HC_CENTER_NUM"].ToString() + "</td>";

                    ////}
                    else if(RadioNationlid.Checked==true||Radiopassport.Checked==true)
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["EMPIMG_DOC_ISSUEDATE"].ToString() + "</td>";

                }
                if (intColumnBodyCount == 4)
                {
                    if (Radiovisa.Checked == true)
                    {
                        strHtml += "<td title=\"" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "\"  class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left; \" >" + dt.Rows[intRowBodyCount]["CNTRY_NAME"].ToString().ToUpper() + "</td>";
                    }
                    else
                    {
                        strHtml += "<td title=\"" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "\"  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; \" >" + dt.Rows[intRowBodyCount]["EMPIMG_DOC_EXPDATE"].ToString().ToUpper() + "</td>";
                    }

                }
                if (intColumnBodyCount == 5)
                {
                    if (Radiovisa.Checked == true)
                    {
                        strHtml += "<td title=\"" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "\"  class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left; \" >" + dt.Rows[intRowBodyCount]["VISA_NAME"].ToString().ToUpper() + "</td>";
                    }
                  
                    else

                    strHtml += "<td title=\"" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "\"  class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left; \" >" + dt.Rows[intRowBodyCount]["CNTRY_NAME"].ToString().ToUpper() + "</td>";
                }
                if (intColumnBodyCount == 6)
                {
                    if (dt.Rows[intRowBodyCount]["EMPIMG_DOC_EXPDATE"].ToString() != null && dt.Rows[intRowBodyCount]["EMPIMG_DOC_EXPDATE"].ToString() !="")
                    {
                        DateTime ExpDate = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["EMPIMG_DOC_EXPDATE"].ToString());
                        if (ExpDate > DateTime.Today)
                        {
                            status = "Not Expired";

                        }
                        else
                            status = "Expired";
                 }

                    strHtml += "<td title=\"" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "\"  class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center; \" >" + status + "</td>";

                }
            }
          
            strHtml += "</tr>";
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

        ////Creating objects for businesslayer
        //clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();
        //clsEntityReports objEntityReports = new clsEntityReports();

        //if (Session["CORPOFFICEID"] != null)
        //{
        //    objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        //}
        //else if (Session["CORPOFFICEID"] == null)
        //{
        //    Response.Redirect("~/Default.aspx");
        //}
        //if (Session["ORGID"] != null)
        //{
        //    objEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

        //}
        //else if (Session["ORGID"] == null)
        //{
        //    Response.Redirect("~/Default.aspx");
        //}
        //if (Session["USERID"] != null)
        //{
        //    objEntityReports.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        //}
        //else if (Session["USERID"] == null)
        //{
        //    Response.Redirect("~/Default.aspx");
        //}
        //if (hiddenSearch.Value.ToString() == "--SELECT ALL DIVISION--")
        //{
        //    objEntityReports.Division_Id = 0;
        //}
        //else
        //{
        //    objEntityReports.Division_Id = Convert.ToInt32(hiddenSearch.Value.ToString());

        //}

        //DataTable dtProductList = objBusinessLayerReports.Read_Guarantee_List(objEntityReports);
        //int first = Convert.ToInt32(hiddenPrevious.Value) - Convert.ToInt32(hiddenTotalRowCount.Value);
        //int last = Convert.ToInt32(hiddenPrevious.Value);
        //hiddenPrevious.Value = first.ToString();
        //hiddenNext.Value = last.ToString();
        //if (first == 0)
        //{
        //    btnPrevious.Enabled = false;

        //}
        //else
        //{
        //    btnPrevious.Enabled = true;
        //}
        //if (last < dtProductList.Rows.Count)
        //{

        //    btnNext.Enabled = true;
        //}
        //else
        //{
        //    btnNext.Enabled = false;
        //}
        ////Write to divReport
        //string strHtm = ConvertDataTableToHTML(dtProductList);
        //divReport.InnerHtml = strHtm;




    }
    protected void btnNext_Click(object sender, EventArgs e)
    {

        ////Creating objects for businesslayer
        //clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();
        //clsEntityReports objEntityReports = new clsEntityReports();
        //if (Session["CORPOFFICEID"] != null)
        //{
        //    objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        //}
        //else if (Session["CORPOFFICEID"] == null)
        //{
        //    Response.Redirect("~/Default.aspx");
        //}
        //if (Session["ORGID"] != null)
        //{
        //    objEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

        //}
        //else if (Session["ORGID"] == null)
        //{
        //    Response.Redirect("~/Default.aspx");
        //}
        //if (Session["USERID"] != null)
        //{
        //    objEntityReports.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        //}
        //else if (Session["USERID"] == null)
        //{
        //    Response.Redirect("~/Default.aspx");
        //}
        //if (hiddenSearch.Value.ToString() == "--SELECT ALL DIVISION--")
        //{
        //    objEntityReports.Division_Id = 0;
        //}
        //else
        //{
        //    objEntityReports.Division_Id = Convert.ToInt32(hiddenSearch.Value.ToString());

        //}



        //DataTable dtProductList = objBusinessLayerReports.Read_Guarantee_List(objEntityReports);
        //int first = Convert.ToInt32(hiddenNext.Value);
        //int last = Convert.ToInt32(hiddenNext.Value) + Convert.ToInt32(hiddenTotalRowCount.Value);
        //hiddenPrevious.Value = first.ToString();
        //hiddenNext.Value = last.ToString();
        //if (first == 0)
        //{
        //    btnPrevious.Enabled = false;

        //}
        //else
        //{
        //    btnPrevious.Enabled = true;
        //}
        //if (last < dtProductList.Rows.Count)
        //{

        //    btnNext.Enabled = true;
        //}
        //else
        //{
        //    btnNext.Enabled = false;
        //}
        ////Write to divReport
        //string strHtm = ConvertDataTableToHTML(dtProductList);
        //divReport.InnerHtml = strHtm;



    }

    //at search button click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        btnNext.Enabled = false;
        btnPrevious.Enabled = false;
        hiddenPrevious.Value = "0";
        hiddenNext.Value = "";
        //Creating objects for businesslayer
        ClsBusinessExpiryNotificationReport objBusinessLayerReports = new ClsBusinessExpiryNotificationReport();
        ClsEntityExpiryNotificationReport objEntityReports = new ClsEntityExpiryNotificationReport();
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

        if (Radiovisa.Checked == true)
        {
            objEntityReports.Document_Type = 1;
        }
        else if (RadioNationlid.Checked == true)
        {
            objEntityReports.Document_Type = 2;

        }
        else if (Radiopassport.Checked == true)
        {
            objEntityReports.Document_Type = 0;

        }
        else if (RadioHC.Checked == true)
        {
            objEntityReports.Document_Type = 3;

        }
        if (ddlDepartmnt.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntityReports.DeptId = Convert.ToInt32(ddlDepartmnt.SelectedItem.Value);
            //objEntityReports.DeptId = 3416279;
            //department = ddlDepartmnt.Text;
        }
        if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
        {
            objEntityReports.DivsnId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
          //  Division = ddlDivision.Text;
        }
      

     
      

        if ((txtFromDate.Text.Trim() != "") && (txtTodate.Text.Trim() != ""))
        {
            DateTime startDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
            DateTime EndDate = objCommon.textToDateTime(txtTodate.Text.Trim());
            int diff = Convert.ToInt32((EndDate - startDate).TotalDays);

            if (diff > 0)
            {
                objEntityReports.FromDt = objCommon.textToDateTime(txtFromDate.Text.Trim());
                objEntityReports.ToDate = objCommon.textToDateTime(txtTodate.Text.Trim());
            }
        }

        if (ddlStatus.SelectedItem.Text == "-- SELECT STATUS--")
        {
            objEntityReports.Status = 0;
        }
        else
        {
            objEntityReports.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        }


        // hiddenSearch.Value = ddlDivisionSearch.SelectedItem.Value;

        //    string strDivisionSearch = ddlDivisionSearch.SelectedItem.Value;
        string strProductName = "";
        // string strQueryString = strDivisionSearch + "_" + strProductName;
        //hiddenSearch.Value = strQueryString;
        DataTable dtProductSrch = new DataTable();
        dtProductSrch = objBusinessLayerReports.Read_Expiry_Notification_List(objEntityReports);
        string strHtm = ConvertDataTableToHTML(dtProductSrch);
        divReport.InnerHtml = strHtm;
        DataTable dtCorp = objBusinessLayerReports.ReadCorporateAddress(objEntityReports);
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
        strTitle = "Expiry Notification Report";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string usrName = "";
        if (Session["USERFULLNAME"] != null)
        {
            usrName = "<B> Report Generated By: </B>" + Session["USERFULLNAME"];
        }
        //for printing product division on print
        string division = "";
        string category = "";
        string mode = "";


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
        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strUsrName + strDivisionTitle + strCategoryTitle + strTypeTitle + strCaptionTabTitle + strCaptionTabstop;



        sbCap.Append(strPrintCaptionTable);
        //write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString(); ;


        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">HOLDER ID</th>";
            }
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">HOLDER NAME</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: right; word-wrap:break-word;\">NUMBER</th>";
            }
            if (intColumnHeaderCount == 3)
            {

                if (Radiovisa.Checked == true)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">EXPIRY DATE</th>";
                }
                else if (RadioNationlid.Checked == true || Radiopassport.Checked == true)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">ISSUED DATE</th>";

                }

            }
            if (intColumnHeaderCount == 4)
            {
                if (Radiovisa.Checked == true)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">ISSUED BY</th>";
                }
                else if (RadioNationlid.Checked == true || Radiopassport.Checked == true || RadioHC.Checked == true)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">EXPIRY DATE</th>";
                }

            }
            if (intColumnHeaderCount == 5)
            {
                if (Radiovisa.Checked == true)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">TYPE</th>";
                }
                else if (RadioNationlid.Checked == true || Radiopassport.Checked == true)
                {
                    strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">ISSUED BY</th>";

                }
                else if (RadioHC.Checked == true)
                {
                    strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">ISSUED BY</th>";

                }

            }
            if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: cnter; word-wrap:break-word;\">STATUS</th>";

            }
        }


        strHtml += "</tr>";
        strHtml += "</thead>";
        string status = "";
        //add rows

        strHtml += "<tbody>";
        if (dt.Rows.Count == 0)
        {
            strHtml += "<tr id=\"TableRprtRow\" >";
            strHtml += "<td class=\"thT\"colspan=10 style=\"width:11%;text-align: center; word-wrap:break-word;\">No Data Available</th>";

        }
        else
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                strHtml += "<tr id=\"TableRprtRow\" >";
                strHtml += "<tr  >";

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {
                    if (intColumnBodyCount == 0)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_NAME"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + dt.Rows[intRowBodyCount]["EMPIMG_DOC_NUMBER"].ToString() + "</td>";
                    }

                    if (intColumnBodyCount == 3)
                    {

                        if (Radiovisa.Checked == true)
                        {

                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["EMPIMG_DOC_EXPDATE"].ToString() + "</td>";
                        }
                        ////else if (RadioHC.Checked == true)
                        ////{
                        ////    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["HC_CENTER_NUM"].ToString() + "</td>";

                        ////}
                        else if (RadioNationlid.Checked == true || Radiopassport.Checked == true)
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["EMPIMG_DOC_ISSUEDATE"].ToString() + "</td>";

                    }
                    if (intColumnBodyCount == 4)
                    {
                        if (Radiovisa.Checked == true)
                        {
                            strHtml += "<td title=\"" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "\"  class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left; \" >" + dt.Rows[intRowBodyCount]["CNTRY_NAME"].ToString().ToUpper() + "</td>";
                        }
                        else
                        {
                            strHtml += "<td title=\"" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "\"  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; \" >" + dt.Rows[intRowBodyCount]["EMPIMG_DOC_EXPDATE"].ToString().ToUpper() + "</td>";
                        }

                    }
                    if (intColumnBodyCount == 5)
                    {
                        if (Radiovisa.Checked == true)
                        {
                            strHtml += "<td title=\"" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "\"  class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left; \" >" + dt.Rows[intRowBodyCount]["VISA_NAME"].ToString().ToUpper() + "</td>";
                        }
                  
                        else

                            strHtml += "<td title=\"" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "\"  class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left; \" >" + dt.Rows[intRowBodyCount]["CNTRY_NAME"].ToString().ToUpper() + "</td>";
                    }
                    if (intColumnBodyCount == 6)
                    {
                        if (dt.Rows[intRowBodyCount]["EMPIMG_DOC_EXPDATE"].ToString() != null && dt.Rows[intRowBodyCount]["EMPIMG_DOC_EXPDATE"].ToString() != "")
                        {
                            DateTime ExpDate = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["EMPIMG_DOC_EXPDATE"].ToString());
                            if (ExpDate > DateTime.Today)
                            {
                                status = "Not Expired";

                            }
                            else
                                status = "Expired";
                        }

                        strHtml += "<td title=\"" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "\"  class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: center; \" >" + status + "</td>";

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

    protected void ddlDepartmnt_SelectedIndexChanged(object sender, EventArgs e)     //emp25
    {
        //clsEntityManpwrReqmt_Status_Report objEntityManpwrReqmt = new clsEntityManpwrReqmt_Status_Report();
        //clsBusinessLayerManpwr_Reqmt_Status_Report objBusinessManpwrReqmt = new clsBusinessLayerManpwr_Reqmt_Status_Report();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            //hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            //hiddenOrgId.Value = Session["ORGID"].ToString();
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
            objEntityReports.DeptId = Dept;

            DataTable dtSubConrt = objBusinessLayerReports.ReadDivision(objEntityReports); 
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

        ScriptManager.RegisterStartupScript(this, GetType(), "DropDepart", "DropDepart();", true);



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
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.EXPIRY_NOTIFICATION_CSV);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
            string newFilePath = Server.MapPath("/CustomFiles/HCM CSV/Expiry Notification/Expiry_Notification_Report_" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "Expiry_Notification_Report_" + strNextId + ".csv";
            Response.ContentType = "csv";
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.EXPIRY_NOTIFICATION_CSV);
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
       if (RadioNationlid.Checked == true || Radiopassport.Checked == true)
        {
        table.Columns.Add("HOLDER ID", typeof(string));
        table.Columns.Add("HOLDER NAME ", typeof(string));
        table.Columns.Add("NUMBER", typeof(string));
        table.Columns.Add("ISSUED DATE", typeof(string));
        table.Columns.Add("EXPIRY DATE", typeof(string));
        table.Columns.Add("ISSUED BY", typeof(string));
        table.Columns.Add("STATUS", typeof(string));
        }
       else if (Radiovisa.Checked == true)
       {
           table.Columns.Add("HOLDER ID", typeof(string));
           table.Columns.Add("HOLDER NAME ", typeof(string));
           table.Columns.Add("NUMBER", typeof(string));
           table.Columns.Add("EXPIRY DATE", typeof(string));
           table.Columns.Add("ISSUED BY", typeof(string));
           table.Columns.Add("TYPE", typeof(string));
           table.Columns.Add("STATUS", typeof(string));
       }
       else if (RadioHC.Checked == true)
       {
           table.Columns.Add("HOLDER ID", typeof(string));
           table.Columns.Add("HOLDER NAME ", typeof(string));
           table.Columns.Add("NUMBER", typeof(string));
           table.Columns.Add("EXPIRY DATE", typeof(string));
           table.Columns.Add("ISSUED BY", typeof(string));
           table.Columns.Add("STATUS", typeof(string));
       }
         
   
        hiddenPrevious.Value = "0";
        hiddenNext.Value = "";
        //Creating objects for businesslayer
        ClsBusinessExpiryNotificationReport objBusinessLayerReports = new ClsBusinessExpiryNotificationReport();
        ClsEntityExpiryNotificationReport objEntityReports = new ClsEntityExpiryNotificationReport();
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

        if (Radiovisa.Checked == true)
        {
            objEntityReports.Document_Type = 1;
        }
        else if (RadioNationlid.Checked == true)
        {
            objEntityReports.Document_Type = 2;

        }
        else if (Radiopassport.Checked == true)
        {
            objEntityReports.Document_Type = 0;

        }
        else if (RadioHC.Checked == true)
        {
            objEntityReports.Document_Type = 3;

        }
        if (ddlDepartmnt.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntityReports.DeptId = Convert.ToInt32(ddlDepartmnt.SelectedItem.Value);
            //objEntityReports.DeptId = 3416279;
            //department = ddlDepartmnt.Text;
        }
        if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
        {
            objEntityReports.DivsnId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
            //  Division = ddlDivision.Text;
        }





        if ((txtFromDate.Text.Trim() != "") && (txtTodate.Text.Trim() != ""))
        {
            DateTime startDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
            DateTime EndDate = objCommon.textToDateTime(txtTodate.Text.Trim());
            int diff = Convert.ToInt32((EndDate - startDate).TotalDays);

            if (diff > 0)
            {
                objEntityReports.FromDt = objCommon.textToDateTime(txtFromDate.Text.Trim());
                objEntityReports.ToDate = objCommon.textToDateTime(txtTodate.Text.Trim());
            }
        }

        if (ddlStatus.SelectedItem.Text == "-- SELECT STATUS--")
        {
            objEntityReports.Status = 0;
        }
        else
        {
            objEntityReports.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        }


        // hiddenSearch.Value = ddlDivisionSearch.SelectedItem.Value;

        //    string strDivisionSearch = ddlDivisionSearch.SelectedItem.Value;
        string strProductName = "";
        // string strQueryString = strDivisionSearch + "_" + strProductName;
        //hiddenSearch.Value = strQueryString;
        DataTable dt = new DataTable();
        dt = objBusinessLayerReports.Read_Expiry_Notification_List(objEntityReports);

        //for printing table
        string HldrId = "";
        string HldrName = "";
        string Numbr = "";
        string IssueDate = "";
        string ExpiryDate = "";
        string IssuedBy = "";
        string sts = "";
        string Type="";
       
      

      
        string status = "";
    
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
           

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                if (intColumnBodyCount == 0)
                {
                    HldrId = dt.Rows[intRowBodyCount]["USR_CODE"].ToString();
                }
                if (intColumnBodyCount == 1)
                {
                    HldrName = dt.Rows[intRowBodyCount]["USR_NAME"].ToString();
                }
                if (intColumnBodyCount == 2)
                {
                    Numbr = dt.Rows[intRowBodyCount]["EMPIMG_DOC_NUMBER"].ToString();
                }

                if (intColumnBodyCount == 3)
                {

                    if (Radiovisa.Checked == true)
                    {
                        ExpiryDate = dt.Rows[intRowBodyCount]["EMPIMG_DOC_EXPDATE"].ToString();

                    }
                    ////else if (RadioHC.Checked == true)
                    ////{
                    ////    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["HC_CENTER_NUM"].ToString() + "</td>";

                    ////}
                    else if (RadioNationlid.Checked == true || Radiopassport.Checked == true)
                        IssueDate = dt.Rows[intRowBodyCount]["EMPIMG_DOC_ISSUEDATE"].ToString();

                }
                if (intColumnBodyCount == 4)
                {
                    if (Radiovisa.Checked == true)
                    {

                        IssuedBy = dt.Rows[intRowBodyCount]["CNTRY_NAME"].ToString().ToUpper();
                    }
                    else
                    {
                        ExpiryDate = dt.Rows[intRowBodyCount]["EMPIMG_DOC_EXPDATE"].ToString().ToUpper();
                    }

                }
                if (intColumnBodyCount == 5)
                {
                    if (Radiovisa.Checked == true)
                    {
                        Type = dt.Rows[intRowBodyCount]["VISA_NAME"].ToString().ToUpper();
                    }

                    else
                        IssuedBy = dt.Rows[intRowBodyCount]["CNTRY_NAME"].ToString().ToUpper();

                }
                if (intColumnBodyCount == 6)
                {
                    if (dt.Rows[intRowBodyCount]["EMPIMG_DOC_EXPDATE"].ToString() != null && dt.Rows[intRowBodyCount]["EMPIMG_DOC_EXPDATE"].ToString() != "")
                    {
                        DateTime ExpDate = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["EMPIMG_DOC_EXPDATE"].ToString());
                        if (ExpDate > DateTime.Today)
                        {
                            status = "Not Expired";

                        }
                        else
                            status = "Expired";
                    }
                    sts = status;

                }
            }
       
             if (RadioNationlid.Checked == true || Radiopassport.Checked == true)
             {
                 table.Rows.Add('"' + HldrId + '"', '"' + HldrName + '"', '"' + Numbr + '"', '"' + IssueDate + '"', '"' + ExpiryDate + '"', '"' + IssuedBy + '"', '"' + sts + '"');
             }
             else if (Radiovisa.Checked == true)
             {
                 table.Rows.Add('"' + HldrId + '"', '"' + HldrName + '"', '"' + Numbr + '"', '"' + ExpiryDate + '"', '"' + IssuedBy + '"', '"' + Type + '"', '"' + sts + '"');

             }
             else if (RadioHC.Checked == true)
             {
                 table.Rows.Add('"' + HldrId + '"', '"' + HldrName + '"', '"' + Numbr + '"', '"' + ExpiryDate + '"', '"' + IssuedBy + '"', '"' + sts + '"');

             }

        }


                 
        return table;
    }
}