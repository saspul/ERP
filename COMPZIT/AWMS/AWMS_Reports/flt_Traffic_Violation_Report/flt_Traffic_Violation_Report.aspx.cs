using BL_Compzit;
using CL_Compzit;
using EL_Compzit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DL_Compzit.DataLayer_AWMS;    
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_AWMS;
using BL_Compzit.BusinessLayer_GMS;



public partial class AWMS_AWMS_Reports_flt_Traffic_Violation_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { 

          txtfromdate.Attributes.Add("onkeypress", "return isTag(event)");
        txttodate.Attributes.Add("onkeypress", "return isTag(event)");
      
       //Creating objects for businesslayer
        clsBusinessLayerTrafficViolationReport objBusinessViolationReport = new clsBusinessLayerTrafficViolationReport();
        clsEntityLayerTrafficViolationReport objEntityViolationReport = new clsEntityLayerTrafficViolationReport();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerEmployee objEntityViolationReportforlist = new clsEntityLayerEmployee();
        List<clsEntityLayerEmployee> objviolatedemp = new List<clsEntityLayerEmployee>();
      ///  clsEntityLayerEmployee objEntityViolationReportforlist = new clsEntityLayerEmployee();
        int corpid = 0 ;
        clsEntityReports objEntityReports = new clsEntityReports();
        
