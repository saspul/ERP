using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using EL_Compzit.EntityLayer_FMS;
using BL_Compzit;
using BL_Compzit.BusinessLayer_FMS;
using CL_Compzit;
using System.Data;
using System.Text;
using System.Web.Services;
using BL_Compzit.BusineesLayer_FMS;
public partial class FMS_FMS_Master_fms_Cost_Group_fms_Cost_Group_List : System.Web.UI.Page
{
    clsBusinessLyer_Cost_Group objBusinessCOST = new clsBusinessLyer_Cost_Group();
    protected void Page_Load(object sender, EventArgs e)
    {
        ddlStatus.Focus();
        clsEntityLayer_Cost_Group objEntity = new clsEntityLayer_Cost_Group();
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
            ddlStatus.Focus();
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

                objEntity.UserId = intUserId;

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                objEntity.Corp_Id = intCorpId;
                // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntity.Org_Id = intOrgId;

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Cost_Group);
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
                        // HiddenRoleEdit.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active); ;
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

            objEntity.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
            DataTable dtList = objBusinessCOST.ReadCOSTList(objEntity);

            //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

            divList.InnerHtml = ConvertDataTableToHTML(dtList, intUpdate, intEnableCancel);
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                       };

            DataTable dtCorpDetail = new DataTable();
            //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
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
                else if (strInsUpd == "Ins")
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                }
                else if (strInsUpd == "Upd")
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
                else if (strInsUpd == "AlCancl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AlreadyCancelMsg", "AlreadyCancelMsg();", true);
                }
            }

        }
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

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"display table-bordered\" width=\"100%\" >";
        //add header row
        strHtml += "<thead class=\"thead1\">";
        strHtml += "<tr id=\"SearchRow\" >";
        // strHtml += "<th class=\"hasinput\" style=\"width:3%;text-align:left;\"> SL#";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"col-md-4 tr_l hasinput\" >COST GROUP ";

                strHtml += "	<input class=\"tb_inp_1 tb_in \" placeholder=\" COST GROUP\"  type=\"text\">";
                strHtml += "</th >";


            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"col-md-2 hasinput\" \">STATUS ";
                strHtml += "<input class=\"tb_inp_1 tb_in\" placeholder=\"STATUS \" type=\"text\">";
                strHtml += "</th >";
              
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"col-md-4 tr_l hasinput\" >HIERARCHY ";
                strHtml += "<input class=\"tb_inp_1 tb_in\" placeholder=\"HIERARCHY \"  type=\"text\">";
                strHtml += "</th >";
            }

            else if (intColumnHeaderCount == 4)
            {
                strHtml += " <th class=\"col-md-2 hasinput\" >Actions <p class=\"nbsp1\">&nbsp;</p></th>";
            }
        }
        //if (cbxCnclStatus.Checked == true)
        //{
        //    strHtml += "<th class=\"hasinput\" style=\"width:1%;text-align: center;\"> VIEW";
        //}

        strHtml += "</th >";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        int COUNT = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            //  string orgid = dt.Rows[intRowBodyCount][0].ToString();
            // strHtml += "<td class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + slno + "</td>";
            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            COUNT++;
            int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());
            // strHtml += "<td class=\"tdT\" style=\" width:3%;text-align: left;\" >" + COUNT + "</td>";

            for (int intColumnBodyCount = 0; intColumnBodyCount < 7; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tr_l\" >" + dt.Rows[intRowBodyCount]["COSTGRP_NAME"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {

                    strHtml += "<td class=\"td1\" >" + dt.Rows[intRowBodyCount]["COSTGRP_STATUS"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 3)
                {

                    strHtml += "<td class=\"tr_l\" >" + dt.Rows[intRowBodyCount]["HIRCHY_NAME"].ToString() + "</td>";
                }


                else if (intColumnBodyCount == 4)
                {

                    strHtml += "<td class=\"td1\"><div class=\"btn_stl1\">";
                    if (intUpdate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (cbxCnclStatus.Checked == false)
                        {

                            strHtml += "<a style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn1\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                            " href=\"fms_Cost_Group.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";
                        }
                    }
                    if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (cbxCnclStatus.Checked == false)
                        {
                            if (intCancTransaction == 0)
                                strHtml += "<a  href=\"#\" style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                            else
                                strHtml += "<a  href=\"#\" style=\"opacity: .4;z-index: 10;\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";

                        }

                    }
                    if (cbxCnclStatus.Checked == true)
                    {
                        strHtml += " <a style=\"opacity: 1;\" class=\"btn act_btn bn4\" title=\"VIEW\" onclick='return getdetails(this.href);' " +
                                     " href=\"fms_Cost_Group.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";
                    }
                    strHtml += " </div></td >";
                }
            }

                strHtml += "</tr>";
            
        }
        //if (dt.Rows.Count == 0)
        //{
        //    strHtml += "<td class=\"tdT\"colspan=\"7\" style=\" width:16%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No Data Available</td>";

        //}

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsEntityLayer_Cost_Group objEntity = new clsEntityLayer_Cost_Group();

        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UserId = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntity.Corp_Id = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.Org_Id = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Cost_Group);
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
                    // HiddenRoleEdit.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active); ;
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                {
                    intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    hiddenEnableCancl.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                }


            }
        }
        if (cbxCnclStatus.Checked == true)
        {

            objEntity.Cancl_Status = 1;
        }
        else
        {
            objEntity.Cancl_Status = 0;
        }
        objEntity.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        DataTable dtList = objBusinessCOST.ReadCOSTList(objEntity);

        //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        divList.InnerHtml = ConvertDataTableToHTML(dtList, intUpdate, intEnableCancel);
    }
    [WebMethod]
    public static string CancelMemoReason(string strmemotId, string reasonmust, string usrId, string cnclRsn, string strOrgIdID, string strCorpID)
    {
        clsBusinessLyer_Cost_Group objBusinessCOST = new clsBusinessLyer_Cost_Group();
        clsEntityLayer_Cost_Group objEntity = new clsEntityLayer_Cost_Group();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successcncl";
        string strRandomMixedId = strmemotId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntity.CostId = Convert.ToInt32(strId);
        objEntity.UserId = Convert.ToInt32(usrId);
        objEntity.Org_Id = Convert.ToInt32(strOrgIdID);
        objEntity.Corp_Id = Convert.ToInt32(strCorpID);



        DataTable dtList = objBusinessCOST.ReadCostCnclChck(objEntity);
        try
        {
            if (dtList.Rows.Count > 0)
            {
                int intCancTransaction = Convert.ToInt32(dtList.Rows[0]["COUNT_TRANSACTION"].ToString());
                if (intCancTransaction == 0)
                {
                    if (reasonmust == "1")
                    {
                        objEntity.CancelReason = cnclRsn;
                    }
                    else
                    {
                        objEntity.CancelReason = objCommon.CancelReason();
                    }
                    objBusinessCOST.CancelCostGroup(objEntity);
                }
                else
                {
                    strRets = "Cncld";
                }

            }
        }
        catch
        {
            strRets = "failed";
        }

        return strRets;


    }
}