using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Text;
using System.Globalization;
using System.IO;
public partial class HCM_HCM_Reports_hcm_Payroll_Process_Report_hcm_Payroll_Process_Report : System.Web.UI.Page
{
    clsBusiness_Payroll_Report objBusinssPayroll = new clsBusiness_Payroll_Report();
    clsEntityPayrollProcess objEntityPayroll = new clsEntityPayrollProcess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityPayroll.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                objEntityPayroll.OrganizatonId = Convert.ToInt32(Session["ORGID"].ToString());
                hiddenOrgId.Value = Session["ORGID"].ToString();
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            DataTable dtDepts = new DataTable();
            dtDepts = objBusinssPayroll.ReadDepts(objEntityPayroll);

            ddlDepartmnt.Items.Clear();
            ddlDepartmnt.DataSource = dtDepts;
            ddlDepartmnt.DataTextField = "CPRDEPT_NAME";
            ddlDepartmnt.DataValueField = "CPRDEPT_ID";
            ddlDepartmnt.DataBind();
            ddlDepartmnt.Items.Insert(0, "--SELECT DEPARTMENT--");

            DataTable dtDivision = new DataTable();
            dtDivision = objBusinssPayroll.ReadDivision(objEntityPayroll);

            ddlDivision.Items.Clear();
            ddlDivision.DataSource = dtDivision;
            ddlDivision.DataTextField = "CPRDIV_NAME";
            ddlDivision.DataValueField = "CPRDIV_ID";
            ddlDivision.DataBind();

            ddlDivision.Items.Insert(0, "--SELECT DIVISION--");

            DataTable dtAccomodation = new DataTable();
            dtAccomodation = objBusinssPayroll.LoadBank(objEntityPayroll);

            ddlBank.Items.Clear();
            ddlBank.DataSource = dtAccomodation;
            ddlBank.DataTextField = "BANK_NAME";
            ddlBank.DataValueField = "BANK_ID";
            ddlBank.DataBind();

            ddlBank.Items.Insert(0, "--SELECT BANK--");

            YearLoad();
            monthLoad();
            DataTable dtPayrollList = new DataTable();
            dtPayrollList = objBusinssPayroll.LoadPayrollReport(objEntityPayroll);

            string strHtm = ConvertDataTableToHTML(dtPayrollList);
            divReport.InnerHtml = strHtm;
            DataTable dtCorp = objBusinssPayroll.ReadCorporateAddress(objEntityPayroll);

