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

public partial class HCM_HCM_Master_hcm_PayrollSystem_hcm_Manual_AddDed_Entry_hcm_Manual_AddDed_Entry : System.Web.UI.Page
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
            if (Request.QueryString["Id"] != null)
            {
                HiddenFieldEditMode.Value = "1";
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string Id = strRandomMixedId.Substring(2, intLenghtofId);

                clsEntityManualAddDedEntry objentity = new clsEntityManualAddDedEntry();
                clsBusinessLayerManualAddDedEntry objBussiness = new clsBusinessLayerManualAddDedEntry();
                objentity.MasterTabId = Convert.ToInt32(Id);
                DataTable dtDup = objBussiness.ReadDataById(objentity);
                CurrMonth = dtDup.Rows[0]["PAYINF_MONTH"].ToString();
                CurrYear = dtDup.Rows[0]["PAYINF_YEAR"].ToString();
                ddlMonth.Disabled = true;
                ddlYear.Disabled = true;
                HiddenFieldMasterDbId.Value = Id;
                TabeleHeaderLoadEdit(Id);
            }
            else
            {
                TabeleHeaderLoad();
            }
            if (Request.QueryString["Mnt"] != null && Request.QueryString["Year"] != null)
            {
                CurrMonth = Request.QueryString["Mnt"].ToString();
                CurrYear = Request.QueryString["Year"].ToString();
            }
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
        if(strMonth=="")
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
    [WebMethod]
    public static string changeYear(string corptID, string year)
    {
        string strmnth = "";
        clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
        clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityLeavSettlmt.CorpId = Convert.ToInt32(corptID);
        DataTable dtCorpSal = objBusinessLeavSettlmt.ReadCorpSal(objEntityLeavSettlmt);
        DateTime dtCorpSalaryDate = objCommon.textToDateTime(dtCorpSal.Rows[0]["COPRT_SALARY_DATE"].ToString());
        int corpSalYear = dtCorpSalaryDate.Year;
        int corpSalMonth = dtCorpSalaryDate.Month;
        int start = 0;
        if (year == corpSalYear.ToString())
        {
            start = corpSalMonth - 1;
        }
        var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
        for (int i = start; i < months.Length - 1; i++)
        {
            strmnth+="<option value=\""+(i+1)+"\">"+months[i]+"</option>";
        }
        return strmnth;
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
            if(corpSalYear<=DateTime.Today.Year)
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
                ddlYear.Items.Add((corpSalYear+i).ToString());
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
        string defAmnt=String.Format(formatString, 0).ToString();

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
        if(AddColSpan!="0")
        objstr.Append("<th colspan=\"" + (Convert.ToInt32(AddColSpan)+1).ToString() + "\">Additions</th>");
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
        if (DedColSpan != "0" && (Convert.ToInt32(DedColSpan)+ Convert.ToInt32(AddColSpan))- 1 == i)
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
    public void TabeleHeaderLoadEdit(string id)
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
        objentity.MasterTabId = Convert.ToInt32(id);
        DataTable dt = objBussiness.ReadManualAddDedEdit(objentity);
        StringBuilder objstr = new StringBuilder();
        StringBuilder objstrFoot = new StringBuilder();

        string AddColSpan = "0", DedColSpan = "0";
        if (dt.Rows.Count > 0)
        {
            DataRow[] resultAdd = dt.Select("PAYRL_MODE =1");
            DataRow[] resultDed = dt.Select("PAYRL_MODE =2");

            AddColSpan = Convert.ToString(resultAdd.Length);
            DedColSpan = Convert.ToString(resultDed.Length);
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

            objstr.Append("<td class=\"th_b7_5_c tr_r\">" + dt.Rows[i]["PAYRL_CODE"].ToString() + "<a href=\"#\"  onclick=\"return ShowDescCommon(" + i + ");\" class=\"fa fa-commenting-o fzd\" data-toggle=\"popover\" data-html=\"true\" data-content=\"<textarea id='txtDescCommon_" + i + "' onkeydown='textCounter(txtDescCommon_" + i + ",450,event);' onkeyup='textCounter(txtDescCommon_" + i + ",450,event);' onchange='return changeTextDesc(" + i + ");'   type='text' row='2'placeholder='Add Remarks'></textarea>\" title=\"" + dt.Rows[i]["PAYRL_CODE"].ToString() + "\"></a></td>");
            objstr.Append("<input id=\"tdAddDedId_" + i + "\" name=\"tdAddDedId_" + i + "\" style=\"display:none;\" value=\"" + dt.Rows[i]["PAYRL_ID"].ToString() + "\" />");
            if (dt.Rows[i]["PAYRL_STATUS"].ToString() == "0" || dt.Rows[i]["PAYRL_CNCL_USR_ID"].ToString() != "" || dt.Rows[i]["PAYRL_DIRECT_STS"].ToString() == "0")
            {
                objstr.Append("<input id=\"tdAddDedIdAct_" + i + "\" name=\"tdAddDedIdAct_" + i + "\" style=\"display:none;\" value=\"0\" />");
            }
            else
            {
                objstr.Append("<input id=\"tdAddDedIdAct_" + i + "\" name=\"tdAddDedIdAct_" + i + "\" style=\"display:none;\" value=\"1\" />");
            }
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
        string[] sts= new string[3];
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
                    if(valSplit[4]!="")
                        objEntityDtls.DescChangeSts = Convert.ToInt32(valSplit[4]);
                    objAddDedList.Add(objEntityDtls);
                }
            }
            DataTable dtDup = objBussiness.readMonthYearData(objentity);
            if (dtDup.Rows.Count>0 && dtDup.Rows[0]["PAYINF_CNCL_USR_ID"].ToString() != "")
            {
                sts[1] = "AlCncl";
            }
            else if (dtDup.Rows.Count > 0 && Mode != "3" && dtDup.Rows[0]["PAYINF_CONF_USR_ID"].ToString() != "")
            {
                sts[1] = "AlConf";
            }
            else if (dtDup.Rows.Count > 0 && Mode == "3" && dtDup.Rows[0]["PAYINF_REOPN_USR_ID"].ToString() != "")
            {
                sts[1] = "AlReop";
            }
            else
            {
                objBussiness.insUpdEmpDtls(objentity, objAddDedList);
                sts[0] = objentity.MasterTabId.ToString();
                sts[2] = objentity.cancelReason;
            }
        }
        catch(Exception ex){
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
        string sts ="0";
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
            objentity.cancelReason = ids.Replace('-',',');
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
        string[] sts =new string[4];
        try
        {
            clsEntityManualAddDedEntry objentity = new clsEntityManualAddDedEntry();
            clsBusinessLayerManualAddDedEntry objBussiness = new clsBusinessLayerManualAddDedEntry();
            objentity.Organisation_Id = Convert.ToInt32(orgID);
            objentity.CorpOffice_Id = Convert.ToInt32(corptID);
            objentity.MonthId = Convert.ToInt32(month);
            objentity.YearId = Convert.ToInt32(year);
            objentity.MasterTabId = Convert.ToInt32(Id);
            DataTable dt = objBussiness.readMonthYearData(objentity);
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
                                AddDedkeyValue = row["PAYRL_ID"].ToString() + "%" + row["PAYINFDT_AMOUNT"].ToString() + "%" + row["PAYINFDT_ID"].ToString()+ "%" + row["PAYINFDT_DESCRIPTION"].ToString() + "%" + row["PAYINFDT_CHANGE_DESC_STS"].ToString();
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
            objentity.MasterTabId = Convert.ToInt32(MasterDbId);
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
        string sts ="";
        try
        {
            AddDedkeyValue = AddDedkeyValue.Replace('%',',');
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
    protected void btnAdd_Click(object sender, EventArgs e)    
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityManualAddDedEntry objentity = new clsEntityManualAddDedEntry();
        clsBusinessLayerManualAddDedEntry objBussiness = new clsBusinessLayerManualAddDedEntry();
        if (Session["CORPOFFICEID"] != null)
        {
            objentity.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objentity.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objentity.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        objentity.MonthId = Convert.ToInt32(ddlMonth.Value);
        objentity.YearId = Convert.ToInt32(ddlYear.Value);
        DataTable dt = objBussiness.ReadManualAddDed(objentity);
        HiddenFieldHeaderList.Value = "";
        if (dt.Rows.Count > 0)
        {
            string strFilePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.EMPLOYEE_DAILY_HOUR);
            //for delete all the files in the specific folder.
            Array.ForEach(Directory.GetFiles(Server.MapPath(strFilePath)), File.Delete);
            if (FileUploader.HasFile)
            {
                FileUploader.SaveAs(Server.MapPath(strFilePath) + FileUploader.PostedFile.FileName);
                HiddenFile.Value = FileUploader.PostedFile.FileName;
            }
            string strData = Server.MapPath(strFilePath) + "/" + FileUploader.PostedFile.FileName;
            try
            {
                int Mainlen = 0;
                var HeaderList = new List<string[]>();
                var OuterLines = new List<string[]>();
                var CorrectList = new List<string[]>();
                var MissingCodeList = new List<string[]>();
                var DuplicateCodeList = new List<string[]>();
                var IncorrectCodeList = new List<string[]>();
                var MissingAmountList = new List<string[]>();
                var IncorrectAmountList = new List<string[]>();
                var BlockedEmpList = new List<string[]>();
                string strRemoveRows = "";

                using (CsvFileReader reader = new CsvFileReader(strData))
                {
                    CsvRow row = new CsvRow();
                    while (reader.ReadRow(row))
                    {
                        //string array for store the csv file row.
                        string[] Line = row.ToArray();
                        OuterLines.Add(Line);
                    }
                }
                var OuterLinesCopy = new List<string[]>(OuterLines);
                OuterLinesCopy = OuterLines.ToList();

                //Header checking
                string strHeaderSts = "1";
                if (OuterLinesCopy.Count < 2 || OuterLinesCopy[0].Length < 3)
                {
                    strHeaderSts = "0";
                }
                if (strHeaderSts == "1")
                {
                    Mainlen = OuterLinesCopy[0].Length;
                    for (int i = 2; i < Mainlen; i++)
                    {
                        string strItem = OuterLinesCopy[0][i].ToString().ToUpper();
                        if (HiddenFieldHeaderList.Value == "")
                        {
                            HiddenFieldHeaderList.Value = strItem;
                        }
                        else
                        {
                            HiddenFieldHeaderList.Value = HiddenFieldHeaderList.Value + "-" + strItem;
                        }
                        DataRow[] result = dt.Select("PAYRL_CODE ='" + strItem + "'");
                        if (result.Length == 0)
                        {
                            strHeaderSts = "0";
                            break;
                        }
                    }
                }
                //When header is correct
                if (strHeaderSts == "1")
                {
                    for (int intRow = OuterLinesCopy.Count - 1; intRow >= 1; intRow--)
                    {
                        string strCorrectSts = "1";

                        //Employee code validation
                        if (OuterLinesCopy[intRow][0] == null || OuterLinesCopy[intRow][0] == "")
                        {
                            MissingCodeList.Add(OuterLinesCopy[intRow]);
                            strCorrectSts = "0";
                        }
                        else
                        {
                            string sReas = objentity.cancelReason;
                            objentity.cancelReason = OuterLinesCopy[intRow][0];
                            DataTable dtEmp = objBussiness.checkEmpcode(objentity);
                            if (dtEmp.Rows.Count == 0)
                            {
                                IncorrectCodeList.Add(OuterLinesCopy[intRow]);
                                strCorrectSts = "0";
                            }
                            else if (dtEmp.Rows[0]["USR_CNCL_USR_ID"].ToString() != "" || dtEmp.Rows[0]["USR_STATUS"].ToString() != "1" || dtEmp.Rows[0]["RSGN_STS"].ToString() != "0")
                            {
                                IncorrectCodeList.Add(OuterLinesCopy[intRow]);
                                strCorrectSts = "0";
                            }
                            else
                            {
                                int flagDup = 0;
                                //checking duplicate employee code inside the uploaded file
                                string strEmpCode = OuterLinesCopy[intRow][0].ToString();
                                for (int intSecondRow = OuterLinesCopy.Count - 1; intSecondRow >= 1; intSecondRow--)
                                {
                                    if (intRow != intSecondRow)
                                    {
                                        if (strEmpCode == OuterLinesCopy[intSecondRow][0].ToString())
                                        {
                                            flagDup = 1;
                                            DuplicateCodeList.Add(OuterLinesCopy[intRow]);
                                            strCorrectSts = "0";
                                            break;
                                        }
                                    }
                                }
                                //checking duplicate employee code inside the database table
                                if (flagDup == 0)
                                {
                                    objentity.cancelReason = "";
                                    objentity.EmployeeId = Convert.ToInt32(dtEmp.Rows[0][0].ToString());
                                    DataTable dtDup = objBussiness.checkEmployeeDuplication(objentity);
                                    objentity.cancelReason = sReas;
                                    if (dtDup.Rows[0][0].ToString() != "0")
                                    {
                                        DuplicateCodeList.Add(OuterLinesCopy[intRow]);
                                        strCorrectSts = "0";
                                    }
                                }
                                //For check salary processed
                                DateTime Curr = new DateTime(objentity.YearId, objentity.MonthId, 01);
                                objentity.StartDate = objCommon.textToDateTime(Curr.ToString("dd-MM-yyyy"));
                                int daysInm = DateTime.DaysInMonth(objentity.YearId, objentity.MonthId);
                                DateTime CurLast = new DateTime(objentity.YearId, objentity.MonthId, daysInm);
                                objentity.EndDate = objCommon.textToDateTime(CurLast.ToString("dd-MM-yyyy"));
                                clsBusinessLayer objBusis = new clsBusinessLayer();
                                clsEntityCommon ObjEntitySales = new clsEntityCommon();
                                ObjEntitySales.UserId = Convert.ToInt32(dtEmp.Rows[0][0].ToString());
                                DataTable dtS = objBusis.CheckLastSalProcess(ObjEntitySales);
                                if (dtS.Rows.Count > 0 && objCommon.textToDateTime(dtS.Rows[0]["EMPERDTL_JOIN_DATE1"].ToString()) >= objCommon.textToDateTime(Curr.ToString("dd-MM-yyyy")))
                                {
                                    BlockedEmpList.Add(OuterLinesCopy[intRow]);
                                    strCorrectSts = "0";
                                }
                                else
                                {
                                    objentity.EmployeeId = Convert.ToInt32(dtEmp.Rows[0][0].ToString());
                                    DataTable dtSs = objBussiness.checkEmpLeave(objentity);
                                    if (dtSs.Rows[0][0].ToString() != "0")
                                    {
                                        BlockedEmpList.Add(OuterLinesCopy[intRow]);
                                        strCorrectSts = "0";
                                    }
                                }

                            }
                        }
                        //Addition/deduction validation
                        int len = OuterLinesCopy[intRow].Length;
                        if (len > Mainlen)
                            len = Mainlen;
                        if (len < 3)
                        {
                            MissingAmountList.Add(OuterLinesCopy[intRow]);
                            strCorrectSts = "0";
                        }
                        else
                        {
                            int flag = 0;
                            for (int i = 2; i < len; i++)
                            {
                                string strItem = OuterLinesCopy[intRow][i].ToString().ToUpper();
                                if (strItem != "" && strItem != null)
                                {
                                    flag = 1;
                                    decimal decValue;
                                    bool isAmntdecimal = true;
                                    isAmntdecimal = decimal.TryParse(OuterLinesCopy[intRow][i].ToString(), out decValue);
                                    if (isAmntdecimal == false)
                                    {
                                        IncorrectAmountList.Add(OuterLinesCopy[intRow]);
                                        strCorrectSts = "0";
                                        break;
                                    }
                                }
                            }
                            if (flag == 0)
                            {
                                MissingAmountList.Add(OuterLinesCopy[intRow]);
                                strCorrectSts = "0";
                            }
                        }


                        if (strCorrectSts == "0")
                        {
                            if (strRemoveRows == "")
                            {
                                strRemoveRows = intRow.ToString();
                            }
                            else
                            {
                                strRemoveRows = strRemoveRows + "," + intRow.ToString();
                            }
                        }

                    }

                    string DaysStr = strRemoveRows;
                    string[] spitDayStr = DaysStr.Split(',');
                    foreach (string strSpliSlice in spitDayStr)
                    {
                        if (strSpliSlice != "")
                        {
                            OuterLines.RemoveAt(Convert.ToInt32(strSpliSlice));
                        }
                    }
                    OuterLines.RemoveAt(0);


                    //For binding data into different tables

                    //Missing employee code list
                    MissingCodeList.Reverse();
                    HiddenMissingCodeListCount.Value = MissingCodeList.Count.ToString();
                    if (MissingCodeList.Count < 100)
                    {
                        btnMissingCodeListNext.Enabled = false;
                        string strCodeMissingHtml = CovertListToHTMLincrct(MissingCodeList,0);
                        divMissingCodeList.InnerHtml = strCodeMissingHtml;
                    }
                    else
                    {
                        btnMissingCodeListNext.Enabled = true;

                        string strCodeMissingJson = ConvertArrayToJson(MissingCodeList);
                        HiddenMissingCodeList.Value = strCodeMissingJson;
                        var NewIncorrectEmployeeCodeList = new List<string[]>();
                        for (int intRow = 0; intRow < 100; intRow++)
                        {
                            NewIncorrectEmployeeCodeList.Add(MissingCodeList[intRow]);
                        }
                        HiddenMissingCodeListNext.Value = "100";
                        string strCodeMissingHtml = CovertListToHTMLincrct(NewIncorrectEmployeeCodeList,0);
                        divMissingCodeList.InnerHtml = strCodeMissingHtml;
                    }

                    //Incorrect employee code list
                    IncorrectCodeList.Reverse();
                    HiddenIncorrectCodeListCount.Value = IncorrectCodeList.Count.ToString();
                    if (IncorrectCodeList.Count < 100)
                    {
                        btnIncorrectCodeListNext.Enabled = false;
                        string strCodeMissingHtml = CovertListToHTMLincrct(IncorrectCodeList,1);
                        divIncorrectCodeList.InnerHtml = strCodeMissingHtml;
                    }
                    else
                    {
                        btnIncorrectCodeListNext.Enabled = true;

                        string strCodeMissingJson = ConvertArrayToJson(IncorrectCodeList);
                        HiddenIncorrectCodeList.Value = strCodeMissingJson;
                        var NewIncorrectEmployeeCodeList = new List<string[]>();
                        for (int intRow = 0; intRow < 100; intRow++)
                        {
                            NewIncorrectEmployeeCodeList.Add(IncorrectCodeList[intRow]);
                        }
                        HiddenIncorrectCodeListNext.Value = "100";
                        string strCodeMissingHtml = CovertListToHTMLincrct(NewIncorrectEmployeeCodeList,1);
                        divIncorrectCodeList.InnerHtml = strCodeMissingHtml;
                    }

                    //Duplicate employee code list
                    DuplicateCodeList.Reverse();
                    HiddenDuplicateCodeListCount.Value = DuplicateCodeList.Count.ToString();
                    if (DuplicateCodeList.Count < 100)
                    {
                        btnDuplicateCodeListNext.Enabled = false;
                        string strCodeMissingHtml = CovertListToHTMLincrct(DuplicateCodeList,0);
                        divDuplicateCodeList.InnerHtml = strCodeMissingHtml;
                    }
                    else
                    {
                        btnDuplicateCodeListNext.Enabled = true;

                        string strCodeMissingJson = ConvertArrayToJson(DuplicateCodeList);
                        HiddenDuplicateCodeList.Value = strCodeMissingJson;
                        var NewIncorrectEmployeeCodeList = new List<string[]>();
                        for (int intRow = 0; intRow < 100; intRow++)
                        {
                            NewIncorrectEmployeeCodeList.Add(DuplicateCodeList[intRow]);
                        }
                        HiddenDuplicateCodeListNext.Value = "100";
                        string strCodeMissingHtml = CovertListToHTMLincrct(NewIncorrectEmployeeCodeList,0);
                        divDuplicateCodeList.InnerHtml = strCodeMissingHtml;
                    }

                    //Missing amount list
                    MissingAmountList.Reverse();
                    HiddenMissingAmountListCount.Value = MissingAmountList.Count.ToString();
                    if (MissingAmountList.Count < 100)
                    {
                        btnMissingAmountListNext.Enabled = false;
                        string strCodeMissingHtml = CovertListToHTMLincrct(MissingAmountList,0);
                        divMissingAmountList.InnerHtml = strCodeMissingHtml;
                    }
                    else
                    {
                        btnMissingAmountListNext.Enabled = true;

                        string strCodeMissingJson = ConvertArrayToJson(MissingAmountList);
                        HiddenMissingAmountList.Value = strCodeMissingJson;
                        var NewIncorrectEmployeeCodeList = new List<string[]>();
                        for (int intRow = 0; intRow < 100; intRow++)
                        {
                            NewIncorrectEmployeeCodeList.Add(MissingAmountList[intRow]);
                        }
                        HiddenMissingAmountListNext.Value = "100";
                        string strCodeMissingHtml = CovertListToHTMLincrct(NewIncorrectEmployeeCodeList,0);
                        divMissingAmountList.InnerHtml = strCodeMissingHtml;
                    }
                    //Incorrect amount list
                    IncorrectAmountList.Reverse();
                    HiddenIncorrectAmountListCount.Value = IncorrectAmountList.Count.ToString();
                    if (IncorrectAmountList.Count < 100)
                    {
                        btnIncorrectAmountListNext.Enabled = false;
                        string strCodeMissingHtml = CovertListToHTMLincrct(IncorrectAmountList,0);
                        divIncorrectAmountList.InnerHtml = strCodeMissingHtml;
                    }
                    else
                    {
                        btnIncorrectAmountListNext.Enabled = true;

                        string strCodeMissingJson = ConvertArrayToJson(IncorrectAmountList);
                        HiddenIncorrectAmountList.Value = strCodeMissingJson;
                        var NewIncorrectEmployeeCodeList = new List<string[]>();
                        for (int intRow = 0; intRow < 100; intRow++)
                        {
                            NewIncorrectEmployeeCodeList.Add(IncorrectAmountList[intRow]);
                        }
                        HiddenIncorrectAmountListNext.Value = "100";
                        string strCodeMissingHtml = CovertListToHTMLincrct(NewIncorrectEmployeeCodeList,0);
                        divIncorrectAmountList.InnerHtml = strCodeMissingHtml;
                    }
                    //Blocked employee list
                    BlockedEmpList.Reverse();
                    HiddenBlockedEmpListCount.Value = BlockedEmpList.Count.ToString();
                    if (BlockedEmpList.Count < 100)
                    {
                        btnBlockedEmpListNext.Enabled = false;
                        string strCodeMissingHtml = CovertListToHTMLincrct(BlockedEmpList,2);
                        divBlockedEmpList.InnerHtml = strCodeMissingHtml;
                    }
                    else
                    {
                        btnBlockedEmpListNext.Enabled = true;

                        string strCodeMissingJson = ConvertArrayToJson(BlockedEmpList);
                        HiddenBlockedEmpList.Value = strCodeMissingJson;
                        var NewIncorrectEmployeeCodeList = new List<string[]>();
                        for (int intRow = 0; intRow < 100; intRow++)
                        {
                            NewIncorrectEmployeeCodeList.Add(BlockedEmpList[intRow]);
                        }
                        HiddenBlockedEmpListNext.Value = "100";
                        string strCodeMissingHtml = CovertListToHTMLincrct(NewIncorrectEmployeeCodeList,2);
                        divBlockedEmpList.InnerHtml = strCodeMissingHtml;
                    }

                    //Correct list
                    HiddenCostPriceMissingCount.Value = OuterLines.Count.ToString();
                    string strCodeMissingJsonv = ConvertArrayToJson(OuterLines);
                    HiddenCostPriceMissingList.Value = strCodeMissingJsonv;
                    btnRateMissingUpdate.Visible = true;
                    if (OuterLines.Count == 0)
                    {
                        btnRateMissingUpdate.Visible = false;
                    }

                    if (OuterLines.Count < 100)
                    {
                        btnCostPriceMissingNextRecords.Enabled = false;
                    }
                    else
                    {
                        btnCostPriceMissingNextRecords.Enabled = true;
                        HiddenCostPriceMissingNext.Value = "100";
                    }
                    divCostPriceMissingReport.InnerHtml = CovertCorrectListToHTML(OuterLines);

                    ScriptManager.RegisterStartupScript(this, GetType(), "ViewMissingProductCode", "ViewMissingProductCode();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "IncorrectHeader", "IncorrectHeader();", true);
                }
            }
            catch
            {

            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "IncorrectHeader", "IncorrectHeader();", true);
        }
    }
    public string CovertListToHTMLincrct(List<string[]> ProuctList,int mode)
    {
        clsEntityManualAddDedEntry objentity = new clsEntityManualAddDedEntry();
        clsBusinessLayerManualAddDedEntry objBussiness = new clsBusinessLayerManualAddDedEntry();
        if (Session["CORPOFFICEID"] != null)
        {
            objentity.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objentity.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        objentity.MonthId = Convert.ToInt32(ddlMonth.Value);
        objentity.YearId = Convert.ToInt32(ddlYear.Value);

        int cnt = 0;
        if (hiddenDecimalCount.Value != "")
        {
            cnt = Convert.ToInt32(hiddenDecimalCount.Value);
        }
        string formatString = String.Concat("{0:F", cnt, "}");
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        if (hiddenDfltCurrencyMstrId.Value != "")
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);


        int MainLength = 2;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        StringBuilder sb = new StringBuilder();
        sb.Append("<table class=\"table table-bordered tb_hcm_fx tbs1\">");
        sb.Append("<thead class=\"thead1\">");         
        sb.Append("<tr class=\"add_ddcn\">");
        sb.Append("<th class=\"th_b8 tr_l\">Employee Code</th>");
        sb.Append("<th class=\"th_b13 tr_l\">Employee Name</th>");
        string DaysStr = HiddenFieldHeaderList.Value;
        string[] spitDayStr = DaysStr.Split('-');
        foreach (string strSpliSlice in spitDayStr)
        {
          if (strSpliSlice != "")
          {
              sb.Append("<th class=\"th tr_r\">" + strSpliSlice + "</th>");
            MainLength++;
          }
        }
        if (mode > 0)
        {
            sb.Append("<th class=\"tr_l\">Remarks</th>");
        }
        sb.Append("</tr>");
        sb.Append("</thead>");
        sb.Append("<tbody>");
        if (ProuctList.Count == 0)
        {
            sb.Append("<tr>");
            sb.Append("<td class=\"\" colspan='30'> <p style=\"text-align: center;font-family: calibri;\">No Data Available</p></td>");
            sb.Append("</tr>");

        }
        else
        {
            for (int intRowBodyCount = 0; intRowBodyCount < ProuctList.Count; intRowBodyCount++)
            {
               string strRemark = "";
               int len = ProuctList[intRowBodyCount].Length;
               sb.Append("<tr>");
               for(int i=0;i<MainLength;i++){
                   if(i<len){
                       if (i < 2)
                       {
                           sb.Append("<td class=\"tr_l\">" + ProuctList[intRowBodyCount][i].ToString() + "</td>");
                       }
                       else
                       {
                           string strNetAmountWithComma = ProuctList[intRowBodyCount][i].ToString();
                           decimal decValue;
                           bool isAmntdecimal = true;
                           isAmntdecimal = decimal.TryParse(ProuctList[intRowBodyCount][i].ToString(), out decValue);
                           if (isAmntdecimal == true)
                           {
                               strNetAmountWithComma = objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString, Convert.ToDecimal(ProuctList[intRowBodyCount][i].ToString())).ToString(), objEntityCommon);
                           }
                           sb.Append("<td class=\"tr_r\">" + strNetAmountWithComma + "</td>");
                       }
                   }
                   else{
                     sb.Append("<td></td>");
                   }
                }
               if (mode > 0)
               {
                   objentity.cancelReason = ProuctList[intRowBodyCount][0].ToString();
                   DataTable dtEmp = objBussiness.checkEmpcode(objentity);
                   if (dtEmp.Rows.Count == 0)
                   {
                       strRemark = "Incorrect employee code";
                   }
                   else if (dtEmp.Rows[0]["USR_CNCL_USR_ID"].ToString() !="")
                   {
                       strRemark = "Cancelled employee";
                   }
                   else if (dtEmp.Rows[0]["USR_STATUS"].ToString() == "0")
                   {
                       strRemark = "Inactive employee";
                   }
                   else if (dtEmp.Rows[0]["RSGN_STS"].ToString() == "1")
                   {
                       strRemark = "Resigned employee";
                   }
                   else if (dtEmp.Rows[0]["RSGN_STS"].ToString() == "2")
                   {
                       strRemark = "Terminated employee";
                   }
                   else
                   {
                       //For check salary processed
                       DateTime Curr = new DateTime(objentity.YearId, objentity.MonthId, 01);
                       objentity.StartDate = objCommon.textToDateTime(Curr.ToString("dd-MM-yyyy"));
                       int daysInm = DateTime.DaysInMonth(objentity.YearId, objentity.MonthId);
                       DateTime CurLast = new DateTime(objentity.YearId, objentity.MonthId, daysInm);
                       objentity.EndDate = objCommon.textToDateTime(CurLast.ToString("dd-MM-yyyy"));
                       clsBusinessLayer objBusis = new clsBusinessLayer();
                       clsEntityCommon ObjEntitySales = new clsEntityCommon();
                       ObjEntitySales.UserId = Convert.ToInt32(dtEmp.Rows[0][0].ToString());
                       DataTable dtS = objBusis.CheckLastSalProcess(ObjEntitySales);
                       if (dtS.Rows.Count > 0 && objCommon.textToDateTime(dtS.Rows[0]["EMPERDTL_JOIN_DATE1"].ToString()) >= objCommon.textToDateTime(Curr.ToString("dd-MM-yyyy")))
                       {
                           strRemark = dtS.Rows[0]["MOD"].ToString();
                       }
                       else
                       {
                           objentity.EmployeeId = Convert.ToInt32(dtEmp.Rows[0][0].ToString());
                           DataTable dtSs = objBussiness.checkEmpLeave(objentity);
                           if (dtSs.Rows[0][0].ToString() != "0")
                           {
                               strRemark = "On leave";
                           }
                       }
                   }
                   sb.Append("<td class=\"tr_l\">" + strRemark + "</td>");
               }
               sb.Append("</tr>");
            }
        }
        sb.Append("</tbody>");
        sb.Append("</table>");
        return sb.ToString();
    }
    [WebMethod]
    public static string[] ServiceListToHtmlIncrct(string strList, string strCount, string strMode, string strTotalCount, string Header, string DecimalCnt, string CurrencyId, string orgID, string corptID, string month, string year, string RemarkMode)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityManualAddDedEntry objentity = new clsEntityManualAddDedEntry();
        clsBusinessLayerManualAddDedEntry objBussiness = new clsBusinessLayerManualAddDedEntry();
        objentity.CorpOffice_Id = Convert.ToInt32(corptID);
        objentity.Organisation_Id = Convert.ToInt32(orgID);
        objentity.MonthId = Convert.ToInt32(month);
        objentity.YearId = Convert.ToInt32(year);

        int cnt = 0;
        if (DecimalCnt != "")
        {
            cnt = Convert.ToInt32(DecimalCnt);
        }
        string formatString = String.Concat("{0:F", cnt, "}");
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        if (CurrencyId != "")
            objEntityCommon.CurrencyId = Convert.ToInt32(CurrencyId);


        int intCount = Convert.ToInt32(strCount);
        int intFinalCount = 0;
        string[] strOutput = new string[2];

        if (intCount < 100)
            intCount = 0;

        //strMode=1 for next and 0 for previous.
        if (strMode == "1")
        {
            intFinalCount = intCount + 100;
            if (intFinalCount > Convert.ToInt32(strTotalCount))
                intFinalCount = Convert.ToInt32(strTotalCount);
        }
        else
        {
            if (intCount % 100 == 0)
            {
                intFinalCount = intCount - 100;
                intCount = intCount - 200;
                if (intCount < 0)
                    intCount = 0;
            }
            else
            {
                intFinalCount = (intCount / 100) * 100;
                intCount = intFinalCount - 100;
                if (intCount < 0)
                    intCount = 0;
            }
        }

        if (intFinalCount % 100 != 0)
        {
            intCount = intFinalCount % 100;
            intCount = intFinalCount - intCount;
        }

        int MainLength = 2;
        StringBuilder sb = new StringBuilder();
        if (strList != "0")
        {
            string[][] ProuctList = JsonConvert.DeserializeObject<string[][]>(strList);
            sb.Append("<table class=\"table table-bordered tb_hcm_fx tbs1\">");
            sb.Append("<thead class=\"thead1\">");
            sb.Append("<tr class=\"add_ddcn\">");
            sb.Append("<th class=\"th_b8 tr_l\">Employee Code</th>");
            sb.Append("<th class=\"th_b13 tr_l\">Employee Name</th>");
            string DaysStr = Header;
            string[] spitDayStr = DaysStr.Split('-');
            foreach (string strSpliSlice in spitDayStr)
            {
                if (strSpliSlice != "")
                {
                    sb.Append("<th class=\"th tr_r\">" + strSpliSlice + "</th>");
                    MainLength++;
                }
            }
            if (Convert.ToInt32(RemarkMode) > 0)
            {
                sb.Append("<th class=\"tr_l\">Remarks</th>");
            }
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("<tbody>");
            for (int intRowBodyCount = intCount; intRowBodyCount < intFinalCount; intRowBodyCount++)
            {
                string strRemark = "";
                int len = ProuctList[intRowBodyCount].Length;
                sb.Append("<tr>");
                for (int i = 0; i < MainLength; i++)
                {
                    if (i < len)
                    {
                        if (i < 2)
                        {
                            sb.Append("<td class=\"tr_l\">" + ProuctList[intRowBodyCount][i].ToString() + "</td>");
                        }
                        else
                        {
                            string strNetAmountWithComma = ProuctList[intRowBodyCount][i].ToString();
                            decimal decValue;
                            bool isAmntdecimal = true;
                            isAmntdecimal = decimal.TryParse(ProuctList[intRowBodyCount][i].ToString(), out decValue);
                            if (isAmntdecimal == true)
                            {
                                strNetAmountWithComma = objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString, Convert.ToDecimal(ProuctList[intRowBodyCount][i].ToString())).ToString(), objEntityCommon);
                            }

                            sb.Append("<td class=\"tr_r\">" + strNetAmountWithComma + "</td>");
                        }
                    }
                    else
                    {
                        sb.Append("<td></td>");
                    }
                }
                if (Convert.ToInt32(RemarkMode) > 0)
                {
                    objentity.cancelReason = ProuctList[intRowBodyCount][0].ToString();
                    DataTable dtEmp = objBussiness.checkEmpcode(objentity);
                    if (dtEmp.Rows.Count == 0)
                    {
                        strRemark = "Incorrect employee code";
                    }
                    else if (dtEmp.Rows[0]["USR_CNCL_USR_ID"].ToString() != "")
                    {
                        strRemark = "Cancelled employee";
                    }
                    else if (dtEmp.Rows[0]["USR_STATUS"].ToString() == "0")
                    {
                        strRemark = "Inactive employee";
                    }
                    else if (dtEmp.Rows[0]["RSGN_STS"].ToString() == "1")
                    {
                        strRemark = "Resigned employee";
                    }
                    else if (dtEmp.Rows[0]["RSGN_STS"].ToString() == "2")
                    {
                        strRemark = "Terminated employee";
                    }
                    else
                    {
                        //For check salary processed
                        DateTime Curr = new DateTime(objentity.YearId, objentity.MonthId, 01);
                        objentity.StartDate = objCommon.textToDateTime(Curr.ToString("dd-MM-yyyy"));
                        int daysInm = DateTime.DaysInMonth(objentity.YearId, objentity.MonthId);
                        DateTime CurLast = new DateTime(objentity.YearId, objentity.MonthId, daysInm);
                        objentity.EndDate = objCommon.textToDateTime(CurLast.ToString("dd-MM-yyyy"));
                        clsBusinessLayer objBusis = new clsBusinessLayer();
                        clsEntityCommon ObjEntitySales = new clsEntityCommon();
                        ObjEntitySales.UserId = Convert.ToInt32(dtEmp.Rows[0][0].ToString());
                        DataTable dtS = objBusis.CheckLastSalProcess(ObjEntitySales);
                        if (dtS.Rows.Count > 0 && objCommon.textToDateTime(dtS.Rows[0]["EMPERDTL_JOIN_DATE1"].ToString()) >= objCommon.textToDateTime(Curr.ToString("dd-MM-yyyy")))
                        {
                            strRemark = dtS.Rows[0]["MOD"].ToString();
                        }
                        else
                        {
                            objentity.EmployeeId = Convert.ToInt32(dtEmp.Rows[0][0].ToString());
                            DataTable dtSs = objBussiness.checkEmpLeave(objentity);
                            if (dtSs.Rows[0][0].ToString() != "0")
                            {
                                strRemark = "On leave";
                            }
                        }
                    }
                    sb.Append("<td class=\"tr_l\">" + strRemark + "</td>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</tbody>");
            sb.Append("</table>");
        }
        strOutput[0] = sb.ToString();
        strOutput[1] = intFinalCount.ToString();
        return strOutput;
    }
    public string CovertCorrectListToHTML(List<string[]> ProuctList)
    {
        int cnt = 0;
        if (hiddenDecimalCount.Value != "")
        {
            cnt = Convert.ToInt32(hiddenDecimalCount.Value);
        }
        string formatString = String.Concat("{0:F", cnt, "}");
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        if(hiddenDfltCurrencyMstrId.Value!="")
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);

        int MainLength = 2;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        StringBuilder sb = new StringBuilder();
        sb.Append("<table class=\"table table-bordered tb_hcm_fx tbs1\">");
        sb.Append("<thead id=\"theadCorrect\"class=\"thead1\">");
        sb.Append("<tr class=\"add_ddcn\">");
        sb.Append("<th class=\"th_b8 tr_l\">Employee Code</th>");
        sb.Append("<th class=\"th_b13 tr_l\">Employee Name</th>");
        string DaysStr = HiddenFieldHeaderList.Value;
        string[] spitDayStr = DaysStr.Split('-');
        foreach (string strSpliSlice in spitDayStr)
        {
            if (strSpliSlice != "")
            {
                sb.Append("<th class=\"th tr_r\">" + strSpliSlice + "</th>");
                MainLength++;
            }
        }
        sb.Append("<th class=\"th_b1\">Actions</th>");
        sb.Append("</tr>");
        sb.Append("</thead>");
        sb.Append("<tbody id=\"tbodyCorrect\">");
        if (ProuctList.Count == 0)
        {
            sb.Append("<tr>");
            sb.Append("<td class=\"\" colspan='30'> <p style=\"text-align: center;font-family: calibri;\">No Data Available</p></td>");
            sb.Append("</tr>");

        }
        else
        {
            for (int intRowBodyCount = 0; intRowBodyCount < ProuctList.Count; intRowBodyCount++)
            {
                int len = ProuctList[intRowBodyCount].Length;
                if (intRowBodyCount >= 100)
                {
                    sb.Append("<tr id=\"tbodyCorrectRow_" + intRowBodyCount + "\" class=\"CorrectRow\" style=\"display:none;\">");
                }
                else
                {
                    sb.Append("<tr id=\"tbodyCorrectRow_" + intRowBodyCount + "\" class=\"CorrectRow\">");
                }              
                for (int i = 0; i < MainLength; i++)
                {
                    if (i < len)
                    {
                        if (i < 2)
                        {
                            sb.Append("<td id=\"txtFieldCsv_" + intRowBodyCount + "_" + i + "\" class=\"tr_l\">" + ProuctList[intRowBodyCount][i].ToString() + "</td>");
                        }
                        else
                        {
                            string strNetAmountWithComma = "";
                            if (ProuctList[intRowBodyCount][i].ToString() != null && ProuctList[intRowBodyCount][i].ToString() != "")
                            {
                                strNetAmountWithComma = objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString, Convert.ToDecimal(ProuctList[intRowBodyCount][i].ToString())).ToString(), objEntityCommon);
                            }
                            sb.Append("<td class=\"tr_r\"><input onchange=\"return BlurNotNumberCsv(\'txtAddDedCsv_" + intRowBodyCount + "_" + i + "\');\" onkeydown=\"return isDecimalNumber(event,\'txtAddDedCsv_" + intRowBodyCount + "_" + i + "\');\" onkeypress=\"return isDecimalNumber(event,\'txtAddDedCsv_" + intRowBodyCount + "_" + i + "\');\"  id=\"txtAddDedCsv_" + intRowBodyCount + "_" + i + "\" maxlength=\"12\" value=\"" + strNetAmountWithComma + "\"  type=\"text\" class=\"form-control fg2_inp2 tr_r notv\" name=\"txtAddDedCsv_" + intRowBodyCount + "_" + i + "\"/></td>");
                        }
                    }
                    else
                    {
                        sb.Append("<td class=\"tr_r\"><input onchange=\"return BlurNotNumberCsv(\'txtAddDedCsv_" + intRowBodyCount + "_" + i + "\');\" onkeydown=\"return isDecimalNumber(event,\'txtAddDedCsv_" + intRowBodyCount + "_" + i + "\');\" onkeypress=\"return isDecimalNumber(event,\'txtAddDedCsv_" + intRowBodyCount + "_" + i + "\');\"  id=\"txtAddDedCsv_" + intRowBodyCount + "_" + i + "\" maxlength=\"12\"   type=\"text\" class=\"form-control fg2_inp2 tr_r notv\" name=\"txtAddDedCsv_" + intRowBodyCount + "_" + i + "\"/></td>");
                    }
                }
               sb.Append("<td>");
               sb.Append("<button  onclick=\"return FuctionDeleCsv(" + intRowBodyCount + ");\" class=\"btn act_btn bn3 notv\" title=\"Delete\">");
               sb.Append("<i class=\"fa fa-trash\"></i>");;
               sb.Append("</button>");
               sb.Append("</div>");
               sb.Append("</td>");
               sb.Append("</tr>");
            }
        }
        sb.Append("</tbody>");
        sb.Append("</table>");
        return sb.ToString();
    }
    public class CsvRow : List<string>
    {
        public string LineText { get; set; }
    }  /// <summary>
    /// Class to read data from a CSV file
    /// </summary>
    public class CsvFileReader : StreamReader
    {
        public CsvFileReader(Stream stream)
            : base(stream)
        {
        }

        public CsvFileReader(string filename)
            : base(filename)
        {
        }

        /// <summary>
        /// Reads a row of data from a CSV file
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool ReadRow(CsvRow row)
        {
            row.LineText = ReadLine();
            if (String.IsNullOrEmpty(row.LineText))
                return false;

            int pos = 0;
            int rows = 0;

            while (pos < row.LineText.Length)
            {
                string value;

                // Special handling for quoted field
                if (row.LineText[pos] == '"')
                {
                    // Skip initial quote
                    pos++;

                    // Parse quoted value
                    int start = pos;
                    while (pos < row.LineText.Length)
                    {
                        // Test for quote character
                        if (row.LineText[pos] == '"')
                        {
                            // Found one
                            pos++;

                            // If two quotes together, keep one
                            // Otherwise, indicates end of value
                            if (pos >= row.LineText.Length || row.LineText[pos] != '"')
                            {
                                pos--;
                                break;
                            }
                        }
                        pos++;
                    }
                    value = row.LineText.Substring(start, pos - start);
                    value = value.Replace("\"\"", "\"");
                }
                else
                {
                    // Parse unquoted value
                    int start = pos;
                    while (pos < row.LineText.Length && row.LineText[pos] != ',')
                        pos++;
                    value = row.LineText.Substring(start, pos - start);
                }

                // Add field to list
                if (rows < row.Count)
                    row[rows] = value;
                else
                    row.Add(value);
                rows++;

                // Eat up to and including next comma
                while (pos < row.LineText.Length && row.LineText[pos] != ',')
                    pos++;
                if (pos < row.LineText.Length)
                    pos++;
            }
            // Delete any unused items
            while (row.Count > rows)
                row.RemoveAt(rows);

            // Return true if any columns read
            return (row.Count > 0);
        }
    }
    //converting string array list to json
    private string ConvertArrayToJson(List<string[]> strArrayList)
    {
        string strjson = JsonConvert.SerializeObject(strArrayList);
        return strjson;
    }

    //remove tags from array
    private List<string[]> ListRemoveTags(List<string[]> strArrayList)
    {
        var TagRemoveArray = new List<string[]>();

        for (int intRowBodyCount = 0; intRowBodyCount < strArrayList.Count; intRowBodyCount++)
        {
            string[] strProductList = new string[3];
            string strProductCode = strArrayList[intRowBodyCount][0].ToString().Replace("<", string.Empty);
            strProductCode = strProductCode.Replace(">", string.Empty);
            strProductList[0] = strProductCode;

            if (strArrayList[intRowBodyCount].GetLength(0) > 1)
            {
                string strProductName = strArrayList[intRowBodyCount][1].ToString().Replace("<", string.Empty);
                strProductName = strProductName.Replace(">", string.Empty);
                strProductList[1] = strProductName;
            }
            else
            {

            }
            if (strArrayList[intRowBodyCount].GetLength(0) > 2)
            {
                string strCostPrice = strArrayList[intRowBodyCount][2].ToString().Replace("<", string.Empty);
                strCostPrice = strCostPrice.Replace(">", string.Empty);
                strProductList[2] = strCostPrice;
            }
            else
            {

            }

            TagRemoveArray.Add(strProductList);
        }
        return TagRemoveArray;
    }
    public class clsTVData1
    {
        public string EMPCODE { get; set; }
        public string EMPADDDED { get; set; }
    }
    protected void btnCsvSave_Click(object sender, EventArgs e)
    {
            try
            {
                clsEntityManualAddDedEntry objentity = new clsEntityManualAddDedEntry();
                clsBusinessLayerManualAddDedEntry objBussiness = new clsBusinessLayerManualAddDedEntry();
                if (Session["CORPOFFICEID"] != null)
                {
                    objentity.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objentity.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                if (Session["USERID"] != null)
                {
                    objentity.User_Id = Convert.ToInt32(Session["USERID"].ToString());
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
                DataTable dt = objBussiness.ReadManualAddDed(objentity);

                if (HiddenFieldMasterDbId.Value != "")
                    objentity.MasterTabId = Convert.ToInt32(HiddenFieldMasterDbId.Value);
                objentity.MonthId = Convert.ToInt32(ddlMonth.Value);
                objentity.YearId = Convert.ToInt32(ddlYear.Value);
                objentity.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                List<clsEntityManualAddDedEntry> objAddDedList = new List<clsEntityManualAddDedEntry>();
                string jsonData = HiddenFieldCsvDataSave.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string i = h.Replace("}\",", "},");
                List<clsTVData1> objTVDataList5 = new List<clsTVData1>();
                objTVDataList5 = JsonConvert.DeserializeObject<List<clsTVData1>>(i);
                if (HiddenFieldCsvDataSave.Value != "" && HiddenFieldCsvDataSave.Value != null)
                {
                    foreach (clsTVData1 objclsTVData in objTVDataList5)
                    {
                        if (objclsTVData.EMPCODE != "" && objclsTVData.EMPADDDED != "")
                        {
                            string[] values = objclsTVData.EMPADDDED.Split('$');
                            for (int k = 0; k < values.Length; k++)
                            {
                                clsEntityManualAddDedEntry objEntityDtls = new clsEntityManualAddDedEntry();
                                string[] valSplit = values[k].Split('%');
                                objentity.cancelReason = objclsTVData.EMPCODE;
                                DataTable dtEmp = objBussiness.checkEmpcode(objentity);
                                DataRow[] result = dt.Select("PAYRL_CODE ='" + valSplit[0] + "'");
                                objEntityDtls.EmployeeId = Convert.ToInt32(dtEmp.Rows[0][0].ToString());
                                foreach (DataRow row in result)
                                {
                                    objEntityDtls.AddDedId = Convert.ToInt32(row["PAYRL_ID"].ToString());
                                }
                                objEntityDtls.Amount = Convert.ToDecimal(valSplit[1]);
                                objAddDedList.Add(objEntityDtls);
                            }
                        }
                    }
                }
                DataTable dtDup = objBussiness.readMonthYearData(objentity);
                if (dtDup.Rows.Count > 0 && dtDup.Rows[0]["PAYINF_CNCL_USR_ID"].ToString() != "")
                {
                    Response.Redirect("hcm_Manual_AddDed_Entry_List.aspx?InsUpd=AlCncl");
                }
                else if (dtDup.Rows.Count > 0 && dtDup.Rows[0]["PAYINF_CONF_USR_ID"].ToString() != "")
                {
                    Response.Redirect("hcm_Manual_AddDed_Entry_List.aspx?InsUpd=AlConf");
                }
                else
                {
                    objBussiness.insUpdEmpDtls(objentity, objAddDedList);
                    string id = objentity.MasterTabId.ToString();
                    if (HiddenFieldEditMode.Value == "1")
                    {
                        Response.Redirect("hcm_Manual_AddDed_Entry.aspx?InsUpd=Ins&Id=" + Request.QueryString["Id"].ToString(), false);
                    }
                    else
                    {
                        clsCommonLibrary objCommon = new clsCommonLibrary();
                        string strRandom = objCommon.Random_Number();
                        string strId = id;
                        int intIdLength = id.Length;
                        string stridLength = intIdLength.ToString("00");
                        string Idss = stridLength + strId + strRandom;
                        Response.Redirect("hcm_Manual_AddDed_Entry.aspx?InsUpd=Ins&Id=" + Idss, false);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("hcm_Manual_AddDed_Entry.aspx?InsUpd=Err&Mnt=" + ddlMonth.Value + "&Year=" + ddlYear.Value,false);
            }
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