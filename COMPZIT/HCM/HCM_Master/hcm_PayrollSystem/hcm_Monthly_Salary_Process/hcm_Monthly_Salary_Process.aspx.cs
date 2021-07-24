using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using BL_Compzit.BusinessLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.Entity_Layer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Text;
using System.Web.Services;
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_AWMS;
// CREATED BY:EVM-0008
// CREATED DATE:10/30/2017
// REVIEWED BY:
// REVIEW DATE:


public partial class HCM_HCM_Master_hcm_PayrollSystem_hcm_Monthly_Salary_Process_hcm_Monthly_Salary_Process : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            HiddenEditView.Value = "";
            HiddenListView.Value = "0";
            ListPage.Visible = false;
            hiddenEmp.Value = "";
            HiddenRoleConf.Value = "0";
            HiddenSuccessMsgType.Value = "";
            int intUserId = 0;
            HiddenEdit.Value = "";
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
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            int intConfirm = 0, intUsrRolMstrId = 0, IntAllBusinessUnit = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Monthly_Salary_Process);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenRoleConf.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_BUSINESS_UNIT).ToString())
                    {
                        IntAllBusinessUnit = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }


                }
            }
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_LEAVE_SETTLE_DAYS,
                                                            clsCommonLibrary.CORP_GLOBAL.ELIGIBLE_LEAVE_STLMNT_LMT,
                                                             clsCommonLibrary.CORP_GLOBAL.PAYROLL_INDIVIDUAL_ROUND,
                                                              clsCommonLibrary.CORP_GLOBAL.FIXED_PAYRL_MODE_JOIN,
                                                               clsCommonLibrary.CORP_GLOBAL.WORKDAY_FIXED_PAYRL_MODE
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenFieldIndividualRound.Value = dtCorpDetail.Rows[0]["PAYROLL_INDIVIDUAL_ROUND"].ToString();
                HiddenFieldFixedPayrlMode.Value = dtCorpDetail.Rows[0]["FIXED_PAYRL_MODE_JOIN"].ToString();
                HiddenFieldWorkdayFixedPayrlMode.Value = dtCorpDetail.Rows[0]["WORKDAY_FIXED_PAYRL_MODE"].ToString();
            }
            BtnCon.Attributes.Add("style", "display:none;margin-left: 81%;height: 31px; margin-left: 5px;padding: 0 22px;font: 300 15px/29px 'Open Sans',Helvetica,Arial,sans-serif;cursor: pointer;");
            BtnPross.Attributes.Add("style", "display:none;margin-left: 81%;height: 31px; margin-left: 5px;padding: 0 22px;font: 300 15px/29px 'Open Sans',Helvetica,Arial,sans-serif;cursor: pointer;");
           
            Hiddentxtefctvedate.Value = DateTime.Now.ToString("dd-MM-yyyy");
            Hiddendate.Value = DateTime.Now.ToString("dd-MM-yyyy");
            cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
            cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
            clsEntityCommon objEntCommon = new clsEntityCommon();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            cls_Entity_Monthly_Salary_Process objEntPrcss = new cls_Entity_Monthly_Salary_Process();

            if (Request.UrlReferrer != null)
            {
                string previousPageUrl = Request.UrlReferrer.AbsoluteUri;
                string previousPageName = System.IO.Path.GetFileName(Request.UrlReferrer.AbsolutePath);
                if (previousPageName == "hcm_Monthly_Salary_Process_List.aspx" || previousPageName == "hcm_Monthly_Salary_Process_Master.aspx")
                {
                    if (Session["SALARPRSS"] != null)
                    {
                        // searchfield.Visible = false;
                        HiddenEdit.Value = "1";
                        ListPage.Visible = true;
                        HiddenListView.Value = "1";
                        int Processed = 0;

                        BtnPross.Attributes.Add("style", "display:none;margin-left: 81%;height: 31px; margin-left: 5px;padding: 0 22px;font: 300 15px/29px 'Open Sans',Helvetica,Arial,sans-serif;cursor: pointer;"); ;

                        var strSALARPRSS = Session["SALARPRSS"];
                        // Session["SALARPRSS_TEMP"] = strSALARPRSS;
                        string[] ProssId = strSALARPRSS.ToString().Split('~');
                        int SaveOrConf = Convert.ToInt32(ProssId[0]);

                        int CorpdepId = Convert.ToInt32(ProssId[1]);
                        int staffWrk = Convert.ToInt32(ProssId[2]);
                        DateTime ddate = objCommon.textToDateTime(ProssId[3]);
                        Hiddentxtefctvedate.Value = ProssId[3];


                        if (intConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            Processed = 1;
                            if (SaveOrConf == 0)
                            {
                                BtnCon.Attributes.Add("style", "display:block;margin-left: 81%;height: 31px; margin-left: 5px;padding: 0 22px;font: 300 15px/29px 'Open Sans',Helvetica,Arial,sans-serif;cursor: pointer;");
                               // BtnCon.Visible = true;
                            }
                        }
                        objEntPrcss.Month = Convert.ToInt32(ProssId[4]);
                        objEntPrcss.Year = Convert.ToInt32(ProssId[5]);
                        HiddenEditView.Value = objEntPrcss.Month + "|" + objEntPrcss.Year;
                        objEntPrcss.SavConf = SaveOrConf;

                        objEntPrcss.CorpOffice = CorpdepId;
                        objEntPrcss.StffWrkr = staffWrk;
                        objEntPrcss.date = ddate;
                        DataTable dt = objBuss.LoadSalaryPrssListPrssTable(objEntPrcss);

                        objEntPrcss.CorpOffice = intCorpId;
                        string ListLoad = ConvertDataTableToHTML(dt, objEntPrcss, Processed);
                        divlistview.InnerHtml = ListLoad;

                    }
                    else
                    {
                        List<cls_Entity_Monthly_Salary_Process> objEmpList = new List<cls_Entity_Monthly_Salary_Process>();
                        DataTable dt = objBuss.LoadSalaryPrssList(objEnt, objEmpList);
                        int Processed = 0;
                        string ListLoad = ConvertDataTableToHTML(dt, objEnt, Processed);
                    }
                }
            }

            clsBusinessLayer objBusiness = new clsBusinessLayer();
            objEntCommon.Organisation_Id = Convert.ToInt32(intOrgId);
            objEntCommon.CorporateID = Convert.ToInt32(intCorpId);
            BindDdlMonths();
            BindDdlYears();
            DataTable dtBussUnit, dtDivision, dtDep, dtDesg, dtEmployee;
            objEnt.CorpOffice = Convert.ToInt32(intCorpId);
            objEnt.Orgid = Convert.ToInt32(intOrgId);
            objEnt.UserId = Convert.ToInt32(intUserId);
            int AllBussnsUnit = 0;
            if (IntAllBusinessUnit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                AllBussnsUnit = 1;
            }

            dtBussUnit = objBuss.LoadBissnusUnit(objEnt, AllBussnsUnit);
            dtDivision = objBuss.LoadDivision(objEnt);
            dtDep = objBuss.LoadDep(objEnt);
            dtDesg = objBuss.LoadDesg(objEnt);
            dtEmployee = objBusiness.ReadEmployeeDtl(objEntCommon);
            LoadBussUnit(dtBussUnit);
            LoadDivision(dtDivision);
            LoadDep(dtDep);
            LoadDesg(dtDesg);
            LoadEmployee(dtEmployee);
            ScriptManager.RegisterStartupScript(this, GetType(), "insert", "insert();", true);

            if (Request.QueryString["Deleted"] == "true")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessDelete", "SuccessDelete();", true);
            }

        }

    }


    public decimal calcFutureLeaveCnt(string stringToCheck, DataTable dtLeaveDate, cls_Entity_Monthly_Salary_Process objEnt2)
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
                    if (LfrmDt>=objEnt2.DateStartDate && LToDt <= objEnt2.DateEndDate)
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
                    if (LfrmDt <= objEnt2.DateEndDate && LfrmDt >=objEnt2.DateStartDate)
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

    //BALANCE_AMOUNT
    public string ConvertDataTableToHTML(DataTable dt, cls_Entity_Monthly_Salary_Process OBJ, int Processed)
    {
        string IndvlRound = HiddenFieldIndividualRound.Value;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        int BasicPayStatus = 0, intOrgId = 0, intCorpid = 0, EmpId = 0;
        string PrcssId = "";
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpid = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        StringBuilder sb = new StringBuilder();
        sb.Append("<table id=\"datatable_fixed_column\" class=\"table table-striped table-bordered\" width=\"100%\" style=\"border-spacing: 1px;background-color: #e7e6e6;\" >");
        //add header row
        sb.Append("<thead>");
        sb.Append("<tr >");
        sb.Append("<tr >");
        HiddenFieldCbxCheck.Value = dt.Rows.Count.ToString();
        if (OBJ.SavConf != 1)
           sb.Append("<th class=\"hasinput\" style=\"width:3%;text-align: center;\"> <label class=\"checkbox\"style=\"margin-bottom: 13%;\" ><input type=\"checkbox\" title=\"SELECT ALL\"  onchange='return changeAll();'   onkeypress='return DisableEnter(event)'  id=\"cbMandatory\"><i  style=\"margin-left: 30%;\"></i></label>");
        sb.Append("<th class=\"hasinput\" style=\"width:10%;text-align: LEFT;\"> EMPLOYEE ID</th >");
        sb.Append("<th class=\"hasinput\" style=\"width:10%;text-align: LEFT;\"> EMPLOYEE</th >");
        sb.Append("<th class=\"hasinput\" style=\"width:8%;text-align: LEFT;\"> DESIGNATION</th >");
        sb.Append("<th class=\"hasinput\" style=\"width:8%;text-align: LEFT;\"> PAY GRADE</th >");   
        sb.Append("<th class=\"hasinput\" style=\"width:8%;text-align: right;\"> BASIC PAY");
        sb.Append("<th class=\"hasinput\" style=\"width:8%;text-align: right;\"> OVER TIME AMOUNT");
        sb.Append("<th class=\"hasinput\" style=\"width:10%;text-align: right;\"> ADDITION");
        sb.Append("<th class=\"hasinput\" style=\"width:10%;text-align: right;\"> OTHER ADDITION");

        sb.Append("<th class=\"hasinput\" style=\"width:8%;text-align: right;\"> ARREAR AMOUNT");

        sb.Append("<th class=\"hasinput\" style=\"width:10%;text-align: right;\"> INSTALMENT AMOUNT");
        sb.Append("<th class=\"hasinput\" style=\"width:10%;text-align: right;\"> DEDUCTION");
        sb.Append("<th class=\"hasinput\" style=\"width:10%;text-align: right;\"> OTHER DEDUCTION");
        sb.Append("<th class=\"hasinput\" style=\"width:10%;text-align: right;\"> LEAVE ARREAR AMOUNT");
        sb.Append("<th class=\"hasinput\" style=\"width:10%;text-align: right;\"> TOTAL AMOUNT");
        if (Processed == 1 && OBJ.SavConf == 0 && HiddenRoleConf.Value == "1")
        {   
          sb.Append("<th class=\"hasinput\" style=\"width:2.5%;text-align: center;\"> EDIT");
          sb.Append("<th class=\"hasinput\" style=\"width:2.5%;text-align: center;\"> DELETE");
        }
        sb.Append("<th class=\"hasinput\" style=\"width:2.5%;text-align: center;display:none\">");
        sb.Append("<th class=\"hasinput\" style=\"width:2.5%;text-align: center;display:none\"> ");
        sb.Append("<th class=\"hasinput\" style=\"width:2.5%;text-align: center;display:none\"> ");
        sb.Append("<th class=\"hasinput\" style=\"width:2.5%;text-align: center;display:none\"> ");
        sb.Append("<th class=\"hasinput\" style=\"width:2.5%;text-align: center;display:none\"> ");
        sb.Append("<th class=\"hasinput\" style=\"width:2.5%;text-align: center;display:none\"> ");
        sb.Append("<th class=\"hasinput\" style=\"width:2.5%;text-align: center;display:none\"> ");
        sb.Append("</th >");
        sb.Append("<th class=\"hasinput\" style=\"width:2.5%;text-align: center;display:none\"> ");
        sb.Append("</th >");
        sb.Append("<th class=\"hasinput\" style=\"width:2.5%;text-align: center;display:none\"> ");
        sb.Append("</th >");
        sb.Append("</tr>");
        sb.Append("</thead>");
        //add rows
        sb.Append("<tbody>");
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
             dutyOf objDuty = new dutyOf();
            int joinMnthSts = 0;
            BasicPayStatus = Convert.ToInt32(dt.Rows[intRowBodyCount]["BASIC_PAY"].ToString());
            string SettledLeavMssg = "", AllwOrDed = "0", MessLabel = "",LvArrearLabel = "", ArriarLable = "";
            decimal MessDedctn = 0, decLvArrearAmnt = 0, Arrearamount = 0, decSettlmntAmnt = 0, TotalnumLeav = 0, decOtherAddtionAmount = 0, decOtherDeductionAmount = 0;
            cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
            cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
            DataTable dtContract = new DataTable();
            if (Processed == 1)
            {
                PrcssId = dt.Rows[intRowBodyCount]["SLPRCDMNTH_ID"].ToString();
            }
            objEnt.Orgid = Convert.ToInt32(intOrgId);
            objEnt.CorpOffice = OBJ.CorpOffice;
            objEnt.date = OBJ.date;
            objEnt.Month = OBJ.Month;
            objEnt.Year = OBJ.Year;
            objEnt.Employee = Convert.ToInt32(dt.Rows[intRowBodyCount][0].ToString());
            EmpId = objEnt.Employee;
            int daysInMonth = DateTime.DaysInMonth(OBJ.Year, OBJ.Month);
            //Mess Deduction
            if (Processed == 1)
            {
                if (dt.Rows[intRowBodyCount]["SLPRCDMNTH_MESS_DEDCTN_AMT"].ToString() != "" && dt.Rows[intRowBodyCount]["SLPRCDMNTH_MESS_DEDCTN_AMT"].ToString() != null && Convert.ToDecimal(dt.Rows[intRowBodyCount]["SLPRCDMNTH_MESS_DEDCTN_AMT"].ToString())!=0)
                {
                    MessDedctn = Convert.ToDecimal(dt.Rows[intRowBodyCount]["SLPRCDMNTH_MESS_DEDCTN_AMT"].ToString());
                    if (IndvlRound == "1")
                    {
                        MessLabel = "Mess :" + Math.Round(MessDedctn, 0).ToString("0.00");
                    }
                    else
                    {
                        MessLabel = "Mess :" + MessDedctn.ToString("0.00");
                    }
                }
            }
            else
            {
                if (dt.Rows[intRowBodyCount]["MESS_DEDCTN"].ToString() != "" && Convert.ToDecimal(dt.Rows[intRowBodyCount]["MESS_DEDCTN"].ToString()) != 0)
                {
                    MessDedctn = Convert.ToDecimal(dt.Rows[intRowBodyCount]["MESS_DEDCTN"].ToString());
                    if (IndvlRound == "1")
                    {
                        MessLabel = "Mess :" + Math.Round(MessDedctn, 0).ToString("0.00");
                    }
                    else
                    {
                        MessLabel = "Mess :" + MessDedctn.ToString("0.00");
                    }
                }  
            }
            //ARREAR AMOUNT CALCULATION
            //if (dt.Rows[intRowBodyCount]["SLPRCDMNTH_ARREAR_AMNT"].ToString() != "" && Convert.ToDecimal(dt.Rows[intRowBodyCount]["SLPRCDMNTH_ARREAR_AMNT"].ToString()) != 0)
            //{               
            //   Arrearamount = Convert.ToDecimal(dt.Rows[intRowBodyCount]["SLPRCDMNTH_ARREAR_AMNT"].ToString());
            //   ArriarLable = "INCLUDED ARREAR AMOUNT";
            //} 
            cls_Entity_Monthly_Salary_Process objEnt1 = new cls_Entity_Monthly_Salary_Process();
            if (objEnt.Month == 1)
            {
                objEnt1.Month = 12;
                objEnt1.Year = objEnt.Year - 1;
            }
            else
            {
                objEnt1.Year = objEnt.Year;
                objEnt1.Month = objEnt.Month - 1;
            }
            objEnt1.Employee = Convert.ToInt32(objEnt.Employee);
            DataTable ArrearAmountdt = objBuss.GetArrearAmount(objEnt1);
            if (ArrearAmountdt.Rows.Count > 0 && ArrearAmountdt.Rows[0]["SLPRCDMNTH_ARREAR_AMNT"].ToString() != "" && Convert.ToDecimal(ArrearAmountdt.Rows[0]["SLPRCDMNTH_ARREAR_AMNT"].ToString()) != 0)
            {
                Arrearamount = Convert.ToDecimal(ArrearAmountdt.Rows[0]["SLPRCDMNTH_ARREAR_AMNT"].ToString());
                ArriarLable = "INCLUDED ARREAR AMOUNT";
            }      
            //Leave Calculation  
            DataTable dtLeavSettlmentVChk = objBuss.ReadLeavSettlmentChk(objEnt);
            if (dtLeavSettlmentVChk.Rows.Count > 0)
            {
                decSettlmntAmnt = Convert.ToDecimal(dtLeavSettlmentVChk.Rows[0]["LEVSETLMT_CRNTMNTH_SAL"].ToString());
                if (decSettlmntAmnt > 0)
                {
                    SettledLeavMssg = "LEAVE SETTLED";
                }
            }
            string strDecision = "", strPrevMnthFrom = "";
            decimal prevSal = 0;
            //Check rejoined after leave settlement
            int LsholiSts = 0, LSoffSts = 0;
            DateTime dtLstSettlddateRj = new DateTime();
            DataTable dtLeaveDtlsRj = new DataTable();
            if ((Processed == 1 && dt.Rows[intRowBodyCount]["SLPRCDMNTH_CONFRMSTS"].ToString() != "1") || Processed==0)
            {
                clsEntityLayerLeaveSettlmt objEntityLeavSettlmt4 = new clsEntityLayerLeaveSettlmt();
                clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt4 = new clsBusinessLayerLeaveSettlmt();
                objEntityLeavSettlmt4.EmployeeId = Convert.ToInt32(dt.Rows[intRowBodyCount][0].ToString());
                DateTime dtLstSettlddate = new DateTime();
                DataTable dtLeavSettld = objBusinessLeavSettlmt4.ReadLastSettldDt(objEntityLeavSettlmt4);
                if (dtLeavSettld.Rows.Count > 0)
                {
                    if (dtLeavSettld.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString() != "")
                    {
                        dtLstSettlddate = objCommon.textToDateTime(dtLeavSettld.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString());
                        dtLstSettlddateRj = objCommon.textToDateTime(dtLeavSettld.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString());
                    }
                    if (dtLeavSettld.Rows[0]["LEAVE_ID"].ToString() != "")
                    {
                        objEntityLeavSettlmt4.LeaveId = Convert.ToInt32(dtLeavSettld.Rows[0]["LEAVE_ID"].ToString());
                    }
                    dtLeaveDtlsRj = objBusinessLeavSettlmt4.ReadLeaveDetailsRj(objEntityLeavSettlmt4);
                    if (dtLeaveDtlsRj.Rows.Count > 0)
                    {
                        LsholiSts = Convert.ToInt32(dtLeaveDtlsRj.Rows[0]["LEAVETYP_HOLIDAY_PAID_STS"].ToString());
                        LSoffSts = Convert.ToInt32(dtLeaveDtlsRj.Rows[0]["LEAVETYP_OFFDAY_PAID_STS"].ToString());
                    }
                }
                if (dtLstSettlddate != DateTime.MinValue)
                {
                    objEntityLeavSettlmt4.CorpId = objEnt.CorpOffice;
                    objEntityLeavSettlmt4.OrgId = objEnt.Orgid;
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
                if (strPrevMnthFrom != "")
                {
                    DateTime dtCorptDate = new DateTime();
                    if (dt.Rows[intRowBodyCount]["COPRT_SALARY_DATE"].ToString() != "")
                    {
                        dtCorptDate = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["COPRT_SALARY_DATE"].ToString());
                    }
                    DateTime dtPrevFrom = objCommon.textToDateTime(strPrevMnthFrom);
                    int preDays = DateTime.DaysInMonth(dtPrevFrom.Year, dtPrevFrom.Month);
                    DateTime dtPrevTo = new DateTime(dtPrevFrom.Year, dtPrevFrom.Month, preDays);
                    if (dtCorptDate <= dtPrevTo)
                    {
                        if (dtCorptDate > dtPrevFrom)
                        {
                            dtPrevFrom = dtCorptDate;
                        }
                        prevSal = MonthSalary(dt.Rows[intRowBodyCount][0].ToString(), dtPrevFrom, dtPrevTo, dt.Rows[intRowBodyCount]["SLRY_BASIC_PAY"].ToString(), BasicPayStatus, 0, objEnt.CorpOffice.ToString(), objEnt.Orgid.ToString(), IndvlRound, LsholiSts, LSoffSts);
                    }
                }
            }
            else
            {
                //Start:-newwwwwwwwwwwwwwwww
                clsEntityLayerLeaveSettlmt objEntityLeavSettlmt4 = new clsEntityLayerLeaveSettlmt();
                clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt4 = new clsBusinessLayerLeaveSettlmt();
                objEntityLeavSettlmt4.EmployeeId = Convert.ToInt32(dt.Rows[intRowBodyCount][0].ToString());
                DateTime dtLstSettlddate = new DateTime();
                DataTable dtLeavSettld = objBusinessLeavSettlmt4.ReadLastSettldDt(objEntityLeavSettlmt4);
                if (dtLeavSettld.Rows.Count > 0)
                {
                    if (dtLeavSettld.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString() != "")
                    {
                        dtLstSettlddate = objCommon.textToDateTime(dtLeavSettld.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString());
                        dtLstSettlddateRj = objCommon.textToDateTime(dtLeavSettld.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString());
                    }
                    if (dtLeavSettld.Rows[0]["LEAVE_ID"].ToString() != "")
                    {
                        objEntityLeavSettlmt4.LeaveId = Convert.ToInt32(dtLeavSettld.Rows[0]["LEAVE_ID"].ToString());
                    }
                    dtLeaveDtlsRj = objBusinessLeavSettlmt4.ReadLeaveDetailsRj(objEntityLeavSettlmt4);
                    if (dtLeaveDtlsRj.Rows.Count > 0)
                    {
                        LsholiSts = Convert.ToInt32(dtLeaveDtlsRj.Rows[0]["LEAVETYP_HOLIDAY_PAID_STS"].ToString());
                        LSoffSts = Convert.ToInt32(dtLeaveDtlsRj.Rows[0]["LEAVETYP_OFFDAY_PAID_STS"].ToString());
                    }
                }
                if (dtLstSettlddate != DateTime.MinValue)
                {
                    objEntityLeavSettlmt4.CorpId = objEnt.CorpOffice;
                    objEntityLeavSettlmt4.OrgId = objEnt.Orgid;
                    DataTable dtEmpRejoin = objBusinessLeavSettlmt4.ReadRejoin(objEntityLeavSettlmt4);
                    if (dtEmpRejoin.Rows.Count > 0 && dtEmpRejoin.Rows[0]["DUTYREJOIN_DATE"].ToString() != "")
                    {
                        if (dtLstSettlddate > objCommon.textToDateTime(dtEmpRejoin.Rows[0]["DUTYREJOIN_DATE"].ToString()))
                        {
                            strDecision = "Not rejoined";
                        }
                    }
                    else
                    {
                        strDecision = "Not rejoined";
                    }
                }
                //End:-newwwwwwwwwwwwwwwww
                prevSal = Convert.ToDecimal(dt.Rows[intRowBodyCount]["SLPRCDMNTH_PREV_MNTH_ARRE_AMNT"].ToString());
            }
            //Arrear from daily attendance sheet table 
            DataTable dtArrearDailyAtt = objBuss.ReadArrearFromAtt(objEnt);
            if (dtArrearDailyAtt.Rows.Count > 0 && dtArrearDailyAtt.Rows[0]["SUM_ARREAR"].ToString() != "")
            {
                prevSal += Convert.ToDecimal(dtArrearDailyAtt.Rows[0]["SUM_ARREAR"].ToString());
            }


            DataTable dtLeavSettlmentDate = objBuss.ReadLeavSettlmentDat(objEnt);
            if (OBJ.Month == 12)
            {
                DataTable dtLeavList = objBuss.ReadLeavListList(objEnt);
                for(int i=0;i<dtLeavList.Rows.Count;i++)
                {
                  if (dtLeavList.Rows[i]["OPENING_NUMLEAVE"].ToString() != "0" && Convert.ToDecimal(dtLeavList.Rows[i]["OPENING_NUMLEAVE"].ToString()) > 0 && Convert.ToDecimal(dtLeavList.Rows[i]["BALANCE_NUMLEAVE"].ToString()) < 0)
                  {
                     
                   if (TotalnumLeav == 0)
                   {
                     TotalnumLeav = Convert.ToDecimal(dtLeavList.Rows[i]["BALANCE_NUMLEAVE"].ToString());
                     if (Convert.ToDecimal(dtLeavList.Rows[i]["BALANCE_NUMLEAVE"].ToString()) > 0 && SettledLeavMssg == "")
                     {
                         SettledLeavMssg = "EXECEEDED LEAVE";
                     }
                    }
                    else
                    {
                     TotalnumLeav = TotalnumLeav + Convert.ToDecimal(dtLeavList.Rows[i]["BALANCE_NUMLEAVE"].ToString());
                    }
                 }
              }
            }
            decimal BASICPAY = Convert.ToDecimal(dt.Rows[intRowBodyCount]["SLRY_BASIC_PAY"].ToString());
            if (OBJ.SavConf == 1)
            {
                objEnt.SavConf = 1;
            }
            int PAYINF_ID = 0;  
            DataTable dtOther_Addition = objBuss.ReadEmpManualy_AdditionDetails(objEnt);
            DataTable dtOther_Deduction = objBuss.ReadEmpManualy_DeductionsDetails(objEnt);                    
            for (int intRow = 0; intRow < dtOther_Addition.Rows.Count; intRow++)
            {
              decOtherAddtionAmount += Convert.ToDecimal(dtOther_Addition.Rows[intRow]["OTHER_ADDITION"].ToString());
              PAYINF_ID = Convert.ToInt32(dtOther_Addition.Rows[intRow]["PAYINF_ID"].ToString());
            }
            for (int intRow = 0; intRow < dtOther_Deduction.Rows.Count; intRow++)
            {
              decOtherDeductionAmount += Convert.ToDecimal(dtOther_Deduction.Rows[intRow]["OTHER_DEDUCTION"].ToString());
              PAYINF_ID = Convert.ToInt32(dtOther_Deduction.Rows[intRow]["PAYINF_ID"].ToString());
            }
            DataTable dtAllowSal, dtDedctnSal, dtAllowDailyhr;
            //ALLOWANCE CAL
            if (Processed == 1)
            {
                objEnt.SalaryPrssId = Convert.ToInt32(PrcssId);
                dtAllowSal = objBuss.ReadAllounceListPrssTable(objEnt);
            }
            else
            {
                dtAllowSal = objBuss.ReadAllounceList(objEnt);
            }
            int Settledays = 0,FixedAllowance = 0,LvSettleMode = 0;
            decimal Allowance = 0, WorkDays = daysInMonth, WorkDaysBasic = 0;
            string Addition = "";
            DateTime LeaveToDate = new DateTime();
            DateTime LeaveSettleUpd = new DateTime();
            DateTime dtLastUpdMonth = new DateTime();            
            DateTime Date1Rejoin = new DateTime();
            DataTable dtRejoin = new DataTable();
            DateTime SettlemtntDate = new DateTime();
            DataTable dtLeavMonth1 = objBuss.ReadMonthlyLastDate(objEnt);
            if (dtLeavMonth1.Rows.Count > 0 && dtLeavMonth1.Rows[0]["SLPRCDMNTH_LST_SETTLD_DT"].ToString() != "")
            {
                dtLastUpdMonth = objCommon.textToDateTime(dtLeavMonth1.Rows[0]["SLPRCDMNTH_LST_SETTLD_DT"].ToString());
            }
            if (dtLeavSettlmentDate.Rows.Count > 0 && dtLeavSettlmentDate.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString() != "")
            {               
                    SettlemtntDate = objCommon.textToDateTime(dtLeavSettlmentDate.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString());
                    objEnt.date = SettlemtntDate;
                    Settledays = SettlemtntDate.Day;
                    if (dtLeavSettlmentDate.Rows[0]["LEVSETLMT_FIXED_ALOWNC_STS"].ToString() != "")
                    {
                        FixedAllowance = Convert.ToInt32(dtLeavSettlmentDate.Rows[0]["LEVSETLMT_FIXED_ALOWNC_STS"].ToString());
                    }
                    if (dtLeavSettlmentDate.Rows[0]["LEVSETLMT_UPD_DATE"].ToString() != "")
                    {
                        LeaveSettleUpd = objCommon.textToDateTime(dtLeavSettlmentDate.Rows[0]["LEVSETLMT_UPD_DATE"].ToString());
                    }
                    if (dtLeavSettlmentDate.Rows[0]["LEVSETLMT_MODE"].ToString() != "")
                    {
                        LvSettleMode = Convert.ToInt32(dtLeavSettlmentDate.Rows[0]["LEVSETLMT_MODE"].ToString());
                    }
                    if (dtLeavSettlmentDate.Rows[0]["LEVSETLMT_ADDITN_AMT"].ToString() != "")
                    {
                        Addition = dtLeavSettlmentDate.Rows[0]["LEVSETLMT_ADDITN_AMT"].ToString();
                    }
                    if (dtLeavSettlmentDate.Rows[0]["LEAVE_ID"].ToString() != "")
                    {
                        objEnt.LeaveId = Convert.ToInt32(dtLeavSettlmentDate.Rows[0]["LEAVE_ID"].ToString());
                        dtRejoin = objBuss.ReadRejoinDate(objEnt);
                        if (dtRejoin.Rows.Count > 0)
                        {
                            if (dtRejoin.Rows[0]["DUTYREJOIN_DATE"].ToString() != "")
                            {
                                DateTime Date1 = new DateTime();
                                DateTime Date2 = new DateTime();
                                int days = DateTime.DaysInMonth(OBJ.Year, OBJ.Month);
                                objEnt.DateEndDate = new DateTime(OBJ.Year, OBJ.Month, days);
                                if (dtRejoin.Rows[0]["DUTYREJOIN_DATE"].ToString() != "")
                                {
                                    objEnt.DateStartDate = objCommon.textToDateTime(dtRejoin.Rows[0]["DUTYREJOIN_DATE"].ToString());

                                    Date1 = objCommon.textToDateTime(objEnt.DateStartDate.ToString("dd-MM-yyyy"));
                                    Date1Rejoin = Date1;
                                    Date2 = objCommon.textToDateTime(objEnt.DateEndDate.ToString("dd-MM-yyyy"));
                                    int intDay = 0;
                                    int intMonth = (Date2.Year * 12 + Date2.Month) - (Date1.Year * 12 + Date1.Month);
                                    if ((Date2.Year == Date1.Year) && (Date2.Month == Date1.Month))
                                    {
                                        intDay = daysInMonth - (Date1.Day - 1);
                                        WorkDays = (intMonth * 30) + intDay;
                                    }
                                    else
                                    {
                                        WorkDays = days;
                                    }
                                }
                                else
                                {
                                    objEnt.DateStartDate = dtLastUpdMonth;
                                }                              
                                if (WorkDays < 0)
                                {
                                    WorkDays = 0;
                                }
                                int daysht = DateTime.DaysInMonth(objEnt.Year, objEnt.Month);
                                if (Date1Rejoin > new DateTime(objEnt.Year, objEnt.Month, daysht))
                                {
                                    WorkDays = 0;
                                }
                            }
                        }
                        else
                        {
                            WorkDays = 0;
                            Settledays = 0;
                        }
                    }
            }
            if (LeaveSettleUpd != DateTime.MinValue || dtLastUpdMonth != DateTime.MinValue)
            {
                if (LeaveSettleUpd > dtLastUpdMonth)
                {
                    objEnt.date = LeaveSettleUpd;
                }
                else
                {
                    objEnt.date = dtLastUpdMonth;
                }
            }
            int daysS = DateTime.DaysInMonth(objEnt.Year, objEnt.Month);
            objEnt.DateEndDate = new DateTime(objEnt.Year, objEnt.Month, daysS);
            DataTable DtSettleAfterLeaveInfo = objBuss.ReadPrevLeaveDetails(objEnt);
            if (dtLastUpdMonth != DateTime.MinValue || Date1Rejoin != DateTime.MinValue)
            {

                Date1Rejoin = objCommon.textToDateTime(objEnt.DateStartDate.ToString("dd-MM-yyyy"));
                objEnt.DateStartDate = Date1Rejoin;
                if (Date1Rejoin > dtLastUpdMonth)
                {
                    objEnt.DateStartDate = Date1Rejoin;
                }
                else
                {                   
                  //objEnt.DateStartDate = dtLastUpdMonth;
                    objEnt.DateStartDate = new DateTime(OBJ.Year, OBJ.Month, 1);
                    if (dtLastUpdMonth.Month == OBJ.Month && dtLastUpdMonth.Year == OBJ.Year)
                    {
                    }
                    else
                    {
                        objEnt.DateStartDate = dtLastUpdMonth.AddDays(1);
                    }

                }
            }
            if (dt.Rows[intRowBodyCount]["USRJDT_CALC_DATE"].ToString() != "")
            {
                DateTime dtJoin = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["USRJDT_CALC_DATE"].ToString());
                if (dtJoin > objEnt.DateStartDate)
                {
                    objEnt.DateStartDate = dtJoin;
                }
            }     
            if (dt.Rows[intRowBodyCount]["COPRT_SALARY_DATE"].ToString() != "")
            {
                DateTime dtCorptDate = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["COPRT_SALARY_DATE"].ToString());
                if (dtCorptDate > objEnt.DateStartDate)
                {
                    objEnt.DateStartDate = dtCorptDate;
                }
            }
            if (dt.Rows[intRowBodyCount]["EMPERDTL_JOIN_DATE"].ToString() != "")
            {
                DateTime dtJoin = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["EMPERDTL_JOIN_DATE"].ToString());
                if (dtJoin >= objEnt.DateStartDate)
                {
                    objEnt.DateStartDate = dtJoin;
                    if (dtJoin.Day > 1 && HiddenFieldFixedPayrlMode.Value=="1")
                    {
                        joinMnthSts = 1;
                    }
                }
                if (Processed == 1 && objEnt.DateStartDate.Year == dtJoin.Year && dtJoin.Month == objEnt.DateStartDate.Month && dtJoin.Day > 1 && HiddenFieldFixedPayrlMode.Value == "1")
                {
                    joinMnthSts = 1;
                }
            }
            DataTable dtPaidLeave = objBuss.ReadMonthlyLeaveForMultipleYrs(objEnt);
            if (dtPaidLeave.Rows.Count > 0 && SettledLeavMssg == "")
            {
              SettledLeavMssg = "SETTLEMENT PENDING";
            }
            int dtdays = DateTime.DaysInMonth(OBJ.Year, OBJ.Month);

            if (strDecision != "")
            {
                WorkDays = 0;
                if (strDecision == "Not rejoined" && (LsholiSts!=0 ||LSoffSts!=0) )
                {
                    if (objEnt.DateEndDate >= dtLstSettlddateRj)
                    {
                        DateTime datenow, enddate;
                        enddate = objEnt.DateEndDate;
                        if (objEnt.DateStartDate < dtLstSettlddateRj)
                        {
                            datenow = dtLstSettlddateRj;
                            if (LsholiSts == 1 || LSoffSts == 1)
                            {
                                int OffCountR = 0;
                                for (var day = datenow; day <= enddate; day = day.AddDays(1))
                                {
                                    string hol = "false";
                                    if (LsholiSts == 1)
                                    {
                                        hol = objDuty.checkholiday(day, datenow, enddate);
                                        if (hol == "true")
                                        {
                                            OffCountR++;
                                        }
                                    }
                                    if (LSoffSts == 1 && hol != "true")
                                    {
                                        string off = objDuty.CheckDutyOff(day, OBJ.CorpOffice.ToString(), intOrgId.ToString());
                                        if (off == "true")
                                        {
                                            OffCountR++;
                                        }
                                    }
                                }
                                WorkDays += OffCountR;
                            }

                        }
                        else
                        {
                            datenow = objEnt.DateStartDate;
                            WorkDays = 0;
                            if (LsholiSts == 1 || LSoffSts == 1)
                            {
                                int OffCountR = 0;
                                for (var day = datenow; day <= enddate; day = day.AddDays(1))
                                {
                                    string hol = "false";
                                    if (LsholiSts == 1)
                                    {
                                        hol = objDuty.checkholiday(day, datenow, enddate);
                                        if (hol == "true")
                                        {
                                            OffCountR++;
                                        }
                                    }
                                    if (LSoffSts == 1 && hol != "true")
                                    {
                                        string off = objDuty.CheckDutyOff(day, OBJ.CorpOffice.ToString(), intOrgId.ToString());
                                        if (off == "true")
                                        {
                                            OffCountR++;
                                        }
                                    }
                                }
                                WorkDays += OffCountR;
                            }
                        }
                    }





                }

            }
            else if (dtLeaveDtlsRj.Rows.Count > 0 && (LsholiSts!=0 ||LSoffSts!=0))
            {                   
                    int OffCountRj = 0;
                    DateTime LfrmDt = DateTime.MinValue;
                    DateTime LToDt = DateTime.MinValue;
                    if (dtLeaveDtlsRj.Rows[0]["LEAVE_FROM_DATE"].ToString() != "")
                    {
                        LfrmDt = objCommon.textToDateTime(dtLeaveDtlsRj.Rows[0]["LEAVE_FROM_DATE"].ToString());
                    }
                    if (dtLeaveDtlsRj.Rows[0]["LEAVE_TO_DATE"].ToString() != "")
                    {
                        LToDt = objCommon.textToDateTime(dtLeaveDtlsRj.Rows[0]["LEAVE_TO_DATE"].ToString());
                    }
                    if (LfrmDt != DateTime.MinValue && LToDt != DateTime.MinValue)
                    {
                        int LvFrmMonth = LfrmDt.Month;
                        int LvFrmYear = LfrmDt.Year;
                        int LvFrmDay = LfrmDt.Day;
                        int LvToMonth = LToDt.Month;
                        int LvToYear = LToDt.Year;
                        int LvToDay = LToDt.Day;

                        if (LvFrmYear == OBJ.Year && LvFrmMonth == OBJ.Month && LvToYear == OBJ.Year && LvToMonth == OBJ.Month)
                        {
                            DateTime datenow, enddate;
                            datenow = LfrmDt;
                            enddate = LToDt;

                            if (LsholiSts == 1 || LSoffSts == 1)
                            {
                                for (var day = datenow; day <= enddate; day = day.AddDays(1))
                                {
                                    string hol = "false";
                                    if (LsholiSts == 1)
                                    {
                                        hol = objDuty.checkholiday(day, datenow, enddate);
                                        if (hol == "true")
                                        {
                                            OffCountRj = OffCountRj + 1;
                                        }
                                    }
                                    if (LSoffSts==1 && hol != "true")
                                    {
                                        string off = objDuty.CheckDutyOff(day, OBJ.CorpOffice.ToString(), intOrgId.ToString());
                                        if (off == "true")
                                        {
                                            OffCountRj = OffCountRj + 1;
                                        }
                                    }
                                }
                            }                           
                        }
                        else if (LvToYear == OBJ.Year && LvToMonth == OBJ.Month)
                        {

                            DateTime datenow, enddate;
                            datenow = objEnt.DateStartDate;
                            enddate = LToDt;
                            if (LsholiSts == 1 || LSoffSts == 1)
                            {
                                for (var day = datenow; day <= enddate; day = day.AddDays(1))
                                {
                                    string hol = "false";
                                    if (LsholiSts == 1)
                                    {
                                        hol = objDuty.checkholiday(day, datenow, enddate);
                                        if (hol == "true")
                                        {
                                            OffCountRj = OffCountRj + 1;
                                        }
                                    }
                                    if (LSoffSts == 1 && hol != "true")
                                    {
                                        string off = objDuty.CheckDutyOff(day, OBJ.CorpOffice.ToString(), intOrgId.ToString());
                                        if (off == "true")
                                        {
                                            OffCountRj = OffCountRj + 1;
                                        }
                                    }
                                }
                            }                         
                        }
                        else if (LvFrmYear == OBJ.Year && LvFrmMonth == OBJ.Month)
                        {
                           
                                DateTime datenow, enddate;
                                datenow = LfrmDt;
                                enddate = objEnt.DateEndDate;
                                if (LsholiSts == 1 || LSoffSts == 1)
                                {
                                    for (var day = datenow; day <= enddate; day = day.AddDays(1))
                                    {
                                        string hol = "false";
                                        if (LsholiSts == 1)
                                        {
                                            hol = objDuty.checkholiday(day, datenow, enddate);
                                            if (hol == "true")
                                            {
                                                OffCountRj = OffCountRj + 1;
                                            }
                                        }
                                        if (LSoffSts == 1 && hol != "true")
                                        {
                                            string off = objDuty.CheckDutyOff(day, OBJ.CorpOffice.ToString(), intOrgId.ToString());
                                            if (off == "true")
                                            {
                                                OffCountRj = OffCountRj + 1;
                                            }
                                        }
                                    }
                                }
                               

                        }
                        else if (LfrmDt<=objEnt.DateStartDate && LToDt>=objEnt.DateEndDate)
                        {
                          
                            DateTime datenow, enddate;
                            datenow = objEnt.DateStartDate;
                            enddate = objEnt.DateEndDate;



                            if (LsholiSts == 1 || LSoffSts == 1)
                            {
                                for (var day = datenow; day <= enddate; day = day.AddDays(1))
                                {
                                    string hol = "false";
                                    if (LsholiSts == 1)
                                    {
                                        hol = objDuty.checkholiday(day, datenow, enddate);
                                        if (hol == "true")
                                        {
                                            OffCountRj = OffCountRj + 1;
                                        }
                                    }
                                    if (LSoffSts == 1 && hol != "true")
                                    {
                                        string off = objDuty.CheckDutyOff(day, OBJ.CorpOffice.ToString(), intOrgId.ToString());
                                        if (off == "true")
                                        {
                                            OffCountRj = OffCountRj + 1;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    WorkDays = WorkDays + OffCountRj;
            }





            if (WorkDays > 0)
            {
                int daysinmonth = DateTime.DaysInMonth(OBJ.Year, OBJ.Month);


                //if (Settledays == 31)
                // {
                //     if (OBJ.Month < 12)
                //     {
                //         objEnt.DateStartDate = new DateTime(OBJ.Year, OBJ.Month + 1, 1);
                //     }
                //     else
                //     {
                //         objEnt.DateStartDate = new DateTime(OBJ.Year + 1, 1, 1);
                //     }
                // }



                if (daysinmonth < Settledays + 1)
                {
                    if (OBJ.Month < 12)
                    {
                        objEnt.DateStartDate = new DateTime(OBJ.Year, OBJ.Month + 1, ((Settledays + 1) - daysinmonth));

                    }
                    else
                    {

                        objEnt.DateStartDate = new DateTime(OBJ.Year + 1, 1, ((Settledays + 1) - daysinmonth));
                    }
                }

                else
                {
                    objEnt.DateStartDate = new DateTime(OBJ.Year, OBJ.Month, Settledays + 1);
                }

                //end


                DateTime WdATE = OBJ.date;
                decimal days = DateTime.DaysInMonth(OBJ.Year, OBJ.Month);
                days = WorkDays;
                if (dt.Rows[intRowBodyCount]["EMPERDTL_JOIN_DATE"].ToString() != "")
                {
                    DateTime JOINDATE = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["EMPERDTL_JOIN_DATE"].ToString());
                    string ddttoday = DateTime.Now.ToString("dd");
                    int JoinMonth = JOINDATE.Month,JoinYear = JOINDATE.Year,decToday = Convert.ToInt32(ddttoday),currntDay = decToday,Datechk = 0;
                    DateTime CorptSalMnthDate;
                    if (dt.Rows[intRowBodyCount]["COPRT_SALARY_DATE"].ToString() != "")
                    {
                        CorptSalMnthDate = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["COPRT_SALARY_DATE"].ToString());
                        int CorpMonth = CorptSalMnthDate.Month,CorpYear = CorptSalMnthDate.Year;
                        if (OBJ.Month == CorpMonth && OBJ.Year == CorpYear)
                        {
                            Datechk = 1;
                            if (CorptSalMnthDate.Day != 1)
                            {
                                currntDay = CorptSalMnthDate.Day - 1;
                                WorkDays = WorkDays - currntDay;
                            }
                            else
                            {
                                currntDay = CorptSalMnthDate.Day;
                            }
                            int daysgS = DateTime.DaysInMonth(OBJ.Year, OBJ.Month);
                            DateTime DtStrtDate = new DateTime();
                            if (currntDay > daysgS)
                            {
                                DtStrtDate = new DateTime(OBJ.Year, OBJ.Month, daysgS);
                            }
                            else
                            {
                                DtStrtDate = new DateTime(OBJ.Year, OBJ.Month, currntDay);
                            }
                            string strSDtrtDt = DtStrtDate.ToString("dd-MM-yyyy");
                            objEnt.DateStartDate = objCommon.textToDateTime(strSDtrtDt);
                            //check join date
                            if (OBJ.Month == JoinMonth && OBJ.Year == JoinYear)
                            {
                                WorkDays = 0;
                                currntDay = JOINDATE.Day;
                                WorkDays = (days - currntDay) + 1;
                                daysgS = DateTime.DaysInMonth(OBJ.Year, OBJ.Month);
                                if (currntDay > daysgS)
                                {
                                    objEnt.DateStartDate = new DateTime(OBJ.Year, OBJ.Month, daysgS);
                                }
                                else
                                {
                                    objEnt.DateStartDate = new DateTime(OBJ.Year, OBJ.Month, currntDay);
                                }
                            }
                        }
                    }
                    if (Datechk == 0)
                    {
                        if (OBJ.Month == JoinMonth && OBJ.Year == JoinYear)
                        {
                            WorkDays = 0;
                            currntDay = JOINDATE.Day;
                            WorkDays = (days - currntDay) + 1;
                            int daysgS = DateTime.DaysInMonth(OBJ.Year, OBJ.Month);
                            if (currntDay > daysgS)
                            {
                                objEnt.DateStartDate = new DateTime(OBJ.Year, OBJ.Month, daysgS);
                            }
                            else
                            {
                                objEnt.DateStartDate = new DateTime(OBJ.Year, OBJ.Month, currntDay);
                            }
                        }
                    }
                }
                if (dtRejoin.Rows.Count > 0 && dtRejoin.Rows[0]["DUTYREJOIN_DATE"].ToString() != "")
                {                    
                        objEnt.DateStartDate = objCommon.textToDateTime(dtRejoin.Rows[0]["DUTYREJOIN_DATE"].ToString());
                        objEnt.LeaveId = Convert.ToInt32(dtRejoin.Rows[0]["LEAVE_ID"].ToString());
                        DataTable dtRejoinLeave = objBuss.ReadRejoinLeave(objEnt);
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
                            if (dtRejoinLeave.Rows[0]["LEVSETLMT_ADDITN_AMT"].ToString() != "")
                            {
                                Allowance = Convert.ToDecimal(dtRejoinLeave.Rows[0]["LEVSETLMT_ADDITN_AMT"].ToString());
                            }
                        }
                }



                
                //Start:-For casual leave rejoin check
                int NotRejoinCasulSts = 0;
                int NotRHoliSts = 0;
                int NotROffSts = 0;
                DateTime dtNotRejStartDate = new DateTime();
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
                            }
                        }
                    }
                    else
                    {
                        NotRejoinCasulSts = 1;
                    }
                    if (NotRejoinCasulSts == 1)
                    {
                        if (dtRejoinLeaveCasual.Rows[0]["LEAVE_TO_DATE"].ToString() != "")
                        {
                            dtNotRejStartDate = objCommon.textToDateTime(dtRejoinLeaveCasual.Rows[0]["LEAVE_TO_DATE"].ToString()).AddDays(1);
                        }
                        else
                        {
                            dtNotRejStartDate = dtFromLR.AddDays(1);
                        }
                    }
                }
                if (NotRejoinCasulSts == 1)
                {
                    if (objEnt.DateEndDate.Month== dtNotRejStartDate.Month &&  dtNotRejStartDate.Year== objEnt.DateEndDate.Year)
                    {
                        int daysR = objEnt.DateEndDate.Day - dtNotRejStartDate.Day+1;
                        WorkDays = WorkDays - daysR;
                        if (WorkDays < 0)
                        {
                            WorkDays = 0;
                        }
                    }
                    if (objEnt.DateEndDate >= dtNotRejStartDate)
                    {
                        DateTime datenow, enddate;
                        enddate = objEnt.DateEndDate;
                        if (objEnt.DateStartDate < dtNotRejStartDate)
                        {
                            datenow = dtNotRejStartDate;
                            if (NotRHoliSts == 1 || NotROffSts == 1)
                            {
                                int OffCountR = 0;
                                for (var day = datenow; day <= enddate; day = day.AddDays(1))
                                {
                                    string hol = "false";
                                    if (NotRHoliSts == 1)
                                    {
                                        hol = objDuty.checkholiday(day, datenow, enddate);
                                        if (hol == "true")
                                        {
                                            OffCountR++;
                                        }
                                    }
                                    if (NotROffSts == 1 && hol != "true")
                                    {
                                        string off = objDuty.CheckDutyOff(day, OBJ.CorpOffice.ToString(), intOrgId.ToString());
                                        if (off == "true")
                                        {
                                            OffCountR++;
                                        }
                                    }
                                }
                                WorkDays += OffCountR;
                            }

                        }
                        else
                        {
                            datenow = objEnt.DateStartDate;
                            WorkDays = 0;
                            if (NotRHoliSts == 1 || NotROffSts == 1)
                            {
                                int OffCountR = 0;
                                for (var day = datenow; day <= enddate; day = day.AddDays(1))
                                {
                                    string hol = "false";
                                    if (NotRHoliSts == 1)
                                    {
                                        hol = objDuty.checkholiday(day, datenow, enddate);
                                        if (hol == "true")
                                        {
                                            OffCountR++;
                                        }
                                    }
                                    if (NotROffSts == 1 && hol != "true")
                                    {
                                        string off = objDuty.CheckDutyOff(day, OBJ.CorpOffice.ToString(), intOrgId.ToString());
                                        if (off == "true")
                                        {
                                            OffCountR++;
                                        }
                                    }
                                }
                                WorkDays += OffCountR;
                            }
                        }
                       
                       
                    }
                }
                //End:-For casual leave rejoin check

                if ((Processed == 1 && dt.Rows[intRowBodyCount]["SLPRCDMNTH_CONFRMSTS"].ToString() != "1") || Processed == 0)
                {
                    if (strPrevMnthFrom != "")
                    {
                        DateTime dtCorptDate = new DateTime();
                        if (dt.Rows[intRowBodyCount]["COPRT_SALARY_DATE"].ToString() != "")
                        {
                            dtCorptDate = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["COPRT_SALARY_DATE"].ToString());
                        }
                        DateTime dtPrevFrom = objCommon.textToDateTime(strPrevMnthFrom);
                        int preDays = DateTime.DaysInMonth(dtPrevFrom.Year, dtPrevFrom.Month);
                        DateTime dtPrevTo = new DateTime(dtPrevFrom.Year, dtPrevFrom.Month, preDays);
                        if (dtCorptDate <= dtPrevTo)
                        {
                            if (dtCorptDate > dtPrevFrom)
                            {
                                dtPrevFrom = dtCorptDate;
                            }
                            prevSal = MonthSalary(dt.Rows[intRowBodyCount][0].ToString(), dtPrevFrom, dtPrevTo, dt.Rows[intRowBodyCount]["SLRY_BASIC_PAY"].ToString(), BasicPayStatus, 0, objEnt.CorpOffice.ToString(), objEnt.Orgid.ToString(), IndvlRound, NotRHoliSts, NotROffSts);
                        }
                    }
                }


                clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
                clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
                objEntityLeavSettlmt.CorpId = OBJ.CorpOffice;
                objEntityLeavSettlmt.OrgId = Convert.ToInt32(intOrgId);
                objEntityLeavSettlmt.EmployeeId = Convert.ToInt32(dt.Rows[intRowBodyCount][0].ToString());
                if (Processed == 1)
                {
                    if (dt.Rows[intRowBodyCount]["SLPRCDMNTH_LEV_ARREAR_AMT"].ToString() != "" && dt.Rows[intRowBodyCount]["SLPRCDMNTH_LEV_ARREAR_AMT"].ToString() != null)
                    {
                        decLvArrearAmnt = Convert.ToDecimal(dt.Rows[intRowBodyCount]["SLPRCDMNTH_LEV_ARREAR_AMT"].ToString());
                        if (decLvArrearAmnt != 0)
                        {
                            if (IndvlRound == "1")
                            {
                                LvArrearLabel = "Leave Arrear :" + Math.Round(decLvArrearAmnt, 0).ToString("0.00");
                            }
                            else
                            {
                                LvArrearLabel = "Leave Arrear :" + decLvArrearAmnt.ToString("0.00");
                            }
                        }
                    }
                }
                else
                {
                    if (dt.Rows[intRowBodyCount]["BALANCE_AMOUNT"].ToString() != "" && dt.Rows[intRowBodyCount]["BALANCE_AMOUNT"].ToString() != null)
                    {
                        decLvArrearAmnt = Convert.ToDecimal(dt.Rows[intRowBodyCount]["BALANCE_AMOUNT"].ToString());
                    }
                    if (decLvArrearAmnt > 0)
                    {
                        if (IndvlRound == "1")
                        {
                            LvArrearLabel = "Leave Arrear :" + Math.Round(decLvArrearAmnt, 0).ToString("0.00");
                        }
                        else
                        {
                            LvArrearLabel = "Leave Arrear :" + decLvArrearAmnt.ToString("0.00");
                        }
                    }
                }
                decimal TtlCnt = 0, cnt = 0;
                objEnt.Employee = Convert.ToInt32(EmpId);
                int dayse = DateTime.DaysInMonth(OBJ.Year, OBJ.Month);
                objEnt.DateEndDate = new DateTime(OBJ.Year, OBJ.Month, dayse);
                DataTable dtLeaveDate = objBuss.ReadLeaveDate(objEnt);
                if (Processed == 0)
                {
                    if (radioCustType1.Checked == true && SettledLeavMssg == "" && CheckWorkerMissingAttendance(EmpId.ToString(), objEnt.DateStartDate, objEnt.DateEndDate, intCorpid.ToString(), intOrgId.ToString()) == "false")
                    {
                        SettledLeavMssg = "MISSING ATTENDANCE";
                    }
                }
                cls_Business_Monthly_Salary_Process objBuss2 = new cls_Business_Monthly_Salary_Process();
                cls_Entity_Monthly_Salary_Process objEnt2 = new cls_Entity_Monthly_Salary_Process();
                objEnt2.Employee = objEnt.Employee;
                objEnt2.DateStartDate = objEnt.DateEndDate.AddDays(1);
                objEnt2.DateEndDate = new DateTime(OBJ.Year, 12, 31);
                objEnt2.CorpOffice = objEnt.CorpOffice;
                objEnt2.Orgid = objEnt.Orgid;
                DataTable dtLeaveDateFuture = new DataTable();
                if (objEnt2.DateStartDate.Year == objEnt2.DateEndDate.Year)
                {
                    dtLeaveDateFuture = objBuss2.ReadLeaveDate(objEnt2);
                }
                string[] stringArray = new string[50];
                int CurrArray = 0;       
                 if (strDecision != "Not rejoined"){
                for (int lcnt = 0; lcnt < dtLeaveDate.Rows.Count; lcnt++)
                {
                    int HoliPaidSts = Convert.ToInt32(dtLeaveDate.Rows[lcnt]["LEAVETYP_HOLIDAY_PAID_STS"].ToString());
                    int OffPaidSts = Convert.ToInt32(dtLeaveDate.Rows[lcnt]["LEAVETYP_OFFDAY_PAID_STS"].ToString());

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

                        objEnt.LeaveId = Convert.ToInt32(dtLeaveDate.Rows[lcnt]["LEAVE_ID"].ToString());
                        dtRejoin = objBuss.ReadRejoinDate(objEnt);
                        if (dtRejoin.Rows.Count > 0)
                        {
                            if (dtRejoin.Rows[0]["DUTYREJOIN_DATE"].ToString() != "")
                            {
                                if (objCommon.textToDateTime(dtRejoin.Rows[0]["DUTYREJOIN_DATE"].ToString()) < LToDt)
                                {
                                    LToDt = objCommon.textToDateTime(dtRejoin.Rows[0]["DUTYREJOIN_DATE"].ToString()).AddDays(-1);
                                }
                            }
                        }
                    }
                    if (LfrmDt != DateTime.MinValue && LToDt != DateTime.MinValue)
                    {
                        int LvFrmMonth = LfrmDt.Month;
                        int LvFrmYear = LfrmDt.Year;
                        int LvFrmDay = LfrmDt.Day;
                        int LvToMonth = LToDt.Month;
                        int LvToYear = LToDt.Year;
                        int LvToDay = LToDt.Day;

                        if (LvFrmYear == OBJ.Year && LvFrmMonth == OBJ.Month && LvToYear == OBJ.Year && LvToMonth == OBJ.Month)
                        {

                            cnt = LvToDay - LvFrmDay + 1;
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
                                    if (OffPaidSts==1 && hol != "true")
                                    {
                                        string off = objDuty.CheckDutyOff(day, OBJ.CorpOffice.ToString(), intOrgId.ToString());
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
                        else if (LvToYear == OBJ.Year && LvToMonth == OBJ.Month)
                        {

                            if (LvToDay > days)
                            {
                                cnt = days;
                            }
                            else
                            {
                                cnt = LvToDay;
                            }
                            if (dtLeaveDate.Rows[lcnt]["LEAVE_TO_SCTN"].ToString() != "1")
                            {
                                cnt = cnt - (decimal)0.5;
                            }


                            DateTime datenow, enddate;
                            datenow = objEnt.DateStartDate;
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
                                        string off = objDuty.CheckDutyOff(day, OBJ.CorpOffice.ToString(), intOrgId.ToString());
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
                                    if (stringArray[i].Contains(stringToCheck))
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
                        else if (LvFrmYear == OBJ.Year && LvFrmMonth == OBJ.Month)
                        {
                            if (LvFrmDay <= days)
                            {
                                cnt = days - LvFrmDay + 1;
                                if (dtLeaveDate.Rows[lcnt]["LEAVE_FROM_SCTN"].ToString() != "1")
                                {
                                    cnt = cnt - (decimal)0.5;
                                }


                                DateTime datenow, enddate;
                                datenow = LfrmDt;
                                enddate = objEnt.DateEndDate;
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
                                            string off = objDuty.CheckDutyOff(day, OBJ.CorpOffice.ToString(), intOrgId.ToString());
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
                                        if (stringArray[i].Contains(stringToCheck))
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
                        else //if (LvFrmYear <= OBJ.Year && LvFrmMonth < OBJ.Month && LvToYear >= OBJ.Year && LvToMonth > OBJ.Month)
                        {
                            cnt = objEnt.DateEndDate.Day - objEnt.DateStartDate.Day + 1;
                            if (dtLeaveDate.Rows[lcnt]["LEAVE_FROM_SCTN"].ToString() != "1")
                            {
                                cnt = cnt - (decimal)0.5;
                            }
                            if (dtLeaveDate.Rows[lcnt]["LEAVE_TO_SCTN"].ToString() != "1")
                            {
                                cnt = cnt - (decimal)0.5;
                            }

                            DateTime datenow, enddate;
                            datenow = objEnt.DateStartDate;
                            enddate = objEnt.DateEndDate;



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
                                        string off = objDuty.CheckDutyOff(day, OBJ.CorpOffice.ToString(), intOrgId.ToString());
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
                        if (LvFrmYear == OBJ.Year && LvFrmMonth == OBJ.Month)
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
                                    if (stringArray[i].Contains(stringToCheck))
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
                if (BasicPayStatus == 0 && joinMnthSts==0)
                {
                    WorkDaysBasic = dtdays;
                }
                else
                {
                    WorkDaysBasic = WorkDays - TtlCnt;
                }
                //No working day 
                if (WorkDays - TtlCnt == 0)
                {
                    WorkDaysBasic = 0;
                }
                WorkDays = WorkDays - TtlCnt;
            }
            HiddenAllwnc.Value = "";
            HiddenDeduction.Value = "";
            string TOTALaLLOW = "0";

           
            int FixedZeroWorkdaySts=1;
            if (HiddenFieldWorkdayFixedPayrlMode.Value == "0" && WorkDays <= 0)
            {
                FixedZeroWorkdaySts = 0;
                WorkDaysBasic = 0;
            }
            if (HiddenFieldWorkdayFixedPayrlMode.Value == "1" && WorkDays <= 0)
            {
                joinMnthSts = 0;
                if (BasicPayStatus == 0)
                {
                    WorkDaysBasic = dtdays;
                }
            }
            int fixAlloSetSts = 0;
            if (SettlemtntDate != DateTime.MinValue && SettlemtntDate.Month == objEnt.DateStartDate.Month && SettlemtntDate.Year == objEnt.DateStartDate.Year)
            {
                fixAlloSetSts = 1;
                if (BasicPayStatus == 0 && joinMnthSts == 0)
                {
                    WorkDaysBasic = 0;
                }
            }
            if (FixedZeroWorkdaySts > 0)
            {
                TOTALaLLOW = SalarySummary(dtAllowSal, AllwOrDed, WorkDays, dtdays, Settledays, FixedAllowance, LeaveToDate, dtRejoin, Allowance, DtSettleAfterLeaveInfo, LvSettleMode, Addition, daysInMonth, joinMnthSts, fixAlloSetSts);
            }
            Decimal TOtalPay = 0;
            if (TOTALaLLOW != "")
            {
                TOtalPay = Convert.ToDecimal(TOTALaLLOW) + BASICPAY;
            }
            //DEDUCTION CAL
            AllwOrDed = "1";
            Decimal TotalDedcn = 0;
            if (Processed == 1)
            {
                dtDedctnSal = objBuss.ReadDeductionListPrssTable(objEnt);
            }
            else
            {
                dtDedctnSal = objBuss.ReadDeductionList(objEnt);
            }
            string TOTALDEDCTN = "0";
            if (FixedZeroWorkdaySts > 0)
            {
                TOTALDEDCTN = SalarySummary(dtDedctnSal, AllwOrDed, WorkDays, dtdays, Settledays, FixedAllowance, LeaveToDate, dtRejoin, Allowance, DtSettleAfterLeaveInfo, LvSettleMode, Addition, daysInMonth, joinMnthSts, fixAlloSetSts);
            }
            TotalDedcn = Convert.ToDecimal(TOTALDEDCTN);
            string PERDEDCTN = "";
            if (FixedZeroWorkdaySts > 0)
            {
                PERDEDCTN = SalaryPerctTotal(dtDedctnSal, TOTALaLLOW, BASICPAY, WorkDays, dtdays, Settledays, daysInMonth, joinMnthSts, fixAlloSetSts);
            }
            if (PERDEDCTN != "")
            {
                TotalDedcn = TotalDedcn + Convert.ToDecimal(PERDEDCTN);
            }
            //deduction by instalment
            decimal DedctionInstalment = 0;
            if (strDecision == "")
            {
                DataTable dtPaymentDedctn = objBuss.ReadPaymenDeductionList(objEnt);
                if (dtPaymentDedctn.Rows.Count > 0 && dtPaymentDedctn.Rows[0]["AMOUNT"].ToString() != "")
                {
                    DedctionInstalment = Convert.ToDecimal(dtPaymentDedctn.Rows[0]["AMOUNT"].ToString());
                }
            }
            //daily hour
            dtAllowDailyhr = objBuss.ReadAllounceDailyhrList(objEnt);
            decimal TotalAllowancw = 0;
            if (dtAllowDailyhr.Rows.Count > 0 && dtAllowDailyhr.Rows[0]["OVERTIMEAMOUNT"].ToString() != "" && strDecision == "")
            {
              try
              {
                decimal deciHourlySalary = (BASICPAY / dtdays) / 8;
                TotalAllowancw = TotalAllowancw + (Convert.ToDecimal(dtAllowDailyhr.Rows[0]["OVERTIMEAMOUNT"].ToString()) * deciHourlySalary);
              }
              catch (Exception)
              {
              }
            }
            if (WorkDays >= 0)
            {
                if (OBJ.SavConf != 1)
                {
                    if (SettledLeavMssg == "SETTLEMENT PENDING")
                    {
                        sb.Append("<td class=\"tdT\" style=\" width:2.5%;word-break: break-all; word-wrap:break-word;text-align: left;\" > <label class=\"checkbox\" ><input disabled type=\"checkbox\" onkeypress='return DisableEnter(event)'  onchange='return changeSingle();'  value=\"" + objEnt.Employee + "\" id=\"cbMandatory" + intRowBodyCount + "\"><i  style=\"margin-left: 30%;\"></i></label></td>");
                    }
                    else if (SettledLeavMssg == "MISSING ATTENDANCE")
                    {
                        sb.Append("<td class=\"tdT\" style=\" width:2.5%;word-break: break-all; word-wrap:break-word;text-align: left;\" > <label class=\"checkbox\" ><input disabled type=\"checkbox\" onkeypress='return DisableEnter(event)'  onchange='return changeSingle();'  value=\"" + objEnt.Employee + "\" id=\"cbMandatory" + intRowBodyCount + "\"><i  style=\"margin-left: 30%;\"></i></label></td>");
                    }
                    else
                    {
                        HiddenFieldActiveCbxCnt.Value = "1";
                        sb.Append("<td class=\"tdT\" style=\" width:2.5%;word-break: break-all; word-wrap:break-word;text-align: left;\" > <label class=\"checkbox\" ><input type=\"checkbox\" onkeypress='return DisableEnter(event)'  onchange='return changeSingle();'  value=\"" + objEnt.Employee + "\" id=\"cbMandatory" + intRowBodyCount + "\"><i  style=\"margin-left: 30%;\"></i></label></td>");
                    }
                } 
                string EditVw = "";
                if (dt.Rows[intRowBodyCount][1].ToString() != "")
                {
                    EditVw += dt.Rows[intRowBodyCount][1].ToString() + "-" + dt.Rows[intRowBodyCount][2].ToString() + "|" + dt.Rows[intRowBodyCount][3].ToString() + "|" + dt.Rows[intRowBodyCount][4].ToString();
                }
                else
                {
                    EditVw += dt.Rows[intRowBodyCount][2].ToString() + "|" + dt.Rows[intRowBodyCount][3].ToString() + "|" + dt.Rows[intRowBodyCount][4].ToString();
                }   
                sb.Append("<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][1].ToString() + "</td>");
                
                //emp-0043 start
                string PaymentType = dt.Rows[intRowBodyCount]["EMPERDTL_PAYMENT_STS"].ToString();
                if (PaymentType == "1")
                {
                    sb.Append("<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][2].ToString() + "<img title=\"Cash\"src='/Images/Icons/csh.png'></img></td>");
                }
                else
                {
                    sb.Append("<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][2].ToString() + "</td>");
                }
                if (OBJ.SavConf == 1)
                {
                    if (dt.Rows[intRowBodyCount]["SLRPRCDMNTH_PAYMENT_TYPE"].ToString() == "1")
                    {
                        sb.Append("<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][2].ToString() + "<img title=\"Cash\" src='/Images/Icons/csh.png'></img></td>");
                    }
                }
                //end 
                sb.Append("<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][3].ToString() + "</td>");
                sb.Append("<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][4].ToString() + "</td>");                   
                if (TOTALaLLOW == "")
                {
                    TOTALaLLOW = "0";
                }
                else
                {
                    TOTALaLLOW = Convert.ToDecimal(TOTALaLLOW).ToString("0.00");
                }
                //calculation based on working days
                int bDays = DateTime.DaysInMonth(OBJ.Year, OBJ.Month);
                if (Settledays > 0)
                {
                    decimal oneDayBasicPay = BASICPAY / daysInMonth;                    
                    int dtSetlmentDay = daysInMonth - Settledays;
                    BASICPAY = oneDayBasicPay * dtSetlmentDay;
                }
                decimal BasicPay = 0;
                decimal TOTALaLLOWPerDay = Convert.ToDecimal(dt.Rows[intRowBodyCount]["SLRY_BASIC_PAY"].ToString()) / daysInMonth;
                BasicPay = TOTALaLLOWPerDay * WorkDaysBasic;
                string strBasicPay = Math.Round(BasicPay, 2).ToString();
                decimal TemTotal = BasicPay + Convert.ToDecimal(TOTALaLLOW);
                TemTotal = TemTotal - TotalDedcn;
                Decimal ToDedction = TotalDedcn + DedctionInstalment + MessDedctn + decLvArrearAmnt;
                decimal Allow =Convert.ToDecimal(TOTALaLLOW) + TotalAllowancw;
                decimal TotalAmount = prevSal+TemTotal + TotalAllowancw + decOtherAddtionAmount + Arrearamount - decOtherDeductionAmount - DedctionInstalment - MessDedctn - decLvArrearAmnt;
                HiddenBasicSalary.Value = HiddenBasicSalary.Value + "," + PrcssId + "-" + strBasicPay;
                //dtOther_Addition

                int decRound = 0;
                if (IndvlRound == "0")
                {
                    decRound = 2;
                }
                sb.Append("<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + Math.Round(Convert.ToDecimal(strBasicPay), decRound).ToString("0.00") + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>");
                sb.Append("<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + Math.Round(TotalAllowancw, decRound).ToString("0.00") + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>");
                sb.Append("<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + Math.Round(Convert.ToDecimal(TOTALaLLOW), decRound).ToString("0.00") + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>");
                sb.Append("<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + Math.Round(decOtherAddtionAmount, decRound).ToString("0.00") + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString());
                if (decOtherAddtionAmount != 0)
                {
                    sb.Append("<a href=\"javascript:;\" title=\"Info\" onclick=\"return OtherAdd_Ded_Display('" + PAYINF_ID + "','" + objEnt.Employee + "',1);\" class=\"pull-right\" > <i class=\"fa fa-info-circle ad_fa\"></i> </a> ");
                }
                sb.Append("</td>");

                sb.Append("<td class=\"tdT\" style=\"width:8%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + Math.Round(prevSal, decRound).ToString("0.00") + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>");

                sb.Append("<td class=\"tdT\" style=\"width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + Math.Round(DedctionInstalment, decRound).ToString("0.00") + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>");
                if (MessLabel != "")
                {
                    MessLabel = "(" + MessLabel + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + ")";
                }
                if (LvArrearLabel != "")
                {
                    LvArrearLabel = "(" + LvArrearLabel + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + ")";
                }
                sb.Append("<td class=\"tdT\" style=\"width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + Math.Round(TotalDedcn, decRound).ToString("0.00") + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "<section style=\"margin-top: 7%;color: #5d5dfe;font-size: 87%;\"> " + MessLabel + " </section><section style=\"margin-top: 7%;color: #5d5dfe;font-size: 87%;display: none;\"> " + LvArrearLabel + " </section></td>");
                sb.Append("<td class=\"tdT\" style=\"width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + Math.Round(decOtherDeductionAmount, decRound).ToString("0.00") + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "");
                if (decOtherDeductionAmount != 0)
                {
                    sb.Append("<a href=\"javascript:;\" title=\"Info\" onclick=\"return OtherAdd_Ded_Display('" + PAYINF_ID + "','" + objEnt.Employee + "',2);\" class=\"pull-right\" > <i class=\"fa fa-info-circle ad_fa\"></i> </a> ");
                }
                sb.Append("</td>");
                sb.Append("<td class=\"tdT\" style=\"width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + Math.Round(decLvArrearAmnt, decRound).ToString("0.00") + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "<section style=\"margin-top: 7%;color: #5d5dfe;font-size: 87%;\">  </section><section style=\"margin-top: 7%;color: #5d5dfe;font-size: 87%;\">  </section></td>");
                if (SettledLeavMssg != "")
                    sb.Append("<td class=\"tdT\" style=\"width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + Math.Round(TotalAmount, 0).ToString("0.00") + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + " <section style=\"margin-top: 7%;color: #5d5dfe;font-size: 87%;\"> " + SettledLeavMssg + " </section><section style=\"margin-top: 7%;color: #5d5dfe;font-size: 87%;\"> " + ArriarLable + "</section></td>");
                else
                    sb.Append("<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + Math.Round(TotalAmount, 0).ToString("0.00") + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "<section style=\"margin-top: 7%;color: #5d5dfe;font-size: 87%;\"> " + ArriarLable + "</section></td>");




                if (Processed == 1 && OBJ.SavConf == 0 && HiddenRoleConf.Value == "1")
                {
                    sb.Append("<td style=\" width:2.5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\" title=\"Edit\"   onclick=\"return EditRow(" + EmpId + "," + dt.Rows[0]["PYGRD_ID"].ToString() + "," + BASICPAY + "," + PrcssId + "," + intRowBodyCount + ");\"><i class=\"fa fa-pencil\"></i></button></td>");
                    sb.Append("<td style=\" width:2.5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\" title=\"Delete\"   onclick=\"return DeleteRow(" + PrcssId + ");\"><i class=\"fa fa-trash\"></i></button></td>");
                }
                string AddAndDedctn = TotalAllowancw.ToString() + "|" + DedctionInstalment.ToString() + "|" + TOTALaLLOW.ToString() + "|" + TotalDedcn.ToString() + "|" + BASICPAY + "|" + HiddenAllwnc.Value + "|" + HiddenDeduction.Value + "|" + strBasicPay + "|" + dt.Rows[intRowBodyCount]["PYGRD_ID"].ToString();
                string passingvalues = TotalAmount.ToString() + "|" + PrcssId + "|" + TotalnumLeav;
                sb.Append("<td class=\"tdT\"  style=\"word-break: break-all; word-wrap:break-word;text-align: left;display:none\" > <input type=\"text\"   value=\"" + passingvalues + "\" id=\"Totalamt" + intRowBodyCount + "\"></td>");
                sb.Append("<td class=\"tdT\"  style=\"word-break: break-all; word-wrap:break-word;text-align: left;display:none\" > <input type=\"text\"   value=\"" + AddAndDedctn + "\" id=\"TotalaLLOWdEDCTN" + intRowBodyCount + "\"></td>");
                EditVw += "|" + HiddenEditView.Value;
                sb.Append("<td class=\"tdT\"  style=\"word-break: break-all; word-wrap:break-word;text-align: left;display:none\" > <input type=\"text\"   value=\"" + EditVw + "\" id=\"HiddEditView" + intRowBodyCount + "\"></td>");
                sb.Append("<td class=\"tdT\"  style=\"word-break: break-all; word-wrap:break-word;text-align: left;display:none\" > <input type=\"text\"   value=\"" + MessDedctn + "\" id=\"TotalMessDedctn" + intRowBodyCount + "\"></td>");
                sb.Append("<td class=\"tdT\"  style=\"word-break: break-all; word-wrap:break-word;text-align: left;display:none\" > <input type=\"text\"   value=\"" + decLvArrearAmnt + "\" id=\"TotalLvArrearAmt" + intRowBodyCount + "\"></td>");
                sb.Append("<td class=\"tdT\"  style=\"word-break: break-all; word-wrap:break-word;text-align: left;display:none\" > <input type=\"text\"   value=\"" + decOtherAddtionAmount + "\" id=\"TotalOtherAddtionAmt" + intRowBodyCount + "\"></td>");
                sb.Append("<td class=\"tdT\"  style=\"word-break: break-all; word-wrap:break-word;text-align: left;display:none\" > <input type=\"text\"   value=\"" + decOtherDeductionAmount + "\" id=\"TotalDeductionAmt" + intRowBodyCount + "\"></td>");
                sb.Append("<td class=\"tdT\"  style=\"word-break: break-all; word-wrap:break-word;text-align: left;display:none\" > <input type=\"text\"   value=\"" + prevSal + "\" id=\"PrevMnthArrearAmt" + intRowBodyCount + "\"></td>");
                sb.Append("<td class=\"tdT\"  style=\"word-break: break-all; word-wrap:break-word;text-align: left;display:none\" > <input type=\"text\"   value=\"" + strPrevMnthFrom + "\" id=\"PrevRejoinDate" + intRowBodyCount + "\"></td>");
                
                sb.Append("<input type=\"hidden\" id=\"hiddenmonth\" value=\"" + objEnt.Month + "\" >");
                sb.Append("<input type=\"hidden\" id=\"hiddenyear\" value=\"" + objEnt.Year + "\" >");
                sb.Append("</tr>");
            }
        }
        sb.Append("</tbody>");
        sb.Append("</table>");
        return sb.ToString();
    }
    public decimal MonthSalary(string strEmpId, DateTime dtFromDate, DateTime dtToDate, string strBasicPay, int BasicPayStatus, int FixedSts, string strCorp, string Org, string IndividualRound,int holiSts,int offSts)
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

            DataTable dtAllownce = objBusinessLeavSettlmt.ReadAllowance(objEntityLeavSettlmt);
            DataTable dtDeductn = objBusinessLeavSettlmt.ReadDeduction(objEntityLeavSettlmt);


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



            if (TotalDays > TotalLeaveCnt)
            {
                //Basic pay calculation       
                if (strBasicPay != "")
                {
                    decBasicPay = Convert.ToDecimal(strBasicPay) / daysInm;
                    if (BasicPayStatus == 0)
                    {
                        if (HiddenFieldWorkdayFixedPayrlMode.Value == "0")
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
                            if (HiddenFieldWorkdayFixedPayrlMode.Value== "0")
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
                                if (HiddenFieldWorkdayFixedPayrlMode.Value == "0")
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
                                if (HiddenFieldWorkdayFixedPayrlMode.Value == "0")
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
                                if (HiddenFieldWorkdayFixedPayrlMode.Value == "0")
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



    public string SalaryPerctTotal(DataTable dt, string alwance, decimal BASICPAY, decimal WorkDays, int days, int Settledays, int daysInMonth, int joinMnthSts, int fixAlloSetSts)
    {
        string strStatusMode = "", deductn=""; decimal perctotalFromTotal = 0, perctotalFromBasic = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            decimal DecDeductionbasicPay = 0, DecDeductionTotlPay = 0;
            strStatusMode = dt.Rows[intRowBodyCount][4].ToString();
            int PerORAmntchk = 0, TotalAmountBsic = 1;
            PerORAmntchk = Convert.ToInt32(dt.Rows[intRowBodyCount]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString());
            TotalAmountBsic = Convert.ToInt32(dt.Rows[intRowBodyCount]["SLRYDEDTN_BASIC_OR_TOTAL_AMNT"].ToString());           
                if (PerORAmntchk == 1)
                {
                        if (strStatusMode == "ACTIVE" || strStatusMode == "1")
                        {
                            if (TotalAmountBsic == 1)
                            {
                                if (dt.Rows[intRowBodyCount]["PAYRL_TYPE_STS"].ToString() == "0" &&  joinMnthSts == 0)
                                {
                                    if (fixAlloSetSts == 0)
                                    {
                                        if (Settledays > 0)
                                        {
                                            int DtSettledays = 30 - Settledays;
                                            DecDeductionTotlPay = Convert.ToDecimal(dt.Rows[intRowBodyCount][3].ToString());
                                        }
                                        else
                                        {
                                            DecDeductionTotlPay = Convert.ToDecimal(dt.Rows[intRowBodyCount][3].ToString());
                                        }
                                        DecDeductionTotlPay = (BASICPAY + Convert.ToDecimal(alwance)) * (DecDeductionTotlPay / 100);
                                    }
                                }
                                else
                                {
                                    DecDeductionTotlPay = Convert.ToDecimal(dt.Rows[intRowBodyCount][3].ToString());
                                   

                                    DecDeductionTotlPay = (BASICPAY + Convert.ToDecimal(alwance)) * (DecDeductionTotlPay / 100);
                                    decimal AmtOneDay = 1;
                                    if (days != 0)
                                    {
                                        AmtOneDay = DecDeductionTotlPay / daysInMonth;

                                    }


                                    DecDeductionTotlPay = AmtOneDay * WorkDays;

                                }
                            }
                            else if (TotalAmountBsic == 0)
                            {
                                if (dt.Rows[intRowBodyCount]["PAYRL_TYPE_STS"].ToString() == "0" &&  joinMnthSts == 0)
                                {
                                    if (fixAlloSetSts == 0)
                                    {
                                        if (Settledays > 0)
                                        {
                                            int DtSettledays = 30 - Settledays;
                                            DecDeductionbasicPay = Convert.ToDecimal(dt.Rows[intRowBodyCount][3].ToString());
                                        }
                                        else
                                        {
                                            DecDeductionbasicPay = Convert.ToDecimal(dt.Rows[intRowBodyCount][3].ToString());
                                        }
                                        DecDeductionbasicPay = BASICPAY * (DecDeductionbasicPay / 100);
                                    }
                                }
                                else
                                {
                                    DecDeductionbasicPay = Convert.ToDecimal(dt.Rows[intRowBodyCount][3].ToString());                                
                                    DecDeductionbasicPay = BASICPAY * (DecDeductionbasicPay / 100);
                                    decimal AmtOneDay = 1;
                                    if (days != 0)
                                    {
                                        AmtOneDay = DecDeductionbasicPay / daysInMonth;
                                    }
                                    DecDeductionbasicPay = AmtOneDay * WorkDays;
                                }
                            }
                        }
                }
            perctotalFromTotal += DecDeductionTotlPay;
            perctotalFromBasic += DecDeductionbasicPay;
            if (DecDeductionbasicPay != 0)
                deductn = dt.Rows[intRowBodyCount]["PGDEDTN_ID"].ToString() + "-" + DecDeductionbasicPay.ToString();         
            HiddenDeduction.Value = HiddenDeduction.Value + "," + deductn;
        }
        decimal decPerTotal = perctotalFromTotal + perctotalFromBasic;
        return decPerTotal.ToString();
    }
    public string SalarySummary(DataTable dt, string AllwOrDed, decimal WorkDays, int days, int Settledays, int FixedAllowance, DateTime LeaveToDate, DataTable dtRejoin1, decimal Allowance, DataTable DtSettleAfterLeaveInfo, int LvSettleMode, string Addition, int daysInMonth, int joinMnthSts, int fixAlloSetSts)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        Decimal totalAmntFrm = 0,perctotal = 0;
        int count = 0;
        var strStatusMode = "";
        DateTime dtRJoin=new DateTime();
        int AllowanceFlag = 0;
        string allwnc = "";
        string deductn = "";      
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            decimal DecAlwnceAmt = 0;
            strStatusMode = dt.Rows[intRowBodyCount]["STATUS"].ToString();           
            if (AllwOrDed == "0")
            {
                        if (strStatusMode == "ACTIVE" || strStatusMode == "1")
                        {
                            count++;
                            string strNetAmount = dt.Rows[intRowBodyCount][2].ToString();

                            if (dt.Rows[intRowBodyCount]["PAYRL_TYPE_STS"].ToString() == "0" && joinMnthSts==0) //fixed
                            {
                                if (fixAlloSetSts == 0)
                                {
                                    if (Settledays > 0)
                                    {
                                        int DtSettledays = 30 - Settledays;
                                        decimal AmtOneDay = 1;
                                        if (LvSettleMode == 0 && Addition == "")
                                        {
                                            DecAlwnceAmt = Convert.ToDecimal(dt.Rows[intRowBodyCount][2].ToString());
                                        }
                                        if (FixedAllowance == 1)
                                        {
                                            if (dtRejoin1.Rows.Count > 0)
                                            {
                                                if (dtRejoin1.Rows[0]["DUTYREJOIN_DATE"].ToString() != "")
                                                {
                                                    dtRJoin = objCommon.textToDateTime(dtRejoin1.Rows[0]["DUTYREJOIN_DATE"].ToString());
                                                    string strRjoin = dtRJoin.ToString("MM");
                                                    if (LeaveToDate != DateTime.MinValue)
                                                    {
                                                        string strLeave = LeaveToDate.ToString("MM");
                                                        if (Convert.ToInt32(strRjoin) > Convert.ToInt32(strLeave))
                                                        {
                                                            if (AllowanceFlag == 0)
                                                            {
                                                                DecAlwnceAmt = DecAlwnceAmt - Allowance;
                                                                AllowanceFlag++;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        DecAlwnceAmt = Convert.ToDecimal(dt.Rows[intRowBodyCount][2].ToString());
                                    }
                                }
                            }
                            else// Variable
                            {
                                DecAlwnceAmt = Convert.ToDecimal(dt.Rows[intRowBodyCount][2].ToString());
                                decimal AmtOneDay = 1;
                                if (days != 0)
                                {
                                    AmtOneDay = DecAlwnceAmt / daysInMonth;
                                }
                                DecAlwnceAmt = AmtOneDay * WorkDays;    
                            }
                        }
                    //}
                    if(DecAlwnceAmt!=0)
                        allwnc = dt.Rows[intRowBodyCount]["PGALLCE_ID"].ToString() + "-" + DecAlwnceAmt.ToString();
                //}
                HiddenAllwnc.Value = HiddenAllwnc.Value + "," + allwnc;
            }
            else if (AllwOrDed == "1")
            {
                int PerORAmntchk = 0;
                PerORAmntchk = Convert.ToInt32(dt.Rows[intRowBodyCount]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString());
                    if (PerORAmntchk == 0)
                    {
                            if (strStatusMode == "ACTIVE" || strStatusMode == "1")
                            {
                                count++;
                                if (dt.Rows[intRowBodyCount]["PAYRL_TYPE_STS"].ToString() == "0" &&  joinMnthSts == 0)
                                {
                                    //if (Settledays > 0)
                                    //{
                                    //}
                                    //else
                                    //{
                                    if (fixAlloSetSts == 0)
                                    {
                                        DecAlwnceAmt = Convert.ToDecimal(dt.Rows[intRowBodyCount][2].ToString());
                                    }
                                    //}
                                }
                                else
                                {
                                    DecAlwnceAmt = Convert.ToDecimal(dt.Rows[intRowBodyCount][2].ToString());

                                    decimal AmtOneDay = 1;
                                    if (days != 0)
                                    {
                                        AmtOneDay = DecAlwnceAmt / daysInMonth;

                                    }


                                    DecAlwnceAmt = AmtOneDay * WorkDays;
                                }
                            }
                    }
                    else if (PerORAmntchk == 1)
                    {
                            if (strStatusMode == "ACTIVE" || strStatusMode == "1")
                            {
                                perctotal = perctotal + Convert.ToDecimal(dt.Rows[intRowBodyCount][3].ToString());
                            }
                    }
                    if (DecAlwnceAmt != 0)
                        deductn = dt.Rows[intRowBodyCount]["PGDEDTN_ID"].ToString() + "-" + DecAlwnceAmt.ToString();
                HiddenDeduction.Value = HiddenDeduction.Value + "," + deductn;
            }
            totalAmntFrm += DecAlwnceAmt;
        }
        //string stramntSummary = "0";
        //string NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(totalAmntFrm.ToString(), objEntityCommon);   
        //stramntSummary = NetAmountWithCommaFrm;
        //return stramntSummary;
        return totalAmntFrm.ToString();
    }
    protected void btnPrss_Click(object sender, EventArgs e)
    {
        Session["SALARPRSS"] = null;
        int intOrgId = 0;
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        int intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
        cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEnt.Orgid = intOrgId;
        objEnt.date = DateTime.MinValue;
        objEnt.UserId = intUserId;
        objEnt.date = objCommon.textToDateTime(Hiddentxtefctvedate.Value);
        objEnt.CorpOffice = Convert.ToInt32(ddlBussunit.SelectedItem.Value);
        objEnt.Month = Convert.ToInt32(ddlMonth.SelectedItem.Value);
        objEnt.Year = Convert.ToInt32(ddlyear.SelectedItem.Value);
        if (radioCustType2.Checked == true)
        {
            objEnt.StffWrkr = 0;
        }
        else if (radioCustType1.Checked == true)
        {
            objEnt.StffWrkr = 1;
        }
        if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
        {
            objEnt.Division = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        }
        if (ddlDep.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEnt.Dep = Convert.ToInt32(ddlDep.SelectedItem.Value);
        }
        if (ddldesg.SelectedItem.Value != "--SELECT DESIGNATION--")
        {
            objEnt.Desg = Convert.ToInt32(ddldesg.SelectedItem.Value);
        }
        List<cls_Entity_Monthly_Salary_Process> objEmpList = new List<cls_Entity_Monthly_Salary_Process>();
        List<cls_Entity_Monthly_Salary_Process> objEmpListAllwnc = new List<cls_Entity_Monthly_Salary_Process>();
        List<cls_Entity_Monthly_Salary_Process> objEmpListDeductn = new List<cls_Entity_Monthly_Salary_Process>();
        string[] empChecked = HiddenFieldCheckEmp.Value.Split(',');
        string[] empMessAmnt = HiddenDedctnMessAmount.Value.Split('/');
        string[] empLvArrearAmnt = HiddenFieldLeaveArrearAmt.Value.Split('/');
        string[] empTotAmount = HiddenAmount.Value.Split(',');
        string[] SpecialAmount = HiddenFieldSpecialAmount.Value.Split('/');
        string[] empOtherAdditionAmnt = hiddenOtherAdditionAmt.Value.Split('/');
        string[] empOtherDeductionAmnt = hiddenOtherDeductionAmt.Value.Split('/');
        string[] empPrevArrAmnt = hiddenPrevArrAmt.Value.Split('/');

        int i = 0;
        decimal decamtAndid=0;
        for(int k=0;k<empChecked.Length;k++)
        {
            DateTime dtMonth = new DateTime();
            DateTime dtRejoin = new DateTime();
            if (empChecked[k] != "" && empChecked[k] != null)
            {
                cls_Entity_Monthly_Salary_Process objEmpval = new cls_Entity_Monthly_Salary_Process();
                objEmpval.Employee = Convert.ToInt32(empChecked[k]);
                string[] amtAndid = empTotAmount[i].Split('|');
                string[] amtAddnDedctn = SpecialAmount[i].Split('|');
                decamtAndid = Convert.ToDecimal(amtAndid[0]);
                objEmpval.TotMount = Convert.ToDecimal(amtAndid[0]);
                if (amtAndid[2] != "" && amtAndid[2].Contains("-")==false)
                objEmpval.NumLeav = Convert.ToInt32(amtAndid[2]);
                if (amtAddnDedctn[0] != "")
                    objEmpval.AllowOverTmAmnt = Convert.ToDecimal(amtAddnDedctn[0]);
                if (amtAddnDedctn[1] != "")
                    objEmpval.InstalAmount = Convert.ToDecimal(amtAddnDedctn[1]);
                if (amtAddnDedctn[2] != "")
                    objEmpval.SpecialAllAmnt = Convert.ToDecimal(amtAddnDedctn[2]);
                if (amtAddnDedctn[3] != "")
                    objEmpval.SpecialDedAmnt = Convert.ToDecimal(amtAddnDedctn[3]);
                if (amtAddnDedctn[4] != "")
                    objEmpval.BasicPay = Convert.ToDecimal(amtAddnDedctn[4]);
                if (amtAddnDedctn[5] != "")
                {
                    string[] EmpAllwnce = amtAddnDedctn[5].Split(',');
                    for(int j=0;j<EmpAllwnce.Length;j++)
                    {                      
                        if (EmpAllwnce[j] != "" && EmpAllwnce[j] != "0" && EmpAllwnce[j] != null)
                        {
                            cls_Entity_Monthly_Salary_Process objEmpAllwnce = new cls_Entity_Monthly_Salary_Process();
                            string[] strAllwnceId = EmpAllwnce[j].Split('-');
                            objEmpAllwnce.ProcessAllwnceID = Convert.ToInt32(strAllwnceId[0]);
                            objEmpAllwnce.ProcessedAllwncAmt = Convert.ToDecimal(strAllwnceId[1]);
                            objEmpAllwnce.Employee = Convert.ToInt32(empChecked[k]);
                            if (amtAddnDedctn[8] != "")
                            {
                                objEmpAllwnce.PayGradeID = Convert.ToInt32(amtAddnDedctn[8]);
                            }
                            objEmpListAllwnc.Add(objEmpAllwnce);
                        }                        
                    }  
                }
                if (amtAddnDedctn[6] != "")
                {
                    string[] EmpDeductn = amtAddnDedctn[6].Split(',');
                    for (int j = 0; j < EmpDeductn.Length;j++)
                    {
                        if (EmpDeductn[j] != "" && EmpDeductn[j] != "0" && EmpDeductn[j] != null)
                        {
                            cls_Entity_Monthly_Salary_Process objEmpDedutn = new cls_Entity_Monthly_Salary_Process();
                            string[] strDedutnId = EmpDeductn[j].Split('-');
                            objEmpDedutn.ProcessDeductneID = Convert.ToInt32(strDedutnId[0]);
                            objEmpDedutn.ProcessedDedtnAmt = Convert.ToDecimal(strDedutnId[1]);
                            objEmpDedutn.Employee = Convert.ToInt32(empChecked[k]);
                            if (amtAddnDedctn[8] != "")
                            {
                                objEmpDedutn.PayGradeID = Convert.ToInt32(amtAddnDedctn[8]);
                            }
                            objEmpListDeductn.Add(objEmpDedutn);
                        }
                    }
                }
            }
            if (empChecked[k] != "" && empChecked[k] != null)
            {
                string[] amtAddnDedctn = SpecialAmount[i].Split('|');
                if (amtAddnDedctn[4] != "")
                {
                    objEnt.ProcessedBasicPay = Convert.ToDecimal(amtAddnDedctn[7]); ;                   
                }
                objEnt.Employee = Convert.ToInt32(empChecked[k]);
                DataTable dtMonthSal = objBuss.ReadMonthlyLastDate(objEnt);
                if (dtMonthSal.Rows.Count > 0 && dtMonthSal.Rows[0]["SLPRCDMNTH_LST_SETTLD_DT"].ToString() != "")
                {
                  dtMonth = objCommon.textToDateTime(dtMonthSal.Rows[0]["SLPRCDMNTH_LST_SETTLD_DT"].ToString());
                }
                DataTable dtLeavSettlmentDate = objBuss.ReadLeavSettlmentDat(objEnt);
                if (dtLeavSettlmentDate.Rows.Count > 0 && dtLeavSettlmentDate.Rows[0]["LEAVE_ID"].ToString() != "")
                {
                   objEnt.LeaveId = Convert.ToInt32(dtLeavSettlmentDate.Rows[0]["LEAVE_ID"].ToString());
                   DataTable dtblRejoin = objBuss.ReadRejoinDate(objEnt);
                   if (dtblRejoin.Rows.Count > 0 && dtblRejoin.Rows[0]["DUTYREJOIN_DATE"].ToString() != "")
                   {                   
                      dtRejoin = objCommon.textToDateTime(dtblRejoin.Rows[0]["DUTYREJOIN_DATE"].ToString());
                   }
                }
                if (dtMonth != DateTime.MinValue || dtRejoin != DateTime.MinValue)
                {
                    if (dtRejoin > dtMonth)
                    {
                        objEnt.DateStartDate = dtRejoin;
                    }
                    else
                    {
                        objEnt.DateStartDate = dtMonth;
                    }
                }
                DataTable dtTblJoin = objBuss.ReadJoinDt(objEnt);
                DataTable dtCorpSal = objBuss.ReadCorpSal(objEnt);
                if (dtTblJoin.Rows.Count > 0 && dtTblJoin.Rows[0]["EMPERDTL_JOIN_DATE"].ToString() != "")
                {                   
                  DateTime dtJoin = objCommon.textToDateTime(dtTblJoin.Rows[0]["EMPERDTL_JOIN_DATE"].ToString());
                  if (dtJoin > objEnt.DateStartDate)
                  {
                   objEnt.DateStartDate = dtJoin;
                  }
                }
                if (dtCorpSal.Rows.Count > 0 && dtCorpSal.Rows[0]["COPRT_SALARY_DATE"].ToString() != "")
                {                   
                   DateTime dtCorptDate = objCommon.textToDateTime(dtCorpSal.Rows[0]["COPRT_SALARY_DATE"].ToString());
                   if (dtCorptDate > objEnt.DateStartDate)
                   {
                     objEnt.DateStartDate = dtCorptDate;
                   }
                }
                objEnt.Month = Convert.ToInt32(ddlMonth.SelectedItem.Value);
                objEnt.Year = Convert.ToInt32(ddlyear.SelectedItem.Value);
                int daysSS = DateTime.DaysInMonth(objEnt.Year, objEnt.Month);
                objEnt.DateEndDate = new DateTime(objEnt.Year, objEnt.Month, daysSS);               
                DataTable dtPaidLeave = objBuss.ReadMonthlyLeaveForMultipleYrs(objEnt);                
                if (dtPaidLeave.Rows.Count == 0)
                {
                    cls_Entity_Monthly_Salary_Process objEmpval = new cls_Entity_Monthly_Salary_Process();
                    objEmpval.Employee = Convert.ToInt32(empChecked[k]);
                    objEmpval.MessAmnt = Convert.ToDecimal(empMessAmnt[i]);
                    objEmpval.LvArrearAmnt = Convert.ToDecimal(empLvArrearAmnt[i]);
                    objEmpval.OtherAdditionAmt = Convert.ToDecimal(empOtherAdditionAmnt[i]);
                    objEmpval.OtherDeductionAmt = Convert.ToDecimal(empOtherDeductionAmnt[i]);
                    objEmpval.PrevMnthArreAmt = Convert.ToDecimal(empPrevArrAmnt[i]);
                    string[] amtAndid = empTotAmount[i].Split('|');          
                    if (amtAndid[0] != "")
                    objEmpval.TotMount = Convert.ToDecimal(amtAndid[0]);
                    if (amtAddnDedctn[0] != "")
                        objEmpval.AllowOverTmAmnt = Convert.ToDecimal(amtAddnDedctn[0]);
                    if (amtAndid[2] != "" && amtAndid[2].Contains("-")==false)
                        objEmpval.NumLeav = Convert.ToInt32(amtAndid[2]);
                    if (amtAddnDedctn[1] != "")
                        objEmpval.InstalAmount = Convert.ToDecimal(amtAddnDedctn[1]);
                    if (amtAddnDedctn[2] != "")
                        objEmpval.SpecialAllAmnt = Convert.ToDecimal(amtAddnDedctn[2]);
                    if (amtAddnDedctn[3] != "")
                        objEmpval.SpecialDedAmnt = Convert.ToDecimal(amtAddnDedctn[3]);
                    if (amtAddnDedctn[7] != "")
                        objEmpval.BasicPay = Convert.ToDecimal(amtAddnDedctn[7]);
                    objEmpList.Add(objEmpval);
                }
            }
            i++;
        }
        objBuss.InsertProssDtls(objEnt, objEmpList,objEmpListAllwnc,objEmpListDeductn);
        Session["MESSG"] = "PROCSS";
        Response.Redirect("hcm_Monthly_Salary_Process_List.aspx");
    }
    protected void btnSrch_Click(object sender, EventArgs e)
    {
        ListPage.Visible = true;
        BtnPross.Attributes.Add("style", "display:none;margin-left: 81%;height: 31px; margin-left: 5px;padding: 0 22px;font: 300 15px/29px 'Open Sans',Helvetica,Arial,sans-serif;cursor: pointer;");
        BtnCon.Attributes.Add("style", "display:none;margin-left: 81%;height: 31px; margin-left: 5px;padding: 0 22px;font: 300 15px/29px 'Open Sans',Helvetica,Arial,sans-serif;cursor: pointer;");
        Session["SALARPRSS"] = null;
        int intOrgId = 0;
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
        cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEnt.Orgid = intOrgId;
        objEnt.date = objCommon.textToDateTime(Hiddentxtefctvedate.Value);
        objEnt.CorpOffice = Convert.ToInt32(ddlBussunit.SelectedItem.Value);
        objEnt.Month = Convert.ToInt32(ddlMonth.SelectedItem.Value);
        objEnt.Year = Convert.ToInt32(ddlyear.SelectedItem.Value);
        if (radioCustType2.Checked == true)
        {
            objEnt.StffWrkr = 0;
        }
        else if (radioCustType1.Checked == true)
        {
            objEnt.StffWrkr = 1;
        }
        if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
        {
            objEnt.Division = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        }
        if (ddlDep.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEnt.Dep = Convert.ToInt32(ddlDep.SelectedItem.Value);
        }
        if (ddldesg.SelectedItem.Value != "--SELECT DESIGNATION--")
        {
            objEnt.Desg = Convert.ToInt32(ddldesg.SelectedItem.Value);
        }
        List<cls_Entity_Monthly_Salary_Process> objEmpList = new List<cls_Entity_Monthly_Salary_Process>();
        string TotalEmp2 = hiddenEmp.Value;
        string[] EachEmpId2 = TotalEmp2.Split(',');
        foreach (string EmpId2 in EachEmpId2)
        {
            if (EmpId2 != "")
            {
                cls_Entity_Monthly_Salary_Process objEmpval = new cls_Entity_Monthly_Salary_Process();
                objEmpval.Employee = Convert.ToInt32(EmpId2);
                objEmpList.Add(objEmpval);
            }
        }
        DataTable dtCorpSal = objBuss.ReadCorpSal(objEnt);
        int flag = 0;
        if (dtCorpSal.Rows.Count > 0 && dtCorpSal.Rows[0][0].ToString()!="")
        {
            
            DateTime dtFinal = objCommon.textToDateTime(dtCorpSal.Rows[0][0].ToString());
            DateTime dtSalCorp = new DateTime(dtFinal.Year, dtFinal.Month, 1);
            objEnt.DateEndDate = objCommon.textToDateTime(dtSalCorp.ToString("dd-MM-yyyy"));
            DateTime dtProcessDate = new DateTime(objEnt.Year, objEnt.Month, 1);
            if (dtSalCorp > dtProcessDate)
            {
                ListPage.Visible = false;
                divlistview.InnerHtml = "";
                flag = 1;
                ScriptManager.RegisterStartupScript(this, GetType(), "CorpSalGreat", "CorpSalGreat();", true);
            }
        }
        if (flag == 0)
        {
            DataTable dt = objBuss.LoadSalaryPrssList(objEnt, objEmpList);
            int Processed = 0;
            string ListLoad = ConvertDataTableToHTML(dt, objEnt, Processed);
            divlistview.InnerHtml = ListLoad;
            ScriptManager.RegisterStartupScript(this, GetType(), "insert", "insert();", true);
        }
    }
    public void LoadDivision(DataTable dt)
    {

        if (dt.Rows.Count > 0)
        {
            ddlDivision.DataSource = dt;
            ddlDivision.DataTextField = "CPRDIV_NAME";
            ddlDivision.DataValueField = "CPRDIV_ID";
            ddlDivision.DataBind();

        }
        ddlDivision.ClearSelection();
        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
    }
    public void LoadEmployee(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            ddlEmployee.DataSource = dt;
            ddlEmployee.DataTextField = "USR_NAME";
            ddlEmployee.DataValueField = "USR_ID";
            ddlEmployee.DataBind();

        }
    }
    public void LoadDep(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            ddlDep.DataSource = dt;
            ddlDep.DataTextField = "CPRDEPT_NAME";
            ddlDep.DataValueField = "CPRDEPT_ID";
            ddlDep.DataBind();

        }
        // DataTable dtDefaultcurc = ObjBussinessBankGuarnt.ReadDefualtCurrency(ObjEntityRequest);
        //string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        ddlDep.ClearSelection();
        ddlDep.Items.Insert(0, "--SELECT DEPARTMENT--");
    }
    public void LoadDesg(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            ddldesg.DataSource = dt;
            ddldesg.DataTextField = "DSGN_NAME";
            ddldesg.DataValueField = "DSGN_ID";
            ddldesg.DataBind();
        }
        ddldesg.ClearSelection();
        ddldesg.Items.Insert(0, "--SELECT DESIGNATION--");
    }
    public void LoadBussUnit(DataTable dt)
    {
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        if (dt.Rows.Count > 0)
        {
            ddlBussunit.DataSource = dt;
            ddlBussunit.DataTextField = "CORPRT_NAME";
            ddlBussunit.DataValueField = "CORPRT_ID";
            ddlBussunit.DataBind();
        }
        ddlBussunit.ClearSelection();
        bool existsCus = dt.Select().ToList().Exists(row => row["CORPRT_ID"].ToString().ToUpper() == intCorpId.ToString());
        if (existsCus == true)
        {

            ddlBussunit.Items.FindByValue(intCorpId.ToString()).Selected = true;
        }
        else
        {
            ddlBussunit.Items.Insert(0, "--SELECT BUSINESS UNIT--");
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
        ddlMonth.ClearSelection();
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
        ddlyear.Items.Clear();
        strYear = DateTime.Today.Year.ToString();
        var currentYear = DateTime.Today.Year;
        for (int i = 1; i >= -1; i--)
        {

            ddlyear.Items.Add((currentYear - i).ToString());
        }
        ddlyear.ClearSelection();
        if (strYear != null)
        {
            if (ddlyear.Items.FindByValue(strYear) != null)
            {
                ddlyear.Items.FindByValue(strYear).Selected = true;
            }
        }
        else
        {
            ddlyear.Items.Insert(0, "--YEAR--");
        }
    }
    protected void btnConfrm_Click(object sender, EventArgs e)
    {
        Session["SALARPRSS"] = null;
        int intOrgId = 0;
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        int intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
        cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEnt.Orgid = intOrgId;
        objEnt.date = DateTime.MinValue;
        objEnt.UserId = intUserId;
        objEnt.date = objCommon.textToDateTime(Hiddentxtefctvedate.Value);
        objEnt.CorpOffice = Convert.ToInt32(ddlBussunit.SelectedItem.Value);
        objEnt.Month = Convert.ToInt32(hidden_Month.Value);
        objEnt.Year = Convert.ToInt32(hidden_Year.Value);
        DataTable dtDialyHourDtl;
        if (radioCustType2.Checked == true)
        {
            objEnt.StffWrkr = 0;
        }
        else if (radioCustType1.Checked == true)
        {
            objEnt.StffWrkr = 1;
        }
        if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
        {
            objEnt.Division = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        }
        if (ddlDep.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEnt.Dep = Convert.ToInt32(ddlDep.SelectedItem.Value);
        }
        if (ddldesg.SelectedItem.Value != "--SELECT DESIGNATION--")
        {
            objEnt.Desg = Convert.ToInt32(ddldesg.SelectedItem.Value);
        }
        List<cls_Entity_Monthly_Salary_Process> objEmpList = new List<cls_Entity_Monthly_Salary_Process>();
        List<cls_Entity_Monthly_Salary_Process> objEmpListDailyHrList = new List<cls_Entity_Monthly_Salary_Process>();
        List<cls_Entity_Monthly_Salary_Process> objDistinctPrjctList = new List<cls_Entity_Monthly_Salary_Process>();
        List<string> Projectlist = new List<string>();
        string[] empChecked = HiddenFieldCheckEmp.Value.Split(',');
        string[] empTotAmount = HiddenAmount.Value.Split(',');
        string[] SpecialAmount = HiddenFieldSpecialAmount.Value.Split('/');

        string[] empPrevArrAmnt = hiddenPrevArrAmt.Value.Split('/');
        string[] empPrevRejoinDate = hiddenPrevRejoinDate.Value.Split('/');

        int i = 0;
        try
        {
            for(int k=0;k<empChecked.Length;k++)
            {
                if (empChecked[k] != "" && empChecked[k] != null)
                {
                    cls_Entity_Monthly_Salary_Process objEmpval = new cls_Entity_Monthly_Salary_Process();
                    objEmpval.Employee = Convert.ToInt32(empChecked[k]);
                    string[] amtAndid = empTotAmount[i].Split('|');
                    string[] amtAddnDedctn = SpecialAmount[i].Split('|');
                    objEmpval.TotMount = Convert.ToDecimal(amtAndid[0]);
                    objEmpval.SalaryPrssId = Convert.ToInt32(amtAndid[1]);
                    if (amtAddnDedctn[0] != "")
                        objEmpval.AllowOverTmAmnt = Convert.ToDecimal(amtAddnDedctn[0]);
                    if (amtAddnDedctn[1] != "")
                        objEmpval.InstalAmount = Convert.ToDecimal(amtAddnDedctn[1]);
                    if (amtAddnDedctn[2] != "")
                        objEmpval.SpecialAllAmnt = Convert.ToDecimal(amtAddnDedctn[2]);
                    if (amtAddnDedctn[3] != "")
                        objEmpval.SpecialDedAmnt = Convert.ToDecimal(amtAddnDedctn[3]);
                    if (amtAddnDedctn[4] != "")
                        objEmpval.BasicPay = Convert.ToDecimal(amtAddnDedctn[4]);

                    objEmpval.PrevMnthArreAmt = Convert.ToDecimal(empPrevArrAmnt[i]);
                    if (empPrevRejoinDate[i] != "" && empPrevRejoinDate != null)
                    {
                        objEmpval.CurrentDate = objCommon.textToDateTime(empPrevRejoinDate[i]);
                    }
                    objEmpList.Add(objEmpval);
                    objEnt.UserId = objEmpval.Employee;
                    objEnt.BasicPay = objEmpval.BasicPay;
                    dtDialyHourDtl = objBuss.ReadDialyHourDtl(objEnt);
                    if (dtDialyHourDtl.Rows.Count > 0)
                    {
                        string strMonthNum = "";
                        if (Convert.ToInt32(dtDialyHourDtl.Rows[0]["MONTH"].ToString()) < 10)
                        {
                            strMonthNum = "0" + dtDialyHourDtl.Rows[0]["MONTH"].ToString();
                        }
                        else
                        {
                            strMonthNum = dtDialyHourDtl.Rows[0]["MONTH"].ToString();
                        }
                        int intCorpId = 0;
                        if (Session["CORPOFFICEID"] != null)
                        {
                            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                        }
                        else if (Session["CORPOFFICEID"] == null)
                        {
                            Response.Redirect("/Default.aspx");
                        }
                        int intYear = Convert.ToInt32(dtDialyHourDtl.Rows[0]["YEAR"].ToString());
                        int intMonth = Convert.ToInt32(dtDialyHourDtl.Rows[0]["MONTH"].ToString());
                        int dtdays = DateTime.DaysInMonth(intYear, intMonth);
                        decimal BASICPAY = objEnt.BasicPay;
                        decimal deciHourlySalary = (BASICPAY / dtdays) / 8;
                        objEnt.CorpOffice = intCorpId;
                        objEnt.MonthYearDate = objCommon.textToDateTime("01/" + strMonthNum + "/" + dtDialyHourDtl.Rows[0]["YEAR"].ToString());
                        for (int j = 0; j < dtDialyHourDtl.Rows.Count; j++)
                        {
                            cls_Entity_Monthly_Salary_Process objEmpvalDilyHr = new cls_Entity_Monthly_Salary_Process();
                            cls_Entity_Monthly_Salary_Process objDistinctPrjct = new cls_Entity_Monthly_Salary_Process();
                            objEmpvalDilyHr.CorpOffice = intCorpId;
                            objEmpvalDilyHr.UserId = objEnt.UserId;
                            objEmpvalDilyHr.MonthYearDate = objCommon.textToDateTime("01/" + strMonthNum + "/" + dtDialyHourDtl.Rows[0]["YEAR"].ToString());
                            objEmpvalDilyHr.OT_Hour = Convert.ToDecimal(dtDialyHourDtl.Rows[j]["EMDLHRDTL_RNDED_OT"].ToString());
                            objEmpvalDilyHr.TotalOTamt = Convert.ToDecimal(dtDialyHourDtl.Rows[j]["OVERTIMEAMOUNT"].ToString()) * deciHourlySalary;
                            objEmpvalDilyHr.NumOfDays = Convert.ToInt32(dtDialyHourDtl.Rows[j]["NUM_DAYS"].ToString());
                            objEmpvalDilyHr.TotalCost = ((BASICPAY + objEmpval.SpecialAllAmnt) + objEmpvalDilyHr.TotalOTamt);
                            objEmpvalDilyHr.ProjectId = Convert.ToInt32(dtDialyHourDtl.Rows[j]["PROJECT_ID"].ToString());
                            objEmpvalDilyHr.Basic_Allwnc_Amt = ((BASICPAY + objEmpval.SpecialAllAmnt));
                            if (!Projectlist.Contains(dtDialyHourDtl.Rows[j]["PROJECT_ID"].ToString()))
                            {
                                Projectlist.Add(dtDialyHourDtl.Rows[j]["PROJECT_ID"].ToString());
                                objDistinctPrjct.ProjectId = Convert.ToInt32(dtDialyHourDtl.Rows[j]["PROJECT_ID"].ToString());
                                objDistinctPrjctList.Add(objDistinctPrjct);
                            }
                            objEmpListDailyHrList.Add(objEmpvalDilyHr);
                        }
                    }
                }
                i++;
            }
            objBuss.ConfrmProssDtls(objEnt, objEmpList, objEmpListDailyHrList, objDistinctPrjctList);
            Session["MESSG"] = "CONF";
        }
        catch (Exception)
        {
        }
        Response.Redirect("hcm_Monthly_Salary_Process_List.aspx");
    }
    protected void btnRedirect_Click(object sender, EventArgs e)
    {
        Session["SALAR_PRSS_EDIT"] = HiddenViewId.Value;
        Response.Redirect("hcm_Monthly_Salary_Process_Master.aspx");

    }


    protected void ddlDep_SelectedIndexChange(object sender, EventArgs e)     //emp25
    {

        cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
        cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();

        if (Session["USERID"] != null)
        {
            objEnt.UserId = Convert.ToInt32(Session["USERID"]);


        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            objEnt.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEnt.Orgid = Convert.ToInt32(Session["ORGID"].ToString());


        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/0.aspx");
        }
        ddlDivision.Items.Clear();
        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
        if (ddlDep.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            int Dept = Convert.ToInt32(ddlDep.SelectedItem.Value);
            objEnt.Dep = Dept;

            DataTable dtSubConrt = objBuss.LoadDivision(objEnt);
            ddlDivision.Items.Clear();
            ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
            if (dtSubConrt.Rows.Count > 0)
            {
                ddlDivision.Items.Clear();
                ddlDivision.DataSource = dtSubConrt;


                ddlDivision.DataValueField = "CPRDIV_ID";
                ddlDivision.DataTextField = "CPRDIV_NAME";

                ddlDivision.DataBind();
                ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
            }

        }


    }

    [WebMethod]
    public static string DeleteMonthlyProces(string PrcssId)
    {
        cls_Entity_Monthly_Salary_Process objEntityMonthlySalaryProcess = new cls_Entity_Monthly_Salary_Process();
        cls_Business_Monthly_Salary_Process objBussMonthlySalaryProcess = new cls_Business_Monthly_Salary_Process();

        objEntityMonthlySalaryProcess.SalaryPrssId = Convert.ToInt32(PrcssId);

        objBussMonthlySalaryProcess.DeleteMonthlySalaryProces(objEntityMonthlySalaryProcess);
        return "";
    }


    [WebMethod]
    public static string OtherAdd_Ded_Details(string orgid, string corpid, string PayinfoId, string EmpId, string PayrolMod,string IndividualRound)
    {
        int roundCnt = 0;
        if (IndividualRound == "0")
        {
            roundCnt = 2;
        }
            clsCommonLibrary objCommon = new clsCommonLibrary();
            cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
            cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();

            objEnt.Orgid = Convert.ToInt32(orgid);
            objEnt.CorpOffice = Convert.ToInt32(corpid);
            objEnt.ManualAddDedId = Convert.ToInt32(PayinfoId);
            objEnt.Employee = Convert.ToInt32(EmpId);
            objEnt.PayrlMode = Convert.ToInt32(PayrolMod);
            DataTable dtDtls = objBuss.ReadEmpManualy_Add_Dedn_Details(objEnt);
            StringBuilder sb = new StringBuilder();
            string strHtml = "<table id=\"datatable_fixed_column\" class=\"table table-striped table-bordered\" width=\"100%\" style=\"border-spacing: 1px;background-color: #e7e6e6;\" >";
            //add header row
            strHtml += "<thead>";
            strHtml += "<tr>";

            strHtml += "<th class=\"hasinput col-md-3\">CODE";
            strHtml += "</th >";
            strHtml += "<th class=\"hasinput col-md-1\" style=\"text-align: right;\">AMOUNT";
            strHtml += "</th >";           
            strHtml += "</tr>";
            strHtml += "</thead>";
            //add rows
            strHtml += "<tbody>";
            if (dtDtls.Rows.Count > 0)
            {
                for (int intCount = 0; intCount < dtDtls.Rows.Count; intCount++)
                {
                    strHtml += "<tr>";
                    strHtml += "<td class=\"tdT\" >" + dtDtls.Rows[intCount]["PAYRL_CODE"].ToString() + "</td>";
                    strHtml += "<td class=\"tdT\" style=\"text-align: right;\" >" + Math.Round(Convert.ToDecimal(dtDtls.Rows[intCount]["PAYINFDT_AMOUNT"].ToString()), roundCnt).ToString("0.00") + "</td>";
                    strHtml += "</tr>";
                }
                strHtml += "</tbody>";
                strHtml += "</table>";
                sb.Append(strHtml);
            }
            return sb.ToString();
        }
    public string CheckWorkerMissingAttendance(string strEmpId, DateTime dtFromDate, DateTime dtToDate, string strCorp, string Org)
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
}