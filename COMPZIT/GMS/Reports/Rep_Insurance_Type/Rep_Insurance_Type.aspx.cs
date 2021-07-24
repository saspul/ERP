using BL_Compzit.BusinessLayer_GMS;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CL_Compzit;
using EL_Compzit.EntityLayer_GMS;
using BL_Compzit;
using System.Web.Services;
using EL_Compzit;
using System.IO;
using System.Collections.Generic;
using System.Linq;
public partial class GMS_Reports_Rep_Insurance_Type_Rep_Insurance_Type : System.Web.UI.Page
{
    clsBusinessLayerInsReports ObjBussinessReports = new clsBusinessLayerInsReports();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            divTitle.InnerHtml = "Insurance Type Report";
            clsEntityReports ObjEntityReports = new clsEntityReports();
            clsBusinessLayerInsReports objBusinessLayerReports = new clsBusinessLayerInsReports();
            ReadDivision();

            InsuranceTypeLoad();
            CurrencyLoad();
            ddlDivision.Focus();


            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {

                ObjEntityReports.User_Id = Convert.ToInt32(Session["USERID"].ToString());

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                ObjEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                ObjEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE ,
                                                                clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                                clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                                
                                                               };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {

                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();

                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            }

            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
            }

            if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
            {
                string strHidden = Request.QueryString["Srch"].ToString();
                HiddenSearchField.Value = strHidden;

                string[] strSearchFields = strHidden.Split(',');
                string strDivision = strSearchFields[0];

                string strInsuranceType = strSearchFields[1];

                if (strDivision != null && strDivision != "")
                {
                    if (ddlDivision.Items.FindByValue(strDivision) != null)
                    {
                        if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
                        {
                            ddlDivision.ClearSelection();
                            ddlDivision.Items.FindByValue(strDivision).Selected = true;
                        }
                    }
                }

                if (strInsuranceType != null && strInsuranceType != "")
                {
                    if (ddlInsuranceType.Items.FindByValue(strInsuranceType) != null)
                    {
                        if (ddlInsuranceType.SelectedItem.Value != "--SELECT INSURANCE TYPE--")
                        {
                            ddlInsuranceType.ClearSelection();
                            ddlInsuranceType.Items.FindByValue(strInsuranceType).Selected = true;
                        }
                    }
                }

            }






            if (HiddenSearchField.Value == "")
            {

                ObjEntityReports.Division_Id = 0;
                 ObjEntityReports.InsuranceType = 0;
            }
            else
            {
                string strHidden = "";
                strHidden = HiddenSearchField.Value;
                string[] strSearchFields = strHidden.Split(',');
                string strDivision = strSearchFields[0];
                string strInsuranceType = strSearchFields[1];
                if (strDivision != null && strDivision != "")
                {
                    if (ddlDivision.Items.FindByValue(strDivision) != null)
                    {
                        if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
                        {
                            ddlDivision.ClearSelection();
                            ddlDivision.Items.FindByValue(strDivision).Selected = true;
                            ObjEntityReports.Division_Id = Convert.ToInt32(strDivision);
                        }
                    }
                }


                if (strInsuranceType != null && strInsuranceType != "")
                {
                    if (ddlInsuranceType.Items.FindByValue(strInsuranceType) != null)
                    {
                        if (ddlInsuranceType.SelectedItem.Value != "--SELECT INSURANCE TYPE--")
                        {
                            ddlInsuranceType.ClearSelection();
                            ddlInsuranceType.Items.FindByValue(strInsuranceType).Selected = true;
                             ObjEntityReports.InsuranceType = Convert.ToInt32(strInsuranceType);
                        }
                    }
                }


            }
            DataTable dtInsurance = new DataTable();

          dtInsurance = ObjBussinessReports.Read_Insurance_TypeReport(ObjEntityReports);
            string strHtm = ConvertDataTableToHTML(dtInsurance);
            //Write to divReport
            divReport.InnerHtml = strHtm;
            DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(ObjEntityReports);
            string strPrintReport = ConvertDataTableForPrint(dtInsurance, dtCorp);
            divPrintReport.InnerHtml = strPrintReport;

        }

    }
  
    public void InsuranceTypeLoad()
    {

        clsEntityReports ObjEntityReports = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {

            ObjEntityReports.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtInsuranceType = ObjBussinessReports.ReadInsurance_Type(ObjEntityReports);
        if (dtInsuranceType.Rows.Count > 0)
        {
            ddlInsuranceType.DataSource = dtInsuranceType;
            ddlInsuranceType.DataTextField = "INSRC_TYPMSTR_NAME";
            ddlInsuranceType.DataValueField = "INSRC_TYPMSTR_ID";
            ddlInsuranceType.DataBind();

        }

        ddlInsuranceType.Items.Insert(0, "--SELECT INSURANCE TYPE--");

    }
    //for binding dropdown
    public void ReadDivision()
    {

        clsEntityReports ObjEntityReports = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {

            ObjEntityReports.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtdivision = ObjBussinessReports.Read_Division(ObjEntityReports);
        if (dtdivision.Rows.Count > 0)
        {
            ddlDivision.DataSource = dtdivision;
            ddlDivision.DataTextField = "CPRDIV_NAME";
            ddlDivision.DataValueField = "CPRDIV_ID";
            ddlDivision.DataBind();

        }

        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");

    }

    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);


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

            else if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: CENTER; word-wrap:break-word;\">DATE</th>";
            }


            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">INSURANCE CATEGORY</th>";
            }

            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: CENTER; word-wrap:break-word;\">INSURANCE PROVIDER</th>";
            }

            else if (intColumnHeaderCount == 5)
            {

                strHtml += "<th class=\"thT\"  style=\"width:4%;text-align: right; word-wrap:break-word;\">AGE (Days)</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: CENTER; word-wrap:break-word;\">EXPIRY DATE</th>";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">PROJECT REF#</th>";
            }

            else if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: right; word-wrap:break-word;\">AMOUNT</th>";
            }
            else if (intColumnHeaderCount == 8)
            {
                strHtml += "<th class=\"thT\"  style=\"width:7%;text-align: center; word-wrap:break-word;\">CURRENCY</th>";
            }
        }



        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        int count = 0;

        lblToalRowCount.Text = "0";
        if ((ddlDivision.SelectedItem.Text != "--SELECT DIVISION--") || (ddlInsuranceType.SelectedItem.Text != "--SELECT INSURANCE TYPE--"))
        {
            lblToalRowCount.Text = dt.Rows.Count.ToString();
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {


                strHtml += "<tr  >";
                count++;
                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count + "</td>";

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {


                    if (intColumnBodyCount == 0)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["INSURANCE_REF_NUM"].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 1)
                    {

                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["INSURANCE_DATE"].ToString() + "</td>";
                    }

                    else if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["INSURNCTYPE_NAME"].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["INSURPRVDR_NAME"].ToString() + "</td>";
                    }

                    else if (intColumnBodyCount == 4)
                    {


                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["INSURANCE_EXP_DATE"].ToString() + "</td>";

                    }

                    else if (intColumnBodyCount == 5)
                    {

                        strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + dt.Rows[intRowBodyCount]["INSURANCE_NO_DAYS"].ToString() + "</td>";

                    }
                    else if (intColumnBodyCount == 6)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PROJECT REF#"].ToString() + "</td>";
                    }

                    else if (intColumnBodyCount == 7)
                    {
                        string strNetAmount = dt.Rows[intRowBodyCount]["INSURANCE_AMOUNT"].ToString();
                        string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strNetAmountWithComma.ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 8)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                        HiddenCurrency.Value = dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString();
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
    // at search button click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //Creating objects for business layer

        clsBusinessLayerInsReports objBusinessLayerReports = new clsBusinessLayerInsReports();


        clsEntityReports ObjEntityReports = new clsEntityReports();
        if (HiddenSearchField.Value == "")
        {
            ObjEntityReports.GuarCatgryId = 0;
            ObjEntityReports.Division_Id = 0;
             ObjEntityReports.InsuranceType = 0;
        }
        else
        {
            string strHidden = "";
            strHidden = HiddenSearchField.Value;
            string[] strSearchFields = strHidden.Split(',');
            string strDivision = strSearchFields[0];
            string strInsuranceType = strSearchFields[1];
            if (strDivision != null && strDivision != "")
            {
                if (ddlDivision.Items.FindByValue(strDivision) != null)
                {
                    if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
                    {
                        ddlDivision.ClearSelection();
                        ddlDivision.Items.FindByValue(strDivision).Selected = true;
                        ObjEntityReports.Division_Id = Convert.ToInt32(strDivision);
                    }
                }
            }

            if (strInsuranceType != null && strInsuranceType != "")
            {
                if (ddlInsuranceType.Items.FindByValue(strInsuranceType) != null)
                {
                    if (ddlInsuranceType.SelectedItem.Value != "--SELECT INSURANCE TYPE--")
                    {
                        ddlInsuranceType.ClearSelection();
                        ddlInsuranceType.Items.FindByValue(strInsuranceType).Selected = true;
                        ObjEntityReports.InsuranceType = Convert.ToInt32(strInsuranceType);
                    }
                }
            }


        }
        if (Session["USERID"] != null)
        {

            ObjEntityReports.User_Id = Convert.ToInt32(Session["USERID"].ToString());

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ObjEntityReports.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);

        DataTable dtInsurance = new DataTable();
        dtInsurance = ObjBussinessReports.Read_Insurance_TypeReport(ObjEntityReports);




        string strHtm = ConvertDataTableToHTML(dtInsurance);
        //Write to divReport
        divReport.InnerHtml = strHtm;
        DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(ObjEntityReports);
        string strPrintReport = ConvertDataTableForPrint(dtInsurance, dtCorp);
        divPrintReport.InnerHtml = strPrintReport;
    }

    public string ConvertDataTableForPrint(DataTable dt, DataTable dtCorp)
    {

        clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";

        strTitle = "Insurance Type Report";

        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string usrName = "<B> Report Generated By: </B>" + Session["USERFULLNAME"];
        string strHidden = "", GuaranteDivsn = "", GuaranteCatgry = "", GuaranteePrjct = "";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        if (HiddenSearchField.Value.ToString() != "")
        {
            strHidden = HiddenSearchField.Value;
            string[] strSearchFields = strHidden.Split(',');
            string strDivision = strSearchFields[0];
            string strInsuranceType = strSearchFields[1];

            if (strDivision != null && strDivision != "")
            {
                if (ddlDivision.Items.FindByValue(strDivision) != null)
                {
                    if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
                    {
                        ddlDivision.ClearSelection();
                        ddlDivision.Items.FindByValue(strDivision).Selected = true;
                        GuaranteDivsn = "<B>Division  : </B>" + ddlDivision.SelectedItem.Text;
                    }
                }
            }

            if (strInsuranceType != null && strInsuranceType != "")
            {
                if (ddlInsuranceType.Items.FindByValue(strInsuranceType) != null)
                {
                    if (ddlInsuranceType.SelectedItem.Value != "--SELECT INSURANCE TYPE--")
                    {
                        ddlInsuranceType.ClearSelection();
                        ddlInsuranceType.Items.FindByValue(strInsuranceType).Selected = true;
                        GuaranteePrjct = "<B>Insurance Type: </B>" + ddlInsuranceType.SelectedItem.Text;
                    }
                }
            }

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
        string strUsrName = "";
        string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr1 + "</td></tr>";

        string strCaptionTabRprtDate = "", strCaptionTabTitle = "", strGuaranteDivsn = "", strGuaranteCatgry = "", strGuaranteePrjct = "";
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
        if (GuaranteePrjct != "")
        {
            strGuaranteePrjct = "<tr><td class=\"RprtDiv\">" + GuaranteePrjct + "</td></tr>";
        }

        if (usrName != "")
        {
            strUsrName = "<tr><td class=\"RprtDiv\">" + usrName + "</td></tr>";
        }
        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strGuaranteDivsn + strGuaranteCatgry + strGuaranteePrjct + strUsrName + strCaptionTabTitle + strCaptionTabstop;
        sbCap.Append(strPrintCaptionTable);
        ////write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString();
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
                strHtml += "<th class=\"thT\" style=\"width:13%;text-align: left; word-wrap:break-word;\">Insurance REF#</th>";
            }

            else if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: CENTER; word-wrap:break-word;\">DATE</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:14%;text-align: left; word-wrap:break-word;\">CUSTOMER NAME</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">Insurance CATEGORY</th>";
            }


            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: CENTER; word-wrap:break-word;\">EXPIRY DATE</th>";
            }

            else if (intColumnHeaderCount == 5)
            {

                strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: right; word-wrap:break-word;\">AGE</th>";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: CENTER; word-wrap:break-word;\">BANK</th>";
            }
            else if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: LEFT; word-wrap:break-word;\">PROJECT REF#</th>";
            }
            else if (intColumnHeaderCount == 8)
            {
                strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: left; word-wrap:break-word;\">JOB CODE</th>";
            }
            else if (intColumnHeaderCount == 9)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: right; word-wrap:break-word;\">AMOUNT</th>";
            }
            else if (intColumnHeaderCount == 10)
            {
                strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: left; word-wrap:break-word;\">CURRENCY</th>";
            }
        }
        strHtml += "</tr>";
        strHtml += "</thead>";
        strHtml += "<tbody>";
        int count = 0;

        if (dt.Rows.Count > 0)
        {

            var result = from tab in dt.AsEnumerable()
                         group tab by tab["CRNCMST_ABBRV"]
                             into groupDt
                             select new
                             {
                                 Group = groupDt.Key,
                                 Sum = groupDt.Sum((r) => decimal.Parse(r["INSURANCE_AMOUNT"].ToString()))
                             };


            if ((ddlDivision.SelectedItem.Text != "--SELECT DIVISION--") || (ddlInsuranceType.SelectedItem.Text != "--SELECT INSURANCE TYPE--"))
            {
                for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
                {
                    strHtml += "<tr id=\"TableRprtRow\" >";
                    count++;
                    strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count + "</td>";

                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {


                        if (intColumnBodyCount == 0)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["INSURANCE_REF_NUM"].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 1)
                        {

                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["INSURANCE_DATE"].ToString() + "</td>";
                        }

                        else if (intColumnBodyCount == 2)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["INSURNCTYPE_NAME"].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 3)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["INSURPRVDR_NAME"].ToString() + "</td>";
                        }

                        else if (intColumnBodyCount == 4)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["INSURANCE_EXP_DATE"].ToString() + "</td>";

                        }

                        else if (intColumnBodyCount == 5)
                        {

                            strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + dt.Rows[intRowBodyCount]["INSURANCE_NO_DAYS"].ToString() + "</td>";

                        }
                        else if (intColumnBodyCount == 6)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PROJECT REF#"].ToString() + "</td>";
                        }

                        else if (intColumnBodyCount == 7)
                        {
                            string strNetAmount = dt.Rows[intRowBodyCount]["INSURANCE_AMOUNT"].ToString();
                            string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strNetAmountWithComma.ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 8)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                            HiddenCurrency.Value = dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString();
                        }
                    }


                    strHtml += "</tr>";
                }

                foreach (var row in result)
                {
                    strHtml += "<tr id=\"TableRprtRow\" >";
                    strHtml += "<tfoot>";
                    strHtml += "<td  class=\"tdT\" colspan=\"10\"; style=\"border-right-color: white;font-size: SMALL;width:6%;word-break: break-all; word-wrap:break-word;text-align: right;\" >Total</td>";
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
                strHtml += "<td  class=\"tdT\" colspan=\"12\"; style=\" border-right: navajowhite;font-size: SMALL;width:6%;word-break: break-all; word-wrap:break-word;text-align: CENTER;\" >No Data Available</td>";
                strHtml += "</tfoot>";
            }
        }
        else
        {
            strHtml += "<tr id=\"TableRprtRow\" >";
            strHtml += "<tfoot>";
            strHtml += "<td  class=\"tdT\" colspan=\"10\"; style=\" border-right: navajowhite;font-size: SMALL;width:6%;word-break: break-all; word-wrap:break-word;text-align: CENTER;\" >No Data Available</td>";
            strHtml += "</tfoot>";
        }
        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();

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
        clsBusinessLayerInsReports objBusinessLayerReports = new clsBusinessLayerInsReports();

        clsEntityReports ObjEntityReports = new clsEntityReports();
        if (HiddenSearchField.Value == "")
        {
            //ObjEntityReports.GuarCatgryId = 0;
            ObjEntityReports.Division_Id = 0;
             ObjEntityReports.InsuranceType = 0;
        }
        else
        {
            string strHidden = "";
            strHidden = HiddenSearchField.Value;
            string[] strSearchFields = strHidden.Split(',');
            string strDivision = strSearchFields[0];

            string strInsuranceType = strSearchFields[1];
            if (strDivision != null && strDivision != "")
            {
                if (ddlDivision.Items.FindByValue(strDivision) != null)
                {
                    if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
                    {
                        ddlDivision.ClearSelection();
                        ddlDivision.Items.FindByValue(strDivision).Selected = true;
                        ObjEntityReports.Division_Id = Convert.ToInt32(strDivision);
                    }
                }
            }

            if (strInsuranceType != null && strInsuranceType != "")
            {
                if (ddlInsuranceType.Items.FindByValue(strInsuranceType) != null)
                {
                    if (ddlInsuranceType.SelectedItem.Value != "--SELECT INSURANCE TYPE--")
                    {
                        ddlInsuranceType.ClearSelection();
                        ddlInsuranceType.Items.FindByValue(strInsuranceType).Selected = true;
                         ObjEntityReports.InsuranceType = Convert.ToInt32(strInsuranceType);
                    }
                }
            }
        }
        if (Session["USERID"] != null)
        {
            ObjEntityReports.User_Id = Convert.ToInt32(Session["USERID"].ToString());

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ObjEntityReports.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
        DataTable dt = new DataTable();

        dt = ObjBussinessReports.Read_Insurance_TypeReport(ObjEntityReports);
        DataTable table = new DataTable();
        table.Columns.Add("INSURANCE REF#", typeof(string));
        table.Columns.Add("DATE", typeof(string));

        table.Columns.Add("INSURANCE CATEGORY", typeof(string));
        table.Columns.Add("EXPIRY DATE", typeof(string));
        table.Columns.Add("AGE", typeof(string));
        table.Columns.Add("INSURANCE PROVIDER", typeof(string));
        table.Columns.Add("PROJECT REF#", typeof(string));

        table.Columns.Add("AMOUNT", typeof(string));
        table.Columns.Add("CURRENCY", typeof(string));

        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        string strRandom = objCommon.Random_Number();
        if ((ddlDivision.SelectedItem.Text != "--SELECT DIVISION--") || (ddlInsuranceType.SelectedItem.Text != "--SELECT INSURANCE TYPE--"))
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                string DATE = "";
                string AGE = "";
                string PROJECT = "";
                string EXPIRED = "";
                string AMOUNT = "";
                string CURRENCY = "";
                string REf = "";
                string BANK = "";
                string CATEGORY = "";
                int intage = 0;
                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {
                    DateTime dateExDate = DateTime.MinValue;
                    string strCurrentDate = objBusiness.LoadCurrentDateInString();
                    DateTime dateCurrntdte = objCommon.textToDateTime(strCurrentDate);
                    if (intColumnBodyCount == 0)
                    {
                        REf = dt.Rows[intRowBodyCount]["INSURANCE_REF_NUM"].ToString();
                    }
                    else if (intColumnBodyCount == 1)
                    {
                        if (dt.Rows[intRowBodyCount]["INSURANCE_DATE"].ToString() != "" && dt.Rows[intRowBodyCount]["INSURANCE_DATE"].ToString() != null)
                        {
                            DATE = dt.Rows[intRowBodyCount]["INSURANCE_DATE"].ToString();
                        }
                    }

                    else if (intColumnBodyCount == 3)
                    {
                        CATEGORY = dt.Rows[intRowBodyCount]["INSURNCTYPE_NAME"].ToString();
                    }
                    else if (intColumnBodyCount == 6)
                    {
                        BANK = dt.Rows[intRowBodyCount]["INSURPRVDR_NAME"].ToString();
                    }

                    else if (intColumnBodyCount == 4)
                    {
                        if (dt.Rows[intRowBodyCount]["INSURNCTYPE_ID"].ToString() == "102")
                        {
                            EXPIRED = dt.Rows[intRowBodyCount]["INSURANCE_EXP_DATE"].ToString();

                            intage = Convert.ToInt32(dt.Rows[intRowBodyCount]["INSURANCE_NO_DAYS"]);
                        }
                        else
                        {
                            EXPIRED = dt.Rows[intRowBodyCount]["INSURANCE_EXP_DATE"].ToString();
                        }
                    }

                    else if (intColumnBodyCount == 5)
                    {
                        string stragee = "";
                        if (dt.Rows[intRowBodyCount]["INSURNCTYPE_ID"].ToString() == "102")
                        {

                            if (dateCurrntdte >= dateExDate)
                            {
                                AGE = dt.Rows[intRowBodyCount]["INSURANCE_NO_DAYS"].ToString();
                            }
                            else
                            {
                                AGE = stragee;
                            }
                        }
                        else
                        {
                            AGE = stragee;
                        }
                    }
                    else if (intColumnBodyCount == 7)
                    {
                        PROJECT = dt.Rows[intRowBodyCount]["PROJECT REF#"].ToString();
                    }

                    else if (intColumnBodyCount == 9)
                    {
                        string strNetAmount = dt.Rows[intRowBodyCount]["INSURANCE_AMOUNT"].ToString();
                        string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                        AMOUNT = strNetAmountWithComma;
                    }
                    else if (intColumnBodyCount == 10)
                    {
                        CURRENCY = dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString();
                    }
                }
                table.Rows.Add('"' + REf + '"', '"' + DATE + '"', '"' + CATEGORY + '"', '"' + EXPIRED + '"', '"' + AGE + '"', '"' + BANK + '"', '"' + PROJECT + '"', '"' + AMOUNT + '"', '"' + CURRENCY + '"');
            }
        }
        else
        {
            string DATE = "";
            string AGE = "";
            string PROJECT = "";
            string EXPIRED = "";
            string AMOUNT = "";
            string CURRENCY = "";
            string REf = "";
            string BANK = "";
            string CATEGORY = "";
            table.Rows.Add('"' + REf + '"', '"' + DATE + '"', '"' + CATEGORY + '"', '"' + EXPIRED + '"', '"' + AGE + '"', '"' + BANK + '"', '"' + PROJECT + '"', '"' + AMOUNT + '"', '"' + CURRENCY + '"');

        }
        return table;
    }
    protected void BtnCSV_Click(object sender, EventArgs e)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dt = GetTable();
        string strResult = DataTableToCSV(dt, ',');
        string strImagePath = "";
        string filepath = "";
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
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INSURANCE_TYPE_CSV);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.INSURANCE_TYPE_CSV);
            string newFilePath = Server.MapPath(strImagePath + "/Insurance_Type_csv_" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "Insurance_Type_csv_" + strNextId + ".csv";
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
        { }
    }
    public void CurrencyLoad()
    {
        clsBusinessLayerInsReports objBusinessLayerReports = new clsBusinessLayerInsReports();
        clsEntityReports objEntityReports = new clsEntityReports();

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
        if (dtDefaultcurc.Rows.Count > 0)
        {
            string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            if (ddlCurrency.Items.FindByValue(strdefltcurrcy) != null)
                ddlCurrency.Items.FindByValue(strdefltcurrcy).Selected = true;
        }

    }
}