using System;
using System.Collections.Generic;
using CL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Web.Script.Serialization;
using EL_Compzit;
using System.Data;
using System.Text;
using System.Web.Services;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using BL_Compzit.BusinessLayer_HCM;

public partial class HCM_HCM_Master_Employee_Performance_Mangmnt_Issue_Performance_Form_Emp_Issue_Prfrmnce_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        clsEntity_Issue_Performance objEntityIssue_Performance = new clsEntity_Issue_Performance();
        cls_Business_Issue_performance objBusiness_Issue_Performance = new cls_Business_Issue_performance();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, IntCorpId = 0;
        ddlDesignation.Focus();
        if (!IsPostBack)
        {
            Performnceload();
         //   int intCorpId = 0, intOrgId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityIssue_Performance.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                IntCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityIssue_Performance.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                objEntityIssue_Performance.UserId = Convert.ToInt32(Session["USERID"].ToString());
                intUserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = { clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, IntCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenCancelReasonMust.Value = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
            }

            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Issue_performance_form);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intEnableAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenEnableModify.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenEnableDelete.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                    }
                }
            }
            //EVM-0027
            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

            }
            else
            {
                divAdd.Visible = false;
            }
            //END
            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();

                if (strInsUpd == "StsCh")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessStatusChange", "SuccessStatusChange();", true);
                }
                else if (strInsUpd == "Cncl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                }
                else if (strInsUpd == "Confrm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                }
            }
        } 
       
       
    }
    public void Performnceload()
    {
        clsEntity_Issue_Performance objEntityIssue_Performance = new clsEntity_Issue_Performance();
        cls_Business_Issue_performance objBusiness_Issue_Performance = new cls_Business_Issue_performance();
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityIssue_Performance.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityIssue_Performance.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtDept = objBusiness_Issue_Performance.ReadPerformanceTemplate(objEntityIssue_Performance);

        ddlDesignation.Items.Clear();

        ddlDesignation.DataSource = dtDept;
        ddlDesignation.DataTextField = "PRFMNC_TMPLT_FORM";
        ddlDesignation.DataValueField = "PRFMNC_TMPLT_ID";
        ddlDesignation.DataBind();
        ddlDesignation.Items.Insert(0, "--SELECT TEMPLATE--");
    }
    [WebMethod]
    public static string ChangeSrvcStatus(string strIssueId, string strStatus, string strUserID)
    {
        clsEntity_Issue_Performance objEntityIssue_Performance = new clsEntity_Issue_Performance();
        cls_Business_Issue_performance objBusiness_Issue_Performance = new cls_Business_Issue_performance();
        string strRet = "success";

        if (strStatus == "1")
        {
            objEntityIssue_Performance.Status = 0;
        }
        else
        {
            objEntityIssue_Performance.Status = 1;
        }
        string strRandomMixedId = strIssueId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityIssue_Performance.IssueId = Convert.ToInt32(strId);
        objEntityIssue_Performance.UserId = Convert.ToInt32(strUserID);
        objBusiness_Issue_Performance.ChangeIssueStatus(objEntityIssue_Performance);
        return strRet;
    }
    [WebMethod]
    public static string CancelIssuePerformance(string strSrvcId, string reasonmust, string usrId, string cnclRsn)
    {
        clsEntity_Issue_Performance objEntityIssue_Performance = new clsEntity_Issue_Performance();
        cls_Business_Issue_performance objBusiness_Issue_Performance = new cls_Business_Issue_performance();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successcncl";
        string strRandomMixedId = strSrvcId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityIssue_Performance.IssueId = Convert.ToInt32(strId);
        objEntityIssue_Performance.UserId = Convert.ToInt32(usrId);

        if (reasonmust == "1")
        {
            objEntityIssue_Performance.CancelReason = cnclRsn;
        }

        else
        {
            objEntityIssue_Performance.CancelReason = objCommon.CancelReason();
        }

        try
        {
            objBusiness_Issue_Performance.CancelIsssuePrfrm(objEntityIssue_Performance);
            Page objpage = new Page();
            objpage.Session["SuccessMsg"] = "DELETE";
        }
        catch
        {
            strRets = "failed";
        }
        return strRets;
    }
    [WebMethod]
    public static string AnalyzeIssuePerformance(string IssueId, string orgid, string corpid)
    {
        clsEntity_Issue_Performance objEntityIssue_Performance = new clsEntity_Issue_Performance();
        cls_Business_Issue_performance objBusiness_Issue_Performance = new cls_Business_Issue_performance();
        HCM_HCM_Master_Employee_Performance_Mangmnt_Issue_Performance_Form_Emp_Issue_Prfrmnce_List obj = new HCM_HCM_Master_Employee_Performance_Mangmnt_Issue_Performance_Form_Emp_Issue_Prfrmnce_List();
        string Details = obj.ConvertDataTable(IssueId, orgid, corpid);


        return Details;
    }
    public string ConvertDataTable(string Id, string orgid, string corpid)
    {
        clsEntity_Issue_Performance objEntityIssue_Performance = new clsEntity_Issue_Performance();
        cls_Business_Issue_performance objBusiness_Issue_Performance = new cls_Business_Issue_performance();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandomMixedId = Id;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityIssue_Performance.IssueId = Convert.ToInt32(strId);
        objEntityIssue_Performance.OrgId = Convert.ToInt32(orgid);
        objEntityIssue_Performance.Corp_Id = Convert.ToInt32(corpid);
        string strRandom = objCommon.Random_Number();
        string strissueId = strId;
        int intEvLength = strissueId.Length;
        string strEvLength = intEvLength.ToString("00");
        string IssueId = strEvLength + strissueId + strRandom;
        StringBuilder sb = new StringBuilder();


        string strHtml = "<table id=\"ReportTableWelfare\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        strHtml += "<tbody>";
        DataTable dt = objBusiness_Issue_Performance.ReadAnalyzePerform(objEntityIssue_Performance);
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string strUId = dt.Rows[intRowBodyCount]["PRMNC_EMP_USR_ID"].ToString();
            int intIdLength = strUId.Length;
            string stridLength = intIdLength.ToString("00");
            string UId = stridLength + strUId + strRandom;

            strHtml += "<tr>";

            strHtml += "<td  id=\"tdName_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:100%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + " <a class=\"tooltip\"  style=\"cursor:pointer;color: blue;opacity: 1;position: sticky;\"onclick='return getdetails(this.href);' " + " href=\"../Performance_Evaluation_Analysis/Performance_Evaluation_Analysis.aspx?Uid=" + UId + "&IssueId=" + IssueId + "\">" + dt.Rows[intRowBodyCount]["USR_NAME"].ToString() + "</a></td>";
            strHtml += "<td id=\"tdUsrName_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >" + dt.Rows[intRowBodyCount]["PRMNC_EMP_USR_ID"].ToString() + "</td>";
            strHtml += "</tr>";


        }
       
        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
}