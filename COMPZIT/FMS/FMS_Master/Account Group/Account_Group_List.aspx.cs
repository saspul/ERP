using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusinessLayer_FMS;
using EL_Compzit.EntityLayer_FMS;
using System.Data;
using System.Web.Services;
public partial class FMS_FMS_Master_Account_Group_Account_Group_List : System.Web.UI.Page
{
    clsEntityAccountGroup objEntityAccountGroup = new clsEntityAccountGroup();
    clsBusinessAccountGroup objBusinessAcountGrp = new clsBusinessAccountGroup();
    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
    clsCommonLibrary objCommon = new clsCommonLibrary();
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

        ddlParentGroup.Focus();
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, IntCorpId = 0;
        if (!IsPostBack)
        {
            LoadAccountGroup();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityAccountGroup.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                IntCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityAccountGroup.OrgId = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                objEntityAccountGroup.UserId = Convert.ToInt32(Session["USERID"].ToString());
                intUserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.FMS_ACCOUNT_GROUP);
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
    public void LoadAccountGroup()
    {
        clsEntityAccountGroup objEntityAccountGroup = new clsEntityAccountGroup();
        clsBusinessAccountGroup objBusinessAcountGrp = new clsBusinessAccountGroup();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityAccountGroup.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityAccountGroup.OrgId = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtAccount = objBusinessAcountGrp.LoadAccountGroup(objEntityAccountGroup);
        ddlParentGroup.Items.Clear();

        ddlParentGroup.DataSource = dtAccount;
        ddlParentGroup.DataTextField = "ACNT_GRP_NAME";
        ddlParentGroup.DataValueField = "ACNT_GRP_ID";
        ddlParentGroup.DataBind();
        ddlParentGroup.Items.Insert(0, "--SELECT GROUP--");

    }

    [WebMethod]
    public static string ChangeAccountStatus(string strmemotId, string strStatus, string UsrId)
    {
        clsEntityAccountGroup objEntityAccountGroup = new clsEntityAccountGroup();
        clsBusinessAccountGroup objBusinessAcountGrp = new clsBusinessAccountGroup();
        string strRet = "success";
        string strRandomMixedId = strmemotId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityAccountGroup.AccountGrpId = Convert.ToInt32(strId);
        objEntityAccountGroup.UserId = Convert.ToInt32(UsrId);
        if (strStatus == "1")
        {
            objEntityAccountGroup.Cancel_status = 0;
        }
        else
        {
            objEntityAccountGroup.Cancel_status = 1;
        }
        objBusinessAcountGrp.ChangeAccountStatus(objEntityAccountGroup);
        return strRet;
    }

    [WebMethod]
    public static string CancelAccountGrp(string strCatId, string reasonmust, string usrId, string cnclRsn)
    {
        clsEntityAccountGroup objEntityAccountGroup = new clsEntityAccountGroup();
        clsBusinessAccountGroup objBusinessAcountGrp = new clsBusinessAccountGroup();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successcncl";
        string strRandomMixedId = strCatId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityAccountGroup.AccountGrpId = Convert.ToInt32(strId);
        objEntityAccountGroup.UserId = Convert.ToInt32(usrId);

        if (reasonmust == "1")
        {
            objEntityAccountGroup.CancelReason = cnclRsn;
        }

        else
        {
            objEntityAccountGroup.CancelReason = objCommon.CancelReason();
        }

        try
        {
            objBusinessAcountGrp.CancelAccountGroup(objEntityAccountGroup);
            Page objpage = new Page();
            objpage.Session["SuccessMsg"] = "DELETE";
        }
        catch
        {
            strRets = "failed";
        }
        return strRets;
    }
}