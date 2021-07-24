using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using CL_Compzit;
using EL_Compzit;
using System.Data;
using System.Text;
using System.Collections;

// CREATED BY:WEM-0006
// CREATED DATE:07/06/2016
// REVIEWED BY:
// REVIEW DATE:


public partial class Home_Compzit_DashboardList_Cmpzit_DashboardMailList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            btnNext.Enabled = false;
            btnPrevious.Enabled = false;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            //Creating objects for business layer
            clsBusinessLayerDashboard objBusinessLayerDashboard = new clsBusinessLayerDashboard();
            clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();

            DataTable dtReadMailList = new DataTable();
            //int intUserId = 0;
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLead.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            
            if (Session["ORGID"] != null)
            {
                objEntityLead.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else 
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objEntityLead.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else 
            {
                Response.Redirect("~/Default.aspx");
            }

           if (Request.QueryString["TId"] != null)
            {
                string strRandomMixedId = Request.QueryString["TId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityLead.Team = Convert.ToInt32(strId);
                
            }
           else 
           {
               Response.Redirect("~/Default.aspx");
           }
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE 

                                                               };

            dtReadMailList = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);


            if (dtReadMailList.Rows.Count > 0)
            {
                string strListingMode = dtReadMailList.Rows[0]["LISTING_MODE"].ToString();
                string strLstingModeSize = dtReadMailList.Rows[0]["LISTING_MODE_SIZE"].ToString();


                int intListingMode = Convert.ToInt32(strListingMode);
                if (intListingMode == 2)//variant
                {
                    btnNext.Text = "Show Next Records";
                    btnPrevious.Text = "Show Previous Records";
                    hiddenMemorySize.Value = strLstingModeSize;
                }
                else if (intListingMode == 1)//fixed
                {
                    btnNext.Text = "Show Next " + strLstingModeSize + " Records";
                    btnPrevious.Text = "Show Previous " + strLstingModeSize + " Records";
                    hiddenTotalRowCount.Value = strLstingModeSize;
                    hiddenNext.Value = strLstingModeSize;
                }
                hiddenPrevious.Value = "0";

               DataTable dtReadMailListing = objBusinessLayerDashboard.Read_MailList_For_TeamHead(objEntityLead);
                string strMailList = ConvertDataTableToHTML(dtReadMailListing);
                divReport.InnerHtml = strMailList;

            }
        }
    }
    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt)
    {


        int first = Convert.ToInt32(hiddenPrevious.Value);
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:30%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:27.5%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:27.5%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
           
        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = first; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            int intMemoryBytes = System.Text.ASCIIEncoding.Unicode.GetByteCount(strHtml);
            if (hiddenTotalRowCount.Value == "")
            {
                if (hiddenMemorySize.Value != "")
                {
                    if (intMemoryBytes >= Convert.ToInt64(hiddenMemorySize.Value))
                    {
                        hiddenTotalRowCount.Value = intRowBodyCount.ToString();
                        hiddenNext.Value = hiddenTotalRowCount.Value;
                        btnNext.Enabled = true;
                        break;

                    }
                    else
                    {
                        strHtml += "<tr  >";

                        
                        for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                        {
                           
                            if (intColumnBodyCount == 1)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            if (intColumnBodyCount == 2)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            if (intColumnBodyCount == 3)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:27.5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            if (intColumnBodyCount == 4)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:27.5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                           

                        }

                        
                        
                        strHtml += "</tr>";
                    }
                }
            }
            else
            {
                if (hiddenNext.Value == "")
                {
                    hiddenNext.Value = hiddenTotalRowCount.Value;
                }
                int last = Convert.ToInt32(hiddenNext.Value);
                if (intRowBodyCount < last)
                 {

                    strHtml += "<tr  >";

                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {
                       
                        if (intColumnBodyCount == 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 2)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 3)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:27.5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 4)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:27.5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                       

                    }



                    
                    
                    strHtml += "</tr>";
                }
                else
                {
                    btnNext.Enabled = true;
                }
            }
        }
        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    //for creating HTML Title
    private string SetTitle(string size, string value)
    {

        return "<h" + size + "><p align=center>" + value + "</p align></h" + size + ">";

    }


   


   
    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        // creating object for business layer
        clsBusinessLayerDashboard objBusinessLayerDashboard = new clsBusinessLayerDashboard();
        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLead.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityLead.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityLead.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Request.QueryString["TId"] != null)
        {

            string strRandomMixedId = Request.QueryString["TId"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityLead.Team = Convert.ToInt32(strId);

        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtReadMailList = objBusinessLayerDashboard.Read_MailList_For_TeamHead(objEntityLead);
        int first = Convert.ToInt32(hiddenPrevious.Value) - Convert.ToInt32(hiddenTotalRowCount.Value);
        int last = Convert.ToInt32(hiddenPrevious.Value);
        hiddenPrevious.Value = first.ToString();
        hiddenNext.Value = last.ToString();
        if (first == 0)
        {
            btnPrevious.Enabled = false;

        }
        else
        {
            btnPrevious.Enabled = true;
        }
        if (last < dtReadMailList.Rows.Count)
        {

            btnNext.Enabled = true;
        }
        else
        {
            btnNext.Enabled = false;
        }
        //Write to divReport
        string strHtm = ConvertDataTableToHTML(dtReadMailList);
        divReport.InnerHtml = strHtm;
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        clsBusinessLayerDashboard objBusinessLayerDashboard = new clsBusinessLayerDashboard();
        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLead.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityLead.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityLead.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Request.QueryString["TId"] != null)
        {

            string strRandomMixedId = Request.QueryString["TId"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityLead.Team = Convert.ToInt32(strId);

        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtReadMailList = objBusinessLayerDashboard.Read_MailList_For_TeamHead(objEntityLead);
        int first = Convert.ToInt32(hiddenNext.Value);
        int last = Convert.ToInt32(hiddenNext.Value) + Convert.ToInt32(hiddenTotalRowCount.Value);
        hiddenPrevious.Value = first.ToString();
        hiddenNext.Value = last.ToString();
        if (first == 0)
        {
            btnPrevious.Enabled = false;

        }
        else
        {
            btnPrevious.Enabled = true;
        }
        if (last < dtReadMailList.Rows.Count)
        {

            btnNext.Enabled = true;
        }
        else
        {
            btnNext.Enabled = false;
        }
        //Write to divReport
        string strHtm = ConvertDataTableToHTML(dtReadMailList);
        divReport.InnerHtml = strHtm;
    }
}