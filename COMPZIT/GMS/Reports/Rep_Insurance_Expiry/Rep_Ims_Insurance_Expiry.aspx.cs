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
using System.Collections.Generic;
using System.Linq;

public partial class GMS_Reports_Rep_Ims_Insurance_Expiry_Rep_Ims_Insurance_Expiry : System.Web.UI.Page
{

    clsBusinessLayerReports ObjBussinessReports = new clsBusinessLayerReports();
    private enum Button_type
    {
        Previous = 1,
        Next = 2
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            divTitle.InnerHtml = "Expired Insurance Report ";
            clsEntityReports ObjEntityReports = new clsEntityReports();
            btnNext.Enabled = false;
            btnPrevious.Enabled = false;
            ReadDivision();
            CurrencyLoad();
           
            ReadInsuranceProvider();
            ddlDivision.Focus();
           
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            //Creating objects for business layer
            clsBusinessLayerInsReports objBusinessLayerInsReports = new clsBusinessLayerInsReports();
            clsEntityReports objEntityReports = new clsEntityReports();
            if (Session["USERID"] != null)
            {
                
                ObjEntityReports.User_Id = Convert.ToInt32(Session["USERID"]);
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
        

                clsCommonLibrary.CORP_GLOBAL[] arrEnumerr = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                                   clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE,
                                                               clsCommonLibrary.CORP_GLOBAL.CMDTY_MANTN_OFFCE,
                                                               clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                                //EVM-0027
                                                                clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT
                                                                 //END
                                                              };

            
                DataTable dtCorpDetail = new DataTable();
                dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumerr, intCorpId);
                if (dtCorpDetail.Rows.Count > 0)
                {
                    //hiddenCommodityValue.Value = dtCorpDetail.Rows[0]["CMDTY_MANTN_OFFCE"].ToString();
                    string strListingMode = dtCorpDetail.Rows[0]["LISTING_MODE"].ToString();
                    string strLstingModeSize = dtCorpDetail.Rows[0]["LISTING_MODE_SIZE"].ToString();
                    hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                    //EVM-0027
                  
                     hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                    //END
                   
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



                ObjEntityReports.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);

            //END

                if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
                {
                    string strHidden = Request.QueryString["Srch"].ToString();
                    HiddenSearchField.Value = strHidden;

                    string[] strSearchFields = strHidden.Split(',');
                    string strDivision = strSearchFields[0];
                    //string strCatgry = strSearchFields[1];

                    string strBank = strSearchFields[1];
                    // string strCntrctrType = strSearchFields[3];



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

             
                    if (strBank != null && strBank != "")
                    {
                        if (ddlBank.Items.FindByValue(strBank) != null)
                        {
                            if (ddlBank.SelectedItem.Value != "--SELECT PROVIDER--")
                            {
                                ddlBank.ClearSelection();
                                ddlBank.Items.FindByValue(strBank).Selected = true;
                                ObjEntityReports.BankId = Convert.ToInt32(strBank);
                            }
                        }
                    }
                }
                        
                if (HiddenSearchField.Value == "")
                {
                   
                    ObjEntityReports.InsuranceProvider = 0;
                    ObjEntityReports.Division_Id = 0;
                }
                else
                {
                    string strHidden = "";
                    strHidden = HiddenSearchField.Value;



                    string[] strSearchFields = strHidden.Split(',');
                    string strDivision = strSearchFields[0];
                    string strBank = strSearchFields[1];

               
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

                 
                    if (strBank != null && strBank != "")
                    {
                        if (ddlBank.Items.FindByValue(strBank) != null)
                        {
                            if (ddlBank.SelectedItem.Value != "--SELECT PROVIDER--")
                            {
                                ddlBank.ClearSelection();
                                ddlBank.Items.FindByValue(strBank).Selected = true;
                                ObjEntityReports.BankId = Convert.ToInt32(strBank);
                            }
                        }
                    }

                }
                
             
                DataTable dtInsurance = new DataTable();
                dtInsurance = objBusinessLayerInsReports.Read_Insurance_Expiry_Details(ObjEntityReports);
                string strHtm = ConvertDataTableToHTML(dtInsurance);
                //Write to divReport
                divReport.InnerHtml = strHtm;

