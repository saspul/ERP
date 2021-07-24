using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusinessLayer_AWMS;
using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using System.Web.UI.WebControls;
using System.Text;

public partial class AWMS_AWMS_Reports_flt_Duty_Roster_Report_flt_Duty_Roster_Report_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

         if (!IsPostBack)
        {
            
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            //Creating objects for business layer
            clsBusinessLayerDutyRosterReports objBusinessDutyRosterReptr = new clsBusinessLayerDutyRosterReports();
            clsEntityLayerDutyRosterReports objEntityDutyRosterReptr = new clsEntityLayerDutyRosterReports();

            int intCorpId = 0;

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityDutyRosterReptr.CorprtId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityDutyRosterReptr.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objEntityDutyRosterReptr.UserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Request.QueryString != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);

                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityDutyRosterReptr.EmplyJobId = Convert.ToInt32(strId);

                if (Request.QueryString["Back"] != null)
                {
                    HiddenFieldBack.Value = Request.QueryString["Back"].ToString();
                }
                if (Request.QueryString["EmpList"] != null)
                {
                    HiddenFieldBackIn.Value = Request.QueryString["EmpList"].ToString();
                }
            }


            DataTable dtDutyRosterAddditionalJobList = objBusinessDutyRosterReptr.ReadEmployeeAdditionalJobdetails(objEntityDutyRosterReptr);

            DataTable dtDutyRosterList = objBusinessDutyRosterReptr.ReadEmployeeJobdetails(objEntityDutyRosterReptr);
            if (dtDutyRosterList.Rows.Count > 0)
            {

                lblEmply.Text = dtDutyRosterList.Rows[0][9].ToString();
                lbldate.Text = dtDutyRosterList.Rows[0][10].ToString();
            }
            string strReport = ConvertDataTableToHTML(dtDutyRosterList, dtDutyRosterAddditionalJobList);
            divReport.InnerHtml = strReport;
            // DataTable dtCorp = objBusinessDutyRosterReptr.ReadDutyRosterReptr(objEntityDutyRosterReptr);
            string strprintreport = ConvertDataTableForPrint(dtDutyRosterList, dtDutyRosterAddditionalJobList);
            divPrintReport.InnerHtml = strprintreport;

         }
        }

    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, DataTable dtDutyRosterAddditionalJobList)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();


        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();


        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
       // strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">SL#</th>";
   
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">JOB</th>";
            }
           
                if (intColumnHeaderCount == 1)
                {
                    strHtml += "<th class=\"thT\" style=\"width:12%;text-align:center; word-wrap:break-word;\">START DATE & TIME</th>";
                }
            
             if (intColumnHeaderCount == 2)
                {
                    strHtml += "<th class=\"thT\" style=\"width:12%;text-align: center; word-wrap:break-word;\">END DATE & TIME</th>";
                }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">VEHICLE</th>";
            }
          
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">PROJECT</th>";
            }

            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">STATUS</th>";
            }
            if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">DESCRIPTION</th>";
            }

        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        int slno = 1;
        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
           // int id = Convert.ToInt32( dt.Rows[intRowBodyCount][6].ToString());


            strHtml += "<tr  >";

            //strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + slno + "</td>";
            //slno = intRowBodyCount +  ;
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                
                
                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a></td>";
                      
                }
               
                    if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" +  dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][13].ToString() + " " + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

                if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

                if (intColumnBodyCount == 6)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 7)
                {
                     strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
            }



            strHtml += "</tr>";




        }
        //addi jobs
        for (int intRowBodyCount = 0; intRowBodyCount < dtDutyRosterAddditionalJobList.Rows.Count; intRowBodyCount++)
        {
            //int id = Convert.ToInt32( dt.Rows[intRowBodyCount][6].ToString());
            //string strId = dt.Rows[intRowBodyCount][6].ToString();
            //int intIdLength = dt.Rows[intRowBodyCount][6].ToString().Length;
            //string stridLength = intIdLength.ToString("00");
            //string Id = stridLength + strId + strRandom;

            // int id = Convert.ToInt32(Id);
            strHtml += "<tr style=\"background-color: #aeaeae;color: white;\" >";


            for (int intColumnBodyCount = 0; intColumnBodyCount < dtDutyRosterAddditionalJobList.Columns.Count; intColumnBodyCount++)
            {
               

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dtDutyRosterAddditionalJobList.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a></td>";

                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dtDutyRosterAddditionalJobList.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

                if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtDutyRosterAddditionalJobList.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtDutyRosterAddditionalJobList.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

                if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" >";
                }
                if (intColumnBodyCount == 6)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtDutyRosterAddditionalJobList.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 7)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";
                }

            }



            strHtml += "</tr>";




        }
        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    
    }

    public string ConvertDataTableForPrint(DataTable dt, DataTable dtDutyRosterAddditionalJobList)
    {
        divtile.InnerHtml = "Duty Roster Report";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        int intCurrentQtr = 0, intMonthQtr = 0, intPrevQtr = 0, intIncrmntQtr = 1, intQtrRowCounter = 0;
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        decimal decQtrTotal = 0;
        string[] strArrQtr = new string[5];
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strRandom = objCommon.Random_Number();

        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayerDutyRosterReports objBusinessDutyRosterReptr = new clsBusinessLayerDutyRosterReports();
        clsEntityLayerDutyRosterReports objEntityDutyRosterReptr = new clsEntityLayerDutyRosterReports();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityDutyRosterReptr.CorprtId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityDutyRosterReptr.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtcorp = objBusinessDutyRosterReptr.ReadCorporateAddress(objEntityDutyRosterReptr);
        //title

        if (dtcorp.Rows.Count > 0)
        {
            strCompanyName = dtcorp.Rows[0]["CORPRT_NAME"].ToString();
            strCompanyAddr1 = dtcorp.Rows[0]["CORPRT_ADDR1"].ToString();
            strCompanyAddr2 = dtcorp.Rows[0]["CORPRT_ADDR2"].ToString();
            strCompanyAddr3 = dtcorp.Rows[0]["CORPRT_ADDR3"].ToString();
            strCompanyAddrCntry = dtcorp.Rows[0]["CNTRY_NAME"].ToString();
        }

        string strCompanyAddr = objCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);

        StringBuilder sbCap = new StringBuilder();
        string strCapTable = "";
        strCapTable = "<table class=\"PrintCaptionTable\" >";
        strCapTable += "<tr><th class=\"CompanyName\" style=\"text-align: left; word-wrap:break-word;\">" + strCompanyName + "</th><td></td></tr>";
        strCapTable += "<tr><th style=\"text-align: left; word-wrap:break-word;\">" + strCompanyAddr + "</th><td></td></tr>";
        strCapTable += "<tr><td><b>Report Date : </b>" + DateTime.Now.ToString("R") + "</td></tr>";


            strCapTable += "<tr><td><b>Employee : </b>" + lblEmply.Text + "</td></tr>";


            strCapTable += "<tr><td><b>Date : </b>" + lbldate.Text + "</td></tr>";


            strCapTable += "<tr><th colspan=\"2\" style=\"text-align: left; word-wrap:break-word;\">Duty Roster Report</th><td></td></tr>";
            strCapTable += "</table>";
            sbCap.Append(strCapTable);
            ////write to  divPrintCaption

        divPrintCaption.InnerHtml = sbCap.ToString();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";

        if (dt.Rows.Count > 0)
        {
            for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
            {
                if (intColumnHeaderCount == 0)
                {
                    strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">JOB</th>";
                }

                if (intColumnHeaderCount == 1)
                {
                    strHtml += "<th class=\"thT\" style=\"width:12%;text-align: center; word-wrap:break-word;\">START DATE & TIME</th>";
                }

                if (intColumnHeaderCount == 2)
                {
                    strHtml += "<th class=\"thT\" style=\"width:12%;text-align: center; word-wrap:break-word;\">END DATE & TIME</th>";
                }
                if (intColumnHeaderCount == 3)
                {
                    strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">VEHICLE</th>";
                }

                if (intColumnHeaderCount == 4)
                {
                    strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">PROJECT</th>";
                }

                if (intColumnHeaderCount == 5)
                {
                    strHtml += "<th class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">STATUS</th>";
                }
                if (intColumnHeaderCount == 6)
                {
                    strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">DESCRIPTION</th>";
                }


            }
        }

        else
        {


            strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word; text-align:center;\">JOB</th>";

            strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word; text-align:center\">START DATE & TIME</th>";

            strHtml += "<th  class=\"thT\"  style=\"width:20%;text-align: left; text-align:center; word-wrap:break-word;\">END DATE & TIME</th>";
            strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">VEHICLE</th>";
            strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">PROJECT</th>";
            strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">STATUS</th>";
            strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">DESCRIPTION</th>";
            strHtml += "<tr>";
            strHtml += "<tfooter>";
            strHtml += "<td  class=\"thT\" colspan=\"3\" style=\"font-weight: unset;border-right: navajowhite;width:6%;word-break: break-all; height:20px; word-wrap:break-word;text-align: center;\" >No data available</td>";

            strHtml += "</tfooter>";
            strHtml += "</tr>";
        }
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            //int id = Convert.ToInt32( dt.Rows[intRowBodyCount][6].ToString());
            string strId = dt.Rows[intRowBodyCount][6].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][6].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

            // int id = Convert.ToInt32(Id);
            strHtml += "<tr  >";


            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
              
                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a></td>";

                }
                  if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                
                if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][13].ToString() + " " + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

                if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 6)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 7)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
              

            }



            strHtml += "</tr>";




        }
        for (int intRowBodyCount = 0; intRowBodyCount < dtDutyRosterAddditionalJobList.Rows.Count; intRowBodyCount++)
        {
            //int id = Convert.ToInt32( dt.Rows[intRowBodyCount][6].ToString());
            //string strId = dt.Rows[intRowBodyCount][6].ToString();
            //int intIdLength = dt.Rows[intRowBodyCount][6].ToString().Length;
            //string stridLength = intIdLength.ToString("00");
            //string Id = stridLength + strId + strRandom;

            // int id = Convert.ToInt32(Id);
            strHtml += "<tr  >";


            for (int intColumnBodyCount = 0; intColumnBodyCount < dtDutyRosterAddditionalJobList.Columns.Count; intColumnBodyCount++)
            {
                

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align:left;\" >" + dtDutyRosterAddditionalJobList.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a></td>";

                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dtDutyRosterAddditionalJobList.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

                if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtDutyRosterAddditionalJobList.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtDutyRosterAddditionalJobList.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

                if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";
                }
                if (intColumnBodyCount == 6)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtDutyRosterAddditionalJobList.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 7)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";
                }

            }



            strHtml += "</tr>";




        }
        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
}