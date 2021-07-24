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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Newtonsoft.Json;
using BL_Compzit.BusinessLayer_GMS;

public partial class FMS_FMS_Master_fms_Profit_and_Loss_account_fms_Profit_and_Loss_account : System.Web.UI.Page
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
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

         

            HiddenCount.Value = "0";
            clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
            string Strdatenow = objBusinessLayer.LoadCurrentDateInString();
            DateTime ToDate = ObjCommonlib.textToDateTime(Strdatenow);

            // LeadgerLoad();
             clsEntityCommon objentcommn = new clsEntityCommon();
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            clsEntityProfitAndLossAccount ObjEntityRequest = new clsEntityProfitAndLossAccount();
            clsBusinessProfitAndLossAccount objBussiness = new clsBusinessProfitAndLossAccount();


            DateTime curdate = ObjCommonlib.textToDateTime(objBusinessLayer.LoadCurrentDateInString());

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
                objentcommn.CorporateID=intCorpId;
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
                objentcommn.Organisation_Id= intOrgId;
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            clsCommonLibrary objCommon = new clsCommonLibrary();
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
            
            int StsGrp = 0;

            if (Session["FINCYRID"] != null)
            {
                objentcommn.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            DataTable dtfinaclYear = objBusinessLayer.ReadFinancialYearById(objentcommn);

            HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
            HiddenEndDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();

            if (dtfinaclYear.Rows.Count > 0)
            {
                HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                HiddenEndDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();

                if (curdate >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate <= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                {
                    DateTime ToDateFin = ObjCommonlib.textToDateTime(HiddenEndDate.Value);
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
                else if (curdate >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                {
                    txtTodate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                    HiddenFieldNewToDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                }
                else if (curdate <= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()))
                {
                    HiddenFieldNewToDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                    txtTodate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                }
                if (txtTodate.Value != "")
                {
                    ObjEntityRequest.ToDate = ObjCommonlib.textToDateTime(txtTodate.Value);
                }

                //--from date--
                if (curdate >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate <= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                {
                    if (curdate.AddDays(-30) >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()))
                    {
                        txtFromDate.Value = curdate.AddDays(-30).ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        txtFromDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                    }
                }
                else
                {
                    curdate = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString());
                    txtFromDate.Value = curdate.AddDays(-30).ToString("dd-MM-yyyy");
                }

                if (txtFromDate.Value != "")
                {
                    ObjEntityRequest.FromDate = ObjCommonlib.textToDateTime(txtFromDate.Value);
                }

            }
            HiddenFieldSearchDate.Value = txtTodate.Value;

            DataTable dtCategory = objBussiness.ProfitAndLossAcnt_List(ObjEntityRequest);
          
           // DataTable dtCategory = new DataTable();
            string strId = "";
            string Printsts = "0";
            string TypSts = "0";
            string intAccntId = "0";
            divList.InnerHtml = LoadConvertToTable(dtCategory, ObjEntityRequest, StsGrp, strId, Printsts, TypSts, intAccntId);
            Printsts = "1";
            dtCategory = objBussiness.ProfitAndLossAcnt_List(ObjEntityRequest);
          //  divPrintReport.InnerHtml = LoadConvertToTable(dtCategory, ObjEntityRequest, StsGrp, strId, Printsts, TypSts, intAccntId);
            //dtCategory = objBussiness.ProfitAndLossAcnt_List(ObjEntityRequest);
            //divPrintCaption.InnerHtml = PrintCaption(ObjEntityRequest, StsGrp, strId);
        }

    }

    public string PrintCaption(clsEntityProfitAndLossAccount ObjEntityRequest, int StsGrp, string strId1)
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
        strTitle = "PROFIT AND LOSS ACCOUNT";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string usrName = "<B> Report Generated By: </B>" + Session["USERFULLNAME"];
        string strHidden = "", GuaranteDivsn = "", GuaranteCatgry = "", GuaranteBank = ""; ;
        clsCommonLibrary objCommon = new clsCommonLibrary();
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

    //Main
    public string LoadConvertToTable(DataTable dtCategory, clsEntityProfitAndLossAccount ObjEntityRequest, int StsGrp, string strId1, string Printsts, string TypSts, string intAccntId)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        DataTable dtCategory1 = dtCategory;
        clsBusinessLayer objBusiness = new clsBusinessLayer();


        int intCorpId = 0, intOrgId = 0, intUserId = 0;

        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            ObjEntityRequest.Corporate_id = intCorpId;


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



        int intCount = 0;

        decimal sum_Cedt = 0, sum_debt = 0;
    
        for (int grscnt = 0; grscnt < dtCategory.Rows.Count; grscnt++)
        {
            if (dtCategory.Rows[grscnt]["ACNT_NATURE_STS"].ToString() == "2")
            {
                sum_debt += Convert.ToDecimal(dtCategory.Rows[grscnt]["TOTAL_DEB_AMNT"]);
            }
            else
            {
                sum_Cedt += Convert.ToDecimal(dtCategory.Rows[grscnt]["TOTAL_CREDIT_AMNT"]);
            }
        }
        int stsflg = 0;

        string strRandom = objCommon.Random_Number();

        StringBuilder sb = new StringBuilder();
        string strHtml = "";
        // class="table table-bordered table-striped"
        if (Printsts == "0")
        {
            //strHtml = "<table id=\"datatable_fixed_column" + strId1 + "\" class=\"display table-bordered\" width=\"100%\" >";
            strHtml = "<table id=\"datatable_fixed_column" + strId1 + "\" class=\" table-bordered\" width=\"100%\" >";
            //add header row
            strHtml += "<thead class=\"thead1\">";
            strHtml += "<tr >";



            strHtml += "<tr >";

            //  strHtml += "<th class=\"hasinput\" style=\"width:5%;text-align:left;\"> SL#";

            for (int intColumnHeaderCount = 0; intColumnHeaderCount <= dtCategory.Columns.Count; intColumnHeaderCount++)
            {
                if (intColumnHeaderCount == 1)
                {
                    strHtml += "<th class=\"col-md-6 pl_3 flt_n\" colspan=\"2\">EXPENSE ";
                    strHtml += "</th >";
                }
                else if (intColumnHeaderCount == 2)
                {
                    strHtml += "<th class=\"col-md-6 pl_3 flt_n\" colspan=\"2\" >INCOME ";
                    strHtml += "</th >";
                }

            }
            strHtml += "</tr>";
            strHtml += "<tr>";
            strHtml += "<th class=\"col-md-4 tr_l\">PARTICULARS ";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-2 tr_r\" > AMOUNT";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-4 tr_l\" >PARTICULARS ";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-2 tr_r\" >AMOUNT ";
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
            strHtml += "<th class=\"thT\" colspan=\"2\"  style=\"width:20%;text-align:center;\">EXPENSE ";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" colspan=\"2\" style=\"width:20%;text-align:center;\">INCOME";
            strHtml += "</th >";
            strHtml += "</tr>";
            strHtml += "</thead>";
        }
        //add rows
        string STRBALANDR = "", STRBALANCR = "";
        if (TypSts == "0")
        {
            strHtml += "<tbody>";
            int COUNT = 0;
            int flg = 0;
            int actCnt = 0;
            string NewRev = "";
            if (dtCategory.Rows.Count > 0)
            {
                for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
                {
                    actCnt = intRowBodyCount;
                    // intRowBodyCount = flg;
                    string strId = dtCategory.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();
                    int intIdLength = dtCategory.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString().Length;
                    string stridLength = intIdLength.ToString("00");
                    string Id = stridLength + strId + strRandom;
                    COUNT++;

                    string strNetAmount = "";
                    string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                    string strsurAbrv = "";
                    int crCnt = 0;

                    int revflg = 0;
                    int rrvflg = 0;
                    string[] newRev1 = NewRev.Split(',');
                    for (int i = 0; i < newRev1.Length; i++)
                    {
                        if (newRev1[i] != dtCategory.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString())
                        {
                            revflg = 0;
                        }
                        else
                        {
                            revflg = 1;
                            rrvflg = 1;
                        }
                    }
                    if (rrvflg == 0)
                    {
                        if (revflg == 0)
                        {



                            // strsurAbrv = dtRowsIn["CRNCMST_ABBRV"].ToString();
                            if (dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString() != "")
                            {
                                strNetAmount = dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString();
                                decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                if (NetAmount < 0)
                                {
                                    strsurAbrv = "CR";
                                    //  NetAmount = -(NetAmount);
                                }
                                else
                                    strsurAbrv = "DR";
                                strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                            }





                            int sts = Convert.ToInt32(dtCategory.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString());

                            if (sts == 2)
                            {
                                if (dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString() != "")
                                {
                                    strNetAmount = dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString();
                                    decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                    if (NetAmount < 0)
                                    {
                                        strsurAbrv = "CR";
                                        // NetAmount = -(NetAmount);
                                    }
                                    else
                                        strsurAbrv = "DR";
                                    strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                }
                            }
                            else
                            {
                                if (dtCategory.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString() != "")
                                {
                                    strNetAmount = dtCategory.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString();
                                    decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                    if (NetAmount < 0)
                                    {
                                        strsurAbrv = "CR";
                                        // NetAmount = -(NetAmount);
                                    }
                                    else
                                        strsurAbrv = "DR";
                                    strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                }
                            }







                            string CustomerName = dtCategory.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString();
                            if (CustomerName.Contains("\"") == true)
                            {
                                CustomerName = CustomerName.Replace("\"", "‡");
                            }
                            if (CustomerName.Contains("\'") == true)
                            {
                                CustomerName = CustomerName.Replace("\'", "¦");
                            }


                            if (dtCategory.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString() == "2")
                            {
                                strHtml += "<td class=\"tr_l\" > <a  title=\"View\"  onclick=\"return OpenReconView('" + Id + "',0,0," + strId + ",'" + Id + "','" + CustomerName + "',1,'" + dtCategory.Rows[intRowBodyCount]["STSACCNTORLED"].ToString() + "');\" href=\"javascript:;\">" + dtCategory.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString() + "</td>";
                                strHtml += "<td class=\"tr_r\"  >" + strNetAmountDebitComma + "</td>";
                                NewRev = NewRev + "," + dtCategory.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();
                                // dtCategory.Rows[intRowBodyCount].Delete();
                                flg++;

                            }

                            else
                            {
                                strHtml += "<td class=\"tr_l\" > <a  title=\"View\"  onclick=\"return OpenReconView('" + Id + "',0,0," + strId + ",'" + Id + "');\" href=\"javascript:;\"></td>";
                                strHtml += "<td class=\"tr_r\"  ></td>";


                                if (dtCategory.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString() != "")
                                {
                                    strNetAmount = dtCategory.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString();
                                    decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                    if (NetAmount < 0)
                                    {
                                        strsurAbrv = "CR";
                                        // NetAmount = -(NetAmount);
                                    }
                                    else
                                        strsurAbrv = "DR";
                                    strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                }


                                strHtml += "<td class=\"tr_l\" > <a  title=\"View\"  onclick=\"return OpenReconView('" + Id + "',0,0," + strId + ",'" + Id + "','" + CustomerName + "',1,'" + dtCategory.Rows[intRowBodyCount]["STSACCNTORLED"].ToString() + "');\" href=\"javascript:;\">" + dtCategory.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString() + "</td>";
                                strHtml += "<td class=\"tr_r\" >" + strNetAmountCrComma + "</td>";
                                // dtCategory.Rows[TempCount].Delete();
                                NewRev = NewRev + "," + dtCategory.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();
                                flg++;
                                crCnt = 1;

                            }

                            //else
                            //{

                            if (intRowBodyCount == flg)
                            {
                                intRowBodyCount = actCnt;
                            }

                            for (int i = intRowBodyCount + 1; i < dtCategory.Rows.Count; i++)
                            {
                                int TempCount = i;


                                rrvflg = 0;
                                for (int j = 0; j < newRev1.Length; j++)
                                {
                                    if (newRev1[j] != dtCategory.Rows[TempCount]["ACNT_GRP_ID"].ToString())
                                    {
                                        revflg = 0;
                                    }
                                    else
                                    {
                                        revflg = 1;
                                        rrvflg = 1;
                                    }
                                }


                                if (rrvflg == 0)
                                {

                                    if (TempCount < dtCategory.Rows.Count && crCnt == 0 && revflg == 0)
                                    {
                                        if (dtCategory.Rows[TempCount]["ACNT_NATURE_STS"].ToString() == "3")
                                        {
                                            if (dtCategory.Rows[TempCount]["TOTAL_CREDIT_AMNT"].ToString() != "")
                                            {
                                                strNetAmount = dtCategory.Rows[TempCount]["TOTAL_CREDIT_AMNT"].ToString();
                                                decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                                if (NetAmount < 0)
                                                {
                                                    strsurAbrv = "CR";
                                                    // NetAmount = -(NetAmount);
                                                }
                                                else
                                                    strsurAbrv = "DR";
                                                strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                            }


                                            string strrId = dtCategory.Rows[TempCount]["ACNT_GRP_ID"].ToString();
                                            int inttIdLength = dtCategory.Rows[TempCount]["ACNT_GRP_ID"].ToString().Length;
                                            string strridLength = inttIdLength.ToString("00");
                                            string tmpId = strridLength + strrId + strRandom;

                                            string CustomerNameTemp = dtCategory.Rows[TempCount]["ACNT_GRP_NAME"].ToString();
                                            if (CustomerNameTemp.Contains("\"") == true)
                                            {
                                                CustomerNameTemp = CustomerNameTemp.Replace("\"", "‡");
                                            }
                                            if (CustomerNameTemp.Contains("\'") == true)
                                            {
                                                CustomerNameTemp = CustomerNameTemp.Replace("\'", "¦");
                                            }


                                            strHtml += "<td class=\"tr_l\" > <a  title=\"View\"  onclick=\"return OpenReconView('" + tmpId + "',0,0," + strId + ",'" + tmpId + "','" + CustomerNameTemp + "',1,'" + dtCategory.Rows[intRowBodyCount]["STSACCNTORLED"].ToString() + "');\" href=\"javascript:;\">" + dtCategory.Rows[TempCount]["ACNT_GRP_NAME"].ToString() + "</td>";
                                            strHtml += "<td class=\"tr_r\">" + strNetAmountCrComma + "</td>";
                                            NewRev = NewRev + "," + dtCategory.Rows[TempCount]["ACNT_GRP_ID"].ToString();

                                            // dtCategory.Rows[TempCount].Delete();
                                            flg++;
                                            crCnt = 1;
                                        }
                                    }
                                }
                            }
                        }
                        if (crCnt == 0)
                        {
                            strHtml += "<td class=\"tr_l\" > <a  title=\"View\"  onclick=\"return OpenReconView('" + Id + "',0,0," + strId + ",'" + intAccntId + "');\" href=\"javascript:;\"></td>";
                            strHtml += "<td class=\"tr_r\"  ></td>";

                        }
                    }
                    strHtml += "</tr>";
                }

            }

            strHtml += "</tbody>";

            if (StsGrp == 0)
            {
                strHtml += " <tbody> <tr class=\"tr1\">";

                string strNetAmount = "";
                string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                string strNetAmount1 = "";
                string strNetAmountDebitComma1 = "", strNetAmountCrComma1 = "";
                string strProfit = "";
                string strLoss = "";
                decimal NetAmount = 0;
                decimal netamtDec = 0;

                int dcmlCnt = 0;
                if (HiddenDecimalCnt.Value != "")
                {
                    dcmlCnt = Convert.ToInt32(HiddenDecimalCnt.Value);
                }
                string[] AmtAftrDe;

                if (sum_Cedt > sum_debt)
                {
                    NetAmount = sum_Cedt - sum_debt;
                    strNetAmount1 = NetAmount.ToString();
                    strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);
                    strNetAmount = sum_Cedt.ToString();
                    strNetAmount = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                    string[] newRev1 = strNetAmount.Split('.');
                    if (newRev1[1] == "" && HiddenDecimalCnt.Value != "")
                    {
                        for (int i = 0; i < dcmlCnt; i++)
                        {
                            strNetAmount += "0";
                        }
                    }

                    stsflg = 0;
                    strProfit = "Gross Profit";
                }
                else
                {
                    NetAmount = sum_debt - sum_Cedt;
                    strNetAmount1 = NetAmount.ToString();
                    strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);

                    string[] newRev2 = strNetAmountCrComma.Split('.');
                    if (newRev2[1] == "" && HiddenDecimalCnt.Value != "")
                    {
                        for (int i = 0; i < dcmlCnt; i++)
                        {
                            strNetAmountCrComma += "0";
                        }
                    }

                    strNetAmount = sum_debt.ToString();
                    netamtDec = Convert.ToDecimal(strNetAmount);

                    strNetAmount = objBusiness.AddCommasForNumberSeperation(netamtDec.ToString(), objEntityCommon);
                    string[] newRev1 = strNetAmount.Split('.');
                    if (newRev1[1] == "" && HiddenDecimalCnt.Value != "")
                    {
                        for (int i = 0; i < dcmlCnt; i++)
                        {
                            strNetAmount += "0";
                        }
                    }

                    stsflg = 1;
                    strLoss = "Gross Loss";
                }
                strHtml += "<td class=\"tr_r\" >" + strProfit + " </td>";
                strHtml += "<td class=\"tr_r\" > " + strNetAmountCrComma1 + "</td>";
                strHtml += "<td class=\"tr_r\">" + strLoss + " </td>";
                strHtml += "<td class=\"tr_r\" > " + strNetAmountCrComma + "</td>";
                strHtml += "  </tr>";
                strHtml += " <tr class=\"tr1\">";
                strHtml += "<td class=\"tr_l\"  > </td>";
                strHtml += "<td class=\"tr_r pl_2\" > " + strNetAmount + "</td>";
                strHtml += "<td class=\"tr_l\" > </td>";
                strHtml += "<td class=\"tr_r pl_1\"> " + strNetAmount + "</td>";
                strHtml += "  </tr>";
                strHtml += "</tbody>";
            }

        }

        //add rows
        int RcCOUNT = 0;
        if (TypSts == "1")
        {
            StsGrp = 0;
        }
        if (StsGrp == 0 || TypSts == "1")
        {
            strHtml += "<tbody>";
            DataTable dtlist = new DataTable();
            if (TypSts == "0")
            {
                dtlist = objBussiness.Net_ProfitAndLossAcnt_List(ObjEntityRequest);
            }

            int Net_flg = 0;
            int Net_actCnt = 0;
            if (dtlist.Rows.Count > 0)
            {
                string NewRRev = "";

                for (int intRowBodyCount = 0; intRowBodyCount < (dtlist.Rows.Count); intRowBodyCount++)
                {
                    Net_actCnt = intRowBodyCount;
                    // intRowBodyCount = Net_flg;
                    int crCnt = 0;
                    string strId = dtlist.Rows[intRowBodyCount][0].ToString();
                    int intIdLength = dtlist.Rows[intRowBodyCount][0].ToString().Length;
                    string stridLength = intIdLength.ToString("00");
                    string Id = stridLength + strId + strRandom;
                    RcCOUNT++;
                    //    strHtml += "<td class=\"tdT\" style=\" width:10%;text-align: left;\" >" + COUNT + "</td>";
                    int revflg = 0;
                    int revflgg = 0;
                    string[] newRev1 = NewRRev.Split(',');
                    for (int i = 0; i < newRev1.Length; i++)
                    {
                        if (newRev1[i] != dtlist.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString())
                        {
                            revflg = 0;
                        }
                        else
                        {
                            revflg = 1;
                            revflgg = 1;
                            //    break;
                        }
                    }


                    if (revflgg == 0)
                    {
                        if (revflg == 0)
                        {
                            string strNetAmount = "";
                            string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                            string strsurAbrv = "";
                            // strsurAbrv = dtRowsIn["CRNCMST_ABBRV"].ToString();
                            if (dtlist.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString() != "")
                            {
                                strNetAmount = dtlist.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString();
                                decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                if (NetAmount < 0)
                                {
                                    strsurAbrv = "CR";
                                    //  NetAmount = -(NetAmount);
                                }
                                else
                                    strsurAbrv = "DR";
                                strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                            }


                            int sts = Convert.ToInt32(dtlist.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString());

                            if (sts == 2)
                            {
                                if (dtlist.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString() != "")
                                {
                                    strNetAmount = dtlist.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString();
                                    decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                    if (NetAmount < 0)
                                    {
                                        strsurAbrv = "CR";
                                        //  NetAmount = -(NetAmount);
                                    }
                                    else
                                        strsurAbrv = "DR";
                                    strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                }
                            }
                            else
                            {
                                strNetAmount = dtlist.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString();
                                decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                if (NetAmount < 0)
                                {
                                    strsurAbrv = "CR";
                                    // NetAmount = -(NetAmount);
                                }
                                else
                                    strsurAbrv = "DR";
                                strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                            }

                            int dcmlCnt = 0;
                            if (HiddenDecimalCnt.Value != "")
                            {
                                dcmlCnt = Convert.ToInt32(HiddenDecimalCnt.Value);
                            }


                            if (strNetAmountCrComma == "0")
                            {
                                string[] newRev3 = strNetAmount.Split('.');
                                if (newRev3[1] == "" && HiddenDecimalCnt.Value != "")
                                {
                                    for (int i = 0; i < dcmlCnt; i++)
                                    {
                                        strNetAmountCrComma += "0";
                                    }
                                }

                            }

                            if (dtlist.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString() == "2")
                            {

                                strHtml += "<td class=\"tr_l\" > <a  title=\"View\" onclick=\"return OpenReconViewNet('" + Id + "','" + dtlist.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString() + "','" + dtlist.Rows[intRowBodyCount]["STSACCNTORLED"].ToString() + "');\"    href=\"javascript:;\">" + dtlist.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString() + "</td>";
                                strHtml += "<td class=\"tr_r\"  >" + strNetAmountDebitComma + "</td>";

                                NewRRev = NewRRev + "," + dtlist.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();
                                Net_flg++;

                            }

                            else
                            {
                                strHtml += "<td class=\"tr_l\" > <a  title=\"View\"   href=\"javascript:;\"></td>";
                                strHtml += "<td class=\"tr_l\"  ></td>";
                                if (dtlist.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString() == "3")
                                {
                                    if (dtlist.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString() != "")
                                    {
                                        strNetAmount = dtlist.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString();
                                        decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                        if (NetAmount < 0)
                                        {
                                            strsurAbrv = "CR";
                                            // NetAmount = -(NetAmount);
                                        }
                                        else
                                            strsurAbrv = "DR";
                                        strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                    }


                                    strHtml += "<td class=\"tr_l\" > <a  title=\"View\"  onclick=\"return OpenReconViewNet('" + Id + "','" + dtlist.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString() + "','" + dtlist.Rows[intRowBodyCount]["STSACCNTORLED"].ToString() + "');\" href=\"javascript:;\">" + dtlist.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString() + "</td>";
                                    strHtml += "<td class=\"tr_r\" >" + strNetAmountCrComma + "</td>";
                                    // dtCategory.Rows[TempCount].Delete();
                                    NewRRev = NewRRev + "," + dtlist.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();

                                    Net_flg++;
                                    crCnt = 1;
                                }
                            }

                            if (intRowBodyCount == Net_flg)
                            {
                                intRowBodyCount = Net_actCnt;
                            }

                            for (int i = intRowBodyCount + 1; i < dtlist.Rows.Count; i++)
                            {
                                int TempCount = i;

                                int rrvfflg = 0;

                                for (int j = 0; j < newRev1.Length; j++)
                                {
                                    if (newRev1[j] != dtlist.Rows[TempCount]["ACNT_GRP_ID"].ToString())
                                    {
                                        revflg = 0;
                                    }
                                    else
                                    {
                                        revflg = 1;
                                        rrvfflg = 1;
                                    }
                                }

                                if (rrvfflg == 0)
                                {
                                    if (TempCount < dtlist.Rows.Count && crCnt == 0 && revflg == 0)
                                    {
                                        if (dtlist.Rows[TempCount]["ACNT_NATURE_STS"].ToString() == "3")
                                        {
                                            if (dtlist.Rows[TempCount]["TOTAL_CREDIT_AMNT"].ToString() != "")
                                            {
                                                strNetAmount = dtlist.Rows[TempCount]["TOTAL_CREDIT_AMNT"].ToString();
                                                decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                                if (NetAmount < 0)
                                                {
                                                    strsurAbrv = "CR";
                                                    // NetAmount = -(NetAmount);
                                                }
                                                else
                                                    strsurAbrv = "DR";
                                                strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                            }
                                            string strrId = dtlist.Rows[TempCount][0].ToString();
                                            int inttIdLength = dtlist.Rows[TempCount][0].ToString().Length;
                                            string strridLength = inttIdLength.ToString("00");
                                            string TempId = strridLength + strrId + strRandom;
                                            strHtml += "<td class=\"tr_l\" > <a  title=\"View\"  onclick=\"return OpenReconViewNet('" + TempId + "','" + dtlist.Rows[TempCount]["ACNT_GRP_NAME"].ToString() + "','" + dtlist.Rows[TempCount]["STSACCNTORLED"].ToString() + "');\" href=\"javascript:;\">" + dtlist.Rows[TempCount]["ACNT_GRP_NAME"].ToString() + "</td>";
                                            strHtml += "<td class=\"tr_r\" >" + strNetAmountCrComma + "</td>";
                                            // dtCategory.Rows[TempCount].Delete();
                                            NewRRev = NewRRev + "," + dtlist.Rows[TempCount]["ACNT_GRP_ID"].ToString();
                                            Net_flg++;
                                            crCnt = 1;
                                        }
                                    }
                                }
                            }
                        }

                        if (crCnt == 0)
                        {
                            strHtml += "<td class=\"tr_l\" > <a  title=\"View\"  href=\"javascript:;\"></td>";
                            strHtml += "<td class=\"tr_r\" ></td>";

                        }
                    }
                    strHtml += "</tr>";
                }

                decimal sum_Cedt1 = 0, sum_debt1 = 0;
                for (int grscnt = 0; grscnt < dtlist.Rows.Count; grscnt++)
                {
                    if (dtlist.Rows[grscnt]["ACNT_NATURE_STS"].ToString() == "2")
                    {
                        sum_debt1 += Convert.ToDecimal(dtlist.Rows[grscnt]["TOTAL_DEB_AMNT"]);
                    }
                    else
                    {
                        sum_Cedt1 += Convert.ToDecimal(dtlist.Rows[grscnt]["TOTAL_CREDIT_AMNT"]);
                    }
                }
                strHtml += "</tbody>";
                strHtml += " <tbody> <tr class=\"tr1\">";
                string strNetAmountnetttl = "";
                string strNetAmountCrNetComma = "";
                string strNetAmount1 = "";
                string strNetAmountDebitComma1 = "", strNetAmountCrComma1 = "0";
                string strProfit1 = "";
                string strLoss1 = "";
                decimal net_amt = 0;
                int eXfLG = 0;
                string strNetAmt = "";
                string TotalComma = "", TotalComma1 = "";
                string profit = "0";
                string netProdiff = "0";
                decimal TTLaMTdR = 0;
                decimal TTLaMTcR = 0;
                string netProdiffcR = "0";
                net_amt = (sum_Cedt + sum_Cedt1) - (sum_debt1 + sum_debt);
                decimal ttlAmt = 0, ttlAmt1 = 0;

                //strNetAmt = net_amt.ToString();


                if (net_amt > 0 && stsflg == 1)
                {

                    decimal NetAmount = sum_Cedt - sum_debt;

                    profit = "Profit Difference";
                    strNetAmount1 = NetAmount.ToString();
                    netProdiff = objBusiness.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);
                    if (NetAmount < 0)
                    {
                        string srDBalance = netProdiff;
                        srDBalance = srDBalance.Substring(1);
                        netProdiff = srDBalance;
                    }

                }
                else if (net_amt < 0 && stsflg == 0)
                {
                    decimal NetAmount = sum_Cedt - sum_debt;

                    profit = "Profit Difference";
                    strNetAmount1 = NetAmount.ToString();
                    netProdiffcR = objBusiness.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);
                    if (NetAmount < 0)
                    {
                        string srDBalance = netProdiffcR;
                        srDBalance = srDBalance.Substring(1);
                        netProdiffcR = srDBalance;
                    }

                }
                else if (net_amt < 0 && stsflg == 1)
                {
                    strProfit1 = "Profit Difference";
                    decimal NetAmount = sum_Cedt - sum_debt;


                    strNetAmount1 = NetAmount.ToString();
                    strNetAmountCrNetComma = objBusiness.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);
                    if (NetAmount < 0)
                    {
                        string srDBalance = strNetAmountCrNetComma;
                        srDBalance = srDBalance.Substring(1);
                        strNetAmountCrNetComma = srDBalance;
                    }
                }
                else if (net_amt < 0 && stsflg == 0)
                {
                    strLoss1 = "Profit Difference";
                    decimal NetAmount = sum_Cedt - sum_debt;


                    strNetAmount1 = NetAmount.ToString();
                    strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);
                    if (NetAmount < 0)
                    {
                        string srDBalance = strNetAmountCrComma1;
                        srDBalance = srDBalance.Substring(1);
                        strNetAmountCrComma1 = srDBalance;
                    }
                }

                else if (net_amt > 0 && stsflg == 0)
                {
                    strLoss1 = "Profit Difference";
                    decimal NetAmount = sum_Cedt - sum_debt;


                    strNetAmount1 = NetAmount.ToString();
                    strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);
                    if (NetAmount < 0)
                    {
                        string srDBalance = strNetAmountCrComma1;
                        srDBalance = srDBalance.Substring(1);
                        strNetAmountCrComma1 = srDBalance;
                    }
                }
                if (net_amt > 0)
                {
                    strProfit1 = "Net Profit";
                    strNetAmt = net_amt.ToString();
                    strNetAmountCrNetComma = objBusiness.AddCommasForNumberSeperation(strNetAmt.ToString(), objEntityCommon);

                }
                else
                {
                    strLoss1 = "Net Loss";
                    strNetAmt = net_amt.ToString();
                    strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(strNetAmt.ToString(), objEntityCommon);
                    strNetAmountCrComma1 = strNetAmountCrComma1.Substring(1);
                }
                int ddcmlCnt = 0;
                if (HiddenDecimalCnt.Value != "")
                {
                    ddcmlCnt = Convert.ToInt32(HiddenDecimalCnt.Value);
                }

                if (strNetAmountCrNetComma != "")
                {
                    TTLaMTdR = sum_debt1 + Convert.ToDecimal(strNetAmountCrNetComma) + Convert.ToDecimal(netProdiff);

                }
                TTLaMTcR = sum_Cedt1 + Convert.ToDecimal(strNetAmountCrComma1) + Convert.ToDecimal(netProdiffcR);

                if (strNetAmountCrComma1 == "0")
                {
                    strNetAmountCrComma1 = "";
                }
                string strTTLaMTdR = objBusiness.AddCommasForNumberSeperation(TTLaMTdR.ToString(), objEntityCommon);
                string strTTLaMTcR = objBusiness.AddCommasForNumberSeperation(TTLaMTcR.ToString(), objEntityCommon);

                if (TTLaMTdR == 0)
                {
                    string[] newRev5 = strTTLaMTdR.Split('.');
                    if (newRev5[1] == "" && HiddenDecimalCnt.Value != "")
                    {
                        for (int i = 0; i < ddcmlCnt; i++)
                        {
                            strTTLaMTdR += "0";
                        }
                    }

                }
                if (TTLaMTcR == 0)
                {
                    string[] newRev5 = strTTLaMTdR.Split('.');
                    if (newRev5[1] == "" && HiddenDecimalCnt.Value != "")
                    {
                        for (int i = 0; i < ddcmlCnt; i++)
                        {
                            strTTLaMTcR += "0";
                        }
                    }

                }
                if (netProdiff != "")
                {
                    string[] newRev6 = netProdiff.Split('.');

                    if (newRev6[0] == "0")
                    {
                        string[] newRev5 = netProdiff.Split('.');
                        if (HiddenDecimalCnt.Value != "")
                        {
                            for (int i = 0; i < ddcmlCnt; i++)
                            {
                                netProdiff += "0";
                            }
                        }

                    }
                }
                strHtml += "<td class=\"tr_l\"  >" + strProfit1 + " </td>";
                strHtml += "<td class=\"tr_r\" > " + strNetAmountCrNetComma + "</td>";
                strHtml += "<td class=\"tr_r\"  >" + strLoss1 + " </td>";
                strHtml += "<td class=\"tr_r\"  > " + strNetAmountCrComma1 + "</td>";
                strHtml += "  </tr>";

                if (net_amt > 0 && stsflg == 1)
                {
                    strHtml += " <tr class=\"tr1\">";
                    strHtml += "<td class=\"tr_l\">" + profit + " </td>";
                    strHtml += "<td class=\"tr_r\"  > " + netProdiff + "</td>";
                    strHtml += "<td class=\"tr_l\"  > </td>";
                    strHtml += "<td class=\"tr_r\" > </td>";
                    strHtml += "  </tr>";
                }
                else if (net_amt < 0 && stsflg == 0)
                {
                    strHtml += " <tr class=\"tr1\">";
                    strHtml += "<td class=\"tr_l\"  > </td>";
                    strHtml += "<td class=\"tr_l\"  ></td>";
                    strHtml += "<td class=\"tr_r\"  > </td>";
                    strHtml += "<td class=\"tr_l\">" + profit + "  </td>";
                    strHtml += "<td class=\"tr_r\"  >" + netProdiffcR + " </td>";
                    strHtml += "  </tr>";
                }
                strHtml += " <tr class=\"tr1\">";
                strHtml += "<td class=\"tr_l\"> </td>";
                strHtml += "<td class=\"tr_r pl_2\">" + strTTLaMTdR + " </td>";
                strHtml += "<td class=\"tr_r\"> </td>";
                strHtml += "<td class=\"tr_r pl_1\" > " + strTTLaMTcR + "</td>";
                strHtml += "  </tr>";
                strHtml += "</tbody>";
            }
        }
        else
        {
            strHtml += "  <tr>";
            strHtml += "<td class=\"tr_l\" colspan=\"4\" style=\" word-break: break-all; word-wrap:break-word;text-align: right;font-size: large;font-weight: bold;\" > No data available in table</td>";
            strHtml += "  </tr>";
        }
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    public string ConvertDataTableToPrintPdf(DataTable dtCategory, clsEntityProfitAndLossAccount objEntityCustomer, int StsGrp, string strId, string Printsts, string TypSts, string intAccntId, string dateto, string ShowZero, string datefrm)
    {
        string strRet = "";
        //string strId1 = "";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        string strRandom = objCommon.Random_Number();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        int Decimalcount = 0;
        clsBusinessProfitAndLossAccount objBussinessPL = new clsBusinessProfitAndLossAccount();

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }
        decimal sum_Cedt = 0, sum_debt = 0;
        for (int grscnt = 0; grscnt < dtCategory.Rows.Count; grscnt++)
        {
            if (dtCategory.Rows[grscnt]["ACNT_NATURE_STS"].ToString() == "2")
            {
                sum_debt += Convert.ToDecimal(dtCategory.Rows[grscnt]["TOTAL_DEB_AMNT"]);
            }
            else
            {
                sum_Cedt += Convert.ToDecimal(dtCategory.Rows[grscnt]["TOTAL_CREDIT_AMNT"]);
            }
        }
        int stsflg = 0;
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.PROFIT_LOSS_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PROFIT_LOSS_PDF);
        objEntityCommon.CorporateID = objEntityCustomer.Corporate_id;
        objEntityCommon.Organisation_Id = objEntityCustomer.Organisation_id;
        string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "ProfitAndLossAccount_" + strNextNumber + ".pdf";

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

                footrtable.AddCell(new PdfPCell(new Phrase("FROM DATE     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(datefrm, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                footrtable.AddCell(new PdfPCell(new Phrase("TO DATE     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(dateto, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

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
                float[] footrsBody = { 35, 15, 35, 15 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;//get header column in all pages

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("EXPENSE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour, Colspan = 2 });
                TBCustomer.AddCell(new PdfPCell(new Phrase("INCOME", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour, Colspan = 2 });
                TBCustomer.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("AMOUNT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("AMOUNT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                string STRBALANDR = "", STRBALANCR = "";
                if (TypSts == "0")
                {
                    //strHtml += "<tbody>";
                    int COUNT = 0;
                    int flg = 0;
                    int actCnt = 0;
                    string NewRev = "";
                    if (dtCategory.Rows.Count > 0)
                    {
                        for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
                        {
                            actCnt = intRowBodyCount;
                            string strId1 = dtCategory.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();
                            int intIdLength = dtCategory.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString().Length;
                            string stridLength = intIdLength.ToString("00");
                            string Id = stridLength + strId1 + strRandom;
                            COUNT++;
                            string strNetAmount = "";
                            string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                            string strsurAbrv = "";
                            int crCnt = 0;
                            int revflg = 0;
                            int rrvflg = 0;
                            string[] newRev1 = NewRev.Split(',');
                            for (int i = 0; i < newRev1.Length; i++)
                            {
                                if (newRev1[i] != dtCategory.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString())
                                {
                                    revflg = 0;
                                }
                                else
                                {
                                    revflg = 1;
                                    rrvflg = 1;
                                }
                            }
                            if (rrvflg == 0)
                            {
                                if (revflg == 0)
                                {
                                    if (dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString() != "")
                                    {
                                        strNetAmount = dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString();
                                        decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                        if (NetAmount < 0)
                                        {
                                            strsurAbrv = "CR";
                                        }
                                        else
                                            strsurAbrv = "DR";
                                        strNetAmountDebitComma = objBusinessLayer.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                    }
                                    int sts = Convert.ToInt32(dtCategory.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString());
                                    if (sts == 2)
                                    {
                                        if (dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString() != "")
                                        {
                                            strNetAmount = dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString();
                                            decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                            if (NetAmount < 0)
                                            {
                                                strsurAbrv = "CR";
                                                // NetAmount = -(NetAmount);
                                            }
                                            else
                                                strsurAbrv = "DR";
                                            strNetAmountCrComma = objBusinessLayer.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                        }
                                    }
                                    else
                                    {
                                        if (dtCategory.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString() != "")
                                        {
                                            strNetAmount = dtCategory.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString();
                                            decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                            if (NetAmount < 0)
                                            {
                                                strsurAbrv = "CR";
                                                // NetAmount = -(NetAmount);
                                            }
                                            else
                                                strsurAbrv = "DR";
                                            strNetAmountCrComma = objBusinessLayer.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                        }
                                    }
                                    if (dtCategory.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString() == "2")
                                    {
                                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountDebitComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                        NewRev = NewRev + "," + dtCategory.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();
                                        flg++;
                                    }
                                    else
                                    {
                                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                        TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                        if (dtCategory.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString() != "")
                                        {
                                            strNetAmount = dtCategory.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString();
                                            decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                            if (NetAmount < 0)
                                            {
                                                strsurAbrv = "CR";
                                            }
                                            else
                                                strsurAbrv = "DR";
                                            strNetAmountCrComma = objBusinessLayer.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                        }
                                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                        NewRev = NewRev + "," + dtCategory.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();
                                        flg++;
                                        crCnt = 1;
                                    }
                                    if (intRowBodyCount == flg)
                                    {
                                        intRowBodyCount = actCnt;
                                    }
                                    for (int i = intRowBodyCount + 1; i < dtCategory.Rows.Count; i++)
                                    {
                                        int TempCount = i;
                                        rrvflg = 0;
                                        for (int j = 0; j < newRev1.Length; j++)
                                        {
                                            if (newRev1[j] != dtCategory.Rows[TempCount]["ACNT_GRP_ID"].ToString())
                                            {
                                                revflg = 0;
                                            }
                                            else
                                            {
                                                revflg = 1;
                                                rrvflg = 1;
                                            }
                                        }
                                        if (rrvflg == 0)
                                        {
                                            if (TempCount < dtCategory.Rows.Count && crCnt == 0 && revflg == 0)
                                            {
                                                if (dtCategory.Rows[TempCount]["ACNT_NATURE_STS"].ToString() == "3")
                                                {
                                                    if (dtCategory.Rows[TempCount]["TOTAL_CREDIT_AMNT"].ToString() != "")
                                                    {
                                                        strNetAmount = dtCategory.Rows[TempCount]["TOTAL_CREDIT_AMNT"].ToString();
                                                        decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                                        if (NetAmount < 0)
                                                        {
                                                            strsurAbrv = "CR";
                                                        }
                                                        else
                                                            strsurAbrv = "DR";
                                                        strNetAmountCrComma = objBusinessLayer.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                                    }
                                                    string strrId = dtCategory.Rows[TempCount]["ACNT_GRP_ID"].ToString();
                                                    int inttIdLength = dtCategory.Rows[TempCount]["ACNT_GRP_ID"].ToString().Length;
                                                    string strridLength = inttIdLength.ToString("00");
                                                    string tmpId = strridLength + strrId + strRandom;

                                                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[TempCount]["ACNT_GRP_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                                    TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                                    NewRev = NewRev + "," + dtCategory.Rows[TempCount]["ACNT_GRP_ID"].ToString();
                                                    flg++;
                                                    crCnt = 1;
                                                }
                                            }
                                        }
                                    }
                                }
                                if (crCnt == 0)
                                {
                                    TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                    TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                }
                            }

                        }
                    }
                    if (StsGrp == 0)
                    {
                        string strNetAmount = "";
                        string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                        string strNetAmount1 = "";
                        string strNetAmountDebitComma1 = "", strNetAmountCrComma1 = "";
                        string strProfit = "";
                        string strLoss = "";
                        decimal NetAmount = 0;
                        decimal netamtDec = 0;
                        int dcmlCnt = 0;
                        dcmlCnt = Convert.ToInt32(Decimalcount);
                        string[] AmtAftrDe;
                        if (sum_Cedt > sum_debt)
                        {
                            NetAmount = sum_Cedt - sum_debt;
                            strNetAmount1 = NetAmount.ToString();
                            strNetAmountCrComma1 = objBusinessLayer.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);
                            strNetAmount = sum_Cedt.ToString();
                            strNetAmount = objBusinessLayer.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                            string[] newRev1 = strNetAmount.Split('.');
                            if (newRev1[1] == "" && Decimalcount.ToString() != "")
                            {
                                for (int i = 0; i < dcmlCnt; i++)
                                {
                                    strNetAmount += "0";
                                }
                            }
                            stsflg = 0;
                            strProfit = "Gross Profit";
                        }
                        else
                        {
                            NetAmount = sum_debt - sum_Cedt;
                            strNetAmount1 = NetAmount.ToString();
                            strNetAmountCrComma = objBusinessLayer.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);

                            string[] newRev2 = strNetAmountCrComma.Split('.');
                            if (newRev2[1] == "" && Decimalcount.ToString() != "")
                            {
                                for (int i = 0; i < dcmlCnt; i++)
                                {
                                    strNetAmountCrComma += "0";
                                }
                            }
                            strNetAmount = sum_debt.ToString();
                            netamtDec = Convert.ToDecimal(strNetAmount);
                            strNetAmount = objBusinessLayer.AddCommasForNumberSeperation(netamtDec.ToString(), objEntityCommon);
                            string[] newRev1 = strNetAmount.Split('.');
                            if (newRev1[1] == "" && Decimalcount.ToString() != "")
                            {
                                for (int i = 0; i < dcmlCnt; i++)
                                {
                                    strNetAmount += "0";
                                }
                            }
                            stsflg = 1;
                            strLoss = "Gross Loss";
                        }
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strProfit, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma1, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strLoss, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmount, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmount, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    }
                }

                //add rows
                int RcCOUNT = 0;
                if (TypSts == "1")
                {
                    StsGrp = 0;
                }
                if (StsGrp == 0 || TypSts == "1")
                {
                    DataTable dtlist = new DataTable();
                    if (TypSts == "0")
                    {
                        dtlist = objBussinessPL.Net_ProfitAndLossAcnt_List(objEntityCustomer);
                    }

                    int Net_flg = 0;
                    int Net_actCnt = 0;
                    if (dtlist.Rows.Count > 0)
                    {
                        string NewRRev = "";
                        for (int intRowBodyCount = 0; intRowBodyCount < (dtlist.Rows.Count); intRowBodyCount++)
                        {
                            Net_actCnt = intRowBodyCount;
                            int crCnt = 0;
                            string strId1 = dtlist.Rows[intRowBodyCount][0].ToString();
                            int intIdLength = dtlist.Rows[intRowBodyCount][0].ToString().Length;
                            string stridLength = intIdLength.ToString("00");
                            string Id = stridLength + strId1 + strRandom;
                            RcCOUNT++;
                            int revflg = 0;
                            int revflgg = 0;
                            string[] newRev1 = NewRRev.Split(',');
                            for (int i = 0; i < newRev1.Length; i++)
                            {
                                if (newRev1[i] != dtlist.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString())
                                {
                                    revflg = 0;
                                }
                                else
                                {
                                    revflg = 1;
                                    revflgg = 1;
                                }
                            }
                            if (revflgg == 0)
                            {
                                if (revflg == 0)
                                {
                                    string strNetAmount = "";
                                    string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                                    string strsurAbrv = "";
                                    if (dtlist.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString() != "")
                                    {
                                        strNetAmount = dtlist.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString();
                                        decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                        if (NetAmount < 0)
                                        {
                                            strsurAbrv = "CR";
                                        }
                                        else
                                            strsurAbrv = "DR";
                                        strNetAmountDebitComma = objBusinessLayer.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                    }
                                    int sts = Convert.ToInt32(dtlist.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString());
                                    if (sts == 2)
                                    {
                                        if (dtlist.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString() != "")
                                        {
                                            strNetAmount = dtlist.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString();
                                            decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                            if (NetAmount < 0)
                                            {
                                                strsurAbrv = "CR";
                                            }
                                            else
                                                strsurAbrv = "DR";
                                            strNetAmountDebitComma = objBusinessLayer.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                        }
                                    }
                                    else
                                    {
                                        strNetAmount = dtlist.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString();
                                        decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                        if (NetAmount < 0)
                                        {
                                            strsurAbrv = "CR";
                                        }
                                        else
                                            strsurAbrv = "DR";
                                        strNetAmountCrComma = objBusinessLayer.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                    }

                                    int dcmlCnt = 0;
                                    if (Decimalcount.ToString() != "")
                                    {
                                        dcmlCnt = Convert.ToInt32(Decimalcount);
                                    }
                                    if (strNetAmountCrComma == "0")
                                    {
                                        string[] newRev3 = strNetAmount.Split('.');
                                        if (newRev3[1] == "" && Decimalcount.ToString() != "")
                                        {
                                            for (int i = 0; i < dcmlCnt; i++)
                                            {
                                                strNetAmountCrComma += "0";
                                            }
                                        }
                                    }

                                    if (dtlist.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString() == "2")
                                    {
                                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtlist.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountDebitComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                        NewRRev = NewRRev + "," + dtlist.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();
                                        Net_flg++;
                                    }
                                    else
                                    {
                                        TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                        TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                        if (dtlist.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString() == "3")
                                        {
                                            if (dtlist.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString() != "")
                                            {
                                                strNetAmount = dtlist.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString();
                                                decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                                if (NetAmount < 0)
                                                {
                                                    strsurAbrv = "CR";
                                                }
                                                else
                                                    strsurAbrv = "DR";
                                                strNetAmountCrComma = objBusinessLayer.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                            }
                                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtlist.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                            TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                            NewRRev = NewRRev + "," + dtlist.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();
                                            Net_flg++;
                                            crCnt = 1;
                                        }
                                    }
                                    if (intRowBodyCount == Net_flg)
                                    {
                                        intRowBodyCount = Net_actCnt;
                                    }
                                    for (int i = intRowBodyCount + 1; i < dtlist.Rows.Count; i++)
                                    {
                                        int TempCount = i;
                                        int rrvfflg = 0;
                                        for (int j = 0; j < newRev1.Length; j++)
                                        {
                                            if (newRev1[j] != dtlist.Rows[TempCount]["ACNT_GRP_ID"].ToString())
                                            {
                                                revflg = 0;
                                            }
                                            else
                                            {
                                                revflg = 1;
                                                rrvfflg = 1;
                                            }
                                        }
                                        if (rrvfflg == 0)
                                        {
                                            if (TempCount < dtlist.Rows.Count && crCnt == 0 && revflg == 0)
                                            {
                                                if (dtlist.Rows[TempCount]["ACNT_NATURE_STS"].ToString() == "3")
                                                {
                                                    if (dtlist.Rows[TempCount]["TOTAL_CREDIT_AMNT"].ToString() != "")
                                                    {
                                                        strNetAmount = dtlist.Rows[TempCount]["TOTAL_CREDIT_AMNT"].ToString();
                                                        decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                                        if (NetAmount < 0)
                                                        {
                                                            strsurAbrv = "CR";
                                                            // NetAmount = -(NetAmount);
                                                        }
                                                        else
                                                            strsurAbrv = "DR";
                                                        strNetAmountCrComma = objBusinessLayer.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                                    }
                                                    string strrId = dtlist.Rows[TempCount][0].ToString();
                                                    int inttIdLength = dtlist.Rows[TempCount][0].ToString().Length;
                                                    string strridLength = inttIdLength.ToString("00");
                                                    string TempId = strridLength + strrId + strRandom;
                                                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtlist.Rows[TempCount]["ACNT_GRP_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                                    TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                                    NewRRev = NewRRev + "," + dtlist.Rows[TempCount]["ACNT_GRP_ID"].ToString();
                                                    Net_flg++;
                                                    crCnt = 1;
                                                }
                                            }
                                        }
                                    }
                                }

                                if (crCnt == 0)
                                {
                                    TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                    TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                }
                            }
                        }

                        decimal sum_Cedt1 = 0, sum_debt1 = 0;
                        for (int grscnt = 0; grscnt < dtlist.Rows.Count; grscnt++)
                        {
                            if (dtlist.Rows[grscnt]["ACNT_NATURE_STS"].ToString() == "2")
                            {
                                sum_debt1 += Convert.ToDecimal(dtlist.Rows[grscnt]["TOTAL_DEB_AMNT"]);
                            }
                            else
                            {
                                sum_Cedt1 += Convert.ToDecimal(dtlist.Rows[grscnt]["TOTAL_CREDIT_AMNT"]);
                            }
                        }
                        string strNetAmountCrNetComma = "";
                        string strNetAmount1 = "";
                        string strNetAmountCrComma1 = "0";
                        string strProfit1 = "";
                        string strLoss1 = "";
                        decimal net_amt = 0;
                        string strNetAmt = "";
                        string profit = "0";
                        string netProdiff = "0";
                        decimal TTLaMTdR = 0;
                        decimal TTLaMTcR = 0;
                        string netProdiffcR = "0";
                        net_amt = (sum_Cedt + sum_Cedt1) - (sum_debt1 + sum_debt);
                        if (net_amt > 0 && stsflg == 1)
                        {
                            decimal NetAmount = sum_Cedt - sum_debt;
                            profit = "Profit Difference";
                            strNetAmount1 = NetAmount.ToString();
                            netProdiff = objBusinessLayer.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);
                            if (NetAmount < 0)
                            {
                                string srDBalance = netProdiff;
                                srDBalance = srDBalance.Substring(1);
                                netProdiff = srDBalance;
                            }
                        }
                        else if (net_amt < 0 && stsflg == 0)
                        {
                            decimal NetAmount = sum_Cedt - sum_debt;

                            profit = "Profit Difference";
                            strNetAmount1 = NetAmount.ToString();
                            netProdiffcR = objBusinessLayer.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);
                            if (NetAmount < 0)
                            {
                                string srDBalance = netProdiffcR;
                                srDBalance = srDBalance.Substring(1);
                                netProdiffcR = srDBalance;
                            }
                        }
                        else if (net_amt < 0 && stsflg == 1)
                        {
                            strProfit1 = "Profit Difference";
                            decimal NetAmount = sum_Cedt - sum_debt;


                            strNetAmount1 = NetAmount.ToString();
                            strNetAmountCrNetComma = objBusinessLayer.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);
                            if (NetAmount < 0)
                            {
                                string srDBalance = strNetAmountCrNetComma;
                                srDBalance = srDBalance.Substring(1);
                                strNetAmountCrNetComma = srDBalance;
                            }
                        }
                        else if (net_amt < 0 && stsflg == 0)
                        {
                            strLoss1 = "Profit Difference";
                            decimal NetAmount = sum_Cedt - sum_debt;


                            strNetAmount1 = NetAmount.ToString();
                            strNetAmountCrComma1 = objBusinessLayer.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);
                            if (NetAmount < 0)
                            {
                                string srDBalance = strNetAmountCrComma1;
                                srDBalance = srDBalance.Substring(1);
                                strNetAmountCrComma1 = srDBalance;
                            }
                        }

                        else if (net_amt > 0 && stsflg == 0)
                        {
                            strLoss1 = "Profit Difference";
                            decimal NetAmount = sum_Cedt - sum_debt;


                            strNetAmount1 = NetAmount.ToString();
                            strNetAmountCrComma1 = objBusinessLayer.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);
                            if (NetAmount < 0)
                            {
                                string srDBalance = strNetAmountCrComma1;
                                srDBalance = srDBalance.Substring(1);
                                strNetAmountCrComma1 = srDBalance;
                            }
                        }
                        if (net_amt > 0)
                        {
                            strProfit1 = "Net Profit";
                            strNetAmt = net_amt.ToString();
                            strNetAmountCrNetComma = objBusinessLayer.AddCommasForNumberSeperation(strNetAmt.ToString(), objEntityCommon);

                        }
                        else
                        {
                            strLoss1 = "Net Loss";
                            strNetAmt = net_amt.ToString();
                            strNetAmountCrComma1 = objBusinessLayer.AddCommasForNumberSeperation(strNetAmt.ToString(), objEntityCommon);
                            strNetAmountCrComma1 = strNetAmountCrComma1.Substring(1);
                        }
                        int ddcmlCnt = 0;
                        if (Decimalcount.ToString() != "")
                        {
                            ddcmlCnt = Convert.ToInt32(Decimalcount.ToString());
                        }

                        if (strNetAmountCrNetComma != "")
                        {
                            TTLaMTdR = sum_debt1 + Convert.ToDecimal(strNetAmountCrNetComma) + Convert.ToDecimal(netProdiff);

                        }
                        TTLaMTcR = sum_Cedt1 + Convert.ToDecimal(strNetAmountCrComma1) + Convert.ToDecimal(netProdiffcR);

                        if (strNetAmountCrComma1 == "0")
                        {
                            strNetAmountCrComma1 = "";
                        }
                        string strTTLaMTdR = objBusinessLayer.AddCommasForNumberSeperation(TTLaMTdR.ToString(), objEntityCommon);
                        string strTTLaMTcR = objBusinessLayer.AddCommasForNumberSeperation(TTLaMTcR.ToString(), objEntityCommon);

                        if (TTLaMTdR == 0)
                        {
                            string[] newRev5 = strTTLaMTdR.Split('.');
                            if (newRev5[1] == "" && Decimalcount.ToString() != "")
                            {
                                for (int i = 0; i < ddcmlCnt; i++)
                                {
                                    strTTLaMTdR += "0";
                                }
                            }

                        }
                        if (TTLaMTcR == 0)
                        {
                            string[] newRev5 = strTTLaMTdR.Split('.');
                            if (newRev5[1] == "" && Decimalcount.ToString() != "")
                            {
                                for (int i = 0; i < ddcmlCnt; i++)
                                {
                                    strTTLaMTcR += "0";
                                }
                            }

                        }
                        if (netProdiff != "")
                        {
                            string[] newRev6 = netProdiff.Split('.');

                            if (newRev6[0] == "0")
                            {
                                string[] newRev5 = netProdiff.Split('.');
                                if (Decimalcount.ToString() != "")
                                {
                                    for (int i = 0; i < ddcmlCnt; i++)
                                    {
                                        netProdiff += "0";
                                    }
                                }

                            }
                        }
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strProfit1, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrNetComma, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strLoss1, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma1, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        if (net_amt > 0 && stsflg == 1)
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase(profit, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(netProdiff, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        }
                        else if (net_amt < 0 && stsflg == 0)
                        {

                            TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(profit, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(netProdiffcR, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        }
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strTTLaMTdR, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strTTLaMTcR, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    }
                }
                else
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase(" No data available in table", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 4 });
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
    public string ConvertDataTable_CSV(DataTable dtCategory, clsEntityProfitAndLossAccount ObjEntityRequest, int StsGrp, string strId, string Printsts, string TypSts, string intAccntId, string dateto, string ShowZero, string datefrm)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        DataTable dt = GetTableList(dtCategory, ObjEntityRequest, StsGrp, strId, Printsts, TypSts, intAccntId, dateto, ShowZero, datefrm);
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


        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PROFITLOSS_CSV);
        string strNextId = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string newFilePath = Server.MapPath("/CustomFiles/FMS CSV/ProfitAndLoss/PLList_" + strNextId + ".csv");
        System.IO.File.WriteAllText(newFilePath, strResult);
        filepath = "PLList_" + strNextId + ".csv";
        strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.PROFITLOSS_CSV);
        return strImagePath + filepath;
    }
    public DataTable GetTableList(DataTable dtCategory, clsEntityProfitAndLossAccount ObjEntityRequest, int StsGrp, string strId, string Printsts, string TypSts, string intAccntId, string dateto, string ShowZero, string datefrm)
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
        clsBusinessProfitAndLossAccount objBussinessPL = new clsBusinessProfitAndLossAccount();
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
        table.Columns.Add("PROFIT AND LOSS", typeof(string));
        table.Columns.Add(" ", typeof(string));
        table.Columns.Add("  ", typeof(string));
        table.Columns.Add("   ", typeof(string));
        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("FROM DATE :", '"' + datefrm + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        if (ShowZero == "1")
            table.Rows.Add("SHOW ZERO BALANCE :", "YES", '"' + FORNULL + '"', '"' + FORNULL + '"');
        else
            table.Rows.Add("SHOW ZERO BALANCE :", "NO", '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');


        table.Rows.Add("EXPENSE", '"' + FORNULL + '"', "INCOME", '"' + FORNULL + '"');


        table.Rows.Add("PARTICULARS", "AMOUNT", "PARTICULARS", "AMOUNT");
        decimal sum_Cedt = 0, sum_debt = 0;
        for (int grscnt = 0; grscnt < dtCategory.Rows.Count; grscnt++)
        {
            if (dtCategory.Rows[grscnt]["ACNT_NATURE_STS"].ToString() == "2")
            {
                sum_debt += Convert.ToDecimal(dtCategory.Rows[grscnt]["TOTAL_DEB_AMNT"]);
            }
            else
            {
                sum_Cedt += Convert.ToDecimal(dtCategory.Rows[grscnt]["TOTAL_CREDIT_AMNT"]);
            }
        }
        int stsflg = 0;
        string strRandom = objCommon.Random_Number();
        string STRBALANDR = "", STRBALANCR = "";
        if (TypSts == "0")
        {
            //strHtml += "<tbody>";
            int COUNT = 0;
            int flg = 0;
            int actCnt = 0;
            string NewRev = "";
            if (dtCategory.Rows.Count > 0)
            {
                for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
                {
                    actCnt = intRowBodyCount;
                    string strId1 = dtCategory.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();
                    int intIdLength = dtCategory.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString().Length;
                    string stridLength = intIdLength.ToString("00");
                    string Id = stridLength + strId1 + strRandom;
                    COUNT++;
                    string strNetAmount = "";
                    string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                    string strsurAbrv = "";
                    int crCnt = 0;
                    int revflg = 0;
                    int rrvflg = 0;
                    string strAccountGroup = "";
                    string strAccountGroup1 = "";
                    string strDebitAmount = "";
                    string strCreditAmount = "";
                    string[] newRev1 = NewRev.Split(',');
                    for (int i = 0; i < newRev1.Length; i++)
                    {
                        if (newRev1[i] != dtCategory.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString())
                        {
                            revflg = 0;
                        }
                        else
                        {
                            revflg = 1;
                            rrvflg = 1;
                        }
                    }
                    if (rrvflg == 0)
                    {
                        if (revflg == 0)
                        {
                            if (dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString() != "")
                            {
                                strNetAmount = dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString();
                                decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                if (NetAmount < 0)
                                {
                                    strsurAbrv = "CR";
                                }
                                else
                                    strsurAbrv = "DR";
                                strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                            }
                            int sts = Convert.ToInt32(dtCategory.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString());
                            if (sts == 2)
                            {
                                if (dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString() != "")
                                {
                                    strNetAmount = dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString();
                                    decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                    if (NetAmount < 0)
                                    {
                                        strsurAbrv = "CR";
                                        // NetAmount = -(NetAmount);
                                    }
                                    else
                                        strsurAbrv = "DR";
                                    strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                }
                            }
                            else
                            {
                                if (dtCategory.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString() != "")
                                {
                                    strNetAmount = dtCategory.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString();
                                    decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                    if (NetAmount < 0)
                                    {
                                        strsurAbrv = "CR";
                                        // NetAmount = -(NetAmount);
                                    }
                                    else
                                        strsurAbrv = "DR";
                                    strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                }
                            }
                            if (dtCategory.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString() == "2")
                            {
                                strAccountGroup = dtCategory.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString();
                                strDebitAmount = strNetAmountDebitComma;
                                strCreditAmount = "";
                                NewRev = NewRev + "," + dtCategory.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();
                                flg++;
                            }
                            else
                            {
                                strAccountGroup = dtCategory.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString();
                                strDebitAmount = "";
                                strCreditAmount = "";
                                if (dtCategory.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString() != "")
                                {
                                    strNetAmount = dtCategory.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString();
                                    decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                    if (NetAmount < 0)
                                    {
                                        strsurAbrv = "CR";
                                    }
                                    else
                                        strsurAbrv = "DR";
                                    strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                }
                                strAccountGroup = dtCategory.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString();
                                strDebitAmount = "";
                                strCreditAmount = strNetAmountCrComma;
                                NewRev = NewRev + "," + dtCategory.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();
                                flg++;
                                crCnt = 1;
                            }
                            if (intRowBodyCount == flg)
                            {
                                intRowBodyCount = actCnt;
                            }
                            for (int i = intRowBodyCount + 1; i < dtCategory.Rows.Count; i++)
                            {
                                int TempCount = i;
                                rrvflg = 0;
                                for (int j = 0; j < newRev1.Length; j++)
                                {
                                    if (newRev1[j] != dtCategory.Rows[TempCount]["ACNT_GRP_ID"].ToString())
                                    {
                                        revflg = 0;
                                    }
                                    else
                                    {
                                        revflg = 1;
                                        rrvflg = 1;
                                    }
                                }
                                if (rrvflg == 0)
                                {
                                    if (TempCount < dtCategory.Rows.Count && crCnt == 0 && revflg == 0)
                                    {
                                        if (dtCategory.Rows[TempCount]["ACNT_NATURE_STS"].ToString() == "3")
                                        {
                                            if (dtCategory.Rows[TempCount]["TOTAL_CREDIT_AMNT"].ToString() != "")
                                            {
                                                strNetAmount = dtCategory.Rows[TempCount]["TOTAL_CREDIT_AMNT"].ToString();
                                                decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                                if (NetAmount < 0)
                                                {
                                                    strsurAbrv = "CR";
                                                }
                                                else
                                                    strsurAbrv = "DR";
                                                strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                            }
                                            string strrId = dtCategory.Rows[TempCount]["ACNT_GRP_ID"].ToString();
                                            int inttIdLength = dtCategory.Rows[TempCount]["ACNT_GRP_ID"].ToString().Length;
                                            string strridLength = inttIdLength.ToString("00");
                                            string tmpId = strridLength + strrId + strRandom;

                                            strAccountGroup1 = dtCategory.Rows[TempCount]["ACNT_GRP_NAME"].ToString();
                                            strDebitAmount = "";
                                            strCreditAmount = strNetAmountCrComma;
                                            NewRev = NewRev + "," + dtCategory.Rows[TempCount]["ACNT_GRP_ID"].ToString();
                                            flg++;
                                            crCnt = 1;
                                        }
                                    }
                                }
                            }
                        }
                        if (crCnt == 0)
                        {
                            //TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            //TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                    }
                    table.Rows.Add('"' + strAccountGroup + '"', '"' + strDebitAmount + '"', '"' + strAccountGroup1 + '"', '"' + strCreditAmount + '"');
                }
            }
            if (StsGrp == 0)
            {
                string strNetAmount = "";
                string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                string strNetAmount1 = "";
                string strNetAmountDebitComma1 = "", strNetAmountCrComma1 = "";
                string strProfit = "";
                string strLoss = "";
                decimal NetAmount = 0;
                decimal netamtDec = 0;
                int dcmlCnt = 0;
                dcmlCnt = Convert.ToInt32(Decimalcount);
                string[] AmtAftrDe;
                if (sum_Cedt > sum_debt)
                {
                    NetAmount = sum_Cedt - sum_debt;
                    strNetAmount1 = NetAmount.ToString();
                    strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);
                    strNetAmount = sum_Cedt.ToString();
                    strNetAmount = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                    string[] newRev1 = strNetAmount.Split('.');
                    if (newRev1[1] == "" && Decimalcount.ToString() != "")
                    {
                        for (int i = 0; i < dcmlCnt; i++)
                        {
                            strNetAmount += "0";
                        }
                    }
                    stsflg = 0;
                    strProfit = "Gross Profit";
                }
                else
                {
                    NetAmount = sum_debt - sum_Cedt;
                    strNetAmount1 = NetAmount.ToString();
                    strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);

                    string[] newRev2 = strNetAmountCrComma.Split('.');
                    if (newRev2[1] == "" && Decimalcount.ToString() != "")
                    {
                        for (int i = 0; i < dcmlCnt; i++)
                        {
                            strNetAmountCrComma += "0";
                        }
                    }
                    strNetAmount = sum_debt.ToString();
                    netamtDec = Convert.ToDecimal(strNetAmount);
                    strNetAmount = objBusiness.AddCommasForNumberSeperation(netamtDec.ToString(), objEntityCommon);
                    string[] newRev1 = strNetAmount.Split('.');
                    if (newRev1[1] == "" && Decimalcount.ToString() != "")
                    {
                        for (int i = 0; i < dcmlCnt; i++)
                        {
                            strNetAmount += "0";
                        }
                    }
                    stsflg = 1;
                    strLoss = "Gross Loss";
                }
                table.Rows.Add('"' + strProfit + '"', '"' + strNetAmountCrComma1 + '"', '"' + strLoss + '"', '"' + strNetAmountCrComma + '"');
                table.Rows.Add('"' + FORNULL + '"', '"' + strNetAmount + '"', '"' + FORNULL + '"', '"' + strNetAmount + '"');
            }
        }

        //add rows
        int RcCOUNT = 0;
        if (TypSts == "1")
        {
            StsGrp = 0;
        }
        if (StsGrp == 0 || TypSts == "1")
        {
            DataTable dtlist = new DataTable();
            if (TypSts == "0")
            {
                dtlist = objBussinessPL.Net_ProfitAndLossAcnt_List(ObjEntityRequest);
            }

            int Net_flg = 0;
            int Net_actCnt = 0;
            if (dtlist.Rows.Count > 0)
            {
                string NewRRev = "";
                for (int intRowBodyCount = 0; intRowBodyCount < (dtlist.Rows.Count); intRowBodyCount++)
                {
                    Net_actCnt = intRowBodyCount;
                    int crCnt = 0;
                    string strId1 = dtlist.Rows[intRowBodyCount][0].ToString();
                    int intIdLength = dtlist.Rows[intRowBodyCount][0].ToString().Length;
                    string stridLength = intIdLength.ToString("00");
                    string Id = stridLength + strId1 + strRandom;
                    RcCOUNT++;
                    int revflg = 0;
                    int revflgg = 0;
                    string[] newRev1 = NewRRev.Split(',');
                    string strAccountGroup = "";
                    string strAccountGroup1 = "";
                    string strDebitAmount = "";
                    string strCreditAmount = "";
                    for (int i = 0; i < newRev1.Length; i++)
                    {
                        if (newRev1[i] != dtlist.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString())
                        {
                            revflg = 0;
                        }
                        else
                        {
                            revflg = 1;
                            revflgg = 1;
                        }
                    }
                    if (revflgg == 0)
                    {
                        if (revflg == 0)
                        {
                            string strNetAmount = "";
                            string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                            string strsurAbrv = "";
                            if (dtlist.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString() != "")
                            {
                                strNetAmount = dtlist.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString();
                                decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                if (NetAmount < 0)
                                {
                                    strsurAbrv = "CR";
                                }
                                else
                                    strsurAbrv = "DR";
                                strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                            }
                            int sts = Convert.ToInt32(dtlist.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString());
                            if (sts == 2)
                            {
                                if (dtlist.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString() != "")
                                {
                                    strNetAmount = dtlist.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString();
                                    decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                    if (NetAmount < 0)
                                    {
                                        strsurAbrv = "CR";
                                    }
                                    else
                                        strsurAbrv = "DR";
                                    strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                }
                            }
                            else
                            {
                                strNetAmount = dtlist.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString();
                                decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                if (NetAmount < 0)
                                {
                                    strsurAbrv = "CR";
                                }
                                else
                                    strsurAbrv = "DR";
                                strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                            }

                            int dcmlCnt = 0;
                            if (Decimalcount.ToString() != "")
                            {
                                dcmlCnt = Convert.ToInt32(Decimalcount);
                            }
                            if (strNetAmountCrComma == "0")
                            {
                                string[] newRev3 = strNetAmount.Split('.');
                                if (newRev3[1] == "" && Decimalcount.ToString() != "")
                                {
                                    for (int i = 0; i < dcmlCnt; i++)
                                    {
                                        strNetAmountCrComma += "0";
                                    }
                                }
                            }

                            if (dtlist.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString() == "2")
                            {
                                strAccountGroup = dtlist.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString();
                                strDebitAmount = strNetAmountDebitComma;
                                strCreditAmount = "";
                                NewRRev = NewRRev + "," + dtlist.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();
                                Net_flg++;
                            }
                            else
                            {
                                if (dtlist.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString() == "3")
                                {
                                    if (dtlist.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString() != "")
                                    {
                                        strNetAmount = dtlist.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString();
                                        decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                        if (NetAmount < 0)
                                        {
                                            strsurAbrv = "CR";
                                        }
                                        else
                                            strsurAbrv = "DR";
                                        strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                    }
                                    strAccountGroup1 = dtlist.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString();
                                    strDebitAmount = "";
                                    strCreditAmount = strNetAmountCrComma;
                                    NewRRev = NewRRev + "," + dtlist.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();
                                    Net_flg++;
                                    crCnt = 1;
                                }
                            }
                            if (intRowBodyCount == Net_flg)
                            {
                                intRowBodyCount = Net_actCnt;
                            }
                            for (int i = intRowBodyCount + 1; i < dtlist.Rows.Count; i++)
                            {
                                int TempCount = i;
                                int rrvfflg = 0;
                                for (int j = 0; j < newRev1.Length; j++)
                                {
                                    if (newRev1[j] != dtlist.Rows[TempCount]["ACNT_GRP_ID"].ToString())
                                    {
                                        revflg = 0;
                                    }
                                    else
                                    {
                                        revflg = 1;
                                        rrvfflg = 1;
                                    }
                                }
                                if (rrvfflg == 0)
                                {
                                    if (TempCount < dtlist.Rows.Count && crCnt == 0 && revflg == 0)
                                    {
                                        if (dtlist.Rows[TempCount]["ACNT_NATURE_STS"].ToString() == "3")
                                        {
                                            if (dtlist.Rows[TempCount]["TOTAL_CREDIT_AMNT"].ToString() != "")
                                            {
                                                strNetAmount = dtlist.Rows[TempCount]["TOTAL_CREDIT_AMNT"].ToString();
                                                decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                                if (NetAmount < 0)
                                                {
                                                    strsurAbrv = "CR";
                                                    // NetAmount = -(NetAmount);
                                                }
                                                else
                                                    strsurAbrv = "DR";
                                                strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                            }
                                            string strrId = dtlist.Rows[TempCount][0].ToString();
                                            int inttIdLength = dtlist.Rows[TempCount][0].ToString().Length;
                                            string strridLength = inttIdLength.ToString("00");
                                            string TempId = strridLength + strrId + strRandom;
                                            strAccountGroup1 = dtlist.Rows[TempCount]["ACNT_GRP_NAME"].ToString();
                                          //  strDebitAmount = "";
                                            strCreditAmount = strNetAmountCrComma;
                                            NewRRev = NewRRev + "," + dtlist.Rows[TempCount]["ACNT_GRP_ID"].ToString();
                                            Net_flg++;
                                            crCnt = 1;
                                        }
                                    }
                                }
                            }
                        }

                        if (crCnt == 0)
                        {
                            //TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                           // TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                        table.Rows.Add('"' + strAccountGroup + '"', '"' + strDebitAmount + '"', '"' + strAccountGroup1 + '"', '"' + strCreditAmount + '"');

                    }

                }

                decimal sum_Cedt1 = 0, sum_debt1 = 0;
                for (int grscnt = 0; grscnt < dtlist.Rows.Count; grscnt++)
                {
                    if (dtlist.Rows[grscnt]["ACNT_NATURE_STS"].ToString() == "2")
                    {
                        sum_debt1 += Convert.ToDecimal(dtlist.Rows[grscnt]["TOTAL_DEB_AMNT"]);
                    }
                    else
                    {
                        sum_Cedt1 += Convert.ToDecimal(dtlist.Rows[grscnt]["TOTAL_CREDIT_AMNT"]);
                    }
                }
                string strNetAmountCrNetComma = "";
                string strNetAmount1 = "";
                string strNetAmountCrComma1 = "0";
                string strProfit1 = "";
                string strLoss1 = "";
                decimal net_amt = 0;
                string strNetAmt = "";
                string profit = "0";
                string netProdiff = "0";
                decimal TTLaMTdR = 0;
                decimal TTLaMTcR = 0;
                string netProdiffcR = "0";
                net_amt = (sum_Cedt + sum_Cedt1) - (sum_debt1 + sum_debt);
                if (net_amt > 0 && stsflg == 1)
                {
                    decimal NetAmount = sum_Cedt - sum_debt;
                    profit = "Profit Difference";
                    strNetAmount1 = NetAmount.ToString();
                    netProdiff = objBusiness.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);
                    if (NetAmount < 0)
                    {
                        string srDBalance = netProdiff;
                        srDBalance = srDBalance.Substring(1);
                        netProdiff = srDBalance;
                    }
                }
                else if (net_amt < 0 && stsflg == 0)
                {
                    decimal NetAmount = sum_Cedt - sum_debt;

                    profit = "Profit Difference";
                    strNetAmount1 = NetAmount.ToString();
                    netProdiffcR = objBusiness.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);
                    if (NetAmount < 0)
                    {
                        string srDBalance = netProdiffcR;
                        srDBalance = srDBalance.Substring(1);
                        netProdiffcR = srDBalance;
                    }
                }
                else if (net_amt < 0 && stsflg == 1)
                {
                    strProfit1 = "Profit Difference";
                    decimal NetAmount = sum_Cedt - sum_debt;


                    strNetAmount1 = NetAmount.ToString();
                    strNetAmountCrNetComma = objBusiness.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);
                    if (NetAmount < 0)
                    {
                        string srDBalance = strNetAmountCrNetComma;
                        srDBalance = srDBalance.Substring(1);
                        strNetAmountCrNetComma = srDBalance;
                    }
                }
                else if (net_amt < 0 && stsflg == 0)
                {
                    strLoss1 = "Profit Difference";
                    decimal NetAmount = sum_Cedt - sum_debt;


                    strNetAmount1 = NetAmount.ToString();
                    strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);
                    if (NetAmount < 0)
                    {
                        string srDBalance = strNetAmountCrComma1;
                        srDBalance = srDBalance.Substring(1);
                        strNetAmountCrComma1 = srDBalance;
                    }
                }

                else if (net_amt > 0 && stsflg == 0)
                {
                    strLoss1 = "Profit Difference";
                    decimal NetAmount = sum_Cedt - sum_debt;


                    strNetAmount1 = NetAmount.ToString();
                    strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);
                    if (NetAmount < 0)
                    {
                        string srDBalance = strNetAmountCrComma1;
                        srDBalance = srDBalance.Substring(1);
                        strNetAmountCrComma1 = srDBalance;
                    }
                }
                if (net_amt > 0)
                {
                    strProfit1 = "Net Profit";
                    strNetAmt = net_amt.ToString();
                    strNetAmountCrNetComma = objBusiness.AddCommasForNumberSeperation(strNetAmt.ToString(), objEntityCommon);

                }
                else
                {
                    strLoss1 = "Net Loss";
                    strNetAmt = net_amt.ToString();
                    strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(strNetAmt.ToString(), objEntityCommon);
                    strNetAmountCrComma1 = strNetAmountCrComma1.Substring(1);
                }
                int ddcmlCnt = 0;
                if (Decimalcount.ToString() != "")
                {
                    ddcmlCnt = Convert.ToInt32(Decimalcount.ToString());
                }

                if (strNetAmountCrNetComma != "")
                {
                    TTLaMTdR = sum_debt1 + Convert.ToDecimal(strNetAmountCrNetComma) + Convert.ToDecimal(netProdiff);

                }
                TTLaMTcR = sum_Cedt1 + Convert.ToDecimal(strNetAmountCrComma1) + Convert.ToDecimal(netProdiffcR);

                if (strNetAmountCrComma1 == "0")
                {
                    strNetAmountCrComma1 = "";
                }
                string strTTLaMTdR = objBusiness.AddCommasForNumberSeperation(TTLaMTdR.ToString(), objEntityCommon);
                string strTTLaMTcR = objBusiness.AddCommasForNumberSeperation(TTLaMTcR.ToString(), objEntityCommon);

                if (TTLaMTdR == 0)
                {
                    string[] newRev5 = strTTLaMTdR.Split('.');
                    if (newRev5[1] == "" && Decimalcount.ToString() != "")
                    {
                        for (int i = 0; i < ddcmlCnt; i++)
                        {
                            strTTLaMTdR += "0";
                        }
                    }

                }
                if (TTLaMTcR == 0)
                {
                    string[] newRev5 = strTTLaMTdR.Split('.');
                    if (newRev5[1] == "" && Decimalcount.ToString() != "")
                    {
                        for (int i = 0; i < ddcmlCnt; i++)
                        {
                            strTTLaMTcR += "0";
                        }
                    }

                }
                if (netProdiff != "")
                {
                    string[] newRev6 = netProdiff.Split('.');

                    if (newRev6[0] == "0")
                    {
                        string[] newRev5 = netProdiff.Split('.');
                        if (Decimalcount.ToString() != "")
                        {
                            for (int i = 0; i < ddcmlCnt; i++)
                            {
                                netProdiff += "0";
                            }
                        }

                    }
                }
                table.Rows.Add('"' + strProfit1 + '"', '"' + strNetAmountCrNetComma + '"', '"' + strLoss1 + '"', '"' + strNetAmountCrComma1 + '"');

                //TBCustomer.AddCell(new PdfPCell(new Phrase(strProfit1, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                //TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrNetComma, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                //TBCustomer.AddCell(new PdfPCell(new Phrase(strLoss1, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                //TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma1, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                if (net_amt > 0 && stsflg == 1)
                {
                    table.Rows.Add('"' + profit + '"', '"' + netProdiff + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

                    //TBCustomer.AddCell(new PdfPCell(new Phrase(profit, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    //TBCustomer.AddCell(new PdfPCell(new Phrase(netProdiff, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    //TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    //TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                }
                else if (net_amt < 0 && stsflg == 0)
                {
                    table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + profit + '"', '"' + netProdiffcR + '"');

                    //TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    //TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    //TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    //TBCustomer.AddCell(new PdfPCell(new Phrase(profit, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    //TBCustomer.AddCell(new PdfPCell(new Phrase(netProdiffcR, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                }
                table.Rows.Add('"' + FORNULL + '"', '"' + strTTLaMTdR + '"', '"' + FORNULL + '"', '"' + strTTLaMTcR + '"');

                //TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                //TBCustomer.AddCell(new PdfPCell(new Phrase(strTTLaMTdR, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                //TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                //TBCustomer.AddCell(new PdfPCell(new Phrase(strTTLaMTcR, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
            }
        }
        else
        {
            table.Rows.Add(" No data available in table", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
            //TBCustomer.AddCell(new PdfPCell(new Phrase(" No data available in table", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 4 });
        }
        return table;
    }

    //list check which print
    [WebMethod]
    public static string TrailBalance_List_Print(string ShowZero, string intuserid, string intorgid, string intcorpid, string datefrom, string dateto, string strPrintMode)
    {
        string result = "";
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        clsEntityProfitAndLossAccount ObjEntityRequest = new clsEntityProfitAndLossAccount();
        clsBusinessProfitAndLossAccount objBussiness = new clsBusinessProfitAndLossAccount();
        FMS_FMS_Master_fms_Profit_and_Loss_account_fms_Profit_and_Loss_account obj = new FMS_FMS_Master_fms_Profit_and_Loss_account_fms_Profit_and_Loss_account();
        ObjEntityRequest.User_Id = Convert.ToInt32(intuserid);
        ObjEntityRequest.Corporate_id = Convert.ToInt32(intcorpid);
        ObjEntityRequest.Organisation_id = Convert.ToInt32(intorgid);
        ObjEntityRequest.ToDate = ObjCommonlib.textToDateTime(dateto);
        ObjEntityRequest.ShowZerosts = Convert.ToInt32(ShowZero);
        int StsGrp = 0;
        DataTable dtCategory = objBussiness.ProfitAndLossAcnt_List(ObjEntityRequest);
        string strId = "";
        string Printsts = "0";
        string TypSts = "0";
        string intAccntId = "0";
        if (strPrintMode == "pdf")
        {
            result = obj.ConvertDataTableToPrintPdf(dtCategory, ObjEntityRequest, StsGrp, strId, Printsts, TypSts, intAccntId, dateto, ShowZero, datefrom);
        }
        else if ((strPrintMode == "csv"))
        {
            result = obj.ConvertDataTable_CSV(dtCategory, ObjEntityRequest, StsGrp, strId, Printsts, TypSts, intAccntId, dateto, ShowZero, datefrom);

        }
        return result;

    }


    //popup check which print
    [WebMethod]
    public static string[] TrailBalance_Lists_ById(string intAccntId, string intuserid, string intorgid, string intcorpid, string intdatefrom, string intdateto, string TypSts, string ledgrSts, string ShowZero, string strName)
    {
        string[] result = new string[10];
        clsBusinessProfitAndLossAccount objBussiness = new clsBusinessProfitAndLossAccount();
        clsEntityProfitAndLossAccount objEntity = new clsEntityProfitAndLossAccount();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        FMS_FMS_Master_fms_Profit_and_Loss_account_fms_Profit_and_Loss_account obj = new FMS_FMS_Master_fms_Profit_and_Loss_account_fms_Profit_and_Loss_account();
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
        objEntity.ShowZerosts = Convert.ToInt32(ShowZero);
        // HiddenVouchrTyp.Value = VOUCHERTYP;

        if (strName.Contains("‡") == true)
        {
            strName = strName.Replace("‡", "\"");
        }
        if (strName.Contains("¦") == true)
        {
            strName = strName.Replace("¦", "\'");
        }


        StringBuilder sb = new StringBuilder();
        string strNetAmount = "", strsurAbrv = "", strNetAmountWithComma = "";
        objEntity.Status = Convert.ToInt32(TypSts);
        if (ledgrSts == "0")
        {
            DataTable dtList = objBussiness.ProfitAndLossAcnt_List_ById(objEntity);
            int StsGrp = 1;
            string Printsts = "0";
            result[1] = obj.ConvertToTable(dtList, objEntity, StsGrp, strId, Printsts, TypSts, intAccntId);
            Printsts = "1";
            result[4] = obj.ConvertToTable_PDF(dtList, objEntity, StsGrp, strId, Printsts, TypSts, intAccntId, strName, intdateto, intdatefrom);
            result[0] = dtList.Rows.Count.ToString();
            result[2] = strId;
            result[3] = "";
            result[5] = intAccntId;
        }
        else
        {
            int cntAll = 0;
            DataTable dtOpenBalance = objBussiness.ReadLedgOpenBal(objEntity);
            DataTable dtList = objBussiness.LedgerTransDtls(objEntity);
            if (dtOpenBalance.Rows.Count > 0 && Convert.ToDecimal(dtOpenBalance.Rows[0]["TOTAL_DEB_AMNT"].ToString()) != 0)
            {
                cntAll++;
            }
            cntAll += dtList.Rows.Count;
            int StsGrp = 1;
            string Printsts = "0";
            result[1] = obj.LoadConvertToTableLed(dtList, dtOpenBalance, objEntity, StsGrp, strId, Printsts, TypSts, intAccntId);
            Printsts = "1";
            result[4] = obj.LoadConvertToTableLed_PDF(dtList, dtOpenBalance, objEntity, StsGrp, strId, Printsts, TypSts, intAccntId, strName, intdateto, intdatefrom);
            result[0] = cntAll.ToString();
            result[2] = strId;
            result[3] = obj.PrintCaption(objEntity, StsGrp, strId);
            result[5] = intAccntId;
        }
        return result;

    }
    [WebMethod]
    public static string TrailBalance_Lists_ById_Print(string intAccntId, string intuserid, string intorgid, string intcorpid, string intdatefrom, string intdateto, string TypSts, string ledgrSts, string ShowZero, string strName, string strPrintMode)
    {
        string result = "";
        clsBusinessProfitAndLossAccount objBussiness = new clsBusinessProfitAndLossAccount();
        clsEntityProfitAndLossAccount objEntity = new clsEntityProfitAndLossAccount();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        FMS_FMS_Master_fms_Profit_and_Loss_account_fms_Profit_and_Loss_account obj = new FMS_FMS_Master_fms_Profit_and_Loss_account_fms_Profit_and_Loss_account();

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
        objEntity.ShowZerosts = Convert.ToInt32(ShowZero);

        if (strName.Contains("‡") == true)
        {
            strName = strName.Replace("‡", "\"");
        }
        if (strName.Contains("¦") == true)
        {
            strName = strName.Replace("¦", "\'");
        }

        StringBuilder sb = new StringBuilder();
        string strNetAmount = "", strsurAbrv = "", strNetAmountWithComma = "";
        objEntity.Status = Convert.ToInt32(TypSts);
        if (ledgrSts == "0")
        {
            DataTable dtList = objBussiness.ProfitAndLossAcnt_List_ById(objEntity);
            int StsGrp = 1;
            string Printsts = "0";
            Printsts = "1";
            if (strPrintMode == "pdf")
            {
                result = obj.ConvertToTable_PDF(dtList, objEntity, StsGrp, strId, Printsts, TypSts, intAccntId, strName, intdateto, intdatefrom);
            }
            else if ((strPrintMode == "csv"))
            {
                result = obj.ConvertToTable_CSV(dtList, objEntity, StsGrp, strId, Printsts, TypSts, intAccntId, strName, intdateto, intdatefrom);

            }
            //    result = obj.ConvertToTable_PDF(dtList, objEntity, StsGrp, strId, Printsts, TypSts, intAccntId);
        }
        else
        {
            int cntAll = 0;
            DataTable dtOpenBalance = objBussiness.ReadLedgOpenBal(objEntity);
            DataTable dtList = objBussiness.LedgerTransDtls(objEntity);
            if (dtOpenBalance.Rows.Count > 0 && Convert.ToDecimal(dtOpenBalance.Rows[0]["TOTAL_DEB_AMNT"].ToString()) != 0)
            {
                cntAll++;
            }
            cntAll += dtList.Rows.Count;
            int StsGrp = 1;
            string Printsts = "0";
            if (strPrintMode == "pdf")
            {
                result = obj.LoadConvertToTableLed_PDF(dtList, dtOpenBalance, objEntity, StsGrp, strId, Printsts, TypSts, intAccntId, strName, intdateto, intdatefrom);
            }
            else if ((strPrintMode == "csv"))
            {
                result = obj.LoadConvertToTableLed_CSV(dtList, dtOpenBalance, objEntity, StsGrp, strId, Printsts, TypSts, intAccntId, strName, intdateto, intdatefrom);

            }
        }
        return result;

    }


    //Detail popup
    public string ConvertToTable(DataTable dtCategory, clsEntityProfitAndLossAccount ObjEntityRequest, int StsGrp, string strId1, string Printsts, string TypSts, string intAccntId)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        DataTable dtCategory1 = dtCategory;
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            ObjEntityRequest.Corporate_id = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
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

        int intCount = 0;

        decimal sum_Cedt = 0, sum_debt = 0;
        foreach (DataRow dr in dtCategory.Rows)
        {
            sum_Cedt += Convert.ToDecimal(dr["TOTAL_CREDIT_AMNT"]);
            sum_debt += Convert.ToDecimal(dr["TOTAL_DEB_AMNT"]);

        }

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
            for (int intColumnHeaderCount = 0; intColumnHeaderCount <= 2; intColumnHeaderCount++)
            {
                if (intColumnHeaderCount == 0)
                {
                    strHtml += "<th class=\"col-md-4 tr_l\" >PARTICULARS ";
                    strHtml += "</th >"; 
                }
                else if (intColumnHeaderCount == 1)
                {
                    strHtml += "<th class=\"col-md-1 tr_r\" >AMOUNT ";
                    strHtml += "</th >";
                }
            }
            strHtml += "</tr >";
            strHtml += "</thead>";
        }
        else
        {
            strHtml = "<table id=\"PrintTable\" class=\"tab\" \">";
            //add header row
            strHtml += "<thead>";
            strHtml += "<tr class=\"top_row\">";
            strHtml += "<th class=\"thT\"  style=\"width:50%;text-align:center;\">PARTICULARS";
            strHtml += "</th >";
            strHtml += "<th class=\"hasinput\" style=\"width:10%;text-align:left;\"> AMOUNT";
            strHtml += "</th >";
            strHtml += "</tr>";
            strHtml += "</thead>";
        }
        //add rows
        string STRBALANDR = "", STRBALANCR = "";
        strHtml += "<tbody>";
      
            int COUNT = 0;
            int flg = 0;
            int actCnt = 0;
            if (dtCategory.Rows.Count > 0)
            {
                for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
                {
                    actCnt = intRowBodyCount;
                    strHtml += "<tr >";

                    string strId = dtCategory.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();
                    int intIdLength = dtCategory.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString().Length;
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

                    string strNetAmount = "";
                    string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                    string strsurAbrv = "";
                    int crCnt = 0;
                    // strsurAbrv = dtRowsIn["CRNCMST_ABBRV"].ToString();
                    if (dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString() != "")
                    {
                        strNetAmount = dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString();
                        decimal NetAmount = Convert.ToDecimal(strNetAmount);
                        if (NetAmount < 0)
                        {
                            strsurAbrv = "CR";
                            //  NetAmount = -(NetAmount);
                        }
                        else
                            strsurAbrv = "DR";
                        strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                    }
                    int sts = Convert.ToInt32(dtCategory.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString());

                    if (sts == 2)
                    {
                        if (dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString() != "")
                        {
                            strNetAmount = dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString();
                            decimal NetAmount = Convert.ToDecimal(strNetAmount);
                            if (NetAmount < 0)
                            {
                                strsurAbrv = "CR";
                                // NetAmount = -(NetAmount);
                            }
                            else
                                strsurAbrv = "DR";
                            strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                        }
                    }
                    else
                    {
                        if (dtCategory.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString() != "")
                        {
                            strNetAmount = dtCategory.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString();
                            decimal NetAmount = Convert.ToDecimal(strNetAmount);
                            if (NetAmount < 0)
                            {
                                strsurAbrv = "CR";
                                // NetAmount = -(NetAmount);
                            }
                            else
                                strsurAbrv = "DR";
                            strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                        }
                    }
                    if (dtCategory.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString() == "2")
                    {
                        strHtml += "<td class=\"tr_l\" > <a  title=\"View\"  onclick=\"return OpenReconView('" + Id + "',0,0," + strId + ",'" + intAccntId + "','" + CustomerName + "',0,'" + dtCategory.Rows[intRowBodyCount]["STSACCNTORLED"].ToString() + "');\" href=\"javascript:;\">" + dtCategory.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString() + "</td>";
                        strHtml += "<td class=\"tr_r\" >" + strNetAmountDebitComma + "</td>";
                    }

                    if (dtCategory.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString() == "3")
                    {
                        strHtml += "<td class=\"tr_l\" > <a  title=\"View\"  onclick=\"return OpenReconView('" + Id + "',0,0," + strId + ",'" + intAccntId + "','" + CustomerName + "',0,'" + dtCategory.Rows[intRowBodyCount]["STSACCNTORLED"].ToString() + "');\" href=\"javascript:;\">" + dtCategory.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString() + "</td>";
                        strHtml += "<td class=\"tr_r\" >" + strNetAmountCrComma + "</td>";
                    }
                    //strHtml += "<td  class=\"tr_r\"   style=\"display:none; \" ><input   type=\"text\" class=\"form-control\" value=\"" + intAccntId + "\"    id=\"txtprvId" + strId1 + "\"/> </td>";
                    strHtml += "</tr>";
                }
            }
         strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    public string ConvertToTable_PDF(DataTable dtCategory, clsEntityProfitAndLossAccount ObjEntityRequest, int StsGrp, string strId1, string Printsts, string TypSts, string intAccntId, string strName, string intdateto, string intdatefrom)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        DataTable dtCategory1 = dtCategory;
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = 0;
        String strRet = "";
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            ObjEntityRequest.Corporate_id = intCorpId;
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
        decimal sum_Cedt = 0, sum_debt = 0;
        foreach (DataRow dr in dtCategory.Rows)
        {
            sum_Cedt += Convert.ToDecimal(dr["TOTAL_CREDIT_AMNT"]);
            sum_debt += Convert.ToDecimal(dr["TOTAL_DEB_AMNT"]);

        }

        string strRandom = objCommon.Random_Number();
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.PROFIT_LOSS_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PROFIT_LOSS_PDF);
        objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "PLStatementAccnt_" + strNextNumber + ".pdf";

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

                footrtable.AddCell(new PdfPCell(new Phrase("FROM DATE     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(intdatefrom, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                footrtable.AddCell(new PdfPCell(new Phrase("TO DATE     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(intdateto, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                footrtable.AddCell(new PdfPCell(new Phrase("ACCOUNT GROUP/LEDGER NAME", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(strName, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });

                document.Add(footrtable);

                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(2);
                float[] footrsBody = { 75, 25 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;//get header column in all pages

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);

                TBCustomer.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("AMOUNT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour});
                
                int COUNT = 0;
                int actCnt = 0;
                if (dtCategory.Rows.Count > 0)
                {
                    for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
                    {
                        actCnt = intRowBodyCount;
                        string strId = dtCategory.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();
                        int intIdLength = dtCategory.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString().Length;
                        string stridLength = intIdLength.ToString("00");
                        string Id = stridLength + strId + strRandom;
                        COUNT++;
                        string strNetAmount = "";
                        string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                        string strsurAbrv = "";
                        int crCnt = 0;
                        if (dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString() != "")
                        {
                            strNetAmount = dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString();
                            decimal NetAmount = Convert.ToDecimal(strNetAmount);
                            if (NetAmount < 0)
                            {
                                strsurAbrv = "CR";
                            }
                            else
                                strsurAbrv = "DR";
                            strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                        }
                        int sts = Convert.ToInt32(dtCategory.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString());

                        if (sts == 2)
                        {
                            if (dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString() != "")
                            {
                                strNetAmount = dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString();
                                decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                if (NetAmount < 0)
                                {
                                    strsurAbrv = "CR";
                                }
                                else
                                    strsurAbrv = "DR";
                                strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                            }
                        }
                        else
                        {
                            if (dtCategory.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString() != "")
                            {
                                strNetAmount = dtCategory.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString();
                                decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                if (NetAmount < 0)
                                {
                                    strsurAbrv = "CR";
                                }
                                else
                                    strsurAbrv = "DR";
                                strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                            }
                        }
                        if (dtCategory.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString() == "2")
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountDebitComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }

                        if (dtCategory.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString() == "3")
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                    }
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
    public string ConvertToTable_CSV(DataTable dtCategory, clsEntityProfitAndLossAccount ObjEntityRequest, int StsGrp, string strId1, string Printsts, string TypSts, string intAccntId, string strName, string intdateto, string intdatefrom)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dt = GetTable( dtCategory,  ObjEntityRequest,  StsGrp,  strId1,  Printsts,  TypSts,  intAccntId,  strName,  intdateto,  intdatefrom);
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


        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PROFITLOSS_CSV);
        string strNextId = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string newFilePath = Server.MapPath("/CustomFiles/FMS CSV/ProfitAndLoss/PLStatementAccnt" + strNextId + ".csv");
        System.IO.File.WriteAllText(newFilePath, strResult);
        filepath = "PLStatementAccnt" + strNextId + ".csv";
        strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.PROFITLOSS_CSV);
        return strImagePath + filepath;
    }
    public DataTable GetTable(DataTable dtCategory, clsEntityProfitAndLossAccount ObjEntityRequest, int StsGrp, string strId1, string Printsts, string TypSts, string intAccntId, string strName, string intdateto, string intdatefrom)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        DataTable dtCategory1 = dtCategory;
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = 0;
        String strRet = "";
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            ObjEntityRequest.Corporate_id = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
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
        decimal sum_Cedt = 0, sum_debt = 0;
        foreach (DataRow dr in dtCategory.Rows)
        {
            sum_Cedt += Convert.ToDecimal(dr["TOTAL_CREDIT_AMNT"]);
            sum_debt += Convert.ToDecimal(dr["TOTAL_DEB_AMNT"]);

        }
        string strRandom = objCommon.Random_Number();
        string FORNULL = "";
        DataTable table = new DataTable();
        table.Columns.Add("PROFIT AND LOSS", typeof(string));
        table.Columns.Add(" ", typeof(string));
        //table.Columns.Add("  ", typeof(string));
        //table.Columns.Add("   ", typeof(string));
        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("FROM DATE :", '"' + intdatefrom + '"');
        table.Rows.Add("TO DATE :", '"' + intdateto + '"');
        table.Rows.Add("ACCOUNT GROUP/LEDGER NAME:", '"' + strName + '"');

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"');


        table.Rows.Add("PARTICULARS", "AMOUNT");
                int COUNT = 0;
                int actCnt = 0;
                if (dtCategory.Rows.Count > 0)
                {
                    for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
                    {
                        string strAccountGroupName="";
                        string strAmount="";
                        actCnt = intRowBodyCount;
                        string strId = dtCategory.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();
                        int intIdLength = dtCategory.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString().Length;
                        string stridLength = intIdLength.ToString("00");
                        string Id = stridLength + strId + strRandom;
                        COUNT++;
                        string strNetAmount = "";
                        string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                        string strsurAbrv = "";
                        int crCnt = 0;
                        if (dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString() != "")
                        {
                            strNetAmount = dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString();
                            decimal NetAmount = Convert.ToDecimal(strNetAmount);
                            if (NetAmount < 0)
                            {
                                strsurAbrv = "CR";
                            }
                            else
                                strsurAbrv = "DR";
                            strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                        }
                        int sts = Convert.ToInt32(dtCategory.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString());

                        if (sts == 2)
                        {
                            if (dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString() != "")
                            {
                                strNetAmount = dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString();
                                decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                if (NetAmount < 0)
                                {
                                    strsurAbrv = "CR";
                                }
                                else
                                    strsurAbrv = "DR";
                                strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                            }
                        }
                        else
                        {
                            if (dtCategory.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString() != "")
                            {
                                strNetAmount = dtCategory.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString();
                                decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                if (NetAmount < 0)
                                {
                                    strsurAbrv = "CR";
                                }
                                else
                                    strsurAbrv = "DR";
                                strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                            }
                        }
                        if (dtCategory.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString() == "2")
                        {
                            strAccountGroupName=dtCategory.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString();
                             strAmount=strNetAmountDebitComma;
                        }

                        if (dtCategory.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString() == "3")
                        {
                             strAccountGroupName=dtCategory.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString();
                             strAmount=strNetAmountCrComma;
                        }
                        table.Rows.Add('"' + strAccountGroupName + '"', '"' + strAmount + '"');

                    }
        }
        return table;
    }


    //Transaction Detail popup
    public string LoadConvertToTableLed(DataTable dtCategory, DataTable dtOpenBalance, clsEntityProfitAndLossAccount ObjEntityRequest, int StsGrp, string strId1, string Printsts, string intAccntId, string sts)
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
        if (Printsts == "0")
        {
            strHtml = "<table id=\"datatable_fixed_column" + strId1 + "\" class=\"display table-bordered\" width=\"100%\" >";
            strHtml += "<thead class=\"thead1\">";
            strHtml += "<tr >";
            strHtml += "<th class=\"col-md-3 tr_l\">REF# ";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-2 tr_c\" >DATE ";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-3 tr_l\" >TRANS TYPE ";
            strHtml += "</th >";
       
            strHtml += "<th class=\"col-md-2 tr_r\" >DEBIT ";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-2 tr_r\" >CREDIT ";
            strHtml += "</th >";
            strHtml += "</tr>";
            strHtml += "</thead>";
        }
        else
        {
            strHtml = "<table id=\"PrintTable\" class=\"tab\" \">";
            strHtml += "<thead>";
            strHtml += "<tr class=\"top_row\">";
            strHtml += "<th class=\"thT\" style=\"width:20%;text-align:left;\">REF#";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" >DATE";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" >TRANS TYPE";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:20%;text-align:right;\">DEBIT";
            strHtml += "</th >";
            strHtml += "<th class=\"thT\" style=\"width:20%;text-align:right;\">CREDIT";
            strHtml += "</th >";
            strHtml += "</tr>";
            strHtml += "</thead>";
        }
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
                strHtml += "<td class=\"tr_c\" ></td>";
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
                    strHtml += "<td class=\"tr_r\" ></td>";
                    strHtml += "<td class=\"tr_r\" > " + strNetAmountDebitComma + "</td>";
                }
                strHtml += "</tr>";
            }
        }
        for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
        {
            COUNT++;
            string VchrSts = dtCategory.Rows[intRowBodyCount]["VOCHR_STS"].ToString();
            strHtml += "<tr>";
            strHtml += "<td class=\"tr_l\" >" + dtCategory.Rows[intRowBodyCount]["VOCHR_REF"].ToString() + "</td>";
            strHtml += "<td class=\"tr_c\"  >" + dtCategory.Rows[intRowBodyCount]["VOCHR_DATE"].ToString() + "</td>";
            strHtml += "<td class=\"tr_l\" >" + dtCategory.Rows[intRowBodyCount]["VOCHR_TYPE"].ToString() + "</td>";
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
                strHtml += "<td class=\"tr_r\"  >" + strNetAmountDebitComma + "</td>";
                strHtml += "<td class=\"tr_r\"  ></td>";
            }
            else
            {
                strHtml += "<td class=\"tr_r\" ></td>";
                strHtml += "<td class=\"tr_r\"  > " + strNetAmountDebitComma + "</td>";
            }
            strHtml += "</tr>";
        }
        strHtml += "</tbody>";
        strHtml += " <tfoot><tr>";
        strHtml += "<td class=\"tr_l ft_bld\" colspan=\"3\"  >GRAND TOTAL</td>";
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
        strHtml += "<td class=\"tr_r ft_bld\"  > " + strNetAmountCrComma + "</td>";
        strHtml += "<td class=\"tr_r ft_bld\"  > " + strNetAmountCrComma1 + "</td>";
        strHtml += " </tr>";
        strHtml += "</tfoot>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    public string LoadConvertToTableLed_PDF(DataTable dtCategory, DataTable dtOpenBalance, clsEntityProfitAndLossAccount ObjEntityRequest, int StsGrp, string strId1, string Printsts, string intAccntId, string sts, string strName, string intdateto, string intdatefrom)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = 0;
        string strRet = "";
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
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.PROFIT_LOSS_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PROFIT_LOSS_PDF);
        objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "PLStementLedAc_" + strNextNumber + ".pdf";

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

                footrtable.AddCell(new PdfPCell(new Phrase("FROM DATE     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(intdatefrom, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                footrtable.AddCell(new PdfPCell(new Phrase("TO DATE     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(intdateto, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                footrtable.AddCell(new PdfPCell(new Phrase("LEDGER NAME", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(strName, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                
                document.Add(footrtable);

                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(5);
                float[] footrsBody = { 15, 15, 40, 15, 15 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;//get header column in all pages

                var FontSmallGray = new BaseColor(230, 230, 230);
                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);

                TBCustomer.AddCell(new PdfPCell(new Phrase("REF#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour});
                TBCustomer.AddCell(new PdfPCell(new Phrase("DATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("TRANS TYPE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("DEBIT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("CREDIT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                int COUNT = 0;
                if (dtOpenBalance.Rows.Count > 0)
                {
                    decimal OpenBal = Convert.ToDecimal(dtOpenBalance.Rows[0]["TOTAL_DEB_AMNT"].ToString());
                    if (OpenBal != 0)
                    {
                        COUNT++;
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtOpenBalance.Rows[0]["STRTDATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase("Opening Balance", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
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
                            TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                        else if (OpenBal < 0)
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountDebitComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                    }
                }
                for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
                {
                    COUNT++;
                    string VchrSts = dtCategory.Rows[intRowBodyCount]["VOCHR_STS"].ToString();
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["VOCHR_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["VOCHR_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["VOCHR_TYPE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
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
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                    }
                    else
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountDebitComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                    }
                }
                TBCustomer.AddCell(new PdfPCell(new Phrase("GRAND TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray, Colspan = 3 });
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
    public string LoadConvertToTableLed_CSV(DataTable dtCategory, DataTable dtOpenBalance, clsEntityProfitAndLossAccount ObjEntityRequest, int StsGrp, string strId1, string Printsts, string intAccntId, string sts, string strName, string intdateto, string intdatefrom)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dt = GetTableLedger( dtCategory,  dtOpenBalance,  ObjEntityRequest,  StsGrp,  strId1,  Printsts,  intAccntId,  sts,  strName,  intdateto,  intdatefrom);
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


        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PROFITLOSS_CSV);
        string strNextId = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string newFilePath = Server.MapPath("/CustomFiles/FMS CSV/ProfitAndLoss/PLLedger_" + strNextId + ".csv");
        System.IO.File.WriteAllText(newFilePath, strResult);
        filepath = "PLLedger_" + strNextId + ".csv";
        strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.PROFITLOSS_CSV);
        return strImagePath + filepath;
    }
    public DataTable GetTableLedger(DataTable dtCategory, DataTable dtOpenBalance, clsEntityProfitAndLossAccount ObjEntityRequest, int StsGrp, string strId1, string Printsts, string intAccntId, string sts, string strName, string intdateto, string intdatefrom)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = 0;
        string strRet = "";
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
        string FORNULL = "";
        DataTable table = new DataTable();
        table.Columns.Add("PROFIT AND LOSS", typeof(string));
        table.Columns.Add(" ", typeof(string));
        table.Columns.Add("  ", typeof(string));
        table.Columns.Add("   ", typeof(string));
        table.Columns.Add("    ", typeof(string));

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("FROM DATE :", '"' + intdatefrom + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("TO DATE :", '"' + intdateto + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("ACCOUNT GROUP/LEDGER NAME:", '"' + strName + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');


        table.Rows.Add("REF#", "DATE", "TRANS TYPE", "DEBIT", "CREDIT");
        int COUNT = 0;
        if (dtOpenBalance.Rows.Count > 0)
        {
            string strOBDebit = "";
            string strOBCredit = "";
            decimal OpenBal = Convert.ToDecimal(dtOpenBalance.Rows[0]["TOTAL_DEB_AMNT"].ToString());
            if (OpenBal != 0)
            {
                COUNT++;


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
                    strOBDebit = strNetAmountDebitComma;
                    strOBCredit = "";
                }
                else if (OpenBal < 0)
                {
                    strOBDebit = "";
                    strOBCredit = strNetAmountDebitComma;
                }
            }
            table.Rows.Add('"' + FORNULL + '"', '"' + dtOpenBalance.Rows[0]["STRTDATE"].ToString() + '"', " Opening Balance ", '"' + strOBDebit + '"', '"' + strOBCredit + '"');
        }
        for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
        {
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
            table.Rows.Add('"' + dtCategory.Rows[intRowBodyCount]["VOCHR_REF"].ToString() + '"', '"' + dtCategory.Rows[intRowBodyCount]["VOCHR_DATE"].ToString() + '"', '"' + dtCategory.Rows[intRowBodyCount]["VOCHR_TYPE"].ToString() + '"', '"' + strDebitAmount + '"', '"' + strCreditAmount + '"');

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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        clsEntityProfitAndLossAccount ObjEntityRequest = new clsEntityProfitAndLossAccount();
        clsBusinessProfitAndLossAccount objBussiness = new clsBusinessProfitAndLossAccount();
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
        if (txtTodate.Value != "")
        {
            ObjEntityRequest.ToDate = ObjCommonlib.textToDateTime(txtTodate.Value);
        }
        HiddenFieldSearchDate.Value = txtTodate.Value;
        if (cbxCnclStatus.Checked == true)
        {
            HiddenFieldShowZero.Value = "1";
            ObjEntityRequest.ShowZerosts = 1;
        }
        else
        {
            HiddenFieldShowZero.Value = "0";
        }
        int StsGrp = 0;
        DataTable dtCategory = objBussiness.ProfitAndLossAcnt_List(ObjEntityRequest);
        string strId = "";
        string Printsts = "0";
        string TypSts = "0";
        string intAccntId = "0";

         divList.InnerHtml = LoadConvertToTable(dtCategory, ObjEntityRequest, StsGrp, strId, Printsts, TypSts, intAccntId);
         Printsts = "1";
         dtCategory = objBussiness.ProfitAndLossAcnt_List(ObjEntityRequest);
        // divPrintReport.InnerHtml = LoadConvertToTable(dtCategory, ObjEntityRequest, StsGrp, strId, Printsts, TypSts, intAccntId);
         dtCategory = objBussiness.ProfitAndLossAcnt_List(ObjEntityRequest);
        divPrintCaption.InnerHtml = PrintCaption(ObjEntityRequest, StsGrp, strId);
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
            headtable.AddCell(new PdfPCell(new Phrase("PROFIT AND LOSS ACCOUNT", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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
