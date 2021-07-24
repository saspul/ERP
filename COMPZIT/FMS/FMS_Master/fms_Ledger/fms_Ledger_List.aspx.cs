using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using BL_Compzit.BusinessLayer_FMS;
using EL_Compzit.EntityLayer_FMS;
using CL_Compzit;
using EL_Compzit;
using System.Data;
using System.Text;
using System.Web.Services;
public partial class FMS_FMS_Master_fms_Ledger_fms_Ledger_List : System.Web.UI.Page
{
    private enum Button_type
    {
        Previous = 1,
        Next = 2
    }
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
            hiddenPrevious.Value="1";
          //  hiddenNext.Value = "1";
            ddlAccountGrp.Focus();
            LoadAccountGrp();
            clsEntityLedger objEntityLedger = new clsEntityLedger();
            clsBusinessLayerLedger objBusinessLedger = new clsBusinessLayerLedger();
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                objEntityLedger.User_Id = intUserId;
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityLedger.Corp_Id = intCorpId;
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityLedger.Org_Id = intOrgId;

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (CbxCnclStatus.Checked == true)
            {
                objEntityLedger.CostCenterSts = 1;
            }
            else
            {
                objEntityLedger.CostCenterSts = 0;
            }
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Ledger);
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
                        HiddenRoleEdit.Value = intUpdate.ToString();
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenEnableCancl.Value = intEnableCancel.ToString();
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

           // objEntityLedger.Corp_Id = 0;
            objEntityLedger.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
            DataTable dtList = objBusinessLedger.ReadLedgerList(objEntityLedger);

           

            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                          clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                          clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE,
                                                          clsCommonLibrary.CORP_GLOBAL.FMS_CODE_NUMBER_FORMAT,
                                                       };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
           

            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenCancelReasonMust.Value = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                string strListingMode = dtCorpDetail.Rows[0]["LISTING_MODE"].ToString();
                string strLstingModeSize = dtCorpDetail.Rows[0]["LISTING_MODE_SIZE"].ToString();

                int intListingMode = Convert.ToInt32(strListingMode);

                if (intListingMode == 2)//variant
                {
                    btnNext.Text = "Show Next Records";
                    btnPrevious.Text = "Show Previous Records";
                    hiddenMemorySize.Value = strLstingModeSize;
                }
                else if (intListingMode == 1)//fixed
                {
                    btnNext.Text = "Show Next " + strLstingModeSize + " Records";
                    btnPrevious.Text = "Show Previous " + strLstingModeSize + " Records";
                    hiddenTotalRowCount.Value = strLstingModeSize;
                   hiddenNext.Value = strLstingModeSize;
                }
                hiddenPrevious.Value = "0";
            }

        }
        if (Request.QueryString["InsUpd"] != null)
        {

            if (Request.QueryString["InsUpd"] == "cncl")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessClose", "SuccessClose();", true);
                //    Response.Redirect("fms_Ledger_List.aspx");

            }
            else if (Request.QueryString["InsUpd"] == "Error")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessError", "SuccessError();", true);
            }
            else if (Request.QueryString["InsUpd"] == "UpdCancl")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessDeleted", "SuccessDeleted();", true);
            }
            else if (Request.QueryString["InsUpd"] == "Upd")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdMsg", "SuccessUpdMsg();", true);
            }
            if (Request.QueryString["InsUpd"] == "Ins")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessMsg", "SuccessMsg();", true);
            }
        }
    }
    public void LoadAccountGrp()
    {
        clsEntityLedger objEntityLedger = new clsEntityLedger();
        clsBusinessLayerLedger objBusinessLedger = new clsBusinessLayerLedger();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLedger.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityLedger.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityLedger.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtdiv = objBusinessLedger.ReadAccountGrpsLedgr(objEntityLedger);
        if (dtdiv.Rows.Count > 0)
        {
            ddlAccountGrp.DataSource = dtdiv;
            ddlAccountGrp.DataTextField = "ACNT_GRP_NAME";
            ddlAccountGrp.DataValueField = "ACNT_GRP_ID";
            ddlAccountGrp.DataBind();
        }
        ddlAccountGrp.Items.Insert(0, "--SELECT ACCOUNT GROUP--");

    }

    //public string ConvertDataTableToHTML(DataTable dt, int intUpdate, int intEnableCancel)
    //{
    //    int first = Convert.ToInt32(hiddenPrevious.Value);
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    string strRandom = objCommon.Random_Number();
    //    String Status = "";
    //    int intOrgId = 0;
    //    if (Session["ORGID"] != null)
    //    {
    //        intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
    //    }
    //    else if (Session["ORGID"] == null)
    //    {
    //        Response.Redirect("/Default.aspx");
    //    }
    //    StringBuilder sb = new StringBuilder();
    //    string strHtml = "";
    //    for (int intRowBodyCount = first; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
    //    {
    //        string strId = dt.Rows[intRowBodyCount][0].ToString();
    //        int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
    //        string stridLength = intIdLength.ToString("00");
    //        string Id = stridLength + strId + strRandom;

    //        int intMemoryBytes = System.Text.ASCIIEncoding.Unicode.GetByteCount(strHtml);

    //        if (hiddenTotalRowCount.Value == "")
    //        {
    //            if (hiddenMemorySize.Value == "")
    //            {
    //                int last = Convert.ToInt32(hiddenNext.Value) + Convert.ToInt32(hiddenTotalRowCount.Value);
    //                if (first == 0)
    //                {
    //                    btnPrevious.Enabled = false;
    //                }
    //                else
    //                {
    //                    btnPrevious.Enabled = true;
    //                }
    //                if (last < dt.Rows.Count)
    //                {
    //                    btnNext.Enabled = true;
    //                }
    //                else
    //                {
    //                    btnNext.Enabled = false;
    //                }

    //                strHtml += "<tr>";
    //                strHtml += "<td class=\"tr_l\">" + dt.Rows[intRowBodyCount]["LDGR_NAME"].ToString() + "</td>";
    //                strHtml += "<td class=\"tr_l\">" + dt.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString() + "</td>";
    //                strHtml += "<td class=\"tr_l\">" + dt.Rows[intRowBodyCount]["SUBLDGR_NAME"].ToString() + "</td>";

    //                strHtml += "<td class=\"tr_l\">" + dt.Rows[intRowBodyCount]["LDGR_CODE"].ToString() + "</td>";

    //                strHtml += "<td>";
    //                strHtml += "<div class=\"btn_stl1\">";

    //                if (intUpdate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
    //                {
    //                    if (CbxCnclStatus.Checked == false)
    //                    {
    //                        strHtml += "<a href=\"fms_Ledger.aspx?Id=" + Id + "\" class=\"btn act_btn bn1 bt_e\" title=\"Edit\">";
    //                        strHtml += "<i class=\"fa fa-edit\"></i>";
    //                        strHtml += "</a>";
    //                    }

    //                }
    //                if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
    //                {
    //                    if (CbxCnclStatus.Checked == false)
    //                    {
    //                        if (dt.Rows[intRowBodyCount]["SUB_STS"].ToString() != "0" || dt.Rows[intRowBodyCount]["SAL_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["PUCH_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["PAY_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["RCPT_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["BUDGT_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["PAY_CST_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["RCPT_CST_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["BUDGT_CST_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["L_Bnk"].ToString() != "0" || dt.Rows[intRowBodyCount]["L_customer"].ToString() != "0" || dt.Rows[intRowBodyCount]["L_Supplier"].ToString() != "0" || dt.Rows[intRowBodyCount]["L_PRODUCT_CATEGORY"].ToString() != "0" || dt.Rows[intRowBodyCount]["ACCSET_LED_ID"].ToString() != "0")
    //                        {
    //                            strHtml += "<a class=\"btn act_btn bn3\" title=\"Delete\" style=\"opacity: .4;\" href=\"#\" onclick=\"return OpenCancelBlock();\">";
    //                            strHtml += "<i class=\"fa fa-trash\"></i>";
    //                            strHtml += "</a>";
    //                        }
    //                        else
    //                        {
    //                            strHtml += "<a class=\"btn act_btn bn3\" title=\"Delete\" href=\"javascript:;\" onclick=\"return OpenCancelView('" + Id + "');\">";
    //                            strHtml += "<i class=\"fa fa-trash\"></i>";
    //                            strHtml += "</a>";
    //                        }

    //                    }

    //                }

    //                if (CbxCnclStatus.Checked == true || (intUpdate != Convert.ToInt32(clsCommonLibrary.StatusAll.Active) && intEnableCancel != Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
    //                {
    //                    strHtml += "<a class=\"btn act_btn bn4 bt_v\"  title=\"View\" href=\"fms_Ledger.aspx?ViewId=" + Id + "\">";
    //                    strHtml += "<i class=\"fa fa-list-alt\"></i>";
    //                    strHtml += "</a>";
    //                }
    //                strHtml += "</div>";
    //                strHtml += "</td>";
    //                strHtml += "</tr>";

    //            }
    //        }
    //        else
    //        {
    //            if (hiddenNext.Value == "")
    //            {
    //                hiddenNext.Value = hiddenTotalRowCount.Value;
    //            }

    //            int last = Convert.ToInt32(hiddenNext.Value);
    //            if (first == 0)
    //            {
    //                btnPrevious.Enabled = false;
    //            }
    //            else
    //            {
    //                btnPrevious.Enabled = true;
    //            }
    //            if (last < dt.Rows.Count)
    //            {
    //                btnNext.Enabled = true;
    //            }
    //            else
    //            {
    //                btnNext.Enabled = false;
    //            }

    //            if (intRowBodyCount < last)
    //            {

    //                strHtml += "<tr>";
    //                strHtml += "<td class=\"tr_l\">" + dt.Rows[intRowBodyCount]["LDGR_NAME"].ToString() + "</td>";
    //                strHtml += "<td class=\"tr_l\">" + dt.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString() + "</td>";
    //                strHtml += "<td class=\"tr_l\">" + dt.Rows[intRowBodyCount]["SUBLDGR_NAME"].ToString() + "</td>";

    //                strHtml += "<td class=\"tr_l\">" + dt.Rows[intRowBodyCount]["LDGR_CODE"].ToString() + "</td>";
    //                strHtml += "<td>";
    //                strHtml += "<div class=\"btn_stl1\">";

    //                if (intUpdate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
    //                {
    //                    if (CbxCnclStatus.Checked == false)
    //                    {
    //                        strHtml += "<a href=\"fms_Ledger.aspx?Id=" + Id + "\" class=\"btn act_btn bn1 bt_e\" title=\"Edit\">";
    //                        strHtml += "<i class=\"fa fa-edit\"></i>";
    //                        strHtml += "</a>";
    //                    }

    //                }
    //                if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
    //                {
    //                    if (CbxCnclStatus.Checked == false)
    //                    {
    //                        if (dt.Rows[intRowBodyCount]["SUB_STS"].ToString() != "0" || dt.Rows[intRowBodyCount]["SAL_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["PUCH_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["PAY_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["RCPT_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["BUDGT_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["PAY_CST_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["RCPT_CST_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["BUDGT_CST_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["L_Bnk"].ToString() != "0" || dt.Rows[intRowBodyCount]["L_customer"].ToString() != "0" || dt.Rows[intRowBodyCount]["L_Supplier"].ToString() != "0" || dt.Rows[intRowBodyCount]["L_PRODUCT_CATEGORY"].ToString() != "0" || dt.Rows[intRowBodyCount]["ACCSET_LED_ID"].ToString() != "0")
    //                        {
    //                            strHtml += "<a class=\"btn act_btn bn3\" title=\"Delete\" style=\"opacity: .4;\" href=\"#\" onclick=\"return OpenCancelBlock();\">";
    //                            strHtml += "<i class=\"fa fa-trash\"></i>";
    //                            strHtml += "</a>";
    //                        }
    //                        else
    //                        {
    //                            strHtml += "<a class=\"btn act_btn bn3\" title=\"Delete\" href=\"javascript:;\" onclick=\"return OpenCancelView('" + Id + "');\">";
    //                            strHtml += "<i class=\"fa fa-trash\"></i>";
    //                            strHtml += "</a>";
    //                        }

    //                    }
    //                }


    //                if (CbxCnclStatus.Checked == true || (intUpdate != Convert.ToInt32(clsCommonLibrary.StatusAll.Active) && intEnableCancel != Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
    //                {
    //                    strHtml += "<a class=\"btn act_btn bn4 bt_v\"  title=\"View\" href=\"fms_Ledger.aspx?ViewId=" + Id + "\">";
    //                    strHtml += "<i class=\"fa fa-list-alt\"></i>";
    //                    strHtml += "</a>";
    //                }

    //                strHtml += "</div>";
    //                strHtml += "</td>";
    //                strHtml += "</tr>";
    //            }
    //            else
    //            {
    //                btnNext.Enabled = true;
    //            }
    //        }
    //        strHtml += "</tr>";
    //    }
    //    sb.Append(strHtml);
    //    return sb.ToString();
    //}



   [System.Web.Services.WebMethod(EnableSession = true)]
    public static string CancelMemoReason(string strmemotId, string reasonmust, string usrId, string cnclRsn)
    {

        clsEntityLedger objEntityLedger = new clsEntityLedger();
        clsBusinessLayerLedger objBusinessLedger = new clsBusinessLayerLedger();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successcncl";
        string strRandomMixedId = strmemotId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityLedger.LedgerId = Convert.ToInt32(strId);
        objEntityLedger.User_Id = Convert.ToInt32(usrId);

        if (reasonmust == "1")
        {
            objEntityLedger.Cancel_Reason = cnclRsn;
        }

        else
        {
            objEntityLedger.Cancel_Reason = objCommon.CancelReason();
        }

        try
        {
            DataTable dt = objBusinessLedger.CheckLedgerCnclSts(objEntityLedger);
            if (dt.Rows.Count == 0)
            {

                objBusinessLedger.CancelLedger(objEntityLedger);
              //  HttpContext.Current.Session["CANCEL_STS"] = "successcncl";

            }
            else
            {
               // HttpContext.Current.Session["CANCEL_STS"] = "UpdCancl";
                strRets = "UpdCancl";
            }
        }
        catch
        {
         //   HttpContext.Current.Session["CANCEL_STS"] = "fail";
            strRets = "fail";
        }

        HttpContext.Current.Session["CANCEL_STS"] = strRets;
       
        return strRets;
    }


    protected void btnCnclSearch_Click(object sender, EventArgs e)
    {

        tblSearch.Attributes["style"] = "display:block;";
        clsEntityLedger objEntityLedger = new clsEntityLedger();
        clsBusinessLayerLedger objBusinessLedger = new clsBusinessLayerLedger();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntityLedger.User_Id = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntityLedger.Corp_Id = intCorpId;
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityLedger.Org_Id = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (CbxCnclStatus.Checked == true)
        {
            objEntityLedger.CostCenterSts = 1;
        }
        else
        {
            objEntityLedger.CostCenterSts = 0;
        }
        if (ddlAccountGrp.SelectedItem.Text != "--SELECT ACCOUNT GROUP--")
        {
            objEntityLedger.AccountGrpId =Convert.ToInt32( ddlAccountGrp.SelectedItem.Value);
        }
        objEntityLedger.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        DataTable dtList = objBusinessLedger.ReadLedgerList(objEntityLedger);

        //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Ledger);
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

    }
    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        Set_Table(Convert.ToInt32(Button_type.Previous));
    } 
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Set_Table(Convert.ToInt32(Button_type.Next));
    }
    public void Set_Table(int intButtonId)
    {


        clsEntityLedger objEntityLedger = new clsEntityLedger();
        clsBusinessLayerLedger objBusinessLedger = new clsBusinessLayerLedger();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntityLedger.User_Id = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntityLedger.Corp_Id = intCorpId;
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityLedger.Org_Id = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (CbxCnclStatus.Checked == true)
        {
            objEntityLedger.CostCenterSts = 1;
        }
        else
        {
            objEntityLedger.CostCenterSts = 0;
        }
        if (ddlAccountGrp.SelectedItem.Text != "--SELECT ACCOUNT GROUP--")
        {
            objEntityLedger.AccountGrpId = Convert.ToInt32(ddlAccountGrp.SelectedItem.Value);
        }
        objEntityLedger.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        DataTable dtList = objBusinessLedger.ReadLedgerList(objEntityLedger);

        //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Ledger);
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
                    HiddenRoleEdit.Value = intUpdate.ToString();
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                {
                    intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    hiddenEnableCancl.Value = intEnableCancel.ToString(); 
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


        int first = 0;
        int last = 0;

        if (intButtonId == Convert.ToInt32(Button_type.Next))
        {
            first = Convert.ToInt32(hiddenNext.Value);
            last = Convert.ToInt32(hiddenNext.Value) + Convert.ToInt32(hiddenTotalRowCount.Value);
            hiddenPrevious.Value = first.ToString();
            hiddenNext.Value = last.ToString();
        }

        if (intButtonId == Convert.ToInt32(Button_type.Previous))
        {
            first = Convert.ToInt32(hiddenPrevious.Value) - Convert.ToInt32(hiddenTotalRowCount.Value);
            last = Convert.ToInt32(hiddenPrevious.Value);
            hiddenPrevious.Value = first.ToString();
            hiddenNext.Value = last.ToString();
        }
        if (first == 0)
        {
            btnPrevious.Enabled = false;

        }
        else
        {
            btnPrevious.Enabled = true;
        }
        if (last < dtList.Rows.Count)
        {

            btnNext.Enabled = true;
        }
        else
        {
            btnNext.Enabled = false;
        }
    }

    public static string[] ConvertDataTableToHTML(DataTable dt, int CancelSts, int intEnableModify, int intEnableCancel)
    {
        string strHtml = "";
        string[] strReturn = new string[2];

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        StringBuilder sbHead = new StringBuilder();
        StringBuilder sb = new StringBuilder();

        //for (int i = 1; i < 5; i++)
        //{
        //    sbHead.Append("<th class=\"sorting\" id=\"tdColumnHead_" + (i + 1) + "\" onclick=\"SetOrderByValue(" + (i + 1) + ")\">" + dt.Columns[i].ColumnName + "</th>");
        //}


        sbHead.Append("<th id=\"tdColumnHead_1\" onclick=\"SetOrderByValue(1)\" class=\"sorting col-md-2 tr_l\" style=\"word-wrap:break-word;\">ACCOUNT NAME<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbHead.Append("<th id=\"tdColumnHead_2\" onclick=\"SetOrderByValue(2)\" class=\"sorting col-md-2 tr_l\" style=\"word-wrap:break-word;\">ACCOUNT GROUP<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbHead.Append("<th id=\"tdColumnHead_3\" onclick=\"SetOrderByValue(3)\" class=\"sorting col-md-2 tr_l\" style=\"word-wrap:break-word;\">MAIN LEDGER <i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
       
        sbHead.Append("<th class=\"col-md-2\" style=\"word-wrap:break-word;\">ACTIONS</th>");


        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            sb.Append("<tr>");

            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;


            strHtml += "<tr>";
            strHtml += "<td class=\"tr_l\"  style=\"word-break: break-all; word-wrap:break-word;\" > " + dt.Rows[intRowBodyCount]["LDGR_NAME"].ToString() + "</td>";
            strHtml += "<td class=\"tr_l\"  style=\"word-break: break-all; word-wrap:break-word;\" > " + dt.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString() + "</td>";
            strHtml += "<td class=\"tr_l\"  style=\"word-break: break-all; word-wrap:break-word;\" > " + dt.Rows[intRowBodyCount]["SUBLDGR_NAME"].ToString() + "</td>";
            strHtml += "<td style=\"display:none;\" > " + dt.Rows[intRowBodyCount]["LDGR_CODE"].ToString() + "</td>";

            strHtml += "<td>";
            strHtml += "<div class=\"btn_stl1\">";

            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (CancelSts == 0)
                {
                    strHtml += "<a href=\"fms_Ledger.aspx?Id=" + Id + "\"  class=\"btn act_btn bn1 bt_e\" title=\"Edit\">";
                    strHtml += "<i class=\"fa fa-edit\"></i>";
                    strHtml +=  "</a>";
                }
            }
            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (CancelSts == 0)
                {
                    if (dt.Rows[intRowBodyCount]["SUB_STS"].ToString() != "0" || dt.Rows[intRowBodyCount]["SAL_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["PUCH_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["PAY_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["RCPT_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["BUDGT_LED_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["PAY_CST_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["RCPT_CST_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["BUDGT_CST_ID"].ToString() != "0" || dt.Rows[intRowBodyCount]["L_Bnk"].ToString() != "0" || dt.Rows[intRowBodyCount]["L_customer"].ToString() != "0" || dt.Rows[intRowBodyCount]["L_Supplier"].ToString() != "0" || dt.Rows[intRowBodyCount]["L_PRODUCT_CATEGORY"].ToString() != "0" || dt.Rows[intRowBodyCount]["ACCSET_LED_ID"].ToString() != "0")
                    {
                        strHtml += "<a class=\"btn act_btn bn3\" title=\"Delete\" style=\"opacity: .4;\" href=\"#\" onclick=\"return OpenCancelBlock();\">";
                        strHtml += "<i class=\"fa fa-trash\"></i>";
                        strHtml += "</a>";
                    }
                    else
                    {
                        strHtml += "<a class=\"btn act_btn bn3\" title=\"Delete\" href=\"javascript:;\" onclick=\"return OpenCancelView('" + Id + "');\">";
                        strHtml += "<i class=\"fa fa-trash\"></i>";
                        strHtml += "</a>";
                    }
                }
            }
            if (CancelSts == 1 || (intEnableModify != Convert.ToInt32(clsCommonLibrary.StatusAll.Active) && intEnableCancel != Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
            {
                strHtml += "<a class=\"btn act_btn bn4 bt_v\"  title=\"View\" href=\"fms_Ledger.aspx?ViewId=" + Id + "\">";
                strHtml += "<i class=\"fa fa-list-alt\"></i>";
                strHtml += "</a>";
            }
            strHtml += "</div>";
            strHtml += "</td>";

            strHtml += "</tr>";
        }

        strReturn[0] = sbHead.ToString();
        strReturn[1] = strHtml;

        return strReturn;
    }
      [WebMethod]
    public static string[] GetData(string OrgId, string CorpId, string ddlStatus, string ddlAccountGrp, string CancelStatus, string EnableModify, string EnableCancel, string PageNumber, string PageMaxSize, string strCommonSearchTerm, string OrderColumn, string OrderMethod, string strInputColumnSearch)
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        clsBusinessLayerLedger objBusinessLedger = new clsBusinessLayerLedger();
        clsEntityLedger objEntityLedger = new clsEntityLedger();

        string[] strResults = new string[3];

        if (OrgId != null && OrgId != "")
        {
            objEntityLedger.Org_Id = Convert.ToInt32(OrgId);
        }
        if (CorpId != null && CorpId != "")
        {
            objEntityLedger.Corp_Id = Convert.ToInt32(CorpId);
        }
        objEntityLedger.Status = Convert.ToInt32(ddlStatus);
        objEntityLedger.CostCenterSts = Convert.ToInt32(CancelStatus);
        if (ddlAccountGrp != "--SELECT ACCOUNT GROUP--")
        {
            objEntityLedger.AccountGrpId = Convert.ToInt32(ddlAccountGrp);
        }

        objEntityLedger.PageNumber = Convert.ToInt32(PageNumber);
        objEntityLedger.PageMaxSize = Convert.ToInt32(PageMaxSize);
        objEntityLedger.OrderMethod = Convert.ToInt32(OrderMethod);
        objEntityLedger.OrderColumn = Convert.ToInt32(OrderColumn);
        objEntityLedger.CommonSearchTerm = strCommonSearchTerm;

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

        objEntityLedger.SearchName = strSearchInputs[Convert.ToInt32(SearchInputColumns.NAME)];
        objEntityLedger.SearchCode = strSearchInputs[Convert.ToInt32(SearchInputColumns.GROUP)];
        objEntityLedger.SearchAddress = strSearchInputs[Convert.ToInt32(SearchInputColumns.LEDGER)];


        //ReadList

        DataTable dtList = objBusinessLedger.ReadLedgerList(objEntityLedger);

        int intCancelStatus = Convert.ToInt32(CancelStatus);
        int intEnableModify = Convert.ToInt32(EnableModify);
        int intEnableCancel = Convert.ToInt32(EnableCancel);

        string[] strTableContents = new string[2];
        strTableContents = ConvertDataTableToHTML(dtList, intCancelStatus, intEnableModify, intEnableCancel);
        strResults[0] = strTableContents[0];
        strResults[1] = strTableContents[1];


        if (dtList.Rows.Count > 0)
        {
            int intTotalItems = Convert.ToInt32(dtList.Rows[0]["CNT"].ToString());
            int intCurrentRowCount = dtList.Rows.Count;

            //Pagination
            strResults[2] = objBusinessLayer.GenereatePagination(intTotalItems, objEntityLedger.PageNumber, objEntityLedger.PageMaxSize, intCurrentRowCount);
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
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"ACCOUNT NAME\" placeholder=\"Account name\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "1")
            {
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"ACCOUNT GROUP\" placeholder=\"Account group\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "2")
            {
                sbSearchInputColumns.Append("<th><input id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer();\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"MAIN LEDGER\" placeholder=\"Main ledger\"></th>");
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
        NAME = 0,
        GROUP = 1,
        LEDGER = 2,     
    }
}