using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CL_Compzit;
using EL_Compzit.EntityLayer_GMS;
using BL_Compzit;
using System.Web.Services;
using EL_Compzit;
using System.Text;
using BL_Compzit.BusinessLayer_GMS;
using System.IO;

public partial class GMS_Reports_Rep_Suppli_Guarantee_Rep_Suppli_Guarantee : System.Web.UI.Page
{
    clsBusinessLayerGmsReports ObjBussinessReports = new clsBusinessLayerGmsReports();
    clsEntityCommon objEntityCommon = new clsEntityCommon();
    clsEntityReports ObjEntitySuppliGuarante = new clsEntityReports();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReadDivision();
            ReadSupplier();
            ddlDivision.Focus();
            CurrencyLoad();
            int intUserId = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();
            clsEntityReports objEntityReports = new clsEntityReports();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                ObjEntitySuppliGuarante.User_Id = Convert.ToInt32(Session["USERID"].ToString());
                objEntityReports.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            divTitle.InnerHtml = "Supplier Wise Guarantee Report";
           


        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntitySuppliGuarante.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntitySuppliGuarante.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


            if (HiddenSearchField.Value == "")
            {
               
                ObjEntitySuppliGuarante.Division_Id = 0;
            }
            else
            {
                string strHidden = "";
                strHidden = HiddenSearchField.Value;
                string[] strSearchFields = strHidden.Split(',');

                string strDivision = strSearchFields[0];
                string strsupplr = strSearchFields[1];


                if (strDivision != null && strDivision != "")
                {
                    if (ddlDivision.Items.FindByValue(strDivision) != null)
                    {
                        if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
                        {
                            ddlDivision.ClearSelection();
                            ddlDivision.Items.FindByValue(strDivision).Selected = true;
                            ObjEntitySuppliGuarante.Division_Id = Convert.ToInt32(strDivision);

                        }
                    }
                }
                if (strsupplr != null && strsupplr != "")
                {
                    if (Ddlsupplier.Items.FindByValue(strDivision) != null)
                    {
                        if (Ddlsupplier.SelectedItem.Value != "--SELECT SUPPLIER--")
                        {
                            Ddlsupplier.ClearSelection();
                            Ddlsupplier.Items.FindByValue(strsupplr).Selected = true;
                            ObjEntitySuppliGuarante.Division_Id = Convert.ToInt32(strsupplr);
                        }
                    }
                }
            }
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                               clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                               };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDfltCurrency.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            }



            // for adding comma
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrency.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
            }



            ObjEntitySuppliGuarante.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);

            DataTable dtBankGuranteSupli = new DataTable();
            dtBankGuranteSupli = ObjBussinessReports.getDataSuppliGuarantee(ObjEntitySuppliGuarante);


            string strHtm = ConvertDataTableToHTML(dtBankGuranteSupli);
            //Write to divReport
            divReport.InnerHtml = strHtm;
            DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(objEntityReports);
            string strPrintReport = ConvertDataTableForPrint(dtBankGuranteSupli, dtCorp);
            divPrintReport.InnerHtml = strPrintReport;

        
    }
}
    public void CurrencyLoad()
    {
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

        DataTable dtSubConrt = ObjBussinessReports.ReadCurrency(ObjEntityBankGuarantee);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlCurrency.DataSource = dtSubConrt;
            ddlCurrency.DataTextField = "CRNCMST_NAME";
            ddlCurrency.DataValueField = "CRNCMST_ID";
            ddlCurrency.DataBind();

        }
        //   ddlCurrency.Items.Insert(0, "--SELECT CURRENCY--");
        DataTable dtDefaultcurc = ObjBussinessReports.ReadDefualtCurrency(ObjEntityBankGuarantee);
        string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        //ddlCurrency.Items.Insert(0, "--SELECT CURRENCY--");
        if (ddlCurrency.Items.FindByValue(strdefltcurrcy) != null)
            ddlCurrency.Items.FindByValue(strdefltcurrcy).Selected = true;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsEntityReports objEntityReports = new clsEntityReports();
        if (HiddenSearchField.Value == "")
        {

            ObjEntitySuppliGuarante.Division_Id = 0;
            ObjEntitySuppliGuarante.GuaranteeTempID = 0;
        }
        else
        {
            string strHidden = "";
            strHidden = HiddenSearchField.Value;
            // string strDivision = strHidden;
            string[] strSearchFields = strHidden.Split(',');
            string strDivision = strSearchFields[0];
            string strsupplr = strSearchFields[1];
            if (strDivision != null && strDivision != "")
            {
                if (ddlDivision.Items.FindByValue(strDivision) != null)
                {
                    if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
                    {
                        ddlDivision.ClearSelection();
                        ddlDivision.Items.FindByValue(strDivision).Selected = true;
                        ObjEntitySuppliGuarante.Division_Id = Convert.ToInt32(strDivision);
                    }
                }
            }

            if (strsupplr != null && strsupplr != "")
            {
                if (Ddlsupplier.Items.FindByValue(strsupplr) != null)
                {
                    if (Ddlsupplier.SelectedItem.Value != "--SELECT SUPPLIER--")
                    {
                        Ddlsupplier.ClearSelection();
                        Ddlsupplier.Items.FindByValue(strsupplr).Selected = true;
                        ObjEntitySuppliGuarante.GuaranteeTempID = Convert.ToInt32(strsupplr);
                    }
                }
            }
        }
        if (Session["USERID"] != null)
        {
           // intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntitySuppliGuarante.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            objEntityReports.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntitySuppliGuarante.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntitySuppliGuarante.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ObjEntitySuppliGuarante.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
        DataTable dtBankGurante = new DataTable();
        dtBankGurante = ObjBussinessReports.getDataSuppliGuarantee(ObjEntitySuppliGuarante);


        int intUserId = 0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }



        string strHtm = ConvertDataTableToHTML(dtBankGurante);
        //Write to divReport
        divReport.InnerHtml = strHtm;
        DataTable dtCorp = ObjBussinessReports.Read_Corp_Details(objEntityReports);
        string strPrintReport = ConvertDataTableForPrint(dtBankGurante,dtCorp);
        divPrintReport.InnerHtml = strPrintReport;
    }



    public void ReadSupplier()
    {

        clsEntityReports ObjEntitySuppliGuar = new clsEntityReports();
        clsBusinessLayerReports objBusinessLayerReports = new clsBusinessLayerReports();


        clsEntityReports objEntityReports = new clsEntityReports();

        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntitySuppliGuarante.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            objEntityReports.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntitySuppliGuarante.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntitySuppliGuarante.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntitySuppliGuarante.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] != null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSupplier = ObjBussinessReports.Read_Supplier(ObjEntitySuppliGuarante);
        if (dtSupplier.Rows.Count > 0)
        {
            Ddlsupplier.DataSource = dtSupplier;
            Ddlsupplier.DataTextField = "CSTMR_NAME";
            Ddlsupplier.DataValueField = "CSTMR_ID";
            Ddlsupplier.DataBind();

        }

        Ddlsupplier.Items.Insert(0, "--SELECT SUPPLIER--");
    }
    public void ReadDivision()
    {

        clsEntityReports ObjEntitySuppliGuar = new clsEntityReports();
        clsBusinessLayerReports objBusinessLayerReports = new clsBusinessLayerReports();

   
        clsEntityReports objEntityReports = new clsEntityReports();

        if (Session["USERID"] != null)
        {
           // intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntitySuppliGuarante.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            objEntityReports.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntitySuppliGuarante.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntitySuppliGuarante.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntitySuppliGuarante.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] != null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtdivision = ObjBussinessReports.Fetch_Division(ObjEntitySuppliGuarante);
        if (dtdivision.Rows.Count > 0)
        {
            ddlDivision.DataSource = dtdivision;
            ddlDivision.DataTextField = "CPRDIV_NAME";
            ddlDivision.DataValueField = "CPRDIV_ID";
            ddlDivision.DataBind();

        }

        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
    }


    public string ConvertDataTableToHTML(DataTable dt)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strRandom = objCommon.Random_Number();


        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrency.Value);
        //string strRandom = objCommon.Random_Number();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">SL.NO</th>";
 

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">"+ dt.Columns[intColumnHeaderCount].ColumnName+"</th>";
            }

            else if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: CENTER; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:13%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
           
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:13%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
    
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: CENTER; word-wrap:break-word;\">EXPIRY DATE</th>";
            }
               
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: LEFT; word-wrap:break-word;\">" +dt.Columns["BANK"].ColumnName+"</th>";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\"  style=\"width:14%;text-align: LEFT; word-wrap:break-word;\">" + dt.Columns["GUARANTEE CATEGORY"].ColumnName  + "</th>";
            }   
            else if (intColumnHeaderCount == 10)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: LEFT; word-wrap:break-word;\">" + dt.Columns["JOB CODE"].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 11)
            {
                strHtml += "<th class=\"thT\"  style=\"width:9%;text-align: right; word-wrap:break-word;\">" + dt.Columns["AMOUNT"].ColumnName + "</th>";
            }
            //EVM-0024
            else if (intColumnHeaderCount == 12)
            {
                strHtml += "<th class=\"thT\"  style=\"width:7%;text-align: left; word-wrap:break-word;\">CURRENCY</th>";
            }
            //END
        }


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        lblToalRowCount.Text ="0";
        if ((ddlDivision.SelectedItem.Text != "--SELECT DIVISION--") || (Ddlsupplier.SelectedItem.Text != "--SELECT SUPPLIER--"))
        {
            lblToalRowCount.Text = dt.Rows.Count.ToString();
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {

                int num1 = intRowBodyCount + 1;
                strHtml += "<tr  >";
                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + num1 + "</td>";
                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    DateTime dateExDate = DateTime.MinValue;
                    string strCurrentDate = objBusiness.LoadCurrentDateInString();
                    DateTime dateCurrntdte = objCommon.textToDateTime(strCurrentDate);
                    if (intColumnBodyCount == 0)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["GUARANTEE REF#"].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 1)
                    {
                        string hiddenDate = "";
                        if (dt.Rows[intRowBodyCount]["GUARANTEE DATE"].ToString() != "" && dt.Rows[intRowBodyCount]["GUARANTEE DATE"].ToString() != null)
                        {
                            string[] arr = new string[3];
                            arr = dt.Rows[intRowBodyCount]["GUARANTEE DATE"].ToString().Split('-');
                            hiddenDate = arr[2] + arr[1] + arr[0];
                        }

                        strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" ><span style=\"display:none;\">" + hiddenDate + "</span>" + dt.Rows[intRowBodyCount]["GUARANTEE DATE"].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 2)
                    {
                        if (dt.Rows[intRowBodyCount]["CSTMR_REFNUM"].ToString() == "")
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["SUPPLIER NAME"].ToString() + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["SUPPLIER NAME"].ToString() + " (" + dt.Rows[intRowBodyCount]["CSTMR_REFNUM"].ToString() + ")" + "</td>";
                        }
                    }

                    else if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\"  title=\" " + dt.Rows[intRowBodyCount]["PROJECT_NAME"].ToString() + " \" style=\" width:13%;cursor: pointer;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PROJECT REF#"].ToString() + "</td>";
                    }

                        //END
                    else if (intColumnBodyCount == 4)
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
                    else if (intColumnBodyCount == 5)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: LEFT;\" >" + dt.Rows[intRowBodyCount]["BANK"].ToString() + "</td>";

                    }
                    else if (intColumnBodyCount == 6)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: LEFT;\" >" + dt.Rows[intRowBodyCount]["GUARANTEE CATEGORY"].ToString() + "</td>";

                    }
                    else if (intColumnBodyCount == 10)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: LEFT;\" >" + dt.Rows[intRowBodyCount]["JOB CODE"].ToString() + "</td>";


                    }
                    else if (intColumnBodyCount == 11)
                    {


                        string strAmount = dt.Rows[intRowBodyCount]["AMOUNT"].ToString();
                        string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strAmount, objEntityCommon);
                        // strHtml += "<td class=\"tdT\" style=\" width:22%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + strNetAmountWithComma.ToString() + "</td>";

                        strHtml += "<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strNetAmountWithComma.ToString() + "</td>";

                    }
                    //EVM-0024
                    else if (intColumnBodyCount == 12)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                        HiddenCurrency.Value = dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString();
                    }
                }

                strHtml += "</tr>";
            }
        }
        //else
        //{
        //    strHtml += "<tr class=\"odd\" style=\"\">";
        //    strHtml += "<tfoot>";
        //    strHtml += "<td  class=\"dataTables_empty\" colspan=\"11\"; style=\" border-right: navajowhite;font-size: SMALL;width:6%;word-break: break-all; word-wrap:break-word;text-align: CENTER;height: 30px;background: #E9E9E9;font-size: 14px;color: #5c5c5e;\" >No Data Available</td>";
        //    strHtml += "</tfoot>";
        //    strHtml += "</tr>";
        //}
        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
    }


    public string ConvertDataTableForPrint(DataTable dt, DataTable dtCorp)
    {

        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Supplier Wise Guarantee Report";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string usrName = "<B>Report Generated By: </B>" + Session["USERFULLNAME"];
       // string TotalRowCnt = "<B>Supplier Wise Total Guarantee: </B>" + dt.Rows.Count;
        //for printing product division on print
        string strHidden = "", GuaranteDivsn = "", Supplier="";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrency.Value);

        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";

        if (HiddenSearchField.Value.ToString() != "")
        {

            strHidden = HiddenSearchField.Value;
            string[] strSearchFields = strHidden.Split(',');
            //  string[] strSearchFields = strHidden.Split(',');
            string strDivision = strSearchFields[0];
            string strsupplr = strSearchFields[1];

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
            if (strsupplr != null && strsupplr != "")
            {
                if (Ddlsupplier.Items.FindByValue(strsupplr) != null)
                {
                    if (Ddlsupplier.SelectedItem.Value != "--SELECT SUPPLIER--")
                    {
                        Ddlsupplier.ClearSelection();
                        Ddlsupplier.Items.FindByValue(strsupplr).Selected = true;
                        Supplier = "<B>Supplier  : </B>" + Ddlsupplier.SelectedItem.Text;
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



        string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr + "</td></tr>";

        string strCaptionTabRprtDate = "", strCaptionTabTitle = "", strGuaranteDivsn = "", strSupplier = "",strUsrName="";
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
        if (Supplier != "")
        {
            strSupplier = "<tr><td class=\"RprtDiv\">" + Supplier + "</td></tr>";

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
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strGuaranteDivsn + strSupplier + strUsrName  + strCaptionTabTitle + strCaptionTabstop;

        sbCap.Append(strPrintCaptionTable);
        ////write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";
        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">SL.NO</th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: CENTER; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:13%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
           
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
        
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: CENTER; word-wrap:break-word;\">" + dt.Columns["EXPIRY DATE"].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: LEFT; word-wrap:break-word;\">" + dt.Columns["BANK"].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: LEFT; word-wrap:break-word;\">" + dt.Columns["GUARANTEE CATEGORY"].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 10)
            {
                strHtml += "<th class=\"thT\"  style=\"width:14%;text-align: LEFT; word-wrap:break-word;\">" + dt.Columns["JOB CODE"].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 11)
            {
                strHtml += "<th class=\"thT\"  style=\"width:9%;text-align: right; word-wrap:break-word;\">AMOUNT</th>";
            }
            //EVM-0024
            else if (intColumnHeaderCount == 12)
            {
                strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: left; word-wrap:break-word;\">CURRENCY</th>";
            }
            //END
        }

        strHtml += "</tr>";
        strHtml += "</thead>";

        //add rows
        decimal totalAmount = 0;
        string cuurency = "";
        strHtml += "<tbody>";
        if (dt.Rows.Count == 0)
        {
            strHtml += "<tr id=\"TableRprtRow\" >";
            strHtml += "<td class=\"thT\"colspan=10 style=\"width:11%;text-align: center; word-wrap:break-word;\">NO DATA AVAILABLE</th>";

        }
        else
        {
            var result = from tab in dt.AsEnumerable()
                         group tab by tab["CRNCMST_ABBRV"]
                             into groupDt
                             select new
                             {
                                 Group = groupDt.Key,
                                 Sum = groupDt.Sum((r) => decimal.Parse(r["AMOUNT"].ToString()))
                             };
            if ((ddlDivision.SelectedItem.Text != "--SELECT DIVISION--") || (Ddlsupplier.SelectedItem.Text != "--SELECT SUPPLIER--"))
            {
                for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
                {
                    int n = intRowBodyCount + 1;
                    strHtml += "<tr id=\"TableRprtRow\" >";
                    strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + n + "</td>";
                    int intage = 0;
                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {

                        DateTime dateExDate = DateTime.MinValue;
                        string strCurrentDate = objBusiness.LoadCurrentDateInString();
                        DateTime dateCurrntdte = objCommon.textToDateTime(strCurrentDate);
                        if (intColumnBodyCount == 0)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["GUARANTEE REF#"].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["GUARANTEE DATE"].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 2)
                        {

                            if (dt.Rows[intRowBodyCount]["CSTMR_REFNUM"].ToString() == "")
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["SUPPLIER NAME"].ToString() + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["SUPPLIER NAME"].ToString() + " (" + dt.Rows[intRowBodyCount]["CSTMR_REFNUM"].ToString() + ")" + "</td>";
                            }
                        }

                        else if (intColumnBodyCount == 3)
                        {
                            strHtml += "<td class=\"tdT\"  title=\" " + dt.Rows[intRowBodyCount]["PROJECT_NAME"].ToString() + " \" style=\" width:9%;cursor: pointer;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PROJECT REF#"].ToString() + "</td>";
                        }

                        else if (intColumnBodyCount == 4)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["EXPIRY DATE"].ToString() + "</td>";

                        }
                        else if (intColumnBodyCount == 5)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["BANK"].ToString() + "</td>";

                        }
                        else if (intColumnBodyCount == 6)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["GUARANTEE CATEGORY"].ToString() + "</td>";

                        }
                        else if (intColumnBodyCount == 10)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: LEFT;\" >" + dt.Rows[intRowBodyCount]["JOB CODE"].ToString() + "</td>";


                        }
                        else if (intColumnBodyCount == 11)
                        {

                            string strAmount = dt.Rows[intRowBodyCount]["AMOUNT"].ToString();
                            string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strAmount, objEntityCommon);
                            strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strNetAmountWithComma.ToString() + "</td>";
                            if (totalAmount == 0)
                            {
                                totalAmount = Convert.ToDecimal(strAmount);
                            }
                            else
                            {
                                totalAmount = totalAmount + Convert.ToDecimal(strAmount);
                            }
                        }
                        //EVM-0024
                        else if (intColumnBodyCount == 12)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                            cuurency = dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString();
                            HiddenCurrency.Value = cuurency;
                        }
                        //END

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
                strHtml += "<td  class=\"tdT\" colspan=\"11\"; style=\" border-right: navajowhite;font-size: SMALL;width:6%;word-break: break-all; word-wrap:break-word;text-align: CENTER;\" >No Data Available</td>";
                //string stamt = sum2.ToString();
                //string strNetAmo = objBusiness.AddCommasForNumberSeperation(stamt, ObjEntityCommon);


                strHtml += "</tfoot>";
            }
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
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        DataTable table = new DataTable();
        table.Columns.Add("SL.NO", typeof(string));
        table.Columns.Add("GUARANTEE REF#", typeof(string));
        table.Columns.Add("GUARANTEE DATE", typeof(string));
        table.Columns.Add("SUPPLIER NAME", typeof(string));
        table.Columns.Add("PROJECT REF#", typeof(string));
        table.Columns.Add("EXPIRY DATE", typeof(string));
        table.Columns.Add("BANK", typeof(string));
        table.Columns.Add("GUARANTEE CATEGORY", typeof(string));
        table.Columns.Add("JOB CODE", typeof(string));
        table.Columns.Add("AMOUNT", typeof(string));
        table.Columns.Add("CURRENCY", typeof(string));
        clsEntityReports objEntityReports = new clsEntityReports();
        if (HiddenSearchField.Value == "")
        {

            ObjEntitySuppliGuarante.Division_Id = 0;
            ObjEntitySuppliGuarante.GuaranteeTempID = 0;
        }
        else
        {
            string strHidden = "";
            strHidden = HiddenSearchField.Value;
            // string strDivision = strHidden;
            string[] strSearchFields = strHidden.Split(',');
            string strDivision = strSearchFields[0];
            string strsupplr = strSearchFields[1];
            if (strDivision != null && strDivision != "")
            {
                if (ddlDivision.Items.FindByValue(strDivision) != null)
                {
                    if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
                    {
                        ddlDivision.ClearSelection();
                        ddlDivision.Items.FindByValue(strDivision).Selected = true;
                        ObjEntitySuppliGuarante.Division_Id = Convert.ToInt32(strDivision);
                    }
                }
            }

            if (strsupplr != null && strsupplr != "")
            {
                if (Ddlsupplier.Items.FindByValue(strsupplr) != null)
                {
                    if (Ddlsupplier.SelectedItem.Value != "--SELECT SUPPLIER--")
                    {
                        Ddlsupplier.ClearSelection();
                        Ddlsupplier.Items.FindByValue(strsupplr).Selected = true;
                        ObjEntitySuppliGuarante.GuaranteeTempID = Convert.ToInt32(strsupplr);
                    }
                }
            }
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntitySuppliGuarante.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            objEntityReports.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntitySuppliGuarante.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntitySuppliGuarante.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ObjEntitySuppliGuarante.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
        DataTable dt = new DataTable();
        dt = ObjBussinessReports.getDataSuppliGuarantee(ObjEntitySuppliGuarante);
        string strRandom = objCommon.Random_Number();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrency.Value);
        if ((ddlDivision.SelectedItem.Text != "--SELECT DIVISION--") || (Ddlsupplier.SelectedItem.Text != "--SELECT SUPPLIER--"))
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                string slNo = "";
                string DATE = "";
                string CUSTOMER = "";
                string CATEGORY = "";
                string PROJECT = "";
                string EXPIRED = "";
                string JOB = "";
                string AMOUNT = "";
                string CURRENCY = "";
                string REf = "";
                string BANK = "";
                int num1 = intRowBodyCount + 1;
                slNo = Convert.ToString(num1);
                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {
                    DateTime dateExDate = DateTime.MinValue;
                    string strCurrentDate = objBusiness.LoadCurrentDateInString();
                    DateTime dateCurrntdte = objCommon.textToDateTime(strCurrentDate);
                    if (intColumnBodyCount == 0)
                    {
                        REf = dt.Rows[intRowBodyCount]["GUARANTEE REF#"].ToString();
                    }
                    else if (intColumnBodyCount == 1)
                    {
                        if (dt.Rows[intRowBodyCount]["GUARANTEE DATE"].ToString() != "" && dt.Rows[intRowBodyCount]["GUARANTEE DATE"].ToString() != null)
                        {
                            DATE = dt.Rows[intRowBodyCount]["GUARANTEE DATE"].ToString();
                        }
                    }
                    else if (intColumnBodyCount == 2)
                    {
                        if (dt.Rows[intRowBodyCount]["CSTMR_REFNUM"].ToString() == "")
                        {
                            CUSTOMER = dt.Rows[intRowBodyCount]["SUPPLIER NAME"].ToString();
                        }
                        else
                        {
                            CUSTOMER = dt.Rows[intRowBodyCount]["SUPPLIER NAME"].ToString() + " (" + dt.Rows[intRowBodyCount]["CSTMR_REFNUM"].ToString() + ")";
                        }
                    }
                    else if (intColumnBodyCount == 3)
                    {
                        PROJECT = dt.Rows[intRowBodyCount]["PROJECT REF#"].ToString();
                    }
                    else if (intColumnBodyCount == 4)
                    {
                        if (dt.Rows[intRowBodyCount]["EXPIRY DATE"].ToString() != "" && dt.Rows[intRowBodyCount]["EXPIRY DATE"].ToString() != null)
                        {
                            EXPIRED = dt.Rows[intRowBodyCount]["EXPIRY DATE"].ToString();
                        }
                    }
                    else if (intColumnBodyCount == 5)
                    {
                        BANK = dt.Rows[intRowBodyCount]["BANK"].ToString();

                    }
                    else if (intColumnBodyCount == 6)
                    {
                        CATEGORY = dt.Rows[intRowBodyCount]["GUARANTEE CATEGORY"].ToString();
                    }
                    else if (intColumnBodyCount == 10)
                    {
                        JOB = dt.Rows[intRowBodyCount]["JOB CODE"].ToString();
                    }
                    else if (intColumnBodyCount == 11)
                    {
                        string strAmount = dt.Rows[intRowBodyCount]["AMOUNT"].ToString();
                        string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strAmount, objEntityCommon);
                        AMOUNT = dt.Rows[intRowBodyCount]["AMOUNT"].ToString();
                    }
                    else if (intColumnBodyCount == 12)
                    {
                        CURRENCY = dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString();
                    }
                }
                //     string[] items = new string[] { slNo, REf, DATE, CUSTOMER,""+ PROJECT+"", EXPIRED, BANK, CATEGORY, JOB, AMOUNT, CURRENCY };
                table.Rows.Add('"' + slNo + '"', '"' + REf + '"', '"' + DATE + '"', '"' + CUSTOMER + '"', '"' + PROJECT + '"', '"' + EXPIRED + '"', '"' + BANK + '"', '"' + CATEGORY + '"', '"' + JOB + '"', '"' + AMOUNT + '"', '"' + CURRENCY + '"');
                //     string toEncrypt = String.Join("|", items);

                //   items = toEncrypt.Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries);

            }
        }
        else
        {
            string slNo = "";
            string DATE = "";
            string CUSTOMER = "";
            string CATEGORY = "";
            string PROJECT = "";
            string EXPIRED = "";
            string JOB = "";
            string AMOUNT = "";
            string CURRENCY = "";
            string REf = "";
            string BANK = "";
            table.Rows.Add('"' + slNo + '"', '"' + REf + '"', '"' + DATE + '"', '"' + CUSTOMER + '"', '"' + PROJECT + '"', '"' + EXPIRED + '"', '"' + BANK + '"', '"' + CATEGORY + '"', '"' + JOB + '"', '"' + AMOUNT + '"', '"' + CURRENCY + '"');

        }
        return table;

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
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SUPPLIEDCSV);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
            string newFilePath = Server.MapPath("/CustomFiles/GMS CSV/Supply Guarantee/Supplier_Wise_Guarantee_Report_" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "Supplier_Wise_Guarantee_Report_" + strNextId + ".csv";
            Response.ContentType = "csv";
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.SUPPLY_CSV);
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