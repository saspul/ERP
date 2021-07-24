using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Collections;
using System.Web.Script.Serialization;
using System.Web.Services;


public partial class HCM_HCM_Master_hcm_Employee_Welfare_Service_hcm_Employee_Welfare_Service_Transaction_hcm_Welfare_Service_Transaction_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["Foc"] = "";

            ddlStatus.Focus();
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Emp_Welfare_Service_Master_Trans);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            divAdd.Visible = false;
            HiddenEnableModify.Value = "0";
            HiddenEnableDelete.Value = "0";
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intEnableAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        divAdd.Visible = true;
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenEnableModify.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenEnableDelete.Value = "1";
                    }
                }
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
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                }
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
                else if (strInsUpd == "Con")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdationConfirm", "SuccessUpdationConfirm();", true);
                }
                else if (strInsUpd == "Cncl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                }
                else if (strInsUpd == "ConfPrev")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationPre", "SuccessConfirmationPre();", true);
                }
                else if (strInsUpd == "ConfPrevDele")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationPreDele", "SuccessConfirmationPreDele();", true);
                }
            }

        }      
    }

    [WebMethod]
    public static string CancelTransctn(string strCatId, string reasonmust, string usrId, string cnclRsn)
    {

        clsEntityWelfareServiceTransaction objentityPassport = new clsEntityWelfareServiceTransaction();
        clsBusinessWelfareServiceTransaction objBussinesspasprt = new clsBusinessWelfareServiceTransaction();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successcncl";
        string strRandomMixedId = strCatId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objentityPassport.ServiceId = Convert.ToInt32(strId);
        objentityPassport.UserId = Convert.ToInt32(usrId);

        if (reasonmust == "1")
        {
            objentityPassport.CancelReason = cnclRsn;
        }
        else
        {
            objentityPassport.CancelReason = objCommon.CancelReason();
        }
        try
        {
            DataTable dt = objBussinesspasprt.checkConfrmSts(objentityPassport);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "1")
                {
                    strRets = "confirm";
                }
                if (dt.Rows[0][1].ToString() != "")
                {
                    strRets = "dele";                  
                }

            }
            if(strRets=="successcncl")
            objBussinesspasprt.CancelWelfareTransctn(objentityPassport);
        }
        catch
        {
            
        }
        return strRets;
    }
}