            string strPrintReport = ConvertDataTableForPrint(dtPayrollList, dtCorp);
            divPrintReport.InnerHtml = strPrintReport;
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
            ddlMonth.Items.Add(new ListItem(info.GetMonthName(i).ToUpper(), i.ToString()));
        }
        ddlMonth.Items.Insert(0, "--SELECT MONTH--");
    }


    protected void ddlDepartmnt_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPayroll.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityPayroll.OrganizatonId = Convert.ToInt32(Session["ORGID"].ToString());
            hiddenOrgId.Value = Session["ORGID"].ToString();
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        ddlDivision.Items.Clear();
        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
        if (ddlDepartmnt.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            int Dept = Convert.ToInt32(ddlDepartmnt.SelectedItem.Value);
            objEntityPayroll.DepartmentId = Dept;

            DataTable dtSubConrt = objBusinssPayroll.ReadDivision(objEntityPayroll); ;
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
    public string ConvertDataTableToHTML(DataTable dt)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:1%;text-align: left; word-wrap:break-word;\">EMPLOYEE</th>";
            }
            //if (intColumnHeaderCount == 3)
            //{
            //    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">DESIGNATION</th>";
            //}
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: right; word-wrap:break-word;\">BASIC PAY</th>";
            }
           
            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\"> ADDITION</th>";
            }
            if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">DEDUCTION</th>";
            }
            if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: right; word-wrap:break-word;\">TOTAL SALARY</th>";
            }
            if (intColumnHeaderCount == 8)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">BANK</th>";
            }
            if (intColumnHeaderCount == 9)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">STATUS</th>";
            }
        }
        strHtml += "</tr>";
        strHtml += "</thead>";
        strHtml += "<tbody>";

        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr  >";
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                if (dt.Rows.Count > 0)
                {
                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USRNAME"].ToString() + "</td>";
                    }
                    //if (intColumnBodyCount == 3)
                    //{
                    //    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DSGN_NAME"].ToString() + "</td>";
                    //}
                    if (intColumnBodyCount == 4)
                    {
                        string strBPAmt = "";
                        if (dt.Rows[intRowBodyCount]["SLRY_BASIC_PAY"].ToString() == "")
                        {
                            strBPAmt = "0.00";
                        }
                        else
                        {
                            strBPAmt = dt.Rows[intRowBodyCount]["SLRY_BASIC_PAY"].ToString();
                        }
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strBPAmt + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                    }
                    //EVM-0027
                    Decimal TotalSal = 0;
                    if (intColumnBodyCount == 5)
                    {
                        Decimal dclAllow = 0;
                        Decimal dclOverAllow = 0;
                        Decimal TotalAllow = 0;
                      

                           
                            if (dt.Rows[intRowBodyCount]["ALLOWANCE"].ToString() != "")
                            {
                                dclAllow = Convert.ToDecimal(dt.Rows[intRowBodyCount]["ALLOWANCE"].ToString());
                            }
                            if (dt.Rows[intRowBodyCount]["OVERALLOWANCE"].ToString() != "")
                            {
                                dclOverAllow = Convert.ToDecimal(dt.Rows[intRowBodyCount]["OVERALLOWANCE"].ToString());
                            }
                            TotalAllow = dclAllow + dclOverAllow;
                            if (TotalAllow == 0)
                            {
                                TotalAllow = Convert.ToDecimal("0.00");
                            }
                            if (ddlSearchOption.SelectedItem.Value == "0")
                            {

                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >Total:" + TotalAllow + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                           }
                         else
                         {
                            string Allowance = "";
                            Decimal Amount = 0;
                          
                            Int32 ProceeId =Convert.ToInt32(dt.Rows[intRowBodyCount]["SLPRCDMNTH_ID"].ToString());
                            objEntityPayroll.ProcessId = ProceeId;
                            DataTable dtAllowance = objBusinssPayroll.ReadAllowanceDetails(objEntityPayroll);
                            if (dtAllowance.Rows.Count > 0)
                            {
                                Decimal totalAmt = 0;

                                strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><table style=\" width:100%;border:0;\" >";
                                for (int i = 0; i < dtAllowance.Rows.Count; i++)
                                {
                                    Allowance = dtAllowance.Rows[i]["PAYRL_NAME"].ToString();
                                    Amount = Convert.ToDecimal(dtAllowance.Rows[i]["SLRYPROSALLCE_AMOUNT"].ToString());

                                    totalAmt = totalAmt + Amount;
                                    TotalSal = totalAmt;
                                    strHtml += "<tr style=\" background: transparent;\"><td style=\" width:60%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + Allowance + "</td><td style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"> " + Amount + "</td><td style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"> " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td></tr>";
                                }
                                if (dt.Rows[intRowBodyCount]["SLPRCDMNTH_CONFRMSTS"].ToString() != "1")
                                {
                                   TotalAllow = TotalAllow + totalAmt;
                                }
                                  
                                    if (dclOverAllow != 0)
                                    {
                                         dclOverAllow = Convert.ToDecimal(dt.Rows[intRowBodyCount]["OVERALLOWANCE"].ToString());
                                         strHtml += "<tr style=\" background: transparent;\"><td  style=\" width:60%;word-break: break-all; word-wrap:break-word;text-align: left;\"> OVERTIME ALLOWANCE  </td><td  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + dclOverAllow + "</td><td  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"> " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td></tr>";
                                    }
                                 strHtml += "<tr style=\" background: transparent;\"><td  style=\" width:60%;word-break: break-all; word-wrap:break-word;text-align: left;\"><p>Total</td><td  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + TotalAllow + "</td><td  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"> " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td></p><tr></table></td>";
                               // strHtml += "</table></td>";
                                 TotalSal = totalAmt;
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><table style=\" width:100%;\" >";
                                if (dclAllow != 0)
                                {
                                    dclAllow = Convert.ToDecimal(dt.Rows[intRowBodyCount]["ALLOWANCE"].ToString());
                                    strHtml += "<tr style=\" background: transparent;\"> <td  style=\" width:60%;word-break: break-all; word-wrap:break-word;text-align: left;\">SPECIAL ALLOWANCE </td><td  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"> " + dclAllow + " </td><td  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"> " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td></tr>";
                                }
                                if (dclOverAllow != 0)
                                {
                                    dclOverAllow = Convert.ToDecimal(dt.Rows[intRowBodyCount]["OVERALLOWANCE"].ToString());
                                    strHtml += "<tr style=\" background: transparent;\"> <td  style=\" width:60%;word-break: break-all; word-wrap:break-word;text-align: left;\"> OVERTIME ALLOWANCE </td><td  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"> " + dclOverAllow + " </td><td  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"> " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td></tr>";
                                    //strHtml += "<tr style=\" background: transparent;\"> OVERTIME ALLOWANCE  " + dclOverAllow + "</td><td> " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</tr>";
                                }

                                strHtml += "<tr style=\"background: transparent;\"><td>Total</td><td>" + TotalAllow + "</td><td> " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td><tr></table></td>";
                              
                             //  strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; color:red; word-wrap:break-word;text-align: left;\" >Total:" + TotalAllow + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                               // strHtml += "</table></td>";
                                TotalSal = TotalAllow;
                            }
                            
                        }
                    }
                  


                    if (intColumnBodyCount == 6)
                    {
                        Decimal dclDedu = 0;
                        Decimal dclInstallDedu = 0;
                        Decimal TotalDeduction = 0;
                       
                            if (dt.Rows[intRowBodyCount]["DEDUCTION"].ToString() != "")
                            {
                                dclDedu = Convert.ToDecimal(dt.Rows[intRowBodyCount]["DEDUCTION"].ToString());
                            }
                            if (dt.Rows[intRowBodyCount]["INSTALMENT_DEDUCTION"].ToString() != "")
                            {
                                dclInstallDedu = Convert.ToDecimal(dt.Rows[intRowBodyCount]["INSTALMENT_DEDUCTION"].ToString());
                            }
                            TotalDeduction = dclDedu + dclInstallDedu;
                            if (TotalDeduction == 0)
                            {
                                TotalDeduction = Convert.ToDecimal("0.00");
                            }
                            if (ddlSearchOption.SelectedItem.Value == "0")
                            {
                                 strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + TotalDeduction + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                            }
                        else
                        {
                            string Deduction = "";
                            Decimal DedAmount = 0;
                            Decimal TotalDedAmount = 0;
                            Int32 ProceeId = Convert.ToInt32(dt.Rows[intRowBodyCount]["SLPRCDMNTH_ID"].ToString());
                            objEntityPayroll.ProcessId = ProceeId;
                            DataTable dtDeduction = objBusinssPayroll.ReadDeductionDetails(objEntityPayroll);
                            if (dtDeduction.Rows.Count > 0)
                            {


                                strHtml += "<td  class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><table style=\" width:100%;\" >";
                                for (int i = 0; i < dtDeduction.Rows.Count; i++)
                                {
                                    Deduction = dtDeduction.Rows[i]["PAYRL_NAME"].ToString();
                                    if (dtDeduction.Rows[i]["SLRYPROSDEDTN_AMOUNT"].ToString() != "0")
                                        DedAmount = Convert.ToDecimal(dtDeduction.Rows[i]["SLRYPROSDEDTN_AMOUNT"].ToString());
                                    else if (dtDeduction.Rows[i]["SLRYPROSDEDTN_PERCNTGE"].ToString() != "0")
                                    {
                                        Decimal basicPay = 0;
                                        Decimal DedAmountPec = 0;
                                        if (dtDeduction.Rows[i]["SLRYPROSDEDTN_BSIC_TOTL_AMNT"].ToString() == "0")
                                        {
                                            //   (0) – basic pay (1) – total amount
                                           
                                            basicPay = Convert.ToDecimal(dt.Rows[intRowBodyCount]["SLRY_BASIC_PAY"].ToString());
                                            DedAmountPec = Convert.ToDecimal(dtDeduction.Rows[i]["SLRYPROSDEDTN_PERCNTGE"].ToString());
                                            DedAmount =basicPay * DedAmountPec / 100;
                                        }
                                        else
                                        {
                                             Decimal NetAmt = 0;
                                             NetAmt  = Convert.ToDecimal(dt.Rows[intRowBodyCount]["ALLOWANCE"].ToString());
                                             basicPay = Convert.ToDecimal(dt.Rows[intRowBodyCount]["SLRY_BASIC_PAY"].ToString());
                                             NetAmt = NetAmt + basicPay;
                                             DedAmountPec = Convert.ToDecimal(dtDeduction.Rows[i]["SLRYPROSDEDTN_PERCNTGE"].ToString());
                                             DedAmount = NetAmt * DedAmountPec / 100;


                                        }
                                       
                                    }
                                    TotalDedAmount = TotalDedAmount + DedAmount;
                                    strHtml += "<tr class=\"noBorder\"  style=\" background: transparent;\"><td style=\" width:60%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + Deduction + "</td><td style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"> " + DedAmount + "</td><td style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"> " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td></tr>";
                                }
                                   if (dt.Rows[intRowBodyCount]["SLPRCDMNTH_CONFRMSTS"].ToString() != "1")
                                   {
                                     TotalDeduction = TotalDeduction + TotalDedAmount;
                                   }
                                   if (dclInstallDedu != 0)
                                   {
                                       dclInstallDedu = Convert.ToDecimal(dt.Rows[intRowBodyCount]["INSTALMENT_DEDUCTION"].ToString());
                                       strHtml += "<tr  class=\"noBorder\" style=\" background: transparent;\"> <td  style=\" width:60%;word-break: break-all; word-wrap:break-word;text-align: left;\">INSTALMENT DEDUCTION </td><td  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"> " + dclInstallDedu + " </td><td  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"> " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td></tr>";
                                       //strHtml += "<tr style=\" background: transparent;\"> OVERTIME ALLOWANCE  " + dclOverAllow + "</td><td> " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</tr>";
                                   }

                                   strHtml += "<tr class=\"noBorder\" style=\" background: transparent;\"><td  style=\" width:60%;word-break: break-all; word-wrap:break-word;text-align: left;\">Total</td><td  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + TotalDeduction + "</td><td  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"> " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td><tr></table></td>"; 
                                //strHtml += "<br><tr ><p > Total :" + TotalDeduction + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</p><tr></table></td>";
                             //  strHtml += "</table></td>";
                            }
                           else
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><table style=\" width:100%;\" >";
                                if (dclDedu != 0)
                                {
                                    dclDedu = Convert.ToDecimal(dt.Rows[intRowBodyCount]["DEDUCTION"].ToString());
                                    strHtml += "<tr class=\"noBorder\" style=\" background: transparent;\"> <td  style=\" width:60%;word-break: break-all; word-wrap:break-word;text-align: left;\">SPECIAL ALLOWANCE </td><td  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"> " + dclDedu + " </td><td  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"> " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td></tr>";
                                }
                                if (dclInstallDedu != 0)
                                {
                                    dclInstallDedu = Convert.ToDecimal(dt.Rows[intRowBodyCount]["INSTALMENT_DEDUCTION"].ToString());
                                    strHtml += "<tr class=\"noBorder\" style=\" background: transparent;\"> <td  style=\" width:60%;word-break: break-all; word-wrap:break-word;text-align: left;\">INSTALMENT DEDUCTION </td><td  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"> " + dclInstallDedu + " </td><td  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"> " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td></tr>";
                                    //strHtml += "<tr style=\" background: transparent;\"> OVERTIME ALLOWANCE  " + dclOverAllow + "</td><td> " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</tr>";
                                }
                                strHtml += "<tr class=\"noBorder\" style=\" background: transparent;\"><td  style=\" width:60%;word-break: break-all; word-wrap:break-word;text-align: left;\"><p>Total</td><td  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + TotalDeduction + "</td><td  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"> " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td></p><tr></table></td>"; 
                             //   strHtml += "<tr style=\"background: transparent;\"><td><p >Total</td><td>" + TotalDeduction + "</td><td> " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td></p><tr></table></td>";
                            //    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; color:red; word-wrap:break-word;text-align: left;\" >Total:" + TotalDeduction + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                               // strHtml += "</table></td>";
                            }
                        }
                    }
                    //END
                    if (intColumnBodyCount == 7)
                    {
                        string strAmt="";
                        if (dt.Rows[intRowBodyCount]["NET_AMOUNT"].ToString() == "")
                        {
                            strAmt = "0.00";
                        }
                        else
                        {
                            strAmt = dt.Rows[intRowBodyCount]["NET_AMOUNT"].ToString();
                        }
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strAmt + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 8)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["BANK_NAME"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 9)
                    {
                        string strStstus="";
                        if (dt.Rows[intRowBodyCount]["SLPRCDMNTH_STATUS"].ToString() == "0")
                        {
                            if (dt.Rows[intRowBodyCount]["SLPRCDMNTH_CONFRMSTS"].ToString() == "1")
                            {
                                strStstus = "CONFIRM";
                            }
                            else
                            {
                                strStstus = "PROCESS";
                            }
                        }
                        else if (dt.Rows[intRowBodyCount]["SLPRCDMNTH_STATUS"].ToString() == "3")
                        {
                            strStstus = "WPS </BR>GENERATED";
                        }
                        else if (dt.Rows[intRowBodyCount]["SLPRCDMNTH_STATUS"].ToString() == "1")
                        {
                            strStstus = "PAID";
                        }

                        strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + strStstus + "</td>";
                    }
                }
            }

            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();

        //End

    }
    public string ConvertDataTableForPrint(DataTable dt, DataTable dtCorp)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Payroll Process Report";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string usrName = "";
        if (Session["USERFULLNAME"] != null)
        {
            usrName = "<B> Report Generated By: </B>" + Session["USERFULLNAME"];
        }
        if (dtCorp.Rows.Count > 0)
        {
            strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
            strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
            strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
            strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
            strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
        }
        string strCompanyAddr = objCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);

        StringBuilder sbCap = new StringBuilder();
        string strUsrName = "";
        string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr + "</td></tr>";
        string strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        if (usrName != "")
        {
            strUsrName = "<tr><td class=\"RprtDiv\">" + usrName + "</td></tr>";
        }
        string strCaptionTabTitle = "<tr><td class=\"CapTitle\" >" + strTitle + "</td></tr>";


        string strdiv = "";
        if (ddlDivision.SelectedItem.Text.ToString() == "--SELECT DIVISION--")
        {
            strdiv = "";
        }
        else
        {
            strdiv = "<tr>Division : " + ddlDivision.SelectedItem.Text.ToString() + "<br/></tr>";
        }

        string strdept = "";
        if (ddlDepartmnt.SelectedItem.Text.ToString() == "--SELECT DEPARTMENT--")
        {
            strdept = "";
        }
        else
        {
            strdept = "<tr>Department : " + ddlDepartmnt.SelectedItem.Text.ToString() + "<br/></tr>";
        }
        string strAcc = "";

        if (ddlBank.SelectedItem.Text.ToString() == "--SELECT BANK--")
        {
            strAcc = "";
        }
        else
        {
            strAcc = "<tr>Bank : " + ddlBank.SelectedItem.Text.ToString() + "<br/></tr>";
        }
        string strMonth = "";
        if (ddlMonth.SelectedItem.Text.ToString() == "--SELECT MONTH--")
        {
            strMonth = "";
        }
        else
        {
            strMonth = "<tr>Month : " + ddlMonth.SelectedItem.Text.ToString() + "<br/></tr>";
        }
        string strYear = "";
        if (ddlYear.SelectedItem.Text.ToString() == "--SELECT YEAR--")
        {
            strYear = "";
        }
        else
        {
            strYear = "<tr>Year : " + ddlYear.SelectedItem.Text.ToString() + "<br/></tr>";
        }
        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strUsrName + strCaptionTabTitle + strCaptionTabstop + strdiv + strdept + strAcc + strMonth + strYear;

        sbCap.Append(strPrintCaptionTable);
        //write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString();
        StringBuilder sb = new StringBuilder();



        string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">DESIGNATION</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: right; word-wrap:break-word;\">BASIC PAY</th>";
            }
            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: right; word-wrap:break-word;\">ADDITION</th>";
            }
            if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: right; word-wrap:break-word;\">DEDUCTION</th>";
            }
        
            if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: right; word-wrap:break-word;\">TOTAL SALARY</th>";
            }
            if (intColumnHeaderCount == 8)
            {
                strHtml += "<th class=\"thT\" style=\"width:12%;text-align: left; word-wrap:break-word;\">BANK</th>";
            }
            if (intColumnHeaderCount == 9)
            {
                strHtml += "<th class=\"thT\" style=\"width:12%;text-align: center; word-wrap:break-word;\">STATUS</th>";
            }
        }
        strHtml += "</tr>";
        strHtml += "</thead>";
        strHtml += "<tbody>";
        if (dt.Rows.Count == 0)
        {
            strHtml += "<tr  ><td  class=\"thT\" colspan=\"9\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td></tr>";
        }
        else
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                strHtml += "<tr  >";
                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (intColumnBodyCount == 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 2)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USRNAME"].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 3)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DSGN_NAME"].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 4)
                        {
                            string strBPAmt = "";
                            if (dt.Rows[intRowBodyCount]["SLRY_BASIC_PAY"].ToString() == "")
                            {
                                strBPAmt = "0.00";
                            }
                            else
                            {
                                strBPAmt = dt.Rows[intRowBodyCount]["SLRY_BASIC_PAY"].ToString();
                            }
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strBPAmt + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 5)
                        {
                            Decimal dclAllow = 0;
                            Decimal dclOverAllow = 0;
                            Decimal TotalAllow = 0;
                            if (dt.Rows[intRowBodyCount]["ALLOWANCE"].ToString() != "")
                            {
                                dclAllow = Convert.ToDecimal(dt.Rows[intRowBodyCount]["ALLOWANCE"].ToString());
                            }
                            if (dt.Rows[intRowBodyCount]["OVERALLOWANCE"].ToString() != "")
                            {
                                dclOverAllow = Convert.ToDecimal(dt.Rows[intRowBodyCount]["OVERALLOWANCE"].ToString());
                            }
                            TotalAllow = dclAllow + dclOverAllow;
                            if (TotalAllow == 0)
                            {
                                TotalAllow = Convert.ToDecimal("0.00");
                            }

                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + TotalAllow + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 6)
                        {
                            Decimal dclDedu = 0;
                            Decimal dclInstallDedu = 0;
                            Decimal TotalDeduction = 0;
                            if (dt.Rows[intRowBodyCount]["DEDUCTION"].ToString() != "")
                            {
                                dclDedu = Convert.ToDecimal(dt.Rows[intRowBodyCount]["DEDUCTION"].ToString());
                            }
                            if (dt.Rows[intRowBodyCount]["OVERALLOWANCE"].ToString() != "")
                            {
                                dclInstallDedu = Convert.ToDecimal(dt.Rows[intRowBodyCount]["INSTALMENT_DEDUCTION"].ToString());
                            }
                            TotalDeduction = dclDedu + dclInstallDedu;
                            if (TotalDeduction == 0)
                            {
                                TotalDeduction = Convert.ToDecimal("0.00");
                            }
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + TotalDeduction + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                        }
                   
                        if (intColumnBodyCount == 7)
                        {
                            string strAmt = "";
                            if (dt.Rows[intRowBodyCount]["NET_AMOUNT"].ToString() == "")
                            {
                                strAmt = "0.00";
                            }
                            else
                            {
                                strAmt = dt.Rows[intRowBodyCount]["NET_AMOUNT"].ToString();
                            }
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strAmt + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 8)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["BANK_NAME"].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 9)
                        {
                            string strStstus = "";
                            if (dt.Rows[intRowBodyCount]["SLPRCDMNTH_STATUS"].ToString() == "0")
                            {
                                if (dt.Rows[intRowBodyCount]["SLPRCDMNTH_CONFRMSTS"].ToString() == "1")
                                {
                                    strStstus = "CONFIRM";
                                }
                                else
                                {
                                    strStstus = "PROCESS";
                                }
                            }
                            else if (dt.Rows[intRowBodyCount]["SLPRCDMNTH_STATUS"].ToString() == "3")
                            {
                                strStstus = "WPS GENERATED";
                            }
                            else if (dt.Rows[intRowBodyCount]["SLPRCDMNTH_STATUS"].ToString() == "1")
                            {
                                strStstus = "PAID";
                            }

                            strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + strStstus + "</td>";
                        }
                    }
                }

                strHtml += "</tr>";
            }
        }
        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();

        //End

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPayroll.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityPayroll.OrganizatonId = Convert.ToInt32(Session["ORGID"].ToString());
            hiddenOrgId.Value = Session["ORGID"].ToString();
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (ddlDepartmnt.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntityPayroll.DepartmentId = Convert.ToInt32(ddlDepartmnt.SelectedItem.Value);
        }
        if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
        {
            objEntityPayroll.DivisionId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        }
        if (ddlBank.SelectedItem.Value != "--SELECT BANK--")
        {
            objEntityPayroll.Bank = Convert.ToInt32(ddlBank.SelectedItem.Value);
        }
        if (ddlMonth.SelectedItem.Value != "--SELECT MONTH--")
        {
            objEntityPayroll.Month = Convert.ToInt32(ddlMonth.SelectedItem.Value);
        }
        if (ddlYear.SelectedItem.Value != "--SELECT YEAR--")
        {
            objEntityPayroll.Year = Convert.ToInt32(ddlYear.SelectedItem.Value);
        }
        DataTable dtPayrollList = new DataTable();
        dtPayrollList = objBusinssPayroll.LoadPayrollReport(objEntityPayroll);

        string strHtm = ConvertDataTableToHTML(dtPayrollList);
        divReport.InnerHtml = strHtm;
        DataTable dtCorp = objBusinssPayroll.ReadCorporateAddress(objEntityPayroll);

        string strPrintReport = ConvertDataTableForPrint(dtPayrollList, dtCorp);
        divPrintReport.InnerHtml = strPrintReport;
    }
    protected void BtnCSV_Click(object sender, EventArgs e)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dt = GetTable();
        string strResult = DataTableToCSV(dt, ',');
        string strImagePath = "";
        string filepath = "";
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        if (Session["ORGID"] != null)
        {
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        try
        {
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PAYROLL_PRSS_REPORT_CSV);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
            string newFilePath = Server.MapPath("/CustomFiles/HCM CSV/Payroll Process/Payroll_Process_Report_" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "Payroll_Process_Report_" + strNextId + ".csv";
            Response.ContentType = "csv";
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.PAYROLL_PRSS_REPORT_CSV);
            Response.AddHeader("content-Disposition", "attachment;filename=\"" + filepath + "\"");
            Response.TransmitFile(Server.MapPath(strImagePath) + filepath);
            Response.End();
            if (File.Exists(MapPath(strImagePath) + filepath))
            {
                File.Delete(MapPath(strImagePath) + filepath);
            }
        }
        catch (Exception)
        { }
    }
    public string DataTableToCSV(DataTable dtSIFHeader, char seperator)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < dtSIFHeader.Columns.Count; i++)
        {
            sb.Append(dtSIFHeader.Columns[i]);
            if (i < dtSIFHeader.Columns.Count - 1)
                sb.Append(seperator);
        }
        sb.AppendLine();
        foreach (DataRow dr in dtSIFHeader.Rows)
        {
            for (int i = 0; i < dtSIFHeader.Columns.Count; i++)
            {
                sb.Append(dr[i].ToString());

                if (i < dtSIFHeader.Columns.Count - 1)
                    sb.Append(seperator);
            }
            sb.AppendLine();
        }
        return sb.ToString();

    }

    public DataTable GetTable()
    {
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPayroll.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityPayroll.OrganizatonId = Convert.ToInt32(Session["ORGID"].ToString());
            hiddenOrgId.Value = Session["ORGID"].ToString();
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (ddlDepartmnt.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntityPayroll.DepartmentId = Convert.ToInt32(ddlDepartmnt.SelectedItem.Value);
        }
        if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
        {
            objEntityPayroll.DivisionId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        }
        if (ddlBank.SelectedItem.Value != "--SELECT BANK--")
        {
            objEntityPayroll.Bank = Convert.ToInt32(ddlBank.SelectedItem.Value);
        }
        if (ddlMonth.SelectedItem.Value != "--SELECT MONTH--")
        {
            objEntityPayroll.Month = Convert.ToInt32(ddlMonth.SelectedItem.Value);
        }
        if (ddlYear.SelectedItem.Value != "--SELECT YEAR--")
        {
            objEntityPayroll.Year = Convert.ToInt32(ddlYear.SelectedItem.Value);
        }
        DataTable dt = new DataTable();
        dt = objBusinssPayroll.LoadPayrollReport(objEntityPayroll);
        DataTable dtCorp = objBusinssPayroll.ReadCorporateAddress(objEntityPayroll);
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable table = new DataTable();
        table.Columns.Add("EMPLOYEE ID", typeof(string));
        table.Columns.Add("EMPLOYEE", typeof(string));
        table.Columns.Add("DESIGNATION", typeof(string));
        table.Columns.Add("BASIC PAY", typeof(string));
        table.Columns.Add("ADDITION", typeof(string));
        table.Columns.Add("DEDUCTION", typeof(string));
        table.Columns.Add("TOTAL SALARY", typeof(string));
        table.Columns.Add("BANK", typeof(string));
        table.Columns.Add("STATUS", typeof(string));

        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string EMPID = "";
            string EMP = "";
            string BASICPAY = "";
            string ADDITION = "";
            string DEDUCTION = "";
            string SALARY = "";
            string BANK = "";
            string STATUS = "";
            string DSGN = "";
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                if (dt.Rows.Count > 0)
                {
                    if (intColumnBodyCount == 1)
                    {
                        EMPID = dt.Rows[intRowBodyCount]["USR_CODE"].ToString() ;
                    }
                    if (intColumnBodyCount == 2)
                    {
                        EMP=  dt.Rows[intRowBodyCount]["USRNAME"].ToString() ;
                    }
                    if (intColumnBodyCount == 3)
                    {
                        DSGN= dt.Rows[intRowBodyCount]["DSGN_NAME"].ToString();
                    }
                    if (intColumnBodyCount == 4)
                    {
                        string strBPAmt = "";
                        if (dt.Rows[intRowBodyCount]["SLRY_BASIC_PAY"].ToString() == "")
                        {
                            strBPAmt = "0.00";
                        }
                        else
                        {
                            strBPAmt = dt.Rows[intRowBodyCount]["SLRY_BASIC_PAY"].ToString();
                        }
                        BASICPAY= strBPAmt + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() ;
                    }
                    if (intColumnBodyCount == 5)
                    {
                        Decimal dclAllow = 0;
                        Decimal dclOverAllow = 0;
                        Decimal TotalAllow = 0;
                        if (dt.Rows[intRowBodyCount]["ALLOWANCE"].ToString() != "")
                        {
                            dclAllow = Convert.ToDecimal(dt.Rows[intRowBodyCount]["ALLOWANCE"].ToString());
                        }
                        if (dt.Rows[intRowBodyCount]["OVERALLOWANCE"].ToString() != "")
                        {
                            dclOverAllow = Convert.ToDecimal(dt.Rows[intRowBodyCount]["OVERALLOWANCE"].ToString());
                        }
                        TotalAllow = dclAllow + dclOverAllow;
                        if (TotalAllow == 0)
                        {
                            TotalAllow = Convert.ToDecimal("0.00");
                        }

                        ADDITION=TotalAllow + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() ;
                    }
                    if (intColumnBodyCount == 6)
                    {
                        Decimal dclDedu = 0;
                        Decimal dclInstallDedu = 0;
                        Decimal TotalDeduction = 0;
                        if (dt.Rows[intRowBodyCount]["DEDUCTION"].ToString() != "")
                        {
                            dclDedu = Convert.ToDecimal(dt.Rows[intRowBodyCount]["DEDUCTION"].ToString());
                        }
                        if (dt.Rows[intRowBodyCount]["OVERALLOWANCE"].ToString() != "")
                        {
                            dclInstallDedu = Convert.ToDecimal(dt.Rows[intRowBodyCount]["INSTALMENT_DEDUCTION"].ToString());
                        }
                        TotalDeduction = dclDedu + dclInstallDedu;
                        if (TotalDeduction == 0)
                        {
                            TotalDeduction = Convert.ToDecimal("0.00");
                        }
                        DEDUCTION= TotalDeduction + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() ;
                    }

                    if (intColumnBodyCount == 7)
                    {
                        string strAmt = "";
                        if (dt.Rows[intRowBodyCount]["NET_AMOUNT"].ToString() == "")
                        {
                            strAmt = "0.00";
                        }
                        else
                        {
                            strAmt = dt.Rows[intRowBodyCount]["NET_AMOUNT"].ToString();
                        }
                        SALARY = strAmt + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString();
                    }
                    if (intColumnBodyCount == 8)
                    {
                        BANK=dt.Rows[intRowBodyCount]["BANK_NAME"].ToString() ;
                    }
                    if (intColumnBodyCount == 9)
                    {
                        string strStstus = "";
                        if (dt.Rows[intRowBodyCount]["SLPRCDMNTH_STATUS"].ToString() == "0")
                        {
                            if (dt.Rows[intRowBodyCount]["SLPRCDMNTH_CONFRMSTS"].ToString() == "1")
                            {
                                strStstus = "CONFIRM";
                            }
                            else
                            {
                                strStstus = "PROCESS";
                            }
                        }
                        else if (dt.Rows[intRowBodyCount]["SLPRCDMNTH_STATUS"].ToString() == "3")
                        {
                            strStstus = "WPS GENERATED";
                        }
                        else if (dt.Rows[intRowBodyCount]["SLPRCDMNTH_STATUS"].ToString() == "1")
                        {
                            strStstus = "PAID";
                        }

                        STATUS=  strStstus;
                    }
                }
            }
            table.Rows.Add('"' + EMPID + '"', '"' + EMP + '"', '"' + DSGN + '"', '"' + BASICPAY + '"', '"' + ADDITION + '"', '"' + DEDUCTION + '"', '"' + SALARY + '"', '"' + BANK + '"', '"' + STATUS + '"');
        }
        return table;
    }
}