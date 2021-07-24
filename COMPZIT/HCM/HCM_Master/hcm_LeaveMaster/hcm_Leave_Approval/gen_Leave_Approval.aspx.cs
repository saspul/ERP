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
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_AWMS;
using System.Globalization;

public partial class HCM_HCM_Master_gen_Candidate_ShortList_gen_Candidate_ShortList : System.Web.UI.Page
{
    public static DateTime dtCurrDate = new DateTime();
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
            chktiktneeded.Enabled = false;
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableDMApprove = 0, intEnableReOpen = 0, intEnableHrConfirm = 0, intEnableGMApprove = 0, intEnableConfirm = 0, intEnableClose = 0;
            divhApproval.Visible = true;

            // SponsorType_Load();
            // Country_Load();
            //int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            cls_Business_Leave_Approval objBusinessLeaveApproval = new cls_Business_Leave_Approval();
            clsEntityLayerLeaveApproval ObjEntityLeaveApproval = new clsEntityLayerLeaveApproval();
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

            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
            dtCurrDate = objCommon.textToDateTime(strCurrentDate);


            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.HCM_STAFF_LEAVE_APROVAL);

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

                        //   HiddenDivApprove.Value = intEnableDMApprove.ToString(); ;
                        btnClose.Visible = false;
                    }

                }
            }

            if (intEnableConfirm == 1)
            {
                btnAprroveDivMAnager.Visible = false;
                lblDmAprove.Visible = false;
                lblDmNote.Visible = false;
                btnAprroveGmApproval.Visible = false;
                lblGmAprove.Visible = false;
                lblGmNote.Visible = false;
                btnAprroveHrApproval.Visible = false;
                lblHrAprove.Visible = false;
                lblHrNote.Visible = false;
                btnAprroveReportngto.Visible = false;
                lblRoAprove.Visible = false;
                lblRoNote.Visible = false;
                btnReject.Visible = false;
                divhApproval.Visible = true;
            }
            if (intEnableHrConfirm == 1)
            {
                btnAprroveDivMAnager.Visible = false;
                lblDmAprove.Visible = false;
                lblDmNote.Visible = false;
                btnAprroveGmApproval.Visible = false;
                lblGmAprove.Visible = false;
                lblGmNote.Visible = false;
                btnAprroveHrApproval.Visible = false;
                lblHrAprove.Visible = false;
                lblHrNote.Visible = false;
                btnAprroveReportngto.Visible = false;
                lblRoNote.Visible = false;
                lblRoAprove.Visible = false;
                btnReject.Visible = false;
                divhApproval.Visible = false;
            }
            if (intEnableGMApprove == 1)
            {
                btnAprroveDivMAnager.Visible = false;
                lblDmAprove.Visible = false;
                lblDmNote.Visible = false;
                btnAprroveGmApproval.Visible = false;
                lblGmAprove.Visible = false;
                lblGmNote.Visible = false;
                btnAprroveHrApproval.Visible = false;
                lblHrAprove.Visible = false;
                lblHrNote.Visible = false;
                btnAprroveReportngto.Visible = false;
                lblRoNote.Visible = false;
                lblRoAprove.Visible = false;
                btnReject.Visible = false;
                divhApproval.Visible = false;

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
                lblEntry.Text = "Leave  Approval";
                if (Request.QueryString["RFGP"] != null)
                {
                    btncancel.Visible = false;
                    divList.Visible = false;
                    btnClose.Visible = false;
                    btnReject.Visible = false;
                    btnAprroveReportngto.Visible = false;
                    lblRoNote.Visible = false;
                    lblRoAprove.Visible = false;
                    lbladdr.Enabled = false;
                    chktiktneeded.Enabled = false;
                    txthrnote.Enabled = false;
                    lblHrAprove.Visible = true;
                    lblHrNote.Visible = true;
                    divhApproval.Visible = true;
                }

            }

        }
    }


    public void Update(string strP_Id)
    {
        HiddenLeaveID.Value = strP_Id;
        //btnAdd.Visible = false;
        //  btnAddClose.Visible = false;
        clsCommonLibrary objCommon = new clsCommonLibrary();

        // btnAdd.Visible = true;
        // clsentitylayeemplo objEntitySponsor = new clsEntitySponsor();
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableDMApprove = 0, intEnableHrConfirm = 0, intEnableGMApprove = 0, intEnableConfirm = 0, intEnableClose = 0;
        cls_Business_Leave_Approval objBusinessLeaveApproval = new cls_Business_Leave_Approval();
        clsEntityLayerLeaveApproval ObjEntityLeaveApproval = new clsEntityLayerLeaveApproval();
        if (Session["USERID"] != null)
        {
            ObjEntityLeaveApproval.User_Id = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityLeaveApproval.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityLeaveApproval.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //Allocating child roles
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.HCM_STAFF_LEAVE_APROVAL);
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

                }

            }
        }

        if (intEnableConfirm == 1)
        {
            btnAprroveDivMAnager.Visible = false;


            btnAprroveGmApproval.Visible = false;
            lblGmAprove.Visible = false;
            //evm-0027 09-02-2019
            lblDmAprove.Visible = true;
            lblDmNote.Visible = true;
            lblGmNote.Visible = true;
            lblHrAprove.Visible = true;
            lblHrNote.Visible = true;
            lblHrAprove.Visible = true;
            lblHrNote.Visible = true;
            btnAprroveReportngto.Visible = false;
            lblRoNote.Visible = false;
            //eND
            btnAprroveHrApproval.Visible = false;

            lblRoAprove.Visible = false;
            btnReject.Visible = false;
            divhApproval.Visible = true;

        }
        if (intEnableHrConfirm == 1)
        {
            btnAprroveDivMAnager.Visible = false;
            lblDmAprove.Visible = false;
            lblDmNote.Visible = false;
            btnAprroveGmApproval.Visible = false;
            lblGmAprove.Visible = false;
            lblGmNote.Visible = false;
            btnAprroveHrApproval.Visible = false;
            lblHrAprove.Visible = false;
            lblHrNote.Visible = false;
            btnAprroveReportngto.Visible = false;
            lblRoNote.Visible = false;
            lblRoAprove.Visible = false;
            btnReject.Visible = false;
            divhApproval.Visible = true;

        }
        if (intEnableGMApprove == 1)
        {
            btnAprroveDivMAnager.Visible = false;
            lblDmAprove.Visible = false;
            lblDmNote.Visible = false;
            btnAprroveGmApproval.Visible = false;
            lblGmAprove.Visible = false;
            lblGmNote.Visible = false;
            btnAprroveHrApproval.Visible = false;
            lblHrAprove.Visible = false;
            lblHrNote.Visible = false;
            btnAprroveReportngto.Visible = false;
            lblRoNote.Visible = false;
            lblRoAprove.Visible = false;
            btnReject.Visible = false;
            divhApproval.Visible = true;
        }


        //To check leave id rejoin table
        clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
        clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
        objEntLevAllocn.LeavAllocn = Convert.ToInt32(strP_Id);
        DataTable dtRejoin = objBusLevAllocn.ReadRejoin(objEntLevAllocn);


        if (intEnableClose != 1)
            btnClose.Visible = false;
        else
        {
            btnClose.Visible = true;

        }
        if (dtRejoin.Rows.Count > 0)
        {
            btnClose.Visible = false;
        }

        DataTable dtTOtallve = objBusinessLeaveApproval.ReadEmployeeTotalLeave(ObjEntityLeaveApproval);

        //   Hiddensponsorid.Value = strP_Id;
        ObjEntityLeaveApproval.Leave_Id = Convert.ToInt32(strP_Id);
        DataTable dtLeaveReport = objBusinessLeaveApproval.ReadLeavallocndtlByid(ObjEntityLeaveApproval);
        if (dtLeaveReport.Rows.Count > 0)
        {
            string rejectststs = dtLeaveReport.Rows[0]["LEAVE_REJECT_STATUS"].ToString();
            string status = dtLeaveReport.Rows[0]["LEAVE_RQST_STATUS"].ToString();
            string cnfrmstatus = dtLeaveReport.Rows[0]["LEAVE_REPORT_EMP_APPROVAL"].ToString();
            string ReportEmployee = dtLeaveReport.Rows[0]["REPORTEMP"].ToString();
            string TicketNeeded = dtLeaveReport.Rows[0]["LEAVE_NEED_TRVL_TCKT"].ToString();
            string closedstatus = dtLeaveReport.Rows[0]["LEAVE_RQST_STATUS"].ToString();
            string CLSDUSRID = dtLeaveReport.Rows[0]["LEAVE_CLS_USR_ID"].ToString();
            //EVM-0027 11-02-2019
            if (dtLeaveReport.Rows[0]["LEAVE_REPORT_EMP_COMMENT"].ToString() != "")
            {
                txtPvRO_Note.Visible = true;
                txtPvRO_Note.Text = dtLeaveReport.Rows[0]["LEAVE_REPORT_EMP_COMMENT"].ToString();
                txtPvRO_Note.Enabled = false;
                lblPrvRo.Visible = true;
            }
            else
            {
                txtPvRO_Note.Visible = false;
                lblPrvRo.Visible = false;
            }
            if (dtLeaveReport.Rows[0]["LEAVE_DM_COMMENT"].ToString() != "")
            {
                txtPvDM_Note.Visible = true;
                txtPvDM_Note.Text = dtLeaveReport.Rows[0]["LEAVE_DM_COMMENT"].ToString();
                txtPvDM_Note.Enabled = false;
                lblPrvDm.Visible = true;
            }
            else
            {
                txtPvDM_Note.Visible = false;
                lblPrvDm.Visible = false;
            }
            if (dtLeaveReport.Rows[0]["LEAVE_GM_COMMENT"].ToString() != "")
            {
                txtprevNote.Visible = true;
                txtprevNote.Text = dtLeaveReport.Rows[0]["LEAVE_GM_COMMENT"].ToString();
                txtprevNote.Enabled = false;
                lblPrvGm.Visible = true;
            }
            else
            {
                txtprevNote.Visible = false;
                lblPrvGm.Visible = false;
            }

            //txtPvDM_Note.Enabled = false;
            //END
            if (TicketNeeded == "1")
            {
                chktiktneeded.Enabled = false;
                chktiktneeded.Checked = true;
            }
            string TravelNeeded = dtLeaveReport.Rows[0]["LEAVETYPDTLS_TRVLNEED"].ToString();
            if (TravelNeeded == "1")
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowTravalNeededDiv", "ShowTravalNeededDiv();", true);

            if (CLSDUSRID != "")
            {
                if (closedstatus == "6")
                {
                    btnClose.Visible = false;
                }
            }
            if (status == "0")
            {
                btnAprroveDivMAnager.Visible = false;
                lblDmAprove.Visible = false;
                lblDmNote.Visible = false;
                btnAprroveGmApproval.Visible = false;
                lblGmAprove.Visible = false;
                //evm-0027
                lblGmNote.Visible = false;
                //end
                btnAprroveHrApproval.Visible = false;
                divhApproval.Visible = false;
                lblHrAprove.Visible = false;
                lblHrNote.Visible = false;

                if (ReportEmployee == HiddenUserId.Value)
                {
                    btnAprroveReportngto.Visible = true;
                    lblRoAprove.Visible = true;
                    lblRoNote.Visible = true;
                    btnReject.Visible = true;
                    divhApproval.Visible = true;
                    divApprovalPrevNote.Visible = false;
                }


            }
            else if (status == "1" && intEnableDMApprove == 1)
            {
                btnAprroveDivMAnager.Visible = true;
                lblDmAprove.Visible = true;
                lblDmNote.Visible = true;
                btnAprroveGmApproval.Visible = false;
                lblGmAprove.Visible = false;
                lblGmNote.Visible = false;
                btnAprroveHrApproval.Visible = false;
                lblHrAprove.Visible = false;
                lblHrNote.Visible = false;
                btnAprroveReportngto.Visible = false;
                //EVm-0027 09-02-2019
                lblRoNote.Visible = false;
                // lblRoNote.Text = dtLeaveReport.Rows[0]["LEAVE_REPORT_EMP_COMMENT"].ToString();
                lblRoNote.Enabled = false;
                //lblPrvRo.Visible = true;
                lblPrvGm.Visible = false;
                lblPrvDm.Visible = false;
                //END
                lblRoAprove.Visible = false;
                btnReject.Visible = true;




                txtprevNote.Enabled = false;
                txtprevNote.Text = dtLeaveReport.Rows[0]["LEAVE_REPORT_EMP_COMMENT"].ToString();
            }

            else if (status == "2" && intEnableGMApprove == 1)
            {
                if (TravelNeeded == "1")
                {
                    btnAprroveDivMAnager.Visible = false;
                    lblDmAprove.Visible = false;


                    //EVM-0027
                    lblRoNote.Visible = false;
                    // lblRoNote.Text = dtLeaveReport.Rows[0]["LEAVE_REPORT_EMP_COMMENT"].ToString();
                    lblRoNote.Enabled = false;
                    lblDmNote.Visible = false;
                    // lblDmNote.Text = dtLeaveReport.Rows[0]["LEAVE_DM_COMMENT"].ToString();
                    lblDmNote.Enabled = false;
                    // lblRoNote.Visible = false;
                    //  lblPrvRo.Visible = false;
                    lblPrvGm.Visible = false;
                    //END
                    btnAprroveGmApproval.Visible = true;
                    lblGmAprove.Visible = true;
                    lblGmNote.Visible = true;
                    btnAprroveHrApproval.Visible = false;
                    lblHrAprove.Visible = false;
                    lblHrNote.Visible = false;
                    btnAprroveReportngto.Visible = false;
                    lblRoAprove.Visible = false;

                    btnReject.Visible = true;


                    lblPrvDm.Visible = true;

                    txtprevNote.Enabled = false;
                    txtprevNote.Text = dtLeaveReport.Rows[0]["LEAVE_DM_COMMENT"].ToString();
                }
                else
                {
                    if (status == "2" && intEnableHrConfirm == 1)
                    {
                        btnAprroveDivMAnager.Visible = false;
                        lblDmAprove.Visible = false;
                        //evm-0027 
                        lblDmNote.Visible = false;
                        lblRoNote.Visible = false;
                        divApprovalPrevNote.Visible = true;
                        //end
                        btnAprroveGmApproval.Visible = false;
                        lblGmAprove.Visible = false;
                        lblGmNote.Visible = true;
                        btnAprroveHrApproval.Visible = true;

                        lblHrAprove.Visible = true;
                        lblHrNote.Visible = true;
                        btnAprroveReportngto.Visible = false;
                        lblRoAprove.Visible = false;

                        btnReject.Visible = true;


                    }


                }

            }
            else if (status == "3" && intEnableHrConfirm == 1)
            {
                btnAprroveDivMAnager.Visible = false;
                lblDmAprove.Visible = false;
                //  lblDmNote.Visible = false;
                btnAprroveGmApproval.Visible = false;
                lblGmAprove.Visible = false;
                lblGmNote.Visible = false;
                btnAprroveHrApproval.Visible = true;
                lblHrAprove.Visible = true;
                lblHrNote.Visible = true;
                btnAprroveReportngto.Visible = false;
                lblRoAprove.Visible = false;
                //EVM-0027
                // lblRoNote.Visible = true;
                //  lblRoNote.Text = dtLeaveReport.Rows[0]["LEAVE_REPORT_EMP_COMMENT"].ToString();
                lblRoNote.Enabled = false;
                lblDmNote.Visible = false;
                // lblDmNote.Text = dtLeaveReport.Rows[0]["LEAVE_DM_COMMENT"].ToString();
                lblDmNote.Enabled = false;
                // lblPrvRo.Visible = false;
                // lblPrvDm.Visible = false;
                //END
                btnReject.Visible = true;



                lblPrvGm.Visible = true;




                txtprevNote.Enabled = false;
                txtprevNote.Text = dtLeaveReport.Rows[0]["LEAVE_GM_COMMENT"].ToString();
            }
            else
            {
                btnAprroveDivMAnager.Visible = false;
                lblDmAprove.Visible = false;
                lblDmNote.Visible = false;
                btnAprroveGmApproval.Visible = false;
                lblGmAprove.Visible = false;
                lblGmNote.Visible = false;
                btnAprroveHrApproval.Visible = false;
                lblHrAprove.Visible = true;
                lblHrNote.Visible = true;
                txthrnote.Enabled = false;
                btnAprroveReportngto.Visible = false;
                lblRoAprove.Visible = false;
                //evm-0027 11-02-2019
                lblRoNote.Visible = true;
                // lblRoNote.Text = dtLeaveReport.Rows[0]["LEAVE_REPORT_EMP_COMMENT"].ToString();
                lblRoNote.Visible = true;
                //end
                btnReject.Visible = false;
                divhApproval.Visible = false;//EVM-0024
                divApprovalPrevNote.Visible = false;
            }
            if (rejectststs == "1")
            {
                btnAprroveDivMAnager.Visible = false;
                lblDmAprove.Visible = false;
                //evm-0027 11-2-2019
                lblDmNote.Visible = false;
                lblDmNote.Text = dtLeaveReport.Rows[0]["LEAVE_DM_COMMENT"].ToString();
                lblDmNote.Enabled = false;
                //end
                btnAprroveGmApproval.Visible = false;
                lblGmAprove.Visible = false;
                lblGmNote.Visible = false;
                btnAprroveHrApproval.Visible = false;
                lblHrAprove.Visible = false;
                lblHrNote.Visible = false;
                btnAprroveReportngto.Visible = false;
                lblRoAprove.Visible = false;
                lblRoNote.Visible = true;
                btnReject.Visible = false;
                divhApproval.Visible = false;//EVM-0024
            }

            if (dtLeaveReport.Rows.Count > 0)
            {
                lblEmpname.Text = dtLeaveReport.Rows[0]["Employee"].ToString().ToUpper();

                //  lblEntry.Text = dtLeaveReport.Rows[0]["LEAVE_INS_DATE"].ToString().ToUpper();
                DateTime todate = new DateTime(), fromdate = new DateTime();
                if (dtLeaveReport.Rows[0]["Date To"].ToString() != "")
                    todate = objCommon.textToDateTime(dtLeaveReport.Rows[0]["Date To"].ToString().ToUpper());
                if (dtLeaveReport.Rows[0]["Date From"].ToString() != "")
                    fromdate = objCommon.textToDateTime(dtLeaveReport.Rows[0]["Date From"].ToString().ToUpper());
                int Leavetype = 0;
                if (dtLeaveReport.Rows[0]["LEAVETYP_ID"].ToString() != "")
                    Leavetype = Convert.ToInt32(dtLeaveReport.Rows[0]["LEAVETYP_ID"].ToString().ToUpper());
                ObjEntityLeaveApproval.Leave_Id = Leavetype;
                DataTable dtremaininglve = objBusinessLeaveApproval.ReadOPeningLeav(ObjEntityLeaveApproval);
                ObjEntityLeaveApproval.EmployeeId = Convert.ToInt32(dtLeaveReport.Rows[0]["USR_ID"].ToString().ToUpper());
                dtTOtallve = objBusinessLeaveApproval.ReadEmployeeTotalLeave(ObjEntityLeaveApproval);

                DataTable dtLastleave = objBusinessLeaveApproval.ReadEmployeelastleave(ObjEntityLeaveApproval);


                if (fromdate < dtCurrDate)
                {
                    btnClose.Visible = false;
                }
                //if(dtLastleave.Rows.Count>0)
                //{

                //    if (dtLastleave.Rows[0]["LASTLEAVETO"].ToString().ToUpper() != "")
                //        lbllastleave.Text = dtLeaveReport.Rows[0]["Date_From"].ToString().ToUpper() + " - " + dtLeaveReport.Rows[0]["Date_To"].ToString().ToUpper();
                //    else

                //        lbllastleave.Text = dtLeaveReport.Rows[0]["Date_From"].ToString().ToUpper();

                //}
                //  lbllastleave.Text = dtLastleave.Rows[0]["Date_From"].ToString().ToUpper()+"  " + dtLastleave.Rows[0]["Date_To"].ToString().ToUpper();

                if (dtLeaveReport.Rows[0]["LEAVE_FROM_SCTN"].ToString() == "1")
                {
                    lblSectn.Text = "Full Day";


                }
                else if (dtLeaveReport.Rows[0]["LEAVE_FROM_SCTN"].ToString() == "2")
                {
                    lblSectn.Text = "First Section";


                }
                else if (dtLeaveReport.Rows[0]["LEAVE_FROM_SCTN"].ToString() == "3")
                {
                    lblSectn.Text = "Second Section";


                }
                if (dtLeaveReport.Rows[0]["LEAVE_TO_SCTN"].ToString() == "1")
                {
                    LblSectionto.Text = "Full Day";


                }
                else if (dtLeaveReport.Rows[0]["LEAVE_TO_SCTN"].ToString() == "2")
                {
                    LblSectionto.Text = "First Section";


                }
                else if (dtLeaveReport.Rows[0]["LEAVE_TO_SCTN"].ToString() == "3")
                {
                    LblSectionto.Text = "Second Section";


                }

                //  if (dtLeaveReport.Rows[0]["Date To"].ToString() != "")
                //  lbltotdays.Text = (todate - fromdate).ToString("dd");
                //    else
                lbltotdays.Text = dtLeaveReport.Rows[0]["LEAVE_NUM_DAYS"].ToString();
                lblFrmDate.Text = dtLeaveReport.Rows[0]["Date From"].ToString().ToUpper();

                lblLeaveType.Text = dtLeaveReport.Rows[0]["Leave Type"].ToString().ToUpper();
                if (dtremaininglve.Rows.Count > 0)
                {
                    lbllNoleavetypeleave.Text = dtremaininglve.Rows[0]["LEAVETYP_NUMDAYS"].ToString().ToUpper();
                }
                //LblSectionto.Text = dtLeaveReport.Rows[0]["MNP_EXPERIENCE"].ToString()+" Years";
                TotalNooflv.Text = dtTOtallve.Rows[0]["LEAVE_NUM_DAYS"].ToString().ToUpper();
                LblTodate.Text = dtLeaveReport.Rows[0]["Date To"].ToString().ToUpper();
                lblDesc.Text = dtLeaveReport.Rows[0]["LEAVE_RQST_DESC"].ToString().ToUpper();
                lbldateoftravl.Text = dtLeaveReport.Rows[0]["LEAVE_DATEOF_TRVL"].ToString().ToUpper();

                lbldestination.Text = dtLeaveReport.Rows[0]["LEAVE_DESTINTN"].ToString().ToUpper();
                lbldateofret.Text = dtLeaveReport.Rows[0]["LEAVE_DATEOF_RETRN"].ToString().ToUpper();
                lblairlinepref.Text = dtLeaveReport.Rows[0]["LEAVE_AIRLINE_PRFRD"].ToString().ToUpper();
                lbladdr.Text = dtLeaveReport.Rows[0]["LEAVE_CNTCT_ADDRS"].ToString().ToUpper();
                lblrelph.Text = dtLeaveReport.Rows[0]["LEAVE_CNTCT_TEL_NO"].ToString().ToUpper();
                lblloccontatc.Text = dtLeaveReport.Rows[0]["LEAVE_LCL_CNTCT_NO"].ToString().ToUpper();
                txthrnote.Text = dtLeaveReport.Rows[0]["LEAVE_HR_COMMENT"].ToString().ToUpper();

                lblemail.Text = dtLeaveReport.Rows[0]["LEAVE_EMAIL"].ToString();
                if (dtLeaveReport.Rows[0]["LASTLEAVETO"].ToString().ToUpper() != "")
                    lbllastleave.Text = dtLeaveReport.Rows[0]["LASTLEAVEFROM"].ToString().ToUpper() + " - " + dtLeaveReport.Rows[0]["LASTLEAVETO"].ToString().ToUpper();
                else

                    lbllastleave.Text = dtLeaveReport.Rows[0]["LASTLEAVEFROM"].ToString().ToUpper();


            }

            //    DataTable dtLeaveReportcandidates =  objBusinessLeaveApproval.ReadLeavallocndtlBySearch(ObjEntityLeaveApproval);
            //DataTable dtLeaveReportedcandidatelist = objBusinesscandidateShrtlist.ReadSelected_Candidates(ObjEntityLeaveApproval);
            string strHtm = ConvertDataTableToHTMLLeaveType(dtTOtallve);
            //Write to divReport
            divReport.InnerHtml = strHtm;
            ObjEntityLeaveApproval.Leave_Id = Convert.ToInt32(strP_Id);

            dtTOtallve = objBusinessLeaveApproval.ReadEmployeeDependent(ObjEntityLeaveApproval);

            string strHtm1 = ConvertDataTableToHTMLDependent(dtTOtallve);
            //Write to divReport
            divreportDependent.InnerHtml = strHtm1;


        }
        //evm-0023 Remove Buttons From View
        if (Request.QueryString["RFGP"] != null)
        {
            divhApproval.Visible = true;
            btnAprroveDivMAnager.Visible = false;
            lblDmAprove.Visible = false;
            lblDmNote.Visible = false;
            btnAprroveGmApproval.Visible = false;
            lblGmAprove.Visible = false;
            lblGmNote.Visible = false;
            btnAprroveHrApproval.Visible = false;
            lblHrAprove.Visible = false;
            lblHrNote.Visible = false;
        }

    }
    public string ConvertDataTableToHTMLLeaveType(DataTable dt)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        int intimgsection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
        // intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.CANDIDATE_SHORTLIST);
        string imgpath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        int shortlistcount = 0;
        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">SL#</th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">TYPE NAME</th>";
            }

            else if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">COUNT</th>";
            }



        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        hiddenRowCount.Value = dt.Rows.Count.ToString();
        strHtml += "<tbody>";
        int count = 1, flag = 0;
        double listcount = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            count = intRowBodyCount + 1;
            strHtml += "<tr  >";
            listcount = listcount + Convert.ToDouble(dt.Rows[intRowBodyCount]["LEAVE_NUM_DAYS"].ToString());

            flag = 0;





            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            string reference = "";
            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count + "</a> </td>";

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 0)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["LEAVETYP_NAME"].ToString() + "</a> </td>";
                }
                else if (intColumnBodyCount == 1)
                {
                    double listcount1 = 0;
                    if (dt.Rows[intRowBodyCount]["LEAVE_NUM_DAYS"].ToString() != "")
                    {
                        listcount1 = listcount1 + Convert.ToDouble(dt.Rows[intRowBodyCount]["LEAVE_NUM_DAYS"].ToString());
                    }
                    listcount1 = Math.Abs(listcount1);
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + listcount1 + "</td>";
                }



            }
            strHtml += "<td id=\"tdcandiateid" + intRowBodyCount + "\"  class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount][0].ToString() + "</td>";


            strHtml += "</tr>";

        }
        strHtml += "<tr>";
        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";

        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >Total</td>";
        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + listcount + "</td>";
        TotalNooflv.Text = listcount.ToString();


        strHtml += "</tr>";
        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    public string ConvertDataTableToHTMLDependent(DataTable dt)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        int intimgsection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
        // intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.CANDIDATE_SHORTLIST);
        string imgpath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        int shortlistcount = 0;
        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">SL#</th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\"> NAME</th>";
            }

            else if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">RELATION</th>";
            }



        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        hiddenRowCount.Value = dt.Rows.Count.ToString();
        double listcount = 0;
        strHtml += "<tbody>";
        int count = 1, flag = 0;
        if (dt.Rows.Count == 0)
        {
            strHtml += "<tr  >";
            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" > </td>";

            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >NO DATA AVAILABLE</a> </td>";
            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" > </td>";

            strHtml += "</tr>";
        }
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            count = intRowBodyCount + 1;
            strHtml += "<tr  >";
            flag = 0;





            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            string reference = "";
            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count + "</a> </td>";

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 0)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPDPNT_NAME"].ToString() + "</a> </td>";
                }
                else if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["RELATE_NAME"].ToString() + "</td>";
                }



            }
            strHtml += "<td id=\"tdcandiateid" + intRowBodyCount + "\"  class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount][0].ToString() + "</td>";


            strHtml += "</tr>";

        }
        strHtml += "<tr>";

        strHtml += "</tr>";
        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
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
        cls_Business_Leave_Approval objBusinessLeaveApproval = new cls_Business_Leave_Approval();
        clsEntityLayerLeaveApproval ObjEntityLeaveApproval = new clsEntityLayerLeaveApproval();
        ObjEntityLeaveApproval.ApprovalStatus = 1;
        ObjEntityLeaveApproval.Requeststatus = 1;
        ObjEntityLeaveApproval.Date = DateTime.Today;
        ObjEntityLeaveApproval.User_Id = Convert.ToInt32(HiddenUserId.Value);
        ObjEntityLeaveApproval.Leave_Id = Convert.ToInt32(HiddenLeaveID.Value);
        ObjEntityLeaveApproval.RoComment = txthrnote.Text;

        objBusinessLeaveApproval.ReprtingEmploy_Approve(ObjEntityLeaveApproval);

        //  ObjEntityLeaveApproval.ApprovalStatus = 0;
        // objBusinessLeaveApproval.Reject(ObjEntityLeaveApproval);   EMP25

        Response.Redirect("gen_Leave_Approval_List.aspx?InsUpd=ApprovedRep");

        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessApproved", "SuccessApproved();", true);

    }

    protected void btnAprroveDivMAnager_Click(object sender, EventArgs e)
    {
        cls_Business_Leave_Approval objBusinessLeaveApproval = new cls_Business_Leave_Approval();
        clsEntityLayerLeaveApproval ObjEntityLeaveApproval = new clsEntityLayerLeaveApproval();
        ObjEntityLeaveApproval.ApprovalStatus = 1;
        ObjEntityLeaveApproval.Requeststatus = 2;
        ObjEntityLeaveApproval.Date = DateTime.Today;
        ObjEntityLeaveApproval.Leave_Id = Convert.ToInt32(HiddenLeaveID.Value);

        ObjEntityLeaveApproval.User_Id = Convert.ToInt32(HiddenUserId.Value);
        ObjEntityLeaveApproval.DmComment = txthrnote.Text;
        objBusinessLeaveApproval.DivsionManagerApproval(ObjEntityLeaveApproval);
        ObjEntityLeaveApproval.ApprovalStatus = 0;
        // objBusinessLeaveApproval.Reject(ObjEntityLeaveApproval); EMP25

        Response.Redirect("gen_Leave_Approval_List.aspx?InsUpd=ApprovedDivmanager");

        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessApproved", "SuccessApproved();", true);

    }

    protected void btnAprroveHrApproval_Click(object sender, EventArgs e)
    {
        cls_Business_Leave_Approval objBusinessLeaveApproval = new cls_Business_Leave_Approval();
        clsEntityLayerLeaveApproval ObjEntityLeaveApproval = new clsEntityLayerLeaveApproval();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        ObjEntityLeaveApproval.ApprovalStatus = 1;
        ObjEntityLeaveApproval.Requeststatus = 4;
        ObjEntityLeaveApproval.Date = DateTime.Today;
        ObjEntityLeaveApproval.User_Id = Convert.ToInt32(HiddenUserId.Value);
        ObjEntityLeaveApproval.Leave_Id = Convert.ToInt32(HiddenLeaveID.Value);
        ObjEntityLeaveApproval.HrComment = txthrnote.Text;
        objBusinessLeaveApproval.Hr_Approve(ObjEntityLeaveApproval);

        if (Request.QueryString["Id"] != null)
        {

            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);

            ObjEntityLeaveApproval.Leave_Id = Convert.ToInt32(strId);
            DataTable dtLevDetails = objBusinessLeaveApproval.ReadLeaveRqstById(ObjEntityLeaveApproval);
            DataTable dtLeav = new DataTable();
            ObjEntityLeaveApproval.Leave_Id = Convert.ToInt32(dtLevDetails.Rows[0]["LEAVETYP_ID"].ToString());
            ObjEntityLeaveApproval.User_Id = Convert.ToInt32(dtLevDetails.Rows[0]["USR_ID"].ToString());

            string strremLeav = "";
            string strbalLeav = "";
            string strlvType = "";
            decimal NumofLeav = 0, RemLeave = 0;
            string strchkuserlevCount = "0";


            if (dtLevDetails.Rows.Count > 0)
            {
                if (dtLevDetails.Rows[0]["LEAVE_RQST_STATUS"].ToString() == "4")
                {

                    ObjEntityLeaveApproval.LeaveFrmDate = objCommon.textToDateTime(dtLevDetails.Rows[0]["LEAVE_FROM_DATE"].ToString());
                    strbalLeav = dtLevDetails.Rows[0]["LEAVE_NUM_DAYS"].ToString();
                    strchkuserlevCount = objBusinessLeaveApproval.chkUserLevCount(ObjEntityLeaveApproval);
                    DataTable dataDt = objBusinessLeaveApproval.ReadRemLeav(ObjEntityLeaveApproval);
                    if (dataDt.Rows.Count > 0)
                    {
                        strlvType = dataDt.Rows[0]["LEAVETYP_ID"].ToString();
                        strremLeav = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                        NumofLeav = Convert.ToDecimal(strbalLeav);
                        RemLeave = Convert.ToDecimal(strremLeav);
                        RemLeave = RemLeave - NumofLeav;
                        ObjEntityLeaveApproval.RemingLev = RemLeave;
                        ObjEntityLeaveApproval.OpeningLv = Convert.ToDecimal(dataDt.Rows[0]["OPENING_NUMLEAVE"]);
                        ObjEntityLeaveApproval.Leave_Id = Convert.ToInt32(strlvType);
                    }
                    if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                    {

                        objBusinessLeaveApproval.InsertUserLeavTyp(ObjEntityLeaveApproval);
                    }
                    else
                    {
                        objBusinessLeaveApproval.InsertUserNewLevRow(ObjEntityLeaveApproval);
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
                    clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
                    clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
                    objEntityLeavSettlmt.CorpId = intCorpId;
                    DataTable dtCorpSal = objBusinessLeavSettlmt.ReadCorpSal(objEntityLeavSettlmt);
                    int BasicPayStatus = Convert.ToInt32(dtCorpSal.Rows[0]["BASIC_PAY"].ToString());
                    DateTime dtTodate = new DateTime();
                    if (dtLevDetails.Rows[0]["LEAVE_TO_DATE"].ToString() != "" && dtLevDetails.Rows[0]["LEAVE_TO_DATE"].ToString() != null)
                    {
                        dtTodate = objCommon.textToDateTime(dtLevDetails.Rows[0]["LEAVE_TO_DATE"].ToString());
                    }




                    int intLeave_from_sctn = 0;
                    if (dtLevDetails.Rows[0]["LEAVE_FROM_SCTN"].ToString() != "")
                    {
                        intLeave_from_sctn = Convert.ToInt32(dtLevDetails.Rows[0]["LEAVE_FROM_SCTN"].ToString());
                    }


                  


                    //Leave allocation

                    clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
                    clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();



                    if (dtLevDetails.Rows[0]["LEAVE_TO_DATE"].ToString() != "")
                    {
                        ObjEntityLeaveApproval.LeaveToDate = objCommon.textToDateTime(dtLevDetails.Rows[0]["LEAVE_TO_DATE"].ToString());
                    }
                    if (dtLevDetails.Rows[0]["LEAVE_TO_SCTN"].ToString() != "")
                    {
                        ObjEntityLeaveApproval.LeaveToSection = Convert.ToInt32(dtLevDetails.Rows[0]["LEAVE_TO_SCTN"].ToString());
                    }
               
                    
                   



                    objEntLevAllocn.Corporate_id = intCorpId;
                    objEntLevAllocn.EmployeeId = ObjEntityLeaveApproval.User_Id;
                    objEntLevAllocn.Leave_Id = ObjEntityLeaveApproval.Leave_Id;
                    objEntLevAllocn.LeaveFrmDate = ObjEntityLeaveApproval.LeaveFrmDate;
                    objEntLevAllocn.LeaveFromSection = intLeave_from_sctn;
                    objEntLevAllocn.LeaveToDate = ObjEntityLeaveApproval.LeaveToDate;
                    objEntLevAllocn.LeaveToSection = ObjEntityLeaveApproval.LeaveToSection;

                    objEntLevAllocn.NumOfLeave = Convert.ToDecimal(NumofLeav);
                    objEntLevAllocn.Organisation_id = intOrgId;
                    objEntLevAllocn.User_Id = Convert.ToInt32(HiddenUserId.Value);
                    //objEntLevAllocn.PaidLvStatus = 0;

                    if (dtLevDetails.Rows[0]["LEAVE_SETTLEMNT_STATUS"].ToString() != "")
                    {
                        objEntLevAllocn.PaidLvStatus = Convert.ToInt32(dtLevDetails.Rows[0]["LEAVE_SETTLEMNT_STATUS"].ToString());
                    }

                    //NEED MODIFICATION
                    objEntLevAllocn.EilgiblLeaveAlloctnSts = 0;

                    objEntLevAllocn.DailyLeaveStatus = 0;


                    objEntLevAllocn.LeaveRequestID = Convert.ToInt32(strId);

                    objBusLevAllocn.AddLeavAlloctnDetails(objEntLevAllocn);

                    objEntLevAllocn.LeaveConfmn = 1;

                    objBusLevAllocn.ConfirmLeavAllocnDtl(objEntLevAllocn);
                    //Leave allocation ends

                    ArrearAmountUpd(Convert.ToInt32(dtLevDetails.Rows[0]["USR_ID"].ToString()), Convert.ToInt32(strId), ObjEntityLeaveApproval.Leave_Id, intCorpId, intOrgId, objCommon.textToDateTime(dtLevDetails.Rows[0]["LEAVE_FROM_DATE"].ToString()), dtTodate, Convert.ToInt32(dtLevDetails.Rows[0]["LEAVE_FROM_SCTN"].ToString()), intLeave_from_sctn, BasicPayStatus, dtCorpSal.Rows[0]["FIXED_PAYRL_MODE_JOIN"].ToString(), dtLevDetails.Rows[0]["EMPERDTL_JOIN_DATE"].ToString());


                }
            }
        }

        ObjEntityLeaveApproval.ApprovalStatus = 0;
        //  objBusinessLeaveApproval.Reject(ObjEntityLeaveApproval);

        Response.Redirect("gen_Leave_Approval_List.aspx?InsUpd=ApprovedHr");

        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessApproved", "SuccessApproved();", true);

    }
    public void ArrearAmountUpd(int UerId, int LeaveId, int LeaveTypId, int CorpId, int OrgId, DateTime dtFrom, DateTime dtTo, int FromSec, int ToSec, int BasicPaySts, string FixedPayrlSts, string joinDate)
    {
        int joinMnthSts = 0;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusiness_Leave_Type objBusinessLeavetype = new clsBusiness_Leave_Type();
        clsEntity_Leave_Type ObjEntityLeaveType = new clsEntity_Leave_Type();
        ObjEntityLeaveType.intleave = LeaveTypId;
        DataTable dtLeaveTypDetail = objBusinessLeavetype.ReadLeavedetailsById(ObjEntityLeaveType);
        decimal cnt1 = 0, cnt2 = 0;
        int DaysMnth1 = 0, DaysMnth2 = 0;
        if (dtLeaveTypDetail.Rows.Count > 0 && dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_PAIDLEAVE"].ToString() == "0")
        {
            DateTime dtLastStl = new DateTime();
            DateTime dtFinal = new DateTime();

            cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
            cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
            objEnt.Employee = UerId;
            DataTable dtLeavMonth1 = objBuss.ReadMonthlyLastDate(objEnt);
            if (dtLeavMonth1.Rows.Count > 0)
            {
                if (dtLeavMonth1.Rows[0]["SLPRCDMNTH_LST_SETTLD_DT"].ToString() != "")
                {
                    dtFinal = objCommon.textToDateTime(dtLeavMonth1.Rows[0]["SLPRCDMNTH_LST_SETTLD_DT"].ToString());
                    if (FixedPayrlSts == "1")
                    {
                        DateTime dtJoin = objCommon.textToDateTime(joinDate);
                        if (dtJoin.Month == dtFinal.Month && dtFinal.Year == dtJoin.Year)
                        {
                            if (dtJoin.Day > 1)
                            {
                                joinMnthSts = 1;
                            }
                        }
                    }
                }
            }
            DataTable dtLeavMonth11 = objBuss.ReadLastLeaveStlDate(objEnt);
            if (dtLeavMonth11.Rows.Count > 0)
            {
                for (int i = 0; i < dtLeavMonth11.Rows.Count; i++)
                {
                    if (dtLeavMonth11.Rows[i]["LEVSETLMT_LST_SETLMTDATE"].ToString() != "" && dtLeavMonth11.Rows[i][1].ToString() == "0")
                    {
                        dtLastStl = objCommon.textToDateTime(dtLeavMonth11.Rows[i]["LEVSETLMT_LST_SETLMTDATE"].ToString());
                        if (dtLastStl > dtFinal)
                        {
                            dtFinal = dtLastStl;
                            joinMnthSts = 0;
                        }
                    }
                }
            }
            if (dtFinal != DateTime.MinValue)
            {

                clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
                clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
                objEntityLeavSettlmt.UserId = UerId;
                objEntityLeavSettlmt.EmployeeId = UerId;
                objEntityLeavSettlmt.DateStartDate = dtFrom;
                objEntityLeavSettlmt.DateEndDate = dtTo;
                DataTable dtLeaveDate = objBusinessLeavSettlmt.ReadLeaveDate(objEntityLeavSettlmt);



                cls_Business_Monthly_Salary_Process objBuss2 = new cls_Business_Monthly_Salary_Process();
                cls_Entity_Monthly_Salary_Process objEnt2 = new cls_Entity_Monthly_Salary_Process();
                objEnt2.Employee = UerId;
                objEnt2.DateStartDate = dtFinal.AddDays(1);
                objEnt2.DateEndDate = new DateTime(dtFinal.Year, 12, 31);
                objEnt2.CorpOffice = CorpId;
                objEnt2.Orgid = OrgId;
                DataTable dtLeaveDateFuture = new DataTable();
                if (objEnt2.DateStartDate.Year == objEnt2.DateEndDate.Year)
                {
                    dtLeaveDateFuture = objBuss2.ReadLeaveDate(objEnt2);
                }
                decimal FutureLeaveCnt = calcFutureLeaveCnt(LeaveTypId.ToString(), dtLeaveDateFuture, objEnt2);



                for (int lcnt = 0; lcnt < dtLeaveDate.Rows.Count; lcnt++)
                {
                    if (dtLeaveDate.Rows[lcnt]["LEAVE_ID"].ToString() == LeaveId.ToString())
                    {
                        int HoliPaidSts = Convert.ToInt32(dtLeaveDate.Rows[lcnt]["LEAVETYP_HOLIDAY_PAID_STS"].ToString());
                        int OffPaidSts = Convert.ToInt32(dtLeaveDate.Rows[lcnt]["LEAVETYP_OFFDAY_PAID_STS"].ToString());


                        decimal OpenLeaveCnt = Convert.ToDecimal(dtLeaveDate.Rows[lcnt]["OPENING_NUMLEAVE"].ToString());
                        decimal BalanceLeaveCnt = Convert.ToDecimal(dtLeaveDate.Rows[lcnt]["BALANCE_NUMLEAVE"].ToString()) + FutureLeaveCnt;
                        decimal LeaveDays = Convert.ToDecimal(dtLeaveDate.Rows[lcnt]["LEAVE_NUM_DAYS"].ToString());

                        dutyOf objDuty = new dutyOf();
                        int OffCount = 0;

                        if (dtFrom != DateTime.MinValue && dtTo != DateTime.MinValue && dtFrom <= dtFinal)
                        {
                            if (dtFrom <= dtFinal && dtTo <= dtFinal)
                            {
                                int MonthDiff = (dtTo.Year * 12 + dtTo.Month) - (dtFrom.Year * 12 + dtFrom.Month);
                                if (MonthDiff == 1)
                                {
                                    DaysMnth1 = DateTime.DaysInMonth(dtTo.Year, dtTo.Month);
                                    DaysMnth2 = DateTime.DaysInMonth(dtFrom.Year, dtFrom.Month);

                                    DateTime dtNewFrom = new DateTime(dtTo.Year, dtTo.Month, 1);
                                    cnt1 = Convert.ToInt32((dtTo - dtNewFrom).TotalDays) + 1;
                                    if (ToSec != 1)
                                    {
                                        cnt1 = cnt1 - (decimal)0.5;
                                    }
                                    DateTime datenow, enddate;
                                    datenow = dtNewFrom;
                                    enddate = dtTo;
                                    if (HoliPaidSts == 1 || OffPaidSts == 1)
                                    {
                                        for (var day = datenow; day <= enddate; day = day.AddDays(1))
                                        {
                                            string hol = "false";
                                            if (HoliPaidSts == 1)
                                            {
                                                hol = objDuty.checkholiday(day, datenow, enddate);
                                                if (hol == "true")
                                                {
                                                    OffCount = OffCount + 1;
                                                }
                                            }
                                            if (OffPaidSts == 1 && hol != "true")
                                            {
                                                string off = objDuty.CheckDutyOff(day, objEnt2.CorpOffice.ToString(), objEnt2.Orgid.ToString());
                                                if (off == "true")
                                                {
                                                    OffCount = OffCount + 1;
                                                }
                                            }
                                        }
                                    }
                                    cnt1 = cnt1 - OffCount;
                                    if (cnt1 < 0)
                                    {
                                        cnt1 = 0;
                                    }



                                    DateTime dtNewTo = dtNewFrom.AddDays(-1);
                                    cnt2 = Convert.ToInt32((dtNewTo - dtFrom).TotalDays) + 1;
                                    if (FromSec != 1)
                                    {
                                        cnt2 = cnt2 - (decimal)0.5;
                                    }
                                    datenow = dtFrom;
                                    enddate = dtNewTo;
                                    OffCount = 0;
                                    if (HoliPaidSts == 1 || OffPaidSts == 1)
                                    {
                                        for (var day = datenow; day <= enddate; day = day.AddDays(1))
                                        {
                                            string hol = "false";
                                            if (HoliPaidSts == 1)
                                            {
                                                hol = objDuty.checkholiday(day, datenow, enddate);
                                                if (hol == "true")
                                                {
                                                    OffCount = OffCount + 1;
                                                }
                                            }
                                            if (OffPaidSts == 1 && hol != "true")
                                            {
                                                string off = objDuty.CheckDutyOff(day, objEnt2.CorpOffice.ToString(), objEnt2.Orgid.ToString());
                                                if (off == "true")
                                                {
                                                    OffCount = OffCount + 1;
                                                }
                                            }
                                        }
                                    }
                                    cnt2 = cnt2 - OffCount;
                                    if (cnt2 < 0)
                                    {
                                        cnt2 = 0;
                                    }


                                }
                                else
                                {
                                    DaysMnth1 = DateTime.DaysInMonth(dtTo.Year, dtTo.Month);

                                    cnt1 = Convert.ToInt32((dtTo - dtFrom).TotalDays) + 1;
                                    if (FromSec != 1)
                                    {
                                        cnt1 = cnt1 - (decimal)0.5;
                                    }
                                    if (ToSec != 1)
                                    {
                                        cnt1 = cnt1 - (decimal)0.5;
                                    }
                                    DateTime datenow, enddate;
                                    datenow = dtFrom;
                                    enddate = dtTo;
                                    if (HoliPaidSts == 1 || OffPaidSts == 1)
                                    {
                                        for (var day = datenow; day <= enddate; day = day.AddDays(1))
                                        {
                                            string hol = "false";
                                            if (HoliPaidSts == 1)
                                            {
                                                hol = objDuty.checkholiday(day, datenow, enddate);
                                                if (hol == "true")
                                                {
                                                    OffCount = OffCount + 1;
                                                }
                                            }
                                            if (OffPaidSts == 1 && hol != "true")
                                            {
                                                string off = objDuty.CheckDutyOff(day, objEnt2.CorpOffice.ToString(), objEnt2.Orgid.ToString());
                                                if (off == "true")
                                                {
                                                    OffCount = OffCount + 1;
                                                }
                                            }
                                        }
                                    }
                                    cnt1 = cnt1 - OffCount;
                                    if (cnt1 < 0)
                                    {
                                        cnt1 = 0;
                                    }
                                }
                            }
                            else
                            {

                                int MonthDiff = (dtFinal.Year * 12 + dtFinal.Month) - (dtFrom.Year * 12 + dtFrom.Month);
                                if (MonthDiff == 1)
                                {
                                    DaysMnth1 = DateTime.DaysInMonth(dtFinal.Year, dtFinal.Month);
                                    DaysMnth2 = DateTime.DaysInMonth(dtFrom.Year, dtFrom.Month);


                                    DateTime dtNewFrom = new DateTime(dtFinal.Year, dtFinal.Month, 1);
                                    cnt1 = Convert.ToInt32((dtFinal - dtNewFrom).TotalDays) + 1;

                                    DateTime datenow, enddate;
                                    datenow = dtNewFrom;
                                    enddate = dtFinal;
                                    if (HoliPaidSts == 1 || OffPaidSts == 1)
                                    {
                                        for (var day = datenow; day <= enddate; day = day.AddDays(1))
                                        {
                                            string hol = "false";
                                            if (HoliPaidSts == 1)
                                            {
                                                hol = objDuty.checkholiday(day, datenow, enddate);
                                                if (hol == "true")
                                                {
                                                    OffCount = OffCount + 1;
                                                }
                                            }
                                            if (OffPaidSts == 1 && hol != "true")
                                            {
                                                string off = objDuty.CheckDutyOff(day, objEnt2.CorpOffice.ToString(), objEnt2.Orgid.ToString());
                                                if (off == "true")
                                                {
                                                    OffCount = OffCount + 1;
                                                }
                                            }
                                        }
                                    }
                                    cnt1 = cnt1 - OffCount;
                                    if (cnt1 < 0)
                                    {
                                        cnt1 = 0;
                                    }

                                    DateTime dtNewTo = dtNewFrom.AddDays(-1);
                                    cnt2 = Convert.ToInt32((dtNewTo - dtFrom).TotalDays) + 1;
                                    if (FromSec != 1)
                                    {
                                        cnt2 = cnt2 - (decimal)0.5;
                                    }
                                    datenow = dtFrom;
                                    enddate = dtNewTo;
                                    OffCount = 0;
                                    if (HoliPaidSts == 1 || OffPaidSts == 1)
                                    {
                                        for (var day = datenow; day <= enddate; day = day.AddDays(1))
                                        {
                                            string hol = "false";
                                            if (HoliPaidSts == 1)
                                            {
                                                hol = objDuty.checkholiday(day, datenow, enddate);
                                                if (hol == "true")
                                                {
                                                    OffCount = OffCount + 1;
                                                }
                                            }
                                            if (OffPaidSts == 1 && hol != "true")
                                            {
                                                string off = objDuty.CheckDutyOff(day, objEnt2.CorpOffice.ToString(), objEnt2.Orgid.ToString());
                                                if (off == "true")
                                                {
                                                    OffCount = OffCount + 1;
                                                }
                                            }
                                        }
                                    }
                                    cnt2 = cnt2 - OffCount;
                                    if (cnt2 < 0)
                                    {
                                        cnt2 = 0;
                                    }
                                }
                                else
                                {
                                    DaysMnth1 = DateTime.DaysInMonth(dtFinal.Year, dtFinal.Month);

                                    cnt1 = Convert.ToInt32((dtFinal - dtFrom).TotalDays) + 1;
                                    if (FromSec != 1)
                                    {
                                        cnt1 = cnt1 - (decimal)0.5;
                                    }
                                    DateTime datenow, enddate;
                                    datenow = dtFrom;
                                    enddate = dtFinal;
                                    if (HoliPaidSts == 1 || OffPaidSts == 1)
                                    {
                                        for (var day = datenow; day <= enddate; day = day.AddDays(1))
                                        {
                                            string hol = "false";
                                            if (HoliPaidSts == 1)
                                            {
                                                hol = objDuty.checkholiday(day, datenow, enddate);
                                                if (hol == "true")
                                                {
                                                    OffCount = OffCount + 1;
                                                }
                                            }
                                            if (OffPaidSts == 1 && hol != "true")
                                            {
                                                string off = objDuty.CheckDutyOff(day, objEnt2.CorpOffice.ToString(), objEnt2.Orgid.ToString());
                                                if (off == "true")
                                                {
                                                    OffCount = OffCount + 1;
                                                }
                                            }
                                        }
                                    }
                                    cnt1 = cnt1 - OffCount;
                                    if (cnt1 < 0)
                                    {
                                        cnt1 = 0;
                                    }
                                }
                            }
                        }
                        else if (dtFrom != DateTime.MinValue && dtTo == DateTime.MinValue && dtFrom <= dtFinal)
                        {
                            DaysMnth1 = DateTime.DaysInMonth(dtFrom.Year, dtFrom.Month);
                            if (FromSec == 1)
                            {
                                cnt1 = 1;
                            }
                            else
                            {
                                cnt1 = (decimal)0.5;
                            }
                        }
                        if (BalanceLeaveCnt < 0)
                        {
                            BalanceLeaveCnt = BalanceLeaveCnt * -1;
                            if (BalanceLeaveCnt >= (cnt2 + cnt1))
                            {
                            }
                            else
                            {
                                if (BalanceLeaveCnt <= cnt1)
                                {
                                    cnt1 = BalanceLeaveCnt;
                                    cnt2 = 0;
                                }
                                else
                                {
                                    cnt2 = BalanceLeaveCnt - cnt1;
                                    if (cnt2 < 0)
                                    {
                                        cnt2 = 0;
                                    }
                                }
                            }
                        }
                        else
                        {
                            cnt1 = 0;
                            cnt2 = 0;
                        }
                    }
                }


                if (cnt1 > 0)
                {
                    decimal TotalAmnt = 0;
                    decimal decBasisPayMnth = 0;
                    decimal decAllownc = 0;
                    decimal deciDeduction = 0;
                    DataTable dtBasic = objBusinessLeavSettlmt.ReadBasicPay(objEntityLeavSettlmt);
                    if (dtBasic.Rows.Count > 0)
                    {
                        if (dtBasic.Rows[0]["SLRY_BASIC_PAY"].ToString() != "")
                        {
                            decBasisPayMnth = Convert.ToDecimal(dtBasic.Rows[0]["SLRY_BASIC_PAY"].ToString());
                        }
                    }
                    DataTable dtAllownce = objBusinessLeavSettlmt.ReadAllowance(objEntityLeavSettlmt);
                    DataTable dtDeductn = objBusinessLeavSettlmt.ReadDeduction(objEntityLeavSettlmt);
                    //Addition calculation      
                    for (int intRowCount = 0; intRowCount < dtAllownce.Rows.Count; intRowCount++)
                    {
                        decimal DecAlwancAmt = 0;
                        if (dtAllownce.Rows[intRowCount]["SLRYALLCE_AMOUNT"].ToString() != "")
                        {
                            if (dtAllownce.Rows[intRowCount]["PAYRL_TYPE_STS"].ToString() == "0" && joinMnthSts == 0)//Fixed Allowance
                            {
                            }
                            else//Variable Allowance
                            {
                                DecAlwancAmt = Convert.ToDecimal(dtAllownce.Rows[intRowCount]["SLRYALLCE_AMOUNT"].ToString());
                                if (DaysMnth2 > 0)
                                {
                                    DecAlwancAmt = ((DecAlwancAmt / DaysMnth1) * cnt1) + ((DecAlwancAmt / DaysMnth2) * cnt2);
                                }
                                else
                                {
                                    DecAlwancAmt = ((DecAlwancAmt / DaysMnth1) * cnt1);
                                }
                            }
                        }
                        decAllownc += DecAlwancAmt;
                    }
                    //deduction amount      
                    for (int intRowCount = 0; intRowCount < dtDeductn.Rows.Count; intRowCount++)
                    {
                        decimal DecDeduction = 0, DecDeductionbasicPay = 0, DecDeductionTotlPay = 0;
                        if (dtDeductn.Rows[intRowCount]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString() == "0")//Amount deduction
                        {
                            if (dtDeductn.Rows[intRowCount]["SLRYDEDTN_AMOUNT"].ToString() != "")
                            {
                                if (dtDeductn.Rows[intRowCount]["PAYRL_TYPE_STS"].ToString() == "0"  && joinMnthSts == 0)//Fixed deduction
                                {
                                }
                                else//Variable deduction
                                {
                                    DecDeduction = Convert.ToDecimal(dtDeductn.Rows[intRowCount]["SLRYDEDTN_AMOUNT"].ToString());
                                    if (DaysMnth2 > 0)
                                    {
                                        DecDeduction = ((DecDeduction / DaysMnth1) * cnt1) + ((DecDeduction / DaysMnth2) * cnt2);
                                    }
                                    else
                                    {
                                        DecDeduction = ((DecDeduction / DaysMnth1) * cnt1);
                                    }
                                }
                            }
                        }
                        else if (dtDeductn.Rows[intRowCount]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString() == "1")//Percentage deduction
                        {
                            if (dtDeductn.Rows[intRowCount]["SLRYDEDTN_BASIC_OR_TOTAL_AMNT"].ToString() == "0") //basic pay deductn
                            {
                                if (dtDeductn.Rows[intRowCount]["PAYRL_TYPE_STS"].ToString() == "0" && joinMnthSts == 0)//Fixed deduction
                                {
                                }
                                else //variable deduction
                                {
                                    DecDeductionbasicPay = Convert.ToDecimal(dtDeductn.Rows[intRowCount]["SLRYDEDTN_PERCNTGE"].ToString());
                                    DecDeductionbasicPay = decBasisPayMnth * (DecDeductionbasicPay / 100);
                                    if (DaysMnth2 > 0)
                                    {
                                        DecDeductionbasicPay = ((DecDeductionbasicPay / DaysMnth1) * cnt1) + ((DecDeductionbasicPay / DaysMnth2) * cnt2);
                                    }
                                    else
                                    {
                                        DecDeductionbasicPay = ((DecDeductionbasicPay / DaysMnth1) * cnt1);
                                    }
                                }
                            }
                            else if (dtDeductn.Rows[intRowCount]["SLRYDEDTN_BASIC_OR_TOTAL_AMNT"].ToString() == "1") //total pay deductn
                            {
                                if (dtDeductn.Rows[intRowCount]["PAYRL_TYPE_STS"].ToString() == "0" && joinMnthSts == 0)//Fixed deduction
                                {
                                }
                                else//Variable deduction
                                {
                                    DecDeductionTotlPay = Convert.ToDecimal(dtDeductn.Rows[intRowCount]["SLRYDEDTN_PERCNTGE"].ToString());
                                    DecDeductionTotlPay = (decBasisPayMnth + decAllownc) * (DecDeductionTotlPay / 100);
                                    if (DaysMnth2 > 0)
                                    {
                                        DecDeductionTotlPay = ((DecDeductionTotlPay / DaysMnth1) * cnt1) + ((DecDeductionTotlPay / DaysMnth2) * cnt2);
                                    }
                                    else
                                    {
                                        DecDeductionTotlPay = ((DecDeductionTotlPay / DaysMnth1) * cnt1);
                                    }
                                }
                            }
                        }
                        deciDeduction += DecDeduction + DecDeductionbasicPay + DecDeductionTotlPay;
                    }
                    if (BasicPaySts == 0 && joinMnthSts==0)
                    {
                        decBasisPayMnth = 0;
                    }
                    else
                    {
                        if (DaysMnth2 > 0)
                        {
                            decBasisPayMnth = ((decBasisPayMnth / DaysMnth1) * cnt1) + ((decBasisPayMnth / DaysMnth2) * cnt2);
                        }
                        else
                        {
                            decBasisPayMnth = ((decBasisPayMnth / DaysMnth1) * cnt1);
                        }
                    }
                    TotalAmnt = decBasisPayMnth + decAllownc + deciDeduction;
                    if (TotalAmnt > 0)
                    {

                        clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
                        clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
                        objEntLevAllocn.Leave_Id = LeaveId;
                        objEntLevAllocn.User_Id = UerId;
                        objEntLevAllocn.NumOfLeave = TotalAmnt;
                        objBusLevAllocn.InsLeaveArrearAmnt(objEntLevAllocn);
                    }
                }
            }
        }
    }
    public class dutyOf
    {

        public static string GetWeekOfMonth(DateTime date)
        {

            DateTime beginningOfMonth = new DateTime(date.Year, date.Month, 1);

            //while (date.Date.AddDays(1).DayOfWeek != CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)

            //    date = date.AddDays(1);
            while (date.Date.AddDays(1).DayOfWeek != CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)

                date = date.AddDays(1);

            int weekNumber = (int)Math.Truncate((double)date.Subtract(beginningOfMonth).TotalDays / 7f) + 1;

            string[] weeks = { "first", "second", "third", "fourth", "fifth", "sixth" };

            return weeks[weekNumber - 1];

        }
        public string CheckDutyOff(DateTime dateCheck, string orgid, string corpid)
        {

            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
            clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
            objEntLevAllocn.Organisation_id = Convert.ToInt32(orgid);
            objEntLevAllocn.Corporate_id = Convert.ToInt32(corpid);
            //FOR READING DUTY OFF
            DataTable dtDutyOffWeekly = objBusLevAllocn.ReadWeeklyDutyOff(objEntLevAllocn);
            string strJbWklyOffDay = "";
            if (dtDutyOffWeekly.Rows.Count > 0)
            {
                string DutyOffDays = dtDutyOffWeekly.Rows[0]["WK_OFFDUTYDTL_DAYS"].ToString();
                string[] DutyOffDay = DutyOffDays.Split(',');
                foreach (string DutyOfwk in DutyOffDay)
                {
                    switch (DutyOfwk)
                    {
                        case "1":
                            strJbWklyOffDay += "Sunday";
                            break;
                        case "2":
                            strJbWklyOffDay += "Monday";
                            break;
                        case "3":
                            strJbWklyOffDay += "Tuesday";
                            break;
                        case "4":
                            strJbWklyOffDay += "Wednesday";
                            break;
                        case "5":
                            strJbWklyOffDay += "Thursday";
                            break;
                        case "6":
                            strJbWklyOffDay += "Friday";
                            break;
                        case "7":
                            strJbWklyOffDay += "Saturday";
                            break;

                    }
                }
            }

            List<DateTime> MonthlyOffDates = new List<DateTime>();

            //for date and month section
            string strTodayDate = dtCurrDate.ToString("dd/MM/yyyy");

            DateTime DateTodayDate = new DateTime();
            DateTodayDate = objCommon.textToDateTime(strTodayDate);

            DateTime now = new DateTime();

            //now = objCommon.textToDateTime(hiddenFirstDate.Value);
            now = dateCheck.Date;
            now = objCommon.textToDateTime(now.ToString("dd/MM/yyyy"));
            string wkoff = GetWeekOfMonth(now.Date);

            DataTable dtDutyOffMonthly = objBusLevAllocn.ReadMonthlyDutyOff(objEntLevAllocn);
            if (dtDutyOffMonthly.Rows.Count > 0)
            {

                DateTime leaveDate = new DateTime();

                foreach (DataRow Rowd in dtDutyOffMonthly.Rows)
                {
                    if (Rowd["OFFDUTYDTL_DAYS"].ToString() != "")
                    {
                        int firstdate = 0;

                        if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "1")
                        {
                            for (int i = 0; i <= 2; i++)
                            {
                                if (i == 0)
                                {
                                    firstdate = 1;
                                }
                                else if (i == 1)
                                {
                                    firstdate = 15;
                                }
                                else if (i == 2)
                                {
                                    firstdate = 28;
                                }

                                string DaysStr = Rowd["OFFDUTYDTL_DAYS"].ToString();
                                string[] spitDayStr = DaysStr.Split(',');
                                foreach (string strSpliSlice in spitDayStr)
                                {
                                    if (strSpliSlice != "")
                                    {
                                        switch (strSpliSlice)
                                        {
                                            case "2":
                                                DateTime FirstMonday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstMonday.DayOfWeek == DayOfWeek.Monday)
                                                    {
                                                        leaveDate = FirstMonday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstMonday = FirstMonday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "3":
                                                DateTime FirstTuesday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstTuesday.DayOfWeek == DayOfWeek.Tuesday)
                                                    {

                                                        leaveDate = FirstTuesday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstTuesday = FirstTuesday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "4":
                                                DateTime FirstWednesday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstWednesday.DayOfWeek == DayOfWeek.Wednesday)
                                                    {
                                                        leaveDate = FirstWednesday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstWednesday = FirstWednesday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "5":
                                                DateTime FirstThursday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstThursday.DayOfWeek == DayOfWeek.Thursday)
                                                    {
                                                        leaveDate = FirstThursday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstThursday = FirstThursday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "6":
                                                DateTime FirstFriday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstFriday.DayOfWeek == DayOfWeek.Friday)
                                                    {
                                                        leaveDate = FirstFriday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstFriday = FirstFriday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "7":
                                                DateTime FirstSaturday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstSaturday.DayOfWeek == DayOfWeek.Saturday)
                                                    {
                                                        leaveDate = FirstSaturday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstSaturday = FirstSaturday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "1":
                                                DateTime FirstSunday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstSunday.DayOfWeek == DayOfWeek.Sunday)
                                                    {
                                                        leaveDate = FirstSunday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstSunday = FirstSunday.AddDays(1);
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                    if (leaveDate != DateTime.MinValue)
                                    {
                                        MonthlyOffDates.Add(leaveDate);
                                    }
                                }
                            }

                        }
                        if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "2")
                        {
                            for (int i = 0; i <= 1; i++)
                            {
                                if (i == 0)
                                {
                                    firstdate = 1;
                                }
                                else if (i == 1)
                                {
                                    firstdate = 7;
                                }


                                string DaysStr = Rowd["OFFDUTYDTL_DAYS"].ToString();
                                string[] spitDayStr = DaysStr.Split(',');
                                foreach (string strSpliSlice in spitDayStr)
                                {
                                    if (strSpliSlice != "")
                                    {
                                        switch (strSpliSlice)
                                        {
                                            case "2":
                                                DateTime FirstMonday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstMonday.DayOfWeek == DayOfWeek.Monday)
                                                    {
                                                        leaveDate = FirstMonday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstMonday = FirstMonday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "3":
                                                DateTime FirstTuesday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstTuesday.DayOfWeek == DayOfWeek.Tuesday)
                                                    {

                                                        leaveDate = FirstTuesday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstTuesday = FirstTuesday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "4":
                                                DateTime FirstWednesday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstWednesday.DayOfWeek == DayOfWeek.Wednesday)
                                                    {
                                                        leaveDate = FirstWednesday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstWednesday = FirstWednesday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "5":
                                                DateTime FirstThursday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstThursday.DayOfWeek == DayOfWeek.Thursday)
                                                    {
                                                        leaveDate = FirstThursday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstThursday = FirstThursday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "6":
                                                DateTime FirstFriday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstFriday.DayOfWeek == DayOfWeek.Friday)
                                                    {
                                                        leaveDate = FirstFriday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstFriday = FirstFriday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "7":
                                                DateTime FirstSaturday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstSaturday.DayOfWeek == DayOfWeek.Saturday)
                                                    {
                                                        leaveDate = FirstSaturday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstSaturday = FirstSaturday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "1":
                                                DateTime FirstSunday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstSunday.DayOfWeek == DayOfWeek.Sunday)
                                                    {
                                                        leaveDate = FirstSunday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstSunday = FirstSunday.AddDays(1);
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                    if (leaveDate != DateTime.MinValue)
                                    {
                                        MonthlyOffDates.Add(leaveDate);
                                    }
                                }
                            }

                        }
                        if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "3")
                        {
                            for (int i = 0; i <= 1; i++)
                            {
                                if (i == 0)
                                {
                                    firstdate = 22;
                                }
                                else if (i == 1)
                                {
                                    firstdate = 28;
                                }


                                string DaysStr = Rowd["OFFDUTYDTL_DAYS"].ToString();
                                string[] spitDayStr = DaysStr.Split(',');
                                foreach (string strSpliSlice in spitDayStr)
                                {
                                    if (strSpliSlice != "")
                                    {
                                        switch (strSpliSlice)
                                        {
                                            case "2":
                                                DateTime FirstMonday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstMonday.DayOfWeek == DayOfWeek.Monday)
                                                    {
                                                        leaveDate = FirstMonday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstMonday = FirstMonday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "3":
                                                DateTime FirstTuesday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstTuesday.DayOfWeek == DayOfWeek.Tuesday)
                                                    {

                                                        leaveDate = FirstTuesday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstTuesday = FirstTuesday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "4":
                                                DateTime FirstWednesday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstWednesday.DayOfWeek == DayOfWeek.Wednesday)
                                                    {
                                                        leaveDate = FirstWednesday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstWednesday = FirstWednesday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "5":
                                                DateTime FirstThursday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstThursday.DayOfWeek == DayOfWeek.Thursday)
                                                    {
                                                        leaveDate = FirstThursday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstThursday = FirstThursday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "6":
                                                DateTime FirstFriday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstFriday.DayOfWeek == DayOfWeek.Friday)
                                                    {
                                                        leaveDate = FirstFriday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstFriday = FirstFriday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "7":
                                                DateTime FirstSaturday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstSaturday.DayOfWeek == DayOfWeek.Saturday)
                                                    {
                                                        leaveDate = FirstSaturday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstSaturday = FirstSaturday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "1":
                                                DateTime FirstSunday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstSunday.DayOfWeek == DayOfWeek.Sunday)
                                                    {
                                                        leaveDate = FirstSunday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstSunday = FirstSunday.AddDays(1);
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                    if (leaveDate != DateTime.MinValue)
                                    {
                                        MonthlyOffDates.Add(leaveDate);
                                    }
                                }
                            }

                        }
                        if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "4" || Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "5" || Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "6" || Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "7" || Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "8")
                        {
                            for (int i = 0; i < 1; i++)
                            {
                                if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "4")
                                {
                                    firstdate = 1;
                                }
                                else if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "5")
                                {
                                    firstdate = 8;
                                }
                                else if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "6")
                                {
                                    firstdate = 15;
                                }
                                else if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "7")
                                {
                                    firstdate = 22;
                                }
                                else if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "8")
                                {
                                    firstdate = 28;
                                }


                                string DaysStr = Rowd["OFFDUTYDTL_DAYS"].ToString();
                                string[] spitDayStr = DaysStr.Split(',');
                                foreach (string strSpliSlice in spitDayStr)
                                {
                                    if (strSpliSlice != "")
                                    {
                                        switch (strSpliSlice)
                                        {
                                            case "2":
                                                DateTime FirstMonday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstMonday.DayOfWeek == DayOfWeek.Monday)
                                                    {
                                                        leaveDate = FirstMonday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstMonday = FirstMonday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "3":
                                                DateTime FirstTuesday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstTuesday.DayOfWeek == DayOfWeek.Tuesday)
                                                    {

                                                        leaveDate = FirstTuesday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstTuesday = FirstTuesday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "4":
                                                DateTime FirstWednesday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstWednesday.DayOfWeek == DayOfWeek.Wednesday)
                                                    {
                                                        leaveDate = FirstWednesday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstWednesday = FirstWednesday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "5":
                                                DateTime FirstThursday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstThursday.DayOfWeek == DayOfWeek.Thursday)
                                                    {
                                                        leaveDate = FirstThursday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstThursday = FirstThursday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "6":
                                                DateTime FirstFriday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstFriday.DayOfWeek == DayOfWeek.Friday)
                                                    {
                                                        leaveDate = FirstFriday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstFriday = FirstFriday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "7":
                                                DateTime FirstSaturday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstSaturday.DayOfWeek == DayOfWeek.Saturday)
                                                    {
                                                        leaveDate = FirstSaturday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstSaturday = FirstSaturday.AddDays(1);
                                                    }
                                                }
                                                break;
                                            case "1":
                                                DateTime FirstSunday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < 7; count++)
                                                {
                                                    if (FirstSunday.DayOfWeek == DayOfWeek.Sunday)
                                                    {
                                                        leaveDate = FirstSunday;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstSunday = FirstSunday.AddDays(1);
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                    if (leaveDate != DateTime.MinValue)
                                    {
                                        MonthlyOffDates.Add(leaveDate);
                                    }
                                }
                            }

                        }

                    }

                }
            }
            if (MonthlyOffDates.Count > 0)
            {

                string HoliName = "", Holi1 = "false";
                foreach (var RowHoli in MonthlyOffDates)
                {
                    DateTime fromdate;
                    string ans;
                    ans = dateCheck.ToString("dd-MM-yyyy");
                    ans = String.Format("{0:dd-MM-yyyy}", ans);
                    fromdate = objCommon.textToDateTime(ans);


                    //to check week off days
                    int weekflag = 0;
                    DateTime fromdate1;
                    string ans1;
                    ans1 = dateCheck.ToString("dd-MM-yyyy");
                    ans1 = String.Format("{0:dd-MM-yyyy}", ans1);
                    fromdate1 = objCommon.textToDateTime(ans1);
                    string strDayWkString1 = RowHoli.ToString("dddd");

                    if (strJbWklyOffDay.Contains(strDayWkString1))
                    {

                        weekflag = 1; ;
                    }
                    if (weekflag != 1)
                    {
                        if (RowHoli == fromdate)
                        {
                            //HoliName = RowHoli["HLDAYMSTR_DATE"].ToString();
                            Holi1 = "true";
                            return Holi1;
                        }
                    }
                }
            }
            DateTime fromdate2;
            string ans2;
            ans2 = dateCheck.ToString("dd-MM-yyyy");
            ans2 = String.Format("{0:dd-MM-yyyy}", ans2);
            fromdate2 = objCommon.textToDateTime(ans2);
            string strDayWkString2 = fromdate2.ToString("dddd");
            if (strJbWklyOffDay.Contains(strDayWkString2))
            {

                return "true";
            }
            return "";


            //List<DateTime> MonthlyOffDates = new List<DateTime>();
            // return "MonthlyOffDates";
        }
        public string checkholiday(DateTime day, DateTime datenow, DateTime enddate)
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
            clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
            DateTime fromdate, todate;
            //fromdate = objCommon.textToDateTime(txtFromDate.Text);
            objEntLevAllocn.LeaveFrmDate = datenow;
            //todate = objCommon.textToDateTime(txtToDate.Text);
            objEntLevAllocn.LeaveToDate = enddate;
            DataTable dtHoliday = objBusLevAllocn.ReadHolidayDate(objEntLevAllocn);


            string HoliName = "", Holi1 = "false";
            foreach (DataRow RowHoli in dtHoliday.Rows)
            {
                string ans;
                ans = day.ToString("dd-MM-yyyy");
                ans = String.Format("{0:dd-MM-yyyy}", ans);
                fromdate = objCommon.textToDateTime(ans);
                if (RowHoli["HLDAYMSTR_DATE"].ToString() != "")
                {
                    if (objCommon.textToDateTime(RowHoli["HLDAYMSTR_DATE"].ToString()) == fromdate)
                    {
                        HoliName = RowHoli["HLDAYMSTR_DATE"].ToString();
                        Holi1 = "true";
                        //return Holi1;
                    }
                }
            }
            return Holi1;
        }

    }
    public static decimal calcFutureLeaveCnt(string stringToCheck, DataTable dtLeaveDate, cls_Entity_Monthly_Salary_Process objEnt2)
    {
        decimal TtlCnt = 0;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        for (int lcnt = 0; lcnt < dtLeaveDate.Rows.Count; lcnt++)
        {
            string stringToCheck1 = dtLeaveDate.Rows[lcnt]["LEAVETYP_ID"].ToString();
            if (stringToCheck1 == stringToCheck)
            {

                int HoliPaidSts = Convert.ToInt32(dtLeaveDate.Rows[lcnt]["LEAVETYP_HOLIDAY_PAID_STS"].ToString());
                int OffPaidSts = Convert.ToInt32(dtLeaveDate.Rows[lcnt]["LEAVETYP_OFFDAY_PAID_STS"].ToString());


                decimal cnt = 0;
                dutyOf objDuty = new dutyOf();
                int OffCount = 0;

                DateTime LfrmDt = DateTime.MinValue;
                DateTime LToDt = DateTime.MinValue;

                if (dtLeaveDate.Rows[lcnt]["LEAVE_FROM_DATE"].ToString() != "")
                {
                    LfrmDt = objCommon.textToDateTime(dtLeaveDate.Rows[lcnt]["LEAVE_FROM_DATE"].ToString());
                }
                if (dtLeaveDate.Rows[lcnt]["LEAVE_TO_DATE"].ToString() != "")
                {
                    LToDt = objCommon.textToDateTime(dtLeaveDate.Rows[lcnt]["LEAVE_TO_DATE"].ToString());
                }
                if (LfrmDt != DateTime.MinValue && LToDt != DateTime.MinValue)
                {
                    if (objEnt2.DateStartDate <= LfrmDt && LToDt <= objEnt2.DateEndDate)
                    {
                        cnt = Convert.ToInt32((LToDt - LfrmDt).TotalDays) + 1;
                        if (dtLeaveDate.Rows[lcnt]["LEAVE_FROM_SCTN"].ToString() != "1")
                        {
                            cnt = cnt - (decimal)0.5;
                        }
                        if (dtLeaveDate.Rows[lcnt]["LEAVE_TO_SCTN"].ToString() != "1")
                        {
                            cnt = cnt - (decimal)0.5;
                        }
                        DateTime datenow, enddate;
                        datenow = LfrmDt;
                        enddate = LToDt;
                        if (HoliPaidSts == 1 || OffPaidSts == 1)
                        {
                            for (var day = datenow; day <= enddate; day = day.AddDays(1))
                            {
                                string hol = "false";
                                if (HoliPaidSts == 1)
                                {
                                    hol = objDuty.checkholiday(day, datenow, enddate);
                                    if (hol == "true")
                                    {
                                        OffCount = OffCount + 1;
                                    }
                                }
                                if (OffPaidSts == 1 && hol != "true")
                                {
                                    string off = objDuty.CheckDutyOff(day, objEnt2.CorpOffice.ToString(), objEnt2.Orgid.ToString());
                                    if (off == "true")
                                    {
                                        OffCount = OffCount + 1;
                                    }
                                }
                            }
                        }
                        cnt = cnt - OffCount;
                        if (cnt < 0)
                        {
                            cnt = 0;
                        }
                    }
                    else if (LfrmDt < objEnt2.DateStartDate)
                    {

                        cnt = Convert.ToInt32((LToDt - objEnt2.DateStartDate).TotalDays) + 1;
                        if (dtLeaveDate.Rows[lcnt]["LEAVE_TO_SCTN"].ToString() != "1")
                        {
                            cnt = cnt - (decimal)0.5;
                        }
                        DateTime datenow, enddate;
                        datenow = objEnt2.DateStartDate;
                        enddate = LToDt;
                        if (HoliPaidSts == 1 || OffPaidSts == 1)
                        {
                            for (var day = datenow; day <= enddate; day = day.AddDays(1))
                            {
                                string hol = "false";
                                if (HoliPaidSts == 1)
                                {
                                    hol = objDuty.checkholiday(day, datenow, enddate);
                                    if (hol == "true")
                                    {
                                        OffCount = OffCount + 1;
                                    }
                                }
                                if (OffPaidSts == 1 && hol != "true")
                                {
                                    string off = objDuty.CheckDutyOff(day, objEnt2.CorpOffice.ToString(), objEnt2.Orgid.ToString());
                                    if (off == "true")
                                    {
                                        OffCount = OffCount + 1;
                                    }
                                }
                            }
                        }
                        cnt = cnt - OffCount;
                        if (cnt < 0)
                        {
                            cnt = 0;
                        }
                    }
                    else if (LToDt > objEnt2.DateEndDate)
                    {

                        cnt = Convert.ToInt32((objEnt2.DateEndDate - LfrmDt).TotalDays) + 1;
                        if (dtLeaveDate.Rows[lcnt]["LEAVE_FROM_SCTN"].ToString() != "1")
                        {
                            cnt = cnt - (decimal)0.5;
                        }


                        DateTime datenow, enddate;
                        datenow = LfrmDt;
                        enddate = objEnt2.DateEndDate;
                        if (HoliPaidSts == 1 || OffPaidSts == 1)
                        {
                            for (var day = datenow; day <= enddate; day = day.AddDays(1))
                            {
                                string hol = "false";
                                if (HoliPaidSts == 1)
                                {
                                    hol = objDuty.checkholiday(day, datenow, enddate);
                                    if (hol == "true")
                                    {
                                        OffCount = OffCount + 1;
                                    }
                                }
                                if (OffPaidSts == 1 && hol != "true")
                                {
                                    string off = objDuty.CheckDutyOff(day, objEnt2.CorpOffice.ToString(), objEnt2.Orgid.ToString());
                                    if (off == "true")
                                    {
                                        OffCount = OffCount + 1;
                                    }
                                }
                            }
                        }
                        cnt = cnt - OffCount;
                        if (cnt < 0)
                        {
                            cnt = 0;
                        }
                    }

                }

                else if (LfrmDt != DateTime.MinValue && LToDt == DateTime.MinValue)
                {
                    if (LfrmDt <= objEnt2.DateEndDate && LfrmDt >= objEnt2.DateStartDate)
                    {

                        if (dtLeaveDate.Rows[lcnt]["LEAVE_FROM_SCTN"].ToString() == "1")
                        {
                            cnt = 1;
                        }
                        else
                        {
                            cnt = (decimal)0.5;
                        }
                    }

                }
                TtlCnt += cnt;
            }
        }
        return TtlCnt;
    }
    protected void btnAprroveGmApproval_Click(object sender, EventArgs e)
    {

        cls_Business_Leave_Approval objBusinessLeaveApproval = new cls_Business_Leave_Approval();
        clsEntityLayerLeaveApproval ObjEntityLeaveApproval = new clsEntityLayerLeaveApproval();
        ObjEntityLeaveApproval.ApprovalStatus = 1;
        ObjEntityLeaveApproval.Requeststatus = 3;
        ObjEntityLeaveApproval.Date = DateTime.Today;
        ObjEntityLeaveApproval.User_Id = Convert.ToInt32(HiddenUserId.Value);
        ObjEntityLeaveApproval.Leave_Id = Convert.ToInt32(HiddenLeaveID.Value);

        ObjEntityLeaveApproval.GmComment = txthrnote.Text;
        objBusinessLeaveApproval.Gm_Approve(ObjEntityLeaveApproval);
        ObjEntityLeaveApproval.ApprovalStatus = 0;
        // objBusinessLeaveApproval.Reject(ObjEntityLeaveApproval);
        Response.Redirect("gen_Leave_Approval_List.aspx?InsUpd=ApprovedGm");

        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessApproved", "SuccessApproved();", true);

    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
        //   hiddenRsnid.Value = HiddenLeaveID.Value;
        cls_Business_Leave_Approval objBusinessLeaveApproval = new cls_Business_Leave_Approval();
        clsEntityLayerLeaveApproval ObjEntityLeaveApproval = new clsEntityLayerLeaveApproval();
        ObjEntityLeaveApproval.ApprovalStatus = 1;
        ObjEntityLeaveApproval.Requeststatus = 5;
        ObjEntityLeaveApproval.Date = DateTime.Today;
        ObjEntityLeaveApproval.User_Id = Convert.ToInt32(HiddenUserId.Value);
        ObjEntityLeaveApproval.Leave_Id = Convert.ToInt32(HiddenLeaveID.Value);
        //  ScriptManager.RegisterStartupScript(this, GetType(), "OpenCancelView", "return OpenCancelView();", true);

        //objBusinessLeaveApproval.Reject(ObjEntityLeaveApproval);
        Response.Redirect("gen_Leave_Approval_List.aspx?InsUpd=Rejected");

        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessRejected", "SuccessRejected();", true);


    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        cls_Business_Leave_Approval objBusinessLeaveApproval = new cls_Business_Leave_Approval();
        clsEntityLayerLeaveApproval ObjEntityLeaveApproval = new clsEntityLayerLeaveApproval();
        ObjEntityLeaveApproval.ApprovalStatus = 1;
        ObjEntityLeaveApproval.Requeststatus = 6;
        ObjEntityLeaveApproval.Date = DateTime.Today;
        ObjEntityLeaveApproval.User_Id = Convert.ToInt32(HiddenUserId.Value);
        ObjEntityLeaveApproval.Leave_Id = Convert.ToInt32(HiddenLeaveID.Value);

        objBusinessLeaveApproval.Close(ObjEntityLeaveApproval);
        objBusinessLeaveApproval.DeleteLeaveAllocationByLveRequestID(ObjEntityLeaveApproval);
        Response.Redirect("gen_Leave_Approval_List.aspx?InsUpd=Close");


    }

    protected void btnRsnSave_Click(object sender, EventArgs e)
    {
        cls_Business_Leave_Approval objBusinessLeaveApproval = new cls_Business_Leave_Approval();
        clsEntityLayerLeaveApproval ObjEntityLeaveApproval = new clsEntityLayerLeaveApproval();
        ObjEntityLeaveApproval.ApprovalStatus = 1;
        ObjEntityLeaveApproval.Requeststatus = 5;
        ObjEntityLeaveApproval.Date = DateTime.Today;
        ObjEntityLeaveApproval.User_Id = Convert.ToInt32(HiddenUserId.Value);
        ObjEntityLeaveApproval.Leave_Id = Convert.ToInt32(HiddenLeaveID.Value);
        //  ScriptManager.RegisterStartupScript(this, GetType(), "OpenCancelView", "return OpenCancelView();", true);
        ObjEntityLeaveApproval.CancelReason = hiddenRsnid.Value;
        objBusinessLeaveApproval.Reject(ObjEntityLeaveApproval);
        Response.Redirect("gen_Leave_Approval_List.aspx?InsUpd=Rejected");

        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessRejected", "SuccessRejected();", true);


    }
}