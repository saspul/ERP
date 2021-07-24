using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using BL_Compzit.BusinessLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.Entity_Layer_HCM;
using EL_Compzit.EntityLayer_AWMS;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HCM_HCM_Master_gen_Manpower_Recruitment_gen_Manpower_Recruitment_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlMode.Focus();
            DivisionLoad();
            LoadRole();
            //DepartmentLoad();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            cls_Business_Leave_Approval objBusinessLeaveApproval = new cls_Business_Leave_Approval();
            clsEntityLayerLeaveApproval ObjEntityLeaveApproval = new clsEntityLayerLeaveApproval();
            int intUserId = 0, intcorpid = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableConfirm = 0, intEnableReOpen = 0, intEnableClose = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableHrConfirm = 0, intEnableDMApprove = 0, intEnableGMApprove = 0;

            // objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.VEHICLE_MASTER);
            /// objEntityCommon.CommonLabelFieldName = "VHCL_PERMIT_NUMBR";
            if (Session["CORPOFFICEID"] != null)
            {
                Hiddencorpid.Value = Session["CORPOFFICEID"].ToString();
                intcorpid = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                ObjEntityLeaveApproval.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                Hiddenorgid.Value = Session["ORGID"].ToString();
                ObjEntityLeaveApproval.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                ObjEntityLeaveApproval.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            intUserRoleRecall = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
            DataTable dtCancelRecall = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUserRoleRecall);
            if (dtCancelRecall.Rows.Count > 0)
            {
                intEnableRecall = 0;
            }
            else
            {
                intEnableRecall = 0;
            }
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

                        HiddenHrCnfrm.Value = intEnableHrConfirm.ToString(); ;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                    {
                        intEnableDMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        //intEnableDMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenDMApprove.Value = intEnableDMApprove.ToString();

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        //    HiddenDMApprove.Value = intEnableDMApprove.ToString(); ;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        //    HiddenDMApprove.Value = intEnableDMApprove.ToString(); ;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString())
                    {
                        intEnableClose = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        //    HiddenDMApprove.Value = intEnableDMApprove.ToString(); ;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.GM_Allocation).ToString())
                    {


                        intEnableGMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);



                    }

                }
            }
            if (intEnableDMApprove != 1)
            {
                ListItem removeItem = ddrole.Items.FindByText("DIVISION MANAGER");
                ddrole.Items.Remove(removeItem);

            }
            if (intEnableHrConfirm != 1)
            {
                ListItem removeItem = ddrole.Items.FindByText("HR");
                ddrole.Items.Remove(removeItem);

            }
            if (intEnableGMApprove != 1)
            {
                ListItem removeItem = ddrole.Items.FindByText("GENERAL MANAGER");
                ddrole.Items.Remove(removeItem);

            }

            if (intEnableAdd == 0)
                divAdd.Visible = false;
            if (Request.QueryString["Approve"] != null)
            {//when Canceled  
                string strRandomMixedId = Request.QueryString["Approve"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                ApproveRequst(strId, intUserId);

            }
            if (Request.QueryString["Close"] != null)
            {//when Canceled  
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessClose", "SuccessClose();", true);


            }
            if (Request.QueryString["Approved"] != null)
            {//when Canceled  
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessApproved", "SuccessApproved();", true);


            }
            if (Request.QueryString["canId"] != null)
            {//when Canceled

                string strRandomMixedId = Request.QueryString["canId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                ObjEntityLeaveApproval.Leave_Id = Convert.ToInt32(strId);
                ObjEntityLeaveApproval.User_Id = intUserId;

                ObjEntityLeaveApproval.Date = System.DateTime.Now;



                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
                DataTable dtCorpDetail = new DataTable();
                dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intcorpid);
                if (dtCorpDetail.Rows.Count > 0)
                {
                    string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                    if (CnclrsnMust == "0")
                    {
                        ObjEntityLeaveApproval.CancelReason = objCommon.CancelReason();

                        // objBusinessLeaveApproval.CancelManpowerRecruitmentById(ObjEntityLeaveApproval);
                        if (HiddenSearchField.Value == "")
                        {
                            Response.Redirect("gen_Manpower_Recruitment_List.aspx?InsUpd=Cncl");
                        }
                        else
                        {
                            Response.Redirect("gen_Manpower_Recruitment_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
                        }

                    }
                    else
                    {

                        hiddenRsnid.Value = strId;

                    }
                }
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
                else if (strInsUpd == "Recl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessRecall", "SuccessRecall();", true);
                }
                else if (strInsUpd == "StsCh")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessStatusChange", "SuccessStatusChange();", true);
                }
                else if (strInsUpd == "Approved")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessApproved", "SuccessApproved();", true);
                }
                else if (strInsUpd == "Reopen")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReOpen", "SuccessReOpen();", true);
                }
                else if (strInsUpd == "Close")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessClose", "SuccessClose();", true);
                }
                else if (strInsUpd == "Rejected")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessRejected", "SuccessRejected();", true);
                }
                else if (strInsUpd == "verify")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessVerified", "SuccessVerified();", true);
                }
                else if (strInsUpd == "ApprovedRep")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessApprovedRep", "SuccessApprovedRep();", true);
                }
                else if (strInsUpd == "ApprovedDivmanager")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessApprovedDivmanager", "SuccessApprovedDivmanager();", true);
                }
                else if (strInsUpd == "ApprovedHr")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessApprovedHr", "SuccessApprovedHr();", true);
                }
                else if (strInsUpd == "ApprovedGm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessApprovedGm", "SuccessApprovedGm();", true);
                }
            }


            ObjEntityLeaveApproval.Mode = 1;
            ObjEntityLeaveApproval.StatsSrch = 0;

            if (ddlStatus.SelectedItem.Text == "PENDING")
            {
                if (ddrole.SelectedItem.Text == "HR")
                {
                    ObjEntityLeaveApproval.RoleSrch = 2;
                }
                else if (ddrole.SelectedItem.Text == "DIVISION MANAGER")
                {
                    ObjEntityLeaveApproval.RoleSrch = 1;
                }
                else if (ddrole.SelectedItem.Text == "REPORTING OFFICER")
                {
                    ObjEntityLeaveApproval.RoleSrch = 0;
                }
                else if (ddrole.SelectedItem.Text == "GENERAL MANAGER")
                {
                    ObjEntityLeaveApproval.RoleSrch = 3;
                }
                
            }

            DataTable dtManpower = objBusinessLeaveApproval.ReadLeavallocndtlBySearch(ObjEntityLeaveApproval);

            string strHtm = ConvertDataTableToHTML(dtManpower, intEnableModify, intEnableCancel, intEnableRecall, intEnableDMApprove);
            //Write to divReport
            divReport.InnerHtml = strHtm;
        }
    }

    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intEnableRecall, int intEnableDMApprove)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        int intCnclUsrId = 0;
        int intEnableCnclUsrId = 0;
        int intDivManApproveFrtab = 0;

        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            if (Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString())!=0)
            {
                intEnableCnclUsrId = 1;
            }
            if (Convert.ToInt32(dt.Rows[intRowBodyCount]["LEAVE_DIV_MAN_APPROVAL"].ToString()) != 0)
            {
                intDivManApproveFrtab = 1;
            }

            if (intEnableCnclUsrId == 1 && intDivManApproveFrtab == 1)
                break;
        }

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: LEFT; word-wrap:break-word;\">EMPLOYEE NAME</th>";
            }

            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">LEAVE DATE FROM</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">LEAVE DATE TO</th>";
            }

            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">LEAVE TYPE</th>";
            }

        }
        if (intEnableCnclUsrId != 0)
        {
            strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: left; word-wrap:break-word;\">CANCEL REQUEST DATE</th>";
            if (intEnableDMApprove == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: left; word-wrap:break-word;\">APPROVE LEAVE CANCEL</th>";
            }
        }
        
        strHtml += "<th class=\"thT\"  style=\"width:2%;text-align: left; word-wrap:break-word;\"></th>";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            int intDivManApprove = Convert.ToInt32(dt.Rows[intRowBodyCount]["LEAVE_DIV_MAN_APPROVAL"].ToString());
            intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            int slno = intRowBodyCount + 1;
            strHtml += "<tr  >";
            //  strHtml += "<td class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + slno + "</td>";

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + " <a class=\"tooltip\" style=\" opacity: 1; margin-top: -9px;font-family: calibri;font-size: 13px;z-index: 4;\" title=\" \" onclick='return getdetails(this.href);' " +
                         " href=\"gen_Leave_Approval.aspx?Id=" + Id + "\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</a> </td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["LEAVE DATE FROM"].ToString() + "</td>";
                }

                else if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["LEAVE DATE TO"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["LEAVE TYPE"].ToString() + "</td>";
                }
            }
                if (intEnableCnclUsrId != 0)//If any one have 
                {
                    if (intCnclUsrId != 0)// emp's cancel usrId
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["LEAVE_CNCL_DATE"].ToString() + " </td>";
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  ></td>";
                    }
                    if (intDivManApprove == 0)//div man is not approved to that person
                    {
                        if (intEnableDMApprove == 1 && intCnclUsrId != 0) // have provision for DM
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Approve\" style=\"margin-top:-1%; margin-left:1.3%;opacity:1;width:2%; \"  onclick = 'return ConfirmMessageApprove(this.href);' " +
                                         " href=\"gen_Leave_Approval_List.aspx?Approve=" + Id + "\">" + " <img style=\"cursor:pointer;opacity:1\" src='/Images/Icons/CbChecked.png' /> " + " </a> </td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                        }

                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> Approved</td>";
                    }
                }             

                strHtml += "<td class=\"tdT\" style=\"width:2%; word-wrap:break-word;text-align: center;\"><input type=\"button\" class=\"save\" style=\"height:22px;margin-top:3%\" value=\"VIEW\" onclick=\"return LeavApprvlId('" + Id + "');\" /></td>";
              

            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }


    // at search button click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //Creating objects for business layer
        cls_Business_Leave_Approval objBusinessLeaveApproval = new cls_Business_Leave_Approval();
        clsEntityLayerLeaveApproval ObjEntityLeaveApproval = new clsEntityLayerLeaveApproval();

        int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableConfirm = 0, intEnableReOpen = 0, intEnableClose = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableHrConfirm = 0, intEnableDMApprove = 0;

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityLeaveApproval.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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

        if (Session["USERID"] != null)
        {
            ObjEntityLeaveApproval.User_Id = Convert.ToInt32(Session["USERID"]);
            //objEntityCntrct.User_Id = 
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
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

                    HiddenHrCnfrm.Value = intEnableHrConfirm.ToString(); ;

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                {
                    intEnableDMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    HiddenDMApprove.Value = intEnableDMApprove.ToString();

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                {
                    intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    //    HiddenDMApprove.Value = intEnableDMApprove.ToString(); ;

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                {
                    intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    //    HiddenDMApprove.Value = intEnableDMApprove.ToString(); ;

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString())
                {
                    intEnableClose = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    //    HiddenDMApprove.Value = intEnableDMApprove.ToString(); ;

                }

            }
        }
      
        DataTable dtBrnd = new DataTable();

        ObjEntityLeaveApproval.StatsSrch =Convert.ToInt32(ddlStatus.SelectedItem.Value);
        ObjEntityLeaveApproval.Mode = Convert.ToInt32(ddlMode.SelectedItem.Value);
        ObjEntityLeaveApproval.RoleSrch = Convert.ToInt32(ddrole.SelectedItem.Value);

        DateTime tempdate;

        string ans = txttodate.Text;
        ans = String.Format("{0:dd-MM-yyyy}", ans);
        if (ans == "")
        {
            DateTime answer = DateTime.MinValue;
            tempdate = answer;
        }
        else
        {
            DateTime answer = DateTime.ParseExact(ans, "dd-MM-yyyy", null);
            tempdate = answer;
        }
        ObjEntityLeaveApproval.LeaveToDate = tempdate;
        ans = txtfrmdate.Text;
        ans = String.Format("{0:dd-MM-yyyy}", ans);
        if (ans == "")
        {
            DateTime answer = DateTime.MinValue;
            tempdate = answer;
        }
        else
        {
            DateTime answer = DateTime.ParseExact(ans, "dd-MM-yyyy", null);
            tempdate = answer;
        }

        ObjEntityLeaveApproval.LeaveFrmDate = tempdate;

        dtBrnd = objBusinessLeaveApproval.ReadLeavallocndtlBySearch(ObjEntityLeaveApproval);

        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        intUserRoleRecall = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
        DataTable dtCancelRecall = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUserRoleRecall);
        if (dtCancelRecall.Rows.Count > 0)
        {
            intEnableRecall = 0;
        }
        else
        {
            intEnableRecall = 0;
        }
        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.HCM_STAFF_LEAVE_APROVAL);
        //  DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

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
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                {
                    intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                {
                    intEnableDMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                }

            }
        }

        string strHtm = ConvertDataTableToHTML(dtBrnd, intEnableModify, intEnableCancel, intEnableRecall, intEnableDMApprove);
        //Write to divReport
        divReport.InnerHtml = strHtm;
    }



    public void DivisionLoad()
    {
        clsBusinessLayerManpowerRecruitment objBusinessLeaveApproval = new clsBusinessLayerManpowerRecruitment();
        CllsEntityManpowerRecruitment ObjEntityLeaveApproval = new CllsEntityManpowerRecruitment();
        clsBusinessLayerJobDetails objBusinessJobDetails = new clsBusinessLayerJobDetails();
        clsEntityJobDetails objEntityJobDetails = new clsEntityJobDetails();


        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobDetails.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityJobDetails.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityJobDetails.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtDivision = objBusinessJobDetails.ReadDivision(objEntityJobDetails);
        //    if (dtDivision.Rows.Count > 0)
        //    {
        //        ddlDivision.Items.Clear();
        //        ddlDivision.DataSource = dtDivision;


        //        ddlDivision.DataValueField = "CPRDIV_ID";
        //        ddlDivision.DataTextField = "CPRDIV_NAME";



        //        //ddlProjct.DataValueField = "PROJECT_ID";
        //        ddlDivision.DataBind();

        //    }
        //    ddlDivision.Items.Insert(0, "--SELECT DIVISION--");

        //}
    }
    protected void btnRsnSave_Click(object sender, EventArgs e)
    {

        //Creating objects for business layer
        clsBusinessLayerManpowerRecruitment objBusinessLeaveApproval = new clsBusinessLayerManpowerRecruitment();
        CllsEntityManpowerRecruitment ObjEntityLeaveApproval = new CllsEntityManpowerRecruitment();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityLeaveApproval.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityLeaveApproval.orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            ObjEntityLeaveApproval.RequestId = Convert.ToInt32(hiddenRsnid.Value);


            if (Session["USERID"] != null)
            {
                ObjEntityLeaveApproval.UserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            ObjEntityLeaveApproval.RequestDate1 = System.DateTime.Now;

            ObjEntityLeaveApproval.Cancel_Reason = txtCnclReason.Text.Trim();
            objBusinessLeaveApproval.CancelManpowerRecruitmentById(ObjEntityLeaveApproval);

            if (HiddenSearchField.Value == "")
            {
                Response.Redirect("gen_Manpower_Recruitment_List.aspx?InsUpd=Cncl");
            }
            else
            {
                Response.Redirect("gen_Manpower_Recruitment_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
            }


        }
    }
    public void ApproveRequst(string stid, int intUserId)
    {

        cls_Business_Leave_Approval objBusinessLeaveApproval = new cls_Business_Leave_Approval();
        clsEntityLayerLeaveApproval ObjEntityLeaveApproval = new clsEntityLayerLeaveApproval();
        ObjEntityLeaveApproval.ApprovalStatus = 1;
        ObjEntityLeaveApproval.Requeststatus = 6;
        ObjEntityLeaveApproval.Date = DateTime.Today;
        ObjEntityLeaveApproval.User_Id = Convert.ToInt32(intUserId);
        ObjEntityLeaveApproval.Leave_Id = Convert.ToInt32(stid);

        objBusinessLeaveApproval.DivsionManagerApproval(ObjEntityLeaveApproval);

    }
    public void LoadRole()
    {

        ListItem lstGrp = new ListItem("REPORTING OFFICER", "0");

        ddrole.Items.Insert(0, lstGrp);

        lstGrp = new ListItem("DIVISION MANAGER", "1");
        ddrole.Items.Insert(1, lstGrp);

        lstGrp = new ListItem("GENERAL MANAGER", "3");
        ddrole.Items.Insert(2, lstGrp);
        lstGrp = new ListItem("HR", "2");
        ddrole.Items.Insert(3, lstGrp);
    }
}