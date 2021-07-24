using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Collections;

public partial class HCM_HCM_Master_hcm_Food_and_Beverages_hcm_Mess_Bill_Calculation_hcm_Mess_Bill_Calculation : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //filter
            DivisionLoad();
            PaygradeLoad();
            DepartmentLoad();
            DesignationLoad();
            CountryLoad();
            projectLoad();
            ReligionLoad();
            //filter



            ddlAccomo.Focus();
            Accomodation_Load();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                hiddenUserId.Value = Session["USERID"].ToString();

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }


            if (Session["CORPOFFICEID"] != null)
            {

                hiddenCorporateId.Value = Session["CORPOFFICEID"].ToString();


            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                hiddenOrganisationId.Value = Session["ORGID"].ToString();
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            clsBusinessLayer objBusiness = new clsBusinessLayer();

            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                            clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, Convert.ToInt32(Session["CORPOFFICEID"]));
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenCurencyMode.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDecimalCountCommon.Value = dtCorpDetail.Rows[0]["GN_UNIT_DECIMAL_CNT"].ToString();
                
            }

            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                hiddenEditMode.Value = "1";

                Update(strId);
                lblEntry.Text = "Edit Mess Bill";
                HiddenFieldAddMode.Value = "0";
                ddlAccomo.Enabled = false;
            }
            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                hiddenViewMode.Value = "1";
                View(strId);
                lblEntry.Text = "View Mess Bill";
                HiddenFieldAddMode.Value = "0";
            }
            else
            {
                HiddenFieldAddMode.Value = "1";
                divPrint.Visible = false;
                lblEntry.Text = "Add Mess Bill";
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnConfirm.Visible = false;
                btnConfirmClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
                if (Request.QueryString["InsUpd"] != null)
                {
                    string strInsUpd = Request.QueryString["InsUpd"].ToString();
                    if (strInsUpd == "Ins")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                    }
                    else if (strInsUpd == "Upd")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                    }
                    else if (strInsUpd == "Dup")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "MessDuplication", "MessDuplication();", true);
                    }  
                    else if (strInsUpd == "Conf")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "MessConfirmation", "MessConfirmation();", true);
                    }

                }
            }

        }
    }



    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strC_Id)
    {
        cls_Business_Mess_Bill objBusinessLayerMessBill = new cls_Business_Mess_Bill();
        clsEntity_Mess_Bill objEntityMessBill = new clsEntity_Mess_Bill();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityMessBill.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityMessBill.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (strC_Id != "")
        {
            int intDecimalCount = Convert.ToInt32(hiddenDecimalCount.Value);

            objEntityMessBill.MessBillId = Convert.ToInt32(strC_Id);
            hiddenMessBillId.Value = strC_Id;
            DataTable dtMessBill = new DataTable();
            dtMessBill = objBusinessLayerMessBill.ReadMessBillData_ById(objEntityMessBill);
            if (dtMessBill.Rows.Count > 0)
            {
                if (dtMessBill.Rows[0]["ACCMDTN_STATUS"].ToString() == "1")
                {
                    ddlAccomo.Items.FindByValue(dtMessBill.Rows[0]["ACCMDTN_ID"].ToString()).Selected = true;
                }
                else
                {

                    ListItem lst = new ListItem(dtMessBill.Rows[0]["ACCMDTN_NAME"].ToString(), dtMessBill.Rows[0]["ACCMDTN_ID"].ToString());
                    ddlAccomo.Items.Insert(1, lst);
                    SortDDL(ref this.ddlAccomo);
                    ddlAccomo.ClearSelection();
                    ddlAccomo.Items.FindByValue(dtMessBill.Rows[0]["ACCMDTN_ID"].ToString()).Selected = true;
                }



                txtTotalAmount.Text = dtMessBill.Rows[0]["MESSBILL_AMOUNT"].ToString();
                hiddenCurrentAmt.Value = dtMessBill.Rows[0]["MESSBILL_AMOUNT"].ToString();

                txtFromDate.Text = dtMessBill.Rows[0]["MESSBILL_FROM"].ToString();
                txtToDate.Text = dtMessBill.Rows[0]["MESSBILL_TO"].ToString();
            }


            btnAdd.Visible = false;
            btnAddClose.Visible = false;
            btnUpdate.Visible = true;
            btnUpdateClose.Visible = true;
            btnConfirm.Visible = true;
            btnConfirmClose.Visible = true;
            LoadTable(objEntityMessBill, 0);
        }
    }
    //Fetch the new datatable from businesslayer and set separately in each field. 
    public void View(string strC_Id)
    {
        cls_Business_Mess_Bill objBusinessLayerMessBill = new cls_Business_Mess_Bill();
        clsEntity_Mess_Bill objEntityMessBill = new clsEntity_Mess_Bill();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityMessBill.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityMessBill.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (strC_Id != "")
        {

            objEntityMessBill.MessBillId = Convert.ToInt32(strC_Id);
            DataTable dtMessBill = new DataTable();
            dtMessBill = objBusinessLayerMessBill.ReadMessBillData_ById(objEntityMessBill);

            if (dtMessBill.Rows.Count > 0)
            {
                if (dtMessBill.Rows[0]["ACCMDTN_STATUS"].ToString() == "1")
                {
                    ddlAccomo.Items.FindByValue(dtMessBill.Rows[0]["ACCMDTN_ID"].ToString()).Selected = true;
                }
                else
                {

                    ListItem lst = new ListItem(dtMessBill.Rows[0]["ACCMDTN_NAME"].ToString(), dtMessBill.Rows[0]["ACCMDTN_ID"].ToString());
                    ddlAccomo.Items.Insert(1, lst);
                    SortDDL(ref this.ddlAccomo);
                    ddlAccomo.ClearSelection();
                    ddlAccomo.Items.FindByValue(dtMessBill.Rows[0]["ACCMDTN_ID"].ToString()).Selected = true;
                }

                txtTotalAmount.Text = dtMessBill.Rows[0]["MESSBILL_AMOUNT"].ToString();
                txtFromDate.Text = dtMessBill.Rows[0]["MESSBILL_FROM"].ToString();
                txtToDate.Text = dtMessBill.Rows[0]["MESSBILL_TO"].ToString();
            }           
            txtToDate.Enabled = false;
            txtFromDate.Enabled = false;
            txtTotalAmount.Enabled = false;
            ddlAccomo.Enabled = false;
            btnCalculate.Visible = false;
            btnAdd.Visible = false;
            btnAddClose.Visible = false;
            btnUpdate.Visible = false;
            btnUpdateClose.Visible = false;
            btnConfirm.Visible = false;
            btnConfirmClose.Visible = false;
            LoadTable(objEntityMessBill, 1);
            ScriptManager.RegisterStartupScript(this, GetType(), "disabled", "disabled();", true);
        }
    }
    //for loading accomodation drpdown

    public void LoadTable(clsEntity_Mess_Bill objEntityMessBill,int mode)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        objEntityCommon.CurrencyId = Convert.ToInt32(HiddenCurencyMode.Value);
        cls_Business_Mess_Bill objBusinessLayerMessBill = new cls_Business_Mess_Bill();
        DataTable dt = objBusinessLayerMessBill.ReadMessEmpDtl(objEntityMessBill);
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (txtFromDate.Text != "" && txtToDate.Text != "")
        {
            objEntityMessBill.Fromdate = objCommon.textToDateTime(txtFromDate.Text);
            objEntityMessBill.Todate = objCommon.textToDateTime(txtToDate.Text);
        }
        DataTable dtCorp = objBusinessLayerMessBill.ReadCorporateAddress(objEntityMessBill);
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        string strTotalAmount = txtTotalAmount.Text;
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Mess Bill";
        DateTime datetm = DateTime.Now;
        string datFromCap = "";
        if (txtFromDate.Text != "")
        {
            datFromCap = "<B>Date From: </B>" + txtFromDate.Text;
        }
        string datToCap = "";
        if (txtToDate.Text != "")
        {
            datToCap = "<B>Date To: </B>" + txtToDate.Text;
        }
        string strAccoNameCap = "";
        if (ddlAccomo.SelectedItem.Text != "--SELECT ACCOMMODATION--")
        {
            strAccoNameCap = "<B>Accommodation: </B>" + ddlAccomo.SelectedItem.Text;
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
        string strCaptionTabRprtDatefr = "<tr><td class=\"RprtDate\">" + datFromCap + "</td></tr>";
        string strCaptionTabRprtDateto = "<tr><td class=\"RprtDate\">" + datToCap + "</td></tr>";
        string strCaptionTabRprtAcc = "<tr><td class=\"RprtDate\">" + strAccoNameCap + "</td></tr>";
        string strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDatefr + strCaptionTabRprtDateto + strCaptionTabRprtAcc + strCaptionTabTitle + strCaptionTabstop;

        sbCap.Append(strPrintCaptionTable);


        int intTotalEmpCount = dt.Rows.Count;
        int totalDaysOfAllEmployee = 0;

        StringBuilder sb = new StringBuilder();
        //string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        string strHtml = "<table id=\"MessDetailTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        string strHtmlPrint = "<table id=\"PrintTable\" class=\"tab\"  >";
        //add header row
        strHtml += "<thead>";
        strHtmlPrint += "<thead>";

        strHtml += "<tr class=\"main_table_head\">";
        strHtmlPrint += "<tr class=\"top_row\">";

        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: center; word-wrap:break-word;\">Sl#</th>";
        strHtmlPrint += "<th class=\"thT\" style=\"width:5%;text-center: left; word-wrap:break-word;\">Sl#</th>";
        strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">EMPLOYEE CODE</th>";
        strHtmlPrint += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">EMPLOYEE CODE</th>";
        strHtml += "<th class=\"thT\" style=\"width:40%;text-align: left; word-wrap:break-word;\">EMPLOYEE</th>";
        strHtmlPrint += "<th class=\"thT\" style=\"width:50%;text-align: left; word-wrap:break-word;\">EMPLOYEE</th>";

        strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: center; word-wrap:break-word;\">NUMBER OF DAYS</th>";
        strHtmlPrint += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">NUMBER OF DAYS</th>";

        strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: right; word-wrap:break-word;\">AMOUNT</th>";
        strHtmlPrint += "<th class=\"thT\"  style=\"width:15%;text-align: right; word-wrap:break-word;\">AMOUNT</th>";

        strHtml += "</tr>";
        strHtmlPrint += "</tr>";

        strHtml += "</thead>";
        strHtmlPrint += "</thead>";
        //add rows

        strHtml += "<tbody>";
        strHtmlPrint += "<tbody>";
        int slNum = 0;
        if (dt.Rows.Count > 0)
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                slNum++;
                string strNetAmountWithComma = objBusinessLayer.AddCommasForNumberSeperation(dt.Rows[intRowBodyCount]["MESSEMP_AMNT"].ToString(), objEntityCommon);


                strHtml += "<tr id=\"trIdMess_" + intRowBodyCount + "\"  >";
                strHtml += "<td id=\"RowId" + intRowBodyCount + "\" class=\"tdT\" style=\"display:none;\" >"+intRowBodyCount+"</td>";
                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + slNum + " </td>";
                strHtml += "<td id=\"tdEmpCode" + intRowBodyCount + "\" class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + " </td>";
                strHtml += "<td id=\"tdEmpName" + intRowBodyCount + "\" class=\"tdT\" style=\" width:40%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + " </td>";
                strHtml += "<td id=\"tdEmpName" + intRowBodyCount + "\" class=\"tdT\" style=\"display:none;\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + " </td>";


                strHtml += "<td id=\"tdDaysMess" + intRowBodyCount + "\" class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["MESSEMP_DAYS"].ToString() + "</td>";

                string backClr = "";
                if (dt.Rows[intRowBodyCount]["MESSBILL_CHANGE_STS"].ToString() == "1")
                {
                    backClr = "#f3d6d6";
                }
                if (mode == 0)
                {
                    strHtml += "<td id=\"tdAmountMess" + intRowBodyCount + "\" class=\"tdT\" style=\"padding-right: 1%; width:15%;word-break: break-all; word-wrap:break-word;text-align: right;\"  ><input id=\"txtAmntMess" + intRowBodyCount + "\" onkeydown=\"return isNumber(event,'txtAmntMess" + intRowBodyCount + "');\" onchange=\"return ChangeAmntMess(" + intRowBodyCount + ");\" type=\"text\" style=\"background-color:" + backClr + "; text-align: right;\" value=\"" + strNetAmountWithComma + "\"></td>";
                }
                else
                {
                    strHtml += "<td id=\"tdAmountMess" + intRowBodyCount + "\" class=\"tdT\" style=\"padding-right: 1%; width:15%;word-break: break-all;background-color:" + backClr + "; word-wrap:break-word;text-align: right;\"  >" + strNetAmountWithComma + "</td>";
                }
                strHtml += "<td id=\"tdAmntOldMess" + intRowBodyCount + "\"class=\"tdT\" style=\"display:none\" >" + strNetAmountWithComma + "</td>";
                strHtml += "<td id=\"tdAmntChangeStsMess" + intRowBodyCount + "\"class=\"tdT\" style=\"display:none\" >" + dt.Rows[intRowBodyCount]["MESSBILL_CHANGE_STS"].ToString() + "</td>";
                strHtml += "<td id=\"tdEmpidMess" + intRowBodyCount + "\"class=\"tdT\" style=\" display:none\" >" + dt.Rows[intRowBodyCount]["USR_ID"].ToString() + " </td>";
                strHtml += "<td id=\"tdEmpDetlidMess" + intRowBodyCount + "\"class=\"tdT\" style=\" display:none\" >" + dt.Rows[intRowBodyCount]["USR_ID"].ToString() + " </td>";
                strHtml += "<td id=\"tdEmpCode" + intRowBodyCount + "\"class=\"tdT\" style=\" display:none\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + " </td>";
                strHtml += "</tr>";


                strHtmlPrint += "<tr  >";
                strHtmlPrint += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + slNum + "</td>";
                strHtmlPrint += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</td>";
                strHtmlPrint += "<td class=\"tdT\" style=\" width:50%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + "</td>";
                strHtmlPrint += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["MESSEMP_DAYS"].ToString() + "</td>";
                strHtmlPrint += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strNetAmountWithComma + "</td>";
                strHtmlPrint += "</tr>";

            }
            strHtmlPrint += "<tr style='font-size: 14px;height: 28px;'>";
            strHtmlPrint += "<td class=\"tdT\" colspan='3' style=\" width:100%;word-break: break-all; word-wrap:break-word;text-align: right;\" ><strong style='margin-right: 6px;'>Total</strong></td>";
            strHtmlPrint += "<td class=\"tdT\" style=\" width:100%;word-break: break-all; word-wrap:break-word;text-align: right;\" ><strong>" + strTotalAmount + "</strong></td>";
            strHtmlPrint += "</tr>";
        }
       

        strHtml += "</tbody>";
        strHtmlPrint += "</tbody>";

        strHtml += "</table>";
        strHtmlPrint += "</table>";

        sb.Append(strHtml);


        divMessDetail.InnerHtml = sb.ToString();
        divPrintReport.InnerHtml = strHtmlPrint;
        divPrintCaption.InnerHtml = sbCap.ToString();

       
    }
    public void Accomodation_Load()
    {
        cls_Business_Mess_Bill objBusinessLayerMessBill = new cls_Business_Mess_Bill();
        clsEntity_Mess_Bill objEntityMessBill = new clsEntity_Mess_Bill();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityMessBill.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityMessBill.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityMessBill.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtAcco = objBusinessLayerMessBill.ReadAccomodation(objEntityMessBill);
        if (dtAcco.Rows.Count > 0)
        {
            ddlAccomo.DataSource = dtAcco;
            ddlAccomo.DataTextField = "ACCMDTN_NAME";
            ddlAccomo.DataValueField = "ACCMDTN_ID";
            ddlAccomo.DataBind();

        }

        ddlAccomo.Items.Insert(0, "--SELECT ACCOMMODATION--");

    }

    [WebMethod]
    //It build the Html table by using the datatable provided
    public static string[] ConvertDataTableToHTML(string intCorpId, string intOrgId, string intAccoId, string strAccoName, string datFrom, string datTo, string strTotalAmount, string strDecimalCnt,string EmpIdsAsJson)
    {

        cls_Business_Mess_Bill objBusinessLayerMessBill = new cls_Business_Mess_Bill();
        clsEntity_Mess_Bill objEntityMessBill = new clsEntity_Mess_Bill();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        objEntityMessBill.CorpOffice_Id = Convert.ToInt32(intCorpId);
        objEntityMessBill.Organisation_Id = Convert.ToInt32(intOrgId);
        if (datFrom != "" && datTo != "")
        {
            objEntityMessBill.Fromdate = objCommon.textToDateTime(datFrom);
            objEntityMessBill.Todate = objCommon.textToDateTime(datTo);
        }
        DataTable dtCorp = objBusinessLayerMessBill.ReadCorporateAddress(objEntityMessBill);
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Mess Bill";
        DateTime datetm = DateTime.Now;
        string datFromCap = "";
        if (datFrom.ToString() != "")
        {
            datFromCap = "<B>Date From: </B>" + datFrom.ToString();
        }
        string datToCap = "";
        if (datTo.ToString() != "")
        {
            datToCap = "<B>Date To: </B>" + datTo.ToString();
        }
        string strAccoNameCap = "";
        if (strAccoName != "--SELECT ACCOMMODATION--")
        {
            strAccoNameCap = "<B>Accommodation: </B>" + strAccoName;
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
        string strCaptionTabRprtDatefr = "<tr><td class=\"RprtDate\">" + datFromCap + "</td></tr>";
        string strCaptionTabRprtDateto = "<tr><td class=\"RprtDate\">" + datToCap + "</td></tr>";
        string strCaptionTabRprtAcc = "<tr><td class=\"RprtDate\">" + strAccoNameCap + "</td></tr>";
        string strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDatefr + strCaptionTabRprtDateto + strCaptionTabRprtAcc + strCaptionTabTitle + strCaptionTabstop;

        sbCap.Append(strPrintCaptionTable);


        int DecimalCnt = Convert.ToInt32(strDecimalCnt);

        double intTotalAmount = 0;
        if (strTotalAmount != "")
        {
            intTotalAmount = Convert.ToDouble(strTotalAmount);
        }
        string[] StrDataPassing = new string[10];

        objEntityMessBill.CorpOffice_Id = Convert.ToInt32(intCorpId);
        objEntityMessBill.Organisation_Id = Convert.ToInt32(intOrgId);

        if (intAccoId != "--SELECT ACCOMMODATION--")
        {
            objEntityMessBill.AccomoDationId = Convert.ToInt32(intAccoId);
        }
        DataTable dt = new DataTable();
        if (datFrom != "" && datTo != "")
        {
            dt = objBusinessLayerMessBill.ReadEmployee_ByAccoId(objEntityMessBill);
        }



        int intTotalEmpCount = dt.Rows.Count;
        int totalDaysOfAllEmployee = 0;
        if (datFrom != "" && datTo != "")
        {
            if (dt.Rows.Count > 0)
            {
                for (int count = 0; count < intTotalEmpCount; count++)
                {
                    objEntityMessBill.EmpId = Convert.ToInt32(dt.Rows[count][0]);
                    objEntityMessBill.Fromdate = objCommon.textToDateTime(datFrom);
                    objEntityMessBill.Todate = objCommon.textToDateTime(datTo);
                    DataTable dtMessCutDetail = objBusinessLayerMessBill.ReadMessExemDataByDate(objEntityMessBill);
                    DataTable dtMessCurrent = objBusinessLayerMessBill.ReadCurrentMess(objEntityMessBill);
                    int intMessCutCount = 0;
                    int intFirstBackUp = 0;

                    string strFromDate = "";
                    int inttotaldays = 0;
                    TimeSpan Backup_difference;

                    DataTable dtBackupDetail = objBusinessLayerMessBill.ReadMessBackup(objEntityMessBill);
                    if (dtBackupDetail.Rows.Count > 0)
                    {

                        DateTime dtStartBackFrom = new DateTime();
                        DateTime dtStartBackFromPrv = new DateTime();
                        DateTime CurrentMessStartDate = new DateTime();
                        for (int i = 0; i < dtBackupDetail.Rows.Count; i++)
                        {

                            if (dtBackupDetail.Rows[i]["MESS_FROMDATE"].ToString() != "")
                            {
                                if (strFromDate == "")
                                {
                                    strFromDate = dtBackupDetail.Rows[i]["MESS_FROMDATE"].ToString();
                                }
                                else
                                {
                                    strFromDate = strFromDate + "," + dtBackupDetail.Rows[i]["MESS_FROMDATE"].ToString();
                                }
                            }
                        }
                        string[] strFromDateSplit = strFromDate.Split(',');
                        for (int i = strFromDateSplit.Length; i > 1; i--)
                        {
                            if (strFromDateSplit[i - 1] != "")
                            {
                                dtStartBackFrom = objCommon.textToDateTime(strFromDateSplit[i - 1]);
                            }
                            if (strFromDateSplit[i - 2] != "")
                            {
                                dtStartBackFromPrv = objCommon.textToDateTime(strFromDateSplit[i - 2]);
                            }
                            if (intFirstBackUp == 0)
                            {
                                intFirstBackUp++;
                                if (strFromDateSplit[0] != "")
                                {
                                    if (dtMessCurrent.Rows.Count > 0)
                                    {
                                        CurrentMessStartDate = objCommon.textToDateTime(dtMessCurrent.Rows[0]["MESS_DATE_FROM"].ToString());
                                        Backup_difference = CurrentMessStartDate - objCommon.textToDateTime(strFromDateSplit[0]);
                                        inttotaldays = inttotaldays + Convert.ToInt32(Backup_difference.TotalDays);
                                    }
                                }
                            }
                            Backup_difference = dtStartBackFrom - dtStartBackFromPrv;
                            inttotaldays = inttotaldays + Convert.ToInt32(Backup_difference.TotalDays);
                        }
                    }




                    if (dtMessCutDetail.Rows.Count > 0)
                    {
                        foreach (DataRow dtRow in dtMessCutDetail.Rows)
                        {
                            DateTime StartCutDate = objCommon.textToDateTime(dtRow["MESSEXPT_FROM"].ToString());
                            DateTime endCutDtae = objCommon.textToDateTime(dtRow["MESSEXPT_TO"].ToString());
                            for (DateTime day = StartCutDate; day <= endCutDtae; day = day.AddDays(1))
                            {
                                if (day >= objEntityMessBill.Fromdate && day <= objEntityMessBill.Todate)
                                {
                                    //  DataTable dtBackDetail = objBusinessLayerMessBill.ReadMessBackup(objEntityMessBill);
                                    //if (dtBackDetail.Rows.Count > 0)
                                    //{
                                       
                                    //}
                                    //else 
                                        if (dtMessCurrent.Rows.Count > 0)
                                    {
                                        //evm-0023
                                        DateTime StartCurrDate = objCommon.textToDateTime(dtMessCurrent.Rows[0]["MESS_DATE_FROM"].ToString());
                                        DateTime endCurrDate = new DateTime();

                                        if (dtMessCurrent.Rows[0]["MESS_DATE_TO"].ToString() != "")
                                        {
                                            endCurrDate = objCommon.textToDateTime(dtMessCurrent.Rows[0]["MESS_DATE_TO"].ToString());
                                        }
                                        //evm-0023
                                        else
                                        {
                                            endCurrDate = objCommon.textToDateTime(datTo);
                                        }
                                        if (day >= StartCurrDate && day <= endCurrDate)
                                        {
                                            intMessCutCount = intMessCutCount + 1;
                                        }
                                    }
                                }
                            }

                            if (endCutDtae < objCommon.textToDateTime(datTo))
                            {
                                break;
                            }

                        }
                    }

                    int MessNotInThis = 0;


                    for (DateTime day = objEntityMessBill.Fromdate; day <= objEntityMessBill.Todate; day = day.AddDays(1))
                    {
                        objEntityMessBill.Fromdate = day;
                        DataTable dtBackDetail = objBusinessLayerMessBill.ReadMessBackup(objEntityMessBill);
             
                        //if (dtBackDetail.Rows.Count > 0)
                        //{
                        //}
                        //else 
                            if (dtMessCurrent.Rows.Count > 0)
                        {
                            //evm-0023
                            DateTime StartCurrDate = objCommon.textToDateTime(dtMessCurrent.Rows[0]["MESS_DATE_FROM"].ToString());
                            DateTime endCurrDate = new DateTime();

                            if (dtMessCurrent.Rows[0]["MESS_DATE_TO"].ToString() != "")
                            {
                                endCurrDate = objCommon.textToDateTime(dtMessCurrent.Rows[0]["MESS_DATE_TO"].ToString());
                            }
                            //evm-0023
                            else
                            {
                                endCurrDate = objCommon.textToDateTime(datTo);
                            }

                            if (dtMessCurrent.Rows[0]["MESS_ACCMDTN_ID"].ToString() == objEntityMessBill.AccomoDationId.ToString())
                            {
                                if (day >= StartCurrDate && day <= endCurrDate)
                                {
                                    
                                }
                                else
                                {
                                    MessNotInThis = MessNotInThis + 1;
                                }
                                //if (day == endCurrDate)
                                //{
                                //    break;
                                //}
                            }
                            else
                            {
                                MessNotInThis = MessNotInThis + 1;
                            }
                        }
                        else
                        {
                            MessNotInThis = MessNotInThis + 1;
                        }
                    }

                    int intRemainingDays = 0;
                    DateTime StartDate = objCommon.textToDateTime(datFrom);
                    DateTime endDtae = objCommon.textToDateTime(datTo);

                    TimeSpan difference = endDtae - StartDate;
                    string totaldays = difference.TotalDays.ToString();
                    intMessCutCount = Convert.ToInt32(intMessCutCount) + MessNotInThis;
                    if (Convert.ToInt32(intMessCutCount) <= (Convert.ToInt32(totaldays) + 1))
                    {
                        intRemainingDays = (Convert.ToInt32(totaldays) + 1) - Convert.ToInt32(intMessCutCount);
                    }
                    else
                    {
                        intRemainingDays = Convert.ToInt32(intMessCutCount) - (Convert.ToInt32(totaldays) + 1);
                    }
                    intRemainingDays += inttotaldays;
                    totalDaysOfAllEmployee = totalDaysOfAllEmployee + Convert.ToInt32(intRemainingDays);
                }
            }
        }
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";

        string strHtmlPrint = "<table id=\"PrintTable\" class=\"tab\"  >";
        //add header row
        strHtml += "<thead>";
        strHtmlPrint += "<thead>";

        strHtml += "<tr class=\"main_table_head\">";
        strHtmlPrint += "<tr class=\"top_row\">";

        strHtml += "<th class=\"thT\" style=\"width:60%;text-align: left; word-wrap:break-word;\">EMPLOYEE</th>";
        strHtmlPrint += "<th class=\"thT\" style=\"width:60%;text-align: left; word-wrap:break-word;\">EMPLOYEE</th>";

        strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: center; word-wrap:break-word;\">NUMBER OF DAYS</th>";
        strHtmlPrint += "<th class=\"thT\"  style=\"width:20%;text-align: center; word-wrap:break-word;\">NUMBER OF DAYS</th>";

        strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: right; word-wrap:break-word;\">AMOUNT</th>";
        strHtmlPrint += "<th class=\"thT\"  style=\"width:20%;text-align: right; word-wrap:break-word;\">AMOUNT</th>";

        strHtml += "</tr>";
        strHtmlPrint += "</tr>";

        strHtml += "</thead>";
        strHtmlPrint += "</thead>";
        //add rows

        strHtml += "<tbody>";
        strHtmlPrint += "<tbody>";
        decimal tot = 0;


        if (dt.Rows.Count > 0)
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {

                strHtml += "<tr id=\"trId_" + intRowBodyCount + " \"  >";
                strHtmlPrint += "<tr  >";

                strHtml += "<td class=\"tdT\" style=\" width:60%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][1].ToString() + " </td>";
                strHtml += "<td id=\"tdEmpName_" + intRowBodyCount + " \" class=\"tdT\" style=\"display:none;\" >" + dt.Rows[intRowBodyCount][1].ToString() + " </td>";
                strHtmlPrint += "<td class=\"tdT\" style=\" width:60%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][1].ToString() + " </td>";
                objEntityMessBill.EmpId = Convert.ToInt32(dt.Rows[intRowBodyCount][0]);
                if (datFrom != "" && datTo != "")
                {
                    objEntityMessBill.Fromdate = objCommon.textToDateTime(datFrom);
                    objEntityMessBill.Todate = objCommon.textToDateTime(datTo);
                    DataTable dtMessCutDetail = objBusinessLayerMessBill.ReadMessExemDataByDate(objEntityMessBill);
                    DataTable dtMessCurrent = objBusinessLayerMessBill.ReadCurrentMess(objEntityMessBill);
                    int intMessCutCount = 0;
                    int intFirstBackUp = 0;

                    string strFromDate = "";
                    int inttotaldays = 0;
                    TimeSpan Backup_difference;

                    DataTable dtBackupDetail = objBusinessLayerMessBill.ReadMessBackup(objEntityMessBill);
                    if (dtBackupDetail.Rows.Count > 0)
                    {

                        DateTime dtStartBackFrom = new DateTime();
                        DateTime dtStartBackFromPrv = new DateTime();
                        DateTime CurrentMessStartDate = new DateTime();
                        for (int i = 0; i < dtBackupDetail.Rows.Count; i++)
                        {

                            if (dtBackupDetail.Rows[i]["MESS_FROMDATE"].ToString() != "")
                            {
                                if (strFromDate == "")
                                {
                                    strFromDate = dtBackupDetail.Rows[i]["MESS_FROMDATE"].ToString();
                                }
                                else
                                {
                                    strFromDate = strFromDate + "," + dtBackupDetail.Rows[i]["MESS_FROMDATE"].ToString();
                                }
                            }
                        }
                        string[] strFromDateSplit = strFromDate.Split(',');
                        for (int i = strFromDateSplit.Length; i > 1; i--)
                        {
                            if (strFromDateSplit[i - 1] != "")
                            {
                                dtStartBackFrom = objCommon.textToDateTime(strFromDateSplit[i - 1]);
                            }
                            if (strFromDateSplit[i - 2] != "")
                            {
                                dtStartBackFromPrv = objCommon.textToDateTime(strFromDateSplit[i - 2]);
                            }
                            if (intFirstBackUp == 0)
                            {
                                intFirstBackUp++;
                                if (strFromDateSplit[0] != "")
                                {
                                    if (dtMessCurrent.Rows.Count > 0)
                                    {
                                        CurrentMessStartDate = objCommon.textToDateTime(dtMessCurrent.Rows[0]["MESS_DATE_FROM"].ToString());
                                        Backup_difference = CurrentMessStartDate - objCommon.textToDateTime(strFromDateSplit[0]);
                                        inttotaldays = inttotaldays + Convert.ToInt32(Backup_difference.TotalDays);
                                    }
                                }
                            }
                            Backup_difference = dtStartBackFrom - dtStartBackFromPrv;
                            inttotaldays = inttotaldays + Convert.ToInt32(Backup_difference.TotalDays);
                        }
                    }
                    if (dtMessCutDetail.Rows.Count > 0)
                    {

                        foreach (DataRow dtRow in dtMessCutDetail.Rows)
                        {
                            DateTime StartCutDate = objCommon.textToDateTime(dtRow["MESSEXPT_FROM"].ToString());
                            DateTime endCutDtae = objCommon.textToDateTime(dtRow["MESSEXPT_TO"].ToString());
                            for (DateTime day = StartCutDate; day <= endCutDtae; day = day.AddDays(1))
                            {
                                if (day >= objCommon.textToDateTime(datFrom) && day <= objCommon.textToDateTime(datTo))
                                {
                                   // objEntityMessBill.Fromdate = day;
                                    //DataTable dtBackDetail = objBusinessLayerMessBill.ReadMessBackup(objEntityMessBill);
                                    //if (dtBackDetail.Rows.Count > 0)
                                    //{
                                        
                                        
                                    //}
                                     if (dtMessCurrent.Rows.Count > 0)
                                    {

                                        //evm-0023
                                        DateTime StartCurrDate = objCommon.textToDateTime(dtMessCurrent.Rows[0]["MESS_DATE_FROM"].ToString());
                                        DateTime endCurrDate = new DateTime();

                                        if (dtMessCurrent.Rows[0]["MESS_DATE_TO"].ToString() != "")
                                        {
                                            endCurrDate = objCommon.textToDateTime(dtMessCurrent.Rows[0]["MESS_DATE_TO"].ToString());
                                        }
                                        //evm-0023
                                        else
                                        {
                                            endCurrDate = objCommon.textToDateTime(datTo);
                                        }
                                        if (day >= StartCurrDate && day <= endCurrDate)
                                        {
                                            intMessCutCount = intMessCutCount + 1;

                                        }
                                    }
                                }

                            }
                            if (endCutDtae < objCommon.textToDateTime(datTo))
                            {
                                break;
                            }

                        }

                    }

                    int MessNotInThis = 0;
                    for (DateTime day = objEntityMessBill.Fromdate; day <= objEntityMessBill.Todate; day = day.AddDays(1))
                    {
                        objEntityMessBill.Fromdate = day;
                        //DataTable dtBackDetail = objBusinessLayerMessBill.ReadMessBackup(objEntityMessBill);
                        //if (dtBackDetail.Rows.Count > 0)
                        //{

                        //}
                        //else 
                            if (dtMessCurrent.Rows.Count > 0)
                        {

                            //evm-0023
                            DateTime StartCurrDate = objCommon.textToDateTime(dtMessCurrent.Rows[0]["MESS_DATE_FROM"].ToString());
                            DateTime endCurrDate = new DateTime();

                            if (dtMessCurrent.Rows[0]["MESS_DATE_TO"].ToString() != "")
                            {
                                endCurrDate = objCommon.textToDateTime(dtMessCurrent.Rows[0]["MESS_DATE_TO"].ToString());
                            }
                            //evm-0023
                            else
                            {
                                endCurrDate = objCommon.textToDateTime(datTo);
                            }


                            //DateTime StartCurrDate = objCommon.textToDateTime(dtMessCurrent.Rows[0]["MESS_DATE_FROM"].ToString());
                            //DateTime endCurrDate = objCommon.textToDateTime(dtMessCurrent.Rows[0]["MESS_DATE_TO"].ToString());
                            if (dtMessCurrent.Rows[0]["MESS_ACCMDTN_ID"].ToString() == objEntityMessBill.AccomoDationId.ToString())
                            {
                                if (day >= StartCurrDate && day <= endCurrDate)
                                {
                                    
                                }
                                else
                                {
                                    MessNotInThis = MessNotInThis + 1;
                                }
                                //if (day == endCurrDate)
                                //{
                                //    break;
                                //}
                            }
                            else
                            {
                                MessNotInThis = MessNotInThis + 1;
                            }
                        }
                        else
                        {
                            MessNotInThis = MessNotInThis + 1;
                        }
                    }



                    int intRemainingDays = 0;
                    DateTime StartDate = objCommon.textToDateTime(datFrom);
                    DateTime endDtae = objCommon.textToDateTime(datTo);

                    TimeSpan difference = endDtae - StartDate;
                    string totaldays = difference.TotalDays.ToString();
                    intMessCutCount = intMessCutCount + Convert.ToInt32(MessNotInThis);
                   
                    //cmd-evm-0023
                    if (Convert.ToInt32(intMessCutCount) <= (Convert.ToInt32(totaldays) + 1))
                    {
                        intRemainingDays = (Convert.ToInt32(totaldays) + 1) - Convert.ToInt32(intMessCutCount);
                    }
                    else
                    {
                        intRemainingDays = Convert.ToInt32(intMessCutCount) - (Convert.ToInt32(totaldays) + 1);
                    }                    
                    intRemainingDays += inttotaldays;
                  


                   // intRemainingDays = Convert.ToInt32((objCommon.textToDateTime(datTo) - objCommon.textToDateTime(datFrom)).TotalDays)+1;

                    double intFinalAmount = 0;

                    string strFinalAmount = "";
                    string strNetAmountWithComma = "0.00";

                    if (intRemainingDays > 0)
                    {
                        //int intFinalAmount = (intTotalAmount / (Convert.ToInt32(totaldays) * intTotalEmpCount)) * intRemainingDays;
                        double TotalByTotalDay = Convert.ToDouble(intTotalAmount) / Convert.ToDouble(totalDaysOfAllEmployee);

                        intFinalAmount = Convert.ToDouble(TotalByTotalDay) * Convert.ToDouble(intRemainingDays);

                        strFinalAmount = Math.Round(intFinalAmount, DecimalCnt).ToString();

                        clsEntityCommon objEntityCommon = new clsEntityCommon();
                        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

                        tot += Convert.ToDecimal(strFinalAmount);
                        if (intRowBodyCount == dt.Rows.Count - 1)
                        {                         
                            decimal lastAmnt = Convert.ToDecimal(intTotalAmount) - tot;
                            strFinalAmount = Convert.ToString(lastAmnt + Convert.ToDecimal(strFinalAmount));
                        }


                        if (strFinalAmount.Contains("."))
                        {
                            string[] a = strFinalAmount.Split(new char[] { '.' });
                            int decimals = a[1].Length;
                            if (decimals < DecimalCnt)
                            {
                                string strDecimal = strFinalAmount + "0";
                                if (intFinalAmount > 0)
                                {
                                    strNetAmountWithComma = objBusinessLayer.AddCommasForNumberSeperation(strDecimal, objEntityCommon);
                                }
                            }
                            else
                            {
                                if (intFinalAmount > 0)
                                {
                                    strNetAmountWithComma = objBusinessLayer.AddCommasForNumberSeperation(strFinalAmount, objEntityCommon);
                                }
                            }
                        }
                        else
                        {
                            string strDecimal = strFinalAmount + ".00";
                            if (intFinalAmount > 0)
                            {
                                strNetAmountWithComma = objBusinessLayer.AddCommasForNumberSeperation(strDecimal, objEntityCommon);
                            }
                        }
                    }
                    else
                    {
                        intRemainingDays = 0;
                    }


                    strHtml += "<td id=\"tdRemain_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + intRemainingDays + "</td>";
                    strHtmlPrint += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + intRemainingDays + "</td>";


                    strHtml += "<td id=\"tdAmount_" + intRowBodyCount + " \" class=\"tdT\" style=\"padding-right: 1%; width:20%;word-break: break-all; word-wrap:break-word;text-align: right;\"  ><input id=\"txtAmnt_" + intRowBodyCount + "\" onkeydown=\"return isNumber(event,'txtAmnt_"+intRowBodyCount+"');\" onchange=\"return ChangeAmnt(" + intRowBodyCount + ");\" type=\"text\" style=\"text-align: right;\" value=\"" + strNetAmountWithComma + "\"></td>";
                    strHtmlPrint += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + strNetAmountWithComma + "</td>";

                    strHtml += "<td id=\"tdAmntOld_" + intRowBodyCount + "\"class=\"tdT\" style=\" display:none\" >" + strNetAmountWithComma + "</td>";
                    strHtml += "<td id=\"tdAmntChangeSts_" + intRowBodyCount + "\"class=\"tdT\" style=\" display:none\" >0</td>";
                    strHtml += "<td id=\"tdEmpid_" + intRowBodyCount + " \"class=\"tdT\" style=\" display:none\" >" + dt.Rows[intRowBodyCount][0].ToString() + " </td>";
                    strHtml += "<td id=\"tdEmpDetlid_" + intRowBodyCount + " \"class=\"tdT\" style=\" display:none\" >" + dt.Rows[intRowBodyCount][0].ToString() + " </td>";
                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" ></td>";
                    strHtmlPrint += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" ></td>";

                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\"  ></td>";
                    strHtmlPrint += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\"  ></td>";

                }
                strHtml += "</tr>";
                strHtmlPrint += "</tr>";
            }
        }
        else
        {
            strHtml += "<tr id=\"trIdNo \"  >";
            strHtml += "<td class=\"tdT\" style=\" width:60%;word-break: break-all; word-wrap:break-word;text-align: center;border-right: none;\" >No Data Available</td>";
            strHtmlPrint += "<td class=\"tdT\" style=\" width:60%;word-break: break-all; word-wrap:break-word;text-align: center;border-right: none;\" >No Data Available</td>";

            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;border-right: none;\"  ></td>";
            strHtmlPrint += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;border-right: none;\"  ></td>";

            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;border-right: none;\" ></td>";
            strHtmlPrint += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;border-right: none;\" ></td>";
            strHtml += "</tr>";
        }

        strHtml += "</tbody>";
        strHtmlPrint += "</tbody>";

        strHtml += "</table>";
        strHtmlPrint += "</table>";

        sb.Append(strHtml);

        //if (dt.Rows.Count > 0)
        //{
        //    StrDataPassing[4] = "TRUE";
        //}
        //else
        //{
        //    StrDataPassing[4] = "FALSE";
        //}


        //evm-0023
        if (dt.Rows.Count <= 0)
        {
            if (datFrom == "" || datTo == "")
            {
                StrDataPassing[4] = "NULLDATE";
            }
            else
            {
                StrDataPassing[4] = "FALSE";
            }
        }
        else
        {
            StrDataPassing[4] = "TRUE";
        }

        StrDataPassing[0] = sb.ToString();
        StrDataPassing[1] = dt.Rows.Count.ToString();
        StrDataPassing[2] = strHtmlPrint;
        StrDataPassing[3] = sbCap.ToString();

        return StrDataPassing;
    }




    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        cls_Business_Mess_Bill objBusinessLayerMessBill = new cls_Business_Mess_Bill();
        clsEntity_Mess_Bill objEntityMessBill = new clsEntity_Mess_Bill();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityMessBill.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityMessBill.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityMessBill.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Request.QueryString["Id"] != null)
        {
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntityMessBill.MessBillId = Convert.ToInt32(strId);
        }
        objEntityMessBill.AccomoDationId = Convert.ToInt32(ddlAccomo.SelectedItem.Value);

        objEntityMessBill.Fromdate = objCommon.textToDateTime(txtFromDate.Text.Trim());

        objEntityMessBill.Todate = objCommon.textToDateTime(txtToDate.Text.Trim());

        objEntityMessBill.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text.Trim());

        List<clsEntity_Mess_Bill_EMP_DTLS> objEntityMessEmpDtlList = new List<clsEntity_Mess_Bill_EMP_DTLS>();
        List<clsEntity_Mess_Bill_EMP_DTLS> objEntityMessEmpDtlMnthWiseList = new List<clsEntity_Mess_Bill_EMP_DTLS>();
        string jsonData = hiddenEmpMessDetails.Value;
        string c = jsonData.Replace("\"{", "\\{");
        string d = c.Replace("\\n", "\r\n");
        string g = d.Replace("\\", "");
        string h = g.Replace("}\"]", "}]");
        string i = h.Replace("}\",", "},");
        List<clsWBData> objWBDataList = new List<clsWBData>();
        objWBDataList = JsonConvert.DeserializeObject<List<clsWBData>>(i);

        foreach (clsWBData objclsWBData in objWBDataList)
        {
            clsEntity_Mess_Bill_EMP_DTLS objEntityDetails = new clsEntity_Mess_Bill_EMP_DTLS();

            objEntityDetails.EmpId = Convert.ToInt32(objclsWBData.EmpId);
            objEntityDetails.MessEmpDys = Convert.ToInt32(objclsWBData.NoOfDays);
            objEntityDetails.MessEmpAmt = Convert.ToDecimal(objclsWBData.Ammount);
            objEntityDetails.ChangeSts = Convert.ToInt32(objclsWBData.ChangeSts);
            objEntityMessEmpDtlList.Add(objEntityDetails);
            //Start:-Month wise data
            decimal decOneDay = objEntityDetails.MessEmpAmt / objEntityDetails.MessEmpDys;
            var days = GetNumberOfDays(objEntityMessBill.Fromdate, objEntityMessBill.Todate);
            foreach (var m in days.Keys)
            {
                clsEntity_Mess_Bill_EMP_DTLS objEntityDetailsMonth = new clsEntity_Mess_Bill_EMP_DTLS();
                objEntityDetailsMonth.EmpId = Convert.ToInt32(objclsWBData.EmpId);
                objEntityDetailsMonth.MessMonth = m.Item2;
                objEntityDetailsMonth.MessYear = m.Item1;
                objEntityDetailsMonth.MessEmpDys = days[m];
                objEntityDetailsMonth.MessEmpAmt = objEntityDetailsMonth.MessEmpDys * decOneDay;
                objEntityMessEmpDtlMnthWiseList.Add(objEntityDetailsMonth);
            }
            //End:-Month wise data
        }

        if (clickedButton.ID == "btnUpdate" ||clickedButton.ID == "btnUpdateClose" )
        {
            objEntityMessBill.ConfirmStatus = 0;
        }

        if (clickedButton.ID == "btnConfirm" || clickedButton.ID == "btnConfirmClose")
        {
            objEntityMessBill.ConfirmStatus = 1;
        }

        objBusinessLayerMessBill.UpdateMessBill(objEntityMessBill, objEntityMessEmpDtlList, objEntityMessEmpDtlMnthWiseList);

        if (clickedButton.ID == "btnUpdate")
        {
            Response.Redirect("hcm_Mess_Bill_Calculation.aspx?InsUpd=Upd");
        }
        else if (clickedButton.ID == "btnUpdateClose")
        {
            Response.Redirect("hcm_Mess_Bill_Calculation_List.aspx?InsUpd=Upd");
        }
        else if (clickedButton.ID == "btnConfirm")
        {
            Response.Redirect("hcm_Mess_Bill_Calculation.aspx?InsUpd=Conf");
        }
        else if (clickedButton.ID == "btnConfirmClose")
        {
            Response.Redirect("hcm_Mess_Bill_Calculation_List.aspx?InsUpd=Conf");
        }

        //DataTable dtDup = new DataTable();
        ////objBusinessLayerMessBill.CheckDuplication(objEntityMessBill);
        //string DupChck = "false";
        //if (dtDup.Rows.Count > 0)
        //{

        //    foreach (DataRow dt in dtDup.Rows)
        //    {
        //        if (dt["MESSBILL_ID"].ToString() != objEntityMessBill.MessBillId.ToString())
        //        {
        //            DupChck = "true";
        //        }
        //    }

        //    if (DupChck == "true")
        //    {
        //        ScriptManager.RegisterStartupScript(this, GetType(), "MessDuplication", "MessDuplication();", true);
        //    }
        //    else
        //    {
        //        objBusinessLayerMessBill.UpdateMessBill(objEntityMessBill, objEntityMessEmpDtlList);
        //    }
        //}
        //else
        //{
        //    objBusinessLayerMessBill.UpdateMessBill(objEntityMessBill, objEntityMessEmpDtlList);
        //}

        //if (clickedButton.ID == "btnUpdate")
        //  {
        //        Response.Redirect("hcm_Mess_Bill_Calculation.aspx?InsUpd=Upd");
        //  }
        //else if (clickedButton.ID == "btnUpdateClose")
        //  {
        //        Response.Redirect("hcm_Mess_Bill_Calculation_List.aspx?InsUpd=Upd");
        //  }
        //else if (clickedButton.ID == "btnUpdateClose")
        //{
        //    Response.Redirect("hcm_Mess_Bill_Calculation.aspx?InsUpd=Conf");
        //}
        //else if (clickedButton.ID == "btnUpdateClose")
        //{
        //    Response.Redirect("hcm_Mess_Bill_Calculation_List.aspx?InsUpd=Conf");
        //}

    }

    public class clsWBData
    {
        public string EmpId { get; set; }
        public string NoOfDays { get; set; }
        public string Ammount { get; set; }
        public string ChangeSts { get; set; }

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        cls_Business_Mess_Bill objBusinessLayerMessBill = new cls_Business_Mess_Bill();
        clsEntity_Mess_Bill objEntityMessBill = new clsEntity_Mess_Bill();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityMessBill.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityMessBill.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityMessBill.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        objEntityMessBill.AccomoDationId = Convert.ToInt32(ddlAccomo.SelectedItem.Value);

        objEntityMessBill.Fromdate = objCommon.textToDateTime(txtFromDate.Text.Trim());

        objEntityMessBill.Todate = objCommon.textToDateTime(txtToDate.Text.Trim());

        objEntityMessBill.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text.Trim());

        List<clsEntity_Mess_Bill_EMP_DTLS> objEntityMessEmpDtlList = new List<clsEntity_Mess_Bill_EMP_DTLS>();
        List<clsEntity_Mess_Bill_EMP_DTLS> objEntityMessEmpDtlMnthWiseList = new List<clsEntity_Mess_Bill_EMP_DTLS>();
        string jsonData = hiddenEmpMessDetails.Value;
        string c = jsonData.Replace("\"{", "\\{");
        string d = c.Replace("\\n", "\r\n");
        string g = d.Replace("\\", "");
        string h = g.Replace("}\"]", "}]");
        string i = h.Replace("}\",", "},");
        List<clsWBData> objWBDataList = new List<clsWBData>();
        objWBDataList = JsonConvert.DeserializeObject<List<clsWBData>>(i);

        foreach (clsWBData objclsWBData in objWBDataList)
        {
            clsEntity_Mess_Bill_EMP_DTLS objEntityDetails = new clsEntity_Mess_Bill_EMP_DTLS();
            objEntityDetails.EmpId = Convert.ToInt32(objclsWBData.EmpId);
            objEntityDetails.MessEmpDys = Convert.ToInt32(objclsWBData.NoOfDays);
            objEntityDetails.MessEmpAmt = Convert.ToDecimal(objclsWBData.Ammount);
            objEntityDetails.ChangeSts = Convert.ToInt32(objclsWBData.ChangeSts);
            objEntityMessEmpDtlList.Add(objEntityDetails);
            //Start:-Month wise data
            decimal decOneDay = objEntityDetails.MessEmpAmt / objEntityDetails.MessEmpDys;
            var days = GetNumberOfDays(objEntityMessBill.Fromdate, objEntityMessBill.Todate);
            foreach (var m in days.Keys)
            {
                clsEntity_Mess_Bill_EMP_DTLS objEntityDetailsMonth = new clsEntity_Mess_Bill_EMP_DTLS();
                objEntityDetailsMonth.EmpId = Convert.ToInt32(objclsWBData.EmpId);
                objEntityDetailsMonth.MessMonth = m.Item2;
                objEntityDetailsMonth.MessYear = m.Item1;
                objEntityDetailsMonth.MessEmpDys = days[m];
                objEntityDetailsMonth.MessEmpAmt = objEntityDetailsMonth.MessEmpDys * decOneDay;
                objEntityMessEmpDtlMnthWiseList.Add(objEntityDetailsMonth);
            }
            //End:-Month wise data

        }

        objBusinessLayerMessBill.InsertMessBill(objEntityMessBill, objEntityMessEmpDtlList, objEntityMessEmpDtlMnthWiseList);

        if (clickedButton.ID == "btnAdd")
        {
            Response.Redirect("hcm_Mess_Bill_Calculation.aspx?InsUpd=Ins");
        }
        else
        {
            Response.Redirect("hcm_Mess_Bill_Calculation_List.aspx?InsUpd=Ins");
        }

        //DataTable dt = objBusinessLayerMessBill.ReadEmployee_ByAccoId(objEntityMessBill);
        //if (dt.Rows.Count > 0)
        //{
        //    DataTable dtDup =new DataTable();
        //    //dtDup = objBusinessLayerMessBill.CheckDuplication(objEntityMessBill);
        //    if (dtDup.Rows.Count > 0)
        //    {             
        //        Response.Redirect("hcm_Mess_Bill_Calculation.aspx?InsUpd=Dup");
        //    }
        //    else
        //    {
        //        objBusinessLayerMessBill.InsertMessBill(objEntityMessBill, objEntityMessEmpDtlList);

        //        if (clickedButton.ID == "btnAdd")
        //        {
        //            Response.Redirect("hcm_Mess_Bill_Calculation.aspx?InsUpd=Ins");
        //        }
        //        else
        //        {
        //            Response.Redirect("hcm_Mess_Bill_Calculation_List.aspx?InsUpd=Ins");
        //        }
        //    }
        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "EmployeeSelect", "EmployeeSelect();", true);
        //}
    }
    static Dictionary<Tuple<int, int>, int> GetNumberOfDays(DateTime start, DateTime end)
    {
        // assumes end > start
        Dictionary<Tuple<int, int>, int> ret = new Dictionary<Tuple<int, int>, int>();
        DateTime date = end;
        while (date > start)
        {
            if (date.Year == start.Year && date.Month == start.Month)
            {
                ret.Add(
                    Tuple.Create<int, int>(date.Year, date.Month),
                    (date - start).Days + 1);
                break;
            }
            else
            {
                ret.Add(
                    Tuple.Create<int, int>(date.Year, date.Month),
                    date.Day);
                date = new DateTime(date.Year, date.Month, 1).AddDays(-1);
            }
        }
        return ret;
    }

    public class clsMessData
    {
        public string EMPID { get; set; }
        public string NUMDAYS { get; set; }
        public string AMOUNT { get; set; }

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

    [WebMethod]
    public static string[] getEmployees(string prefix, string orgID, string corpID, string AccomdtnId)
    {
        List<string> employees = new List<string>();
        if (AccomdtnId != "--SELECT ACCOMMODATION--")
        {
            cls_Business_Mess_Bill objBusinessLayerMessBill = new cls_Business_Mess_Bill();
            clsEntity_Mess_Bill objEntityMessBill = new clsEntity_Mess_Bill();
            objEntityMessBill.Organisation_Id = Convert.ToInt32(orgID);
            objEntityMessBill.CorpOffice_Id = Convert.ToInt32(corpID);
            objEntityMessBill.SearchString = prefix;
            objEntityMessBill.AccomoDationId = Convert.ToInt32(AccomdtnId);
            DataTable dtEmp = objBusinessLayerMessBill.ReadEmployees(objEntityMessBill);
            foreach (DataRow r in dtEmp.Rows)
            {
                employees.Add(string.Format("{0}%{1}", r[1], r[0] + "~" + r[2]));
            }
        }
        return employees.ToArray(); ;
    }
    

     [WebMethod]
    public static string CheckEmployeeMessDate(string EmpId, string frmdate, string todate, string validRowID, string MessBillId)
    {
         cls_Business_Mess_Bill objBusinessLayerMessBill = new cls_Business_Mess_Bill();
         clsEntity_Mess_Bill objEntityMessBill = new clsEntity_Mess_Bill();
         clsCommonLibrary objCommon = new clsCommonLibrary();
         string ret = "True";
         objEntityMessBill.EmpId = Convert.ToInt32(EmpId);
         objEntityMessBill.Fromdate = objCommon.textToDateTime(frmdate);
         objEntityMessBill.Todate = objCommon.textToDateTime(todate);

         if (MessBillId == "")
         {
             objEntityMessBill.MessBillId = 0;
         }
         else
         {
             objEntityMessBill.MessBillId = Convert.ToInt32(MessBillId);
         }
         
         DataTable dtCheckEmployeeMessDate = objBusinessLayerMessBill.CheckEmployeeMessDate(objEntityMessBill);
         if (dtCheckEmployeeMessDate.Rows.Count == 0)
         {
             ret = "False";
         }
         
         return ret;
    }



     #region filter

     public void DivisionLoad()
     {
         clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport = new clsEntityEmployeeDetailsReport();
         clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();

         //  clsEntityReports ObjLeadReport = new clsEntityReports();
         if (Session["CORPOFFICEID"] != null)
         {
             objEntityEmployeeDetailsreport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
         }
         else if (Session["CORPOFFICEID"] == null)
         {
             Response.Redirect("~/Default.aspx");
         }
         if (Session["ORGID"] != null)
         {
             objEntityEmployeeDetailsreport.OrganisationId = Convert.ToInt32(Session["ORGID"].ToString());
         }
         else if (Session["ORGID"] == null)
         {
             Response.Redirect("/Default.aspx");
         }
         if (Session["USERID"] != null)
         {
             // intUserId = Convert.ToInt32(Session["USERID"]);
             objEntityEmployeeDetailsreport.UserId = Convert.ToInt32(Session["USERID"]);
         }
         else if (Session["USERID"] == null)
         {
             Response.Redirect("/Default.aspx");
         }
         DataTable dtDivision = objBusinessEmployeeDetailsReport.ReadDivision(objEntityEmployeeDetailsreport);
         if (dtDivision.Rows.Count > 0)
         {
             ddlDivsn.Items.Clear();
             ddlDivsn.DataSource = dtDivision;


             ddlDivsn.DataValueField = "CPRDIV_ID";
             ddlDivsn.DataTextField = "CPRDIV_NAME";



             //ddlProjct.DataValueField = "PROJECT_ID";
             ddlDivsn.DataBind();

         }
         ddlDivsn.Items.Insert(0, "--SELECT--");

     }
     public void CountryLoad()
     {
         clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();
         DataTable dtCountry = objBusinessEmployeeDetailsReport.readCountry();
         if (dtCountry.Rows.Count > 0)
         {
             ddlNation.Items.Clear();
             ddlNation.DataSource = dtCountry;


             ddlNation.DataValueField = "CNTRY_ID";
             ddlNation.DataTextField = "CNTRY_NAME";



             //ddlProjct.DataValueField = "PROJECT_ID";
             ddlNation.DataBind();

         }
         ddlNation.Items.Insert(0, "--SELECT--");
     }
     public void projectLoad()
     {
         clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport = new clsEntityEmployeeDetailsReport();
         clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();

         //  clsEntityReports ObjLeadReport = new clsEntityReports();
         if (Session["CORPOFFICEID"] != null)
         {
             objEntityEmployeeDetailsreport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
         }
         else if (Session["CORPOFFICEID"] == null)
         {
             Response.Redirect("~/Default.aspx");
         }
         if (Session["ORGID"] != null)
         {
             objEntityEmployeeDetailsreport.OrganisationId = Convert.ToInt32(Session["ORGID"].ToString());
         }
         else if (Session["ORGID"] == null)
         {
             Response.Redirect("/Default.aspx");
         }
         if (Session["USERID"] != null)
         {
             // intUserId = Convert.ToInt32(Session["USERID"]);
             objEntityEmployeeDetailsreport.UserId = Convert.ToInt32(Session["USERID"]);
         }
         else if (Session["USERID"] == null)
         {
             Response.Redirect("/Default.aspx");
         }

         int divid = 0;
         objEntityEmployeeDetailsreport.DivisionId = divid;
         DataTable dtProject = objBusinessEmployeeDetailsReport.ReadProject(objEntityEmployeeDetailsreport);
         if (dtProject.Rows.Count > 0)
         {
             ddlPrjct.DataSource = dtProject;


             ddlPrjct.DataValueField = "PROJECT_ID";
             ddlPrjct.DataTextField = "PROJECT_NAME";

             //  ddlprojectassign.DataValueField = "PROJECT_ID";


             //     ddlProjct.DataValueField = "PROJECT_ID";
             ddlPrjct.DataBind();

         }
         //    ddlprojectassign.Items.Insert(0, "--SELECT PROJECT--");
         ddlPrjct.Items.Insert(0, "--SELECT--");


     }

     public void DesignationLoad()
     {
         clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport = new clsEntityEmployeeDetailsReport();
         clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();
         if (Session["CORPOFFICEID"] != null)
         {
             objEntityEmployeeDetailsreport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
         }
         else if (Session["CORPOFFICEID"] == null)
         {
             Response.Redirect("~/Default.aspx");
         }
         if (Session["ORGID"] != null)
         {
             objEntityEmployeeDetailsreport.OrganisationId = Convert.ToInt32(Session["ORGID"].ToString());
         }
         else if (Session["ORGID"] == null)
         {
             Response.Redirect("/Default.aspx");
         }
         if (Session["USERID"] != null)
         {
             // intUserId = Convert.ToInt32(Session["USERID"]);
             objEntityEmployeeDetailsreport.UserId = Convert.ToInt32(Session["USERID"]);
         }
         else if (Session["USERID"] == null)
         {
             Response.Redirect("/Default.aspx");
         }
         DataTable dtdesig = objBusinessEmployeeDetailsReport.ReadDesignation(objEntityEmployeeDetailsreport);
         if (dtdesig.Rows.Count > 0)
         {
             ddlDesgntn.DataSource = dtdesig;


             ddlDesgntn.DataValueField = "DSGN_ID";
             ddlDesgntn.DataTextField = "DSGN_NAME";



             //ddlProjct.DataValueField = "PROJECT_ID";
             ddlDesgntn.DataBind();

         }
         ddlDesgntn.Items.Insert(0, "--SELECT--");

     }

     public void DepartmentLoad()
     {
         clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport = new clsEntityEmployeeDetailsReport();
         clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();
         if (Session["CORPOFFICEID"] != null)
         {
             objEntityEmployeeDetailsreport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
         }
         else if (Session["CORPOFFICEID"] == null)
         {
             Response.Redirect("~/Default.aspx");
         }
         if (Session["ORGID"] != null)
         {
             objEntityEmployeeDetailsreport.OrganisationId = Convert.ToInt32(Session["ORGID"].ToString());
         }
         else if (Session["ORGID"] == null)
         {
             Response.Redirect("/Default.aspx");
         }
         if (Session["USERID"] != null)
         {
             // intUserId = Convert.ToInt32(Session["USERID"]);
             objEntityEmployeeDetailsreport.UserId = Convert.ToInt32(Session["USERID"]);
         }
         else if (Session["USERID"] == null)
         {
             Response.Redirect("/Default.aspx");
         }
         DataTable dtdepartment = objBusinessEmployeeDetailsReport.ReadDepartment(objEntityEmployeeDetailsreport);
         if (dtdepartment.Rows.Count > 0)
         {
             ddlDeptmnt.DataSource = dtdepartment;
             ddlDeptmnt.Items.Clear();

             ddlDeptmnt.DataValueField = "CPRDEPT_ID";
             ddlDeptmnt.DataTextField = "CPRDEPT_NAME";



             //ddlProjct.DataValueField = "PROJECT_ID";
             ddlDeptmnt.DataBind();

         }
         ddlDeptmnt.Items.Insert(0, "--SELECT--");

     }
     public void PaygradeLoad()
     {
         clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport = new clsEntityEmployeeDetailsReport();
         clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();
         if (Session["CORPOFFICEID"] != null)
         {
             objEntityEmployeeDetailsreport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
         }
         else if (Session["CORPOFFICEID"] == null)
         {
             Response.Redirect("~/Default.aspx");
         }
         if (Session["ORGID"] != null)
         {
             objEntityEmployeeDetailsreport.OrganisationId = Convert.ToInt32(Session["ORGID"].ToString());
         }
         else if (Session["ORGID"] == null)
         {
             Response.Redirect("/Default.aspx");
         }
         if (Session["USERID"] != null)
         {
             // intUserId = Convert.ToInt32(Session["USERID"]);
             objEntityEmployeeDetailsreport.UserId = Convert.ToInt32(Session["USERID"]);
         }
         else if (Session["USERID"] == null)
         {
             Response.Redirect("/Default.aspx");
         }
         DataTable dtdepartment = objBusinessEmployeeDetailsReport.ReadPaygrade(objEntityEmployeeDetailsreport);
         if (dtdepartment.Rows.Count > 0)
         {
             ddlGrade.DataSource = dtdepartment;
             ddlGrade.Items.Clear();

             ddlGrade.DataValueField = "PYGRD_ID";
             ddlGrade.DataTextField = "PYGRD_NAME";



             //ddlProjct.DataValueField = "PROJECT_ID";
             ddlGrade.DataBind();

         }
         ddlGrade.Items.Insert(0, "--SELECT--");

     }
     protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
     {
         clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport = new clsEntityEmployeeDetailsReport();
         clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();

         //  clsEntityReports ObjLeadReport = new clsEntityReports();
         if (Session["CORPOFFICEID"] != null)
         {
             objEntityEmployeeDetailsreport.Corporate_id = Convert.ToInt32(ddlBusnsUnit.SelectedItem.Value);
             //objEntityEmployeeDetailsreport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
         }
         else if (Session["CORPOFFICEID"] == null)
         {
             Response.Redirect("~/Default.aspx");
         }
         if (Session["ORGID"] != null)
         {
             objEntityEmployeeDetailsreport.OrganisationId = Convert.ToInt32(Session["ORGID"].ToString());
         }
         else if (Session["ORGID"] == null)
         {
             Response.Redirect("/Default.aspx");
         }
         if (Session["USERID"] != null)
         {
             // intUserId = Convert.ToInt32(Session["USERID"]);
             objEntityEmployeeDetailsreport.UserId = Convert.ToInt32(Session["USERID"]);
         }
         else if (Session["USERID"] == null)
         {
             Response.Redirect("/Default.aspx");
         }

         if (ddlDivsn.SelectedItem.Text == "--SELECT--")
         {
             objEntityEmployeeDetailsreport.DivisionId = 0;
         }
         else
         {

             objEntityEmployeeDetailsreport.DivisionId = Convert.ToInt32(ddlDivsn.SelectedValue);
         }
         ddlPrjct.Items.Clear();
         DataTable dtProject = objBusinessEmployeeDetailsReport.ReadProject(objEntityEmployeeDetailsreport);
         if (dtProject.Rows.Count > 0)
         {
             ddlPrjct.DataSource = dtProject;
             ddlPrjct.DataValueField = "PROJECT_ID";
             ddlPrjct.DataTextField = "PROJECT_NAME";
             ddlPrjct.DataBind();

         }

         ddlPrjct.Items.Insert(0, "--SELECT--");
         ScriptManager.RegisterStartupScript(this, GetType(), "Autocomplt", "Autocomplt();", true);
     }
     public void ReligionLoad()
     {
         clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();
         DataTable dtCountry = objBusinessEmployeeDetailsReport.readReligion();
         if (dtCountry.Rows.Count > 0)
         {
             ddlRelgn.Items.Clear();
             ddlRelgn.DataSource = dtCountry;
             ddlRelgn.DataValueField = "RELIGION_ID";
             ddlRelgn.DataTextField = "RELIGION_NAME";
             ddlRelgn.DataBind();

         }
         ddlRelgn.Items.Insert(0, "--SELECT--");
     }

    #endregion filter

     [WebMethod]
     public static string LoadEmployeeDetailsList(string OrgId, string CorpId, string DesignationId, string DepartmentId, string DivisionId, string ProjectId, string ReligionId,string GenderId, string NumOfYears, string PayGradeId, string AgeFrom, string AgeTo, string StatusId, string NationalityId)
     {

         clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport = new clsEntityEmployeeDetailsReport();
         clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();
         clsCommonLibrary objCommon = new clsCommonLibrary();
         string strRandom = objCommon.Random_Number();

         objEntityEmployeeDetailsreport.OrganisationId = Convert.ToInt32(OrgId);
         objEntityEmployeeDetailsreport.Corporate_id = Convert.ToInt32(CorpId);

         if (DesignationId != "")
         {
             objEntityEmployeeDetailsreport.DesignationId = Convert.ToInt32(DesignationId);
         }


         if (DepartmentId != "")
         {
             objEntityEmployeeDetailsreport.DepartmentId = Convert.ToInt32(DepartmentId);
         }


         if (DivisionId != "")
         {
             objEntityEmployeeDetailsreport.DivisionId = Convert.ToInt32(DivisionId);
         }

         if (ProjectId != "")
         {
             objEntityEmployeeDetailsreport.ProjectId = Convert.ToInt32(ProjectId);
         }

         if (ReligionId != "")
         {
             objEntityEmployeeDetailsreport.ReligionId = Convert.ToInt32(ReligionId);
         }

         /////////////

         if (GenderId != "")
         {
             objEntityEmployeeDetailsreport.GenderId = Convert.ToInt32(GenderId);
         }
         if (NumOfYears != "")
         {
             objEntityEmployeeDetailsreport.NumOfYears = Convert.ToInt32(NumOfYears);
         }
         if (PayGradeId != "")
         {
             objEntityEmployeeDetailsreport.GradeId = Convert.ToInt32(PayGradeId);
         }
         if (AgeFrom != "")
         {
             objEntityEmployeeDetailsreport.AgeFrom = Convert.ToInt32(AgeFrom);
         }
         if (AgeTo != "")
         {
             objEntityEmployeeDetailsreport.AgeTo = Convert.ToInt32(AgeTo);
         }
         if (StatusId != "")
         {
             if (StatusId == "0")
             {
                 objEntityEmployeeDetailsreport.StatusId = 1;
             }
             if (StatusId == "1")
             {
                 objEntityEmployeeDetailsreport.StatusId = 2;
             }
             if (StatusId == "2")
             {
                 objEntityEmployeeDetailsreport.StatusId = 3;
             }
             if (StatusId == "3")
             {
                 objEntityEmployeeDetailsreport.StatusId = 0;
             }
         }
         if (NationalityId != "")
         {
             objEntityEmployeeDetailsreport.NationalityId = Convert.ToInt32(NationalityId);
         }


         DataTable dtEmpDetails = new DataTable();
         dtEmpDetails = objBusinessEmployeeDetailsReport.ReadEmployeeList(objEntityEmployeeDetailsreport);
         string strHtml = "<table id=\"ReportTableBulk\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";

         //add header row
         strHtml += "<thead>";
         strHtml += "<tr class=\"main_table_head\">";
         strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: left; word-wrap:break-word;\"><input type=\"checkbox\" Id=\"cbxSelectAll\" OnkeyPress=\"return DisableEnter(event)\" style=\"margin-left: 23%;\" onchange=\"selectAllCandidate()\"></th>";
         for (int intColumnHeaderCount = 0; intColumnHeaderCount < dtEmpDetails.Columns.Count; intColumnHeaderCount++)
         {

             if (intColumnHeaderCount == 1)
             {
                 strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";
             }
             if (intColumnHeaderCount == 2)
             {
                 strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE NAME </th>";
             }
             if (intColumnHeaderCount == 3)
             {
                 strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">DESIGNATION</th>";
             }
             if (intColumnHeaderCount == 4)
             {
                 strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";
             }

             if (intColumnHeaderCount == 5)
             {
                 strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">DIVISION</th>";
             }
             if (intColumnHeaderCount == 6)
             {
                 strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">PAY GRADE</th>";
             }
         }

         strHtml += "</tr>";
         strHtml += "</thead>";
         //add rows

         strHtml += "<tbody>";

         for (int intRowBodyCount = 0; intRowBodyCount < dtEmpDetails.Rows.Count; intRowBodyCount++)
         {

             string strEmployeeID = "";
             string strEmployeeName = "";
             string strDesignation = "";
             string strDepartment = "";
             string strDivision = "";
             string strPaygrade = "";

             objEntityEmployeeDetailsreport.UserId = Convert.ToInt32(dtEmpDetails.Rows[intRowBodyCount]["USR_ID"]);
             DataTable dtDivisions = objBusinessEmployeeDetailsReport.ReadDivisionOfEmp(objEntityEmployeeDetailsreport);

             objEntityEmployeeDetailsreport.date = System.DateTime.Now;
             DataTable dtProject = objBusinessEmployeeDetailsReport.ReadProjectDetails(objEntityEmployeeDetailsreport);

             string strShowPrjct = "false";
             if (dtProject.Rows.Count == 0 && ProjectId == "")
             {
                 strShowPrjct = "true";
             }

             foreach (DataRow dtDiv in dtProject.Rows)
             {
                 if (ProjectId != "")
                 {
                     if (dtDiv["PROJECT_ID"].ToString() == ProjectId)
                     {
                         strShowPrjct = "true";
                     }
                 }
                 else
                 {
                     strShowPrjct = "true";
                 }
             }

             //End:-For Project Search



             //Start:-For Division Search
             string strShow = "false";
             string strDivisions = "";
             if (dtDivisions.Rows.Count == 0 || DivisionId == "")
             {
                 strShow = "true";
             }

             foreach (DataRow dtDiv in dtDivisions.Rows)
             {
                 if (strDivisions == "")
                 {
                     strDivisions = dtDiv["CPRDIV_NAME"].ToString();
                 }
                 else
                 {
                     strDivisions = strDivisions + "," + dtDiv["CPRDIV_NAME"];
                 }

                 if (DivisionId != "")
                 {
                     if (dtDiv["CPRDIV_ID"].ToString() == DivisionId)
                     {
                         strShow = "true";
                     }
                 }
                 else
                 {
                     strShow = "true";
                 }

             }
             //End:-For Division Search

             //Start:-For Age Search EVM-0027
             Int64 Years = 000;
             string strShowAge = "false";
             clsCommonLibrary commn = new clsCommonLibrary();

             if (dtEmpDetails.Rows[intRowBodyCount]["EMPERDTL_DOB"].ToString() != "")
             {
                 string Dob1 = dtEmpDetails.Rows[intRowBodyCount]["EMPERDTL_DOB"].ToString();
                 DateTime dob = commn.textToDateTime(Dob1);
                 if (dob < DateTime.Now)
                 {

                     Years = new DateTime(DateTime.Now.Subtract(dob).Ticks).Year - 1;
                 }

             }
             //END

             if (AgeFrom != "" && AgeTo != "")
             {
                 if (Years >= Convert.ToInt32(AgeFrom) && Years <= Convert.ToInt32(AgeTo))
                 {
                     strShowAge = "true";
                 }
             }
             else if (AgeFrom != "")
             {
                 if (Years >= Convert.ToInt32(AgeFrom))
                 {
                     strShowAge = "true";
                 }
             }
             else if (AgeTo != "")
             {
                 if (Years <= Convert.ToInt32(AgeTo))
                 {
                     strShowAge = "true";
                 }
             }
             else
             {
                 strShowAge = "true";
             }
             //End:-For Age Search


             //Start:-For Exp Years Search
             int ExpYears = 0;
             string strShowExp = "false";
             if (dtEmpDetails.Rows[intRowBodyCount]["EMPERDTL_JOIN_DATE"].ToString() != "")
             {
                 DateTime Dob = commn.textToDateTime(dtEmpDetails.Rows[intRowBodyCount]["EMPERDTL_JOIN_DATE"].ToString());
                 //  DateTime Dob = Convert.ToDateTime(dt.Rows[intRowBodyCount]["EMPERDTL_JOIN_DATE"].ToString());
                 if (Dob < DateTime.Now)
                     ExpYears = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;

             }

             //  CorpId,  DesignationId,  DepartmentId,  DivisionId,  ProjectId,  ReligionId,  GenderId,  NumOfYears,  PayGradeId,  AgeFrom,  AgeTo,  StatusId,  NationalityId)

             if (NumOfYears == "1")
             {
                 if (ExpYears >= 1)
                 {
                     strShowExp = "true";
                 }
             }
             else if (NumOfYears == "2")
             {
                 if (ExpYears >= 3)
                 {
                     strShowExp = "true";
                 }
             }
             else if (NumOfYears == "3")
             {
                 if (ExpYears >= 5)
                 {
                     strShowExp = "true";
                 }
             }
             else if (NumOfYears == "4")
             {
                 if (ExpYears >= 8)
                 {
                     strShowExp = "true";
                 }
             }
             else
             {
                 strShowExp = "true";
             }
             //End:-For Exp Years Search

             if (strShow == "true" && strShowPrjct == "true" && strShowAge == "true" && strShowExp == "true")
             {
                 strHtml += "<tr  >";
                 strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" onchange='return changeSingle();' OnkeyPress=\"return DisableEnter(event)\" class=\"clsCblcandidatelist\" Id=\"cblcandidatelist" + intRowBodyCount + "\"true\"></td>";

                 for (int intColumnBodyCount = 0; intColumnBodyCount < dtEmpDetails.Columns.Count; intColumnBodyCount++)
                    // for (int intColumnBodyCount = 0; intColumnBodyCount < 3; intColumnBodyCount++)
                 {
                     if (intColumnBodyCount == 1)
                     {
                         strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtEmpDetails.Rows[intRowBodyCount][3].ToString() + "</td>";
                     }

                     if (intColumnBodyCount == 2)
                     {
                         if (dtEmpDetails.Rows[intRowBodyCount][intColumnBodyCount].ToString() != "")
                         {
                             strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtEmpDetails.Rows[intRowBodyCount]["USRNAME"].ToString() + "</td>";
                         }
                         else
                         {
                             strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtEmpDetails.Rows[intRowBodyCount][9].ToString() + "</td>";
                         }
                     }

                     if (intColumnBodyCount == 3)
                     {
                         strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtEmpDetails.Rows[intRowBodyCount]["DSGN_NAME"].ToString() + "</td>";
                     }
                     if (intColumnBodyCount == 4)
                     {
                         strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtEmpDetails.Rows[intRowBodyCount]["CPRDEPT_NAME"].ToString() + "</td>";
                     }

                     if (intColumnBodyCount == 5)
                     {
                         strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + strDivisions + "</td>";
                     }
                     if (intColumnBodyCount == 6)
                     {
                         strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtEmpDetails.Rows[intRowBodyCount][6].ToString().ToUpper() + "</td>";
                     }
                 }

                 strHtml += "<td style=\"display:none\" class=\"tdT\" Id=\"tdEmpId" + intRowBodyCount + "\">" + dtEmpDetails.Rows[intRowBodyCount]["USR_ID"].ToString() + "</td>";
                 strHtml += "<td style=\"display:none\" class=\"tdT\" Id=\"tdEmpName" + intRowBodyCount + "\">" + dtEmpDetails.Rows[intRowBodyCount]["USRNAME"].ToString() + "</td>";
                 strHtml += "<td style=\"display:none\" class=\"tdT\" Id=\"tdEmpCode" + intRowBodyCount + "\">" + dtEmpDetails.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</td>";

                 strHtml += "</tr>";

             }
         }

         strHtml += "</tbody>";
         strHtml += "</table>";

         return strHtml;
     }
     protected void btnConfirm_Click(object sender, EventArgs e)
     {

     }
     [WebMethod]
     public static string LoadBusinessUnits(string OrgId, string CorpId, string AcmdtnId)
     {
         cls_Business_Mess_Bill objBusinessLayerMessBill = new cls_Business_Mess_Bill();
         clsEntity_Mess_Bill objEntityMessBill = new clsEntity_Mess_Bill();
         objEntityMessBill.Organisation_Id = Convert.ToInt32(OrgId);
         objEntityMessBill.CorpOffice_Id = Convert.ToInt32(CorpId);
         if (AcmdtnId != "--SELECT ACCOMMODATION--")
         {
             objEntityMessBill.AccomoDationId = Convert.ToInt32(AcmdtnId);
         }
         DataTable dtEmpDetails = new DataTable();
         dtEmpDetails = objBusinessLayerMessBill.ReadBusnsUnitsAcmdtn(objEntityMessBill);
         string strHtml = "";     
         for (int intRowBodyCount = 0; intRowBodyCount < dtEmpDetails.Rows.Count; intRowBodyCount++)
         {
             if (CorpId == dtEmpDetails.Rows[intRowBodyCount]["CORPRT_ID"].ToString())
             {
                 strHtml+="<option selected value=\"" + dtEmpDetails.Rows[intRowBodyCount]["CORPRT_ID"].ToString() + "\">" + dtEmpDetails.Rows[intRowBodyCount]["CORPRT_NAME"].ToString() + "</option>";
             }
             else
             {
                strHtml+="<option value=\"" + dtEmpDetails.Rows[intRowBodyCount]["CORPRT_ID"].ToString() + "\">" + dtEmpDetails.Rows[intRowBodyCount]["CORPRT_NAME"].ToString() + "</option>";
             }
         }
         return strHtml;
     }

     [WebMethod]
     public static string[] LoadBusinessUnitsSubDdl(string OrgId, string CorpId)
     {
         string[] strArr=new string[5];
         clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport = new clsEntityEmployeeDetailsReport();
         clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();
         objEntityEmployeeDetailsreport.Corporate_id= Convert.ToInt32(CorpId);
         objEntityEmployeeDetailsreport.OrganisationId= Convert.ToInt32(OrgId);
         string strHtml="";
         // division
         strHtml += "<option selected value=\"--SELECT--\">--SELECT--</option>";
         DataTable dtDivision = objBusinessEmployeeDetailsReport.ReadDivision(objEntityEmployeeDetailsreport);             
         for (int intRowBodyCount = 0; intRowBodyCount < dtDivision.Rows.Count; intRowBodyCount++)
         {     
            strHtml += "<option value=\"" + dtDivision.Rows[intRowBodyCount]["CPRDIV_ID"].ToString() + "\">" + dtDivision.Rows[intRowBodyCount]["CPRDIV_NAME"].ToString() + "</option>";
         }
         strArr[0]=strHtml;
        
         //Project
         int divid = 0;
         objEntityEmployeeDetailsreport.DivisionId = divid;
         DataTable dtProject = objBusinessEmployeeDetailsReport.ReadProject(objEntityEmployeeDetailsreport);
         strHtml="";
         strHtml += "<option selected value=\"--SELECT--\">--SELECT--</option>";            
         for (int intRowBodyCount = 0; intRowBodyCount < dtProject.Rows.Count; intRowBodyCount++)
         {     
            strHtml += "<option value=\"" + dtProject.Rows[intRowBodyCount]["PROJECT_ID"].ToString() + "\">" + dtProject.Rows[intRowBodyCount]["PROJECT_NAME"].ToString() + "</option>";
         }
         strArr[1]=strHtml;
        

        //Department load
   
         DataTable dtdepartment = objBusinessEmployeeDetailsReport.ReadDepartment(objEntityEmployeeDetailsreport);
         strHtml="";
         strHtml += "<option selected value=\"--SELECT--\">--SELECT--</option>";            
         for (int intRowBodyCount = 0; intRowBodyCount < dtdepartment.Rows.Count; intRowBodyCount++)
         {     
            strHtml += "<option value=\"" + dtdepartment.Rows[intRowBodyCount]["CPRDEPT_ID"].ToString() + "\">" + dtdepartment.Rows[intRowBodyCount]["CPRDEPT_NAME"].ToString() + "</option>";
         }
         strArr[2]=strHtml;
        
       //paygrade load
         
         DataTable dtdepartment1 = objBusinessEmployeeDetailsReport.ReadPaygrade(objEntityEmployeeDetailsreport);
         strHtml="";
         strHtml += "<option selected value=\"--SELECT--\">--SELECT--</option>";            
         for (int intRowBodyCount = 0; intRowBodyCount < dtdepartment1.Rows.Count; intRowBodyCount++)
         {     
            strHtml += "<option value=\"" + dtdepartment1.Rows[intRowBodyCount]["PYGRD_ID"].ToString() + "\">" + dtdepartment1.Rows[intRowBodyCount]["PYGRD_NAME"].ToString() + "</option>";
         }
         strArr[3]=strHtml;
         
         return strArr;
     }

     //protected void ddlBusnsUnit_SelectedIndexChanged(object sender, EventArgs e)
     //{
     //    ddlPrjct.Items.Clear();
     //    ddlDivsn.Items.Clear();
     //    ddlDeptmnt.Items.Clear();
     //    ddlGrade.Items.Clear();

     //    clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport = new clsEntityEmployeeDetailsReport();
     //    clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();

     //    //  clsEntityReports ObjLeadReport = new clsEntityReports();
     //    if (Session["CORPOFFICEID"] != null)
     //    {
     //        objEntityEmployeeDetailsreport.Corporate_id = Convert.ToInt32(ddlBusnsUnit.SelectedItem.Value);
     //    }
     //    else if (Session["CORPOFFICEID"] == null)
     //    {
     //        Response.Redirect("~/Default.aspx");
     //    }
     //    if (Session["ORGID"] != null)
     //    {
     //        objEntityEmployeeDetailsreport.OrganisationId = Convert.ToInt32(Session["ORGID"].ToString());
     //    }
     //    else if (Session["ORGID"] == null)
     //    {
     //        Response.Redirect("/Default.aspx");
     //    }
     //    if (Session["USERID"] != null)
     //    {
     //        // intUserId = Convert.ToInt32(Session["USERID"]);
     //        objEntityEmployeeDetailsreport.UserId = Convert.ToInt32(Session["USERID"]);
     //    }
     //    else if (Session["USERID"] == null)
     //    {
     //        Response.Redirect("/Default.aspx");
     //    }
     //    DataTable dtDivision = objBusinessEmployeeDetailsReport.ReadDivision(objEntityEmployeeDetailsreport);
     //    if (dtDivision.Rows.Count > 0)
     //    {
     //        ddlDivsn.Items.Clear();
     //        ddlDivsn.DataSource = dtDivision;


     //        ddlDivsn.DataValueField = "CPRDIV_ID";
     //        ddlDivsn.DataTextField = "CPRDIV_NAME";



     //        //ddlProjct.DataValueField = "PROJECT_ID";
     //        ddlDivsn.DataBind();

     //    }
     //    ddlDivsn.Items.Insert(0, "--SELECT--");
        

     //    int divid = 0;
     //    objEntityEmployeeDetailsreport.DivisionId = divid;
     //    DataTable dtProject = objBusinessEmployeeDetailsReport.ReadProject(objEntityEmployeeDetailsreport);
     //    if (dtProject.Rows.Count > 0)
     //    {
     //        ddlPrjct.DataSource = dtProject;


     //        ddlPrjct.DataValueField = "PROJECT_ID";
     //        ddlPrjct.DataTextField = "PROJECT_NAME";

     //        //  ddlprojectassign.DataValueField = "PROJECT_ID";


     //        //     ddlProjct.DataValueField = "PROJECT_ID";
     //        ddlPrjct.DataBind();

     //    }
     //    //    ddlprojectassign.Items.Insert(0, "--SELECT PROJECT--");
     //    ddlPrjct.Items.Insert(0, "--SELECT--");

        
     //    DataTable dtdepartment = objBusinessEmployeeDetailsReport.ReadDepartment(objEntityEmployeeDetailsreport);
     //    if (dtdepartment.Rows.Count > 0)
     //    {
     //        ddlDeptmnt.DataSource = dtdepartment;
     //        ddlDeptmnt.Items.Clear();

     //        ddlDeptmnt.DataValueField = "CPRDEPT_ID";
     //        ddlDeptmnt.DataTextField = "CPRDEPT_NAME";



     //        //ddlProjct.DataValueField = "PROJECT_ID";
     //        ddlDeptmnt.DataBind();

     //    }
     //    ddlDeptmnt.Items.Insert(0, "--SELECT--");
         
     //    DataTable dtdepartment1 = objBusinessEmployeeDetailsReport.ReadPaygrade(objEntityEmployeeDetailsreport);
     //    if (dtdepartment1.Rows.Count > 0)
     //    {
     //        ddlGrade.DataSource = dtdepartment1;
     //        ddlGrade.Items.Clear();

     //        ddlGrade.DataValueField = "PYGRD_ID";
     //        ddlGrade.DataTextField = "PYGRD_NAME";



     //        //ddlProjct.DataValueField = "PROJECT_ID";
     //        ddlGrade.DataBind();

     //    }
     //    ddlGrade.Items.Insert(0, "--SELECT--");
     //    ScriptManager.RegisterStartupScript(this, GetType(), "Autocomplt", "Autocomplt();", true);
     //}
}