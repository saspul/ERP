using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using CL_Compzit;
using BL_Compzit;
using EL_Compzit;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Collections;
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_AWMS;
using System.Globalization;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


public partial class HCM_HCM_Master_hcm_PayrollSystem_hcm_End_Service_Leave_Stlmnt_hcm_End_Service_Leave_Stlmnt : System.Web.UI.Page
{
    public static DateTime dtCurrDate = new DateTime();
    public static DateTime dtCorpGratityDate = new DateTime();
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["READ"] != null)
        {
            this.MasterPageFile = "~/MasterPage/MasterPage_Modal.master";

        }
        else
        {
            this.MasterPageFile = "~/MasterPage/MasterPageNewHcm.master";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            HiddenMessDedctn.Value = "";
            HiddenSuccessMsgType.Value = "0";
            if (Session["SuccessMsg"] != null)
            {
                HiddenSuccessMsgType.Value = Session["SuccessMsg"].ToString();
            }
            Session["SuccessMsg"] = null;
            LoadFormData();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            int intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            int intCorpId = 0, intOrgId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            int intUsrRolMstrId, intEnableAdd = 0, intEnableConfirm = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.End_Of_Service_Leave_Settlement);
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
                        hiddenRoleAdd.Value = intEnableAdd.ToString();
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleConfirm.Value = intEnableConfirm.ToString();
                    }

                }
            }
            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
            }
            else
            {
            }
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                            clsCommonLibrary.CORP_GLOBAL.PAYROLL_INDIVIDUAL_ROUND,
                                                            clsCommonLibrary.CORP_GLOBAL.WORKDAY_FIXED_PAYRL_MODE
                                                         
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                HiddenFieldIndividualRound.Value = dtCorpDetail.Rows[0]["PAYROLL_INDIVIDUAL_ROUND"].ToString();
                HiddenFieldWorkdayFixedPayrlMode.Value = dtCorpDetail.Rows[0]["WORKDAY_FIXED_PAYRL_MODE"].ToString();
            }
            //when editing 
            if (Session["EDIT_ID"] != null)
            {
                txtComments.Focus();
                ddlEmployee.Enabled = false;
                // btnCalculate.Visible = false;
                btnClear.Visible = false;
                string strId = Session["EDIT_ID"].ToString();
                hiddenEditID.Value = strId;
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    btnUpdate.Visible = true;
                }
                btnUpdateClose.Visible = true;
                Update(strId, intCorpId, intOrgId, intEnableConfirm);
                lblHeader.InnerText = "Edit End Of Service Settlement ";




            }
            //when  viewing
            else if (Session["VIEW_ID"] != null)
            {
                txtComments.Focus();
                ddlEmployee.Enabled = false;
                btnCalculate.Visible = false;
                btnClear.Visible = false;
                string strId = Session["VIEW_ID"].ToString();
                hiddenViewID.Value = strId;
                Update(strId, intCorpId, intOrgId, intEnableConfirm);
                btnConfirm.Visible = false;
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                txtComments.Enabled = false;
                txtNetAmount.Enabled = false;
                txtOtherAmount.Enabled = false;
                txtOtherDeductions.Enabled = false;
                txtTicketAmount.Enabled = false;
                lblHeader.InnerText = "View End Of Service Settlement ";
            }
            else if (Session["READ"] != null)
            {

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnConfirm.Visible = false;
                btnCancel.Visible = false;
                divList.Visible = false;
                lblHeader.InnerText = "View End Of Service Settlement ";
                txtComments.Focus();
                ddlEmployee.Enabled = false;
                btnCalculate.Visible = false;
                btnClear.Visible = false;
                string strId = Session["READ"].ToString();
                Session["READ"] = null;
                hiddenViewID.Value = strId;
                Update(strId, intCorpId, intOrgId, intEnableConfirm);
                btnConfirm.Visible = false;
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                //INPUT FIELDS
                txtComments.Enabled = false;
                txtNetAmount.Enabled = false;
                txtOtherAmount.Enabled = false;
                txtOtherDeductions.Enabled = false;
                txtTicketAmount.Enabled = false;

            }
            else
            {
                ddlEmployee.Focus();
            }

           

            // for adding comma
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
                hiddenCurrencyAbbrv.Value = dtCurrencyDetail.Rows[0]["CRNCMST_ABBRV"].ToString();
            }
            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
            dtCurrDate = objCommon.textToDateTime(strCurrentDate);


            clsBusinessLayerEndOfServiceLeaveStlmnt objBusinessLayerEndOfServiceLeaveStlmnt = new clsBusinessLayerEndOfServiceLeaveStlmnt();
            clsEntityLayerEndOfServiceLeaveStlmnt objEntityLayerEndOfServiceLeaveStlmnt = new clsEntityLayerEndOfServiceLeaveStlmnt();
            objEntityLayerEndOfServiceLeaveStlmnt.CorpId = intCorpId;
            objEntityLayerEndOfServiceLeaveStlmnt.OrgId = intOrgId;
            DataTable dtGrtCorpDate = objBusinessLayerEndOfServiceLeaveStlmnt.readGratuityDate(objEntityLayerEndOfServiceLeaveStlmnt);
            if (dtGrtCorpDate.Rows.Count > 0)
            {
                dtCorpGratityDate = Convert.ToDateTime(dtGrtCorpDate.Rows[0]["GRATUITY_START_DATE"].ToString());
            }


         

        }
    }
    protected void LoadFormData()
    {
        clsBusinessLayerEndOfServiceLeaveStlmnt objBusinessLayerEndOfServiceLeaveStlmnt = new clsBusinessLayerEndOfServiceLeaveStlmnt();
        clsEntityLayerEndOfServiceLeaveStlmnt objEntityLayerEndOfServiceLeaveStlmnt = new clsEntityLayerEndOfServiceLeaveStlmnt();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLayerEndOfServiceLeaveStlmnt.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityLayerEndOfServiceLeaveStlmnt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable DtLevAlloDetails = new DataTable();
        DtLevAlloDetails = objBusinessLayerEndOfServiceLeaveStlmnt.ReadExitEmployeeList(objEntityLayerEndOfServiceLeaveStlmnt);
        if (DtLevAlloDetails.Rows.Count > 0)
        {
            ddlEmployee.DataSource = DtLevAlloDetails;
            ddlEmployee.DataValueField = "USR_ID";
            ddlEmployee.DataTextField = "USR_NAME";
            ddlEmployee.DataBind();

        }
        ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");
    }
    protected void btnAddClose_Click(object sender, EventArgs e)
    {
        //txtLeaveDays  txtLeaveSalary txtPrevMonthSal
        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerEndOfServiceLeaveStlmnt objBusinessLayerEndOfServiceLeaveStlmnt = new clsBusinessLayerEndOfServiceLeaveStlmnt();
        clsEntityLayerEndOfServiceLeaveStlmnt objEntityLayerEndOfServiceLeaveStlmnt = new clsEntityLayerEndOfServiceLeaveStlmnt();
        List<clsEntityLayerEmpSalary> objEntityAdditionList = new List<clsEntityLayerEmpSalary>();
        List<clsEntityLayerEmpSalary> objEntityDeductionList = new List<clsEntityLayerEmpSalary>();
        try
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLayerEndOfServiceLeaveStlmnt.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityLayerEndOfServiceLeaveStlmnt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objEntityLayerEndOfServiceLeaveStlmnt.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            //string[] keys = Request.Form.AllKeys;
            if (ddlEmployee.SelectedItem.Value.ToString() != "--SELECT EMPLOYEE--")
            {
                objEntityLayerEndOfServiceLeaveStlmnt.EmployeeID = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
            }



            objEntityLayerEndOfServiceLeaveStlmnt.PrevMnthArrAmt = Convert.ToDecimal(HiddenFieldPrevArrAmt.Value);
            if (HiddenFieldPrevMntRejoinDate.Value != "")
            {
                objEntityLayerEndOfServiceLeaveStlmnt.PrevMntRejoinDate = objCommon.textToDateTime(HiddenFieldPrevMntRejoinDate.Value);
            }


            objEntityLayerEndOfServiceLeaveStlmnt.OpenElgibleDays = Convert.ToDecimal(Request.Form["txtLeaveDaysOpen"].Trim());
            objEntityLayerEndOfServiceLeaveStlmnt.OpenLeaveSalary = Convert.ToDecimal(Request.Form["txtOpenLeaveSalary"].Trim());

            objEntityLayerEndOfServiceLeaveStlmnt.LvArrearAmnt = Convert.ToDecimal(Request.Form["txtLvArrearAmt"].Trim());


            if (cbxGrtJoinDate.Checked == true)
            {
                objEntityLayerEndOfServiceLeaveStlmnt.GrtJoinDateSts = 1;
            }

            objEntityLayerEndOfServiceLeaveStlmnt.DateOfLeaving = objCommon.textToDateTime(Request.Form["txtDateOfLeaving"].Trim());

            if (Request.Form["txtEmpStatusID"].ToString() != "" && Request.Form["txtEmpStatusID"].ToString() != "0")
            {
                objEntityLayerEndOfServiceLeaveStlmnt.EmployeeStatus = Convert.ToInt32(Request.Form["txtEmpStatusID"]);
            }
            objEntityLayerEndOfServiceLeaveStlmnt.Comments = txtComments.Text.Trim();
            objEntityLayerEndOfServiceLeaveStlmnt.DateReJoin = objCommon.textToDateTime(Request.Form["txtLastRejoinDate"].Trim());

            objEntityLayerEndOfServiceLeaveStlmnt.EligibleDaysLveSalary = Convert.ToDecimal(Request.Form["txtLeaveDays"].Trim());
            objEntityLayerEndOfServiceLeaveStlmnt.EligibleDaysLveGratuity = Convert.ToDecimal(Request.Form["txtGratuityDays"].Trim());
            objEntityLayerEndOfServiceLeaveStlmnt.GratuityAmount = Convert.ToDecimal(Request.Form["txtGratuity"].Trim());
            objEntityLayerEndOfServiceLeaveStlmnt.LeaveSalary = Convert.ToDecimal(Request.Form["txtLeaveSalary"].Trim());
            objEntityLayerEndOfServiceLeaveStlmnt.CurrentMonthSalary = Convert.ToDecimal(Request.Form["txtCurrentMonthSal"].Trim());
            objEntityLayerEndOfServiceLeaveStlmnt.PreviousMonthSalary = Convert.ToDecimal(Request.Form["txtPrevMonthSal"].Trim());
            //if (txtOtherAmount.Text.Trim() != "")
            //{
            //    objEntityLayerEndOfServiceLeaveStlmnt.OtherAmount = Convert.ToDecimal(txtOtherAmount.Text.Trim());
            //}
            if (txtTicketAmount.Text.Trim() != "")
                objEntityLayerEndOfServiceLeaveStlmnt.TicketAmount = Convert.ToDecimal(txtTicketAmount.Text.Trim());
            //if (txtOtherDeductions.Text.Trim() != "")
            //    objEntityLayerEndOfServiceLeaveStlmnt.OtherDeduction = Convert.ToDecimal(txtOtherDeductions.Text.Trim());


           // objEntityLayerEndOfServiceLeaveStlmnt.OtherAmount = Convert.ToDecimal(Request.Form["txtOtherAmount"].Trim());
           // objEntityLayerEndOfServiceLeaveStlmnt.OtherDeduction = Convert.ToDecimal(Request.Form["txtOtherDeductions"].Trim());

            if (Page.Request.Form[txtOtherAmount.UniqueID].ToString() != "")
            {
                objEntityLayerEndOfServiceLeaveStlmnt.OtherAmount = Convert.ToDecimal(Page.Request.Form[txtOtherAmount.UniqueID].ToString());
            }

            if (Page.Request.Form[txtOtherDeductions.UniqueID].ToString() != "")
            {
                objEntityLayerEndOfServiceLeaveStlmnt.OtherDeduction = Convert.ToDecimal(Page.Request.Form[txtOtherDeductions.UniqueID].ToString());
            }

            if (HiddenFieldPrevOtherAddAmt.Value != "")
            {
                objEntityLayerEndOfServiceLeaveStlmnt.PrevOtherAmount = Convert.ToDecimal(HiddenFieldPrevOtherAddAmt.Value.Trim());
            }
            if (HiddenFieldPrevOtherDeductAmt.Value != "")
            {
                objEntityLayerEndOfServiceLeaveStlmnt.PrevOtherDeduction = Convert.ToDecimal(HiddenFieldPrevOtherDeductAmt.Value.Trim());
            }

            if (hiddenNetAmount.Value.Trim() != "")
                objEntityLayerEndOfServiceLeaveStlmnt.NetAmount = Convert.ToDecimal(hiddenNetAmount.Value.Trim());
            if (Request.Form["txtBasicPay"].Trim() != "")
                objEntityLayerEndOfServiceLeaveStlmnt.Bacispay = Convert.ToDecimal(Request.Form["txtBasicPay"].Trim());
            if (Request.Form["txtAddition"].Trim() != "")
                objEntityLayerEndOfServiceLeaveStlmnt.Addition = Convert.ToDecimal(Request.Form["txtAddition"].Trim());
            if (Request.Form["txtDeduction"].Trim() != "")
                objEntityLayerEndOfServiceLeaveStlmnt.Deduction = Convert.ToDecimal(Request.Form["txtDeduction"].Trim());
            if (Request.Form["txtOverTimeAddition"].Trim() != "")
                objEntityLayerEndOfServiceLeaveStlmnt.OT_Addition = Convert.ToDecimal(Request.Form["txtOverTimeAddition"].Trim());
            if (Request.Form["txtPaymentDeduction"].Trim() != "")
                objEntityLayerEndOfServiceLeaveStlmnt.EmpPaymentDeduction = Convert.ToDecimal(Request.Form["txtPaymentDeduction"].Trim());

            objEntityLayerEndOfServiceLeaveStlmnt.MessAmnt = Convert.ToDecimal(HiddenMessDedctn.Value);

            objEntityLayerEndOfServiceLeaveStlmnt.CancelReason = HiddenFieldLeaveDeductCnt.Value;



            if (HiddenFieldPrevAddition.Value != "")
            {
                objEntityLayerEndOfServiceLeaveStlmnt.PrevAdditionAmnt = Convert.ToDecimal(HiddenFieldPrevAddition.Value.Trim());
            }
            if (HiddenFieldPrevOvertimeAmt.Value != "")
            {
                objEntityLayerEndOfServiceLeaveStlmnt.PrevOvertimeAmnt = Convert.ToDecimal(HiddenFieldPrevOvertimeAmt.Value.Trim());
            }
            if (HiddenFieldPrevDeduction.Value != "")
            {
                objEntityLayerEndOfServiceLeaveStlmnt.PrevDeductionAmnt = Convert.ToDecimal(HiddenFieldPrevDeduction.Value.Trim());
            }
            if (HiddenFieldPrevPaymntDedAmt.Value != "")
            {
                objEntityLayerEndOfServiceLeaveStlmnt.PrevPaymntDedAmnt = Convert.ToDecimal(HiddenFieldPrevPaymntDedAmt.Value.Trim());
            }
            if (HiddenFieldPrevMessAmt.Value != "")
            {
                objEntityLayerEndOfServiceLeaveStlmnt.PrevMessAmnt = Convert.ToDecimal(HiddenFieldPrevMessAmt.Value.Trim());
            }



            if (HiddenFieldFromDate.Value != "")
            {
                objEntityLayerEndOfServiceLeaveStlmnt.FromDate = objCommon.textToDateTime(HiddenFieldFromDate.Value);
            }
            if (HiddenFieldChangeSts.Value == "1")
            {
                objEntityLayerEndOfServiceLeaveStlmnt.CancelStatus = 1;
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

            //Session["EDIT_ID"] = null;
            Session["VIEW_ID"] = null;
        }
        catch (Exception ex)
        {
            throw ex;
        }



        if (clickedButton.ID == "btnAdd")
        {
            objBusinessLayerEndOfServiceLeaveStlmnt.AddEndSrvLveStlmnt(objEntityLayerEndOfServiceLeaveStlmnt,objEntityAdditionList, objEntityDeductionList);

            //success msg
            Session["SuccessMsg"] = "SAVE";
            Response.Redirect("hcm_End_Service_Leave_Settlement.aspx");
        }
        else if (clickedButton.ID == "btnAddClose")
        {
            objBusinessLayerEndOfServiceLeaveStlmnt.AddEndSrvLveStlmnt(objEntityLayerEndOfServiceLeaveStlmnt, objEntityAdditionList, objEntityDeductionList);
            // objEntityLayerEndOfServiceLeaveStlmnt.MessAmnt = Convert.ToDecimal(HiddenMessDedctn.Value);
            Session["SuccessMsg"] = "SAVE";
            Response.Redirect("hcm_End_Service_Leave_Stlmnt_List.aspx");
        }
        else if (clickedButton.ID == "btnUpdate")
        {
            objEntityLayerEndOfServiceLeaveStlmnt.EndSrvLveStlmntID = Convert.ToInt32(hiddenEditID.Value);
            objBusinessLayerEndOfServiceLeaveStlmnt.UpdateEndSrvLveStlmnt(objEntityLayerEndOfServiceLeaveStlmnt, objEntityAdditionList, objEntityDeductionList);
            //success msg
            Session["SuccessMsg"] = "UPDATE";
            Response.Redirect("hcm_End_Service_Leave_Settlement.aspx");
        }
        else if (clickedButton.ID == "btnUpdateClose")
        {
            objEntityLayerEndOfServiceLeaveStlmnt.EndSrvLveStlmntID = Convert.ToInt32(hiddenEditID.Value);
            objBusinessLayerEndOfServiceLeaveStlmnt.UpdateEndSrvLveStlmnt(objEntityLayerEndOfServiceLeaveStlmnt, objEntityAdditionList, objEntityDeductionList);

            Session["SuccessMsg"] = "UPDATE";
            Response.Redirect("hcm_End_Service_Leave_Stlmnt_List.aspx");

        }
        else if (clickedButton.ID == "btnCon")
        {
            objEntityLayerEndOfServiceLeaveStlmnt.EndSrvLveStlmntID = Convert.ToInt32(hiddenEditID.Value);
            objEntityLayerEndOfServiceLeaveStlmnt.ConfirmStatus = 1;

            objBusinessLayerEndOfServiceLeaveStlmnt.UpdateEndSrvLveStlmnt(objEntityLayerEndOfServiceLeaveStlmnt, objEntityAdditionList, objEntityDeductionList);


            //Update to GN_USER_LEAVE_TYPES
            if (HiddenFieldLeaveDeductCnt.Value != "")
            {
                string[] values = HiddenFieldLeaveDeductCnt.Value.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i] != "")
                    {
                        string[] EachLeave = values[i].Split('-');
                        clsEntityLayerLeaveSettlmt objSubEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
                        clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
                        if (ddlEmployee.SelectedItem.Value.ToString() != "--SELECT EMPLOYEE--")
                        {
                            objSubEntityLeavSettlmt.EmployeeId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
                        }
                        objSubEntityLeavSettlmt.LeaveTypeId = Convert.ToInt32(EachLeave[0]);
                        objSubEntityLeavSettlmt.Year = Convert.ToInt32(EachLeave[1]);
                        objSubEntityLeavSettlmt.BalanceLeave = Convert.ToDecimal(EachLeave[2]);
                        objBusinessLeavSettlmt.UpdateEligibleDaysCount(objSubEntityLeavSettlmt);
                    }
                }
            }




            //success msg
            Session["SuccessMsg"] = "CONFIRM";
            Response.Redirect("hcm_End_Service_Leave_Settlement.aspx");
        }

    }

    public static void InsLeaveType(int intCorpID, int intOrgID, int intEmployeeID, DateTime Date2)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLeaveRequest objBusinessLeaveRequest = new clsBusinessLeaveRequest();
        clsEntityLeaveRequest objEntityLeaveRequest = new clsEntityLeaveRequest();
        objEntityLeaveRequest.Corporate_id = intCorpID;
        objEntityLeaveRequest.Organisation_id = intOrgID;
        objEntityLeaveRequest.User_Id = intEmployeeID;

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
                DateTime dtTod = dtCurrDate;
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
                        //if (rowDesg[0].ToString() == "1")
                        //{
                        //    if (ExpYears >= 0 && ExpYears <= 2)
                        //    {
                        //        ExpChck = "true";
                        //    }
                        //}
                        //else if (rowDesg[0].ToString() == "2")
                        //{
                        //    if (ExpYears >= 2 && ExpYears <= 4)
                        //    {
                        //        ExpChck = "true";
                        //    }
                        //}
                        //else if (rowDesg[0].ToString() == "3")
                        //{
                        //    if (ExpYears >= 4 && ExpYears <= 6)
                        //    {
                        //        ExpChck = "true";
                        //    }
                        //}
                        //else if (rowDesg[0].ToString() == "4")
                        //{
                        //    if (ExpYears >= 6 && ExpYears <= 8)
                        //    {
                        //        ExpChck = "true";
                        //    }
                        //}
                        //else if (rowDesg[0].ToString() == "5")
                        //{
                        //    if (ExpYears >= 8 && ExpYears <= 10)
                        //    {
                        //        ExpChck = "true";
                        //    }
                        //}
                        //else if (rowDesg[0].ToString() == "6")
                        //{
                        //    if (ExpYears >= 10 && ExpYears <= 15)
                        //    {
                        //        ExpChck = "true";
                        //    }
                        //}
                        //else if (rowDesg[0].ToString() == "7")
                        //{
                        //    if (ExpYears >= 15 && ExpYears <= 20)
                        //    {
                        //        ExpChck = "true";
                        //    }
                        //}
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
    }
    [System.Web.Services.WebMethod]
    public static clsEndSrvStlmntLocal LoadEmployeeDetails(int intEmployeeID, int intCorpID, int intOrgID, string stringDateofLeaving, int intGrtFromJoinSts, string DecimalCnt, string IndividualRound,int ZeroWorkFixed)
    {
        //deciLeaveSalaryDays deciOpenLeaveDays   ReadMessDeductionByID  deciLeaveSalAmt
        //deciPrevMonSalary  strMessDedctn
       
        string strHtmlOtherAdd = "";
        string strHtmlOtherDed = "";
        clsEndSrvStlmntLocal objEndSrvStlmntLocal = new clsEndSrvStlmntLocal();
        try
        {

           clsEntityCommon objEntityCommon = new clsEntityCommon();
          int decmlcnt = Convert.ToInt32(DecimalCnt);
          string formatString = String.Concat("{0:F", decmlcnt, "}");

          int roundNum = 0;
          if (IndividualRound == "0")
          {
             roundNum = decmlcnt;
           }
          string format = String.Format("{{0:N{0}}}", roundNum);

            clsCommonLibrary objCommon = new clsCommonLibrary();
            DateTime dtLastStl = new DateTime();
            DateTime dtFinal = new DateTime();
            DateTime dtFinal1 = new DateTime();
            cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
            cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
            objEnt.Employee = intEmployeeID;
            objEnt.CorpOffice = intCorpID;
            objEnt.Orgid = intOrgID;
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
                    if (dtLeavMonth11.Rows[i]["LEVSETLMT_LST_SETLMTDATE"].ToString() != "" && dtLeavMonth11.Rows[i][1].ToString() == "1")
                    {
                        dtFinal1 = objCommon.textToDateTime(dtLeavMonth11.Rows[i]["LEVSETLMT_LST_SETLMTDATE"].ToString());
                        dtFinal1 = dtFinal1.AddDays(1);
                    }
                }
            }


            string PaidLeavePending = LoadEmployeeLeaveDate(intEmployeeID.ToString(), intCorpID.ToString(), intOrgID.ToString(), stringDateofLeaving);


            clsEntityLayerLeaveSettlmt objEntityLeavSettlmt2 = new clsEntityLayerLeaveSettlmt();
            clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt2 = new clsBusinessLayerLeaveSettlmt();
            objEntityLeavSettlmt2.EmployeeId = intEmployeeID;
            objEntityLeavSettlmt2.CorpId = intCorpID;
            objEntityLeavSettlmt2.OrgId = intOrgID;

            DateTime dProbEnddate = new DateTime();
            DataTable dtProb = objBusinessLeavSettlmt2.ReadProbationEnddate(objEntityLeavSettlmt2);
            if (dtProb.Rows.Count > 0 && dtProb.Rows[0][0].ToString() != "")
            {
                dProbEnddate = objCommon.textToDateTime(dtProb.Rows[0][0].ToString());
            }


            DataTable dtEmpRejoin2 = objBusinessLeavSettlmt2.ReadRejoin(objEntityLeavSettlmt2);
            int rejoinHalfDay = 0;
            if (dtEmpRejoin2.Rows.Count > 0 && dtEmpRejoin2.Rows[0]["DUTYREJOIN_DATE"].ToString() != "")
            {
                rejoinHalfDay = Convert.ToInt32(dtEmpRejoin2.Rows[0]["HALFDAY_STATUS"].ToString());
            }
            DataTable dtEmpOpenRejoin = objBusinessLeavSettlmt2.ReadOpenRejoin(objEntityLeavSettlmt2);
            //Start:-Read leave arrear amount
            DataTable dtLeaveArrear = objBusinessLeavSettlmt2.ReadLeaveArrearAmnt(objEntityLeavSettlmt2);
            if (dtLeaveArrear.Rows.Count > 0)
            {
                objEndSrvStlmntLocal.deciLvArrearAmnt = Convert.ToDecimal(dtLeaveArrear.Rows[0]["BALANCE_AMOUNT"].ToString());
            }
            //End:-Read leave arrear amount 



            clsBusinessLayerEndOfServiceLeaveStlmnt objBusinessLayerEndOfServiceLeaveStlmnt = new clsBusinessLayerEndOfServiceLeaveStlmnt();
            clsEntityLayerEndOfServiceLeaveStlmnt objEntityLayerEndOfServiceLeaveStlmnt = new clsEntityLayerEndOfServiceLeaveStlmnt();

            objEntityLayerEndOfServiceLeaveStlmnt.CorpId = intCorpID;
            objEntityLayerEndOfServiceLeaveStlmnt.OrgId = intOrgID;
            objEntityLayerEndOfServiceLeaveStlmnt.EmployeeID = intEmployeeID;

            string strAddDtls = "";
            string strDedDtls = "";
            string strAddDtlsPrev = "";
            string strDedDtlsPrev = "";
            DataTable dtEmpSalaryDeduction = objBusinessLayerEndOfServiceLeaveStlmnt.ReadEmpSalaryDeduction(objEntityLayerEndOfServiceLeaveStlmnt);
            DataTable dtEmpSalaryAllowance = objBusinessLayerEndOfServiceLeaveStlmnt.ReadEmpSalaryAllowance(objEntityLayerEndOfServiceLeaveStlmnt);
            DataTable dtEmpSalaryGratuityLeaveDays = objBusinessLayerEndOfServiceLeaveStlmnt.ReadEmpSalaryGratuityLeaveDays(objEntityLayerEndOfServiceLeaveStlmnt);
            DataTable dtEmpTotalAvailableLves = objBusinessLayerEndOfServiceLeaveStlmnt.ReadExitEmpTotalAvailableLves(objEntityLayerEndOfServiceLeaveStlmnt);
            DataTable dtEmpRejoinStatus = objBusinessLayerEndOfServiceLeaveStlmnt.ReadExitEmpRejoinDtls(objEntityLayerEndOfServiceLeaveStlmnt);
            DataTable dtEmpLastSalaryDate = objBusinessLayerEndOfServiceLeaveStlmnt.ReadPreSalaryDate(objEntityLayerEndOfServiceLeaveStlmnt);
            objEntityLayerEndOfServiceLeaveStlmnt.Date = objCommon.textToDateTime(stringDateofLeaving);
            DataTable dtLevDetailsByID = objBusinessLayerEndOfServiceLeaveStlmnt.ReadLevDetailsByID(objEntityLayerEndOfServiceLeaveStlmnt);

            //duty rejoin ticket sts deciLeaveSalaryDays
            string strRejoindate = "", strLveStlmntdate = "", strUsrJoindate = "", strUsrInsdate = "", strLevSettldDate = "";
            string strOpenRejoindateAct = "", strOpenRejoindateCalc = "";
            int intTicketSts = 0;
            string strRejoinLeaveId = "";
            string StrAllowance = "";
            DateTime LeaveToDate = new DateTime(); ;
            if (dtEmpRejoinStatus.Rows.Count > 0)
            {
                for (int intRowCount = 0; intRowCount < dtEmpRejoinStatus.Rows.Count; intRowCount++)
                {
                    if (dtEmpRejoinStatus.Rows[intRowCount]["TYPE"].ToString() == "DUTYREJOIN_DATE" && dtEmpRejoinStatus.Rows[intRowCount]["VALUE"].ToString() != "")
                    {
                        strRejoindate = dtEmpRejoinStatus.Rows[intRowCount]["VALUE"].ToString();
                    }
                    else if (dtEmpRejoinStatus.Rows[intRowCount]["TYPE"].ToString() == "LEVSETLMT_INS_DATE")
                    {
                        strLveStlmntdate = dtEmpRejoinStatus.Rows[intRowCount]["VALUE"].ToString();
                    }
                    else if (dtEmpRejoinStatus.Rows[intRowCount]["TYPE"].ToString() == "USR_JOIN_DATE")
                    {
                        strUsrJoindate = dtEmpRejoinStatus.Rows[intRowCount]["VALUE"].ToString();
                    }
                    else if (dtEmpRejoinStatus.Rows[intRowCount]["TYPE"].ToString() == "USR_INS_DATE")
                    {
                        strUsrInsdate = dtEmpRejoinStatus.Rows[intRowCount]["VALUE"].ToString();
                    }
                    else if (dtEmpRejoinStatus.Rows[intRowCount]["TYPE"].ToString() == "TICKET_COUNT" && dtEmpRejoinStatus.Rows[intRowCount]["VALUE"].ToString() != "")
                    {
                        intTicketSts = 1;
                    }
                    else if (dtEmpRejoinStatus.Rows[intRowCount]["TYPE"].ToString() == "." && dtEmpRejoinStatus.Rows[intRowCount]["VALUE"].ToString() != "")
                    {
                        strLevSettldDate = dtEmpRejoinStatus.Rows[intRowCount]["VALUE"].ToString();
                    }
                    if ((dtEmpRejoinStatus.Rows[intRowCount]["LEAVE_ID"].ToString() != "") && (dtEmpRejoinStatus.Rows[intRowCount]["LEAVE_ID"].ToString() != "0"))
                    {
                        strRejoinLeaveId = dtEmpRejoinStatus.Rows[intRowCount]["LEAVE_ID"].ToString();
                        objEntityLayerEndOfServiceLeaveStlmnt.LeaveId = Convert.ToInt32(strRejoinLeaveId);

                        DataTable dtRejoinLeave = objBusinessLayerEndOfServiceLeaveStlmnt.ReadRejoinLeave(objEntityLayerEndOfServiceLeaveStlmnt);
                        if (dtRejoinLeave.Rows.Count > 0)
                        {
                            if (dtRejoinLeave.Rows[0]["LEAVE_TO_DATE"].ToString() != "")
                            {
                                LeaveToDate = objCommon.textToDateTime(dtRejoinLeave.Rows[0]["LEAVE_TO_DATE"].ToString());
                            }
                            else if (dtRejoinLeave.Rows[0]["LEAVE_FROM_DATE"].ToString() != "")
                            {
                                LeaveToDate = objCommon.textToDateTime(dtRejoinLeave.Rows[0]["LEAVE_FROM_DATE"].ToString());
                            }
                        }
                    }
                }
            }


            if (dtEmpOpenRejoin.Rows.Count > 0 && dtEmpOpenRejoin.Rows[0]["USRJDT_ACT_DATE"].ToString() != "")
            {
                strOpenRejoindateAct = dtEmpOpenRejoin.Rows[0]["USRJDT_ACT_DATE"].ToString();
                strOpenRejoindateCalc = dtEmpOpenRejoin.Rows[0]["USRJDT_CALC_DATE"].ToString();
            }



            string strLastRejoinDate = "";
            string strLastRejoinDateDisp = "";
            if (strRejoindate != "")
            {
                strLastRejoinDate = strRejoindate;
                strLastRejoinDateDisp = strRejoindate;
            }
            else if (strOpenRejoindateCalc != "")
            {
                strLastRejoinDate = strOpenRejoindateCalc;
                strLastRejoinDateDisp = strOpenRejoindateAct;
            }
            else if (strUsrJoindate != "")
            {
                strLastRejoinDate = strUsrJoindate;
                strLastRejoinDateDisp = strUsrJoindate;
            }
            else if (strUsrInsdate != "")
            {
                strLastRejoinDate = strUsrInsdate;
                strLastRejoinDateDisp = strUsrInsdate;
            }
            DateTime dtRejoinDate = objCommon.textToDateTime(strLastRejoinDate);


            DateTime dateLastSalaryProcess = new DateTime();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            DateTime dateDateofLeaving = objCommon.textToDateTime(stringDateofLeaving);
            DateTime dateCurrentDate = dateDateofLeaving;

            int OnProbationSts = 0;
            if (dProbEnddate != DateTime.MinValue && dateDateofLeaving <= dProbEnddate)
            {
                OnProbationSts = 1;
            }


            dateLastSalaryProcess = DateTime.MinValue;
            int intLastSalaryMonth = 0; int intLastSalaryYear = 0;
            if (dtEmpLastSalaryDate.Rows.Count > 0)
            {
                intLastSalaryMonth = Convert.ToInt32(dtEmpLastSalaryDate.Rows[0]["SLPRCDMNTH_NUMBR"]);
                intLastSalaryYear = Convert.ToInt32(dtEmpLastSalaryDate.Rows[0]["SLPRCDMNTH_YEAR"]);
                if (intLastSalaryMonth > 0 && intLastSalaryYear > 0)
                {
                    DateTime dtLastSalaryPrcsDate = new DateTime();
                    int DtSettlMon = intLastSalaryMonth;
                    int DtSettlYr = intLastSalaryYear;
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
                    if (dtLastSalaryPrcsDate != DateTime.MinValue)
                    {
                        if (dtLastSalaryPrcsDate > dtRejoinDate)
                        {
                            dtRejoinDate = dtLastSalaryPrcsDate;
                        }
                    }
                }
            }
            string strPrevMnthFrom = "";
            decimal prevSal = 0;
            clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
            clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
            objEntityLeavSettlmt.CorpId = intCorpID;
            DataTable dtCorpSal = objBusinessLeavSettlmt.ReadCorpSal(objEntityLeavSettlmt);
            DateTime dateCorpSal = objCommon.textToDateTime(dtCorpSal.Rows[0]["COPRT_SALARY_DATE"].ToString());
            int BasicPayStatus = Convert.ToInt32(dtCorpSal.Rows[0]["BASIC_PAY"].ToString());
            if (dateCorpSal > dtRejoinDate)
            {
                dtRejoinDate = dateCorpSal;
            }
            string strDecision = "";


            int LsholiSts = 0, LSoffSts = 0;
            DateTime dtLstSettlddateRj = new DateTime();
            DataTable dtLeaveDtlsRj = new DataTable();


            //Read last leave settlement info
            objEntityLeavSettlmt.EmployeeId = intEmployeeID;
            DataTable DtLastSettleInfo = new DataTable();
            DataTable DtSettleAfterLeaveInfo = new DataTable();
            DateTime dtLastUpdSettle = new DateTime();
            DateTime dtLstSettlddate = new DateTime();
            int LastSettledAllowance = 0;
            DataTable dtLeavSettld = objBusinessLeavSettlmt.ReadLastSettldDt(objEntityLeavSettlmt);
            if (dtLeavSettld.Rows.Count > 0)
            {
                if (dtLeavSettld.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString() != "")
                {
                    dtLstSettlddate = objCommon.textToDateTime(dtLeavSettld.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString());
                    LastSettledAllowance = Convert.ToInt32(dtLeavSettld.Rows[0]["LEVSETLMT_FIXED_ALOWNC_STS"].ToString());
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
                clsEntityLayerLeaveSettlmt objEntityLeavSettlmt4 = new clsEntityLayerLeaveSettlmt();
                clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt4 = new clsBusinessLayerLeaveSettlmt();
                objEntityLeavSettlmt4.EmployeeId = intEmployeeID;
                objEntityLeavSettlmt4.CorpId = intCorpID;
                objEntityLeavSettlmt4.OrgId = intOrgID;
                DataTable dtEmpRejoin = objBusinessLeavSettlmt4.ReadRejoin(objEntityLeavSettlmt4);

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
                                LsholiSts = NotRHoliSts;
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


            objEndSrvStlmntLocal.strFromDate = dtRejoinDate.ToString("dd-MM-yyyy");

            int MonthDiff = (dateDateofLeaving.Year * 12 + dateDateofLeaving.Month) - (dtRejoinDate.Year * 12 + dtRejoinDate.Month);
            if (MonthDiff > 1 && strDecision == "")
            {
                strDecision = "Salary process pending";
            }
            if (PaidLeavePending == "1")
            {
                strDecision = "Paid leave pending";
            }
            //neww
            DataTable dtEmp = objBusinessLeavSettlmt.ReadEmpDtls(objEntityLeavSettlmt);
            string staffWorkr = "0";
            if (dtEmp.Rows.Count > 0)
            {
                staffWorkr = dtEmp.Rows[0]["STAFF_WORKER"].ToString().ToUpper();
            }
            if (strDecision == "" && staffWorkr == "1" && CheckWorkerMissingAttendance(intEmployeeID.ToString(), dtRejoinDate, dateDateofLeaving, intCorpID.ToString(), intOrgID.ToString()) == "false")
            {
                strDecision = "MissingAttendance";
            }
            //neww

            objEndSrvStlmntLocal.strDecision = strDecision;

            if (strDecision == "")
            {
                DateTime dateCalcFromDate = new DateTime();
                string strStartDate = "01-" + dateDateofLeaving.Month.ToString("D2") + "-" + dateDateofLeaving.Year;
                dateCalcFromDate = objCommon.textToDateTime(strStartDate);
                DateTime dtStartDate = objCommon.textToDateTime(strStartDate);
                if (dtRejoinDate > dtStartDate)
                {
                    dateCalcFromDate = dtRejoinDate;
                }

                //Current month salary calculation
                objEntityLayerEndOfServiceLeaveStlmnt.DateOfLeaving = objCommon.textToDateTime(stringDateofLeaving);
                objEntityLayerEndOfServiceLeaveStlmnt.DateStartDate = dateCalcFromDate;
                if (MonthDiff == 1)
                {
                    objEntityLayerEndOfServiceLeaveStlmnt.ConfirmStatus = 1;
                }
                DataTable dtMessDedctn = objBusinessLayerEndOfServiceLeaveStlmnt.ReadMessDeductionByID(objEntityLayerEndOfServiceLeaveStlmnt);
                decimal MessDedctn = 0; string StrMessDedctn = "0";
                if (dtMessDedctn.Rows.Count > 0)
                {
                    if (dtMessDedctn.Rows[0]["MESS_DEDCTN"].ToString() != "")
                    {
                        StrMessDedctn = dtMessDedctn.Rows[0]["MESS_DEDCTN"].ToString();
                        MessDedctn = Convert.ToDecimal(dtMessDedctn.Rows[0]["MESS_DEDCTN"].ToString());
                    }
                }



                objEntityLayerEndOfServiceLeaveStlmnt.DateStartDate = dateCalcFromDate;
                DataTable dtSalaryDtl = objBusinessLayerEndOfServiceLeaveStlmnt.ReadEmpSalaryDtl(objEntityLayerEndOfServiceLeaveStlmnt);
                clsEntityLayerEndOfServiceLeaveStlmnt objEntityEndSrvLveStlmntLocal = new clsEntityLayerEndOfServiceLeaveStlmnt();
                decimal deciPrevMonSalary = 0, deciBasicPay = 0, deciEmpPaymentDeduction = 0, deciDeduction = 0, deciOverTimeAddition = 0, deciAllowance = 0, deciDeductionTotPayPercentage = 0, deciDeductionBasicPayPercentage = 0,
                deciOtherManualAddAmnt=0,deciOtherManualDeductAmnt=0;
                decimal intGratuityDays = 0;
                if (dtSalaryDtl.Rows.Count > 0)
                {
                    for (int intRowCount = 0; intRowCount < dtSalaryDtl.Rows.Count; intRowCount++)
                    {
                        if (dtSalaryDtl.Rows[intRowCount]["TYPE"].ToString() == "BASIC_PAY" && dtSalaryDtl.Rows[intRowCount]["AMOUNT"].ToString() != "")
                        {
                            deciBasicPay = Convert.ToDecimal(dtSalaryDtl.Rows[intRowCount]["AMOUNT"]);
                        }
                        else if (dtSalaryDtl.Rows[intRowCount]["TYPE"].ToString() == "DEDUCTION" && dtSalaryDtl.Rows[intRowCount]["AMOUNT"].ToString() != "")
                        {
                            deciEmpPaymentDeduction = Convert.ToDecimal(dtSalaryDtl.Rows[intRowCount]["AMOUNT"]);
                        }
                        else if (dtSalaryDtl.Rows[intRowCount]["TYPE"].ToString() == "OVERTIME_AMT" && dtSalaryDtl.Rows[intRowCount]["AMOUNT"].ToString() != "")
                        {
                            deciOverTimeAddition = Convert.ToDecimal(dtSalaryDtl.Rows[intRowCount]["AMOUNT"]);
                        }
                        else if (dtSalaryDtl.Rows[intRowCount]["TYPE"].ToString() == "ARREAR_AMNT" && dtSalaryDtl.Rows[intRowCount]["AMOUNT"].ToString() != "")
                        {
                            deciPrevMonSalary = Convert.ToDecimal(dtSalaryDtl.Rows[intRowCount]["AMOUNT"]);
                        }
                        else if (dtSalaryDtl.Rows[intRowCount]["TYPE"].ToString() == "OTHER_ADD" && dtSalaryDtl.Rows[intRowCount]["AMOUNT"].ToString() != "")
                        {
                            deciOtherManualAddAmnt = Convert.ToDecimal(dtSalaryDtl.Rows[intRowCount]["AMOUNT"]);
                        }
                        else if (dtSalaryDtl.Rows[intRowCount]["TYPE"].ToString() == "OTHER_DEDUCT" && dtSalaryDtl.Rows[intRowCount]["AMOUNT"].ToString() != "")
                        {
                            deciOtherManualDeductAmnt = Convert.ToDecimal(dtSalaryDtl.Rows[intRowCount]["AMOUNT"]);
                        }
                    }
                }
                if (dtEmpSalaryGratuityLeaveDays.Rows.Count > 0)
                {
                    for (int intRowCount = 0; intRowCount < dtEmpSalaryGratuityLeaveDays.Rows.Count; intRowCount++)
                    {
                        if (dtEmpSalaryGratuityLeaveDays.Rows[intRowCount]["TYPE"].ToString() == "ELIGIBLE_GRATUITY_DAYS" && dtEmpSalaryGratuityLeaveDays.Rows[intRowCount]["NO_DAYS"].ToString() != "")
                        {
                            intGratuityDays = Convert.ToDecimal(dtEmpSalaryGratuityLeaveDays.Rows[intRowCount]["NO_DAYS"]);
                        }
                    }
                }
                //Check rejoined after leave settlement
                if (strPrevMnthFrom != "")
                {
                    DateTime dtPrevFrom = objCommon.textToDateTime(strPrevMnthFrom);
                    int preDays = DateTime.DaysInMonth(dtPrevFrom.Year, dtPrevFrom.Month);
                    DateTime dtPrevTo = new DateTime(dtPrevFrom.Year, dtPrevFrom.Month, preDays);
                    if (dateCorpSal <= dtPrevTo)
                    {
                        if (dateCorpSal > dtPrevFrom)
                        {
                            dtPrevFrom = dateCorpSal;
                        }
                        prevSal = MonthSalaryArr(intEmployeeID.ToString(), dtPrevFrom, dtPrevTo, deciBasicPay.ToString(), dtEmpSalaryAllowance, dtEmpSalaryDeduction, BasicPayStatus, 0, intCorpID.ToString(), intOrgID.ToString(), IndividualRound, ZeroWorkFixed, LsholiSts, LSoffSts);
                        objEndSrvStlmntLocal.strPrevMnthRejoin = strPrevMnthFrom;
                        objEndSrvStlmntLocal.PrevMnthArrAmt = prevSal;
                    }
                }
                //Arrear from daily attendance sheet table 
                DataTable dtArrearDailyAtt = objBuss.ReadArrearFromAtt(objEnt);
                if (dtArrearDailyAtt.Rows.Count > 0 && dtArrearDailyAtt.Rows[0]["SUM_ARREAR"].ToString() != "")
                {
                    prevSal += Convert.ToDecimal(dtArrearDailyAtt.Rows[0]["SUM_ARREAR"].ToString());
                    objEndSrvStlmntLocal.PrevMnthArrAmt = prevSal;
                }
                if (IndividualRound == "1")
                {
                    objEndSrvStlmntLocal.PrevMnthArrAmt = Math.Round(objEndSrvStlmntLocal.PrevMnthArrAmt, 0);
                }

                DataTable dtLeavSettlmentDate = objBusinessLayerEndOfServiceLeaveStlmnt.ReadLeavSettlmentDat(objEntityLayerEndOfServiceLeaveStlmnt);
                int Settledays1 = 0;
                int SettleMonth1 = 0;
                int SettleYear1 = 0;
                int FixedAllowance = 0;
                if (dtLeavSettlmentDate.Rows.Count > 0)
                {
                    if (dtLeavSettlmentDate.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString() != "")
                    {
                        DateTime SettlemtntDate = objCommon.textToDateTime(dtLeavSettlmentDate.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString());
                        SettleMonth1 = SettlemtntDate.Month;
                        SettleYear1 = SettlemtntDate.Year;
                        Settledays1 = SettlemtntDate.Day;
                    }
                    if (dtLeavSettlmentDate.Rows[0]["LEVSETLMT_FIXED_ALOWNC_STS"].ToString() != "")
                    {
                        FixedAllowance = Convert.ToInt32(dtLeavSettlmentDate.Rows[0]["LEVSETLMT_FIXED_ALOWNC_STS"].ToString());
                    }
                    if (dtLeavSettlmentDate.Rows[0]["LEVSETLMT_ADDITN_AMT"].ToString() != "")
                    {
                        StrAllowance = dtLeavSettlmentDate.Rows[0]["LEVSETLMT_ADDITN_AMT"].ToString();
                    }
                }



                DateTime ddate = dateDateofLeaving;
                int SettleMonth = ddate.Month;
                int SettleYear = ddate.Year;
                int SettleDay = ddate.Day;
                int WorkDays = DateTime.DaysInMonth(SettleYear, SettleMonth);
                int days = 0;
                decimal currntDay = 30;
                decimal TtlCnt = 0;
                //EVM-0024
                DateTime Date1 = new DateTime();
                DateTime Date2 = new DateTime();
                if (strLastRejoinDate != "")
                {
                    Date2 = new DateTime(SettleYear, SettleMonth, SettleDay);
                    Date1 = dateCalcFromDate;
                    currntDay = Convert.ToInt32((Date2 - Date1).TotalDays) + 1;
                }
                //End

                DateTime dateFrom = new DateTime(ddate.Year, ddate.Month, Settledays1 + 1);
                if (Settledays1 + 1 >= SettleDay)
                {
                }
                else
                {
                    objEntityEndSrvLveStlmntLocal.EmployeeID = Convert.ToInt32(intEmployeeID);
                    objEntityEndSrvLveStlmntLocal.DateStartDate = dateCalcFromDate;
                    objEntityEndSrvLveStlmntLocal.DateEndDate = ddate;
                    decimal cnt = 0;
                    DataTable dtLeaveDate = objBusinessLayerEndOfServiceLeaveStlmnt.ReadLeaveDate(objEntityEndSrvLveStlmntLocal);
                    string[] stringArray = new string[50];
                    int CurrArray = 0;


                    cls_Business_Monthly_Salary_Process objBuss2 = new cls_Business_Monthly_Salary_Process();
                    cls_Entity_Monthly_Salary_Process objEnt2 = new cls_Entity_Monthly_Salary_Process();
                    objEnt2.Employee = objEntityEndSrvLveStlmntLocal.EmployeeID;
                    objEnt2.DateStartDate = objEntityEndSrvLveStlmntLocal.DateEndDate.AddDays(1);
                    objEnt2.DateEndDate = new DateTime(objEntityEndSrvLveStlmntLocal.DateEndDate.Year, 12, 31);
                    objEnt2.CorpOffice = intCorpID;
                    objEnt2.Orgid = intOrgID;
                    DataTable dtLeaveDateFuture = new DataTable();
                    if (objEnt2.DateStartDate.Year == objEnt2.DateEndDate.Year)
                    {
                        dtLeaveDateFuture = objBuss2.ReadLeaveDate(objEnt2);
                    }


                    for (int lcnt = 0; lcnt < dtLeaveDate.Rows.Count; lcnt++)
                    {

                        int HoliPaidSts = Convert.ToInt32(dtLeaveDate.Rows[lcnt]["LEAVETYP_HOLIDAY_PAID_STS"].ToString());
                        int OffPaidSts = Convert.ToInt32(dtLeaveDate.Rows[lcnt]["LEAVETYP_OFFDAY_PAID_STS"].ToString());

                        dutyOf objDuty = new dutyOf();
                        int OffCount = 0;


                        cnt = 0;
                        decimal dedHalfLeave = 0;
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


                            if (LvFrmYear == SettleYear && LvFrmMonth == SettleMonth && LvToYear == SettleYear && LvToMonth == SettleMonth)
                            {

                                if (LfrmDt < dateCalcFromDate)
                                {
                                    LfrmDt = dateCalcFromDate;
                                }
                                else
                                {
                                    if (dtLeaveDate.Rows[lcnt]["LEAVE_FROM_SCTN"].ToString() != "1")
                                    {
                                        dedHalfLeave = dedHalfLeave + (decimal)0.5;
                                    }
                                }
                                if (LToDt > ddate)
                                {
                                    LToDt = ddate;
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
                            else if (LvToYear == SettleYear && LvToMonth == SettleMonth)
                            {
                                LfrmDt = dateCalcFromDate;
                                if (LToDt > ddate)
                                {
                                    LToDt = ddate;
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
                            else if (LvFrmYear == SettleYear && LvFrmMonth == SettleMonth)
                            {

                                if (LfrmDt < dateCalcFromDate)
                                {
                                    LfrmDt = dateCalcFromDate;
                                }
                                else
                                {
                                    if (dtLeaveDate.Rows[lcnt]["LEAVE_FROM_SCTN"].ToString() != "1")
                                    {
                                        dedHalfLeave = dedHalfLeave + (decimal)0.5;
                                    }
                                }
                                LToDt = ddate;

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
                                cnt = ddate.Day - dateCalcFromDate.Day + 1;
                                if (dtLeaveDate.Rows[lcnt]["LEAVE_FROM_SCTN"].ToString() != "1")
                                {
                                    cnt = cnt - (decimal)0.5;
                                }
                                if (dtLeaveDate.Rows[lcnt]["LEAVE_TO_SCTN"].ToString() != "1")
                                {
                                    cnt = cnt - (decimal)0.5;
                                }

                                DateTime datenow, enddate;
                                datenow = dateCalcFromDate;
                                enddate = ddate;



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
                            if (LvFrmYear == SettleYear && LvFrmMonth == SettleMonth)
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
                        TtlCnt += cnt;
                        objEntityEndSrvLveStlmntLocal.LvCnt = Convert.ToInt32(TtlCnt);
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
                                TtlCnt += decTotLeaveCount;
                            }
                            else
                            {
                                TtlCnt += decBalCount;
                            }
                        }
                    }

                }

                int flgFix = 0;
                if (dtFinal != DateTime.MinValue && MonthDiff == 0)
                {
                    DateTime dtfbd = new DateTime(dtFinal.Year, dtFinal.Month, 1);
                    DateTime dtfhbd = new DateTime(ddate.Year, ddate.Month, 1);
                    if (dtfhbd <= dtfbd)
                    {
                        flgFix = 1;
                    }
                }



                if (dtEmpSalaryAllowance.Rows.Count > 0)
                {//SLRYDEDTN_AMNT_PERCTGE_CHCK

                    if (currntDay > TtlCnt || ZeroWorkFixed == 1)
                    {

                        for (int intRowCount = 0; intRowCount < dtEmpSalaryAllowance.Rows.Count; intRowCount++)
                        {
                            decimal DecAlwnceAmt = 0;

                            if (dtEmpSalaryAllowance.Rows[intRowCount]["PAYRL_TYPE_STS"].ToString() == "0")
                            {

                                if (flgFix == 0)
                                {
                                    DecAlwnceAmt = Convert.ToDecimal(dtEmpSalaryAllowance.Rows[intRowCount]["SLRYALLCE_AMOUNT"].ToString());
                                }
                                else if (flgFix == 1)
                                {
                                    if (strLastRejoinDate != "")
                                    {
                                        DateTime dtRJoin = objCommon.textToDateTime(strLastRejoinDate);
                                        string strRjoin = dtRJoin.ToString("MM");
                                        if (LeaveToDate != DateTime.MinValue)
                                        {
                                            string strLeave = LeaveToDate.ToString("MM");
                                            if (Convert.ToInt32(strRjoin) > Convert.ToInt32(strLeave))
                                            {
                                                if (StrAllowance != "")
                                                {
                                                    DecAlwnceAmt = Convert.ToDecimal(DecAlwnceAmt - Convert.ToDecimal(StrAllowance));
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                DecAlwnceAmt = Convert.ToDecimal(dtEmpSalaryAllowance.Rows[intRowCount]["SLRYALLCE_AMOUNT"].ToString());
                                decimal amtOneDay = DecAlwnceAmt / WorkDays;
                                decimal amtWorkDay = amtOneDay * (currntDay - TtlCnt);
                                DecAlwnceAmt = amtWorkDay;

                            }
                            if (strAddDtls == "")
                            {
                                strAddDtls += dtEmpSalaryAllowance.Rows[intRowCount]["PGALLCE_ID"].ToString() + "-" + dtEmpSalaryAllowance.Rows[intRowCount]["PYGRD_ID"].ToString() + "-" + dtEmpSalaryAllowance.Rows[intRowCount]["SLRYALLCE_AMOUNT"].ToString() + "-" + DecAlwnceAmt.ToString() + "-0";
                            }
                            else
                            {
                                strAddDtls += "%" + dtEmpSalaryAllowance.Rows[intRowCount]["PGALLCE_ID"].ToString() + "-" + dtEmpSalaryAllowance.Rows[intRowCount]["PYGRD_ID"].ToString() + "-" + dtEmpSalaryAllowance.Rows[intRowCount]["SLRYALLCE_AMOUNT"].ToString() + "-" + DecAlwnceAmt.ToString() + "-0";
                            }
                            deciAllowance += DecAlwnceAmt;

                        }
                    }

                }
                decimal deciBasicpayDeduction = 0, deciTotalPayDedution = 0, deciBasicPaywithAllowance = 0;
                if (dtEmpSalaryDeduction.Rows.Count > 0)
                {//SLRYDEDTN_AMNT_PERCTGE_CHCK

                    if (currntDay > TtlCnt || ZeroWorkFixed == 1)
                    {

                        for (int intRowCount = 0; intRowCount < dtEmpSalaryDeduction.Rows.Count; intRowCount++)
                        {
                            decimal DecDeduction = 0, DecDeductionbasicPay = 0, DecDeductionTotlPay = 0, DecCurrAmnt = 0;

                            if (dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString() == "0")
                            {
                                //not percentage
                                if (dtEmpSalaryDeduction.Rows[intRowCount]["PAYRL_TYPE_STS"].ToString() == "0")
                                {

                                    if (flgFix == 0)
                                    {
                                        DecDeduction = Convert.ToDecimal(dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_AMOUNT"]);
                                    }
                                }
                                else
                                {
                                    DecDeduction = Convert.ToDecimal(dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_AMOUNT"]);
                                    decimal amtOneDay = DecDeduction / WorkDays;
                                    decimal amtWorkDay = amtOneDay * (currntDay - TtlCnt);
                                    DecDeduction = amtWorkDay;
                                }
                                DecCurrAmnt = DecDeduction;
                                deciDeduction += DecDeduction;
                            }
                            else if (dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString() == "1")
                            {
                                //percentage
                                if (dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_BASIC_OR_TOTAL_AMNT"].ToString() == "0")
                                {
                                    //deduction percentage on Basic Pay
                                    if (dtEmpSalaryDeduction.Rows[intRowCount]["PAYRL_TYPE_STS"].ToString() == "0")
                                    {
                                        if (flgFix == 0)
                                        {
                                            DecDeductionbasicPay = Convert.ToDecimal(dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_PERCNTGE"]);
                                            DecDeductionbasicPay = deciBasicPay * (DecDeductionbasicPay / 100);
                                        }
                                    }
                                    else
                                    {
                                        DecDeductionbasicPay = Convert.ToDecimal(dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_PERCNTGE"]);
                                        DecDeductionbasicPay = deciBasicPay * (DecDeductionbasicPay / 100);

                                        decimal amtOneDay = DecDeductionbasicPay / WorkDays;
                                        decimal amtWorkDay = amtOneDay * (currntDay - TtlCnt);
                                        DecDeductionbasicPay = amtWorkDay;

                                    }
                                    DecCurrAmnt = DecDeductionbasicPay;
                                }
                                else if (dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_BASIC_OR_TOTAL_AMNT"].ToString() == "1")
                                {
                                    //deduction percentage on Total Amnt
                                    if (dtEmpSalaryDeduction.Rows[intRowCount]["PAYRL_TYPE_STS"].ToString() == "0")
                                    {
                                        if (flgFix == 0)
                                        {
                                            DecDeductionTotlPay = Convert.ToDecimal(dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_PERCNTGE"]);
                                            DecDeductionTotlPay = (deciBasicPay + deciAllowance) * (DecDeductionTotlPay / 100);
                                        }
                                    }
                                    else
                                    {
                                        DecDeductionTotlPay = Convert.ToDecimal(dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_PERCNTGE"]);
                                        DecDeductionTotlPay = (deciBasicPay + deciAllowance) * (DecDeductionTotlPay / 100);
                                        decimal amtOneDay = DecDeductionTotlPay / WorkDays;
                                        decimal amtWorkDay = amtOneDay * (currntDay - TtlCnt);
                                        DecDeductionTotlPay = amtWorkDay;
                                    }
                                    DecCurrAmnt = DecDeductionTotlPay;
                                }


                            }

                            if (strDedDtls == "")
                            {
                                strDedDtls += dtEmpSalaryDeduction.Rows[intRowCount]["PGDEDTN_ID"].ToString() + "-" + dtEmpSalaryDeduction.Rows[intRowCount]["PYGRD_ID"].ToString() + "-" + dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_AMOUNT"].ToString() + "-" + dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_PERCNTGE"].ToString() + "-" + dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString() + "-" + dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_BASIC_OR_TOTAL_AMNT"].ToString() + "-" + DecCurrAmnt.ToString() + "-0";
                            }
                            else
                            {
                                strDedDtls += "%" + dtEmpSalaryDeduction.Rows[intRowCount]["PGDEDTN_ID"].ToString() + "-" + dtEmpSalaryDeduction.Rows[intRowCount]["PYGRD_ID"].ToString() + "-" + dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_AMOUNT"].ToString() + "-" + dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_PERCNTGE"].ToString() + "-" + dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString() + "-" + dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_BASIC_OR_TOTAL_AMNT"].ToString() + "-" + DecCurrAmnt.ToString() + "-0";
                            }


                            deciBasicpayDeduction += DecDeductionbasicPay;
                            deciTotalPayDedution += DecDeductionTotlPay;
                        }
                    }
                }
                objEndSrvStlmntLocal.strLastRejoinDate = strLastRejoinDateDisp;
                objEndSrvStlmntLocal.deciDeduction = deciDeduction + deciBasicpayDeduction + deciTotalPayDedution;


                decimal RemainDays = 30;
                DateTime Nowdate = dateDateofLeaving;
                int LstSettleMonth = Nowdate.Month;
                int LstSettleYear = Nowdate.Year;
                int LstSettleDay = Nowdate.Day;
                DateTime Date1New = new DateTime();
                DateTime Date2New = new DateTime();
                if (strLastRejoinDate != "")
                {
                    Date2New = new DateTime(LstSettleYear, LstSettleMonth, LstSettleDay);
                    Date1New = dateCalcFromDate;
                    RemainDays = Convert.ToInt32((Date2New - Date1New).TotalDays) + 1;
                    if (BasicPayStatus == 1)
                    {
                        RemainDays = RemainDays - TtlCnt;
                    }
                    else
                    {
                        if (flgFix == 0)
                        {
                            RemainDays = WorkDays;
                        }
                        else
                        {
                            RemainDays = 0;
                        }

                    }
                }

                InsLeaveType(intCorpID, intOrgID, intEmployeeID, Date2);

                //leave salary deciOpenLeaveDays  deciLeaveSalaryDays
                decimal RemainLeav = 0;
                DateTime DateL1 = new DateTime();
                DateTime DateL2 = new DateTime();
                if (strLastRejoinDate != "")
                {
                    DateL1 = objCommon.textToDateTime(strLastRejoinDate);
                }
                DataTable dtLeavSettldL = objBusinessLeavSettlmt.ReadLastSettldDt(objEntityLeavSettlmt);
                DateTime dtLastSettle = new DateTime();
                if (dtLeavSettldL.Rows.Count > 0 && dtLeavSettldL.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString() != "")
                {
                    dtLastSettle = objCommon.textToDateTime(dtLeavSettldL.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString());
                }
                DataTable dtLeavMonth = objBusinessLeavSettlmt.ReadMonthlyLastDate(objEntityLeavSettlmt);
                if (dtLastSettle != DateTime.MinValue || DateL1 != DateTime.MinValue)
                {
                    if (dtLastSettle > DateL1)
                    {
                        DateL1 = dtLastSettle;
                    }
                }
                if (dtFinal1 != DateTime.MinValue)
                {
                    if (dtFinal1 > DateL1)
                    {
                        DateL1 = dtFinal1;
                    }
                }
                DateL2 = dateDateofLeaving;

                
                if(OnProbationSts==0){

                //Start:-Read opening balance paid leave counts
                decimal decOpenLeaveCntPrev = 0, decOpenLeaveAmntPrev = 0;
                int OpenYear = 0;
                DataTable dtOpenLeaveinfo = objBusinessLeavSettlmt.ReadOpeningLeaveInfo(objEntityLeavSettlmt);
                if (dtOpenLeaveinfo.Rows.Count > 0)
                {
                    decimal deciSalaryPerDayd = 0;
               //  deciSalaryPerDayd = deciBasicPay / 30;
                    deciSalaryPerDayd = deciBasicPay / 30;
                    
                   //decOpenLeaveCntPrev = Math.Round(Convert.ToDecimal(dtOpenLeaveinfo.Rows[0]["BALANCE_NUMLEAVE"].ToString()));
                 //   string strOpenLeaveCntPrev = String.Format(format, Convert.ToDecimal(dtOpenLeaveinfo.Rows[0]["BALANCE_NUMLEAVE"].ToString()));
                    string strOpenLeaveCntPrev = dtOpenLeaveinfo.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                    decOpenLeaveCntPrev = Convert.ToDecimal(strOpenLeaveCntPrev);
                    decOpenLeaveAmntPrev = decOpenLeaveCntPrev * deciSalaryPerDayd;
                    OpenYear = Convert.ToInt32(dtOpenLeaveinfo.Rows[0]["OPUSLETYP_YEAR"].ToString());
                }

                //--deciOpenLeaveDays  
                objEndSrvStlmntLocal.deciOpenLeaveDays = decOpenLeaveCntPrev;
               

                objEndSrvStlmntLocal.deciOpenLeaveSalary = decOpenLeaveAmntPrev;
                //End:-Read opening balance paid leave counts

                DateTime dtJoinDate = objCommon.textToDateTime(strUsrJoindate);
                DateTime dtFrom = DateL1;
                DateTime dtTo = DateL2;
                int FromYear = dtFrom.Year;
                int ToYear = dtTo.Year;
                int CurrYear = dtCurrDate.Year;
                decimal PrevYearBalLeave = 0, CurrYearBalLeave = 0, NextYearBalLeave = 0;
                decimal CurrYearDays = 0, NextYearDays = 0, JoinDateDays = 365;
                decimal LeaveEligbleDays = 0;
                string SetlmtnRemainUpd = "";
                //LeaveEligbleDays += decOpenLeaveCntPrev;
                if (dtJoinDate.Year == dtFrom.Year)
                {
                    JoinDateDays = CalculateDays(dtJoinDate, new DateTime(dtJoinDate.Year, 12, 31));
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
                objEntityLeavSettlmt.Year = DateL2.Year;
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
               // RemainLeav = Math.Round(LeaveEligbleDays); //open 
                //string strRemainLeav = String.Format(format, LeaveEligbleDays);
                string strRemainLeav = LeaveEligbleDays.ToString("0.00");
                RemainLeav = Convert.ToDecimal(strRemainLeav);
                objEndSrvStlmntLocal.strLeaveDaysDeduct = SetlmtnRemainUpd;

                objEndSrvStlmntLocal.deciLeaveSalaryDays = RemainLeav;
                objEndSrvStlmntLocal.deciLeaveSalaryDays = RemainLeav + decOpenLeaveCntPrev;
                objEndSrvStlmntLocal.deciLeaveSalaryDays = Math.Round((RemainLeav + decOpenLeaveCntPrev), 0);

                }

                decimal deciSalaryPerDay = 0;
          //    deciSalaryPerDay = deciBasicPay / 30;
                deciSalaryPerDay = deciBasicPay / WorkDays;
                decimal salperday = deciBasicPay / 30;
                decimal deciEmployeeBasicPay = 0;

                deciEmployeeBasicPay = deciBasicPay;

             //   deciBasicPay = (deciBasicPay / WorkDays) * RemainDays;

                deciBasicPay = deciSalaryPerDay * RemainDays;




                objEndSrvStlmntLocal.deciBasicPay = deciBasicPay;
                objEndSrvStlmntLocal.deciAddition = deciAllowance;
                objEndSrvStlmntLocal.deciPrevMonSalary = deciPrevMonSalary;
                deciBasicPaywithAllowance = deciBasicPay + deciAllowance;

                objEndSrvStlmntLocal.strMessDedctn = StrMessDedctn;
                objEndSrvStlmntLocal.strSettlmentDate = dateCurrentDate.ToString();


                //Start:-Gratuity Calculation
                DateTime dateJoin = objCommon.textToDateTime(strUsrJoindate);
                int workDays = Convert.ToInt32((dateDateofLeaving - dateJoin).TotalDays) + 1;
                if (dateJoin < dtCorpGratityDate && intGrtFromJoinSts == 0)
                {
                    dateJoin = dtCorpGratityDate;
                }
                int totDays = Convert.ToInt32((dateDateofLeaving - dateJoin).TotalDays) + 1;
                if (workDays >= 365)
                {              
                    objEndSrvStlmntLocal.intGratuityDays = Math.Round((intGratuityDays / 365) * totDays,roundNum);
                    //objEndSrvStlmntLocal.intGratuityDays = (intGratuityDays / 365) * totDays;
                    objEndSrvStlmntLocal.deciGratuityAmt = objEndSrvStlmntLocal.intGratuityDays * salperday;
                }
                //End:-Gratuity Calculation

                //--deciLeaveSalaryDays


               

                objEndSrvStlmntLocal.deciLeaveSalAmt = (objEndSrvStlmntLocal.deciLeaveSalaryDays * salperday);
                objEndSrvStlmntLocal.deciTotalPay = objEndSrvStlmntLocal.deciAddition - objEndSrvStlmntLocal.deciDeduction;
                //EVM-0012
                //Modification on OT calculation  5440
                //per hour salary
                deciOverTimeAddition = ((deciEmployeeBasicPay / WorkDays) / 8) * deciOverTimeAddition;



                objEndSrvStlmntLocal.deciOverTimeAddition = deciOverTimeAddition;
                objEndSrvStlmntLocal.deciPaymentDeduction = deciEmpPaymentDeduction;
                objEndSrvStlmntLocal.deciTotalPay += deciOverTimeAddition;
                objEndSrvStlmntLocal.deciTotalPay -= deciEmpPaymentDeduction;
                objEndSrvStlmntLocal.deciOtherManualAddAmnt = deciOtherManualAddAmnt;
                objEndSrvStlmntLocal.deciOtherManualDeductAmnt = deciOtherManualDeductAmnt;

                //Math.Round(objEndSrvStlmntLocal.deciBasicPay, 0);

                objEndSrvStlmntLocal.deciCurrentMonSalary = objEndSrvStlmntLocal.deciBasicPay + objEndSrvStlmntLocal.deciTotalPay - MessDedctn;

                //Previous month salary calculation
                if (MonthDiff == 1)
                {
                    DateTime dtCurrFromDate = new DateTime(dateCalcFromDate.Year, dateCalcFromDate.Month, 1);
                    DateTime dtPrevToDate = dtCurrFromDate.AddDays(-1);
                    DateTime dtprevFromDate = new DateTime(dtPrevToDate.Year, dtPrevToDate.Month, 1);
                    if (dtprevFromDate < dtRejoinDate)
                    {
                        dtprevFromDate = dtRejoinDate;
                    }



                    objEntityLayerEndOfServiceLeaveStlmnt.DateOfLeaving = dtPrevToDate;
                    objEntityLayerEndOfServiceLeaveStlmnt.DateStartDate = dtprevFromDate;
                    objEntityLayerEndOfServiceLeaveStlmnt.ConfirmStatus = 0;
                    DataTable dtMessDedctnPre = objBusinessLayerEndOfServiceLeaveStlmnt.ReadMessDeductionByID(objEntityLayerEndOfServiceLeaveStlmnt);
                    decimal PrevMessDedctn = 0;
                    if (dtMessDedctnPre.Rows.Count > 0)
                    {
                        if (dtMessDedctnPre.Rows[0]["MESS_DEDCTN"].ToString() != "")
                        {
                            PrevMessDedctn = Convert.ToDecimal(dtMessDedctnPre.Rows[0]["MESS_DEDCTN"].ToString());
                        }
                    }





                    objEntityLayerEndOfServiceLeaveStlmnt.Date = dtPrevToDate;
                    objEntityLayerEndOfServiceLeaveStlmnt.DateStartDate = dtprevFromDate;


                    dtSalaryDtl = objBusinessLayerEndOfServiceLeaveStlmnt.ReadEmpSalaryDtl(objEntityLayerEndOfServiceLeaveStlmnt);
                    deciPrevMonSalary = 0; deciBasicPay = 0; deciEmpPaymentDeduction = 0; deciDeduction = 0; deciOverTimeAddition = 0;
                    deciAllowance = 0; deciDeductionTotPayPercentage = 0; deciDeductionBasicPayPercentage = 0; deciOtherManualAddAmnt = 0; deciOtherManualDeductAmnt = 0;

                    if (dtSalaryDtl.Rows.Count > 0)
                    {
                        for (int intRowCount = 0; intRowCount < dtSalaryDtl.Rows.Count; intRowCount++)
                        {
                            if (dtSalaryDtl.Rows[intRowCount]["TYPE"].ToString() == "BASIC_PAY" && dtSalaryDtl.Rows[intRowCount]["AMOUNT"].ToString() != "")
                            {
                                deciBasicPay = Convert.ToDecimal(dtSalaryDtl.Rows[intRowCount]["AMOUNT"]);
                            }
                            else if (dtSalaryDtl.Rows[intRowCount]["TYPE"].ToString() == "DEDUCTION" && dtSalaryDtl.Rows[intRowCount]["AMOUNT"].ToString() != "")
                            {
                                deciEmpPaymentDeduction = Convert.ToDecimal(dtSalaryDtl.Rows[intRowCount]["AMOUNT"]);
                            }
                            else if (dtSalaryDtl.Rows[intRowCount]["TYPE"].ToString() == "OVERTIME_AMT" && dtSalaryDtl.Rows[intRowCount]["AMOUNT"].ToString() != "")
                            {
                                deciOverTimeAddition = Convert.ToDecimal(dtSalaryDtl.Rows[intRowCount]["AMOUNT"]);
                            }
                            else if (dtSalaryDtl.Rows[intRowCount]["TYPE"].ToString() == "ARREAR_AMNT" && dtSalaryDtl.Rows[intRowCount]["AMOUNT"].ToString() != "")
                            {
                                deciPrevMonSalary = Convert.ToDecimal(dtSalaryDtl.Rows[intRowCount]["AMOUNT"]);
                            }
                            else if (dtSalaryDtl.Rows[intRowCount]["TYPE"].ToString() == "OTHER_ADD" && dtSalaryDtl.Rows[intRowCount]["AMOUNT"].ToString() != "")
                            {
                                deciOtherManualAddAmnt = Convert.ToDecimal(dtSalaryDtl.Rows[intRowCount]["AMOUNT"]);
                                objEndSrvStlmntLocal.deciPrevOtherManualAddAmnt = deciOtherManualAddAmnt;
                            }
                            else if (dtSalaryDtl.Rows[intRowCount]["TYPE"].ToString() == "OTHER_DEDUCT" && dtSalaryDtl.Rows[intRowCount]["AMOUNT"].ToString() != "")
                            {
                                deciOtherManualDeductAmnt = Convert.ToDecimal(dtSalaryDtl.Rows[intRowCount]["AMOUNT"]);
                                objEndSrvStlmntLocal.deciPrevOtherManualDeductAmnt = deciOtherManualDeductAmnt;

                            }
                        }
                    }

                    deciEmployeeBasicPay = deciBasicPay;


                    ddate = dtPrevToDate;
                    SettleMonth = ddate.Month;
                    SettleYear = ddate.Year;
                    SettleDay = ddate.Day;
                    WorkDays = DateTime.DaysInMonth(SettleYear, SettleMonth);
                    days = 0;
                    currntDay = 30;
                    TtlCnt = 0;
                    //EVM-0024
                    if (strLastRejoinDate != "")
                    {
                        Date2 = new DateTime(SettleYear, SettleMonth, SettleDay);
                        Date1 = dtprevFromDate;
                        currntDay = Convert.ToInt32((Date2 - Date1).TotalDays) + 1;
                    }
                    //End

                    dateFrom = new DateTime(ddate.Year, ddate.Month, Settledays1 + 1);
                    if (Settledays1 + 1 >= SettleDay)
                    {
                    }
                    else
                    {
                        objEntityEndSrvLveStlmntLocal.EmployeeID = Convert.ToInt32(intEmployeeID);
                        objEntityEndSrvLveStlmntLocal.DateStartDate = dtprevFromDate;
                        objEntityEndSrvLveStlmntLocal.DateEndDate = ddate;
                        decimal cnt = 0;

                        string[] stringArray = new string[50];
                        int CurrArray = 0;

                        DataTable dtLeaveDate = objBusinessLayerEndOfServiceLeaveStlmnt.ReadLeaveDate(objEntityEndSrvLveStlmntLocal);


                        cls_Business_Monthly_Salary_Process objBuss2 = new cls_Business_Monthly_Salary_Process();
                        cls_Entity_Monthly_Salary_Process objEnt2 = new cls_Entity_Monthly_Salary_Process();
                        objEnt2.Employee = objEntityEndSrvLveStlmntLocal.EmployeeID;
                        objEnt2.DateStartDate = objEntityEndSrvLveStlmntLocal.DateEndDate.AddDays(1);
                        objEnt2.DateEndDate = new DateTime(ddate.Year, 12, 31);
                        objEnt2.CorpOffice = intCorpID;
                        objEnt2.Orgid = intOrgID;
                        DataTable dtLeaveDateFuture = new DataTable();
                        if (objEnt2.DateStartDate.Year == objEnt2.DateEndDate.Year)
                        {
                            dtLeaveDateFuture = objBuss2.ReadLeaveDate(objEnt2);
                        }



                        for (int lcnt = 0; lcnt < dtLeaveDate.Rows.Count; lcnt++)
                        {

                            int HoliPaidSts = Convert.ToInt32(dtLeaveDate.Rows[lcnt]["LEAVETYP_HOLIDAY_PAID_STS"].ToString());
                            int OffPaidSts = Convert.ToInt32(dtLeaveDate.Rows[lcnt]["LEAVETYP_OFFDAY_PAID_STS"].ToString());


                            dutyOf objDuty = new dutyOf();
                            int OffCount = 0;

                            DateTime LfrmDt = DateTime.MinValue;
                            DateTime LToDt = DateTime.MinValue;
                            decimal dedHalfLeave = 0;
                            cnt = 0;
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


                                if (LvFrmYear == SettleYear && LvFrmMonth == SettleMonth && LvToYear == SettleYear && LvToMonth == SettleMonth)
                                {


                                    if (LfrmDt < dtprevFromDate)
                                    {
                                        LfrmDt = dtprevFromDate;
                                    }
                                    else
                                    {
                                        if (dtLeaveDate.Rows[lcnt]["LEAVE_FROM_SCTN"].ToString() != "1")
                                        {
                                            dedHalfLeave = dedHalfLeave + (decimal)0.5;
                                        }
                                    }
                                    if (LToDt > ddate)
                                    {
                                        LToDt = ddate;
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
                                else if (LvToYear == SettleYear && LvToMonth == SettleMonth)
                                {
                                    LfrmDt = dtprevFromDate;
                                    if (LToDt > ddate)
                                    {
                                        LToDt = ddate;
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
                                else if (LvFrmYear == SettleYear && LvFrmMonth == SettleMonth)
                                {
                                    if (LfrmDt < dtprevFromDate)
                                    {
                                        LfrmDt = dtprevFromDate;
                                    }
                                    else
                                    {
                                        if (dtLeaveDate.Rows[lcnt]["LEAVE_FROM_SCTN"].ToString() != "1")
                                        {
                                            dedHalfLeave = dedHalfLeave + (decimal)0.5;
                                        }
                                    }
                                    LToDt = ddate;

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
                                    cnt = ddate.Day - dtprevFromDate.Day + 1;
                                    if (dtLeaveDate.Rows[lcnt]["LEAVE_FROM_SCTN"].ToString() != "1")
                                    {
                                        cnt = cnt - (decimal)0.5;
                                    }
                                    if (dtLeaveDate.Rows[lcnt]["LEAVE_TO_SCTN"].ToString() != "1")
                                    {
                                        cnt = cnt - (decimal)0.5;
                                    }

                                    DateTime datenow, enddate;
                                    datenow = dtprevFromDate;
                                    enddate = ddate;


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
                                if (LvFrmYear == SettleYear && LvFrmMonth == SettleMonth)
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
                            TtlCnt += cnt;
                            //objEntityEndSrvLveStlmntLocal.LvCnt = Convert.ToInt32(TtlCnt);
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
                                    TtlCnt += decTotLeaveCount;
                                }
                                else
                                {
                                    TtlCnt += decBalCount;
                                }
                            }
                        }
                    }

                    flgFix = 0;
                    if (dtFinal != DateTime.MinValue)
                    {
                        DateTime dtfbd = new DateTime(dtFinal.Year, dtFinal.Month, 1);
                        DateTime dtfhbd = new DateTime(ddate.Year, ddate.Month, 1);
                        if (dtfhbd <= dtfbd)
                        {
                            flgFix = 1;
                        }
                    }


                    if (dtEmpSalaryAllowance.Rows.Count > 0)
                    {//SLRYDEDTN_AMNT_PERCTGE_CHCK

                        if (currntDay > TtlCnt || ZeroWorkFixed == 1)
                        {

                            for (int intRowCount = 0; intRowCount < dtEmpSalaryAllowance.Rows.Count; intRowCount++)
                            {
                                decimal DecAlwnceAmt = 0;
                                if (dtEmpSalaryAllowance.Rows[intRowCount]["PAYRL_TYPE_STS"].ToString() == "0")
                                {
                                    if (flgFix == 0)
                                    {
                                        DecAlwnceAmt = Convert.ToDecimal(dtEmpSalaryAllowance.Rows[intRowCount]["SLRYALLCE_AMOUNT"].ToString());
                                    }
                                    else if (flgFix == 1)
                                    {
                                        if (strLastRejoinDate != "")
                                        {
                                            DateTime dtRJoin = objCommon.textToDateTime(strLastRejoinDate);
                                            string strRjoin = dtRJoin.ToString("MM");
                                            if (LeaveToDate != DateTime.MinValue)
                                            {
                                                string strLeave = LeaveToDate.ToString("MM");
                                                if (Convert.ToInt32(strRjoin) > Convert.ToInt32(strLeave))
                                                {
                                                    if (StrAllowance != "")
                                                    {
                                                        DecAlwnceAmt = Convert.ToDecimal(DecAlwnceAmt - Convert.ToDecimal(StrAllowance));
                                                    }
                                                }
                                            }
                                        }
                                    }


                                }
                                else
                                {
                                    DecAlwnceAmt = Convert.ToDecimal(dtEmpSalaryAllowance.Rows[intRowCount]["SLRYALLCE_AMOUNT"].ToString());
                                    decimal amtOneDay = DecAlwnceAmt / WorkDays;
                                    decimal amtWorkDay = amtOneDay * (currntDay - TtlCnt);
                                    DecAlwnceAmt = amtWorkDay;

                                }

                                if (strAddDtlsPrev == "")
                                {
                                    strAddDtlsPrev += dtEmpSalaryAllowance.Rows[intRowCount]["PGALLCE_ID"].ToString() + "-" + dtEmpSalaryAllowance.Rows[intRowCount]["PYGRD_ID"].ToString() + "-" + dtEmpSalaryAllowance.Rows[intRowCount]["SLRYALLCE_AMOUNT"].ToString() + "-" + DecAlwnceAmt.ToString() + "-1";
                                }
                                else
                                {
                                    strAddDtlsPrev += "%" + dtEmpSalaryAllowance.Rows[intRowCount]["PGALLCE_ID"].ToString() + "-" + dtEmpSalaryAllowance.Rows[intRowCount]["PYGRD_ID"].ToString() + "-" + dtEmpSalaryAllowance.Rows[intRowCount]["SLRYALLCE_AMOUNT"].ToString() + "-" + DecAlwnceAmt.ToString() + "-1";
                                }



                                deciAllowance += DecAlwnceAmt;

                            }
                        }
                    }
                    deciBasicpayDeduction = 0; deciTotalPayDedution = 0; deciBasicPaywithAllowance = 0;
                    if (dtEmpSalaryDeduction.Rows.Count > 0)
                    {//SLRYDEDTN_AMNT_PERCTGE_CHCK
                        if (currntDay > TtlCnt || ZeroWorkFixed == 1)
                        {

                            for (int intRowCount = 0; intRowCount < dtEmpSalaryDeduction.Rows.Count; intRowCount++)
                            {
                                decimal DecDeduction = 0, DecDeductionbasicPay = 0, DecDeductionTotlPay = 0, DecCurrAmnt = 0;
                                if (dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString() == "0")
                                {
                                    //not percentage
                                    if (dtEmpSalaryDeduction.Rows[intRowCount]["PAYRL_TYPE_STS"].ToString() == "0")
                                    {
                                        if (flgFix == 0)
                                        {
                                            DecDeduction = Convert.ToDecimal(dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_AMOUNT"]);
                                        }
                                    }
                                    else
                                    {
                                        DecDeduction = Convert.ToDecimal(dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_AMOUNT"]);
                                        decimal amtOneDay = DecDeduction / WorkDays;
                                        decimal amtWorkDay = amtOneDay * (currntDay - TtlCnt);
                                        DecDeduction = amtWorkDay;
                                    }
                                    DecCurrAmnt = DecDeduction;
                                    deciDeduction += DecDeduction;
                                }
                                else if (dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString() == "1")
                                {
                                    //percentage
                                    if (dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_BASIC_OR_TOTAL_AMNT"].ToString() == "0")
                                    {
                                        //deduction percentage on Basic Pay
                                        if (dtEmpSalaryDeduction.Rows[intRowCount]["PAYRL_TYPE_STS"].ToString() == "0")
                                        {
                                            if (flgFix == 0)
                                            {
                                                DecDeductionbasicPay = Convert.ToDecimal(dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_PERCNTGE"]);
                                                DecDeductionbasicPay = deciBasicPay * (DecDeductionbasicPay / 100);
                                            }
                                        }
                                        else
                                        {
                                            DecDeductionbasicPay = Convert.ToDecimal(dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_PERCNTGE"]);
                                            DecDeductionbasicPay = deciBasicPay * (DecDeductionbasicPay / 100);

                                            decimal amtOneDay = DecDeductionbasicPay / WorkDays;
                                            decimal amtWorkDay = amtOneDay * (currntDay - TtlCnt);
                                            DecDeductionbasicPay = amtWorkDay;

                                        }
                                        DecCurrAmnt = DecDeductionbasicPay;
                                    }
                                    else if (dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_BASIC_OR_TOTAL_AMNT"].ToString() == "1")
                                    {
                                        //deduction percentage on Total Amnt
                                        if (dtEmpSalaryDeduction.Rows[intRowCount]["PAYRL_TYPE_STS"].ToString() == "0")
                                        {
                                            if (flgFix == 0)
                                            {
                                                DecDeductionTotlPay = Convert.ToDecimal(dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_PERCNTGE"]);
                                                DecDeductionTotlPay = (deciBasicPay + deciAllowance) * (DecDeductionTotlPay / 100);
                                            }
                                        }
                                        else
                                        {
                                            DecDeductionTotlPay = Convert.ToDecimal(dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_PERCNTGE"]);
                                            DecDeductionTotlPay = (deciBasicPay + deciAllowance) * (DecDeductionTotlPay / 100);
                                            decimal amtOneDay = DecDeductionTotlPay / WorkDays;
                                            decimal amtWorkDay = amtOneDay * (currntDay - TtlCnt);
                                            DecDeductionTotlPay = amtWorkDay;
                                        }
                                        DecCurrAmnt = DecDeductionTotlPay;
                                    }


                                }

                                if (strDedDtlsPrev == "")
                                {
                                    strDedDtlsPrev += dtEmpSalaryDeduction.Rows[intRowCount]["PGDEDTN_ID"].ToString() + "-" + dtEmpSalaryDeduction.Rows[intRowCount]["PYGRD_ID"].ToString() + "-" + dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_AMOUNT"].ToString() + "-" + dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_PERCNTGE"].ToString() + "-" + dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString() + "-" + dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_BASIC_OR_TOTAL_AMNT"].ToString() + "-" + DecCurrAmnt.ToString() + "-1";
                                }
                                else
                                {
                                    strDedDtlsPrev += "%" + dtEmpSalaryDeduction.Rows[intRowCount]["PGDEDTN_ID"].ToString() + "-" + dtEmpSalaryDeduction.Rows[intRowCount]["PYGRD_ID"].ToString() + "-" + dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_AMOUNT"].ToString() + "-" + dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_PERCNTGE"].ToString() + "-" + dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString() + "-" + dtEmpSalaryDeduction.Rows[intRowCount]["SLRYDEDTN_BASIC_OR_TOTAL_AMNT"].ToString() + "-" + DecCurrAmnt.ToString() + "-1";
                                }


                                deciBasicpayDeduction += DecDeductionbasicPay;
                                deciTotalPayDedution += DecDeductionTotlPay;
                            }
                        }
                    }


                    RemainDays = 30;
                    Nowdate = dtPrevToDate;
                    LstSettleMonth = Nowdate.Month;
                    LstSettleYear = Nowdate.Year;
                    LstSettleDay = Nowdate.Day;
                    Date1New = new DateTime();
                    Date2New = new DateTime();
                    if (strLastRejoinDate != "")
                    {
                        Date2New = new DateTime(LstSettleYear, LstSettleMonth, LstSettleDay);
                        Date1New = dtprevFromDate;
                        RemainDays = Convert.ToInt32((Date2New - Date1New).TotalDays) + 1;
                        if (BasicPayStatus == 1)
                        {
                            RemainDays = RemainDays - TtlCnt;
                        }
                        else
                        {
                            if (flgFix == 0)
                            {
                                RemainDays = WorkDays;
                            }
                            else
                            {
                                RemainDays = 0;
                            }

                        }
                    }
                    deciBasicPay = (deciBasicPay / WorkDays) * RemainDays;
                    deciOverTimeAddition = ((deciEmployeeBasicPay / WorkDays) / 8) * deciOverTimeAddition;
                    objEndSrvStlmntLocal.deciPrevMonSalary = deciBasicPay + deciOverTimeAddition + deciPrevMonSalary + deciAllowance + deciOtherManualAddAmnt
                        - (deciDeduction + deciBasicpayDeduction + deciTotalPayDedution + deciOtherManualDeductAmnt + PrevMessDedctn);


                    decimal decPreTotDedt = deciDeduction + deciBasicpayDeduction + deciTotalPayDedution;
                  

                    string strHtml = "Basic Pay:" + objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString,Math.Round(deciBasicPay, roundNum)).ToString(), objEntityCommon);
                    strHtml += "\nAddition:" + objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString,Math.Round(deciAllowance, roundNum)).ToString(), objEntityCommon);
                    strHtml += "\nOvertime Addition:" + objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString,Math.Round(deciOverTimeAddition, roundNum)).ToString(), objEntityCommon);
                    strHtml += "\nDeduction:" + objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString, Math.Round(decPreTotDedt, roundNum)).ToString(), objEntityCommon);
                    strHtml += "\nPayment Deduction:" + objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString, Math.Round(deciTotalPayDedution, roundNum)).ToString(), objEntityCommon);
                    strHtml += "\nOther Addition:" + objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString, Math.Round(deciOtherManualAddAmnt, roundNum)).ToString(), objEntityCommon);
                    strHtml += "\nOther Deduction:" + objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString,Math.Round(deciOtherManualDeductAmnt, roundNum) ).ToString(), objEntityCommon);
                    strHtml += "\nMess Deduction:" + objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString, Math.Round(PrevMessDedctn, roundNum)).ToString(), objEntityCommon);

                    objEndSrvStlmntLocal.strPrevSalaryDtls = strHtml;

                    objEndSrvStlmntLocal.deciPrevAdditionAmt = deciAllowance;
                    objEndSrvStlmntLocal.deciPrevOvertimeAmt = deciOverTimeAddition;
                    objEndSrvStlmntLocal.deciPrevDeductionAmt = decPreTotDedt;
                    objEndSrvStlmntLocal.PrevPaymntDedAmt = deciTotalPayDedution;
                    objEndSrvStlmntLocal.deciPrevMessAmnt = PrevMessDedctn;
                    
                }


                //Net amount calculation

              /*  objEndSrvStlmntLocal.deciNetAmt += objEndSrvStlmntLocal.deciCurrentMonSalary + objEndSrvStlmntLocal.deciGratuityAmt + objEndSrvStlmntLocal.deciLeaveSalAmt + objEndSrvStlmntLocal.deciPrevMonSalary + decOpenLeaveAmntPrev;
                  objEndSrvStlmntLocal.deciNetAmt -= objEndSrvStlmntLocal.deciLvArrearAmnt;*/
             // objEndSrvStlmntLocal.deciPrevMonSalary

            // objEndSrvStlmntLocal.deciNetAmt += objEndSrvStlmntLocal.deciCurrentMonSalary + objEndSrvStlmntLocal.deciGratuityAmt + objEndSrvStlmntLocal.deciLeaveSalAmt + objEndSrvStlmntLocal.deciPrevMonSalary + decOpenLeaveAmntPrev + objEndSrvStlmntLocal.deciOtherManualAddAmnt;
                objEndSrvStlmntLocal.deciNetAmt += objEndSrvStlmntLocal.deciCurrentMonSalary + objEndSrvStlmntLocal.deciGratuityAmt + objEndSrvStlmntLocal.deciLeaveSalAmt + objEndSrvStlmntLocal.deciPrevMonSalary + objEndSrvStlmntLocal.deciOtherManualAddAmnt + objEndSrvStlmntLocal.PrevMnthArrAmt;
                objEndSrvStlmntLocal.deciNetAmt -= objEndSrvStlmntLocal.deciLvArrearAmnt + objEndSrvStlmntLocal.deciOtherManualDeductAmnt;
                objEndSrvStlmntLocal.deciNetAmt = Math.Round(objEndSrvStlmntLocal.deciNetAmt);
                objEndSrvStlmntLocal.intTicketAmtSts = intTicketSts;

                if (IndividualRound == "1")
                {
                    objEndSrvStlmntLocal.deciBasicPay = Math.Round(objEndSrvStlmntLocal.deciBasicPay, 0);
                    objEndSrvStlmntLocal.deciAddition = Math.Round(objEndSrvStlmntLocal.deciAddition, 0);
                    objEndSrvStlmntLocal.deciDeduction = Math.Round(objEndSrvStlmntLocal.deciDeduction, 0);
                    objEndSrvStlmntLocal.strMessDedctn = Math.Round(Convert.ToDecimal(objEndSrvStlmntLocal.strMessDedctn), 0).ToString();
                    objEndSrvStlmntLocal.deciGratuityAmt = Math.Round(objEndSrvStlmntLocal.deciGratuityAmt, 0);
                    objEndSrvStlmntLocal.deciPrevMonSalary = Math.Round(objEndSrvStlmntLocal.deciPrevMonSalary, 0);
                    objEndSrvStlmntLocal.deciOverTimeAddition = Math.Round(objEndSrvStlmntLocal.deciOverTimeAddition, 0);
                    objEndSrvStlmntLocal.deciPaymentDeduction = Math.Round(objEndSrvStlmntLocal.deciPaymentDeduction, 0);
                    objEndSrvStlmntLocal.deciLvArrearAmnt = Math.Round(objEndSrvStlmntLocal.deciLvArrearAmnt, 0);
                    objEndSrvStlmntLocal.deciOtherManualAddAmnt = Math.Round(objEndSrvStlmntLocal.deciOtherManualAddAmnt, 0);
                    objEndSrvStlmntLocal.deciOtherManualDeductAmnt = Math.Round(objEndSrvStlmntLocal.deciOtherManualDeductAmnt, 0);
                    objEndSrvStlmntLocal.deciCurrentMonSalary =  Math.Round((objEndSrvStlmntLocal.deciBasicPay + objEndSrvStlmntLocal.deciOverTimeAddition + objEndSrvStlmntLocal.deciAddition) - (objEndSrvStlmntLocal.deciPaymentDeduction + MessDedctn + objEndSrvStlmntLocal.deciDeduction),0);
                    objEndSrvStlmntLocal.deciNetAmt = Math.Round(objEndSrvStlmntLocal.deciCurrentMonSalary, 0) + Math.Round(objEndSrvStlmntLocal.deciGratuityAmt, 0) + Math.Round(objEndSrvStlmntLocal.deciLeaveSalAmt, 0) + Math.Round(objEndSrvStlmntLocal.deciPrevMonSalary, 0) + Math.Round(objEndSrvStlmntLocal.deciOtherManualAddAmnt, 0) + objEndSrvStlmntLocal.PrevMnthArrAmt;
                    objEndSrvStlmntLocal.deciNetAmt -= Math.Round(objEndSrvStlmntLocal.deciLvArrearAmnt,0) +Math.Round( objEndSrvStlmntLocal.deciOtherManualDeductAmnt,0);
                    objEndSrvStlmntLocal.deciLeaveSalAmt = Math.Round(objEndSrvStlmntLocal.deciLeaveSalAmt, 0);



                }


                cls_Business_Monthly_Salary_Process objBuss3 = new cls_Business_Monthly_Salary_Process();
                cls_Entity_Monthly_Salary_Process objEnt3 = new cls_Entity_Monthly_Salary_Process();


                string pmonth = objCommon.textToDateTime(stringDateofLeaving).Month.ToString("00");
                string pyear = objCommon.textToDateTime(stringDateofLeaving).Year.ToString();

               // string pmonth = objEntityLeavSettlmt.DateEndDate.Month.ToString("00");
               // string pyear = objEntityLeavSettlmt.DateEndDate.Year.ToString();

             //   nt intCorpID, int intOrgID,
                objEnt3.Orgid = intOrgID;
                objEnt3.CorpOffice = intCorpID;
                objEnt3.Month = Convert.ToInt32(pmonth);
                objEnt3.Year = Convert.ToInt32(pyear);
                objEnt3.Employee = objEnt.Employee;
                //Other Addition & Deduction
                DataTable dtOther_Addition = objBuss3.ReadEmpManualy_AdditionDetails(objEnt3);
                DataTable dtOther_Deduction = objBuss3.ReadEmpManualy_DeductionsDetails(objEnt3);

                int decmlcnt1 = Convert.ToInt32(DecimalCnt);
                int roundNum1 = 0;
                if (IndividualRound == "0")
                {
                    roundNum1 = decmlcnt1;
                }

                if (dtOther_Addition.Rows.Count > 0)
                {
                    for (int intRow = 0; intRow < dtOther_Addition.Rows.Count; intRow++)
                    {
                        string strOthrAddAmt = Convert.ToString(Math.Round(Convert.ToDecimal(dtOther_Addition.Rows[intRow]["OTHER_ADDITION"]), roundNum1).ToString("0.00"));
                        if (strHtmlOtherAdd == "")
                        {
                            strHtmlOtherAdd += dtOther_Addition.Rows[intRow]["PAYRL_CODE"].ToString() + " : " + strOthrAddAmt;
                        }
                        else
                        {
                            strHtmlOtherAdd += ", " + dtOther_Addition.Rows[intRow]["PAYRL_CODE"].ToString() + " : " + strOthrAddAmt;
                        }
                    }
                    objEndSrvStlmntLocal.strOtherAddition = strHtmlOtherAdd;

                }

                if (dtOther_Deduction.Rows.Count > 0)
                {
                    for (int intRow = 0; intRow < dtOther_Deduction.Rows.Count; intRow++)
                    {
                        string strOthrDeductAmt = Convert.ToString(Math.Round(Convert.ToDecimal(dtOther_Deduction.Rows[intRow]["OTHER_DEDUCTION"]), roundNum1).ToString("0.00"));
                        if (strHtmlOtherDed == "")
                        {
                            strHtmlOtherDed += dtOther_Deduction.Rows[intRow]["PAYRL_CODE"].ToString() + " : " + strOthrDeductAmt;
                        }
                        else
                        {
                            strHtmlOtherDed += ", " + dtOther_Deduction.Rows[intRow]["PAYRL_CODE"].ToString() + " : " + strOthrDeductAmt;
                        }
                    }
                    objEndSrvStlmntLocal.strOtherDeduction = strHtmlOtherDed;
                }

                        objEndSrvStlmntLocal.strAddDtls = strAddDtls;
                        if (strAddDtlsPrev != "")
                        {
                            objEndSrvStlmntLocal.strAddDtls = strAddDtls + "%" + strAddDtlsPrev;
                        }
                        objEndSrvStlmntLocal.strDedDtls = strDedDtls;
                        if (strDedDtlsPrev != "")
                        {
                            objEndSrvStlmntLocal.strDedDtls = strDedDtls + "%" + strDedDtlsPrev;
                        }
                       
            }
        }
        catch (Exception ex)
        {
        }
        return objEndSrvStlmntLocal;
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
    
    public class clsEndSrvStlmntLocal
    {
        public decimal deciBasicPay = 0;
        public decimal deciAddition = 0;
        public decimal deciDeduction = 0;
        public decimal deciOverTimeAddition = 0;
        public decimal deciPaymentDeduction = 0;
        public decimal deciTotalPay = 0;
        public string strLastRejoinDate = "";
        public decimal deciLeaveSalaryDays = 0;
        public decimal intGratuityDays = 0;
        public decimal deciGratuityAmt = 0;
        public decimal deciLeaveSalAmt = 0;
        public decimal deciCurrentMonSalary = 0;
        public decimal deciPrevMonSalary = 0;
        public int intTicketAmtSts = 0;
        public decimal deciNetAmt = 0;
        public decimal deciDeductionDays = 0;
        public string strSettlmentDate = "";
        public string strMessDedctn = "";
        public string strDecision = "";
        public string strLeaveDaysDeduct = "";
        public decimal deciOpenLeaveDays = 0;
        public decimal deciOpenLeaveSalary = 0;
        public decimal deciLvArrearAmnt = 0;
        public decimal deciOtherManualAddAmnt = 0;
        public decimal deciOtherManualDeductAmnt = 0;

        public decimal deciPrevOtherManualAddAmnt = 0;
        public decimal deciPrevOtherManualDeductAmnt = 0;
        public string strOtherAddition = "";
        public string strOtherDeduction = "";
        public string strPrevSalaryDtls = "";

        public decimal deciPrevAdditionAmt = 0;
        public decimal deciPrevOvertimeAmt = 0;
        public decimal deciPrevDeductionAmt = 0;
        public decimal PrevPaymntDedAmt = 0;
        public decimal PrevMnthArrAmt = 0;
        public decimal deciPrevMessAmnt = 0;

        public string strFromDate = "";
        public string strAddDtls = "";
        public string strDedDtls = "";
        public string strPrevMnthRejoin = "";
    }
    [System.Web.Services.WebMethod]
    public static string[] LoadEmployeeDetailsByID(int intEmployeeID, int intCorpID, int intOrgID)
    {
        string[] strArrEmpDetails = new string[6];
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerEndOfServiceLeaveStlmnt objBusinessLayerEndOfServiceLeaveStlmnt = new clsBusinessLayerEndOfServiceLeaveStlmnt();
        clsEntityLayerEndOfServiceLeaveStlmnt objEntityLayerEndOfServiceLeaveStlmnt = new clsEntityLayerEndOfServiceLeaveStlmnt();
        try
        {
            objEntityLayerEndOfServiceLeaveStlmnt.EmployeeID = intEmployeeID;
            objEntityLayerEndOfServiceLeaveStlmnt.CorpId = intCorpID;
            objEntityLayerEndOfServiceLeaveStlmnt.OrgId = intOrgID;
            DataTable dtEmpDtls = new DataTable();
            dtEmpDtls = objBusinessLayerEndOfServiceLeaveStlmnt.ReadExitEmployeeByID(objEntityLayerEndOfServiceLeaveStlmnt);
            if (dtEmpDtls.Rows.Count > 0)
            {
                strArrEmpDetails[0] = dtEmpDtls.Rows[0]["USR_ID"].ToString();
                strArrEmpDetails[1] = dtEmpDtls.Rows[0]["EMPLOYEE"].ToString();
                strArrEmpDetails[2] = dtEmpDtls.Rows[0]["STATUS"].ToString();
                strArrEmpDetails[3] = dtEmpDtls.Rows[0]["EMPERDTL_REF_NUM"].ToString();
                strArrEmpDetails[4] = dtEmpDtls.Rows[0]["EXTPRCS_DATE"].ToString();
                DateTime dtJoinDate = objCommon.textToDateTime(dtEmpDtls.Rows[0]["EMPERDTL_JOIN_DATE"].ToString());
                DateTime dtEndDate = objCommon.textToDateTime(dtEmpDtls.Rows[0]["EXTPRCS_DATE"].ToString());
                int totDays = Convert.ToInt32((dtEndDate - dtJoinDate).TotalDays) + 1;
                if (dtJoinDate < dtCorpGratityDate && totDays >= 365)
                {
                    strArrEmpDetails[5] = "1";
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }

        return strArrEmpDetails;
    }
    [System.Web.Services.WebMethod]
    public static clsEndSrvStlmntLocal UpdateDetail(string strId, int intCorpId, int intOrgId)
    {
        clsBusinessLayerEndOfServiceLeaveStlmnt objBusinessLayerEndOfServiceLeaveStlmnt = new clsBusinessLayerEndOfServiceLeaveStlmnt();
        clsEntityLayerEndOfServiceLeaveStlmnt objEntityLayerEndOfServiceLeaveStlmnt = new clsEntityLayerEndOfServiceLeaveStlmnt();
        objEntityLayerEndOfServiceLeaveStlmnt.OrgId = intOrgId;
        objEntityLayerEndOfServiceLeaveStlmnt.CorpId = intCorpId;
        objEntityLayerEndOfServiceLeaveStlmnt.EndSrvLveStlmntID = Convert.ToInt32(strId);
        DataTable dtEndOfServiceLeaveStlmnt = objBusinessLayerEndOfServiceLeaveStlmnt.ReadSrvLevStlmntByID(objEntityLayerEndOfServiceLeaveStlmnt);
        clsEndSrvStlmntLocal objEndSrvStlmntLocal = new clsEndSrvStlmntLocal();
        if (dtEndOfServiceLeaveStlmnt.Rows.Count > 0)
        {


        }
        return objEndSrvStlmntLocal;
    }
    public void Update(string strId, int intCorpId, int intOrgId, int intEnableConfirm)
    {//PREV_OTHER_DEDUCT_AMNT
        clsBusinessLayerEndOfServiceLeaveStlmnt objBusinessLayerEndOfServiceLeaveStlmnt = new clsBusinessLayerEndOfServiceLeaveStlmnt();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityLayerEndOfServiceLeaveStlmnt objEntityLayerEndOfServiceLeaveStlmnt = new clsEntityLayerEndOfServiceLeaveStlmnt();
        objEntityLayerEndOfServiceLeaveStlmnt.OrgId = intOrgId;
        objEntityLayerEndOfServiceLeaveStlmnt.CorpId = intCorpId;
        objEntityLayerEndOfServiceLeaveStlmnt.EndSrvLveStlmntID = Convert.ToInt32(strId);
        HiddenEndOfStlmntID.Value = strId;
        cls_Business_Monthly_Salary_Process objBuss2 = new cls_Business_Monthly_Salary_Process();
        cls_Entity_Monthly_Salary_Process objEnt2 = new cls_Entity_Monthly_Salary_Process();

        DataTable dtEndOfServiceLeaveStlmnt = objBusinessLayerEndOfServiceLeaveStlmnt.ReadSrvLevStlmntByID(objEntityLayerEndOfServiceLeaveStlmnt);
        clsEndSrvStlmntLocal objEndSrvStlmntLocal = new clsEndSrvStlmntLocal();
        string strHtmlOtherAdd = "";
        string strHtmlOtherDed = "";

        string individualRound = HiddenFieldIndividualRound.Value;
        int roundNum = 0;
        if(individualRound=="0"){
        roundNum=Convert.ToInt32(hiddenDecimalCount.Value);
        }

        if (dtEndOfServiceLeaveStlmnt.Rows.Count > 0)
        {
             HiddenFieldFromDate.Value = dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_FROM_DATE"].ToString();
             HiddenFieldPrevArrAmt.Value = dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_PREV_MNTH_ARR_AMT"].ToString();
             HiddenFieldPrevMntRejoinDate.Value = dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_PREV_MNTH_REJOIN"].ToString();


            DateTime dtJoinDate = objCommon.textToDateTime(dtEndOfServiceLeaveStlmnt.Rows[0]["EMPERDTL_JOIN_DATE"].ToString());
            DateTime dtEndDate = objCommon.textToDateTime(dtEndOfServiceLeaveStlmnt.Rows[0]["DATE_OF_LEAVING"].ToString());
            int totDays = Convert.ToInt32((dtEndDate - dtJoinDate).TotalDays) + 1;
            if (dtJoinDate < dtCorpGratityDate && totDays >= 365)
            {
                HiddenFieldShowCbx.Value = "1";
            }



            HiddenFieldLeaveDeductCnt.Value = dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_LEAVE_DEDUCT"].ToString();
            //if (dtEndOfServiceLeaveStlmnt.Rows[0]["CNFRM_STS"].ToString() == "0")
            //{
            //    DateTime dateDateofLeaving = objCommon.textToDateTime(dtEndOfServiceLeaveStlmnt.Rows[0]["DATE_OF_LEAVING"].ToString());
            //    DateTime dateCurrentDate = objBusinessLayer.LoadCurrentDate();
            //    if (dateCurrentDate > dateDateofLeaving)
            //    {
            //        dateCurrentDate = dateDateofLeaving;
            //    }
            //    objEntityLayerEndOfServiceLeaveStlmnt.DateOfLeaving = dateCurrentDate;



            //    objEntityLayerEndOfServiceLeaveStlmnt.EmployeeID = Convert.ToInt32(dtEndOfServiceLeaveStlmnt.Rows[0]["EMPOLYEE_ID"].ToString());
            //    objEntityLayerEndOfServiceLeaveStlmnt.DateOfLeaving = dateCurrentDate;

            //    DataTable dtMessDedctn = objBusinessLayerEndOfServiceLeaveStlmnt.ReadMessDeductionByID(objEntityLayerEndOfServiceLeaveStlmnt);
            //    decimal MessDedctn = 0; string StrMessDedctn = "0";
            //    if (dtMessDedctn.Rows[0]["MESS_DEDCTN"].ToString() != "")
            //    {
            //        StrMessDedctn = dtMessDedctn.Rows[0]["MESS_DEDCTN"].ToString();
            //        MessDedctn = Convert.ToDecimal(dtMessDedctn.Rows[0]["MESS_DEDCTN"].ToString());
            //        HiddenMessDedctn.Value = StrMessDedctn;


            //    }
            //}



            HiddenMessDedctn.Value = dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_STLMT_MESSAMNT"].ToString();
            HiddenFieldPrevOtherAddAmt.Value = dtEndOfServiceLeaveStlmnt.Rows[0]["PREV_OTHER_ADD_AMNT"].ToString();
            HiddenFieldPrevOtherDeductAmt.Value = dtEndOfServiceLeaveStlmnt.Rows[0]["PREV_OTHER_DEDUCT_AMNT"].ToString();


            HiddenFieldPrevAddition.Value = dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_PREV_ADDITION"].ToString();
            HiddenFieldPrevOvertimeAmt.Value = dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_PREV_OVERTIME_AMNT"].ToString();
            HiddenFieldPrevDeduction.Value = dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_PREV_DEDUCTION"].ToString();
            HiddenFieldPrevPaymntDedAmt.Value = dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_PREV_PAYMENT_DEDUCT"].ToString();
            HiddenFieldPrevMessAmt.Value = dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_PREV_MESS_AMNT"].ToString();
            decimal deciPrevBasicPay = 0, deciAllowance = 0, deciOverTimeAddition = 0, deciDeduction = 0, deciTotalPayDedution = 0, deciOtherManualAddAmnt = 0, deciOtherManualDeductAmnt = 0;
            decimal deciPrevMessAmt = 0;
            if (dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_PREV_MESS_AMNT"].ToString() != "")
            {
                deciPrevMessAmt = Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_PREV_MESS_AMNT"].ToString());
            }
            if (HiddenFieldPrevAddition.Value != "")
            {
                deciAllowance = Convert.ToDecimal(HiddenFieldPrevAddition.Value);
            }
            if (HiddenFieldPrevOvertimeAmt.Value != "")
            {
                deciOverTimeAddition = Convert.ToDecimal(HiddenFieldPrevOvertimeAmt.Value);
            }
            if (HiddenFieldPrevDeduction.Value != "")
            {
                deciDeduction = Convert.ToDecimal(HiddenFieldPrevDeduction.Value);
            }
            if (HiddenFieldPrevPaymntDedAmt.Value != "")
            {
                deciTotalPayDedution = Convert.ToDecimal(HiddenFieldPrevPaymntDedAmt.Value);
            }
            if (HiddenFieldPrevOtherAddAmt.Value != "")
            {
                deciOtherManualAddAmnt = Convert.ToDecimal(HiddenFieldPrevOtherAddAmt.Value);
            }
            if (HiddenFieldPrevOtherDeductAmt.Value != "")
            {
                deciOtherManualDeductAmnt = Convert.ToDecimal(HiddenFieldPrevOtherDeductAmt.Value);
            }

            clsEntityCommon objEntityCommon = new clsEntityCommon();
            int decmlcnt = Convert.ToInt32("2");
            string formatString = String.Concat("{0:F", decmlcnt, "}");

            deciPrevBasicPay = Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[0]["PREV_MONTH_SAL"].ToString());

            deciPrevBasicPay = deciPrevBasicPay - deciAllowance - deciOverTimeAddition - deciOtherManualAddAmnt + deciDeduction + deciTotalPayDedution + deciOtherManualDeductAmnt + deciPrevMessAmt;

            string strHtml = "Basic Pay:" + objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString,Math.Round(deciPrevBasicPay,roundNum)).ToString(), objEntityCommon);
            strHtml += "\nAddition:" + objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString, Math.Round(deciAllowance,roundNum)).ToString(), objEntityCommon);
            strHtml += "\nOvertime Addition:" + objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString, Math.Round(deciOverTimeAddition, roundNum)).ToString(), objEntityCommon);
            strHtml += "\nDeduction:" + objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString, Math.Round(deciDeduction, roundNum)).ToString(), objEntityCommon);
            strHtml += "\nPayment Deduction:" + objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString, Math.Round(deciTotalPayDedution, roundNum)).ToString(), objEntityCommon);
            strHtml += "\nOther Addition:" + objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString, Math.Round(deciOtherManualAddAmnt,roundNum)).ToString(), objEntityCommon);
            strHtml += "\nOther Deduction:" + objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString, Math.Round(deciOtherManualDeductAmnt,roundNum)).ToString(), objEntityCommon);
            strHtml += "\nMess Deduction:" + objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString, Math.Round(deciPrevMessAmt, roundNum)).ToString(), objEntityCommon);
            HiddenFieldPreviousMonthDetails.Value = strHtml;

            if (ddlEmployee.Items.FindByText(dtEndOfServiceLeaveStlmnt.Rows[0]["EMPLOYEE"].ToString()) != null)
            {
                ddlEmployee.ClearSelection();
                ddlEmployee.Items.FindByText(dtEndOfServiceLeaveStlmnt.Rows[0]["EMPLOYEE"].ToString()).Selected = true;
            }

            else
            {
                System.Web.UI.WebControls.ListItem lst = new System.Web.UI.WebControls.ListItem(dtEndOfServiceLeaveStlmnt.Rows[0]["EMPLOYEE"].ToString(), dtEndOfServiceLeaveStlmnt.Rows[0]["EMPOLYEE_ID"].ToString());
                ddlEmployee.Items.Insert(1, lst);

                SortDDL(ref this.ddlEmployee);
                ddlEmployee.ClearSelection();
                ddlEmployee.Items.FindByText(dtEndOfServiceLeaveStlmnt.Rows[0]["EMPLOYEE"].ToString()).Selected = true;
            }

            txtComments.Text = dtEndOfServiceLeaveStlmnt.Rows[0]["COMMENTS_REMARKS"].ToString();

            decimal netamnt = 0;
            //  netamnt=Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[0]["NET_AMOUNT"].ToString()); txtLeaveSalary
            //   netamnt = netamnt - MessDedctn; txtPrevMonthSal PREV_MONTH
            txtNetAmount.Text = dtEndOfServiceLeaveStlmnt.Rows[0]["NET_AMOUNT"].ToString();
            hiddenNetAmount.Value = dtEndOfServiceLeaveStlmnt.Rows[0]["NET_AMOUNT"].ToString();

            txtOtherAmount.Text = dtEndOfServiceLeaveStlmnt.Rows[0]["OTHER_AMNT"].ToString();
            txtOtherDeductions.Text = dtEndOfServiceLeaveStlmnt.Rows[0]["OTHER_DEDUCTION"].ToString();
            txtTicketAmount.Text = dtEndOfServiceLeaveStlmnt.Rows[0]["TICKET_AMOUNT"].ToString();
            if (individualRound == "1")
            {
                txtOtherAmount.Text = Math.Round(Convert.ToDecimal(txtOtherAmount.Text), 0).ToString();
                txtOtherDeductions.Text = Math.Round(Convert.ToDecimal(txtOtherDeductions.Text), 0).ToString();
                txtTicketAmount.Text = Math.Round(Convert.ToDecimal(txtTicketAmount.Text), 0).ToString();
            }

            hiddenEditData.Value = DataTableToJSONWithJavaScriptSerializer(dtEndOfServiceLeaveStlmnt);


            if (intEnableConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active) && dtEndOfServiceLeaveStlmnt.Rows[0]["CNFRM_STS"].ToString() == "0")
            {
                btnConfirm.Visible = true;
            }

            DateTime dtLastLeaveCurr = objCommon.textToDateTime(dtEndOfServiceLeaveStlmnt.Rows[0]["DATE_OF_LEAVING"].ToString());
            string pmonth = dtLastLeaveCurr.Month.ToString("00");
            string pyear = dtLastLeaveCurr.Year.ToString();
            objEnt2.Month = Convert.ToInt32(pmonth);
            objEnt2.Year = Convert.ToInt32(pyear);
            objEnt2.Employee = Convert.ToInt32(dtEndOfServiceLeaveStlmnt.Rows[0]["EMPOLYEE_ID"].ToString());
            objEnt2.CorpOffice = intCorpId;
            objEnt2.Orgid = intOrgId;

            if (dtEndOfServiceLeaveStlmnt.Rows[0]["CNFRM_STS"].ToString() == "1")
            {
                objEnt2.SavConf = 1;
            }

            DataTable dtOther_Addition = objBuss2.ReadEmpManualy_AdditionDetails(objEnt2);
            DataTable dtOther_Deduction = objBuss2.ReadEmpManualy_DeductionsDetails(objEnt2);

            if (dtOther_Addition.Rows.Count > 0)
            {
                for (int intRow = 0; intRow < dtOther_Addition.Rows.Count; intRow++)
                {
                    string strOthrAddAmt = Convert.ToString(Math.Round(Convert.ToDecimal(dtOther_Addition.Rows[intRow]["OTHER_ADDITION"]), roundNum).ToString("0.00"));
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
                    string strOthrDeductAmt = Convert.ToString(Math.Round(Convert.ToDecimal(dtOther_Deduction.Rows[intRow]["OTHER_DEDUCTION"]), roundNum).ToString("0.00"));
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

            divprint.Visible = true;

           if (dtEndOfServiceLeaveStlmnt.Rows[0]["STAFF_WORKER"].ToString() == "1")
           {
                    divPrintPayslip.Visible = true;
           }


            if (dtEndOfServiceLeaveStlmnt.Rows[0]["CNFRM_STS"].ToString() == "1")
            {
                btnCalculate.Visible = false;
                //confirmed entry
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                //INPUT FIELDS
                txtComments.Enabled = false;
                txtNetAmount.Enabled = false;
                txtOtherAmount.Enabled = false;
                txtOtherDeductions.Enabled = false;
                txtTicketAmount.Enabled = false;
                cbxGrtJoinDate.Disabled = true;
                DataTable dtCorp = objBusinessLayerEndOfServiceLeaveStlmnt.ReadCorporateAddress(objEntityLayerEndOfServiceLeaveStlmnt);

                string strPrintReport = ConvertDataTableForPrint(dtEndOfServiceLeaveStlmnt, dtCorp);
                divprint.Visible = true;
                divPrintReport.InnerHtml = strPrintReport;

            }
            else if (dtEndOfServiceLeaveStlmnt.Rows[0]["CNFRM_STS"].ToString() == "2" || dtEndOfServiceLeaveStlmnt.Rows[0]["CNFRM_STS"].ToString() == "3")
            {
                btnCalculate.Visible = false;
                cbxGrtJoinDate.Disabled = true;
                btnConfirm.Visible = false;
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                //INPUT FIELDS
                txtComments.Enabled = false;
                txtNetAmount.Enabled = false;
                txtOtherAmount.Enabled = false;
                txtOtherDeductions.Enabled = false;
                txtTicketAmount.Enabled = false;

                DataTable dtCorp = objBusinessLayerEndOfServiceLeaveStlmnt.ReadCorporateAddress(objEntityLayerEndOfServiceLeaveStlmnt);

                string strPrintReport = ConvertDataTableForPrint(dtEndOfServiceLeaveStlmnt, dtCorp);
                divprint.Visible = true;
                divPrintReport.InnerHtml = strPrintReport;
            }
        }

    }
    public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
    {
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
        Dictionary<string, object> childRow;
        foreach (DataRow row in table.Rows)
        {
            childRow = new Dictionary<string, object>();
            foreach (DataColumn col in table.Columns)
            {
                childRow.Add(col.ColumnName, row[col]);

            }

            parentRow.Add(childRow);
        }
        return jsSerializer.Serialize(parentRow);
    }
    //for sorting drop down
    private void SortDDL(ref DropDownList objDDL)
    {
        ArrayList textList = new ArrayList();
        ArrayList valueList = new ArrayList();


        foreach (System.Web.UI.WebControls.ListItem li in objDDL.Items)
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
            System.Web.UI.WebControls.ListItem objItem = new System.Web.UI.WebControls.ListItem(textList[i].ToString(), valueList[i].ToString());
            objDDL.Items.Add(objItem);
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("hcm_End_Service_Leave_Settlement.aspx");
    }
    public string ConvertDataTableForPrint(DataTable dt, DataTable dtCorp)
    {
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "End Of Service Settlement";
        DateTime datetm = DateTime.Now;
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
        // strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >1</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Employee</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["EMPLOYEE"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        //strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >9</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Date of Leaving </td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["DATE_OF_LEAVING"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        // strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >2</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >REF#</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + lblRefNo.Text + "</td>";
        strHtml += "</tr>";

        string strEmpStatus = "";
        switch (dt.Rows[0]["EMPLOYEE_STS"].ToString())
        {
            case "1":
                strEmpStatus = "Resign";
                break;
            case "2":
                strEmpStatus = "Retirement";
                break;
            case "3":
                strEmpStatus = "Termination";
                break;
            case "4":
                strEmpStatus = "Other";
                break;
            default:
                strEmpStatus = "";
                break;
        }
        strHtml += "<tr>";
        // strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >10</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Employee Status</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + strEmpStatus + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        // strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >3</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Comments/Remarks</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["COMMENTS_REMARKS"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        // strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >6</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Basic pay</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["SRVCLVE_STLMT_BASICPAY"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        // strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >7</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Addition</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["SRVCLVE_STLMT_ADDITION"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        // strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >8</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Deduction</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["SRVCLVE_STLMT_DEDUCTION"].ToString() + "</td>";
        strHtml += "</tr>";


        strHtml += "<tr>";
        // strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >7</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Over Time Addition</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["SRVCLVE_STLMT_DEDUCTION"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        // strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >8</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Payment Deduction</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["SRVLVE_PYMT_DEDUCTION"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        // strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >4</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Resume date</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["LAST_REJOIN_DATE"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        // strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >3</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Eligible Days For Leave Salary</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["LVE_SAL_ELIGIBLE_DAYS"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Open Eligible Days For Leave Salary</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["SRVCLVE_OPEN_LEAVE_DAYS"].ToString() + "</td>";
        strHtml += "</tr>";



        strHtml += "<tr>";
        // strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >3</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Eligible Days For Gratuity</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["GRATUITY_ELIGIBLE_DAYS"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        // strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >3</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Gratuity</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["GRATUITY_AMOUNT"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        // strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >3</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Leave Salary</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["LVE_SAL_AMOUNT"].ToString() + "</td>";
        strHtml += "</tr>";


        strHtml += "<tr>";
        // strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >3</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Open Leave Salary</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["SRVCLVE_OPEN_LEAVE_SALARY"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        // strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >3</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Leave Arrear Amount</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["SRVCLVE_LV_ARREAR_AMNT"].ToString() + "</td>";
        strHtml += "</tr>";


        strHtml += "<tr>";
        // strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >13</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Current month salary(Till Date)</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["CUR_MONTH_SAL"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        // strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >12</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Previous month salary</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["PREV_MONTH_SAL"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        // strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >15</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Other amount</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["OTHER_AMNT"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        // strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >14</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Ticket amount</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["TICKET_AMOUNT"].ToString() + "</td>";
        strHtml += "</tr>";



        strHtml += "<tr>";
        // strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >16</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Other deduction</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["OTHER_DEDUCTION"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "<tr>";
        // strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align:left;\" >17</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Net amount</td>";
        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[0]["NET_AMOUNT"].ToString() + "</td>";
        strHtml += "</tr>";

        strHtml += "</tbody>";

        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }



    public static string LoadEmployeeLeaveDate(string strEmpId, string strCorpId, string strOrgId, string strToDate)
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
        objEntityLeavSettlmt.DateSettle = objCommon.textToDateTime(dtDate);


        DataTable dtMonthlyLeave = objBusinessLeavSettlmt.ReadMonthlyLeaveForMultipleYrs(objEntityLeavSettlmt);
        if (dtMonthlyLeave.Rows.Count > 0)
        {
            string LeaveType_id = "";
            for (int row1 = 0; row1 < dtMonthlyLeave.Rows.Count; row1++)
            {
                DateTime dtFrom = new DateTime();
                DateTime dtDateNow = new DateTime();
                DateTime dtResignDate = new DateTime();
                if (dtMonthlyLeave.Rows[row1]["LEAVE_FROM_DATE"].ToString() != "")
                {
                    dtFrom = objCommon.textToDateTime(dtMonthlyLeave.Rows[row1]["LEAVE_FROM_DATE"].ToString());
                }
                if (strToDate != "")
                {
                    dtResignDate = objCommon.textToDateTime(strToDate);
                }

                dtDateNow = dtCurrDate;
                if (dtFrom >= dtDateNow && dtFrom <= dtResignDate)
                {
                    if (!(LeaveType_id.Contains(dtMonthlyLeave.Rows[row1]["LEAVE_ID"].ToString())))
                    {
                        Leave = "1";

                    }
                }
            }
        }
        return Leave;
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
    [System.Web.Services.WebMethod]
    public static string GenerateReport( string strCorpID ,
        string strOrgIdID ,
        string strId ,
        string strRejoin_date ,
        string strCurrentMonthBasicPay ,
        string strMonthlySalaryTillDate ,
        string strAddition_amount ,
        string strDeduction_amount ,
        string strMess_amount ,
        string strOvertime_amount ,
        string strPayment_deduction ,
        string strEos_reason ,
        string strPrevMonthSal ,
        string strLeaveArrearAmmount ,
        string strTotal_eligible_days ,
        string strTotal_gratuity_eligible_days ,
        string strTotal_gratuity_amount ,
        string strTotal_leave_salary ,

        string strNetAmount ,
        string strOther_AmountAddition ,
        string strOtherDeductions ,
        string strTicketAmount, string strDecimalCount
        , string strDfltCurrencyMstrId,
        string strLeaveDaysOpen, string strLeaveSalaryOpen, string strPRevArrAmnt,string strPRevArrAmntOrg)
    {

        clsBusinessLayerEndOfServiceLeaveStlmnt objBusinessLayerEndOfServiceLeaveStlmnt = new clsBusinessLayerEndOfServiceLeaveStlmnt();
        clsEntityLayerEndOfServiceLeaveStlmnt objEntityLayerEndOfServiceLeaveStlmnt = new clsEntityLayerEndOfServiceLeaveStlmnt();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        int precision = Convert.ToInt32(strDecimalCount);
        string format = String.Format("{{0:N{0}}}", precision);



       
            objEntityLayerEndOfServiceLeaveStlmnt.CorpId = Convert.ToInt32(strCorpID);

            objEntityLayerEndOfServiceLeaveStlmnt.OrgId = Convert.ToInt32(strOrgIdID);
        

        DataTable dtCorp = objBusinessLayerEndOfServiceLeaveStlmnt.ReadCorporateAddress(objEntityLayerEndOfServiceLeaveStlmnt);


        //GET DATA
        clsCommonLibrary objCommon = new clsCommonLibrary();

        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "", strCompanyLogo = ""; ;


        string strTitle = "";
        strTitle = "End Of Service Settlement";
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





////////////////////////////////
      ////  string strId = Session["EDIT_ID"].ToString();

        objEntityLayerEndOfServiceLeaveStlmnt.EndSrvLveStlmntID = Convert.ToInt32(strId);


        DataTable dtEndOfServiceLeaveStlmnt = objBusinessLayerEndOfServiceLeaveStlmnt.ReadSrvLevStlmntByID(objEntityLayerEndOfServiceLeaveStlmnt);


        string strCurrentDate = objBusiness.LoadCurrentDateInString();
        dtCurrDate = objCommon.textToDateTime(strCurrentDate);





        string strEmployee_code = "";
        string strDATE_OF_JOIN = "";
        string strEmployee_name = "";
           string strBasic_salary = "";
        string strRemarks = "";
        string strDate_of_leaving = "";
        

       string strSettledDate = "";
        //string strOvertime_amount = "";
        //string strDeduction_amount = "0";
        //string strPayment_deduction = "";

        ////LEAVE SALARY CALCULATION 
        //string strTotal_eligible_days = "";
        //string strTotal_leave_salary = "";
        ////GRATUITY CALCULATION
        //string strTotal_gratuity_eligible_days = "";
        //string strTotal_gratuity_amount = "";
        ////SETTLEMENT_SUMMARY
        //string strCurrentMonthBasicPay = "";
        //string strMonthlySalaryTillDate = "";
        //string strPrevMonthSal = "";

        //string strOther_AmountAddition = "0";
        //string strOtherDeductions = "0";
        //string strTicketAmount = "0";
        //string strLeaveArrearAmmount = "";
        //string strNetAmount = "0";
        //string strRejoin_date = "";

        //string strEos_reason = "";



        strDeduction_amount = (Convert.ToDecimal(strMess_amount.Replace(",", "")) + Convert.ToDecimal(strDeduction_amount.Replace(",", ""))).ToString();







        DateTime dtEndDate = DateTime.MinValue;
        DateTime dtPreviousMonthDate = DateTime.MinValue;


        if (dtEndOfServiceLeaveStlmnt.Rows.Count > 0)
        {

            dtEndDate = objCommon.textToDateTime(dtEndOfServiceLeaveStlmnt.Rows[0]["DATE_OF_LEAVING"].ToString());

            dtPreviousMonthDate = dtEndDate.AddMonths(-1);

            strDATE_OF_JOIN = dtEndOfServiceLeaveStlmnt.Rows[0]["EMPERDTL_JOIN_DATE"].ToString();
            if (dtEndOfServiceLeaveStlmnt.Rows[0]["EMPLOYEE"].ToString().Contains('-'))
            {
                strEmployee_name = dtEndOfServiceLeaveStlmnt.Rows[0]["EMPLOYEE"].ToString().Split('-')[1];
            }
            else
            {
                strEmployee_name = dtEndOfServiceLeaveStlmnt.Rows[0]["EMPLOYEE"].ToString();
            }
            strDate_of_leaving = dtEndOfServiceLeaveStlmnt.Rows[0]["DATE_OF_LEAVING"].ToString();
            strEmployee_code = dtEndOfServiceLeaveStlmnt.Rows[0]["USR_CODE"].ToString();
           

            strBasic_salary = dtEndOfServiceLeaveStlmnt.Rows[0]["BASIC_PAY"].ToString();

            strRemarks = dtEndOfServiceLeaveStlmnt.Rows[0]["COMMENTS_REMARKS"].ToString();
            strSettledDate = dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_LST_SETLMTDATE"].ToString();


        }



        //GET DATA ENDS





        objEntityCommon.CurrencyId = Convert.ToInt32(strDfltCurrencyMstrId);

        strNetAmount = String.Format(format, Convert.ToDecimal(strNetAmount));


        Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);
        Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);//, color.BLACK);
        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
        {
            objEntityCommon.CorporateID = Convert.ToInt32(strCorpID);
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.END_OF_SERVICE);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);

            int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.END_OF_SERVICE_PDF);
            string strImageName = "EOS" + strId +strNextId+ ".pdf";
            string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.END_OF_SERVICE_PDF);


          //  string fullPath = System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName;
            //if ((System.IO.File.Exists(fullPath)))
            //{
            //    System.IO.File.Delete(fullPath);
            //}

            System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(strImagePath));


            FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
            PdfWriter writer = PdfWriter.GetInstance(document, file);
            writer.PageEvent = new PDFHeader();


            document.Open();


            PdfPTable headtable = new PdfPTable(2);

          
         
            headtable.AddCell(new PdfPCell(new Phrase("END OF SERVICE SETTLEMENT", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

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
            headtable.AddCell(new PdfPCell(new Phrase("DATE : " + dtCurrDate.ToString("dd/MM/yyyy"), new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });




            
            
            
            
            float[] headersHeading = { 80, 20 };  //Header Widths
            headtable.SetWidths(headersHeading);        //Set the pdf headers
            headtable.WidthPercentage = 100;       //Set the PDF File witdh percentage
            document.Add(headtable);


            PdfPTable tableLine = new PdfPTable(1);
            float[] tableLineBody = { 100 };
            tableLine.SetWidths(tableLineBody);
            tableLine.WidthPercentage = 100;
            tableLine.TotalWidth = 650F;
            tableLine.AddCell(new PdfPCell(new Phrase("_____________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
            tableLine.WriteSelectedRows(0, -1, 0, document.PageSize.GetTop(73), writer.DirectContent);



            //contents


            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Tahoma,Arial", 10, Font.NORMAL, BaseColor.BLACK))));
            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Tahoma,Arial", 10, Font.NORMAL, BaseColor.BLACK))));



            PdfPTable pdfBodyTable = new PdfPTable(6);
            //Row 1
            pdfBodyTable.AddCell(new PdfPCell(new Phrase("EMPLOYEE CODE", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) {BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyTable.AddCell(new PdfPCell(new Phrase(strEmployee_code, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyTable.AddCell(new PdfPCell(new Phrase("DATE OF JOIN", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyTable.AddCell(new PdfPCell(new Phrase(strDATE_OF_JOIN, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyTable.AddCell(new PdfPCell(new Phrase("SETTLED DATE ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyTable.AddCell(new PdfPCell(new Phrase(strSettledDate, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            float[] headersPdfBodyTable = { 20, 16, 16, 16 , 16, 16};  //Header Widths
            pdfBodyTable.SetWidths(headersPdfBodyTable);        //Set the pdf headers
            pdfBodyTable.WidthPercentage = 100;       //Set the PDF File witdh percentage
            document.Add(pdfBodyTable);

            pdfBodyTable = new PdfPTable(4);
            
            //Row 2

            pdfBodyTable.AddCell(new PdfPCell(new Phrase("EMPLOYEE NAME", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyTable.AddCell(new PdfPCell(new Phrase(strEmployee_name, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 3, BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //Row 3

            pdfBodyTable.AddCell(new PdfPCell(new Phrase("RESUME DATE", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyTable.AddCell(new PdfPCell(new Phrase(strRejoin_date, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyTable.AddCell(new PdfPCell(new Phrase("DATE OF LEAVING", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyTable.AddCell(new PdfPCell(new Phrase(strDate_of_leaving, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //Row 4

            pdfBodyTable.AddCell(new PdfPCell(new Phrase("EOS REASON", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyTable.AddCell(new PdfPCell(new Phrase(strEos_reason, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyTable.AddCell(new PdfPCell(new Phrase("BASIC SALARY", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyTable.AddCell(new PdfPCell(new Phrase(strBasic_salary, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //Row 5
            pdfBodyTable.AddCell(new PdfPCell(new Phrase("REMARKS, IF ANY", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyTable.AddCell(new PdfPCell(new Phrase(strRemarks, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 3, BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });


            float[] headersPdfBodyTable2 = { 25, 25, 25, 25 };  //Header Widths
            pdfBodyTable.SetWidths(headersPdfBodyTable2);        //Set the pdf headers
            pdfBodyTable.WidthPercentage = 100;       //Set the PDF File witdh percentage
            document.Add(pdfBodyTable);


            //2nd table

            PdfPTable pdfBodyDetailTable = new PdfPTable(3);

            //Row 6
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("SALARY FOR " + dtEndDate.ToString("MMMM").ToUpper() + " " + dtEndDate.Year, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Rowspan=6, BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("BASIC SALARY (+)", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(strCurrentMonthBasicPay, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //Row 7
           // pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("ADDITION AMOUNT (+)", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(strAddition_amount, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });


            //Row 8
           // pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("OVERTIME AMOUNT (+)", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(strOvertime_amount, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //Row 9
           // pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("DEDUCTION AMOUNT (-)", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(strDeduction_amount, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //Row 10
           // pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("PAYMENT DEDUCTION (-)", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(strPayment_deduction, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });


            //Row 11
         //   pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("A. SALARY FOR " + dtEndDate.ToString("MMMM").ToUpper() + " " + dtEndDate.Year, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(strMonthlySalaryTillDate, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });



            decimal decTotalLeavDays = 0, decTotalLeavSalary = 0;
         //   decTotalLeavDays = Convert.ToDecimal(strTotal_eligible_days) + Convert.ToDecimal(strLeaveDaysOpen);
            decTotalLeavDays = Convert.ToDecimal(strTotal_eligible_days) ;

            //decTotalLeavSalary = Convert.ToDecimal(strTotal_leave_salary) + Convert.ToDecimal(strLeaveSalaryOpen);
            decimal BasicSalry = Convert.ToDecimal(strBasic_salary);
            decTotalLeavSalary = (BasicSalry / 30) * (Math.Round(decTotalLeavDays, 0));

            //Row 12
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("LEAVE SALARY CALCULATION", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) {Rowspan=2, BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("TOTAL ELIGIBLE DAYS", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
          //  pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(strTotal_eligible_days, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_CENTER, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
           // pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(decTotalLeavDays.ToString(), new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_CENTER, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase( Math.Round(decTotalLeavDays, 0).ToString(), new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_CENTER, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });


            //Row 13
           // pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("B. TOTAL LEAVE SALARY", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
         //   pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(strTotal_leave_salary, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
          //  pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(decTotalLeavSalary.ToString(), new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase( Math.Round(decTotalLeavSalary,0).ToString("0.00"), new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //Math.Round(netsalary, 0).ToString();
            //Row 14
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("GRATUITY CALCULATION", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Rowspan = 2, BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("TOTAL ELIGIBLE DAYS", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(strTotal_gratuity_eligible_days, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_CENTER, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //Row 15
           // pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("C. TOTAL GRATUITY AMOUNT", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(strTotal_gratuity_amount, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //Row 16
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) {Colspan=3, BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            //pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            //pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //Row 17
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("SETTLEMENT SUMMARY", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) {Rowspan=10, BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("SALARY FOR " + dtEndDate.ToString("MMMM").ToUpper() + " " + dtEndDate.Year + " (+)", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(strMonthlySalaryTillDate, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //Row 18
            //pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("SALARY FOR " + dtPreviousMonthDate.ToString("MMMM").ToUpper() + " " + dtPreviousMonthDate.Year + " (+)", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(strPrevMonthSal, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //Row 19
           // pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("TOTAL LEAVE SALARY (+)", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            //pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(strTotal_leave_salary, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(Math.Round(decTotalLeavSalary,0).ToString("0.00") , new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //Row 20
           // pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("TOTAL GRATUITY AMOUNT (+)", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(strTotal_gratuity_amount, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });


            //Row 21
           // pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("OTHER ADDITION, IF ANY (+)", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(strOther_AmountAddition, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //Row 22
           // pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("TICKET AMOUNT, IF ANY (+)", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(strTicketAmount, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            if (Convert.ToDecimal(strPRevArrAmntOrg) >= 0)
            {
                pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("ARREAR AMOUNT (+)", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
                pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(strPRevArrAmnt, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            }
            else
            {
                pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("ARREAR AMOUNT (-)", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
                pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(strPRevArrAmnt, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            }
            
            
            //Row 23
           // pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("OTHER DEDUCTION (-)", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(strOtherDeductions, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //Row 24
           // pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("LEAVE ARREAR AMOUNT (-) ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(strLeaveArrearAmmount, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });


            decimal decNetAmnt = Convert.ToDecimal(strPRevArrAmntOrg) + Convert.ToDecimal(strMonthlySalaryTillDate) + Convert.ToDecimal(strPrevMonthSal) + Convert.ToDecimal(Math.Round(decTotalLeavSalary, 0).ToString("0.00")) + Convert.ToDecimal(strTotal_gratuity_amount) + Convert.ToDecimal(strOther_AmountAddition) + Convert.ToDecimal(strTicketAmount) - Convert.ToDecimal(strOtherDeductions) - Convert.ToDecimal(strLeaveArrearAmmount);
           // string NetAmnt = String.Format(format, decNetAmnt, strDecimalCount);

            string NetAmnt = Math.Round(decNetAmnt, 0).ToString("0.00");
           
            string strcurrenWord = objBusiness.ConvertCurrencyToWords(objEntityCommon, NetAmnt.Replace(",", ""));

            //Row 24
          //  pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase("D. SETTLEMENT AMOUNT", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) {  BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(NetAmnt, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { BorderColor = BaseColor.GRAY, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });

            //row 25
            pdfBodyDetailTable.AddCell(new PdfPCell(new Phrase(strcurrenWord, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Colspan = 3, BorderColor = BaseColor.GRAY, VerticalAlignment=Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 4f, PaddingLeft = 4f, PaddingTop = 4f });



            float[] headerspdfBodyDetailTable = { 32, 34, 34 };  //Header Widths
            pdfBodyDetailTable.SetWidths(headerspdfBodyDetailTable);        //Set the pdf headers
            pdfBodyDetailTable.WidthPercentage = 100;       //Set the PDF File witdh percentage
            document.Add(pdfBodyDetailTable);


            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Tahoma,Arial", 10, Font.NORMAL, BaseColor.BLACK))));
            document.Add(new Paragraph(new Chunk("I hereby declare that I have received all dues from M/S " + strCompanyName + " and there is no outstanding as on date.", FontFactory.GetFont("Tahoma,Arial", 10, Font.NORMAL, BaseColor.BLACK))));


            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Tahoma,Arial", 10, Font.NORMAL, BaseColor.BLACK))));
            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Tahoma,Arial", 10, Font.NORMAL, BaseColor.BLACK))));
            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Tahoma,Arial", 10, Font.NORMAL, BaseColor.BLACK))));





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
            document.Add(pdfSignatureTable);


            document.Close();
            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();
            //Response.Clear();

            //// Response.AppendHeader("Content-Disposition", "inline; filename=Empl");
            //Response.AddHeader("Content-Disposition", "inline; filename=Employee.pdf");
            //Response.ContentType = "application/pdf";
            //Response.Buffer = true;
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.BinaryWrite(bytes);
            //Response.End();
            //Response.Close();


           return strImagePath + strImageName;






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
            headImg.WriteSelectedRows(0, -1, 50, document.PageSize.GetBottom(30), writer.DirectContent);


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


    //public class PDFHeader : PdfPageEventHelper
    //{
    //    PdfContentByte cb;
    //    PdfTemplate footerTemplate;
    //    BaseFont bf = null;
    //    DateTime PrintTime = DateTime.Now;
    //    public override void OnOpenDocument(PdfWriter writer, Document document)
    //    {
    //        try
    //        {
    //            PrintTime = DateTime.Now;
    //            bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
    //            cb = writer.DirectContent;
    //            footerTemplate = cb.CreateTemplate(200, 200);
    //        }
    //        catch (DocumentException de)
    //        {
    //            //handle exception here
    //        }
    //        catch (System.IO.IOException ioe)
    //        {
    //            //handle exception here
    //        }
    //    }
    //    public override void OnStartPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
    //    {
    //        clsCommonLibrary objCommon = new clsCommonLibrary();
    //        clsEntityCommon ObjEntityCommon = new clsEntityCommon();
    //        clsBusinessLayer objDataCommon = new clsBusinessLayer();
    //        ObjEntityCommon.CorporateID = Convert.ToInt32(HttpContext.Current.Session["CORPOFFICEID"].ToString());
    //        ObjEntityCommon.Organisation_Id = Convert.ToInt32(HttpContext.Current.Session["ORGID"].ToString());
    //        DataTable dtCorp = objDataCommon.ReadCorpDetails(ObjEntityCommon);
    //        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "";
    //        string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DEFAULT_LOGO);
    //        if (dtCorp.Rows.Count > 0)
    //        {
    //            if (dtCorp.Rows[0]["CORPRT_ICON"].ToString() != "")
    //            {
    //                string imaeposition = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
    //                string icon = dtCorp.Rows[0]["CORPRT_ICON"].ToString();
    //                strImageLogo = imaeposition + icon;
    //            }
    //            strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
    //            strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
    //            strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
    //            strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
    //        }
    //        string strAddress = "";
    //        strAddress = strCompanyAddr1;
    //        if (strCompanyAddr2 != "")
    //        {
    //            strAddress += ", " + strCompanyAddr2;
    //        }
    //        if (strCompanyAddr3 != "")
    //        {
    //            strAddress += ", " + strCompanyAddr3;
    //        }
    //        //Head Table
    //        PdfPTable headtable = new PdfPTable(2);
    //        headtable.AddCell(new PdfPCell(new Phrase("LABOR CARD ", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
    //        if (strImageLogo != "")
    //        {
    //            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
    //            image.ScalePercent(PdfPCell.ALIGN_CENTER);
    //            image.ScaleToFit(60f, 40f);
    //            headtable.AddCell(new PdfPCell(image) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
    //        }
    //        else
    //        {
    //            headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
    //        }
    //        headtable.AddCell(new PdfPCell(new Phrase(strCompanyName, new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
    //        headtable.AddCell(new PdfPCell(new Phrase(strAddress, new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
    //        headtable.AddCell(new PdfPCell(new Phrase("_________________________________________________________________________________________________________", new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 2 });
    //        headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 2 });
    //        float[] headersHeading = { 80, 20 };
    //        headtable.SetWidths(headersHeading);
    //        headtable.WidthPercentage = 100;
    //        document.Add(headtable);
    //        PdfPTable tableLine = new PdfPTable(1);
    //        float[] tableLineBody = { 100 };
    //        tableLine.SetWidths(tableLineBody);
    //        tableLine.WidthPercentage = 100;
    //        tableLine.TotalWidth = 650F;
    //        tableLine.AddCell(new PdfPCell(new Phrase("_____________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //        float pos9 = writer.GetVerticalPosition(false);
    //    }
    //    public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
    //    {
    //        // base.OnEndPage(writer, document);
    //        string strUsername = HttpContext.Current.Session["USERFULLNAME"].ToString();
    //        PdfPTable table3 = new PdfPTable(1);
    //        float[] tableBody3 = { 100 };
    //        table3.SetWidths(tableBody3);
    //        table3.WidthPercentage = 100;
    //        table3.TotalWidth = 650F;
    //        table3.AddCell(new PdfPCell(new Phrase("_________________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //        // document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
    //        PdfPTable headImg = new PdfPTable(3);
    //        string strImageLogo = "/Images/Design_Images/images/Compztlogo.png";
    //        //headImg.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 3 });

    //        headImg.AddCell(new PdfPCell(new Phrase("______________________________________________________________________________________________________", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 3, PaddingTop = 5 });
    //        if (strImageLogo != "")
    //        {
    //            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
    //            image.ScalePercent(PdfPCell.ALIGN_CENTER);
    //            image.ScaleToFit(60f, 40f);
    //            headImg.AddCell(new PdfPCell(image) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_TOP });
    //        }

    //        headImg.AddCell(new PdfPCell(new Paragraph("Report generated in Compzit by:" + strUsername + "\nReport generated on:" + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
    //        headImg.AddCell(new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 3 });
    //        float[] headersHeading = { 20, 60, 20 };
    //        headImg.SetWidths(headersHeading);
    //        headImg.WidthPercentage = 100;
    //        headImg.TotalWidth = document.PageSize.Width - 80f;

    //        headImg.WriteSelectedRows(0, -1, 50, document.PageSize.GetBottom(50), writer.DirectContent);

    //        String text = "Page " + writer.PageNumber + " of ";
    //        //Add paging to footer
    //        {
    //            cb.BeginText();
    //            cb.SetFontAndSize(bf, 8);
    //            cb.SetTextMatrix(document.PageSize.GetRight(100), document.PageSize.GetBottom(15));
    //            cb.ShowText(text);
    //            cb.EndText();
    //            float len = bf.GetWidthPoint(text, 8);
    //            cb.AddTemplate(footerTemplate, document.PageSize.GetRight(100) + len, document.PageSize.GetBottom(15));
    //        }
    //    }
    //    public override void OnCloseDocument(PdfWriter writer, Document document)
    //    {
    //        base.OnCloseDocument(writer, document);
    //        footerTemplate.BeginText();
    //        footerTemplate.SetFontAndSize(bf, 8);
    //        footerTemplate.SetTextMatrix(0, 0);
    //        footerTemplate.ShowText((writer.PageNumber).ToString());
    //        footerTemplate.EndText();
    //    }
    //}



    //neww
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
            //string strTodayDate = dtCurrDate.ToString("dd/MM/yyyy");
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
    //neww

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
        string format = String.Format("{{0:N{0}}}", roundNum);
        clsBusinessLayerEndOfServiceLeaveStlmnt objBusinessLayerEndOfServiceLeaveStlmnt = new clsBusinessLayerEndOfServiceLeaveStlmnt();
        clsEntityLayerEndOfServiceLeaveStlmnt objEntityLayerEndOfServiceLeaveStlmnt = new clsEntityLayerEndOfServiceLeaveStlmnt();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
        clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLayerEndOfServiceLeaveStlmnt.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntityLeavSettlmt.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityLayerEndOfServiceLeaveStlmnt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityLeavSettlmt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (HiddenEndOfStlmntID.Value != "")
        {
            objEntityLayerEndOfServiceLeaveStlmnt.EndSrvLveStlmntID = Convert.ToInt32(HiddenEndOfStlmntID.Value);
        }

        DataTable dtCorp = objBusinessLayerEndOfServiceLeaveStlmnt.ReadCorporateAddress(objEntityLayerEndOfServiceLeaveStlmnt);
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "", strCompanyLogo = "";

        string strTitle = "";
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

        DataTable dtEndOfServiceLeaveStlmnt = objBusinessLayerEndOfServiceLeaveStlmnt.ReadSrvLevStlmntByID(objEntityLayerEndOfServiceLeaveStlmnt);

        string strCurrentDate = objBusiness.LoadCurrentDateInString();
        dtCurrDate = objCommon.textToDateTime(strCurrentDate);

        string strEmployee_code = "";
        string strDATE_OF_JOIN = "";
        string strEmployee_name = "";
        string strBasic_salary = "";
        string strRemarks = "";
        string strDate_of_leaving = "";
        string strGratuity_days = "";

        
        string strSettledDate = "";
        string strMess_amount = "0";

        string strDeduction_amount = "0";
        strDeduction_amount = (Convert.ToDecimal(strMess_amount.Replace(",", "")) + Convert.ToDecimal(strDeduction_amount.Replace(",", ""))).ToString();

        DateTime dtEndDate = DateTime.MinValue;
        DateTime dtPreviousMonthDate = DateTime.MinValue;

        string strEmpId = "";
        if (dtEndOfServiceLeaveStlmnt.Rows.Count > 0)
        {
            dtEndDate = objCommon.textToDateTime(dtEndOfServiceLeaveStlmnt.Rows[0]["DATE_OF_LEAVING"].ToString());
            dtPreviousMonthDate = dtEndDate.AddMonths(-1);

            strDATE_OF_JOIN = dtEndOfServiceLeaveStlmnt.Rows[0]["EMPERDTL_JOIN_DATE"].ToString();
            if (dtEndOfServiceLeaveStlmnt.Rows[0]["EMPLOYEE"].ToString().Contains('-'))
            {
                strEmployee_name = dtEndOfServiceLeaveStlmnt.Rows[0]["EMPLOYEE"].ToString().Split('-')[1];
            }
            else
            {
                strEmployee_name = dtEndOfServiceLeaveStlmnt.Rows[0]["EMPLOYEE"].ToString();
            }
            strDate_of_leaving = dtEndOfServiceLeaveStlmnt.Rows[0]["DATE_OF_LEAVING"].ToString();
            strEmployee_code = dtEndOfServiceLeaveStlmnt.Rows[0]["USR_CODE"].ToString();


            strBasic_salary = dtEndOfServiceLeaveStlmnt.Rows[0]["BASIC_PAY"].ToString();

            strRemarks = dtEndOfServiceLeaveStlmnt.Rows[0]["COMMENTS_REMARKS"].ToString();
            strSettledDate = dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_LST_SETLMTDATE"].ToString();
            strEmpId = dtEndOfServiceLeaveStlmnt.Rows[0]["EMPOLYEE_ID"].ToString();
            objEntityLeavSettlmt.EmployeeId = Convert.ToInt32(strEmpId);
            objEntityLayerEndOfServiceLeaveStlmnt.EmployeeID = Convert.ToInt32(strEmpId);
            strGratuity_days = dtEndOfServiceLeaveStlmnt.Rows[0]["GRATUITY_ELIGIBLE_DAYS"].ToString();
        }
        string strNetAmount = "0";
        if (txtNetAmount.Text != "")
        {
            strNetAmount = txtNetAmount.Text;
        }
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        string strcurrenWord = objBusiness.ConvertCurrencyToWords(objEntityCommon, strNetAmount.Replace(",", ""));

        strNetAmount = String.Format(format, Convert.ToDecimal(strNetAmount));

        DateTime dtLastLeaveCurr = DateTime.MinValue;
        string dtDate = "";

        DateTime dtLastHiddenDate = DateTime.MinValue;
        
        DataTable dtEmpLastLeav = objBusinessLayerEndOfServiceLeaveStlmnt.ReadLastLeavDateEmp_Id(objEntityLayerEndOfServiceLeaveStlmnt);
        if (dtEmpLastLeav.Rows.Count > 0)
        {
            if (dtEmpLastLeav.Rows[0]["LEAVE_FROM_DATE"].ToString()!="")
            {
                dtLastHiddenDate = objCommon.textToDateTime(dtEmpLastLeav.Rows[0]["LEAVE_FROM_DATE"].ToString());
            }
            else if (dtEmpLastLeav.Rows.Count > 1)
            {
                if (dtEmpLastLeav.Rows[1]["LEAVE_FROM_DATE"].ToString() != "")
                {
                    dtLastHiddenDate = objCommon.textToDateTime(dtEmpLastLeav.Rows[1]["LEAVE_FROM_DATE"].ToString());
                }
            }
        }


        if (dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_LST_SETLMTDATE"].ToString() != "")
        {
            dtLastLeaveCurr = objCommon.textToDateTime(dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_LST_SETLMTDATE"].ToString());
        }
        else
        {
            DataTable dtLeavSettld = objBusinessLeavSettlmt.ReadLastSettldDt(objEntityLeavSettlmt);
            DateTime dtLastSettle = new DateTime();
            DateTime dtLastMonth = new DateTime();
            if (dtLeavSettld.Rows.Count > 0 && dtLeavSettld.Rows[0]["SRVCLVE_LST_SETLMTDATE"].ToString() != "")
            {
                dtLastSettle = objCommon.textToDateTime(dtLeavSettld.Rows[0]["SRVCLVE_LST_SETLMTDATE"].ToString());
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
                if (dtLastHiddenDate != DateTime.MinValue)
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

        objEnt1.Employee = Convert.ToInt32(dtEndOfServiceLeaveStlmnt.Rows[0]["EMPOLYEE_ID"].ToString());

        if (HiddenFieldFromDate.Value != "")
        {
            dtFinal = objCommon.textToDateTime(HiddenFieldFromDate.Value.ToString());
        }
        else
        {
            if (dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_LST_SETLMTDATE"].ToString() != "")
            {
                objEnt1.date = objCommon.textToDateTime(dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_LST_SETLMTDATE"].ToString());
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
            string strStartDate = "";
            strStartDate = dtEndOfServiceLeaveStlmnt.Rows[0]["EMPERDTL_JOIN_DATE"].ToString();
            dtFromDate2 = objCommon.textToDateTime(strStartDate);

            //if (dtFromDate2 > dtFinal && dtFromDate2 < dtLastLeaveCurr)
            //{
            //    dtFinal = dtFromDate2;
            //}
            if (dtFromDate2 > dtFinal && dtFromDate2 < dtLastLeaveCurr)
            {
                dtFinal = dtLastLeaveCurr;
            }

            DataTable dtCorpSal = objBusinessLeavSettlmt.ReadCorpSal(objEntityLeavSettlmt);
            DateTime dtCorpSalaryDate = objCommon.textToDateTime(dtCorpSal.Rows[0]["COPRT_SALARY_DATE"].ToString());
            if (dtCorpSalaryDate != DateTime.MinValue)
            {
                if (dtCorpSalaryDate > dtFinal && dtCorpSalaryDate < dtLastLeaveCurr)
                {
                    dtFinal = dtCorpSalaryDate;
                }
            }
        }

        
        DateTime dtFromDate = dtFinal;

        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        DateTime dtToDate = new DateTime();
        if (dtEndOfServiceLeaveStlmnt.Rows[0]["DATE_OF_LEAVING"].ToString() != "")
        {
            dtToDate = objCommon.textToDateTime(dtEndOfServiceLeaveStlmnt.Rows[0]["DATE_OF_LEAVING"].ToString());
        }


        DateTime dtCurrFromDate = dtFromDate;
        DateTime dtPrevToDate = new DateTime();
        DateTime dtprevFromDate = new DateTime();

        int MonthDiff = (dtToDate.Year * 12 + dtToDate.Month) - (dtFromDate.Year * 12 + dtFromDate.Month);

        if (MonthDiff == 1)
        {
            dtCurrFromDate = new DateTime(dtToDate.Year, dtToDate.Month, 1);
            dtPrevToDate = dtCurrFromDate.AddDays(-1);
            dtprevFromDate = new DateTime(dtPrevToDate.Year, dtPrevToDate.Month, 1);
            if (dtprevFromDate < dtFromDate)
            {
                dtprevFromDate = dtFromDate;
            }
        }
        int cursts = 0;
        Document document = new Document(PageSize.LETTER, 50f, 30f, 19f, 40f);

        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
        {
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

            string strImageName = "EOS_LaborCard_LS_" + HiddenEndOfStlmntID.Value + ".pdf";
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
            //fisrt cursts
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

                for (int intRowBodyCount = startMonth; intRowBodyCount <= numMonth; intRowBodyCount++)
                {
                    string EmDate = new DateTime(dtCurrFromDate.Year, dtCurrFromDate.Month, intRowBodyCount).ToString("dd-MM-yyyy");
                    DateTime ddate = objCommon.textToDateTime(EmDate);

                    cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
                    cls_Entity_Monthly_Salary_Process objEntPrcss = new cls_Entity_Monthly_Salary_Process();
                    objEntPrcss.date = ddate;
                    MonthName = ddate.ToString("MMMM");
                    objEntPrcss.Employee = objEntityLeavSettlmt.EmployeeId;
                    objEntPrcss.Month = dtCurrFromDate.Month;
                    objEntPrcss.Year = dtCurrFromDate.Year;
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
                pdfBodyTable.AddCell(new PdfPCell(new Phrase(dtEndOfServiceLeaveStlmnt.Rows[0]["USR_CODE"].ToString(), new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                pdfBodyTable.AddCell(new PdfPCell(new Phrase("DESIGNATION", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                pdfBodyTable.AddCell(new PdfPCell(new Phrase(dtEndOfServiceLeaveStlmnt.Rows[0]["DSGN_NAME"].ToString(), new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                pdfBodyTable.AddCell(new PdfPCell(new Phrase("MONTH & YEAR", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                pdfBodyTable.AddCell(new PdfPCell(new Phrase(MonthName.ToUpper() + " " + dtCurrFromDate.Year, new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                pdfBodyTable.AddCell(new PdfPCell(new Phrase("", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 2, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                pdfBodyTable.AddCell(new PdfPCell(new Phrase("EMPLOYEE NAME", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                if (dtEndOfServiceLeaveStlmnt.Rows[0]["EMPLOYEE"].ToString().Contains('-'))
                {
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(dtEndOfServiceLeaveStlmnt.Rows[0]["EMPLOYEE"].ToString().Split('-')[1], new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 3, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                else
                {
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(dtEndOfServiceLeaveStlmnt.Rows[0]["EMPLOYEE"].ToString(), new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 3, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                }

                pdfBodyTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 4, Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                document.Add(pdfBodyTable);

                document.Add(tableLayout);

                string gratuityAmt="", basicAmt = "", AllowaceAmt = "", AllowovertimeAmount = "", DedctionAmt = "", DedctionInstalmntAmnt = "", Total = "", OT_Hours = "", MessAmnt = "", LvArrearAmnt = "", CurrMonthBasic = "";
                Decimal decgratuityAmt1=0,TotalBasicAllow = 0, TotalDedctn = 0, netsalary = 0, AllowovertimeAmount1 = 0, AllowaceAmt1 = 0, basicAmt1 = 0, instlmntDedctionAmt = 0, deductnamt = 0;
                Decimal decMessAmnt = 0, decLvArrearAmnt = 0, decCurrMonthBasic = 0,decTotalAllwnce=0;
                Decimal decPrevArrAmnt = 0;


                basicAmt = dtEndOfServiceLeaveStlmnt.Rows[0]["BASIC_PAY"].ToString();
                CurrMonthBasic = dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_STLMT_BASICPAY"].ToString();
               // CurrMonthBasic = dtEndOfServiceLeaveStlmnt.Rows[0]["CUR_MONTH_SAL"].ToString();
                AllowaceAmt = dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_STLMT_ADDITION"].ToString();
                AllowovertimeAmount = dtEndOfServiceLeaveStlmnt.Rows[0]["SRVLVE_OT_ADDITION"].ToString();

                DedctionAmt = dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_STLMT_DEDUCTION"].ToString();
                DedctionInstalmntAmnt = dtEndOfServiceLeaveStlmnt.Rows[0]["SRVLVE_PYMT_DEDUCTION"].ToString();
                MessAmnt = dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_STLMT_MESSAMNT"].ToString();
                LvArrearAmnt = dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_LV_ARREAR_AMNT"].ToString();
                gratuityAmt = dtEndOfServiceLeaveStlmnt.Rows[0]["GRATUITY_AMOUNT"].ToString();

                Total = dtEndOfServiceLeaveStlmnt.Rows[0]["CUR_MONTH_SAL"].ToString();
                if (dtEndOfServiceLeaveStlmnt.Rows[0]["CUR_MONTH_SAL"].ToString() != "")
                {
                    if (dtEndOfServiceLeaveStlmnt.Rows[0]["SLRYALLCE_AMOUNT"].ToString() != "")
                    decTotalAllwnce = Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[0]["SLRYALLCE_AMOUNT"].ToString());
                }

                decPrevArrAmnt = Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_PREV_MNTH_ARR_AMT"].ToString());

                objEnt1.Orgid = objEntityLeavSettlmt.OrgId;
                objEnt1.CorpOffice = objEntityLeavSettlmt.CorpId;
                objEnt1.Month = dtCurrFromDate.Month;
                objEnt1.Year = dtCurrFromDate.Year;
                objEnt1.SavConf = 0;

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

                //if (gratuityAmt != "")
                //{
                //    decgratuityAmt1 = Convert.ToDecimal(gratuityAmt);
                //    TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(gratuityAmt);
                //}

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
                    netsalary = Convert.ToDecimal(Total) + TotOthrAddAmt + decgratuityAmt1 - TotOthrDeductAmt + decPrevArrAmnt;
                    //netsalary = netsalary + TotalBasicAllow - TotalDedctn;
                }

                //if (Total != "")
                //{
                //    netsalary = Convert.ToDecimal(Total);
                //    netsalary = netsalary + TotOthrAddAmt - decLvArrearAmnt - TotOthrDeductAmt;
                //}
                string FinalNetAmt = Math.Round(netsalary, 0).ToString();
                netsalary = Convert.ToDecimal(FinalNetAmt);
                //CRNCMST_ABBRV
                string strbasicAmt = objBusiness.AddCommasForNumberSeperation(basicAmt1.ToString("0.00"), objEntityCommon);
                string strCurrbasicAmt = objBusiness.AddCommasForNumberSeperation(Math.Round(decCurrMonthBasic, roundNum).ToString("0.00"), objEntityCommon);

                string strgratuityAmt1 = objBusiness.AddCommasForNumberSeperation(Math.Round(decgratuityAmt1, roundNum).ToString("0.00"), objEntityCommon);
                string strAllowaceAmt = objBusiness.AddCommasForNumberSeperation(Math.Round(AllowaceAmt1, roundNum).ToString("0.00"), objEntityCommon);
                string strAllowovertimeAmount = objBusiness.AddCommasForNumberSeperation(Math.Round(AllowovertimeAmount1, roundNum).ToString("0.00"), objEntityCommon);
                string strTotalBasicAllow = objBusiness.AddCommasForNumberSeperation(Math.Round(TotalBasicAllow, roundNum).ToString("0.00"), objEntityCommon);
                string strDeductnAmt = objBusiness.AddCommasForNumberSeperation(Math.Round(deductnamt, roundNum).ToString("0.00"), objEntityCommon);
                string strDeductnInstlmtAmount = objBusiness.AddCommasForNumberSeperation(Math.Round(instlmntDedctionAmt, roundNum).ToString("0.00"), objEntityCommon);
                string strTotalDedctn = objBusiness.AddCommasForNumberSeperation(Math.Round(TotalDedctn, roundNum).ToString("0.00"), objEntityCommon);
                string strnetsalary = objBusiness.AddCommasForNumberSeperation(netsalary.ToString("0.00"), objEntityCommon);
                string strMessAmnt = objBusiness.AddCommasForNumberSeperation(Math.Round(decMessAmnt, roundNum).ToString("0.00"), objEntityCommon);
                string strLvArrearAmnt = objBusiness.AddCommasForNumberSeperation(Math.Round(decLvArrearAmnt, roundNum).ToString("0.00"), objEntityCommon);
                string strTotalAllwnce = objBusiness.AddCommasForNumberSeperation(Math.Round(decTotalAllwnce, roundNum).ToString("0.00"), objEntityCommon);
                string strPrevArrAmt = objBusiness.AddCommasForNumberSeperation(Math.Round(decPrevArrAmnt, roundNum).ToString("0.00"), objEntityCommon);
                int daysInm = DateTime.DaysInMonth(dtCurrFromDate.Year, dtCurrFromDate.Month);
                decimal decPerHourSal = Convert.ToDecimal(basicAmt) / daysInm;
                if (decPerHourSal > 0)
                {
                    decPerHourSal = decPerHourSal / 8;
                }


                decimal NormalOTAmnt = NormlOT * NormalOvertmRatePrHr * decPerHourSal;
                decimal HolidayOTAmnt = HoldayOt * HolidayOvertmRatePrHr * decPerHourSal;
                
                string strNormalOT = String.Format(format, NormalOTAmnt);
                string strHolidayOT = String.Format(format, HolidayOTAmnt);


                string strNormalOTAmnt = objBusiness.AddCommasForNumberSeperation(Convert.ToDecimal(strNormalOT).ToString("0.00"), objEntityCommon);
                string strHolidayOTAmnt = objBusiness.AddCommasForNumberSeperation(Convert.ToDecimal(strHolidayOT).ToString("0.00"), objEntityCommon);

              //  int numCurrDays = (numMonth - startMonth) + 1;

                int numCurrDays = (numMonth);
                decimal PerDaySalCurr=Convert.ToDecimal(basicAmt) / daysInm;
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
                    sumtable.AddCell(new PdfPCell(new Phrase(strTotalAllwnce, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
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
                //if (Convert.ToDecimal(strgratuityAmt1) != 0)
                //{
                //    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                //    sumtable.AddCell(new PdfPCell(new Phrase("Gratuity Amount", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                //    sumtable.AddCell(new PdfPCell(new Phrase(strgratuityAmt1, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                //    sumtable.AddCell(new PdfPCell(new Phrase(strGratuity_days, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                //    sumtable.AddCell(new PdfPCell(new Phrase(strgratuityAmt1, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                //    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                //}
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

                //   sumtable.AddCell(cell);

                if (decPrevArrAmnt > 0)
                {
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    sumtable.AddCell(new PdfPCell(new Phrase("Arrear Amount", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(strPrevArrAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(strPrevArrAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
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
                sumtable.AddCell(new PdfPCell(new Phrase(strnetsalary + " " + dtEndOfServiceLeaveStlmnt.Rows[0]["CRNCMST_ABBRV"].ToString(), FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                if (pos2 > 280)
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
            //second MonthDiff
                            //Start:-Previous month
            if (MonthDiff == 1)
            {
                    document.NewPage();

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

                    PdfPCell cell_headLine = (new PdfPCell(new Phrase("________________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, });
                    cell_headLine.Padding = -5;
                    tableLine.AddCell(cell_headLine);
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
                        objEntPrcss.Employee = objEntityLeavSettlmt.EmployeeId;
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
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 4, Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("EMPLOYEE CODE", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(dtEndOfServiceLeaveStlmnt.Rows[0]["USR_CODE"].ToString(), new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("DESIGNATION", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(dtEndOfServiceLeaveStlmnt.Rows[0]["DSGN_NAME"].ToString(), new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("MONTH & YEAR", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(MonthName.ToUpper() + " " + dtCurrFromDate.Year, new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 2, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("EMPLOYEE NAME", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    if (dtEndOfServiceLeaveStlmnt.Rows[0]["EMPLOYEE"].ToString().Contains('-'))
                    {
                        pdfBodyTable.AddCell(new PdfPCell(new Phrase(dtEndOfServiceLeaveStlmnt.Rows[0]["EMPLOYEE"].ToString().Split('-')[1], new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 3, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    }
                    else
                    {
                        pdfBodyTable.AddCell(new PdfPCell(new Phrase(dtEndOfServiceLeaveStlmnt.Rows[0]["EMPLOYEE"].ToString(), new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 3, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    }

                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 4, Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    document.Add(pdfBodyTable);

                    document.Add(tableLayout);

                    string basicAmt = "", AllowaceAmt = "", AllowovertimeAmount = "", DedctionAmt = "", DedctionInstalmntAmnt = "", Total = "", OT_Hours = "", MessAmnt = "", LvArrearAmnt = "", CurrMonthBasic = "";
                    Decimal TotalBasicAllow = 0, TotalDedctn = 0, netsalary = 0, AllowovertimeAmount1 = 0, AllowaceAmt1 = 0, basicAmt1 = 0, instlmntDedctionAmt = 0, deductnamt = 0;
                    Decimal decMessAmnt = 0, decLvArrearAmnt = 0, decCurrMonthBasic = 0, decTotalAllwnce=0;

                    MessAmnt = dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_PREV_MESS_AMNT"].ToString();
                    
                    basicAmt = dtEndOfServiceLeaveStlmnt.Rows[0]["BASIC_PAY"].ToString();
                    CurrMonthBasic = dtEndOfServiceLeaveStlmnt.Rows[0]["BASIC_PREV"].ToString();

                    AllowaceAmt = dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_PREV_ADDITION"].ToString();
                    AllowovertimeAmount = dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_PREV_OVERTIME_AMNT"].ToString();

                    DedctionAmt = dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_PREV_DEDUCTION"].ToString();
                    DedctionInstalmntAmnt = dtEndOfServiceLeaveStlmnt.Rows[0]["SRVCLVE_PREV_PAYMENT_DEDUCT"].ToString();
                    Total = dtEndOfServiceLeaveStlmnt.Rows[0]["PREV_MONTH_SAL"].ToString();

                    if (dtEndOfServiceLeaveStlmnt.Rows[0]["CUR_MONTH_SAL"].ToString() != "")
                    {
                        if (dtEndOfServiceLeaveStlmnt.Rows[0]["SLRYALLCE_AMOUNT"].ToString() != "")
                        decTotalAllwnce = Convert.ToDecimal(dtEndOfServiceLeaveStlmnt.Rows[0]["SLRYALLCE_AMOUNT"].ToString());
                    }

                    objEnt1.Orgid = objEntityLeavSettlmt.OrgId;
                    objEnt1.CorpOffice = objEntityLeavSettlmt.CorpId;
                    objEnt1.Month = dtprevFromDate.Month;
                    objEnt1.Year = dtprevFromDate.Year;

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
                       // netsalary = netsalary + TotOthrAddAmt - decLvArrearAmnt - TotOthrDeductAmt;
                    }
                    string FinalNetAmt = Math.Round(netsalary, 0).ToString();
                    netsalary = Convert.ToDecimal(FinalNetAmt);
                    //CRNCMST_ABBRV

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
                    string strTotalAllwnce = objBusiness.AddCommasForNumberSeperation(Math.Round(decTotalAllwnce, roundNum).ToString("0.00"), objEntityCommon);

                    int daysInm = DateTime.DaysInMonth(dtprevFromDate.Year, dtprevFromDate.Month);
                    decimal decPerHourSal = Convert.ToDecimal(basicAmt) / daysInm;
                    if (decPerHourSal > 0)
                    {
                        decPerHourSal = decPerHourSal / 8;
                    }


                    decimal NormalOTAmnt = NormlOT * NormalOvertmRatePrHr * decPerHourSal;
                    decimal HolidayOTAmnt = HoldayOt * HolidayOvertmRatePrHr * decPerHourSal;

                    string strNormalOT = String.Format(format, NormalOTAmnt);
                    string strHolidayOT = String.Format(format, HolidayOTAmnt);


                    string strNormalOTAmnt = objBusiness.AddCommasForNumberSeperation(Convert.ToDecimal(strNormalOT).ToString("0.00"), objEntityCommon);
                    string strHolidayOTAmnt = objBusiness.AddCommasForNumberSeperation(Convert.ToDecimal(strHolidayOT).ToString("0.00"), objEntityCommon);

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
                        sumtable.AddCell(new PdfPCell(new Phrase(strTotalAllwnce, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
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
                    sumtable.AddCell(new PdfPCell(new Phrase(strnetsalary + " " + dtEndOfServiceLeaveStlmnt.Rows[0]["CRNCMST_ABBRV"].ToString(), FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    if (pos2 > 280)
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

            document.Close();

            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=EOS_LaborCard_LS_" + HiddenEndOfStlmntID.Value + ".pdf");
            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();
            Response.Close();
        }
    }
    public static decimal MonthSalaryArr(string strEmpId, DateTime dtFromDate, DateTime dtToDate, string strBasicPay, DataTable dtAllownce, DataTable dtDeductn, int BasicPayStatus, int FixedSts, string strCorp, string Org, string IndividualRound, int ZeroWorkFixed, int holiSts, int offSts)
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



        if (TotalDays > TotalLeaveCnt || ZeroWorkFixed == 1)
        {
            //Basic pay calculation       
            if (strBasicPay != "" )
            {
                decBasicPay = Convert.ToDecimal(strBasicPay) / daysInm;
                if (BasicPayStatus == 0)
                {
                    if (ZeroWorkFixed == 0)
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