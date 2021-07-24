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
using BL_Compzit.BusineesLayer_FMS;
using BL_Compzit.BusinessLayer_FMS;
using EL_Compzit.EntityLayer_FMS;
using System.Data;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Collections;
using System.Web.Script.Serialization;
using System.Web.Services;


public partial class FMS_FMS_Master_fms_Budget_fms_Budget_Review : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FRMWRK_ID"] != null && Session["FRMWRK_ID"].ToString() == "2")
        {
            aHome.HRef = "/Home/Compzit_Home/Compzit_Home_Finance.aspx";
        }
        else
        {
            aHome.HRef = " /Home/Compzit_LandingPage/Compzit_LandingPage.aspx";
        }
        ddlParticularType.Focus();
        if (!IsPostBack)
        {
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

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                            clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                             clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID                                                                      
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenFieldDecimalCnt.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
            }

            txtBudgtName.Disabled = true;
            ddlMode.Disabled = true;
            ddlYear.Disabled = true;


            if (Request.QueryString["Id"] != null)
            {
                lblEntry.Text = "Monthly Budgeting-Review";
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                btnCancel.Visible = true;
                HiddenFieldBudjetId.Value = strId;
                Update(strId);
            }

        }
        if (Request.QueryString["InsUpd"] != null)
        {
            string strInsUpd = Request.QueryString["InsUpd"].ToString();
            if (strInsUpd == "Ins")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessMsg", "SuccessMsg();", true);
            }
        }
    }
    public class clsLedgrData
    {
        public string LEDGRTABID { get; set; }
        public string LEDGRREASN { get; set; }
    }
    protected void bttnsave_Click(object sender, EventArgs e)
    {
        try
        {
            clsEntityLayerBudget objEntityLayerStock = new clsEntityLayerBudget();
            clsBusinessLayerBudget objBusinessLayerStock = new clsBusinessLayerBudget();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                objEntityLayerStock.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/ADMIN/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLayerStock.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/ADMIN/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityLayerStock.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/ADMIN/Default.aspx");
            }
            objEntityLayerStock.BudgtName = HiddenFieldCurrMnth.Value;
            objEntityLayerStock.BudgetId = Convert.ToInt32(HiddenFieldBudjetId.Value);
            objEntityLayerStock.ConfirmSts = Convert.ToInt32(ddlParticularType.Value);
            List<clsEntityBudgetLedgerDtl> objEntityJrnlLedgrList = new List<clsEntityBudgetLedgerDtl>();
            List<clsEntityBudgetCostCntrDtl> objEntityJrnlCostcentrList = new List<clsEntityBudgetCostCntrDtl>();

            string jsonData = HiddenFieldBudgtDataLedgr.Value;
            string c = jsonData.Replace("\"{", "\\{");
            string d = c.Replace("\\n", "\r\n");
            string g = d.Replace("\\", "");
            string h = g.Replace("}\"]", "}]");
            string i = h.Replace("}\",", "},");
            List<clsLedgrData> objTVDataList5 = new List<clsLedgrData>();
            objTVDataList5 = JsonConvert.DeserializeObject<List<clsLedgrData>>(i);
            if (HiddenFieldBudgtDataLedgr.Value != "" && HiddenFieldBudgtDataLedgr.Value != null)
            {
                foreach (clsLedgrData objclsTVData in objTVDataList5)
                {
                    if (ddlParticularType.Value == "0")
                    {
                        clsEntityBudgetLedgerDtl objEntityDtl = new clsEntityBudgetLedgerDtl();
                        objEntityDtl.BudgetLedgerId = Convert.ToInt32(objclsTVData.LEDGRTABID);
                        objEntityDtl.Reason = objclsTVData.LEDGRREASN;
                        objEntityJrnlLedgrList.Add(objEntityDtl);
                    }
                    else
                    {
                        clsEntityBudgetCostCntrDtl objEntityDtl = new clsEntityBudgetCostCntrDtl();
                        objEntityDtl.BudgetCostCntrId = Convert.ToInt32(objclsTVData.LEDGRTABID);
                        objEntityDtl.Reason = objclsTVData.LEDGRREASN;
                        objEntityDtl.BudgetId = objEntityLayerStock.BudgetId;
                        objEntityJrnlCostcentrList.Add(objEntityDtl);
                    }
                }
            }
            objEntityJrnlLedgrList.Reverse();
            objEntityJrnlCostcentrList.Reverse();
            DataTable dt = objBusinessLayerStock.ReadBdgtDtlsById(objEntityLayerStock);
            string subSts = "";
            if (ddlParticularType.Value == "0")
            {
                subSts = dt.Rows[0]["BUDGT_SUBMIT_STS"].ToString();
            }
            else
            {
                subSts = dt.Rows[0]["BUDGT_SUBMIT_STS_COST"].ToString();
            }
            if (subSts.Contains(HiddenFieldCurrMnth.Value) == false)
            {
                objBusinessLayerStock.SubmitMonthDtls(objEntityLayerStock, objEntityJrnlLedgrList, objEntityJrnlCostcentrList);
                Response.Redirect("fms_Budget_Review.aspx?Id=" + Request.QueryString["Id"].ToString() + "&InsUpd=Ins");
            }
            else
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "AlrdySub", "AlrdySub();", true);
            }
        }
        catch (Exception)
        {

        }
    }
    [WebMethod]
    public static string ShowMnthDtls(string BudgtId, string mnth, string FullMnth, string year, string mode, string orgID, string corptID, string FloatingValueMoney, string Type)
    {

        int precision = Convert.ToInt32(FloatingValueMoney);
        string format = String.Format("{{0:N{0}}}", precision);

        clsEntityLayerBudget objEntityLayerBudgt = new clsEntityLayerBudget();
        clsBusinessLayerBudget objBusinessLayerBudgt = new clsBusinessLayerBudget();
        clsCommonLibrary objCommon=new clsCommonLibrary();
        objEntityLayerBudgt.BudgetId = Convert.ToInt32(BudgtId);
        objEntityLayerBudgt.BudgtName = mnth;
        objEntityLayerBudgt.Cancel_Reason = FullMnth;
        if (mode == "Expense")
        {
            objEntityLayerBudgt.Mode = 1;
        }
        objEntityLayerBudgt.Year = Convert.ToInt32(year); 

        objEntityLayerBudgt.Org_Id = Convert.ToInt32(orgID);
        objEntityLayerBudgt.Corp_Id = Convert.ToInt32(corptID);
        StringBuilder sb = new StringBuilder();

        try
        {
            int FiinacialYear = 0;
            DataTable dtYear = objBusinessLayerBudgt.ReadBdgtYear(objEntityLayerBudgt);
            if (dtYear.Rows.Count > 0)
            {
                if (dtYear.Rows[0]["FINCYR_START_DT"].ToString() != "")
                {
                    DateTime startDate = objCommon.textToDateTime(dtYear.Rows[0]["FINCYR_START_DT"].ToString());
                    if (startDate.Month <= Convert.ToInt32(FullMnth))
                    {
                        FiinacialYear = startDate.Year;
                    }
                }
                if (dtYear.Rows[0]["FINCYR_END_DT"].ToString() != "")
                {
                    DateTime EndDate = objCommon.textToDateTime(dtYear.Rows[0]["FINCYR_END_DT"].ToString());
                    if (EndDate.Month >= Convert.ToInt32(FullMnth))
                    {
                        FiinacialYear = EndDate.Year;
                    }
                }

            }
            objEntityLayerBudgt.Year = FiinacialYear;
            if (Type == "0")
            {
         
                DataTable dtLedgrdDebDtl = objBusinessLayerBudgt.ReadBdgtLedgrDtlsByIdMnth(objEntityLayerBudgt);
                for (int i = 0; i < dtLedgrdDebDtl.Rows.Count; i++)
                {
                    decimal decDiff = 0, decBudAmnt = 0, decActAmnt = 0;
                    string strVarnce = "0";
                    if (dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_" + mnth].ToString() != "")
                    {
                        decBudAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_" + mnth].ToString());
                    }
                    if (dtLedgrdDebDtl.Rows[i]["ACT_AMNT"].ToString() != "")
                    {
                        decActAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[i]["ACT_AMNT"].ToString());
                    }
                    decDiff = decActAmnt - decBudAmnt;
                    if (decDiff > 0)
                    {

                        strVarnce = "+" + String.Format(format, decDiff);
                    }
                    else
                    {
                        strVarnce = String.Format(format, decDiff);
                    }


                    string valuestringBudAmnt = String.Format(format, decBudAmnt);
                    string valuestringActAmnt = String.Format(format, decActAmnt);

                    sb.Append("<tr id=\"SubRow" + i + "\">");
                    sb.Append("<td style=\"display:none;\">" + i + "</td>");
                    sb.Append("<td style=\"display:none;\">" + dtLedgrdDebDtl.Rows[i]["LD_BUDGT_ID"].ToString() + "</td>");
                    sb.Append("<td class=\" tr_l\" >" + dtLedgrdDebDtl.Rows[i]["LDGR_NAME"].ToString() + "</td>");
                    sb.Append("<td class=\" tr_r\" >" + valuestringBudAmnt + "</td>");
                    sb.Append("<td class=\" tr_r\" >" + valuestringActAmnt + "</td>");
                    sb.Append("<td class=\" tr_r\">" + strVarnce + "</td>");
                    sb.Append("<td >");
                    sb.Append("<textarea class=\"form-control\"  rows = \"2\" onchange=\"IncrmntConfrmCounter();\" onkeydown=\"textCounter(txtReason" + i + ",500)\" onkeyup=\"textCounter(txtReason" + i + ",500)\"  style=\"resize:none;\"  id=\"txtReason" + i + "\">" + dtLedgrdDebDtl.Rows[i]["LD_BUDGT_REAS_" + mnth].ToString() + " </textarea>");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                }
            }
            else
            {
                DataTable dtCostCntrDebDtl = objBusinessLayerBudgt.ReadBdgtCostCntrDtlsByIdMnth(objEntityLayerBudgt);

                DataView view = new DataView(dtCostCntrDebDtl);
                DataTable distinctValues = new DataTable();
                distinctValues = view.ToTable(true, "COSTCNTR_ID", "COSTCNTR_NAME", "ACT_AMNT");


                for (int j = 0; j < distinctValues.Rows.Count; j++)
                {

                    DataRow[] rowsFiltered = dtCostCntrDebDtl.Select("COSTCNTR_ID=" + distinctValues.Rows[j]["COSTCNTR_ID"].ToString());
                    string desc = rowsFiltered[0]["CST_BUDGT_RESN_" + mnth].ToString();
                    string amnt = dtCostCntrDebDtl.Compute("Sum(CST_BUDGT_AMT_" + mnth + ")", "COSTCNTR_ID=" + distinctValues.Rows[j]["COSTCNTR_ID"].ToString()).ToString();



                    decimal decDiff = 0, decBudAmnt = 0, decActAmnt = 0;
                    string strVarnce = "0";
                    if (amnt != "")
                    {
                        decBudAmnt = Convert.ToDecimal(amnt);
                    }
                    if (distinctValues.Rows[j]["ACT_AMNT"].ToString() != "")
                    {
                        decActAmnt = Convert.ToDecimal(distinctValues.Rows[j]["ACT_AMNT"].ToString());
                    }
                    decDiff = decActAmnt - decBudAmnt;
                    if (decDiff > 0)
                    {
                        strVarnce = "+" + String.Format(format, decDiff);
                    }
                    else
                    {
                        strVarnce = String.Format(format, decDiff);
                    }
                    string valuestringBudAmnt = String.Format(format, decBudAmnt);
                    string valuestringActAmnt = String.Format(format, decActAmnt);

                    sb.Append("<tr id=\"SubRow" + j.ToString() + "\">");
                    sb.Append("<td style=\"display:none;\">" + j.ToString() + "</td>");
                    sb.Append("<td style=\"display:none;\">" + distinctValues.Rows[j]["COSTCNTR_ID"].ToString() + "</td>");
                    sb.Append("<td class=\" tr_l\" >" + distinctValues.Rows[j]["COSTCNTR_NAME"].ToString() + "</td>");
                    sb.Append("<td  class=\" tr_r\">" + valuestringBudAmnt + "</td>");
                    sb.Append("<td class=\" tr_r\" >" + valuestringActAmnt + "</td>");
                    sb.Append("<td class=\" tr_r\" >" + strVarnce + "</td>");
                    sb.Append("<td >");
                    sb.Append("<textarea class=\"form-control\" rows = \"2\" onchange=\"IncrmntConfrmCounter();\"  onkeydown=\"textCounter(txtReason" + j.ToString() + ",500)\" onkeyup=\"textCounter(txtReason" + j.ToString() + ",500)\"  style=\"resize:none;\" id=\"txtReason" + j.ToString() + "\"  >" + desc + "</textarea>");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                }
                if (dtCostCntrDebDtl.Rows.Count == 0)
                {
                    sb.Append("<tr >");
                    sb.Append("<td id=\"tdNoData\" colspan=\"16\">No data available</td></tr>");
                }
            }
        }
        catch (Exception)
        {

        }
        return sb.ToString();
    }
    public void Update(string id)
    {
        try
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayer onjBusuness = new clsBusinessLayer();
            clsEntityLayerBudget objEntityLayerBudgt = new clsEntityLayerBudget();
            clsBusinessLayerBudget objBusinessLayerBudgt = new clsBusinessLayerBudget();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLayerBudgt.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/ADMIN/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityLayerBudgt.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/ADMIN/Default.aspx");
            }
            objEntityLayerBudgt.BudgetId = Convert.ToInt32(id);
            DataTable dt = objBusinessLayerBudgt.ReadBdgtDtlsById(objEntityLayerBudgt);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["BUDGT_MODE"].ToString() == "0")
                {
                    ddlMode.Value = "Income";
                }
                else
                {
                    ddlMode.Value = "Expense";
                }
                ddlYear.Value = dt.Rows[0]["FINCYR_DEFAULTNAME"].ToString();
                ddlMainCostCenter.Value = dt.Rows[0]["BUDGT_YEAR"].ToString();
                txtBudgtName.Value = dt.Rows[0]["BUDGT_NAME"].ToString();
                HiddenFieldBdgtsubmitSts.Value = dt.Rows[0]["BUDGT_SUBMIT_STS"].ToString();
                HiddenFieldBdgtsubmitStsCost.Value = dt.Rows[0]["BUDGT_SUBMIT_STS_COST"].ToString();
                objEntityLayerBudgt.Cancel_Reason =Convert.ToString(onjBusuness.LoadCurrentDate().Month);
                objEntityLayerBudgt.Year = Convert.ToInt32(dt.Rows[0]["BUDGT_YEAR"].ToString());

            }
            int FiinacialYear = 0;
            DataTable dtYear = objBusinessLayerBudgt.ReadBdgtYear(objEntityLayerBudgt);
            if (dtYear.Rows.Count > 0)
            {
                if (dtYear.Rows[0]["FINCYR_START_DT"].ToString() != "")
                {
                    DateTime startDate = objCommon.textToDateTime(dtYear.Rows[0]["FINCYR_START_DT"].ToString());
                    if (startDate.Month <= Convert.ToInt32(onjBusuness.LoadCurrentDate().Month))
                    {
                        FiinacialYear = startDate.Year;
                    }
                }
                if (dtYear.Rows[0]["FINCYR_END_DT"].ToString() != "")
                {
                    DateTime EndDate = objCommon.textToDateTime(dtYear.Rows[0]["FINCYR_END_DT"].ToString());
                    if (EndDate.Month >= Convert.ToInt32(onjBusuness.LoadCurrentDate().Month))
                    {
                        FiinacialYear = EndDate.Year;
                    }
                }

            }


            DateTime currMnt = onjBusuness.LoadCurrentDate();
            DateTime tarMnt = new DateTime();

            StringBuilder sb = new StringBuilder();
            sb.Append("<button id=\"defaultOpen\" class=\"tablinks active \" data-toggle=\"tab\" href=\"#tabMain\" role=\"tab\" aria-controls=\"home\"  aria-expanded=\"true\" onclick=\"return ShowDtls(event,'JAN','01');\">JANUARY</button>");
            tarMnt = objCommon.textToDateTime("01-02-" + FiinacialYear);
            //if (tarMnt < currMnt)
            //{
            sb.Append("<button class=\"tablinks \"  data-toggle=\"tab\" href=\"#tabMain\" role=\"tab\" aria-controls=\"home\" aria-expanded=\"false\" onclick=\"return ShowDtls(event,'FEB','02');\">FEBRUARY</button>");
           // }
            tarMnt = objCommon.textToDateTime("01-03-" + FiinacialYear);
          //  if (tarMnt < currMnt)
           // {
            sb.Append(" <button class=\"tablinks \" data-toggle=\"tab\" href=\"#tabMain\" role=\"tab\" aria-controls=\"home\" aria-expanded=\"false\" onclick=\"return ShowDtls(event,'MAR','03');\">MARCH</button>");
          //  }
            tarMnt = objCommon.textToDateTime("01-04-" + FiinacialYear);
           // if (tarMnt < currMnt)
           // {
            sb.Append("<button class=\"tablinks \" data-toggle=\"tab\" href=\"#tabMain\" role=\"tab\" aria-controls=\"home\" aria-expanded=\"false\" onclick=\"return ShowDtls(event,'APR','04');\">APRIL</button>");
          //  }
            tarMnt = objCommon.textToDateTime("01-05-" + FiinacialYear);
           // if (tarMnt < currMnt)
           // {
            sb.Append(" <button  class=\"tablinks \" data-toggle=\"tab\" href=\"#tabMain\" role=\"tab\" aria-controls=\"home\" aria-expanded=\"false\" onclick=\"return ShowDtls(event,'MAY','05');\">MAY</button>");
           // }
            tarMnt = objCommon.textToDateTime("01-06-" + FiinacialYear);
          //  if (tarMnt < currMnt)
          //  {
            sb.Append("<button class=\"tablinks \" data-toggle=\"tab\" href=\"tabMain\" role=\"tab\" aria-controls=\"home\" aria-expanded=\"false\" onclick=\"return ShowDtls(event,'JUN','06');\">JUNE</button>");
           // }
            tarMnt = objCommon.textToDateTime("01-07-" + FiinacialYear);
           // if (tarMnt < currMnt)
           // {
            sb.Append(" <button class=\"tablinks \" data-toggle=\"tab\" href=\"#tabMain\" role=\"tab\" aria-controls=\"home\" aria-expanded=\"false\" onclick=\"return ShowDtls(event,'JUL','07');\">JULY</button>");
           // }
            tarMnt = objCommon.textToDateTime("01-08-" + FiinacialYear);
           // if (tarMnt < currMnt)
           // {
            sb.Append(" <button  class=\"tablinks \" data-toggle=\"tab\" href=\"#tabMain\" role=\"tab\" aria-controls=\"home\"  aria-expanded=\"false\" onclick=\"return ShowDtls(event,'AUG','08');\">AUGUST</button>");
           // }
            tarMnt = objCommon.textToDateTime("01-09-" + FiinacialYear);
          //  if (tarMnt < currMnt)
           // {
            sb.Append("<button  class=\"tablinks \" data-toggle=\"tab\" href=\"#tabMain\" role=\"tab\" aria-controls=\"home\" aria-expanded=\"false\" onclick=\"return ShowDtls(event,'SEP','09');\">SEPTEMBER</button>");
           // }

            tarMnt = objCommon.textToDateTime("01-10-" + FiinacialYear);
            //if (tarMnt < currMnt)
           // {
            sb.Append("<button class=\"tablinks \"  data-toggle=\"tab\" href=\"#tabMain\" role=\"tab\" aria-controls=\"home\"  aria-expanded=\"false\" onclick=\"return ShowDtls(event,'OCT','10');\">OCTOBER</button>");
           // }
            tarMnt = objCommon.textToDateTime("01-11-" + FiinacialYear);
          //  if (tarMnt < currMnt)
          //  {
            sb.Append("  <button  class=\"tablinks \" data-toggle=\"tab\" href=\"#tabMain\" role=\"tab\" aria-controls=\"home\"  aria-expanded=\"false\" onclick=\"return ShowDtls(event,'NOV','11');\">NOVEMBER</button>");
           // }
            tarMnt = objCommon.textToDateTime("01-12-" + FiinacialYear);
           // if (tarMnt < currMnt)
           // {
            sb.Append(" <button   class=\"tablinks \" data-toggle=\"tab\" href=\"#tabMain\" role=\"tab\" aria-controls=\"home\"  aria-expanded=\"false\" onclick=\"return ShowDtls(event,'DEC','12');\">DECEMBER</button>");
           // }
            myTab.InnerHtml = sb.ToString();
        }
        catch (Exception)
        {

        }
    }

}