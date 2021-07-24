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
using EL_Compzit;
using BL_Compzit;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Globalization;
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_AWMS;

public partial class HCM_HCM_Master_hcm_PayrollSystem_hcm_Duty_Rejoin_hcm_Duty_Rejoin_List : System.Web.UI.Page
{
    public static DateTime dtCurreDate = new DateTime();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayerDutyRejoin objBusinessDutyRejoin = new clsBusinessLayerDutyRejoin();
            clsEntityLayerDutyRejoin objEntityDutyRejoin = new clsEntityLayerDutyRejoin();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

            int intUserId = 0, intUsrRolMstrId;

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityDutyRejoin.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityDutyRejoin.orgid = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }


            if (Session["USERID"] != null)
            {
                objEntityDutyRejoin.UserId = Convert.ToInt32(Session["USERID"].ToString());
                intUserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
            HiddenFieldCurrSysDate.Value = strCurrentDate;
            dtCurreDate = objCommon.textToDateTime(strCurrentDate);

            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Duty_Rejoin);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

         
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {

                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        HiddenFieldConfirmRole.Value = "1";
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                    {
                        HiddenFieldHRrole.Value = "1";
                    }

                }
            }
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.REJOIN_CONFIRMATION_MODE
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, objEntityDutyRejoin.CorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenFieldConfirmationMode.Value = dtCorpDetail.Rows[0]["REJOIN_CONFIRMATION_MODE"].ToString();
            }

        }

    }

   
   

    [WebMethod]
    public static void rejoinClick(string orgID, string corptID, string userID, string empID, string leaveId, string RejoinDate, string HandSts, string HalfDaySts)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerDutyRejoin objBusinessDutyRejoin = new clsBusinessLayerDutyRejoin();
        clsEntityLayerDutyRejoin objEntityDutyRejoin = new clsEntityLayerDutyRejoin();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();


        clsBusiness_UserRol_ChilDefntion objUserRol = new clsBusiness_UserRol_ChilDefntion();
        clsEntity_UserRol_ChilDefntion objUserEntity = new clsEntity_UserRol_ChilDefntion();
        objUserEntity.UserId = Convert.ToInt32(empID);
        objUserEntity.Employeeid = Convert.ToInt32(empID);
        DataTable dtUserRolProv = objUserRol.ReadUserRolProvsn(objUserEntity);
        if (dtUserRolProv.Rows.Count > 0)
        {
            foreach (DataRow Dr in dtUserRolProv.Rows)
            {
                objUserEntity.ChildRole = Convert.ToInt32(Dr["CHILDROL_NUM"].ToString());
                objUserEntity.AssgnUserid = Convert.ToInt32(Dr["USR_ID"].ToString());
                objUserEntity.AssgnUsrRol = Convert.ToInt32(Dr["USROL_ID"].ToString());
                objUserEntity.AssgnTempSts = Convert.ToInt32(Dr["CHILDROL_TEMP_STS"].ToString());
                objUserRol.UserRolesDeleteByAssgnUserid(objUserEntity);
            }

        }

        objEntityDutyRejoin.CorpId = Convert.ToInt32(corptID);
        objEntityDutyRejoin.orgid = Convert.ToInt32(orgID);
        objEntityDutyRejoin.UserId = Convert.ToInt32(userID);
        objEntityDutyRejoin.EmployeeId = Convert.ToInt32(empID);
        objEntityDutyRejoin.LeaveId = Convert.ToInt32(leaveId);
        objEntityDutyRejoin.PassHandOverSts = Convert.ToInt32(HandSts);
        objEntityDutyRejoin.RejoinDate = objCommon.textToDateTime(RejoinDate.Trim());
        objEntityDutyRejoin.UserDate = dtCurreDate;
        objEntityDutyRejoin.HalfdayStatus = Convert.ToInt32(HalfDaySts);
        objBusinessDutyRejoin.AddRejoin(objEntityDutyRejoin);    
    }
    [WebMethod]
    public static void ConfirmClick(string userID, string RejoinId, string RejoinStatus, string RejoinDate, string ConfMode, string RejoinEmpId)
    {
        decimal ComCnt = 0;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        //Check rejoined after monthly salary process
        cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
        cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
        objEnt.Employee = Convert.ToInt32(RejoinEmpId); ;
        DataTable dtLeavMonth1 = objBuss.ReadMonthlyLastDate(objEnt);
        int SalProcsSts = 1;
        if (dtLeavMonth1.Rows.Count > 0)
        {
            if (dtLeavMonth1.Rows[0]["SLPRCDMNTH_LST_SETTLD_DT"].ToString() != "")
            {
                if (objCommon.textToDateTime(RejoinDate.Trim()) <= objCommon.textToDateTime(dtLeavMonth1.Rows[0]["SLPRCDMNTH_LST_SETTLD_DT"].ToString()))
                {
                    SalProcsSts = 0;
                }
            }
        }
        clsBusinessLayerDutyRejoin objBusinessDutyRejoin = new clsBusinessLayerDutyRejoin();
        clsEntityLayerDutyRejoin objEntityDutyRejoin = new clsEntityLayerDutyRejoin();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        objEntityDutyRejoin.SalProcsSts = SalProcsSts;
        objEntityDutyRejoin.DutyRejoinId = Convert.ToInt32(RejoinId);
        objEntityDutyRejoin.UserId = Convert.ToInt32(userID);
        objEntityDutyRejoin.UserDate = dtCurreDate;
        if (RejoinStatus == "0")
        {
            objBusinessDutyRejoin.ConfirmRejoin(objEntityDutyRejoin);
        }
        else if (RejoinStatus == "1" && ConfMode == "0")
        {
            objBusinessDutyRejoin.ReporterConfirm(objEntityDutyRejoin);
        }
        else if (RejoinStatus == "2")
        {
            objEntityDutyRejoin.Status = Convert.ToInt32(ConfMode);
            objEntityDutyRejoin.RejoinDate = objCommon.textToDateTime(RejoinDate.Trim());
            objBusinessDutyRejoin.ReporterConfirmReject(objEntityDutyRejoin);
            if (ConfMode == "1")
            {

                try
                {
                    //Start:-Update leave details if leave To date is different
                    DataTable dtLeave = objBusinessDutyRejoin.ReadLeaveDetails(objEntityDutyRejoin);
                    if (dtLeave.Rows.Count > 0)
                    {
                        int LeaveFromSection = 0, LeaveToSection = 0, RejoinHalfDaySts = 0, LeavePage = 0;
                        LeavePage = Convert.ToInt32(dtLeave.Rows[0][1].ToString());
                        LeaveFromSection = Convert.ToInt32(dtLeave.Rows[0]["LEAVE_FROM_SCTN"].ToString());
                        if (dtLeave.Rows[0]["LEAVE_TO_SCTN"].ToString() != "" && dtLeave.Rows[0]["LEAVE_TO_SCTN"].ToString() != null)
                            LeaveToSection = Convert.ToInt32(dtLeave.Rows[0]["LEAVE_TO_SCTN"].ToString());
                        RejoinHalfDaySts = Convert.ToInt32(dtLeave.Rows[0]["HALFDAY_STATUS"].ToString());
                        DateTime dtRejoinDate = objCommon.textToDateTime(dtLeave.Rows[0]["DUTYREJOIN_DATE"].ToString());
                        DateTime dtLeaveFromDate = objCommon.textToDateTime(dtLeave.Rows[0]["LEAVE_FROM_DATE"].ToString());
                        DateTime dtLeaveToDate = new DateTime();
                        if (dtLeave.Rows[0]["LEAVE_TO_DATE"].ToString() != "" && dtLeave.Rows[0]["LEAVE_TO_DATE"].ToString() != null)
                            dtLeaveToDate = objCommon.textToDateTime(dtLeave.Rows[0]["LEAVE_TO_DATE"].ToString());

                        int HoliPaidSts = Convert.ToInt32(dtLeave.Rows[0]["LEAVETYP_HOLIDAY_PAID_STS"].ToString());
                        int OffPaidSts = Convert.ToInt32(dtLeave.Rows[0]["LEAVETYP_OFFDAY_PAID_STS"].ToString());
                        int NoDedCntSts = Convert.ToInt32(dtLeave.Rows[0]["LEAVETYP_EXC_SAL_PROC"].ToString());
                        int PaidLeaveSts = Convert.ToInt32(dtLeave.Rows[0]["PAID_LEAVE_STS"].ToString());

                        if ((dtRejoinDate == dtLeaveToDate.AddDays(1) && LeaveToSection == 1) || (dtRejoinDate == dtLeaveToDate && LeaveToSection == 2))
                        {
                        }
                        else
                        {

                           

                            decimal OffCount = 0, TotalDays = 0, LeaveReqstCount = 0;
                            dutyOf objDuty = new dutyOf();
                            DateTime datenow, enddate;
                            datenow = dtLeaveFromDate;
                            if (RejoinHalfDaySts == 1)
                            {
                                enddate = dtRejoinDate;
                            }
                            else
                            {
                                enddate = dtRejoinDate.AddDays(-1);
                            }

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
                                        string off = objDuty.CheckDutyOff(day, dtLeave.Rows[0]["ORG_ID"].ToString(), dtLeave.Rows[0]["CORPRT_ID"].ToString());
                                        if (off == "true")
                                        {
                                            OffCount = OffCount + 1;
                                        }
                                    }
                                }
                            }
                            
                            TotalDays = Convert.ToInt32((enddate - datenow).TotalDays) + 1;
                            if (RejoinHalfDaySts == 1)
                            {
                                TotalDays = TotalDays - (decimal)0.5;
                            }
                            if (LeaveFromSection > 1)
                            {
                                TotalDays = TotalDays - (decimal)0.5;
                            }
                            TotalDays = TotalDays - OffCount;
                            if (TotalDays < 0)
                                TotalDays = 0;

                            LeaveReqstCount = Convert.ToDecimal(dtLeave.Rows[0]["LEAVE_NUM_DAYS"].ToString());
                            if (LeaveReqstCount != TotalDays)
                            {
                                string[] arrLEave = new string[11];
                                arrLEave[0] = userID;
                                arrLEave[1] = RejoinId;
                                arrLEave[2] = dtLeave.Rows[0]["LEAVE_ID"].ToString();
                                arrLEave[3] = LeavePage.ToString();
                                if (enddate == dtLeaveFromDate)
                                {
                                    if (RejoinHalfDaySts == 1)
                                    {
                                        arrLEave[4] = "2";
                                    }
                                    else
                                    {
                                        arrLEave[4] = "1";
                                    }
                                    arrLEave[5] = "";
                                    arrLEave[6] = "";

                                }
                                else
                                {
                                    arrLEave[4] = LeaveFromSection.ToString();
                                    arrLEave[5] = enddate.ToString("dd-MM-yyyy");
                                    if (RejoinHalfDaySts == 1)
                                    {
                                        arrLEave[6] = "2";
                                    }
                                    else
                                    {
                                        arrLEave[6] = "1";
                                    }
                                }
                                arrLEave[7] = TotalDays.ToString();
                                arrLEave[8] = Convert.ToString(LeaveReqstCount - TotalDays);
                                arrLEave[9] = dtLeave.Rows[0]["CORPRT_ID"].ToString();
                                arrLEave[10] = dtLeave.Rows[0]["USR_ID"].ToString();
                                objBusinessDutyRejoin.updateLeaveInfo(arrLEave);

                                ComCnt = TotalDays;

                                decimal openLeave = Convert.ToDecimal(dtLeave.Rows[0]["LEAVETYP_NUMDAYS"].ToString());
                                decimal decOpngLev = openLeave;
                                //Update GN_USER_LEAVE_TYPES
                                clsBusinessLeaveRequest objBusinessLeaveRequest = new clsBusinessLeaveRequest();
                                clsEntityLeaveRequest objEntityLeaveRequest = new clsEntityLeaveRequest();
                                objEntityLeaveRequest.User_Id = Convert.ToInt32(dtLeave.Rows[0]["USR_ID"].ToString());
                                objEntityLeaveRequest.Leave_Id = Convert.ToInt32(dtLeave.Rows[0]["LEAVETYP_ID"].ToString());
                                objEntityLeaveRequest.OpeningLv = openLeave;

                                if (dtLeaveFromDate.Year == enddate.Year)
                                {
                                    decimal OffCount1 = 0, TotalDays1 = 0, TotalDays2 = 0, LeaveReqstCount1 = 0, LeaveReqstCount2 = 0, DiffCount1 = 0, DiffCount2 = 0;

                                    if (dtLeaveFromDate.Year == dtLeaveToDate.Year)
                                    {
                                        DiffCount1 = LeaveReqstCount - TotalDays;
                                        objEntityLeaveRequest.LeaveFrmDate = dtLeaveFromDate;
                                        string strchkuserlevCount = "0";
                                        strchkuserlevCount = objBusinessLeaveRequest.chkUserLevCount(objEntityLeaveRequest);
                                        objEntityLeaveRequest.LeaveFrmDate = dtLeaveFromDate;
                                        if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                                        {
                                            if (NoDedCntSts == 0)
                                            {
                                                objEntityLeaveRequest.RemingLev = DiffCount1;
                                                objBusinessDutyRejoin.InsertUserLeavTyp(objEntityLeaveRequest);
                                            }
                                        }
                                        else
                                        {
                                            if (NoDedCntSts == 0)
                                            {
                                                objEntityLeaveRequest.RemingLev = decOpngLev - TotalDays;
                                            }
                                            else
                                            {
                                                objEntityLeaveRequest.RemingLev = decOpngLev;
                                            }
                                            objBusinessLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);
                                        }
                                    }
                                    else
                                    {
                                        OffCount1 = 0;
                                        DateTime datenow2, enddate2;
                                        datenow2 = new DateTime(dtLeaveToDate.Year, 01, 01);
                                        enddate2 = dtLeaveToDate;

                                        if (HoliPaidSts == 1 || OffPaidSts == 1)
                                        {
                                            for (var day = datenow2; day <= enddate2; day = day.AddDays(1))
                                            {
                                                string hol = "false";
                                                if (HoliPaidSts == 1)
                                                {
                                                    hol = objDuty.checkholiday(day, datenow2, enddate2);
                                                    if (hol == "true")
                                                    {
                                                        OffCount1 = OffCount1 + 1;
                                                    }
                                                }
                                                if (OffPaidSts == 1 && hol != "true")
                                                {
                                                    string off = objDuty.CheckDutyOff(day, dtLeave.Rows[0]["ORG_ID"].ToString(), dtLeave.Rows[0]["CORPRT_ID"].ToString());
                                                    if (off == "true")
                                                    {
                                                        OffCount1 = OffCount1 + 1;
                                                    }
                                                }
                                            }
                                        }

                                        LeaveReqstCount2 = Convert.ToInt32((enddate2 - datenow2).TotalDays) + 1;
                                        if (LeaveToSection > 1)
                                        {
                                            LeaveReqstCount2 = LeaveReqstCount2 - (decimal)0.5;
                                        }
                                        LeaveReqstCount2 = LeaveReqstCount2 - OffCount1;
                                        if (LeaveReqstCount2 < 0)
                                            LeaveReqstCount2 = 0;


                                        DiffCount1 = LeaveReqstCount - LeaveReqstCount2;
                                        DiffCount1 = DiffCount1 - TotalDays;
                                        DiffCount2 = LeaveReqstCount2;


                                        string strchkFrmlevCount = "0", strchkTolevCount = "0";
                                        objEntityLeaveRequest.LeaveFrmDate = dtLeaveFromDate;
                                        strchkFrmlevCount = objBusinessLeaveRequest.chkUserLevCount(objEntityLeaveRequest);
                                        if (strchkFrmlevCount != "0" && strchkFrmlevCount != "")
                                        {
                                            if (NoDedCntSts == 0)
                                            {
                                                objEntityLeaveRequest.RemingLev = DiffCount1;
                                                objBusinessDutyRejoin.InsertUserLeavTyp(objEntityLeaveRequest);
                                            }
                                        }
                                        else
                                        {
                                            if (NoDedCntSts == 0)
                                            {
                                                objEntityLeaveRequest.RemingLev = decOpngLev - TotalDays;
                                            }
                                            else
                                            {
                                                objEntityLeaveRequest.RemingLev = decOpngLev;
                                            }
                                            objBusinessLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);
                                        }


                                        objEntityLeaveRequest.LeaveFrmDate = dtLeaveToDate;
                                        strchkTolevCount = objBusinessLeaveRequest.chkUserLevCount(objEntityLeaveRequest);
                                        if (strchkTolevCount != "0" && strchkTolevCount != "")
                                        {
                                            if (NoDedCntSts == 0)
                                            {
                                                objEntityLeaveRequest.RemingLev = DiffCount2;
                                                objBusinessDutyRejoin.InsertUserLeavTyp(objEntityLeaveRequest);
                                            }
                                        }
                                    }
                                }
                                else
                                {

                                    decimal OffCount1 = 0, TotalDays1 = 0, TotalDays2 = 0, LeaveReqstCount1 = 0, LeaveReqstCount2 = 0, DiffCount1 = 0, DiffCount2 = 0;


                                    DateTime datenow1, enddate1;
                                    datenow1 = dtLeaveFromDate;
                                    enddate1 = new DateTime(datenow1.Year, 12, 31);
                                    if (HoliPaidSts == 1 || OffPaidSts == 1)
                                    {
                                        for (var day = datenow1; day <= enddate1; day = day.AddDays(1))
                                        {
                                            string hol = "false";
                                            if (HoliPaidSts == 1)
                                            {
                                                hol = objDuty.checkholiday(day, datenow1, enddate1);
                                                if (hol == "true")
                                                {
                                                    OffCount1 = OffCount1 + 1;
                                                }
                                            }
                                            if (OffPaidSts == 1 && hol != "true")
                                            {
                                                string off = objDuty.CheckDutyOff(day, dtLeave.Rows[0]["ORG_ID"].ToString(), dtLeave.Rows[0]["CORPRT_ID"].ToString());
                                                if (off == "true")
                                                {
                                                    OffCount1 = OffCount1 + 1;
                                                }
                                            }
                                        }
                                    }

                                    TotalDays1 = Convert.ToInt32((enddate1 - datenow1).TotalDays) + 1;
                                    if (LeaveFromSection > 1)
                                    {
                                        TotalDays1 = TotalDays1 - (decimal)0.5;
                                    }
                                    TotalDays1 = TotalDays1 - OffCount1;
                                    if (TotalDays1 < 0)
                                        TotalDays1 = 0;

                                    TotalDays2 = TotalDays - TotalDays1;



                                    //Calculate old leave counts
                                    if (dtLeaveFromDate.Year == dtLeaveToDate.Year)
                                    {
                                        DiffCount1 = LeaveReqstCount - TotalDays1;
                                        DiffCount2 = TotalDays2;
                                    }
                                    else
                                    {
                                        OffCount1 = 0;
                                        DateTime datenow2, enddate2;
                                        datenow2 = new DateTime(dtLeaveToDate.Year, 01, 01);
                                        enddate2 = dtLeaveToDate;
                                        if (HoliPaidSts == 1 || OffPaidSts == 1)
                                        {
                                            for (var day = datenow2; day <= enddate2; day = day.AddDays(1))
                                            {
                                                string hol = "false";
                                                if (HoliPaidSts == 1)
                                                {
                                                    hol = objDuty.checkholiday(day, datenow2, enddate2);
                                                    if (hol == "true")
                                                    {
                                                        OffCount1 = OffCount1 + 1;
                                                    }
                                                }
                                                if (OffPaidSts == 1 && hol != "true")
                                                {
                                                    string off = objDuty.CheckDutyOff(day, dtLeave.Rows[0]["ORG_ID"].ToString(), dtLeave.Rows[0]["CORPRT_ID"].ToString());
                                                    if (off == "true")
                                                    {
                                                        OffCount1 = OffCount1 + 1;
                                                    }
                                                }
                                            }
                                        }

                                        LeaveReqstCount2 = Convert.ToInt32((enddate2 - datenow2).TotalDays) + 1;
                                        if (LeaveToSection > 1)
                                        {
                                            LeaveReqstCount2 = LeaveReqstCount2 - (decimal)0.5;
                                        }
                                        LeaveReqstCount2 = LeaveReqstCount2 - OffCount1;
                                        if (LeaveReqstCount2 < 0)
                                            LeaveReqstCount2 = 0;



                                        DiffCount1 = 0;
                                        DiffCount2 = LeaveReqstCount2 - TotalDays2;
                                    }



                                    string strchkFrmlevCount = "0", strchkTolevCount = "0";
                                    objEntityLeaveRequest.OpeningLv = decOpngLev;

                                    objEntityLeaveRequest.LeaveFrmDate = dtLeaveFromDate;
                                    strchkFrmlevCount = objBusinessLeaveRequest.chkUserLevCount(objEntityLeaveRequest);
                                    if (strchkFrmlevCount != "0" && strchkFrmlevCount != "")
                                    {
                                        if (NoDedCntSts == 0)
                                        {
                                            objEntityLeaveRequest.RemingLev = DiffCount1;
                                            objBusinessDutyRejoin.InsertUserLeavTyp(objEntityLeaveRequest);
                                        }
                                    }
                                    else
                                    {
                                        if (NoDedCntSts == 0)
                                        {
                                            objEntityLeaveRequest.RemingLev = decOpngLev - TotalDays1;
                                        }
                                        else
                                        {
                                            objEntityLeaveRequest.RemingLev = decOpngLev;
                                        }
                                        objBusinessLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);
                                    }


                                    objEntityLeaveRequest.LeaveFrmDate = enddate;
                                    strchkTolevCount = objBusinessLeaveRequest.chkUserLevCount(objEntityLeaveRequest);
                                    if (strchkTolevCount != "0" && strchkTolevCount != "")
                                    {
                                        if (NoDedCntSts == 0)
                                        {
                                            objEntityLeaveRequest.RemingLev = DiffCount2;
                                            objBusinessDutyRejoin.InsertUserLeavTyp(objEntityLeaveRequest);
                                        }
                                    }
                                    else
                                    {
                                        if (NoDedCntSts == 0)
                                        {
                                            objEntityLeaveRequest.RemingLev = decOpngLev - TotalDays2;
                                        }
                                        else
                                        {
                                            objEntityLeaveRequest.RemingLev = decOpngLev;
                                        }
                                        objBusinessLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);
                                    }
                                }
                            }
                        }
                        //Start:-Insert to GN_USER_LEAVE_TYPES
                        clsBusinessLeaveRequest objBusinessLeaveRequest1 = new clsBusinessLeaveRequest();
                        clsEntityLeaveRequest objEntityLeaveRequest1 = new clsEntityLeaveRequest();
                        if (dtLeave.Rows[0]["CORPRT_ID"].ToString() != "")
                        {
                            objEntityLeaveRequest1.Corporate_id = Convert.ToInt32(dtLeave.Rows[0]["CORPRT_ID"].ToString());
                        }
                        if (dtLeave.Rows[0]["ORG_ID"].ToString() != "")
                        {
                            objEntityLeaveRequest1.Organisation_id = Convert.ToInt32(dtLeave.Rows[0]["ORG_ID"].ToString());
                        }
                        if (dtLeave.Rows[0]["USR_ID"].ToString() != "")
                        {
                            objEntityLeaveRequest1.User_Id = Convert.ToInt32(dtLeave.Rows[0]["USR_ID"].ToString());
                        }
                        DataTable DtLevAlloDetails = objBusinessLeaveRequest1.ReadLeavTypdtl(objEntityLeaveRequest1);
                        DataTable DtUser = objBusinessLeaveRequest1.ReadUserDetails(objEntityLeaveRequest1);
                        string UsrDesg = DtUser.Rows[0]["DSGN_ID"].ToString();
                        string UsrJoinDate = DtUser.Rows[0]["EMPERDTL_JOIN_DATE"].ToString();
                        string UsrGender = DtUser.Rows[0]["EMPERDTL_GENDER"].ToString();
                        string UsrMrtlSts = DtUser.Rows[0]["EMPERDTL_MRTL_STS"].ToString();
                        string UsrPayGrd = DtUser.Rows[0]["PYGRD_ID"].ToString();

                        foreach (DataRow rowDepnt in DtLevAlloDetails.Rows)
                        {
                            string GendrChck = "false", MrtlChck = "false", DesgChck = "false", PayGrdChck = "false", ExpChck = "false";
                            objEntityLeaveRequest1.Leave_Id = Convert.ToInt32(rowDepnt["LEAVETYP_ID"].ToString());
                            DataTable dtGendrMrtSts = objBusinessLeaveRequest1.ReadGendrMrtSts(objEntityLeaveRequest1);
                            DataTable dtDesgDtls = objBusinessLeaveRequest1.ReadDesgDtls(objEntityLeaveRequest1);
                            DataTable dtPayGrdeDtls = objBusinessLeaveRequest1.ReadPayGrdedtls(objEntityLeaveRequest1);
                            DataTable dtExpDtls = objBusinessLeaveRequest1.ReadExpDtls(objEntityLeaveRequest1);

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

                                DateTime Dob = objCommon.textToDateTime(UsrJoinDate);
                                //ExpYears = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
                                ExpYears = (dtCurreDate.Month - Dob.Month) + 12 * (dtCurreDate.Year - Dob.Year);
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
                                        if (rowDesg[0].ToString() == "1")
                                        {
                                            if (ExpYears >= 0 && ExpYears <= 2)
                                            {
                                                ExpChck = "true";
                                            }
                                        }

                                        else if (rowDesg[0].ToString() == "2")
                                        {
                                            if (ExpYears >= 2 && ExpYears <= 4)
                                            {
                                                ExpChck = "true";
                                            }
                                        }

                                        else if (rowDesg[0].ToString() == "3")
                                        {
                                            if (ExpYears >= 4 && ExpYears <= 6)
                                            {
                                                ExpChck = "true";
                                            }
                                        }

                                        else if (rowDesg[0].ToString() == "4")
                                        {
                                            if (ExpYears >= 6 && ExpYears <= 8)
                                            {
                                                ExpChck = "true";
                                            }
                                        }

                                        else if (rowDesg[0].ToString() == "5")
                                        {
                                            if (ExpYears >= 8 && ExpYears <= 10)
                                            {
                                                ExpChck = "true";
                                            }
                                        }
                                        else if (rowDesg[0].ToString() == "6")
                                        {
                                            if (ExpYears >= 10 && ExpYears <= 15)
                                            {
                                                ExpChck = "true";
                                            }
                                        }
                                        else if (rowDesg[0].ToString() == "7")
                                        {
                                            if (ExpYears >= 15 && ExpYears <= 20)
                                            {
                                                ExpChck = "true";
                                            }
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
                            objEntityLeaveRequest1.LeaveFrmDate = dtRejoinDate;
                            objEntityLeaveRequest1.Leave_Id = Convert.ToInt32(DtLevAlloDetails.Rows[i]["LEAVETYP_ID"].ToString());
                            strchkuserlevCount = objBusinessLeaveRequest1.chkUserLevCount(objEntityLeaveRequest1);
                            objEntityLeaveRequest1.OpeningLv = Convert.ToDecimal(DtLevAlloDetails.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                            objEntityLeaveRequest1.RemingLev = Convert.ToDecimal(DtLevAlloDetails.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                            if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                            {
                            }
                            else
                            {
                                objBusinessLeaveRequest1.InsertUserNewLevRow(objEntityLeaveRequest1);
                            }
                        }
                        //End:-Insert to GN_USER_LEAVE_TYPES

                        if (PaidLeaveSts == 0 && ComCnt>0)
                        {
                            //Start:-Deduct eligibility days from GN_USER_LEAVE_TYPES
                            clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
                            clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
                            if (dtLeave.Rows[0]["CORPRT_ID"].ToString() != "")
                            {
                                objEntityLeavSettlmt.CorpId = Convert.ToInt32(dtLeave.Rows[0]["CORPRT_ID"].ToString());
                            }
                            if (dtLeave.Rows[0]["ORG_ID"].ToString() != "")
                            {
                                objEntityLeavSettlmt.OrgId = Convert.ToInt32(dtLeave.Rows[0]["ORG_ID"].ToString());
                            }
                            if (dtLeave.Rows[0]["USR_ID"].ToString() != "")
                            {
                                objEntityLeavSettlmt.EmployeeId = Convert.ToInt32(dtLeave.Rows[0]["USR_ID"].ToString());
                            }
                            DataTable dtEmpjoin = objBusinessLeavSettlmt.ReadJoinDt(objEntityLeavSettlmt);
                            DateTime dtJoinDate = new DateTime();
                            decimal CurrYearBalLeave = 0, NextYearBalLeave = 0;
                            decimal CurrYearDays = 0, NextYearDays = 0, JoinDateDays = 365;
                            decimal LeaveEligbleDays = 0;
                            if (dtEmpjoin.Rows.Count > 0 && dtEmpjoin.Rows[0]["EMPERDTL_JOIN_DATE"].ToString() != "")
                            {
                                dtJoinDate = objCommon.textToDateTime(dtEmpjoin.Rows[0]["EMPERDTL_JOIN_DATE"].ToString());
                                JoinDateDays = CalculateDays(dtJoinDate, new DateTime(dtJoinDate.Year, 12, 31));
                            }
                            if (dtRejoinDate.Year == dtLeaveFromDate.Year)
                            {
                                CurrYearDays = CalculateDays(dtLeaveFromDate, dtRejoinDate);
                            }
                            else
                            {
                                DateTime NewToDate = new DateTime(dtLeaveFromDate.Year, 12, 31);
                                CurrYearDays = CalculateDays(dtLeaveFromDate, NewToDate);

                                DateTime NewFromDate = new DateTime(dtRejoinDate.Year, 1, 1);
                                NextYearDays = CalculateDays(NewFromDate, dtRejoinDate);
                            }
                            objEntityLeavSettlmt.Year = dtRejoinDate.Year;
                            DataTable dtLeav = objBusinessLeavSettlmt.ReadEligibleLeaveCount(objEntityLeavSettlmt);
                            if (dtLeav.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtLeav.Rows.Count; i++)
                                {
                                    int dtDear = Convert.ToInt32(dtLeav.Rows[i]["USRLEAVTYP_YEAR"].ToString());
                                    if (dtLeav.Rows[i]["USRLEAVTYP_SETTLEMENT_LEAVE"].ToString() != "")
                                    {
                                        if (dtDear == dtLeaveFromDate.Year)
                                        {
                                            CurrYearBalLeave = Convert.ToDecimal(dtLeav.Rows[i]["USRLEAVTYP_SETTLEMENT_LEAVE"].ToString());
                                            if (dtJoinDate.Year == dtDear)
                                            {
                                                LeaveEligbleDays = (CurrYearBalLeave / JoinDateDays) * CurrYearDays;
                                            }
                                            else
                                            {
                                                LeaveEligbleDays = (CurrYearBalLeave / 365) * CurrYearDays;
                                            }
                                        }
                                        if (dtDear > dtLeaveFromDate.Year)
                                        {
                                            NextYearBalLeave = Convert.ToDecimal(dtLeav.Rows[i]["USRLEAVTYP_SETTLEMENT_LEAVE"].ToString());
                                            LeaveEligbleDays = (NextYearBalLeave / 365) * NextYearDays;
                                        }

                                        objEntityLeavSettlmt.LeaveTypeId = Convert.ToInt32(dtLeav.Rows[i]["LEAVETYP_ID"].ToString());
                                        objEntityLeavSettlmt.Year = dtDear;
                                        objEntityLeavSettlmt.BalanceLeave = LeaveEligbleDays;
                                        objBusinessLeavSettlmt.UpdateEligibleDaysCount(objEntityLeavSettlmt);

                                    }
                                }
                            }
                            //End:-Deduct eligibility days from GN_USER_LEAVE_TYPES
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
        else if (RejoinStatus == "3" || (RejoinStatus == "1" && ConfMode=="1"))
        {
            objBusinessDutyRejoin.HRconfirm(objEntityDutyRejoin);
            try
            {
                //Start:-Update leave details if leave To date is different
                DataTable dtLeave = objBusinessDutyRejoin.ReadLeaveDetails(objEntityDutyRejoin);
                if (dtLeave.Rows.Count > 0)
                {
                    int LeaveFromSection = 0, LeaveToSection = 0, RejoinHalfDaySts = 0, LeavePage = 0;
                    LeavePage = Convert.ToInt32(dtLeave.Rows[0][1].ToString());
                    LeaveFromSection = Convert.ToInt32(dtLeave.Rows[0]["LEAVE_FROM_SCTN"].ToString());
                    if (dtLeave.Rows[0]["LEAVE_TO_SCTN"].ToString() != "" && dtLeave.Rows[0]["LEAVE_TO_SCTN"].ToString() != null)
                        LeaveToSection = Convert.ToInt32(dtLeave.Rows[0]["LEAVE_TO_SCTN"].ToString());
                    RejoinHalfDaySts = Convert.ToInt32(dtLeave.Rows[0]["HALFDAY_STATUS"].ToString());
                    DateTime dtRejoinDate = objCommon.textToDateTime(dtLeave.Rows[0]["DUTYREJOIN_DATE"].ToString());
                    DateTime dtLeaveFromDate = objCommon.textToDateTime(dtLeave.Rows[0]["LEAVE_FROM_DATE"].ToString());
                    DateTime dtLeaveToDate = new DateTime();
                    if (dtLeave.Rows[0]["LEAVE_TO_DATE"].ToString() != "" && dtLeave.Rows[0]["LEAVE_TO_DATE"].ToString() != null)
                        dtLeaveToDate = objCommon.textToDateTime(dtLeave.Rows[0]["LEAVE_TO_DATE"].ToString());

                    int HoliPaidSts = Convert.ToInt32(dtLeave.Rows[0]["LEAVETYP_HOLIDAY_PAID_STS"].ToString());
                    int OffPaidSts = Convert.ToInt32(dtLeave.Rows[0]["LEAVETYP_OFFDAY_PAID_STS"].ToString());
                    int NoDedCntSts = Convert.ToInt32(dtLeave.Rows[0]["LEAVETYP_EXC_SAL_PROC"].ToString());
                    int PaidLeaveSts = Convert.ToInt32(dtLeave.Rows[0]["PAID_LEAVE_STS"].ToString());

                    if ((dtRejoinDate == dtLeaveToDate.AddDays(1) && LeaveToSection == 1) || (dtRejoinDate == dtLeaveToDate && LeaveToSection == 2))
                    {
                    }
                    else
                    {
                        decimal OffCount = 0, TotalDays = 0, LeaveReqstCount = 0;
                        dutyOf objDuty = new dutyOf();
                        DateTime datenow, enddate;
                        datenow = dtLeaveFromDate;
                        if (RejoinHalfDaySts == 1)
                        {
                            enddate = dtRejoinDate;
                        }
                        else
                        {
                            enddate = dtRejoinDate.AddDays(-1);
                        }
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
                                    string off = objDuty.CheckDutyOff(day, dtLeave.Rows[0]["ORG_ID"].ToString(), dtLeave.Rows[0]["CORPRT_ID"].ToString());
                                    if (off == "true")
                                    {
                                        OffCount = OffCount + 1;
                                    }
                                }
                            }
                        }

                        TotalDays = Convert.ToInt32((enddate - datenow).TotalDays) + 1;
                        if (RejoinHalfDaySts == 1)
                        {
                            TotalDays = TotalDays - (decimal)0.5;
                        }
                        if (LeaveFromSection > 1)
                        {
                            TotalDays = TotalDays - (decimal)0.5;
                        }
                        TotalDays = TotalDays - OffCount;
                        if (TotalDays < 0)
                            TotalDays = 0;

                        LeaveReqstCount = Convert.ToDecimal(dtLeave.Rows[0]["LEAVE_NUM_DAYS"].ToString());
                        if (LeaveReqstCount != TotalDays)
                        {
                            string[] arrLEave = new string[11];
                            arrLEave[0] = userID;
                            arrLEave[1] = RejoinId;
                            arrLEave[2] = dtLeave.Rows[0]["LEAVE_ID"].ToString();
                            arrLEave[3] = LeavePage.ToString();
                            if (enddate == dtLeaveFromDate)
                            {
                                if (RejoinHalfDaySts == 1)
                                {
                                    arrLEave[4] = "2";
                                }
                                else
                                {
                                    arrLEave[4] = "1";
                                }
                                arrLEave[5] = "";
                                arrLEave[6] = "";

                            }
                            else
                            {
                                arrLEave[4] = LeaveFromSection.ToString();
                                arrLEave[5] = enddate.ToString("dd-MM-yyyy");
                                if (RejoinHalfDaySts == 1)
                                {
                                    arrLEave[6] = "2";
                                }
                                else
                                {
                                    arrLEave[6] = "1";
                                }
                            }
                            arrLEave[7] = TotalDays.ToString();
                            arrLEave[8] = Convert.ToString(LeaveReqstCount - TotalDays);
                            arrLEave[9] = dtLeave.Rows[0]["CORPRT_ID"].ToString();
                            arrLEave[10] = dtLeave.Rows[0]["USR_ID"].ToString();
                            objBusinessDutyRejoin.updateLeaveInfo(arrLEave);

                            ComCnt = TotalDays;

                            decimal openLeave = Convert.ToDecimal(dtLeave.Rows[0]["LEAVETYP_NUMDAYS"].ToString());
                            decimal decOpngLev = openLeave;
                            //Update GN_USER_LEAVE_TYPES
                            clsBusinessLeaveRequest objBusinessLeaveRequest = new clsBusinessLeaveRequest();
                            clsEntityLeaveRequest objEntityLeaveRequest = new clsEntityLeaveRequest();
                            objEntityLeaveRequest.User_Id = Convert.ToInt32(dtLeave.Rows[0]["USR_ID"].ToString());
                            objEntityLeaveRequest.Leave_Id = Convert.ToInt32(dtLeave.Rows[0]["LEAVETYP_ID"].ToString());
                            objEntityLeaveRequest.OpeningLv = openLeave;

                            if (dtLeaveFromDate.Year == enddate.Year)
                            {
                                decimal OffCount1 = 0, TotalDays1 = 0, TotalDays2 = 0, LeaveReqstCount1 = 0, LeaveReqstCount2 = 0, DiffCount1 = 0, DiffCount2 = 0;

                                if (dtLeaveFromDate.Year == dtLeaveToDate.Year)
                                {
                                    DiffCount1 = LeaveReqstCount - TotalDays;
                                    objEntityLeaveRequest.LeaveFrmDate = dtLeaveFromDate;
                                    string strchkuserlevCount = "0";
                                    strchkuserlevCount = objBusinessLeaveRequest.chkUserLevCount(objEntityLeaveRequest);
                                    objEntityLeaveRequest.LeaveFrmDate = dtLeaveFromDate;
                                    if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                                    {
                                        if (NoDedCntSts == 0)
                                        {
                                            objEntityLeaveRequest.RemingLev = DiffCount1;
                                            objBusinessDutyRejoin.InsertUserLeavTyp(objEntityLeaveRequest);
                                        }
                                    }
                                    else
                                    {
                                        if (NoDedCntSts == 0)
                                        {
                                            objEntityLeaveRequest.RemingLev = decOpngLev - TotalDays;
                                        }
                                        else
                                        {
                                            objEntityLeaveRequest.RemingLev = decOpngLev;
                                        }
                                        objBusinessLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);
                                    }
                                }
                                else
                                {
                                    OffCount1 = 0;
                                    DateTime datenow2, enddate2;
                                    datenow2 = new DateTime(dtLeaveToDate.Year, 01, 01);
                                    enddate2 = dtLeaveToDate;
                                    if (HoliPaidSts == 1 || OffPaidSts == 1)
                                    {
                                        for (var day = datenow2; day <= enddate2; day = day.AddDays(1))
                                        {
                                            string hol = "false";
                                            if (HoliPaidSts == 1)
                                            {
                                                hol = objDuty.checkholiday(day, datenow2, enddate2);
                                                if (hol == "true")
                                                {
                                                    OffCount1 = OffCount1 + 1;
                                                }
                                            }
                                            if (OffPaidSts == 1 && hol != "true")
                                            {
                                                string off = objDuty.CheckDutyOff(day, dtLeave.Rows[0]["ORG_ID"].ToString(), dtLeave.Rows[0]["CORPRT_ID"].ToString());
                                                if (off == "true")
                                                {
                                                    OffCount1 = OffCount1 + 1;
                                                }
                                            }
                                        }
                                    }

                                    LeaveReqstCount2 = Convert.ToInt32((enddate2 - datenow2).TotalDays) + 1;
                                    if (LeaveToSection > 1)
                                    {
                                        LeaveReqstCount2 = LeaveReqstCount2 - (decimal)0.5;
                                    }
                                    LeaveReqstCount2 = LeaveReqstCount2 - OffCount1;
                                    if (LeaveReqstCount2 < 0)
                                        LeaveReqstCount2 = 0;


                                    DiffCount1 = LeaveReqstCount - LeaveReqstCount2;
                                    DiffCount1 = DiffCount1 - TotalDays;
                                    DiffCount2 = LeaveReqstCount2;


                                    string strchkFrmlevCount = "0", strchkTolevCount = "0";
                                    objEntityLeaveRequest.LeaveFrmDate = dtLeaveFromDate;
                                    strchkFrmlevCount = objBusinessLeaveRequest.chkUserLevCount(objEntityLeaveRequest);
                                    if (strchkFrmlevCount != "0" && strchkFrmlevCount != "")
                                    {
                                        if (NoDedCntSts == 0)
                                        {
                                            objEntityLeaveRequest.RemingLev = DiffCount1;
                                            objBusinessDutyRejoin.InsertUserLeavTyp(objEntityLeaveRequest);
                                        }
                                    }
                                    else
                                    {
                                        if (NoDedCntSts == 0)
                                        {
                                            objEntityLeaveRequest.RemingLev = decOpngLev - TotalDays;
                                        }
                                        else{
                                            objEntityLeaveRequest.RemingLev = decOpngLev;
                                         }
                                        objBusinessLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);
                                    }


                                    objEntityLeaveRequest.LeaveFrmDate = dtLeaveToDate;
                                    strchkTolevCount = objBusinessLeaveRequest.chkUserLevCount(objEntityLeaveRequest);
                                    if (strchkTolevCount != "0" && strchkTolevCount != "")
                                    {
                                        if (NoDedCntSts == 0)
                                        {
                                            objEntityLeaveRequest.RemingLev = DiffCount2;
                                            objBusinessDutyRejoin.InsertUserLeavTyp(objEntityLeaveRequest);
                                        }
                                    }
                                }
                            }
                            else
                            {

                                decimal OffCount1 = 0, TotalDays1 = 0, TotalDays2 = 0, LeaveReqstCount1 = 0, LeaveReqstCount2 = 0, DiffCount1 = 0, DiffCount2 = 0;


                                DateTime datenow1, enddate1;
                                datenow1 = dtLeaveFromDate;
                                enddate1 = new DateTime(datenow1.Year, 12, 31);
                                if (HoliPaidSts == 1 || OffPaidSts == 1)
                                {
                                    for (var day = datenow1; day <= enddate1; day = day.AddDays(1))
                                    {
                                        string hol = "false";
                                        if (HoliPaidSts == 1)
                                        {
                                            hol = objDuty.checkholiday(day, datenow1, enddate1);
                                            if (hol == "true")
                                            {
                                                OffCount1 = OffCount1 + 1;
                                            }
                                        }
                                        if (OffPaidSts == 1 && hol != "true")
                                        {
                                            string off = objDuty.CheckDutyOff(day, dtLeave.Rows[0]["ORG_ID"].ToString(), dtLeave.Rows[0]["CORPRT_ID"].ToString());
                                            if (off == "true")
                                            {
                                                OffCount1 = OffCount1 + 1;
                                            }
                                        }
                                    }
                                }


                                TotalDays1 = Convert.ToInt32((enddate1 - datenow1).TotalDays) + 1;
                                if (LeaveFromSection > 1)
                                {
                                    TotalDays1 = TotalDays1 - (decimal)0.5;
                                }
                                TotalDays1 = TotalDays1 - OffCount1;
                                if (TotalDays1 < 0)
                                    TotalDays1 = 0;

                                TotalDays2 = TotalDays - TotalDays1;



                                //Calculate old leave counts
                                if (dtLeaveFromDate.Year == dtLeaveToDate.Year)
                                {
                                    DiffCount1 = LeaveReqstCount - TotalDays1;
                                    DiffCount2 = TotalDays2;
                                }
                                else
                                {
                                    OffCount1 = 0;
                                    DateTime datenow2, enddate2;
                                    datenow2 = new DateTime(dtLeaveToDate.Year, 01, 01);
                                    enddate2 = dtLeaveToDate;
                                    if (HoliPaidSts == 1 || OffPaidSts == 1)
                                    {
                                        for (var day = datenow2; day <= enddate2; day = day.AddDays(1))
                                        {
                                            string hol = "false";
                                            if (HoliPaidSts == 1)
                                            {
                                                hol = objDuty.checkholiday(day, datenow2, enddate2);
                                                if (hol == "true")
                                                {
                                                    OffCount1 = OffCount1 + 1;
                                                }
                                            }
                                            if (OffPaidSts == 1 && hol != "true")
                                            {
                                                string off = objDuty.CheckDutyOff(day, dtLeave.Rows[0]["ORG_ID"].ToString(), dtLeave.Rows[0]["CORPRT_ID"].ToString());
                                                if (off == "true")
                                                {
                                                    OffCount1 = OffCount1 + 1;
                                                }
                                            }
                                        }
                                    }

                                    LeaveReqstCount2 = Convert.ToInt32((enddate2 - datenow2).TotalDays) + 1;
                                    if (LeaveToSection > 1)
                                    {
                                        LeaveReqstCount2 = LeaveReqstCount2 - (decimal)0.5;
                                    }
                                    LeaveReqstCount2 = LeaveReqstCount2 - OffCount1;
                                    if (LeaveReqstCount2 < 0)
                                        LeaveReqstCount2 = 0;



                                    DiffCount1 = 0;
                                    DiffCount2 = LeaveReqstCount2 - TotalDays2;
                                }



                                string strchkFrmlevCount = "0", strchkTolevCount = "0";
                                objEntityLeaveRequest.OpeningLv = decOpngLev;

                                objEntityLeaveRequest.LeaveFrmDate = dtLeaveFromDate;
                                strchkFrmlevCount = objBusinessLeaveRequest.chkUserLevCount(objEntityLeaveRequest);
                                if (strchkFrmlevCount != "0" && strchkFrmlevCount != "")
                                {
                                    if (NoDedCntSts == 0)
                                    {
                                        objEntityLeaveRequest.RemingLev = DiffCount1;
                                        objBusinessDutyRejoin.InsertUserLeavTyp(objEntityLeaveRequest);
                                    }
                                }
                                else
                                {
                                    if (NoDedCntSts == 0)
                                    {
                                        objEntityLeaveRequest.RemingLev = decOpngLev - TotalDays1;
                                    }
                                    else
                                    {
                                        objEntityLeaveRequest.RemingLev = decOpngLev;
                                    }
                                    objBusinessLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);
                                }


                                objEntityLeaveRequest.LeaveFrmDate = enddate;
                                strchkTolevCount = objBusinessLeaveRequest.chkUserLevCount(objEntityLeaveRequest);
                                if (strchkTolevCount != "0" && strchkTolevCount != "")
                                {
                                    if (NoDedCntSts == 0)
                                    {
                                        objEntityLeaveRequest.RemingLev = DiffCount2;
                                        objBusinessDutyRejoin.InsertUserLeavTyp(objEntityLeaveRequest);
                                    }
                                }
                                else
                                {
                                    if (NoDedCntSts == 0)
                                    {
                                        objEntityLeaveRequest.RemingLev = decOpngLev - TotalDays2;
                                    }
                                    else
                                    {
                                        objEntityLeaveRequest.RemingLev = decOpngLev;
                                    }
                                    objBusinessLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);
                                }
                            }
                        }
                    }


                    //Start:-Insert to GN_USER_LEAVE_TYPES
                    clsBusinessLeaveRequest objBusinessLeaveRequest1 = new clsBusinessLeaveRequest();
                    clsEntityLeaveRequest objEntityLeaveRequest1 = new clsEntityLeaveRequest();
                    if (dtLeave.Rows[0]["CORPRT_ID"].ToString() != "")
                    {
                        objEntityLeaveRequest1.Corporate_id = Convert.ToInt32(dtLeave.Rows[0]["CORPRT_ID"].ToString());
                    }
                    if (dtLeave.Rows[0]["ORG_ID"].ToString() != "")
                    {
                        objEntityLeaveRequest1.Organisation_id = Convert.ToInt32(dtLeave.Rows[0]["ORG_ID"].ToString());
                    }
                    if (dtLeave.Rows[0]["USR_ID"].ToString() != "")
                    {
                        objEntityLeaveRequest1.User_Id = Convert.ToInt32(dtLeave.Rows[0]["USR_ID"].ToString());
                    }
                    DataTable DtLevAlloDetails = objBusinessLeaveRequest1.ReadLeavTypdtl(objEntityLeaveRequest1);
                    DataTable DtUser = objBusinessLeaveRequest1.ReadUserDetails(objEntityLeaveRequest1);
                    string UsrDesg = DtUser.Rows[0]["DSGN_ID"].ToString();
                    string UsrJoinDate = DtUser.Rows[0]["EMPERDTL_JOIN_DATE"].ToString();
                    string UsrGender = DtUser.Rows[0]["EMPERDTL_GENDER"].ToString();
                    string UsrMrtlSts = DtUser.Rows[0]["EMPERDTL_MRTL_STS"].ToString();
                    string UsrPayGrd = DtUser.Rows[0]["PYGRD_ID"].ToString();

                    foreach (DataRow rowDepnt in DtLevAlloDetails.Rows)
                    {
                        string GendrChck = "false", MrtlChck = "false", DesgChck = "false", PayGrdChck = "false", ExpChck = "false";
                        objEntityLeaveRequest1.Leave_Id = Convert.ToInt32(rowDepnt["LEAVETYP_ID"].ToString());
                        DataTable dtGendrMrtSts = objBusinessLeaveRequest1.ReadGendrMrtSts(objEntityLeaveRequest1);
                        DataTable dtDesgDtls = objBusinessLeaveRequest1.ReadDesgDtls(objEntityLeaveRequest1);
                        DataTable dtPayGrdeDtls = objBusinessLeaveRequest1.ReadPayGrdedtls(objEntityLeaveRequest1);
                        DataTable dtExpDtls = objBusinessLeaveRequest1.ReadExpDtls(objEntityLeaveRequest1);

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

                            DateTime Dob = objCommon.textToDateTime(UsrJoinDate);
                            //ExpYears = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
                            ExpYears = (dtCurreDate.Month - Dob.Month) + 12 * (dtCurreDate.Year - Dob.Year);
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
                                    if (rowDesg[0].ToString() == "1")
                                    {
                                        if (ExpYears >= 0 && ExpYears <= 2)
                                        {
                                            ExpChck = "true";
                                        }
                                    }

                                    else if (rowDesg[0].ToString() == "2")
                                    {
                                        if (ExpYears >= 2 && ExpYears <= 4)
                                        {
                                            ExpChck = "true";
                                        }
                                    }

                                    else if (rowDesg[0].ToString() == "3")
                                    {
                                        if (ExpYears >= 4 && ExpYears <= 6)
                                        {
                                            ExpChck = "true";
                                        }
                                    }

                                    else if (rowDesg[0].ToString() == "4")
                                    {
                                        if (ExpYears >= 6 && ExpYears <= 8)
                                        {
                                            ExpChck = "true";
                                        }
                                    }

                                    else if (rowDesg[0].ToString() == "5")
                                    {
                                        if (ExpYears >= 8 && ExpYears <= 10)
                                        {
                                            ExpChck = "true";
                                        }
                                    }
                                    else if (rowDesg[0].ToString() == "6")
                                    {
                                        if (ExpYears >= 10 && ExpYears <= 15)
                                        {
                                            ExpChck = "true";
                                        }
                                    }
                                    else if (rowDesg[0].ToString() == "7")
                                    {
                                        if (ExpYears >= 15 && ExpYears <= 20)
                                        {
                                            ExpChck = "true";
                                        }
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
                        objEntityLeaveRequest1.LeaveFrmDate = dtRejoinDate;
                        objEntityLeaveRequest1.Leave_Id = Convert.ToInt32(DtLevAlloDetails.Rows[i]["LEAVETYP_ID"].ToString());
                        strchkuserlevCount = objBusinessLeaveRequest1.chkUserLevCount(objEntityLeaveRequest1);
                        objEntityLeaveRequest1.OpeningLv = Convert.ToDecimal(DtLevAlloDetails.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                        objEntityLeaveRequest1.RemingLev = Convert.ToDecimal(DtLevAlloDetails.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                        if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                        {
                        }
                        else
                        {
                            objBusinessLeaveRequest1.InsertUserNewLevRow(objEntityLeaveRequest1);
                        }
                    }
                    //End:-Insert to GN_USER_LEAVE_TYPES


                    if (PaidLeaveSts == 0 && ComCnt>0)
                    {
                    //Start:-Deduct eligibility days from GN_USER_LEAVE_TYPES
                    clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
                    clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
                    if (dtLeave.Rows[0]["CORPRT_ID"].ToString() != "")
                    {
                        objEntityLeavSettlmt.CorpId = Convert.ToInt32(dtLeave.Rows[0]["CORPRT_ID"].ToString());
                    }
                    if (dtLeave.Rows[0]["ORG_ID"].ToString() != "")
                    {
                        objEntityLeavSettlmt.OrgId = Convert.ToInt32(dtLeave.Rows[0]["ORG_ID"].ToString());
                    }
                    if (dtLeave.Rows[0]["USR_ID"].ToString() != "")
                    {
                        objEntityLeavSettlmt.EmployeeId = Convert.ToInt32(dtLeave.Rows[0]["USR_ID"].ToString());
                    }
                    DataTable dtEmpjoin = objBusinessLeavSettlmt.ReadJoinDt(objEntityLeavSettlmt);
                    DateTime dtJoinDate = new DateTime();
                    decimal CurrYearBalLeave = 0, NextYearBalLeave = 0;
                    decimal CurrYearDays = 0, NextYearDays = 0, JoinDateDays = 365;
                    decimal LeaveEligbleDays = 0;
                    if (dtEmpjoin.Rows.Count > 0 && dtEmpjoin.Rows[0]["EMPERDTL_JOIN_DATE"].ToString() != "")
                    {
                        dtJoinDate = objCommon.textToDateTime(dtEmpjoin.Rows[0]["EMPERDTL_JOIN_DATE"].ToString());
                        JoinDateDays = CalculateDays(dtJoinDate, new DateTime(dtJoinDate.Year, 12, 31));
                    }
                    if (dtRejoinDate.Year == dtLeaveFromDate.Year)
                    {
                        CurrYearDays = CalculateDays(dtLeaveFromDate, dtRejoinDate);
                    }
                    else
                    {
                        DateTime NewToDate = new DateTime(dtLeaveFromDate.Year, 12, 31);
                        CurrYearDays = CalculateDays(dtLeaveFromDate, NewToDate);

                        DateTime NewFromDate = new DateTime(dtRejoinDate.Year, 1, 1);
                        NextYearDays = CalculateDays(NewFromDate, dtRejoinDate);
                    }
                    objEntityLeavSettlmt.Year = dtRejoinDate.Year;
                    DataTable dtLeav = objBusinessLeavSettlmt.ReadEligibleLeaveCount(objEntityLeavSettlmt);
                    if (dtLeav.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtLeav.Rows.Count; i++)
                        {
                            int dtDear = Convert.ToInt32(dtLeav.Rows[i]["USRLEAVTYP_YEAR"].ToString());
                            if (dtLeav.Rows[i]["USRLEAVTYP_SETTLEMENT_LEAVE"].ToString() != "")
                            {
                                if (dtDear == dtLeaveFromDate.Year)
                                {
                                    CurrYearBalLeave = Convert.ToDecimal(dtLeav.Rows[i]["USRLEAVTYP_SETTLEMENT_LEAVE"].ToString());
                                    if (dtJoinDate.Year == dtDear)
                                    {
                                        LeaveEligbleDays = (CurrYearBalLeave / JoinDateDays) * CurrYearDays;
                                    }
                                    else
                                    {
                                        LeaveEligbleDays = (CurrYearBalLeave / 365) * CurrYearDays;
                                    }
                                }
                                if (dtDear > dtLeaveFromDate.Year)
                                {
                                    NextYearBalLeave = Convert.ToDecimal(dtLeav.Rows[i]["USRLEAVTYP_SETTLEMENT_LEAVE"].ToString());
                                    LeaveEligbleDays = (NextYearBalLeave / 365) * NextYearDays;
                                }

                                objEntityLeavSettlmt.LeaveTypeId = Convert.ToInt32(dtLeav.Rows[i]["LEAVETYP_ID"].ToString());
                                objEntityLeavSettlmt.Year = dtDear;
                                objEntityLeavSettlmt.BalanceLeave = LeaveEligbleDays;
                                objBusinessLeavSettlmt.UpdateEligibleDaysCount(objEntityLeavSettlmt);

                            }
                        }
                    }
                    //End:-Deduct eligibility days from GN_USER_LEAVE_TYPES
                     }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
    public static decimal CalculateDays(DateTime dtFrom, DateTime dtTo)
    {
        decimal TotalDays = Convert.ToInt32((dtTo - dtFrom).TotalDays) + 1;
        if (TotalDays > 365)
        {
            TotalDays = 365;
        }
        return TotalDays;
    }
    [WebMethod]
    public static void rejectRejoin(string userID, string RejoinId, string Reason)
    {
        clsBusinessLayerDutyRejoin objBusinessDutyRejoin = new clsBusinessLayerDutyRejoin();
        clsEntityLayerDutyRejoin objEntityDutyRejoin = new clsEntityLayerDutyRejoin();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        objEntityDutyRejoin.DutyRejoinId = Convert.ToInt32(RejoinId);
        objEntityDutyRejoin.UserId = Convert.ToInt32(userID);
        objEntityDutyRejoin.UserDate = dtCurreDate;
        objEntityDutyRejoin.RejectReason = Reason;
        objBusinessDutyRejoin.RejectRejoin(objEntityDutyRejoin);
      
    }
    [WebMethod]
    public static string ReportRead(string userID)
    {
       string strReportrId = "";
       clsBusinessLayerDutyRejoin objBusinessDutyRejoin = new clsBusinessLayerDutyRejoin();
       clsEntityLayerDutyRejoin objEntityDutyRejoin = new clsEntityLayerDutyRejoin();
       clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
       objEntityDutyRejoin.UserId = Convert.ToInt32(userID);
       DataTable dt=objBusinessDutyRejoin.ReportOfficerRead(objEntityDutyRejoin);
       if (dt.Rows.Count > 0)
       {
           strReportrId = dt.Rows[0][0].ToString();
       }
       return strReportrId;
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
            objEntLevAllocn.Organisation_id = Convert.ToInt32(orgid);
            objEntLevAllocn.Corporate_id = Convert.ToInt32(corpid);
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
            string strTodayDate = dtCurreDate.ToString("dd/MM/yyyy");

            DateTime DateTodayDate = new DateTime();
            DateTodayDate = objCommon.textToDateTime(strTodayDate);

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
}