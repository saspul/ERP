using System;
using System.Web.UI;
using BL_Compzit;
using System.Data;
using CL_Compzit;
using System.Web.Services;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;

public partial class HCM_HCM_Master_hcm_Employee_Welfare_Service_hcm_Employee_Welfare_Service_hcm_Emp_Welfare_Service_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, IntCorpId = 0;
        clsEntity_Emp_Welfare_Service objEntityWelfare = new clsEntity_Emp_Welfare_Service();
        clsBusiness_Emp_Welfare_Service objBusinessWelfare = new clsBusiness_Emp_Welfare_Service();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        //txtFromdate.Focus();

        if (!IsPostBack)
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityWelfare.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                IntCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityWelfare.OrgId = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                objEntityWelfare.UserId = Convert.ToInt32(Session["USERID"].ToString());
                intUserId = Convert.ToInt32(Session["USERID"].ToString());
                HiddenUsrId.Value = Session["USERID"].ToString();
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            Designationload();

            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Emp_Welfare_Service_Master);
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
            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                divAdd.Visible = true;
            }
            else
            {
                divAdd.Visible = false;
            }
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = { clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, IntCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenCancelReasonMust.Value = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
            }
            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                }
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
                else if (strInsUpd == "Cncl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                }
                else if (strInsUpd == "StsCh")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessStatusChange", "SuccessStatusChange();", true);
                }
            }
        }
    }
    public void Designationload()
    {
        clsEntity_Emp_Welfare_Service objEntityWelfare_Service = new clsEntity_Emp_Welfare_Service();
        clsBusiness_Emp_Welfare_Service objBusiness_Welfare_Service = new clsBusiness_Emp_Welfare_Service();
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityWelfare_Service.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityWelfare_Service.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtDesignation = objBusiness_Welfare_Service.ReadDesignation(objEntityWelfare_Service);
        ddlDesignation.Items.Clear();

        ddlDesignation.DataSource = dtDesignation;
        ddlDesignation.DataTextField = "DSGN_NAME";
        ddlDesignation.DataValueField = "DSGN_ID";
        ddlDesignation.DataBind();
        ddlDesignation.Items.Insert(0, "--SELECT DESIGNATION--");
    }
    [WebMethod]
    public static string CancelWelfareService(string strSrvcId, string reasonmust, string usrId, string cnclRsn)
    {
        clsEntity_Emp_Welfare_Service objEntityWelfare_Service = new clsEntity_Emp_Welfare_Service();
        clsBusiness_Emp_Welfare_Service objBusiness_Welfare_Service = new clsBusiness_Emp_Welfare_Service();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successcncl";
        string strRandomMixedId = strSrvcId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityWelfare_Service.WelfareServiceId = Convert.ToInt32(strId);
        objEntityWelfare_Service.UserId = Convert.ToInt32(usrId);

        if (reasonmust == "1")
        {
            objEntityWelfare_Service.CancelReason = cnclRsn;
        }

        else
        {
            objEntityWelfare_Service.CancelReason = objCommon.CancelReason();
        }

        try
        {
            objBusiness_Welfare_Service.CancelWelfareService(objEntityWelfare_Service);
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
    public static string ChangeSrvcStatus(string strmemotId, string strStatus, string strUserID)
    {
        clsEntity_Emp_Welfare_Service objEntityWelfare_Service = new clsEntity_Emp_Welfare_Service();
        clsBusiness_Emp_Welfare_Service objBusiness_Welfare_Service = new clsBusiness_Emp_Welfare_Service();
        string strRet = "success";

        if (strStatus == "1")
        {
            objEntityWelfare_Service.Status = 0;
        }
        else
        {
            objEntityWelfare_Service.Status = 1;
        }
        string strRandomMixedId = strmemotId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityWelfare_Service.WelfareServiceId = Convert.ToInt32(strId);
        objEntityWelfare_Service.UserId = Convert.ToInt32(strUserID);
        objBusiness_Welfare_Service.ChangeServiceStatus(objEntityWelfare_Service);
        return strRet;
    }

}