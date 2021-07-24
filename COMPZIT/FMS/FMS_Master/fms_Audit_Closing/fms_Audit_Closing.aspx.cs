using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using CL_Compzit;
using EL_Compzit;
using System.Data;
using System.Text;
using System.Web.Services;
using EL_Compzit.EntityLayer_FMS;
using BL_Compzit.BusineesLayer_FMS;
using System.Collections.Generic;

public partial class FMS_FMS_Master_fms_Audit_Closing_fms_Audit_Closing : System.Web.UI.Page
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
            //RemoveUnwanted();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            HiddenCurrentDate.Value = objBusinessLayer.LoadCurrentDate().ToString("dd-MM-yyyy");
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            cls_Business_Audit_Closeing objBusinessAudit = new cls_Business_Audit_Closeing();
            clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
            clsCommonLibrary objcommon = new clsCommonLibrary();



            clsEntityCommon objEntityCommon = new clsEntityCommon();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                objEntityAudit.User_Id = intUserId;
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityAudit.Corporate_id = intCorpId;
                objEntityCommon.CorporateID = intCorpId;
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityAudit.Organisation_id = intOrgId;
                objEntityCommon.Organisation_Id = intOrgId;
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                            clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                             clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                             clsCommonLibrary.CORP_GLOBAL.AUDIT_DEPNDENT_STATUS        
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenCancelReasonMust.Value = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                HiddenFieldDecimalCnt.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                HiddenAuditDependent.Value = dtCorpDetail.Rows[0]["AUDIT_DEPNDENT_STATUS"].ToString();
            }
            DataTable dtAccountCls = objBusinessAudit.Read_Account_Close(objEntityAudit);



            if (dtAccountCls.Rows.Count > 0)
            {
                int count = dtAccountCls.Rows.Count - 1;
                HiddenAccountClsDate.Value = dtAccountCls.Rows[0]["ACCNT_CLS_DATE"].ToString();
                lblLastAccountClsdDate.InnerText = HiddenAccountClsDate.Value;
            }
            //To calculate last closed date
            DataTable dtCls1 = objBusinessAudit.Read_Audit_Close(objEntityAudit);
            DataTable dtCls = objBusinessAudit.ReadCloseDates(objEntityAudit);
            DivClsHis.InnerHtml = ConvertDataTableToHTMLClsgHistory(dtCls);
            if (dtCls1.Rows.Count > 0)
            {
                int count = dtCls1.Rows.Count - 1;
                HiddenLastClosDate.Value = dtCls1.Rows[0]["AUDIT_CLS_DATE"].ToString();
                lblLastAuditClsdDate.InnerText = HiddenLastClosDate.Value;

            }

            DateTime dtAudit = new DateTime();
            DateTime dtAccount = new DateTime();
            if (HiddenAccountClsDate.Value != "")
                dtAccount = objcommon.textToDateTime(HiddenAccountClsDate.Value);
            if (HiddenLastClosDate.Value != "")
            {
                dtAudit = objcommon.textToDateTime(HiddenLastClosDate.Value);
                dtAudit = dtAudit.AddDays(1);
            }
            if (dtAudit != DateTime.MinValue || dtAccount != DateTime.MinValue)
            {
                if (dtAudit >= dtAccount)
                    HiddenStartDate.Value = dtAudit.ToString("dd-MM-yyyy");
                else
                    HiddenStartDate.Value = dtAccount.ToString("dd-MM-yyyy");
            }
         
            if (HiddenCurrentDate.Value == HiddenLastClosDate.Value)
            {
                //  HiddenCurrentDate.Value = "";
            }

            lblEntry.Text = "Audit Closing";
            if (Session["FINCYRID"] != null)
            {
                objEntityCommon.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            DataTable dtfinaclYear = objBusinessLayer.ReadFinancialYearById(objEntityCommon);
            if (dtfinaclYear.Rows.Count > 0)
            {
                if (dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString() != "")
                {
                    HiddenFinancialYearTo.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();

                } if (dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString() != "")
                {
                    HiddenFinancialYearFrom.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                    if (HiddenStartDate.Value == "")
                    {
                        HiddenStartDate.Value = objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()).ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        if (objcommon.textToDateTime(HiddenStartDate.Value) >= objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && objcommon.textToDateTime(HiddenStartDate.Value) <= objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                        {

                        }
                        else
                        {
                            HiddenStartDate.Value = objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()).ToString("dd-MM-yyyy");
                        }
                    }
                }
                if (System.DateTime.Now >= objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && System.DateTime.Now <= objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                {
                    txtFromdate.Value = HiddenCurrentDate.Value;
                }
            }
            //if (Request.QueryString["Id"] != null)
            //{
            //    string strRandomMixedId = Request.QueryString["Id"].ToString();
            //    string strLenghtofId = strRandomMixedId.Substring(0, 2);
            //    int intLenghtofId = Convert.ToInt16(strLenghtofId);
            //    string strId = strRandomMixedId.Substring(2, intLenghtofId);
            //}
            //else if (Request.QueryString["ViewId"] != null)
            //{
            //    string strRandomMixedId = Request.QueryString["ViewId"].ToString();
            //    string strLenghtofId = strRandomMixedId.Substring(0, 2);
            //    int intLenghtofId = Convert.ToInt16(strLenghtofId);
            //    string strId = strRandomMixedId.Substring(2, intLenghtofId);
            //    txtFromdate.Disabled = true;
            //}

            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessMsg", "SuccessMsg();", true);
                }
                else if (strInsUpd == "InsCls")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "CloseErrorMsg", "CloseErrorMsg();", true);
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
                else if (Request.QueryString["InsUpd"] == "ConfirmSus")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirm", "SuccessConfirm();", true);
                }
                else if (Request.QueryString["InsUpd"] == "Confirmed")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AlreadyConfirm", "AlreadyConfirm();", true);
                }
                else if (Request.QueryString["InsUpd"] == "FailAudit")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AccountCloseBeforeAudit", "AccountCloseBeforeAudit();", true);
                }
                else if (Request.QueryString["InsUpd"] == "PendingConfirm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "PendingConfirmMsg", "PendingConfirmMsg();", true);
                }
            }
        }
    }

    public string ConvertDataTableToHTMLClsgHistory(DataTable dt)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
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
        strHtml += "<tr >";
        //<th class="col-md-3">Audit Date
        //        <i class="fa fa-sort pull-right hed_fa" aria-hidden="true"></i><br>
        strHtml += "<th class=\"col-md-3 hasinput\" > AUDIT DATE<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br>";
        strHtml += "<input class=\"tb_inp_1 tb_in\" placeholder=\" AUDIT DATE\"  style=\"text-align:CENTER;\" type=\"text\">";
        strHtml += "</th >";

        strHtml += "<th class=\"col-md-3 hasinput\" > ACTION DATE<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br>";
        strHtml += "<input class=\"tb_inp_1 tb_in\" placeholder=\"  ACTION DATE\" style=\"text-align:CENTER;\" type=\"text\">";
        strHtml += "</th >";

        strHtml += "<th class=\"col-md-3 hasinput\" >AUDITED BY<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br>";
        strHtml += "<input class=\"tb_inp_1 tb_in\" style=\"text-align:CENTER;\" placeholder=\"  AUDITED BY\"  type=\"text\">";
        strHtml += "</th >";

        //strHtml += "<th class=\"hasinput\" style=\"width:25%;text-align:center;\">ACTION DATE";
        //strHtml += "<input class=\"form-control\" placeholder=\"ACTION DATE\" style=\"text-align:center;\" type=\"text\">";
        //strHtml += "</th >";

        //strHtml += "<th class=\"hasinput\" style=\"width:34%;text-align:left;\">AUDITED BY";
        //strHtml += "<input class=\"form-control\" placeholder=\"AUDITED BY\" style=\"text-align:left;\" type=\"text\">";
        //strHtml += "</th >";
  
        strHtml += "<th class=\"col-md-3 hasinput\" >Actions <i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>";
        strHtml += "</th >";
        //strHtml += "<th class=\"hasinput\" >DELETE";
        //strHtml += "</th >";
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
            strHtml += "<tr>";
            strHtml += "<td>" + dt.Rows[intRowBodyCount]["AUDIT_CLS_DATE"].ToString() + "</td>";
            strHtml += "<td>" + dt.Rows[intRowBodyCount]["AUDIT_CLS_INS_USR_DATE"].ToString() + "</td>";
            if (dt.Rows[intRowBodyCount]["AUDIT_CLS_CONFRIM_STS"].ToString() != "")
            {
                if (dt.Rows[intRowBodyCount]["AUDIT_CLS_CONFRIM_STS"].ToString() == "1")
                {
                    strHtml += "<td>" + dt.Rows[intRowBodyCount]["EMPNAME"].ToString() + "</td>";

                       

                    strHtml += "<div class=\"btn_stl1\"><td ><a  href=\"javascript:;\" style=\"opacity: 0.5;\" class=\"btn act_btn bn2 \" title=\"Confirm\"><i class=\"fa fa-check\" style=\"\"></i></a>";
                    strHtml += "<a  href=\"#\" style=\"opacity: 0.5;\" class=\"btn act_btn bn3 \" title=\"Delete\" ><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a></div></td>";


                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\" width:34%;word-break: break-all; word-wrap:break-word;text-align: center;\" ></td>";
                    strHtml += "<div class=\"btn_stl1\"><td ><a  href=\"javascript:;\" style=\"opacity: 1;\" class=\"btn act_btn bn2 \" title=\"Confirm\" onclick=\"return OpenConfirm('" + Id + "');\"><i class=\"fa fa-check\" style=\"\"></i></a>";
                    strHtml += "<a  href=\"#\" style=\"opacity: 1;\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\" ><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a></div></td>";

                  
                    //strHtml += "<td style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><a  href=\"javascript:;\" style=\"opacity: 1;margin-left: 2%;z-index: 10;\" class=\"tooltip \" title=\"Confirm\" onclick=\"return OpenConfirm('" + Id + "');\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a></td>";
                    //strHtml += "<td style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><a  href=\"#\" style=\"opacity: 1;margin-left: 2%;z-index: 10;\" class=\"tooltip \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a></td>";

                }
            }
            
            
            strHtml += "</tr>";
        }
        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }

    protected void bttnsave_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        cls_Business_Audit_Closeing objBusinessAudit = new cls_Business_Audit_Closeing();
        clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityAudit.User_Id = intUserId;
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntityAudit.Corporate_id = intCorpId;
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityAudit.Organisation_id = intOrgId;
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityAudit.FromDate = objCommon.textToDateTime(txtFromdate.Value);
        int flag = 0;
        if (HiddenAuditDependent.Value == "1")
        {
            if (HiddenAccountClsDate.Value == "")
            {
                flag++;
                Response.Redirect("fms_Audit_Closing.aspx?InsUpd=FailAudit");
            }
        }
        DataTable dtNoncnfrm = objBusinessAudit.CheckNonConfirmEntry(objEntityAudit);
        if (dtNoncnfrm.Rows.Count > 0)
        {
            Response.Redirect("fms_Audit_Closing.aspx?InsUpd=PendingConfirm");
        }
        DataTable dtAccntCls = objBusinessAudit.CheckAuditClosingDate(objEntityAudit);

        int intErorCnt = 0;

        clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
        clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        objEntityCommon.CorporateID = intCorpId;
        objEntityAccnt.Corporate_id = intCorpId;
        objEntityCommon.Organisation_Id = intOrgId;
        objEntityAccnt.Organisation_id = intOrgId;
        DataTable dtCurrentFinclYr = objBusinessLayer.ReadFinancialYear(objEntityCommon);
        if (dtCurrentFinclYr.Rows.Count > 0)
        {
            objEntityCommon.FinancialYrId = Convert.ToInt32(dtCurrentFinclYr.Rows[0]["FINCYR_ID"].ToString());
            objEntityAccnt.FinancialYrId = Convert.ToInt32(dtCurrentFinclYr.Rows[0]["FINCYR_ID"].ToString());
        }

        DataTable dtClsYearEnd = objEmpAccntCls.CheckYearEndClose(objEntityAccnt);
        if (dtClsYearEnd.Rows.Count > 0)
        {
            if (dtClsYearEnd.Rows[0]["ACCNT_CLS_ID"].ToString() != "")
            {

            }
        }
        else
        {
            if (dtAccntCls.Rows.Count > 0)
            {
                intErorCnt++;
            }
        }

        if (intErorCnt > 0)
        {
            Response.Redirect("fms_Audit_Closing.aspx?InsUpd=InsCls");
        }
        else
        {
            if (flag == 0)
            {
                objBusinessAudit.InsertAuditClosing(objEntityAudit);
                if (clickedButton.ID == "bttnsave")
                {
                    Response.Redirect("fms_Audit_Closing.aspx?InsUpd=Ins");
                }
            }
        }
    }

    [WebMethod]
    public static string CancelMemoReason(string strmemotId, string reasonmust, string usrId, string cnclRsn, string strOrgID, string strCorprtID)
    {

        cls_Business_Audit_Closeing objBusinessAudit = new cls_Business_Audit_Closeing();
        clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successcncl";
        string strRandomMixedId = strmemotId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityAudit.AuditClsId = Convert.ToInt32(strId);
        objEntityAudit.User_Id = Convert.ToInt32(usrId);
        objEntityAudit.Corporate_id = Convert.ToInt32(strCorprtID);
        objEntityAudit.Organisation_id = Convert.ToInt32(strOrgID);
        if (reasonmust == "1")
        {
            objEntityAudit.Cancel_Reason = cnclRsn;
        }

        else
        {
            objEntityAudit.Cancel_Reason = objCommon.CancelReason();
        }

        try
        {
            DataTable dtChkCnfrm = objBusinessAudit.CheckAuditClsDateConfirmStatus(objEntityAudit);
            DataTable dt = objBusinessAudit.CheckAuditClsDateCnclSts(objEntityAudit);
            if (dt.Rows.Count > 0)
            {
                strRets = "UpdCancl";
            }
            else if (dtChkCnfrm.Rows.Count > 0)
            {
                if (dtChkCnfrm.Rows[0][0].ToString() != "" && dtChkCnfrm.Rows[0][0].ToString() != null)
                {
                    strRets = "Confirmed";

                }
            }
            else
            {
                objBusinessAudit.CancelAuditClsDate(objEntityAudit);
            }

        }
        catch
        {
            strRets = "failed";
        }
        return strRets;
    }

    [WebMethod]
    public static string ConfirmAccountClose(string strId, string strUserID, string strOrgID, string strCorprtID)
    {

        cls_Business_Audit_Closeing objBusinessAudit = new cls_Business_Audit_Closeing();
        clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "ConfirmSus";
        string strRandomMixedId = strId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string StrId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityAudit.AuditClsId = Convert.ToInt32(StrId);
        objEntityAudit.User_Id = Convert.ToInt32(strUserID);
        if (strOrgID != "")
        {
            objEntityAudit.Organisation_id = Convert.ToInt32(strOrgID);
        }
        if (strCorprtID != "")
        {
            objEntityAudit.Corporate_id = Convert.ToInt32(strCorprtID);
        }

        try
        {

            DataTable dt = objBusinessAudit.CheckAuditClsDateCnclSts(objEntityAudit);

            if (dt.Rows.Count > 0)
            {
                strRets = "UpdCancl";
            }

            else
            {
                objBusinessAudit.ConfirmAuditClsDate(objEntityAudit);
            }

        }
        catch
        {
            strRets = "failed";
        }
        return strRets;
    }


    public void RemoveUnwanted()
    {
        clsBusinessLayerLedgerStatmnt objBusinessLedgerStatmnt = new clsBusinessLayerLedgerStatmnt();
        clsEntityLedgerStatement objEntityLedgerStatmnt = new clsEntityLedgerStatement();

        DataTable dt = objBusinessLedgerStatmnt.ReadJournalRemove(objEntityLedgerStatmnt);

        List<clsEntityLedgerStatement> objDeleteList = new List<clsEntityLedgerStatement>();
        List<clsEntityLedgerStatement> objInsertList = new List<clsEntityLedgerStatement>();

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            clsEntityLedgerStatement objEntityLdgr = new clsEntityLedgerStatement();

            objEntityLdgr.VoucherId = Convert.ToInt32(dt.Rows[i]["VOCHR_ID"].ToString());
            objEntityLdgr.Ledger = Convert.ToInt32(dt.Rows[i]["LDGR_ID"].ToString());
            objEntityLdgr.VoucherAccntId = Convert.ToInt32(dt.Rows[i]["VOCHR_ACCNT_ID"].ToString());

            objDeleteList.Add(objEntityLdgr);

            DataTable dtInsert = objBusinessLedgerStatmnt.ReadJournalInsert(objEntityLdgr);

            for (int row = 0; row < dtInsert.Rows.Count; row++)
            {
                clsEntityLedgerStatement objEntityLdgrDtls = new clsEntityLedgerStatement();

                objEntityLdgrDtls.VoucherId = objEntityLdgr.VoucherId;
                objEntityLdgrDtls.Ledger = Convert.ToInt32(dtInsert.Rows[row]["LDGR_ID"].ToString());

                objInsertList.Add(objEntityLdgrDtls);
            }
        }

        objBusinessLedgerStatmnt.DeleteAndInsertJrnl(objDeleteList, objInsertList);

    }


}