using BL_Compzit;
using BL_Compzit.BusinessLayer_AWMS;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Collections;

public partial class AWMS_AWMS_Transaction_flt_Job_Shdl_flt_Job_Shdl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            ddlTimeSlot_PeriodWise.Attributes.Add("onkeypress", "return DisableEnter(event)");
            ddlTimeSlot_DayWise.Attributes.Add("onkeypress", "return DisableEnter(event)");



            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableConfirm = 0, intEnableReOpen = 0;
            //   hiddenRoleConfirm.Value = "0";
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();

            hiddenCurrentDate.Value = strCurrentDate;

            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            hiddenUserId.Value = Convert.ToString(intUserId);

            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Job_Schedule);
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
                        intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        //  hiddenRoleConfirm.Value = intEnableConfirm.ToString();

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);


                    }


                }

                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    btnSave.Visible = true;
                    //  btnSaveClose.Visible = true;

                }
                else
                {

                    btnSave.Visible = false;
                    // btnSaveClose.Visible = false;
                }
                if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    btnUpdate.Visible = true;
                    // btnUpdateClose.Visible = true;

                }
                else
                {

                    btnUpdate.Visible = false;
                    //  btnUpdateClose.Visible = false;

                }
                if (intEnableConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    //btnConfirm.Visible = true;

                }
                else
                {

                    //btnConfirm.Visible = false;


                }



                //Loading Terms in dropdown
                TimeSlotLoad();



                int intCorpId = 0;
                int intOrgId = 0;
                if (Session["CORPOFFICEID"] != null)
                {

                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    hiddenCorporateId.Value = Session["CORPOFFICEID"].ToString();

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {

                    intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                    hiddenOrganisationId.Value = Session["ORGID"].ToString();

                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }



                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                            clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                        
                                                                      
                                                              };
                DataTable dtCorpDetail = new DataTable();
                dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                if (dtCorpDetail.Rows.Count > 0)
                {

                    hiddenFloatingValueMoney.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();

                }

                btnReopen.Visible = false;

                //when editing 
                if (Request.QueryString["Id"] != null)
                {
                    if (intEnableConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        btnConfirm.Visible = true;

                    }
                    else
                    {

                        btnConfirm.Visible = false;


                    }
                    btnClear.Visible = false;
                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);
                    int intEmpId = Convert.ToInt32(strId);

                    hiddenEmpJSId.Value = strId;



                    clsBusinessLayerJobShdl objBusinessLayerJobShdl = new clsBusinessLayerJobShdl();
                    clsEntityLayerJobSchedule objEntityJobShdl = new clsEntityLayerJobSchedule();
                    DataTable dtEmpName = new DataTable();
                    objEntityJobShdl.JobSchdlUserId = intEmpId;
                    dtEmpName = objBusinessLayerJobShdl.ReadEmpName(objEntityJobShdl);
                    lblEmpName.Text = dtEmpName.Rows[0][0].ToString();
                    string strRandomMixedId1 = Request.QueryString["ShdlId"].ToString();
                    string strLenghtofId1 = strRandomMixedId1.Substring(0, 2);
                    int intLenghtofId1 = Convert.ToInt16(strLenghtofId1);
                    string strId1 = strRandomMixedId1.Substring(2, intLenghtofId1);
                    int intJobSchdlId = Convert.ToInt32(strId1);

                    HiddenFieldJobScdlID.Value = strId1;

                    EditView(intJobSchdlId, 1);
                    lblEntry.Text = "Edit Job Schedule";

                    if (hiddenConfirmedEntry.Value == "1")
                    {
                        objEntityJobShdl.JobSchdlUserId = intEmpId;
                        objEntityJobShdl.Fromdate = objCommon.textToDateTime(txtFromDate.Text);
                        objEntityJobShdl.Todate = objCommon.textToDateTime(txtToDate.Text);
                        DataTable dtDutyRstr = objBusinessLayerJobShdl.ReadDutyRstr(objEntityJobShdl);
                        if (dtDutyRstr.Rows.Count == 0)
                        {
                            if (intEnableReOpen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                            {
                                btnReopen.Visible = true;

                            }
                        }

                        btnConfirm.Visible = false;
                        txtFromDate.Enabled = false;
                        txtToDate.Enabled = false;
                        cbxMustDayWise.Enabled = false;
                        btnClearAll.Visible = false;
                        btnUpdate.Visible = false;
                        btnClearRowDW.Visible = false;
                        btnClearRowPW.Visible = false;


                    }
                    if (Request.QueryString["InsUpd"] != null)
                    {
                        string strInsUpd = Request.QueryString["InsUpd"].ToString();


                        if (strInsUpd == "NotCnfrm")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "FailureConfirmation", "FailureConfirmation();", true);
                        }



                        else if (strInsUpd == "NotReOpen")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "FailureReOpen", "FailureReOpen();", true);
                        }
                    }
                }
                //when  viewing
                else if (Request.QueryString["ViewId"] != null)
                {
                    btnClear.Visible = false;
                    //   btnReOpen.Visible = false;
                    btnConfirm.Visible = false;
                    string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);
                    int intEmpId = Convert.ToInt32(strId);

                    clsBusinessLayerJobShdl objBusinessLayerJobShdl = new clsBusinessLayerJobShdl();
                    clsEntityLayerJobSchedule objEntityJobShdl = new clsEntityLayerJobSchedule();
                    DataTable dtEmpName = new DataTable();
                    objEntityJobShdl.JobSchdlUserId = intEmpId;
                    dtEmpName = objBusinessLayerJobShdl.ReadEmpName(objEntityJobShdl);
                    lblEmpName.Text = dtEmpName.Rows[0][0].ToString();

                    string strRandomMixedId1 = Request.QueryString["ShdlId"].ToString();
                    string strLenghtofId1 = strRandomMixedId1.Substring(0, 2);
                    int intLenghtofId1 = Convert.ToInt16(strLenghtofId1);
                    string strId1 = strRandomMixedId1.Substring(2, intLenghtofId1);
                    int intJobSchdlId = Convert.ToInt32(strId1);
                    EditView(intJobSchdlId, 2);

                    lblEntry.Text = "View Job Schedule";

                }
                else if (Request.QueryString["EmpId"] != null)
                {

                    HiddenFieldJobScdlID.Value = "0";

                    btnConfirm.Visible = false;
                    lblEntry.Text = "Add Job Schedule";
                    string strRandomMixedId = Request.QueryString["EmpId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);
                    hiddenEmpJSId.Value = strId;
                    hiddenEmpJSIdQS.Value = Request.QueryString["EmpId"].ToString();
                    clsBusinessLayerJobShdl objBusinessLayerJobShdl = new clsBusinessLayerJobShdl();
                    clsEntityLayerJobSchedule objEntityJobShdl = new clsEntityLayerJobSchedule();
                    DataTable dtEmpName = new DataTable();
                    objEntityJobShdl.JobSchdlUserId = Convert.ToInt32(strId);
                    dtEmpName = objBusinessLayerJobShdl.ReadEmpName(objEntityJobShdl);
                    lblEmpName.Text = dtEmpName.Rows[0][0].ToString();
                    btnUpdate.Visible = false;
                    // btnUpdateClose.Visible = false;
                    //   btnConfirm.Visible = false;
                    //   btnReOpen.Visible = false;




                }

                if (Request.QueryString["InsUpd"] != null)
                {
                    string strInsUpd = Request.QueryString["InsUpd"].ToString();
                    if (strInsUpd == "Save")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessSave", "SuccessSave();", true);
                    }
                    else if (strInsUpd == "Upd")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                    }
                    else if (strInsUpd == "Cnfrm")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                    }
                    else if (strInsUpd == "NotCnfrm")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "FailureConfirmation", "FailureConfirmation();", true);
                    }

                    else if (strInsUpd == "Reopen")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReOpen", "SuccessReOpen();", true);
                    }

                    else if (strInsUpd == "NotReOpen")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "FailureReOpen", "FailureReOpen();", true);
                    }
                    else if (strInsUpd == "CnfrmPnd")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ConfirmPnd", "ConfirmPnd();", true);
                    }
                }

            }
            else
            {
                btnSave.Visible = false;
                //  btnSaveClose.Visible = false;
                btnUpdate.Visible = false;
                // btnUpdateClose.Visible = false;
                //  btnReOpen.Visible = false;
                //  btnConfirm.Visible = false;
                // btnClose.Visible = false;
                btnClear.Visible = false;

            }


        }
    }


    //This is the method for binding timeslot to dropdown list.
    public void TimeSlotLoad()
    {
        ddlTimeSlot_PeriodWise.Items.Clear();
        ddlTimeSlot_DayWise.Items.Clear();
        clsBusinessLayerJobShdl objBusinessLayerJobShdl = new clsBusinessLayerJobShdl();
        clsEntityLayerJobSchedule objEntityJobShdl = new clsEntityLayerJobSchedule();
        if (hiddenCorporateId.Value == "")
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityJobShdl.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {

            objEntityJobShdl.CorpOffice_Id = Convert.ToInt32(hiddenCorporateId.Value);
        }
        if (hiddenOrganisationId.Value == "")
        {
            if (Session["ORGID"] != null)
            {
                objEntityJobShdl.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {
            objEntityJobShdl.Organisation_Id = Convert.ToInt32(hiddenOrganisationId.Value);
        }
        DataTable dtTimeSlots = new DataTable();
        dtTimeSlots = objBusinessLayerJobShdl.ReadTimeSlotMasters(objEntityJobShdl);


        //Period Wise
        ddlTimeSlot_PeriodWise.DataSource = dtTimeSlots;
        ddlTimeSlot_PeriodWise.DataTextField = "TMSLT_NAME";
        ddlTimeSlot_PeriodWise.DataValueField = "TMSLT_ID";
        ddlTimeSlot_PeriodWise.DataBind();
        ddlTimeSlot_PeriodWise.Items.Insert(0, "--SELECT TIME SLOT--");

        //Day Wise
        ddlTimeSlot_DayWise.DataSource = dtTimeSlots;
        ddlTimeSlot_DayWise.DataTextField = "TMSLT_NAME";
        ddlTimeSlot_DayWise.DataValueField = "TMSLT_ID";
        ddlTimeSlot_DayWise.DataBind();
        ddlTimeSlot_DayWise.Items.Insert(0, "--SELECT TIME SLOT--");


    }



    private void EditView(int intJobSchdlId, int intEditOrView)
    {//when Editing or viewing
        //intEditOrView if 1-Edit,2-View
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerJobShdl objBusinessLayerJobShdl = new clsBusinessLayerJobShdl();
        clsEntityLayerJobSchedule objEntityJobShdl = new clsEntityLayerJobSchedule();
        objEntityJobShdl.JobSchdlId = intJobSchdlId;
        if (hiddenCorporateId.Value == "")
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityJobShdl.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {

            objEntityJobShdl.CorpOffice_Id = Convert.ToInt32(hiddenCorporateId.Value);
        }

        if (hiddenOrganisationId.Value == "")
        {
            if (Session["ORGID"] != null)
            {
                objEntityJobShdl.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {
            objEntityJobShdl.Organisation_Id = Convert.ToInt32(hiddenOrganisationId.Value);
        }
        DataTable dtJSPeriodWiseDtl = new DataTable();
        DataTable dtJSDayWiseDtl = new DataTable();
        //   DataTable dtWBill = new DataTable();


        dtJSPeriodWiseDtl = objBusinessLayerJobShdl.ReadJobSchdlDetail(objEntityJobShdl, 0);//0-period wise

        dtJSDayWiseDtl = objBusinessLayerJobShdl.ReadJobSchdlDetail(objEntityJobShdl, 1);//1-pDay wise

        if (dtJSPeriodWiseDtl.Rows.Count > 0)
        {
            txtFromDate.Text = dtJSPeriodWiseDtl.Rows[0]["JOBSHDL_FROM_DATE"].ToString();
            txtToDate.Text = dtJSPeriodWiseDtl.Rows[0]["JOBSHDL_TO_DATE"].ToString();
            hiddenConfirmedEntry.Value = "0";
            if (dtJSPeriodWiseDtl.Rows[0]["JOBSHDL_CNFRM_USR_ID"].ToString() != "0")
            {
                hiddenConfirmedEntry.Value = "1";
                btnConfirm.Visible = false;
                btnUpdate.Visible = false;
            }

            //ie IF  timeslot IS ACTIVE
            if (dtJSPeriodWiseDtl.Rows[0]["TMSLT_STATUS"].ToString() == "1" && dtJSPeriodWiseDtl.Rows[0]["TMSLT_CNCL_USR_ID"].ToString() == "")
            {
                ddlTimeSlot_PeriodWise.ClearSelection();
                ddlTimeSlot_PeriodWise.Items.FindByValue(dtJSPeriodWiseDtl.Rows[0]["TMSLT_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lst = new ListItem(dtJSPeriodWiseDtl.Rows[0]["TMSLT_NAME"].ToString(), dtJSPeriodWiseDtl.Rows[0]["TMSLT_ID"].ToString());
                ddlTimeSlot_PeriodWise.Items.Insert(1, lst);

                SortDDL(ref this.ddlTimeSlot_PeriodWise);
                ddlTimeSlot_PeriodWise.ClearSelection();
                ddlTimeSlot_PeriodWise.Items.FindByValue(dtJSPeriodWiseDtl.Rows[0]["TMSLT_ID"].ToString()).Selected = true;
            }





            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("TransId", typeof(int));
            dtDetail.Columns.Add("TransDtlId", typeof(int));
            dtDetail.Columns.Add("JobName", typeof(string));
            dtDetail.Columns.Add("JobId", typeof(int));
            dtDetail.Columns.Add("VhclNumbr", typeof(string));
            dtDetail.Columns.Add("VhclId", typeof(int));
            dtDetail.Columns.Add("PrjctName", typeof(string));
            dtDetail.Columns.Add("PrjctId", typeof(int));
            dtDetail.Columns.Add("FromTime", typeof(string));
            dtDetail.Columns.Add("ToTime", typeof(string));
            dtDetail.Columns.Add("JobMode", typeof(int));
            dtDetail.Columns.Add("txtJobName", typeof(string));


            for (int intcnt = 0; intcnt < dtJSPeriodWiseDtl.Rows.Count; intcnt++)
            {
                DataRow drDtl = dtDetail.NewRow();
                drDtl["TransId"] = Convert.ToInt32(dtJSPeriodWiseDtl.Rows[intcnt]["JOBSHDL_ID"].ToString());
                drDtl["TransDtlId"] = Convert.ToInt32(dtJSPeriodWiseDtl.Rows[intcnt]["JOBSHDLDTL_ID"].ToString());
                drDtl["JobName"] = dtJSPeriodWiseDtl.Rows[intcnt]["JOBMSTR_TITLE"].ToString();
                if (dtJSPeriodWiseDtl.Rows[intcnt]["JOBMSTR_ID"].ToString() != "")
                {
                    drDtl["JobId"] = Convert.ToInt32(dtJSPeriodWiseDtl.Rows[intcnt]["JOBMSTR_ID"].ToString());

                }
                else
                {
                    // WHEN CHANGING MODE IT BECOMES NULL
                    drDtl["JobId"] = 0;
                }

                drDtl["VhclNumbr"] = dtJSPeriodWiseDtl.Rows[intcnt]["VHCL_NUMBR"].ToString();
                drDtl["VhclId"] = Convert.ToInt32(dtJSPeriodWiseDtl.Rows[intcnt]["VHCL_ID"].ToString());
                drDtl["PrjctName"] = dtJSPeriodWiseDtl.Rows[intcnt]["PROJECT_NAME"].ToString();
                drDtl["PrjctId"] = Convert.ToInt32(dtJSPeriodWiseDtl.Rows[intcnt]["PROJECT_ID"].ToString());
                drDtl["FromTime"] = dtJSPeriodWiseDtl.Rows[intcnt]["JOBSHDLDTL_FROM_TIME"].ToString();
                drDtl["ToTime"] = dtJSPeriodWiseDtl.Rows[intcnt]["JOBSHDLDTL_TO_TIME"].ToString();
                drDtl["JobMode"] = Convert.ToInt32(dtJSPeriodWiseDtl.Rows[intcnt]["JOBSHDLDTL_JOB_MODE"].ToString());
                drDtl["txtJobName"] = dtJSPeriodWiseDtl.Rows[intcnt]["JOB_NAME"].ToString();
                dtDetail.Rows.Add(drDtl);

            }

            string strJsonPW = DataTableToJSONWithJavaScriptSerializer(dtDetail);

            hiddenDataPeriodWise.Value = strJsonPW;


        }

        if (dtJSDayWiseDtl.Rows.Count > 0)
        {
            btnClearAll.Visible = true;
            cbxMustDayWise.Enabled = false;
            cbxMustDayWise.Checked = true;
            //ie IF  timeslot IS ACTIVE
            if (dtJSDayWiseDtl.Rows[0]["TMSLT_STATUS"].ToString() == "1" && dtJSDayWiseDtl.Rows[0]["TMSLT_CNCL_USR_ID"].ToString() == "")
            {
                ddlTimeSlot_DayWise.ClearSelection();
                ddlTimeSlot_DayWise.Items.FindByValue(dtJSDayWiseDtl.Rows[0]["TMSLT_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lst = new ListItem(dtJSDayWiseDtl.Rows[0]["TMSLT_NAME"].ToString(), dtJSDayWiseDtl.Rows[0]["TMSLT_ID"].ToString());
                ddlTimeSlot_DayWise.Items.Insert(1, lst);

                SortDDL(ref this.ddlTimeSlot_DayWise);
                ddlTimeSlot_DayWise.ClearSelection();
                ddlTimeSlot_DayWise.Items.FindByValue(dtJSDayWiseDtl.Rows[0]["TMSLT_ID"].ToString()).Selected = true;
            }





            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("TransId", typeof(int));
            dtDetail.Columns.Add("TransDtlId", typeof(int));
            dtDetail.Columns.Add("JobName", typeof(string));
            dtDetail.Columns.Add("JobId", typeof(int));
            dtDetail.Columns.Add("VhclNumbr", typeof(string));
            dtDetail.Columns.Add("VhclId", typeof(int));
            dtDetail.Columns.Add("PrjctName", typeof(string));
            dtDetail.Columns.Add("PrjctId", typeof(int));
            dtDetail.Columns.Add("FromTime", typeof(string));
            dtDetail.Columns.Add("ToTime", typeof(string));
            dtDetail.Columns.Add("JobMode", typeof(int));
            dtDetail.Columns.Add("txtJobName", typeof(string));


            for (int intcnt = 0; intcnt < dtJSDayWiseDtl.Rows.Count; intcnt++)
            {
                DataRow drDtl = dtDetail.NewRow();
                drDtl["TransId"] = Convert.ToInt32(dtJSDayWiseDtl.Rows[intcnt]["JOBSHDL_ID"].ToString());
                drDtl["TransDtlId"] = Convert.ToInt32(dtJSDayWiseDtl.Rows[intcnt]["JOBSHDLDTL_ID"].ToString());
                drDtl["JobName"] = dtJSDayWiseDtl.Rows[intcnt]["JOBMSTR_TITLE"].ToString();
                if (dtJSDayWiseDtl.Rows[intcnt]["JOBMSTR_ID"].ToString() != "")
                {
                    drDtl["JobId"] = Convert.ToInt32(dtJSDayWiseDtl.Rows[intcnt]["JOBMSTR_ID"].ToString());

                }
                else
                {
                    // WHEN CHANGING MODE IT BECOMES NULL
                    drDtl["JobId"] = 0;
                }

                drDtl["VhclNumbr"] = dtJSDayWiseDtl.Rows[intcnt]["VHCL_NUMBR"].ToString();
                drDtl["VhclId"] = Convert.ToInt32(dtJSDayWiseDtl.Rows[intcnt]["VHCL_ID"].ToString());
                drDtl["PrjctName"] = dtJSDayWiseDtl.Rows[intcnt]["PROJECT_NAME"].ToString();
                drDtl["PrjctId"] = Convert.ToInt32(dtJSDayWiseDtl.Rows[intcnt]["PROJECT_ID"].ToString());
                drDtl["FromTime"] = dtJSDayWiseDtl.Rows[intcnt]["JOBSHDLDTL_FROM_TIME"].ToString();
                drDtl["ToTime"] = dtJSDayWiseDtl.Rows[intcnt]["JOBSHDLDTL_TO_TIME"].ToString();
                drDtl["JobMode"] = Convert.ToInt32(dtJSDayWiseDtl.Rows[intcnt]["JOBSHDLDTL_JOB_MODE"].ToString());
                drDtl["txtJobName"] = dtJSDayWiseDtl.Rows[intcnt]["JOB_NAME"].ToString();
                dtDetail.Rows.Add(drDtl);

            }

            string strJsonDW = DataTableToJSONWithJavaScriptSerializer(dtDetail);

            hiddenDataDayWise.Value = strJsonDW;


        }
        else
        {

            btnClearAll.Visible = false;
            cbxMustDayWise.Enabled = true;
            cbxMustDayWise.Checked = false;

        }


        DataTable dtWeekDayList = objBusinessLayerJobShdl.ReadJobSchdlWeekDetail(objEntityJobShdl);

        if (dtWeekDayList.Rows.Count > 0)
        {

            for (int intCount = 0; intCount < dtWeekDayList.Rows.Count; intCount++)
            {

                hiddenWeekDayId.Value = hiddenWeekDayId.Value + dtWeekDayList.Rows[intCount]["WEEK_DAYS_ID"].ToString().Trim() + ",";
            }
        }


        if (intEditOrView == 1)
        {
            btnSave.Visible = false;
            //   btnSaveClose.Visible = false;
            hiddenEdit.Value = "EDIT";
        }
        else if (intEditOrView == 2)
        {

            btnSave.Visible = false;
            //  btnSaveClose.Visible = false;
            btnUpdate.Visible = false;
            // btnUpdateClose.Visible = false;
            hiddenView.Value = "VIEW";
        }
    }


    public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
    {
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
        Dictionary<string, object> childRow;
        foreach (DataRow row in table.Rows)
        {
            childRow = new Dictionary<string, object>();
            foreach (DataColumn col in table.Columns)
            {
                childRow.Add(col.ColumnName, row[col]);

            }

            parentRow.Add(childRow);
        }
        return jsSerializer.Serialize(parentRow);
    }

    public class clsJSData
    {
        public string JOBID { get; set; }
        public string JOBNAME { get; set; }
        public string VHCLID { get; set; }
        public string PRJCTID { get; set; }
        public string FROMTIME { get; set; }
        public string TOTIME { get; set; }
        public string EVTACTION { get; set; }
        public string DTLID { get; set; }
        public string JOBMODE { get; set; }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayerJobShdl objBusinessLayerJobShdl = new clsBusinessLayerJobShdl();
            clsEntityLayerJobSchedule objEntityJobShdl = new clsEntityLayerJobSchedule();
            int intUserId = 0;
            if (hiddenCorporateId.Value == "")
            {
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityJobShdl.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            else
            {

                objEntityJobShdl.CorpOffice_Id = Convert.ToInt32(hiddenCorporateId.Value);
            }
            if (hiddenOrganisationId.Value == "")
            {
                if (Session["ORGID"] != null)
                {
                    objEntityJobShdl.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            else
            {
                objEntityJobShdl.Organisation_Id = Convert.ToInt32(hiddenOrganisationId.Value);
            }
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Request.QueryString["EmpId"] != null)
            {

                string strRandomMixedId = Request.QueryString["EmpId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityJobShdl.JobSchdlUserId = Convert.ToInt32(strId);
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityJobShdl.Fromdate = objCommon.textToDateTime(txtFromDate.Text);
            objEntityJobShdl.Todate = objCommon.textToDateTime(txtToDate.Text);


            objEntityJobShdl.User_Id = intUserId;

            if (cbxMustDayWise.Checked)
            {
                objEntityJobShdl.IsWeekWiseAvailable = 1;
            }
            else
            {
                objEntityJobShdl.IsWeekWiseAvailable = 0;
            }
            List<clsEntityLayerJobScheduleDtl> objEntityobScheduleDtlPeriodWiseList = new List<clsEntityLayerJobScheduleDtl>();
            List<clsEntityLayerJobScheduleDtl> objEntityobScheduleDtlDayWiseList = new List<clsEntityLayerJobScheduleDtl>();
            List<clsEntityLayerJobSchdlWeekDayDtl> objEntityJobScheduleWeekDayDtlList = new List<clsEntityLayerJobSchdlWeekDayDtl>();
            string jsonDataPW = HiddenField1.Value;
            string R1PW = jsonDataPW.Replace("\"{", "\\{");
            string R2PW = R1PW.Replace("\\n", "\r\n");
            string R3PW = R2PW.Replace("\\", "");
            string R4PW = R3PW.Replace("}\"]", "}]");
            string R5PW = R4PW.Replace("}\",", "},");
            List<clsJSData> objWBDataPWList = new List<clsJSData>();
            //   UserData  data
            objWBDataPWList = JsonConvert.DeserializeObject<List<clsJSData>>(R5PW);


            foreach (clsJSData objclsJSData in objWBDataPWList)
            {
                clsEntityLayerJobScheduleDtl objEntityDetails = new clsEntityLayerJobScheduleDtl();

                objEntityDetails.TimeSlotId = Convert.ToInt32(hiddenddlTimeSlotPWVal.Value);
                objEntityDetails.SchdlWiseMode = 0;
                string strFromDatetime = Convert.ToString("01-01-1000-" + objclsJSData.FROMTIME);
                objEntityDetails.FromTime = objCommon.textWithTimeToDateTime(strFromDatetime);
                string strToDatetime = Convert.ToString("01-01-1000-" + objclsJSData.TOTIME);
                objEntityDetails.ToTime = objCommon.textWithTimeToDateTime(strToDatetime);
                objEntityDetails.VhclId = Convert.ToInt32(objclsJSData.VHCLID);
                objEntityDetails.PrjctId = Convert.ToInt32(objclsJSData.PRJCTID);
                objEntityDetails.JobId = Convert.ToInt32(objclsJSData.JOBID);
                objEntityDetails.JobName = objclsJSData.JOBNAME.Trim();
                objEntityDetails.JobMode = Convert.ToInt32(objclsJSData.JOBMODE);

                objEntityobScheduleDtlPeriodWiseList.Add(objEntityDetails);

            }
            if (objEntityJobShdl.IsWeekWiseAvailable != 0)
            {
                string jsonDataDW = HiddenField2.Value;
                string R1DW = jsonDataDW.Replace("\"{", "\\{");
                string R2DW = R1DW.Replace("\\n", "\r\n");
                string R3DW = R2DW.Replace("\\", "");
                string R4DW = R3DW.Replace("}\"]", "}]");
                string R5DW = R4DW.Replace("}\",", "},");
                List<clsJSData> objWBDataDWList = new List<clsJSData>();
                //   UserData  data
                objWBDataDWList = JsonConvert.DeserializeObject<List<clsJSData>>(R5DW);


                foreach (clsJSData objclsJSData in objWBDataDWList)
                {
                    clsEntityLayerJobScheduleDtl objEntityDetails = new clsEntityLayerJobScheduleDtl();

                    objEntityDetails.TimeSlotId = Convert.ToInt32(hiddenddlTimeSlotDWVal.Value);
                    objEntityDetails.SchdlWiseMode = 1;
                    string strFromDatetime = Convert.ToString("01-01-1000-" + objclsJSData.FROMTIME);
                    objEntityDetails.FromTime = objCommon.textWithTimeToDateTime(strFromDatetime);
                    string strToDatetime = Convert.ToString("01-01-1000-" + objclsJSData.TOTIME);
                    objEntityDetails.ToTime = objCommon.textWithTimeToDateTime(strToDatetime);
                    objEntityDetails.VhclId = Convert.ToInt32(objclsJSData.VHCLID);
                    objEntityDetails.PrjctId = Convert.ToInt32(objclsJSData.PRJCTID);
                    objEntityDetails.JobId = Convert.ToInt32(objclsJSData.JOBID);
                    objEntityDetails.JobName = objclsJSData.JOBNAME.Trim();
                    objEntityDetails.JobMode = Convert.ToInt32(objclsJSData.JOBMODE);

                    objEntityobScheduleDtlDayWiseList.Add(objEntityDetails);

                }


                if (hiddenWeekDayId.Value != "")
                {

                    string strWeekList = hiddenWeekDayId.Value;
                    // Split string on spaces.
                    // ... This will separate all the words.
                    string[] strArrWeekDays = strWeekList.Split(',');
                    foreach (string strWeekDayId in strArrWeekDays)
                    {
                        if (strWeekDayId != "")
                        {
                            clsEntityLayerJobSchdlWeekDayDtl objEntityJobSchdlWeekDayDtl = new clsEntityLayerJobSchdlWeekDayDtl();
                            objEntityJobSchdlWeekDayDtl.WeekDaysId = Convert.ToInt32(strWeekDayId);
                            objEntityJobScheduleWeekDayDtlList.Add(objEntityJobSchdlWeekDayDtl);
                        }
                    }

                }

            }

            int intJobSchdlId = objBusinessLayerJobShdl.Insert_JobScheduling(objEntityJobShdl, objEntityobScheduleDtlPeriodWiseList, objEntityobScheduleDtlDayWiseList, objEntityJobScheduleWeekDayDtlList);


            if (clickedButton.ID == "btnSave")
            {
                Response.Redirect("flt_Job_Shdl_List.aspx?InsUpd=Save");
            }
            /* else if (clickedButton.ID == "btnSaveClose")
             {
                 Response.Redirect("flt_Job_Shdl_List.aspx?InsUpd=Save");
             }*/




        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ErrorMsg", "ErrorMsg();", true);
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;
            if (Request.QueryString["ShdlId"] != null)
            {
                clsCommonLibrary objCommon = new clsCommonLibrary();

                clsBusinessLayerJobShdl objBusinessLayerJobShdl = new clsBusinessLayerJobShdl();
                clsEntityLayerJobSchedule objEntityJobShdl = new clsEntityLayerJobSchedule();
                int intUserId = 0;
                if (hiddenCorporateId.Value == "")
                {
                    if (Session["CORPOFFICEID"] != null)
                    {
                        objEntityJobShdl.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
                    }
                    else if (Session["CORPOFFICEID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {

                    objEntityJobShdl.CorpOffice_Id = Convert.ToInt32(hiddenCorporateId.Value);
                }
                if (hiddenOrganisationId.Value == "")
                {
                    if (Session["ORGID"] != null)
                    {
                        objEntityJobShdl.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                    }
                    else if (Session["ORGID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {
                    objEntityJobShdl.Organisation_Id = Convert.ToInt32(hiddenOrganisationId.Value);
                }
                if (Session["USERID"] != null)
                {
                    intUserId = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }

                string strRandomMixedId = Request.QueryString["ShdlId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityJobShdl.JobSchdlId = Convert.ToInt32(strId);

                if (Request.QueryString["Id"] != null)
                {

                    string strRandomMixedEId = Request.QueryString["Id"].ToString();
                    string strLenghtofEId = strRandomMixedEId.Substring(0, 2);
                    int intLenghtofEId = Convert.ToInt16(strLenghtofEId);
                    string strEId = strRandomMixedEId.Substring(2, intLenghtofEId);
                    objEntityJobShdl.JobSchdlUserId = Convert.ToInt32(strEId);
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
                objEntityJobShdl.Fromdate = objCommon.textToDateTime(txtFromDate.Text);
                objEntityJobShdl.Todate = objCommon.textToDateTime(txtToDate.Text);


                objEntityJobShdl.User_Id = intUserId;
                objEntityJobShdl.D_Date = System.DateTime.Now;

                if (cbxMustDayWise.Checked)
                {
                    objEntityJobShdl.IsWeekWiseAvailable = 1;
                }
                else
                {
                    objEntityJobShdl.IsWeekWiseAvailable = 0;
                }





                List<clsEntityLayerJobScheduleDtl> objEntityWBDeatilsINSERTPeriodList = new List<clsEntityLayerJobScheduleDtl>();
                List<clsEntityLayerJobScheduleDtl> objEntityWBDeatilsUPDATEPeriodList = new List<clsEntityLayerJobScheduleDtl>();
                List<clsEntityLayerJobScheduleDtl> objEntityWBDeatilsINSERTDayList = new List<clsEntityLayerJobScheduleDtl>();
                List<clsEntityLayerJobScheduleDtl> objEntityWBDeatilsUPDATEDayList = new List<clsEntityLayerJobScheduleDtl>();
                List<clsEntityLayerJobSchdlWeekDayDtl> objEntityJobScheduleWeekDayDtlList = new List<clsEntityLayerJobSchdlWeekDayDtl>();
                string jsonDataPW = HiddenField1.Value;
                string R1PW = jsonDataPW.Replace("\"{", "\\{");
                string R2PW = R1PW.Replace("\\n", "\r\n");
                string R3PW = R2PW.Replace("\\", "");
                string R4PW = R3PW.Replace("}\"]", "}]");
                string R5PW = R4PW.Replace("}\",", "},");
                List<clsJSData> objWBDataPWList = new List<clsJSData>();
                //   UserData  data
                objWBDataPWList = JsonConvert.DeserializeObject<List<clsJSData>>(R5PW);


                foreach (clsJSData objclsJSData in objWBDataPWList)
                {
                    if (objclsJSData.EVTACTION == "INS")
                    {
                        clsEntityLayerJobScheduleDtl objEntityDetails = new clsEntityLayerJobScheduleDtl();

                        objEntityDetails.TimeSlotId = Convert.ToInt32(hiddenddlTimeSlotPWVal.Value);
                        objEntityDetails.SchdlWiseMode = 0;
                        string strFromDatetime = Convert.ToString("01-01-1000-" + objclsJSData.FROMTIME);
                        objEntityDetails.FromTime = objCommon.textWithTimeToDateTime(strFromDatetime);
                        string strToDatetime = Convert.ToString("01-01-1000-" + objclsJSData.TOTIME);
                        objEntityDetails.ToTime = objCommon.textWithTimeToDateTime(strToDatetime);
                        objEntityDetails.VhclId = Convert.ToInt32(objclsJSData.VHCLID);
                        objEntityDetails.PrjctId = Convert.ToInt32(objclsJSData.PRJCTID);
                        objEntityDetails.JobId = Convert.ToInt32(objclsJSData.JOBID);
                        objEntityDetails.JobName = objclsJSData.JOBNAME.Trim();
                        objEntityDetails.JobMode = Convert.ToInt32(objclsJSData.JOBMODE);

                        objEntityWBDeatilsINSERTPeriodList.Add(objEntityDetails);
                    }
                    else if (objclsJSData.EVTACTION == "UPD")
                    {
                        clsEntityLayerJobScheduleDtl objEntityDetails = new clsEntityLayerJobScheduleDtl();
                        objEntityDetails.JobSchdlDtlId = Convert.ToInt32(objclsJSData.DTLID);

                        objEntityDetails.TimeSlotId = Convert.ToInt32(hiddenddlTimeSlotPWVal.Value);
                        objEntityDetails.SchdlWiseMode = 0;
                        string strFromDatetime = Convert.ToString("01-01-1000-" + objclsJSData.FROMTIME);
                        objEntityDetails.FromTime = objCommon.textWithTimeToDateTime(strFromDatetime);
                        string strToDatetime = Convert.ToString("01-01-1000-" + objclsJSData.TOTIME);
                        objEntityDetails.ToTime = objCommon.textWithTimeToDateTime(strToDatetime);
                        objEntityDetails.VhclId = Convert.ToInt32(objclsJSData.VHCLID);
                        objEntityDetails.PrjctId = Convert.ToInt32(objclsJSData.PRJCTID);
                        objEntityDetails.JobId = Convert.ToInt32(objclsJSData.JOBID);
                        objEntityDetails.JobName = objclsJSData.JOBNAME.Trim();
                        objEntityDetails.JobMode = Convert.ToInt32(objclsJSData.JOBMODE);


                        objEntityWBDeatilsUPDATEPeriodList.Add(objEntityDetails);


                    }
                }

                if (objEntityJobShdl.IsWeekWiseAvailable != 0)
                {
                    string jsonDataDW = HiddenField2.Value;
                    string R1DW = jsonDataDW.Replace("\"{", "\\{");
                    string R2DW = R1DW.Replace("\\n", "\r\n");
                    string R3DW = R2DW.Replace("\\", "");
                    string R4DW = R3DW.Replace("}\"]", "}]");
                    string R5DW = R4DW.Replace("}\",", "},");
                    List<clsJSData> objWBDataDWList = new List<clsJSData>();
                    //   UserData  data
                    objWBDataDWList = JsonConvert.DeserializeObject<List<clsJSData>>(R5DW);


                    foreach (clsJSData objclsJSData in objWBDataDWList)
                    {
                        if (objclsJSData.EVTACTION == "INS")
                        {
                            clsEntityLayerJobScheduleDtl objEntityDetails = new clsEntityLayerJobScheduleDtl();

                            objEntityDetails.TimeSlotId = Convert.ToInt32(hiddenddlTimeSlotDWVal.Value);
                            objEntityDetails.SchdlWiseMode = 1;
                            string strFromDatetime = Convert.ToString("01-01-1000-" + objclsJSData.FROMTIME);
                            objEntityDetails.FromTime = objCommon.textWithTimeToDateTime(strFromDatetime);
                            string strToDatetime = Convert.ToString("01-01-1000-" + objclsJSData.TOTIME);
                            objEntityDetails.ToTime = objCommon.textWithTimeToDateTime(strToDatetime);
                            objEntityDetails.VhclId = Convert.ToInt32(objclsJSData.VHCLID);
                            objEntityDetails.PrjctId = Convert.ToInt32(objclsJSData.PRJCTID);
                            objEntityDetails.JobId = Convert.ToInt32(objclsJSData.JOBID);
                            objEntityDetails.JobName = objclsJSData.JOBNAME.Trim();
                            objEntityDetails.JobMode = Convert.ToInt32(objclsJSData.JOBMODE);

                            objEntityWBDeatilsINSERTDayList.Add(objEntityDetails);
                        }
                        else if (objclsJSData.EVTACTION == "UPD")
                        {
                            clsEntityLayerJobScheduleDtl objEntityDetails = new clsEntityLayerJobScheduleDtl();
                            objEntityDetails.JobSchdlDtlId = Convert.ToInt32(objclsJSData.DTLID);

                            objEntityDetails.TimeSlotId = Convert.ToInt32(hiddenddlTimeSlotDWVal.Value);
                            objEntityDetails.SchdlWiseMode = 1;
                            string strFromDatetime = Convert.ToString("01-01-1000-" + objclsJSData.FROMTIME);
                            objEntityDetails.FromTime = objCommon.textWithTimeToDateTime(strFromDatetime);
                            string strToDatetime = Convert.ToString("01-01-1000-" + objclsJSData.TOTIME);
                            objEntityDetails.ToTime = objCommon.textWithTimeToDateTime(strToDatetime);
                            objEntityDetails.VhclId = Convert.ToInt32(objclsJSData.VHCLID);
                            objEntityDetails.PrjctId = Convert.ToInt32(objclsJSData.PRJCTID);
                            objEntityDetails.JobId = Convert.ToInt32(objclsJSData.JOBID);
                            objEntityDetails.JobName = objclsJSData.JOBNAME.Trim();
                            objEntityDetails.JobMode = Convert.ToInt32(objclsJSData.JOBMODE);


                            objEntityWBDeatilsUPDATEDayList.Add(objEntityDetails);


                        }
                    }


                    if (hiddenWeekDayId.Value != "")
                    {

                        string strWeekList = hiddenWeekDayId.Value;
                        // Split string on spaces.
                        // ... This will separate all the words.
                        string[] strArrWeekDays = strWeekList.Split(',');
                        foreach (string strWeekDayId in strArrWeekDays)
                        {
                            if (strWeekDayId != "")
                            {
                                clsEntityLayerJobSchdlWeekDayDtl objEntityJobSchdlWeekDayDtl = new clsEntityLayerJobSchdlWeekDayDtl();
                                objEntityJobSchdlWeekDayDtl.WeekDaysId = Convert.ToInt32(strWeekDayId);
                                objEntityJobScheduleWeekDayDtlList.Add(objEntityJobSchdlWeekDayDtl);
                            }
                        }

                    }

                }

                string strCanclDtlId = "";
                string[] strarrCancldtlIds = strCanclDtlId.Split(',');
                if (hiddenCanclDtlId.Value != "" && hiddenCanclDtlId.Value != null)
                {
                    strCanclDtlId = hiddenCanclDtlId.Value;
                    strarrCancldtlIds = strCanclDtlId.Split(',');

                }

                objBusinessLayerJobShdl.Update_JobScheduling(objEntityJobShdl, objEntityWBDeatilsINSERTPeriodList, objEntityWBDeatilsUPDATEPeriodList, objEntityWBDeatilsINSERTDayList, objEntityWBDeatilsUPDATEDayList, objEntityJobScheduleWeekDayDtlList, strarrCancldtlIds);


                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("flt_Job_Shdl_List.aspx?InsUpd=Upd");
                }
                /*  else if (clickedButton.ID == "btnUpdateClose")
                  {
                      Response.Redirect("flt_Job_Shdl_List.aspx?InsUpd=Upd");
                  }*/

            }
            else
            {

                Response.Redirect("~/Default.aspx");

            }
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ErrorMsg", "ErrorMsg();", true);
        }
    }



    public class TimeSlotDtls
    {
        public string strStartTime = "";
        public string strEndTime = "";


    }
    // this web method is for fetching data based on the card selected 
    [WebMethod]
    public static TimeSlotDtls TimeSlotDetails(string corporateId, string organisationId, string SLOTID)
    {

        TimeSlotDtls objTimeSlotDtls = new TimeSlotDtls();     // CREATE AN OBJECT.

        //Creating objects for business layer
        clsBusinessLayerJobShdl objBusinessLayerJobShdl = new clsBusinessLayerJobShdl();
        clsEntityLayerJobSchedule objEntityJobShdl = new clsEntityLayerJobSchedule();


        if (corporateId != null && corporateId != "" && corporateId != "undefined" && organisationId != null && organisationId != "" && organisationId != "undefined" && SLOTID != null && SLOTID != "" && SLOTID != "undefined")
        {
            objEntityJobShdl.CorpOffice_Id = Convert.ToInt32(corporateId);
            objEntityJobShdl.Organisation_Id = Convert.ToInt32(organisationId);
            objEntityJobShdl.TimeSlotId = Convert.ToInt32(SLOTID);
        }

        DataTable dtTimeSlotDtl = new DataTable();

        dtTimeSlotDtl = objBusinessLayerJobShdl.ReadTimeSlotById(objEntityJobShdl);
        if (dtTimeSlotDtl.Rows.Count > 0)
        {
            objTimeSlotDtls.strStartTime = dtTimeSlotDtl.Rows[0]["TMSLT_START_TIME"].ToString();
            objTimeSlotDtls.strEndTime = dtTimeSlotDtl.Rows[0]["TMSLT_END_TIME"].ToString();

        }
        return objTimeSlotDtls;
    }


    //start-0009

    // this web method is for fetching data based on the card selected 
    [WebMethod]
    public static string FromToDateDetails(string corporateId, string organisationId, string EmpID, string FromDate, string ToDate, string JobShdlID)
    {


        //Creating objects for business layer
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerJobShdl objBusinessLayerJobShdl = new clsBusinessLayerJobShdl();
        clsEntityLayerJobSchedule objEntityJobShdl = new clsEntityLayerJobSchedule();
        string strReturn = "true";
        DateTime FromDateTime = objCommon.textToDateTime(FromDate);
        DateTime ToDateTime = objCommon.textToDateTime(ToDate);
        if (corporateId != null && corporateId != "" && corporateId != "undefined" && organisationId != null && organisationId != "" && organisationId != "undefined")
        {
            objEntityJobShdl.CorpOffice_Id = Convert.ToInt32(corporateId);
            objEntityJobShdl.Organisation_Id = Convert.ToInt32(organisationId);
            objEntityJobShdl.JobSchdlUserId = Convert.ToInt32(EmpID); ;
            objEntityJobShdl.JobSchdlId = Convert.ToInt32(JobShdlID);
        }

        DataTable dtDateDtl = new DataTable();

        dtDateDtl = objBusinessLayerJobShdl.ReadFromToDateByUsrId(objEntityJobShdl);
        if (dtDateDtl.Rows.Count > 0)
        {
            for (int i = 0; i < dtDateDtl.Rows.Count; i++)
            {
                DateTime strFromDate = objCommon.textToDateTime(dtDateDtl.Rows[i]["JOBSHDL_FROM_DATE"].ToString());
                DateTime strToDate = objCommon.textToDateTime(dtDateDtl.Rows[i]["JOBSHDL_TO_DATE"].ToString());
                // Range covers other ?
                if ((strFromDate <= FromDateTime) && (ToDateTime <= strToDate))
                {
                    strReturn = "false";
                }
                // Range intersects with other start ?
                if ((strFromDate <= FromDateTime) && (FromDateTime <= strToDate))
                {
                    strReturn = "false";
                }
                // Range intersects with other end ?
                if ((strFromDate <= ToDateTime) && (ToDateTime <= strToDate))
                {
                    strReturn = "false";
                }

                // All good

            }
        }
        return strReturn;
    }
    //stop-0009


    //for sorting drop down
    private void SortDDL(ref DropDownList objDDL)
    {
        ArrayList textList = new ArrayList();
        ArrayList valueList = new ArrayList();


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
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;
            if (Request.QueryString["ShdlId"] != null)
            {
                clsCommonLibrary objCommon = new clsCommonLibrary();

                clsBusinessLayerJobShdl objBusinessLayerJobShdl = new clsBusinessLayerJobShdl();
                clsEntityLayerJobSchedule objEntityJobShdl = new clsEntityLayerJobSchedule();
                int intUserId = 0;
                if (hiddenCorporateId.Value == "")
                {
                    if (Session["CORPOFFICEID"] != null)
                    {
                        objEntityJobShdl.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
                    }
                    else if (Session["CORPOFFICEID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {

                    objEntityJobShdl.CorpOffice_Id = Convert.ToInt32(hiddenCorporateId.Value);
                }
                if (hiddenOrganisationId.Value == "")
                {
                    if (Session["ORGID"] != null)
                    {
                        objEntityJobShdl.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                    }
                    else if (Session["ORGID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {
                    objEntityJobShdl.Organisation_Id = Convert.ToInt32(hiddenOrganisationId.Value);
                }
                if (Session["USERID"] != null)
                {
                    intUserId = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }

                string strRandomMixedId = Request.QueryString["ShdlId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityJobShdl.JobSchdlId = Convert.ToInt32(strId);

                if (Request.QueryString["Id"] != null)
                {

                    string strRandomMixedEId = Request.QueryString["Id"].ToString();
                    string strLenghtofEId = strRandomMixedEId.Substring(0, 2);
                    int intLenghtofEId = Convert.ToInt16(strLenghtofEId);
                    string strEId = strRandomMixedEId.Substring(2, intLenghtofEId);
                    objEntityJobShdl.JobSchdlUserId = Convert.ToInt32(strEId);
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
                objEntityJobShdl.Fromdate = objCommon.textToDateTime(txtFromDate.Text);
                objEntityJobShdl.Todate = objCommon.textToDateTime(txtToDate.Text);


                objEntityJobShdl.User_Id = intUserId;
                objEntityJobShdl.D_Date = System.DateTime.Now;

                if (cbxMustDayWise.Checked)
                {
                    objEntityJobShdl.IsWeekWiseAvailable = 1;
                }
                else
                {
                    objEntityJobShdl.IsWeekWiseAvailable = 0;
                }





                List<clsEntityLayerJobScheduleDtl> objEntityWBDeatilsINSERTPeriodList = new List<clsEntityLayerJobScheduleDtl>();
                List<clsEntityLayerJobScheduleDtl> objEntityWBDeatilsUPDATEPeriodList = new List<clsEntityLayerJobScheduleDtl>();
                List<clsEntityLayerJobScheduleDtl> objEntityWBDeatilsINSERTDayList = new List<clsEntityLayerJobScheduleDtl>();
                List<clsEntityLayerJobScheduleDtl> objEntityWBDeatilsUPDATEDayList = new List<clsEntityLayerJobScheduleDtl>();
                List<clsEntityLayerJobSchdlWeekDayDtl> objEntityJobScheduleWeekDayDtlList = new List<clsEntityLayerJobSchdlWeekDayDtl>();
                string jsonDataPW = HiddenField1.Value;
                string R1PW = jsonDataPW.Replace("\"{", "\\{");
                string R2PW = R1PW.Replace("\\n", "\r\n");
                string R3PW = R2PW.Replace("\\", "");
                string R4PW = R3PW.Replace("}\"]", "}]");
                string R5PW = R4PW.Replace("}\",", "},");
                List<clsJSData> objWBDataPWList = new List<clsJSData>();
                //   UserData  data
                objWBDataPWList = JsonConvert.DeserializeObject<List<clsJSData>>(R5PW);


                foreach (clsJSData objclsJSData in objWBDataPWList)
                {
                    if (objclsJSData.EVTACTION == "INS")
                    {
                        clsEntityLayerJobScheduleDtl objEntityDetails = new clsEntityLayerJobScheduleDtl();

                        objEntityDetails.TimeSlotId = Convert.ToInt32(hiddenddlTimeSlotPWVal.Value);
                        objEntityDetails.SchdlWiseMode = 0;
                        string strFromDatetime = Convert.ToString("01-01-1000-" + objclsJSData.FROMTIME);
                        objEntityDetails.FromTime = objCommon.textWithTimeToDateTime(strFromDatetime);
                        string strToDatetime = Convert.ToString("01-01-1000-" + objclsJSData.TOTIME);
                        objEntityDetails.ToTime = objCommon.textWithTimeToDateTime(strToDatetime);
                        objEntityDetails.VhclId = Convert.ToInt32(objclsJSData.VHCLID);
                        objEntityDetails.PrjctId = Convert.ToInt32(objclsJSData.PRJCTID);
                        objEntityDetails.JobId = Convert.ToInt32(objclsJSData.JOBID);
                        objEntityDetails.JobName = objclsJSData.JOBNAME.Trim();
                        objEntityDetails.JobMode = Convert.ToInt32(objclsJSData.JOBMODE);

                        objEntityWBDeatilsINSERTPeriodList.Add(objEntityDetails);
                    }
                    else if (objclsJSData.EVTACTION == "UPD")
                    {
                        clsEntityLayerJobScheduleDtl objEntityDetails = new clsEntityLayerJobScheduleDtl();
                        objEntityDetails.JobSchdlDtlId = Convert.ToInt32(objclsJSData.DTLID);

                        objEntityDetails.TimeSlotId = Convert.ToInt32(hiddenddlTimeSlotPWVal.Value);
                        objEntityDetails.SchdlWiseMode = 0;
                        string strFromDatetime = Convert.ToString("01-01-1000-" + objclsJSData.FROMTIME);
                        objEntityDetails.FromTime = objCommon.textWithTimeToDateTime(strFromDatetime);
                        string strToDatetime = Convert.ToString("01-01-1000-" + objclsJSData.TOTIME);
                        objEntityDetails.ToTime = objCommon.textWithTimeToDateTime(strToDatetime);
                        objEntityDetails.VhclId = Convert.ToInt32(objclsJSData.VHCLID);
                        objEntityDetails.PrjctId = Convert.ToInt32(objclsJSData.PRJCTID);
                        objEntityDetails.JobId = Convert.ToInt32(objclsJSData.JOBID);
                        objEntityDetails.JobName = objclsJSData.JOBNAME.Trim();
                        objEntityDetails.JobMode = Convert.ToInt32(objclsJSData.JOBMODE);


                        objEntityWBDeatilsUPDATEPeriodList.Add(objEntityDetails);


                    }
                }

                if (objEntityJobShdl.IsWeekWiseAvailable != 0)
                {
                    string jsonDataDW = HiddenField2.Value;
                    string R1DW = jsonDataDW.Replace("\"{", "\\{");
                    string R2DW = R1DW.Replace("\\n", "\r\n");
                    string R3DW = R2DW.Replace("\\", "");
                    string R4DW = R3DW.Replace("}\"]", "}]");
                    string R5DW = R4DW.Replace("}\",", "},");
                    List<clsJSData> objWBDataDWList = new List<clsJSData>();
                    //   UserData  data
                    objWBDataDWList = JsonConvert.DeserializeObject<List<clsJSData>>(R5DW);


                    foreach (clsJSData objclsJSData in objWBDataDWList)
                    {
                        if (objclsJSData.EVTACTION == "INS")
                        {
                            clsEntityLayerJobScheduleDtl objEntityDetails = new clsEntityLayerJobScheduleDtl();

                            objEntityDetails.TimeSlotId = Convert.ToInt32(hiddenddlTimeSlotDWVal.Value);
                            objEntityDetails.SchdlWiseMode = 1;
                            string strFromDatetime = Convert.ToString("01-01-1000-" + objclsJSData.FROMTIME);
                            objEntityDetails.FromTime = objCommon.textWithTimeToDateTime(strFromDatetime);
                            string strToDatetime = Convert.ToString("01-01-1000-" + objclsJSData.TOTIME);
                            objEntityDetails.ToTime = objCommon.textWithTimeToDateTime(strToDatetime);
                            objEntityDetails.VhclId = Convert.ToInt32(objclsJSData.VHCLID);
                            objEntityDetails.PrjctId = Convert.ToInt32(objclsJSData.PRJCTID);
                            objEntityDetails.JobId = Convert.ToInt32(objclsJSData.JOBID);
                            objEntityDetails.JobName = objclsJSData.JOBNAME.Trim();
                            objEntityDetails.JobMode = Convert.ToInt32(objclsJSData.JOBMODE);

                            objEntityWBDeatilsINSERTDayList.Add(objEntityDetails);
                        }
                        else if (objclsJSData.EVTACTION == "UPD")
                        {
                            clsEntityLayerJobScheduleDtl objEntityDetails = new clsEntityLayerJobScheduleDtl();
                            objEntityDetails.JobSchdlDtlId = Convert.ToInt32(objclsJSData.DTLID);

                            objEntityDetails.TimeSlotId = Convert.ToInt32(hiddenddlTimeSlotDWVal.Value);
                            objEntityDetails.SchdlWiseMode = 1;
                            string strFromDatetime = Convert.ToString("01-01-1000-" + objclsJSData.FROMTIME);
                            objEntityDetails.FromTime = objCommon.textWithTimeToDateTime(strFromDatetime);
                            string strToDatetime = Convert.ToString("01-01-1000-" + objclsJSData.TOTIME);
                            objEntityDetails.ToTime = objCommon.textWithTimeToDateTime(strToDatetime);
                            objEntityDetails.VhclId = Convert.ToInt32(objclsJSData.VHCLID);
                            objEntityDetails.PrjctId = Convert.ToInt32(objclsJSData.PRJCTID);
                            objEntityDetails.JobId = Convert.ToInt32(objclsJSData.JOBID);
                            objEntityDetails.JobName = objclsJSData.JOBNAME.Trim();
                            objEntityDetails.JobMode = Convert.ToInt32(objclsJSData.JOBMODE);


                            objEntityWBDeatilsUPDATEDayList.Add(objEntityDetails);


                        }
                    }


                    if (hiddenWeekDayId.Value != "")
                    {

                        string strWeekList = hiddenWeekDayId.Value;
                        // Split string on spaces.
                        // ... This will separate all the words.
                        string[] strArrWeekDays = strWeekList.Split(',');
                        foreach (string strWeekDayId in strArrWeekDays)
                        {
                            if (strWeekDayId != "")
                            {
                                clsEntityLayerJobSchdlWeekDayDtl objEntityJobSchdlWeekDayDtl = new clsEntityLayerJobSchdlWeekDayDtl();
                                objEntityJobSchdlWeekDayDtl.WeekDaysId = Convert.ToInt32(strWeekDayId);
                                objEntityJobScheduleWeekDayDtlList.Add(objEntityJobSchdlWeekDayDtl);
                            }
                        }

                    }

                }

                string strCanclDtlId = "";
                string[] strarrCancldtlIds = strCanclDtlId.Split(',');
                if (hiddenCanclDtlId.Value != "" && hiddenCanclDtlId.Value != null)
                {
                    strCanclDtlId = hiddenCanclDtlId.Value;
                    strarrCancldtlIds = strCanclDtlId.Split(',');

                }
                //confirm
                objEntityJobShdl.ToConfirm = 1;
                objBusinessLayerJobShdl.Update_JobScheduling(objEntityJobShdl, objEntityWBDeatilsINSERTPeriodList, objEntityWBDeatilsUPDATEPeriodList, objEntityWBDeatilsINSERTDayList, objEntityWBDeatilsUPDATEDayList, objEntityJobScheduleWeekDayDtlList, strarrCancldtlIds);
                Response.Redirect("flt_Job_Shdl_List.aspx?InsUpd=Confirm");

            }
            else
            {

                Response.Redirect("~/Default.aspx");

            }
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ErrorMsg", "ErrorMsg();", true);
        }
    }
    protected void btnReopen_Click(object sender, EventArgs e)
    {

        if (Request.QueryString["ShdlId"] != null)
        {

            clsBusinessLayerJobShdl objBusinessLayerJobShdl = new clsBusinessLayerJobShdl();
            clsEntityLayerJobSchedule objEntityJobShdl = new clsEntityLayerJobSchedule();
            int intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            string strRandomMixedId = Request.QueryString["ShdlId"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityJobShdl.JobSchdlId = Convert.ToInt32(strId);


            objEntityJobShdl.User_Id = intUserId;
            objEntityJobShdl.D_Date = System.DateTime.Now;
            objBusinessLayerJobShdl.JobScheduleConfirmRecl(objEntityJobShdl);
            Response.Redirect("flt_Job_Shdl_List.aspx?InsUpd=Reopen");
        }
    }
    [WebMethod]
    public static string VhclCheck(string Fromdate, string Todate, string FromTime, string ToTime, int VhclId, string edit)
    {
        string sts = "true";
        clsBusinessLayerJobShdl objBusinessLayerJobShdl = new clsBusinessLayerJobShdl();
        clsEntityLayerJobSchedule objEntityJobShdl = new clsEntityLayerJobSchedule();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityJobShdl.VehicleID = VhclId;
        objEntityJobShdl.Fromdate = objCommon.textToDateTime(Fromdate);
        objEntityJobShdl.Todate = objCommon.textToDateTime(Todate);



        clsEntityLayerJobScheduleDtl objEntityDetails = new clsEntityLayerJobScheduleDtl();
        string strFromDatetime = Convert.ToString("01-01-1000-" + FromTime);
        objEntityDetails.FromTime = objCommon.textWithTimeToDateTime(strFromDatetime);
        string strToDatetime = Convert.ToString("01-01-1000-" + ToTime);
        objEntityDetails.ToTime = objCommon.textWithTimeToDateTime(strToDatetime);
        if (edit != "")
        {
            objEntityJobShdl.JobSchdlId = Convert.ToInt32(edit);
        }

        DataTable dtCheck = new DataTable();


        DataTable dt = objBusinessLayerJobShdl.readVhclScdldDtls(objEntityJobShdl);
        foreach (DataRow RowVhcl in dt.Rows)
        {
            objEntityJobShdl.JobSchdlId = Convert.ToInt32(RowVhcl["JOBSHDL_ID"].ToString());
            dtCheck = objBusinessLayerJobShdl.readDays(objEntityJobShdl);


            if (dtCheck.Rows.Count == 0)
            {
                clsEntityLayerJobScheduleDtl objEntityDetails1 = new clsEntityLayerJobScheduleDtl();
                string strFromDatetime1 = Convert.ToString("01-01-1000-" + RowVhcl["JOBSHDLDTL_FROM_TIME"].ToString());
                objEntityDetails1.FromTime = objCommon.textWithTimeToDateTime(strFromDatetime1);
                string strToDatetime1 = Convert.ToString("01-01-1000-" + RowVhcl["JOBSHDLDTL_TO_TIME"].ToString());
                objEntityDetails1.ToTime = objCommon.textWithTimeToDateTime(strToDatetime1);


                if (objEntityDetails1.FromTime > objEntityDetails.FromTime && objEntityDetails1.FromTime < objEntityDetails.ToTime
                    ||
                    objEntityDetails.FromTime > objEntityDetails1.FromTime && objEntityDetails.FromTime < objEntityDetails1.ToTime
                    ||
                     objEntityDetails1.FromTime == objEntityDetails.FromTime
                    )
                {
                    sts = "false";
                    break;
                }

            }
        }





        if (dtCheck.Rows.Count > 0)
        {

            DataTable dts = objBusinessLayerJobShdl.readVhclScdldDtlsScdlID(objEntityJobShdl);
            foreach (DataRow RowVhcl in dts.Rows)
            {




                objEntityJobShdl.JobSchdlId = Convert.ToInt32(RowVhcl["JOBSHDL_ID"].ToString());
                DataTable dtCheckss = objBusinessLayerJobShdl.readDays(objEntityJobShdl);

                foreach (DataRow days in dtCheckss.Rows)
                {
                    DayOfWeek strJbWklyOffDay = DayOfWeek.Sunday;
                    string DutyOfwk = days["WEEK_DAYS_ID"].ToString();
                    switch (DutyOfwk)
                    {

                        case "0":
                            strJbWklyOffDay = DayOfWeek.Sunday;
                            break;
                        case "1":
                            strJbWklyOffDay = DayOfWeek.Monday;
                            break;
                        case "2":
                            strJbWklyOffDay = DayOfWeek.Tuesday;
                            break;
                        case "3":
                            strJbWklyOffDay = DayOfWeek.Wednesday;
                            break;
                        case "4":
                            strJbWklyOffDay = DayOfWeek.Thursday;
                            break;
                        case "5":
                            strJbWklyOffDay = DayOfWeek.Friday;
                            break;
                        case "6":
                            strJbWklyOffDay = DayOfWeek.Saturday;
                            break;

                    }

                    DateTime startdate = new DateTime();
                    startdate = objEntityJobShdl.Fromdate;

                    DateTime enddate = new DateTime();
                    enddate = objEntityJobShdl.Todate;
                    do
                    {

                        DataTable dtn = objBusinessLayerJobShdl.readVhclScdldDtls(objEntityJobShdl);
                        foreach (DataRow RowVhclss in dtn.Rows)
                        {
                            if (RowVhclss["JOBSHDL_ID"].ToString() == RowVhcl["JOBSHDL_ID"].ToString())
                            {

                                if (startdate.DayOfWeek == strJbWklyOffDay)
                                {

                                    if (RowVhclss["SHDLWISE_MODE"].ToString() == "1")
                                    {


                                        objEntityJobShdl.Fromdate = startdate;
                                        objEntityJobShdl.Todate = startdate;

                                        clsEntityLayerJobScheduleDtl objEntityDetails1 = new clsEntityLayerJobScheduleDtl();
                                        string strFromDatetime1 = Convert.ToString("01-01-1000-" + RowVhclss["JOBSHDLDTL_FROM_TIME"].ToString());
                                        objEntityDetails1.FromTime = objCommon.textWithTimeToDateTime(strFromDatetime1);
                                        string strToDatetime1 = Convert.ToString("01-01-1000-" + RowVhclss["JOBSHDLDTL_TO_TIME"].ToString());
                                        objEntityDetails1.ToTime = objCommon.textWithTimeToDateTime(strToDatetime1);


                                        if (objEntityDetails1.FromTime > objEntityDetails.FromTime && objEntityDetails1.FromTime < objEntityDetails.ToTime
                                            ||
                                            objEntityDetails.FromTime > objEntityDetails1.FromTime && objEntityDetails.FromTime < objEntityDetails1.ToTime

                                            ||
                                            objEntityDetails1.FromTime == objEntityDetails.FromTime
                                            )
                                        {
                                            sts = "false";
                                            break;
                                        }

                                    }

                                }
                                else
                                {
                                    if (RowVhclss["SHDLWISE_MODE"].ToString() == "0")
                                    {
                                        objEntityJobShdl.Fromdate = startdate;
                                        objEntityJobShdl.Todate = startdate;



                                        clsEntityLayerJobScheduleDtl objEntityDetails1 = new clsEntityLayerJobScheduleDtl();
                                        string strFromDatetime1 = Convert.ToString("01-01-1000-" + RowVhclss["JOBSHDLDTL_FROM_TIME"].ToString());
                                        objEntityDetails1.FromTime = objCommon.textWithTimeToDateTime(strFromDatetime1);
                                        string strToDatetime1 = Convert.ToString("01-01-1000-" + RowVhclss["JOBSHDLDTL_TO_TIME"].ToString());
                                        objEntityDetails1.ToTime = objCommon.textWithTimeToDateTime(strToDatetime1);


                                        if (objEntityDetails1.FromTime > objEntityDetails.FromTime && objEntityDetails1.FromTime < objEntityDetails.ToTime
                                            ||
                                            objEntityDetails.FromTime > objEntityDetails1.FromTime && objEntityDetails.FromTime < objEntityDetails1.ToTime

                                            ||
                                            objEntityDetails1.FromTime == objEntityDetails.FromTime
                                            )
                                        {
                                            sts = "false";
                                            break;
                                        }


                                    }

                                }






                            }
                        }





                        startdate = startdate.AddDays(1);
                    } while (startdate <= enddate);


                }
            }


        }




        return sts;
    }

    [WebMethod]
    public static string prjctReadByVhcl(string FromDate, string ToDate, int VhclId, int CorpId, int OrgId)
    {
        string PrjctId = "";
    
        clsBusinessLayerJobShdl objBusinessLayerJobShdl = new clsBusinessLayerJobShdl();
        clsEntityLayerJobSchedule objEntityJobShdl = new clsEntityLayerJobSchedule();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityJobShdl.VehicleID = VhclId;
        if (FromDate!="")
        objEntityJobShdl.Fromdate = objCommon.textToDateTime(FromDate);
        if (ToDate!="")
        objEntityJobShdl.Todate = objCommon.textToDateTime(ToDate);
        objEntityJobShdl.CorpOffice_Id = CorpId;
        objEntityJobShdl.Organisation_Id = OrgId;
        DataTable dt = objBusinessLayerJobShdl.ReadPrjctByVhcl(objEntityJobShdl);
        foreach (DataRow RowVhcl in dt.Rows)
        {
            clsEntityLayerJobSchedule objEntityJobShdl1 = new clsEntityLayerJobSchedule();
            if (RowVhcl["TO_DATE"].ToString() == "")
            {
                objEntityJobShdl1.Fromdate = objCommon.textToDateTime(RowVhcl["FROM_DATE"].ToString());
                if (objEntityJobShdl.Fromdate <= objEntityJobShdl1.Fromdate)
                {
                    PrjctId = RowVhcl["ASSAIGNED_TO_PRJCT_ID"].ToString() + "," + RowVhcl["PROJECT_NAME"].ToString();
                    break;
                }
            }
            else
            {
                objEntityJobShdl1.Fromdate = objCommon.textToDateTime(RowVhcl["FROM_DATE"].ToString());
                objEntityJobShdl1.Todate = objCommon.textToDateTime(RowVhcl["TO_DATE"].ToString());
                if (objEntityJobShdl.Fromdate >= objEntityJobShdl1.Fromdate && objEntityJobShdl.Todate <= objEntityJobShdl1.Todate)
                {
                    PrjctId = RowVhcl["ASSAIGNED_TO_PRJCT_ID"].ToString() + "," + RowVhcl["PROJECT_NAME"].ToString();
                    break;
                }
            }
        }

        return PrjctId;

    }
}