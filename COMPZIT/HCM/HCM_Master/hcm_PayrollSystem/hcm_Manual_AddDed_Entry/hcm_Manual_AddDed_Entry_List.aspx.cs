using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using CL_Compzit;
using System.Data;
using System.Text;
using System.Web.Services;
using System.Globalization;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Ionic.Zip;
using System.IO;


public partial class HCM_HCM_Master_hcm_PayrollSystem_hcm_Manual_AddDed_Entry_hcm_Manual_AddDed_Entry_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ddlMonth.Focus();
        if (!IsPostBack)
        {
            BindDdlMonths();
            BindDdlYears();
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
            int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0,intEnableReopen = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.MANUAL_ADD_DED_ENTRY);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();
                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intUpdate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenFieldUpdRole.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenFieldCnclRole.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenFieldConfRole.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intEnableReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenFieldReopRole.Value = "1";
                    }
                }
            }
            if (intAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
            }
            else
            {
                myBtn.Visible = false;
            }
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = { clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenCancelReasonMust.Value = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
            }
            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Cncl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                }
                else if (strInsUpd == "Error")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ErrorCancelation", "ErrorCancelation();", true);
                }
                else if (strInsUpd == "Conf")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                }
                else if (strInsUpd == "Reop")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReopen", "SuccessReopen();", true);
                }
                else if (strInsUpd == "AlCncl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AlreadyCancelMsg", "AlreadyCancelMsg();", true);
                }
                else if (strInsUpd == "AlConf")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AlConf", "AlConf();", true);
                }
                else if (strInsUpd == "AlReop")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AlReop", "AlReop();", true);
                }
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpd", "SuccessUpd();", true);
                }
                else if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessIns", "SuccessIns();", true);
                }
            }
        }
    }
    public void BindDdlMonths()
    {
        string strMonth = DateTime.Today.Month.ToString();
        ddlMonth.Items.Clear();
        var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
        for (int i = 0; i < months.Length - 1; i++)
        {
            ddlMonth.Items.Add(new System.Web.UI.WebControls.ListItem(months[i], (i + 1).ToString()));           

        }
        ddlMonth.Items.Insert(0, "-Select-");
    }
    public void BindDdlYears()
    {
        ddlYear.Items.Clear();
        string strYear = DateTime.Today.Year.ToString();
        var currentYear = DateTime.Today.Year+1;
        for (int i = 0; i <20; i++)
        {
            ddlYear.Items.Add((currentYear - i).ToString());
        }
        ddlYear.Items.Insert(0, "-Select-");
    }
    public static string[] ConvertDataTableToHTML(DataTable dt, clsEntityManualAddDedEntry objEntity, int intUpdate, int intEnableCancel, int intConfirm, int intEnableReopen)
    {
        string[] strReturn = new string[2];
        StringBuilder sbHead = new StringBuilder();
        sbHead.Append("<th id=\"tdColumnHead_1\" onclick=\"SetOrderByValue(1)\" class=\"sorting col-md-2 tr_l\" style=\"word-wrap:break-word;\">MONTH<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbHead.Append("<th id=\"tdColumnHead_2\" onclick=\"SetOrderByValue(2)\" class=\"sorting col-md-1 tr_c\" style=\"word-wrap:break-word;\">YEAR<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbHead.Append("<th id=\"tdColumnHead_3\" onclick=\"SetOrderByValue(3)\" class=\"sorting col-md-2 tr_l\" style=\"word-wrap:break-word;\">NO. OF EMPLOYEES<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbHead.Append("<th id=\"tdColumnHead_4\" onclick=\"SetOrderByValue(4)\" class=\"sorting col-md-1 tr_c\" style=\"word-wrap:break-word;\">INSERT DATE<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbHead.Append("<th id=\"tdColumnHead_5\" onclick=\"SetOrderByValue(5)\" class=\"sorting col-md-1 tr_c\" style=\"word-wrap:break-word;\">INSERT TIME<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbHead.Append("<th id=\"tdColumnHead_6\" onclick=\"SetOrderByValue(6)\" class=\"sorting col-md-1 tr_c\" style=\"word-wrap:break-word;\">STATUS<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbHead.Append("<th class=\"col-md-2\" style=\"word-wrap:break-word;\">ACTIONS</th>");


        int intSts = objEntity.StatusId;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        int COUNT = 0;
        string strHtml = "";
        if (dt.Rows.Count > 0)
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                string strId = dt.Rows[intRowBodyCount]["PAYINF_ID"].ToString();
                int intIdLength = dt.Rows[intRowBodyCount]["PAYINF_ID"].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                COUNT++;

                int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["NUM_PROCESSED"].ToString());
                strHtml += "<tr>";

                strHtml += "<td style=\"text-align: left;\">" + dt.Rows[intRowBodyCount]["PAYINF_MONTH1"].ToString() + "</td>";
                strHtml += "<td  >" + dt.Rows[intRowBodyCount]["PAYINF_YEAR"].ToString() + "</td>";
                strHtml += "<td style=\"text-align: left;\" >" + dt.Rows[intRowBodyCount]["NUM_PERSONS"].ToString() + "</td>";
                strHtml += "<td  >" + dt.Rows[intRowBodyCount]["PAYINF_INS_DATE1"].ToString() + "</td>";
                strHtml += "<td  >" + dt.Rows[intRowBodyCount]["PAYINF_INS_TIME1"].ToString() + "</td>";

                if (dt.Rows[intRowBodyCount]["STATUS"].ToString() == "0")
                    strHtml += "<td ><button class=\"btn tab_but1 butn2\" onclick=\"return false;\" style=\"cursor: initial;\">Pending</button></td>";
                if (dt.Rows[intRowBodyCount]["STATUS"].ToString() == "1")
                    strHtml += "<td ><button class=\"btn tab_but1 butn1\" onclick=\"return false;\" style=\"cursor: initial;\">Confirmed</button></td>";
                if (dt.Rows[intRowBodyCount]["STATUS"].ToString() == "2")
                    strHtml += "<td ><button class=\"btn tab_but1 butn3\" onclick=\"return false;\" style=\"cursor: initial;\">Reopened</button></td>";

                int TableSts = Convert.ToInt32(dt.Rows[intRowBodyCount]["STATUS"].ToString());


                strHtml += "<td><div class=\"btn_stl1\">";
                if (objEntity.CancelStatus == 1)
                {
                    strHtml += "<a style=\"opacity: 1;\" class=\"btn act_btn bn4\" title=\"VIEW\" onclick='return getdetails(this.href);' " +
                                 " href=\"hcm_Manual_AddDed_Entry.aspx?Id=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";
                }
                else
                {
                    if (TableSts != 1)
                    {
                        if (intUpdate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            strHtml += "<a style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn1\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                            " href=\"hcm_Manual_AddDed_Entry.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";
                        }
                        if (intConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            strHtml += "<a style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn2\" title=\"Confirm\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\"></i></a>";
                        }
                        if (intEnableReopen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            strHtml += " <a disabled href=\"javascript:;\" class=\"btn act_btn bn2\" title=\"REOPEN\" " + " ><i class=\"fa fa-unlock\"></i></a>";
                        }
                        if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            if (intCancTransaction == 0)
                                strHtml += "<a  href=\"#\" style=\"opacity: 1;\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" ></i></a>";
                            else
                                strHtml += "<a  href=\"#\" style=\"opacity: .4;\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                        }
                    }
                    else
                    {
                        strHtml += "<a style=\"opacity: 1;\" class=\"btn act_btn bn4\" title=\"VIEW\" onclick='return getdetails(this.href);' " +
                                " href=\"hcm_Manual_AddDed_Entry.aspx?Id=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";

                        if (intConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            strHtml += "<a   class=\"btn act_btn bn2\"  disabled  href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";
                        }
                        if (intEnableReopen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            strHtml += "  <a href=\"javascript:;\" class=\"btn act_btn bn2\" title=\"REOPEN\"  onclick=\"return ReOpen('" + Id + "');\" ><i class=\"fa fa-unlock\"></i></a>";
                        }
                        if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            if (intCancTransaction == 0)
                                strHtml += "<a  href=\"#\" style=\"opacity: 1;\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" ></i></a>";
                            else
                                strHtml += "<a  href=\"#\" style=\"opacity: .4;\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                        }
                    }
                }
                strHtml += "</div></td>";
                strHtml += "</tr>";
            }
        }
        else
        {
            strHtml +="<td class=\"tr_c\" colspan=\"7\">No data available in table</td>";
        }
        sb.Append(strHtml);
        strReturn[0] = sbHead.ToString();
        strReturn[1] = sb.ToString();
        return strReturn;
    }
    [WebMethod]
    public static string ReOpenConfByID(string orgID, string corptID, string userID, string MasterDbId, string Mode, string reasonmust, string cnclRsn)
    {
        string sts ="success";
        try
        {
            string strRandomMixedId = MasterDbId;
            string id = strRandomMixedId;
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityManualAddDedEntry objentity = new clsEntityManualAddDedEntry();
            clsBusinessLayerManualAddDedEntry objBussiness = new clsBusinessLayerManualAddDedEntry();
            objentity.CorpOffice_Id = Convert.ToInt32(corptID);
            objentity.Organisation_Id = Convert.ToInt32(orgID);
            objentity.User_Id = Convert.ToInt32(userID);
            objentity.MasterTabId = Convert.ToInt32(strId);
            objentity.User_Id = Convert.ToInt32(userID);
            objentity.ConfStatusId = Convert.ToInt32(Mode);
            if (Mode == "0")
            {
                if (reasonmust == "1")
                {
                    objentity.cancelReason = cnclRsn;
                }
                else
                {
                    objentity.cancelReason = objCommon.CancelReason();
                }

            }
            DataTable dtDup = objBussiness.ReadDataById(objentity);
            if (dtDup.Rows.Count > 0 && dtDup.Rows[0]["PAYINF_CNCL_USR_ID"].ToString() != "")
            {
                sts = "AlCncl";
            }
            else if (dtDup.Rows.Count > 0 && Mode != "3" && dtDup.Rows[0]["PAYINF_CONF_USR_ID"].ToString() != "")
            {
                sts = "AlConf";
            }
            else if (dtDup.Rows.Count > 0 && Mode == "3" && dtDup.Rows[0]["PAYINF_REOPN_USR_ID"].ToString() != "")
            {
                sts = "AlReop";
            }
            else
            {
                objBussiness.ReopConfDele(objentity);
                if (Mode == "0")
                {
                    sts = "Cncl";
                }
                else if (Mode == "1")
                {
                    sts = "Conf";
                }
                else
                {
                    sts = "Reop";
                }
            }
        }
        catch (Exception ex)
        {
            sts = "Error";
        }
        return sts;
    }
    //------------------------------------------Pagination------------------------------------------------

    [WebMethod]
    public static string[] GetData(string OrgId, string CorpId, string ddlStatus, string CancelStatus,string Year,string Month,string EnableModify, string EnableCancel,string EnableConfirm,string EnableReopen, string PageNumber, string PageMaxSize, string strCommonSearchTerm, string OrderColumn, string OrderMethod, string strInputColumnSearch)
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityManualAddDedEntry objEntity = new clsEntityManualAddDedEntry();
        clsBusinessLayerManualAddDedEntry objBussiness = new clsBusinessLayerManualAddDedEntry();
        string[] strResults = new string[3];
        if (OrgId != null && OrgId != "")
        {
            objEntity.Organisation_Id = Convert.ToInt32(OrgId);
        }
        if (CorpId != null && CorpId != "")
        {
            objEntity.CorpOffice_Id = Convert.ToInt32(CorpId);
        }
        objEntity.StatusId = Convert.ToInt32(ddlStatus);
        objEntity.CancelStatus = Convert.ToInt32(CancelStatus);
        if (Month != "-Select-")
            objEntity.MonthId = Convert.ToInt32(Month);
        if (Year != "-Select-")
            objEntity.YearId = Convert.ToInt32(Year);

        objEntity.PageNumber = Convert.ToInt32(PageNumber);
        objEntity.PageMaxSize = Convert.ToInt32(PageMaxSize);
        objEntity.OrderMethod = Convert.ToInt32(OrderMethod);
        objEntity.OrderColumn = Convert.ToInt32(OrderColumn);
        objEntity.CommonSearchTerm = strCommonSearchTerm;

        var values = Enum.GetValues(typeof(SearchInputColumns));
        int intSearchColumnCount = values.Length;

        string[] strSearchInputs = new string[intSearchColumnCount];
        //— ‡
        if (strInputColumnSearch != "")
        {
            string[] InputColumnSearchList = strInputColumnSearch.Split('—');
            foreach (var InputColumnSearch in InputColumnSearchList)
            {
                string[] strColumnSrch = InputColumnSearch.Split('‡');
                int intColumnNo = Convert.ToInt32(strColumnSrch[0]);
                string strSearchString = strColumnSrch[1];

                if (intColumnNo <= intSearchColumnCount)
                {
                    strSearchInputs[intColumnNo] = strSearchString;
                }
            }
        }

        objEntity.searcMonth = strSearchInputs[Convert.ToInt32(SearchInputColumns.MONTH)];
        objEntity.SearchYear = strSearchInputs[Convert.ToInt32(SearchInputColumns.YEAR)];
        objEntity.SearchNumEmp = strSearchInputs[Convert.ToInt32(SearchInputColumns.NUMEMP)];
        objEntity.SearchInsDate = strSearchInputs[Convert.ToInt32(SearchInputColumns.INSDATE)];
        objEntity.SearchInsTime = strSearchInputs[Convert.ToInt32(SearchInputColumns.INSTIME)];
        objEntity.SearchStatus = strSearchInputs[Convert.ToInt32(SearchInputColumns.STATUS)];
        //ReadList
        DataTable dt = objBussiness.ReadList(objEntity);

        int intEnableUpdate = Convert.ToInt32(EnableModify);
        int intEnableCancel = Convert.ToInt32(EnableCancel);
        int intEnableConfirm = Convert.ToInt32(EnableConfirm);
        int intEnableReopen = Convert.ToInt32(EnableReopen);


        string[] strTableContents = new string[2];
        strTableContents = ConvertDataTableToHTML(dt, objEntity, intEnableUpdate, intEnableCancel, intEnableConfirm, intEnableReopen);
        strResults[0] = strTableContents[0];
        strResults[1] = strTableContents[1];
        if (dt.Rows.Count > 0)
        {
            int intTotalItems = Convert.ToInt32(dt.Rows[0]["CNT"].ToString());
            int intCurrentRowCount = dt.Rows.Count;
            //Pagination
            strResults[2] = objBusinessLayer.GenereatePagination(intTotalItems, objEntity.PageNumber, objEntity.PageMaxSize, intCurrentRowCount);
        }

        return strResults;
    }

    [WebMethod]
    public static string[] LoadStaticDatafordt()//Filters
    {
        StringBuilder html = new StringBuilder();
        StringBuilder sbSearchInputColumns = new StringBuilder();

        string[] strResults = new string[3];
        html.Append("<div>");

        html.Append("<div class=\"col-md-2\">");//length
        html.Append("<p><span class=\"tbl_srt1\">Show</span> <select class=\"form-control tbl_srt\" onchange=\"getdata(1);\" id=\"ddl_page_size\">");
        html.Append("<option value=\"10\">10</option><option value=\"25\">25</option><option value=\"50\">50</option><option value=\"100\">100</option></select> entries");
        html.Append("</p></div>");
        //page length ends
        //common filter
        html.Append("<div class=\"col-md-2 pull-right\">");
        html.Append("<input  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"SettypingTimer();\" class=\"form-control tbl_ser_n\" id=\"txtCommonSearch_dt\"  type=\"search\" placeholder=\" Search \" aria-controls=\"example\">");
        html.Append("</div>");
        //common filter ends
        html.Append("</div>");
        strResults[0] = html.ToString();

        //custom search fields
        var values = Enum.GetValues(typeof(SearchInputColumns));
        int intSearchColumnCount = values.Length;

        foreach (var item in values)
        {
            // use item number to customize names using if 
            if (Convert.ToInt32(item).ToString() == "0")
            {
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"MONTH\" placeholder=\"Month\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "1")
            {
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in tr_c\" type=\"text\" title=\"YEAR\" placeholder=\"Year\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "2")
            {
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"NO. OF EMPLOYEES\" placeholder=\"No. of Employees\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "3")
            {
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in tr_c\" type=\"text\" title=\"INSERT DATE\" placeholder=\"Insert Date\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "4")
            {
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in tr_c\" type=\"text\" title=\"INSERT TIME\" placeholder=\"Insert Time\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "5")
            {
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in tr_c\" type=\"text\" title=\"STATUS\" placeholder=\"Status\"></th>");
            }
        }
        //this is to adjust the non search  fields
        sbSearchInputColumns.Append("<td id=\"thPagingTable_thAdjuster\"></td>");
        strResults[1] = sbSearchInputColumns.ToString();
        strResults[2] = intSearchColumnCount.ToString();
        return strResults;
    }

    public enum SearchInputColumns
    {
        //Must be sequential 
        MONTH = 0,
        YEAR = 1,
        NUMEMP = 2,
        INSDATE = 3,
        INSTIME = 4,
        STATUS = 5,
    }

    #region PDF PRINT
    protected void btnPrintList_Click(object sender, EventArgs e)
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
        objentity.StatusId = Convert.ToInt32(ddlStatus.Value);
        int intCancelStatus = 0;
        if (cbxCnclStatus.Checked == true)
        {
            intCancelStatus = 1;
        }
        objentity.CancelStatus = intCancelStatus;
        
        DataTable dtPrintList = objBussiness.ReadPrintList(objentity);

        Generate_Manual_AddDed_List_PDF(dtPrintList, objentity);
    }
    public void Generate_Manual_AddDed_List_PDF(DataTable dt, clsEntityManualAddDedEntry objentity)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        objEntityCommon.CorporateID = objentity.CorpOffice_Id;
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.MANUAL_ADD_DED_LIST_ATTACHMENT);
        string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
      
        if (dt.Rows.Count > 0)
        {
            Document document = new Document(PageSize.LETTER, 35f, 25f, 15f, 60f);
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                string strImageName = "ManualAddDedList_" + strNextId + ".pdf";
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.MANUAL_ADD_DED_LIST_PDF);

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
                    PdfPTable tableLayout = new PdfPTable(6);
                    float[] headersBody = { 20, 15, 20, 15, 15, 15 };
                    tableLayout.SetWidths(headersBody);
                    tableLayout.WidthPercentage = 100;

                    float pos9 = writer.GetVerticalPosition(false);
                    tableLayout.AddCell(new PdfPCell(new Phrase("MONTH", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase("YEAR", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase("INSERT DATE", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase("INSERT TIME", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase("EMPLOYEES #", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                    tableLayout.AddCell(new PdfPCell(new Phrase("STATUS", FontFactory.GetFont("Times New Roman", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 2, BorderColor = BaseColor.GRAY });
                   
                    for (int intRowCount = 0; intRowCount < dt.Rows.Count; intRowCount++)
                    {
                        tableLayout.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowCount]["PAYINF_MONTH"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                        tableLayout.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowCount]["PAYINF_YEAR"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                        tableLayout.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowCount]["PAYINF_INS_DATE"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                        tableLayout.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowCount]["PAYINF_INS_TIME"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                        tableLayout.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowCount]["NUM_PERSONS"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = BaseColor.GRAY });
                        tableLayout.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowCount]["STATUS"].ToString(), FontFactory.GetFont("Times New Roman", 8, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = BaseColor.GRAY });
                        int TableTotalcount = tableLayout.Size;                      
                    }
                    document.Add(tableLayout);

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

                    if (pos1 > 80)
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
                Response.AddHeader("Content-Disposition", "attachment; filename=ManualAddDedList_" + strNextId + ".pdf");
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
            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

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