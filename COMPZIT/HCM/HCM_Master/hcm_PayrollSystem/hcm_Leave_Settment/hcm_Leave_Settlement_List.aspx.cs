using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using BL_Compzit;
using System.Text;
using System.Data;
using CL_Compzit;
using System.Web.Services;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;

public partial class HCM_HCM_Master_hcm_PayrollSystem_hcm_Leave_Settment_hcm_Leave_Settlement_List : System.Web.UI.Page
{
    static DateTime currDate = new DateTime();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hiddenConfrm.Value = "";

            Session["EDIT"] = null;
            Session["VIEW"] = null;

            LoadEmployee();

            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableConfirm = 0;

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
            currDate = objCommon.textToDateTime(strCurrentDate);
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Leave_Settlement);
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
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                }
            }

            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                divAdd.Visible = true;
            }
            else
            {
                divAdd.Visible = false;
            }


            clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
            clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();

            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLeavSettlmt.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                objEntityLeavSettlmt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                               };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);


            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();

                string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();

                hiddenCnclrsnMust.Value = CnclrsnMust;

                objEntityLeavSettlmt.EmployeeId = 0;
                objEntityLeavSettlmt.ConfrmStatus = 0;
                objEntityLeavSettlmt.CancelStatus = 0;

                DataTable dtLeavSettlmt = objBusinessLeavSettlmt.ReadLeaveSettlmt(objEntityLeavSettlmt);
                 
                string strhtm = ConvertDataTableToHTML(dtLeavSettlmt, intEnableModify, intEnableCancel, intEnableConfirm);
                divList.InnerHtml = strhtm;
            }

        }

    }

    public void LoadEmployee()
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        DataTable dtCountry = objBusinessLayer.ReadEmployeeDtl(objEntityCommon);

        ddlEmployee.Items.Clear();

        ddlEmployee.DataSource = dtCountry;

        ddlEmployee.DataTextField = "USR_NAME";
        ddlEmployee.DataValueField = "USR_ID";
        ddlEmployee.DataBind();

        ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");
    }


    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intEnableConfirm)
    {
        int cnt = 0;
        if (dt.Rows.Count > 0 && dt.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString() != "")
        {
          cnt= Convert.ToInt32(dt.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }

        string formatString = String.Concat("{0:F", cnt, "}");
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"table table-striped table-bordered\" width=\"100%\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr >";


        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th  style=\"width:20%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th  style=\"width:20%;text-align: left; word-wrap:break-word;\">EMPLOYEE NAME</th>";
            }

            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th  style=\"width:15%;text-align: left; word-wrap:break-word;\">JOIN/RESUME DATE</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th  style=\"width:15%;text-align: right; word-wrap:break-word;\">SETTLED DATE</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th  style=\"width:20%;text-align: right; word-wrap:break-word;\">SETTLEMENT AMOUNT</th>";
            }

        }
        if (cbxCnclStatus.Checked == false)
        {
            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active) || intEnableConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (hiddenConfrm.Value == "1" || hiddenPaidMode.Value == "1")
                {
                    strHtml += "<th style=\"width:5%; word-wrap:break-word;text-align: center;\">VIEW </th>";
                }
                else
                {
                    strHtml += "<th style=\"width:5%; word-wrap:break-word;text-align: center;\">EDIT </th>";
                }
            }
            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                strHtml += "<th style=\"width:5%; word-wrap:break-word;text-align: center;\">DELETE </th>";
            }
            if (hiddenPaidMode.Value == "1")
            {
                if (dt.Rows.Count > 0)
                {
                    strHtml += " <th class=\"hasinput\" style=\"width:5%;\"><button id=\"btnPaidAll\"  onclick=\"return ToPaidAll();\" style=\"width: 100%;background-color: #88bdf2;border: 1px solid darkblue;\" class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\">paid</button>";
                }
                else
                {
                    strHtml += " <th class=\"hasinput\" style=\"width:5%;\"><button id=\"btnPaidAll\" onclick=\"return false;\"  style=\"width: 100%;background-color: #88bdf2;border: 1px solid darkblue;\" class=\"btn btn-xs btn-default\"  data-original-title=\"Edit Row\">paid</button>";
                }
            }
        }
        else
        {
            strHtml += "<th style=\"width:5%; word-wrap:break-word;text-align: center;\">VIEW </th>";
        }
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            strHtml += "<tr>";

            //string strId = dt.Rows[intRowBodyCount][0].ToString();

            string Id = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string strId = stridLength + Id + strRandom;


            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + " <a   style=\"cursor:pointer;color: blue;\"  title=\"View\" onclick=\"return LeavSettmtViewId('" + strId + "');\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</a> </td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    // EMP-0043 START
                    if (ddlStatus.SelectedItem.Value == "1")
                    {
                        if (dt.Rows[intRowBodyCount]["EMPERDTL_PAYMENT_STS"].ToString() == "1")
                        {
                            strHtml += "<td style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + "<img title=\"Cash\"src='/Images/Icons/csh.png'></img></td>";
                        }
                        else
                        {
                            strHtml += "<td style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + "</td>";
                        }
                    }
                    else
                    {
                        if (dt.Rows[intRowBodyCount]["LEVSESTLMT_PREV_PAYMENT_TYPE"].ToString() == "1")
                        {
                            strHtml += "<td style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + "<img title=\"Cash\"src='/Images/Icons/csh.png'></img></td>";
                        }
                        else
                        {
                            strHtml += "<td style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + "</td>";
                        }
                    }
                    //end
                }
                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["LAST REJOIN DATE"].ToString() + "</td>";
                }

                else if (intColumnBodyCount == 4)
                {
                    strHtml += "<td style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["SETTLED DATE"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 5)
                {
                    clsEntityCommon objEntityCommon = new clsEntityCommon();
                    string strAmount = dt.Rows[intRowBodyCount]["SETTLEMENT AMOUNT"].ToString();             
                    string strNetAmountWithComma = objBusinessLayer.AddCommasForNumberSeperation(String.Format(formatString, Convert.ToDecimal(strAmount)).ToString(), objEntityCommon);                  
                    strHtml += "<td style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strNetAmountWithComma + "  " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                }

            }

            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active) || intEnableConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (cbxCnclStatus.Checked == false)
                {
                    if (dt.Rows[intRowBodyCount]["LEVSETLMT_CONFRMSTS"].ToString() == "1" || dt.Rows[intRowBodyCount]["LEVSETLMT_CONFRMSTS"].ToString() == "2" || dt.Rows[intRowBodyCount]["LEVSETLMT_CONFRMSTS"].ToString() == "3" || dt.Rows[intRowBodyCount]["LEVSETLMT_CONFRMSTS"].ToString() == "4")
                    {
                        strHtml += " <td style=\" width:5%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\">" + " <a  class=\"btn btn-xs btn-default\" title=\"View\"  onclick='return getdetails(this.href);' " +
                 " href=\"hcm_Leave_Settlement.aspx?ViewId=" + strId + "\"><i class=\"fa fa-eye\"></i></a>";
                    }
                    else
                    {
                        strHtml += " <td style=\" width:5%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\">" + " <a class=\"btn btn-xs btn-default\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                              " href=\"hcm_Leave_Settlement.aspx?Id=" + strId + "\"><i class=\"fa fa-pencil\"></i></a>";
                    }

                }
            }
            if (cbxCnclStatus.Checked == true)
            {
                strHtml += " <td style=\" width:5%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\">" + " <a  class=\"btn btn-xs btn-default\" title=\"View\"  onclick='return getdetails(this.href);' " +
                 " href=\"hcm_Leave_Settlement.aspx?ViewId=" + strId + "\"><i class=\"fa fa-eye\"></i></a>";
            }
            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (cbxCnclStatus.Checked == false)
                {
                    if (dt.Rows[intRowBodyCount]["LEVSETLMT_CONFRMSTS"].ToString() == "1" || dt.Rows[intRowBodyCount]["LEVSETLMT_CONFRMSTS"].ToString() == "2" || dt.Rows[intRowBodyCount]["LEVSETLMT_CONFRMSTS"].ToString() == "3" || dt.Rows[intRowBodyCount]["LEVSETLMT_CONFRMSTS"].ToString() == "4")
                    {
                        strHtml += " <td style=\" width:5%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button runat=\"server\" class=\"btn btn-xs btn-default\" data-original-title=\"Cancel Row\" onclick='return CancelNotPossible();' \"><i class=\"fa fa-trash\" \" style=\"opacity: 0.2; \"></i></button>";
                    }
                    else
                    {
                        strHtml += " <td style=\" width:5%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button title=\"Delete\" runat=\"server\" class=\"btn btn-xs btn-default\" data-original-title=\"Cancel Row\"  onclick=\"return CancelRow(" + Id + ");\"><i class=\"fa fa-trash\" ></i></button>";
                    }

                    if (hiddenPaidMode.Value == "1")
                    {
                        if (dt.Rows[intRowBodyCount]["LEVSETLMT_CONFRMSTS"].ToString() == "4")
                        {
                            strHtml += " <td style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button id=\"btnPaid" + intRowBodyCount + "\"  style=\"width: 100%;background-color: #dedada;\" class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\"   onclick=\"return ToPaid(" + Id + "," + intRowBodyCount + ");\">paid</button>  </td>";
                        }
                    }

                }

            }


            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (hiddenEdit.Value != "")
        {
            Session["EDIT"] = hiddenEdit.Value;
            Session["VIEW"] = null;
            //Session["READ"] = null;

        }
        else if (hiddenViewId.Value != "")
        {
            Session["EDIT"] = null;
            //Session["READ"] = null;
            Session["VIEW"] = hiddenViewId.Value;
        }
        else
        {
            Response.Redirect("/HCM/HCM_Master/hcm_PayrollSystem/hcm_Leave_Settment/hcm_Leave_Settlement_List.aspx");
        }
        
        Response.Redirect("/HCM/HCM_Master/hcm_PayrollSystem/hcm_Leave_Settment/hcm_Leave_Settlement.aspx");


    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableConfirm=0;

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Leave_Settlement);
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
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                {
                    intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                {
                    intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
            }
        }

        clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
        clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLeavSettlmt.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityLeavSettlmt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        if (cbxCnclStatus.Checked == true)
        {
            objEntityLeavSettlmt.CancelStatus = 1;
        }
        else
        {
            objEntityLeavSettlmt.CancelStatus = 0;
        }

        hiddenPaidMode.Value = "";
        if (ddlEmployee.SelectedItem.Text != "--SELECT EMPLOYEE--" && ddlEmployee.SelectedItem.Value !="0")
        {
            objEntityLeavSettlmt.EmployeeId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
        }
        if (ddlStatus.SelectedItem.Value == "1")
        {
            objEntityLeavSettlmt.ConfrmStatus = 0;//pending
            hiddenConfrm.Value = "0";
        }
        else if (ddlStatus.SelectedItem.Value == "2")
        {
            objEntityLeavSettlmt.ConfrmStatus = 1;//settled
            hiddenConfrm.Value = "1";
        }
        else if (ddlStatus.SelectedItem.Value == "3")
        {
            objEntityLeavSettlmt.ConfrmStatus = 3;//wps processed
            hiddenConfrm.Value = "1";
        }
        else if (ddlStatus.SelectedItem.Value == "4")
        {
            objEntityLeavSettlmt.ConfrmStatus = 2;//closed
            hiddenConfrm.Value = "1";
        }
        else if (ddlStatus.SelectedItem.Value == "5")
        {
            objEntityLeavSettlmt.ConfrmStatus = 4;
            hiddenPaidMode.Value = "1";
        }

        DataTable dtLeavSettlmt = objBusinessLeavSettlmt.ReadLeaveSettlmt(objEntityLeavSettlmt);
        string strhtm = ConvertDataTableToHTML(dtLeavSettlmt, intEnableModify, intEnableCancel, intEnableConfirm);
        divList.InnerHtml = strhtm;

    }

    [WebMethod]
    public static string CancelLeaveSettlmt(string strLevSettlmntId, string strUserId, string strCancelReason, string strCancelMust)
    {
        string strResult = "TRUE";
        clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
        clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();

        try
        {
            objEntityLeavSettlmt.LeaveSettlmtId = Convert.ToInt32(strLevSettlmntId);
            objEntityLeavSettlmt.UserId = Convert.ToInt32(strUserId);
            if (strCancelMust == "0")
            {
                clsCommonLibrary objCommon = new clsCommonLibrary();
                objEntityLeavSettlmt.CnclReason = objCommon.CancelReason();
            }
            else
            {
                objEntityLeavSettlmt.CnclReason = strCancelReason;
            }
            objEntityLeavSettlmt.Date = currDate;

            objBusinessLeavSettlmt.CancelLeavSettlmt(objEntityLeavSettlmt);

            Page objpage = new Page();
            objpage.Session["SUCCESS"] = "DELETE"; 

        }
        catch (Exception ex)
        {
            strResult = "FALSE";
            throw ex;
        }
        return strResult;
    }


    protected void btnView_Click(object sender, EventArgs e)
    {
        if (hiddenViewValue.Value != "")
        {
            Session["EDIT"] = null;
            Session["VIEW"] = null;
            Session["READ"] = hiddenViewValue.Value;
        }
    }


    //[WebMethod]
    //public static string EditClick(string strId)
    //{
    //    string success="true";
    //    Page objpage = new Page();
    //    objpage.Session["EDIT"] = strId;
    //    return success;

    //}

    [System.Web.Services.WebMethod]
    public static string UpdateSettledStatus(string Id)
    {
        string ret = "TRUE";

        clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
        clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();

        if (Id != "")
        {
            objEntityLeavSettlmt.LeaveSettlmtId = Convert.ToInt32(Id);
        }

        objBusinessLeavSettlmt.UpdateSettledStatus(objEntityLeavSettlmt);
        Page objpage = new Page();
        objpage.Session["SUCCESS"] = "PAID"; 
        return ret;
    }
    [System.Web.Services.WebMethod]
    public static string PaidAll_UpdateSettledStatus(string strOrgID, string strCorpID)
    {
        string ret = "TRUE";
        clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
        clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();

        if (strOrgID != "" && strCorpID != "")
        {
            objEntityLeavSettlmt.OrgId = Convert.ToInt32(strOrgID);
            objEntityLeavSettlmt.CorpId = Convert.ToInt32(strCorpID);
        }

        objBusinessLeavSettlmt.PaidAll_UpdateSettledStatus(objEntityLeavSettlmt);
        Page objpage = new Page();
        objpage.Session["SUCCESS"] = "PAID"; 
        return ret;
    }





}