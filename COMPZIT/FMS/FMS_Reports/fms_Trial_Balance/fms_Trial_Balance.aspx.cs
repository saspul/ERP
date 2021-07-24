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

public partial class FMS_FMS_Master_fms_Trial_Balance_fms_Trial_Balance : System.Web.UI.Page
{
    static string StrMode = "";
    static int intCountGlbl = 0;
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
        StrMode = ddlMode.SelectedItem.Text;
        if (!IsPostBack)
        {
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
            string strCurrentDate = objBusiness.LoadCurrentDateInString();
            DateTime ToDate = ObjCommonlib.textToDateTime(strCurrentDate);
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            clsEntity_Trial_Bal ObjEntityRequest = new clsEntity_Trial_Bal();
            clsBusinessLayer_Trial_Bal objBussiness = new clsBusinessLayer_Trial_Bal();
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
                }
                if (dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString() != "")
                {
                    HiddenFinancialYearFrom.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
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
            HiddenFieldSearchDate.Value = txtTodate.Value;
            int StsGrp = 0;
            DataTable dtCategory = objBussiness.TrailBalance_List(ObjEntityRequest);
            string strId = "";
            string Printsts = "0";
            string intAccntId = "0";
            divList.InnerHtml = LoadConvertToTable(dtCategory, ObjEntityRequest, StsGrp, strId, Printsts, intAccntId);
            Printsts = "1";
        }
    }
    public string PrintCaption(clsEntity_Trial_Bal ObjEntityRequest, int StsGrp, string strId1)
    {
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
        strTitle = "TRIAL BALANCE";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string usrName = "<B> Report Generated By: </B>" + Session["USERFULLNAME"];
        // string TotalRowCnt = "<B> Total Expired Bank Guarantee: </B>" + dt.Rows.Count;
        //for printing product division on print
        string strHidden = "", GuaranteDivsn = "", GuaranteCatgry = "", GuaranteBank = ""; ;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        // clsBusinessLayer objBusiness = new clsBusinessLayer();


        // string strHidden = "";

        GuaranteDivsn = "<B>MODE  : </B>" + StrMode;

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
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strGuaranteCatgry + strGuaranteDivsn + strGuaranteBank + strUsrName + strCaptionTabTitle + strCaptionTabstop;



        sbCap.Append(strPrintCaptionTable);
        ////write to  divPrintCaption
        return sbCap.ToString();


    }

    //account group/ledger main list and list detail popup
    public string LoadConvertToTable(DataTable dtCategory, clsEntity_Trial_Bal ObjEntityRequest, int StsGrp, string strId1, string Printsts, string intAccntId)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsBusinessLayer objBusiness = new clsBusinessLayer();


        int intCorpId = ObjEntityRequest.Corporate_id, intOrgId = 0, intUserId = 0;

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

        string format = String.Format("{{0:N{0}}}", Decimalcount);

        decimal sum_Cedt = 0, sum_debt = 0;
        foreach (DataRow dr in dtCategory.Rows)
        {
            sum_Cedt += Convert.ToDecimal(dr["TOTAL_CREDIT_AMNT"]);//val   to setting
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

          


            strHtml += "<tr >";

            //  strHtml += "<th class=\"hasinput\" style=\"width:5%;text-align:left;\"> SL#";

            for (int intColumnHeaderCount = 0; intColumnHeaderCount <= dtCategory.Columns.Count; intColumnHeaderCount++)
            {
                if (intColumnHeaderCount == 1)
                {
                    strHtml += "<th class=\"col-md-7 tr_l\" >PARTICULARS ";
                    strHtml += " <i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input class=\"tb_inp_1 tb_in\" placeholder=\"PARTICULARS \"  type=\"text\">";
                    strHtml += "</th >";
                }
                else if (intColumnHeaderCount == 2)
                {
                    strHtml += "<th class=\"col-md-2 tr_r\" >DEBIT ";
                    strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input class=\"tb_inp_1 tb_in tr_r\" placeholder=\"DEBIT\"  type=\"text\">";
                    strHtml += "</th >";
                }

                else if (intColumnHeaderCount == 3)
                {
                    strHtml += "<th class=\"col-md-2 tr_r\" >CREDIT ";
                    strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input class=\"tb_inp_1 tb_in tr_r\" placeholder=\"CREDIT\"  type=\"text\">";
                    strHtml += "</th >";
                }
            }


            strHtml += "</tr>";
            strHtml += "</thead>";
            
        }
        else
        {
            strHtml = "<table id=\"PrintTable\" class=\"tab\" \">";
            //add header row
            strHtml += "<thead>";
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

        decimal decDebit = 0;
        decimal decCredit = 0;

        for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
        {

            decimal decDebAmnt = Convert.ToDecimal(dtCategory.Rows[intRowBodyCount][2].ToString());
            decimal decCreAmnt = Convert.ToDecimal(dtCategory.Rows[intRowBodyCount][3].ToString());


            if (ObjEntityRequest.Status == 1 || (ObjEntityRequest.Status == 0 && (decDebAmnt != 0 || decCreAmnt != 0)))
            {
                intCountGlbl++;

                string strId = dtCategory.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dtCategory.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                COUNT++;

                strHtml += "<tr>";

                for (int intColumnBodyCount = 0; intColumnBodyCount < dtCategory.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 1)
                    {
                        string CustomerName = dtCategory.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                        if (CustomerName.Contains("\"") == true)
                        {
                            CustomerName = CustomerName.Replace("\"", "‡");
                        }
                        if (CustomerName.Contains("\'") == true)
                        {
                            CustomerName = CustomerName.Replace("\'", "¦");
                        }

                        if (StsGrp == 0)  //main
                        {

                            strHtml += "<td class=\"tr_l\"  > <a  title=\"View\"  onclick=\"return OpenReconView('" + Id + "',0,0," + strId + ",'" + Id + "','" + CustomerName + "',1,'" + dtCategory.Rows[intRowBodyCount]["STSACCNTORLED"].ToString() + "');\" href=\"javascript:;\">" + dtCategory.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        else   //sub
                        {
                            strHtml += "<td class=\"tr_l\" > <a  title=\"View\"  onclick=\"return OpenReconView('" + Id + "',0,0," + strId + ",'" + intAccntId + "','" + CustomerName + "',0,'" + dtCategory.Rows[intRowBodyCount]["STSACCNTORLED"].ToString() + "');\" href=\"javascript:;\">" + dtCategory.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                        }
                    }
                    else if (intColumnBodyCount == 2)
                    {

                        string strNetAmount = "";
                        string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                        string strsurAbrv = "";
                        // strsurAbrv = dtRowsIn["CRNCMST_ABBRV"].ToString();
                        if (dtCategory.Rows[intRowBodyCount][intColumnBodyCount].ToString() != "")
                        {
                            strNetAmount = dtCategory.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                            decimal NetAmount = Convert.ToDecimal(strNetAmount);
                            decDebit = decDebit + NetAmount;
                            if (NetAmount < 0)
                            {
                                strsurAbrv = "CR";
                                //  NetAmount = -(NetAmount);
                            }
                            else
                                strsurAbrv = "DR";
                            strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                        }

                        strHtml += "<td class=\"tr_r\"  style=\"text-align:right;\">" + strNetAmountDebitComma + "</td>";
                    }
                    else if (intColumnBodyCount == 3)
                    {
                        string strNetAmount = "";
                        string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                        string strsurAbrv = "";


                        if (dtCategory.Rows[intRowBodyCount][intColumnBodyCount].ToString() != "")
                        {
                            strNetAmount = dtCategory.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                            decimal NetAmount = Convert.ToDecimal(strNetAmount);
                            decCredit = decCredit + NetAmount;
                            if (NetAmount < 0)
                            {
                                strsurAbrv = "CR";
                                // NetAmount = -(NetAmount);
                            }
                            else
                                strsurAbrv = "DR";
                            strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                        }


                        strHtml += "<td class=\"tr_r\"  style=\"text-align:right;\"> " + strNetAmountCrComma + "</td>";
                    }




                }

                strHtml += "</tr>";

            }

        }

        strHtml += "</tbody>";

 
            string STRBALANDR = "", STRBALANCR = "";
            if (sum_Cedt != sum_debt)
            {
                //0039
                if (sum_Cedt < sum_debt && strId1 == "")
                {
                    STRBALANDR = "";
                    STRBALANCR = (sum_debt - sum_Cedt).ToString();
                    if (STRBALANCR != "")
                    {
                        sum_Cedt = sum_Cedt + Convert.ToDecimal(STRBALANCR);

                    }
                }
                if (sum_Cedt > sum_debt && strId1 == "")
                {
                    STRBALANDR = (sum_Cedt - sum_debt).ToString();
                    if (STRBALANDR != "")
                        sum_debt = sum_debt + Convert.ToDecimal(STRBALANDR);
                    STRBALANCR = "";
                }   
                //end
            }

   
        //<tr>
        //    <th class="tr_c" colspan="2">Balance</th>
        //    <th></th>
        //    <th class="tr_r">1300000.00</th>
        //  </tr>
        //  <tr>
        //    <th class="tr_c" colspan="2">Total</th>
        //    <th></th>
        //    <th class="tr_r">1300000.00</th>
        //  </tr>


        if (Printsts == "0")
        {
            //0039
            if (strId1 != "")
            {
                strHtml += " <tfoot><tr>";
                //strHtml += "<td class=\"tdT\"  > </td>";
                strHtml += "<td class=\"tr_c ft_bld\"  colspan=\"1\" style=\"text-align:right !important;\">GRAND TOTAL</td>";
                //strHtml += "<td class=\"tdT\"  ></td>";
                string strNetAmountCrComma = "", strNetAmountCrComma1 = "";
                strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(decDebit.ToString(), objEntityCommon);
                strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(decCredit.ToString(), objEntityCommon);
                if (strNetAmountCrComma == "0.")
                {
                    strNetAmountCrComma = "";
                }
                if (strNetAmountCrComma1 == "0.")
                {
                    strNetAmountCrComma1 = "";
                }
                strHtml += "<td class=\"tr_r ft_bld\"  style=\"text-align:right;\"> " + strNetAmountCrComma + "</td>";
                strHtml += "<td class=\"tr_r ft_bld\" style=\"text-align:right;\" > " + strNetAmountCrComma1 + "</td>";
                strHtml += " </tr>";
                strHtml += "</tfoot>";
               
            }
            //end
            if (StsGrp == 0)
            {
                strHtml += " <tfoot> <tr  class=\"bg1\">";
                strHtml += "<th class=\"tr_l txt_rd \" style=\"text-align:left !important;\">BALANCE </th>";
                string strNetAmount = "";
                string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                string strNetAmount1 = "";
                string strNetAmountDebitComma1 = "", strNetAmountCrComma1 = "";
                if (STRBALANDR != "")
                {
                    strNetAmount = STRBALANDR;
                    decimal NetAmount = Convert.ToDecimal(strNetAmount);

                    strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                }


                strHtml += "<th class=\"tr_r txt_rd\" style=\"text-align:right;\"> " + strNetAmountCrComma + "</th>";
                if (STRBALANCR != "")
                {
                    strNetAmount1 = STRBALANCR;
                    decimal NetAmount1 = Convert.ToDecimal(strNetAmount1);

                    strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(NetAmount1.ToString(), objEntityCommon);
                }

                string strsum1 = "", strsum2 = "";
                if (sum_debt == 0)
                {
                    strsum1 = String.Format(format, sum_debt);
                }
                else
                {
                    strsum1 = objBusiness.AddCommasForNumberSeperation(sum_debt.ToString(), objEntityCommon);
                }
                if (sum_Cedt == 0)
                {
                    strsum2 = String.Format(format, sum_Cedt);
                }
                else
                {
                    strsum2 = objBusiness.AddCommasForNumberSeperation(sum_Cedt.ToString(), objEntityCommon);
                }


                strHtml += "<th class=\"tr_r txt_rd\"  style=\"text-align:right;\"> " + strNetAmountCrComma1 + "</th>";
                strHtml += "  </tr>";
                strHtml += " <tr  class=\"bg1\">";
                strHtml += "<th class=\"tr_l pl_1\" style=\"text-align:left !important;\"> TOTAL</th>";
                strHtml += "<th class=\"tr_r pl_1\" style=\"text-align:right;\"> " + strsum1 + "</th>";
                strHtml += "<th class=\"tr_r pl_1\"  style=\"text-align:right;\"> " + strsum2 + "</th>";
                strHtml += "  </tr></tfoot>";
            }
        }
        else
        {
            //0039
            if (strId1 != "")
            {
                strHtml += " <tfoot><tr style=\"font-weight: Bold;\">";
                //strHtml += "<td class=\"tdT\"  > </td>";
                strHtml += "<td class=\"tr_c ft_bld\"  colspan=\"1\" style=\"text-align:right !important;\">GRAND TOTAL</td>";
                //strHtml += "<td class=\"tdT\"  ></td>";
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
                strHtml += "<td class=\"tr_r ft_bld\"  style=\"text-align:right;\"> " + strNetAmountCrComma + "</td>";
                strHtml += "<td class=\"tr_r ft_bld\" style=\"text-align:right;\" > " + strNetAmountCrComma1 + "</td>";
                strHtml += " </tr>";
                strHtml += "</tfoot>";
            }
            //end

            if (StsGrp == 0)
            {
                strHtml += " <tfoot> <tr  class=\"bg1\" style=\"font-weight: Bold;\">";
                strHtml += "<td class=\"thT txt_rd \" style=\"text-align:left !important;\">BALANCE </td>";
                string strNetAmount = "";
                string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                string strNetAmount1 = "";
                string strNetAmountDebitComma1 = "", strNetAmountCrComma1 = "";
                if (STRBALANDR != "")
                {
                    strNetAmount = STRBALANDR;
                    decimal NetAmount = Convert.ToDecimal(strNetAmount);

                    strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                }


                strHtml += "<td class=\"thT txt_rd \" style=\"text-align:right;\"> " + strNetAmountCrComma + "</td>";
                if (STRBALANCR != "")
                {
                    strNetAmount1 = STRBALANCR;
                    decimal NetAmount1 = Convert.ToDecimal(strNetAmount1);

                    strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(NetAmount1.ToString(), objEntityCommon);
                }

                string strsum1 = "", strsum2 = "";
                if (sum_debt == 0)
                {
                    strsum1 = String.Format(format, sum_debt);
                }
                else
                {
                    strsum1 = objBusiness.AddCommasForNumberSeperation(sum_debt.ToString(), objEntityCommon);
                }
                if (sum_Cedt == 0)
                {
                    strsum2 = String.Format(format, sum_Cedt);
                }
                else
                {
                    strsum2 = objBusiness.AddCommasForNumberSeperation(sum_Cedt.ToString(), objEntityCommon);
                }


                strHtml += "<td class=\"thT txt_rd \"  style=\"text-align:right;\"> " + strNetAmountCrComma1 + "</td>";
                strHtml += "  </tr>";
                strHtml += " <tr  class=\"bg1\" style=\"font-weight: Bold;\">";
                strHtml += "<td class=\"thT pl_1\" style=\"text-align:left !important;\"> TOTAL</td>";
                strHtml += "<td class=\"thT pl_1\" style=\"text-align:right;\"> " + strsum1 + "</td>";
                strHtml += "<td class=\"thT pl_1\"  style=\"text-align:right;\"> " + strsum2 + "</td>";
                strHtml += "  </tr></tfoot>";
            }

        }
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    public string LoadConvertToTable_PDF(DataTable dtCategory, clsEntity_Trial_Bal ObjEntityRequest, int StsGrp, string strId1, string Printsts, string intAccntId, string dateto, string Mode, string ShowZero, string Ledgername)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = ObjEntityRequest.Corporate_id, intOrgId = 0, intUserId = 0;
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
        string format = String.Format("{{0:N{0}}}", Decimalcount);
        decimal sum_Cedt = 0, sum_debt = 0;
        foreach (DataRow dr in dtCategory.Rows)
        {
            sum_Cedt += Convert.ToDecimal(dr["TOTAL_CREDIT_AMNT"]);
            sum_debt += Convert.ToDecimal(dr["TOTAL_DEB_AMNT"]);
        }
        string strRandom = objCommon.Random_Number();
        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.TRIAL_BALANCE_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.TRIAL_BALANCE_PDF);
        objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "TBLedger_" + strNextNumber + ".pdf";
        
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
                float[] footrsBody1 = { 30, 5, 65 };
                footrtable.SetWidths(footrsBody1);
                footrtable.WidthPercentage = 100;

                footrtable.AddCell(new PdfPCell(new Phrase("DATE     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(dateto, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (Ledgername != "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("LEDGER     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(Ledgername, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                if (Mode == "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("MODE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase("Consolidated Account Group", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                else if(Mode == "1")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("MODE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase("Ledger", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
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
                PdfPTable TBCustomer = new PdfPTable(3);
                float[] footrsBody = { 50, 25, 25 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;//get header column in all pages

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("DEBIT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("CREDIT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                int COUNT = 0;
                for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
                {
                    decimal decDebAmnt = Convert.ToDecimal(dtCategory.Rows[intRowBodyCount][2].ToString());
                    decimal decCreAmnt = Convert.ToDecimal(dtCategory.Rows[intRowBodyCount][3].ToString());
                    if (ObjEntityRequest.Status == 1 || (ObjEntityRequest.Status == 0 && (decDebAmnt != 0 || decCreAmnt != 0)))
                    {
                        intCountGlbl++;
                        string strId = dtCategory.Rows[intRowBodyCount][0].ToString();
                        int intIdLength = dtCategory.Rows[intRowBodyCount][0].ToString().Length;
                        string stridLength = intIdLength.ToString("00");
                        string Id = stridLength + strId + strRandom;
                        COUNT++;
                        for (int intColumnBodyCount = 0; intColumnBodyCount < dtCategory.Columns.Count; intColumnBodyCount++)
                        {
                            if (intColumnBodyCount == 1)
                            {
                                if (StsGrp == 0)  //main
                                {
                                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount][intColumnBodyCount].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                }
                                else   //sub
                                {
                                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount][intColumnBodyCount].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                }
                            }
                            else if (intColumnBodyCount == 2)
                            {
                                string strNetAmount = "";
                                string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                                string strsurAbrv = "";
                                if (dtCategory.Rows[intRowBodyCount][intColumnBodyCount].ToString() != "")
                                {
                                    strNetAmount = dtCategory.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                                    decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                    if (NetAmount < 0)
                                    {
                                        strsurAbrv = "CR";
                                    }
                                    else
                                        strsurAbrv = "DR";
                                    strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                }
                                TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountDebitComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            }
                            else if (intColumnBodyCount == 3)
                            {
                                string strNetAmount = "";
                                string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                                string strsurAbrv = "";
                                if (dtCategory.Rows[intRowBodyCount][intColumnBodyCount].ToString() != "")
                                {
                                    strNetAmount = dtCategory.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                                    decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                    if (NetAmount < 0)
                                    {
                                        strsurAbrv = "CR";
                                    }
                                    else
                                        strsurAbrv = "DR";
                                    strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                }
                                TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            }
                        }
                    }
                }
                string STRBALANDR = "", STRBALANCR = "";
                if (sum_Cedt != sum_debt)
                {
                    if (sum_Cedt < sum_debt && strId1 == "")
                    {
                        STRBALANDR = "";
                        STRBALANCR = (sum_debt - sum_Cedt).ToString();
                        if (STRBALANCR != "")
                        {
                            sum_Cedt = sum_Cedt + Convert.ToDecimal(STRBALANCR);

                        }
                    }
                    if (sum_Cedt > sum_debt && strId1 == "")
                    {
                        STRBALANDR = (sum_Cedt - sum_debt).ToString();
                        if (STRBALANDR != "")
                            sum_debt = sum_debt + Convert.ToDecimal(STRBALANDR);
                        STRBALANCR = "";
                    }
                }
                if (StsGrp == 0)
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase("BALANCE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    string strNetAmount = "";
                    string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                    string strNetAmount1 = "";
                    string strNetAmountDebitComma1 = "", strNetAmountCrComma1 = "";
                    if (STRBALANDR != "")
                    {
                        strNetAmount = STRBALANDR;
                        decimal NetAmount = Convert.ToDecimal(strNetAmount);
                        strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                    }
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    if (STRBALANCR != "")
                    {
                        strNetAmount1 = STRBALANCR;
                        decimal NetAmount1 = Convert.ToDecimal(strNetAmount1);
                        strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(NetAmount1.ToString(), objEntityCommon);
                    }
                    string strsum1 = "", strsum2 = "";
                    if (sum_debt == 0)
                    {
                        strsum1 = String.Format(format, sum_debt);
                    }
                    else
                    {
                        strsum1 = objBusiness.AddCommasForNumberSeperation(sum_debt.ToString(), objEntityCommon);
                    }
                    if (sum_Cedt == 0)
                    {
                        strsum2 = String.Format(format, sum_Cedt);
                    }
                    else
                    {
                        strsum2 = objBusiness.AddCommasForNumberSeperation(sum_Cedt.ToString(), objEntityCommon);
                    }
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma1, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strsum1, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strsum2, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                }
                //0039
                else if (StsGrp == 1)
                {
                    string strsum1 = "", strsum2 = "";
                    if (sum_debt == 0)
                    {
                        strsum1 = String.Format(format, sum_debt);
                    }
                    else
                    {
                        strsum1 = objBusiness.AddCommasForNumberSeperation(sum_debt.ToString(), objEntityCommon);
                    }
                    if (sum_Cedt == 0)
                    {
                        strsum2 = String.Format(format, sum_Cedt);
                    }
                    else
                    {
                        strsum2 = objBusiness.AddCommasForNumberSeperation(sum_Cedt.ToString(), objEntityCommon);
                    }                   
                    TBCustomer.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strsum1, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strsum2, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                }
                //endddd
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
    public string LoadConvertToTable_CSV(DataTable dtCategory, clsEntity_Trial_Bal ObjEntityRequest, int StsGrp, string strId1, string Printsts, string intAccntId, string dateto, string Mode, string ShowZero, string Ledgername)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        DataTable dt = GetTableList(dtCategory, ObjEntityRequest, StsGrp, strId1, Printsts, intAccntId, dateto, Mode, ShowZero, Ledgername);
        string strResult = DataTableToCSV(dt, ',');

        if (ObjEntityRequest.Corporate_id != 0)
        {
            objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        }
        if (ObjEntityRequest.Organisation_id != 0)
        {
            objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        }
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.TRIALBALANCE_CSV);
        string strNextId = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string filepath = "TrialBalanceList_" + strNextId + ".csv";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.TRIALBALANCE_CSV);
        string newFilePath = Server.MapPath(strImagePath + filepath);
        System.IO.File.WriteAllText(newFilePath, strResult);

        return strImagePath + filepath;
    }
    public DataTable GetTableList(DataTable dtCategory, clsEntity_Trial_Bal ObjEntityRequest, int StsGrp, string strId1, string Printsts, string intAccntId, string dateto, string Mode, string ShowZero, string Ledgername)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = ObjEntityRequest.Corporate_id, intOrgId = 0, intUserId = 0;
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
        string format = String.Format("{{0:N{0}}}", Decimalcount);
        decimal sum_Cedt = 0, sum_debt = 0;
        foreach (DataRow dr in dtCategory.Rows)
        {
            sum_Cedt += Convert.ToDecimal(dr["TOTAL_CREDIT_AMNT"]);
            sum_debt += Convert.ToDecimal(dr["TOTAL_DEB_AMNT"]);
        }
        string strRandom = objCommon.Random_Number();

        string FORNULL = "";
        DataTable table = new DataTable();

        table.Columns.Add("TRIAL BALANCE", typeof(string));
        table.Columns.Add(" ", typeof(string));
        table.Columns.Add("  ", typeof(string));

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("DATE :", '"' + dateto + '"', '"' + FORNULL + '"');
        if (Ledgername != "0")
        {
            table.Rows.Add("LEDGER :", '"' + Ledgername + '"', '"' + FORNULL + '"');
        }
        if (Mode == "0")
        {
            table.Rows.Add("MODE :", '"' + "Consolidated Account Group" + '"', '"' + FORNULL + '"');
        }
        else if (Mode == "1")
        {
            table.Rows.Add("MODE :", '"' + "Ledger" + '"', '"' + FORNULL + '"');
        }
        if (ShowZero == "1")
        {
            table.Rows.Add("SHOW ZERO BALANCE :", '"' + "YES" + '"', '"' + FORNULL + '"');
        }
        else
        {
            table.Rows.Add("SHOW ZERO BALANCE :", '"' + "NO" + '"', '"' + FORNULL + '"');
        }

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

        table.Rows.Add('"' + "PARTICULARS" + '"', '"' + "DEBIT" + '"', '"' + "CREDIT" + '"');

        int COUNT = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
        {
            decimal decDebAmnt = Convert.ToDecimal(dtCategory.Rows[intRowBodyCount][2].ToString());
            decimal decCreAmnt = Convert.ToDecimal(dtCategory.Rows[intRowBodyCount][3].ToString());
            if (ObjEntityRequest.Status == 1 || (ObjEntityRequest.Status == 0 && (decDebAmnt != 0 || decCreAmnt != 0)))
            {
                intCountGlbl++;
                string strId = dtCategory.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dtCategory.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                COUNT++;
                string strName = "", strDebitAmnt = "", strCreditAmnt = "";

                strName = dtCategory.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString();

                string strNetAmount = "";
                string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                string strsurAbrv = "";
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
                    strDebitAmnt = strNetAmountDebitComma;
                }

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
                    strCreditAmnt = strNetAmountCrComma;
                }

                table.Rows.Add('"' + strName + '"', '"' + strDebitAmnt + '"', '"' + strCreditAmnt + '"');

            }
        }
        string STRBALANDR = "", STRBALANCR = "";
        if (sum_Cedt != sum_debt)
        {  
            //0039
            if (sum_Cedt < sum_debt && strId1 == "")
            {
                STRBALANDR = "";
                STRBALANCR = (sum_debt - sum_Cedt).ToString();
                if (STRBALANCR != "")
                {
                    sum_Cedt = sum_Cedt + Convert.ToDecimal(STRBALANCR);

                }
            }
            if (sum_Cedt > sum_debt && strId1 == "")
            {
                STRBALANDR = (sum_Cedt - sum_debt).ToString();
                if (STRBALANDR != "")
                    sum_debt = sum_debt + Convert.ToDecimal(STRBALANDR);
                STRBALANCR = "";
            }
            //end
        }
        if (StsGrp == 0)
        {
            string strNetAmount = "";
            string strNetAmountDebitComma = "", strNetAmountCrComma = "";
            string strNetAmount1 = "";
            string strNetAmountDebitComma1 = "", strNetAmountCrComma1 = "";
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
            string strsum1 = "", strsum2 = "";
            if (sum_debt == 0)
            {
                strsum1 = String.Format(format, sum_debt);
            }
            else
            {
                strsum1 = objBusiness.AddCommasForNumberSeperation(sum_debt.ToString(), objEntityCommon);
            }
            if (sum_Cedt == 0)
            {
                strsum2 = String.Format(format, sum_Cedt);
            }
            else
            {
                strsum2 = objBusiness.AddCommasForNumberSeperation(sum_Cedt.ToString(), objEntityCommon);
            }

            table.Rows.Add('"' + "BALANCE" + '"', '"' + strNetAmountCrComma + '"', '"' + strNetAmountCrComma1 + '"');

            table.Rows.Add('"' + "TOTAL" + '"', '"' + strsum1 + '"', '"' + strsum2 + '"');

        }
        //0039
        if (StsGrp == 1)
        {
           
            string strsum1 = "", strsum2 = "";
            if (sum_debt == 0)
            {
                strsum1 = String.Format(format, sum_debt);
            }
            else
            {
                strsum1 = objBusiness.AddCommasForNumberSeperation(sum_debt.ToString(), objEntityCommon);
            }
            if (sum_Cedt == 0)
            {
                strsum2 = String.Format(format, sum_Cedt);
            }
            else
            {
                strsum2 = objBusiness.AddCommasForNumberSeperation(sum_Cedt.ToString(), objEntityCommon);
            }

            //table.Rows.Add('"' + "BALANCE" + '"', '"' + strNetAmountCrComma + '"', '"' + strNetAmountCrComma1 + '"');

            table.Rows.Add('"' + "TOTAL" + '"', '"' + strsum1 + '"', '"' + strsum2 + '"');

        }

        return table;
    }


    //detailed account group
    public string LoadConvertToTableDetail(DataTable dtCategory, clsEntity_Trial_Bal ObjEntityRequest, int StsGrp, string strId1, string Printsts, string intAccntId)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = ObjEntityRequest.Corporate_id, intOrgId = 0, intUserId = 0;
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
        string format = String.Format("{{0:N{0}}}", Decimalcount);
        decimal sum_Cedt = 0, sum_debt = 0;
        DataRow[] result = dtCategory.Select("LEVEL=1");
        foreach (DataRow row in result)
        {
            sum_Cedt += Convert.ToDecimal(row["TOTAL_CREDIT_AMNT"]);
            sum_debt += Convert.ToDecimal(row["TOTAL_DEB_AMNT"]);
        }
        string strRandom = objCommon.Random_Number();

        StringBuilder sb = new StringBuilder();
        string strHtml = "";
        // class="table table-bordered table-striped"
        if (Printsts == "0")
        {

            strHtml = "<table id=\"datatable_fixed_column" + strId1 + "\" class=\"display table-bordered\" width=\"100%\" >";
            //add header row
            strHtml += "<thead  class=\"thead1\">";
            strHtml += "<tr >";





            //  strHtml += "<th class=\"hasinput\" style=\"width:5%;text-align:left;\"> SL#";

            for (int intColumnHeaderCount = 0; intColumnHeaderCount <= dtCategory.Columns.Count; intColumnHeaderCount++)
            {

                if (intColumnHeaderCount == 1)
                {
                    strHtml += "<th class=\"col-md-7 tr_l\" >PARTICULARS ";
                    strHtml += " <i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input class=\"tb_inp_1 tb_in\" placeholder=\"PARTICULARS \"  type=\"text\">";
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
                    strHtml += " <i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input class=\"tb_inp_1 tb_in tr_r\" placeholder=\"CREDIT\"  type=\"text\">";
                    strHtml += "</th >";
                }



            }


            strHtml += "</tr>";
            strHtml += "</thead>";

        }
        else
        {

            strHtml = "<table id=\"PrintTable\" class=\"tab\" \">";
            //add header row
            strHtml += "<thead>";
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
        int MainCOUNT = 0;
        foreach (DataRow row in result)
        {

            decimal decDebAmnt = Convert.ToDecimal(row[4].ToString());
            decimal decCreAmnt = Convert.ToDecimal(row[5].ToString());
            if (ObjEntityRequest.Status == 1 || (ObjEntityRequest.Status == 0 && (decDebAmnt != 0 || decCreAmnt != 0)))
            {

                intCountGlbl++;
                string strId = row[0].ToString();
                COUNT++;
                MainCOUNT++;
                strHtml += "<tr>";
                strHtml += "<td class=\"tr_l\"  >" + row[1].ToString() + "</td>";

                string strNetAmount = "";
                string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                if (row[4].ToString() != "")
                {
                    strNetAmount = row[4].ToString();
                    decimal NetAmount = Convert.ToDecimal(strNetAmount);
                    strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                }
                strHtml += "<td class=\"tr_r\"  style=\"text-align:right;\">" + strNetAmountDebitComma + "</td>";


                strNetAmount = "";
                strNetAmountDebitComma = ""; strNetAmountCrComma = "";

                if (row[5].ToString() != "")
                {
                    strNetAmount = row[5].ToString();
                    decimal NetAmount = Convert.ToDecimal(strNetAmount);
                    strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                }
                strHtml += "<td class=\"tr_r\"  style=\"text-align:right;\"> " + strNetAmountCrComma + "</td>";
                strHtml += "</tr>";

                //Level2
                DataRow[] result1 = dtCategory.Select("ACNT_PARENT_GRP_ID ='" + strId + "' AND LEVEL =2");
                foreach (DataRow row1 in result1)
                {


                    decimal decDebAmnt1 = Convert.ToDecimal(row1[4].ToString());
                    decimal decCreAmnt1 = Convert.ToDecimal(row1[5].ToString());
                    if (ObjEntityRequest.Status == 1 || (ObjEntityRequest.Status == 0 && (decDebAmnt1 != 0 || decCreAmnt1 != 0)))
                    {

                        string strId2 = row1[0].ToString();
                        COUNT++;

                        strHtml += "<tr  style=\"background-color: #f5f5f5 !important;\" >";
                        strHtml += "<td class=\"tr_l\" style=\"padding-left:30px!important;background-color: #f5f5f5;\" >" + row1[1].ToString() + "</td>";

                        strNetAmount = "";
                        strNetAmountDebitComma = ""; strNetAmountCrComma = "";
                        if (row1[4].ToString() != "")
                        {
                            strNetAmount = row1[4].ToString();
                            decimal NetAmount = Convert.ToDecimal(strNetAmount);
                            strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                        }
                        strHtml += "<td class=\"tr_r\"  style=\"text-align:right;\">" + strNetAmountDebitComma + "</td>";


                        strNetAmount = "";
                        strNetAmountDebitComma = ""; strNetAmountCrComma = "";

                        if (row1[5].ToString() != "")
                        {
                            strNetAmount = row1[5].ToString();
                            decimal NetAmount = Convert.ToDecimal(strNetAmount);
                            strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                        }
                        strHtml += "<td class=\"tr_r\" style=\"text-align:right;\"> " + strNetAmountCrComma + "</td>";
                        strHtml += "</tr>";

                        //Level3
                        DataRow[] result2 = dtCategory.Select("ACNT_PARENT_GRP_ID ='" + strId2 + "' AND LEVEL =3");
                        foreach (DataRow row2 in result2)
                        {


                            decimal decDebAmnt2 = Convert.ToDecimal(row2[4].ToString());
                            decimal decCreAmnt2 = Convert.ToDecimal(row2[5].ToString());
                            if (ObjEntityRequest.Status == 1 || (ObjEntityRequest.Status == 0 && (decDebAmnt2 != 0 || decCreAmnt2 != 0)))
                            {

                                intCountGlbl++;
                                COUNT++;

                                strHtml += "<tr style=\" background-color: #eaeaea !important;\" >";
                                strHtml += "<td class=\"tr_l\" style=\" padding-left:60px!important;background-color: #eaeaea;\" >" + row2[1].ToString() + "</td>";

                                strNetAmount = "";
                                strNetAmountDebitComma = ""; strNetAmountCrComma = "";
                                if (row2[4].ToString() != "")
                                {
                                    strNetAmount = row2[4].ToString();
                                    decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                    strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                }
                                strHtml += "<td class=\"tr_r\" style=\"text-align:right;\" >" + strNetAmountDebitComma + "</td>";


                                strNetAmount = "";
                                strNetAmountDebitComma = ""; strNetAmountCrComma = "";

                                if (row2[5].ToString() != "")
                                {
                                    strNetAmount = row2[5].ToString();
                                    decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                    strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                }
                                strHtml += "<td class=\"tr_r\"  style=\"text-align:right;\"> " + strNetAmountCrComma + "</td>";
                                strHtml += "</tr>";

                            }
                        }
                    }
                }


            }
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
        if (Printsts == "0")
        {
            if (StsGrp == 0)
            {
                strHtml += " <tfoot> <tr  class=\"bg1\">";
                strHtml += "<th class=\"tr_l txt_rd \" style=\"text-align:left !important;\" >BALANCE </th>";
                string strNetAmount = "";
                string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                string strNetAmount1 = "";
                string strNetAmountDebitComma1 = "", strNetAmountCrComma1 = "";
                if (STRBALANDR != "")
                {
                    strNetAmount = STRBALANDR;
                    decimal NetAmount = Convert.ToDecimal(strNetAmount);
                    strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                }
                strHtml += "<th class=\"tr_r txt_rd \" style=\"text-align:right;\" > " + strNetAmountCrComma + "</th>";
                if (STRBALANCR != "")
                {
                    strNetAmount1 = STRBALANCR;
                    decimal NetAmount1 = Convert.ToDecimal(strNetAmount1);
                    strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(NetAmount1.ToString(), objEntityCommon);
                }

                strHtml += "<th class=\"tr_r txt_rd \" style=\"text-align:right;\"> " + strNetAmountCrComma1 + "</th>";
                strHtml += "  </tr>";


                string strsum1 = "", strsum2 = "";
                if (sum_debt == 0)
                {
                    strsum1 = String.Format(format, sum_debt);
                }
                else
                {
                    strsum1 = objBusiness.AddCommasForNumberSeperation(sum_debt.ToString(), objEntityCommon);
                }
                if (sum_Cedt == 0)
                {
                    strsum2 = String.Format(format, sum_Cedt);
                }
                else
                {
                    strsum2 = objBusiness.AddCommasForNumberSeperation(sum_Cedt.ToString(), objEntityCommon);
                }

                strHtml += " <tr  class=\"bg1\">";
                strHtml += "<th class=\"tr_l pl_1\"  style=\"text-align:left !important;\" > TOTAL</th>";
                strHtml += "<th class=\"tr_r pl_1\" style=\"text-align:right;\" > " + strsum1 + "</th>";
                strHtml += "<th class=\"tr_r pl_1\" style=\"text-align:right;\" > " + strsum2 + "</th>";
                strHtml += "  </tr></tfoot>";
            }
        }
        else
        {
            if (StsGrp == 0)
            {
                strHtml += " <tfoot> <tr  class=\"bg1\" style=\"font-weight: Bold;\">";
                strHtml += "<td class=\"thT txt_rd \" style=\"text-align:left !important;\" >BALANCE </td>";
                string strNetAmount = "";
                string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                string strNetAmount1 = "";
                string strNetAmountDebitComma1 = "", strNetAmountCrComma1 = "";
                if (STRBALANDR != "")
                {
                    strNetAmount = STRBALANDR;
                    decimal NetAmount = Convert.ToDecimal(strNetAmount);
                    strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                }
                strHtml += "<td class=\"thT txt_rd \" style=\"text-align:right;\" > " + strNetAmountCrComma + "</td>";
                if (STRBALANCR != "")
                {
                    strNetAmount1 = STRBALANCR;
                    decimal NetAmount1 = Convert.ToDecimal(strNetAmount1);
                    strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(NetAmount1.ToString(), objEntityCommon);
                }

                strHtml += "<td class=\"thT txt_rd \" style=\"text-align:right;\"> " + strNetAmountCrComma1 + "</td>";
                strHtml += "  </tr>";



                string strsum1 = "", strsum2 = "";
                if (sum_debt == 0)
                {
                    strsum1 = String.Format(format, sum_debt);
                }
                else
                {
                    strsum1 = objBusiness.AddCommasForNumberSeperation(sum_debt.ToString(), objEntityCommon);
                }
                if (sum_Cedt == 0)
                {
                    strsum2 = String.Format(format, sum_Cedt);
                }
                else
                {
                    strsum2 = objBusiness.AddCommasForNumberSeperation(sum_Cedt.ToString(), objEntityCommon);
                }

                strHtml += " <tr class=\"bg1\" style=\"font-weight: Bold;\">";
                strHtml += "<td class=\"thT pl_1\"  style=\"text-align:left !important;\" > TOTAL</td>";
                strHtml += "<td class=\"thT pl_1\" style=\"text-align:right;\" > " + strsum1 + "</td>";
                strHtml += "<td class=\"thT pl_1\" style=\"text-align:right;\" > " + strsum2 + "</td>";
                strHtml += "  </tr></tfoot>";
            }
        }

        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    public string LoadConvertToTableDetail_PDF(DataTable dtCategory, clsEntity_Trial_Bal ObjEntityRequest, int StsGrp, string strId1, string Printsts, string intAccntId, string dateto, string Mode, string ShowZero)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = ObjEntityRequest.Corporate_id, intOrgId = 0, intUserId = 0;
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
        string format = String.Format("{{0:N{0}}}", Decimalcount);
        decimal sum_Cedt = 0, sum_debt = 0;
        DataRow[] result = dtCategory.Select("LEVEL=1");
        foreach (DataRow row in result)
        {
            sum_Cedt += Convert.ToDecimal(row["TOTAL_CREDIT_AMNT"]);
            sum_debt += Convert.ToDecimal(row["TOTAL_DEB_AMNT"]);
        }
        string strRandom = objCommon.Random_Number();
        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.TRIAL_BALANCE_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.TRIAL_BALANCE_PDF);
        objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "TBListDetailed_" + strNextNumber + ".pdf";

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
                float[] footrsBody1 = { 30, 5, 65 };
                footrtable.SetWidths(footrsBody1);
                footrtable.WidthPercentage = 100;

                footrtable.AddCell(new PdfPCell(new Phrase("DATE     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(dateto, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase("MODE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase("Detailed Account Group", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

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
                PdfPTable TBCustomer = new PdfPTable(3);
                float[] footrsBody = { 50, 25, 25 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;//get header column in all pages

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("DEBIT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("CREDIT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                
                int COUNT = 0;
                int MainCOUNT = 0;
                foreach (DataRow row in result)
                {
                    decimal decDebAmnt = Convert.ToDecimal(row[4].ToString());
                    decimal decCreAmnt = Convert.ToDecimal(row[5].ToString());
                    if (ObjEntityRequest.Status == 1 || (ObjEntityRequest.Status == 0 && (decDebAmnt != 0 || decCreAmnt != 0)))
                    {

                        intCountGlbl++;
                        string strId = row[0].ToString();
                        COUNT++;
                        MainCOUNT++;
                        TBCustomer.AddCell(new PdfPCell(new Phrase(row[1].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        string strNetAmount = "";
                        string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                        if (row[4].ToString() != "")
                        {
                            strNetAmount = row[4].ToString();
                            decimal NetAmount = Convert.ToDecimal(strNetAmount);
                            strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                        }
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountDebitComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        strNetAmount = "";
                        strNetAmountDebitComma = ""; strNetAmountCrComma = "";
                        if (row[5].ToString() != "")
                        {
                            strNetAmount = row[5].ToString();
                            decimal NetAmount = Convert.ToDecimal(strNetAmount);
                            strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                        }
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        //Level2
                        DataRow[] result1 = dtCategory.Select("ACNT_PARENT_GRP_ID ='" + strId + "' AND LEVEL =2");
                        foreach (DataRow row1 in result1)
                        {
                            decimal decDebAmnt1 = Convert.ToDecimal(row1[4].ToString());
                            decimal decCreAmnt1 = Convert.ToDecimal(row1[5].ToString());
                            if (ObjEntityRequest.Status == 1 || (ObjEntityRequest.Status == 0 && (decDebAmnt1 != 0 || decCreAmnt1 != 0)))
                            {
                                string strId2 = row1[0].ToString();
                                COUNT++;
                                TBCustomer.AddCell(new PdfPCell(new Phrase(row1[1].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, PaddingLeft = 20 });
                                strNetAmount = "";
                                strNetAmountDebitComma = ""; strNetAmountCrComma = "";
                                if (row1[4].ToString() != "")
                                {
                                    strNetAmount = row1[4].ToString();
                                    decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                    strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                }
                                TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountDebitComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                strNetAmount = "";
                                strNetAmountDebitComma = ""; strNetAmountCrComma = "";

                                if (row1[5].ToString() != "")
                                {
                                    strNetAmount = row1[5].ToString();
                                    decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                    strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                }
                                TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                //Level3
                                DataRow[] result2 = dtCategory.Select("ACNT_PARENT_GRP_ID ='" + strId2 + "' AND LEVEL =3");
                                foreach (DataRow row2 in result2)
                                {


                                    decimal decDebAmnt2 = Convert.ToDecimal(row2[4].ToString());
                                    decimal decCreAmnt2 = Convert.ToDecimal(row2[5].ToString());
                                    if (ObjEntityRequest.Status == 1 || (ObjEntityRequest.Status == 0 && (decDebAmnt2 != 0 || decCreAmnt2 != 0)))
                                    {
                                        intCountGlbl++;
                                        COUNT++;
                                        TBCustomer.AddCell(new PdfPCell(new Phrase(row2[1].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, PaddingLeft = 40 });
                                        strNetAmount = "";
                                        strNetAmountDebitComma = ""; strNetAmountCrComma = "";
                                        if (row2[4].ToString() != "")
                                        {
                                            strNetAmount = row2[4].ToString();
                                            decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                            strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                        }
                                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountDebitComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                        strNetAmount = "";
                                        strNetAmountDebitComma = ""; strNetAmountCrComma = "";
                                        if (row2[5].ToString() != "")
                                        {
                                            strNetAmount = row2[5].ToString();
                                            decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                            strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                        }
                                        TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                    }
                                }
                            }
                        }
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
                    TBCustomer.AddCell(new PdfPCell(new Phrase("BALANCE", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    string strNetAmount = "";
                    string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                    string strNetAmount1 = "";
                    string strNetAmountDebitComma1 = "", strNetAmountCrComma1 = "";
                    if (STRBALANDR != "")
                    {
                        strNetAmount = STRBALANDR;
                        decimal NetAmount = Convert.ToDecimal(strNetAmount);
                        strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                    }
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    if (STRBALANCR != "")
                    {
                        strNetAmount1 = STRBALANCR;
                        decimal NetAmount1 = Convert.ToDecimal(strNetAmount1);
                        strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(NetAmount1.ToString(), objEntityCommon);
                    }
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountCrComma1, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    string strsum1 = "", strsum2 = "";
                    if (sum_debt == 0)
                    {
                        strsum1 = String.Format(format, sum_debt);
                    }
                    else
                    {
                        strsum1 = objBusiness.AddCommasForNumberSeperation(sum_debt.ToString(), objEntityCommon);
                    }
                    if (sum_Cedt == 0)
                    {
                        strsum2 = String.Format(format, sum_Cedt);
                    }
                    else
                    {
                        strsum2 = objBusiness.AddCommasForNumberSeperation(sum_Cedt.ToString(), objEntityCommon);
                    }
                    TBCustomer.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strsum1, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(strsum2, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
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
    public string LoadConvertToTableDetail_CSV(DataTable dtCategory, clsEntity_Trial_Bal ObjEntityRequest, int StsGrp, string strId1, string Printsts, string intAccntId, string dateto, string Mode, string ShowZero)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        DataTable dt = GetTableDetailList(dtCategory, ObjEntityRequest, StsGrp, strId1, Printsts, intAccntId, dateto, Mode, ShowZero);
        string strResult = DataTableToCSV(dt, ',');

        if (ObjEntityRequest.Corporate_id != 0)
        {
            objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        }
        if (ObjEntityRequest.Organisation_id != 0)
        {
            objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        }
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.TRIALBALANCE_CSV);
        string strNextId = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string filepath = "TrialBalanceList_" + strNextId + ".csv";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.TRIALBALANCE_CSV);
        string newFilePath = Server.MapPath(strImagePath + filepath);
        System.IO.File.WriteAllText(newFilePath, strResult);

        return strImagePath + filepath;
    }
    public DataTable GetTableDetailList(DataTable dtCategory, clsEntity_Trial_Bal ObjEntityRequest, int StsGrp, string strId1, string Printsts, string intAccntId, string dateto, string Mode, string ShowZero)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = ObjEntityRequest.Corporate_id, intOrgId = 0, intUserId = 0;
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
        string format = String.Format("{{0:N{0}}}", Decimalcount);
        decimal sum_Cedt = 0, sum_debt = 0;

        //Level1
        DataRow[] result = dtCategory.Select("LEVEL=1");

        foreach (DataRow row in result)
        {
            sum_Cedt += Convert.ToDecimal(row["TOTAL_CREDIT_AMNT"]);
            sum_debt += Convert.ToDecimal(row["TOTAL_DEB_AMNT"]);
        }

        string FORNULL = "";
        DataTable table = new DataTable();

        table.Columns.Add("TRIAL BALANCE", typeof(string));
        table.Columns.Add(" ", typeof(string));
        table.Columns.Add("  ", typeof(string));
        table.Columns.Add("   ", typeof(string));
        table.Columns.Add("    ", typeof(string));

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("DATE :", '"' + dateto + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("MODE :", '"' + "Detailed Account Group" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

        if (ShowZero == "1")
        {
            table.Rows.Add("SHOW ZERO BALANCE :", '"' + "YES" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        else
        {
            table.Rows.Add("SHOW ZERO BALANCE :", '"' + "NO" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

        table.Rows.Add('"' + "PARTICULARS" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + "DEBIT" + '"', '"' + "CREDIT" + '"'); 
        
        int COUNT = 0;
        int MainCOUNT = 0;
        //Level1
        foreach (DataRow row in result)
        {

            decimal decDebAmnt = Convert.ToDecimal(row[4].ToString());
            decimal decCreAmnt = Convert.ToDecimal(row[5].ToString());
            if (ObjEntityRequest.Status == 1 || (ObjEntityRequest.Status == 0 && (decDebAmnt != 0 || decCreAmnt != 0)))
            {

                intCountGlbl++;
                string strId = row[0].ToString();
                COUNT++;
                MainCOUNT++;
                
                string strNetAmount = "";
                string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                if (row[4].ToString() != "")
                {
                    strNetAmount = row[4].ToString();
                    decimal NetAmount = Convert.ToDecimal(strNetAmount);
                    strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                }

                if (row[5].ToString() != "")
                {
                    strNetAmount = row[5].ToString();
                    decimal NetAmount = Convert.ToDecimal(strNetAmount);
                    strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                }

                if (result.Count() > 0)
                {
                    table.Rows.Add('"' + row[1].ToString() + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + strNetAmountDebitComma + '"', '"' + strNetAmountCrComma + '"');
                }
                
                //Level2
                DataRow[] result1 = dtCategory.Select("ACNT_PARENT_GRP_ID ='" + strId + "' AND LEVEL =2");
                foreach (DataRow row1 in result1)
                {
                    decimal decDebAmnt1 = Convert.ToDecimal(row1[4].ToString());
                    decimal decCreAmnt1 = Convert.ToDecimal(row1[5].ToString());
                    if (ObjEntityRequest.Status == 1 || (ObjEntityRequest.Status == 0 && (decDebAmnt1 != 0 || decCreAmnt1 != 0)))
                    {
                        string strId2 = row1[0].ToString();
                        COUNT++;
                        
                        strNetAmount = "";
                        strNetAmountDebitComma = ""; strNetAmountCrComma = "";
                        if (row1[4].ToString() != "")
                        {
                            strNetAmount = row1[4].ToString();
                            decimal NetAmount = Convert.ToDecimal(strNetAmount);
                            strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                        }

                        if (row1[5].ToString() != "")
                        {
                            strNetAmount = row1[5].ToString();
                            decimal NetAmount = Convert.ToDecimal(strNetAmount);
                            strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                        }

                        if (result1.Count() > 0)
                        {
                            table.Rows.Add('"' + FORNULL + '"', '"' + row1[1].ToString() + '"', '"' + FORNULL + '"', '"' + strNetAmountDebitComma + '"', '"' + strNetAmountCrComma + '"');
                        }

                        //Level3
                        DataRow[] result2 = dtCategory.Select("ACNT_PARENT_GRP_ID ='" + strId2 + "' AND LEVEL =3");
                        foreach (DataRow row2 in result2)
                        {


                            decimal decDebAmnt2 = Convert.ToDecimal(row2[4].ToString());
                            decimal decCreAmnt2 = Convert.ToDecimal(row2[5].ToString());
                            if (ObjEntityRequest.Status == 1 || (ObjEntityRequest.Status == 0 && (decDebAmnt2 != 0 || decCreAmnt2 != 0)))
                            {
                                intCountGlbl++;
                                COUNT++;

                                strNetAmount = "";
                                strNetAmountDebitComma = ""; strNetAmountCrComma = "";
                                if (row2[4].ToString() != "")
                                {
                                    strNetAmount = row2[4].ToString();
                                    decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                    strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                }
                                if (row2[5].ToString() != "")
                                {
                                    strNetAmount = row2[5].ToString();
                                    decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                    strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                }

                                if (result2.Count() > 0)
                                {
                                    table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"','"' + row2[1].ToString() + '"', '"' + strNetAmountDebitComma + '"', '"' + strNetAmountCrComma + '"');
                                }
                            
                            }
                        }
                    }
                }
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
            string strNetAmount = "";
            string strNetAmountDebitComma = "", strNetAmountCrComma = "";
            string strNetAmount1 = "";
            string strNetAmountDebitComma1 = "", strNetAmountCrComma1 = "";
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

            table.Rows.Add('"' + "BALANCE" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + strNetAmountCrComma + '"', '"' + strNetAmountCrComma1 + '"');            
            
            string strsum1 = "", strsum2 = "";
            if (sum_debt == 0)
            {
                strsum1 = String.Format(format, sum_debt);
            }
            else
            {
                strsum1 = objBusiness.AddCommasForNumberSeperation(sum_debt.ToString(), objEntityCommon);
            }
            if (sum_Cedt == 0)
            {
                strsum2 = String.Format(format, sum_Cedt);
            }
            else
            {
                strsum2 = objBusiness.AddCommasForNumberSeperation(sum_Cedt.ToString(), objEntityCommon);
            }

            table.Rows.Add('"' + "TOTAL" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + strsum1 + '"', '"' + strsum2 + '"');            

        }

        return table;
    }


    //list check which print
    [WebMethod]
    public static string TrailBalance_List_Print(string ShowZero, string intuserid, string intorgid, string intcorpid, string datefrom, string dateto, string Mode, string strPrintMode)
    {
        string result = "";
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        clsEntity_Trial_Bal ObjEntityRequest = new clsEntity_Trial_Bal();
        clsBusinessLayer_Trial_Bal objBussiness = new clsBusinessLayer_Trial_Bal();
        FMS_FMS_Master_fms_Trial_Balance_fms_Trial_Balance OBJ = new FMS_FMS_Master_fms_Trial_Balance_fms_Trial_Balance();
        intUserId = Convert.ToInt32(intuserid);
        ObjEntityRequest.User_Id = intUserId;
        intCorpId = Convert.ToInt32(intcorpid);
        ObjEntityRequest.Corporate_id = intCorpId;
        intOrgId = Convert.ToInt32(intorgid);
        ObjEntityRequest.Organisation_id = intOrgId;
        if (dateto != "")
        {
            ObjEntityRequest.ToDate = ObjCommonlib.textToDateTime(dateto);
        }
        if (ShowZero == "1")
        {
            ObjEntityRequest.Status = 1;
        }

        int StsGrp = 0;
        DataTable dtCategory = new DataTable();
        if (Mode == "0")
        {
            dtCategory = objBussiness.TrailBalance_List(ObjEntityRequest);
        }
        else if (Mode == "1")
        {
            dtCategory = objBussiness.TrailBalance_ListLed(ObjEntityRequest);
        }
        if (Mode != "2")
        {
            string strId = "";
            string Printsts = "1";
            string intAccntId = "0";
            if (strPrintMode == "csv")
            {
                result = OBJ.LoadConvertToTable_CSV(dtCategory, ObjEntityRequest, StsGrp, strId, Printsts, intAccntId, dateto, Mode, ShowZero, "0");
            }
            else
            {
                result = OBJ.LoadConvertToTable_PDF(dtCategory, ObjEntityRequest, StsGrp, strId, Printsts, intAccntId, dateto, Mode, ShowZero, "0");
            }
        }
        else
        {
            dtCategory = objBussiness.TrailBalance_List_Detail(ObjEntityRequest);
            string strId = "";
            string Printsts = "0";
            string intAccntId = "0";
            Printsts = "1";
            if (strPrintMode == "csv")
            {
                result = OBJ.LoadConvertToTableDetail_CSV(dtCategory, ObjEntityRequest, StsGrp, strId, Printsts, intAccntId, dateto, Mode, ShowZero);
            }
            else
            {
                result = OBJ.LoadConvertToTableDetail_PDF(dtCategory, ObjEntityRequest, StsGrp, strId, Printsts, intAccntId, dateto, Mode, ShowZero);
            }
        }
        return result;
    }  

    //popup check which print
    [WebMethod]
    public static string[] TrailBalance_Lists_ById(string intAccntId, string intuserid, string intorgid, string intcorpid, string intdatefrom, string intdateto, string LdgrSts, string ShowZero)
    {

        intCountGlbl = 0;
        string[] result = new string[10];
        clsBusinessLayer_Trial_Bal objBussiness = new clsBusinessLayer_Trial_Bal();
        clsEntity_Trial_Bal objEntity = new clsEntity_Trial_Bal();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        FMS_FMS_Master_fms_Trial_Balance_fms_Trial_Balance obj = new FMS_FMS_Master_fms_Trial_Balance_fms_Trial_Balance();
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
        objEntity.Status = Convert.ToInt32(ShowZero);
        StringBuilder sb = new StringBuilder();
        string strNetAmount = "", strsurAbrv = "", strNetAmountWithComma = "";

        if (LdgrSts == "0")
        {
            DataTable dtList = objBussiness.TrailBalance_List_ById(objEntity);
            int StsGrp = 1;
            string Printsts = "0";
            result[1] = obj.LoadConvertToTable(dtList, objEntity, StsGrp, strId, Printsts, intAccntId);
            Printsts = "1";
            //result[4] = obj.LoadConvertToTable(dtList, objEntity, StsGrp, strId, Printsts, intAccntId);
            result[0] = intCountGlbl.ToString();
            result[2] = strId;
            //result[3] = obj.PrintCaption(objEntity, StsGrp, strId);
        }
        else
        {
            DataTable dtList = objBussiness.LedgerTransDtls(objEntity);
            DataTable dtOpenBalance = objBussiness.ReadLedgOpenBal(objEntity);
            int countR = dtList.Rows.Count;
            if (dtOpenBalance.Rows.Count > 0 && Convert.ToDecimal(dtOpenBalance.Rows[0]["TOTAL_DEB_AMNT"].ToString()) != 0)
            {
                countR++;
            }
            int StsGrp = 1;
            string Printsts = "0";
            result[1] = obj.LoadConvertToTableLed(dtList, dtOpenBalance, objEntity, StsGrp, strId, Printsts, intAccntId);
            Printsts = "1";
            //result[4] = obj.LoadConvertToTableLed(dtList, dtOpenBalance, objEntity, StsGrp, strId, Printsts, intAccntId);
            result[0] = countR.ToString();
            result[2] = strId;
            //result[3] = obj.PrintCaption(objEntity, StsGrp, strId);
        }
        return result;
    }
    [WebMethod]
    public static string[] TrailBalance_Lists_ById_Print(string intAccntId, string intuserid, string intorgid, string intcorpid, string intdatefrom, string intdateto, string LdgrSts, string ShowZero, string Mode, string Ledgername, string strPrintMode)
    {
        intCountGlbl = 0;
        string[] result = new string[10];
        clsBusinessLayer_Trial_Bal objBussiness = new clsBusinessLayer_Trial_Bal();
        clsEntity_Trial_Bal objEntity = new clsEntity_Trial_Bal();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        FMS_FMS_Master_fms_Trial_Balance_fms_Trial_Balance obj = new FMS_FMS_Master_fms_Trial_Balance_fms_Trial_Balance();
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
        objEntity.Status = Convert.ToInt32(ShowZero);

        if (Ledgername.Contains("‡") == true)
        {
            Ledgername = Ledgername.Replace("‡", "\"");
        }
        if (Ledgername.Contains("¦") == true)
        {
            Ledgername = Ledgername.Replace("¦", "\'");
        }

        StringBuilder sb = new StringBuilder();
        string strNetAmount = "", strsurAbrv = "", strNetAmountWithComma = "";

        if (LdgrSts == "0")
        {
            DataTable dtList = objBussiness.TrailBalance_List_ById(objEntity);
            int StsGrp = 1;
            string Printsts = "1";
            Printsts = "1";
            if (strPrintMode == "csv")
            {
                result[0] = obj.LoadConvertToTable_CSV(dtList, objEntity, StsGrp, strId, Printsts, intAccntId, intdateto, Mode, ShowZero, Ledgername);
            }
            else
            {
                result[0] = obj.LoadConvertToTable_PDF(dtList, objEntity, StsGrp, strId, Printsts, intAccntId, intdateto, Mode, ShowZero, Ledgername);
            }
        }
        else
        {
            DataTable dtList = objBussiness.LedgerTransDtls(objEntity);
            DataTable dtOpenBalance = objBussiness.ReadLedgOpenBal(objEntity);
            int countR = dtList.Rows.Count;
            if (dtOpenBalance.Rows.Count > 0 && Convert.ToDecimal(dtOpenBalance.Rows[0]["TOTAL_DEB_AMNT"].ToString()) != 0)
            {
                countR++;
            }
            int StsGrp = 1;
            string Printsts = "0";
            Printsts = "1";
            if (strPrintMode == "csv")
            {
                result[0] = obj.LoadConvertToTableLed_CSV(dtList, dtOpenBalance, objEntity, StsGrp, strId, Printsts, intAccntId, Ledgername, intdateto, Mode, ShowZero);
            }
            else
            {
                result[0] = obj.LoadConvertToTableLed_PDF(dtList, dtOpenBalance, objEntity, StsGrp, strId, Printsts, intAccntId, Ledgername, intdateto, Mode, ShowZero);
            }
        }
        return result;
    }


    //list detail ledger popup
    public string LoadConvertToTableLed(DataTable dtCategory, DataTable dtOpenBalance, clsEntity_Trial_Bal ObjEntityRequest, int StsGrp, string strId1, string Printsts, string intAccntId)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer_Trial_Bal objBussiness = new clsBusinessLayer_Trial_Bal();
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();

        int intCorpId = 0;

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

        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        string strHtml = "";
        if (Printsts == "0")
        {

            strHtml = "<table id=\"datatable_fixed_column" + strId1 + "\" class=\"display table-bordered\" width=\"100%\" >";
            //add header row
            strHtml += "<thead class=\"thead1\">";

            strHtml += "<tr >";
            strHtml += "<th class=\"col-md-2 tr_c\" >DATE ";
            strHtml += " <i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input class=\"tb_inp_1 tb_in tr_c\" placeholder=\"DATE \" type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-3 tr_l\" >TRANS TYPE ";
            strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input class=\"tb_inp_1 tb_in tr_l\" placeholder=\"TRANS TYPE \" type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-3 tr_c\" >REF# ";
            strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input class=\"tb_inp_1 tb_in tr_c\" placeholder=\"REF# \" type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-2 tr_r\" >DEBIT ";
            strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input class=\"tb_inp_1 tb_in tr_r\" placeholder=\"DEBIT\"  type=\"text\">";
            strHtml += "</th >";
            strHtml += "<th class=\"col-md-2 tr_r\" >CREDIT ";
            strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input class=\"tb_inp_1 tb_in tr_r\" placeholder=\"CREDIT\"  type=\"text\">";
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
                strHtml += "<td class=\"tr_c\" >" + dtOpenBalance.Rows[0]["STRTDATE"].ToString() + "</td>";
                strHtml += "<td class=\"tr_l\"  >Opening Balance</td>";
                strHtml += "<td class=\"tr_l\" ></td>";
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
                    strHtml += "<td class=\"tr_r\"  style=\"text-align:right;\">" + strNetAmountDebitComma + "</td>";
                    strHtml += "<td class=\"tdT\" ></td>";
                }
                else if (OpenBal < 0)
                {
                    strHtml += "<td class=\"tdT\"  style=\"text-align:right;\"></td>";
                    strHtml += "<td class=\"tr_r\"  > " + strNetAmountDebitComma + "</td>";
                }
                strHtml += "</tr>";
            }
        }


        for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
        {
            COUNT++;
            string VchrSts = dtCategory.Rows[intRowBodyCount]["VOCHR_STS"].ToString();

            strHtml += "<tr>";
            strHtml += "<td class=\"tr_c\"  >" + dtCategory.Rows[intRowBodyCount]["VOCHR_DATE"].ToString() + "</td>";
            strHtml += "<td class=\"tr_l\"  >" + dtCategory.Rows[intRowBodyCount]["VOCHR_TYPE"].ToString() + "</td>";
            strHtml += "<td class=\"tr_l\" >" + dtCategory.Rows[intRowBodyCount]["VOCHR_REF"].ToString() + "</td>";


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
                strHtml += "<td class=\"tr_r\"  style=\"text-align:right;\">" + strNetAmountDebitComma + "</td>";
                strHtml += "<td class=\"tdT\" style=\"text-align:right;\"></td>";
            }
            else
            {
                strHtml += "<td class=\"tdT\" style=\"text-align:right;\"></td>";
                strHtml += "<td class=\"tr_r\" style=\"text-align:right;\" > " + strNetAmountDebitComma + "</td>";
            }
            strHtml += "</tr>";
        }
        strHtml += "</tbody>";

        if (Printsts == "0")
        {
            strHtml += " <tfoot><tr>";
            //strHtml += "<td class=\"tdT\"  > </td>";
            strHtml += "<td class=\"tr_c ft_bld\"  colspan=\"3\" style=\"text-align:right !important;\">GRAND TOTAL</td>";
            //strHtml += "<td class=\"tdT\"  ></td>";
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
            strHtml += "<td class=\"tr_r ft_bld\"  style=\"text-align:right;\"> " + strNetAmountCrComma + "</td>";
            strHtml += "<td class=\"tr_r ft_bld\" style=\"text-align:right;\" > " + strNetAmountCrComma1 + "</td>";
            strHtml += " </tr>";
            strHtml += "</tfoot>";
        }
        else
        {
            strHtml += " <tfoot><tr style=\"font-weight: Bold;\">";
            //strHtml += "<td class=\"tdT\"  > </td>";
            strHtml += "<td class=\"tr_c ft_bld\"  colspan=\"3\" style=\"text-align:right !important;\">GRAND TOTAL</td>";
            //strHtml += "<td class=\"tdT\"  ></td>";
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
            strHtml += "<td class=\"tr_r ft_bld\"  style=\"text-align:right;\"> " + strNetAmountCrComma + "</td>";
            strHtml += "<td class=\"tr_r ft_bld\" style=\"text-align:right;\" > " + strNetAmountCrComma1 + "</td>";
            strHtml += " </tr>";
            strHtml += "</tfoot>";
        }
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    public string LoadConvertToTableLed_PDF(DataTable dtCategory, DataTable dtOpenBalance, clsEntity_Trial_Bal ObjEntityRequest, int StsGrp, string strId1, string Printsts, string intAccntId, string Ledgername, string intdateto, string Mode, string ShowZero)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer_Trial_Bal objBussiness = new clsBusinessLayer_Trial_Bal();
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = 0;
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
        string strRandom = objCommon.Random_Number();
        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.TRIAL_BALANCE_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.TRIAL_BALANCE_PDF);
        objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "TBLedgerList_" + strNextNumber + ".pdf";

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
                float[] footrsBody1 = { 30, 5, 65 };
                footrtable.SetWidths(footrsBody1);
                footrtable.WidthPercentage = 100;

                footrtable.AddCell(new PdfPCell(new Phrase("DATE     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(intdateto, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase("LEDGER     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(Ledgername, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (Mode == "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("MODE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase("Consolidated Account Group", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                else
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("MODE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase("Ledger", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
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
                PdfPTable TBCustomer = new PdfPTable(5);
                float[] footrsBody = { 12, 18, 20, 25, 25 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;//get header column in all pages

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("DATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("TRANS TYPE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("REF#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("DEBIT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("CREDIT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                int COUNT = 0;
                if (dtOpenBalance.Rows.Count > 0)
                {
                    decimal OpenBal = Convert.ToDecimal(dtOpenBalance.Rows[0]["TOTAL_DEB_AMNT"].ToString());
                    if (OpenBal != 0)
                    {
                        COUNT++;
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtOpenBalance.Rows[0]["STRTDATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase("Opening Balance", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
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
                            TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                        else if (OpenBal < 0)
                        {
                            TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            TBCustomer.AddCell(new PdfPCell(new Phrase(strNetAmountDebitComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        }
                    }
                }
                for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
                {
                    COUNT++;
                    string VchrSts = dtCategory.Rows[intRowBodyCount]["VOCHR_STS"].ToString();
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["VOCHR_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
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
                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }
                    else
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
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
    public string LoadConvertToTableLed_CSV(DataTable dtCategory, DataTable dtOpenBalance, clsEntity_Trial_Bal ObjEntityRequest, int StsGrp, string strId1, string Printsts, string intAccntId, string Ledgername, string intdateto, string Mode, string ShowZero)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        DataTable dt = GetTableDetailLed(dtCategory, dtOpenBalance, ObjEntityRequest, StsGrp, strId1, Printsts, intAccntId, Ledgername, intdateto, Mode, ShowZero);
        string strResult = DataTableToCSV(dt, ',');

        if (ObjEntityRequest.Corporate_id != 0)
        {
            objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        }
        if (ObjEntityRequest.Organisation_id != 0)
        {
            objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        }
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.TRIALBALANCE_CSV);
        string strNextId = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string filepath = "TrialBalanceLedger_" + strNextId + ".csv";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.TRIALBALANCE_CSV);
        string newFilePath = Server.MapPath(strImagePath + filepath);
        System.IO.File.WriteAllText(newFilePath, strResult);

        return strImagePath + filepath;
    }
    public DataTable GetTableDetailLed(DataTable dtCategory, DataTable dtOpenBalance, clsEntity_Trial_Bal ObjEntityRequest, int StsGrp, string strId1, string Printsts, string intAccntId, string Ledgername, string intdateto, string Mode, string ShowZero)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer_Trial_Bal objBussiness = new clsBusinessLayer_Trial_Bal();
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = 0;
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

        string FORNULL = "";
        DataTable table = new DataTable();

        table.Columns.Add("TRIAL BALANCE", typeof(string));
        table.Columns.Add(" ", typeof(string));
        table.Columns.Add("  ", typeof(string));
        table.Columns.Add("   ", typeof(string));
        table.Columns.Add("    ", typeof(string));

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

        table.Rows.Add('"' + "DATE" + '"', '"' + intdateto + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add('"' + "LEDGER" + '"', '"' + Ledgername + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        if (Mode == "0")
        {
            table.Rows.Add('"' + "MODE" + '"', '"' + "Consolidated Account Group" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        else
        {
            table.Rows.Add('"' + "MODE" + '"', '"' + "Ledger" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        if (ShowZero == "1")
        {
            table.Rows.Add('"' + "SHOW ZERO BALANCE" + '"', '"' + "YES" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        else
        {
            table.Rows.Add('"' + "SHOW ZERO BALANCE" + '"', '"' + "NO" + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

        table.Rows.Add('"' + "DATE" + '"', '"' + "TRANS TYPE" + '"', '"' + "REF#" + '"', '"' + "DEBIT" + '"', '"' + "CREDIT" + '"');


        int COUNT = 0;
        if (dtOpenBalance.Rows.Count > 0)
        {
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
                string DebitAmnt = "";
                string CreditAmnt = "";

                if (OpenBal > 0)
                {
                    DebitAmnt = strNetAmountDebitComma;
                }
                else if (OpenBal < 0)
                {
                    CreditAmnt = strNetAmountDebitComma;
                }

                table.Rows.Add('"' + dtOpenBalance.Rows[0]["STRTDATE"].ToString() + '"', '"' + "Opening Balance" + '"', '"' + FORNULL + '"', '"' + DebitAmnt + '"', '"' + CreditAmnt + '"');

            }
        }
        for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
        {
            COUNT++;
            string VchrSts = dtCategory.Rows[intRowBodyCount]["VOCHR_STS"].ToString();

            string strNetAmount = "";
            string strNetAmountDebitComma = "";
            if (dtCategory.Rows[intRowBodyCount]["VOCHR_AMT"].ToString() != "")
            {
                strNetAmount = dtCategory.Rows[intRowBodyCount]["VOCHR_AMT"].ToString();
                strNetAmount = strNetAmount.Replace(@"-", string.Empty);
                strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
            }
            string DebitAmnt = "";
            string CreditAmnt = "";

            if (VchrSts == "0")
            {
                DebitAmnt = strNetAmountDebitComma;
            }
            else
            {
                CreditAmnt = strNetAmountDebitComma;
            }

            table.Rows.Add('"' + dtCategory.Rows[intRowBodyCount]["VOCHR_DATE"].ToString() + '"', '"' + dtCategory.Rows[intRowBodyCount]["VOCHR_TYPE"].ToString() + '"', '"' + dtCategory.Rows[intRowBodyCount]["VOCHR_REF"].ToString() + '"', '"' + DebitAmnt + '"', '"' + CreditAmnt + '"');

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

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + "GRAND TOTAL" + '"', '"' + strNetAmountCrComma + '"', '"' + strNetAmountCrComma1 + '"');

        return table;
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        clsEntity_Trial_Bal ObjEntityRequest = new clsEntity_Trial_Bal();
        clsBusinessLayer_Trial_Bal objBussiness = new clsBusinessLayer_Trial_Bal();
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
        if (cbxCnclStatus.Checked == true)
        {
            ObjEntityRequest.Status = 1;
            HiddenFieldShowZero.Value = "1";
        }
        else
        {
            HiddenFieldShowZero.Value = "0";
        }
        int StsGrp = 0;
        DataTable dtCategory = new DataTable();
        if (ddlMode.SelectedItem.Value == "0")
        {
            dtCategory = objBussiness.TrailBalance_List(ObjEntityRequest);
        }
        else if (ddlMode.SelectedItem.Value == "1")
        {
            dtCategory = objBussiness.TrailBalance_ListLed(ObjEntityRequest);
        }
        HiddenFieldSearchDate.Value = txtTodate.Value;
        if (ddlMode.SelectedItem.Value != "2")
        {
            string strId = "";
            string Printsts = "0";
            string intAccntId = "0";
            divList.InnerHtml = LoadConvertToTable(dtCategory, ObjEntityRequest, StsGrp, strId, Printsts, intAccntId);
            Printsts = "1";
        }
        else
        {
            dtCategory = objBussiness.TrailBalance_List_Detail(ObjEntityRequest);
            string strId = "";
            string Printsts = "0";
            string intAccntId = "0";
            divList.InnerHtml = LoadConvertToTableDetail(dtCategory, ObjEntityRequest, StsGrp, strId, Printsts, intAccntId);
            Printsts = "1";
        }
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
            headtable.AddCell(new PdfPCell(new Phrase("TRIAL BALANCE", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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
}