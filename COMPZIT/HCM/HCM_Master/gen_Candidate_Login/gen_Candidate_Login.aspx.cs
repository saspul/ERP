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

public partial class HCM_HCM_Master_gen_Candidate_Login_Gen_Candidate_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
              if (!IsPostBack)
        {
           // btnIdGenerate.Enabled = false;
            txtcandidate.Focus();
          
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

            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"]);
                objEntityCandRegistr.Organisation_Id = intOrgId;
                objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
       
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
    
            //candidate load

         
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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Candidate_LogIn);
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

                        HiddenConfirm.Value = clsCommonLibrary.StatusAll.Active.ToString()  ;

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


            if (Request.QueryString["Sts"] != null)
            {
                Label1.Text = "Permission Denied";
            }
            else
            {
                if (intEnableConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    Response.Redirect("gen_Candidate_Login.aspx?Sts=Denied");
                }
            }
        }
    }



          protected void SignIn_Click(object sender, EventArgs e)
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsEntityCandidatelogin objEntityCandRegistr = new clsEntityCandidatelogin();
        clsBusiness_Candidate_Login objBusiness_Candidate_Login = new clsBusiness_Candidate_Login();
        int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableReOpen = 0, intEnableHrConfirm = 0, intEnableGMApprove = 0, intEnableConfirm = 0, intEnableClose = 0, intCorpId = 0, intOrgId = 0;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        if (HiddenConfirm.Value == (clsCommonLibrary.StatusAll.Active).ToString())
        {
            Response.Redirect("gen_Candidate_Login.aspx?Sts=Denied");
        }




        //if (Session["CORPOFFICEID"] != null)
        //{
        //    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);

        //    objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        //}
        //else if (Session["CORPOFFICEID"] == null)
        //{
        //    Response.Redirect("/Default.aspx");
        //}
        //if (Session["ORGID"] != null)
        //{
        //    intOrgId = Convert.ToInt32(Session["ORGID"]);
        //    objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        //}
        //else if (Session["ORGID"] == null)
        //{
        //    Response.Redirect("/Default.aspx");
        //}
        //if (Session["USERID"] != null)
        //{
        //    intUserId = Convert.ToInt32(Session["USERID"]);

        //}
        //else if (Session["USERID"] == null)
        //{
        //    Response.Redirect("/Default.aspx");
        //}
        objEntityCandRegistr.CorpOffice_Id = intCorpId;
        objEntityCandRegistr.Organisation_Id = intOrgId;
        objEntityCandRegistr.GeneratedCandidateId = txtcandidate.Text.Trim(); ;
    DataTable Dtcandidate=objBusiness_Candidate_Login.Checklogin(objEntityCandRegistr);

  
    if (Dtcandidate.Rows.Count > 0)
    {
        string strId = Dtcandidate.Rows[0]["CAND_ID"].ToString();
        int intIdLength = Dtcandidate.Rows[0]["CAND_ID"].ToString().Length;
        string stridLength = intIdLength.ToString("00");
        string Id = stridLength + strId + strRandom;

        //gen_Emply_Personal_Informn.aspx? Id = "";
        Session["USERID"] = Dtcandidate.Rows[0]["CAND_ID"].ToString();
        Session["ORGID"] = Dtcandidate.Rows[0]["ORG_ID"].ToString();
        Session["CORPOFFICEID"] = Dtcandidate.Rows[0]["CORPRT_ID"].ToString();
        Session["CANDNAME"] = Dtcandidate.Rows[0]["CAND_NAME"].ToString();

  
        Response.Redirect("/Hcm/Hcm_Master/gen_Candidate_Login/gen_Candidate_Personal_Informn.aspx?Candid=" + Id);
    }
    else
    {

        txtcandidate.Focus();
        //Response.Write("Login failed    ");Label1
        Label1.Text = "Login failed ";
    }

    }
}