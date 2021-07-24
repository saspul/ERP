using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Collections;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Globalization;
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_AWMS;
public partial class HCM_HCM_Master_hcm_PayrollSystem_hcm_Employee_Daily_Hour_hcm_Employee_Daily_Hour_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        DropDownList2.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        DropDownList2.Attributes.Add("onkeypress", "return DisableEnter(event)");
        DropDownList3.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        DropDownList3.Attributes.Add("onkeypress", "return DisableEnter(event)");

        if (!IsPostBack)
        {
            YearLoad();
            monthLoad();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayerEmployeeDailyWorkHour objBusinessEmpDailyWorkHour = new clsBusinessLayerEmployeeDailyWorkHour();
            clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour = new clsEntityEmployeeDailyWorkHour();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

            Session["DailyWrkView"] = null;


            int intUserId = 0, intUsrRolMstrId;

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
                intUserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }



            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Daily_Attendance_Sheet);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

            divAdd.Visible = false;
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                   
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        divAdd.Visible = true;
                    }
                  

                }
            }

            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "CONFIRM")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                }
                else if (strInsUpd == "REOPEN")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReopen", "SuccessReopen();", true);
                }
            }
        }
    }
    protected void YearLoad()
    {

        DropDownList3.Items.Clear();
        // created object for business layer for compare the date
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strCurrentDate = objBusiness.LoadCurrentDateInString();
        string[] split = strCurrentDate.Split('-');

        var currentYear = Convert.ToInt32(split[2]);
        for (int i = 0; i <= 20; i++)
        {
            // Now just add an entry that's the current year minus the counter
            DropDownList3.Items.Add((currentYear - i).ToString());

        }
        DropDownList3.Items.Insert(0, "--SELECT YEAR--");
    }
    public void monthLoad()
    {
        DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
        for (int i = 1; i < 13; i++)
        {
            DropDownList2.Items.Add(new ListItem(info.GetMonthName(i).ToUpper(), i.ToString()));
        }
        DropDownList2.Items.Insert(0, "--SELECT MONTH--");
    }
    protected void btnRedirect_Click(object sender, EventArgs e)
    {
        Session["DailyWrkView"] = HiddenViewId.Value;
        Response.Redirect("/HCM/HCM_Master/hcm_PayrollSystem/hcm_Employee_Daily_Hour/hcm_Employee_Daily_Hour_View.aspx");
    }
    [WebMethod]
    public static string ConfirmDtlsAll(string Id, string orgID, string corptID, string userID, string Mode, string TableSts)
    {
        clsBusinessLayerEmployeeDailyWorkHour objBusinessEmpDailyWorkHour = new clsBusinessLayerEmployeeDailyWorkHour();
        clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour = new clsEntityEmployeeDailyWorkHour();
        objEntityEmpDailyWorkHour.CorpId = Convert.ToInt32(corptID);
        objEntityEmpDailyWorkHour.orgid = Convert.ToInt32(orgID);
        objEntityEmpDailyWorkHour.StrDate = Id;
        objEntityEmpDailyWorkHour.UserId = Convert.ToInt32(userID);
        objEntityEmpDailyWorkHour.AttandanceMode = Convert.ToInt32(Mode);
        objEntityEmpDailyWorkHour.InsTableSts = Convert.ToInt32(TableSts);
        string strResult = "SUCCESS";  //checkAllConfReop
        try
        {
          DataTable dt = objBusinessEmpDailyWorkHour.checkAllConfReop(objEntityEmpDailyWorkHour);
          if (dt.Rows[0][0].ToString() != "0")
          {
              if (Mode == "1")
              {
                  objBusinessEmpDailyWorkHour.ConfReopAll(objEntityEmpDailyWorkHour);
              }
              else if (Mode == "0")
              {
                  DataTable dtIds = objBusinessEmpDailyWorkHour.ReadMasterIds(objEntityEmpDailyWorkHour);
                  for (int i = 0; i < dtIds.Rows.Count; i++)
                  {

                          bool boolLeaveAllocationStatus = false;
                          if (TableSts == "0")
                          {
                              boolLeaveAllocationStatus = AllocateLeave(dtIds.Rows[i][0].ToString(), orgID, corptID, userID);
                          }
                          else
                          {
                              boolLeaveAllocationStatus = AllocateLeaveAmnt(dtIds.Rows[i][0].ToString(), orgID, corptID, userID);
                          }
                          if (boolLeaveAllocationStatus)
                          {
                              objEntityEmpDailyWorkHour.EmpDlyWrkHrID = Convert.ToInt32(dtIds.Rows[i][0].ToString());
                              objBusinessEmpDailyWorkHour.ConfirmDtls(objEntityEmpDailyWorkHour);
                          }
                          else
                          {
                              //confirmation failed 
                              //missing leave type eith leave on absence for corporate
                              strResult = "NO_LOA";
                              break;
                          }
                  }
              }
          }
          else
          {
              strResult = "ALL_CONF";
          }
        }
        catch (Exception ex)
        {
         strResult = "ERROR";
        }
        return strResult;
    }

    public static bool AllocateLeave(string Id, string strOrgID, string strCorptID, string strUserID)
    {
        bool boolLeaveAllocationStatus = true;

        clsBusinessLayerEmployeeDailyWorkHour objBusinessEmpDailyWorkHour = new clsBusinessLayerEmployeeDailyWorkHour();
        clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour = new clsEntityEmployeeDailyWorkHour();

        if (Id != "")
        {
            objEntityEmpDailyWorkHour.EmpDlyWrkHrID = Convert.ToInt32(Id);
        }
        // Select Absentees 
        objEntityEmpDailyWorkHour.AttandanceMode = 1;
        DataTable dtEmpDailyWorkHourAbsentees = objBusinessEmpDailyWorkHour.readDailywrksheetDtls(objEntityEmpDailyWorkHour);

        if (dtEmpDailyWorkHourAbsentees.Rows.Count > 0)
        {
            DataRow[] dr = dtEmpDailyWorkHourAbsentees.Select("LEAVE_ON_ABSENCE_ID = " + 0);

            if (dr.Count() > 0)
            {
                // Absentees with no leave type
                boolLeaveAllocationStatus = false;
            }
            else
            {
                try
                {

                    for (int intRowCount = 0; intRowCount < dtEmpDailyWorkHourAbsentees.Rows.Count; intRowCount++)
                    {
                        //validate leaves - leave must not be duplicated
                        //if valid
                        //Allocate leaves
                        clsCommonLibrary objCommon = new clsCommonLibrary();
                        clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
                        clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
                        clsEntityCommon objEntityCommon = new clsEntityCommon();
                        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                        decimal decHalfFrmday = 0, decHalfToDay = 0;
                        DateTime dateCurnt;
                        objEntLevAllocn.Corporate_id = Convert.ToInt32(strCorptID);
                        objEntLevAllocn.Organisation_id = Convert.ToInt32(strOrgID);
                        objEntLevAllocn.User_Id = Convert.ToInt32(strUserID);
                        objEntLevAllocn.EmployeeId = Convert.ToInt32(dtEmpDailyWorkHourAbsentees.Rows[intRowCount]["USR_ID"].ToString());
                        //get leave id
                        if (dtEmpDailyWorkHourAbsentees.Rows[intRowCount]["LEAVE_ON_ABSENCE_ID"].ToString() != "")
                        {
                            objEntLevAllocn.Leave_Id = Convert.ToInt32(dtEmpDailyWorkHourAbsentees.Rows[intRowCount]["LEAVE_ON_ABSENCE_ID"].ToString());
                        }
                        objEntLevAllocn.PaidLvStatus = 0;
                        objEntLevAllocn.EilgiblLeaveAlloctnSts = 0;
                        objEntLevAllocn.LeaveFrmDate = objCommon.textToDateTime(dtEmpDailyWorkHourAbsentees.Rows[intRowCount]["DATE"].ToString());
                        dateCurnt = objEntLevAllocn.LeaveFrmDate;
                        objEntLevAllocn.LeaveFromSection = 1;
                        objEntLevAllocn.LeaveToDate = DateTime.MinValue;
                        objEntLevAllocn.LeaveToSection = 0;
                        objEntLevAllocn.NumOfLeave = 1;
                        int intFlag = 0;
                        DateTime dateFrm, dateTo;
                        DataTable datatableFrmChk;
                        datatableFrmChk = objBusLevAllocn.CheckLeaveDatesByEmployeeID(objEntLevAllocn);
                        if (datatableFrmChk.Rows.Count > 0)
                        {
                            intFlag++;
                        }
                        if (intFlag == 0)
                        {

                            objEntLevAllocn.EmployeeId = Convert.ToInt32(dtEmpDailyWorkHourAbsentees.Rows[intRowCount]["USR_ID"].ToString());
                            objEntLevAllocn.Leave_Id = Convert.ToInt32(dtEmpDailyWorkHourAbsentees.Rows[intRowCount]["LEAVE_ON_ABSENCE_ID"].ToString());

                            DataTable DtUser = objBusLevAllocn.ReadUserDetailsGnUser(objEntLevAllocn);
                            string UsrJoinDate = "", strJoinDate = "";
                            if (DtUser.Rows.Count > 0)
                            {
                                strJoinDate = DtUser.Rows[0]["USR_JOINED_DATE"].ToString();
                                if (strJoinDate == "")
                                {
                                    DataTable DtgnUser = objBusLevAllocn.ReadUserDetails(objEntLevAllocn);
                                    if (DtgnUser.Rows.Count > 0)
                                    {
                                        strJoinDate = DtgnUser.Rows[0]["USR_JOIN_DATE"].ToString();
                                    }
                                    if (strJoinDate != "")
                                    {
                                        if ((objCommon.textToDateTime(strJoinDate) != DateTime.MinValue))
                                        {
                                            UsrJoinDate = strJoinDate;
                                        }
                                    }
                                }
                                else if ((objCommon.textToDateTime(strJoinDate) == DateTime.MinValue))
                                {
                                    DataTable DtgnUser = objBusLevAllocn.ReadUserDetails(objEntLevAllocn);
                                    if (DtgnUser.Rows.Count > 0)
                                    {
                                        strJoinDate = DtgnUser.Rows[0]["USR_JOIN_DATE"].ToString();
                                    }
                                    if (strJoinDate != "")
                                    {
                                        if ((objCommon.textToDateTime(strJoinDate) != DateTime.MinValue))
                                        {
                                            UsrJoinDate = strJoinDate;
                                        }
                                    }
                                }
                                else
                                {
                                    UsrJoinDate = strJoinDate;
                                }
                            }
                            else
                            {
                                DataTable DtgnUser = objBusLevAllocn.ReadUserDetailsGnUser(objEntLevAllocn);
                                if (DtgnUser.Rows.Count > 0)
                                {
                                    strJoinDate = DtgnUser.Rows[0]["USR_JOIN_DATE"].ToString();
                                }
                                if (strJoinDate != "")
                                {
                                    if ((objCommon.textToDateTime(strJoinDate) != DateTime.MinValue))
                                    {
                                        UsrJoinDate = strJoinDate;
                                    }
                                }
                            }

                            //For experience
                            decimal ExpYears = 0;
                            clsBusiness_Leave_Type objBusinessLeave_Type = new clsBusiness_Leave_Type();
                            clsEntity_Leave_Type objEntityLeave_Type = new clsEntity_Leave_Type();
                            DataTable dtExpDtls = objBusinessLeave_Type.ReadExperienceByID(objEntityLeave_Type);

                            int ExpChck = 0;
                            if (UsrJoinDate != "")
                            {
                                string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();


                                DateTime currDateTime = objCommon.textToDateTime(strCurrentDate);

                                DateTime Dob = objCommon.textToDateTime(UsrJoinDate);
                                ExpYears = (currDateTime.Month - Dob.Month) + 12 * (currDateTime.Year - Dob.Year);
                                ExpYears = ExpYears / 12;
                                //if (ExpYears != 0)
                                //{
                                for (int intExpDtlsRowCount = 0; intExpDtlsRowCount < dtExpDtls.Rows.Count; intExpDtlsRowCount++)
                                {
                                    int intMinYear = Convert.ToInt32(dtExpDtls.Rows[intExpDtlsRowCount]["EXPMASTR_MIN_YEAR"]);
                                    int intMaxYear = Convert.ToInt32(dtExpDtls.Rows[intExpDtlsRowCount]["EXPMASTR_MAX_YEAR"]);
                                    if (ExpYears >= intMinYear && ExpYears <= intMaxYear)
                                    {
                                        ExpChck = Convert.ToInt32(dtExpDtls.Rows[intExpDtlsRowCount]["LEAVDTLS_EXPMASTR_ID"]);
                                    }
                                }
                            }

                            DataTable DtLevAlloDetails = new DataTable();
                            DtLevAlloDetails = objBusLevAllocn.ReadLeavTypdtl(objEntLevAllocn, ExpChck);


                            DataTable dataDt = objBusLevAllocn.ReadRemLeav(objEntLevAllocn);

                            string hiddenFrmRem = "0";

                            string hiddenOpeningLev = "0";
                            string hiddenremngNxtyrLv = "0";
                            if (dataDt.Rows.Count > 0)
                            {

                                hiddenFrmRem = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();

                                hiddenremngNxtyrLv = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                                hiddenOpeningLev = dataDt.Rows[0]["OPENING_NUMLEAVE"].ToString();

                            }


                            objEntLevAllocn.DailyLeaveStatus = 1;
                            //objEntLevAllocn.OpeningLv = Convert.ToInt32(hiddenOpeningLev);
                            objBusLevAllocn.AddLeavAlloctnDetails(objEntLevAllocn);

                            objEntLevAllocn.LeaveConfmn = 1;

                            objBusLevAllocn.ConfirmLeavAllocnDtl(objEntLevAllocn);
                            // new new type
                            //confirm the leave and update balance leave

                            string strchkuserlevCount = "0";

                            strchkuserlevCount = objBusLevAllocn.chkUserLevCount(objEntLevAllocn);

                            decimal decRemainLeav = 0, decNoOfLeav = 0;
                            decNoOfLeav = 1;
                            decimal decOpngLev = Convert.ToDecimal(hiddenOpeningLev);
                            objEntLevAllocn.OpeningLv = decOpngLev;
                            decRemainLeav = Convert.ToDecimal(hiddenremngNxtyrLv);
                            decRemainLeav = decRemainLeav - decNoOfLeav;
                            objEntLevAllocn.RemingLev = decRemainLeav;
                            if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                            {

                                objBusLevAllocn.InsertUserLeavTyp(objEntLevAllocn);
                            }
                            else
                            {
                                objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                            }
                            //Start:-Insert other leave types to GN_USER_LEAVE_TYPES            
                            for (int i = 0; i < DtLevAlloDetails.Rows.Count; i++)
                            {
                                objEntLevAllocn.Leave_Id = Convert.ToInt32(DtLevAlloDetails.Rows[i]["LEAVETYP_ID"].ToString());
                                strchkuserlevCount = "0";
                                strchkuserlevCount = objBusLevAllocn.chkUserLevCount(objEntLevAllocn);
                                objEntLevAllocn.OpeningLv = Convert.ToDecimal(DtLevAlloDetails.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                                objEntLevAllocn.RemingLev = Convert.ToDecimal(DtLevAlloDetails.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                                if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                                {
                                }
                                else
                                {
                                    objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                                }
                            }
                            //Stop:-Insert other leave types to GN_USER_LEAVE_TYPES



                            clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
                            clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
                            objEntityLeavSettlmt.CorpId = objEntLevAllocn.Corporate_id;
                            DataTable dtCorpSal = objBusinessLeavSettlmt.ReadCorpSal(objEntityLeavSettlmt);
                            int BasicPayStatus = Convert.ToInt32(dtCorpSal.Rows[0]["BASIC_PAY"].ToString());
                            objBusLevAllocn.ArrearAmountUpd(objEntLevAllocn.EmployeeId, objEntLevAllocn.LeavAllocn, objEntLevAllocn.Leave_Id, objEntLevAllocn.Corporate_id, objEntLevAllocn.Organisation_id, objEntLevAllocn.LeaveFrmDate, objEntLevAllocn.LeaveToDate, objEntLevAllocn.LeaveFromSection, objEntLevAllocn.LeaveToSection, BasicPayStatus, dtCorpSal.Rows[0]["FIXED_PAYRL_MODE_JOIN"].ToString(), UsrJoinDate);
                            //confrim ends
                        }
                    }

                }
                catch (Exception ex)
                {
                    //boolLeaveAllocationStatus = false;
                }
            }
        }
        return boolLeaveAllocationStatus;
    }


    public static decimal MonthSalary(string strEmpId, DateTime dtFromDate, DateTime dtToDate, string strBasicPay, int BasicPayStatus, int FixedSts, string strCorp, string Org, string IndividualRound)
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
        objEntityLeavSettlmt.EmployeeId = Convert.ToInt32(strEmpId);
        objEntityLeavSettlmt.UserId = Convert.ToInt32(strEmpId);
        objEntityLeavSettlmt.CorpId = Convert.ToInt32(strCorp);
        objEntityLeavSettlmt.OrgId = Convert.ToInt32(Org);

        TotalDays = 1;
        int daysInm = DateTime.DaysInMonth(dtFromDate.Year, dtFromDate.Month);

        DataTable dtAllownce = objBusinessLeavSettlmt.ReadAllowance(objEntityLeavSettlmt);
        DataTable dtDeductn = objBusinessLeavSettlmt.ReadDeduction(objEntityLeavSettlmt);

        //Basic pay calculation       
        if (strBasicPay != "")
        {
            decBasicPay = Convert.ToDecimal(strBasicPay) / daysInm;
            if (BasicPayStatus == 0)
            {
                decBasicPay = 0;
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
        int cntD = 2;
        if (IndividualRound == "1")
        {
            cntD = 0;
        }
        return Math.Round(decArrearAmnt, cntD) + Math.Round(decOtherAddtionAmount, cntD) + Math.Round(decBasicPay, cntD) + Math.Round(decAllownc, cntD) + Math.Round(decOvertm, cntD) - Math.Round(deciDeduction, cntD) - Math.Round(decInstlmnt, cntD) - Math.Round(decOtherDeductionAmount, cntD);
    }


    public static bool AllocateLeaveAmnt(string Id, string strOrgID, string strCorptID, string strUserID)
    {
        bool boolLeaveAllocationStatus = true;

        clsBusinessLayerEmployeeDailyWorkHour objBusinessEmpDailyWorkHour = new clsBusinessLayerEmployeeDailyWorkHour();
        clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour = new clsEntityEmployeeDailyWorkHour();
        if (Id != "")
        {
            objEntityEmpDailyWorkHour.EmpDlyWrkHrID = Convert.ToInt32(Id);
        }
        // Select Absentees 
        //objEntityEmpDailyWorkHour.AttandanceMode = 1;
        objEntityEmpDailyWorkHour.InsTableSts = 1;
        DataTable dtEmpDailyWorkHourAbsentees = objBusinessEmpDailyWorkHour.readDailywrksheetDtls(objEntityEmpDailyWorkHour);

        if (dtEmpDailyWorkHourAbsentees.Rows.Count > 0)
        {
            DataRow[] dr = dtEmpDailyWorkHourAbsentees.Select("LEAVE_ON_ABSENCE_ID = " + 0);

            if (dr.Count() > 0)
            {
                // Absentees with no leave type
                boolLeaveAllocationStatus = false;

            }
            else
            {
                try
                {

                    for (int intRowCount = 0; intRowCount < dtEmpDailyWorkHourAbsentees.Rows.Count; intRowCount++)
                    {
                        int ChangeSts = 0;
                        decimal netArrear = 0;
                        string strAtt = dtEmpDailyWorkHourAbsentees.Rows[intRowCount]["ATTENDANCE"].ToString();
                        string strRoundOt = dtEmpDailyWorkHourAbsentees.Rows[intRowCount]["EMDLHRDTL_RNDED_OT"].ToString();
                        string strOtName = dtEmpDailyWorkHourAbsentees.Rows[intRowCount]["OVRTMCATG_NAME"].ToString();
                        string strOtRate = dtEmpDailyWorkHourAbsentees.Rows[intRowCount]["OVRTMCATG_RATE"].ToString();
                        string strProjectRef = dtEmpDailyWorkHourAbsentees.Rows[intRowCount]["PROJECT_ID"].ToString();
                        string strIdlHour = dtEmpDailyWorkHourAbsentees.Rows[intRowCount]["EMDLHRDTL_IDLE_HOUR"].ToString();
                        string strOt = dtEmpDailyWorkHourAbsentees.Rows[intRowCount]["EMDLHRDTL_OT"].ToString();
                        string strEmpName = dtEmpDailyWorkHourAbsentees.Rows[intRowCount]["EMPLOYEE_NAME"].ToString();
                        string strDesignation = dtEmpDailyWorkHourAbsentees.Rows[intRowCount]["DESIGNATION"].ToString();
                        string strRemarks = dtEmpDailyWorkHourAbsentees.Rows[intRowCount]["EMDLHRDTL_REMARKS"].ToString();
                        //validate leaves - leave must not be duplicated

                        //if valid
                        //Allocate leaves

                        clsCommonLibrary objCommon = new clsCommonLibrary();
                        clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
                        clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
                        clsEntityCommon objEntityCommon = new clsEntityCommon();
                        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                        decimal decHalfFrmday = 0, decHalfToDay = 0;
                        DateTime dateCurnt;
                        objEntLevAllocn.Corporate_id = Convert.ToInt32(strCorptID);
                        objEntLevAllocn.Organisation_id = Convert.ToInt32(strOrgID);
                        objEntLevAllocn.User_Id = Convert.ToInt32(strUserID);
                        objEntLevAllocn.EmployeeId = Convert.ToInt32(dtEmpDailyWorkHourAbsentees.Rows[intRowCount]["USR_ID"].ToString());
                        //get leave id
                        if (dtEmpDailyWorkHourAbsentees.Rows[intRowCount]["LEAVE_ON_ABSENCE_ID"].ToString() != "")
                        {
                            objEntLevAllocn.Leave_Id = Convert.ToInt32(dtEmpDailyWorkHourAbsentees.Rows[intRowCount]["LEAVE_ON_ABSENCE_ID"].ToString());
                        }
                        objEntLevAllocn.PaidLvStatus = 0;
                        objEntLevAllocn.EilgiblLeaveAlloctnSts = 0;
                        objEntLevAllocn.LeaveFrmDate = objCommon.textToDateTime(dtEmpDailyWorkHourAbsentees.Rows[intRowCount]["DATE"].ToString());
                        dateCurnt = objEntLevAllocn.LeaveFrmDate;
                        objEntLevAllocn.LeaveFromSection = 1;
                        objEntLevAllocn.LeaveToDate = DateTime.MinValue;
                        objEntLevAllocn.LeaveToSection = 0;
                        objEntLevAllocn.NumOfLeave = 1;
                        objEntLevAllocn.LeaveSource = 1;

                        objEntityEmpDailyWorkHour.UserId = objEntLevAllocn.EmployeeId;
                        objEntityEmpDailyWorkHour.DateOfWork = objEntLevAllocn.LeaveFrmDate;
                        objEntityEmpDailyWorkHour.orgid = Convert.ToInt32(strOrgID);
                        objEntityEmpDailyWorkHour.CorpId = Convert.ToInt32(strCorptID);
                        DataTable dtFirstData = objBusinessEmpDailyWorkHour.ReadFirstUploadData(objEntityEmpDailyWorkHour);
                        decimal leaveArr = 0;
                        if (dtFirstData.Rows.Count > 0)
                        {
                            string strAttAmnt = dtFirstData.Rows[0]["ATTENDANCE"].ToString();
                            string strRoundOtAmnt = dtFirstData.Rows[0]["EMDLHRDTL_RNDED_OT"].ToString();
                            string strOtNameAmnt = dtFirstData.Rows[0]["OVRTMCATG_NAME"].ToString();
                            string strOtRateAmnt = dtFirstData.Rows[0]["OVRTMCATG_RATE"].ToString();
                            string strProjectRefAmnt = dtFirstData.Rows[0]["PROJECT_ID"].ToString();
                            string strIdlHourAmnt = dtFirstData.Rows[0]["EMDLHRDTL_IDLE_HOUR"].ToString();
                            string strOtAmnt = dtFirstData.Rows[0]["EMDLHRDTL_OT"].ToString();
                            string strEmpNameAmnt = dtFirstData.Rows[0]["EMPLOYEE_NAME"].ToString();
                            string strDesignationAmnt = dtFirstData.Rows[0]["DESIGNATION"].ToString();
                            string strRemarksAmnt = dtFirstData.Rows[0]["EMDLHRDTL_REMARKS"].ToString();
                            decimal BasicPay = Convert.ToDecimal(dtFirstData.Rows[0]["SLRY_BASIC_PAY"].ToString());

                            if (strAttAmnt != strAtt || strRoundOtAmnt != strRoundOt || strOtNameAmnt != strOtName || strProjectRefAmnt != strProjectRef || strIdlHourAmnt != strIdlHour
                            || strOtAmnt != strOt || strEmpNameAmnt != strEmpName || strDesignationAmnt != strDesignation || strRemarksAmnt != strRemarks)
                            {
                                ChangeSts = 1;
                                if (strAttAmnt != strAtt)
                                {
                                    ChangeSts = 2;
                                }
                            }
                            if (ChangeSts > 0 && strAttAmnt == "A" && strAtt == "P")
                            {
                                //Remove from leave allocation
                                objEntityEmpDailyWorkHour.ProjectId = objEntLevAllocn.Leave_Id;
                                objBusinessEmpDailyWorkHour.removeLeaveAllocation(objEntityEmpDailyWorkHour);
                                //Calculate one day salary
                                decimal basicAmnt = MonthSalary(objEntLevAllocn.EmployeeId.ToString(), objEntityEmpDailyWorkHour.DateOfWork, objEntityEmpDailyWorkHour.DateOfWork, dtFirstData.Rows[0]["SLRY_BASIC_PAY"].ToString(), Convert.ToInt32(dtFirstData.Rows[0]["BASIC_PAY"].ToString()), 0, strCorptID, strOrgID, dtFirstData.Rows[0]["PAYROLL_INDIVIDUAL_ROUND"].ToString());
                                netArrear += basicAmnt;
                            }
                            if (strRoundOtAmnt != strRoundOt || strOtNameAmnt != strOtName)
                            {
                                if (strAttAmnt == "P" && strAtt == "A")
                                {

                                    decimal otArrear = 0;
                                    int daysInm = DateTime.DaysInMonth(objEntityEmpDailyWorkHour.DateOfWork.Year, objEntityEmpDailyWorkHour.DateOfWork.Month);
                                    decimal decPerHourSal = BasicPay / daysInm;
                                    if (decPerHourSal > 0)
                                    {
                                        decPerHourSal = decPerHourSal / 8;
                                    }
                                    decimal OtAmnt = Convert.ToDecimal(strRoundOtAmnt) * Convert.ToDecimal(strOtRateAmnt) * decPerHourSal;
                                    decimal OtAmntAmnt = Convert.ToDecimal(strRoundOt) * Convert.ToDecimal(strOtRate) * decPerHourSal;
                                    otArrear = OtAmnt - OtAmntAmnt;
                                    if (otArrear != 0)
                                    {
                                        leaveArr += otArrear;

                                    }
                                }
                                else
                                {
                                    decimal otArrear = 0;
                                    int daysInm = DateTime.DaysInMonth(objEntityEmpDailyWorkHour.DateOfWork.Year, objEntityEmpDailyWorkHour.DateOfWork.Month);
                                    decimal decPerHourSal = BasicPay / daysInm;
                                    if (decPerHourSal > 0)
                                    {
                                        decPerHourSal = decPerHourSal / 8;
                                    }
                                    decimal OtAmnt = Convert.ToDecimal(strRoundOtAmnt) * Convert.ToDecimal(strOtRateAmnt) * decPerHourSal;
                                    decimal OtAmntAmnt = Convert.ToDecimal(strRoundOt) * Convert.ToDecimal(strOtRate) * decPerHourSal;
                                    otArrear = OtAmntAmnt - OtAmnt;
                                    if (otArrear != 0)
                                    {
                                        netArrear += otArrear;

                                    }
                                }
                            }
                            if (ChangeSts > 0)
                            {
                                clsEntityEmployeeDailyWorkHourDtl objEntityEmpDailyWorkHourDt = new clsEntityEmployeeDailyWorkHourDtl();
                                objEntityEmpDailyWorkHourDt.EmpDlyWrkHrID = Convert.ToInt32(dtEmpDailyWorkHourAbsentees.Rows[intRowCount]["EMDLHRDTL_ID"].ToString());
                                objEntityEmpDailyWorkHourDt.CorpId = ChangeSts;
                                objEntityEmpDailyWorkHourDt.RoundedOT = netArrear;
                                objBusinessEmpDailyWorkHour.UpdateAmendmentAttendance(objEntityEmpDailyWorkHourDt);
                            }
                        }
                        if (strAtt == "A" || strAtt == "a")
                        {
                            int intFlag = 0;
                            DateTime dateFrm, dateTo;
                            DataTable datatableFrmChk;
                            datatableFrmChk = objBusLevAllocn.CheckLeaveDatesByEmployeeID(objEntLevAllocn);
                            if (datatableFrmChk.Rows.Count > 0)
                            {
                                intFlag++;
                            }

                            if (intFlag == 0)
                            {


                                objEntLevAllocn.EmployeeId = Convert.ToInt32(dtEmpDailyWorkHourAbsentees.Rows[intRowCount]["USR_ID"].ToString());
                                objEntLevAllocn.Leave_Id = Convert.ToInt32(dtEmpDailyWorkHourAbsentees.Rows[intRowCount]["LEAVE_ON_ABSENCE_ID"].ToString());



                                DataTable DtUser = objBusLevAllocn.ReadUserDetailsGnUser(objEntLevAllocn);
                                string UsrJoinDate = "", strJoinDate = "";
                                if (DtUser.Rows.Count > 0)
                                {
                                    strJoinDate = DtUser.Rows[0]["USR_JOINED_DATE"].ToString();
                                    if (strJoinDate == "")
                                    {
                                        DataTable DtgnUser = objBusLevAllocn.ReadUserDetails(objEntLevAllocn);
                                        if (DtgnUser.Rows.Count > 0)
                                        {
                                            strJoinDate = DtgnUser.Rows[0]["USR_JOIN_DATE"].ToString();
                                        }
                                        if (strJoinDate != "")
                                        {
                                            if ((objCommon.textToDateTime(strJoinDate) != DateTime.MinValue))
                                            {
                                                UsrJoinDate = strJoinDate;
                                            }
                                        }
                                    }
                                    else if ((objCommon.textToDateTime(strJoinDate) == DateTime.MinValue))
                                    {
                                        DataTable DtgnUser = objBusLevAllocn.ReadUserDetails(objEntLevAllocn);
                                        if (DtgnUser.Rows.Count > 0)
                                        {
                                            strJoinDate = DtgnUser.Rows[0]["USR_JOIN_DATE"].ToString();
                                        }
                                        if (strJoinDate != "")
                                        {
                                            if ((objCommon.textToDateTime(strJoinDate) != DateTime.MinValue))
                                            {
                                                UsrJoinDate = strJoinDate;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        UsrJoinDate = strJoinDate;
                                    }
                                }
                                else
                                {
                                    DataTable DtgnUser = objBusLevAllocn.ReadUserDetailsGnUser(objEntLevAllocn);
                                    if (DtgnUser.Rows.Count > 0)
                                    {
                                        strJoinDate = DtgnUser.Rows[0]["USR_JOIN_DATE"].ToString();
                                    }
                                    if (strJoinDate != "")
                                    {
                                        if ((objCommon.textToDateTime(strJoinDate) != DateTime.MinValue))
                                        {
                                            UsrJoinDate = strJoinDate;
                                        }
                                    }
                                }

                                //For experience
                                decimal ExpYears = 0;
                                clsBusiness_Leave_Type objBusinessLeave_Type = new clsBusiness_Leave_Type();
                                clsEntity_Leave_Type objEntityLeave_Type = new clsEntity_Leave_Type();
                                DataTable dtExpDtls = objBusinessLeave_Type.ReadExperienceByID(objEntityLeave_Type);

                                int ExpChck = 0;
                                if (UsrJoinDate != "")
                                {
                                    string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();


                                    DateTime currDateTime = objCommon.textToDateTime(strCurrentDate);

                                    DateTime Dob = objCommon.textToDateTime(UsrJoinDate);
                                    ExpYears = (currDateTime.Month - Dob.Month) + 12 * (currDateTime.Year - Dob.Year);
                                    ExpYears = ExpYears / 12;
                                    for (int intExpDtlsRowCount = 0; intExpDtlsRowCount < dtExpDtls.Rows.Count; intExpDtlsRowCount++)
                                    {
                                        int intMinYear = Convert.ToInt32(dtExpDtls.Rows[intExpDtlsRowCount]["EXPMASTR_MIN_YEAR"]);
                                        int intMaxYear = Convert.ToInt32(dtExpDtls.Rows[intExpDtlsRowCount]["EXPMASTR_MAX_YEAR"]);
                                        if (ExpYears >= intMinYear && ExpYears <= intMaxYear)
                                        {
                                            ExpChck = Convert.ToInt32(dtExpDtls.Rows[intExpDtlsRowCount]["LEAVDTLS_EXPMASTR_ID"]);
                                        }
                                    }
                                }

                                DataTable DtLevAlloDetails = new DataTable();
                                DtLevAlloDetails = objBusLevAllocn.ReadLeavTypdtl(objEntLevAllocn, ExpChck);


                                DataTable dataDt = objBusLevAllocn.ReadRemLeav(objEntLevAllocn);

                                string hiddenFrmRem = "0";

                                string hiddenOpeningLev = "0";
                                string hiddenremngNxtyrLv = "0";
                                if (dataDt.Rows.Count > 0)
                                {

                                    hiddenFrmRem = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();

                                    hiddenremngNxtyrLv = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                                    hiddenOpeningLev = dataDt.Rows[0]["OPENING_NUMLEAVE"].ToString();

                                }


                                objEntLevAllocn.DailyLeaveStatus = 1;
                                //objEntLevAllocn.OpeningLv = Convert.ToInt32(hiddenOpeningLev);
                                objBusLevAllocn.AddLeavAlloctnDetails(objEntLevAllocn);

                                objEntLevAllocn.LeaveConfmn = 1;

                                objBusLevAllocn.ConfirmLeavAllocnDtl(objEntLevAllocn);


                                //confirm the leave and update balance leave

                                string strchkuserlevCount = "0";

                                strchkuserlevCount = objBusLevAllocn.chkUserLevCount(objEntLevAllocn);

                                decimal decRemainLeav = 0, decNoOfLeav = 0;
                                decNoOfLeav = 1;
                                decimal decOpngLev = Convert.ToDecimal(hiddenOpeningLev);
                                objEntLevAllocn.OpeningLv = decOpngLev;
                                decRemainLeav = Convert.ToDecimal(hiddenremngNxtyrLv);
                                decRemainLeav = decRemainLeav - decNoOfLeav;
                                objEntLevAllocn.RemingLev = decRemainLeav;
                                if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                                {

                                    objBusLevAllocn.InsertUserLeavTyp(objEntLevAllocn);
                                }
                                else
                                {
                                    objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                                }
                                //Start:-Insert other leave types to GN_USER_LEAVE_TYPES            
                                for (int i = 0; i < DtLevAlloDetails.Rows.Count; i++)
                                {
                                    objEntLevAllocn.Leave_Id = Convert.ToInt32(DtLevAlloDetails.Rows[i]["LEAVETYP_ID"].ToString());
                                    strchkuserlevCount = "0";
                                    strchkuserlevCount = objBusLevAllocn.chkUserLevCount(objEntLevAllocn);
                                    objEntLevAllocn.OpeningLv = Convert.ToDecimal(DtLevAlloDetails.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                                    objEntLevAllocn.RemingLev = Convert.ToDecimal(DtLevAlloDetails.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                                    if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                                    {
                                    }
                                    else
                                    {
                                        objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                                    }
                                }
                                //Stop:-Insert other leave types to GN_USER_LEAVE_TYPES

                                decimal basicAmntArrLev = MonthSalary(objEntLevAllocn.EmployeeId.ToString(), objEntityEmpDailyWorkHour.DateOfWork, objEntityEmpDailyWorkHour.DateOfWork, dtFirstData.Rows[0]["SLRY_BASIC_PAY"].ToString(), Convert.ToInt32(dtFirstData.Rows[0]["BASIC_PAY"].ToString()), 0, strCorptID, strOrgID, dtFirstData.Rows[0]["PAYROLL_INDIVIDUAL_ROUND"].ToString());
                                leaveArr += basicAmntArrLev;
                                if (leaveArr > 0)
                                {
                                    clsBussinessLayerLeaveAllocationMaster objBusLevAllocn1 = new clsBussinessLayerLeaveAllocationMaster();
                                    clsEntityLayerLeaveAllocationMaster objEntLevAllocn1 = new clsEntityLayerLeaveAllocationMaster();
                                    objEntLevAllocn1.Leave_Id = objEntLevAllocn.LeavAllocn;
                                    objEntLevAllocn1.User_Id = Convert.ToInt32(dtEmpDailyWorkHourAbsentees.Rows[intRowCount]["USR_ID"].ToString());
                                    objEntLevAllocn1.NumOfLeave = leaveArr;
                                    objBusLevAllocn1.InsLeaveArrearAmnt(objEntLevAllocn1);
                                }
                            }
                        }
                    }



                }
                catch (Exception ex)
                {
                    boolLeaveAllocationStatus = false;

                }


            }



        }


        return boolLeaveAllocationStatus;

    }
}