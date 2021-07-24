using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using BL_Compzit;
using System.Text;
using System.Data;
using CL_Compzit;
using System.Web.Services;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_AWMS;
using EL_Compzit.EntityLayer_FMS;
using BL_Compzit.BusineesLayer_FMS;
using System.Globalization;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;



public partial class HCM_HCM_Master_hcm_PayrollSystem_hcm_End_Of_Service_Settmnt_hcm_End_Of_Service_Settmnt : System.Web.UI.Page
{
    public static string strCurrDateServer = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            txtRemarks.Text = "";
            lblEligibleSettlmt.Text = "";
            lblRejoinDate.Text = "";
            lblRefNo.Text = "";
            LoadEmployee();
            txtNetAmt.Enabled = false;
            txtLstSettlddate.Enabled = false;
            hiddenEdit.Value = "";
            hiddenView.Value = "";

            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableConfirm = 0;

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
            hiddenDate.Value = strCurrentDate;
            strCurrDateServer = strCurrentDate;

            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }


            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Leave_Settlement);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intEnableAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }

                }

                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    btnSave.Visible = true;
                    btnSaveClose.Visible = true;
                }
                else
                {
                    btnSave.Visible = false;
                    btnSaveClose.Visible = false;
                }

                if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        btnUpdate.Visible = true;
                    }
                    else
                    {
                        btnUpdate.Visible = false;
                    }

                    btnUpdateClose.Visible = true;
                }
                else
                {
                    btnUpdate.Visible = false;
                    btnUpdateClose.Visible = false;
                }

                if (intEnableConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    btnConfirm.Visible = true;
                }
                else
                {
                    btnConfirm.Visible = false;
                }

                clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
                clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();

                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityLeavSettlmt.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }

                if (Session["ORGID"] != null)
                {
                    objEntityLeavSettlmt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                    hiddenOrgId.Value = Session["ORGID"].ToString();
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }

                clsBusinessLayer objBusiness = new clsBusinessLayer();
                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_LEAVE_SETTLE_DAYS,
                                                            clsCommonLibrary.CORP_GLOBAL.ELIGIBLE_LEAVE_STLMNT_LMT,
                                                             clsCommonLibrary.CORP_GLOBAL.PAYROLL_INDIVIDUAL_ROUND,
                                                               clsCommonLibrary.CORP_GLOBAL.OFFDUTYDAYS_STATUS,
                                                               clsCommonLibrary.CORP_GLOBAL.WORKDAY_FIXED_PAYRL_MODE
                                                              };
                DataTable dtCorpDetail = new DataTable();
                dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
                if (dtCorpDetail.Rows.Count > 0)
                {
                    hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                    hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                    HiddenLeaveSettledDays.Value = dtCorpDetail.Rows[0]["GN_LEAVE_SETTLE_DAYS"].ToString();
                    HiddenFieldEligibleDaysLmt.Value = dtCorpDetail.Rows[0]["ELIGIBLE_LEAVE_STLMNT_LMT"].ToString();
                    HiddenFieldIndividualRound.Value = dtCorpDetail.Rows[0]["PAYROLL_INDIVIDUAL_ROUND"].ToString();
                    HiddenOFfdaysSts.Value = dtCorpDetail.Rows[0]["OFFDUTYDAYS_STATUS"].ToString();
                    HiddenFieldWorkdayFixedPayrlMode.Value = dtCorpDetail.Rows[0]["WORKDAY_FIXED_PAYRL_MODE"].ToString();
                }

                if (Request.QueryString["Id"] != null)
                {
                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string Id = strRandomMixedId.Substring(2, intLenghtofId);

                    Session["EDIT"] = Id;
                    string strId = Session["EDIT"].ToString();
                    Update(strId);
                    hiddenView.Value = strId;
                    if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            btnUpdate.Visible = true;
                        }
                        else
                        {
                            btnUpdate.Visible = false;
                        }

                        btnUpdateClose.Visible = true;
                    }
                    if (intEnableConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        btnConfirm.Visible = true;
                    }
                    else
                    {
                        btnConfirm.Visible = false;
                    }
                    btnCancel.Visible = true;
                    btnSave.Visible = false;
                    btnSaveClose.Visible = false;
                    btnClear.Visible = false;
                    lblHeader.InnerText = "Edit Leave Settlement";

                }
                else if (Request.QueryString["ViewId"] != null)
                {
                    string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string Id = strRandomMixedId.Substring(2, intLenghtofId);

                    Session["VIEW"] = Id;
                    string strId = Session["VIEW"].ToString();
                    hiddenView.Value = strId;
                    Update(strId);

                    lblHeader.InnerText = "View Leave Settlement";
                }
                else if (Request.QueryString["READ"] != null)
                {
                    string strId = Request.QueryString["READ"].ToString();
                    string strRandomMixedId = strId;
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string Id = strRandomMixedId.Substring(2, intLenghtofId);
                    hiddenView.Value = strId;
                    Update(Id);
                    txtRemarks.Enabled = false;
                    txtLevSalary.Enabled = false;
                    txtPrevMonthSalary.Enabled = false;
                    txtCurntMnthSalary.Enabled = false;
                    txtTicktAmt.Enabled = false;
                    txtOtherAmt.Enabled = false;
                    txtOtherDeductn.Enabled = false;
                    btnUpdate.Visible = false;
                    btnUpdateClose.Visible = false;
                    btnConfirm.Visible = false;
                    btnCancel.Visible = false;
                    btnProcess.Visible = false;
                    divList.Visible = false;
                    lblHeader.InnerText = "View Leave Settlement";
                }
                else
                {
                    txtdate.Value = hiddenDate.Value;
                    lblHeader.InnerText = "Add Leave Settlement";
                    btnUpdate.Visible = false;
                    btnUpdateClose.Visible = false;
                    btnConfirm.Visible = false;
                }



                // for adding comma
                clsEntityCommon objEntityCommon = new clsEntityCommon();
                if (hiddenDfltCurrencyMstrId.Value != "")
                {
                    objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                }
                DataTable dtCurrencyDetail = new DataTable();
                dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
                if (dtCurrencyDetail.Rows.Count > 0)
                {
                    hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
                }
            }
        }
    }

    public void LoadEmployee()
    {
        clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
        clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLeavSettlmt.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityLeavSettlmt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            hiddenOrgId.Value = Session["ORGID"].ToString();
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        DataTable dtCountry = objBusinessLeavSettlmt.ReadEmp(objEntityLeavSettlmt);

        ddlEmployee.Items.Clear();

        ddlEmployee.DataSource = dtCountry;

        ddlEmployee.DataTextField = "USR_NAME";
        ddlEmployee.DataValueField = "USR_ID";
        ddlEmployee.DataBind();

        ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");

    }

    [WebMethod]
    public static string LoadEmployeeLeaveDate(string strEmpId, string strCorpId, string strOrgId, string LeaveId, string Confirm, string varDisplyLeave)
    {
        clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
        clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string dtDate = "";
        string Leave = "";
        if (strEmpId != "")
        {
            objEntityLeavSettlmt.EmployeeId = Convert.ToInt32(strEmpId);
        }
        if (strCorpId != "")
        {
            objEntityLeavSettlmt.CorpId = Convert.ToInt32(strCorpId);
        }
        if (strOrgId != "")
        {
            objEntityLeavSettlmt.OrgId = Convert.ToInt32(strOrgId);
        }
        DataTable dtEmpRejoin = objBusinessLeavSettlmt.ReadRejoin(objEntityLeavSettlmt);
        DataTable dtEmpjoin = objBusinessLeavSettlmt.ReadJoinDt(objEntityLeavSettlmt);
        DataTable dtEmpLev = objBusinessLeavSettlmt.ReadInsertDt(objEntityLeavSettlmt);

        if (dtEmpRejoin.Rows.Count > 0 && dtEmpRejoin.Rows[0]["DUTYREJOIN_DATE"].ToString() != "")
        {
            dtDate = dtEmpRejoin.Rows[0]["DUTYREJOIN_DATE"].ToString();
        }
        else if (dtEmpjoin.Rows.Count > 0 && dtEmpjoin.Rows[0]["EMPERDTL_JOIN_DATE"].ToString() != "")
        {
            dtDate = dtEmpjoin.Rows[0]["EMPERDTL_JOIN_DATE"].ToString();
        }
        else if (dtEmpLev.Rows.Count > 0 && dtEmpLev.Rows[0]["USR_INS_DATE"].ToString() != "")
        {
            dtDate = dtEmpLev.Rows[0]["USR_INS_DATE"].ToString();
        }
        else if (dtEmpjoin.Rows.Count > 0 && dtEmpjoin.Rows[0]["USR_JOIN_DATE"].ToString() != "")
        {
            dtDate = dtEmpjoin.Rows[0]["USR_JOIN_DATE"].ToString();
        }

        DataTable dtLeavSettld = objBusinessLeavSettlmt.ReadLastSettldDt(objEntityLeavSettlmt);
        DateTime dtLastSettle = new DateTime();
        DateTime dtLastMonth = new DateTime();
        if (dtLeavSettld.Rows.Count > 0 && dtLeavSettld.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString() != "")
        {
            dtLastSettle = objCommon.textToDateTime(dtLeavSettld.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString());
        }
        DataTable dtLeavMonth = objBusinessLeavSettlmt.ReadMonthlyLastDate(objEntityLeavSettlmt);
        if (dtLeavMonth.Rows.Count > 0 && dtLeavMonth.Rows[0]["SLPRCDMNTH_LST_SETTLD_DT"].ToString() != "")
        {
            dtLastMonth = objCommon.textToDateTime(dtLeavMonth.Rows[0]["SLPRCDMNTH_LST_SETTLD_DT"].ToString());
        }
        if (dtLastSettle != DateTime.MinValue || dtLastMonth != DateTime.MinValue)
        {
            if (dtLastSettle > dtLastMonth)
            {
                dtDate = Convert.ToString(dtLastSettle.ToString("dd-MM-yyyy")); ;
            }
            else
            {
                dtDate = Convert.ToString(dtLastMonth.ToString("dd-MM-yyyy"));
            }
        }

        if (dtDate != "")
        {
            objEntityLeavSettlmt.SettlmtDate = objCommon.textToDateTime(dtDate);
        }
        string strdate = strCurrDateServer;
        objEntityLeavSettlmt.DateSettle = objCommon.textToDateTime(dtDate);
        StringBuilder sb = new StringBuilder();

        if (Confirm == "1")
        {
            objEntityLeavSettlmt.LeaveId = Convert.ToInt32(LeaveId);

            DataTable dtMonthlyLeave = objBusinessLeavSettlmt.ReadMonthlyConfirmLeave(objEntityLeavSettlmt);
            if (dtMonthlyLeave.Rows.Count > 0)
            {
                string Leave_id = "";
                sb.Append("<table class=\"list-group bg-grey\" style=\"width:100%;\" id=\"TableLeave\" >");
                for (int row1 = 0; row1 < dtMonthlyLeave.Rows.Count; row1++)
                {
                    if (!(Leave_id.Contains(dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString())))
                    {
                        Leave_id = Leave_id + "," + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString();
                        sb.Append("<tr class=\"list-group-item\" id=\"SelectRow" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\" style=\"padding: 3%;border: none;\">");
                        sb.Append("<td class=\"smart-form\" id=\"tdLeaveID" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\" style=\"display:none;width:55%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "</td>");
                        sb.Append("<td class=\"smart-form\" id=\"tdLeaveTotalCount" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\" style=\"display:none;width:55%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + dtMonthlyLeave.Rows[row1]["OPENING_NUMLEAVE"].ToString() + "</td>");
                        sb.Append("<td class=\"smart-form\" id=\"tdLeaveTakenCount" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\" style=\"display:none;width:55%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + dtMonthlyLeave.Rows[row1]["LEAVE_NUM_DAYS"].ToString() + "</td>");
                        sb.Append("<td class=\"smart-form\" id=\"tdLeaveBalance_Settle" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\" style=\"display:none;width:55%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + dtMonthlyLeave.Rows[row1]["USRLEAVTYP_SETTLELEAVE_REMAIN"].ToString() + "</td>");

                        if (LeaveId != "0")
                        {
                            if (LeaveId == dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString())
                            {
                                sb.Append("<td class=\"smart-form\" style=\"width:1%;word-break: break-all; word-wrap:break-word;text-align: left;\" > <label class=\"checkbox \" ><input type=\"checkbox\" disabled checked=\"true\" onchange=\"CheckboxCheck('" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "');\" onkeypress=\"return DisableEnter(event);\"  value=\"" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\" id=\"cbMandatory" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\"><i  style=\"margin-top:-45%;\"></i></label></td>");

                            }
                            else
                            {
                                sb.Append("<td class=\"smart-form\" style=\"width:1%;word-break: break-all; word-wrap:break-word;text-align: left;\" > <label class=\"checkbox \" ><input type=\"checkbox\" disabled onchange=\"CheckboxCheck('" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "');\" onkeypress=\"return DisableEnter(event);\"  value=\"" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\" id=\"cbMandatory" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\"><i  style=\"margin-top:-45%;\"></i></label></td>");

                            }
                        }
                        else
                        {
                            sb.Append("<td class=\"smart-form\" style=\"width:1%;word-break: break-all; word-wrap:break-word;text-align: left;\" > <label class=\"checkbox \" ><input type=\"checkbox\"  disabled onchange=\"CheckboxCheck('" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "');\" onkeypress=\"return DisableEnter(event);\"  value=\"" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\" id=\"cbMandatory" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\"><i  style=\"margin-top:-45%;\"></i></label></td>");
                        }
                        if (dtMonthlyLeave.Rows[row1]["LEAVE_TO_DATE"].ToString() != "")
                        {
                            sb.Append("<td class=\"smart-form\" id=\"tdLeaveDate" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\" style=\"width:80%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + dtMonthlyLeave.Rows[row1]["LEAVE_FROM_DATE"].ToString() + " - " + dtMonthlyLeave.Rows[row1]["LEAVE_TO_DATE"].ToString() + "</td>");
                            sb.Append("<td class=\"smart-form\" id=\"tdLeaveFrmDate" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\" style=\"width:80%;word-break: break-all; word-wrap:break-word;text-align: left;display:none;\">" + dtMonthlyLeave.Rows[row1]["LEAVE_FROM_DATE"].ToString() + "</td>");
                        }
                        else if (dtMonthlyLeave.Rows[row1]["LEAVE_TO_DATE"].ToString() == "" && dtMonthlyLeave.Rows[row1]["LEAVE_FROM_DATE"].ToString() != "")
                        {

                            sb.Append("<td class=\"smart-form\" id=\"tdLeaveFrmDate" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\" style=\"width:80%;word-break: break-all; word-wrap:break-word;text-align: left;display:none;\">" + dtMonthlyLeave.Rows[row1]["LEAVE_FROM_DATE"].ToString() + "</td>");
                            sb.Append("<td class=\"smart-form\" id=\"tdLeaveDate" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\" style=\"width:80%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + dtMonthlyLeave.Rows[row1]["LEAVE_FROM_DATE"].ToString() + "</td>");
                        }
                        sb.Append("</tr>");
                    }

                }

                sb.Append("</table>");
            }
        }
        else
        {
            DataTable dtMonthlyLeave = objBusinessLeavSettlmt.ReadMonthlyLeaveForMultipleYrs(objEntityLeavSettlmt);
            ////  tdLeaveTakenCount
            if (dtMonthlyLeave.Rows.Count > 0)
            {
                string LeaveType_id = "";
                sb.Append("<table class=\"list-group bg-grey\" style=\"width:100%;\" id=\"TableLeave\" >");
                for (int row1 = 0; row1 < dtMonthlyLeave.Rows.Count; row1++)
                {
                    DateTime dtFrom = new DateTime();
                    DateTime dtDateNow = new DateTime();
                    if (dtMonthlyLeave.Rows[row1]["LEAVE_FROM_DATE"].ToString() != "")
                    {
                        dtFrom = objCommon.textToDateTime(dtMonthlyLeave.Rows[row1]["LEAVE_FROM_DATE"].ToString());
                    }
                    //EVM-0027 18-10-2019
                    string strDay = dtFrom.DayOfWeek.ToString();

                    //END
                    dtDateNow = objCommon.textToDateTime(strCurrDateServer);
                    int DateDiff = Convert.ToInt32((dtFrom - dtDateNow).TotalDays);
                    //temp modification - past date is allowed 
                    if (DateDiff <= Convert.ToInt32(varDisplyLeave))// && dtFrom >= dtDateNow)
                    {
                        if (!(LeaveType_id.Contains(dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString())))
                        {
                            LeaveType_id = LeaveType_id + "," + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString();
                            decimal intLeavNum = Convert.ToDecimal(dtMonthlyLeave.Rows[row1]["LEAVE_NUM_DAYS"].ToString());
                            if (strDay == "Friday")
                            {
                                intLeavNum = intLeavNum - 1;
                            }
                            sb.Append("<tr class=\"list-group-item\" id=\"SelectRow" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\" style=\"padding: 3%;border: none;\">");
                            sb.Append("<td class=\"smart-form\" id=\"tdLeaveID" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\" style=\"display:none;width:55%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "</td>");
                            sb.Append("<td class=\"smart-form\" id=\"tdLeaveTotalCount" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\" style=\"display:none;width:55%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + dtMonthlyLeave.Rows[row1]["OPENING_NUMLEAVE"].ToString() + "</td>");
                            sb.Append("<td class=\"smart-form\" id=\"tdLeaveTakenCount" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\" style=\"display:none;width:55%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + intLeavNum.ToString() + "</td>");
                            sb.Append("<td class=\"smart-form\" id=\"tdLeaveBalance_Settle" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\" style=\"display:none;width:55%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + dtMonthlyLeave.Rows[row1]["USRLEAVTYP_SETTLELEAVE_REMAIN"].ToString() + "</td>");

                            if (LeaveId != "0")
                            {
                                if (LeaveId == dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString())
                                {
                                    sb.Append("<td class=\"smart-form\" style=\"width:1%;word-break: break-all; word-wrap:break-word;text-align: left;\" > <label class=\"checkbox \" ><input type=\"checkbox\" checked=\"true\" onclick=\"CheckboxCheck('" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "');\" onkeypress=\"return DisableEnter(event);\"  value=\"" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\" id=\"cbMandatory" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\"><i  style=\"margin-top:-45%;\"></i></label></td>");
                                }
                                else
                                {
                                    sb.Append("<td class=\"smart-form\" style=\"width:1%;word-break: break-all; word-wrap:break-word;text-align: left;\" > <label class=\"checkbox \" ><input type=\"checkbox\" onclick=\"CheckboxCheck('" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "');\" onkeypress=\"return DisableEnter(event);\"  value=\"" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\" id=\"cbMandatory" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\"><i  style=\"margin-top:-45%;\"></i></label></td>");

                                }
                            }
                            else
                            {
                                sb.Append("<td class=\"smart-form\" style=\"width:1%;word-break: break-all; word-wrap:break-word;text-align: left;\" > <label class=\"checkbox \" ><input type=\"checkbox\" onclick=\"CheckboxCheck('" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "');\" onkeypress=\"return DisableEnter(event);\"  value=\"" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\" id=\"cbMandatory" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\"><i  style=\"margin-top:-45%;\"></i></label></td>");
                            }
                            if (dtMonthlyLeave.Rows[row1]["LEAVE_TO_DATE"].ToString() != "")
                            {

                                sb.Append("<td class=\"smart-form\" id=\"tdLeaveFrmDate" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\" style=\"width:80%;word-break: break-all; word-wrap:break-word;text-align: left;display:none;\">" + dtMonthlyLeave.Rows[row1]["LEAVE_FROM_DATE"].ToString() + "</td>");
                                sb.Append("<td class=\"smart-form\" id=\"tdLeaveDate" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\" style=\"width:80%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + dtMonthlyLeave.Rows[row1]["LEAVE_FROM_DATE"].ToString() + " - " + dtMonthlyLeave.Rows[row1]["LEAVE_TO_DATE"].ToString() + "</td>");
                            }
                            else if (dtMonthlyLeave.Rows[row1]["LEAVE_TO_DATE"].ToString() == "" && dtMonthlyLeave.Rows[row1]["LEAVE_FROM_DATE"].ToString() != "")
                            {

                                sb.Append("<td class=\"smart-form\" id=\"tdLeaveFrmDate" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\" style=\"width:80%;word-break: break-all; word-wrap:break-word;text-align: left;display:none;\">" + dtMonthlyLeave.Rows[row1]["LEAVE_FROM_DATE"].ToString() + "</td>");
                                sb.Append("<td class=\"smart-form\" id=\"tdLeaveDate" + dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString() + "\" style=\"width:80%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + dtMonthlyLeave.Rows[row1]["LEAVE_FROM_DATE"].ToString() + "</td>");
                            }
                            sb.Append("</tr>");
                        }
                    }
                }
                sb.Append("</table>");
            }
        }
        Leave = sb.ToString();
        return Leave;
    }

    public static decimal CalculateDays(DateTime dtFrom, DateTime dtTo)
    {
        decimal TotalDays = Convert.ToInt32((dtTo - dtFrom).TotalDays) + 1;
        if (TotalDays > 365)
        {
            TotalDays = 365;
        }
        if (TotalDays < 0)
        {
            TotalDays = 0;
        }
        return TotalDays;
    }


    [WebMethod]
    public static string[] EmployeeDetails(string strEmpId, string strCorpId, string strOrgId, string DecimalCnt, string LeaveId, string tdOpenLeave, string tdLeaveTaken, string tdLeaveDate, string tdLeaveBalance_Settle, string Mode, string varDate, string IndividualRound,string OffDaysSts)
    {
        //IndividualRound = "0";
        //strJson[2] strJson[30]
        string[] strJson = new string[35];

        try
        {
            clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
            clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            if (strEmpId != "--SELECT EMPLOYEE--" && strEmpId != "")
            {
                strJson[34] = "0";
                objEntityLeavSettlmt.EmployeeId = Convert.ToInt32(strEmpId);
                objEntityLeavSettlmt.CorpId = Convert.ToInt32(strCorpId);
                objEntityLeavSettlmt.OrgId = Convert.ToInt32(strOrgId);

                DateTime dProbEnddate = new DateTime();
                DataTable dtProb = objBusinessLeavSettlmt.ReadProbationEnddate(objEntityLeavSettlmt);
                if (dtProb.Rows.Count > 0 && dtProb.Rows[0][0].ToString() != "")
                {
                    dProbEnddate = objCommon.textToDateTime(dtProb.Rows[0][0].ToString());
                }


                DateTime dtFinal = new DateTime();
                cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
                cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
                objEnt.Employee = Convert.ToInt32(strEmpId); ;
                DataTable dtLeavMonth11 = objBuss.ReadLastLeaveStlDate(objEnt);
                if (dtLeavMonth11.Rows.Count > 0)
                {
                    for (int i = 0; i < dtLeavMonth11.Rows.Count; i++)
                    {
                        if (dtLeavMonth11.Rows[i]["LEVSETLMT_LST_SETLMTDATE"].ToString() != "" && dtLeavMonth11.Rows[i][1].ToString() == "1")
                        {
                            dtFinal = objCommon.textToDateTime(dtLeavMonth11.Rows[i]["LEVSETLMT_LST_SETLMTDATE"].ToString());
                            dtFinal = dtFinal.AddDays(1);
                        }
                    }
                }



                //Start:-Read opening balance paid leave counts
                decimal decOpenLeaveCntPrev = 0;
                int OpenYear = 0;
                DataTable dtOpenLeaveinfo = objBusinessLeavSettlmt.ReadOpeningLeaveInfo(objEntityLeavSettlmt);
                if (dtOpenLeaveinfo.Rows.Count > 0)
                {
                    decOpenLeaveCntPrev = Convert.ToDecimal(dtOpenLeaveinfo.Rows[0]["BALANCE_NUMLEAVE"].ToString());
                    OpenYear = Convert.ToInt32(dtOpenLeaveinfo.Rows[0]["OPUSLETYP_YEAR"].ToString());
                }
                strJson[33] = decOpenLeaveCntPrev.ToString();
                //if (IndividualRound == "1")
                //{
                //    strJson[30] = decOpenLeaveCntPrev.ToString("0.00");
                //}
                //else
                //{
                //    strJson[30] = decOpenLeaveCntPrev.ToString("0.00");
                //}
                // strJson[30] = decOpenLeaveCntPrev.ToString("0.00");
                //End:-Read opening balance paid leave counts

                DataTable dtEmp = objBusinessLeavSettlmt.ReadEmpDtls(objEntityLeavSettlmt);
                if (dtEmp.Rows.Count > 0)
                {
                    strJson[0] = dtEmp.Rows[0]["EMPERDTL_EMPLOYEE_ID"].ToString().ToUpper();
                }
                DataTable dtEmpLeaveTypes = objBusinessLeavSettlmt.ReadEmpLeaveTypes(objEntityLeavSettlmt);
                string strHtml = "";
                for (int i = 0; i < dtEmpLeaveTypes.Rows.Count; i++)
                {
                    strHtml += dtEmpLeaveTypes.Rows[i][0].ToString() + "\n";
                }
                strJson[28] = strHtml;


                DataTable dtEmpRejoin = objBusinessLeavSettlmt.ReadRejoin(objEntityLeavSettlmt);
                DataTable dtEmpjoin = objBusinessLeavSettlmt.ReadJoinDt(objEntityLeavSettlmt);
                DataTable dtEmpLev = objBusinessLeavSettlmt.ReadInsertDt(objEntityLeavSettlmt);
                DataTable dtEmpOpenRejoin = objBusinessLeavSettlmt.ReadOpenRejoin(objEntityLeavSettlmt);

                decimal decTotalEligibleLeav=0;
                int rejoinHalfDay = 0;
                string strRejoinJoinDate = "";
                if (dtEmpRejoin.Rows.Count > 0 && dtEmpRejoin.Rows[0]["DUTYREJOIN_DATE"].ToString() != "")
                {
                    strJson[1] = dtEmpRejoin.Rows[0]["DUTYREJOIN_DATE"].ToString();
                    strRejoinJoinDate = dtEmpRejoin.Rows[0]["DUTYREJOIN_DATE"].ToString();
                    rejoinHalfDay = Convert.ToInt32(dtEmpRejoin.Rows[0]["HALFDAY_STATUS"].ToString());
                }
                else if (dtEmpOpenRejoin.Rows.Count > 0 && dtEmpOpenRejoin.Rows[0]["USRJDT_ACT_DATE"].ToString() != "")
                {
                    strJson[1] = dtEmpOpenRejoin.Rows[0]["USRJDT_ACT_DATE"].ToString();
                    strRejoinJoinDate = dtEmpOpenRejoin.Rows[0]["USRJDT_CALC_DATE"].ToString();
                }
                else if (dtEmpjoin.Rows.Count > 0 && dtEmpjoin.Rows[0]["EMPERDTL_JOIN_DATE"].ToString() != "")
                {
                    strJson[1] = dtEmpjoin.Rows[0]["EMPERDTL_JOIN_DATE"].ToString();
                    strRejoinJoinDate = dtEmpjoin.Rows[0]["EMPERDTL_JOIN_DATE"].ToString();
                }
                else if (dtEmpLev.Rows.Count > 0 && dtEmpLev.Rows[0]["USR_INS_DATE"].ToString() != "")
                {
                    strJson[1] = dtEmpLev.Rows[0]["USR_INS_DATE"].ToString();
                    strRejoinJoinDate = dtEmpLev.Rows[0]["USR_INS_DATE"].ToString();
                }
                else if (dtEmpjoin.Rows.Count > 0 && dtEmpjoin.Rows[0]["USR_JOIN_DATE"].ToString() != "")
                {
                    strJson[1] = dtEmpjoin.Rows[0]["USR_JOIN_DATE"].ToString();
                    strRejoinJoinDate = dtEmpjoin.Rows[0]["USR_JOIN_DATE"].ToString();
                }

                DataTable dtTotalLeavTaken = objBusinessLeavSettlmt.ReadEmpLeav(objEntityLeavSettlmt);
                DateTime Today = objCommon.textToDateTime(strCurrDateServer);
                string Year = Today.ToString("yyyy");
                decimal RemainLeav = 0;
                string RemainLeavDeductUser = "";
                DateTime Date1 = new DateTime();
                DateTime Date2 = new DateTime();
                DateTime Date3 = new DateTime();
                 int flag = 0;

                if (Mode == "0") //Settlement mode by leave
                {
                    if (strRejoinJoinDate != "")
                    {
                        Date1 = objCommon.textToDateTime(strRejoinJoinDate);
                    }
                    DataTable dtLeavSettld = objBusinessLeavSettlmt.ReadLastSettldDt(objEntityLeavSettlmt);
                    DateTime dtLastSettle = new DateTime();
                    DateTime dtLastMonth = new DateTime();
                    if (dtLeavSettld.Rows.Count > 0 && dtLeavSettld.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString() != "")
                    {
                        dtLastSettle = objCommon.textToDateTime(dtLeavSettld.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString());
                    }
                    if (dtLastSettle != DateTime.MinValue || dtLastMonth != DateTime.MinValue)
                    {
                        if (dtLastSettle > Date1)
                        {
                            Date1 = dtLastSettle;
                        }
                    }
                    if (dtFinal != DateTime.MinValue)
                    {
                        if (dtFinal > Date1)
                        {
                            Date1 = dtFinal;
                        }
                    }
                    int OffCount = 0;
                    if (tdLeaveDate != "")
                    {
                        string UserLeaveDeduct = "";
                        string[] LeaveDate = tdLeaveDate.Split(' ');
                        if (LeaveDate.Length == 3)
                        {
                           
                            //start Date--- Date2 Off Days
                            Date2 = objCommon.textToDateTime(LeaveDate[0]);
                            objEntityLeavSettlmt.FromDate = Date2;
                            DateTime dtTodate = new DateTime();
                            dtTodate = objCommon.textToDateTime(LeaveDate[2]);
                            //int offDutySatus=1;

                            //if (OffDaysSts == "1")
                            //{
                                dutyOf objDuty = new dutyOf();
                                DateTime datenow, enddate;
                                
                                datenow = Date2;
                                enddate = dtTodate;
                                int stsHol = 0;
                                //for (var day = datenow; day <= enddate; day = day.AddDays(1))
                                //{
                                //    string hol = objDuty.checkholiday(day, datenow, enddate);
                                //    if (hol == "true")
                                //    {
                                //        stsHol = 1;
                                //        OffCount = OffCount + 1;
                                //    }
                                //    else
                                //    {
                                //        break;
                                //    }

                                //}
                                //if (stsHol == 0)
                                //{
                                //    for (var day = datenow; day <= enddate; day = day.AddDays(1))
                                //    {
                                //        string off = objDuty.CheckDutyOff(day, strCorpId, strOrgId);
                                //        if (off == "true")
                                //        {
                                //            OffCount = OffCount + 1;
                                //        }
                                //        else
                                //        {
                                //            break;
                                //        }
                                //    }
                                //}


                                for (var day = datenow; day <= enddate; day = day.AddDays(1))
                                {
                                    string hol = objDuty.checkholiday(day, datenow, enddate);
                                    if (hol == "true")
                                    {
                                        OffCount = OffCount + 1;
                                    }
                                    if (hol != "true")
                                    {
                                        string off = objDuty.CheckDutyOff(day, strCorpId, strOrgId);
                                        if (off == "true")
                                        {
                                            OffCount = OffCount + 1;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                        
                            string[] FromDate = LeaveDate[0].Split('-');
                            if (FromDate[0] == "01" || FromDate[0] == "1")
                            {
                                string[] ToDate = LeaveDate[2].Split('-');

                                if (Convert.ToInt32(ToDate[0]) < DateTime.DaysInMonth(Convert.ToInt32(ToDate[2]), Convert.ToInt32(ToDate[1])))
                                {
                                    strJson[13] = "true";
                                }
                            }
                            UserLeaveDeduct = LeaveDate[2];
                            Date3 = objCommon.textToDateTime(LeaveDate[2]);
                        }
                        else if (LeaveDate.Length == 2)
                        {
                            UserLeaveDeduct = LeaveDate[0];
                            Date3 = objCommon.textToDateTime(LeaveDate[0]);
                        }
                    }

                    DateTime dtFrom = Date1;
                    DateTime dtTo=new DateTime();
                    dtTo = Date2.AddDays(-1);
                 
                    int OnProbationSts=0;
                    if (dProbEnddate != DateTime.MinValue && dtTo <= dProbEnddate)
                    {
                        OnProbationSts = 1;                      
                    }
                    


                    strJson[31] = Date1.ToString("dd-MM-yyyy");
                    strJson[32] = dtTo.ToString("dd-MM-yyyy");
                    DateTime dtJoinDate = new DateTime();
                    int FromYear = dtFrom.Year;
                    int ToYear = dtTo.Year;
                    int CurrYear = Today.Year;
                    decimal PrevYearBalLeave = 0, CurrYearBalLeave = 0, NextYearBalLeave = 0;
                    decimal CurrYearDays = 0, NextYearDays = 0, JoinDateDays = 365;
                    decimal LeaveEligbleDays = 0;
                    string SetlmtnRemainUpd = "";

                    if (OnProbationSts == 0)
                    {

                        //LeaveEligbleDays += decOpenLeaveCntPrev;
                        if (dtEmpjoin.Rows.Count > 0 && dtEmpjoin.Rows[0]["EMPERDTL_JOIN_DATE"].ToString() != "")
                        {
                            dtJoinDate = objCommon.textToDateTime(dtEmpjoin.Rows[0]["EMPERDTL_JOIN_DATE"].ToString());
                            if (dtJoinDate.Year == dtFrom.Year)
                            {
                                JoinDateDays = CalculateDays(dtJoinDate, new DateTime(dtJoinDate.Year, 12, 31));
                            }
                        }
                        if (FromYear == ToYear)
                        {
                            CurrYearDays = CalculateDays(dtFrom, dtTo);
                        }
                        else
                        {
                            int YearDiff = ToYear - FromYear;
                            if (dtFrom.Year == CurrYear)
                            {
                                DateTime NewToDate = new DateTime(dtFrom.Year, 12, 31);
                                CurrYearDays = CalculateDays(dtFrom, NewToDate);
                            }
                            if (dtTo.Year == CurrYear)
                            {
                                DateTime NewFromDate = new DateTime(dtTo.Year, 1, 1);
                                CurrYearDays = CalculateDays(NewFromDate, dtTo);
                            }
                            else if (YearDiff > 1)
                            {
                                DateTime NewFromDatep = new DateTime(CurrYear, 1, 1);
                                DateTime NewToDate = new DateTime(CurrYear, 12, 31);
                                if (NewToDate > dtTo)
                                {
                                    NewToDate = dtTo;
                                }
                                CurrYearDays = CalculateDays(NewFromDatep, NewToDate);
                            }
                            if (dtTo.Year > CurrYear)
                            {
                                DateTime NewFromDate = new DateTime(dtTo.Year, 1, 1);
                                NextYearDays = CalculateDays(NewFromDate, dtTo);
                            }
                        }
                        if (rejoinHalfDay == 1)
                        {
                            CurrYearDays = CurrYearDays - (decimal)0.5;
                        }
                        objEntityLeavSettlmt.Year = Date3.Year;
                        DataTable dtLeav = objBusinessLeavSettlmt.ReadEligibleLeaveCount(objEntityLeavSettlmt);
                        if (dtLeav.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtLeav.Rows.Count; i++)
                            {
                                int dtDear = Convert.ToInt32(dtLeav.Rows[i]["USRLEAVTYP_YEAR"].ToString());
                                if (dtLeav.Rows[i]["USRLEAVTYP_SETTLEMENT_LEAVE"].ToString() != "")
                                {
                                    if (dtDear < CurrYear)
                                    {
                                        PrevYearBalLeave = Convert.ToDecimal(dtLeav.Rows[i]["USRLEAVTYP_SETTLELEAVE_REMAIN"].ToString());
                                        LeaveEligbleDays += PrevYearBalLeave;
                                        SetlmtnRemainUpd = SetlmtnRemainUpd + "," + dtLeav.Rows[i]["LEAVETYP_ID"].ToString() + "-" + dtDear + "-" + PrevYearBalLeave;
                                    }
                                    else if (dtDear == CurrYear)
                                    {
                                        CurrYearBalLeave = Convert.ToDecimal(dtLeav.Rows[i]["USRLEAVTYP_SETTLEMENT_LEAVE"].ToString());
                                        if (dtJoinDate.Year == dtDear)
                                        {
                                            LeaveEligbleDays += (CurrYearBalLeave / JoinDateDays) * CurrYearDays;
                                            SetlmtnRemainUpd = SetlmtnRemainUpd + "," + dtLeav.Rows[i]["LEAVETYP_ID"].ToString() + "-" + dtDear + "-" + (CurrYearBalLeave / JoinDateDays) * CurrYearDays;
                                        }
                                        else
                                        {
                                            LeaveEligbleDays += (CurrYearBalLeave / 365) * CurrYearDays;
                                            SetlmtnRemainUpd = SetlmtnRemainUpd + "," + dtLeav.Rows[i]["LEAVETYP_ID"].ToString() + "-" + dtDear + "-" + (CurrYearBalLeave / 365) * CurrYearDays;
                                        }
                                    }
                                    if (dtDear > CurrYear)
                                    {
                                        NextYearBalLeave = Convert.ToDecimal(dtLeav.Rows[i]["USRLEAVTYP_SETTLEMENT_LEAVE"].ToString());
                                        LeaveEligbleDays += (NextYearBalLeave / 365) * NextYearDays;
                                        SetlmtnRemainUpd = SetlmtnRemainUpd + "," + dtLeav.Rows[i]["LEAVETYP_ID"].ToString() + "-" + dtDear + "-" + (NextYearBalLeave / 365) * NextYearDays;
                                    }
                                }
                            }
                        }
                        RemainLeav = LeaveEligbleDays;
                        RemainLeavDeductUser = SetlmtnRemainUpd;
                        decTotalEligibleLeav = decOpenLeaveCntPrev + RemainLeav;
                    }
                }
                else //Settlement mode by total eligile days
                {
                    if (strRejoinJoinDate != "")
                    {
                        Date1 = objCommon.textToDateTime(strRejoinJoinDate);
                    }
                    DataTable dtLeavSettld = objBusinessLeavSettlmt.ReadLastSettldDt(objEntityLeavSettlmt);
                    DateTime dtLastSettle = new DateTime();
                    DateTime dtLastMonth = new DateTime();
                    if (dtLeavSettld.Rows.Count > 0 && dtLeavSettld.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString() != "")
                    {
                        dtLastSettle = objCommon.textToDateTime(dtLeavSettld.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString());
                    }
                    DataTable dtLeavMonth = objBusinessLeavSettlmt.ReadMonthlyLastDate(objEntityLeavSettlmt);
                    if (dtLastSettle != DateTime.MinValue || Date1 != DateTime.MinValue)
                    {
                        if (dtLastSettle > Date1)
                        {
                            Date1 = dtLastSettle;
                        }
                    }
                    if (dtFinal != DateTime.MinValue)
                    {
                        if (dtFinal > Date1)
                        {
                            Date1 = dtFinal;
                        }
                    }

                    if (varDate != null)
                    {
                        Date2 = objCommon.textToDateTime(varDate);
                    }



                    //Start:-Insert to GN_USER_LEAVE_TYPES

                    clsBusinessLeaveRequest objBusinessLeaveRequest = new clsBusinessLeaveRequest();
                    clsEntityLeaveRequest objEntityLeaveRequest = new clsEntityLeaveRequest();
                    if (strCorpId != null && strCorpId != "")
                    {
                        objEntityLeaveRequest.Corporate_id = Convert.ToInt32(strCorpId);
                    }
                    if (strOrgId != null && strOrgId != "")
                    {
                        objEntityLeaveRequest.Organisation_id = Convert.ToInt32(strOrgId);
                    }
                    if (strEmpId != null && strEmpId != "")
                    {
                        objEntityLeaveRequest.User_Id = Convert.ToInt32(strEmpId);
                    }
                    DataTable DtLevAlloDetails = objBusinessLeaveRequest.ReadLeavTypdtl(objEntityLeaveRequest);
                    DataTable DtUser = objBusinessLeaveRequest.ReadUserDetails(objEntityLeaveRequest);
                    string UsrDesg = DtUser.Rows[0]["DSGN_ID"].ToString();
                    string UsrJoinDate = DtUser.Rows[0]["EMPERDTL_JOIN_DATE"].ToString();
                    string UsrGender = DtUser.Rows[0]["EMPERDTL_GENDER"].ToString();
                    string UsrMrtlSts = DtUser.Rows[0]["EMPERDTL_MRTL_STS"].ToString();
                    string UsrPayGrd = DtUser.Rows[0]["PYGRD_ID"].ToString();

                    foreach (DataRow rowDepnt in DtLevAlloDetails.Rows)
                    {
                        string GendrChck = "false", MrtlChck = "false", DesgChck = "false", PayGrdChck = "false", ExpChck = "false";
                        objEntityLeaveRequest.Leave_Id = Convert.ToInt32(rowDepnt["LEAVETYP_ID"].ToString());
                        DataTable dtGendrMrtSts = objBusinessLeaveRequest.ReadGendrMrtSts(objEntityLeaveRequest);
                        DataTable dtDesgDtls = objBusinessLeaveRequest.ReadDesgDtls(objEntityLeaveRequest);
                        DataTable dtPayGrdeDtls = objBusinessLeaveRequest.ReadPayGrdedtls(objEntityLeaveRequest);
                        DataTable dtExpDtls = objBusinessLeaveRequest.ReadExpDtls(objEntityLeaveRequest);

                        //For gender check
                        if (dtGendrMrtSts.Rows.Count > 0)
                        {
                            if (dtGendrMrtSts.Rows[0][0].ToString() == "2")
                            {
                                GendrChck = "true";
                            }
                            else if (dtGendrMrtSts.Rows[0][0].ToString() == UsrGender)
                            {
                                GendrChck = "true";
                            }
                        }
                        //For marrital status
                        if (dtGendrMrtSts.Rows.Count > 0)
                        {
                            if (dtGendrMrtSts.Rows[0][1].ToString() == "2")
                            {
                                MrtlChck = "true";
                            }
                            else if (dtGendrMrtSts.Rows[0][1].ToString() != UsrGender)
                            {
                                MrtlChck = "true";
                            }
                        }
                        //For Designation 
                        if (dtDesgDtls.Rows.Count > 0)
                        {
                            if (dtDesgDtls.Rows[0][1].ToString() == "1")
                            {
                                DesgChck = "true";
                            }
                            else
                            {
                                foreach (DataRow rowDesg in dtDesgDtls.Rows)
                                {
                                    if (rowDesg[0].ToString() == UsrDesg)
                                    {
                                        DesgChck = "true";
                                        break;
                                    }
                                }
                            }
                        }
                        //For paygrade
                        if (dtPayGrdeDtls.Rows.Count > 0)
                        {
                            if (dtPayGrdeDtls.Rows[0][1].ToString() == "1")
                            {
                                PayGrdChck = "true";
                            }
                            else
                            {
                                foreach (DataRow rowDesg in dtPayGrdeDtls.Rows)
                                {
                                    if (rowDesg[0].ToString() == UsrPayGrd)
                                    {
                                        PayGrdChck = "true";
                                        break;
                                    }
                                }
                            }
                        }
                        //For experience
                        decimal ExpYears = 0;
                        if (UsrJoinDate != "")
                        {
                            DateTime dtTod = objCommon.textToDateTime(strCurrDateServer);
                            DateTime Dob = objCommon.textToDateTime(UsrJoinDate);
                            ExpYears = (dtTod.Month - Dob.Month) + 12 * (dtTod.Year - Dob.Year);
                            ExpYears = ExpYears / 12;
                        }
                        if (dtExpDtls.Rows.Count > 0)
                        {
                            if (dtExpDtls.Rows[0][1].ToString() == "1")
                            {
                                ExpChck = "true";
                            }
                            else
                            {
                                foreach (DataRow rowDesg in dtExpDtls.Rows)
                                {
                                    int intMinYear = Convert.ToInt32(rowDesg[2]);
                                    int intMaxYear = Convert.ToInt32(rowDesg[3]);
                                    if (ExpYears >= intMinYear && ExpYears <= intMaxYear)
                                    {
                                        ExpChck = "true";
                                    }

                                }
                            }
                        }
                        if ((DesgChck == "true" || ExpChck == "true" || PayGrdChck == "true") && (GendrChck == "true" && MrtlChck == "true"))
                        {
                        }
                        else
                        {
                            rowDepnt.Delete();
                        }
                    }
                    DtLevAlloDetails.AcceptChanges();
                    for (int i = 0; i < DtLevAlloDetails.Rows.Count; i++)
                    {
                        string strchkuserlevCount = "0";
                        objEntityLeaveRequest.LeaveFrmDate = Date2;
                        objEntityLeaveRequest.Leave_Id = Convert.ToInt32(DtLevAlloDetails.Rows[i]["LEAVETYP_ID"].ToString());
                        strchkuserlevCount = objBusinessLeaveRequest.chkUserLevCount(objEntityLeaveRequest);
                        objEntityLeaveRequest.OpeningLv = Convert.ToDecimal(DtLevAlloDetails.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                        objEntityLeaveRequest.RemingLev = Convert.ToDecimal(DtLevAlloDetails.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                        if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                        {
                        }
                        else
                        {
                            objBusinessLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);
                        }
                    }
                    //End:-Insert to GN_USER_LEAVE_TYPES


                    DateTime dtFrom = Date1;
                    DateTime dtTo = Date2;
                    strJson[31] = Date1.ToString("dd-MM-yyyy");
                    strJson[32] = Date2.ToString("dd-MM-yyyy");
                    DateTime dtJoinDate = new DateTime();
                    int FromYear = dtFrom.Year;
                    int ToYear = dtTo.Year;
                    int CurrYear = Today.Year;
                    decimal PrevYearBalLeave = 0, CurrYearBalLeave = 0, NextYearBalLeave = 0;
                    decimal CurrYearDays = 0, NextYearDays = 0, JoinDateDays = 365;
                    decimal LeaveEligbleDays = 0;
                    string SetlmtnRemainUpd = "";


                    int OnProbationSts = 0;
                    if (dProbEnddate != DateTime.MinValue && dtTo <= dProbEnddate)
                    {
                        OnProbationSts = 1;
                        strJson[34] = "1";
                    }

                    if (OnProbationSts == 0)
                    {

                        //LeaveEligbleDays += decOpenLeaveCntPrev;
                        if (dtEmpjoin.Rows.Count > 0 && dtEmpjoin.Rows[0]["EMPERDTL_JOIN_DATE"].ToString() != "")
                        {
                            dtJoinDate = objCommon.textToDateTime(dtEmpjoin.Rows[0]["EMPERDTL_JOIN_DATE"].ToString());
                            if (dtJoinDate.Year == dtFrom.Year)
                            {
                                JoinDateDays = CalculateDays(dtJoinDate, new DateTime(dtJoinDate.Year, 12, 31));
                            }
                        }
                        if (FromYear == ToYear)
                        {
                            CurrYearDays = CalculateDays(dtFrom, dtTo);
                        }
                        else
                        {
                            int YearDiff = ToYear - FromYear;
                            if (dtFrom.Year == CurrYear)
                            {
                                DateTime NewToDate = new DateTime(dtFrom.Year, 12, 31);
                                CurrYearDays = CalculateDays(dtFrom, NewToDate);
                            }
                            if (dtTo.Year == CurrYear)
                            {
                                DateTime NewFromDate = new DateTime(dtTo.Year, 1, 1);
                                CurrYearDays = CalculateDays(NewFromDate, dtTo);
                            }
                            else if (YearDiff > 1)
                            {
                                DateTime NewFromDatep = new DateTime(CurrYear, 1, 1);
                                DateTime NewToDate = new DateTime(CurrYear, 12, 31);
                                if (NewToDate > dtTo)
                                {
                                    NewToDate = dtTo;
                                }
                                CurrYearDays = CalculateDays(NewFromDatep, NewToDate);
                            }
                            if (dtTo.Year > CurrYear)
                            {
                                DateTime NewFromDate = new DateTime(dtTo.Year, 1, 1);
                                NextYearDays = CalculateDays(NewFromDate, dtTo);
                            }
                        }
                        if (rejoinHalfDay == 1)
                        {
                            CurrYearDays = CurrYearDays - (decimal)0.5;
                        }
                        objEntityLeavSettlmt.Year = Date2.Year;
                        DataTable dtLeav = objBusinessLeavSettlmt.ReadEligibleLeaveCount(objEntityLeavSettlmt);
                        if (dtLeav.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtLeav.Rows.Count; i++)
                            {
                                int dtDear = Convert.ToInt32(dtLeav.Rows[i]["USRLEAVTYP_YEAR"].ToString());
                                if (dtLeav.Rows[i]["USRLEAVTYP_SETTLEMENT_LEAVE"].ToString() != "")
                                {
                                    if (dtDear < CurrYear)
                                    {
                                        PrevYearBalLeave = Convert.ToDecimal(dtLeav.Rows[i]["USRLEAVTYP_SETTLELEAVE_REMAIN"].ToString());
                                        LeaveEligbleDays += PrevYearBalLeave;
                                        SetlmtnRemainUpd = SetlmtnRemainUpd + "," + dtLeav.Rows[i]["LEAVETYP_ID"].ToString() + "-" + dtDear + "-" + PrevYearBalLeave;
                                    }
                                    else if (dtDear == CurrYear)
                                    {
                                        CurrYearBalLeave = Convert.ToDecimal(dtLeav.Rows[i]["USRLEAVTYP_SETTLEMENT_LEAVE"].ToString());
                                        if (dtJoinDate.Year == dtDear)
                                        {
                                            LeaveEligbleDays += (CurrYearBalLeave / JoinDateDays) * CurrYearDays;
                                            SetlmtnRemainUpd = SetlmtnRemainUpd + "," + dtLeav.Rows[i]["LEAVETYP_ID"].ToString() + "-" + dtDear + "-" + (CurrYearBalLeave / JoinDateDays) * CurrYearDays;
                                        }
                                        else
                                        {
                                            LeaveEligbleDays += (CurrYearBalLeave / 365) * CurrYearDays;
                                            SetlmtnRemainUpd = SetlmtnRemainUpd + "," + dtLeav.Rows[i]["LEAVETYP_ID"].ToString() + "-" + dtDear + "-" + (CurrYearBalLeave / 365) * CurrYearDays;
                                        }
                                    }
                                    if (dtDear > CurrYear)
                                    {
                                        NextYearBalLeave = Convert.ToDecimal(dtLeav.Rows[i]["USRLEAVTYP_SETTLEMENT_LEAVE"].ToString());
                                        LeaveEligbleDays += (NextYearBalLeave / 365) * NextYearDays;
                                        SetlmtnRemainUpd = SetlmtnRemainUpd + "," + dtLeav.Rows[i]["LEAVETYP_ID"].ToString() + "-" + dtDear + "-" + (NextYearBalLeave / 365) * NextYearDays;
                                    }
                                }
                            }
                        }
                        RemainLeav = LeaveEligbleDays;
                        RemainLeavDeductUser = SetlmtnRemainUpd;
                        decTotalEligibleLeav = decOpenLeaveCntPrev + RemainLeav;
                    }
                }
                strJson[33] = decTotalEligibleLeav.ToString("0.00");
                strJson[33]=    Math.Round(Convert.ToDecimal(decTotalEligibleLeav), 0).ToString("0.00");
                //if (IndividualRound == "1")
                //{
                //    strJson[2] = RemainLeav.ToString("0.00");
                //}
                //else
                //{
                //    strJson[2] = RemainLeav.ToString("0.00");
                //}

                //    strJson[2] = RemainLeav.ToString("0.00");
                strJson[15] = RemainLeavDeductUser;
            }
        }
        catch (Exception ex)
        {
        }
        return strJson;
    }

    [WebMethod]
    public static string[] SalaryDtls(string strEmpId, string strSettlmtDays, string strRejoinDt, string strDecmlCnt, string strCorp, string Org, string LeaveId, string tdLeaveTaken, string tdLeaveDate, string FixedAllowanceCheck, string varDate, string Mode, string CrncyId, string IndividualRound, string ZeroWorkFixed)
    {
        //IndividualRound = "0";
        string[] strJson = new string[50];//44      
        try
        {
            clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
            clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();



            if (strEmpId != "--SELECT EMPLOYEE--" && strEmpId != "")
            {
                objEntityLeavSettlmt.CorpId = Convert.ToInt32(strCorp);
                objEntityLeavSettlmt.OrgId = Convert.ToInt32(Org);
                objEntityLeavSettlmt.EmployeeId = Convert.ToInt32(strEmpId);
                string lstSettldDt = "";

                //basic pay
                strJson[0] = "0";
                DataTable dtBasic = objBusinessLeavSettlmt.ReadBasicPay(objEntityLeavSettlmt);
                if (dtBasic.Rows.Count > 0)
                {
                    if (dtBasic.Rows[0]["SLRY_BASIC_PAY"].ToString() != "")
                    {
                        strJson[0] = dtBasic.Rows[0]["SLRY_BASIC_PAY"].ToString();
                    }
                }


                //Start:-Read opening balance paid leave counts
                decimal decOpenLeaveCntPrev = 0, decOpenLeaveAmntPrev = 0;
                int OpenYear = 0;
                DataTable dtOpenLeaveinfo = objBusinessLeavSettlmt.ReadOpeningLeaveInfo(objEntityLeavSettlmt);
                if (dtOpenLeaveinfo.Rows.Count > 0)
                {
                    decimal BasicPay = 0;
                    BasicPay = Convert.ToDecimal(strJson[0]);
                    decimal PayPerDay = BasicPay / 30;

                    // decOpenLeaveCntPrev =Math.Round( Convert.ToDecimal(dtOpenLeaveinfo.Rows[0]["BALANCE_NUMLEAVE"].ToString()));
                    decOpenLeaveCntPrev = Convert.ToDecimal(dtOpenLeaveinfo.Rows[0]["BALANCE_NUMLEAVE"].ToString());
                    decOpenLeaveAmntPrev = decOpenLeaveCntPrev * PayPerDay;
                    OpenYear = Convert.ToInt32(dtOpenLeaveinfo.Rows[0]["OPUSLETYP_YEAR"].ToString());
                }
                strJson[30] = decOpenLeaveAmntPrev.ToString("0.00");
                //if (IndividualRound == "1")
                //{
                //    strJson[30] = Math.Round(decOpenLeaveAmntPrev, 0).ToString("0.00");
                //}
                //End:-Read opening balance paid leave counts



                //Start:-Read leave arrear amount
                decimal decLvArrearAmnt = 0;
                DataTable dtLeaveArrear = objBusinessLeavSettlmt.ReadLeaveArrearAmnt(objEntityLeavSettlmt);
                if (dtLeaveArrear.Rows.Count > 0)
                {
                    decLvArrearAmnt = Convert.ToDecimal(dtLeaveArrear.Rows[0]["BALANCE_AMOUNT"].ToString());
                }
                if (Mode == "0")
                {
                    strJson[31] = decLvArrearAmnt.ToString("0.00");
                    if (IndividualRound == "1")
                    {
                        strJson[31] = Math.Round(decLvArrearAmnt, 0).ToString("0.00");
                    }
                }
                //End:-Read leave arrear amount
                strJson[32] = "0";
                strJson[33] = "0";
                strJson[34] = "0";
                strJson[35] = "0";
                strJson[36] = "0";
                strJson[37] = "0";
                strJson[40] = "0";
                strJson[41] = "0";
                strJson[48] = "0";
                // settle all leave then leave settle upto the given date
                if (Mode == "1")
                {
                    strJson[31] = decLvArrearAmnt.ToString("0.00");
                    if (IndividualRound == "1")
                    {
                        strJson[31] = Math.Round(decLvArrearAmnt, 0).ToString("0.00");
                    }
                    decimal PayPerDay = 0;
                    string FinalPerDay = "";

                    int decmlcnt = Convert.ToInt32(strDecmlCnt);
                    decimal SettlmtDays = 0;
                    if (strSettlmtDays != "")
                    {
                        SettlmtDays = Convert.ToDecimal(strSettlmtDays);
                    }
                    decimal BasicPayPerDay = 0;
                    decimal BasicPay = 0;
                    BasicPay = Convert.ToDecimal(strJson[0]);
                    PayPerDay = BasicPay / 30;
                    BasicPayPerDay = BasicPay / 30;
                    BasicPay.ToString("0.00");

                    if (IndividualRound == "1" && strJson[0] != "" && strJson[0] != null && strJson[0] != "null")
                    {
                        strJson[0] = Math.Round(Convert.ToDecimal(strJson[0]), 0).ToString("0.00");
                    }

                    //strJson[0] = Convert.ToString(BasicPay);
                    strJson[1] = "0";
                    strJson[2] = "0";
                    strJson[3] = Convert.ToString(BasicPay);
                    strJson[4] = Convert.ToString(BasicPayPerDay);
                    strJson[5] = "0";
                    strJson[6] = "0";
                    strJson[7] = "0";
                    strJson[8] = Convert.ToString(BasicPay);
                    strJson[10] = "0";
                    strJson[11] = "0";
                    strJson[12] = "0";
                    strJson[28] = "";
                    strJson[38] = "0";
                    strJson[39] = "0";

                    FinalPerDay = Math.Round(PayPerDay, decmlcnt).ToString();
                    strJson[4] = FinalPerDay;
                    decimal leavSal = (PayPerDay * (SettlmtDays));
                    string FinalLeavSal = leavSal.ToString("0.00");
                    strJson[5] = FinalLeavSal;
                    //if (IndividualRound == "1")
                    //{
                    //    strJson[5] = leavSal.ToString("0.00");
                    //}
                    strJson[5] = Math.Round(leavSal, 0).ToString("0.00");
                    decimal NetAmt = leavSal  - decLvArrearAmnt;
                    string FinalNetAmt = Math.Round(NetAmt, 0).ToString();
                    strJson[8] = FinalNetAmt;
                }



          //Leave settlement by leave then the leave settle upto leave end date
                else if (Mode == "0")
                {
                    DateTime dtLastStl = new DateTime();
                    DateTime dtFinal = new DateTime();
                    cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
                    cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
                    objEnt.Employee = Convert.ToInt32(strEmpId);
                    objEnt.Orgid = Convert.ToInt32(Org);
                    objEnt.CorpOffice = Convert.ToInt32(strCorp);

                    DataTable dtLeavMonth1 = objBuss.ReadMonthlyLastDate(objEnt);
                    if (dtLeavMonth1.Rows.Count > 0)
                    {
                        if (dtLeavMonth1.Rows[0]["SLPRCDMNTH_LST_SETTLD_DT"].ToString() != "")
                        {
                            dtFinal = objCommon.textToDateTime(dtLeavMonth1.Rows[0]["SLPRCDMNTH_LST_SETTLD_DT"].ToString());
                        }
                    }
                    DataTable dtLeavMonth11 = objBuss.ReadLastLeaveStlDate(objEnt);
                    if (dtLeavMonth11.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtLeavMonth11.Rows.Count; i++)
                        {
                            if (dtLeavMonth11.Rows[i]["LEVSETLMT_LST_SETLMTDATE"].ToString() != "" && dtLeavMonth11.Rows[i][1].ToString() == "0")
                            {
                                dtLastStl = objCommon.textToDateTime(dtLeavMonth11.Rows[i]["LEVSETLMT_LST_SETLMTDATE"].ToString());
                                if (dtLastStl > dtFinal)
                                {
                                    dtFinal = dtLastStl;
                                }
                            }
                        }
                    }
                    string strDecision = "";

                    DataTable dtAllownce = objBusinessLeavSettlmt.ReadAllowance(objEntityLeavSettlmt);
                    DataTable dtDeductn = objBusinessLeavSettlmt.ReadDeduction(objEntityLeavSettlmt);

                    DateTime dtFromDate = new DateTime();
                    DateTime dtToDate = new DateTime();

                    if (tdLeaveDate != "")
                    {
                        string[] LeaveDate = tdLeaveDate.Split(' ');
                        objEntityLeavSettlmt.DateEndDate = objCommon.textToDateTime(LeaveDate[0]);
                        dtToDate = objCommon.textToDateTime(LeaveDate[0]);

                    }


                    //Join or rejoin date
                    string strStartDate = "";
                    DataTable dtEmpRejoin = objBusinessLeavSettlmt.ReadRejoin(objEntityLeavSettlmt);
                    DataTable dtEmpjoin = objBusinessLeavSettlmt.ReadJoinDt(objEntityLeavSettlmt);
                    DataTable dtEmpLev = objBusinessLeavSettlmt.ReadInsertDt(objEntityLeavSettlmt);
                    DataTable dtEmpOpenRejoin = objBusinessLeavSettlmt.ReadOpenRejoin(objEntityLeavSettlmt);

                    if (dtEmpRejoin.Rows.Count > 0 && dtEmpRejoin.Rows[0]["DUTYREJOIN_DATE"].ToString() != "")
                    {
                        strStartDate = dtEmpRejoin.Rows[0]["DUTYREJOIN_DATE"].ToString();
                    }
                    else if (dtEmpOpenRejoin.Rows.Count > 0 && dtEmpOpenRejoin.Rows[0]["USRJDT_CALC_DATE"].ToString() != "")
                    {
                        strStartDate = dtEmpOpenRejoin.Rows[0]["USRJDT_CALC_DATE"].ToString();
                    }
                    else if (dtEmpjoin.Rows.Count > 0 && dtEmpjoin.Rows[0]["EMPERDTL_JOIN_DATE"].ToString() != "")
                    {
                        strStartDate = dtEmpjoin.Rows[0]["EMPERDTL_JOIN_DATE"].ToString();
                    }
                    else if (dtEmpLev.Rows.Count > 0 && dtEmpLev.Rows[0]["USR_INS_DATE"].ToString() != "")
                    {
                        strStartDate = dtEmpLev.Rows[0]["USR_INS_DATE"].ToString();
                    }
                    else if (dtEmpjoin.Rows.Count > 0 && dtEmpjoin.Rows[0]["USR_JOIN_DATE"].ToString() != "")
                    {
                        strStartDate = dtEmpjoin.Rows[0]["USR_JOIN_DATE"].ToString();
                    }
                    dtFromDate = objCommon.textToDateTime(strStartDate);



                    //Salary process last date
                    DateTime dtLastSalaryPrcsDate = new DateTime();
                    DataTable dtLeavMonth = objBusinessLeavSettlmt.ReadMonthlyLastDate(objEntityLeavSettlmt);
                    if (dtLeavMonth.Rows.Count > 0 && dtLeavMonth.Rows[0]["SLPRCDMNTH_LST_SETTLD_DT"].ToString() != "")
                    {
                        dtLastSalaryPrcsDate = objCommon.textToDateTime(dtLeavMonth.Rows[0]["SLPRCDMNTH_LST_SETTLD_DT"].ToString());
                        int DtSettldNo = dtLastSalaryPrcsDate.Day;
                        int DtSettlMon = dtLastSalaryPrcsDate.Month;
                        int DtSettlYr = dtLastSalaryPrcsDate.Year;
                        if (DtSettlMon == 12)
                        {
                            DtSettlMon = 01;
                            DtSettlYr++;
                            dtLastSalaryPrcsDate = new DateTime(DtSettlYr, DtSettlMon, 1);
                        }
                        else
                        {
                            dtLastSalaryPrcsDate = new DateTime(DtSettlYr, DtSettlMon, 1);
                            dtLastSalaryPrcsDate = dtLastSalaryPrcsDate.AddMonths(1);
                        }
                    }
                    if (dtLastSalaryPrcsDate != DateTime.MinValue)
                    {
                        if (dtLastSalaryPrcsDate > dtFromDate)
                        {
                            dtFromDate = dtLastSalaryPrcsDate;
                        }
                    }


                    //Corporate salary date
                    DataTable dtCorpSal = objBusinessLeavSettlmt.ReadCorpSal(objEntityLeavSettlmt);
                    DateTime dtCorpSalaryDate = objCommon.textToDateTime(dtCorpSal.Rows[0]["COPRT_SALARY_DATE"].ToString());
                    int BasicPayStatus = Convert.ToInt32(dtCorpSal.Rows[0]["BASIC_PAY"].ToString());
                    if (dtCorpSalaryDate != DateTime.MinValue)
                    {
                        if (dtCorpSalaryDate > dtFromDate)
                        {
                            dtFromDate = dtCorpSalaryDate;
                        }
                    }
                    string strPrevMnthFrom = "";
                    decimal prevSal = 0;

                    int LsholiSts = 0, LSoffSts = 0;
                    DateTime dtLstSettlddateRj = new DateTime();
                    DataTable dtLeaveDtlsRj = new DataTable();


                    //Read last leave settlement info
                    DataTable DtLastSettleInfo = new DataTable();
                    DataTable DtSettleAfterLeaveInfo = new DataTable();
                    DateTime dtLastUpdSettle = new DateTime();
                    DateTime dtLastUpdMonth = new DateTime();
                    DateTime dtLstSettlddate = new DateTime();
                    int LastSettledAllowance = 0;
                    DataTable dtLeavSettld = objBusinessLeavSettlmt.ReadLastSettldDt(objEntityLeavSettlmt);
                    if (dtLeavSettld.Rows.Count > 0)
                    {
                        if (dtLeavSettld.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString() != "")
                        {

                            strJson[9] = dtLeavSettld.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString();
                            dtLstSettlddate = objCommon.textToDateTime(dtLeavSettld.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString());
                            LastSettledAllowance = Convert.ToInt32(dtLeavSettld.Rows[0]["LEVSETLMT_FIXED_ALOWNC_STS"].ToString());
                            lstSettldDt = dtLstSettlddate.ToString("dd-MM-yyyy");
                            if (dtLeavSettld.Rows[0]["LEAVE_ID"].ToString() != "")
                            {
                                objEntityLeavSettlmt.LeaveId = Convert.ToInt32(dtLeavSettld.Rows[0]["LEAVE_ID"].ToString());
                                DtLastSettleInfo = objBusinessLeavSettlmt.ReadLastSettlementDetails(objEntityLeavSettlmt);
                            }
                            if (dtLeavSettld.Rows[0]["LEVSETLMT_UPD_DATE"].ToString() != "")
                            {
                                dtLastUpdSettle = objCommon.textToDateTime(dtLeavSettld.Rows[0]["LEVSETLMT_UPD_DATE"].ToString());
                            }
                            dtLeaveDtlsRj = objBusinessLeavSettlmt.ReadLeaveDetailsRj(objEntityLeavSettlmt);
                            if (dtLeaveDtlsRj.Rows.Count > 0)
                            {
                                LsholiSts = Convert.ToInt32(dtLeaveDtlsRj.Rows[0]["LEAVETYP_HOLIDAY_PAID_STS"].ToString());
                                LSoffSts = Convert.ToInt32(dtLeaveDtlsRj.Rows[0]["LEAVETYP_OFFDAY_PAID_STS"].ToString());
                            }


                        }
                    }
                    if (dtLstSettlddate != DateTime.MinValue)
                    {
                        if (dtEmpRejoin.Rows.Count > 0 && dtEmpRejoin.Rows[0]["DUTYREJOIN_DATE"].ToString() != "")
                        {
                            if (dtLstSettlddate > objCommon.textToDateTime(dtEmpRejoin.Rows[0]["DUTYREJOIN_DATE"].ToString()))
                            {
                                strDecision = "Not rejoined";
                            }
                            else
                            {
                                if (dtEmpRejoin.Rows[0]["SALARY_PROCS_STS"].ToString() == "0")
                                {
                                    strPrevMnthFrom = dtEmpRejoin.Rows[0]["DUTYREJOIN_DATE"].ToString();
                                }
                            }
                        }
                        else
                        {
                            strDecision = "Not rejoined";
                        }
                    }

                    //Start:-For casual leave rejoin check
                    if (strDecision == "")
                    {                       
                        int NotRejoinCasulSts = 0;
                        int NotRHoliSts = 0;
                        int NotROffSts = 0;
                        DateTime dtFromLR = new DateTime();
                        DataTable dtRejoinLeaveCasual = objBuss.ReadLeaveCasualRejoin(objEnt);
                        if (dtRejoinLeaveCasual.Rows.Count > 0)
                        {
                            NotRHoliSts = Convert.ToInt32(dtRejoinLeaveCasual.Rows[0]["LEAVETYP_HOLIDAY_PAID_STS"].ToString());
                            NotROffSts = Convert.ToInt32(dtRejoinLeaveCasual.Rows[0]["LEAVETYP_OFFDAY_PAID_STS"].ToString());
                            dtFromLR = objCommon.textToDateTime(dtRejoinLeaveCasual.Rows[0]["LEAVE_FROM_DATE"].ToString());
                            DataTable dtRejoinLeaveCasualD = objBuss.ReadLeaveCasualRejoinDate(objEnt);
                            if (dtRejoinLeaveCasualD.Rows.Count > 0 && dtRejoinLeaveCasualD.Rows[0]["DUTYREJOIN_DATE"].ToString() != "")
                            {
                                if (dtFromLR > objCommon.textToDateTime(dtRejoinLeaveCasualD.Rows[0]["DUTYREJOIN_DATE"].ToString()))
                                {
                                    NotRejoinCasulSts = 1;
                                }
                                else
                                {
                                    if (dtRejoinLeaveCasualD.Rows[0]["SALARY_PROCS_STS"].ToString() == "0")
                                    {
                                        strPrevMnthFrom = dtRejoinLeaveCasualD.Rows[0]["DUTYREJOIN_DATE"].ToString();
                                        LsholiSts=NotRHoliSts;
                                        LSoffSts = NotROffSts;
                                    }
                                }
                            }
                            else
                            {
                                NotRejoinCasulSts = 1;
                            }
                            if (NotRejoinCasulSts == 1)
                            {
                                strDecision = "Not rejoined";
                            }
                        }                                             
                    }
                    //End:-For casual leave rejoin chec




                    strJson[44] = dtFromDate.ToString("dd-MM-yyyy");
                    DateTime dtToStore = dtToDate.AddDays(-1);
                    strJson[45] = dtToStore.ToString("dd-MM-yyyy");


                    //Month difference calculation
                    int MonthDiff = (dtToDate.Year * 12 + dtToDate.Month) - (dtFromDate.Year * 12 + dtFromDate.Month);
                    if (MonthDiff > 1 && strDecision == "")
                    {
                        strDecision = "Salary process pending";
                    }

                    int decmlcnt = Convert.ToInt32(strDecmlCnt);

                    DataTable dtEmp = objBusinessLeavSettlmt.ReadEmpDtls(objEntityLeavSettlmt);
                    string staffWorkr = "0";
                    if (dtEmp.Rows.Count > 0)
                    {
                        staffWorkr = dtEmp.Rows[0]["STAFF_WORKER"].ToString().ToUpper();
                    }
                    if (strDecision == "" && staffWorkr == "1" && CheckWorkerMissingAttendance(strEmpId, dtFromDate, dtToDate, strCorp, Org) == "false")
                    {
                        strDecision = "MissingAttendance";
                    }
                    strJson[28] = strDecision;
                    if (strDecision == "")
                    {
                        //Check rejoined after leave settlement
                        if (strPrevMnthFrom != "")
                        {
                            DateTime dtPrevFrom = objCommon.textToDateTime(strPrevMnthFrom);
                            int preDays = DateTime.DaysInMonth(dtPrevFrom.Year, dtPrevFrom.Month);
                            DateTime dtPrevTo = new DateTime(dtPrevFrom.Year, dtPrevFrom.Month, preDays);
                            if (dtCorpSalaryDate <= dtPrevTo)
                            {
                                if (dtCorpSalaryDate > dtPrevFrom)
                                {
                                    dtPrevFrom = dtCorpSalaryDate;
                                }
                                prevSal = MonthSalaryArr(strEmpId, dtPrevFrom, dtPrevTo, strJson[0], dtAllownce, dtDeductn, BasicPayStatus, 0, strCorp, Org, IndividualRound, ZeroWorkFixed, LsholiSts, LSoffSts);
                                strJson[49] = strPrevMnthFrom;
                            }
                        }
                        //Arrear from daily attendance sheet table 
                        DataTable dtArrearDailyAtt = objBuss.ReadArrearFromAtt(objEnt);
                        if (dtArrearDailyAtt.Rows.Count > 0 && dtArrearDailyAtt.Rows[0]["SUM_ARREAR"].ToString()!="")
                        {
                            prevSal += Convert.ToDecimal(dtArrearDailyAtt.Rows[0]["SUM_ARREAR"].ToString());
                        }


                        if (CrncyId != "")
                            objEntityCommon.CurrencyId = Convert.ToInt32(CrncyId);
                        string formatString = String.Concat("{0:F", decmlcnt, "}");

                        //Calculate current month salary
                        decimal decMessDedctn = 0; string StrMessDedctn = "0";
                        string[] strJsonCurr = new string[12];
                        if (MonthDiff == 0)
                        {

                            int flgFix = 0;
                            if (dtFinal != DateTime.MinValue)
                            {
                                DateTime dtfbd = new DateTime(dtFinal.Year, dtFinal.Month, 1);
                                DateTime dtfhbd = new DateTime(dtFromDate.Year, dtFromDate.Month, 1);
                                if (dtfhbd <= dtfbd)
                                {
                                    flgFix = 1;
                                }
                            }

                            strJsonCurr = MonthSalary(strEmpId, dtFromDate, dtToDate, strJson[0], dtAllownce, dtDeductn, 0, BasicPayStatus, flgFix, strCorp, Org, IndividualRound, ZeroWorkFixed);
                            //Mess amount calculation for current and previous month
                            objEntityLeavSettlmt.DateSettle = dtToDate;
                            objEntityLeavSettlmt.DateStartDate = dtFromDate;
                            objEntityLeavSettlmt.ConfrmStatus = 0;
                            DataTable dtMess = objBusinessLeavSettlmt.ReadMessAmount(objEntityLeavSettlmt);
                            if (dtMess.Rows.Count > 0)
                            {
                                if (dtMess.Rows[0]["MESS_DEDCTN"].ToString() != "")
                                {
                                    StrMessDedctn = dtMess.Rows[0]["MESS_DEDCTN"].ToString();
                                    decMessDedctn = Convert.ToDecimal(dtMess.Rows[0]["MESS_DEDCTN"].ToString());
                                }
                            }
                        
                        }
                        else
                        {
                            DateTime dtCurrFromDate = new DateTime(dtToDate.Year, dtToDate.Month, 1);
                            strJsonCurr = MonthSalary(strEmpId, dtCurrFromDate, dtToDate, strJson[0], dtAllownce, dtDeductn, 0, BasicPayStatus, 0, strCorp, Org, IndividualRound, ZeroWorkFixed);

                            //Mess amount calculation for current and previous month
                            objEntityLeavSettlmt.DateSettle = dtToDate;
                            objEntityLeavSettlmt.DateStartDate = dtCurrFromDate;                           
                            objEntityLeavSettlmt.ConfrmStatus = 1;
                            DataTable dtMess = objBusinessLeavSettlmt.ReadMessAmount(objEntityLeavSettlmt);
                            if (dtMess.Rows.Count > 0)
                            {
                                if (dtMess.Rows[0]["MESS_DEDCTN"].ToString() != "")
                                {
                                    StrMessDedctn = dtMess.Rows[0]["MESS_DEDCTN"].ToString();
                                    decMessDedctn = Convert.ToDecimal(dtMess.Rows[0]["MESS_DEDCTN"].ToString());
                                }
                            }
                        
                        
                        }
                        //  Addition & Deduction
                       
                        strJson[12] = Math.Round(decMessDedctn, decmlcnt).ToString();
                        if (IndividualRound == "1")
                        {
                            strJson[12] = Math.Round(decMessDedctn, 0).ToString();
                        }

                        strJson[1] = strJsonCurr[2];
                        strJson[2] = "0";
                        strJson[2] = strJsonCurr[4];
                        if (IndividualRound == "1")
                        {
                            strJson[1] = Math.Round(Convert.ToDecimal(strJsonCurr[2]), 0).ToString("0.00");
                            strJson[2] = Math.Round(Convert.ToDecimal(strJsonCurr[4]), 0).ToString("0.00");
                        }
                        decimal Basic = Convert.ToDecimal(strJson[0]);

                        decimal ArrearAmount = Convert.ToDecimal(strJsonCurr[0]);
                        decimal decBasicSalary = Convert.ToDecimal(strJsonCurr[1]);
                        decimal Allowance = Convert.ToDecimal(strJsonCurr[2]);
                        decimal OvertimeAmnt = Convert.ToDecimal(strJsonCurr[3]);
                        decimal Deductn = Convert.ToDecimal(strJsonCurr[4]);
                        decimal Installment = Convert.ToDecimal(strJsonCurr[5]);

                        decimal OtherAdditionAmt = Convert.ToDecimal(strJsonCurr[6]);
                        decimal OtherDeductionAmt = Convert.ToDecimal(strJsonCurr[7]);

                        string strOtherAdd = strJsonCurr[8];
                        string strOtherDeduct = strJsonCurr[9];

                        strJson[42] = strOtherAdd;
                        strJson[43] = strOtherDeduct;
                        //if (IndividualRound == "1")
                        //{
                        //    if(strOtherAdd!="")
                        //    strJson[42] = Math.Round(Convert.ToDecimal(strOtherAdd), 0).ToString("0.00");
                        //    if (strOtherDeduct != "")
                        //    strJson[43] = Math.Round(Convert.ToDecimal(strOtherDeduct), 0).ToString("0.00");
                        //}

                        decimal TotalPay = (decBasicSalary + Allowance + ArrearAmount + OvertimeAmnt) - Deductn - decMessDedctn - Installment;
                        // decimal TotalPay = (decBasicSalary + Allowance + ArrearAmount + OvertimeAmnt + OtherAdditionAmt) - Deductn - decMessDedctn - Installment - OtherDeductionAmt;
                        strJson[3] = TotalPay.ToString("0.00");
                        strJson[7] = TotalPay.ToString("0.00");
                        if (IndividualRound == "1")
                        {
                            TotalPay = Math.Round(decBasicSalary, 0) + Math.Round(Allowance, 0) + Math.Round(ArrearAmount, 0) + Math.Round(OvertimeAmnt, 0) - Math.Round(Deductn, 0) - Math.Round(decMessDedctn, 0) - Math.Round(Installment, 0);

                            strJson[7] = Math.Round(TotalPay, 0).ToString("0.00");
                        }
                       // strJson[7] = TotalPay.ToString("0.00");
                        strJson[3] = TotalPay.ToString("0.00");
                        string FinalPerDay = "";
                        decimal PayPerDay = 0;

                        PayPerDay = Basic / 30;
                        FinalPerDay = Math.Round(PayPerDay, decmlcnt).ToString();
                        strJson[4] = FinalPerDay;

                        strJson[10] = Math.Round(OvertimeAmnt, decmlcnt).ToString();
                        strJson[11] = Math.Round(Installment, decmlcnt).ToString();
                        if (IndividualRound == "1")
                        {
                            strJson[10] = Math.Round(OvertimeAmnt, 0).ToString();
                            strJson[11] = Math.Round(Installment, 0).ToString();
                        }
                        decimal CurntMnthSal = TotalPay;

                        strJson[38] = OtherAdditionAmt.ToString("0.00");
                        strJson[39] = OtherDeductionAmt.ToString("0.00");
                        if (IndividualRound == "1")
                        {
                            strJson[38] = Math.Round(OtherAdditionAmt, 0).ToString("0.00");
                            strJson[39] = Math.Round(OtherDeductionAmt, 0).ToString("0.00");
                        }

                        //Calculate leave salary
                        decimal SettlmtDays = 0;
                        if (strSettlmtDays != "")
                        {
                            strJson[25] = SettlmtDays.ToString();
                            SettlmtDays = Convert.ToDecimal(strSettlmtDays);
                        }
                        decimal leavSal = (PayPerDay * (SettlmtDays));
                        string FinalLeavSal = leavSal.ToString("0.00");
			strJson[5] = Math.Round(leavSal, 0).ToString("0.00");

                      //  strJson[5] = FinalLeavSal;
                      //  if (IndividualRound == "1")
                     //   {
                        //    strJson[5] = leavSal.ToString("0.00");
                       // }


                        //Calculate previous month salary
                        decimal PrevSal = 0;
                        strJson[6] = Math.Round(PrevSal, decmlcnt).ToString();
                        string[] strJsonPrev = new string[12];
                        if (MonthDiff == 1)
                        {
                            DateTime dtCurrFromDate = new DateTime(dtToDate.Year, dtToDate.Month, 1);
                            DateTime dtPrevToDate = dtCurrFromDate.AddDays(-1);
                            DateTime dtprevFromDate = new DateTime(dtPrevToDate.Year, dtPrevToDate.Month, 1);
                            if (dtprevFromDate < dtFromDate)
                            {
                                dtprevFromDate = dtFromDate;
                            }

                            int flgFix = 0;
                            if (dtFinal != DateTime.MinValue)
                            {
                                DateTime dtfbd = new DateTime(dtFinal.Year, dtFinal.Month, 1);
                                DateTime dtfhbd = new DateTime(dtprevFromDate.Year, dtprevFromDate.Month, 1);
                                if (dtfhbd <= dtfbd)
                                {
                                    flgFix = 1;
                                }
                            }

                            strJsonPrev = MonthSalary(strEmpId, dtprevFromDate, dtPrevToDate, strJson[0], dtAllownce, dtDeductn, 1, BasicPayStatus, flgFix, strCorp, Org, IndividualRound, ZeroWorkFixed);


                            //Mess amount calculation for previous month
                            decimal PrevMessAmount = 0;
                            objEntityLeavSettlmt.DateSettle = dtPrevToDate;
                            objEntityLeavSettlmt.DateStartDate = dtprevFromDate;                           
                            objEntityLeavSettlmt.ConfrmStatus = 0;
                            DataTable dtMess = objBusinessLeavSettlmt.ReadMessAmount(objEntityLeavSettlmt);
                            if (dtMess.Rows.Count > 0)
                            {
                                if (dtMess.Rows[0]["MESS_DEDCTN"].ToString() != "")
                                {
                                    PrevMessAmount = Convert.ToDecimal(dtMess.Rows[0]["MESS_DEDCTN"].ToString());
                                }
                            }

                            decimal PrevArrearAmount = Convert.ToDecimal(strJsonPrev[0]);
                            decimal PrevBasicSalary = Convert.ToDecimal(strJsonPrev[1]);
                            decimal PrevAllowance = Convert.ToDecimal(strJsonPrev[2]);
                            decimal PrevOvertimeAmnt = Convert.ToDecimal(strJsonPrev[3]);
                            decimal PrevDeductn = Convert.ToDecimal(strJsonPrev[4]);
                            decimal PrevInstallment = Convert.ToDecimal(strJsonPrev[5]);

                            decimal PrevOtherAdditionAmt = Convert.ToDecimal(strJsonPrev[6]);
                            decimal PrevOtherDeductionAmt = Convert.ToDecimal(strJsonPrev[7]);

                            //      PrevSal = PrevArrearAmount + PrevBasicSalary + PrevAllowance + PrevOvertimeAmnt - PrevDeductn - PrevInstallment;
                            PrevSal = PrevArrearAmount + PrevBasicSalary + PrevAllowance + PrevOvertimeAmnt + PrevOtherAdditionAmt - PrevDeductn - PrevInstallment - PrevOtherDeductionAmt - PrevMessAmount;
                            if (IndividualRound == "1")
                            {
                                PrevArrearAmount = Math.Round(PrevArrearAmount, 0);
                                PrevBasicSalary = Math.Round(PrevBasicSalary, 0);
                                PrevAllowance = Math.Round(PrevAllowance, 0);
                                PrevOvertimeAmnt = Math.Round(PrevOvertimeAmnt, 0);
                                PrevDeductn = Math.Round(PrevDeductn, 0);
                                PrevInstallment = Math.Round(PrevInstallment, 0);
                                PrevOtherAdditionAmt = Math.Round(PrevOtherAdditionAmt, 0);
                                PrevOtherDeductionAmt = Math.Round(PrevOtherDeductionAmt, 0);
                                PrevMessAmount = Math.Round(PrevMessAmount, 0);
                            }


                            if (CrncyId != "")
                                objEntityCommon.CurrencyId = Convert.ToInt32(CrncyId);

                            string strHtml = "Basic Pay:" + objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString, PrevBasicSalary).ToString(), objEntityCommon);
                            strHtml += "\nArrear Amount:" + objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString, PrevArrearAmount).ToString(), objEntityCommon);
                            strHtml += "\nAddition:" + objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString, PrevAllowance).ToString(), objEntityCommon);
                            strHtml += "\nOvertime Addition:" + objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString, PrevOvertimeAmnt).ToString(), objEntityCommon);
                            strHtml += "\nDeduction:" + objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString, PrevDeductn).ToString(), objEntityCommon);
                            strHtml += "\nPayment Deduction:" + objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString, PrevInstallment).ToString(), objEntityCommon);
                            strHtml += "\nOther Addition:" + objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString, PrevOtherAdditionAmt).ToString(), objEntityCommon);
                            strHtml += "\nOther Deduction:" + objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString, PrevOtherDeductionAmt).ToString(), objEntityCommon);
                            strHtml += "\nMess Deduction:" + objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString, PrevMessAmount).ToString(), objEntityCommon);
                            strJson[29] = strHtml;
                            strJson[6] = Math.Round(PrevSal, decmlcnt).ToString();
                            if (IndividualRound == "1")
                            {
                                strJson[6] = Math.Round(PrevSal, 0).ToString();
                            }
                            strJson[32] = Math.Round(PrevAllowance, decmlcnt).ToString();
                            strJson[33] = Math.Round(PrevOvertimeAmnt, decmlcnt).ToString();
                            strJson[34] = Math.Round(PrevArrearAmount, decmlcnt).ToString();
                            strJson[35] = Math.Round(PrevDeductn, decmlcnt).ToString();
                            strJson[36] = Math.Round(PrevInstallment, decmlcnt).ToString();
                            strJson[40] = Math.Round(PrevOtherAdditionAmt, decmlcnt).ToString();
                            strJson[41] = Math.Round(PrevOtherDeductionAmt, decmlcnt).ToString();
                            strJson[37] = Math.Round(PrevMessAmount, decmlcnt).ToString();

                        }
                        if (IndividualRound == "1" && strJson[0] != "" && strJson[0] != null && strJson[0] != "null")
                        {
                            strJson[0] = Math.Round(Convert.ToDecimal(strJson[0]), 0).ToString();
                        }

                        string strAddDtls = strJsonCurr[10], strDedDtls = strJsonCurr[11];
                        if (strJsonPrev[10] != null && strJsonPrev[10] != "")
                        {
                            strAddDtls = strJsonCurr[10] + "%" + strJsonPrev[10];
                        }
                        if (strJsonPrev[11] != null && strJsonPrev[11] != "")
                        {
                            strDedDtls = strJsonCurr[11] + "%" + strJsonPrev[11];
                        }
                        strJson[46] = strAddDtls;
                        strJson[47] = strDedDtls;

                        if (IndividualRound == "1")
                        {
                            prevSal = Math.Round(prevSal, 0);
                        }
                        //Calculate net amount
                        // decimal NetAmt = leavSal + PrevSal + CurntMnthSal + decOpenLeaveAmntPrev - decLvArrearAmnt; 
                        decimal NetAmt = leavSal + PrevSal + CurntMnthSal + OtherAdditionAmt + prevSal - decLvArrearAmnt - OtherDeductionAmt;
                        if (IndividualRound == "1")
                        {
                            NetAmt = Math.Round(leavSal, 0) + Math.Round(PrevSal, 0) + Math.Round(CurntMnthSal, 0) + Math.Round(OtherAdditionAmt, 0) +prevSal- Math.Round(decLvArrearAmnt, 0) - Math.Round(OtherDeductionAmt, 0);
                        }
                        string FinalNetAmt = Math.Round(NetAmt, 0).ToString();
                        strJson[8] = FinalNetAmt;
                        strJson[48] = prevSal.ToString();
                    }

                }


            }
        }
         catch (Exception ex)
        {
        }
        return strJson;
    }


    public static decimal calcFutureLeaveCnt(string stringToCheck, DataTable dtLeaveDate, cls_Entity_Monthly_Salary_Process objEnt2)
    {
        decimal TtlCnt = 0;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        for (int lcnt = 0; lcnt < dtLeaveDate.Rows.Count; lcnt++)
        {
            string stringToCheck1 = dtLeaveDate.Rows[lcnt]["LEAVETYP_ID"].ToString();
            if (stringToCheck1 == stringToCheck)
            {

                int HoliPaidSts = Convert.ToInt32(dtLeaveDate.Rows[lcnt]["LEAVETYP_HOLIDAY_PAID_STS"].ToString());
                int OffPaidSts = Convert.ToInt32(dtLeaveDate.Rows[lcnt]["LEAVETYP_OFFDAY_PAID_STS"].ToString());


                decimal cnt = 0;
                dutyOf objDuty = new dutyOf();
                int OffCount = 0;

                DateTime LfrmDt = DateTime.MinValue;
                DateTime LToDt = DateTime.MinValue;

                if (dtLeaveDate.Rows[lcnt]["LEAVE_FROM_DATE"].ToString() != "")
                {
                    LfrmDt = objCommon.textToDateTime(dtLeaveDate.Rows[lcnt]["LEAVE_FROM_DATE"].ToString());
                }
                if (dtLeaveDate.Rows[lcnt]["LEAVE_TO_DATE"].ToString() != "")
                {
                    LToDt = objCommon.textToDateTime(dtLeaveDate.Rows[lcnt]["LEAVE_TO_DATE"].ToString());
                }
                if (LfrmDt != DateTime.MinValue && LToDt != DateTime.MinValue)
                {
                    if (LfrmDt >= objEnt2.DateStartDate && LToDt <= objEnt2.DateEndDate)
                    {
                        cnt = Convert.ToInt32((LToDt - LfrmDt).TotalDays) + 1;
                        if (dtLeaveDate.Rows[lcnt]["LEAVE_FROM_SCTN"].ToString() != "1")
                        {
                            cnt = cnt - (decimal)0.5;
                        }
                        if (dtLeaveDate.Rows[lcnt]["LEAVE_TO_SCTN"].ToString() != "1")
                        {
                            cnt = cnt - (decimal)0.5;
                        }
                        DateTime datenow, enddate;
                        datenow = LfrmDt;
                        enddate = LToDt;
                        if (HoliPaidSts == 1 || OffPaidSts == 1)
                        {
                            for (var day = datenow; day <= enddate; day = day.AddDays(1))
                            {
                                string hol = "false";
                                if (HoliPaidSts == 1)
                                {
                                    hol = objDuty.checkholiday(day, datenow, enddate);
                                    if (hol == "true")
                                    {
                                        OffCount = OffCount + 1;
                                    }
                                }
                                if (OffPaidSts == 1 && hol != "true")
                                {
                                    string off = objDuty.CheckDutyOff(day, objEnt2.CorpOffice.ToString(), objEnt2.Orgid.ToString());
                                    if (off == "true")
                                    {
                                        OffCount = OffCount + 1;
                                    }
                                }
                            }
                        }

                        cnt = cnt - OffCount;
                        if (cnt < 0)
                        {
                            cnt = 0;
                        }
                    }
                    else if (LfrmDt < objEnt2.DateStartDate)
                    {

                        cnt = Convert.ToInt32((LToDt - objEnt2.DateStartDate).TotalDays) + 1;
                        if (dtLeaveDate.Rows[lcnt]["LEAVE_TO_SCTN"].ToString() != "1")
                        {
                            cnt = cnt - (decimal)0.5;
                        }
                        DateTime datenow, enddate;
                        datenow = objEnt2.DateStartDate;
                        enddate = LToDt;
                        if (HoliPaidSts == 1 || OffPaidSts == 1)
                        {
                            for (var day = datenow; day <= enddate; day = day.AddDays(1))
                            {
                                string hol = "false";
                                if (HoliPaidSts == 1)
                                {
                                    hol = objDuty.checkholiday(day, datenow, enddate);
                                    if (hol == "true")
                                    {
                                        OffCount = OffCount + 1;
                                    }
                                }
                                if (OffPaidSts == 1 && hol != "true")
                                {
                                    string off = objDuty.CheckDutyOff(day, objEnt2.CorpOffice.ToString(), objEnt2.Orgid.ToString());
                                    if (off == "true")
                                    {
                                        OffCount = OffCount + 1;
                                    }
                                }
                            }
                        }
                        cnt = cnt - OffCount;
                        if (cnt < 0)
                        {
                            cnt = 0;
                        }
                    }
                    else if (LToDt > objEnt2.DateEndDate)
                    {

                        cnt = Convert.ToInt32((objEnt2.DateEndDate - LfrmDt).TotalDays) + 1;
                        if (dtLeaveDate.Rows[lcnt]["LEAVE_FROM_SCTN"].ToString() != "1")
                        {
                            cnt = cnt - (decimal)0.5;
                        }


                        DateTime datenow, enddate;
                        datenow = LfrmDt;
                        enddate = objEnt2.DateEndDate;
                        if (HoliPaidSts == 1 || OffPaidSts == 1)
                        {
                            for (var day = datenow; day <= enddate; day = day.AddDays(1))
                            {
                                string hol = "false";
                                if (HoliPaidSts == 1)
                                {
                                    hol = objDuty.checkholiday(day, datenow, enddate);
                                    if (hol == "true")
                                    {
                                        OffCount = OffCount + 1;
                                    }
                                }
                                if (OffPaidSts == 1 && hol != "true")
                                {
                                    string off = objDuty.CheckDutyOff(day, objEnt2.CorpOffice.ToString(), objEnt2.Orgid.ToString());
                                    if (off == "true")
                                    {
                                        OffCount = OffCount + 1;
                                    }
                                }
                            }
                        }
                        cnt = cnt - OffCount;
                        if (cnt < 0)
                        {
                            cnt = 0;
                        }
                    }

                }

                else if (LfrmDt != DateTime.MinValue && LToDt == DateTime.MinValue)
                {
                    if (LfrmDt <= objEnt2.DateEndDate && LfrmDt >= objEnt2.DateStartDate)
                    {

                        if (dtLeaveDate.Rows[lcnt]["LEAVE_FROM_SCTN"].ToString() == "1")
                        {
                            cnt = 1;
                        }
                        else
                        {
                            cnt = (decimal)0.5;
                        }
                    }

                }
                TtlCnt += cnt;
            }
        }
        return TtlCnt;
    }

    public class dutyOf
    {

        public static string GetWeekOfMonth(DateTime date)
        {
            DateTime beginningOfMonth = new DateTime(date.Year, date.Month, 1);
            while (date.Date.AddDays(1).DayOfWeek != CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)

                date = date.AddDays(1);

            int weekNumber = (int)Math.Truncate((double)date.Subtract(beginningOfMonth).TotalDays / 7f) + 1;

            string[] weeks = { "first", "second", "third", "fourth", "fifth", "sixth" };

            return weeks[weekNumber - 1];

        }
        public string CheckDutyOff(DateTime dateCheck, string orgid, string corpid)
        {

            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
            clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
            objEntLevAllocn.Organisation_id = Convert.ToInt32(corpid);
            objEntLevAllocn.Corporate_id = Convert.ToInt32(orgid);
            //FOR READING DUTY OFF
            DataTable dtDutyOffWeekly = objBusLevAllocn.ReadWeeklyDutyOff(objEntLevAllocn);
            string strJbWklyOffDay = "";
            if (dtDutyOffWeekly.Rows.Count > 0)
            {
                string DutyOffDays = dtDutyOffWeekly.Rows[0]["WK_OFFDUTYDTL_DAYS"].ToString();
                string[] DutyOffDay = DutyOffDays.Split(',');
                foreach (string DutyOfwk in DutyOffDay)
                {
                    switch (DutyOfwk)
                    {
                        case "1":
                            strJbWklyOffDay += "Sunday";
                            break;
                        case "2":
                            strJbWklyOffDay += "Monday";
                            break;
                        case "3":
                            strJbWklyOffDay += "Tuesday";
                            break;
                        case "4":
                            strJbWklyOffDay += "Wednesday";
                            break;
                        case "5":
                            strJbWklyOffDay += "Thursday";
                            break;
                        case "6":
                            strJbWklyOffDay += "Friday";
                            break;
                        case "7":
                            strJbWklyOffDay += "Saturday";
                            break;

                    }
                }
            }

            List<DateTime> MonthlyOffDates = new List<DateTime>();

            //for date and month section

            //string strTodayDate = objCommon.textToDateTime(strCurrDateServer).ToString("dd/MM/yyyy");
            //DateTime DateTodayDate = new DateTime();
            //DateTodayDate = objCommon.textToDateTime(strTodayDate);

            DateTime now = new DateTime();

            //now = objCommon.textToDateTime(hiddenFirstDate.Value);
            now = dateCheck.Date;
            now = objCommon.textToDateTime(now.ToString("dd/MM/yyyy"));
            string wkoff = GetWeekOfMonth(now.Date);

            DataTable dtDutyOffMonthly = objBusLevAllocn.ReadMonthlyDutyOff(objEntLevAllocn);
            if (dtDutyOffMonthly.Rows.Count > 0)
            {


                DateTime leaveDate = new DateTime();


                //Start:-EMP-0009
                DateTime now1 = new DateTime();
                now1 = now.AddDays(6);

                foreach (DataRow Rowd in dtDutyOffMonthly.Rows)
                {
                    if (Rowd["OFFDUTYDTL_DAYS"].ToString() != "")
                    {
                        int firstdate = 0;


                        //First two
                        if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "2")
                        {
                            for (int i = 0; i <= 1; i++)
                            {
                                if (i == 0)
                                {
                                    firstdate = 1;
                                }
                                else if (i == 1)
                                {
                                    firstdate = 8;
                                }


                                string DaysStr = Rowd["OFFDUTYDTL_DAYS"].ToString();
                                string[] spitDayStr = DaysStr.Split(',');
                                foreach (string strSpliSlice in spitDayStr)
                                {
                                    if (strSpliSlice != "")
                                    {
                                        switch (strSpliSlice)
                                        {
                                            case "2":
                                                DateTime FirstMonday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstMonday.DayOfWeek == DayOfWeek.Monday)
                                                    {
                                                        leaveDate = FirstMonday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstMonday = FirstMonday.AddDays(1);
                                                    }
                                                }

                                                if (now.Month < now1.Month || now.Year < now1.Year)
                                                {
                                                    FirstMonday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < 7; count++)
                                                    {
                                                        if (FirstMonday.DayOfWeek == DayOfWeek.Monday)
                                                        {
                                                            leaveDate = FirstMonday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstMonday = FirstMonday.AddDays(1);
                                                        }
                                                    }

                                                }


                                                break;
                                            case "3":
                                                DateTime FirstTuesday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstTuesday.DayOfWeek == DayOfWeek.Tuesday)
                                                    {

                                                        leaveDate = FirstTuesday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstTuesday = FirstTuesday.AddDays(1);
                                                    }
                                                }
                                                if (now.Month < now1.Month || now.Year < now1.Year)
                                                {

                                                    FirstTuesday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < 7; count++)
                                                    {
                                                        if (FirstTuesday.DayOfWeek == DayOfWeek.Tuesday)
                                                        {

                                                            leaveDate = FirstTuesday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstTuesday = FirstTuesday.AddDays(1);
                                                        }
                                                    }
                                                }
                                                break;
                                            case "4":
                                                DateTime FirstWednesday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstWednesday.DayOfWeek == DayOfWeek.Wednesday)
                                                    {
                                                        leaveDate = FirstWednesday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstWednesday = FirstWednesday.AddDays(1);
                                                    }
                                                }

                                                if (now.Month < now1.Month || now.Year < now1.Year)
                                                {
                                                    FirstWednesday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < 7; count++)
                                                    {
                                                        if (FirstWednesday.DayOfWeek == DayOfWeek.Wednesday)
                                                        {
                                                            leaveDate = FirstWednesday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstWednesday = FirstWednesday.AddDays(1);
                                                        }
                                                    }
                                                }
                                                break;
                                            case "5":
                                                DateTime FirstThursday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstThursday.DayOfWeek == DayOfWeek.Thursday)
                                                    {
                                                        leaveDate = FirstThursday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstThursday = FirstThursday.AddDays(1);
                                                    }
                                                }
                                                if (now.Month < now1.Month || now.Year < now1.Year)
                                                {
                                                    FirstThursday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < 7; count++)
                                                    {
                                                        if (FirstThursday.DayOfWeek == DayOfWeek.Thursday)
                                                        {
                                                            leaveDate = FirstThursday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstThursday = FirstThursday.AddDays(1);
                                                        }
                                                    }
                                                }
                                                break;
                                            case "6":
                                                DateTime FirstFriday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstFriday.DayOfWeek == DayOfWeek.Friday)
                                                    {
                                                        leaveDate = FirstFriday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstFriday = FirstFriday.AddDays(1);
                                                    }
                                                }

                                                if (now.Month < now1.Month || now.Year < now1.Year)
                                                {
                                                    FirstFriday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < 7; count++)
                                                    {
                                                        if (FirstFriday.DayOfWeek == DayOfWeek.Friday)
                                                        {
                                                            leaveDate = FirstFriday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstFriday = FirstFriday.AddDays(1);
                                                        }
                                                    }
                                                }
                                                break;
                                            case "7":
                                                DateTime FirstSaturday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstSaturday.DayOfWeek == DayOfWeek.Saturday)
                                                    {
                                                        leaveDate = FirstSaturday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstSaturday = FirstSaturday.AddDays(1);
                                                    }
                                                }


                                                if (now.Month < now1.Month || now.Year < now1.Year)
                                                {

                                                    FirstSaturday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < 7; count++)
                                                    {
                                                        if (FirstSaturday.DayOfWeek == DayOfWeek.Saturday)
                                                        {
                                                            leaveDate = FirstSaturday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstSaturday = FirstSaturday.AddDays(1);
                                                        }
                                                    }

                                                }

                                                break;
                                            case "1":
                                                DateTime FirstSunday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstSunday.DayOfWeek == DayOfWeek.Sunday)
                                                    {
                                                        leaveDate = FirstSunday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstSunday = FirstSunday.AddDays(1);
                                                    }
                                                }

                                                if (now.Month < now1.Month || now.Year < now1.Year)
                                                {
                                                    FirstSunday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < 7; count++)
                                                    {
                                                        if (FirstSunday.DayOfWeek == DayOfWeek.Sunday)
                                                        {
                                                            leaveDate = FirstSunday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstSunday = FirstSunday.AddDays(1);
                                                        }
                                                    }
                                                }
                                                break;
                                        }
                                    }

                                }
                            }

                        }


                        //Last two

                        if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "3")
                        {


                            for (int i = 0; i <= 1; i++)
                            {
                                if (i == 0)
                                {
                                    firstdate = DateTime.DaysInMonth(now.Year, now.Month);
                                }
                                else if (i == 1)
                                {
                                    firstdate = DateTime.DaysInMonth(now.Year, now.Month) - 7;
                                }


                                string DaysStr = Rowd["OFFDUTYDTL_DAYS"].ToString();
                                string[] spitDayStr = DaysStr.Split(',');
                                foreach (string strSpliSlice in spitDayStr)
                                {
                                    if (strSpliSlice != "")
                                    {
                                        switch (strSpliSlice)
                                        {
                                            case "2":
                                                DateTime FirstMonday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstMonday.DayOfWeek == DayOfWeek.Monday)
                                                    {
                                                        leaveDate = FirstMonday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstMonday = FirstMonday.AddDays(-1);
                                                    }
                                                }
                                                break;
                                            case "3":
                                                DateTime FirstTuesday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstTuesday.DayOfWeek == DayOfWeek.Tuesday)
                                                    {

                                                        leaveDate = FirstTuesday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstTuesday = FirstTuesday.AddDays(-1);
                                                    }
                                                }
                                                break;
                                            case "4":
                                                DateTime FirstWednesday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstWednesday.DayOfWeek == DayOfWeek.Wednesday)
                                                    {
                                                        leaveDate = FirstWednesday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstWednesday = FirstWednesday.AddDays(-1);
                                                    }
                                                }
                                                break;
                                            case "5":
                                                DateTime FirstThursday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstThursday.DayOfWeek == DayOfWeek.Thursday)
                                                    {
                                                        leaveDate = FirstThursday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstThursday = FirstThursday.AddDays(-1);
                                                    }
                                                }
                                                break;
                                            case "6":
                                                DateTime FirstFriday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstFriday.DayOfWeek == DayOfWeek.Friday)
                                                    {
                                                        leaveDate = FirstFriday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstFriday = FirstFriday.AddDays(-1);
                                                    }
                                                }
                                                break;
                                            case "7":
                                                DateTime FirstSaturday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstSaturday.DayOfWeek == DayOfWeek.Saturday)
                                                    {
                                                        leaveDate = FirstSaturday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstSaturday = FirstSaturday.AddDays(-1);
                                                    }
                                                }
                                                break;
                                            case "1":
                                                DateTime FirstSunday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstSunday.DayOfWeek == DayOfWeek.Sunday)
                                                    {
                                                        leaveDate = FirstSunday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstSunday = FirstSunday.AddDays(-1);
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                    if (leaveDate != DateTime.MinValue)
                                    {
                                        MonthlyOffDates.Add(leaveDate);
                                    }
                                }
                            }

                        }








                    }
                }


                //End:EMP-0009



                foreach (DataRow Rowd in dtDutyOffMonthly.Rows)
                {
                    if (Rowd["OFFDUTYDTL_DAYS"].ToString() != "")
                    {
                        int firstdate = 0;

                        if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "1")
                        {
                            for (int i = 0; i <= 2; i++)
                            {
                                if (i == 0)
                                {
                                    firstdate = 1;
                                }
                                else if (i == 1)
                                {
                                    firstdate = 15;
                                }
                                else if (i == 2)
                                {
                                    firstdate = DateTime.DaysInMonth(now.Year, now.Month);
                                    if (firstdate == 28)
                                    {
                                        break;
                                    }
                                    firstdate = 29;
                                }

                                string DaysStr = Rowd["OFFDUTYDTL_DAYS"].ToString();
                                string[] spitDayStr = DaysStr.Split(',');
                                foreach (string strSpliSlice in spitDayStr)
                                {
                                    if (strSpliSlice != "")
                                    {
                                        switch (strSpliSlice)
                                        {
                                            case "2":
                                                DateTime FirstMonday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstMonday.DayOfWeek == DayOfWeek.Monday)
                                                    {
                                                        leaveDate = FirstMonday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstMonday = FirstMonday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "3":
                                                DateTime FirstTuesday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstTuesday.DayOfWeek == DayOfWeek.Tuesday)
                                                    {

                                                        leaveDate = FirstTuesday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstTuesday = FirstTuesday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "4":
                                                DateTime FirstWednesday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstWednesday.DayOfWeek == DayOfWeek.Wednesday)
                                                    {
                                                        leaveDate = FirstWednesday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstWednesday = FirstWednesday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "5":
                                                DateTime FirstThursday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstThursday.DayOfWeek == DayOfWeek.Thursday)
                                                    {
                                                        leaveDate = FirstThursday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstThursday = FirstThursday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "6":
                                                DateTime FirstFriday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstFriday.DayOfWeek == DayOfWeek.Friday)
                                                    {
                                                        leaveDate = FirstFriday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstFriday = FirstFriday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "7":
                                                DateTime FirstSaturday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstSaturday.DayOfWeek == DayOfWeek.Saturday)
                                                    {
                                                        leaveDate = FirstSaturday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstSaturday = FirstSaturday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "1":
                                                DateTime FirstSunday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstSunday.DayOfWeek == DayOfWeek.Sunday)
                                                    {
                                                        leaveDate = FirstSunday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstSunday = FirstSunday.AddDays(1);
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                    if (leaveDate != DateTime.MinValue)
                                    {
                                        MonthlyOffDates.Add(leaveDate);
                                    }
                                }
                            }

                        }


                        if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "4" || Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "5" || Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "6" || Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "7" || Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "8")
                        {
                            int lastWeekDays = DateTime.DaysInMonth(now.Year, now.Month);
                            lastWeekDays = lastWeekDays - 28;
                            int limit = 7;

                            for (int i = 0; i < 1; i++)
                            {
                                if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "4")
                                {
                                    firstdate = 1;
                                }
                                else if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "5")
                                {
                                    firstdate = 8;
                                }
                                else if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "6")
                                {
                                    firstdate = 15;
                                }
                                else if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "7")
                                {
                                    firstdate = 22;
                                }
                                else if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "8")
                                {

                                    limit = lastWeekDays;

                                    if (now.Month == 2)
                                    {
                                        if ((now.Year % 4 == 0 && now.Year % 100 != 0) || (now.Year % 400 == 0))
                                        {
                                            firstdate = 29;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        firstdate = 29;
                                    }

                                }




                                string DaysStr = Rowd["OFFDUTYDTL_DAYS"].ToString();
                                string[] spitDayStr = DaysStr.Split(',');
                                foreach (string strSpliSlice in spitDayStr)
                                {
                                    if (strSpliSlice != "")
                                    {
                                        switch (strSpliSlice)
                                        {
                                            case "2":
                                                DateTime FirstMonday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < limit; count++)
                                                {
                                                    if (FirstMonday.DayOfWeek == DayOfWeek.Monday)
                                                    {
                                                        leaveDate = FirstMonday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstMonday = FirstMonday.AddDays(1);
                                                    }
                                                }

                                                if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() != "8" && (now.Month < now1.Month || now.Year < now1.Year))
                                                {
                                                    FirstMonday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < limit; count++)
                                                    {
                                                        if (FirstMonday.DayOfWeek == DayOfWeek.Monday)
                                                        {
                                                            leaveDate = FirstMonday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstMonday = FirstMonday.AddDays(1);
                                                        }
                                                    }
                                                }
                                                break;
                                            case "3":
                                                DateTime FirstTuesday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < limit; count++)
                                                {
                                                    if (FirstTuesday.DayOfWeek == DayOfWeek.Tuesday)
                                                    {

                                                        leaveDate = FirstTuesday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstTuesday = FirstTuesday.AddDays(1);
                                                    }
                                                }
                                                if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() != "8" && (now.Month < now1.Month || now.Year < now1.Year))
                                                {
                                                    FirstTuesday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < limit; count++)
                                                    {
                                                        if (FirstTuesday.DayOfWeek == DayOfWeek.Tuesday)
                                                        {

                                                            leaveDate = FirstTuesday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstTuesday = FirstTuesday.AddDays(1);
                                                        }
                                                    }
                                                }
                                                break;
                                            case "4":
                                                DateTime FirstWednesday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < limit; count++)
                                                {
                                                    if (FirstWednesday.DayOfWeek == DayOfWeek.Wednesday)
                                                    {
                                                        leaveDate = FirstWednesday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstWednesday = FirstWednesday.AddDays(1);
                                                    }
                                                }

                                                if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() != "8" && (now.Month < now1.Month || now.Year < now1.Year))
                                                {
                                                    FirstWednesday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < limit; count++)
                                                    {
                                                        if (FirstWednesday.DayOfWeek == DayOfWeek.Wednesday)
                                                        {
                                                            leaveDate = FirstWednesday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstWednesday = FirstWednesday.AddDays(1);
                                                        }
                                                    }
                                                }
                                                break;
                                            case "5":
                                                DateTime FirstThursday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < limit; count++)
                                                {
                                                    if (FirstThursday.DayOfWeek == DayOfWeek.Thursday)
                                                    {
                                                        leaveDate = FirstThursday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstThursday = FirstThursday.AddDays(1);
                                                    }
                                                }
                                                if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() != "8" && (now.Month < now1.Month || now.Year < now1.Year))
                                                {
                                                    FirstThursday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < limit; count++)
                                                    {
                                                        if (FirstThursday.DayOfWeek == DayOfWeek.Thursday)
                                                        {
                                                            leaveDate = FirstThursday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstThursday = FirstThursday.AddDays(1);
                                                        }
                                                    }
                                                }
                                                break;
                                            case "6":
                                                DateTime FirstFriday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < limit; count++)
                                                {
                                                    if (FirstFriday.DayOfWeek == DayOfWeek.Friday)
                                                    {
                                                        leaveDate = FirstFriday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstFriday = FirstFriday.AddDays(1);
                                                    }
                                                }
                                                if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() != "8" && (now.Month < now1.Month || now.Year < now1.Year))
                                                {
                                                    FirstFriday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < limit; count++)
                                                    {
                                                        if (FirstFriday.DayOfWeek == DayOfWeek.Friday)
                                                        {
                                                            leaveDate = FirstFriday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstFriday = FirstFriday.AddDays(1);
                                                        }
                                                    }
                                                }
                                                break;
                                            case "7":

                                                DateTime FirstSaturday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < limit; count++)
                                                {
                                                    if (FirstSaturday.DayOfWeek == DayOfWeek.Saturday)
                                                    {
                                                        leaveDate = FirstSaturday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstSaturday = FirstSaturday.AddDays(1);
                                                    }
                                                }
                                                if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() != "8" && (now.Month < now1.Month || now.Year < now1.Year))
                                                {
                                                    FirstSaturday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < limit; count++)
                                                    {
                                                        if (FirstSaturday.DayOfWeek == DayOfWeek.Saturday)
                                                        {
                                                            leaveDate = FirstSaturday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstSaturday = FirstSaturday.AddDays(1);
                                                        }
                                                    }
                                                }
                                                break;
                                            case "1":
                                                DateTime FirstSunday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < limit; count++)
                                                {
                                                    if (FirstSunday.DayOfWeek == DayOfWeek.Sunday)
                                                    {
                                                        leaveDate = FirstSunday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstSunday = FirstSunday.AddDays(1);
                                                    }
                                                }
                                                if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() != "8" && (now.Month < now1.Month || now.Year < now1.Year))
                                                {
                                                    FirstSunday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < limit; count++)
                                                    {
                                                        if (FirstSunday.DayOfWeek == DayOfWeek.Sunday)
                                                        {
                                                            leaveDate = FirstSunday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstSunday = FirstSunday.AddDays(1);
                                                        }
                                                    }
                                                }
                                                break;
                                        }
                                    }

                                }
                            }

                        }

                    }

                }
            }
            if (MonthlyOffDates.Count > 0)
            {

                string HoliName = "", Holi1 = "false";
                foreach (var RowHoli in MonthlyOffDates)
                {
                    DateTime fromdate;
                    string ans;
                    ans = dateCheck.ToString("dd-MM-yyyy");
                    ans = String.Format("{0:dd-MM-yyyy}", ans);
                    fromdate = objCommon.textToDateTime(ans);


                    //to check week off days
                    int weekflag = 0;
                    DateTime fromdate1;
                    string ans1;
                    ans1 = dateCheck.ToString("dd-MM-yyyy");
                    ans1 = String.Format("{0:dd-MM-yyyy}", ans1);
                    fromdate1 = objCommon.textToDateTime(ans1);
                    string strDayWkString1 = RowHoli.ToString("dddd");

                    if (strJbWklyOffDay.Contains(strDayWkString1))
                    {

                        weekflag = 1; ;
                    }
                    if (weekflag != 1)
                    {
                        if (RowHoli == fromdate)
                        {
                            Holi1 = "true";
                            return Holi1;
                        }
                    }
                }
            }
            DateTime fromdate2;
            string ans2;
            ans2 = dateCheck.ToString("dd-MM-yyyy");
            ans2 = String.Format("{0:dd-MM-yyyy}", ans2);
            fromdate2 = objCommon.textToDateTime(ans2);
            string strDayWkString2 = fromdate2.ToString("dddd");
            if (strJbWklyOffDay.Contains(strDayWkString2))
            {

                return "true";
            }
            return "";
        }

        public string checkholiday(DateTime day, DateTime datenow, DateTime enddate)
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
            clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
            DateTime fromdate, todate;
            objEntLevAllocn.LeaveFrmDate = datenow;
            objEntLevAllocn.LeaveToDate = enddate;
            DataTable dtHoliday = objBusLevAllocn.ReadHolidayDate(objEntLevAllocn);

            string HoliName = "", Holi1 = "false";
            foreach (DataRow RowHoli in dtHoliday.Rows)
            {
                string ans;
                ans = day.ToString("dd-MM-yyyy");
                ans = String.Format("{0:dd-MM-yyyy}", ans);
                fromdate = objCommon.textToDateTime(ans);
                if (RowHoli["HLDAYMSTR_DATE"].ToString() != "")
                {
                    if (objCommon.textToDateTime(RowHoli["HLDAYMSTR_DATE"].ToString()) == fromdate)
                    {
                        HoliName = RowHoli["HLDAYMSTR_DATE"].ToString();
                        Holi1 = "true";
                    }
                }
            }
            return Holi1;
        }

    }

    public static string[] MonthSalary(string strEmpId, DateTime dtFromDate, DateTime dtToDate, string strBasicPay, DataTable dtAllownce, DataTable dtDeductn, int ModeProcess, int BasicPayStatus, int FixedSts, string strCorp, string Org, string IndividualRound,string ZeroWorkFixed)
    {
        string[] strJson = new string[12];//10
        decimal TotalDays = 0;
        decimal TotalLeaveCnt = 0;
        decimal decBasicPay = 0;
        decimal decArrearAmnt = 0;
        decimal decAllownc = 0;
        decimal decOvertm = 0;
        decimal decInstlmnt = 0;
        decimal deciDeduction = 0;
        decimal decOtherAddtionAmount = 0;
        decimal decOtherDeductionAmount = 0;

        string strHtmlOtherAdd = "";
        string strHtmlOtherDed = "";
        string strAddDtls = "";
        string strDedDtls = "";

        if ((ModeProcess == 0 && dtToDate.Day > 1) || ModeProcess == 1)
        {
            if (ModeProcess == 0)
            {
                dtToDate = dtToDate.AddDays(-1);
            }
            clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
            clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            objEntityLeavSettlmt.DateStartDate = dtFromDate;
            objEntityLeavSettlmt.DateEndDate = dtToDate;
            objEntityLeavSettlmt.EmployeeId = Convert.ToInt32(strEmpId);
            objEntityLeavSettlmt.UserId = Convert.ToInt32(strEmpId);

            objEntityLeavSettlmt.CorpId = Convert.ToInt32(strCorp);
            objEntityLeavSettlmt.OrgId = Convert.ToInt32(Org);

            TotalDays = Convert.ToInt32((dtToDate - dtFromDate).TotalDays) + 1;
            int daysInm = DateTime.DaysInMonth(dtFromDate.Year, dtFromDate.Month);


            cls_Business_Monthly_Salary_Process objBuss2 = new cls_Business_Monthly_Salary_Process();
            cls_Entity_Monthly_Salary_Process objEnt2 = new cls_Entity_Monthly_Salary_Process();
            objEnt2.Employee = objEntityLeavSettlmt.EmployeeId;
            objEnt2.DateStartDate = objEntityLeavSettlmt.DateEndDate.AddDays(1);
            objEnt2.DateEndDate = new DateTime(dtToDate.Year, 12, 31);
            objEnt2.CorpOffice = Convert.ToInt32(strCorp);
            objEnt2.Orgid = Convert.ToInt32(Org);

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            DataTable dtLeaveDateFuture = new DataTable();
            if (objEnt2.DateStartDate.Year == objEnt2.DateEndDate.Year)
            {
                dtLeaveDateFuture = objBuss2.ReadLeaveDate(objEnt2);
            }



            //Leave count calculation DateEndDate
            string[] stringArray = new string[50];
            int CurrArray = 0;
            DataTable dtLeaveDate = objBusinessLeavSettlmt.ReadLeaveDate(objEntityLeavSettlmt);
            for (int lcnt = 0; lcnt < dtLeaveDate.Rows.Count; lcnt++)
            {

                int HoliPaidSts = Convert.ToInt32(dtLeaveDate.Rows[lcnt]["LEAVETYP_HOLIDAY_PAID_STS"].ToString());
                int OffPaidSts = Convert.ToInt32(dtLeaveDate.Rows[lcnt]["LEAVETYP_OFFDAY_PAID_STS"].ToString());

                dutyOf objDuty = new dutyOf();
                int OffCount = 0;

                decimal dedHalfLeave = 0;
                decimal cnt = 0;
                DateTime LfrmDt = DateTime.MinValue;
                DateTime LToDt = DateTime.MinValue;
                if (dtLeaveDate.Rows[lcnt]["LEAVE_FROM_DATE"].ToString() != "")
                {
                    LfrmDt = objCommon.textToDateTime(dtLeaveDate.Rows[lcnt]["LEAVE_FROM_DATE"].ToString());
                }
                if (dtLeaveDate.Rows[lcnt]["LEAVE_TO_DATE"].ToString() != "")
                {
                    LToDt = objCommon.textToDateTime(dtLeaveDate.Rows[lcnt]["LEAVE_TO_DATE"].ToString());
                }
                if (LfrmDt != DateTime.MinValue && LToDt != DateTime.MinValue)
                {
                    int LvFrmMonth = LfrmDt.Month;
                    int LvFrmYear = LfrmDt.Year;
                    int LvFrmDay = LfrmDt.Day;
                    int LvToMonth = LToDt.Month;
                    int LvToYear = LToDt.Year;
                    int LvToDay = LToDt.Day;
                    if (LvFrmYear == dtFromDate.Year && LvFrmMonth == dtFromDate.Month && LvToYear == dtFromDate.Year && LvToMonth == dtFromDate.Month)
                    {
                        if (LfrmDt < dtFromDate)
                        {
                            LfrmDt = dtFromDate;
                        }
                        else
                        {
                            if (dtLeaveDate.Rows[lcnt]["LEAVE_FROM_SCTN"].ToString() != "1")
                            {
                                dedHalfLeave = dedHalfLeave + (decimal)0.5;
                            }
                        }
                        if (LToDt > dtToDate)
                        {
                            LToDt = dtToDate;
                        }
                        else
                        {
                            if (dtLeaveDate.Rows[lcnt]["LEAVE_TO_SCTN"].ToString() != "1")
                            {
                                dedHalfLeave = dedHalfLeave + (decimal)0.5;
                            }
                        }

                        cnt = LToDt.Day - LfrmDt.Day + 1;
                        cnt = cnt - dedHalfLeave;


                        DateTime datenow, enddate;
                        datenow = LfrmDt;
                        enddate = LToDt;
                        if (HoliPaidSts == 1 || OffPaidSts == 1)
                        {
                            for (var day = datenow; day <= enddate; day = day.AddDays(1))
                            {
                                string hol = "false";
                                if (HoliPaidSts == 1)
                                {
                                    hol = objDuty.checkholiday(day, datenow, enddate);
                                    if (hol == "true")
                                    {
                                        OffCount = OffCount + 1;
                                    }
                                }
                                if (OffPaidSts == 1 && hol != "true")
                                {
                                    string off = objDuty.CheckDutyOff(day, objEnt2.CorpOffice.ToString(), objEnt2.Orgid.ToString());
                                    if (off == "true")
                                    {
                                        OffCount = OffCount + 1;
                                    }
                                }
                            }
                        }


                        cnt = cnt - OffCount;
                        if (cnt < 0)
                        {
                            cnt = 0;
                        }



                        if (dtLeaveDate.Rows[lcnt]["LEAVETYPDTLS_PAIDLEAVE"].ToString() == "0")
                        {
                            string stringToCheck = dtLeaveDate.Rows[lcnt]["LEAVETYP_ID"].ToString();

                            decimal FutureLeaveCnt = calcFutureLeaveCnt(stringToCheck, dtLeaveDateFuture, objEnt2);
                            decimal BalCount = Convert.ToDecimal(dtLeaveDate.Rows[lcnt]["BALANCE_NUMLEAVE"].ToString()) + FutureLeaveCnt;

                            int FindSts = 0;
                            for (int i = 0; i < CurrArray; i++)
                            {
                                if (stringArray[i] != null && stringArray[i].Contains(stringToCheck))
                                {
                                    FindSts = 1;
                                    string[] stringArrayX = stringArray[i].Split(',');
                                    decimal decPrevCount = Convert.ToDecimal(stringArrayX[1]) + cnt;
                                    stringArray[i] = stringToCheck + "," + decPrevCount + "," + dtLeaveDate.Rows[lcnt]["OPENING_NUMLEAVE"].ToString() + "," + BalCount.ToString();
                                }
                            }
                            if (FindSts == 0)
                            {
                                stringArray[CurrArray] = stringToCheck + "," + cnt + "," + dtLeaveDate.Rows[lcnt]["OPENING_NUMLEAVE"].ToString() + "," + BalCount.ToString();
                                CurrArray += 1;
                            }
                            cnt = 0;
                        }
                    }
                    else if (LvToYear == dtFromDate.Year && LvToMonth == dtFromDate.Month)
                    {
                        LfrmDt = dtFromDate;
                        if (LToDt > dtToDate)
                        {
                            LToDt = dtToDate;
                        }
                        else
                        {
                            if (dtLeaveDate.Rows[lcnt]["LEAVE_TO_SCTN"].ToString() != "1")
                            {
                                dedHalfLeave = dedHalfLeave + (decimal)0.5;
                            }
                        }

                        cnt = LToDt.Day - LfrmDt.Day + 1;
                        cnt = cnt - dedHalfLeave;

                        DateTime datenow, enddate;
                        datenow = LfrmDt;
                        enddate = LToDt;
                        if (HoliPaidSts == 1 || OffPaidSts == 1)
                        {
                            for (var day = datenow; day <= enddate; day = day.AddDays(1))
                            {
                                string hol = "false";
                                if (HoliPaidSts == 1)
                                {
                                    hol = objDuty.checkholiday(day, datenow, enddate);
                                    if (hol == "true")
                                    {
                                        OffCount = OffCount + 1;
                                    }
                                }
                                if (OffPaidSts == 1 && hol != "true")
                                {
                                    string off = objDuty.CheckDutyOff(day, objEnt2.CorpOffice.ToString(), objEnt2.Orgid.ToString());
                                    if (off == "true")
                                    {
                                        OffCount = OffCount + 1;
                                    }
                                }
                            }
                        }

                        cnt = cnt - OffCount;
                        if (cnt < 0)
                        {
                            cnt = 0;
                        }



                        if (dtLeaveDate.Rows[lcnt]["LEAVETYPDTLS_PAIDLEAVE"].ToString() == "0")
                        {
                            string stringToCheck = dtLeaveDate.Rows[lcnt]["LEAVETYP_ID"].ToString();

                            decimal FutureLeaveCnt = calcFutureLeaveCnt(stringToCheck, dtLeaveDateFuture, objEnt2);
                            decimal BalCount = Convert.ToDecimal(dtLeaveDate.Rows[lcnt]["BALANCE_NUMLEAVE"].ToString()) + FutureLeaveCnt;
                            int FindSts = 0;
                            for (int i = 0; i < CurrArray; i++)
                            {
                                if (stringArray[i] != null && stringArray[i].Contains(stringToCheck))
                                {
                                    FindSts = 1;
                                    string[] stringArrayX = stringArray[i].Split(',');
                                    decimal decPrevCount = Convert.ToDecimal(stringArrayX[1]) + cnt;
                                    stringArray[i] = stringToCheck + "," + decPrevCount + "," + dtLeaveDate.Rows[lcnt]["OPENING_NUMLEAVE"].ToString() + "," + BalCount.ToString();
                                }
                            }
                            if (FindSts == 0)
                            {
                                stringArray[CurrArray] = stringToCheck + "," + cnt + "," + dtLeaveDate.Rows[lcnt]["OPENING_NUMLEAVE"].ToString() + "," + BalCount.ToString();
                                CurrArray += 1;
                            }
                            cnt = 0;

                        }
                    }
                    else if (LvFrmYear == dtFromDate.Year && LvFrmMonth == dtFromDate.Month)
                    {

                        if (LfrmDt < dtFromDate)
                        {
                            LfrmDt = dtFromDate;
                        }
                        else
                        {
                            if (dtLeaveDate.Rows[lcnt]["LEAVE_FROM_SCTN"].ToString() != "1")
                            {
                                dedHalfLeave = dedHalfLeave + (decimal)0.5;
                            }
                        }
                        LToDt = dtToDate;

                        cnt = LToDt.Day - LfrmDt.Day + 1;
                        cnt = cnt - dedHalfLeave;

                        DateTime datenow, enddate;
                        datenow = LfrmDt;
                        enddate = LToDt;
                        if (HoliPaidSts == 1 || OffPaidSts == 1)
                        {
                            for (var day = datenow; day <= enddate; day = day.AddDays(1))
                            {
                                string hol = "false";
                                if (HoliPaidSts == 1)
                                {
                                    hol = objDuty.checkholiday(day, datenow, enddate);
                                    if (hol == "true")
                                    {
                                        OffCount = OffCount + 1;
                                    }
                                }
                                if (OffPaidSts == 1 && hol != "true")
                                {
                                    string off = objDuty.CheckDutyOff(day, objEnt2.CorpOffice.ToString(), objEnt2.Orgid.ToString());
                                    if (off == "true")
                                    {
                                        OffCount = OffCount + 1;
                                    }
                                }
                            }
                        }

                        cnt = cnt - OffCount;
                        if (cnt < 0)
                        {
                            cnt = 0;
                        }


                        if (dtLeaveDate.Rows[lcnt]["LEAVETYPDTLS_PAIDLEAVE"].ToString() == "0")
                        {
                            string stringToCheck = dtLeaveDate.Rows[lcnt]["LEAVETYP_ID"].ToString();

                            decimal FutureLeaveCnt = calcFutureLeaveCnt(stringToCheck, dtLeaveDateFuture, objEnt2);
                            decimal BalCount = Convert.ToDecimal(dtLeaveDate.Rows[lcnt]["BALANCE_NUMLEAVE"].ToString()) + FutureLeaveCnt;
                            int FindSts = 0;
                            for (int i = 0; i < CurrArray; i++)
                            {
                                if (stringArray[i] != null && stringArray[i].Contains(stringToCheck))
                                {
                                    FindSts = 1;
                                    string[] stringArrayX = stringArray[i].Split(',');
                                    decimal decPrevCount = Convert.ToDecimal(stringArrayX[1]) + cnt;
                                    stringArray[i] = stringToCheck + "," + decPrevCount + "," + dtLeaveDate.Rows[lcnt]["OPENING_NUMLEAVE"].ToString() + "," + BalCount.ToString();
                                }
                            }
                            if (FindSts == 0)
                            {
                                stringArray[CurrArray] = stringToCheck + "," + cnt + "," + dtLeaveDate.Rows[lcnt]["OPENING_NUMLEAVE"].ToString() + "," + BalCount.ToString();
                                CurrArray += 1;
                            }
                            cnt = 0;

                        }
                    }

                    else //if (LvFrmYear <= OBJ.Year && LvFrmMonth < OBJ.Month && LvToYear >= OBJ.Year && LvToMonth > OBJ.Month)
                    {
                        cnt = dtToDate.Day - dtFromDate.Day + 1;
                        if (dtLeaveDate.Rows[lcnt]["LEAVE_FROM_SCTN"].ToString() != "1")
                        {
                            cnt = cnt - (decimal)0.5;
                        }
                        if (dtLeaveDate.Rows[lcnt]["LEAVE_TO_SCTN"].ToString() != "1")
                        {
                            cnt = cnt - (decimal)0.5;
                        }

                        DateTime datenow, enddate;
                        datenow = dtFromDate;
                        enddate = dtToDate;


                        if (HoliPaidSts == 1 || OffPaidSts == 1)
                        {
                            for (var day = datenow; day <= enddate; day = day.AddDays(1))
                            {
                                string hol = "false";
                                if (HoliPaidSts == 1)
                                {
                                    hol = objDuty.checkholiday(day, datenow, enddate);
                                    if (hol == "true")
                                    {
                                        OffCount = OffCount + 1;
                                    }
                                }
                                if (OffPaidSts == 1 && hol != "true")
                                {
                                    string off = objDuty.CheckDutyOff(day, objEnt2.CorpOffice.ToString(), objEnt2.Orgid.ToString());
                                    if (off == "true")
                                    {
                                        OffCount = OffCount + 1;
                                    }
                                }
                            }
                        }
                        cnt = cnt - OffCount;
                        if (cnt < 0)
                        {
                            cnt = 0;
                        }
                        if (dtLeaveDate.Rows[lcnt]["LEAVETYPDTLS_PAIDLEAVE"].ToString() == "0")
                        {
                            string stringToCheck = dtLeaveDate.Rows[lcnt]["LEAVETYP_ID"].ToString();
                            decimal FutureLeaveCnt = calcFutureLeaveCnt(stringToCheck, dtLeaveDateFuture, objEnt2);
                            decimal BalCount = Convert.ToDecimal(dtLeaveDate.Rows[lcnt]["BALANCE_NUMLEAVE"].ToString()) + FutureLeaveCnt;
                            int FindSts = 0;
                            for (int i = 0; i < CurrArray; i++)
                            {
                                if (stringArray[i] != null && stringArray[i].Contains(stringToCheck))
                                {
                                    FindSts = 1;
                                    string[] stringArrayX = stringArray[i].Split(',');
                                    decimal decPrevCount = Convert.ToDecimal(stringArrayX[1]) + cnt;
                                    stringArray[i] = stringToCheck + "," + decPrevCount + "," + dtLeaveDate.Rows[lcnt]["OPENING_NUMLEAVE"].ToString() + "," + BalCount.ToString();
                                }
                            }
                            if (FindSts == 0)
                            {
                                stringArray[CurrArray] = stringToCheck + "," + cnt + "," + dtLeaveDate.Rows[lcnt]["OPENING_NUMLEAVE"].ToString() + "," + BalCount.ToString();
                                CurrArray += 1;
                            }
                            cnt = 0;
                        }
                    }
                }
                else if (LfrmDt != DateTime.MinValue && LToDt == DateTime.MinValue)
                {
                    int LvFrmMonth = LfrmDt.Month;
                    int LvFrmYear = LfrmDt.Year;
                    int LvFrmDay = LfrmDt.Day;
                    if (LvFrmYear == dtFromDate.Year && LvFrmMonth == dtFromDate.Month)
                    {
                        if (dtLeaveDate.Rows[lcnt]["LEAVE_FROM_SCTN"].ToString() == "1")
                        {
                            cnt = 1;
                        }
                        else
                        {
                            cnt = (decimal)0.5;
                        }
                        if (dtLeaveDate.Rows[lcnt]["LEAVETYPDTLS_PAIDLEAVE"].ToString() == "0")
                        {
                            string stringToCheck = dtLeaveDate.Rows[lcnt]["LEAVETYP_ID"].ToString();

                            decimal FutureLeaveCnt = calcFutureLeaveCnt(stringToCheck, dtLeaveDateFuture, objEnt2);
                            decimal BalCount = Convert.ToDecimal(dtLeaveDate.Rows[lcnt]["BALANCE_NUMLEAVE"].ToString()) + FutureLeaveCnt;
                            int FindSts = 0;
                            for (int i = 0; i < CurrArray; i++)
                            {
                                if (stringArray[i] != null && stringArray[i].Contains(stringToCheck))
                                {
                                    FindSts = 1;
                                    string[] stringArrayX = stringArray[i].Split(',');
                                    decimal decPrevCount = Convert.ToDecimal(stringArrayX[1]) + cnt;
                                    stringArray[i] = stringToCheck + "," + decPrevCount + "," + dtLeaveDate.Rows[lcnt]["OPENING_NUMLEAVE"].ToString() + "," + BalCount.ToString();
                                }
                            }
                            if (FindSts == 0)
                            {
                                stringArray[CurrArray] = stringToCheck + "," + cnt + "," + dtLeaveDate.Rows[lcnt]["OPENING_NUMLEAVE"].ToString() + "," + BalCount.ToString();
                                CurrArray += 1;
                            }
                            cnt = 0;

                        }
                    }
                }
                TotalLeaveCnt += cnt;
            }

            for (int i = 0; i < CurrArray; i++)
            {
                string[] stringArrayX = stringArray[i].Split(',');
                decimal decTotLeaveCount = Convert.ToDecimal(stringArrayX[1]);
                decimal decOpenCount = Convert.ToDecimal(stringArrayX[2]);
                decimal decBalCount = Convert.ToDecimal(stringArrayX[3]);
                if (decBalCount < 0)
                {
                    decBalCount = decBalCount * -1;
                    if (decBalCount >= decTotLeaveCount)
                    {
                        TotalLeaveCnt += decTotLeaveCount;
                    }
                    else
                    {
                        TotalLeaveCnt += decBalCount;
                    }
                }
            }



            if (TotalDays > TotalLeaveCnt || ZeroWorkFixed=="1")
            {
                //Basic pay calculation       
                if (strBasicPay != "")
                {
                    decBasicPay = Convert.ToDecimal(strBasicPay) / daysInm;
                    if (BasicPayStatus == 0)
                    {
                        if (FixedSts == 0)
                        {
                            decBasicPay = Convert.ToDecimal(strBasicPay);
                        }
                        else
                        {
                            decBasicPay = 0;
                        }
                    }
                    else
                    {
                        decBasicPay = decBasicPay * (TotalDays - TotalLeaveCnt);
                    }
                }

                //Arrear amount calculation      
                int CurrMonth = dtFromDate.Month;
                int CurrYear = dtFromDate.Year;
                int PrevMnth = 0, PrevYear = 0;
                if (CurrMonth == 1)
                {
                    PrevMnth = 12;
                    PrevYear = CurrYear - 1;
                }
                else
                {
                    PrevMnth = CurrMonth - 1;
                    PrevYear = CurrYear;
                }
                objEntityLeavSettlmt.PrevMnth = PrevMnth;
                objEntityLeavSettlmt.Year = PrevYear;
                DataTable dtSalMnth = objBusinessLeavSettlmt.ReadMonthsalary(objEntityLeavSettlmt);
                if (dtSalMnth.Rows.Count > 0)
                {
                    if (dtSalMnth.Rows[0]["SLPRCDMNTH_ARREAR_AMNT"].ToString() != "")
                    {
                        decArrearAmnt = Convert.ToDecimal(dtSalMnth.Rows[0]["SLPRCDMNTH_ARREAR_AMNT"].ToString());
                    }
                }

                string pmonth = objEntityLeavSettlmt.DateEndDate.Month.ToString("00");
                string pyear = objEntityLeavSettlmt.DateEndDate.Year.ToString();

                objEnt2.Month = Convert.ToInt32(pmonth);
                objEnt2.Year = Convert.ToInt32(pyear);
                //Other Addition & Deduction
                DataTable dtOther_Addition = objBuss2.ReadEmpManualy_AdditionDetails(objEnt2);
                DataTable dtOther_Deduction = objBuss2.ReadEmpManualy_DeductionsDetails(objEnt2);

                objEntityLeavSettlmt.Month = Convert.ToInt32(pmonth);
                objEntityLeavSettlmt.Year = Convert.ToInt32(pyear);

                //     DataTable dtOtherAdd_DedDtls = objBusinessLeavSettlmt.ReadEmpManualy_Add_Dedn_Details(objEntityLeavSettlmt);


                int PAYINF_ID = 0;

                if (dtOther_Addition.Rows.Count > 0)
                {
                    for (int intRow = 0; intRow < dtOther_Addition.Rows.Count; intRow++)
                    {
                        decOtherAddtionAmount += Convert.ToDecimal(dtOther_Addition.Rows[intRow]["OTHER_ADDITION"].ToString());
                        PAYINF_ID = Convert.ToInt32(dtOther_Addition.Rows[intRow]["PAYINF_ID"].ToString());

                        string strOthrAddAmt = Convert.ToString(Convert.ToDecimal(dtOther_Addition.Rows[intRow]["OTHER_ADDITION"]).ToString("0.00"));

                        if (IndividualRound == "1" && strOthrAddAmt != "")
                        {
                            strOthrAddAmt = Math.Round(Convert.ToDecimal(strOthrAddAmt), 0).ToString("0.00");
                        }
                        if (strHtmlOtherAdd == "")
                        {
                            strHtmlOtherAdd += dtOther_Addition.Rows[intRow]["PAYRL_CODE"].ToString() + " : " + strOthrAddAmt;
                        }
                        else
                        {
                            strHtmlOtherAdd += ", " + dtOther_Addition.Rows[intRow]["PAYRL_CODE"].ToString() + " : " + strOthrAddAmt;
                        }
                    }
                }

                if (dtOther_Deduction.Rows.Count > 0)
                {
                    for (int intRow = 0; intRow < dtOther_Deduction.Rows.Count; intRow++)
                    {
                        decOtherDeductionAmount += Convert.ToDecimal(dtOther_Deduction.Rows[intRow]["OTHER_DEDUCTION"].ToString());
                        PAYINF_ID = Convert.ToInt32(dtOther_Deduction.Rows[intRow]["PAYINF_ID"].ToString());

                        string strOthrDeductAmt = Convert.ToString(Convert.ToDecimal(dtOther_Deduction.Rows[intRow]["OTHER_DEDUCTION"]).ToString("0.00"));
                        if (IndividualRound == "1" && strOthrDeductAmt != "")
                        {
                            strOthrDeductAmt = Math.Round(Convert.ToDecimal(strOthrDeductAmt), 0).ToString("0.00");
                        }
                        if (strHtmlOtherDed == "")
                        {
                            strHtmlOtherDed += dtOther_Deduction.Rows[intRow]["PAYRL_CODE"].ToString() + " : " + strOthrDeductAmt;
                        }
                        else
                        {
                            strHtmlOtherDed += ", " + dtOther_Deduction.Rows[intRow]["PAYRL_CODE"].ToString() + " : " + strOthrDeductAmt;
                        }
                    }
                }



                //Addition calculation      
                for (int intRowCount = 0; intRowCount < dtAllownce.Rows.Count; intRowCount++)
                {
                    decimal DecAlwancAmt = 0;
                    if (dtAllownce.Rows[intRowCount]["SLRYALLCE_AMOUNT"].ToString() != "")
                    {
                        if (dtAllownce.Rows[intRowCount]["PAYRL_TYPE_STS"].ToString() == "0")//Fixed Allowance
                        {
                            if (FixedSts == 0)
                            {
                                DecAlwancAmt = Convert.ToDecimal(dtAllownce.Rows[intRowCount]["SLRYALLCE_AMOUNT"].ToString());
                            }
                        }
                        else//Variable Allowance
                        {
                            DecAlwancAmt = Convert.ToDecimal(dtAllownce.Rows[intRowCount]["SLRYALLCE_AMOUNT"].ToString());
                            decimal amtOneDay = DecAlwancAmt / daysInm;
                            DecAlwancAmt = amtOneDay * (TotalDays - TotalLeaveCnt);
                        }
                        if (strAddDtls == "")
                        {
                            strAddDtls += dtAllownce.Rows[intRowCount]["PGALLCE_ID"].ToString() + "-" + dtAllownce.Rows[intRowCount]["PYGRD_ID"].ToString() + "-" + dtAllownce.Rows[intRowCount]["SLRYALLCE_AMOUNT"].ToString() + "-" + DecAlwancAmt.ToString() + "-" + ModeProcess.ToString();
                        }
                        else
                        {
                            strAddDtls += "%" + dtAllownce.Rows[intRowCount]["PGALLCE_ID"].ToString() + "-" + dtAllownce.Rows[intRowCount]["PYGRD_ID"].ToString() + "-" + dtAllownce.Rows[intRowCount]["SLRYALLCE_AMOUNT"].ToString() + "-" + DecAlwancAmt.ToString() + "-" + ModeProcess.ToString();
                        }
                    }
                    decAllownc += DecAlwancAmt;
                }

                //Overtime amount calculation       
                DataTable dtOvertm = objBusinessLeavSettlmt.ReadOvertimeAdd(objEntityLeavSettlmt);
                if (dtOvertm.Rows.Count > 0 && dtOvertm.Rows[0]["AMOUNT"].ToString() != "")
                {
                    //EVM-0012
                    //Modification on OT calculation 5440
                    decimal decPerHourSal = Convert.ToDecimal(strBasicPay) / daysInm;
                    if (decPerHourSal > 0)
                    {
                        //Per Hour Salary
                        decPerHourSal = decPerHourSal / 8;
                    }
                    decOvertm = Convert.ToDecimal(dtOvertm.Rows[0]["AMOUNT"].ToString());
                    decOvertm = decOvertm * decPerHourSal;
                }



                //Installment amount       
                DataTable dtDeductnMstr = objBusinessLeavSettlmt.ReadDeductionMaster(objEntityLeavSettlmt);
                if (dtDeductnMstr.Rows.Count > 0)
                {
                    if (dtDeductnMstr.Rows[0]["DEDUCTNAMT"].ToString() != "")
                    {
                        decInstlmnt = Convert.ToDecimal(dtDeductnMstr.Rows[0]["DEDUCTNAMT"].ToString());
                    }
                }

                //deduction amount      
                for (int intRowCount = 0; intRowCount < dtDeductn.Rows.Count; intRowCount++)
                {
                    decimal DecDeduction = 0, DecDeductionbasicPay = 0, DecDeductionTotlPay = 0, DecCurrAmnt = 0;
                    if (dtDeductn.Rows[intRowCount]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString() == "0")//Amount deduction
                    {
                        if (dtDeductn.Rows[intRowCount]["SLRYDEDTN_AMOUNT"].ToString() != "")
                        {
                            if (dtDeductn.Rows[intRowCount]["PAYRL_TYPE_STS"].ToString() == "0")//Fixed deduction
                            {
                                if (FixedSts == 0)
                                {
                                    DecDeduction = Convert.ToDecimal(dtDeductn.Rows[intRowCount]["SLRYDEDTN_AMOUNT"].ToString());
                                }
                            }
                            else//Variable deduction
                            {
                                DecDeduction = Convert.ToDecimal(dtDeductn.Rows[intRowCount]["SLRYDEDTN_AMOUNT"].ToString());
                                decimal amtOneDay = DecDeduction / daysInm;
                                DecDeduction = amtOneDay * (TotalDays - TotalLeaveCnt);
                            }
                        }
                        DecCurrAmnt = DecDeduction;
                    }
                    else if (dtDeductn.Rows[intRowCount]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString() == "1")//Percentage deduction
                    {
                        if (dtDeductn.Rows[intRowCount]["SLRYDEDTN_BASIC_OR_TOTAL_AMNT"].ToString() == "0") //basic pay deductn
                        {
                            if (dtDeductn.Rows[intRowCount]["PAYRL_TYPE_STS"].ToString() == "0")//Fixed deduction
                            {
                                if (FixedSts == 0)
                                {
                                    DecDeductionbasicPay = Convert.ToDecimal(dtDeductn.Rows[intRowCount]["SLRYDEDTN_PERCNTGE"].ToString());
                                    DecDeductionbasicPay = Convert.ToDecimal(strBasicPay) * (DecDeductionbasicPay / 100);
                                }
                            }
                            else //variable deduction
                            {
                                DecDeductionbasicPay = Convert.ToDecimal(dtDeductn.Rows[intRowCount]["SLRYDEDTN_PERCNTGE"].ToString());
                                DecDeductionbasicPay = Convert.ToDecimal(strBasicPay) * (DecDeductionbasicPay / 100);
                                decimal amtOneDay = DecDeductionbasicPay / daysInm;
                                DecDeductionbasicPay = amtOneDay * (TotalDays - TotalLeaveCnt);
                            }
                            DecCurrAmnt = DecDeductionbasicPay;
                        }
                        else if (dtDeductn.Rows[intRowCount]["SLRYDEDTN_BASIC_OR_TOTAL_AMNT"].ToString() == "1") //total pay deductn
                        {
                            if (dtDeductn.Rows[intRowCount]["PAYRL_TYPE_STS"].ToString() == "0")//Fixed deduction
                            {
                                if (FixedSts == 0)
                                {
                                    DecDeductionTotlPay = Convert.ToDecimal(dtDeductn.Rows[intRowCount]["SLRYDEDTN_PERCNTGE"].ToString());
                                    DecDeductionTotlPay = (Convert.ToDecimal(strBasicPay) + decAllownc) * (DecDeductionTotlPay / 100);
                                }
                            }
                            else//Variable deduction
                            {
                                DecDeductionTotlPay = Convert.ToDecimal(dtDeductn.Rows[intRowCount]["SLRYDEDTN_PERCNTGE"].ToString());
                                DecDeductionTotlPay = (Convert.ToDecimal(strBasicPay) + decAllownc) * (DecDeductionTotlPay / 100);
                                decimal amtOneDay = DecDeductionTotlPay / daysInm;
                                DecDeductionTotlPay = amtOneDay * (TotalDays - TotalLeaveCnt);

                            }
                            DecCurrAmnt = DecDeductionTotlPay;
                        }
                    }
                    if (strDedDtls == "")
                    {
                        strDedDtls += dtDeductn.Rows[intRowCount]["PGDEDTN_ID"].ToString() + "-" + dtDeductn.Rows[intRowCount]["PYGRD_ID"].ToString() + "-" + dtDeductn.Rows[intRowCount]["SLRYDEDTN_AMOUNT"].ToString() + "-" + dtDeductn.Rows[intRowCount]["SLRYDEDTN_PERCNTGE"].ToString() + "-" + dtDeductn.Rows[intRowCount]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString() + "-" + dtDeductn.Rows[intRowCount]["SLRYDEDTN_BASIC_OR_TOTAL_AMNT"].ToString() + "-" + DecCurrAmnt.ToString() + "-" + ModeProcess.ToString();
                    }
                    else
                    {
                        strDedDtls += "%" + dtDeductn.Rows[intRowCount]["PGDEDTN_ID"].ToString() + "-" + dtDeductn.Rows[intRowCount]["PYGRD_ID"].ToString() + "-" + dtDeductn.Rows[intRowCount]["SLRYDEDTN_AMOUNT"].ToString() + "-" + dtDeductn.Rows[intRowCount]["SLRYDEDTN_PERCNTGE"].ToString() + "-" + dtDeductn.Rows[intRowCount]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString() + "-" + dtDeductn.Rows[intRowCount]["SLRYDEDTN_BASIC_OR_TOTAL_AMNT"].ToString() + "-" + DecCurrAmnt.ToString() + "-" + ModeProcess.ToString();
                    }
                    deciDeduction += DecDeduction + DecDeductionbasicPay + DecDeductionTotlPay;
                }
            }
        }
        strJson[0] = decArrearAmnt.ToString();
        strJson[1] = decBasicPay.ToString();
        strJson[2] = decAllownc.ToString();
        strJson[3] = decOvertm.ToString();
        strJson[4] = deciDeduction.ToString();
        strJson[5] = decInstlmnt.ToString();
        strJson[6] = decOtherAddtionAmount.ToString();
        strJson[7] = decOtherDeductionAmount.ToString();
        strJson[8] = strHtmlOtherAdd.ToString();
        strJson[9] = strHtmlOtherDed.ToString();
        strJson[10] = strAddDtls;
        strJson[11] = strDedDtls;
        return strJson;
    }


    [WebMethod]
    public static string[] SalaryDtlsChanged(string strEmpId, string strSettlmtDays, string strLevSal, string strprevMnth, string strCurntMnth, string strTickt, string strOtherAmt, string strOtherDeductn, string strDecmlCnt, string strOpenLeaveSal, string strLeavArrearAmnt, string IndividualRound, string PrevArrAmnt)
    {
        string[] strJson = new string[30];

        clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
        clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
        if (strEmpId != "--SELECT EMPLOYEE--" && strEmpId != "")
        {
            objEntityLeavSettlmt.EmployeeId = Convert.ToInt32(strEmpId);


            double SettlmtDays = Convert.ToDouble(strSettlmtDays);

            double leavSal = Convert.ToDouble(strLevSal);
            double PrevMnthSal = Convert.ToDouble(strprevMnth);
            double CurntMnthSal = Convert.ToDouble(strCurntMnth);

            DataTable dtTickt = objBusinessLeavSettlmt.ReadEmpLeav(objEntityLeavSettlmt);
            if (dtTickt.Rows.Count > 0)
            {
                if (dtTickt.Rows[0]["LEAVE_NEED_TRVL_TCKT"].ToString() != "")
                {
                    int TicktReq = Convert.ToInt32(dtTickt.Rows[0]["LEAVE_NEED_TRVL_TCKT"].ToString());
                }
            }

            double Tickt = Convert.ToDouble(strTickt);
            double OtherAmt = Convert.ToDouble(strOtherAmt);
            double OtherDeductn = Convert.ToDouble(strOtherDeductn);
            double OpenLEaveSal = Convert.ToDouble(strOpenLeaveSal);
            double LeaveArreAmnt = Convert.ToDouble(strLeavArrearAmnt);

            int decmlcnt = Convert.ToInt32(strDecmlCnt);

           // double NetAmt = leavSal + PrevMnthSal + CurntMnthSal + Tickt + OtherAmt + OpenLEaveSal - OtherDeductn - LeaveArreAmnt;
            double NetAmt = leavSal + PrevMnthSal + CurntMnthSal + Tickt + OtherAmt + Convert.ToDouble(PrevArrAmnt) - OtherDeductn - LeaveArreAmnt;

            string FinalNetAmt = Math.Round(NetAmt, 0).ToString();//NetAmt.ToString();

            strJson[0] = FinalNetAmt;
            if (IndividualRound == "1")
            {
                strJson[1] = Math.Round(Tickt, 0).ToString();
            }
        }

        return strJson;

    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
        clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
        List<clsEntityLayerLeaveSettlmt> objEntityLeaveTypSettlmt = new List<clsEntityLayerLeaveSettlmt>();
        //txtOtherAmt txtOtherDeductn PrevAdditionAmnt objEntityLeavSettlmt.LeaveId objEntityLeaveSettlmt.SettlmtDate
        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLeavSettlmt.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityLeavSettlmt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityLeavSettlmt.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (hiddenEmpId.Value != "")
        {
            objEntityLeavSettlmt.EmployeeId = Convert.ToInt32(hiddenEmpId.Value);
        }


        if (HiddenFieldPrevAddition.Value != "")
        {
            objEntityLeavSettlmt.PrevAdditionAmnt = Convert.ToDecimal(HiddenFieldPrevAddition.Value);
        }
        if (HiddenFieldPrevOvertimeAmt.Value != "")
        {
            objEntityLeavSettlmt.PrevOvertimeAmnt = Convert.ToDecimal(HiddenFieldPrevOvertimeAmt.Value);
        }
        if (HiddenFieldPrevArrearAmt.Value != "")
        {
            objEntityLeavSettlmt.PrevArrearAmnt = Convert.ToDecimal(HiddenFieldPrevArrearAmt.Value);
        }
        if (HiddenFieldPrevDeduction.Value != "")
        {
            objEntityLeavSettlmt.PrevDeductionAmnt = Convert.ToDecimal(HiddenFieldPrevDeduction.Value);
        }
        if (HiddenFieldPrevPaymntAmt.Value != "")
        {
            objEntityLeavSettlmt.PrevPaymntDedAmnt = Convert.ToDecimal(HiddenFieldPrevPaymntAmt.Value);
        }
        if (HiddenFieldPrevMessAmt.Value != "")
        {
            objEntityLeavSettlmt.PrevMessDedAmnt = Convert.ToDecimal(HiddenFieldPrevMessAmt.Value);
        }

        if (HiddenFieldPrevOtherAddAmt.Value != "")
        {
            objEntityLeavSettlmt.PrevOtherAddAmnt = Convert.ToDecimal(HiddenFieldPrevOtherAddAmt.Value);
        }
        if (HiddenFieldPrevOtherDeductAmt.Value != "")
        {
            objEntityLeavSettlmt.PrevOtherDedAmnt = Convert.ToDecimal(HiddenFieldPrevOtherDeductAmt.Value);
        }



        if (HiddenFieldOpenLeaveDays.Value != "")
        {
            objEntityLeavSettlmt.OpenElgibleDays = Convert.ToDecimal(HiddenFieldOpenLeaveDays.Value);
        }
        if (HiddenFieldOpenLeaveSalary.Value != "")
        {
            objEntityLeavSettlmt.OpenLeaveSalary = Convert.ToDecimal(HiddenFieldOpenLeaveSalary.Value);
        }

        if (HiddenFieldLeavArrearAmnt.Value != "")
        {
            objEntityLeavSettlmt.LeaveArrearAmnt = Convert.ToDecimal(HiddenFieldLeavArrearAmnt.Value);
        }


        if (hiddenSettlmtDays.Value != "")
        {
            objEntityLeavSettlmt.SettlmtDays = Convert.ToDouble(hiddenSettlmtDays.Value);
        }
        else
        {
            objEntityLeavSettlmt.SettlmtDays = Convert.ToInt32(lblEligibleSettlmt.Text);
        }
        if (HiddenNoLeaveDeduct.Value != "")
        {
            objEntityLeavSettlmt.CnclReason = HiddenNoLeaveDeduct.Value;
        }



        if (HiddenFieldPrevMntRejoinDate.Value != "")
        {
            objEntityLeavSettlmt.PrevMntRejoinDate = objCommon.textToDateTime(HiddenFieldPrevMntRejoinDate.Value);
        }
        if (HiddenFieldPrevArrAmt.Value != "" && HiddenFieldPrevArrAmt.Value != null)
        {
            objEntityLeavSettlmt.PrevMnthArrAmt = Convert.ToDecimal(HiddenFieldPrevArrAmt.Value);
        }


        if (hiddenRejoinDt.Value != "")
        {
            objEntityLeavSettlmt.RejoinDate = objCommon.textToDateTime(hiddenRejoinDt.Value);
        }
        else
        {
            objEntityLeavSettlmt.RejoinDate = objCommon.textToDateTime(lblRejoinDate.Text);
        }
        if (txtRemarks.Text != "")
        {
            objEntityLeavSettlmt.Remarks = txtRemarks.Text.Trim();
        }

        if (hiddenSettldDate.Value != "")
        {
            objEntityLeavSettlmt.SettlmtDate = objCommon.textToDateTime(hiddenSettldDate.Value);

            DateTime dtLastLeaveCurr = objCommon.textToDateTime(hiddenSettldDate.Value.ToString());
            string pmonth = dtLastLeaveCurr.Month.ToString("00");
            string pyear = dtLastLeaveCurr.Year.ToString();
            objEntityLeavSettlmt.Month = Convert.ToInt32(pmonth);
            objEntityLeavSettlmt.Year = Convert.ToInt32(pyear);
        }
        else if (txtLstSettlddate.Text != "")
        {
            objEntityLeavSettlmt.SettlmtDate = objCommon.textToDateTime(txtLstSettlddate.Text);
        }

        if (hiddenBasicPay.Value != "")
        {
            objEntityLeavSettlmt.BasicPay = Convert.ToDecimal(hiddenBasicPay.Value);
        }
        else
        {
            objEntityLeavSettlmt.BasicPay = Convert.ToDecimal(lblBasicPay.Text);
        }

        if (hiddenAllownce.Value != "")
        {
            objEntityLeavSettlmt.Allowance = Convert.ToDecimal(hiddenAllownce.Value);
        }
        else
        {
            objEntityLeavSettlmt.Allowance = Convert.ToDecimal(lblAddition.Text);
        }

        if (hiddenDeductn.Value != "")
        {
            objEntityLeavSettlmt.Deduction = Convert.ToDecimal(hiddenDeductn.Value);
        }
        else
        {
            objEntityLeavSettlmt.Deduction = Convert.ToDecimal(lblDeduction.Text);
        }

        if (hiddenTotalPay.Value != "")
        {
            objEntityLeavSettlmt.TotalPay = Convert.ToDecimal(hiddenTotalPay.Value);
        }
        else
        {
            objEntityLeavSettlmt.TotalPay = Convert.ToDecimal(lblTotalPay.Text);
        }
        if (hiddenSalaryPerDay.Value != "")
        {
            objEntityLeavSettlmt.SalaryPerDay = Convert.ToDecimal(hiddenSalaryPerDay.Value);
        }
        else
        {
            objEntityLeavSettlmt.SalaryPerDay = Convert.ToDecimal(lblSalaryPerDay.Text);
        }


        if (Request.Form[txtLevSalary.UniqueID] != "")
        {
            objEntityLeavSettlmt.LeaveSalary = Convert.ToDecimal(Request.Form[txtLevSalary.UniqueID]);
        }

        //if (txtLevSalary.Text != "") hiddenSettldDate
        //{
        //    objEntityLeavSettlmt.LeaveSalary = Convert.ToDecimal(txtLevSalary.Text);
        //}
        if (hiddenPrvsmnt.Value != "")
        {
            objEntityLeavSettlmt.PrevMnthSalary = Convert.ToDecimal(hiddenPrvsmnt.Value);
        }
        else
        {
            if (txtPrevMonthSalary.Text != "")
            {
                objEntityLeavSettlmt.PrevMnthSalary = Convert.ToDecimal(txtPrevMonthSalary.Text);
            }
        }

        if (Request.Form[txtCurntMnthSalary.UniqueID] != "")
        {
            objEntityLeavSettlmt.CurrentMnthSalary = Convert.ToDecimal(Request.Form[txtCurntMnthSalary.UniqueID]);
        }

        //if (txtCurntMnthSalary.Text != "")
        //{
        //    objEntityLeavSettlmt.CurrentMnthSalary = Convert.ToDecimal(txtCurntMnthSalary.Text);
        //}
        if (txtTicktAmt.Text != "")
        {
            objEntityLeavSettlmt.TicktAmt = Convert.ToDecimal(txtTicktAmt.Text);
        }
        //if (txtOtherAmt.Text != "")
        //{
        //    objEntityLeavSettlmt.OtherAmt = Convert.ToDecimal(txtOtherAmt.Text);
        //}
        //if (txtOtherDeductn.Text != "")
        //{
        //    objEntityLeavSettlmt.OtherDeductionAmt = Convert.ToDecimal(txtOtherDeductn.Text);
        //}


        //if (hiddenOtherAdditionAmt.Value != "")
        //{
        //    objEntityLeavSettlmt.OtherAmt = Convert.ToDecimal(hiddenOtherAdditionAmt.Value);
        //}

        //if (hiddenOtherDeductionAmt.Value != "")
        //{
        //    objEntityLeavSettlmt.OtherDeductionAmt = Convert.ToDecimal(hiddenOtherDeductionAmt.Value);
        //}

        if (Page.Request.Form[txtOtherAmt.UniqueID].ToString() != "")
        {
            objEntityLeavSettlmt.OtherAmt = Convert.ToDecimal(Page.Request.Form[txtOtherAmt.UniqueID].ToString());
        }

        if (Page.Request.Form[txtOtherDeductn.UniqueID].ToString() != "")
        {
            objEntityLeavSettlmt.OtherDeductionAmt = Convert.ToDecimal(Page.Request.Form[txtOtherDeductn.UniqueID].ToString());
        }

        if (hiddenNetAmt.Value != "")
        {
            objEntityLeavSettlmt.NetAmount = Convert.ToDecimal(hiddenNetAmt.Value);
        }
        else
        {
            objEntityLeavSettlmt.NetAmount = Convert.ToDecimal(txtNetAmt.Text);
        }

        if (hiddenOvertm.Value != "")
        {
            objEntityLeavSettlmt.Overtm = Convert.ToDecimal(hiddenOvertm.Value);
        }
        else
        {
            if (lblOvertm.Text != "")
            {
                objEntityLeavSettlmt.Overtm = Convert.ToDecimal(lblOvertm.Text);
            }
        }

        if (hiddenDeductnMstr.Value != "")
        {
            objEntityLeavSettlmt.PaymntDeductn = Convert.ToDecimal(hiddenDeductnMstr.Value);
        }
        else
        {
            if (lblInstlmnt.Text != "")
            {
                objEntityLeavSettlmt.PaymntDeductn = Convert.ToDecimal(lblInstlmnt.Text);
            }
        }
        if (hiddenMessAmount.Value != "")
        {
            objEntityLeavSettlmt.DedctnMess = Convert.ToDecimal(hiddenMessAmount.Value);
        }
        else
        {
            if (MessDedctn.Text != "")
            {
                objEntityLeavSettlmt.DedctnMess = Convert.ToDecimal(MessDedctn.Text);
            }
        }




        objEntityLeavSettlmt.Date = objCommon.textToDateTime(strCurrDateServer);
        if (HiddenLeaveId.Value != "")
        {
            objEntityLeavSettlmt.LeaveId = Convert.ToInt32(HiddenLeaveId.Value);
        }
        if (cbxFA.Checked == true)
        {
            objEntityLeavSettlmt.FixedAllowance = 1;
        }
        else
        {
            objEntityLeavSettlmt.FixedAllowance = 0;
        }
        if (typResident.Checked)
        {
            objEntityLeavSettlmt.Mode = 0;

        }
        else if (typeNonResident.Checked)
        {
            objEntityLeavSettlmt.Mode = 1;
            objEntityLeavSettlmt.SettlmtDate = objCommon.textToDateTime(txtdate.Value);

            if (txtdate.Value != "")
            {
                objEntityLeavSettlmt.DateSettle = objCommon.textToDateTime(txtdate.Value);
            }
        }
        if (HiddenFieldFromDate.Value != "")
        {
            objEntityLeavSettlmt.FromDate = objCommon.textToDateTime(HiddenFieldFromDate.Value);
        }
        if (HiddenFieldToDate.Value != "")
        {
            objEntityLeavSettlmt.ToDate = objCommon.textToDateTime(HiddenFieldToDate.Value);
        }
        List<clsEntityLayerEmpSalary> objEntityAdditionList = new List<clsEntityLayerEmpSalary>();
        List<clsEntityLayerEmpSalary> objEntityDeductionList = new List<clsEntityLayerEmpSalary>();
        if (HiddenFieldChangeSts.Value == "1")
        {
            if (HiddenFieldAddDtls.Value != "" && HiddenFieldAddDtls.Value != null && HiddenFieldAddDtls.Value != "null")
            {
                string[] values = HiddenFieldAddDtls.Value.Split('%');
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i] != "")
                    {
                        string[] EachLeave = values[i].Split('-');
                        clsEntityLayerEmpSalary objSubEntityLeavSettlmt = new clsEntityLayerEmpSalary();
                        objSubEntityLeavSettlmt.AlownceId = Convert.ToInt32(EachLeave[0]);
                        objSubEntityLeavSettlmt.SalaryAllwnceId = Convert.ToInt32(EachLeave[1]);
                        objSubEntityLeavSettlmt.AmountRangeFrm = Convert.ToDecimal(EachLeave[2]);
                        objSubEntityLeavSettlmt.AmountRangeTo = Convert.ToDecimal(EachLeave[3]);
                        objSubEntityLeavSettlmt.AmountRangeTo = Convert.ToDecimal(objSubEntityLeavSettlmt.AmountRangeTo.ToString("0.00"));
                        objSubEntityLeavSettlmt.AdditnStatus = Convert.ToInt32(EachLeave[4]);
                        objEntityAdditionList.Add(objSubEntityLeavSettlmt);
                    }
                }
            }
            if (HiddenFieldDedDtls.Value != "" && HiddenFieldDedDtls.Value != null && HiddenFieldDedDtls.Value != "null")
            {
                string[] values = HiddenFieldDedDtls.Value.Split('%');
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i] != "")
                    {
                        string[] EachLeave = values[i].Split('-');
                        clsEntityLayerEmpSalary objSubEntityLeavSettlmt = new clsEntityLayerEmpSalary();
                        objSubEntityLeavSettlmt.AlownceId = Convert.ToInt32(EachLeave[0]);
                        objSubEntityLeavSettlmt.SalaryAllwnceId = Convert.ToInt32(EachLeave[1]);
                        objSubEntityLeavSettlmt.AmountRangeFrm = Convert.ToDecimal(EachLeave[2]);
                        objSubEntityLeavSettlmt.Percentge = Convert.ToDecimal(EachLeave[3]);
                        objSubEntityLeavSettlmt.PercOrAmountChk = Convert.ToInt32(EachLeave[4]);
                        objSubEntityLeavSettlmt.BasicOrTotalAmtChk = Convert.ToInt32(EachLeave[5]);
                        objSubEntityLeavSettlmt.AmountRangeTo = Convert.ToDecimal(EachLeave[6]);
                        objSubEntityLeavSettlmt.AmountRangeTo = Convert.ToDecimal(objSubEntityLeavSettlmt.AmountRangeTo.ToString("0.00"));
                        objSubEntityLeavSettlmt.AdditnStatus = Convert.ToInt32(EachLeave[7]);
                        objEntityDeductionList.Add(objSubEntityLeavSettlmt);
                    }
                }
            }
        }


        //Update to GN_USER_LEAVE_TYPES
        if (HiddenNoLeaveDeduct.Value != "")
        {
            string[] values = HiddenNoLeaveDeduct.Value.Split(',');
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] != "")
                {
                    string[] EachLeave = values[i].Split('-');
                    clsEntityLayerLeaveSettlmt objSubEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
                    if (hiddenEmpId.Value != "")
                    {
                        objSubEntityLeavSettlmt.EmployeeId = Convert.ToInt32(hiddenEmpId.Value);
                    }
                    objSubEntityLeavSettlmt.LeaveTypeId = Convert.ToInt32(EachLeave[0]);
                    objSubEntityLeavSettlmt.Year = Convert.ToInt32(EachLeave[1]);
                    objSubEntityLeavSettlmt.BalanceLeave = Convert.ToDecimal(EachLeave[2]);
                    objEntityLeaveTypSettlmt.Add(objSubEntityLeavSettlmt);
                }
            }
        }


        Session["EDIT"] = null;
        Session["VIEW"] = null;
        Session["READ"] = null;

        if (clickedButton.ID == "btnSave")
        {
            objBusinessLeavSettlmt.InsertEmployeeDtls(objEntityLeavSettlmt, objEntityAdditionList, objEntityDeductionList);
            Session["SUCCESS"] = "SAVE";
            Response.Redirect("hcm_Leave_Settlement.aspx");
        }
        else if (clickedButton.ID == "btnSaveClose")
        {
            objBusinessLeavSettlmt.InsertEmployeeDtls(objEntityLeavSettlmt, objEntityAdditionList, objEntityDeductionList);
            Session["SUCCESS"] = "SAVE";
            Response.Redirect("hcm_Leave_Settlement_List.aspx");
        }
        else if (clickedButton.ID == "btnUpdate")
        {
            if (HiddenFieldChangeSts.Value == "1")
            {
                objEntityLeavSettlmt.CancelStatus = 1;
            }
            objEntityLeavSettlmt.ConfrmStatus = 0;
            objEntityLeavSettlmt.LeaveSettlmtId = Convert.ToInt32(hiddenEdit.Value);
            objBusinessLeavSettlmt.UpdateEmployeeDtls(objEntityLeavSettlmt, objEntityLeaveTypSettlmt, objEntityAdditionList, objEntityDeductionList);
            Session["SUCCESS"] = "UPDATE";
        }
        else if (clickedButton.ID == "btnUpdateClose")
        {
            if (HiddenFieldChangeSts.Value == "1")
            {
                objEntityLeavSettlmt.CancelStatus = 1;
            }
            objEntityLeavSettlmt.ConfrmStatus = 0;
            objEntityLeavSettlmt.LeaveSettlmtId = Convert.ToInt32(hiddenEdit.Value);
            objBusinessLeavSettlmt.UpdateEmployeeDtls(objEntityLeavSettlmt, objEntityLeaveTypSettlmt, objEntityAdditionList, objEntityDeductionList);
            Session["SUCCESS"] = "UPDATE";
            Response.Redirect("hcm_Leave_Settlement_List.aspx");
        }
        else if (clickedButton.ID == "btnConfrmDeflt")
        {
            if (typResident.Checked)
            {
                objEntityLeavSettlmt.Mode = 0;
            }
            else if (typeNonResident.Checked)
            {
                objEntityLeavSettlmt.Mode = 1;
                if (txtdate.Value != "")
                {
                    objEntityLeavSettlmt.SettlmtDate = objCommon.textToDateTime(txtdate.Value);
                    objEntityLeavSettlmt.DateSettle = objCommon.textToDateTime(txtdate.Value);
                }
            }
            if (HiddenFieldChangeSts.Value == "1")
            {
                objEntityLeavSettlmt.CancelStatus = 1;
            }
            objEntityLeavSettlmt.ConfrmStatus = 1;
            objEntityLeavSettlmt.LeaveSettlmtId = Convert.ToInt32(hiddenEdit.Value);
            Session["SUCCESS"] = "CONFIRM";
            objBusinessLeavSettlmt.UpdateEmployeeDtls(objEntityLeavSettlmt, objEntityLeaveTypSettlmt, objEntityAdditionList, objEntityDeductionList);


            DataTable dtTickt = objBusinessLeavSettlmt.ReadEmpLeav(objEntityLeavSettlmt);
            if (dtTickt.Rows.Count > 0)
            {
                for (int intRowCount = 0; intRowCount < dtTickt.Rows.Count; intRowCount++)
                {
                    if (dtTickt.Rows[intRowCount]["LEAVE_ID"].ToString() != "")
                    {
                        objEntityLeavSettlmt.LeaveTypId = Convert.ToInt32(dtTickt.Rows[intRowCount]["LEAVE_ID"].ToString());
                    }
                    objBusinessLeavSettlmt.UpdateLeaveSettld(objEntityLeavSettlmt);
                }
            }


            txtRemarks.Enabled = false;
            txtLevSalary.Enabled = false;
            txtPrevMonthSalary.Enabled = false;
            txtCurntMnthSalary.Enabled = false;
            txtTicktAmt.Enabled = false;
            txtOtherAmt.Enabled = false;
            txtOtherDeductn.Enabled = false;
            btnUpdate.Visible = false;
            btnUpdateClose.Visible = false;
            btnConfirm.Visible = false;
            lblHeader.InnerText = "View Leave Settlement";
            hiddenView.Value = hiddenEdit.Value;
            typResident.Disabled = true;
            typeNonResident.Disabled = true;
            btnProcess.Visible = false;
        }
    }

    public void Update(string strId)
    {
        string IndividualRound = HiddenFieldIndividualRound.Value;
        clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
        clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        cls_Business_Monthly_Salary_Process objBuss2 = new cls_Business_Monthly_Salary_Process();
        cls_Entity_Monthly_Salary_Process objEnt2 = new cls_Entity_Monthly_Salary_Process();

        decimal decOtherAddtionAmount = 0;
        decimal decOtherDeductionAmount = 0;

        string strHtmlOtherAdd = "";
        string strHtmlOtherDed = "";

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLeavSettlmt.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityLeavSettlmt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (strId != "")
        {
            objEntityLeavSettlmt.LeaveSettlmtId = Convert.ToInt32(strId);

            hiddenEdit.Value = strId;
        }


        DataTable dtLeavSettl = objBusinessLeavSettlmt.ReadLeaveSettlmt_ById(objEntityLeavSettlmt);

        if (dtLeavSettl.Rows.Count > 0)
        {
            if (dtLeavSettl.Rows[0]["ALLOCATION_LEAVE_TO_DATE"].ToString() != "")
            {
                DateTime dtLastLeaveCurr = objCommon.textToDateTime(dtLeavSettl.Rows[0]["ALLOCATION_LEAVE_TO_DATE"].ToString());
                string pmonth = dtLastLeaveCurr.Month.ToString("00");
                string pyear = dtLastLeaveCurr.Year.ToString();
                objEnt2.Month = Convert.ToInt32(pmonth);
                objEnt2.Year = Convert.ToInt32(pyear);

                objEnt2.Employee = Convert.ToInt32(dtLeavSettl.Rows[0]["USR_ID"].ToString());
                objEnt2.CorpOffice = objEntityLeavSettlmt.CorpId;
                objEnt2.Orgid = objEntityLeavSettlmt.OrgId;

                if (dtLeavSettl.Rows[0]["LEVSETLMT_CONFRMSTS"].ToString() == "1")
                {
                    objEnt2.SavConf = 1;
                }

                DataTable dtOther_Addition = objBuss2.ReadEmpManualy_AdditionDetails(objEnt2);
                DataTable dtOther_Deduction = objBuss2.ReadEmpManualy_DeductionsDetails(objEnt2);

                if (dtOther_Addition.Rows.Count > 0)
                {
                    for (int intRow = 0; intRow < dtOther_Addition.Rows.Count; intRow++)
                    {
                        decOtherAddtionAmount += Convert.ToDecimal(dtOther_Addition.Rows[intRow]["OTHER_ADDITION"].ToString());

                        string strOthrAddAmt = Convert.ToString(Convert.ToDecimal(dtOther_Addition.Rows[intRow]["OTHER_ADDITION"]).ToString("0.00"));
                        if (strHtmlOtherAdd == "")
                        {
                            strHtmlOtherAdd += dtOther_Addition.Rows[intRow]["PAYRL_CODE"].ToString() + " : " + strOthrAddAmt;
                        }
                        else
                        {
                            strHtmlOtherAdd += ", " + dtOther_Addition.Rows[intRow]["PAYRL_CODE"].ToString() + " : " + strOthrAddAmt;
                        }
                    }
                    HiddenFieldOtherAddDtls.Value = strHtmlOtherAdd;
                }

                if (dtOther_Deduction.Rows.Count > 0)
                {
                    for (int intRow = 0; intRow < dtOther_Deduction.Rows.Count; intRow++)
                    {
                        decOtherDeductionAmount += Convert.ToDecimal(dtOther_Deduction.Rows[intRow]["OTHER_DEDUCTION"].ToString());

                        string strOthrDeductAmt = Convert.ToString(Convert.ToDecimal(dtOther_Deduction.Rows[intRow]["OTHER_DEDUCTION"]).ToString("0.00"));
                        if (strHtmlOtherDed == "")
                        {
                            strHtmlOtherDed += dtOther_Deduction.Rows[intRow]["PAYRL_CODE"].ToString() + " : " + strOthrDeductAmt;
                        }
                        else
                        {
                            strHtmlOtherDed += ", " + dtOther_Deduction.Rows[intRow]["PAYRL_CODE"].ToString() + " : " + strOthrDeductAmt;
                        }
                    }
                    HiddenFieldOtherDeductDtls.Value = strHtmlOtherDed;
                }
            }
            lblPrevMnthArrAmt.Text = dtLeavSettl.Rows[0]["LEVSETLMT_PREVR_ARR_MNT"].ToString();
            HiddenFieldPrevArrAmt.Value = dtLeavSettl.Rows[0]["LEVSETLMT_PREVR_ARR_MNT"].ToString();

            if (Convert.ToDecimal(HiddenFieldPrevArrAmt.Value) >= 0)
            {
                lblArrearPrev.InnerText = "Arrear Amount Addition";
            }
            else
            {
                lblArrearPrev.InnerText = "Arrear Amount Deduction";
                lblPrevMnthArrAmt.Text = (Convert.ToDecimal(HiddenFieldPrevArrAmt.Value) * -1).ToString();
            }




            HiddenFieldPrevMntRejoinDate.Value = dtLeavSettl.Rows[0]["LEVSETLMT_PREV_REJOIN_DATE"].ToString();


            HiddenNoLeaveDeduct.Value = dtLeavSettl.Rows[0]["LEVSETLMT_DEDUCT_DAYS"].ToString();

            ddlEmployee.Enabled = false;

            if (ddlEmployee.Items.FindByValue(dtLeavSettl.Rows[0]["USR_ID"].ToString()) != null)
            {
                ddlEmployee.Items.FindByValue(dtLeavSettl.Rows[0]["USR_ID"].ToString()).Selected = true;
            }
            else
            {

                System.Web.UI.WebControls.ListItem lstGrp = new System.Web.UI.WebControls.ListItem(dtLeavSettl.Rows[0]["USR_NAME"].ToString(), dtLeavSettl.Rows[0]["USR_ID"].ToString());
                ddlEmployee.Items.Insert(0, lstGrp);
                ddlEmployee.Items.FindByValue(dtLeavSettl.Rows[0]["USR_ID"].ToString()).Selected = true;
            }

            //Start:-Previous salary 
            HiddenFieldPrevAddition.Value = dtLeavSettl.Rows[0]["LEVSETLMT_PREV_ADDITION"].ToString();
            HiddenFieldPrevOvertimeAmt.Value = dtLeavSettl.Rows[0]["LEVSETLMT_PREV_OVERTIME_AMNT"].ToString();
            HiddenFieldPrevArrearAmt.Value = dtLeavSettl.Rows[0]["LEVSETLMT_PREV_ARREAR_AMNT"].ToString();
            HiddenFieldPrevDeduction.Value = dtLeavSettl.Rows[0]["LEVSETLMT_PREV_DEDUCTION"].ToString();
            HiddenFieldPrevPaymntAmt.Value = dtLeavSettl.Rows[0]["LEVSETLMT_PREV_PAYMENT_DEDUCT"].ToString();
            HiddenFieldPrevMessAmt.Value = dtLeavSettl.Rows[0]["LEVSETLMT_PREV_MESS_DEDUCT"].ToString();

            HiddenFieldPrevOtherAddAmt.Value = dtLeavSettl.Rows[0]["LEVSETLMT_PREV_OTHERAMT"].ToString();
            HiddenFieldPrevOtherDeductAmt.Value = dtLeavSettl.Rows[0]["LEVSETLMT_PREV_OTHERDEDCTN"].ToString();

            HiddenFieldFromDate.Value = dtLeavSettl.Rows[0]["LEVSETLMT_FROM_DATE"].ToString();
            HiddenFieldToDate.Value = dtLeavSettl.Rows[0]["LEVSETLMT_TO_DATE"].ToString();


            decimal PrevMessAmount = Convert.ToDecimal(HiddenFieldPrevMessAmt.Value);

            decimal PrevArrearAmount = Convert.ToDecimal(HiddenFieldPrevArrearAmt.Value);
            decimal PrevAllowance = Convert.ToDecimal(HiddenFieldPrevAddition.Value);
            decimal PrevOvertimeAmnt = Convert.ToDecimal(HiddenFieldPrevOvertimeAmt.Value);
            decimal PrevDeductn = Convert.ToDecimal(HiddenFieldPrevDeduction.Value);
            decimal PrevInstallment = Convert.ToDecimal(HiddenFieldPrevPaymntAmt.Value);

            decimal PrevOtherAdditionAmt = Convert.ToDecimal(HiddenFieldPrevOtherAddAmt.Value);
            decimal PrevOtherDeductionAmt = Convert.ToDecimal(HiddenFieldPrevOtherDeductAmt.Value);

            decimal PrevSal = Convert.ToDecimal(dtLeavSettl.Rows[0]["LEVSETLMT_PRVMNTH_SAL"].ToString());
            //  decimal PrevBasicSalary = PrevSal - PrevArrearAmount - PrevAllowance - PrevOvertimeAmnt + PrevDeductn + PrevInstallment;
            decimal PrevBasicSalary = PrevSal - PrevArrearAmount - PrevAllowance - PrevOvertimeAmnt + PrevDeductn + PrevInstallment - PrevOtherAdditionAmt + PrevOtherDeductionAmt + PrevMessAmount;
            int decmlcnt = Convert.ToInt32(dtLeavSettl.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
            string strHtml = "";
            if (PrevSal > 0)
            {
                if (IndividualRound == "1")
                {
                    PrevArrearAmount = Math.Round(PrevArrearAmount, 0);
                    PrevAllowance = Math.Round(PrevAllowance, 0);
                    PrevOvertimeAmnt = Math.Round(PrevOvertimeAmnt, 0);
                    PrevDeductn = Math.Round(PrevDeductn, 0);
                    PrevInstallment = Math.Round(PrevInstallment, 0);
                    PrevOtherAdditionAmt = Math.Round(PrevOtherAdditionAmt, 0);
                    PrevOtherDeductionAmt = Math.Round(PrevOtherDeductionAmt, 0);
                    PrevBasicSalary = Math.Round(PrevBasicSalary, 0);
                    PrevMessAmount = Math.Round(PrevMessAmount, 0);
                }

                clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                clsEntityCommon objEntityCommon = new clsEntityCommon();
                objEntityCommon.CurrencyId = Convert.ToInt32(dtLeavSettl.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
                strHtml = "Basic Pay:" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(PrevBasicSalary, decmlcnt).ToString(), objEntityCommon);
                strHtml += "\nArrear Amount:" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(PrevArrearAmount, decmlcnt).ToString(), objEntityCommon);
                strHtml += "\nAddition:" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(PrevAllowance, decmlcnt).ToString(), objEntityCommon);
                strHtml += "\nOvertime Addition:" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(PrevOvertimeAmnt, decmlcnt).ToString(), objEntityCommon);
                strHtml += "\nDeduction:" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(PrevDeductn, decmlcnt).ToString(), objEntityCommon);
                strHtml += "\nPayment Deduction:" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(PrevInstallment, decmlcnt).ToString(), objEntityCommon);
                strHtml += "\nOther Addition:" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(PrevOtherAdditionAmt, decmlcnt).ToString(), objEntityCommon);
                strHtml += "\nOther Deduction:" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(PrevOtherDeductionAmt, decmlcnt).ToString(), objEntityCommon);
                strHtml += "\nMess Deduction:" + objBusinessLayer.AddCommasForNumberSeperation(Math.Round(PrevMessAmount, decmlcnt).ToString(), objEntityCommon);
                HiddenFieldPrevSalaryDtls.Value = strHtml;
            }
            //End:-Previous salary

            lblLeavArrearAmnt.Text = dtLeavSettl.Rows[0]["LEVSETLMT_LV_ARREAR_AMNT"].ToString();
            HiddenFieldLeavArrearAmnt.Value = dtLeavSettl.Rows[0]["LEVSETLMT_LV_ARREAR_AMNT"].ToString();


          //  lblEligibleSettlmtOpen.Text = dtLeavSettl.Rows[0]["LEVSETLMT_OPEN_ELIGBLE_DAYS"].ToString();
            lblOpenLeaveSal.Text = dtLeavSettl.Rows[0]["LEVSETLMT_OPEN_LEAVE_SALARY"].ToString();


            //lblEligibleSettlmt
            
            lblEligibleSettlmtOpen.Text = dtLeavSettl.Rows[0]["LEVSETLMT_OPEN_ELIGBLE_DAYS"].ToString();
            HiddenFieldOpenLeaveDays.Value = dtLeavSettl.Rows[0]["LEVSETLMT_OPEN_ELIGBLE_DAYS"].ToString();
            decimal decTotalEligibleDays = Convert.ToDecimal(dtLeavSettl.Rows[0]["LEVSETLMT_OPEN_ELIGBLE_DAYS"]) + Convert.ToDecimal(dtLeavSettl.Rows[0]["LEVSETLMT_SETTLMTDAYS"]);
            // lblEligibleSettlmt.Text = dtLeavSettl.Rows[0]["LEVSETLMT_SETTLMTDAYS"].ToString();
            lblEligibleSettlmt.Text = Math.Round(Convert.ToDecimal(decTotalEligibleDays.ToString()), 0).ToString();
            

            HiddenFieldOpenLeaveDays.Value = dtLeavSettl.Rows[0]["LEVSETLMT_OPEN_ELIGBLE_DAYS"].ToString();
            HiddenFieldOpenLeaveSalary.Value = dtLeavSettl.Rows[0]["LEVSETLMT_OPEN_LEAVE_SALARY"].ToString();


            lblRejoinDate.Text = dtLeavSettl.Rows[0]["LEVSETLMT_REJOINDATE"].ToString();
           // lblEligibleSettlmt.Text = dtLeavSettl.Rows[0]["LEVSETLMT_SETTLMTDAYS"].ToString();
            hiddenSettlmtDays.Value = dtLeavSettl.Rows[0]["LEVSETLMT_SETTLMTDAYS"].ToString();

            txtRemarks.Text = dtLeavSettl.Rows[0]["LEVSETLMT_COMMNT"].ToString();
            lblBasicPay.Text = dtLeavSettl.Rows[0]["LEVSETLMT_BASIC_PAY"].ToString();

            lblAddition.Text = dtLeavSettl.Rows[0]["LEVSETLMT_ADDITN_AMT"].ToString();
            lblDeduction.Text = dtLeavSettl.Rows[0]["LEVSETLMT_DEDUCTN_AMT"].ToString();
            lblTotalPay.Text = dtLeavSettl.Rows[0]["LEVSETLMT_TOTAL_PAY"].ToString();
            lblSalaryPerDay.Text = dtLeavSettl.Rows[0]["LEVSETLMT_SAL_PERDAY"].ToString();
            txtLevSalary.Text = dtLeavSettl.Rows[0]["LEVSETLMT_LEVSALARY"].ToString();
            txtLstSettlddate.Text = dtLeavSettl.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString();

            //decimal PrevMonthSal = PrevSal + PrevOtherAdditionAmt - PrevOtherDeductionAmt;
            //txtPrevMonthSalary.Text = PrevMonthSal.ToString();
            //hiddenPrvsmnt.Value = PrevMonthSal.ToString();
            txtPrevMonthSalary.Text = dtLeavSettl.Rows[0]["LEVSETLMT_PRVMNTH_SAL"].ToString();
            hiddenPrvsmnt.Value = dtLeavSettl.Rows[0]["LEVSETLMT_PRVMNTH_SAL"].ToString();

            txtCurntMnthSalary.Text = dtLeavSettl.Rows[0]["LEVSETLMT_CRNTMNTH_SAL"].ToString();
            txtTicktAmt.Text = dtLeavSettl.Rows[0]["LEVSETLMT_TICKTAMT"].ToString();
            txtOtherAmt.Text = dtLeavSettl.Rows[0]["LEVSETLMT_OTHERAMT"].ToString();
            txtOtherDeductn.Text = dtLeavSettl.Rows[0]["LEVSETLMT_OTHERDEDCTN"].ToString();
            txtNetAmt.Text = dtLeavSettl.Rows[0]["LEVSETLMT_NETAMT"].ToString();
            lblOvertm.Text = dtLeavSettl.Rows[0]["LEVSETLMT_OVERTM_ADDTN"].ToString();
            lblInstlmnt.Text = dtLeavSettl.Rows[0]["LEVSETLMT_PYMT_DEDUCTN"].ToString();
            MessDedctn.Text = dtLeavSettl.Rows[0]["LEVSETLMT_MESS_DEDN"].ToString();


            if (IndividualRound == "1")
            {
                lblLeavArrearAmnt.Text = Math.Round(Convert.ToDecimal(dtLeavSettl.Rows[0]["LEVSETLMT_LV_ARREAR_AMNT"].ToString()), 0).ToString();
                // lblOpenLeaveSal.Text = Math.Round(Convert.ToDecimal(dtLeavSettl.Rows[0]["LEVSETLMT_OPEN_LEAVE_SALARY"].ToString()), 0).ToString();
                lblOpenLeaveSal.Text = dtLeavSettl.Rows[0]["LEVSETLMT_OPEN_LEAVE_SALARY"].ToString();

                lblAddition.Text = Math.Round(Convert.ToDecimal(dtLeavSettl.Rows[0]["LEVSETLMT_ADDITN_AMT"].ToString()), 0).ToString();
                lblDeduction.Text = Math.Round(Convert.ToDecimal(dtLeavSettl.Rows[0]["LEVSETLMT_DEDUCTN_AMT"].ToString()), 0).ToString();
                //  txtLevSalary.Text = Math.Round(Convert.ToDecimal(dtLeavSettl.Rows[0]["LEVSETLMT_LEVSALARY"].ToString()), 0).ToString();
                txtLevSalary.Text = dtLeavSettl.Rows[0]["LEVSETLMT_LEVSALARY"].ToString();

                txtPrevMonthSalary.Text = Math.Round(Convert.ToDecimal(dtLeavSettl.Rows[0]["LEVSETLMT_PRVMNTH_SAL"].ToString()), 0).ToString();
                //   txtCurntMnthSalary.Text = Math.Round(Convert.ToDecimal(dtLeavSettl.Rows[0]["LEVSETLMT_CRNTMNTH_SAL"].ToString()), 0).ToString(); 
                txtTicktAmt.Text = Math.Round(Convert.ToDecimal(dtLeavSettl.Rows[0]["LEVSETLMT_TICKTAMT"].ToString()), 0).ToString();
                txtOtherAmt.Text = Math.Round(Convert.ToDecimal(dtLeavSettl.Rows[0]["LEVSETLMT_OTHERAMT"].ToString()), 0).ToString();
                txtOtherDeductn.Text = Math.Round(Convert.ToDecimal(dtLeavSettl.Rows[0]["LEVSETLMT_OTHERDEDCTN"].ToString()), 0).ToString();
                txtNetAmt.Text = Math.Round(Convert.ToDecimal(dtLeavSettl.Rows[0]["LEVSETLMT_NETAMT"].ToString()), 0).ToString();
                lblOvertm.Text = Math.Round(Convert.ToDecimal(dtLeavSettl.Rows[0]["LEVSETLMT_OVERTM_ADDTN"].ToString()), 0).ToString();
                lblInstlmnt.Text = Math.Round(Convert.ToDecimal(dtLeavSettl.Rows[0]["LEVSETLMT_PYMT_DEDUCTN"].ToString()), 0).ToString();
                MessDedctn.Text = Math.Round(Convert.ToDecimal(dtLeavSettl.Rows[0]["LEVSETLMT_MESS_DEDN"].ToString()), 0).ToString();
            }



            if (dtLeavSettl.Rows[0]["LEVSETLMT_MODE"].ToString() == "0")
            {
                typResident.Checked = true;
                HiddenSettlementMode.Value = "0";
                HiddenLeaveId.Value = dtLeavSettl.Rows[0]["LEAVE_ID"].ToString();
                DivDate.Attributes["style"] = "padding-left: 3.4%;display:none; ";

            }
            else if (dtLeavSettl.Rows[0]["LEVSETLMT_MODE"].ToString() == "1")
            {
                typeNonResident.Checked = true;
                HiddenSettlementMode.Value = "1";

                if (dtLeavSettl.Rows[0]["LEVSETLMT_DATE_SETTLE"].ToString() != "")
                {
                    DivDate.Attributes["style"] = "padding-left: 3.4%;";
                    txtdate.Value = dtLeavSettl.Rows[0]["LEVSETLMT_DATE_SETTLE"].ToString();
                }
            }
            if (dtLeavSettl.Rows[0]["LEVSETLMT_FIXED_ALOWNC_STS"].ToString() == "1")
            {
                DivFixedAllowance.Attributes["style"] = "width: 50%; float: left;";
                cbxFA.Checked = true;
            }
            else
            {
                DivFixedAllowance.Attributes["style"] = "width: 50%;display:none; float: left;";
            }

            DataTable dtConfrm = objBusinessLeavSettlmt.ReadConfrmStatus(objEntityLeavSettlmt);
            if (dtConfrm.Rows[0]["LEVSETLMT_CONFRMSTS"].ToString() == "1" || dtConfrm.Rows[0]["LEVSETLMT_CONFRMSTS"].ToString() == "2" || dtConfrm.Rows[0]["LEVSETLMT_CONFRMSTS"].ToString() == "3" || hiddenView.Value != "")
            {
                txtRemarks.Enabled = false;
                typeNonResident.Disabled = true;
                typResident.Disabled = true;
                txtLevSalary.Enabled = false;
                txtPrevMonthSalary.Enabled = false;
                txtCurntMnthSalary.Enabled = false;
                txtTicktAmt.Enabled = false;
                txtOtherAmt.Enabled = false;
                txtOtherDeductn.Enabled = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnConfirm.Visible = false;
                btnCancel.Visible = true;
                btnProcess.Visible = false;
                btnSave.Visible = false;
                btnSaveClose.Visible = false;
                btnClear.Visible = false;
                hiddenView.Value = strId;
            }



            string aa = dtConfrm.Rows[0]["LEVSETLMT_CONFRMSTS"].ToString();


            if (dtConfrm.Rows[0]["LEVSETLMT_CONFRMSTS"].ToString() == "0" || dtConfrm.Rows[0]["LEVSETLMT_CONFRMSTS"].ToString() == "1" || dtConfrm.Rows[0]["LEVSETLMT_CONFRMSTS"].ToString() == "2" || dtConfrm.Rows[0]["LEVSETLMT_CONFRMSTS"].ToString() == "3")
            {
                divprint.Visible = true;
                if (dtLeavSettl.Rows[0]["LEVSETLMT_MODE"].ToString() == "0" && dtLeavSettl.Rows[0]["STAFF_WORKER"].ToString() == "1")
                {
                    divPrintPayslip.Visible = true;
                }
            }

            if (Request.QueryString["READ"] != null)
            {
                btnCancel.Visible = false;
                btnProcess.Visible = false;
                divList.Visible = false;
            }

            DataTable dtCorp = objBusinessLeavSettlmt.ReadCorporateAddress(objEntityLeavSettlmt);

            string strPrintReport = ConvertDataTableForPrint(dtLeavSettl, dtCorp);
            divPrintReport.InnerHtml = strPrintReport;


        }


        Session["EDIT"] = null;
        Session["VIEW"] = null;
        Session["READ"] = null;
    }

    [WebMethod]
    public static string TicktReqrd(string strEmpId, int intCorpId, int intOrgId)
    {

        clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
        clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();

        string TicktReq = "0";

        objEntityLeavSettlmt.CorpId = intCorpId;
        objEntityLeavSettlmt.OrgId = intOrgId;
        if (strEmpId != "--SELECT EMPLOYEE--" && strEmpId != "")
        {
            objEntityLeavSettlmt.EmployeeId = Convert.ToInt32(strEmpId);
        }

        DataTable dtTickt = objBusinessLeavSettlmt.ReadEmpLeav(objEntityLeavSettlmt);
        if (dtTickt.Rows.Count > 0)
        {
            if (dtTickt.Rows[0]["LEAVE_NEED_TRVL_TCKT"].ToString() != "")
            {
                TicktReq = dtTickt.Rows[0]["LEAVE_NEED_TRVL_TCKT"].ToString();
            }
        }
        return TicktReq;

    }


    public string ConvertDataTableForPrint(DataTable dt, DataTable dtCorp)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();

        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Leave Settlement";
        DateTime datetm = objCommon.textToDateTime(strCurrDateServer);
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
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
        string strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        string strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strCaptionTabTitle + strCaptionTabstop;

        sbCap.Append(strPrintCaptionTable);
        //write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\">";

        strHtml += "<tbody>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >1</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Employee</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["USR_NAME"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >2</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >REF#</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["EMPERDTL_EMPLOYEE_ID"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >3</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Eligible settlement days</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["LEVSETLMT_SETTLMTDAYS"].ToString() + "</td>";
        strHtml += "</tr>";


        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >4</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Open Eligible settlement days</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["LEVSETLMT_OPEN_ELIGBLE_DAYS"].ToString() + "</td>";
        strHtml += "</tr>";




        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >5</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Resume date</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["LEVSETLMT_REJOINDATE"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >6</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Last settled date</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >7</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Basic pay</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["LEVSETLMT_BASIC_PAY"].ToString() + "  " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >8</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Addition</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["LEVSETLMT_ADDITN_AMT"].ToString() + "  " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >9</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Deduction</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["LEVSETLMT_DEDUCTN_AMT"].ToString() + "  " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >10</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Total pay</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["LEVSETLMT_TOTAL_PAY"].ToString() + "  " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >11</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Salary per day</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["LEVSETLMT_SAL_PERDAY"].ToString() + "  " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >12</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Overtime Addition</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["LEVSETLMT_OVERTM_ADDTN"].ToString() + "  " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >13</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Payment Deduction</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["LEVSETLMT_PYMT_DEDUCTN"].ToString() + "  " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >14</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Mess Deduction</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["LEVSETLMT_MESS_DEDN"].ToString() + "  " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >15</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Leave salary</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["LEVSETLMT_LEVSALARY"].ToString() + "  " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >16</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Open Leave salary</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["LEVSETLMT_OPEN_LEAVE_SALARY"].ToString() + "  " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >17</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Leave Arrear Amount</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["LEVSETLMT_LV_ARREAR_AMNT"].ToString() + "  " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >18</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Previous month salary</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["LEVSETLMT_PRVMNTH_SAL"].ToString() + "  " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >19</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Current month salary</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["LEVSETLMT_CRNTMNTH_SAL"].ToString() + "  " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >20</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Ticket amount</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["LEVSETLMT_TICKTAMT"].ToString() + "  " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >21</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Other amount</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["LEVSETLMT_OTHERAMT"].ToString() + "  " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >22</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Other deduction</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["LEVSETLMT_OTHERDEDCTN"].ToString() + "  " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >23</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Net amount</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["LEVSETLMT_NETAMT"].ToString() + "  " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "</tbody>";

        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    [System.Web.Services.WebMethod]
    public static string GenerateReport(string strCorpID, string strOrgIdID, string strId, string LastSeetldHiddenDate, string IndividualRound)
    {
        clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
        clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityLeavSettlmt.CorpId = Convert.ToInt32(strCorpID);
        objEntityLeavSettlmt.OrgId = Convert.ToInt32(strOrgIdID);
        DataTable dtCorp = objBusinessLeavSettlmt.ReadCorporateAddress(objEntityLeavSettlmt);
        if (strId != "")
        {
            objEntityLeavSettlmt.LeaveSettlmtId = Convert.ToInt32(strId);
        }
        DataTable dt = objBusinessLeavSettlmt.ReadLeaveSettlmt_ById(objEntityLeavSettlmt);

        //GET DATA   usr_id
        clsCommonLibrary objCommon = new clsCommonLibrary();

        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "", strCompanyLogo = ""; ;


        string strTitle = "";
        strTitle = "Leave Settlement";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        if (dtCorp.Rows.Count > 0)
        {
            strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
            strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
            strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
            strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
            strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
            strCompanyLogo = dtCorp.Rows[0]["CORPRT_ICON"].ToString();
        }
        if (strCompanyLogo != "")
        {
            strCompanyLogo = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit) + strCompanyLogo;
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
        string strCurrentDate = objBusiness.LoadCurrentDateInString();
        DateTime dtCurrDate = objCommon.textToDateTime(strCurrentDate);

        string strDeduction_amount = (Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_MESS_DEDN"].ToString().Replace(",", "")) + Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_DEDUCTN_AMT"].ToString().Replace(",", ""))).ToString();


        DateTime dtEndDate = DateTime.MinValue;
        DateTime dtPreviousMonthDate = DateTime.MinValue;

        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString() != "")
            {
                dtEndDate = objCommon.textToDateTime(dt.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString());
            }
            else
            {
                DateTime dtLastHiddenDate = DateTime.MinValue;
                if (LastSeetldHiddenDate != "")
                {
                    dtLastHiddenDate = objCommon.textToDateTime(LastSeetldHiddenDate.ToString());
                }

                string strEmpId = dt.Rows[0]["USR_ID"].ToString();
                objEntityLeavSettlmt.EmployeeId = Convert.ToInt32(strEmpId);
                DataTable dtLeavSettld = objBusinessLeavSettlmt.ReadLastSettldDt(objEntityLeavSettlmt);
                DateTime dtLastSettle = new DateTime();
                DateTime dtLastMonth = new DateTime();
                string dtDate = "";
                if (dtLeavSettld.Rows.Count > 0 && dtLeavSettld.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString() != "")
                {
                    dtLastSettle = objCommon.textToDateTime(dtLeavSettld.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString());
                }
                DataTable dtLeavMonth = objBusinessLeavSettlmt.ReadMonthlyLastDate(objEntityLeavSettlmt);
                if (dtLeavMonth.Rows.Count > 0 && dtLeavMonth.Rows[0]["SLPRCDMNTH_LST_SETTLD_DT"].ToString() != "")
                {
                    dtLastMonth = objCommon.textToDateTime(dtLeavMonth.Rows[0]["SLPRCDMNTH_LST_SETTLD_DT"].ToString());
                }
                if (dtLastSettle != DateTime.MinValue || dtLastMonth != DateTime.MinValue)
                {
                    if (dtLastSettle > dtLastMonth)
                    {
                        dtDate = Convert.ToString(dtLastSettle.ToString("dd-MM-yyyy")); ;
                    }
                    else
                    {
                        dtDate = Convert.ToString(dtLastMonth.ToString("dd-MM-yyyy"));
                    }
                }
                if (dtDate != "")
                {
                    dtEndDate = objCommon.textToDateTime(dtDate);

                    if (LastSeetldHiddenDate != "")
                    {
                        if (dtLastHiddenDate > dtEndDate)
                        {
                            dtEndDate = dtLastHiddenDate;
                        }
                    }
                }
                else if (dtLastHiddenDate != DateTime.MinValue)
                {
                    if (LastSeetldHiddenDate != "")
                    {
                        if (dtLastHiddenDate > dtEndDate)
                        {
                            dtEndDate = dtLastHiddenDate;
                        }
                    }
                }
            }
            if (dtEndDate != DateTime.MinValue)
            {
                dtPreviousMonthDate = dtEndDate.AddMonths(-1);
            }
        }
        //GET DATA ENDS
        objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
        // string strcurrenWord = dt.Rows[0]["CRNCMST_ABBRV"].ToString() + " - " + objBusiness.ConvertCurrencyToWords(objEntityCommon, dt.Rows[0]["LEVSETLMT_NETAMT"].ToString().Replace(",", ""));

        string strLeaveFromDate = "", strLeaveToDate = "", strMode = dt.Rows[0]["LEVSETLMT_MODE"].ToString();
        if (strMode == "0")
        {
            if (dt.Rows[0]["LEAVE_FROM_DATE"].ToString() != "")
            {
                strLeaveFromDate = dt.Rows[0]["LEAVE_FROM_DATE"].ToString();
                strLeaveToDate = dt.Rows[0]["LEAVE_TO_DATE"].ToString();
            }
            else
            {
                strLeaveFromDate = dt.Rows[0]["LEAVE_FROM_DATE_AL"].ToString();
                strLeaveToDate = dt.Rows[0]["LEAVE_TO_DATE_AL"].ToString();
            }
        }
        string format = String.Format("{{0:N{0}}}", Convert.ToInt32(dt.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString()));
        int roundNum = 0;
        if (IndividualRound == "0")
        {
            roundNum = Convert.ToInt32(dt.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }


        // Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);
        Document document = new Document(PageSize.LETTER, 50f, 30f, 19f, 20f);
        Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
        {
            objEntityCommon.CorporateID = Convert.ToInt32(strCorpID);
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.LEAVE_SETTLEMENT);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);

            int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.LEAVE_SETTLEMENT_PDF);
            string strImageName = "LS" + strId + strNextId + ".pdf";
            string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.END_OF_SERVICE_PDF);

            System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(strImagePath));

            FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
            PdfWriter writer = PdfWriter.GetInstance(document, file);
            writer.PageEvent = new PDFHeader();
            document.Open();


            PdfPTable headtable = new PdfPTable(2);



            headtable.AddCell(new PdfPCell(new Phrase("LEAVE SETTLEMENT", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

            if (strCompanyLogo != "")
            {
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strCompanyLogo));
                image.ScalePercent(PdfPCell.ALIGN_CENTER);
                image.ScaleToFit(60f, 40f);
                headtable.AddCell(new PdfPCell(image) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

            }
            else
            {
                headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            }


            headtable.AddCell(new PdfPCell(new Phrase(strCompanyName, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

            ///sub head
            headtable.AddCell(new PdfPCell(new Phrase(strAddress, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            //headtable.AddCell(new PdfPCell(new Phrase("DATE : " + dtCurrDate.ToString("dd/MM/yyyy"), new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

            float[] headersHeading = { 80, 20 };  //Header Widths
            headtable.SetWidths(headersHeading);        //Set the pdf headers
            headtable.WidthPercentage = 100;       //Set the PDF File witdh percentage
            document.Add(headtable);

            PdfPTable tableLine = new PdfPTable(1);
            float[] tableLineBody = { 100 };
            tableLine.SetWidths(tableLineBody);
            tableLine.WidthPercentage = 100;
            tableLine.TotalWidth = 650F;

            PdfPCell cell_headLine = (new PdfPCell(new Phrase("______________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, });
            cell_headLine.Padding = -5;
            tableLine.AddCell(cell_headLine);

            // tableLine.AddCell(new PdfPCell(new Phrase("_____________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
            tableLine.WriteSelectedRows(0, -1, 0, document.PageSize.GetTop(59), writer.DirectContent);


            //contents


            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Tahoma,Arial", 10, Font.NORMAL, BaseColor.BLACK))));
            //   document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Tahoma,Arial", 10, Font.NORMAL, BaseColor.BLACK))));



            PdfPTable pdfBodyTable = new PdfPTable(6);

            float[] headersPdfBodyTable = { 20, 16, 16, 16, 16, 16 };  //Header Widths
            pdfBodyTable.SetWidths(headersPdfBodyTable);        //Set the pdf headers
            pdfBodyTable.WidthPercentage = 100;       //Set the PDF File witdh percentage
            document.Add(pdfBodyTable);

            pdfBodyTable = new PdfPTable(4);



            pdfBodyTable.AddCell(new PdfPCell(new Phrase("EMPLOYEE CODE", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyTable.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["USR_CODE"].ToString(), new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyTable.AddCell(new PdfPCell(new Phrase("DATE OF JOIN", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyTable.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["USR_JOIN_DATE"].ToString(), new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //Row 2

            pdfBodyTable.AddCell(new PdfPCell(new Phrase("EMPLOYEE NAME", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            if (dt.Rows[0]["USR_NAME"].ToString().Contains('-'))
            {
                pdfBodyTable.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["USR_NAME"].ToString().Split('-')[1], new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 3, BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            }
            else
            {
                pdfBodyTable.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["USR_NAME"].ToString(), new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 3, BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            }
            //Row 3
            string strRejoinDate = "";
            if (dt.Rows[0]["USR_JOIN_DATE"].ToString() != dt.Rows[0]["LEVSETLMT_REJOINDATE"].ToString())
            {
                strRejoinDate = dt.Rows[0]["LEVSETLMT_REJOINDATE"].ToString();
            }

            pdfBodyTable.AddCell(new PdfPCell(new Phrase("BASIC SALARY", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyTable.AddCell(new PdfPCell(new Phrase(String.Format(format, Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_BASIC_PAY"].ToString())), new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyTable.AddCell(new PdfPCell(new Phrase("LAST RESUME DATE", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyTable.AddCell(new PdfPCell(new Phrase(strRejoinDate, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //Row 4

            pdfBodyTable.AddCell(new PdfPCell(new Phrase("LEAVE START DATE", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyTable.AddCell(new PdfPCell(new Phrase(strLeaveFromDate, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyTable.AddCell(new PdfPCell(new Phrase("LEAVE END DATE", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyTable.AddCell(new PdfPCell(new Phrase(strLeaveToDate, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //Row 5
            pdfBodyTable.AddCell(new PdfPCell(new Phrase("REMARKS, IF ANY", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyTable.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["LEVSETLMT_COMMNT"].ToString(), new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 3, BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });


            float[] headersPdfBodyTable2 = { 25, 25, 25, 25 };  //Header Widths
            pdfBodyTable.SetWidths(headersPdfBodyTable2);        //Set the pdf headers
            pdfBodyTable.WidthPercentage = 100;       //Set the PDF File witdh percentage
            document.Add(pdfBodyTable);


            //2nd table

            PdfPTable pdfBodyDetailTable = new PdfPTable(3);

            string curBasicsal = "";
            if (strMode == "0")
            {
                curBasicsal = String.Format(format, Convert.ToDecimal(dt.Rows[0]["BASIC_CURR"].ToString()));
                if (IndividualRound == "1")
                {
                    curBasicsal = String.Format(format, Math.Round(Convert.ToDecimal(dt.Rows[0]["BASIC_CURR"].ToString()), 0));
                }
            }
            else
            {
                curBasicsal = String.Format(format, 0);
            }

            string AdditionalAmnt = String.Format(format, Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_ADDITN_AMT"].ToString()), roundNum);
            if (IndividualRound == "1")
            {
                AdditionalAmnt = String.Format(format, Math.Round(Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_ADDITN_AMT"].ToString())), roundNum);
            }

            string OverTimeAmnt = String.Format(format, Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_OVERTM_ADDTN"].ToString()), roundNum);
            if (IndividualRound == "1")
            {
                OverTimeAmnt = String.Format(format, Math.Round(Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_OVERTM_ADDTN"].ToString())), roundNum);
            }

            string DeductnAmnt = String.Format(format, Convert.ToDecimal(strDeduction_amount), roundNum);
            if (IndividualRound == "1")
            {
                DeductnAmnt = String.Format(format, Math.Round(Convert.ToDecimal(strDeduction_amount)), roundNum);
            }

            string PymntDeductnAmnt = String.Format(format, Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_PYMT_DEDUCTN"].ToString()), roundNum);
            if (IndividualRound == "1")
            {
                PymntDeductnAmnt = String.Format(format, Math.Round(Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_PYMT_DEDUCTN"].ToString())), roundNum);
            }

            string CrntMnthSalAmnt = String.Format(format, Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_CRNTMNTH_SAL"].ToString()), roundNum);
            if (IndividualRound == "1")
            {
                CrntMnthSalAmnt = String.Format(format, Math.Round(Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_CRNTMNTH_SAL"].ToString())), roundNum);
            }

            string PrvsMnthSettlmntAmnt = String.Format(format, Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_PRVMNTH_SAL"].ToString()), roundNum);
            if (IndividualRound == "1")
            {
                PrvsMnthSettlmntAmnt = String.Format(format, Math.Round(Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_PRVMNTH_SAL"].ToString())), roundNum);
            }

            string OtherAmnt = String.Format(format, Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_OTHERAMT"].ToString()), roundNum);
            if (IndividualRound == "1")
            {
                OtherAmnt = String.Format(format, Math.Round(Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_OTHERAMT"].ToString())), roundNum);
            }

            string TicktAmnt = String.Format(format, Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_TICKTAMT"].ToString()), roundNum);
            if (IndividualRound == "1")
            {
                TicktAmnt = String.Format(format, Math.Round(Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_TICKTAMT"].ToString())), roundNum);
            }
            string OtherDeductnAmnt = String.Format(format, Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_OTHERDEDCTN"].ToString()), roundNum);
            if (IndividualRound == "1")
            {
                OtherDeductnAmnt = String.Format(format, Math.Round(Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_OTHERDEDCTN"].ToString())), roundNum);
            }

            string ArrearAmnt = String.Format(format, Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_LV_ARREAR_AMNT"].ToString()), roundNum);
            if (IndividualRound == "1")
            {
                ArrearAmnt = String.Format(format, Math.Round(Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_LV_ARREAR_AMNT"].ToString())), roundNum);
            }


            string PRevArrearAmnt = String.Format(format, Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_PREVR_ARR_MNT"].ToString()), roundNum);
            if (IndividualRound == "1")
            {
                PRevArrearAmnt = String.Format(format, Math.Round(Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_PREVR_ARR_MNT"].ToString())), roundNum);
            }


            //string NetAmnt = String.Format(format, Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_NETAMT"].ToString()), roundNum);
            //if (IndividualRound == "1")
            //{
            //    NetAmnt = String.Format(format, Math.Round(Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_NETAMT"].ToString())), roundNum);
            //}

            //Row 6
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("SALARY FOR " + dtEndDate.ToString("MMMM").ToUpper() + " " + dtEndDate.Year, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Rowspan = 6, BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("BASIC SALARY (+)", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(curBasicsal, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //Row 7
            // pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("ADDITION AMOUNT (+)", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(AdditionalAmnt, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });


            //Row 8
            // pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("OVERTIME AMOUNT (+)", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(OverTimeAmnt, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //Row 9
            // pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("DEDUCTION AMOUNT (-)", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(DeductnAmnt, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //Row 10
            // pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("PAYMENT DEDUCTION (-)", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(PymntDeductnAmnt, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });


            //Row 11
            //   pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("A. SALARY FOR " + dtEndDate.ToString("MMMM").ToUpper() + " " + dtEndDate.Year, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(CrntMnthSalAmnt, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });



            decimal decTotalLeavDays = 0, decTotalLeavSalary = 0;
            decTotalLeavDays = Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_SETTLMTDAYS"].ToString()) + Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_OPEN_ELIGBLE_DAYS"].ToString());
            //decTotalLeavSalary = Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_LEVSALARY"].ToString()) + Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_OPEN_LEAVE_SALARY"].ToString());
            decimal BasicSalry = Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_BASIC_PAY"].ToString());
            //decTotalLeavSalary = (BasicSalry / 30) * Math.Round(decTotalLeavDays);

            string TotalLeavDays = String.Format(format, Math.Round(decTotalLeavDays), roundNum);

            //string TotalLeavDays = String.Format(format, decTotalLeavDays, roundNum);
            //if (IndividualRound == "1")
            //{
            //    TotalLeavDays = String.Format(format, Math.Round(decTotalLeavDays), roundNum);
            //}
            if (dt.Rows[0]["LEVSETLMT_LEVSALARY"].ToString() != "")
            {
                decTotalLeavSalary = Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_LEVSALARY"].ToString());
            }
            string TotalLeavSalary = String.Format(format, decTotalLeavSalary, roundNum);
            //if (IndividualRound == "1")
            //{
            TotalLeavSalary = String.Format(format, Math.Round(decTotalLeavSalary), roundNum);
            //}

            //Row 12
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("LEAVE SALARY CALCULATION", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Rowspan = 2, BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("TOTAL ELIGIBLE DAYS", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            //  pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(strTotal_eligible_days, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_CENTER, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(TotalLeavDays, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_CENTER, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });


            //Row 13
            // pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("B. TOTAL LEAVE SALARY", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            //   pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(strTotal_leave_salary, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(TotalLeavSalary, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });


            //Row 16
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Colspan = 3, BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            //pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            //pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //Row 17
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("SETTLEMENT SUMMARY", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Rowspan = 9, BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("SALARY FOR " + dtEndDate.ToString("MMMM").ToUpper() + " " + dtEndDate.Year + " (+)", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(CrntMnthSalAmnt, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //Row 18
            //pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("SALARY FOR " + dtPreviousMonthDate.ToString("MMMM").ToUpper() + " " + dtPreviousMonthDate.Year + " (+)", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(PrvsMnthSettlmntAmnt, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //Row 19
            // pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("TOTAL LEAVE SALARY (+)", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            //pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(strTotal_leave_salary, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(TotalLeavSalary, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });


            //Row 21
            // pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("OTHER ADDITION, IF ANY (+)", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(OtherAmnt, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //Row 22
            // pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("TICKET AMOUNT, IF ANY (+)", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(TicktAmnt, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            if (Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_PREVR_ARR_MNT"].ToString()) >= 0)
            {

                pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("ARREAR AMOUNT (+)", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
                pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(PRevArrearAmnt, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            }
            else
            {
                pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("ARREAR AMOUNT (-)", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
                pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(PRevArrearAmnt.Replace("-", string.Empty), new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            }
            //Row 23
            // pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("OTHER DEDUCTION (-)", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(OtherDeductnAmnt, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //Row 24
            // pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("LEAVE ARREAR AMOUNT (-) ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(ArrearAmnt, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            decimal decNetAmnt = Convert.ToDecimal(CrntMnthSalAmnt) + Convert.ToDecimal(PrvsMnthSettlmntAmnt) + Convert.ToDecimal(TotalLeavSalary) + Convert.ToDecimal(OtherAmnt) + Convert.ToDecimal(TicktAmnt) + Convert.ToDecimal(PRevArrearAmnt) - Convert.ToDecimal(OtherDeductnAmnt) - Convert.ToDecimal(ArrearAmnt);

            string NetAmnt = String.Format(format, decNetAmnt, roundNum);
            if (IndividualRound == "1")
            {
                NetAmnt = String.Format(format, Math.Round(decNetAmnt), roundNum);
            }
            string strcurrenWord = objBusiness.ConvertCurrencyToWords(objEntityCommon, NetAmnt.Replace(",", ""));

            //Row 24
            //  pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("C. SETTLEMENT AMOUNT", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(NetAmnt, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //row 25
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(strcurrenWord, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Colspan = 3, BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });



            float[] headerspdfBodyDetailTable = { 32, 34, 34 };  //Header Widths
            pdfBodyDetailTable.SetWidths(headerspdfBodyDetailTable);        //Set the pdf headers
            pdfBodyDetailTable.WidthPercentage = 100;       //Set the PDF File witdh percentage
            document.Add(pdfBodyDetailTable);


            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Tahoma,Arial", 10, Font.NORMAL, BaseColor.BLACK))));
            //document.Add(new Paragraph(new Chunk("I hereby declare that I have received all dues from M/S " + strCompanyName + " and there is no outstanding as on date.", FontFactory.GetFont("Tahoma,Arial", 10, Font.NORMAL, BaseColor.BLACK))));


            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Tahoma,Arial", 10, Font.NORMAL, BaseColor.BLACK))));
            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Tahoma,Arial", 10, Font.NORMAL, BaseColor.BLACK))));
            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Tahoma,Arial", 10, Font.NORMAL, BaseColor.BLACK))));


            float pos1 = writer.GetVerticalPosition(false);


            PdfPTable pdfSignatureTable = new PdfPTable(3);
            //Row 1
            pdfSignatureTable.AddCell(new PdfPCell(new Phrase("______________________", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfSignatureTable.AddCell(new PdfPCell(new Phrase("______________________", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfSignatureTable.AddCell(new PdfPCell(new Phrase("______________________", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            pdfSignatureTable.AddCell(new PdfPCell(new Phrase("FINANCE MANAGER", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfSignatureTable.AddCell(new PdfPCell(new Phrase("GENERAL MANAGER", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfSignatureTable.AddCell(new PdfPCell(new Phrase("RECEIVER’S SIGNATURE", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            float[] headerspdfSignatureTable = { 32, 34, 34 };  //Header Widths
            pdfSignatureTable.SetWidths(headerspdfSignatureTable);        //Set the pdf headers
            pdfSignatureTable.WidthPercentage = 100;       //Set the PDF File witdh percentage
            //document.Add(pdfSignatureTable);
            pdfSignatureTable.TotalWidth = 640F;
            if (pos1 > 100)
            {
                pdfSignatureTable.WriteSelectedRows(0, -1, 0, 100, writer.DirectContent);
                //  table3.WriteSelectedRows(0, -1, 65, 120, writer.DirectContent);
            }
            else
            {
                document.NewPage();
                pdfSignatureTable.WriteSelectedRows(0, -1, 0, 100, writer.DirectContent);

                // table3.WriteSelectedRows(0, -1, 65, 120, writer.DirectContent);
            }

            document.Close();
            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();
            return strImagePath + strImageName;

        }
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            Generate_LabourCard_PDF();
        }
        catch (Exception ex)
        {

        }
    }
    public void Generate_LabourCard_PDF()
    {

        string IndividualRound = HiddenFieldIndividualRound.Value;
        int roundNum = 0;
        if (IndividualRound == "0")
        {
            roundNum = Convert.ToInt32(hiddenDecimalCount.Value);
        }


        clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
        clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLeavSettlmt.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityLeavSettlmt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (hiddenView.Value != "")
        {
            objEntityLeavSettlmt.LeaveSettlmtId = Convert.ToInt32(hiddenView.Value);
        }

        DataTable dtCorp = objBusinessLeavSettlmt.ReadCorporateAddress(objEntityLeavSettlmt);
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "", strCompanyLogo = "";
        string strTitle = "";
        //l1
        strTitle = "LABOR CARD";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        if (dtCorp.Rows.Count > 0)
        {
            strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
            strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
            strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
            strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
            strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
            strCompanyLogo = dtCorp.Rows[0]["CORPRT_ICON"].ToString();
        }
        if (strCompanyLogo != "")
        {
            strCompanyLogo = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit) + strCompanyLogo;
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

        DataTable dt = objBusinessLeavSettlmt.ReadLeaveSettlmt_ById(objEntityLeavSettlmt);
        if (dt.Rows.Count > 0)
        {
            DateTime dtLastLeaveCurr = DateTime.MinValue;
            string dtDate = "";

            DateTime dtLastHiddenDate = DateTime.MinValue;
            if (hiddenSettldDate.Value != "")
            {
                dtLastHiddenDate = objCommon.textToDateTime(hiddenSettldDate.Value.ToString());
            }

            if (dt.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString() != "")
            {
                dtLastLeaveCurr = objCommon.textToDateTime(dt.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString());
            }
            else
            {
                string strEmpId = dt.Rows[0]["USR_ID"].ToString();
                objEntityLeavSettlmt.EmployeeId = Convert.ToInt32(strEmpId);
                DataTable dtLeavSettld = objBusinessLeavSettlmt.ReadLastSettldDt(objEntityLeavSettlmt);
                DateTime dtLastSettle = new DateTime();
                DateTime dtLastMonth = new DateTime();


                DataTable dtEmpRejoin = objBusinessLeavSettlmt.ReadRejoin(objEntityLeavSettlmt);
                DataTable dtEmpjoin = objBusinessLeavSettlmt.ReadJoinDt(objEntityLeavSettlmt);
                DataTable dtEmpLev = objBusinessLeavSettlmt.ReadInsertDt(objEntityLeavSettlmt);

                if (dtEmpRejoin.Rows.Count > 0 && dtEmpRejoin.Rows[0]["DUTYREJOIN_DATE"].ToString() != "")
                {
                    dtDate = dtEmpRejoin.Rows[0]["DUTYREJOIN_DATE"].ToString();
                }
                else if (dtEmpjoin.Rows.Count > 0 && dtEmpjoin.Rows[0]["EMPERDTL_JOIN_DATE"].ToString() != "")
                {
                    dtDate = dtEmpjoin.Rows[0]["EMPERDTL_JOIN_DATE"].ToString();
                }
                else if (dtEmpLev.Rows.Count > 0 && dtEmpLev.Rows[0]["USR_INS_DATE"].ToString() != "")
                {
                    dtDate = dtEmpLev.Rows[0]["USR_INS_DATE"].ToString();
                }
                else if (dtEmpjoin.Rows.Count > 0 && dtEmpjoin.Rows[0]["USR_JOIN_DATE"].ToString() != "")
                {
                    dtDate = dtEmpjoin.Rows[0]["USR_JOIN_DATE"].ToString();
                }


                if (dtLeavSettld.Rows.Count > 0 && dtLeavSettld.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString() != "")
                {
                    dtLastSettle = objCommon.textToDateTime(dtLeavSettld.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString());
                }
                DataTable dtLeavMonth = objBusinessLeavSettlmt.ReadMonthlyLastDate(objEntityLeavSettlmt);
                if (dtLeavMonth.Rows.Count > 0 && dtLeavMonth.Rows[0]["SLPRCDMNTH_LST_SETTLD_DT"].ToString() != "")
                {
                    dtLastMonth = objCommon.textToDateTime(dtLeavMonth.Rows[0]["SLPRCDMNTH_LST_SETTLD_DT"].ToString());
                }
                if (dtLastSettle != DateTime.MinValue || dtLastMonth != DateTime.MinValue)
                {
                    if (dtLastSettle > dtLastMonth)
                    {
                        dtDate = Convert.ToString(dtLastSettle.ToString("dd-MM-yyyy")); ;
                    }
                    else
                    {
                        dtDate = Convert.ToString(dtLastMonth.ToString("dd-MM-yyyy"));
                    }
                }

                if (dtDate != "")
                {
                    dtLastLeaveCurr = objCommon.textToDateTime(dtDate);
                    if (hiddenSettldDate.Value != "")
                    {
                        if (dtLastHiddenDate > dtLastLeaveCurr)
                        {
                            dtLastLeaveCurr = dtLastHiddenDate;
                        }
                    }
                }
            }

            DateTime dtLastStl = new DateTime();
            DateTime dtFinal = new DateTime();
            cls_Business_Monthly_Salary_Process objBuss1 = new cls_Business_Monthly_Salary_Process();
            cls_Entity_Monthly_Salary_Process objEnt1 = new cls_Entity_Monthly_Salary_Process();
            objEnt1.Employee = Convert.ToInt32(dt.Rows[0]["USR_ID"].ToString());
            if (dt.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString() != "")
            {
                objEnt1.date = objCommon.textToDateTime(dt.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString());
            }
            else
            {
                if (dtDate != "")
                {
                    objEnt1.date = dtLastLeaveCurr;
                }
            }

            DataTable dtLeavMonth1 = objBuss1.ReadLastDatePrint(objEnt1);
            if (dtLeavMonth1.Rows.Count > 0)
            {
                if (dtLeavMonth1.Rows[0][0].ToString() != "")
                {
                    dtFinal = objCommon.textToDateTime(dtLeavMonth1.Rows[0][0].ToString());
                    dtFinal = dtFinal.AddDays(1);
                }
                if (dtLeavMonth1.Rows[1][0].ToString() != "")
                {
                    dtLastStl = objCommon.textToDateTime(dtLeavMonth1.Rows[1][0].ToString());
                    if (dtLastStl > dtFinal)
                    {
                        dtFinal = dtLastStl;
                    }
                }
            }
            DateTime dtFromDate2 = new DateTime();
            //Join or rejoin date
            string strStartDate = dt.Rows[0]["LEVSETLMT_REJOINDATE"].ToString();
            dtFromDate2 = objCommon.textToDateTime(strStartDate);
            if (dtFromDate2 > dtFinal && dtFromDate2 < dtLastLeaveCurr)
            {
                dtFinal = dtFromDate2;
            }

            //Corporate salary date
            DataTable dtCorpSal = objBusinessLeavSettlmt.ReadCorpSal(objEntityLeavSettlmt);
            DateTime dtCorpSalaryDate = objCommon.textToDateTime(dtCorpSal.Rows[0]["COPRT_SALARY_DATE"].ToString());
            if (dtCorpSalaryDate != DateTime.MinValue)
            {
                if (dtCorpSalaryDate > dtFinal && dtCorpSalaryDate < dtLastLeaveCurr)
                {
                    dtFinal = dtCorpSalaryDate;
                }
            }
            DateTime dtFromDate = dtFinal;

            objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            DateTime dtToDate = new DateTime();
            if (dt.Rows[0]["LEAVE_FROM_DATE"].ToString() != "")
            {
                dtToDate = objCommon.textToDateTime(dt.Rows[0]["LEAVE_FROM_DATE"].ToString());
            }
            else
            {
                dtToDate = objCommon.textToDateTime(dt.Rows[0]["LEAVE_FROM_DATE_AL"].ToString());
            }
            dtToDate = dtToDate.AddDays(-1);
            DateTime dtCurrFromDate = dtFromDate;
            DateTime dtPrevToDate = new DateTime();
            DateTime dtprevFromDate = new DateTime();

            int cursts = 0;
            int MonthDiff = (dtToDate.Year * 12 + dtToDate.Month) - (dtFromDate.Year * 12 + dtFromDate.Month);

            if (dtLastLeaveCurr.Day == 1)//previous mnth only present(1st day of mnth)
            {
                MonthDiff = 1;
                cursts = 1;
            }

            if (MonthDiff == 1)
            {
                if (dtLastLeaveCurr.Day == 1)//previous mnth only present(1st day of mnth)
                {
                    dtCurrFromDate = new DateTime(dtLastLeaveCurr.Year, dtLastLeaveCurr.Month, 1);
                    dtPrevToDate = dtCurrFromDate.AddDays(-1);
                    dtprevFromDate = new DateTime(dtPrevToDate.Year, dtPrevToDate.Month, 1);
                }
                else
                {
                    dtCurrFromDate = new DateTime(dtToDate.Year, dtToDate.Month, 1);
                    dtPrevToDate = dtCurrFromDate.AddDays(-1);
                    dtprevFromDate = new DateTime(dtPrevToDate.Year, dtPrevToDate.Month, 1);
                    if (dtprevFromDate < dtFromDate)
                    {
                        dtprevFromDate = dtFromDate;
                    }
                }
            }

            //strt level1
            //    Document document = new Document(PageSize.A4, 50f, 40f, 20f, 50f);
            Document document = new Document(PageSize.LETTER, 50f, 30f, 19f, 20f);

            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                string strImageName = "LaborCard_LS_" + hiddenView.Value + ".pdf";
                string imgpath = "/CustomFiles/PaySlip/";
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.PAYSLIP_PDF);


                string fullPath = System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName;
                if ((System.IO.File.Exists(fullPath)))
                {
                    System.IO.File.Delete(fullPath);
                }


                FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(imgpath) + strImageName, FileMode.Create);
                PdfWriter.GetInstance(document, file);

                writer.PageEvent = new PDFHeader();
                document.Open();


                if (cursts == 0)
                {
                    PdfPTable headtable = new PdfPTable(2);
                    //lbr -1
                    headtable.AddCell(new PdfPCell(new Phrase("LABOR CARD", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    if (strCompanyLogo != "")
                    {
                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strCompanyLogo));
                        image.ScalePercent(PdfPCell.ALIGN_CENTER);
                        image.ScaleToFit(60f, 40f);
                        headtable.AddCell(new PdfPCell(image) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    }
                    else
                    {
                        headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    }
                    headtable.AddCell(new PdfPCell(new Phrase(strCompanyName, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    headtable.AddCell(new PdfPCell(new Phrase(strAddress, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    float[] headersHeading = { 80, 20 };
                    headtable.SetWidths(headersHeading);
                    headtable.WidthPercentage = 100;
                    document.Add(headtable);

                    PdfPTable tableLine = new PdfPTable(1);
                    float[] tableLineBody = { 100 };
                    tableLine.SetWidths(tableLineBody);
                    tableLine.WidthPercentage = 100;
                    tableLine.TotalWidth = 650F;

                    PdfPCell cell_headLine = (new PdfPCell(new Phrase("______________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, });
                    cell_headLine.Padding = -5;
                    tableLine.AddCell(cell_headLine);

                    //tableLine.AddCell(new PdfPCell(new Phrase("______________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, });
                    tableLine.WriteSelectedRows(0, -1, 0, document.PageSize.GetTop(58), writer.DirectContent);



                    PdfPTable tableLayout = new PdfPTable(6);
                    float[] headersBody = { 19, 19, 14, 16, 16, 16 };
                    tableLayout.SetWidths(headersBody);
                    tableLayout.WidthPercentage = 100;
                    tableLayout.AddCell(new PdfPCell(new Phrase("DATE", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase("JOB#", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase("STATUS", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase("NORMAL HOURS", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase("NORMAL OT", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase("HOLIDAY OT", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });

                    int numMonth = dtToDate.Day;
                    int startMonth = dtCurrFromDate.Day;
                    string MonthName = "";

                    decimal NormlOT = 0, HoldayOt = 0;
                    decimal NormalOvertmRatePrHr = 0, HolidayOvertmRatePrHr = 0;

                    DateTime dtToday = objCommon.textToDateTime(hiddenDate.Value);
                    int CurrentMnth = dtToday.Month;

                    for (int intRowBodyCount = startMonth; intRowBodyCount <= numMonth; intRowBodyCount++)
                    {
                        string EmDate = new DateTime(dtCurrFromDate.Year, dtCurrFromDate.Month, intRowBodyCount).ToString("dd-MM-yyyy");
                        DateTime ddate = objCommon.textToDateTime(EmDate);

                        cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
                        cls_Entity_Monthly_Salary_Process objEntPrcss = new cls_Entity_Monthly_Salary_Process();
                        objEntPrcss.date = ddate;
                        MonthName = ddate.ToString("MMMM");
                        objEntPrcss.Employee = Convert.ToInt32(dt.Rows[0]["USR_ID"].ToString());
                        objEntPrcss.Month = dtCurrFromDate.Month;
                        objEntPrcss.Year = dtCurrFromDate.Year;
                        DataTable dtEmp_list = objBuss.ReadEmp_List_For_Print(objEntPrcss);
                        //date
                        tableLayout.AddCell(new PdfPCell(new Phrase(ddate.ToString("dd-MM-yyyy"), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                        if (dtEmp_list.Rows.Count > 0)
                        {
                            tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["JOBMSTR_TITLE"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                            tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["ATTENDANCE"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                            if (dtEmp_list.Rows[0]["ATTENDANCE"].ToString() == "P" || dtEmp_list.Rows[0]["ATTENDANCE"].ToString()=="p")
                            {
                                tableLayout.AddCell(new PdfPCell(new Phrase("8", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                            }
                            else if (dtEmp_list.Rows[0]["ATTENDANCE"].ToString() == "A" || dtEmp_list.Rows[0]["ATTENDANCE"].ToString() == "a")
                            {
                                tableLayout.AddCell(new PdfPCell(new Phrase("0", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                            }
                            else
                            {
                                tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });

                            }
                            foreach (DataRow row in dtEmp_list.Rows)
                            {
                                if (row["OVRTMCATG_NAME"].ToString() == "NORMAL OT")
                                {
                                    tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                    NormlOT += Convert.ToDecimal(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString());
                                    NormalOvertmRatePrHr = Convert.ToDecimal(row["OVRTMCATG_RATE"].ToString());
                                }
                                else
                                {
                                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                }
                                if (row["OVRTMCATG_NAME"].ToString() == "HOLIDAY OT")
                                {
                                    tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                    HoldayOt += Convert.ToDecimal(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString());
                                    HolidayOvertmRatePrHr = Convert.ToDecimal(row["OVRTMCATG_RATE"].ToString());
                                }
                                else
                                {
                                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                }
                            }
                        }
                        else
                        {
                            tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                            tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                            tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                            tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                            tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                        }
                    }
                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 4, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase(NormlOT.ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase(HoldayOt.ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 6, Padding = 2 });

                    PdfPTable pdfBodyTable = new PdfPTable(4);
                    pdfBodyTable.WidthPercentage = 100;
                    //  pdfBodyTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 4, Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 4, Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("EMPLOYEE CODE", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["USR_CODE"].ToString(), new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("DESIGNATION", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["DSGN_NAME"].ToString(), new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("MONTH & YEAR", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(MonthName.ToUpper() + " " + dtCurrFromDate.Year, new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 2, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("EMPLOYEE NAME", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    if (dt.Rows[0]["USR_NAME"].ToString().Contains('-'))
                    {
                        pdfBodyTable.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["USR_NAME"].ToString().Split('-')[1], new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 3, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    }
                    else
                    {
                        pdfBodyTable.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["USR_NAME"].ToString(), new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 3, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    }
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 4, Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    document.Add(pdfBodyTable);

                    document.Add(tableLayout);

                    string basicAmt = "", AllowaceAmt = "", AllowovertimeAmount = "", DedctionAmt = "", DedctionInstalmntAmnt = "", Total = "", OT_Hours = "", MessAmnt = "", LvArrearAmnt = "", CurrMonthBasic = "";
                    Decimal TotalBasicAllow = 0, TotalDedctn = 0, netsalary = 0, AllowovertimeAmount1 = 0, AllowaceAmt1 = 0, basicAmt1 = 0, instlmntDedctionAmt = 0, deductnamt = 0;
                    Decimal decMessAmnt = 0, decLvArrearAmnt = 0, decCurrMonthBasic = 0;
                    Decimal decPrevArrAmnt = 0;
                    basicAmt = dt.Rows[0]["LEVSETLMT_BASIC_PAY"].ToString();
                    CurrMonthBasic = dt.Rows[0]["BASIC_CURR"].ToString();
                    AllowaceAmt = dt.Rows[0]["LEVSETLMT_ADDITN_AMT"].ToString();
                    AllowovertimeAmount = dt.Rows[0]["LEVSETLMT_OVERTM_ADDTN"].ToString();
                    DedctionAmt = dt.Rows[0]["LEVSETLMT_DEDUCTN_AMT"].ToString();
                    DedctionInstalmntAmnt = dt.Rows[0]["LEVSETLMT_PYMT_DEDUCTN"].ToString();
                    MessAmnt = dt.Rows[0]["LEVSETLMT_MESS_DEDN"].ToString();
                    LvArrearAmnt = dt.Rows[0]["LEVSETLMT_LV_ARREAR_AMNT"].ToString();

                    Total = dt.Rows[0]["LEVSETLMT_CRNTMNTH_SAL"].ToString();

                    objEnt1.Orgid = objEntityLeavSettlmt.OrgId;
                    objEnt1.CorpOffice = objEntityLeavSettlmt.CorpId;
                    objEnt1.Month = dtCurrFromDate.Month;
                    objEnt1.Year = dtCurrFromDate.Year;

                    decPrevArrAmnt = Convert.ToDecimal(dt.Rows[0]["LEVSETLMT_PREVR_ARR_MNT"].ToString());


                    // objEnt1
                 //   DataTable dtOtherAddDedDetls = objBuss1.ReadEmpManualy_Add_Dedn_Dtls(objEnt1);
                    DataTable dtOtherAddDedDetls = objBuss1.ReadEmpManualy_Add_Dedn(objEnt1);
                    
                    decimal TotOthrAddAmt = 0, TotOthrDeductAmt = 0;
                    for (int i = 0; i < dtOtherAddDedDetls.Rows.Count; i++)
                    {
                        if (dtOtherAddDedDetls.Rows[i]["PAYRL_MODE"].ToString() == "1")
                        {
                            TotOthrAddAmt += Convert.ToDecimal(dtOtherAddDedDetls.Rows[i]["PAYINFDT_AMOUNT"].ToString());
                        }
                        else if (dtOtherAddDedDetls.Rows[i]["PAYRL_MODE"].ToString() == "2")
                        {
                            TotOthrDeductAmt += Convert.ToDecimal(dtOtherAddDedDetls.Rows[i]["PAYINFDT_AMOUNT"].ToString());
                        }
                    }


                    if (CurrMonthBasic != "")
                    {
                        decCurrMonthBasic = Convert.ToDecimal(CurrMonthBasic);
                    }
                    if (basicAmt != "")
                    {
                        basicAmt1 = Convert.ToDecimal(basicAmt);
                        TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(decCurrMonthBasic);
                    }
                    if (AllowaceAmt != "")
                    {
                        AllowaceAmt1 = Convert.ToDecimal(AllowaceAmt);
                        TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(AllowaceAmt);
                    }
                    if (AllowovertimeAmount != "")
                    {
                        AllowovertimeAmount1 = Convert.ToDecimal(AllowovertimeAmount);
                        TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(AllowovertimeAmount);
                    }
                    if (TotOthrAddAmt != 0)
                    {
                        TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(TotOthrAddAmt);
                    }
                    if (decPrevArrAmnt >= 0)
                    {
                        TotalBasicAllow = TotalBasicAllow + decPrevArrAmnt;
                    }
                    if (DedctionAmt != "")
                    {
                        deductnamt = Convert.ToDecimal(DedctionAmt);
                        TotalDedctn = TotalDedctn + Convert.ToDecimal(DedctionAmt);
                    }
                    if (DedctionInstalmntAmnt != "")
                    {
                        instlmntDedctionAmt = Convert.ToDecimal(DedctionInstalmntAmnt);
                        TotalDedctn = TotalDedctn + Convert.ToDecimal(DedctionInstalmntAmnt);
                    }
                    if (MessAmnt != "")
                    {
                        decMessAmnt = Convert.ToDecimal(MessAmnt);
                        TotalDedctn = TotalDedctn + Convert.ToDecimal(decMessAmnt);
                    }
                    if (LvArrearAmnt != "")
                    {
                        decLvArrearAmnt = Convert.ToDecimal(LvArrearAmnt);
                        TotalDedctn = TotalDedctn + Convert.ToDecimal(decLvArrearAmnt);
                    }
                    if (TotOthrDeductAmt != 0)
                    {
                        TotalDedctn = TotalDedctn + Convert.ToDecimal(TotOthrDeductAmt);
                    }
                    if (decPrevArrAmnt < 0)
                    {
                        TotalDedctn = TotalDedctn + (decPrevArrAmnt * -1);
                    }
                    if (Total != "")
                    {
                        netsalary = Convert.ToDecimal(Total);
                        netsalary = netsalary + TotOthrAddAmt - decLvArrearAmnt - TotOthrDeductAmt + decPrevArrAmnt;
                    }
                    string FinalNetAmt = Math.Round(netsalary, 0).ToString();
                    netsalary = Convert.ToDecimal(FinalNetAmt);


                    string strbasicAmt = objBusiness.AddCommasForNumberSeperation(basicAmt1.ToString("0.00"), objEntityCommon);
                    string strCurrbasicAmt = objBusiness.AddCommasForNumberSeperation(Math.Round(decCurrMonthBasic, roundNum).ToString("0.00"), objEntityCommon);

                    string strAllowaceAmt = objBusiness.AddCommasForNumberSeperation(Math.Round(AllowaceAmt1, roundNum).ToString("0.00"), objEntityCommon);
                    string strAllowovertimeAmount = objBusiness.AddCommasForNumberSeperation(Math.Round(AllowovertimeAmount1, roundNum).ToString("0.00"), objEntityCommon);
                    string strTotalBasicAllow = objBusiness.AddCommasForNumberSeperation(Math.Round(TotalBasicAllow, roundNum).ToString("0.00"), objEntityCommon);
                    string strDeductnAmt = objBusiness.AddCommasForNumberSeperation(Math.Round(deductnamt, roundNum).ToString("0.00"), objEntityCommon);
                    string strDeductnInstlmtAmount = objBusiness.AddCommasForNumberSeperation(Math.Round(instlmntDedctionAmt, roundNum).ToString("0.00"), objEntityCommon);
                    string strTotalDedctn = objBusiness.AddCommasForNumberSeperation(Math.Round(TotalDedctn, roundNum).ToString("0.00"), objEntityCommon);
                    string strnetsalary = objBusiness.AddCommasForNumberSeperation(netsalary.ToString("0.00"), objEntityCommon);
                    string strMessAmnt = objBusiness.AddCommasForNumberSeperation(Math.Round(decMessAmnt, roundNum).ToString("0.00"), objEntityCommon);
                    string strLvArrearAmnt = objBusiness.AddCommasForNumberSeperation(Math.Round(decLvArrearAmnt, roundNum).ToString("0.00"), objEntityCommon);
                    string strPrevArrAmt = objBusiness.AddCommasForNumberSeperation(Math.Round(decPrevArrAmnt, roundNum).ToString("0.00"), objEntityCommon);

                    int daysInm = DateTime.DaysInMonth(dtCurrFromDate.Year, dtCurrFromDate.Month);
                    decimal decPerHourSal = Convert.ToDecimal(basicAmt) / daysInm;
                    if (decPerHourSal > 0)
                    {
                        decPerHourSal = decPerHourSal / 8;
                    }


                    decimal NormalOTAmnt = NormlOT * NormalOvertmRatePrHr * decPerHourSal;
                    decimal HolidayOTAmnt = HoldayOt * HolidayOvertmRatePrHr * decPerHourSal;
                    string strNormalOTAmnt = objBusiness.AddCommasForNumberSeperation(Math.Round(NormalOTAmnt, roundNum).ToString("0.00"), objEntityCommon);
                    string strHolidayOTAmnt = objBusiness.AddCommasForNumberSeperation(Math.Round(HolidayOTAmnt, roundNum).ToString("0.00"), objEntityCommon);

                    int numCurrDays = (numMonth - startMonth) + 1;


                    decimal PerDaySalCurr = Convert.ToDecimal(basicAmt) / daysInm;
                    decimal workdays = decCurrMonthBasic / PerDaySalCurr;
                    workdays = Math.Round(workdays, 1);
                    if (workdays % 1 == 0)
                    {
                        workdays = Convert.ToInt32(workdays);
                    }



                    float pos2 = writer.GetVerticalPosition(false);

                    PdfPTable sumtable = new PdfPTable(6);
                    float[] footrsBody = { 14, 28, 16, 13, 15, 14 };
                    sumtable.SetWidths(footrsBody);
                    sumtable.WidthPercentage = 100;

                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Basic and Allowances", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = BaseColor.LIGHT_GRAY, Colspan = 4, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Description", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase("Days/Hrs", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Basic Pay", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(strbasicAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(workdays.ToString(), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(strCurrbasicAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    if (Convert.ToDecimal(strAllowaceAmt) != 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Special Allowance", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strAllowaceAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strAllowaceAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    }
                    if (NormlOT != 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Normal OT @" + NormalOvertmRatePrHr.ToString() + "/hr", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(NormlOT.ToString(), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strNormalOTAmnt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    }
                    if (HoldayOt != 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Holiday OT @" + HolidayOvertmRatePrHr.ToString() + "/hr", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(HoldayOt.ToString(), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strHolidayOTAmnt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    }
                    for (int i = 0; i < dtOtherAddDedDetls.Rows.Count; i++)
                    {
                        if (dtOtherAddDedDetls.Rows[i]["PAYRL_MODE"].ToString() == "1")
                        {
                            string strTotOthrAddAmt = objBusiness.AddCommasForNumberSeperation(Convert.ToDecimal(dtOtherAddDedDetls.Rows[i]["PAYINFDT_AMOUNT"]).ToString("0.00"), objEntityCommon);
                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            sumtable.AddCell(new PdfPCell(new Phrase(dtOtherAddDedDetls.Rows[i]["PAYRL_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(strTotOthrAddAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(strTotOthrAddAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        }
                    }


                    if (decPrevArrAmnt > 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Arrear Amount", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strPrevArrAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strPrevArrAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    }

                    //   sumtable.AddCell(cell);

                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Total Basic and Allowances", FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(strTotalBasicAllow, FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Deductions", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = BaseColor.LIGHT_GRAY, Colspan = 4, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Deduction Types", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BackgroundColor = BaseColor.LIGHT_GRAY, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = BaseColor.LIGHT_GRAY, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    if (Convert.ToDecimal(strDeductnAmt) != 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Special Deductions", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strDeductnAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    }
                    if (Convert.ToDecimal(strDeductnInstlmtAmount) != 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Installment Deductions", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strDeductnInstlmtAmount, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    }
                    if (Convert.ToDecimal(strMessAmnt) != 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Mess Deductions", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strMessAmnt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    }
                    if (Convert.ToDecimal(strLvArrearAmnt) != 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Leave Arrear Deductions", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strLvArrearAmnt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    }
                    if (decPrevArrAmnt < 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Arrear Amount", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strPrevArrAmt.Replace("-", string.Empty), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    }
                    for (int i = 0; i < dtOtherAddDedDetls.Rows.Count; i++)
                    {
                        if (dtOtherAddDedDetls.Rows[i]["PAYRL_MODE"].ToString() == "2")
                        {
                            string strTotOthrDeductAmt = objBusiness.AddCommasForNumberSeperation(Convert.ToDecimal(dtOtherAddDedDetls.Rows[i]["PAYINFDT_AMOUNT"]).ToString("0.00"), objEntityCommon);
                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            sumtable.AddCell(new PdfPCell(new Phrase(dtOtherAddDedDetls.Rows[i]["PAYRL_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(strTotOthrDeductAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        }
                    }
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Total Deductions", FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(strTotalDedctn, FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = BaseColor.LIGHT_GRAY, Colspan = 4, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Net Salary", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(strnetsalary + " " + dt.Rows[0]["CRNCMST_ABBRV"].ToString(), FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    if (pos2 > 200)
                    {
                    }
                    else
                    {
                        document.NewPage();
                    }
                    document.Add(sumtable);


                    float pos1 = writer.GetVerticalPosition(false);
                    PdfPTable endtable = new PdfPTable(6);
                    float[] endBody = { 25, 10, 25, 10, 25, 5 };
                    endtable.SetWidths(endBody);
                    endtable.WidthPercentage = 100;
                    endtable.TotalWidth = document.PageSize.Width - 80f;

                    endtable.AddCell(new PdfPCell(new Phrase("FINANCE MANAGER", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                    endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                    endtable.AddCell(new PdfPCell(new Phrase("GENERAL MANAGER", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                    endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                    endtable.AddCell(new PdfPCell(new Phrase("RECEIVER’S SIGNATURE", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                    endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });

                    endtable.TotalWidth = 555F;
                    if (pos1 > 70)
                    {
                        endtable.WriteSelectedRows(0, -1, 50, 65, writer.DirectContent);
                    }
                    else
                    {
                        document.NewPage();
                        endtable.WriteSelectedRows(0, -1, 50, 65, writer.DirectContent);
                    }
                }
                //Start:-Previous month
                if (MonthDiff == 1)
                {
                    document.NewPage();

                    PdfPTable headtable = new PdfPTable(2);
                    //lbr -2
                    headtable.AddCell(new PdfPCell(new Phrase("LABOR CARD", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    if (strCompanyLogo != "")
                    {
                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strCompanyLogo));
                        image.ScalePercent(PdfPCell.ALIGN_CENTER);
                        image.ScaleToFit(60f, 40f);
                        headtable.AddCell(new PdfPCell(image) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    }
                    else
                    {
                        headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    }
                    headtable.AddCell(new PdfPCell(new Phrase(strCompanyName, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    headtable.AddCell(new PdfPCell(new Phrase(strAddress, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    float[] headersHeading = { 80, 20 };
                    headtable.SetWidths(headersHeading);
                    headtable.WidthPercentage = 100;
                    document.Add(headtable);

                    PdfPTable tableLine = new PdfPTable(1);
                    float[] tableLineBody = { 100 };
                    tableLine.SetWidths(tableLineBody);
                    tableLine.WidthPercentage = 100;
                    tableLine.TotalWidth = 650F;

                    PdfPCell cell_headLine = (new PdfPCell(new Phrase("______________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, });
                    cell_headLine.Padding = -5;
                    tableLine.AddCell(cell_headLine);

                    //   tableLine.AddCell(new PdfPCell(new Phrase("_____________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    tableLine.WriteSelectedRows(0, -1, 0, document.PageSize.GetTop(58), writer.DirectContent);


                    float pos9 = writer.GetVerticalPosition(false);
                    PdfPTable tableLayout = new PdfPTable(6);
                    float[] headersBody = { 19, 19, 14, 16, 16, 16 };
                    tableLayout.SetWidths(headersBody);
                    tableLayout.WidthPercentage = 100;

                    tableLayout.AddCell(new PdfPCell(new Phrase("DATE", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase("JOB#", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase("STATUS", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase("NORMAL HOURS", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase("NORMAL OT", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase("HOLIDAY OT", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });

                    int numMonth = dtPrevToDate.Day;
                    int startMonth = dtprevFromDate.Day;
                    string MonthName = "";

                    decimal NormlOT = 0, HoldayOt = 0;
                    decimal NormalOvertmRatePrHr = 0, HolidayOvertmRatePrHr = 0;

                    for (int intRowBodyCount = startMonth; intRowBodyCount <= numMonth; intRowBodyCount++)
                    {
                        string EmDate = new DateTime(dtprevFromDate.Year, dtprevFromDate.Month, intRowBodyCount).ToString("dd-MM-yyyy");
                        DateTime ddate = objCommon.textToDateTime(EmDate);

                        cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
                        cls_Entity_Monthly_Salary_Process objEntPrcss = new cls_Entity_Monthly_Salary_Process();
                        objEntPrcss.date = ddate;
                        MonthName = ddate.ToString("MMMM");
                        objEntPrcss.Employee = Convert.ToInt32(dt.Rows[0]["USR_ID"].ToString());
                        objEntPrcss.Month = dtprevFromDate.Month;
                        objEntPrcss.Year = dtprevFromDate.Year;
                        DataTable dtEmp_list = objBuss.ReadEmp_List_For_Print(objEntPrcss);

                        tableLayout.AddCell(new PdfPCell(new Phrase(ddate.ToString("dd-MM-yyyy"), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                        if (dtEmp_list.Rows.Count > 0)
                        {
                            tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["JOBMSTR_TITLE"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                            tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["ATTENDANCE"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                            if (dtEmp_list.Rows[0]["ATTENDANCE"].ToString() == "P")
                            {
                                tableLayout.AddCell(new PdfPCell(new Phrase("8", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                            }
                            else if (dtEmp_list.Rows[0]["ATTENDANCE"].ToString() == "A")
                            {
                                tableLayout.AddCell(new PdfPCell(new Phrase("0", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                            }
                            foreach (DataRow row in dtEmp_list.Rows)
                            {
                                if (row["OVRTMCATG_NAME"].ToString() == "NORMAL OT")
                                {
                                    tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                    NormlOT += Convert.ToDecimal(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString());
                                    NormalOvertmRatePrHr = Convert.ToDecimal(row["OVRTMCATG_RATE"].ToString());
                                }
                                else
                                {
                                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                }
                                if (row["OVRTMCATG_NAME"].ToString() == "HOLIDAY OT")
                                {
                                    tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                    HoldayOt += Convert.ToDecimal(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString());
                                    HolidayOvertmRatePrHr = Convert.ToDecimal(row["OVRTMCATG_RATE"].ToString());
                                }
                                else
                                {
                                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                                }
                            }
                        }
                        else
                        {
                            tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                            tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                            tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                            tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                            tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                        }
                    }

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 4, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase(NormlOT.ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase(HoldayOt.ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 6, Padding = 2 });

                    PdfPTable pdfBodyTable = new PdfPTable(4);
                    pdfBodyTable.WidthPercentage = 100;

                    //  pdfBodyTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 4, Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 4, Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("EMPLOYEE CODE", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["USR_CODE"].ToString(), new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("DESIGNATION", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["DSGN_NAME"].ToString(), new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });


                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("MONTH & YEAR", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(MonthName.ToUpper() + " " + dtprevFromDate.Year, new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 2, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });


                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("EMPLOYEE NAME", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    if (dt.Rows[0]["USR_NAME"].ToString().Contains('-'))
                    {
                        pdfBodyTable.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["USR_NAME"].ToString().Split('-')[1], new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 3, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    }
                    else
                    {
                        pdfBodyTable.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["USR_NAME"].ToString(), new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 3, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    }
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 4, Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    if (pos9 > 150)
                    {
                    }
                    else
                    {
                        document.NewPage();
                    }
                    document.Add(pdfBodyTable);


                    float pos8 = writer.GetVerticalPosition(false);
                    if (pos8 > 150)
                    {
                    }
                    else
                    {
                        document.NewPage();
                    }
                    document.Add(tableLayout);

                    string basicAmt = "", AllowaceAmt = "", AllowovertimeAmount = "", DedctionAmt = "", DedctionInstalmntAmnt = "", Total = "", OT_Hours = "", MessAmnt = "", LvArrearAmnt = "", CurrMonthBasic = "";
                    Decimal TotalBasicAllow = 0, TotalDedctn = 0, netsalary = 0, AllowovertimeAmount1 = 0, AllowaceAmt1 = 0, basicAmt1 = 0, instlmntDedctionAmt = 0, deductnamt = 0;
                    Decimal decMessAmnt = 0, decLvArrearAmnt = 0, decCurrMonthBasic = 0;

                    basicAmt = dt.Rows[0]["LEVSETLMT_BASIC_PAY"].ToString();
                    CurrMonthBasic = dt.Rows[0]["BASIC_PREV"].ToString();

                    AllowaceAmt = dt.Rows[0]["LEVSETLMT_PREV_ADDITION"].ToString();
                    AllowovertimeAmount = dt.Rows[0]["LEVSETLMT_PREV_OVERTIME_AMNT"].ToString();

                    DedctionAmt = dt.Rows[0]["LEVSETLMT_PREV_DEDUCTION"].ToString();
                    DedctionInstalmntAmnt = dt.Rows[0]["LEVSETLMT_PREV_PAYMENT_DEDUCT"].ToString();
                    MessAmnt = dt.Rows[0]["LEVSETLMT_PREV_MESS_DEDUCT"].ToString();

                    Total = dt.Rows[0]["LEVSETLMT_PRVMNTH_SAL"].ToString();

                    objEnt1.Orgid = objEntityLeavSettlmt.OrgId;
                    objEnt1.CorpOffice = objEntityLeavSettlmt.CorpId;
                    objEnt1.Month = dtprevFromDate.Month;
                    objEnt1.Year = dtprevFromDate.Year;
                    
                    // objEnt1
                    DataTable dtOtherAddDedDetls = objBuss1.ReadEmpManualy_Add_Dedn(objEnt1);
                    decimal TotOthrAddAmt = 0, TotOthrDeductAmt = 0;
                    for (int i = 0; i < dtOtherAddDedDetls.Rows.Count; i++)
                    {
                        if (dtOtherAddDedDetls.Rows[i]["PAYRL_MODE"].ToString() == "1")
                        {
                            TotOthrAddAmt += Convert.ToDecimal(dtOtherAddDedDetls.Rows[i]["PAYINFDT_AMOUNT"].ToString());
                        }
                        else if (dtOtherAddDedDetls.Rows[i]["PAYRL_MODE"].ToString() == "2")
                        {
                            TotOthrDeductAmt += Convert.ToDecimal(dtOtherAddDedDetls.Rows[i]["PAYINFDT_AMOUNT"].ToString());
                        }
                    }


                    if (CurrMonthBasic != "")
                    {
                        decCurrMonthBasic = Convert.ToDecimal(CurrMonthBasic);
                    }
                    if (basicAmt != "")
                    {
                        basicAmt1 = Convert.ToDecimal(basicAmt);
                        TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(decCurrMonthBasic);
                    }
                    if (AllowaceAmt != "")
                    {
                        AllowaceAmt1 = Convert.ToDecimal(AllowaceAmt);
                        TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(AllowaceAmt);
                    }
                    if (AllowovertimeAmount != "")
                    {
                        AllowovertimeAmount1 = Convert.ToDecimal(AllowovertimeAmount);
                        TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(AllowovertimeAmount);
                    }
                    if (TotOthrAddAmt != 0)
                    {
                        TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(TotOthrAddAmt);
                    }
                    if (DedctionAmt != "")
                    {
                        deductnamt = Convert.ToDecimal(DedctionAmt);
                        TotalDedctn = TotalDedctn + Convert.ToDecimal(DedctionAmt);
                    }
                    if (DedctionInstalmntAmnt != "")
                    {
                        instlmntDedctionAmt = Convert.ToDecimal(DedctionInstalmntAmnt);
                        TotalDedctn = TotalDedctn + Convert.ToDecimal(DedctionInstalmntAmnt);
                    }
                    if (MessAmnt != "")
                    {
                        decMessAmnt = Convert.ToDecimal(MessAmnt);
                        TotalDedctn = TotalDedctn + Convert.ToDecimal(decMessAmnt);
                    }
                    if (LvArrearAmnt != "")
                    {
                        decLvArrearAmnt = Convert.ToDecimal(LvArrearAmnt);
                        TotalDedctn = TotalDedctn + Convert.ToDecimal(decLvArrearAmnt);
                    }
                    if (TotOthrDeductAmt != 0)
                    {
                        TotalDedctn = TotalDedctn + Convert.ToDecimal(TotOthrDeductAmt);
                    }
                    if (Total != "")
                    {
                        netsalary = Convert.ToDecimal(Total);
                    }
                    string FinalNetAmt = Math.Round(netsalary, 0).ToString();
                    netsalary = Convert.ToDecimal(FinalNetAmt);

                    int daysInm = DateTime.DaysInMonth(dtprevFromDate.Year, dtprevFromDate.Month);
                    decimal decPerHourSal = Convert.ToDecimal(basicAmt) / daysInm;
                    if (decPerHourSal > 0)
                    {
                        decPerHourSal = decPerHourSal / 8;
                    }

                    decimal NormalOTAmnt = NormlOT * NormalOvertmRatePrHr * decPerHourSal;
                    decimal HolidayOTAmnt = HoldayOt * HolidayOvertmRatePrHr * decPerHourSal;


                    string strbasicAmt = objBusiness.AddCommasForNumberSeperation(basicAmt1.ToString("0.00"), objEntityCommon);
                    string strCurrbasicAmt = objBusiness.AddCommasForNumberSeperation(Math.Round(decCurrMonthBasic, roundNum).ToString("0.00"), objEntityCommon);

                    string strAllowaceAmt = objBusiness.AddCommasForNumberSeperation(Math.Round(AllowaceAmt1, roundNum).ToString("0.00"), objEntityCommon);
                    string strAllowovertimeAmount = objBusiness.AddCommasForNumberSeperation(Math.Round(AllowovertimeAmount1, roundNum).ToString("0.00"), objEntityCommon);
                    string strTotalBasicAllow = objBusiness.AddCommasForNumberSeperation(Math.Round(TotalBasicAllow, roundNum).ToString("0.00"), objEntityCommon);
                    string strDeductnAmt = objBusiness.AddCommasForNumberSeperation(Math.Round(deductnamt, roundNum).ToString("0.00"), objEntityCommon);
                    string strDeductnInstlmtAmount = objBusiness.AddCommasForNumberSeperation(Math.Round(instlmntDedctionAmt, roundNum).ToString("0.00"), objEntityCommon);
                    string strTotalDedctn = objBusiness.AddCommasForNumberSeperation(Math.Round(TotalDedctn, roundNum).ToString("0.00"), objEntityCommon);
                    string strnetsalary = objBusiness.AddCommasForNumberSeperation(netsalary.ToString("0.00"), objEntityCommon);
                    string strMessAmnt = objBusiness.AddCommasForNumberSeperation(Math.Round(decMessAmnt, roundNum).ToString("0.00"), objEntityCommon);
                    string strLvArrearAmnt = objBusiness.AddCommasForNumberSeperation(Math.Round(decLvArrearAmnt, roundNum).ToString("0.00"), objEntityCommon);


                    string strNormalOTAmnt = objBusiness.AddCommasForNumberSeperation(NormalOTAmnt.ToString("0.00"), objEntityCommon);
                    string strHolidayOTAmnt = objBusiness.AddCommasForNumberSeperation(HolidayOTAmnt.ToString("0.00"), objEntityCommon);

                    int numCurrDays = (numMonth - startMonth) + 1;

                    decimal PerDaySalCurr = Convert.ToDecimal(basicAmt) / daysInm;
                    decimal workdays = decCurrMonthBasic / PerDaySalCurr;
                    workdays = Math.Round(workdays, 1);
                    if (workdays % 1 == 0)
                    {
                        workdays = Convert.ToInt32(workdays);
                    }

                    float pos4 = writer.GetVerticalPosition(false);

                    PdfPTable sumtable = new PdfPTable(6);
                    float[] footrsBody = { 14, 28, 16, 13, 15, 14 };
                    sumtable.SetWidths(footrsBody);
                    sumtable.WidthPercentage = 100;

                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Basic and Allowances", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = BaseColor.LIGHT_GRAY, Colspan = 4, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Description", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase("Days/Hrs", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Basic Pay", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(strbasicAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(workdays.ToString(), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(strCurrbasicAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    if (Convert.ToDecimal(strAllowaceAmt) != 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Special Allowance", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strAllowaceAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strAllowaceAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    }
                    if (NormlOT != 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Normal OT @" + NormalOvertmRatePrHr.ToString() + "/hr", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(NormlOT.ToString(), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strNormalOTAmnt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    }
                    if (HoldayOt != 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Holiday OT @" + HolidayOvertmRatePrHr.ToString() + "/hr", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(HoldayOt.ToString(), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strHolidayOTAmnt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    }
                    for (int i = 0; i < dtOtherAddDedDetls.Rows.Count; i++)
                    {
                        if (dtOtherAddDedDetls.Rows[i]["PAYRL_MODE"].ToString() == "1")
                        {
                            string strTotOthrAddAmt = objBusiness.AddCommasForNumberSeperation(Convert.ToDecimal(dtOtherAddDedDetls.Rows[i]["PAYINFDT_AMOUNT"]).ToString("0.00"), objEntityCommon);
                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            sumtable.AddCell(new PdfPCell(new Phrase(dtOtherAddDedDetls.Rows[i]["PAYRL_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(strTotOthrAddAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(strTotOthrAddAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        }
                    }
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Total Basic and Allowances", FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(strTotalBasicAllow, FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Deductions", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = BaseColor.LIGHT_GRAY, Colspan = 4, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Deduction Types", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BackgroundColor = BaseColor.LIGHT_GRAY, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = BaseColor.LIGHT_GRAY, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    if (Convert.ToDecimal(strDeductnAmt) != 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Special Deductions", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strDeductnAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    }
                    if (Convert.ToDecimal(strDeductnInstlmtAmount) != 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Installment Deductions", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strDeductnInstlmtAmount, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    }
                    if (Convert.ToDecimal(strMessAmnt) != 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Mess Deductions", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strMessAmnt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    }
                    if (Convert.ToDecimal(strLvArrearAmnt) != 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Leave Arrear Deductions", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strLvArrearAmnt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    }
                    for (int i = 0; i < dtOtherAddDedDetls.Rows.Count; i++)
                    {
                        if (dtOtherAddDedDetls.Rows[i]["PAYRL_MODE"].ToString() == "2")
                        {
                            string strTotOthrDeductAmt = objBusiness.AddCommasForNumberSeperation(Convert.ToDecimal(dtOtherAddDedDetls.Rows[i]["PAYINFDT_AMOUNT"]).ToString("0.00"), objEntityCommon);
                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                            sumtable.AddCell(new PdfPCell(new Phrase(dtOtherAddDedDetls.Rows[i]["PAYRL_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(strTotOthrDeductAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        }
                    }
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Total Deductions", FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(strTotalDedctn, FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = BaseColor.LIGHT_GRAY, Colspan = 4, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Net Salary", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(strnetsalary + " " + dt.Rows[0]["CRNCMST_ABBRV"].ToString(), FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    if (pos4 > 200)
                    {
                    }
                    else
                    {
                        document.NewPage();
                    }

                    document.Add(sumtable);


                    float pos1 = writer.GetVerticalPosition(false);
                    PdfPTable endtable = new PdfPTable(6);
                    float[] endBody = { 25, 10, 25, 10, 25, 5 };
                    endtable.SetWidths(endBody);
                    endtable.WidthPercentage = 100;
                    endtable.TotalWidth = document.PageSize.Width - 80f;

                    endtable.AddCell(new PdfPCell(new Phrase("FINANCE MANAGER", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                    endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                    endtable.AddCell(new PdfPCell(new Phrase("GENERAL MANAGER", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                    endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                    endtable.AddCell(new PdfPCell(new Phrase("RECEIVER’S SIGNATURE", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                    endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                    endtable.TotalWidth = 555F;
                    if (pos1 > 70)
                    {
                        endtable.WriteSelectedRows(0, -1, 50, 65, writer.DirectContent);
                    }
                    else
                    {
                        document.NewPage();
                        endtable.WriteSelectedRows(0, -1, 50, 65, writer.DirectContent);
                    }
                }
                //End:-Previous month

                document.Close();

                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=LaborCard_LS_" + hiddenView.Value + ".pdf");
                Response.Buffer = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();

            }
        }
    }

    public class PDFHeader : PdfPageEventHelper
    {
        // This is the contentbyte object of the writer
        PdfContentByte cb;

        // we will put the final number of pages in a template
        PdfTemplate footerTemplate;

        // this is the BaseFont we are going to use for the header / footer
        BaseFont bf = null;

        // This keeps track of the creation time
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
        public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            base.OnEndPage(writer, document);
            clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
            clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
            objEntityLeavSettlmt.EmployeeId = Convert.ToInt32(HttpContext.Current.Session["USERID"].ToString());
            DataTable dtEmp = objBusinessLeavSettlmt.ReadEmpDtls(objEntityLeavSettlmt);


            PdfPTable table3 = new PdfPTable(1);
            float[] tableBody3 = { 100 };
            table3.SetWidths(tableBody3);
            table3.WidthPercentage = 100;
            table3.TotalWidth = 650F;
            table3.AddCell(new PdfPCell(new Phrase("_________________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
            table3.WriteSelectedRows(0, -1, 0, document.PageSize.GetBottom(50), writer.DirectContent);

            PdfPTable headImg = new PdfPTable(3);
            string strImageLogo = "/Images/Design_Images/images/Compztlogo.png";
            if (strImageLogo != "")
            {
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
                image.ScalePercent(PdfPCell.ALIGN_CENTER);
                image.ScaleToFit(60f, 40f);
                headImg.AddCell(new PdfPCell(image) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_TOP });
            }
            headImg.AddCell(new PdfPCell(new Paragraph("Report generated in Compzit by:" + dtEmp.Rows[0]["USR_CODE"].ToString() + ", " + dtEmp.Rows[0]["USR_FNAME"].ToString() + "\nReport generated on:" + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
            headImg.AddCell(new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            float[] headersHeading = { 20, 60, 20 };
            headImg.SetWidths(headersHeading);
            headImg.WidthPercentage = 100;
            headImg.TotalWidth = document.PageSize.Width - 80f;
            headImg.WriteSelectedRows(0, -1, 50, document.PageSize.GetBottom(40), writer.DirectContent);


            String text = "Page " + writer.PageNumber + " of ";
            //Add paging to footer
            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.SetTextMatrix(document.PageSize.GetRight(100), document.PageSize.GetBottom(30));
                cb.ShowText(text);
                cb.EndText();
                float len = bf.GetWidthPoint(text, 8);
                cb.AddTemplate(footerTemplate, document.PageSize.GetRight(100) + len, document.PageSize.GetBottom(30));
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


    public static string CheckWorkerMissingAttendance(string strEmpId, DateTime dtFromDate, DateTime dtToDate, string strCorp, string Org)
    {
        string strJson = "true";
        clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
        clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityLeavSettlmt.DateStartDate = dtFromDate;
        objEntityLeavSettlmt.DateEndDate = dtToDate;
        objEntityLeavSettlmt.EmployeeId = Convert.ToInt32(strEmpId);
        objEntityLeavSettlmt.UserId = Convert.ToInt32(strEmpId);
        objEntityLeavSettlmt.CorpId = Convert.ToInt32(strCorp);
        objEntityLeavSettlmt.OrgId = Convert.ToInt32(Org);
        DataTable dtLeaveDate = objBusinessLeavSettlmt.ReadLeaveDateMiss(objEntityLeavSettlmt);
        DataTable dtAttendance = objBusinessLeavSettlmt.ReadAttendance(objEntityLeavSettlmt);

        dutyOf objDuty = new dutyOf();
        for (var day = dtFromDate; day <= dtToDate; day = day.AddDays(1))
        {
            string sts = "0";
            string hol = objDuty.checkholiday(day, dtFromDate, dtToDate);
            if (hol == "true")
            {
                continue;
            }
            string off = objDuty.CheckDutyOff(day, strCorp, Org);
            if (off == "true")
            {
                continue;
            }
            DateTime CurrDate = objCommon.textToDateTime(day.ToString("dd-MM-yyyy"));
            DataRow[] result = dtAttendance.Select("EMPDLYHR_DATE ='" + day.ToString("dd-MM-yyyy") + "'");
            if (result.Length > 0)
            {
                continue;
            }
            for (int lcnt = 0; lcnt < dtLeaveDate.Rows.Count; lcnt++)
            {
                DateTime LfrmDt = DateTime.MinValue;
                DateTime LToDt = DateTime.MinValue;
                if (dtLeaveDate.Rows[lcnt]["LEAVE_FROM_DATE"].ToString() != "")
                {
                    LfrmDt = objCommon.textToDateTime(dtLeaveDate.Rows[lcnt]["LEAVE_FROM_DATE"].ToString());
                }
                if (dtLeaveDate.Rows[lcnt]["LEAVE_TO_DATE"].ToString() != "")
                {
                    LToDt = objCommon.textToDateTime(dtLeaveDate.Rows[lcnt]["LEAVE_TO_DATE"].ToString());
                }
                if (LfrmDt != DateTime.MinValue && LToDt != DateTime.MinValue && CurrDate >= LfrmDt && CurrDate <= LToDt)
                {
                    sts = "1";
                    break;
                }
                else if (LfrmDt != DateTime.MinValue && LToDt == DateTime.MinValue && CurrDate == LfrmDt)
                {
                    sts = "1";
                    break;
                }
            }
            if (sts == "0")
            {
                strJson = "false";
                break;
            }
        }
        return strJson;
    }


    public static  bool NthDayOfMonth(DateTime date, DayOfWeek dow, int n)
    {
        int d = date.Day;
        //return date.DayOfWeek == dow && ((d / 7 == n)|| (d / 7 == (n - 1) && d % 7 > 0));
        return date.DayOfWeek == dow && (d - 1) / 7 == (n - 1);
    }

    public static int GetOccuranceOfWeekday(int Year, int Month, DayOfWeek Weekday)
    {
        int ReturnValue = 0;
        DateTime MyDate = new DateTime(Year, Month, 1);
        int Start = 1;
        if (Weekday != MyDate.DayOfWeek)
        {
            Start = -(MyDate.DayOfWeek - Weekday - 1);
            if (Start <= 0)
            {
                ReturnValue = -1;
            }

        }
        while (Start <= DateTime.DaysInMonth(Year, Month))
        {
            ReturnValue += 1;
            Start += 7;
        }
        return ReturnValue;
    }
    //private static DateTime GetSaturdayByWeek(DateTime dateofMonth, int weekNumber, int DayNumber)
    //{
    //    //DateTime firstDateofMonth = new DateTime(dateofMonth.Year, dateofMonth.Month, 1);
    //    //DateTime resultDate = CultureInfo.InvariantCulture.Calendar.AddWeeks(firstDateofMonth, weekNumber - 1);
    //    //int day = Convert.ToInt32(resultDate.DayOfWeek) < DayNumber ? (Convert.ToInt32(resultDate.DayOfWeek) - DayNumber) * -1 : 0;
    //    //return resultDate.AddDays(day);

    //    DateTime dtSat = new DateTime(dateofMonth.Year, dateofMonth.Month, 1);
    //    DateTime Occurrence;
    //    int j = 0;
    //    string DesiredDay = "1";
    //    if (Convert.ToInt32(DesiredDay) - Convert.ToInt32(dtSat.DayOfWeek) >= 0)

    //        j = Convert.ToInt32(DesiredDay) - Convert.ToInt32(dtSat.DayOfWeek) + 1;

    //    else

    //        j = (7 - Convert.ToInt32(dtSat.DayOfWeek)) + (Convert.ToInt32(DesiredDay) + 1);



    //    return j + (Occurrence - 1) * 7;
    //}
    public static decimal MonthSalaryArr(string strEmpId, DateTime dtFromDate, DateTime dtToDate, string strBasicPay, DataTable dtAllownce, DataTable dtDeductn, int BasicPayStatus, int FixedSts, string strCorp, string Org, string IndividualRound, string ZeroWorkFixed, int holiSts, int offSts)
    {
        decimal TotalDays = 0;
        decimal TotalLeaveCnt = 0;
        decimal decBasicPay = 0;
        decimal decArrearAmnt = 0;
        decimal decAllownc = 0;
        decimal decOvertm = 0;
        decimal decInstlmnt = 0;
        decimal deciDeduction = 0;
        decimal decOtherAddtionAmount = 0;
        decimal decOtherDeductionAmount = 0;

        clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
        clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityLeavSettlmt.DateStartDate = dtFromDate;
        objEntityLeavSettlmt.DateEndDate = dtToDate;
        objEntityLeavSettlmt.EmployeeId = Convert.ToInt32(strEmpId);
        objEntityLeavSettlmt.UserId = Convert.ToInt32(strEmpId);



        objEntityLeavSettlmt.CorpId = Convert.ToInt32(strCorp);
        objEntityLeavSettlmt.OrgId = Convert.ToInt32(Org);

        TotalDays = Convert.ToInt32((dtToDate - dtFromDate).TotalDays) + 1;

        dutyOf objDuty = new dutyOf();
        //Start:-Deduc off day or holiday
        DateTime datenowS, enddateS;
        datenowS = dtFromDate;
        enddateS = dtToDate;
        if (holiSts == 1 || offSts == 1)
        {
            int offCR = 0;
            for (var day = datenowS; day <= enddateS; day = day.AddDays(1))
            {
                string hol = "false";
                if (holiSts == 1)
                {
                    hol = objDuty.checkholiday(day, datenowS, enddateS);
                    if (hol == "true")
                    {
                        offCR = offCR + 1;
                    }
                }
                if (offSts == 1 && hol != "true")
                {
                    string off = objDuty.CheckDutyOff(day, objEntityLeavSettlmt.CorpId.ToString(), objEntityLeavSettlmt.OrgId.ToString());
                    if (off == "true")
                    {
                        offCR = offCR + 1;
                    }
                }
            }
            TotalDays = TotalDays - offCR;
        }

        //End:-Deduc off day or holiday



        int daysInm = DateTime.DaysInMonth(dtFromDate.Year, dtFromDate.Month);

       

        cls_Business_Monthly_Salary_Process objBuss2 = new cls_Business_Monthly_Salary_Process();
        cls_Entity_Monthly_Salary_Process objEnt2 = new cls_Entity_Monthly_Salary_Process();
        objEnt2.Employee = objEntityLeavSettlmt.EmployeeId;
        objEnt2.DateStartDate = objEntityLeavSettlmt.DateEndDate.AddDays(1);
        objEnt2.DateEndDate = new DateTime(dtToDate.Year, 12, 31);
        objEnt2.CorpOffice = Convert.ToInt32(strCorp);
        objEnt2.Orgid = Convert.ToInt32(Org);

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dtLeaveDateFuture = new DataTable();
        if (objEnt2.DateStartDate.Year == objEnt2.DateEndDate.Year)
        {
            dtLeaveDateFuture = objBuss2.ReadLeaveDate(objEnt2);
        }

        //Leave count calculation DateEndDate
        string[] stringArray = new string[50];
        int CurrArray = 0;
        DataTable dtLeaveDate = objBusinessLeavSettlmt.ReadLeaveDate(objEntityLeavSettlmt);
        for (int lcnt = 0; lcnt < dtLeaveDate.Rows.Count; lcnt++)
        {

            int HoliPaidSts = Convert.ToInt32(dtLeaveDate.Rows[lcnt]["LEAVETYP_HOLIDAY_PAID_STS"].ToString());
            int OffPaidSts = Convert.ToInt32(dtLeaveDate.Rows[lcnt]["LEAVETYP_OFFDAY_PAID_STS"].ToString());

            int OffCount = 0;

            decimal dedHalfLeave = 0;
            decimal cnt = 0;
            DateTime LfrmDt = DateTime.MinValue;
            DateTime LToDt = DateTime.MinValue;
            if (dtLeaveDate.Rows[lcnt]["LEAVE_FROM_DATE"].ToString() != "")
            {
                LfrmDt = objCommon.textToDateTime(dtLeaveDate.Rows[lcnt]["LEAVE_FROM_DATE"].ToString());
            }
            if (dtLeaveDate.Rows[lcnt]["LEAVE_TO_DATE"].ToString() != "")
            {
                LToDt = objCommon.textToDateTime(dtLeaveDate.Rows[lcnt]["LEAVE_TO_DATE"].ToString());
            }
            if (LfrmDt != DateTime.MinValue && LToDt != DateTime.MinValue)
            {
                int LvFrmMonth = LfrmDt.Month;
                int LvFrmYear = LfrmDt.Year;
                int LvFrmDay = LfrmDt.Day;
                int LvToMonth = LToDt.Month;
                int LvToYear = LToDt.Year;
                int LvToDay = LToDt.Day;
                if (LvFrmYear == dtFromDate.Year && LvFrmMonth == dtFromDate.Month && LvToYear == dtFromDate.Year && LvToMonth == dtFromDate.Month)
                {
                    if (LfrmDt < dtFromDate)
                    {
                        LfrmDt = dtFromDate;
                    }
                    else
                    {
                        if (dtLeaveDate.Rows[lcnt]["LEAVE_FROM_SCTN"].ToString() != "1")
                        {
                            dedHalfLeave = dedHalfLeave + (decimal)0.5;
                        }
                    }
                    if (LToDt > dtToDate)
                    {
                        LToDt = dtToDate;
                    }
                    else
                    {
                        if (dtLeaveDate.Rows[lcnt]["LEAVE_TO_SCTN"].ToString() != "1")
                        {
                            dedHalfLeave = dedHalfLeave + (decimal)0.5;
                        }
                    }

                    cnt = LToDt.Day - LfrmDt.Day + 1;
                    cnt = cnt - dedHalfLeave;


                    DateTime datenow, enddate;
                    datenow = LfrmDt;
                    enddate = LToDt;

                    if (HoliPaidSts == 1 || OffPaidSts == 1)
                    {
                        for (var day = datenow; day <= enddate; day = day.AddDays(1))
                        {
                            string hol = "false";
                            if (HoliPaidSts == 1)
                            {
                                hol = objDuty.checkholiday(day, datenow, enddate);
                                if (hol == "true")
                                {
                                    OffCount = OffCount + 1;
                                }
                            }
                            if (OffPaidSts == 1 && hol != "true")
                            {
                                string off = objDuty.CheckDutyOff(day, objEnt2.CorpOffice.ToString(), objEnt2.Orgid.ToString());
                                if (off == "true")
                                {
                                    OffCount = OffCount + 1;
                                }
                            }
                        }
                    }

                    cnt = cnt - OffCount;
                    if (cnt < 0)
                    {
                        cnt = 0;
                    }



                    if (dtLeaveDate.Rows[lcnt]["LEAVETYPDTLS_PAIDLEAVE"].ToString() == "0")
                    {
                        string stringToCheck = dtLeaveDate.Rows[lcnt]["LEAVETYP_ID"].ToString();

                        decimal FutureLeaveCnt = calcFutureLeaveCnt(stringToCheck, dtLeaveDateFuture, objEnt2);
                        decimal BalCount = Convert.ToDecimal(dtLeaveDate.Rows[lcnt]["BALANCE_NUMLEAVE"].ToString()) + FutureLeaveCnt;

                        int FindSts = 0;
                        for (int i = 0; i < CurrArray; i++)
                        {
                            if (stringArray[i] != null && stringArray[i].Contains(stringToCheck))
                            {
                                FindSts = 1;
                                string[] stringArrayX = stringArray[i].Split(',');
                                decimal decPrevCount = Convert.ToDecimal(stringArrayX[1]) + cnt;
                                stringArray[i] = stringToCheck + "," + decPrevCount + "," + dtLeaveDate.Rows[lcnt]["OPENING_NUMLEAVE"].ToString() + "," + BalCount.ToString();
                            }
                        }
                        if (FindSts == 0)
                        {
                            stringArray[CurrArray] = stringToCheck + "," + cnt + "," + dtLeaveDate.Rows[lcnt]["OPENING_NUMLEAVE"].ToString() + "," + BalCount.ToString();
                            CurrArray += 1;
                        }
                        cnt = 0;
                    }
                }
                else if (LvToYear == dtFromDate.Year && LvToMonth == dtFromDate.Month)
                {
                    LfrmDt = dtFromDate;
                    if (LToDt > dtToDate)
                    {
                        LToDt = dtToDate;
                    }
                    else
                    {
                        if (dtLeaveDate.Rows[lcnt]["LEAVE_TO_SCTN"].ToString() != "1")
                        {
                            dedHalfLeave = dedHalfLeave + (decimal)0.5;
                        }
                    }

                    cnt = LToDt.Day - LfrmDt.Day + 1;
                    cnt = cnt - dedHalfLeave;

                    DateTime datenow, enddate;
                    datenow = LfrmDt;
                    enddate = LToDt;
                    if (HoliPaidSts == 1 || OffPaidSts == 1)
                    {
                        for (var day = datenow; day <= enddate; day = day.AddDays(1))
                        {
                            string hol = "false";
                            if (HoliPaidSts == 1)
                            {
                                hol = objDuty.checkholiday(day, datenow, enddate);
                                if (hol == "true")
                                {
                                    OffCount = OffCount + 1;
                                }
                            }
                            if (OffPaidSts == 1 && hol != "true")
                            {
                                string off = objDuty.CheckDutyOff(day, objEnt2.CorpOffice.ToString(), objEnt2.Orgid.ToString());
                                if (off == "true")
                                {
                                    OffCount = OffCount + 1;
                                }
                            }
                        }
                    }

                    cnt = cnt - OffCount;
                    if (cnt < 0)
                    {
                        cnt = 0;
                    }



                    if (dtLeaveDate.Rows[lcnt]["LEAVETYPDTLS_PAIDLEAVE"].ToString() == "0")
                    {
                        string stringToCheck = dtLeaveDate.Rows[lcnt]["LEAVETYP_ID"].ToString();

                        decimal FutureLeaveCnt = calcFutureLeaveCnt(stringToCheck, dtLeaveDateFuture, objEnt2);
                        decimal BalCount = Convert.ToDecimal(dtLeaveDate.Rows[lcnt]["BALANCE_NUMLEAVE"].ToString()) + FutureLeaveCnt;
                        int FindSts = 0;
                        for (int i = 0; i < CurrArray; i++)
                        {
                            if (stringArray[i] != null && stringArray[i].Contains(stringToCheck))
                            {
                                FindSts = 1;
                                string[] stringArrayX = stringArray[i].Split(',');
                                decimal decPrevCount = Convert.ToDecimal(stringArrayX[1]) + cnt;
                                stringArray[i] = stringToCheck + "," + decPrevCount + "," + dtLeaveDate.Rows[lcnt]["OPENING_NUMLEAVE"].ToString() + "," + BalCount.ToString();
                            }
                        }
                        if (FindSts == 0)
                        {
                            stringArray[CurrArray] = stringToCheck + "," + cnt + "," + dtLeaveDate.Rows[lcnt]["OPENING_NUMLEAVE"].ToString() + "," + BalCount.ToString();
                            CurrArray += 1;
                        }
                        cnt = 0;

                    }
                }
                else if (LvFrmYear == dtFromDate.Year && LvFrmMonth == dtFromDate.Month)
                {

                    if (LfrmDt < dtFromDate)
                    {
                        LfrmDt = dtFromDate;
                    }
                    else
                    {
                        if (dtLeaveDate.Rows[lcnt]["LEAVE_FROM_SCTN"].ToString() != "1")
                        {
                            dedHalfLeave = dedHalfLeave + (decimal)0.5;
                        }
                    }
                    LToDt = dtToDate;

                    cnt = LToDt.Day - LfrmDt.Day + 1;
                    cnt = cnt - dedHalfLeave;

                    DateTime datenow, enddate;
                    datenow = LfrmDt;
                    enddate = LToDt;
                    if (HoliPaidSts == 1 || OffPaidSts == 1)
                    {
                        for (var day = datenow; day <= enddate; day = day.AddDays(1))
                        {
                            string hol = "false";
                            if (HoliPaidSts == 1)
                            {
                                hol = objDuty.checkholiday(day, datenow, enddate);
                                if (hol == "true")
                                {
                                    OffCount = OffCount + 1;
                                }
                            }
                            if (OffPaidSts == 1 && hol != "true")
                            {
                                string off = objDuty.CheckDutyOff(day, objEnt2.CorpOffice.ToString(), objEnt2.Orgid.ToString());
                                if (off == "true")
                                {
                                    OffCount = OffCount + 1;
                                }
                            }
                        }
                    }

                    cnt = cnt - OffCount;
                    if (cnt < 0)
                    {
                        cnt = 0;
                    }


                    if (dtLeaveDate.Rows[lcnt]["LEAVETYPDTLS_PAIDLEAVE"].ToString() == "0")
                    {
                        string stringToCheck = dtLeaveDate.Rows[lcnt]["LEAVETYP_ID"].ToString();

                        decimal FutureLeaveCnt = calcFutureLeaveCnt(stringToCheck, dtLeaveDateFuture, objEnt2);
                        decimal BalCount = Convert.ToDecimal(dtLeaveDate.Rows[lcnt]["BALANCE_NUMLEAVE"].ToString()) + FutureLeaveCnt;
                        int FindSts = 0;
                        for (int i = 0; i < CurrArray; i++)
                        {
                            if (stringArray[i] != null && stringArray[i].Contains(stringToCheck))
                            {
                                FindSts = 1;
                                string[] stringArrayX = stringArray[i].Split(',');
                                decimal decPrevCount = Convert.ToDecimal(stringArrayX[1]) + cnt;
                                stringArray[i] = stringToCheck + "," + decPrevCount + "," + dtLeaveDate.Rows[lcnt]["OPENING_NUMLEAVE"].ToString() + "," + BalCount.ToString();
                            }
                        }
                        if (FindSts == 0)
                        {
                            stringArray[CurrArray] = stringToCheck + "," + cnt + "," + dtLeaveDate.Rows[lcnt]["OPENING_NUMLEAVE"].ToString() + "," + BalCount.ToString();
                            CurrArray += 1;
                        }
                        cnt = 0;

                    }
                }
                else //if (LvFrmYear <= OBJ.Year && LvFrmMonth < OBJ.Month && LvToYear >= OBJ.Year && LvToMonth > OBJ.Month)
                {
                    cnt = dtToDate.Day - dtFromDate.Day + 1;
                    if (dtLeaveDate.Rows[lcnt]["LEAVE_FROM_SCTN"].ToString() != "1")
                    {
                        cnt = cnt - (decimal)0.5;
                    }
                    if (dtLeaveDate.Rows[lcnt]["LEAVE_TO_SCTN"].ToString() != "1")
                    {
                        cnt = cnt - (decimal)0.5;
                    }

                    DateTime datenow, enddate;
                    datenow = dtFromDate;
                    enddate = dtToDate;



                    if (HoliPaidSts == 1 || OffPaidSts == 1)
                    {
                        for (var day = datenow; day <= enddate; day = day.AddDays(1))
                        {
                            string hol = "false";
                            if (HoliPaidSts == 1)
                            {
                                hol = objDuty.checkholiday(day, datenow, enddate);
                                if (hol == "true")
                                {
                                    OffCount = OffCount + 1;
                                }
                            }
                            if (OffPaidSts == 1 && hol != "true")
                            {
                                string off = objDuty.CheckDutyOff(day, objEnt2.CorpOffice.ToString(), objEnt2.Orgid.ToString());
                                if (off == "true")
                                {
                                    OffCount = OffCount + 1;
                                }
                            }
                        }
                    }
                    cnt = cnt - OffCount;
                    if (cnt < 0)
                    {
                        cnt = 0;
                    }
                    if (dtLeaveDate.Rows[lcnt]["LEAVETYPDTLS_PAIDLEAVE"].ToString() == "0")
                    {
                        string stringToCheck = dtLeaveDate.Rows[lcnt]["LEAVETYP_ID"].ToString();
                        decimal FutureLeaveCnt = calcFutureLeaveCnt(stringToCheck, dtLeaveDateFuture, objEnt2);
                        decimal BalCount = Convert.ToDecimal(dtLeaveDate.Rows[lcnt]["BALANCE_NUMLEAVE"].ToString()) + FutureLeaveCnt;
                        int FindSts = 0;
                        for (int i = 0; i < CurrArray; i++)
                        {
                            if (stringArray[i] != null && stringArray[i].Contains(stringToCheck))
                            {
                                FindSts = 1;
                                string[] stringArrayX = stringArray[i].Split(',');
                                decimal decPrevCount = Convert.ToDecimal(stringArrayX[1]) + cnt;
                                stringArray[i] = stringToCheck + "," + decPrevCount + "," + dtLeaveDate.Rows[lcnt]["OPENING_NUMLEAVE"].ToString() + "," + BalCount.ToString();
                            }
                        }
                        if (FindSts == 0)
                        {
                            stringArray[CurrArray] = stringToCheck + "," + cnt + "," + dtLeaveDate.Rows[lcnt]["OPENING_NUMLEAVE"].ToString() + "," + BalCount.ToString();
                            CurrArray += 1;
                        }
                        cnt = 0;
                    }
                }
            }
            else if (LfrmDt != DateTime.MinValue && LToDt == DateTime.MinValue)
            {
                int LvFrmMonth = LfrmDt.Month;
                int LvFrmYear = LfrmDt.Year;
                int LvFrmDay = LfrmDt.Day;
                if (LvFrmYear == dtFromDate.Year && LvFrmMonth == dtFromDate.Month)
                {
                    if (dtLeaveDate.Rows[lcnt]["LEAVE_FROM_SCTN"].ToString() == "1")
                    {
                        cnt = 1;
                    }
                    else
                    {
                        cnt = (decimal)0.5;
                    }
                    if (dtLeaveDate.Rows[lcnt]["LEAVETYPDTLS_PAIDLEAVE"].ToString() == "0")
                    {
                        string stringToCheck = dtLeaveDate.Rows[lcnt]["LEAVETYP_ID"].ToString();

                        decimal FutureLeaveCnt = calcFutureLeaveCnt(stringToCheck, dtLeaveDateFuture, objEnt2);
                        decimal BalCount = Convert.ToDecimal(dtLeaveDate.Rows[lcnt]["BALANCE_NUMLEAVE"].ToString()) + FutureLeaveCnt;
                        int FindSts = 0;
                        for (int i = 0; i < CurrArray; i++)
                        {
                            if (stringArray[i] != null && stringArray[i].Contains(stringToCheck))
                            {
                                FindSts = 1;
                                string[] stringArrayX = stringArray[i].Split(',');
                                decimal decPrevCount = Convert.ToDecimal(stringArrayX[1]) + cnt;
                                stringArray[i] = stringToCheck + "," + decPrevCount + "," + dtLeaveDate.Rows[lcnt]["OPENING_NUMLEAVE"].ToString() + "," + BalCount.ToString();
                            }
                        }
                        if (FindSts == 0)
                        {
                            stringArray[CurrArray] = stringToCheck + "," + cnt + "," + dtLeaveDate.Rows[lcnt]["OPENING_NUMLEAVE"].ToString() + "," + BalCount.ToString();
                            CurrArray += 1;
                        }
                        cnt = 0;

                    }
                }
            }
            TotalLeaveCnt += cnt;
        }

        for (int i = 0; i < CurrArray; i++)
        {
            string[] stringArrayX = stringArray[i].Split(',');
            decimal decTotLeaveCount = Convert.ToDecimal(stringArrayX[1]);
            decimal decOpenCount = Convert.ToDecimal(stringArrayX[2]);
            decimal decBalCount = Convert.ToDecimal(stringArrayX[3]);
            if (decBalCount < 0)
            {
                decBalCount = decBalCount * -1;
                if (decBalCount >= decTotLeaveCount)
                {
                    TotalLeaveCnt += decTotLeaveCount;
                }
                else
                {
                    TotalLeaveCnt += decBalCount;
                }
            }
        }



        if (TotalDays > TotalLeaveCnt || ZeroWorkFixed == "1")
        {
            //Basic pay calculation       
            if (strBasicPay != "")
            {
                decBasicPay = Convert.ToDecimal(strBasicPay) / daysInm;
                if (BasicPayStatus == 0)
                {
                    if (ZeroWorkFixed == "0")
                    {
                        decBasicPay = Convert.ToDecimal(strBasicPay);
                    }
                    else
                    {
                        decBasicPay = 0;
                    }
                }
                else
                {
                    decBasicPay = decBasicPay * (TotalDays - TotalLeaveCnt);
                }
            }

            //Arrear amount calculation      
            int CurrMonth = dtFromDate.Month;
            int CurrYear = dtFromDate.Year;
            int PrevMnth = 0, PrevYear = 0;
            if (CurrMonth == 1)
            {
                PrevMnth = 12;
                PrevYear = CurrYear - 1;
            }
            else
            {
                PrevMnth = CurrMonth - 1;
                PrevYear = CurrYear;
            }
            objEntityLeavSettlmt.PrevMnth = PrevMnth;
            objEntityLeavSettlmt.Year = PrevYear;
            DataTable dtSalMnth = objBusinessLeavSettlmt.ReadMonthsalary(objEntityLeavSettlmt);
            if (dtSalMnth.Rows.Count > 0)
            {
                if (dtSalMnth.Rows[0]["SLPRCDMNTH_ARREAR_AMNT"].ToString() != "")
                {
                    decArrearAmnt = Convert.ToDecimal(dtSalMnth.Rows[0]["SLPRCDMNTH_ARREAR_AMNT"].ToString());
                }
            }

            string pmonth = objEntityLeavSettlmt.DateEndDate.Month.ToString("00");
            string pyear = objEntityLeavSettlmt.DateEndDate.Year.ToString();

            objEnt2.Month = Convert.ToInt32(pmonth);
            objEnt2.Year = Convert.ToInt32(pyear);
            //Other Addition & Deduction
            DataTable dtOther_Addition = objBuss2.ReadEmpManualy_AdditionDetails(objEnt2);
            DataTable dtOther_Deduction = objBuss2.ReadEmpManualy_DeductionsDetails(objEnt2);

            objEntityLeavSettlmt.Month = Convert.ToInt32(pmonth);
            objEntityLeavSettlmt.Year = Convert.ToInt32(pyear);

            //     DataTable dtOtherAdd_DedDtls = objBusinessLeavSettlmt.ReadEmpManualy_Add_Dedn_Details(objEntityLeavSettlmt);


            int PAYINF_ID = 0;

            if (dtOther_Addition.Rows.Count > 0)
            {
                for (int intRow = 0; intRow < dtOther_Addition.Rows.Count; intRow++)
                {
                    decOtherAddtionAmount += Convert.ToDecimal(dtOther_Addition.Rows[intRow]["OTHER_ADDITION"].ToString());
                    PAYINF_ID = Convert.ToInt32(dtOther_Addition.Rows[intRow]["PAYINF_ID"].ToString());

                    string strOthrAddAmt = Convert.ToString(Convert.ToDecimal(dtOther_Addition.Rows[intRow]["OTHER_ADDITION"]).ToString("0.00"));

                    if (IndividualRound == "1" && strOthrAddAmt != "")
                    {
                        strOthrAddAmt = Math.Round(Convert.ToDecimal(strOthrAddAmt), 0).ToString("0.00");
                    }
                }
            }

            if (dtOther_Deduction.Rows.Count > 0)
            {
                for (int intRow = 0; intRow < dtOther_Deduction.Rows.Count; intRow++)
                {
                    decOtherDeductionAmount += Convert.ToDecimal(dtOther_Deduction.Rows[intRow]["OTHER_DEDUCTION"].ToString());
                    PAYINF_ID = Convert.ToInt32(dtOther_Deduction.Rows[intRow]["PAYINF_ID"].ToString());

                    string strOthrDeductAmt = Convert.ToString(Convert.ToDecimal(dtOther_Deduction.Rows[intRow]["OTHER_DEDUCTION"]).ToString("0.00"));
                    if (IndividualRound == "1" && strOthrDeductAmt != "")
                    {
                        strOthrDeductAmt = Math.Round(Convert.ToDecimal(strOthrDeductAmt), 0).ToString("0.00");
                    }
                }
            }



            //Addition calculation      
            for (int intRowCount = 0; intRowCount < dtAllownce.Rows.Count; intRowCount++)
            {
                decimal DecAlwancAmt = 0;
                if (dtAllownce.Rows[intRowCount]["SLRYALLCE_AMOUNT"].ToString() != "")
                {
                    if (dtAllownce.Rows[intRowCount]["PAYRL_TYPE_STS"].ToString() == "0")//Fixed Allowance
                    {
                        if (ZeroWorkFixed == "0")
                        {
                            DecAlwancAmt = Convert.ToDecimal(dtAllownce.Rows[intRowCount]["SLRYALLCE_AMOUNT"].ToString());
                        }
                    }
                    else//Variable Allowance
                    {
                        DecAlwancAmt = Convert.ToDecimal(dtAllownce.Rows[intRowCount]["SLRYALLCE_AMOUNT"].ToString());
                        decimal amtOneDay = DecAlwancAmt / daysInm;
                        DecAlwancAmt = amtOneDay * (TotalDays - TotalLeaveCnt);
                    }

                }
                decAllownc += DecAlwancAmt;
            }

            //Overtime amount calculation       
            DataTable dtOvertm = objBusinessLeavSettlmt.ReadOvertimeAdd(objEntityLeavSettlmt);
            if (dtOvertm.Rows.Count > 0 && dtOvertm.Rows[0]["AMOUNT"].ToString() != "")
            {
                //EVM-0012
                //Modification on OT calculation 5440
                decimal decPerHourSal = Convert.ToDecimal(strBasicPay) / daysInm;
                if (decPerHourSal > 0)
                {
                    //Per Hour Salary
                    decPerHourSal = decPerHourSal / 8;
                }
                decOvertm = Convert.ToDecimal(dtOvertm.Rows[0]["AMOUNT"].ToString());
                decOvertm = decOvertm * decPerHourSal;
            }



            //Installment amount       
            DataTable dtDeductnMstr = objBusinessLeavSettlmt.ReadDeductionMaster(objEntityLeavSettlmt);
            if (dtDeductnMstr.Rows.Count > 0)
            {
                if (dtDeductnMstr.Rows[0]["DEDUCTNAMT"].ToString() != "")
                {
                    decInstlmnt = Convert.ToDecimal(dtDeductnMstr.Rows[0]["DEDUCTNAMT"].ToString());
                }
            }

            //deduction amount      
            for (int intRowCount = 0; intRowCount < dtDeductn.Rows.Count; intRowCount++)
            {
                decimal DecDeduction = 0, DecDeductionbasicPay = 0, DecDeductionTotlPay = 0, DecCurrAmnt = 0;
                if (dtDeductn.Rows[intRowCount]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString() == "0")//Amount deduction
                {
                    if (dtDeductn.Rows[intRowCount]["SLRYDEDTN_AMOUNT"].ToString() != "")
                    {
                        if (dtDeductn.Rows[intRowCount]["PAYRL_TYPE_STS"].ToString() == "0")//Fixed deduction
                        {
                            if (ZeroWorkFixed == "0")
                            {
                                DecDeduction = Convert.ToDecimal(dtDeductn.Rows[intRowCount]["SLRYDEDTN_AMOUNT"].ToString());
                            }
                        }
                        else//Variable deduction
                        {
                            DecDeduction = Convert.ToDecimal(dtDeductn.Rows[intRowCount]["SLRYDEDTN_AMOUNT"].ToString());
                            decimal amtOneDay = DecDeduction / daysInm;
                            DecDeduction = amtOneDay * (TotalDays - TotalLeaveCnt);
                        }
                    }
                    DecCurrAmnt = DecDeduction;
                }
                else if (dtDeductn.Rows[intRowCount]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString() == "1")//Percentage deduction
                {
                    if (dtDeductn.Rows[intRowCount]["SLRYDEDTN_BASIC_OR_TOTAL_AMNT"].ToString() == "0") //basic pay deductn
                    {
                        if (dtDeductn.Rows[intRowCount]["PAYRL_TYPE_STS"].ToString() == "0")//Fixed deduction
                        {
                            if (ZeroWorkFixed == "0")
                            {
                                DecDeductionbasicPay = Convert.ToDecimal(dtDeductn.Rows[intRowCount]["SLRYDEDTN_PERCNTGE"].ToString());
                                DecDeductionbasicPay = Convert.ToDecimal(strBasicPay) * (DecDeductionbasicPay / 100);
                            }
                        }
                        else //variable deduction
                        {
                            DecDeductionbasicPay = Convert.ToDecimal(dtDeductn.Rows[intRowCount]["SLRYDEDTN_PERCNTGE"].ToString());
                            DecDeductionbasicPay = Convert.ToDecimal(strBasicPay) * (DecDeductionbasicPay / 100);
                            decimal amtOneDay = DecDeductionbasicPay / daysInm;
                            DecDeductionbasicPay = amtOneDay * (TotalDays - TotalLeaveCnt);
                        }
                        DecCurrAmnt = DecDeductionbasicPay;
                    }
                    else if (dtDeductn.Rows[intRowCount]["SLRYDEDTN_BASIC_OR_TOTAL_AMNT"].ToString() == "1") //total pay deductn
                    {
                        if (dtDeductn.Rows[intRowCount]["PAYRL_TYPE_STS"].ToString() == "0")//Fixed deduction
                        {
                            if (ZeroWorkFixed == "0")
                            {
                                DecDeductionTotlPay = Convert.ToDecimal(dtDeductn.Rows[intRowCount]["SLRYDEDTN_PERCNTGE"].ToString());
                                DecDeductionTotlPay = (Convert.ToDecimal(strBasicPay) + decAllownc) * (DecDeductionTotlPay / 100);
                            }
                        }
                        else//Variable deduction
                        {
                            DecDeductionTotlPay = Convert.ToDecimal(dtDeductn.Rows[intRowCount]["SLRYDEDTN_PERCNTGE"].ToString());
                            DecDeductionTotlPay = (Convert.ToDecimal(strBasicPay) + decAllownc) * (DecDeductionTotlPay / 100);
                            decimal amtOneDay = DecDeductionTotlPay / daysInm;
                            DecDeductionTotlPay = amtOneDay * (TotalDays - TotalLeaveCnt);

                        }
                        DecCurrAmnt = DecDeductionTotlPay;
                    }
                }
                deciDeduction += DecDeduction + DecDeductionbasicPay + DecDeductionTotlPay;
            }
        }
        int cntD = 2;
        if (IndividualRound == "1")
        {
            cntD = 0;
        }
        return Math.Round(decArrearAmnt, cntD) + Math.Round(decOtherAddtionAmount, cntD) + Math.Round(decBasicPay, cntD) + Math.Round(decAllownc, cntD) + Math.Round(decOvertm, cntD) - Math.Round(deciDeduction, cntD) - Math.Round(decInstlmnt, cntD) - Math.Round(decOtherDeductionAmount, cntD);
    }
}
   


    


