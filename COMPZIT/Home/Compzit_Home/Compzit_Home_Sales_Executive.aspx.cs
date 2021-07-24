using BL_Compzit;
using CL_Compzit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using System.Web.Services;

public partial class Home_Compzit_Home_Compzit_Home_Sales_Executive : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["APP_ID"] = "2";

        if (!IsPostBack)
        {

            clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
           
            clsCommonLibrary objcommon = new clsCommonLibrary();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            //int intUserId = 0;
           // clsCommonLibrary objCommon = new clsCommonLibrary();
            int intUserId = 0, intAllEnableMail = 0, intCorpId = 0, intOrgId = 0;
            //when ORGANIZATION ADMIN CHOOSES A CORPORATE 
            if (Request.QueryString["CId"] != null)
            {
                string strRandomMixedId = Request.QueryString["CId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Session["CORPOFFICEID"] = strId;
                clsBusinessLayer objBusiness = new clsBusinessLayer();
                if (Session["CORPOFFICEID"] != null)
                {

                    DataTable dtCorpDetail = new DataTable();

                    int intCorppId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    clsCommonLibrary.CORP_GLOBAL[] arrEnumer = { clsCommonLibrary.CORP_GLOBAL.ACTIVE_FINCYR_ID };
                    dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorppId);
                    if (dtCorpDetail.Rows.Count > 0)
                    {
                        if (dtCorpDetail.Rows[0]["ACTIVE_FINCYR_ID"].ToString() != "")
                        {
                            Session["FINCYRID"] = Convert.ToInt32(dtCorpDetail.Rows[0]["ACTIVE_FINCYR_ID"].ToString());
                        }
                    }
                }

                clsEntityLayerLogin objEntLogin = new clsEntityLayerLogin();
                objEntLogin.CorpOfficeId = Convert.ToInt32(strId);
                clsBusinessLayerLogin objBusinessLog = new clsBusinessLayerLogin();
                DataTable dtCorpName = new DataTable();
                dtCorpName = objBusinessLog.ReadCorporateName(objEntLogin);


                if (dtCorpName.Rows.Count > 0)
                {
                    Session["CORPORATENAME"] = dtCorpName.Rows[0]["CORPRT_NAME"].ToString();
                }
            }
            if (Session["USERID"] != null)
            {
                objEntityLead.Active_UserId = Convert.ToInt32(Session["USERID"].ToString());
                intUserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLead.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("../../Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityLead.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("../../Default.aspx");
            }
            Session["APP_ID"] = "2";

            int intUsrRolMstrIdLead = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.New_Lead);
            int intUsrRolMstrIdDivMgr = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Division_Manager_Dashboard);
            DataTable dtChildRolLead = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrIdLead);
            DataTable dtChildRolDivMgr = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrIdDivMgr);
            if (dtChildRolLead.Rows.Count > 0)
            {
              LoadDashBoardValues(objEntityLead);
                DrawDashBoardGraphs(objEntityLead);
            }
            else
            {
                divSalesExec.Visible = false;

            }
         //   if division manager
            if (dtChildRolLead.Rows.Count > 0 && dtChildRolDivMgr.Rows.Count > 0)
            {
            LoadDivisionMgrData(objEntityLead);
            DrawBarDiagramForDivMgr(objEntityLead);
            }
            else
            {
            divDivisionMgr.Visible = false;
            }


                //total Amt List 1-Total booking 2-Total booking in this month
          
            
            //string rcptAmnt = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
            //objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            //string commaRcptAmnt = objBusinessLayer.AddCommasForNumberSeperation(rcptAmnt, objEntityCommon);

            
        }

        
    }
    public void LoadDashBoardValues(clsEntityLeadCreation objEntityLead)
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayerDashboard objBusinessDashBoard = new clsBusinessLayerDashboard();

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {   clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE ,
                                                                clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
        DataTable dtCorpDetail = new DataTable();
       
        dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, objEntityLead.Corp_Id);
        if (dtCorpDetail.Rows.Count > 0)
        {


            hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            //CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();





        }
        
        string strCurrencyAbbr = "";
        if (hiddenDfltCurrencyMstrId.Value == "")
        {
            hiddenDfltCurrencyMstrId.Value = "0";
        }
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        DataTable dtCurrencyDetails = new DataTable();
        dtCurrencyDetails = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
        if (dtCurrencyDetails.Rows.Count > 0)
        {
            strCurrencyAbbr = dtCurrencyDetails.Rows[0]["CRNCMST_ABBRV"].ToString();
        }
        DataTable dtAmt = objBusinessDashBoard.Read_Amt_Sales_Executive(objEntityLead);
        if (dtAmt.Rows.Count > 0)
        {
            decimal DECTotalBookingAmt1 =Convert.ToDecimal( dtAmt.Rows[0]["TOTAL_AMT"].ToString());
            decimal DECTotalBookingAmt2 = Convert.ToDecimal(dtAmt.Rows[2]["TOTAL_AMT"].ToString());
            decimal DECTotalBookingAmt = DECTotalBookingAmt1 + DECTotalBookingAmt2;
            string strTotalBookingAmt = DECTotalBookingAmt.ToString();

            decimal DECTotalBookingAmtMonthly1 = Convert.ToDecimal(dtAmt.Rows[1]["TOTAL_AMT"].ToString());
            decimal DECTotalBookingAmtMonthly2 = Convert.ToDecimal(dtAmt.Rows[3]["TOTAL_AMT"].ToString());
            decimal DECTotalBookingAmtMonthly = DECTotalBookingAmtMonthly1 + DECTotalBookingAmtMonthly2;
            string strTotalBookingAmtMonthly = DECTotalBookingAmtMonthly.ToString();

            strTotalBookingAmt = objBusinessLayer.AddCommasForNumberSeperation(strTotalBookingAmt, objEntityCommon);
            strTotalBookingAmtMonthly = objBusinessLayer.AddCommasForNumberSeperation(strTotalBookingAmtMonthly, objEntityCommon);

            divTotalBookings.InnerHtml = "<p>" + strTotalBookingAmt +" "+ strCurrencyAbbr+"</p>";
            divBookingsMonthly.InnerHtml = "<p>" + strTotalBookingAmtMonthly +" "+strCurrencyAbbr+ "</p>";
        }
        //TotalCount List 1-leads in pipeline 2-leads opened this month 3-leads won this month 4-leads won 
        //5-leads lost this month 6-leads lost 7-Total Number of leads 8-COUNT of success 9--COUNT of success IN MONTH
        DataTable dtCount = objBusinessDashBoard.Read_Count_Sales_Executive(objEntityLead);
        if (dtCount.Rows.Count > 0)
        {
            string strLeadsInPipeLine = dtCount.Rows[0]["TOTAL_COUNT"].ToString();
            string strLeadsOpenedMonthly = dtCount.Rows[1]["TOTAL_COUNT"].ToString();
            string strLeadswonMonthly = dtCount.Rows[2]["TOTAL_COUNT"].ToString();
            string strLeadsWon = dtCount.Rows[3]["TOTAL_COUNT"].ToString();
            string strLeadsLostMonthly = dtCount.Rows[4]["TOTAL_COUNT"].ToString();
            string strLeadsLost = dtCount.Rows[5]["TOTAL_COUNT"].ToString();
            double strTotalNoLeads = Convert.ToDouble(dtCount.Rows[6]["TOTAL_COUNT"]);
            double strSucccesCount = Convert.ToDouble(dtCount.Rows[7]["TOTAL_COUNT"]);
            double strSucccesCountMonthly = Convert.ToDouble(dtCount.Rows[8]["TOTAL_COUNT"]);
            double strTotalNoLeadsMonthly = Convert.ToDouble(dtCount.Rows[9]["TOTAL_COUNT"]);
            decimal deciSuccessRate = 0;
             decimal deciSuccessRateMonthly =0;
            if ((decimal)strTotalNoLeads > 0)
            {
                deciSuccessRate = (decimal)strSucccesCount / (decimal)strTotalNoLeads;
                
            }
            if ((decimal)strTotalNoLeadsMonthly>0)
            {
                
                    deciSuccessRateMonthly = (decimal)strSucccesCountMonthly / (decimal)strTotalNoLeadsMonthly;
            }
            deciSuccessRate = Math.Round(deciSuccessRate * 100, 2);
            deciSuccessRateMonthly = Math.Round(deciSuccessRateMonthly * 100, 2);
            divLeadsInPipeLine.InnerHtml = "<p>" + strLeadsInPipeLine + "</p>";
            divLeadsOpenedMonthly.InnerHtml = "<p>" + strLeadsOpenedMonthly + "</p>";
            divLeadswonMonthly.InnerHtml = "<p>" + strLeadswonMonthly + "</p>";
            divLeadsWon.InnerHtml = "<p>" + strLeadsWon + "</p>";
            divLeadsLostMonthly.InnerHtml = "<p>" + strLeadsLostMonthly + "</p>";
            divLeadsLost.InnerHtml = "<p>" + strLeadsLost + "</p>";
            divTotalNoLeads.InnerHtml = "<p>" + strTotalNoLeads + "</p>";
            divSucccesCount.InnerHtml = "<p>" + deciSuccessRate + " %</p>";
            // String.Format("{0:P}", )
            divSucccesCountMonthly.InnerHtml = "<p>" + deciSuccessRateMonthly + " %</p>";

        }
    }
    public void DrawDashBoardGraphs(clsEntityLeadCreation objEntityLead)
    {
        //For sales Exec
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBusinessLayerDashboard objBusinessDashBoard = new clsBusinessLayerDashboard();
        hiddenLeadWonMonthly.Value = "";
        hiddenBookedAmtMonthly.Value = "";
        try
        {
            int intMonth = 0;

            DateTime dateCurrentDate = objBusinessLayer.LoadCurrentDate();
            //intMonth = DateTime.Today.Month;
            intMonth = dateCurrentDate.Month;
            //Graph Leads won monthly
            DataTable dtLeadsWon = objBusinessDashBoard.Read_Leads_Count_ById_Monthly(objEntityLead);



            int[] intLeadsMonthly = Enumerable.Repeat(0, intMonth + 1).ToArray();
            for (int intRowCount = 0; intRowCount < dtLeadsWon.Rows.Count; intRowCount++)
            {
                if (intLeadsMonthly.Length >= dtLeadsWon.Rows.Count)
                {

                    intLeadsMonthly[Convert.ToInt32(dtLeadsWon.Rows[intRowCount]["LEADS_STS_DATE"].ToString())] = Convert.ToInt32(dtLeadsWon.Rows[intRowCount]["LEADS_WON_COUNT"].ToString());
                }

            }
            string strLeadWonMonthly = "";
            strLeadWonMonthly = string.Join(",", intLeadsMonthly);
            hiddenLeadWonMonthly.Value = strLeadWonMonthly;



            //Graph Leads Amt Booked Monthly
            DataTable dtLeadsAmtBooked = objBusinessDashBoard.Read_Leads_Amt_ById_Monthly(objEntityLead);
            decimal[] decAmtBkdMonthly = new decimal[intMonth + 1];
            for (int intmonthCount = 0; intmonthCount < intMonth; intmonthCount++)
            {
                decAmtBkdMonthly[intmonthCount] = 0;
            }
            for (int intRowCount = 0; intRowCount < dtLeadsAmtBooked.Rows.Count; intRowCount++)
            {
                if (decAmtBkdMonthly.Length >= dtLeadsAmtBooked.Rows.Count)
                {

                    decAmtBkdMonthly[Convert.ToInt32(dtLeadsAmtBooked.Rows[intRowCount]["LEADS_STS_DATE"].ToString())] = Convert.ToDecimal(dtLeadsAmtBooked.Rows[intRowCount]["LDQUOT_NET_AMT"].ToString());
                }
            }
            string strAmtBkdMonthly = "";
            strAmtBkdMonthly = string.Join(",", decAmtBkdMonthly);
            hiddenBookedAmtMonthly.Value = strAmtBkdMonthly;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }
    public void LoadDivisionMgrData(clsEntityLeadCreation objEntityLead)
    {
        clsBusinessLayerDashboard objBusinessDashBoard = new clsBusinessLayerDashboard();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {   clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE ,
                                                                clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
        DataTable dtCorpDetail = new DataTable();

        dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, objEntityLead.Corp_Id);
        if (dtCorpDetail.Rows.Count > 0)
        {


            hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            //CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();





        }

        string strCurrencyAbbr = "";
        if (hiddenDfltCurrencyMstrId.Value == "")
        {
            hiddenDfltCurrencyMstrId.Value = "0";
        }
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        DataTable dtCurrencyDetails = new DataTable();
        dtCurrencyDetails = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
        hiddenCurrencyAbbr.Value = "";
        if (dtCurrencyDetails.Rows.Count > 0)
        {
            strCurrencyAbbr = dtCurrencyDetails.Rows[0]["CRNCMST_ABBRV"].ToString();
            hiddenCurrencyAbbr.Value = dtCurrencyDetails.Rows[0]["CRNCMST_ABBRV"].ToString();
        }



        // Mode=1 if table have project name mode-2 for table lost leads
        int intTblMode = 0;
        //MONTHLY WON LEADS(DEALS) DIVISION WISE CLIENT LIST
        string strMainHead="",StrSubHead="";
        DataTable dtMonthlyWonLeads = objBusinessDashBoard.Read_MonthlyWonLeads_ByDiv(objEntityLead);
        strMainHead = "Top Deals";
        StrSubHead = "deals won-Client wise";
        string strHtmWon = ConvertDataTableToHTML(dtMonthlyWonLeads, strMainHead,StrSubHead);
        //Write to divReport
        divMonthlyWonLeads.InnerHtml = strHtmWon;
        // --OPEN LEADS(DEALS) DIVISION WISE PROJECT LIST

        DataTable dtMonthlyOpenLeads = objBusinessDashBoard.Read_MonthlyOpenLeads_ByDiv(objEntityLead);
        strMainHead = "Top Deals";
        StrSubHead = "Open deals current month";
        intTblMode = 1;
        string strHtmOpen = ConvertDataTableToHTML(dtMonthlyOpenLeads, strMainHead, StrSubHead, intTblMode);
        //Write to divReport
        divMonthlyOpenLeads.InnerHtml = strHtmOpen;
        //-- CLOSED LEADS(DEALS) DIVISION WISE PROJECT LIST

        DataTable dtMonthlyClosedLeads = objBusinessDashBoard.Read_MonthlyClosedLeads_ByDiv(objEntityLead);
        strMainHead = "Top Deals";
        StrSubHead = "Closed deals current month";
        intTblMode = 1;
        string strHtmClosed = ConvertDataTableToHTML(dtMonthlyClosedLeads, strMainHead, StrSubHead, intTblMode);
        //Write to divReport
        divMonthlyClosedLeads.InnerHtml = strHtmClosed;
         
        //--LEADS LOSS MONTH WISE
      
        

          DataTable dtMonthlyLostLeads = objBusinessDashBoard.Read_MonthlyLostLeads_ByDiv(objEntityLead);
          strMainHead = "Lost opportunities";
        StrSubHead = "";
        intTblMode = 2;
        string strHtmLost = ConvertDataTableToHTML(dtMonthlyLostLeads, strMainHead, StrSubHead, intTblMode);
        //Write to divReport
        divMonthlyLostLeads.InnerHtml = strHtmLost;
       
       //--TOP AGED LEAD


        DataTable dtTopAgedLeads = objBusinessDashBoard.Read_TopAgedLeads_ByDiv(objEntityLead);
        strMainHead = "Top Aged Opportunity";
        StrSubHead = "";
        intTblMode = 3;
        string strHtmdtTopAgedLeads = ConvertDataTableToHTML(dtTopAgedLeads, strMainHead, StrSubHead, intTblMode);
        //Write to divReport
        divTopAgedLeads.InnerHtml = strHtmdtTopAgedLeads;


        // -Product cat by div
           
        DataTable dtProductCat = objBusinessDashBoard.Read_Product_Cat_ByDiv(objEntityLead);
        strMainHead = "Product Category Wise";
        StrSubHead = "";
        string strHtmdtProductCat = ConvertDataTableToHTML(dtProductCat, strMainHead, StrSubHead);
        //Write to divReport
        divProductCat.InnerHtml = strHtmdtProductCat;
       
    }
    public string ConvertDataTableToHTML(DataTable dt,string strMainHead,string StrSubHead,int intTblMode=0)
    {
        string strCurrencyAbbr = "";
        if (intTblMode != 3)
        {
            if (hiddenCurrencyAbbr.Value != "")
            {
                strCurrencyAbbr = hiddenCurrencyAbbr.Value;
            }
        }
        else
        {
            strCurrencyAbbr = "";
        }
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table class=\"table table-striped\" cellpadding=\"0\" cellspacing=\"0\" style=\"margin-bottom: 0px;\">";
        strHtml += "<thead><tr><th colspan=\"3\" >" + strMainHead + "</th></tr></thead>";
        if (StrSubHead != "")
        {
            strHtml += "<tr><th colspan=\"3\" class=\"tbl\" >" + StrSubHead + "</th></tr>";
        }
        //add header row
        strHtml += "<tr >";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<td class=\"tbl2\" style=\"width: 50%; \">" + dt.Columns[intColumnHeaderCount].ColumnName + "</td>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<td class=\"tbl3\" style=\"text-align: right;width: 50%; \">" + dt.Columns[intColumnHeaderCount].ColumnName + "</td>";
            }
        }
                 strHtml += "</tr>";
                 strHtml += "</table>";
                 strHtml += "<div style=\"height: 138px;overflow-x: auto;margin-bottom: 40px;\"><table class=\"table table-striped\" cellpadding=\"0\" cellspacing=\"0\"style=\"margin-bottom: 0px;\">";
        //add rows
                 for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr>";
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                if (intColumnBodyCount == 1)
                {
                    if (intTblMode == 1)
                    {
                        if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "")
                        {
                            strHtml += "<td class=\"tbl4\" style=\"width: 50%; \">" + dt.Rows[intRowBodyCount][3].ToString() + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tbl4\" style=\"width: 50%; \">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                    }
                    else
                    {
                        strHtml += "<td class=\"tbl4\" style=\"width: 50%; \">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                    }
                }
                if (intColumnBodyCount == 2)
                {
                    if (intTblMode == 2)
                    {
                        strHtml += "<td class=\"red_colomn\" style=\"text-align: right;width: 50%; \">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + " " + strCurrencyAbbr + "</td>";
                    }
                    else
                    {
                        strHtml += "<td class=\"tbl5\" style=\"text-align: right;width: 50%; \">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + " " + strCurrencyAbbr + "</td>";
                    }
                }

                }
                strHtml += "</tr>";
        }
                 if (dt.Rows.Count == 0)
                 {
                     strHtml += "<tr>";
                     strHtml += "<tfooter>";

                     strHtml += "<td  class=\"tbl5\" colspan=\"3\" style=\" border-right: navajowhite;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";

                     strHtml += "</tfooter>";
                     strHtml += "</tr>";
                 }
        strHtml += "</table></div>";

        sb.Append(strHtml);
        return sb.ToString();
    }
    public void DrawBarDiagramForDivMgr(clsEntityLeadCreation objEntityLead)
    {
        //For DivMgr
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBusinessLayerDashboard objBusinessDashBoard = new clsBusinessLayerDashboard();
        hiddenTotalConvertedLead.Value = "";
        hiddenTotalLead.Value = "";
        try
        {
            int intMonth = 0;

            DateTime dateCurrentDate = objBusinessLayer.LoadCurrentDate();
            //intMonth = DateTime.Today.Month;
            intMonth = dateCurrentDate.Month;
            
            DataTable dtTotalLeadsWon = objBusinessDashBoard.Read_TotalWonLeads_ByDiv(objEntityLead);



            int[] intTotalLeadsWonMon = Enumerable.Repeat(0, intMonth + 1).ToArray();
            for (int intRowCount = 0; intRowCount < dtTotalLeadsWon.Rows.Count; intRowCount++)
            {
                if (intTotalLeadsWonMon.Length >= dtTotalLeadsWon.Rows.Count)
                {

                    intTotalLeadsWonMon[Convert.ToInt32(dtTotalLeadsWon.Rows[intRowCount]["LEADS_STS_DATE"].ToString())] = Convert.ToInt32(dtTotalLeadsWon.Rows[intRowCount]["TOTAL_LEADS_WON"].ToString());
                }

            }
            string strLeadWonMonthly = "";
            strLeadWonMonthly = string.Join(",", intTotalLeadsWonMon);
            hiddenTotalConvertedLead.Value = strLeadWonMonthly;


           
            DataTable dtTotalLeads = objBusinessDashBoard.Read_TotalLeads_ByDiv(objEntityLead);



            int[] intTotalLeadsMonthly = Enumerable.Repeat(0, intMonth + 1).ToArray();
            for (int intRowCount = 0; intRowCount < dtTotalLeads.Rows.Count; intRowCount++)
            {
                if (intTotalLeadsMonthly.Length >= dtTotalLeads.Rows.Count)
                {

                    intTotalLeadsMonthly[Convert.ToInt32(dtTotalLeads.Rows[intRowCount]["LEADS_STS_DATE"].ToString())] = Convert.ToInt32(dtTotalLeads.Rows[intRowCount]["TOTAL_LEADS"].ToString());
                }

            }
            string strTotalLeadMonthly = "";
            strTotalLeadMonthly = string.Join(",", intTotalLeadsMonthly);
            hiddenTotalLead.Value = strTotalLeadMonthly;
            //Calc Avg Leads

            decimal[] decAvgLeads = new decimal[intMonth + 1];
            int intTotalLeadsWon = 0;
            for (int intmonthCount = 0; intmonthCount < intMonth; intmonthCount++)
            {
                if (intmonthCount > 0)
                {
                    intTotalLeadsWon = intTotalLeadsWonMon[intmonthCount];
                    //intTotLeads = intTotalLeadsMonthly[intmonthCount];
                    decAvgLeads[intmonthCount] = ((decimal)intTotalLeadsWon / (decimal)intmonthCount);

                   // decAvgLeads[intmonthCount] = (decimal)(intTotalLeadsWonMon[intmonthCount] / intTotalLeadsMonthly[intmonthCount]);
                    //decAvgLeads[intmonthCount] = intTotalLeadsWonMon[intmonthCount];

                }
                else
                {
                    decAvgLeads[intmonthCount] = 0;
                }
            }
            string strAvgLeads = "";
            strAvgLeads = string.Join(",", decAvgLeads);
            hiddenAvgLeads.Value = strAvgLeads;
           
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }
}