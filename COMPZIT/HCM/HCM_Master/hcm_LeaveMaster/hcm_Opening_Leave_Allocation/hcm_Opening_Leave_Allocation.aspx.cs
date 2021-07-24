using BL_Compzit;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CL_Compzit;
using EL_Compzit;
using System.Web.Services;
using System.Collections.Generic;
using BL_Compzit.BusinessLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using EL_Compzit.Entity_Layer_HCM;
using System.Collections;
using BL_Compzit.BusineesLayer_HCM;

public partial class HCM_HCM_Master_hcm_LeaveMaster_hcm_Opening_Leave_Allocation_hcm_Opening_Leave_Allocation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clsEntityLayerUserRegistration objEntityUserRegistration = new clsEntityLayerUserRegistration();
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
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

            int intUserLimited = Convert.ToInt32(USERLIMITED.ISLIMITED), intUsrDsgnId = 0;

            clsEntityLayerDesignation objEntityDsgnation = new clsEntityLayerDesignation();
            clsBusinessLayerDesignation objBusinessLayerDsgnMaster = new clsBusinessLayerDesignation();
            DataTable dtUserDetails = new DataTable();

            objEntityDsgnation.DesignationUserId = intUserId;
            dtUserDetails = objBusinessLayerDsgnMaster.ReadIfUserLimitedByUsrId(objEntityDsgnation);
            if (dtUserDetails.Rows.Count > 0)
            {
                intUserLimited = Convert.ToInt32(dtUserDetails.Rows[0]["USR_LMTD"].ToString());
                intUsrDsgnId = Convert.ToInt32(dtUserDetails.Rows[0]["DSGN_ID"].ToString());

            }
            if (Session["DSGN_TYPID"] != null)
            {
                hiddenDsgnTypId.Value = Session["DSGN_TYPID"].ToString();
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityUserRegistration.UserOrgId = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["DSGN_CONTROL"] != null)
            {
                hiddenDsgnControlId.Value = Session["DSGN_CONTROL"].ToString();
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

            if (hiddenDsgnControlId.Value == "C" || hiddenDsgnControlId.Value == "c")
            {

                if (Session["CORPOFFICEID"] != null)
                {

                    objEntityUserRegistration.UserCrprtId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            HiddenFieldCorpId.Value = Convert.ToString(objEntityUserRegistration.UserCrprtId);          

            HiddenFieldLmtdUser.Value = intUserLimited.ToString();
            HiddenFieldUserDesgId.Value = intUsrDsgnId.ToString();


            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, objEntityUserRegistration.UserCrprtId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            }

            // for adding comma
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
            }
        }
    }
    private enum USERLIMITED
    {
        ISLIMITED = 1,
        NOTLIMITED = 2

    }
    [WebMethod]
    public static string Insert_Leave_Details(string strEmpId, string strOpngLeave, string strBlncLeave, string strLeaveTypId, string strYear, string Msg,string strOrgID, string strCorpID)
    {
        string strResult = "TRUE";
        clsEntityOpeningLeaveAlloc objEntityOpngLvAlloc = new clsEntityOpeningLeaveAlloc();
        clsBuisnesslayerOpeningLeaveAlloc objBuisnessOpngLvAlloc = new clsBuisnesslayerOpeningLeaveAlloc();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        try
        {
            
            objEntityOpngLvAlloc.EmployeeId = Convert.ToInt32(strEmpId);
            objEntityOpngLvAlloc.LeaveType = Convert.ToInt32(strLeaveTypId);
            objEntityOpngLvAlloc.OpeningLeaveNumb = Convert.ToDecimal(strOpngLeave);
            objEntityOpngLvAlloc.BalanceLeaveNumb = Convert.ToDecimal(strBlncLeave);
            //objEntityOpngLvAlloc.LeaveAmount = Convert.ToDecimal(strLeaveAmnt);
            //objEntityOpngLvAlloc.BalanceLeaveAmount = Convert.ToDecimal(strBlncLeaveAmnt);
            objEntityOpngLvAlloc.LeaveYear = Convert.ToInt32(strYear);
            if (strOrgID != "" && strCorpID != "")
            {
                objEntityOpngLvAlloc.OrgId = Convert.ToInt32(strOrgID);
                objEntityOpngLvAlloc.CorpId = Convert.ToInt32(strCorpID);
                if (Msg == "INS")
                {
                    objBuisnessOpngLvAlloc.InsertLeaveAlloc(objEntityOpngLvAlloc);
                }
                else
                {
                    objEntityOpngLvAlloc.UsrerId = Convert.ToInt32(strEmpId);
                    objBuisnessOpngLvAlloc.UpdateLeaveAlloc(objEntityOpngLvAlloc);
                }
            }
            else
            {
                strResult = "FALSE";
            }
            
        }
        catch (Exception ex)
        {
            strResult = "FALSE";
        }

        return strResult;
    }
    [WebMethod]
    public static string Confirm_Leave_Details(string strId, string strCnfrmUsrId)
    {
        string strReault = "TRUE";
        clsEntityOpeningLeaveAlloc objEntityOpngLvAlloc = new clsEntityOpeningLeaveAlloc();
        clsBuisnesslayerOpeningLeaveAlloc objBuisnessOpngLvAlloc = new clsBuisnesslayerOpeningLeaveAlloc();
        try
        {
            objEntityOpngLvAlloc.UsrerId = Convert.ToInt32(strId);
            objEntityOpngLvAlloc.ConfirmSts = 1;
            objEntityOpngLvAlloc.ConfirmUserId = Convert.ToInt32(strCnfrmUsrId);
            objBuisnessOpngLvAlloc.ConfirmLeaveAlloc(objEntityOpngLvAlloc);
        }
        catch(Exception ex)
        {
            strReault = "FALSE";
        }

        return strReault;
    }
    
}