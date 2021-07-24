using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using CL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Data;
using System.Web.UI;
using System.Web.Script.Serialization;
using System.Web.Services;

public partial class HCM_HCM_Master_hcm_Employee_Conduct_Management_hcm_Memo_Reason_Master_List : System.Web.UI.Page
{
    clsBusiness_Memo_Reason objBusinessMemoReason = new clsBusiness_Memo_Reason();
    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

    protected void Page_Load(object sender, EventArgs e)
    {
        clsEntity_Memo_Reason_Master objEntityMemoReason = new clsEntity_Memo_Reason_Master();
        clsBusiness_Memo_Reason objBusinessMemoReason = new clsBusiness_Memo_Reason();


        HiddenSuccessMsgType.Value = "0";
        if (Session["SuccessMsg"] != null)
        {
            HiddenSuccessMsgType.Value = Session["SuccessMsg"].ToString();
        }
        Session["SuccessMsg"] = null;
        if (!IsPostBack)
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();

            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intCorpId=0;
            hiddenEnableModify.Value = Convert.ToString(intEnableModify);
            hiddenEnableCancl.Value = Convert.ToString(intEnableCancel);
            if (Session["USERID"] != null)
            {
                objEntityMemoReason.User_Id = Convert.ToInt32(Session["USERID"]);
                intUserId = Convert.ToInt32(Session["USERID"]);
                HiddenusrId.Value = intUserId.ToString();
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityMemoReason.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityMemoReason.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Memo_Reason);
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
                        Hiddenenabladd.Value = intEnableAdd.ToString();
                    }

                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        Hiddenenabledit.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenEnableCancl.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                    }
                    
                }
            }

            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                divAdd.Visible=true;
            }
            else
            {
                divAdd.Visible=false;
            }

             DataTable dtReadMemoResn = objBusinessMemoReason.ReadLMemoResn(objEntityMemoReason);


             clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                       };

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
                     ScriptManager.RegisterStartupScript(this, GetType(), "MemoSuccessConfirmation", "MemoSuccessConfirmation();", true);
                 }
                 else if (strInsUpd == "Upd")
                 {
                     ScriptManager.RegisterStartupScript(this, GetType(), "MemoSuccessUpdation", "MemoSuccessUpdation();", true);
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
           

            if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
            {
                string strHidden = Request.QueryString["Srch"].ToString();
                HiddenSearchField.Value = strHidden;

                string[] strSearchFields = strHidden.Split(',');

                string strddlStatus = strSearchFields[0];
                string strCbxStatus = strSearchFields[1];


                if (strddlStatus != null && strddlStatus != "")
                {
                    if (ddlStatus.Items.FindByValue(strddlStatus) != null)
                    {
                        ddlStatus.ClearSelection();
                        ddlStatus.Items.FindByValue(strddlStatus).Selected = true;
                    }
                }
                if (strCbxStatus == "1")
                {
                    cbxCnclStatus.Checked = true;
                }
                else
                {
                    cbxCnclStatus.Checked = false;
                }

            }
    
        }
   
    [WebMethod]
    public static string CancelMemoReason(string strmemotId,string reasonmust, string usrId, string cnclRsn)
    {

        clsEntity_Memo_Reason_Master objEntityMemoReason = new clsEntity_Memo_Reason_Master();
        clsBusiness_Memo_Reason objBusinessMemoReason = new clsBusiness_Memo_Reason();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successcncl";
        string strRandomMixedId = strmemotId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityMemoReason.MemoId = Convert.ToInt32(strId);
        objEntityMemoReason.User_Id = Convert.ToInt32(usrId);
        objEntityMemoReason.MemoUserDate = System.DateTime.Now;
      

        if (reasonmust == "1")
        {
            objEntityMemoReason.MemoCnclRsn = cnclRsn;
        }
      
             else
        {
            objEntityMemoReason.MemoCnclRsn = objCommon.CancelReason();
        }

        try
        {
            objBusinessMemoReason.CancelMemoReason(objEntityMemoReason);
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
    public static string ChangeMemoStatus(string strmemotId, string strStatus)
    {

        clsEntity_Memo_Reason_Master objEntityMemoReason = new clsEntity_Memo_Reason_Master();
        clsBusiness_Memo_Reason objBusinessMemoReason = new clsBusiness_Memo_Reason();
        string strRet = "success";

        if (strStatus == "1")
        {
            objEntityMemoReason.MemoStatus = 0;
        }
        else
        {
            objEntityMemoReason.MemoStatus = 1;
        }
        string strRandomMixedId = strmemotId;
       string id= strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityMemoReason.MemoId = Convert.ToInt32(strId);
      
            
            objBusinessMemoReason.ChangeMemoStatus(objEntityMemoReason);
        
       
        return strRet;
    }
   
    }

   

   

   
