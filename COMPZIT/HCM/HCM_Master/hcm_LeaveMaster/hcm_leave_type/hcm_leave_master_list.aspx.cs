using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using CL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HCM_HCM_Master_hcm_leave_type_hcm_leave_master_list : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtCnclReason.Attributes.Add("onkeypress", "return isTag(event)");
        if (!IsPostBack)
        {
            int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0;
            hiddenRoleAdd.Value = "0";
            hiddenRoleUpdate.Value = "0";
            hiddenRoleCancel.Value = "0";
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

            intUserRoleRecall = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
            DataTable dtCancelRecall = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUserRoleRecall);
            if (dtCancelRecall.Rows.Count > 0)
            {
                intEnableRecall = 1;
                hiddenRoleRecall.Value = "1";
            }
            else
            {
                intEnableRecall = 0;
                hiddenRoleRecall.Value = "0";
            }

            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Leave_Type_Master);

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
                        hiddenRoleAdd.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleUpdate.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleCancel.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        //future

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



                //Creating objects for business layer
              clsBusiness_Leave_Type objBusinessLeavetype = new clsBusiness_Leave_Type();
              clsEntity_Leave_Type ObjEntityLeaveType = new clsEntity_Leave_Type();
    
                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    ObjEntityLeaveType.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    ObjEntityLeaveType.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }


                //when recalled
                if (Request.QueryString["ReId"] != null)
                {
                    string strRandomMixedId = Request.QueryString["ReId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    ObjEntityLeaveType.intleave = Convert.ToInt32(strId);
                    ObjEntityLeaveType.User_Id = intUserId;

                    ObjEntityLeaveType.Date = System.DateTime.Now;

                    DataTable dtLeaveTypDetail = new DataTable();
                    DataTable dtLeavedesigDetail = new DataTable();
                    DataTable dtLeavepaygradeDetail = new DataTable();
                    DataTable dtLeaveExperienceDetail = new DataTable();
                    dtLeaveTypDetail = objBusinessLeavetype.ReadLeavedetailsById(ObjEntityLeaveType);
                    dtLeavedesigDetail = objBusinessLeavetype.ReadLeavedDesigById(ObjEntityLeaveType);
                    dtLeavepaygradeDetail = objBusinessLeavetype.ReadLeavePaygradeById(ObjEntityLeaveType);
                    dtLeaveExperienceDetail = objBusinessLeavetype.ReadLeaveExprnsById(ObjEntityLeaveType);
                    string strName = "", strNameCount = "0", CheckLeavOnAbsnc ="0";
                    if (dtLeaveTypDetail.Rows.Count > 0)
                    {

                        strName = dtLeaveTypDetail.Rows[0]["LEAVETYP_NAME"].ToString();
                    }

                    if (strName != "")
                    {
                        ObjEntityLeaveType.LeaveTypeName = strName;
                    }

                    strNameCount = objBusinessLeavetype.CheckLeaveName(ObjEntityLeaveType);


                    if (dtLeaveTypDetail.Rows[0]["LEAVETYP_LEAVE_ON_ABSENCE"].ToString() == "1")
                    {
                        CheckLeavOnAbsnc = objBusinessLeavetype.CheckLeavOnAbsnc(ObjEntityLeaveType);
                    }

                    if (strNameCount == "0" && CheckLeavOnAbsnc == "0")
                    {

                        objBusinessLeavetype.ReCallLeaveDetails(ObjEntityLeaveType);

                        Response.Redirect("hcm_leave_master_List.aspx?InsUpd=Recl");
                    }
                    else
                    {
                        if (strNameCount != "0")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCardName", "DuplicationCardName();", true);
                        }
                        else if (CheckLeavOnAbsnc != "0")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationLeavAbsnc", "DuplicationLeavAbsnc();", true);
                        }
                    }

                }


                if (Request.QueryString["Id"] != null)
                {//when Canceled

                    ObjEntityLeaveType.Status_id = 1;
                    if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
                    {
                        ObjEntityLeaveType.Status_id = Convert.ToInt32(Request.QueryString["Srch"].ToString());
                        ddlStatus.Items.FindByValue(ObjEntityLeaveType.Status_id.ToString()).Selected = true;


                    }

                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    ObjEntityLeaveType.LeaveTypeMasterId = Convert.ToInt32(strId);
                    ObjEntityLeaveType.User_Id = intUserId;

                    ObjEntityLeaveType.Date = System.DateTime.Now;
                    clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
                    DataTable dtCorpDetail = new DataTable();
                    dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                    if (dtCorpDetail.Rows.Count > 0)
                    {
                        string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                        if (CnclrsnMust == "0")
                        {
                            ObjEntityLeaveType.CancelReason = objCommon.CancelReason();


                            objBusinessLeavetype.CancelLeaveType(ObjEntityLeaveType);

                            Response.Redirect("hcm_leave_master_List.aspx?InsUpd=Cncl&Srch=" + ObjEntityLeaveType.Status_id + "");


                        }
                        else
                        {
                            DataTable dtLeaveType = new DataTable();
                            ObjEntityLeaveType.Status_id = Convert.ToInt32(ddlStatus.SelectedItem.Value);
                            dtLeaveType = objBusinessLeavetype.ReadLeaveTypeBySearch(ObjEntityLeaveType);
                            string strHtm = ConvertDataTableToHTML(dtLeaveType, intEnableModify, intEnableCancel, intEnableRecall);
                            //Write to divReport
                            divReport.InnerHtml = strHtm;

                            hiddenRsnid.Value = strId;

                        }

                    }



                }
                else
                {
                    //to view
                    DataTable dtLeavTyp = new DataTable();
                    if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
                    {
                        ObjEntityLeaveType.Status_id = Convert.ToInt32(Request.QueryString["Srch"].ToString());
                        ddlStatus.Items.FindByValue(ObjEntityLeaveType.Status_id.ToString()).Selected = true;


                    }
                    ObjEntityLeaveType.Status_id = Convert.ToInt32(ddlStatus.SelectedItem.Value);
                    dtLeavTyp = objBusinessLeavetype.ReadLeaveTypeBySearch(ObjEntityLeaveType);
                    string strHtm = ConvertDataTableToHTML(dtLeavTyp, intEnableModify, intEnableCancel, intEnableRecall);
                    //Write to divReport
                    divReport.InnerHtml = strHtm;

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
                    }
                }


            }
        }
    }




    //for the list table in the list page
    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intEnableRecall)
    {
        int intddlStatus = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        clsBusiness_Leave_Type objBusinessLeavetype = new clsBusiness_Leave_Type();
        clsEntity_Leave_Type ObjEntityLeaveType = new clsEntity_Leave_Type();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        //strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";

        //for assigning column for reopen

        int intReCallForTAble = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());

            if (intCnclUsrId != 0)
            {
                intReCallForTAble = 1;
            }
        }

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:70%;text-align: left; word-wrap:break-word;\">" + "LEAVE TYPE" + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%; word-wrap:break-word; text-align: right;\">" + "NUMBER OF DAYS " + "</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">" + "TRAVEL" + "</th>";
            }
        }
        if (intReCallForTAble == 0)
        {
            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT</th>";
            }
            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">ADD</th>";
            }
        }
        else
        {
            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">VIEW</th>";
        }
        if (intReCallForTAble == 0)
        {
            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">DELETE</th>";
            }
        }
        if (intReCallForTAble == 1)
        {
            if (intEnableRecall == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">RECALL</th>";
            }
        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

            strHtml += "<tr  >";

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:70%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word; text-align: right;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
            }

            int intRealloctnStatus = 0;

            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

            DataTable dtLeaveType = new DataTable();
            ObjEntityLeaveType.intleave = Convert.ToInt32(strId);
            dtLeaveType = objBusinessLeavetype.ReadConfirmedLevAllocn(ObjEntityLeaveType);
            if (dtLeaveType.Rows.Count > 0)
            {
                intRealloctnStatus = 1;
            }

            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                //if (intCancTransaction == 0)
                //{
                if (intCnclUsrId == 0)
                {
                    if (intRealloctnStatus == 0)
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return getdetails(this.href);' " +
                              " href=\"hcm_leave_master.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return getdetails(this.href);' " +
                                  " href=\"hcm_leave_master.aspx?SelctdId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                    }

                    //individual employee leave type adding
                    if (dt.Rows[intRowBodyCount]["LEAVETYP_APPLICABLE_NONE_STS"].ToString() == "1")
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a title=\"Add individual leave type\" onclick='return getdetails(this.href);' " +
                                                     " href=\"hcm_Individual_Leave_Type.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/ADD.png' /> " + "</a> </td>";
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return getdetails(this.href);' " +
                                                     " href=\"javascript:;\">" + "<img  style=\"opacity: 0.2;cursor: pointer; \"  src='/Images/Icons/ADD.png' /> " + "</a> </td>";
                    }
                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return getdetails(this.href);' " +
                     " href=\"hcm_leave_master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";
                }

            }
            if (intReCallForTAble == 0)
            {
                if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    if (intCnclUsrId == 0)
                    {
                        if (intCancTransaction == 0)
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelAlert(this.href);' " +
                             " href=\"hcm_leave_master_list.aspx?Id=" + Id + "&Srch=" + intddlStatus + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >"
                                    + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                        }
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                    }
                }
            }
            if (intReCallForTAble == 1)
            {
                if (intEnableRecall == 1)
                {
                    if (intCnclUsrId == 0)
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return ReCallAlert(this.href);' " +
                             " href=\"hcm_leave_master_list.aspx?ReId=" + Id + "&Srch=" + intddlStatus + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                    }
                }
            }

            strHtml += "</tr>";

        }

        strHtml += "</tbody>";

        strHtml += "</table>";


        sb.Append(strHtml);
        return sb.ToString();
    }




    //  saving the reason for the deletion
    protected void btnRsnSave_Click(object sender, EventArgs e)
    {


        //Creating objects for business layer

        clsBusiness_Leave_Type objBusinessLeavetype = new clsBusiness_Leave_Type();
        clsEntity_Leave_Type ObjEntityLeaveType = new clsEntity_Leave_Type();
    
        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            ObjEntityLeaveType.LeaveTypeMasterId = Convert.ToInt32(hiddenRsnid.Value);


            if (Session["USERID"] != null)
            {
                ObjEntityLeaveType.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            int status = Convert.ToInt32(ddlStatus.SelectedItem.Value);

            ObjEntityLeaveType.Date = System.DateTime.Now;

            ObjEntityLeaveType.CancelReason = txtCnclReason.Text.Trim();


            objBusinessLeavetype.CancelLeaveType(ObjEntityLeaveType);


            Response.Redirect("hcm_leave_master_list.aspx?InsUpd=Cncl&Srch=" + status + "");



        }
    }

    //for searching
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsBusiness_Leave_Type objBusinessLeavetype = new clsBusiness_Leave_Type();
        clsEntity_Leave_Type ObjEntityLeaveType = new clsEntity_Leave_Type();

        ObjEntityLeaveType.Status_id = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        if (cbxCnclStatus.Checked == true)
            ObjEntityLeaveType.CancelStatus = 1;
        else
            ObjEntityLeaveType.CancelStatus = 0;

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityLeaveType.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityLeaveType.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        DataTable dtLeave = new DataTable();

        dtLeave = objBusinessLeavetype.ReadLeaveTypeBySearch(ObjEntityLeaveType);


        int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        intUserRoleRecall = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
        DataTable dtCancelRecall = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUserRoleRecall);
        if (dtCancelRecall.Rows.Count > 0)
        {
            intEnableRecall = 1;
            hiddenRoleRecall.Value = "1";
        }
        else
        {
            intEnableRecall = 0;
            hiddenRoleRecall.Value = "0";
        }
        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Leave_Type_Master);
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
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                {
                    intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                }

            }
        }

        string strHtm = ConvertDataTableToHTML(dtLeave, intEnableModify, intEnableCancel, intEnableRecall);
        //Write to divReport
        divReport.InnerHtml = strHtm;
    }
}