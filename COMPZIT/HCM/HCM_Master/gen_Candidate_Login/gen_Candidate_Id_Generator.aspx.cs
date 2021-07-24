using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HCM_HCM_Master_gen_Candidate_Login_gen_Candidate_Id_Generator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblcandidateid.Text = "";
        //btnIdGenerate.Visible = false;

        if (!IsPostBack)
        {
           // btnIdGenerate.Enabled = false;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsEntityCandidatelogin objEntityCandRegistr = new clsEntityCandidatelogin();
            clsBusiness_Candidate_Login objBusiness_Candidate_Login = new clsBusiness_Candidate_Login();

            int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableReOpen = 0, intEnableHrConfirm = 0, intEnableGMApprove = 0, intEnableConfirm = 0, intEnableClose = 0, intCorpId = 0, intOrgId = 0;

            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
                objEntityCandRegistr.CorpOffice_Id = intCorpId;
                objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"]);
                objEntityCandRegistr.Organisation_Id = intOrgId;
                objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            //candidate load

            DataTable dtcandidates = objBusiness_Candidate_Login.ReadCandidates(objEntityCandRegistr);
            
                ddlcandidate.DataSource = dtcandidates;
                ddlcandidate.DataValueField = "CAND_ID";
                ddlcandidate.DataTextField = "CAND_NAME";
                ddlcandidate.DataBind();
                ddlcandidate.Items.Insert(0, "--SELECT CANDIDATE--");
                       
            intUserRoleRecall = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
            DataTable dtCancelRecall = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUserRoleRecall);
            if (dtCancelRecall.Rows.Count > 0)
            {
                intEnableRecall = 1;
            }
            else
            {
                intEnableRecall = 0;
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Mapower_Requirement);
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
                        //  Hiddenenabledit.Value = intEnableModify.ToString(); ;
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        //   Hiddenenablecancl.Value = intEnableCancel.ToString(); ;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                    {
                        intEnableHrConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        //   HiddenHrCnfrm.Value = intEnableHrConfirm.ToString(); ;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.GM_Allocation).ToString())
                    {
                        intEnableGMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        //  HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        //    HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        //    HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString())
                    {
                        intEnableClose = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        //    HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                    }
                }
            }
        }
       
    }
    protected void btnIdGenerate_Click(object sender, EventArgs e)
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsEntityCandidatelogin objEntityCandRegistr = new clsEntityCandidatelogin();
        clsBusiness_Candidate_Login objBusiness_Candidate_Login = new clsBusiness_Candidate_Login();
        int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableReOpen = 0, intEnableHrConfirm = 0, intEnableGMApprove = 0, intEnableConfirm = 0, intEnableClose = 0, intCorpId = 0, intOrgId = 0;

        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);

            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"]);
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (ddlcandidate.SelectedItem.Value!="--SELECT CANDIDATE--")
        objEntityCandRegistr.CandidateId = Convert.ToInt32(ddlcandidate.SelectedItem.Value);
        objEntityCandRegistr.CorpOffice_Id = intCorpId;
        objEntityCandRegistr.Organisation_Id = intOrgId;
        objEntityCandRegistr.User_Id = intUserId;
        DataTable Dtcandidate = objBusiness_Candidate_Login.Readlogin(objEntityCandRegistr);
         
        if (Dtcandidate.Rows.Count > 0)
        {
           // btnIdGenerate.Visible = false;
            lblcandidateid.Text = Dtcandidate.Rows[0]["CAND_GENERATED_ID"].ToString();

        }
        else
        {
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CANDIDATE_LOGIN);
            objEntityCommon.CorporateID = intCorpId;
            objEntityCommon.Organisation_Id = intOrgId;
            string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
            hiddenenxtid.Value = strNextId;
            string year = DateTime.Today.Year.ToString();
            lblcandidateid.Text = "EMP/" + year + "/" + hiddenenxtid.Value;

            objEntityCandRegistr.GeneratedCandidateId = lblcandidateid.Text;
            if (ddlcandidate.SelectedItem.Value != "--SELECT CANDIDATE--")
            {
                objEntityCandRegistr.CandidateId = Convert.ToInt32(ddlcandidate.SelectedValue);

                objBusiness_Candidate_Login.AddLogin(objEntityCandRegistr);
            }
            // DataTable dtNextId = objBusinessLayerUserRegisteration.ReadNextId(objEntityUsrRegistr);
            // objEntityCandRegistr.UsrRegistrationId = Convert.ToInt32(dtNextId.Rows[0]["MST_NEXT_VALUE"]);
            // HiddenEmployeeMasterId.Value = dtNextId.Rows[0]["MST_NEXT_VALUE"].ToString();
            //txtRefNum.Text = "REF/" + year + "/" + hiddenenxtid.Value;

        }
    }
    protected void ddlcandidate_SelectedIndexChanged(object sender, EventArgs e)
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsEntityCandidatelogin objEntityCandRegistr = new clsEntityCandidatelogin();
        clsBusiness_Candidate_Login objBusiness_Candidate_Login = new clsBusiness_Candidate_Login();
        int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableReOpen = 0, intEnableHrConfirm = 0, intEnableGMApprove = 0, intEnableConfirm = 0, intEnableClose = 0, intCorpId = 0, intOrgId = 0;

        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);

            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"]);
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityCandRegistr.CorpOffice_Id = intCorpId;
        objEntityCandRegistr.Organisation_Id = intOrgId;
        if (ddlcandidate.SelectedItem.Value == "--SELECT CANDIDATE--")
        { 
        
        }
        else
     
            objEntityCandRegistr.CandidateId = Convert.ToInt32(ddlcandidate.SelectedItem.Value);
    DataTable Dtcandidate=    objBusiness_Candidate_Login.Readlogin(objEntityCandRegistr);
    if (Dtcandidate.Rows.Count > 0)
    {
       // btnIdGenerate.Visible = false;
        lblcandidateid.Text = Dtcandidate.Rows[0]["CAND_GENERATED_ID"].ToString();

    }
    else
    {
        //btnIdGenerate.Visible = true;
        lblcandidateid.Text = "";
    }
    ScriptManager.RegisterStartupScript(this, GetType(), "Reload", "Reload();", true);
    }
    [System.Web.Services.WebMethod]
    public static string CreateID(string orgID,string corpID,string CandID)
    {
        clsEntityCandidatelogin objEntityCandRegistr = new clsEntityCandidatelogin();
        clsBusiness_Candidate_Login objBusiness_Candidate_Login = new clsBusiness_Candidate_Login();
        string strID = "";
        objEntityCandRegistr.CorpOffice_Id = Convert.ToInt32(corpID); 
        objEntityCandRegistr.Organisation_Id = Convert.ToInt32(orgID); 
        if (CandID == "--SELECT CANDIDATE--")
        {

        }
        else

            objEntityCandRegistr.CandidateId = Convert.ToInt32(CandID);
        DataTable Dtcandidate = objBusiness_Candidate_Login.Readlogin(objEntityCandRegistr);
        if (Dtcandidate.Rows.Count > 0)
        {
            strID = Dtcandidate.Rows[0]["CAND_GENERATED_ID"].ToString();
        }
        else
        {
            strID = "";
        }
        return strID;
    }
}