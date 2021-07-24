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

public partial class FMS_FMS_Master_fms_Budget_fms_Budget_List : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            ddlMode.Value = "2";
            ddlMode.Focus();
            clsEntityLayerBudget objEntityLayerStock = new clsEntityLayerBudget();
            clsBusinessLayerBudget objBusinessLayerStock = new clsBusinessLayerBudget();
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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Budget);
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
                }
            }

            if (intAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

            }
            else
            {
                divAdd.Visible = false;
            }
            objEntityLayerStock.Mode = Convert.ToInt32(ddlMode.Value);
            DataTable dtList = objBusinessLayerStock.ReadBudgetList(objEntityLayerStock);
            divList.InnerHtml = ConvertDataTableToHTML(dtList, intUpdate, intEnableCancel);

            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                       };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenCancelReasonMust.Value = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
            }

        }
        if (Request.QueryString["InsUpd"] != null)
        {
            if (Request.QueryString["InsUpd"] == "Ins")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessMsg", "SuccessMsg();", true);
            }
            else if (Request.QueryString["InsUpd"] == "Upd")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdMsg", "SuccessUpdMsg();", true);
            }
            else if (Request.QueryString["InsUpd"] == "cncl")
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
        }
    }

    public string ConvertDataTableToHTML(DataTable dt, int intUpdate, int intEnableCancel)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusuness = new clsBusinessLayer();

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
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"display table-bordered\" width=\"100%\" >";
        //add header row
        strHtml += "<thead class=\"thead1\">";
        strHtml += "<tr id=\"SearchRow\" >";



        strHtml += "<tr >";


        for (int intColumnHeaderCount = 0; intColumnHeaderCount < 5; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"col-md-4 tr_l hasinput\" >BUDGET <i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br>";
                strHtml += "<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in \"  placeholder=\"BUDGET\"  type=\"text\">";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"col-md-2 tr_c \" >YEAR <i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>";
                strHtml += "<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_c\" placeholder=\"YEAR\"  type=\"text\">";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"col-md-2 tr_c \" >MODE  <i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>";
                strHtml += "<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_c\" placeholder=\"MODE\" type=\"text\">";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 3)
            {

                strHtml += "<th class=\"col-md-2\" > Actions";
            }

        }

        strHtml += "</th >";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

            string strCancTransaction = dt.Rows[intRowBodyCount][4].ToString();

            for (int intColumnBodyCount = 0; intColumnBodyCount < 5; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 0)
                {

                    strHtml += "<td class=\"tr_l\" >" + dt.Rows[intRowBodyCount]["BUDGT_NAME"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 1)
                {

                    strHtml += "<td  > " + dt.Rows[intRowBodyCount]["BUDGT_YEAR"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {

                    strHtml += "<td > " + dt.Rows[intRowBodyCount]["MODE"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 3)
                {

                    strHtml += "<td class=\"td1\"><div class=\"btn_stl1\">";
                    if (intUpdate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (CbxCnclStatus.Checked == false)
                        {
                            if (strCancTransaction == "0")
                            {
                                strHtml += "  <a style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn1\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                                " href=\"fms_Budget.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";
                            }
                            else
                            {
                                strHtml += "  <a style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn4\" title=\"View\" onclick='return getdetails(this.href);' " +
                                                                               " href=\"fms_Budget.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";
                            }
                        }

                    }
                    if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (CbxCnclStatus.Checked == false)
                        {
                            if (strCancTransaction == "0")
                                strHtml += "<a  href=\"#\" style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                            else
                                strHtml += "<a  href=\"#\" disabled=\"true\"  class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";

                        }

                    }
                    if (CbxCnclStatus.Checked == false)
                    {

                        DateTime currMnt = objBusuness.LoadCurrentDate();
                        DateTime tarMnt = new DateTime();
                        tarMnt = objCommon.textToDateTime("01-01-" + dt.Rows[intRowBodyCount]["BUDGT_YEAR"].ToString());

                        if (strCancTransaction == "0" || tarMnt >= currMnt)
                        {
                            strHtml += "<a  href=\"#\" disabled=\"true\"  class=\"btn act_btn bn9 \" title=\"Review\" onclick=\"return ReViewNotPosble();\"><i class=\"fa fa-file-text-o\" style=\"cursor: pointer;\"></i></a>";
                        }
                        else if (strCancTransaction == "1")
                        {
                            strHtml += "  <a style=\"opacity: 1\" class=\"btn act_btn bn9\" title=\"Review\" onclick='return getdetails(this.href);' " +
                                     " href=\"fms_Budget_Review.aspx?Id=" + Id + "\"><i class=\"fa fa-file-text-o\"></i></a>";
                        }
                    }

                    if (CbxCnclStatus.Checked == true)
                    {
                        strHtml += "  <a style=\"opacity: 1;\" class=\"btn act_btn bn4\" title=\"VIEW\" onclick='return getdetails(this.href);' " +
                                     " href=\"fms_Budget.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";

                    }
                    strHtml += "</div></td>";
                }
            }
         strHtml += "</tr>";
        }
        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }



    [WebMethod]
    public static string CancelMemoReason(string strmemotId, string reasonmust, string usrId, string cnclRsn)
    {

        clsEntityLayerBudget objEntityLayerStock = new clsEntityLayerBudget();
        clsBusinessLayerBudget objBusinessLayerStock = new clsBusinessLayerBudget();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successcncl";
        string strRandomMixedId = strmemotId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityLayerStock.BudgetId = Convert.ToInt32(strId);
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
            DataTable dt = objBusinessLayerStock.CheckBdgtCnclSts(objEntityLayerStock);
            if (dt.Rows[0][0].ToString() == "" && dt.Rows[0][1].ToString() == "0")
            {
                objBusinessLayerStock.CancelBudget(objEntityLayerStock);
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
        try{
        clsEntityLayerBudget objEntitySupplier = new clsEntityLayerBudget();
        clsBusinessLayerBudget objBusinessLayerStock = new clsBusinessLayerBudget();
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
        objEntitySupplier.Mode = Convert.ToInt32(ddlMode.Value);
        DataTable dtList = objBusinessLayerStock.ReadBudgetList(objEntitySupplier);

        //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Budget);
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
        catch (Exception)
        {

        }
    }
}