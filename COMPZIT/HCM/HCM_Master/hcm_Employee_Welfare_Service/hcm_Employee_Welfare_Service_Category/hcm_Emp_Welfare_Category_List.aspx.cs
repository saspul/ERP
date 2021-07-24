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


public partial class HCM_HCM_Master_hcm_Employee_Welfare_Service_hcm_Employee_Welfare_Service_Category_hcm_Emp_Welfare_Category_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, IntCorpId= 0;
        clsEntity_Emp_Welfare_Service_category objEntityWelfare_Category = new clsEntity_Emp_Welfare_Service_category();
        clsBusiness_Emp_Welfare_Service_Category objBusinessWelfare_Category = new clsBusiness_Emp_Welfare_Service_Category();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (!IsPostBack)
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityWelfare_Category.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                IntCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityWelfare_Category.OrgId = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                objEntityWelfare_Category.UserId = Convert.ToInt32(Session["USERID"].ToString());
                intUserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Emp_Welfare_Service);
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
                        HiddenEnableModify.Value=Convert.ToString(clsCommonLibrary.StatusAll.Active);
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
        [WebMethod]
    public static string CancelCategory(string strCatId, string reasonmust, string usrId, string cnclRsn)
    {

        clsEntity_Emp_Welfare_Service_category objEntityWelfare_Category = new clsEntity_Emp_Welfare_Service_category();
        clsBusiness_Emp_Welfare_Service_Category objBusinessWelfare_Category = new clsBusiness_Emp_Welfare_Service_Category();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successcncl";
        string strRandomMixedId = strCatId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityWelfare_Category.CategoryId = Convert.ToInt32(strId);
        objEntityWelfare_Category.UserId = Convert.ToInt32(usrId);
       
        if (reasonmust == "1")
        {
            objEntityWelfare_Category.CancelReason = cnclRsn;
        }

        else
        {
            objEntityWelfare_Category.CancelReason = objCommon.CancelReason();
        }

        try
        {
            objBusinessWelfare_Category.CancelWelfareCategory(objEntityWelfare_Category);
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
    public static string ChangeCategoryStatus(string strmemotId, string strStatus)
    {

        clsEntity_Emp_Welfare_Service_category objEntityWelfare_Category = new clsEntity_Emp_Welfare_Service_category();
        clsBusiness_Emp_Welfare_Service_Category objBusinessWelfare_Category = new clsBusiness_Emp_Welfare_Service_Category();
        string strRet = "success";

        if (strStatus == "1")
        {
            objEntityWelfare_Category.Status = 0;
        }
        else
        {
            objEntityWelfare_Category.Status = 1;
        }
        string strRandomMixedId = strmemotId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityWelfare_Category.CategoryId = Convert.ToInt32(strId);


        objBusinessWelfare_Category.ChangeCategoryStatus(objEntityWelfare_Category);


        return strRet;
    }
}