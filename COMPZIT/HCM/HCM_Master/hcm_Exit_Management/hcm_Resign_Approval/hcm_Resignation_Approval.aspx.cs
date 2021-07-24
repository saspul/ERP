using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using BL_Compzit.BusinessLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HCM_HCM_Master_gen_Candidate_ShortList_gen_Candidate_ShortList : System.Web.UI.Page
{

    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Request.QueryString["RFGP"] != null)
        {
            this.MasterPageFile = "~/MasterPage/MasterPage_Modal.master";

        }
        else
        {

            this.MasterPageFile = "~/MasterPage/MasterPageCompzit_Hcm.master";
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableDMApprove = 0, intEnableReOpen = 0, intEnableHrConfirm = 0, intEnableGMApprove = 0, intEnableConfirm = 0, intEnableClose = 0;
            txtEmpReason.Enabled = false;
            
            // SponsorType_Load();
            // Country_Load();
            //int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            cls_Business_Resignation_Approval objBusinessResignApproval = new cls_Business_Resignation_Approval();
            clsEntityLayerresignationApproval ObjEntityResignApproval = new clsEntityLayerresignationApproval();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                HiddenUserId.Value = intUserId.ToString();
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            int intCorpId = 0, intOrgId = 0;
            if (Session["CORPOFFICEID"] != null)
            {

                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Resignation_Approval);
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
                        Hiddenenabledit.Value = intEnableModify.ToString(); ;
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        Hiddenenablecancl.Value = intEnableCancel.ToString(); ;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                    {
                        intEnableHrConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        HiddenHrApprove.Value = intEnableHrConfirm.ToString(); ;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.GM_Allocation).ToString())
                    {
                        intEnableGMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                    {
                        intEnableDMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        HiddenDivApprove.Value = intEnableDMApprove.ToString(); ;

                    }


                }
            }

            if (intEnableConfirm == 1)
            {
                btnAprroveDivMAnager.Visible = false;
               // txtreason.Enabled = false;
                btnAprroveGmApproval.Visible = false;
                btnAprroveHrApproval.Visible = false;
                btnAprroveReportngto.Visible = false;
                btnReject.Visible = false;

                //  divhApproval.Visible = true;
            }
            if (intEnableHrConfirm == 1)
            {
                btnAprroveDivMAnager.Visible = false;
               // txtreason.Enabled = false;
                btnAprroveGmApproval.Visible = false;
                btnAprroveHrApproval.Visible = false;
                btnAprroveReportngto.Visible = false;
                btnReject.Visible = false;

            }
            if (intEnableGMApprove == 1)
            {
                btnAprroveDivMAnager.Visible = false;
               // txtreason.Enabled = false;
                btnAprroveGmApproval.Visible = false;
                btnAprroveHrApproval.Visible = false;
                btnAprroveReportngto.Visible = false;
                btnReject.Visible = false;
            }
            
      
           
            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                //btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId);
                HiddenreqstId.Value = strId;
                lblEntry.Text = "Resignation  Approval";
                if (Request.QueryString["RFGP"] != null)
                {
                   // btnCancel.Visible = false;
                    divList.Visible = false;
                    btnAprroveDivMAnager.Visible = false;

                    btnAprroveGmApproval.Visible = false;
                    btnAprroveHrApproval.Visible = false;
                    btnAprroveReportngto.Visible = false;
                    btnReject.Visible = false;
                    txtreason.Enabled = false;
                    txtlvDate.Enabled = false;
                    Image1.Disabled = true;
                    btncancel.Visible = false;
                    btnClose.Visible = false;
                }

            }
            HiddenToday.Value = objBusinessLayer.LoadCurrentDateInString();
               // DateTime.Today.ToString();
        }
    }
    public void Update(string strP_Id)
    {
        HiddenLeaveID.Value= strP_Id;
        //btnAdd.Visible = false;
        //  btnAddClose.Visible = false;
        clsCommonLibrary objCommon = new clsCommonLibrary();

        // btnAdd.Visible = true;
        // clsentitylayeemplo objEntitySponsor = new clsEntitySponsor();
        int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableDMApprove = 0, intEnableHrConfirm = 0, intEnableGMApprove = 0, intEnableConfirm = 0, intEnableClose = 0;
        cls_Business_Resignation_Approval objBusinessResignApproval = new cls_Business_Resignation_Approval();
        clsEntityLayerresignationApproval ObjEntityResignApproval = new clsEntityLayerresignationApproval();
        if (Session["USERID"] != null)
        {
            ObjEntityResignApproval.User_Id = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityResignApproval.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityResignApproval.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //Allocating child roles
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Resignation_Approval);
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
                    Hiddenenabledit.Value = intEnableModify.ToString(); ;
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                {
                    intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    Hiddenenablecancl.Value = intEnableCancel.ToString(); ;

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                {
                    intEnableHrConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    HiddenHrApprove.Value = intEnableHrConfirm.ToString(); ;

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.GM_Allocation).ToString())
                {
                    intEnableGMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                {
                    intEnableDMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    HiddenDivApprove.Value = intEnableDMApprove.ToString(); ;

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString())
                {
                    intEnableClose = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                   // HiddenDivApprove.Value = intEnableDMApprove.ToString(); ;

                }

            }
        }

        if (intEnableConfirm == 1)
        {
            btnAprroveDivMAnager.Visible = false;

            btnAprroveGmApproval.Visible = false;
            btnAprroveHrApproval.Visible = false;
            btnAprroveReportngto.Visible = false;
            btnReject.Visible = false;

            //  divhApproval.Visible = true;
        }
        if (intEnableHrConfirm == 1)
        {
            btnAprroveDivMAnager.Visible = false;

            btnAprroveGmApproval.Visible = false;
            btnAprroveHrApproval.Visible = false;
            btnAprroveReportngto.Visible = false;
            btnReject.Visible = false;

        }
        if (intEnableGMApprove == 1)
        {
            btnAprroveDivMAnager.Visible = false;

            btnAprroveGmApproval.Visible = false;
            btnAprroveHrApproval.Visible = false;
            btnAprroveReportngto.Visible = false;
            btnReject.Visible = false;
        }

        if (intEnableClose != 1)
            btnClose.Visible = false;
        else
            btnClose.Visible = true;

      //  DataTable dtTOtallve = objBusinessResignApproval.ReadEmployeeTotalLeave(ObjEntityResignApproval);

        //   Hiddensponsorid.Value = strP_Id;
        ObjEntityResignApproval.Resignation_Id = Convert.ToInt32(strP_Id);
        DataTable dtLeaveReport = objBusinessResignApproval.ReadResignationreqByid(ObjEntityResignApproval);
        if (dtLeaveReport.Rows.Count > 0)
        {
            string ReportEmployee = dtLeaveReport.Rows[0]["REPORTEMP"].ToString();
            //   string rejectststs = dtLeaveReport.Rows[0]["LEAVE_REJECT_STATUS"].ToString();
            string status = dtLeaveReport.Rows[0]["STATUS"].ToString();
           string usrid =dtLeaveReport.Rows[0]["USR_ID"].ToString().ToUpper();
            ObjEntityResignApproval.EmployeeId = Convert.ToInt32(usrid);
            DataTable Dtemployeediv = objBusinessResignApproval.ReadEmployeeDivsn(ObjEntityResignApproval);
           // txtreason.Enabled = false;
            txtlvDate.Enabled = false;

            if (status == "APPROVAL PENDING")
            {
                btnAprroveDivMAnager.Visible = false;

                btnAprroveGmApproval.Visible = false;
                btnAprroveHrApproval.Visible = false;
                if (ReportEmployee == HiddenUserId.Value)
                {
                    btnAprroveReportngto.Visible = true;
                    btnReject.Visible = true;
                   // divHrReason.Visible = false;
                    lblRoReason.Visible = true;
                    lblDmReason.Visible = false;
                    lblHrReason.Visible = false;
                    lblGmReason.Visible = false;
                    divPrvRsn.Visible = false;
    
                }


            }
            else if (status == "REPORTING EMPLOYEE APPROVED" && intEnableDMApprove == 1)
            {
                btnAprroveDivMAnager.Visible = true;

                btnAprroveGmApproval.Visible = false;
                btnAprroveHrApproval.Visible = false;
                btnAprroveReportngto.Visible = false;
                btnReject.Visible = true;
            //    divHrReason.Visible = false;

                lblRoReason.Visible = false;
                lblDmReason.Visible = true;
                lblHrReason.Visible = false;
                lblGmReason.Visible = false;

                lblDmPrvRsn.Visible = false;
                lblHrPrvRsn.Visible = false;
                lblGmPrvRsn.Visible = false;
                lblRoPrvRsn.Visible = true;
                txtprvRsn.Enabled = false;
                txtprvRsn.Text = dtLeaveReport.Rows[0]["RSGNTN_REPRT_RSN"].ToString();  
            }

            else if (status == "DIVISION MANAGER APPROVED" && intEnableHrConfirm == 1)
            {
              //
                     btnAprroveDivMAnager.Visible = false;
                     btnAprroveGmApproval.Visible = false;
                     btnAprroveHrApproval.Visible = true;
                     btnAprroveReportngto.Visible = false;
                     btnReject.Visible = true;
                     lblRoReason.Visible = false;
                     lblDmReason.Visible = false;
                     lblHrReason.Visible = true;
                     lblGmReason.Visible = false;


                     lblDmPrvRsn.Visible = true;
                     lblHrPrvRsn.Visible = false;
                     lblGmPrvRsn.Visible = false;
                     lblRoPrvRsn.Visible = false;
                     txtprvRsn.Enabled = false;
                     txtprvRsn.Text = dtLeaveReport.Rows[0]["RSGNTN_DM_REASON"].ToString();  
                 //    divHrReason.Visible = true;

              //  txtreason.Enabled = true;
                txtlvDate.Enabled = true;

                ScriptManager.RegisterStartupScript(this, GetType(), "enableimg", "enableimg();", true);


            }


            else if (status == "HR APPROVED" && intEnableGMApprove == 1)
            {
                btnAprroveDivMAnager.Visible = false;
                btnAprroveHrApproval.Text = "HR Approve";
                btnAprroveGmApproval.Visible = true;
                btnAprroveHrApproval.Visible = false;
                btnAprroveReportngto.Visible = false;
                btnReject.Visible = true;
             //   txtreason.Enabled = false;
                txtlvDate.Enabled = false;
             //   divHrReason.Visible = true;
                lblRoReason.Visible = false;
                lblDmReason.Visible = false;
                lblHrReason.Visible = false;
                lblGmReason.Visible = true;
                lblDmPrvRsn.Visible = false;
                lblHrPrvRsn.Visible = true;
                lblGmPrvRsn.Visible = false;
                lblRoPrvRsn.Visible = false;
                txtprvRsn.Enabled = false;
                txtprvRsn.Text = dtLeaveReport.Rows[0]["RSGNTN_HR_REASON"].ToString();  
            }
            else if (status == "GM APPROVED" && intEnableHrConfirm == 1)
            {
                HiddenApprovedbyHr.Value = "1";
                btnAprroveHrApproval.Text = "Final HR Approve";
                btnAprroveDivMAnager.Visible = false;

                btnAprroveGmApproval.Visible = false;
                btnAprroveHrApproval.Visible = true;
                btnAprroveReportngto.Visible = false;
                btnReject.Visible = true;
                lblRoReason.Visible = false;
                lblDmReason.Visible = false;
                lblHrReason.Visible = true;
                lblGmReason.Visible = false;
                txtprvRsn.Enabled = false;
                lblDmPrvRsn.Visible = false;
                lblHrPrvRsn.Visible = false;
                lblGmPrvRsn.Visible = true;
                lblRoPrvRsn.Visible = false;
               // divHrReason.Visible = true;
                txtprvRsn.Text = dtLeaveReport.Rows[0]["RSGNTN_GM_REASON"].ToString(); 
            }
           
            else
            {
                btnAprroveDivMAnager.Visible = false;

                btnAprroveGmApproval.Visible = false;
                btnAprroveHrApproval.Visible = false;
                btnAprroveReportngto.Visible = false;
                btnReject.Visible = false;
                divComment.Visible = false;


            }
           if (status == "Rejected")
            {
                btnAprroveDivMAnager.Visible = false;

                btnAprroveGmApproval.Visible = false;
                btnAprroveHrApproval.Visible = false;
                btnAprroveReportngto.Visible = false;
                btnReject.Visible = false;


            }
        
            if (dtLeaveReport.Rows.Count > 0)
            {
                lblEmpname.Text = dtLeaveReport.Rows[0]["USR_NAME"].ToString().ToUpper();
                lblDesig.Text = dtLeaveReport.Rows[0]["DSGN_NAME"].ToString().ToUpper();
                  lblDep.Text = dtLeaveReport.Rows[0]["CPRDEPT_NAME"].ToString().ToUpper();
                for (int i=0; i < Dtemployeediv.Rows.Count;i++)
                {
                    if(i==0)
                    lblDiv.Text = Dtemployeediv.Rows[i]["DIVISION"].ToString().ToUpper();
                    else
                        lblDiv.Text = lblDiv.Text + ", " + Dtemployeediv.Rows[i]["DIVISION"].ToString().ToUpper();

                }
             //   lblDiv.Text = dtLeaveReport.Rows[0]["CPRDEPT_NAME"].ToString().ToUpper();
                LblPaygrd.Text = dtLeaveReport.Rows[0]["PYGRD_NAME"].ToString().ToUpper();
                lbllPreflvedte.Text = dtLeaveReport.Rows[0]["PRFRDDATE"].ToString().ToUpper();
                lblNotcprd.Text = dtLeaveReport.Rows[0]["NTCPRD_DAYS"].ToString().ToUpper();
                LblJoindte.Text = dtLeaveReport.Rows[0]["EMPERDTL_JOIN_DATE"].ToString().ToUpper();
               // txtreason.Text = dtLeaveReport.Rows[0]["RSGNTN_HR_REASON"].ToString();  emp 25
                txtlvDate.Text= dtLeaveReport.Rows[0]["RSGNTN_HR_PRFRD_DATE"].ToString().ToUpper();
                txtEmpReason.Text = dtLeaveReport.Rows[0]["RSGNTN_USR_REASON"].ToString();
            }
            ObjEntityResignApproval.Resignation_Id = Convert.ToInt32(strP_Id);                  
            }

    }
   
    protected void Btnsave_Click(object sender, EventArgs e)
    {
        
        
    }
    
    protected void btnAdd_Click(object sender, EventArgs e)
    {
     
       


    }
    protected void btnCnfrm_Click(object sender, EventArgs e)
    {
      
    }
   
    public void save()
    {
       
    }

    protected void btnAprroveReportngto_Click(object sender, EventArgs e)
    {
        cls_Business_Resignation_Approval objBusinessResignApproval = new cls_Business_Resignation_Approval();
        clsEntityLayerresignationApproval ObjEntityResignApproval = new clsEntityLayerresignationApproval();
       
        ObjEntityResignApproval.Requeststatus = 2;
        ObjEntityResignApproval.Date = DateTime.Today;
        ObjEntityResignApproval.User_Id = Convert.ToInt32(HiddenUserId.Value);
        ObjEntityResignApproval.Resignation_Id = Convert.ToInt32(HiddenLeaveID.Value);

        ObjEntityResignApproval.RoReason = txtreason.Text;
        objBusinessResignApproval.ReprtingEmploy_Approve(ObjEntityResignApproval);

     //   objBusinessResignApproval.Reject(ObjEntityResignApproval);

        Response.Redirect("hcm_Resignation_Approval_List.aspx?InsUpd=ApprovedRep");

        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessApproved", "SuccessApproved();", true);

    }

    protected void btnAprroveDivMAnager_Click(object sender, EventArgs e)
    {
        cls_Business_Resignation_Approval objBusinessResignApproval = new cls_Business_Resignation_Approval();
        clsEntityLayerresignationApproval ObjEntityResignApproval = new clsEntityLayerresignationApproval();
       
        ObjEntityResignApproval.Requeststatus = 3;
        ObjEntityResignApproval.Date = DateTime.Today;
        ObjEntityResignApproval.Resignation_Id = Convert.ToInt32(HiddenLeaveID.Value);

        ObjEntityResignApproval.User_Id = Convert.ToInt32(HiddenUserId.Value);
        ObjEntityResignApproval.DmReason = txtreason.Text;
        objBusinessResignApproval.DivsionManagerApproval(ObjEntityResignApproval);
        ObjEntityResignApproval.ApprovalStatus = 0;
      //  objBusinessResignApproval.Reject(ObjEntityResignApproval);
        Response.Redirect("hcm_Resignation_Approval_List.aspx?InsUpd=ApprovedDivmanager");      
    }

    protected void btnAprroveHrApproval_Click(object sender, EventArgs e)
    {
         cls_Business_Resignation_Approval objBusinessResignApproval = new cls_Business_Resignation_Approval();
        clsEntityLayerresignationApproval ObjEntityResignApproval = new clsEntityLayerresignationApproval();
        clsCommonLibrary objCommonLibrary = new clsCommonLibrary();
        
        if (HiddenApprovedbyHr.Value == "1")
        {
            ObjEntityResignApproval.SearchField = "FinalHr";
            ObjEntityResignApproval.Requeststatus = 6;
            ObjEntityResignApproval.CancelReason = txtreason.Text;
        }
        else
        {
            ObjEntityResignApproval.Requeststatus = 4;
            ObjEntityResignApproval.ResignationToDate = objCommonLibrary.textToDateTime(txtlvDate.Text);
            ObjEntityResignApproval.CancelReason = txtreason.Text;
        }
        ObjEntityResignApproval.Date = DateTime.Today;
        ObjEntityResignApproval.User_Id = Convert.ToInt32(HiddenUserId.Value);
        ObjEntityResignApproval.Resignation_Id = Convert.ToInt32(HiddenLeaveID.Value);

        objBusinessResignApproval.Hr_Approve(ObjEntityResignApproval);
        ObjEntityResignApproval.ApprovalStatus = 0;
      //  objBusinessResignApproval.Reject(ObjEntityResignApproval);
        HiddenApprovedbyHr.Value = "1";
        Response.Redirect("hcm_Resignation_Approval_List.aspx?InsUpd=ApprovedHr");

        ScriptManager.RegisterStartupScript(this, GetType(), "ApprovedHr", "ApprovedHr();", true);

    }

    protected void btnAprroveGmApproval_Click(object sender, EventArgs e)
    {

        cls_Business_Resignation_Approval objBusinessResignApproval = new cls_Business_Resignation_Approval();
        clsEntityLayerresignationApproval ObjEntityResignApproval = new clsEntityLayerresignationApproval();
  
        ObjEntityResignApproval.Requeststatus = 5;
        ObjEntityResignApproval.Date = DateTime.Today;
        ObjEntityResignApproval.User_Id = Convert.ToInt32(HiddenUserId.Value);
        ObjEntityResignApproval.Resignation_Id = Convert.ToInt32(HiddenLeaveID.Value);

        ObjEntityResignApproval.GmReason = txtreason.Text;
        objBusinessResignApproval.Gm_Approve(ObjEntityResignApproval);

       // objBusinessResignApproval.Reject(ObjEntityResignApproval);
        Response.Redirect("hcm_Resignation_Approval_List.aspx?InsUpd=ApprovedGm");

        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessApproved", "SuccessApproved();", true);

    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
     //   hiddenRsnid.Value = HiddenLeaveID.Value;
        cls_Business_Resignation_Approval objBusinessResignApproval = new cls_Business_Resignation_Approval();
        clsEntityLayerresignationApproval ObjEntityResignApproval = new clsEntityLayerresignationApproval();

        ObjEntityResignApproval.Requeststatus = 7;
        ObjEntityResignApproval.Date = DateTime.Today;
        ObjEntityResignApproval.User_Id = Convert.ToInt32(HiddenUserId.Value);
        ObjEntityResignApproval.Resignation_Id = Convert.ToInt32(HiddenLeaveID.Value);
       // ObjEntityResignApproval.CancelReason =txtreason
     //  ScriptManager.RegisterStartupScript(this, GetType(), "OpenCancelView", "return OpenCancelView();", true);

     objBusinessResignApproval.Reject(ObjEntityResignApproval);
        Response.Redirect("hcm_Resignation_Approval_List.aspx?InsUpd=Rejected");

        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessRejected", "SuccessRejected();", true);

        
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        cls_Business_Resignation_Approval objBusinessResignApproval = new cls_Business_Resignation_Approval();
        clsEntityLayerresignationApproval ObjEntityResignApproval = new clsEntityLayerresignationApproval();

        ObjEntityResignApproval.Requeststatus = 8;
        ObjEntityResignApproval.Date = DateTime.Today;
        ObjEntityResignApproval.User_Id = Convert.ToInt32(HiddenUserId.Value);
        ObjEntityResignApproval.Resignation_Id = Convert.ToInt32(HiddenLeaveID.Value);

        objBusinessResignApproval.Close(ObjEntityResignApproval);
        Response.Redirect("hcm_Resignation_Approval_List.aspx?InsUpd=Close");
    

    }

    protected void btnRsnSave_Click(object sender, EventArgs e)
    {
        cls_Business_Resignation_Approval objBusinessResignApproval = new cls_Business_Resignation_Approval();
        clsEntityLayerresignationApproval ObjEntityResignApproval = new clsEntityLayerresignationApproval();
   
        ObjEntityResignApproval.Requeststatus =7;
        ObjEntityResignApproval.Date = DateTime.Today;
        ObjEntityResignApproval.User_Id = Convert.ToInt32(HiddenUserId.Value);
        ObjEntityResignApproval.Resignation_Id = Convert.ToInt32(HiddenLeaveID.Value);
        //  ScriptManager.RegisterStartupScript(this, GetType(), "OpenCancelView", "return OpenCancelView();", true);
        ObjEntityResignApproval.CancelReason = hiddenRsnid.Value;
      //  objBusinessResignApproval.Reject(ObjEntityResignApproval);
        Response.Redirect("hcm_Resignation_Approval_List.aspx?InsUpd=Rejected");

        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessRejected", "SuccessRejected();", true);


    }
}