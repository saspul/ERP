
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DL_Compzit;
using EL_Compzit;
using System.Data;
using DL_Compzit.DataLayer_AWMS;
using EL_Compzit.EntityLayer_AWMS;
using CL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Globalization;
// CREATED BY:EVM-0008
// CREATED DATE:21/12/2016
// REVIEWED BY:
// REVIEW DATE

namespace BL_Compzit.BusinessLayer_AWMS
{
    public class clsBussinessLayerLeaveAllocationMaster
    {
        public DataTable ReadEmployeedtl(clsEntityLayerLeaveAllocationMaster objEntLeavAllo)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerLevAllo = new clsDataLayerLeaveAllocationMaster();
            DataTable dtReadEmp = objDataLayerLevAllo.ReadEmployeedtl(objEntLeavAllo);
            return dtReadEmp;
        }

        public DataTable ReadLeavTypdtl(clsEntityLayerLeaveAllocationMaster objEntLeavAllo, int ExpChck)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerLevAllo = new clsDataLayerLeaveAllocationMaster();
            DataTable dtReadLeav = objDataLayerLevAllo.ReadLeavTypdtl(objEntLeavAllo, ExpChck);
            return dtReadLeav;
        }

        public DataTable ReadRemLeav(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerRemLeav = new clsDataLayerLeaveAllocationMaster();
            DataTable count = objDataLayerRemLeav.ReadRemLeav(objEntLev);
            return count;
        }
        public DataTable ReadOPeningLeav(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerRemLeav = new clsDataLayerLeaveAllocationMaster();
            DataTable count = objDataLayerRemLeav.ReadOPeningLeav(objEntLev);
            return count;
        }
        public void AddLeavAlloctnDetails(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayeraddlev = new clsDataLayerLeaveAllocationMaster();
            objDataLayeraddlev.AddLeavAlloctnDetails(objEntLev);

        }
        public void InsertUserLeavTyp(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayeraddlev = new clsDataLayerLeaveAllocationMaster();
            objDataLayeraddlev.InsertUserLeavTyp(objEntLev);

        }
        public void UpdateLeavAllocnDetls(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayeraddlev = new clsDataLayerLeaveAllocationMaster();
            objDataLayeraddlev.UpdateLeavAllocnDetls(objEntLev);

        }

        public void ConfirmLeavAllocnDtl(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayeraddlev = new clsDataLayerLeaveAllocationMaster();
            objDataLayeraddlev.ConfirmLeavAllocnDtl(objEntLev);

        }

        public void ReOpenLeavAlloctn(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayeraddlev = new clsDataLayerLeaveAllocationMaster();
            objDataLayeraddlev.ReOpenLeavAlloctn(objEntLev);

        }

        public DataTable ReadLevAllctnById(clsEntityLayerLeaveAllocationMaster objEntLeavAllo)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerLevAllo = new clsDataLayerLeaveAllocationMaster();
            DataTable dtReadLeav = objDataLayerLevAllo.ReadLevAllctnById(objEntLeavAllo);
            return dtReadLeav;
        }

        public void ReCallLeavAlloctndtl(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayeraddlev = new clsDataLayerLeaveAllocationMaster();
            objDataLayeraddlev.ReCallLeavAlloctndtl(objEntLev);

        }

        public void CancelLeavAlloctn(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayeraddlev = new clsDataLayerLeaveAllocationMaster();
            objDataLayeraddlev.CancelLeavAlloctn(objEntLev);

        }

        public DataTable ReadLeavallocndtlBySearch(clsEntityLayerLeaveAllocationMaster objEntLeavAllo)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerLevAllo = new clsDataLayerLeaveAllocationMaster();
            DataTable dtReadLeav = objDataLayerLevAllo.ReadLeavallocndtlBySearch(objEntLeavAllo);
            return dtReadLeav;
        }

        //0039
        public DataTable ReadLeaveAloctionDtls(clsEntityLayerLeaveAllocationMaster objEntLeavAllo)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerLevAllo = new clsDataLayerLeaveAllocationMaster();
            DataTable dtReadLeavDtls = objDataLayerLevAllo.ReadLeaveAloctionDtls(objEntLeavAllo);
            return dtReadLeavDtls;
        }
        //END

        public DataTable ReadYr(clsEntityLayerLeaveAllocationMaster objEntLeavAllo)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerLevAllo = new clsDataLayerLeaveAllocationMaster();
            DataTable dtReadLeav = objDataLayerLevAllo.ReadYr(objEntLeavAllo);
            return dtReadLeav;
        }

        public string chkUserLevCount(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerRemLeav = new clsDataLayerLeaveAllocationMaster();
            string count = objDataLayerRemLeav.chkUserLevCount(objEntLev);
            return count;
        }

        public DataTable ReadRemLeavNxtYr(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerRemLeav = new clsDataLayerLeaveAllocationMaster();
            DataTable count = objDataLayerRemLeav.ReadRemLeavNxtYr(objEntLev);
            return count;
        }

        public void InsertUserNewLevRow(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayeraddlev = new clsDataLayerLeaveAllocationMaster();
            objDataLayeraddlev.InsertUserNewLevRow(objEntLev);

        }


        public string chkUserToLevCount(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerRemLeav = new clsDataLayerLeaveAllocationMaster();
            string count = objDataLayerRemLeav.chkUserToLevCount(objEntLev);
            return count;
        }


        public DataTable HolidayChck(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerRemLeav = new clsDataLayerLeaveAllocationMaster();
            DataTable count = objDataLayerRemLeav.HolidayChck(objEntLev);
            return count;
        }

        public DataTable ReadHolidayCountSiglDate(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerRemLeav = new clsDataLayerLeaveAllocationMaster();
            DataTable count = objDataLayerRemLeav.ReadHolidayCountSiglDate(objEntLev);
            return count;
        }

        public DataTable ReadChckEmply(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerRemLeav = new clsDataLayerLeaveAllocationMaster();
            DataTable count = objDataLayerRemLeav.ReadChckEmply(objEntLev);
            return count;
        }

        public DataTable ReadHolidayCountSiglDateTo(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerRemLeav = new clsDataLayerLeaveAllocationMaster();
            DataTable count = objDataLayerRemLeav.ReadHolidayCountSiglDateTo(objEntLev);
            return count;
        }

        public DataTable ReadHolidayCountSiglDateFrm(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerRemLeav = new clsDataLayerLeaveAllocationMaster();
            DataTable count = objDataLayerRemLeav.ReadHolidayCountSiglDateFrm(objEntLev);
            return count;
        }

        public void InsertReopnFrom(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerRemLeav = new clsDataLayerLeaveAllocationMaster();
            objDataLayerRemLeav.InsertReopnFrom(objEntLev);

        }

        public string confmAllocnCount(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerRemLeav = new clsDataLayerLeaveAllocationMaster();
            string count = objDataLayerRemLeav.confmAllocnCount(objEntLev);
            return count;
        }


        public DataTable FrmSgleDate(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerRemLeav = new clsDataLayerLeaveAllocationMaster();
            DataTable count = objDataLayerRemLeav.FrmSgleDate(objEntLev);
            return count;
        }
        public DataTable ChkDatesInLeavReqst(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerRemLeav = new clsDataLayerLeaveAllocationMaster();
            DataTable count = objDataLayerRemLeav.ChkDatesInLeavReqst(objEntLev);
            return count;
        }


        public DataTable ReadUserDetails(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerRemLeav = new clsDataLayerLeaveAllocationMaster();
            DataTable count = objDataLayerRemLeav.ReadUserDetails(objEntLev);
            return count;
        }
        public DataTable ReadUserDetailsGnUser(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerRemLeav = new clsDataLayerLeaveAllocationMaster();
            DataTable count = objDataLayerRemLeav.ReadUserDetailsGnUser(objEntLev);
            return count;
        }
        public DataTable ReadWeeklyDutyOff(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerRemLeav = new clsDataLayerLeaveAllocationMaster();
            DataTable count = objDataLayerRemLeav.ReadWeeklyDutyOff(objEntLev);
            return count;
        }

        public DataTable ReadMonthlyDutyOff(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerRemLeav = new clsDataLayerLeaveAllocationMaster();
            DataTable count = objDataLayerRemLeav.ReadMonthlyDutyOff(objEntLev);
            return count;
        }


        public DataTable ReadHolidayDate(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerRemLeav = new clsDataLayerLeaveAllocationMaster();
            DataTable count = objDataLayerRemLeav.ReadHolidayDate(objEntLev);
            return count;
        }
        public DataTable ReadRejoin(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerRemLeav = new clsDataLayerLeaveAllocationMaster();
            DataTable count = objDataLayerRemLeav.ReadRejoin(objEntLev);
            return count;
        }
        public void InsLeaveArrearAmnt(clsEntityLayerLeaveAllocationMaster objEntLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayeraddlev = new clsDataLayerLeaveAllocationMaster();
            objDataLayeraddlev.InsLeaveArrearAmnt(objEntLev);

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

                    decimal cnt = 0;
                    clsBussinessLayerLeaveAllocationMaster_dutyOff objDuty = new clsBussinessLayerLeaveAllocationMaster_dutyOff();
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
                        if (objEnt2.DateStartDate <= LfrmDt && LToDt <= objEnt2.DateEndDate)
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
                            for (var day = datenow; day <= enddate; day = day.AddDays(1))
                            {
                                string hol = objDuty.checkholiday(day, datenow, enddate);
                                if (hol == "true")
                                {
                                    OffCount = OffCount + 1;
                                }
                                if (hol != "true")
                                {
                                    string off = objDuty.CheckDutyOff(day, objEnt2.CorpOffice.ToString(), objEnt2.Orgid.ToString());
                                    if (off == "true")
                                    {
                                        OffCount = OffCount + 1;
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
                            for (var day = datenow; day <= enddate; day = day.AddDays(1))
                            {
                                string hol = objDuty.checkholiday(day, datenow, enddate);
                                if (hol == "true")
                                {
                                    OffCount = OffCount + 1;
                                }
                                if (hol != "true")
                                {
                                    string off = objDuty.CheckDutyOff(day, objEnt2.CorpOffice.ToString(), objEnt2.Orgid.ToString());
                                    if (off == "true")
                                    {
                                        OffCount = OffCount + 1;
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
                            for (var day = datenow; day <= enddate; day = day.AddDays(1))
                            {
                                string hol = objDuty.checkholiday(day, datenow, enddate);
                                if (hol == "true")
                                {
                                    OffCount = OffCount + 1;
                                }
                                if (hol != "true")
                                {
                                    string off = objDuty.CheckDutyOff(day, objEnt2.CorpOffice.ToString(), objEnt2.Orgid.ToString());
                                    if (off == "true")
                                    {
                                        OffCount = OffCount + 1;
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


        public void ArrearAmountUpd(int UerId, int LeaveId, int LeaveTypId, int CorpId, int OrgId, DateTime dtFrom, DateTime dtTo, int FromSec, int ToSec, int BasicPaySts, string FixedPayrlSts, string joinDate)
        {
            int joinMnthSts = 0;
            clsCommonLibrary objCommon = new clsCommonLibrary();
            DateTime dtLastStl = new DateTime();
            DateTime dtFinal = new DateTime();
            cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
            cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
            objEnt.Employee = UerId;
            DataTable dtLeavMonth1 = objBuss.ReadMonthlyLastDate(objEnt);
            if (dtLeavMonth1.Rows.Count > 0)
            {
                if (dtLeavMonth1.Rows[0]["SLPRCDMNTH_LST_SETTLD_DT"].ToString() != "")
                {
                    dtFinal = objCommon.textToDateTime(dtLeavMonth1.Rows[0]["SLPRCDMNTH_LST_SETTLD_DT"].ToString());
                    if (FixedPayrlSts == "1")
                    {
                        DateTime dtJoin = objCommon.textToDateTime(joinDate);
                        if (dtJoin.Month == dtFinal.Month && dtFinal.Year == dtJoin.Year)
                        {
                            if (dtJoin.Day > 1)
                            {
                                joinMnthSts = 1;
                            }
                        }
                    }

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
                            joinMnthSts = 0;
                        }
                    }
                }
            }
            if (dtFinal != DateTime.MinValue && dtFrom <= dtFinal)
            {

                clsBusiness_Leave_Type objBusinessLeavetype = new clsBusiness_Leave_Type();
                clsEntity_Leave_Type ObjEntityLeaveType = new clsEntity_Leave_Type();
                ObjEntityLeaveType.intleave = LeaveTypId;
                DataTable dtLeaveTypDetail = objBusinessLeavetype.ReadLeavedetailsById(ObjEntityLeaveType);
                decimal cnt1 = 0, cnt2 = 0;
                int DaysMnth1 = 0, DaysMnth2 = 0;
                string strPaidLeave = dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_PAIDLEAVE"].ToString();
                if (dtLeaveTypDetail.Rows.Count > 0)
                {

                    clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
                    clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
                    objEntityLeavSettlmt.UserId = UerId;
                    objEntityLeavSettlmt.EmployeeId = UerId;
                    objEntityLeavSettlmt.DateStartDate = dtFrom;
                    objEntityLeavSettlmt.DateEndDate = dtTo;
                    DataTable dtLeaveDate = objBusinessLeavSettlmt.ReadLeaveDate(objEntityLeavSettlmt);



                    cls_Business_Monthly_Salary_Process objBuss2 = new cls_Business_Monthly_Salary_Process();
                    cls_Entity_Monthly_Salary_Process objEnt2 = new cls_Entity_Monthly_Salary_Process();
                    objEnt2.Employee = UerId;
                    objEnt2.DateStartDate = dtFinal.AddDays(1);
                    objEnt2.DateEndDate = new DateTime(dtFinal.Year, 12, 31);
                    objEnt2.CorpOffice = CorpId;
                    objEnt2.Orgid = OrgId;
                    DataTable dtLeaveDateFuture = new DataTable();
                    if (objEnt2.DateStartDate.Year == objEnt2.DateEndDate.Year)
                    {
                        dtLeaveDateFuture = objBuss2.ReadLeaveDate(objEnt2);
                    }
                    decimal FutureLeaveCnt = calcFutureLeaveCnt(LeaveTypId.ToString(), dtLeaveDateFuture, objEnt2);



                    for (int lcnt = 0; lcnt < dtLeaveDate.Rows.Count; lcnt++)
                    {
                        if (dtLeaveDate.Rows[lcnt]["LEAVE_ID"].ToString() == LeaveId.ToString())
                        {
                            int HoliPaidSts = Convert.ToInt32(dtLeaveDate.Rows[lcnt]["LEAVETYP_HOLIDAY_PAID_STS"].ToString());
                            int OffPaidSts = Convert.ToInt32(dtLeaveDate.Rows[lcnt]["LEAVETYP_OFFDAY_PAID_STS"].ToString());

                            decimal OpenLeaveCnt = Convert.ToDecimal(dtLeaveDate.Rows[lcnt]["OPENING_NUMLEAVE"].ToString());
                            decimal BalanceLeaveCnt = Convert.ToDecimal(dtLeaveDate.Rows[lcnt]["BALANCE_NUMLEAVE"].ToString()) + FutureLeaveCnt;
                            decimal LeaveDays = Convert.ToDecimal(dtLeaveDate.Rows[lcnt]["LEAVE_NUM_DAYS"].ToString());

                            clsBussinessLayerLeaveAllocationMaster_dutyOff objDuty = new clsBussinessLayerLeaveAllocationMaster_dutyOff();
                            int OffCount = 0;

                            if (dtFrom != DateTime.MinValue && dtTo != DateTime.MinValue && dtFrom <= dtFinal)
                            {
                                if ((dtFrom <= dtFinal && dtTo <= dtFinal)) //modi
                                {
                                    int MonthDiff = (dtTo.Year * 12 + dtTo.Month) - (dtFrom.Year * 12 + dtFrom.Month);
                                    if (MonthDiff == 1)
                                    {
                                        DaysMnth1 = DateTime.DaysInMonth(dtTo.Year, dtTo.Month);
                                        DaysMnth2 = DateTime.DaysInMonth(dtFrom.Year, dtFrom.Month);

                                        DateTime dtNewFrom = new DateTime(dtTo.Year, dtTo.Month, 1);
                                        cnt1 = Convert.ToInt32((dtTo - dtNewFrom).TotalDays) + 1;
                                        if (ToSec != 1)
                                        {
                                            cnt1 = cnt1 - (decimal)0.5;
                                        }
                                        DateTime datenow, enddate;
                                        datenow = dtNewFrom;
                                        enddate = dtTo;

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
                                        cnt1 = cnt1 - OffCount;
                                        if (cnt1 < 0)
                                        {
                                            cnt1 = 0;
                                        }



                                        DateTime dtNewTo = dtNewFrom.AddDays(-1);
                                        cnt2 = Convert.ToInt32((dtNewTo - dtFrom).TotalDays) + 1;
                                        if (FromSec != 1)
                                        {
                                            cnt2 = cnt2 - (decimal)0.5;
                                        }
                                        datenow = dtFrom;
                                        enddate = dtNewTo;
                                        OffCount = 0;
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
                                        cnt2 = cnt2 - OffCount;
                                        if (cnt2 < 0)
                                        {
                                            cnt2 = 0;
                                        }


                                    }
                                    else
                                    {
                                        DaysMnth1 = DateTime.DaysInMonth(dtTo.Year, dtTo.Month);

                                        cnt1 = Convert.ToInt32((dtTo - dtFrom).TotalDays) + 1;

                                        if (FromSec != 1)
                                        {
                                            cnt1 = cnt1 - (decimal)0.5;
                                        }
                                        if (ToSec != 1)
                                        {
                                            cnt1 = cnt1 - (decimal)0.5;
                                        }
                                        DateTime datenow, enddate;
                                        datenow = dtFrom;
                                        enddate = dtTo;
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
                                        cnt1 = cnt1 - OffCount;
                                        if (cnt1 < 0)
                                        {
                                            cnt1 = 0;
                                        }

                                        //IF PAID = 1
                                    }
                                }
                                else
                                {
                                    int MonthDiff = 0;

                                    if (strPaidLeave == "1" && dtFrom <= dtFinal && dtTo >= dtFinal)
                                    {
                                        MonthDiff = (dtTo.Year * 12 + dtTo.Month) - (dtFinal.Year * 12 + dtFinal.Month);
                                    }
                                    else
                                    {
                                        MonthDiff = (dtFinal.Year * 12 + dtFinal.Month) - (dtFrom.Year * 12 + dtFrom.Month);
                                    }

                                    if (MonthDiff == 1)
                                    {
                                        DaysMnth1 = DateTime.DaysInMonth(dtFinal.Year, dtFinal.Month);
                                        DaysMnth2 = DateTime.DaysInMonth(dtFrom.Year, dtFrom.Month);


                                        DateTime dtNewFrom = new DateTime(dtFinal.Year, dtFinal.Month, 1);

                                        if (strPaidLeave == "1") //modi
                                        {
                                            if (dtTo > dtFinal)
                                            {
                                                cnt1 = Convert.ToInt32((dtFinal - dtFrom).TotalDays) + 1;
                                            }
                                            else
                                            {
                                                cnt1 = Convert.ToInt32((dtTo - dtFrom).TotalDays) + 1;
                                            }
                                        }
                                        else
                                        {
                                            cnt1 = Convert.ToInt32((dtFinal - dtNewFrom).TotalDays) + 1;
                                        }

                                        DateTime datenow, enddate;
                                        datenow = dtNewFrom;
                                        enddate = dtFinal;
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
                                        cnt1 = cnt1 - OffCount;
                                        if (cnt1 < 0)
                                        {
                                            cnt1 = 0;
                                        }

                                        DateTime dtNewTo = dtNewFrom.AddDays(-1);
                                        cnt2 = Convert.ToInt32((dtNewTo - dtFrom).TotalDays) + 1;
                                        if (FromSec != 1)
                                        {
                                            cnt2 = cnt2 - (decimal)0.5;
                                        }
                                        datenow = dtFrom;
                                        enddate = dtNewTo;
                                        OffCount = 0;
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
                                        cnt2 = cnt2 - OffCount;
                                        if (cnt2 < 0)
                                        {
                                            cnt2 = 0;
                                        }

                                        // if()

                                    }
                                    else
                                    {
                                        DaysMnth1 = DateTime.DaysInMonth(dtFinal.Year, dtFinal.Month);

                                        cnt1 = Convert.ToInt32((dtFinal - dtFrom).TotalDays) + 1;
                                        if (FromSec != 1)
                                        {
                                            cnt1 = cnt1 - (decimal)0.5;
                                        }
                                        DateTime datenow, enddate;
                                        datenow = dtFrom;
                                        enddate = dtFinal;
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
                                        cnt1 = cnt1 - OffCount;
                                        if (cnt1 < 0)
                                        {
                                            cnt1 = 0;
                                        }
                                    }
                                }
                            }
                            else if (dtFrom != DateTime.MinValue && dtTo == DateTime.MinValue && dtFrom <= dtFinal)
                            {
                                DaysMnth1 = DateTime.DaysInMonth(dtFrom.Year, dtFrom.Month);
                                if (FromSec == 1)
                                {
                                    cnt1 = 1;
                                }
                                else
                                {
                                    cnt1 = (decimal)0.5;
                                }
                            }


                            if (strPaidLeave == "0")  //modi
                            {
                                if (BalanceLeaveCnt < 0)
                                {
                                    BalanceLeaveCnt = BalanceLeaveCnt * -1;
                                    if (BalanceLeaveCnt >= (cnt2 + cnt1))
                                    {
                                    }
                                    else
                                    {
                                        if (BalanceLeaveCnt <= cnt1)
                                        {
                                            cnt1 = BalanceLeaveCnt;
                                            cnt2 = 0;
                                        }
                                        else
                                        {
                                            cnt2 = BalanceLeaveCnt - cnt1;
                                            if (cnt2 < 0)
                                            {
                                                cnt2 = 0;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    cnt1 = 0;
                                    cnt2 = 0;
                                }
                            }
                            else
                            {
                                cnt1 = cnt1;
                            }
                        }
                    }


                    if (cnt1 > 0)
                    {
                        decimal TotalAmnt = 0;
                        decimal decBasisPayMnth = 0;
                        decimal decAllownc = 0;
                        decimal deciDeduction = 0;
                        DataTable dtBasic = objBusinessLeavSettlmt.ReadBasicPay(objEntityLeavSettlmt);
                        if (dtBasic.Rows.Count > 0)
                        {
                            if (dtBasic.Rows[0]["SLRY_BASIC_PAY"].ToString() != "")
                            {
                                decBasisPayMnth = Convert.ToDecimal(dtBasic.Rows[0]["SLRY_BASIC_PAY"].ToString());
                            }
                        }
                        DataTable dtAllownce = objBusinessLeavSettlmt.ReadAllowance(objEntityLeavSettlmt);
                        DataTable dtDeductn = objBusinessLeavSettlmt.ReadDeduction(objEntityLeavSettlmt);
                        //Addition calculation      
                        decimal DecAllTotalAmount = 0;
                        for (int intRowCount = 0; intRowCount < dtAllownce.Rows.Count; intRowCount++)
                        {
                            decimal DecAlwancAmt = 0;
                            if (dtAllownce.Rows[intRowCount]["SLRYALLCE_AMOUNT"].ToString() != "")
                            {
                                if (dtAllownce.Rows[intRowCount]["PAYRL_TYPE_STS"].ToString() == "0" && joinMnthSts == 0)//Fixed Allowance
                                {
                                    DecAllTotalAmount += Convert.ToDecimal(dtAllownce.Rows[intRowCount]["SLRYALLCE_AMOUNT"].ToString()); ;
                                }
                                else//Variable Allowance
                                {
                                    DecAlwancAmt = Convert.ToDecimal(dtAllownce.Rows[intRowCount]["SLRYALLCE_AMOUNT"].ToString());
                                    DecAllTotalAmount += DecAlwancAmt;
                                    if (DaysMnth2 > 0)
                                    {
                                        DecAlwancAmt = ((DecAlwancAmt / DaysMnth1) * cnt1) + ((DecAlwancAmt / DaysMnth2) * cnt2);
                                    }
                                    else
                                    {
                                        DecAlwancAmt = ((DecAlwancAmt / DaysMnth1) * cnt1);
                                    }
                                }
                            }
                            decAllownc += DecAlwancAmt;
                        }
                        //deduction amount      
                        for (int intRowCount = 0; intRowCount < dtDeductn.Rows.Count; intRowCount++)
                        {
                            decimal DecDeduction = 0, DecDeductionbasicPay = 0, DecDeductionTotlPay = 0;
                            if (dtDeductn.Rows[intRowCount]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString() == "0")//Amount deduction
                            {
                                if (dtDeductn.Rows[intRowCount]["SLRYDEDTN_AMOUNT"].ToString() != "")
                                {
                                    if (dtDeductn.Rows[intRowCount]["PAYRL_TYPE_STS"].ToString() == "0" && joinMnthSts == 0)//Fixed deduction
                                    {

                                    }
                                    else//Variable deduction
                                    {
                                        DecDeduction = Convert.ToDecimal(dtDeductn.Rows[intRowCount]["SLRYDEDTN_AMOUNT"].ToString());
                                        if (DaysMnth2 > 0)
                                        {
                                            DecDeduction = ((DecDeduction / DaysMnth1) * cnt1) + ((DecDeduction / DaysMnth2) * cnt2);
                                        }
                                        else
                                        {
                                            DecDeduction = ((DecDeduction / DaysMnth1) * cnt1);
                                        }
                                    }
                                }
                            }
                            else if (dtDeductn.Rows[intRowCount]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString() == "1")//Percentage deduction
                            {
                                if (dtDeductn.Rows[intRowCount]["SLRYDEDTN_BASIC_OR_TOTAL_AMNT"].ToString() == "0") //basic pay deductn
                                {
                                    if (dtDeductn.Rows[intRowCount]["PAYRL_TYPE_STS"].ToString() == "0" && joinMnthSts == 0)//Fixed deduction
                                    {

                                    }
                                    else //variable deduction
                                    {
                                        DecDeductionbasicPay = Convert.ToDecimal(dtDeductn.Rows[intRowCount]["SLRYDEDTN_PERCNTGE"].ToString());
                                        DecDeductionbasicPay = decBasisPayMnth * (DecDeductionbasicPay / 100);
                                        if (DaysMnth2 > 0)
                                        {
                                            DecDeductionbasicPay = ((DecDeductionbasicPay / DaysMnth1) * cnt1) + ((DecDeductionbasicPay / DaysMnth2) * cnt2);
                                        }
                                        else
                                        {
                                            DecDeductionbasicPay = ((DecDeductionbasicPay / DaysMnth1) * cnt1);
                                        }
                                    }
                                }
                                else if (dtDeductn.Rows[intRowCount]["SLRYDEDTN_BASIC_OR_TOTAL_AMNT"].ToString() == "1") //total pay deductn
                                {
                                    if (dtDeductn.Rows[intRowCount]["PAYRL_TYPE_STS"].ToString() == "0" && joinMnthSts == 0)//Fixed deduction
                                    {

                                    }
                                    else//Variable deduction
                                    {
                                        DecDeductionTotlPay = Convert.ToDecimal(dtDeductn.Rows[intRowCount]["SLRYDEDTN_PERCNTGE"].ToString());
                                        DecDeductionTotlPay = (decBasisPayMnth + DecAllTotalAmount) * (DecDeductionTotlPay / 100);
                                        if (DaysMnth2 > 0)
                                        {
                                            DecDeductionTotlPay = ((DecDeductionTotlPay / DaysMnth1) * cnt1) + ((DecDeductionTotlPay / DaysMnth2) * cnt2);
                                        }
                                        else
                                        {
                                            DecDeductionTotlPay = ((DecDeductionTotlPay / DaysMnth1) * cnt1);
                                        }
                                    }
                                }
                            }
                            deciDeduction += DecDeduction + DecDeductionbasicPay + DecDeductionTotlPay;
                        }
                        if (BasicPaySts == 0 && joinMnthSts == 0)
                        {
                            decBasisPayMnth = 0;
                        }
                        else
                        {
                            if (DaysMnth2 > 0)
                            {
                                decBasisPayMnth = ((decBasisPayMnth / DaysMnth1) * cnt1) + ((decBasisPayMnth / DaysMnth2) * cnt2);
                            }
                            else
                            {
                                decBasisPayMnth = ((decBasisPayMnth / DaysMnth1) * cnt1);
                            }
                        }
                        TotalAmnt = decBasisPayMnth + decAllownc + deciDeduction;
                        if (TotalAmnt > 0)
                        {

                            clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
                            clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
                            objEntLevAllocn.Leave_Id = LeaveId;
                            objEntLevAllocn.User_Id = UerId;
                            objEntLevAllocn.NumOfLeave = TotalAmnt;
                            objBusLevAllocn.InsLeaveArrearAmnt(objEntLevAllocn);
                        }
                    }
                }
            }
        }



        public DataTable CheckLeaveDatesByEmployeeCode(clsEntityLayerLeaveAllocationMaster objEntityLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerRemLeav = new clsDataLayerLeaveAllocationMaster();
            DataTable count = objDataLayerRemLeav.CheckLeaveDatesByEmployeeCode(objEntityLev);
            return count;

        }


        public DataTable CheckLeaveDatesByEmployeeID(clsEntityLayerLeaveAllocationMaster objEntityLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerRemLeav = new clsDataLayerLeaveAllocationMaster();
            DataTable count = objDataLayerRemLeav.CheckLeaveDatesByEmployeeID(objEntityLev);
            return count;

        }

        public DataTable CheckLeaveDates(clsEntityLayerLeaveAllocationMaster objEntityLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerRemLeav = new clsDataLayerLeaveAllocationMaster();
            DataTable count = objDataLayerRemLeav.CheckLeaveDates(objEntityLev);
            return count;

        }

        public DataTable CheckReportOffcr(clsEntityLayerLeaveAllocationMaster objEntityLev)
        {
            clsDataLayerLeaveAllocationMaster objDataLayerRemLeav = new clsDataLayerLeaveAllocationMaster();
            DataTable count = objDataLayerRemLeav.CheckReportOffcr(objEntityLev);
            return count;
        }

    }


    public class clsBussinessLayerLeaveAllocationMaster_dutyOff
    {

        public static string GetWeekOfMonth(DateTime date)
        {

            DateTime beginningOfMonth = new DateTime(date.Year, date.Month, 1);

            //while (date.Date.AddDays(1).DayOfWeek != CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)

            //    date = date.AddDays(1);
            while (date.Date.AddDays(1).DayOfWeek != CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)

                date = date.AddDays(1);

            int weekNumber = (int)Math.Truncate((double)date.Subtract(beginningOfMonth).TotalDays / 7f) + 1;

            string[] weeks = { "first", "second", "third", "fourth", "fifth", "sixth" };

            return weeks[weekNumber - 1];

        }
        public string CheckDutyOff(DateTime dateCheck, string orgid, string corpid)
        {
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

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
            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
            DateTime currDateTime = objCommon.textToDateTime(strCurrentDate);
            string strTodayDate = currDateTime.ToString("dd/MM/yyyy");

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
                                    firstdate = 28;
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
                                    firstdate = 7;
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
                        if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "3")
                        {
                            for (int i = 0; i <= 1; i++)
                            {
                                if (i == 0)
                                {
                                    firstdate = 22;
                                }
                                else if (i == 1)
                                {
                                    firstdate = 28;
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
                                    firstdate = 28;
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
                            //HoliName = RowHoli["HLDAYMSTR_DATE"].ToString();
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


            //List<DateTime> MonthlyOffDates = new List<DateTime>();
            // return "MonthlyOffDates";
        }
        public string checkholiday(DateTime day, DateTime datenow, DateTime enddate)
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
            clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
            DateTime fromdate, todate;
            //fromdate = objCommon.textToDateTime(txtFromDate.Text);
            objEntLevAllocn.LeaveFrmDate = datenow;
            //todate = objCommon.textToDateTime(txtToDate.Text);
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
                        //return Holi1;
                    }
                }
            }
            return Holi1;
        }

    }
}
