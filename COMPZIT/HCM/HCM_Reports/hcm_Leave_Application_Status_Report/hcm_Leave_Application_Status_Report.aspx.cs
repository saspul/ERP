using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Globalization;
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
using iTextSharp.text.pdf;
public partial class HCM_HCM_Reports_hcm_Leave_Application_Status_Report_hcm_Leave_Application_Status_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDepartment();
            LoadLeaveType();
            LoadDivision();
            LoadJob();

            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                 objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }   
            txtToDate.Value =objBusiness.LoadCurrentDate().ToString("dd-MM-yyyy");
            DateTime CurrntDate = objCommon.textToDateTime(txtToDate.Value);           
            txtFromDate.Value = CurrntDate.AddDays(-30).ToString("dd-MM-yyyy");
            HiddenFieldFromDate.Value = txtFromDate.Value;
            HiddenFieldToDate.Value = txtToDate.Value;
            HiddenFieldCategory.Value = ddlCategory.Value;
            HiddenFieldSummary.Value = ddlSummaryType.Value;
            Search();
        }
    }
 
    public void LoadDepartment()
    {
        clsEntityLeaveApplicationStatusReport objEntityBulkPrint = new clsEntityLeaveApplicationStatusReport();
        clsBusinessLeaveApplicationStsReport objBusiness = new clsBusinessLeaveApplicationStsReport();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityBulkPrint.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityBulkPrint.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dt = objBusiness.LoadDepartment(objEntityBulkPrint);
        if (dt.Rows.Count > 0)
        {
            ddlDepartment.DataSource = dt;
            ddlDepartment.DataTextField = "CPRDEPT_NAME";
            ddlDepartment.DataValueField = "CPRDEPT_ID";
            ddlDepartment.DataBind();
        }
    }
    public void LoadLeaveType()
    {
        clsEntityLeaveApplicationStatusReport objEntityBulkPrint = new clsEntityLeaveApplicationStatusReport();
        clsBusinessLeaveApplicationStsReport objBusiness = new clsBusinessLeaveApplicationStsReport();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityBulkPrint.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityBulkPrint.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dt = objBusiness.LoadLeaveType(objEntityBulkPrint);
        if (dt.Rows.Count > 0)
        {
            ddlLeaveType.DataSource = dt;
            ddlLeaveType.DataTextField = "LEAVETYP_NAME";
            ddlLeaveType.DataValueField = "LEAVETYP_ID";
            ddlLeaveType.DataBind();
        }
    }
    public void LoadDivision()
    {
        clsEntityLeaveApplicationStatusReport objEntityBulkPrint = new clsEntityLeaveApplicationStatusReport();
        clsBusinessLeaveApplicationStsReport objBusiness = new clsBusinessLeaveApplicationStsReport();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityBulkPrint.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityBulkPrint.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dt = objBusiness.LoadDivison(objEntityBulkPrint);
        if (dt.Rows.Count > 0)
        {
            ddlDivision.DataSource = dt;
            ddlDivision.DataTextField = "CPRDIV_NAME";
            ddlDivision.DataValueField = "CPRDIV_ID";
            ddlDivision.DataBind();
        }
    }
    public void LoadJob()
    {
        clsEntityLeaveApplicationStatusReport objEntityBulkPrint = new clsEntityLeaveApplicationStatusReport();
        clsBusinessLeaveApplicationStsReport objBusiness = new clsBusinessLeaveApplicationStsReport();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityBulkPrint.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityBulkPrint.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dt = objBusiness.LoadJob(objEntityBulkPrint);
        if (dt.Rows.Count > 0)
        {
            ddlJob.DataSource = dt;
            ddlJob.DataTextField = "JOBMSTR_TITLE";
            ddlJob.DataValueField = "JOBMSTR_ID";
            ddlJob.DataBind();
        }
    }
    public void Search()
    {
        clsEntityLeaveApplicationStatusReport objEntityJoiningList = new clsEntityLeaveApplicationStatusReport();
        clsBusinessLeaveApplicationStsReport objBusiness = new clsBusinessLeaveApplicationStsReport();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJoiningList.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityJoiningList.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityJoiningList.LeaveTypeId = HiddenFieldLeaveType.Value;
        objEntityJoiningList.DepartmentId = HiddenFieldDept.Value;
        objEntityJoiningList.DivisionId = HiddenFieldDivision.Value;
        objEntityJoiningList.JobId = HiddenFieldJob.Value;
        objEntityJoiningList.Status = HiddenFieldStatus.Value;
        if (txtFromDate.Value.Trim() != "")
        {
            objEntityJoiningList.FromDate = objCommon.textToDateTime(txtFromDate.Value.Trim());
        }
        if (txtToDate.Value.Trim() != "")
        {
            objEntityJoiningList.Todate = objCommon.textToDateTime(txtToDate.Value.Trim());
        }
        objEntityJoiningList.CategoryId = Convert.ToInt32(ddlCategory.Value);
        objEntityJoiningList.SummaryTypeId = Convert.ToInt32(ddlSummaryType.Value);
        DataTable dt = objBusiness.ReadSummaryTypeList(objEntityJoiningList);
        string strHtml = "";
        int total = 0;

        DataTable dtDetail = new DataTable();
        dtDetail.Columns.Add("CLASS NAME", typeof(string));
        dtDetail.Columns.Add("COUNT", typeof(Int32));


        for (int i = 0; i < dt.Rows.Count; i++)
        {
            total += Convert.ToInt32(dt.Rows[i][2].ToString());
            strHtml += "<tr>";
            strHtml += "<td class=\"tr_l\">" + dt.Rows[i][1].ToString() + "</td>";
            strHtml += "<td><a onclick=\"return ShowSummarySingle('" + dt.Rows[i][0].ToString() + "'," + dt.Rows[i][2].ToString() + ");\" href=\"#\" class=\"bt_sumry_2\">" + dt.Rows[i][2].ToString() + "</a></td>";
            strHtml += "<td class=\"\"><span class=\"spn_bt_opn tr_r flt_r\" style=\"display:block;\">";
            strHtml += "<button onclick=\"return ShowSummarySingle('" + dt.Rows[i][0].ToString() + "'," + dt.Rows[i][2].ToString() + ");\" class=\"btn_ic_ds ds_ic1 bt_sumry_2\" title=\"Summary\"><i class=\"fa fa-newspaper-o \" aria-hidden=\"true\"></i></button><a href=\"#area_sec1\">";
            strHtml += "<button onclick=\"return ShowSummaryLevel3('','','','',''," + dt.Rows[i][2].ToString() + ",'" + dt.Rows[i][0].ToString() + "','','L1');\" href=\"#area_sec1\" class=\"btn_ic_ds ds_ic2 bt_dtl_1\" title=\"Details\"><i class=\"fa fa-file-text\" aria-hidden=\"true\"></i></button>";
            strHtml += "</a></span></td></tr>";

            DataRow drDtl = dtDetail.NewRow();
            drDtl["CLASS NAME"] = dt.Rows[i][1].ToString();
            drDtl["COUNT"] = Convert.ToInt32(dt.Rows[i][2].ToString());
            dtDetail.Rows.Add(drDtl);

        }
        string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
        HiddenFieldGraphData.Value = strJson;


        HiddenFieldMainTotCnt.Value = total.ToString();
        if (dt.Rows.Count == 0)
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tr_c\" colspan=\"3\">No data available</td></tr>";
        }
        tbodyLevel1.InnerHtml = strHtml;
        if (total > 0)
        {
            strHtml = "<tr><th>Total</th><th>";
            strHtml += "<a onclick=\"return ShowSummaryLevel3('','','','',''," + total + ",'','','L1');\" href=\"#area_sec1\" class=\"bt_dtl_1\">" + total + "</a>";
            strHtml += "</th><th></th></tr>";
            tFootLevel1.InnerHtml = strHtml;
            graphCnt.InnerHtml = total.ToString();
        }
        else
        {
            tFootLevel1.InnerHtml = "";
            graphCnt.InnerHtml = "";
        }
        thHeadLevel1.InnerText = ddlSummaryType.Items[ddlSummaryType.SelectedIndex].Text;
        headLevel2.InnerText = ddlSummaryType.Items[ddlSummaryType.SelectedIndex].Text + " Summary";
        theadLevel3.InnerText = ddlSummaryType.Items[ddlSummaryType.SelectedIndex].Text + " Details";
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Search();
    }
    [System.Web.Services.WebMethod]
    public static string LoadSummarySingleDtls(string OrgIdID, string CorpID, string DeptIds, string DivsIds, string JobIds, string StatusIds, string LeaveTypIds, string FromDate, string ToDate, string CategoryID, string SummaryID, string SumTypeId, string ShowLeavTyp, string ShowDept, string ShowDivs, string ShowCtgry, string ShowStatus)
    {
        string strHtml = "";
        try
        {
            clsEntityLeaveApplicationStatusReport objEntityJoiningList = new clsEntityLeaveApplicationStatusReport();
            clsBusinessLeaveApplicationStsReport objBusiness = new clsBusinessLeaveApplicationStsReport();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            objEntityJoiningList.CorpId = Convert.ToInt32(CorpID);
            objEntityJoiningList.OrgId = Convert.ToInt32(OrgIdID);
            objEntityJoiningList.LeaveTypeId = LeaveTypIds;
            objEntityJoiningList.DepartmentId = DeptIds;
            objEntityJoiningList.DivisionId = DivsIds;
            objEntityJoiningList.JobId = JobIds;
            objEntityJoiningList.Status = StatusIds;
            if (FromDate.Trim() != "")
            {
                objEntityJoiningList.FromDate = objCommon.textToDateTime(FromDate.Trim());
            }
            if (ToDate.Trim() != "")
            {
                objEntityJoiningList.Todate = objCommon.textToDateTime(ToDate.Trim());
            }
            objEntityJoiningList.CategoryId = Convert.ToInt32(CategoryID);
            objEntityJoiningList.SummaryTypeId = Convert.ToInt32(SummaryID);
            objEntityJoiningList.SummaryTypeIdInd = Convert.ToInt32(SumTypeId);

            string queryCol = "";
            if (ShowLeavTyp == "1")
            {
               queryCol = "LEAVETYP_ID,LEAVETYP_NAME";
            }
            if (ShowDept == "1")
            {
                if (queryCol == "")
                {
                    queryCol = "CPRDEPT_ID,CPRDEPT_NAME";
                }
                else
                {
                    queryCol += ",CPRDEPT_ID,CPRDEPT_NAME";
                }
            }
            if (ShowDivs == "1")
            {
                if (queryCol == "")
                {
                    queryCol = "CPRDIV_ID,CPRDIV_NAME";
                }
                else
                {
                    queryCol += ",CPRDIV_ID,CPRDIV_NAME";
                }
            }
            if (ShowCtgry == "1")
            {
                if (queryCol == "")
                {
                    queryCol = "STAFF_WORKER,STAFF_WORKER_NAME";
                }
                else
                {
                    queryCol += ",STAFF_WORKER,STAFF_WORKER_NAME";
                }
            }
            if (ShowStatus == "1")
            {
                if (queryCol == "")
                {
                    queryCol = "STATUS_ID,STATUS_NAME";
                }
                else
                {
                    queryCol += ",STATUS_ID,STATUS_NAME";
                }
            }
            objEntityJoiningList.QueryColumns = queryCol;
            DataTable dt = objBusiness.ReadSummaryTypeListSingle(objEntityJoiningList);     
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strDept = "", strDiv = "", strLevTyp = "", strCtgry = "", strSts = "";
                string strDeptI = "", strDivI = "", strLevTypI = "", strCtgryI = "", strStsI = "";
                if (ShowLeavTyp == "1")
                {
                    strLevTyp = dt.Rows[i]["LEAVETYP_NAME"].ToString();
                    strLevTypI = dt.Rows[i]["LEAVETYP_ID"].ToString();
                }
                if (ShowDept == "1")
                {
                    strDept = dt.Rows[i]["CPRDEPT_NAME"].ToString();
                    strDeptI = dt.Rows[i]["CPRDEPT_ID"].ToString();
                }
                if (ShowDivs == "1")
                {
                    strDiv = dt.Rows[i]["CPRDIV_NAME"].ToString();
                    strDivI = dt.Rows[i]["CPRDIV_ID"].ToString();
                }
                if (ShowCtgry == "1")
                {
                    strCtgry = dt.Rows[i]["STAFF_WORKER_NAME"].ToString();
                    strCtgryI = dt.Rows[i]["STAFF_WORKER"].ToString();
                }
                if (ShowStatus == "1")
                {
                    strSts = dt.Rows[i]["STATUS_NAME"].ToString();
                    strStsI = dt.Rows[i]["STATUS_ID"].ToString();
                }
                strHtml += "<tr>";
                strHtml += "<td class=\"tr_l dep_1 grq1\">" + strDept + "</td>";
                strHtml += "<td class=\"tr_l div_1 grq2\">" + strDiv + "</td>";
                strHtml += "<td class=\"tr_l lev_1 grq0\">" + strLevTyp + "</td>";
                strHtml += "<td class=\"tr_l cat_1 grq3\">" + strCtgry + "</td>";
                strHtml += "<td class=\"tr_l job_1 grq4\"></td>";
                strHtml += "<td class=\"tr_l sta_1 grq5\">" + strSts + "</td>";
                strHtml += "<td><a onclick=\"return ShowSummaryLevel3('" + strDeptI + "','" + strDivI + "','" + strLevTypI + "','" + strCtgryI + "','" + strStsI+ "'," + dt.Rows[i]["CNT"].ToString() + ",'','','L2');\" href=\"#\" class=\"bt_dtl_1\">" + dt.Rows[i]["CNT"].ToString() + "</a></td>";
                strHtml += "</tr>";                          
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return strHtml;
    }
    [System.Web.Services.WebMethod]
    public static string ShowSummaryLevel3(string OrgIdID, string CorpID, string DeptIds, string DivsIds, string JobIds, string StatusIds, string LeaveTypIds, string FromDate, string ToDate, string CategoryID, string SummaryID, string IndSumTypeId,string Level,string HideCols)
    {
        string strHtml = "";
        try
        {
            clsEntityLeaveApplicationStatusReport objEntityJoiningList = new clsEntityLeaveApplicationStatusReport();
            clsBusinessLeaveApplicationStsReport objBusiness = new clsBusinessLeaveApplicationStsReport();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            objEntityJoiningList.CorpId = Convert.ToInt32(CorpID);
            objEntityJoiningList.OrgId = Convert.ToInt32(OrgIdID);
            objEntityJoiningList.LeaveTypeId = LeaveTypIds;
            objEntityJoiningList.DepartmentId = DeptIds;
            objEntityJoiningList.DivisionId = DivsIds;
            objEntityJoiningList.JobId = JobIds;
            objEntityJoiningList.Status = StatusIds;
            if (FromDate.Trim() != "")
            {
                objEntityJoiningList.FromDate = objCommon.textToDateTime(FromDate.Trim());
            }
            if (ToDate.Trim() != "")
            {
                objEntityJoiningList.Todate = objCommon.textToDateTime(ToDate.Trim());
            }
            if (CategoryID != "")
            {
                objEntityJoiningList.CategoryId = Convert.ToInt32(CategoryID);
            }
            else
            {
                objEntityJoiningList.CategoryId = 2;
            }
            objEntityJoiningList.SummaryTypeId = Convert.ToInt32(SummaryID);
            if (IndSumTypeId != "")
            {
                objEntityJoiningList.SummaryTypeIdInd = Convert.ToInt32(IndSumTypeId);
            }
            else
            {
                objEntityJoiningList.SummaryTypeIdInd = -1;
            }
            DataTable dt = objBusiness.ReadSummaryLeaveDtls(objEntityJoiningList);

            DataView dtview = new DataView(dt);
            DataTable dtDistdept = new DataTable();
            string strSumTypCol = "";
            if (Level == "0")
            {
                dtDistdept = dtview.ToTable(true, "LEAVETYP_NAME");
                strSumTypCol = "LEAVETYP_NAME";
            }
            else if (Level == "1")
            {
                dtDistdept = dtview.ToTable(true, "CPRDEPT_NAME");
                strSumTypCol = "CPRDEPT_NAME";
            }
            else if (Level == "2")
            {
                dtDistdept = dtview.ToTable(true, "CPRDIV_NAME");
                strSumTypCol = "CPRDIV_NAME";
            }
            else if (Level == "3")
            {
                dtDistdept = dtview.ToTable(true, "STAFF_WORKER_NAME");
                strSumTypCol = "STAFF_WORKER_NAME";
            }
            else if (Level == "5")
            {
                dtDistdept = dtview.ToTable(true, "STATUS_NAME");
                strSumTypCol = "STATUS_NAME";
            }
            for (int i = 0; i < dtDistdept.Rows.Count; i++)
            {
                strHtml += "<tr>";
                strHtml += "<td class=\"tr_l clr_hrd1 col6\">" + dtDistdept.Rows[i][0].ToString() + "</td>";
                strHtml += "<td class=\"tr_l clr_hrd1 ap_r col7\"></td>";
                strHtml += "<td class=\"tr_l clr_hrd1 da_r col8\"></td>";
                strHtml += "<td class=\"tr_l clr_hrd1 em_r col9\"></td>";
                strHtml += "<td class=\"tr_l clr_hrd1 em_r1 col10\"></td>";
                strHtml += "<td class=\"tr_l clr_hrd1 de_r col1\"></td>";
                strHtml += "<td class=\"tr_l clr_hrd1 de_r1 col3\"></td>";
                strHtml += "<td class=\"tr_l clr_hrd1 ca_r col0\"></td>";
                strHtml += "<td class=\"tr_l clr_hrd1 le_r col11\"></td>";
                strHtml += "<td class=\"tr_l clr_hrd1 jo_r col5\"></td>";
                strHtml += "<td class=\"tr_l clr_hrd1 jo_r col12\"></td>";
                strHtml += "<td class=\"tr_l clr_hrd1 av_r col13\"></td>";
                strHtml += "<td class=\"tr_l clr_hrd1 le_r1 col14\"></td>";
                strHtml += "<td class=\"tr_l clr_hrd1 le_r3 col15\"></td>";
                strHtml += "<td class=\"tr_l clr_hrd1 le_r3 col16\"></td>";
                strHtml += "</tr>";

                DataRow[] dr;
                if(dtDistdept.Rows[i][0].ToString()!=""){
                dr = dt.Select("" + strSumTypCol + "='" + dtDistdept.Rows[i][0].ToString() + "'");
                }
                else{
                      dr = dt.Select("" + strSumTypCol + " IS NULL");
                }

                foreach(DataRow dRow in dr)               
                {

                   strHtml += "<tr>";
                   strHtml += "<td class=\"tr_l ap_r col6\"></td>";
                   strHtml += "<td class=\"da_r col7\">" + dRow["DATE REQST"].ToString() + "</td>";
                   strHtml += "<td class=\"tr_l em_r col8\">" + dRow["USR_CODE"].ToString() + "</td>";
                   strHtml += "<td class=\"tr_l em_r1 col9\">" + dRow["EMPLOYEE"].ToString() + "</td>";
                   strHtml += "<td class=\"tr_l de_r col10\">" + dRow["DSGN_NAME"].ToString() + "</td>";
                    strHtml += "<td class=\"tr_l de_r1 col1\">" + dRow["CPRDEPT_NAME"].ToString() + "</td>";
                    strHtml += "<td class=\"tr_l ca_r col3\">" + dRow["STAFF_WORKER_NAME"].ToString() + "</td>";
                    strHtml += "<td class=\"tr_l le_r col0\">" + dRow["LEAVETYP_NAME"].ToString() + "</td>";
                    strHtml += "<td class=\"tr_l jo_r col11\"></td>";
                    strHtml += "<td class=\"tr_l jo_r col5\">" + dRow["STATUS_NAME"].ToString() + "</td>";
                    strHtml += "<td class=\"av_r col12\">" + dRow["OPENING_NUMLEAVE"].ToString() + "</td>";
                    strHtml += "<td class=\"le_r1 col13\">" + dRow["LEAVE DATE FROM"].ToString() + "</td>";
                    strHtml += "<td class=\"le_r2 col14\">" + dRow["LEAVE DATE TO"].ToString() + "</td>";
                    strHtml += "<td class=\"le_r3 col15\">" + dRow["LEAVE_NUM_DAYS"].ToString() + "</td>";
                    strHtml += "<td class=\"ba_r col16\">" + dRow["BALANCE_NUMLEAVE"].ToString() + "</td>";
                    strHtml += "</tr>";

                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return strHtml;
    }
    [System.Web.Services.WebMethod]
    public static string ShowSummaryLevel3Print(string OrgIdID, string CorpID, string DeptIds, string DivsIds, string JobIds, string StatusIds, string LeaveTypIds, string FromDate, string ToDate, string CategoryID, string SummaryID, string IndSumTypeId, string Level, string HideCols)
    {
        string strImageName = "", strImagePath = "";
        try
        {
            string[] strArr=HideCols.Split(',');
            int ColCnt=15-strArr.Length;
            clsEntityLeaveApplicationStatusReport objEntityJoiningList = new clsEntityLeaveApplicationStatusReport();
            clsBusinessLeaveApplicationStsReport objBusiness = new clsBusinessLeaveApplicationStsReport();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            objEntityJoiningList.CorpId = Convert.ToInt32(CorpID);
            objEntityJoiningList.OrgId = Convert.ToInt32(OrgIdID);
            objEntityJoiningList.LeaveTypeId = LeaveTypIds;
            objEntityJoiningList.DepartmentId = DeptIds;
            objEntityJoiningList.DivisionId = DivsIds;
            objEntityJoiningList.JobId = JobIds;
            objEntityJoiningList.Status = StatusIds;
            if (FromDate.Trim() != "")
            {
                objEntityJoiningList.FromDate = objCommon.textToDateTime(FromDate.Trim());
            }
            if (ToDate.Trim() != "")
            {
                objEntityJoiningList.Todate = objCommon.textToDateTime(ToDate.Trim());
            }
            if (CategoryID != "")
            {
                objEntityJoiningList.CategoryId = Convert.ToInt32(CategoryID);
            }
            else
            {
                objEntityJoiningList.CategoryId = 2;
            }
            objEntityJoiningList.SummaryTypeId = Convert.ToInt32(SummaryID);
            if (IndSumTypeId != "")
            {
                objEntityJoiningList.SummaryTypeIdInd = Convert.ToInt32(IndSumTypeId);
            }
            else
            {
                objEntityJoiningList.SummaryTypeIdInd = -1;
            }
            DataTable dt = objBusiness.ReadSummaryLeaveDtls(objEntityJoiningList);

            DataView dtview = new DataView(dt);
            DataTable dtDistdept = new DataTable();
            string strSumTypCol = "",strSumTypColL="";
            if (Level == "0")
            {
                dtDistdept = dtview.ToTable(true, "LEAVETYP_NAME");
                strSumTypCol = "LEAVETYP_NAME";
                strSumTypColL = "LEAVE TYPE";
            }
            else if (Level == "1")
            {
                dtDistdept = dtview.ToTable(true, "CPRDEPT_NAME");
                strSumTypCol = "CPRDEPT_NAME";
                strSumTypColL = "DEPARTMENT";
            }
            else if (Level == "2")
            {
                dtDistdept = dtview.ToTable(true, "CPRDIV_NAME");
                strSumTypCol = "CPRDIV_NAME";
                strSumTypColL = "DIVISION";
            }
            else if (Level == "3")
            {
                dtDistdept = dtview.ToTable(true, "STAFF_WORKER_NAME");
                strSumTypCol = "STAFF_WORKER_NAME";
                strSumTypColL = "CATEGORY";
            }
            else if (Level == "5")
            {
                dtDistdept = dtview.ToTable(true, "STATUS_NAME");
                strSumTypCol = "STATUS_NAME";
                strSumTypColL = "STATUS";
            }


            clsBusinessLayer objBusinessC = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();  
            clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
            clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();          
            objEntityLeavSettlmt.CorpId = Convert.ToInt32(CorpID);
            objEntityCommon.CorporateID = Convert.ToInt32(CorpID);
            objEntityLeavSettlmt.OrgId = Convert.ToInt32(OrgIdID);         
            DataTable dtCorp = objBusinessLeavSettlmt.ReadCorporateAddress(objEntityLeavSettlmt);
            string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "", strCompanyLogo = "";
            string strTitle = "";
            strTitle = "LEAVE APPLICATION REPORT";
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
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.LEAVE_APPLICATION_REPORT_PDF);
            Document document = new Document(PageSize.LETTER.Rotate(), 30f, 30f, 19f, 50f);

           


            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {              
                string strNextNumber = objBusinessC.ReadNextNumberSequanceForUI(objEntityCommon);
                //PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                strImageName = "LeaveApplicationRpt_" + strNextNumber + ".pdf";
                strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.LEAVE_APPLICATION_REPORT_PDF);
                string fullPath = System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName;
                if ((System.IO.File.Exists(fullPath)))
                {
                    System.IO.File.Delete(fullPath);
                }
                FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                PdfWriter writer = PdfWriter.GetInstance(document, file);
                writer.PageEvent = new PDFHeader();
                document.Open();


                PdfPTable headtable = new PdfPTable(2);
                    //lbr -1
                    headtable.AddCell(new PdfPCell(new Phrase("LEAVE APPLICATION AND STATUS REPORT", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    if (strCompanyLogo != "")
                    {
                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strCompanyLogo));
                        image.ScalePercent(PdfPCell.ALIGN_CENTER);
                        image.ScaleToFit(60f, 40f);
                        headtable.AddCell(new PdfPCell(image) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    }
                    else
                    {
                        headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    }
                    headtable.AddCell(new PdfPCell(new Phrase(strCompanyName, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    headtable.AddCell(new PdfPCell(new Phrase(strAddress, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    float[] headersHeading = { 92, 8 };
                    headtable.SetWidths(headersHeading);
                    headtable.WidthPercentage = 100;
                    document.Add(headtable);


                    PdfPTable tableLine = new PdfPTable(1);
                    float[] tableLineBody = { 100 };
                    tableLine.SetWidths(tableLineBody);
                    tableLine.WidthPercentage = 100;
                    tableLine.TotalWidth = 950F;
                    PdfPCell cell_headLine = (new PdfPCell(new Phrase("__________________________________________________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, });
                    cell_headLine.Padding = -5;
                    tableLine.AddCell(cell_headLine);

                    tableLine.WriteSelectedRows(0, -1, 0, document.PageSize.GetTop(58), writer.DirectContent);
                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Tahoma,Arial", 10, Font.NORMAL, BaseColor.BLACK))));
                    

                    PdfPTable tabHeadMSP = new PdfPTable(ColCnt);
                    tabHeadMSP.WidthPercentage = 100;
                    tabHeadMSP.HeaderRows = 1;
                    
                tabHeadMSP.AddCell(new PdfPCell(new Phrase("Application Ref#", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });

                
                if(HideCols.Contains('7')==false)
                tabHeadMSP.AddCell(new PdfPCell(new Phrase("Date of Request", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                 if(HideCols.Contains('8')==false)
                     tabHeadMSP.AddCell(new PdfPCell(new Phrase("Employee ID", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                 if(HideCols.Contains('9')==false)
                     tabHeadMSP.AddCell(new PdfPCell(new Phrase("Employee", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                 if(HideCols.Contains("A")==false)
                     tabHeadMSP.AddCell(new PdfPCell(new Phrase("Designation", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                 if(HideCols.Contains('1')==false)
                     tabHeadMSP.AddCell(new PdfPCell(new Phrase("Department", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                 if(HideCols.Contains('3')==false)
                     tabHeadMSP.AddCell(new PdfPCell(new Phrase("Category", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                 if(HideCols.Contains('0')==false)
                     tabHeadMSP.AddCell(new PdfPCell(new Phrase("Leave Type", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                 if(HideCols.Contains("B")==false)
                     tabHeadMSP.AddCell(new PdfPCell(new Phrase("Job", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                 if(HideCols.Contains('5')==false)
                     tabHeadMSP.AddCell(new PdfPCell(new Phrase("Status", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                 if(HideCols.Contains("C")==false)
                     tabHeadMSP.AddCell(new PdfPCell(new Phrase("Available Leave#", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });

                 tabHeadMSP.AddCell(new PdfPCell(new Phrase("Leave From", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                 tabHeadMSP.AddCell(new PdfPCell(new Phrase("Leave To", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                 tabHeadMSP.AddCell(new PdfPCell(new Phrase("Leave Days#", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                 tabHeadMSP.AddCell(new PdfPCell(new Phrase("Balance Leave#", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                   

              
            for (int i = 0; i < dtDistdept.Rows.Count; i++)
            {

                tabHeadMSP.AddCell(new PdfPCell(new Phrase(dtDistdept.Rows[i][0].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Colspan = ColCnt, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });

                DataRow[] dr;
                if (dtDistdept.Rows[i][0].ToString() != "")
                {
                    dr = dt.Select("" + strSumTypCol + "='" + dtDistdept.Rows[i][0].ToString() + "'");
                }
                else
                {
                    dr = dt.Select("" + strSumTypCol + " IS NULL");
                }
               
                foreach (DataRow dRow in dr)
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                
                if(HideCols.Contains('7')==false)
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(dRow["DATE REQST"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                 if(HideCols.Contains('8')==false)
                     tabHeadMSP.AddCell(new PdfPCell(new Phrase(dRow["USR_CODE"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                 if(HideCols.Contains('9')==false)
                     tabHeadMSP.AddCell(new PdfPCell(new Phrase(dRow["EMPLOYEE"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                 if(HideCols.Contains("A")==false)
                     tabHeadMSP.AddCell(new PdfPCell(new Phrase(dRow["DSGN_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                 if(HideCols.Contains('1')==false)
                     tabHeadMSP.AddCell(new PdfPCell(new Phrase(dRow["CPRDEPT_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                 if(HideCols.Contains('3')==false)
                     tabHeadMSP.AddCell(new PdfPCell(new Phrase(dRow["STAFF_WORKER_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                 if(HideCols.Contains('0')==false)
                     tabHeadMSP.AddCell(new PdfPCell(new Phrase(dRow["LEAVETYP_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                 if(HideCols.Contains("B")==false)
                     tabHeadMSP.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                 if(HideCols.Contains('5')==false)
                     tabHeadMSP.AddCell(new PdfPCell(new Phrase(dRow["STATUS_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                 if(HideCols.Contains("C")==false)
                     tabHeadMSP.AddCell(new PdfPCell(new Phrase(dRow["OPENING_NUMLEAVE"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });

                 tabHeadMSP.AddCell(new PdfPCell(new Phrase(dRow["LEAVE DATE FROM"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                 tabHeadMSP.AddCell(new PdfPCell(new Phrase(dRow["LEAVE DATE TO"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                 tabHeadMSP.AddCell(new PdfPCell(new Phrase(dRow["LEAVE_NUM_DAYS"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                 tabHeadMSP.AddCell(new PdfPCell(new Phrase(dRow["BALANCE_NUMLEAVE"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                   
                }
            }
            document.Add(tabHeadMSP);



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
            endtable.AddCell(new PdfPCell(new Phrase("RECEIVER’S SIGNATURE", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });

            endtable.TotalWidth = 555F;
            if (pos1 > 90)
            {
                endtable.WriteSelectedRows(0, -1, 123, 65, writer.DirectContent);
            }
            else
            {
                document.NewPage();
                endtable.WriteSelectedRows(0, -1, 123, 65, writer.DirectContent);
            }
            document.Close();
            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();
        }
        }
        catch (Exception ex)
        {
            strImageName = "";
            strImagePath = "";
        }
        return strImagePath + strImageName;
    }

    [System.Web.Services.WebMethod]
    public static string LoadSummarySingleDtlsPrint(string OrgIdID, string CorpID, string DeptIds, string DivsIds, string JobIds, string StatusIds, string LeaveTypIds, string FromDate, string ToDate, string CategoryID, string SummaryID, string SumTypeId, string ShowLeavTyp, string ShowDept, string ShowDivs, string ShowCtgry, string ShowStatus)
    {
        string strImageName = "", strImagePath = "";
        try
        {
            clsEntityLeaveApplicationStatusReport objEntityJoiningList = new clsEntityLeaveApplicationStatusReport();
            clsBusinessLeaveApplicationStsReport objBusiness = new clsBusinessLeaveApplicationStsReport();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            objEntityJoiningList.CorpId = Convert.ToInt32(CorpID);
            objEntityJoiningList.OrgId = Convert.ToInt32(OrgIdID);
            objEntityJoiningList.LeaveTypeId = LeaveTypIds;
            objEntityJoiningList.DepartmentId = DeptIds;
            objEntityJoiningList.DivisionId = DivsIds;
            objEntityJoiningList.JobId = JobIds;
            objEntityJoiningList.Status = StatusIds;
            if (FromDate.Trim() != "")
            {
                objEntityJoiningList.FromDate = objCommon.textToDateTime(FromDate.Trim());
            }
            if (ToDate.Trim() != "")
            {
                objEntityJoiningList.Todate = objCommon.textToDateTime(ToDate.Trim());
            }
            objEntityJoiningList.CategoryId = Convert.ToInt32(CategoryID);
            objEntityJoiningList.SummaryTypeId = Convert.ToInt32(SummaryID);
            objEntityJoiningList.SummaryTypeIdInd = Convert.ToInt32(SumTypeId);

            string nameCo = "LEAVE TYPE";
            if (SummaryID == "1")
            {
                nameCo = "DEPARTMENT";
            }
            else if (SummaryID == "2")
            {
                nameCo = "DIVISION";
            }
            else if (SummaryID == "3")
            {
                nameCo = "CATEGORY";
            }
            else if (SummaryID == "5")
            {
                nameCo = "STATUS";
            }
           


            string queryCol = "";
            int Cnt = 2;
            if (ShowLeavTyp == "1")
            {
                queryCol = "LEAVETYP_ID,LEAVETYP_NAME";
                Cnt++;
            }
            if (ShowDept == "1")
            {
                if (queryCol == "")
                {
                    queryCol = "CPRDEPT_ID,CPRDEPT_NAME";
                }
                else
                {
                    queryCol += ",CPRDEPT_ID,CPRDEPT_NAME";
                }
                Cnt++;
            }
            if (ShowDivs == "1")
            {
                if (queryCol == "")
                {
                    queryCol = "CPRDIV_ID,CPRDIV_NAME";
                }
                else
                {
                    queryCol += ",CPRDIV_ID,CPRDIV_NAME";
                }
                Cnt++;
            }
            if (ShowCtgry == "1")
            {
                if (queryCol == "")
                {
                    queryCol = "STAFF_WORKER,STAFF_WORKER_NAME";
                }
                else
                {
                    queryCol += ",STAFF_WORKER,STAFF_WORKER_NAME";
                }
                Cnt++;
            }
            if (ShowStatus == "1")
            {
                if (queryCol == "")
                {
                    queryCol = "STATUS_ID,STATUS_NAME";
                }
                else
                {
                    queryCol += ",STATUS_ID,STATUS_NAME";
                }
                Cnt++;
            }
            objEntityJoiningList.QueryColumns = queryCol;
            DataTable dt = objBusiness.ReadSummaryTypeListSingle(objEntityJoiningList);
             clsBusinessLayer objBusinessC = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();  
            clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
            clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();          
            objEntityLeavSettlmt.CorpId = Convert.ToInt32(CorpID);
            objEntityCommon.CorporateID = Convert.ToInt32(CorpID);
            objEntityLeavSettlmt.OrgId = Convert.ToInt32(OrgIdID);         
            DataTable dtCorp = objBusinessLeavSettlmt.ReadCorporateAddress(objEntityLeavSettlmt);
            string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "", strCompanyLogo = "";
            string strTitle = "";
            strTitle = "LEAVE APPLICATION REPORT";
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
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.LEAVE_APPLICATION_REPORT_PDF);
            Document document = new Document(PageSize.LETTER.Rotate(), 30f, 30f, 19f, 50f);

           


            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {              
                string strNextNumber = objBusinessC.ReadNextNumberSequanceForUI(objEntityCommon);
                //PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                strImageName = "LeaveApplicationRpt_" + strNextNumber + ".pdf";
                strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.LEAVE_APPLICATION_REPORT_PDF);
                string fullPath = System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName;
                if ((System.IO.File.Exists(fullPath)))
                {
                    System.IO.File.Delete(fullPath);
                }
                FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                PdfWriter writer = PdfWriter.GetInstance(document, file);
                writer.PageEvent = new PDFHeader();
                document.Open();


                PdfPTable headtable = new PdfPTable(2);
                    //lbr -1
                headtable.AddCell(new PdfPCell(new Phrase("LEAVE APPLICATION AND STATUS REPORT", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    if (strCompanyLogo != "")
                    {
                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strCompanyLogo));
                        image.ScalePercent(PdfPCell.ALIGN_CENTER);
                        image.ScaleToFit(60f, 40f);
                        headtable.AddCell(new PdfPCell(image) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    }
                    else
                    {
                        headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    }
                    headtable.AddCell(new PdfPCell(new Phrase(strCompanyName, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    headtable.AddCell(new PdfPCell(new Phrase(strAddress, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    float[] headersHeading = { 92, 8 };
                    headtable.SetWidths(headersHeading);
                    headtable.WidthPercentage = 100;
                    document.Add(headtable);


                    PdfPTable tableLine = new PdfPTable(1);
                    float[] tableLineBody = { 100 };
                    tableLine.SetWidths(tableLineBody);
                    tableLine.WidthPercentage = 100;
                    tableLine.TotalWidth = 950F;
                    PdfPCell cell_headLine = (new PdfPCell(new Phrase("__________________________________________________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, });
                    cell_headLine.Padding = -5;
                    tableLine.AddCell(cell_headLine);

                    tableLine.WriteSelectedRows(0, -1, 0, document.PageSize.GetTop(58), writer.DirectContent);
                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Tahoma,Arial", 10, Font.NORMAL, BaseColor.BLACK))));


                    PdfPTable tabHeadMSP = new PdfPTable(Cnt);
                    tabHeadMSP.WidthPercentage = 100;
                    tabHeadMSP.HeaderRows = 1;
                    if (ShowDept == "1")
                    {
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase("Department", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    }
                    if (ShowDivs == "1")
                    {
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase("Division", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    }
                    if (ShowLeavTyp == "1")
                    {
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase("Leave Type", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    }
                    if (ShowCtgry == "1")
                    {
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase("Category", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    }                   
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("Job", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    if (ShowStatus == "1")
                    {
                        tabHeadMSP.AddCell(new PdfPCell(new Phrase("Status", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    }                   
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase("Application Count", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });

                    int totCnt = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (ShowDept == "1")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(dt.Rows[i]["CPRDEPT_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });                   
                }
                if (ShowDivs == "1")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(dt.Rows[i]["CPRDIV_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                if (ShowLeavTyp == "1")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(dt.Rows[i]["LEAVETYP_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                }                     
                if (ShowCtgry == "1")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(dt.Rows[i]["STAFF_WORKER_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                tabHeadMSP.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                if (ShowStatus == "1")
                {
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(dt.Rows[i]["STATUS_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                tabHeadMSP.AddCell(new PdfPCell(new Phrase(dt.Rows[i]["CNT"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                totCnt += Convert.ToInt32(dt.Rows[i]["CNT"].ToString());
            }


            tabHeadMSP.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { Colspan = Cnt-1, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
            tabHeadMSP.AddCell(new PdfPCell(new Phrase(totCnt.ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });



            document.Add(tabHeadMSP);



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
            endtable.AddCell(new PdfPCell(new Phrase("RECEIVER’S SIGNATURE", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
            endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });

            endtable.TotalWidth = 555F;
            if (pos1 > 90)
            {
                endtable.WriteSelectedRows(0, -1, 123, 65, writer.DirectContent);
            }
            else
            {
                document.NewPage();
                endtable.WriteSelectedRows(0, -1, 123, 65, writer.DirectContent);
            }
            document.Close();
            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();
            }

        }
        catch (Exception ex)
        {
            strImageName = "";
            strImagePath = "";
        }
        return strImagePath + strImageName;
    }

    [System.Web.Services.WebMethod]
    public static string LoadSummaryMainPrint(string OrgIdID, string CorpID, string DeptIds, string DivsIds, string JobIds, string StatusIds, string LeaveTypIds, string FromDate, string ToDate, string CategoryID, string SummaryID)
    {
        string strImageName = "", strImagePath = "";
        try
        {
            clsEntityLeaveApplicationStatusReport objEntityJoiningList = new clsEntityLeaveApplicationStatusReport();
            clsBusinessLeaveApplicationStsReport objBusiness = new clsBusinessLeaveApplicationStsReport();
            clsCommonLibrary objCommon = new clsCommonLibrary();          
            objEntityJoiningList.CorpId = Convert.ToInt32(CorpID);
            objEntityJoiningList.OrgId = Convert.ToInt32(OrgIdID);
            objEntityJoiningList.LeaveTypeId = LeaveTypIds;
            objEntityJoiningList.DepartmentId = DeptIds;
            objEntityJoiningList.DivisionId = DivsIds;
            objEntityJoiningList.JobId = JobIds;
            objEntityJoiningList.Status = StatusIds;
            objEntityJoiningList.FromDate = objCommon.textToDateTime(FromDate.Trim());
            objEntityJoiningList.Todate = objCommon.textToDateTime(ToDate.Trim());
            objEntityJoiningList.CategoryId = Convert.ToInt32(CategoryID);
            objEntityJoiningList.SummaryTypeId = Convert.ToInt32(SummaryID);
            DataTable dt = objBusiness.ReadSummaryTypeList(objEntityJoiningList);

            string nameCo = "LEAVE TYPE";
            if (SummaryID == "1")
            {
                nameCo = "DEPARTMENT";
            }
            else if (SummaryID == "2")
            {
                nameCo = "DIVISION";
            }
            else if (SummaryID == "3")
            {
                nameCo = "CATEGORY";
            }
            else if (SummaryID == "5")
            {
                nameCo = "STATUS";
            }

            
            clsBusinessLayer objBusinessC = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
            clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
            objEntityLeavSettlmt.CorpId = Convert.ToInt32(CorpID);
            objEntityCommon.CorporateID = Convert.ToInt32(CorpID);
            objEntityLeavSettlmt.OrgId = Convert.ToInt32(OrgIdID);
            DataTable dtCorp = objBusinessLeavSettlmt.ReadCorporateAddress(objEntityLeavSettlmt);
            string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "", strCompanyLogo = "";
            string strTitle = "";
            strTitle = "LEAVE APPLICATION REPORT";
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
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.LEAVE_APPLICATION_REPORT_PDF);
            Document document = new Document(PageSize.LETTER.Rotate(), 30f, 30f, 19f, 50f);
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                string strNextNumber = objBusinessC.ReadNextNumberSequanceForUI(objEntityCommon);
                //PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                strImageName = "LeaveApplicationRpt_" + strNextNumber + ".pdf";
                strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.LEAVE_APPLICATION_REPORT_PDF);
                string fullPath = System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName;
                if ((System.IO.File.Exists(fullPath)))
                {
                    System.IO.File.Delete(fullPath);
                }
                FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                PdfWriter writer = PdfWriter.GetInstance(document, file);
                writer.PageEvent = new PDFHeader();
                document.Open();


                PdfPTable headtable = new PdfPTable(2);
                headtable.AddCell(new PdfPCell(new Phrase("LEAVE APPLICATION AND STATUS REPORT", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                if (strCompanyLogo != "")
                {
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strCompanyLogo));
                    image.ScalePercent(PdfPCell.ALIGN_CENTER);
                    image.ScaleToFit(60f, 40f);
                    headtable.AddCell(new PdfPCell(image) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                }
                else
                {
                    headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                }
                headtable.AddCell(new PdfPCell(new Phrase(strCompanyName, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                headtable.AddCell(new PdfPCell(new Phrase(strAddress, new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                float[] headersHeading = { 92, 8 };
                headtable.SetWidths(headersHeading);
                headtable.WidthPercentage = 100;
                document.Add(headtable);


                PdfPTable tableLine = new PdfPTable(1);
                float[] tableLineBody = { 100 };
                tableLine.SetWidths(tableLineBody);
                tableLine.WidthPercentage = 100;
                tableLine.TotalWidth = 950F;
                PdfPCell cell_headLine = (new PdfPCell(new Phrase("__________________________________________________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, });
                cell_headLine.Padding = -5;
                tableLine.AddCell(cell_headLine);
                tableLine.WriteSelectedRows(0, -1, 0, document.PageSize.GetTop(58), writer.DirectContent);

                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Tahoma,Arial", 10, Font.NORMAL, BaseColor.BLACK))));


                PdfPTable tabHeadMSP = new PdfPTable(2);
                float[] headersHeadindg = { 80, 20};
                tabHeadMSP.SetWidths(headersHeadindg);
                tabHeadMSP.WidthPercentage = 100;
                tabHeadMSP.HeaderRows = 1;                
                tabHeadMSP.AddCell(new PdfPCell(new Phrase(nameCo, FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                tabHeadMSP.AddCell(new PdfPCell(new Phrase("APPLICATION COUNT", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });

                int total = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    total += Convert.ToInt32(dt.Rows[i][2].ToString());
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(dt.Rows[i][1].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                    tabHeadMSP.AddCell(new PdfPCell(new Phrase(dt.Rows[i][2].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                }
                tabHeadMSP.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                tabHeadMSP.AddCell(new PdfPCell(new Phrase(total.ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                document.Add(tabHeadMSP);



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
                endtable.AddCell(new PdfPCell(new Phrase("RECEIVER’S SIGNATURE", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });

                endtable.TotalWidth = 555F;
                if (pos1 > 90)
                {
                    endtable.WriteSelectedRows(0, -1, 123, 65, writer.DirectContent);
                }
                else
                {
                    document.NewPage();
                    endtable.WriteSelectedRows(0, -1, 123, 65, writer.DirectContent);
                }
                document.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
              

                if(total==0){
                    strImageName = "";
                     strImagePath = "";
                }
            }

        }
        catch (Exception ex)
        {
            strImageName = "";
            strImagePath = "";
        }
        return strImagePath + strImageName;
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
            table3.TotalWidth = 950F;
            table3.AddCell(new PdfPCell(new Phrase("_____________________________________________________________________________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
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
  
}