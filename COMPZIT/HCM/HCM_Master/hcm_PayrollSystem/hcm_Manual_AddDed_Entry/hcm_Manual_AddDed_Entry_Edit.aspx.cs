using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Collections;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Globalization;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Ionic.Zip;
using System.IO;

public partial class HCM_HCM_Master_hcm_PayrollSystem_hcm_Manual_AddDed_Entry_hcm_Manual_AddDed_Entry_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ddlMonth.Focus();
        if (!IsPostBack)
        {
            this.Form.Enctype = "multipart/form-data";
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
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
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            //Allocating child roles
            int intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.MANUAL_ADD_DED_ENTRY);
            DataTable dtChildRol = objBusiness.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();
                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        HiddenFieldSaveRole.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        HiddenFieldUpdRole.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        HiddenFieldConfRole.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        HiddenFieldReopRole.Value = "1";
                    }
                }
            }

            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                          clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                          clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                          clsCommonLibrary.CORP_GLOBAL.REFNUM_ACCNTCLS_STS,
                                                          clsCommonLibrary.CORP_GLOBAL.GN_REMOVE_RESTRCTNS_STS
                                                       };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            }
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusiness.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
                HiddenCurrencyAbrv.Value = dtCurrencyDetail.Rows[0]["CRNCMST_ABBRV"].ToString();
            }
            string CurrMonth = "", CurrYear = "";           
            HiddenFieldEditMode.Value = "1";               
            TabeleHeaderLoad();
            BindDdlYears(CurrYear);
            BindDdlMonths(CurrMonth);
            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccCsvSave", "SuccCsvSave();", true);
                }
                else if (strInsUpd == "Err")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Err", "Err();", true);
                }
            }
        }
    }
    public void BindDdlMonths(string strMonth)
    {
        clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
        clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLeavSettlmt.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        DataTable dtCorpSal = objBusinessLeavSettlmt.ReadCorpSal(objEntityLeavSettlmt);
        DateTime dtCorpSalaryDate = objCommon.textToDateTime(dtCorpSal.Rows[0]["COPRT_SALARY_DATE"].ToString());
        int corpSalYear = dtCorpSalaryDate.Year;
        int corpSalMonth = dtCorpSalaryDate.Month;
        int start = 0;
        if (ddlYear.Value == corpSalYear.ToString())
        {
            start = corpSalMonth - 1;
        }
        if (strMonth == "")
            strMonth = DateTime.Today.Month.ToString();

        ddlMonth.Items.Clear();
        var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
        for (int i = start; i < months.Length - 1; i++)
        {
            ddlMonth.Items.Add(new System.Web.UI.WebControls.ListItem(months[i], (i + 1).ToString()));
        }
        if (strMonth != "")
        {
            if (ddlMonth.Items.FindByValue(strMonth) != null)
            {
                ddlMonth.Items.FindByValue(strMonth).Selected = true;
            }
            HiddenFieldCurrMonth.Value = strMonth;
        }
    }
    public void BindDdlYears(string strYear)
    {
        clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
        clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLeavSettlmt.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        DataTable dtCorpSal = objBusinessLeavSettlmt.ReadCorpSal(objEntityLeavSettlmt);
        DateTime dtCorpSalaryDate = objCommon.textToDateTime(dtCorpSal.Rows[0]["COPRT_SALARY_DATE"].ToString());
        int corpSalYear = dtCorpSalaryDate.Year;
        ddlYear.Items.Clear();
        if (strYear == "")
        {
            if (corpSalYear <= DateTime.Today.Year)
                strYear = DateTime.Today.Year.ToString();
        }
        int currentYear = DateTime.Today.Year + 1;
        int flag = 0;
        for (int i = currentYear; i >= corpSalYear; i--)
        {
            flag = 1;
            if (strYear == "")
            {
                strYear = i.ToString();
            }
            ddlYear.Items.Add((i).ToString());
        }
        if (flag == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                if (strYear == "")
                {
                    strYear = corpSalYear.ToString();
                }
                ddlYear.Items.Add((corpSalYear + i).ToString());
            }
        }
        if (strYear != "")
        {
            if (ddlYear.Items.FindByValue(strYear) != null)
            {
                ddlYear.Items.FindByValue(strYear).Selected = true;
            }
            else
            {
                ddlYear.Items.Add(strYear);
                ddlYear.Items.FindByValue(strYear).Selected = true;
            }
            HiddenFieldCurrYear.Value = strYear;
        }
    }
    public void TabeleHeaderLoad()
    {
        int cnt = 0;
        if (hiddenDecimalCount.Value != "")
        {
            cnt = Convert.ToInt32(hiddenDecimalCount.Value);
        }
        string formatString = String.Concat("{0:F", cnt, "}");
        string defAmnt = String.Format(formatString, 0).ToString();

        clsEntityManualAddDedEntry objentity = new clsEntityManualAddDedEntry();
        clsBusinessLayerManualAddDedEntry objBussiness = new clsBusinessLayerManualAddDedEntry();
        if (Session["CORPOFFICEID"] != null)
        {
            objentity.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objentity.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objentity.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dt = objBussiness.ReadManualAddDed(objentity);
        StringBuilder objstr = new StringBuilder();
        StringBuilder objstrFoot = new StringBuilder();

        string AddColSpan = "0", DedColSpan = "0";
        if (dt.Rows.Count > 0)
        {
            AddColSpan = dt.Rows[0]["CNT_ADD"].ToString();
            DedColSpan = dt.Rows[0]["CNT_DED"].ToString();
        }
        HiddenFieldAddSpan.Value = AddColSpan;
        HiddenFieldDedSpan.Value = DedColSpan;


        objstrFoot.Append("<tr class=\"tr_ft\">");
        objstrFoot.Append("<td class=\"tr_c\" colspan=\"3\">TOTAL</td>");

        objstr.Append("<tr>");
        objstr.Append("<th class=\"th_b5_c\" rowspan=\"2\"></th>");
        objstr.Append("<th class=\"th_b6_c\"><input id=\"txtSearch1\" type=\"text\" class=\"inp_tb_ser notv\" placeholder=\"CODE#\"/></th>");
        objstr.Append("<th class=\"th_b8_c tr_l\"><input id=\"txtSearch2\" type=\"text\" class=\"inp_tb_ser notv\" placeholder=\"EMPLOYEE NAME\"/></th>");
        if (AddColSpan != "0")
            objstr.Append("<th colspan=\"" + (Convert.ToInt32(AddColSpan) + 1).ToString() + "\">Additions</th>");
        if (DedColSpan != "0")
            objstr.Append("<th colspan=\"" + (Convert.ToInt32(DedColSpan) + 1).ToString() + "\">Deductions</th>");
        objstr.Append("<th class=\"th_b2_c\" rowspan=\"2\">Actions</th>");
        objstr.Append("</tr>");

        objstr.Append("<tr class=\"add_ddcn\">");
        objstr.Append("<th class=\"th_b6_c tr_l\">Emp Code</th>");
        objstr.Append("<th class=\"th_b4_c tr_l\">Employee Name</th>");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            objstrFoot.Append("<td class=\"tr_r\" id=\"tdAddDedTotCol_" + i + "\">" + defAmnt + "</td>");

            objstr.Append("<td class=\"th_b7_5_c tr_r\">" + dt.Rows[i]["PAYRL_CODE"].ToString() + "<a href=\"#\" onclick=\"return ShowDescCommon(" + i + ");\" class=\"fa fa-commenting-o fzd\" data-toggle=\"popover\" data-html=\"true\" data-content=\"<textarea id='txtDescCommon_" + i + "' onkeydown='textCounter(txtDescCommon_" + i + ",450,event);' onkeyup='textCounter(txtDescCommon_" + i + ",450,event);' onchange='return changeTextDesc(" + i + ");'   type='text' row='2'placeholder='Add Remarks'></textarea>\" title=\"" + dt.Rows[i]["PAYRL_CODE"].ToString() + "\"></a></td>");
            objstr.Append("<input id=\"tdAddDedId_" + i + "\" name=\"tdAddDedId_" + i + "\" style=\"display:none;\" value=\"" + dt.Rows[i]["PAYRL_ID"].ToString() + "\" />");
            objstr.Append("<input id=\"tdAddDedIdAct_" + i + "\" name=\"tdAddDedIdAct_" + i + "\" style=\"display:none;\" value=\"1\" />");
            objstr.Append("<input id=\"tdDesc_" + i + "\" name=\"tdDesc_" + i + "\" style=\"display:none;\"/>");
            objstr.Append("<input id=\"tdAddDedName_" + i + "\" name=\"tdAddDedName_" + i + "\" value=\"" + dt.Rows[i]["PAYRL_CODE"].ToString() + "\" style=\"display:none;\"/>");
            if (AddColSpan != "0" && Convert.ToInt32(AddColSpan) - 1 == i)
            {
                objstr.Append("<td class=\"th_b7_5_c tr_r\">TOTAL</td>");
                objstrFoot.Append("<td id=\"tdAddTotAmnt\" class=\"tr_r fnt_w6 grn1\">" + defAmnt + "</td>");
            }
            if (DedColSpan != "0" && (Convert.ToInt32(DedColSpan) + Convert.ToInt32(AddColSpan)) - 1 == i)
            {
                objstr.Append("<td class=\"th_b7_5_c tr_r\">TOTAL</td>");
                objstrFoot.Append("<td id=\"tdDedTotAmnt\" class=\"tr_r fnt_w6 red1\">" + defAmnt + "</td>");
            }
        }
        objstr.Append("</tr>");
        objstrFoot.Append("<td class=\"tr_r\"></td>");
        objstrFoot.Append("</tr>");
        tMainHead.InnerHtml = objstr.ToString();
        tMainFoot.InnerHtml = objstrFoot.ToString();
        HiddenFieldTotAddDedNum.Value = dt.Rows.Count.ToString();
    }
    [WebMethod]
    public static string[] changeEmployee(string strLikeEmployee, int orgID, int corptID, int month, int year)
    {
        List<string> Employees = new List<string>();
        clsEntityManualAddDedEntry objentity = new clsEntityManualAddDedEntry();
        clsBusinessLayerManualAddDedEntry objBussiness = new clsBusinessLayerManualAddDedEntry();
        objentity.CorpOffice_Id = Convert.ToInt32(corptID);
        objentity.Organisation_Id = Convert.ToInt32(orgID);
        objentity.MonthId = Convert.ToInt32(month);
        objentity.YearId = Convert.ToInt32(year);
        DataTable dtEmployess = objBussiness.ReadEmployee(objentity, strLikeEmployee.ToUpper());
        for (int intRowCount = 0; intRowCount < dtEmployess.Rows.Count; intRowCount++)
        {
            Employees.Add(string.Format("{0}<,>{1}<,>{2}<,>{3}", dtEmployess.Rows[intRowCount]["USR_ID"].ToString(), dtEmployess.Rows[intRowCount]["USR_CODE"].ToString(), dtEmployess.Rows[intRowCount]["USR_NAME"].ToString(), dtEmployess.Rows[intRowCount]["USR_NAME_CODE"].ToString()));
        }
        return Employees.ToArray();
    }
    [WebMethod]
    public static string[] SaveUpdDelEmpDtls(string orgID, string corptID, string userID, string MasterDbId, string MonthNum, string YearNum, string RowNum, string Mode, string EmpId, string AddDedkeyValue, string Currency_id)
    {
        string[] sts = new string[3];
        try
        {
            clsEntityManualAddDedEntry objentity = new clsEntityManualAddDedEntry();
            clsBusinessLayerManualAddDedEntry objBussiness = new clsBusinessLayerManualAddDedEntry();
            objentity.CorpOffice_Id = Convert.ToInt32(corptID);
            objentity.Organisation_Id = Convert.ToInt32(orgID);
            objentity.User_Id = Convert.ToInt32(userID);
            objentity.MasterTabId = Convert.ToInt32(MasterDbId);
            objentity.MonthId = Convert.ToInt32(MonthNum);
            objentity.YearId = Convert.ToInt32(YearNum);
            objentity.ConfStatusId = Convert.ToInt32(Mode);
            objentity.CurrencyId = Convert.ToInt32(Currency_id);
            objentity.User_Id = Convert.ToInt32(userID);
            List<clsEntityManualAddDedEntry> objAddDedList = new List<clsEntityManualAddDedEntry>();
            if (AddDedkeyValue != "" && AddDedkeyValue != null && AddDedkeyValue != "null")
            {
                string[] values = AddDedkeyValue.Split('$');
                for (int i = 0; i < values.Length; i++)
                {
                    clsEntityManualAddDedEntry objEntityDtls = new clsEntityManualAddDedEntry();
                    string[] valSplit = values[i].Split('%');
                    objEntityDtls.EmployeeId = Convert.ToInt32(EmpId);
                    objEntityDtls.AddDedId = Convert.ToInt32(valSplit[0]);
                    if (valSplit[1] != "" && valSplit[1] != null && valSplit[1] != "null")
                        objEntityDtls.Amount = Convert.ToDecimal(valSplit[1]);
                    objEntityDtls.SubTabId = Convert.ToInt32(valSplit[2]);
                    objEntityDtls.Description = valSplit[3];
                    if (valSplit[4] != "")
                        objEntityDtls.DescChangeSts = Convert.ToInt32(valSplit[4]);
                    objAddDedList.Add(objEntityDtls);
                }
            }
            //DataTable dtDup = objBussiness.readMonthYearDataEdit(objentity);
            //for(int i=0;i<dtDup.Rows.Count;i++){
            //if (dtDup.Rows.Count > 0 && dtDup.Rows[i]["PAYINF_CNCL_USR_ID"].ToString() != "")
            //{
            //    sts[1] = "AlCncl";
            //    break;
            //}
            //else if (dtDup.Rows.Count > 0 && Mode != "3" && dtDup.Rows[i]["PAYINF_CONF_USR_ID"].ToString() != "")
            //{
            //    sts[1] = "AlConf";
            //      break;
            //}
            //else if (dtDup.Rows.Count > 0 && Mode == "3" && dtDup.Rows[i]["PAYINF_REOPN_USR_ID"].ToString() != "")
            //{
            //    sts[1] = "AlReop";
            //      break;
            //}
            //}
            if(sts[1]=="" || sts[1] ==null) 
            {
                objBussiness.insUpdEmpDtlsEdit(objentity, objAddDedList);
                sts[0] = "100";
                sts[2] = objentity.cancelReason;
            }
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("unique constraint"))
            {
                sts[1] = "DupEmp";
            }
        }
        return sts;
    }
    [WebMethod]
    public static string UpdDetailIds(string MasterDbId, string EmpId, string AddDedId)
    {
        string sts = "0";
        try
        {
            clsEntityManualAddDedEntry objentity = new clsEntityManualAddDedEntry();
            clsBusinessLayerManualAddDedEntry objBussiness = new clsBusinessLayerManualAddDedEntry();
            objentity.MasterTabId = Convert.ToInt32(MasterDbId);
            objentity.EmployeeId = Convert.ToInt32(EmpId);
            objentity.AddDedId = Convert.ToInt32(AddDedId);
            DataTable dt = objBussiness.ReadSubTableId(objentity);
            if (dt.Rows.Count > 0)
            {
                sts = dt.Rows[0][0].ToString();
            }
        }
        catch (Exception ex)
        {

        }
        return sts;
    }
    [WebMethod]
    public static string changeDescription(string ids, string Desc, string ChangeSts, string userID)
    {
        string sts = "0";
        try
        {
            clsEntityManualAddDedEntry objentity = new clsEntityManualAddDedEntry();
            clsBusinessLayerManualAddDedEntry objBussiness = new clsBusinessLayerManualAddDedEntry();
            objentity.cancelReason = ids.Replace('-', ',');
            objentity.Description = Desc;
            objentity.DescChangeSts = Convert.ToInt32(ChangeSts);
            objentity.User_Id = Convert.ToInt32(userID);
            objBussiness.UpdateDescription(objentity);
        }
        catch (Exception ex)
        {
        }
        return sts;
    }
    public class clsTVData
    {
        public string EMPID { get; set; }
        public string EMPCODE { get; set; }
        public string EMPNAME { get; set; }
        public string ADDDEDSTLS { get; set; }
        public string PROCESSD { get; set; }
    }
    [WebMethod]
    public static string[] changeMonthYear(string orgID, string corptID, string month, string year, string Id)
    {
        string[] sts = new string[4];
        try
        {
            clsEntityManualAddDedEntry objentity = new clsEntityManualAddDedEntry();
            clsBusinessLayerManualAddDedEntry objBussiness = new clsBusinessLayerManualAddDedEntry();
            objentity.Organisation_Id = Convert.ToInt32(orgID);
            objentity.CorpOffice_Id = Convert.ToInt32(corptID);
            objentity.MonthId = Convert.ToInt32(month);
            objentity.YearId = Convert.ToInt32(year);
            objentity.MasterTabId = Convert.ToInt32(Id);
            DataTable dt = objBussiness.readMonthYearDataEdit(objentity);
            if (dt.Rows.Count > 0)
            {

                sts[0] = dt.Rows[0]["PAYINF_ID"].ToString();
                sts[1] = dt.Rows[0]["PAYINF_CONF_USR_ID"].ToString();
                sts[2] = dt.Rows[0]["PAYINF_CNCL_USR_ID"].ToString();


                DataTable dtDetail = new DataTable();
                dtDetail.Columns.Add("EMPID", typeof(string));
                dtDetail.Columns.Add("EMPCODE", typeof(string));
                dtDetail.Columns.Add("EMPNAME", typeof(string));
                dtDetail.Columns.Add("ADDDEDSTLS", typeof(string));
                dtDetail.Columns.Add("PROCESSD", typeof(string));

                int flag = 0;
                DataView view = new DataView(dt);
                DataTable dtCategory = view.ToTable(true, "USR_ID", "USR_NAME", "USR_CODE", "PAYINFDT_PROCESS_STS");
                for (int i = 0; i < dtCategory.Rows.Count; i++)
                {
                    if (dtCategory.Rows[i]["USR_ID"].ToString() != "")
                    {
                        DataRow[] result = dt.Select("USR_ID =" + dtCategory.Rows[i]["USR_ID"].ToString() + "");
                        string AddDedkeyValue = "";
                        foreach (DataRow row in result)
                        {
                            if (AddDedkeyValue == "")
                            {
                                AddDedkeyValue = row["PAYRL_ID"].ToString() + "%" + row["PAYINFDT_AMOUNT"].ToString() + "%" + row["PAYINFDT_ID"].ToString() + "%" + row["PAYINFDT_DESCRIPTION"].ToString() + "%" + row["PAYINFDT_CHANGE_DESC_STS"].ToString();
                            }
                            else
                            {
                                AddDedkeyValue = AddDedkeyValue + "$" + row["PAYRL_ID"].ToString() + "%" + row["PAYINFDT_AMOUNT"].ToString() + "%" + row["PAYINFDT_ID"].ToString() + "%" + row["PAYINFDT_DESCRIPTION"].ToString() + "%" + row["PAYINFDT_CHANGE_DESC_STS"].ToString();
                            }
                        }

                        DataRow drDtl = dtDetail.NewRow();
                        drDtl["EMPID"] = dtCategory.Rows[i]["USR_ID"].ToString();
                        drDtl["EMPCODE"] = dtCategory.Rows[i]["USR_CODE"].ToString();
                        drDtl["EMPNAME"] = dtCategory.Rows[i]["USR_NAME"].ToString();
                        drDtl["ADDDEDSTLS"] = AddDedkeyValue;
                        drDtl["PROCESSD"] = dtCategory.Rows[i]["PAYINFDT_PROCESS_STS"].ToString();
                        dtDetail.Rows.Add(drDtl);
                        flag = 1;
                    }
                }
                if (flag == 1)
                    sts[3] = DataTableToJSONWithJavaScriptSerializer(dtDetail);

            }
        }
        catch (Exception ex)
        {

        }
        return sts;
    }
    [WebMethod]
    public static string[] ReadClearData(string MasterDbId, string AddDedTbId)
    {
        string[] sts = new string[4];
        try
        {
            clsEntityManualAddDedEntry objentity = new clsEntityManualAddDedEntry();
            clsBusinessLayerManualAddDedEntry objBussiness = new clsBusinessLayerManualAddDedEntry();
            objentity.SubTabId = Convert.ToInt32(AddDedTbId);
            DataTable dt = objBussiness.readClearDta(objentity);
            if (dt.Rows.Count > 0)
            {
                sts[0] = dt.Rows[0]["PAYINF_ID"].ToString();
                sts[1] = dt.Rows[0]["PAYINF_CONF_USR_ID"].ToString();
                sts[2] = dt.Rows[0]["PAYINF_CNCL_USR_ID"].ToString();


                DataTable dtDetail = new DataTable();
                dtDetail.Columns.Add("EMPID", typeof(string));
                dtDetail.Columns.Add("EMPCODE", typeof(string));
                dtDetail.Columns.Add("EMPNAME", typeof(string));
                dtDetail.Columns.Add("ADDDEDSTLS", typeof(string));
                dtDetail.Columns.Add("PROCESSD", typeof(string));

                int flag = 0;
                DataView view = new DataView(dt);
                DataTable dtCategory = view.ToTable(true, "USR_ID", "USR_NAME", "USR_CODE", "PAYINFDT_PROCESS_STS");
                for (int i = 0; i < dtCategory.Rows.Count; i++)
                {
                    if (dtCategory.Rows[i]["USR_ID"].ToString() != "")
                    {
                        DataRow[] result = dt.Select("USR_ID =" + dtCategory.Rows[i]["USR_ID"].ToString() + "");
                        string AddDedkeyValue = "";
                        foreach (DataRow row in result)
                        {
                            if (AddDedkeyValue == "")
                            {
                                AddDedkeyValue = row["PAYRL_ID"].ToString() + "%" + row["PAYINFDT_AMOUNT"].ToString() + "%" + row["PAYINFDT_ID"].ToString() + "%" + row["PAYINFDT_DESCRIPTION"].ToString() + "%" + row["PAYINFDT_CHANGE_DESC_STS"].ToString();
                            }
                            else
                            {
                                AddDedkeyValue = AddDedkeyValue + "$" + row["PAYRL_ID"].ToString() + "%" + row["PAYINFDT_AMOUNT"].ToString() + "%" + row["PAYINFDT_ID"].ToString() + "%" + row["PAYINFDT_DESCRIPTION"].ToString() + "%" + row["PAYINFDT_CHANGE_DESC_STS"].ToString();
                            }
                        }

                        DataRow drDtl = dtDetail.NewRow();
                        drDtl["EMPID"] = dtCategory.Rows[i]["USR_ID"].ToString();
                        drDtl["EMPCODE"] = dtCategory.Rows[i]["USR_CODE"].ToString();
                        drDtl["EMPNAME"] = dtCategory.Rows[i]["USR_NAME"].ToString();
                        drDtl["ADDDEDSTLS"] = AddDedkeyValue;
                        drDtl["PROCESSD"] = dtCategory.Rows[i]["PAYINFDT_PROCESS_STS"].ToString();
                        dtDetail.Rows.Add(drDtl);
                        flag = 1;
                    }
                }
                if (flag == 1)
                    sts[3] = DataTableToJSONWithJavaScriptSerializer(dtDetail);

            }
        }
        catch (Exception ex)
        {

        }
        return sts;
    }
    [WebMethod]
    public static string checkEmpDuplication(string orgID, string corptID, string month, string year, string EmpId, string AddDedkeyValue)
    {
        string sts = "";
        try
        {
            AddDedkeyValue = AddDedkeyValue.Replace('%', ',');
            clsEntityManualAddDedEntry objentity = new clsEntityManualAddDedEntry();
            clsBusinessLayerManualAddDedEntry objBussiness = new clsBusinessLayerManualAddDedEntry();
            objentity.Organisation_Id = Convert.ToInt32(orgID);
            objentity.CorpOffice_Id = Convert.ToInt32(corptID);
            objentity.MonthId = Convert.ToInt32(month);
            objentity.YearId = Convert.ToInt32(year);
            objentity.EmployeeId = Convert.ToInt32(EmpId);
            objentity.cancelReason = AddDedkeyValue;
            DataTable dt = objBussiness.checkEmployeeDuplication(objentity);
            if (dt.Rows[0][0].ToString() != "0")
            {
                sts = "dup";
            }
            else
            {
                clsCommonLibrary objCommon = new clsCommonLibrary();
                DateTime Curr = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), 01);
                objentity.StartDate = objCommon.textToDateTime(Curr.ToString("dd-MM-yyyy"));
                int daysInm = DateTime.DaysInMonth(Convert.ToInt32(year), Convert.ToInt32(month));
                DateTime CurLast = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), daysInm);
                objentity.EndDate = objCommon.textToDateTime(CurLast.ToString("dd-MM-yyyy"));
                clsBusinessLayer objBusis = new clsBusinessLayer();
                clsEntityCommon ObjEntitySales = new clsEntityCommon();
                ObjEntitySales.UserId = Convert.ToInt32(EmpId);
                DataTable dtS = objBusis.CheckLastSalProcess(ObjEntitySales);
                if (dtS.Rows.Count > 0 && objCommon.textToDateTime(dtS.Rows[0]["EMPERDTL_JOIN_DATE1"].ToString()) >= objCommon.textToDateTime(Curr.ToString("dd-MM-yyyy")))
                {
                    sts = dtS.Rows[0]["MOD"].ToString();
                }
                else
                {
                    DataTable dtSs = objBussiness.checkEmpLeave(objentity);
                    if (dtSs.Rows[0][0].ToString() != "0")
                    {
                        sts = "on leave";
                    }

                }
            }
        }
        catch (Exception ex)
        {
        }
        return sts;
    }
    public static string DataTableToJSONWithJavaScriptSerializer(DataTable table)
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
    #region PDF PRINT
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        clsEntityManualAddDedEntry objentity = new clsEntityManualAddDedEntry();
        clsBusinessLayerManualAddDedEntry objBussiness = new clsBusinessLayerManualAddDedEntry();

        if (Session["CORPOFFICEID"] != null)
        {
            objentity.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objentity.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (ddlMonth.Value != "-Select-")
        {
            objentity.MonthId = Convert.ToInt32(ddlMonth.Value);
        }
        if (ddlYear.Value != "-Select-")
        {
            objentity.YearId = Convert.ToInt32(ddlYear.Value);
        }
        objentity.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        objentity.MasterTabId = Convert.ToInt32(HiddenFieldMasterDbId.Value);

        DataTable dtTabeleHeader = objBussiness.ReadManualAddDedEdit(objentity);

        //VIEWDATA
        DataTable dtAddDedDtls = objBussiness.readMonthYearData(objentity);

        Generate_Manual_AddDed_PDF(dtTabeleHeader, dtAddDedDtls, objentity);
    }
    public void Generate_Manual_AddDed_PDF(DataTable dtTabeleHeader, DataTable dtAddDedDtls, clsEntityManualAddDedEntry objentity)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        objEntityCommon.CorporateID = objentity.CorpOffice_Id;
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.MANUAL_ADD_DED_ATTACHMENT);
        string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);

        if (dtTabeleHeader.Rows.Count > 0 && dtAddDedDtls.Rows.Count > 0) //oold
        {
            Document document = new Document(PageSize.LETTER, 35f, 25f, 15f, 60f);
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                string strImageName = "ManualAddDed_" + strNextId + ".pdf";
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.MANUAL_ADD_DED_PDF);

                string fullPath = System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName;
                if ((System.IO.File.Exists(fullPath)))
                {
                    System.IO.File.Delete(fullPath);
                }

                FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                PdfWriter.GetInstance(document, file);
                writer.PageEvent = new PDFHeader();
                document.Open();

                if (true)
                {
                    int cnt = 0;
                    if (hiddenDecimalCount.Value != "")
                    {
                        cnt = Convert.ToInt32(hiddenDecimalCount.Value);
                    }
                    string formatString = String.Concat("{0:F", cnt, "}");

                    int MonthId = Convert.ToInt16(dtAddDedDtls.Rows[0]["PAYINF_MONTH"].ToString());
                    int YearId = Convert.ToInt16(dtAddDedDtls.Rows[0]["PAYINF_YEAR"].ToString());
                    DateTime dtDate = new DateTime(2000, MonthId, 1);
                    string strMonthName = dtDate.ToString("MMMM");
                    string strYear = YearId.ToString();

                    PdfPTable MonthYearTable = new PdfPTable(4);
                    float[] YearTableBody = { 5, 80, 4, 6 };
                    MonthYearTable.SetWidths(YearTableBody);
                    MonthYearTable.WidthPercentage = 100;
                    MonthYearTable.AddCell(new PdfPCell(new Phrase("Month", new Font(FontFactory.GetFont("Tahoma,Arial", 8, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    MonthYearTable.AddCell(new PdfPCell(new Phrase(":  " + strMonthName, new Font(FontFactory.GetFont("Tahoma,Arial", 8, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    MonthYearTable.AddCell(new PdfPCell(new Phrase("Year", new Font(FontFactory.GetFont("Tahoma,Arial", 8, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    MonthYearTable.AddCell(new PdfPCell(new Phrase(":  " + strYear, new Font(FontFactory.GetFont("Tahoma,Arial", 8, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                    document.Add(MonthYearTable);


                    #region Table

                    int intAddColSpan = 0, intDedColSpan = 0;
                    if (dtTabeleHeader.Rows.Count > 0)
                    {
                        DataRow[] resultAdd = dtTabeleHeader.Select("PAYRL_MODE =1");
                        DataRow[] resultDed = dtTabeleHeader.Select("PAYRL_MODE =2");

                        intAddColSpan = Convert.ToInt32(resultAdd.Length);
                        intDedColSpan = Convert.ToInt32(resultDed.Length);
                    }
                    int intAddTotalColmn = 0; int intDedTotalColmn = 0;
                    if (intAddColSpan != 0)
                    {
                        intAddTotalColmn = 1;
                    }
                    if (intDedColSpan != 0)
                    {
                        intDedTotalColmn = 1;
                    }


                    int TotalColumn = intAddColSpan + intDedColSpan + intAddTotalColmn + intDedTotalColmn + 2;

                    //tableLayout width setting
                    float[] arrayAddDed = new float[TotalColumn];

                    for (int i = 0; i < TotalColumn; i++)
                    {
                        if (i == 0 || i == 1)
                        {
                            if (i == 0)
                            {
                                arrayAddDed[i] = 9;
                            }
                            else
                            {
                                arrayAddDed[i] = 16;
                            }
                        }

                        else
                        {
                            arrayAddDed[i] = 75 / (intAddColSpan + intDedColSpan + intAddTotalColmn + intDedTotalColmn);
                        }
                    }

                    PdfPTable tableLayout = new PdfPTable(TotalColumn);
                    float[] headersBody = arrayAddDed;
                    tableLayout.SetWidths(headersBody);
                    tableLayout.WidthPercentage = 100;

                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

                    int intTotalColspanAdd = intAddColSpan + intAddTotalColmn;
                    int intTotalColspanDed = intDedColSpan + intDedTotalColmn;


                    //table head section
                    tableLayout.AddCell(new PdfPCell(new Phrase("EMPLOYEE CODE", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY, Rowspan = 2 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("EMPLOYEE NAME", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY, Rowspan = 2 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("ADDITIONS", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY, Colspan = intTotalColspanAdd });
                    tableLayout.AddCell(new PdfPCell(new Phrase("DEDUCTIONS", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY, Colspan = intTotalColspanDed });
                    for (int i = 0; i < dtTabeleHeader.Rows.Count; i++)
                    {
                        string add = dtTabeleHeader.Rows[i]["PAYRL_CODE"].ToString();
                        tableLayout.AddCell(new PdfPCell(new Phrase(dtTabeleHeader.Rows[i]["PAYRL_CODE"].ToString(), FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                        if ((i == intAddColSpan - 1 && intAddColSpan != 0) || (i == intAddColSpan + intDedColSpan - 1 && intDedColSpan != 0))
                        {
                            tableLayout.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                        }

                    }
                    //table head section


                    //table body
                    DataTable dtDetail = new DataTable();
                    dtDetail.Columns.Add("EMPCODE", typeof(string));
                    dtDetail.Columns.Add("EMPNAME", typeof(string));
                    for (int i = 0; i < dtTabeleHeader.Rows.Count; i++)
                    {
                        dtDetail.Columns.Add("ADDDEDSTLS_" + i, typeof(string));
                    }

                    DataView view = new DataView(dtAddDedDtls);
                    DataTable dtCategory = view.ToTable(true, "USR_ID", "USR_NAME", "USR_CODE", "PAYINFDT_PROCESS_STS");

                    for (int i = 0; i < dtCategory.Rows.Count; i++)
                    {
                        if (dtCategory.Rows[i]["USR_ID"].ToString() != "")
                        {
                            DataRow[] result = dtAddDedDtls.Select("USR_ID =" + dtCategory.Rows[i]["USR_ID"].ToString() + "");

                            DataRow drDtl = dtDetail.NewRow();
                            drDtl["EMPCODE"] = dtCategory.Rows[i]["USR_CODE"].ToString();
                            drDtl["EMPNAME"] = dtCategory.Rows[i]["USR_NAME"].ToString();

                            string strPayrlId = "";
                            for (int j = 0; j < dtTabeleHeader.Rows.Count; j++)
                            {
                                foreach (DataRow row in result)
                                {
                                    strPayrlId = row["PAYRL_ID"].ToString();
                                    if (dtTabeleHeader.Rows[j]["PAYRL_ID"].ToString() == strPayrlId)
                                    {
                                        drDtl["ADDDEDSTLS_" + j] = row["PAYINFDT_AMOUNT"].ToString();
                                    }
                                }
                            }
                            dtDetail.Rows.Add(drDtl);
                        }
                    }
                    decimal TotalAmt = 0;
                    decimal decWholeTotalAdd = 0; decimal decWholeTotalDed = 0;
                    decimal[] decAddDedColumnTotal = new decimal[dtTabeleHeader.Rows.Count];

                    for (int j = 0; j < dtDetail.Rows.Count; j++)
                    {
                        tableLayout.AddCell(new PdfPCell(new Phrase(dtDetail.Rows[j]["EMPCODE"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                        tableLayout.AddCell(new PdfPCell(new Phrase(dtDetail.Rows[j]["EMPNAME"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                        for (int k = 0; k < dtTabeleHeader.Rows.Count; k++)
                        {
                            if (dtDetail.Rows[j]["ADDDEDSTLS_" + k].ToString() != "")
                            {
                                string strAmount = String.Format(formatString, Convert.ToDecimal(dtDetail.Rows[j]["ADDDEDSTLS_" + k].ToString())).ToString();
                                if (dtDetail.Rows[j]["ADDDEDSTLS_" + k].ToString() != "")
                                {
                                    TotalAmt += Convert.ToDecimal(dtDetail.Rows[j]["ADDDEDSTLS_" + k].ToString());
                                    decAddDedColumnTotal[k] += Convert.ToDecimal(dtDetail.Rows[j]["ADDDEDSTLS_" + k].ToString());
                                }
                                tableLayout.AddCell(new PdfPCell(new Phrase(strAmount.ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                            }
                            else
                            {
                                tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                            }

                            if ((k == intAddColSpan - 1 && intAddColSpan != 0) || (k == intAddColSpan + intDedColSpan - 1 && intDedColSpan != 0))
                            {
                                if (k == intAddColSpan - 1)
                                {
                                    decWholeTotalAdd += TotalAmt;
                                }
                                else if (k == intAddColSpan + intDedColSpan - 1)
                                {
                                    decWholeTotalDed += TotalAmt;
                                }

                                string strToalAmount = String.Format(formatString, TotalAmt).ToString();
                                tableLayout.AddCell(new PdfPCell(new Phrase(strToalAmount, FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                                TotalAmt = 0;
                            }

                        }

                    }


                    tableLayout.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY, Colspan = 2 });
                    for (int m = 0; m < dtTabeleHeader.Rows.Count; m++)
                    {
                        decimal decWholColumnTotal = decAddDedColumnTotal[m];
                        string strWholColumnTotal = String.Format(formatString, decWholColumnTotal).ToString();

                        tableLayout.AddCell(new PdfPCell(new Phrase(strWholColumnTotal, FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        if ((m == intAddColSpan - 1 && intAddColSpan != 0) || (m == intAddColSpan + intDedColSpan - 1 && intDedColSpan != 0))
                        {
                            string strWholToalAmount = "";
                            if (m == intAddColSpan - 1)
                            {
                                strWholToalAmount = String.Format(formatString, decWholeTotalAdd).ToString();
                            }
                            else if (m == intAddColSpan + intDedColSpan - 1)
                            {
                                strWholToalAmount = String.Format(formatString, decWholeTotalDed).ToString();
                            }
                            tableLayout.AddCell(new PdfPCell(new Phrase(strWholToalAmount, FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = BaseColor.GRAY });
                        }
                    }
                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });


                    //table body

                    document.Add(tableLayout);

                    #endregion Table

                    float pos1 = writer.GetVerticalPosition(false);
                    PdfPTable endtable = new PdfPTable(6);
                    float[] endBody = { 25, 10, 25, 10, 25, 5 };
                    endtable.SetWidths(endBody);
                    endtable.WidthPercentage = 100;
                    endtable.TotalWidth = document.PageSize.Width - 80f;

                    endtable.AddCell(new PdfPCell(new Phrase("PREPARED BY", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                    endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                    endtable.AddCell(new PdfPCell(new Phrase("CHECKED BY", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
                    endtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, Padding = 6 });
                    endtable.AddCell(new PdfPCell(new Phrase("AUTHORIZED BY", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthRight = 0, Padding = 6 });
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
                Response.AddHeader("Content-Disposition", "attachment; filename=ManualAddDed_" + strNextId + ".pdf");
                Response.Buffer = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();
            }
        }

    }
    public class PDFHeader : PdfPageEventHelper
    {
        int intNewPageCount = 1;
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
        public override void OnStartPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            cls_Entity_Monthly_Salary_Process objEntPrcss = new cls_Entity_Monthly_Salary_Process();
            cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();

            objEntPrcss.CorpOffice = Convert.ToInt32(HttpContext.Current.Session["CORPOFFICEID"].ToString());
            objEntPrcss.Orgid = Convert.ToInt32(HttpContext.Current.Session["ORGID"].ToString());

            DataTable dtCorp = objBuss.ReadCorporateAddress(objEntPrcss);
            string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "", strCompanyLogo = "";

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

            PdfPTable headtable = new PdfPTable(2);
            headtable.AddCell(new PdfPCell(new Phrase("MANUAL ADDITION/DEDUCTION LIST", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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

            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
            if (intNewPageCount != 1)
            {
                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
            }
            intNewPageCount++;

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
    #endregion PDF PRINT
}