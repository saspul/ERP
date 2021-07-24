using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using BL_Compzit.BusineesLayer_FMS;
using EL_Compzit.EntityLayer_FMS;
using CL_Compzit;
using EL_Compzit;
using System.Data;
using System.Text;
using System.Web.Services;

public partial class FMS_FMS_Master_fms_Journal_fms_Journal_List : System.Web.UI.Page
{
    int intAccntCloseReopen = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
            txtDateTo.Value = strCurrentDate;
            DateTime now = new DateTime();
            now = objCommon.textToDateTime(strCurrentDate);
            now = now.AddDays(-6);
            txtDateFrom.Value = objCommon.ConvertDateTimeToStringWithoutTime(now);


            ddlLedger.Focus();
            LoadLedger();
            clsEntityJournal objEntityLayerStock = new clsEntityJournal();
            clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                objEntityLayerStock.User_Id = intUserId;
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityLayerStock.Corp_Id = intCorpId;
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityLayerStock.Org_Id = intOrgId;
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (CbxCnclStatus.Checked == true)
            {
                objEntityLayerStock.ConfirmSts = 1;
            }
            else
            {
                objEntityLayerStock.ConfirmSts = 0;
            }
           
            int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Journal);
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
                        HiddenRoleEdit.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenEnableCancl.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                    {
                        intAccntCloseReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                }
            }

            if (intAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

            }
            else
            {
                divAdd.Visible = false;
            }
            objEntityLayerStock.FromDate = objCommon.textToDateTime(txtDateFrom.Value);
            objEntityLayerStock.JournalDate = objCommon.textToDateTime(txtDateTo.Value);
            if (ddlLedger.SelectedItem.Value != "--SELECT LEDGER--")
                objEntityLayerStock.JournalId = Convert.ToInt32(ddlLedger.SelectedItem.Value);
            DataTable dtList = objBusinessLayerStock.ReadJournlList(objEntityLayerStock);
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                            clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                             clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID                                                                      
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenCancelReasonMust.Value = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                HiddenFieldDecimalCnt.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
            }
            divList.InnerHtml = ConvertDataTableToHTML(dtList, intUpdate, intEnableCancel);
        }
        if (Request.QueryString["InsUpd"] != null)
        {
            if (Request.QueryString["InsUpd"] == "cncl")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessClose", "SuccessClose();", true);
            }
            else if (Request.QueryString["InsUpd"] == "Error")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessError", "SuccessError();", true);
            }
            else if (Request.QueryString["InsUpd"] == "UpdCancl")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessDeleted", "SuccessDeleted();", true);
            }
            else if (Request.QueryString["InsUpd"] == "UpdConfm")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "CanclCnfMsg", "CanclCnfMsg();", true);
            }
            else if (Request.QueryString["InsUpd"] == "AcntClosed")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "AcntClosed", "AcntClosed();", true);
            }
            
        }
    }
    public int AccountCloseCheck(string strDate)
    {
        int sts = 0;
        clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
        clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityAccnt.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityAccnt.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityAccnt.FromDate = objCommon.textToDateTime(strDate);
        DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
        if (dtAccntCls.Rows.Count > 0)
        {
            sts = 1;
        }
        return sts;
    }
    public void LoadLedger()
    {
        clsEntityJournal objEntityLayerStock = new clsEntityJournal();
        clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLayerStock.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityLayerStock.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityLayerStock.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtdiv = objBusinessLayerStock.ReadLedgrListDdl(objEntityLayerStock);
        if (dtdiv.Rows.Count > 0)
        {
            ddlLedger.DataSource = dtdiv;
            ddlLedger.DataTextField = "LDGR_NAME";
            ddlLedger.DataValueField = "LDGR_ID";
            ddlLedger.DataBind();
        }
        ddlLedger.Items.Insert(0, "--SELECT LEDGER--");
    }
    public string ConvertDataTableToHTML(DataTable dt, int intUpdate, int intEnableCancel)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        String Status = "";
        int intOrgId = 0;
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"table table-striped table-bordered\" width=\"100%\" style=\"border-spacing: 1px;background-color: #e7e6e6;\">";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr >";



        strHtml += "<tr >";


        for (int intColumnHeaderCount = 0; intColumnHeaderCount < 5; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:40%;text-align:left;\">REFERENCE NUMBER";
                strHtml += "<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"form-control\" placeholder=\"REFERENCE NUMBER\" style=\"text-align:left;\" type=\"text\">";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:20%;text-align:center;\">DATE";
                strHtml += "<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"form-control\" placeholder=\"DATE\" style=\"text-align:center;\" type=\"text\">";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:30%;text-align:right;\">TOTAL AMOUNT";
                strHtml += "<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"form-control\" placeholder=\"TOTAL AMOUNT\" style=\"text-align:right;\" type=\"text\">";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 3)
            {
                if (intUpdate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    if (CbxCnclStatus.Checked == false)
                    {

                        strHtml += "<th class=\"hasinput\" style=\"width:1%;text-align: center;\"> EDIT";

                    }
                }
                if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    if (CbxCnclStatus.Checked == false)
                    {

                        strHtml += "<th class=\"hasinput\" style=\"width:1%;text-align: center;\"> DELETE";

                    }
                }

            }

            else if (intColumnHeaderCount == 4)
            {
                if (CbxCnclStatus.Checked == true)
                {
                    strHtml += "<th class=\"hasinput\" style=\"width:1%;text-align: center;\"> VIEW";
                }
            }
        }

        strHtml += "</th >";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            int AcntClsSts = AccountCloseCheck(dt.Rows[intRowBodyCount]["JURNL_DATE"].ToString());

            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

            string strCancTransaction = dt.Rows[intRowBodyCount][4].ToString();

            decimal value = 0;
            if (dt.Rows[intRowBodyCount]["JURNL_TOTAL_AMT"].ToString() != "")
            {
              value = Convert.ToDecimal(dt.Rows[intRowBodyCount]["JURNL_TOTAL_AMT"].ToString());
            }
            int precision = Convert.ToInt32(HiddenFieldDecimalCnt.Value);
            string format = String.Format("{{0:N{0}}}", precision);
            string valuestring = String.Format(format, value);
            valuestring = valuestring + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString();
            for (int intColumnBodyCount = 0; intColumnBodyCount < 5; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 0)
                {

                    strHtml += "<td class=\"tdT\" style=\" width:40%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["JURNL_REF"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 1)
                {

                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" > " + dt.Rows[intRowBodyCount]["JURNL_DATE"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {

                    strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: right;\" > " + valuestring + "</td>";
                }
                else if (intColumnBodyCount == 3)
                {

                    if (intUpdate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (CbxCnclStatus.Checked == false)
                        {

                            strHtml += " <td style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\">" + " <a style=\"opacity: 1;z-index: 10;\" class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                            " href=\"fms_Journal.aspx?Id=" + Id + "\"><i class=\"fa fa-pencil\"></i></a></td>";

                        }

                    }
                    if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (CbxCnclStatus.Checked == false)
                        {
                            if ((strCancTransaction == "0" && AcntClsSts == 1 && intAccntCloseReopen == 1) || (strCancTransaction == "0" && AcntClsSts == 0))
                                strHtml += "<td style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><a  href=\"#\" style=\"opacity: 1;margin-left: 1%;z-index: 10;\" class=\"tooltip \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a></td>";
                            else
                                strHtml += "<td style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><a  href=\"#\" style=\"opacity: .4;margin-left: 1%;z-index: 10;\" class=\"tooltip \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a></td>";

                        }

                    }

                }
                else if (intColumnBodyCount == 4)
                {

                    if (CbxCnclStatus.Checked == true)
                    {
                        strHtml += " <td style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\">" + " <a style=\"opacity: 1;\" class=\"tooltip\" title=\"VIEW\" onclick='return getdetails(this.href);' " +
                                     " href=\"fms_Journal.aspx?ViewId=" + Id + "\"><i class=\"fa fa-eye\"></i></a></td>";

                    }
                }

            }




            strHtml += "</tr>";
        }
        if (dt.Rows.Count == 0)
        {
            strHtml += "<td class=\"tdT\"colspan=\"6\" style=\" width:16%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No Data Available</td>";

        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }



    [WebMethod]
    public static string CancelMemoReason(string strmemotId, string reasonmust, string usrId, string cnclRsn)
    {

        clsEntityJournal objEntityLayerStock = new clsEntityJournal();
        clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successcncl";
        string strRandomMixedId = strmemotId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityLayerStock.JournalId = Convert.ToInt32(strId);
        objEntityLayerStock.User_Id = Convert.ToInt32(usrId);

        if (reasonmust == "1")
        {
            objEntityLayerStock.Cancel_Reason = cnclRsn;
        }

        else
        {
            objEntityLayerStock.Cancel_Reason = objCommon.CancelReason();
        }

        try
        {
            DataTable dt = objBusinessLayerStock.CheckJournlCnclSts(objEntityLayerStock);
            if (dt.Rows[0][0].ToString() == "" && dt.Rows[0][1].ToString()=="0")
            {
                objBusinessLayerStock.CancelJournal(objEntityLayerStock);
            }
            else if (dt.Rows[0][0].ToString() != "")
            {
                strRets = "UpdCancl";
            }
            else
            {
                strRets = "CnfCancl";
            }
        }
        catch
        {
            strRets = "failed";
        }
        return strRets;
    }


    protected void btnCnclSearch_Click(object sender, EventArgs e)
    {
        clsEntityJournal objEntitySupplier = new clsEntityJournal();
        clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
            objEntitySupplier.User_Id = intUserId;
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntitySupplier.Corp_Id = intCorpId;
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntitySupplier.Org_Id = intOrgId;
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (CbxCnclStatus.Checked == true)
        {
            objEntitySupplier.ConfirmSts = 1;
        }
        else
        {
            objEntitySupplier.ConfirmSts = 0;
        }
        objEntitySupplier.FromDate = objCommon.textToDateTime(txtDateFrom.Value);
        objEntitySupplier.JournalDate = objCommon.textToDateTime(txtDateTo.Value);
        if (ddlLedger.SelectedItem.Value != "--SELECT LEDGER--")
        objEntitySupplier.JournalId = Convert.ToInt32(ddlLedger.SelectedItem.Value);
        DataTable dtList = objBusinessLayerStock.ReadJournlList(objEntitySupplier);

        //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Journal);
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
                    //HiddenRoleConf.Value = "1";
                }
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                {
                    intUpdate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    HiddenRoleEdit.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active); ;
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                {
                    intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    hiddenEnableCancl.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                }


            }
        }

        if (intAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {

        }
        else
        {
            divAdd.Visible = false;
        }


        divList.InnerHtml = ConvertDataTableToHTML(dtList, intUpdate, intEnableCancel);

    }
}