        ScriptManager.RegisterStartupScript(this, GetType(), "checkselecteed", "checkselecteed();", true);
        ddlEmployee.Focus();
        if (!IsPostBack)
        {
            hiddensearchby.Value = "Employee";
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityViolationReport.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                corpid = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                corpid = 0;
     
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityViolationReport.OrgID = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
         
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            radioemploye.Checked = true;
            Employee_Load();
            Vehicle_Load();
            // clsEntity_Pay_Grade_Master objEntityPaygrd = new clsEntity_Pay_Grade_Master();

            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, corpid);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            }

            // for adding comma
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusiness.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
            }
            clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();
            //clsEntityReports objEntityReports = new clsEntityReports();
            objviolatedemp.Add(objEntityViolationReportforlist);
           DataTable dtProductSrch = objBusinessViolationReport.ReadViolationreport(objEntityViolationReport, objviolatedemp);
           lblNumRec.Text = "Total number of records : " + dtProductSrch.Rows.Count.ToString();
            string strHtm = ConvertDataTableToHTML(dtProductSrch);
            divReport.InnerHtml = strHtm;
            DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(objEntityReports);
            string strPrintReport = ConvertDataTableForPrint(dtProductSrch, dtCorp);
            divPrintReport.InnerHtml = strPrintReport;
            //evm-0023 add radioemp focus
            radioemploye.Focus();
        }
       
       
    }


    // Method for assigning  values to drop down list for Divisionfor search
    public void Employee_Load()
    {
        clsBusinessLayerTrafficViolationReport objbusinesslayeremplye = new clsBusinessLayerTrafficViolationReport();
        clsEntityLayerTrafficViolationReport objentitylayeremplye = new clsEntityLayerTrafficViolationReport();



        if (Session["CORPOFFICEID"] != null)
        {
            objentitylayeremplye.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objentitylayeremplye.OrgID = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objentitylayeremplye.EmployeeID = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        DataTable dtDivision = objbusinesslayeremplye.ReadEmployee(objentitylayeremplye);




        //Division
        ddlEmployee.DataSource = dtDivision;





        ddlEmployee.DataTextField = "USR_NAME";
        ddlEmployee.DataValueField = "USR_ID";
        ddlEmployee.DataBind();

       //s ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");


    }



    // Method for assigning  values to drop down list for Divisionfor search
    public void Vehicle_Load()
    {
        clsBusinessLayerTrafficViolationReport objbusinesslayeremplye = new clsBusinessLayerTrafficViolationReport();
        clsEntityLayerTrafficViolationReport objentitylayeremplye = new clsEntityLayerTrafficViolationReport();



        if (Session["CORPOFFICEID"] != null)
        {
            objentitylayeremplye.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objentitylayeremplye.OrgID = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        DataTable dtvehicle = objbusinesslayeremplye.ReadVehicle(objentitylayeremplye);




        //Division
        ddlvechcle.DataSource = dtvehicle;





        ddlvechcle.DataTextField = "VHCL_NUMBR";
        ddlvechcle.DataValueField = "VHCL_ID";
        ddlvechcle.DataBind();

      //  ddlvechcle.Items.Insert(0, "--SELECT VEHICLE--");


    }



    public void Status_Load() {
        ////ddlStatus.Items.Add("","");
        //ddlStatus.Items.Insert(0, "--SELECT--");
        //ddlStatus.Items.Insert(1, "SETTLED");
        //ddlStatus.Items.Insert(0, "NOT SETTLED");
    }



    protected void btnsearch_Click(object sender, EventArgs e)
    {
        List<clsEntityLayerEmployee> objviolatedemp = new List<clsEntityLayerEmployee>();
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
       // btnNext.Enabled = false;
       // btnPrevious.Enabled = false;
        hiddenPrevious.Value = "0";
        hiddenNext.Value = "";
        //Creating objects for businesslayer   
        clsEntityReports objEntityReports = new clsEntityReports();
     
        clsBusinessLayerTrafficViolationReport objBusinessViolationReport = new clsBusinessLayerTrafficViolationReport();
        clsEntityLayerTrafficViolationReport objEntityViolationReport = new clsEntityLayerTrafficViolationReport();
        clsCommonLibrary objCommon=new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityViolationReport.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityViolationReport.OrgID = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        //if (Session["USERID"] != null)
        //{
        //    objEntityViolationReport.EmplID = Convert.ToInt32(Session["USERID"].ToString());
        //}
        //else if (Session["USERID"] == null)
        //{
        //    Response.Redirect("~/Default.aspx");
        //}
        if (ddlStatus.SelectedItem.Text == "--SELECT--")
        {
            objEntityViolationReport.Status = 2;
        }
        else
        {
            objEntityViolationReport.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);

        }
        if (hiddenselectedlist.Value == "")

        {

            ddlEmployee.SelectedItem.Text = "";
            ddlvechcle.SelectedItem.Text = "";
        }
        if (radioemploye.Checked == true)
        {
            if (ddlEmployee.SelectedItem.Text == "")
            {
                objEntityViolationReport.EmployeeID = 0;
            }
            else
            {
                string[] tokens = hiddenselectedlist.Value.Split(',');
                //  foreach (ListItem itemCheckBoxModules in cblcandidatelist.Items)
                // {
                if (tokens.Count()==1)
                {
                    hiddenSelectdNo.Value = "1";
                }
                for (int i = 0; i < tokens.Count() ; i++)
                {
                    if (tokens[i]!="")
                    {
                    clsEntityLayerEmployee objEntityViolationReportforlist = new clsEntityLayerEmployee();
                    objEntityViolationReportforlist.searchby = hiddensearchby.Value;
                    objEntityViolationReportforlist.EmployeeID = Convert.ToInt32(tokens[i]);
                    objviolatedemp.Add(objEntityViolationReportforlist);
                    }
                }
                }
               
        }
        else if (radiovechcle.Checked == true)
        { 
            if (ddlvechcle.SelectedItem.Text == "")
            {

            
            }
            else
            {
                string[] tokens = hiddenselectedlist.Value.Split(',');
                //  foreach (ListItem itemCheckBoxModules in cblcandidatelist.Items)
                // {

                if (tokens.Count() == 1 && tokens[0] != "")
                {
                    hiddenSelectdNo.Value = "1";
                }
                
                for (int i = 0; i < tokens.Count(); i++)
                {

                    clsEntityLayerEmployee objEntityViolationReportforlist = new clsEntityLayerEmployee();
                    objEntityViolationReportforlist.searchby = hiddensearchby.Value;
                    objEntityViolationReportforlist.vehicleid = Convert.ToInt32(tokens[i]);
                    objviolatedemp.Add(objEntityViolationReportforlist);
                }
            }
        }
        if (txtfromdate.Text!="")
        objEntityViolationReport.FromDate = objCommon.textToDateTime(txtfromdate.Text);
        if (txttodate.Text == "")
        {
           objEntityViolationReport.ToDate =DateTime.Today;
 }
        else
        objEntityViolationReport.ToDate = objCommon.textToDateTime(txttodate.Text);

       
      //  hiddenSearch.Value = ddlDivisionSearch.SelectedItem.Value;

       // string strDivisionSearch = ddlDivisionSearch.SelectedItem.Value;
       // string strProductName = "";
       // string strQueryString = strDivisionSearch + "_" + strProductName;
        //hiddenSearch.Value = strQueryString;
        DataTable dtProductSrch = new DataTable();
        clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();
        dtProductSrch = objBusinessViolationReport.ReadViolationreport(objEntityViolationReport, objviolatedemp);
        lblNumRec.Text = "Total number of records : " + dtProductSrch.Rows.Count.ToString();
        string strHtm = ConvertDataTableToHTML(dtProductSrch);
        divReport.InnerHtml = strHtm;
        DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(objEntityReports);
        string strPrintReport = ConvertDataTableForPrint(dtProductSrch, dtCorp);
  


      //  DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(objEntityViolationReport);
      //  string strPrintReport = ConvertDataTableForPrint(dtProductSrch, dtCorp);
       divPrintReport.InnerHtml = strPrintReport;
       // if (tempdate != null)
            //hiddenDate.Value = tempdate.ToString("dd-MM-yyyy");
    }

    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        //int first = Convert.ToInt32(hiddenPrevious.Value);
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

 
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        DataTable dtCurrencyDetail = new DataTable();
        dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
        if (dtCurrencyDetail.Rows.Count > 0)
        {
            hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCMST_ABBRV"].ToString();
        }
       
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        if (dt.Rows.Count == 0)
        {
           
            strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">SL#</th>";
            strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">REFERENCE NO</th>";
            strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">DATE</th>";

            //evm-0023 if conditions for whether employee and vehicle have no data(table-html)
            if (hiddensearchby.Value == "Employee")
            {
                strHtml += "<th class=\"thT\" style=\"width:11%;text-align: left; word-wrap:break-word;\">VEHICLE</th>";
            }
            else if (hiddensearchby.Value == "vechcle")  
            {
                 strHtml += "<th class=\"thT\" style=\"width:8%;text-align: left; word-wrap:break-word;\">EMPLOYEE</th>";
            }
            
            

            strHtml += "<th class=\"thT\" style=\"width:15%;text-align: right; word-wrap:break-word;\">AMOUNT</th>";
            strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">RECEIPT NUMBER</th>";
            strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">STATUS</th>";
            strHtml += "<tr>";
            strHtml += "<tfooter>";
            strHtml += "<td  class=\"thT\" colspan=\"7\" style=\"font-weight: unset;border-right: navajowhite;width:6%;word-break: break-all; height:30px; word-wrap:break-word;text-align: center;background: rgb(219, 216, 216);\" >No data available</td>";

            strHtml += "</tfooter>";
            strHtml += "</tr>";
        }
        else
        {
            strHtml += "<th class=\"thT\" style=\"width:2%;text-align: center; word-wrap:break-word;\">SL#</th>";
            strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">REFERENCE NO</th>";

            for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
            {


                if (intColumnHeaderCount == 0)
                {
                    strHtml += "<th class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">DATE</th>";
                }
                if (hiddenSelectdNo.Value != "1")
                {
                    if (hiddensearchby.Value == "Employee" || hiddensearchby.Value == "vechcle")
                    {
                        if (intColumnHeaderCount == 1)
                        {
                            strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE</th>";
                        }
                        if (intColumnHeaderCount == 2)
                        {
                            strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">VEHICLE</th>";
                        }

                    }
                }
                else
                {

                    if (radiovechcle.Checked == true)
                    {

                        if (intColumnHeaderCount == 1)
                        {
                            strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">EMPLOYEE</th>";
                        }
                    }
                    if (radioemploye.Checked == true)
                    {

                        if (intColumnHeaderCount == 2)
                        {
                            strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">VEHICLE</th>";
                        }

                    }
                } if (intColumnHeaderCount == 3)
                {
                    strHtml += "<th class=\"thT\" style=\"width:8%;text-align: right; word-wrap:break-word;\">AMOUNT</th>";
                }
                if (intColumnHeaderCount == 4)
                {
                    strHtml += "<th class=\"thT\" style=\"width:8%;text-align: left; word-wrap:break-word;\">RECEIPT NUMBER</th>";
                }
                if (intColumnHeaderCount == 5)
                {
                    strHtml += "<th class=\"thT\" style=\"width:6%;text-align: center; word-wrap:break-word;\">STATUS</th>";
                }
                //if (intColumnHeaderCount == 6)
                //{
                //    strHtml += "<th class=\"thT\" style=\"width:14%;text-align: right; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                //}
                //if (intColumnHeaderCount == 7)
                //{
                //    strHtml += "<th class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                //}


            }


        } 
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
       // strHtml += "<tr >";
        //if (dt.Rows.Count == 0)
        //{
        //    //strHtml += "<th class=\"thT\" style=\"width:11%;text-align: left; word-wrap:break-word;\">VEHICLE</th>";
                
        //    //strHtml += "<th class=\"thT\"colspan=6 style=\"width:11%;text-align: center; word-wrap:break-word;\">NO DATA AVAILABLE</th>";

        //}
        //else
        //{
            int count = 1;
            string tempvehcle = "", tempvehcle2 = "";
            string tempemply = "", tempemply2 = "";
            for (
                
                int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {

                tempemply2 = tempemply;
                tempvehcle2 = tempvehcle;
                tempemply = dt.Rows[intRowBodyCount][1].ToString();



                tempvehcle = dt.Rows[intRowBodyCount][2].ToString();

                if (radiovechcle.Checked == true)
                {

                    if (tempvehcle2 != tempvehcle)
                    {
                        strHtml += "<tr style=\"background:#ababc8;text-align: center;\" >";
                        strHtml += "<td class=\"tdT\"  colspan=7 style=\"width:15%;word-break: break-all; word-wrap:break-word;text-align: center;background:#cdece3;;\" >" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";

                        strHtml += "</tr>";
                    }
                }
                if (radioemploye.Checked == true)
                {

                    if (tempemply2 != tempemply)
                    {
                        strHtml += "<tr style=\"background:#a3c3c3;text-align: center;\" >";
                        strHtml += "<td  class=\"tdT\" colspan=7 style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;background:#cdece3;;\" >" + dt.Rows[intRowBodyCount][1].ToString() + "</td>";

                        strHtml += "</tr>";
                    }
                }
                strHtml += "<tr  >";
                strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: center;padding-right: 13px;\" >" + count + "</td>";

                count = count + 1;

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 0)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["TRFCVIOLTN_REFNO"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["TRFCVIOLTNDTL_DATE"].ToString() + "</td>";
                    }
                    if (hiddenSelectdNo.Value != "1")
                    {
                        if (hiddensearchby.Value == "Employee" || hiddensearchby.Value == "vechcle")
                        {

                            if (intColumnBodyCount == 1)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][1].ToString() + "</td>";

                            }
                            if (intColumnBodyCount == 2)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";
                            }
                        }
                    }
                    else
                    {
                        if (radiovechcle.Checked == true)
                        {


                            if (intColumnBodyCount == 1)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                        }
                        if (radioemploye.Checked == true)
                        {

                            if (intColumnBodyCount == 2)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                        }
                    }
                    if (intColumnBodyCount == 3)
                    {

                      string AMT=  objBusinessLayer.AddCommasForNumberSeperation(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString(),objEntityCommon);
                      strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: right;padding-right: 5px;\" >" + AMT+ "   "+"</td>";
                    }
                    if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    //if (intColumnBodyCount == 6)
                    //{

                    //    string rchgAmnt = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();

                    //    objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                    //    string commarchgAmnt = objBusinessLayer.AddCommasForNumberSeperation(rchgAmnt, objEntityCommon);
                    //    string currency = dt.Rows[intRowBodyCount][9].ToString();
                    //    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: end;\" >" + commarchgAmnt + " " + currency + "</td>";
                    //}
                    if (intColumnBodyCount == 5)
                    {
                      //  strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                        if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "1")
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: center;\" >SETTLED</td>";
                
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >NOT SETTLED</td>";
                        }
                    }
                    //if (intColumnBodyCount == 7)
                    //{
                    //    strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    //}


                }



                strHtml += "</tr>";




            }
        
      //  strHtml += "</tr>";
        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    //It build the Html table for printing by using the datatable provided
    public string ConvertDataTableForPrint(DataTable dt, DataTable dtCorp)
    {

        clsEntityCommon objEntityCommon = new clsEntityCommon();

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        DataTable dtCurrencyDetail = new DataTable();
        dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
        if (dtCurrencyDetail.Rows.Count > 0)
        {
            hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCMST_ABBRV"].ToString();
        }

        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Traffic Violation Report";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        //for printing product division on print
        string employee="";
        string vehicle="";
        string date="";
        string todate = "";
        string status = "";
        if (ddlEmployee.SelectedItem.Text.ToString() == "")
        {
            employee = "";                       //EMP17
        }
        else
        {if (radioemploye.Checked == true)
            {
                if (dt.Rows.Count > 0)
                {
                   string  str = Hiddenselectedtext.Value.Remove(Hiddenselectedtext.Value.Length - 1);
                    employee = "<B>Employee: </B>" + str;
                }
            }
        }

        if (dtCorp.Rows.Count > 0)
        {
            strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
            strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
            strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
            strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
            strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
        }
        if (ddlStatus.SelectedItem.Text.ToString() == "--SELECT--")
        {
            status = "";                                                 //EMP17
        }
        else
        {
            status = "<B>Status : </B>" + ddlStatus.SelectedItem.Text;                   //EMP17
        }
        if (ddlvechcle.SelectedItem.Text.ToString() == "")
        {
            vehicle = "";                                                 //EMP17
        }
        else
        {
            if (radiovechcle.Checked == true)
            {
                if (dt.Rows.Count > 0)
                {
                    string str = Hiddenselectedtext.Value.Remove(Hiddenselectedtext.Value.Length - 1);

                    vehicle = "<B>Vehicle : </B>" + str;
                }//EMP17
            }
        }
        if (txttodate.Text != "")
        {
            todate = "<B>To Date : </B>" + txttodate.Text;
        }
        if (txtfromdate.Text != "")
        {
            date = "<B>From Date : </B>" + txtfromdate.Text;
        }
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        string strCompanyAddr = objClsCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);

        StringBuilder sbCap = new StringBuilder();



        string strCaptionTabstart = "<table id=\"ReportTable\" class=\"PrintCaptionTable\" >";
        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr + "</td></tr>";
        string strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        string strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
        string strDivisionTitle = "";
        string strTypeTitle = "";
        if (radioemploye.Checked == true)
        {
             strDivisionTitle = "<tr><td class=\"RprtDiv\">" + employee + "</td></tr>";
        }
        else
        {
            strTypeTitle = "<tr><td class=\"RprtDiv\">" + vehicle + "</td></tr>";
        }
        string strStatsTitle = "<tr><td class=\"RprtDiv\">" + status + "</td></tr>";

        string strPeriodTitle = "<tr><td class=\"RprtDiv\">" + date + "</td></tr>";
        string strTOdateTitle = "<tr><td class=\"RprtDiv\">" + todate + "</td></tr>";
        if (date == "")
            strPeriodTitle = "";
        if (todate == "")
            strTOdateTitle = "";

        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strCaptionTabTitle + strDivisionTitle + strTypeTitle + strStatsTitle + strPeriodTitle + strTOdateTitle + strCaptionTabstop;



        sbCap.Append(strPrintCaptionTable);
        //write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString(); ;


        //clsEntityCommon objEntityCommon = new clsEntityCommon();

        //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        int first = 0;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();


        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";
        if (dt.Rows.Count == 0)
        {

            strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">SL#</th>";
            strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">DATE</th>";
            //evm-0023 if conditions for whether employee and vehicle have no data(printing) 
            if (hiddensearchby.Value == "Employee")
            {
                strHtml += "<th class=\"thT\" style=\"width:11%;text-align: left; word-wrap:break-word;\">VEHICLE</th>";
            }
            else if (hiddensearchby.Value == "vechcle")
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: left; word-wrap:break-word;\">EMPLOYEE</th>";
            }
            strHtml += "<th class=\"thT\" style=\"width:15%;text-align: right; word-wrap:break-word;\">AMOUNT</th>";
            strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">RECEIPT NUMBER</th>";
            strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">STATUS</th>";
       
        }
        else
        {
            strHtml += "<th class=\"thT\" style=\"width:4%;text-align: center; word-wrap:break-word;\">SL#</th>";
            strHtml += "<th class=\"thT\" style=\"width:4%;text-align: center; word-wrap:break-word;\">REFERENCE NO</th>";

            for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
            {


                if (intColumnHeaderCount == 0)
                {
                    strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">DATE</th>";
                }
                if (hiddenSelectdNo.Value != "1")
                {
                    if (hiddensearchby.Value == "Employee" || hiddensearchby.Value == "vechcle")
                    {
                        if (intColumnHeaderCount == 1)
                        {
                            strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE</th>";
                        }
                        if (intColumnHeaderCount == 2)
                        {
                            strHtml += "<th class=\"thT\" style=\"width:11%;text-align: left; word-wrap:break-word;\">VEHICLE</th>";
                        }

                    }
                }
                else
                {

                    if (radiovechcle.Checked == true)
                    {

                        if (intColumnHeaderCount == 1)
                        {
                            strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE</th>";
                        }
                    }
                    if (radioemploye.Checked == true)
                    {

                        if (intColumnHeaderCount == 2)
                        {
                            strHtml += "<th class=\"thT\" style=\"width:11%;text-align: left; word-wrap:break-word;\">VEHICLE</th>";
                        }

                    }
                } if (intColumnHeaderCount == 3)
                {
                    strHtml += "<th class=\"thT\" style=\"width:15%;text-align: right; word-wrap:break-word;\">AMOUNT</th>";
                }
                if (intColumnHeaderCount == 4)
                {
                    strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">RECEIPT NUMBER</th>";
                }
                if (intColumnHeaderCount == 5)
                {
                    strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">STATUS</th>";
                }
                //if (intColumnHeaderCount == 6)
                //{
                //    strHtml += "<th class=\"thT\" style=\"width:14%;text-align: right; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                //}
                //if (intColumnHeaderCount == 7)
                //{
                //    strHtml += "<th class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                //}


            }
        }
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
          if (dt.Rows.Count == 0)
        {
            strHtml += "<tr id=\"TableRprtRow\" >";
            strHtml += "<td class=\"thT\"colspan=10 style=\"width:11%;text-align: center; word-wrap:break-word;\">NO DATA AVAILABLE</th>";
       
             }
        else
        {
        int count = 0;
        string tempvehcle = "", tempvehcle2 = "";
        string tempemply = "", tempemply2 = "";
        for (int intRowBodyCount = first; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            tempemply2 = tempemply;
            tempvehcle2 = tempvehcle;
            tempemply = dt.Rows[intRowBodyCount][1].ToString();



            tempvehcle = dt.Rows[intRowBodyCount][2].ToString();

            if (radiovechcle.Checked == true)
            {

                if (tempvehcle2 != tempvehcle)
                {
                    strHtml += "<tr style=\"background:#dadada;text-align: center;\" >";
                    strHtml += "<td class=\"tdT\"colspan=7 \"style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";

                    strHtml += "</tr>";
                }
            }
            if (radioemploye.Checked == true)
            {

                if (tempemply2 != tempemply)
                {
                    strHtml += "<tr style=\"background:#dadada;text-align: center;\" >";
                    strHtml += "<td class=\"tdT\"colspan=7 \"style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][1].ToString() + "</td>";

                    strHtml += "</tr>";
                }
            } count = intRowBodyCount + 1;
            strHtml += "<tr  >";
            strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + count + "</td>";

      

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                if (intColumnBodyCount == 0)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["TRFCVIOLTN_REFNO"].ToString() + "</td>";
                }
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["TRFCVIOLTNDTL_DATE"].ToString() + "</td>";
                }

                //if (intColumnBodyCount == 0)
                //{
                //    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                //}
                if (hiddenSelectdNo.Value != "1")
                {
                    if (hiddensearchby.Value == "Employee" || hiddensearchby.Value == "vechcle")
                    {

                        if (intColumnBodyCount == 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][1].ToString() + "</td>";

                        }
                        if (intColumnBodyCount == 2)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";
                        }
                    }
                }
                else
                {
                    if (radiovechcle.Checked == true)
                    {


                        if (intColumnBodyCount == 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                    }
                    if (radioemploye.Checked == true)
                    {

                        if (intColumnBodyCount == 2)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                    }
                }
                if (intColumnBodyCount == 3)
                {
                        string AMT = objBusinessLayer.AddCommasForNumberSeperation(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString(), objEntityCommon);
                        strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + AMT + " " + "</td>";
                    }
                    if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                //if (intColumnBodyCount == 6)
                //{

                //    string rchgAmnt = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();

                //    objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                //    string commarchgAmnt = objBusinessLayer.AddCommasForNumberSeperation(rchgAmnt, objEntityCommon);
                //    string currency = dt.Rows[intRowBodyCount][9].ToString();
                //    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: end;\" >" + commarchgAmnt + " " + currency + "</td>";
                //}
                if (intColumnBodyCount == 5)
                {
                    if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "1")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" >SETTLED</td>";

                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" >NOT SETTLED</td>";
                    }
                }
                //if (intColumnBodyCount == 7)
                //{
                //    strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                //}


            }



            strHtml += "</tr>";


        }

        }
        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();

    }
}
    