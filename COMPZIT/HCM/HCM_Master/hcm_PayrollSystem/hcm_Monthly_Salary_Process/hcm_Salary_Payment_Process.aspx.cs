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
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Ionic.Zip;

using System.IO;


// CREATED BY:EVM-0008
// CREATED DATE:10/30/2017
// REVIEWED BY:
// REVIEW DATE:

public partial class HCM_HCM_Master_hcm_PayrollSystem_hcm_Monthly_Salary_Process_hcm_Salary_Payment_Process : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        // Session["SALARPRSS_PAID"] = null;
        if (!IsPostBack)
        {
            HiddenEmployeeId.Value = "";
            HiddenFinishOrPend.Value = "0";
            //  Session["SALARPRSS_PAID"] = null;
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
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
            cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
            clsEntityCommon objEntCommon = new clsEntityCommon();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {
                                                             clsCommonLibrary.CORP_GLOBAL.PAYROLL_INDIVIDUAL_ROUND
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenFieldIndividualRound.Value = dtCorpDetail.Rows[0]["PAYROLL_INDIVIDUAL_ROUND"].ToString();
            }
            if (Session["SALARPRSS_PAYMENT"] != null)
            {
                int Processed = 0;

                //  BtnPross.Visible = false;
                cls_Entity_Monthly_Salary_Process objEntPrcss = new cls_Entity_Monthly_Salary_Process();
                var strSALARPRSS = Session["SALARPRSS_PAYMENT"];
                string[] ProssId = strSALARPRSS.ToString().Split('~');
                int SaveOrConf = Convert.ToInt32(ProssId[0]);

                int CorpdepId = Convert.ToInt32(ProssId[1]);
                int staffWrk = Convert.ToInt32(ProssId[2]);
                DateTime ddate = objCommon.textToDateTime(ProssId[3]);

                objEntPrcss.Month = Convert.ToInt32(ProssId[4]);
                objEntPrcss.Year = Convert.ToInt32(ProssId[5]);

                objEntPrcss.PaidFinish = SaveOrConf;

                objEntPrcss.Dep = CorpdepId;
                objEntPrcss.StffWrkr = staffWrk;

                objEntPrcss.date = ddate;
                objEntPrcss.CorpOffice = intCorpId;
                DataTable dt = objBuss.LoadSalaryPrssPaymentTable(objEntPrcss);
                if (dt.Rows.Count > 0)
                {
                    lblLoctn.Text = dt.Rows[0]["CORPRT_NAME"].ToString();
                }
                if (staffWrk == 0)
                {
                    lblResume.Text = "STAFF";
                }
                else
                {
                    lblResume.Text = "WORKER";
                }
                string mnth = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(objEntPrcss.Month);
                lblRefEmp.Text = mnth.ToUpper() + " " + objEntPrcss.Year;
                lblCandtName.Text = ddate.ToString("dd-MM-yyyy");
                objEntPrcss.CorpOffice = intCorpId;
                string ListLoad = "";
                // if (dt.Rows.Count>0)
                ListLoad = ConvertDataTableToHTML(dt, staffWrk);
                divlistview.InnerHtml = ListLoad;
            }


        }
    }
    public string ConvertDataTableToHTML(DataTable dt, int StaffWrkr)
    {
        string indvlRound = HiddenFieldIndividualRound.Value;
        cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
        cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        hiddenAllEmpid.Value = "";
        int intOrgId = 0;
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());


        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        HiddenFieldRowCount.Value = dt.Rows.Count.ToString();
        if (HiddenFieldRowCount.Value != "0")
        {
            HiddenFinishOrPend.Value = dt.Rows[0]["SLPRCDMNTH_STATUS"].ToString();
        }
        else
        {
            HiddenFinishOrPend.Value = "1";
        }

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"table table-striped table-bordered\" width=\"100%\" style=\"border-spacing: 1px;background-color: #e7e6e6;\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr >";

        strHtml += "<tr >";

        int intCnclUsrId = 0;
        int intReCallForTAble = 0;

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:10%\"> EMPLOYEE ID";
                strHtml += "</th >";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:15%\">EMPLOYEE";
                strHtml += "</th >";
            }

            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:10%;\"> DESIGNATION";
                strHtml += "</th >";
            }

            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:15%;text-align: right;\">SALARY AMOUNT";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:15%;text-align: right;\">ARREAR AMOUNT";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:15%;text-align: right;\">FINAL AMOUNT";
                strHtml += "</th >";
            }

        }
        strHtml += "<th class=\"hasinput\" style=\"width:15%;text-align: right;\">PAID AMOUNT";
        if (HiddenFieldRowCount.Value != "0")
        {
            if (dt.Rows[0]["SLPRCDMNTH_STATUS"].ToString() == "3")
            {
                strHtml += " <th class=\"hasinput\" style=\"width:15%;\"><button  onclick=\"return ToPaidAll();\" style=\"width: 100%;background-color: #88bdf2;border: 1px solid darkblue;\" class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\">paid</button>";
            }
        }
        if (HiddenFieldRowCount.Value != "0")
        {
            if (dt.Rows[0]["SLPRCDMNTH_STATUS"].ToString() == "1")
            {
                strHtml += "<th class=\"hasinput\" style=\"width:20%;\"><button ID=\"btnDownloadAll\" style=\"width: 100% ;background-color: #dedada;\" class=\"btn btn-xs btn-default\"  onclick=\"return DownloadAll();\" />Download All Payslip";
            }
        }
        strHtml += "<th class=\"hasinput\" style=\"width:15%;display:none\">PAID";
        strHtml += "<th class=\"hasinput\" style=\"width:15%;display:none\">PAID";
        strHtml += "<th class=\"hasinput\" style=\"width:15%;display:none\">PAID";
        strHtml += "<th class=\"hasinput\" style=\"width:15%;display:none\">PAID";
        strHtml += "<th class=\"hasinput\" style=\"width:15%;display:none\">PAID";
        strHtml += "</th >";

        strHtml += "</th >";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        Decimal Arrearamount = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            //EvM-0027 Sep-24
            hiddenAllEmpid.Value = dt.Rows[intRowBodyCount]["USR_ID"].ToString() + "," + hiddenAllEmpid.Value;

                //END

            //arrear amount
            string UserId = dt.Rows[intRowBodyCount]["USR_ID"].ToString();
            DateTime DateDate = Convert.ToDateTime(dt.Rows[intRowBodyCount]["SLPRCDMNTH_FROM_DATE"].ToString());
            DateTime PrevMonth;
            int IntMonthInt = Convert.ToInt32(dt.Rows[intRowBodyCount]["SLPRCDMNTH_NUMBR"].ToString());
            int IntYearInt = Convert.ToInt32(dt.Rows[intRowBodyCount]["SLPRCDMNTH_YEAR"].ToString());
            string MonthYear = IntMonthInt + "~" + IntYearInt;
            int intmonth, intYear;
            if (IntMonthInt == 1)
            {
                intmonth = 12;
                intYear = IntYearInt - 1;
            }
            else
            {
                intYear = IntYearInt;
                intmonth = IntMonthInt - 1;
            }
            PrevMonth = DateDate.AddMonths(-1);
            // int intmonth = Convert.ToInt32(PrevMonth.Month.ToString());
            // int intYear = Convert.ToInt32(PrevMonth.Year.ToString());
            objEnt.Month = intmonth;
            objEnt.Year = intYear;
            objEnt.Employee = Convert.ToInt32(UserId);
            DataTable ArrearAmountdt = objBuss.GetArrearAmount(objEnt);
            if (ArrearAmountdt.Rows.Count > 0)
            {
                if (ArrearAmountdt.Rows[0]["SLPRCDMNTH_ARREAR_AMNT"].ToString() != "")
                {
                    Arrearamount = Convert.ToDecimal(ArrearAmountdt.Rows[0]["SLPRCDMNTH_ARREAR_AMNT"].ToString());
                }

            }

            //totalamount
            decimal Totalamnt = 0, ArrearAmt = 0;
            if (dt.Rows[intRowBodyCount]["SLPRCDMNTH_TOTAL_AMT"].ToString() != "")
                Totalamnt = Convert.ToDecimal(dt.Rows[intRowBodyCount]["SLPRCDMNTH_TOTAL_AMT"].ToString());
            Totalamnt = Totalamnt + ArrearAmt;

            string PrssMnthId = dt.Rows[intRowBodyCount]["SLPRCDMNTH_ID"].ToString();

            string empsalid = UserId + "," + PrssMnthId;
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EID"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    //emp-0043 start
                    if (dt.Rows[intRowBodyCount]["SLRPRCDMNTH_PAYMENT_TYPE"].ToString() == "1")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + "<img title=\"Cash\" src='/Images/Icons/csh.png'></img></td>";

                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + "</td>";
                    }
                    //end
                }

                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DESIGNATION"].ToString() + "</td>";
                }

                else if (intColumnBodyCount == 4)
                {
                    string NetAmountWithCommaFrm = "";
                    if (indvlRound == "0")
                    {
                        NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(dt.Rows[intRowBodyCount]["SLPRCDMNTH_TOTAL_AMT"].ToString(), objEntityCommon);
                    }
                    else
                    {
                        NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[intRowBodyCount]["SLPRCDMNTH_TOTAL_AMT"].ToString()), 0).ToString("0.00"), objEntityCommon);
                    }
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + NetAmountWithCommaFrm + "</td>";
                }
                else if (intColumnBodyCount == 5)
                {

                    // Arrearamount = Arrearamount + Convert.ToDecimal(dt.Rows[intRowBodyCount]["SLPRCDMNTH_ARREAR_AMNT"].ToString());
                    if (HiddenFieldRowCount.Value != "0")
                    {
                        if (dt.Rows[0]["SLPRCDMNTH_STATUS"].ToString() == "3")
                        {
                            string NetAmountWithCommaFrm = "";
                            if (indvlRound == "0")
                            {
                                NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(Arrearamount.ToString("0.00"), objEntityCommon);
                            }
                            else
                            {
                                NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(Arrearamount.ToString("0.00")), 0).ToString("0.00"), objEntityCommon);
                            }
                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + NetAmountWithCommaFrm + "</td>";
                        }
                        else
                        {
                            string NetAmountWithCommaFrm = "";
                            if (indvlRound == "0")
                            {
                                NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(dt.Rows[intRowBodyCount]["SLPRCDMNTH_ARREAR_AMNT"].ToString(), objEntityCommon);
                            }
                            else
                            {
                                NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[intRowBodyCount]["SLPRCDMNTH_ARREAR_AMNT"].ToString()), 0).ToString("0.00"), objEntityCommon);
                            }
                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + NetAmountWithCommaFrm + "</td>";
                        }
                    }
                    else
                    {
                        string NetAmountWithCommaFrm = "";
                        if (indvlRound == "0")
                        {
                            NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(dt.Rows[intRowBodyCount]["SLPRCDMNTH_ARREAR_AMNT"].ToString(), objEntityCommon);
                        }
                        else
                        {
                            NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[intRowBodyCount]["SLPRCDMNTH_ARREAR_AMNT"].ToString()), 0).ToString("0.00"), objEntityCommon);
                        }
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + NetAmountWithCommaFrm + "</td>";
                    }
                }
                else if (intColumnBodyCount == 6)
                {
                    if (dt.Rows[0]["SLPRCDMNTH_STATUS"].ToString() == "3")
                    {
                        Totalamnt = Totalamnt;
                        //+Arrearamount;
                    }

                    string NetAmountWithCommaFrm = "";
                    //if (indvlRound == "0")
                    //{
                    //    NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(Totalamnt.ToString(), objEntityCommon);
                    //}
                    //else
                    //{
                        NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(Totalamnt.ToString()), 0).ToString("0.00"), objEntityCommon);
                    //}
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + NetAmountWithCommaFrm + "</td>";
                }
                else if (intColumnBodyCount == 7)
                {

                    if (HiddenFieldRowCount.Value != "0")
                    {
                        if (dt.Rows[0]["SLPRCDMNTH_STATUS"].ToString() == "3")
                        {
                            string NetAmountWithCommaFrm = "";
                            //if (indvlRound == "0")
                            //{
                            //    NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(Totalamnt.ToString(), objEntityCommon);
                            //}
                            //else
                            //{
                                NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(Totalamnt.ToString()), 0).ToString("0.00"), objEntityCommon);
                            //}
                            strHtml += "<td class=\"tdT\" style=\"width:15%;text-align: center;\"> <label class=\"input\"style=\"margin-bottom: 13%;\" ><input type=\"text\"   onkeydown=\"return isNumberSalary(event,'cbMandatory" + intRowBodyCount + "');\"  onblur=\"AmountChecking('cbMandatory" + intRowBodyCount + "','cbMandatory" + intRowBodyCount + "','cbMandatory" + intRowBodyCount + "');\"   value=\"" + NetAmountWithCommaFrm + "\" name=\"cbMandatory" + intRowBodyCount + "\"  id=\"cbMandatory" + intRowBodyCount + "\"  maxlength=\"18\"   onkeypress='return DisableEnter(event)'  ></label>";
                        }
                        else
                        {


                            string NetAmountWithCommaFrm = "";
                            //if (indvlRound == "0")
                            //{
                            //    NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(dt.Rows[intRowBodyCount]["SLPRCDMNTH_PAID_AMT"].ToString(), objEntityCommon);
                            //}
                            //else
                            //{
                                NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[intRowBodyCount]["SLPRCDMNTH_PAID_AMT"].ToString()), 0).ToString("0.00"), objEntityCommon);
                            //}
                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + NetAmountWithCommaFrm + "</td>";
                        }
                    }
                    else
                    {
                        string NetAmountWithCommaFrm = "";
                        //if (indvlRound == "0")
                        //{
                        //    NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(dt.Rows[intRowBodyCount]["SLPRCDMNTH_PAID_AMT"].ToString(), objEntityCommon);
                        //}
                        //else
                        //{
                            NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(dt.Rows[intRowBodyCount]["SLPRCDMNTH_PAID_AMT"].ToString()), 0).ToString("0.00"), objEntityCommon);
                        //}
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + NetAmountWithCommaFrm + "</td>";
                    }
                }
                else if (intColumnBodyCount == 8)
                {
                    if (HiddenFieldRowCount.Value != "0")
                    {
                        if (dt.Rows[intRowBodyCount]["SLPRCDMNTH_STATUS"].ToString() == "3" || dt.Rows[intRowBodyCount]["SLPRCDMNTH_STATUS"].ToString() == "")
                        {

                            strHtml += " <td style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button  style=\"width: 100%;background-color: #dedada;\" class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\"   onclick=\"return ToPaid(" + intRowBodyCount + "," + UserId + "," + PrssMnthId + "," + IntMonthInt.ToString() + "," + IntYearInt.ToString() + ");\">paid</button></td>";
                        }
                    }
                }
            }
            if (HiddenFieldRowCount.Value != "0")
            {
                if (dt.Rows[intRowBodyCount]["SLPRCDMNTH_STATUS"].ToString() == "1" || dt.Rows[intRowBodyCount]["SLPRCDMNTH_STATUS"].ToString() == "1")
                {
                    if (StaffWrkr == 1)
                    {
                        strHtml += " <td style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button  style=\"width: 100%;background-color: #dedada;1px solid #212323\" class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\"   onclick=\"return Clickme(" + dt.Rows[intRowBodyCount]["USR_ID"].ToString() + "," + intRowBodyCount + "," + dt.Rows[intRowBodyCount]["SLPRCDMNTH_ID"].ToString() + ")\">Pay Slip</button></td>";
                    }
                    else
                    {
                        strHtml += " <td style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button  style=\"width: 100%;background-color: #dedada;1px solid #212323\" class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\"   onclick=\"return PaySlip(" + dt.Rows[intRowBodyCount]["USR_ID"].ToString() + "," + intRowBodyCount + "," + dt.Rows[intRowBodyCount]["SLPRCDMNTH_ID"].ToString() + ")\">Pay Slip</button></td>";
                    }
                }
            }
            strHtml += "<td class=\"tdT\" style=\"text-align: center;display:none\"> <label class=\"input\"style=\"margin-bottom: 13%;\" ><input type=\"text\"        value=\"" + Arrearamount + "\" name=\"ArrearAmount" + intRowBodyCount + "\" id=\"ArrearAmount" + intRowBodyCount + "\"  maxlength=\"18\"   ></label>";
            strHtml += "<td class=\"tdT\" style=\"text-align: center;display:none\"> <label class=\"input\"style=\"margin-bottom: 13%;\" ><input type=\"text\"       value=\"" + Totalamnt + "\" name=\"TotalAmount" + intRowBodyCount + "\" id=\"TotalAmount" + intRowBodyCount + "\"  maxlength=\"18\"   ></label>";
            strHtml += "<td class=\"tdT\"style=\"text-align: center;display:none\"> <label class=\"input\"style=\"margin-bottom: 13%;\" ><input type=\"text\"        value=\"" + empsalid + "\" name=\"EmpSalId" + intRowBodyCount + "\" id=\"EmpSalId" + intRowBodyCount + "\"  maxlength=\"18\"   ></label>";
            string emploeeDtls = dt.Rows[intRowBodyCount]["EID"].ToString() + "~" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + "~" + dt.Rows[intRowBodyCount]["CORPRT_NAME"].ToString() + "~" + dt.Rows[intRowBodyCount]["DESIGNATION"].ToString();
            strHtml += "<td class=\"tdT\"style=\"text-align: center;display:none\"> <label class=\"input\"style=\"margin-bottom: 13%;\" ><input type=\"text\"        value=\"" + emploeeDtls + "\" name=\"EmpDetails" + intRowBodyCount + "\" id=\"EmpDetails" + intRowBodyCount + "\"  maxlength=\"24\"   ></label>";

            strHtml += "<td class=\"tdT\"style=\"text-align: center;display:none\"> <label class=\"input\"style=\"margin-bottom: 13%;\" ><input type=\"text\"        value=\"" + MonthYear + "\" name=\"MNTHYR" + intRowBodyCount + "\" id=\"MNTHYR" + intRowBodyCount + "\"  maxlength=\"18\"   ></label>";


            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
    }
    protected void btnRedirect_Click(object sender, EventArgs e)
    {

        int intCorpId = 0, intOrgId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
        cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
        clsEntityCommon objEntCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        string[] empDtls = HiddenForPayment.Value.Split('-');
        string TextBoxId = empDtls[0];
        objEnt.Employee = Convert.ToInt32(empDtls[1]);
        objEnt.SalaryPrssId = Convert.ToInt32(empDtls[2]);
        objEnt.Month = Convert.ToInt32(empDtls[3]);
        objEnt.Year = Convert.ToInt32(empDtls[4]);

        Session["SALAR_PRSS_EDIT"] = HiddenViewId.Value;

        decimal PaidAmount = Convert.ToDecimal(Request.Form["cbMandatory" + TextBoxId]);
        decimal TotAmount = 0, ArrAmount = 0;
        if (Request.Form["TotalAmount" + TextBoxId] != "")
        {
            TotAmount = Convert.ToDecimal(Request.Form["TotalAmount" + TextBoxId]);
        }
        if (Request.Form["ArrearAmount" + TextBoxId] != "")
        {
            ArrAmount = Convert.ToDecimal(Request.Form["ArrearAmount" + TextBoxId]);
        }

        if (TotAmount > PaidAmount)
            objEnt.ArrerMount = TotAmount - PaidAmount;
        objEnt.PaidMount = PaidAmount;
        objBuss.SaveSinglePayment(objEnt);
        //  Response.Redirect("hcm_Monthly_Salary_Process_Master.aspx");
        Session["SALARPRSS_PAID"] = "PAID";
        if (Session["SALARPRSS_PAYMENT"] != null)
        {
            int Processed = 0;

            //  BtnPross.Visible = false;
            cls_Entity_Monthly_Salary_Process objEntPrcss = new cls_Entity_Monthly_Salary_Process();
            var strSALARPRSS = Session["SALARPRSS_PAYMENT"];
            string[] ProssId = strSALARPRSS.ToString().Split('~');
            int SaveOrConf = Convert.ToInt32(ProssId[0]);

            int CorpdepId = Convert.ToInt32(ProssId[1]);
            int staffWrk = Convert.ToInt32(ProssId[2]);
            DateTime ddate = objCommon.textToDateTime(ProssId[3]);

            objEntPrcss.Month = Convert.ToInt32(ProssId[4]);
            objEntPrcss.Year = Convert.ToInt32(ProssId[5]);

            objEntPrcss.PaidFinish = SaveOrConf;

            objEntPrcss.Dep = CorpdepId;
            objEntPrcss.CorpOffice = intCorpId;
            objEntPrcss.StffWrkr = staffWrk;
            objEntPrcss.date = ddate;
            //EVm-0027
            if (HiddenEmployeeId.Value != "")
                objEntPrcss.Employee = Convert.ToInt32(HiddenEmployeeId.Value);
            //END
            DataTable dt = objBuss.LoadSalaryPrssPaymentTable(objEntPrcss);

            objEntPrcss.CorpOffice = intCorpId;
            string ListLoad = ConvertDataTableToHTML(dt, staffWrk);
            divlistview.InnerHtml = ListLoad;
        }

    }
    protected void btnRedirectAll_Click(object sender, EventArgs e)
    {
        cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();

        List<cls_Entity_Monthly_Salary_Process> objList = new List<cls_Entity_Monthly_Salary_Process>();
        int count = Convert.ToInt32(HiddenFieldRowCount.Value);
        for (int i = 0; i < count; i++)
        {
            cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();


            string MothYr = Request.Form["MNTHYR" + i];
            string[] MothYrArr = MothYr.Split('~');
            objEnt.Month = Convert.ToInt32(MothYrArr[0]);
            objEnt.Year = Convert.ToInt32(MothYrArr[1]);
            string Ids = Request.Form["EmpSalId" + i];
            string[] empDtls = Ids.Split(',');
            objEnt.Employee = Convert.ToInt32(empDtls[0]);
            objEnt.SalaryPrssId = Convert.ToInt32(empDtls[1]);
            decimal PaidAmount = Convert.ToDecimal(Request.Form["cbMandatory" + i]);
            decimal ArrAmount = Convert.ToDecimal(Request.Form["ArrearAmount" + i]);
            decimal TotAmount = Convert.ToDecimal(Request.Form["TotalAmount" + i]);
            if (TotAmount > PaidAmount)
                objEnt.ArrerMount = TotAmount - PaidAmount;
            objEnt.PaidMount = PaidAmount;
            objList.Add(objEnt);
        }
        objBuss.SaveAllPayment(objList);
        Session["SALARPRSS_PAID"] = "PAID1";
        Response.Redirect("hcm_Monthly_Salary_Process_List.aspx");
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
        cls_Entity_Monthly_Salary_Process objEntPrcss = new cls_Entity_Monthly_Salary_Process();
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["SALARPRSS_PAYMENT"] != null)
        {
            var strSALARPRSS = Session["SALARPRSS_PAYMENT"];
            string[] ProssId = strSALARPRSS.ToString().Split('~');
            int SaveOrConf = Convert.ToInt32(ProssId[0]);

            int CorpdepId = Convert.ToInt32(ProssId[1]);
            int staffWrk = Convert.ToInt32(ProssId[2]);
            DateTime ddate = objCommon.textToDateTime(ProssId[3]);
            objEntPrcss.Month = Convert.ToInt32(ProssId[4]);

            objEntPrcss.Year = Convert.ToInt32(ProssId[5]);
            objEntPrcss.PaidFinish = SaveOrConf;
            objEntPrcss.Dep = CorpdepId;
            objEntPrcss.CorpOffice = intCorpId;
            objEntPrcss.StffWrkr = staffWrk;
            objEntPrcss.date = ddate;
            //EVm-0027
            if (HiddenEmployeeId.Value != "")
                objEntPrcss.Employee = Convert.ToInt32(HiddenEmployeeId.Value);
            //END
            DataTable dt = objBuss.LoadSalaryPrssPaymentTable(objEntPrcss);
            if (dt.Rows.Count > 0)
            {
                if (HiddenEmployeeId.Value != "")
                    objEntPrcss.Employee = Convert.ToInt32(HiddenEmployeeId.Value);
                objEntPrcss.SalaryPrssId = Convert.ToInt32(hiddenSalaryPrcsdId.Value);
            }

            Generate_LabourCard_PDF(objEntPrcss);
            //Generate_LabourCard_PDF_old(objEntPrcss);
            

            ScriptManager.RegisterStartupScript(this, GetType(), "PrintClick", "PrintClick();", true);
        }

    }

    public void Generate_LabourCard_PDF(cls_Entity_Monthly_Salary_Process OBJ)
    {
        string indvlRound = HiddenFieldIndividualRound.Value;
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

        DataTable dtCorp = objBuss.ReadCorporateAddress(objEntPrcss);
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "", strCompanyLogo = "";

        string strTitle = "";
        //l1
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


        cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
        objEnt.Employee = OBJ.Employee;
        objEnt.Month = OBJ.Month;
        objEnt.Year = OBJ.Year;
        OBJ.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        OBJ.Orgid = Convert.ToInt32(Session["ORGID"].ToString());

        DataTable dtSalPrssDtls;
        dtSalPrssDtls = objBuss.ReadSalaryProssDtlsById(objEnt);

        if (dtSalPrssDtls.Rows.Count > 0)
        {



        //    Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);
            Document document = new Document(PageSize.LETTER, 15f, 25f, 15f, 45f);
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                string strImageName = "LabourCard_" + OBJ.SalaryPrssId + ".pdf";
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

                if (true)
                {
                    PdfPTable headtable = new PdfPTable(2);
                    //lbr -1 year 11
                    headtable.AddCell(new PdfPCell(new Phrase("LABOR CARD", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    if (strCompanyLogo != "")
                    {
                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strCompanyLogo));
                        image.ScalePercent(PdfPCell.ALIGN_CENTER);
                        image.ScaleToFit(60f, 40f);
                        headtable.AddCell(new PdfPCell(image) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
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
                    tableLine.AddCell(new PdfPCell(new Phrase("_____________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    tableLine.WriteSelectedRows(0, -1, 0, document.PageSize.GetTop(55), writer.DirectContent);



                    float pos9 = writer.GetVerticalPosition(false);
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

                    int numMonth = DateTime.DaysInMonth(OBJ.Year, OBJ.Month);
                    string MonthName = "";

                    decimal NormlOT = 0, HoldayOt = 0;
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
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 4, Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("EMPLOYEE CODE", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(dtSalPrssDtls.Rows[0]["USR_CODE"].ToString(), new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("DESIGNATION", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(dtSalPrssDtls.Rows[0]["DSGN_NAME"].ToString(), new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });


                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("MONTH & YEAR", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(MonthName.ToUpper() + " " + OBJ.Year, new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 2, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });


                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("EMPLOYEE NAME", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(dtSalPrssDtls.Rows[0]["USR_NAME"].ToString(), new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 3, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });

                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 4, Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    if (pos9 > 150)
                    {
                    }
                    else
                    {
                        document.NewPage();
                    }
                    document.Add(pdfBodyTable);


                    float pos8 = writer.GetVerticalPosition(false);
                    if (pos8 > 150)
                    {
                    }
                    else
                    {
                        document.NewPage();
                    }

                    document.Add(tableLayout);

                    string basicAmt = "", AllowaceAmt = "", AllowovertimeAmount = "", DedctionAmt = "", DedctionInstalmntAmnt = "", Total = "", OT_Hours = "", MessAmnt = "", LvArrearAmnt = "";
                    Decimal TotalBasicAllow = 0, TotalDedctn = 0, netsalary = 0, AllowovertimeAmount1 = 0, AllowaceAmt1 = 0, basicAmt1 = 0, instlmntDedctionAmt = 0, deductnamt = 0;
                    Decimal decMessAmnt = 0, decLvArrearAmnt = 0, decCurrMonthBasic = 0, decPrevArrAmnt = 0;

                    basicAmt = dtSalPrssDtls.Rows[0]["SLRY_BASIC_PAY"].ToString();
                    AllowaceAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_ALLOW_AMT"].ToString();
                    AllowovertimeAmount = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_OVERTIME_ALLOW_AMT"].ToString();
                    DedctionAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_DEDCTN_AMT"].ToString();
                    DedctionInstalmntAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_INSTLMNT_DEDCN_AMT"].ToString();
                    Total = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_TOTAL_AMT"].ToString();
                    decPrevArrAmnt = Convert.ToDecimal(dtSalPrssDtls.Rows[0]["SLPRCDMNTH_PREV_MNTH_ARRE_AMNT"].ToString());

                    DataTable dtOtherAddDedDetls = objBuss.ReadEmpManualy_Add_Dedn_Dtls(OBJ);
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


                    if (dtSalPrssDtls.Rows.Count > 0)
                    {

                        if (dtSalPrssDtls.Rows[0]["SLPRCDMNTH_TOTAL_AMT"].ToString() != "")
                        {
                            OT_Hours = dtSalPrssDtls.Rows[0]["EMDLHRDTL_OT"].ToString();
                        }
                        MessAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_MESS_DEDCTN_AMT"].ToString();
                        LvArrearAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_LEV_ARREAR_AMT"].ToString();
                    }


                    int daysInm = DateTime.DaysInMonth(objEntPrcss.Year, objEntPrcss.Month);
                    decimal decPerHourSal = Convert.ToDecimal(basicAmt) / daysInm;
                    if (decPerHourSal > 0)
                    {
                        decPerHourSal = decPerHourSal / 8;
                    }

                    decimal NormalOTAmnt = NormlOT * NormalOvertmRatePrHr * decPerHourSal;
                    decimal HolidayOTAmnt = HoldayOt * HolidayOvertmRatePrHr * decPerHourSal;
                    decimal TotOvertimeAmnt = NormalOTAmnt + HolidayOTAmnt;
                    decimal decbasicAmtPrc = 0;
                    if (dtSalPrssDtls.Rows[0]["SLPRCDMNTH_PRSD_BASICPAY"].ToString() != "")
                    {
                        decbasicAmtPrc = Convert.ToDecimal(dtSalPrssDtls.Rows[0]["SLPRCDMNTH_PRSD_BASICPAY"].ToString());
                    }

                    if (basicAmt != "")
                    {
                        basicAmt1 = Convert.ToDecimal(basicAmt);
                        TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(decbasicAmtPrc);
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
                    if (decPrevArrAmnt < 0)
                    {
                        TotalDedctn = TotalDedctn + (decPrevArrAmnt*-1);
                    }


                    if (TotOthrDeductAmt != 0)
                    {
                        TotalDedctn = TotalDedctn + Convert.ToDecimal(TotOthrDeductAmt);
                    }
                    if (Total != "")
                    {
                       // netsalary = Convert.ToDecimal(Total);
                        netsalary = TotalBasicAllow-TotalDedctn;
                    }
                    int roundInd = 0;
                    if (indvlRound == "0")
                    {
                        roundInd = 2;
                    }


                    string strbasicAmtProces = objBusiness.AddCommasForNumberSeperation(Math.Round(decbasicAmtPrc, roundInd).ToString("0.00"), objEntityCommon);
                    string strbasicAmt = objBusiness.AddCommasForNumberSeperation(Math.Round(basicAmt1, roundInd).ToString("0.00"), objEntityCommon);
                    string strAllowaceAmt = objBusiness.AddCommasForNumberSeperation(Math.Round(AllowaceAmt1, roundInd).ToString("0.00"), objEntityCommon);
                    string strAllowovertimeAmount = objBusiness.AddCommasForNumberSeperation(Math.Round(AllowovertimeAmount1, roundInd).ToString("0.00"), objEntityCommon);
                    string strTotalBasicAllow = objBusiness.AddCommasForNumberSeperation(Math.Round(TotalBasicAllow, roundInd).ToString("0.00"), objEntityCommon);
                    string strDeductnAmt = objBusiness.AddCommasForNumberSeperation(Math.Round(deductnamt, roundInd).ToString("0.00"), objEntityCommon);
                    string strDeductnInstlmtAmount = objBusiness.AddCommasForNumberSeperation(Math.Round(instlmntDedctionAmt, roundInd).ToString("0.00"), objEntityCommon);
                    string strTotalDedctn = objBusiness.AddCommasForNumberSeperation(Math.Round(TotalDedctn, roundInd).ToString("0.00"), objEntityCommon);
                    string strnetsalary = objBusiness.AddCommasForNumberSeperation(Math.Round(netsalary, 0).ToString("0.00"), objEntityCommon);
                    string strMessAmnt = objBusiness.AddCommasForNumberSeperation(Math.Round(decMessAmnt, roundInd).ToString("0.00"), objEntityCommon);
                    string strLvArrearAmnt = objBusiness.AddCommasForNumberSeperation(Math.Round(decLvArrearAmnt, roundInd).ToString("0.00"), objEntityCommon);
                    string strNormalOTAmnt = objBusiness.AddCommasForNumberSeperation(Math.Round(NormalOTAmnt, roundInd).ToString("0.00"), objEntityCommon);
                    string strHolidayOTAmnt = objBusiness.AddCommasForNumberSeperation(Math.Round(HolidayOTAmnt, roundInd).ToString("0.00"), objEntityCommon);
                    string strPrevArrAmt = objBusiness.AddCommasForNumberSeperation(Math.Round(decPrevArrAmnt, roundInd).ToString("0.00"), objEntityCommon);

                    decimal PerDaySalCurr = Convert.ToDecimal(basicAmt1) / daysInm;
                    decimal workdays = decbasicAmtPrc / PerDaySalCurr;
                    workdays = Math.Round(workdays, 1);
                    if (workdays % 1 == 0)
                    {
                        workdays = Convert.ToInt32(workdays);
                    }

                    float pos4 = writer.GetVerticalPosition(false);
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
                    sumtable.AddCell(new PdfPCell(new Phrase(strbasicAmtProces, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    if (Convert.ToDecimal(strAllowaceAmt) != 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Special Allowance", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strAllowaceAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
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
                    sumtable.AddCell(new PdfPCell(new Phrase(strnetsalary + " " + dtSalPrssDtls.Rows[0]["CRNCMST_ABBRV"].ToString(), FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    if (pos4 > 400)
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
                    endtable.AddCell(new PdfPCell(new Phrase("RECEIVER'S SIGNATURE", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                    endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });

                    if (pos1 > 70)
                    {
                        endtable.WriteSelectedRows(0, -1, 50, 65, writer.DirectContent);
                    }
                    else
                    {
                        document.NewPage();
                        endtable.WriteSelectedRows(0, -1, 50, 65, writer.DirectContent);
                    }
                }//if TRADE                                            
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

    }


    public void Generate_LabourCard_PDF_old(cls_Entity_Monthly_Salary_Process OBJ)
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
            decimal NormalOvertmRatePrHr = 0,HolidayOvertmRatePrHr = 0;

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

            string RowCount = HiddenRowCount.Value;

            tableheadlayout.AddCell(new PdfPCell(new Phrase("Employee", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 7 });
            if (RowCount != "")
            {
                //string name=dt.Rows[0][2].ToString();

                string Employeedtl = Request.Form["EmpDetails" + RowCount];
                string[] Emp = Employeedtl.ToString().Split('~');
                tableheadlayout.AddCell(new PdfPCell(new Phrase(Emp[0], FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase(Emp[1], FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase("Trade", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 7 });
                tableheadlayout.AddCell(new PdfPCell(new Phrase(Emp[3], FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7 });
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
            sumtable.AddCell(new PdfPCell(new Phrase("Deductions", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 8, BackgroundColor = BaseColor.LIGHT_GRAY, Colspan = 4});
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
            sumtable.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Times New Roman", 11,  BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 8, BackgroundColor = BaseColor.LIGHT_GRAY, Colspan = 4 });
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
            headImg.WriteSelectedRows(0, -1, 50, document.PageSize.GetBottom(40), writer.DirectContent);


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

    public string ConvertDataTableToHtmlEmp_list(cls_Entity_Monthly_Salary_Process OBJ)
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
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntPrcss.Orgid = Convert.ToInt32(Session["ORGID"].ToString());


        }

        strCapTable = "<table  class=\"tab\" cellspacing=\"0\" cellpadding=\"2px\" >";
        strCapTable += "<thead>";
        strCapTable += "<tr >";
        //   strCapTable += "<th class=\"thT\" style=\"width:5%;text-align: center; word-wrap:break-word;border: solid 1px #939191;\">Record sequence </th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount <= 5; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 0)
            {
                strCapTable += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;height: 36px;\">Date</th>";

            }

            else if (intColumnHeaderCount == 1)
            {
                strCapTable += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;height: 36px;\">Job #</th>";
            }
            else if (intColumnHeaderCount == 2)
            {
                strCapTable += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;height: 36px;\">Status</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strCapTable += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;height: 36px;\">Normal Hrs</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strCapTable += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;height: 36px;\">Normal OT</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strCapTable += "<th class=\"thT\"  style=\"width:7%;text-align: center; word-wrap:break-word;height: 36px;\">Holiday OT</th>";
            }

        }
        strCapTable += "</tr>";
        strCapTable += "</thead>";
        strCapTable += "<tbody>";
        int numMonth = DateTime.DaysInMonth(OBJ.Year, OBJ.Month);
        for (int intRowBodyCount = 1; intRowBodyCount <= numMonth; intRowBodyCount++)
        {
            strCapTable += "<tr  >";
            // strCapTable += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;border: solid 1px #939191;\">" + count.ToString() + "</td>";
            // count++;
            //  DateTime value = new DateTime(OBJ.Year, OBJ.Month, intRowBodyCount);
            string EmDate = new DateTime(OBJ.Year, OBJ.Month, intRowBodyCount).ToString("dd-MM-yyyy");
            DateTime ddate = objCommon.textToDateTime(EmDate);

            objEntPrcss.date = ddate;
            string MonthName = ddate.ToString("MMMM");
            objEntPrcss.Employee = OBJ.Employee;
            objEntPrcss.Month = OBJ.Month;
            objEntPrcss.Year = OBJ.Year;
            DataTable dtEmp_list = objBuss.ReadEmp_List_For_Print(objEntPrcss);
            DataTable dtCorp = objBuss.ReadCorporateAddress(objEntPrcss);
            string strCompanyName = "";
            if (dtCorp.Rows.Count > 0)
            {
                strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();

            }
            string strCaptionTabstart = "<table class=\"PrintCaptionTable\" style=\" width:100%;text-align: center; \"  >";
            string strCaptionTabCompanyNameRow = "<tr><th class=\"CompanyName\">" + strCompanyName + "</td></tr>";

            string strCaptionTabRprtDate = "<tr><th class=\"RprtDate\">Labor Card For " + MonthName + "-" + objEntPrcss.Year + "</td></tr>";
            string RowCount = HiddenRowCount.Value;
            string strEmpCodeAndName = "", strEmpCodeAndName1 = "", strEmpCodeAndName2 = "";
            if (RowCount != "")
            {
                string Employeedtl = Request.Form["EmpDetails" + RowCount];
                string[] Emp = Employeedtl.ToString().Split('~');
                strEmpCodeAndName = "<tr><th class=\"RprtDate\">Employee ID: " + Emp[0] + "</td></tr>";
                strEmpCodeAndName1 = "<tr><th class=\"RprtDate\">Employee Name: " + Emp[1] + "</td></tr>";
                strEmpCodeAndName2 = "<tr><th class=\"RprtDate\">Business Unit: " + Emp[2] + "</td></tr>";
            }
            string strCaptionTabstop = "</table>";

            strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabRprtDate + strEmpCodeAndName + strEmpCodeAndName1 + strEmpCodeAndName2 + strCaptionTabstop;
            // DateTime dd = Convert.ToDateTime(dt.Rows[intRowBodyCount]["EMPDLYHR_DATE"].ToString());
            strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">" + ddate + "</td>";
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


                    }
                    if (row["OVRTMCATG_NAME"].ToString() == "HOLIDAY OT")
                    {
                        strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\"></td>";
                        strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">" + dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString() + "</td>";
                    }
                }

            }
            else
            {
                strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">  </td>";

                strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\"></td>";


                strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\"></td>";
                strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\"></td>";
                strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\"></td>";
            }

            strCapTable += "</tr>";

        }
        cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
        objEnt.Employee = OBJ.Employee;
        objEnt.Month = OBJ.Month;
        objEnt.Year = OBJ.Year;
        DataTable dtSalPrssDtls;
        dtSalPrssDtls = objBuss.ReadSalaryProssDtlsById(objEnt);
        string basicAmt = "", AllowaceAmt = "", AllowovertimeAmount = "", DedctionAmt = "", DedctionInstalmntAmnt = "", Total = "";
        Decimal TotalBasicAllow = 0, TotalDedctn = 0, netsalary = 0, AllowovertimeAmount1 = 0, AllowaceAmt1 = 0, basicAmt1 = 0;
        if (dtSalPrssDtls.Rows.Count > 0)
        {
            basicAmt = dtSalPrssDtls.Rows[0]["SLRY_BASIC_PAY"].ToString();
            AllowaceAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_ALLOW_AMT"].ToString();
            AllowovertimeAmount = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_OVERTIME_ALLOW_AMT"].ToString();
            DedctionAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_DEDCTN_AMT"].ToString();
            DedctionInstalmntAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_INSTLMNT_DEDCN_AMT"].ToString();
            Total = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_TOTAL_AMT"].ToString();
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

        // if (AllowovertimeAmount != "")
        //{
        //    TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(AllowovertimeAmount);
        //}
        if (DedctionAmt != "")
        {
            TotalDedctn = TotalDedctn + Convert.ToDecimal(DedctionAmt);
        }
        if (DedctionInstalmntAmnt != "")
        {
            TotalDedctn = TotalDedctn + Convert.ToDecimal(DedctionInstalmntAmnt);
        }
        if (Total != "")
        {
            netsalary = Convert.ToDecimal(Total);
        }
        //TotalBasicAllow - TotalDedctn;
        strCapTable += "<tr >";
        strCapTable += "<td class=\"tdT\" ColSpan=\"6\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 60px;\">";
        strCapTable += "</tr>";
        strCapTable += "<tr  >";
        strCapTable += "<th class=\"tdT\" ColSpan=\"6\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;margin-top:10%\">BASIC & ALLOWANCES</td>";
        strCapTable += "</tr>";
        strCapTable += "<tr  >";
        strCapTable += "</tr>";
        strCapTable += "<tr  >";
        strCapTable += "<td class=\"tdT\" ColSpan=\"6\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">";
        //new table begin
        strCapTable += "<table cellspacing=\"0\" cellpadding=\"2px\" style=\" width:100%\" >";
        strCapTable += "<thead>";
        strCapTable += "<tr class=class=\"top_row\">";
        strCapTable += "<th class=\"tdT\"  style=\"width:10%;text-align: center; word-wrap:break-word;height: 36px;\">DESCRIPTION</th>";
        strCapTable += "<th class=\"tdT\"  style=\"width:10%;text-align: center; word-wrap:break-word;height: 36px;\">AMOUNT</th>";
        //  strCapTable += "<th class=\"tdT\"  style=\"width:10%;text-align: center; word-wrap:break-word;height: 36px;\">DESCRIPTION</th>";
        strCapTable += "</td>";
        strCapTable += "</tr>";
        strCapTable += "<thead>";
        strCapTable += "<tbody>";
        strCapTable += "<tr>";
        strCapTable += "<td class=\"tdT\"  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left; height: 36px;padding-left: 21%;\">Basic</td>";
        string strbasicAmt = objBusiness.AddCommasForNumberSeperation(basicAmt1.ToString("0.00"), objEntityCommon);
        strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">" + strbasicAmt + "</td>";
        strCapTable += "</tr>";
        strCapTable += "<tr>";
        strCapTable += "<td class=\"tdT\"  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left; height: 36px;padding-left: 21%;\">Special Allowance</td>";
        string strAllowaceAmt = objBusiness.AddCommasForNumberSeperation(AllowaceAmt1.ToString("0.00"), objEntityCommon);
        strCapTable += "<td class=\"tdT\"  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">" + strAllowaceAmt + "</td>";
        strCapTable += "</tr>";
        strCapTable += "<tr>";
        strCapTable += "<td class=\"tdT\"  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left; height: 36px;padding-left: 21%;\">Over Time Allowance</td>";

        string strAllowovertimeAmount = objBusiness.AddCommasForNumberSeperation(AllowovertimeAmount1.ToString("0.00"), objEntityCommon);
        strCapTable += "<td class=\"tdT\"  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">" + strAllowovertimeAmount + "</td>";
        strCapTable += "</tr>";
        strCapTable += "<tr>";
        strCapTable += "<td class=\"tdT\"  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left; height: 36px;padding-left: 21%;\">Total Basic & Allowance</td>";
        string strTotalBasicAllow = objBusiness.AddCommasForNumberSeperation(TotalBasicAllow.ToString("0.00"), objEntityCommon);
        strCapTable += "<td class=\"tdT\"  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">" + strTotalBasicAllow + "</td>";
        strCapTable += "</tr>";
        strCapTable += "<tr  >";
        strCapTable += "<th class=\"tdT\" ColSpan=\"6\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;margin-top:10%\">Deductions</td>";
        strCapTable += "</tr>";
        strCapTable += "<tr>";
        strCapTable += "<td class=\"tdT\"  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left; height: 36px;padding-left: 21%;\">Special Deductions</td>";
        string strTotalDedctn = objBusiness.AddCommasForNumberSeperation(TotalDedctn.ToString("0.00"), objEntityCommon);
        strCapTable += "<td class=\"tdT\"  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">" + strTotalDedctn + "</td>";
        strCapTable += "</tr>";
        strCapTable += "<tr  >";
        strCapTable += "<th class=\"tdT\"  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;margin-top:10%\">NET SALARY</td>";
        //netsalary = decimal.Round(netsalary, 2, MidpointRounding.AwayFromZero);
        string strnetsalary = objBusiness.AddCommasForNumberSeperation(netsalary.ToString("0.00"), objEntityCommon);

        strCapTable += "<th class=\"tdT\"  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;margin-top:10%\">" + strnetsalary + "</td>";

        strCapTable += "</tr>";
        strCapTable += "</tbody>";
        // table close
        strCapTable += "</table>";
        strCapTable += "</tr>";
        strCapTable += "</tbody>";
        strCapTable += "</table>";
        // strPrintCaptionTable = strPrintCaptionTable + strCapTable;
        divSIFHeader.InnerHtml = strPrintCaptionTable;
        sbCap.Append(strCapTable);
        return sbCap.ToString();
    }


    protected void btnPrintPaySlip_Click(object sender, EventArgs e)
    {
        string a = "sssss";

        cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
        cls_Entity_Monthly_Salary_Process objEntPrcss = new cls_Entity_Monthly_Salary_Process();
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["SALARPRSS_PAYMENT"] != null)
        {
            var strSALARPRSS = Session["SALARPRSS_PAYMENT"];
            string[] ProssId = strSALARPRSS.ToString().Split('~');
            int SaveOrConf = Convert.ToInt32(ProssId[0]);

            int CorpdepId = Convert.ToInt32(ProssId[1]);
            int staffWrk = Convert.ToInt32(ProssId[2]);
            DateTime ddate = objCommon.textToDateTime(ProssId[3]);
            objEntPrcss.Month = Convert.ToInt32(ProssId[4]);

            objEntPrcss.Year = Convert.ToInt32(ProssId[5]);
            objEntPrcss.PaidFinish = SaveOrConf;
            objEntPrcss.Dep = CorpdepId;
            objEntPrcss.CorpOffice = intCorpId;
            objEntPrcss.StffWrkr = staffWrk;
            objEntPrcss.date = ddate;
            //EVm-0027
            if (HiddenEmployeeId.Value != "")
                objEntPrcss.Employee = Convert.ToInt32(HiddenEmployeeId.Value);
            //END
            DataTable dt = objBuss.LoadSalaryPrssPaymentTable(objEntPrcss);
            if (dt.Rows.Count > 0)
            {
                if (HiddenEmployeeId.Value != "")
                    objEntPrcss.Employee = Convert.ToInt32(HiddenEmployeeId.Value);
                objEntPrcss.SalaryPrssId = Convert.ToInt32(hiddenSalaryPrcsdId.Value);
            }

            DataTable dtEmp_list = objBuss.ReadEmp_List_For_Print(objEntPrcss);


            Generate_Payslip_PDF(dt, objEntPrcss);

            //string strHtmlPaySlipEmp = ConvertDataTableToHtmlPay_Slip(dt, objEntPrcss);
            //divSIFbody2.InnerHtml = strHtmlPaySlipEmp;
            ScriptManager.RegisterStartupScript(this, GetType(), "PrintClick1", "PrintClick1();", true);
        }
    }

    public void Generate_Payslip_PDF(DataTable dt, cls_Entity_Monthly_Salary_Process objMonthlySalaryProcess)
    {
        string indvlRound = HiddenFieldIndividualRound.Value;
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

            string basicAmt = "", SalaryProcssdBasicAmt = "", AllowaceAmt = "", AllowovertimeAmount = "", DedctionAmt = "", DedctionInstalmntAmnt = "", Total = "", OT_Hours = "", MessAmnt = "", LvArrearAmnt = "", OtherAddAmnt = "", OtherDeductAmnt = "";
            Decimal TotalBasicAllow = 0, TotalDedctn = 0, netsalary = 0, AllowovertimeAmount1 = 0, AllowaceAmt1 = 0, basicAmt1 = 0, decSalaryProcssdBasicAmt = 0, spclDedctionAmt = 0, instlmntDedctionAmt = 0, decOtherAddAmnt = 0, decOtherDeductAmnt = 0;
            Decimal decMessAmnt = 0, decLvArrearAmnt = 0, decPrevArrAmnt = 0;
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

                OtherAddAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_OTHR_ADTION_AMT"].ToString();
                OtherDeductAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_OTHR_DEDCTN_AMT"].ToString();
                decPrevArrAmnt = Convert.ToDecimal(dtSalPrssDtls.Rows[0]["SLPRCDMNTH_PREV_MNTH_ARRE_AMNT"].ToString());
            }
            if (basicAmt != "")
            {
                basicAmt1 = Convert.ToDecimal(basicAmt);
              //  TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(basicAmt);
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
            if (OtherAddAmnt != "")
            {
                decOtherAddAmnt = Convert.ToDecimal(OtherAddAmnt);
                TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(OtherAddAmnt);
            }
            if (decPrevArrAmnt > 0)
            {
                TotalBasicAllow = TotalBasicAllow + decPrevArrAmnt;
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
            if (OtherDeductAmnt != "")
            {
                decOtherDeductAmnt = Convert.ToDecimal(OtherDeductAmnt);
                TotalDedctn = TotalDedctn + Convert.ToDecimal(OtherDeductAmnt);
            }
            if (decPrevArrAmnt < 0)
            {
                TotalDedctn = TotalDedctn + (decPrevArrAmnt*-1);
            }
            if (Total != "")
            {
                netsalary = Convert.ToDecimal(Total);
            }
            int roundInd = 0;
            if (indvlRound == "0")
            {
                roundInd = 2;
            }
            string strbasicAmt = objBusiness.AddCommasForNumberSeperation(Math.Round(basicAmt1, roundInd).ToString("0.00"), objEntityCommon);
            string strSalaryProcssdBasicAmt = objBusiness.AddCommasForNumberSeperation(Math.Round(decSalaryProcssdBasicAmt, roundInd).ToString("0.00"), objEntityCommon);
            string strAllowaceAmt = objBusiness.AddCommasForNumberSeperation(Math.Round(AllowaceAmt1, roundInd).ToString("0.00"), objEntityCommon);
            string strAllowovertimeAmount = objBusiness.AddCommasForNumberSeperation(Math.Round(AllowovertimeAmount1, roundInd).ToString("0.00"), objEntityCommon);
            string strTotalBasicAllow = objBusiness.AddCommasForNumberSeperation(Math.Round(TotalBasicAllow, roundInd).ToString("0.00"), objEntityCommon);
            string strTotalDedctn = objBusiness.AddCommasForNumberSeperation(Math.Round(TotalDedctn, roundInd).ToString("0.00"), objEntityCommon);
            string strspclDedctionAmt = objBusiness.AddCommasForNumberSeperation(Math.Round(spclDedctionAmt, roundInd).ToString("0.00"), objEntityCommon);
            string strinstlmntDedctionAmt = objBusiness.AddCommasForNumberSeperation(Math.Round(instlmntDedctionAmt, roundInd).ToString("0.00"), objEntityCommon);
            string strMessAmnt = objBusiness.AddCommasForNumberSeperation(Math.Round(decMessAmnt, roundInd).ToString("0.00"), objEntityCommon);
            string strLvArrearAmnt = objBusiness.AddCommasForNumberSeperation(Math.Round(decLvArrearAmnt, roundInd).ToString("0.00"), objEntityCommon);
            string strnetsalary = objBusiness.AddCommasForNumberSeperation(Math.Round(netsalary, 0).ToString("0.00"), objEntityCommon);
            string strOtherAddAmt = objBusiness.AddCommasForNumberSeperation(Math.Round(decOtherAddAmnt, roundInd).ToString("0.00"), objEntityCommon);
            string strOtherDeductAmt = objBusiness.AddCommasForNumberSeperation(Math.Round(decOtherDeductAmnt, roundInd).ToString("0.00"), objEntityCommon);

            string strPrevArrAmnt = objBusiness.AddCommasForNumberSeperation(Math.Round(decPrevArrAmnt, roundInd).ToString("0.00"), objEntityCommon);

            PdfPTable tableheadlayout = new PdfPTable(5);
            float[] tableheadlayoutBody = { 15, 43, 7, 23, 12 };
            tableheadlayout.SetWidths(tableheadlayoutBody);
            tableheadlayout.WidthPercentage = 100;

            tableheadlayout.AddCell(new PdfPCell(new Phrase("Employee #", FontFactory.GetFont("Times New Roman", 10,Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tableheadlayout.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["EID"].ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });


            tableheadlayout.AddCell(new PdfPCell(new Phrase("Name", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tableheadlayout.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["EMPLOYEE"].ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });

            tableheadlayout.AddCell(new PdfPCell(new Phrase("Department", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tableheadlayout.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["CPRDEPT_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });

            tableheadlayout.AddCell(new PdfPCell(new Phrase("Designation", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tableheadlayout.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["DESIGNATION"].ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tableheadlayout.AddCell(new PdfPCell(new Phrase("Eligible Days", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tableheadlayout.AddCell(new PdfPCell(new Phrase(NofDaysMonth.ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });

            tableheadlayout.AddCell(new PdfPCell(new Phrase("Job Title", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tableheadlayout.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["JOBRL_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tableheadlayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tableheadlayout.AddCell(new PdfPCell(new Phrase("Present Days", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tableheadlayout.AddCell(new PdfPCell(new Phrase(AttendncCount.ToString(), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });

            document.Add(tableheadlayout);

            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 20, BaseColor.BLACK))));
         //   document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 20, BaseColor.BLACK))));

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
                        
            tablelayout.AddCell(new PdfPCell(new Phrase("Other Addition", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(strOtherAddAmt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(strOtherAddAmt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase("Other Deduction", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
            tablelayout.AddCell(new PdfPCell(new Phrase(strOtherDeductAmt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });


            if (decPrevArrAmnt >= 0)
            {
                tablelayout.AddCell(new PdfPCell(new Phrase("Arrear Amount", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tablelayout.AddCell(new PdfPCell(new Phrase(strPrevArrAmnt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tablelayout.AddCell(new PdfPCell(new Phrase(strPrevArrAmnt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tablelayout.AddCell(new PdfPCell(new Phrase("Leave Arrear Deduction", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tablelayout.AddCell(new PdfPCell(new Phrase(strLvArrearAmnt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });


                tablelayout.AddCell(new PdfPCell(new Phrase("Total Basic & Allowances", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6, Colspan = 3 });
                tablelayout.AddCell(new PdfPCell(new Phrase(strTotalBasicAllow, FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                tablelayout.AddCell(new PdfPCell(new Phrase("Total Deduction", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tablelayout.AddCell(new PdfPCell(new Phrase(strTotalDedctn, FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });

            }
            else
            {


                tablelayout.AddCell(new PdfPCell(new Phrase("Total Basic & Allowances", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6, Colspan = 3 });
                tablelayout.AddCell(new PdfPCell(new Phrase(strTotalBasicAllow, FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tablelayout.AddCell(new PdfPCell(new Phrase("Leave Arrear Deduction", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tablelayout.AddCell(new PdfPCell(new Phrase(strLvArrearAmnt, FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });


                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tablelayout.AddCell(new PdfPCell(new Phrase("Arrear Amount", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tablelayout.AddCell(new PdfPCell(new Phrase(strPrevArrAmnt.Replace("-", string.Empty), FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });



                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tablelayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 10, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tablelayout.AddCell(new PdfPCell(new Phrase("Total Deduction", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 6 });
                tablelayout.AddCell(new PdfPCell(new Phrase(strTotalDedctn, FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6 });
            }
            document.Add(tablelayout);

            PdfPTable tablelayoutnet = new PdfPTable(3);
            float[] tablenetlayoutBody = { 68, 23, 12 };
            tablelayoutnet.SetWidths(tablenetlayoutBody);
            tablelayoutnet.WidthPercentage = 100;

            //tablelayoutnet.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6, Colspan = 3 });
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

            endtable.AddCell(new PdfPCell(new Phrase("Prepared By", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border=0 ,Padding = 6 });
            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
            endtable.AddCell(new PdfPCell(new Phrase("Checked By", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border=0 , Padding = 6 });
            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
            endtable.AddCell(new PdfPCell(new Phrase("Received By", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border=0 , Padding = 6 });
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

        //DataTable dtEmp_list = objBuss.ReadEmp_List_For_Print(objEntPrcss);
        DataTable dtEmp_list = objBuss.ReadEmp_List_For_PaySlip_Print(objEntPrcss);

        DataTable dtSalPrssDtls = objBuss.ReadSalaryProssDtlsById(objEntPrcss);

        //   DataTable dtOTHours = objBuss.ReadAllounceDailyhrList(objEnt);
        //strHtml += "<div class=\"col-lg-8 logo\"><img src=\"/Images/certficate/logo.PNG\" width=\"60\" />";
        sbPaySlip.Append("<div class=\"col-lg-8 logo\"><img src=\"/CustomImages/Corporate Logos/pdf.png\" width=\"60\" />");
        sbPaySlip.Append("<h3 style=\"text-align:center\">Payslip for the Month of " + MonthName + ", " + objEntPrcss.Year + "<h3>");
        sbPaySlip.Append("<br><br>");

        sbPaySlip.Append("<div style=\"width:100%; height:60%\">");
        sbPaySlip.Append("<div style=\"width:50%;height:60%;float:left;\">");
        sbPaySlip.Append("<table style=\"width:100%;  \" class=\"tab\" cellspacing=\"0\" cellpadding=\"1px\" >");
        sbPaySlip.Append("<tr> <td><strong>Employee #</strong></td>  <td>" + dt.Rows[0]["EID"].ToString() + "</td>  </tr>");
        sbPaySlip.Append("<tr> <td><strong>Name</strong></td>  <td> " + dt.Rows[0]["EMPLOYEE"].ToString() + " </td>  </tr>");
        sbPaySlip.Append("<tr> <td><strong>Department</strong></td>  <td>" + dt.Rows[0]["CPRDEPT_NAME"].ToString() + "  </td>  </tr>");
        sbPaySlip.Append("<tr> <td><strong>Designation</strong></td>  <td>" + dt.Rows[0]["DESIGNATION"].ToString() + " </td>  </tr>");
        sbPaySlip.Append("<tr> <td><strong>Job Title</strong></td>  <td> " + dt.Rows[0]["JOBRL_NAME"].ToString() + "  </td>  </tr>");
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
        sbPaySlip.Append("<tr> <td><strong>Eligible Days</strong></td>  <td style=\"text-align:center\"> " + NofDaysMonth + " </td>  </tr>");
        sbPaySlip.Append("<tr> <td><strong>Present Days</strong></td>  <td style=\"text-align:center\">" + AttendncCount + " </td>  </tr> ");
        sbPaySlip.Append("</table> </div> ");
        sbPaySlip.Append("</div>");



        string basicAmt = "", AllowaceAmt = "", AllowovertimeAmount = "", DedctionAmt = "", DedctionInstalmntAmnt = "", Total = "", OT_Hours = "";
        Decimal TotalBasicAllow = 0, TotalDedctn = 0, netsalary = 0, AllowovertimeAmount1 = 0, AllowaceAmt1 = 0, basicAmt1 = 0, spclDedctionAmt = 0, instlmntDedctionAmt = 0;
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
            spclDedctionAmt = Convert.ToDecimal(DedctionAmt);
            TotalDedctn = TotalDedctn + Convert.ToDecimal(DedctionAmt);
        }
        if (DedctionInstalmntAmnt != "")
        {
            instlmntDedctionAmt = Convert.ToDecimal(DedctionInstalmntAmnt);
            TotalDedctn = TotalDedctn + Convert.ToDecimal(DedctionInstalmntAmnt);
        }
        if (Total != "")
        {
            netsalary = Convert.ToDecimal(Total);
        }


        sbPaySlip.Append("<div style=\"width:100%;  height:50%\">");
        sbPaySlip.Append("<div style=\"width:51%;float:left;\">");
        sbPaySlip.Append("<br> <br>");
        sbPaySlip.Append("<table style=\"width:98%;\" class=\"tab\" cellspacing=\"0\" cellpadding=\"1px\" >");
        sbPaySlip.Append("<tr style=\"background-color: #cacfd2;height: 30px;\"> <td style=\"text-align:center\" colspan=\"4\" > Basic & Allowances</td>  </tr>");
        sbPaySlip.Append("<tr style=\"text-align:center\"> <td style=\"text-align:left\"> Description</td> <th style=\"text-align:right\">Amount</td> <td> Hours</td> <td style=\"text-align:right\">Earned</td>  </tr>");

        string strbasicAmt = objBusiness.AddCommasForNumberSeperation(basicAmt1.ToString("0.00"), objEntityCommon);
        sbPaySlip.Append("<tr> <td>" + dt.Rows[0]["PAY GRADE"].ToString() + "</td> <td style=\"text-align:right\">" + strbasicAmt + "</td> <td></td> <td style=\"text-align:right\">" + strbasicAmt + "</td>   </tr> ");

        string strAllowaceAmt = objBusiness.AddCommasForNumberSeperation(AllowaceAmt1.ToString("0.00"), objEntityCommon);
        sbPaySlip.Append("<tr> <td>Special Allowance</td> <td style=\"text-align:right\">" + strAllowaceAmt + "</td> <td></td> <td style=\"text-align:right\">" + strAllowaceAmt + "</td>   </tr> ");

        string strAllowovertimeAmount = objBusiness.AddCommasForNumberSeperation(AllowovertimeAmount1.ToString("0.00"), objEntityCommon);
        sbPaySlip.Append("<tr> <td>Over Time Allowance</td> <td style=\"text-align:right\">" + strAllowovertimeAmount + "</td> <td style=\"text-align:center\"> " + OT_Hours + "  </td> <td style=\"text-align:right\">" + strAllowovertimeAmount + "</td>   </tr> ");
        string strTotalBasicAllow = objBusiness.AddCommasForNumberSeperation(TotalBasicAllow.ToString("0.00"), objEntityCommon);
        sbPaySlip.Append("<tr  > <td colspan=\"3\" > Total Basic & Allowances </td> <td style=\"text-align:right\">" + strTotalBasicAllow + "</td>  </tr>");
        sbPaySlip.Append("</table> </div>");

        sbPaySlip.Append("<div style=\"width:49%;float:right;\">");
        sbPaySlip.Append("<br> <br>");
        sbPaySlip.Append("<table style=\"width:82.5%; float: right;\" class=\"tab\" cellspacing=\"0\" cellpadding=\"1px\" >");
        string strTotalDedctn = objBusiness.AddCommasForNumberSeperation(TotalDedctn.ToString("0.00"), objEntityCommon);
        sbPaySlip.Append("<tr style=\"background-color: #cacfd2;height: 30px;\"> <td style=\"text-align:center\" colspan=\"2\" >Deduction</td>  </tr> ");
        sbPaySlip.Append("<tr> <th colspan=\"2\" style=\"text-align:right\" > Amount</th>  </tr>");

        string strspclDedctionAmt = objBusiness.AddCommasForNumberSeperation(spclDedctionAmt.ToString("0.00"), objEntityCommon);
        string strinstlmntDedctionAmt = objBusiness.AddCommasForNumberSeperation(instlmntDedctionAmt.ToString("0.00"), objEntityCommon);
        sbPaySlip.Append("<tr> <td>Special Deduction</td>  <td style=\"text-align:right\">  " + strspclDedctionAmt + " </td>  </tr>");
        sbPaySlip.Append("<tr> <td>Installment Deduction</td>  <td style=\"text-align:right\">  " + strinstlmntDedctionAmt + " </td>  </tr>");
        sbPaySlip.Append("<tr> <td>Total Deduction</td>  <td style=\"text-align:right\">  " + strTotalDedctn + " </td>  </tr>");
        sbPaySlip.Append("</table>  </div>");
        sbPaySlip.Append("</div>");

        sbPaySlip.Append("<div  >");
        sbPaySlip.Append("<div style=\"width:100%\">");
        sbPaySlip.Append("<table style=\"width:40.5%;float:right;margin-top: 8%;\" class=\"tab\" cellspacing=\"0\" cellpadding=\"1px\" >");
        string strnetsalary = objBusiness.AddCommasForNumberSeperation(netsalary.ToString("0.00"), objEntityCommon);
        sbPaySlip.Append("<tr><td><h2>Net Salary </h2> </td> <td style=\"text-align:right\"><h2>" + strnetsalary + " </h2></td> </tr>");
        sbPaySlip.Append("</div>");
        sbPaySlip.Append("</div>");

        return sbPaySlip.ToString();
    }





    public string OgConvertDataTableToHTML(DataTable dt)
    {

        cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
        cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        int intOrgId = 0;
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());


        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        HiddenFieldRowCount.Value = dt.Rows.Count.ToString();
        if (HiddenFieldRowCount.Value != "0")
        {
            HiddenFinishOrPend.Value = dt.Rows[0]["SLPRCDMNTH_STATUS"].ToString();
        }
        else
        {
            HiddenFinishOrPend.Value = "1";
        }

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"table table-striped table-bordered\" width=\"100%\" style=\"border-spacing: 1px;background-color: #e7e6e6;\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr >";

        strHtml += "<tr >";

        int intCnclUsrId = 0;
        int intReCallForTAble = 0;

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:10%\"> EMPLOYEE ID";
                strHtml += "</th >";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:15%\">EMPLOYEE";
                strHtml += "</th >";
            }

            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:10%;\"> DESIGNATION";
                strHtml += "</th >";
            }

            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:15%;text-align: right;\">SALARY AMOUNT";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:15%;text-align: right;\">ARREAR AMOUNT";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:15%;text-align: right;\">FINAL AMOUNT";
                strHtml += "</th >";
            }

        }
        strHtml += "<th class=\"hasinput\" style=\"width:15%;text-align: right;\">PAID AMOUNT";
        if (HiddenFieldRowCount.Value != "0")
        {
            if (dt.Rows[0]["SLPRCDMNTH_STATUS"].ToString() == "3")
            {
                strHtml += " <th class=\"hasinput\" style=\"width:15%;\"><button  onclick=\"return ToPaidAll();\" style=\"width: 100%;background-color: #88bdf2;border: 1px solid darkblue;\" class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\">paid</button>";
            }
        }
        if (HiddenFieldRowCount.Value != "0")
        {
            if (dt.Rows[0]["SLPRCDMNTH_STATUS"].ToString() == "1")
            {
                strHtml += "<th class=\"hasinput\" style=\"width:15%;\">PRINT";
            }
        }
        strHtml += "<th class=\"hasinput\" style=\"width:15%;display:none\">PAID";
        strHtml += "<th class=\"hasinput\" style=\"width:15%;display:none\">PAID";
        strHtml += "<th class=\"hasinput\" style=\"width:15%;display:none\">PAID";
        strHtml += "<th class=\"hasinput\" style=\"width:15%;display:none\">PAID";
        strHtml += "<th class=\"hasinput\" style=\"width:15%;display:none\">PAID";
        strHtml += "</th >";

        strHtml += "</th >";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        Decimal Arrearamount = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            //arrear amount
            string UserId = dt.Rows[intRowBodyCount]["USR_ID"].ToString();
            DateTime DateDate = Convert.ToDateTime(dt.Rows[intRowBodyCount]["SLPRCDMNTH_FROM_DATE"].ToString());
            DateTime PrevMonth;
            int IntMonthInt = Convert.ToInt32(dt.Rows[intRowBodyCount]["SLPRCDMNTH_NUMBR"].ToString());
            int IntYearInt = Convert.ToInt32(dt.Rows[intRowBodyCount]["SLPRCDMNTH_YEAR"].ToString());
            string MonthYear = IntMonthInt + "~" + IntYearInt;
            int intmonth, intYear;
            if (IntMonthInt == 1)
            {
                intmonth = 12;
                intYear = IntYearInt - 1;
            }
            else
            {
                intYear = IntYearInt;
                intmonth = IntMonthInt - 1;
            }
            PrevMonth = DateDate.AddMonths(-1);
            objEnt.Month = intmonth;
            objEnt.Year = intYear;
            objEnt.Employee = Convert.ToInt32(UserId);
            DataTable ArrearAmountdt = objBuss.GetArrearAmount(objEnt);
            if (ArrearAmountdt.Rows.Count > 0)
            {
                if (ArrearAmountdt.Rows[0]["SLPRCDMNTH_ARREAR_AMNT"].ToString() != "")
                {
                    Arrearamount = Convert.ToDecimal(ArrearAmountdt.Rows[0]["SLPRCDMNTH_ARREAR_AMNT"].ToString());
                }

            }

            //totalamount
            decimal Totalamnt = 0, ArrearAmt = 0;
            if (dt.Rows[intRowBodyCount]["SLPRCDMNTH_TOTAL_AMT"].ToString() != "")
                Totalamnt = Convert.ToDecimal(dt.Rows[intRowBodyCount]["SLPRCDMNTH_TOTAL_AMT"].ToString());
            Totalamnt = Totalamnt + ArrearAmt;

            string PrssMnthId = dt.Rows[intRowBodyCount]["SLPRCDMNTH_ID"].ToString();

            string empsalid = UserId + "," + PrssMnthId;
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EID"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {

                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + "</td>";
                }

                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DESIGNATION"].ToString() + "</td>";
                }

                else if (intColumnBodyCount == 4)
                {
                    string NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(dt.Rows[intRowBodyCount]["SLPRCDMNTH_TOTAL_AMT"].ToString(), objEntityCommon);
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + NetAmountWithCommaFrm + "</td>";
                }
                else if (intColumnBodyCount == 5)
                {
                    // Arrearamount = Arrearamount + Convert.ToDecimal(dt.Rows[intRowBodyCount]["SLPRCDMNTH_ARREAR_AMNT"].ToString());
                    if (HiddenFieldRowCount.Value != "0")
                    {
                        if (dt.Rows[0]["SLPRCDMNTH_STATUS"].ToString() == "3")
                        {
                            string NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(Arrearamount.ToString("0.00"), objEntityCommon);
                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + NetAmountWithCommaFrm + "</td>";
                        }
                        else
                        {
                            string NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(dt.Rows[intRowBodyCount]["SLPRCDMNTH_ARREAR_AMNT"].ToString(), objEntityCommon);
                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + NetAmountWithCommaFrm + "</td>";
                        }
                    }
                    else
                    {
                        string NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(dt.Rows[intRowBodyCount]["SLPRCDMNTH_ARREAR_AMNT"].ToString(), objEntityCommon);
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + NetAmountWithCommaFrm + "</td>";
                    }
                }
                else if (intColumnBodyCount == 6)
                {
                    if (dt.Rows[0]["SLPRCDMNTH_STATUS"].ToString() == "3")
                    {
                        Totalamnt = Totalamnt;
                        //+Arrearamount;
                    }

                    string NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(Totalamnt.ToString(), objEntityCommon);

                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + NetAmountWithCommaFrm + "</td>";
                }
                else if (intColumnBodyCount == 7)
                {

                    if (HiddenFieldRowCount.Value != "0")
                    {
                        if (dt.Rows[0]["SLPRCDMNTH_STATUS"].ToString() == "3")
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:15%;text-align: center;\"> <label class=\"input\"style=\"margin-bottom: 13%;\" ><input type=\"text\"   onkeydown=\"return isNumberSalary(event,'cbMandatory" + intRowBodyCount + "');\"  onblur=\"AmountChecking('cbMandatory" + intRowBodyCount + "','cbMandatory" + intRowBodyCount + "','cbMandatory" + intRowBodyCount + "');\"   value=\"" + Totalamnt + "\" name=\"cbMandatory" + intRowBodyCount + "\"  id=\"cbMandatory" + intRowBodyCount + "\"  maxlength=\"18\"   onkeypress='return DisableEnter(event)'  ></label>";
                        }
                        else
                        {

                            string NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(dt.Rows[intRowBodyCount]["SLPRCDMNTH_PAID_AMT"].ToString(), objEntityCommon);
                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + NetAmountWithCommaFrm + "</td>";
                        }
                    }
                    else
                    {
                        string NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(dt.Rows[intRowBodyCount]["SLPRCDMNTH_PAID_AMT"].ToString(), objEntityCommon);
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + NetAmountWithCommaFrm + "</td>";
                    }
                }
                else if (intColumnBodyCount == 8)
                {
                    if (HiddenFieldRowCount.Value != "0")
                    {
                        if (dt.Rows[intRowBodyCount]["SLPRCDMNTH_STATUS"].ToString() == "3" || dt.Rows[intRowBodyCount]["SLPRCDMNTH_STATUS"].ToString() == "")
                        {

                            strHtml += " <td style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button  style=\"width: 100%;background-color: #dedada;\" class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\"   onclick=\"return ToPaid(" + intRowBodyCount + "," + UserId + "," + PrssMnthId + "," + IntMonthInt.ToString() + "," + IntYearInt.ToString() + ");\">paid</button></td>";
                        }
                    }
                }
            }
            if (HiddenFieldRowCount.Value != "0")
            {
                if (dt.Rows[intRowBodyCount]["SLPRCDMNTH_STATUS"].ToString() == "1" || dt.Rows[intRowBodyCount]["SLPRCDMNTH_STATUS"].ToString() == "1")
                {
                    strHtml += " <td style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button  style=\"width: 100%;background-color: #dedada;1px solid #212323\" class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\"   onclick=\"return Clickme(" + dt.Rows[intRowBodyCount]["USR_ID"].ToString() + "," + intRowBodyCount + "," + dt.Rows[intRowBodyCount]["SLPRCDMNTH_ID"].ToString() +")\">Print</button></td>";
                }
            }
            strHtml += "<td class=\"tdT\" style=\"text-align: center;display:none\"> <label class=\"input\"style=\"margin-bottom: 13%;\" ><input type=\"text\"        value=\"" + Arrearamount + "\" name=\"ArrearAmount" + intRowBodyCount + "\" id=\"ArrearAmount" + intRowBodyCount + "\"  maxlength=\"18\"   ></label>";
            strHtml += "<td class=\"tdT\" style=\"text-align: center;display:none\"> <label class=\"input\"style=\"margin-bottom: 13%;\" ><input type=\"text\"       value=\"" + Totalamnt + "\" name=\"TotalAmount" + intRowBodyCount + "\" id=\"TotalAmount" + intRowBodyCount + "\"  maxlength=\"18\"   ></label>";
            strHtml += "<td class=\"tdT\"style=\"text-align: center;display:none\"> <label class=\"input\"style=\"margin-bottom: 13%;\" ><input type=\"text\"        value=\"" + empsalid + "\" name=\"EmpSalId" + intRowBodyCount + "\" id=\"EmpSalId" + intRowBodyCount + "\"  maxlength=\"18\"   ></label>";
            string emploeeDtls = dt.Rows[intRowBodyCount]["EID"].ToString() + "~" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + "~" + dt.Rows[intRowBodyCount]["CORPRT_NAME"].ToString() + "~" + dt.Rows[intRowBodyCount]["DESIGNATION"].ToString();
            strHtml += "<td class=\"tdT\"style=\"text-align: center;display:none\"> <label class=\"input\"style=\"margin-bottom: 13%;\" ><input type=\"text\"        value=\"" + emploeeDtls + "\" name=\"EmpDetails" + intRowBodyCount + "\" id=\"EmpDetails" + intRowBodyCount + "\"  maxlength=\"24\"   ></label>";

            strHtml += "<td class=\"tdT\"style=\"text-align: center;display:none\"> <label class=\"input\"style=\"margin-bottom: 13%;\" ><input type=\"text\"        value=\"" + MonthYear + "\" name=\"MNTHYR" + intRowBodyCount + "\" id=\"MNTHYR" + intRowBodyCount + "\"  maxlength=\"18\"   ></label>";


            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    public string OgConvertDataTableToHtmlEmp_list(cls_Entity_Monthly_Salary_Process OBJ)
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
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntPrcss.Orgid = Convert.ToInt32(Session["ORGID"].ToString());


        }

        strCapTable = "<table  class=\"tab\" cellspacing=\"0\" cellpadding=\"2px\" >";
        strCapTable += "<thead>";
        strCapTable += "<tr >";
        //   strCapTable += "<th class=\"thT\" style=\"width:5%;text-align: center; word-wrap:break-word;border: solid 1px #939191;\">Record sequence </th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount <= 5; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 0)
            {
                strCapTable += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;height: 36px;\">Date</th>";

            }

            else if (intColumnHeaderCount == 1)
            {
                strCapTable += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;height: 36px;\">Job #</th>";
            }
            else if (intColumnHeaderCount == 2)
            {
                strCapTable += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;height: 36px;\">Status</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strCapTable += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;height: 36px;\">Normal Hrs</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strCapTable += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;height: 36px;\">Normal OT</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strCapTable += "<th class=\"thT\"  style=\"width:7%;text-align: center; word-wrap:break-word;height: 36px;\">Holiday OT</th>";
            }

        }
        strCapTable += "</tr>";
        strCapTable += "</thead>";
        strCapTable += "<tbody>";
        int numMonth = DateTime.DaysInMonth(OBJ.Year, OBJ.Month);
        for (int intRowBodyCount = 1; intRowBodyCount <= numMonth; intRowBodyCount++)
        {
            strCapTable += "<tr  >";
            // strCapTable += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;border: solid 1px #939191;\">" + count.ToString() + "</td>";
            // count++;
            //  DateTime value = new DateTime(OBJ.Year, OBJ.Month, intRowBodyCount);
            string EmDate = new DateTime(OBJ.Year, OBJ.Month, intRowBodyCount).ToString("dd-MM-yyyy");
            DateTime ddate = objCommon.textToDateTime(EmDate);
            objEntPrcss.date = ddate;
            string MonthName = ddate.ToString("MMMM");
            objEntPrcss.Employee = OBJ.Employee;
            objEntPrcss.Month = OBJ.Month;
            objEntPrcss.Year = OBJ.Year;
            DataTable dtEmp_list = objBuss.ReadEmp_List_For_Print(objEntPrcss);
            DataTable dtCorp = objBuss.ReadCorporateAddress(objEntPrcss);
            string strCompanyName = "";
            if (dtCorp.Rows.Count > 0)
            {
                strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();

            }
            string strCaptionTabstart = "<table class=\"PrintCaptionTable\" style=\" width:100%;text-align: center; \"  >";
            string strCaptionTabCompanyNameRow = "<tr><th class=\"CompanyName\">" + strCompanyName + "</td></tr>";

            string strCaptionTabRprtDate = "<tr><th class=\"RprtDate\">Labor Card For " + MonthName + "-" + objEntPrcss.Year + "</td></tr>";
            string RowCount = HiddenRowCount.Value;
            string strEmpCodeAndName = "", strEmpCodeAndName1 = "", strEmpCodeAndName2 = "";
            if (RowCount != "")
            {
                string Employeedtl = Request.Form["EmpDetails" + RowCount];
                string[] Emp = Employeedtl.ToString().Split('~');
                strEmpCodeAndName = "<tr><th class=\"RprtDate\">Employee ID: " + Emp[0] + "</td></tr>";
                strEmpCodeAndName1 = "<tr><th class=\"RprtDate\">Employee Name: " + Emp[1] + "</td></tr>";
                strEmpCodeAndName2 = "<tr><th class=\"RprtDate\">Business Unit: " + Emp[2] + "</td></tr>";
            }
            string strCaptionTabstop = "</table>";

            strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabRprtDate + strEmpCodeAndName + strEmpCodeAndName1 + strEmpCodeAndName2 + strCaptionTabstop;
            // DateTime dd = Convert.ToDateTime(dt.Rows[intRowBodyCount]["EMPDLYHR_DATE"].ToString());
            strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">" + ddate + "</td>";
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


                    }
                    if (row["OVRTMCATG_NAME"].ToString() == "HOLIDAY OT")
                    {
                        strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\"></td>";
                        strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">" + dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString() + "</td>";
                    }
                }

            }
            else
            {
                strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">  </td>";

                strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\"></td>";


                strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\"></td>";
                strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\"></td>";
                strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\"></td>";
            }

            strCapTable += "</tr>";

        }
        cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
        objEnt.Employee = OBJ.Employee;
        objEnt.Month = OBJ.Month;
        objEnt.Year = OBJ.Year;
        DataTable dtSalPrssDtls;
        dtSalPrssDtls = objBuss.ReadSalaryProssDtlsById(objEnt);
        string basicAmt = "", AllowaceAmt = "", AllowovertimeAmount = "", DedctionAmt = "", DedctionInstalmntAmnt = "", Total = "";
        Decimal TotalBasicAllow = 0, TotalDedctn = 0, netsalary = 0, AllowovertimeAmount1 = 0, AllowaceAmt1 = 0, basicAmt1 = 0;
        if (dtSalPrssDtls.Rows.Count > 0)
        {
            basicAmt = dtSalPrssDtls.Rows[0]["SLRY_BASIC_PAY"].ToString();
            AllowaceAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_ALLOW_AMT"].ToString();
            AllowovertimeAmount = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_OVERTIME_ALLOW_AMT"].ToString();
            DedctionAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_DEDCTN_AMT"].ToString();
            DedctionInstalmntAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_INSTLMNT_DEDCN_AMT"].ToString();
            Total = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_TOTAL_AMT"].ToString();
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

        // if (AllowovertimeAmount != "")
        //{
        //    TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(AllowovertimeAmount);
        //}
        if (DedctionAmt != "")
        {
            TotalDedctn = TotalDedctn + Convert.ToDecimal(DedctionAmt);
        }
        if (DedctionInstalmntAmnt != "")
        {
            TotalDedctn = TotalDedctn + Convert.ToDecimal(DedctionInstalmntAmnt);
        }
        if (Total != "")
        {
            netsalary = Convert.ToDecimal(Total);
        }
        //TotalBasicAllow - TotalDedctn;
        strCapTable += "<tr >";
        strCapTable += "<td class=\"tdT\" ColSpan=\"6\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 60px;\">";
        strCapTable += "</tr>";
        strCapTable += "<tr  >";
        strCapTable += "<th class=\"tdT\" ColSpan=\"6\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;margin-top:10%\">BASIC & ALLOWANCES</td>";
        strCapTable += "</tr>";
        strCapTable += "<tr  >";
        strCapTable += "</tr>";
        strCapTable += "<tr  >";
        strCapTable += "<td class=\"tdT\" ColSpan=\"6\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">";
        //new table begin
        strCapTable += "<table cellspacing=\"0\" cellpadding=\"2px\" style=\" width:100%\" >";
        strCapTable += "<thead>";
        strCapTable += "<tr class=class=\"top_row\">";
        strCapTable += "<th class=\"tdT\"  style=\"width:10%;text-align: center; word-wrap:break-word;height: 36px;\">DESCRIPTION</th>";
        strCapTable += "<th class=\"tdT\"  style=\"width:10%;text-align: center; word-wrap:break-word;height: 36px;\">AMOUNT</th>";
        //  strCapTable += "<th class=\"tdT\"  style=\"width:10%;text-align: center; word-wrap:break-word;height: 36px;\">DESCRIPTION</th>";
        strCapTable += "</td>";
        strCapTable += "</tr>";
        strCapTable += "<thead>";
        strCapTable += "<tbody>";
        strCapTable += "<tr>";
        strCapTable += "<td class=\"tdT\"  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left; height: 36px;padding-left: 21%;\">Basic</td>";
        string strbasicAmt = objBusiness.AddCommasForNumberSeperation(basicAmt1.ToString("0.00"), objEntityCommon);
        strCapTable += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">" + strbasicAmt + "</td>";
        strCapTable += "</tr>";
        strCapTable += "<tr>";
        strCapTable += "<td class=\"tdT\"  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left; height: 36px;padding-left: 21%;\">Special Allowance</td>";
        string strAllowaceAmt = objBusiness.AddCommasForNumberSeperation(AllowaceAmt1.ToString("0.00"), objEntityCommon);
        strCapTable += "<td class=\"tdT\"  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">" + strAllowaceAmt + "</td>";
        strCapTable += "</tr>";
        strCapTable += "<tr>";
        strCapTable += "<td class=\"tdT\"  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left; height: 36px;padding-left: 21%;\">Over Time Allowance</td>";

        string strAllowovertimeAmount = objBusiness.AddCommasForNumberSeperation(AllowovertimeAmount1.ToString("0.00"), objEntityCommon);
        strCapTable += "<td class=\"tdT\"  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">" + strAllowovertimeAmount + "</td>";
        strCapTable += "</tr>";
        strCapTable += "<tr>";
        strCapTable += "<td class=\"tdT\"  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left; height: 36px;padding-left: 21%;\">Total Basic & Allowance</td>";
        string strTotalBasicAllow = objBusiness.AddCommasForNumberSeperation(TotalBasicAllow.ToString("0.00"), objEntityCommon);
        strCapTable += "<td class=\"tdT\"  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">" + strTotalBasicAllow + "</td>";
        strCapTable += "</tr>";
        strCapTable += "<tr  >";
        strCapTable += "<th class=\"tdT\" ColSpan=\"6\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;margin-top:10%\">Deductions</td>";
        strCapTable += "</tr>";
        strCapTable += "<tr>";
        strCapTable += "<td class=\"tdT\"  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left; height: 36px;padding-left: 21%;\">Special Deductions</td>";
        string strTotalDedctn = objBusiness.AddCommasForNumberSeperation(TotalDedctn.ToString("0.00"), objEntityCommon);
        strCapTable += "<td class=\"tdT\"  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;\">" + strTotalDedctn + "</td>";
        strCapTable += "</tr>";
        strCapTable += "<tr  >";
        strCapTable += "<th class=\"tdT\"  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;margin-top:10%\">NET SALARY</td>";
        //netsalary = decimal.Round(netsalary, 2, MidpointRounding.AwayFromZero);
        string strnetsalary = objBusiness.AddCommasForNumberSeperation(netsalary.ToString("0.00"), objEntityCommon);

        strCapTable += "<th class=\"tdT\"  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center; height: 36px;margin-top:10%\">" + strnetsalary + "</td>";

        strCapTable += "</tr>";
        strCapTable += "</tbody>";
        // table close
        strCapTable += "</table>";
        strCapTable += "</tr>";
        strCapTable += "</tbody>";
        strCapTable += "</table>";
        // strPrintCaptionTable = strPrintCaptionTable + strCapTable;
        divSIFHeader.InnerHtml = strPrintCaptionTable;
        sbCap.Append(strCapTable);
        return sbCap.ToString();

    }


    protected void btnDownloadAll_Click(object sender, EventArgs e)
    {
        string indvlRound = HiddenFieldIndividualRound.Value;
        cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
        cls_Entity_Monthly_Salary_Process OBJ = new cls_Entity_Monthly_Salary_Process();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        int intOrgId = 0;
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        int roundInd = 0;
        if (indvlRound == "0")
        {
            roundInd = 2;
        }
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["SALARPRSS_PAYMENT"] != null)
        {
            var strSALARPRSS = Session["SALARPRSS_PAYMENT"];
            string[] ProssId = strSALARPRSS.ToString().Split('~');
            int SaveOrConf = Convert.ToInt32(ProssId[0]);

            int CorpdepId = Convert.ToInt32(ProssId[1]);
            int staffWrk = Convert.ToInt32(ProssId[2]);
            DateTime ddat = objCommon.textToDateTime(ProssId[3]);
            OBJ.Month = Convert.ToInt32(ProssId[4]);

            OBJ.Year = Convert.ToInt32(ProssId[5]);
            OBJ.PaidFinish = SaveOrConf;
            OBJ.Dep = CorpdepId;
            OBJ.CorpOffice = intCorpId;
            OBJ.Orgid = intOrgId;
            OBJ.StffWrkr = staffWrk;
            OBJ.date = ddat;
            DataSet ds = new DataSet();
            DataTable dtSal = new DataTable();
            Stream memoryStreamForZipFile = null;
            ZipFile zipFile = new ZipFile();
            string[] EmpId = hiddenAllEmpid.Value.Split(',');
            dtSal = objBuss.LoadSalaryPrssPaymentTable(OBJ);


            DataTable dtCorp = objBuss.ReadCorporateAddress(OBJ);
            string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "", strCompanyLogo = "";

            string strTitle = "";
            //l1   objEntPrcss.date = ddate
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


            for (int i = 0; i < dtSal.Rows.Count; i++)
            {
                int empid = Convert.ToInt32(dtSal.Rows[i]["USR_ID"]);
                cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
                objEnt.Employee = empid;
                objEnt.Month = OBJ.Month;
                objEnt.Year = OBJ.Year;
                DataTable dtSalPrssDtls;
                dtSalPrssDtls = objBuss.ReadSalaryProssDtlsById(objEnt);

                string fileName = null;
                Document document = null;
                MemoryStream memoryStream = null;
                PdfWriter pdfWriter = null;


                memoryStream = new MemoryStream();

                document = new Document(PageSize.LETTER, 15f, 25f, 15f, 45f);

                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                string strImageName = "LabourCard_" + Convert.ToInt32(empid) + ".pdf";
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

                if (true)
                {
                    PdfPTable headtable = new PdfPTable(2);
                    //lbr -1 year 11
                    headtable.AddCell(new PdfPCell(new Phrase("LABOR CARD", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    if (strCompanyLogo != "")
                    {
                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strCompanyLogo));
                        image.ScalePercent(PdfPCell.ALIGN_CENTER);
                        image.ScaleToFit(60f, 40f);
                        headtable.AddCell(new PdfPCell(image) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
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
                    tableLine.AddCell(new PdfPCell(new Phrase("________________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                    tableLine.WriteSelectedRows(0, -1, 0, document.PageSize.GetTop(57), writer.DirectContent);


                    float pos9 = writer.GetVerticalPosition(false);
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

                    int numMonth = DateTime.DaysInMonth(OBJ.Year, OBJ.Month);
                    string MonthName = "";

                    decimal NormlOT = 0, HoldayOt = 0;
                    decimal NormalOvertmRatePrHr = 0, HolidayOvertmRatePrHr = 0;

                    for (int intRowBodyCount = 1; intRowBodyCount <= numMonth; intRowBodyCount++)
                    {
                        string EmDate = new DateTime(OBJ.Year, OBJ.Month, intRowBodyCount).ToString("dd-MM-yyyy");
                        DateTime ddate = objCommon.textToDateTime(EmDate);

                        OBJ.date = ddate;
                        MonthName = ddate.ToString("MMMM");
                        OBJ.Employee = empid;
                        OBJ.Month = OBJ.Month;
                        OBJ.Year = OBJ.Year;
                        DataTable dtEmp_list = objBuss.ReadEmp_List_For_Print(OBJ);

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
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 4, Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("EMPLOYEE CODE", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(dtSalPrssDtls.Rows[0]["USR_CODE"].ToString(), new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("DESIGNATION", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(dtSalPrssDtls.Rows[0]["DSGN_NAME"].ToString(), new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });


                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("MONTH & YEAR", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(MonthName.ToUpper() + " " + OBJ.Year, new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 2, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });


                    pdfBodyTable.AddCell(new PdfPCell(new Phrase("EMPLOYEE NAME", new Font(FontFactory.GetFont("Times New Roman", 9, Font.BOLD, BaseColor.BLACK)))) { VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(dtSalPrssDtls.Rows[0]["USR_NAME"].ToString(), new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 3, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });

                    pdfBodyTable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Times New Roman", 9, Font.NORMAL, BaseColor.BLACK)))) { Colspan = 4, Border = 0, VerticalAlignment = Element.ALIGN_CENTER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    if (pos9 > 150)
                    {
                    }
                    else
                    {
                        document.NewPage();
                    }
                    document.Add(pdfBodyTable);


                    float pos8 = writer.GetVerticalPosition(false);
                    if (pos8 > 150)
                    {
                    }
                    else
                    {
                        document.NewPage();
                    }

                    document.Add(tableLayout);

                    string basicAmt = "", AllowaceAmt = "", AllowovertimeAmount = "", DedctionAmt = "", DedctionInstalmntAmnt = "", Total = "", OT_Hours = "", MessAmnt = "", LvArrearAmnt = "";
                    Decimal TotalBasicAllow = 0, TotalDedctn = 0, netsalary = 0, AllowovertimeAmount1 = 0, AllowaceAmt1 = 0, basicAmt1 = 0, instlmntDedctionAmt = 0, deductnamt = 0;
                    Decimal decMessAmnt = 0, decLvArrearAmnt = 0, decCurrMonthBasic = 0, decPrevArrAmnt = 0;

                    basicAmt = dtSalPrssDtls.Rows[0]["SLRY_BASIC_PAY"].ToString();
                    AllowaceAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_ALLOW_AMT"].ToString();
                    AllowovertimeAmount = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_OVERTIME_ALLOW_AMT"].ToString();
                    DedctionAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_DEDCTN_AMT"].ToString();
                    DedctionInstalmntAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_INSTLMNT_DEDCN_AMT"].ToString();
                    Total = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_TOTAL_AMT"].ToString();

                    decimal decbasicAmtPrc = 0;
                    if (dtSalPrssDtls.Rows[0]["SLPRCDMNTH_PRSD_BASICPAY"].ToString() != "")
                    {
                        decbasicAmtPrc = Convert.ToDecimal(dtSalPrssDtls.Rows[0]["SLPRCDMNTH_PRSD_BASICPAY"].ToString());
                    }

                    decPrevArrAmnt = Convert.ToDecimal(dtSalPrssDtls.Rows[0]["SLPRCDMNTH_PREV_MNTH_ARRE_AMNT"].ToString());
                    if (dtSalPrssDtls.Rows.Count > 0)
                    {

                        if (dtSalPrssDtls.Rows[0]["SLPRCDMNTH_TOTAL_AMT"].ToString() != "")
                        {
                            OT_Hours = dtSalPrssDtls.Rows[0]["EMDLHRDTL_OT"].ToString();
                        }
                        MessAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_MESS_DEDCTN_AMT"].ToString();
                        LvArrearAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_LEV_ARREAR_AMT"].ToString();
                    }

                    int daysInm = DateTime.DaysInMonth(OBJ.Year, OBJ.Month);
                    decimal decPerHourSal = Convert.ToDecimal(basicAmt) / daysInm;
                    if (decPerHourSal > 0)
                    {
                        decPerHourSal = decPerHourSal / 8;
                    }

                    decimal NormalOTAmnt = NormlOT * NormalOvertmRatePrHr * decPerHourSal;
                    decimal HolidayOTAmnt = HoldayOt * HolidayOvertmRatePrHr * decPerHourSal;
                    decimal TotOvertimeAmnt = NormalOTAmnt + HolidayOTAmnt;

                    if (basicAmt != "")
                    {
                        basicAmt1 = Convert.ToDecimal(basicAmt);
                        TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(decbasicAmtPrc);
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
                    if (decPrevArrAmnt < 0)
                    {
                        TotalDedctn = TotalDedctn + (decPrevArrAmnt*-1);
                    }
                    if (Total != "")
                    {
                        //  netsalary = Convert.ToDecimal(Total);
                        netsalary = TotalBasicAllow - TotalDedctn;
                    }

                    string strbasicAmtProces = objBusiness.AddCommasForNumberSeperation(Math.Round(decbasicAmtPrc, roundInd).ToString("0.00"), objEntityCommon);
                    string strbasicAmt = objBusiness.AddCommasForNumberSeperation(Math.Round(basicAmt1, roundInd).ToString("0.00"), objEntityCommon);
                    string strAllowaceAmt = objBusiness.AddCommasForNumberSeperation(Math.Round(AllowaceAmt1, roundInd).ToString("0.00"), objEntityCommon);
                    string strAllowovertimeAmount = objBusiness.AddCommasForNumberSeperation(Math.Round(AllowovertimeAmount1, roundInd).ToString("0.00"), objEntityCommon);
                    string strTotalBasicAllow = objBusiness.AddCommasForNumberSeperation(Math.Round(TotalBasicAllow, roundInd).ToString("0.00"), objEntityCommon);
                    string strDeductnAmt = objBusiness.AddCommasForNumberSeperation(Math.Round(deductnamt, roundInd).ToString("0.00"), objEntityCommon);
                    string strDeductnInstlmtAmount = objBusiness.AddCommasForNumberSeperation(Math.Round(instlmntDedctionAmt, roundInd).ToString("0.00"), objEntityCommon);
                    string strTotalDedctn = objBusiness.AddCommasForNumberSeperation(Math.Round(TotalDedctn, roundInd).ToString("0.00"), objEntityCommon);
                    string strnetsalary = objBusiness.AddCommasForNumberSeperation(Math.Round(netsalary, 0).ToString("0.00"), objEntityCommon);
                    string strMessAmnt = objBusiness.AddCommasForNumberSeperation(Math.Round(decMessAmnt, roundInd).ToString("0.00"), objEntityCommon);
                    string strLvArrearAmnt = objBusiness.AddCommasForNumberSeperation(Math.Round(decLvArrearAmnt, roundInd).ToString("0.00"), objEntityCommon);

                    string strNormalOTAmnt = objBusiness.AddCommasForNumberSeperation(Math.Round(NormalOTAmnt, roundInd).ToString("0.00"), objEntityCommon);
                    string strHolidayOTAmnt = objBusiness.AddCommasForNumberSeperation(Math.Round(HolidayOTAmnt, roundInd).ToString("0.00"), objEntityCommon);
                    string strPrevArrAmnt = objBusiness.AddCommasForNumberSeperation(Math.Round(decPrevArrAmnt, roundInd).ToString("0.00"), objEntityCommon);

                    

                    decimal PerDaySalCurr = Convert.ToDecimal(basicAmt1) / daysInm;
                    decimal workdays = decbasicAmtPrc / PerDaySalCurr;
                    workdays = Math.Round(workdays, 1);
                    if (workdays % 1 == 0)
                    {
                        workdays = Convert.ToInt32(workdays);
                    }


                    float pos4 = writer.GetVerticalPosition(false);
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
                    sumtable.AddCell(new PdfPCell(new Phrase(strbasicAmtProces, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    if (Convert.ToDecimal(strAllowaceAmt) != 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Special Allowance", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strAllowaceAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strAllowaceAmt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    }
                    if (NormlOT != 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Normal OT @" + NormalOvertmRatePrHr.ToString() + "/hr", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(NormlOT.ToString(), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strAllowovertimeAmount, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    }

                    if (HoldayOt != 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Holiday OT @" + HolidayOvertmRatePrHr.ToString() + "/hr", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(HoldayOt.ToString(), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strAllowovertimeAmount, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    }


                    if (decPrevArrAmnt > 0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Arrear Amount", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strPrevArrAmnt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strPrevArrAmnt, FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
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

                    if (decPrevArrAmnt<0)
                    {
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                        sumtable.AddCell(new PdfPCell(new Phrase("Arrear Amount", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(strPrevArrAmnt.Replace("-", string.Empty), FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
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
                    sumtable.AddCell(new PdfPCell(new Phrase(strnetsalary + " " + dtSalPrssDtls.Rows[0]["CRNCMST_ABBRV"].ToString(), FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                    sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 9, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                    if (pos4 > 400)
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
                    endtable.AddCell(new PdfPCell(new Phrase("RECEIVER'S SIGNATURE", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                    endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });

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
                memoryStreamForZipFile = new MemoryStream(memoryStream.ToArray());
                memoryStreamForZipFile.Seek(0, SeekOrigin.Begin);
                zipFile.AddEntry(strImageName, memoryStreamForZipFile);
            }
            Response.Clear();
            Response.Buffer = false;
            Response.ContentType = "application/zip";

            Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "Paymentslip_" + OBJ.Month + "_" + OBJ.Year + ".zip"));

            zipFile.Save(Response.OutputStream);

            Response.End();
            ScriptManager.RegisterStartupScript(this, GetType(), "PrintClick", "PrintClick();", true);
        }
    }

    
#region Old
    //protected void btnDownloadAll_Click(object sender, EventArgs e)
    //{
    //    cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
    //    cls_Entity_Monthly_Salary_Process OBJ = new cls_Entity_Monthly_Salary_Process();
    //    clsBusinessLayer objBusiness = new clsBusinessLayer();
    //    clsEntityCommon objEntityCommon = new clsEntityCommon();

    //    int intCorpId = 0;
    //    if (Session["CORPOFFICEID"] != null)
    //    {
    //        intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

    //    }
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    if (Session["SALARPRSS_PAYMENT"] != null)
    //    {
    //        var strSALARPRSS = Session["SALARPRSS_PAYMENT"];
    //        string[] ProssId = strSALARPRSS.ToString().Split('~');
    //        int SaveOrConf = Convert.ToInt32(ProssId[0]);

    //        int CorpdepId = Convert.ToInt32(ProssId[1]);
    //        int staffWrk = Convert.ToInt32(ProssId[2]);
    //        DateTime ddat = objCommon.textToDateTime(ProssId[3]);
    //        OBJ.Month = Convert.ToInt32(ProssId[4]);

    //        OBJ.Year = Convert.ToInt32(ProssId[5]);
    //        OBJ.PaidFinish = SaveOrConf;
    //        OBJ.Dep = CorpdepId;
    //        OBJ.CorpOffice = intCorpId;
    //        OBJ.StffWrkr = staffWrk;
    //        OBJ.date = ddat;
    //        DataSet ds = new DataSet();
    //        DataTable dtSal = new DataTable();
    //        Stream memoryStreamForZipFile = null;
    //        ZipFile zipFile = new ZipFile();
    //        string[] EmpId = hiddenAllEmpid.Value.Split(',');
    //        dtSal = objBuss.LoadSalaryPrssPaymentTable(OBJ);

    //        for (int i = 0; i < dtSal.Rows.Count; i++)
    //        {
    //            int empid = Convert.ToInt32(dtSal.Rows[i]["USR_ID"]);
    //            string fileName = null;
    //            Document document = null;
    //            MemoryStream memoryStream = null;
    //            PdfWriter pdfWriter = null;


    //            memoryStream = new MemoryStream();

    //            document = new Document(PageSize.A4, 30, 30, 30, 30);
    //            pdfWriter = PdfWriter.GetInstance(document, memoryStream);
    //            pdfWriter.ViewerPreferences = PdfWriter.PageLayoutSinglePage;

    //            fileName = string.Format("Salary.pdf", i);
    //            string strImageName = "LabourCard_" + Convert.ToInt32(empid) + ".pdf";
    //            string imgpath = "/CustomFiles/PaySlip/";
    //            string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.PAYSLIP_PDF);
    //            document.Open();

    //            PdfPTable headtable = new PdfPTable(1);

    //            string strImageLoc = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CORPORATE_LOGOS) + "quotation-header.png";
    //            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLoc));
    //            image.ScalePercent(PdfPCell.ALIGN_CENTER);
    //            image.ScaleToFit(600f, 100f);

    //            headtable.AddCell(new PdfPCell(image) { Border = 0, PaddingBottom = 20, HorizontalAlignment = Element.ALIGN_CENTER, });
    //            document.Add(headtable);

    //            PdfPTable tableLayout = new PdfPTable(6);
    //            float[] headersBody = { 19, 19, 12, 17, 17, 16 };
    //            tableLayout.SetWidths(headersBody);
    //            tableLayout.WidthPercentage = 100;

    //            tableLayout.AddCell(new PdfPCell(new Phrase("Date", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 8 });
    //            tableLayout.AddCell(new PdfPCell(new Phrase("Job #", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 8 });
    //            tableLayout.AddCell(new PdfPCell(new Phrase("Status", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 8 });
    //            tableLayout.AddCell(new PdfPCell(new Phrase("Normal Hrs", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 8 });
    //            tableLayout.AddCell(new PdfPCell(new Phrase("Normal OT", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 8 });
    //            tableLayout.AddCell(new PdfPCell(new Phrase("Holiday OT", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 8 });

    //            int numMonth = DateTime.DaysInMonth(OBJ.Year, OBJ.Month);

    //            string MonthName = "";

    //            int NormlOT = 0, HoldayOt = 0;
    //            decimal NormalOvertmRatePrHr = 0, HolidayOvertmRatePrHr = 0;

    //            for (int intRowBodyCount = 1; intRowBodyCount <= numMonth; intRowBodyCount++)
    //            {
    //                string EmDate = new DateTime(OBJ.Year, OBJ.Month, intRowBodyCount).ToString("dd-MM-yyyy");
    //                DateTime ddate = objCommon.textToDateTime(EmDate);

    //                OBJ.date = ddate;
    //                MonthName = ddate.ToString("MMMM");
    //                OBJ.Employee = empid;
    //                OBJ.Month = OBJ.Month;
    //                OBJ.Year = OBJ.Year;
    //                DataTable dtEmp_list = objBuss.ReadEmp_List_For_Print(OBJ);

    //                tableLayout.AddCell(new PdfPCell(new Phrase(ddate.ToString("dd-MMMM-yyyy"), FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 });
    //                if (dtEmp_list.Rows.Count > 0)
    //                {

    //                    tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["JOBMSTR_TITLE"].ToString(), FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 });
    //                    tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["ATTENDANCE"].ToString(), FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 });
    //                    if (dtEmp_list.Rows[0]["ATTENDANCE"].ToString() == "P")
    //                    {
    //                        tableLayout.AddCell(new PdfPCell(new Phrase("8", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, });
    //                    }
    //                    else if (dtEmp_list.Rows[0]["ATTENDANCE"].ToString() == "A")
    //                    {
    //                        tableLayout.AddCell(new PdfPCell(new Phrase("0", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, });
    //                    }
    //                    foreach (DataRow row in dtEmp_list.Rows)
    //                    {

    //                        if (row["OVRTMCATG_NAME"].ToString() == "NORMAL OT")
    //                        {
    //                            tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString(), FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 });
    //                            NormlOT += Convert.ToInt32(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString());
    //                            NormalOvertmRatePrHr = Convert.ToDecimal(row["OVRTMCATG_RATE"].ToString());
    //                        }
    //                        else
    //                        {
    //                            tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 });
    //                        }
    //                        if (row["OVRTMCATG_NAME"].ToString() == "HOLIDAY OT")
    //                        {
    //                            tableLayout.AddCell(new PdfPCell(new Phrase(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString(), FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 });
    //                            HoldayOt += Convert.ToInt32(dtEmp_list.Rows[0]["EMDLHRDTL_OT"].ToString());
    //                            HolidayOvertmRatePrHr = Convert.ToDecimal(row["OVRTMCATG_RATE"].ToString());
    //                        }
    //                        else
    //                        {
    //                            tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 });
    //                        }
    //                    }
    //                }
    //                else
    //                {
    //                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 });
    //                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 });
    //                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 });
    //                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 });
    //                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 });
    //                }
    //            }
    //            tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 4 });
    //            tableLayout.AddCell(new PdfPCell(new Phrase(NormlOT.ToString(), FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER });
    //            tableLayout.AddCell(new PdfPCell(new Phrase(HoldayOt.ToString(), FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER });

    //            PdfPTable headLayout = new PdfPTable(1);
    //            headLayout.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
    //            headLayout.AddCell(new PdfPCell(new Phrase("Labor Card For " + MonthName + "-" + OBJ.Year, FontFactory.GetFont("Times New Roman", 14, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
    //            headLayout.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Times New Roman", 25, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
    //            document.Add(headLayout);

    //            PdfPTable tableheadlayout = new PdfPTable(5);
    //            float[] tableheadlayoutBody = { 14, 25, 27, 10, 24 };
    //            tableheadlayout.SetWidths(tableheadlayoutBody);
    //            tableheadlayout.WidthPercentage = 100;

    //            string RowCount = HiddenRowCount.Value;

    //            tableheadlayout.AddCell(new PdfPCell(new Phrase("Employee", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 7 });

    //            string Employee = dtSal.Rows[i]["EID"].ToString() + "~" + dtSal.Rows[i]["EMPLOYEE"].ToString() + "~" + dtSal.Rows[i]["CORPRT_NAME"].ToString() + "~" + dtSal.Rows[i]["DESIGNATION"].ToString();
    //            string[] Emp = Employee.ToString().Split('~');

    //            tableheadlayout.AddCell(new PdfPCell(new Phrase(Emp[0], FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7 });
    //            tableheadlayout.AddCell(new PdfPCell(new Phrase(Emp[1], FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7 });
    //            tableheadlayout.AddCell(new PdfPCell(new Phrase("Trade", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 7 });
    //            tableheadlayout.AddCell(new PdfPCell(new Phrase(Emp[3], FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7 });
    //            document.Add(tableheadlayout);

    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 25, BaseColor.BLACK))));

    //            document.Add(tableLayout);

    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 25, BaseColor.BLACK))));



    //            cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
    //            objEnt.Employee = empid;
    //            objEnt.Month = OBJ.Month;
    //            objEnt.Year = OBJ.Year;
    //            DataTable dtSalPrssDtls;
    //            dtSalPrssDtls = objBuss.ReadSalaryProssDtlsById(objEnt);
    //            string basicAmt = "", AllowaceAmt = "", AllowovertimeAmount = "", DedctionAmt = "", DedctionInstalmntAmnt = "", Total = "", OT_Hours = "";
    //            Decimal TotalBasicAllow = 0, TotalDedctn = 0, netsalary = 0, AllowovertimeAmount1 = 0, AllowaceAmt1 = 0, basicAmt1 = 0, instlmntDedctionAmt = 0, deductnamt = 0;
    //            if (dtSalPrssDtls.Rows.Count > 0)
    //            {
    //                basicAmt = dtSalPrssDtls.Rows[0]["SLRY_BASIC_PAY"].ToString();
    //                AllowaceAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_ALLOW_AMT"].ToString();
    //                AllowovertimeAmount = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_OVERTIME_ALLOW_AMT"].ToString();
    //                DedctionAmt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_SPECIAL_DEDCTN_AMT"].ToString();
    //                DedctionInstalmntAmnt = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_INSTLMNT_DEDCN_AMT"].ToString();
    //                Total = dtSalPrssDtls.Rows[0]["SLPRCDMNTH_TOTAL_AMT"].ToString();
    //                if (dtSalPrssDtls.Rows[0]["SLPRCDMNTH_TOTAL_AMT"].ToString() != "")
    //                {
    //                    OT_Hours = dtSalPrssDtls.Rows[0]["EMDLHRDTL_OT"].ToString();
    //                }
    //            }
    //            if (basicAmt != "")
    //            {
    //                basicAmt1 = Convert.ToDecimal(basicAmt);
    //                TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(basicAmt);
    //            }
    //            if (AllowaceAmt != "")
    //            {
    //                AllowaceAmt1 = Convert.ToDecimal(AllowaceAmt);
    //                TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(AllowaceAmt);
    //            }
    //            if (AllowovertimeAmount != "")
    //            {
    //                AllowovertimeAmount1 = Convert.ToDecimal(AllowovertimeAmount);
    //                TotalBasicAllow = TotalBasicAllow + Convert.ToDecimal(AllowovertimeAmount);
    //            }
    //            if (DedctionAmt != "")
    //            {
    //                deductnamt = Convert.ToDecimal(DedctionAmt);
    //                TotalDedctn = TotalDedctn + Convert.ToDecimal(DedctionAmt);
    //            }
    //            if (DedctionInstalmntAmnt != "")
    //            {
    //                instlmntDedctionAmt = Convert.ToDecimal(DedctionInstalmntAmnt);
    //                TotalDedctn = TotalDedctn + Convert.ToDecimal(DedctionInstalmntAmnt);
    //            }
    //            if (Total != "")
    //            {
    //                netsalary = Convert.ToDecimal(Total);
    //            }


    //            string strbasicAmt = objBusiness.AddCommasForNumberSeperation(basicAmt1.ToString("0.00"), objEntityCommon);
    //            string strAllowaceAmt = objBusiness.AddCommasForNumberSeperation(AllowaceAmt1.ToString("0.00"), objEntityCommon);
    //            string strAllowovertimeAmount = objBusiness.AddCommasForNumberSeperation(AllowovertimeAmount1.ToString("0.00"), objEntityCommon);
    //            string strTotalBasicAllow = objBusiness.AddCommasForNumberSeperation(TotalBasicAllow.ToString("0.00"), objEntityCommon);
    //            string strDeductnAmt = objBusiness.AddCommasForNumberSeperation(deductnamt.ToString("0.00"), objEntityCommon);
    //            string strDeductnInstlmtAmount = objBusiness.AddCommasForNumberSeperation(instlmntDedctionAmt.ToString("0.00"), objEntityCommon);
    //            string strTotalDedctn = objBusiness.AddCommasForNumberSeperation(TotalDedctn.ToString("0.00"), objEntityCommon);
    //            string strnetsalary = objBusiness.AddCommasForNumberSeperation(netsalary.ToString("0.00"), objEntityCommon);



    //            PdfPTable sumtable = new PdfPTable(6);
    //            float[] footrsBody = { 14, 28, 16, 13, 15, 14 };
    //            sumtable.SetWidths(footrsBody);
    //            sumtable.WidthPercentage = 100;

    //            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
    //            sumtable.AddCell(new PdfPCell(new Phrase("Basic and Allowances", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 8, BackgroundColor = BaseColor.LIGHT_GRAY, Colspan = 4 });
    //            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

    //            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
    //            sumtable.AddCell(new PdfPCell(new Phrase("Description", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 8 });
    //            sumtable.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 8 });
    //            sumtable.AddCell(new PdfPCell(new Phrase("Days/Hrs", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 8 });
    //            sumtable.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 8 });
    //            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

    //            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
    //            sumtable.AddCell(new PdfPCell(new Phrase("Basic Pay", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8 });
    //            sumtable.AddCell(new PdfPCell(new Phrase(strbasicAmt, FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8 });
    //            sumtable.AddCell(new PdfPCell(new Phrase(numMonth.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8 });
    //            sumtable.AddCell(new PdfPCell(new Phrase(strbasicAmt, FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8 });
    //            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

    //            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
    //            sumtable.AddCell(new PdfPCell(new Phrase("Special Allowance", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8 });
    //            sumtable.AddCell(new PdfPCell(new Phrase(strAllowaceAmt, FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8 });
    //            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8 });
    //            sumtable.AddCell(new PdfPCell(new Phrase(strAllowaceAmt, FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8 });
    //            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
    //            if (NormlOT != 0)
    //            {
    //                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
    //                sumtable.AddCell(new PdfPCell(new Phrase("Normal OT @" + NormalOvertmRatePrHr.ToString() + "/hr", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8, Colspan = 2 });
    //                sumtable.AddCell(new PdfPCell(new Phrase(NormlOT.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8 });
    //                sumtable.AddCell(new PdfPCell(new Phrase(strAllowovertimeAmount, FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8 });
    //                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8 });
    //            }
    //            if (HoldayOt != 0)
    //            {
    //                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
    //                sumtable.AddCell(new PdfPCell(new Phrase("Holiday OT @" + HolidayOvertmRatePrHr.ToString() + "/hr", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8, Colspan = 2 });
    //                sumtable.AddCell(new PdfPCell(new Phrase(HoldayOt.ToString(), FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8 });
    //                sumtable.AddCell(new PdfPCell(new Phrase(strAllowovertimeAmount, FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8 });
    //                sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8 });
    //            }
    //            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
    //            sumtable.AddCell(new PdfPCell(new Phrase("Total Basic and Allowances", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8, Colspan = 3 });
    //            sumtable.AddCell(new PdfPCell(new Phrase(strTotalBasicAllow, FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8 });
    //            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

    //            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
    //            sumtable.AddCell(new PdfPCell(new Phrase("Deductions", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 8, BackgroundColor = BaseColor.LIGHT_GRAY, Colspan = 4 });
    //            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

    //            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
    //            sumtable.AddCell(new PdfPCell(new Phrase("Deduction Types", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8, Colspan = 3, BackgroundColor = BaseColor.LIGHT_GRAY, });
    //            sumtable.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8, BackgroundColor = BaseColor.LIGHT_GRAY, });
    //            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

    //            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
    //            sumtable.AddCell(new PdfPCell(new Phrase("Special Deductions", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8, Colspan = 3 });
    //            sumtable.AddCell(new PdfPCell(new Phrase(strDeductnAmt, FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8 });
    //            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

    //            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
    //            sumtable.AddCell(new PdfPCell(new Phrase("Installment Deductions", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8, Colspan = 3 });
    //            sumtable.AddCell(new PdfPCell(new Phrase(strDeductnInstlmtAmount, FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8 });
    //            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

    //            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
    //            sumtable.AddCell(new PdfPCell(new Phrase("Total Deductions", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8, Colspan = 3 });
    //            sumtable.AddCell(new PdfPCell(new Phrase(strTotalDedctn, FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8 });
    //            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

    //            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
    //            sumtable.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 8, BackgroundColor = BaseColor.LIGHT_GRAY, Colspan = 4 });
    //            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

    //            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
    //            sumtable.AddCell(new PdfPCell(new Phrase("Net Salary", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 8, Colspan = 3 });
    //            sumtable.AddCell(new PdfPCell(new Phrase(strnetsalary, FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 8 });
    //            sumtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 11, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

    //            document.Add(sumtable);

    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 20, BaseColor.BLACK))));
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 20, BaseColor.BLACK))));
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 20, BaseColor.BLACK))));


    //            PdfPTable endtable = new PdfPTable(6);
    //            float[] endBody = { 25, 10, 25, 10, 25, 5 };
    //            endtable.SetWidths(endBody);
    //            endtable.WidthPercentage = 100;

    //            endtable.AddCell(new PdfPCell(new Phrase("Finance Manager", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
    //            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
    //            endtable.AddCell(new PdfPCell(new Phrase("General Manager", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
    //            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
    //            endtable.AddCell(new PdfPCell(new Phrase("Receiver signature", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
    //            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });

    //            document.Add(endtable);
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 40, BaseColor.BLACK))));
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 40, BaseColor.BLACK))));

    //            PdfPTable footrtable = new PdfPTable(2);
    //            float[] headersBodyfootr = { 0, 100 };
    //            footrtable.SetWidths(headersBodyfootr);
    //            footrtable.WidthPercentage = 100;

    //            string strImageLocFooter = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CORPORATE_LOGOS) + "quotation-footer.png";
    //            iTextSharp.text.Image imageFootr = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLocFooter));
    //            imageFootr.ScalePercent(PdfPCell.ALIGN_LEFT);
    //            imageFootr.ScaleToFit(520f, 60f);

    //            footrtable.AddCell(new PdfPCell(new Phrase(" ")) { Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_LEFT });
    //            footrtable.AddCell(new PdfPCell(imageFootr) { Border = 0, PaddingBottom = 10, HorizontalAlignment = Element.ALIGN_LEFT });
    //            document.Add(footrtable);
    //            document.Close();
    //            memoryStreamForZipFile = new MemoryStream(memoryStream.ToArray());
    //            memoryStreamForZipFile.Seek(0, SeekOrigin.Begin);
    //            zipFile.AddEntry(strImageName, memoryStreamForZipFile);

    //        }
    //        Response.Clear();
    //        Response.Buffer = false;
    //        Response.ContentType = "application/zip";

    //        Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "Paymentslip_" + OBJ.Month + "_" + OBJ.Year + ".zip"));

    //        zipFile.Save(Response.OutputStream);

    //        Response.End();
    //        ScriptManager.RegisterStartupScript(this, GetType(), "PrintClick", "PrintClick();", true);
    //    }
    //}
#endregion Old


}






