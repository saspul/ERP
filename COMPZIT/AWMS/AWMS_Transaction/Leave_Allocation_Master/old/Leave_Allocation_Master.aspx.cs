
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using CL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_AWMS;
using System.Data;
using System.Web.Services;
using System.Globalization;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using System.Text;
// CREATED BY:EVM-0008
// CREATED DATE:21/12/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class AWMS_AWMS_Transaction_Leave_Allocation_Master_Leave_Allocation_Master : System.Web.UI.Page
{

    static DateTime currDateTime = new DateTime();
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "Autocomplete", "Autocomplete();", true);
        txtDateFrom.Attributes.Add("onkeypress", "return isTag(event)");
        TextDateTo.Attributes.Add("onkeypress", "return isTag(event)");
        ddlEmploye.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        imgbtnReOpen.ImageUrl = "/Images/Icons/Reopen.png";


        if (!IsPostBack)
        {
            ddlLeavTyp.Items.Insert(0, "--SELECT LEAVE TYPE--");

            hiddenCurrentDate.Value = "01-01-2019";// strCurrentDate;

            // ddlEmploye.Focus();

            DivFixedAllowance.Style["display"] = "none";
            img1.Disabled = true;
            TextDateTo.Enabled = false;
            ddlSecTo.Enabled = false;
            imgbtnReOpen.Visible = false;

            EmployeeLoad();

            hiddenRoleAdd.Value = "0";
            hiddenRoleReOpen.Value = "0";
            hiddenRoleConfirm.Value = "0";
            hiddenfunReturn.Value = "0";
            hiddenstrid.Value = "0";
            hiddenHolidaychck.Value = "0";
            btnConfirm.Visible = false;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();


            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();

            currDateTime = objCommon.textToDateTime(strCurrentDate);
            int intUserId = 0, intUsrRolMstrId, intEnableReOpen, intEnableConfirm, intEnableAdd;


            if (Session["CORPOFFICEID"] != null)
            {
                HiddenFieldCorp.Value = Session["CORPOFFICEID"].ToString();

            }

            if (Session["ORGID"] != null)
            {
                HiddenFieldOrg.Value = Session["ORGID"].ToString();

            }

            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Leave_Allocation_Master);

            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

            //0041
            //START
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {                             clsCommonLibrary.CORP_GLOBAL.OFFDUTYDAYS_STATUS,                              
                                                             clsCommonLibrary.CORP_GLOBAL.LEVSTRTDT_OFFDUTYSTS,
                                                                clsCommonLibrary.CORP_GLOBAL.LEVSTRTDT_HOLIDAYSTS,
                                                                clsCommonLibrary.CORP_GLOBAL.LEVEND_OFFDUTYSTS,
                                                                clsCommonLibrary.CORP_GLOBAL.LEVEND_HOLIDAYSTS,
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer,Convert.ToInt32( HiddenFieldCorp.Value));
            if (dtCorpDetail.Rows.Count > 0)
            {
               
                HiddenOFfdaysSts.Value = dtCorpDetail.Rows[0]["OFFDUTYDAYS_STATUS"].ToString();
           //   HiddenOFfdaysSts.Value = "0";

                HiddenLevstrtdtholidaysts.Value = dtCorpDetail.Rows[0]["LEVSTRTDT_HOLIDAYSTS"].ToString();

                HiddenLevenddtholidaysts.Value = dtCorpDetail.Rows[0]["LEVEND_HOLIDAYSTS"].ToString();
                HiddenLevstrtdtoffdaysts.Value = dtCorpDetail.Rows[0]["LEVSTRTDT_OFFDUTYSTS"].ToString();

                HiddenLevenddtoffdaysts.Value = dtCorpDetail.Rows[0]["LEVEND_OFFDUTYSTS"].ToString();
                
            }



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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleReOpen.Value = intEnableReOpen.ToString();
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleConfirm.Value = intEnableConfirm.ToString();
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        //future

                    }

                }

            }


            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                img1.Disabled = false;

                Update(strId);
                lblEntry.Text = "Edit Leave Allocation Details";

            }

            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                img1.Disabled = true;

                View(strId);

                lblEntry.Text = "View Leave Allocation Details";
            }

            else
            {
                lblEntry.Text = "Add Leave Allocation Details";
                if (hiddenRoleAdd.Value != "")
                {
                    if (hiddenRoleAdd.Value == "1")
                    {
                        btnAdd.Visible = true;
                        btnAddClose.Visible = true;
                    }
                    else
                    {
                        btnCancel.Visible = true;
                        btnAdd.Visible = false;
                        btnAddClose.Visible = false;
                    }
                }

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;

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
                    else if (strInsUpd == "Cnfrm")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirm", "SuccessConfirm();", true);
                    }
                    else if (strInsUpd == "ReOpen")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReOpen", "SuccessReOpen();", true);
                    }
                    else if (strInsUpd == "InsDp")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "LeaveSmAllctd", "LeaveSmAllctd();", true);
                    }
                }
            }

            // created object for business layer for compare the date

           




        }
    }


    protected void EmployeeLoad()
    {
        clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
        clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
        int intUserId;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntLevAllocn.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntLevAllocn.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["USERID"] != null)
        {
            objEntLevAllocn.User_Id = Convert.ToInt32(Session["USERID"].ToString());

            intUserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable DtLevAlloDetails = new DataTable();
        DtLevAlloDetails = objBusLevAllocn.ReadEmployeedtl(objEntLevAllocn);

        if (DtLevAlloDetails.Rows.Count > 0)
        {
            ddlEmploye.DataSource = DtLevAlloDetails;
            ddlEmploye.DataValueField = "USR_ID";
            ddlEmploye.DataTextField = "USR_NAME";
            ddlEmploye.DataBind();

        }

        ddlEmploye.ClearSelection();
        ddlEmploye.Items.Insert(0, "--SELECT AN EMPLOYEE--");
        // ddlEmploye.Items.FindByText("--SELECT AN EMPLOYEE--").Selected = true;
        ScriptManager.RegisterStartupScript(this, GetType(), "ddlReload", "ddlReload();", true);
    }

    //protected void LeavTypLoad()
    //{
    //    clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
    //    clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
    //    int intUserId;
    //    if (Session["CORPOFFICEID"] != null)
    //    {
    //        objEntLevAllocn.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
    //    }
    //    else if (Session["CORPOFFICEID"] == null)
    //    {
    //        Response.Redirect("/Default.aspx");
    //    }
    //    if (Session["ORGID"] != null)
    //    {
    //        objEntLevAllocn.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
    //    }
    //    else if (Session["USERID"] != null)
    //    {
    //        objEntLevAllocn.User_Id = Convert.ToInt32(Session["USERID"].ToString());
    //        intUserId = Convert.ToInt32(Session["USERID"].ToString());
    //    }
    //    else
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    hiddenCurrentDate.Value = "01-01-2019";// strCurrentDate;
    //    if (ddlEmploye.SelectedItem.Value != "--SELECT AN EMPLOYEE--")
    //    {
    //        objEntLevAllocn.EmployeeId = Convert.ToInt32(ddlEmploye.SelectedItem.Value);
    //        DataTable DtUser = objBusLevAllocn.ReadUserDetailsGnUser(objEntLevAllocn);
    //        string UsrJoinDate = "", strJoinDate = "";
    //        if (DtUser.Rows.Count > 0)
    //        {
    //            strJoinDate = DtUser.Rows[0]["USR_JOINED_DATE"].ToString();



    //            DateTime dtLast_mnt_sal_processed = objCommon.textToDateTime("01-01-2019");
    //            DateTime dtLast_leave_settled_dt = objCommon.textToDateTime("01-01-2019");

    //            if (DtUser.Rows[0]["LAST_LEAVE_SETTLED_DT"].ToString() != "")
    //            {
    //                dtLast_leave_settled_dt = objCommon.textToDateTime(DtUser.Rows[0]["LAST_LEAVE_SETTLED_DT"].ToString());

    //            }

    //            if (DtUser.Rows[0]["LAST_MNT_SAL_PROCESSED"].ToString() != "")
    //            {
    //                dtLast_mnt_sal_processed = objCommon.textToDateTime(DtUser.Rows[0]["LAST_MNT_SAL_PROCESSED"].ToString());


    //            }
    //            if (dtLast_leave_settled_dt > dtLast_mnt_sal_processed)
    //            {
    //                hiddenCurrentDate.Value = dtLast_leave_settled_dt.ToString("dd-MM-yyyy");

    //            }
    //            else if (dtLast_leave_settled_dt < dtLast_mnt_sal_processed)
    //            {
    //                hiddenCurrentDate.Value = dtLast_mnt_sal_processed.ToString("dd-MM-yyyy");

    //            }
    //            else if (dtLast_leave_settled_dt == dtLast_mnt_sal_processed)
    //            {
    //                hiddenCurrentDate.Value = dtLast_mnt_sal_processed.ToString("dd-MM-yyyy");
    //            }



    //            if (strJoinDate == "")
    //            {
    //                DataTable DtgnUser = objBusLevAllocn.ReadUserDetails(objEntLevAllocn);
    //                if (DtgnUser.Rows.Count > 0)
    //                {
    //                    strJoinDate = DtgnUser.Rows[0]["USR_JOIN_DATE"].ToString();
    //                }
    //                if (strJoinDate != "")
    //                {
    //                    if ((objCommon.textToDateTime(strJoinDate) != DateTime.MinValue))
    //                    {
    //                        UsrJoinDate = strJoinDate;
    //                    }
    //                }
    //            }
    //            else if ((objCommon.textToDateTime(strJoinDate) == DateTime.MinValue))
    //            {
    //                DataTable DtgnUser = objBusLevAllocn.ReadUserDetails(objEntLevAllocn);
    //                if (DtgnUser.Rows.Count > 0)
    //                {
    //                    strJoinDate = DtgnUser.Rows[0]["USR_JOIN_DATE"].ToString();
    //                }
    //                if (strJoinDate != "")
    //                {
    //                    if ((objCommon.textToDateTime(strJoinDate) != DateTime.MinValue))
    //                    {
    //                        UsrJoinDate = strJoinDate;
    //                    }
    //                }
    //            }
    //            else
    //            {
    //                UsrJoinDate = strJoinDate;
    //            }

    //        }
    //        else
    //        {
    //            DataTable DtgnUser = objBusLevAllocn.ReadUserDetailsGnUser(objEntLevAllocn);
    //            if (DtgnUser.Rows.Count > 0)
    //            {
    //                strJoinDate = DtgnUser.Rows[0]["USR_JOIN_DATE"].ToString();
    //            }

    //            if (strJoinDate != "")
    //            {
    //                if ((objCommon.textToDateTime(strJoinDate) != DateTime.MinValue))
    //                {
    //                    UsrJoinDate = strJoinDate;
    //                }
    //            }
    //        }

    //        //  string UsrJoinDategnuser = DtUser.Rows[0]["EMPERDTL_JOIN_DATE"].ToString();
    //        //For experience

    //        clsBusiness_Leave_Type objBusinessLeave_Type = new clsBusiness_Leave_Type();
    //        clsEntity_Leave_Type objEntityLeave_Type = new clsEntity_Leave_Type();
    //        DataTable dtExpDtls = objBusinessLeave_Type.ReadExperienceByID(objEntityLeave_Type);
    //        decimal ExpYears = 0;
    //        int ExpChck = 0;
    //        if (UsrJoinDate != "")
    //        {

    //            DateTime Dob = objCommon.textToDateTime(UsrJoinDate);
    //            //ExpYears = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
    //            ExpYears = (currDateTime.Month - Dob.Month) + 12 * (currDateTime.Year - Dob.Year);
    //            ExpYears = ExpYears / 12;
    //            //if (ExpYears != 0)
    //            //{
    //            for (int intRowCount = 0; intRowCount < dtExpDtls.Rows.Count; intRowCount++)
    //            {
    //                int intMinYear = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["EXPMASTR_MIN_YEAR"]);
    //                int intMaxYear = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["EXPMASTR_MAX_YEAR"]);
    //                if (ExpYears >= intMinYear && ExpYears <= intMaxYear)
    //                {
    //                    ExpChck = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["LEAVDTLS_EXPMASTR_ID"]);
    //                }
    //            }
    //            // }

    //            //if (ExpYears >= 0 && ExpYears <= 2)
    //            //{
    //            //    ExpChck = 1;
    //            //}
    //            //else if (ExpYears >= 2 && ExpYears <= 4)
    //            //{
    //            //    ExpChck = 2;
    //            //}
    //            //else if (ExpYears >= 4 && ExpYears <= 6)
    //            //{
    //            //    ExpChck = 3;
    //            //}
    //            //else if (ExpYears >= 6 && ExpYears <= 8)
    //            //{
    //            //    ExpChck = 4;
    //            //}
    //            //else if (ExpYears >= 8 && ExpYears <= 10)
    //            //{
    //            //    ExpChck = 5;
    //            //}
    //            //else if (ExpYears >= 10 && ExpYears <= 15)
    //            //{
    //            //    ExpChck = 6;
    //            //}

    //            //else if (ExpYears >= 15 && ExpYears <= 20)
    //            //{
    //            //    ExpChck = 7;
    //            //}


    //        }


    //        DataTable DtLevAlloDetails = new DataTable();
    //        DtLevAlloDetails = objBusLevAllocn.ReadLeavTypdtl(objEntLevAllocn, ExpChck);
    //        if (DtLevAlloDetails.Rows.Count > 0)
    //        {
    //            ddlLeavTyp.DataSource = DtLevAlloDetails;
    //            ddlLeavTyp.DataValueField = "LEAVETYP_ID";
    //            ddlLeavTyp.DataTextField = "LEAVETYP_NAME";
    //            ddlLeavTyp.DataBind();

    //        }
    //        else
    //        {
    //            ddlLeavTyp.ClearSelection();
    //            ddlLeavTyp.Items.Clear();
    //            //  ddlLeavTyp.Items.Insert(0, "--SELECT LEAVE TYPE--");
    //            ScriptManager.RegisterStartupScript(this, GetType(), "EpmlyNotInUsr", "EpmlyNotInUsr();", true);

    //        }
    //        ddlLeavTyp.ClearSelection();
    //        // ddlLeavTyp.Items.Clear();
    //        ddlLeavTyp.Items.Insert(0, "--SELECT LEAVE TYPE--");
    //        ScriptManager.RegisterStartupScript(this, GetType(), "Autocomplete", "Autocomplete();", true);

    //    }
    //}

    protected void LeavTypLoad(string EmpId, string FromDate)
    {
        clsBusiness_Leave_Type objBusinessLeaveType = new clsBusiness_Leave_Type();
        clsEntity_Leave_Type objEntityLeaveType = new clsEntity_Leave_Type();

        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
        DateTime CurrentDate = objCommon.textToDateTime(strCurrentDate);

        StringBuilder sb = new StringBuilder();
        sb.Append("<option value=\"--SELECT LEAVE TYPE--\" selected=\"true\">--SELECT LEAVE TYPE--</option>");

        if (EmpId != "" && EmpId != "--SELECT AN EMPLOYEE--" && FromDate != "")
        {
            objEntityLeaveType.EmployeeId = Convert.ToInt32(EmpId);

            DataTable dt = objBusinessLeaveType.ReadEmpJoinDate(objEntityLeaveType);
            string UsrJoinDate = "";
            if (dt.Rows.Count > 0)
            {
                for (int intRowCount = 0; intRowCount < dt.Rows.Count; intRowCount++)
                {
                    if (dt.Rows[intRowCount]["TYPE"].ToString() == "USR_JOIN_DATE" && dt.Rows[intRowCount]["VALUE"].ToString() != "")
                    {
                        UsrJoinDate = dt.Rows[intRowCount]["VALUE"].ToString();
                    }
                    if (dt.Rows[intRowCount]["TYPE"].ToString() == "USR_EXPCTD_JOIN_DATE" && dt.Rows[intRowCount]["VALUE"].ToString() != "")
                    {
                        UsrJoinDate = dt.Rows[intRowCount]["VALUE"].ToString();
                    }
                }
            }

            DataTable dtExpDtls = objBusinessLeaveType.ReadExperienceByID(objEntityLeaveType);
            decimal ExpYears = 0;
            int ExpChck = 0;
            if (UsrJoinDate != "")
            {
                DateTime Dob = objCommon.textToDateTime(UsrJoinDate);

                ExpYears = (CurrentDate.Month - Dob.Month) + 12 * (CurrentDate.Year - Dob.Year);
                ExpYears = ExpYears / 12;

                for (int intRowCount = 0; intRowCount < dtExpDtls.Rows.Count; intRowCount++)
                {
                    int intMinYear = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["EXPMASTR_MIN_YEAR"]);
                    int intMaxYear = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["EXPMASTR_MAX_YEAR"]);
                    if (ExpYears >= intMinYear && ExpYears <= intMaxYear)
                    {
                        ExpChck = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["LEAVDTLS_EXPMASTR_ID"]);
                    }
                }
            }

            objEntityLeaveType.ExpMstrId = Convert.ToInt32(ExpChck);
            objEntityLeaveType.FromDate = objCommon.textToDateTime(FromDate);
            if (hiddenLeaveTypId.Value != "")
            {
                objEntityLeaveType.LeaveTypeMasterId = Convert.ToInt32(hiddenLeaveTypId.Value);
            }

            DataTable dtLeaveTypes = objBusinessLeaveType.ReadUserLeaveTypes(objEntityLeaveType);
            if (dtLeaveTypes.Rows.Count > 0)
            {
                ddlLeavTyp.DataSource = dtLeaveTypes;
                ddlLeavTyp.DataValueField = "LEAVETYP_ID";
                ddlLeavTyp.DataTextField = "LEAVETYP_NAME";
                ddlLeavTyp.DataBind();

            }
            else
            {
                ddlLeavTyp.ClearSelection();
                ddlLeavTyp.Items.Clear();
                ScriptManager.RegisterStartupScript(this, GetType(), "EpmlyNotInUsr", "EpmlyNotInUsr();", true);

            }
            ddlLeavTyp.ClearSelection();
            ddlLeavTyp.Items.Insert(0, "--SELECT LEAVE TYPE--");
            ScriptManager.RegisterStartupScript(this, GetType(), "Autocomplete", "Autocomplete();", true);
        }
    }

    [WebMethod]
    public static string LeavTypLoad(string CorpId, string OrgId, string EmpId, string FromDate, string LevTypId)
    {
        clsBusiness_Leave_Type objBusinessLeaveType = new clsBusiness_Leave_Type();
        clsEntity_Leave_Type objEntityLeaveType = new clsEntity_Leave_Type();

        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        string strResult = "";

        string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
        DateTime CurrentDate = objCommon.textToDateTime(strCurrentDate);

        StringBuilder sb = new StringBuilder();
        sb.Append("<option value=\"--SELECT LEAVE TYPE--\" selected=\"true\">--SELECT LEAVE TYPE--</option>");

        if (EmpId != "" && EmpId != "--SELECT AN EMPLOYEE--" && FromDate != "")
        {
            objEntityLeaveType.EmployeeId = Convert.ToInt32(EmpId);

            DataTable dt = objBusinessLeaveType.ReadEmpJoinDate(objEntityLeaveType);
            string UsrJoinDate = "";
            if (dt.Rows.Count > 0)
            {
                for (int intRowCount = 0; intRowCount < dt.Rows.Count; intRowCount++)
                {
                    if (dt.Rows[intRowCount]["TYPE"].ToString() == "USR_JOIN_DATE" && dt.Rows[intRowCount]["VALUE"].ToString() != "")
                    {
                        UsrJoinDate = dt.Rows[intRowCount]["VALUE"].ToString();
                    }
                    if (dt.Rows[intRowCount]["TYPE"].ToString() == "USR_EXPCTD_JOIN_DATE" && dt.Rows[intRowCount]["VALUE"].ToString() != "")
                    {
                        UsrJoinDate = dt.Rows[intRowCount]["VALUE"].ToString();
                    }
                }
            }

            DataTable dtExpDtls = objBusinessLeaveType.ReadExperienceByID(objEntityLeaveType);
            decimal ExpYears = 0;
            int ExpChck = 0;
            if (UsrJoinDate != "")
            {
                DateTime Dob = objCommon.textToDateTime(UsrJoinDate);

                ExpYears = (CurrentDate.Month - Dob.Month) + 12 * (CurrentDate.Year - Dob.Year);
                ExpYears = ExpYears / 12;

                for (int intRowCount = 0; intRowCount < dtExpDtls.Rows.Count; intRowCount++)
                {
                    int intMinYear = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["EXPMASTR_MIN_YEAR"]);
                    int intMaxYear = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["EXPMASTR_MAX_YEAR"]);
                    if (ExpYears >= intMinYear && ExpYears <= intMaxYear)
                    {
                        ExpChck = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["LEAVDTLS_EXPMASTR_ID"]);
                    }
                }
            }

            objEntityLeaveType.ExpMstrId = Convert.ToInt32(ExpChck);
            objEntityLeaveType.FromDate = objCommon.textToDateTime(FromDate);

            if (LevTypId != "")
            {
                objEntityLeaveType.LeaveTypeMasterId = Convert.ToInt32(LevTypId);
            }

            DataTable dtLeaveTypes = objBusinessLeaveType.ReadUserLeaveTypes(objEntityLeaveType);
            if (dtLeaveTypes.Rows.Count > 0)
            {
                foreach (DataRow dtRow in dtLeaveTypes.Rows)
                {
                    sb.Append("<option value=\"" + dtRow["LEAVETYP_ID"].ToString() + "\">" + dtRow["LEAVETYP_NAME"].ToString() + "</option>");
                }
            }
            else
            {
                sb.Append("EpmlyNotInUsr");
            }
        }

        strResult = sb.ToString();

        return strResult;
    }

    [WebMethod]
    public static string LevTypOverRideDate(string LevTypId, string EmpId)
    {
        string strResult = "";

        clsBusiness_Leave_Type objBusinessLeaveType = new clsBusiness_Leave_Type();
        clsEntity_Leave_Type objEntityLeaveType = new clsEntity_Leave_Type();

        objEntityLeaveType.EmployeeId = Convert.ToInt32(EmpId);
        objEntityLeaveType.LeaveTypeMasterId = Convert.ToInt32(LevTypId);

        DataTable dt = objBusinessLeaveType.ReadOverRideDtlsByLeaveTypId(objEntityLeaveType);
        if (dt.Rows.Count > 0)
        {
            strResult = dt.Rows[0]["EMPLEAVTYP_DATE"].ToString() + "_" + dt.Rows[0]["LEAVETYP_NAME"].ToString();
        }

        return strResult;
    }

    protected void ddlEmploye_SelectedIndexChanged(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "Autocomplete", "Autocomplete();", true);

        clsCommonLibrary objCommonLbry = new clsCommonLibrary();
        clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
        clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();

        NumOfLev.Text = "";
        YearlyLev.Text = "";

        if (ddlEmploye.SelectedItem.Value != "--SELECT AN EMPLOYEE--")
        {
            objEntLevAllocn.EmployeeId = Convert.ToInt32(ddlEmploye.SelectedItem.Value);
        }

        if (Session["CORPOFFICEID"] != null)
        {
            objEntLevAllocn.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntLevAllocn.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

        }

        DataTable dtCheckReportOffcr = objBusLevAllocn.CheckReportOffcr(objEntLevAllocn);
        bool HavingReportingOffcr = false;
        if (dtCheckReportOffcr.Rows.Count > 0)
        {
            if (dtCheckReportOffcr.Rows[0]["EMPREPORTING"].ToString() != "0")
            {
                HavingReportingOffcr = true;
            }
        }

        if (HavingReportingOffcr == true)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ddlSecToIndexChangedUpdatePanel", "ddlSecToIndexChangedUpdatePanel(0);", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ddlSecToIndexChangedUpdatePanel", "ddlSecToIndexChangedUpdatePanel(1);", true);
        }

        
     


    }

    //evm-0023-15-2
    protected void CtrlChanged(object sender, EventArgs e)
    {
        if (cbxStatus.Checked == true)
        {
            TextDateTo.Enabled = true;
            ddlSecTo.Enabled = true;

            img1.Disabled = false;
            hTodate.InnerHtml = "To Date*";
            hTosec.InnerHtml = "Session To*";
            ScriptManager.RegisterStartupScript(this, GetType(), "ddlSecToIndexChanged", "ddlSecToIndexChanged();", true);
        }
        else
        {

            TextDateTo.Text = "";
            ddlSecTo.ClearSelection();
            ddlSecTo.Items.FindByValue("0").Selected = true;
            hTodate.InnerHtml = "To Date";
            hTosec.InnerHtml = "Session To";
            img1.Disabled = true;
            TextDateTo.Enabled = false;
            ddlSecTo.Enabled = false;
            ScriptManager.RegisterStartupScript(this, GetType(), "ddlSecToIndexChanged", "ddlSecToIndexChanged();", true);
        }
        if (ddlEmploye.SelectedItem.Value != "--SELECT LEAVE TYPE--" && ddlEmploye.SelectedItem.Value != "" && txtDateFrom.Text != "")
        {
            LeavTypLoad(ddlEmploye.SelectedItem.Value, txtDateFrom.Text);
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        //EmployeeId User_Id
        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
        clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        decimal decHalfFrmday = 0, decHalfToDay = 0;
        DateTime dateCurnt;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntLevAllocn.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntLevAllocn.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntLevAllocn.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }




        if (ddlEmploye.SelectedItem.Value != "--SELECT AN EMPLOYEE--")
        {
            objEntLevAllocn.EmployeeId = Convert.ToInt32(ddlEmploye.SelectedItem.Value);
        }
        //if (ddlLeavTyp.SelectedItem.Value != "--SELECT LEAVE TYPE--")
        //{
        //    objEntLevAllocn.Leave_Id = Convert.ToInt32(ddlLeavTyp.SelectedItem.Value);
        //}
        if (hiddenLeaveTypId.Value != "")
        {
            objEntLevAllocn.Leave_Id = Convert.ToInt32(hiddenLeaveTypId.Value);
        }
        if (cbxSettlement.Checked)
        {
            objEntLevAllocn.PaidLvStatus = 1;
        }
        else
        {
            objEntLevAllocn.PaidLvStatus = 0;
        }

        if (cbxElgblLeavAllctn.Checked)
        {
            objEntLevAllocn.EilgiblLeaveAlloctnSts = 1;
        }
        else
        {
            objEntLevAllocn.EilgiblLeaveAlloctnSts = 0;
        }

        objEntLevAllocn.LeaveFrmDate = objCommon.textToDateTime(txtDateFrom.Text.Trim());
        dateCurnt = objEntLevAllocn.LeaveFrmDate;

        if (ddlSecnFrom.SelectedItem.Value != "--SELECT FROM--")
        {
            objEntLevAllocn.LeaveFromSection = Convert.ToInt32(ddlSecnFrom.SelectedItem.Value);
            if (objEntLevAllocn.LeaveFromSection != 1)
            {
                decHalfFrmday = Convert.ToDecimal(0.5);
            }
        }
        if (cbxStatus.Checked == true)
        {
            objEntLevAllocn.LeaveToDate = objCommon.textToDateTime(TextDateTo.Text.Trim());
        }
        else
        {
            objEntLevAllocn.LeaveToDate = DateTime.MinValue;

        }
        if (ddlSecTo.SelectedItem.Value != "--SELECT TO--")
        {
            objEntLevAllocn.LeaveToSection = Convert.ToInt32(ddlSecTo.SelectedItem.Value);
            if (objEntLevAllocn.LeaveToSection != 1)
            {
                decHalfToDay = Convert.ToDecimal(0.5);
            }
        }
        if (hiddennoofleave.Value != "")
        {
            objEntLevAllocn.NumOfLeave = Convert.ToDecimal(hiddennoofleave.Value);
        }

        //0039

        DataTable LeaveAllDtls = new DataTable();
        LeaveAllDtls = objBusLevAllocn.ReadLeaveAloctionDtls(objEntLevAllocn);
        int CountVal = Convert.ToInt32(LeaveAllDtls.Rows[0]["USERCOUNT"].ToString());

        //end



        int intFlag = 0;
        int intDupLeavFromDialyLeave = 0;
        int intDupLeavFromLeaveRequest = 0;
        int intDupLeavFromLeaveAllocation = 0;

        DateTime dateFrm, dateTo;


        DataTable datatableFrmChk;
        //datatableFrmChk = objBusLevAllocn.ChkDatesInLeavReqst(objEntLevAllocn);
        datatableFrmChk = objBusLevAllocn.CheckLeaveDates(objEntLevAllocn);
        if (datatableFrmChk.Rows.Count > 0)
        {
            intFlag++;

            DataRow[] drDialyLeave = datatableFrmChk.Select("LEAVE_DAILY_LEAVE = " + 1);
            DataRow[] drLeaveRequest = datatableFrmChk.Select("LEAVE_LVE_REQST_ID = " + 1);
            DataRow[] drLeaveAllocation = datatableFrmChk.Select("LEAVE_ALLOCATION = " + 1);

            intDupLeavFromDialyLeave = drDialyLeave.Length;
            intDupLeavFromLeaveRequest = drLeaveRequest.Length;
            intDupLeavFromLeaveAllocation = drLeaveAllocation.Length;
        }
        else
        {

            //  strFrmDate = objBusLevAllocn.FrmDate(objEntLevAllocn);
        }

        // DataTable dtCheckReportOffcr = new DataTable();
        DataTable dtCheckReportOffcr = objBusLevAllocn.CheckReportOffcr(objEntLevAllocn);
        bool HavingReportingOffcr = false;

        if (dtCheckReportOffcr.Rows.Count > 0)
        {
            if (dtCheckReportOffcr.Rows[0]["EMPREPORTING"].ToString() != "0")
            {
                HavingReportingOffcr = true;
            }
        }

        if (intFlag == 0 && HavingReportingOffcr == true && CountVal == 0)
        {
            objEntLevAllocn.OpeningLv = Convert.ToInt32(hiddenOpeningLev.Value);
            objBusLevAllocn.AddLeavAlloctnDetails(objEntLevAllocn);

            //Start:-Insert other leave types to GN_USER_LEAVE_TYPES

            clsBusiness_Leave_Type objBusinessLeaveType = new clsBusiness_Leave_Type();
            clsEntity_Leave_Type objEntityLeaveType = new clsEntity_Leave_Type();

            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
            DateTime CurrentDate = objCommon.textToDateTime(strCurrentDate);

            objEntityLeaveType.EmployeeId = objEntLevAllocn.EmployeeId;

            DataTable dt = objBusinessLeaveType.ReadEmpJoinDate(objEntityLeaveType);
            string UsrJoinDate = "";
            if (dt.Rows.Count > 0)
            {
                for (int intRowCount = 0; intRowCount < dt.Rows.Count; intRowCount++)
                {
                    if (dt.Rows[intRowCount]["TYPE"].ToString() == "USR_JOIN_DATE" && dt.Rows[intRowCount]["VALUE"].ToString() != "")
                    {
                        UsrJoinDate = dt.Rows[intRowCount]["VALUE"].ToString();
                    }
                    if (dt.Rows[intRowCount]["TYPE"].ToString() == "USR_EXPCTD_JOIN_DATE" && dt.Rows[intRowCount]["VALUE"].ToString() != "")
                    {
                        UsrJoinDate = dt.Rows[intRowCount]["VALUE"].ToString();
                    }
                }
            }

            DataTable dtExpDtls = objBusinessLeaveType.ReadExperienceByID(objEntityLeaveType);
            decimal ExpYears = 0;
            int ExpChck = 0;
            if (UsrJoinDate != "")
            {
                DateTime Dob = objCommon.textToDateTime(UsrJoinDate);

                ExpYears = (CurrentDate.Month - Dob.Month) + 12 * (CurrentDate.Year - Dob.Year);
                ExpYears = ExpYears / 12;

                for (int intRowCount = 0; intRowCount < dtExpDtls.Rows.Count; intRowCount++)
                {
                    int intMinYear = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["EXPMASTR_MIN_YEAR"]);
                    int intMaxYear = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["EXPMASTR_MAX_YEAR"]);
                    if (ExpYears >= intMinYear && ExpYears <= intMaxYear)
                    {
                        ExpChck = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["LEAVDTLS_EXPMASTR_ID"]);
                    }
                }
            }

            objEntityLeaveType.ExpMstrId = Convert.ToInt32(ExpChck);
            objEntityLeaveType.FromDate = objEntLevAllocn.LeaveFrmDate;

            DataTable dtLeaveTypes = objBusinessLeaveType.ReadUserLeaveTypes(objEntityLeaveType);

            //Stop:-Insert other leave types to GN_USER_LEAVE_TYPES


            if (cbxStatus.Checked == false)
            {
                string strremLeav = "";
                DataTable dataDt = objBusLevAllocn.ReadRemLeav(objEntLevAllocn);
                objEntLevAllocn.RemingLev = Convert.ToDecimal(hiddenFrmRem.Value);
                if (dataDt.Rows.Count > 0)
                {
                    strremLeav = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                }
                if (strremLeav == "")
                {
                    objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);//inserting all leavetypes of user if not present for the leave adding year
                }
                //Start:-Insert other leave types to GN_USER_LEAVE_TYPES            
                for (int i = 0; i < dtLeaveTypes.Rows.Count; i++)
                {
                    objEntLevAllocn.Leave_Id = Convert.ToInt32(dtLeaveTypes.Rows[i]["LEAVETYP_ID"].ToString());
                    string strchkuserlevCount = "0";
                    strchkuserlevCount = objBusLevAllocn.chkUserLevCount(objEntLevAllocn);
                    objEntLevAllocn.OpeningLv = Convert.ToDecimal(dtLeaveTypes.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                    objEntLevAllocn.RemingLev = Convert.ToDecimal(dtLeaveTypes.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                    if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                    {
                    }
                    else
                    {
                        objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                    }
                }
                //Stop:-Insert other leave types to GN_USER_LEAVE_TYPES

            }
            else
            {

                int intFromyr = 0, intToYr = 0;
                string strFrDate = txtDateFrom.Text.Trim().ToString();
                string[] Frmdt = strFrDate.Split('-');
                intFromyr = Convert.ToInt32(Frmdt[2]);
                string strToDate = TextDateTo.Text.Trim().ToString();
                string[] Todt = strToDate.Split('-');
                intToYr = Convert.ToInt32(Todt[2]);
                if (intFromyr == intToYr)
                {
                    string strremLeav = "";
                    DataTable dataDt = objBusLevAllocn.ReadRemLeav(objEntLevAllocn);
                    objEntLevAllocn.RemingLev = Convert.ToDecimal(hiddenFrmRem.Value);
                    if (dataDt.Rows.Count > 0)
                    {
                        strremLeav = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                    }
                    if (strremLeav == "")
                    {
                        objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                    }


                    //Start:-Insert other leave types to GN_USER_LEAVE_TYPES            
                    for (int i = 0; i < dtLeaveTypes.Rows.Count; i++)
                    {
                        objEntLevAllocn.Leave_Id = Convert.ToInt32(dtLeaveTypes.Rows[i]["LEAVETYP_ID"].ToString());
                        string strchkuserlevCount = "0";
                        strchkuserlevCount = objBusLevAllocn.chkUserLevCount(objEntLevAllocn);
                        objEntLevAllocn.OpeningLv = Convert.ToDecimal(dtLeaveTypes.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                        objEntLevAllocn.RemingLev = Convert.ToDecimal(dtLeaveTypes.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                        if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                        {
                        }
                        else
                        {
                            objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                        }
                    }
                    //Stop:-Insert other leave types to GN_USER_LEAVE_TYPES



                }
                else
                {

                    string strremLeavFrm = "", strremLeavTo = "";
                    DataTable dataDt = objBusLevAllocn.ReadRemLeav(objEntLevAllocn);
                    objEntLevAllocn.RemingLev = Convert.ToDecimal(hiddenFrmRem.Value);
                    if (dataDt.Rows.Count > 0)
                    {
                        strremLeavFrm = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                    }
                    if (strremLeavFrm == "")
                    {
                        objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                    }
                    objEntLevAllocn.LeaveFrmDate = objEntLevAllocn.LeaveToDate;
                    DataTable dataDtt = objBusLevAllocn.ReadRemLeav(objEntLevAllocn);
                    objEntLevAllocn.RemingLev = Convert.ToDecimal(hiddenToRem.Value);
                    if (dataDtt.Rows.Count > 0)
                    {
                        strremLeavTo = dataDtt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                    }
                    if (strremLeavTo == "")
                    {
                        objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                    }

                    //Start:-Insert other leave types to GN_USER_LEAVE_TYPES            
                    for (int i = 0; i < dtLeaveTypes.Rows.Count; i++)
                    {
                        string strchkuserlevCount = "0";
                        objEntLevAllocn.Leave_Id = Convert.ToInt32(dtLeaveTypes.Rows[i]["LEAVETYP_ID"].ToString());
                        objEntLevAllocn.OpeningLv = Convert.ToDecimal(dtLeaveTypes.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                        objEntLevAllocn.RemingLev = Convert.ToDecimal(dtLeaveTypes.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                        objEntLevAllocn.LeaveFrmDate = objCommon.textToDateTime(txtDateFrom.Text.Trim());
                        strchkuserlevCount = objBusLevAllocn.chkUserLevCount(objEntLevAllocn);
                        if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                        {
                        }
                        else
                        {
                            objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                        }
                        objEntLevAllocn.LeaveFrmDate = objEntLevAllocn.LeaveToDate;
                        strchkuserlevCount = "0";
                        strchkuserlevCount = objBusLevAllocn.chkUserLevCount(objEntLevAllocn);
                        if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                        {
                        }
                        else
                        {
                            objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                        }
                    }
                    //Stop:-Insert other leave types to GN_USER_LEAVE_TYPES
                }
            }

            if (clickedButton.ID == "btnAdd")
            {
                Response.Redirect("Leave_Allocation_Master.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("Leave_Allocation_Master_List.aspx?InsUpd=Ins");
            }
        }
        else if (intFlag != 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationLevDate", "DuplicationLevDate('" + intDupLeavFromDialyLeave + "','" + intDupLeavFromLeaveRequest + "', '" + intDupLeavFromLeaveAllocation + "');", true);
        }
        else if (HavingReportingOffcr == false)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "CheckReportingOfficer", "CheckReportingOfficer();", true);
        }
        //0039
        else if (CountVal != 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "LeaveSmAllctd", "LeaveSmAllctd();", true);
            //Response.Redirect("Leave_Allocation_Master.aspx?InsUpd=InsDp");
        }

        //LAAAAAAAAAAAAST




        ////If have
        //else
        //{
        //    if (strNameCount != "")
        //    {
        //        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);

        //    }

        //    if (strprocesscount != "" && strNameCount == "")
        //    {
        //        ScriptManager.RegisterStartupScript(this, GetType(), "SalaryProcessed", "SalaryProcessed();", true);

        //    }

        //}
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
        clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();

        Button clickedButton = sender as Button;
        decimal decHalfFrmday = 0, decHalfToDay = 0;
        DateTime dateCurnt;
        if (Request.QueryString["Id"] != null)
        {

            if (Session["CORPOFFICEID"] != null)
            {
                objEntLevAllocn.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntLevAllocn.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                objEntLevAllocn.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strHolId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntLevAllocn.LeavAllocn = Convert.ToInt32(strHolId);
            if (ddlEmploye.SelectedItem.Value != "--SELECT AN EMPLOYEE--")
            {
                objEntLevAllocn.EmployeeId = Convert.ToInt32(ddlEmploye.SelectedItem.Value);
            }
            //if (ddlLeavTyp.SelectedItem.Value != "--SELECT LEAVE TYPE--")
            //{
            //    objEntLevAllocn.Leave_Id = Convert.ToInt32(ddlLeavTyp.SelectedItem.Value);
            //}
            if (hiddenLeaveTypId.Value != "")
            {
                objEntLevAllocn.Leave_Id = Convert.ToInt32(hiddenLeaveTypId.Value);
            }
            objEntLevAllocn.LeaveFrmDate = objCommon.textToDateTime(txtDateFrom.Text.Trim());
            if (cbxSettlement.Checked)
            {
                objEntLevAllocn.PaidLvStatus = 1;
            }
            else
            {
                objEntLevAllocn.PaidLvStatus = 0;
            }
            if (cbxElgblLeavAllctn.Checked)
            {
                objEntLevAllocn.EilgiblLeaveAlloctnSts = 1;
            }
            else
            {
                objEntLevAllocn.EilgiblLeaveAlloctnSts = 0;
            }
            dateCurnt = objEntLevAllocn.LeaveFrmDate;
            if (ddlSecnFrom.SelectedItem.Value != "--SELECT FROM")
            {
                objEntLevAllocn.LeaveFromSection = Convert.ToInt32(ddlSecnFrom.SelectedItem.Value);
                if (objEntLevAllocn.LeaveFromSection != 1)
                {
                    decHalfFrmday = Convert.ToDecimal(0.5);
                }
            }
            if (cbxStatus.Checked == true)
            {
                objEntLevAllocn.LeaveToDate = objCommon.textToDateTime(TextDateTo.Text.Trim());
                if (ddlSecTo.SelectedItem.Value != "--SELECT TO--")
                {
                    objEntLevAllocn.LeaveToSection = Convert.ToInt32(ddlSecTo.SelectedItem.Value);
                    if (objEntLevAllocn.LeaveToSection != 1)
                    {
                        decHalfToDay = Convert.ToDecimal(0.5);
                    }
                }
            }
            else
            {
                objEntLevAllocn.LeaveToDate = DateTime.MinValue;

            }



            objEntLevAllocn.NumOfLeave = Convert.ToDecimal(hiddennoofleave.Value);





            int intFlag = 0;
            int intDupLeavFromDialyLeave = 0;
            int intDupLeavFromLeaveRequest = 0;
            int intDupLeavFromLeaveAllocation = 0;
            DateTime dateFrm, dateTo;


            DataTable datatableFrmChk;

            datatableFrmChk = objBusLevAllocn.CheckLeaveDates(objEntLevAllocn);
            if (datatableFrmChk.Rows.Count > 0)
            { intFlag++;

            DataRow[] drDialyLeave = datatableFrmChk.Select("LEAVE_DAILY_LEAVE = " + 1);
            DataRow[] drLeaveRequest = datatableFrmChk.Select("LEAVE_LVE_REQST_ID = " + 1);
            DataRow[] drLeaveAllocation = datatableFrmChk.Select("LEAVE_ALLOCATION = " + 1);

            intDupLeavFromDialyLeave = drDialyLeave.Length;
            intDupLeavFromLeaveRequest = drLeaveRequest.Length;
            intDupLeavFromLeaveAllocation = drLeaveAllocation.Length;

                //foreach (DataRow row in datatableFrmChk.Rows)
                //{
                //    if (row["LEAVE_FROM_DATE"].ToString() == objEntLevAllocn.LeaveFrmDate.ToString())
                //    {
                //        intFlag++;
                //        if (intFlag != 0)
                //        {
                //            break;
                //        }
                //    }
                //    if (row["LEAVE_TO_DATE"] != DBNull.Value && row["LEAVE_TO_DATE"].ToString() != null && row["LEAVE_TO_DATE"].ToString() != "")
                //    {

                //        dateFrm = objCommon.textToDateTime(row["LEAVE_FROM_DATE"].ToString());
                //        dateTo = objCommon.textToDateTime(row["LEAVE_TO_DATE"].ToString());
                //        if (dateCurnt >= dateFrm && dateCurnt <= dateTo)
                //        {
                //            intFlag++;
                //            if (intFlag != 0)
                //            {
                //                break;
                //            }
                //        }

                //    }



                //}
            }
            else
            {

                //  strFrmDate = objBusLevAllocn.FrmDate(objEntLevAllocn);
            }

            //DataTable dtCheckReportOffcr = new DataTable();
            DataTable dtCheckReportOffcr = objBusLevAllocn.CheckReportOffcr(objEntLevAllocn);
            bool HavingReportingOffcr = false;


            if (dtCheckReportOffcr.Rows.Count > 0)
            {
                if (dtCheckReportOffcr.Rows[0]["EMPREPORTING"].ToString() != "0")
                {
                    HavingReportingOffcr = true;
                }
            }


            //0039

            DataTable LeaveAllDtls = new DataTable();
            LeaveAllDtls = objBusLevAllocn.ReadLeaveAloctionDtls(objEntLevAllocn);
            int CountVal = Convert.ToInt32(LeaveAllDtls.Rows[0]["USERCOUNT"].ToString());

            //end

            if (intFlag == 0 && HavingReportingOffcr == true && CountVal == 0)
            {
                objBusLevAllocn.UpdateLeavAllocnDetls(objEntLevAllocn);

                //Start:-Insert other leave types to GN_USER_LEAVE_TYPES
                clsBusiness_Leave_Type objBusinessLeaveType = new clsBusiness_Leave_Type();
                clsEntity_Leave_Type objEntityLeaveType = new clsEntity_Leave_Type();

                string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
                DateTime CurrentDate = objCommon.textToDateTime(strCurrentDate);

                objEntityLeaveType.EmployeeId = objEntLevAllocn.EmployeeId;

                DataTable dt = objBusinessLeaveType.ReadEmpJoinDate(objEntityLeaveType);
                string UsrJoinDate = "";
                if (dt.Rows.Count > 0)
                {
                    for (int intRowCount = 0; intRowCount < dt.Rows.Count; intRowCount++)
                    {
                        if (dt.Rows[intRowCount]["TYPE"].ToString() == "USR_JOIN_DATE" && dt.Rows[intRowCount]["VALUE"].ToString() != "")
                        {
                            UsrJoinDate = dt.Rows[intRowCount]["VALUE"].ToString();
                        }
                        if (dt.Rows[intRowCount]["TYPE"].ToString() == "USR_EXPCTD_JOIN_DATE" && dt.Rows[intRowCount]["VALUE"].ToString() != "")
                        {
                            UsrJoinDate = dt.Rows[intRowCount]["VALUE"].ToString();
                        }
                    }
                }

                DataTable dtExpDtls = objBusinessLeaveType.ReadExperienceByID(objEntityLeaveType);
                decimal ExpYears = 0;
                int ExpChck = 0;
                if (UsrJoinDate != "")
                {
                    DateTime Dob = objCommon.textToDateTime(UsrJoinDate);

                    ExpYears = (CurrentDate.Month - Dob.Month) + 12 * (CurrentDate.Year - Dob.Year);
                    ExpYears = ExpYears / 12;

                    for (int intRowCount = 0; intRowCount < dtExpDtls.Rows.Count; intRowCount++)
                    {
                        int intMinYear = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["EXPMASTR_MIN_YEAR"]);
                        int intMaxYear = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["EXPMASTR_MAX_YEAR"]);
                        if (ExpYears >= intMinYear && ExpYears <= intMaxYear)
                        {
                            ExpChck = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["LEAVDTLS_EXPMASTR_ID"]);
                        }
                    }
                }

                objEntityLeaveType.ExpMstrId = Convert.ToInt32(ExpChck);
                objEntityLeaveType.FromDate = objEntLevAllocn.LeaveFrmDate;

                DataTable dtLeaveTypes = objBusinessLeaveType.ReadUserLeaveTypes(objEntityLeaveType);
                //Stop:-Insert other leave types to GN_USER_LEAVE_TYPES

                if (cbxStatus.Checked == false)
                {
                    string strremLeav = "";
                    DataTable dataDt = objBusLevAllocn.ReadRemLeav(objEntLevAllocn);
                    objEntLevAllocn.RemingLev = Convert.ToDecimal(hiddenFrmRem.Value);
                    if (dataDt.Rows.Count > 0)
                    {
                        strremLeav = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                    }
                    if (strremLeav == "")
                    {
                        objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);//inserting all leavetypes of user if not present for the leave adding year
                    }
                    //Start:-Insert other leave types to GN_USER_LEAVE_TYPES            
                    for (int i = 0; i < dtLeaveTypes.Rows.Count; i++)
                    {
                        objEntLevAllocn.Leave_Id = Convert.ToInt32(dtLeaveTypes.Rows[i]["LEAVETYP_ID"].ToString());
                        string strchkuserlevCount = "0";
                        strchkuserlevCount = objBusLevAllocn.chkUserLevCount(objEntLevAllocn);
                        objEntLevAllocn.OpeningLv = Convert.ToDecimal(dtLeaveTypes.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                        objEntLevAllocn.RemingLev = Convert.ToDecimal(dtLeaveTypes.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                        if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                        {
                        }
                        else
                        {
                            objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                        }
                    }
                    //Stop:-Insert other leave types to GN_USER_LEAVE_TYPES

                }
                else
                {

                    int intFromyr = 0, intToYr = 0;
                    string strFrDate = txtDateFrom.Text.Trim().ToString();
                    string[] Frmdt = strFrDate.Split('-');
                    intFromyr = Convert.ToInt32(Frmdt[2]);
                    string strToDate = TextDateTo.Text.Trim().ToString();
                    string[] Todt = strToDate.Split('-');
                    intToYr = Convert.ToInt32(Todt[2]);
                    if (intFromyr == intToYr)
                    {
                        string strremLeav = "";
                        DataTable dataDt = objBusLevAllocn.ReadRemLeav(objEntLevAllocn);
                        objEntLevAllocn.RemingLev = Convert.ToDecimal(hiddenFrmRem.Value);
                        if (dataDt.Rows.Count > 0)
                        {
                            strremLeav = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                        }
                        if (strremLeav == "")
                        {
                            objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                        }

                        //Start:-Insert other leave types to GN_USER_LEAVE_TYPES            
                        for (int i = 0; i < dtLeaveTypes.Rows.Count; i++)
                        {
                            objEntLevAllocn.Leave_Id = Convert.ToInt32(dtLeaveTypes.Rows[i]["LEAVETYP_ID"].ToString());
                            string strchkuserlevCount = "0";
                            strchkuserlevCount = objBusLevAllocn.chkUserLevCount(objEntLevAllocn);
                            objEntLevAllocn.OpeningLv = Convert.ToDecimal(dtLeaveTypes.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                            objEntLevAllocn.RemingLev = Convert.ToDecimal(dtLeaveTypes.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                            if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                            {
                            }
                            else
                            {
                                objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                            }
                        }
                        //Stop:-Insert other leave types to GN_USER_LEAVE_TYPES


                    }
                    else
                    {

                        string strremLeavFrm = "", strremLeavTo = "";
                        DataTable dataDt = objBusLevAllocn.ReadRemLeav(objEntLevAllocn);
                        objEntLevAllocn.RemingLev = Convert.ToDecimal(hiddenFrmRem.Value);
                        if (dataDt.Rows.Count > 0)
                        {
                            strremLeavFrm = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                        }
                        if (strremLeavFrm == "")
                        {
                            objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                        }
                        objEntLevAllocn.LeaveFrmDate = objEntLevAllocn.LeaveToDate;
                        DataTable dataDtt = objBusLevAllocn.ReadRemLeav(objEntLevAllocn);
                        objEntLevAllocn.RemingLev = Convert.ToDecimal(hiddenToRem.Value);
                        if (dataDtt.Rows.Count > 0)
                        {
                            strremLeavTo = dataDtt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                        }
                        if (strremLeavTo == "")
                        {
                            objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                        }


                        //Start:-Insert other leave types to GN_USER_LEAVE_TYPES            
                        for (int i = 0; i < dtLeaveTypes.Rows.Count; i++)
                        {
                            string strchkuserlevCount = "0";
                            objEntLevAllocn.Leave_Id = Convert.ToInt32(dtLeaveTypes.Rows[i]["LEAVETYP_ID"].ToString());
                            objEntLevAllocn.OpeningLv = Convert.ToDecimal(dtLeaveTypes.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                            objEntLevAllocn.RemingLev = Convert.ToDecimal(dtLeaveTypes.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                            objEntLevAllocn.LeaveFrmDate = objCommon.textToDateTime(txtDateFrom.Text.Trim());
                            strchkuserlevCount = objBusLevAllocn.chkUserLevCount(objEntLevAllocn);
                            if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                            {
                            }
                            else
                            {
                                objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                            }
                            objEntLevAllocn.LeaveFrmDate = objEntLevAllocn.LeaveToDate;
                            strchkuserlevCount = "0";
                            strchkuserlevCount = objBusLevAllocn.chkUserLevCount(objEntLevAllocn);
                            if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                            {
                            }
                            else
                            {
                                objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                            }
                        }
                        //Stop:-Insert other leave types to GN_USER_LEAVE_TYPES
                    }
                }


                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("Leave_Allocation_Master.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("Leave_Allocation_Master_List.aspx?InsUpd=Upd");
                }




                //If have
                //else
                //{
                //    if (strNameCount != "")
                //    {
                //  ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);

                // }
                //if (strprocesscount != "" && strNameCount == "")
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "SalaryProcessed", "SalaryProcessed();", true);

                //}
            }
            else if (intFlag != 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationLevDate", "DuplicationLevDate('" + intDupLeavFromDialyLeave + "','" + intDupLeavFromLeaveRequest + "', '" + intDupLeavFromLeaveAllocation + "');", true);
            }
            else if (HavingReportingOffcr == false)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "CheckReportingOfficer", "CheckReportingOfficer();", true);
            }
            //0039
            else if (CountVal != 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "LeaveSmAllctd", "LeaveSmAllctd();", true);
                //Response.Redirect("Leave_Allocation_Master.aspx?InsUpd=InsDp");
            }
        }
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
        clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        Button clickedButton = sender as Button;
        decimal decHalfFrmday = 0, decHalfToDay = 0;
        DateTime dateCurnt;
        if (Request.QueryString["Id"] != null)
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntLevAllocn.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntLevAllocn.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objEntLevAllocn.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntLevAllocn.LeavAllocn = Convert.ToInt32(strId);
            if (ddlEmploye.SelectedItem.Value != "--SELECT AN EMPLOYEE--")
            {
                objEntLevAllocn.EmployeeId = Convert.ToInt32(ddlEmploye.SelectedItem.Value);
            }
            //if (ddlLeavTyp.SelectedItem.Value != "--SELECT LEAVE TYPE--")
            //{
            //    objEntLevAllocn.Leave_Id = Convert.ToInt32(ddlLeavTyp.SelectedItem.Value);
            //}
            if (hiddenLeaveTypId.Value != "")
            {
                objEntLevAllocn.Leave_Id = Convert.ToInt32(hiddenLeaveTypId.Value);
            }
            objEntLevAllocn.LeaveFrmDate = objCommon.textToDateTime(txtDateFrom.Text.Trim());
            dateCurnt = objEntLevAllocn.LeaveFrmDate;
            if (ddlSecnFrom.SelectedItem.Value != "--SELECT FROM")
            {
                objEntLevAllocn.LeaveFromSection = Convert.ToInt32(ddlSecnFrom.SelectedItem.Value);
                if (objEntLevAllocn.LeaveFromSection != 1)
                {
                    decHalfFrmday = Convert.ToDecimal(0.5);
                }
            }
            if (cbxStatus.Checked == true)
            {
                objEntLevAllocn.LeaveToDate = objCommon.textToDateTime(TextDateTo.Text.Trim());
                if (ddlSecTo.SelectedItem.Value != "--SELECT TO--")
                {
                    objEntLevAllocn.LeaveToSection = Convert.ToInt32(ddlSecTo.SelectedItem.Value);
                    if (objEntLevAllocn.LeaveToSection != 1)
                    {
                        decHalfToDay = Convert.ToDecimal(0.5);
                    }
                }
            }
            else
            {
                objEntLevAllocn.LeaveToDate = DateTime.MinValue;
            }
            if (cbxSettlement.Checked)
            {
                objEntLevAllocn.PaidLvStatus = 1;
            }
            else
            {
                objEntLevAllocn.PaidLvStatus = 0;
            }
            if (cbxElgblLeavAllctn.Checked)
            {
                objEntLevAllocn.EilgiblLeaveAlloctnSts = 1;
            }
            else
            {
                objEntLevAllocn.EilgiblLeaveAlloctnSts =0 ;
            }
            objEntLevAllocn.NumOfLeave = Convert.ToDecimal(hiddennoofleave.Value);        
            DataTable dtCheckReportOffcr = objBusLevAllocn.CheckReportOffcr(objEntLevAllocn);
            bool HavingReportingOffcr =false;
            if (dtCheckReportOffcr.Rows.Count > 0)
            {
                if (dtCheckReportOffcr.Rows[0]["EMPREPORTING"].ToString() != "0")
                {
                    HavingReportingOffcr = true;
                }
            }
            if (HavingReportingOffcr == true)
            {
                DataTable datatableFrmChk = objBusLevAllocn.CheckLeaveDates(objEntLevAllocn);
                if (datatableFrmChk.Rows.Count == 0)
                {                  
                    //objBusLevAllocn.UpdateLeavAllocnDetls(objEntLevAllocn);
                    objEntLevAllocn.LeaveConfmn = 1;
                    objBusLevAllocn.ConfirmLeavAllocnDtl(objEntLevAllocn);

                    //Start:-Insert other leave types to GN_USER_LEAVE_TYPES
                    clsBusiness_Leave_Type objBusinessLeaveType = new clsBusiness_Leave_Type();
                    clsEntity_Leave_Type objEntityLeaveType = new clsEntity_Leave_Type();

                    string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
                    DateTime CurrentDate = objCommon.textToDateTime(strCurrentDate);

                    objEntityLeaveType.EmployeeId = objEntLevAllocn.EmployeeId;

                    DataTable dt = objBusinessLeaveType.ReadEmpJoinDate(objEntityLeaveType);
                    string UsrJoinDate = "";
                    if (dt.Rows.Count > 0)
                    {
                        for (int intRowCount = 0; intRowCount < dt.Rows.Count; intRowCount++)
                        {
                            if (dt.Rows[intRowCount]["TYPE"].ToString() == "USR_JOIN_DATE" && dt.Rows[intRowCount]["VALUE"].ToString() != "")
                            {
                                UsrJoinDate = dt.Rows[intRowCount]["VALUE"].ToString();
                            }
                            if (dt.Rows[intRowCount]["TYPE"].ToString() == "USR_EXPCTD_JOIN_DATE" && dt.Rows[intRowCount]["VALUE"].ToString() != "")
                            {
                                UsrJoinDate = dt.Rows[intRowCount]["VALUE"].ToString();
                            }
                        }
                    }

                    DataTable dtExpDtls = objBusinessLeaveType.ReadExperienceByID(objEntityLeaveType);
                    decimal ExpYears = 0;
                    int ExpChck = 0;
                    if (UsrJoinDate != "")
                    {
                        DateTime Dob = objCommon.textToDateTime(UsrJoinDate);

                        ExpYears = (CurrentDate.Month - Dob.Month) + 12 * (CurrentDate.Year - Dob.Year);
                        ExpYears = ExpYears / 12;

                        for (int intRowCount = 0; intRowCount < dtExpDtls.Rows.Count; intRowCount++)
                        {
                            int intMinYear = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["EXPMASTR_MIN_YEAR"]);
                            int intMaxYear = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["EXPMASTR_MAX_YEAR"]);
                            if (ExpYears >= intMinYear && ExpYears <= intMaxYear)
                            {
                                ExpChck = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["LEAVDTLS_EXPMASTR_ID"]);
                            }
                        }
                    }

                    objEntityLeaveType.ExpMstrId = Convert.ToInt32(ExpChck);
                    objEntityLeaveType.FromDate = objEntLevAllocn.LeaveFrmDate;

                    DataTable dtLeaveTypes = objBusinessLeaveType.ReadUserLeaveTypes(objEntityLeaveType);
                    //Stop:-Insert other leave types to GN_USER_LEAVE_TYPES
                    if (cbxStatus.Checked == false)
                    {
                        string strchkuserlevCount = "0";
                        strchkuserlevCount = objBusLevAllocn.chkUserLevCount(objEntLevAllocn);
                        decimal decRemainLeav = 0, decNoOfLeav = 0;
                        decNoOfLeav = Convert.ToDecimal(hiddennoofleave.Value);
                        decimal decOpngLev = Convert.ToDecimal(hiddenOpeningLev.Value);
                        objEntLevAllocn.OpeningLv = decOpngLev;
                        decRemainLeav = Convert.ToDecimal(hiddenremngNxtyrLv.Value);
                        decRemainLeav = decRemainLeav - decNoOfLeav;
                        objEntLevAllocn.RemingLev = decRemainLeav;
                        if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                        {
                            objBusLevAllocn.InsertUserLeavTyp(objEntLevAllocn);//updating balance leave of user
                        }
                        else
                        {
                            objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);//inserting all leavetypes of user if not present for the leave adding year
                        }
                        //Start:-Insert other leave types to GN_USER_LEAVE_TYPES            
                        for (int i = 0; i < dtLeaveTypes.Rows.Count; i++)
                        {
                            objEntLevAllocn.Leave_Id = Convert.ToInt32(dtLeaveTypes.Rows[i]["LEAVETYP_ID"].ToString());
                            strchkuserlevCount = "0";
                            strchkuserlevCount = objBusLevAllocn.chkUserLevCount(objEntLevAllocn);
                            objEntLevAllocn.OpeningLv = Convert.ToDecimal(dtLeaveTypes.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                            objEntLevAllocn.RemingLev = Convert.ToDecimal(dtLeaveTypes.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                            if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                            {
                            }
                            else
                            {
                                objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                            }
                        }
                        //Stop:-Insert other leave types to GN_USER_LEAVE_TYPES
                    }
                    else
                    {

                        int intFromyr = 0, intToYr = 0;
                        string strFrDate = txtDateFrom.Text.Trim().ToString();
                        string[] Frmdt = strFrDate.Split('-');
                        intFromyr = Convert.ToInt32(Frmdt[2]);
                        string strToDate = TextDateTo.Text.Trim().ToString();
                        string[] Todt = strToDate.Split('-');
                        intToYr = Convert.ToInt32(Todt[2]);
                        if (intFromyr == intToYr)
                        {
                            decimal decRemainLeav = 0, decNoOfLeav = 0;
                            decNoOfLeav = Convert.ToDecimal(hiddennoofleave.Value);
                            decimal decOpngLev = Convert.ToDecimal(hiddenOpeningLev.Value);
                            objEntLevAllocn.OpeningLv = decOpngLev;
                            decRemainLeav = Convert.ToDecimal(hiddenremngNxtyrLv.Value);
                            decRemainLeav = decRemainLeav - decNoOfLeav;
                            objEntLevAllocn.RemingLev = decRemainLeav;
                            string strchkuserlevCount = "0";
                            strchkuserlevCount = objBusLevAllocn.chkUserLevCount(objEntLevAllocn);
                            if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                            {
                                objBusLevAllocn.InsertUserLeavTyp(objEntLevAllocn);
                            }
                            else
                            {
                                objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                            }
                            //Start:-Insert other leave types to GN_USER_LEAVE_TYPES            
                            for (int i = 0; i < dtLeaveTypes.Rows.Count; i++)
                            {
                                objEntLevAllocn.Leave_Id = Convert.ToInt32(dtLeaveTypes.Rows[i]["LEAVETYP_ID"].ToString());
                                strchkuserlevCount = "0";
                                strchkuserlevCount = objBusLevAllocn.chkUserLevCount(objEntLevAllocn);
                                objEntLevAllocn.OpeningLv = Convert.ToDecimal(dtLeaveTypes.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                                objEntLevAllocn.RemingLev = Convert.ToDecimal(dtLeaveTypes.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                                if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                                {
                                }
                                else
                                {
                                    objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                                }
                            }
                            //Stop:-Insert other leave types to GN_USER_LEAVE_TYPES
                        }
                        else
                        {
                            string strchkFrmlevCount = "0", strchkTolevCount = "0";
                            decimal decRemainLeav = 0, decNoOfLeav = 0, decMthRemday = 0, decNxtYrLev = 0;
                            decNoOfLeav = Convert.ToDecimal(hiddennoofleave.Value);
                            decimal decOpngLev = Convert.ToDecimal(hiddenOpeningLev.Value);
                            objEntLevAllocn.OpeningLv = decOpngLev;
                            DateTime today = objEntLevAllocn.LeaveFrmDate;
                            int daysleft = new DateTime(today.Year, 12, 31).DayOfYear - today.DayOfYear;
                            daysleft = daysleft + 1;
                            decimal decFromdaysleft = daysleft - decHalfFrmday;
                            decMthRemday = decNoOfLeav - decFromdaysleft;
                            decNxtYrLev = decMthRemday - decHalfToDay;
                            strchkFrmlevCount = objBusLevAllocn.chkUserLevCount(objEntLevAllocn);
                            strchkTolevCount = objBusLevAllocn.chkUserToLevCount(objEntLevAllocn);
                            if (strchkFrmlevCount != "0" && strchkFrmlevCount != "")
                            {
                                decRemainLeav = Convert.ToDecimal(hiddenFrmRem.Value);
                                decRemainLeav = decRemainLeav - decFromdaysleft;
                                objEntLevAllocn.RemingLev = decRemainLeav;
                                objBusLevAllocn.InsertUserLeavTyp(objEntLevAllocn);
                            }
                            else
                            {
                                decRemainLeav = Convert.ToDecimal(hiddenFrmRem.Value);
                                decRemainLeav = decRemainLeav - decFromdaysleft;
                                objEntLevAllocn.RemingLev = decRemainLeav;
                                objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                            }
                            if (strchkTolevCount != "0" && strchkTolevCount != "")
                            {
                                decRemainLeav = Convert.ToDecimal(hiddenToRem.Value);
                                decRemainLeav = decRemainLeav - decNxtYrLev;
                                objEntLevAllocn.RemingLev = decRemainLeav;
                                //objEntLevAllocn.LeaveFrmDate = objEntLevAllocn.LeaveToDate;
                                objBusLevAllocn.InsertUserLeavTyp(objEntLevAllocn);
                            }
                            else
                            {
                                decRemainLeav = Convert.ToDecimal(hiddenToRem.Value);
                                decRemainLeav = decRemainLeav - decNxtYrLev;
                                objEntLevAllocn.RemingLev = decRemainLeav;
                                //objEntLevAllocn.LeaveFrmDate = objEntLevAllocn.LeaveToDate;
                                objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                            }

                            //Start:-Insert other leave types to GN_USER_LEAVE_TYPES            
                            for (int i = 0; i < dtLeaveTypes.Rows.Count; i++)
                            {
                                string strchkuserlevCount = "0";
                                objEntLevAllocn.Leave_Id = Convert.ToInt32(dtLeaveTypes.Rows[i]["LEAVETYP_ID"].ToString());
                                objEntLevAllocn.OpeningLv = Convert.ToDecimal(dtLeaveTypes.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                                objEntLevAllocn.RemingLev = Convert.ToDecimal(dtLeaveTypes.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                                objEntLevAllocn.LeaveFrmDate = objCommon.textToDateTime(txtDateFrom.Text.Trim());
                                strchkuserlevCount = objBusLevAllocn.chkUserLevCount(objEntLevAllocn);
                                if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                                {
                                }
                                else
                                {
                                    objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                                }
                                //objEntLevAllocn.LeaveFrmDate = objEntLevAllocn.LeaveToDate;
                                strchkuserlevCount = "0";
                                strchkuserlevCount = objBusLevAllocn.chkUserLevCount(objEntLevAllocn);
                                if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                                {
                                }
                                else
                                {
                                    objBusLevAllocn.InsertUserNewLevRow(objEntLevAllocn);
                                }
                            }
                            //Stop:-Insert other leave types to GN_USER_LEAVE_TYPES
                        }
                    }
                    clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
                    clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
                    objEntityLeavSettlmt.CorpId = objEntLevAllocn.Corporate_id;
                    DataTable dtCorpSal = objBusinessLeavSettlmt.ReadCorpSal(objEntityLeavSettlmt);
                    int BasicPayStatus = Convert.ToInt32(dtCorpSal.Rows[0]["BASIC_PAY"].ToString());
                    if (dtCorpSal.Rows[0]["COPRT_SALARY_DATE"].ToString() != "")
                    {
                        DateTime dtFinal = objCommon.textToDateTime(dtCorpSal.Rows[0]["COPRT_SALARY_DATE"].ToString());
                        if(objEntLevAllocn.LeaveFrmDate >=dtFinal || objEntLevAllocn.LeaveToDate>=dtFinal)
                            objBusLevAllocn.ArrearAmountUpd(objEntLevAllocn.EmployeeId, objEntLevAllocn.LeavAllocn, Convert.ToInt32(hiddenLeaveTypId.Value), objEntLevAllocn.Corporate_id, objEntLevAllocn.Organisation_id, objEntLevAllocn.LeaveFrmDate, objEntLevAllocn.LeaveToDate, objEntLevAllocn.LeaveFromSection, objEntLevAllocn.LeaveToSection, BasicPayStatus, dtCorpSal.Rows[0]["FIXED_PAYRL_MODE_JOIN"].ToString(), UsrJoinDate);
                    }
                    Response.Redirect("Leave_Allocation_Master.aspx?InsUpd=Cnfrm");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationConfm", "DuplicationConfm();", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "CheckReportingOfficer", "CheckReportingOfficer();", true);
            }
        }
    }

    protected void imgbtnReOpen_Click(object sender, ImageClickEventArgs e)
    {
        clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
        clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (Request.QueryString["Id"] != null)
        {

            if (Session["CORPOFFICEID"] != null)
            {
                objEntLevAllocn.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntLevAllocn.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                objEntLevAllocn.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }





            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntLevAllocn.LeavAllocn = Convert.ToInt32(strId);
            objEntLevAllocn.LeaveConfmn = 0;
            DataTable dtLeavDetail = objBusLevAllocn.ReadLevAllctnById(objEntLevAllocn);

            if (dtLeavDetail.Rows.Count > 0)
            {

                if (dtLeavDetail.Rows[0]["LEAVE_CNFRM_STS"].ToString() == "1")
                {

                    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                    DateTime dateFrm, dateTo, dateCurnt;
                    string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
                    dateCurnt = objCommon.textToDateTime(strCurrentDate);
                    int intFlag = 0;

                    if (dtLeavDetail.Rows[0]["LEAVE_TO_DATE"] == DBNull.Value && dtLeavDetail.Rows[0]["LEAVE_TO_DATE"].ToString() == null && dtLeavDetail.Rows[0]["LEAVE_TO_DATE"].ToString() == "")
                    {
                        dateFrm = objCommon.textToDateTime(dtLeavDetail.Rows[0]["LEAVE_FROM_DATE"].ToString());
                        if (dateCurnt >= dateFrm)
                        {
                            intFlag++;
                        }

                    }
                    //EVM 0041

                    //START
                    if (dtLeavDetail.Rows[0]["LEAVE_TO_DATE"] != DBNull.Value && dtLeavDetail.Rows[0]["LEAVE_TO_DATE"].ToString() != null && dtLeavDetail.Rows[0]["LEAVE_TO_DATE"].ToString() != "")
                    {
                        dateTo = objCommon.textToDateTime(dtLeavDetail.Rows[0]["LEAVE_TO_DATE"].ToString());
                        if (dateCurnt >= dateTo)
                        {
                            intFlag++;
                        }
                    }


                    if (intFlag == 0 || intFlag == 1)//END
                    {
                        string strdateT = "", strFrmyr = "", strToyr = "";
                        DateTime datetmeFrm, datetmeTo;
                        decimal decLeavNum = 0, decFrmSec, decToSec, decDiffrnce, decRemF = 0, decRemT = 0;
                        if (dtLeavDetail.Rows.Count > 0)
                        {
                            // strdateF=
                            objEntLevAllocn.EmployeeId = Convert.ToInt32(dtLeavDetail.Rows[0]["USR_ID"].ToString());
                            objEntLevAllocn.Leave_Id = Convert.ToInt32(dtLeavDetail.Rows[0]["LEAVETYP_ID"].ToString());
                            decFrmSec = Convert.ToDecimal(dtLeavDetail.Rows[0]["LEAVE_FROM_SCTN"].ToString());
                            decLeavNum = Convert.ToDecimal(dtLeavDetail.Rows[0]["LEAVE_NUM_DAYS"]);
                            datetmeFrm = objCommon.textToDateTime(dtLeavDetail.Rows[0]["LEAVE_FROM_DATE"].ToString());
                            strFrmyr = datetmeFrm.ToString("dd-MM-yyyy");
                            strdateT = dtLeavDetail.Rows[0]["LEAVE_TO_DATE"].ToString();
                            //objEntLevAllocn.RemingLev=decLeavNum;
                            objEntLevAllocn.LeaveFrmDate = datetmeFrm;
                            if (strdateT != "")
                            {

                                datetmeTo = objCommon.textToDateTime(dtLeavDetail.Rows[0]["LEAVE_TO_DATE"].ToString());
                                strToyr = datetmeTo.ToString("dd-MM-yyyy");
                                objEntLevAllocn.LeaveToDate = datetmeTo;
                                decToSec = Convert.ToDecimal(dtLeavDetail.Rows[0]["LEAVE_TO_SCTN"].ToString());
                                int intFromyr = 0, intToYr = 0;
                                string strFrDate = strFrmyr.ToString();
                                string[] Frmdt = strFrDate.Split('-');
                                intFromyr = Convert.ToInt32(Frmdt[2]);
                                string strToDate = strToyr.ToString();
                                string[] Todt = strToDate.Split('-');
                                intToYr = Convert.ToInt32(Todt[2]);
                                if (intFromyr == intToYr)
                                {
                                    objEntLevAllocn.LeaveFrmDate = datetmeFrm;

                                    objEntLevAllocn.RemingLev = decLeavNum;
                                    objBusLevAllocn.InsertReopnFrom(objEntLevAllocn);
                                }
                                else
                                {
                                    DateTime today = objEntLevAllocn.LeaveFrmDate;
                                    int daysleft = new DateTime(today.Year, 12, 31).DayOfYear - today.DayOfYear;
                                    daysleft = daysleft + 1;
                                    decRemF = Convert.ToDecimal(daysleft);
                                    decDiffrnce = decLeavNum - daysleft;
                                    if (decFrmSec != 1)
                                    {

                                        decRemF = decRemF - Convert.ToDecimal(0.5);
                                        objEntLevAllocn.RemingLev = decRemF;
                                        objBusLevAllocn.InsertReopnFrom(objEntLevAllocn);

                                    }
                                    else
                                    {

                                        objEntLevAllocn.RemingLev = decRemF;
                                        objBusLevAllocn.InsertReopnFrom(objEntLevAllocn);

                                    }
                                    if (decToSec != 1)
                                    {
                                        decRemT = decRemT + Convert.ToDecimal(0.5);
                                        objEntLevAllocn.RemingLev = decDiffrnce - decRemT;
                                        objEntLevAllocn.LeaveFrmDate = objEntLevAllocn.LeaveToDate;
                                        objBusLevAllocn.InsertReopnFrom(objEntLevAllocn);
                                    }
                                    else
                                    {

                                        objEntLevAllocn.RemingLev = decDiffrnce;
                                        objEntLevAllocn.LeaveFrmDate = objEntLevAllocn.LeaveToDate;
                                        objBusLevAllocn.InsertReopnFrom(objEntLevAllocn);

                                    }


                                }
                            }
                            else
                            {
                                //if (decFrmSec == 1)
                                //{
                                objEntLevAllocn.RemingLev = decLeavNum;

                                //}
                                //else
                                //{
                                //    objEntLevAllocn.RemingLev = (decLeavNum - Convert.ToDecimal(0.5));

                                //}
                                objBusLevAllocn.InsertReopnFrom(objEntLevAllocn);
                            }

                        }

                        objBusLevAllocn.ReOpenLeavAlloctn(objEntLevAllocn);

                        Response.Redirect("Leave_Allocation_Master.aspx?InsUpd=ReOpen");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ReOpenNotPossible", "ReOpenNotPossible();", true);

                    }


                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Already_ReOpened", "Already_ReOpened();", true);
                       
                }
            }

           
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("Leave_Allocation_Master.aspx");
    }

    public void Update(string strWId)
    {
        imgbtnReOpen.Visible = true;
        clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
        clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
        objEntLevAllocn.LeavAllocn = Convert.ToInt32(strWId);
        DataTable dtLeavDetail = new DataTable();
        dtLeavDetail = objBusLevAllocn.ReadLevAllctnById(objEntLevAllocn);
        clsCommonLibrary objCommon = new clsCommonLibrary();

       hiddenCurrentDate.Value = "01-01-2019";
     


  
        hiddenstrid.Value = strWId;



        //After fetch holiday details in datatable,we need to differentiate.
        if (dtLeavDetail.Rows.Count > 0)
        {


            DateTime dtLast_mnt_sal_processed = objCommon.textToDateTime("01-01-2019");
            DateTime dtLast_leave_settled_dt = objCommon.textToDateTime("01-01-2019");

            if (dtLeavDetail.Rows[0]["LAST_LEAVE_SETTLED_DT"].ToString() != "")
            {
                dtLast_leave_settled_dt = objCommon.textToDateTime(dtLeavDetail.Rows[0]["LAST_LEAVE_SETTLED_DT"].ToString());

            }

            if (dtLeavDetail.Rows[0]["LAST_MNT_SAL_PROCESSED"].ToString() != "")
            {
                dtLast_mnt_sal_processed = objCommon.textToDateTime(dtLeavDetail.Rows[0]["LAST_MNT_SAL_PROCESSED"].ToString());


            }
            if (dtLast_leave_settled_dt > dtLast_mnt_sal_processed)
            {
                hiddenCurrentDate.Value = dtLast_leave_settled_dt.ToString("dd-MM-yyyy");

            }
            else if (dtLast_leave_settled_dt < dtLast_mnt_sal_processed)
            {
                hiddenCurrentDate.Value = dtLast_mnt_sal_processed.ToString("dd-MM-yyyy");

            }
            else if (dtLast_leave_settled_dt == dtLast_mnt_sal_processed)
            {
                hiddenCurrentDate.Value = dtLast_mnt_sal_processed.ToString("dd-MM-yyyy");
            }





            if (dtLeavDetail.Rows[0]["LEAVE_TO_DATE"].ToString() != "")
            {
                cbxStatus.Checked = true;
                if (cbxStatus.Checked == true)
                {
                    TextDateTo.Enabled = true;
                    ddlSecTo.Enabled = true;
                }
                else
                {
                    TextDateTo.Enabled = false;
                    ddlSecTo.Enabled = false;
                }
            }
            if (dtLeavDetail.Rows[0]["LEAVE_SETTLEMNT_STATUS"].ToString() == "1")
            {
                cbxSettlement.Checked = true;
                DivFixedAllowance.Style["display"] = "block";
                divcbxSettlementleaveallocation.Style["display"] = "block";


                if (dtLeavDetail.Rows[0]["LEAVE_SETLMNT_ELIGIBLE_STS"].ToString() == "1")
                {
                    cbxElgblLeavAllctn.Checked = true;
                }
                else
                {
                    cbxElgblLeavAllctn.Checked = false;
                }
            }
            else if (dtLeavDetail.Rows[0]["LEAVE_SETTLEMNT_STATUS"].ToString() == "0")
            {
                cbxSettlement.Checked = false;
                DivFixedAllowance.Style["display"] = "none";
                divcbxSettlementleaveallocation.Style["display"] = "none";

                if (dtLeavDetail.Rows[0]["LEAVETYPDTLS_SETTLMTSTS"].ToString() == "1")
                {
                    DivFixedAllowance.Style["display"] = "block";
                }
            } 


            if (dtLeavDetail.Rows[0]["USR_ID"].ToString() != "" && dtLeavDetail.Rows[0]["USR_STATUS"].ToString() == "1")
            {
                ddlEmploye.ClearSelection();
                ddlEmploye.Items.FindByValue(dtLeavDetail.Rows[0]["USR_ID"].ToString()).Selected = true;
            }
            else
            {

                ListItem lstGrp = new ListItem(dtLeavDetail.Rows[0]["USR_NAME"].ToString(), dtLeavDetail.Rows[0]["USR_ID"].ToString());
                ddlEmploye.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlEmploye);

                ddlEmploye.Items.FindByValue(dtLeavDetail.Rows[0]["USR_ID"].ToString()).Selected = true;
                string a = dtLeavDetail.Rows[0]["USR_ID"].ToString();
            }

            hiddenLeaveTypId.Value = dtLeavDetail.Rows[0]["LEAVETYP_ID"].ToString();
            LeavTypLoad(dtLeavDetail.Rows[0]["USR_ID"].ToString(), dtLeavDetail.Rows[0]["LEAVE_FROM_DATE"].ToString());
            if (dtLeavDetail.Rows[0]["LEAVETYP_ID"].ToString() != "" && dtLeavDetail.Rows[0]["LEAVETYP_STATUS"].ToString() == "1")
            {
                if (ddlLeavTyp.Items.FindByValue(dtLeavDetail.Rows[0]["LEAVETYP_ID"].ToString()) != null)
                {
                    ddlLeavTyp.Items.FindByValue(dtLeavDetail.Rows[0]["LEAVETYP_ID"].ToString()).Selected = true;
                }
            }
            else
            {

                ListItem lstGrp = new ListItem(dtLeavDetail.Rows[0]["LEAVETYP_NAME"].ToString(), dtLeavDetail.Rows[0]["LEAVETYP_ID"].ToString());
                ddlLeavTyp.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlLeavTyp);

                ddlLeavTyp.Items.FindByValue(dtLeavDetail.Rows[0]["LEAVETYP_ID"].ToString()).Selected = true;
            }

            txtDateFrom.Text = dtLeavDetail.Rows[0]["LEAVE_FROM_DATE"].ToString();
            objEntLevAllocn.LeaveFrmDate = objCommon.textToDateTime(dtLeavDetail.Rows[0]["LEAVE_FROM_DATE"].ToString());
            ddlSecnFrom.Items.FindByValue(dtLeavDetail.Rows[0]["LEAVE_FROM_SCTN"].ToString()).Selected = true;
            if (cbxStatus.Checked == true)
            {
                TextDateTo.Text = dtLeavDetail.Rows[0]["LEAVE_TO_DATE"].ToString();
                objEntLevAllocn.LeaveToDate = objCommon.textToDateTime(dtLeavDetail.Rows[0]["LEAVE_TO_DATE"].ToString());
                ddlSecTo.Items.FindByValue(dtLeavDetail.Rows[0]["LEAVE_TO_SCTN"].ToString()).Selected = true;


                //override date
                clsBusiness_Leave_Type objBusinessLeaveType = new clsBusiness_Leave_Type();
                clsEntity_Leave_Type objEntityLeaveType = new clsEntity_Leave_Type();
                objEntityLeaveType.EmployeeId = Convert.ToInt32(dtLeavDetail.Rows[0]["USR_ID"].ToString());
                objEntityLeaveType.LeaveTypeMasterId = Convert.ToInt32(dtLeavDetail.Rows[0]["LEAVETYP_ID"].ToString());

                DataTable dt = objBusinessLeaveType.ReadOverRideDtlsByLeaveTypId(objEntityLeaveType);
                if (dt.Rows.Count > 0)
                {
                    hiddenOverRidedLeavTyp.Value = dt.Rows[0]["LEAVETYP_NAME"].ToString();
                    hiddenOverRideLeavTypDate.Value = dt.Rows[0]["EMPLEAVTYP_DATE"].ToString();
                }
            }

            //clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
            //clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();

            //DataTable dtLevSettl = objBusinessLeavSettlmt.ReadLeavSettlmt(objEntityLeavSettlmt);

            //for (int intColumnBodyCountLev = 0; intColumnBodyCountLev < dtLevSettl.Rows.Count; intColumnBodyCountLev++)
            //{
            //    if (dtLevSettl.Rows[intColumnBodyCountLev]["USR_ID"].ToString() == dtLeavDetail.Rows[0]["USR_ID"].ToString())
            //    {
            //        imgbtnReOpen.Visible = false;
            //    }

            //}

            try
            {
                DateTime dateFromDate = objCommon.textToDateTime(dtLeavDetail.Rows[0]["LEAVE_FROM_DATE"].ToString());

                //if (hiddenCurrentDate.Value == "")
                //{
                //    clsBusinessLayer objBusinessLayer2 = new clsBusinessLayer();
                //    string strCurrentDate = objBusinessLayer2.LoadCurrentDateInString();
                //    hiddenCurrentDate.Value = "01-01-2019";// strCurrentDate;
                //}
               // DateTime dateCurrentDate = objCommon.textToDateTime(hiddenCurrentDate.Value);

                if (dtLeavDetail.Rows[0]["PROCESSED_COUNT"].ToString()!="0")
                {
                     imgbtnReOpen.Visible = false;
                }

                if (dtLeavDetail.Rows[0]["LEAVE_SETTLED_COUNT"].ToString() != "0")
                {
                    imgbtnReOpen.Visible = false;
                }



                //if (dateCurrentDate.Date >= dateFromDate.Date)
                //{
                //    //txtDateFrom.Enabled = false;
                //   //imgDate.Disabled = true;

                //    //PROCESSED_COUNT

                //    if (cbxStatus.Checked == false)
                //    {
                //        imgbtnReOpen.Visible = false;
                //    }
                //}
                //if (cbxStatus.Checked == true)
                //{
                //    if (objEntLevAllocn.LeaveToDate != DateTime.MinValue)
                //    {
                //        if (dateCurrentDate.Date >= objEntLevAllocn.LeaveToDate.Date)
                //        {
                //            imgbtnReOpen.Visible = false;
                //        }
                //    }
                //}

            }
            catch (Exception)
            {

                throw;
            }



            NumOfLev.Text = dtLeavDetail.Rows[0]["LEAVE_NUM_DAYS"].ToString();
            hiddennoofleave.Value = dtLeavDetail.Rows[0]["LEAVE_NUM_DAYS"].ToString();

            objEntLevAllocn.EmployeeId = Convert.ToInt32(dtLeavDetail.Rows[0]["USR_ID"].ToString());
            objEntLevAllocn.Leave_Id = Convert.ToInt32(dtLeavDetail.Rows[0]["LEAVETYP_ID"].ToString());
            if (cbxStatus.Checked == false)
            {
                string strremLeav = "";
                DataTable dataDt = objBusLevAllocn.ReadRemLeav(objEntLevAllocn);

                if (dataDt.Rows.Count > 0)
                {
                    strremLeav = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                    hiddenFrmRem.Value = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                    hiddenremngNxtyrLv.Value = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();

                    hiddenOpeningLev.Value = dataDt.Rows[0]["OPENING_NUMLEAVE"].ToString();

                }
                if (strremLeav != "")
                {
                    YearlyLev.Text = strremLeav;
                }


            }
            else
            {

                int intFromyr = 0, intToYr = 0;
                string strFrDate = txtDateFrom.Text.Trim().ToString();
                string[] Frmdt = strFrDate.Split('-');
                intFromyr = Convert.ToInt32(Frmdt[2]);
                string strToDate = TextDateTo.Text.Trim().ToString();
                string[] Todt = strToDate.Split('-');
                intToYr = Convert.ToInt32(Todt[2]);
                if (intFromyr == intToYr)
                {
                    string strremLeav = "";
                    DataTable dataDt = objBusLevAllocn.ReadRemLeav(objEntLevAllocn);

                    if (dataDt.Rows.Count > 0)
                    {
                        strremLeav = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                        hiddenFrmRem.Value = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                        hiddenremngNxtyrLv.Value = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                        hiddenOpeningLev.Value = dataDt.Rows[0]["OPENING_NUMLEAVE"].ToString();
                    }
                    if (strremLeav != "")
                    {
                        YearlyLev.Text = strremLeav;
                    }

                }
                else
                {

                    decimal decYrlyLevFrm = 0, decYrlyLevTo = 0, decTotalYr = 0;
                    string strremLeavFrm = "", strremLeavTo = "";
                    DataTable dataDt = objBusLevAllocn.ReadRemLeav(objEntLevAllocn);

                    if (dataDt.Rows.Count > 0)
                    {
                        strremLeavFrm = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                        hiddenFrmRem.Value = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                        hiddenOpeningLev.Value = dataDt.Rows[0]["OPENING_NUMLEAVE"].ToString();

                    }
                    if (strremLeavFrm != "")
                    {
                        decYrlyLevFrm = Convert.ToDecimal(strremLeavFrm);
                    }
                    else
                    {
                        decYrlyLevFrm = Convert.ToInt32(dataDt.Rows[0]["OPENING_NUMLEAVE"].ToString());
                    }
                    objEntLevAllocn.LeaveFrmDate = objEntLevAllocn.LeaveToDate;
                    DataTable dataDtt = objBusLevAllocn.ReadRemLeav(objEntLevAllocn);

                    if (dataDtt.Rows.Count > 0)
                    {
                        strremLeavTo = dataDtt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                        hiddenToRem.Value = dataDtt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                        hiddenOpeningLev.Value = dataDtt.Rows[0]["OPENING_NUMLEAVE"].ToString();

                    }
                    if (strremLeavTo != "")
                    {
                        decYrlyLevTo = Convert.ToDecimal(strremLeavTo);
                    }
                    else
                    {
                        if (dataDtt.Rows.Count > 0)
                        {
                            decYrlyLevTo = Convert.ToDecimal(dataDtt.Rows[0]["OPENING_NUMLEAVE"].ToString());
                        }
                    }
                    decTotalYr = decYrlyLevFrm + decYrlyLevTo;
                    // intTotalYr = intTotalYr;
                    YearlyLev.Text = decTotalYr.ToString();
                }
            }
            hiddenConfirmSts.Value = "0";
            if (hiddenRoleReOpen.Value != "")
            {
                if (hiddenRoleReOpen.Value == "1")
                {
                    if (dtLeavDetail.Rows[0]["LEAVE_CNFRM_STS"].ToString() == "1")
                    {

                        hiddenConfirmSts.Value = "1";

                        ddlEmploye.Enabled = false;
                        ddlLeavTyp.Enabled = false;
                        txtDateFrom.Enabled = false;
                        ddlSecnFrom.Enabled = false;
                        cbxStatus.Enabled = false;
                        TextDateTo.Enabled = false;
                        ddlSecTo.Enabled = false;
                        img1.Disabled = true;
                        imgDate.Disabled = true;
                        //Mod0012
                       // imgbtnReOpen.Visible = true;
                    }
                    else
                    {
                        imgbtnReOpen.Visible = false;
                    }
                }
                else
                {
                    if (dtLeavDetail.Rows[0]["LEAVE_CNFRM_STS"].ToString() == "1")
                    {
                        ddlEmploye.Enabled = false;
                        ddlLeavTyp.Enabled = false;
                        txtDateFrom.Enabled = false;
                        ddlSecnFrom.Enabled = false;
                        cbxStatus.Enabled = false;
                        TextDateTo.Enabled = false;
                        ddlSecTo.Enabled = false;
                        imgbtnReOpen.Visible = false;
                    }

                }

            }


        }


        if (hiddenRoleConfirm.Value == "1")
        {

            if (dtLeavDetail.Rows[0]["LEAVE_CNFRM_STS"].ToString() == "1")
            {
                btnConfirm.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                //  imgbtnReOpen.Visible = true;
            }
            else
            {
                //imgbtnReOpen.Visible = false;
                btnConfirm.Visible = true;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = true;
            }
        }
        else
        {
            if (dtLeavDetail.Rows[0]["LEAVE_CNFRM_STS"].ToString() == "0")
            {
                btnConfirm.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
            }
            else
            {
                btnConfirm.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = true;
            }
        }


        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Leave_Allocation_Master);
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
            }
        }
        if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            if (dtLeavDetail.Rows[0]["LEAVE_CNFRM_STS"].ToString() == "1")
            {
                btnUpdate.Visible = false;
            }
            else
            {
                btnUpdate.Visible = true;
            }

        }
        else
        {

            btnUpdate.Visible = false;

        }







        btnClear.Visible = false;
        btnAdd.Visible = false;
        btnAddClose.Visible = false;

    }
    private void SortDDL(ref DropDownList objDDL)
    {
        System.Collections.ArrayList textList = new System.Collections.ArrayList();
        System.Collections.ArrayList valueList = new System.Collections.ArrayList();


        foreach (ListItem li in objDDL.Items)
        {
            textList.Add(li.Text);
        }

        textList.Sort();


        foreach (object item in textList)
        {
            string value = objDDL.Items.FindByText(item.ToString()).Value;
            valueList.Add(value);
        }
        objDDL.Items.Clear();

        for (int i = 0; i < textList.Count; i++)
        {
            ListItem objItem = new ListItem(textList[i].ToString(), valueList[i].ToString());
            objDDL.Items.Add(objItem);
        }
    }

    public void View(string strWId)
    {

        clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
        clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
        objEntLevAllocn.LeavAllocn = Convert.ToInt32(strWId);
        clsCommonLibrary objCommon = new clsCommonLibrary();
        DataTable dtLeavDetail = new DataTable();
        dtLeavDetail = objBusLevAllocn.ReadLevAllctnById(objEntLevAllocn);


        if (dtLeavDetail.Rows.Count > 0)
        {


            if (dtLeavDetail.Rows[0]["LEAVE_TO_DATE"].ToString() != "")
            {
                cbxStatus.Checked = true;
                if (cbxStatus.Checked == true)
                {
                    TextDateTo.Enabled = true;
                    ddlSecTo.Enabled = true;
                }
                else
                {
                    TextDateTo.Enabled = false;
                    ddlSecTo.Enabled = false;
                }
            }



            if (dtLeavDetail.Rows[0]["USR_ID"].ToString() != "" && dtLeavDetail.Rows[0]["USR_STATUS"].ToString() == "1")
            {
                ddlEmploye.ClearSelection();
                ddlEmploye.Items.FindByValue(dtLeavDetail.Rows[0]["USR_ID"].ToString()).Selected = true;
            }
            else
            {

                ListItem lstGrp = new ListItem(dtLeavDetail.Rows[0]["USR_NAME"].ToString(), dtLeavDetail.Rows[0]["USR_ID"].ToString());
                ddlEmploye.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlEmploye);

                ddlEmploye.Items.FindByValue(dtLeavDetail.Rows[0]["USR_ID"].ToString()).Selected = true;
            }

            hiddenLeaveTypId.Value = dtLeavDetail.Rows[0]["LEAVETYP_ID"].ToString();
            LeavTypLoad(dtLeavDetail.Rows[0]["USR_ID"].ToString(), dtLeavDetail.Rows[0]["LEAVE_FROM_DATE"].ToString());
            if (dtLeavDetail.Rows[0]["LEAVETYP_ID"].ToString() != "" && dtLeavDetail.Rows[0]["LEAVETYP_STATUS"].ToString() == "1")
            {
                ddlLeavTyp.Items.FindByValue(dtLeavDetail.Rows[0]["LEAVETYP_ID"].ToString()).Selected = true;
            }
            else
            {

                ListItem lstGrp = new ListItem(dtLeavDetail.Rows[0]["LEAVETYP_NAME"].ToString(), dtLeavDetail.Rows[0]["LEAVETYP_ID"].ToString());
                ddlLeavTyp.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlLeavTyp);

                ddlLeavTyp.Items.FindByValue(dtLeavDetail.Rows[0]["LEAVETYP_ID"].ToString()).Selected = true;
            }

            txtDateFrom.Text = dtLeavDetail.Rows[0]["LEAVE_FROM_DATE"].ToString();
            objEntLevAllocn.LeaveFrmDate = objCommon.textToDateTime(dtLeavDetail.Rows[0]["LEAVE_FROM_DATE"].ToString());
            ddlSecnFrom.Items.FindByValue(dtLeavDetail.Rows[0]["LEAVE_FROM_SCTN"].ToString()).Selected = true;
            if (cbxStatus.Checked == true)
            {
                TextDateTo.Text = dtLeavDetail.Rows[0]["LEAVE_TO_DATE"].ToString();
                objEntLevAllocn.LeaveToDate = objCommon.textToDateTime(dtLeavDetail.Rows[0]["LEAVE_TO_DATE"].ToString());
                ddlSecTo.Items.FindByValue(dtLeavDetail.Rows[0]["LEAVE_TO_SCTN"].ToString()).Selected = true;
            }
            NumOfLev.Text = dtLeavDetail.Rows[0]["LEAVE_NUM_DAYS"].ToString();

            objEntLevAllocn.EmployeeId = Convert.ToInt32(dtLeavDetail.Rows[0]["USR_ID"].ToString());
            objEntLevAllocn.Leave_Id = Convert.ToInt32(dtLeavDetail.Rows[0]["LEAVETYP_ID"].ToString());

            if (cbxStatus.Checked == false)
            {
                string strremLeav = "";
                DataTable dataDt = objBusLevAllocn.ReadRemLeav(objEntLevAllocn);

                if (dataDt.Rows.Count > 0)
                {
                    strremLeav = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                }
                if (strremLeav != "")
                {
                    YearlyLev.Text = strremLeav;
                }


            }
            else
            {

                int intFromyr = 0, intToYr = 0;
                string strFrDate = txtDateFrom.Text.Trim().ToString();
                string[] Frmdt = strFrDate.Split('-');
                intFromyr = Convert.ToInt32(Frmdt[2]);
                string strToDate = TextDateTo.Text.Trim().ToString();
                string[] Todt = strToDate.Split('-');
                intToYr = Convert.ToInt32(Todt[2]);
                if (intFromyr == intToYr)
                {
                    string strremLeav = "";
                    DataTable dataDt = objBusLevAllocn.ReadRemLeav(objEntLevAllocn);

                    if (dataDt.Rows.Count > 0)
                    {
                        strremLeav = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                    }
                    if (strremLeav != "")
                    {
                        YearlyLev.Text = strremLeav;
                    }

                }
                else
                {
                    int intYrlyLevFrm = 0, intYrlyLevTo = 0, intTotalYr = 0;
                    string strremLeavFrm = "", strremLeavTo = "";
                    DataTable dataDt = objBusLevAllocn.ReadRemLeav(objEntLevAllocn);

                    if (dataDt.Rows.Count > 0)
                    {
                        strremLeavFrm = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                    }
                    if (strremLeavFrm != "")
                    {
                        intYrlyLevFrm = Convert.ToInt32(strremLeavFrm);
                    }
                    else
                    {
                        intYrlyLevFrm = Convert.ToInt32(dataDt.Rows[0]["OPENING_NUMLEAVE"].ToString());
                    }
                    objEntLevAllocn.LeaveFrmDate = objEntLevAllocn.LeaveToDate;
                    DataTable dataDtt = objBusLevAllocn.ReadRemLeav(objEntLevAllocn);

                    if (dataDtt.Rows.Count > 0)
                    {
                        strremLeavTo = dataDtt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                    }
                    if (strremLeavTo != "")
                    {
                        intYrlyLevTo = Convert.ToInt32(strremLeavTo);
                    }
                    else
                    {
                        intYrlyLevTo = Convert.ToInt32(dataDtt.Rows[0]["OPENING_NUMLEAVE"].ToString());
                    }
                    intTotalYr = intYrlyLevFrm + intYrlyLevTo;
                    YearlyLev.Text = intTotalYr.ToString();
                }
            }


        }

        ddlEmploye.Enabled = false;
        ddlLeavTyp.Enabled = false;
        txtDateFrom.Enabled = false;
        ddlSecnFrom.Enabled = false;
        cbxStatus.Enabled = false;
        TextDateTo.Enabled = false;
        ddlSecTo.Enabled = false;

        imgbtnReOpen.Visible = false;
        btnClear.Visible = false;
        btnConfirm.Visible = false;
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
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
            string strTodayDate = currDateTime.ToString("dd/MM/yyyy");

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

    [WebMethod]
    public static int ReadDutyofChk(string strdate, string orgid, string corpid)
    {
        int Count = 0;
        clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
        clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
        dutyOf objDuty = new dutyOf();
        int ret = 0;
        CL_Compzit.clsCommonLibrary objCommon = new CL_Compzit.clsCommonLibrary();
        string strRemLev = "";

        if (strdate != "")
        {
            objEntLevAllocn.LeaveFrmDate = objCommon.textToDateTime(strdate);
        }
        string off = objDuty.CheckDutyOff(objEntLevAllocn.LeaveFrmDate, orgid, corpid);

        if (off == "true")
        {
            Count = 1;
        }


        return Count;
    }
    [WebMethod]
    public static string[] ReadDutyofChkDateRanges(string strdateFm, string orgid, string corpid, string strdateTo)
    {
        string[] strReturn=new string[2];
     
        int Count = 0;
        int ContinuesOffDayCount = 0;
        clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
        clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
        dutyOf objDuty = new dutyOf();
        int ret = 0;
        CL_Compzit.clsCommonLibrary objCommon = new CL_Compzit.clsCommonLibrary();
        string strRemLev = "";
        DateTime datenow, enddate;

        datenow = objCommon.textToDateTime(strdateFm);
        enddate = objCommon.textToDateTime(strdateTo);

        for (var day = datenow; day <= enddate; day = day.AddDays(1))
        {
            string hol = objDuty.checkholiday(day, datenow, enddate);
            if (hol == "true")
            {
                Count = Count + 1;
            }
            if (hol != "true")
            {

                // continue;

                string off = objDuty.CheckDutyOff(day, orgid, corpid);

                if (off == "true")
                {
                    Count = Count + 1;
                }
            }

        }
        strReturn[0] = Count.ToString();
        //11/1

        for (var day = datenow; day <= enddate; day = day.AddDays(1))
        {
            string hol = objDuty.checkholiday(day, datenow, enddate);
            if (hol == "true")
            {
                ContinuesOffDayCount = ContinuesOffDayCount + 1;
                continue;
            }
            //else
            //{
            //    break;
            //}
            if (hol != "true")
            {
                string off = objDuty.CheckDutyOff(day, orgid, corpid);

                if (off == "true")
                {
                    ContinuesOffDayCount = ContinuesOffDayCount + 1;
                }
                else
                {
                    break;
                }
            }

        }


        strReturn[1] = ContinuesOffDayCount.ToString();


        //  objEntLevAllocn.LeaveFrmDate = objCommon.textToDateTime(strdateFm);



        return strReturn;
    }
    [WebMethod]
    public static string[] CheckTrvlDtlShow(int LeaveTypeId)
    {
        clsBusinessLeaveRequest objBusinessLeaveRequest = new clsBusinessLeaveRequest();
        clsEntityLeaveRequest objEntityLeaveRequest = new clsEntityLeaveRequest();
        string[] strJson = new string[5];
        string ret = "true";

        objEntityLeaveRequest.Leave_Id = LeaveTypeId;
        DataTable dt = objBusinessLeaveRequest.CheckTrvlDtlShow(objEntityLeaveRequest);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0][0].ToString() == "0")
            {
                ret = "false";
            }
            strJson[1] = dt.Rows[0][1].ToString();
        }
        else
        {
            ret = "false";
        }
        strJson[0] = ret;

        if (dt.Rows[0]["LEAVETYPDTLS_SETTLMTSTS"].ToString() != "")
        {
            strJson[2] = dt.Rows[0]["LEAVETYPDTLS_SETTLMTSTS"].ToString();
        }
        strJson[3] = dt.Rows[0]["LEAVETYPDTLS_PAIDLEAVE"].ToString();
        return strJson;

    }

}