                DataTable dtCorp = ObjBussinessReports.Read_Corp_Details(objEntityReports);
                string strPrintReport = ConvertDataTableForPrint(dtInsurance, dtCorp);

                divPrintReport.InnerHtml = strPrintReport;
            }
    }
    public void CurrencyLoad()
    {
        clsEntityReports objEntityReport = new clsEntityReports();
        clsBusinessLayerInsReports objInsReports = new clsBusinessLayerInsReports();
       

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReport.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityReport.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityReport.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtSubConrt = objInsReports.ReadCurrency(objEntityReport);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlCurrency.DataSource = dtSubConrt;
            ddlCurrency.DataTextField = "CRNCMST_NAME";
            ddlCurrency.DataValueField = "CRNCMST_ID";
            ddlCurrency.DataBind();

        }

       
        DataTable dtDefaultcurc = objInsReports.ReadDefualtCurrency(objEntityReport);
        string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
   
        if (ddlCurrency.Items.FindByValue(strdefltcurrcy) != null)
            ddlCurrency.Items.FindByValue(strdefltcurrcy).Selected = true;


    }
    //for binding dropdown
    public void ReadInsuranceProvider()
    {
        clsEntityReports objEntityReport = new clsEntityReports();
        clsBusinessLayerInsReports objInsReports = new clsBusinessLayerInsReports();
        //clsEntityReports ObjEntityBankGuarantee = new clsEntityReports();
        if (Session["USERID"] != null)
        {
          
            objEntityReport.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReport.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityReport.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtdivision = objInsReports.ReadInsuranceProvider(objEntityReport);
        if (dtdivision.Rows.Count > 0)
        {
            ddlBank.DataSource = dtdivision;
            ddlBank.DataTextField = "INSURPRVDR_NAME";
            ddlBank.DataValueField = "INSURPRVDR_ID";
            ddlBank.DataBind();

        }

        ddlBank.Items.Insert(0, "--SELECT PROVIDER--");
    }
    //for binding dropdown
    public void ReadDivision()
    {
        clsEntityReports objEntityReport = new clsEntityReports();
        clsBusinessLayerInsReports objInsReports = new clsBusinessLayerInsReports();
       
        if (Session["USERID"] != null)
        {
            //intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityReport.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReport.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityReport.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtdivision = objInsReports.Read_Division(objEntityReport);
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
        int first = Convert.ToInt32(hiddenPrevious.Value);
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
       
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
                strHtml += "<th class=\"thT\" style=\"width:17%;text-align: left; word-wrap:break-word;\">INSURANCE REF#</th>";
            }

            else if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: CENTER; word-wrap:break-word;\">DATE</th>";
            }
         
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">INSURANCE CATEGORY</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:13%;text-align: left; word-wrap:break-word;\">PROJECT REF#</th>";
            }


            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:7%;text-align: CENTER; word-wrap:break-word;\">EXPIRED DATE</th>";
            }

            else if (intColumnHeaderCount == 5)
            {
               
                strHtml += "<th class=\"thT\"  style=\"width:4%;text-align: right; word-wrap:break-word;\">AGE (Days)</th>";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: right; word-wrap:break-word;\">AMOUNT</th>";
            }

            else if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: CENTER; word-wrap:break-word;\">CURRENCY</th>";
            }
        }





        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";

        int count = 0;
        lblToalRowCount.Text = "0";
        if ((ddlDivision.SelectedItem.Text != "--SELECT DIVISION--") ||  (ddlBank.SelectedItem.Text != "--SELECT PROVIDER--"))
        {
            lblToalRowCount.Text = dt.Rows.Count.ToString();
            for (int intRowBodyCount = first; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {

                
                int intMemoryBytes = System.Text.ASCIIEncoding.Unicode.GetByteCount(strHtml);
                if (hiddenTotalRowCount.Value == "")
                {
                    if (hiddenMemorySize.Value == "")
                    {

                        count++;
                        strHtml += "<tr  >";
                        strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count + "</td>";
                      
                        for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                        {

                            if (intColumnBodyCount == 0)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["INSURANCE_REF_NUM"].ToString() + "</td>";
                            }
                            else if (intColumnBodyCount == 1)
                            {
                             

                                strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["INSURANCE_DATE"] + "</td>";
                            }
                       
                            else if (intColumnBodyCount == 2)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["INSURNCTYPE_NAME"].ToString() + "</td>";
                            }
                            else if (intColumnBodyCount == 3)
                            {
                                strHtml += "<td class=\"tdT\"  title=\" " + dt.Rows[intRowBodyCount]["PROJECT_NAME"].ToString() + " \" style=\" width:13%;cursor: pointer;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PROJECT REF#"].ToString() + "</td>";
                            }


                            else if (intColumnBodyCount == 4)
                            {
                               

                                strHtml += "<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["INSURANCE_EXP_DATE"] + "</td>";
                                
                            }

                            else if (intColumnBodyCount == 5)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + dt.Rows[intRowBodyCount]["INSURANCE_NO_DAYS"].ToString() + "</td>";
                            }
                         
                            else if (intColumnBodyCount == 6)
                            {
                                string strNetAmount = dt.Rows[intRowBodyCount]["INSURANCE_AMOUNT"].ToString();
                                string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strNetAmountWithComma.ToString() + " </td>";
                            }

                            else if (intColumnBodyCount == 7)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: CENTER;\" >" + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";

                            }
                        }


                      
                    }
                }
                else
                {
                    if (hiddenNext.Value == "")
                    {
                        hiddenNext.Value = hiddenTotalRowCount.Value;
                    }
                    int last = Convert.ToInt32(hiddenNext.Value);
                    if (intRowBodyCount < last)
                    {
                        count++;
                        strHtml += "<tr  >";
                        strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count + "</td>";

                      
                        for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                        {                                                
                            if (intColumnBodyCount == 0)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["INSURANCE_REF_NUM"].ToString() + "</td>";
                            }
                            else if (intColumnBodyCount == 1)
                            {
                        
                                strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["INSURANCE_DATE"] + "</td>";
                            }
                    
                            else if (intColumnBodyCount == 2)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["INSURNCTYPE_NAME"].ToString() + "</td>";
                            }
                            else if (intColumnBodyCount == 3)
                            {
                                strHtml += "<td class=\"tdT\"  title=\" " + dt.Rows[intRowBodyCount]["PROJECT_NAME"].ToString() + " \" style=\" width:13%;cursor: pointer;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PROJECT REF#"].ToString() + "</td>";
                            }

                                
                            else if (intColumnBodyCount == 4)
                            {
                             strHtml += "<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["INSURANCE_EXP_DATE"] + "</td>";
                            
                            }

                            else if (intColumnBodyCount == 5)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + dt.Rows[intRowBodyCount]["INSURANCE_NO_DAYS"].ToString() + "</td>";
                            }
                         
                            else if (intColumnBodyCount == 6)
                            {
                                string strNetAmount = dt.Rows[intRowBodyCount]["INSURANCE_AMOUNT"].ToString();
                                string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strNetAmountWithComma.ToString() + " </td>";
                            }

                            else if (intColumnBodyCount == 7)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: CENTER;\" >" + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                                HiddenCurrency.Value = dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString();

                            }
                        }
                    }
                    else
                    {
                        btnNext.Enabled = true;
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



    // at search button click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
 
        clsBusinessLayerInsReports objBusinessLayerInsReports = new clsBusinessLayerInsReports();
        clsEntityReports objEntityReports = new clsEntityReports();          
     
        if (HiddenSearchField.Value == "")
        {
           
            objEntityReports.Division_Id = 0;
            objEntityReports.InsuranceProvider = 0;
        }
        else
        {
            string strHidden = "";
            strHidden = HiddenSearchField.Value;



            string[] strSearchFields = strHidden.Split(',');
            string strDivision = strSearchFields[0];
            string strBank = strSearchFields[1];

            if (strDivision != null && strDivision != "")
            {
                if (ddlDivision.Items.FindByValue(strDivision) != null)
                {
                    if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
                    {
                        ddlDivision.ClearSelection();
                        ddlDivision.Items.FindByValue(strDivision).Selected = true;
                        objEntityReports.Division_Id = Convert.ToInt32(strDivision);
                    }
                }
            }

         
            if (strBank != null && strBank != "")
            {
                if (ddlBank.Items.FindByValue(strBank) != null)
                {
                    if (ddlBank.SelectedItem.Value != "--SELECT PROVIDER--")
                    {
                        ddlBank.ClearSelection();
                        ddlBank.Items.FindByValue(strBank).Selected = true;
                        objEntityReports.InsuranceProvider = Convert.ToInt32(strBank);
                    }
                }
            }
           


        }
        objEntityReports.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);

        if (Session["USERID"] != null)
        {
           objEntityReports.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            
            objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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

        DataTable dtInsurance = new DataTable();
        dtInsurance = objBusinessLayerInsReports.Read_Insurance_Expiry_Details(objEntityReports);

      
        string strHtm = ConvertDataTableToHTML(dtInsurance);
        //Write to divReport
        divReport.InnerHtml = strHtm;

        DataTable dtCorp = objBusinessLayerInsReports.Read_Corp_Details(objEntityReports);
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
        strTitle = "Expired Insurance Report";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string usrName = "<B> Report Generated By: </B>" + Session["USERFULLNAME"];
       
        string strHidden = "", GuaranteDivsn = "", GuaranteCatgry = "", GuaranteBank = ""; ;
        clsCommonLibrary objCommon = new clsCommonLibrary();
       


        if (HiddenSearchField.Value.ToString() != "")
        {
            
            strHidden = HiddenSearchField.Value;



            string[] strSearchFields = strHidden.Split(',');
            string strDivision = strSearchFields[0];
            string strBank = strSearchFields[1];
          
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

        
            if (strBank != null && strBank != "")
            {
                if (ddlBank.Items.FindByValue(strBank) != null)
                {
                    if (ddlBank.SelectedItem.Value != "--SELECT PROVIDER--")
                    {
                        ddlBank.ClearSelection();
                        ddlBank.Items.FindByValue(strBank).Selected = true;
                        GuaranteBank = "<B>Insurance Provider : </B>" + ddlBank.SelectedItem.Text;
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
        ////write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\"   >";
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

            else if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:6%;text-align: CENTER; word-wrap:break-word;\">DATE</th>";
            }
          
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">INSURANCE TYPE</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">PROJECT REF#</th>";
            }

               
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: CENTER; word-wrap:break-word;\">EXPIRED DATE</th>";
            }
         
            else if (intColumnHeaderCount == 5)
            {
            
                strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: CENTER; word-wrap:break-word;\">AGE (Days)</th>";
            }
          
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: right; word-wrap:break-word;\">AMOUNT</th>";

            }
            else if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: CENTER; word-wrap:break-word;\">CURRENCY</th>";

            }

        }

        strHtml += "</tr>";
        strHtml += "</thead>";

        //add rows

        strHtml += "<tbody>";
        if ((ddlDivision.SelectedItem.Text != "--SELECT DIVISION--") || (ddlBank.SelectedItem.Text != "--SELECT PROVIDER--"))
        {
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
                string CurrencyName = "";
                decimal totalAmount = 0;
                int count = 0;
                for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
                {
                    count++;
                    strHtml += "<tr id=\"TableRprtRow\" >";
                    strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count + "</td>";
                   
                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {

                   
                        if (intColumnBodyCount == 0)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["INSURANCE_REF_NUM"].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 1)
                        {
                          

                             strHtml += "<td class=\"tdT\" style=\" width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["INSURANCE_DATE"] + "</td>";
                        }
                     
                        else if (intColumnBodyCount == 2)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["INSURNCTYPE_NAME"].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 3)
                        {
                            strHtml += "<td class=\"tdT\"  title=\" " + dt.Rows[intRowBodyCount]["PROJECT_NAME"].ToString() + " \" style=\" width:10%;cursor: pointer;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PROJECT REF#"].ToString() + "</td>";
                        }

                            
                        else if (intColumnBodyCount == 4)
                        {
     
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["INSURANCE_EXP_DATE"] + "</td>";
                          
                        }
                        
                
                        else if (intColumnBodyCount == 5)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["INSURANCE_NO_DAYS"].ToString() + "</td>";

                        }
                        else if (intColumnBodyCount == 6)
                        {
                            string strNetAmount = dt.Rows[intRowBodyCount]["INSURANCE_AMOUNT"].ToString();
                            string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strNetAmountWithComma.ToString() + "</td>";
                            if (totalAmount == 0)
                            {
                                totalAmount = Convert.ToDecimal(strNetAmount);
                            }
                            else
                            {
                                totalAmount = totalAmount + Convert.ToDecimal(strNetAmount);
                            }
                        }
                        else if (intColumnBodyCount == 7)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                            CurrencyName = dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString();
                        }
                    }
                    strHtml += "</tr>";
                }
                foreach (var row in result)
                {
                    strHtml += "<tr id=\"TableRprtRow\" >";
                    strHtml += "<tfoot>";
                    strHtml += "<td  class=\"tdT\" colspan=\"7\"; style=\"border-right-color: white;font-size: SMALL;width:6%;word-break: break-all; word-wrap:break-word;text-align: right;\" >Total</td>";
                    string strtotalAmount = "";
                    strtotalAmount = Convert.ToString(row.Sum);
                   
                    string strTotal = objBusiness.AddCommasForNumberSeperation(strtotalAmount, objEntityCommon);
                    strHtml += "<td  class=\"tdT\"  style=\" border-right: navajowhite;font-size: SMALL;width:8%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strTotal + "</td>";
                    strHtml += "<td  class=\"tdT\"  style=\" border-right: navajowhite;font-size: SMALL;width:6%;word-break: break-all; word-wrap:break-word;text-align: left;border-left-color: white;\" >" + row.Group + "</td>";
                    strHtml += "</tfoot>";
                  // HiddenFieldAmount.Value = strTotal;
                }
                
            }

            else
            {
                strHtml += "<tr id=\"TableRprtRow\" >";
                strHtml += "<tfoot>";
                strHtml += "<td  class=\"tdT\" colspan=\"11\"; style=\" border-right: navajowhite;font-size: SMALL;width:6%;word-break: break-all; word-wrap:break-word;text-align: CENTER;\" >No Data Available</td>";
                strHtml += "</tfoot>";
            }
        }
        else
        {
            strHtml += "<tr id=\"TableRprtRow\" >";
            strHtml += "<tfoot>";
            strHtml += "<td  class=\"tdT\" colspan=\"11\"; style=\" border-right: navajowhite;font-size: SMALL;width:6%;word-break: break-all; word-wrap:break-word;text-align: CENTER;\" >No Data Available</td>";
            strHtml += "</tfoot>";
        }
        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();

    }


    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        Set_Table(Convert.ToInt32(Button_type.Previous));
    }



    //at next records show button click
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Set_Table(Convert.ToInt32(Button_type.Next));
    }


    //prepare table set datatable
    public void Set_Table(int intButtonId)
    {
               
        clsEntityReports objEntityReports = new clsEntityReports();
        clsBusinessLayerInsReports objBusinessLayerInsReports = new clsBusinessLayerInsReports();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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



        if (HiddenSearchField.Value == "")
        {
            // objEntityNotTemp.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
            objEntityReports.InsuranceProvider = 0;
            objEntityReports.Division_Id = 0;
        }
        else
        {
            string strHidden = "";
            strHidden = HiddenSearchField.Value;



            string[] strSearchFields = strHidden.Split(',');
            string strDivision = strSearchFields[0];
            string strBank = strSearchFields[1];


            if (strDivision != null && strDivision != "")
            {
                if (ddlDivision.Items.FindByValue(strDivision) != null)
                {
                    if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
                    {
                        ddlDivision.ClearSelection();
                        ddlDivision.Items.FindByValue(strDivision).Selected = true;
                        objEntityReports.Division_Id = Convert.ToInt32(strDivision);
                    }
                }
            }
            if (strBank != null && strBank != "")
            {
                if (ddlBank.Items.FindByValue(strBank) != null)
                {
                    if (ddlBank.SelectedItem.Value != "--SELECT PROVIDER--")
                    {
                        ddlBank.ClearSelection();
                        ddlBank.Items.FindByValue(strBank).Selected = true;
                        objEntityReports.BankId = Convert.ToInt32(strBank);
                    }
                }
            }

        


        }
        if (Session["USERID"] != null)
        {
           
            objEntityReports.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
          
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

       

        objEntityReports.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
        DataTable dtInsurance = new DataTable();
        dtInsurance = objBusinessLayerInsReports.Read_Insurance_Expiry_Details(objEntityReports);

        DataTable dtCorp = ObjBussinessReports.Read_Corp_Details(objEntityReports);       
       
        int first = 0;
        int last = 0;

        if (intButtonId == Convert.ToInt32(Button_type.Next))
        {
            first = Convert.ToInt32(hiddenNext.Value);
            last = Convert.ToInt32(hiddenNext.Value) + Convert.ToInt32(hiddenTotalRowCount.Value);
            hiddenPrevious.Value = first.ToString();
            hiddenNext.Value = last.ToString();
        }

        if (intButtonId == Convert.ToInt32(Button_type.Previous))
        {
            first = Convert.ToInt32(hiddenPrevious.Value) - Convert.ToInt32(hiddenTotalRowCount.Value);
            last = Convert.ToInt32(hiddenPrevious.Value);
            hiddenPrevious.Value = first.ToString();
            hiddenNext.Value = last.ToString();
        }
        if (first == 0)
        {
            btnPrevious.Enabled = false;

        }
        else
        {
            btnPrevious.Enabled = true;
        }
        if (last < dtInsurance.Rows.Count)
        {

            btnNext.Enabled = true;
        }
        else
        {
            btnNext.Enabled = false;
        }

        string strPrintReport = ConvertDataTableForPrint(dtInsurance, dtCorp);
        divPrintReport.InnerHtml = strPrintReport;
        //Write to divReport
        string strHtm = ConvertDataTableToHTML(dtInsurance);
        //Write to divReport
        divReport.InnerHtml = strHtm;

    }
    protected void BtnCSV_Click(object sender, EventArgs e)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        string strImagePath;
        string filepath = "";
        DataTable dt = GetTable();
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
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INSURANCE_EXPIRED_CSV);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.INSURANCE_EXPIRED_CSV);
            string newFilePath = Server.MapPath(strImagePath+"/Expired_Ins_Report_" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "Expired_Ins_Report_" + strNextId + ".csv";
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
    public DataTable GetTable()
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayerInsReports objBusinessLayerReports = new clsBusinessLayerInsReports();
        clsEntityReports objEntityReports = new clsEntityReports();
        DataTable table = new DataTable();
       
        table.Columns.Add("INSURANCE REF#", typeof(string));
        table.Columns.Add("DATE", typeof(string));
        table.Columns.Add("INSURANCE CATEGORY", typeof(string));
        table.Columns.Add("PROJECT REF#", typeof(string));
        table.Columns.Add("EXPIRED DATE", typeof(string));
        table.Columns.Add("AGE", typeof(string));
        table.Columns.Add("AMOUNT", typeof(string));
        table.Columns.Add("CURRENCY", typeof(string));

       
       
        if (HiddenSearchField.Value == "")
        {
            
            objEntityReports.GuarCatgryId = 0;
            objEntityReports.Division_Id = 0;
            objEntityReports.BankId = 0;
        }
        else
        {
            string strHidden = "";
            strHidden = HiddenSearchField.Value;
            string[] strSearchFields = strHidden.Split(',');
            string strDivision = strSearchFields[0];
            string strBank = strSearchFields[1];
           
            if (strDivision != null && strDivision != "")
            {
                if (ddlDivision.Items.FindByValue(strDivision) != null)
                {
                    if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
                    {
                        ddlDivision.ClearSelection();
                        ddlDivision.Items.FindByValue(strDivision).Selected = true;
                        objEntityReports.Division_Id = Convert.ToInt32(strDivision);
                    }
                }
            }
       
            if (strBank != null && strBank != "")
            {
                if (ddlBank.Items.FindByValue(strBank) != null)
                {
                    if (ddlBank.SelectedItem.Value != "--SELECT PROVIDER--")
                    {
                        ddlBank.ClearSelection();
                        ddlBank.Items.FindByValue(strBank).Selected = true;
                        objEntityReports.InsuranceProvider = Convert.ToInt32(strBank);
                    }
                }
            }

        }
        if (Session["USERID"] != null)
        {
            objEntityReports.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
           
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

        DataTable dt = new DataTable();
        dt = objBusinessLayerReports.Read_Insurance_Expiry_Details(objEntityReports);
       

        int first = Convert.ToInt32(hiddenPrevious.Value);
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        for (int intRowBodyCount = first; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            
            string DATE = "";
            string CATEGORY = "";
            string PROJECT = "";
            string EXPIRED = "";
            string AGE = "";
            string AMOUNT = "";
            string CURRENCY = "";
            string REf = "";

         
            if (hiddenTotalRowCount.Value == "")
            {
                if (hiddenMemorySize.Value == "")
                {
                    
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
                             DATE = dt.Rows[intRowBodyCount]["INSURANCE_DATE"].ToString();
                        }
                      
                        else if (intColumnBodyCount == 2)
                        {
                            CATEGORY = dt.Rows[intRowBodyCount]["INSURNCTYPE_NAME"].ToString();
                        }
                        else if (intColumnBodyCount == 3)
                        {
                            PROJECT = dt.Rows[intRowBodyCount]["PROJECT_NAME"].ToString() + " / " + dt.Rows[intRowBodyCount]["PROJECT REF#"].ToString();
                        }

                        else if (intColumnBodyCount == 4)
                        {
                       
                            EXPIRED = dt.Rows[intRowBodyCount]["INSURANCE_EXP_DATE"].ToString();
                         }

                        else if (intColumnBodyCount == 5)
                        {
                            AGE = dt.Rows[intRowBodyCount]["INSURANCE_NO_DAYS"].ToString();
                        }
                      
                        else if (intColumnBodyCount == 6)
                        {
                            string strNetAmount = dt.Rows[intRowBodyCount]["INSURANCE_AMOUNT"].ToString();
                            string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                            AMOUNT = dt.Rows[intRowBodyCount]["INSURANCE_AMOUNT"].ToString();
                        }
                        
                        else if (intColumnBodyCount == 7)
                        {
                            CURRENCY = dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString();
                        }
                        
                    }


                    string strId = dt.Rows[intRowBodyCount][0].ToString();
                    int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                    string stridLength = intIdLength.ToString("00");
                    string Id = stridLength + strId + strRandom;
                }
            }
            else
            {
                if (hiddenNext.Value == "")
                {
                    hiddenNext.Value = hiddenTotalRowCount.Value;
                }
                int last = Convert.ToInt32(hiddenNext.Value);
                if (intRowBodyCount < last)
                {

                  
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
                                               
                            DATE = dt.Rows[intRowBodyCount]["INSURANCE_DATE"].ToString();
                        }
                        else if (intColumnBodyCount == 2)
                        {
                            CATEGORY = dt.Rows[intRowBodyCount]["INSURNCTYPE_NAME"].ToString();
                        }
                        else if (intColumnBodyCount == 3)
                        {
                            PROJECT = dt.Rows[intRowBodyCount]["PROJECT REF#"].ToString();
                        }

                          
                        else if (intColumnBodyCount == 4)
                        {
                            EXPIRED = dt.Rows[intRowBodyCount]["INSURANCE_EXP_DATE"].ToString();
                         }

                        else if (intColumnBodyCount == 5)
                        {
                            AGE = dt.Rows[intRowBodyCount]["INSURANCE_NO_DAYS"].ToString();
                        }
                      
                        else if (intColumnBodyCount == 6)
                        {
                            string strNetAmount = dt.Rows[intRowBodyCount]["INSURANCE_AMOUNT"].ToString();
                            string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                            AMOUNT = dt.Rows[intRowBodyCount]["INSURANCE_AMOUNT"].ToString();
                        }
                       
                        else if (intColumnBodyCount == 7)
                        {
                            CURRENCY = dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString();
                        }
                    }
                }
                else
                {
                    btnNext.Enabled = true;
                }
            }

            table.Rows.Add('"' + REf + '"', '"' + DATE + '"',  '"' + CATEGORY + '"', '"' + PROJECT + '"', '"' + EXPIRED + '"', '"' + AGE + '"', '"' + AMOUNT + '"', '"' + CURRENCY + '"');
        }
        return table;

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