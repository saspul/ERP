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

public partial class HCM_HCM_Master_hcm_leave_type_hcm_leave_master : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {



            TypNme.Focus();
            TypNme.Attributes.Add("onkeypress", "return isTag(event)");
            TypNme.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            ddlmodeSearch.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            ddlpay.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            ddlexp.Attributes.Add("onchange", "IncrmntConfrmCounter()"); 
           // cbxAll1.Attributes.Add("onchange", "IncrmntConfrmCounter()");
          //  cbxAll2.Attributes.Add("onchange", "IncrmntConfrmCounter()");
           // cbxAll3.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            cbxTravel.Attributes.Add("onchange", "IncrmntConfrmCounter()");
          ///  cbxleave.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            RbCalendar.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            Rbwrkgday.Attributes.Add("onchange", "IncrmntConfrmCounter()");

            RbMale.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            RBfemale.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            RbBoth.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            Rbsingle.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            RBMarried.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            Rbbothmarital.Attributes.Add("onchange", "IncrmntConfrmCounter()");

            NumDays.Attributes.Add("onkeypress", "return isNumber(event)");
            NumDays.Attributes.Add("onkeydown", "return isTag(event)");
            NumDays.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            CbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            RbMale.Attributes.Add("onkeypress", "return isTag(event)");
            RBfemale.Attributes.Add("onkeypress", "return isTag(event)");
            RbBoth.Attributes.Add("onkeypress", "return isTag(event)");
            Rbsingle.Attributes.Add("onkeypress", "return isTag(event)");
            RBMarried.Attributes.Add("onkeypress", "return isTag(event)");
            Rbbothmarital.Attributes.Add("onkeypress", "return isTag(event)");
            RbCalendar.Attributes.Add("onkeypress", "return isTag(event)");
            Rbwrkgday.Attributes.Add("onkeypress", "return isTag(event)");
            //cbxExcSalProc.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            cbxIncDutyRejoin.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            cbxHoliPaid.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            cbxOffPaid.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            if (!IsPostBack)
            {
                clsBusiness_Leave_Type objBusinessLeavetype = new clsBusiness_Leave_Type();
                clsEntity_Leave_Type ObjEntityLeaveType = new clsEntity_Leave_Type();

                string CheckLeavOnAbsnc = "0";
                if (Session["CORPOFFICEID"] != null)
                {
                    ObjEntityLeaveType.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    CheckLeavOnAbsnc = objBusinessLeavetype.CheckLeavOnAbsnc(ObjEntityLeaveType);
                    hiddenLeavOnAbsnc.Value = CheckLeavOnAbsnc;
                }

                DesignationLoad();
                PaygradeLoad();
                ExperienceLoad();
                
                clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                clsCommonLibrary objCommon = new clsCommonLibrary();
                int intUserId = 0, intUsrRolMstrId, intEnableReOpen, intEnableConfirm, intEnableAdd=0;

               
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
                        else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                        {
                            intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                          
                        }
                        else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                        {
                            intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                         
                        }
                        else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                        {
                            //future

                        }

                    }
                    
                }
                
                HiddenAllocatnConfirmed.Value = "0";
                //when editing 
                //???
                if (Request.QueryString["SelctdId"] != null)
                {
                    string strRandomMixedId = Request.QueryString["SelctdId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);
                    HiddenAllocatnConfirmed.Value = "1";
                 
                    Update(strId);
                    lblEntry.Text = "Edit Leave Type";

                }
                if (Request.QueryString["Id"] != null)
                {
                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);
                    HiddenLeaveId.Value = strId;
                   
                    Update(strId);
                    lblEntry.Text = "Edit Leave Type";

                }

                //passing the id for viewing the deleted entries
                else if (Request.QueryString["ViewId"] != null)
                {
                    string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);
                    HiddenLeaveId.Value = strId;
                   
                    View(strId);
                    btnUpdate.Visible = false;

                    lblEntry.Text = "View Leave Type";
                }

                else
                {
                    lblEntry.Text = "Add Leave Type";
                    RbBoth.Checked = true;
                    Rbbothmarital.Checked = true;
                    btnUpdate.Visible = false;
                    btnUpdateClose.Visible = false;
                    btnAdd.Visible = true;
                    btnAddClose.Visible = true;
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
                    }
                }
               

            }
        }




    


    // for viewing the deleted entries
    public void View(string strWId)
    {
        //declaring objects for bussines and entity layers
        clsBusiness_Leave_Type objBusinessLeavetype = new clsBusiness_Leave_Type();
        clsEntity_Leave_Type ObjEntityLeaveType = new clsEntity_Leave_Type();
        List<clsEntity_designation_list> ObjEntityLeaveDesignationList = new List<clsEntity_designation_list>();
        List<clsEntity_paygrade_list> ObjEntityLeavPayGradeList = new List<clsEntity_paygrade_list>();
        List<clsEntity_experience_list> ObjEntityLeaveExpriencenOList = new List<clsEntity_experience_list>();
        DataTable dtLeaveTypDetail = new DataTable();
        DataTable dtLeavedesigDetail = new DataTable();
        DataTable dtLeavepaygradeDetail = new DataTable();
        DataTable dtLeaveExperienceDetail = new DataTable();


        ObjEntityLeaveType.intleave = Convert.ToInt32(strWId);

        dtLeaveTypDetail = objBusinessLeavetype.ReadLeavedetailsById(ObjEntityLeaveType);


        int NoneSts = 0;
        //for viewing the leave type details
        if (dtLeaveTypDetail.Rows.Count > 0)
        {
            TypNme.Text = dtLeaveTypDetail.Rows[0]["LEAVETYP_NAME"].ToString();
            NumDays.Text = dtLeaveTypDetail.Rows[0]["LEAVETYP_NUMDAYS"].ToString();

            if (dtLeaveTypDetail.Rows[0]["LEAVETYP_APPLICABLE_NONE_STS"].ToString() == "1")
            {
                cbxNone.Checked = true;
                NoneSts = 1;
            }
            else
            {
                cbxNone.Checked = false;
                NoneSts = 0;
            }

            if (dtLeaveTypDetail.Rows[0]["LEAVETYP_LEAVE_ON_ABSENCE"].ToString() == "1")
            {
                cbxLeaveOnAbsence.Checked = true;
                hiddenLeavOnAbsnc.Value = "0";
            }
            else
            {
                cbxLeaveOnAbsence.Checked = false;
            }

            //if (dtLeaveTypDetail.Rows[0]["LEAVETYP_EXC_SAL_PROC"].ToString() == "1")
            //{
            //    cbxExcSalProc.Checked = true;
            //}
            //else
            //{
            //    cbxExcSalProc.Checked = false;
            //}
            if (dtLeaveTypDetail.Rows[0]["LEAVETYP_DUTY_REJOIN_STS"].ToString() == "1")
            {
                cbxIncDutyRejoin.Checked = true;
            }
            else
            {
                cbxIncDutyRejoin.Checked = false;
            }
            if (dtLeaveTypDetail.Rows[0]["LEAVETYP_HOLIDAY_PAID_STS"].ToString() == "1")
            {
                cbxHoliPaid.Checked = true;
            }
            else
            {
                cbxHoliPaid.Checked = false;
            }
            if (dtLeaveTypDetail.Rows[0]["LEAVETYP_OFFDAY_PAID_STS"].ToString() == "1")
            {
                cbxOffPaid.Checked = true;
            }
            else
            {
                cbxOffPaid.Checked = false;
            }
            if (dtLeaveTypDetail.Rows[0]["LEAVETYP_STATUS"] != null)
            {
                int intInsuretStatus = Convert.ToInt32(dtLeaveTypDetail.Rows[0]["LEAVETYP_STATUS"]);
                if (intInsuretStatus == 1)
                {
                    CbxStatus.Checked = true;
                }
                else
                {
                    CbxStatus.Checked = false;
                }
            }
            if (dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_TRVLNEED"] != null)
            {
                int intTravelNeeded = Convert.ToInt32(dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_TRVLNEED"]);
                if (intTravelNeeded == 1)
                {
                    cbxTravel.Checked = true;
                }
                else
                {
                    cbxTravel.Checked = false;
                }
            }
            if (dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_MONTHLYINC"] != null)
            {
                int intMonthlyLeav = Convert.ToInt32(dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_MONTHLYINC"]);
                if (intMonthlyLeav == 1)
                {
                    cbxMonthly.Checked = true;
                }
                else
                {
                    cbxMonthly.Checked = false;
                }
            }

            if (dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_PAIDLEAVE"] != null)
            {
                int intPaidLeave = Convert.ToInt32(dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_PAIDLEAVE"]);
                if (intPaidLeave == 1)
                {
                    cbxleave.Checked = true;
                    ScriptManager.RegisterStartupScript(this, GetType(), "SettlmtWork", "SettlmtWork();", true);
                    int settlmtsts = Convert.ToInt32(dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_SETTLMTSTS"]);
                    if (settlmtsts == 1)
                    {
                        cbxSettlmt.Checked = true;
                    }
                    else
                    {
                        cbxSettlmt.Checked = false;
                    }
                }
                else
                {
                    cbxleave.Checked = false;
                    ScriptManager.RegisterStartupScript(this, GetType(), "SettlmtWork", "SettlmtWork();", true);
                }
            }
            if (dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_LEVTYP"] != null)
            {
                int intCalendar = Convert.ToInt32(dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_LEVTYP"]);
                if (intCalendar == 0)
                {
                    RbCalendar.Checked = true;
                }
                else if (intCalendar == 1)
                {
                    Rbwrkgday.Checked = true;
                }
            }
            if (dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_SEX"] != null)
            {
                int intsex = Convert.ToInt32(dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_SEX"]);
                if (intsex == 0)
                {
                    RbMale.Checked = true;
                }
                else if (intsex == 1)
                {
                    RBfemale.Checked = true;
                }
                else
                {

                    RbBoth.Checked = true;
                }

            }
            if (dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_MARITAL"] != null)
            {
                int intmarital = Convert.ToInt32(dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_MARITAL"]);
                if (intmarital == 0)
                {
                    Rbsingle.Checked = true;
                }
                else if (intmarital == 1)
                {
                    RBMarried.Checked = true;
                }
                else
                {

                    Rbbothmarital.Checked = true;
                }
            }

            if (NoneSts == 0)
            {
                dtLeavedesigDetail = objBusinessLeavetype.ReadLeavedDesigById(ObjEntityLeaveType);

                dtLeaveExperienceDetail = objBusinessLeavetype.ReadLeaveExprnsById(ObjEntityLeaveType);
                dtLeavedesigDetail = objBusinessLeavetype.ReadLeavedDesigById(ObjEntityLeaveType);

                //for viewing the designation,
                for (int i = 0; i < dtLeavedesigDetail.Rows.Count; i++)
                {
                    if (i == 0)
                        hiddenselectedDesignlist.Value = dtLeavedesigDetail.Rows[i][0].ToString();
                    else
                        hiddenselectedDesignlist.Value = hiddenselectedDesignlist.Value + "," + dtLeavedesigDetail.Rows[i][0];
                }
                //for viewing the paygrade,
                dtLeavepaygradeDetail = objBusinessLeavetype.ReadLeavePaygradeById(ObjEntityLeaveType);
                for (int i = 0; i < dtLeavepaygradeDetail.Rows.Count; i++)
                {
                    if (i == 0)
                        hiddenselectedPaygradelist.Value = dtLeavepaygradeDetail.Rows[i][0].ToString();
                    else
                        hiddenselectedPaygradelist.Value = hiddenselectedPaygradelist.Value + "," + dtLeavepaygradeDetail.Rows[i][0];
                }
                //for viewing the experience,
                dtLeaveExperienceDetail = objBusinessLeavetype.ReadLeaveExprnsById(ObjEntityLeaveType);
                for (int i = 0; i < dtLeaveExperienceDetail.Rows.Count; i++)
                {
                    if (i == 0)
                        hiddenselectedExperiencelist.Value = dtLeaveExperienceDetail.Rows[i][0].ToString();
                    else
                        hiddenselectedExperiencelist.Value = hiddenselectedExperiencelist.Value + "," + dtLeaveExperienceDetail.Rows[i][0];
                }


                if (dtLeavedesigDetail.Rows.Count > 0)
                {
                    int designall = Convert.ToInt32(dtLeavedesigDetail.Rows[0]["DESIG_STATUS"]);

                    if (designall == 1)
                    {
                        cbxAll1.Checked = true;
                        ddlmodeSearch.Enabled = false;
                        ddlpay.Enabled = false;
                        ddlexp.Enabled = false;
                        cbxAll2.Enabled = false;
                        cbxAll3.Enabled = false;
                    }
                    else
                    {
                        for (int j = 0; j < dtLeavedesigDetail.Rows.Count; j++)
                        {

                            if (dtLeavedesigDetail.Rows[j]["DSGN_ID"].ToString() != "")
                            {
                                if (ddlmodeSearch.Items.FindByValue(dtLeavedesigDetail.Rows[j]["DSGN_ID"].ToString()) != null)
                                {
                                    ddlmodeSearch.ClearSelection();
                                    ddlmodeSearch.Items.FindByValue(dtLeavedesigDetail.Rows[j]["DSGN_ID"].ToString()).Selected = true;
                                }
                                else
                                {
                                    ddlmodeSearch.ClearSelection();
                                    ListItem lstGrp = new ListItem(dtLeavedesigDetail.Rows[j]["DSGN_NAME"].ToString(), dtLeavedesigDetail.Rows[0]["DSGN_ID"].ToString());
                                    ddlmodeSearch.Items.Insert(1, lstGrp);
                                    //SortDDL(ref this.ddlpaygrade);
                                    ddlmodeSearch.Items.FindByValue(dtLeavedesigDetail.Rows[j]["DSGN_ID"].ToString()).Selected = true;
                                }

                            }
                        }
                    }

                }

                int paygradeall = 0;
                if (dtLeavepaygradeDetail.Rows.Count > 0)
                {
                    if (dtLeavepaygradeDetail.Rows[0]["PAYGRADE_STATUS"].ToString() != "")
                    {
                        paygradeall = Convert.ToInt32(dtLeavepaygradeDetail.Rows[0]["PAYGRADE_STATUS"]);
                    }

                    if (paygradeall == 1)
                    {
                        cbxAll2.Checked = true;
                        ddlpay.Enabled = false;
                        ddlexp.Enabled = false;
                        ddlmodeSearch.Enabled = false;
                        ddlmodeSearch.Items.Clear();
                        ddlexp.Items.Clear();
                        cbxAll1.Enabled = false;
                        cbxAll2.Enabled = false;
                    }
                    else
                    {
                        for (int j = 0; j < dtLeavepaygradeDetail.Rows.Count; j++)
                        {
                            if (dtLeavepaygradeDetail.Rows[j]["PYGRD_ID"].ToString() != "")
                            {
                                if (ddlpay.Items.FindByValue(dtLeavepaygradeDetail.Rows[j]["PYGRD_ID"].ToString()) != null)
                                {
                                    ddlpay.ClearSelection();
                                    ddlpay.Items.FindByValue(dtLeavepaygradeDetail.Rows[j]["PYGRD_ID"].ToString()).Selected = true;
                                }
                                else
                                {
                                    ddlpay.ClearSelection();
                                    ListItem lstGrp = new ListItem(dtLeavepaygradeDetail.Rows[j]["PYGRD_NAME"].ToString(), dtLeavepaygradeDetail.Rows[j]["PYGRD_ID"].ToString());
                                    ddlpay.Items.Insert(1, lstGrp);
                                    //SortDDL(ref this.ddlpaygrade);
                                    ddlpay.Items.FindByValue(dtLeavepaygradeDetail.Rows[j]["PYGRD_ID"].ToString()).Selected = true;
                                }


                            }
                        }
                    }
                }
                if (dtLeaveExperienceDetail.Rows.Count > 0)
                {

                    if (dtLeaveExperienceDetail.Rows[0]["EXPERIENCE_STATUSCOLUMN1"].ToString() != "")
                    {
                        int Experienceall = 0;
                        Experienceall = Convert.ToInt32(dtLeaveExperienceDetail.Rows[0]["EXPERIENCE_STATUSCOLUMN1"]);

                        if (Experienceall == 1)
                        {
                            cbxAll3.Checked = true;
                            ddlexp.Enabled = false;
                            ddlmodeSearch.Enabled = false;
                            ddlmodeSearch.Items.Clear();
                            ddlpay.Enabled = false;
                            ddlpay.Items.Clear();
                            cbxAll1.Enabled = false;
                            cbxAll2.Enabled = false;
                        }
                        else
                        {
                            for (int i = 0; i < dtLeaveExperienceDetail.Rows.Count; i++)
                            {
                                if (i == 0)
                                    hiddenselectedExperiencelist.Value = dtLeaveExperienceDetail.Rows[i][0].ToString();
                                else
                                    hiddenselectedExperiencelist.Value = hiddenselectedExperiencelist.Value + "," + dtLeaveExperienceDetail.Rows[i][0];
                            }

                        }

                    }

                }

            }

            ddlexp.Enabled = false;
            ddlmodeSearch.Enabled = false;
            ddlpay.Enabled = false;
            cbxAll1.Enabled = false;
            cbxAll2.Enabled = false;
            cbxAll3.Enabled = false;
            CbxStatus.Enabled = false;
            cbxleave.Enabled = false;
            cbxTravel.Enabled = false;
            RbBoth.Enabled = false;
            Rbbothmarital.Enabled = false;
            RbCalendar.Enabled = false;
            Rbwrkgday.Enabled = false;
            RbMale.Enabled = false;
            RBfemale.Enabled = false;
            RBMarried.Enabled = false;
            Rbsingle.Enabled = false;
            TypNme.Enabled = false;
            NumDays.Enabled = false;
            btnClear.Visible = false;
            btnAdd.Visible = false;
            btnAddClose.Visible = false;
            btnUpdate.Visible = false;
            btnUpdateClose.Visible = false;
            cbxSettlmt.Enabled = false;
            cbxMonthly.Enabled = false;
            cbxLeaveOnAbsence.Enabled = false;
            txtDesc.Enabled = false;
            cbxNone.Enabled = false;
            //cbxStatus.Enabled = false;
            //cbxStatus.Attributes["style"] = "pointer-events: none;";
            //cbxExcSalProc.Enabled = false;
            cbxIncDutyRejoin.Enabled = false;
            cbxHoliPaid.Enabled = false;
            cbxOffPaid.Enabled = false;
        }
    }

    //for editing view
    public void Update(string strWId)
    {
        //declaring objects for bussines and entity layers
        clsBusiness_Leave_Type objBusinessLeavetype = new clsBusiness_Leave_Type();
        clsEntity_Leave_Type ObjEntityLeaveType = new clsEntity_Leave_Type();
        List<clsEntity_designation_list> ObjEntityLeaveDesignationList = new List<clsEntity_designation_list>();
        List<clsEntity_paygrade_list> ObjEntityLeavPayGradeList = new List<clsEntity_paygrade_list>();
        List<clsEntity_experience_list> ObjEntityLeaveExpriencenOList = new List<clsEntity_experience_list>();


        ObjEntityLeaveType.intleave = Convert.ToInt32(strWId);
        DataTable dtLeaveTypDetail = new DataTable();
        DataTable dtLeavedesigDetail = new DataTable();
        DataTable dtLeavepaygradeDetail = new DataTable();
        DataTable dtLeaveExperienceDetail = new DataTable();

        dtLeaveTypDetail = objBusinessLeavetype.ReadLeavedetailsById(ObjEntityLeaveType);

        int NoneSts = 0;
        //for the editing view of leave type details
        if (dtLeaveTypDetail.Rows.Count > 0)
        {
            TypNme.Text = dtLeaveTypDetail.Rows[0]["LEAVETYP_NAME"].ToString();
            NumDays.Text = dtLeaveTypDetail.Rows[0]["LEAVETYP_NUMDAYS"].ToString();
            txtDesc.Text = dtLeaveTypDetail.Rows[0]["LEAVETYP_DESC"].ToString();
            if (dtLeaveTypDetail.Rows[0]["LEAVETYP_APPLICABLE_NONE_STS"].ToString() == "1")
            {
                cbxNone.Checked = true;
                NoneSts = 1;
            }
            else
            {
                cbxNone.Checked = false;
                NoneSts = 0;
            }

            if (dtLeaveTypDetail.Rows[0]["LEAVETYP_LEAVE_ON_ABSENCE"].ToString() == "1")
            {
                cbxLeaveOnAbsence.Checked = true;
                hiddenLeavOnAbsnc.Value = "0";
            }
            else
            {
                cbxLeaveOnAbsence.Checked = false;
            }

            //if (dtLeaveTypDetail.Rows[0]["LEAVETYP_EXC_SAL_PROC"].ToString() == "1")
            //{
            //    cbxExcSalProc.Checked = true;
            //}
            //else
            //{
            //    cbxExcSalProc.Checked = false;
            //}
            if (dtLeaveTypDetail.Rows[0]["LEAVETYP_DUTY_REJOIN_STS"].ToString() == "1")
            {
                cbxIncDutyRejoin.Checked = true;
            }
            else
            {
                cbxIncDutyRejoin.Checked = false;
            }


            if (dtLeaveTypDetail.Rows[0]["LEAVETYP_HOLIDAY_PAID_STS"].ToString() == "1")
            {
                cbxHoliPaid.Checked = true;
            }
            else
            {
                cbxHoliPaid.Checked = false;
            }
            if (dtLeaveTypDetail.Rows[0]["LEAVETYP_OFFDAY_PAID_STS"].ToString() == "1")
            {
                cbxOffPaid.Checked = true;
            }
            else
            {
                cbxOffPaid.Checked = false;
            }




            if (dtLeaveTypDetail.Rows[0]["LEAVETYP_STATUS"] != null)
            {
                int intInsuretStatus = 0;
                if (dtLeaveTypDetail.Rows[0]["LEAVETYP_STATUS"].ToString() != "")
                {
                    intInsuretStatus = Convert.ToInt32(dtLeaveTypDetail.Rows[0]["LEAVETYP_STATUS"]);
                }
                if (intInsuretStatus == 1)
                {
                    CbxStatus.Checked = true;
                }
                else
                {
                    CbxStatus.Checked = false;
                }
            }
            if (dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_TRVLNEED"] != null)
            {
                int intTravelNeeded = Convert.ToInt32(dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_TRVLNEED"]);
                if (intTravelNeeded == 1)
                {
                    cbxTravel.Checked = true;
                }
                else
                {
                    cbxTravel.Checked = false;
                }
            }
            if (dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_MONTHLYINC"] != null)
            {
                int intMonthlyLeav = Convert.ToInt32(dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_MONTHLYINC"]);
                if (intMonthlyLeav == 1)
                {
                    cbxMonthly.Checked = true;
                }
                else
                {
                    cbxMonthly.Checked = false;
                }
            }

            if (dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_PAIDLEAVE"] != null)
            {
                int intPaidLeave = Convert.ToInt32(dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_PAIDLEAVE"]);
                if (intPaidLeave == 1)
                {
                    cbxleave.Checked = true;
                    ScriptManager.RegisterStartupScript(this, GetType(), "SettlmtWork", "SettlmtWork();", true);
                    int settlmtsts = Convert.ToInt32(dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_SETTLMTSTS"]);
                    if (settlmtsts == 1)
                    {
                        cbxSettlmt.Checked = true;
                    }
                    else
                    {
                        cbxSettlmt.Checked = false;
                    }
                }
                else
                {
                    cbxleave.Checked = false;
                    ScriptManager.RegisterStartupScript(this, GetType(), "SettlmtWork", "SettlmtWork();", true);
                }
            }
            if (dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_LEVTYP"] != null)
            {
                int intCalendar = Convert.ToInt32(dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_LEVTYP"]);
                if (intCalendar == 0)
                {
                    RbCalendar.Checked = true;
                }
                else if (intCalendar == 1)
                {
                    Rbwrkgday.Checked = true;
                }
            }
            if (dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_SEX"] != null)
            {
                int intsex = Convert.ToInt32(dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_SEX"]);
                if (intsex == 0)
                {
                    RbMale.Checked = true;
                }
                else if (intsex == 1)
                {
                    RBfemale.Checked = true;
                }
                else
                {

                    RbBoth.Checked = true;
                }

            }
            if (dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_MARITAL"] != null)
            {
                int intmarital = Convert.ToInt32(dtLeaveTypDetail.Rows[0]["LEAVETYPDTLS_MARITAL"]);
                if (intmarital == 0)
                {
                    Rbsingle.Checked = true;
                }
                else if (intmarital == 1)
                {
                    RBMarried.Checked = true;
                }
                else
                {

                    Rbbothmarital.Checked = true;
                }
            }

            if (NoneSts == 0)
            {

                dtLeavedesigDetail = objBusinessLeavetype.ReadLeavedDesigById(ObjEntityLeaveType);
                int designall = 0;
                if (dtLeavedesigDetail.Rows.Count > 0)
                {
                    if (dtLeavedesigDetail.Rows[0]["DESIG_STATUS"].ToString() != "")
                    {
                        designall = Convert.ToInt32(dtLeavedesigDetail.Rows[0]["DESIG_STATUS"]);
                    }
                    if (designall == 1)
                    {
                        cbxAll1.Checked = true;

                        ddlmodeSearch.Enabled = false;
                        ddlpay.Enabled = false;
                        ddlexp.Enabled = false;
                        cbxAll2.Enabled = false;
                        cbxAll3.Enabled = false;
                    }
                    else
                    {
                        for (int i = 0; i < dtLeavedesigDetail.Rows.Count; i++)
                        {
                            if (dtLeavedesigDetail.Rows[0]["DESIG_STATUS"].ToString() != "")
                            {
                                if (i == 0)
                                    hiddenselectedDesignlist.Value = dtLeavedesigDetail.Rows[i][0].ToString();
                                else
                                    hiddenselectedDesignlist.Value = hiddenselectedDesignlist.Value + "," + dtLeavedesigDetail.Rows[i][0];
                            }

                        }
                    }
                }
                dtLeavepaygradeDetail = objBusinessLeavetype.ReadLeavePaygradeById(ObjEntityLeaveType);
                int paygradeall = 0;
                if (dtLeavepaygradeDetail.Rows.Count > 0)
                {
                    if (dtLeavepaygradeDetail.Rows[0]["PAYGRADE_STATUS"].ToString() != "")
                    {
                        paygradeall = Convert.ToInt32(dtLeavepaygradeDetail.Rows[0]["PAYGRADE_STATUS"]);
                    }
                    if (paygradeall == 1)
                    {
                        cbxAll2.Checked = true;
                        ddlpay.Enabled = false;
                        ddlmodeSearch.Enabled = false;
                        ddlexp.Enabled = false;
                        cbxAll2.Enabled = false;
                        cbxAll3.Enabled = false;

                    }

                    for (int i = 0; i < dtLeavepaygradeDetail.Rows.Count; i++)
                    {
                        if (dtLeavepaygradeDetail.Rows[i][0].ToString() != "")
                        {
                            if (i == 0)
                                hiddenselectedPaygradelist.Value = dtLeavepaygradeDetail.Rows[i][0].ToString();
                            else
                                hiddenselectedPaygradelist.Value = hiddenselectedPaygradelist.Value + "," + dtLeavepaygradeDetail.Rows[i][0];
                        }

                    }
                }
                dtLeaveExperienceDetail = objBusinessLeavetype.ReadLeaveExprnsById(ObjEntityLeaveType);
                for (int i = 0; i < dtLeaveExperienceDetail.Rows.Count; i++)
                {
                    if (dtLeaveExperienceDetail.Rows[i][0].ToString() != "")
                    {
                        if (i == 0)
                            hiddenselectedExperiencelist.Value = dtLeaveExperienceDetail.Rows[i][0].ToString();
                        else
                            hiddenselectedExperiencelist.Value = hiddenselectedExperiencelist.Value + "," + dtLeaveExperienceDetail.Rows[i][0];
                    }

                }


                if (designall != 1)
                {

                    for (int j = 0; j < dtLeavedesigDetail.Rows.Count; j++)
                    {
                        if (dtLeavedesigDetail.Rows[j]["DSGN_ID"].ToString() != "")
                        {
                            if (ddlmodeSearch.Items.FindByValue(dtLeavedesigDetail.Rows[j]["DSGN_ID"].ToString()) != null)
                            {
                                ddlmodeSearch.ClearSelection();
                                ddlmodeSearch.Items.FindByValue(dtLeavedesigDetail.Rows[j]["DSGN_ID"].ToString()).Selected = true;
                            }
                            else
                            {
                                ddlmodeSearch.ClearSelection();
                                ListItem lstGrp = new ListItem(dtLeavedesigDetail.Rows[j]["DSGN_NAME"].ToString(), dtLeavedesigDetail.Rows[j]["DSGN_ID"].ToString());
                                ddlmodeSearch.Items.Insert(1, lstGrp);
                                ddlmodeSearch.Items.FindByValue(dtLeavedesigDetail.Rows[j]["DSGN_ID"].ToString()).Selected = true;
                            }
                            int designall1 = 0;
                            designall1 = Convert.ToInt32(dtLeavedesigDetail.Rows[j]["DESIG_STATUS"]);
                            if (designall1 == 1)
                            {
                                cbxAll1.Checked = true;
                                ddlmodeSearch.Enabled = false;
                                ddlpay.Enabled = false;
                                ddlexp.Enabled = false;
                                cbxAll2.Enabled = false;
                                cbxAll3.Enabled = false;
                            }
                            else
                            {

                            }
                        }
                    }
                }

                for (int j = 0; j < dtLeavepaygradeDetail.Rows.Count; j++)
                {
                    if (dtLeavepaygradeDetail.Rows[j]["PYGRD_ID"].ToString() != "")
                    {
                        if (ddlpay.Items.FindByValue(dtLeavepaygradeDetail.Rows[j]["PYGRD_ID"].ToString()) != null)
                        {
                            ddlpay.ClearSelection();
                            ddlpay.Items.FindByValue(dtLeavepaygradeDetail.Rows[j]["PYGRD_ID"].ToString()).Selected = true;
                        }
                        else
                        {
                            ddlpay.ClearSelection();
                            ListItem lstGrp = new ListItem(dtLeavepaygradeDetail.Rows[j]["PYGRD_NAME"].ToString(), dtLeavepaygradeDetail.Rows[j]["PYGRD_ID"].ToString());
                            ddlpay.Items.Insert(1, lstGrp);
                            ddlpay.Items.FindByValue(dtLeavepaygradeDetail.Rows[j]["PYGRD_ID"].ToString()).Selected = true;
                        }
                        paygradeall = 0;
                        paygradeall = Convert.ToInt32(dtLeavepaygradeDetail.Rows[j]["PAYGRADE_STATUS"]);

                        if (paygradeall == 1)
                        {
                            cbxAll2.Checked = true;
                            ddlmodeSearch.Enabled = false;
                            ddlpay.Enabled = false;
                            ddlexp.Enabled = false;
                            cbxAll1.Enabled = false;
                            cbxAll3.Enabled = false;
                        }
                        else
                        {

                        }

                    }
                }
                if (dtLeaveExperienceDetail.Rows[0]["EXPERIENCE_STATUSCOLUMN1"].ToString() != "")
                {
                    int Experienceall = 0;
                    Experienceall = Convert.ToInt32(dtLeaveExperienceDetail.Rows[0]["EXPERIENCE_STATUSCOLUMN1"]);

                    if (Experienceall == 1)
                    {
                        cbxAll3.Checked = true;
                        ddlmodeSearch.Enabled = false;

                        ddlpay.Enabled = false;
                        ddlexp.Enabled = false;
                        cbxAll1.Enabled = false;
                        cbxAll2.Enabled = false;
                    }
                }

            }
            else
            {
                ddlmodeSearch.Enabled = false;
                ddlpay.Enabled = false;
                ddlexp.Enabled = false;
                cbxAll1.Enabled = false;
                cbxAll2.Enabled = false;
                cbxAll3.Enabled = false;
                hiddenselectedDesignlist.Value = "";
                hiddenselectedPaygradelist.Value = "";
                hiddenselectedExperiencelist.Value = "";
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
                }
            }
            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                btnUpdate.Visible = true;
                btnUpdateClose.Visible = true;
            }
            else
            {

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = true;
            }


            if (HiddenAllocatnConfirmed.Value == "1")
            {
                NumDays.Enabled = false;

            }
            btnClear.Visible = false;
            btnAdd.Visible = false;
            btnAddClose.Visible = false;

            if ((dtLeaveTypDetail.Rows[0]["LEAVE_TYPE_SUB"].ToString() != "" && dtLeaveTypDetail.Rows[0]["LEAVE_TYPE_SUB"].ToString() != null) || (Convert.ToInt32(dtLeaveTypDetail.Rows[0]["LEAVE_SETTLE"].ToString()) > 0))
            {

                ddlexp.Enabled = false;
                ddlmodeSearch.Enabled = false;
                ddlpay.Enabled = false;
                cbxAll1.Enabled = false;
                cbxAll2.Enabled = false;
                cbxAll3.Enabled = false;
                CbxStatus.Enabled = false;
                cbxleave.Enabled = false;
                cbxTravel.Enabled = false;
                RbBoth.Enabled = false;
                Rbbothmarital.Enabled = false;
                RbCalendar.Enabled = false;
                Rbwrkgday.Enabled = false;
                RbMale.Enabled = false;
                RBfemale.Enabled = false;
                RBMarried.Enabled = false;
                Rbsingle.Enabled = false;
                TypNme.Enabled = false;
                NumDays.Enabled = false;
                btnClear.Visible = false;
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                cbxSettlmt.Enabled = false;
                cbxMonthly.Enabled = false;
                btnUpdate.Visible = false;
                cbxLeaveOnAbsence.Enabled = false;
                cbxNone.Enabled = false;
                txtDesc.Enabled = false;
                //cbxExcSalProc.Enabled = false;
                cbxIncDutyRejoin.Enabled = false;
                cbxHoliPaid.Enabled = false;
                cbxOffPaid.Enabled = false;
            }
        }

    }

    //for adding the leave details
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusiness_Leave_Type objBusinessLeavetype = new clsBusiness_Leave_Type();
        clsEntity_Leave_Type ObjEntityLeaveType = new clsEntity_Leave_Type();

        List<clsEntity_designation_list> ObjEntityLeaveDesignationList = new List<clsEntity_designation_list>();
        List<clsEntity_paygrade_list> ObjEntityLeavPayGradeList = new List<clsEntity_paygrade_list>();
        List<clsEntity_experience_list> ObjEntityLeaveExpriencenOList = new List<clsEntity_experience_list>();
        List<clsEntity_Users_list> objEntityUser_List = new List<clsEntity_Users_list>();

        DataTable dtPaygrdUsers=new DataTable();
        DataTable dtDsgnUsers = new DataTable();
        DataTable dtExpUsers = new DataTable();
        DataTable dtMoreExpUsers = new DataTable();
        string UserID = "";

        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
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

        if (Session["USERID"] != null)
        {
            ObjEntityLeaveType.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }



        //if (cbxExcSalProc.Checked == true)
        //{
        //    ObjEntityLeaveType.ExcSalProc = 1;
        //}
        //else
        //{
        //    ObjEntityLeaveType.ExcSalProc = 0;
        //}
        if (cbxIncDutyRejoin.Checked == true)
        {
            ObjEntityLeaveType.IncDutyRejoin = 1;
        }
        else
        {
            ObjEntityLeaveType.IncDutyRejoin = 0;
        }
        if (cbxHoliPaid.Checked == true)
        {
            ObjEntityLeaveType.HoliPaid = 1;
        }
        else
        {
            ObjEntityLeaveType.HoliPaid = 0;
        }
        if (cbxOffPaid.Checked == true)
        {
            ObjEntityLeaveType.OffPaid = 1;
        }
        else
        {
            ObjEntityLeaveType.OffPaid = 0;
        }




        //Status checkbox checked
        if (CbxStatus.Checked == true)
        {
            ObjEntityLeaveType.Status_id = 1;
        }
        //Status checkbox not checked
        else
        {
            ObjEntityLeaveType.Status_id = 0;
        }
        //travel checkbox checked
        if (cbxTravel.Checked == true)
        {
            ObjEntityLeaveType.intTravelNeeded = 1;
        }
        //travel checkbox not checked
        else
        {
            ObjEntityLeaveType.intTravelNeeded = 0;
        }
        //monthly leave
        if (cbxMonthly.Checked == true)
        {
            ObjEntityLeaveType.Monthly = 1;
        }
        else
        {
            ObjEntityLeaveType.Monthly = 0;
        }

        //leave checkbox checked
        if (cbxleave.Checked == true)
        {
            ObjEntityLeaveType.intPaidLeave = 1;

            if (cbxSettlmt.Checked == true)
            {
                ObjEntityLeaveType.SettlmtSts = 1;
            }
            else
            {
                ObjEntityLeaveType.SettlmtSts = 0;
            }
        }
        //leave checkbox not checked
        else
        {
            ObjEntityLeaveType.intPaidLeave = 0;
        }
        //calendar radiobutton checked
        if
            (RbCalendar.Checked == true)
        {
            ObjEntityLeaveType.intCalendarRb = 0;
        }
        else if
            //wrkingday radiobutton checked
            (Rbwrkgday.Checked == true)
        {
            ObjEntityLeaveType.intCalendarRb = 1;
        }

        //male radiobutton checked

        if
             (RbMale.Checked == true)
        {
            ObjEntityLeaveType.intsexRb = 0;
        }
        //female radiobutton checked
        else if
            (RBfemale.Checked == true)
        {
            ObjEntityLeaveType.intsexRb = 1;
        }
        else
        {
            ObjEntityLeaveType.intsexRb = 2;
        }

        // marital sigle radiobutton checked

        if
            (Rbsingle.Checked == true)
        {
            ObjEntityLeaveType.MaritalStatus = 0;
        }
        //  married radiobutton checked
        else if
            (RBMarried.Checked == true)
        {
            ObjEntityLeaveType.MaritalStatus = 1;
        }
        else
        {
            ObjEntityLeaveType.MaritalStatus = 2;
        }

        if (cbxNone.Checked == false)
        {

            // all checkbox for designation
            if (cbxAll1.Checked == true)
            {
                ObjEntityLeaveType.intDesignationStatus = 1;
                ddlmodeSearch.Enabled = false;
            }

            else
            {
                if (hiddenselectedDesignlist.Value != "")
                {
                    string[] tokens = hiddenselectedDesignlist.Value.Split(',');

                    for (int i = 0; i < tokens.Count(); i++)
                    {

                        int DesnationId = Convert.ToInt32(tokens[i]);
                        clsEntity_designation_list objentityDesignation = new clsEntity_designation_list();
                        objentityDesignation.intDesignationlist_id = DesnationId;
                        ObjEntityLeaveDesignationList.Add(objentityDesignation);
                    }

                    ObjEntityLeaveType.DesignationID = hiddenselectedDesignlist.Value;
                    dtDsgnUsers = objBusinessLeavetype.ReadDesignationUsers(ObjEntityLeaveType);
                    for (int i = 0; i < dtDsgnUsers.Rows.Count; i++)
                    {
                        clsEntity_Users_list objEntityUsers_list = new clsEntity_Users_list();
                        if (!(UserID.Contains(dtDsgnUsers.Rows[i]["USR_ID"].ToString())))
                        {
                            UserID = UserID + "," + dtDsgnUsers.Rows[i]["USR_ID"].ToString();
                            objEntityUsers_list.UserID = Convert.ToInt32(dtDsgnUsers.Rows[i]["USR_ID"].ToString());
                            objEntityUser_List.Add(objEntityUsers_list);
                        }
                    }
                }
            }
            // all checkbox for paygrade
            if (cbxAll2.Checked == true)
            {
                ObjEntityLeaveType.intpaygradestatus = 1;
                ddlpay.Enabled = false;
            }

            else
            {
                if (hiddenselectedPaygradelist.Value != "")
                {
                    string[] tokens = hiddenselectedPaygradelist.Value.Split(',');

                    for (int i = 0; i < tokens.Count(); i++)
                    {

                        int payGradeId = Convert.ToInt32(tokens[i]);
                        clsEntity_paygrade_list objentitypaygrade = new clsEntity_paygrade_list();
                        objentitypaygrade.intpaygradelist_id = payGradeId;
                        ObjEntityLeavPayGradeList.Add(objentitypaygrade);
                    }

                    ObjEntityLeaveType.Paygrade = hiddenselectedPaygradelist.Value;
                    dtPaygrdUsers = objBusinessLeavetype.ReadPaygradeUsers(ObjEntityLeaveType);
                    for (int i = 0; i < dtPaygrdUsers.Rows.Count; i++)
                    {
                        clsEntity_Users_list objEntityUsers_list = new clsEntity_Users_list();
                        if (!(UserID.Contains(dtPaygrdUsers.Rows[i]["USER_ID"].ToString())))
                        {
                            UserID = UserID + "," + dtPaygrdUsers.Rows[i]["USER_ID"].ToString();
                            objEntityUsers_list.UserID = Convert.ToInt32(dtPaygrdUsers.Rows[i]["USER_ID"].ToString());
                            objEntityUser_List.Add(objEntityUsers_list);
                        }
                    }

                }

            }
            // all checkbox for experience

            if (cbxAll3.Checked == true)
            {
                ObjEntityLeaveType.intexperiencesstatus = 1;
                ddlexp.Enabled = false;
            }

            else
            {
                if (hiddenselectedExperiencelist.Value != "")
                {
                    string[] tokens = hiddenselectedExperiencelist.Value.Split(',');
                    string StrExperience = "";

                    DataTable dtExp = objBusinessLeavetype.ReadExperienceByID(ObjEntityLeaveType);
                    DataTable table = new DataTable("Experience");
                    table.Columns.Add(new DataColumn("Id", typeof(int)));
                    table.Columns.Add(new DataColumn("Min", typeof(float)));
                    table.Columns.Add(new DataColumn("Max", typeof(float)));
                    for (int introwCount = 0; introwCount < dtExp.Rows.Count; introwCount++)
                    {
                        DataRow drDtl = table.NewRow();
                        foreach (DataRow dtRowsIn in dtExp.Rows)
                        {

                            drDtl["Id"] = dtExp.Rows[introwCount]["LEAVDTLS_EXPMASTR_ID"].ToString();
                            drDtl["Min"] = dtExp.Rows[introwCount]["EXPMASTR_MIN_YEAR"].ToString();
                            drDtl["Max"] = dtExp.Rows[introwCount]["EXPMASTR_MAX_YEAR"].ToString();
                        }
                        table.Rows.Add(drDtl);

                    }
                    for (int i = 0; i < tokens.Count(); i++)
                    {
                        int experienceId = Convert.ToInt32(tokens[i]);
                        DataRow[] results = table.Select("Id =" + experienceId);
                        if (results.Length > 0)
                        {
                            foreach (DataRow row in results)
                            {
                                string strMin = row[1].ToString();
                                string strMax = row[2].ToString();
                                //for (decimal intExpMin = Convert.ToInt32(strMin); intExpMin <= Convert.ToInt32(strMax); intExpMin++)
                                //{
                                //    StrExperience = StrExperience + "," + intExpMin.ToString();
                                //}

                                for (decimal intExpMin = Convert.ToDecimal(strMin); intExpMin <= Convert.ToDecimal(strMax); intExpMin++)
                                {
                                    StrExperience = StrExperience + "," + intExpMin.ToString();
                                }
                            }
                        }
                        clsEntity_experience_list objentityExperience = new clsEntity_experience_list();
                        objentityExperience.intexperiencelist_id = experienceId;
                        ObjEntityLeaveExpriencenOList.Add(objentityExperience);
                    }

                    if (StrExperience != "")
                    {
                        ObjEntityLeaveType.Experience = StrExperience;
                    }
                    dtExpUsers = objBusinessLeavetype.ReadExperienceUsers(ObjEntityLeaveType);
                    for (int J = 0; J < dtExpUsers.Rows.Count; J++)
                    {
                        clsEntity_Users_list objEntityUsers_list = new clsEntity_Users_list();
                        if (!(UserID.Contains(dtExpUsers.Rows[J]["USER_ID"].ToString())))
                        {
                            UserID = UserID + "," + dtExpUsers.Rows[J]["USER_ID"].ToString();
                            objEntityUsers_list.UserID = Convert.ToInt32(dtExpUsers.Rows[J]["USER_ID"].ToString());
                            objEntityUser_List.Add(objEntityUsers_list);
                        }
                    }


                }
            }
        }
        else
        {
            ObjEntityLeaveType.ApplicableNone = 1;
            ObjEntityLeaveType.intDesignationStatus = 0;
            ObjEntityLeaveType.intpaygradestatus = 0;
            ObjEntityLeaveType.intexperiencesstatus = 0;
            ObjEntityLeaveDesignationList.Clear();
            ObjEntityLeavPayGradeList.Clear();
            ObjEntityLeaveExpriencenOList.Clear();
        }


        ObjEntityLeaveType.LeaveTypeName = TypNme.Text.Trim().ToUpper();


        ObjEntityLeaveType.NoOfDays = Convert.ToInt32(Request.Form[NumDays.UniqueID]);


       

        


        ObjEntityLeaveType.LeaveDesc = txtDesc.Text.ToUpper();

        ObjEntityLeaveType.LeaveTypeName = TypNme.Text.Trim().ToUpper();
      //  ObjEntityLeaveType.NoOfDays = Convert.ToInt32(NumDays.Text.Trim().ToUpper());
        string strNameCount = "0";
        if (TypNme.Text != "" && TypNme.Text != null)
        {
            ObjEntityLeaveType.LeaveTypeName = TypNme.Text.Trim().ToUpper();
            strNameCount = objBusinessLeavetype.CheckLeaveName(ObjEntityLeaveType);
        }
      //  ObjEntityLeaveType.NoOfDays = Convert.ToInt32(NumDays.Text.Trim().ToUpper());

        string strCheckLeavOnAbsnc = "0";

        if (cbxLeaveOnAbsence.Checked == true)
        {
            ObjEntityLeaveType.LeaveOnAbsence = 1;
            strCheckLeavOnAbsnc = objBusinessLeavetype.CheckLeavOnAbsnc(ObjEntityLeaveType);
        }
        else
        {
            ObjEntityLeaveType.LeaveOnAbsence = 0;
        }

       

        

        //If there is no name like this on table.    
        if (strNameCount == "0" && strCheckLeavOnAbsnc =="0")
        {
            objBusinessLeavetype.AddLeaveType(ObjEntityLeaveType, ObjEntityLeaveDesignationList, ObjEntityLeavPayGradeList, ObjEntityLeaveExpriencenOList, objEntityUser_List);

            if (clickedButton.ID == "btnAdd")
            {
                Response.Redirect("hcm_leave_master.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("hcm_leave_master_List.aspx?InsUpd=Ins");
            }

        }
        //If have
        else
        {
            if (strNameCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            }
            else if (strCheckLeavOnAbsnc != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationLeavAbsnc", "DuplicationLeavAbsnc();", true);
            }

        }
    }

    //for load the experience
    public void ExperienceLoad()
    {
        clsBusiness_Leave_Type objBusinessLeavetype = new clsBusiness_Leave_Type();
        clsEntity_Leave_Type ObjEntityLeaveType = new clsEntity_Leave_Type();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityLeaveType.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
        
            ObjEntityLeaveType.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtdepartment = objBusinessLeavetype.ReadExperience(ObjEntityLeaveType);
        if (dtdepartment.Rows.Count > 0)
        {
            ddlexp.DataSource = dtdepartment;
            ddlexp.Items.Clear();

            ddlexp.DataValueField = "LEAVDTLS_EXPMASTR_ID";
            ddlexp.DataTextField = "EXPMASTR_TYPE";
            ddlexp.DataBind();

        }
     
    }


    //for load the paygrade
    public void PaygradeLoad()
    {
        clsBusiness_Leave_Type objBusinessLeavetype = new clsBusiness_Leave_Type();
        clsEntity_Leave_Type ObjEntityLeaveType = new clsEntity_Leave_Type();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityLeaveType.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityLeaveType.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtdepartment = objBusinessLeavetype.ReadPaygrade(ObjEntityLeaveType);
        if (dtdepartment.Rows.Count > 0)
        {
            ddlpay.DataSource = dtdepartment;
            ddlpay.Items.Clear();

            ddlpay.DataValueField = "PYGRD_ID";
            ddlpay.DataTextField = "PYGRD_NAME";



           
            ddlpay.DataBind();

        }
 

    }
    //for load the experience designation

    public void DesignationLoad()
    {
        clsBusiness_Leave_Type objBusinessLeavetype = new clsBusiness_Leave_Type();
        clsEntity_Leave_Type ObjEntityLeaveType = new clsEntity_Leave_Type();


        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityLeaveType.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityLeaveType.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtdesig = objBusinessLeavetype.ReadDesignation(ObjEntityLeaveType);
        if (dtdesig.Rows.Count > 0)
        {
            ddlmodeSearch.DataSource = dtdesig;
            ddlmodeSearch.Items.Clear();

            ddlmodeSearch.DataValueField = "DSGN_ID";
            ddlmodeSearch.DataTextField = "DSGN_NAME";



        
            ddlmodeSearch.DataBind();

        }
   

    }
    // for the upadtion of data
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusiness_Leave_Type objBusinessLeavetype = new clsBusiness_Leave_Type();
        clsEntity_Leave_Type ObjEntityLeaveType = new clsEntity_Leave_Type();

        List<clsEntity_designation_list> ObjEntityLeaveDesignationList = new List<clsEntity_designation_list>();
        List<clsEntity_paygrade_list> ObjEntityLeavPayGradeList = new List<clsEntity_paygrade_list>();
        List<clsEntity_experience_list> ObjEntityLeaveExpriencenOList = new List<clsEntity_experience_list>();

        List<clsEntity_Users_list> objEntityUser_List = new List<clsEntity_Users_list>();
        DataTable dtPaygrdUsers = new DataTable();
        DataTable dtDsgnUsers = new DataTable();
        DataTable dtExpUsers = new DataTable();
        DataTable dtMoreExpUsers = new DataTable();
        
        string UserID = "";
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
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

        if (Session["USERID"] != null)
        {
            ObjEntityLeaveType.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        //if (cbxExcSalProc.Checked == true)
        //{
        //    ObjEntityLeaveType.ExcSalProc = 1;
        //}
        //else
        //{
        //    ObjEntityLeaveType.ExcSalProc = 0;
        //}
        if (cbxIncDutyRejoin.Checked == true)
        {
            ObjEntityLeaveType.IncDutyRejoin = 1;
        }
        else
        {
            ObjEntityLeaveType.IncDutyRejoin = 0;
        }
        if (cbxHoliPaid.Checked == true)
        {
            ObjEntityLeaveType.HoliPaid = 1;
        }
        else
        {
            ObjEntityLeaveType.HoliPaid = 0;
        }
        if (cbxOffPaid.Checked == true)
        {
            ObjEntityLeaveType.OffPaid = 1;
        }
        else
        {
            ObjEntityLeaveType.OffPaid = 0;
        }


        //Status checkbox checked
        if (CbxStatus.Checked == true)
        {
            ObjEntityLeaveType.Status_id = 1;
        }
        //Status checkbox not checked
        else
        {
            ObjEntityLeaveType.Status_id = 0;
        }
        // checkbox for travel 

        if (cbxTravel.Checked == true)
        {
            ObjEntityLeaveType.intTravelNeeded = 1;
        }
     
        else
        {
            ObjEntityLeaveType.intTravelNeeded = 0;
        }

        //monthly leave
        if (cbxMonthly.Checked == true)
        {
            ObjEntityLeaveType.Monthly = 1;
        }
        else
        {
            ObjEntityLeaveType.Monthly = 0;
        }

        // checkbox for leave 
        if (cbxleave.Checked == true)
        {
            ObjEntityLeaveType.intPaidLeave = 1;

            if (cbxSettlmt.Checked == true)
            {
                ObjEntityLeaveType.SettlmtSts = 1;
            }
            else
            {
                ObjEntityLeaveType.SettlmtSts = 0;
            }
        }
     
        else
        {
            ObjEntityLeaveType.intPaidLeave = 0;
        }
        // radiobutton for calender 
        if
            (RbCalendar.Checked == true)
        {
            ObjEntityLeaveType.intCalendarRb = 0;
        }
        else if
            // radiobutton for workig day 
            (Rbwrkgday.Checked == true)
        {
            ObjEntityLeaveType.intCalendarRb = 1;
        }
        // radiobutton for sex 
        if
             (RbMale.Checked == true)
        {
            ObjEntityLeaveType.intsexRb = 0;
        }
        else if
            (RBfemale.Checked == true)
        {
            ObjEntityLeaveType.intsexRb = 1;
        }
        else
        {
            ObjEntityLeaveType.intsexRb = 2;
        }

        // radiobutton for marital status 

        if
            (Rbsingle.Checked == true)
        {
            ObjEntityLeaveType.MaritalStatus = 0;
        }
        else if
            (RBMarried.Checked == true)
        {
            ObjEntityLeaveType.MaritalStatus = 1;
        }
        else
        {
            ObjEntityLeaveType.MaritalStatus = 2;
        }

        //if (cbxAll1.Enabled == true)
        //{
        //    int a = 1;
        //}

        // checkbox for designation 
        //if (cbxAll1.Enabled == true)
        //{
        //    ObjEntityLeaveType.intDesignationStatus = 1;
        //    ddlmodeSearch.Enabled = false;
        //}

        if (cbxNone.Checked == false)
        {
            if (cbxAll1.Checked == true)
            {
                ObjEntityLeaveType.intDesignationStatus = 1;
                ddlmodeSearch.Enabled = false;
            }

            else
            {
                if (hiddenselectedDesignlist.Value != "")
                {
                    string[] tokens = hiddenselectedDesignlist.Value.Split(',');

                    for (int i = 0; i < tokens.Count(); i++)
                    {

                        int DesnationId = Convert.ToInt32(tokens[i]);
                        clsEntity_designation_list objentityDesignation = new clsEntity_designation_list();
                        objentityDesignation.intDesignationlist_id = DesnationId;
                        ObjEntityLeaveDesignationList.Add(objentityDesignation);
                    }

                    ObjEntityLeaveType.DesignationID = hiddenselectedDesignlist.Value;
                    dtDsgnUsers = objBusinessLeavetype.ReadDesignationUsers(ObjEntityLeaveType);
                    for (int i = 0; i < dtDsgnUsers.Rows.Count; i++)
                    {
                        clsEntity_Users_list objEntityUsers_list = new clsEntity_Users_list();
                        if (!(UserID.Contains(dtDsgnUsers.Rows[i]["USR_ID"].ToString())))
                        {
                            UserID = UserID + "," + dtDsgnUsers.Rows[i]["USR_ID"].ToString();
                            objEntityUsers_list.UserID = Convert.ToInt32(dtDsgnUsers.Rows[i]["USR_ID"].ToString());
                            objEntityUser_List.Add(objEntityUsers_list);
                        }
                    }
                }

            }
            // checkbox for paygrade 
            if (cbxAll2.Checked == true)
            {
                ObjEntityLeaveType.intpaygradestatus = 1;
                ddlpay.Enabled = false;
            }

            else
            {
                if (hiddenselectedPaygradelist.Value != "")
                {
                    string[] tokens = hiddenselectedPaygradelist.Value.Split(',');

                    for (int i = 0; i < tokens.Count(); i++)
                    {

                        int payGradeId = Convert.ToInt32(tokens[i]);
                        clsEntity_paygrade_list objentitypaygrade = new clsEntity_paygrade_list();
                        objentitypaygrade.intpaygradelist_id = payGradeId;
                        ObjEntityLeavPayGradeList.Add(objentitypaygrade);
                    }

                    ObjEntityLeaveType.Paygrade = hiddenselectedPaygradelist.Value;
                    dtPaygrdUsers = objBusinessLeavetype.ReadPaygradeUsers(ObjEntityLeaveType);
                    for (int i = 0; i < dtPaygrdUsers.Rows.Count; i++)
                    {
                        clsEntity_Users_list objEntityUsers_list = new clsEntity_Users_list();
                        if (!(UserID.Contains(dtPaygrdUsers.Rows[i]["USER_ID"].ToString())))
                        {
                            UserID = UserID + "," + dtPaygrdUsers.Rows[i]["USER_ID"].ToString();
                            objEntityUsers_list.UserID = Convert.ToInt32(dtPaygrdUsers.Rows[i]["USER_ID"].ToString());
                            objEntityUser_List.Add(objEntityUsers_list);
                        }
                    }

                }
            }

            // checkbox for experience 
            if (cbxAll3.Checked == true)
            {
                ObjEntityLeaveType.intexperiencesstatus = 1;
                ddlexp.Enabled = false;
            }

            else
            {
                if (hiddenselectedExperiencelist.Value != "")
                {
                    string[] tokens = hiddenselectedExperiencelist.Value.Split(',');

                    string StrExperience = "";
                    DataTable dtExp = objBusinessLeavetype.ReadExperienceByID(ObjEntityLeaveType);
                    DataTable table = new DataTable("Experience");
                    table.Columns.Add(new DataColumn("Id", typeof(int)));
                    table.Columns.Add(new DataColumn("Min", typeof(float)));
                    table.Columns.Add(new DataColumn("Max", typeof(float)));
                    for (int introwCount = 0; introwCount < dtExp.Rows.Count; introwCount++)
                    {
                        DataRow drDtl = table.NewRow();
                        foreach (DataRow dtRowsIn in dtExp.Rows)
                        {


                            drDtl["Id"] = dtExp.Rows[introwCount]["LEAVDTLS_EXPMASTR_ID"].ToString();
                            drDtl["Min"] = dtExp.Rows[introwCount]["EXPMASTR_MIN_YEAR"].ToString();
                            drDtl["Max"] = dtExp.Rows[introwCount]["EXPMASTR_MAX_YEAR"].ToString();
                        }
                        table.Rows.Add(drDtl);

                    }
                    for (int i = 0; i < tokens.Count(); i++)
                    {
                        int experienceId = Convert.ToInt32(tokens[i]);
                        DataRow[] results = table.Select("Id =" + experienceId);
                        if (results.Length > 0)
                        {
                            foreach (DataRow row in results)
                            {
                                string strMin = row[1].ToString();
                                string strMax = row[2].ToString();
                                //for (int intExpMin = Convert.ToInt32(strMin); intExpMin <= Convert.ToInt32(strMax); intExpMin++)
                                //{
                                //    StrExperience = StrExperience + "," + intExpMin.ToString();
                                //}

                                for (decimal intExpMin = Convert.ToDecimal(strMin); intExpMin <= Convert.ToDecimal(strMax); intExpMin++)
                                {
                                    StrExperience = StrExperience + "," + intExpMin.ToString();
                                }
                            }
                        }
                        clsEntity_experience_list objentityExperience = new clsEntity_experience_list();
                        objentityExperience.intexperiencelist_id = experienceId;
                        ObjEntityLeaveExpriencenOList.Add(objentityExperience);
                    }
                    if (StrExperience != "")
                    {
                        ObjEntityLeaveType.Experience = StrExperience;
                    }
                    dtExpUsers = objBusinessLeavetype.ReadExperienceUsers(ObjEntityLeaveType);
                    for (int J = 0; J < dtExpUsers.Rows.Count; J++)
                    {
                        clsEntity_Users_list objEntityUsers_list = new clsEntity_Users_list();
                        if (!(UserID.Contains(dtExpUsers.Rows[J]["USER_ID"].ToString())))
                        {
                            UserID = UserID + "," + dtExpUsers.Rows[J]["USER_ID"].ToString();
                            objEntityUsers_list.UserID = Convert.ToInt32(dtExpUsers.Rows[J]["USER_ID"].ToString());
                            objEntityUser_List.Add(objEntityUsers_list);
                        }
                    }
                }
            }
        }
        else
        {
            ObjEntityLeaveType.ApplicableNone = 1;
            ObjEntityLeaveType.intDesignationStatus = 0;
            ObjEntityLeaveType.intpaygradestatus = 0;
            ObjEntityLeaveType.intexperiencesstatus = 0;
            ObjEntityLeaveDesignationList.Clear();
            ObjEntityLeavPayGradeList.Clear();
            ObjEntityLeaveExpriencenOList.Clear();
            objEntityUser_List.Clear();
        }

        ObjEntityLeaveType.LeaveTypeMasterId = Convert.ToInt32(HiddenLeaveId.Value);

        ObjEntityLeaveType.LeaveDesc = txtDesc.Text.ToUpper();
        ObjEntityLeaveType.LeaveTypeName = TypNme.Text.Trim().ToUpper();
        ObjEntityLeaveType.NoOfDays = Convert.ToInt32(Request.Form[NumDays.UniqueID]);
        ObjEntityLeaveType.LeaveTypeName = TypNme.Text.Trim().ToUpper();
       // ObjEntityLeaveType.NoOfDays = Convert.ToInt32(NumDays.Text.Trim().ToUpper());
        string strNameCount = "0";
        if (TypNme.Text != "" && TypNme.Text != null)
        {
            ObjEntityLeaveType.LeaveTypeName = TypNme.Text.Trim().ToUpper();
            strNameCount = objBusinessLeavetype.CheckLeaveName(ObjEntityLeaveType);
        }
       // ObjEntityLeaveType.NoOfDays = Convert.ToInt32(NumDays.Text.Trim().ToUpper());
        ObjEntityLeaveType.intleave = Convert.ToInt32(HiddenLeaveId.Value);

        string strCheckLeavOnAbsnc = "0";

        if (cbxLeaveOnAbsence.Checked == true)
        {
            ObjEntityLeaveType.LeaveOnAbsence = 1;
            strCheckLeavOnAbsnc = objBusinessLeavetype.CheckLeavOnAbsnc(ObjEntityLeaveType);

        }
        else
        {
            ObjEntityLeaveType.LeaveOnAbsence = 0;
        }


        //If there is no name like this on table.    
        if (strNameCount == "0" && strCheckLeavOnAbsnc=="0")
        {
            objBusinessLeavetype.UpdateLeaveType(ObjEntityLeaveType, ObjEntityLeaveDesignationList, ObjEntityLeavPayGradeList, ObjEntityLeaveExpriencenOList, objEntityUser_List);

            if (clickedButton.ID == "btnUpdate")
            {
                Response.Redirect("hcm_leave_master.aspx?InsUpd=Upd");
            }
            else if (clickedButton.ID == "btnUpdateClose")
            {
                
                Response.Redirect("hcm_leave_master_List.aspx?InsUpd=Upd");
            }

        }
     
        else
        {
            if (strNameCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);

            }
            else if (strCheckLeavOnAbsnc != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationLeavAbsnc", "DuplicationLeavAbsnc();", true);
            }

        }





    }

}