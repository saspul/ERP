using System;
using System.Collections.Generic;
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


public partial class HCM_HCM_Master_hcm_PayrollSystem_hcm_Monthly_Salary_WPS_List_hcm_Monthly_Salary_WPS_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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


            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

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
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {
                                                             clsCommonLibrary.CORP_GLOBAL.PAYROLL_INDIVIDUAL_ROUND
                                                              };
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            HiddenFieldIndividualRound.Value = dtCorpDetail.Rows[0]["PAYROLL_INDIVIDUAL_ROUND"].ToString();
        }
        clsBusiness_Mnthly_WPS_List objBuss = new clsBusiness_Mnthly_WPS_List();
        ClsEntityLayerWps_List objEnt = new ClsEntityLayerWps_List();
        objEnt.CorprtId = intCorpId;
        objEnt.UserId = intUserId;
        objEnt.OrgId = intOrgId;
        objEnt.SavConf = 0;

        DataTable dtList = objBuss.LoadMonthlySalList(objEnt);
        
        string STRLIST = ConvertDataTableToHTML(dtList);
        
        divlistview.InnerHtml = STRLIST;
    }

    public string ConvertDataTableToHTML(DataTable dt)
    {



        int intOrgId = 0;
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());


        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"table table-striped table-bordered\" width=\"100%\" >";
        //add header row
        strHtml += "<thead>";
 

        strHtml += "<tr >";
        string strHead = "<tr >";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 1)
            {
                

                strHtml += "<th class=\"hasinput\" style=\"width: 15%\"><input type=\"text\" class=\"form-control\" onkeypress='return DisableEnter(event);' placeholder='" + "MONTH & YEAR" + "' </th>";
                strHead += " <th data-class=\"expand\">" + "MONTH & YEAR" + "</th>";

            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"hasinput\" style=\"width: 15%\"><input type=\"text\" class=\"form-control\" onkeypress='return DisableEnter(event);' placeholder='" + "TYPE " + "' </th>";
                strHead += " <th data-class=\"expand\">" + "TYPE " + "</th>";
            }

            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"hasinput\" style=\"width: 20%\"><input type=\"text\" class=\"form-control\" onkeypress='return DisableEnter(event);' placeholder='" + "DEPARTMENT" + "' </th>";
                strHead += " <th data-class=\"expand\">" + "DEPARTMENT" + "</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"hasinput\" style=\"width: 20%\"><input type=\"text\" class=\"form-control\" onkeypress='return DisableEnter(event);' placeholder='" + "MODE" + "' </th>";
                strHead += " <th data-class=\"expand\">" + "MODE" + "</th>";
            }

            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"hasinput\" style=\"width: 15%\"><input type=\"text\" class=\"form-control\" onkeypress='return DisableEnter(event);' placeholder='" + "NO. OF EMPLOYEES" + "' </th>";
                strHead += " <th data-class=\"expand\">" + "NO. OF EMPLOYEES" + "</th>";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"hasinput\" style=\"width: 15%\"><input type=\"text\" class=\"form-control\" onkeypress='return DisableEnter(event);' placeholder='" + "DATE" + "' </th>";
                strHead += " <th data-class=\"expand\">" + "DATE" + "</th>";
            }
             else if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"hasinput\" style=\"width: 12%\"><input type=\"text\" class=\"form-control\" onkeypress='return DisableEnter(event);' placeholder='" + "PREVIEW" + "' </th>";
                strHead += " <th data-class=\"expand\">" + "PREVIEW" + "</th>";
            }
        }
        strHtml += "<th class=\"hasinput\" style=\"display:none;\"></th >";
        strHead += "<th class=\"hasinput\" style=\"display:none;\"></th ></tr>";
        strHtml += "</tr>";
        strHtml += strHead;
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr>";
            //  string orgid = dt.Rows[intRowBodyCount][0].ToString();
            // strHtml += "<td class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + slno + "</td>";
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    if (dt.Rows[intRowBodyCount]["WPS_MONTH"].ToString() != "")
                    {
                        int month = Convert.ToInt32(dt.Rows[intRowBodyCount]["WPS_MONTH"].ToString());
                        
                        DateTime date = new DateTime(1, month, 1);
                        string mnth = date.ToString("MMMM");
                        strHtml += "<td  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + mnth + " " + dt.Rows[intRowBodyCount]["WPS_YEAR"].ToString() + "</td>";
                    }
                    else
                        strHtml += "<td  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    string StaffWork = "";
                    if (dt.Rows[intRowBodyCount]["STAFF_WORKER"].ToString() == "0")
                    {
                        StaffWork = "Staff";
                    }
                    else
                    {
                        StaffWork = "Worker";
                    }
                    strHtml += "<td  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + StaffWork + "</td>";
                }

                else if (intColumnBodyCount == 3)
                {
                    string dept = "";
                    if (dt.Rows[intRowBodyCount]["DEPARTMENT"].ToString() == "")
                    {
                        dept = "";
                    }
                    else
                    {
                        dept = dt.Rows[intRowBodyCount]["DEPARTMENT"].ToString();
                    }
                    strHtml += "<td  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dept + "</td>";
                }
                else if (intColumnBodyCount == 4)
                {
                    string mode = "";
                    if (dt.Rows[intRowBodyCount]["WPS_MODE"].ToString() == "1")
                    {
                        mode = "Salary Process";
                    }
                    else if (dt.Rows[intRowBodyCount]["WPS_MODE"].ToString() == "2")
                    {
                        mode = "Leave Settlemnet";
                    }
                    else
                    {
                        mode = "End of Leave Settlemnet";
                    }
                    strHtml += "<td  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + mode + "</td>";

                }

                else if (intColumnBodyCount == 5)
                {
                    strHtml += "<td  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["WPS_EMP_COUNT"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 6)
                {
                    strHtml += "<td  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EXPORTDATE"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 7)
                {
                    strHtml += " <td  style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: centers;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button class=\"btn btn-xs btn-default\" data-original-title=\"Preview\"   onclick=\"return Clickme(" + dt.Rows[intRowBodyCount]["RECORD_IDENTITY"].ToString() + ");\"><i class=\"fa fa-pencil\"></i></button></td>";
                }

            }

            string CorpdepId = "";
            if (dt.Rows[intRowBodyCount]["DEPARTMENT"].ToString() != "")
            {
                CorpdepId = dt.Rows[intRowBodyCount]["DEPARTMENT"].ToString();
            }
            string staffWrk = dt.Rows[intRowBodyCount]["STAFF_WORKER"].ToString();
            string ddate = dt.Rows[intRowBodyCount]["EXPORTDATE"].ToString();
            string pMonth = dt.Rows[intRowBodyCount]["WPS_MONTH"].ToString();
            string pYear = dt.Rows[intRowBodyCount]["WPS_YEAR"].ToString();
            HiddenCorpID.Value=dt.Rows[intRowBodyCount]["CORPRT_ID"].ToString();
            string passingvalues = CorpdepId + "," + staffWrk + "," + ddate + "," + pMonth + "," + pYear;

            strHtml += "<td  style=\" word-break: break-all; word-wrap:break-word;text-align: left;display:none\" > <input type=\"text\"  value=\"" + passingvalues + "\" id=\"Para" + intRowBodyCount + "\"></td>";
            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        
        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    
    protected void btnRedirect_Click(object sender, EventArgs e)
    {
       
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string indvlRound = HiddenFieldIndividualRound.Value;
        clsBusiness_Mnthly_WPS_List objBuss = new clsBusiness_Mnthly_WPS_List();
        ClsEntityLayerWps_List objEnt = new ClsEntityLayerWps_List();
        int intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        int intCorpId = 0, intOrgId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        objEnt.RowId = Convert.ToInt32(HiddenRowId.Value);
      
        DataTable dtRecord = objBuss.ReadFor_PreView_Record(objEnt);
        DataTable dtHeader = objBuss.ReadFor_PreView_Header(objEnt);
        string strHtmlSIFRecord = ConvertDataTableToHtmlSIFRecord(dtRecord);
        divSIFbody.InnerHtml = strHtmlSIFRecord;
        string strHtmlSIF = ConvertDataTableToHtmlSIFHeader(dtHeader);
        divSIFHeader.InnerHtml = strHtmlSIF;
        ScriptManager.RegisterStartupScript(this, GetType(), "PrintClick", "PrintClick();", true);
    }

    public string ConvertDataTableToHtmlSIFRecord(DataTable dt)
    {
        string indvlRound = HiddenFieldIndividualRound.Value;
        clsBusiness_Mnthly_WPS_List objBuss = new clsBusiness_Mnthly_WPS_List();
        ClsEntityLayerWps_List objEnt = new ClsEntityLayerWps_List();
        int intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        if (Session["Bank"] != null)
        {
            objEnt.BankId = Convert.ToInt32(Session["Bank"]);
        }
        int count = 1;

        StringBuilder sbCap = new StringBuilder();
        string strCapTable = "";

        strCapTable = "SIF RECORD: <br><br>";
        strCapTable += "Record sequence, Employee QID, Employee Visa ID, Employee Name, Employee Bank Short Name, Employee Account, Salary Frequency, Number Of Working Days, Net Salary, Basic Salary, Extra Hours, Extra Income, Deductions, Payment Type, Notes/Comments <br> ";

        for (int row = 0; row < dt.Rows.Count; row++)
        {

            strCapTable += count + ", ";
            count++;
            if (dt.Rows[row]["EMP_QID"].ToString() != "")
            {
                strCapTable += dt.Rows[row]["EMP_QID"].ToString() + ", ";
            }
            else
            {
                strCapTable += ", ";
            }
            if (dt.Rows[row]["EMP_VISAID"].ToString() != "")
            {
                strCapTable += dt.Rows[row]["EMP_VISAID"].ToString() + ", ";
            }
            else
            {
                strCapTable += ", ";
            }
            if (dt.Rows[row]["EMP_NAME"].ToString() != "")
            {
                strCapTable += dt.Rows[row]["EMP_NAME"].ToString() + ", ";
            }
            else
            {
                strCapTable += ", ";
            }
            if (dt.Rows[row]["WPS_BANK"].ToString() != "")
            {
                strCapTable += dt.Rows[row]["WPS_BANK"].ToString() + ", ";
            }
            else
            {
                strCapTable += ", ";
            }
            if (dt.Rows[row]["EMP_ACCOUNT_NNO"].ToString() != "")
            {
                strCapTable += dt.Rows[row]["EMP_ACCOUNT_NNO"].ToString() + ", ";
            }
            else
            {
                strCapTable += ", ";
            }
            if (dt.Rows[row]["SALARY_FREQNCY"].ToString() != "")
            {
                strCapTable += dt.Rows[row]["SALARY_FREQNCY"].ToString() + ", ";
            }
            else
            {
                strCapTable += ", ";
            }
            if (dt.Rows[row]["WORKING_DAYS"].ToString() != "")
            {
                strCapTable += dt.Rows[row]["WORKING_DAYS"].ToString() + ", ";
            }
            else
            {
                strCapTable += ", ";
            }
            if (dt.Rows[row]["NET_SALARY"].ToString() != "")
            {
                //if (indvlRound == "1")
                //{
                strCapTable += Math.Round(Convert.ToDecimal(dt.Rows[row]["NET_SALARY"].ToString()), 0).ToString("0.00") + ",  ";
                //}
                //else
                //{
                //    strCapTable += dt.Rows[row]["NET_SALARY"].ToString() + ", ";
                //}

            }
            else
            {
                strCapTable += ", ";
            }


            if (dt.Rows[row]["SLPRCDMNTH_PRSD_BASICPAY"].ToString() != "")
            {

                if (indvlRound == "1")
                {
                    strCapTable += Math.Round(Convert.ToDecimal(dt.Rows[row]["SLPRCDMNTH_PRSD_BASICPAY"].ToString()), 0).ToString("0.00") + ",  ";
                }
                else
                {
                    strCapTable += dt.Rows[row]["SLPRCDMNTH_PRSD_BASICPAY"].ToString() + ", ";
                }
            }
            else
            {
                strCapTable += ", ";
            }


            /* if (dt.Rows[row]["BASIC_SALARY"].ToString() != "")
             {
                 strCapTable += dt.Rows[row]["BASIC_SALARY"].ToString() + ", ";
             }
             else
             {
                 strCapTable += ", ";
             }*/




            if (dt.Rows[row]["EXTRA_HOURS"].ToString() != "")
            {
                strCapTable += dt.Rows[row]["EXTRA_HOURS"].ToString() + ", ";
            }
            else
            {
                strCapTable += "0, ";
            }
            if (dt.Rows[row]["EXTRA_INCOME"].ToString() != "")
            {

                if (indvlRound == "1")
                {
                    strCapTable += Math.Round(Convert.ToDecimal(dt.Rows[row]["EXTRA_INCOME"].ToString()), 0).ToString("0.00") + ",  ";
                }
                else
                {
                    strCapTable += dt.Rows[row]["EXTRA_INCOME"].ToString() + ", ";
                }
            }
            else
            {
                strCapTable += ", ";
            }
            if (dt.Rows[row]["DECUCTION"].ToString() != "")
            {

                if (indvlRound == "1")
                {
                    strCapTable += Math.Round(Convert.ToDecimal(dt.Rows[row]["DECUCTION"].ToString()), 0).ToString("0.00") + ",  ";
                }
                else
                {
                    strCapTable += dt.Rows[row]["DECUCTION"].ToString() + ", ";
                }
            }
            else
            {
                strCapTable += ", ";
            }
            if (dt.Rows[row]["WPS_MODE"].ToString() != "")
            {
                if (dt.Rows[row]["WPS_MODE"].ToString() == "1")
                {
                    strCapTable += "Salary Process " + ", ";
                }
                if (dt.Rows[row]["WPS_MODE"].ToString() == "2")
                {
                    strCapTable += " Leave Settlement" + ", ";
                }
                if (dt.Rows[row]["WPS_MODE"].ToString() == "3")
                {
                    strCapTable += "End of Leave Settlement" + ", ";
                }
            }
            else
            {
                strCapTable += ", ";
            }
            if (dt.Rows[row]["COMMENTS"].ToString() != "")
            {
                strCapTable += dt.Rows[row]["COMMENTS"].ToString() + "</br>";
            }
            else
            {
                strCapTable += "</br>";
            }


        }
        sbCap.Append(strCapTable);
        return sbCap.ToString();
    }

    public string ConvertDataTableToHtmlSIFHeader(DataTable dt)
    {
        StringBuilder sbCap = new StringBuilder();
        string strCapTable = "";
        int month = 0;
        string year = "";
        strCapTable = "SIF HEADER: <br><br>";
        strCapTable += "Employer EID, File Creation Date, File Creation Time, Payer EID, Payer QID, Payer Bank Short Name, Payer IBAN, Salary Year and Month, Total Salaries, Total Records <br>";

        for (int row = 0; row < dt.Rows.Count; row++)
        {
            DateTime filedate;
            DateTime filetime;

            year = dt.Rows[row]["WPS_YEAR"].ToString();
            month = Convert.ToInt32(dt.Rows[row]["WPS_MONTH"].ToString());
            if (dt.Rows[row]["EMPLYER_EID"].ToString() != "")
            {
                strCapTable += dt.Rows[row]["EMPLYER_EID"].ToString() + ", ";
            }
            else
            {
                strCapTable += ", ";
            }
            if (dt.Rows[row]["FILE_CREATE_DATE"].ToString() != "")
            {
                filedate = Convert.ToDateTime(dt.Rows[row]["FILE_CREATE_DATE"].ToString());
                strCapTable += filedate.Year + "" + filedate.Month + "" + filedate.Day + ", ";

            }
            else
            {
                strCapTable += ", ";
            }
            if (dt.Rows[row]["FILE_CTREATE_TIME"].ToString() != "")
            {
                filetime = Convert.ToDateTime(dt.Rows[row]["FILE_CTREATE_TIME"].ToString());
                strCapTable += filetime.Hour + "" + filetime.Minute + ", ";
            }
            else
            {
                strCapTable += ", ";
            }
            if (dt.Rows[row]["EMPLYER_EID"].ToString() != "")
            {
                strCapTable += dt.Rows[row]["EMPLYER_EID"].ToString() + ", ";
            }
            else
            {
                strCapTable += ", ";
            }
            if (dt.Rows[row]["PAYER_QID"].ToString() != "")
            {
                strCapTable += dt.Rows[row]["PAYER_QID"].ToString() + ", ";
            }
            else
            {
                strCapTable += ", ";
            }
            if (dt.Rows[row]["PAYER_BANK_NAME"].ToString() != "")
            {
                strCapTable += dt.Rows[row]["PAYER_BANK_NAME"].ToString() + ", ";
            }
            else
            {
                strCapTable += ", ";
            }
            if (dt.Rows[row]["PAYER_IBAN"].ToString() != "")
            {
                strCapTable += dt.Rows[row]["PAYER_IBAN"].ToString() + ", ";
            }
            else
            {
                strCapTable += ", ";
            }
            strCapTable += year + "" + month + ", ";
            if (dt.Rows[row]["TOTAL_SALARY"].ToString() != "")
            {
                strCapTable += dt.Rows[row]["TOTAL_SALARY"].ToString() + ", ";
            }
            else
            {
                strCapTable += ", ";
            }
            if (dt.Rows[row]["TOTAL_RECORD"].ToString() != "")
            {
                strCapTable += dt.Rows[row]["TOTAL_RECORD"].ToString() + "</br>";
            }
            else
            {
                strCapTable += "</br>";
            }


        }
        sbCap.Append(strCapTable);
        return sbCap.ToString();
    }
}