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
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Globalization;

public partial class Home_Compzit_Home_Compzit_Home_Awms : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["APP_ID"] = "3";

        if (!IsPostBack)
        {
            clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
            clsBusinessLayerDashboard objBusinessDashBoard = new clsBusinessLayerDashboard();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();


            //when ORGANIZATION ADMIN CHOOSES A CORPORATE 
            if (Request.QueryString["CId"] != null)
            {
                string strRandomMixedId = Request.QueryString["CId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Session["CORPOFFICEID"] = strId;
                if (Session["CORPOFFICEID"] != null)
                {
                    clsBusinessLayer objBusiness = new clsBusinessLayer();
                    DataTable dtCorpDetails = new DataTable();

                    int intCorppId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    clsCommonLibrary.CORP_GLOBAL[] arrEnumerr = { clsCommonLibrary.CORP_GLOBAL.ACTIVE_FINCYR_ID };
                    dtCorpDetails = objBusiness.LoadGlobalDetail(arrEnumerr, intCorppId);
                    if (dtCorpDetails.Rows.Count > 0)
                    {
                        if (dtCorpDetails.Rows[0]["ACTIVE_FINCYR_ID"].ToString() != "")
                        {
                            Session["FINCYRID"] = Convert.ToInt32(dtCorpDetails.Rows[0]["ACTIVE_FINCYR_ID"].ToString());
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
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLead.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else
            {
                Response.Redirect("../../Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityLead.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else
            {
                Response.Redirect("../../Default.aspx");
            }
            DateTime dateCurrentDate = objBusinessLayer.LoadCurrentDate();
            string strYear = "";
            strYear = dateCurrentDate.Year.ToString();
            BindDdlMonths();
            BindDdlYears(strYear);
            if (ddlFromMonthInsu.Items.FindByValue("1") != null)
            {
                ddlFromMonthInsu.Items.FindByValue("1").Selected = true;
            }
            if (ddlToMonthInsu.Items.FindByValue("12") != null)
            {
                ddlToMonthInsu.Items.FindByValue("12").Selected = true;
            }
            if (ddlFromMonthPermit.Items.FindByValue("1") != null)
            {
                ddlFromMonthPermit.Items.FindByValue("1").Selected = true;
            }
            if (ddlToMonthPermit.Items.FindByValue("12") != null)
            {
                ddlToMonthPermit.Items.FindByValue("12").Selected = true;
            }
           
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {   clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE ,
                                                                clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            }


            DataTable dtVehicleDetails = new DataTable();
            dtVehicleDetails = objBusinessDashBoard.Read_Vehicle_Details(objEntityLead);
            
            DataTable dtVehicleInService = new DataTable();
            dtVehicleInService = objBusinessDashBoard.Read_Vehicle_InService(objEntityLead);
            DataTable dtVehicleType = new DataTable();
            dtVehicleType = objBusinessDashBoard.Read_Vehicle_ByType(objEntityLead);
            //To Read_Water_Card 
            DataTable dtWaterCardDetails = new DataTable();
            dtWaterCardDetails = objBusinessDashBoard.Read_Water_Card(objEntityLead);
            //to read DriverAvailChart 
            DataTable dtDriverAvailChart = new DataTable();
            dtDriverAvailChart = objBusinessDashBoard.Read_DriverAvailChart(objEntityLead);
            //read Read Violation pending Monthly
            DataTable dtReadViolationPendingMonthly = new DataTable();
            dtReadViolationPendingMonthly = objBusinessDashBoard.ReadPendingViolationMonthly(objEntityLead);

            //read Read Violation Settled Monthly
            DataTable dtReadViolationSettledMonthly = new DataTable();
            dtReadViolationSettledMonthly = objBusinessDashBoard.ReadSetteledViolationMonthly(objEntityLead);
            LoadBarChartViolation(dtReadViolationPendingMonthly, dtReadViolationSettledMonthly);
            //Load PROJECT vehicle allotment chart
            DataTable dtProjectVehicleClass = new DataTable();
            dtProjectVehicleClass = objBusinessDashBoard.ReadVehicleCountProjectWise(objEntityLead);
            DataTable dtProjectList = objBusinessDashBoard.ReadVehicleProjectList(objEntityLead);
            LoadBarChartVehicleAllotment(dtProjectVehicleClass, dtProjectList);
            
            
            
            ////load permit graph
            //DataTable dtPermit = new DataTable();
            //dtPermit = objBusinessDashBoard.ReadPermitCount(objEntityLead);
            //LoadBarChartPermit(dtPermit);
            ////load permit graph
            //DataTable dtInsu = new DataTable();
            //dtInsu = objBusinessDashBoard.ReadInsurCount(objEntityLead);
            //LoadBarChartInsu(dtInsu);

            LoadGraphVehicleByYear();
            LoadGraphVehicleType(dtVehicleType);
            LoadPieChartVhclInService(dtVehicleInService);
            LoadPieChartDriverAvailChart(dtDriverAvailChart);
            string strTableClass = "main_table_5", strTrClass = "main_table_5_head";
            string strVechicleDetails = ConvertDataTableToHTML(dtVehicleDetails, strTableClass, strTrClass);
            //Write to divReport
            divVehicleDetails.InnerHtml = strVechicleDetails;
            //Water card details
            strTableClass = "main_table_6";
            strTrClass = "main_table_6_head";
            string strWaterCardDetails = ConvertDataTableToHTML(dtWaterCardDetails, strTableClass, strTrClass, 1);
            //Write to divReport
            divWaterCardDeatils.InnerHtml = strWaterCardDetails;
        }
    }
   
  
    public void LoadBarChartVehicleAllotment(DataTable dtProjectVehicleClass, DataTable dtProjectList)
    {


        DataView view = new DataView(dtProjectVehicleClass);
        DataTable distinctValues = view.ToTable(true, "VHCLCLS_NAME");



        DataTable DtTotal = new DataTable();
        DtTotal.Columns.Add("PROJECT", typeof(string));
        foreach (DataRow dt in distinctValues.Rows)
        {
            DtTotal.Columns.Add(dt["VHCLCLS_NAME"].ToString(), typeof(string));
        }

        //LoadGlobalDetail
        //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        //clsCommonLibrary objCommon = new clsCommonLibrary();

        //objBusinessLayer.LoadGlobalDetail(
        //For corp office
        
        DataRow drDtl2 = DtTotal.NewRow();
    
        if (Session["CORPORATENAME"] != null)
        {
            drDtl2["PROJECT"] = Session["CORPORATENAME"].ToString() + " (Business Unit)";
        }
        else
        {
            drDtl2["PROJECT"] = "Corp Office";
        }
        foreach (DataRow DtFull in dtProjectVehicleClass.Rows)
        {

            foreach (DataRow Dtclas in distinctValues.Rows)
            {
                if (Dtclas["VHCLCLS_NAME"].ToString() == DtFull["VHCLCLS_NAME"].ToString())
                {
                    string ClassName = Dtclas["VHCLCLS_NAME"].ToString();
                    if (drDtl2[ClassName] == DBNull.Value)
                    {
                        drDtl2[ClassName] = DtFull["COUNT"].ToString();
                    }
                    else
                    {
                        string strNewCount = DtFull["COUNT"].ToString();
                        string strCount = drDtl2[ClassName].ToString();
                        decimal deciTotalCount = Convert.ToDecimal(strNewCount) + Convert.ToDecimal(strCount);
                        drDtl2[ClassName] = deciTotalCount.ToString();
                    }
                    string count = DtFull["COUNT"].ToString();
                    string prj = DtFull["PROJECT_NAME"].ToString();
                    string clsn = DtFull["VHCLCLS_NAME"].ToString();
                }

            }
        }
        DtTotal.Rows.Add(drDtl2);
        foreach (DataRow DtPr in dtProjectList.Rows)
        {
            DataRow drDtl = DtTotal.NewRow();
            drDtl["PROJECT"] = DtPr["PROJECT_NAME"].ToString();

            foreach (DataRow DtFull in dtProjectVehicleClass.Rows)
            {
                if (DtPr["PROJECT_NAME"].ToString() == DtFull["PROJECT_NAME"].ToString())
                {
                    foreach (DataRow Dtclas in distinctValues.Rows)
                    {
                        if (Dtclas["VHCLCLS_NAME"].ToString() == DtFull["VHCLCLS_NAME"].ToString())
                        {
                            string ClassName = Dtclas["VHCLCLS_NAME"].ToString();
                            drDtl[ClassName] = DtFull["COUNT"].ToString();
                            string count= DtFull["COUNT"].ToString();
                            string prj = DtFull["PROJECT_NAME"].ToString();
                            string clsn = DtFull["VHCLCLS_NAME"].ToString();
                        }
                        
                    }

                }

            }
            DtTotal.Rows.Add(drDtl);//
        }
        
     

        string strJson = DataTableToJSONWithJavaScriptSerializer(DtTotal);
        string strVhclAllotmentHtml =ConvertDataTableToHTMLReverse(DtTotal);
        divTblVhclAllotmentTbl.InnerHtml = strVhclAllotmentHtml;
        HiddenProjectVhclData.Value = strJson;
        DataView viewPrj = new DataView(dtProjectVehicleClass);
        DataTable distinctPrj = view.ToTable(true, "PROJECT_NAME");
        string strJsonPrj = DataTableToJSONWithJavaScriptSerializer(distinctPrj);
        for (int intProject = 0; intProject < distinctPrj.Rows.Count; intProject++)
        {
            if (HiddenProjectData.Value == "")
            {
                HiddenProjectData.Value += distinctPrj.Rows[intProject]["PROJECT_NAME"].ToString();
            }
            else
            {

                HiddenProjectData.Value += "," + distinctPrj.Rows[intProject]["PROJECT_NAME"].ToString();
            }
        }


        string strJsonVhcl = DataTableToJSONWithJavaScriptSerializer(distinctValues);

        for (int intProject = 0; intProject < distinctValues.Rows.Count; intProject++)
        {

            if (HiddenVhclData.Value == "")
            {
                HiddenVhclData.Value += distinctValues.Rows[intProject]["VHCLCLS_NAME"].ToString();
            }
            else
            {

                HiddenVhclData.Value += "," + distinctValues.Rows[intProject]["VHCLCLS_NAME"].ToString();
            }
        }

    }





    public void LoadBarChartViolation(DataTable dtReadViolationPendingMonthly, DataTable dtReadViolationSettledMonthly)
    {
        int intMonth = 0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        DateTime dateCurrentDate = objBusinessLayer.LoadCurrentDate();
        intMonth = dateCurrentDate.Month;

        int[] intArrViolationSettled = Enumerable.Repeat(1, intMonth).ToArray();
        decimal[] deciArrViolationPending = new decimal[intMonth + 1]; ;
        //pending
        for (int intmonthCount = 0; intmonthCount < intMonth; intmonthCount++)
        {
            deciArrViolationPending[intmonthCount] = 0;
        }
        if (dtReadViolationPendingMonthly.Rows.Count > 0)
        {

            for (int intRowCount = 0; intRowCount < dtReadViolationPendingMonthly.Rows.Count; intRowCount++)
            {
                if (deciArrViolationPending.Length >= dtReadViolationPendingMonthly.Rows.Count)
                {

                    deciArrViolationPending[Convert.ToInt32(dtReadViolationPendingMonthly.Rows[intRowCount]["MONTH"].ToString())] = Convert.ToDecimal(dtReadViolationPendingMonthly.Rows[intRowCount]["AMOUNT"].ToString());
                }
            }
        }
        decimal[] deciArrViolationSettled = new decimal[intMonth + 1]; ;
        //Settled
        for (int intmonthCount = 0; intmonthCount < intMonth; intmonthCount++)
        {
            deciArrViolationSettled[intmonthCount] = 0;
        }
        if (dtReadViolationSettledMonthly.Rows.Count > 0)
        {
            for (int intRowCount = 0; intRowCount < dtReadViolationSettledMonthly.Rows.Count; intRowCount++)
            {
                if (deciArrViolationSettled.Length >= dtReadViolationSettledMonthly.Rows.Count)
                {

                    deciArrViolationSettled[Convert.ToInt32(dtReadViolationSettledMonthly.Rows[intRowCount]["MONTH"].ToString())] = Convert.ToDecimal(dtReadViolationSettledMonthly.Rows[intRowCount]["AMOUNT"].ToString());
                }
            }
        }
        //TO data table
        DataTable dtDetail = new DataTable();
        dtDetail.Columns.Add("MONTH", typeof(string));
        dtDetail.Columns.Add("Settled", typeof(string));
        dtDetail.Columns.Add("Pending", typeof(string));

        for (int intRowCount = 1; intRowCount <= intMonth; intRowCount++)
        {
            string monthName = new DateTime(2010, intRowCount, 1).ToString("MMM", CultureInfo.InvariantCulture);
            DataRow drDtl = dtDetail.NewRow();
            drDtl["MONTH"] = monthName;
            drDtl["Settled"] = deciArrViolationSettled[intRowCount].ToString();
            drDtl["Pending"] = deciArrViolationPending[intRowCount].ToString();
            dtDetail.Rows.Add(drDtl);
        }

        string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
        DataTable dtTransposedDetail = Transpose(dtDetail);
        string strHtmlViolation=""; 
        strHtmlViolation = ConvertDataTableToHTMLViolation(dtTransposedDetail);
        divViolationTbl.InnerHtml = strHtmlViolation;
        hiddenViolationData.Value = strJson;
    }
    private DataTable Transpose(DataTable dt)
    {
        DataTable dtNew = new DataTable();

        //adding columns    
        for (int i = 0; i <= dt.Rows.Count; i++)
        {
            dtNew.Columns.Add(i.ToString());
        }



        //Changing Column Captions: 
        dtNew.Columns[0].ColumnName = " ";

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            //For dateTime columns use like below
           // dtNew.Columns[i + 1].ColumnName = Convert.ToDateTime(dt.Rows[i].ItemArray[0].ToString()).ToString("MM/dd/yyyy");
            //Else just assign the ItermArry[0] to the columnName property
            dtNew.Columns[i + 1].ColumnName = dt.Rows[i].ItemArray[0].ToString();
        }
        //Adding Row Data
        for (int k = 1; k < dt.Columns.Count; k++)
        {
            DataRow r = dtNew.NewRow();
            r[0] = dt.Columns[k].ToString();
            for (int j = 1; j <= dt.Rows.Count; j++)
                r[j] = dt.Rows[j - 1][k];
            dtNew.Rows.Add(r);
        }

        return dtNew;
    }
    public void LoadPieChartDriverAvailChart(DataTable dtDriverAvailChart)
    {
        if (dtDriverAvailChart.Rows.Count > 2)
        {
            //TO data table
            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("label", typeof(string));
            dtDetail.Columns.Add("data", typeof(string));

            decimal deciTotalDrivers = 0;
            decimal deciDriversAllotted = 0;
            decimal deciDriversLeave = 0;
            decimal deciDriversAvailable = 0;
            deciTotalDrivers = Convert.ToDecimal(dtDriverAvailChart.Rows[0]["COUNT"]);
            deciDriversAllotted = Convert.ToDecimal(dtDriverAvailChart.Rows[1]["COUNT"]);
            deciDriversLeave = Convert.ToDecimal(dtDriverAvailChart.Rows[2]["COUNT"]);
            deciDriversAvailable = deciDriversAllotted + deciDriversLeave;
            if (deciTotalDrivers > deciDriversAvailable)
            {
                deciDriversAvailable = deciTotalDrivers - deciDriversAvailable;
            }
            else
            {
                deciDriversAvailable = 0;
            }
            //DataRow drDtl = dtDetail.NewRow();
            //drDtl["label"] = "TOTAL NO. OF DRIVERS";
            //drDtl["data"] = deciTotalDrivers.ToString();
            //dtDetail.Rows.Add(drDtl);

            DataRow drDtl2 = dtDetail.NewRow();
            drDtl2["label"] = "Drivers Allotted";
            drDtl2["data"] = deciDriversAllotted.ToString();
            dtDetail.Rows.Add(drDtl2);

            DataRow drDtl3 = dtDetail.NewRow();
            drDtl3["label"] = "Drivers On Leave";
            drDtl3["data"] = deciDriversLeave.ToString();
            dtDetail.Rows.Add(drDtl3);

            DataRow drDtl4 = dtDetail.NewRow();
            drDtl4["label"] = "Drivers Available";
            drDtl4["data"] = deciDriversAvailable.ToString();
            dtDetail.Rows.Add(drDtl4);

            string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
            hiddenDriverAvailChart.Value = strJson;
        }
        else
        {
            hiddenDriverAvailChart.Value = "";
        }
    }
    public void LoadPieChartVhclInService(DataTable dtVehicleInService)
    {
        if (dtVehicleInService.Rows.Count > 1)
        {
            //TO data table
            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("label", typeof(string));
            dtDetail.Columns.Add("data", typeof(int));

            decimal TotalCount=Convert.ToDecimal(dtVehicleInService.Rows[0]["COUNTTOTAL"].ToString());
            decimal TotalMaintCount=Convert.ToDecimal(dtVehicleInService.Rows[1]["COUNTTOTAL"].ToString());
            TotalCount=TotalCount-TotalMaintCount;
            DataRow drDtl = dtDetail.NewRow();
            drDtl["label"] = "In Service";
            drDtl["data"] = TotalCount.ToString();
            dtDetail.Rows.Add(drDtl);

            DataRow drDtl2 = dtDetail.NewRow();
            drDtl2["label"] = "At Repair";
            drDtl2["data"] = dtVehicleInService.Rows[1]["COUNTTOTAL"].ToString();
            dtDetail.Rows.Add(drDtl2);

            string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
            hiddenVhclByServiceDataPie.Value = strJson;
        }
        else
        {
            hiddenVhclByServiceDataPie.Value = "";
        }
    }
    public void LoadGraphVehicleType(DataTable dtVehicleByYear)
    {
        if (dtVehicleByYear.Rows.Count > 0)
        {
            //TO data table
            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("CLASS NAME", typeof(string));
            dtDetail.Columns.Add("COUNT", typeof(Int32));
            for (int intRowCount = 0; intRowCount < dtVehicleByYear.Rows.Count; intRowCount++)
            {
                DataRow drDtl = dtDetail.NewRow();
                drDtl["CLASS NAME"] = dtVehicleByYear.Rows[intRowCount]["CLASS NAME"].ToString();
                drDtl["COUNT"] = Convert.ToInt32(dtVehicleByYear.Rows[intRowCount]["COUNT"].ToString());
                dtDetail.Rows.Add(drDtl);
            }
            string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
            hiddenVehicleByTypeData.Value = strJson;
        }
        else
        {
            hiddenVehicleByTypeData.Value = "";
        }
    }
    public void LoadGraphVehicleByYear()
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBusinessLayerDashboard objBusinessDashBoard = new clsBusinessLayerDashboard();


        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
       
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLead.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("../../Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityLead.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("../../Default.aspx");
        }
        
        try
        {
            int intYear = 0;
            DateTime dateCurrentDate = objBusinessLayer.LoadCurrentDate();
            //intMonth = DateTime.Today.Month;
            intYear = dateCurrentDate.Year;
            //Graph Vehicle by Year
            int[,] intArrYears = new int[5, 2];
            int intTempYear = intYear;
            for (int intYearCount = 0; intYearCount < 5; intYearCount++)
            {
                intArrYears[intYearCount, 0] = intTempYear;
                intArrYears[intYearCount, 1] = 0;
                intTempYear--;
            }
            for (int intYearCount = 0; intYearCount < 5; intYearCount++)
            {
                objEntityLead.FinYearId = intArrYears[intYearCount, 0];
                DataTable dtVehicleByYear = new DataTable();
                dtVehicleByYear = objBusinessDashBoard.Read_Vehicle_ByYear(objEntityLead);
                if (dtVehicleByYear.Rows.Count > 0)
                {
                    if (dtVehicleByYear.Rows[0]["COUNT"].ToString() != "")
                    {
                        intArrYears[intYearCount, 1] = Convert.ToInt32(dtVehicleByYear.Rows[0]["COUNT"].ToString());
                    }
                }
            }
            //if (dtVehicleByYear.Rows.Count > 0)
            //{
            //    for (int intRowCount = 0; intRowCount < dtVehicleByYear.Rows.Count; intRowCount++)
            //    {
            //        for (int intYearCount = 0; intYearCount < 5; intYearCount++)
            //        {
            //            if (Convert.ToInt32(dtVehicleByYear.Rows[intRowCount]["YEAR"].ToString()) == intArrYears[intYearCount, 0])
            //            {
            //                intArrYears[intYearCount, 1] = Convert.ToInt32(dtVehicleByYear.Rows[intRowCount]["COUNT"].ToString());
            //            }
            //        }
            //    }
            //}
            //TO data table
            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("YEAR", typeof(string));
            dtDetail.Columns.Add("COUNT", typeof(Int32));

            for (int intYearCount = 4; intYearCount >= 0; intYearCount--)
            {

                DataRow drDtl = dtDetail.NewRow();
                drDtl["YEAR"] = intArrYears[intYearCount, 0].ToString();
                drDtl["COUNT"] =Convert.ToInt32( intArrYears[intYearCount, 1].ToString());
                dtDetail.Rows.Add(drDtl);
            }
            string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
            hiddenVehicleByYearData.Value = strJson;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }
    public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
    {
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
        Dictionary<string, object> childRow;
        foreach (DataRow row in table.Rows)
        {
            childRow = new Dictionary<string, object>();
            foreach (DataColumn col in table.Columns)
            {
                childRow.Add(col.ColumnName, row[col]);

            }

            parentRow.Add(childRow);
        }
        return jsSerializer.Serialize(parentRow);
    }
    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, string strTableClass, string strTrClass, int intMode = 0)
    {
        string strPath = "";
        //intMode =1 for water card detail table
        if (intMode == 1)
        {
            strPath = "/AWMS/AWMS_Master/gen_Water_Card_Master/gen_Water_Card_Master.aspx?Id=";
        }
        else
        {
            strPath = "/AWMS/AWMS_Master/gen_Vehicle_Master/gen_Vehicle_Master.aspx?Id=";
        }
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dtCurrencyDetails = new DataTable();
        if (hiddenDfltCurrencyMstrId.Value!="")
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        dtCurrencyDetails = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
        string strCurrencyAbbr = "";
        if (dtCurrencyDetails.Rows.Count > 0)
        {
            strCurrencyAbbr = dtCurrencyDetails.Rows[0]["CRNCMST_ABBRV"].ToString();
        }
        string strRandom = objCommon.Random_Number();
        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable" + intMode + "\" class=\"" + strTableClass + "\" cellspacing=\"0\" cellpadding=\"2px\" style=\"margin-bottom: 0px;width: 98.7%;\">";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"" + strTrClass + "\">";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:5%;text-align: center; word-wrap:break-word;\">SL#</th>";
            }
            else if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                if(intMode==0)
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                else
                    strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: right; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                if (intMode == 0)
                    strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                else
                    strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

        }
        strHtml += "</tr>";
       // strHtml += strHtmlTblHead;
        strHtml += "</thead>";
        
     
        //add rows
        strHtml += "<tbody>";
        int intSlNO = 1;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr  >";

            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                if (intColumnBodyCount == 0)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + intSlNO + "</td>";
                }
                else if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><a href=" + strPath + Id+">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a></td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 3)
                {
                    if (intMode == 0)
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    else
                    {
                        string rcptAmnt = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                        string commaRcptAmnt = objBusinessLayer.AddCommasForNumberSeperation(rcptAmnt, objEntityCommon);
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + commaRcptAmnt + " </td>";
                    }
                }
                else if (intColumnBodyCount == 4)
                {
                    if (intMode == 0)
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    else
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 6)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 7)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

            }
            intSlNO++;
            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
    }
    public string ConvertDataTableToHTMLReverse(DataTable dt)
    {
        StringBuilder sb = new StringBuilder();
        HiddenColorList.Value = "";
        string strColors = "";
        string strHtml = "<table class=\"table2 table-bordered\"  cellspacing=\"0\">";
        //add header row
        strHtml += "<tr>";
        var random = new Random();
        for (int i = 0; i < dt.Columns.Count; i++)
        {
            var color="";
            if (i > 0)
            {
                
                color = String.Format("#{0:X6}", random.Next(0x1000000));
                if (strColors != "")
                {
                    strColors += "," + color;
                }
                else
                {
                    strColors = color;
                }
            }

            strHtml += "<td><span class=\"vhcle_color\" style=\"background:"+ color+"\"></span>" + dt.Columns[i].ColumnName + "</td>";
        }
        strHtml += "</tr>";
        HiddenColorList.Value = strColors;
        //add rows
        for (int i = 1; i < dt.Rows.Count; i++)
        {
            strHtml += "<tr>";
            for (int j = 0; j < dt.Columns.Count; j++)
                strHtml += "<td>" + dt.Rows[i][j].ToString() + "</td>";
            strHtml += "</tr>";
        }
        strHtml += "<tr style=\"background-color: #b3baba;\">";
        for (int j = 0; j < dt.Columns.Count; j++)
        strHtml += "<td>" + dt.Rows[0][j].ToString() + "</td>";
        strHtml += "</tr>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return strHtml;
    }
    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTMLViolation(DataTable dt)
    {
        //only for VIOLATIONS-MONTH WISE Table
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"table2 table-bordered\" cellspacing=\"0\" cellpadding=\"2px\" style=\"margin-bottom: 0px;width: 98.7%;\">";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"thT\" style=\"text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\"  style=\"text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\"  style=\"text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            
            else if (intColumnHeaderCount == 8)
            {
                strHtml += "<th class=\"thT\"  style=\"text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 9)
            {
                strHtml += "<th class=\"thT\"  style=\"text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 10)
            {
                strHtml += "<th class=\"thT\"  style=\"text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 11)
            {
                strHtml += "<th class=\"thT\"  style=\"text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 12)
            {
                //width:10%;
                strHtml += "<th class=\"thT\"  style=\"text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

        }
        strHtml += "</tr>";
        // strHtml += strHtmlTblHead;
        strHtml += "</thead>";


        //add rows
        strHtml += "<tbody>";
        string[] strArrColor = new string[] { "#5b9bd5", "#ed7d31", "#a4a4a4" };
        int intColorCount = 0;
        decimal[] deciArrAmount = new decimal[13];
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr  >";

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                if (intColumnBodyCount == 0)
                {
                    strHtml += "<td class=\"tdT\" style=\" word-break: break-all; word-wrap:break-word;text-align: left;\"  ><span class=\"vhcle_color\" style=\"background:" + strArrColor[intColorCount] + "\"></span>" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    deciArrAmount[1] = deciArrAmount[1] + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount]);
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    deciArrAmount[2] = deciArrAmount[2] + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount]);
                }
                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    deciArrAmount[3] = deciArrAmount[3] + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount]);
                }
                else if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    deciArrAmount[4] = deciArrAmount[4] + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount]);
                }
                else if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    deciArrAmount[5] = deciArrAmount[5] + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount]);
                }
                else if (intColumnBodyCount == 6)
                {
                    strHtml += "<td class=\"tdT\" style=\" word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    deciArrAmount[6] = deciArrAmount[6] + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount]);
                }
                else if (intColumnBodyCount == 7)
                {
                    strHtml += "<td class=\"tdT\" style=\" word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    deciArrAmount[7] = deciArrAmount[7] + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount]);
                }
                else if (intColumnBodyCount == 8)
                {
                    strHtml += "<td class=\"tdT\" style=\" word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    deciArrAmount[8] = deciArrAmount[8] + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount]);
                }
                else if (intColumnBodyCount == 9)
                {
                    strHtml += "<td class=\"tdT\" style=\" word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    deciArrAmount[9] = deciArrAmount[9] + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount]);
                }
                else if (intColumnBodyCount == 10)
                {
                    strHtml += "<td class=\"tdT\" style=\" word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    deciArrAmount[10] = deciArrAmount[10] + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount]);
                }
                else if (intColumnBodyCount == 11)
                {
                    strHtml += "<td class=\"tdT\" style=\" word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    deciArrAmount[11] = deciArrAmount[11] + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount]);
                }
                else if (intColumnBodyCount == 12)
                {
                    strHtml += "<td class=\"tdT\" style=\" word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    deciArrAmount[12] = deciArrAmount[12] + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount]);
                }
            }
            strHtml += "</tr>";
           
            intColorCount++;

        }
        strHtml += "<tr  >";
        strHtml += "<td class=\"tdT\" style=\" word-break: break-all; word-wrap:break-word;text-align: left;\"  ><span class=\"vhcle_color\" style=\"background:" + strArrColor[intColorCount] + "\"></span> Total Amount </td>";
        for (int intColumnBodyCount = 1; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
        {
            strHtml += "<td class=\"tdT\" style=\" word-break: break-all; word-wrap:break-word;text-align: left;\">" + deciArrAmount[intColumnBodyCount] + "</td>";

        }
        strHtml += "</tr>";

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
    }
   
    public void BindDdlYears(string strYear = null)
    {
        var currentYear = DateTime.Today.Year;
        currentYear = currentYear + 10;
        for (int i = 20; i >= 0; i--)
        {
            ddlFromYearPermit.Items.Add((currentYear - i).ToString());
            ddlToYearPermit.Items.Add((currentYear - i).ToString());
            ddlFromYearInsu.Items.Add((currentYear - i).ToString());
            ddlToYearInsu.Items.Add((currentYear - i).ToString());
        }
        ////ddlFromYearPermit.Items.Insert(0, "--SELECT--");
        ////ddlToYearPermit.Items.Insert(0, "--SELECT--");
        ////ddlFromYearInsu.Items.Insert(0, "--SELECT--");
        ////ddlToYearInsu.Items.Insert(0, "--SELECT--");

        if (strYear != null)
        {
            if (ddlFromYearPermit.Items.FindByValue(strYear) != null)
            {
                ddlFromYearPermit.Items.FindByValue(strYear).Selected = true;
            }
            if (ddlToYearPermit.Items.FindByValue(strYear) != null)
            {
                ddlToYearPermit.Items.FindByValue(strYear).Selected = true;
            }
            if (ddlFromYearInsu.Items.FindByValue(strYear) != null)
            {
                ddlFromYearInsu.Items.FindByValue(strYear).Selected = true;
            }
            if (ddlToYearInsu.Items.FindByValue(strYear) != null)
            {
                ddlToYearInsu.Items.FindByValue(strYear).Selected = true;
            }
        }
      
    }
    public void BindDdlMonths(string strMonth = null)
    {
        var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
        for (int i = 0; i < months.Length - 1; i++)
        {
            ddlToMonthInsu.Items.Add(new ListItem(months[i], (i + 1).ToString()));
            ddlFromMonthInsu.Items.Add(new ListItem(months[i], (i + 1).ToString()));
            ddlFromMonthPermit.Items.Add(new ListItem(months[i], (i + 1).ToString()));
            ddlToMonthPermit.Items.Add(new ListItem(months[i], (i + 1).ToString()));
        }
        //if (strMonth != null)
        //{
        //    if (ddlToMonthInsu.Items.FindByValue(strMonth) != null)
        //    {
        //        ddlMonths.Items.FindByValue(strMonth).Selected = true;
        //    }
        //}
        ////ddlToMonthInsu.Items.Insert(0, "--SELECT--");
        ////ddlFromMonthInsu.Items.Insert(0, "--SELECT--");
        ////ddlFromMonthPermit.Items.Insert(0, "--SELECT--");
        ////ddlToMonthPermit.Items.Insert(0, "--SELECT--");

    }
    class clsDynamicBarChart
    {
        public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);

                }

                parentRow.Add(childRow);
            }
            return jsSerializer.Serialize(parentRow);
        }
        public string LoadBarChartPermit(DataTable dtPermit, int intMonthlySts, DateTime dateFromdate, DateTime dateTodate)
        {
            if (intMonthlySts == 1)
            {
                //monthly
                int intTOMonth = 0, intFromMonth = 0;
                clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                //DateTime dateCurrentDate = objBusinessLayer.LoadCurrentDate();
                intTOMonth = dateTodate.Month;
                intFromMonth = dateFromdate.Month;
                int[] intArrViolationSettled = Enumerable.Repeat(intFromMonth, intTOMonth).ToArray();
                decimal[] deciArrViolationPending = new decimal[intTOMonth + 1]; ;
                for (int intmonthCount = 0; intmonthCount < intTOMonth; intmonthCount++)
                {
                    deciArrViolationPending[intmonthCount] = 0;
                }
                if (dtPermit.Rows.Count > 0)
                {

                    for (int intRowCount = 0; intRowCount < dtPermit.Rows.Count; intRowCount++)
                    {
                        if (deciArrViolationPending.Length >= dtPermit.Rows.Count)
                        {

                            deciArrViolationPending[Convert.ToInt32(dtPermit.Rows[intRowCount]["DATE"].ToString())] = Convert.ToDecimal(dtPermit.Rows[intRowCount]["COUNT"].ToString());
                        }
                    }
                }
                //TO data table
                DataTable dtDetail = new DataTable();
                dtDetail.Columns.Add("DATE", typeof(string));
                dtDetail.Columns.Add("COUNT", typeof(string));

                for (int intRowCount = intFromMonth; intRowCount <= intTOMonth; intRowCount++)
                {
                    string monthName = new DateTime(2010, intRowCount, 1).ToString("MMM", CultureInfo.InvariantCulture);
                    DataRow drDtl = dtDetail.NewRow();
                    drDtl["DATE"] = monthName;
                    drDtl["COUNT"] = deciArrViolationPending[intRowCount].ToString();
                    dtDetail.Rows.Add(drDtl);
                }

                string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
                return strJson;
                //DataTable dtTransposedDetail = Transpose(dtDetail);
                //string strHtmlViolation = "";
                //strHtmlViolation = ConvertDataTableToHTMLViolation(dtTransposedDetail);
                //divViolationTbl.InnerHtml = strHtmlViolation;
                //hiddenViolationData.Value = strJson;
            }
            else
            {
                //yearly
                int intToYear = 0, intFromYear = 0;
                clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                //DateTime dateCurrentDate = objBusinessLayer.LoadCurrentDate();
                intToYear = dateTodate.Year;
                intFromYear = dateFromdate.Year;
                int inTotalYears = intToYear - intFromYear;
                int intYear = 0;
                DateTime dateCurrentDate = objBusinessLayer.LoadCurrentDate();
                //intMonth = DateTime.Today.Month;
                intYear = dateCurrentDate.Year;
                //Graph Vehicle by Year
                int[,] intArrYears = new int[inTotalYears + 1, 2];
                int intTempYear = intFromYear;
                for (int intYearCount = 0; intYearCount <= inTotalYears; intYearCount++)
                {
                    intArrYears[intYearCount, 0] = intTempYear;
                    intArrYears[intYearCount, 1] = 0;
                    intTempYear++;

                }
                if (dtPermit.Rows.Count > 0)
                {
                    for (int intRowCount = 0; intRowCount < dtPermit.Rows.Count; intRowCount++)
                    {
                        for (int intYearCount = 0; intYearCount <= inTotalYears; intYearCount++)
                        {
                            // objEntityLead.FinYearId = intArrYears[intYearCount, 0];


                            if (dtPermit.Rows[intRowCount]["COUNT"].ToString() != "" && Convert.ToInt32(dtPermit.Rows[intRowCount]["DATE"].ToString()) == intArrYears[intYearCount, 0])
                            {
                                intArrYears[intYearCount, 1] = Convert.ToInt32(dtPermit.Rows[intRowCount]["COUNT"].ToString());
                            }

                        }
                    }
                }
                //TO data table
                DataTable dtDetail = new DataTable();
                dtDetail.Columns.Add("DATE", typeof(string));
                dtDetail.Columns.Add("COUNT", typeof(Int32));

                for (int intYearCount = 0; intYearCount <= inTotalYears; intYearCount++)
                {
                    DataRow drDtl = dtDetail.NewRow();
                    drDtl["DATE"] = intArrYears[intYearCount, 0].ToString();
                    drDtl["COUNT"] = Convert.ToInt32(intArrYears[intYearCount, 1].ToString());
                    dtDetail.Rows.Add(drDtl);
                }
                string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
               // hiddenVehicleByYearData.Value = strJson;
                return strJson;
            }

        }
    }
    [WebMethod]
    public static string GenerateBarChart(int OrgId, int CorpId,int FromYear,int ToYear,int ToMonth,int FromMonth,int BarType)
    {
        clsDynamicBarChart objDynamiChart = new clsDynamicBarChart();

        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
        clsBusinessLayerDashboard objBusinessDashBoard = new clsBusinessLayerDashboard();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        objEntityLead.Corp_Id = CorpId;
        objEntityLead.Org_Id = OrgId;

        //dateToDate =new  DateTime(dateTime.Year,dateTime.Month,dateTime.Day);
        int intFromYearPermit, intFromMonthPermit, intToYearPermit, intToMonthPermit;
        // intFromYearInsu, intFromMonthInsu, intToYearInsu, intToMonthInsu;
        intFromYearPermit = FromYear;
        intFromMonthPermit = FromMonth;
        intToMonthPermit = ToMonth;
        intToYearPermit = ToYear;

        // intToYearInsu = Convert.ToInt32(ddlToYearPermit.SelectedItem.Value);
        // intToMonthInsu = Convert.ToInt32(ddlToMonthInsu.SelectedItem.Value);
        string strFromDate = intFromMonthPermit.ToString("D2") + "/" + intFromYearPermit;
        string strToDate =  intToMonthPermit.ToString("D2") + "/" + intToYearPermit;
        string strtemDateFrom="01/"+intFromMonthPermit.ToString("D2") + "/" + intFromYearPermit;
        string strtemDateTo = "01/" + intToMonthPermit.ToString("D2") + "/" + intToYearPermit;

        DateTime dateFromdate = objCommon.textToDateTime(strtemDateFrom);
        DateTime dateTodate = objCommon.textToDateTime(strtemDateTo);
        string strJson = "";
       
            // valid case
            if (intFromYearPermit == intToYearPermit)
            {
                objEntityLead.Status = 1;
            }
            else
            {
                objEntityLead.Status = 0;
            }
            //string strTempDate = "", strTempDate2="";
            //DateTime dateFromDate = Convert.ToDateTime(strFromDate);
            //strTempDate = dateFromDate.ToString("dd-MM-yyyy");
            //strTempDate = String.Format("{0:dd-MM-yyyy}", strTempDate);


            //objEntityLead.FromDateDB = objCommon.textToDateTime(strTempDate);

            //DateTime dateToDate = Convert.ToDateTime(strToDate);
            //strTempDate2 = dateToDate.ToString("dd-MM-yyyy");
            //strTempDate2 = String.Format("{0:dd-MM-yyyy}", strTempDate2);

            //objEntityLead.TodateDB = objCommon.textToDateTime(strTempDate2); ;


            objEntityLead.From_Date = strFromDate;
            objEntityLead.To_Date = strToDate;
            //load permit graph
            DataTable dtInsu = new DataTable();


            if (BarType == 1)
            {
                //permit
                dtInsu = objBusinessDashBoard.ReadPermitCount(objEntityLead);
            }
            else
            {
                //insu
                dtInsu = objBusinessDashBoard.ReadInsurCount(objEntityLead);
            }
            if (dtInsu.Rows.Count > 0)
            {
                strJson = objDynamiChart.LoadBarChartPermit(dtInsu, objEntityLead.Status, dateFromdate, dateTodate);
            }
            else
            {
                strJson = "";
            }
            
        
       

        return strJson;
        
    }

}