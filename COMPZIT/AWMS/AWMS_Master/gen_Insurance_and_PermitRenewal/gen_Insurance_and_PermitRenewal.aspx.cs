using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Collections;
using EL_Compzit;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusinessLayer_AWMS;
using EL_Compzit.EntityLayer_AWMS;
using System.Web.Services;
using System.IO;
//using BL
// CREATED BY:WEM-0006
// CREATED DATE:17/10/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class AWMS_AWMS_Master_gen_Insurance_and_Permit_gen_Insurance_and_Permit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtDate.Attributes.Add("onkeypress", "return isTag(event)");
       
        
        if (!IsPostBack)
        {
            Vehicle_renewal();
            VehicleNumber();
            ddlWeekLoad();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            //Creating objects for business layer
            clsBusinessLayerInsuranceAndPermitExp objBusinessLayerInsunc = new clsBusinessLayerInsuranceAndPermitExp();
            clsEntityInsuranceAndPermitRenewal objEntityInsunc = new clsEntityInsuranceAndPermitRenewal();
            clsEntityCommon objEntityCommon = new clsEntityCommon();

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityInsunc.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityCommon.CorporateID = objEntityInsunc.Corporate_Id;

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityInsunc.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityCommon.Organisation_Id = objEntityInsunc.Organisation_Id;
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.VEHICLE_MASTER);
            objEntityCommon.CommonLabelFieldName = "VHCL_PERMIT_NUMBR";

            //fetch permit common label name
            DataTable dtLblName = new DataTable();
            dtLblName = objBusinessLayer.ReadGeneralLabelName(objEntityCommon);
            string strPermit = "";
            if (dtLblName.Rows.Count > 0)
            {
                strPermit = dtLblName.Rows[0]["CMNLBL_NAME_TOCHNG"].ToString();
                hiddenPermitName.Value = strPermit;

            }

            int intCorpId = objEntityInsunc.Corporate_Id;


            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                          clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                          clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                          clsCommonLibrary.CORP_GLOBAL.VHCL_RNWL_ALRT_MOD,
                                                          clsCommonLibrary.CORP_GLOBAL.VHCL_RNWL_ALRT_VAL
                                                   };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCountMoney.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                hiddenVhclRnwlAlrtMod.Value = dtCorpDetail.Rows[0]["VHCL_RNWL_ALRT_MOD"].ToString();
                hiddenVhclRnwlAlrtVal.Value = dtCorpDetail.Rows[0]["VHCL_RNWL_ALRT_VAL"].ToString();
             

               
            }

            //EVM-0027
           
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
            }

            DataTable dtInsurn = objBusinessLayerInsunc.ReadInsuranceAndPermit(objEntityInsunc);
            string strReport = ConvertDataTableToHTML(dtInsurn);
            divReportDate.InnerHtml = strReport;
            //END

            //DataTable dtInsurn = objBusinessLayerInsunc.ReadInsuranceAndPermitExpDate(objEntityInsunc);
            //string strReport = ConvertDataTableToHTML(dtInsurn);
            //divReportDate.InnerHtml = strReport;
            //objEntityInsunc.DisplayMode = 1;
            //DataTable dtInsurnce = objBusinessLayerInsunc.ReadInsuranceAndPermitAsOnDate(objEntityInsunc);
            //string strRport = ConvertDataTableToHTMLAsOnDate(dtInsurnce);
            //divReportDate.InnerHtml = strRport;


            //string strPrintReport = ConvertDataTableToHTMLForPrint(dtInsurnce);
            //divPrintReport.InnerHtml = strPrintReport;

            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                }
                else if (strInsUpd == "permt")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessPermtConfirmation", "SuccessPermtConfirmation();", true);
                }
                else if (strInsUpd == "Cncl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                }
            }
            // created object for business layer for compare the date
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            string strCurrentDate = objBusiness.LoadCurrentDateInString();

            hiddenCurrentDate.Value = strCurrentDate;


        }
    }
    public void ddlWeekLoad()
    {
        ddlWeek.Items.Add("--Select Period--");
        ddlWeek.Items.Add("1 Week");
        ddlWeek.Items.Add("1 Month");
        ddlWeek.Items.Add("3 Months");    
        ddlWeek.Items.Add("6 Months");
       
    }
    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, string strInsuDate = "", string strpermDate = "")
    {

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        DateTime dateTdate = System.DateTime.Now;
        DateTime dateGetPrmdate ;
        DateTime dateGetInsudate ;
        DateTime dateRnwlAlrt;
        objEntityCommon.VhclRnwlAlrtMod = Convert.ToInt32(hiddenVhclRnwlAlrtMod.Value);
        objEntityCommon.VhclRnwlAlrtVal = Convert.ToInt32(hiddenVhclRnwlAlrtVal.Value);
        dateRnwlAlrt = objBusinessLayer.EnableVhclRnwlLink(objEntityCommon);
        string strPermitName = hiddenPermitName.Value;
        strPermitName = strPermitName.ToUpper();





        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
       

      



        clsBusinessLayerReports objBusinessLayerReports = new clsBusinessLayerReports();
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
            Response.Redirect("~/Default.aspx");
        }

        DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(ObjEntityReports);
        if (dtCorp.Rows.Count > 0)
        {
            strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
            strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
            strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
            strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
            strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
        }
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string usrName = "<B> Report Generated By: </B>" + Session["USERFULLNAME"];
        string week = "", date = "", renweType = "", vehicleNo = "";
        if (ddlWeek.SelectedItem.Text != "--Select Period--")
        {

            week = "<B>Period : </B>" + ddlWeek.SelectedItem.Text;
            date = "<B>As On Date  : </B>" + txtDate.Text;

        }
        if (ddlVehicleRenewal.SelectedItem.Text != "--SELECT RENEWAL TYPE--")
        {
            renweType = "<B>Based On  : </B>" + ddlVehicleRenewal.SelectedItem.Text;
        }
        if (ddlVehicleNumber.SelectedItem.Text != "--REGISTRATION NUMBER--")
        {
            vehicleNo = "<B>Registration No  : </B>" + ddlVehicleNumber.SelectedItem.Text;
        }



        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        string strCompanyAddr = objClsCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);
        StringBuilder sbCap = new StringBuilder();
        string strUsrName = "";
        string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr1 + "</td></tr>";

        string strCaptionTabRprtDate = "",  strGuaranteDivsn = "", strGuaranteCatgry = "", strGuaranteePrjct = "", strVehicleNo = "";
        if (dat != "")
        {
            strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        }
     
        if (week != "")
        {
            strGuaranteDivsn = "<tr><td class=\"RprtDate\">" + week + "</td></tr>";

        }
        if (date != "")
        {
            strGuaranteCatgry = "<tr><td class=\"RprtDate\">" + date + "</td></tr>";

        }
        if (renweType != "")
        {
            strGuaranteePrjct = "<tr><td class=\"RprtDate\">" + renweType + "</td></tr>";
        }
        if (vehicleNo != "")
        {
            strVehicleNo = "<tr><td class=\"RprtDate\">" + vehicleNo + "</td></tr>";
        }


        if (usrName != "")
        {
            strUsrName = "<tr><td class=\"RprtDate\">" + usrName + "</td></tr>";
        }
        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strGuaranteDivsn + strGuaranteCatgry + strGuaranteePrjct + strVehicleNo + strUsrName + strCaptionTabstop;
        sbCap.Append(strPrintCaptionTable);
   
        ////write to  divPrintCaption
        divPrintCaption.InnerHtml = strPrintCaptionTable.ToString();








        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        if(dt.Rows.Count==0)
            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            //if (i == 0)
            //{
            //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
            //}
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:30%;text-align: left; word-wrap:break-word;\">" + "REGISTRATION NUMBER" + "</th>";
            }
            //evm-0027
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">VEHICLE MODEL</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">" + "VEHICLE CLASS" + "</th>";
            }
            else if (intColumnHeaderCount ==4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:12%;text-align: center; word-wrap:break-word;\">" + strPermitName+ " EXP DATE" + "</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:14%;text-align: center; word-wrap:break-word;\">" + "INSURANCE EXP DATE" + "</th>";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\"  style=\"width:14%;text-align: right; word-wrap:break-word;\">" + "INSURANCE AMOUNT" + "</th>";
            }
            //end
        }




        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";

         for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr  >";
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                //if (j == 0)
                //{
                //    int intCnt = i + 1;
                //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                //}
                //EVM-0027
                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;


                string strMode = dt.Rows[intRowBodyCount][7].ToString();

                if (intColumnBodyCount ==1)
                {
                    strHtml += "<td class=\"tdT\" style=\"cursor:pointer;color: blue; width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + " <a     title=\"View\" onclick=\"return getVehicleDetails('" + Id + "');\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a></td>";
                    //strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["VHCL_MODEL"].ToString() + "</td>";
                    //strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

                //END
                if (intColumnBodyCount == 3)
                {

                    if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "0")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["VHCLCLS_NAME"].ToString() + "</td>";

                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["VHCLCLS_NAME"].ToString() + "</td>";
                    }
                }

                //for taking and pASSING id
             
                if (intColumnBodyCount ==4)
                {

                    if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "0")
                        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount]["PERMIT EXP DATE"].ToString() + "</td>";
                    else
                    {

                        dateGetPrmdate = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["PERMIT EXP DATE"].ToString());
                        if (dateGetPrmdate <= dateRnwlAlrt)
                        {
                            if (dateTdate.Date <= dateGetPrmdate.Date)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >" +
                                    " <a style=\" color:Green;\"; onclick='return getdetails(this.href);' href=\"gen_Insurnc_And_Prmt_Exp_details.aspx?permd=" + Id + "&Mode="+strMode+"\">"
                                    + dt.Rows[intRowBodyCount]["PERMIT EXP DATE"].ToString() +
                                    " </a> </td>";
                            }

                            else if (dateTdate.Date > dateGetPrmdate.Date)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >" +
                                    " <a style=\" color:Red;\"; onclick='return getdetails(this.href);' href=\"gen_Insurnc_And_Prmt_Exp_details.aspx?permd=" + Id + "&Mode=" + strMode + "\">"
                                    + dt.Rows[intRowBodyCount]["PERMIT EXP DATE"].ToString() +
                                    " </a> </td>";

                            }
                        }
                        else
                        {
                            if (dateTdate.Date <= dateGetPrmdate.Date)
                            {
                                strHtml += "<td class=\"tdT\" style=\" color:Green;width:12%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >"

                                    + dt.Rows[intRowBodyCount]["PERMIT EXP DATE"].ToString() +
                                    "</td>";
                            }

                           
                        }
                       
                    }
                }
                else if (intColumnBodyCount == 5)
                {
                    if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "0")
                        strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount]["INURANCE EXP DATE"].ToString() + "</td>";
                    else
                    {
                        dateGetInsudate = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["INSURANCE EXP DATE"].ToString());
                        if (dateGetInsudate <= dateRnwlAlrt)
                        {
                            if (dateTdate.Date <= dateGetInsudate.Date)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >" +
                                    " <a style=\" color:Green;\"; onclick='return getdetails(this.href);' href=\"gen_Insurnc_And_Prmt_Exp_details.aspx?insd=" + Id + "&Mode=" + strMode + "\">"
                                    + dt.Rows[intRowBodyCount]["INSURANCE EXP DATE"].ToString() +
                                    " </a> </td>";
                            }
                            else if (dateTdate.Date > dateGetInsudate.Date)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >" +
                                    " <a style=\" color:Red;\"; onclick='return getdetails(this.href);' href=\"gen_Insurnc_And_Prmt_Exp_details.aspx?insd=" + Id + "&Mode=" + strMode + "\">"
                                    + dt.Rows[intRowBodyCount]["INSURANCE EXP DATE"].ToString() +
                                    " </a> </td>";
                            }
                        }
                        else
                        {
                            if (dateTdate.Date <= dateGetInsudate.Date)
                            {
                                strHtml += "<td class=\"tdT\" style=\" color:Green;width:14%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >"

                                    + dt.Rows[intRowBodyCount]["INSURANCE EXP DATE"].ToString() +
                                    "  </td>";
                            }
                           
                        }
                        
                    }
                }
               else if (intColumnBodyCount == 6)
                {
                    string InsrAmnt = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                    objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                    string commaInsrAmnt = objBusinessLayer.AddCommasForNumberSeperation(InsrAmnt, objEntityCommon);
                    if (dt.Rows[intRowBodyCount][intColumnBodyCount] != DBNull.Value)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + commaInsrAmnt + "</td>";

                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + "0" + "</td>";
                    }
                    
                }

                


            }
            strHtml += "</tr>";
        }



         strHtml += "</tbody>";

         strHtml += "</table>";

         sb.Append(strHtml);
         return sb.ToString();

    }
     //set vehcle renewal details
    private void Vehicle_renewal()
    {
        clsBusinessLayerInsuranceAndPermitExp objBusinessLayerInsunc = new clsBusinessLayerInsuranceAndPermitExp();
        clsEntityInsuranceAndPermitRenewal objEntityInsunc = new clsEntityInsuranceAndPermitRenewal();
       
        DataTable dtRenewal = objBusinessLayerInsunc.ReadVehicleRenewal(objEntityInsunc);

        ddlVehicleRenewal.DataSource = dtRenewal;

        ddlVehicleRenewal.DataTextField = "VHCLRENWL_NAME";
        ddlVehicleRenewal.DataValueField = "VHCLRENWL_ID";
        ddlVehicleRenewal.DataBind();
        ddlVehicleRenewal.Items.Insert(0, "--SELECT RENEWAL TYPE--");

    }


    //set vehcle renewal details
    private void VehicleNumber()
    {
        clsBusinessLayerInsuranceAndPermitExp objBusinessLayerInsunc = new clsBusinessLayerInsuranceAndPermitExp();
        clsEntityInsuranceAndPermitRenewal objEntityInsunc = new clsEntityInsuranceAndPermitRenewal();

        DataTable dtRenewal = objBusinessLayerInsunc.ReadVehicleNumber(objEntityInsunc);

        ddlVehicleNumber.DataSource = dtRenewal;

        ddlVehicleNumber.DataTextField = "NUMBER";
        ddlVehicleNumber.DataValueField = "VHCL_ID";
        ddlVehicleNumber.DataBind();
        ddlVehicleNumber.Items.Insert(0, "--REGISTRATION NUMBER--");

    }


     //at search button click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //Creating objects for business layer
        clsBusinessLayerInsuranceAndPermitExp objBusinessLayerInsunc = new clsBusinessLayerInsuranceAndPermitExp();
        clsEntityInsuranceAndPermitRenewal objEntityInsunc = new clsEntityInsuranceAndPermitRenewal();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsunc.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityInsunc.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

       
        objEntityInsunc.NewDate = objCommon.textToDateTime(txtDate.Text);
        if (ddlVehicleNumber.SelectedItem.Text != "--REGISTRATION NUMBER--")
        {
            objEntityInsunc.VehiclNmbr = (ddlVehicleNumber.SelectedItem.Text);
        }
        else
        {
            objEntityInsunc.VehiclNmbr = "0";
        }

        if (ddlVehicleRenewal.SelectedItem.Value!="0")
        {
        objEntityInsunc.DisplayMode=Convert.ToInt32(ddlVehicleRenewal.SelectedItem.Value);
        }
        DataTable dtInsurn = objBusinessLayerInsunc.ReadInsuranceAndPermit(objEntityInsunc);
        string strReport = ConvertDataTableToHTML(dtInsurn);
        divReportDate.InnerHtml = strReport;
        //DataTable dtInsurn = objBusinessLayerInsunc.ReadInsuranceAndPermitAsOnDate(objEntityInsunc);

        //  string strReport = ConvertDataTableToHTMLAsOnDate(dtInsurn);
        //  divReportDate.InnerHtml = strReport;
      
    }


    //public string ConvertDataTableToHTMLAsOnDate(DataTable dt)
    //{
    //    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
    //    clsEntityCommon objEntityCommon = new clsEntityCommon();
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    string strRandom = objCommon.Random_Number();

    //    string strPermitName = hiddenPermitName.Value;
    //    strPermitName = strPermitName.ToUpper();

    //    clsEntityInsuranceAndPermitRenewal objEntityInsunc = new clsEntityInsuranceAndPermitRenewal();
    //    //DateTime dateTdate = objEntityInsunc.NewDate;
    //    DateTime dateTdate = System.DateTime.Now;
    //    DateTime dateGetPrmdate;
    //    DateTime dateGetInsudate;
    //    DateTime dateRnwlAlrt;
    //    objEntityCommon.VhclRnwlAlrtMod = Convert.ToInt32(hiddenVhclRnwlAlrtMod.Value);
    //    objEntityCommon.VhclRnwlAlrtVal = Convert.ToInt32(hiddenVhclRnwlAlrtVal.Value);
    //    dateRnwlAlrt = objBusinessLayer.EnableVhclRnwlLink(objEntityCommon);
       
      






    //    // class="table table-bordered table-striped"
    //    StringBuilder sb = new StringBuilder();
    //    string strHtml = "<table id=\"ReportTable2\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
    //    //add header row
    //    strHtml += "<thead>";
    //    strHtml += "<tr class=\"main_table_head\">";
 
    //    for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
    //    {
    //        //if (i == 0)
    //        //{
    //        //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
    //        //}
    //        if (intColumnHeaderCount == 1)
    //        {
    //            strHtml += "<th class=\"thT\" style=\"width:30%;text-align: left; word-wrap:break-word;\">" + "REGISTRATION NUMBER" + "</th>";
    //        }
    //        //evm-0027
    //        if (intColumnHeaderCount == 2)
    //        {
    //            strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">VEHICLE MODEL</th>";
    //        }
    //        if (intColumnHeaderCount == 3)
    //        {
    //            strHtml += "<th class=\"thT\" style=\"width:30%;text-align: left; word-wrap:break-word;\">" + "VEHICLE CLASS" + "</th>";
    //        }
    //        else if (intColumnHeaderCount == 4)
    //        {
                
    //                strHtml += "<th class=\"thT\"  style=\"width:12%;text-align: center; word-wrap:break-word;\">" + strPermitName+ " EXP DATE" + "</th>";
                
    //        }
    //        else if (intColumnHeaderCount == 5)
    //        {
    //            strHtml += "<th class=\"thT\"  style=\"width:14%;text-align: center; word-wrap:break-word;\">" + "INSURANCE EXP DATE" + "</th>";
    //        }
    //        else if (intColumnHeaderCount == 6)
    //        {
    //            strHtml += "<th class=\"thT\"  style=\"width:14%;text-align: right; word-wrap:break-word;\">" + "INSURANCE AMOUNT" + "</th>";
    //        }
    //    }
    //    //END

    //     strHtml += "</tr>";
    //    strHtml += "</thead>";
    //    //add rows

    //    strHtml += "<tbody>";
        
    //    if (dt.Rows.Count == 0)
    //    {
    //        strHtml += "<tr class=\"odd\">";
    //        strHtml += "<td class=\"dataTables_empty\" colspan=\"6\" valign=\"top\" style=\"text-align: center;\">No data available</td>";
    //        strHtml += "</tr>";
    //    }

    //    else
    //    {
    //     for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
    //    {
    //        strHtml += "<tr  >";
    //        for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
    //        {
    //            //if (j == 0)
    //            //{
    //            //    int intCnt = i + 1;
    //            //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
    //            //}
    //            if (intColumnBodyCount == 1)
    //            {
    //                strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //            }
    //            if (intColumnBodyCount == 2)
    //            {
    //                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["VHCL_MODEL"].ToString() + "</td>";
    //            }
    //            if (intColumnBodyCount == 3)
    //            {

    //                if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "0")
    //                    strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount]["VHCLCLS_NAME"].ToString() + "</td>";
    //                else
    //                {
    //                    //string strHref="gen_Lead_Summary_Popup.aspx?Id=" + dt.Rows[intRowBodyCount][3].ToString() ;
    //                    strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["VHCLCLS_NAME"].ToString() + "</td>";
    //                }
    //            }

    //            //for taking and pASSING id
    //            string strId = dt.Rows[intRowBodyCount][0].ToString();
    //            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
    //            string stridLength = intIdLength.ToString("00");
    //            string Id = stridLength + strId + strRandom;


    //            string strMode = dt.Rows[intRowBodyCount][7].ToString();
    //            if (intColumnBodyCount == 4)
    //            {
    //                if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "0")
    //                    strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount]["PERMIT EXP DATE"].ToString() + "</td>";
    //                else
    //                {
                        
    //                        //strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";


    //                    dateGetPrmdate = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["PERMIT EXP DATE"].ToString());
    //                        if (dateGetPrmdate <= dateRnwlAlrt)
    //                        {
    //                            if (dateTdate.Date <= dateGetPrmdate.Date)
    //                            {
    //                                if (txtDate.Text.ToString() != "")
    //                                {
    //                                    DateTime dateAsOnDate;
    //                                    dateAsOnDate = objCommon.textToDateTime(txtDate.Text.Trim());

    //                                    if (dateAsOnDate <= dateGetPrmdate.Date)
    //                                    {
    //                                        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >" +
    //                                            " <a style=\" color:Green;\"; onclick='return getdetails(this.href);' href=\"gen_Insurnc_And_Prmt_Exp_details.aspx?permd=" + Id + "&Mode=" + strMode + "\">"
    //                                            + dt.Rows[intRowBodyCount]["PERMIT EXP DATE"].ToString() +
    //                                            " </a> </td>";
    //                                    }
    //                                    else
    //                                    {
    //                                        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >" +
    //                                            " <a style=\" color:#6a00b4;\"; onclick='return getdetails(this.href);' href=\"gen_Insurnc_And_Prmt_Exp_details.aspx?permd=" + Id + "&Mode=" + strMode + "\">"
    //                                            + dt.Rows[intRowBodyCount]["PERMIT EXP DATE"].ToString() +
    //                                            " </a> </td>";
    //                                    }
    //                                }
    //                            }
    //                            else if (dateTdate.Date > dateGetPrmdate.Date)
    //                            {

    //                                strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >" +
    //                                    " <a style=\" color:red;\"; onclick='return getdetails(this.href);' href=\"gen_Insurnc_And_Prmt_Exp_details.aspx?permd=" + Id + "&Mode=" + strMode + "\">"
    //                                    + dt.Rows[intRowBodyCount]["PERMIT EXP DATE"].ToString() +
    //                                    " </a> </td>";
    //                            }
    //                        }
    //                        else
    //                        {
    //                            if (dateTdate.Date <= dateGetPrmdate.Date)
    //                            {
    //                                if (txtDate.Text.ToString() != "")
    //                                {
    //                                    DateTime dateAsOnDate;
    //                                    dateAsOnDate = objCommon.textToDateTime(txtDate.Text.Trim());

    //                                    if (dateAsOnDate <= dateGetPrmdate.Date)
    //                                    {
    //                                        strHtml += "<td class=\"tdT\" style=\" color:Green;width:12%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >"

    //                                            + dt.Rows[intRowBodyCount]["PERMIT EXP DATE"].ToString() +
    //                                            "  </td>";
    //                                    }
    //                                    else
    //                                    {
    //                                        strHtml += "<td class=\"tdT\" style=\" color:#6a00b4;width:12%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >"

    //                                            + dt.Rows[intRowBodyCount]["PERMIT EXP DATE"].ToString() +
    //                                            "  </td>";
    //                                    }
    //                                }
    //                            }
    //                            else if (dateTdate.Date > dateGetPrmdate.Date)
    //                            {

    //                                strHtml += "<td class=\"tdT\" style=\" color:red;width:12%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >"

    //                                    + dt.Rows[intRowBodyCount]["PERMIT EXP DATE"].ToString() +
    //                                    "  </td>";
    //                            }
    //                        }
    //                }
    //            }
    //            else if (intColumnBodyCount == 5)
    //            {
    //                if (dt.Rows[intRowBodyCount]["INSURANCE EXP DATE"].ToString() == "0")
    //                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount]["INURANCE EXP DATE"].ToString() + "</td>";
    //                else
    //                {
    //                    dateGetInsudate = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["INSURANCE EXP DATE"].ToString());
    //                    if (dateGetInsudate <= dateRnwlAlrt)
    //                    {

    //                        if (dateTdate.Date <= dateGetInsudate.Date)
    //                        {
    //                            if (txtDate.Text.ToString() != "")
    //                            {
    //                                DateTime dateAsOnDate;
    //                                dateAsOnDate = objCommon.textToDateTime(txtDate.Text.Trim());

    //                                if (dateAsOnDate <= dateGetInsudate.Date)
    //                                {
    //                                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >" +
    //                                        " <a style=\" color:Green;\"; onclick='return getdetails(this.href);' href=\"gen_Insurnc_And_Prmt_Exp_details.aspx?insd=" + Id + "&Mode=" + strMode + "\">"
    //                                        + dt.Rows[intRowBodyCount]["INSURANCE EXP DATE"].ToString() +
    //                                        " </a> </td>";
    //                                }
    //                                else
    //                                {
    //                                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >" +
    //                                       " <a style=\" color:#6a00b4;\"; onclick='return getdetails(this.href);' href=\"gen_Insurnc_And_Prmt_Exp_details.aspx?insd=" + Id + "&Mode=" + strMode + "\">"
    //                                       + dt.Rows[intRowBodyCount]["INSURANCE EXP DATE"].ToString() +
    //                                       " </a> </td>";
    //                                }
    //                            }
    //                        }
    //                        else if (dateTdate.Date > dateGetInsudate.Date)
    //                        {

    //                            strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >" +
    //                                " <a style=\" color:Red;\"; onclick='return getdetails(this.href);' href=\"gen_Insurnc_And_Prmt_Exp_details.aspx?insd=" + Id + "&Mode=" + strMode + "\">"
    //                                + dt.Rows[intRowBodyCount]["INSURANCE EXP DATE"].ToString() +
    //                                " </a> </td>";
    //                        }
    //                    }
    //                    else
    //                    {
    //                        if (dateTdate.Date <= dateGetInsudate.Date)
    //                        {
    //                            if (txtDate.Text.ToString() != "")
    //                            {
    //                                DateTime dateAsOnDate;
    //                                dateAsOnDate = objCommon.textToDateTime(txtDate.Text.Trim());

    //                                if (dateAsOnDate <= dateGetInsudate.Date)
    //                                {
    //                                    strHtml += "<td class=\"tdT\" style=\" color:Green;width:14%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >"

    //                                        + dt.Rows[intRowBodyCount]["INSURANCE EXP DATE"].ToString() +
    //                                        "  </td>";
    //                                }
    //                                else
    //                                {
    //                                    strHtml += "<td class=\"tdT\" style=\" color:#6a00b4;width:14%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >"

    //                                       + dt.Rows[intRowBodyCount]["INSURANCE EXP DATE"].ToString() +
    //                                       "  </td>";
    //                                }
    //                            }
    //                        }
    //                        else if (dateTdate.Date > dateGetInsudate.Date)
    //                        {

    //                            strHtml += "<td class=\"tdT\" style=\" color:Red;width:14%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >"

    //                                + dt.Rows[intRowBodyCount]["INSURANCE EXP DATE"].ToString() +
    //                                " </td>";
    //                        }
    //                    }
    //                }
    //            }
    //            else if (intColumnBodyCount == 6)
    //            {
    //                string InsrAmnt = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
    //                objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
    //                string commaInsrAmnt = objBusinessLayer.AddCommasForNumberSeperation(InsrAmnt, objEntityCommon);
    //                if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "0")
    //                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + commaInsrAmnt + "</td>";
    //                else
    //                {
    //                    //string strHref="gen_Lead_Summary_Popup.aspx?Id=" + dt.Rows[intRowBodyCount][3].ToString() ;
    //                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + commaInsrAmnt + "</td>";
    //                }
    //            }

                


    //        }
    //        strHtml += "</tr>";
    //    }
    //}


    //     strHtml += "</tbody>";

    //     strHtml += "</table>";

    //     sb.Append(strHtml);
    //     return sb.ToString();

    //}


    //public string ConvertDataTableToHTMLForPrint(DataTable dt)
    //{
    //    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
    //    clsEntityCommon objEntityCommon = new clsEntityCommon();
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    string strRandom = objCommon.Random_Number();

    //    string strPermitName = hiddenPermitName.Value;
    //    strPermitName = strPermitName.ToUpper();

    //    clsEntityInsuranceAndPermitRenewal objEntityInsunc = new clsEntityInsuranceAndPermitRenewal();
    //    //DateTime dateTdate = objEntityInsunc.NewDate;
    //    DateTime dateTdate = System.DateTime.Now;
    //    DateTime dateGetPrmdate;
    //    DateTime dateGetInsudate;
    //    DateTime dateRnwlAlrt;
    //    objEntityCommon.VhclRnwlAlrtMod = Convert.ToInt32(hiddenVhclRnwlAlrtMod.Value);
    //    objEntityCommon.VhclRnwlAlrtVal = Convert.ToInt32(hiddenVhclRnwlAlrtVal.Value);
    //    dateRnwlAlrt = objBusinessLayer.EnableVhclRnwlLink(objEntityCommon);

    //    //EVM-0027 For Print



    //    objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
    //    string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
    //    clsBusinessLayer objBusiness = new clsBusinessLayer();
    //    string strTitle = "";

    //    strTitle = "Project Wise Insurance Report";

    //    DateTime datetm = DateTime.Now;
    //    string dat = "<B>Report Date: </B>" + datetm.ToString("R");
    //    string usrName = "<B> Report Generated By: </B>" + Session["USERFULLNAME"];
    //    string  week = "", date = "", renweType = "",vehicleNo="";
    //    if (ddlWeek.SelectedItem.Text != "--Select Period--")
    //    {

    //        week = "<B>Period : </B>" + ddlWeek.SelectedItem.Text;
    //        date = "<B>As On Date  : </B>" + txtDate.Text;

    //    }
    //    if (ddlVehicleRenewal.SelectedItem.Text != "--SELECT RENEWAL TYPE--")
    //    {
    //        renweType = "<B>Based On  : </B>" + ddlVehicleRenewal.SelectedItem.Text;
    //    }
    //    if (ddlVehicleNumber.SelectedItem.Text != "--REGISTRATION NUMBER--")
    //    {
    //        vehicleNo = "<B>Registration No  : </B>" + ddlVehicleNumber.SelectedItem.Text;
    //    }
        

       
    //    clsBusinessLayerReports objBusinessLayerReports = new clsBusinessLayerReports();
    //    clsEntityReports ObjEntityReports = new clsEntityReports();
    //    if (Session["CORPOFFICEID"] != null)
    //    {
    //        ObjEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

    //    }
    //    else if (Session["CORPOFFICEID"] == null)
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }
    //    if (Session["ORGID"] != null)
    //    {
    //        ObjEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
           
    //    }
    //    else if (Session["ORGID"] == null)
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }
       
    //    DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(ObjEntityReports);
    //    if (dtCorp.Rows.Count > 0)
    //    {
    //        strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
    //        strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
    //        strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
    //        strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
    //        strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
    //    }



    //    clsCommonLibrary objClsCommon = new clsCommonLibrary();
    //    string strCompanyAddr = objClsCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);
    //    StringBuilder sbCap = new StringBuilder();
    //    string strUsrName = "";
    //    string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
    //    string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
    //    string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr1 + "</td></tr>";

    //    string strCaptionTabRprtDate = "", strCaptionTabTitle = "", strGuaranteDivsn = "", strGuaranteCatgry = "", strGuaranteePrjct = "", strVehicleNo="";
    //    if (dat != "")
    //    {
    //        strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
    //    }
    //    //if (strTitle != "")
    //    //{
    //    //    strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
    //    //}
    //    if (week != "")
    //    {
    //        strGuaranteDivsn = "<tr><td class=\"RprtDiv\">" + week + "</td></tr>";

    //    }
    //    if (date != "")
    //    {
    //        strGuaranteCatgry = "<tr><td class=\"RprtDiv\">" + date + "</td></tr>";

    //    }
    //    if (renweType != "")
    //    {
    //        strGuaranteePrjct = "<tr><td class=\"RprtDiv\">" + renweType + "</td></tr>";
    //    }
    //     if (vehicleNo != "")
    //    {
    //        strVehicleNo = "<tr><td class=\"RprtDiv\">" + vehicleNo + "</td></tr>";
    //    }
     

    //    if (usrName != "")
    //    {
    //        strUsrName = "<tr><td class=\"RprtDate\">" + usrName + "</td></tr>";
    //    }
    //    string strCaptionTabstop = "</table>";
    //    string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strGuaranteDivsn + strGuaranteCatgry + strGuaranteePrjct + strVehicleNo+strUsrName + strCaptionTabTitle + strCaptionTabstop;
    //    sbCap.Append(strPrintCaptionTable);
    //    ////write to  divPrintCaption
    //   // divPrintCaption.InnerHtml = strPrintCaptionTable.ToString();






    //    //END

    //    StringBuilder sb = new StringBuilder();
    //    string strHtml = "<table id=\"ReportTable1\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
    //    //add header row
    //    strHtml += "<thead>";
    //    strHtml += "<tr class=\"main_table_head\">";
    //    if (dt.Rows.Count == 0)
    //        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";
    //    for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
    //    {
    //        //if (i == 0)
    //        //{
    //        //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
    //        //}
    //        if (intColumnHeaderCount == 1)
    //        {
    //            strHtml += "<th class=\"thT\" style=\"width:30%;text-align: left; word-wrap:break-word;\">" + "REGISTRATION NUMBER" + "</th>";
    //        }
    //        //evm-0027
    //        if (intColumnHeaderCount == 2)
    //        {
    //            strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">VEHICLE MODEL</th>";
    //        }
    //        if (intColumnHeaderCount == 3)
    //        {
    //            strHtml += "<th class=\"thT\" style=\"width:30%;text-align: left; word-wrap:break-word;\">" + "VEHICLE CLASS" + "</th>";
    //        }
    //        else if (intColumnHeaderCount == 4)
    //        {
    //            strHtml += "<th class=\"thT\"  style=\"width:12%;text-align: center; word-wrap:break-word;\">" + strPermitName + " EXP DATE" + "</th>";
    //        }
    //        else if (intColumnHeaderCount == 5)
    //        {
    //            strHtml += "<th class=\"thT\"  style=\"width:14%;text-align: center; word-wrap:break-word;\">" + "INSURANCE EXP DATE" + "</th>";
    //        }
    //        else if (intColumnHeaderCount == 6)
    //        {
    //            strHtml += "<th class=\"thT\"  style=\"width:14%;text-align: right; word-wrap:break-word;\">" + "INSURANCE AMOUNT" + "</th>";
    //        }
    //        //end
    //    }




    //    strHtml += "</tr>";
    //    strHtml += "</thead>";
    //    //add rows

    //    strHtml += "<tbody>";

    //    for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
    //    {
    //        strHtml += "<tr  >";
    //        for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
    //        {
    //            //if (j == 0)
    //            //{
    //            //    int intCnt = i + 1;
    //            //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
    //            //}
    //            //EVM-0027
    //            string strId = dt.Rows[intRowBodyCount][0].ToString();
    //            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
    //            string stridLength = intIdLength.ToString("00");
    //            string Id = stridLength + strId + strRandom;


    //            string strMode = dt.Rows[intRowBodyCount][7].ToString();

    //            if (intColumnBodyCount == 1)
    //            {
    //                strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + " <a   style=\"cursor:pointer;color: blue;\"  title=\"View\" onclick=\"return getVehicleDetails('" + Id + "');\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a></td>";
    //                //strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //            }
    //            if (intColumnBodyCount == 2)
    //            {
    //                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount]["VHCL_MODEL"].ToString() + "</td>";
    //                //strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //            }

    //            //END
    //            if (intColumnBodyCount == 3)
    //            {

    //                if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "0")
    //                {
    //                    strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount]["VHCLCLS_NAME"].ToString() + "</td>";

    //                }
    //                else
    //                {
    //                    strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["VHCLCLS_NAME"].ToString() + "</td>";
    //                }
    //            }

    //            //for taking and pASSING id

    //            if (intColumnBodyCount == 4)
    //            {

    //                if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "0")
    //                    strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount]["PERMIT EXP DATE"].ToString() + "</td>";
    //                else
    //                {

    //                    dateGetPrmdate = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["PERMIT EXP DATE"].ToString());
    //                    if (dateGetPrmdate <= dateRnwlAlrt)
    //                    {
    //                        if (dateTdate.Date <= dateGetPrmdate.Date)
    //                        {
    //                            strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >" +
    //                                " <a style=\" color:Green;\"; onclick='return getdetails(this.href);' href=\"gen_Insurnc_And_Prmt_Exp_details.aspx?permd=" + Id + "&Mode=" + strMode + "\">"
    //                                + dt.Rows[intRowBodyCount]["PERMIT EXP DATE"].ToString() +
    //                                " </a> </td>";
    //                        }

    //                        else if (dateTdate.Date > dateGetPrmdate.Date)
    //                        {
    //                            strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >" +
    //                                " <a style=\" color:Red;\"; onclick='return getdetails(this.href);' href=\"gen_Insurnc_And_Prmt_Exp_details.aspx?permd=" + Id + "&Mode=" + strMode + "\">"
    //                                + dt.Rows[intRowBodyCount]["PERMIT EXP DATE"].ToString() +
    //                                " </a> </td>";

    //                        }
    //                    }
    //                    else
    //                    {
    //                        if (dateTdate.Date <= dateGetPrmdate.Date)
    //                        {
    //                            strHtml += "<td class=\"tdT\" style=\" color:Green;width:12%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >"

    //                                + dt.Rows[intRowBodyCount]["PERMIT EXP DATE"].ToString() +
    //                                "</td>";
    //                        }


    //                    }

    //                }
    //            }
    //            else if (intColumnBodyCount == 5)
    //            {
    //                if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "0")
    //                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount]["INURANCE EXP DATE"].ToString() + "</td>";
    //                else
    //                {
    //                    dateGetInsudate = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["INSURANCE EXP DATE"].ToString());
    //                    if (dateGetInsudate <= dateRnwlAlrt)
    //                    {
    //                        if (dateTdate.Date <= dateGetInsudate.Date)
    //                        {
    //                            strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >" +
    //                                " <a style=\" color:Green;\"; onclick='return getdetails(this.href);' href=\"gen_Insurnc_And_Prmt_Exp_details.aspx?insd=" + Id + "&Mode=" + strMode + "\">"
    //                                + dt.Rows[intRowBodyCount]["INSURANCE EXP DATE"].ToString() +
    //                                " </a> </td>";
    //                        }
    //                        else if (dateTdate.Date > dateGetInsudate.Date)
    //                        {
    //                            strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >" +
    //                                " <a style=\" color:Red;\"; onclick='return getdetails(this.href);' href=\"gen_Insurnc_And_Prmt_Exp_details.aspx?insd=" + Id + "&Mode=" + strMode + "\">"
    //                                + dt.Rows[intRowBodyCount]["INSURANCE EXP DATE"].ToString() +
    //                                " </a> </td>";
    //                        }
    //                    }
    //                    else
    //                    {
    //                        if (dateTdate.Date <= dateGetInsudate.Date)
    //                        {
    //                            strHtml += "<td class=\"tdT\" style=\" color:Green;width:14%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >"

    //                                + dt.Rows[intRowBodyCount]["INSURANCE EXP DATE"].ToString() +
    //                                "  </td>";
    //                        }

    //                    }

    //                }
    //            }
    //            else if (intColumnBodyCount == 6)
    //            {
    //                string InsrAmnt = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
    //                objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
    //                string commaInsrAmnt = objBusinessLayer.AddCommasForNumberSeperation(InsrAmnt, objEntityCommon);
    //                if (dt.Rows[intRowBodyCount][intColumnBodyCount] != DBNull.Value)
    //                {
    //                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + commaInsrAmnt + "</td>";

    //                }
    //                else
    //                {
    //                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + "0" + "</td>";
    //                }

    //            }




    //        }
    //        strHtml += "</tr>";
    //    }



    //    strHtml += "</tbody>";

    //    strHtml += "</table>";

    //    sb.Append(strHtml);
    //    return sb.ToString();




    //    //// class="table table-bordered table-striped"
    //    //StringBuilder sb = new StringBuilder();
    //    //string strHtml = "<table id=\"ReportTable1\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
    //    ////add header row
    //    //strHtml += "<thead>";
    //    //strHtml += "<tr class=\"main_table_head\">";

    //    //for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
    //    //{
    //    //    //if (i == 0)
    //    //    //{
    //    //    //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
    //    //    //}
    //    //    if (intColumnHeaderCount == 1)
    //    //    {
    //    //        strHtml += "<th class=\"thT\" style=\"width:30%;text-align: left; word-wrap:break-word;\">" + "REGISTRATION NUMBER" + "</th>";
    //    //    }
    //    //    if (intColumnHeaderCount == 2)
    //    //    {
    //    //        strHtml += "<th class=\"thT\" style=\"width:30%;text-align: left; word-wrap:break-word;\">" + "VEHICLE CLASS" + "</th>";
    //    //    }
    //    //    else if (intColumnHeaderCount == 3)
    //    //    {

    //    //        strHtml += "<th class=\"thT\"  style=\"width:12%;text-align: center; word-wrap:break-word;\">" + strPermitName + " EXP DATE" + "</th>";

    //    //    }
    //    //    else if (intColumnHeaderCount == 4)
    //    //    {
    //    //        strHtml += "<th class=\"thT\"  style=\"width:14%;text-align: center; word-wrap:break-word;\">" + "INSURANCE EXP DATE" + "</th>";
    //    //    }
    //    //    else if (intColumnHeaderCount == 5)
    //    //    {
    //    //        strHtml += "<th class=\"thT\"  style=\"width:14%;text-align: right; word-wrap:break-word;\">" + "INSURANCE AMOUNT" + "</th>";
    //    //    }
    //    //}

    //    //strHtml += "</tr>";
    //    //strHtml += "</thead>";
    //    ////add rows

    //    //strHtml += "<tbody>";

    //    //if (dt.Rows.Count == 0)
    //    //{
    //    //    strHtml += "<tr class=\"odd\">";
    //    //    strHtml += "<td class=\"dataTables_empty\" colspan=\"6\" valign=\"top\" style=\"text-align: center;\">No data available</td>";
    //    //    strHtml += "</tr>";
    //    //}

    //    //else
    //    //{
    //    //    for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
    //    //    {
    //    //        strHtml += "<tr  >";
    //    //        for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
    //    //        {
    //    //            //if (j == 0)
    //    //            //{
    //    //            //    int intCnt = i + 1;
    //    //            //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
    //    //            //}
    //    //            if (intColumnBodyCount == 1)
    //    //            {
    //    //                strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //    //            }
    //    //            if (intColumnBodyCount == 2)
    //    //            {

    //    //                if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "0")
    //    //                    strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //    //                else
    //    //                {
    //    //                    //string strHref="gen_Lead_Summary_Popup.aspx?Id=" + dt.Rows[intRowBodyCount][3].ToString() ;
    //    //                    strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //    //                }
    //    //            }

    //    //            //for taking and pASSING id
    //    //            string strId = dt.Rows[intRowBodyCount][0].ToString();
    //    //            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
    //    //            string stridLength = intIdLength.ToString("00");
    //    //            string Id = stridLength + strId + strRandom;


    //    //            string strMode = dt.Rows[intRowBodyCount][6].ToString();
    //    //            if (intColumnBodyCount == 3)
    //    //            {
    //    //                if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "0")
    //    //                    strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //    //                else
    //    //                {

    //    //                    //strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";


    //    //                    dateGetPrmdate = objCommon.textToDateTime(dt.Rows[intRowBodyCount][3].ToString());
    //    //                    if (dateGetPrmdate <= dateRnwlAlrt)
    //    //                    {
    //    //                        if (dateTdate.Date <= dateGetPrmdate.Date)
    //    //                        {
    //    //                            if (txtDate.Text.ToString() != "")
    //    //                            {
    //    //                                DateTime dateAsOnDate;
    //    //                                dateAsOnDate = objCommon.textToDateTime(txtDate.Text.Trim());

    //    //                                if (dateAsOnDate <= dateGetPrmdate.Date)
    //    //                                {
    //    //                                    strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() +    " </td>";
    //    //                                }
    //    //                                else
    //    //                                {
    //    //                                    strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() +   " </td>";
    //    //                                }
    //    //                            }
    //    //                        }
    //    //                        else if (dateTdate.Date > dateGetPrmdate.Date)
    //    //                        {

    //    //                            strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >"+ dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() +
    //    //                                " </td>";
    //    //                        }
    //    //                    }
    //    //                    else
    //    //                    {
    //    //                        if (dateTdate.Date <= dateGetPrmdate.Date)
    //    //                        {
    //    //                            if (txtDate.Text.ToString() != "")
    //    //                            {
    //    //                                DateTime dateAsOnDate;
    //    //                                dateAsOnDate = objCommon.textToDateTime(txtDate.Text.Trim());

    //    //                                if (dateAsOnDate <= dateGetPrmdate.Date)
    //    //                                {
    //    //                                    strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >"

    //    //                                        + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() +
    //    //                                        "  </td>";
    //    //                                }
    //    //                                else
    //    //                                {
    //    //                                    strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >"

    //    //                                        + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() +
    //    //                                        "  </td>";
    //    //                                }
    //    //                            }
    //    //                        }
    //    //                        else if (dateTdate.Date > dateGetPrmdate.Date)
    //    //                        {

    //    //                            strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >"

    //    //                                + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() +
    //    //                                "  </td>";
    //    //                        }
    //    //                    }
    //    //                }
    //    //            }
    //    //            else if (intColumnBodyCount == 4)
    //    //            {
    //    //                if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "0")
    //    //                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //    //                else
    //    //                {
    //    //                    dateGetInsudate = objCommon.textToDateTime(dt.Rows[intRowBodyCount][4].ToString());
    //    //                    if (dateGetInsudate <= dateRnwlAlrt)
    //    //                    {

    //    //                        if (dateTdate.Date <= dateGetInsudate.Date)
    //    //                        {
    //    //                            if (txtDate.Text.ToString() != "")
    //    //                            {
    //    //                                DateTime dateAsOnDate;
    //    //                                dateAsOnDate = objCommon.textToDateTime(txtDate.Text.Trim());

    //    //                                if (dateAsOnDate <= dateGetInsudate.Date)
    //    //                                {
    //    //                                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >"  + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + " </td>";
    //    //                                }
    //    //                                else
    //    //                                {
    //    //                                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() +   "  </td>";
    //    //                                }
    //    //                            }
    //    //                        }
    //    //                        else if (dateTdate.Date > dateGetInsudate.Date)
    //    //                        {

    //    //                            strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + " </td>";
    //    //                        }
    //    //                    }
    //    //                    else
    //    //                    {
    //    //                        if (dateTdate.Date <= dateGetInsudate.Date)
    //    //                        {
    //    //                            if (txtDate.Text.ToString() != "")
    //    //                            {
    //    //                                DateTime dateAsOnDate;
    //    //                                dateAsOnDate = objCommon.textToDateTime(txtDate.Text.Trim());

    //    //                                if (dateAsOnDate <= dateGetInsudate.Date)
    //    //                                {
    //    //                                    strHtml += "<td class=\"tdT\" style=\" color:Green;width:14%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >"

    //    //                                        + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() +
    //    //                                        "  </td>";
    //    //                                }
    //    //                                else
    //    //                                {
    //    //                                    strHtml += "<td class=\"tdT\" style=\" color:#6a00b4;width:14%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >"

    //    //                                       + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() +
    //    //                                       "  </td>";
    //    //                                }
    //    //                            }
    //    //                        }
    //    //                        else if (dateTdate.Date > dateGetInsudate.Date)
    //    //                        {

    //    //                            strHtml += "<td class=\"tdT\" style=\" color:Red;width:14%;word-break: break-all; word-wrap:break-word; cursor:pointer; text-align: center;\"  >"

    //    //                                + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() +
    //    //                                " </td>";
    //    //                        }
    //    //                    }
    //    //                }
    //    //            }
    //    //            else if (intColumnBodyCount == 5)
    //    //            {
    //    //                string InsrAmnt = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
    //    //                objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
    //    //                string commaInsrAmnt = objBusinessLayer.AddCommasForNumberSeperation(InsrAmnt, objEntityCommon);
    //    //                if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "0")
    //    //                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + commaInsrAmnt + "</td>";
    //    //                else
    //    //                {
    //    //                    //string strHref="gen_Lead_Summary_Popup.aspx?Id=" + dt.Rows[intRowBodyCount][3].ToString() ;
    //    //                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + commaInsrAmnt + "</td>";
    //    //                }
    //    //            }




    //    //        }
    //    //        strHtml += "</tr>";
    //    //    }
    //    //}


    //    //strHtml += "</tbody>";

    //    //strHtml += "</table>";

    //    //sb.Append(strHtml);
    //    //return sb.ToString();

    //}
    

}