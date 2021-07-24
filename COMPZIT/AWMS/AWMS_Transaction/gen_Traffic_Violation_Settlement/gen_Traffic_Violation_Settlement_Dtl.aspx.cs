using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using CL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_AWMS;
using System.Data;
using System.Text;
using System.Web.Services;

public partial class AWMS_AWMS_Transaction_gen_Traffic_Violation_Settlement_gen_Traffic_Violation_Settlement_Dtl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            //Creating objects for business layer

            clsBusinessLayerTrafficViolationSettlement objBusinessLayerTrficVioltnStlmnt = new clsBusinessLayerTrafficViolationSettlement();
            clsEntityTrafficViolationSettlement objEntityTrficVioltnStlmnt = new clsEntityTrafficViolationSettlement();

            int intUsrRolMstrId = 0, intUserId = 0, intCorpId = 0, intEnableReOpen = 0, intEnableConfirm=0;
            string strCurrentDate = objBusiness.LoadCurrentDateInString();

            hiddenCurrentDate.Value = strCurrentDate;

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityTrficVioltnStlmnt.CorporateId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityTrficVioltnStlmnt.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
                hiddenOrgId.Value = Session["ORGID"].ToString();
            }

            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                hiddenUserId.Value = Session["USERID"].ToString();
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Traffic_Violation_Settlement);

            DataTable dtChildRol = objBusiness.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        //intEnableAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        //intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        //intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        //hiddenRoleConfirm.Value = intEnableConfirm.ToString();
                    }

                }

              
            }
            //currency

            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                            clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                //hiddenDecimalCountCommon.Value = dtCorpDetail.Rows[0]["GN_UNIT_DECIMAL_CNT"].ToString();
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            }
            
            // client side number format
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            //evm-0023 initialize currency details and taken into lblCurrencyAbbr
            dtCurrencyDetail = objBusiness.ReadCurrencyDetails(objEntityCommon);
            string strCurrencyAbbr = "";
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
                strCurrencyAbbr = dtCurrencyDetail.Rows[0]["CRNCMST_ABBRV"].ToString();
                lblCurrencyAbbr.Text = strCurrencyAbbr;
            }

            BindDropDownList();
            //Pending settlement
            if (Request.QueryString["Id"] != null)
            {
                divHiddenDdlEmploee.Visible = true;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                int intVehicleId = Convert.ToInt32(strId);
                //EditView(intTVioltnId, 1);
                hiddenVehicleId.Value = intVehicleId.ToString();
                lblEntry.Text = "Edit Traffic Violation";
                objEntityTrficVioltnStlmnt.VehicleId = intVehicleId;
                DataTable dtPendingViolations = new DataTable();
                objEntityTrficVioltnStlmnt.StlStatus = 0;
                objEntityTrficVioltnStlmnt.ReceiptNo = null;
                dtPendingViolations = objBusinessLayerTrficVioltnStlmnt.ReadViolationsByVehID(objEntityTrficVioltnStlmnt);
                //To read Vehicle No
                DataTable dtVehDetails = objBusinessLayerTrficVioltnStlmnt.ReadVehicleNoDtl(objEntityTrficVioltnStlmnt);
                string strHtm = ConvertDataTableToHTML(dtPendingViolations,"Edit");

                //Write to divReport
                divReport.InnerHtml = strHtm;
                if (dtVehDetails.Rows.Count > 0)
                {
                    
                    lblVheNo.Text = dtVehDetails.Rows[0]["VHCL_NUMBR"].ToString();
                    
                }
                hiddenViewStatus.Value = "Pending";
                hiddenSaveStatus.Value = "Save";        
            }
            
            if (Request.QueryString["VHEId"] != null && Request.QueryString["RecptNo"] != null)
            {
                //Settled
                divHiddenDdlEmploee.Visible = false;
                string strRandomMixedId = Request.QueryString["VHEId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                int intVehicleId = Convert.ToInt32(strId);
                //EditView(intTVioltnId, 1);
                hiddenVehicleId.Value = intVehicleId.ToString();
                lblEntry.Text = "Settled Traffic Violation";
                objEntityTrficVioltnStlmnt.VehicleId = intVehicleId;
                DataTable dtPendingViolations = new DataTable();
                objEntityTrficVioltnStlmnt.ReceiptNo = Request.QueryString["RecptNo"].ToString();
                objEntityTrficVioltnStlmnt.StlStatus = 1;
                dtPendingViolations = objBusinessLayerTrficVioltnStlmnt.ReadViolationsByVehID(objEntityTrficVioltnStlmnt);
                //To read Vehicle No +Receipt No +Amnt
                DataTable dtVehDetails = objBusinessLayerTrficVioltnStlmnt.ReadVehicleNoDtl(objEntityTrficVioltnStlmnt);
                string strHtm = ConvertDataTableToHTML(dtPendingViolations);
                //Write to divReport
                divReport.InnerHtml = strHtm;
                if (intEnableConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    btnConfirm.Visible = true;
                }
                btnSave.Text = "Update";
                if (dtVehDetails.Rows.Count > 0)
                {
                    txtReceiptNo.Text = dtVehDetails.Rows[0]["TRFCVIOLTNDTL_RCPT_NUMBER"].ToString();
                    lblReceiptAmount.Text = dtVehDetails.Rows[0]["RCPT_AMNT"].ToString() ;
                    hiddenReceiptAmt.Value = dtVehDetails.Rows[0]["RCPT_AMNT"].ToString();
                    lblVheNo.Text = dtVehDetails.Rows[0]["VHCL_NUMBR"].ToString();
                    string strSettleUserId = "";
                    strSettleUserId=dtVehDetails.Rows[0]["SETTLD_USRID"].ToString();
                    if (strSettleUserId != null)
                    {
                        if (ddlEmployee.Items.FindByValue(strSettleUserId) != null)
                        {
                            ddlEmployee.Items.FindByValue(strSettleUserId).Selected = true;
                        }
                    }
                    if (dtVehDetails.Rows[0]["TRFCVIOLTN_CNFRM_STS"].ToString() == "1")
                    {
                        btnClear.Visible = false;
                        btnSave.Visible = false;
                        btnConfirm.Visible = false;
                        txtReceiptNo.Enabled = false;
                        ddlEmployee.Enabled = false;
                        if (intEnableReOpen ==Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                        btnReOpen.Visible = true;
                        }
                    }
                }
                txtReceiptNo.Focus();
                hiddenViewStatus.Value = "Settled";
                hiddenSaveStatus.Value = "Update";

            }
            if (Request.QueryString["DVHEId"] != null && Request.QueryString["RecptNo"] != null)
            {
                //Canceled View
                string strRandomMixedId = Request.QueryString["DVHEId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                int intVehicleId = Convert.ToInt32(strId);
                //EditView(intTVioltnId, 1);
                hiddenVehicleId.Value = intVehicleId.ToString();
                lblEntry.Text = "Settled Traffic Violation";
                objEntityTrficVioltnStlmnt.VehicleId = intVehicleId;
                DataTable dtPendingViolations = new DataTable();
                objEntityTrficVioltnStlmnt.ReceiptNo = Request.QueryString["RecptNo"].ToString();
                objEntityTrficVioltnStlmnt.StlStatus = 1;
                objEntityTrficVioltnStlmnt.CancelStatus = 1;
                dtPendingViolations = objBusinessLayerTrficVioltnStlmnt.ReadViolationsByVehID(objEntityTrficVioltnStlmnt);
                //To read Vehicle No +Receipt No +Amnt
                DataTable dtVehDetails = objBusinessLayerTrficVioltnStlmnt.ReadVehicleNoDtl(objEntityTrficVioltnStlmnt);
                string strHtm = ConvertDataTableToHTML(dtPendingViolations);
                //Write to divReport
                divReport.InnerHtml = strHtm;
                //btnConfirm.Visible = true;
                if (dtVehDetails.Rows.Count > 0)
                {
                    txtReceiptNo.Text = dtVehDetails.Rows[0]["TRFCVIOLTNDTL_RCPT_NUMBER"].ToString();
                    lblReceiptAmount.Text = dtVehDetails.Rows[0]["RCPT_AMNT"].ToString();
                    hiddenReceiptAmt.Value = dtVehDetails.Rows[0]["RCPT_AMNT"].ToString();
                    lblVheNo.Text = dtVehDetails.Rows[0]["VHCL_NUMBR"].ToString();
                    string strSettleUserId = "";
                    strSettleUserId = dtVehDetails.Rows[0]["SETTLD_USRID"].ToString();
                    if (strSettleUserId != null)
                    {
                        if (ddlEmployee.Items.FindByValue(strSettleUserId) != null)
                        {
                            ddlEmployee.Items.FindByValue(strSettleUserId).Selected = true;
                        }
                    }
                    if (dtVehDetails.Rows[0]["TRFCVIOLTN_CNFRM_STS"].ToString() == "1")
                    {
                        
                    }
                }
                btnClear.Visible = false;
                btnSave.Visible = false;
                btnConfirm.Visible = false;
                txtReceiptNo.Enabled = false;
                ddlEmployee.Enabled = false;
                btnReOpen.Visible = false;
                hiddenViewStatus.Value = "Settled";

            }
        }
    }
    public void BindDropDownList(string strEmpID = null)
            {
        
                ddlEmployee.Items.Clear();
                clsBusinessLayerTrafficViolationSettlement objBusinessLayerTrficVioltnStlmnt = new clsBusinessLayerTrafficViolationSettlement();
                clsEntityTrafficViolationSettlement objEntityTrficVioltnStlmnt = new clsEntityTrafficViolationSettlement();
                DataTable dtEmployees = new DataTable();

                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityTrficVioltnStlmnt.CorporateId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityTrficVioltnStlmnt.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                //BL
                dtEmployees = objBusinessLayerTrficVioltnStlmnt.ReadEmployees(objEntityTrficVioltnStlmnt);

                ddlEmployee.DataSource = dtEmployees;
                ddlEmployee.DataTextField = "USR_NAME";
                ddlEmployee.DataValueField = "USR_ID";//DSGTYP_ID
                ddlEmployee.DataBind();
                ddlEmployee.Items.Insert(0, "--SELECT--");
                if (strEmpID != null)
                {
                    if (ddlEmployee.Items.FindByText(strEmpID) != null)
                    {
                        ddlEmployee.Items.FindByText(strEmpID).Selected = true;
                    }
                }
            }
    public string ConvertDataTableToHTML(DataTable dt,string strMode=null)
    {
        
        hiddenRowCount.Value = dt.Rows.Count.ToString();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        StringBuilder sb = new StringBuilder();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        decimal decimalSettleAmount = 0;

        //evm-0023 For strCurrencyAbbr adding Currency symbol 
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dtCurrencyDetails = new DataTable();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        dtCurrencyDetails = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
        string strCurrencyAbbr = "";
        if (dtCurrencyDetails.Rows.Count > 0)
        {
            strCurrencyAbbr = dtCurrencyDetails.Rows[0]["CRNCMST_ABBRV"].ToString();
        }

        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">SL#</th>";

            }
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: right; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">SETTLED</th>";

                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: right; word-wrap:break-word;\">SETTLED AMOUNT</th>";
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">SETTLED DATE</th>";    
            }
            if (strMode == null)
            {
                if (intColumnHeaderCount == 8)
                {
                    strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
            }
           
            
        }
        // strHtml += "<td>" + dt.Columns[i].ColumnName + "</td>";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        int intSlNo = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr>";
            intSlNo = intSlNo + 1;
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                
                
                if (intColumnBodyCount == 0)
                {
                    //strHtml += "<td>" + i + "</td>";
                    strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + intSlNo + "</td>";

                }
                if (intColumnBodyCount == 1)
                {
                    string strId = dt.Rows[intRowBodyCount][0].ToString();
                    int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                    string stridLength = intIdLength.ToString("00");
                    string Id = stridLength + strId + strRandom;
                    // strHtml += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                    //strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + String.Format("{0:dd/MM/yyyy}",dt.Rows[intRowBodyCount][intColumnBodyCount]) + "</td>";

                }
                if (intColumnBodyCount == 2)
                {

                    //strHtml += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                }
                if (intColumnBodyCount == 3)
                {

                    //strHtml += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString()+ "</td>";
                }
                if (intColumnBodyCount == 4)
                {

                    //strHtml += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                    HiddenFieldSymbl.Value = strCurrencyAbbr;
                    //evm-0023 Add strCurrencyAbbr for INR
                    strHtml += "<td id=\"vltnAmnt" + intRowBodyCount + "\" class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() +  "</td>";
                    decimalSettleAmount = Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount]);
                    if (dt.Rows[intRowBodyCount][7].ToString() == "0")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" id=\"cbxSettle" + intRowBodyCount + "\" onkeypress=\"return isTag(event);\" onchange=\"toggleCheckbox(" + intRowBodyCount + "," + decimalSettleAmount + "," + dt.Rows.Count + ");\" value=\"" + dt.Rows[intRowBodyCount][0].ToString() + "_" + dt.Rows[intRowBodyCount][5].ToString() + "\"></td>";


                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" ><input type=\"text\" id=\"txtSettleAmnt" + intRowBodyCount + "\" style=\"text-align: right;\" onkeydown=\"return isNumber(event,'txtSettleAmnt" + intRowBodyCount + "');\" onblur=\"AmountCheck('txtSettleAmnt" + intRowBodyCount + "');\" onkeyup=\"calcAmount(" + dt.Rows.Count + ");\" maxlength=\"12\" disabled></td>";

                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" ><input type=\"text\" id=\"txtSettledDate" + intRowBodyCount + "\" placeholder=\"DD/MM/YYYY\" style=\"text-align: center;\"  onkeypress=\"return isTag(event);\" onblur=\"blurDate('txtSettledDate" + intRowBodyCount + "');\"   disabled ></td>";
                    }
                    else
                    {
                       
                            strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" checked=\"true\" id=\"cbxSettle" + intRowBodyCount + "\" onkeypress=\"return isTag(event);\" onchange=\"toggleCheckbox(" + intRowBodyCount + "," + decimalSettleAmount + "," + dt.Rows.Count + ");\" value=\"" + dt.Rows[intRowBodyCount][0].ToString() + "_" + dt.Rows[intRowBodyCount][5].ToString() + "\" disabled></td>";


                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" ><input type=\"text\" id=\"txtSettleAmnt" + intRowBodyCount + "\" style=\"text-align: right;\" onkeydown=\"return isNumber(event,'txtSettleAmnt" + intRowBodyCount + "');\" onblur=\"AmountCheck('txtSettleAmnt" + intRowBodyCount + "');\" value=\"" + dt.Rows[intRowBodyCount][6].ToString() + "\" maxlength=\"12\" onkeyup=\"calcAmount(" + dt.Rows.Count + ");\" disabled ></td>";

                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" ><input type=\"text\" id=\"txtSettledDate" + intRowBodyCount + "\" placeholder=\"DD/MM/YYYY\" style=\"text-align: center;\" onkeypress=\"return isTag(event);\"    value=\"" + String.Format("{0:dd/MM/yyyy}", dt.Rows[intRowBodyCount][9]) + "\" onblur=\"blurDate('txtSettledDate" + intRowBodyCount + "');\"  disabled ></td>";
                    }
                    
                }
                if (strMode == null)
                {
                    if (intColumnBodyCount == 8)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                    }

                }

            
                
            }
            strHtml += "</tr>";
        }
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    [WebMethod]
    public static string ConfirmSave(string strTrvID, string strTrvDtlID, string strAmntList, string strDtlList, string strSaveStatus, string strStldDateList)
    
    {
        //SAVE
        string strResult = "fail";
        string[] strArrTrvID = strTrvID.Split(',');
        string[] strArrTrvDtlID = strTrvDtlID.Split(',');
        string[] strArrAmntList = strAmntList.Split(',');

        string[] strStldDtaelist = strStldDateList.Split(',');

        clsBusinessLayerTrafficViolationSettlement objBusinessLayerTrficVioltnStlmnt = new clsBusinessLayerTrafficViolationSettlement();
        clsEntityTrafficViolationSettlement objEntityTrficVioltnStlmnt = new clsEntityTrafficViolationSettlement();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        //string stores Receipt No(0), Employee id(1),ReceiptAmnt(2),VehicleId(3),UserId (4),OrgId(5),CorpId(6)
        string[] strTrafficVioDtls = strDtlList.Split(',');
        objEntityTrficVioltnStlmnt.ReceiptNo = strTrafficVioDtls[0].ToString();
        if (strSaveStatus == "Update")
        {
            objEntityTrficVioltnStlmnt.VehicleId = Convert.ToInt32(strTrafficVioDtls[3]);
            
        }
        else
        {
            objEntityTrficVioltnStlmnt.VehicleId = 0;
            if (strTrafficVioDtls[1] != "--SELECT--")
            {
                objEntityTrficVioltnStlmnt.StlUserId = Convert.ToInt32(strTrafficVioDtls[1]);
            }

        }
            objEntityTrficVioltnStlmnt.Org_Id = Convert.ToInt32(strTrafficVioDtls[5]);
        objEntityTrficVioltnStlmnt.CorporateId = Convert.ToInt32(strTrafficVioDtls[6]);
       


           
            objEntityTrficVioltnStlmnt.ReceiptAmt = Convert.ToDecimal(strTrafficVioDtls[2]);
            objEntityTrficVioltnStlmnt.VehicleId = Convert.ToInt32(strTrafficVioDtls[3]);

            objEntityTrficVioltnStlmnt.User_Id = Convert.ToInt32(strTrafficVioDtls[4]);


            if (strArrTrvID.Length == strArrAmntList.Length && strArrTrvDtlID.Length == strArrTrvID.Length && strStldDtaelist.Length == strArrTrvID.Length && strArrTrvID.Length > 0)
            {
                List<clsEntityLayerSettleList> objSettleList = new List<clsEntityLayerSettleList>();
                for (int i = 0; i < strArrTrvID.Length; i++)
                {
                    if (strArrTrvID[i] != "" && strArrTrvDtlID[i] != "" && strArrAmntList[i] != "" && strStldDtaelist[i] != "")
                    {
                        clsEntityLayerSettleList objSettleCls = new clsEntityLayerSettleList();
                        objSettleCls.TrfcVioltn_ID = Convert.ToInt32(strArrTrvID[i]);
                        objSettleCls.TrfcVioltnDtl_ID = Convert.ToInt32(strArrTrvDtlID[i]);
                        objSettleCls.SettleAmount = Convert.ToDecimal(strArrAmntList[i]);
                        objSettleCls.StldStatus = 1;
                        if(strStldDtaelist[i].ToString()!="")
                        objSettleCls.SetldDate = objCommon.textToDateTime(strStldDtaelist[i].ToString());


                        objSettleList.Add(objSettleCls);
                    }


                }
                objBusinessLayerTrficVioltnStlmnt.Update_TrafficVioltn(objEntityTrficVioltnStlmnt, objSettleList);
                strResult = "success";
            }
        
        
        return strResult;
    }
    [WebMethod]
    public static string ConfirmSettlement(string strTrvID, string strTrvDtlID, string strAmntList, string strDtlList, string strStldDate)
    {
        //Confirm
        string strResult = "fail";
        string[] strArrTrvID = strTrvID.Split(',');
        string[] strArrTrvDtlID = strTrvDtlID.Split(',');
        string[] strArrAmntList = strAmntList.Split(',');

        string[] strArrStldDateList = strStldDate.Split(',');
        clsBusinessLayerTrafficViolationSettlement objBusinessLayerTrficVioltnStlmnt = new clsBusinessLayerTrafficViolationSettlement();
        clsEntityTrafficViolationSettlement objEntityTrficVioltnStlmnt = new clsEntityTrafficViolationSettlement();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        //string stores Receipt No(0), Employee id(1),ReceiptAmnt(2),VehicleId(3),UserId (4),OrgId(5),CorpId(6)
        string[] strTrafficVioDtls = strDtlList.Split(',');
        objEntityTrficVioltnStlmnt.ReceiptNo = strTrafficVioDtls[0].ToString();
        if (strTrafficVioDtls[1] != "--SELECT--")
        {
            objEntityTrficVioltnStlmnt.StlUserId = Convert.ToInt32(strTrafficVioDtls[1]);
        }
        objEntityTrficVioltnStlmnt.ReceiptAmt = Convert.ToDecimal(strTrafficVioDtls[2]);
        objEntityTrficVioltnStlmnt.VehicleId = Convert.ToInt32(strTrafficVioDtls[3]);
        objEntityTrficVioltnStlmnt.Org_Id = Convert.ToInt32(strTrafficVioDtls[5]);
        objEntityTrficVioltnStlmnt.CorporateId = Convert.ToInt32(strTrafficVioDtls[6]);
       
            objEntityTrficVioltnStlmnt.User_Id = Convert.ToInt32(strTrafficVioDtls[4]);
            
            objEntityTrficVioltnStlmnt.Date = DateTime.Now;
           
            if (strArrTrvID.Length == strArrAmntList.Length && strArrTrvDtlID.Length == strArrTrvID.Length && strArrTrvID.Length > 0)
            {
                List<clsEntityLayerSettleList> objSettleList = new List<clsEntityLayerSettleList>();
                for (int i = 0; i < strArrTrvID.Length; i++)
                {
                    if (strArrTrvID[i] != "" && strArrTrvDtlID[i] != "" && strArrAmntList[i] != "" && strArrStldDateList[i] != "")
                    {
                        clsEntityLayerSettleList objSettleCls = new clsEntityLayerSettleList();
                        objSettleCls.TrfcVioltn_ID = Convert.ToInt32(strArrTrvID[i]);
                        objSettleCls.TrfcVioltnDtl_ID = Convert.ToInt32(strArrTrvDtlID[i]);
                        objSettleCls.SettleAmount = Convert.ToDecimal(strArrAmntList[i]);
                        objSettleCls.StldStatus = 1;
                        if (strArrStldDateList[i].ToString() != "")
                            objSettleCls.SetldDate = objCommon.textToDateTime(strArrStldDateList[i].ToString());
                        objSettleList.Add(objSettleCls);
                    }


                }
                objBusinessLayerTrficVioltnStlmnt.Update_TrafficVioltn(objEntityTrficVioltnStlmnt, objSettleList);
                objBusinessLayerTrficVioltnStlmnt.ConfirmSettlement(objEntityTrficVioltnStlmnt, objSettleList);
                strResult = "success";
            }
       
        return strResult;
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        
        Response.Redirect(Request.RawUrl);
    }
    [WebMethod]
    public static string ReOpenTrafficViolation(string strTrvID, string strTrvDtlID, string strAmntList, string strDtlList)
    {
        //Confirm
        string strResult = "fail";
        string[] strArrTrvID = strTrvID.Split(',');
        string[] strArrTrvDtlID = strTrvDtlID.Split(',');
        string[] strArrAmntList = strAmntList.Split(',');
        clsBusinessLayerTrafficViolationSettlement objBusinessLayerTrficVioltnStlmnt = new clsBusinessLayerTrafficViolationSettlement();
        clsEntityTrafficViolationSettlement objEntityTrficVioltnStlmnt = new clsEntityTrafficViolationSettlement();
        //string stores Receipt No(0), Employee id(1),ReceiptAmnt(2),VehicleId(3),UserId (4),OrgId(5),CorpId(6)
        string[] strTrafficVioDtls = strDtlList.Split(',');
        objEntityTrficVioltnStlmnt.ReceiptNo = strTrafficVioDtls[0].ToString();
          //string strReceiptNoCount = objBusinessLayerTrficVioltnStlmnt.CheckDupReceiptNo(objEntityTrficVioltnStlmnt);
        DataTable dtReceiptDtls = objBusinessLayerTrficVioltnStlmnt.CheckDupReceiptNo(objEntityTrficVioltnStlmnt);
          
          
              
          
         
              if (strTrafficVioDtls[1] != "--SELECT--")
              {
                  objEntityTrficVioltnStlmnt.StlUserId = Convert.ToInt32(strTrafficVioDtls[1]);
              }
              objEntityTrficVioltnStlmnt.ReceiptAmt = Convert.ToDecimal(strTrafficVioDtls[2]);
              objEntityTrficVioltnStlmnt.VehicleId = Convert.ToInt32(strTrafficVioDtls[3]);

              objEntityTrficVioltnStlmnt.User_Id = Convert.ToInt32(strTrafficVioDtls[4]);
              objEntityTrficVioltnStlmnt.Org_Id = Convert.ToInt32(strTrafficVioDtls[5]);
              objEntityTrficVioltnStlmnt.CorporateId = Convert.ToInt32(strTrafficVioDtls[6]);

              if (strArrTrvID.Length == strArrAmntList.Length && strArrTrvDtlID.Length == strArrTrvID.Length && strArrTrvID.Length > 0)
              {
                  List<clsEntityLayerSettleList> objSettleList = new List<clsEntityLayerSettleList>();
                  for (int i = 0; i < strArrTrvID.Length; i++)
                  {
                      if (strArrTrvID[i] != "" && strArrTrvDtlID[i] != "" && strArrAmntList[i] != "")
                      {
                          clsEntityLayerSettleList objSettleCls = new clsEntityLayerSettleList();
                          objSettleCls.TrfcVioltn_ID = Convert.ToInt32(strArrTrvID[i]);
                          objSettleCls.TrfcVioltnDtl_ID = Convert.ToInt32(strArrTrvDtlID[i]);
                          objSettleCls.SettleAmount = Convert.ToDecimal(strArrAmntList[i]);
                          objSettleCls.StldStatus = 1;
                          objSettleList.Add(objSettleCls);
                      }


                  }
                  //objBusinessLayerTrficVioltnStlmnt.Update_TrafficVioltn(objEntityTrficVioltnStlmnt, objSettleList);
                  objBusinessLayerTrficVioltnStlmnt.ReOpenTrafficViolation(objEntityTrficVioltnStlmnt, objSettleList);
                  strResult = "success";
              }
          
         

        return strResult;
    }



    //Check 0012
    [WebMethod]
    public static string CheckDupReceiptNo(int intOrgId, int intCorpId, int intVhclId, string strReceiptNo, decimal decReceiptAmount, string strStatus)
    {

        clsBusinessLayerTrafficViolationSettlement objBusinessLayerTrficVioltnStlmnt = new clsBusinessLayerTrafficViolationSettlement();
        clsEntityTrafficViolationSettlement objEntityTrficVioltn = new clsEntityTrafficViolationSettlement();
        if (intVhclId == 0)
        {
            objEntityTrficVioltn.VehicleId = 0;
        }
        else
        {
            objEntityTrficVioltn.VehicleId = intVhclId;
        }
        objEntityTrficVioltn.Org_Id = intOrgId;
        objEntityTrficVioltn.CorporateId = intCorpId;
        objEntityTrficVioltn.ReceiptNo = strReceiptNo;
        DataTable dtReceiptDtls = objBusinessLayerTrficVioltnStlmnt.CheckDupReceiptNo(objEntityTrficVioltn);
        string strReceiptNoCount = "0";
        if (strStatus == "Save")
        {
            if (dtReceiptDtls.Rows.Count > 0)
            {
                strReceiptNoCount = "1";
            }
        }
        

        return strReceiptNoCount;
    }
    //check by trfviolation ID
    [WebMethod]
    public static string CheckDupReceiptNoByID(string strTrvID, string strTrvDtlID, string strAmntList, string strDtlList)
    {
        //Confirm
        string strResult = "fail";
        string[] strArrTrvID = strTrvID.Split(',');
        string[] strArrTrvDtlID = strTrvDtlID.Split(',');
        string[] strArrAmntList = strAmntList.Split(',');
        clsBusinessLayerTrafficViolationSettlement objBusinessLayerTrficVioltnStlmnt = new clsBusinessLayerTrafficViolationSettlement();
        clsEntityTrafficViolationSettlement objEntityTrficVioltnStlmnt = new clsEntityTrafficViolationSettlement();
        //string stores Receipt No(0), Employee id(1),ReceiptAmnt(2),VehicleId(3),UserId (4),OrgId(5),CorpId(6)
        string[] strTrafficVioDtls = strDtlList.Split(',');
        objEntityTrficVioltnStlmnt.ReceiptNo = strTrafficVioDtls[0].ToString();
        //string strReceiptNoCount = objBusinessLayerTrficVioltnStlmnt.CheckDupReceiptNo(objEntityTrficVioltnStlmnt);
        objEntityTrficVioltnStlmnt.Org_Id = Convert.ToInt32(strTrafficVioDtls[5]);
        objEntityTrficVioltnStlmnt.CorporateId = Convert.ToInt32(strTrafficVioDtls[6]);
        DataTable dtReceiptNos= objBusinessLayerTrficVioltnStlmnt.CheckDupReceiptNoByID(objEntityTrficVioltnStlmnt);
        
         if (dtReceiptNos.Rows.Count > 0)
            {
                        
                            //string str = dr["TRFCVIOLTN_ID"].ToString();

                            for (int i = 0; i < strArrTrvID.Length; i++)
                            {
                                if (strArrTrvID[i] != "")
                                {
                                    for (int intRowCount = dtReceiptNos.Rows.Count-1 ; intRowCount >= 0; intRowCount--)
                                    {
                                        DataRow dr = dtReceiptNos.Rows[intRowCount];
                                        
                                            if (dr["TRFCVIOLTN_ID"].ToString() == strArrTrvID[i])
                                            {
                                                //dr.Delete();
                                                dtReceiptNos.Rows.Remove(dr);
                                            }
                                        
                                    }
                                }
                            }
                        
                    
                
            }
            
                
                
            
        if (dtReceiptNos.Rows.Count > 0)
            {
                strResult = "Duplicate";
            }
            else
            {
                strResult = "success";
            }

        return strResult;
    }
   
}