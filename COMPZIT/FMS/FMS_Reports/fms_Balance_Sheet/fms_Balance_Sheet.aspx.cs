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

public partial class FMS_FMS_Reports_fms_Balance_Sheet_fms_Balance_Sheet : System.Web.UI.Page
{
    static int CountRow = 0;
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
            clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
            DateTime ToDate = ObjCommonlib.textToDateTime(strCurrentDate);

            clsEntityCommon objEntityCommon = new clsEntityCommon();


            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            clsEntityBalanceSheet ObjEntityRequest = new clsEntityBalanceSheet();
            clsBusinessBalanceSheet objBussiness = new clsBusinessBalanceSheet();
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
                // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

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
            DataTable dtfinaclYear = objBusinessLayer.ReadFinancialYearById(objEntityCommon);

            if (dtfinaclYear.Rows.Count > 0)
            {
                if (dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString() != "")
                {
                    HiddenFinancialYearTo.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                }
                if (dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString() != "")
                {
                    HiddenFinancialYearFrom.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                }
            }
            DateTime ToDateFin = ObjCommonlib.textToDateTime(HiddenFinancialYearTo.Value);

            if (ToDate >= ObjCommonlib.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && ToDate <= ObjCommonlib.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
            {
                txtTodate.Value = ToDate.ToString("dd-MM-yyyy");
                HiddenFieldNewToDate.Value = ToDate.ToString("dd-MM-yyyy");
            }
            else
            {
                txtTodate.Value = ToDateFin.ToString("dd-MM-yyyy");
                HiddenFieldNewToDate.Value = ToDateFin.ToString("dd-MM-yyyy");
            }

            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_TAX_ENABLED,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_INVENTORY_FOREX_STATUS
                                                              };

            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenDecimalCnt.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();

            }

            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessMsg", "SuccessMsg();", true);
                }
            }
            if (HiddenFinancialYearFrom.Value != "")
            {
                ObjEntityRequest.FromDate = ObjCommonlib.textToDateTime(HiddenFinancialYearFrom.Value);
            }
            if (txtTodate.Value != "")
            {
                ObjEntityRequest.ToDate = ObjCommonlib.textToDateTime(txtTodate.Value);
            }
            ObjEntityRequest.Status = 0;
            DataTable dtAsset = objBussiness.ReadPrimaryGroupDetails(ObjEntityRequest);
            ObjEntityRequest.Status = 1;
            DataTable dtLiability = objBussiness.ReadPrimaryGroupDetails(ObjEntityRequest);
            DataTable dtCategory = objBussiness.ReadProfitLoss(ObjEntityRequest);
            decimal sum_Cedt = 0, sum_debt = 0, NetAmount = 0;
            for (int grscnt = 0; grscnt < dtCategory.Rows.Count; grscnt++)
            {
                if (dtCategory.Rows[grscnt]["ACNT_NATURE_STS"].ToString() == "3")
                {
                    sum_debt += Convert.ToDecimal(dtCategory.Rows[grscnt]["TOTAL_DEB_AMNT"]);
                }
                else
                {
                    sum_Cedt += Convert.ToDecimal(dtCategory.Rows[grscnt]["TOTAL_CREDIT_AMNT"]);
                }
            }
            if (sum_Cedt > sum_debt)
            {
                //NetAmount = sum_Cedt - sum_debt;
                //strProfit = "Gross Profit";
            }
            else
            {
                //NetAmount = sum_debt - sum_Cedt;
                //strLoss = "Gross Loss";
            }

            string strId = "";
            string Printsts = "0";
            string TypSts = "0";
            string intAccntId = "0";
            divList.InnerHtml = LoadConvertToTable(dtAsset, dtLiability, ObjEntityRequest, strId, Printsts, TypSts, sum_Cedt, sum_debt, intAccntId);
            Printsts = "1";
            //     divPrintReport.InnerHtml = LoadConvertToTable(dtAsset, dtLiability, ObjEntityRequest, strId, Printsts, TypSts, sum_Cedt, sum_debt, intAccntId);
            //  divPrintCaption.InnerHtml = PrintCaption(ObjEntityRequest, strId);
        }

    }
    public string PrintCaption(clsEntityBalanceSheet ObjEntityRequest, string strId1)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();
        clsEntityReports objEntityReports = new clsEntityReports();
        objEntityReports.Corporate_Id = ObjEntityRequest.Corporate_id;
        objEntityReports.Organisation_Id = ObjEntityRequest.Organisation_id;
        objEntityReports.User_Id = ObjEntityRequest.User_Id;
        DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(objEntityReports);

        clsEntityCommon objEntityCommon = new clsEntityCommon();
        // objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "BALANCE SHEET";
        DateTime datetm = objBusiness.LoadCurrentDate();
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string usrName = "<B> Report Generated By: </B>" + Session["USERFULLNAME"];
        // string TotalRowCnt = "<B> Total Expired Bank Guarantee: </B>" + dt.Rows.Count;
        //for printing product division on print
        string strHidden = "", GuaranteDivsn = "", GuaranteCatgry = "", GuaranteBank = ""; ;


        GuaranteDivsn = "<B>FROM DATE  : </B>" + ObjEntityRequest.FromDate.ToString("dd-MMM-yyyy");

        GuaranteCatgry = "<B>DATE: </B>" + ObjEntityRequest.ToDate.ToString("dd-MMM-yyyy");





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

        //clsCommonLibrary objClsCommon = new clsCommonLibrary();
        //string strCompanyAddr = objClsCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);

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
        //if (GuaranteDivsn != "")
        //{
        //    strGuaranteDivsn = "<tr><td class=\"RprtDiv\">" + GuaranteDivsn + "</td></tr>";

        //}
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
        //if (TotalRowCnt != "")
        //{
        //    strTotalCount = "<tr><td class=\"RprtDiv\">" + TotalRowCnt + "</td></tr>";
        //}
        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strGuaranteDivsn + strGuaranteCatgry + strGuaranteBank + strUsrName + strCaptionTabTitle + strCaptionTabstop;

        sbCap.Append(strPrintCaptionTable);
        ////write to  divPrintCaption
        return sbCap.ToString();


    }
    
    [WebMethod]
    public static string TrailBalance_List_Print(string ShowZero, string intuserid, string intorgid, string intcorpid, string datefrom, string dateto, string strPrintMode)
    {
        string result = "";
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        clsEntityBalanceSheet ObjEntityRequest = new clsEntityBalanceSheet();
        clsBusinessBalanceSheet objBussiness = new clsBusinessBalanceSheet();
        FMS_FMS_Reports_fms_Balance_Sheet_fms_Balance_Sheet obj = new FMS_FMS_Reports_fms_Balance_Sheet_fms_Balance_Sheet();
        ObjEntityRequest.User_Id = Convert.ToInt32(intuserid);
        ObjEntityRequest.Corporate_id = Convert.ToInt32(intcorpid);
        ObjEntityRequest.Organisation_id = Convert.ToInt32(intorgid);
        ObjEntityRequest.ToDate = ObjCommonlib.textToDateTime(dateto);
        ObjEntityRequest.ShowZerosts = Convert.ToInt32(ShowZero);
        ObjEntityRequest.FromDate = ObjCommonlib.textToDateTime(datefrom);
        //HiddenFieldShowZero
        ObjEntityRequest.Status = 0;
        // ObjEntityRequest.ShowZerosts = 1;
        DataTable dtAsset = objBussiness.ReadPrimaryGroupDetails(ObjEntityRequest);
        ObjEntityRequest.Status = 1;
        DataTable dtLiability = objBussiness.ReadPrimaryGroupDetails(ObjEntityRequest);
        DataTable dtCategory = objBussiness.ReadProfitLoss(ObjEntityRequest);
        decimal sum_Cedt = 0, sum_debt = 0, NetAmount = 0;
        for (int grscnt = 0; grscnt < dtCategory.Rows.Count; grscnt++)
        {
            if (dtCategory.Rows[grscnt]["ACNT_NATURE_STS"].ToString() == "3")
            {
                sum_debt += Convert.ToDecimal(dtCategory.Rows[grscnt]["TOTAL_DEB_AMNT"]);
            }
            else
            {
                sum_Cedt += Convert.ToDecimal(dtCategory.Rows[grscnt]["TOTAL_CREDIT_AMNT"]);
            }
        }
        string strId = "";
        string Printsts = "0";
        string TypSts = "0";
        string intAccntId = "0";
        if (strPrintMode == "pdf")
        {
            result = obj.LoadConvertToTable_PDF(dtAsset, dtLiability, ObjEntityRequest, strId, Printsts, TypSts, sum_Cedt, sum_debt, intAccntId, dateto, ShowZero);
        }
        else if ((strPrintMode == "csv"))
        {
            result = obj.LoadConvertToTable_CSV(dtAsset, dtLiability, ObjEntityRequest, strId, Printsts, TypSts, sum_Cedt, sum_debt, intAccntId, dateto, ShowZero);
        }
        Printsts = "1";
        return result;
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
    
    //main table
    public string LoadConvertToTable(DataTable dtAsset, DataTable dtLiability, clsEntityBalanceSheet ObjEntityRequest, string strId1, string Printsts, string TypSts, Decimal credAmnt, Decimal debAmnt, string intAccntId)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            ObjEntityRequest.Corporate_id = intCorpId;
            objEntityCommon.CorporateID = intCorpId;
        }
        clsBusinessProfitAndLossAccount objBussiness = new clsBusinessProfitAndLossAccount();
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
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
        int RowCountTot = dtAsset.Rows.Count;
        if (RowCountTot < dtLiability.Rows.Count)
        {
            RowCountTot = dtLiability.Rows.Count;
        }
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        string strHtml = "";
        decimal decLiabilityTot = 0, decAssetTot = 0;
        if (Printsts == "0")
        {
            strHtml = "<table id=\"datatable_fixed_column0\" class=\" table-bordered\" width=\"100%\" >";
            strHtml += "<thead class=\"thead1\">";
            strHtml += "<tr >";
            strHtml += "<th class=\"col-md-6 pl_3 flt_n\" colspan=\"2\" >LIABILITIES</th>";
            strHtml += "<th class=\"col-md-6 pl_3 flt_n\" colspan=\"2\" >ASSETS</th>";
            strHtml += "</tr>";
            strHtml += "<tr>";
            strHtml += "<th class=\"col-md-4 tr_l\" >PARTICULARS";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md- tr_r\" > AMOUNT";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-4 tr_l\" >PARTICULARS";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-2 tr_r\" >AMOUNT ";
            strHtml += "</th >";
            strHtml += "</tr>";
            strHtml += "</thead>";
        }
        else
        {
            strHtml = "<table id=\"PrintTable\" class=\"tab\">";
            strHtml += "<thead>";
            strHtml += "<tr class=\"top_row\">";
            strHtml += "<th class=\"thT\" colspan=\"2\" style=\"width:50%;text-align:center;border-bottom: solid 1px #939191;\">LIABILITIES</th>";
            strHtml += "<th class=\"thT\" colspan=\"2\" style=\"width:50%;text-align:center;border-bottom: solid 1px #939191;\">ASSETS</th>";
            strHtml += "</tr>";
            strHtml += "<tr class=\"top_row\">";
            strHtml += "<th class=\"thT\" style=\"width:35%;text-align:left;\">PARTICULARS";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:10%;text-align:left;\"> ";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:40%;text-align:left;\">PARTICULARS";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:10%;text-align:left;\"> ";
            strHtml += "</th >";
            strHtml += "</tr>";
            strHtml += "</thead>";
        }
        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < RowCountTot; intRowBodyCount++)
        {
            strHtml += "<tr>";
            int COUNT = intRowBodyCount + 1;

            if (intRowBodyCount < dtLiability.Rows.Count)
            {
                string strId = dtLiability.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();
                int intIdLength = dtLiability.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                string drcr = "";
                if (Convert.ToDecimal(dtLiability.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString()) > 0)
                {
                    drcr = " Dr";
                }
                else if (Convert.ToDecimal(dtLiability.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString()) < 0)
                {
                    drcr = " Cr";
                }
                string strNetAmount = dtLiability.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString().Replace(@"-", string.Empty) + drcr;

                string CustomerName = dtLiability.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString();
                if (CustomerName.Contains("\"") == true)
                {
                    CustomerName = CustomerName.Replace("\"", "‡");
                }
                if (CustomerName.Contains("\'") == true)
                {
                    CustomerName = CustomerName.Replace("\'", "¦");
                }

                strHtml += "<td class=\"tr_l\"  ><a  title=\"View\"  onclick=\"return OpenReconView('" + Id + "',1,0," + strId + ",'" + Id + "','" + CustomerName + "',1,0);\" href=\"javascript:;\">" + dtLiability.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString() + "</td>";
                strHtml += "<td class=\"tr_r\" >" + objBusiness.AddCommasForNumberSeperation(dtLiability.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString().Replace(@"-", string.Empty).ToString(), objEntityCommon) + "</td>";
                decLiabilityTot = decLiabilityTot + Convert.ToDecimal(dtLiability.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString());
            }
            else
            {
                strHtml += "<td class=\"tr_l\"  ></td>";
                strHtml += "<td class=\"tr_l\" ></td>";
            }
            if (intRowBodyCount < dtAsset.Rows.Count)
            {
                string strId = dtAsset.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();
                int intIdLength = dtAsset.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                string drcr = "";
                if (Convert.ToDecimal(dtAsset.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString()) > 0)
                {
                    drcr = " Dr";
                }
                else if (Convert.ToDecimal(dtAsset.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString()) < 0)
                {
                    drcr = " Cr";
                }
                string strNetAmount = dtAsset.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString().Replace(@"-", string.Empty) + drcr;

                string CustomerName = dtAsset.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString();
                if (CustomerName.Contains("\"") == true)
                {
                    CustomerName = CustomerName.Replace("\"", "‡");
                }
                if (CustomerName.Contains("\'") == true)
                {
                    CustomerName = CustomerName.Replace("\'", "¦");
                }

                strHtml += "<td class=\"tr_l\"  ><a  title=\"View\"  onclick=\"return OpenReconView('" + Id + "',0,0," + strId + ",'" + Id + "','" + CustomerName + "',1,0);\" href=\"javascript:;\">" + dtAsset.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString() + "</td>";
                strHtml += "<td class=\"tr_r\"  >" + objBusiness.AddCommasForNumberSeperation(dtAsset.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString().Replace(@"-", string.Empty), objEntityCommon) + "</td>";
                decAssetTot = decAssetTot + Convert.ToDecimal(dtAsset.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString());
            }
            else
            {
                strHtml += "<td class=\"tr_l\"  ></td>";
                strHtml += "<td class=\"tr_l\"  ></td>";
            }
            strHtml += "</tr>";
        }
        strHtml += "</tbody>";

        if (RowCountTot > 0)
        {
            decimal NetAmount = 0;
            decimal NetTotal = 0;
            strHtml += "<tbody>";

            NetAmount = debAmnt - credAmnt;

            if (NetAmount > 0)
            {
                decAssetTot = decAssetTot + NetAmount;
                //strProfit = "Gross Profit";
                strHtml += "<tr class=\"tr1\">";
                strHtml += "<td class=\"tdT\" ></td>";
                strHtml += "<td class=\"tdT\" ></td>";
                strHtml += "<td class=\"tr_l\" >Profit & Loss A/C</td>";
                strHtml += "<td class=\"tr_r\" >" + objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon) + " Dr</td>";
                strHtml += "</tr>";
            }
            else if (NetAmount < 0)
            {
                NetAmount = NetAmount * -1;
                decLiabilityTot = decLiabilityTot + NetAmount;

                //strLoss = "Gross Loss";
                strHtml += "<tr class=\"tr1\">";
                strHtml += "<td class=\"tr_l\" >Profit & Loss A/C</td>";
                strHtml += "<td class=\"tr_r\" >" + objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon) + " Dr</td>";
                strHtml += "<td class=\"tdT\" ></td>";
                strHtml += "<td class=\"tdT\" ></td>";
                strHtml += "</tr>";
            }
            NetTotal = decAssetTot;
            if (decAssetTot > decLiabilityTot)
            {

                string str = "";
                decimal amntDif = decAssetTot - decLiabilityTot;
                if (amntDif > 0)
                {
                    str = " Dr";
                }
                else if (amntDif < 0)
                {
                    str = " Cr";
                }


                //strProfit = "Gross Profit";
                strHtml += "<tr class=\"tr1\">";
                strHtml += "<td class=\"tr_l\" >Difference</td>";
                strHtml += "<td class=\"tr_r\" >" + objBusiness.AddCommasForNumberSeperation(amntDif.ToString(), objEntityCommon) + str + "</td>";
                strHtml += "<td class=\"tdT\" ></td>";
                strHtml += "<td class=\"tdT\" ></td>";
                strHtml += "</tr>";
            }
            else if (decAssetTot < decLiabilityTot)
            {
                NetTotal = decLiabilityTot;

                string str = "";
                decimal amntDif = decLiabilityTot - decAssetTot;
                if (amntDif > 0)
                {
                    str = " Dr";
                }
                else if (amntDif < 0)
                {
                    str = " Cr";
                }

                //strLoss = "Gross Loss";
                strHtml += "<tr class=\"tr1\">";
                strHtml += "<td class=\"tdT\" ></td>";
                strHtml += "<td class=\"tdT\" ></td>";
                strHtml += "<td class=\"tr_l\" >Difference</td>";
                strHtml += "<td class=\"tr_r\" >" + objBusiness.AddCommasForNumberSeperation(amntDif.ToString(), objEntityCommon) + str + "</td>";
                strHtml += "</tr>";
            }
            strHtml += "<tr class=\"tr1\">";
            strHtml += "<td class=\"tdT\" ></td>";
            strHtml += "<td class=\"tr_r pl_2\"  >" + objBusiness.AddCommasForNumberSeperation(NetTotal.ToString(), objEntityCommon) + "</td>";
            strHtml += "<td class=\"tdT\" ></td>";
            strHtml += "<td class=\"tr_r pl_1\"  >" + objBusiness.AddCommasForNumberSeperation(NetTotal.ToString(), objEntityCommon) + "</td>";
            strHtml += "</tr>";
            strHtml += "</tbody>";
        }

        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    public string LoadConvertToTable_PDF(DataTable dtAsset, DataTable dtLiability, clsEntityBalanceSheet ObjEntityRequest, string strId1, string Printsts, string TypSts, Decimal credAmnt, Decimal debAmnt, string intAccntId, string datefrom, string ShowZero)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strRet = "";
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            ObjEntityRequest.Corporate_id = intCorpId;
            objEntityCommon.CorporateID = intCorpId;
        }
        clsBusinessProfitAndLossAccount objBussiness = new clsBusinessProfitAndLossAccount();
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
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
        int RowCountTot = dtAsset.Rows.Count;
        if (RowCountTot < dtLiability.Rows.Count)
        {
            RowCountTot = dtLiability.Rows.Count;
        }
        string strRandom = objCommon.Random_Number();
        decimal decLiabilityTot = 0, decAssetTot = 0;
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.BALANCESHEET_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.BALANCESHEET_PDF);
        objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "BalanceSheet_" + strNextNumber + ".pdf";

        Document document = new Document(PageSize.A4, 50f, 40f, 120f, 30f);
        document = new Document(PageSize.LETTER, 50f, 40f, 20f, 30f);
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
                footrtable.AddCell(new PdfPCell(new Phrase(datefrom, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (ShowZero == "1")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("SHOW ZERO BALANCE    ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase("YES", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("SHOW ZERO BALANCE    ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase("NO", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                document.Add(footrtable);

                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(4);
                float[] footrsBody = { 30, 20, 30, 20 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;//get header column in all pages

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("LIABILITIES", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour, Colspan = 2 });
                TBCustomer.AddCell(new PdfPCell(new Phrase("ASSETS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour, Colspan = 2 });
                TBCustomer.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("AMOUNT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("AMOUNT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                
                for (int intRowBodyCount = 0; intRowBodyCount < RowCountTot; intRowBodyCount++)
                {
                    int COUNT = intRowBodyCount + 1;

                    if (intRowBodyCount < dtLiability.Rows.Count)
                    {
                        string strId = dtLiability.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();
                        int intIdLength = dtLiability.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString().Length;
                        string stridLength = intIdLength.ToString("00");
                        string Id = stridLength + strId + strRandom;

                        string drcr = "";
                        if (Convert.ToDecimal(dtLiability.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString()) > 0)
                        {
                            drcr = " Dr";
                        }
                        else if (Convert.ToDecimal(dtLiability.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString()) < 0)
                        {
                            drcr = " Cr";
                        }
                        string strNetAmount = dtLiability.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString().Replace(@"-", string.Empty) + drcr;
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtLiability.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(dtLiability.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString().Replace(@"-", string.Empty).ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        decLiabilityTot = decLiabilityTot + Convert.ToDecimal(dtLiability.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString());
                    }
                    else
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }
                    if (intRowBodyCount < dtAsset.Rows.Count)
                    {
                        string strId = dtAsset.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();
                        int intIdLength = dtAsset.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString().Length;
                        string stridLength = intIdLength.ToString("00");
                        string Id = stridLength + strId + strRandom;

                        string drcr = "";
                        if (Convert.ToDecimal(dtAsset.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString()) > 0)
                        {
                            drcr = " Dr";
                        }
                        else if (Convert.ToDecimal(dtAsset.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString()) < 0)
                        {
                            drcr = " Cr";
                        }
                        string strNetAmount = dtAsset.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString().Replace(@"-", string.Empty) + drcr;
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtAsset.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(dtAsset.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString().Replace(@"-", string.Empty), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        decAssetTot = decAssetTot + Convert.ToDecimal(dtAsset.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString());
                    }
                    else
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }
                }
                if (RowCountTot > 0)
                {
                    decimal NetAmount = 0;
                    decimal NetTotal = 0;
                    NetAmount = debAmnt - credAmnt;
                    if (NetAmount > 0)
                    {
                        decAssetTot = decAssetTot + NetAmount;
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase("Profit & Loss A/C", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon) + " Dr", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    }
                    else if (NetAmount < 0)
                    {
                        NetAmount = NetAmount * -1;
                        decLiabilityTot = decLiabilityTot + NetAmount;
                        TBCustomer.AddCell(new PdfPCell(new Phrase("Profit & Loss A/C ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon) + " Dr", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    }
                    NetTotal = decAssetTot;
                    if (decAssetTot > decLiabilityTot)
                    {

                        string str = "";
                        decimal amntDif = decAssetTot - decLiabilityTot;
                        if (amntDif > 0)
                        {
                            str = " Dr";
                        }
                        else if (amntDif < 0)
                        {
                            str = " Cr";
                        }

                        TBCustomer.AddCell(new PdfPCell(new Phrase("Difference ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(amntDif.ToString(), objEntityCommon) + str, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    }
                    else if (decAssetTot < decLiabilityTot)
                    {
                        NetTotal = decLiabilityTot;

                        string str = "";
                        decimal amntDif = decLiabilityTot - decAssetTot;
                        if (amntDif > 0)
                        {
                            str = " Dr";
                        }
                        else if (amntDif < 0)
                        {
                            str = " Cr";
                        }
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase("Difference ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(amntDif.ToString(), objEntityCommon) + str, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    }
                    TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(NetTotal.ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(NetTotal.ToString(), objEntityCommon), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
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
    public string LoadConvertToTable_CSV(DataTable dtAsset, DataTable dtLiability, clsEntityBalanceSheet ObjEntityRequest, string strId1, string Printsts, string TypSts, Decimal credAmnt, Decimal debAmnt, string intAccntId, string datefrom, string ShowZero)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        DataTable dt = GetTableList(dtAsset, dtLiability, ObjEntityRequest, strId1, Printsts, TypSts, credAmnt, debAmnt, intAccntId, datefrom, ShowZero);
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


        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.BALANCESHEET_CSV);
        string strNextId = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string newFilePath = Server.MapPath("/CustomFiles/FMS CSV/BalanceSheet/BalanceSheetList_" + strNextId + ".csv");
        System.IO.File.WriteAllText(newFilePath, strResult);
        filepath = "BalanceSheetList_" + strNextId + ".csv";
        strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.BALANCESHEET_CSV);
        return strImagePath + filepath;
    }
    public DataTable GetTableList(DataTable dtAsset, DataTable dtLiability, clsEntityBalanceSheet ObjEntityRequest, string strId1, string Printsts, string TypSts, Decimal credAmnt, Decimal debAmnt, string intAccntId, string datefrom, string ShowZero)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,                                                           
                                                      clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,    
                                                              };
        int intCorpId = 0;
        if (ObjEntityRequest.Corporate_id != 0)
        {
            intCorpId = ObjEntityRequest.Corporate_id;
        }

        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        int Decimalcount = 0;
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }
        string FORNULL = "";
        DataTable table = new DataTable();
        table.Columns.Add("BALANCE SHEET", typeof(string));
        table.Columns.Add(" ", typeof(string));
        table.Columns.Add("  ", typeof(string));
        table.Columns.Add("   ", typeof(string));
        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("FROM DATE :", '"' + datefrom + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        if (ShowZero == "1")
            table.Rows.Add("SHOW ZERO BALANCE :", "YES", '"' + FORNULL + '"', '"' + FORNULL + '"');
        else
            table.Rows.Add("SHOW ZERO BALANCE :", "NO", '"' + FORNULL + '"', '"' + FORNULL + '"');

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');


        table.Rows.Add("LIABILITIES", '"' + FORNULL + '"', "ASSETS", '"' + FORNULL + '"');
        table.Rows.Add("PARTICULARS", "AMOUNT", "PARTICULARS", "AMOUNT");
        int RowCountTot = dtAsset.Rows.Count;
        if (RowCountTot < dtLiability.Rows.Count)
        {
            RowCountTot = dtLiability.Rows.Count;
        }
        string strRandom = objCommon.Random_Number();
        decimal decLiabilityTot = 0, decAssetTot = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < RowCountTot; intRowBodyCount++)
        {
            int COUNT = intRowBodyCount + 1;
            string strLIaAccountGroupName = "";
            string strLiaAmount = "";
            string strAssetAccountGroupName = "";
            string strAssetAmount = "";
            if (intRowBodyCount < dtLiability.Rows.Count)
            {
                string strId = dtLiability.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();
                int intIdLength = dtLiability.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                string drcr = "";
                if (Convert.ToDecimal(dtLiability.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString()) > 0)
                {
                    drcr = " Dr";
                }
                else if (Convert.ToDecimal(dtLiability.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString()) < 0)
                {
                    drcr = " Cr";
                }
                string strNetAmount = dtLiability.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString().Replace(@"-", string.Empty) + drcr;
                strLIaAccountGroupName = dtLiability.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString();
                strLiaAmount = objBusiness.AddCommasForNumberSeperation(dtLiability.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString().Replace(@"-", string.Empty).ToString(), objEntityCommon);
                decLiabilityTot = decLiabilityTot + Convert.ToDecimal(dtLiability.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString());
            }
            else
            {
                strLIaAccountGroupName = "";
                strLiaAmount = "";
            }
            if (intRowBodyCount < dtAsset.Rows.Count)
            {
                string strId = dtAsset.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();
                int intIdLength = dtAsset.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                string drcr = "";
                if (Convert.ToDecimal(dtAsset.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString()) > 0)
                {
                    drcr = " Dr";
                }
                else if (Convert.ToDecimal(dtAsset.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString()) < 0)
                {
                    drcr = " Cr";
                }
                string strNetAmount = dtAsset.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString().Replace(@"-", string.Empty) + drcr;
                strAssetAccountGroupName = dtAsset.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString();
                strAssetAmount = objBusiness.AddCommasForNumberSeperation(dtAsset.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString().Replace(@"-", string.Empty), objEntityCommon);
                decAssetTot = decAssetTot + Convert.ToDecimal(dtAsset.Rows[intRowBodyCount]["TOTAL_AMNT"].ToString());
            }
            else
            {
                strAssetAccountGroupName = "";
                strAssetAmount = "";
            }
            table.Rows.Add('"' + strLIaAccountGroupName + '"', '"' + strLiaAmount + '"', '"' + strAssetAccountGroupName + '"', '"' + strAssetAmount + '"');
        }
        if (RowCountTot > 0)
        {
            decimal NetAmount = 0;
            decimal NetTotal = 0;
            NetAmount = debAmnt - credAmnt;
            if (NetAmount > 0)
            {
                decAssetTot = decAssetTot + NetAmount;
                table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', "Profit & Loss A/C", '"' + objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon) + " Dr" + '"');
            }
            else if (NetAmount < 0)
            {
                NetAmount = NetAmount * -1;
                decLiabilityTot = decLiabilityTot + NetAmount;
                table.Rows.Add("Profit & Loss A/C", '"' + objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon) + " Dr" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
            }
            NetTotal = decAssetTot;
            if (decAssetTot > decLiabilityTot)
            {
                string str = "";
                decimal amntDif = decAssetTot - decLiabilityTot;
                if (amntDif > 0)
                {
                    str = " Dr";
                }
                else if (amntDif < 0)
                {
                    str = " Cr";
                }
                table.Rows.Add("Difference", '"' + objBusiness.AddCommasForNumberSeperation(amntDif.ToString(), objEntityCommon) + str + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
            }
            else if (decAssetTot < decLiabilityTot)
            {
                NetTotal = decLiabilityTot;

                string str = "";
                decimal amntDif = decLiabilityTot - decAssetTot;
                if (amntDif > 0)
                {
                    str = " Dr";
                }
                else if (amntDif < 0)
                {
                    str = " Cr";
                }
                table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', "Difference", '"' + objBusiness.AddCommasForNumberSeperation(amntDif.ToString(), objEntityCommon) + str + '"');
            }
            table.Rows.Add('"' + FORNULL + '"', '"' + objBusiness.AddCommasForNumberSeperation(NetTotal.ToString(), objEntityCommon) + '"', '"' + FORNULL + '"', '"' + objBusiness.AddCommasForNumberSeperation(NetTotal.ToString(), objEntityCommon) + '"');
        }
        return table;
    }

    //detail table popup
    public string LoadConvertToTable(DataTable dtCategory, clsEntityBalanceSheet ObjEntityRequest, int StsGrp, string strId1, string Printsts, string intAccntId, string sts)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        clsBusinessLayer_Trial_Bal objBussiness = new clsBusinessLayer_Trial_Bal();
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
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

        int intCount = 0;

        decimal sum_Cedt = 0, sum_debt = 0;
        foreach (DataRow dr in dtCategory.Rows)
        {
            if (Convert.ToDecimal(dr["TOTAL_DEB_AMNT"]) >= 0)
            {
                sum_debt += Convert.ToDecimal(dr["TOTAL_DEB_AMNT"]);
            }
            else
            {
                sum_Cedt += (Convert.ToDecimal(dr["TOTAL_DEB_AMNT"]) * -1);
            }
        }
        //   clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        StringBuilder sb = new StringBuilder();
        string strHtml = "";
        // class="table table-bordered table-striped"
        if (Printsts == "0")
        {

            strHtml = "<table id=\"datatable_fixed_column" + strId1 + "\" class=\"display table-bordered\" width=\"100%\">";
            //add header row
            strHtml += "<thead class=\"thead1\">";
            strHtml += "<tr >";
            for (int intColumnHeaderCount = 0; intColumnHeaderCount <= dtCategory.Columns.Count; intColumnHeaderCount++)
            {
                if (intColumnHeaderCount == 1)
                {
                    strHtml += "<th class=\"col-md-7 tr_l\" >PARTICULARS ";
                    strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input class=\"tb_inp_1 tb_in\" placeholder=\"PARTICULARS \"  type=\"text\">";
                    strHtml += "</th >";
                }
                else if (intColumnHeaderCount == 2)
                {
                    strHtml += "<th class=\"col-md-2 tr_r\" >DEBIT ";
                    strHtml += " <i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input class=\"tb_inp_1 tb_in tr_r\" placeholder=\"DEBIT\" type=\"text\">";
                    strHtml += "</th >";
                }

                else if (intColumnHeaderCount == 3)
                {
                    strHtml += "<th class=\"col-md-2 tr_r\" >CREDIT ";
                    strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input class=\"tb_inp_1 tb_in tr_r\" placeholder=\"CREDIT\" type=\"text\">";
                    strHtml += "</th >";
                }
            }

            strHtml += "</th >";
            strHtml += "</tr>";
            strHtml += "</thead>";

        }
        else
        {
            strHtml = "<table id=\"PrintTable\" class=\"tab\" \">";
            //add header row
            strHtml += "<thead >";
            strHtml += "<tr class=\"top_row\">";
            strHtml += "<th class=\"thT\" style=\"width:20%;text-align:left;\">PARTICULARS ";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:20%;text-align:right;\">DEBIT";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:20%;text-align:right;\">CREDIT";
            strHtml += "</th >";
            strHtml += "</tr>";
            strHtml += "</thead>";
        }
        //add rows

        strHtml += "<tbody>";
        int COUNT = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
        {

            decimal decDebAmnt = Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString());
            //if (decDebAmnt != 0)
            //{
            strHtml += "<tr>";
            CountRow = 1;
            string strId = dtCategory.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dtCategory.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            COUNT++;

            string CustomerName = dtCategory.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString();
            if (CustomerName.Contains("\"") == true)
            {
                CustomerName = CustomerName.Replace("\"", "‡");
            }
            if (CustomerName.Contains("\'") == true)
            {
                CustomerName = CustomerName.Replace("\'", "¦");
            }

            strHtml += "<td class=\"tr_l\"  > <a  title=\"View\"  onclick=\"return OpenReconView('" + Id + "'," + sts + ",0," + strId + ",'" + intAccntId + "','" + CustomerName + "',0,'" + dtCategory.Rows[intRowBodyCount]["STSACCNTORLED"].ToString() + "');\" href=\"javascript:;\">" + dtCategory.Rows[intRowBodyCount][1].ToString() + "</td>";
            string strNetAmount = "";
            string strNetAmountDebitComma = "";
            if (dtCategory.Rows[intRowBodyCount][2].ToString() != "")
            {
                strNetAmount = dtCategory.Rows[intRowBodyCount][2].ToString();
                strNetAmount = strNetAmount.Replace(@"-", string.Empty);
                strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
            }
            if (decDebAmnt > 0)
            {
                strHtml += "<td class=\"tr_r\"  >" + strNetAmountDebitComma + "</td>";
                strHtml += "<td class=\"tr_r\"  ></td>";
            }
            else
            {
                strHtml += "<td class=\"tr_r\"  ></td>";
                strHtml += "<td class=\"tr_r\"  > " + strNetAmountDebitComma + "</td>";
            }
            strHtml += "</tr>";
        }
        strHtml += "</tbody>";

        string STRBALANDR = "", STRBALANCR = "";
        if (sum_Cedt != sum_debt)
        {
            if (sum_Cedt < sum_debt)
            {
                STRBALANDR = "";
                STRBALANCR = (sum_debt - sum_Cedt).ToString();
                if (STRBALANCR != "")
                {
                    sum_Cedt = sum_Cedt + Convert.ToDecimal(STRBALANCR);
                }
            }
            if (sum_Cedt > sum_debt)
            {
                STRBALANDR = (sum_Cedt - sum_debt).ToString();
                if (STRBALANDR != "")
                    sum_debt = sum_debt + Convert.ToDecimal(STRBALANDR);
                STRBALANCR = "";
            }
        }
        if (StsGrp == 0)
        {
            strHtml += " <tfoot> <tr>";
            strHtml += "<td class=\"tdT\"   > </td>";
            strHtml += "<th class=\"tr_l\"  >BALANCE </th>";
            string strNetAmount = "";
            string strNetAmountCrComma = "";
            string strNetAmount1 = "";
            string strNetAmountCrComma1 = "";
            if (STRBALANDR != "")
            {
                strNetAmount = STRBALANDR;
                decimal NetAmount = Convert.ToDecimal(strNetAmount);
                strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
            }
            if (STRBALANCR != "")
            {
                strNetAmount1 = STRBALANCR;
                decimal NetAmount1 = Convert.ToDecimal(strNetAmount1);
                strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(NetAmount1.ToString(), objEntityCommon);
            }
            strHtml += "<th class=\"tr_r\"  > " + strNetAmountCrComma + "</th>";
            strHtml += "<th class=\"tr_r\"  > " + strNetAmountCrComma1 + "</th>";
            strHtml += "</tr>";
            strHtml += "<tr>";
            strHtml += "<th class=\"tr_l \"   > TOTAL</th>";
            strHtml += "<td class=\"tr_r \"  > " + sum_debt + "</td>";
            strHtml += "<td class=\"tr_r\"  > " + sum_Cedt + "</td>";
            strHtml += "</tr></tfoot>";
        }
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    public string LoadConvertToTable_PDF(DataTable dtCategory, clsEntityBalanceSheet ObjEntityRequest, int StsGrp, string strId1, string Printsts, string intAccntId, string sts, string strName, string intdateto)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        clsBusinessLayer_Trial_Bal objBussiness = new clsBusinessLayer_Trial_Bal();
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        string strRet = "";

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

        int intCount = 0;

        decimal sum_Cedt = 0, sum_debt = 0;
        foreach (DataRow dr in dtCategory.Rows)
        {
            if (Convert.ToDecimal(dr["TOTAL_DEB_AMNT"]) >= 0)
            {
                sum_debt += Convert.ToDecimal(dr["TOTAL_DEB_AMNT"]);
            }
            else
            {
                sum_Cedt += (Convert.ToDecimal(dr["TOTAL_DEB_AMNT"]) * -1);
            }
        }
        string strRandom = objCommon.Random_Number();
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.BALANCESHEET_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.BALANCESHEET_PDF);
        objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "BalncShtAccntStmt_" + strNextNumber + ".pdf";

        Document document = new Document(PageSize.A4, 50f, 40f, 120f, 30f);
        document = new Document(PageSize.LETTER, 50f, 40f, 20f, 30f);
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
                float[] footrsBody1 = { 40, 5, 55 };
                footrtable.SetWidths(footrsBody1);
                footrtable.WidthPercentage = 100;

                footrtable.AddCell(new PdfPCell(new Phrase("DATE     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(intdateto, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase("ACCOUNT GROUP/LEDGER NAME", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(strName, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                document.Add(footrtable);

                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(3);
                float[] footrsBody = { 60, 20, 20 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;//get header column in all pages

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);

                TBCustomer.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("DEBIT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("CREDIT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                
                int COUNT = 0;
                for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
                {
                    decimal decDebAmnt = Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString());
                    CountRow = 1;
                    string strId = dtCategory.Rows[intRowBodyCount][0].ToString();
                    int intIdLength = dtCategory.Rows[intRowBodyCount][0].ToString().Length;
                    string stridLength = intIdLength.ToString("00");
                    string Id = stridLength + strId + strRandom;
                    COUNT++;
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount][1].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    string strNetAmount = "";
                    string strNetAmountDebitComma = "";
                    if (dtCategory.Rows[intRowBodyCount][2].ToString() != "")
                    {
                        strNetAmount = dtCategory.Rows[intRowBodyCount][2].ToString();
                        strNetAmount = strNetAmount.Replace(@"-", string.Empty);
                        strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                    }
                    if (decDebAmnt > 0)
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountDebitComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }
                    else
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountDebitComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }
                }
                string STRBALANDR = "", STRBALANCR = "";
                if (sum_Cedt != sum_debt)
                {
                    if (sum_Cedt < sum_debt)
                    {
                        STRBALANDR = "";
                        STRBALANCR = (sum_debt - sum_Cedt).ToString();
                        if (STRBALANCR != "")
                        {
                            sum_Cedt = sum_Cedt + Convert.ToDecimal(STRBALANCR);
                        }
                    }
                    if (sum_Cedt > sum_debt)
                    {
                        STRBALANDR = (sum_Cedt - sum_debt).ToString();
                        if (STRBALANDR != "")
                            sum_debt = sum_debt + Convert.ToDecimal(STRBALANDR);
                        STRBALANCR = "";
                    }
                }
                if (StsGrp == 0)
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("BALANCE", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    string strNetAmount = "";
                    string strNetAmountCrComma = "";
                    string strNetAmount1 = "";
                    string strNetAmountCrComma1 = "";
                    if (STRBALANDR != "")
                    {
                        strNetAmount = STRBALANDR;
                        decimal NetAmount = Convert.ToDecimal(strNetAmount);
                        strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                    }
                    if (STRBALANCR != "")
                    {
                        strNetAmount1 = STRBALANCR;
                        decimal NetAmount1 = Convert.ToDecimal(strNetAmount1);
                        strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(NetAmount1.ToString(), objEntityCommon);
                    }
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma1, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(sum_debt.ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(sum_Cedt.ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
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
    public string LoadConvertToTable_CSV(DataTable dtCategory, clsEntityBalanceSheet ObjEntityRequest, int StsGrp, string strId1, string Printsts, string intAccntId, string sts, string strName, string intdateto)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        DataTable dt = GetTable(dtCategory, ObjEntityRequest, StsGrp, strId1, Printsts, intAccntId, sts, strName, intdateto);
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


        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.BALANCESHEET_CSV);
        string strNextId = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string newFilePath = Server.MapPath("/CustomFiles/FMS CSV/BalanceSheet/BalaceSheet_" + strNextId + ".csv");
        System.IO.File.WriteAllText(newFilePath, strResult);
        filepath = "BalaceSheet_" + strNextId + ".csv";
        strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.BALANCESHEET_CSV);
        return strImagePath + filepath;
    }
    public DataTable GetTable(DataTable dtCategory, clsEntityBalanceSheet ObjEntityRequest, int StsGrp, string strId1, string Printsts, string intAccntId, string sts, string strName, string intdateto)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,                                                           
                                                      clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,    
                                                              };
        int intCorpId = 0;
        if (ObjEntityRequest.Corporate_id != 0)
        {
            intCorpId = ObjEntityRequest.Corporate_id;
        }

        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        int Decimalcount = 0;
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }
        int intCount = 0;

        decimal sum_Cedt = 0, sum_debt = 0;
        foreach (DataRow dr in dtCategory.Rows)
        {
            if (Convert.ToDecimal(dr["TOTAL_DEB_AMNT"]) >= 0)
            {
                sum_debt += Convert.ToDecimal(dr["TOTAL_DEB_AMNT"]);
            }
            else
            {
                sum_Cedt += (Convert.ToDecimal(dr["TOTAL_DEB_AMNT"]) * -1);
            }
        }
        string strRandom = objCommon.Random_Number();
        string FORNULL = "";
        DataTable table = new DataTable();
        table.Columns.Add("BALANCE SHEET", typeof(string));
        table.Columns.Add(" ", typeof(string));
        table.Columns.Add("  ", typeof(string));
        //table.Columns.Add("   ", typeof(string));
        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("DATE :", '"' + intdateto + '"', '"' + FORNULL + '"');
        table.Rows.Add("ACCOUNT GROUP/LEDGER NAME :", '"' + strName + '"', '"' + FORNULL + '"');
        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');


        table.Rows.Add("PARTICULARS", "DEBIT", "CREDIT");
        int COUNT = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
        {

            decimal decDebAmnt = Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString());
            //if (decDebAmnt != 0)
            //{
            CountRow = 1;
            string strId = dtCategory.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dtCategory.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            COUNT++;
            string strNetAmount = "";
            string strNetAmountDebitComma = "";
            string strDebitAmount = "";
            string strCreditAmount = "";
            if (dtCategory.Rows[intRowBodyCount][2].ToString() != "")
            {
                strNetAmount = dtCategory.Rows[intRowBodyCount][2].ToString();
                strNetAmount = strNetAmount.Replace(@"-", string.Empty);
                strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
            }
            if (decDebAmnt > 0)
            {
                strDebitAmount = strNetAmountDebitComma;
                strCreditAmount = "";
            }
            else
            {
                strDebitAmount = "";
                strCreditAmount = strNetAmountDebitComma;
            }
            table.Rows.Add('"' + dtCategory.Rows[intRowBodyCount][1].ToString() + '"', '"' + strDebitAmount + '"', '"' + strCreditAmount + '"');

        }
        string STRBALANDR = "", STRBALANCR = "";
        if (sum_Cedt != sum_debt)
        {
            if (sum_Cedt < sum_debt)
            {
                STRBALANDR = "";
                STRBALANCR = (sum_debt - sum_Cedt).ToString();
                if (STRBALANCR != "")
                {
                    sum_Cedt = sum_Cedt + Convert.ToDecimal(STRBALANCR);
                }
            }
            if (sum_Cedt > sum_debt)
            {
                STRBALANDR = (sum_Cedt - sum_debt).ToString();
                if (STRBALANDR != "")
                    sum_debt = sum_debt + Convert.ToDecimal(STRBALANDR);
                STRBALANCR = "";
            }
        }
        if (StsGrp == 0)
        {
            string strNetAmount = "";
            string strNetAmountCrComma = "";
            string strNetAmount1 = "";
            string strNetAmountCrComma1 = "";
            if (STRBALANDR != "")
            {
                strNetAmount = STRBALANDR;
                decimal NetAmount = Convert.ToDecimal(strNetAmount);
                strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
            }
            if (STRBALANCR != "")
            {
                strNetAmount1 = STRBALANCR;
                decimal NetAmount1 = Convert.ToDecimal(strNetAmount1);
                strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(NetAmount1.ToString(), objEntityCommon);
            }
            table.Rows.Add("BALANCE", '"' + strNetAmountCrComma + '"', '"' + strNetAmountCrComma1 + '"');
            table.Rows.Add("TOTAL", '"' + sum_debt.ToString() + '"', '"' + sum_Cedt.ToString() + '"');
        }
        return table;
    }

    //ledger detail table popup
    public string LoadConvertToTableLed(DataTable dtCategory, DataTable dtOpenBalance, clsEntityBalanceSheet ObjEntityRequest, int StsGrp, string strId1, string Printsts, string intAccntId, string sts)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsBusinessLayer objBusiness = new clsBusinessLayer();


        int intCorpId = 0;

        clsBusinessLayer_Trial_Bal objBussiness = new clsBusinessLayer_Trial_Bal();
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
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

        int intCount = 0;

        decimal sum_Cedt = 0, sum_debt = 0;
        foreach (DataRow dr in dtCategory.Rows)
        {
            if (dr["VOCHR_STS"].ToString() == "0")
            {
                sum_debt += Convert.ToDecimal(dr["VOCHR_AMT"]);
            }
            else
            {
                sum_Cedt += Convert.ToDecimal(dr["VOCHR_AMT"]);
            }
        }
        if (dtOpenBalance.Rows.Count > 0)
        {
            decimal OpenBal = Convert.ToDecimal(dtOpenBalance.Rows[0]["TOTAL_DEB_AMNT"].ToString());
            if (OpenBal > 0)
            {
                sum_debt += OpenBal;
            }
            else if (OpenBal < 0)
            {
                sum_Cedt += (OpenBal * -1);
            }
        }
        //   clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        StringBuilder sb = new StringBuilder();
        string strHtml = "";
        // class="table table-bordered table-striped"
        if (Printsts == "0")
        {

            strHtml = "<table id=\"datatable_fixed_column" + strId1 + "\" class=\"display table-bordered\" width=\"100%\" >";
            //add header row
            strHtml += "<thead class=\"thead1\">";

            strHtml += "<tr >";
            strHtml += "<th class=\"col-md-2 tr_c\" >DATE ";
            strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input class=\"tb_inp_1 tb_in tr_c\" placeholder=\"DATE \" type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-3 tr_l\" >TRANS TYPE ";
            strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input class=\"tb_inp_1 tb_in tr_l\" placeholder=\"TRANS TYPE \" type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-3 tr_c\" >REF# ";
            strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input class=\"tb_inp_1 tb_in tr_c\" placeholder=\"REF# \" type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-2 tr_r\" >DEBIT ";
            strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input class=\"tb_inp_1 tb_in tr_r\" placeholder=\"DEBIT\" type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-2 tr_r\" >CREDIT ";
            strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input class=\"tb_inp_1 tb_in tr_r\" placeholder=\"CREDIT\" type=\"text\">";
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
            strHtml += "<th class=\"thT\" style=\"width:15%;text-align:left;\">DATE";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:15%;text-align:left;\">TRANS TYPE";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:20%;text-align:left;\">REF#";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:20%;text-align:right;\">DEBIT";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:20%;text-align:right;\">CREDIT";
            strHtml += "</th >";
            strHtml += "</tr>";
            strHtml += "</thead>";
        }
        //add rows

        strHtml += "<tbody>";
        int COUNT = 0;
        if (dtOpenBalance.Rows.Count > 0)
        {
            decimal OpenBal = Convert.ToDecimal(dtOpenBalance.Rows[0]["TOTAL_DEB_AMNT"].ToString());
            if (OpenBal != 0)
            {
                COUNT++;
                strHtml += "<tr>";
                strHtml += "<td class=\"tr_c\"  >" + dtOpenBalance.Rows[0]["STRTDATE"].ToString() + "</td>";
                strHtml += "<td class=\"tr_l\"  >Opening Balance</td>";
                strHtml += "<td class=\"tr_l\"  ></td>";
                string strNetAmount = "";
                string strNetAmountDebitComma = "";
                if (dtOpenBalance.Rows[0]["TOTAL_DEB_AMNT"].ToString() != "")
                {
                    strNetAmount = dtOpenBalance.Rows[0]["TOTAL_DEB_AMNT"].ToString();
                    strNetAmount = strNetAmount.Replace(@"-", string.Empty);
                    strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                }
                if (OpenBal > 0)
                {
                    strHtml += "<td class=\"tr_r\" >" + strNetAmountDebitComma + "</td>";
                    strHtml += "<td class=\"tr_r\"  ></td>";
                }
                else if (OpenBal < 0)
                {
                    strHtml += "<td class=\"tr_l\" ></td>";
                    strHtml += "<td class=\"tr_r\"  > " + strNetAmountDebitComma + "</td>";
                }
                strHtml += "</tr>";
            }
        }
        for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
        {
            CountRow = 1;
            COUNT++;
            string VchrSts = dtCategory.Rows[intRowBodyCount]["VOCHR_STS"].ToString();

            strHtml += "<tr>";
            strHtml += "<td class=\"tr_c\"  >" + dtCategory.Rows[intRowBodyCount]["VOCHR_DATE"].ToString() + "</td>";
            strHtml += "<td class=\"tr_l\" >" + dtCategory.Rows[intRowBodyCount]["VOCHR_TYPE"].ToString() + "</td>";
            strHtml += "<td class=\"tr_c\"  >" + dtCategory.Rows[intRowBodyCount]["VOCHR_REF"].ToString() + "</td>";


            string strNetAmount = "";
            string strNetAmountDebitComma = "";
            if (dtCategory.Rows[intRowBodyCount]["VOCHR_AMT"].ToString() != "")
            {
                strNetAmount = dtCategory.Rows[intRowBodyCount]["VOCHR_AMT"].ToString();
                strNetAmount = strNetAmount.Replace(@"-", string.Empty);
                strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
            }
            if (VchrSts == "0")
            {
                strHtml += "<td class=\"tr_r\" >" + strNetAmountDebitComma + "</td>";
                strHtml += "<td class=\"tdT\" ></td>";
            }
            else
            {
                strHtml += "<td class=\"tdT\" ></td>";
                strHtml += "<td class=\"tr_r\"  > " + strNetAmountDebitComma + "</td>";
            }
            strHtml += "</tr>";
        }
        strHtml += "</tbody>";
        strHtml += " <tfoot><tr>";
        strHtml += "<td class=\"tr_c ft_bld\"  colspan=\"3\">GRAND TOTAL</td>";
        string strNetAmountCrComma = "", strNetAmountCrComma1 = "";
        strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(sum_debt.ToString(), objEntityCommon);
        strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(sum_Cedt.ToString(), objEntityCommon);
        if (strNetAmountCrComma == "0.")
        {
            strNetAmountCrComma = "";
        }
        if (strNetAmountCrComma1 == "0.")
        {
            strNetAmountCrComma1 = "";
        }
        strHtml += "<td class=\"tr_r ft_bld\" > " + strNetAmountCrComma + "</td>";
        strHtml += "<td class=\"tr_r ft_bld\" > " + strNetAmountCrComma1 + "</td>";
        strHtml += " </tr>";
        strHtml += "</tfoot>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    public string LoadConvertToTableLed_PDF(DataTable dtCategory, DataTable dtOpenBalance, clsEntityBalanceSheet ObjEntityRequest, int StsGrp, string strId1, string Printsts, string intAccntId, string sts, string strName, string intdateto)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = 0;
        clsBusinessLayer_Trial_Bal objBussiness = new clsBusinessLayer_Trial_Bal();
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        int Decimalcount = 0;
        string strRet = "";
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

        int intCount = 0;
        decimal sum_Cedt = 0, sum_debt = 0;
        foreach (DataRow dr in dtCategory.Rows)
        {
            if (dr["VOCHR_STS"].ToString() == "0")
            {
                sum_debt += Convert.ToDecimal(dr["VOCHR_AMT"]);
            }
            else
            {
                sum_Cedt += Convert.ToDecimal(dr["VOCHR_AMT"]);
            }
        }
        if (dtOpenBalance.Rows.Count > 0)
        {
            decimal OpenBal = Convert.ToDecimal(dtOpenBalance.Rows[0]["TOTAL_DEB_AMNT"].ToString());
            if (OpenBal > 0)
            {
                sum_debt += OpenBal;
            }
            else if (OpenBal < 0)
            {
                sum_Cedt += (OpenBal * -1);
            }
        }
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.BALANCESHEET_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.BALANCESHEET_PDF);
        objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "BalanSheetStmentLed_" + strNextNumber + ".pdf";

        Document document = new Document(PageSize.A4, 50f, 40f, 120f, 30f);
        document = new Document(PageSize.LETTER, 50f, 40f, 20f, 30f);
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
                float[] footrsBody1 = { 40, 5, 55 };
                footrtable.SetWidths(footrsBody1);
                footrtable.WidthPercentage = 100;

                footrtable.AddCell(new PdfPCell(new Phrase("DATE     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(intdateto, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase("LEDGER NAME", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(strName, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                document.Add(footrtable);

                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(5);
                float[] footrsBody = { 10, 30, 20, 20, 20 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;//get header column in all pages

                var FontSmallGray = new BaseColor(230, 230, 230);
                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);

                TBCustomer.AddCell(new PdfPCell(new Phrase("DATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("TRANS TYPE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("REF#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("DEBIT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("CREDIT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
               
                int COUNT = 0;
                if (dtOpenBalance.Rows.Count > 0)
                {
                    decimal OpenBal = Convert.ToDecimal(dtOpenBalance.Rows[0]["TOTAL_DEB_AMNT"].ToString());
                    if (OpenBal != 0)
                    {
                        COUNT++;
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtOpenBalance.Rows[0]["STRTDATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase("Opening Balance", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        string strNetAmount = "";
                        string strNetAmountDebitComma = "";
                        if (dtOpenBalance.Rows[0]["TOTAL_DEB_AMNT"].ToString() != "")
                        {
                            strNetAmount = dtOpenBalance.Rows[0]["TOTAL_DEB_AMNT"].ToString();
                            strNetAmount = strNetAmount.Replace(@"-", string.Empty);
                            strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                        }
                        if (OpenBal > 0)
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountDebitComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                        else if (OpenBal < 0)
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountDebitComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                    }
                }
                for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
                {
                    CountRow = 1;
                    COUNT++;
                    string VchrSts = dtCategory.Rows[intRowBodyCount]["VOCHR_STS"].ToString();

                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["VOCHR_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["VOCHR_TYPE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["VOCHR_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    string strNetAmount = "";
                    string strNetAmountDebitComma = "";
                    if (dtCategory.Rows[intRowBodyCount]["VOCHR_AMT"].ToString() != "")
                    {
                        strNetAmount = dtCategory.Rows[intRowBodyCount]["VOCHR_AMT"].ToString();
                        strNetAmount = strNetAmount.Replace(@"-", string.Empty);
                        strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                    }
                    if (VchrSts == "0")
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountDebitComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }
                    else
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountDebitComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }
                }
                TBCustomer.AddCell(new PdfPCell(new Phrase("GRAND TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray, Colspan = 3 });
                string strNetAmountCrComma = "", strNetAmountCrComma1 = "";
                strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(sum_debt.ToString(), objEntityCommon);
                strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(sum_Cedt.ToString(), objEntityCommon);
                if (strNetAmountCrComma == "0.")
                {
                    strNetAmountCrComma = "";
                }
                if (strNetAmountCrComma1 == "0.")
                {
                    strNetAmountCrComma1 = "";
                }
                TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma1, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });

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
    public string LoadConvertToTableLed_CSV(DataTable dtCategory, DataTable dtOpenBalance, clsEntityBalanceSheet ObjEntityRequest, int StsGrp, string strId1, string Printsts, string intAccntId, string sts, string strName, string intdateto)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dt = GetTableLed(dtCategory,dtOpenBalance, ObjEntityRequest, StsGrp, strId1, Printsts, intAccntId, sts, strName, intdateto);
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
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.BALANCESHEET_CSV);
        string strNextId = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string newFilePath = Server.MapPath("/CustomFiles/FMS CSV/BalanceSheet/BalanceSheetLedger_" + strNextId + ".csv");
        System.IO.File.WriteAllText(newFilePath, strResult);
        filepath = "BalanceSheetLedger_" + strNextId + ".csv";
        strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.BALANCESHEET_CSV);
        return strImagePath + filepath;
    } 
    public DataTable GetTableLed(DataTable dtCategory, DataTable dtOpenBalance, clsEntityBalanceSheet ObjEntityRequest, int StsGrp, string strId1, string Printsts, string intAccntId, string sts, string strName, string intdateto)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,                                                           
                                                      clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,    
                                                              };
        int intCorpId = 0;
        if (ObjEntityRequest.Corporate_id != 0)
        {
            intCorpId = ObjEntityRequest.Corporate_id;
        }

        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        int Decimalcount = 0;
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }
        int intCount = 0;

        decimal sum_Cedt = 0, sum_debt = 0;
       
        foreach (DataRow dr in dtCategory.Rows)
        {
            if (dr["VOCHR_STS"].ToString() == "0")
            {
                sum_debt += Convert.ToDecimal(dr["VOCHR_AMT"]);
            }
            else
            {
                sum_Cedt += Convert.ToDecimal(dr["VOCHR_AMT"]);
            }
        }
        if (dtOpenBalance.Rows.Count > 0)
        {
            decimal OpenBal = Convert.ToDecimal(dtOpenBalance.Rows[0]["TOTAL_DEB_AMNT"].ToString());
            if (OpenBal > 0)
            {
                sum_debt += OpenBal;
            }
            else if (OpenBal < 0)
            {
                sum_Cedt += (OpenBal * -1);
            }
        }
        string strRandom = objCommon.Random_Number();
        string FORNULL = "";
        DataTable table = new DataTable();
        table.Columns.Add("BALANCE SHEET", typeof(string));
        table.Columns.Add(" ", typeof(string));
        table.Columns.Add("  ", typeof(string));
        table.Columns.Add("   ", typeof(string));
        table.Columns.Add("    ", typeof(string));
        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("DATE :", '"' + intdateto + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("LEDGER NAME :", '"' + strName + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
          
        table.Rows.Add("DATE","TRANS TYPE","REF#", "DEBIT", "CREDIT");
        int COUNT = 0;
        if (dtOpenBalance.Rows.Count > 0)
        {
            decimal OpenBal = Convert.ToDecimal(dtOpenBalance.Rows[0]["TOTAL_DEB_AMNT"].ToString());
            if (OpenBal != 0)
            {
                COUNT++;
                string strNetAmount = "";
                string strNetAmountDebitComma = "";
                string strDebitAmount = "";
                string strCreditAmount = "";
                if (dtOpenBalance.Rows[0]["TOTAL_DEB_AMNT"].ToString() != "")
                {
                    strNetAmount = dtOpenBalance.Rows[0]["TOTAL_DEB_AMNT"].ToString();
                    strNetAmount = strNetAmount.Replace(@"-", string.Empty);
                    strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                }
                if (OpenBal > 0)
                {
                    strDebitAmount = strNetAmountDebitComma;
                    strCreditAmount = "";
                }
                else if (OpenBal < 0)
                {
                    strDebitAmount = "";
                    strCreditAmount = strNetAmountDebitComma;
                }
                table.Rows.Add('"' + dtOpenBalance.Rows[0]["STRTDATE"].ToString() + '"', "Opening Balance", '"' + FORNULL + '"', '"' + strDebitAmount + '"', '"' + strCreditAmount + '"');
                
            }
        }
        for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
        {
            CountRow = 1;
            COUNT++;
            string strDebitAmount = "";
            string strCreditAmount = "";
            string VchrSts = dtCategory.Rows[intRowBodyCount]["VOCHR_STS"].ToString();
            string strNetAmount = "";
            string strNetAmountDebitComma = "";
            if (dtCategory.Rows[intRowBodyCount]["VOCHR_AMT"].ToString() != "")
            {
                strNetAmount = dtCategory.Rows[intRowBodyCount]["VOCHR_AMT"].ToString();
                strNetAmount = strNetAmount.Replace(@"-", string.Empty);
                strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
            }
            if (VchrSts == "0")
            {
                strDebitAmount = strNetAmountDebitComma;
                strCreditAmount = "";
            }
            else
            {
                strDebitAmount = "";
                strCreditAmount = strNetAmountDebitComma;
            }
            table.Rows.Add('"' + dtCategory.Rows[intRowBodyCount]["VOCHR_DATE"].ToString() + '"', '"' + dtCategory.Rows[intRowBodyCount]["VOCHR_TYPE"].ToString() + '"', '"' + dtCategory.Rows[intRowBodyCount]["VOCHR_REF"].ToString() + '"', '"' + strDebitAmount + '"', '"' + strCreditAmount + '"');

        }
        string strNetAmountCrComma = "", strNetAmountCrComma1 = "";
        strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(sum_debt.ToString(), objEntityCommon);
        strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(sum_Cedt.ToString(), objEntityCommon);
        if (strNetAmountCrComma == "0.")
        {
            strNetAmountCrComma = "";
        }
        if (strNetAmountCrComma1 == "0.")
        {
            strNetAmountCrComma1 = "";
        }
        table.Rows.Add("GRAND TOTAL", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + strNetAmountCrComma + '"', '"' + strNetAmountCrComma1 + '"');


        return table;
    }
    
    //check popup table
    [WebMethod]
    public static string[] TrailBalance_Lists_ById(string intAccntId, string intuserid, string intorgid, string intcorpid, string intdatefrom, string intdateto, string sts, string LedgSts, string ShowZero, string strName)
    {
        CountRow = 0;
        string[] result = new string[10];
        clsBusinessBalanceSheet objBussiness = new clsBusinessBalanceSheet();
        clsEntityBalanceSheet objEntity = new clsEntityBalanceSheet();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        FMS_FMS_Reports_fms_Balance_Sheet_fms_Balance_Sheet obj = new FMS_FMS_Reports_fms_Balance_Sheet_fms_Balance_Sheet();
        string strRandomMixedId = intAccntId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        int corp = Convert.ToInt32(intcorpid);
        objEntity.FromDate = ObjCommonlib.textToDateTime(intdatefrom.ToString());
        objEntity.ToDate = ObjCommonlib.textToDateTime(intdateto.ToString());
        objEntity.Organisation_id = Convert.ToInt32(intorgid);
        objEntity.Corporate_id = corp;
        objEntity.LedgId = Convert.ToInt32(strId);
        objEntity.Status = Convert.ToInt32(sts);
        objEntity.ShowZerosts = Convert.ToInt32(ShowZero);

        if (strName.Contains("‡") == true)
        {
            strName = strName.Replace("‡", "\"");
        }
        if (strName.Contains("¦") == true)
        {
            strName = strName.Replace("¦", "\'");
        }

        if (LedgSts == "0")
        {
            DataTable dtList = objBussiness.TrailBalance_List_ById(objEntity);
            int StsGrp = 1;
            string Printsts = "0";
            result[1] = obj.LoadConvertToTable(dtList, objEntity, StsGrp, strId, Printsts, intAccntId, sts);
            Printsts = "1";
            //result[4] = obj.LoadConvertToTable(dtList, objEntity, StsGrp, strId, Printsts, intAccntId, sts);
            result[0] = CountRow.ToString();
            result[2] = strId;
            result[3] = obj.PrintCaption(objEntity, strId);
        }
        else
        {
            DataTable dtOpenBalance = objBussiness.ReadLedgOpenBal(objEntity);
            DataTable dtList = objBussiness.LedgerTransDtls(objEntity);
            int StsGrp = 1;
            string Printsts = "0";
            result[1] = obj.LoadConvertToTableLed(dtList, dtOpenBalance, objEntity, StsGrp, strId, Printsts, intAccntId, sts);
            Printsts = "1";
            //result[4] = obj.LoadConvertToTableLed(dtList,dtOpenBalance, objEntity, StsGrp, strId, Printsts, intAccntId, sts);
            if (dtOpenBalance.Rows.Count > 0 && Convert.ToDecimal(dtOpenBalance.Rows[0]["TOTAL_DEB_AMNT"].ToString()) != 0)
            {
                CountRow++;
            }
            result[0] = CountRow.ToString();
            result[2] = strId;
            result[3] = obj.PrintCaption(objEntity, strId);
        }
        return result;

    }
    [WebMethod]
    public static string[] TrailBalance_Lists_ById_Print(string intAccntId, string intuserid, string intorgid, string intcorpid, string intdatefrom, string intdateto, string sts, string LedgSts, string ShowZero, string StrName, string strPrintMode)
    {
        CountRow = 0;
        string[] result = new string[10];
        clsBusinessBalanceSheet objBussiness = new clsBusinessBalanceSheet();
        clsEntityBalanceSheet objEntity = new clsEntityBalanceSheet();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        FMS_FMS_Reports_fms_Balance_Sheet_fms_Balance_Sheet obj = new FMS_FMS_Reports_fms_Balance_Sheet_fms_Balance_Sheet();
        string strRandomMixedId = intAccntId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        int corp = Convert.ToInt32(intcorpid);
        objEntity.FromDate = ObjCommonlib.textToDateTime(intdatefrom.ToString());
        objEntity.ToDate = ObjCommonlib.textToDateTime(intdateto.ToString());
        objEntity.Organisation_id = Convert.ToInt32(intorgid);
        objEntity.Corporate_id = corp;
        objEntity.LedgId = Convert.ToInt32(strId);
        objEntity.Status = Convert.ToInt32(sts);
        objEntity.ShowZerosts = Convert.ToInt32(ShowZero);

        if (StrName.Contains("‡") == true)
        {
            StrName = StrName.Replace("‡", "\"");
        }
        if (StrName.Contains("¦") == true)
        {
            StrName = StrName.Replace("¦", "\'");
        }

        if (LedgSts == "0")
        {
            DataTable dtList = objBussiness.TrailBalance_List_ById(objEntity);
            int StsGrp = 1;
            string Printsts = "0";
            //result[1] = obj.LoadConvertToTable(dtList, objEntity, StsGrp, strId, Printsts, intAccntId, sts);
            Printsts = "1";
            if (strPrintMode == "pdf")
            {
                result[0] = obj.LoadConvertToTable_PDF(dtList, objEntity, StsGrp, strId, Printsts, intAccntId, sts, StrName, intdateto);
            }
            else if (strPrintMode == "csv")
            {
                result[0] = obj.LoadConvertToTable_CSV(dtList, objEntity, StsGrp, strId, Printsts, intAccntId, sts, StrName, intdateto);
            }
        }
        else
        {
            DataTable dtOpenBalance = objBussiness.ReadLedgOpenBal(objEntity);
            DataTable dtList = objBussiness.LedgerTransDtls(objEntity);
            int StsGrp = 1;
            string Printsts = "0";
            Printsts = "1";
            if (strPrintMode == "pdf")
            {
                result[0] = obj.LoadConvertToTableLed_PDF(dtList, dtOpenBalance, objEntity, StsGrp, strId, Printsts, intAccntId, sts, StrName, intdateto);
            }
            else if (strPrintMode == "csv")
            {
                result[0] = obj.LoadConvertToTableLed_CSV(dtList, dtOpenBalance, objEntity, StsGrp, strId, Printsts, intAccntId, sts, StrName, intdateto);
            }
            if (dtOpenBalance.Rows.Count > 0 && Convert.ToDecimal(dtOpenBalance.Rows[0]["TOTAL_DEB_AMNT"].ToString()) != 0)
            {
                CountRow++;
            }
        }
        return result;
    }
    

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        clsEntityBalanceSheet ObjEntityRequest = new clsEntityBalanceSheet();
        clsBusinessBalanceSheet objBussiness = new clsBusinessBalanceSheet();
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
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
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
        if (HiddenFinancialYearFrom.Value != "")
        {
            ObjEntityRequest.FromDate = ObjCommonlib.textToDateTime(HiddenFinancialYearFrom.Value);
        }
        if (txtTodate.Value != "")
        {
            ObjEntityRequest.ToDate = ObjCommonlib.textToDateTime(txtTodate.Value);
        }
        ObjEntityRequest.Status = 0;
        if (cbxCnclStatus.Checked == true)
        {
            HiddenFieldShowZero.Value = "1";
            ObjEntityRequest.ShowZerosts = 1;
        }
        else
        {
            HiddenFieldShowZero.Value = "0";
        }
        DataTable dtAsset = objBussiness.ReadPrimaryGroupDetails(ObjEntityRequest);
        ObjEntityRequest.Status = 1;
        DataTable dtLiability = objBussiness.ReadPrimaryGroupDetails(ObjEntityRequest);
        DataTable dtCategory = objBussiness.ReadProfitLoss(ObjEntityRequest);
        decimal sum_Cedt = 0, sum_debt = 0, NetAmount = 0;
        for (int grscnt = 0; grscnt < dtCategory.Rows.Count; grscnt++)
        {
            if (dtCategory.Rows[grscnt]["ACNT_NATURE_STS"].ToString() == "3")
            {
                sum_debt += Convert.ToDecimal(dtCategory.Rows[grscnt]["TOTAL_DEB_AMNT"]);
            }
            else
            {
                sum_Cedt += Convert.ToDecimal(dtCategory.Rows[grscnt]["TOTAL_CREDIT_AMNT"]);
            }
        }

        string strId = "";
        string Printsts = "0";
        string TypSts = "0";
        string intAccntId = "0";
        divList.InnerHtml = LoadConvertToTable(dtAsset, dtLiability, ObjEntityRequest, strId, Printsts, TypSts, sum_Cedt, sum_debt, intAccntId);
        Printsts = "1";
        // divPrintReport.InnerHtml = LoadConvertToTable(dtAsset, dtLiability, ObjEntityRequest, strId, Printsts, TypSts, sum_Cedt, sum_debt, intAccntId);
        //  divPrintCaption.InnerHtml = PrintCaption(ObjEntityRequest, strId);
    }
    [WebMethod]
    
    public static string[] DecriptId_ById(string intAccntId, string intstrprvId)
    {
        string[] result = new string[10];

        string strRandomMixedId = intAccntId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        result[0] = strId;


        strRandomMixedId = intstrprvId;
        strLenghtofId = strRandomMixedId.Substring(0, 2);
        intLenghtofId = Convert.ToInt16(strLenghtofId);
        strId = strRandomMixedId.Substring(2, intLenghtofId);
        result[1] = strId;


        return result;

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
            headtable.AddCell(new PdfPCell(new Phrase("BALANCE SHEET", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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