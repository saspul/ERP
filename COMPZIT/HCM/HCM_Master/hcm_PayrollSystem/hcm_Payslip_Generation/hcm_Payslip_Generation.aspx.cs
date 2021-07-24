using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.IO;

public partial class HCM_HCM_Master_hcm_PayrollSystem_hcm_Payslip_Generation_hcm_Payslip_Generation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            YearLoad();
            monthLoad();

            divPayslip.Visible = false;
            divLabourCard.Visible = false;
            divPreview.Visible = false;
            btnprint.Visible = false;

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityCommon objEntityCommon = new clsEntityCommon();

            clsEntityLayerPayslipGeneratn objEntityLayerPayslip = new clsEntityLayerPayslipGeneratn();
            clsBusinessLayerPayslipGeneratn objBusinessPayslip = new clsBusinessLayerPayslipGeneratn();

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityLayerPayslip.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityLayerPayslip.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objEntityLayerPayslip.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            DataTable dtEmpDtls = objBusinessPayslip.ReadEmployeeDtls(objEntityLayerPayslip);

            if (dtEmpDtls.Rows.Count > 0)
            {
                lblEmpName.Text = dtEmpDtls.Rows[0]["USR_NAME"].ToString();
                lblDesgntn.Text = dtEmpDtls.Rows[0]["DSGN_NAME"].ToString();
                lblDeprtmnt.Text = dtEmpDtls.Rows[0]["CPRDEPT_NAME"].ToString();

                DataTable dtDivsn = objBusinessPayslip.ReadDivisn(objEntityLayerPayslip);

                string strDiv = "";
                foreach (DataRow dtDiv in dtDivsn.Rows)
                {
                    strDiv = (dtDiv["CPRDIV_NAME"].ToString() + ", " + strDiv).TrimEnd(" , ".ToCharArray());
                }
                lblDivsn.Text = strDiv;

                hiddenStaffWrkr.Value = dtEmpDtls.Rows[0]["STAFF_WORKER"].ToString();
            }
        }
    }

    protected void YearLoad()
    {
        ddlYear.Items.Clear();
        // created object for business layer for compare the date
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strCurrentDate = objBusiness.LoadCurrentDateInString();
        string[] split = strCurrentDate.Split('-');

        var currentYear = Convert.ToInt32(split[2]);
        for (int i = 0; i <= 20; i++)
        {
            // Now just add an entry that's the current year minus the counter
            ddlYear.Items.Add((currentYear - i).ToString());
        }
        ddlYear.Items.Insert(0, "--SELECT YEAR--");
    }

    public void monthLoad()
    {
        DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
        for (int i = 1; i < 13; i++)
        {
            ddlMonth.Items.Add(new System.Web.UI.WebControls.ListItem(info.GetMonthName(i).ToUpper(), i.ToString()));
        }
        ddlMonth.Items.Insert(0, "--SELECT MONTH--");
    }


    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntityLayerPayslipGeneratn objEntityLayerPayslip = new clsEntityLayerPayslipGeneratn();
        clsBusinessLayerPayslipGeneratn objBusinessPayslip = new clsBusinessLayerPayslipGeneratn();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLayerPayslip.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityLayerPayslip.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        objEntityLayerPayslip.Month = Convert.ToInt32(ddlMonth.SelectedItem.Value);
        objEntityLayerPayslip.Year = Convert.ToInt32(ddlYear.SelectedItem.Value);

        DataTable dtEmpSlryPrcsd = objBusinessPayslip.ReadProcessdEmployees(objEntityLayerPayslip);

        cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
        cls_Entity_Monthly_Salary_Process objEntPrcss = new cls_Entity_Monthly_Salary_Process();

        objEntPrcss.UserId = objEntityLayerPayslip.UserId;
        objEntPrcss.Employee = objEntityLayerPayslip.UserId;
        objEntPrcss.Month = Convert.ToInt32(ddlMonth.SelectedItem.Value);
        objEntPrcss.Year = Convert.ToInt32(ddlYear.SelectedItem.Value);
        objEntPrcss.PaidFinish = 1;
        objEntPrcss.CorpOffice = objEntityLayerPayslip.CorpId;
        if (dtEmpSlryPrcsd.Rows.Count > 0)
        {
            objEntPrcss.date = objCommon.textToDateTime(dtEmpSlryPrcsd.Rows[0]["SLPRCDMNTH_FROM_DATE"].ToString());
            objEntPrcss.Dep = Convert.ToInt32(dtEmpSlryPrcsd.Rows[0]["CPRDEPT_ID"].ToString());
            objEntPrcss.SalaryPrssId = Convert.ToInt32(dtEmpSlryPrcsd.Rows[0]["SLPRCDMNTH_ID"].ToString());

            if (hiddenStaffWrkr.Value == "0")
            {
                objEntPrcss.StffWrkr = 0;
                btnprint.Visible = true;
                string strHtmlPaySlipEmp = ConvertDataTableToHtmlPay_Slip(dtEmpSlryPrcsd, objEntPrcss);
                divPayslip.InnerHtml = strHtmlPaySlipEmp;
                divPreview.Visible = true;
                divPayslip.Visible = true;

            }
            else
            {
                objEntPrcss.StffWrkr = 0;
                btnprint.Visible = true;
                string strHtmlEmp_list = ConvertDataTableToHtmlEmp_list(dtEmpSlryPrcsd, objEntPrcss);
                divLabourCardbody.InnerHtml = strHtmlEmp_list;
                divPreview.Visible = true;
                divLabourCard.Visible = true;

            }

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SalaryNotPrcsdMessage", "SalaryNotPrcsdMessage();", true);
            divPayslip.Visible = false;
            divLabourCard.Visible = false;
            divPreview.Visible = false;
            btnprint.Visible = false;
        }

    }

    public string ConvertDataTableToHtmlPay_Slip(DataTable dt, cls_Entity_Monthly_Salary_Process objMonthlySalaryProcess)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
        cls_Entity_Monthly_Salary_Process objEntPrcss = new cls_Entity_Monthly_Salary_Process();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        StringBuilder sbPaySlip = new StringBuilder();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntPrcss.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntPrcss.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }

        int NofDaysMonth = DateTime.DaysInMonth(objMonthlySalaryProcess.Year, objMonthlySalaryProcess.Month);
        string strMonthstart = new DateTime(objMonthlySalaryProcess.Year, objMonthlySalaryProcess.Month, 1).ToString("dd-MM-yyyy");
        string strMonthEnd = new DateTime(objMonthlySalaryProcess.Year, objMonthlySalaryProcess.Month, NofDaysMonth).ToString("dd-MM-yyyy");
        DateTime dMonthstart = objCommon.textToDateTime(strMonthstart);
        DateTime dMonthEnd = objCommon.textToDateTime(strMonthEnd);

        objEntPrcss.date = dMonthstart;
        objEntPrcss.CurrentDate = dMonthEnd;
        string MonthName = dMonthstart.ToString("MMMM");
        objEntPrcss.Employee = objMonthlySalaryProcess.Employee;
        objEntPrcss.Month = objMonthlySalaryProcess.Month;
        objEntPrcss.Year = objMonthlySalaryProcess.Year;

        DataTable dtEmp_list = objBuss.ReadEmp_List_For_PaySlip_Print(objEntPrcss);

        DataTable dtSalPrssDtls = objBuss.ReadSalaryProssDtlsById(objEntPrcss);

        sbPaySlip.Append("<h3 style=\"text-align:center\">Payslip for the Month of " + MonthName + ", " + objEntPrcss.Year + "<h3>");
        sbPaySlip.Append("<br><br>");

        sbPaySlip.Append("<div style=\"width:100%; height:60%\">");
        sbPaySlip.Append("<div style=\"width:50%;height:60%;float:left;\">");
        sbPaySlip.Append("<table style=\"width:100%;  \" class=\"tab\" cellspacing=\"0\" cellpadding=\"1px\" >");
        sbPaySlip.Append("<tr> <td class=\"thT\"><strong>Employee #</strong></td>  <td class=\"tdT\">" + dt.Rows[0]["EID"].ToString() + "</td>  </tr>");
        sbPaySlip.Append("<tr> <td class=\"thT\"><strong>Name</strong></td>  <td class=\"tdT\"> " + dt.Rows[0]["USR_NAME"].ToString() + " </td>  </tr>");
        sbPaySlip.Append("<tr> <td class=\"thT\"><strong>Department</strong></td>  <td class=\"tdT\">" + dt.Rows[0]["CPRDEPT_NAME"].ToString() + "  </td>  </tr>");
        sbPaySlip.Append("<tr> <td class=\"thT\"><strong>Designation</strong></td>  <td class=\"tdT\">" + dt.Rows[0]["DSGN_NAME"].ToString() + " </td>  </tr>");
        sbPaySlip.Append("<tr> <td class=\"thT\"><strong>Job Title</strong></td>  <td class=\"tdT\"> " + dt.Rows[0]["JOBRL_NAME"].ToString() + "  </td>  </tr>");
        sbPaySlip.Append("</table> </div>");


        int AttendncCount = 0;

        for (int intRowBodyCount = 1; intRowBodyCount <= dtEmp_list.Rows.Count; intRowBodyCount++)
        {
            if (dtEmp_list.Rows[0]["ATTENDANCE"].ToString() == "P")
            {
                AttendncCount++;
            }
        }

        sbPaySlip.Append("<div style=\"width:50%;height:60%;float:right\">");
        sbPaySlip.Append("<table style=\"width:81%;margin-top: 0%; float: right;\" class=\"tab\" cellspacing=\"0\" cellpadding=\"1px\" >");
        sbPaySlip.Append("<tr> <td class=\"thT\"><strong>Eligible Days</strong></td>  <td class=\"tdT\" style=\"text-align:center\"> " + NofDaysMonth + " </td>  </tr>");
        sbPaySlip.Append("<tr> <td class=\"thT\"><strong>Present Days</strong></td>  <td class=\"tdT\" style=\"text-align:center\">" + AttendncCount + " </td>  </tr> ");
        sbPaySlip.Append("</table> </div> ");
        sbPaySlip.Append("</div>");



        string basicAmt = "", SalaryProcssdBasicAmt = "", AllowaceAmt = "", AllowovertimeAmount = "", DedctionAmt = "", DedctionInstalmntAmnt = "", Total = "", OT_Hours = "", MessAmnt = "", LvArrearAmnt = "";
        Decimal TotalBasicAllow = 0, TotalDedctn = 0, netsalary = 0, AllowovertimeAmount1 = 0, AllowaceAmt1 = 0, basicAmt1 = 0, decSalaryProcssdBasicAmt = 0, spclDedctionAmt = 0, instlmntDedctionAmt = 0;
        Decimal decMessAmnt = 0, decLvArrearAmnt = 0;
        if (dtSalPrssDtls.Rows.Count > 0)
        {
            basicAmt = dtSalPrssDtls.Rows[0]["SLRY_BASIC_PAY"].ToString();
            SalaryProcssdBasicAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_PRSD_BASICPAY"].ToString();
            AllowaceAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_ALLOW_AMT"].ToString();
            AllowovertimeAmount = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_OVERTIME_ALLOW_AMT"].ToString();
            DedctionAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_DEDCTN_AMT"].ToString();
            DedctionInstalmntAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_INSTLMNT_DEDCN_AMT"].ToString();
            Total = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_TOTAL_AMT"].ToString();
            if (dtSalPrssDtls.Rows[0]["SLPRCDMNTH_TOTAL_AMT"].ToString() != "")
            {
                OT_Hours = dtSalPrssDtls.Rows[0]["EMDLHRDTL_OT"].ToString();
            }
            MessAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_MESS_DEDCTN_AMT"].ToString();
            LvArrearAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_LEV_ARREAR_AMT"].ToString();
        }
        if (basicAmt != "")
        {
            basicAmt1 = Convert.ToDecimal(basicAmt);
        //    TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(basicAmt);
        }
        if (SalaryProcssdBasicAmt != "")
        {
            decSalaryProcssdBasicAmt = Convert.ToDecimal(SalaryProcssdBasicAmt);
            TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(SalaryProcssdBasicAmt);
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
        if (DedctionAmt != "")
        {
            spclDedctionAmt = Convert.ToDecimal(DedctionAmt);
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
        if (Total != "")
        {
            netsalary = Convert.ToDecimal(Total);
        }


        sbPaySlip.Append("<div style=\"width:100%;  height:50%\">");
        sbPaySlip.Append("<div style=\"width:51%;float:left;\">");
        sbPaySlip.Append("<br> <br>");
        sbPaySlip.Append("<table style=\"width:98%;\" class=\"tab\" cellspacing=\"0\" cellpadding=\"1px\" >");
        sbPaySlip.Append("<tr style=\"background-color: #cacfd2;height: 30px;\"> <td class=\"thT\" style=\"text-align:center\" colspan=\"4\" > Basic & Allowances</td>  </tr>");
        sbPaySlip.Append("<tr style=\"text-align:center\"> <td class=\"thT\" style=\"text-align:left\"> Description</td> <td class=\"thT\" style=\"text-align:right\">Amount</td> <td class=\"thT\"> Hours</td> <td class=\"thT\" style=\"text-align:right\">Earned</td>  </tr>");

        string strbasicAmt = objBusiness.AddCommasForNumberSeperation(basicAmt1.ToString("0.00"), objEntityCommon);
        string strSalaryProcssdBasicAmt = objBusiness.AddCommasForNumberSeperation(decSalaryProcssdBasicAmt.ToString("0.00"), objEntityCommon);

        //sbPaySlip.Append("<tr> <td class=\"tdT\">Basic Pay</td> <td class=\"tdT\" style=\"text-align:right\">" + strbasicAmt + "</td> <td></td> <td class=\"tdT\" style=\"text-align:right\">" + strbasicAmt + "</td>   </tr> ");
        sbPaySlip.Append("<tr> <td class=\"tdT\">Basic Pay</td> <td class=\"tdT\" style=\"text-align:right\">" + strbasicAmt + "</td> <td></td> <td class=\"tdT\" style=\"text-align:right\">" + strSalaryProcssdBasicAmt + "</td>   </tr> ");

        string strAllowaceAmt = objBusiness.AddCommasForNumberSeperation(AllowaceAmt1.ToString("0.00"), objEntityCommon);
        sbPaySlip.Append("<tr> <td class=\"tdT\">Special Allowance</td> <td class=\"tdT\" style=\"text-align:right\">" + strAllowaceAmt + "</td> <td></td> <td class=\"tdT\" style=\"text-align:right\">" + strAllowaceAmt + "</td>   </tr> ");

        string strAllowovertimeAmount = objBusiness.AddCommasForNumberSeperation(AllowovertimeAmount1.ToString("0.00"), objEntityCommon);
        sbPaySlip.Append("<tr> <td class=\"tdT\">Over Time Allowance</td> <td class=\"tdT\" style=\"text-align:right\">" + strAllowovertimeAmount + "</td> <td style=\"text-align:center\" class=\"tdT\"> " + OT_Hours + "  </td> <td class=\"tdT\" style=\"text-align:right\">" + strAllowovertimeAmount + "</td>   </tr> ");
        string strTotalBasicAllow = objBusiness.AddCommasForNumberSeperation(TotalBasicAllow.ToString("0.00"), objEntityCommon);
        sbPaySlip.Append("<tr  > <td colspan=\"3\" class=\"thT\" > Total Basic & Allowances </td> <td style=\"text-align:right\" class=\"tdT\">" + strTotalBasicAllow + "</td>  </tr>");
        sbPaySlip.Append("</table> </div>");

        sbPaySlip.Append("<div style=\"width:49%;float:right;\">");
        sbPaySlip.Append("<br> <br>");
        sbPaySlip.Append("<table style=\"width:82.5%; float: right;\" class=\"tab\" cellspacing=\"0\" cellpadding=\"1px\" >");
        string strTotalDedctn = objBusiness.AddCommasForNumberSeperation(TotalDedctn.ToString("0.00"), objEntityCommon);
        sbPaySlip.Append("<tr style=\"background-color: #cacfd2;height: 30px;\"> <td style=\"text-align:center\" colspan=\"2\" class=\"thT\" >Deduction</td>  </tr> ");
        sbPaySlip.Append("<tr> <th class=\"thT\" colspan=\"2\" style=\"text-align:right\" > Amount</th>  </tr>");

        string strspclDedctionAmt = objBusiness.AddCommasForNumberSeperation(spclDedctionAmt.ToString("0.00"), objEntityCommon);
        string strinstlmntDedctionAmt = objBusiness.AddCommasForNumberSeperation(instlmntDedctionAmt.ToString("0.00"), objEntityCommon);

        string strMessAmnt = objBusiness.AddCommasForNumberSeperation(decMessAmnt.ToString("0.00"), objEntityCommon);
        string strLvArrearAmnt = objBusiness.AddCommasForNumberSeperation(decLvArrearAmnt.ToString("0.00"), objEntityCommon);

        sbPaySlip.Append("<tr> <td class=\"tdT\">Special Deduction</td>  <td class=\"tdT\" style=\"text-align:right\">  " + strspclDedctionAmt + " </td>  </tr>");
        sbPaySlip.Append("<tr> <td class=\"tdT\">Installment Deduction</td>  <td class=\"tdT\" style=\"text-align:right\">  " + strinstlmntDedctionAmt + " </td>  </tr>");
        sbPaySlip.Append("<tr> <td class=\"tdT\">Mess Deduction</td>  <td class=\"tdT\" style=\"text-align:right\">  " + strMessAmnt + " </td>  </tr>");
        sbPaySlip.Append("<tr> <td class=\"tdT\">Leave Arrear Deduction</td>  <td class=\"tdT\" style=\"text-align:right\">  " + strLvArrearAmnt + " </td>  </tr>");
        sbPaySlip.Append("<tr> <td class=\"tdT\">Total Deduction</td>  <td class=\"tdT\" style=\"text-align:right\">  " + strTotalDedctn + " </td>  </tr>");
        sbPaySlip.Append("</table>  </div>");
        sbPaySlip.Append("</div>");

        sbPaySlip.Append("<div>");
        sbPaySlip.Append("<div style=\"width:100%\">");
        sbPaySlip.Append("<table style=\"width:40.5%;float:right;margin-top: 8%;\" class=\"tab\" cellspacing=\"0\" cellpadding=\"1px\" >");
        string strnetsalary = objBusiness.AddCommasForNumberSeperation(netsalary.ToString("0.00"), objEntityCommon);
        sbPaySlip.Append("<tr><td class=\"thT\">Net Salary </td> <td class=\"thT\" style=\"text-align:right\">" + strnetsalary + " </td> </tr>");
        sbPaySlip.Append("</table></div>");
        sbPaySlip.Append("</div>");

        return sbPaySlip.ToString();
    }


    public string ConvertDataTableToHtmlEmp_list(DataTable dt, cls_Entity_Monthly_Salary_Process OBJ)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
        cls_Entity_Monthly_Salary_Process objEntPrcss = new cls_Entity_Monthly_Salary_Process();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        StringBuilder sbCap = new StringBuilder();
        string strCapTable = "";

        string strPrintCaptionTable = "";
        if (Session["CORPOFFICEID"] != null)
        {
            objEntPrcss.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntPrcss.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }

        strCapTable = "<table style=\"width:95%;margin-top:2%;\"  class=\"tab\" cellspacing=\"0\" cellpadding=\"2px\" >";
        strCapTable += "<thead>";
        strCapTable += "<tr >";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount <= 5; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 0)
            {
                strCapTable += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;height: 36px;background-color: #cacfd2;height: 30px;\">Date</th>";
           }
            else if (intColumnHeaderCount == 1)
            {
                strCapTable += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;height: 36px;background-color: #cacfd2;height: 30px;\">Job #</th>";
            }
            else if (intColumnHeaderCount == 2)
            {
                strCapTable += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;height: 36px;background-color: #cacfd2;height: 30px;\">Status</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strCapTable += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;height: 36px;background-color: #cacfd2;height: 30px;\">Normal Hrs</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strCapTable += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;height: 36px;background-color: #cacfd2;height: 30px;\">Normal OT</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strCapTable += "<th class=\"thT\"  style=\"width:7%;text-align: center; word-wrap:break-word;height: 36px;background-color: #cacfd2;height: 30px;\">Holiday OT</th>";
            }

        }
        strCapTable += "</tr>";
        strCapTable += "</thead>";
        strCapTable += "<tbody>";
        int numMonth = DateTime.DaysInMonth(OBJ.Year, OBJ.Month);

        int NormlOT=0,HolidayOT=0;
        decimal NormalOvertmRatePrHr=0,HolidayOvertmRatePrHr=0;

        for (int intRowBodyCount = 1; intRowBodyCount <= numMonth; intRowBodyCount++)
        {
            strCapTable += "<tr  >";

            string EmDate = new DateTime(OBJ.Year, OBJ.Month, intRowBodyCount).ToString("dd-MM-yyyy");
            DateTime ddate = objCommon.textToDateTime(EmDate);

            objEntPrcss.date = ddate;
            string MonthName = ddate.ToString("MMMM");
            objEntPrcss.Employee = OBJ.Employee;
            objEntPrcss.Month = OBJ.Month;
            objEntPrcss.Year = OBJ.Year;
            DataTable dtEmp_list = objBuss.ReadEmp_List_For_Print(objEntPrcss);


            string strCaptionTabRprtDate = "<h3 style=\"text-align:center;margin-top: 2%;margin-bottom:4%;\">Labour Card For " + MonthName + "-" + objEntPrcss.Year + "</h3>";

            string strCaptionTabstart = "<table class=\"tab\" style=\" width:95%;text-align: center; \">";

            string strEmpCodeAndName = "", strEmpCodeAndName1 = "", strEmpCodeAndName2 = "", strEmpCodeAndName3 = "", strEmpCodeAndName4="";
            if (dt.Rows.Count > 0)
            {

                strEmpCodeAndName4 = "<td style=\"width:20%;background-color: #cacfd2;height: 30px;\" class=\"thT\">Employee</td>";
                strEmpCodeAndName = "<td style=\"width:20%;\" class=\"thT\">" + dt.Rows[0]["EID"].ToString() + "</td>";
                strEmpCodeAndName1 = "<td style=\"width:20%;\" class=\"tdT\">" + dt.Rows[0]["USR_NAME"].ToString() + "</td>";
                strEmpCodeAndName2 = "<td style=\"width:5%;background-color: #cacfd2;height: 30px;\"  class=\"tdT\">Trade</td>";
                strEmpCodeAndName3 = "<td style=\"width:20%;\" class=\"tdT\">" + dt.Rows[0]["DSGN_NAME"].ToString() + "</td>";
            }
            string strCaptionTabstop = "</table>";

            strPrintCaptionTable = strCaptionTabstart + strCaptionTabRprtDate + strEmpCodeAndName4 + strEmpCodeAndName + strEmpCodeAndName1 + strEmpCodeAndName2 + strEmpCodeAndName3 + strCaptionTabstop;

            strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">" + ddate.ToString("dd-MMMM-yyyy") + "</td>";
            if (dtEmp_list.Rows.Count > 0)
            {
                strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">" + dtEmp_list.Rows[0]["JOBMSTR_TITLE"].ToString() + "  </td>";
                strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">" + dtEmp_list.Rows[0]["ATTENDANCE"].ToString() + "</td>";
                strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">8</td>";

                foreach (DataRow row in dtEmp_list.Rows)
                {
                    if (row["OVRTMCATG_NAME"].ToString() == "NORMAL OT")
                    {
                        strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">" + dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString() + "</td>";
                        strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\"></td>";
                        NormlOT += Convert.ToInt32(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString());
                        NormalOvertmRatePrHr = Convert.ToDecimal(row["OVRTMCATG_RATE"].ToString());
                    }
                    if (row["OVRTMCATG_NAME"].ToString() == "HOLIDAY OT")
                    {
                        strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\"></td>";
                        strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">" + dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString() + "</td>";
                        HolidayOT += Convert.ToInt32(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString());
                        HolidayOvertmRatePrHr = Convert.ToDecimal(row["OVRTMCATG_RATE"].ToString());
                    }
                }
                
            }
            else
            {
                strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\"></td>";
                strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\"></td>";
                strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\"></td>";
                strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\"></td>";
                strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\"></td>";
            }

            strCapTable += "</tr>";

        }
        strCapTable += "<td colspan=\"4\" class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\"></td>";
        strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">" + NormlOT + "</td>";
        strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">" + HolidayOT + "</td>";

        strCapTable += "</tr>";
        strCapTable += "</tbody>";
        strCapTable += "</table><br/><br/>";

        cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
        objEnt.Employee = OBJ.Employee;
        objEnt.Month = OBJ.Month;
        objEnt.Year = OBJ.Year;
        DataTable dtSalPrssDtls;
        dtSalPrssDtls = objBuss.ReadSalaryProssDtlsById(objEnt);
        string basicAmt = "", AllowaceAmt = "", AllowovertimeAmount = "", DedctionAmt = "", DedctionInstalmntAmnt = "", Total = "", OT_Hours = "", MessAmnt = "", LvArrearAmnt = "";
        Decimal TotalBasicAllow = 0, TotalDedctn = 0, netsalary = 0, AllowovertimeAmount1 = 0, AllowaceAmt1 = 0, basicAmt1 = 0, instlmntDedctionAmt = 0, deductnamt = 0;
        Decimal decMessAmnt = 0, decLvArrearAmnt = 0;
        if (dtSalPrssDtls.Rows.Count > 0)
        {
            basicAmt = dtSalPrssDtls.Rows[0]["SLRY_BASIC_PAY"].ToString();
            AllowaceAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_ALLOW_AMT"].ToString();
            AllowovertimeAmount = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_OVERTIME_ALLOW_AMT"].ToString();
            DedctionAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_DEDCTN_AMT"].ToString();
            DedctionInstalmntAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_INSTLMNT_DEDCN_AMT"].ToString();
            Total = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_TOTAL_AMT"].ToString();
            if (dtSalPrssDtls.Rows[0]["SLPRCDMNTH_TOTAL_AMT"].ToString() != "")
            {
                OT_Hours = dtSalPrssDtls.Rows[0]["EMDLHRDTL_OT"].ToString();
            }
            MessAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_MESS_DEDCTN_AMT"].ToString();
            LvArrearAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_LEV_ARREAR_AMT"].ToString();
        }
        if (basicAmt != "")
        {
            basicAmt1 = Convert.ToDecimal(basicAmt);
            TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(basicAmt);
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
        if (Total != "")
        {
            netsalary = Convert.ToDecimal(Total);
        }


        string strbasicAmt = objBusiness.AddCommasForNumberSeperation(basicAmt1.ToString("0.00"), objEntityCommon);
        string strAllowaceAmt = objBusiness.AddCommasForNumberSeperation(AllowaceAmt1.ToString("0.00"), objEntityCommon);
        string strAllowovertimeAmount = objBusiness.AddCommasForNumberSeperation(AllowovertimeAmount1.ToString("0.00"), objEntityCommon);
        string strTotalBasicAllow = objBusiness.AddCommasForNumberSeperation(TotalBasicAllow.ToString("0.00"), objEntityCommon);
        string strDeductnAmt = objBusiness.AddCommasForNumberSeperation(deductnamt.ToString("0.00"), objEntityCommon);
        string strDeductnInstlmtAmount = objBusiness.AddCommasForNumberSeperation(instlmntDedctionAmt.ToString("0.00"), objEntityCommon);
        string strTotalDedctn = objBusiness.AddCommasForNumberSeperation(TotalDedctn.ToString("0.00"), objEntityCommon);
        string strMessAmnt = objBusiness.AddCommasForNumberSeperation(decMessAmnt.ToString("0.00"), objEntityCommon);
        string strLvArrearAmnt = objBusiness.AddCommasForNumberSeperation(decLvArrearAmnt.ToString("0.00"), objEntityCommon);
        string strnetsalary = objBusiness.AddCommasForNumberSeperation(netsalary.ToString("0.00"), objEntityCommon);

        strCapTable += "<table class=\"tab\" style=\"width: 85%;margin-left: 6%;margin-bottom:1%;\" cellspacing=\"0\" cellpadding=\"2px\" >";
        strCapTable += "<tbody>";
        strCapTable += "<tr class=\"top_row\">";
        strCapTable += "<td class=\"thT\" ColSpan=\"4\" style=\"word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;background-color: #cacfd2;height: 30px;\">Basic & Allowances</td>";
        strCapTable += "</tr>";
        strCapTable += "<tr><td class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;height: 36px;background-color: #cacfd2;height: 30px;\">Description</td>";
        strCapTable += "<td class=\"thT\"  style=\"width:20%;text-align: right; word-wrap:break-word;height: 36px;background-color: #cacfd2;height: 30px;\">Amount </td>";
        strCapTable += "<td class=\"thT\"  style=\"width:20%;text-align: center; word-wrap:break-word;height: 36px;background-color: #cacfd2;height: 30px;\"> Days/Hrs</td>";
        strCapTable += "<td class=\"thT\"  style=\"width:20%;text-align: right; word-wrap:break-word;height: 36px;background-color: #cacfd2;height: 30px;\">Amount</td></tr>";

        strCapTable += "<tr>";
        strCapTable += "<td class=\"tdT\"  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left; height: 36px;\">Basic Pay</td>";
        strCapTable += "<td class=\"tdT\"  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right; height: 36px;\">" + strbasicAmt + "</td>";
        strCapTable += "<td class=\"tdT\"  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">" + numMonth + "</td>";
        strCapTable += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right; height: 36px;\">" + strbasicAmt + "</td>";
        strCapTable += "</tr>";
        strCapTable += "<tr>";
        strCapTable += "<td class=\"tdT\"  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left; height: 36px;\">Special Allowance</td>";
        strCapTable += "<td class=\"tdT\"  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right; height: 36px;\">" + strAllowaceAmt + "</td>";
        strCapTable += "<td class=\"tdT\"  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\"></td>";
        strCapTable += "<td class=\"tdT\"  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right; height: 36px;\">" + strAllowaceAmt + "</td>";
        strCapTable += "</tr>";
        strCapTable += "<tr>";
        if (NormlOT != 0)
        {
            strCapTable += "<td class=\"tdT\" ColSpan=\"2\" style=\" word-break: break-all; word-wrap:break-word;text-align: left; height: 36px;\">Normal OT @" + NormalOvertmRatePrHr.ToString() + "/hr</td>";
            strCapTable += "<td class=\"tdT\"  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">" + NormlOT.ToString() + "</td>";    
        }
        else
        {
            strCapTable += "<td class=\"tdT\" ColSpan=\"2\" style=\"word-break: break-all; word-wrap:break-word;text-align: left; height: 36px;\">Holiday OT @" + HolidayOvertmRatePrHr.ToString() + "/hr</td>";
            strCapTable += "<td class=\"tdT\"  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">" + HolidayOT.ToString() + "</td>";    
        }
        strCapTable += "<td class=\"tdT\"  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right; height: 36px;\">" + strAllowovertimeAmount + "</td>";
        strCapTable += "</tr>";
        strCapTable += "<tr>";
        strCapTable += "<td class=\"thT\" ColSpan=\"3\"  style=\"word-break: break-all; word-wrap:break-word;text-align: left; height: 36px;\">Total Basic & Allowance</td>";
        strCapTable += "<td class=\"thT\"  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right; height: 36px;\">" + strTotalBasicAllow + "</td>";
        strCapTable += "</tr>";
        strCapTable += "<tr  >";
        strCapTable += "<th class=\"thT\" ColSpan=\"4\" style=\"word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;margin-top:10%;background-color: #cacfd2;height: 30px;\">Deductions</td>";
        strCapTable += "</tr>";
        strCapTable += "<tr>";
        strCapTable += "<td class=\"tdT\" ColSpan=\"3\" style=\"word-break: break-all; word-wrap:break-word;text-align: left; height: 36px;background-color: #cacfd2;height: 30px;\">Deduction Types</td>";
        strCapTable += "<td class=\"tdT\"  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right; height: 36px;background-color: #cacfd2;height: 30px;\">Amount</td>";
        strCapTable += "</tr>";
        strCapTable += "<tr>";
        strCapTable += "<td class=\"tdT\" ColSpan=\"3\" style=\"word-break: break-all; word-wrap:break-word;text-align: left; height: 36px;\">Special Deductions</td>";
        strCapTable += "<td class=\"tdT\"  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right; height: 36px;\">" + strDeductnAmt + "</td>";
        strCapTable += "</tr>";
        strCapTable += "<tr>";
        strCapTable += "<td class=\"tdT\" ColSpan=\"3\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left; height: 36px;\">Installment Deductions</td>";
        strCapTable += "<td class=\"tdT\"  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right; height: 36px;\">" + strDeductnInstlmtAmount + "</td>";
        strCapTable += "</tr>";
        strCapTable += "<tr>";
        strCapTable += "<td class=\"tdT\" ColSpan=\"3\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left; height: 36px;\">Mess Deductions</td>";
        strCapTable += "<td class=\"tdT\"  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right; height: 36px;\">" + strMessAmnt + "</td>";
        strCapTable += "</tr>";
        strCapTable += "<tr>";
        strCapTable += "<td class=\"tdT\" ColSpan=\"3\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left; height: 36px;\">Leave Arrear Deductions</td>";
        strCapTable += "<td class=\"tdT\"  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right; height: 36px;\">" + strLvArrearAmnt + "</td>";
        strCapTable += "</tr>";
        strCapTable += "<tr>";
        strCapTable += "<td class=\"thT\" ColSpan=\"3\" style=\"word-break: break-all; word-wrap:break-word;text-align: left; height: 36px;\">Total Deductions</td>";
        strCapTable += "<td class=\"thT\"  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right; height: 36px;\">" + strTotalDedctn + "</td>";
        strCapTable += "</tr>";
        strCapTable += "<tr  >";
        strCapTable += "<th class=\"thT\" ColSpan=\"4\" style=\"word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;margin-top:10%;background-color: #cacfd2;height: 30px;\">Total</td>";
        strCapTable += "</tr>";
        strCapTable += "<tr>";
        strCapTable += "<td class=\"thT\" ColSpan=\"3\" style=\"word-break: break-all; word-wrap:break-word;text-align: left; height: 36px;\">Net Salary</td>";
        strCapTable += "<td class=\"thT\"  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right; height: 36px;\">" + strnetsalary + "</td>";
        strCapTable += "</tr>";
        strCapTable += "</tbody>";
        strCapTable += "</table>";

        divLabourCardHeader.InnerHtml = strPrintCaptionTable;
        sbCap.Append(strCapTable);
        return sbCap.ToString();
    }

    public void Generate_Payslip_PDF(DataTable dt, cls_Entity_Monthly_Salary_Process objMonthlySalaryProcess)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
        cls_Entity_Monthly_Salary_Process objEntPrcss = new cls_Entity_Monthly_Salary_Process();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        StringBuilder sbPaySlip = new StringBuilder();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntPrcss.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntPrcss.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }

        int NofDaysMonth = DateTime.DaysInMonth(objMonthlySalaryProcess.Year, objMonthlySalaryProcess.Month);
        string strMonthstart = new DateTime(objMonthlySalaryProcess.Year, objMonthlySalaryProcess.Month, 1).ToString("dd-MM-yyyy");
        string strMonthEnd = new DateTime(objMonthlySalaryProcess.Year, objMonthlySalaryProcess.Month, NofDaysMonth).ToString("dd-MM-yyyy");
        DateTime dMonthstart = objCommon.textToDateTime(strMonthstart);
        DateTime dMonthEnd = objCommon.textToDateTime(strMonthEnd);

        objEntPrcss.date = dMonthstart;
        objEntPrcss.CurrentDate = dMonthEnd;
        string MonthName = dMonthstart.ToString("MMMM");
        objEntPrcss.Employee = objMonthlySalaryProcess.Employee;
        objEntPrcss.Month = objMonthlySalaryProcess.Month;
        objEntPrcss.Year = objMonthlySalaryProcess.Year;

        DataTable dtEmp_list = objBuss.ReadEmp_List_For_PaySlip_Print(objEntPrcss);        
        DataTable dtSalPrssDtls = objBuss.ReadSalaryProssDtlsById(objEntPrcss);

        Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);

        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
        {
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

            string strImageName = "Payslip_" + objMonthlySalaryProcess.SalaryPrssId + ".pdf";
            string imgpath = "/CustomFiles/PaySlip/";
            string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.PAYSLIP_PDF);

            FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(imgpath) + strImageName, FileMode.Create);
            PdfWriter.GetInstance(document, file);

            document.Open();

            PdfPTable headtable = new PdfPTable(1);

            string strImageLoc = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CORPORATE_LOGOS) + "quotation-header.png";
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLoc));
            image.ScalePercent(PdfPCell.ALIGN_CENTER);
            image.ScaleToFit(600f, 100f);

            headtable.AddCell(new PdfPCell(image) { Border = 0, PaddingBottom = 20, HorizontalAlignment = Element.ALIGN_CENTER, });
            document.Add(headtable);


            PdfPTable headLayout = new PdfPTable(1);
            headLayout.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
            headLayout.AddCell(new PdfPCell(new Phrase("Payslip for the Month of " + MonthName + ", " + objEntPrcss.Year, FontFactory.GetFont("Times New Roman", 14, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
            headLayout.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Times New Roman", 30, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
            document.Add(headLayout);

            int AttendncCount = 0;

            for (int intRowBodyCount = 1; intRowBodyCount <= dtEmp_list.Rows.Count; intRowBodyCount++)
            {
                if (dtEmp_list.Rows[0]["ATTENDANCE"].ToString() == "P")
                {
                    AttendncCount++;
                }
            }

            string basicAmt = "", AllowaceAmt = "", SalaryProcssdBasicAmt = "", AllowovertimeAmount = "", DedctionAmt = "", DedctionInstalmntAmnt = "", Total = "", OT_Hours = "", MessAmnt = "", LvArrearAmnt = "";
            Decimal TotalBasicAllow = 0, TotalDedctn = 0, netsalary = 0, AllowovertimeAmount1 = 0, AllowaceAmt1 = 0, basicAmt1 = 0, decSalaryProcssdBasicAmt = 0, spclDedctionAmt = 0, instlmntDedctionAmt = 0;
            Decimal decMessAmnt = 0, decLvArrearAmnt = 0;
            if (dtSalPrssDtls.Rows.Count > 0)
            {
                basicAmt = dtSalPrssDtls.Rows[0]["SLRY_BASIC_PAY"].ToString();
                SalaryProcssdBasicAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_PRSD_BASICPAY"].ToString();
                AllowaceAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_ALLOW_AMT"].ToString();
                AllowovertimeAmount = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_OVERTIME_ALLOW_AMT"].ToString();
                DedctionAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_DEDCTN_AMT"].ToString();
                DedctionInstalmntAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_INSTLMNT_DEDCN_AMT"].ToString();
                Total = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_TOTAL_AMT"].ToString();
                if (dtSalPrssDtls.Rows[0]["SLPRCDMNTH_TOTAL_AMT"].ToString() != "")
                {
                    OT_Hours = dtSalPrssDtls.Rows[0]["EMDLHRDTL_OT"].ToString();
                }
                MessAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_MESS_DEDCTN_AMT"].ToString();
                LvArrearAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_LEV_ARREAR_AMT"].ToString();
            }
            if (basicAmt != "")
            {
                basicAmt1 = Convert.ToDecimal(basicAmt);
             //   TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(basicAmt);
            }

            if (SalaryProcssdBasicAmt != "")
            {
                decSalaryProcssdBasicAmt = Convert.ToDecimal(SalaryProcssdBasicAmt);
                TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(SalaryProcssdBasicAmt);

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
            if (DedctionAmt != "")
            {
                spclDedctionAmt = Convert.ToDecimal(DedctionAmt);
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
            if (Total != "")
            {
                netsalary = Convert.ToDecimal(Total);
            }
            string strbasicAmt = objBusiness.AddCommasForNumberSeperation(basicAmt1.ToString("0.00"), objEntityCommon);
            string strSalaryProcssdBasicAmt = objBusiness.AddCommasForNumberSeperation(decSalaryProcssdBasicAmt.ToString("0.00"), objEntityCommon);

            string strAllowaceAmt = objBusiness.AddCommasForNumberSeperation(AllowaceAmt1.ToString("0.00"), objEntityCommon);
            string strAllowovertimeAmount = objBusiness.AddCommasForNumberSeperation(AllowovertimeAmount1.ToString("0.00"), objEntityCommon);
            string strTotalBasicAllow = objBusiness.AddCommasForNumberSeperation(TotalBasicAllow.ToString("0.00"), objEntityCommon);
            string strTotalDedctn = objBusiness.AddCommasForNumberSeperation(TotalDedctn.ToString("0.00"), objEntityCommon);
            string strspclDedctionAmt = objBusiness.AddCommasForNumberSeperation(spclDedctionAmt.ToString("0.00"), objEntityCommon);
            string strinstlmntDedctionAmt = objBusiness.AddCommasForNumberSeperation(instlmntDedctionAmt.ToString("0.00"), objEntityCommon);
            string strnetsalary = objBusiness.AddCommasForNumberSeperation(netsalary.ToString("0.00"), objEntityCommon);
            string strMessAmnt = objBusiness.AddCommasForNumberSeperation(decMessAmnt.ToString("0.00"), objEntityCommon);
            string strLvArrearAmnt = objBusiness.AddCommasForNumberSeperation(decLvArrearAmnt.ToString("0.00"), objEntityCommon);

            PdfPTable tableheadlayout = new PdfPTable(5);
            float[] tableheadlayoutBody = { 15, 43, 7, 23, 12 };
            tableheadlayout.SetWidths(tableheadlayoutBody);
            tableheadlayout.WidthPercentage = 100;

            if (dt.Rows.Count > 0)
            {

                tableheadlayout.AddCell(new PdfPCell(new Phrase("Employee #", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["EID"].ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });


                tableheadlayout.AddCell(new PdfPCell(new Phrase("Name", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["USR_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });

                tableheadlayout.AddCell(new PdfPCell(new Phrase("Department", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["CPRDEPT_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });

                tableheadlayout.AddCell(new PdfPCell(new Phrase("Designation", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["DSGN_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase("Eligible Days", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase(NofDaysMonth.ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });

                tableheadlayout.AddCell(new PdfPCell(new Phrase("Job Title", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["JOBRL_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase("Present Days", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase(AttendncCount.ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            }
            document.Add(tableheadlayout);

            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 20, BaseColor.BLACK))));
            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 20, BaseColor.BLACK))));

            PdfPTable tablelayout = new PdfPTable(7);
            float[] tablelayoutBody = { 22, 13, 8, 13, 7, 23, 12 };
            tablelayout.SetWidths(tablelayoutBody);
            tablelayout.WidthPercentage = 100;

            tablelayout.AddCell(new PdfPCell(new Phrase("Basic and Allowances", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6, Colspan = 4, BackgroundColor = BaseColor.LIGHT_GRAY });
            tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase("Deduction", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6, Colspan = 2, BackgroundColor = BaseColor.LIGHT_GRAY });

            tablelayout.AddCell(new PdfPCell(new Phrase("Description", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase("Hours", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase("Earned", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6, Colspan = 2 });

            tablelayout.AddCell(new PdfPCell(new Phrase("Basic Pay", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(strbasicAmt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(strSalaryProcssdBasicAmt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase("Special Deduction", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(strspclDedctionAmt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });

            tablelayout.AddCell(new PdfPCell(new Phrase("Special Allowance", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(strAllowaceAmt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(strAllowaceAmt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase("Installment Deduction", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(strinstlmntDedctionAmt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });

            tablelayout.AddCell(new PdfPCell(new Phrase("Over Time Allowance", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(strAllowovertimeAmount, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(OT_Hours, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(strAllowovertimeAmount, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase("Mess Deduction", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(strMessAmnt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });


            tablelayout.AddCell(new PdfPCell(new Phrase("Total Basic & Allowances", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6, Colspan = 3 });
            tablelayout.AddCell(new PdfPCell(new Phrase(strTotalBasicAllow, FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase("Leave Arrear Deduction", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(strLvArrearAmnt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });

            tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase("Total Deduction", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(strTotalDedctn, FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });

            document.Add(tablelayout);

            PdfPTable tablelayoutnet = new PdfPTable(3);
            float[] tablenetlayoutBody = { 68, 23, 12 };
            tablelayoutnet.SetWidths(tablenetlayoutBody);
            tablelayoutnet.WidthPercentage = 100;

            tablelayoutnet.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6, Colspan = 3 });
            tablelayoutnet.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6, Colspan = 3 });

            tablelayoutnet.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
            tablelayoutnet.AddCell(new PdfPCell(new Phrase("Net Salary", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tablelayoutnet.AddCell(new PdfPCell(new Phrase(strnetsalary, FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6, });

            document.Add(tablelayoutnet);

            PdfPTable endtable = new PdfPTable(6);
            float[] endBody = { 25, 10, 25, 10, 25, 5 };
            endtable.SetWidths(endBody);
            endtable.WidthPercentage = 100;

            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6, Colspan = 6 });
            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6, Colspan = 6 });

            endtable.AddCell(new PdfPCell(new Phrase("Prepared By", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
            endtable.AddCell(new PdfPCell(new Phrase("Checked By", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
            endtable.AddCell(new PdfPCell(new Phrase("Received By", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });

            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthTop = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthTop = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthTop = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });

            document.Add(endtable);

            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 40, BaseColor.BLACK))));


            PdfPTable footrtable = new PdfPTable(2);
            float[] headersBodyfootr = { 0, 100 };
            footrtable.SetWidths(headersBodyfootr);
            footrtable.WidthPercentage = 100;

            string strImageLocFooter = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CORPORATE_LOGOS) + "quotation-footer.png";
            iTextSharp.text.Image imageFootr = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLocFooter));
            imageFootr.ScalePercent(PdfPCell.ALIGN_LEFT);
            imageFootr.ScaleToFit(520f, 60f);

            footrtable.AddCell(new PdfPCell(new Phrase(" ")) { Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_LEFT });
            footrtable.AddCell(new PdfPCell(imageFootr) { Border = 0, PaddingBottom = 10, HorizontalAlignment = Element.ALIGN_LEFT });
            document.Add(footrtable);

            document.Close();

            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=Payslip_" + objMonthlySalaryProcess.SalaryPrssId + ".pdf");
            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();
            Response.Close();
        }
    }


    public void Generate_LabourCard_PDF(DataTable dt,cls_Entity_Monthly_Salary_Process OBJ)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
        cls_Entity_Monthly_Salary_Process objEntPrcss = new cls_Entity_Monthly_Salary_Process();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        StringBuilder sbCap = new StringBuilder();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntPrcss.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntPrcss.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }

        Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);

        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
        {
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

            string strImageName = "LabourCard_" + OBJ.SalaryPrssId + ".pdf";
            string imgpath = "/CustomFiles/PaySlip/";
            string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.PAYSLIP_PDF);

            FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(imgpath) + strImageName, FileMode.Create);
            PdfWriter.GetInstance(document, file);

            document.Open();

            PdfPTable headtable = new PdfPTable(1);

            string strImageLoc = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CORPORATE_LOGOS) + "quotation-header.png";
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLoc));
            image.ScalePercent(PdfPCell.ALIGN_CENTER);
            image.ScaleToFit(600f, 100f);

            headtable.AddCell(new PdfPCell(image) { Border = 0, PaddingBottom = 20, HorizontalAlignment = Element.ALIGN_CENTER, });
            document.Add(headtable);

            PdfPTable tableLayout = new PdfPTable(6);
            float[] headersBody = { 19, 19, 12, 17, 17, 16 };
            tableLayout.SetWidths(headersBody);
            tableLayout.WidthPercentage = 100;

            tableLayout.AddCell(new PdfPCell(new Phrase("Date", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 8 });
            tableLayout.AddCell(new PdfPCell(new Phrase("Job #", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 8 });
            tableLayout.AddCell(new PdfPCell(new Phrase("Status", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 8 });
            tableLayout.AddCell(new PdfPCell(new Phrase("Normal Hrs", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 8 });
            tableLayout.AddCell(new PdfPCell(new Phrase("Normal OT", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 8 });
            tableLayout.AddCell(new PdfPCell(new Phrase("Holiday OT", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 8 });

            int numMonth = DateTime.DaysInMonth(OBJ.Year, OBJ.Month);

            string MonthName = "";

            int NormlOT = 0, HoldayOt = 0;
            decimal NormalOvertmRatePrHr = 0, HolidayOvertmRatePrHr = 0;

            for (int intRowBodyCount = 1; intRowBodyCount <= numMonth; intRowBodyCount++)
            {
                string EmDate = new DateTime(OBJ.Year, OBJ.Month, intRowBodyCount).ToString("dd-MM-yyyy");
                DateTime ddate = objCommon.textToDateTime(EmDate);

                objEntPrcss.date = ddate;
                MonthName = ddate.ToString("MMMM");
                objEntPrcss.Employee = OBJ.Employee;
                objEntPrcss.Month = OBJ.Month;
                objEntPrcss.Year = OBJ.Year;
                DataTable dtEmp_list = objBuss.ReadEmp_List_For_Print(objEntPrcss);

                tableLayout.AddCell(new PdfPCell(new Phrase(ddate.ToString("dd-MMMM-yyyy"), FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 });
                if (dtEmp_list.Rows.Count > 0)
                {

                    tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["JOBMSTR_TITLE"].ToString(), FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["ATTENDANCE"].ToString(), FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 });
                    if (dtEmp_list.Rows[0]["ATTENDANCE"].ToString() == "P")
                    {
                        tableLayout.AddCell(new PdfPCell(new Phrase("8", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, });
                    }
                    else if (dtEmp_list.Rows[0]["ATTENDANCE"].ToString() == "A")
                    {
                        tableLayout.AddCell(new PdfPCell(new Phrase("0", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, });
                    }
                    foreach (DataRow row in dtEmp_list.Rows)
                    {

                        if (row["OVRTMCATG_NAME"].ToString() == "NORMAL OT")
                        {
                            tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString(), FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 });
                            NormlOT += Convert.ToInt32(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString());
                            NormalOvertmRatePrHr = Convert.ToDecimal(row["OVRTMCATG_RATE"].ToString());
                        }
                        else
                        {
                            tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 });
                        }
                        if (row["OVRTMCATG_NAME"].ToString() == "HOLIDAY OT")
                        {
                            tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString(), FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 });
                            HoldayOt += Convert.ToInt32(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString());
                            HolidayOvertmRatePrHr = Convert.ToDecimal(row["OVRTMCATG_RATE"].ToString());
                        }
                        else
                        {
                            tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 });
                        }
                    }
                }
                else
                {
                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 });
                }
            }
            tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 4 });
            tableLayout.AddCell(new PdfPCell(new Phrase(NormlOT.ToString(), FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tableLayout.AddCell(new PdfPCell(new Phrase(HoldayOt.ToString(), FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER });

            PdfPTable headLayout = new PdfPTable(1);
            headLayout.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
            headLayout.AddCell(new PdfPCell(new Phrase("Labor Card For " + MonthName + "-" + objEntPrcss.Year, FontFactory.GetFont("Times New Roman", 14, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
            headLayout.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Times New Roman", 25, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
            document.Add(headLayout);

            PdfPTable tableheadlayout = new PdfPTable(5);
            float[] tableheadlayoutBody = { 14, 25, 27, 10, 24 };
            tableheadlayout.SetWidths(tableheadlayoutBody);
            tableheadlayout.WidthPercentage = 100;

            tableheadlayout.AddCell(new PdfPCell(new Phrase("Employee", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 7 });
            if (dt.Rows.Count>0)
            {
                tableheadlayout.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["EID"].ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["USR_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase("Trade", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 7 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["DSGN_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7 });
            }
            else
            {
                tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase("Trade", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 7 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7 });
            }

            document.Add(tableheadlayout);

            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 25, BaseColor.BLACK))));

            document.Add(tableLayout);

            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 25, BaseColor.BLACK))));



            cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
            objEnt.Employee = OBJ.Employee;
            objEnt.Month = OBJ.Month;
            objEnt.Year = OBJ.Year;
            DataTable dtSalPrssDtls;
            dtSalPrssDtls = objBuss.ReadSalaryProssDtlsById(objEnt);
            string basicAmt = "", AllowaceAmt = "", AllowovertimeAmount = "", DedctionAmt = "", DedctionInstalmntAmnt = "", Total = "", OT_Hours = "", MessAmnt = "", LvArrearAmnt = "";
            Decimal TotalBasicAllow = 0, TotalDedctn = 0, netsalary = 0, AllowovertimeAmount1 = 0, AllowaceAmt1 = 0, basicAmt1 = 0, instlmntDedctionAmt = 0, deductnamt = 0;
            Decimal decMessAmnt = 0, decLvArrearAmnt = 0;
            if (dtSalPrssDtls.Rows.Count > 0)
            {
                basicAmt = dtSalPrssDtls.Rows[0]["SLRY_BASIC_PAY"].ToString();
                AllowaceAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_ALLOW_AMT"].ToString();
                AllowovertimeAmount = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_OVERTIME_ALLOW_AMT"].ToString();
                DedctionAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_DEDCTN_AMT"].ToString();
                DedctionInstalmntAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_INSTLMNT_DEDCN_AMT"].ToString();
                Total = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_TOTAL_AMT"].ToString();
                if (dtSalPrssDtls.Rows[0]["SLPRCDMNTH_TOTAL_AMT"].ToString() != "")
                {
                    OT_Hours = dtSalPrssDtls.Rows[0]["EMDLHRDTL_OT"].ToString();
                }
                MessAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_MESS_DEDCTN_AMT"].ToString();
                LvArrearAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_LEV_ARREAR_AMT"].ToString();
            }
            if (basicAmt != "")
            {
                basicAmt1 = Convert.ToDecimal(basicAmt);
                TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(basicAmt);
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
            if (Total != "")
            {
                netsalary = Convert.ToDecimal(Total);
            }


            string strbasicAmt = objBusiness.AddCommasForNumberSeperation(basicAmt1.ToString("0.00"), objEntityCommon);
            string strAllowaceAmt = objBusiness.AddCommasForNumberSeperation(AllowaceAmt1.ToString("0.00"), objEntityCommon);
            string strAllowovertimeAmount = objBusiness.AddCommasForNumberSeperation(AllowovertimeAmount1.ToString("0.00"), objEntityCommon);
            string strTotalBasicAllow = objBusiness.AddCommasForNumberSeperation(TotalBasicAllow.ToString("0.00"), objEntityCommon);
            string strDeductnAmt = objBusiness.AddCommasForNumberSeperation(deductnamt.ToString("0.00"), objEntityCommon);
            string strDeductnInstlmtAmount = objBusiness.AddCommasForNumberSeperation(instlmntDedctionAmt.ToString("0.00"), objEntityCommon);
            string strTotalDedctn = objBusiness.AddCommasForNumberSeperation(TotalDedctn.ToString("0.00"), objEntityCommon);
            string strnetsalary = objBusiness.AddCommasForNumberSeperation(netsalary.ToString("0.00"), objEntityCommon);
            string strMessAmnt = objBusiness.AddCommasForNumberSeperation(decMessAmnt.ToString("0.00"), objEntityCommon);
            string strLvArrearAmnt = objBusiness.AddCommasForNumberSeperation(decLvArrearAmnt.ToString("0.00"), objEntityCommon);


            PdfPTable sumtable = new PdfPTable(6);
            float[] footrsBody = { 14, 28, 16, 13, 15, 14 };
            sumtable.SetWidths(footrsBody);
            sumtable.WidthPercentage = 100;

            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            sumtable.AddCell(new PdfPCell(new Phrase("Basic and Allowances", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 8, BackgroundColor = BaseColor.LIGHT_GRAY, Colspan = 4 });
            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            sumtable.AddCell(new PdfPCell(new Phrase("Description", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 8 });
            sumtable.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 8 });
            sumtable.AddCell(new PdfPCell(new Phrase("Days/Hrs", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 8 });
            sumtable.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 8 });
            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            sumtable.AddCell(new PdfPCell(new Phrase("Basic Pay", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8 });
            sumtable.AddCell(new PdfPCell(new Phrase(strbasicAmt, FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8 });
            sumtable.AddCell(new PdfPCell(new Phrase(numMonth.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8 });
            sumtable.AddCell(new PdfPCell(new Phrase(strbasicAmt, FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8 });
            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            sumtable.AddCell(new PdfPCell(new Phrase("Special Allowance", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8 });
            sumtable.AddCell(new PdfPCell(new Phrase(strAllowaceAmt, FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8 });
            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8 });
            sumtable.AddCell(new PdfPCell(new Phrase(strAllowaceAmt, FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8 });
            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            if (NormlOT != 0)
            {
                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                sumtable.AddCell(new PdfPCell(new Phrase("Normal OT @" + NormalOvertmRatePrHr.ToString() + "/hr", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8, Colspan = 2 });
                sumtable.AddCell(new PdfPCell(new Phrase(NormlOT.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8 });
                sumtable.AddCell(new PdfPCell(new Phrase(strAllowovertimeAmount, FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8 });
                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8 });
            }
            if (HoldayOt != 0)
            {
                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                sumtable.AddCell(new PdfPCell(new Phrase("Holiday OT @" + HolidayOvertmRatePrHr.ToString() + "/hr", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8, Colspan = 2 });
                sumtable.AddCell(new PdfPCell(new Phrase(HoldayOt.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8 });
                sumtable.AddCell(new PdfPCell(new Phrase(strAllowovertimeAmount, FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8 });
                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8 });
            }
            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            sumtable.AddCell(new PdfPCell(new Phrase("Total Basic and Allowances", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8, Colspan = 3 });
            sumtable.AddCell(new PdfPCell(new Phrase(strTotalBasicAllow, FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8 });
            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            sumtable.AddCell(new PdfPCell(new Phrase("Deductions", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 8, BackgroundColor = BaseColor.LIGHT_GRAY, Colspan = 4 });
            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            sumtable.AddCell(new PdfPCell(new Phrase("Deduction Types", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8, Colspan = 3, BackgroundColor = BaseColor.LIGHT_GRAY, });
            sumtable.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8, BackgroundColor = BaseColor.LIGHT_GRAY, });
            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            sumtable.AddCell(new PdfPCell(new Phrase("Special Deductions", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8, Colspan = 3 });
            sumtable.AddCell(new PdfPCell(new Phrase(strDeductnAmt, FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8 });
            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            sumtable.AddCell(new PdfPCell(new Phrase("Installment Deductions", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8, Colspan = 3 });
            sumtable.AddCell(new PdfPCell(new Phrase(strDeductnInstlmtAmount, FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8 });
            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });


            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            sumtable.AddCell(new PdfPCell(new Phrase("Mess Deductions", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8, Colspan = 3 });
            sumtable.AddCell(new PdfPCell(new Phrase(strMessAmnt, FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8 });
            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            sumtable.AddCell(new PdfPCell(new Phrase("Leave Arrear Deductions", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8, Colspan = 3 });
            sumtable.AddCell(new PdfPCell(new Phrase(strLvArrearAmnt, FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8 });
            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });


            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            sumtable.AddCell(new PdfPCell(new Phrase("Total Deductions", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8, Colspan = 3 });
            sumtable.AddCell(new PdfPCell(new Phrase(strTotalDedctn, FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8 });
            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            sumtable.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 8, BackgroundColor = BaseColor.LIGHT_GRAY, Colspan = 4 });
            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            sumtable.AddCell(new PdfPCell(new Phrase("Net Salary", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8, Colspan = 3 });
            sumtable.AddCell(new PdfPCell(new Phrase(strnetsalary, FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8 });
            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

            document.Add(sumtable);

            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 20, BaseColor.BLACK))));
            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 20, BaseColor.BLACK))));
            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 20, BaseColor.BLACK))));


            PdfPTable endtable = new PdfPTable(6);
            float[] endBody = { 25, 10, 25, 10, 25, 5 };
            endtable.SetWidths(endBody);
            endtable.WidthPercentage = 100;

            endtable.AddCell(new PdfPCell(new Phrase("Finance Manager", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
            endtable.AddCell(new PdfPCell(new Phrase("General Manager", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
            endtable.AddCell(new PdfPCell(new Phrase("Receiver signature", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });

            document.Add(endtable);

            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 40, BaseColor.BLACK))));
            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 40, BaseColor.BLACK))));


            PdfPTable footrtable = new PdfPTable(2);
            float[] headersBodyfootr = { 0, 100 };
            footrtable.SetWidths(headersBodyfootr);
            footrtable.WidthPercentage = 100;

            string strImageLocFooter = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CORPORATE_LOGOS) + "quotation-footer.png";
            iTextSharp.text.Image imageFootr = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLocFooter));
            imageFootr.ScalePercent(PdfPCell.ALIGN_LEFT);
            imageFootr.ScaleToFit(520f, 60f);

            footrtable.AddCell(new PdfPCell(new Phrase(" ")) { Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_LEFT });
            footrtable.AddCell(new PdfPCell(imageFootr) { Border = 0, PaddingBottom = 10, HorizontalAlignment = Element.ALIGN_LEFT });
            document.Add(footrtable);

            document.Close();

            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=LabourCard_" + OBJ.SalaryPrssId + ".pdf");
            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();
            Response.Close();
        }
    }

    protected void btnprint_Click(object sender, EventArgs e)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntityLayerPayslipGeneratn objEntityLayerPayslip = new clsEntityLayerPayslipGeneratn();
        clsBusinessLayerPayslipGeneratn objBusinessPayslip = new clsBusinessLayerPayslipGeneratn();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLayerPayslip.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityLayerPayslip.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        objEntityLayerPayslip.Month = Convert.ToInt32(ddlMonth.SelectedItem.Value);
        objEntityLayerPayslip.Year = Convert.ToInt32(ddlYear.SelectedItem.Value);

        DataTable dtEmpSlryPrcsd = objBusinessPayslip.ReadProcessdEmployees(objEntityLayerPayslip);

        cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
        cls_Entity_Monthly_Salary_Process objEntPrcss = new cls_Entity_Monthly_Salary_Process();

        objEntPrcss.UserId = objEntityLayerPayslip.UserId;
        objEntPrcss.Employee = objEntityLayerPayslip.UserId;
        objEntPrcss.Month = Convert.ToInt32(ddlMonth.SelectedItem.Value);
        objEntPrcss.Year = Convert.ToInt32(ddlYear.SelectedItem.Value);
        objEntPrcss.PaidFinish = 1;
        objEntPrcss.CorpOffice = objEntityLayerPayslip.CorpId;
        if (dtEmpSlryPrcsd.Rows.Count > 0)
        {
            objEntPrcss.date = objCommon.textToDateTime(dtEmpSlryPrcsd.Rows[0]["SLPRCDMNTH_FROM_DATE"].ToString());
            objEntPrcss.Dep = Convert.ToInt32(dtEmpSlryPrcsd.Rows[0]["CPRDEPT_ID"].ToString());
            objEntPrcss.SalaryPrssId = Convert.ToInt32(dtEmpSlryPrcsd.Rows[0]["SLPRCDMNTH_ID"].ToString());

            if (hiddenStaffWrkr.Value == "0")
            {
                objEntPrcss.StffWrkr = 0;
                Generate_Payslip_PDF(dtEmpSlryPrcsd, objEntPrcss);
            }
            else
            {
                objEntPrcss.StffWrkr = 0;
                string strHtmlEmp_list = ConvertDataTableToHtmlEmp_list(dtEmpSlryPrcsd, objEntPrcss);
                Generate_LabourCard_PDF(dtEmpSlryPrcsd, objEntPrcss);
            }

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SalaryNotPrcsdMessage", "SalaryNotPrcsdMessage();", true);
        }
    }


}