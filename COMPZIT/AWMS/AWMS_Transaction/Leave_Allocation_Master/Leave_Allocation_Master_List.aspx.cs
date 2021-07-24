
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
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using System.Web.Services;
// CREATED BY:EVM-0008
// CREATED DATE:26/12/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class AWMS_AWMS_Transaction_Leave_Allocation_Master_Leave_Allocation_Master_List : System.Web.UI.Page
{
    DateTime currDateTime = new DateTime();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtCnclReason.Attributes.Add("onkeypress", "return isTag(event)");
        //ddlModalYear.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        //ddlEmployee.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        //ddlStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        if (!IsPostBack)
        {
            ModalYearLoad();
            EmployLoad();
            txtCnclReason.Attributes.Add("onkeypress", "return isTag(event)");
            int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableReOpen = 0;
            hiddenRoleAdd.Value = "0";
            hiddenRoleUpdate.Value = "0";
            hiddenRoleCancel.Value = "0";
            hiddenRoleReOpen.Value = "0";
            HiddenFieldConfirm.Value = "0";

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            string strCurrentDate = objBusiness.LoadCurrentDateInString();
            string[] strPrsntyr = strCurrentDate.Split('-');
            int intPrsntYear = Convert.ToInt32(strPrsntyr[2]);
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            currDateTime = objCommon.textToDateTime(strCurrentDate);
            intUserRoleRecall = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
            DataTable dtCancelRecall = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUserRoleRecall);
            if (dtCancelRecall.Rows.Count > 0)
            {
                intEnableRecall = 1;
                hiddenRoleRecall.Value = "1";
            }
            else
            {
                intEnableRecall = 0;
                hiddenRoleRecall.Value = "0";
            }

            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Leave_Allocation_Master);
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
                        hiddenRoleAdd.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleUpdate.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleCancel.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleReOpen.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        HiddenFieldConfirm.Value = "1";
                    }
                }
                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    divAdd.Visible = true;
                }
                else
                {
                    divAdd.Visible = false;
                }
                if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
                {
                    string strHidden = Request.QueryString["Srch"].ToString();
                    HiddenSearchField.Value = strHidden;
                    string[] strSearchFields = strHidden.Split(',');
                    string strddlyear = strSearchFields[0];
                    string strddlStatus = strSearchFields[1];
                    string strddlEmployee = strSearchFields[2];                 
                    string strCbxStatus = strSearchFields[3];
                    if (strddlyear != null && strddlyear != "")
                    {
                        if (ddlModalYear.Items.FindByValue(strddlyear) != null)
                        {
                            ddlModalYear.ClearSelection();
                            ddlModalYear.Items.FindByValue(strddlyear).Selected = true;
                        }
                    }
                    if (strddlEmployee != null && strddlEmployee != "")
                    {
                        if (ddlEmployee.Items.FindByValue(strddlEmployee) != null)
                        {
                            ddlEmployee.Items.FindByValue(strddlEmployee).Selected = true;
                        }
                    }
                    if (strddlStatus != null && strddlStatus != "")
                    {
                        if (ddlStatus.Items.FindByValue(strddlStatus) != null)
                        {
                            ddlStatus.Items.FindByValue(strddlStatus).Selected = true;
                        }
                    }
                    if (strCbxStatus == "1")
                    {
                        cbxCnclStatus.Checked = true;
                    }
                    else
                    {
                        cbxCnclStatus.Checked = false;
                    }
                }
                //Creating objects for business layer
                clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
                clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntLevAllocn.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntLevAllocn.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {   clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                              clsCommonLibrary.CORP_GLOBAL.FIXED_PAYRL_MODE_JOIN
                                                              };
                DataTable dtCorpDetail = new DataTable();
                dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                //when ReOpened
                if (Request.QueryString["ReOpId"] != null)
                {
                    string strRandomMixedId = Request.QueryString["ReOpId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);
                    objEntLevAllocn.LeavAllocn = Convert.ToInt32(strId);
                    objEntLevAllocn.User_Id = intUserId;
                    objEntLevAllocn.LeaveConfmn = 0;
                    DataTable dtLeavDetail = objBusLevAllocn.ReadLevAllctnById(objEntLevAllocn);
                    DataTable dtRejoin = objBusLevAllocn.ReadRejoin(objEntLevAllocn);
                    string strdateT = "", strFrmyr = "", strToyr = "";
                    DateTime datetmeFrm, datetmeTo;
                    decimal decLeavNum = 0, decFrmSec, decToSec, decDiffrnce, decRemF = 0, decRemT = 0;
                    if (dtLeavDetail.Rows.Count > 0)
                    {
                        if (dtLeavDetail.Rows[0]["LEAVE_CNFRM_STS"].ToString() == "1")
                        {

                            if (dtRejoin.Rows.Count == 0)
                            {

                                objEntLevAllocn.EmployeeId = Convert.ToInt32(dtLeavDetail.Rows[0]["USR_ID"].ToString());
                                objEntLevAllocn.Leave_Id = Convert.ToInt32(dtLeavDetail.Rows[0]["LEAVETYP_ID"].ToString());
                                decFrmSec = Convert.ToDecimal(dtLeavDetail.Rows[0]["LEAVE_FROM_SCTN"].ToString());
                                decLeavNum = Convert.ToDecimal(dtLeavDetail.Rows[0]["LEAVE_NUM_DAYS"]);
                                datetmeFrm = objCommon.textToDateTime(dtLeavDetail.Rows[0]["LEAVE_FROM_DATE"].ToString());
                                strFrmyr = datetmeFrm.ToString("dd-MM-yyyy");
                                strdateT = dtLeavDetail.Rows[0]["LEAVE_TO_DATE"].ToString();
                                //objEntLevAllocn.RemingLev=decLeavNum;
                                objEntLevAllocn.LeaveFrmDate = datetmeFrm;
                                if (strdateT != "")
                                {
                                    datetmeTo = objCommon.textToDateTime(dtLeavDetail.Rows[0]["LEAVE_TO_DATE"].ToString());
                                    strToyr = datetmeTo.ToString("dd-MM-yyyy");
                                    objEntLevAllocn.LeaveToDate = datetmeTo;
                                    decToSec = Convert.ToDecimal(dtLeavDetail.Rows[0]["LEAVE_TO_SCTN"].ToString());
                                    int intFromyr = 0, intToYr = 0;
                                    string strFrDate = strFrmyr.ToString();
                                    string[] Frmdt = strFrDate.Split('-');
                                    intFromyr = Convert.ToInt32(Frmdt[2]);
                                    string strToDate = strToyr.ToString();
                                    string[] Todt = strToDate.Split('-');
                                    intToYr = Convert.ToInt32(Todt[2]);
                                    if (intFromyr == intToYr)
                                    {
                                        objEntLevAllocn.LeaveFrmDate = datetmeFrm;
                                        //if (decFrmSec != 1)
                                        //{
                                        //    //objEntLevAllocn.RemingLev = decRemF;
                                        //    decRemF = decRemF + Convert.ToDecimal(0.5);

                                        //}
                                        //if (decToSec != 1)
                                        //{
                                        //    decRemT = decRemT + Convert.ToDecimal(0.5);
                                        //}
                                        //decDiffrnce = decRemF + decRemF;
                                        //decLeavNum = decLeavNum - decDiffrnce;
                                        objEntLevAllocn.RemingLev = decLeavNum;
                                        objBusLevAllocn.InsertReopnFrom(objEntLevAllocn);
                                    }
                                    else
                                    {
                                        DateTime today = objEntLevAllocn.LeaveFrmDate;
                                        int daysleft = new DateTime(today.Year, 12, 31).DayOfYear - today.DayOfYear;
                                        daysleft = daysleft + 1;
                                        decRemF = Convert.ToDecimal(daysleft);
                                        decDiffrnce = decLeavNum - daysleft;
                                        if (decFrmSec != 1)
                                        {

                                            decRemF = decRemF - Convert.ToDecimal(0.5);
                                            objEntLevAllocn.RemingLev = decRemF;
                                            objBusLevAllocn.InsertReopnFrom(objEntLevAllocn);

                                        }
                                        else
                                        {

                                            objEntLevAllocn.RemingLev = decRemF;
                                            objBusLevAllocn.InsertReopnFrom(objEntLevAllocn);

                                        }
                                        if (decToSec != 1)
                                        {
                                            decRemT = decRemT + Convert.ToDecimal(0.5);
                                            objEntLevAllocn.RemingLev = decDiffrnce - decRemT;
                                            objEntLevAllocn.LeaveFrmDate = objEntLevAllocn.LeaveToDate;
                                            objBusLevAllocn.InsertReopnFrom(objEntLevAllocn);
                                        }
                                        else
                                        {

                                            objEntLevAllocn.RemingLev = decDiffrnce;
                                            objEntLevAllocn.LeaveFrmDate = objEntLevAllocn.LeaveToDate;
                                            objBusLevAllocn.InsertReopnFrom(objEntLevAllocn);

                                        }


                                    }
                                }
                                else
                                {
                                    objEntLevAllocn.RemingLev = decLeavNum;
                                    objBusLevAllocn.InsertReopnFrom(objEntLevAllocn);
                                }
                                objBusLevAllocn.ReOpenLeavAlloctn(objEntLevAllocn);
                                if (HiddenSearchField.Value == "")
                                    Response.Redirect("Leave_Allocation_Master_List.aspx?InsUpd=ReOpen");
                                else
                                    Response.Redirect("Leave_Allocation_Master_List.aspx?InsUpd=ReOpen&Srch=" + this.HiddenSearchField.Value);
                            }
                            else
                            {

                                if (HiddenSearchField.Value == "")
                                    Response.Redirect("Leave_Allocation_Master_List.aspx?InsUpd=Already_Rejoined");
                                else
                                    Response.Redirect("Leave_Allocation_Master_List.aspx?InsUpd=Already_Rejoined&Srch=" + this.HiddenSearchField.Value);
                            }
                        }
                        else
                        {
                            if (HiddenSearchField.Value == "")
                                Response.Redirect("Leave_Allocation_Master_List.aspx?InsUpd=Already_ReOpened");
                            else
                                Response.Redirect("Leave_Allocation_Master_List.aspx?InsUpd=Already_ReOpened&Srch=" + this.HiddenSearchField.Value);
                        }
                    }
                }
                //when Confirmed
                if (Request.QueryString["ConfId"] != null)
                {
                    string strRandomMixedId = Request.QueryString["ConfId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntLevAllocn.LeavAllocn = Convert.ToInt32(strId);
                    objEntLevAllocn.User_Id = intUserId;
                    DataTable dtLeavDetail = objBusLevAllocn.ReadLevAllctnById(objEntLevAllocn);
                    string strdateT = "";
                    if (dtLeavDetail.Rows.Count > 0)
                    {
                        if (dtLeavDetail.Rows[0]["LEAVE_CNFRM_STS"].ToString() == "0")
                        {
                            decimal decHalfFrmday = 0, decHalfToDay = 0;
                            DateTime dateCurnt;

                            objEntLevAllocn.EmployeeId = Convert.ToInt32(dtLeavDetail.Rows[0]["USR_ID"].ToString());
                            objEntLevAllocn.Leave_Id = Convert.ToInt32(dtLeavDetail.Rows[0]["LEAVETYP_ID"].ToString());
                            objEntLevAllocn.LeaveFrmDate = objCommon.textToDateTime(dtLeavDetail.Rows[0]["LEAVE_FROM_DATE"].ToString());
                            dateCurnt = objEntLevAllocn.LeaveFrmDate;
                            objEntLevAllocn.LeaveFromSection = Convert.ToInt32(dtLeavDetail.Rows[0]["LEAVE_FROM_SCTN"].ToString());
                            if (objEntLevAllocn.LeaveFromSection != 1)
                            {
                                decHalfFrmday = Convert.ToDecimal(0.5);
                            }
                            strdateT = dtLeavDetail.Rows[0]["LEAVE_TO_DATE"].ToString();
                            if (strdateT != "")
                            {
                                objEntLevAllocn.LeaveToDate = objCommon.textToDateTime(dtLeavDetail.Rows[0]["LEAVE_TO_DATE"].ToString());
                                objEntLevAllocn.LeaveToSection = Convert.ToInt32(dtLeavDetail.Rows[0]["LEAVE_TO_SCTN"].ToString());
                                if (objEntLevAllocn.LeaveToSection != 1)
                                {
                                    decHalfToDay = Convert.ToDecimal(0.5);
                                }
                            }
                            else
                            {
                                objEntLevAllocn.LeaveToDate = DateTime.MinValue;
                            }
                            objEntLevAllocn.PaidLvStatus = Convert.ToInt32(dtLeavDetail.Rows[0]["LEAVE_SETTLEMNT_STATUS"].ToString());
                            objEntLevAllocn.EilgiblLeaveAlloctnSts = Convert.ToInt32(dtLeavDetail.Rows[0]["LEAVE_SETLMNT_ELIGIBLE_STS"].ToString());
                            objEntLevAllocn.NumOfLeave = Convert.ToDecimal(dtLeavDetail.Rows[0]["LEAVE_NUM_DAYS"].ToString());
                            string strhiddenFrmRem = "0", strhiddenremngNxtyrLv = "0", strhiddenOpeningLev = "0", strhiddenToRem = "0";
                            if (strdateT == "")
                            {
                                DataTable dataDt = objBusLevAllocn.ReadRemLeav(objEntLevAllocn);
                                if (dataDt.Rows.Count > 0)
                                {
                                    strhiddenFrmRem = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                                    strhiddenremngNxtyrLv = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                                    strhiddenOpeningLev = dataDt.Rows[0]["OPENING_NUMLEAVE"].ToString();
                                }
                            }
                            else
                            {
                                int intFromyr = 0, intToYr = 0;
                                string strFrDate = dtLeavDetail.Rows[0]["LEAVE_FROM_DATE"].ToString();
                                string[] Frmdt = strFrDate.Split('-');
                                intFromyr = Convert.ToInt32(Frmdt[2]);
                                string strToDate = dtLeavDetail.Rows[0]["LEAVE_TO_DATE"].ToString();
                                string[] Todt = strToDate.Split('-');
                                intToYr = Convert.ToInt32(Todt[2]);
                                if (intFromyr == intToYr)
                                {
                                    DataTable dataDt = objBusLevAllocn.ReadRemLeav(objEntLevAllocn);
                                    if (dataDt.Rows.Count > 0)
                                    {
                                        strhiddenFrmRem = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                                        strhiddenremngNxtyrLv = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                                        strhiddenOpeningLev = dataDt.Rows[0]["OPENING_NUMLEAVE"].ToString();
                                    }
                                }
                                else
                                {

                                    decimal decYrlyLevFrm = 0, decYrlyLevTo = 0, decTotalYr = 0;
                                    string strremLeavFrm = "", strremLeavTo = "";
                                    DataTable dataDt = objBusLevAllocn.ReadRemLeav(objEntLevAllocn);
                                    if (dataDt.Rows.Count > 0)
                                    {
                                        strhiddenFrmRem = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                                        strhiddenOpeningLev = dataDt.Rows[0]["OPENING_NUMLEAVE"].ToString();
                                    }
                                    if (strremLeavFrm != "")
                                    {
                                        decYrlyLevFrm = Convert.ToDecimal(strremLeavFrm);
                                    }
                                    else
                                    {
                                        decYrlyLevFrm = Convert.ToDecimal(dataDt.Rows[0]["OPENING_NUMLEAVE"].ToString());
                                    }
                                    //objEntLevAllocn.LeaveFrmDate = objEntLevAllocn.LeaveToDate;
                                    DataTable dataDtt = objBusLevAllocn.ReadRemLeav(objEntLevAllocn);
                                    if (dataDtt.Rows.Count > 0)
                                    {
                                        strhiddenToRem = dataDtt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                                        strhiddenOpeningLev = dataDtt.Rows[0]["OPENING_NUMLEAVE"].ToString();
                                    }
                                    if (strremLeavTo != "")
                                    {
                                        decYrlyLevTo = Convert.ToDecimal(strremLeavTo);
                                    }
                                    else
                                    {
                                        if (dataDtt.Rows.Count > 0)
                                        {
                                            decYrlyLevTo = Convert.ToDecimal(dataDtt.Rows[0]["OPENING_NUMLEAVE"].ToString());
                                        }
                                    }
                                }
                            }
                          
                            //If there is no name like this on table.                             
                            bool HavingReportingOffcr = false;
                            if (dtLeavDetail.Rows[0]["EMPREPORTING"].ToString() != "0")
                            {
                              HavingReportingOffcr = true;
                            }
                            if (HavingReportingOffcr == true)
                            {
                                DataTable datatableFrmChk;
                                datatableFrmChk = objBusLevAllocn.CheckLeaveDates(objEntLevAllocn);
                                if (datatableFrmChk.Rows.Count == 0)
                                {                                 
                                    objEntLevAllocn.LeaveConfmn = 1;
                                    objBusLevAllocn.ConfirmLeavAllocnDtl(objEntLevAllocn);
                                    if (strdateT == "")
                                    {
                                        //string strchkuserlevCount = "0";
                                        //strchkuserlevCount = objBusLevAllocn.chkUserLevCount(objEntLevAllocn);
                                        decimal decRemainLeav = 0, decNoOfLeav = 0;
                                        decNoOfLeav = objEntLevAllocn.NumOfLeave;
                                        decimal decOpngLev = Convert.ToDecimal(strhiddenOpeningLev);
                                        objEntLevAllocn.OpeningLv = decOpngLev;
                                        decRemainLeav = Convert.ToDecimal(strhiddenremngNxtyrLv);
                                        decRemainLeav = decRemainLeav - decNoOfLeav;
                                        objEntLevAllocn.RemingLev = decRemainLeav;
                                        //if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                                        //{
                                        objBusLevAllocn.InsertUserLeavTyp(objEntLevAllocn);//updating balance leave of user
                                        //}
                                        //else
                                        //{
                                        //    objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                                        //}
                                    }
                                    else
                                    {
                                        int intFromyr = 0, intToYr = 0;
                                        string strFrDate = dtLeavDetail.Rows[0]["LEAVE_FROM_DATE"].ToString();
                                        string[] Frmdt = strFrDate.Split('-');
                                        intFromyr = Convert.ToInt32(Frmdt[2]);
                                        string strToDate = dtLeavDetail.Rows[0]["LEAVE_TO_DATE"].ToString();
                                        string[] Todt = strToDate.Split('-');
                                        intToYr = Convert.ToInt32(Todt[2]);
                                        if (intFromyr == intToYr)
                                        {
                                            decimal decRemainLeav = 0, decNoOfLeav = 0;
                                            decNoOfLeav = objEntLevAllocn.NumOfLeave;
                                            decimal decOpngLev = Convert.ToDecimal(strhiddenOpeningLev);
                                            objEntLevAllocn.OpeningLv = decOpngLev;
                                            decRemainLeav = Convert.ToDecimal(strhiddenremngNxtyrLv);
                                            decRemainLeav = decRemainLeav - decNoOfLeav;
                                            objEntLevAllocn.RemingLev = decRemainLeav;
                                            //string strchkuserlevCount = "0";
                                            //strchkuserlevCount = objBusLevAllocn.chkUserLevCount(objEntLevAllocn);
                                            //if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                                            //{
                                            objBusLevAllocn.InsertUserLeavTyp(objEntLevAllocn);//updating balance leave of user
                                            //}
                                            //else
                                            //{
                                            //    objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                                            //}
                                        }
                                        else
                                        {
                                            //string strchkFrmlevCount = "0", strchkTolevCount = "0";
                                            decimal decRemainLeav = 0, decNoOfLeav = 0, decMthRemday = 0, decNxtYrLev = 0;
                                            decNoOfLeav = objEntLevAllocn.NumOfLeave;
                                            decimal decOpngLev = Convert.ToDecimal(strhiddenOpeningLev);
                                            objEntLevAllocn.OpeningLv = decOpngLev;
                                            DateTime today = objEntLevAllocn.LeaveFrmDate;
                                            int daysleft = new DateTime(today.Year, 12, 31).DayOfYear - today.DayOfYear;
                                            daysleft = daysleft + 1;
                                            decimal decFromdaysleft = daysleft - decHalfFrmday;
                                            decMthRemday = decNoOfLeav - decFromdaysleft;
                                            decNxtYrLev = decMthRemday - decHalfToDay;
                                            //strchkFrmlevCount = objBusLevAllocn.chkUserLevCount(objEntLevAllocn);
                                            //strchkTolevCount = objBusLevAllocn.chkUserToLevCount(objEntLevAllocn);
                                            //if (strchkFrmlevCount != "0" && strchkFrmlevCount != "")
                                            //{
                                                decRemainLeav = Convert.ToDecimal(strhiddenFrmRem);
                                                decRemainLeav = decRemainLeav - decFromdaysleft;
                                                objEntLevAllocn.RemingLev = decRemainLeav;
                                                objBusLevAllocn.InsertUserLeavTyp(objEntLevAllocn);//updating balance leave of user

                                            //}
                                            //else
                                            //{
                                            //    decRemainLeav = Convert.ToDecimal(strhiddenFrmRem);
                                            //    decRemainLeav = decRemainLeav - decFromdaysleft;
                                            //    objEntLevAllocn.RemingLev = decRemainLeav;
                                            //    objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                                            //}
                                            //if (strchkTolevCount != "0" && strchkTolevCount != "")
                                            //{
                                                decRemainLeav = Convert.ToDecimal(strhiddenToRem);
                                                decRemainLeav = decRemainLeav - decNxtYrLev;
                                                objEntLevAllocn.RemingLev = decRemainLeav;
                                                //objEntLevAllocn.LeaveFrmDate = objEntLevAllocn.LeaveToDate;
                                                objBusLevAllocn.InsertUserLeavTyp(objEntLevAllocn);//updating balance leave of user
                                            //}
                                            //else
                                            //{
                                            //    decRemainLeav = Convert.ToDecimal(strhiddenToRem);
                                            //    decRemainLeav = decRemainLeav - decNxtYrLev;
                                            //    objEntLevAllocn.RemingLev = decRemainLeav;
                                                //objEntLevAllocn.LeaveFrmDate = objEntLevAllocn.LeaveToDate;
                                            //    objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                                            //}
                                        }
                                    }
                                    int BasicPayStatus = Convert.ToInt32(dtLeavDetail.Rows[0]["BASIC_PAY"].ToString());
                                    if (dtLeavDetail.Rows[0]["COPRT_SALARY_DATE"].ToString() != "")
                                    {
                                        DateTime dtFinal = objCommon.textToDateTime(dtLeavDetail.Rows[0]["COPRT_SALARY_DATE"].ToString());
                                        if (objEntLevAllocn.LeaveFrmDate >= dtFinal || objEntLevAllocn.LeaveToDate >= dtFinal)
                                            objBusLevAllocn.ArrearAmountUpd(objEntLevAllocn.EmployeeId, objEntLevAllocn.LeavAllocn, objEntLevAllocn.Leave_Id, objEntLevAllocn.Corporate_id, objEntLevAllocn.Organisation_id, objEntLevAllocn.LeaveFrmDate, objEntLevAllocn.LeaveToDate, objEntLevAllocn.LeaveFromSection, objEntLevAllocn.LeaveToSection, BasicPayStatus, dtLeavDetail.Rows[0]["FIXED_PAYRL_MODE_JOIN"].ToString(), dtLeavDetail.Rows[0]["EMPERDTL_JOIN_DATE"].ToString());
                                    }
                                    if (HiddenSearchField.Value == "")
                                        Response.Redirect("Leave_Allocation_Master_List.aspx?InsUpd=Confirm");
                                    else
                                        Response.Redirect("Leave_Allocation_Master_List.aspx?InsUpd=Confirm&Srch=" + this.HiddenSearchField.Value);
                                }
                                else
                                {
                                    if (HiddenSearchField.Value == "")
                                        Response.Redirect("Leave_Allocation_Master_List.aspx?InsUpd=DupCon");
                                    else
                                        Response.Redirect("Leave_Allocation_Master_List.aspx?InsUpd=DupCon&Srch=" + this.HiddenSearchField.Value);
                                }
                            }
                            else
                            {
                                if (HiddenSearchField.Value == "")
                                    Response.Redirect("Leave_Allocation_Master_List.aspx?InsUpd=NoOfcr");
                                else
                                    Response.Redirect("Leave_Allocation_Master_List.aspx?InsUpd=NoOfcr&Srch=" + this.HiddenSearchField.Value);
                            }
                        }
                        else
                        {
                            if (HiddenSearchField.Value == "")
                                Response.Redirect("Leave_Allocation_Master_List.aspx?InsUpd=Already_Confirmed");
                            else
                                Response.Redirect("Leave_Allocation_Master_List.aspx?InsUpd=Already_Confirmed&Srch=" + this.HiddenSearchField.Value);
                        }

                     }
                 }
                //when recalled
                if (Request.QueryString["ReId"] != null)
                {
                    string strRandomMixedId = Request.QueryString["ReId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntLevAllocn.LeavAllocn = Convert.ToInt32(strId);
                    objEntLevAllocn.User_Id = intUserId;

                    objEntLevAllocn.Date = currDateTime;

                    objBusLevAllocn.ReCallLeavAlloctndtl(objEntLevAllocn);
                    if (HiddenSearchField.Value == "")
                        Response.Redirect("Leave_Allocation_Master_List.aspx?InsUpd=Recl");
                    else
                        Response.Redirect("Leave_Allocation_Master_List.aspx?InsUpd=Recl&Srch=" + this.HiddenSearchField.Value);

                }

                if (Request.QueryString["Id"] != null)
                {//when Canceled

                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntLevAllocn.LeavAllocn = Convert.ToInt32(strId);
                    objEntLevAllocn.User_Id = intUserId;

                    objEntLevAllocn.Date = currDateTime;

                    if (dtCorpDetail.Rows.Count > 0)
                    {

                        string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                        if (CnclrsnMust == "0")
                        {
                            objEntLevAllocn.CancelReason = objCommon.CancelReason();


                            objBusLevAllocn.CancelLeavAlloctn(objEntLevAllocn);
                            if (HiddenSearchField.Value == "")
                            {
                                Response.Redirect("Leave_Allocation_Master_List.aspx?InsUpd=Cncl");
                            }
                            else
                            {
                                Response.Redirect("Leave_Allocation_Master_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
                            }

                        }
                        else
                        {
                            //DataTable dtLeavAllo = new DataTable();
                            //if (HiddenSearchField.Value == "")
                            //{
                            //    objEntLevAllocn.EmplySrch = 0;
                            //    objEntLevAllocn.StatsSrch = 2;
                            //    objEntLevAllocn.CancelStatus = 0;
                            //    objEntLevAllocn.YearSrch =  intPrsntYear; ;
                            //    objEntLevAllocn.LeavCatgry = 0;


                            //    dtLeavAllo = objBusLevAllocn.ReadLeavallocndtlBySearch(objEntLevAllocn);

                            //}

                            //else
                            //{
                            //    string strHidden = "";
                            //    strHidden = HiddenSearchField.Value;
                            //    string[] strSearchFields = strHidden.Split(',');

                            //    string strddlyear = strSearchFields[0];
                            //    string strddlStatus = strSearchFields[1];
                            //    string strddlEmployee = strSearchFields[2];

                            //    string strCbxStatus = strSearchFields[3];

                            //    objEntLevAllocn.StatsSrch = Convert.ToInt32(strddlStatus);
                            //    objEntLevAllocn.CancelStatus = Convert.ToInt32(strCbxStatus);
                              
                            //    if (strddlyear != intPrsntYear.ToString())
                            //    {
                            //        objEntLevAllocn.YearSrch = Convert.ToInt32(strddlyear);
                            //    }
                            //    else
                            //    {
                            //        objEntLevAllocn.YearSrch = intPrsntYear;
                            //    }
                            //    if (strddlEmployee != "--SELECT--")
                            //    {
                            //        objEntLevAllocn.EmplySrch = Convert.ToInt32(strddlEmployee);
                            //    }
                            //    else
                            //    {
                            //        objEntLevAllocn.EmplySrch = 0;
                            //    }
                            //    objEntLevAllocn.StatsSrch = Convert.ToInt32(strddlStatus);
                            //    objEntLevAllocn.CancelStatus = Convert.ToInt32(strCbxStatus);

                            //    objEntLevAllocn.LeavCatgry =0;

                            //    dtLeavAllo = objBusLevAllocn.ReadLeavallocndtlBySearch(objEntLevAllocn);


                            //}
                            //string strHtm = ConvertDataTableToHTML(dtLeavAllo, intEnableModify, intEnableCancel, intEnableRecall, intEnableReOpen);
                            //Write to divReport
                            //divReport.InnerHtml = strHtm;

                            hiddenRsnid.Value = strId;


                        }

                    }



                }

                else
                {
                    //to view
                    //DataTable dtLeavAllo = new DataTable();
                    //if (HiddenSearchField.Value == "")
                    //{

                    //    objEntLevAllocn.EmplySrch = 0;
                    //    objEntLevAllocn.StatsSrch = 2;
                    //    objEntLevAllocn.CancelStatus = 0;
                    //    objEntLevAllocn.YearSrch = intPrsntYear;
                    //    objEntLevAllocn.LeavCatgry = 0;
                    //    dtLeavAllo = objBusLevAllocn.ReadLeavallocndtlBySearch(objEntLevAllocn);

                    //}
                    //else
                    //{
                    //    string strHidden = "";
                    //    strHidden = HiddenSearchField.Value;
                    //    string[] strSearchFields = strHidden.Split(',');
                    //    string strddlyear = strSearchFields[0];
                    //    string strddlStatus = strSearchFields[1];
                    //    string strddlEmployee = strSearchFields[2];

                    //    string strCbxStatus = strSearchFields[3];


                    //    if (strddlyear != intPrsntYear.ToString())
                    //    {
                    //        objEntLevAllocn.YearSrch = Convert.ToInt32(strddlyear);
                    //    }
                    //    else
                    //    {
                    //        objEntLevAllocn.YearSrch = intPrsntYear;
                    //    }
                    //    if (strddlEmployee != "--SELECT--")
                    //    {
                    //        objEntLevAllocn.EmplySrch = Convert.ToInt32(strddlEmployee);
                    //    }
                    //    else
                    //    {
                    //        objEntLevAllocn.EmplySrch = 0;
                    //    }
                    //    objEntLevAllocn.StatsSrch = Convert.ToInt32(strddlStatus);
                    //    objEntLevAllocn.CancelStatus = Convert.ToInt32(strCbxStatus);
                    //    objEntLevAllocn.LeavCatgry = 0;
                    //    dtLeavAllo = objBusLevAllocn.ReadLeavallocndtlBySearch(objEntLevAllocn);


                    //}
                    //string strHtm = ConvertDataTableToHTML(dtLeavAllo, intEnableModify, intEnableCancel, intEnableRecall, intEnableReOpen);
                    //Write to divReport
                    //divReport.InnerHtml = strHtm;

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
                        else if (strInsUpd == "Cncl")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                        }
                        else if (strInsUpd == "Recl")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessRecall", "SuccessRecall();", true);
                        }
                        else if (strInsUpd == "ReOpen")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReOpen", "SuccessReOpen();", true);
                        }
                        else if (strInsUpd == "Already_ReOpened")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Already_ReOpened", "Already_ReOpened();", true);
                        }
                        else if (strInsUpd == "Already_Rejoined")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Already_Rejoined", "Already_Rejoined();", true);
                        }
                            
                        else if (strInsUpd == "Confirm")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirm", "SuccessConfirm();", true);
                        }
                        else if (strInsUpd == "Already_Confirmed")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Already_Confirmed", "Already_Confirmed();", true);
                        }
                        else if (strInsUpd == "NoOfcr")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "NoOfficer", "NoOfficer();", true);
                        }
                        else if (strInsUpd == "DupCon")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationConfm", "DuplicationConfm();", true);
                        }
                        
                    }
                }

            }


        }



    }
    protected void EmployLoad()
    {
        clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
        clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
        int intUserId;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntLevAllocn.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntLevAllocn.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["USERID"] != null)
        {
            objEntLevAllocn.User_Id = Convert.ToInt32(Session["USERID"].ToString());

            intUserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable DtLevAlloDetails = new DataTable();
        DtLevAlloDetails = objBusLevAllocn.ReadEmployeedtl(objEntLevAllocn);
        if (DtLevAlloDetails.Rows.Count > 0)
        {
            ddlEmployee.DataSource = DtLevAlloDetails;
            ddlEmployee.DataValueField = "USR_ID";
            ddlEmployee.DataTextField = "USR_NAME";
            ddlEmployee.DataBind();

        }
        ddlEmployee.Items.Insert(0, "--SELECT--");

    }
   
    protected void ModalYearLoad()
    {
        clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
        clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
        ddlModalYear.Items.Clear();
        // created object for business layer for compare the date
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        DataTable dtHolyr = new DataTable();
        int intchckfordate = 0;
        string strMaxyr, strMinyr;
        var currentYear = 0;
        var currentMaxYear = 0;
        string strCurrentDate = objBusiness.LoadCurrentDateInString();
        string[] Prsntyr = strCurrentDate.Split('-');
        currentYear = Convert.ToInt32(Prsntyr[2]);
        dtHolyr = objBusLevAllocn.ReadYr(objEntLevAllocn);
        if (dtHolyr.Rows.Count > 0 && dtHolyr.Rows[0]["DATEMAX"].ToString() != "")
        {
            strMaxyr = dtHolyr.Rows[0]["DATEMAX"].ToString();
            strMinyr = dtHolyr.Rows[1]["DATEMAX"].ToString();
            currentMaxYear = Convert.ToInt32(strMaxyr);



            int minyear = Convert.ToInt32(strMinyr);
            int IntDif = currentMaxYear - minyear;

            for (int range = IntDif; range >= 0; range--)
            {
                // Now just add an entry that's the current year minus the counter
                ddlModalYear.Items.Add((currentMaxYear - range).ToString());

            }
            foreach (ListItem li in ddlModalYear.Items)
            {
                if (li.Value == currentYear.ToString())
                {
                    intchckfordate++;
                }
            }
            if (intchckfordate == 0)
            {
                ddlModalYear.Items.Add((currentYear).ToString());
                SortDDL(ref this.ddlModalYear);
            }

        }
        else
        {
            string[] split = strCurrentDate.Split('-');
            currentYear = Convert.ToInt32(split[2]);
            ddlModalYear.Items.Add((currentYear).ToString());
        }


        //  ddlModalYear.Items.Insert(0, currentYear.ToString());
        ddlModalYear.ClearSelection();
        ddlModalYear.Items.FindByText(currentYear.ToString()).Selected = true;
    }

    private void SortDDL(ref DropDownList objDDL)
    {
        System.Collections.ArrayList textList = new System.Collections.ArrayList();
        System.Collections.ArrayList valueList = new System.Collections.ArrayList();


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

    public static string[] ConvertDataTableToHTML(DataTable dt, clsEntityLayerLeaveAllocationMaster objEntity, int intEnableModify, int intEnableCancel, int intRnableConfirm, int intEnableReOpen, int intEnableRecall, string HiddenSearch)
    {
        string[] strReturn = new string[2];
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        string strHeader = "";


        strHeader += "<th id=\"tdColumnHead_1\" onclick=\"SetOrderByValue(1)\" class=\"sorting thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>";
        strHeader += "<th id=\"tdColumnHead_2\" onclick=\"SetOrderByValue(2)\" class=\"sorting thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">EMPLOYEE NAME<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>";
        strHeader += "<th id=\"tdColumnHead_3\" onclick=\"SetOrderByValue(3)\" class=\"sorting thT\" style=\"width:15%; word-wrap:break-word; text-align: left;\">LEAVE TYPE<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>";
        strHeader += "<th id=\"tdColumnHead_4\" onclick=\"SetOrderByValue(4)\" class=\"sorting thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">FROM DATE<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>";
        strHeader += "<th id=\"tdColumnHead_5\" onclick=\"SetOrderByValue(5)\" class=\"sorting thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">TO DATE<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>";
        strHeader += "<th id=\"tdColumnHead_6\" onclick=\"SetOrderByValue(6)\" class=\"sorting thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">STATUS<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>";
     

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = ""; 

        //for assigning column for reopen
        int intConfirmedForHead = 0;
        int intReCallForTAble = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string ConfirmedTransaction = dt.Rows[intRowBodyCount]["STATUS"].ToString();
            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            if (ConfirmedTransaction == "CONFIRMED")
            {
                intConfirmedForHead = 1;
            }

            if (intCnclUsrId != 0)
            {
                intReCallForTAble = 1;
            }

        }

        int intLeaveCatgry = objEntity.LeavCatgry;
        if (intLeaveCatgry != 0)
        {
            //strHeader += "<th class=\"col-md-2\" style=\"word-wrap:break-word;\">VIEW</th>";
            strHeader += "<th class=\"thT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">VIEW</th>";        
        }
        if (intLeaveCatgry == 0)
        {       
            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))       
            {
                strHeader += "<th class=\"thT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">EDIT</th>";
            //strHeader += "<th class=\"col-md-2\" style=\"word-wrap:break-word;\">EDIT</th>";
            }


            if (intReCallForTAble == 0)
            {
                if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    strHeader += "<th class=\"thT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">DELETE</th>";
                    //strHeader += "<th class=\"col-md-2\" style=\"word-wrap:break-word;\">DELETE</th>";
                }
            }

            if (intReCallForTAble == 1)
            {
                if (intEnableRecall == 1)
                {
                    strHeader += "<th class=\"thT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">RECALL </th>";
                    //strHeader += "<th class=\"col-md-2\" style=\"word-wrap:break-word;\">RECALL</th>";
                }
            }

            if (intReCallForTAble == 0)
            {
                if (intRnableConfirm == 1 && objEntity.StatsSrch != 1)
                {
                    strHeader += "<th class=\"thT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">CONFIRM</th>";
                    //strHeader += "<th class=\"col-md-2\" style=\"word-wrap:break-word;\">CONFIRM</th>";
                }
            }

            if (intEnableReOpen == 1)
            {
                if (intConfirmedForHead == 1)
                {
                    //strHtml += "<th class=\"thT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">REOPEN </th>";
                    strHeader += "<th class=\"thT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">REOPEN</th>";
                }
            }
        }

        if (dt.Rows.Count > 0)
        {


            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                int intConfirmed;
                int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
                int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());
                string ConfirmedTransaction = dt.Rows[intRowBodyCount]["STATUS"].ToString();

                if (ConfirmedTransaction == "CONFIRMED")
                {
                    intConfirmed = 1;
                }
                else
                {
                    intConfirmed = 0;
                }


                strHtml += "<tr  >";


                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 1)
                    {

                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</td>";

                    }
                    if (intColumnBodyCount == 2)
                    {

                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word; text-align: left;\"  >" + dt.Rows[intRowBodyCount]["USR_NAME"].ToString() + "</td>";

                    }
                    if (intColumnBodyCount == 3)
                    {

                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word; text-align: left;\"  >" + dt.Rows[intRowBodyCount]["LEAVETYP_NAME"].ToString() + "</td>";

                    }
                    else if (intColumnBodyCount == 4)
                    {

                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount]["LEAVE_FROM_DATE"].ToString() + "</td>";

                    }
                    else if (intColumnBodyCount == 5)
                    {

                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount]["LEAVE_TO_DATE"].ToString() + "</td>";

                    }
                    else if (intColumnBodyCount == 6)
                    {

                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount]["STATUS"].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 7)
                    {
                        strHtml += "<td class=\"tdT datesort\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount]["INS_DATE"].ToString() + "</td>";
                    }
                }
                string strId = dt.Rows[intRowBodyCount]["LEAVE_ID"].ToString();
                int intIdLength = dt.Rows[intRowBodyCount]["LEAVE_ID"].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;



                //for checking ReOpen Provision Of Balance Amount limit
                clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
                clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
                clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                DateTime dateFrm, dateTo, dateCurnt;
                string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
                dateCurnt = objCommon.textToDateTime(strCurrentDate);
                int intFlag = 1;







                if (dt.Rows[intRowBodyCount]["PROCESSED_COUNT"].ToString() == "0")
                {
                    intFlag = 0;
                }

                if (dt.Rows[intRowBodyCount]["LEAVE_TO_DATE"] == DBNull.Value || dt.Rows[intRowBodyCount]["LEAVE_TO_DATE"].ToString() == null || dt.Rows[intRowBodyCount]["LEAVE_TO_DATE"].ToString() == "")
                {
                    dateFrm = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["LEAVE_FROM_DATE"].ToString());
                    if (dateCurnt >= dateFrm)
                    {
                        intFlag++;
                    }

                }
                else if (dt.Rows[intRowBodyCount]["LEAVE_TO_DATE"] != DBNull.Value || dt.Rows[intRowBodyCount]["LEAVE_TO_DATE"].ToString() != null || dt.Rows[intRowBodyCount]["LEAVE_TO_DATE"].ToString() != "")
                {


                    dateTo = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["LEAVE_TO_DATE"].ToString());
                    if (dateCurnt >= dateTo)
                    {
                        intFlag++;


                    }

                }




                objEntLevAllocn.LeavAllocn = Convert.ToInt32(strId);
                DataTable dtLevAllocDtls = new DataTable();
                dtLevAllocDtls = objBusLevAllocn.ReadLevAllctnById(objEntLevAllocn);
                int intReOpenPossible = 0;


                //To check leave id rejoin table
                DataTable dtRejoin = objBusLevAllocn.ReadRejoin(objEntLevAllocn);


                if (dtLevAllocDtls.Rows.Count > 0)
                {
                    int intcheck = Convert.ToInt32(dtLevAllocDtls.Rows[0]["LEAVE_CNFRM_STS"].ToString());

                    if (intcheck == 1 && dtRejoin.Rows.Count == 0)
                    {
                        intReOpenPossible = 1;
                    }
                }

                //clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
                //clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();

                //DataTable dtLevSettl = objBusinessLeavSettlmt.ReadLeavSettlmt(objEntityLeavSettlmt);

                //for (int intColumnBodyCountLev = 0; intColumnBodyCountLev < dtLevSettl.Rows.Count; intColumnBodyCountLev++)
                //{

                //    if (dtLevSettl.Rows[intColumnBodyCountLev]["USR_ID"].ToString() == dt.Rows[intRowBodyCount]["USR_ID"].ToString())
                //    {
                //        intReOpenPossible = 0;
                //    }
                //}


                if (dt.Rows[intRowBodyCount]["LEAVE_SETTLED_COUNT"].ToString() != "0")
                {
                    intReOpenPossible = 0;
                }




                if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    if (intCnclUsrId == 0 && intLeaveCatgry == 0)
                    {


                        strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\"   onclick='return getdetails(this.href);' " +
                              " href=\"Leave_Allocation_Master.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";


                    }

                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\"  onclick='return getdetails(this.href);' " +
                         " href=\"Leave_Allocation_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


                    }
                }

                if (intLeaveCatgry == 0)
                {

                    if (intReCallForTAble == 0)
                    {
                        if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            if (intCnclUsrId == 0)
                            {
                                if (intCancTransaction == 0)
                                {
                                    if (intConfirmed == 0)
                                    {
                                        if (HiddenSearch == "")
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\"  onclick='return CancelAlert(this.href);' " +
                                             " href=\"Leave_Allocation_Master_List.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\"  onclick='return CancelAlert(this.href);' " +
                                             " href=\"Leave_Allocation_Master_List.aspx?Id=" + Id + "&Srch=" + HiddenSearch + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                        }
                                    }
                                    else
                                    {

                                        strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >"
                                                + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";

                                    }
                                }
                                else
                                {

                                    strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >"
                                            + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";

                                }



                            }
                            else
                            {

                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                            }
                        }
                    }
                    if (intReCallForTAble == 1)
                    {
                        if (intEnableRecall == 1)
                        {
                            if (intCnclUsrId == 0)
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                            }
                            else
                            {

                                if (HiddenSearch == "")
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Recall\"  onclick='return ReCallAlert(this.href);' " +
                                     " href=\"Leave_Allocation_Master_List.aspx?ReId=" + Id + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Recall\"  onclick='return ReCallAlert(this.href);' " +
                                     " href=\"Leave_Allocation_Master_List.aspx?ReId=" + Id + "&Srch=" + HiddenSearch + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                                }


                            }
                        }
                    }

                    //confirm

                    if (intReCallForTAble == 0)
                    {
                        if (intRnableConfirm == 1 && objEntity.StatsSrch != 1)
                        {
                            if (intConfirmed == 0)
                            {
                                if (HiddenSearch == "")
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Confirm\"  onclick='return ConfirmAlert(this.href);' " +
                                     " href=\"Leave_Allocation_Master_List.aspx?ConfId=" + Id + "\">" + "<img  src='/Images/Icons/confirm.png' /> " + "</a> </td>";
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Confirm\"  onclick='return ConfirmAlert(this.href);' " +
                                     " href=\"Leave_Allocation_Master_List.aspx?ConfId=" + Id + "&Srch=" + HiddenSearch + "\">" + "<img  src='/Images/Icons/confirm.png' /> " + "</a> </td>";
                                }
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                            }
                        }
                    }

                    //confirm

                    if (intConfirmedForHead == 1)
                    {
                        if (intEnableReOpen == 1)
                        {
                            if (intCnclUsrId == 0)
                            {
                                if (intConfirmed == 1)
                                {
                                    if (intReOpenPossible == 1)
                                    {
                                        if (intFlag == 0 || intFlag == 1)
                                        {
                                            if (HiddenSearch == "")
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Re-open\"  onclick='return ReOpenAlert(this.href);' " +
                                                 " href=\"Leave_Allocation_Master_List.aspx?ReOpId=" + Id + "\">" + "<img  src='/Images/Icons/Re-open.png' /> " + "</a> </td>";
                                            }
                                            else
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Re-open\"  onclick='return ReOpenAlert(this.href);' " +
                                                 " href=\"Leave_Allocation_Master_List.aspx?ReOpId=" + Id + "&Srch=" + HiddenSearch + "\">" + "<img  src='/Images/Icons/Re-open.png' /> " + "</a> </td>";
                                            }
                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Re-open\" onclick='return ReOpenNotPossible();' >"
                                                     + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/Re-open.png' /> " + "</a> </td>";
                                        }
                                        //reopen_small.png
                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Re-open\" onclick='return ReOpenNotPossible();' >"
                                                  + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/Re-open.png' /> " + "</a> </td>";
                                    }

                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                                }

                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                            }
                        }
                    }
                }



                strHtml += "</tr>";
            }
        }
        else
        {
            strHtml += "<tr><td class=\"tdT\" colspan=\"9\" style=\"word-wrap:break-word;text-align: center;\">No data available in table</td></tr>";
        }
        strReturn[0] = strHeader;
        strReturn[1] = strHtml;
        return strReturn;
    }
    //at search button click
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableReOpen = 0;
        hiddenRoleAdd.Value = "0";
        hiddenRoleUpdate.Value = "0";
        hiddenRoleCancel.Value = "0";
        hiddenRoleReOpen.Value = "0";
        HiddenFieldConfirm.Value = "0";
     
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strCurrentDate = objBusiness.LoadCurrentDateInString();
        string[] strPrsntyr = strCurrentDate.Split('-');
        int intPrsntYear = Convert.ToInt32(strPrsntyr[2]);
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        //allocating provision for recall
        intUserRoleRecall = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
        DataTable dtCancelRecall = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUserRoleRecall);
        if (dtCancelRecall.Rows.Count > 0)
        {
            intEnableRecall = 1;
            hiddenRoleRecall.Value = "1";
        }
        else
        {
            intEnableRecall = 0;
            hiddenRoleRecall.Value = "0";
        }
        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Leave_Allocation_Master);
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
                    hiddenRoleAdd.Value = "1";
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                {
                    intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    hiddenRoleUpdate.Value = "1";
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                {
                    intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    hiddenRoleCancel.Value = "1";
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                {
                    intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    hiddenRoleReOpen.Value = "1";
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString())
                {
                    //future

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                {
                    HiddenFieldConfirm.Value = "1";

                }

            }

            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                divAdd.Visible = true;

            }
            else
            {

                divAdd.Visible = false;

            }

            //Creating objects for business layer

            clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
            clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntLevAllocn.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntLevAllocn.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }




            //to view
            DataTable dtLeavAllo = new DataTable();
            if (HiddenSearchField.Value == "")
            {
                objEntLevAllocn.EmplySrch = 0;
                objEntLevAllocn.StatsSrch = 2;
                objEntLevAllocn.CancelStatus = 0;
                objEntLevAllocn.YearSrch = intPrsntYear;
                dtLeavAllo = objBusLevAllocn.ReadLeavallocndtlBySearch(objEntLevAllocn);

            }

            else
            {
                string strHidden = "";
                strHidden = HiddenSearchField.Value;
                string[] strSearchFields = strHidden.Split(',');
                string strddlyear = strSearchFields[0];
                string strddlStatus = strSearchFields[1];
                string strddlEmployee = strSearchFields[2];

                string strCbxStatus = strSearchFields[3]; ;


                if (strddlyear != intPrsntYear.ToString())
                {
                    objEntLevAllocn.YearSrch = Convert.ToInt32(strddlyear);
                }
                else
                {
                    objEntLevAllocn.YearSrch = intPrsntYear;
                }
                if (strddlEmployee != "--SELECT--")
                {
                    objEntLevAllocn.EmplySrch = Convert.ToInt32(strddlEmployee);
                }
                else
                {
                    objEntLevAllocn.EmplySrch = 0;
                }
                objEntLevAllocn.StatsSrch = Convert.ToInt32(strddlStatus);
                objEntLevAllocn.CancelStatus = Convert.ToInt32(strCbxStatus);

                objEntLevAllocn.LeavCatgry = Convert.ToInt32(ddlLeaveCategory.SelectedValue.ToString()); 

                dtLeavAllo = objBusLevAllocn.ReadLeavallocndtlBySearch(objEntLevAllocn);


            }

            string strHtm = "";// ConvertDataTableToHTML(dtLeavAllo, intEnableModify, intEnableCancel, intEnableRecall, intEnableReOpen);
            //Write to divReport
            divReport.InnerHtml = strHtm;

            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessInsertion", "SuccessInsertion();", true);
                }
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
                //else if (strInsUpd == "Cncl")
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                //}
            }


        }
    }


    protected void btnRsnSave_Click(object sender, EventArgs e)
    {
        //Creating objects for business layer

        clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
        clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();

        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntLevAllocn.LeavAllocn = Convert.ToInt32(hiddenRsnid.Value);


            if (Session["USERID"] != null)
            {
                objEntLevAllocn.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            objEntLevAllocn.Date = currDateTime;

            objEntLevAllocn.CancelReason = txtCnclReason.Text.Trim();


            objBusLevAllocn.CancelLeavAlloctn(objEntLevAllocn);


            if (HiddenSearchField.Value == "")
            {
                Response.Redirect("Leave_Allocation_Master_List.aspx?InsUpd=Cncl");
            }
            else
            {
                Response.Redirect("Leave_Allocation_Master_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
            }


        }
    }

    //------------------------------------------Pagination------------------------------------------------

    [WebMethod]
    public static string[] GetData(string OrgId, string CorpId, string ddlCtgry, string ddlYear, string ddlEmployee, string ddlStatus, string CancelStatus, string EnableModify, string EnableCancel, string EnableConfirm, string EnableReopen,string EnableRecall,string HiddenSearch, string PageNumber, string PageMaxSize, string strCommonSearchTerm, string OrderColumn, string OrderMethod, string strInputColumnSearch)
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBussinessLayerLeaveAllocationMaster objBussiness = new clsBussinessLayerLeaveAllocationMaster();
        clsEntityLayerLeaveAllocationMaster objEntity = new clsEntityLayerLeaveAllocationMaster();
        string[] strResults = new string[3];
        if (OrgId != null && OrgId != "")
        {
            objEntity.Organisation_id = Convert.ToInt32(OrgId);
        }
        if (CorpId != null && CorpId != "")
        {
            objEntity.Corporate_id = Convert.ToInt32(CorpId);
        }
        if (ddlYear != "" && ddlYear!=null)
        {
            objEntity.YearSrch = Convert.ToInt32(ddlYear);
        }
        if (ddlEmployee != "--SELECT--")
        {
            objEntity.EmplySrch = Convert.ToInt32(ddlEmployee);
        }
        else
        {
            objEntity.EmplySrch = 0;
        }
        objEntity.StatsSrch = Convert.ToInt32(ddlStatus);
        objEntity.CancelStatus = Convert.ToInt32(CancelStatus);
        objEntity.LeavCatgry = Convert.ToInt32(ddlCtgry);

        objEntity.PageNumber = Convert.ToInt32(PageNumber);
        objEntity.PageMaxSize = Convert.ToInt32(PageMaxSize);
        objEntity.OrderMethod = Convert.ToInt32(OrderMethod);
        objEntity.OrderColumn = Convert.ToInt32(OrderColumn);
        objEntity.CommonSearchTerm = strCommonSearchTerm;

        var values = Enum.GetValues(typeof(SearchInputColumns));
        int intSearchColumnCount = values.Length;

        string[] strSearchInputs = new string[intSearchColumnCount];
        //— ‡
        if (strInputColumnSearch != "")
        {
            string[] InputColumnSearchList = strInputColumnSearch.Split('—');
            foreach (var InputColumnSearch in InputColumnSearchList)
            {
                string[] strColumnSrch = InputColumnSearch.Split('‡');
                int intColumnNo = Convert.ToInt32(strColumnSrch[0]);
                string strSearchString = strColumnSrch[1];

                if (intColumnNo <= intSearchColumnCount)
                {
                    strSearchInputs[intColumnNo] = strSearchString;
                }
            }
        }

        objEntity.searcEmpId = strSearchInputs[Convert.ToInt32(SearchInputColumns.EMPLOYEE_ID)];
        objEntity.SearchEmpName = strSearchInputs[Convert.ToInt32(SearchInputColumns.EMPLOYEE_NAME)];
        objEntity.SearchLeaveType = strSearchInputs[Convert.ToInt32(SearchInputColumns.LEAVE_TYPE)];
        objEntity.SearchFromDate = strSearchInputs[Convert.ToInt32(SearchInputColumns.FROM_DATE)];
        objEntity.SearchToDate = strSearchInputs[Convert.ToInt32(SearchInputColumns.TO_DATE)];
        objEntity.SearchStatus = strSearchInputs[Convert.ToInt32(SearchInputColumns.STATUS)];
        //ReadList
        DataTable dtLeavAllo = objBussiness.ReadLeavallocndtlBySearch(objEntity);

        int intEnableUpdate = Convert.ToInt32(EnableModify);
        int intEnableCancel = Convert.ToInt32(EnableCancel);
        int intEnableConfirm = Convert.ToInt32(EnableConfirm);
        int intEnableReopen = Convert.ToInt32(EnableReopen);
        int intEnableRecall = Convert.ToInt32(EnableRecall);

        string[] strTableContents = new string[2];
        strTableContents = ConvertDataTableToHTML(dtLeavAllo, objEntity, intEnableUpdate, intEnableCancel, intEnableConfirm, intEnableReopen, intEnableRecall, HiddenSearch);
        strResults[0] = strTableContents[0];
        strResults[1] = strTableContents[1];
        if (dtLeavAllo.Rows.Count > 0)
        {
            int intTotalItems = Convert.ToInt32(dtLeavAllo.Rows[0]["CNT"].ToString());
            int intCurrentRowCount = dtLeavAllo.Rows.Count;
            //Pagination
            strResults[2] = objBusinessLayer.GenereatePagination(intTotalItems, objEntity.PageNumber, objEntity.PageMaxSize, intCurrentRowCount);
        }

        return strResults;
    }

    [WebMethod]
    public static string[] LoadStaticDatafordt()//Filters
    {
        StringBuilder html = new StringBuilder();
        StringBuilder sbSearchInputColumns = new StringBuilder();

        string[] strResults = new string[3];
        html.Append("<div>");

        html.Append("<div class=\"col-md-2\">");//length
        html.Append("<p><span class=\"tbl_srt1\">Show</span> <select class=\"form-control tbl_srt\" onchange=\"getdata(1);\" id=\"ddl_page_size\">");
        html.Append("<option value=\"10\">10</option><option value=\"25\">25</option><option value=\"50\">50</option><option value=\"100\">100</option></select> entries");
        html.Append("</p></div>");
        //page length ends
        //common filter
        html.Append("<div class=\"col-md-2 pull-right\">");
        html.Append("<input  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"SettypingTimer();\" class=\"form-control tbl_ser_n\" id=\"txtCommonSearch_dt\"  type=\"search\" placeholder=\" Search \" aria-controls=\"example\">");
        html.Append("</div>");
        //common filter ends
        html.Append("</div>");
        strResults[0] = html.ToString();

        //custom search fields
        var values = Enum.GetValues(typeof(SearchInputColumns));
        int intSearchColumnCount = 0;

        //foreach (var item in values)
        //{
        //    if (Convert.ToInt32(item).ToString() == "0")
        //    {
        //        sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"EMPLOYEE ID\" placeholder=\"EMPLOYEE ID\"></th>");
        //    }
        //    else if (Convert.ToInt32(item).ToString() == "1")
        //    {
        //        sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in tr_c\" type=\"text\" title=\"EMPLOYEE NAME\" placeholder=\"EMPLOYEE NAME\"></th>");
        //    }
        //    else if (Convert.ToInt32(item).ToString() == "2")
        //    {
        //        sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"LEAVE TYPE\" placeholder=\"LEAVE TYPE\"></th>");
        //    }
        //    else if (Convert.ToInt32(item).ToString() == "3")
        //    {
        //        sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in tr_c\" type=\"text\" title=\"FROM DATE\" placeholder=\"FROM DATE\"></th>");
        //    }
        //    else if (Convert.ToInt32(item).ToString() == "4")
        //    {
        //        sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in tr_c\" type=\"text\" title=\"TO DATE\" placeholder=\"TO DATE\"></th>");
        //    }
        //    else if (Convert.ToInt32(item).ToString() == "5")
        //    {
        //        sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in tr_c\" type=\"text\" title=\"STATUS\" placeholder=\"STATUS\"></th>");
        //    }
        //}
        //this is to adjust the non search  fields
        sbSearchInputColumns.Append("<td id=\"thPagingTable_thAdjuster\"></td>");
        strResults[1] = sbSearchInputColumns.ToString();
        strResults[2] = intSearchColumnCount.ToString();
        return strResults;
    }

    public enum SearchInputColumns
    {
        //Must be sequential 
        EMPLOYEE_ID = 0,
        EMPLOYEE_NAME = 1,
        LEAVE_TYPE = 2,
        FROM_DATE = 3,
        TO_DATE = 4,
        STATUS = 5,
    }
}