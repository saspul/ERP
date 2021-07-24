using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using CL_Compzit;
using BL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using System.Web.Services;
using Newtonsoft.Json;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using EL_Compzit;
using System.IO;
public partial class HCM_HCM_Reports_hcm_Employee_Details_Report_hcm_Employee_Details_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            DivisionLoad();
            PaygradeLoad();
            DepartmentLoad();
            DesignationLoad();
            CountryLoad();
            projectLoad();
            ReligionLoad();

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            int intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport = new clsEntityEmployeeDetailsReport();
            clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();



            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityEmployeeDetailsreport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                objEntityEmployeeDetailsreport.OrganisationId = Convert.ToInt32(Session["ORGID"].ToString());
                hiddenOrgId.Value = Session["ORGID"].ToString();
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                objEntityEmployeeDetailsreport.UserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            //objEntityEmployeeDetailsreport.StatusId = Convert.ToInt32(ddlStatus.SelectedItem.Value);
            objEntityEmployeeDetailsreport.StatusId = 1;



            //for printing table

            DataTable dtCorp = objBusinessEmployeeDetailsReport.ReadCorporateAddress(objEntityEmployeeDetailsreport);
            objEntityEmployeeDetailsreport.Corporate_id = 0;
            objEntityEmployeeDetailsreport.OrganisationId = 0;
            DataTable dtVisaQuota = new DataTable();
            //dtVisaQuota = objBusinessEmployeeDetailsReport.ReadEmployeeList(objEntityEmployeeDetailsreport);

          //  string strHtm = ConvertDataTableToHTML(dtVisaQuota);
        //   divReport.InnerHtml = strHtm;
            string strPrintReport = ConvertDataTableForPrint(dtVisaQuota, dtCorp);
            divPrintReport.InnerHtml = strPrintReport;

        }    //evm-0023
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Autocomplt", "Autocomplt();", true);
        }
    }
    public string ConvertDataTableToHTML(DataTable dt)
    {

        clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport = new clsEntityEmployeeDetailsReport();
        clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";

        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE NAME </th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">DESIGNATION</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";
            }

            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">DIVISION</th>";
            }
            if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">PAY GRADE</th>";
            }
        }

        strHtml += "<th class=\"thT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">MORE INFO</th>";


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            objEntityEmployeeDetailsreport.UserId = Convert.ToInt32(dt.Rows[intRowBodyCount]["USR_ID"]);
            DataTable dtDivisions = objBusinessEmployeeDetailsReport.ReadDivisionOfEmp(objEntityEmployeeDetailsreport);

            objEntityEmployeeDetailsreport.date = System.DateTime.Now;
            DataTable dtProject = objBusinessEmployeeDetailsReport.ReadProjectDetails(objEntityEmployeeDetailsreport);

            //DataTable dtLeave = objBusinessEmployeeDetailsReport.ReadLeave(objEntityEmployeeDetailsreport);
            //Start:-For Project Search
            string strShowPrjct = "false";
            if (dtProject.Rows.Count == 0 && ddlPrjct.SelectedItem.Value == "--SELECT--")
            {
                strShowPrjct = "true";
            }
            foreach (DataRow dtDiv in dtProject.Rows)
            {


                if (ddlPrjct.SelectedItem.Value != "--SELECT--")
                {
                    if (dtDiv["PROJECT_ID"].ToString() == ddlPrjct.SelectedItem.Value)
                    {
                        strShowPrjct = "true";
                    }
                }
                else
                {
                    strShowPrjct = "true";
                }

            }
            //End:-For Project Search



            //Start:-For Division Search
            string strShow = "false";
            string strDivisions = "";
            if (dtDivisions.Rows.Count == 0 && ddlDivsn.SelectedItem.Value == "--SELECT--")
            {
                strShow = "true";
            }
            foreach (DataRow dtDiv in dtDivisions.Rows)
            {
                if (strDivisions == "")
                {
                    strDivisions = dtDiv["CPRDIV_NAME"].ToString();
                }
                else
                {
                    strDivisions = strDivisions + "," + dtDiv["CPRDIV_NAME"];
                }

                if (ddlDivsn.SelectedItem.Value != "--SELECT--")
                {
                    if (dtDiv["CPRDIV_ID"].ToString() == ddlDivsn.SelectedItem.Value)
                    {
                        strShow = "true";
                    }
                }
                else
                {
                    strShow = "true";
                }

            }
            //End:-For Division Search



            //Start:-For Age Search EVM-0027
            Int64 Years=000;
            string strShowAge = "false";
            clsCommonLibrary commn = new clsCommonLibrary();

            if (dt.Rows[intRowBodyCount]["EMPERDTL_DOB"].ToString() != "")
            {

             string Dob1 =dt.Rows[intRowBodyCount]["EMPERDTL_DOB"].ToString();
             DateTime dob =   commn.textToDateTime(Dob1);
        
                if (dob <DateTime.Now)
                {

                  Years = new DateTime(DateTime.Now.Subtract(dob).Ticks).Year - 1;
                }

            }
            //END
            if (txtAgeFrom.Text != "" && txtAgeTo.Text != "")
            {
                if (Years >= Convert.ToInt32(txtAgeFrom.Text) && Years <= Convert.ToInt32(txtAgeTo.Text))
                {
                    strShowAge = "true";
                }
            }
            else if (txtAgeFrom.Text != "")
            {
                if (Years >= Convert.ToInt32(txtAgeFrom.Text))
                {
                    strShowAge = "true";
                }
            }
            else if (txtAgeTo.Text != "")
            {
                if (Years <= Convert.ToInt32(txtAgeTo.Text))
                {
                    strShowAge = "true";
                }
            }
            else
            {
                strShowAge = "true";
            }
            //End:-For Age Search


            //Start:-For Exp Years Search
            int ExpYears = 0;
            string strShowExp = "false";
            if (dt.Rows[intRowBodyCount]["EMPERDTL_JOIN_DATE"].ToString() != "")
            {
                DateTime Dob = commn.textToDateTime(dt.Rows[intRowBodyCount]["EMPERDTL_JOIN_DATE"].ToString());
              //  DateTime Dob = Convert.ToDateTime(dt.Rows[intRowBodyCount]["EMPERDTL_JOIN_DATE"].ToString());
                if (Dob < DateTime.Now)
                    ExpYears = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;

            }
            if (ddlNumYear.SelectedItem.Value == "1")
            {
                if (ExpYears >= 1)
                {
                    strShowExp = "true";
                }
            }
            else if (ddlNumYear.SelectedItem.Value == "2")
            {
                if (ExpYears >= 3)
                {
                    strShowExp = "true";
                }
            }
            else if (ddlNumYear.SelectedItem.Value == "3")
            {
                if (ExpYears >= 5)
                {
                    strShowExp = "true";
                }
            }
            else if (ddlNumYear.SelectedItem.Value == "4")
            {
                if (ExpYears >= 8)
                {
                    strShowExp = "true";
                }
            }
            else
            {
                strShowExp = "true";
            }
            //End:-For Exp Years Search



            if (strShow == "true" && strShowPrjct == "true" && strShowAge == "true" && strShowExp == "true")
            {

                strHtml += "<tr  >";

                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;



                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][3].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 2)
                    {
                        if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() != "")
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USRNAME"].ToString() + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][9].ToString() + "</td>";
                        }

                    }
                    if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DSGN_NAME"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CPRDEPT_NAME"].ToString() + "</td>";
                    }
                }
                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + strDivisions + "</td>";

                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][6].ToString().ToUpper() + "</td>";


                strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;padding-left: 0.5%;\"><input type=\"button\" class=\"save\" style=\"height:22px;margin-top:3%\" value=\"More Info\" onclick='return OpenCancelView(" + strId + ");' /></td>";

                strHtml += "</tr>";
            }
        }
        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }

    //It build the Html table by using the datatable provided
    public string ConvertDataTableForPrint(DataTable dt, DataTable dtCorp)
    {

        clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport = new clsEntityEmployeeDetailsReport();
        clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();

        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Employee Details Report";
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
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        string strCompanyAddr = objClsCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);

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
        string strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strUsrName + strCaptionTabTitle + strCaptionTabstop;

        sbCap.Append(strPrintCaptionTable);
        //write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:25%;text-align: left; word-wrap:break-word;\">EMPLOYEE</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:11%;text-align: left; word-wrap:break-word;\">EMPLOYEE NO</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">DESIGNATION</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";
            }

            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">DIVISION</th>";
            }
            if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">PAY GRADE</th>";
            }
        }
        if (dt.Columns.Count == 0)
        {
            strHtml += "<td class=\"thT\" style=\"width:25%;text-align: left; word-wrap:break-word;\">EMPLOYEE</th>";
            strHtml += "<td class=\"thT\" style=\"width:14%;text-align: center; word-wrap:break-word;\">EMPLOYEE NO</th>";
            strHtml += "<td class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">DESIGNATION</th>";
            strHtml += "<td class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">DEPARTMENT</th>";
            strHtml += "<td class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">DIVISION</th>";
            strHtml += "<td class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">PAY GRADE</th>";
        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            objEntityEmployeeDetailsreport.UserId = Convert.ToInt32(dt.Rows[intRowBodyCount]["USR_ID"]);
            DataTable dtDivisions = objBusinessEmployeeDetailsReport.ReadDivisionOfEmp(objEntityEmployeeDetailsreport);

            objEntityEmployeeDetailsreport.date = System.DateTime.Now;
            DataTable dtProject = objBusinessEmployeeDetailsReport.ReadProjectDetails(objEntityEmployeeDetailsreport);

            DataTable dtLeave = objBusinessEmployeeDetailsReport.ReadLeave(objEntityEmployeeDetailsreport);

            //Start:-For Project Search
            string strShowPrjct = "false";
            if (dtProject.Rows.Count == 0 && ddlPrjct.SelectedItem.Value == "--SELECT--")
            {
                strShowPrjct = "true";
            }
            foreach (DataRow dtDiv in dtProject.Rows)
            {


                if (ddlPrjct.SelectedItem.Value != "--SELECT--")
                {
                    if (dtDiv["PROJECT_ID"].ToString() == ddlPrjct.SelectedItem.Value)
                    {
                        strShowPrjct = "true";
                    }
                }
                else
                {
                    strShowPrjct = "true";
                }

            }
            //End:-For Project Search



            //Start:-For Division Search
            string strShow = "false";
            string strDivisions = "";
            if (dtDivisions.Rows.Count == 0 && ddlDivsn.SelectedItem.Value == "--SELECT--")
            {
                strShow = "true";
            }
            foreach (DataRow dtDiv in dtDivisions.Rows)
            {
                if (strDivisions == "")
                {
                    strDivisions = dtDiv["CPRDIV_NAME"].ToString();
                }
                else
                {
                    strDivisions = strDivisions + "," + dtDiv["CPRDIV_NAME"];
                }

                if (ddlDivsn.SelectedItem.Value != "--SELECT--")
                {
                    if (dtDiv["CPRDIV_ID"].ToString() == ddlDivsn.SelectedItem.Value)
                    {
                        strShow = "true";
                    }
                }
                else
                {
                    strShow = "true";
                }

            }
            //End:-For Division Search



            //Start:-For Age Search
            //int Years = 0;
            //string strShowAge = "false";
            //if (dt.Rows[intRowBodyCount]["EMPERDTL_DOB"].ToString() != "")
            //{

            //    DateTime Dob = Convert.ToDateTime(dt.Rows[intRowBodyCount]["EMPERDTL_DOB"].ToString());
            //    Years = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;

            //}


            //EVM-0027
            //Start:-For Age Search EVM-0027
            Int64 Years = 000;
            string strShowAge = "false";
            clsCommonLibrary commn = new clsCommonLibrary();

            if (dt.Rows[intRowBodyCount]["EMPERDTL_DOB"].ToString() != "")
            {

                string Dob1 = dt.Rows[intRowBodyCount]["EMPERDTL_DOB"].ToString();
                DateTime dob = commn.textToDateTime(Dob1);
                //string strCurrentDate = (DateTime.Now).ToString();
                //DateTime dtCurrentDate = commn.textToDateTime(strCurrentDate);
                if (dob < DateTime.Now)
                {

                    Years = new DateTime(DateTime.Now.Subtract(dob).Ticks).Year - 1;
                }

            }
            //END

            //END



            if (txtAgeFrom.Text != "" && txtAgeTo.Text != "")
            {
                if (Years >= Convert.ToInt32(txtAgeFrom.Text) && Years <= Convert.ToInt32(txtAgeTo.Text))
                {
                    strShowAge = "true";
                }
            }
            else if (txtAgeFrom.Text != "")
            {
                if (Years >= Convert.ToInt32(txtAgeFrom.Text))
                {
                    strShowAge = "true";
                }
            }
            else if (txtAgeTo.Text != "")
            {
                if (Years <= Convert.ToInt32(txtAgeTo.Text))
                {
                    strShowAge = "true";
                }
            }
            else
            {
                strShowAge = "true";
            }
            //End:-For Age Search


            //Start:-For Exp Years Search
            int ExpYears = 0;
            string strShowExp = "false";
            //if (dt.Rows[intRowBodyCount]["EMPERDTL_JOIN_DATE"].ToString() != "" && dt.Rows[intRowBodyCount]["EMPERDTL_JOIN_DATE"].ToString() !=null)
            //{

            //    DateTime Dob = Convert.ToDateTime(dt.Rows[intRowBodyCount]["EMPERDTL_JOIN_DATE"].ToString());
            //    if (Dob < DateTime.Now)
            //        ExpYears = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;

            //}


            if (dt.Rows[intRowBodyCount]["EMPERDTL_JOIN_DATE"].ToString() != "")
            {

                string Dob1 = dt.Rows[intRowBodyCount]["EMPERDTL_JOIN_DATE"].ToString();
                DateTime dob = commn.textToDateTime(Dob1);
                //string strCurrentDate = (DateTime.Now).ToString();
                //DateTime dtCurrentDate = commn.textToDateTime(strCurrentDate);
                if (dob < DateTime.Now)
                {
                    Years = new DateTime(DateTime.Now.Subtract(dob).Ticks).Year - 1;
                }

            }
            if (ddlNumYear.SelectedItem.Value == "1")
            {
                if (ExpYears >= 1)
                {
                    strShowExp = "true";
                }
            }
            else if (ddlNumYear.SelectedItem.Value == "2")
            {
                if (ExpYears >= 3)
                {
                    strShowExp = "true";
                }
            }
            else if (ddlNumYear.SelectedItem.Value == "3")
            {
                if (ExpYears >= 5)
                {
                    strShowExp = "true";
                }
            }
            else if (ddlNumYear.SelectedItem.Value == "4")
            {
                if (ExpYears >= 8)
                {
                    strShowExp = "true";
                }
            }
            else
            {
                strShowExp = "true";
            }
            //End:-For Exp Years Search



            //Start:-For Leave Search
            string strShowLeave = "false";
            if (ddlStatus.SelectedItem.Value == "1")
            {
                if (dtLeave.Rows.Count != 0)
                {
                    strShowLeave = "true";
                }
            }
            else
            {
                strShowLeave = "true";
            }
            //End:-For Leave Search



            if (strShow == "true" && strShowPrjct == "true" && strShowAge == "true" && strShowExp == "true" && strShowLeave == "true")
            {

                strHtml += "<tr  >";


                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {


                    if (intColumnBodyCount == 1)
                    {
                        if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() != "")
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][9].ToString() + "</td>";
                        }
                    }
                    if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                }

                objEntityEmployeeDetailsreport.UserId = Convert.ToInt32(dt.Rows[intRowBodyCount]["USR_ID"]);

                foreach (DataRow dtDiv in dtDivisions.Rows)
                {
                    if (strDivisions == "")
                    {
                        strDivisions = dtDiv["CPRDIV_NAME"].ToString();
                    }
                    else
                    {
                        strDivisions = strDivisions + "," + dtDiv["CPRDIV_NAME"];
                    }
                }

                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + strDivisions + "</td>";

                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][6].ToString().ToUpper() + "</td>";

                strHtml += "</tr>";
            }
        }


        if (dt.Rows.Count == 0)
        {
            strHtml += "<td  class=\"thT\" colspan=\"8\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport = new clsEntityEmployeeDetailsReport();
        clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEmployeeDetailsreport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityEmployeeDetailsreport.OrganisationId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityEmployeeDetailsreport.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        if (ddlDesgntn.SelectedItem.Value != "--SELECT--")
        {
            objEntityEmployeeDetailsreport.DesignationId = Convert.ToInt32(ddlDesgntn.SelectedItem.Value);
        }
        if (ddlDeptmnt.SelectedItem.Value != "--SELECT--")
        {
            objEntityEmployeeDetailsreport.DepartmentId = Convert.ToInt32(ddlDeptmnt.SelectedItem.Value);
        }
        if (ddlDivsn.SelectedItem.Value != "--SELECT--")
        {
            objEntityEmployeeDetailsreport.DivisionId = Convert.ToInt32(ddlDivsn.SelectedItem.Value);
        }
        if (ddlGrade.SelectedItem.Value != "--SELECT--")
        {
            objEntityEmployeeDetailsreport.GradeId = Convert.ToInt32(ddlGrade.SelectedItem.Value);
        }
        if (ddlPrjct.SelectedItem.Value != "--SELECT--")
        {
            objEntityEmployeeDetailsreport.ProjectId = Convert.ToInt32(ddlPrjct.SelectedItem.Value);
        }
        //objEntityEmployeeDetailsreport.StatusId = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        if (ddlStatus.SelectedItem.Value == "0")
        {
            objEntityEmployeeDetailsreport.StatusId = 1;
        }
        if (ddlStatus.SelectedItem.Value == "1")
        {
            objEntityEmployeeDetailsreport.StatusId = 2;
        }
        if (ddlStatus.SelectedItem.Value == "2")
        {
            objEntityEmployeeDetailsreport.StatusId = 3;
        }
        if (ddlStatus.SelectedItem.Value == "3")
        {
            objEntityEmployeeDetailsreport.StatusId = 0;
        }
        if (ddlNation.SelectedItem.Value != "--SELECT--")
        {
            objEntityEmployeeDetailsreport.NationalityId = Convert.ToInt32(ddlNation.SelectedItem.Value);
        }
        if (ddlRelgn.SelectedItem.Value != "--SELECT--")
        {
            objEntityEmployeeDetailsreport.ReligionId = Convert.ToInt32(ddlRelgn.SelectedItem.Value);
        }

        objEntityEmployeeDetailsreport.GenderId = Convert.ToInt32(ddlGender.SelectedItem.Value);


        if (ddlNumYear.SelectedItem.Value != "--SELECT--")
        {
            objEntityEmployeeDetailsreport.NumOfYears = Convert.ToInt32(ddlNumYear.SelectedItem.Value);
        }
        if (txtAgeFrom.Text != "")
        {
            objEntityEmployeeDetailsreport.AgeFrom = Convert.ToInt32(txtAgeFrom.Text);
        }
        if (txtAgeTo.Text != "")
        {
            objEntityEmployeeDetailsreport.AgeTo = Convert.ToInt32(txtAgeTo.Text);
        }

        DataTable dtVisaQuota = new DataTable();
       // dtVisaQuota = objBusinessEmployeeDetailsReport.ReadEmployeeList(objEntityEmployeeDetailsreport);

       // string strHtm = ConvertDataTableToHTML(dtVisaQuota);
        //  divReport.InnerHtml = strHtm;


        //for printing table

        DataTable dtCorp = objBusinessEmployeeDetailsReport.ReadCorporateAddress(objEntityEmployeeDetailsreport);
        string strPrintReport = ConvertDataTableForPrint(dtVisaQuota, dtCorp);
        divPrintReport.InnerHtml = strPrintReport;
    }
    [WebMethod]
    public static string[] EmployeeDetails(int intCorpId, int intOrgId, int intUserId)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();

        string[] strJson = new string[20];

        clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport = new clsEntityEmployeeDetailsReport();
        clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();

        objEntityEmployeeDetailsreport.UserId = intUserId;
        objEntityEmployeeDetailsreport.Corporate_id = intCorpId;
        objEntityEmployeeDetailsreport.OrganisationId = intOrgId;


        DataTable dtVisaBundleDtls = new DataTable();
        dtVisaBundleDtls = objBusinessEmployeeDetailsReport.ReadEmpDetailsById(objEntityEmployeeDetailsreport);
        if (dtVisaBundleDtls.Rows[0]["EMPERDTL_FNAME"].ToString() != "")
        {
            strJson[0] = dtVisaBundleDtls.Rows[0]["EMPERDTL_FNAME"].ToString() + " " + dtVisaBundleDtls.Rows[0]["EMPERDTL_MNAME"].ToString() + " " + dtVisaBundleDtls.Rows[0]["EMPERDTL_LNAME"].ToString();
        }
        else
        {
            strJson[0] = dtVisaBundleDtls.Rows[0]["USR_NAME"].ToString();
        }

        //if (dtVisaBundleDtls.Rows[0]["EMPERDTL_FNAME"].ToString() != "")
        //{
        //    strEmpName = dtVisaBundleDtls.Rows[0]["EMPERDTL_FNAME"].ToString() + " " + dtVisaBundleDtls.Rows[0]["EMPERDTL_MNAME"].ToString() + " " + dtVisaBundleDtls.Rows[0]["EMPERDTL_LNAME"].ToString();
        //}
        //else
        //{
        //    strEmpName = dtVisaBundleDtls.Rows[0]["USR_NAME"].ToString();
        //}
        strJson[1] = dtVisaBundleDtls.Rows[0]["DSGN_NAME"].ToString();
        strJson[2] = dtVisaBundleDtls.Rows[0]["CPRDEPT_NAME"].ToString();
        DataTable dtDivisions = objBusinessEmployeeDetailsReport.ReadDivisionOfEmp(objEntityEmployeeDetailsreport);
        string strDivisions = "";
        foreach (DataRow dtDiv in dtDivisions.Rows)
        {
            if (strDivisions == "")
            {
                strDivisions = dtDiv["CPRDIV_NAME"].ToString();
            }
            else
            {
                strDivisions = strDivisions + "," + dtDiv["CPRDIV_NAME"];
            }
        }
        strJson[3] = strDivisions;
        strJson[4] = dtVisaBundleDtls.Rows[0]["PYGRD_NAME"].ToString().ToUpper();
        objEntityEmployeeDetailsreport.date = System.DateTime.Now;
        DataTable dtProject = objBusinessEmployeeDetailsReport.ReadProjectDetails(objEntityEmployeeDetailsreport);
        string strProjectsAsgn = "";
        foreach (DataRow dtDiv in dtProject.Rows)
        {
            if (strProjectsAsgn == "")
            {
                strProjectsAsgn = dtDiv["PROJECT_NAME"].ToString();
            }
            else
            {
                strProjectsAsgn = strProjectsAsgn + "," + dtDiv["PROJECT_NAME"];
            }
        }
        strJson[5] = strProjectsAsgn;

        strJson[6] = dtVisaBundleDtls.Rows[0]["CNTRY_NAME"].ToString();
        strJson[7] = dtVisaBundleDtls.Rows[0]["RELIGION_NAME"].ToString();
        strJson[8] = dtVisaBundleDtls.Rows[0]["GENDER"].ToString();
        //EVM-0027
        if (dtVisaBundleDtls.Rows[0]["EMPERDTL_DOB"].ToString() != "")
        {
            DateTime Dob = objCommon.textToDateTime(dtVisaBundleDtls.Rows[0]["EMPERDTL_DOB"].ToString());
            Int64 Years=000;

            if (Dob < DateTime.Now)
            {

                Years = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
            }

            strJson[9] = Years.ToString();
        }
     
        //END

        
        if (dtVisaBundleDtls.Rows[0]["USR_STATUS"].ToString() == "0" || dtVisaBundleDtls.Rows[0]["RSGN_STS"].ToString() == "1")
        {

            strJson[10] = "INACTIVE";

        }
        else
        {
            strJson[10] = "ACTIVE";
        }
        
        //EVM-0027

        if (dtVisaBundleDtls.Rows[0]["EMPERDTL_JOIN_DATE"].ToString() != "")
        {
            DateTime Dob = objCommon.textToDateTime(dtVisaBundleDtls.Rows[0]["EMPERDTL_JOIN_DATE"].ToString());
            Int64 Years = 000;

            if (Dob < DateTime.Now)
            {
                Years = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
            }

            strJson[11] = Years.ToString();
        }
     
        //END
        //if (dtVisaBundleDtls.Rows[0]["EMPERDTL_JOIN_DATE"].ToString() != "")
        //{
        //    DateTime Doj = Convert.ToDateTime(dtVisaBundleDtls.Rows[0]["EMPERDTL_JOIN_DATE"].ToString());
        //    int WrkYears = new DateTime(DateTime.Now.Subtract(Doj).Ticks).Year - 1;
        //    strJson[11] = WrkYears.ToString() + " Years";
        //}
        //for printing the detail table

        DataTable dtCorp = objBusinessEmployeeDetailsReport.ReadCorporateAddress(objEntityEmployeeDetailsreport);
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Employee Details Report";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        if (dtCorp.Rows.Count > 0)
        {
            strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
            strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
            strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
            strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
            strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
        }
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        string strCompanyAddr = objClsCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);

        StringBuilder sbCap = new StringBuilder();

        string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr + "</td></tr>";
        string strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        string strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strCaptionTabTitle + strCaptionTabstop;

        sbCap.Append(strPrintCaptionTable);
        //write to  divPrintCaption
        strJson[12] = sbCap.ToString();




        string strEmpName = "", strDesg = "", strDept = "", strDivsn = "", strGrade = "", strPrjct = "", strNation = "",
               strRelgn = "", strGender = "", strAge = "", strNoYear = "", strWrkSts = "";

        StringBuilder sbBndlDtls = new StringBuilder();

        if (dtVisaBundleDtls.Rows[0]["EMPERDTL_FNAME"].ToString() != "")
        {
            strEmpName = dtVisaBundleDtls.Rows[0]["EMPERDTL_FNAME"].ToString() + " " + dtVisaBundleDtls.Rows[0]["EMPERDTL_MNAME"].ToString() + " " + dtVisaBundleDtls.Rows[0]["EMPERDTL_LNAME"].ToString();
        }
        else
        {
            strEmpName = dtVisaBundleDtls.Rows[0]["USR_NAME"].ToString();
        }


        strDesg = dtVisaBundleDtls.Rows[0]["DSGN_NAME"].ToString();
        strDept = dtVisaBundleDtls.Rows[0]["CPRDEPT_NAME"].ToString();
        strDivsn = strDivisions;
        strGrade = dtVisaBundleDtls.Rows[0]["PYGRD_NAME"].ToString();
        objEntityEmployeeDetailsreport.date = System.DateTime.Now;

        strPrjct = strProjectsAsgn;

        strNation = dtVisaBundleDtls.Rows[0]["CNTRY_NAME"].ToString();
        strRelgn = dtVisaBundleDtls.Rows[0]["RELIGION_NAME"].ToString();
        strGender = dtVisaBundleDtls.Rows[0]["GENDER"].ToString();




        if (dtVisaBundleDtls.Rows[0]["EMPERDTL_DOB"].ToString() != "")
        {
            Int64 Years = 000;
            DateTime Dob = objCommon.textToDateTime(dtVisaBundleDtls.Rows[0]["EMPERDTL_DOB"].ToString());
            if (Dob < DateTime.Now)
            Years = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
            strAge = Years.ToString();
        }

        if (dtVisaBundleDtls.Rows[0]["USR_STATUS"].ToString() == "0" || dtVisaBundleDtls.Rows[0]["RSGN_STS"].ToString() == "1")
        //if (dtVisaBundleDtls.Rows[0]["EMPERDTL_STATUS"].ToString() == "0" )//|| dtVisaBundleDtls.Rows[0]["RSGN_STS"].ToString() == "1")
        {
            {
                strWrkSts = "INACTIVE";
            }
        }
        else
        {
            strWrkSts = "ACTIVE";
        }
        if (dtVisaBundleDtls.Rows[0]["EMPERDTL_JOIN_DATE"].ToString() != "")
        {
            Int64 WrkYears = 000;
            DateTime Doj = objCommon.textToDateTime(dtVisaBundleDtls.Rows[0]["EMPERDTL_JOIN_DATE"].ToString());
            if (Doj < DateTime.Now)
            WrkYears = new DateTime(DateTime.Now.Subtract(Doj).Ticks).Year - 1;
            strNoYear = WrkYears.ToString() + " Years";
        }





        string strbrk = "<br/>";
        string strBundleTbl = "<table>";
        string strEmployee = "<tr><td><b>EMPLOYEE : " + strEmpName + "</b></td></tr>";
        string strDesgntn = "<tr><td><b>DESIGNATION : " + strDesg + "</b></td></tr>";
        string strDepartmnt = "<tr><td><b>DEPARTMENT : " + strDept + "</b></td></tr>";
        string strDivisionsp = "<tr><td><b>DIVISION : " + strDivsn + "</b></td></tr>";
        string strPayGrade = "<tr><td><b>PAY GRADE : " + strGrade + "</b></td></tr>";
        string strProjects = "<tr><td><b>PROJECT : " + strPrjct + "</b></td></tr>";
        string strCountry = "<tr><td><b>NATIONALITY : " + strNation + "</b></td></tr>";
        string strReligion = "<tr><td><b>RELIGION : " + strRelgn + "</b></td></tr>";
        string strGenderP = "<tr><td><b>GENDER : " + strGender + "</b></td></tr>";
        string strAgeP = "<tr><td><b>AGE : " + strAge + "</b></td></tr>";
        string strWorkStatus = "<tr><td><b>WORKING STATUS : " + strWrkSts + "</b></td></tr>";
        string strNumberYears = "<tr><td><b>NUMBER OF YEARS AT AL-BALAGH : " + strNoYear + "</b></td></tr>";
        string strBndlTblCls = "</table>";
        string strPrintBndlTable = strbrk + strBundleTbl + strEmployee + strDesgntn + strDepartmnt + strDivisionsp + strPayGrade
                                  + strProjects + strCountry + strReligion + strGenderP + strAgeP + strWorkStatus + strNumberYears + strBndlTblCls + strbrk;
        sbBndlDtls.Append(strPrintBndlTable);
        //write to  divPrintCaption
        strJson[13] = sbBndlDtls.ToString();



        return strJson;

    }

    public void DivisionLoad()
    {
        clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport = new clsEntityEmployeeDetailsReport();
        clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();

        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEmployeeDetailsreport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityEmployeeDetailsreport.OrganisationId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityEmployeeDetailsreport.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtDivision = objBusinessEmployeeDetailsReport.ReadDivision(objEntityEmployeeDetailsreport);
        if (dtDivision.Rows.Count > 0)
        {
            ddlDivsn.Items.Clear();
            ddlDivsn.DataSource = dtDivision;


            ddlDivsn.DataValueField = "CPRDIV_ID";
            ddlDivsn.DataTextField = "CPRDIV_NAME";



            //ddlProjct.DataValueField = "PROJECT_ID";
            ddlDivsn.DataBind();

        }
        ddlDivsn.Items.Insert(0, "--SELECT--");

    }
    public void CountryLoad()
    {
        clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();
        DataTable dtCountry = objBusinessEmployeeDetailsReport.readCountry();
        if (dtCountry.Rows.Count > 0)
        {
            ddlNation.Items.Clear();
            ddlNation.DataSource = dtCountry;


            ddlNation.DataValueField = "CNTRY_ID";
            ddlNation.DataTextField = "CNTRY_NAME";



            //ddlProjct.DataValueField = "PROJECT_ID";
            ddlNation.DataBind();

        }
        ddlNation.Items.Insert(0, "--SELECT--");
    }
    public void projectLoad()
    {
        clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport = new clsEntityEmployeeDetailsReport();
        clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();

        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEmployeeDetailsreport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityEmployeeDetailsreport.OrganisationId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityEmployeeDetailsreport.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int divid = 0;
        objEntityEmployeeDetailsreport.DivisionId = divid;
        DataTable dtProject = objBusinessEmployeeDetailsReport.ReadProject(objEntityEmployeeDetailsreport);
        if (dtProject.Rows.Count > 0)
        {
            ddlPrjct.DataSource = dtProject;


            ddlPrjct.DataValueField = "PROJECT_ID";
            ddlPrjct.DataTextField = "PROJECT_NAME";

            //  ddlprojectassign.DataValueField = "PROJECT_ID";


            //     ddlProjct.DataValueField = "PROJECT_ID";
            ddlPrjct.DataBind();

        }
        //    ddlprojectassign.Items.Insert(0, "--SELECT PROJECT--");
        ddlPrjct.Items.Insert(0, "--SELECT--");


    }

    public void DesignationLoad()
    {
        clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport = new clsEntityEmployeeDetailsReport();
        clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEmployeeDetailsreport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityEmployeeDetailsreport.OrganisationId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityEmployeeDetailsreport.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtdesig = objBusinessEmployeeDetailsReport.ReadDesignation(objEntityEmployeeDetailsreport);
        if (dtdesig.Rows.Count > 0)
        {
            ddlDesgntn.DataSource = dtdesig;


            ddlDesgntn.DataValueField = "DSGN_ID";
            ddlDesgntn.DataTextField = "DSGN_NAME";



            //ddlProjct.DataValueField = "PROJECT_ID";
            ddlDesgntn.DataBind();

        }
        ddlDesgntn.Items.Insert(0, "--SELECT--");

    }

    public void DepartmentLoad()
    {
        clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport = new clsEntityEmployeeDetailsReport();
        clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEmployeeDetailsreport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityEmployeeDetailsreport.OrganisationId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityEmployeeDetailsreport.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtdepartment = objBusinessEmployeeDetailsReport.ReadDepartment(objEntityEmployeeDetailsreport);
        if (dtdepartment.Rows.Count > 0)
        {
            ddlDeptmnt.DataSource = dtdepartment;
            ddlDeptmnt.Items.Clear();

            ddlDeptmnt.DataValueField = "CPRDEPT_ID";
            ddlDeptmnt.DataTextField = "CPRDEPT_NAME";



            //ddlProjct.DataValueField = "PROJECT_ID";
            ddlDeptmnt.DataBind();

        }
        ddlDeptmnt.Items.Insert(0, "--SELECT--");

    }
    public void PaygradeLoad()
    {
        clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport = new clsEntityEmployeeDetailsReport();
        clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEmployeeDetailsreport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityEmployeeDetailsreport.OrganisationId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityEmployeeDetailsreport.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtdepartment = objBusinessEmployeeDetailsReport.ReadPaygrade(objEntityEmployeeDetailsreport);
        if (dtdepartment.Rows.Count > 0)
        {
            ddlGrade.DataSource = dtdepartment;
            ddlGrade.Items.Clear();

            ddlGrade.DataValueField = "PYGRD_ID";
            ddlGrade.DataTextField = "PYGRD_NAME";



            //ddlProjct.DataValueField = "PROJECT_ID";
            ddlGrade.DataBind();

        }
        ddlGrade.Items.Insert(0, "--SELECT--");

    }
    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport = new clsEntityEmployeeDetailsReport();
        clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();

        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEmployeeDetailsreport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityEmployeeDetailsreport.OrganisationId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityEmployeeDetailsreport.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (ddlDivsn.SelectedItem.Text == "--SELECT--")
        {
            objEntityEmployeeDetailsreport.DivisionId = 0;
        }
        else
        {

            objEntityEmployeeDetailsreport.DivisionId = Convert.ToInt32(ddlDivsn.SelectedValue);
        }
        ddlPrjct.Items.Clear();
        DataTable dtProject = objBusinessEmployeeDetailsReport.ReadProject(objEntityEmployeeDetailsreport);
        if (dtProject.Rows.Count > 0)
        {
            ddlPrjct.DataSource = dtProject;
            ddlPrjct.DataValueField = "PROJECT_ID";
            ddlPrjct.DataTextField = "PROJECT_NAME";
            ddlPrjct.DataBind();

        }

        ddlPrjct.Items.Insert(0, "--SELECT--");
        ScriptManager.RegisterStartupScript(this, GetType(), "Autocomplt", "Autocomplt();", true);
    }
    public void ReligionLoad()
    {
        clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();
        DataTable dtCountry = objBusinessEmployeeDetailsReport.readReligion();
        if (dtCountry.Rows.Count > 0)
        {
            ddlRelgn.Items.Clear();
            ddlRelgn.DataSource = dtCountry;
            ddlRelgn.DataValueField = "RELIGION_ID";
            ddlRelgn.DataTextField = "RELIGION_NAME";
            ddlRelgn.DataBind();

        }
        ddlRelgn.Items.Insert(0, "--SELECT--");
    }
    protected void BtnCSV_Click(object sender, EventArgs e)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dt = GetTable();
        string strImagePath = "";
        string filepath = "";
        string strResult = DataTableToCSV(dt, ',');
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
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.EMPLOYEE_DETAILS_CSV);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
            string newFilePath = Server.MapPath("/CustomFiles/HCM CSV/Employee Details/Employee_Details_Report_" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "Employee_Details_Report_" + strNextId + ".csv";
            Response.ContentType = "csv";
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.EMPLOYEE_DETAILS_CSV);
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
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport = new clsEntityEmployeeDetailsReport();
        DataTable table = new DataTable();
        table.Columns.Add("EMPLOYEE ID", typeof(string));
        table.Columns.Add("EMPLOYEE NAME", typeof(string));
        table.Columns.Add("DESIGNATION", typeof(string));
        table.Columns.Add("DEPARTMENT", typeof(string));
        table.Columns.Add("DIVISION", typeof(string));
        table.Columns.Add("PAY GRADE", typeof(string));
       
        clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEmployeeDetailsreport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityEmployeeDetailsreport.OrganisationId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityEmployeeDetailsreport.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        if (ddlDesgntn.SelectedItem.Value != "--SELECT--")
        {
            objEntityEmployeeDetailsreport.DesignationId = Convert.ToInt32(ddlDesgntn.SelectedItem.Value);
        }
        if (ddlDeptmnt.SelectedItem.Value != "--SELECT--")
        {
            objEntityEmployeeDetailsreport.DepartmentId = Convert.ToInt32(ddlDeptmnt.SelectedItem.Value);
        }
        if (ddlDivsn.SelectedItem.Value != "--SELECT--")
        {
            objEntityEmployeeDetailsreport.DivisionId = Convert.ToInt32(ddlDivsn.SelectedItem.Value);
        }
        if (ddlGrade.SelectedItem.Value != "--SELECT--")
        {
            objEntityEmployeeDetailsreport.GradeId = Convert.ToInt32(ddlGrade.SelectedItem.Value);
        }
        if (ddlPrjct.SelectedItem.Value != "--SELECT--")
        {
            objEntityEmployeeDetailsreport.ProjectId = Convert.ToInt32(ddlPrjct.SelectedItem.Value);
        }
        //objEntityEmployeeDetailsreport.StatusId = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        if (ddlStatus.SelectedItem.Value == "0")
        {
            objEntityEmployeeDetailsreport.StatusId = 1;
        }
        if (ddlStatus.SelectedItem.Value == "1")
        {
            objEntityEmployeeDetailsreport.StatusId = 2;
        }
        if (ddlStatus.SelectedItem.Value == "2")
        {
            objEntityEmployeeDetailsreport.StatusId = 3;
        }
        if (ddlStatus.SelectedItem.Value == "3")
        {
            objEntityEmployeeDetailsreport.StatusId = 0;
        }
        if (ddlNation.SelectedItem.Value != "--SELECT--")
        {
            objEntityEmployeeDetailsreport.NationalityId = Convert.ToInt32(ddlNation.SelectedItem.Value);
        }
        if (ddlRelgn.SelectedItem.Value != "--SELECT--")
        {
            objEntityEmployeeDetailsreport.ReligionId = Convert.ToInt32(ddlRelgn.SelectedItem.Value);
        }

        objEntityEmployeeDetailsreport.GenderId = Convert.ToInt32(ddlGender.SelectedItem.Value);


        if (ddlNumYear.SelectedItem.Value != "--SELECT--")
        {
            objEntityEmployeeDetailsreport.NumOfYears = Convert.ToInt32(ddlNumYear.SelectedItem.Value);
        }
        if (txtAgeFrom.Text != "")
        {
            objEntityEmployeeDetailsreport.AgeFrom = Convert.ToInt32(txtAgeFrom.Text);
        }
        if (txtAgeTo.Text != "")
        {
            objEntityEmployeeDetailsreport.AgeTo = Convert.ToInt32(txtAgeTo.Text);
        }

        DataTable dt = new DataTable();
        dt = objBusinessEmployeeDetailsReport.ReadEmployeeList(objEntityEmployeeDetailsreport);

        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
      
   
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            objEntityEmployeeDetailsreport.UserId = Convert.ToInt32(dt.Rows[intRowBodyCount]["USR_ID"]);
            DataTable dtDivisions = objBusinessEmployeeDetailsReport.ReadDivisionOfEmp(objEntityEmployeeDetailsreport);

            objEntityEmployeeDetailsreport.date = System.DateTime.Now;
            DataTable dtProject = objBusinessEmployeeDetailsReport.ReadProjectDetails(objEntityEmployeeDetailsreport);

            //DataTable dtLeave = objBusinessEmployeeDetailsReport.ReadLeave(objEntityEmployeeDetailsreport);
            //Start:-For Project Search
            string strShowPrjct = "false";
            if (dtProject.Rows.Count == 0 && ddlPrjct.SelectedItem.Value == "--SELECT--")
            {
                strShowPrjct = "true";
            }
            foreach (DataRow dtDiv in dtProject.Rows)
            {


                if (ddlPrjct.SelectedItem.Value != "--SELECT--")
                {
                    if (dtDiv["PROJECT_ID"].ToString() == ddlPrjct.SelectedItem.Value)
                    {
                        strShowPrjct = "true";
                    }
                }
                else
                {
                    strShowPrjct = "true";
                }

            }
            //End:-For Project Search



            //Start:-For Division Search
            string strShow = "false";
            string strDivisions = "";
            if (dtDivisions.Rows.Count == 0 && ddlDivsn.SelectedItem.Value == "--SELECT--")
            {
                strShow = "true";
            }
            foreach (DataRow dtDiv in dtDivisions.Rows)
            {
                if (strDivisions == "")
                {
                    strDivisions = dtDiv["CPRDIV_NAME"].ToString();
                }
                else
                {
                    strDivisions = strDivisions + "," + dtDiv["CPRDIV_NAME"];
                }

                if (ddlDivsn.SelectedItem.Value != "--SELECT--")
                {
                    if (dtDiv["CPRDIV_ID"].ToString() == ddlDivsn.SelectedItem.Value)
                    {
                        strShow = "true";
                    }
                }
                else
                {
                    strShow = "true";
                }

            }
            //End:-For Division Search
            //EVM-0027
           
           

           
               
               
           
            //END

            //Start:-For Age Search
            Int64 Years = 000;
            string strShowAge = "false";
            clsCommonLibrary commn = new clsCommonLibrary();
            if (dt.Rows[intRowBodyCount]["EMPERDTL_DOB"].ToString() != "" && dt.Rows[intRowBodyCount]["EMPERDTL_DOB"].ToString() != null )
            {

                string Dob1 = dt.Rows[intRowBodyCount]["EMPERDTL_DOB"].ToString();
                DateTime dob = commn.textToDateTime(Dob1);

                if (dob < DateTime.Now)
                {

                    Years = new DateTime(DateTime.Now.Subtract(dob).Ticks).Year - 1;
                }


                //DateTime Dob = Convert.ToDateTime(dt.Rows[intRowBodyCount]["EMPERDTL_DOB"].ToString());
                //Years = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;

            }
            //END
            if (txtAgeFrom.Text != "" && txtAgeTo.Text != "")
            {
                if (Years >= Convert.ToInt32(txtAgeFrom.Text) && Years <= Convert.ToInt32(txtAgeTo.Text))
                {
                    strShowAge = "true";
                }
            }
            else if (txtAgeFrom.Text != "")
            {
                if (Years >= Convert.ToInt32(txtAgeFrom.Text))
                {
                    strShowAge = "true";
                }
            }
            else if (txtAgeTo.Text != "")
            {
                if (Years <= Convert.ToInt32(txtAgeTo.Text))
                {
                    strShowAge = "true";
                }
            }
            else
            {
                strShowAge = "true";
            }
            //End:-For Age Search
            int ExpYears = 0;
            string strShowExp = "false";
            if (dt.Rows[intRowBodyCount]["EMPERDTL_JOIN_DATE"].ToString() != "")
            {
                DateTime Dob = commn.textToDateTime(dt.Rows[intRowBodyCount]["EMPERDTL_JOIN_DATE"].ToString());
                //  DateTime Dob = Convert.ToDateTime(dt.Rows[intRowBodyCount]["EMPERDTL_JOIN_DATE"].ToString());
                if (Dob < DateTime.Now)
                    ExpYears = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;

            }

            ////Start:-For Exp Years Search
            //int ExpYears = 0;
            //string strShowExp = "false";
            //if (dt.Rows[intRowBodyCount]["EMPERDTL_JOIN_DATE"].ToString() != "")
            //{

            //    DateTime Dob = Convert.ToDateTime(dt.Rows[intRowBodyCount]["EMPERDTL_JOIN_DATE"].ToString());
            //    if (Dob < DateTime.Now)
            //        ExpYears = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;

            //}
            if (ddlNumYear.SelectedItem.Value == "1")
            {
                if (ExpYears >= 1)
                {
                    strShowExp = "true";
                }
            }
            else if (ddlNumYear.SelectedItem.Value == "2")
            {
                if (ExpYears >= 3)
                {
                    strShowExp = "true";
                }
            }
            else if (ddlNumYear.SelectedItem.Value == "3")
            {
                if (ExpYears >= 5)
                {
                    strShowExp = "true";
                }
            }
            else if (ddlNumYear.SelectedItem.Value == "4")
            {
                if (ExpYears >= 8)
                {
                    strShowExp = "true";
                }
            }
            else
            {
                strShowExp = "true";
            }
            //End:-For Exp Years Search



            if (strShow == "true" && strShowPrjct == "true" && strShowAge == "true" && strShowExp == "true")
            {

               

                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                string EmployeeId = "";
                string EmployeeName = "";
                string Designation = "";
                string Department = "";
                string Division = "";
                string payGrade = ""; 
                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {


               
              
                    if (intColumnBodyCount == 1)
                    {
                        EmployeeId = dt.Rows[intRowBodyCount][3].ToString();
                    }
                    if (intColumnBodyCount == 2)
                    {
                        if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() != "")
                        {
                            EmployeeName= dt.Rows[intRowBodyCount]["USRNAME"].ToString() ;
                        }
                        else
                        {
                            EmployeeName = dt.Rows[intRowBodyCount][9].ToString();
                        }

                    }
                    if (intColumnBodyCount == 3)
                    {
                        Designation = dt.Rows[intRowBodyCount]["DSGN_NAME"].ToString();
                    }
                    if (intColumnBodyCount == 4)
                    {
                        Department = dt.Rows[intRowBodyCount]["CPRDEPT_NAME"].ToString();
                    }
                }
                Division = strDivisions;

                payGrade = dt.Rows[intRowBodyCount][6].ToString().ToUpper();


                table.Rows.Add('"' + EmployeeId + '"', '"' + EmployeeName + '"', '"' + Designation + '"', '"' + Department + '"', '"' + Division + '"', '"' + payGrade +  '"');
            }
            
        }
        return table;

    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        Response.Redirect("hcm_Employee_Details_Report.aspx");
    }
}