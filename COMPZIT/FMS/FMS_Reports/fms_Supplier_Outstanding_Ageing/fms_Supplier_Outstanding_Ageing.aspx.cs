using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using BL_Compzit.BusinessLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.Entity_Layer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Text;
using System.Web.Services;
using System.Collections;
using EL_Compzit.EntityLayer_FMS;
using BL_Compzit.BusineesLayer_FMS;
using System.Threading;
using System.IO;
using Newtonsoft.Json;
using BL_Compzit.BusinessLayer_GMS;
using iTextSharp.text;
using iTextSharp.text.pdf;

public partial class FMS_FMS_Reports_fms_Supplier_Outstanding_Ageing_fms_Supplier_Outstanding_Ageing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FRMWRK_ID"] != null && Session["FRMWRK_ID"].ToString() == "2")
        {
            aHome.HRef = "/Home/Compzit_Home/Compzit_Home_Finance.aspx";
        }
        else
        {
            aHome.HRef = " /Home/Compzit_LandingPage/Compzit_LandingPage.aspx";
        }
        if (!IsPostBack)
        {
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
            string strCurrentDate = objBusiness.LoadCurrentDateInString();
            DateTime ToDate = ObjCommonlib.textToDateTime(strCurrentDate);
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            clsEntityOutstandingAgeing ObjEntityRequest = new clsEntityOutstandingAgeing();
            clsBusinessOutstandingAgeing objBussiness = new clsBusinessOutstandingAgeing();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                ObjEntityRequest.User_Id = intUserId;
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                ObjEntityRequest.Corporate_id = intCorpId;
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                ObjEntityRequest.Organisation_id = intOrgId;
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            objEntityCommon.CorporateID = intCorpId;
            objEntityCommon.Organisation_Id = intOrgId;
            if (Session["FINCYRID"] != null)
            {
                objEntityCommon.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            DataTable dtfinaclYear = objBusiness.ReadFinancialYearById(objEntityCommon);
            DateTime curdate = ObjCommonlib.textToDateTime(objBusiness.LoadCurrentDateInString());
            if (dtfinaclYear.Rows.Count > 0)
            {
                if (dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString() != "")
                {
                    HiddenFinancialYearTo.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                    ObjEntityRequest.FinYearToDate = ObjCommonlib.textToDateTime(HiddenFinancialYearTo.Value);
                }
                if (dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString() != "")
                {
                    HiddenFinancialYearFrom.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                    ObjEntityRequest.FinYearFromDate = ObjCommonlib.textToDateTime(HiddenFinancialYearFrom.Value);
                }

                if (curdate >= ObjCommonlib.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate <= ObjCommonlib.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                {
                    DateTime ToDateFin = ObjCommonlib.textToDateTime(HiddenFinancialYearTo.Value);
                    if (ToDateFin > ToDate)
                    {
                        txtTodate.Value = ToDate.ToString("dd-MM-yyyy");
                        HiddenFieldNewToDate.Value = ToDate.ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        txtTodate.Value = ToDateFin.ToString("dd-MM-yyyy");
                        HiddenFieldNewToDate.Value = ToDateFin.ToString("dd-MM-yyyy");
                    }
                }
                else if (curdate >= ObjCommonlib.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                {
                    txtTodate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                    HiddenFieldNewToDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                }
                else if (curdate <= ObjCommonlib.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()))
                {
                    HiddenFieldNewToDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                    txtTodate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                }
            }
            HiddenFinancialYearTo.Value = strCurrentDate;
            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessMsg", "SuccessMsg();", true);
                }
            }
            if (txtTodate.Value != "")
            {
                ObjEntityRequest.ToDate = ObjCommonlib.textToDateTime(txtTodate.Value);
            }
            ObjEntityRequest.Mode = Convert.ToInt32(ddlMode.SelectedItem.Value);
            if (ObjEntityRequest.Mode == 1 && radioIndividual.Checked == true)
            {
                ObjEntityRequest.Mode = 2;
            }
           
            if (ObjEntityRequest.Mode == 0)
            {
                if (txtFromAgeing.Value.Trim() != "")
                {
                    ObjEntityRequest.FromAgeing = Convert.ToInt32(txtFromAgeing.Value.Trim());
                }
                if (txtToAgeing.Value.Trim() != "")
                {
                    ObjEntityRequest.FromAgeing = Convert.ToInt32(txtToAgeing.Value.Trim());
                }
            }
            else
            {
                if (txtSplit1.Value.Trim() != "")
                {
                    ObjEntityRequest.Split1 = Convert.ToInt32(txtSplit1.Value.Trim());
                }
                if (txtSplit2.Value.Trim() != "")
                {
                    ObjEntityRequest.Split2 = Convert.ToInt32(txtSplit2.Value.Trim());
                }
                if (txtSplit3.Value.Trim() != "")
                {
                    ObjEntityRequest.Split3 = Convert.ToInt32(txtSplit3.Value.Trim());
                }
            }
            if (radioCredit.Checked == true)
            {
                ObjEntityRequest.Mode = 3;
            }
          
            HiddenFieldSearchDate.Value = txtTodate.Value;
            DataTable dtCategory = objBussiness.Ageing_List_Supplier(ObjEntityRequest);
            if(radioCredit .Checked ==false )
            {
            string Printsts = "0";
            divList.InnerHtml = LoadConvertToTable(dtCategory, ObjEntityRequest, Printsts);
            Printsts = "1";
            }
            else
            {
            dtCategory = objBussiness.Ageing_List_SupplierCrdtPrd(ObjEntityRequest);
            string Printsts = "0";
            divList.InnerHtml = LoadConvertToTableCreditPeriod (dtCategory, ObjEntityRequest, Printsts);
            Printsts = "1";
            }
            //divPrintReport.InnerHtml = LoadConvertToTable(dtCategory, ObjEntityRequest, Printsts);
            //divPrintCaption.InnerHtml = PrintCaption(ObjEntityRequest, "");
        }

    }

    public string PrintCaption(clsEntityOutstandingAgeing ObjEntityRequest, string strName)
    {
        clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();
        clsEntityReports objEntityReports = new clsEntityReports();
        objEntityReports.Corporate_Id = ObjEntityRequest.Corporate_id;
        objEntityReports.Organisation_Id = ObjEntityRequest.Organisation_id;
        objEntityReports.User_Id = ObjEntityRequest.User_Id;
        DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(objEntityReports);
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "SUPPLIER OUTSTANDING AGEING REPORT";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string usrName = "<B> Report Generated By: </B>" + Session["USERFULLNAME"];
        string strHidden = "", GuaranteDivsn = "", GuaranteCatgry = "", GuaranteBank = "", GuaranteDnaM = "";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strMode = "";
        if (ObjEntityRequest.Mode == 0)
        {
            strMode = "Method 1";
        }
        else if (ObjEntityRequest.Mode == 1)
        {
            strMode = "Method 2-Consolidated";
        }
        else if (ObjEntityRequest.Mode == 2)
        {
            strMode = "Method 2-Individual";
        }
        GuaranteDivsn = "<B>MODE  : </B>" + strMode;

        GuaranteCatgry = "<B>DATE: </B>" + ObjEntityRequest.ToDate.ToString("dd-MMM-yyyy");

        if (strName != "")
        {
            GuaranteDnaM = "<B>SUPPLIER NAME: </B>" + strName;
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
        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr1 + "</td></tr>";
        string strCaptionTabRprtDate = "", strCaptionTabTitle = "", strGuaranteDivsn = "", strGuaranteCatgry = "", strGuaranteBank = "", strUsrName = "";
        if (dat != "")
        {
            strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        }
        if (strTitle != "")
        {
            strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
        }
        if (GuaranteDivsn != "")
        {
            strGuaranteDivsn = "<tr><td class=\"RprtDiv\">" + GuaranteDivsn + "</td></tr>";

        }
        if (GuaranteCatgry != "")
        {
            strGuaranteCatgry = "<tr><td class=\"RprtDiv\">" + GuaranteCatgry + "</td></tr>";

        }
        if (GuaranteBank != "")
        {
            strGuaranteBank = "<tr><td class=\"RprtDiv\">" + GuaranteBank + "</td></tr>";

        }
        if (usrName != "")
        {
            strUsrName = "<tr><td class=\"RprtDiv\">" + usrName + "</td></tr>";
        }
        if (GuaranteDnaM != "")
        {
            GuaranteDnaM = "<tr><td class=\"RprtDiv\">" + GuaranteDnaM + "</td></tr>";
        }
        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strGuaranteCatgry + strGuaranteDivsn + GuaranteDnaM + strGuaranteBank + strUsrName + strCaptionTabTitle + strCaptionTabstop;
        sbCap.Append(strPrintCaptionTable);
        return sbCap.ToString();
    }

    //main list table
    public string LoadConvertToTable(DataTable dtCategory, clsEntityOutstandingAgeing ObjEntityRequest, string Printsts)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = ObjEntityRequest.Corporate_id, intOrgId = 0, intUserId = 0;
        int Decimalcount = 0;
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                    clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                    clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                    clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                    };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }
        decimal sum_debt = 0;
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        string strHtml = "";
        if (Printsts == "0")
        {
            strHtml = "<table id=\"datatable_fixed_column\" class=\"table-bordered display\" width=\"100%\" >";
            //add header row
            strHtml += "<thead class=\"thead1\">";
            strHtml += "<tr>";
            //strHtml += "<th class=\"hasinput\" style=\"text-align:left;width:10%;\">SL NO ";
            //strHtml += "</th >";
            strHtml += "<th class=\"col-md-3 tr_l\" >SUPPLIER NAME ";
            strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input class=\"tb_inp_1 tb_in tr_l\" placeholder=\"SUPPLIER NAME \" type=\"text\" onkeypress=\"return DisableEnter(event)\">";
            strHtml += "<th class=\"col-md-2 tr_r\" >OUTSTANDING AMOUNT";
            strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input class=\"tb_inp_1 tb_in tr_r\" placeholder=\"OUTSTANDING AMOUNT\"  type=\"text\" onkeypress=\"return DisableEnter(event)\">";
            strHtml += "</th >";
            strHtml += "</tr>";
            strHtml += "</thead>";
        }
        else
        {
            strHtml = "<table id=\"PrintTable\" class=\"tab\" \">";
            //add header row
            strHtml += "<thead>";
            strHtml += "<tr class=\"top_row\">";
            //strHtml += "<th class=\"thT\" style=\"width:10%;text-align:left;\">SL NO";
            //strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:60%;text-align:left;\">SUPPLIER NAME ";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:40%;text-align:right;\">OUTSTANDING AMOUNT";
            strHtml += "</th >";
            strHtml += "</tr>";
            strHtml += "</thead>";
        }
        //add rows
        strHtml += "<tbody>";
        int COUNT = 0;
        DataView view = new DataView(dtCategory);
        DataTable dtCategory1 = view.ToTable(true, "CSTMR_ID", "CSTMR_NAME");
        clsBusinessOutstandingAgeing objBussinessAging = new clsBusinessOutstandingAgeing();
        clsEntityOutstandingAgeing ObjEntityRequest1 = new clsEntityOutstandingAgeing();
        for (int intRowBodyCount = 0; intRowBodyCount < dtCategory1.Rows.Count; intRowBodyCount++)
        {
            decimal NetAmount = 0;
            DataRow[] result = dtCategory.Select("CSTMR_ID ='" + dtCategory1.Rows[intRowBodyCount]["CSTMR_ID"].ToString() + "'");
            foreach (DataRow row in result)
            {
                NetAmount += Convert.ToDecimal(row["BALNC_AMT"].ToString());
            }
            ObjEntityRequest1.CustomerId = Convert.ToInt32(dtCategory1.Rows[intRowBodyCount]["CSTMR_ID"].ToString());
            ObjEntityRequest1.Corporate_id = ObjEntityRequest.Corporate_id;
            ObjEntityRequest1.Organisation_id = ObjEntityRequest.Organisation_id;
            sum_debt += NetAmount;
            string strId = dtCategory1.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dtCategory1.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            COUNT++;

            string CustomerName = dtCategory1.Rows[intRowBodyCount]["CSTMR_NAME"].ToString();
            if (CustomerName.Contains("\"") == true)
            {
                CustomerName = CustomerName.Replace("\"", "‡");
            }
            if (CustomerName.Contains("\'") == true)
            {
                CustomerName = CustomerName.Replace("\'", "¦");
            }

            strHtml += "<tr>";
            strHtml += "<td class=\"tr_l\" style=\"text-align:left;\"> <a  title=\"View\"  onclick=\"return OpenReconView('" + Id + "','" + CustomerName + "','" + ObjEntityRequest.Mode + "','" + ObjEntityRequest.FromAgeing + "','" + ObjEntityRequest.ToAgeing + "','" + ObjEntityRequest.Split1 + "','" + ObjEntityRequest.Split2 + "','" + ObjEntityRequest.Split3 + "');\" href=\"javascript:;\">" + dtCategory1.Rows[intRowBodyCount]["CSTMR_NAME"].ToString() + "</a>";

            DataTable dt = objBussinessAging.ReadPendingPayments(ObjEntityRequest1);//pending paymnts
            if (dt.Rows.Count > 0)
            {
                strHtml += "<span href=\"javascript:;\" class=\"pull-right spn_rc pst_dt_bx\" title=\"Pending Payment Details\" onclick=\"return PendingReceiptsDisplay('" + Id + "');\" data-toggle=\"modal\" data-target=\"#ModalPendingReceipt\" > <i class=\"fa fa-clipboard\"></i></span>";
            }

            //postdated chq
            DataTable dtPostDate = objBussinessAging.ReadPostdatedChqDtls(ObjEntityRequest1);
            if (dtPostDate.Rows.Count > 0)
            {
                strHtml += "<span href=\"javascript:;\" class=\"pst_dt_bx pull-right\" title=\"Postdated Cheque\" onclick=\"return PostdatedChqDisplay('" + Id + "');\" data-toggle=\"modal\" data-target=\"#divPostdatedChq\" ><i class=\"fa fa-list-alt ad_fa ad_posd pa_fa\"></i></span>";
            }

            strHtml += "</td>";
            strHtml += "<td class=\"tr_r\" style=\"text-align:right;\">" + objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon) + "</td>";
            strHtml += "</tr>";
        }
        strHtml += "</tbody>";
        if (dtCategory1.Rows.Count > 0)
        {
            strHtml += " <tfoot> <tr class=\"tr1\">";
            strHtml += "<th class=\"tr_r txt_rd bg1\" style=\"text-align:left !important;\" >TOTAL </th>";
            strHtml += "<th class=\"tr_r txt_rd bg1\" style=\"text-align:right;\"> " + objBusiness.AddCommasForNumberSeperation(sum_debt.ToString(), objEntityCommon) + "</th>";
            strHtml += "</tr></tfoot>";
        }
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    //--evm 0044
    public string LoadConvertToTableCreditPeriod(DataTable dtCategory, clsEntityOutstandingAgeing ObjEntityRequest, string Printsts)
    {
        
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = ObjEntityRequest.Corporate_id, intOrgId = 0, intUserId = 0;
        int Decimalcount = 0;
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                    clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                    clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                    clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                    };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }
        decimal sum_debt = 0;
        decimal sum_debt1 = 0;
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        string strHtml = "";
        if (Printsts == "0")
        {
            strHtml = "<table id=\"datatable_fixed_column\" class=\"table-bordered display\" width=\"100%\" >";
            //add header row
            strHtml += "<thead class=\"thead1\">";
            strHtml += "<tr>";
            //strHtml += "<th class=\"hasinput\" style=\"text-align:left;width:10%;\">SL NO ";
            //strHtml += "</th >";
            strHtml += "<th class=\"col-md-3 tr_l\" >SUPPLIER NAME ";
            strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input class=\"tb_inp_1 tb_in tr_l\" placeholder=\"SUPPLIER NAME \" type=\"text\" onkeypress=\"return DisableEnter(event)\">";
            strHtml += "<th class=\"col-md-2 tr_r\" >AMOUNT WITHOUT DUE";
            strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input class=\"tb_inp_1 tb_in tr_r\" placeholder=\"OUTSTANDING AMOUNT\"  type=\"text\" onkeypress=\"return DisableEnter(event)\">";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-2 tr_r\" >AMOUNT WITH DUE";
            strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input class=\"tb_inp_1 tb_in tr_r\" placeholder=\"OUTSTANDING AMOUNT\"  type=\"text\" onkeypress=\"return DisableEnter(event)\">";
            strHtml += "</th >";
            strHtml += "</tr>";
            strHtml += "</thead>";
        }
        else
        {
            strHtml = "<table id=\"PrintTable\" class=\"tab\" \">";
            //add header row
            strHtml += "<thead>";
            strHtml += "<tr class=\"top_row\">";
            //strHtml += "<th class=\"thT\" style=\"width:10%;text-align:left;\">SL NO";
            //strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:60%;text-align:left;\">SUPPLIER NAME ";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:40%;text-align:right;\">AMOUNT WITHOUT DUE";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:40%;text-align:right;\">AMOUNT WITH DUE";
            strHtml += "</th >";
            strHtml += "</tr>";
            strHtml += "</thead>";
        }
        //add rows
        strHtml += "<tbody>";
        int COUNT = 0;
        DataView view = new DataView(dtCategory);
        //DataTable dtCategory1 = view.ToTable(true, "CSTMR_ID", "CSTMR_NAME");
        clsBusinessOutstandingAgeing objBussinessAging = new clsBusinessOutstandingAgeing();
        clsEntityOutstandingAgeing ObjEntityRequest1 = new clsEntityOutstandingAgeing();
        for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
        {
           decimal AmtWithoutDue = 0;
           decimal AmtWithDue = 0;
           AmtWithoutDue = Convert.ToDecimal (dtCategory.Rows[intRowBodyCount]["NODUE_AMT"].ToString());
           AmtWithDue = Convert.ToDecimal (dtCategory.Rows[intRowBodyCount]["DUE_AMT"].ToString());

            ObjEntityRequest1.CustomerId = Convert.ToInt32(dtCategory.Rows[intRowBodyCount]["CSTMR_ID"].ToString());
            ObjEntityRequest1.Corporate_id = ObjEntityRequest.Corporate_id;
            ObjEntityRequest1.Organisation_id = ObjEntityRequest.Organisation_id;
            sum_debt += AmtWithoutDue   ;
            sum_debt1 += AmtWithDue;
            string strId = dtCategory.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dtCategory.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            COUNT++;

            string CustomerName = dtCategory.Rows[intRowBodyCount]["CSTMR_NAME"].ToString();
            if (CustomerName.Contains("\"") == true)
            {
                CustomerName = CustomerName.Replace("\"", "‡");
            }
            if (CustomerName.Contains("\'") == true)
            {
                CustomerName = CustomerName.Replace("\'", "¦");
            }

            strHtml += "<tr>";
            strHtml += "<td class=\"tr_l\" style=\"text-align:left;\"> <a  title=\"View\"  onclick=\"return OpenReconView('" + Id + "','" + CustomerName + "','" + ObjEntityRequest.Mode + "','" + ObjEntityRequest.FromAgeing + "','" + 2 + "','" + ObjEntityRequest.Split1 + "','" + ObjEntityRequest.Split2 + "','" + ObjEntityRequest.Split3 + "');\" href=\"javascript:;\">" + dtCategory.Rows[intRowBodyCount]["CSTMR_NAME"].ToString() + "</a>";

            DataTable dt = objBussinessAging.ReadPendingPayments(ObjEntityRequest1);//pending paymnts
            if (dt.Rows.Count > 0)
            {
                strHtml += "<span href=\"javascript:;\" class=\"pull-right spn_rc pst_dt_bx\" title=\"Pending Payment Details\" onclick=\"return PendingReceiptsDisplay('" + Id + "');\" data-toggle=\"modal\" data-target=\"#ModalPendingReceipt\" > <i class=\"fa fa-clipboard\"></i></span>";
            }

            //postdated chq
            DataTable dtPostDate = objBussinessAging.ReadPostdatedChqDtls(ObjEntityRequest1);
            if (dtPostDate.Rows.Count > 0)
            {
                strHtml += "<span href=\"javascript:;\" class=\"pst_dt_bx pull-right\" title=\"Postdated Cheque\" onclick=\"return PostdatedChqDisplay('" + Id + "');\" data-toggle=\"modal\" data-target=\"#divPostdatedChq\" ><i class=\"fa fa-list-alt ad_fa ad_posd pa_fa\"></i></span>";
            }

            strHtml += "</td>";

            if (AmtWithoutDue == 0)
            {
               
                strHtml += "<td class=\"tr_r\" style=\"text-align:right;\"><a  title=\"View\"  onclick=\"return OpenReconView('" + Id + "','" + CustomerName + "','" + ObjEntityRequest.Mode + "','" + 0 + "','" +0  +"','" + ObjEntityRequest.Split1 + "','" + ObjEntityRequest.Split2 + "','" + ObjEntityRequest.Split3 + "');\" href=\"javascript:;\">0.00</td>";
            }
            else
            {

                strHtml += "<td class=\"tr_r\" style=\"text-align:right;\"><a  title=\"View\"  onclick=\"return OpenReconView('" + Id + "','" + CustomerName + "','" + ObjEntityRequest.Mode + "','" + 0 + "','" + 0 + "','" + ObjEntityRequest.Split1 + "','" + ObjEntityRequest.Split2 + "','" + ObjEntityRequest.Split3 + "');\" href=\"javascript:;\">" + objBusiness.AddCommasForNumberSeperation(AmtWithoutDue.ToString().ToString(), objEntityCommon) + "</td>";
            }
            if (AmtWithDue == 0)
            {
               
                strHtml += "<td class=\"tr_r\" style=\"text-align:right;\"><a  title=\"View\"  onclick=\"return OpenReconView('" + Id + "','" + CustomerName + "','" + ObjEntityRequest.Mode + "','" +0 + "','" + 1 + "','" + ObjEntityRequest.Split1 + "','" + ObjEntityRequest.Split2 + "','" + ObjEntityRequest.Split3 + "');\" href=\"javascript:;\">0.00</td>";
            }
            else
            {
                
                strHtml += "<td class=\"tr_r\" style=\"text-align:right;\"><a  title=\"View\"  onclick=\"return OpenReconView('" + Id + "','" + CustomerName + "','" + ObjEntityRequest.Mode + "','" + 0 + "','" + 1 + "','" + ObjEntityRequest.Split1 + "','" + ObjEntityRequest.Split2 + "','" + ObjEntityRequest.Split3 + "');\" href=\"javascript:;\">" + objBusiness.AddCommasForNumberSeperation(AmtWithDue.ToString(), objEntityCommon) + "</td>";
            }
            strHtml += "</tr>";
        }
     
        strHtml += "</tbody>";
        if (dtCategory.Rows.Count > 0)
        {
            strHtml += " <tfoot> <tr class=\"tr1\">";
            strHtml += "<th class=\"tr_r txt_rd bg1\" style=\"text-align:left !important;\" >TOTAL </th>";
            strHtml += "<th class=\"tr_r txt_rd bg1\" style=\"text-align:right;\"> " + objBusiness.AddCommasForNumberSeperation(sum_debt.ToString(), objEntityCommon) + "</th>";
            strHtml += "<th class=\"tr_r txt_rd bg1\" style=\"text-align:right;\"> " + objBusiness.AddCommasForNumberSeperation(sum_debt1.ToString(), objEntityCommon) + "</th>";
            strHtml += "</tr></tfoot>";
        }
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    //------
    [WebMethod]
    public static string[] LoadConvertToTable_Print(string intuserid, string intorgid, string intcorpid, string intdatefrom, string intdateto, string mode, string AgeingFrom, string AgeingTo, string Split1, string Split2, string Split3, string FinYearFromDate, string FinYearToDate, string individual, string strPrintMode)
    {
        string[] result = new string[10];
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        clsEntityOutstandingAgeing ObjEntityRequest = new clsEntityOutstandingAgeing();
        clsBusinessOutstandingAgeing objBussiness = new clsBusinessOutstandingAgeing();
        ObjEntityRequest.User_Id = Convert.ToInt32(intuserid);;
        ObjEntityRequest.Corporate_id =  Convert.ToInt32(intcorpid);
        ObjEntityRequest.Organisation_id = Convert.ToInt32(intorgid);
        FMS_FMS_Reports_fms_Supplier_Outstanding_Ageing_fms_Supplier_Outstanding_Ageing OBJ = new FMS_FMS_Reports_fms_Supplier_Outstanding_Ageing_fms_Supplier_Outstanding_Ageing();
        if (intdateto != "")
        {
            ObjEntityRequest.ToDate = ObjCommonlib.textToDateTime(intdateto);
        }
        ObjEntityRequest.FinYearFromDate = ObjCommonlib.textToDateTime(FinYearFromDate);
        ObjEntityRequest.FinYearToDate = ObjCommonlib.textToDateTime(FinYearToDate);
        ObjEntityRequest.Mode = Convert.ToInt32(mode);

        if (ObjEntityRequest.Mode == 1 && individual == "0")
        {
            ObjEntityRequest.Mode = 2;
        }
        if (ObjEntityRequest.Mode == 0)
        {
            if (AgeingFrom != "")
            {
                ObjEntityRequest.FromAgeing = Convert.ToInt32(AgeingFrom);
            }
            if (AgeingTo!= "")
            {
                ObjEntityRequest.ToAgeing = Convert.ToInt32(AgeingTo);
            }
        }
        else
        {
            if (Split1 != "")
            {
                ObjEntityRequest.Split1 = Convert.ToInt32(Split1.Trim());
            }
            if (Split2.Trim() != "")
            {
                ObjEntityRequest.Split2 = Convert.ToInt32(Split2.Trim());
            }
            if (Split3.Trim() != "")
            {
                ObjEntityRequest.Split3 = Convert.ToInt32(Split3.Trim());
            }
        }
        if (individual == "2")
        {
            ObjEntityRequest.Mode = 3;
        }
        DataTable dtCategory = new DataTable();
        dtCategory = objBussiness.Ageing_List_Supplier(ObjEntityRequest);

        if (strPrintMode == "pdf")

        {
            if (individual == "2")
            {
                dtCategory = objBussiness.Ageing_List_SupplierCrdtPrd(ObjEntityRequest);
                string Printsts = "0";
                Printsts = "1";
                result[0] = OBJ.LoadConvertToTableCreditPeriod_PDF(dtCategory, ObjEntityRequest, Printsts, intdateto, mode, AgeingFrom, AgeingTo, Split1, Split2, Split3);
            }
            else if (ObjEntityRequest.Mode < 2)
            {
                string Printsts = "0";
                //divList.InnerHtml = LoadConvertToTable(dtCategory, ObjEntityRequest, Printsts);
                //LoadConvertToTableIndvl_PDF(dtCategory, ObjEntityRequest, Printsts, intdateto, mode, AgeingFrom, AgeingTo, Split1, Split2, Split3);
                Printsts = "1";
                result[0] = OBJ.LoadConvertToTable_PDF(dtCategory, ObjEntityRequest, Printsts, intdateto, mode, AgeingFrom, AgeingTo, Split1, Split2, Split3);
                //divPrintCaption.InnerHtml = PrintCaption(ObjEntityRequest, "");
            }
            else
            {
                string Printsts = "0";
                //divList.InnerHtml = LoadConvertToTableIndvl(dtCategory, ObjEntityRequest, Printsts);
                Printsts = "1";
                result[0] = OBJ.LoadConvertToTableIndvl_PDF(dtCategory, ObjEntityRequest, Printsts, intdateto, mode, AgeingFrom, AgeingTo, Split1, Split2, Split3);
                //divPrintCaption.InnerHtml = PrintCaption(ObjEntityRequest, ""); LoadConvertToTable_PDF
            }
        }
        else if (strPrintMode == "csv")
        {
            if (individual == "2")

            {
                dtCategory = objBussiness.Ageing_List_SupplierCrdtPrd(ObjEntityRequest);
                string Printsts = "0";
                Printsts = "1";
                result[0] = OBJ.LoadConvertToTableCreditPeriod_CSV (dtCategory, ObjEntityRequest, Printsts, intdateto, mode, AgeingFrom, AgeingTo, Split1, Split2, Split3);
            }
            else
            if (ObjEntityRequest.Mode < 2)
            {
                string Printsts = "0";
                Printsts = "1";
                result[0] = OBJ.LoadConvertToTable_CSV(dtCategory, ObjEntityRequest, Printsts, intdateto, mode, AgeingFrom, AgeingTo, Split1, Split2, Split3);
            }
            else
            {
                string Printsts = "0";
                Printsts = "1";
                result[0] = OBJ.LoadConvertToTableIndvl_CSV(dtCategory, ObjEntityRequest, Printsts, intdateto, mode, AgeingFrom, AgeingTo, Split1, Split2, Split3);
            }
        }


        return result;

    }
    public string LoadConvertToTable_PDF(DataTable dtCategory, clsEntityOutstandingAgeing ObjEntityRequest, string Printsts, string intdateto,string mode,string AgeingFrom,string AgeingTo,string Split1,string Split2,string Split3)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = ObjEntityRequest.Corporate_id, intOrgId = 0, intUserId = 0;
        int Decimalcount = 0;
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                    clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                    clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                    clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                    };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }
        decimal sum_debt = 0;
        string strRandom = objCommon.Random_Number();
        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.SUPPLIER_OUTSTANDING_AGING_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SUPPLIER_OUTSTANDING_AGING_PDF);
        objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "Sup_AgeingList_" + strNextNumber + ".pdf";

        Document document = new Document(PageSize.A4, 50f, 40f, 120f, 30f);
        document = new Document(PageSize.LETTER, 50f, 40f, 20f, 40f);
        Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
        string format = String.Format("{{0:N{0}}}", 2);
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

                footrtable.AddCell(new PdfPCell(new Phrase("DATE     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(intdateto, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (mode == "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("MODE   ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    if (AgeingFrom != "" && AgeingTo != "")
                    {
                        footrtable.AddCell(new PdfPCell(new Phrase("METHOD 1", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase("AGEING   ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase(AgeingFrom + " - " + AgeingTo, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                    }
                    else
                    {
                        footrtable.AddCell(new PdfPCell(new Phrase("METHOD 1", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                    }
                }
                else
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("MODE ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase("METHOD 2 - Consolidated", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    if (Split1 != "" && Split2 != "" && Split3 != "")
                    {
                        footrtable.AddCell(new PdfPCell(new Phrase("AGEING   ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase(Split1 + " - " + Split2 + " - " + Split3, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                    }
                }         
                document.Add(footrtable);

                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(2);
                float[] footrsBody = { 75, 25 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;//get header column in all pages

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("SUPPLIER NAME", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour});
                TBCustomer.AddCell(new PdfPCell(new Phrase("OUTSTANDING AMOUNT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                
                int COUNT = 0;
                DataView view = new DataView(dtCategory);
                DataTable dtCategory1 = view.ToTable(true, "CSTMR_ID", "CSTMR_NAME");
                clsBusinessOutstandingAgeing objBussinessAging = new clsBusinessOutstandingAgeing();
                clsEntityOutstandingAgeing ObjEntityRequest1 = new clsEntityOutstandingAgeing();
                for (int intRowBodyCount = 0; intRowBodyCount < dtCategory1.Rows.Count; intRowBodyCount++)
                {
                    decimal NetAmount = 0;
                    DataRow[] result = dtCategory.Select("CSTMR_ID ='" + dtCategory1.Rows[intRowBodyCount]["CSTMR_ID"].ToString() + "'");
                    foreach (DataRow row in result)
                    {
                        NetAmount += Convert.ToDecimal(row["BALNC_AMT"].ToString());
                    }
                    ObjEntityRequest1.CustomerId = Convert.ToInt32(dtCategory1.Rows[intRowBodyCount]["CSTMR_ID"].ToString());
                    ObjEntityRequest1.Corporate_id = ObjEntityRequest.Corporate_id;
                    ObjEntityRequest1.Organisation_id = ObjEntityRequest.Organisation_id;
                    sum_debt += NetAmount;
                    string strId = dtCategory1.Rows[intRowBodyCount][0].ToString();
                    int intIdLength = dtCategory1.Rows[intRowBodyCount][0].ToString().Length;
                    string stridLength = intIdLength.ToString("00");
                    string Id = stridLength + strId + strRandom;
                    COUNT++;
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory1.Rows[intRowBodyCount]["CSTMR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                }
                if (dtCategory1.Rows.Count > 0)
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(sum_debt.ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
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
    //--evm 0044
    public string LoadConvertToTableCreditPeriod_PDF(DataTable dtCategory, clsEntityOutstandingAgeing ObjEntityRequest, string Printsts, string intdateto, string mode, string AgeingFrom, string AgeingTo, string Split1, string Split2, string Split3)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = ObjEntityRequest.Corporate_id, intOrgId = 0, intUserId = 0;
        int Decimalcount = 0;
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                    clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                    clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                    clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                    };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }
        decimal sum_debt = 0;
        decimal sum_debt1 = 0;
        string strRandom = objCommon.Random_Number();
        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.SUPPLIER_OUTSTANDING_AGING_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SUPPLIER_OUTSTANDING_AGING_PDF);
        objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "Sup_AgeingListCrdtPeriod_" + strNextNumber + ".pdf";

        Document document = new Document(PageSize.A4, 50f, 40f, 120f, 30f);
        document = new Document(PageSize.LETTER, 50f, 40f, 20f, 40f);
        Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
        string format = String.Format("{{0:N{0}}}", 2);
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

                footrtable.AddCell(new PdfPCell(new Phrase("DATE     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(intdateto, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (mode == "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("MODE   ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    if (AgeingFrom != "" && AgeingTo != "")
                    {
                        footrtable.AddCell(new PdfPCell(new Phrase("METHOD 1", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase("AGEING   ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase(AgeingFrom + " - " + AgeingTo, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                    }
                    else
                    {
                        footrtable.AddCell(new PdfPCell(new Phrase("METHOD 1", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                    }
                }
                else
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("MODE ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase("METHOD 2 - Consolidated", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    if (Split1 != "" && Split2 != "" && Split3 != "")
                    {
                        footrtable.AddCell(new PdfPCell(new Phrase("AGEING   ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase(Split1 + " - " + Split2 + " - " + Split3, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                    }
                }
                document.Add(footrtable);

                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(3);
                float[] footrsBody = { 50, 25,25 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;//get header column in all pages

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("SUPPLIER NAME", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("AMOUNT WITHOUT DUE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("AMOUNT WITH DUE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });

                int COUNT = 0;
                DataView view = new DataView(dtCategory);
                DataTable dtCategory1 = view.ToTable(true, "CSTMR_ID", "CSTMR_NAME");
                clsBusinessOutstandingAgeing objBussinessAging = new clsBusinessOutstandingAgeing();
                clsEntityOutstandingAgeing ObjEntityRequest1 = new clsEntityOutstandingAgeing();
                 decimal AmtWithoutDue = 0;
                 decimal AmtWithDue = 0;
                for (int intRowBodyCount = 0; intRowBodyCount < dtCategory1.Rows.Count; intRowBodyCount++)
                {
                   
                                     
                            AmtWithoutDue = Convert.ToDecimal (dtCategory.Rows[intRowBodyCount]["NODUE_AMT"].ToString());
                            AmtWithDue = Convert.ToDecimal (dtCategory.Rows[intRowBodyCount]["DUE_AMT"].ToString());
                    
                    ObjEntityRequest1.CustomerId = Convert.ToInt32(dtCategory1.Rows[intRowBodyCount]["CSTMR_ID"].ToString());
                    ObjEntityRequest1.Corporate_id = ObjEntityRequest.Corporate_id;
                    ObjEntityRequest1.Organisation_id = ObjEntityRequest.Organisation_id;
                    sum_debt += AmtWithoutDue ;
                    sum_debt1 += AmtWithDue;
                    string strId = dtCategory1.Rows[intRowBodyCount][0].ToString();
                    int intIdLength = dtCategory1.Rows[intRowBodyCount][0].ToString().Length;
                    string stridLength = intIdLength.ToString("00");
                    string Id = stridLength + strId + strRandom;
                    COUNT++;
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory1.Rows[intRowBodyCount]["CSTMR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    if (AmtWithoutDue == 0)
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase("0.00", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }
                    else
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(AmtWithoutDue.ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }
                    if (AmtWithDue == 0)
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase("0.00", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }
                    else
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(AmtWithDue.ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }
                    
                }
                if (dtCategory1.Rows.Count > 0)
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(sum_debt.ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(sum_debt1.ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
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
    //--------
    public string LoadConvertToTable_CSV(DataTable dtCategory, clsEntityOutstandingAgeing ObjEntityRequest, string Printsts, string intdateto, string mode, string AgeingFrom, string AgeingTo, string Split1, string Split2, string Split3)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        DataTable dt = GetTable_1(dtCategory, ObjEntityRequest, intdateto, mode, AgeingFrom, AgeingTo, Split1, Split2, Split3);
        string strResult = DataTableToCSV(dt, ',');
        string strImagePath = "";
        string filepath = "";

        if (ObjEntityRequest.Corporate_id != 0)
        {
            objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        }
        if (ObjEntityRequest.Organisation_id != 0)
        {
            objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        }


        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SUPPLIER_OUTSTNDG_AGEING_CSV);
        string strNextId = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string newFilePath = Server.MapPath("/CustomFiles/FMS CSV/Supplier Outstanding Ageing/Supp_AgeingList_" + strNextId + ".csv");
        System.IO.File.WriteAllText(newFilePath, strResult);
        filepath = "Supp_AgeingList_" + strNextId + ".csv";
        strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.SUPPLIER_OUTSTNDG_AGEING_CSV);
        return strImagePath + filepath;
    }
    //--evm 0044
    public string LoadConvertToTableCreditPeriod_CSV(DataTable dtCategory, clsEntityOutstandingAgeing ObjEntityRequest, string Printsts, string intdateto, string mode, string AgeingFrom, string AgeingTo, string Split1, string Split2, string Split3)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        DataTable dt = GetTable_CreditPeriod(dtCategory, ObjEntityRequest, intdateto, mode, AgeingFrom, AgeingTo, Split1, Split2, Split3);
        string strResult = DataTableToCSV(dt, ',');
        string strImagePath = "";
        string filepath = "";

        if (ObjEntityRequest.Corporate_id != 0)
        {
            objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        }
        if (ObjEntityRequest.Organisation_id != 0)
        {
            objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        }


        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SUPPLIER_OUTSTNDG_AGEING_CSV);
        string strNextId = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string newFilePath = Server.MapPath("/CustomFiles/FMS CSV/Supplier Outstanding Ageing/Supp_AgeingListCrdtPeriod_" + strNextId + ".csv");
        System.IO.File.WriteAllText(newFilePath, strResult);
        filepath = "Supp_AgeingListCrdtPeriod_" + strNextId + ".csv";
        strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.SUPPLIER_OUTSTNDG_AGEING_CSV);
        return strImagePath + filepath;
    }
    //-------
    public DataTable GetTable_1(DataTable dtCategory, clsEntityOutstandingAgeing ObjEntityRequest, string intdateto, string mode, string AgeingFrom, string AgeingTo, string Split1, string Split2, string Split3)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = ObjEntityRequest.Corporate_id;
        int Decimalcount = 0;
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                  clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                    };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }
        decimal sum_debt = 0;
        string strRandom = objCommon.Random_Number();

        string FORNULL = "";
        DataTable table = new DataTable();

        try
        {
            table.Columns.Add("SUPPLIER OUTSTANDING AGEING REPORT ", typeof(string));
            table.Columns.Add(" ", typeof(string));

            table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"');
            table.Rows.Add("DATE :", '"' + intdateto + '"');

            if (mode == "0")
            {
                table.Rows.Add("MODE :", "METHOD 1");
                if (AgeingFrom != "" && AgeingTo != "")
                {
                    table.Rows.Add("AGEING :", '"' + AgeingFrom + " to " + AgeingTo + '"');
                }
            }
            else
            {
                table.Rows.Add("MODE :", "METHOD 2 - Consolidated");
                if (Split1 != "" && Split2 != "" && Split3 != "")
                {
                    table.Rows.Add("AGEING :", '"' + Split1 + " to " + Split2 + " to " + Split3 + '"');
                }
            }
            table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"');
            table.Rows.Add("SUPPLIER NAME", "OUTSTANDING AMOUNT");

            int COUNT = 0;
            DataView view = new DataView(dtCategory);
            DataTable dtCategory1 = view.ToTable(true, "CSTMR_ID", "CSTMR_NAME");
            clsBusinessOutstandingAgeing objBussinessAging = new clsBusinessOutstandingAgeing();
            clsEntityOutstandingAgeing ObjEntityRequest1 = new clsEntityOutstandingAgeing();

            for (int intRowBodyCount = 0; intRowBodyCount < dtCategory1.Rows.Count; intRowBodyCount++)
            {
                decimal NetAmount = 0;
                DataRow[] result = dtCategory.Select("CSTMR_ID ='" + dtCategory1.Rows[intRowBodyCount]["CSTMR_ID"].ToString() + "'");
                foreach (DataRow row in result)
                {
                    NetAmount += Convert.ToDecimal(row["BALNC_AMT"].ToString());
                }
                ObjEntityRequest1.CustomerId = Convert.ToInt32(dtCategory1.Rows[intRowBodyCount]["CSTMR_ID"].ToString());
                ObjEntityRequest1.Corporate_id = ObjEntityRequest.Corporate_id;
                ObjEntityRequest1.Organisation_id = ObjEntityRequest.Organisation_id;
                sum_debt += NetAmount;
                string strId = dtCategory1.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dtCategory1.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                COUNT++;
                table.Rows.Add('"' + dtCategory1.Rows[intRowBodyCount]["CSTMR_NAME"].ToString() + '"', '"' + objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon) + '"');
            }

            if (dtCategory1.Rows.Count > 0)
            {
                table.Rows.Add("TOTAL", '"' + objBusiness.AddCommasForNumberSeperation(sum_debt.ToString(), objEntityCommon) + '"');
            }
        }
        catch (Exception)
        {

        }

        return table;
    }

    //---evm 0044
    public DataTable GetTable_CreditPeriod(DataTable dtCategory, clsEntityOutstandingAgeing ObjEntityRequest, string intdateto, string mode, string AgeingFrom, string AgeingTo, string Split1, string Split2, string Split3)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = ObjEntityRequest.Corporate_id;
        int Decimalcount = 0;
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                  clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                    };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }
        decimal sum_debt = 0;
        decimal sum_debt1 = 0;
        string strRandom = objCommon.Random_Number();

        string FORNULL = "";
        DataTable table = new DataTable();

        try
        {
            table.Columns.Add("SUPPLIER OUTSTANDING AGEING REPORT ", typeof(string));
            table.Columns.Add(" ", typeof(string));
            table.Columns.Add("  ", typeof(string));

            table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
            table.Rows.Add("DATE :", '"' + intdateto + '"', '"' + FORNULL + '"');

            if (mode == "0")
            {
                table.Rows.Add("MODE :", "METHOD 1", '"' + FORNULL + '"');
                if (AgeingFrom != "" && AgeingTo != "")
                {
                    table.Rows.Add("AGEING :", '"' + AgeingFrom + " to " + AgeingTo + '"', '"' + FORNULL + '"');
                }
            }
            else
            {
                table.Rows.Add("MODE :", "METHOD 2 - Consolidated", '"' + FORNULL + '"');
                if (Split1 != "" && Split2 != "" && Split3 != "")
                {
                    table.Rows.Add("AGEING :", '"' + Split1 + " to " + Split2 + " to " + Split3 + '"', '"' + FORNULL + '"');
                }
            }
            table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
            table.Rows.Add("SUPPLIER NAME", "AMOUNT WITHOUT DUE","AMOUNT WITH DUE");

            int COUNT = 0;
            DataView view = new DataView(dtCategory);
            DataTable dtCategory1 = view.ToTable(true, "CSTMR_ID", "CSTMR_NAME");
            clsBusinessOutstandingAgeing objBussinessAging = new clsBusinessOutstandingAgeing();
            clsEntityOutstandingAgeing ObjEntityRequest1 = new clsEntityOutstandingAgeing();

            for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
            {
                decimal AmtWithoutDue = 0;
                decimal AmtWithDue = 0;
                DataRow[] result = dtCategory.Select("CSTMR_ID ='" + dtCategory.Rows[intRowBodyCount]["CSTMR_ID"].ToString() + "'");
                AmtWithoutDue += Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["NODUE_AMT"].ToString());
                AmtWithDue += Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["DUE_AMT"].ToString());
                   
                ObjEntityRequest1.CustomerId = Convert.ToInt32(dtCategory.Rows[intRowBodyCount]["CSTMR_ID"].ToString());
                ObjEntityRequest1.Corporate_id = ObjEntityRequest.Corporate_id;
                ObjEntityRequest1.Organisation_id = ObjEntityRequest.Organisation_id;
                sum_debt += AmtWithoutDue;
                sum_debt1 += AmtWithDue;
                string strId = dtCategory.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dtCategory.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                COUNT++;
                table.Rows.Add('"' + dtCategory.Rows[intRowBodyCount]["CSTMR_NAME"].ToString() + '"', '"' + objBusiness.AddCommasForNumberSeperation(AmtWithoutDue.ToString(), objEntityCommon) + '"', '"' + objBusiness.AddCommasForNumberSeperation(AmtWithDue.ToString(), objEntityCommon) + '"');
            }

            if (dtCategory.Rows.Count > 0)
            {
                table.Rows.Add("TOTAL", '"' + objBusiness.AddCommasForNumberSeperation(sum_debt.ToString(), objEntityCommon) + '"', '"' + objBusiness.AddCommasForNumberSeperation(sum_debt1.ToString(), objEntityCommon) + '"');
            }
        }
        catch (Exception)
        {

        }

        return table;
    }
    //------
    //check whether popup consolidated/individual
    [WebMethod]
    public static string[] TrailBalance_Lists_ById(string intAccntId, string intuserid, string intorgid, string intcorpid, string intdatefrom, string intdateto, string mode, string AgeingFrom, string AgeingTo, string Split1, string Split2, string Split3, string strName, string FinYearFromDate, string FinYearToDate)
    {
        string[] result = new string[10];
        clsBusinessOutstandingAgeing objBussiness = new clsBusinessOutstandingAgeing();
        clsEntityOutstandingAgeing objEntity = new clsEntityOutstandingAgeing();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        FMS_FMS_Reports_fms_Supplier_Outstanding_Ageing_fms_Supplier_Outstanding_Ageing obj = new FMS_FMS_Reports_fms_Supplier_Outstanding_Ageing_fms_Supplier_Outstanding_Ageing();
        string strRandomMixedId = intAccntId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntity.FinYearFromDate = ObjCommonlib.textToDateTime(FinYearFromDate);
        objEntity.FinYearToDate = ObjCommonlib.textToDateTime(FinYearToDate);
        int corp = Convert.ToInt32(intcorpid);
        objEntity.FromDate = ObjCommonlib.textToDateTime(intdatefrom.ToString());
        objEntity.ToDate = ObjCommonlib.textToDateTime(intdateto.ToString());
        objEntity.Organisation_id = Convert.ToInt32(intorgid);
        objEntity.Corporate_id = corp;
        objEntity.CustomerId = Convert.ToInt32(strId);
        objEntity.Mode = Convert.ToInt32(mode);

        objEntity.FromAgeing = Convert.ToInt32(AgeingFrom);
        objEntity.ToAgeing = Convert.ToInt32(AgeingTo);
        objEntity.Split1 = Convert.ToInt32(Split1);
        objEntity.Split2 = Convert.ToInt32(Split2);
        objEntity.Split3 = Convert.ToInt32(Split3);
        
        if (strName.Contains("‡") == true)
        {
            strName = strName.Replace("‡", "\"");
        }
        if (strName.Contains("¦") == true)
        {
            strName = strName.Replace("¦", "\'");
        }
        if (objEntity.Mode == 3)
        {
            objEntity.ByCredit = 1;
        }
        else
        {
            objEntity.ByCredit = 0;
        }
        StringBuilder sb = new StringBuilder();
        DataTable dtList = objBussiness.Ageing_List_ById_Supplier(objEntity);

        if (objEntity.Mode == 0 || objEntity.Mode == 2)
        {
            objEntity.DueSts = 2;
            string Printsts = "0";
            result[1] = obj.LoadConvertToTableLed(dtList, objEntity, strId, Printsts);
            Printsts = "1";
          //  result[4] = obj.LoadConvertToTableLed(dtList, objEntity, strId, Printsts);
            result[0] = dtList.Rows.Count.ToString();
            result[2] = strId;
          //  result[3] = obj.PrintCaption(objEntity, strName);
        }
        else if (objEntity.Mode == 1)
        {
            objEntity .DueSts =2;
            string Printsts = "0";
            result[1] = obj.LoadConvertToTableLedCons(dtList, objEntity, strId, Printsts);
            Printsts = "1";
          //  result[4] = obj.LoadConvertToTableLedCons(dtList, objEntity, strId, Printsts);
            result[0] = dtList.Rows.Count.ToString();
            result[2] = strId;
          //  result[3] = obj.PrintCaption(objEntity, strName);
        }
        else if (objEntity.Mode ==3)
        {
            objEntity.DueSts = objEntity.ToAgeing;
             dtList = objBussiness.Ageing_List_ById_Supplier(objEntity);
               string Printsts = "0";
               result[1] = obj.LoadConvertToTableCreditPopup(dtList, objEntity, strId, Printsts);
            Printsts = "1";
          //  result[4] = obj.LoadConvertToTableLedCons(dtList, objEntity, strId, Printsts);
            result[0] = dtList.Rows.Count.ToString();
            result[2] = strId;
          //  result[3] = obj.PrintCaption(objEntity, strName);
        }
        return result;

    }
    [WebMethod]
    public static string[] TrailBalance_Lists_ById_Print(string intAccntId, string intuserid, string intorgid, string intcorpid, string intdatefrom, string intdateto, string mode, string AgeingFrom, string AgeingTo, string Split1, string Split2, string Split3, string strName, string FinYearFromDate, string FinYearToDate, string individual, string strPrintMode)
    {
        string[] result = new string[10];
        clsBusinessOutstandingAgeing objBussiness = new clsBusinessOutstandingAgeing();
        clsEntityOutstandingAgeing objEntity = new clsEntityOutstandingAgeing();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        FMS_FMS_Reports_fms_Supplier_Outstanding_Ageing_fms_Supplier_Outstanding_Ageing obj = new FMS_FMS_Reports_fms_Supplier_Outstanding_Ageing_fms_Supplier_Outstanding_Ageing();
        string strRandomMixedId = intAccntId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntity.FinYearFromDate = ObjCommonlib.textToDateTime(FinYearFromDate);
        objEntity.FinYearToDate = ObjCommonlib.textToDateTime(FinYearToDate);
        int corp = Convert.ToInt32(intcorpid);
        objEntity.FromDate = ObjCommonlib.textToDateTime(intdatefrom.ToString());
        objEntity.ToDate = ObjCommonlib.textToDateTime(intdateto.ToString());
        objEntity.Organisation_id = Convert.ToInt32(intorgid);
        objEntity.Corporate_id = corp;
        objEntity.CustomerId = Convert.ToInt32(strId);
        objEntity.Mode = Convert.ToInt32(mode);
        if (mode == "1" && individual == "0")
        {
            objEntity.Mode = 2;
        }
        if (individual == "2")
        {
            objEntity.Mode = 3;
        }
        if (AgeingFrom != "" && AgeingTo != "")
        {
            objEntity.FromAgeing = Convert.ToInt32(AgeingFrom);
            objEntity.ToAgeing = Convert.ToInt32(AgeingTo);
        }
        if (Split1 != "" && Split2 != "" && Split3 != "")
        {
            objEntity.Split1 = Convert.ToInt32(Split1);
            objEntity.Split2 = Convert.ToInt32(Split2);
            objEntity.Split3 = Convert.ToInt32(Split3);
        }

        if (strName.Contains("‡") == true)
        {
            strName = strName.Replace("‡", "\"");
        }
        if (strName.Contains("¦") == true)
        {
            strName = strName.Replace("¦", "\'");
        }
        if (objEntity.Mode == 3)
        {
            objEntity.ByCredit = 1;
        }
        else
        {
            objEntity.ByCredit = 0;
        }

        StringBuilder sb = new StringBuilder();
        DataTable dtList = objBussiness.Ageing_List_ById_Supplier(objEntity);
        if (strPrintMode == "pdf")
        {

            if (objEntity.Mode == 0 || objEntity.Mode == 2)
            {
                string Printsts = "0";
                Printsts = "1";
                result[0] = obj.LoadConvertToTableLed_PDF(dtList, objEntity, strId, Printsts, intdateto, mode, AgeingFrom, AgeingTo, Split1, Split2, Split3, strName, individual);
            }
            else if (objEntity.Mode == 1)
            {
                string Printsts = "0";
                Printsts = "1";
                result[0] = obj.LoadConvertToTableLedCons_PDF(dtList, objEntity, strId, Printsts, intdateto, mode, AgeingFrom, AgeingTo, Split1, Split2, Split3, strName, individual);
            }
            else if (objEntity.Mode == 3)
            {
                objEntity.DueSts = Convert.ToInt32(AgeingTo);
                dtList = objBussiness.Ageing_List_ById_Supplier  (objEntity);
                string Printsts = "0";
                Printsts = "1";
                result[0] = obj.LoadConvertToTableCreditPopup_PDF (dtList, objEntity, strId, Printsts, intdateto, mode, AgeingFrom, AgeingTo, Split1, Split2, Split3, strName, individual);
            }
        }
        else if (strPrintMode == "csv")
        {
            if (objEntity.Mode == 0 || objEntity.Mode == 2)
            {
                string Printsts = "0";
                Printsts = "1";
                result[0] = obj.LoadConvertToTableLed_CSV(dtList, objEntity, strId, Printsts, intdateto, mode, AgeingFrom, AgeingTo, Split1, Split2, Split3, strName, individual);
            }
            else if (objEntity.Mode == 1)
            {
                string Printsts = "0";
                Printsts = "1";
                result[0] = obj.LoadConvertToTableLedCons_CSV(dtList, objEntity, strId, Printsts, intdateto, mode, AgeingFrom, AgeingTo, Split1, Split2, Split3, strName, individual);
            }
            else if (objEntity.Mode == 3)
            {
                objEntity.DueSts = Convert.ToInt32(AgeingTo);
                dtList = objBussiness.Ageing_List_ById_Supplier (objEntity);
                string Printsts = "0";
                Printsts = "1";
                result[0] = obj.LoadConvertToTableCreditPopup_CSV (dtList, objEntity, strId, Printsts, intdateto, mode, AgeingFrom, AgeingTo, Split1, Split2, Split3, strName, individual);
            }
        }


        return result;

    }

    //method1 and method2 individual list detail popup
    public string LoadConvertToTableLed(DataTable dtCategory, clsEntityOutstandingAgeing ObjEntityRequest, string strId1, string Printsts)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsBusinessOutstandingAgeing objBussiness = new clsBusinessOutstandingAgeing();
        int intCorpId = ObjEntityRequest.Corporate_id;
        int Decimalcount = 0;
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }
        string format = String.Format("{{0:N{0}}}", Decimalcount);
        int intCount = 0;
        decimal sum_inv = 0, sum_paid = 0, sum_bal = 0, sum_return = 0;
        foreach (DataRow dr in dtCategory.Rows)
        {
            sum_inv += Convert.ToDecimal(dr["INVOICE_AMT"]);
            sum_paid += Convert.ToDecimal(dr["PAID_AMT"]);
            sum_bal += Convert.ToDecimal(dr["BALNC_AMT"]);
            sum_return += Convert.ToDecimal(dr["SALES_RETURN_AMNT"]);
        }

        DataTable dtForOB = objBussiness.ReadOepningBalById(ObjEntityRequest);
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        string strHtml = "";
        if (Printsts == "0")
        {
            strHtml = "<table id=\"datatable_fixed_column" + strId1 + "\" class=\"table-bordered display\" width=\"100%\" >";
            //add header row
            strHtml += "<thead class=\"thead1\">";

            strHtml += "<tr >";
            //strHtml += "<th class=\"hasinput\" style=\"text-align:left;width:5%;\">SL NO ";
            // strHtml += "</th >";
            strHtml += "<th class=\"th_b6 tr_l\">INVOICE NO ";
            strHtml += "<input class=\"tb_inp_1 tb_in tr_l\" placeholder=\"INVOICE NO \" type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"th_b7\" >INVOICE DATE ";
            strHtml += "<input class=\"tb_inp_1 tb_in tr_c\" placeholder=\"INVOICE DATE\" type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"th_b6 tr_r\" >INVOICE AMOUNT ";
            strHtml += "<input class=\"tb_inp_1 tb_in tr_r\" placeholder=\"INVOICE AMOUNT \"  type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"th_b6 tr_r\" >PAID AMOUNT ";
            strHtml += "<input class=\"tb_inp_1 tb_in tr_r\" placeholder=\"PAID AMOUNT\"  type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"th_b6 tr_r\">RETURN AMOUNT";
            strHtml += "<input class=\"tb_inp_1 tb_in tr_r\" placeholder=\"RETURN AMOUNT\"  type=\"text\">";
            strHtml += "</th>";
            strHtml += "<th class=\"th_b6 tr_r\" >BALANCE AMOUNT ";
            strHtml += "<input class=\"tb_inp_1 tb_in tr_r\" placeholder=\"BALANCE AMOUNT\" type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"th_b7\" >AGEING ";
            strHtml += "<input class=\"tb_inp_1 tb_in tr_c\" placeholder=\"AGEING\"  type=\"text\">";
            strHtml += "</th >";
            strHtml += "</tr>";
            strHtml += "</thead>";

        }
        else
        {

            strHtml = "<table id=\"PrintTable\" class=\"tab\" \">";
            //add header row
            strHtml += "<thead>";
            strHtml += "<tr class=\"top_row\">";
            //strHtml += "<th class=\"thT\" style=\"width:5%;text-align:left;\">SL NO";
            //strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:30%;text-align:left;\">INVOICE NO";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:10%;text-align:center;\">INVOICE DATE";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:17%;text-align:right;\">INVOICE AMOUNT";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:17%;text-align:right;\">PAID AMOUNT";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:17%;text-align:right;\">RETURN AMOUNT";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:17%;text-align:right;\">BALANCE AMOUNT";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:9%;text-align:center;\">AGEING";
            strHtml += "</th >";
            strHtml += "</tr>";
            strHtml += "</thead>";
        }
        //add rows

        strHtml += "<tbody>";

        if (dtForOB.Rows.Count > 0)
        {
            strHtml += "<tr class=\"tr1\"><td class=\"tr_l\">OPENING BALANCE</td><td></td><td></td><td></td><td></td><td class=\"tr_r\" >" + objBusiness.AddCommasForNumberSeperation(dtForOB.Rows[0]["VOCHR_OB"].ToString(), objEntityCommon) + "</td><td></td>";
            strHtml += "</tr>";
        }
        if (dtForOB.Rows.Count > 0 && dtForOB.Rows[0]["VOCHR_OB"].ToString() != "")
        {
            sum_bal = sum_bal + Convert.ToDecimal(dtForOB.Rows[0]["VOCHR_OB"].ToString());
        }

        int COUNT = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
        {
            COUNT++;
            strHtml += "<tr>";
            //  strHtml += "<td class=\"tdT\" style=\" width:5%;text-align: left;\" >" + COUNT + "</td>";
            strHtml += "<td class=\"tr_l\" >" + dtCategory.Rows[intRowBodyCount]["PURCHS_REF"].ToString() + "</td>";
            strHtml += "<td >" + dtCategory.Rows[intRowBodyCount]["PURCHS_DATE"].ToString() + "</td>";
            strHtml += "<td class=\"tr_r\" >" + objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["INVOICE_AMT"].ToString(), objEntityCommon) + "</td>";
            strHtml += "<td class=\"tr_r\" >" + objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["PAID_AMT"].ToString(), objEntityCommon) + "</td>";
            strHtml += "<td class=\"tr_r\" >" + objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["SALES_RETURN_AMNT"].ToString(), objEntityCommon) + "</td>";
            strHtml += "<td class=\"tr_r\"> " + objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["BALNC_AMT"].ToString(), objEntityCommon) + "</td>";
            strHtml += "<td> " + dtCategory.Rows[intRowBodyCount]["DAYS"].ToString() + "</td>";
            strHtml += "</tr>";
        }
        strHtml += "</tbody>";

        string strNetAmountCrComma = "", strNetAmountCrComma1 = "", strNetAmountCrComma2 = "", strNetAmountCrComma3 = "";
        if (sum_inv == 0)
        {
            strNetAmountCrComma = String.Format(format, sum_inv);
        }
        else
        {
            strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(sum_inv.ToString(), objEntityCommon);
        }
        if (sum_paid == 0)
        {
            strNetAmountCrComma1 = String.Format(format, sum_paid);
        }
        else
        {
            strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(sum_paid.ToString(), objEntityCommon);
        }
        if (sum_bal == 0)
        {
            strNetAmountCrComma2 = String.Format(format, sum_bal);
        }
        else
        {
            strNetAmountCrComma2 = objBusiness.AddCommasForNumberSeperation(sum_bal.ToString(), objEntityCommon);
        }

        if (sum_return == 0)
        {
            strNetAmountCrComma3 = String.Format(format, sum_return);
        }
        else
        {
            strNetAmountCrComma3 = objBusiness.AddCommasForNumberSeperation(sum_return.ToString(), objEntityCommon);
        }

        strHtml += " <tfoot><tr class=\"tr1\">";
        //  strHtml += "<td class=\"tdT\" style=\" width:5%;text-align: left;\" ></td>";
        strHtml += "<th class=\"tr_r txt_rd bg1\" style=\"text-align:left !important;\" >TOTAL</th>";
        strHtml += "<th class=\"tr_r txt_rd bg1\"></th>";
        strHtml += "<th class=\"tr_r txt_rd bg1\" style=\"text-align:right;\" >" + strNetAmountCrComma + "</th>";
        strHtml += "<th class=\"tr_r txt_rd bg1\" style=\"text-align:right;\" >" + strNetAmountCrComma1 + "</th>";
        strHtml += "<th class=\"tr_r txt_rd bg1\"  style=\"text-align:right;\"> " + strNetAmountCrComma3 + "</th>";
        strHtml += "<th class=\"tr_r txt_rd bg1\"  style=\"text-align:right;\"> " + strNetAmountCrComma2 + "</th>";
        strHtml += "<th class=\"tr_r txt_rd bg1\" > </th>";
        strHtml += " </tr>";
        strHtml += "</tfoot>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    //---0044
    public string LoadConvertToTableCreditPopup(DataTable dtCategory, clsEntityOutstandingAgeing ObjEntityRequest, string strId1, string Printsts)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsBusinessOutstandingAgeing objBussiness = new clsBusinessOutstandingAgeing();
        int intCorpId = ObjEntityRequest.Corporate_id;
        int Decimalcount = 0;
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }
        string format = String.Format("{{0:N{0}}}", Decimalcount);
        int intCount = 0;
        decimal sum_inv = 0, sum_paid = 0, sum_bal = 0, sum_return = 0;
        foreach (DataRow dr in dtCategory.Rows)
        {
            sum_inv += Convert.ToDecimal(dr["INVOICE_AMT"]);
            sum_paid += Convert.ToDecimal(dr["PAID_AMT"]);
            sum_bal += Convert.ToDecimal(dr["BALNC_AMT"]);
            sum_return += Convert.ToDecimal(dr["SALES_RETURN_AMNT"]);
        }

        DataTable dtForOB = objBussiness.ReadOepningBalById(ObjEntityRequest);
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        string strHtml = "";
        if (Printsts == "0")
        {
            strHtml = "<table id=\"datatable_fixed_column" + strId1 + "\" class=\"table-bordered display\" width=\"100%\" >";
            //add header row
            strHtml += "<thead class=\"thead1\">";

            strHtml += "<tr >";
            //strHtml += "<th class=\"hasinput\" style=\"text-align:left;width:5%;\">SL NO ";
            // strHtml += "</th >";
            strHtml += "<th class=\"th_b6 tr_l\">INVOICE NO ";
            strHtml += "<input class=\"tb_inp_1 tb_in tr_l\" placeholder=\"INVOICE NO \" type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"th_b7\" >INVOICE DATE ";
            strHtml += "<input class=\"tb_inp_1 tb_in tr_c\" placeholder=\"INVOICE DATE\" type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"th_b6 tr_r\" >INVOICE AMOUNT ";
            strHtml += "<input class=\"tb_inp_1 tb_in tr_r\" placeholder=\"INVOICE AMOUNT \"  type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"th_b6 tr_r\" >PAID AMOUNT ";
            strHtml += "<input class=\"tb_inp_1 tb_in tr_r\" placeholder=\"PAID AMOUNT\"  type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"th_b6 tr_r\">RETURN AMOUNT";
            strHtml += "<input class=\"tb_inp_1 tb_in tr_r\" placeholder=\"RETURN AMOUNT\"  type=\"text\">";
            strHtml += "</th>";
            strHtml += "<th class=\"th_b6 tr_r\" >BALANCE AMOUNT ";
            strHtml += "<input class=\"tb_inp_1 tb_in tr_r\" placeholder=\"BALANCE AMOUNT\" type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"th_b7\" >DUE DAYS ";
            strHtml += "<input class=\"tb_inp_1 tb_in tr_c\" placeholder=\"DUE DAYS\"  type=\"text\">";
            strHtml += "</th >";
            strHtml += "</tr>";
            strHtml += "</thead>";

        }
        else
        {

            strHtml = "<table id=\"PrintTable\" class=\"tab\" \">";
            //add header row
            strHtml += "<thead>";
            strHtml += "<tr class=\"top_row\">";
            //strHtml += "<th class=\"thT\" style=\"width:5%;text-align:left;\">SL NO";
            //strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:30%;text-align:left;\">INVOICE NO";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:10%;text-align:center;\">INVOICE DATE";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:17%;text-align:right;\">INVOICE AMOUNT";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:17%;text-align:right;\">PAID AMOUNT";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:17%;text-align:right;\">RETURN AMOUNT";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:17%;text-align:right;\">BALANCE AMOUNT";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:9%;text-align:center;\">DUE DAYS";
            strHtml += "</th >";
            strHtml += "</tr>";
            strHtml += "</thead>";
        }
        //add rows

        strHtml += "<tbody>";

        if (dtForOB.Rows.Count > 0)
        {
            strHtml += "<tr class=\"tr1\"><td class=\"tr_l\">OPENING BALANCE</td><td></td><td></td><td></td><td></td><td class=\"tr_r\" >" + objBusiness.AddCommasForNumberSeperation(dtForOB.Rows[0]["VOCHR_OB"].ToString(), objEntityCommon) + "</td><td></td>";
            strHtml += "</tr>";
        }
        if (dtForOB.Rows.Count > 0 && dtForOB.Rows[0]["VOCHR_OB"].ToString() != "")
        {
            sum_bal = sum_bal + Convert.ToDecimal(dtForOB.Rows[0]["VOCHR_OB"].ToString());
        }

        int COUNT = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
        {
            COUNT++;
            strHtml += "<tr>";
            //  strHtml += "<td class=\"tdT\" style=\" width:5%;text-align: left;\" >" + COUNT + "</td>";
            strHtml += "<td class=\"tr_l\" >" + dtCategory.Rows[intRowBodyCount]["PURCHS_REF"].ToString() + "</td>";
            strHtml += "<td >" + dtCategory.Rows[intRowBodyCount]["PURCHS_DATE"].ToString() + "</td>";
            strHtml += "<td class=\"tr_r\" >" + objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["INVOICE_AMT"].ToString(), objEntityCommon) + "</td>";
            strHtml += "<td class=\"tr_r\" >" + objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["PAID_AMT"].ToString(), objEntityCommon) + "</td>";
            strHtml += "<td class=\"tr_r\" >" + objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["SALES_RETURN_AMNT"].ToString(), objEntityCommon) + "</td>";
            strHtml += "<td class=\"tr_r\"> " + objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["BALNC_AMT"].ToString(), objEntityCommon) + "</td>";
            //if (dtCategory.Rows[intRowBodyCount]["CREDIT_DAYS"].ToString() == "0")
            //{
                strHtml += "<td> " + dtCategory.Rows[intRowBodyCount]["DAYS"].ToString() + "</td>";
            //}
            //else if(Convert .ToInt32 (dtCategory.Rows[intRowBodyCount]["CREDIT_DAYS"].ToString()) <=Convert .ToInt32 (dtCategory.Rows[intRowBodyCount]["DAYS"].ToString()))
            //{
            //    int duedays = Convert.ToInt32(dtCategory.Rows[intRowBodyCount]["DAYS"].ToString()) - Convert.ToInt32(dtCategory.Rows[intRowBodyCount]["CREDIT_DAYS"].ToString());
            //    strHtml += "<td> " + duedays.ToString() + "</td>";
            //}
            // else if(Convert .ToInt32 (dtCategory.Rows[intRowBodyCount]["CREDIT_DAYS"].ToString()) > Convert .ToInt32 (dtCategory.Rows[intRowBodyCount]["DAYS"].ToString()))
            //{
            //    int duedays= 0-Convert .ToInt32 (dtCategory.Rows[intRowBodyCount]["DAYS"].ToString());
            //    strHtml += "<td> " + duedays.ToString() + "</td>";
            //}
            strHtml += "</tr>";
        }
        strHtml += "</tbody>";

        string strNetAmountCrComma = "", strNetAmountCrComma1 = "", strNetAmountCrComma2 = "", strNetAmountCrComma3 = "";
        if (sum_inv == 0)
        {
            strNetAmountCrComma = String.Format(format, sum_inv);
        }
        else
        {
            strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(sum_inv.ToString(), objEntityCommon);
        }
        if (sum_paid == 0)
        {
            strNetAmountCrComma1 = String.Format(format, sum_paid);
        }
        else
        {
            strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(sum_paid.ToString(), objEntityCommon);
        }
        if (sum_bal == 0)
        {
            strNetAmountCrComma2 = String.Format(format, sum_bal);
        }
        else
        {
            strNetAmountCrComma2 = objBusiness.AddCommasForNumberSeperation(sum_bal.ToString(), objEntityCommon);
        }

        if (sum_return == 0)
        {
            strNetAmountCrComma3 = String.Format(format, sum_return);
        }
        else
        {
            strNetAmountCrComma3 = objBusiness.AddCommasForNumberSeperation(sum_return.ToString(), objEntityCommon);
        }

        strHtml += " <tfoot><tr class=\"tr1\">";
        //  strHtml += "<td class=\"tdT\" style=\" width:5%;text-align: left;\" ></td>";
        strHtml += "<th class=\"tr_r txt_rd bg1\" style=\"text-align:left !important;\" >TOTAL</th>";
        strHtml += "<th class=\"tr_r txt_rd bg1\"></th>";
        strHtml += "<th class=\"tr_r txt_rd bg1\" style=\"text-align:right;\" >" + strNetAmountCrComma + "</th>";
        strHtml += "<th class=\"tr_r txt_rd bg1\" style=\"text-align:right;\" >" + strNetAmountCrComma1 + "</th>";
        strHtml += "<th class=\"tr_r txt_rd bg1\"  style=\"text-align:right;\"> " + strNetAmountCrComma3 + "</th>";
        strHtml += "<th class=\"tr_r txt_rd bg1\"  style=\"text-align:right;\"> " + strNetAmountCrComma2 + "</th>";
        strHtml += "<th class=\"tr_r txt_rd bg1\" > </th>";
        strHtml += " </tr>";
        strHtml += "</tfoot>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    //-----0044
    public string LoadConvertToTableLed_PDF(DataTable dtCategory, clsEntityOutstandingAgeing ObjEntityRequest, string strId1, string Printsts, string intdateto, string mode, string AgeingFrom, string AgeingTo, string Split1, string Split2, string Split3, string strName, string individual)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsBusinessOutstandingAgeing objBussiness = new clsBusinessOutstandingAgeing();
        int intCorpId = ObjEntityRequest.Corporate_id;
        int Decimalcount = 0;
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }
        string format = String.Format("{{0:N{0}}}", Decimalcount);
        int intCount = 0;
        decimal sum_inv = 0, sum_paid = 0, sum_bal = 0, sum_return = 0;
        foreach (DataRow dr in dtCategory.Rows)
        {
            sum_inv += Convert.ToDecimal(dr["INVOICE_AMT"]);
            sum_paid += Convert.ToDecimal(dr["PAID_AMT"]);
            sum_bal += Convert.ToDecimal(dr["BALNC_AMT"]);
            sum_return += Convert.ToDecimal(dr["SALES_RETURN_AMNT"]);
        }

        DataTable dtForOB = objBussiness.ReadOepningBalById(ObjEntityRequest);
        string strRandom = objCommon.Random_Number();
        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.SUPPLIER_OUTSTANDING_AGING_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SUPPLIER_OUTSTANDING_AGING_PDF);
        objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "SupAgeingLed_" + strNextNumber + ".pdf";
        
        Document document = new Document(PageSize.A4, 50f, 40f, 120f, 30f);
        document = new Document(PageSize.LETTER, 50f, 40f, 20f, 30f);
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

                footrtable.AddCell(new PdfPCell(new Phrase("DATE     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(intdateto, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase("SUPPLIER     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(strName, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (mode == "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("MODE   ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    if (AgeingFrom != "" && AgeingTo != "")
                    {
                        footrtable.AddCell(new PdfPCell(new Phrase("METHOD 1", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase("AGEING   ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase(AgeingFrom + " - " + AgeingTo, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                    }
                    else
                    {
                        footrtable.AddCell(new PdfPCell(new Phrase("METHOD 1", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                    }
                }
                else
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("MODE ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase("METHOD 2 - Consolidated", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    if (Split1 != "" && Split2 != "" && Split3 != "")
                    {
                        footrtable.AddCell(new PdfPCell(new Phrase("AGEING   ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase(Split1 + " - " + Split2 + " - " + Split3, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                    }
                }
                document.Add(footrtable);

                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(7);
                float[] footrsBody = { 20, 10, 20, 10, 10, 20, 10 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;//get header column in all pages

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("INVOICE NO ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("INVOICE DATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("INVOICE AMOUNT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("PAID AMOUNT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("RETURN AMOUNT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("BALANCE AMOUNT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("AGEING", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                if (dtForOB.Rows.Count > 0)
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase("OPENING BALANCE", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(dtForOB.Rows[0]["VOCHR_OB"].ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    //strHtml += "<tr class=\"tr1\"><td class=\"tr_l\">OPENING BALANCE</td><td></td><td></td><td></td><td class=\"tr_r\" >" + objBusiness.AddCommasForNumberSeperation(dtForOB.Rows[0]["VOCHR_OB"].ToString(), objEntityCommon) + "</td><td></td>";
                    //strHtml += "</tr>";
                }
                if (dtForOB.Rows.Count > 0 && dtForOB.Rows[0]["VOCHR_OB"].ToString() != "")
                {
                    sum_bal = sum_bal + Convert.ToDecimal(dtForOB.Rows[0]["VOCHR_OB"].ToString());
                }

                int COUNT = 0;
                for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
                {
                    COUNT++;
                    //     strHtml += "<tr>";
                    //  strHtml += "<td class=\"tdT\" style=\" width:5%;text-align: left;\" >" + COUNT + "</td>";
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["PURCHS_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["PURCHS_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["INVOICE_AMT"].ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["PAID_AMT"].ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["SALES_RETURN_AMNT"].ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["BALNC_AMT"].ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["DAYS"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                }
                string strNetAmountCrComma = "", strNetAmountCrComma1 = "", strNetAmountCrComma2 = "", strNetAmountCrComma3 = "";
                if (sum_inv == 0)
                {
                    strNetAmountCrComma = String.Format(format, sum_inv);
                }
                else
                {
                    strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(sum_inv.ToString(), objEntityCommon);
                }
                if (sum_paid == 0)
                {
                    strNetAmountCrComma1 = String.Format(format, sum_paid);
                }
                else
                {
                    strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(sum_paid.ToString(), objEntityCommon);
                }
                if (sum_bal == 0)
                {
                    strNetAmountCrComma2 = String.Format(format, sum_bal);
                }
                else
                {
                    strNetAmountCrComma2 = objBusiness.AddCommasForNumberSeperation(sum_bal.ToString(), objEntityCommon);
                }
                if (sum_return == 0)
                {
                    strNetAmountCrComma3 = String.Format(format, sum_return);
                }
                else
                {
                    strNetAmountCrComma3 = objBusiness.AddCommasForNumberSeperation(sum_return.ToString(), objEntityCommon);
                }

                TBCustomer.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma1, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma3, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma2, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
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
    //---0044
    public string LoadConvertToTableCreditPopup_PDF(DataTable dtCategory, clsEntityOutstandingAgeing ObjEntityRequest, string strId1, string Printsts, string intdateto, string mode, string AgeingFrom, string AgeingTo, string Split1, string Split2, string Split3, string strName, string individual)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsBusinessOutstandingAgeing objBussiness = new clsBusinessOutstandingAgeing();
        int intCorpId = ObjEntityRequest.Corporate_id;
        int Decimalcount = 0;
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }
        string format = String.Format("{{0:N{0}}}", Decimalcount);
        int intCount = 0;
        decimal sum_inv = 0, sum_paid = 0, sum_bal = 0, sum_return = 0;
        foreach (DataRow dr in dtCategory.Rows)
        {
            sum_inv += Convert.ToDecimal(dr["INVOICE_AMT"]);
            sum_paid += Convert.ToDecimal(dr["PAID_AMT"]);
            sum_bal += Convert.ToDecimal(dr["BALNC_AMT"]);
            sum_return += Convert.ToDecimal(dr["SALES_RETURN_AMNT"]);
        }

        DataTable dtForOB = objBussiness.ReadOepningBalById(ObjEntityRequest);
        string strRandom = objCommon.Random_Number();
        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.SUPPLIER_OUTSTANDING_AGING_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SUPPLIER_OUTSTANDING_AGING_PDF);
        objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "SupAgeingCredit_" + strNextNumber + ".pdf";

        Document document = new Document(PageSize.A4, 50f, 40f, 120f, 30f);
        document = new Document(PageSize.LETTER, 50f, 40f, 20f, 30f);
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

                footrtable.AddCell(new PdfPCell(new Phrase("DATE     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(intdateto, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase("SUPPLIER     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(strName, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (mode == "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("MODE   ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    if (AgeingFrom != "" && AgeingTo != "")
                    {
                        footrtable.AddCell(new PdfPCell(new Phrase("METHOD 1", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase("AGEING   ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase(AgeingFrom + " - " + AgeingTo, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                    }
                    else
                    {
                        footrtable.AddCell(new PdfPCell(new Phrase("METHOD 1", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                    }
                }
                else
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("MODE ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase("METHOD 2 - Consolidated", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    if (Split1 != "" && Split2 != "" && Split3 != "")
                    {
                        footrtable.AddCell(new PdfPCell(new Phrase("AGEING   ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase(Split1 + " - " + Split2 + " - " + Split3, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                    }
                }
                document.Add(footrtable);

                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(7);
                float[] footrsBody = { 20, 10, 20, 10, 10, 20, 10 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;//get header column in all pages

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("INVOICE NO ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("INVOICE DATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("INVOICE AMOUNT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("PAID AMOUNT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("RETURN AMOUNT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("BALANCE AMOUNT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("DUE DAYS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                if (dtForOB.Rows.Count > 0)
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase("OPENING BALANCE", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(dtForOB.Rows[0]["VOCHR_OB"].ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    //strHtml += "<tr class=\"tr1\"><td class=\"tr_l\">OPENING BALANCE</td><td></td><td></td><td></td><td class=\"tr_r\" >" + objBusiness.AddCommasForNumberSeperation(dtForOB.Rows[0]["VOCHR_OB"].ToString(), objEntityCommon) + "</td><td></td>";
                    //strHtml += "</tr>";
                }
                if (dtForOB.Rows.Count > 0 && dtForOB.Rows[0]["VOCHR_OB"].ToString() != "")
                {
                    sum_bal = sum_bal + Convert.ToDecimal(dtForOB.Rows[0]["VOCHR_OB"].ToString());
                }

                int COUNT = 0;
                for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
                {
                    COUNT++;
                    //     strHtml += "<tr>";
                    //  strHtml += "<td class=\"tdT\" style=\" width:5%;text-align: left;\" >" + COUNT + "</td>";
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["PURCHS_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["PURCHS_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["INVOICE_AMT"].ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["PAID_AMT"].ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["SALES_RETURN_AMNT"].ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["BALNC_AMT"].ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["DAYS"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                      
                   
                }
                string strNetAmountCrComma = "", strNetAmountCrComma1 = "", strNetAmountCrComma2 = "", strNetAmountCrComma3 = "";
                if (sum_inv == 0)
                {
                    strNetAmountCrComma = String.Format(format, sum_inv);
                }
                else
                {
                    strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(sum_inv.ToString(), objEntityCommon);
                }
                if (sum_paid == 0)
                {
                    strNetAmountCrComma1 = String.Format(format, sum_paid);
                }
                else
                {
                    strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(sum_paid.ToString(), objEntityCommon);
                }
                if (sum_bal == 0)
                {
                    strNetAmountCrComma2 = String.Format(format, sum_bal);
                }
                else
                {
                    strNetAmountCrComma2 = objBusiness.AddCommasForNumberSeperation(sum_bal.ToString(), objEntityCommon);
                }
                if (sum_return == 0)
                {
                    strNetAmountCrComma3 = String.Format(format, sum_return);
                }
                else
                {
                    strNetAmountCrComma3 = objBusiness.AddCommasForNumberSeperation(sum_return.ToString(), objEntityCommon);
                }

                TBCustomer.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma1, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma3, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma2, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
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
    //---0044
    public string LoadConvertToTableLed_CSV(DataTable dtCategory, clsEntityOutstandingAgeing ObjEntityRequest, string strId1, string Printsts, string intdateto, string mode, string AgeingFrom, string AgeingTo, string Split1, string Split2, string Split3, string strName, string individual)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        DataTable dt = GetTable_3(dtCategory, ObjEntityRequest, strId1, Printsts, intdateto, mode, AgeingFrom, AgeingTo, Split1, Split2, Split3, strName, individual);
        string strResult = DataTableToCSV(dt, ',');
        string strImagePath = "";
        string filepath = "";

        if (ObjEntityRequest.Corporate_id != 0)
        {
            objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        }
        if (ObjEntityRequest.Organisation_id != 0)
        {
            objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        }


        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SUPPLIER_OUTSTNDG_AGEING_CSV);
        string strNextId = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string newFilePath = Server.MapPath("/CustomFiles/FMS CSV/Supplier Outstanding Ageing/Supp_AgeingTableLed_" + strNextId + ".csv");
        System.IO.File.WriteAllText(newFilePath, strResult);
        filepath = "Supp_AgeingTableLed_" + strNextId + ".csv";
        strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.SUPPLIER_OUTSTNDG_AGEING_CSV);
        return strImagePath + filepath;
    }
    public DataTable GetTable_3(DataTable dtCategory, clsEntityOutstandingAgeing ObjEntityRequest, string strId1, string Printsts, string intdateto, string mode, string AgeingFrom, string AgeingTo, string Split1, string Split2, string Split3, string strName, string individual)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = ObjEntityRequest.Corporate_id;
        int Decimalcount = 0;
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                              };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }
        string format = String.Format("{{0:N{0}}}", Decimalcount);
        decimal sum_inv = 0, sum_paid = 0, sum_bal = 0, sum_return = 0;
        foreach (DataRow dr in dtCategory.Rows)
        {
            sum_inv += Convert.ToDecimal(dr["INVOICE_AMT"]);
            sum_paid += Convert.ToDecimal(dr["PAID_AMT"]);
            sum_bal += Convert.ToDecimal(dr["BALNC_AMT"]);
            sum_return += Convert.ToDecimal(dr["SALES_RETURN_AMNT"]);
        }
        clsBusinessOutstandingAgeing objBussiness = new clsBusinessOutstandingAgeing();
        DataTable dtForOB = objBussiness.ReadOepningBalById(ObjEntityRequest);
        string strRandom = objCommon.Random_Number();

        DataTable table = new DataTable();
        try
        {
            string FORNULL = "";
            table.Columns.Add("SUPPLIER OUTSTANDING AGEING REPORT", typeof(string));
            table.Columns.Add(" ", typeof(string));
            table.Columns.Add("  ", typeof(string));
            table.Columns.Add("   ", typeof(string));
            table.Columns.Add("    ", typeof(string));
            table.Columns.Add("     ", typeof(string));
            table.Columns.Add("      ", typeof(string));

            table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

            table.Rows.Add("DATE :", '"' + intdateto + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
            table.Rows.Add("SUPPLIER :", '"' + strName + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

            if (mode == "0")
            {
                table.Rows.Add("MODE :", "METHOD 1", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
                if (AgeingFrom != "" && AgeingTo != "")
                {
                    table.Rows.Add("AGEING :", '"' + AgeingFrom + " to " + AgeingTo + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
                }
            }
            else
            {
                table.Rows.Add("MODE :", "METHOD 2 - Individual", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
                if (Split1 != "" && Split2 != "" && Split3 != "")
                {
                    table.Rows.Add("AGEING :", '"' + Split1 + " to " + Split2 + " to " + Split3 + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
                }
            }
            table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

            table.Rows.Add("INVOICE NO", "INVOICE DATE", "INVOICE AMOUNT", "PAID AMOUNT", "RETURN AMOUNT", "BALANCE AMOUNT", "AGEING");

            int COUNT = 0;

            if (dtForOB.Rows.Count > 0 && dtForOB.Rows[0]["VOCHR_OB"].ToString() != "")
            {
                table.Rows.Add("OPENING BALANCE", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + objBusiness.AddCommasForNumberSeperation(dtForOB.Rows[0]["VOCHR_OB"].ToString(), objEntityCommon) + '"', '"' + FORNULL + '"');
            }
            if (dtForOB.Rows.Count > 0 && dtForOB.Rows[0]["VOCHR_OB"].ToString() != "")
            {
                sum_bal = sum_bal + Convert.ToDecimal(dtForOB.Rows[0]["VOCHR_OB"].ToString());
            }
            for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
            {
                COUNT++;
                table.Rows.Add('"' + dtCategory.Rows[intRowBodyCount]["PURCHS_REF"].ToString() + '"', '"' + dtCategory.Rows[intRowBodyCount]["PURCHS_DATE"].ToString() + '"', '"' + objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["INVOICE_AMT"].ToString(), objEntityCommon) + '"', '"' + objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["PAID_AMT"].ToString(), objEntityCommon) + '"', '"' + objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["SALES_RETURN_AMNT"].ToString(), objEntityCommon) + '"', '"' + objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["BALNC_AMT"].ToString(), objEntityCommon) + '"', '"' + dtCategory.Rows[intRowBodyCount]["DAYS"].ToString() + '"');
            }

            string strNetAmountCrComma = "", strNetAmountCrComma1 = "", strNetAmountCrComma2 = "", strNetAmountCrComma3 = "";
            if (sum_inv == 0)
            {
                strNetAmountCrComma = String.Format(format, sum_inv);
            }
            else
            {
                strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(sum_inv.ToString(), objEntityCommon);
            }
            if (sum_paid == 0)
            {
                strNetAmountCrComma1 = String.Format(format, sum_paid);
            }
            else
            {
                strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(sum_paid.ToString(), objEntityCommon);
            }
            if (sum_bal == 0)
            {
                strNetAmountCrComma2 = String.Format(format, sum_bal);
            }
            else
            {
                strNetAmountCrComma2 = objBusiness.AddCommasForNumberSeperation(sum_bal.ToString(), objEntityCommon);
            }
            if (sum_return == 0)
            {
                strNetAmountCrComma3 = String.Format(format, sum_return);
            }
            else
            {
                strNetAmountCrComma3 = objBusiness.AddCommasForNumberSeperation(sum_return.ToString(), objEntityCommon);
            }

            table.Rows.Add("TOTAL", '"' + FORNULL + '"', '"' + strNetAmountCrComma + '"', '"' + strNetAmountCrComma1 + '"', '"' + strNetAmountCrComma3 + '"', '"' + strNetAmountCrComma2 + '"', '"' + FORNULL + '"');
        }
        catch (Exception)
        {
        }
        return table;
    }
    public string LoadConvertToTableCreditPopup_CSV(DataTable dtCategory, clsEntityOutstandingAgeing ObjEntityRequest, string strId1, string Printsts, string intdateto, string mode, string AgeingFrom, string AgeingTo, string Split1, string Split2, string Split3, string strName, string individual)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        DataTable dt = GetTable_CreditPopup(dtCategory, ObjEntityRequest, strId1, Printsts, intdateto, mode, AgeingFrom, AgeingTo, Split1, Split2, Split3, strName, individual);
        string strResult = DataTableToCSV(dt, ',');
        string strImagePath = "";
        string filepath = "";

        if (ObjEntityRequest.Corporate_id != 0)
        {
            objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        }
        if (ObjEntityRequest.Organisation_id != 0)
        {
            objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        }


        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SUPPLIER_OUTSTNDG_AGEING_CSV);
        string strNextId = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string newFilePath = Server.MapPath("/CustomFiles/FMS CSV/Supplier Outstanding Ageing/Supp_AgeingTableCredit_" + strNextId + ".csv");
        System.IO.File.WriteAllText(newFilePath, strResult);
        filepath = "Supp_AgeingTableCredit_" + strNextId + ".csv";
        strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.SUPPLIER_OUTSTNDG_AGEING_CSV);
        return strImagePath + filepath;
    }
    public DataTable GetTable_CreditPopup(DataTable dtCategory, clsEntityOutstandingAgeing ObjEntityRequest, string strId1, string Printsts, string intdateto, string mode, string AgeingFrom, string AgeingTo, string Split1, string Split2, string Split3, string strName, string individual)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = ObjEntityRequest.Corporate_id;
        int Decimalcount = 0;
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                              };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }
        string format = String.Format("{{0:N{0}}}", Decimalcount);
        decimal sum_inv = 0, sum_paid = 0, sum_bal = 0, sum_return = 0;
        foreach (DataRow dr in dtCategory.Rows)
        {
            sum_inv += Convert.ToDecimal(dr["INVOICE_AMT"]);
            sum_paid += Convert.ToDecimal(dr["PAID_AMT"]);
            sum_bal += Convert.ToDecimal(dr["BALNC_AMT"]);
            sum_return += Convert.ToDecimal(dr["SALES_RETURN_AMNT"]);
        }
        clsBusinessOutstandingAgeing objBussiness = new clsBusinessOutstandingAgeing();
        DataTable dtForOB = objBussiness.ReadOepningBalById(ObjEntityRequest);
        string strRandom = objCommon.Random_Number();

        DataTable table = new DataTable();
        try
        {
            string FORNULL = "";
            table.Columns.Add("SUPPLIER OUTSTANDING AGEING REPORT", typeof(string));
            table.Columns.Add(" ", typeof(string));
            table.Columns.Add("  ", typeof(string));
            table.Columns.Add("   ", typeof(string));
            table.Columns.Add("    ", typeof(string));
            table.Columns.Add("     ", typeof(string));
            table.Columns.Add("      ", typeof(string));

            table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

            table.Rows.Add("DATE :", '"' + intdateto + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
            table.Rows.Add("SUPPLIER :", '"' + strName + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

            if (mode == "0")
            {
                table.Rows.Add("MODE :", "METHOD 1", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
                if (AgeingFrom != "" && AgeingTo != "")
                {
                    table.Rows.Add("AGEING :", '"' + AgeingFrom + " to " + AgeingTo + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
                }
            }
            else
            {
                table.Rows.Add("MODE :", "METHOD 2 - Individual", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
                if (Split1 != "" && Split2 != "" && Split3 != "")
                {
                    table.Rows.Add("AGEING :", '"' + Split1 + " to " + Split2 + " to " + Split3 + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
                }
            }
            table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

            table.Rows.Add("INVOICE NO", "INVOICE DATE", "INVOICE AMOUNT", "PAID AMOUNT", "RETURN AMOUNT", "BALANCE AMOUNT", "DUE DAYS");

            int COUNT = 0;

            if (dtForOB.Rows.Count > 0 && dtForOB.Rows[0]["VOCHR_OB"].ToString() != "")
            {
                table.Rows.Add("OPENING BALANCE", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + objBusiness.AddCommasForNumberSeperation(dtForOB.Rows[0]["VOCHR_OB"].ToString(), objEntityCommon) + '"', '"' + FORNULL + '"');
            }
            if (dtForOB.Rows.Count > 0 && dtForOB.Rows[0]["VOCHR_OB"].ToString() != "")
            {
                sum_bal = sum_bal + Convert.ToDecimal(dtForOB.Rows[0]["VOCHR_OB"].ToString());
            }
            for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
            {
                COUNT++;

                table.Rows.Add('"' + dtCategory.Rows[intRowBodyCount]["PURCHS_REF"].ToString() + '"', '"' + dtCategory.Rows[intRowBodyCount]["PURCHS_DATE"].ToString() + '"', '"' + objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["INVOICE_AMT"].ToString(), objEntityCommon) + '"', '"' + objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["PAID_AMT"].ToString(), objEntityCommon) + '"', '"' + objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["SALES_RETURN_AMNT"].ToString(), objEntityCommon) + '"', '"' + objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["BALNC_AMT"].ToString(), objEntityCommon) + '"', '"' + dtCategory.Rows[intRowBodyCount]["DAYS"].ToString() + '"');
            }
              
            

            string strNetAmountCrComma = "", strNetAmountCrComma1 = "", strNetAmountCrComma2 = "", strNetAmountCrComma3 = "";
            if (sum_inv == 0)
            {
                strNetAmountCrComma = String.Format(format, sum_inv);
            }
            else
            {
                strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(sum_inv.ToString(), objEntityCommon);
            }
            if (sum_paid == 0)
            {
                strNetAmountCrComma1 = String.Format(format, sum_paid);
            }
            else
            {
                strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(sum_paid.ToString(), objEntityCommon);
            }
            if (sum_bal == 0)
            {
                strNetAmountCrComma2 = String.Format(format, sum_bal);
            }
            else
            {
                strNetAmountCrComma2 = objBusiness.AddCommasForNumberSeperation(sum_bal.ToString(), objEntityCommon);
            }
            if (sum_return == 0)
            {
                strNetAmountCrComma3 = String.Format(format, sum_return);
            }
            else
            {
                strNetAmountCrComma3 = objBusiness.AddCommasForNumberSeperation(sum_return.ToString(), objEntityCommon);
            }

            table.Rows.Add("TOTAL", '"' + FORNULL + '"', '"' + strNetAmountCrComma + '"', '"' + strNetAmountCrComma1 + '"', '"' + strNetAmountCrComma3 + '"', '"' + strNetAmountCrComma2 + '"', '"' + FORNULL + '"');
        }
        catch (Exception)
        {
        }
        return table;
    }

    //method2 consolidated list detail popup
    public string LoadConvertToTableLedCons(DataTable dtCategory, clsEntityOutstandingAgeing ObjEntityRequest, string strId, string Printsts)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();

        int intCorpId = ObjEntityRequest.Corporate_id, intOrgId = 0, intUserId = 0;
        int Decimalcount = 0;
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                    clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                    clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                    clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                    };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }
        string format = String.Format("{{0:N{0}}}", Decimalcount);
        int intCount = 0;
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        string strHtml = "";
        if (Printsts == "0")
        {
            strHtml = "<table id=\"datatable_fixed_column" + strId + "\" class=\" table-bordered display\" width=\"100%\">";
            //add header row
            strHtml += "<thead class=\"thead1\">";
            strHtml += "<tr>";
            //strHtml += "<th class=\"hasinput\" style=\"text-align:left;width:5%;\">SL NO ";
            //strHtml += "</th >";
            strHtml += "<th class=\"col-md-2 td1 tr_l\" >INVOICE NO ";
            strHtml += "<input class=\"tb_inp_1 tb_in tr_l\" placeholder=\"INVOICE NO \" type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-1\" >INVOICE DATE ";
            strHtml += "<input class=\"tb_inp_1 tb_in\" placeholder=\"INVOICE DATE\" type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-2 tr_r\" >INVOICE AMOUNT ";
            strHtml += "<input class=\"tb_inp_1 tb_in tr_r\" placeholder=\"INVOICE AMOUNT \"  type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-1 tr_r\" >PAID AMOUNT ";
            strHtml += "<input class=\"tb_inp_1 tb_in tr_r\" placeholder=\"PAID AMOUNT\" type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-1 tr_r\" >RETURN AMOUNT ";
            strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input class=\"tb_inp_1 tb_in tr_r\" placeholder=\"RETURN AMOUNT\"  type=\"text\">";
            strHtml += "</th >";
            //strHtml += "<th class=\"col-md-1 tr_r\" >NO DUE ";
            //strHtml += "<input class=\"tb_inp_1 tb_in tr_r\" placeholder=\"NO DUE\"  type=\"text\">";
            //strHtml += "</th >";
            strHtml += "<th class=\"col-md-1 tr_c\" >0-" + ObjEntityRequest.Split1 + "";
            strHtml += "<input class=\"tb_inp_1 tb_in tr_c\" placeholder=\"0-" + ObjEntityRequest.Split1 + "\"  type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-1 tr_c\" >" + (ObjEntityRequest.Split1 + 1) + "-" + ObjEntityRequest.Split2 + "";
            strHtml += "<input class=\"tb_inp_1 tb_in tr_c\" placeholder=\"" + (ObjEntityRequest.Split1 + 1) + " - " + ObjEntityRequest.Split2 + "\"  type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-1 tr_c\" >" + (ObjEntityRequest.Split2 + 1) + "-" + ObjEntityRequest.Split3 + "";
            strHtml += "<input class=\"tb_inp_1 tb_in tr_c\" placeholder=\"" + (ObjEntityRequest.Split2 + 1) + " - " + ObjEntityRequest.Split3 + "\" type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-1 tr_c\" >>" + ObjEntityRequest.Split3 + "";
            strHtml += "<input class=\"tb_inp_1 tb_in tr_c\" placeholder=\">" + ObjEntityRequest.Split3 + "\"  type=\"text\">";
            strHtml += "</th >";
            strHtml += "</tr>";
            strHtml += "</thead>";
        }
        else
        {
            strHtml = "<table id=\"PrintTable\" class=\"tab\" \">";
            //add header row
            strHtml += "<thead>";
            strHtml += "<tr class=\"top_row\">";
            //strHtml += "<th class=\"thT\" style=\"width:5%;text-align:left;\">SL NO";
            //strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:20%;text-align:left;\">INVOICE NO";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:10%;text-align:center;\">INVOICE DATE";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:10%;text-align:right;\">INVOICE AMOUNT";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:10%;text-align:right;\">PAID AMOUNT";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:10%;text-align:right;\">RETURN AMOUNT";
            strHtml += "</th >";
            //strHtml += "<th class=\"thT\" style=\"width:10%;text-align:right;\">NO DUE";
            //strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:10%;text-align:right;\">0-" + ObjEntityRequest.Split1 + "";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:10%;text-align:right;\">" + (ObjEntityRequest.Split1 + 1) + "-" + ObjEntityRequest.Split2 + "";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:10%;text-align:right;\">" + (ObjEntityRequest.Split2 + 1) + "-" + ObjEntityRequest.Split3 + "";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:10%;text-align:right;\">>" + ObjEntityRequest.Split3 + "";
            strHtml += "</th >";
            strHtml += "</tr>";
            strHtml += "</thead>";
        }

        clsBusinessOutstandingAgeing objBussiness = new clsBusinessOutstandingAgeing();
        DataTable dtForOB = objBussiness.ReadOepningBalById(ObjEntityRequest);
        if (dtForOB.Rows.Count > 0)
        {
            strHtml += "<tr class=\"tr1\"><td class=\"tr_l\">OPENING BALANCE</td><td></td><td></td><td></td><td class=\"tr_r\" >" + objBusiness.AddCommasForNumberSeperation(dtForOB.Rows[0]["VOCHR_OB"].ToString(), objEntityCommon) + "</td><td></td><td></td><td></td><td></td></td>";
            strHtml += "</tr>";
        }

        //add rows
        strHtml += "<tbody>";
        int COUNT = 0;
        decimal Netsum1 = 0, Netsum2 = 0, Netsum3 = 0, Netsum4 = 0, Netsum5 = 0, invAmnt = 0, PaidAmnt = 0, sum_return = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
        {
            COUNT++;
            decimal sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0, sum5 = 0;

            int daysAge = Convert.ToInt32(dtCategory.Rows[intRowBodyCount]["DAYS"].ToString());
            //if (daysAge == 0)
            //{
            //    sum1 = Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["BALNC_AMT"].ToString());
            //}
            //else 
            if (daysAge >= 0 && daysAge <= ObjEntityRequest.Split1)
            {
                sum2 = Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["BALNC_AMT"].ToString());
            }
            else if (daysAge >= ObjEntityRequest.Split1 + 1 && daysAge <= ObjEntityRequest.Split2)
            {
                sum3 = Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["BALNC_AMT"].ToString());
            }
            else if (daysAge >= ObjEntityRequest.Split2 + 1 && daysAge <= ObjEntityRequest.Split3)
            {
                sum4 = Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["BALNC_AMT"].ToString());
            }
            else if (daysAge > ObjEntityRequest.Split3)
            {
                sum5 = Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["BALNC_AMT"].ToString());
            }
            invAmnt += Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["INVOICE_AMT"].ToString());
            PaidAmnt += Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["PAID_AMT"].ToString());
            sum_return += Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["SALES_RETURN_AMNT"].ToString());

            Netsum1 += sum1;
            Netsum2 += sum2;
            Netsum3 += sum3;
            Netsum4 += sum4;
            Netsum5 += sum5;

            string strsum1 = "", strsum2 = "", strsum3 = "", strsum4 = "", strsum5 = "";
            if (sum1 == 0)
            {
                strsum1 = String.Format(format, sum1);
            }
            else
            {
                strsum1 = objBusiness.AddCommasForNumberSeperation(sum1.ToString(), objEntityCommon);
            }
            if (sum2 == 0)
            {
                strsum2 = String.Format(format, sum2);
            }
            else
            {
                strsum2 = objBusiness.AddCommasForNumberSeperation(sum2.ToString(), objEntityCommon);
            }
            if (sum3 == 0)
            {
                strsum3 = String.Format(format, sum3);
            }
            else
            {
                strsum3 = objBusiness.AddCommasForNumberSeperation(sum3.ToString(), objEntityCommon);
            }
            if (sum4 == 0)
            {
                strsum4 = String.Format(format, sum4);
            }
            else
            {
                strsum4 = objBusiness.AddCommasForNumberSeperation(sum4.ToString(), objEntityCommon);
            }
            if (sum5 == 0)
            {
                strsum5 = String.Format(format, sum5);
            }
            else
            {
                strsum5 = objBusiness.AddCommasForNumberSeperation(sum5.ToString(), objEntityCommon);
            }

            strHtml += "<tr>";
            strHtml += "<td class=\"tr_l\" >" + dtCategory.Rows[intRowBodyCount]["PURCHS_REF"].ToString() + "</td>";
            strHtml += "<td  style=\"text-align:center !important;\" >" + dtCategory.Rows[intRowBodyCount]["PURCHS_DATE"].ToString() + "</td>";
            strHtml += "<td class=\"tr_r\" style=\"text-align:right;\">" + objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["INVOICE_AMT"].ToString(), objEntityCommon) + "</td>";
            strHtml += "<td class=\"tr_r\" style=\"text-align:right;\" >" + objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["PAID_AMT"].ToString(), objEntityCommon) + "</td>";
            strHtml += "<td class=\"tr_r\"  style=\"text-align:right;\">" + objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["SALES_RETURN_AMNT"].ToString(), objEntityCommon) + "</td>";
            //strHtml += "<td class=\"tr_r\"  style=\"text-align:right;\">" + strsum1 + "</td>";
            strHtml += "<td class=\"tr_r\"  style=\"text-align:right;\">" + strsum2 + "</td>";
            strHtml += "<td class=\"tr_r\" style=\"text-align:right;\">" + strsum3 + "</td>";
            strHtml += "<td class=\"tr_r\" style=\"text-align:right;\" >" + strsum4 + "</td>";
            strHtml += "<td class=\"tr_r\" style=\"text-align:right;\">" + strsum5 + "</td>";
            strHtml += "</tr>";
        }
        strHtml += "</tbody>";
        if (dtCategory.Rows.Count > 0)
        {

            string strsum1 = "", strsum2 = "", strsum3 = "", strsum4 = "", strsum5 = "", strsumInv = "", strsumPaid = "", strsumReturn = "";
            if (invAmnt == 0)
            {
                strsumInv = String.Format(format, invAmnt);
            }
            else
            {
                strsumInv = objBusiness.AddCommasForNumberSeperation(invAmnt.ToString(), objEntityCommon);
            }
            if (PaidAmnt == 0)
            {
                strsumPaid = String.Format(format, PaidAmnt);
            }
            else
            {
                strsumPaid = objBusiness.AddCommasForNumberSeperation(PaidAmnt.ToString(), objEntityCommon);
            }

            if (dtForOB.Rows.Count > 0 && dtForOB.Rows[0]["VOCHR_OB"].ToString() != "")
            {
                Netsum1 = Netsum1 + Convert.ToDecimal(dtForOB.Rows[0]["VOCHR_OB"].ToString());
            }

            if (Netsum1 == 0)
            {
                strsum1 = String.Format(format, Netsum1);
            }
            else
            {
                strsum1 = objBusiness.AddCommasForNumberSeperation(Netsum1.ToString(), objEntityCommon);
            }
            if (Netsum2 == 0)
            {
                strsum2 = String.Format(format, Netsum2);
            }
            else
            {
                strsum2 = objBusiness.AddCommasForNumberSeperation(Netsum2.ToString(), objEntityCommon);
            }
            if (Netsum3 == 0)
            {
                strsum3 = String.Format(format, Netsum3);
            }
            else
            {
                strsum3 = objBusiness.AddCommasForNumberSeperation(Netsum3.ToString(), objEntityCommon);
            }
            if (Netsum4 == 0)
            {
                strsum4 = String.Format(format, Netsum4);
            }
            else
            {
                strsum4 = objBusiness.AddCommasForNumberSeperation(Netsum4.ToString(), objEntityCommon);
            }

            if (dtForOB.Rows.Count > 0 && dtForOB.Rows[0]["VOCHR_OB"].ToString() != "")
            {
                Netsum5 = Netsum5 + Convert.ToDecimal(dtForOB.Rows[0]["VOCHR_OB"].ToString());
            }

            if (Netsum5 == 0)
            {
                strsum5 = String.Format(format, Netsum5);
            }
            else
            {
                strsum5 = objBusiness.AddCommasForNumberSeperation(Netsum5.ToString(), objEntityCommon);
            }
            if (sum_return == 0)
            {
                strsumReturn = String.Format(format, sum_return);
            }
            else
            {
                strsumReturn = objBusiness.AddCommasForNumberSeperation(sum_return.ToString(), objEntityCommon);
            }


            strHtml += " <tfoot> <tr class=\"tr1\">";
            strHtml += "<th class=\"tr_r txt_rd bg1\"  style=\"text-align:left !important;\">TOTAL </th>";
            strHtml += "<th class=\"tr_r txt_rd bg1\"  ></th>";
            strHtml += "<th class=\"tr_r txt_rd bg1\" style=\"text-align:right;\">" + strsumInv + " </th>";
            strHtml += "<th class=\"tr_r txt_rd bg1\" style=\"text-align:right;\">" + strsumPaid + " </th>";
            strHtml += "<th class=\"tr_r txt_rd bg1\" style=\"text-align:right;\">" + strsumReturn + " </th>";
            //strHtml += "<th class=\"tr_r txt_rd bg1\" style=\"text-align:right;\"> " + strsum1 + "</th>";
            strHtml += "<th class=\"tr_r txt_rd bg1\"  style=\"text-align:right;\"> " + strsum2 + "</th>";
            strHtml += "<th class=\"tr_r txt_rd bg1\" style=\"text-align:right;\"> " + strsum3 + "</th>";
            strHtml += "<th class=\"tr_r txt_rd bg1\" style=\"text-align:right;\"> " + strsum4 + "</th>";
            strHtml += "<th class=\"tr_r txt_rd bg1\"  style=\"text-align:right;\"> " + strsum5 + "</th>";
            strHtml += "</tr></tfoot>";
        }
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    public string LoadConvertToTableLedCons_PDF(DataTable dtCategory, clsEntityOutstandingAgeing ObjEntityRequest, string strId, string Printsts, string intdateto, string mode, string AgeingFrom, string AgeingTo, string Split1, string Split2, string Split3, string strName, string individual)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();

        int intCorpId = ObjEntityRequest.Corporate_id, intOrgId = 0, intUserId = 0;
        int Decimalcount = 0;
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                    clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                    clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                    clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                    };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }
        string format = String.Format("{{0:N{0}}}", Decimalcount);
        int intCount = 0;
        string strRandom = objCommon.Random_Number();
        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.SUPPLIER_OUTSTANDING_AGING_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SUPPLIER_OUTSTANDING_AGING_PDF);
        objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "SuppAgeing_LedCons" + strNextNumber + ".pdf";

        Document document = new Document(PageSize.A4, 50f, 40f, 120f, 30f);
        document = new Document(PageSize.LETTER, 50f, 40f, 20f, 30f);
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

                footrtable.AddCell(new PdfPCell(new Phrase("DATE     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(intdateto, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase("SUPPLIER     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(strName, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (mode == "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("MODE   ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    if (AgeingFrom != "" && AgeingTo != "")
                    {
                        footrtable.AddCell(new PdfPCell(new Phrase("METHOD 1", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase("AGEING   ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase(AgeingFrom + " - " + AgeingTo, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                    }
                    else
                    {
                        footrtable.AddCell(new PdfPCell(new Phrase("METHOD 1", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                    }
                }
                else
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("MODE ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    if (individual == "0")
                    {
                        footrtable.AddCell(new PdfPCell(new Phrase("METHOD 2 - Individual", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    }
                    else
                    {
                        footrtable.AddCell(new PdfPCell(new Phrase("METHOD 2 - Consolidated", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    }
                    if (Split1 != "" && Split2 != "" && Split3 != "")
                    {
                        footrtable.AddCell(new PdfPCell(new Phrase("AGEING   ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase(Split1 + " - " + Split2 + " - " + Split3, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                    }
                }
                document.Add(footrtable);

                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(9);
                float[] footrsBody = { 10, 10, 10, 10, 15, 15, 10, 10, 10, 10 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;//get header column in all pages

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("INVOICE NO", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("INVOICE DATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("INVOICE AMOUNT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("PAID AMOUNT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("RETURN AMOUNT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                //TBCustomer.AddCell(new PdfPCell(new Phrase("NO DUE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase(ObjEntityRequest.Split1 + " ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase((ObjEntityRequest.Split1 + 1) + "-" + ObjEntityRequest.Split2 + "", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase((ObjEntityRequest.Split2 + 1) + "-" + ObjEntityRequest.Split3 + "", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase(">" + ObjEntityRequest.Split3, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                clsBusinessOutstandingAgeing objBussiness = new clsBusinessOutstandingAgeing();
                DataTable dtForOB = objBussiness.ReadOepningBalById(ObjEntityRequest);
                if (dtForOB.Rows.Count > 0)
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase("OPENING BALANCE", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    //TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(dtForOB.Rows[0]["VOCHR_OB"].ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                }
                int COUNT = 0;
                decimal Netsum1 = 0, Netsum2 = 0, Netsum3 = 0, Netsum4 = 0, Netsum5 = 0, invAmnt = 0, PaidAmnt = 0, sum_return = 0;
                for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
                {
                    COUNT++;
                    decimal sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0, sum5 = 0;

                    int daysAge = Convert.ToInt32(dtCategory.Rows[intRowBodyCount]["DAYS"].ToString());
                    //if (daysAge == 0)
                    //{
                    //    sum1 = Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["BALNC_AMT"].ToString());
                    //}
                    //else 
                    if (daysAge >= 0 && daysAge <= ObjEntityRequest.Split1)
                    {
                        sum2 = Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["BALNC_AMT"].ToString());
                    }
                    else if (daysAge >= ObjEntityRequest.Split1 + 1 && daysAge <= ObjEntityRequest.Split2)
                    {
                        sum3 = Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["BALNC_AMT"].ToString());
                    }
                    else if (daysAge >= ObjEntityRequest.Split2 + 1 && daysAge <= ObjEntityRequest.Split3)
                    {
                        sum4 = Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["BALNC_AMT"].ToString());
                    }
                    else if (daysAge > ObjEntityRequest.Split3)
                    {
                        sum5 = Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["BALNC_AMT"].ToString());
                    }
                    invAmnt += Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["INVOICE_AMT"].ToString());
                    PaidAmnt += Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["PAID_AMT"].ToString());
                    sum_return += Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["SALES_RETURN_AMNT"].ToString());

                    Netsum1 += sum1;
                    Netsum2 += sum2;
                    Netsum3 += sum3;
                    Netsum4 += sum4;
                    Netsum5 += sum5;

                    string strsum1 = "", strsum2 = "", strsum3 = "", strsum4 = "", strsum5 = "";
                    if (sum1 == 0)
                    {
                        strsum1 = String.Format(format, sum1);
                    }
                    else
                    {
                        strsum1 = objBusiness.AddCommasForNumberSeperation(sum1.ToString(), objEntityCommon);
                    }
                    if (sum2 == 0)
                    {
                        strsum2 = String.Format(format, sum2);
                    }
                    else
                    {
                        strsum2 = objBusiness.AddCommasForNumberSeperation(sum2.ToString(), objEntityCommon);
                    }
                    if (sum3 == 0)
                    {
                        strsum3 = String.Format(format, sum3);
                    }
                    else
                    {
                        strsum3 = objBusiness.AddCommasForNumberSeperation(sum3.ToString(), objEntityCommon);
                    }
                    if (sum4 == 0)
                    {
                        strsum4 = String.Format(format, sum4);
                    }
                    else
                    {
                        strsum4 = objBusiness.AddCommasForNumberSeperation(sum4.ToString(), objEntityCommon);
                    }
                    if (sum5 == 0)
                    {
                        strsum5 = String.Format(format, sum5);
                    }
                    else
                    {
                        strsum5 = objBusiness.AddCommasForNumberSeperation(sum5.ToString(), objEntityCommon);
                    }

                    //strHtml += "<tr>";
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["PURCHS_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["PURCHS_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["INVOICE_AMT"].ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["PAID_AMT"].ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["SALES_RETURN_AMNT"].ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    //TBCustomer.AddCell(new PdfPCell(new Phrase(strsum1, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strsum2, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strsum3, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strsum4, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strsum5, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                }
                if (dtCategory.Rows.Count > 0)
                {

                    string strsum1 = "", strsum2 = "", strsum3 = "", strsum4 = "", strsum5 = "", strsumInv = "", strsumPaid = "", strsumReturn = "";
                    if (invAmnt == 0)
                    {
                        strsumInv = String.Format(format, invAmnt);
                    }
                    else
                    {
                        strsumInv = objBusiness.AddCommasForNumberSeperation(invAmnt.ToString(), objEntityCommon);
                    }
                    if (PaidAmnt == 0)
                    {
                        strsumPaid = String.Format(format, PaidAmnt);
                    }
                    else
                    {
                        strsumPaid = objBusiness.AddCommasForNumberSeperation(PaidAmnt.ToString(), objEntityCommon);
                    }

                    if (dtForOB.Rows.Count > 0 && dtForOB.Rows[0]["VOCHR_OB"].ToString() != "")
                    {
                        Netsum1 = Netsum1 + Convert.ToDecimal(dtForOB.Rows[0]["VOCHR_OB"].ToString());
                    }

                    if (Netsum1 == 0)
                    {
                        strsum1 = String.Format(format, Netsum1);
                    }
                    else
                    {
                        strsum1 = objBusiness.AddCommasForNumberSeperation(Netsum1.ToString(), objEntityCommon);
                    }
                    if (Netsum2 == 0)
                    {
                        strsum2 = String.Format(format, Netsum2);
                    }
                    else
                    {
                        strsum2 = objBusiness.AddCommasForNumberSeperation(Netsum2.ToString(), objEntityCommon);
                    }
                    if (Netsum3 == 0)
                    {
                        strsum3 = String.Format(format, Netsum3);
                    }
                    else
                    {
                        strsum3 = objBusiness.AddCommasForNumberSeperation(Netsum3.ToString(), objEntityCommon);
                    }
                    if (Netsum4 == 0)
                    {
                        strsum4 = String.Format(format, Netsum4);
                    }
                    else
                    {
                        strsum4 = objBusiness.AddCommasForNumberSeperation(Netsum4.ToString(), objEntityCommon);
                    }

                    if (dtForOB.Rows.Count > 0 && dtForOB.Rows[0]["VOCHR_OB"].ToString() != "")
                    {
                        Netsum5 = Netsum5 + Convert.ToDecimal(dtForOB.Rows[0]["VOCHR_OB"].ToString());
                    }

                    if (Netsum5 == 0)
                    {
                        strsum5 = String.Format(format, Netsum5);
                    }
                    else
                    {
                        strsum5 = objBusiness.AddCommasForNumberSeperation(Netsum5.ToString(), objEntityCommon);
                    }
                    if (sum_return == 0)
                    {
                        strsumReturn = String.Format(format, sum_return);
                    }
                    else
                    {
                        strsumReturn = objBusiness.AddCommasForNumberSeperation(sum_return.ToString(), objEntityCommon);
                    }

                    TBCustomer.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strsumInv, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strsumPaid, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strsumReturn, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    //TBCustomer.AddCell(new PdfPCell(new Phrase(strsum1, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strsum2, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strsum3, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strsum4, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strsum5, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
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
    public string LoadConvertToTableLedCons_CSV(DataTable dtCategory, clsEntityOutstandingAgeing ObjEntityRequest, string strId, string Printsts, string intdateto, string mode, string AgeingFrom, string AgeingTo, string Split1, string Split2, string Split3, string strName, string individual)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        DataTable dt = GetTable_4(dtCategory, ObjEntityRequest, strId, Printsts, intdateto, mode, AgeingFrom, AgeingTo, Split1, Split2, Split3, strName, individual);
        string strResult = DataTableToCSV(dt, ',');
        string strImagePath = "";
        string filepath = "";

        if (ObjEntityRequest.Corporate_id != 0)
        {
            objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        }
        if (ObjEntityRequest.Organisation_id != 0)
        {
            objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        }

        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SUPPLIER_OUTSTNDG_AGEING_CSV);
        string strNextId = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string newFilePath = Server.MapPath("/CustomFiles/FMS CSV/Supplier Outstanding Ageing/Supp_AgeingTableLedCons_" + strNextId + ".csv");
        System.IO.File.WriteAllText(newFilePath, strResult);
        filepath = "Supp_AgeingTableLedCons_" + strNextId + ".csv";
        strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.SUPPLIER_OUTSTNDG_AGEING_CSV);
        return strImagePath + filepath;
    }
    public DataTable GetTable_4(DataTable dtCategory, clsEntityOutstandingAgeing ObjEntityRequest, string strId, string Printsts, string intdateto, string mode, string AgeingFrom, string AgeingTo, string Split1, string Split2, string Split3, string strName, string individual)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = ObjEntityRequest.Corporate_id, intOrgId = 0, intUserId = 0;
        int Decimalcount = 0;
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                    clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                    };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }
        string format = String.Format("{{0:N{0}}}", Decimalcount);
        string strRandom = objCommon.Random_Number();

        string FORNULL = "";
        DataTable table = new DataTable();
        try
        {
            table.Columns.Add("SUPPLIER OUTSTANDING AGEING REPORT", typeof(string));
            table.Columns.Add(" ", typeof(string));
            table.Columns.Add("  ", typeof(string));
            table.Columns.Add("   ", typeof(string));
            table.Columns.Add("    ", typeof(string));
            table.Columns.Add("     ", typeof(string));
            table.Columns.Add("      ", typeof(string));
            table.Columns.Add("       ", typeof(string));
            table.Columns.Add("        ", typeof(string));
            table.Columns.Add("         ", typeof(string));

            table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

            table.Rows.Add("DATE : ", '"' + intdateto + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
            table.Rows.Add("SUPPLIER : ", '"' + strName + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

            if (mode == "0")
            {
                table.Rows.Add("MODE : ", "METHOD 1", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
                if (AgeingFrom != "" && AgeingTo != "")
                {
                    table.Rows.Add("AGEING : ", '"' + AgeingFrom + " to " + AgeingTo + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
                }
            }
            else
            {
                table.Rows.Add("MODE : ", "METHOD 2 - Consolidated", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
                if (Split1 != "" && Split2 != "" && Split3 != "")
                {
                    table.Rows.Add("AGEING : ", '"' + Split1 + " to " + Split2 + " to " + Split3 + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
                }
            }
            table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

            string AgeingSec_1 = "0 to " + ObjEntityRequest.Split1 + "";
            string AgeingSec_2 = (ObjEntityRequest.Split1 + 1) + " to " + ObjEntityRequest.Split2 + "";
            string AgeingSec_3 = (ObjEntityRequest.Split2 + 1) + " to " + ObjEntityRequest.Split3 + "";
            string AgeingSec_4 = ">" + ObjEntityRequest.Split3 + "";

            table.Rows.Add("INVOICE NO", "INVOICE DATE", "INVOICE AMOUNT", "PAID AMOUNT", "RETURN AMOUNT", '"' + AgeingSec_1 + '"', '"' + AgeingSec_2 + '"', '"' + AgeingSec_3 + '"', '"' + AgeingSec_4 + '"');

            int COUNT = 0;
            decimal Netsum1 = 0, Netsum2 = 0, Netsum3 = 0, Netsum4 = 0, Netsum5 = 0, invAmnt = 0, PaidAmnt = 0, sum_return = 0;
            clsBusinessOutstandingAgeing objBussiness = new clsBusinessOutstandingAgeing();
            DataTable dtForOB = objBussiness.ReadOepningBalById(ObjEntityRequest);
            if (dtForOB.Rows.Count > 0)
            {
                table.Rows.Add("OPENING BALANCE", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + objBusiness.AddCommasForNumberSeperation(dtForOB.Rows[0]["VOCHR_OB"].ToString(), objEntityCommon) + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
            }

            for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
            {
                COUNT++;
                decimal sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0, sum5 = 0;

                int daysAge = Convert.ToInt32(dtCategory.Rows[intRowBodyCount]["DAYS"].ToString());
                //if (daysAge == 0)
                //{
                //    sum1 = Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["BALNC_AMT"].ToString());
                //}
                //else 
                if (daysAge >= 0 && daysAge <= ObjEntityRequest.Split1)
                {
                    sum2 = Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["BALNC_AMT"].ToString());
                }
                else if (daysAge >= ObjEntityRequest.Split1 + 1 && daysAge <= ObjEntityRequest.Split2)
                {
                    sum3 = Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["BALNC_AMT"].ToString());
                }
                else if (daysAge >= ObjEntityRequest.Split2 + 1 && daysAge <= ObjEntityRequest.Split3)
                {
                    sum4 = Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["BALNC_AMT"].ToString());
                }
                else if (daysAge > ObjEntityRequest.Split3)
                {
                    sum5 = Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["BALNC_AMT"].ToString());
                }
                invAmnt += Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["INVOICE_AMT"].ToString());
                PaidAmnt += Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["PAID_AMT"].ToString());
                sum_return += Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["SALES_RETURN_AMNT"].ToString());

                Netsum1 += sum1;
                Netsum2 += sum2;
                Netsum3 += sum3;
                Netsum4 += sum4;
                Netsum5 += sum5;

                string strsum1 = "", strsum2 = "", strsum3 = "", strsum4 = "", strsum5 = "";
                if (sum1 == 0)
                {
                    strsum1 = String.Format(format, sum1);
                }
                else
                {
                    strsum1 = objBusiness.AddCommasForNumberSeperation(sum1.ToString(), objEntityCommon);
                }
                if (sum2 == 0)
                {
                    strsum2 = String.Format(format, sum2);
                }
                else
                {
                    strsum2 = objBusiness.AddCommasForNumberSeperation(sum2.ToString(), objEntityCommon);
                }
                if (sum3 == 0)
                {
                    strsum3 = String.Format(format, sum3);
                }
                else
                {
                    strsum3 = objBusiness.AddCommasForNumberSeperation(sum3.ToString(), objEntityCommon);
                }
                if (sum4 == 0)
                {
                    strsum4 = String.Format(format, sum4);
                }
                else
                {
                    strsum4 = objBusiness.AddCommasForNumberSeperation(sum4.ToString(), objEntityCommon);
                }
                if (sum5 == 0)
                {
                    strsum5 = String.Format(format, sum5);
                }
                else
                {
                    strsum5 = objBusiness.AddCommasForNumberSeperation(sum5.ToString(), objEntityCommon);
                }
                table.Rows.Add('"' + dtCategory.Rows[intRowBodyCount]["PURCHS_REF"].ToString() + '"', '"' + dtCategory.Rows[intRowBodyCount]["PURCHS_DATE"].ToString() + '"', '"' + objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["INVOICE_AMT"].ToString(), objEntityCommon) + '"', '"' + objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["PAID_AMT"].ToString(), objEntityCommon) + '"','"' + objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["SALES_RETURN_AMNT"].ToString(), objEntityCommon) + '"', '"' + strsum1 + '"', '"' + strsum2 + '"', '"' + strsum3 + '"', '"' + strsum4 + '"', '"' + strsum5 + '"');

            }
            if (dtCategory.Rows.Count > 0)
            {
                string strsum1 = "", strsum2 = "", strsum3 = "", strsum4 = "", strsum5 = "", strsumInv = "", strsumPaid = "", strsumReturn = "";
                if (invAmnt == 0)
                {
                    strsumInv = String.Format(format, invAmnt);
                }
                else
                {
                    strsumInv = objBusiness.AddCommasForNumberSeperation(invAmnt.ToString(), objEntityCommon);
                }
                if (PaidAmnt == 0)
                {
                    strsumPaid = String.Format(format, PaidAmnt);
                }
                else
                {
                    strsumPaid = objBusiness.AddCommasForNumberSeperation(PaidAmnt.ToString(), objEntityCommon);
                }

                if (dtForOB.Rows.Count > 0 && dtForOB.Rows[0]["VOCHR_OB"].ToString() != "")
                {
                    Netsum1 = Netsum1 + Convert.ToDecimal(dtForOB.Rows[0]["VOCHR_OB"].ToString());
                }

                if (Netsum1 == 0)
                {
                    strsum1 = String.Format(format, Netsum1);
                }
                else
                {
                    strsum1 = objBusiness.AddCommasForNumberSeperation(Netsum1.ToString(), objEntityCommon);
                }
                if (Netsum2 == 0)
                {
                    strsum2 = String.Format(format, Netsum2);
                }
                else
                {
                    strsum2 = objBusiness.AddCommasForNumberSeperation(Netsum2.ToString(), objEntityCommon);
                }
                if (Netsum3 == 0)
                {
                    strsum3 = String.Format(format, Netsum3);
                }
                else
                {
                    strsum3 = objBusiness.AddCommasForNumberSeperation(Netsum3.ToString(), objEntityCommon);
                }
                if (Netsum4 == 0)
                {
                    strsum4 = String.Format(format, Netsum4);
                }
                else
                {
                    strsum4 = objBusiness.AddCommasForNumberSeperation(Netsum4.ToString(), objEntityCommon);
                }

                if (Netsum5 == 0)
                {
                    strsum5 = String.Format(format, Netsum5);
                }
                else
                {
                    strsum5 = objBusiness.AddCommasForNumberSeperation(Netsum5.ToString(), objEntityCommon);
                }
                if (sum_return == 0)
                {
                    strsumReturn = String.Format(format, sum_return);
                }
                else
                {
                    strsumReturn = objBusiness.AddCommasForNumberSeperation(sum_return.ToString(), objEntityCommon);
                }

                table.Rows.Add("TOTAL", '"' + FORNULL + '"', '"' + strsumInv + '"', '"' + strsumPaid + '"', '"' + strsumReturn + '"',  '"' + strsum2 + '"', '"' + strsum3 + '"', '"' + strsum4 + '"', '"' + strsum5 + '"');
            }
        }
        catch (Exception)
        {
        }
        return table;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        clsEntityOutstandingAgeing ObjEntityRequest = new clsEntityOutstandingAgeing();
        clsBusinessOutstandingAgeing objBussiness = new clsBusinessOutstandingAgeing();
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityRequest.User_Id = intUserId;
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            ObjEntityRequest.Corporate_id = intCorpId;
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            ObjEntityRequest.Organisation_id = intOrgId;
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (txtTodate.Value != "")
        {
            ObjEntityRequest.ToDate = ObjCommonlib.textToDateTime(txtTodate.Value);
        }
        ObjEntityRequest.FinYearFromDate = ObjCommonlib.textToDateTime(HiddenFinancialYearFrom.Value);
        ObjEntityRequest.FinYearToDate = ObjCommonlib.textToDateTime(HiddenFinancialYearTo.Value);
        ObjEntityRequest.Mode = Convert.ToInt32(ddlMode.SelectedItem.Value);
        if (radioCredit.Checked == true)
        {
            ObjEntityRequest.Mode = 3;
        }
        if (ObjEntityRequest.Mode == 1 && radioIndividual.Checked == true)
        {
            ObjEntityRequest.Mode = 2;
        }
       
         
        if (ObjEntityRequest.Mode == 0)
        {
            if (txtFromAgeing.Value.Trim() != "")
            {
                ObjEntityRequest.FromAgeing = Convert.ToInt32(txtFromAgeing.Value.Trim());
            }
            if (txtToAgeing.Value.Trim() != "")
            {
                ObjEntityRequest.ToAgeing = Convert.ToInt32(txtToAgeing.Value.Trim());
            }
        }
        else
        {
            if (txtSplit1.Value.Trim() != "")
            {
                ObjEntityRequest.Split1 = Convert.ToInt32(txtSplit1.Value.Trim());
            }
            if (txtSplit2.Value.Trim() != "")
            {
                ObjEntityRequest.Split2 = Convert.ToInt32(txtSplit2.Value.Trim());
            }
            if (txtSplit3.Value.Trim() != "")
            {
                ObjEntityRequest.Split3 = Convert.ToInt32(txtSplit3.Value.Trim());
            }
        }
        HiddenFieldSearchDate.Value = txtTodate.Value;//evm 0044
        DataTable dtCategory = new DataTable();
        dtCategory = objBussiness.Ageing_List_Supplier(ObjEntityRequest);
        if (radioCredit.Checked == true)
        {
            dtCategory = objBussiness.Ageing_List_SupplierCrdtPrd (ObjEntityRequest);
            string Printsts = "0";
            divList.InnerHtml = LoadConvertToTableCreditPeriod(dtCategory, ObjEntityRequest, Printsts);
            Printsts = "1";
        }
        else if (ObjEntityRequest.Mode < 2)
        {
            string Printsts = "0";
            divList.InnerHtml = LoadConvertToTable(dtCategory, ObjEntityRequest, Printsts);
            Printsts = "1";
            //divPrintReport.InnerHtml = LoadConvertToTable(dtCategory, ObjEntityRequest, Printsts);
            //divPrintCaption.InnerHtml = PrintCaption(ObjEntityRequest, "");
        }
        else
        {
            string Printsts = "0";
            divList.InnerHtml = LoadConvertToTableIndvl(dtCategory, ObjEntityRequest, Printsts);
            Printsts = "1";
            //divPrintReport.InnerHtml = LoadConvertToTableIndvl(dtCategory, ObjEntityRequest, Printsts);
            //divPrintCaption.InnerHtml = PrintCaption(ObjEntityRequest, "");
        }
     
    }

    //method2 individual list
    public string LoadConvertToTableIndvl(DataTable dtCategory, clsEntityOutstandingAgeing ObjEntityRequest, string Printsts)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = ObjEntityRequest.Corporate_id, intOrgId = 0, intUserId = 0;
        int Decimalcount = 0;
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                    clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                    clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                    clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                    };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }
        string format = String.Format("{{0:N{0}}}", Decimalcount);
        int intCount = 0;
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        string strHtml = "";
        if (Printsts == "0")
        {
            strHtml = "<table id=\"datatable_fixed_column\" class=\"table-bordered display\" width=\"100%\" >";
            //add header row
            strHtml += "<thead class=\"thead1\">";
            strHtml += "<tr>";
            //strHtml += "<th class=\"hasinput\" style=\"text-align:left;width:5%;\">SL NO ";
            //strHtml += "</th >";
            strHtml += "<th class=\"col-md-3 td1 tr_l\" >SUPPLIER NAME ";
            strHtml += "<input class=\"tb_inp_1 tb_in tr_l\" placeholder=\"SUPPLIER NAME \"  type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-1 tr_r\" >TOTAL AMOUNT ";
            strHtml += "<input class=\"tb_inp_1 tb_in tr_r\" placeholder=\"TOTAL AMOUNT \"  type=\"text\">";
            strHtml += "</th >";
            //strHtml += "<th class=\"col-md-1 tr_r\" >NO DUE ";
            //strHtml += "<input class=\"tb_inp_1 tb_in tr_r\" placeholder=\"NO DUE\"  type=\"text\">";
            //strHtml += "</th >";
            strHtml += "<th class=\"col-md-1 tr_c\" >0-" + ObjEntityRequest.Split1 + "";
            strHtml += "<input class=\"tb_inp_1 tb_in tr_c\" placeholder=\"0-" + ObjEntityRequest.Split1 + "\"  type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-1 tr_c \" >" + (ObjEntityRequest.Split1 + 1) + "-" + ObjEntityRequest.Split2 + "";
            strHtml += "<input class=\"tb_inp_1 tb_in tr_c\" placeholder=\"" + (ObjEntityRequest.Split1 + 1) + " - " + ObjEntityRequest.Split2 + "\"  type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-1 tr_c\" >" + (ObjEntityRequest.Split2 + 1) + "-" + ObjEntityRequest.Split3 + "";
            strHtml += "<input class=\"tb_inp_1 tb_in tr_c\" placeholder=\"" + (ObjEntityRequest.Split2 + 1) + " - " + ObjEntityRequest.Split3 + "\" type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-1 tr_c\" >>" + ObjEntityRequest.Split3 + "";
            strHtml += "<input class=\"tb_inp_1 tb_in tr_c\" placeholder=\">" + ObjEntityRequest.Split3 + "\"  type=\"text\">";
            strHtml += "</th >";
            strHtml += "</tr>";
            strHtml += "</thead>";
        }
        else
        {

            strHtml = "<table id=\"PrintTable\" class=\"tab\" \">";
            //add header row
            strHtml += "<thead>";
            strHtml += "<tr class=\"top_row\">";
            //  strHtml += "<th class=\"thT\" style=\"width:5%;text-align:left;\">SL NO";
            //strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:28%;text-align:left;\">SUPPLIER NAME ";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:12%;text-align:right;\">TOTAL AMOUNT ";
            strHtml += "</th >";
            //strHtml += "<th class=\"thT\" style=\"width:12%;text-align:right;\">NO DUE";
            //strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:12%;text-align:right;\">0-" + ObjEntityRequest.Split1 + "";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:12%;text-align:right;\">" + (ObjEntityRequest.Split1 + 1) + "-" + ObjEntityRequest.Split2 + "";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:12%;text-align:right;\">" + (ObjEntityRequest.Split2 + 1) + "-" + ObjEntityRequest.Split3 + "";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:12%;text-align:right;\">>" + ObjEntityRequest.Split3 + "";
            strHtml += "</th >";
            strHtml += "</tr>";
            strHtml += "</thead>";
        }
        //add rows
        DataView view = new DataView(dtCategory);
        DataTable dtCategory1 = view.ToTable(true, "CSTMR_ID", "CSTMR_NAME");
        strHtml += "<tbody>";
        int COUNT = 0;
        decimal Netsum1 = 0, Netsum2 = 0, Netsum3 = 0, Netsum4 = 0, Netsum5 = 0, TotNetSum = 0;

        clsBusinessOutstandingAgeing objBussiness = new clsBusinessOutstandingAgeing();
        DataTable dtForOB = objBussiness.ReadOepningBalById(ObjEntityRequest);
        if (dtForOB.Rows.Count > 0)
        {
            strHtml += "<tr class=\"tr1\"><td class=\"tr_l\">OPENING BALANCE</td><td></td><td></td><td class=\"tr_r\" >" + objBusiness.AddCommasForNumberSeperation(dtForOB.Rows[0]["VOCHR_OB"].ToString(), objEntityCommon) + "</td><td></td>";
            strHtml += "</tr>";
        }


        for (int intRowBodyCount = 0; intRowBodyCount < dtCategory1.Rows.Count; intRowBodyCount++)
        {
            clsBusinessOutstandingAgeing objBussinessAging = new clsBusinessOutstandingAgeing();
            clsEntityOutstandingAgeing ObjEntityRequest1 = new clsEntityOutstandingAgeing();

            string strId = dtCategory1.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dtCategory1.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            COUNT++;

            ObjEntityRequest1.Organisation_id = ObjEntityRequest.Organisation_id;
            ObjEntityRequest1.Corporate_id = ObjEntityRequest.Corporate_id;
            ObjEntityRequest1.CustomerId = Convert.ToInt32(strId);

            decimal sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0, sum5 = 0, totSum = 0;
            DataRow[] result = dtCategory.Select("CSTMR_ID ='" + dtCategory1.Rows[intRowBodyCount]["CSTMR_ID"].ToString() + "'");
            foreach (DataRow row in result)
            {
                int daysAge = Convert.ToInt32(row["DAYS"].ToString());
                //if (daysAge == 0)
                //{
                //    sum1 += Convert.ToDecimal(row["BALNC_AMT"].ToString());
                //}
               // else
                if (daysAge >= 0 && daysAge <= ObjEntityRequest.Split1)
                {
                    sum2 += Convert.ToDecimal(row["BALNC_AMT"].ToString());
                }
                else if (daysAge >= ObjEntityRequest.Split1 + 1 && daysAge <= ObjEntityRequest.Split2)
                {
                    sum3 += Convert.ToDecimal(row["BALNC_AMT"].ToString());
                }
                else if (daysAge >= ObjEntityRequest.Split2 + 1 && daysAge <= ObjEntityRequest.Split3)
                {
                    sum4 += Convert.ToDecimal(row["BALNC_AMT"].ToString());
                }
                else if (daysAge > ObjEntityRequest.Split3)
                {
                    sum5 += Convert.ToDecimal(row["BALNC_AMT"].ToString());
                }
            }
            totSum = sum1 + sum2 + sum3 + sum4 + sum5;
            TotNetSum += totSum;

            Netsum1 += sum1;
            Netsum2 += sum2;
            Netsum3 += sum3;
            Netsum4 += sum4;

            if (dtForOB.Rows.Count > 0 && dtForOB.Rows[0]["VOCHR_OB"].ToString() != "")
            {
                Netsum5 = Netsum5 + Convert.ToDecimal(dtForOB.Rows[0]["VOCHR_OB"].ToString());
            }

            Netsum5 += sum5;


            string strsum1 = "", strsum2 = "", strsum3 = "", strsum4 = "", strsum5 = "", strTotsum = "";
            if (totSum == 0)
            {
                strTotsum = String.Format(format, totSum);
            }
            else
            {
                strTotsum = objBusiness.AddCommasForNumberSeperation(totSum.ToString(), objEntityCommon);
            }
            if (sum1 == 0)
            {
                strsum1 = String.Format(format, sum1);
            }
            else
            {
                strsum1 = objBusiness.AddCommasForNumberSeperation(sum1.ToString(), objEntityCommon);
            }
            if (sum2 == 0)
            {
                strsum2 = String.Format(format, sum2);
            }
            else
            {
                strsum2 = objBusiness.AddCommasForNumberSeperation(sum2.ToString(), objEntityCommon);
            }
            if (sum3 == 0)
            {
                strsum3 = String.Format(format, sum3);
            }
            else
            {
                strsum3 = objBusiness.AddCommasForNumberSeperation(sum3.ToString(), objEntityCommon);
            }
            if (sum4 == 0)
            {
                strsum4 = String.Format(format, sum4);
            }
            else
            {
                strsum4 = objBusiness.AddCommasForNumberSeperation(sum4.ToString(), objEntityCommon);
            }

            if (sum5 == 0)
            {
                strsum5 = String.Format(format, sum5);
            }
            else
            {
                strsum5 = objBusiness.AddCommasForNumberSeperation(sum5.ToString(), objEntityCommon);
            }

            strHtml += "<tr>";
            strHtml += "<td class=\"tr_l\">" + dtCategory1.Rows[intRowBodyCount]["CSTMR_NAME"].ToString() + "";
            DataTable dt = objBussinessAging.ReadPendingPayments(ObjEntityRequest1);//pending paymnts
            if (dt.Rows.Count > 0)
            {
                strHtml += "<span href=\"javascript:;\" class=\"pull-right spn_rc pst_dt_bx\" title=\"Pending Payment Details\" onclick=\"return PendingReceiptsDisplay('" + Id + "');\" data-toggle=\"modal\" data-target=\"#ModalPendingReceipt\" > <i class=\"fa fa-clipboard\"></i></span>";
            }
            //postdated chq
            DataTable dtPostDate = objBussinessAging.ReadPostdatedChqDtls(ObjEntityRequest1);
            if (dtPostDate.Rows.Count > 0)
            {
                strHtml += "<span href=\"javascript:;\" class=\"pst_dt_bx pull-right\" title=\"Postdated Cheque\" onclick=\"return PostdatedChqDisplay('" + Id + "');\" data-toggle=\"modal\" data-target=\"#divPostdatedChq\" ><i class=\"fa fa-list-alt ad_fa ad_posd pa_fa\"></i></span>";
            }

            string CustomerName = dtCategory1.Rows[intRowBodyCount]["CSTMR_NAME"].ToString();
            if (CustomerName.Contains("\"") == true)
            {
                CustomerName = CustomerName.Replace("\"", "‡");
            }
            if (CustomerName.Contains("\'") == true)
            {
                CustomerName = CustomerName.Replace("\'", "¦");
            }

            strHtml += "</td>";
            strHtml += "<td class=\"tr_r\"  style=\"text-align:right !important;\">" + strTotsum + "</td>";
            //strHtml += "<td class=\"tr_r\" style=\"text-align:right !important;\"><a  title=\"View\"  onclick=\"return OpenReconView('" + Id + "','" + CustomerName + "','" + ObjEntityRequest.Mode + "','" + ObjEntityRequest.FromAgeing + "','" + -1 + "','" + ObjEntityRequest.Split1 + "','" + ObjEntityRequest.Split2 + "','" + ObjEntityRequest.Split3 + "');\" href=\"javascript:;\">" + strsum1 + "</td>";
            strHtml += "<td class=\"tr_r\"  style=\"text-align:right !important;\"><a  title=\"View\"  onclick=\"return OpenReconView('" + Id + "','" + CustomerName + "','" + ObjEntityRequest.Mode + "','" + 0 + "','" + ObjEntityRequest.Split1 + "','" + ObjEntityRequest.Split1 + "','" + ObjEntityRequest.Split2 + "','" + ObjEntityRequest.Split3 + "');\" href=\"javascript:;\">" + strsum2 + "</td>";
            strHtml += "<td class=\"tr_r\" style=\"text-align:right !important;\" ><a  title=\"View\"  onclick=\"return OpenReconView('" + Id + "','" + CustomerName + "','" + ObjEntityRequest.Mode + "','" + (ObjEntityRequest.Split1 + 1) + "','" + ObjEntityRequest.Split2 + "','" + ObjEntityRequest.Split1 + "','" + ObjEntityRequest.Split2 + "','" + ObjEntityRequest.Split3 + "');\" href=\"javascript:;\">" + strsum3 + "</td>";
            strHtml += "<td class=\"tr_r\" style=\"text-align:right !important;\" ><a  title=\"View\"  onclick=\"return OpenReconView('" + Id + "','" + CustomerName + "','" + ObjEntityRequest.Mode + "','" + (ObjEntityRequest.Split2 + 1) + "','" + ObjEntityRequest.Split3 + "','" + ObjEntityRequest.Split1 + "','" + ObjEntityRequest.Split2 + "','" + ObjEntityRequest.Split3 + "');\" href=\"javascript:;\">" + strsum4 + "</td>";
            strHtml += "<td class=\"tr_r\" style=\"text-align:right !important;\" ><a  title=\"View\"  onclick=\"return OpenReconView('" + Id + "','" + CustomerName + "','" + ObjEntityRequest.Mode + "','" + (ObjEntityRequest.Split3 + 1) + "','" + ObjEntityRequest.ToAgeing + "','" + ObjEntityRequest.Split1 + "','" + ObjEntityRequest.Split2 + "','" + ObjEntityRequest.Split3 + "');\" href=\"javascript:;\">" + strsum5 + "</td>";
            strHtml += "</tr>";
        }
        strHtml += "</tbody>";


        if (dtCategory1.Rows.Count > 0)
        {

            string strsum1 = "", strsum2 = "", strsum3 = "", strsum4 = "", strsum5 = "", strTotsum = "";
            if (TotNetSum == 0)
            {
                strTotsum = String.Format(format, TotNetSum);
            }
            else
            {
                strTotsum = objBusiness.AddCommasForNumberSeperation(TotNetSum.ToString(), objEntityCommon);
            }
            if (Netsum1 == 0)
            {
                strsum1 = String.Format(format, Netsum1);
            }
            else
            {
                strsum1 = objBusiness.AddCommasForNumberSeperation(Netsum1.ToString(), objEntityCommon);
            }
            if (Netsum2 == 0)
            {
                strsum2 = String.Format(format, Netsum2);
            }
            else
            {
                strsum2 = objBusiness.AddCommasForNumberSeperation(Netsum2.ToString(), objEntityCommon);
            }
            if (Netsum3 == 0)
            {
                strsum3 = String.Format(format, Netsum3);
            }
            else
            {
                strsum3 = objBusiness.AddCommasForNumberSeperation(Netsum3.ToString(), objEntityCommon);
            }
            if (Netsum4 == 0)
            {
                strsum4 = String.Format(format, Netsum4);
            }
            else
            {
                strsum4 = objBusiness.AddCommasForNumberSeperation(Netsum4.ToString(), objEntityCommon);
            }
            if (Netsum5 == 0)
            {
                strsum5 = String.Format(format, Netsum5);
            }
            else
            {
                strsum5 = objBusiness.AddCommasForNumberSeperation(Netsum5.ToString(), objEntityCommon);
            }

            strHtml += " <tfoot> <tr class=\"tr1\">";
            strHtml += "<th class=\"tr_r txt_rd bg1\" style=\"text-align:left !important;\">TOTAL </td>";
            strHtml += "<th class=\"tr_r txt_rd bg1\" style=\"text-align:right;\"> " + strTotsum + "</th>";
            //strHtml += "<th class=\"tr_r txt_rd bg1\" style=\"text-align:right;\"> " + strsum1 + "</th>";
            strHtml += "<th class=\"tr_r txt_rd bg1\"  style=\"text-align:right;\"> " + strsum2 + "</th>";
            strHtml += "<th class=\"tr_r txt_rd bg1\" style=\"text-align:right;\"> " + strsum3 + "</th>";
            strHtml += "<th class=\"tr_r txt_rd bg1\" style=\"text-align:right;\"> " + strsum4 + "</th>";
            strHtml += "<th class=\"tr_r txt_rd bg1\" style=\"text-align:right;\"> " + strsum5 + "</th>";
            strHtml += "</tr></tfoot>";
        }
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    public string LoadConvertToTableIndvl_PDF(DataTable dtCategory, clsEntityOutstandingAgeing ObjEntityRequest, string Printsts,string intdateto,string mode,string AgeingFrom,string AgeingTo,string Split1,string Split2,string Split3)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = ObjEntityRequest.Corporate_id, intOrgId = 0, intUserId = 0;
        int Decimalcount = 0;
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                    clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                    clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                    clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                    };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }
        string format = String.Format("{{0:N{0}}}", Decimalcount);
        int intCount = 0;
        string strRandom = objCommon.Random_Number();
        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.SUPPLIER_OUTSTANDING_AGING_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SUPPLIER_OUTSTANDING_AGING_PDF);
        objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "SupAgeingIndivList_" + strNextNumber + ".pdf";

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

                footrtable.AddCell(new PdfPCell(new Phrase("DATE     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(intdateto, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (mode == "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("MODE   ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    if (AgeingFrom != "" && AgeingTo != "")
                    {
                        footrtable.AddCell(new PdfPCell(new Phrase("METHOD 1", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase("AGEING   ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase(AgeingFrom + " - " + AgeingTo, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                    }
                    else
                    {
                        footrtable.AddCell(new PdfPCell(new Phrase("METHOD 1", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                    }
                }
                else
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("MODE ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase("METHOD 2 - Individual", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    if (Split1 != "" && Split2 != "" && Split3 != "")
                    {
                        footrtable.AddCell(new PdfPCell(new Phrase("AGEING   ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        footrtable.AddCell(new PdfPCell(new Phrase(Split1 + " - " + Split2 + " - " + Split3, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                    }
                }
                document.Add(footrtable);

                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(6);
                float[] footrsBody = { 20, 15, 18,18,17,14};
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;//get header column in all pages

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("SUPPLIER NAME", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("TOTAL AMOUNT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                //TBCustomer.AddCell(new PdfPCell(new Phrase("NO DUE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("0-" + ObjEntityRequest.Split1 + "", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase((ObjEntityRequest.Split1 + 1) + "-" + ObjEntityRequest.Split2 + "", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase((ObjEntityRequest.Split2 + 1) + "-" + ObjEntityRequest.Split3 + "", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase(">" + ObjEntityRequest.Split3 + "", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                //add rows
                DataView view = new DataView(dtCategory);
                DataTable dtCategory1 = view.ToTable(true, "CSTMR_ID", "CSTMR_NAME");
                int COUNT = 0;
                decimal Netsum1 = 0, Netsum2 = 0, Netsum3 = 0, Netsum4 = 0, Netsum5 = 0, TotNetSum = 0;

                clsBusinessOutstandingAgeing objBussiness = new clsBusinessOutstandingAgeing();
                DataTable dtForOB = objBussiness.ReadOepningBalById(ObjEntityRequest);
                if (dtForOB.Rows.Count > 0)
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase(">OPENING BALANCE", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    //TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(dtForOB.Rows[0]["VOCHR_OB"].ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                }


                for (int intRowBodyCount = 0; intRowBodyCount < dtCategory1.Rows.Count; intRowBodyCount++)
                {
                    clsBusinessOutstandingAgeing objBussinessAging = new clsBusinessOutstandingAgeing();
                    clsEntityOutstandingAgeing ObjEntityRequest1 = new clsEntityOutstandingAgeing();

                    string strId = dtCategory1.Rows[intRowBodyCount][0].ToString();
                    int intIdLength = dtCategory1.Rows[intRowBodyCount][0].ToString().Length;
                    string stridLength = intIdLength.ToString("00");
                    string Id = stridLength + strId + strRandom;
                    COUNT++;

                    ObjEntityRequest1.Corporate_id = ObjEntityRequest.Corporate_id;
                    ObjEntityRequest1.CustomerId = Convert.ToInt32(strId);

                    decimal sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0, sum5 = 0, totSum = 0;
                    DataRow[] result = dtCategory.Select("CSTMR_ID ='" + dtCategory1.Rows[intRowBodyCount]["CSTMR_ID"].ToString() + "'");
                    foreach (DataRow row in result)
                    {
                        int daysAge = Convert.ToInt32(row["DAYS"].ToString());
                        //if (daysAge == 0)
                        //{
                        //    sum1 += Convert.ToDecimal(row["BALNC_AMT"].ToString());
                        //}
                        //else 
                        if (daysAge >= 0 && daysAge <= ObjEntityRequest.Split1)
                        {
                            sum2 += Convert.ToDecimal(row["BALNC_AMT"].ToString());
                        }
                        else if (daysAge >= ObjEntityRequest.Split1 + 1 && daysAge <= ObjEntityRequest.Split2)
                        {
                            sum3 += Convert.ToDecimal(row["BALNC_AMT"].ToString());
                        }
                        else if (daysAge >= ObjEntityRequest.Split2 + 1 && daysAge <= ObjEntityRequest.Split3)
                        {
                            sum4 += Convert.ToDecimal(row["BALNC_AMT"].ToString());
                        }
                        else if (daysAge > ObjEntityRequest.Split3)
                        {
                            sum5 += Convert.ToDecimal(row["BALNC_AMT"].ToString());
                        }
                    }
                    totSum = sum1 + sum2 + sum3 + sum4 + sum5;
                    TotNetSum += totSum;

                    Netsum1 += sum1;
                    Netsum2 += sum2;
                    Netsum3 += sum3;
                    Netsum4 += sum4;

                    if (dtForOB.Rows.Count > 0 && dtForOB.Rows[0]["VOCHR_OB"].ToString() != "")
                    {
                        Netsum5 = Netsum5 + Convert.ToDecimal(dtForOB.Rows[0]["VOCHR_OB"].ToString());
                    }

                    Netsum5 += sum5;


                    string strsum1 = "", strsum2 = "", strsum3 = "", strsum4 = "", strsum5 = "", strTotsum = "";
                    if (totSum == 0)
                    {
                        strTotsum = String.Format(format, totSum);
                    }
                    else
                    {
                        strTotsum = objBusiness.AddCommasForNumberSeperation(totSum.ToString(), objEntityCommon);
                    }
                    if (sum1 == 0)
                    {
                        strsum1 = String.Format(format, sum1);
                    }
                    else
                    {
                        strsum1 = objBusiness.AddCommasForNumberSeperation(sum1.ToString(), objEntityCommon);
                    }
                    if (sum2 == 0)
                    {
                        strsum2 = String.Format(format, sum2);
                    }
                    else
                    {
                        strsum2 = objBusiness.AddCommasForNumberSeperation(sum2.ToString(), objEntityCommon);
                    }
                    if (sum3 == 0)
                    {
                        strsum3 = String.Format(format, sum3);
                    }
                    else
                    {
                        strsum3 = objBusiness.AddCommasForNumberSeperation(sum3.ToString(), objEntityCommon);
                    }
                    if (sum4 == 0)
                    {
                        strsum4 = String.Format(format, sum4);
                    }
                    else
                    {
                        strsum4 = objBusiness.AddCommasForNumberSeperation(sum4.ToString(), objEntityCommon);
                    }

                    if (sum5 == 0)
                    {
                        strsum5 = String.Format(format, sum5);
                    }
                    else
                    {
                        strsum5 = objBusiness.AddCommasForNumberSeperation(sum5.ToString(), objEntityCommon);
                    }
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory1.Rows[intRowBodyCount]["CSTMR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strTotsum, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    //TBCustomer.AddCell(new PdfPCell(new Phrase(strsum1, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strsum2, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strsum3, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strsum4, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strsum5, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                }
                if (dtCategory1.Rows.Count > 0)
                {

                    string strsum1 = "", strsum2 = "", strsum3 = "", strsum4 = "", strsum5 = "", strTotsum = "";
                    if (TotNetSum == 0)
                    {
                        strTotsum = String.Format(format, TotNetSum);
                    }
                    else
                    {
                        strTotsum = objBusiness.AddCommasForNumberSeperation(TotNetSum.ToString(), objEntityCommon);
                    }
                    if (Netsum1 == 0)
                    {
                        strsum1 = String.Format(format, Netsum1);
                    }
                    else
                    {
                        strsum1 = objBusiness.AddCommasForNumberSeperation(Netsum1.ToString(), objEntityCommon);
                    }
                    if (Netsum2 == 0)
                    {
                        strsum2 = String.Format(format, Netsum2);
                    }
                    else
                    {
                        strsum2 = objBusiness.AddCommasForNumberSeperation(Netsum2.ToString(), objEntityCommon);
                    }
                    if (Netsum3 == 0)
                    {
                        strsum3 = String.Format(format, Netsum3);
                    }
                    else
                    {
                        strsum3 = objBusiness.AddCommasForNumberSeperation(Netsum3.ToString(), objEntityCommon);
                    }
                    if (Netsum4 == 0)
                    {
                        strsum4 = String.Format(format, Netsum4);
                    }
                    else
                    {
                        strsum4 = objBusiness.AddCommasForNumberSeperation(Netsum4.ToString(), objEntityCommon);
                    }
                    if (Netsum5 == 0)
                    {
                        strsum5 = String.Format(format, Netsum5);
                    }
                    else
                    {
                        strsum5 = objBusiness.AddCommasForNumberSeperation(Netsum5.ToString(), objEntityCommon);
                    }
                    TBCustomer.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor =FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strTotsum, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    //TBCustomer.AddCell(new PdfPCell(new Phrase(strsum1, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strsum2, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strsum3, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strsum4, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strsum5, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
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
    public string LoadConvertToTableIndvl_CSV(DataTable dtCategory, clsEntityOutstandingAgeing ObjEntityRequest, string Printsts, string intdateto, string mode, string AgeingFrom, string AgeingTo, string Split1, string Split2, string Split3)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        DataTable dt = GetTable_2(dtCategory, ObjEntityRequest, intdateto, mode, AgeingFrom, AgeingTo, Split1, Split2, Split3);
        string strResult = DataTableToCSV(dt, ',');
        string strImagePath = "";
        string filepath = "";

        if (ObjEntityRequest.Corporate_id != 0)
        {
            objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        }
        if (ObjEntityRequest.Organisation_id != 0)
        {
            objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        }


        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SUPPLIER_OUTSTNDG_AGEING_CSV);
        string strNextId = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string newFilePath = Server.MapPath("/CustomFiles/FMS CSV/Supplier Outstanding Ageing/Supp_AgeingTableIndvl_" + strNextId + ".csv");
        System.IO.File.WriteAllText(newFilePath, strResult);
        filepath = "Supp_AgeingTableIndvl_" + strNextId + ".csv";
        strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.SUPPLIER_OUTSTNDG_AGEING_CSV);
        return strImagePath + filepath;
    }
    public DataTable GetTable_2(DataTable dtCategory, clsEntityOutstandingAgeing ObjEntityRequest, string intdateto, string mode, string AgeingFrom, string AgeingTo, string Split1, string Split2, string Split3)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = ObjEntityRequest.Corporate_id;
        int Decimalcount = 0;
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                    clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                    };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }
        string format = String.Format("{{0:N{0}}}", Decimalcount);
        string strRandom = objCommon.Random_Number();

        string FORNULL = "";
        DataTable table = new DataTable();
        try
        {
            table.Columns.Add("SUPPLIER OUTSTANDING AGEING REPORT", typeof(string));
            table.Columns.Add(" ", typeof(string));
            table.Columns.Add("  ", typeof(string));
            table.Columns.Add("   ", typeof(string));
            //table.Columns.Add("    ", typeof(string));
            table.Columns.Add("     ", typeof(string));
            table.Columns.Add("      ", typeof(string));

            table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
            table.Rows.Add("DATE : ", '"' + intdateto + '"', '"' + FORNULL + '"',  '"' + FORNULL + '"', '"' + FORNULL + '"');
            if (mode == "0")
            {
                table.Rows.Add("MODE : ", "METHOD 1", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
                if (AgeingFrom != "" && AgeingTo != "")
                {
                    table.Rows.Add("AGEING : ", '"' + AgeingFrom + " to " + AgeingTo + '"',  '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
                }
            }
            else
            {
                table.Rows.Add("MODE : ", "METHOD 2 - Individual", '"' + FORNULL + '"',  '"' + FORNULL + '"', '"' + FORNULL + '"');
                if (Split1 != "" && Split2 != "" && Split3 != "")
                {
                    table.Rows.Add("AGEING : ", '"' + Split1 + " to " + Split2 + " to " + Split3 + '"',  '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
                }
            }
            table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"',  '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

            string AgeingSec_1 = "0 to " + ObjEntityRequest.Split1 + "";
            string AgeingSec_2 = (ObjEntityRequest.Split1 + 1) + " to " + ObjEntityRequest.Split2 + "";
            string AgeingSec_3 = (ObjEntityRequest.Split2 + 1) + " to " + ObjEntityRequest.Split3 + "";
            string AgeingSec_4 = ">" + ObjEntityRequest.Split3 + "";

            //Head section
            table.Rows.Add("SUPPLIER NAME", "TOTAL AMOUNT",  '"' + AgeingSec_1 + '"', '"' + AgeingSec_2 + '"', '"' + AgeingSec_3 + '"', '"' + AgeingSec_4 + '"');

            ////add rows
            DataView view = new DataView(dtCategory);
            DataTable dtCategory1 = view.ToTable(true, "CSTMR_ID", "CSTMR_NAME");
            //strHtml += "<tbody>";
            int COUNT = 0;
            decimal Netsum1 = 0, Netsum2 = 0, Netsum3 = 0, Netsum4 = 0, Netsum5 = 0, TotNetSum = 0;
            clsBusinessOutstandingAgeing objBussiness = new clsBusinessOutstandingAgeing();
            DataTable dtForOB = objBussiness.ReadOepningBalById(ObjEntityRequest);
            if (dtForOB.Rows.Count > 0)
            {
                table.Rows.Add("OPENING BALANCE", '"' + FORNULL + '"',  '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + objBusiness.AddCommasForNumberSeperation(dtForOB.Rows[0]["VOCHR_OB"].ToString(), objEntityCommon) + '"', '"' + FORNULL + '"');
            }

            for (int intRowBodyCount = 0; intRowBodyCount < dtCategory1.Rows.Count; intRowBodyCount++)
            {
                clsBusinessOutstandingAgeing objBussinessAging = new clsBusinessOutstandingAgeing();
                clsEntityOutstandingAgeing ObjEntityRequest1 = new clsEntityOutstandingAgeing();
                string strId = dtCategory1.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dtCategory1.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                COUNT++;
                ObjEntityRequest1.Corporate_id = ObjEntityRequest.Corporate_id;
                ObjEntityRequest1.CustomerId = Convert.ToInt32(strId);
                decimal sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0, sum5 = 0, totSum = 0;
                DataRow[] result = dtCategory.Select("CSTMR_ID ='" + dtCategory1.Rows[intRowBodyCount]["CSTMR_ID"].ToString() + "'");
                foreach (DataRow row in result)
                {
                    int daysAge = Convert.ToInt32(row["DAYS"].ToString());
                    if (daysAge == 0)
                    {
                        sum1 += Convert.ToDecimal(row["BALNC_AMT"].ToString());
                    }
                    else if (daysAge >= 1 && daysAge <= ObjEntityRequest.Split1)
                    {
                        sum2 += Convert.ToDecimal(row["BALNC_AMT"].ToString());
                    }
                    else if (daysAge >= ObjEntityRequest.Split1 + 1 && daysAge <= ObjEntityRequest.Split2)
                    {
                        sum3 += Convert.ToDecimal(row["BALNC_AMT"].ToString());
                    }
                    else if (daysAge >= ObjEntityRequest.Split2 + 1 && daysAge <= ObjEntityRequest.Split3)
                    {
                        sum4 += Convert.ToDecimal(row["BALNC_AMT"].ToString());
                    }
                    else if (daysAge > ObjEntityRequest.Split3)
                    {
                        sum5 += Convert.ToDecimal(row["BALNC_AMT"].ToString());
                    }
                }
                totSum = sum1 + sum2 + sum3 + sum4 + sum5;
                TotNetSum += totSum;
                Netsum1 += sum1;
                Netsum2 += sum2;
                Netsum3 += sum3;
                Netsum4 += sum4;
                Netsum5 += sum5;
                string strsum1 = "", strsum2 = "", strsum3 = "", strsum4 = "", strsum5 = "", strTotsum = "";
                if (totSum == 0)
                {
                    strTotsum = String.Format(format, totSum);
                }
                else
                {
                    strTotsum = objBusiness.AddCommasForNumberSeperation(totSum.ToString(), objEntityCommon);
                }
                if (sum1 == 0)
                {
                    strsum1 = String.Format(format, sum1);
                }
                else
                {
                    strsum1 = objBusiness.AddCommasForNumberSeperation(sum1.ToString(), objEntityCommon);
                }
                if (sum2 == 0)
                {
                    strsum2 = String.Format(format, sum2);
                }
                else
                {
                    strsum2 = objBusiness.AddCommasForNumberSeperation(sum2.ToString(), objEntityCommon);
                }
                if (sum3 == 0)
                {
                    strsum3 = String.Format(format, sum3);
                }
                else
                {
                    strsum3 = objBusiness.AddCommasForNumberSeperation(sum3.ToString(), objEntityCommon);
                }
                if (sum4 == 0)
                {
                    strsum4 = String.Format(format, sum4);
                }
                else
                {
                    strsum4 = objBusiness.AddCommasForNumberSeperation(sum4.ToString(), objEntityCommon);
                }
                if (sum5 == 0)
                {
                    strsum5 = String.Format(format, sum5);
                }
                else
                {
                    strsum5 = objBusiness.AddCommasForNumberSeperation(sum5.ToString(), objEntityCommon);
                }
                table.Rows.Add('"' + dtCategory1.Rows[intRowBodyCount]["CSTMR_NAME"].ToString() + '"', '"' + strTotsum + '"', '"' + strsum1 + '"', '"' + strsum2 + '"', '"' + strsum3 + '"', '"' + strsum4 + '"', '"' + strsum5 + '"');
            }

            if (dtCategory1.Rows.Count > 0)
            {
                string strsum1 = "", strsum2 = "", strsum3 = "", strsum4 = "", strsum5 = "", strTotsum = "";
                if (TotNetSum == 0)
                {
                    strTotsum = String.Format(format, TotNetSum);
                }
                else
                {
                    strTotsum = objBusiness.AddCommasForNumberSeperation(TotNetSum.ToString(), objEntityCommon);
                }
                if (Netsum1 == 0)
                {
                    strsum1 = String.Format(format, Netsum1);
                }
                else
                {
                    strsum1 = objBusiness.AddCommasForNumberSeperation(Netsum1.ToString(), objEntityCommon);
                }
                if (Netsum2 == 0)
                {
                    strsum2 = String.Format(format, Netsum2);
                }
                else
                {
                    strsum2 = objBusiness.AddCommasForNumberSeperation(Netsum2.ToString(), objEntityCommon);
                }
                if (Netsum3 == 0)
                {
                    strsum3 = String.Format(format, Netsum3);
                }
                else
                {
                    strsum3 = objBusiness.AddCommasForNumberSeperation(Netsum3.ToString(), objEntityCommon);
                }
                if (Netsum4 == 0)
                {
                    strsum4 = String.Format(format, Netsum4);
                }
                else
                {
                    strsum4 = objBusiness.AddCommasForNumberSeperation(Netsum4.ToString(), objEntityCommon);
                }

                if (dtForOB.Rows.Count > 0 && dtForOB.Rows[0]["VOCHR_OB"].ToString() != "")
                {
                    Netsum5 = Netsum5 + Convert.ToDecimal(dtForOB.Rows[0]["VOCHR_OB"].ToString());
                }

                if (Netsum5 == 0)
                {
                    strsum5 = String.Format(format, Netsum5);
                }
                else
                {
                    strsum5 = objBusiness.AddCommasForNumberSeperation(Netsum5.ToString(), objEntityCommon);
                }
                table.Rows.Add("TOTAL", '"' + strTotsum + '"',  '"' + strsum2 + '"', '"' + strsum3 + '"', '"' + strsum4 + '"', '"' + strsum5 + '"');
            }
        }
        catch (Exception)
        {
        }
        return table;
    }


    [WebMethod]
    public static string LoadPendingReceipts(string OrgId, string CorpId, string LdgrId)
    {
        clsBusinessOutstandingAgeing objBussinessAging = new clsBusinessOutstandingAgeing();
        clsEntityOutstandingAgeing ObjEntityRequest1 = new clsEntityOutstandingAgeing();

        string strRandomMixedId = LdgrId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        ObjEntityRequest1.Corporate_id = Convert.ToInt32(CorpId);
        ObjEntityRequest1.CustomerId = Convert.ToInt32(strId);
        DataTable dt = objBussinessAging.ReadPendingPayments(ObjEntityRequest1);//pending payments

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        StringBuilder sbPop = new StringBuilder();
        if (dt.Rows.Count > 0)
        {
            sbPop.Append("<thead class=\"thead1\">");
            sbPop.Append("<tr >");

            sbPop.Append("<th class=\"col-md-5 tr_l\">REF#");
            sbPop.Append("</th >");
            sbPop.Append("<th class=\"col-md-3\">Date");
            sbPop.Append("</th >");
            sbPop.Append("<th class=\"col-md-3 tr_r\" >Amount");
            sbPop.Append("</th >");
            sbPop.Append("</tr>");
            sbPop.Append("</thead>");
            //add rows
            sbPop.Append("<tbody>");

            decimal decTotal = 0;

            for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
            {
                string strRcptId = dt.Rows[intCount]["PAYMNT_ID"].ToString();
                int intIdLength = dt.Rows[intCount]["PAYMNT_ID"].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strRcptId + strRandom;

                sbPop.Append("<tr>");
                sbPop.Append("<td class=\"tr_l\" ><a href=\"/FMS/FMS_Master/fms_Payment_Account/fms_Payment_Account.aspx?ViewId=" + Id + "&VId=1\" >" + dt.Rows[intCount]["PAYMNT_REF"].ToString() + "</a></td>");
                sbPop.Append("<td class=\"tr_c\" >" + dt.Rows[intCount]["PAYMNT_DATE"].ToString() + "</td>");
                sbPop.Append("<td class=\"tr_r\" >" + dt.Rows[intCount]["PAYMNT_LD_AMT"].ToString() + "</td>");
                sbPop.Append("</tr>");

                decTotal = decTotal + Convert.ToDecimal(dt.Rows[intCount]["PAYMNT_LD_AMT"].ToString());
            }

            sbPop.Append("<tr class=\"tr1 brd1\">");
            sbPop.Append("<td colspan=\"2\" class=\"tr_r ft_bld\">Total</td>");
            sbPop.Append("<td class=\"tr_r txt_blu\">" + decTotal + "</td>");
            sbPop.Append("</tr>");

            sbPop.Append("</tbody>");
        }
        return sbPop.ToString();
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
            headtable.AddCell(new PdfPCell(new Phrase("SUPPLIER OUTSTANDING AGEING REPORT ", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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

    [WebMethod]
    public static string LoadPostdatedChqDtls(string OrgId, string CorpId, string LdgrId)
    {
        clsBusinessOutstandingAgeing objBussinessAging = new clsBusinessOutstandingAgeing();
        clsEntityOutstandingAgeing ObjEntityRequest1 = new clsEntityOutstandingAgeing();

        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        ObjEntityRequest1.Organisation_id = Convert.ToInt32(OrgId);
        ObjEntityRequest1.Corporate_id = Convert.ToInt32(CorpId);

        string strRandomMixedId = LdgrId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        ObjEntityRequest1.CustomerId = Convert.ToInt32(strId);
        DataTable dtPostDate = objBussinessAging.ReadPostdatedChqDtls(ObjEntityRequest1);//Postdated chq

        StringBuilder sbPop = new StringBuilder();

        sbPop.Append("<thead class=\"thead1\">");
        sbPop.Append("<tr>");
        sbPop.Append("<th class=\"col-md-2 td1 tr_l\">Ref#</th>");
        sbPop.Append("<th class=\"col-md-3 tr_l\">Bank</th>");
        sbPop.Append("<th class=\"col-md-1 tr_l\">Cheque#</th>");
        sbPop.Append("<th class=\"col-md-2\">Cheque Date</th>");
        sbPop.Append("<th class=\"col-md-2 tr_r\">Amount</th>");
        sbPop.Append("<th class=\"col-md-2\">Status</th>");
        sbPop.Append("</tr>");
        sbPop.Append("</thead>");

        sbPop.Append("<tbody>");

        for (int intRow = 0; intRow < dtPostDate.Rows.Count; intRow++)
        {
            sbPop.Append("<tr>");
            sbPop.Append("<td class=\"tr_l\">" + dtPostDate.Rows[intRow]["PST_CHEQUE_REF"].ToString() + "</td>");
            sbPop.Append("<td class=\"tr_l\">" + dtPostDate.Rows[intRow]["LDGR_NAME"].ToString() + "</td>");
            sbPop.Append("<td class=\"tr_l\">" + dtPostDate.Rows[intRow]["CHQ_DTLS_NUMBER"].ToString() + "</td>");
            sbPop.Append("<td class=\"tr_c\">" + dtPostDate.Rows[intRow]["CHQ_DTLS_CHQ_DATE"].ToString() + "</td>");

            string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(dtPostDate.Rows[intRow]["CHQ_DTLS_AMOUNT"].ToString(), objEntityCommon);

            sbPop.Append("<td class=\"tr_r\">" + strNetAmountWithComma + "</td>");
            sbPop.Append("<td>" + dtPostDate.Rows[intRow]["CHQ_DTLS_PAID_RJCT_STATUS"].ToString() + "</td>");
            sbPop.Append("</tr>");
        }

        sbPop.Append("</tbody>");

        return sbPop.ToString();
    }


}