using System;
using System.Collections.Generic;
using System.Web.UI;
using BL_Compzit;
using EL_Compzit;
using CL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_AWMS;
using System.Data;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Globalization;
public partial class AWMS_AWMS_Master_gen_Duty_Roster_gen_Duty_Roster : System.Web.UI.Page
{

    //enumeration for previous and next button
    private enum Button_type
    {
        Previous = 1,
        Next = 2,
        Redirect=3
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
            hiddenCurrentDate.Value = strCurrentDate;
            int intUserId=0;

            if (Session["CORPOFFICEID"] != null)
            {
                hiddenCorporateId.Value = Session["CORPOFFICEID"].ToString();

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
               hiddenOrganisationId.Value = Session["ORGID"].ToString();

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                HiddenFieldLoginUserId.Value = Session["USERID"].ToString();
                intUserId =Convert.ToInt32(Session["USERID"].ToString());
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

           int intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Leave_Allocation_Master);

            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            btnMarkLeave.Visible = false;
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    
                   if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        btnMarkLeave.Visible = true;
                        
                    }


                }
            }
            TimeSlotLoad();
            EmployeeCbxLoad();

            hiddenPrevious.Value = "0";
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;

            hiddenFirstDate.Value = DateTime.Now.ToString("dd/MM/yyyy");

            if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
            {
                string EmpIdSearch = Request.QueryString["Srch"].ToString();
                ddlEmployee.Items.FindByValue(EmpIdSearch).Selected = true;
                string EmpDataFill = FillEmployeeTable(Convert.ToInt32(EmpIdSearch));
            }
            else if (Request.QueryString["Navi"] != null && Request.QueryString["Navi"] != "")
            {
                string strFullNav = Request.QueryString["Navi"].ToString();
                string[] splitNav=strFullNav.Split(',');
                hiddenPrevious.Value = splitNav[0];
                hiddenNext.Value = splitNav[1];
                setButtonValues(3);
                
            }
            else
            {
                string EmpDataFill = FillEmployeeTable();
            }



            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "InsShdl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessSchedule", "SuccessSchedule();", true);
                }
                if (strInsUpd == "InsSubmsn")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                }
                if (strInsUpd == "ReopenSubmsn")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReopenSubmit", "SuccessReopenSubmit();", true);
                }
                if (strInsUpd == "LeaveAlloted")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessLeaveSubmit", "SuccessLeaveSubmit();", true);
                }
            }
        }
        bindStatus();
        
    }

    //It build the Html table by using the datatable provided
    public string FillEmployeeTable(int EmpIdSearch=0)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
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

        //for date and month section
       string strTodayDate= DateTime.Now.ToString("dd/MM/yyyy");

       DateTime DateTodayDate = new DateTime();
       DateTodayDate = objCommon.textToDateTime(strTodayDate);

        DateTime now = new DateTime();
        now = objCommon.textToDateTime(hiddenFirstDate.Value);


              
      

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

                                             if (now.Month < now1.Month || now.Year<now1.Year)
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
                                 firstdate = DateTime.DaysInMonth(now.Year, now.Month)-7; 
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
                                                    FirstMonday= FirstMonday.AddDays(1);
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
                                                    FirstTuesday= FirstTuesday.AddDays(1);
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
                                                    FirstWednesday= FirstWednesday.AddDays(1);
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
                                                    FirstThursday= FirstThursday.AddDays(1);
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
                                                    FirstFriday= FirstFriday.AddDays(1);
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
                                                    FirstSaturday= FirstSaturday.AddDays(1);
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
                                                    FirstSunday= FirstSunday.AddDays(1);
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
                                                    FirstMonday= FirstMonday.AddDays(1);
                                                 }
                                             }

                                             if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() != "8" && (now.Month < now1.Month || now.Year<now1.Year))                                           
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
                                                    FirstTuesday= FirstTuesday.AddDays(1);
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
                                                    FirstWednesday= FirstWednesday.AddDays(1);
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
                                                    FirstThursday= FirstThursday.AddDays(1);
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
                                                   FirstFriday=  FirstFriday.AddDays(1);
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
                                                    FirstSunday= FirstSunday.AddDays(1);
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

         string StartDate = now.ToString("dd/MMM/yyyy");
         string EndDate = now.AddDays(6).ToString("dd/MMM/yyyy");
        hiddenLastDate.Value = now.AddDays(7).ToString();

        string strMonth = now.ToString("MMMM");
        int strYear = now.Year;

        int intDay = now.Day;
        lblFromDuty.InnerText = StartDate;
        lblToDuty.InnerText = EndDate;
        DataTable dtEmployee = new DataTable();
        if (EmpIdSearch == 0)
        {
            objEntityDutyRoster.EmployeeId = 0;
            dtEmployee = objBusinessDutyRoster.ReadEmployee(objEntityDutyRoster);

            if (dtEmployee.Rows.Count > 25 &&Convert.ToInt32(hiddenPrevious.Value)==0)
            {
                btnNext.Enabled = true;
                hiddenPrevious.Value = "0";
                hiddenNext.Value = "25";
            }
        }
        else
        {
            btnNext.Enabled = false;
            btnPrevious.Enabled = false;
            hiddenPrevious.Value = "0";
            objEntityDutyRoster.EmployeeId = EmpIdSearch;
            dtEmployee = objBusinessDutyRoster.ReadEmployee(objEntityDutyRoster);
        }

        objEntityDutyRoster.FromDate = now;
        objEntityDutyRoster.ToDate = now.AddDays(7);
        DataTable dtHolidays = objBusinessDutyRoster.ReadHolidays(objEntityDutyRoster);

        StringBuilder sb = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();
        string strHtml = "<table id=\"TabEmployeeContainer\" class=\"EmpTabCls\" cellspacing=\"0\" cellpadding=\"2px\"  >";

        strHtml += "<tbody style=\"word-break: break-all;\">";

        string strTopHtml = "<table id=\"TabTopSection\" cellspacing=\"0\" cellpadding=\"2px\"  >";
        strTopHtml += "<tbody style=\"word-break: break-all;background-color: #e4e4e4;\">";
        strTopHtml += "<tr >";
        strTopHtml += "<td style=\"width:14%;border: 1px solid #969393;\" >";

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

        string Holi1 = "false";
        string HoliName = "";
        foreach (DataRow RowHoli in dtHolidays.Rows)
        {
            if (objCommon.textToDateTime(RowHoli["HLDAYMSTR_DATE"].ToString()) == now)
            {
                HoliName = RowHoli["HLDAYMSTR_TITLE"].ToString();
                Holi1 = "true";
            }
        }
        if (strMonthOf1 == "true" || strWekOf1 == "true")
        {
            strTopHtml += "<div style=\"margin-left: 15%;color: red;font-family: calibri;visibility: visible;\">OFF DUTY</div>";
        }
        else
        {
            strTopHtml += "<div style=\"margin-left: 15%;color: red;font-family: calibri;visibility: hidden;\">OFF DUTY</div>";
        }

        if (Holi1 == "false")
        {
            strTopHtml += "<div><a class=\"tooltip\" title=\"PRINT DUTY SLIP\" onclick=\"return PrintDutySlip('" + now.ToString("dd/MM/yyyy") + "');\" ><img src=\"/Images/Icons/dutyPrint.png\" style=\"cursor:pointer;vertical-align: middle;max-width: 80%;margin-left: 10%;\"></a></div>";

            objEntityDutyRoster.FromDate = objCommon.textToDateTime(now.ToString("dd/MM/yyyy"));

            DataTable dt = objBusinessDutyRoster.ReadDutyslipCreateOrNOt(objEntityDutyRoster);
            if(dt.Rows.Count>0)

                strTopHtml += "<div style=\"margin-top:2px;margin-left:10%;\"><a class=\"tooltip\" title=\"CREATE DUTY SLIP\" onclick=\"return createDutySlip('" + now.ToString("dd/MM/yyyy") + "');\" ><img src=\"/Images/Icons/DutySlip.png\" style=\"cursor:pointer;vertical-align: middle;max-width: 80%;margin-left: 4%;\"></a></div>";
            else
                strTopHtml += "<div style=\"margin-top:2px;margin-left:10%;\"><a class=\"tooltip\" title=\"CREATE DUTY SLIP\" ><img src=\"/Images/Icons/DutySlip.png\" style=\"cursor:pointer;vertical-align: middle;opacity:0.5;max-width: 80%;margin-left: 4%;\"></a></div>";
        }
        else if (Holi1 == "true")
        {
            strTopHtml += "<div style=\"margin-left: 11%;color: red;font-family: calibri;\">HOLIDAY</div>";
            strTopHtml += "<div style=\"margin-top:2px;margin-left:-3%;font-size: 11px;height: 33px;overflow: auto;text-align: center;font-family: calibri;\">" + HoliName + "</div>";
        }
        

        strTopHtml += "<div style=\"margin-top:2px;\">";
        strTopHtml += "<div style=\"width:28%;float: left;\"><img src=\"/Images/Icons/upload.png\" style=\"cursor:pointer;vertical-align: middle;margin-left: 5%;max-width: 90%;\"></div>";
        strTopHtml += "<div style=\"width: 37%;font-size: 19px;font-weight: bold;color: #0f0fb4;float: left;text-align: center;\">" + intDay + "</div>";
        strTopHtml += "<div style=\"width:28%;float: left;\"><img src=\"/Images/Icons/download.png\" style=\"cursor:pointer;vertical-align: middle;margin-left: 5%;max-width: 90%;\"></div>";
        strTopHtml += "</div>";
        strTopHtml += "</td>";
        now = now.AddDays(1);
        intDay = now.Day;
        strTopHtml += "<td style=\"width:14.3%;border: 1px solid #969393;\" >";

        string strMonthOf2 = "false";
        foreach (DateTime MonthOff in MonthlyOffDates)
        {
            if (MonthOff == now)
            {
                strMonthOf2 = "true";
                break;
            }
        }
        string strWekOf2 = "false";
        string strDayWkString2 = now.ToString("dddd");
        if (strJbWklyOffDay.Contains(strDayWkString2))
        {
            strWekOf2 = "true";
        }
        string Holi2 = "false";
        foreach (DataRow RowHoli in dtHolidays.Rows)
        {
            if (objCommon.textToDateTime(RowHoli["HLDAYMSTR_DATE"].ToString()) == now)
            {
                HoliName = RowHoli["HLDAYMSTR_TITLE"].ToString();
                Holi2 = "true";
            }
        }
        if (strMonthOf2 == "true" || strWekOf2 == "true")
        {
            strTopHtml += "<div style=\"margin-left: 15%;color: red;font-family: calibri;visibility: visible;\">OFF DUTY</div>";
        }
        else
        {
            strTopHtml += "<div style=\"margin-left: 15%;color: red;font-family: calibri;visibility: hidden;\">OFF DUTY</div>";
        }
        if (Holi2 == "false" )
        {
            strTopHtml += "<div><a class=\"tooltip\" title=\"PRINT DUTY SLIP\" onclick=\"return PrintDutySlip('" + now.ToString("dd/MM/yyyy") + "');\" ><img src=\"/Images/Icons/dutyPrint.png\" style=\"cursor:pointer;vertical-align: middle;max-width: 80%;margin-left: 10%;\"></a></div>";
            objEntityDutyRoster.FromDate = objCommon.textToDateTime(now.ToString("dd/MM/yyyy"));
            DataTable dt = objBusinessDutyRoster.ReadDutyslipCreateOrNOt(objEntityDutyRoster);
            if (dt.Rows.Count > 0)
                strTopHtml += "<div style=\"margin-top:2px;margin-left:10%;\"><a class=\"tooltip\" title=\"CREATE DUTY SLIP\" onclick=\"return createDutySlip('" + now.ToString("dd/MM/yyyy") + "');\" ><img src=\"/Images/Icons/DutySlip.png\" style=\"cursor:pointer;vertical-align: middle;max-width: 80%;margin-left: 4%;\"></a></div>";
            else
                strTopHtml += "<div style=\"margin-top:2px;margin-left:10%;\"><a class=\"tooltip\" title=\"CREATE DUTY SLIP\" ><img src=\"/Images/Icons/DutySlip.png\" style=\"cursor:pointer;vertical-align: middle;opacity:0.5;max-width: 80%;margin-left: 4%;\"></a></div>";
        }
        else if (Holi2 == "true")
        {
            strTopHtml += "<div style=\"margin-left: 11%;color: red;font-family: calibri;\">HOLIDAY</div>";

            strTopHtml += "<div style=\"margin-top:2px;margin-left:-3%;font-size: 11px;height: 33px;overflow: auto;text-align: center;font-family: calibri\">" + HoliName + "</div>";
        }


        strTopHtml += "<div style=\"margin-top:2px;\">";
        strTopHtml += "<div style=\"width:28%;float: left;\"><img src=\"/Images/Icons/upload.png\" style=\"cursor:pointer;vertical-align: middle;margin-left: 5%;max-width: 90%;\"></div>";
        strTopHtml += "<div style=\"width: 37%;font-size: 19px;font-weight: bold;color: #0f0fb4;float: left;text-align: center;\">" + intDay + "</div>";
        strTopHtml += "<div style=\"width:28%;float: left;\"><img src=\"/Images/Icons/download.png\" style=\"cursor:pointer;vertical-align: middle;margin-left: 5%;max-width: 90%;\"></div>";
        strTopHtml += "</div>";
        strTopHtml += "</td>";
        now = now.AddDays(1);
        intDay = now.Day;
        strTopHtml += "<td style=\"width:14.4%;border: 1px solid #969393;\" >";
        string strMonthOf3 = "false";
        foreach (DateTime MonthOff in MonthlyOffDates)
        {
            if (MonthOff == now)
            {
                strMonthOf3 = "true";
                break;
            }
        }
        string strWekOf3 = "false";
        string strDayWkString3 = now.ToString("dddd");
        if (strJbWklyOffDay.Contains(strDayWkString3))
        {
            strWekOf3 = "true";
        }

        string Holi3 = "false";
        foreach (DataRow RowHoli in dtHolidays.Rows)
        {
            if (objCommon.textToDateTime(RowHoli["HLDAYMSTR_DATE"].ToString()) == now)
            {
                HoliName = RowHoli["HLDAYMSTR_TITLE"].ToString();
                Holi3 = "true";
            }
        }
        if (strMonthOf3 == "true" || strWekOf3 == "true")
        {
            strTopHtml += "<div style=\"margin-left: 15%;color: red;font-family: calibri;visibility: visible;\">OFF DUTY</div>";
        }
        else
        {
            strTopHtml += "<div style=\"margin-left: 15%;color: red;font-family: calibri;visibility: hidden;\">OFF DUTY</div>";
        }
        if (Holi3 == "false")
        {
            strTopHtml += "<div><a class=\"tooltip\" title=\"PRINT DUTY SLIP\" onclick=\"return PrintDutySlip('" + now.ToString("dd/MM/yyyy") + "');\" ><img src=\"/Images/Icons/dutyPrint.png\" style=\"cursor:pointer;vertical-align: middle;max-width: 80%;margin-left: 10%;\"></a></div>";
            objEntityDutyRoster.FromDate = objCommon.textToDateTime(now.ToString("dd/MM/yyyy"));
            DataTable dt = objBusinessDutyRoster.ReadDutyslipCreateOrNOt(objEntityDutyRoster);
            if (dt.Rows.Count > 0)
                strTopHtml += "<div style=\"margin-top:2px;margin-left:10%;\"><a class=\"tooltip\" title=\"CREATE DUTY SLIP\" onclick=\"return createDutySlip('" + now.ToString("dd/MM/yyyy") + "');\" ><img src=\"/Images/Icons/DutySlip.png\" style=\"cursor:pointer;vertical-align: middle;max-width: 80%;margin-left: 4%;\"></a></div>";
            else
                strTopHtml += "<div style=\"margin-top:2px;margin-left:10%;\"><a class=\"tooltip\" title=\"CREATE DUTY SLIP\"  ><img src=\"/Images/Icons/DutySlip.png\" style=\"cursor:pointer;vertical-align: middle;opacity:0.5;max-width: 80%;margin-left: 4%;\"></a></div>";
       
        }
        else if(Holi3 == "true")
        {
            strTopHtml += "<div style=\"margin-left: 11%;color: red;font-family: calibri;\">HOLIDAY</div>";
            strTopHtml += "<div style=\"margin-top:2px;margin-left:-3%;font-size: 11px;height: 33px;overflow: auto;text-align: center;font-family: calibri\">" + HoliName + "</div>";
        }
       

        strTopHtml += "<div style=\"margin-top:2px;\">";
        strTopHtml += "<div style=\"width:28%;float: left;\"><img src=\"/Images/Icons/upload.png\" style=\"cursor:pointer;vertical-align: middle;margin-left: 5%;max-width: 90%;\"></div>";
        strTopHtml += "<div style=\"width: 37%;font-size: 19px;font-weight: bold;color: #0f0fb4;float: left;text-align: center;\">" + intDay + "</div>";
        strTopHtml += "<div style=\"width:28%;float: left;\"><img src=\"/Images/Icons/download.png\" style=\"cursor:pointer;vertical-align: middle;margin-left: 5%;max-width: 90%;\"></div>";
        strTopHtml += "</div>";
        strTopHtml += "</td>";
        now = now.AddDays(1);
        intDay = now.Day;
        strTopHtml += "<td style=\"width:14.4%;border: 1px solid #969393;\" >";
        string strMonthOf4 = "false";
        foreach (DateTime MonthOff in MonthlyOffDates)
        {
            if (MonthOff == now)
            {
                strMonthOf4 = "true";
                break;
            }
        }
        string strWekOf4 = "false";
        string strDayWkString4 = now.ToString("dddd");
        if (strJbWklyOffDay.Contains(strDayWkString4))
        {
            strWekOf4 = "true";
        }
        string Holi4 = "false";
        foreach (DataRow RowHoli in dtHolidays.Rows)
        {
            if (objCommon.textToDateTime(RowHoli["HLDAYMSTR_DATE"].ToString()) == now)
            {
                HoliName = RowHoli["HLDAYMSTR_TITLE"].ToString();
                Holi4 = "true";
            }
        }
        if (strMonthOf4 == "true" || strWekOf4 == "true")
        {
            strTopHtml += "<div style=\"margin-left: 15%;color: red;font-family: calibri;visibility: visible;\">OFF DUTY</div>";
        }
        else
        {
            strTopHtml += "<div style=\"margin-left: 15%;color: red;font-family: calibri;visibility: hidden;\">OFF DUTY</div>";
        }
        if (Holi4 == "false")
        {
            strTopHtml += "<div><a class=\"tooltip\" title=\"PRINT DUTY SLIP\" onclick=\"return PrintDutySlip('" + now.ToString("dd/MM/yyyy") + "');\" ><img src=\"/Images/Icons/dutyPrint.png\" style=\"cursor:pointer;vertical-align: middle;max-width: 80%;margin-left: 10%;\"></a></div>";
            objEntityDutyRoster.FromDate = objCommon.textToDateTime(now.ToString("dd/MM/yyyy"));
            DataTable dt = objBusinessDutyRoster.ReadDutyslipCreateOrNOt(objEntityDutyRoster);
            if (dt.Rows.Count > 0)
                strTopHtml += "<div style=\"margin-top:2px;margin-left:10%;\"><a class=\"tooltip\" title=\"CREATE DUTY SLIP\" onclick=\"return createDutySlip('" + now.ToString("dd/MM/yyyy") + "');\" ><img src=\"/Images/Icons/DutySlip.png\" style=\"cursor:pointer;vertical-align: middle;max-width: 80%;margin-left: 4%;\"></a></div>";
            else
                strTopHtml += "<div style=\"margin-top:2px;margin-left:10%;\"><a class=\"tooltip\" title=\"CREATE DUTY SLIP\" ><img src=\"/Images/Icons/DutySlip.png\" style=\"cursor:pointer;vertical-align: middle;opacity:0.5;max-width: 80%;margin-left: 4%;\"></a></div>";
       
        }
        else if (Holi4 == "true")
        {
            strTopHtml += "<div style=\"margin-left: 11%;color: red;font-family: calibri;\">HOLIDAY</div>";
            strTopHtml += "<div style=\"margin-top:2px;margin-left:-3%;font-size: 11px;height: 33px;overflow: auto;text-align: center;font-family: calibri\">" + HoliName + "</div>";
        }
       
        strTopHtml += "<div style=\"margin-top:2px;\">";
        strTopHtml += "<div style=\"width:28%;float: left;\"><img src=\"/Images/Icons/upload.png\" style=\"cursor:pointer;vertical-align: middle;margin-left: 5%;max-width: 90%;\"></div>";
        strTopHtml += "<div style=\"width: 37%;font-size: 19px;font-weight: bold;color: #0f0fb4;float: left;text-align: center;\">" + intDay + "</div>";
        strTopHtml += "<div style=\"width:28%;float: left;\"><img src=\"/Images/Icons/download.png\" style=\"cursor:pointer;vertical-align: middle;margin-left: 5%;max-width: 90%;\"></div>";
        strTopHtml += "</div>";
        strTopHtml += "</td>";
        now = now.AddDays(1);
        intDay = now.Day;
        strTopHtml += "<td style=\"width:14.3%;border: 1px solid #969393;\" >";
        string strMonthOf5 = "false";
        foreach (DateTime MonthOff in MonthlyOffDates)
        {
            if (MonthOff == now)
            {
                strMonthOf5 = "true";
                break;
            }
        }
        string strWekOf5 = "false";
        string strDayWkString5 = now.ToString("dddd");
        if (strJbWklyOffDay.Contains(strDayWkString5))
        {
            strWekOf5 = "true";
        }
        string Holi5 = "false";
        foreach (DataRow RowHoli in dtHolidays.Rows)
        {
            if (objCommon.textToDateTime(RowHoli["HLDAYMSTR_DATE"].ToString()) == now)
            {
                HoliName = RowHoli["HLDAYMSTR_TITLE"].ToString();
                Holi5 = "true";
            }
        }
        if (strMonthOf5 == "true" || strWekOf5 == "true")
        {
            strTopHtml += "<div style=\"margin-left: 15%;color: red;font-family: calibri;visibility: visible;\">OFF DUTY</div>";
        }
        else
        {
            strTopHtml += "<div style=\"margin-left: 15%;color: red;font-family: calibri;visibility: hidden;\">OFF DUTY</div>";
        }
        if (Holi5 == "false")
        {
            strTopHtml += "<div><a class=\"tooltip\" title=\"PRINT DUTY SLIP\" onclick=\"return PrintDutySlip('" + now.ToString("dd/MM/yyyy") + "');\" ><img src=\"/Images/Icons/dutyPrint.png\" style=\"cursor:pointer;vertical-align: middle;max-width: 80%;margin-left: 10%;\"></a></div>";
            objEntityDutyRoster.FromDate = objCommon.textToDateTime(now.ToString("dd/MM/yyyy"));
            DataTable dt = objBusinessDutyRoster.ReadDutyslipCreateOrNOt(objEntityDutyRoster);
            if (dt.Rows.Count > 0)
                strTopHtml += "<div style=\"margin-top:2px;margin-left:10%;\"><a class=\"tooltip\" title=\"CREATE DUTY SLIP\" onclick=\"return createDutySlip('" + now.ToString("dd/MM/yyyy") + "');\" ><img src=\"/Images/Icons/DutySlip.png\" style=\"cursor:pointer;vertical-align: middle;max-width: 80%;margin-left: 4%;\"></a></div>";
            else
                strTopHtml += "<div style=\"margin-top:2px;margin-left:10%;\"><a class=\"tooltip\" title=\"CREATE DUTY SLIP\" ><img src=\"/Images/Icons/DutySlip.png\" style=\"cursor:pointer;vertical-align: middle;opacity:0.5;max-width: 80%;margin-left: 4%;\"></a></div>";
       
        }
        else if (Holi5 == "true")
        {
            strTopHtml += "<div style=\"margin-left: 11%;color: red;font-family: calibri;\">HOLIDAY</div>";
            strTopHtml += "<div style=\"margin-top:2px;margin-left:-3%;font-size: 11px;height: 33px;overflow: auto;text-align: center;font-family: calibri\">" + HoliName + "</div>";
        }
       
        strTopHtml += "<div style=\"margin-top:2px;\">";
        strTopHtml += "<div style=\"width:28%;float: left;\"><img src=\"/Images/Icons/upload.png\" style=\"cursor:pointer;vertical-align: middle;margin-left: 5%;max-width: 90%;\"></div>";
        strTopHtml += "<div style=\"width: 37%;font-size: 19px;font-weight: bold;color: #0f0fb4;float: left;text-align: center;\">" + intDay + "</div>";
        strTopHtml += "<div style=\"width:28%;float: left;\"><img src=\"/Images/Icons/download.png\" style=\"cursor:pointer;vertical-align: middle;margin-left: 5%;max-width: 90%;\"></div>";
        strTopHtml += "</div>";
        strTopHtml += "</td>";
        now = now.AddDays(1);
        intDay = now.Day;
        strTopHtml += "<td style=\"width:14.4%;border: 1px solid #969393;\" >";
        string strMonthOf6 = "false";
        foreach (DateTime MonthOff in MonthlyOffDates)
        {
            if (MonthOff == now)
            {
                strMonthOf6 = "true";
                break;
            }
        }
        string strWekOf6 = "false";
        string strDayWkString6 = now.ToString("dddd");
        if (strJbWklyOffDay.Contains(strDayWkString6))
        {
            strWekOf6 = "true";
        }
        string Holi6 = "false";
        foreach (DataRow RowHoli in dtHolidays.Rows)
        {
            if (objCommon.textToDateTime(RowHoli["HLDAYMSTR_DATE"].ToString()) == now)
            {
                HoliName = RowHoli["HLDAYMSTR_TITLE"].ToString();
                Holi6 = "true";
            }
        }
        if (strMonthOf6 == "true" || strWekOf6 == "true")
        {
            strTopHtml += "<div style=\"margin-left: 15%;color: red;font-family: calibri;visibility: visible;\">OFF DUTY</div>";
        }
        else
        {
            strTopHtml += "<div style=\"margin-left: 15%;color: red;font-family: calibri;visibility: hidden;\">OFF DUTY</div>";
        }
        if (Holi6 == "false" )
        {
            strTopHtml += "<div><a class=\"tooltip\" title=\"PRINT DUTY SLIP\" onclick=\"return PrintDutySlip('" + now.ToString("dd/MM/yyyy") + "');\" ><img src=\"/Images/Icons/dutyPrint.png\" style=\"cursor:pointer;vertical-align: middle;max-width: 80%;margin-left: 10%;\"></a></div>";
            objEntityDutyRoster.FromDate = objCommon.textToDateTime(now.ToString("dd/MM/yyyy"));
            DataTable dt = objBusinessDutyRoster.ReadDutyslipCreateOrNOt(objEntityDutyRoster);
            if (dt.Rows.Count > 0)
                strTopHtml += "<div style=\"margin-top:2px;margin-left:10%;\"><a class=\"tooltip\" title=\"CREATE DUTY SLIP\" onclick=\"return createDutySlip('" + now.ToString("dd/MM/yyyy") + "');\" ><img src=\"/Images/Icons/DutySlip.png\" style=\"cursor:pointer;vertical-align: middle;max-width: 80%;margin-left: 4%;\"></a></div>";
            else
                strTopHtml += "<div style=\"margin-top:2px;margin-left:10%;\"><a class=\"tooltip\" title=\"CREATE DUTY SLIP\" ><img src=\"/Images/Icons/DutySlip.png\" style=\"cursor:pointer;vertical-align: middle;opacity:0.5;max-width: 80%;margin-left: 4%;\"></a></div>";
       
        }
        else if (Holi6 == "true")
        {
            strTopHtml += "<div style=\"margin-left: 11%;color: red;font-family: calibri;\">HOLIDAY</div>";
            strTopHtml += "<div style=\"margin-top:2px;margin-left:-3%;font-size: 11px;height: 33px;overflow: auto;text-align: center;font-family: calibri\">" + HoliName + "</div>";
        }
       
        strTopHtml += "<div style=\"margin-top:2px;\">";
        strTopHtml += "<div style=\"width:28%;float: left;\"><img src=\"/Images/Icons/upload.png\" style=\"cursor:pointer;vertical-align: middle;margin-left: 5%;max-width: 90%;\"></div>";
        strTopHtml += "<div style=\"width: 37%;font-size: 19px;font-weight: bold;color: #0f0fb4;float: left;text-align: center;\">" + intDay + "</div>";
        strTopHtml += "<div style=\"width:28%;float: left;\"><img src=\"/Images/Icons/download.png\" style=\"cursor:pointer;vertical-align: middle;margin-left: 5%;max-width: 90%;\"></div>";
        strTopHtml += "</div>";
        strTopHtml += "</td>";
        now = now.AddDays(1);
        intDay = now.Day;
        strTopHtml += "<td style=\"width:14.6%;border: 1px solid #969393;\" >";
        string strMonthOf7 = "false";
        foreach (DateTime MonthOff in MonthlyOffDates)
        {
            if (MonthOff == now)
            {
                strMonthOf7 = "true";
                break;
            }
        }
        string strWekOf7 = "false";
        string strDayWkString7 = now.ToString("dddd");
        if (strJbWklyOffDay.Contains(strDayWkString7))
        {
            strWekOf7 = "true";
        }
        string Holi7 = "false";
        foreach (DataRow RowHoli in dtHolidays.Rows)
        {
            if (objCommon.textToDateTime(RowHoli["HLDAYMSTR_DATE"].ToString()) == now)
            {
                HoliName = RowHoli["HLDAYMSTR_TITLE"].ToString();
                Holi7 = "true";
            }
        }
        if (strMonthOf7 == "true" || strWekOf7 == "true")
        {
            strTopHtml += "<div style=\"margin-left: 15%;color: red;font-family: calibri;visibility: visible;\">OFF DUTY</div>";
        }
        else
        {
            strTopHtml += "<div style=\"margin-left: 15%;color: red;font-family: calibri;visibility: hidden;\">OFF DUTY</div>";
        }
        if (Holi7 == "false")
        {
            strTopHtml += "<div><a class=\"tooltip\" title=\"PRINT DUTY SLIP\" onclick=\"return PrintDutySlip('" + now.ToString("dd/MM/yyyy") + "');\" ><img src=\"/Images/Icons/dutyPrint.png\" style=\"cursor:pointer;vertical-align: middle;max-width: 80%;margin-left: 10%;\"></a></div>";
            objEntityDutyRoster.FromDate = objCommon.textToDateTime(now.ToString("dd/MM/yyyy"));
            DataTable dt = objBusinessDutyRoster.ReadDutyslipCreateOrNOt(objEntityDutyRoster);
            if (dt.Rows.Count > 0)
                strTopHtml += "<div style=\"margin-top:2px;margin-left:10%;\"><a class=\"tooltip\" title=\"CREATE DUTY SLIP\" onclick=\"return createDutySlip('" + now.ToString("dd/MM/yyyy") + "');\" ><img src=\"/Images/Icons/DutySlip.png\" style=\"cursor:pointer;vertical-align: middle;max-width: 80%;margin-left: 4%;\"></a></div>";
            else
                strTopHtml += "<div style=\"margin-top:2px;margin-left:10%;\"><a class=\"tooltip\" title=\"CREATE DUTY SLIP\" ><img src=\"/Images/Icons/DutySlip.png\" style=\"cursor:pointer;vertical-align: middle;opacity:0.5;max-width: 80%;margin-left: 4%;\"></a></div>";
       
        }
        else  if (Holi7 == "true")
        {
            strTopHtml += "<div style=\"margin-left: 11%;color: red;font-family: calibri;\">HOLIDAY</div>";
            strTopHtml += "<div style=\"margin-top:2px;margin-left:-3%;font-size: 11px;height: 33px;overflow: auto;text-align: center;font-family: calibri\">" + HoliName + "</div>";
        }
       
        strTopHtml += "<div style=\"margin-top:2px;\">";
        strTopHtml += "<div style=\"width:28%;float: left;\"><img src=\"/Images/Icons/upload.png\" style=\"cursor:pointer;vertical-align: middle;margin-left: 5%;max-width: 90%;\"></div>";
        strTopHtml += "<div style=\"width: 37%;font-size: 19px;font-weight: bold;color: #0f0fb4;float: left;text-align: center;\">" + intDay + "</div>";
        strTopHtml += "<div style=\"width:28%;float: left;\"><img src=\"/Images/Icons/download.png\" style=\"cursor:pointer;vertical-align: middle;margin-left: 5%;max-width: 90%;\"></div>";
        strTopHtml += "</div>";
        strTopHtml += "</td>";
        strTopHtml += "</tr >";

        strTopHtml += "</tbody>";

        strTopHtml += "</table>";
        sb2.Append(strTopHtml);

        divTopMainContainer.InnerHtml = sb2.ToString();


        int first = Convert.ToInt32(hiddenPrevious.Value);
        int last = 0;
        for (int intRowBodyCount = first; intRowBodyCount < dtEmployee.Rows.Count; intRowBodyCount++)
            {
                last++;
                if (last == 25)
                {
                    break;
                }
              


            DateTime now2 = new DateTime();
            now2 = objCommon.textToDateTime(hiddenFirstDate.Value);

            strHtml += "<tr  >";

            string strId = dtEmployee.Rows[intRowBodyCount]["USR_ID"].ToString();
            string strEmpName =dtEmployee.Rows[intRowBodyCount]["Employee"].ToString();
            objEntityDutyRoster.EmployeeId = Convert.ToInt32(strId);
            objEntityDutyRoster.FromDate = now2;
            objEntityDutyRoster.ToDate = now2.AddDays(7);
            DataTable dtEmployeJbshdl = objBusinessDutyRoster.ReadJobShdlByEmp(objEntityDutyRoster);
            DataTable dtEmployeeJbBYDayWise = objBusinessDutyRoster.ReadJobShdlByDayWise(objEntityDutyRoster);
            //Start:-EMP-0009
            DataTable dtEmployeLeaveDtl = objBusinessDutyRoster.ReadLeaveDtlByEmp(objEntityDutyRoster);
            DataTable dtEmployeeSingle_Leave = objBusinessDutyRoster.ReadSingleLeaveDtlByEmp(objEntityDutyRoster);
            //End:-EMP-0009

            string strJbAsgndDay = "";
            if (dtEmployeeJbBYDayWise.Rows.Count > 0)
            {
                foreach (DataRow RowsDay in dtEmployeeJbBYDayWise.Rows)
                {
                    string DayValue = RowsDay["WEEK_DAYS_ID"].ToString();

                    switch (DayValue)
                    {
                        case "1":
                            strJbAsgndDay += "Monday";
                            break;
                        case "2":
                            strJbAsgndDay += "Tuesday";
                            break;
                        case "3":
                            strJbAsgndDay += "Wednesday";
                            break;
                        case "4":
                            strJbAsgndDay += "Thursday";
                            break;
                        case "5":
                            strJbAsgndDay += "Friday";
                            break;
                        case "6":
                            strJbAsgndDay += "Saturday";
                            break;
                        case "0":
                            strJbAsgndDay += "Sunday";
                            break;
                    }
                }
            }


            //Start:-EMP-0009
            objEntityDutyRoster.FromDate = now2;
            string DutySlipSbmtd1 = objBusinessDutyRoster.CheckDutySlpSubmsnSts(objEntityDutyRoster);
            string leave1 = "false";
            string halfday1 = "false";
            int section1 = 1;
            foreach (DataRow Rows in dtEmployeLeaveDtl.Rows)
            {
                DateTime Start = new DateTime();
                DateTime End = new DateTime();
                if (Rows[2].ToString() == "1")
                {
                    Start=objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString());
                }
                else
                {
                    Start = objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()).AddDays(1);
                    if (objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()) == now2)
                    {
                        halfday1 = "true";
                        section1 = Convert.ToInt32(Rows[2].ToString());
                    }

                }

                if (Rows[4].ToString() == "1")
                {
                    End = objCommon.textToDateTime(Rows["LEAVE_TO_DATE"].ToString());
                }
                else
                {
                    End = objCommon.textToDateTime(Rows["LEAVE_TO_DATE"].ToString()).AddDays(-1);
                    if (objCommon.textToDateTime(Rows["LEAVE_TO_DATE"].ToString()) == now2)
                    {
                        halfday1 = "true";
                        section1 = Convert.ToInt32(Rows[4].ToString());
                    }
                }


                if (Start <= now2 && End >= now2)
                {
                    leave1 = "true";
                    break;
                }
            }

            foreach (DataRow Rows in dtEmployeeSingle_Leave.Rows)
            {
                if (Rows[2].ToString() == "1")
                {
                    if (objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()) == now2)
                    {
                        leave1 = "true";
                        break;
                    }
                }
                else
                {
                    if (objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()) == now2)
                    {
                        halfday1 = "true";
                        section1 = Convert.ToInt32(Rows[2].ToString());

                    }

                }
            }
            //End:-EMP-0009


            string Asigned1 = "false";
            string Print1 = "";

            foreach (DataRow Rows in dtEmployeJbshdl.Rows)
            {
                if (objCommon.textToDateTime(Rows["JOBSHDL_FROM_DATE"].ToString()) <= now2 && objCommon.textToDateTime(Rows["JOBSHDL_TO_DATE"].ToString()) >= now2)
                {
                    Asigned1 = "true";
                    break;
                }
            }

            string strDayString1 = now2.ToString("dddd");
            if (dtEmployeeJbBYDayWise.Rows.Count > 0)
            {
                foreach (DataRow RowsDay in dtEmployeeJbBYDayWise.Rows)
                {
                    if (objCommon.textToDateTime(RowsDay["JOBSHDL_FROM_DATE"].ToString()) <= now2 && objCommon.textToDateTime(RowsDay["JOBSHDL_TO_DATE"].ToString()) >= now2)
                    {
                        if (strJbAsgndDay.Contains(strDayString1))
                        {
                            Asigned1 = "true";
                            break;
                        }
                    }
                }
            }
            //check if duty sheduled
            DataTable dtDutySheduledForDay = objBusinessDutyRoster.ReadDutyShdlByEmp(objEntityDutyRoster);
           
            if (dtDutySheduledForDay.Rows.Count > 0)
            {
                Asigned1 = "true";
                Print1=dtDutySheduledForDay.Rows[0][1].ToString();
            }



            strHtml += "<td style=\"width:30.2%;border: 1px solid #bdbcbc;\" >" + dtEmployee.Rows[intRowBodyCount]["Employee"].ToString() + "</td>";
            strHtml += "<td style=\"width:9.8%;border: 1px solid #bdbcbc;\" >";





            if ( Holi1 == "false" && leave1 == "false")
            {
                if (DutySlipSbmtd1 == "0")
                {
                    if (now2 >= DateTodayDate)
                    {
                        if (Asigned1 == "true")
                        {
                            strHtml += "<div style=\"width: 49%;float: left;\"><a class=\"tooltip\" title=\"duty shedule\"  onclick=\"return ShowJobShedule('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + halfday1 + "','" + section1 + "');\" ><img src=\"/Images/Icons/green round button.png\" style=\"vertical-align: middle;cursor:pointer;\"></a></div>";

                        }
                        else
                        {
                            strHtml += "<div style=\"width: 49%;float: left;\"><a class=\"tooltip\" title=\"duty shedule\"  onclick=\"return ShowJobShedule('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + halfday1 + "','" + section1 + "');\" ><img src=\"/Images/Icons/red round button.png\" style=\"vertical-align: middle;cursor:pointer;\"></div>";

                        }
                    }
                    else
                    {
                        strHtml += "<div style=\"width: 49%;float: left;\"><img src=\"/Images/Icons/red round button.png\" style=\"vertical-align: middle;cursor:pointer;opacity:0.4\"></a></div>";
                    }
                }
                else
                {
                    strHtml += "<div style=\"width: 49%;float: left;\"><a   onclick=\"return DutySlipSubmited();\" ><img src=\"/Images/Icons/green round button.png\" style=\"vertical-align: middle;cursor:pointer;\"></div>";
                }
                if (now2 <= DateTodayDate)
                {
                    if (DutySlipSbmtd1 == "0")
                    {
                        strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><a class=\"tooltip\" title=\"duty submit\"  onclick=\"return ShowJobSheduleSubmit('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + Print1 + "');\" ><img src=\"/Images/Icons/white round button.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;\"></a></div>";
                    }
                    else
                    {
                        strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><a class=\"tooltip\" title=\"duty submit\"  onclick=\"return ShowJobSheduleSubmit('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + Print1 + "');\" ><img src=\"/Images/Icons/orange round button.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;\"></a></div>";

                    }
                }
                else
                {
                    strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><a class=\"tooltip\" title=\"duty submit\"  ><img src=\"/Images/Icons/white round button.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;opacity:0.4\"></a></div>";
                }
            }
            else
            {
                strHtml += "<div style=\"width: 49%;float: left;\"><img src=\"/Images/Icons/red round button.png\" style=\"vertical-align: middle;cursor:pointer;opacity:0.4\"></a></div>";

                strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><img src=\"/Images/Icons/white round button.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;opacity:0.4\"></div>";

            }

            strHtml += " </td>";

            now2 = now2.AddDays(1);

            //Start:-EMP-0009
            objEntityDutyRoster.FromDate = now2;
            string DutySlipSbmtd2 = objBusinessDutyRoster.CheckDutySlpSubmsnSts(objEntityDutyRoster);
            string leave2 = "false";
            string halfday2 = "false";
            int section2 = 1;
            foreach (DataRow Rows in dtEmployeLeaveDtl.Rows)
            {
                DateTime Start = new DateTime();
                DateTime End = new DateTime();
                if (Rows[2].ToString() == "1")
                {
                    Start = objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString());
                }
                else
                {
                    Start = objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()).AddDays(1);
                    if (objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()) == now2)
                    {
                        halfday2 = "true";
                        section2 = Convert.ToInt32(Rows[2].ToString());
                    }

                }

                if (Rows[4].ToString() == "1")
                {
                    End = objCommon.textToDateTime(Rows["LEAVE_TO_DATE"].ToString());
                }
                else
                {
                    End = objCommon.textToDateTime(Rows["LEAVE_TO_DATE"].ToString()).AddDays(-1);
                    if (objCommon.textToDateTime(Rows["LEAVE_TO_DATE"].ToString()) == now2)
                    {
                        halfday2 = "true";
                        section2 = Convert.ToInt32(Rows[4].ToString());
                    }
                }


                if (Start <= now2 && End >= now2)
                {
                    leave2 = "true";
                    break;
                }
            }
            foreach (DataRow Rows in dtEmployeeSingle_Leave.Rows)
            {
                if (Rows[2].ToString() == "1")
                {
                    if (objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()) == now2)
                    {
                        leave2 = "true";
                        break;
                    }
                }
                else
                {
                    if (objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()) == now2)
                    {
                        halfday2 = "true";
                        section2 = Convert.ToInt32(Rows[2].ToString());

                    }

                }
            }
            //End:-EMP-0009
            string Asigned2 = "false";
            string Print2 = "";
            foreach (DataRow Rows in dtEmployeJbshdl.Rows)
            {
                if (objCommon.textToDateTime(Rows["JOBSHDL_FROM_DATE"].ToString()) <= now2 && objCommon.textToDateTime(Rows["JOBSHDL_TO_DATE"].ToString()) >= now2)
                {
                    Asigned2 = "true";
                    break;
                }
            }

            //check if duty sheduled
            DataTable dtDutySheduledForDay2 = objBusinessDutyRoster.ReadDutyShdlByEmp(objEntityDutyRoster);

            if (dtDutySheduledForDay2.Rows.Count > 0)
            {
                Asigned2 = "true";
                Print2 = dtDutySheduledForDay2.Rows[0][1].ToString();
            }

            string strDayString2 = now2.ToString("dddd");

            if (dtEmployeeJbBYDayWise.Rows.Count > 0)
            {
                foreach (DataRow RowsDay in dtEmployeeJbBYDayWise.Rows)
                {
                    if (objCommon.textToDateTime(RowsDay["JOBSHDL_FROM_DATE"].ToString()) <= now2 && objCommon.textToDateTime(RowsDay["JOBSHDL_TO_DATE"].ToString()) >= now2)
                    {
                        if (strJbAsgndDay.Contains(strDayString2))
                        {
                            Asigned2 = "true";
                            break;
                        }
                    }
                }
            }


            strHtml += "<td style=\"width:10%;border: 1px solid #bdbcbc;\" >";
            if (Holi2 == "false" && leave2 == "false")
            {
                if (DutySlipSbmtd2 == "0")
                {
                    if (now2 >= DateTodayDate)
                    {
                        if (Asigned2 == "true")
                        {

                            strHtml += "<div style=\"width: 49%;float: left;\"><a class=\"tooltip\" title=\"duty shedule\"  onclick=\"return ShowJobShedule('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + halfday2 + "','" + section2 + "');\" ><img src=\"/Images/Icons/green round button.png\" style=\"vertical-align: middle;cursor:pointer;\"></div>";

                        }
                        else
                        {

                            strHtml += "<div style=\"width: 49%;float: left;\"><a class=\"tooltip\" title=\"duty shedule\"  onclick=\"return ShowJobShedule('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + halfday2 + "','" + section2 + "');\" ><img src=\"/Images/Icons/red round button.png\" style=\"vertical-align: middle;cursor:pointer;\"></div>";

                        }
                    }
                    else
                    {
                        strHtml += "<div style=\"width: 49%;float: left;\"><img src=\"/Images/Icons/red round button.png\" style=\"vertical-align: middle;cursor:pointer;opacity:0.4\"></a></div>";

                    }
                }
                else
                {
                    strHtml += "<div style=\"width: 49%;float: left;\"><a   onclick=\"return DutySlipSubmited();\" ><img src=\"/Images/Icons/green round button.png\" style=\"vertical-align: middle;cursor:pointer;\"></div>";
                }
                if (now2 <= DateTodayDate)
                {
                    if (DutySlipSbmtd2 == "0")
                    {
                        strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><a class=\"tooltip\" title=\"duty submit\"  onclick=\"return ShowJobSheduleSubmit('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + Print2 + "');\" ><img src=\"/Images/Icons/white round button.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;\"></a></div>";
                    }
                    else
                    {
                        strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><a  class=\"tooltip\" title=\"duty submit\" onclick=\"return ShowJobSheduleSubmit('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + Print2 + "');\" ><img src=\"/Images/Icons/orange round button.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;\"></a></div>";

                    }
                }
                else
                {
                    strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><a class=\"tooltip\" title=\"duty submit\"  ><img src=\"/Images/Icons/white round button.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;opacity:0.4\"></a></div>";
                }
            }
            else
            {
                strHtml += "<div style=\"width: 49%;float: left;\"><img src=\"/Images/Icons/red round button.png\" style=\"vertical-align: middle;cursor:pointer;opacity:0.4\"></a></div>";

                strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><img src=\"/Images/Icons/white round button.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;opacity:0.4\"></div>";

            }
            strHtml += " </td>";

            now2 = now2.AddDays(1);
            //Start:-EMP-0009
            objEntityDutyRoster.FromDate = now2;
            string DutySlipSbmtd3 = objBusinessDutyRoster.CheckDutySlpSubmsnSts(objEntityDutyRoster);
            string leave3 = "false";
            string halfday3 = "false";
            int section3 = 1;
            foreach (DataRow Rows in dtEmployeLeaveDtl.Rows)
            {
                DateTime Start = new DateTime();
                DateTime End = new DateTime();
                if (Rows[2].ToString() == "1")
                {
                    Start = objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString());
                }
                else
                {
                    Start = objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()).AddDays(1);
                    if (objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()) == now2)
                    {
                        halfday3 = "true";
                        section3 = Convert.ToInt32(Rows[2].ToString());
                    }

                }

                if (Rows[4].ToString() == "1")
                {
                    End = objCommon.textToDateTime(Rows["LEAVE_TO_DATE"].ToString());
                }
                else
                {
                    End = objCommon.textToDateTime(Rows["LEAVE_TO_DATE"].ToString()).AddDays(-1);
                    if (objCommon.textToDateTime(Rows["LEAVE_TO_DATE"].ToString()) == now2)
                    {
                        halfday3 = "true";
                        section3 = Convert.ToInt32(Rows[4].ToString());
                    }
                }


                if (Start <= now2 && End >= now2)
                {
                    leave3 = "true";
                    break;
                }
            }
            foreach (DataRow Rows in dtEmployeeSingle_Leave.Rows)
            {
                if (Rows[2].ToString() == "1")
                {
                    if (objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()) == now2)
                    {
                        leave3 = "true";
                        break;
                    }
                }
                else
                {
                    if (objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()) == now2)
                    {
                        halfday3 = "true";
                        section3 = Convert.ToInt32(Rows[2].ToString());

                    }

                }
            }
            //End:-EMP-0009
            string Asigned3 = "false";
            string Print3 = "";
            foreach (DataRow Rows in dtEmployeJbshdl.Rows)
            {
                if (objCommon.textToDateTime(Rows["JOBSHDL_FROM_DATE"].ToString()) <= now2 && objCommon.textToDateTime(Rows["JOBSHDL_TO_DATE"].ToString()) >= now2)
                {
                    Asigned3 = "true";
                    break;
                }
            }

            string strDayString3 = now2.ToString("dddd");

            if (dtEmployeeJbBYDayWise.Rows.Count > 0)
            {
                foreach (DataRow RowsDay in dtEmployeeJbBYDayWise.Rows)
                {
                    if (objCommon.textToDateTime(RowsDay["JOBSHDL_FROM_DATE"].ToString()) <= now2 && objCommon.textToDateTime(RowsDay["JOBSHDL_TO_DATE"].ToString()) >= now2)
                    {
                        if (strJbAsgndDay.Contains(strDayString3))
                        {
                            Asigned3 = "true";
                            break;
                        }
                    }
                }
            }

            //check if duty sheduled
            DataTable dtDutySheduledForDay3 = objBusinessDutyRoster.ReadDutyShdlByEmp(objEntityDutyRoster);

            if (dtDutySheduledForDay3.Rows.Count > 0)
            {
                Asigned3 = "true";
                Print3 = dtDutySheduledForDay3.Rows[0][1].ToString();
            }


            strHtml += "<td style=\"width:10%;border: 1px solid #bdbcbc;\" >";

            if (Holi3 == "false" && leave3 == "false")
            {
                if (DutySlipSbmtd3 == "0")
                {
                    if (now2 >= DateTodayDate)
                    {
                        if (Asigned3 == "true")
                        {

                            strHtml += "<div style=\"width: 49%;float: left;\"><a class=\"tooltip\" title=\"duty shedule\"  onclick=\"return ShowJobShedule('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + halfday3 + "','" + section3 + "');\" ><img src=\"/Images/Icons/green round button.png\" style=\"vertical-align: middle;cursor:pointer;\"></div>";

                        }
                        else
                        {

                            strHtml += "<div style=\"width: 49%;float: left;\"><a class=\"tooltip\" title=\"duty shedule\"  onclick=\"return ShowJobShedule('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + halfday3 + "','" + section3 + "');\" ><img src=\"/Images/Icons/red round button.png\" style=\"vertical-align: middle;cursor:pointer;\"></div>";

                        }
                    }
                    else
                    {
                        strHtml += "<div style=\"width: 49%;float: left;\"><img src=\"/Images/Icons/red round button.png\" style=\"vertical-align: middle;cursor:pointer;opacity:0.4\"></a></div>";

                    }
                }
                else
                {
                    strHtml += "<div style=\"width: 49%;float: left;\"><a   onclick=\"return DutySlipSubmited();\" ><img src=\"/Images/Icons/green round button.png\" style=\"vertical-align: middle;cursor:pointer;\"></div>";
                }
                if (now2 <= DateTodayDate)
                {
                    if (DutySlipSbmtd3 == "0")
                    {
                        strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><a  class=\"tooltip\" title=\"duty submit\" onclick=\"return ShowJobSheduleSubmit('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + Print3 + "');\" ><img src=\"/Images/Icons/white round button.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;\"></a></div>";
                    }
                    else
                    {
                        strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><a class=\"tooltip\" title=\"duty submit\"  onclick=\"return ShowJobSheduleSubmit('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + Print3 + "');\" ><img src=\"/Images/Icons/orange round button.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;\"></a></div>";

                    }
                }
                else
                {
                    strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><a class=\"tooltip\" title=\"duty submit\"  ><img src=\"/Images/Icons/white round button.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;opacity:0.4\"></a></div>";
                }
            }
            else
            {
                strHtml += "<div style=\"width: 49%;float: left;\"><img src=\"/Images/Icons/red round button.png\" style=\"vertical-align: middle;cursor:pointer;opacity:0.4\"></a></div>";

                strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><img src=\"/Images/Icons/white round button.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;opacity:0.4\"></div>";

            }
            strHtml += " </td>";

            now2 = now2.AddDays(1);
            //Start:-EMP-0009
            objEntityDutyRoster.FromDate = now2;
            string DutySlipSbmtd4 = objBusinessDutyRoster.CheckDutySlpSubmsnSts(objEntityDutyRoster);
            string leave4 = "false";
            string halfday4 = "false";
            int section4 = 1;
            foreach (DataRow Rows in dtEmployeLeaveDtl.Rows)
            {
                DateTime Start = new DateTime();
                DateTime End = new DateTime();
                if (Rows[2].ToString() == "1")
                {
                    Start = objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString());
                }
                else
                {
                    Start = objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()).AddDays(1);
                    if (objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()) == now2)
                    {
                        halfday4 = "true";
                        section4 = Convert.ToInt32(Rows[2].ToString());
                    }

                }

                if (Rows[4].ToString() == "1")
                {
                    End = objCommon.textToDateTime(Rows["LEAVE_TO_DATE"].ToString());
                }
                else
                {
                    End = objCommon.textToDateTime(Rows["LEAVE_TO_DATE"].ToString()).AddDays(-1);
                    if (objCommon.textToDateTime(Rows["LEAVE_TO_DATE"].ToString()) == now2)
                    {
                        halfday4 = "true";
                        section4 = Convert.ToInt32(Rows[4].ToString());
                    }
                }


                if (Start <= now2 && End >= now2)
                {
                    leave4 = "true";
                    break;
                }
            }
            foreach (DataRow Rows in dtEmployeeSingle_Leave.Rows)
            {
                if (Rows[2].ToString() == "1")
                {
                    if (objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()) == now2)
                    {
                        leave4 = "true";
                        break;
                    }
                }
                else
                {
                    if (objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()) == now2)
                    {
                        halfday4 = "true";
                        section4 = Convert.ToInt32(Rows[2].ToString());

                    }

                }
            }
            //End:-EMP-0009
            string Asigned4 = "false";
            string Print4 = "";
            foreach (DataRow Rows in dtEmployeJbshdl.Rows)
            {
                if (objCommon.textToDateTime(Rows["JOBSHDL_FROM_DATE"].ToString()) <= now2 && objCommon.textToDateTime(Rows["JOBSHDL_TO_DATE"].ToString()) >= now2)
                {
                    Asigned4 = "true";
                    break;
                }
            }

            string strDayString4 = now2.ToString("dddd");
            if (dtEmployeeJbBYDayWise.Rows.Count > 0)
            {
                foreach (DataRow RowsDay in dtEmployeeJbBYDayWise.Rows)
                {
                    if (objCommon.textToDateTime(RowsDay["JOBSHDL_FROM_DATE"].ToString()) <= now2 && objCommon.textToDateTime(RowsDay["JOBSHDL_TO_DATE"].ToString()) >= now2)
                    {
                        if (strJbAsgndDay.Contains(strDayString4))
                        {
                            Asigned4 = "true";
                            break;
                        }
                    }
                }
            }
            //check if duty sheduled
            DataTable dtDutySheduledForDay4 = objBusinessDutyRoster.ReadDutyShdlByEmp(objEntityDutyRoster);

            if (dtDutySheduledForDay4.Rows.Count > 0)
            {
                Asigned4 = "true";
                Print4 = dtDutySheduledForDay4.Rows[0][1].ToString();
            }




            strHtml += "<td style=\"width:10%;border: 1px solid #bdbcbc;\" >";

            if (Holi4 == "false" && leave4 == "false")
            {
                if (DutySlipSbmtd4 == "0")
                {
                    if (now2 >= DateTodayDate)
                    {
                        if (Asigned4 == "true")
                        {

                            strHtml += "<div style=\"width: 49%;float: left;\"><a class=\"tooltip\" title=\"duty shedule\"  onclick=\"return ShowJobShedule('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + halfday4 + "','" + section4 + "');\" ><img src=\"/Images/Icons/green round button.png\" style=\"vertical-align: middle;cursor:pointer;\"></div>";

                        }
                        else
                        {
                            strHtml += "<div style=\"width: 49%;float: left;\"><a  class=\"tooltip\" title=\"duty shedule\" onclick=\"return ShowJobShedule('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + halfday4 + "','" + section4 + "');\" ><img src=\"/Images/Icons/red round button.png\" style=\"vertical-align: middle;cursor:pointer;\"></div>";

                        }
                    }
                    else
                    {
                        strHtml += "<div style=\"width: 49%;float: left;\"><img src=\"/Images/Icons/red round button.png\" style=\"vertical-align: middle;cursor:pointer;opacity:0.4\"></a></div>";

                    }
                }
                else
                {
                    strHtml += "<div style=\"width: 49%;float: left;\"><a   onclick=\"return DutySlipSubmited();\" ><img src=\"/Images/Icons/green round button.png\" style=\"vertical-align: middle;cursor:pointer;\"></div>";
                }
                if (now2 <= DateTodayDate)
                {
                    if (DutySlipSbmtd4 == "0")
                    {
                        strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><a class=\"tooltip\" title=\"duty submit\"  onclick=\"return ShowJobSheduleSubmit('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + Print4 + "');\" ><img src=\"/Images/Icons/white round button.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;\"></a></div>";
                    }
                    else
                    {
                        strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><a class=\"tooltip\" title=\"duty submit\"  onclick=\"return ShowJobSheduleSubmit('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + Print4 + "');\" ><img src=\"/Images/Icons/orange round button.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;\"></a></div>";

                    }
                }
                else
                {
                    strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><a class=\"tooltip\" title=\"duty submit\"  ><img src=\"/Images/Icons/white round button.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;opacity:0.4\"></a></div>";
                }
            }
            else
            {
                strHtml += "<div style=\"width: 49%;float: left;\"><img src=\"/Images/Icons/leave.png\" style=\"vertical-align: middle;cursor:pointer;opacity:0.4\"></a></div>";

                strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><img src=\"/Images/Icons/leave_1.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;opacity:0.4\"></div>";

            }
            strHtml += " </td>";

            now2 = now2.AddDays(1);
            //Start:-EMP-0009
            objEntityDutyRoster.FromDate = now2;
            string DutySlipSbmtd5 = objBusinessDutyRoster.CheckDutySlpSubmsnSts(objEntityDutyRoster);
            string leave5 = "false";
            string halfday5 = "false";
            int section5 = 1;
            foreach (DataRow Rows in dtEmployeLeaveDtl.Rows)
            {
                DateTime Start = new DateTime();
                DateTime End = new DateTime();
                if (Rows[2].ToString() == "1")
                {
                    Start = objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString());
                }
                else
                {
                    Start = objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()).AddDays(1);
                    if (objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()) == now2)
                    {
                        halfday5 = "true";
                        section5 = Convert.ToInt32(Rows[2].ToString());
                    }

                }

                if (Rows[4].ToString() == "1")
                {
                    End = objCommon.textToDateTime(Rows["LEAVE_TO_DATE"].ToString());
                }
                else
                {
                    End = objCommon.textToDateTime(Rows["LEAVE_TO_DATE"].ToString()).AddDays(-1);
                    if (objCommon.textToDateTime(Rows["LEAVE_TO_DATE"].ToString()) == now2)
                    {
                        halfday5 = "true";
                        section5 = Convert.ToInt32(Rows[4].ToString());
                    }
                }


                if (Start <= now2 && End >= now2)
                {
                    leave5 = "true";
                    break;
                }
            }
            foreach (DataRow Rows in dtEmployeeSingle_Leave.Rows)
            {
                if (Rows[2].ToString() == "1")
                {
                    if (objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()) == now2)
                    {
                        leave5 = "true";
                        break;
                    }
                }
                else
                {
                    if (objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()) == now2)
                    {
                        halfday5 = "true";
                        section5 = Convert.ToInt32(Rows[2].ToString());

                    }

                }
            }
            //End:-EMP-0009
            string Asigned5 = "false";
            string Print5 = "";
            foreach (DataRow Rows in dtEmployeJbshdl.Rows)
            {
                if (objCommon.textToDateTime(Rows["JOBSHDL_FROM_DATE"].ToString()) <= now2 && objCommon.textToDateTime(Rows["JOBSHDL_TO_DATE"].ToString()) >= now2)
                {
                    Asigned5 = "true";
                    break;
                }
            }
            //check if duty sheduled
            DataTable dtDutySheduledForDay5 = objBusinessDutyRoster.ReadDutyShdlByEmp(objEntityDutyRoster);

            if (dtDutySheduledForDay5.Rows.Count > 0)
            {
                Asigned5 = "true";
                Print5 = dtDutySheduledForDay5.Rows[0][1].ToString();
            }

            string strDayString5 = now2.ToString("dddd");
             if (dtEmployeeJbBYDayWise.Rows.Count > 0)
            {
                foreach (DataRow RowsDay in dtEmployeeJbBYDayWise.Rows)
                {
                    if (objCommon.textToDateTime(RowsDay["JOBSHDL_FROM_DATE"].ToString()) <= now2 && objCommon.textToDateTime(RowsDay["JOBSHDL_TO_DATE"].ToString()) >= now2)
                    {
                        if (strJbAsgndDay.Contains(strDayString5))
                        {
                            Asigned5 = "true";
                            break;
                        }
                    }
                }
            }



             strHtml += "<td style=\"width:10%;border: 1px solid #bdbcbc;\" >";
            if ( Holi5 == "false" && leave5 == "false")
            {
                if (DutySlipSbmtd5 == "0")
                {
                    if (now2 >= DateTodayDate)
                    {
                        if (Asigned5 == "true")
                        {
                            strHtml += "<div style=\"width: 49%;float: left;\"><a class=\"tooltip\" title=\"duty shedule\"  onclick=\"return ShowJobShedule('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + halfday5 + "','" + section5 + "');\" ><img src=\"/Images/Icons/green round button.png\" style=\"vertical-align: middle;cursor:pointer;\"></div>";
                        }
                        else
                        {
                            strHtml += "<div style=\"width: 49%;float: left;\"><a class=\"tooltip\" title=\"duty shedule\"  onclick=\"return ShowJobShedule('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + halfday5 + "','" + section5 + "');\" ><img src=\"/Images/Icons/red round button.png\" style=\"vertical-align: middle;cursor:pointer;\"></div>";

                        }
                    }
                    else
                    {
                        strHtml += "<div style=\"width: 49%;float: left;\"><img src=\"/Images/Icons/red round button.png\" style=\"vertical-align: middle;cursor:pointer;opacity:0.4\"></a></div>";

                    }
                }
                else
                {
                    strHtml += "<div style=\"width: 49%;float: left;\"><a   onclick=\"return DutySlipSubmited();\" ><img src=\"/Images/Icons/green round button.png\" style=\"vertical-align: middle;cursor:pointer;\"></div>";
                }
                if (now2 <= DateTodayDate)
                {
                    if (DutySlipSbmtd5 == "0")
                    {
                        strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><a class=\"tooltip\" title=\"duty submit\"  onclick=\"return ShowJobSheduleSubmit('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + Print5 + "');\" ><img src=\"/Images/Icons/white round button.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;\"></a></div>";
                    }
                    else
                    {
                        strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><a class=\"tooltip\" title=\"duty submit\"  onclick=\"return ShowJobSheduleSubmit('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + Print5 + "');\" ><img src=\"/Images/Icons/orange round button.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;\"></a></div>";

                    }
                }
                else
                {
                    strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><a class=\"tooltip\" title=\"duty submit\"  ><img src=\"/Images/Icons/white round button.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;opacity:0.4\"></a></div>";
                }
            }
            else
            {
                strHtml += "<div style=\"width: 49%;float: left;\"><img src=\"/Images/Icons/leave.png\" style=\"vertical-align: middle;cursor:pointer;opacity:0.4\"></a></div>";

                strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><img src=\"/Images/Icons/leave_1.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;opacity:0.4\"></div>";

            }
            strHtml += " </td>";

            now2 = now2.AddDays(1);
            //Start:-EMP-0009
            objEntityDutyRoster.FromDate = now2;
            string DutySlipSbmtd6 = objBusinessDutyRoster.CheckDutySlpSubmsnSts(objEntityDutyRoster);
            string leave6 = "false";
            string halfday6 = "false";
            int section6 = 1;
            foreach (DataRow Rows in dtEmployeLeaveDtl.Rows)
            {
                DateTime Start = new DateTime();
                DateTime End = new DateTime();
                if (Rows[2].ToString() == "1")
                {
                    Start = objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString());
                }
                else
                {
                    Start = objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()).AddDays(1);
                    if (objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()) == now2)
                    {
                        halfday6 = "true";
                        section6 = Convert.ToInt32(Rows[2].ToString());
                    }

                }

                if (Rows[4].ToString() == "1")
                {
                    End = objCommon.textToDateTime(Rows["LEAVE_TO_DATE"].ToString());
                }
                else
                {
                    End = objCommon.textToDateTime(Rows["LEAVE_TO_DATE"].ToString()).AddDays(-1);
                    if (objCommon.textToDateTime(Rows["LEAVE_TO_DATE"].ToString()) == now2)
                    {
                        halfday6 = "true";
                        section6 = Convert.ToInt32(Rows[4].ToString());
                    }
                }

                if (Start <= now2 && End >= now2)
                {
                    leave6 = "true";
                    break;
                }
            }
            foreach (DataRow Rows in dtEmployeeSingle_Leave.Rows)
            {
                if (Rows[2].ToString() == "1")
                {
                    if (objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()) == now2)
                    {
                        leave6 = "true";
                        break;
                    }
                }
                else
                {
                    if (objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()) == now2)
                    {
                        halfday6 = "true";
                        section6 = Convert.ToInt32(Rows[2].ToString());

                    }

                }
            }
            //End:-EMP-0009
            string Asigned6 = "false";
            string Print6 = "";
            foreach (DataRow Rows in dtEmployeJbshdl.Rows)
            {
                if (objCommon.textToDateTime(Rows["JOBSHDL_FROM_DATE"].ToString()) <= now2 && objCommon.textToDateTime(Rows["JOBSHDL_TO_DATE"].ToString()) >= now2)
                {
                    Asigned6 = "true";
                    break;
                }
            }
            string strDayString6 = now2.ToString("dddd");
            if (dtEmployeeJbBYDayWise.Rows.Count > 0)
            {
                foreach (DataRow RowsDay in dtEmployeeJbBYDayWise.Rows)
                {
                    if (objCommon.textToDateTime(RowsDay["JOBSHDL_FROM_DATE"].ToString()) <= now2 && objCommon.textToDateTime(RowsDay["JOBSHDL_TO_DATE"].ToString()) >= now2)
                    {
                        if (strJbAsgndDay.Contains(strDayString6))
                        {
                            Asigned6 = "true";
                            break;
                        }
                    }
                }
            }
            //check if duty sheduled
            DataTable dtDutySheduledForDay6 = objBusinessDutyRoster.ReadDutyShdlByEmp(objEntityDutyRoster);

            if (dtDutySheduledForDay6.Rows.Count > 0)
            {
                Asigned6 = "true";
                Print6 = dtDutySheduledForDay6.Rows[0][1].ToString();
            }

            strHtml += "<td style=\"width:10%;border: 1px solid #bdbcbc;\" >";
            if (Holi6 == "false" && leave6 == "false")
            {
                if (DutySlipSbmtd6 == "0")
                {
                    if (now2 >= DateTodayDate)
                    {
                        if (Asigned6 == "true")
                        {
                            strHtml += "<div style=\"width: 49%;float: left;\"><a class=\"tooltip\" title=\"duty shedule\"  onclick=\"return ShowJobShedule('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + halfday6 + "','" + section6 + "');\" ><img src=\"/Images/Icons/green round button.png\" style=\"vertical-align: middle;cursor:pointer;\"></div>";

                        }
                        else
                        {
                            strHtml += "<div style=\"width: 49%;float: left;\"><a  class=\"tooltip\" title=\"duty shedule\" onclick=\"return ShowJobShedule('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + halfday6 + "','" + section6 + "');\" ><img src=\"/Images/Icons/red round button.png\" style=\"vertical-align: middle;cursor:pointer;\"></div>";

                        }
                    }
                    else
                    {
                        strHtml += "<div style=\"width: 49%;float: left;\"><img src=\"/Images/Icons/red round button.png\" style=\"vertical-align: middle;cursor:pointer;opacity:0.4\"></a></div>";

                    }
                }
                else
                {
                    strHtml += "<div style=\"width: 49%;float: left;\"><a   onclick=\"return DutySlipSubmited();\" ><img src=\"/Images/Icons/green round button.png\" style=\"vertical-align: middle;cursor:pointer;\"></div>";
                }
                if (now2 <= DateTodayDate)
                {
                    if (DutySlipSbmtd6 == "0")
                    {
                        strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><a  class=\"tooltip\" title=\"duty submit\" onclick=\"return ShowJobSheduleSubmit('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + Print6 + "');\" ><img src=\"/Images/Icons/white round button.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;\"></a></div>";
                    }
                    else
                    {
                        strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><a class=\"tooltip\" title=\"duty submit\"  onclick=\"return ShowJobSheduleSubmit('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + Print6 + "');\" ><img src=\"/Images/Icons/orange round button.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;\"></a></div>";

                    }
                }
                else
                {
                    strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><a class=\"tooltip\" title=\"duty submit\"  ><img src=\"/Images/Icons/white round button.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;opacity:0.4\"></a></div>";
                }
            }
            else
            {
                strHtml += "<div style=\"width: 49%;float: left;\"><img src=\"/Images/Icons/leave.png\" style=\"vertical-align: middle;cursor:pointer;opacity:0.4\"></a></div>";

                strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><img src=\"/Images/Icons/leave_1.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;opacity:0.4\"></div>";

            }
            strHtml += " </td>";

            now2 = now2.AddDays(1);
            //Start:-EMP-0009
            objEntityDutyRoster.FromDate = now2;
            string DutySlipSbmtd7 = objBusinessDutyRoster.CheckDutySlpSubmsnSts(objEntityDutyRoster);
            string leave7 = "false";
            string halfday7 = "false";
            int section7 = 1;
            foreach (DataRow Rows in dtEmployeLeaveDtl.Rows)
            {
                DateTime Start = new DateTime();
                DateTime End = new DateTime();
                if (Rows[2].ToString() == "1")
                {
                    Start = objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString());
                }
                else
                {
                    Start = objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()).AddDays(1);
                    if (objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()) == now2)
                    {
                        halfday7 = "true";
                        section7 = Convert.ToInt32(Rows[2].ToString());
                    }

                }

                if (Rows[4].ToString() == "1")
                {
                    End = objCommon.textToDateTime(Rows["LEAVE_TO_DATE"].ToString());
                }
                else
                {
                    End = objCommon.textToDateTime(Rows["LEAVE_TO_DATE"].ToString()).AddDays(-1);
                    if (objCommon.textToDateTime(Rows["LEAVE_TO_DATE"].ToString()) == now2)
                    {
                        halfday7 = "true";
                        section7 = Convert.ToInt32(Rows[4].ToString());
                    }
                }


                if (Start <= now2 && End >= now2)
                {
                    leave7 = "true";
                    break;
                }
            }
            foreach (DataRow Rows in dtEmployeeSingle_Leave.Rows)
            {
                if (Rows[2].ToString() == "1")
                {
                    if (objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()) == now2)
                    {
                        leave7 = "true";
                        break;
                    }
                }
                else
                {
                    if (objCommon.textToDateTime(Rows["LEAVE_FROM_DATE"].ToString()) == now2)
                    {
                        halfday7 = "true";
                        section7 = Convert.ToInt32(Rows[2].ToString());

                    }

                }
            }
            //End:-EMP-0009
            string Asigned7 = "false";
            string Print7 = "";
            foreach (DataRow Rows in dtEmployeJbshdl.Rows)
            {
                if (objCommon.textToDateTime(Rows["JOBSHDL_FROM_DATE"].ToString()) <= now2 && objCommon.textToDateTime(Rows["JOBSHDL_TO_DATE"].ToString()) >= now2)
                {
                    Asigned7 = "true";
                    break;
                }
            }
            //check if duty sheduled
            DataTable dtDutySheduledForDay7 = objBusinessDutyRoster.ReadDutyShdlByEmp(objEntityDutyRoster);

            if (dtDutySheduledForDay7.Rows.Count > 0)
            {
                Asigned7 = "true";
                Print7 = dtDutySheduledForDay7.Rows[0][1].ToString();
            }
            string strDayString7 = now2.ToString("dddd");
            if (dtEmployeeJbBYDayWise.Rows.Count > 0)
            {
                foreach (DataRow RowsDay in dtEmployeeJbBYDayWise.Rows)
                {
                    if (objCommon.textToDateTime(RowsDay["JOBSHDL_FROM_DATE"].ToString()) <= now2 && objCommon.textToDateTime(RowsDay["JOBSHDL_TO_DATE"].ToString()) >= now2)
                    {
                        if (strJbAsgndDay.Contains(strDayString7))
                        {
                            Asigned7 = "true";
                            break;
                        }
                    }
                }
            }


            strHtml += "<td style=\"width:10%;border: 1px solid #bdbcbc;\" >";
            if ( Holi7 == "false" && leave7 == "false")
            {
                if (DutySlipSbmtd7 == "0")
                {
                    if (now2 >= DateTodayDate)
                    {
                        if (Asigned7 == "true")
                        {
                            strHtml += "<div style=\"width: 49%;float: left;\"><a class=\"tooltip\" title=\"duty shedule\"  onclick=\"return ShowJobShedule('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + halfday7 + "','" + section7 + "');\" ><img src=\"/Images/Icons/green round button.png\" style=\"vertical-align: middle;cursor:pointer;\"></div>";

                        }
                        else
                        {
                            strHtml += "<div style=\"width: 49%;float: left;\"><a class=\"tooltip\" title=\"duty shedule\"  onclick=\"return ShowJobShedule('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + halfday7 + "','" + section7 + "');\" ><img src=\"/Images/Icons/red round button.png\" style=\"vertical-align: middle;cursor:pointer;\"></div>";

                        }
                    }
                    else
                    {
                        strHtml += "<div style=\"width: 49%;float: left;\"><img src=\"/Images/Icons/red round button.png\" style=\"vertical-align: middle;cursor:pointer;opacity:0.4\"></a></div>";

                    }
                }
                else
                {
                    strHtml += "<div style=\"width: 49%;float: left;\"><a   onclick=\"return DutySlipSubmited();\" ><img src=\"/Images/Icons/green round button.png\" style=\"vertical-align: middle;cursor:pointer;\"></div>";
                }
                if (now2 <= DateTodayDate)
                {
                    if (DutySlipSbmtd7 == "0")
                    {
                        strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><a class=\"tooltip\" title=\"duty submit\"  onclick=\"return ShowJobSheduleSubmit('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + Print7 + "');\" ><img src=\"/Images/Icons/white round button.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;\"></a></div>";
                    }
                    else
                    {
                        strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><a class=\"tooltip\" title=\"duty submit\"  onclick=\"return ShowJobSheduleSubmit('" + strEmpName + "','" + strId + "','" + now2.ToString("dd/MM/yyyy") + "','" + Print7 + "');\" ><img src=\"/Images/Icons/orange round button.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;\"></a></div>";

                    }
                }
                else
                {
                    strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><a class=\"tooltip\" title=\"duty submit\"  ><img src=\"/Images/Icons/white round button.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;opacity:0.4\"></a></div>";
                }
            }
            else
            {
                strHtml += "<div style=\"width: 49%;float: left;\"><img src=\"/Images/Icons/leave.png\" style=\"vertical-align: middle;cursor:pointer;opacity:0.4\"></a></div>";

                strHtml += "<div style=\"width: 49%;float: left;border-left: 1px solid;\"><img src=\"/Images/Icons/leave_1.png\" style=\"vertical-align: middle;margin-left: 17%;cursor:pointer;opacity:0.4\"></div>";

            }
            strHtml += " </td>";

            strHtml += "</tr>";
        }

       
           
      

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        divEmployeeContain.InnerHtml = sb.ToString();
        return sb.ToString();
    }
    protected void DateFront_Click(object sender, EventArgs e)
    { clsCommonLibrary objCommon = new clsCommonLibrary();
        DateTime now = new DateTime();
        now = objCommon.textToDateTime(hiddenFirstDate.Value);
        now = now.AddDays(7);
        hiddenFirstDate.Value = now.ToString("dd/MM/yyyy");
        FillEmployeeTable();
    }
    protected void DateBack_Click(object sender, EventArgs e)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        DateTime now = new DateTime();
        now = objCommon.textToDateTime(hiddenFirstDate.Value);
        now = now.AddDays(-7);
        hiddenFirstDate.Value = now.ToString("dd/MM/yyyy");
        FillEmployeeTable();
    }
    //This is the method for binding timeslot to dropdown list.
    public void TimeSlotLoad()
    {
        ddlTimeSlot_DayWise.Items.Clear();
        clsBusinessLayerJobShdl objBusinessLayerJobShdl = new clsBusinessLayerJobShdl();
        clsEntityLayerJobSchedule objEntityJobShdl = new clsEntityLayerJobSchedule();
        if (hiddenCorporateId.Value == "")
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityJobShdl.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {

            objEntityJobShdl.CorpOffice_Id = Convert.ToInt32(hiddenCorporateId.Value);
        }
        if (hiddenOrganisationId.Value == "")
        {
            if (Session["ORGID"] != null)
            {
                objEntityJobShdl.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {
            objEntityJobShdl.Organisation_Id = Convert.ToInt32(hiddenOrganisationId.Value);
        }
        DataTable dtTimeSlots = new DataTable();
        dtTimeSlots = objBusinessLayerJobShdl.ReadTimeSlotMasters(objEntityJobShdl);



        //Day Wise
        ddlTimeSlot_DayWise.DataSource = dtTimeSlots;
        ddlTimeSlot_DayWise.DataTextField = "TMSLT_NAME";
        ddlTimeSlot_DayWise.DataValueField = "TMSLT_ID";
        ddlTimeSlot_DayWise.DataBind();
        ddlTimeSlot_DayWise.Items.Insert(0, "--SELECT TIME SLOT--");


    }
    [WebMethod]
    public static string[] VehicleInsertNewRow(int VehId)
    {
        clsEntityLayerDutyRoster objEntityDutyRoster = new clsEntityLayerDutyRoster();
        clsBusinessLayerDutyRoster objBusinessDutyRoster = new clsBusinessLayerDutyRoster();
        string[] strJsonDW = new string[3];


        DataTable dtVehDetail = new DataTable();
        dtVehDetail.Columns.Add("VhclId", typeof(int));
        dtVehDetail.Columns.Add("VhclNumbr", typeof(string));
        dtVehDetail.Columns.Add("Mileage", typeof(string));



        objEntityDutyRoster.VehiclleId = Convert.ToInt32(VehId);
        DataTable dtVehicle = objBusinessDutyRoster.ReadVehicleById(objEntityDutyRoster);
        if (dtVehicle.Rows.Count>0)
        {

        DataRow drDtlVeh = dtVehDetail.NewRow();
        strJsonDW[0] =dtVehicle.Rows[0]["VHCL_ID"].ToString();
        strJsonDW[1] = dtVehicle.Rows[0]["VHCL_NUMBR"].ToString();
        strJsonDW[2] = dtVehicle.Rows[0]["VHCL_CRNT_MILEAGE"].ToString();
        }

      
        return strJsonDW;
    }
    [WebMethod]
    public static string[] DayWiseJobShdl(int intCorpId, int intOrgId, int EmpId, string DatePass)
    {//when Editing or viewing
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerDutyRoster objEntityDutyRoster = new clsEntityLayerDutyRoster();
        clsBusinessLayerDutyRoster objBusinessDutyRoster = new clsBusinessLayerDutyRoster();
        objEntityDutyRoster.Organisation_id = intOrgId;
        objEntityDutyRoster.Corporate_id = intCorpId;
        objEntityDutyRoster.FromDate = objCommon.textToDateTime(DatePass);

        objEntityDutyRoster.EmployeeId = EmpId;
        string[] strJsonDW = new string[3];

        DataTable dtJSDayWiseDtl = new DataTable();
        //   DataTable dtWBill = new DataTable();


        dtJSDayWiseDtl = objBusinessDutyRoster.ReadJobShdlForDayEmp(objEntityDutyRoster);//1-pDay wise


        DataTable dtDutyShdlDayWise = objBusinessDutyRoster.ReadDutyShdlForDayEmp(objEntityDutyRoster);//1-pDay wise

        DataTable dtJobShdlDayWise = objBusinessDutyRoster.ReadJobShdlForDayEmpDaywise(objEntityDutyRoster);

        if (dtDutyShdlDayWise.Rows.Count > 0)
        {


            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("TransId", typeof(int));
            dtDetail.Columns.Add("TransDtlId", typeof(int));
            dtDetail.Columns.Add("JobName", typeof(string));
            dtDetail.Columns.Add("JobId", typeof(int));
            dtDetail.Columns.Add("VhclNumbr", typeof(string));
            dtDetail.Columns.Add("VhclId", typeof(int));
            dtDetail.Columns.Add("PrjctName", typeof(string));
            dtDetail.Columns.Add("PrjctId", typeof(int));
            dtDetail.Columns.Add("FromTime", typeof(string));
            dtDetail.Columns.Add("ToTime", typeof(string));
            dtDetail.Columns.Add("JobMode", typeof(int));
            dtDetail.Columns.Add("txtJobName", typeof(string));



            dtDetail.Columns.Add("TmsltId", typeof(int));
            dtDetail.Columns.Add("TmsltName", typeof(string));
            dtDetail.Columns.Add("TmsltSts", typeof(int));
            dtDetail.Columns.Add("TmsltCnclUsrId", typeof(int));
            dtDetail.Columns.Add("DutyOrJobShdl", typeof(string));



            DataTable dtVehDetail = new DataTable();
            dtVehDetail.Columns.Add("VhclId", typeof(int));
            dtVehDetail.Columns.Add("VhclNumbr", typeof(string));
            dtVehDetail.Columns.Add("Mileage", typeof(string));


            for (int intcnt = 0; intcnt < dtDutyShdlDayWise.Rows.Count; intcnt++)
            {
                DataRow drDtl = dtDetail.NewRow();
                drDtl["TransId"] = Convert.ToInt32(dtDutyShdlDayWise.Rows[intcnt]["DUTYGNRTN_ID"].ToString());
                drDtl["TransDtlId"] = Convert.ToInt32(dtDutyShdlDayWise.Rows[intcnt]["DUTYGNRTNDTL_ID"].ToString());
                drDtl["JobName"] = dtDutyShdlDayWise.Rows[intcnt]["JOBMSTR_TITLE"].ToString();
                if (dtDutyShdlDayWise.Rows[intcnt]["JOBMSTR_ID"].ToString() != "")
                {
                    drDtl["JobId"] = Convert.ToInt32(dtDutyShdlDayWise.Rows[intcnt]["JOBMSTR_ID"].ToString());

                }
                else
                {
                    // WHEN CHANGING MODE IT BECOMES NULL
                    drDtl["JobId"] = 0;
                }

                drDtl["VhclNumbr"] = dtDutyShdlDayWise.Rows[intcnt]["VHCL_NUMBR"].ToString();
                drDtl["VhclId"] = Convert.ToInt32(dtDutyShdlDayWise.Rows[intcnt]["VHCL_ID"].ToString());
                drDtl["PrjctName"] = dtDutyShdlDayWise.Rows[intcnt]["PROJECT_NAME"].ToString();
                drDtl["PrjctId"] = Convert.ToInt32(dtDutyShdlDayWise.Rows[intcnt]["PROJECT_ID"].ToString());
                drDtl["FromTime"] = dtDutyShdlDayWise.Rows[intcnt]["DUTYGNRTNDTL_FROM_TIME"].ToString();
                drDtl["ToTime"] = dtDutyShdlDayWise.Rows[intcnt]["DUTYGNRTNDTL_TO_TIME"].ToString();
                if (dtDutyShdlDayWise.Rows[intcnt]["JOBMSTR_ID"].ToString() != "")
                {
                    drDtl["JobMode"] = Convert.ToInt32(1);
                }
                else
                {
                    drDtl["JobMode"] = Convert.ToInt32(2);
                }
              
                drDtl["txtJobName"] = dtDutyShdlDayWise.Rows[intcnt]["JOB_NAME"].ToString();


                drDtl["TmsltId"] = Convert.ToInt32(dtDutyShdlDayWise.Rows[intcnt]["TMSLT_ID"].ToString());
                drDtl["TmsltName"] = dtDutyShdlDayWise.Rows[intcnt]["TMSLT_NAME"].ToString();
                drDtl["TmsltSts"] = Convert.ToInt32(dtDutyShdlDayWise.Rows[intcnt]["TMSLT_STATUS"].ToString());
                if (dtDutyShdlDayWise.Rows[intcnt]["TMSLT_CNCL_USR_ID"].ToString() != "")
                {
                    drDtl["TmsltCnclUsrId"] = Convert.ToInt32(dtDutyShdlDayWise.Rows[intcnt]["TMSLT_CNCL_USR_ID"].ToString());
                }
                else
                {
                    drDtl["TmsltCnclUsrId"] = 0;
                }

                drDtl["DutyOrJobShdl"] = "DUTY";

                dtDetail.Rows.Add(drDtl);


                objEntityDutyRoster.VehiclleId = Convert.ToInt32(dtDutyShdlDayWise.Rows[intcnt]["VHCL_ID"].ToString());
                DataTable dtVehicle = objBusinessDutyRoster.ReadVehicleById(objEntityDutyRoster);
                DataRow drDtlVeh = dtVehDetail.NewRow();
                drDtlVeh["VhclId"] = Convert.ToInt32(dtVehicle.Rows[0]["VHCL_ID"].ToString());
                drDtlVeh["VhclNumbr"] = dtVehicle.Rows[0]["VHCL_NUMBR"].ToString();
                drDtlVeh["Mileage"] = dtVehicle.Rows[0]["VHCL_CRNT_MILEAGE"].ToString();

                var aa = "true";
                foreach (DataRow rows in dtVehDetail.Rows)
                {
                    if (rows["VhclId"].ToString() == objEntityDutyRoster.VehiclleId.ToString())
                    {
                        aa = "false";
                    }
                }

                if (aa == "true")
                {
                    dtVehDetail.Rows.Add(drDtlVeh);
                }
            }


            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dtDetail.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dtDetail.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);

                }

                parentRow.Add(childRow);
            }

            strJsonDW[2] = jsSerializer.Serialize(parentRow);


            List<Dictionary<string, object>> parentRowVeh = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRowVeh;
            foreach (DataRow rowVeh in dtVehDetail.Rows)
            {
                childRowVeh = new Dictionary<string, object>();
                foreach (DataColumn colveh in dtVehDetail.Columns)
                {
                    childRowVeh.Add(colveh.ColumnName, rowVeh[colveh]);

                }

                parentRowVeh.Add(childRowVeh);
            }

            strJsonDW[1] = jsSerializer.Serialize(parentRowVeh);

        }
        else
        {
            if (dtJobShdlDayWise.Rows.Count > 0)
            {
                string strJbAsgndDay = "";
                foreach (DataRow RowsDay in dtJobShdlDayWise.Rows)
                {
                    string DayValue = RowsDay["WEEK_DAYS_ID"].ToString();

                    switch (DayValue)
                    {
                        case "1":
                            strJbAsgndDay += "Monday";
                            break;
                        case "2":
                            strJbAsgndDay += "Tuesday";
                            break;
                        case "3":
                            strJbAsgndDay += "Wednesday";
                            break;
                        case "4":
                            strJbAsgndDay += "Thursday";
                            break;
                        case "5":
                            strJbAsgndDay += "Friday";
                            break;
                        case "6":
                            strJbAsgndDay += "Saturday";
                            break;
                        case "0":
                            strJbAsgndDay += "Sunday";
                            break;
                    }
                }

                DateTime now2 = new DateTime();
                now2 = objCommon.textToDateTime(DatePass);
                string strDayString = now2.ToString("dddd");

                if (strJbAsgndDay.Contains(strDayString))
                {
                    DataTable dtDetail = new DataTable();
                    dtDetail.Columns.Add("TransId", typeof(int));
                    dtDetail.Columns.Add("TransDtlId", typeof(int));
                    dtDetail.Columns.Add("JobName", typeof(string));
                    dtDetail.Columns.Add("JobId", typeof(int));
                    dtDetail.Columns.Add("VhclNumbr", typeof(string));
                    dtDetail.Columns.Add("VhclId", typeof(int));
                    dtDetail.Columns.Add("PrjctName", typeof(string));
                    dtDetail.Columns.Add("PrjctId", typeof(int));
                    dtDetail.Columns.Add("FromTime", typeof(string));
                    dtDetail.Columns.Add("ToTime", typeof(string));
                    dtDetail.Columns.Add("JobMode", typeof(int));
                    dtDetail.Columns.Add("txtJobName", typeof(string));



                    dtDetail.Columns.Add("TmsltId", typeof(int));
                    dtDetail.Columns.Add("TmsltName", typeof(string));
                    dtDetail.Columns.Add("TmsltSts", typeof(int));
                    dtDetail.Columns.Add("TmsltCnclUsrId", typeof(int));
                    dtDetail.Columns.Add("DutyOrJobShdl", typeof(string));



                    DataTable dtVehDetail = new DataTable();
                    dtVehDetail.Columns.Add("VhclId", typeof(int));
                    dtVehDetail.Columns.Add("VhclNumbr", typeof(string));
                    dtVehDetail.Columns.Add("Mileage", typeof(string));


                    for (int intcnt = 0; intcnt < dtJobShdlDayWise.Rows.Count; intcnt++)
                    {
                        DataRow drDtl = dtDetail.NewRow();
                        drDtl["TransId"] = Convert.ToInt32(dtJobShdlDayWise.Rows[intcnt]["JOBSHDL_ID"].ToString());
                        drDtl["TransDtlId"] = Convert.ToInt32(dtJobShdlDayWise.Rows[intcnt]["JOBSHDLDTL_ID"].ToString());
                        drDtl["JobName"] = dtJobShdlDayWise.Rows[intcnt]["JOBMSTR_TITLE"].ToString();
                        if (dtJobShdlDayWise.Rows[intcnt]["JOBMSTR_ID"].ToString() != "")
                        {
                            drDtl["JobId"] = Convert.ToInt32(dtJobShdlDayWise.Rows[intcnt]["JOBMSTR_ID"].ToString());

                        }
                        else
                        {
                            // WHEN CHANGING MODE IT BECOMES NULL
                            drDtl["JobId"] = 0;
                        }

                        drDtl["VhclNumbr"] = dtJobShdlDayWise.Rows[intcnt]["VHCL_NUMBR"].ToString();
                        drDtl["VhclId"] = Convert.ToInt32(dtJobShdlDayWise.Rows[intcnt]["VHCL_ID"].ToString());
                        drDtl["PrjctName"] = dtJobShdlDayWise.Rows[intcnt]["PROJECT_NAME"].ToString();
                        drDtl["PrjctId"] = Convert.ToInt32(dtJobShdlDayWise.Rows[intcnt]["PROJECT_ID"].ToString());
                        drDtl["FromTime"] = dtJobShdlDayWise.Rows[intcnt]["JOBSHDLDTL_FROM_TIME"].ToString();
                        drDtl["ToTime"] = dtJobShdlDayWise.Rows[intcnt]["JOBSHDLDTL_TO_TIME"].ToString();
                        drDtl["JobMode"] = Convert.ToInt32(dtJobShdlDayWise.Rows[intcnt]["JOBSHDLDTL_JOB_MODE"].ToString());
                        drDtl["txtJobName"] = dtJobShdlDayWise.Rows[intcnt]["JOB_NAME"].ToString();


                        drDtl["TmsltId"] = Convert.ToInt32(dtJobShdlDayWise.Rows[intcnt]["TMSLT_ID"].ToString());
                        drDtl["TmsltName"] = dtJobShdlDayWise.Rows[intcnt]["TMSLT_NAME"].ToString();
                        drDtl["TmsltSts"] = Convert.ToInt32(dtJobShdlDayWise.Rows[intcnt]["TMSLT_STATUS"].ToString());
                        if (dtJobShdlDayWise.Rows[intcnt]["TMSLT_CNCL_USR_ID"].ToString() != "")
                        {
                            drDtl["TmsltCnclUsrId"] = Convert.ToInt32(dtJobShdlDayWise.Rows[intcnt]["TMSLT_CNCL_USR_ID"].ToString());
                        }
                        else
                        {
                            drDtl["TmsltCnclUsrId"] = 0;
                        }
                        drDtl["DutyOrJobShdl"] = "JOBSHDL";


                        dtDetail.Rows.Add(drDtl);


                        objEntityDutyRoster.VehiclleId = Convert.ToInt32(dtJobShdlDayWise.Rows[intcnt]["VHCL_ID"].ToString());
                        DataTable dtVehicle = objBusinessDutyRoster.ReadVehicleById(objEntityDutyRoster);
                        DataRow drDtlVeh = dtVehDetail.NewRow();
                        drDtlVeh["VhclId"] = Convert.ToInt32(dtVehicle.Rows[0]["VHCL_ID"].ToString());
                        drDtlVeh["VhclNumbr"] = dtVehicle.Rows[0]["VHCL_NUMBR"].ToString();
                        drDtlVeh["Mileage"] = dtVehicle.Rows[0]["VHCL_CRNT_MILEAGE"].ToString();
                        var aa = "true";
                        foreach (DataRow rows in dtVehDetail.Rows)
                        {
                            if (rows["VhclId"].ToString() == objEntityDutyRoster.VehiclleId.ToString())
                            {
                                aa = "false";
                            }
                        }

                        if (aa == "true")
                        {
                            dtVehDetail.Rows.Add(drDtlVeh);
                        }
                    }


                    JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                    List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
                    Dictionary<string, object> childRow;
                    foreach (DataRow row in dtDetail.Rows)
                    {
                        childRow = new Dictionary<string, object>();
                        foreach (DataColumn col in dtDetail.Columns)
                        {
                            childRow.Add(col.ColumnName, row[col]);

                        }

                        parentRow.Add(childRow);
                    }

                    strJsonDW[0] = jsSerializer.Serialize(parentRow);


                    List<Dictionary<string, object>> parentRowVeh = new List<Dictionary<string, object>>();
                    Dictionary<string, object> childRowVeh;
                    foreach (DataRow rowVeh in dtVehDetail.Rows)
                    {
                        childRowVeh = new Dictionary<string, object>();
                        foreach (DataColumn colveh in dtVehDetail.Columns)
                        {
                            childRowVeh.Add(colveh.ColumnName, rowVeh[colveh]);

                        }

                        parentRowVeh.Add(childRowVeh);
                    }

                    strJsonDW[1] = jsSerializer.Serialize(parentRowVeh);
                }
                else if (dtJSDayWiseDtl.Rows.Count > 0)
                {
                    DataTable dtDetail = new DataTable();
                    dtDetail.Columns.Add("TransId", typeof(int));
                    dtDetail.Columns.Add("TransDtlId", typeof(int));
                    dtDetail.Columns.Add("JobName", typeof(string));
                    dtDetail.Columns.Add("JobId", typeof(int));
                    dtDetail.Columns.Add("VhclNumbr", typeof(string));
                    dtDetail.Columns.Add("VhclId", typeof(int));
                    dtDetail.Columns.Add("PrjctName", typeof(string));
                    dtDetail.Columns.Add("PrjctId", typeof(int));
                    dtDetail.Columns.Add("FromTime", typeof(string));
                    dtDetail.Columns.Add("ToTime", typeof(string));
                    dtDetail.Columns.Add("JobMode", typeof(int));
                    dtDetail.Columns.Add("txtJobName", typeof(string));



                    dtDetail.Columns.Add("TmsltId", typeof(int));
                    dtDetail.Columns.Add("TmsltName", typeof(string));
                    dtDetail.Columns.Add("TmsltSts", typeof(int));
                    dtDetail.Columns.Add("TmsltCnclUsrId", typeof(int));
                    dtDetail.Columns.Add("DutyOrJobShdl", typeof(string));



                    DataTable dtVehDetail = new DataTable();
                    dtVehDetail.Columns.Add("VhclId", typeof(int));
                    dtVehDetail.Columns.Add("VhclNumbr", typeof(string));
                    dtVehDetail.Columns.Add("Mileage", typeof(string));


                    for (int intcnt = 0; intcnt < dtJSDayWiseDtl.Rows.Count; intcnt++)
                    {
                        DataRow drDtl = dtDetail.NewRow();
                        drDtl["TransId"] = Convert.ToInt32(dtJSDayWiseDtl.Rows[intcnt]["JOBSHDL_ID"].ToString());
                        drDtl["TransDtlId"] = Convert.ToInt32(dtJSDayWiseDtl.Rows[intcnt]["JOBSHDLDTL_ID"].ToString());
                        drDtl["JobName"] = dtJSDayWiseDtl.Rows[intcnt]["JOBMSTR_TITLE"].ToString();
                        if (dtJSDayWiseDtl.Rows[intcnt]["JOBMSTR_ID"].ToString() != "")
                        {
                            drDtl["JobId"] = Convert.ToInt32(dtJSDayWiseDtl.Rows[intcnt]["JOBMSTR_ID"].ToString());

                        }
                        else
                        {
                            // WHEN CHANGING MODE IT BECOMES NULL
                            drDtl["JobId"] = 0;
                        }

                        drDtl["VhclNumbr"] = dtJSDayWiseDtl.Rows[intcnt]["VHCL_NUMBR"].ToString();
                        drDtl["VhclId"] = Convert.ToInt32(dtJSDayWiseDtl.Rows[intcnt]["VHCL_ID"].ToString());
                        drDtl["PrjctName"] = dtJSDayWiseDtl.Rows[intcnt]["PROJECT_NAME"].ToString();
                        drDtl["PrjctId"] = Convert.ToInt32(dtJSDayWiseDtl.Rows[intcnt]["PROJECT_ID"].ToString());
                        drDtl["FromTime"] = dtJSDayWiseDtl.Rows[intcnt]["JOBSHDLDTL_FROM_TIME"].ToString();
                        drDtl["ToTime"] = dtJSDayWiseDtl.Rows[intcnt]["JOBSHDLDTL_TO_TIME"].ToString();
                        drDtl["JobMode"] = Convert.ToInt32(dtJSDayWiseDtl.Rows[intcnt]["JOBSHDLDTL_JOB_MODE"].ToString());
                        drDtl["txtJobName"] = dtJSDayWiseDtl.Rows[intcnt]["JOB_NAME"].ToString();


                        drDtl["TmsltId"] = Convert.ToInt32(dtJSDayWiseDtl.Rows[intcnt]["TMSLT_ID"].ToString());
                        drDtl["TmsltName"] = dtJSDayWiseDtl.Rows[intcnt]["TMSLT_NAME"].ToString();
                        drDtl["TmsltSts"] = Convert.ToInt32(dtJSDayWiseDtl.Rows[intcnt]["TMSLT_STATUS"].ToString());
                        if (dtJSDayWiseDtl.Rows[intcnt]["TMSLT_CNCL_USR_ID"].ToString() != "")
                        {
                            drDtl["TmsltCnclUsrId"] = Convert.ToInt32(dtJSDayWiseDtl.Rows[intcnt]["TMSLT_CNCL_USR_ID"].ToString());
                        }
                        else
                        {
                            drDtl["TmsltCnclUsrId"] = 0;
                        }
                        drDtl["DutyOrJobShdl"] = "JOBSHDL";


                        dtDetail.Rows.Add(drDtl);


                        objEntityDutyRoster.VehiclleId = Convert.ToInt32(dtJSDayWiseDtl.Rows[intcnt]["VHCL_ID"].ToString());
                        DataTable dtVehicle = objBusinessDutyRoster.ReadVehicleById(objEntityDutyRoster);
                        DataRow drDtlVeh = dtVehDetail.NewRow();
                        drDtlVeh["VhclId"] = Convert.ToInt32(dtVehicle.Rows[0]["VHCL_ID"].ToString());
                        drDtlVeh["VhclNumbr"] = dtVehicle.Rows[0]["VHCL_NUMBR"].ToString();
                        drDtlVeh["Mileage"] = dtVehicle.Rows[0]["VHCL_CRNT_MILEAGE"].ToString();
                        var aa = "true";
                        foreach (DataRow rows in dtVehDetail.Rows)
                        {
                            if (rows["VhclId"].ToString() == objEntityDutyRoster.VehiclleId.ToString())
                            {
                                aa = "false";
                            }
                        }

                        if (aa == "true")
                        {
                            dtVehDetail.Rows.Add(drDtlVeh);
                        }
                    }


                    JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                    List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
                    Dictionary<string, object> childRow;
                    foreach (DataRow row in dtDetail.Rows)
                    {
                        childRow = new Dictionary<string, object>();
                        foreach (DataColumn col in dtDetail.Columns)
                        {
                            childRow.Add(col.ColumnName, row[col]);

                        }

                        parentRow.Add(childRow);
                    }

                    strJsonDW[0] = jsSerializer.Serialize(parentRow);


                    List<Dictionary<string, object>> parentRowVeh = new List<Dictionary<string, object>>();
                    Dictionary<string, object> childRowVeh;
                    foreach (DataRow rowVeh in dtVehDetail.Rows)
                    {
                        childRowVeh = new Dictionary<string, object>();
                        foreach (DataColumn colveh in dtVehDetail.Columns)
                        {
                            childRowVeh.Add(colveh.ColumnName, rowVeh[colveh]);

                        }

                        parentRowVeh.Add(childRowVeh);
                    }

                    strJsonDW[1] = jsSerializer.Serialize(parentRowVeh);
                }
            }

            else if (dtJSDayWiseDtl.Rows.Count > 0)
            {
                DataTable dtDetail = new DataTable();
                dtDetail.Columns.Add("TransId", typeof(int));
                dtDetail.Columns.Add("TransDtlId", typeof(int));
                dtDetail.Columns.Add("JobName", typeof(string));
                dtDetail.Columns.Add("JobId", typeof(int));
                dtDetail.Columns.Add("VhclNumbr", typeof(string));
                dtDetail.Columns.Add("VhclId", typeof(int));
                dtDetail.Columns.Add("PrjctName", typeof(string));
                dtDetail.Columns.Add("PrjctId", typeof(int));
                dtDetail.Columns.Add("FromTime", typeof(string));
                dtDetail.Columns.Add("ToTime", typeof(string));
                dtDetail.Columns.Add("JobMode", typeof(int));
                dtDetail.Columns.Add("txtJobName", typeof(string));



                dtDetail.Columns.Add("TmsltId", typeof(int));
                dtDetail.Columns.Add("TmsltName", typeof(string));
                dtDetail.Columns.Add("TmsltSts", typeof(int));
                dtDetail.Columns.Add("TmsltCnclUsrId", typeof(int));
                dtDetail.Columns.Add("DutyOrJobShdl", typeof(string));



                DataTable dtVehDetail = new DataTable();
                dtVehDetail.Columns.Add("VhclId", typeof(int));
                dtVehDetail.Columns.Add("VhclNumbr", typeof(string));
                dtVehDetail.Columns.Add("Mileage", typeof(string));


                for (int intcnt = 0; intcnt < dtJSDayWiseDtl.Rows.Count; intcnt++)
                {
                    DataRow drDtl = dtDetail.NewRow();
                    drDtl["TransId"] = Convert.ToInt32(dtJSDayWiseDtl.Rows[intcnt]["JOBSHDL_ID"].ToString());
                    drDtl["TransDtlId"] = Convert.ToInt32(dtJSDayWiseDtl.Rows[intcnt]["JOBSHDLDTL_ID"].ToString());
                    drDtl["JobName"] = dtJSDayWiseDtl.Rows[intcnt]["JOBMSTR_TITLE"].ToString();
                    if (dtJSDayWiseDtl.Rows[intcnt]["JOBMSTR_ID"].ToString() != "")
                    {
                        drDtl["JobId"] = Convert.ToInt32(dtJSDayWiseDtl.Rows[intcnt]["JOBMSTR_ID"].ToString());

                    }
                    else
                    {
                        // WHEN CHANGING MODE IT BECOMES NULL
                        drDtl["JobId"] = 0;
                    }

                    drDtl["VhclNumbr"] = dtJSDayWiseDtl.Rows[intcnt]["VHCL_NUMBR"].ToString();
                    drDtl["VhclId"] = Convert.ToInt32(dtJSDayWiseDtl.Rows[intcnt]["VHCL_ID"].ToString());
                    drDtl["PrjctName"] = dtJSDayWiseDtl.Rows[intcnt]["PROJECT_NAME"].ToString();
                    drDtl["PrjctId"] = Convert.ToInt32(dtJSDayWiseDtl.Rows[intcnt]["PROJECT_ID"].ToString());
                    drDtl["FromTime"] = dtJSDayWiseDtl.Rows[intcnt]["JOBSHDLDTL_FROM_TIME"].ToString();
                    drDtl["ToTime"] = dtJSDayWiseDtl.Rows[intcnt]["JOBSHDLDTL_TO_TIME"].ToString();
                    drDtl["JobMode"] = Convert.ToInt32(dtJSDayWiseDtl.Rows[intcnt]["JOBSHDLDTL_JOB_MODE"].ToString());
                    drDtl["txtJobName"] = dtJSDayWiseDtl.Rows[intcnt]["JOB_NAME"].ToString();


                    drDtl["TmsltId"] = Convert.ToInt32(dtJSDayWiseDtl.Rows[intcnt]["TMSLT_ID"].ToString());
                    drDtl["TmsltName"] = dtJSDayWiseDtl.Rows[intcnt]["TMSLT_NAME"].ToString();
                    drDtl["TmsltSts"] = Convert.ToInt32(dtJSDayWiseDtl.Rows[intcnt]["TMSLT_STATUS"].ToString());
                    if (dtJSDayWiseDtl.Rows[intcnt]["TMSLT_CNCL_USR_ID"].ToString() != "")
                    {
                        drDtl["TmsltCnclUsrId"] = Convert.ToInt32(dtJSDayWiseDtl.Rows[intcnt]["TMSLT_CNCL_USR_ID"].ToString());
                    }
                    else
                    {
                        drDtl["TmsltCnclUsrId"] = 0;
                    }

                    drDtl["DutyOrJobShdl"] = "JOBSHDL";

                    dtDetail.Rows.Add(drDtl);


                    objEntityDutyRoster.VehiclleId = Convert.ToInt32(dtJSDayWiseDtl.Rows[intcnt]["VHCL_ID"].ToString());
                    DataTable dtVehicle = objBusinessDutyRoster.ReadVehicleById(objEntityDutyRoster);
                    DataRow drDtlVeh = dtVehDetail.NewRow();
                    drDtlVeh["VhclId"] = Convert.ToInt32(dtVehicle.Rows[0]["VHCL_ID"].ToString());
                    drDtlVeh["VhclNumbr"] = dtVehicle.Rows[0]["VHCL_NUMBR"].ToString();
                    drDtlVeh["Mileage"] = dtVehicle.Rows[0]["VHCL_CRNT_MILEAGE"].ToString();
                    var aa = "true";
                    foreach (DataRow rows in dtVehDetail.Rows)
                    {
                        if (rows["VhclId"].ToString() == objEntityDutyRoster.VehiclleId.ToString())
                        {
                            aa = "false";
                        }
                    }

                    if (aa == "true")
                    {
                        dtVehDetail.Rows.Add(drDtlVeh);
                    }
                }


                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
                Dictionary<string, object> childRow;
                foreach (DataRow row in dtDetail.Rows)
                {
                    childRow = new Dictionary<string, object>();
                    foreach (DataColumn col in dtDetail.Columns)
                    {
                        childRow.Add(col.ColumnName, row[col]);

                    }

                    parentRow.Add(childRow);
                }

                strJsonDW[0] = jsSerializer.Serialize(parentRow);


                List<Dictionary<string, object>> parentRowVeh = new List<Dictionary<string, object>>();
                Dictionary<string, object> childRowVeh;
                foreach (DataRow rowVeh in dtVehDetail.Rows)
                {
                    childRowVeh = new Dictionary<string, object>();
                    foreach (DataColumn colveh in dtVehDetail.Columns)
                    {
                        childRowVeh.Add(colveh.ColumnName, rowVeh[colveh]);

                    }

                    parentRowVeh.Add(childRowVeh);
                }

                strJsonDW[1] = jsSerializer.Serialize(parentRowVeh);
            }
        }
        return strJsonDW;
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

    public class clsJSData
    {
        public string JOBID { get; set; }
        public string JOBNAME { get; set; }
        public string VHCLID { get; set; }
        public string PRJCTID { get; set; }
        public string FROMTIME { get; set; }
        public string TOTIME { get; set; }
        public string EVTACTION { get; set; }
        public string DTLID { get; set; }
        public string JOBMODE { get; set; }
    }

    public class TimeSlotDtls
    {
        public string strStartTime = "";
        public string strEndTime = "";


    }
    // this web method is for fetching data based on the card selected 
    [WebMethod]
    public static TimeSlotDtls TimeSlotDetails(string corporateId, string organisationId, string SLOTID)
    {

        TimeSlotDtls objTimeSlotDtls = new TimeSlotDtls();     // CREATE AN OBJECT.

        //Creating objects for business layer
        clsBusinessLayerJobShdl objBusinessLayerJobShdl = new clsBusinessLayerJobShdl();
        clsEntityLayerJobSchedule objEntityJobShdl = new clsEntityLayerJobSchedule();


        if (corporateId != null && corporateId != "" && corporateId != "undefined" && organisationId != null && organisationId != "" && organisationId != "undefined" && SLOTID != null && SLOTID != "" && SLOTID != "undefined")
        {
            objEntityJobShdl.CorpOffice_Id = Convert.ToInt32(corporateId);
            objEntityJobShdl.Organisation_Id = Convert.ToInt32(organisationId);
            objEntityJobShdl.TimeSlotId = Convert.ToInt32(SLOTID);
        }

        DataTable dtTimeSlotDtl = new DataTable();

        dtTimeSlotDtl = objBusinessLayerJobShdl.ReadTimeSlotById(objEntityJobShdl);
        if (dtTimeSlotDtl.Rows.Count > 0)
        {
            objTimeSlotDtls.strStartTime = dtTimeSlotDtl.Rows[0]["TMSLT_START_TIME"].ToString();
            objTimeSlotDtls.strEndTime = dtTimeSlotDtl.Rows[0]["TMSLT_END_TIME"].ToString();

        }
        return objTimeSlotDtls;
    }
    //Start:-Emp-0009
    protected void btnSchedule_Click(object sender, EventArgs e)
    {
        clsEntityLayerDutyRoster objEntityDutyRoster = new clsEntityLayerDutyRoster();
        clsBusinessLayerDutyRoster objBusinessDutyRoster = new clsBusinessLayerDutyRoster();
        clsCommonLibrary objCommon = new clsCommonLibrary();
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
        if (Session["USERID"] != null)
        {
            objEntityDutyRoster.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityDutyRoster.Date = System.DateTime.Now;
        objEntityDutyRoster.EmployeeId = Convert.ToInt32(HiddenFieldEmployeeId.Value);
        objEntityDutyRoster.FromDate = objCommon.textToDateTime(HiddenFieldDate.Value);
        objEntityDutyRoster.Status_id = 1;


        if (hiddenDutyMasterId.Value != "0" && hiddenDutyMasterId.Value != null && hiddenDutyMasterId.Value !="")
        {
            objEntityDutyRoster.DutyRosterId = Convert.ToInt32(hiddenDutyMasterId.Value);
            List<clsEntityLayerJobScheduleDtl> objEntityWBDeatilsINSERTDayList = new List<clsEntityLayerJobScheduleDtl>();
            List<clsEntityLayerJobScheduleDtl> objEntityWBDeatilsUPDATEDayList = new List<clsEntityLayerJobScheduleDtl>();

            string jsonDataPW = HiddenField2.Value;
            string R1PW = jsonDataPW.Replace("\"{", "\\{");
            string R2PW = R1PW.Replace("\\n", "\r\n");
            string R3PW = R2PW.Replace("\\", "");
            string R4PW = R3PW.Replace("}\"]", "}]");
            string R5PW = R4PW.Replace("}\",", "},");
            List<clsJSData> objWBDataPWList = new List<clsJSData>();
            // UserData  data
            objWBDataPWList = JsonConvert.DeserializeObject<List<clsJSData>>(R5PW);


            foreach (clsJSData objclsJSData in objWBDataPWList)
            {
                if (objclsJSData.EVTACTION == "INS")
                {
                    clsEntityLayerJobScheduleDtl objEntityDetails = new clsEntityLayerJobScheduleDtl();
                    objEntityDetails.DutyRosterId = Convert.ToInt32(hiddenDutyMasterId.Value);
                    objEntityDetails.TimeSlotId = Convert.ToInt32(hiddenddlTimeSlotPWVal.Value);
                    objEntityDetails.SchdlWiseMode = 0;
                    string strFromDatetime = Convert.ToString("01-01-1000-" + objclsJSData.FROMTIME);
                    objEntityDetails.FromTime = objCommon.textWithTimeToDateTime(strFromDatetime);
                    string strToDatetime = Convert.ToString("01-01-1000-" + objclsJSData.TOTIME);
                    objEntityDetails.ToTime = objCommon.textWithTimeToDateTime(strToDatetime);
                    objEntityDetails.VhclId = Convert.ToInt32(objclsJSData.VHCLID);
                    objEntityDetails.PrjctId = Convert.ToInt32(objclsJSData.PRJCTID);
                    objEntityDetails.JobId = Convert.ToInt32(objclsJSData.JOBID);
                    objEntityDetails.JobName = objclsJSData.JOBNAME.Trim();
                    objEntityDetails.JobMode = Convert.ToInt32(objclsJSData.JOBMODE);
                    objEntityWBDeatilsINSERTDayList.Add(objEntityDetails);
                }
                else if (objclsJSData.EVTACTION == "UPD")
                {
                    clsEntityLayerJobScheduleDtl objEntityDetails = new clsEntityLayerJobScheduleDtl();
                    objEntityDetails.DutyRosterDetailId = Convert.ToInt32(objclsJSData.DTLID);

                    objEntityDetails.TimeSlotId = Convert.ToInt32(hiddenddlTimeSlotPWVal.Value);
                    objEntityDetails.SchdlWiseMode = 0;
                    string strFromDatetime = Convert.ToString("01-01-1000-" + objclsJSData.FROMTIME);
                    objEntityDetails.FromTime = objCommon.textWithTimeToDateTime(strFromDatetime);
                    string strToDatetime = Convert.ToString("01-01-1000-" + objclsJSData.TOTIME);
                    objEntityDetails.ToTime = objCommon.textWithTimeToDateTime(strToDatetime);
                    objEntityDetails.VhclId = Convert.ToInt32(objclsJSData.VHCLID);
                    objEntityDetails.PrjctId = Convert.ToInt32(objclsJSData.PRJCTID);
                    objEntityDetails.JobId = Convert.ToInt32(objclsJSData.JOBID);
                    objEntityDetails.JobName = objclsJSData.JOBNAME.Trim();
                    objEntityDetails.JobMode = Convert.ToInt32(objclsJSData.JOBMODE);


                    objEntityWBDeatilsUPDATEDayList.Add(objEntityDetails);


                }


            }
            string strCanclDtlId = "";
            string[] strarrCancldtlIds = strCanclDtlId.Split(',');
            if (hiddenCanclDtlId.Value != "" && hiddenCanclDtlId.Value != null)
            {
                strCanclDtlId = hiddenCanclDtlId.Value;
                strarrCancldtlIds = strCanclDtlId.Split(',');

            }
            objBusinessDutyRoster.updateScheduleDetails(objEntityWBDeatilsINSERTDayList, objEntityWBDeatilsUPDATEDayList, strarrCancldtlIds);

            bindStatus();
            if (ddlEmployee.SelectedItem.Value == "--ALL EMPLOYEE--" && hiddenPrevious.Value == "0")
            {
                Response.Redirect("gen_Duty_Roster.aspx?InsUpd=InsShdl");
            }
            else if (hiddenPrevious.Value != "0")
            {
                string navigate = hiddenPrevious.Value + "," + hiddenNext.Value;

                Response.Redirect("gen_Duty_Roster.aspx?InsUpd=InsShdl&Navi=" + navigate);

            }

            else
            {
                string Id = ddlEmployee.SelectedItem.Value;
                Response.Redirect("gen_Duty_Roster.aspx?InsUpd=InsShdl&Srch=" + Id);
            }
        }
        else
        {

            List<clsEntityLayerJobScheduleDtl> objEntityWBDeatilsINSERTDayList = new List<clsEntityLayerJobScheduleDtl>();
            List<clsEntityLayerJobScheduleDtl> objEntityWBDeatilsUPDATEDayList = new List<clsEntityLayerJobScheduleDtl>();

            string jsonDataPW = HiddenField2.Value;
            string R1PW = jsonDataPW.Replace("\"{", "\\{");
            string R2PW = R1PW.Replace("\\n", "\r\n");
            string R3PW = R2PW.Replace("\\", "");
            string R4PW = R3PW.Replace("}\"]", "}]");
            string R5PW = R4PW.Replace("}\",", "},");
            List<clsJSData> objWBDataPWList = new List<clsJSData>();
            // UserData  data
            objWBDataPWList = JsonConvert.DeserializeObject<List<clsJSData>>(R5PW);


            foreach (clsJSData objclsJSData in objWBDataPWList)
            {
                if (objclsJSData.EVTACTION == "INS")
                {
                    clsEntityLayerJobScheduleDtl objEntityDetails = new clsEntityLayerJobScheduleDtl();
                    objEntityDetails.TimeSlotId = Convert.ToInt32(hiddenddlTimeSlotPWVal.Value);
                    objEntityDetails.SchdlWiseMode = 0;
                    string strFromDatetime = Convert.ToString("01-01-1000-" + objclsJSData.FROMTIME);
                    objEntityDetails.FromTime = objCommon.textWithTimeToDateTime(strFromDatetime);
                    string strToDatetime = Convert.ToString("01-01-1000-" + objclsJSData.TOTIME);
                    objEntityDetails.ToTime = objCommon.textWithTimeToDateTime(strToDatetime);
                    objEntityDetails.VhclId = Convert.ToInt32(objclsJSData.VHCLID);
                    objEntityDetails.PrjctId = Convert.ToInt32(objclsJSData.PRJCTID);
                    objEntityDetails.JobId = Convert.ToInt32(objclsJSData.JOBID);
                    objEntityDetails.JobName = objclsJSData.JOBNAME.Trim();
                    objEntityDetails.JobMode = Convert.ToInt32(objclsJSData.JOBMODE);
                    objEntityWBDeatilsINSERTDayList.Add(objEntityDetails);
                }
                else if (objclsJSData.EVTACTION == "UPD")
                {
                    clsEntityLayerJobScheduleDtl objEntityDetails = new clsEntityLayerJobScheduleDtl();
                    objEntityDetails.JobSchdlDtlId = Convert.ToInt32(objclsJSData.DTLID);

                    objEntityDetails.TimeSlotId = Convert.ToInt32(hiddenddlTimeSlotPWVal.Value);
                    objEntityDetails.SchdlWiseMode = 0;
                    string strFromDatetime = Convert.ToString("01-01-1000-" + objclsJSData.FROMTIME);
                    objEntityDetails.FromTime = objCommon.textWithTimeToDateTime(strFromDatetime);
                    string strToDatetime = Convert.ToString("01-01-1000-" + objclsJSData.TOTIME);
                    objEntityDetails.ToTime = objCommon.textWithTimeToDateTime(strToDatetime);
                    objEntityDetails.VhclId = Convert.ToInt32(objclsJSData.VHCLID);
                    objEntityDetails.PrjctId = Convert.ToInt32(objclsJSData.PRJCTID);
                    objEntityDetails.JobId = Convert.ToInt32(objclsJSData.JOBID);
                    objEntityDetails.JobName = objclsJSData.JOBNAME.Trim();
                    objEntityDetails.JobMode = Convert.ToInt32(objclsJSData.JOBMODE);


                    objEntityWBDeatilsUPDATEDayList.Add(objEntityDetails);


                }


            }
            string strCanclDtlId = "";
            string[] strarrCancldtlIds = strCanclDtlId.Split(',');
            if (hiddenCanclDtlId.Value != "" && hiddenCanclDtlId.Value != null)
            {
                strCanclDtlId = hiddenCanclDtlId.Value;
                strarrCancldtlIds = strCanclDtlId.Split(',');

            }
            objBusinessDutyRoster.insertScheduleDetails(objEntityDutyRoster, objEntityWBDeatilsINSERTDayList, objEntityWBDeatilsUPDATEDayList, strarrCancldtlIds);

            bindStatus();
            if (ddlEmployee.SelectedItem.Value == "--ALL EMPLOYEE--" && hiddenPrevious.Value == "0")
            {
                Response.Redirect("gen_Duty_Roster.aspx?InsUpd=InsShdl");
            }
            else if (hiddenPrevious.Value != "0")
            {
                string navigate = hiddenPrevious.Value + "," + hiddenNext.Value;

                Response.Redirect("gen_Duty_Roster.aspx?InsUpd=InsShdl&Navi=" + navigate);

            }

            else
            {
                string Id = ddlEmployee.SelectedItem.Value;
                Response.Redirect("gen_Duty_Roster.aspx?InsUpd=InsShdl&Srch=" + Id);
            }

        }
       
    }

    [WebMethod]
    public static void createDutySlip(int intCorpId, int intOrgId,int intLogUserId, string DatePass)
    {
        clsEntityLayerDutyRoster objEntityDutyRoster = new clsEntityLayerDutyRoster();
        clsBusinessLayerDutyRoster objBusinessDutyRoster = new clsBusinessLayerDutyRoster();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityDutyRoster.Corporate_id = intCorpId;
        objEntityDutyRoster.Organisation_id = intOrgId;
        DataTable dtEmployee = objBusinessDutyRoster.ReadEmployee(objEntityDutyRoster);
        foreach (DataRow Row in dtEmployee.Rows)
        {
           
            string strId = Row["USR_ID"].ToString();
            string strEmpName = Row["Employee"].ToString();
            objEntityDutyRoster.EmployeeId = Convert.ToInt32(strId);
            objEntityDutyRoster.FromDate = objCommon.textToDateTime(DatePass);
            DataTable dtJSDayWiseDtl = objBusinessDutyRoster.ReadJobShdlForDayEmp(objEntityDutyRoster);

            //To check data Already exist in th table
            string Count = objBusinessDutyRoster.CheckDutyRoster(objEntityDutyRoster);


            if (dtJSDayWiseDtl.Rows.Count > 0 && Count=="0")
            {
                //For dutyroster master table
                objEntityDutyRoster.Corporate_id = intCorpId;
                objEntityDutyRoster.Organisation_id = intOrgId;
                objEntityDutyRoster.User_Id = intLogUserId;
                objEntityDutyRoster.Date = System.DateTime.Now;
                objEntityDutyRoster.Status_id = 1;

                //For dutyroster details master table
                List<clsEntityLayerJobScheduleDtl> objEntityWBDeatilsINSERTDayList = new List<clsEntityLayerJobScheduleDtl>();
                List<clsEntityLayerJobScheduleDtl> objEntityWBDeatilsUPDATEDayList = new List<clsEntityLayerJobScheduleDtl>();
                foreach (DataRow Rowjs in dtJSDayWiseDtl.Rows)
                {
                    clsEntityLayerJobScheduleDtl objEntityDetails = new clsEntityLayerJobScheduleDtl();
                    objEntityDetails.TimeSlotId = Convert.ToInt32(Rowjs["TMSLT_ID"].ToString());
                    objEntityDetails.SchdlWiseMode = 0;
                    string strFromDatetime = Convert.ToString("01-01-1000-" + Rowjs["JOBSHDLDTL_FROM_TIME"].ToString());
                    objEntityDetails.FromTime = objCommon.textWithTimeToDateTime(strFromDatetime);
                    string strToDatetime = Convert.ToString("01-01-1000-" + Rowjs["JOBSHDLDTL_TO_TIME"].ToString());
                    objEntityDetails.ToTime = objCommon.textWithTimeToDateTime(strToDatetime);
                    objEntityDetails.VhclId = Convert.ToInt32(Rowjs["VHCL_ID"].ToString());
                    objEntityDetails.PrjctId = Convert.ToInt32(Rowjs["PROJECT_ID"].ToString());
                    objEntityDetails.JobId = Convert.ToInt32(Rowjs["JOBMSTR_ID"].ToString());
                    objEntityDetails.JobName = Rowjs["JOB_NAME"].ToString();
                    objEntityWBDeatilsINSERTDayList.Add(objEntityDetails);
                }
                string strCanclDtlId = "";
                string[] strarrCancldtlIds = strCanclDtlId.Split(',');
                objBusinessDutyRoster.insertScheduleDetails(objEntityDutyRoster, objEntityWBDeatilsINSERTDayList, objEntityWBDeatilsUPDATEDayList, strarrCancldtlIds);
            }

        }

        //Start:-EMP-0009
        objBusinessDutyRoster.UpdateDutySlipSts(objEntityDutyRoster);
        //End:-EMP-0009

    }
    [WebMethod]
    public static string DayWiseDutySlipCreateOrNot(int intCorpId, int intOrgId, string DatePass)
    {
        clsEntityLayerDutyRoster objEntityDutyRoster = new clsEntityLayerDutyRoster();
        clsBusinessLayerDutyRoster objBusinessDutyRoster = new clsBusinessLayerDutyRoster();
        string strJsonDW = "";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityDutyRoster.Organisation_id = intOrgId;
        objEntityDutyRoster.Corporate_id = intCorpId;
        objEntityDutyRoster.FromDate = objCommon.textToDateTime(DatePass);

        DataTable dt = objBusinessDutyRoster.ReadDutyslipCreateOrNOt(objEntityDutyRoster);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0][2].ToString() == "1")
            {
                strJsonDW = "true";
            }
            else
            {
                strJsonDW = "false";
            }
        }
        else
        {
            strJsonDW = "false";
        }

        return strJsonDW;
    }
    
    //For reading dutyslip details of a employee daywise
    [WebMethod]
    public static string[] DayWiseDutySlipDtl(int intCorpId, int intOrgId, int EmpId, string DatePass)
    {

        clsEntityLayerDutyRoster objEntityDutyRoster = new clsEntityLayerDutyRoster();
        clsBusinessLayerDutyRoster objBusinessDutyRoster = new clsBusinessLayerDutyRoster();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityDutyRoster.Organisation_id = intOrgId;
        objEntityDutyRoster.Corporate_id = intCorpId;
        objEntityDutyRoster.FromDate = objCommon.textToDateTime(DatePass);
        objEntityDutyRoster.EmployeeId = EmpId;


        DataTable dt = objBusinessDutyRoster.ReadDutyslipDtl(objEntityDutyRoster);

        string[] strJsonDW = new string[5];
        if (dt.Rows.Count > 0)
        {
            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("TransId", typeof(int));
            dtDetail.Columns.Add("TransDtlId", typeof(int));
            dtDetail.Columns.Add("JobName", typeof(string));
            dtDetail.Columns.Add("JobId", typeof(int));
            dtDetail.Columns.Add("VhclNumbr", typeof(string));
            dtDetail.Columns.Add("VhclId", typeof(int));
            dtDetail.Columns.Add("PrjctName", typeof(string));
            dtDetail.Columns.Add("PrjctId", typeof(int));
            dtDetail.Columns.Add("FromTime", typeof(string));
            dtDetail.Columns.Add("ToTime", typeof(string));
            dtDetail.Columns.Add("txtJobName", typeof(string));

            for (int intcnt = 0; intcnt < dt.Rows.Count; intcnt++)
            {
                DataRow drDtl = dtDetail.NewRow();
                drDtl["TransId"] = Convert.ToInt32(dt.Rows[intcnt]["DUTYGNRTN_ID"].ToString());
                drDtl["TransDtlId"] = Convert.ToInt32(dt.Rows[intcnt]["DUTYGNRTNDTL_ID"].ToString());
                drDtl["JobName"] = dt.Rows[intcnt]["JOBMSTR_TITLE"].ToString();
                if (dt.Rows[intcnt]["JOBMSTR_ID"].ToString() != "")
                {
                    drDtl["JobId"] = Convert.ToInt32(dt.Rows[intcnt]["JOBMSTR_ID"].ToString());

                }
                else
                {
                    drDtl["JobId"] = 0;
                }

                drDtl["VhclNumbr"] = dt.Rows[intcnt]["VHCL_NUMBR"].ToString();
                drDtl["VhclId"] = Convert.ToInt32(dt.Rows[intcnt]["VHCL_ID"].ToString());
                drDtl["PrjctName"] = dt.Rows[intcnt]["PROJECT_NAME"].ToString();
                drDtl["PrjctId"] = Convert.ToInt32(dt.Rows[intcnt]["PROJECT_ID"].ToString());
                drDtl["FromTime"] = dt.Rows[intcnt]["DUTYGNRT_FROM_TIME"].ToString();
                drDtl["ToTime"] = dt.Rows[intcnt]["DUTYGNRT_TO_TIME"].ToString();
                drDtl["txtJobName"] = dt.Rows[intcnt]["JOB_NAME"].ToString();
                dtDetail.Rows.Add(drDtl);
            }
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dtDetail.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dtDetail.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);

                }

                parentRow.Add(childRow);
            }

            strJsonDW[0] = jsSerializer.Serialize(parentRow);
        }

        //To check jobs already submitted for an employee for a particular date
        string Count = objBusinessDutyRoster.CheckDutySlpSubmsnSts(objEntityDutyRoster);

        if (Count != "0")
        {
            //To read time sheet details of job submission
            DataTable dtSbmsTimesheet = objBusinessDutyRoster.ReadDutySlipSbmsnTimesheetDtl(objEntityDutyRoster);
            objEntityDutyRoster.SubmissionId = Convert.ToInt32(dtSbmsTimesheet.Rows[0]["DUTYSUBMTN_ID"].ToString());
            //To read job submission details
            DataTable dtJobSbmsnDtls = objBusinessDutyRoster.ReadDutySlipSbmsnDtl(objEntityDutyRoster);
            //To read additional job details
            DataTable dtSbmsnAddtnlJobDtls = objBusinessDutyRoster.ReadDutySlipSbmsnAddtnlJobDtl(objEntityDutyRoster);

            //For timesheet details
            if (dtSbmsTimesheet.Rows.Count > 0)
            {
                DataTable dtDetailTS = new DataTable();
                dtDetailTS.Columns.Add("TransId", typeof(int));
                dtDetailTS.Columns.Add("FromTime", typeof(string));
                dtDetailTS.Columns.Add("ToTime", typeof(string));
                dtDetailTS.Columns.Add("TotalWrkHr", typeof(decimal));
                dtDetailTS.Columns.Add("NrmlWrkHr", typeof(decimal));
                dtDetailTS.Columns.Add("IdleHr", typeof(string));
                dtDetailTS.Columns.Add("FinalOT", typeof(string));
                dtDetailTS.Columns.Add("RoundedOT", typeof(string));
                dtDetailTS.Columns.Add("CnfrmStsId", typeof(int));

                DataRow drDtl = dtDetailTS.NewRow();
                drDtl["TransId"] = Convert.ToInt32(dtSbmsTimesheet.Rows[0]["DUTYSUBMTN_ID"].ToString());
                drDtl["FromTime"] = dtSbmsTimesheet.Rows[0]["TS_FROM_TIME"].ToString();
                drDtl["ToTime"] = dtSbmsTimesheet.Rows[0]["TS_END_TIME"].ToString();
                drDtl["TotalWrkHr"] = Convert.ToDecimal(dtSbmsTimesheet.Rows[0]["DUTYSUBMTN_TS_TOTAL_WRKHR"].ToString());
                drDtl["NrmlWrkHr"] = Convert.ToDecimal(dtSbmsTimesheet.Rows[0]["DUTYSUBMTN_TS_NORML_WRKHR"].ToString());
                drDtl["IdleHr"] = dtSbmsTimesheet.Rows[0]["DUTYSUBMTN_TS_IDEAL_HR"].ToString();
                drDtl["FinalOT"] = dtSbmsTimesheet.Rows[0]["DUTYSUBMTN_TS_FINL_OT"].ToString();
                drDtl["RoundedOT"] = dtSbmsTimesheet.Rows[0]["DUTYSUBMTN_TS_ROUNDED_OT"].ToString();
                drDtl["CnfrmStsId"] = Convert.ToInt32(dtSbmsTimesheet.Rows[0]["DUTYSUBMTN_CNFRM_STS"].ToString());

                dtDetailTS.Rows.Add(drDtl);


                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
                Dictionary<string, object> childRow;
                foreach (DataRow row in dtDetailTS.Rows)
                {
                    childRow = new Dictionary<string, object>();
                    foreach (DataColumn col in dtDetailTS.Columns)
                    {
                        childRow.Add(col.ColumnName, row[col]);

                    }

                    parentRow.Add(childRow);
                }

                strJsonDW[1] = jsSerializer.Serialize(parentRow);

            }

            //For job submission details
            if (dtJobSbmsnDtls.Rows.Count > 0)
            {
                DataTable dtDetailJS = new DataTable();
                dtDetailJS.Columns.Add("TransId", typeof(int));
                dtDetailJS.Columns.Add("TransDtlId", typeof(int));
                dtDetailJS.Columns.Add("FromTime", typeof(string));
                dtDetailJS.Columns.Add("ToTime", typeof(string));
                dtDetailJS.Columns.Add("SbmsnStsId", typeof(int));
                dtDetailJS.Columns.Add("SbmsnStsName", typeof(string));
                dtDetailJS.Columns.Add("SbmsnStsActve", typeof(int));
                dtDetailJS.Columns.Add("VhclId", typeof(int));
                dtDetailJS.Columns.Add("VhclPrsntMlg", typeof(int));
                dtDetailJS.Columns.Add("Desc", typeof(string));


                for (int intcnt = 0; intcnt < dtJobSbmsnDtls.Rows.Count; intcnt++)
                {
                    DataRow drDtl = dtDetailJS.NewRow();
                    drDtl["TransId"] = Convert.ToInt32(dtJobSbmsnDtls.Rows[intcnt]["DUTYSUBMTN_ID"].ToString());
                    drDtl["TransDtlId"] = Convert.ToInt32(dtJobSbmsnDtls.Rows[intcnt]["DUTYSUBMTNDTL_ID"].ToString());
                    drDtl["FromTime"] = dtJobSbmsnDtls.Rows[intcnt]["JS_FROM_TIME"].ToString();
                    drDtl["ToTime"] = dtJobSbmsnDtls.Rows[intcnt]["JS_END_TIME"].ToString();
                    drDtl["SbmsnStsId"] = Convert.ToInt32(dtJobSbmsnDtls.Rows[intcnt]["SUBMTNSTS_ID"].ToString());
                    drDtl["SbmsnStsName"] = dtJobSbmsnDtls.Rows[intcnt]["SUBMTNSTS_NAME"].ToString();
                    drDtl["SbmsnStsActve"] = Convert.ToInt32(dtJobSbmsnDtls.Rows[intcnt]["SUBMTNSTS_STATUS"].ToString());
                    drDtl["VhclId"] = Convert.ToInt32(dtJobSbmsnDtls.Rows[intcnt]["VHCL_ID"].ToString());
                    drDtl["VhclPrsntMlg"] = Convert.ToInt32(dtJobSbmsnDtls.Rows[intcnt]["VHCL_PRSNT_MILEAGE"].ToString());
                    drDtl["Desc"] = dtJobSbmsnDtls.Rows[intcnt]["DUTYSUBMTNDTL_DESC"].ToString();
                    dtDetailJS.Rows.Add(drDtl);
                }
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
                Dictionary<string, object> childRow;
                foreach (DataRow row in dtDetailJS.Rows)
                {
                    childRow = new Dictionary<string, object>();
                    foreach (DataColumn col in dtDetailJS.Columns)
                    {
                        childRow.Add(col.ColumnName, row[col]);

                    }

                    parentRow.Add(childRow);
                }

                strJsonDW[2] = jsSerializer.Serialize(parentRow);
            }

            if (dtSbmsnAddtnlJobDtls.Rows.Count > 0)
            {
                DataTable dtDetailAJ = new DataTable();
                dtDetailAJ.Columns.Add("TransId", typeof(int));
                dtDetailAJ.Columns.Add("TransDtlId", typeof(int));
                dtDetailAJ.Columns.Add("JobName", typeof(string));
                dtDetailAJ.Columns.Add("JobId", typeof(int));
                dtDetailAJ.Columns.Add("VhclNumbr", typeof(string));
                dtDetailAJ.Columns.Add("VhclId", typeof(int));
                dtDetailAJ.Columns.Add("FromTime", typeof(string));
                dtDetailAJ.Columns.Add("ToTime", typeof(string));
                dtDetailAJ.Columns.Add("txtJobName", typeof(string));

                for (int intcnt = 0; intcnt < dtSbmsnAddtnlJobDtls.Rows.Count; intcnt++)
                {
                    DataRow drDtl = dtDetailAJ.NewRow();
                    drDtl["TransId"] = Convert.ToInt32(dtSbmsnAddtnlJobDtls.Rows[intcnt]["DUTYSUBMTN_ID"].ToString());
                    drDtl["TransDtlId"] = Convert.ToInt32(dtSbmsnAddtnlJobDtls.Rows[intcnt]["DUTYSUBADDJOB_ID"].ToString());
                    drDtl["JobName"] = dtSbmsnAddtnlJobDtls.Rows[intcnt]["JOBMSTR_TITLE"].ToString();
                    if (dtSbmsnAddtnlJobDtls.Rows[intcnt]["JOBMSTR_ID"].ToString() != "")
                    {
                        drDtl["JobId"] = Convert.ToInt32(dtSbmsnAddtnlJobDtls.Rows[intcnt]["JOBMSTR_ID"].ToString());

                    }
                    else
                    {
                        drDtl["JobId"] = 0;
                    }

                    drDtl["VhclNumbr"] = dtSbmsnAddtnlJobDtls.Rows[intcnt]["VHCL_NUMBR"].ToString();
                    drDtl["VhclId"] = Convert.ToInt32(dtSbmsnAddtnlJobDtls.Rows[intcnt]["VHCL_ID"].ToString());
                    drDtl["FromTime"] = dtSbmsnAddtnlJobDtls.Rows[intcnt]["AJ_FROM_TIME"].ToString();
                    drDtl["ToTime"] = dtSbmsnAddtnlJobDtls.Rows[intcnt]["AJ_END_TIME"].ToString();
                    drDtl["txtJobName"] = dtSbmsnAddtnlJobDtls.Rows[intcnt]["JOB_NAME"].ToString();
                    dtDetailAJ.Rows.Add(drDtl);
                }
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
                Dictionary<string, object> childRow;
                foreach (DataRow row in dtDetailAJ.Rows)
                {
                    childRow = new Dictionary<string, object>();
                    foreach (DataColumn col in dtDetailAJ.Columns)
                    {
                        childRow.Add(col.ColumnName, row[col]);

                    }

                    parentRow.Add(childRow);
                }

                strJsonDW[3] = jsSerializer.Serialize(parentRow);

            }
        }


        return strJsonDW;

    }
    public class clsTimeSheetData
    {
        public string FROMTIME { get; set; }
        public string TOTIME { get; set; }
        public string TOTALWRKHR { get; set; }
        public string NORMALWRKHR { get; set; }
        public string IDLEHR { get; set; }
        public string TOTALOT { get; set; }
        public string ROUNDEDOT { get; set; }
    }
    public class clsJobSbmsnData
    {
        public string DUTYDTLID { get; set; }
        public string FROMTIME { get; set; }
        public string TOTIME { get; set; }
        public string SUBMSNSTS { get; set; }
        public string VHCLID { get; set; }
        public string PRSNTMLG { get; set; }
        public string DESC { get; set; }
       
    }
    protected void btnSubSave_Click(object sender, EventArgs e)
    {
        clsEntityLayerDutyRoster objEntityDutyRoster = new clsEntityLayerDutyRoster();
        clsBusinessLayerDutyRoster objBusinessDutyRoster = new clsBusinessLayerDutyRoster();
        clsCommonLibrary objCommon = new clsCommonLibrary();
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
        if (Session["USERID"] != null)
        {
            objEntityDutyRoster.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        //For duty submission master table
        objEntityDutyRoster.Date = System.DateTime.Now;
        objEntityDutyRoster.DutyRosterId = Convert.ToInt32(HiddenFieldDutyRostrId.Value);
        objEntityDutyRoster.EmployeeId = Convert.ToInt32(HiddenFieldEmployeeId.Value);
        //Start:-To check wheather the details added or updated
        objEntityDutyRoster.FromDate = objCommon.textToDateTime(HiddenFieldDate.Value);
        string Count = objBusinessDutyRoster.CheckDutySlpSubmsnSts(objEntityDutyRoster);
        //End:-To check wheather the details added or updated
        objEntityDutyRoster.SubmissionDate = objCommon.textToDateTime(HiddenFieldDate.Value);
        string jsonDataPW = HiddenFieldTimeSheet.Value;
        string R1PW = jsonDataPW.Replace("\"{", "\\{");
        string R2PW = R1PW.Replace("\\n", "\r\n");
        string R3PW = R2PW.Replace("\\", "");
        string R4PW = R3PW.Replace("}\"]", "}]");
        string R5PW = R4PW.Replace("}\",", "},");
        List<clsTimeSheetData> objWBDataPWList2 = new List<clsTimeSheetData>();
        objWBDataPWList2 = JsonConvert.DeserializeObject<List<clsTimeSheetData>>(R5PW);
        foreach (clsTimeSheetData objClsTimeSheetData in objWBDataPWList2)
        {
            if (objClsTimeSheetData.FROMTIME.ToString() != "")
            {
                objEntityDutyRoster.FromDate = objCommon.textWithTimeToDateTime(objClsTimeSheetData.FROMTIME);
                objEntityDutyRoster.ToDate = objCommon.textWithTimeToDateTime(objClsTimeSheetData.TOTIME);
                objEntityDutyRoster.TotalWrkHr = Convert.ToDecimal(objClsTimeSheetData.TOTALWRKHR);
                objEntityDutyRoster.NormalWrkHr = Convert.ToDecimal(objClsTimeSheetData.NORMALWRKHR);
                if (objClsTimeSheetData.IDLEHR.ToString() != "")
                {
                    objEntityDutyRoster.IdleHr = Convert.ToDecimal(objClsTimeSheetData.IDLEHR);
                }
                if (objClsTimeSheetData.TOTALOT.ToString() != "")
                {
                    objEntityDutyRoster.FinalOT = Convert.ToDecimal(objClsTimeSheetData.TOTALOT);
                }
                if (objClsTimeSheetData.ROUNDEDOT.ToString() != "")
                {
                    objEntityDutyRoster.RoundedOT = Convert.ToDecimal(objClsTimeSheetData.ROUNDEDOT);
                }
            }
        }
        //For duty submission detail table
        List<clsEntityLayerSubmissionDtl> objEntityJobSubmsnDtlList = new List<clsEntityLayerSubmissionDtl>();
        jsonDataPW = HiddenFieldJobSbmsnDtls.Value;
        R1PW = jsonDataPW.Replace("\"{", "\\{");
        R2PW = R1PW.Replace("\\n", "\r\n");
        R3PW = R2PW.Replace("\\", "");
        R4PW = R3PW.Replace("}\"]", "}]");
        R5PW = R4PW.Replace("}\",", "},");
        List<clsJobSbmsnData> objWBDataPWList = new List<clsJobSbmsnData>();
        // UserData  data
        objWBDataPWList = JsonConvert.DeserializeObject<List<clsJobSbmsnData>>(R5PW);
        foreach (clsJobSbmsnData objclsJSData in objWBDataPWList)
        {
            if (objclsJSData.FROMTIME.ToString() != "")
            {
                clsEntityLayerSubmissionDtl objEntityDetails = new clsEntityLayerSubmissionDtl();
                objEntityDetails.DutyRosterDtlId = Convert.ToInt32(objclsJSData.DUTYDTLID);
                objEntityDetails.FromDate = objCommon.textWithTimeToDateTime(objclsJSData.FROMTIME);
                objEntityDetails.ToDate = objCommon.textWithTimeToDateTime(objclsJSData.TOTIME);
                objEntityDetails.SubmissionStsId = Convert.ToInt32(objclsJSData.SUBMSNSTS); ;
                objEntityDetails.VehiclleId = Convert.ToInt32(objclsJSData.VHCLID);
                objEntityDetails.VhclPrsntMlg = Convert.ToInt32(objclsJSData.PRSNTMLG);
                objEntityDetails.SubmsnDtlDesc = objclsJSData.DESC.Trim();
                objEntityJobSubmsnDtlList.Add(objEntityDetails);
            }
        }




        //For additional jobs table
        List<clsEntityLayerJobScheduleDtl> objEntityAddtnlJobsList = new List<clsEntityLayerJobScheduleDtl>();
        jsonDataPW = HiddenFieldAddtnlJobs.Value;
        R1PW = jsonDataPW.Replace("\"{", "\\{");
        R2PW = R1PW.Replace("\\n", "\r\n");
        R3PW = R2PW.Replace("\\", "");
        R4PW = R3PW.Replace("}\"]", "}]");
        R5PW = R4PW.Replace("}\",", "},");
        List<clsJSData> objWBDataPWList1 = new List<clsJSData>();
        // UserData  data
        if (HiddenFieldAddtnlJobs.Value != null && HiddenFieldAddtnlJobs.Value != "")
        {
            objWBDataPWList1 = JsonConvert.DeserializeObject<List<clsJSData>>(R5PW);
            foreach (clsJSData objclsJSData in objWBDataPWList1)
            {
                if (objclsJSData.FROMTIME.ToString() != "" && objclsJSData.TOTIME.ToString() != "" && objclsJSData.VHCLID.ToString() != "" && objclsJSData.JOBID.ToString() != "" && objclsJSData.JOBNAME.ToString() != "")
                {
                    clsEntityLayerJobScheduleDtl objEntityDetails = new clsEntityLayerJobScheduleDtl();
                    objEntityDetails.FromTime = objCommon.textWithTimeToDateTime(objclsJSData.FROMTIME);
                    objEntityDetails.ToTime = objCommon.textWithTimeToDateTime(objclsJSData.TOTIME);
                    objEntityDetails.VhclId = Convert.ToInt32(objclsJSData.VHCLID);
                    objEntityDetails.JobId = Convert.ToInt32(objclsJSData.JOBID);
                    objEntityDetails.JobName = objclsJSData.JOBNAME.Trim();
                    objEntityAddtnlJobsList.Add(objEntityDetails);
                }

            }
        }
        //Start:-update
        if (Count != "0")
        {
            objEntityDutyRoster.SubmissionId = Convert.ToInt32(HiddenFieldSubmissionId.Value);

            List<clsEntityLayerJobScheduleDtl> objEntityAddtnlJobsListUpdate = new List<clsEntityLayerJobScheduleDtl>();
            List<clsEntityLayerJobScheduleDtl> objEntityAddtnlJobsListAdd = new List<clsEntityLayerJobScheduleDtl>();
            jsonDataPW = HiddenFieldAddtnlJobs.Value;
            R1PW = jsonDataPW.Replace("\"{", "\\{");
            R2PW = R1PW.Replace("\\n", "\r\n");
            R3PW = R2PW.Replace("\\", "");
            R4PW = R3PW.Replace("}\"]", "}]");
            R5PW = R4PW.Replace("}\",", "},");
            List<clsJSData> objWBDataPWList4 = new List<clsJSData>();
            // UserData  data
            if (HiddenFieldAddtnlJobs.Value != null && HiddenFieldAddtnlJobs.Value != "")
            {
                objWBDataPWList4 = JsonConvert.DeserializeObject<List<clsJSData>>(R5PW);
                foreach (clsJSData objclsJSData in objWBDataPWList4)
                {
                    if (objclsJSData.EVTACTION == "INS")
                    {
                        if (objclsJSData.FROMTIME.ToString() != "" && objclsJSData.TOTIME.ToString() != "" && objclsJSData.VHCLID.ToString() != "" && objclsJSData.JOBID.ToString() != "" && objclsJSData.JOBNAME.ToString() != "")
                        {
                            clsEntityLayerJobScheduleDtl objEntityDetails = new clsEntityLayerJobScheduleDtl();
                            objEntityDetails.FromTime = objCommon.textWithTimeToDateTime(objclsJSData.FROMTIME);
                            objEntityDetails.ToTime = objCommon.textWithTimeToDateTime(objclsJSData.TOTIME);
                            objEntityDetails.VhclId = Convert.ToInt32(objclsJSData.VHCLID);
                            objEntityDetails.JobId = Convert.ToInt32(objclsJSData.JOBID);
                            objEntityDetails.JobName = objclsJSData.JOBNAME.Trim();
                            objEntityAddtnlJobsListAdd.Add(objEntityDetails);
                        }
                    }
                    else if (objclsJSData.EVTACTION == "UPD")
                    {
                        if (objclsJSData.FROMTIME.ToString() != "" && objclsJSData.TOTIME.ToString() != "" && objclsJSData.VHCLID.ToString() != "" && objclsJSData.JOBID.ToString() != "" && objclsJSData.JOBNAME.ToString() != "")
                        {
                            clsEntityLayerJobScheduleDtl objEntityDetails = new clsEntityLayerJobScheduleDtl();
                            objEntityDetails.JobSchdlDtlId = Convert.ToInt32(objclsJSData.DTLID);
                            objEntityDetails.FromTime = objCommon.textWithTimeToDateTime(objclsJSData.FROMTIME);
                            objEntityDetails.ToTime = objCommon.textWithTimeToDateTime(objclsJSData.TOTIME);
                            objEntityDetails.VhclId = Convert.ToInt32(objclsJSData.VHCLID);
                            objEntityDetails.JobId = Convert.ToInt32(objclsJSData.JOBID);
                            objEntityDetails.JobName = objclsJSData.JOBNAME.Trim();
                            objEntityAddtnlJobsListUpdate.Add(objEntityDetails);
                        }

                    }
                }
            }

            //For deleted additional jobs
            string strCanclDtlId = "";
            string[] strarrCancldtlIds = strCanclDtlId.Split(',');
            if (HiddenFieldCancelAddtnJobDtlId.Value != "" && HiddenFieldCancelAddtnJobDtlId.Value != null)
            {
                strCanclDtlId = HiddenFieldCancelAddtnJobDtlId.Value;
                strarrCancldtlIds = strCanclDtlId.Split(',');

            }

            objBusinessDutyRoster.updateJobSbmsnDetails(objEntityDutyRoster, objEntityJobSubmsnDtlList, objEntityAddtnlJobsListAdd, objEntityAddtnlJobsListUpdate, strarrCancldtlIds);
        }
        //End:-Update
        else
        {
            objBusinessDutyRoster.insertJobSbmsnDetails(objEntityDutyRoster, objEntityJobSubmsnDtlList, objEntityAddtnlJobsList);
        }
        bindStatus();
        Response.Redirect("gen_Duty_Roster.aspx?InsUpd=InsSubmsn");
    }
    protected void btnSubConfirm_Click(object sender, EventArgs e)
    {
        clsEntityLayerDutyRoster objEntityDutyRoster = new clsEntityLayerDutyRoster();
        clsBusinessLayerDutyRoster objBusinessDutyRoster = new clsBusinessLayerDutyRoster();
        clsCommonLibrary objCommon = new clsCommonLibrary();
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
        if (Session["USERID"] != null)
        {
            objEntityDutyRoster.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        //For duty submission master table
        objEntityDutyRoster.Date = System.DateTime.Now;
        objEntityDutyRoster.DutyRosterId = Convert.ToInt32(HiddenFieldDutyRostrId.Value);
        objEntityDutyRoster.EmployeeId = Convert.ToInt32(HiddenFieldEmployeeId.Value);
        //Start:-To check wheather the details added or updated
        objEntityDutyRoster.FromDate = objCommon.textToDateTime(HiddenFieldDate.Value);
        string Count = objBusinessDutyRoster.CheckDutySlpSubmsnSts(objEntityDutyRoster);
        //End:-To check wheather the details added or updated
        objEntityDutyRoster.SubmissionDate = objCommon.textToDateTime(HiddenFieldDate.Value);
        string jsonDataPW = HiddenFieldTimeSheet.Value;
        string R1PW = jsonDataPW.Replace("\"{", "\\{");
        string R2PW = R1PW.Replace("\\n", "\r\n");
        string R3PW = R2PW.Replace("\\", "");
        string R4PW = R3PW.Replace("}\"]", "}]");
        string R5PW = R4PW.Replace("}\",", "},");
        List<clsTimeSheetData> objWBDataPWList2 = new List<clsTimeSheetData>();
        objWBDataPWList2 = JsonConvert.DeserializeObject<List<clsTimeSheetData>>(R5PW);
        foreach (clsTimeSheetData objClsTimeSheetData in objWBDataPWList2)
        {
            if (objClsTimeSheetData.FROMTIME.ToString() != "")
            {
                objEntityDutyRoster.FromDate = objCommon.textWithTimeToDateTime(objClsTimeSheetData.FROMTIME);
                objEntityDutyRoster.ToDate = objCommon.textWithTimeToDateTime(objClsTimeSheetData.TOTIME);
                objEntityDutyRoster.TotalWrkHr = Convert.ToDecimal(objClsTimeSheetData.TOTALWRKHR);
                objEntityDutyRoster.NormalWrkHr = Convert.ToDecimal(objClsTimeSheetData.NORMALWRKHR);
                if (objClsTimeSheetData.IDLEHR.ToString() != "")
                {
                    objEntityDutyRoster.IdleHr = Convert.ToDecimal(objClsTimeSheetData.IDLEHR);
                }
                if (objClsTimeSheetData.TOTALOT.ToString() != "")
                {
                    objEntityDutyRoster.FinalOT = Convert.ToDecimal(objClsTimeSheetData.TOTALOT);
                }
                if (objClsTimeSheetData.ROUNDEDOT.ToString() != "")
                {
                    objEntityDutyRoster.RoundedOT = Convert.ToDecimal(objClsTimeSheetData.ROUNDEDOT);
                }
            }
        }
        //For duty submission detail table
        List<clsEntityLayerSubmissionDtl> objEntityJobSubmsnDtlList = new List<clsEntityLayerSubmissionDtl>();
        jsonDataPW = HiddenFieldJobSbmsnDtls.Value;
        R1PW = jsonDataPW.Replace("\"{", "\\{");
        R2PW = R1PW.Replace("\\n", "\r\n");
        R3PW = R2PW.Replace("\\", "");
        R4PW = R3PW.Replace("}\"]", "}]");
        R5PW = R4PW.Replace("}\",", "},");
        List<clsJobSbmsnData> objWBDataPWList = new List<clsJobSbmsnData>();
        // UserData  data
        objWBDataPWList = JsonConvert.DeserializeObject<List<clsJobSbmsnData>>(R5PW);
        foreach (clsJobSbmsnData objclsJSData in objWBDataPWList)
        {
            if (objclsJSData.FROMTIME.ToString() != "")
            {
                clsEntityLayerSubmissionDtl objEntityDetails = new clsEntityLayerSubmissionDtl();
                objEntityDetails.DutyRosterDtlId = Convert.ToInt32(objclsJSData.DUTYDTLID);
                objEntityDetails.FromDate = objCommon.textWithTimeToDateTime(objclsJSData.FROMTIME);
                objEntityDetails.ToDate = objCommon.textWithTimeToDateTime(objclsJSData.TOTIME);
                objEntityDetails.SubmissionStsId = Convert.ToInt32(objclsJSData.SUBMSNSTS); ;
                objEntityDetails.VehiclleId = Convert.ToInt32(objclsJSData.VHCLID);
                objEntityDetails.VhclPrsntMlg = Convert.ToInt32(objclsJSData.PRSNTMLG);
                objEntityDetails.SubmsnDtlDesc = objclsJSData.DESC.Trim();
                objEntityJobSubmsnDtlList.Add(objEntityDetails);
            }
        }




        //For additional jobs table
        List<clsEntityLayerJobScheduleDtl> objEntityAddtnlJobsList = new List<clsEntityLayerJobScheduleDtl>();
        jsonDataPW = HiddenFieldAddtnlJobs.Value;
        R1PW = jsonDataPW.Replace("\"{", "\\{");
        R2PW = R1PW.Replace("\\n", "\r\n");
        R3PW = R2PW.Replace("\\", "");
        R4PW = R3PW.Replace("}\"]", "}]");
        R5PW = R4PW.Replace("}\",", "},");
        List<clsJSData> objWBDataPWList1 = new List<clsJSData>();
        // UserData  data
        if (HiddenFieldAddtnlJobs.Value != null && HiddenFieldAddtnlJobs.Value != "")
        {
            objWBDataPWList1 = JsonConvert.DeserializeObject<List<clsJSData>>(R5PW);
            foreach (clsJSData objclsJSData in objWBDataPWList1)
            {
                if (objclsJSData.FROMTIME.ToString() != "" && objclsJSData.TOTIME.ToString() != "" && objclsJSData.VHCLID.ToString() != "" && objclsJSData.JOBID.ToString() != "" && objclsJSData.JOBNAME.ToString() != "")
                {
                    clsEntityLayerJobScheduleDtl objEntityDetails = new clsEntityLayerJobScheduleDtl();
                    objEntityDetails.FromTime = objCommon.textWithTimeToDateTime(objclsJSData.FROMTIME);
                    objEntityDetails.ToTime = objCommon.textWithTimeToDateTime(objclsJSData.TOTIME);
                    objEntityDetails.VhclId = Convert.ToInt32(objclsJSData.VHCLID);
                    objEntityDetails.JobId = Convert.ToInt32(objclsJSData.JOBID);
                    objEntityDetails.JobName = objclsJSData.JOBNAME.Trim();
                    objEntityAddtnlJobsList.Add(objEntityDetails);
                }

            }
        }
        //Start:-update
        if (Count != "0")
        {
            objEntityDutyRoster.SubmissionId = Convert.ToInt32(HiddenFieldSubmissionId.Value);

            List<clsEntityLayerJobScheduleDtl> objEntityAddtnlJobsListUpdate = new List<clsEntityLayerJobScheduleDtl>();
            List<clsEntityLayerJobScheduleDtl> objEntityAddtnlJobsListAdd = new List<clsEntityLayerJobScheduleDtl>();
            jsonDataPW = HiddenFieldAddtnlJobs.Value;
            R1PW = jsonDataPW.Replace("\"{", "\\{");
            R2PW = R1PW.Replace("\\n", "\r\n");
            R3PW = R2PW.Replace("\\", "");
            R4PW = R3PW.Replace("}\"]", "}]");
            R5PW = R4PW.Replace("}\",", "},");
            List<clsJSData> objWBDataPWList4 = new List<clsJSData>();
            // UserData  data
            if (HiddenFieldAddtnlJobs.Value != null && HiddenFieldAddtnlJobs.Value != "")
            {
                objWBDataPWList4 = JsonConvert.DeserializeObject<List<clsJSData>>(R5PW);
                foreach (clsJSData objclsJSData in objWBDataPWList4)
                {
                    if (objclsJSData.EVTACTION == "INS")
                    {
                        if (objclsJSData.FROMTIME.ToString() != "" && objclsJSData.TOTIME.ToString() != "" && objclsJSData.VHCLID.ToString() != "" && objclsJSData.JOBID.ToString() != "" && objclsJSData.JOBNAME.ToString() != "")
                        {
                            clsEntityLayerJobScheduleDtl objEntityDetails = new clsEntityLayerJobScheduleDtl();
                            objEntityDetails.FromTime = objCommon.textWithTimeToDateTime(objclsJSData.FROMTIME);
                            objEntityDetails.ToTime = objCommon.textWithTimeToDateTime(objclsJSData.TOTIME);
                            objEntityDetails.VhclId = Convert.ToInt32(objclsJSData.VHCLID);
                            objEntityDetails.JobId = Convert.ToInt32(objclsJSData.JOBID);
                            objEntityDetails.JobName = objclsJSData.JOBNAME.Trim();
                            objEntityAddtnlJobsListAdd.Add(objEntityDetails);
                        }
                    }
                    else if (objclsJSData.EVTACTION == "UPD")
                    {
                        if (objclsJSData.FROMTIME.ToString() != "" && objclsJSData.TOTIME.ToString() != "" && objclsJSData.VHCLID.ToString() != "" && objclsJSData.JOBID.ToString() != "" && objclsJSData.JOBNAME.ToString() != "")
                        {
                            clsEntityLayerJobScheduleDtl objEntityDetails = new clsEntityLayerJobScheduleDtl();
                            objEntityDetails.JobSchdlDtlId = Convert.ToInt32(objclsJSData.DTLID);
                            objEntityDetails.FromTime = objCommon.textWithTimeToDateTime(objclsJSData.FROMTIME);
                            objEntityDetails.ToTime = objCommon.textWithTimeToDateTime(objclsJSData.TOTIME);
                            objEntityDetails.VhclId = Convert.ToInt32(objclsJSData.VHCLID);
                            objEntityDetails.JobId = Convert.ToInt32(objclsJSData.JOBID);
                            objEntityDetails.JobName = objclsJSData.JOBNAME.Trim();
                            objEntityAddtnlJobsListUpdate.Add(objEntityDetails);
                        }

                    }
                }
            }

            //For deleted additional jobs
            string strCanclDtlId = "";
            string[] strarrCancldtlIds = strCanclDtlId.Split(',');
            if (HiddenFieldCancelAddtnJobDtlId.Value != "" && HiddenFieldCancelAddtnJobDtlId.Value != null)
            {
                strCanclDtlId = HiddenFieldCancelAddtnJobDtlId.Value;
                strarrCancldtlIds = strCanclDtlId.Split(',');

            }

            objBusinessDutyRoster.updateJobSbmsnDetails(objEntityDutyRoster, objEntityJobSubmsnDtlList, objEntityAddtnlJobsListAdd, objEntityAddtnlJobsListUpdate, strarrCancldtlIds);
        }



        //For duty submission master table
        objEntityDutyRoster.Date = System.DateTime.Now;
        objEntityDutyRoster.CnfrmStsId = 1;
        objEntityDutyRoster.SubmissionId = Convert.ToInt32(HiddenFieldSubmissionId.Value);
        objBusinessDutyRoster.confirmSubmision(objEntityDutyRoster);
        //For Update present mileage of vehicles
        DataTable dtVhcl = objBusinessDutyRoster.readVhclDetails(objEntityDutyRoster);
        foreach (DataRow RowVhcl in dtVhcl.Rows)
        {

            objEntityDutyRoster.VehiclleId = Convert.ToInt32(RowVhcl["VHCL_ID"].ToString());
            objEntityDutyRoster.User_Id = Convert.ToInt32(RowVhcl["VHCL_PRSNT_MILEAGE"].ToString());
            objBusinessDutyRoster.updateVhclMlg(objEntityDutyRoster);              
        }
        bindStatus();
        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmSubmit", "SuccessConfirmSubmit();", true);
    }
    protected void btnSubReopen_Click(object sender, EventArgs e)
    {
        clsEntityLayerDutyRoster objEntityDutyRoster = new clsEntityLayerDutyRoster();
        clsBusinessLayerDutyRoster objBusinessDutyRoster = new clsBusinessLayerDutyRoster();
        clsCommonLibrary objCommon = new clsCommonLibrary();
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
        if (Session["USERID"] != null)
        {
            objEntityDutyRoster.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        //For duty submission master table
        objEntityDutyRoster.Date = System.DateTime.Now;
        objEntityDutyRoster.CnfrmStsId = 0;
        objEntityDutyRoster.SubmissionId = Convert.ToInt32(HiddenFieldSubmissionId.Value);
        objBusinessDutyRoster.reopenSubmision(objEntityDutyRoster);
        bindStatus();
        Response.Redirect("gen_Duty_Roster.aspx?InsUpd=ReopenSubmsn");

    }
    public void bindStatus()
    {
        clsBusinessLayerDutyRoster objBusinessDutyRoster = new clsBusinessLayerDutyRoster();
        DataTable dtDivisionList = new DataTable();
        dtDivisionList = objBusinessDutyRoster.ReadSts();
        dtDivisionList.TableName = "dtTableDivision";
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtDivisionList.WriteXml(sw);
            result = sw.ToString();
        }
        HiddenFieldStatusDropdown.Value = result;
    }
    //Stop:-Emp-0009

    [WebMethod]
    public static string[] CreateDutySlipPrint(int intCorpId, int intOrgId,int intUserid, string EmployeIds, string strDate)
    {

        clsEntityLayerDutyRoster objEntityDutyRoster = new clsEntityLayerDutyRoster();
        clsBusinessLayerDutyRoster objBusinessDutyRoster = new clsBusinessLayerDutyRoster();
        objEntityDutyRoster.Organisation_id = intOrgId;
        objEntityDutyRoster.Corporate_id = intCorpId;

        
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";

        strTitle = "Duty Slip";
        string dat = "<B>Date: </B>" + strDate;

        DataTable dtCorp = objBusinessDutyRoster.ReadCorporateAddress(objEntityDutyRoster);
        if (dtCorp.Rows.Count > 0)
        {
            strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
            strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
            strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
            strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
            strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
        }
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        string strCompanyAddr = objClsCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);


        //  string strCompanyAddr = objClsCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);

        string[] strFulldata = new string[3];

        string[] FullEmployee = EmployeIds.Split(',');

        foreach (string EachEmploye in FullEmployee)
        {
            if (EachEmploye != "")
            {


                objEntityDutyRoster.Organisation_id = intOrgId;
                objEntityDutyRoster.Corporate_id = intCorpId;
                objEntityDutyRoster.FromDate = objCommon.textToDateTime(strDate);

                objEntityDutyRoster.EmployeeId = Convert.ToInt32(EachEmploye);


                DataTable dtDutyShdlDayWise = objBusinessDutyRoster.ReadDutyShdlForDayEmp(objEntityDutyRoster);//1-pDay wise

                DataTable dtEmpName = objBusinessDutyRoster.ReadEmpDetail(objEntityDutyRoster);



                StringBuilder sbCap = new StringBuilder();

                string strCaptionTabstart = "<div style=\"float: left;width: 100%;padding-top: 20px;\"><table class=\"PrintCaptionTable\" style=\"width: 100%;\">";
                string strCaptionTabCompanyNameRow = "<tr style=\"text-align: center;font-size: 14px;font-weight: bold;line-height: 8px;\"><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
                string strCaptionTabCompanyAddrRow = "<tr style=\"text-align: center; font-size: 10px;\"><td class=\"CompanyAddr\">" + strCompanyAddr1 + "</td></tr>";

                string strCaptionTabRprtDate = "", strCaptionTabTitle = "",strEmpName="";
                if (strTitle != "")
                {
                    strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
                }
                if (dat != "")
                {
                    strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
                }

                if (dtEmpName.Rows.Count>0)
                {
                    strEmpName = "<tr><td class=\"RprtDate\"><B>Employee : </B>" + dtEmpName.Rows[0]["USR_NAME"] + "</td></tr>";
                }



                string strCaptionTabstop = "</table></div>";

                string DivFullWithTopic = "<div style=\"float: left;width: 100%;margin-top: -2%;\"><h2 style=\"width: 20%;float: left;font-size: 14px;margin-left: 20%;\">PLAN</h2><h2 style=\"width: 20%;float: left;font-size: 14px;margin-left: 38%;\">ACTUAL</h2></div>";
                string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabTitle + strCaptionTabRprtDate + strEmpName + strCaptionTabstop + DivFullWithTopic;

                StringBuilder sb = new StringBuilder();
                string strHtml = strPrintCaptionTable;
                strHtml += "<div style=\"float: left;width: 100%;padding-bottom: 69px;border-bottom: 2px dotted;\"><table class=\"tab\"  >";
                //add header row
                strHtml += "<thead>";
                strHtml += "<tr class=\"top_row\">";

                strHtml += "<th class=\"thT\" style=\"width:7%;text-align: CENTER; word-wrap:break-word;\">FROM TIME</th>";

                strHtml += "<th class=\"thT\"  style=\"width:7%;text-align: CENTER; word-wrap:break-word;\">TO TIME</th>";

                strHtml += "<th class=\"thT\"  style=\"width:36%;text-align: left; word-wrap:break-word;\">ASSIGNED DUTY</th>";

                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: LEFT; word-wrap:break-word;\">VEHICLE NUMBER</th>";
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: LEFT; word-wrap:break-word;\">VEHICLE CLASS</th>";

                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: CENTER; word-wrap:break-word;\">FROM DATE&TIME</th>";

                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: CENTER; word-wrap:break-word;\">TO DATE&TIME</th>";

                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: CENTER; word-wrap:break-word;\">PRESENT MILEAGE</th>";
                strHtml += "</tr>";
                strHtml += "</thead>";

                //add rows

                strHtml += "<tbody>";
                if(dtDutyShdlDayWise.Rows.Count>0)
                    {
                for (int intRowBodyCount = 0; intRowBodyCount < dtDutyShdlDayWise.Rows.Count; intRowBodyCount++)
                {

                    objEntityDutyRoster.DutyRosterId = Convert.ToInt32(dtDutyShdlDayWise.Rows[intRowBodyCount]["DUTYGNRTN_ID"]);
                    objEntityDutyRoster.User_Id = intUserid;
                    objEntityDutyRoster.Date = DateTime.Now;
                    objBusinessDutyRoster.PrintStsUpdate(objEntityDutyRoster);

                    strHtml += "<tr >";
                       
                            strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtDutyShdlDayWise.Rows[intRowBodyCount]["DUTYGNRTNDTL_FROM_TIME"].ToString() + "</td>";
                       
                       
                            strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtDutyShdlDayWise.Rows[intRowBodyCount]["DUTYGNRTNDTL_TO_TIME"].ToString() + "</td>";

                            if (dtDutyShdlDayWise.Rows[intRowBodyCount]["JOBMSTR_TITLE"].ToString() != "")
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:36%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtDutyShdlDayWise.Rows[intRowBodyCount]["JOBMSTR_TITLE"].ToString() + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:36%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtDutyShdlDayWise.Rows[intRowBodyCount]["JOB_NAME"].ToString() + "</td>";
                            }
                       
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtDutyShdlDayWise.Rows[intRowBodyCount]["VHCL_NUMBR"].ToString() + "</td>";
                       
                      
                        
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtDutyShdlDayWise.Rows[intRowBodyCount]["VHCLCLS_NAME"].ToString() + "</td>";
                       
                     
                       
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" ></td>";
                      

                       
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" ></td>";

                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" ></td>";
                  
                    strHtml += "</tr>";
                }
                    
                }
                else
                {

                    strHtml += "<tr style=\"height: 23px;\">";
                        
                            strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: center;\" ></td>";
                       
                       
                            strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: center;\" ></td>";
                        
                       
                            strHtml += "<td class=\"tdT\" style=\" width:36%;word-break: break-all; word-wrap:break-word;text-align: center;\" > No Job Sheduled</td>";
                       
                        
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";
                       
                      
                        
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";
                       
                     
                       
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" ></td>";
                      

                       
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" ></td>";

                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" ></td>";
                  
                    strHtml += "</tr>";
                }


                for (int Count = 0; Count < 6; Count++)
                {
                    strHtml += "<tr >";

                    strHtml += "<td class=\"tdT\" style=\"height: 17px; width:7%;word-break: break-all; word-wrap:break-word;text-align: center;\" ></td>";


                    strHtml += "<td class=\"tdT\" style=\"height: 17px; width:7%;word-break: break-all; word-wrap:break-word;text-align: center;\" ></td>";


                    strHtml += "<td class=\"tdT\" style=\"height: 17px; width:36%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";


                    strHtml += "<td class=\"tdT\" style=\" height: 17px;width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";



                    strHtml += "<td class=\"tdT\" style=\"height: 17px; width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";



                    strHtml += "<td class=\"tdT\" style=\" height: 17px;width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" ></td>";



                    strHtml += "<td class=\"tdT\" style=\" height: 17px;width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" ></td>";

                    strHtml += "<td class=\"tdT\" style=\" height: 17px;width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" ></td>";

                    strHtml += "</tr>";
                }

                strHtml += "</tbody>";

                strHtml += "</table>";

                strHtml += "<div style=\"float: left;width: 100%;\">";
                strHtml += "<div style=\"float: left;width: 48%;\">";
                strHtml += "<h2 style=\"float: left;font-size: 12px;margin-top: 3%;\">Duty assigned :.................................................</h2>";
                strHtml += " </div>";
                strHtml += "<div style=\"float: right;width: 48%;\">";
                strHtml += "<h2 style=\"float: right;font-size: 12px;margin-top: 3%;\">Employee's signature :.................................................</h2>";
                strHtml += " </div>";   
                strHtml += " </div>";
                    strHtml += " </div>";

                //objEntityDutyRoster.VehiclleId = Convert.ToInt32(dtDutyShdlDayWise.Rows[0]["VHCL_ID"].ToString());
                //DataTable dtVehicle = objBusinessDutyRoster.ReadVehicleById(objEntityDutyRoster);
               
                


               //FOR FUTURE VEHICLE DETAILS


                sb.Append(strHtml);
                strFulldata[1] = strFulldata[1] + sb.ToString();

            }
        }
        return strFulldata;
    }
    public void EmployeeCbxLoad()
    {
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

        DataTable dtEmployee = objBusinessDutyRoster.ReadEmployee(objEntityDutyRoster);


        if (dtEmployee.Rows.Count > 0)
        {
            chkbxListEmployee.DataSource = dtEmployee;
            chkbxListEmployee.DataTextField = "Employee";
            chkbxListEmployee.DataValueField = "USR_ID";
            chkbxListEmployee.DataBind();


        }

        if (dtEmployee.Rows.Count > 0)
        {
            ddlEmployee.DataSource = dtEmployee;
            ddlEmployee.DataTextField = "Employee";
            ddlEmployee.DataValueField = "USR_ID";
            ddlEmployee.DataBind();


        }

        ddlEmployee.Items.Insert(0, "--ALL EMPLOYEE--");

    }
    protected void btnMarkLeave_Click(object sender, EventArgs e)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerDutyRoster objEntityDutyRoster = new clsEntityLayerDutyRoster();
        clsBusinessLayerDutyRoster objBusinessDutyRoster = new clsBusinessLayerDutyRoster();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

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

        if (Session["USERID"] != null)
        {
            objEntityDutyRoster.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        string LeaveTotal = hiddenLeaveMarkDetails.Value;

        string[] leaveSplit = LeaveTotal.Split(',');
        objEntityDutyRoster.EmployeeId = Convert.ToInt32(leaveSplit[0]);

        objEntityDutyRoster.LeaveDate = objCommon.textToDateTime(leaveSplit[1]);

        objBusinessDutyRoster.AddLeavAlloctnDetails(objEntityDutyRoster);
       


        if (ddlEmployee.SelectedItem.Value == "--ALL EMPLOYEE--" && hiddenPrevious.Value == "0")
        {
            Response.Redirect("gen_Duty_Roster.aspx?InsUpd=LeaveAlloted");
        }
        else if (hiddenPrevious.Value != "0")
        {
            string navigate = hiddenPrevious.Value + "," + hiddenNext.Value;

            Response.Redirect("gen_Duty_Roster.aspx?InsUpd=LeaveAlloted&Navi=" + navigate);

        }

        else
        {
            string Id = ddlEmployee.SelectedItem.Value;
            Response.Redirect("gen_Duty_Roster.aspx?InsUpd=LeaveAlloted&Srch=" + Id);
        }
    }
    protected void btnEmployeeSearch_Click(object sender, EventArgs e)
    {
        if (ddlEmployee.SelectedItem.Value != "--ALL EMPLOYEE--")
        {
            int intEmp = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
            FillEmployeeTable(intEmp);
        }
        else
        {
            FillEmployeeTable();
        }
    }
    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        setButtonValues(Convert.ToInt32(Button_type.Previous));
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        setButtonValues(Convert.ToInt32(Button_type.Next));
    }

    public void setButtonValues(int intButtonId)
    {
        int first = 0;
        int last = 0;

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
        objEntityDutyRoster.EmployeeId = 0;
        DataTable dtEmployee = objBusinessDutyRoster.ReadEmployee(objEntityDutyRoster);

        if (intButtonId == Convert.ToInt32(Button_type.Next))
        {
            first = Convert.ToInt32(hiddenNext.Value);
            last = Convert.ToInt32(hiddenNext.Value) + Convert.ToInt32(25);
            hiddenPrevious.Value = first.ToString();
            hiddenNext.Value = last.ToString();
        }

        if (intButtonId == Convert.ToInt32(Button_type.Previous))
        {
            first = Convert.ToInt32(hiddenPrevious.Value) - Convert.ToInt32(25);
            last = Convert.ToInt32(hiddenPrevious.Value);
            hiddenPrevious.Value = first.ToString();
            hiddenNext.Value = last.ToString();
        }

        if (intButtonId == Convert.ToInt32(Button_type.Redirect))
        {
            first = Convert.ToInt32(hiddenPrevious.Value);
            last = Convert.ToInt32(hiddenNext.Value);
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
        if (last < dtEmployee.Rows.Count)
        {

            btnNext.Enabled = true;
        }
        else
        {
            btnNext.Enabled = false;
        }
        FillEmployeeTable();
    }


    [WebMethod]
    public static string VhclCheck(string Fromdate, string Todate, string FromTime, string ToTime, int VhclId, string edit)
    {
        string sts = "true";
        clsBusinessLayerJobShdl objBusinessLayerJobShdl = new clsBusinessLayerJobShdl();
        clsEntityLayerJobSchedule objEntityJobShdl = new clsEntityLayerJobSchedule();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityJobShdl.VehicleID = VhclId;
        objEntityJobShdl.Fromdate = objCommon.textToDateTime(Fromdate);
        objEntityJobShdl.Todate = objCommon.textToDateTime(Todate);


        //For job schedule table
        clsEntityLayerJobScheduleDtl objEntityDetails = new clsEntityLayerJobScheduleDtl();
        string strFromDatetime = Convert.ToString("01-01-1000-" + FromTime);
        objEntityDetails.FromTime = objCommon.textWithTimeToDateTime(strFromDatetime);
        string strToDatetime = Convert.ToString("01-01-1000-" + ToTime);
        objEntityDetails.ToTime = objCommon.textWithTimeToDateTime(strToDatetime);
       


        //For dutyroster scheduling
        clsEntityLayerJobScheduleDtl objEntityDetailsDuty = new clsEntityLayerJobScheduleDtl();
        string strFromDatetimeduty = Convert.ToString("01-01-1000-" + FromTime);
        objEntityDetails.FromTime = objCommon.textWithTimeToDateTime(strFromDatetime);
        string strToDatetimeduty = Convert.ToString("01-01-1000-" + ToTime);
        objEntityDetails.ToTime = objCommon.textWithTimeToDateTime(strToDatetime);
        if (edit != "")
        {
            objEntityJobShdl.JobSchdlId = Convert.ToInt32(edit);
        }

        DataTable dtduty = objBusinessLayerJobShdl.readVhclScdldDtlsDuty(objEntityJobShdl);
        foreach (DataRow RowVhcl in dtduty.Rows)
        {       
                clsEntityLayerJobScheduleDtl objEntityDetails1 = new clsEntityLayerJobScheduleDtl();
                string strFromDatetime1 = Convert.ToString("01-01-1000-" + RowVhcl["JOBSHDLDTL_FROM_TIME"].ToString());
                objEntityDetails1.FromTime = objCommon.textWithTimeToDateTime(strFromDatetime1);
                string strToDatetime1 = Convert.ToString("01-01-1000-" + RowVhcl["JOBSHDLDTL_TO_TIME"].ToString());
                objEntityDetails1.ToTime = objCommon.textWithTimeToDateTime(strToDatetime1);


                if (objEntityDetails1.FromTime > objEntityDetails.FromTime && objEntityDetails1.FromTime < objEntityDetails.ToTime
                    ||
                    objEntityDetails.FromTime > objEntityDetails1.FromTime && objEntityDetails.FromTime < objEntityDetails1.ToTime
                    ||
                     objEntityDetails1.FromTime == objEntityDetails.FromTime
                    )
                {
                    sts = "false";
                    break;
                }
            
        }



        return sts;
    }

    //Start:-EMP-0009

    [WebMethod]
    public static string CheckEmpDuplctn(string empid, string fromdate, string todate, string SubmsnId)
    {
        string sts = "true";
        clsBusinessLayerDutyRoster objBUsinessDutyRstr = new clsBusinessLayerDutyRoster();
        clsEntityLayerDutyRoster objEntityDutyRstr = new clsEntityLayerDutyRoster();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityDutyRstr.User_Id = Convert.ToInt32(empid);
        objEntityDutyRstr.FromDate = objCommon.textWithTimeToDateTime(fromdate);
        objEntityDutyRstr.ToDate = objCommon.textWithTimeToDateTime(todate);
        if (SubmsnId != "" && SubmsnId != null)
        {
            objEntityDutyRstr.SubmissionId = Convert.ToInt32(SubmsnId);
        }
        DataTable dt = objBUsinessDutyRstr.readEmpDateDtls(objEntityDutyRstr);
        foreach (DataRow RowVhcl in dt.Rows)
        {

            clsEntityLayerDutyRoster objEntityDutyRstr1 = new clsEntityLayerDutyRoster();
            objEntityDutyRstr1.FromDate = Convert.ToDateTime(RowVhcl[0].ToString());
            objEntityDutyRstr1.ToDate = Convert.ToDateTime(RowVhcl[1].ToString());


            if (objEntityDutyRstr.FromDate > objEntityDutyRstr1.FromDate && objEntityDutyRstr.FromDate < objEntityDutyRstr1.ToDate
                    ||
                    objEntityDutyRstr1.FromDate > objEntityDutyRstr.FromDate && objEntityDutyRstr1.FromDate < objEntityDutyRstr.ToDate
                    ||
                     objEntityDutyRstr1.FromDate == objEntityDutyRstr.FromDate
                    )
                {
                    sts = "false";
                    break;
                }
           
          
        }
        return sts;
    }

    [WebMethod]
    public static string[] updateStartEnd(string strStartTime, string strStopTime, int strHalfTime, int strHalfSec)
    {
        string[] a = new string[2];

        clsBusinessLayerJobShdl objBusinessLayerJobSheduling = new clsBusinessLayerJobShdl();
        clsEntityLayerJobScheduleDtl objEntityJobShedulingDtl = new clsEntityLayerJobScheduleDtl();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (strStartTime != "" && strStopTime != "")
        {

            string strFromDatetime = Convert.ToString("01-01-1000-" + strStartTime);
            DateTime dtFromTime = Convert.ToDateTime(strFromDatetime);
            string strToDatetime = Convert.ToString("01-01-1000-" + strStopTime);
            DateTime dtToTime = Convert.ToDateTime(strToDatetime);

            if (strHalfSec == 2)
            {
                dtFromTime = dtFromTime.AddMinutes(strHalfTime);
            }
            else if (strHalfSec == 3)
            {
                dtToTime = dtFromTime.AddMinutes(strHalfTime);

            }
            string strFinalFrom = dtFromTime.ToString();
            string[] elem = strFinalFrom.Split(' ');
            string[] elem1 = elem[1].Split(':');
            if (elem1[0].Length < 2)
            {
                elem1[0] = "0" + elem1[0];
            }
            strFinalFrom = elem1[0] + ":" + elem1[1] + " " + elem[2];

            string strFinalTo = dtToTime.ToString();
            elem = strFinalTo.Split(' ');
            elem1 = elem[1].Split(':');
            if (elem1[0].Length < 2)
            {
                elem1[0] = "0" + elem1[0];
            }
            strFinalTo = elem1[0] + ":" + elem1[1] + " " + elem[2];

            a[0] = strFinalFrom;
            a[1] = strFinalTo;

        }
        return a;
    }
}