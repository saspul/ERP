using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using System.Text;
using CL_Compzit;
using System.Collections;
using System.IO;
using MailUtility_ERP;
using System.Web.Script.Serialization;
using System.Web.Services;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_AWMS;
using System.Globalization;

public partial class HCM_HCM_Master_hcm_PayrollSystem_hcm_Monthly_Attendance_Sheet_hcm_Monthly_Attendance_Sheet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        cbxImprtHasHeader.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxImprtHasHeader.Attributes.Add("onkeypress", "return DisableEnter(event)");
        rbtnCropDept.Attributes.Add("onkeypress", "return DisableEnter(event)");
        rbtnCropDept.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        if (!IsPostBack)
        {
            BindDdlMonths();
            BindDdlYears();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
            hiddenCurrentDate.Value = strCurrentDate;


            if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                HiddenUserId.Value = Session["USERID"].ToString();
            }

            if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                HiddenOrgId.Value = Session["ORGID"].ToString();
            }

            int intCorpId = 0;
            if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }

            FileUploader.Focus();
            DropDownBindDepartment();

            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.EMPDLYHR_FUTURE_DAYS,
                                                       };

            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                int Days = Convert.ToInt32(dtCorpDetail.Rows[0]["EMPDLYHR_FUTURE_DAYS"].ToString());
                DateTime dtdate = objCommon.textToDateTime(strCurrentDate.ToString());
                hiddenCorpGlobalFutureDays.Value = dtdate.AddDays(Days).ToString("dd-MM-yyyy");
            }

            //when editing 
            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();

                if (strInsUpd == "Err")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ErrorMessage", "ErrorMessage();", true);
                }
                if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
            }

            //For Check holiday
            clsBusinessLayerEmployeeDailyWorkHour objBusinessEmpDailyWorkHour = new clsBusinessLayerEmployeeDailyWorkHour();
            clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour = new clsEntityEmployeeDailyWorkHour();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityEmpDailyWorkHour.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityEmpDailyWorkHour.orgid = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityEmpDailyWorkHour.DateOfWork = objCommon.textToDateTime(hiddenCurrentDate.Value.Trim());
            DataTable dt = objBusinessEmpDailyWorkHour.checkHoliday(objEntityEmpDailyWorkHour);
            int holiSts = 0;
            if (dt.Rows.Count > 0)
            {
                //if ( rbtnCropDept.Items.FindByText("HOLIDAY OT")!=null)
                //{
                //    rbtnCropDept.Items.FindByText("HOLIDAY OT").Selected = true;
                holiSts = 1;
                HiddenFieldHldySts.Value = "1";
                //}
            }
            else
            {
                //if (rbtnCropDept.Items.FindByText("NORMAL OT") != null)
                //{
                //    rbtnCropDept.Items.FindByText("NORMAL OT").Selected = true;
                HiddenFieldHldySts.Value = "0";
                //}
            }

            if (holiSts == 0)
            {
                //For off duty checking         
                clsEntityLayerDutyRoster objEntityDutyRoster = new clsEntityLayerDutyRoster();
                clsBusinessLayerDutyRoster objBusinessDutyRoster = new clsBusinessLayerDutyRoster();
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityDutyRoster.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityDutyRoster.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                //FOR READING DUTY OFF
                DataTable dtDutyOffWeekly = objBusinessDutyRoster.ReadWeeklyDutyOff(objEntityDutyRoster);
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

                DateTime now = new DateTime();
                now = objCommon.textToDateTime(hiddenCurrentDate.Value);

                DataTable dtDutyOffMonthly = objBusinessDutyRoster.ReadMonthlyDutyOff(objEntityDutyRoster);
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

                                                    break;
                                            }
                                        }

                                    }
                                }

                            }

                        }

                    }
                }


                string strMonthOf1 = "false";
                foreach (DateTime MonthOff in MonthlyOffDates)
                {
                    if (MonthOff == now)
                    {
                        strMonthOf1 = "true";
                        break;
                    }
                }
                string strWekOf1 = "false";
                string strDayWkString1 = now.ToString("dddd");
                if (strJbWklyOffDay.Contains(strDayWkString1))
                {
                    strWekOf1 = "true";
                }

                if (strMonthOf1 == "true" || strWekOf1 == "true")
                {
                    //if (rbtnCropDept.Items.FindByText("HOLIDAY OT") != null)
                    //{
                    //    rbtnCropDept.Items.FindByText("HOLIDAY OT").Selected = true;
                    HiddenFieldHldySts.Value = "1";
                    //}
                }
                //For off duty checking
            }
        }
    }

   

    public void BindDdlMonths(string strMonth = null)
    {
        strMonth = DateTime.Today.Month.ToString();
        ddlMonth.Items.Clear();
        var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
        for (int i = 0; i < months.Length - 1; i++)
        {
            ddlMonth.Items.Add(new ListItem(months[i], (i + 1).ToString()));
        }
       // ddlMonth.ClearSelection();
        if (strMonth != null)
        {
            if (ddlMonth.Items.FindByValue(strMonth) != null)
            {
                ddlMonth.Items.FindByValue(strMonth).Selected = true;
            }
        }
        else
        {
            ddlMonth.Items.Insert(0, "--MONTH--");
        }
    }

    public void BindDdlYears(string strYear = null)
    {
        ddlYear.Items.Clear();
        strYear = DateTime.Today.Year.ToString();
        var currentYear = DateTime.Today.Year;
        for (int i = 1; i >= -1; i--)
        {

            ddlYear.Items.Add((currentYear - i).ToString());
        }
      //  ddlYear.ClearSelection();
        if (strYear != null)
        {
            if (ddlYear.Items.FindByValue(strYear) != null)
            {
                ddlYear.Items.FindByValue(strYear).Selected = true;
            }
        }
        else
        {
            ddlYear.Items.Insert(0, "--YEAR--");
        }
    }


    public void DropDownBindDepartment()
    {


        clsBusinessLayerEmployeeDailyWorkHour objBusinessEmpDailyWorkHour = new clsBusinessLayerEmployeeDailyWorkHour();
        clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour = new clsEntityEmployeeDailyWorkHour();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEmpDailyWorkHour.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityEmpDailyWorkHour.orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dt = objBusinessEmpDailyWorkHour.readOTcategories(objEntityEmpDailyWorkHour);
        HiddenCategoryCount.Value = dt.Rows.Count.ToString();
        if (dt.Rows.Count > 0)
        {
            rbtnCropDept.Items.Clear();
            rbtnCropDept.DataTextField = "OVRTMCATG_NAME";
            rbtnCropDept.DataValueField = "OVRTMCATG_ID";
            rbtnCropDept.DataSource = dt;
            rbtnCropDept.DataBind();
            rbtnCropDept.Enabled = true;
            divCompzitModuleNoList.Visible = false;
        }
        else
        {
            divCompzitModuleNoList.Visible = true;
            btnAdd.Visible = false;
        }
    }
    //0039
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
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
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
    //end
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //txtefctvedate

        int tableSts = 0;


        string strmonth = ddlMonth.Items[ddlMonth.SelectedIndex].Text;
        string stryear = ddlYear.Items[ddlYear.SelectedIndex].Text;
        
        HiddenFieldMonthAndYear.Value =  strmonth +" "+stryear;

        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerEmployeeDailyWorkHour objBusinessEmpDailyWorkHour = new clsBusinessLayerEmployeeDailyWorkHour();
        clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour = new clsEntityEmployeeDailyWorkHour();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEmpDailyWorkHour.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityEmpDailyWorkHour.orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        if (Session["USERID"] != null)
        {
            objEntityEmpDailyWorkHour.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        int intMonth =Convert.ToInt16(ddlMonth.Value);
        int intYear = Convert.ToInt16(ddlYear.Value);
        int daysInMonth = DateTime.DaysInMonth(intYear, intMonth);

        string strFilePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.MONTHLY_ATTENDACE_SHEET);

        //for delete all the files in the specific folder.
        Array.ForEach(Directory.GetFiles(Server.MapPath(strFilePath)), File.Delete);

        if (FileUploader.HasFile)
        {
            FileUploader.SaveAs(Server.MapPath(strFilePath) + FileUploader.PostedFile.FileName);
            HiddenFile.Value = FileUploader.PostedFile.FileName;
        }

        string strData = Server.MapPath(strFilePath) + "/" + FileUploader.PostedFile.FileName;
        try
        {
            var OuterLines = new List<string[]>();
            var CodeCorrectList = new List<string[]>();
            var CodeMissingList = new List<string[]>();
            var IncorrectOTList = new List<string[]>();
            var IncorrectRemarksList = new List<string[]>();
            var IncorrectEmployeeCodeList = new List<string[]>();
            var AlreadyConfirmedList = new List<string[]>();
            var IncorrectProjectCodeList = new List<string[]>();
            var DuplicateList = new List<string[]>();

            var IncorrectDaysList = new List<string[]>();
            var IncorrectOTCategoryList = new List<string[]>();


            bool blHeader = false;

            int intTotalEmployeesCount = 0;
            int intHeaderCount = 0;


            using (CsvFileReader reader = new CsvFileReader(strData))
            {
                CsvRow row = new CsvRow();
                while (reader.ReadRow(row))
                {
                    //check the uploaded file has headers
                    if (cbxImprtHasHeader.Checked == true)
                    {
                        if (blHeader == false)
                        {
                            blHeader = true;
                            goto rowOuter;
                        }
                    }
                    else
                    {
                        intHeaderCount = 1;
                    }
                    //string array for store the csv file row.
                    string[] Line = row.ToArray();

                    OuterLines.Add(Line);
                rowOuter: ;
                }

            }

            intTotalEmployeesCount = OuterLines.Count - intHeaderCount;


            var OuterLinesCopy = new List<string[]>(OuterLines);
            OuterLinesCopy = OuterLines.ToList();




            //EVM-0012
            //refactor csv validation
            int intConsolidated = 0;
            if (cbxConsolidate.Checked == true)
            {
                intConsolidated = 1;
            }

            string DayVal = "";

            for (int intRow = OuterLinesCopy.Count - 1; intRow >= 0; intRow--)
            {
                bool boolValidStatus = true;
                bool boolDaysInMonth = true;

                for (int i = 0; i <= 8; i++)
                {

                    //For removing <> 

                    int len = OuterLines[intRow].Length;

                    if (len > i)
                    {

                        string strItem = OuterLinesCopy[intRow][2].ToString().ToUpper();
                        strItem = strItem.Replace("<", string.Empty);
                        strItem = strItem.Replace(">", string.Empty);
                        OuterLinesCopy[intRow][2] = strItem;

                        //checking missing values

                        //Day Validation
                        if (i == 0)
                        {
                            if (OuterLinesCopy[intRow][i] == null || OuterLinesCopy[intRow][i] == "" || OuterLinesCopy[intRow][i] == "0")
                            {
                                IncorrectDaysList.Add(OuterLinesCopy[intRow]);
                                boolValidStatus = false;
                                boolDaysInMonth = false;
                                if (intConsolidated == 1)
                                    break;
                            }
                            else
                            {
                                string strDay = OuterLinesCopy[intRow][i].ToString().ToLower();
                                bool checkIsDigit = strDay.All(char.IsDigit);
                                if (checkIsDigit == true)
                                {
                                    int day = Convert.ToInt16(strDay);
                                    if (day > daysInMonth)
                                    {
                                        boolDaysInMonth = false;
                                        boolValidStatus = false;
                                        IncorrectDaysList.Add(OuterLinesCopy[intRow]);
                                        if (intConsolidated == 1)
                                            break;
                                    }
                                    else
                                    {
                                        string strday = "", strMonth = "";
                                        if (day < 10)
                                        {
                                            strday = "0" + day.ToString();
                                        }
                                        else
                                        {
                                            strday = day.ToString();
                                           }
                                        if (intMonth < 10)
                                        {
                                            strMonth = "0" + intMonth.ToString();
                                        }
                                        else
                                        {
                                            strMonth = intMonth.ToString();
                                        }
                                        DayVal = strday;
                                        objEntityEmpDailyWorkHour.DateOfWork = objCommon.textToDateTime(strday + "-" + strMonth + "-" + intYear.ToString());
                                        boolDaysInMonth = true;
                                    }
                                }
                                else
                                {
                                    boolDaysInMonth = false;
                                    boolValidStatus = false;
                                    IncorrectDaysList.Add(OuterLinesCopy[intRow]);
                                    if (intConsolidated == 1)
                                        break;
                                }
                            }

                        }

                        //OT Category Validation
                       else if (i == 1)
                       {
                           if (OuterLinesCopy[intRow][i].ToString().ToLower() != "h" && OuterLinesCopy[intRow][i].ToString() != "")
                           {
                               IncorrectOTCategoryList.Add(OuterLinesCopy[intRow]);
                               boolValidStatus = false;
                               if (intConsolidated == 1)
                                   break;
                           }
                           else
                           {
                               string strOTCatg = OuterLinesCopy[intRow][i].ToString().ToLower();

                               if (strOTCatg == "h")
                               {
                                   strOTCatg = "HOLIDAY OT";
                               }
                               else
                               {
                                   strOTCatg = "NORMAL OT";
                               }

                               objEntityEmpDailyWorkHour.OTCatgName = strOTCatg;
                               DataTable dtOtCatgry = objBusinessEmpDailyWorkHour.checkOTCategory(objEntityEmpDailyWorkHour);
                               if (dtOtCatgry.Rows.Count == 0)
                               {
                                   IncorrectOTCategoryList.Add(OuterLinesCopy[intRow]);
                                   boolValidStatus = false;
                                   if (intConsolidated == 1)
                                       break;
                               }
                           }

                       }

                        //EMPCODE VALIDATION
                        // EVM 0041

                        else if (i == 2)
                        {
                            if (OuterLinesCopy[intRow][i] == null || OuterLinesCopy[intRow][i] == "")
                            {

                                boolValidStatus = false;

                                IncorrectEmployeeCodeList.Add(OuterLinesCopy[intRow]);
                                if (intConsolidated == 1)
                                    break;
                            }
                            else
                            {
                                string strEmpcode = OuterLines[intRow][2].ToString().Replace("<", string.Empty);
                                // string strJobName = OuterLines[intRow][3].ToString().Replace("<", string.Empty); //cmd evm0023
                                string strProjectCode = OuterLines[intRow][5].ToString().Replace("<", string.Empty);

                                objEntityEmpDailyWorkHour.FileName = strProjectCode;
                                objEntityEmpDailyWorkHour.ActFileName = strEmpcode;

                                DataTable dtEmp = new DataTable();

                                dtEmp = objBusinessEmpDailyWorkHour.checkEmpcode(objEntityEmpDailyWorkHour);

                                if (dtEmp.Rows.Count == 0)
                                {
                                    //if (OuterLinesCopy[intRow][6].ToString().ToLower() == "a")
                                    //{
                                        boolValidStatus = false;
                                        IncorrectEmployeeCodeList.Add(OuterLinesCopy[intRow]);
                                        if (intConsolidated == 1)
                                            break;
                                    //}
                                }
                                else
                                {

                                    if (boolDaysInMonth == true)
                                    {
                                        if (dtEmp.Rows[0]["PROCESSED_COUNT"].ToString().Trim() != "0" && dtEmp.Rows[0]["EMPDLYHR_CNFRM_STS"].ToString().Trim() != "1")
                                        {
                                            //if (OuterLinesCopy[intRow][6].ToString().ToLower() == "a")
                                            //{
                                            boolValidStatus = false;
                                            AlreadyConfirmedList.Add(OuterLinesCopy[intRow]);
                                            if (intConsolidated == 1)
                                                break;
                                            //    }
                                            //}
                                        }
                                        if (dtEmp.Rows[0]["LEAVE_SETTLED_COUNT"].ToString().Trim() != "0" && dtEmp.Rows[0]["EMPDLYHR_CNFRM_STS"].ToString().Trim() != "1")
                                        {
                                            //if (OuterLinesCopy[intRow][6].ToString().ToLower() == "a")
                                            //{

                                                boolValidStatus = false;
                                                AlreadyConfirmedList.Add(OuterLinesCopy[intRow]);
                                                if (intConsolidated == 1)
                                                    break;
                                            //}
                                        }

                                        //End
                                        //check already confirmed or not
                                        if (dtEmp.Rows[0]["EMPDLYHR_CNFRM_STS"].ToString().Trim() == "1" && dtEmp.Rows[0]["LEAVE_SETTLED_COUNT_PAID"].ToString().Trim() == "0" && dtEmp.Rows[0]["PROCESSED_COUNT_PAID"].ToString().Trim() == "0")
                                        {
                                            boolValidStatus = false;
                                            AlreadyConfirmedList.Add(OuterLinesCopy[intRow]);
                                            if (intConsolidated == 1)
                                                break;
                                        }
                                        if (dtEmp.Rows[0]["EMPDLYHR_CNT_AMNT"].ToString().Trim() == "1")
                                        {
                                            boolValidStatus = false;
                                            AlreadyConfirmedList.Add(OuterLinesCopy[intRow]);
                                            if (intConsolidated == 1)
                                                break;
                                        }
                                        if (dtEmp.Rows[0]["LEAVE_CNFRM_STS"].ToString().Trim() == "1")
                                        {
                                            boolValidStatus = false;
                                            AlreadyConfirmedList.Add(OuterLinesCopy[intRow]);
                                            if (intConsolidated == 1)
                                                break;
                                        }

                                        if (dtEmp.Rows[0]["LEAVE_SETTLED_COUNT_PAID"].ToString().Trim() != "0" || dtEmp.Rows[0]["PROCESSED_COUNT_PAID"].ToString().Trim() != "0")
                                        {
                                            tableSts = 1;
                                        }

                                    }


                                    if (OuterLinesCopy[intRow][6].ToString().ToLower() == "p")
                                    {

                                        // check leave on this date
                                        clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
                                        clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();


                                        string strDay = OuterLines[intRow][0].ToString();

                                        bool checkIsDigit = strDay.All(char.IsDigit);
                                        if (checkIsDigit == true)
                                        {
                                            int day = Convert.ToInt16(strDay);
                                            if (day <= daysInMonth)
                                            {
                                                string strday = "", strMonth = "";
                                                if (day < 10)
                                                {
                                                    strday = "0" + day.ToString();
                                                }
                                                else
                                                {
                                                    strday = day.ToString();
                                                }
                                                if (intMonth < 10)
                                                {
                                                    strMonth = "0" + intMonth.ToString();
                                                }
                                                else
                                                {
                                                    strMonth = intMonth.ToString();
                                                }
                                                objEntityEmpDailyWorkHour.DateOfWork = objCommon.textToDateTime(strday + "-" + strMonth + "-" + intYear.ToString());
                                            }
                                        }

                                        DateTime dateCurnt = objEntityEmpDailyWorkHour.DateOfWork;
                                        int intFlag = 0;
                                        DataTable datatableFrmChk;
                                        objEntLevAllocn.LeaveFrmDate = objEntityEmpDailyWorkHour.DateOfWork;
                                        objEntLevAllocn.EmployeeCode = OuterLinesCopy[intRow][i];
                                        datatableFrmChk = objBusLevAllocn.CheckLeaveDatesByEmployeeCode(objEntLevAllocn);
                                        if (datatableFrmChk.Rows.Count > 0)
                                        {
                                            intFlag++;
                                        }
                                        if (intFlag != 0)
                                        {
                                            //already leave allocated and daily attendance says employee is present 
                                            CodeMissingList.Add(OuterLinesCopy[intRow]);
                                            boolValidStatus = false;
                                            if (intConsolidated == 1)
                                                break;
                                        }

                                    }


                                }
                            }
                        }

                        //  Project code Validation
                        else if (i == 5)
                        {
                            if (OuterLinesCopy[intRow][i] == null || OuterLinesCopy[intRow][i] == "")
                            {
                                IncorrectProjectCodeList.Add(OuterLinesCopy[intRow]);
                                boolValidStatus = false;
                                if (intConsolidated == 1)
                                    break;
                            }
                            else
                            {
                                DataTable dtProject = objBusinessEmpDailyWorkHour.checkProjectCode(objEntityEmpDailyWorkHour);
                                if (dtProject.Rows.Count == 0)
                                {
                                    boolValidStatus = false;
                                    IncorrectProjectCodeList.Add(OuterLinesCopy[intRow]);
                                    if (intConsolidated == 1)
                                        break;
                                }
                            }

                        }

                           // Attendance Validation
                        else if (i == 6)
                        {
                            if (OuterLinesCopy[intRow][i] == null || OuterLinesCopy[intRow][i] == "")
                            {
                                CodeMissingList.Add(OuterLinesCopy[intRow]);
                                boolValidStatus = false;
                                if (intConsolidated == 1)
                                    break;

                            }
                            else if (OuterLinesCopy[intRow][i].ToString().ToLower() != "a" && OuterLinesCopy[intRow][i].ToString().ToLower() != "p")
                            {
                                CodeMissingList.Add(OuterLinesCopy[intRow]);
                                boolValidStatus = false;
                                if (intConsolidated == 1)
                                    break;
                            }

                            if (OuterLinesCopy[intRow][i].ToString().ToLower() == "a" )
                            {
                                if (OuterLinesCopy[intRow][i].ToString() != "0" && OuterLinesCopy[intRow][i].ToString() != null && OuterLinesCopy[intRow][i].ToString() != "")
                                {
                                    //0039
                                    string Org = "";
                                    string strCorp = "";
                                    Org = Session["ORGID"].ToString();
                                    
                                    strCorp = Session["CORPOFFICEID"].ToString();

                                    int OffCount = 0;
                                    string strDay = OuterLinesCopy[intRow][i].ToString().ToLower();
                                    string strMnth = ddlMonth.Value;                                  
                                    int intYear1 = Convert.ToInt16(ddlYear.Value);
                                    int intMonth1 = Convert.ToInt16(strMnth);
                                    int NooFDaysMnth = DateTime.DaysInMonth(intYear1, intMonth1);
                                    if (intMonth1 < 10)
                                    {
                                        strMnth = "0" + strMnth;
                                    }

                                    dutyOf objDuty = new dutyOf();
                                    if (DayVal != "")
                                    {
                                        int intDate = Convert.ToInt32(DayVal);
                                        if (intDate < 10)
                                        {
                                            strDay = "0" + strDay;
                                        }

                                        DateTime day = objCommon.textToDateTime(DayVal + "-" + strMnth + "-" + intYear1);
                                        string sts = "0";
                                        string hol = objDuty.checkholiday(day, day, day);
                                        if (hol == "true")
                                        {
                                            CodeMissingList.Add(OuterLinesCopy[intRow]);
                                            OffCount++;
                                            boolValidStatus = false;
                                            continue;
                                        }
                                        string off = objDuty.CheckDutyOff(day, strCorp, Org);
                                        if (off == "true")
                                        {
                                            CodeMissingList.Add(OuterLinesCopy[intRow]);
                                            OffCount++;
                                            boolValidStatus = false;
                                            continue;
                                        }
                                        //end

                                        //if (OffCount > 0)
                                        //{
                                        //    boolValidStatus = false;
                                        //    if (intConsolidated == 1)
                                        //        break;
                                        //}
                                    }
                                }
                            }
                        }

                       //OT Amount validation
                        else if (i == 7)
                        {
                            string OT = OuterLines[intRow][7].ToString();
                            if (OT != "" )
                            {
                                string d = OuterLines[intRow][6].ToString().ToLower();
                                decimal decValue;
                                bool isOTdecimal = true;
                                isOTdecimal = decimal.TryParse(OuterLines[intRow][7].ToString(), out decValue);
                                if (isOTdecimal == false || OT.Length > 8)
                                {
                                    IncorrectOTList.Add(OuterLines[intRow]);
                                    boolValidStatus = false;
                                    if (intConsolidated == 1)
                                        break;
                                }
                                else if (Convert.ToDecimal(OT) > 24)
                                {
                                    IncorrectOTList.Add(OuterLines[intRow]);
                                    boolValidStatus = false;
                                    if (intConsolidated == 1)
                                        break;
                                }

                                  //0041

                                else if (OT != "" && OuterLines[intRow][6].ToString().ToLower() == "a" &&  OT!="0")
                                {
                                    IncorrectOTList.Add(OuterLines[intRow]);
                                    boolValidStatus = false;
                                    if (intConsolidated == 1)
                                        break;
                                }
                            }
                        }
                      // Remark Validation
                        else if (i == 8)
                        {
                            string remark = OuterLines[intRow][8].ToString();
                            if (remark != "" && remark.Length > 200)
                            {
                                IncorrectRemarksList.Add(OuterLines[intRow]);
                                boolValidStatus = false;
                                if (intConsolidated == 1)
                                    break;

                            }
                        }
                    }

                }
                if (boolValidStatus == false)
                {
                    if (OuterLines.Count >= intRow)
                        OuterLines.RemoveAt(intRow);
                }
            }

            //checking duplicate employee code inside the uploaded file
            for (int intRow = 0; intRow <= OuterLines.Count - 1; intRow++)
            {
                if (OuterLines.Count > intRow)
                {
                    string strDay = OuterLines[intRow][0].ToString();
                    string strEmpCode = OuterLines[intRow][2].ToString();
                    string strDupEmpCode = "";
                    for (int intSecondRow = 0; intSecondRow <= OuterLines.Count - 1; intSecondRow++)
                    {
                        if (intRow != intSecondRow)
                        {
                            if (strEmpCode == OuterLines[intSecondRow][2].ToString() && strDay == OuterLines[intSecondRow][0].ToString())
                            {
                                if (OuterLines.Count > intRow)
                                {
                                    DuplicateList.Add(OuterLines[intSecondRow]);
                                    OuterLines.RemoveAt(intSecondRow);
                                    strDupEmpCode = strEmpCode;
                                    intSecondRow = intSecondRow - 1;
                                }
                            }
                        }
                    }

                    bool checkIsDigit = strDay.All(char.IsDigit);
                    if (checkIsDigit == true)
                    {
                        int day = Convert.ToInt16(strDay);
                        if (day <= daysInMonth)
                        {
                            string strday = "", strMonth = "";
                            if (day < 10)
                            {
                                strday = "0" + day.ToString();
                            }
                            else
                            {
                                strday = day.ToString();
                            }
                            if (intMonth < 10)
                            {
                                strMonth = "0" + intMonth.ToString();
                            }
                            else
                            {
                                strMonth = intMonth.ToString();
                            }
                            objEntityEmpDailyWorkHour.DateOfWork = objCommon.textToDateTime(strday + "-" + strMonth + "-" + intYear.ToString());
                        }
                    }

                    string strEmpcode = OuterLines[intRow][2].ToString().Replace("<", string.Empty);
                    objEntityEmpDailyWorkHour.ActFileName = strEmpcode;

                    DataTable dtEmp = objBusinessEmpDailyWorkHour.checkEmpcodeDB(objEntityEmpDailyWorkHour);
                    //Table Dup
                  /*  if (dtEmp.Rows.Count > 0)
                    {
                        if (strDupEmpCode != strEmpcode)
                        {
                            DuplicateList.Add(OuterLines[intRow]);
                            //OuterLines.RemoveAt(intRow);
                        }
                    }*/
                    //Table Dup

                }
            }


            //For duplicate list
            HiddenFieldDupListCount.Value = DuplicateList.Count.ToString();
            if (DuplicateList.Count > 0)
            {

                string strRateAmendmentJson = ConvertArrayToJson(DuplicateList);
                HiddenRateUpdateList.Value = strRateAmendmentJson;

                string strRateMissing = CovertListToHTMLDup(DuplicateList);
                divDupTable.InnerHtml = strRateMissing;

            }


            //Incorrect list
            //assigning the records have missing ,duplicate and mismatch values
            CodeMissingList.Reverse();
            HiddenCodeMissingCount.Value = CodeMissingList.Count.ToString();
            if (CodeMissingList.Count < 100)
            {
                btnMissingCodeNextRecords.Enabled = false;

                string strCodeMissingHtml = CovertListToHTMLincrct(CodeMissingList);
                divMissingCodeReport.InnerHtml = strCodeMissingHtml;//incorrect attendece entry//doubt 21
            }
            else
            {
                btnMissingCodeNextRecords.Enabled = true;

                string strCodeMissingJson = ConvertArrayToJson(CodeMissingList);
                HiddenCodeMissingList.Value = strCodeMissingJson;
                var NewCodeMissingList = new List<string[]>();
                for (int intRow = 0; intRow < 100; intRow++)
                {
                    NewCodeMissingList.Add(CodeMissingList[intRow]);
                }
                HiddenCodeMissingNext.Value = "100";
                string strCodeMissingHtml = CovertListToHTMLincrct(NewCodeMissingList);
                divMissingCodeReport.InnerHtml = strCodeMissingHtml;
            }


            
            IncorrectDaysList.Reverse(); //data value having value consist of number of incorrect days
            HiddenIncorrectDayCount.Value = IncorrectDaysList.Count.ToString();//final sending value to client

            if (IncorrectDaysList.Count < 100)
            {
                btnIncorrectDaysNext.Enabled = false;
                string strCodeMissingHtml = CovertListToHTMLincrct(IncorrectDaysList);
                divIncorrectDays.InnerHtml = strCodeMissingHtml;
            }
            else
            {
                btnIncorrectDaysNext.Enabled = true;

                string strCodeMissingJson = ConvertArrayToJson(IncorrectDaysList);
                HiddenIncorrectDayList.Value = strCodeMissingJson;
                var NewIncorrectDayList = new List<string[]>();
                for (int intRow = 0; intRow < 100; intRow++)
                {
                    NewIncorrectDayList.Add(IncorrectDaysList[intRow]);
                }
                HiddenIncorrectEmpCodeNext.Value = "100";
                string strCodeMissingHtml = CovertListToHTMLincrct(NewIncorrectDayList);
                divIncorrectDays.InnerHtml = strCodeMissingHtml;
            }


            //OTCategoryL //#remark1
            IncorrectOTCategoryList.Reverse();
            HiddenIncorrectOTCatgCount.Value = IncorrectOTCategoryList.Count.ToString();
            if (IncorrectOTCategoryList.Count < 100)
            {
                btnIncorrectOTCatgNext.Enabled = false;
                string strCodeMissingHtml = CovertListToHTMLincrct(IncorrectOTCategoryList);
                divIncorrectOTCatg.InnerHtml = strCodeMissingHtml;
            }
            else
            {
                btnIncorrectOTCatgNext.Enabled = true;

                string strCodeMissingJson = ConvertArrayToJson(IncorrectOTCategoryList);
                HiddenIncorrectOTCatgList.Value = strCodeMissingJson;
                var NewIncorrectOTCatgList = new List<string[]>();
                for (int intRow = 0; intRow < 100; intRow++)
                {
                    NewIncorrectOTCatgList.Add(IncorrectOTCategoryList[intRow]);
                }
                HiddenIncorrectOTCatgNext.Value = "100";
                string strCodeMissingHtml = CovertListToHTMLincrct(NewIncorrectOTCatgList);
                divIncorrectOTCatg.InnerHtml = strCodeMissingHtml;
            }
            


            // Incorrect EmployeeCodeList
            //assigning the records have missing ,duplicate and mismatch values
            IncorrectEmployeeCodeList.Reverse();
            HiddenIncorrectEmpCodeCount.Value = IncorrectEmployeeCodeList.Count.ToString();
            if (IncorrectEmployeeCodeList.Count < 100)
            {
                btnIncorrectEmpCodeNext.Enabled = false;

                string strCodeMissingHtml = CovertListToHTMLincrct(IncorrectEmployeeCodeList);
                divIncorrectEmpCode.InnerHtml = strCodeMissingHtml;
            }
            else
            {
                btnIncorrectEmpCodeNext.Enabled = true;

                string strCodeMissingJson = ConvertArrayToJson(IncorrectEmployeeCodeList);
                HiddenIncorrectEmpCodeList.Value = strCodeMissingJson;
                var NewIncorrectEmployeeCodeList = new List<string[]>();
                for (int intRow = 0; intRow < 100; intRow++)
                {
                    NewIncorrectEmployeeCodeList.Add(IncorrectEmployeeCodeList[intRow]);
                }
                HiddenIncorrectEmpCodeNext.Value = "100";
                string strCodeMissingHtml = CovertListToHTMLincrct(NewIncorrectEmployeeCodeList);
                divIncorrectEmpCode.InnerHtml = strCodeMissingHtml;
            }

            // Incorrect EmployeeCodeList Ends


            // Incorrect ProjectCodeList
            //assigning the records have missing ,duplicate and mismatch values
            IncorrectProjectCodeList.Reverse();
            HiddenIncorrectProjectCodeCount.Value = IncorrectProjectCodeList.Count.ToString();
            if (IncorrectProjectCodeList.Count < 100)
            {
                btnIncorrectProjectCodeNext.Enabled = false;

                string strCodeMissingHtml = CovertListToHTMLincrct(IncorrectProjectCodeList);
                divIncorrectProjectCode.InnerHtml = strCodeMissingHtml;
            }
            else
            {
                btnIncorrectProjectCodeNext.Enabled = true;

                string strCodeMissingJson = ConvertArrayToJson(IncorrectProjectCodeList);
                HiddenIncorrectProjectCodeList.Value = strCodeMissingJson;
                var NewIncorrectProjectCodeList = new List<string[]>();
                for (int intRow = 0; intRow < 100; intRow++)
                {
                    NewIncorrectProjectCodeList.Add(IncorrectProjectCodeList[intRow]);
                }
                HiddenIncorrectProjectCodeNext.Value = "100";
                string strCodeMissingHtml = CovertListToHTMLincrct(NewIncorrectProjectCodeList);
                divIncorrectProjectCode.InnerHtml = strCodeMissingHtml;
            }

            // Incorrect ProjectCodeList Ends



            ////Incorrect OT 
            //assigning the records have missing ,duplicate and mismatch values
            IncorrectOTList.Reverse();
            HiddenIncorrectOTCount.Value = IncorrectOTList.Count.ToString();
            if (IncorrectOTList.Count < 100)
            {
                btnIncorrectOTNext.Enabled = false;

                string strIncorrectOTHtml = CovertListToHTMLincrct(IncorrectOTList);
                divIncorrrectOT.InnerHtml = strIncorrectOTHtml;
            }
            else
            {
                btnIncorrectOTNext.Enabled = true;

                string strIncorrectOTJson = ConvertArrayToJson(IncorrectOTList);
                HiddenIncorrectOTList.Value = strIncorrectOTJson;
                var NewIncorrectOTList = new List<string[]>();
                for (int intRow = 0; intRow < 100; intRow++)
                {
                    NewIncorrectOTList.Add(IncorrectOTList[intRow]);
                }
                HiddenIncorrectOTNext.Value = "100";
                string strIncorrectOTHtml = CovertListToHTMLincrct(NewIncorrectOTList);
                divIncorrrectOT.InnerHtml = strIncorrectOTHtml;
            }
            ////Incorrect OT Ends




          
            //assigning the records have missing ,duplicate and mismatch values
            IncorrectRemarksList.Reverse();
            HiddenIncorrectRemarksCount.Value = IncorrectRemarksList.Count.ToString();
            if (IncorrectRemarksList.Count < 100)
            {
                btnIncorrectRemarksNext.Enabled = false;

                string strIncorrectRemarksHtml = CovertListToHTMLincrct(IncorrectRemarksList);
                divIncorrectRemarks.InnerHtml = strIncorrectRemarksHtml;
            }
            else
            {
                btnIncorrectRemarksNext.Enabled = true;

                string strIncorrectRemarksJson = ConvertArrayToJson(IncorrectRemarksList);
                HiddenIncorrectRemarksList.Value = strIncorrectRemarksJson;
                var NewIncorrectRemarksList = new List<string[]>();
                for (int intRow = 0; intRow < 100; intRow++)
                {
                    NewIncorrectRemarksList.Add(IncorrectRemarksList[intRow]);
                }
                HiddenIncorrectRemarksNext.Value = "100";
                string strIncorrectRemarksHtml = CovertListToHTMLincrct(NewIncorrectRemarksList);
                divIncorrectRemarks.InnerHtml = strIncorrectRemarksHtml;
            }
            ////Incorrect Remarks Ends


            //already confirmed 
            //Incorrect list
            //assigning the records have missing ,duplicate and mismatch values
            AlreadyConfirmedList.Reverse();
            HiddenAlreadyConfirmedCount.Value = AlreadyConfirmedList.Count.ToString();
            if (AlreadyConfirmedList.Count < 100)
            {
                btnAlreadyConfirmedNext.Enabled = false;

                string strAlreadyConfirmedHtml = CovertListToHTMLincrct(AlreadyConfirmedList);
                divAlreadyConfirmed.InnerHtml = strAlreadyConfirmedHtml;
            }
            else
            {
                btnAlreadyConfirmedNext.Enabled = true;

                string strAlreadyConfirmedJson = ConvertArrayToJson(AlreadyConfirmedList);
                HiddenAlreadyConfirmedList.Value = strAlreadyConfirmedJson;
                var NewAlreadyConfirmedList = new List<string[]>();
                for (int intRow = 0; intRow < 100; intRow++)
                {
                    NewAlreadyConfirmedList.Add(AlreadyConfirmedList[intRow]);
                }
                HiddenAlreadyConfirmedNext.Value = "100";
                string strAlreadyConfirmedHtml = CovertListToHTMLincrct(NewAlreadyConfirmedList);
                divAlreadyConfirmed.InnerHtml = strAlreadyConfirmedHtml;
            }
            //already confirmed ends





            //For Checking duplication in the table
            HiddenFieldDupIdsDb.Value = "";
            for (int intRow = OuterLines.Count - 1; intRow >= 0; intRow--)
            {
                string strDay = OuterLines[intRow][0].ToString();
                bool checkIsDigit = strDay.All(char.IsDigit);
                if (checkIsDigit == true)
                {
                    int day = Convert.ToInt16(strDay);
                    if (day <= daysInMonth)
                    {
                        string strday = "", strMonth = "";
                        if (day < 10)
                        {
                            strday = "0" + day.ToString();
                        }
                        else
                        {
                            strday = day.ToString();
                        }
                        if (intMonth < 10)
                        {
                            strMonth = "0" + intMonth.ToString();
                        }
                        else
                        {
                            strMonth = intMonth.ToString();
                        }
                        objEntityEmpDailyWorkHour.DateOfWork = objCommon.textToDateTime(strday + "-" + strMonth + "-" + intYear.ToString());
                    }
                }

                string strEmpcode = OuterLines[intRow][2].ToString().Replace("<", string.Empty);
                objEntityEmpDailyWorkHour.ActFileName = strEmpcode;
                objEntityEmpDailyWorkHour.InsTableSts = tableSts;                
                DataTable dtEmp = objBusinessEmpDailyWorkHour.checkEmpcodeDB(objEntityEmpDailyWorkHour);
                if (dtEmp.Rows.Count > 0)
                {
                    HiddenFieldDupIdsDb.Value = HiddenFieldDupIdsDb.Value + dtEmp.Rows[0][0].ToString() + "-" + strEmpcode + ",";
                }
            }




            //correct list-CORRECT
            // OuterLines.Reverse();
            HiddenCostPriceMissingCount.Value = OuterLines.Count.ToString();

            if (OuterLines.Count < 100)
            {


                DataTable dtDetails = new DataTable();
                dtDetails.Columns.Add("DAY", typeof(string));
                dtDetails.Columns.Add("OT_CATEGORY", typeof(string));
                dtDetails.Columns.Add("EMPCODE", typeof(string));
                dtDetails.Columns.Add("EMPLOYEE", typeof(string));
                dtDetails.Columns.Add("DESG", typeof(string));
                // dtDetails.Columns.Add("JOBNUM", typeof(string)); //cmd evm-0023
                dtDetails.Columns.Add("PROJECT_CODE", typeof(string));
                dtDetails.Columns.Add("ATTENDANCE", typeof(string));
                dtDetails.Columns.Add("OT", typeof(string));
                dtDetails.Columns.Add("REMARKS", typeof(string));
                dtDetails.Columns.Add("IDLEHOUR", typeof(string));
                dtDetails.Columns.Add("FINALOT", typeof(string));
                dtDetails.Columns.Add("ROUNDEDOT", typeof(string));

                int intCurrectEmployeesCount = OuterLines.Count;
                int intErrorEmployeesCount = intTotalEmployeesCount - intCurrectEmployeesCount;

                //0039

                int plusattendenceerror = CodeMissingList.Count;
                intErrorEmployeesCount = intErrorEmployeesCount + plusattendenceerror;

                //end


                HiddenTotalCurrectEmp.Value = intCurrectEmployeesCount.ToString();
                HiddenTotalErrorEmp.Value = intErrorEmployeesCount.ToString();

                //binding data by row
                DataTable dtBankDtl = new DataTable();
                for (int intcnt = 0; intcnt < OuterLines.Count; intcnt++)
                {

                    string IdleHRcmn = txtIdleHrCmn.Text;
                    string strFinalOT = "";

                    int len = OuterLines[intcnt].Length;
                    DataRow drDtl = dtDetails.NewRow();
                    drDtl["DAY"] = OuterLines[intcnt][0].ToString();
                    drDtl["OT_CATEGORY"] = OuterLines[intcnt][1].ToString();

                    drDtl["EMPCODE"] = OuterLines[intcnt][2].ToString();
                    drDtl["EMPCODE"] = OuterLines[intcnt][2].ToString();
                    drDtl["EMPLOYEE"] = OuterLines[intcnt][3].ToString();
                    drDtl["DESG"] = OuterLines[intcnt][4].ToString();
                    // drDtl["JOBNUM"] = OuterLines[intcnt][3].ToString(); //cmd evm-0023
                    drDtl["PROJECT_CODE"] = OuterLines[intcnt][5].ToString();
                    drDtl["ATTENDANCE"] = OuterLines[intcnt][6].ToString();
                    if (len >= 8)
                    {
                        drDtl["OT"] = OuterLines[intcnt][7].ToString();


                        if (OuterLines[intcnt][7].ToString() != "")
                        {

                            if (Convert.ToDecimal(IdleHRcmn) >= Convert.ToDecimal(OuterLines[intcnt][7].ToString()))
                            {
                                strFinalOT = "0";
                            }
                            else
                            {
                                strFinalOT = Convert.ToString(Convert.ToDecimal(OuterLines[intcnt][7].ToString()) - Convert.ToDecimal(IdleHRcmn));
                            }
                        }
                        else
                        {
                            strFinalOT = "0";
                        }

                    }
                    else
                    {
                        drDtl["OT"] = "";
                    }
                    if (len >= 9)
                    {
                        drDtl["REMARKS"] = OuterLines[intcnt][8].ToString();
                    }
                    else
                    {
                        drDtl["REMARKS"] = "";
                    }
                    drDtl["IDLEHOUR"] = IdleHRcmn;
                    drDtl["FINALOT"] = strFinalOT;
                    drDtl["ROUNDEDOT"] = strFinalOT;

                    dtDetails.Rows.Add(drDtl);

                }

                
                string strJsonFf = DataTableToJSONWithJavaScriptSerializer(dtDetails);
                HiddenRateAmendmentList.Value = strJsonFf;

                //Start:-New Code:22-05-2018
                HiddenFieldCorrectListJson.Value = strJsonFf;
                //End:-New Code:22-05-2018

                btnRateMissingUpdate.Enabled = true;
                if (HiddenCostPriceMissingCount.Value == "0")
                {
                    btnRateMissingUpdate.Enabled = false;
                }
                btnCostPriceMissingNextRecords.Enabled = false;

                //NEW CODE

                string strupdatelist = ConvertArrayToJson(OuterLines);
                HiddenCorrectListCopy.Value = strupdatelist;
                //END NEW CODE
                string strRateMissing = CovertListToHTML(OuterLines);
                divCostPriceMissingReport.InnerHtml = strRateMissing;//doubt 2
            }
            else
            {




                DataTable dtDetails = new DataTable();
                dtDetails.Columns.Add("DAY", typeof(string));
                dtDetails.Columns.Add("OT_CATEGORY", typeof(string));
                dtDetails.Columns.Add("EMPCODE", typeof(string));
                dtDetails.Columns.Add("EMPLOYEE", typeof(string));
                dtDetails.Columns.Add("DESG", typeof(string));
                // dtDetails.Columns.Add("JOBNUM", typeof(string)); //cmd evm-0023
                dtDetails.Columns.Add("PROJECT_CODE", typeof(string));
                dtDetails.Columns.Add("ATTENDANCE", typeof(string));
                dtDetails.Columns.Add("OT", typeof(string));
                dtDetails.Columns.Add("REMARKS", typeof(string));
                dtDetails.Columns.Add("IDLEHOUR", typeof(string));
                dtDetails.Columns.Add("FINALOT", typeof(string));
                dtDetails.Columns.Add("ROUNDEDOT", typeof(string));


                DataTable dtBankDtl = new DataTable();
                for (int intcnt = 0; intcnt < OuterLines.Count; intcnt++)
                {

                    string IdleHRcmn = txtIdleHrCmn.Text;
                    string strFinalOT = "";

                    int len = OuterLines[intcnt].Length;
                    DataRow drDtl = dtDetails.NewRow();
                    drDtl["DAY"] = OuterLines[intcnt][0].ToString();
                    drDtl["OT_CATEGORY"] = OuterLines[intcnt][1].ToString();
                    drDtl["EMPCODE"] = OuterLines[intcnt][2].ToString();
                    drDtl["EMPLOYEE"] = OuterLines[intcnt][3].ToString();
                    drDtl["DESG"] = OuterLines[intcnt][4].ToString();
                    // drDtl["JOBNUM"] = OuterLines[intcnt][3].ToString(); //cmd evm-0023
                    drDtl["PROJECT_CODE"] = OuterLines[intcnt][5].ToString();
                    drDtl["ATTENDANCE"] = OuterLines[intcnt][6].ToString();
                    if (len >= 8)
                    {
                        drDtl["OT"] = OuterLines[intcnt][7].ToString();


                        if (OuterLines[intcnt][7].ToString() != "")
                        {
                            if (Convert.ToDecimal(IdleHRcmn) >= Convert.ToDecimal(OuterLines[intcnt][7].ToString()))
                            {
                                strFinalOT = "0";
                            }
                            else
                            {
                                strFinalOT = Convert.ToString(Convert.ToDecimal(OuterLines[intcnt][7].ToString()) - Convert.ToDecimal(IdleHRcmn));
                            }
                        }
                        else
                        {
                            strFinalOT = "0";
                        }
                    }
                    else
                    {
                        drDtl["OT"] = "";
                    }
                    if (len >= 9)
                    {
                        drDtl["REMARKS"] = OuterLines[intcnt][8].ToString();
                    }
                    else
                    {
                        drDtl["REMARKS"] = "";
                    }
                    drDtl["IDLEHOUR"] = IdleHRcmn;
                    drDtl["FINALOT"] = strFinalOT;
                    drDtl["ROUNDEDOT"] = strFinalOT;

                    dtDetails.Rows.Add(drDtl);

                }

                string strJsonFf = DataTableToJSONWithJavaScriptSerializer(dtDetails);
                HiddenRateAmendmentList.Value = strJsonFf;
                //Start:-New Code:22-05-2018
                HiddenFieldCorrectListJson.Value = strJsonFf;
                //End:-New Code:22-05-2018

                btnRateMissingUpdate.Enabled = true;
                btnCostPriceMissingNextRecords.Enabled = true;


                string strupdatelist = ConvertArrayToJson(OuterLines);
                HiddenCorrectListCopy.Value = strupdatelist;


                //end new code


                string strRateMissingJson = ConvertArrayToJson(OuterLines);
                HiddenCostPriceMissingList.Value = strRateMissingJson;

                var CostPriceMissList = new List<string[]>();
                for (int intRow = 0; intRow < 100; intRow++)
                {
                    CostPriceMissList.Add(OuterLines[intRow]);
                }
                HiddenCostPriceMissingNext.Value = "100";
                string strRateMissingHtml = CovertListToHTML(CostPriceMissList);
                divCostPriceMissingReport.InnerHtml = strRateMissingHtml;

            }

            ScriptManager.RegisterStartupScript(this, GetType(), "ViewMissingProductCode", "ViewMissingProductCode();", true);

        }
        catch
        {
            Response.Redirect("hcm_Monthly_Attendance_Sheet.aspx?InsUpd=Err");
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


    //When Update Button is clicked
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBusinessLayerEmployeeDailyWorkHour objBusinessEmpDailyWorkHour = new clsBusinessLayerEmployeeDailyWorkHour();
        clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour = new clsEntityEmployeeDailyWorkHour();
        List<clsEntityEmployeeDailyWorkHourDtl> objEntityEmpDailyHrList = new List<clsEntityEmployeeDailyWorkHourDtl>();
        List<clsEntityEmployeeDailyWorkHour> objEntityEmpDailyHrMasterList = new List<clsEntityEmployeeDailyWorkHour>();



        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEmpDailyWorkHour.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityEmpDailyWorkHour.orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        if (Session["USERID"] != null)
        {
            objEntityEmpDailyWorkHour.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }



      
        objEntityCommon.CorporateID = objEntityEmpDailyWorkHour.CorpId;
        objEntityCommon.Organisation_Id = objEntityEmpDailyWorkHour.orgid;


        objEntityEmpDailyWorkHour.ActFileName = HiddenFile.Value;
        objEntityEmpDailyWorkHour.FileName = HiddenFile.Value; 
        if (txtIdleHrCmn.Text.Trim() != "")
            objEntityEmpDailyWorkHour.IdleHourCmn = Convert.ToDecimal(txtIdleHrCmn.Text);



        string strFilePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.MONTHLY_ATTENDACE_SHEET);
        string strData = Server.MapPath(strFilePath) + "/" + HiddenFile.Value;
        string jsonDataPW = HiddenFieldCorrectListJson.Value;
        string R1PW = jsonDataPW.Replace("\"{", "\\{");
        string R2PW = R1PW.Replace("\\n", "\r\n");
        string R3PW = R2PW.Replace("\\", "");
        string R4PW = R3PW.Replace("}\"]", "}]");
        string R5PW = R4PW.Replace("}\",", "},");
        List<clsWorkHourDtl> objWBDataPWList = new List<clsWorkHourDtl>();
        objWBDataPWList = JsonConvert.DeserializeObject<List<clsWorkHourDtl>>(R5PW);

        try
        {
            if (objWBDataPWList != null && objWBDataPWList.Count > 0)
            {
                string[] strarrDupValues = null;

                int intRow = 1;
                foreach (clsWorkHourDtl objclsJSData in objWBDataPWList)
                {


                    bool flag = true;
                    string[] strarrCancldtlIds = HiddenFieldCancelIDs.Value.Split(',');
                    foreach (string strDtlId in strarrCancldtlIds)
                    {
                        if (strDtlId == intRow.ToString())
                        {
                            flag = false;
                        }
                    }



                    if (HiddenFieldOverWriteSts.Value == "0")
                    {
                        strarrDupValues = HiddenFieldDupIdsDb.Value.Split(',');
                        foreach (string strDtlId in strarrDupValues)
                        {
                            string[] strarrDup = strDtlId.Split('-');
                            if (strarrDup[1] == objclsJSData.EMPCODE)
                            {
                                flag = false;
                            }
                        }
                    }
                    else if (HiddenFieldOverWriteSts.Value == "1")
                    {
                        strarrDupValues = HiddenFieldDupIdsDb.Value.Split(',');

                    }

                    if (flag == true)
                    {

                        string strOTCatgsAMPLEEE = objclsJSData.OT_CATEGORY;

                        clsEntityEmployeeDailyWorkHour objEntityEmpDailyHrMasterDtl = new clsEntityEmployeeDailyWorkHour();
                        clsEntityEmployeeDailyWorkHourDtl objEntityEmpDailyWorkHourDtl = new clsEntityEmployeeDailyWorkHourDtl();

                        #region MASTER     
                      
                        objEntityEmpDailyWorkHour.ActFileName = objclsJSData.EMPCODE;

                        objEntityEmpDailyHrMasterDtl.ActFileName = HiddenFile.Value;
                        objEntityEmpDailyHrMasterDtl.FileName = HiddenFile.Value;

                        objEntityEmpDailyHrMasterDtl.CorpId = objEntityEmpDailyWorkHour.CorpId;
                        objEntityEmpDailyHrMasterDtl.orgid = objEntityEmpDailyWorkHour.orgid;
                        objEntityEmpDailyHrMasterDtl.UserId = objEntityEmpDailyWorkHour.UserId;

                        if (txtIdleHrCmn.Text.Trim() != "")
                            objEntityEmpDailyHrMasterDtl.IdleHourCmn = Convert.ToDecimal(txtIdleHrCmn.Text);



                        int intMonth = Convert.ToInt16(ddlMonth.Value);
                        int intYear = Convert.ToInt16(ddlYear.Value);
                        int day = Convert.ToInt32(objclsJSData.DAY);
                        string strday = "", strMonth = "";
                        if (day < 10)
                        {
                            strday = "0" + day.ToString();
                        }
                        else
                        {
                            strday = day.ToString();
                        }
                        if (intMonth < 10)
                        {
                            strMonth = "0" + intMonth.ToString();
                        }
                        else
                        {
                            strMonth = intMonth.ToString();
                        }
                        objEntityEmpDailyHrMasterDtl.DateOfWork = objCommon.textToDateTime(strday + "-" + strMonth + "-" + intYear.ToString());
                        objEntityEmpDailyWorkHour.DateOfWork = objCommon.textToDateTime(strday + "-" + strMonth + "-" + intYear.ToString());


                        string strOTCatg = objclsJSData.OT_CATEGORY.ToLower();

                        if (strOTCatg == "h")
                        {
                            strOTCatg = "HOLIDAY OT";
                        }
                        else
                        {
                            strOTCatg = "NORMAL OT";
                        }
                        objEntityEmpDailyWorkHour.OTCatgName = strOTCatg;
                        DataTable dtOtCatgry = objBusinessEmpDailyWorkHour.checkOTCategory(objEntityEmpDailyWorkHour);
                        if (dtOtCatgry.Rows.Count>0)
                            objEntityEmpDailyHrMasterDtl.HolidaySts = Convert.ToInt32(dtOtCatgry.Rows[0]["OVRTMCATG_ID"].ToString());




                       


                        #endregion MASTER

                        int insTableSts = 0;//0-normal insertion,1-insert to amendment tables

                       
                        objEntityEmpDailyWorkHourDtl.CorpId = objEntityEmpDailyWorkHour.CorpId;

                        DataTable dtEmp = objBusinessEmpDailyWorkHour.checkEmpcode(objEntityEmpDailyWorkHour);
                        if (dtEmp.Rows.Count > 0)
                        {
                            objEntityEmpDailyWorkHourDtl.UserId = Convert.ToInt32(dtEmp.Rows[0][3].ToString());

                            //Start:-To check where to insert
                            if (dtEmp.Rows[0]["EMPDLYHR_CNFRM_STS"].ToString().Trim() == "1" && (dtEmp.Rows[0]["PROCESSED_COUNT"].ToString().Trim() != "0" || dtEmp.Rows[0]["LEAVE_SETTLED_COUNT"].ToString().Trim() != "0"))
                            {
                                insTableSts = 1;
                            }
 
                            //End:-To check where to insert
                        }

                        if (insTableSts == 0)
                        {
                            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.MONTHLY_ATTENDACE_SHEET);
                        }
                        else
                        {
                            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.MONTHLY_ATTENDACE_SHEET_AMNT);
                        }
                        string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
                        objEntityEmpDailyHrMasterDtl.EmpDlyWrkHrID = Convert.ToInt32(strNextId);
                        objEntityEmpDailyWorkHourDtl.EmpDlyWrkHrID = Convert.ToInt32(strNextId);

                        objEntityEmpDailyHrMasterDtl.InsTableSts = insTableSts;
                        objEntityEmpDailyWorkHourDtl.InsTableSts = insTableSts;

                        objEntityEmpDailyWorkHourDtl.JobTitle = objclsJSData.PROJECT_CODE;

                        objEntityEmpDailyWorkHour.FileName = objclsJSData.PROJECT_CODE;
                        DataTable dtProject = objBusinessEmpDailyWorkHour.checkProjectCode(objEntityEmpDailyWorkHour);
                        if (dtProject.Rows.Count > 0)
                        {
                            objEntityEmpDailyHrMasterDtl.ProjectId = Convert.ToInt32(dtProject.Rows[0]["PROJECT_ID"].ToString());
                            objEntityEmpDailyWorkHourDtl.ProjectId = Convert.ToInt32(dtProject.Rows[0]["PROJECT_ID"].ToString());
                        }

                        //  objEntityEmpDailyWorkHourDtl.JobTitle = objclsJSData.JOBNUM;
                        if (objclsJSData.OT != "")
                        {
                            objEntityEmpDailyWorkHourDtl.OT = Convert.ToDecimal(objclsJSData.OT);
                        }
                        objEntityEmpDailyWorkHourDtl.Remark = objclsJSData.REMARKS;
                        objEntityEmpDailyWorkHourDtl.EmployeeName = objclsJSData.EMPLOYEE;
                        objEntityEmpDailyWorkHourDtl.Designation = objclsJSData.DESG;
                        objEntityEmpDailyWorkHourDtl.Attendance = objclsJSData.ATTENDANCE;
                        if (objEntityEmpDailyWorkHourDtl.Attendance.ToUpper() == "P")
                        {
                            objEntityEmpDailyWorkHourDtl.IdleHour = Convert.ToDecimal(objclsJSData.IDLEHOUR);
                        }
                        objEntityEmpDailyWorkHourDtl.RoundedOT = Convert.ToDecimal(objclsJSData.ROUNDEDOT);

                        objEntityEmpDailyHrMasterList.Add(objEntityEmpDailyHrMasterDtl);
                        objEntityEmpDailyHrList.Add(objEntityEmpDailyWorkHourDtl);

                    }

                    intRow++;
                }

                objEntityEmpDailyWorkHour.ActFileName = HiddenFile.Value;

                if (HiddenFieldOverWriteSts.Value == "0")
                {
                    strarrDupValues = null;
                }
                 objBusinessEmpDailyWorkHour.InsertMonthlyWorkHourSheet(objEntityEmpDailyHrMasterList, objEntityEmpDailyHrList, strarrDupValues);                
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                Response.Redirect("hcm_Monthly_Attendance_Sheet.aspx?InsUpd=Upd");
            }
        }
        catch
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "ShowError", "ShowError();", true);
        }
    }



    //create a datatable corresponding to the string array
    public string CovertListToHTML(List<string[]> ProuctList, string strProductRateName = null)
    {
        string IdleHRcmn = txtIdleHrCmn.Text;
        string strFinalOT = "";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"table table-bordered table-striped\" width=\"100%\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr >";
        //strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";
        strHtml += "<th class=\"\" style=\"width:3%;text-align: left; word-wrap:break-word;padding:4px\">" + "Day" + "</th>";
        strHtml += "<th class=\"\" style=\"width:8%;text-align: left; word-wrap:break-word;padding:4px\">" + "OT Category" + "</th>";

        strHtml += "<th class=\"\" style=\"width:10%;text-align: left; word-wrap:break-word;padding:4px\">" + "Employee Code" + "</th>";
        strHtml += "<th class=\"\" style=\"width:19%;text-align: left; word-wrap:break-word;padding:4px\">" + "Employee" + "</th>";
        strHtml += "<th class=\"\" style=\"width:10%;text-align: left; word-wrap:break-word;padding:4px\">" + "Designation" + "</th>";
        // strHtml += "<th class=\"\"  style=\"width:10%;text-align:left; word-wrap:break-word;padding:4px\">" + "Job Number" + "</th>"; //cmd evm-0023
        strHtml += "<th class=\"\"  style=\"width:10%;text-align:left; word-wrap:break-word;padding:4px\">" + "Project Code" + "</th>";
        strHtml += "<th class=\"\" style=\"width:6%;text-align: center; word-wrap:break-word;padding:4px\">" + "Attendance" + "</th>";
        strHtml += "<th class=\"\" style=\"width:5%;text-align: left; word-wrap:break-word;padding:4px\">" + "O.T" + "</th>";
        strHtml += "<th class=\"\" style=\"width:5%;text-align: left; word-wrap:break-word;padding:4px\">" + "Idle Hour" + "</th>";
        strHtml += "<th class=\"\" style=\"width:5%;text-align: left; word-wrap:break-word;padding:4px\">" + "Final O.T" + "</th>";
        strHtml += "<th class=\"\" style=\"width:5%;text-align: left; word-wrap:break-word;padding:4px\">" + "Rounded O.T" + "</th>";
        strHtml += "<th class=\"\" style=\"width:25%;text-align: left; word-wrap:break-word;padding:4px\">" + "Remarks" + "</th>";
        if (ProuctList.Count > 0)
        {
            strHtml += "<th class=\"\" style=\"width:5%;text-align: left; word-wrap:break-word;\"></th>";
        }


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        int intSerialNumber = 0;
        strHtml += "<tbody>";
        if (ProuctList.Count == 0)
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"\" colspan='12'> <p style=\"text-align: center;font-family: calibri;\">No Data Available</p></td>";
            strHtml += "</tr>";

        }
        else
        {
            for (int intRowBodyCount = 0; intRowBodyCount < ProuctList.Count; intRowBodyCount++)
            {
                intSerialNumber++;
                strHtml += "<tr id=\"row" + intSerialNumber + "\" >";
                //for serial number
                //strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: left;\">" + intSerialNumber + "</td>";


                int len = ProuctList[intRowBodyCount].Length;


                string Day = ProuctList[intRowBodyCount][0].ToString().Replace("<", string.Empty);
                Day = Day.Replace(">", string.Empty);
                strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\" >";
                strHtml += "<input tabindex=\"-1\" class=\"input\" id=\"txtDay" + intSerialNumber + "\" name=\"txtDay" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + Day + "\"   />";
                strHtml += "</td>";

                string OTCatg = ProuctList[intRowBodyCount][1].ToString().Replace("<", string.Empty);
                OTCatg = OTCatg.Replace(">", string.Empty);
                strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\" >";
                strHtml += "<input tabindex=\"-1\" class=\"input\" id=\"txtOTCatg" + intSerialNumber + "\" name=\"txtOTCatg" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + OTCatg + "\"   />";
                strHtml += "</td>";


                string Empcode = ProuctList[intRowBodyCount][2].ToString().Replace("<", string.Empty);
                Empcode = Empcode.Replace(">", string.Empty);
                strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\" >";
                strHtml += "<input tabindex=\"-1\" class=\"input\" id=\"txtEmpCode" + intSerialNumber + "\" name=\"txtEmpCode" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + Empcode + "\"   />";
                strHtml += "</td>";


                string Employee = ProuctList[intRowBodyCount][3].ToString().Replace("<", string.Empty);
                Employee = Employee.Replace(">", string.Empty);
                strHtml += "<td class=\"tdT\" style=\" width:19%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                strHtml += "<input tabindex=\"-1\" id=\"txtEmployee" + intSerialNumber + "\" name=\"txtEmployee" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + Employee + "\"   />";
                strHtml += "</td>";



                string Designation = ProuctList[intRowBodyCount][4].ToString().Replace("<", string.Empty);
                Designation = Designation.Replace(">", string.Empty);
                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                strHtml += "<input tabindex=\"-1\" id=\"txtDesignation" + intSerialNumber + "\" name=\"txtDesignation" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + Designation + "\"  />";
                strHtml += "</td>";

                string Job = ProuctList[intRowBodyCount][5].ToString().Replace("<", string.Empty);
                Job = Job.Replace(">", string.Empty);
                strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                strHtml += "<input tabindex=\"-1\" id=\"txtJob" + intSerialNumber + "\" name=\"txtJob" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + Job + "\"   />";
                strHtml += "</td>";



                string Attendance = ProuctList[intRowBodyCount][6].ToString().Replace("<", string.Empty);
                Attendance = Attendance.Replace(">", string.Empty);
                strHtml += "<td  class=\"tdT\" style=\" width:6%;word-break: break-all; word-wrap:break-word;text-align: center;padding:0px;height:20px;\"  >";
                strHtml += "<input tabindex=\"-1\" id=\"txtAtt" + intSerialNumber + "\" name=\"txtAtt" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;text-align:center;\" value=\"" + Attendance + "\"   />";
                strHtml += "</td>";


                if (len >= 8)
                {
                    string OT = ProuctList[intRowBodyCount][7].ToString().Replace("<", string.Empty);
                    if (OT == "")
                    {
                        OT = "0";
                    }
                    OT = OT.Replace(">", string.Empty);
                    strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                    strHtml += "<input tabindex=\"-1\" id=\"txtOT" + intSerialNumber + "\" name=\"txtOT" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + OT + "\"  onblur=\"return BlurIdleHr(" + intSerialNumber + ");\" onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"IncrmntConfrmCounter();\" maxlength=5 />";
                    strHtml += "</td>";

                    if (Convert.ToDecimal(IdleHRcmn) >= Convert.ToDecimal(OT))
                    {
                        strFinalOT = "0";
                    }
                    else
                    {
                        strFinalOT = Convert.ToString(Convert.ToDecimal(OT) - Convert.ToDecimal(IdleHRcmn));
                    }
                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                    strHtml += "<input tabindex=\"-1\" id=\"txtOT" + intSerialNumber + "\"  name=\"txtOT" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\"  onblur=\"return BlurIdleHr(" + intSerialNumber + ");\" onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"IncrmntConfrmCounter();\" maxlength=5 />";
                    strHtml += "</td>";
                }


                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                strHtml += "<input id=\"txtIdleHr" + intSerialNumber + "\" name=\"txtIdleHr" + intSerialNumber + "\" type=text   style=\" width:100%;\" value=\"" + IdleHRcmn + "\"    onblur=\"return BlurIdleHr(" + intSerialNumber + ");\" onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"IncrmntConfrmCounter();\" maxlength=5 />";
                strHtml += "</td>";



                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                strHtml += "<input tabindex=\"-1\" id=\"txtFinalOT" + intSerialNumber + "\" name=\"txtFinalOT" + intSerialNumber + "\" type=text value=\"" + strFinalOT + "\"   style=\" width:100%;pointer-events:none;background-color: gainsboro;\"   onblur=\"return BlurIdleHr(" + intSerialNumber + ");\" onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"IncrmntConfrmCounter();\" maxlength=5 />";
                strHtml += "</td>";


                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                strHtml += "<input id=\"txtRndedOT" + intSerialNumber + "\" name=\"txtRndedOT" + intSerialNumber + "\" type=text   style=\" width:100%;\" value=\"" + strFinalOT + "\"   onblur=\"return BlurRoundedOT(" + intSerialNumber + ");\" onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"IncrmntConfrmCounter();\" maxlength=5 />";
                strHtml += "</td>";





                if (len >= 9)
                {
                    string Remarks = ProuctList[intRowBodyCount][8].ToString().Replace("<", string.Empty);
                    Remarks = Remarks.Replace(">", string.Empty);
                    strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                    strHtml += "<input id=\"txtRemark" + intSerialNumber + "\" onblur=\"return BlurRemark(" + intSerialNumber + ");\" name=\"txtRemark" + intSerialNumber + "\"  type=text   style=\" width:100%;\" value=\"" + Remarks + "\" onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" onchange=\"IncrmntConfrmCounter();\"  maxlength=100/>";
                    strHtml += "</td>";

                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                    strHtml += "<input id=\"txtRemark" + intSerialNumber + "\" onblur=\"return BlurRemark(" + intSerialNumber + ");\" name=\"txtRemark" + intSerialNumber + "\"  type=text   style=\" width:100%;\" onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" maxlength=100 onchange=\"IncrmntConfrmCounter();\" />";
                    strHtml += "</td>";
                }




                strHtml += "<td class=\"tdT\" style=\"width:5%; word-break: break-all; word-wrap:break-word;text-align: center;padding:0px;height:20px;\">" + " <a  style=\"cursor:pointer;margin-top:-1.5%;opacity:1;margin-left:1%;z-index: 29;\" title=\"Cancel\" onclick='return DeleteRow(" + intSerialNumber + ");' >"
                                         + "<img style=\"cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";


                strHtml += "</tr>";
            }
        }
        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    //create a datatable corresponding to the string array
    public string CovertListToHTMLincrct(List<string[]> ProuctList, string strProductRateName = null)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTableIncrct\" class=\"table table-bordered table-striped\" width=\"100%\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr >";
        //strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";
        strHtml += "<th class=\"\" style=\"width:3%;text-align: left; word-wrap:break-word;padding:4px\">" + "Day" + "</th>";
        strHtml += "<th class=\"\" style=\"width:8%;text-align: left; word-wrap:break-word;padding:4px\">" + "OT Category" + "</th>";
        strHtml += "<th class=\"\" style=\"width:10%;text-align: left; word-wrap:break-word;padding:4px\">" + "Employee Code" + "</th>";
        strHtml += "<th class=\"\" style=\"width:20%;text-align: left; word-wrap:break-word;padding:4px\">" + "Employee" + "</th>";
        strHtml += "<th class=\"\" style=\"width:20%;text-align: left; word-wrap:break-word;padding:4px\">" + "Designation" + "</th>";
        //  strHtml += "<th class=\"\"  style=\"width:10%;text-align:left; word-wrap:break-word;padding:4px\">" + "Job Number" + "</th>"; //cmd evm-0023
        strHtml += "<th class=\"\"  style=\"width:10%;text-align:left; word-wrap:break-word;padding:4px\">" + "Project Code" + "</th>";
        strHtml += "<th class=\"\" style=\"width:6%;text-align: center; word-wrap:break-word;padding:4px\">" + "Attendance" + "</th>";
        strHtml += "<th class=\"\" style=\"width:5%;text-align: left; word-wrap:break-word;padding:4px\">" + "O.T" + "</th>";
        strHtml += "<th class=\"\" style=\"width:25%;text-align: left; word-wrap:break-word;padding:4px\">" + "Remarks" + "</th>";



        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        int intSerialNumber = 0;
        strHtml += "<tbody>";
        if (ProuctList.Count == 0)
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"\" colspan='8'> <p style=\"text-align: center;font-family: calibri;\">No Data Available</p></td>";
            strHtml += "</tr>";

        }
        else
        {
            for (int intRowBodyCount = 0; intRowBodyCount < ProuctList.Count; intRowBodyCount++)
            {
                intSerialNumber++;
                strHtml += "<tr id=\"rows" + intSerialNumber + "\" >";
                //for serial number
                //strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: left;\">" + intSerialNumber + "</td>";


                int len = ProuctList[intRowBodyCount].Length;


                string Day = ProuctList[intRowBodyCount][0].ToString().Replace("<", string.Empty);
                Day = Day.Replace(">", string.Empty);
                strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\" >";
                strHtml += "<input tabindex=\"-1\" class=\"input\" id=\"txtDay" + intSerialNumber + "\" name=\"txtDay" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + Day + "\"   />";
                strHtml += "</td>";

                string OTCatg = ProuctList[intRowBodyCount][1].ToString().Replace("<", string.Empty);
                OTCatg = OTCatg.Replace(">", string.Empty);
                strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\" >";
                strHtml += "<input tabindex=\"-1\" class=\"input\" id=\"txtOTCatg" + intSerialNumber + "\" name=\"txtOTCatg" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + OTCatg + "\"   />";
                strHtml += "</td>";

                string Empcode = ProuctList[intRowBodyCount][2].ToString().Replace("<", string.Empty);
                Empcode = Empcode.Replace(">", string.Empty);
                strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\" >";
                strHtml += "<input tabindex=\"-1\" class=\"input\" id=\"txtEmpCodeI" + intSerialNumber + "\" name=\"txtEmpCodeI" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + Empcode + "\"   />";
                strHtml += "</td>";


                string Employee = ProuctList[intRowBodyCount][3].ToString().Replace("<", string.Empty);
                Employee = Employee.Replace(">", string.Empty);
                strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                strHtml += "<input tabindex=\"-1\"  id=\"txtEmployeeI" + intSerialNumber + "\" name=\"txtEmployeeI" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + Employee + "\"   />";
                strHtml += "</td>";



                string Designation = ProuctList[intRowBodyCount][4].ToString().Replace("<", string.Empty);
                Designation = Designation.Replace(">", string.Empty);
                strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                strHtml += "<input tabindex=\"-1\" id=\"txtDesignationI" + intSerialNumber + "\" name=\"txtDesignationI" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + Designation + "\"  />";
                strHtml += "</td>";

                string Job = ProuctList[intRowBodyCount][5].ToString().Replace("<", string.Empty);
                Job = Job.Replace(">", string.Empty);
                strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                strHtml += "<input tabindex=\"-1\" id=\"txtJobI" + intSerialNumber + "\" name=\"txtJobI" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + Job + "\"   />";
                strHtml += "</td>";



                string Attendance = ProuctList[intRowBodyCount][6].ToString().Replace("<", string.Empty);
                Attendance = Attendance.Replace(">", string.Empty);
                strHtml += "<td  class=\"tdT\" style=\" width:6%;word-break: break-all; word-wrap:break-word;text-align: center;padding:0px;height:20px;\"  >";
                strHtml += "<input tabindex=\"-1\" id=\"txtAttI" + intSerialNumber + "\" name=\"txtAttI" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;text-align:center;\" value=\"" + Attendance + "\"   />";
                strHtml += "</td>";
                //#remark
                if (len >= 8)
                {
                    string OT = ProuctList[intRowBodyCount][7].ToString().Replace("<", string.Empty);
                    OT = OT.Replace(">", string.Empty);
                    strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                    strHtml += "<input tabindex=\"-1\" id=\"txtOTI" + intSerialNumber + "\" name=\"txtOTI" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + OT + "\"  onblur=\"return BlurIdleHr(" + intSerialNumber + ");\" onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"IncrmntConfrmCounter();\" maxlength=5 />";
                    strHtml += "</td>";

                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                    strHtml += "<input tabindex=\"-1\" id=\"txtOTI" + intSerialNumber + "\"  name=\"txtOTI" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\"  onblur=\"return BlurIdleHr(" + intSerialNumber + ");\" onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"IncrmntConfrmCounter();\" maxlength=5 />";
                    strHtml += "</td>";
                }
                if (len >= 9)
                {
                    string Remarks = ProuctList[intRowBodyCount][8].ToString().Replace("<", string.Empty);
                    Remarks = Remarks.Replace(">", string.Empty);
                    strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                    strHtml += "<input tabindex=\"-1\" id=\"txtRemarkI" + intSerialNumber + "\" name=\"txtRemarkI" + intSerialNumber + "\"  type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + Remarks + "\" onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" onchange=\"IncrmntConfrmCounter();\"  maxlength=100/>";
                    strHtml += "</td>";

                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                    strHtml += "<input tabindex=\"-1\" id=\"txtRemarkI" + intSerialNumber + "\" name=\"txtRemarkI" + intSerialNumber + "\"  type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" maxlength=100 onchange=\"IncrmntConfrmCounter();\" />";
                    strHtml += "</td>";
                }



                strHtml += "</tr>";
            }
        }
        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }

    //create a datatable corresponding to the string array
    public string CovertListToHTMLDup(List<string[]> ProuctList, string strProductRateName = null)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTableDup\" class=\"table table-bordered table-striped\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr >";
        //strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";

        strHtml += "<th  style=\"width:5%;text-align: left; word-wrap:break-word;\"></th>";
        strHtml += "<th class=\"\" style=\"width:3%;text-align: left; word-wrap:break-word;padding:4px\">" + "Day" + "</th>";
        strHtml += "<th class=\"\" style=\"width:8%;text-align: left; word-wrap:break-word;padding:4px\">" + "OT Category" + "</th>";
        strHtml += "<th  style=\"width:10%;text-align: left; word-wrap:break-word;\">" + "Employee Code" + "</th>";
        strHtml += "<th  style=\"width:20%;text-align: left; word-wrap:break-word;\">" + "Employee" + "</th>";
        strHtml += "<th  style=\"width:20%;text-align: left; word-wrap:break-word;\">" + "Designation" + "</th>";
        //   strHtml += "<th   style=\"width:10%;text-align:left; word-wrap:break-word;\">" + "Job Number" + "</th>";////cmd evm-0023
        strHtml += "<th   style=\"width:10%;text-align:left; word-wrap:break-word;\">" + "Project Code" + "</th>";
        strHtml += "<th  style=\"width:6%;text-align: center; word-wrap:break-word;\">" + "Attendance" + "</th>";
        strHtml += "<th  style=\"width:5%;text-align: left; word-wrap:break-word;\">" + "O.T" + "</th>";
        strHtml += "<th  style=\"width:25%;text-align: left; word-wrap:break-word;\">" + "Remarks" + "</th>";




        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        int intSerialNumber = 0;
        strHtml += "<tbody>";
        if (ProuctList.Count == 0)
        {
            strHtml += "<tr>";
            strHtml += "<td  colspan='8'> <p style=\"text-align: center;font-family: calibri;\">No Data Available</p></td>";
            strHtml += "</tr>";

        }
        else
        {
            for (int intRowBodyCount = 0; intRowBodyCount < ProuctList.Count; intRowBodyCount++)
            {
                intSerialNumber++;
                strHtml += "<tr id=\"row" + intSerialNumber + "\" >";
                //for serial number
                //strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: left;\">" + intSerialNumber + "</td>";
                strHtml += "<td style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >";
                strHtml += "<input id=\"cbx" + intSerialNumber + "\" name=\"cbx" + intSerialNumber + "\"  type=checkbox   style=\" width:97%;\" onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\"  onchange=\"changeCbx(" + intSerialNumber + ");\" />";
                strHtml += "</td>";



                int len = ProuctList[intRowBodyCount].Length;

                string Day = ProuctList[intRowBodyCount][0].ToString().Replace("<", string.Empty);
                Day = Day.Replace(">", string.Empty);
                strHtml += "<td id=\"tdDay" + intSerialNumber + "\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + Day + "</td>";


                string OTCatg = ProuctList[intRowBodyCount][1].ToString().Replace("<", string.Empty);
                OTCatg = OTCatg.Replace(">", string.Empty);
                strHtml += "<td id=\"tdOTCatg" + intSerialNumber + "\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + OTCatg + "</td>";



                string Empcode = ProuctList[intRowBodyCount][2].ToString().Replace("<", string.Empty);
                Empcode = Empcode.Replace(">", string.Empty);
                strHtml += "<td id=\"tdEmpCode" + intSerialNumber + "\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + Empcode + "</td>";

                string Employee = ProuctList[intRowBodyCount][3].ToString().Replace("<", string.Empty);
                Employee = Employee.Replace(">", string.Empty);
                strHtml += "<td id=\"tdEmployee" + intSerialNumber + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + Employee + "</td>";

                string Designation = ProuctList[intRowBodyCount][4].ToString().Replace("<", string.Empty);
                Designation = Designation.Replace(">", string.Empty);
                strHtml += "<td id=\"tdDesignation" + intSerialNumber + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + Designation + "</td>";

                string Job = ProuctList[intRowBodyCount][5].ToString().Replace("<", string.Empty);
                Job = Job.Replace(">", string.Empty);
                strHtml += "<td id=\"tdJob" + intSerialNumber + "\" name=\"tdJob" + intSerialNumber + "\"  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + Job + "</td>";

                string Attendance = ProuctList[intRowBodyCount][6].ToString().Replace("<", string.Empty);
                Attendance = Attendance.Replace(">", string.Empty);
                strHtml += "<td id=\"tdAtt" + intSerialNumber + "\" name=\"tdAtt" + intSerialNumber + "\"  style=\" width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + Attendance + "</td>";

                if (len >= 8)
                {
                    string OT = ProuctList[intRowBodyCount][7].ToString().Replace("<", string.Empty);
                    OT = OT.Replace(">", string.Empty);
                    strHtml += "<td id=\"tdOT" + intSerialNumber + "\" name=\"tdOT" + intSerialNumber + "\"   style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + OT + "</td>";

                }
                else
                {
                    strHtml += "<td id=\"tdOT" + intSerialNumber + "\" name=\"tdOT" + intSerialNumber + "\"  style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  ></td>";

                }
                if (len >= 9)
                {
                    string Remarks = ProuctList[intRowBodyCount][8].ToString().Replace("<", string.Empty);
                    Remarks = Remarks.Replace(">", string.Empty);
                    strHtml += "<td id=\"tdRemark" + intSerialNumber + "\" name=\"tdRemark" + intSerialNumber + "\"  style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + Remarks + "</td>";
                }
                else
                {
                    strHtml += "<td id=\"tdRemark" + intSerialNumber + "\" name=\"tdRemark" + intSerialNumber + "\"  style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\"  ></td>";

                }





                strHtml += "</tr>";
            }
        }
        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }

    public class CsvRow : List<string>
    {
        public string LineText { get; set; }
    }  /// <summary>
    /// Class to read data from a CSV file
    /// </summary>
    public class CsvFileReader : StreamReader
    {
        public CsvFileReader(Stream stream)
            : base(stream)
        {
        }

        public CsvFileReader(string filename)
            : base(filename)
        {
        }

        /// <summary>
        /// Reads a row of data from a CSV file
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool ReadRow(CsvRow row)
        {
            row.LineText = ReadLine();
            if (String.IsNullOrEmpty(row.LineText))
                return false;

            int pos = 0;
            int rows = 0;

            while (pos < row.LineText.Length)
            {
                string value;

                // Special handling for quoted field
                if (row.LineText[pos] == '"')
                {
                    // Skip initial quote
                    pos++;

                    // Parse quoted value
                    int start = pos;
                    while (pos < row.LineText.Length)
                    {
                        // Test for quote character
                        if (row.LineText[pos] == '"')
                        {
                            // Found one
                            pos++;

                            // If two quotes together, keep one
                            // Otherwise, indicates end of value
                            if (pos >= row.LineText.Length || row.LineText[pos] != '"')
                            {
                                pos--;
                                break;
                            }
                        }
                        pos++;
                    }
                    value = row.LineText.Substring(start, pos - start);
                    value = value.Replace("\"\"", "\"");
                }
                else
                {
                    // Parse unquoted value
                    int start = pos;
                    while (pos < row.LineText.Length && row.LineText[pos] != ',')
                        pos++;
                    value = row.LineText.Substring(start, pos - start);
                }

                // Add field to list
                if (rows < row.Count)
                    row[rows] = value;
                else
                    row.Add(value);
                rows++;

                // Eat up to and including next comma
                while (pos < row.LineText.Length && row.LineText[pos] != ',')
                    pos++;
                if (pos < row.LineText.Length)
                    pos++;
            }
            // Delete any unused items
            while (row.Count > rows)
                row.RemoveAt(rows);

            // Return true if any columns read
            return (row.Count > 0);
        }
    }
    //converting string array list to json
    private string ConvertArrayToJson(List<string[]> strArrayList)
    {
        string strjson = JsonConvert.SerializeObject(strArrayList);
        return strjson;
    }

    //remove tags from array
    private List<string[]> ListRemoveTags(List<string[]> strArrayList)
    {
        var TagRemoveArray = new List<string[]>();

        for (int intRowBodyCount = 0; intRowBodyCount < strArrayList.Count; intRowBodyCount++)
        {
            string[] strProductList = new string[3];
            string strProductCode = strArrayList[intRowBodyCount][0].ToString().Replace("<", string.Empty);
            strProductCode = strProductCode.Replace(">", string.Empty);
            strProductList[0] = strProductCode;

            if (strArrayList[intRowBodyCount].GetLength(0) > 1)
            {
                string strProductName = strArrayList[intRowBodyCount][1].ToString().Replace("<", string.Empty);
                strProductName = strProductName.Replace(">", string.Empty);
                strProductList[1] = strProductName;
            }
            else
            {

            }
            if (strArrayList[intRowBodyCount].GetLength(0) > 2)
            {
                string strCostPrice = strArrayList[intRowBodyCount][2].ToString().Replace("<", string.Empty);
                strCostPrice = strCostPrice.Replace(">", string.Empty);
                strProductList[2] = strCostPrice;
            }
            else
            {

            }

            TagRemoveArray.Add(strProductList);
        }
        return TagRemoveArray;
    }
    [WebMethod]
    public static string[] ServiceListToHtml(string strList, string strCount, string strMode, string strTotalCount, string CmnIdleHr)
    {
        string[] strOutput = new string[2];
        if (strList != "")
        {
            string jsonDataPW = strList;
            string R1PW = jsonDataPW.Replace("\"{", "\\{");
            string R2PW = R1PW.Replace("\\n", "\r\n");
            string R3PW = R2PW.Replace("\\", "");
            string R4PW = R3PW.Replace("}\"]", "}]");
            string R5PW = R4PW.Replace("}\",", "},");
            List<clsWorkHourDtl> objWBDataPWList = new List<clsWorkHourDtl>();
            objWBDataPWList = JsonConvert.DeserializeObject<List<clsWorkHourDtl>>(R5PW);



            string IdleHRcmn = CmnIdleHr;
            string strFinalOT = "";



            int intCount = Convert.ToInt32(strCount);
            int intFinalCount = 0;


            if (intCount < 100)
                intCount = 0;

            //strMode=1 for next and 0 for previous.
            if (strMode == "1")
            {
                intFinalCount = intCount + 100;
                if (intFinalCount > Convert.ToInt32(strTotalCount))
                    intFinalCount = Convert.ToInt32(strTotalCount);
            }
            else
            {
                if (intCount % 100 == 0)
                {
                    intFinalCount = intCount - 100;
                    intCount = intCount - 200;
                    if (intCount < 0)
                        intCount = 0;
                }
                else
                {
                    intFinalCount = (intCount / 100) * 100;
                    intCount = intFinalCount - 100;
                    if (intCount < 0)
                        intCount = 0;
                }
            }

            if (intFinalCount % 100 != 0)
            {
                intCount = intFinalCount % 100;
                intCount = intFinalCount - intCount;
            }


            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();



            // class="table table-bordered table-striped"
            StringBuilder sb = new StringBuilder();
            string strHtml = "<table id=\"ReportTable\" class=\"table table-bordered table-striped\" cellspacing=\"0\" cellpadding=\"2px\" >";
            //add header row
            strHtml += "<thead>";
            strHtml += "<tr >";



            //strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";
            strHtml += "<th  style=\"width:10%;text-align: left; word-wrap:break-word;padding:4px\">" + "Day" + "</th>";
            strHtml += "<th  style=\"width:10%;text-align: left; word-wrap:break-word;padding:4px\">" + "OT Category" + "</th>";
            strHtml += "<th  style=\"width:10%;text-align: left; word-wrap:break-word;padding:4px\">" + "Employee Code" + "</th>";
            strHtml += "<th  style=\"width:20%;text-align: left; word-wrap:break-word;padding:4px\">" + "Employee" + "</th>";
            strHtml += "<th  style=\"width:20%;text-align: left; word-wrap:break-word;padding:4px\">" + "Designation" + "</th>";
            //  strHtml += "<th   style=\"width:10%;text-align:left; word-wrap:break-word;padding:4px\">" + "Job Number" + "</th>";//cmd evm-0023
            strHtml += "<th   style=\"width:10%;text-align:left; word-wrap:break-word;padding:4px\">" + "Project Code" + "</th>";

            strHtml += "<th  style=\"width:6%;text-align: center; word-wrap:break-word;padding:4px\">" + "Attendance" + "</th>";
            strHtml += "<th  style=\"width:5%;text-align: left; word-wrap:break-word;padding:4px\">" + "O.T" + "</th>";

            strHtml += "<th  style=\"width:5%;text-align: left; word-wrap:break-word;padding:4px\">" + "Idle Hour" + "</th>";
            strHtml += "<th  style=\"width:5%;text-align: left; word-wrap:break-word;padding:4px\">" + "Final O.T" + "</th>";
            strHtml += "<th  style=\"width:5%;text-align: left; word-wrap:break-word;padding:4px\">" + "Rounded O.T" + "</th>";

            strHtml += "<th  style=\"width:25%;text-align: left; word-wrap:break-word;padding:4px\">" + "Remarks" + "</th>";

            strHtml += "<th  style=\"width:5%;text-align: left; word-wrap:break-word;\"></th>";


            strHtml += "</tr>";
            strHtml += "</thead>";
            //add rows
            int intSerialNumber = 0;
            strHtml += "<tbody>";



            foreach (clsWorkHourDtl objclsJSData in objWBDataPWList)
            {


                //for (int intRow = intCount; intRow < intFinalCount; intRow++)
                //{
                intSerialNumber++;

                if (intSerialNumber > intCount && intSerialNumber <= intFinalCount)
                {
                    strHtml += "<tr id=\"row" + intSerialNumber + "\" >";
                    //for serial number
                    //strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: left;\">" + intSerialNumber + "</td>";


                    //int len = 7;
                    int len = 9;


                    string Day = objclsJSData.DAY.Replace("<", string.Empty);
                    Day = Day.Replace(">", string.Empty);
                    strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\" >";
                    strHtml += "<input tabindex=\"-1\" class=\"input\" id=\"txtDay" + intSerialNumber + "\" name=\"txtDay" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + Day + "\"   />";
                    strHtml += "</td>";

                    string OTCatg = objclsJSData.OT_CATEGORY.Replace("<", string.Empty);
                    OTCatg = OTCatg.Replace(">", string.Empty);
                    strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\" >";
                    strHtml += "<input tabindex=\"-1\" class=\"input\" id=\"txtOTCatg" + intSerialNumber + "\" name=\"txtOTCatg" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + OTCatg + "\"   />";
                    strHtml += "</td>";

                    string Empcode = objclsJSData.EMPCODE.Replace("<", string.Empty);
                    Empcode = Empcode.Replace(">", string.Empty);
                    strHtml += "<td  class=\"tdT\"  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\" >";
                    strHtml += "<input tabindex=\"-1\" id=\"txtEmpCode" + intSerialNumber + "\" name=\"txtEmpCode" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + Empcode + "\"   />";
                    strHtml += "</td>";


                    string Employee = objclsJSData.EMPLOYEE.Replace("<", string.Empty);
                    Employee = Employee.Replace(">", string.Empty);
                    strHtml += "<td  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                    strHtml += "<input tabindex=\"-1\" id=\"txtEmployee" + intSerialNumber + "\" name=\"txtEmployee" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + Employee + "\"   />";
                    strHtml += "</td>";


                    string Designation = objclsJSData.DESG.Replace("<", string.Empty);
                    Designation = Designation.Replace(">", string.Empty);
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                    strHtml += "<input tabindex=\"-1\" id=\"txtDesignation" + intSerialNumber + "\" name=\"txtDesignation" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + Designation + "\"   />";
                    strHtml += "</td>";

                    string Job = objclsJSData.PROJECT_CODE.Replace("<", string.Empty);
                    //string Job = objclsJSData.JOBNUM.Replace("<", string.Empty);
                    Job = Job.Replace(">", string.Empty);
                    strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                    strHtml += "<input tabindex=\"-1\" id=\"txtJob" + intSerialNumber + "\" name=\"txtJob" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + Job + "\"   />";
                    strHtml += "</td>";



                    string Attendance = objclsJSData.ATTENDANCE.Replace("<", string.Empty);
                    Attendance = Attendance.Replace(">", string.Empty);
                    strHtml += "<td class=\"tdT\" style=\" width:6%;word-break: break-all; word-wrap:break-word;text-align: center;padding:0px;height:20px;\"  >";
                    strHtml += "<input tabindex=\"-1\" id=\"txtAtt" + intSerialNumber + "\" name=\"txtAtt" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;text-align:center;\" value=\"" + Attendance + "\"   />";
                    strHtml += "</td>";


                    if (len >= 8)
                    {
                        string OT = objclsJSData.OT.Replace("<", string.Empty);
                        OT = OT.Replace(">", string.Empty);
                        strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                        strHtml += "<input tabindex=\"-1\" id=\"txtOT" + intSerialNumber + "\"  name=\"txtOT" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + OT + "\" onblur=\"return BlurIdleHr(" + intSerialNumber + ");\" onkeydown=\"return isNumberDec(event)\" onchange=\"IncrmntConfrmCounter();\" onkeypress=\"return isNumberDec(event)\"  maxlength=5/>";
                        strHtml += "</td>";


                        if (Convert.ToDecimal(IdleHRcmn) >= Convert.ToDecimal(OT))
                        {
                            strFinalOT = "0";
                        }
                        else
                        {
                            strFinalOT = Convert.ToString(Convert.ToDecimal(OT) - Convert.ToDecimal(IdleHRcmn));
                        }


                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                        strHtml += "<input tabindex=\"-1\" id=\"txtOT" + intSerialNumber + "\" name=\"txtOT" + intSerialNumber + "\"  type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" onblur=\"return BlurIdleHr(" + intSerialNumber + ");\" onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"IncrmntConfrmCounter();\" maxlength=5 />";
                        strHtml += "</td>";
                    }



                    string IdleHourIndvdl = objclsJSData.IDLEHOUR.Replace("<", string.Empty);
                    IdleHourIndvdl = IdleHourIndvdl.Replace(">", string.Empty);
                    strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                    strHtml += "<input id=\"txtIdleHr" + intSerialNumber + "\" name=\"txtIdleHr" + intSerialNumber + "\" type=text   style=\" width:100%;\" value=\"" + IdleHourIndvdl + "\"    onblur=\"return BlurIdleHr(" + intSerialNumber + ");\" onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"IncrmntConfrmCounter();\" maxlength=5 />";
                    strHtml += "</td>";


                    string FinalOTInd = objclsJSData.FINALOT.Replace("<", string.Empty);
                    FinalOTInd = FinalOTInd.Replace(">", string.Empty);
                    strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                    strHtml += "<input tabindex=\"-1\" id=\"txtFinalOT" + intSerialNumber + "\" name=\"txtFinalOT" + intSerialNumber + "\" type=text value=\"" + FinalOTInd + "\"   style=\" width:100%;pointer-events:none;background-color: gainsboro;\"   onblur=\"return BlurIdleHr(" + intSerialNumber + ");\" onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"IncrmntConfrmCounter();\" maxlength=5 />";
                    strHtml += "</td>";

                    string RoundOTInd = objclsJSData.ROUNDEDOT.Replace("<", string.Empty);
                    RoundOTInd = RoundOTInd.Replace(">", string.Empty);
                    strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                    strHtml += "<input id=\"txtRndedOT" + intSerialNumber + "\" name=\"txtRndedOT" + intSerialNumber + "\" type=text   style=\" width:100%;\" value=\"" + RoundOTInd + "\"   onblur=\"return BlurRoundedOT(" + intSerialNumber + ");\" onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"IncrmntConfrmCounter();\" maxlength=5 />";
                    strHtml += "</td>";



                    if (len >= 9)
                    {
                        string Remarks = objclsJSData.REMARKS.Replace("<", string.Empty);
                        Remarks = Remarks.Replace(">", string.Empty);
                        strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                        strHtml += "<input id=\"txtRemark" + intSerialNumber + "\" onblur=\"return BlurRemark(" + intSerialNumber + ");\" name=\"txtRemark" + intSerialNumber + "\" type=text   style=\" width:100%;\" value=\"" + Remarks + "\" onkeydown=\"return isTag(event)\"  onkeypress=\"return isTag(event)\" onchange=\"IncrmntConfrmCounter();\" maxlength=100/>";
                        strHtml += "</td>";
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                        strHtml += "<input id=\"txtRemark" + intSerialNumber + "\" onblur=\"return BlurRemark(" + intSerialNumber + ");\" name=\"txtRemark" + intSerialNumber + "\"  type=text   style=\" width:100%;\" onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" onchange=\"IncrmntConfrmCounter();\" maxlength=100 />";
                        strHtml += "</td>";
                    }

                    strHtml += "<td class=\"tdT\" style=\"width:5%; word-break: break-all; word-wrap:break-word;text-align: center;padding:0px;height:20px;\">" + " <a  style=\"cursor:pointer;margin-top:-1.5%;opacity:1;margin-left:1%;z-index: 29;\" title=\"Cancel\" onclick='return DeleteRow(" + intSerialNumber + ");' >"
                                                  + "<img style=\"cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";


                    strHtml += "</tr>";
                }
            }
            strHtml += "</tbody>";

            strHtml += "</table>";



            sb.Append(strHtml);
            strOutput[0] = sb.ToString();
            strOutput[1] = intFinalCount.ToString();
        }
        return strOutput;
    }

    [WebMethod]
    public static string[] ServiceListToHtmlIncrct(string strList, string strCount, string strMode, string strTotalCount)
    {
        string[][] strArrayList = JsonConvert.DeserializeObject<string[][]>(strList);
        int intCount = Convert.ToInt32(strCount);
        int intFinalCount = 0;
        string[] strOutput = new string[2];

        if (intCount < 100)
            intCount = 0;

        //strMode=1 for next and 0 for previous.
        if (strMode == "1")
        {
            intFinalCount = intCount + 100;
            if (intFinalCount > Convert.ToInt32(strTotalCount))
                intFinalCount = Convert.ToInt32(strTotalCount);
        }
        else
        {
            if (intCount % 100 == 0)
            {
                intFinalCount = intCount - 100;
                intCount = intCount - 200;
                if (intCount < 0)
                    intCount = 0;
            }
            else
            {
                intFinalCount = (intCount / 100) * 100;
                intCount = intFinalCount - 100;
                if (intCount < 0)
                    intCount = 0;
            }
        }

        if (intFinalCount % 100 != 0)
        {
            intCount = intFinalCount % 100;
            intCount = intFinalCount - intCount;
        }


        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();



        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTableIncrct\" class=\"table table-bordered table-striped\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr >";



        //strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";
        strHtml += "<th  style=\"width:10%;text-align: left; word-wrap:break-word;padding:4px\">" + "Day" + "</th>";
        strHtml += "<th  style=\"width:10%;text-align: left; word-wrap:break-word;padding:4px\">" + "OT Category" + "</th>";
        strHtml += "<th  style=\"width:10%;text-align: left; word-wrap:break-word;padding:4px\">" + "Employee Code" + "</th>";
        strHtml += "<th  style=\"width:20%;text-align: left; word-wrap:break-word;padding:4px\">" + "Employee" + "</th>";
        strHtml += "<th  style=\"width:20%;text-align: left; word-wrap:break-word;padding:4px\">" + "Designation" + "</th>";
        //    strHtml += "<th   style=\"width:10%;text-align:left; word-wrap:break-word;padding:4px\">" + "Job Number" + "</th>";//cmd evm-0023
        strHtml += "<th   style=\"width:10%;text-align:left; word-wrap:break-word;padding:4px\">" + "Project Code" + "</th>";
        strHtml += "<th  style=\"width:6%;text-align: center; word-wrap:break-word;padding:4px\">" + "Attendance" + "</th>";
        strHtml += "<th  style=\"width:5%;text-align: left; word-wrap:break-word;padding:4px\">" + "O.T" + "</th>";
        strHtml += "<th  style=\"width:25%;text-align: left; word-wrap:break-word;padding:4px\">" + "Remarks" + "</th>";


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        int intSerialNumber = 0;
        strHtml += "<tbody>";

        for (int intRow = intCount; intRow < intFinalCount; intRow++)
        {
            intSerialNumber++;
            strHtml += "<tr id=\"rows" + intSerialNumber + "\" >";
            //for serial number
            //strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: left;\">" + intSerialNumber + "</td>";


            int len = strArrayList[intRow].Length;

            string Empcode = strArrayList[intRow][0].ToString().Replace("<", string.Empty);
            Empcode = Empcode.Replace(">", string.Empty);
            strHtml += "<td  class=\"tdT\"  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\" >";
            strHtml += "<input tabindex=\"-1\" id=\"txtEmpCodeI" + intSerialNumber + "\" name=\"txtEmpCodeI" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + Empcode + "\"   />";
            strHtml += "</td>";


            string Employee = strArrayList[intRow][1].ToString().Replace("<", string.Empty);
            Employee = Employee.Replace(">", string.Empty);
            strHtml += "<td  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
            strHtml += "<input tabindex=\"-1\" id=\"txtEmployeeI" + intSerialNumber + "\" name=\"txtEmployeeI" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + Employee + "\"   />";
            strHtml += "</td>";


            string Designation = strArrayList[intRow][2].ToString().Replace("<", string.Empty);
            Designation = Designation.Replace(">", string.Empty);
            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
            strHtml += "<input tabindex=\"-1\" id=\"txtDesignationI" + intSerialNumber + "\" name=\"txtDesignationI" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + Designation + "\"   />";
            strHtml += "</td>";

            string Job = strArrayList[intRow][3].ToString().Replace("<", string.Empty);
            Job = Job.Replace(">", string.Empty);
            strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
            strHtml += "<input tabindex=\"-1\" id=\"txtJobI" + intSerialNumber + "\" name=\"txtJobI" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + Job + "\"   />";
            strHtml += "</td>";



            string Attendance = strArrayList[intRow][4].ToString().Replace("<", string.Empty);
            Attendance = Attendance.Replace(">", string.Empty);
            strHtml += "<td class=\"tdT\" style=\" width:6%;word-break: break-all; word-wrap:break-word;text-align: center;padding:0px;height:20px;\"  >";
            strHtml += "<input tabindex=\"-1\" id=\"txtAttI" + intSerialNumber + "\" name=\"txtAttI" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;text-align:center;\" value=\"" + Attendance + "\"   />";
            strHtml += "</td>";


            if (len >= 8)
            {
                string OT = strArrayList[intRow][5].ToString().Replace("<", string.Empty);
                OT = OT.Replace(">", string.Empty);
                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                strHtml += "<input tabindex=\"-1\" id=\"txtOTI" + intSerialNumber + "\" name=\"txtOTI" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + OT + "\" onblur=\"return BlurIdleHr(" + intSerialNumber + ");\" onkeydown=\"return isNumberDec(event)\" onchange=\"IncrmntConfrmCounter();\" onkeypress=\"return isNumberDec(event)\"  maxlength=5/>";
                strHtml += "</td>";
            }
            else
            {
                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                strHtml += "<input tabindex=\"-1\" id=\"txtOTI" + intSerialNumber + "\" name=\"txtOTI" + intSerialNumber + "\"  type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" onblur=\"return BlurIdleHr(" + intSerialNumber + ");\" onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"IncrmntConfrmCounter();\" maxlength=5 />";
                strHtml += "</td>";
            }

            if (len >= 9)
            {
                string Remarks = strArrayList[intRow][6].ToString().Replace("<", string.Empty);
                Remarks = Remarks.Replace(">", string.Empty);
                strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                strHtml += "<input tabindex=\"-1\" id=\"txtRemarkI" + intSerialNumber + "\" name=\"txtRemarkI" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + Remarks + "\" onkeydown=\"return isTag(event)\"  onkeypress=\"return isTag(event)\" onchange=\"IncrmntConfrmCounter();\" maxlength=100/>";
                strHtml += "</td>";
            }
            else
            {
                strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                strHtml += "<input tabindex=\"-1\" id=\"txtRemarkI" + intSerialNumber + "\" name=\"txtRemarkI" + intSerialNumber + "\"  type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" onchange=\"IncrmntConfrmCounter();\" maxlength=100 />";
                strHtml += "</td>";
            }

            strHtml += "</tr>";
        }
        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        strOutput[0] = sb.ToString();
        strOutput[1] = intFinalCount.ToString();
        return strOutput;
    }
    [WebMethod]
    public static string CheckHoliday(string date, string orgID, string corptID)
    {
        string Sts = "false";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerEmployeeDailyWorkHour objBusinessEmpDailyWorkHour = new clsBusinessLayerEmployeeDailyWorkHour();
        clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour = new clsEntityEmployeeDailyWorkHour();
        objEntityEmpDailyWorkHour.CorpId = Convert.ToInt32(corptID);
        objEntityEmpDailyWorkHour.orgid = Convert.ToInt32(orgID);
        objEntityEmpDailyWorkHour.DateOfWork = objCommon.textToDateTime(date);
        DataTable dt = objBusinessEmpDailyWorkHour.checkHoliday(objEntityEmpDailyWorkHour);
        if (dt.Rows.Count > 0)
        {
            Sts = "true";
        }
        if (Sts == "false")
        {
            //For off duty checking         
            clsEntityLayerDutyRoster objEntityDutyRoster = new clsEntityLayerDutyRoster();
            clsBusinessLayerDutyRoster objBusinessDutyRoster = new clsBusinessLayerDutyRoster();
            objEntityDutyRoster.Corporate_id = Convert.ToInt32(corptID);
            objEntityDutyRoster.Organisation_id = Convert.ToInt32(orgID);
            //FOR READING DUTY OFF
            DataTable dtDutyOffWeekly = objBusinessDutyRoster.ReadWeeklyDutyOff(objEntityDutyRoster);
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

            DateTime now = new DateTime();
            now = objCommon.textToDateTime(date);

            DataTable dtDutyOffMonthly = objBusinessDutyRoster.ReadMonthlyDutyOff(objEntityDutyRoster);
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

                                                break;
                                        }
                                    }

                                }
                            }

                        }

                    }

                }
            }


            string strMonthOf1 = "false";
            foreach (DateTime MonthOff in MonthlyOffDates)
            {
                if (MonthOff == now)
                {
                    strMonthOf1 = "true";
                    break;
                }
            }
            string strWekOf1 = "false";
            string strDayWkString1 = now.ToString("dddd");
            if (strJbWklyOffDay.Contains(strDayWkString1))
            {
                strWekOf1 = "true";
            }

            if (strMonthOf1 == "true" || strWekOf1 == "true")
            {
                Sts = "true";
            }

        }


        return Sts;
    }


    public class clsWorkHourDtl
    {
        public string EMPCODE { get; set; }
        public string EMPLOYEE { get; set; }
        public string DESG { get; set; }
        public string PROJECT_CODE { get; set; }
        public string ATTENDANCE { get; set; }
        public string OT { get; set; }
        public string REMARKS { get; set; }
        public string IDLEHOUR { get; set; }
        public string FINALOT { get; set; }
        public string ROUNDEDOT { get; set; }
        public string DAY { get; set; }
        public string OT_CATEGORY { get; set; }
    }

    [WebMethod]
    public static string CorrectListLoad(string strList, string Idle)
    {


        string jsonDataPW = strList;
        string R1PW = jsonDataPW.Replace("\"{", "\\{");
        string R2PW = R1PW.Replace("\\n", "\r\n");
        string R3PW = R2PW.Replace("\\", "");
        string R4PW = R3PW.Replace("}\"]", "}]");
        string R5PW = R4PW.Replace("}\",", "},");
        List<clsWorkHourDtl> objWBDataPWList = new List<clsWorkHourDtl>();
        objWBDataPWList = JsonConvert.DeserializeObject<List<clsWorkHourDtl>>(R5PW);



        string IdleHRcmn = Idle;
        string strFinalOT = "";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"table table-bordered table-striped\" width=\"100%\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr >";
        strHtml += "<th  style=\"width:10%;text-align: left; word-wrap:break-word;padding:4px\">" + "Day" + "</th>";
        strHtml += "<th  style=\"width:10%;text-align: left; word-wrap:break-word;padding:4px\">" + "OT Category" + "</th>";
        //strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";
        strHtml += "<th class=\"\" style=\"width:10%;text-align: left; word-wrap:break-word;padding:4px\">" + "Employee Code" + "</th>";
        strHtml += "<th class=\"\" style=\"width:20%;text-align: left; word-wrap:break-word;padding:4px\">" + "Employee" + "</th>";
        strHtml += "<th class=\"\" style=\"width:20%;text-align: left; word-wrap:break-word;padding:4px\">" + "Designation" + "</th>";
        // strHtml += "<th class=\"\"  style=\"width:10%;text-align:left; word-wrap:break-word;padding:4px\">" + "Job Number" + "</th>"; //cmd evm-0023
        strHtml += "<th class=\"\"  style=\"width:10%;text-align:left; word-wrap:break-word;padding:4px\">" + "Project Code" + "</th>";
        strHtml += "<th class=\"\" style=\"width:6%;text-align: center; word-wrap:break-word;padding:4px\">" + "Attendance" + "</th>";
        strHtml += "<th class=\"\" style=\"width:5%;text-align: left; word-wrap:break-word;padding:4px\">" + "O.T" + "</th>";
        strHtml += "<th class=\"\" style=\"width:5%;text-align: left; word-wrap:break-word;padding:4px\">" + "Idle Hour" + "</th>";
        strHtml += "<th class=\"\" style=\"width:5%;text-align: left; word-wrap:break-word;padding:4px\">" + "Final O.T" + "</th>";
        strHtml += "<th class=\"\" style=\"width:5%;text-align: left; word-wrap:break-word;padding:4px\">" + "Rounded O.T" + "</th>";

        strHtml += "<th class=\"\" style=\"width:25%;text-align: left; word-wrap:break-word;padding:4px\">" + "Remarks" + "</th>";

        strHtml += "<th class=\"\" style=\"width:5%;text-align: left; word-wrap:break-word;\"></th>";



        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        int intSerialNumber = 0;
        strHtml += "<tbody>";
        if (objWBDataPWList.Count == 0)
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"\" colspan='8'> <p style=\"text-align: center;font-family: calibri;\">No Data Available</p></td>";
            strHtml += "</tr>";

        }
        else
        {
            foreach (clsWorkHourDtl objclsJSData in objWBDataPWList)
            {


                intSerialNumber++;

                if (intSerialNumber <= 100)
                {

                    strHtml += "<tr id=\"row" + intSerialNumber + "\" >";
                    //for serial number
                    //strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: left;\">" + intSerialNumber + "</td>";


                    //int len = 7;
                    int len = 9;

                    string Day = objclsJSData.DAY.Replace("<", string.Empty);
                    Day = Day.Replace(">", string.Empty);
                    strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\" >";
                    strHtml += "<input tabindex=\"-1\" class=\"input\" id=\"txtDay" + intSerialNumber + "\" name=\"txtDay" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + Day + "\"   />";
                    strHtml += "</td>";

                    string OTCatg = objclsJSData.OT_CATEGORY.Replace("<", string.Empty);
                    OTCatg = OTCatg.Replace(">", string.Empty);
                    strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\" >";
                    strHtml += "<input tabindex=\"-1\" class=\"input\" id=\"txtOTCatg" + intSerialNumber + "\" name=\"txtOTCatg" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + OTCatg + "\"   />";
                    strHtml += "</td>";


                    string Empcode = objclsJSData.EMPCODE.Replace("<", string.Empty);
                    Empcode = Empcode.Replace(">", string.Empty);
                    strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\" >";
                    strHtml += "<input tabindex=\"-1\" class=\"input\" id=\"txtEmpCode" + intSerialNumber + "\" name=\"txtEmpCode" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + Empcode + "\"   />";
                    strHtml += "</td>";


                    string Employee = objclsJSData.EMPLOYEE.Replace("<", string.Empty);
                    Employee = Employee.Replace(">", string.Empty);
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                    strHtml += "<input tabindex=\"-1\" id=\"txtEmployee" + intSerialNumber + "\" name=\"txtEmployee" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + Employee + "\"   />";
                    strHtml += "</td>";



                    string Designation = objclsJSData.DESG.Replace("<", string.Empty);
                    Designation = Designation.Replace(">", string.Empty);
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                    strHtml += "<input tabindex=\"-1\" id=\"txtDesignation" + intSerialNumber + "\" name=\"txtDesignation" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + Designation + "\"  />";
                    strHtml += "</td>";

                    if (objclsJSData.PROJECT_CODE == null)
                    {
                        objclsJSData.PROJECT_CODE = "";
                    }

                    string Job = objclsJSData.PROJECT_CODE.Replace("<", string.Empty);
                    //string Job = objclsJSData.JOBNUM.Replace("<", string.Empty);
                    Job = Job.Replace(">", string.Empty);
                    strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                    strHtml += "<input tabindex=\"-1\" id=\"txtJob" + intSerialNumber + "\" name=\"txtJob" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + Job + "\"   />";
                    strHtml += "</td>";



                    string Attendance = objclsJSData.ATTENDANCE.Replace("<", string.Empty);
                    Attendance = Attendance.Replace(">", string.Empty);
                    strHtml += "<td  class=\"tdT\" style=\" width:6%;word-break: break-all; word-wrap:break-word;text-align: center;padding:0px;height:20px;\"  >";
                    strHtml += "<input tabindex=\"-1\" id=\"txtAtt" + intSerialNumber + "\" name=\"txtAtt" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;text-align:center;\" value=\"" + Attendance + "\"   />";
                    strHtml += "</td>";


                    if (len >= 8)
                    {
                        string OT = objclsJSData.OT.Replace("<", string.Empty);
                        OT = OT.Replace(">", string.Empty);
                        strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                        strHtml += "<input tabindex=\"-1\" id=\"txtOT" + intSerialNumber + "\" name=\"txtOT" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\" value=\"" + OT + "\"  onblur=\"return BlurIdleHr(" + intSerialNumber + ");\" onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"IncrmntConfrmCounter();\" maxlength=5 />";
                        strHtml += "</td>";
                         //new start
                        if (OT == "" || OT == null)
                        {
                            OT = "0";
                            strFinalOT = "0";
                        }
                        else
                        {
                        //new end
                        if (Convert.ToDecimal(IdleHRcmn) >= Convert.ToDecimal(OT))
                        {
                            strFinalOT = "0";
                        }
                        else
                        {
                            strFinalOT = Convert.ToString(Convert.ToDecimal(OT) - Convert.ToDecimal(IdleHRcmn));
                        }
                            //new start
                        }
                        //new end
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                        strHtml += "<input tabindex=\"-1\" id=\"txtOT" + intSerialNumber + "\"  name=\"txtOT" + intSerialNumber + "\" type=text   style=\" width:100%;pointer-events:none;background-color: gainsboro;\"  onblur=\"return BlurIdleHr(" + intSerialNumber + ");\" onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"IncrmntConfrmCounter();\" maxlength=5 />";
                        strHtml += "</td>";
                    }


                    strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                    strHtml += "<input id=\"txtIdleHr" + intSerialNumber + "\" name=\"txtIdleHr" + intSerialNumber + "\" type=text   style=\" width:100%;\" value=\"" + IdleHRcmn + "\"    onblur=\"return BlurIdleHr(" + intSerialNumber + ");\" onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"IncrmntConfrmCounter();\" maxlength=5 />";
                    strHtml += "</td>";



                    strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                    strHtml += "<input tabindex=\"-1\" id=\"txtFinalOT" + intSerialNumber + "\" name=\"txtFinalOT" + intSerialNumber + "\" type=text value=\"" + strFinalOT + "\"   style=\" width:100%;pointer-events:none;background-color: gainsboro;\"   onblur=\"return BlurIdleHr(" + intSerialNumber + ");\" onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"IncrmntConfrmCounter();\" maxlength=5 />";
                    strHtml += "</td>";


                    strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                    strHtml += "<input id=\"txtRndedOT" + intSerialNumber + "\" name=\"txtRndedOT" + intSerialNumber + "\" type=text   style=\" width:100%;\" value=\"" + strFinalOT + "\"   onblur=\"return BlurRoundedOT(" + intSerialNumber + ");\" onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" onchange=\"IncrmntConfrmCounter();\" maxlength=5 />";
                    strHtml += "</td>";





                    if (len >= 9)
                    {
                        string Remarks = objclsJSData.REMARKS.Replace("<", string.Empty);
                        Remarks = Remarks.Replace(">", string.Empty);
                        strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                        strHtml += "<input id=\"txtRemark" + intSerialNumber + "\" onblur=\"return BlurRemark(" + intSerialNumber + ");\" name=\"txtRemark" + intSerialNumber + "\"  type=text   style=\" width:100%;\" value=\"" + Remarks + "\" onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" onchange=\"IncrmntConfrmCounter();\"  maxlength=100/>";
                        strHtml += "</td>";

                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;padding:0px;height:20px;\"  >";
                        strHtml += "<input id=\"txtRemark" + intSerialNumber + "\" onblur=\"return BlurRemark(" + intSerialNumber + ");\" name=\"txtRemark" + intSerialNumber + "\"  type=text   style=\" width:100%;\" onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" maxlength=100 onchange=\"IncrmntConfrmCounter();\" />";
                        strHtml += "</td>";
                    }




                    strHtml += "<td class=\"tdT\" style=\"width:5%; word-break: break-all; word-wrap:break-word;text-align: center;padding:0px;height:20px;\">" + " <a  style=\"cursor:pointer;margin-top:-1.5%;opacity:1;margin-left:1%;z-index: 29;\" title=\"Cancel\" onclick='return DeleteRow(" + intSerialNumber + ");' >"
                                             + "<img style=\"cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";


                    strHtml += "</tr>";


                }
            }
        }
        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();

    }





}