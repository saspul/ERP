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

public partial class FMS_FMS_Reports_fms_CostCntr_Performance_fms_CostCntr_Performance : System.Web.UI.Page
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

            clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
            DateTime ToDate = ObjCommonlib.textToDateTime(strCurrentDate);


            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            clsEntityCostGrpPerfAnalysis ObjEntity = new clsEntityCostGrpPerfAnalysis();
            clsBusinessLayerCostGrpPerfAnalysis objBussiness = new clsBusinessLayerCostGrpPerfAnalysis();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                ObjEntity.User_Id = intUserId;
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                ObjEntity.Corporate_id = intCorpId;
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                ObjEntity.Organisation_id = intOrgId;
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenFieldDecmlCnt.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
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

                if (System.DateTime.Now >= ObjCommonlib.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && System.DateTime.Now <= ObjCommonlib.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                {
                    DateTime dtFinStart = ObjCommonlib.textToDateTime(HiddenFinancialYearFrom.Value);
                    if (ToDate.AddDays(-30) > dtFinStart)
                    {
                        txtFromdate.Value = ToDate.AddDays(-30).ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        txtFromdate.Value = HiddenFinancialYearFrom.Value;
                    }
                    txtTodate.Value = ToDate.ToString("dd-MM-yyyy");
                }
            }

            LoadCostCentres();
            LoadCostGroups();

            if (txtFromdate.Value != "")
            {
                ObjEntity.FromDate = ObjCommonlib.textToDateTime(txtFromdate.Value);
            }
            if (txtTodate.Value != "")
            {
                ObjEntity.ToDate = ObjCommonlib.textToDateTime(txtTodate.Value);
            }

            if (radioDetail.Checked == true)
            {
                ObjEntity.Mode = 0;
            }
            else if (radioSummary.Checked == true)
            {
                ObjEntity.Mode = 1;
            }

            if (cbxAllCC.Checked == true)
            {
                ObjEntity.AllCostCentres = 1;
            }

            DataTable dtCategory = objBussiness.ReadCostCenterListCntr(ObjEntity);
            string Printsts = "0";
            if (ObjEntity.Mode == 0)
            {
                divList.InnerHtml = LoadConvertToTable(dtCategory, ObjEntity, Printsts);
            }
            else
            {
                divList.InnerHtml = LoadConvertToTableSummary(dtCategory, ObjEntity, Printsts);
            }
            //Printsts = "1";
            //if (ObjEntity.Mode == 0)
            //{
            //    divPrintReport.InnerHtml = LoadConvertToTable(dtCategory, ObjEntity, Printsts);
            //}
            //else
            //{
            //    divPrintReport.InnerHtml = LoadConvertToTableSummary(dtCategory, ObjEntity, Printsts);
            //}
            //divPrintCaption.InnerHtml = PrintCaption(ObjEntity);
        }

    }

    public void LoadCostCentres()
    {
        clsEntityCostGrpPerfAnalysis ObjEntity = new clsEntityCostGrpPerfAnalysis();
        clsBusinessLayerCostGrpPerfAnalysis objBussiness = new clsBusinessLayerCostGrpPerfAnalysis();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntity.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntity.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dt = objBussiness.ReadCostCentres(ObjEntity);
        if (dt.Rows.Count > 0)
        {
            ddlCostCentre.DataSource = dt;
            ddlCostCentre.DataTextField = "COSTCNTR_NAME";
            ddlCostCentre.DataValueField = "COSTCNTR_ID";
            ddlCostCentre.DataBind();
        }
    }

    public void LoadCostGroups()
    {
        clsEntityCostGrpPerfAnalysis ObjEntity = new clsEntityCostGrpPerfAnalysis();
        clsBusinessLayerCostGrpPerfAnalysis objBussiness = new clsBusinessLayerCostGrpPerfAnalysis();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntity.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntity.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dt = objBussiness.ReadCostGroups(ObjEntity);
        if (dt.Rows.Count > 0)
        {
            ddlCostGrp.DataSource = dt;
            ddlCostGrp.DataTextField = "COSTGRP_NAME";
            ddlCostGrp.DataValueField = "COSTGRP_ID";
            ddlCostGrp.DataBind();
        }
    }

    public string PrintCaption(clsEntityCostGrpPerfAnalysis ObjEntityRequest)
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
        strTitle = "COST CENTRE PERFORMANCE ANALYSIS";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string usrName = "<B> Report Generated By: </B>" + Session["USERFULLNAME"];
        //for printing product division on print
        string strHidden = "", GuaranteDivsn = "", GuaranteCatgry = "", GuaranteBank = ""; ;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        GuaranteDivsn = "<B>FROM DATE  : </B>" + ObjEntityRequest.FromDate.ToString("dd-MMM-yyyy");
        GuaranteCatgry = "<B>TO DATE: </B>" + ObjEntityRequest.ToDate.ToString("dd-MMM-yyyy");
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
        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strGuaranteDivsn + strGuaranteCatgry + strGuaranteBank + strUsrName + strCaptionTabTitle + strCaptionTabstop;


        sbCap.Append(strPrintCaptionTable);
        return sbCap.ToString();


    }

    //detail table
    public string LoadConvertToTable(DataTable dtCategory1, clsEntityCostGrpPerfAnalysis ObjEntityRequest, string Printsts)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        int Decimalcount = 0;
        intCorpId = ObjEntityRequest.Corporate_id;
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


        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        string strHtml = "";
        if (Printsts == "0")
        {
            strHtml = "<table id=\"datatable_fixed_column\" class=\"table-bordered\" width=\"100%\" >";
            //add header row
            strHtml += "<thead class=\"thead1\">";
            strHtml += "<tr >";
            strHtml += "<th class=\"col-md-1 td1\">DATE";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-2 td1\" >REF#";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-5 tr_l\" >ACCOUNT NAME";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-2 tr_r\" >DR AMOUNT";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-2 tr_r\" >CR AMOUNT";
            strHtml += "</th >";
            strHtml += "</tr>";
            strHtml += "</thead>";
        }
        else
        {
            strHtml = "<table id=\"PrintTable\" class=\"tab\" \">";
            strHtml += "<thead>";
            strHtml += "<tr class=\"top_row\">";
            strHtml += "<th class=\"thT\" style=\"width:10%;text-align:left;\">DATE";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:35%;text-align:left;\">REF#";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:15%;text-align:left;\">ACCOUNT NAME";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:20%;text-align:right;\">DR AMOUNT";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:20%;text-align:right;\">CR AMOUNT";
            strHtml += "</th >";
            strHtml += "</tr>";
            strHtml += "</thead>";
        }
        //add rows

        strHtml += "<tbody>";


        DataView view = new DataView(dtCategory1);
        DataTable dtCategory = new DataTable();
        if (dtCategory1.Rows.Count > 0)
        {
            dtCategory = view.ToTable(true, "COSTCNTR_ID", "COSTCNTR_NAME", "TOTAL_DEBIT_AMNT", "TOTAL_CREDIT_AMNT");
        }

        decimal decTotal = 0;

        for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr>";
            strHtml += "<th></th><th class=\"tr_l\">" + dtCategory.Rows[intRowBodyCount]["COSTCNTR_NAME"].ToString() + "</th>";
            strHtml += "<th></th><th></th><th></th>";
            strHtml += "</tr>";
            decimal sum_Cedt = 0, sum_debt = 0;
            DataRow[] result = dtCategory1.Select("COSTCNTR_ID =" + dtCategory.Rows[intRowBodyCount]["COSTCNTR_ID"].ToString() + "");
            foreach (DataRow row in result)
            {
                string strNetAmountDebitComma = "";
                decimal NetAmount = 0;
                NetAmount = Convert.ToDecimal(row["CC_VOCHR_AMT"].ToString());

                if (row["CC_VOCHR_STS"].ToString() == "0")
                {
                    sum_debt += NetAmount;
                    decTotal = decTotal + NetAmount;
                }
                else
                {
                    sum_Cedt += NetAmount;
                    decTotal = decTotal - NetAmount;
                }
                strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                strHtml += "<tr>";
                strHtml += "<td class=\"tr_l\"  >" + row["CC_VOCHR_DATE"].ToString() + "</td>";
                strHtml += "<td class=\"tr_l\"  >" + row["CC_VOCHR_REF"].ToString() + "</td>";
                strHtml += "<td class=\"tr_l\"  >" + row["LDGR_NAME"].ToString() + "</td>";
                //strHtml += "<td class=\"tr_l\"  >" + row["VOCHR_TYPE"].ToString() + "</td>";
                if (row["CC_VOCHR_STS"].ToString() == "0")
                {
                    strHtml += "<td class=\"tr_r\"  >" + strNetAmountDebitComma + "</td>";
                    strHtml += "<td class=\"tdT\"  ></td>";
                }
                else
                {
                    strHtml += "<td class=\"tdT\"  ></td>";
                    strHtml += "<td class=\"tr_r\"  > " + strNetAmountDebitComma + "</td>";
                }
                strHtml += "</tr>";
            }
            string StrDebAmnt = "", StrCreAmnt = "";
            int MoneyCnt = Convert.ToInt32(HiddenFieldDecmlCnt.Value);
            string format = String.Format("{{0:N{0}}}", MoneyCnt);
            if (sum_debt == 0)
            {
                StrDebAmnt = String.Format(format, sum_debt);
            }
            else
            {
                StrDebAmnt = objBusiness.AddCommasForNumberSeperation(sum_debt.ToString(), objEntityCommon);
            }
            if (sum_Cedt == 0)
            {
                StrCreAmnt = String.Format(format, sum_Cedt);
            }
            else
            {
                StrCreAmnt = objBusiness.AddCommasForNumberSeperation(sum_Cedt.ToString(), objEntityCommon);
            }
            strHtml += "<tr class=\"tr1\">";
            strHtml += "<td class=\"tdT\"  ></td>";
            strHtml += "<td class=\"tdT\" ></td>";
            strHtml += "<td class=\"tr_r\" >Total</td>";
            strHtml += "<td class=\"tr_r\" >" + StrDebAmnt + "</td>";
            strHtml += "<td class=\"tr_r\" > " + StrCreAmnt + "</td>";
            strHtml += "</tr>";

        }

        //string StrTotalAmnt = "";
        //if (dtCategory.Rows.Count > 0)
        //{
        //    if (decTotal < 0)
        //    {
        //        StrTotalAmnt = objBusiness.AddCommasForNumberSeperation((0 - decTotal).ToString(), objEntityCommon) + " CR";
        //    }
        //    else
        //    {
        //        StrTotalAmnt = objBusiness.AddCommasForNumberSeperation(decTotal.ToString(), objEntityCommon) + " DR";
        //    }
        //    if (Printsts == "0")
        //    {
        //        strHtml += "<tfoot><tr>";
        //        strHtml += "<td class=\"txt_rd bg1\" ></td>";
        //        strHtml += "<td class=\"txt_rd bg1 tr_l\"  >Total Profit/Loss</td>";
        //        strHtml += "<td class=\"txt_rd bg1\" ></td>";
        //        strHtml += "<td class=\"txt_rd bg1\" ></td>";
        //        strHtml += "<td class=\"tr_r txt_rd bg1\" >" + StrTotalAmnt + "</td>";
        //        strHtml += "</tr>";
        //        strHtml += "</tfoot>";
        //    }
        //    else
        //    {
        //        strHtml += "<tfoot><tr>";
        //        strHtml += "<td colspan=\"4\" class=\"tr_r\" >Total Profit/Loss</td>";
        //        strHtml += "<td class=\"tr_r\" >" + StrTotalAmnt + "</td>";
        //        strHtml += "</tr>";
        //        strHtml += "</tfoot>";
        //    }
        //}

        if (Printsts == "1" && dtCategory.Rows.Count == 0)
        {
            strHtml += " <tr>";
            strHtml += "<td class=\"tdT\" colspan=\"5\" style=\" width:100%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available in table</td>";
            strHtml += "</tr>";
        }
        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);

        return sb.ToString();
    }
    public string LoadConvertToTable_PDF(DataTable dtCategory1, clsEntityCostGrpPerfAnalysis ObjEntityRequest, string DecimaCount, string selCGroup, string selCostCentre, string Mode, string datefrom, string dateto)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        int Decimalcount = 0;
        intCorpId = ObjEntityRequest.Corporate_id;
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


        string strRandom = objCommon.Random_Number();
        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.COST_CENTRE_PERFOMANCE_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.COST_CENTRE_PERFOMANCE_PDF);
        objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "CCPerfomancDet_" + strNextNumber + ".pdf";

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

                //filter section
                PdfPTable footrtable = new PdfPTable(3);
                float[] footrsBody1 = { 15, 5, 80 };
                footrtable.SetWidths(footrsBody1);
                footrtable.WidthPercentage = 100;

                footrtable.AddCell(new PdfPCell(new Phrase("FROM DATE ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(datefrom, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase("TO DATE ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(dateto, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (selCGroup != "")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("COST GROUP", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(selCGroup.TrimEnd(',', ' '), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (selCostCentre != "")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("COST CENTRE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(selCostCentre.TrimEnd(',',' '), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                footrtable.AddCell(new PdfPCell(new Phrase("MODE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (Mode == "0")
                    footrtable.AddCell(new PdfPCell(new Phrase("DETAILED", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                else
                    footrtable.AddCell(new PdfPCell(new Phrase("SUMMARY", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                document.Add(footrtable);
                
                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(5);
                float[] footrsBody = { 15, 15, 30, 20, 20 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;//get header column in all pages

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("DATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("REF#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("ACCOUNT NAME", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("DR AMOUNT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("CR AMOUNT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                
                DataView view = new DataView(dtCategory1);
                DataTable dtCategory = new DataTable();
                if (dtCategory1.Rows.Count > 0)
                {
                    dtCategory = view.ToTable(true, "COSTCNTR_ID", "COSTCNTR_NAME", "TOTAL_DEBIT_AMNT", "TOTAL_CREDIT_AMNT");
                }
                decimal decTotal = 0;
                for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["COSTCNTR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray ,Colspan=2});
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    decimal sum_Cedt = 0, sum_debt = 0;
                    DataRow[] result = dtCategory1.Select("COSTCNTR_ID =" + dtCategory.Rows[intRowBodyCount]["COSTCNTR_ID"].ToString() + "");
                    foreach (DataRow row in result)
                    {
                        string strNetAmountDebitComma = "";
                        decimal NetAmount = 0;
                        NetAmount = Convert.ToDecimal(row["CC_VOCHR_AMT"].ToString());

                        if (row["CC_VOCHR_STS"].ToString() == "0")
                        {
                            sum_debt += NetAmount;
                            decTotal = decTotal + NetAmount;
                        }
                        else
                        {
                            sum_Cedt += NetAmount;
                            decTotal = decTotal - NetAmount;
                        }
                        strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                        TBCustomer.AddCell(new PdfPCell(new Phrase(row["CC_VOCHR_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(row["CC_VOCHR_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(row["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        if (row["CC_VOCHR_STS"].ToString() == "0")
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountDebitComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                        else
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountDebitComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                    }
                    string StrDebAmnt = "", StrCreAmnt = "";
                    int MoneyCnt = Convert.ToInt32(DecimaCount);
                    string format = String.Format("{{0:N{0}}}", MoneyCnt);
                    if (sum_debt == 0)
                    {
                        StrDebAmnt = String.Format(format, sum_debt);
                    }
                    else
                    {
                        StrDebAmnt = objBusiness.AddCommasForNumberSeperation(sum_debt.ToString(), objEntityCommon);
                    }
                    if (sum_Cedt == 0)
                    {
                        StrCreAmnt = String.Format(format, sum_Cedt);
                    }
                    else
                    {
                        StrCreAmnt = objBusiness.AddCommasForNumberSeperation(sum_Cedt.ToString(), objEntityCommon);
                    }
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(StrDebAmnt, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(StrCreAmnt, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                }
                if (dtCategory.Rows.Count == 0)
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase("No data available", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray,Colspan=5 });
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
    public string LoadTable_CSV(DataTable dtCategory, clsEntityCostGrpPerfAnalysis ObjEntityRequest, string selCGroup, string selCostCentre, string Mode, string datefrom, string dateto)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        DataTable dt = GetTable(dtCategory, ObjEntityRequest, selCGroup, selCostCentre, Mode, datefrom, dateto);
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


        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.COST_CENTRE_PERFOMANCE_CSV);
        string strNextId = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string newFilePath = Server.MapPath("/CustomFiles/FMS CSV/Cost Centre Perfomance/Cost_Centre_Perfomance_" + strNextId + ".csv");
        System.IO.File.WriteAllText(newFilePath, strResult);
        filepath = "Cost_Centre_Perfomance_" + strNextId + ".csv";
        strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.COST_CENTRE_PERFOMANCE_CSV);
        return strImagePath + filepath;
    }
    public DataTable GetTable(DataTable dt, clsEntityCostGrpPerfAnalysis ObjEntityRequest, string selCGroup, string selCostCentre, string Mode, string datefrom, string dateto)
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

        //Detail Section
        if (Mode == "0")
        {
            table.Columns.Add("COST CENTRE PERFOMANCE REPORT", typeof(string));
            table.Columns.Add(" ", typeof(string));
            table.Columns.Add("  ", typeof(string));
            table.Columns.Add("   ", typeof(string));
            table.Columns.Add("    ", typeof(string));

            table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
            table.Rows.Add("FROM DATE :", '"' + datefrom + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
            table.Rows.Add("TO DATE :", '"' + dateto + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
            if (selCGroup != "")
                table.Rows.Add("COST GROUP :", '"' + selCGroup.TrimEnd(',', ' ') + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
            if (selCostCentre != "")
                table.Rows.Add("COST CENTRE :", '"' + selCostCentre.TrimEnd(',', ' ') + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
            if (Mode == "0")
                table.Rows.Add("MODE :", "DETAILED", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
            table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

            DataView view = new DataView(dt);
            DataTable dtCategory = new DataTable();
            if (dt.Rows.Count > 0)
            {
                dtCategory = view.ToTable(true, "COSTCNTR_ID", "COSTCNTR_NAME", "TOTAL_DEBIT_AMNT", "TOTAL_CREDIT_AMNT");
            }
            if (dtCategory.Rows.Count > 0)
            {
                table.Rows.Add("DATE", "REF#", "ACCOUNT NAME", "DR AMOUNT", "CR AMOUNT");
            }
            else
            {
                table.Rows.Add("DATE", "REF#", "ACCOUNT NAME", "DR AMOUNT", "CR AMOUNT");
            }

            decimal decTotal = 0;
            for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
            {
                table.Rows.Add('"' + FORNULL + '"', '"' + dtCategory.Rows[intRowBodyCount]["COSTCNTR_NAME"].ToString() + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
                decimal sum_Cedt = 0, sum_debt = 0;
                DataRow[] result = dt.Select("COSTCNTR_ID =" + dtCategory.Rows[intRowBodyCount]["COSTCNTR_ID"].ToString() + "");
                foreach (DataRow row in result)
                {
                    decimal NetAmount = 0;
                    NetAmount = Convert.ToDecimal(row["CC_VOCHR_AMT"].ToString());
                    if (row["CC_VOCHR_STS"].ToString() == "0")
                    {
                        sum_debt += NetAmount;
                        decTotal = decTotal + NetAmount;
                    }
                    else
                    {
                        sum_Cedt += NetAmount;
                        decTotal = decTotal - NetAmount;
                    }
                    string strNetAmountDebit = "", strNetAmountCredit = "";
                    if (row["CC_VOCHR_STS"].ToString() == "0")
                    {
                        strNetAmountDebit = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                    }
                    else
                    {
                        strNetAmountCredit = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                    }
                    table.Rows.Add('"' + row["CC_VOCHR_DATE"].ToString() + '"', '"' + row["CC_VOCHR_REF"].ToString() + '"', '"' + row["LDGR_NAME"].ToString() + '"', '"' + strNetAmountDebit + '"', '"' + strNetAmountCredit + '"');
                }

                string StrDebAmnt = "", StrCreAmnt = "";
                int MoneyCnt = Convert.ToInt32(Decimalcount);
                string format = String.Format("{{0:N{0}}}", MoneyCnt);
                if (sum_debt == 0)
                {
                    StrDebAmnt = String.Format(format, sum_debt);
                }
                else
                {
                    StrDebAmnt = objBusiness.AddCommasForNumberSeperation(sum_debt.ToString(), objEntityCommon);
                }
                if (sum_Cedt == 0)
                {
                    StrCreAmnt = String.Format(format, sum_Cedt);
                }
                else
                {
                    StrCreAmnt = objBusiness.AddCommasForNumberSeperation(sum_Cedt.ToString(), objEntityCommon);
                }
                table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', "Total", '"' + StrDebAmnt + '"', '"' + StrCreAmnt + '"');
            }
        }//Detail Section end

        //Summery Section
        if (Mode == "1")
        {
            table.Columns.Add("COST CENTRE PERFOMANCE REPORT", typeof(string));
            table.Columns.Add(" ", typeof(string));
            table.Columns.Add("  ", typeof(string));
            table.Columns.Add("   ", typeof(string));

            table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
            table.Rows.Add("FROM DATE :", '"' + datefrom + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
            table.Rows.Add("TO DATE :", '"' + dateto + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
            if (selCGroup != "")
                table.Rows.Add("COST GROUP :", '"' + selCGroup.TrimEnd(',', ' ') + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
            if (selCostCentre != "")
                table.Rows.Add("COST CENTRE :", '"' + selCostCentre.TrimEnd(',', ' ') + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
            if (Mode == "1")
                table.Rows.Add("MODE :", "SUMMARY", '"' + FORNULL + '"', '"' + FORNULL + '"');
            table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

            table.Rows.Add("COST CENTRE", "INCOME", "EXPENSE", "PROFIT/LOSS");

            DataView view = new DataView(dt);
            DataTable dtCategory = new DataTable();
            if (dt.Rows.Count > 0)
            {
                dtCategory = view.ToTable(true, "COSTCNTR_ID", "COSTCNTR_NAME", "TOTAL_DEBIT_AMNT", "TOTAL_CREDIT_AMNT");
            }
            decimal decTotal = 0;
            for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
            {
                string StrDebAmnt = objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["TOTAL_DEBIT_AMNT"].ToString(), objEntityCommon);
                string StrCreAmnt = objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString(), objEntityCommon);
                decimal ProftLoss = Convert.ToDecimal(StrDebAmnt) - Convert.ToDecimal(StrCreAmnt);
                string strProfitLoss = "";
                if (ProftLoss > 0)
                {
                    strProfitLoss = ProftLoss.ToString() + " DR";
                }
                else
                {
                    strProfitLoss = (0 - ProftLoss).ToString() + " CR";
                }
                table.Rows.Add('"' + dtCategory.Rows[intRowBodyCount]["COSTCNTR_NAME"].ToString() + '"', '"' + StrDebAmnt + '"', '"' + StrCreAmnt + '"', '"' + strProfitLoss + '"');
                decTotal = decTotal + ProftLoss;
            }

            string StrTotalAmnt = "";
            if (dtCategory.Rows.Count > 0)
            {
                if (decTotal < 0)
                {
                    StrTotalAmnt = objBusiness.AddCommasForNumberSeperation((0 - decTotal).ToString(), objEntityCommon) + " CR";
                }
                else
                {
                    StrTotalAmnt = objBusiness.AddCommasForNumberSeperation(decTotal.ToString(), objEntityCommon) + " DR";
                }
                table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', "Total Profit/Loss", '"' + StrTotalAmnt + '"');
            }
        } ////Summery Section end       
        return table;
    }
    
    //summary table
    public string LoadConvertToTableSummary(DataTable dtCategory1, clsEntityCostGrpPerfAnalysis ObjEntityRequest, string Printsts)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        int Decimalcount = 0;
        intCorpId = ObjEntityRequest.Corporate_id;
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


        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        string strHtml = "";
        if (Printsts == "0")
        {
            strHtml = "<table id=\"datatable_fixed_column\" class=\"display table-bordered\" width=\"100%\" >";
            //add header row
            strHtml += "<thead class=\"thead1\">";
            strHtml += "<tr >";
            strHtml += "<th class=\"col-md-5 td1 tr_l\" >COST CENTRE";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-2 tr_r\" >INCOME";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-2 tr_r\" >EXPENSE";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-3 tr_r\" >PROFIT/LOSS";
            strHtml += "</th >";
            strHtml += "</tr>";
            strHtml += "</thead>";
        }
        else
        {
            strHtml = "<table id=\"PrintTable\" class=\"tab\" \" >";
            //add header row
            strHtml += "<thead class=\"thead1\">";
            strHtml += "<tr class=\"top_row\">";
            strHtml += "<th class=\"col-md-5 td1 tr_l\" >COST CENTRE";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-2 tr_r\" >INCOME";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-2 tr_r\" >EXPENSE";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-3 tr_r\" >PROFIT/LOSS";
            strHtml += "</th >";
            strHtml += "</tr>";
            strHtml += "</thead>";
        }

        strHtml += "<tbody>";

        DataView view = new DataView(dtCategory1);
        DataTable dtCategory = new DataTable();
        if (dtCategory1.Rows.Count > 0)
        {
            dtCategory = view.ToTable(true, "COSTCNTR_ID", "COSTCNTR_NAME", "TOTAL_DEBIT_AMNT", "TOTAL_CREDIT_AMNT");
        }
        decimal decTotal = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tr_l\">" + dtCategory.Rows[intRowBodyCount]["COSTCNTR_NAME"].ToString() + "</td>";

            string StrDebAmnt = objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["TOTAL_DEBIT_AMNT"].ToString(), objEntityCommon);
            string StrCreAmnt = objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString(), objEntityCommon);

            decimal ProftLoss = Convert.ToDecimal(StrDebAmnt) - Convert.ToDecimal(StrCreAmnt);

            strHtml += "<td class=\"tr_r\">" + StrDebAmnt + "</td>";
            strHtml += "<td class=\"tr_r\">" + StrCreAmnt + "</td>";
            if (ProftLoss > 0)
            {
                strHtml += "<td class=\"tr_r\">" + ProftLoss.ToString() + " DR</td>";
            }
            else
            {
                strHtml += "<td class=\"tr_r\">" + (0 - ProftLoss).ToString() + " CR</td>";
            }
            decTotal = decTotal + ProftLoss;

            strHtml += "</tr>";
        }

        string StrTotalAmnt = "";
        if (dtCategory.Rows.Count > 0)
        {
            if (decTotal < 0)
            {
                StrTotalAmnt = objBusiness.AddCommasForNumberSeperation((0 - decTotal).ToString(), objEntityCommon) + " CR";
            }
            else
            {
                StrTotalAmnt = objBusiness.AddCommasForNumberSeperation(decTotal.ToString(), objEntityCommon) + " DR";
            }
            if (Printsts == "0")
            {
                strHtml += "<tfoot><tr>";
                strHtml += "<td class=\"txt_rd bg1 tr_l\"  >Total Profit/Loss</td>";
                strHtml += "<td class=\"txt_rd bg1\" ></td>";
                strHtml += "<td class=\"txt_rd bg1\" ></td>";
                strHtml += "<td class=\"tr_r txt_rd bg1\" >" + StrTotalAmnt + "</td>";
                strHtml += "</tr>";
                strHtml += "</tfoot>";
            }
            else
            {
                strHtml += "<tfoot><tr>";
                strHtml += "<td colspan=\"3\" class=\"tr_r\" >Total Profit/Loss</td>";
                strHtml += "<td class=\"tr_r\" >" + StrTotalAmnt + "</td>";
                strHtml += "</tr>";
                strHtml += "</tfoot>";
            }
        }

        if (Printsts == "1" && dtCategory.Rows.Count == 0)
        {
            strHtml += " <tr>";
            strHtml += "<td class=\"tdT\" colspan=\"4\" style=\" width:100%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available in table</td>";
            strHtml += "</tr>";
        }
        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);

        return sb.ToString();
    }
    public string LoadConvertToTableSummary_PDF(DataTable dtCategory1, clsEntityCostGrpPerfAnalysis ObjEntityRequest, string Printsts, string selCGroup, string selCostCentre, string Mode, string datefrom, string dateto)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        int Decimalcount = 0;
        intCorpId = ObjEntityRequest.Corporate_id;
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
        string strRandom = objCommon.Random_Number();
        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.COST_CENTRE_PERFOMANCE_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.COST_CENTRE_PERFOMANCE_PDF);
        objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "CCPerfomanceSumry_" + strNextNumber + ".pdf";

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

                //filter section
                PdfPTable footrtable = new PdfPTable(3);
                float[] footrsBody1 = { 15, 5, 80 };
                footrtable.SetWidths(footrsBody1);
                footrtable.WidthPercentage = 100;

                footrtable.AddCell(new PdfPCell(new Phrase("FROM DATE ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(datefrom, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase("TO DATE ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(dateto, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (selCGroup != "")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("COST GROUP", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(selCGroup.TrimEnd(',', ' '), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (selCostCentre != "")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("COST CENTRE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(selCostCentre.TrimEnd(',', ' '), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                footrtable.AddCell(new PdfPCell(new Phrase("MODE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (Mode == "0")
                    footrtable.AddCell(new PdfPCell(new Phrase("DETAILED", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                else
                    footrtable.AddCell(new PdfPCell(new Phrase("SUMMARY", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                document.Add(footrtable);
                
                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(4);
                float[] footrsBody = { 30, 20, 20, 30 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;//get header column in all pages

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);

                TBCustomer.AddCell(new PdfPCell(new Phrase("COST CENTRE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("INCOME", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("EXPENSE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("PROFIT/LOSS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                DataView view = new DataView(dtCategory1);
                DataTable dtCategory = new DataTable();
                if (dtCategory1.Rows.Count > 0)
                {
                    dtCategory = view.ToTable(true, "COSTCNTR_ID", "COSTCNTR_NAME", "TOTAL_DEBIT_AMNT", "TOTAL_CREDIT_AMNT");
                }
                decimal decTotal = 0;
                for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["COSTCNTR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    string StrDebAmnt = objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["TOTAL_DEBIT_AMNT"].ToString(), objEntityCommon);
                    string StrCreAmnt = objBusiness.AddCommasForNumberSeperation(dtCategory.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString(), objEntityCommon);
                    decimal ProftLoss = Convert.ToDecimal(StrDebAmnt) - Convert.ToDecimal(StrCreAmnt);
                    TBCustomer.AddCell(new PdfPCell(new Phrase(StrDebAmnt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(StrCreAmnt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    if (ProftLoss > 0)
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase(ProftLoss.ToString() + " DR", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }
                    else
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase((0 - ProftLoss).ToString() + " CR", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }
                    decTotal = decTotal + ProftLoss;
                }

                string StrTotalAmnt = "";
                if (dtCategory.Rows.Count > 0)
                {
                    if (decTotal < 0)
                    {
                        StrTotalAmnt = objBusiness.AddCommasForNumberSeperation((0 - decTotal).ToString(), objEntityCommon) + " CR";
                    }
                    else
                    {
                        StrTotalAmnt = objBusiness.AddCommasForNumberSeperation(decTotal.ToString(), objEntityCommon) + " DR";
                    }
                    TBCustomer.AddCell(new PdfPCell(new Phrase("Total Profit/Loss", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGray, BorderColor = FontGray, Colspan = 3 });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(StrTotalAmnt, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGray, BorderColor = FontGray });
                }
                if (dtCategory.Rows.Count == 0)
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase("No data available", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 4 });
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

    //check which print
    [WebMethod]
    public static string List_Print(string selCGroup, string selCostCentre, string Allcc, string Mode, string CC, string CG, string intuserid, string intorgid, string intcorpid, string datefrom, string dateto, string DecimaCount, string strPrintMode)
    {
        string result = "";
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        clsEntityCostGrpPerfAnalysis ObjEntity = new clsEntityCostGrpPerfAnalysis();
        clsBusinessLayerCostGrpPerfAnalysis objBussiness = new clsBusinessLayerCostGrpPerfAnalysis();
        ObjEntity.User_Id = Convert.ToInt32(intuserid);
        ObjEntity.Corporate_id = Convert.ToInt32(intcorpid);
        ObjEntity.Organisation_id = Convert.ToInt32(intorgid);
        ObjEntity.FromDate = ObjCommonlib.textToDateTime(datefrom);
        ObjEntity.ToDate = ObjCommonlib.textToDateTime(dateto);
        ObjEntity.AllCostCentres = Convert.ToInt32(Allcc);
        ObjEntity.CostCentreIds = CC;
        ObjEntity.CostGrpIds = CG;
        ObjEntity.Mode = Convert.ToInt32(Mode);
        FMS_FMS_Reports_fms_CostCntr_Performance_fms_CostCntr_Performance OBJ = new FMS_FMS_Reports_fms_CostCntr_Performance_fms_CostCntr_Performance();
        DataTable dtCategory = objBussiness.ReadCostCenterListCntr(ObjEntity);
        string Printsts = "0";

        Printsts = "1";
        if (strPrintMode == "pdf")
        {
            if (ObjEntity.Mode == 0)
            {
                result = OBJ.LoadConvertToTable_PDF(dtCategory, ObjEntity, DecimaCount, selCGroup, selCostCentre, Mode, datefrom, dateto);
            }
            else
            {
                result = OBJ.LoadConvertToTableSummary_PDF(dtCategory, ObjEntity, Printsts, selCGroup, selCostCentre, Mode, datefrom, dateto);
            }
        }
        else if ((strPrintMode == "csv"))
        {
            result = OBJ.LoadTable_CSV(dtCategory, ObjEntity, selCGroup, selCostCentre, Mode, datefrom, dateto);
        }
        return result;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        clsEntityCostGrpPerfAnalysis ObjEntity = new clsEntityCostGrpPerfAnalysis();
        clsBusinessLayerCostGrpPerfAnalysis objBussiness = new clsBusinessLayerCostGrpPerfAnalysis();
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntity.User_Id = intUserId;
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            ObjEntity.Corporate_id = intCorpId;
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            ObjEntity.Organisation_id = intOrgId;
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (txtFromdate.Value != "")
        {
            ObjEntity.FromDate = ObjCommonlib.textToDateTime(txtFromdate.Value);
        }
        if (txtTodate.Value != "")
        {
            ObjEntity.ToDate = ObjCommonlib.textToDateTime(txtTodate.Value);
        }
        ObjEntity.CostCentreIds = hiddenCostCentrIds.Value;
        ObjEntity.CostGrpIds = hiddenCostGrpIds.Value;
        if (cbxAllCC.Checked == true)
        {
            ObjEntity.AllCostCentres = 1;
        }

        if (radioDetail.Checked == true)
        {
            ObjEntity.Mode = 0;
        }
        else if (radioSummary.Checked == true)
        {
            ObjEntity.Mode = 1;
        }

        DataTable dtCategory = objBussiness.ReadCostCenterListCntr(ObjEntity);

        string Printsts = "0";
        if (ObjEntity.Mode == 0)
        {
            divList.InnerHtml = LoadConvertToTable(dtCategory, ObjEntity, Printsts);
        }
        else
        {
            divList.InnerHtml = LoadConvertToTableSummary(dtCategory, ObjEntity, Printsts);
        }
        //Printsts = "1";
        //if (ObjEntity.Mode == 0)
        //{
        //    divPrintReport.InnerHtml = LoadConvertToTable(dtCategory, ObjEntity, Printsts);
        //}
        //else
        //{
        //    divPrintReport.InnerHtml = LoadConvertToTableSummary(dtCategory, ObjEntity, Printsts);
        //}

        //divPrintCaption.InnerHtml = PrintCaption(ObjEntity);
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
            headtable.AddCell(new PdfPCell(new Phrase("COST CENTRE PERFOMANCE REPORT", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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
            PdfPTable headImg = new PdfPTable(3);
            string strImageLogo = "/Images/Design_Images/images/Compztlogo.png";
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

}