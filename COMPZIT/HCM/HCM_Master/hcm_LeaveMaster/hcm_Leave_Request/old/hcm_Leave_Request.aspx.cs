using BL_Compzit.BusinessLayer_GMS;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CL_Compzit;
using BL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_AWMS;
using System.Web.Services;
using BL_Compzit.BusinessLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using System.Xml;
using System.Web.Script.Serialization;
using System.Globalization;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public partial class HCM_HCM_Master_hcm_OnBoarding_hcm_Leave_Management_hcm_Leave_Request : System.Web.UI.Page
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
        txtDateFrom.Attributes.Add("onkeypress", "return isTag(event)");
        TextDateTo.Attributes.Add("onkeypress", "return isTag(event)");
        txtDateTrvl.Attributes.Add("onkeypress", "return isTag(event)");
        txtDateRetrn.Attributes.Add("onkeypress", "return isTag(event)");
        txtDestntn.Attributes.Add("onkeypress", "return isTag(event)");
        txtAirLine.Attributes.Add("onkeypress", "return isTag(event)");
        txtTelNo.Attributes.Add("onkeypress", "return isTag(event)");
        txtLclCntctNo.Attributes.Add("onkeypress", "return isTag(event)");
        txtEmail.Attributes.Add("onkeypress", "return isTag(event)");
        txtTelNo.Attributes.Add("onkeypress", "return isNumber(event)");


        txtDateTrvl.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtDateRetrn.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtDestntn.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtAirLine.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtTelNo.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtLclCntctNo.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtEmail.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtAddrss.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtCmnt.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxNeedTckt.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        ddlLeavTyp.Items.Insert(0, "--SELECT LEAVE TYPE--");
        cbxStatus.Focus();
        if (!IsPostBack)
        {
            HiddenView.Value = "";
            hiddenRoleAdd.Value = "0";
            hiddenRoleReOpen.Value = "0";
            hiddenRoleConfirm.Value = "0";
            hiddenfunReturn.Value = "0";
            hiddenstrid.Value = "0";
            hiddenHolidaychck.Value = "0";
            btnConfirm.Visible = false;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
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
                intUserId = Convert.ToInt32(Session["USERID"].ToString());
            hiddenEmployeeId.Value = Session["USERID"].ToString();
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Leave_Request);

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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        HiddenFieldCancelUsrRole.Value = "1";

                    }

                }

            }



            //0041

            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  
                                                                        clsCommonLibrary.CORP_GLOBAL.OFFDUTYDAYS_STATUS,                                       
                                                             clsCommonLibrary.CORP_GLOBAL.LEVSTRTDT_OFFDUTYSTS,
                                                                clsCommonLibrary.CORP_GLOBAL.LEVSTRTDT_HOLIDAYSTS,
                                                                clsCommonLibrary.CORP_GLOBAL.LEVEND_OFFDUTYSTS,
                                                                clsCommonLibrary.CORP_GLOBAL.LEVEND_HOLIDAYSTS,
                                                             
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, Convert.ToInt32(HiddenFieldCorp.Value));
            if (dtCorpDetail.Rows.Count > 0)
            {

            HiddenOFfdaysSts.Value = dtCorpDetail.Rows[0]["OFFDUTYDAYS_STATUS"].ToString();
              //   HiddenOFfdaysSts.Value = "0";

            HiddenLevstrtdtholidaysts.Value = dtCorpDetail.Rows[0]["LEVSTRTDT_HOLIDAYSTS"].ToString();

            HiddenLevenddtholidaysts.Value = dtCorpDetail.Rows[0]["LEVEND_HOLIDAYSTS"].ToString();
            HiddenLevstrtdtoffdaysts.Value = dtCorpDetail.Rows[0]["LEVSTRTDT_OFFDUTYSTS"].ToString();

            HiddenLevenddtoffdaysts.Value = dtCorpDetail.Rows[0]["LEVEND_OFFDUTYSTS"].ToString();
           

            }
          
//end

             clsBusinessLeaveRequest objBusinessLeaveRequest = new clsBusinessLeaveRequest();
             clsEntityLeaveRequest objEntityLeaveRequest = new clsEntityLeaveRequest();
             objEntityLeaveRequest.User_Id = Convert.ToInt32(hiddenEmployeeId.Value);  
           
            //start:-For check login user is staff or worker
             DataTable  dtEmpType = objBusinessLeaveRequest.CheckEmpType(objEntityLeaveRequest);
             HiddenFieldEmpType.Value=dtEmpType.Rows[0][0].ToString();

           //End:-For check login user is staff or worker

            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                if (Request.QueryString["Sts"] != null)
                {
                    HiddenFieldExpiredSts.Value = "Exp"; 
                }

                string strRandomMixedId = Request.QueryString["Id"].ToString();
                HiddenFieldQryString.Value = strRandomMixedId;
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                Update(strId);
                lblEntry.Text = "Edit Leave Request";

              

            }

            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId);

                lblEntry.Text = "View Leave Request";
            }

            else
            {
                lblEntry.Text = "Add Leave Request";
                //if (hiddenRoleAdd.Value != "")
                //{
                //    if (hiddenRoleAdd.Value == "1")
                //    {
                //        btnAdd.Visible = true;
                //        btnAddClose.Visible = true;
                //    }
                //    else
                //    {
                //        btnCancel.Visible = true;
                //        btnAdd.Visible = false;
                //        btnAddClose.Visible = false;
                //    }
                //}

                DataTable dtCity = new DataTable();
                dtCity = objBusinessLeaveRequest.ReadCity(objEntityLeaveRequest);
                if (dtCity.Rows.Count > 0)
                {
                    txtDestntn.Text = dtCity.Rows[0][0].ToString();
                }

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;

               
            }
            if (Request.QueryString["RFGP"] != null)
            {
                HiddenView.Value = "1";
                btnCancel.Visible = false;
                divList.Visible = false;
                //vv
                imgAirptClose.Visible = false;
                imgCaption.Visible = false;
                
                ddlLeavTyp.Enabled = false;
                txtDateFrom.Enabled = false;
                ddlSecnFrom.Enabled = false;
                cbxStatus.Enabled = false;
                TextDateTo.Enabled = false;
                ddlSecTo.Enabled = false;
                img1.Disabled = true;
                imgDate.Disabled = true;
                //For travel details
                //EVM-0027 08-02-2019
                cbxSettlement.Disabled = true;
                //ENd
                txtDateTrvl.Enabled = false;
                Image1.Disabled = true;
                txtDestntn.Enabled = false;
                txtDateRetrn.Enabled = false;
                Image2.Disabled = true;
                txtAirLine.Enabled = false;
                txtAddrss.Enabled = false;
                txtTelNo.Enabled = false;
                txtLclCntctNo.Enabled = false;
                txtEmail.Enabled = false;
                txtCmnt.Enabled = false;
                cbxNeedTckt.Enabled = false;
                txtLvDesc.Enabled = false;
                btnConfirm.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnClear.Visible = false;
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                cbxTrvlSts.Enabled = false;
                btnClearanceLink.Visible = false;   //emp25
            }
            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                }

                //if (strInsUpd == "NO_ReportOffcr")
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "CheckReportingOfficer", "CheckReportingOfficer();", true);
                //}


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
                else if (strInsUpd == "InsStf")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessAddStaff", "SuccessAddStaff();", true);
                }
                else if (strInsUpd == "UpdStf")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdStaff", "SuccessUpdStaff();", true);
                }

            }
            //Start:-For loading Family details table
            DataTable dtContract = new DataTable();
            dtContract = objBusinessLeaveRequest.ReadFmlyDtls(objEntityLeaveRequest);
            string strHtm = ConvertDataTableToHTML(dtContract);
            divFamlyDtls.InnerHtml = strHtm;
            //End:-For loading Family details table

            // created object for business layer for compare the date

            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
            hiddenCurrentDate.Value = strCurrentDate;
            dtCurrDate = objCommon.textToDateTime(strCurrentDate);
        }
    }
    //protected void LeavTypLoad()
    //{
    //    clsBusinessLeaveRequest objBusinessLeaveRequest = new clsBusinessLeaveRequest();
    //    clsEntityLeaveRequest objEntityLeaveRequest = new clsEntityLeaveRequest();
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    int intUserId;
    //    if (Session["CORPOFFICEID"] != null)
    //    {
    //        objEntityLeaveRequest.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
    //    }
    //    else
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }
    //    if (Session["ORGID"] != null)
    //    {
    //        objEntityLeaveRequest.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

    //    }
    //    else
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }
    //    if (Session["USERID"] != null)
    //    {
    //        objEntityLeaveRequest.User_Id = Convert.ToInt32(Session["USERID"].ToString());

    //        intUserId = Convert.ToInt32(Session["USERID"].ToString());
    //    }
    //    else
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }

    //    DataTable DtLevAlloDetails = objBusinessLeaveRequest.ReadLeavTypdtl(objEntityLeaveRequest);
    //    DataTable DtUser = objBusinessLeaveRequest.ReadUserDetails(objEntityLeaveRequest);
    //    string UsrDesg = DtUser.Rows[0]["DSGN_ID"].ToString();
    //    string UsrJoinDate = DtUser.Rows[0]["EMPERDTL_JOIN_DATE"].ToString();
    //    string UsrGender = DtUser.Rows[0]["EMPERDTL_GENDER"].ToString();
    //    string UsrMrtlSts = DtUser.Rows[0]["EMPERDTL_MRTL_STS"].ToString();
    //    string UsrPayGrd = DtUser.Rows[0]["PYGRD_ID"].ToString();
    //    foreach (DataRow rowDepnt in DtLevAlloDetails.Rows)
    //    {

    //        string GendrChck = "false", MrtlChck = "false", DesgChck = "false", PayGrdChck = "false", ExpChck = "false", IndvdlLvTypChk = "false";

    //        if (rowDepnt["EMPLEAVTYP_ID"].ToString() != "")
    //        {
    //            IndvdlLvTypChk = "true";
    //        }

    //        objEntityLeaveRequest.Leave_Id = Convert.ToInt32(rowDepnt["LEAVETYP_ID"].ToString());
    //        DataTable dtGendrMrtSts = objBusinessLeaveRequest.ReadGendrMrtSts(objEntityLeaveRequest);
    //        DataTable dtDesgDtls = objBusinessLeaveRequest.ReadDesgDtls(objEntityLeaveRequest);
    //        DataTable dtPayGrdeDtls = objBusinessLeaveRequest.ReadPayGrdedtls(objEntityLeaveRequest);
    //        DataTable dtExpDtls = objBusinessLeaveRequest.ReadExpDtls(objEntityLeaveRequest);

    //        //For gender check
    //        if (dtGendrMrtSts.Rows.Count > 0)
    //        {
    //            if (dtGendrMrtSts.Rows[0][0].ToString() == "2")
    //            {
    //                GendrChck = "true";
    //            }
    //            else if (dtGendrMrtSts.Rows[0][0].ToString() == UsrGender)
    //            {
    //                GendrChck = "true";
    //            }
    //        }
    //        //For marrital status
    //        if (dtGendrMrtSts.Rows.Count > 0)
    //        {
    //            if (dtGendrMrtSts.Rows[0][1].ToString() == "2")
    //            {
    //                MrtlChck = "true";
    //            }
    //            else if (dtGendrMrtSts.Rows[0][1].ToString() != UsrGender)
    //            {
    //                MrtlChck = "true";
    //            }
    //        }
    //        //For Designation 
    //        if (dtDesgDtls.Rows.Count > 0)
    //        {
    //            if (dtDesgDtls.Rows[0][1].ToString() == "1")
    //            {
    //                DesgChck = "true";
    //            }
    //            else
    //            {
    //                foreach (DataRow rowDesg in dtDesgDtls.Rows)
    //                {
    //                    if (rowDesg[0].ToString() == UsrDesg)
    //                    {
    //                        DesgChck = "true";
    //                        break;
    //                    }
    //                }

    //            }
    //        }
    //        //For paygrade
    //        if (dtPayGrdeDtls.Rows.Count > 0)
    //        {
    //            if (dtPayGrdeDtls.Rows[0][1].ToString() == "1")
    //            {
    //                PayGrdChck = "true";
    //            }
    //            else
    //            {
    //                foreach (DataRow rowDesg in dtPayGrdeDtls.Rows)
    //                {
    //                    if (rowDesg[0].ToString() == UsrPayGrd)
    //                    {
    //                        PayGrdChck = "true";
    //                        break;
    //                    }
    //                }

    //            }
    //        }
    //        //For experience
    //        decimal ExpYears = 0;
    //        if (UsrJoinDate != "")
    //        {

    //            DateTime Dob = objCommon.textToDateTime(UsrJoinDate);
    //            //ExpYears = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
    //            ExpYears = (dtCurrDate.Month - Dob.Month) + 12 * (dtCurrDate.Year - Dob.Year);
    //            ExpYears = ExpYears / 12;
    //        }
    //        if (dtExpDtls.Rows.Count > 0)
    //        {
    //            if (dtExpDtls.Rows[0][1].ToString() == "1")
    //            {
    //                ExpChck = "true";
    //            }
    //            else
    //            {
    //                foreach (DataRow rowDesg in dtExpDtls.Rows)
    //                {
    //                    int intMinYear = Convert.ToInt32(rowDesg[2]);
    //                    int intMaxYear = Convert.ToInt32(rowDesg[3]);
    //                    if (ExpYears >= intMinYear && ExpYears <= intMaxYear)
    //                    {
    //                        ExpChck = "true";
    //                    }
    //                    //if (rowDesg[0].ToString() == "1")
    //                    //{
    //                    //    if (ExpYears >= 0 && ExpYears <= 2)
    //                    //    {
    //                    //        ExpChck = "true";
    //                    //    }
    //                    //}

    //                    //else if (rowDesg[0].ToString() == "2")
    //                    //{
    //                    //    if (ExpYears >= 2 && ExpYears <= 4)
    //                    //    {
    //                    //        ExpChck = "true";
    //                    //    }
    //                    //}

    //                    //else if (rowDesg[0].ToString() == "3")
    //                    //{
    //                    //    if (ExpYears >= 4 && ExpYears <= 6)
    //                    //    {
    //                    //        ExpChck = "true";
    //                    //    }
    //                    //}

    //                    //else if (rowDesg[0].ToString() == "4")
    //                    //{
    //                    //    if (ExpYears >= 6 && ExpYears <= 8)
    //                    //    {
    //                    //        ExpChck = "true";
    //                    //    }
    //                    //}

    //                    //else if (rowDesg[0].ToString() == "5")
    //                    //{
    //                    //    if (ExpYears >= 8 && ExpYears <= 10)
    //                    //    {
    //                    //        ExpChck = "true";
    //                    //    }
    //                    //}
    //                    //else if (rowDesg[0].ToString() == "6")
    //                    //{
    //                    //    if (ExpYears >= 10 && ExpYears <= 15)
    //                    //    {
    //                    //        ExpChck = "true";
    //                    //    }
    //                    //}
    //                    //else if (rowDesg[0].ToString() == "7")
    //                    //{
    //                    //    if (ExpYears >= 15 && ExpYears <= 20)
    //                    //    {
    //                    //        ExpChck = "true";
    //                    //    }
    //                    //}
    //                }

    //            }
    //        }


    //        if ((DesgChck == "true" || ExpChck == "true" || PayGrdChck == "true" || IndvdlLvTypChk == "true") && (GendrChck == "true" && MrtlChck == "true"))
    //        {
    //        }
    //        else
    //        {
    //            rowDepnt.Delete();
    //        }

    //    }

    //    clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
    //    clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
    //    objEntLevAllocn.EmployeeId = objEntityLeaveRequest.User_Id;

    //    hiddenCurrentDate2.Value = "01-01-2019";// strCurrentDate;
    //    DataTable DtUser_CurrDate = objBusLevAllocn.ReadUserDetailsGnUser(objEntLevAllocn);
    //    if (DtUser_CurrDate.Rows.Count > 0)
    //    {         
    //        DateTime dtLast_mnt_sal_processed = objCommon.textToDateTime("01-01-2019");
    //        DateTime dtLast_leave_settled_dt = objCommon.textToDateTime("01-01-2019");

    //        if (DtUser_CurrDate.Rows[0]["LAST_LEAVE_SETTLED_DT"].ToString() != "")
    //        {
    //            dtLast_leave_settled_dt = objCommon.textToDateTime(DtUser_CurrDate.Rows[0]["LAST_LEAVE_SETTLED_DT"].ToString());

    //        }

    //        if (DtUser_CurrDate.Rows[0]["LAST_MNT_SAL_PROCESSED"].ToString() != "")
    //        {
    //            dtLast_mnt_sal_processed = objCommon.textToDateTime(DtUser_CurrDate.Rows[0]["LAST_MNT_SAL_PROCESSED"].ToString());
    //        }
    //        if (dtLast_leave_settled_dt > dtLast_mnt_sal_processed)
    //        {
    //            hiddenCurrentDate2.Value = dtLast_leave_settled_dt.ToString("dd-MM-yyyy");

    //        }
    //        else if (dtLast_leave_settled_dt < dtLast_mnt_sal_processed)
    //        {
    //            hiddenCurrentDate2.Value = dtLast_mnt_sal_processed.ToString("dd-MM-yyyy");

    //        }
    //        else if (dtLast_leave_settled_dt == dtLast_mnt_sal_processed)
    //        {
    //            hiddenCurrentDate2.Value = dtLast_mnt_sal_processed.ToString("dd-MM-yyyy");
    //        }
   
    //    }














    //    DtLevAlloDetails.AcceptChanges();

    //    if (DtLevAlloDetails.Rows.Count > 0)
    //    {
    //        ddlLeavTyp.DataSource = DtLevAlloDetails;
    //        ddlLeavTyp.DataValueField = "LEAVETYP_ID";
    //        ddlLeavTyp.DataTextField = "LEAVETYP_NAME";
    //        ddlLeavTyp.DataBind();

    //    }
    //    ddlLeavTyp.Items.Insert(0, "--SELECT LEAVE TYPE--");

    //}

    [WebMethod]
    public static string LeavTypLoad(string CorpId, string OrgId, string EmpId, string FromDate)
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

        if (EmpId != "--SELECT AN EMPLOYEE--" && FromDate != "")
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

    [WebMethod]
    public static void CancelRqst(int LeaveRqstId, int UserId)
    {
        clsBusinessLeaveRequest objBusinessLeaveRequest = new clsBusinessLeaveRequest();
        clsEntityLeaveRequest objEntityLeaveRequest = new clsEntityLeaveRequest();
        objEntityLeaveRequest.LeaveRqstId = LeaveRqstId;
        objEntityLeaveRequest.User_Id = UserId;
        objEntityLeaveRequest.date = dtCurrDate;
        objBusinessLeaveRequest.CancelRqst(objEntityLeaveRequest);
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
            strJson[3] = dt.Rows[0]["LEAVETYPDTLS_PAIDLEAVE"].ToString();
        }
        else
        {
            ret = "false";
        }
        strJson[0] = ret;
       

        return strJson;

    }
    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:80%;text-align: left; word-wrap:break-word;\">NAME</th>";
            }

            else if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">RELATION</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: center; word-wrap:break-word;\">YES</th>";
            }
           
        }

        DataTable dtDepntIds = new DataTable();
        if (hiddenstrid.Value != "" || hiddenstrid.Value != null)
        {
            clsBusinessLeaveRequest objBusinessLeaveRequest = new clsBusinessLeaveRequest();
            clsEntityLeaveRequest objEntityLeaveRequest = new clsEntityLeaveRequest();
            objEntityLeaveRequest.LeaveRqstId = Convert.ToInt32(hiddenstrid.Value);
            dtDepntIds = objBusinessLeaveRequest.ReadDepntIds(objEntityLeaveRequest);
        }


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        HiddenFieldCbxCount.Value = Convert.ToString(dt.Rows.Count);
        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr  >";
            strHtml += "<td id=\"DepntId" + intRowBodyCount + "\" style=\"display:none;\" >" + dt.Rows[intRowBodyCount][0].ToString() + "</td>";
          
 
         

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:80%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
            }
            string sts = "false";

            strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\">";
            foreach (DataRow rowDepnt in dtDepntIds.Rows)
            {
                if (rowDepnt["EMPDPNT_ID"].ToString() == dt.Rows[intRowBodyCount][0].ToString())
                {
                    sts = "true";
                   
                }
               
            }

                if (sts == "true")
                {
                    //EVM-0027 08-02-2019
                    if (HiddenFieldConfirm.Value == "1" || HiddenView.Value=="1" )
                    {
                        strHtml += "<input id=\"cbx" + intRowBodyCount + "\" disabled  type=\"checkbox\" checked onchange=\"return IncrmntConfrmCounter();\" onkeydown=\"return isTag(event);\" />";
                    }
                    else
                    {
                        strHtml += "<input id=\"cbx" + intRowBodyCount + "\"  type=\"checkbox\" checked onchange=\"return IncrmntConfrmCounter();\" onkeydown=\"return isTag(event);\" />";

                    }
                }
                else
                {
                    if (HiddenFieldConfirm.Value == "1" || HiddenView.Value == "1")
                    {
                        strHtml += "<input id=\"cbx" + intRowBodyCount + "\"  disabled type=\"checkbox\" onchange=\"return IncrmntConfrmCounter();\" onkeydown=\"return isTag(event);\" />";
                    }
                    else
                    {
                        strHtml += "<input id=\"cbx" + intRowBodyCount + "\"  type=\"checkbox\" onchange=\"return IncrmntConfrmCounter();\" onkeydown=\"return isTag(event);\" />";
                    }
                }

           //END

            strHtml += "</td>";


            strHtml += "</tr>";

        }
        if (dt.Rows.Count == 0)
        {
            strHtml += "<td  class=\"thT\" colspan=\"8\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLeaveRequest objBusinessLeaveRequest = new clsBusinessLeaveRequest();
        clsEntityLeaveRequest objEntityLeaveRequest = new clsEntityLeaveRequest();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        decimal decHalfFrmday = 0, decHalfToDay = 0;

        //EVM040
        DateTime dateCurnt, dateCurnt2;
        //EVM040

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLeaveRequest.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityLeaveRequest.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityLeaveRequest.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        //if (ddlLeavTyp.SelectedItem.Value != "--SELECT LEAVE TYPE--")
        //{
        //    objEntityLeaveRequest.Leave_Id = Convert.ToInt32(ddlLeavTyp.SelectedItem.Value);
        //}
        if (hiddenLeaveTypId.Value != "--SELECT LEAVE TYPE--")
        {
            objEntityLeaveRequest.Leave_Id = Convert.ToInt32(hiddenLeaveTypId.Value);
        }
        if (cbxSettlement.Checked)
        {
            objEntityLeaveRequest.PaidLvStatus = 1;
        }
        else
        {
            objEntityLeaveRequest.PaidLvStatus = 0;
        }
        objEntityLeaveRequest.LeaveFrmDate = objCommon.textToDateTime(txtDateFrom.Text.Trim());
        dateCurnt = objEntityLeaveRequest.LeaveFrmDate;

        if (ddlSecnFrom.SelectedItem.Value != "--SELECT FROM--")
        {
            objEntityLeaveRequest.LeaveFromSection = Convert.ToInt32(ddlSecnFrom.SelectedItem.Value);
            if (objEntityLeaveRequest.LeaveFromSection != 1)
            {
                decHalfFrmday = Convert.ToDecimal(0.5);
            }
        }
        if (cbxStatus.Checked == true)
        {
            objEntityLeaveRequest.LeaveToDate = objCommon.textToDateTime(TextDateTo.Text.Trim());
            objEntityLeaveRequest.MulDaysChk = 1;
        }
        else
        {
            objEntityLeaveRequest.LeaveToDate = DateTime.MinValue;
            objEntityLeaveRequest.MulDaysChk = 0;
        }

        //EVM040
        dateCurnt2 = objEntityLeaveRequest.LeaveToDate;
        //EVM040

        if (ddlSecTo.SelectedItem.Value != "--SELECT TO--")
        {
            objEntityLeaveRequest.LeaveToSection = Convert.ToInt32(ddlSecTo.SelectedItem.Value);
            if (objEntityLeaveRequest.LeaveToSection != 1)
            {
                decHalfToDay = Convert.ToDecimal(0.5);
            }
        }
        objEntityLeaveRequest.NumOfLeave = Convert.ToDecimal(hiddennoofleave.Value);
        objEntityLeaveRequest.OpeningLv = Convert.ToInt32(hiddenOpeningLev.Value);

        int intFlag = 0;
        DateTime dateFrm, dateTo;


        DataTable dtCheckReportOffcr = objBusinessLeaveRequest.CheckReportOffcr(objEntityLeaveRequest);
        bool HavingReportingOffcr = false;
        if (dtCheckReportOffcr.Rows.Count > 0)
        {
            if (dtCheckReportOffcr.Rows[0]["EMPREPORTING"].ToString() != "0")
            {
                HavingReportingOffcr = true;
            }
        }
        //DuplicationLevDate
        if (HavingReportingOffcr == true)
        {
            DataTable datatableFrmChk;

            datatableFrmChk = objBusinessLeaveRequest.ChkDatesInLeavReqst(objEntityLeaveRequest);
            if (datatableFrmChk.Rows.Count > 0)
            {
                foreach (DataRow row in datatableFrmChk.Rows)
                {
                    if (objCommon.textToDateTime(row["LEAVE_FROM_DATE"].ToString()) == objEntityLeaveRequest.LeaveFrmDate)
                    {
                        intFlag++;
                        if (intFlag != 0)
                        {
                            break;
                        }
                    }
                    if (row["LEAVE_TO_DATE"] != DBNull.Value && row["LEAVE_TO_DATE"].ToString() != null && row["LEAVE_TO_DATE"].ToString() != "")
                    {

                        dateFrm = objCommon.textToDateTime(row["LEAVE_FROM_DATE"].ToString());
                        dateTo = objCommon.textToDateTime(row["LEAVE_TO_DATE"].ToString());
                        //START
                        //EVM040

                        if (dateCurnt2 != DateTime.MinValue)
                        {
                            if (dateCurnt2 >= dateFrm && dateCurnt <= dateTo)
                            {
                                intFlag++;
                                if (intFlag != 0)
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (dateCurnt >= dateFrm && dateCurnt <= dateTo)
                            {
                                intFlag++;
                                if (intFlag != 0)
                                {
                                    break;
                                }
                            }
                        }

                    }
                    else
                    {
                        dateFrm = objCommon.textToDateTime(row["LEAVE_FROM_DATE"].ToString());
                        if (dateCurnt <= dateFrm && dateCurnt >= dateFrm)
                        {
                            intFlag++;
                            if (intFlag != 0)
                            {
                                break;
                            }
                        }

                    }
                    //END
                    //EVM040



                }
            }
            else
            {

                //  strFrmDate = objBusLevAllocn.FrmDate(objEntLevAllocn);
            }

            objEntityLeaveRequest.Description = txtLvDesc.Text;
            if (cbxTrvlSts.Checked == true)
            {
                objEntityLeaveRequest.TravelStatus = 0;
            }
            else
            {
                objEntityLeaveRequest.TravelStatus = 1;
            }
            //Start:-For Travel details
            string[] strarrDepntIds = null;
            if (HiddenFieldTrvlDtlsVisible.Value == "true")
            {
                objEntityLeaveRequest.ShowTrvlDtls = 1;
                objEntityLeaveRequest.DateOfTrvl = objCommon.textToDateTime(txtDateTrvl.Text.Trim());
                objEntityLeaveRequest.DateOfRetrn = objCommon.textToDateTime(txtDateRetrn.Text.Trim());
                objEntityLeaveRequest.Destination = txtDestntn.Text;
                objEntityLeaveRequest.AirlinePrfrd = txtAirLine.Text;
                objEntityLeaveRequest.Address = txtAddrss.Text;
                objEntityLeaveRequest.TeleNo = txtTelNo.Text;
                objEntityLeaveRequest.LocalCntctNo = txtLclCntctNo.Text;
                objEntityLeaveRequest.Email = txtEmail.Text;
                objEntityLeaveRequest.Comment = txtCmnt.Text;
                if (cbxNeedTckt.Checked == true)
                {
                    objEntityLeaveRequest.TcketNeeded = 1;
                }
                else
                {
                    objEntityLeaveRequest.TcketNeeded = 0;
                }



                //For family details
                string strDepntId = "";
                strarrDepntIds = strDepntId.Split(',');
                if (HiddenFieldDepntIds.Value != "" && HiddenFieldDepntIds.Value != null)
                {
                    strDepntId = HiddenFieldDepntIds.Value;
                    strarrDepntIds = strDepntId.Split(',');

                }

            }

            if (intFlag == 0)
            {

                //End:-For Travel details
                objBusinessLeaveRequest.AddLeavReqstDetails(objEntityLeaveRequest, strarrDepntIds);


                //objEntityLeaveRequest.NumOfLeaveNew = Convert.ToInt32(hiddenOpeningLev.Value) - Convert.ToDecimal(hiddennoofleave.Value);


                if (cbxStatus.Checked == false)
                {
                    string strremLeav = "";
                    DataTable dataDt = objBusinessLeaveRequest.ReadRemLeav(objEntityLeaveRequest);
                    objEntityLeaveRequest.RemingLev = Convert.ToDecimal(hiddenFrmRem.Value);
                    if (dataDt.Rows.Count > 0)
                    {
                        strremLeav = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                    }
                    if (strremLeav == "")
                    {
                        objBusinessLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);//inserting all leavetypes of user if not present for the leave adding year
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
                        DataTable dataDt = objBusinessLeaveRequest.ReadRemLeav(objEntityLeaveRequest);
                        objEntityLeaveRequest.RemingLev = Convert.ToDecimal(hiddenFrmRem.Value);
                        if (dataDt.Rows.Count > 0)
                        {
                            strremLeav = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                        }
                        if (strremLeav == "")
                        {
                            objBusinessLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);
                        }

                    }
                    else
                    {

                        string strremLeavFrm = "", strremLeavTo = "";
                        DataTable dataDt = objBusinessLeaveRequest.ReadRemLeav(objEntityLeaveRequest);
                        objEntityLeaveRequest.RemingLev = Convert.ToDecimal(hiddenFrmRem.Value);
                        if (dataDt.Rows.Count > 0)
                        {
                            strremLeavFrm = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                        }
                        if (strremLeavFrm == "")
                        {
                            objBusinessLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);
                        }
                        objEntityLeaveRequest.LeaveFrmDate = objEntityLeaveRequest.LeaveToDate;
                        DataTable dataDtt = objBusinessLeaveRequest.ReadRemLeav(objEntityLeaveRequest);
                        objEntityLeaveRequest.RemingLev = Convert.ToDecimal(hiddenToRem.Value);
                        if (dataDtt.Rows.Count > 0)
                        {
                            strremLeavTo = dataDtt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                        }
                        if (strremLeavTo == "")
                        {
                            objBusinessLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);
                        }

                    }
                }




                if (clickedButton.ID == "btnAdd")
                {
                    Response.Redirect("hcm_Leave_Request.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnAddClose")
                {
                    Response.Redirect("hcm_Leave_Request_List.aspx?InsUpd=Ins");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationLevDate", "DuplicationLevDate();", true);
            }

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "CheckReportingOfficer", "CheckReportingOfficer();", true);
          //  Response.Redirect("hcm_Leave_Request.aspx?InsUpd=NO_ReportOffcr");
        }
       
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLeaveRequest objBusinessLeaveRequest = new clsBusinessLeaveRequest();
        clsEntityLeaveRequest objEntityLeaveRequest = new clsEntityLeaveRequest();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        decimal decHalfFrmday = 0, decHalfToDay = 0;
        DateTime dateCurnt;
        if (Request.QueryString["Id"] != null)
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLeaveRequest.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityLeaveRequest.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                objEntityLeaveRequest.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            //if (ddlLeavTyp.SelectedItem.Value != "--SELECT LEAVE TYPE--")
            //{
            //    objEntityLeaveRequest.Leave_Id = Convert.ToInt32(ddlLeavTyp.SelectedItem.Value);
            //}
            if (hiddenLeaveTypId.Value != "--SELECT LEAVE TYPE--")
            {
                objEntityLeaveRequest.Leave_Id = Convert.ToInt32(hiddenLeaveTypId.Value);
            }

            objEntityLeaveRequest.LeaveFrmDate = objCommon.textToDateTime(txtDateFrom.Text.Trim());
            dateCurnt = objEntityLeaveRequest.LeaveFrmDate;
            if (cbxSettlement.Checked)
            {
                objEntityLeaveRequest.PaidLvStatus = 1;
            }
            else
            {
                objEntityLeaveRequest.PaidLvStatus = 0;
            }
            if (ddlSecnFrom.SelectedItem.Value != "--SELECT FROM--")
            {
                objEntityLeaveRequest.LeaveFromSection = Convert.ToInt32(ddlSecnFrom.SelectedItem.Value);
                if (objEntityLeaveRequest.LeaveFromSection != 1)
                {
                    decHalfFrmday = Convert.ToDecimal(0.5);
                }
            }
            if (cbxStatus.Checked == true)
            {
                objEntityLeaveRequest.LeaveToDate = objCommon.textToDateTime(TextDateTo.Text.Trim());
                objEntityLeaveRequest.MulDaysChk = 1;
            }
            else
            {
                objEntityLeaveRequest.LeaveToDate = DateTime.MinValue;
                objEntityLeaveRequest.MulDaysChk = 0;

            }

            if (ddlSecTo.SelectedItem.Value != "--SELECT TO--")
            {
                objEntityLeaveRequest.LeaveToSection = Convert.ToInt32(ddlSecTo.SelectedItem.Value);
                if (objEntityLeaveRequest.LeaveToSection != 1)
                {
                    decHalfToDay = Convert.ToDecimal(0.5);
                }
            }
            objEntityLeaveRequest.NumOfLeave = Convert.ToDecimal(hiddennoofleave.Value);
           //objEntityLeaveRequest.OpeningLv = Convert.ToInt32(hiddenOpeningLev.Value);



            DataTable dtCheckReportOffcr = objBusinessLeaveRequest.CheckReportOffcr(objEntityLeaveRequest);
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
                int intFlag = 0;
                DateTime dateFrm, dateTo;

                DataTable datatableFrmChk;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strHolId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityLeaveRequest.LeaveRqstId = Convert.ToInt32(strHolId);

                datatableFrmChk = objBusinessLeaveRequest.ChkDatesInLeavReqst(objEntityLeaveRequest);
                if (datatableFrmChk.Rows.Count > 0)
                {
                    foreach (DataRow row in datatableFrmChk.Rows)
                    {
                        if (objCommon.textToDateTime(row["LEAVE_FROM_DATE"].ToString()) == objEntityLeaveRequest.LeaveFrmDate)
                        {
                            intFlag++;
                            if (intFlag != 0)
                            {
                                break;
                            }
                        }
                        if (row["LEAVE_TO_DATE"] != DBNull.Value && row["LEAVE_TO_DATE"].ToString() != null && row["LEAVE_TO_DATE"].ToString() != "")
                        {

                            dateFrm = objCommon.textToDateTime(row["LEAVE_FROM_DATE"].ToString());
                            dateTo = objCommon.textToDateTime(row["LEAVE_TO_DATE"].ToString());
                            if (dateCurnt >= dateFrm && dateCurnt <= dateTo)
                            {
                                intFlag++;
                                if (intFlag != 0)
                                {
                                    break;
                                }
                            }

                        }



                    }
                }
                else
                {

                    //  strFrmDate = objBusLevAllocn.FrmDate(objEntLevAllocn);
                }


                objEntityLeaveRequest.Description = txtLvDesc.Text;
                if (cbxTrvlSts.Checked == true)
                {
                    objEntityLeaveRequest.TravelStatus = 0;
                }
                else
                {
                    objEntityLeaveRequest.TravelStatus = 1;
                }
                //Start:-For Travel details
                string[] strarrDepntIds = null;
                if (HiddenFieldTrvlDtlsVisible.Value == "true")
                {
                    objEntityLeaveRequest.ShowTrvlDtls = 1;
                    objEntityLeaveRequest.DateOfTrvl = objCommon.textToDateTime(txtDateTrvl.Text.Trim());
                    objEntityLeaveRequest.DateOfRetrn = objCommon.textToDateTime(txtDateRetrn.Text.Trim());
                    objEntityLeaveRequest.Destination = txtDestntn.Text;
                    objEntityLeaveRequest.AirlinePrfrd = txtAirLine.Text;
                    objEntityLeaveRequest.Address = txtAddrss.Text;
                    objEntityLeaveRequest.TeleNo = txtTelNo.Text;
                    objEntityLeaveRequest.LocalCntctNo = txtLclCntctNo.Text;
                    objEntityLeaveRequest.Email = txtEmail.Text;
                    objEntityLeaveRequest.Comment = txtCmnt.Text;

                    if (cbxNeedTckt.Checked == true)
                    {
                        objEntityLeaveRequest.TcketNeeded = 1;
                    }
                    else
                    {
                        objEntityLeaveRequest.TcketNeeded = 0;
                    }

                    //For family details
                    string strDepntId = "";
                    strarrDepntIds = strDepntId.Split(',');
                    if (HiddenFieldDepntIds.Value != "" && HiddenFieldDepntIds.Value != null)
                    {
                        strDepntId = HiddenFieldDepntIds.Value;
                        strarrDepntIds = strDepntId.Split(',');

                    }

                }



                //End:-For Travel details
                if (intFlag == 0)
                {





                    objEntityLeaveRequest.date = dtCurrDate;

                    objBusinessLeaveRequest.UpdateLeaveRqstDtls(objEntityLeaveRequest, strarrDepntIds);


                    //objEntityLeaveRequest.NumOfLeaveNew = Convert.ToInt32(hiddenOpeningLev.Value) - Convert.ToDecimal(hiddennoofleave.Value);


                    if (cbxStatus.Checked == false)
                    {
                        string strremLeav = "";
                        DataTable dataDt = objBusinessLeaveRequest.ReadRemLeav(objEntityLeaveRequest);
                        objEntityLeaveRequest.RemingLev = Convert.ToDecimal(hiddenFrmRem.Value);
                        if (dataDt.Rows.Count > 0)
                        {
                            strremLeav = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                        }
                        if (strremLeav == "")
                        {
                            objBusinessLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);//inserting all leavetypes of user if not present for the leave adding year
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
                            DataTable dataDt = objBusinessLeaveRequest.ReadRemLeav(objEntityLeaveRequest);
                            objEntityLeaveRequest.RemingLev = Convert.ToDecimal(hiddenFrmRem.Value);
                            if (dataDt.Rows.Count > 0)
                            {
                                strremLeav = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                            }
                            if (strremLeav == "")
                            {
                                objBusinessLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);
                            }

                        }
                        else
                        {

                            string strremLeavFrm = "", strremLeavTo = "";
                            DataTable dataDt = objBusinessLeaveRequest.ReadRemLeav(objEntityLeaveRequest);
                            objEntityLeaveRequest.RemingLev = Convert.ToDecimal(hiddenFrmRem.Value);
                            if (dataDt.Rows.Count > 0)
                            {
                                strremLeavFrm = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                            }
                            if (strremLeavFrm == "")
                            {
                                objBusinessLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);
                            }
                            objEntityLeaveRequest.LeaveFrmDate = objEntityLeaveRequest.LeaveToDate;
                            DataTable dataDtt = objBusinessLeaveRequest.ReadRemLeav(objEntityLeaveRequest);
                            objEntityLeaveRequest.RemingLev = Convert.ToDecimal(hiddenToRem.Value);
                            if (dataDtt.Rows.Count > 0)
                            {
                                strremLeavTo = dataDtt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                            }
                            if (strremLeavTo == "")
                            {
                                objBusinessLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);
                            }

                        }
                    }




                    if (clickedButton.ID == "btnUpdate")
                    {
                        Response.Redirect("hcm_Leave_Request.aspx?InsUpd=Upd");
                    }
                    else if (clickedButton.ID == "btnUpdateClose")
                    {
                        Response.Redirect("hcm_Leave_Request_List.aspx?InsUpd=Upd");
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationLevDate", "DuplicationLevDate();", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "CheckReportingOfficer", "CheckReportingOfficer();", true);
            }
        }
       
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLeaveRequest objBusinessLeaveRequest = new clsBusinessLeaveRequest();
        clsEntityLeaveRequest objEntityLeaveRequest = new clsEntityLeaveRequest();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        decimal decHalfFrmday = 0, decHalfToDay = 0;
        DateTime dateCurnt;
        if (Request.QueryString["Id"] != null)
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLeaveRequest.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityLeaveRequest.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                objEntityLeaveRequest.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            //if (ddlLeavTyp.SelectedItem.Value != "--SELECT LEAVE TYPE--")
            //{
            //    objEntityLeaveRequest.Leave_Id = Convert.ToInt32(ddlLeavTyp.SelectedItem.Value);
            //}
            if (hiddenLeaveTypId.Value != "--SELECT LEAVE TYPE--")
            {
                objEntityLeaveRequest.Leave_Id = Convert.ToInt32(hiddenLeaveTypId.Value);
            }

            objEntityLeaveRequest.LeaveFrmDate = objCommon.textToDateTime(txtDateFrom.Text.Trim());
            dateCurnt = objEntityLeaveRequest.LeaveFrmDate;
            if (cbxSettlement.Checked)
            {
                objEntityLeaveRequest.PaidLvStatus = 1;
            }
            else
            {
                objEntityLeaveRequest.PaidLvStatus = 0;
            }
            if (ddlSecnFrom.SelectedItem.Value != "--SELECT FROM--")
            {
                objEntityLeaveRequest.LeaveFromSection = Convert.ToInt32(ddlSecnFrom.SelectedItem.Value);
                if (objEntityLeaveRequest.LeaveFromSection != 1)
                {
                    decHalfFrmday = Convert.ToDecimal(0.5);
                }
            }
            if (cbxStatus.Checked == true)
            {
                objEntityLeaveRequest.LeaveToDate = objCommon.textToDateTime(TextDateTo.Text.Trim());
                objEntityLeaveRequest.MulDaysChk = 1;
            }
            else
            {
                objEntityLeaveRequest.LeaveToDate = DateTime.MinValue;
                objEntityLeaveRequest.MulDaysChk = 0;

            }
            if (ddlSecTo.SelectedItem.Value != "--SELECT TO--")
            {
                objEntityLeaveRequest.LeaveToSection = Convert.ToInt32(ddlSecTo.SelectedItem.Value);
                if (objEntityLeaveRequest.LeaveToSection != 1)
                {
                    decHalfToDay = Convert.ToDecimal(0.5);
                }
            }
            objEntityLeaveRequest.NumOfLeave = Convert.ToDecimal(hiddennoofleave.Value);

            objEntityLeaveRequest.Description = txtLvDesc.Text;

            if (cbxTrvlSts.Checked == true)
            {
                objEntityLeaveRequest.TravelStatus = 0;
            }
            else
            {
                objEntityLeaveRequest.TravelStatus = 1;
            }

            DataTable dtCheckReportOffcr = objBusinessLeaveRequest.CheckReportOffcr(objEntityLeaveRequest);
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


                //Start:-For Travel details
                string[] strarrDepntIds = null;
                if (HiddenFieldTrvlDtlsVisible.Value == "true")
                {
                    objEntityLeaveRequest.ShowTrvlDtls = 1;
                    objEntityLeaveRequest.DateOfTrvl = objCommon.textToDateTime(txtDateTrvl.Text.Trim());
                    objEntityLeaveRequest.DateOfRetrn = objCommon.textToDateTime(txtDateRetrn.Text.Trim());
                    objEntityLeaveRequest.Destination = txtDestntn.Text;
                    objEntityLeaveRequest.AirlinePrfrd = txtAirLine.Text;
                    objEntityLeaveRequest.Address = txtAddrss.Text;
                    objEntityLeaveRequest.TeleNo = txtTelNo.Text;
                    objEntityLeaveRequest.LocalCntctNo = txtLclCntctNo.Text;
                    objEntityLeaveRequest.Email = txtEmail.Text;
                    objEntityLeaveRequest.Comment = txtCmnt.Text;

                    if (cbxNeedTckt.Checked == true)
                    {
                        objEntityLeaveRequest.TcketNeeded = 1;
                    }
                    else
                    {
                        objEntityLeaveRequest.TcketNeeded = 0;
                    }

                    //For family details
                    string strDepntId = "";
                    strarrDepntIds = strDepntId.Split(',');
                    if (HiddenFieldDepntIds.Value != "" && HiddenFieldDepntIds.Value != null)
                    {
                        strDepntId = HiddenFieldDepntIds.Value;
                        strarrDepntIds = strDepntId.Split(',');

                    }

                }



                //End:-For Travel details

                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strHolId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityLeaveRequest.LeaveRqstId = Convert.ToInt32(strHolId);


                objEntityLeaveRequest.date = dtCurrDate;

                //decimal decRemainLeav = 0, decNoOfLeav = 0;
                //decNoOfLeav = Convert.ToDecimal(hiddennoofleave.Value);

                //decRemainLeav = Convert.ToDecimal(hiddenremaingLev.Value);
                //decRemainLeav = decRemainLeav - decNoOfLeav;
                //objEntLevAllocn.RemingLev = decRemainLeav;
                //objBusLevAllocn.InsertUserLeavTyp(objEntLevAllocn);
                //If there is no name like this on table.    
                string strconfmAllocnCount = "", strFrmDate = "";
                int intFlag = 0;
                DateTime dateFrm, dateTo;
                DataTable datatableFrmChk;
                strconfmAllocnCount = objBusinessLeaveRequest.confmAllocnCount(objEntityLeaveRequest);



                if (strconfmAllocnCount != "0" && strconfmAllocnCount != "")
                {

                    datatableFrmChk = objBusinessLeaveRequest.FrmSgleDate(objEntityLeaveRequest);
                    if (datatableFrmChk.Rows.Count > 0)
                    {
                        foreach (DataRow row in datatableFrmChk.Rows)
                        {
                            if (row["LEAVE_FROM_DATE"].ToString() == objEntityLeaveRequest.LeaveFrmDate.ToString())
                            {
                                intFlag++;
                                if (intFlag != 0)
                                {
                                    break;
                                }
                            }
                            if (row["LEAVE_TO_DATE"] != DBNull.Value && row["LEAVE_TO_DATE"].ToString() != null && row["LEAVE_TO_DATE"].ToString() != "")
                            {

                                dateFrm = objCommon.textToDateTime(row["LEAVE_FROM_DATE"].ToString());
                                dateTo = objCommon.textToDateTime(row["LEAVE_TO_DATE"].ToString());
                                if (dateCurnt >= dateFrm && dateCurnt <= dateTo)
                                {
                                    intFlag++;
                                    if (intFlag != 0)
                                    {
                                        break;
                                    }
                                }

                            }



                        }
                    }
                    else
                    {

                        //  strFrmDate = objBusLevAllocn.FrmDate(objEntLevAllocn);
                    }

                }
                else
                {
                    objBusinessLeaveRequest.UpdateLeaveRqstDtls(objEntityLeaveRequest, strarrDepntIds);
                    objEntityLeaveRequest.LeaveConfmn = 1;
                    objBusinessLeaveRequest.ConfirmLeavAllocnDtl(objEntityLeaveRequest);
                }
                if (intFlag == 0)
                {
                    objBusinessLeaveRequest.UpdateLeaveRqstDtls(objEntityLeaveRequest, strarrDepntIds);
                    objEntityLeaveRequest.LeaveConfmn = 1;
                    objBusinessLeaveRequest.ConfirmLeavAllocnDtl(objEntityLeaveRequest);


                    //Start:-Insert other leave types to GN_USER_LEAVE_TYPES
                    int LeaveidOld = objEntityLeaveRequest.Leave_Id;

                    clsBusiness_Leave_Type objBusinessLeaveType = new clsBusiness_Leave_Type();
                    clsEntity_Leave_Type objEntityLeaveType = new clsEntity_Leave_Type();

                    string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
                    DateTime CurrentDate = objCommon.textToDateTime(strCurrentDate);

                    objEntityLeaveType.EmployeeId = objEntityLeaveRequest.EmployeeId;

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
                    objEntityLeaveType.FromDate = objEntityLeaveRequest.LeaveFrmDate;

                    DataTable dtLeaveTypes = objBusinessLeaveType.ReadUserLeaveTypes(objEntityLeaveType);

                    objEntityLeaveRequest.Leave_Id = LeaveidOld;
                    //Stop:-Insert other leave types to GN_USER_LEAVE_TYPES

                    if (cbxStatus.Checked == false)
                    {

                        string strchkuserlevCount = "0";
                        strchkuserlevCount = objBusinessLeaveRequest.chkUserLevCount(objEntityLeaveRequest);

                        decimal decRemainLeav = 0, decNoOfLeav = 0;
                        decNoOfLeav = Convert.ToDecimal(hiddennoofleave.Value);
                        decimal decOpngLev = Convert.ToDecimal(hiddenOpeningLev.Value);
                        objEntityLeaveRequest.OpeningLv = decOpngLev;
                        decRemainLeav = Convert.ToDecimal(hiddenremngNxtyrLv.Value);
                        //    decRemainLeav = decRemainLeav - decNoOfLeav;
                        objEntityLeaveRequest.RemingLev = decRemainLeav;
                        if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                        {
                            objBusinessLeaveRequest.InsertUserLeavTyp(objEntityLeaveRequest);//updating balance leave of user
                        }
                        else
                        {
                            objBusinessLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);//inserting all leavetypes of user if not present for the leave adding year
                        }




                        //Start:-Insert other leave types to GN_USER_LEAVE_TYPES            
                        for (int i = 0; i < dtLeaveTypes.Rows.Count; i++)
                        {
                            objEntityLeaveRequest.Leave_Id = Convert.ToInt32(dtLeaveTypes.Rows[i]["LEAVETYP_ID"].ToString());
                            strchkuserlevCount = "0";
                            strchkuserlevCount = objBusinessLeaveRequest.chkUserLevCount(objEntityLeaveRequest);
                            objEntityLeaveRequest.OpeningLv = Convert.ToDecimal(dtLeaveTypes.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                            objEntityLeaveRequest.RemingLev = Convert.ToDecimal(dtLeaveTypes.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                            if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                            {
                            }
                            else
                            {
                                objBusinessLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);
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
                            objEntityLeaveRequest.OpeningLv = decOpngLev;
                            decRemainLeav = Convert.ToDecimal(hiddenremngNxtyrLv.Value);
                            //        decRemainLeav = decRemainLeav - decNoOfLeav;
                            objEntityLeaveRequest.RemingLev = decRemainLeav;
                            string strchkuserlevCount = "0";

                            strchkuserlevCount = objBusinessLeaveRequest.chkUserLevCount(objEntityLeaveRequest);
                            if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                            {

                                objBusinessLeaveRequest.InsertUserLeavTyp(objEntityLeaveRequest);
                            }
                            else
                            {
                                objBusinessLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);
                            }


                            //Start:-Insert other leave types to GN_USER_LEAVE_TYPES            
                            for (int i = 0; i < dtLeaveTypes.Rows.Count; i++)
                            {
                                objEntityLeaveRequest.Leave_Id = Convert.ToInt32(dtLeaveTypes.Rows[i]["LEAVETYP_ID"].ToString());
                                strchkuserlevCount = "0";
                                strchkuserlevCount = objBusinessLeaveRequest.chkUserLevCount(objEntityLeaveRequest);
                                objEntityLeaveRequest.OpeningLv = Convert.ToDecimal(dtLeaveTypes.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                                objEntityLeaveRequest.RemingLev = Convert.ToDecimal(dtLeaveTypes.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                                if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                                {
                                }
                                else
                                {
                                    objBusinessLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);
                                }
                            }
                            //Stop:-Insert other leave types to GN_USER_LEAVE_TYPES


                        }
                        else
                        {
                            string strchkFrmlevCount = "0", strchkTolevCount = "0";

                            //decimal  decNoOfLeav = 0;
                            //decNoOfLeav = Convert.ToDecimal(hiddennoofleave.Value);
                            //decimal decOpngLev = Convert.ToDecimal(hiddenOpeningLev.Value);
                            //objEntLevAllocn.OpeningLv = decOpngLev;
                            decimal decRemainLeav = 0, decNoOfLeav = 0, decMthRemday = 0, decNxtYrLev = 0;
                            decNoOfLeav = Convert.ToDecimal(hiddennoofleave.Value);
                            decimal decOpngLev = Convert.ToDecimal(hiddenOpeningLev.Value);
                            objEntityLeaveRequest.OpeningLv = decOpngLev;
                            // decRemainLeav = Convert.ToDecimal(hiddenremngNxtyrLv.Value);
                            //decRemainLeav = decRemainLeav - decNoOfLeav;
                            //objEntLevAllocn.RemingLev = decRemainLeav;
                            DateTime today = objEntityLeaveRequest.LeaveFrmDate;
                            int daysleft = new DateTime(today.Year, 12, 31).DayOfYear - today.DayOfYear;
                            daysleft = daysleft + 1;
                            decimal decFromdaysleft = daysleft - decHalfFrmday;
                            decMthRemday = decNoOfLeav - decFromdaysleft;
                            //  decNxtYrLev = decNoOfLeav - decMthRemday;
                            //       decNxtYrLev = decMthRemday - decHalfToDay;
                            strchkFrmlevCount = objBusinessLeaveRequest.chkUserLevCount(objEntityLeaveRequest);
                            strchkTolevCount = objBusinessLeaveRequest.chkUserToLevCount(objEntityLeaveRequest);
                            if (strchkFrmlevCount != "0" && strchkFrmlevCount != "")
                            {

                                decRemainLeav = Convert.ToDecimal(hiddenFrmRem.Value);
                                //            decRemainLeav = decRemainLeav - decFromdaysleft;
                                objEntityLeaveRequest.RemingLev = decRemainLeav;
                                objBusinessLeaveRequest.InsertUserLeavTyp(objEntityLeaveRequest);

                            }
                            else
                            {

                                decRemainLeav = Convert.ToDecimal(hiddenFrmRem.Value);
                                //            decRemainLeav = decRemainLeav - decFromdaysleft;
                                objEntityLeaveRequest.RemingLev = decRemainLeav;
                                // objBusLevAllocn.InsertUserLeavTyp(objEntLevAllocn);
                                objBusinessLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);
                            }
                            if (strchkTolevCount != "0" && strchkTolevCount != "")
                            {

                                decRemainLeav = Convert.ToDecimal(hiddenToRem.Value);
                                //               decRemainLeav = decRemainLeav - decNxtYrLev;
                                objEntityLeaveRequest.RemingLev = decRemainLeav;
                                objEntityLeaveRequest.LeaveFrmDate = objEntityLeaveRequest.LeaveToDate;
                                objBusinessLeaveRequest.InsertUserLeavTyp(objEntityLeaveRequest);

                            }
                            else
                            {

                                decRemainLeav = Convert.ToDecimal(hiddenToRem.Value);
                                //              decRemainLeav = decRemainLeav - decNxtYrLev;
                                objEntityLeaveRequest.RemingLev = decRemainLeav;
                                objEntityLeaveRequest.LeaveFrmDate = objEntityLeaveRequest.LeaveToDate;
                                objBusinessLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);
                            }



                            //Start:-Insert other leave types to GN_USER_LEAVE_TYPES            
                            for (int i = 0; i < dtLeaveTypes.Rows.Count; i++)
                            {
                                string strchkuserlevCount = "0";
                                objEntityLeaveRequest.Leave_Id = Convert.ToInt32(dtLeaveTypes.Rows[i]["LEAVETYP_ID"].ToString());
                                objEntityLeaveRequest.OpeningLv = Convert.ToDecimal(dtLeaveTypes.Rows[i]["LEAVETYP_NUMDAYS"].ToString());
                                objEntityLeaveRequest.RemingLev = Convert.ToDecimal(dtLeaveTypes.Rows[i]["LEAVETYP_NUMDAYS"].ToString());

                                objEntityLeaveRequest.LeaveFrmDate = objCommon.textToDateTime(txtDateFrom.Text.Trim());
                                strchkuserlevCount = objBusinessLeaveRequest.chkUserLevCount(objEntityLeaveRequest);
                                if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                                {
                                }
                                else
                                {
                                    objBusinessLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);
                                }


                                objEntityLeaveRequest.LeaveFrmDate = objEntityLeaveRequest.LeaveToDate;
                                strchkuserlevCount = "0";
                                strchkuserlevCount = objBusinessLeaveRequest.chkUserLevCount(objEntityLeaveRequest);
                                if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                                {
                                }
                                else
                                {
                                    objBusinessLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);
                                }
                            }
                            //Stop:-Insert other leave types to GN_USER_LEAVE_TYPES




                        }
                    }



                    Response.Redirect("hcm_Leave_Request.aspx?InsUpd=Cnfrm");

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
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("hcm_Leave_Request.aspx");
    }
    protected void btnClrnceLink_Click(object sender, EventArgs e)
    {

        Response.Redirect("/HCM/HCM_Master/hcm_LeaveMaster/hcm_Clearance_Form_Staff/hcm_Clearance_Form_Staff.aspx?Id="+HiddenFieldQryString.Value+"");
    }
    
    public void Update(string strWId)
    {

        clsBusinessLeaveRequest objBusinessLeaveRequest = new clsBusinessLeaveRequest();
        clsEntityLeaveRequest objEntityLeaveRequest = new clsEntityLeaveRequest();
        objEntityLeaveRequest.LeaveRqstId = Convert.ToInt32(strWId);
        DataTable dtLeavDetail = new DataTable();
        dtLeavDetail = objBusinessLeaveRequest.ReadLeaveRqstById(objEntityLeaveRequest);
        clsCommonLibrary objCommon = new clsCommonLibrary();
        hiddenstrid.Value = strWId;


        if (Session["USERID"] != null)
        {
            objEntityLeaveRequest.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        //After fetch holiday details in datatable,we need to differentiate.
        if (dtLeavDetail.Rows.Count > 0)
        {

           if (dtLeavDetail.Rows[0]["LEAVE_RQST_STATUS"].ToString() == "0")
            {
                status1.InnerText = "Approval Pending";
                status2.InnerText = "";
            }
            else if (dtLeavDetail.Rows[0]["LEAVE_RQST_STATUS"].ToString() == "1")
            {
                status1.InnerText = "Reporting Officer Approved";
                status2.InnerText = "Waiting For Division Manager Decision";
            }
            else if (dtLeavDetail.Rows[0]["LEAVE_RQST_STATUS"].ToString() == "2")
            {
                status1.InnerText = "Division Manager Approved";
                status2.InnerText = "Waiting For General Manager Decision";
            }
            else if (dtLeavDetail.Rows[0]["LEAVE_RQST_STATUS"].ToString() == "3")
            {
                status1.InnerText = "General Manager Approved";
                status2.InnerText = "Waiting For HR Decision";
            }
            else if (dtLeavDetail.Rows[0]["LEAVE_RQST_STATUS"].ToString() == "4")
            {
                status1.InnerText = "HR Approved";
                status2.InnerText = "";
            }
            else if (dtLeavDetail.Rows[0]["LEAVE_RQST_STATUS"].ToString() == "5")
            {
                status1.InnerText = "Rejected";
                status2.InnerText = "Reason:" + dtLeavDetail.Rows[0]["LEAVE_REJCT_RSN"].ToString();
            }
            else if (dtLeavDetail.Rows[0]["LEAVE_RQST_STATUS"].ToString() == "6")
            {



                if (dtLeavDetail.Rows[0]["LEAVE_CLS_USR_ID"].ToString() != "")
                {
                    status1.InnerText = "Closed";
                    status2.InnerText = "";
                   
                }
                else if (dtLeavDetail.Rows[0]["LEAVE_DIV_MAN_APPROVAL"].ToString() == "0")
                {
                    status1.InnerText = "Cancel Pending";
                    status2.InnerText = "";
                   
                }
                else if (dtLeavDetail.Rows[0]["LEAVE_DIV_MAN_APPROVAL"].ToString() == "1")
                {
                    status1.InnerText = "Cancelled";
                    status2.InnerText = "";
                   
                }

              
            }
           if (dtLeavDetail.Rows[0]["LEAVE_SETTLEMNT_STATUS"].ToString() == "1")
           {
               cbxSettlement.Checked = true;
           }
           else if (dtLeavDetail.Rows[0]["LEAVE_SETTLEMNT_STATUS"].ToString() == "0")
           {
               cbxSettlement.Checked = false;
           } 

           clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
           clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();

           DataTable dtLevSettl = objBusinessLeavSettlmt.ReadLeavSettlmt(objEntityLeavSettlmt);

           for (int intColumnBodyCountLev = 0; intColumnBodyCountLev < dtLevSettl.Rows.Count; intColumnBodyCountLev++)
           {
               if (dtLevSettl.Rows[intColumnBodyCountLev]["USR_ID"].ToString() == dtLeavDetail.Rows[0]["USR_ID"].ToString())
               {
                   imgAirptClose.Visible = false;
               }

           }


           //To check leave id rejoin table
           clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
           clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();

           objEntLevAllocn.EmployeeId = objEntityLeaveRequest.User_Id;

           hiddenCurrentDate2.Value = "01-01-2019";// strCurrentDate;
           DataTable DtUser_CurrDate = objBusLevAllocn.ReadUserDetailsGnUser(objEntLevAllocn);
           if (DtUser_CurrDate.Rows.Count > 0)
           {
               DateTime dtLast_mnt_sal_processed = objCommon.textToDateTime("01-01-2019");
               DateTime dtLast_leave_settled_dt = objCommon.textToDateTime("01-01-2019");

               if (DtUser_CurrDate.Rows[0]["LAST_LEAVE_SETTLED_DT"].ToString() != "")
               {
                   dtLast_leave_settled_dt = objCommon.textToDateTime(DtUser_CurrDate.Rows[0]["LAST_LEAVE_SETTLED_DT"].ToString());

               }

               if (DtUser_CurrDate.Rows[0]["LAST_MNT_SAL_PROCESSED"].ToString() != "")
               {
                   dtLast_mnt_sal_processed = objCommon.textToDateTime(DtUser_CurrDate.Rows[0]["LAST_MNT_SAL_PROCESSED"].ToString());
               }
               if (dtLast_leave_settled_dt > dtLast_mnt_sal_processed)
               {
                   hiddenCurrentDate2.Value = dtLast_leave_settled_dt.ToString("dd-MM-yyyy");

               }
               else if (dtLast_leave_settled_dt < dtLast_mnt_sal_processed)
               {
                   hiddenCurrentDate2.Value = dtLast_mnt_sal_processed.ToString("dd-MM-yyyy");

               }
               else if (dtLast_leave_settled_dt == dtLast_mnt_sal_processed)
               {
                   hiddenCurrentDate2.Value = dtLast_mnt_sal_processed.ToString("dd-MM-yyyy");
               }

           }




           objEntLevAllocn.LeavAllocn = Convert.ToInt32(strWId);




           DataTable dtRejoin = objBusLevAllocn.ReadRejoin(objEntLevAllocn);
           if (dtLeavDetail.Rows[0]["LEAVE_RQST_STATUS"].ToString() == "4" && dtRejoin.Rows.Count==0)
            {
                HiddenFieldShowCancel.Value = "true";
            }
            else
            {
                HiddenFieldShowCancel.Value = "false";
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

              if (ddlLeavTyp.Items.FindByValue(dtLeavDetail.Rows[0]["LEAVETYP_ID"].ToString()) != null)
                 {
            //if (dtLeavDetail.Rows[0]["LEAVETYP_ID"].ToString() != "" && dtLeavDetail.Rows[0]["LEAVETYP_STATUS"].ToString() == "1" && dtLeavDetail.Rows[0]["LEAVETYP_CNCL_USR_ID"].ToString() == "")
            //{
                //ddlLeavTyp.Items.FindByValue(dtLeavDetail.Rows[0]["LEAVETYP_ID"].ToString()).Selected = true;
            }
            else
            {

                ListItem lstGrp = new ListItem(dtLeavDetail.Rows[0]["LEAVETYP_NAME"].ToString(), dtLeavDetail.Rows[0]["LEAVETYP_ID"].ToString());
                ddlLeavTyp.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlLeavTyp);

                ddlLeavTyp.Items.FindByValue(dtLeavDetail.Rows[0]["LEAVETYP_ID"].ToString()).Selected = true;
            }

              hiddenLeaveTypId.Value = dtLeavDetail.Rows[0]["LEAVETYP_ID"].ToString();

            txtDateFrom.Text = dtLeavDetail.Rows[0]["LEAVE_FROM_DATE"].ToString();
            objEntityLeaveRequest.LeaveFrmDate = objCommon.textToDateTime(dtLeavDetail.Rows[0]["LEAVE_FROM_DATE"].ToString());
            ddlSecnFrom.Items.FindByValue(dtLeavDetail.Rows[0]["LEAVE_FROM_SCTN"].ToString()).Selected = true;
            if (cbxStatus.Checked == true)
            {
                TextDateTo.Text = dtLeavDetail.Rows[0]["LEAVE_TO_DATE"].ToString();
                objEntityLeaveRequest.LeaveToDate = objCommon.textToDateTime(dtLeavDetail.Rows[0]["LEAVE_TO_DATE"].ToString());
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
            NumOfLev.Text = dtLeavDetail.Rows[0]["LEAVE_NUM_DAYS"].ToString();
            hiddennoofleave.Value = dtLeavDetail.Rows[0]["LEAVE_NUM_DAYS"].ToString();
            txtLvDesc.Text = dtLeavDetail.Rows[0]["LEAVE_RQST_DESC"].ToString();    //EMP25
            if (dtLeavDetail.Rows[0]["LEAVE_TRVL_STS"].ToString() == "0")
            {
                HiddenTrvlSts.Value = "0";
                cbxTrvlSts.Checked = true;
            }
            else
            {
                HiddenTrvlSts.Value = "1";
                cbxTrvlSts.Checked = false;
            }
            objEntityLeaveRequest.Leave_Id = Convert.ToInt32(dtLeavDetail.Rows[0]["LEAVETYP_ID"].ToString());
            if (cbxStatus.Checked == false)
            {
                string strremLeav = "";
                DataTable dataDt = objBusinessLeaveRequest.ReadRemLeav(objEntityLeaveRequest);

                if (dataDt.Rows.Count > 0)
                {
                    strremLeav = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                    hiddenFrmRem.Value = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                    hiddenremngNxtyrLv.Value = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                    hiddenOpeningLev.Value = dataDt.Rows[0]["OPENING_NUMLEAVE"].ToString();
                    //YearlyLev.Text = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
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
                    DataTable dataDt = objBusinessLeaveRequest.ReadRemLeav(objEntityLeaveRequest);

                    if (dataDt.Rows.Count > 0)
                    {
                        strremLeav = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                        hiddenFrmRem.Value = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                        hiddenremngNxtyrLv.Value = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                        hiddenOpeningLev.Value = dataDt.Rows[0]["OPENING_NUMLEAVE"].ToString();
                        //YearlyLev.Text = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
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
                    DataTable dataDt = objBusinessLeaveRequest.ReadRemLeav(objEntityLeaveRequest);

                    if (dataDt.Rows.Count > 0)
                    {
                        strremLeavFrm = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                        hiddenFrmRem.Value = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                        hiddenOpeningLev.Value = dataDt.Rows[0]["OPENING_NUMLEAVE"].ToString();
                        //YearlyLev.Text = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                    }
                    if (strremLeavFrm != "")
                    {
                        decYrlyLevFrm = Convert.ToDecimal(strremLeavFrm);
                    }
                    else
                    {
                        decYrlyLevFrm = Convert.ToInt32(dataDt.Rows[0]["OPENING_NUMLEAVE"].ToString());
                    }
                    objEntityLeaveRequest.LeaveFrmDate = objEntityLeaveRequest.LeaveToDate;
                    DataTable dataDtt = objBusinessLeaveRequest.ReadRemLeav(objEntityLeaveRequest);

                    if (dataDtt.Rows.Count > 0)
                    {
                        strremLeavTo = dataDtt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                        hiddenToRem.Value = dataDtt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                        hiddenOpeningLev.Value = dataDtt.Rows[0]["OPENING_NUMLEAVE"].ToString();
                        //YearlyLev.Text = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
                    }
                    if (strremLeavTo != "")
                    {
                        decYrlyLevTo = Convert.ToDecimal(strremLeavTo);
                    }
                    else
                    {
                        decYrlyLevTo = Convert.ToDecimal(dataDtt.Rows[0]["OPENING_NUMLEAVE"].ToString());
                    }
                    decTotalYr = decYrlyLevFrm + decYrlyLevTo;
                    // intTotalYr = intTotalYr;
                    YearlyLev.Text = decTotalYr.ToString();
                }
            }

            if (hiddenRoleReOpen.Value != "")
            {
                if (hiddenRoleReOpen.Value == "1")
                {

                    if (dtLeavDetail.Rows[0]["LEAVE_CNFRM_STS"].ToString() == "1" ||  HiddenFieldExpiredSts.Value == "Exp")
                    {
                        HiddenFieldConfirm.Value = "1";
                        ddlLeavTyp.Enabled = false;
                        txtDateFrom.Enabled = false;
                        ddlSecnFrom.Enabled = false;
                        cbxStatus.Enabled = false;
                        TextDateTo.Enabled = false;
                        ddlSecTo.Enabled = false;
                        img1.Disabled = true;
                        imgDate.Disabled = true;
                        //For travel details
                        txtDateTrvl.Enabled = false;
                        Image1.Disabled = true;
                        txtDestntn.Enabled = false;
                        txtDateRetrn.Enabled = false;
                        Image2.Disabled = true;
                        txtAirLine.Enabled = false;
                        txtAddrss.Enabled = false;
                        txtTelNo.Enabled = false;
                        txtLclCntctNo.Enabled = false;
                        txtEmail.Enabled = false;
                        txtCmnt.Enabled = false;
                        cbxNeedTckt.Enabled = false;
                        txtLvDesc.Enabled = false;
                        cbxTrvlSts.Enabled = false;
                    }
                    else
                    {

                    }
                }
                else
                {
                    if (dtLeavDetail.Rows[0]["LEAVE_CNFRM_STS"].ToString() == "1" || HiddenFieldExpiredSts.Value == "Exp")
                    {
                        HiddenFieldConfirm.Value = "1";
                        ddlLeavTyp.Enabled = false;
                        txtDateFrom.Enabled = false;
                        ddlSecnFrom.Enabled = false;
                        cbxStatus.Enabled = false;
                        TextDateTo.Enabled = false;
                        ddlSecTo.Enabled = false;
                        img1.Disabled = true;
                        imgDate.Disabled = true;
                        //For travel details
                        txtDateTrvl.Enabled = false;
                        Image1.Disabled = true;
                        txtDestntn.Enabled = false;
                        txtDateRetrn.Enabled = false;
                        Image2.Disabled = true;
                        txtAirLine.Enabled = false;
                        txtAddrss.Enabled = false;
                        txtTelNo.Enabled = false;
                        txtLclCntctNo.Enabled = false;
                        txtEmail.Enabled = false;
                        txtCmnt.Enabled = false;
                        cbxNeedTckt.Enabled = false;
                        txtLvDesc.Enabled = false;
                        cbxTrvlSts.Enabled = false;
                    }

                }

            }
            //Start:-For travel details display
            if (dtLeavDetail.Rows[0]["DATE_TRVL"].ToString() != "")
            {
               HiddenFieldTrvlDtlsVisible.Value = "true";
               txtDateTrvl.Text = dtLeavDetail.Rows[0]["DATE_TRVL"].ToString();
               txtDateRetrn.Text = dtLeavDetail.Rows[0]["DATE_RETRN"].ToString();
               txtDestntn.Text = dtLeavDetail.Rows[0]["LEAVE_DESTINTN"].ToString();
               txtAirLine.Text = dtLeavDetail.Rows[0]["LEAVE_AIRLINE_PRFRD"].ToString();
               txtAddrss.Text = dtLeavDetail.Rows[0]["LEAVE_CNTCT_ADDRS"].ToString();
               txtTelNo.Text = dtLeavDetail.Rows[0]["LEAVE_CNTCT_TEL_NO"].ToString();
               txtLclCntctNo.Text = dtLeavDetail.Rows[0]["LEAVE_LCL_CNTCT_NO"].ToString();
               txtEmail.Text = dtLeavDetail.Rows[0]["LEAVE_EMAIL"].ToString();
               txtCmnt.Text = dtLeavDetail.Rows[0]["LEAVE_COMMENT"].ToString();
               if (dtLeavDetail.Rows[0]["LEAVE_NEED_TRVL_TCKT"].ToString() == "1")
               {
                   cbxNeedTckt.Checked = true;
               }
            }
           //End:-For travel details display

        }


        if (hiddenRoleConfirm.Value == "1")
        {

            if (dtLeavDetail.Rows[0]["LEAVE_CNFRM_STS"].ToString() == "1" || HiddenFieldExpiredSts.Value == "Exp")
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
            if (dtLeavDetail.Rows[0]["LEAVE_CNFRM_STS"].ToString() == "1" || HiddenFieldExpiredSts.Value == "Exp")
            {
                btnConfirm.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
            }
            else
            {
                btnConfirm.Visible = true;
                btnUpdate.Visible = true;
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
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Leave_Request);
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
            if (dtLeavDetail.Rows[0]["LEAVE_CNFRM_STS"].ToString() == "1" || HiddenFieldExpiredSts.Value == "Exp")
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
        public string CheckDutyOff(DateTime dateCheck,string orgid,string corpid)
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


                //Start:-EMP-0009
                DateTime now1 = new DateTime();
                now1 = now.AddDays(6);

                foreach (DataRow Rowd in dtDutyOffMonthly.Rows)
                {
                    if (Rowd["OFFDUTYDTL_DAYS"].ToString() != "")
                    {
                        int firstdate = 0;


                        //First two
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
                                    firstdate = 8;
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
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstMonday = FirstMonday.AddDays(1);
                                                    }
                                                }

                                                if (now.Month < now1.Month || now.Year < now1.Year)
                                                {
                                                    FirstMonday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < 7; count++)
                                                    {
                                                        if (FirstMonday.DayOfWeek == DayOfWeek.Monday)
                                                        {
                                                            leaveDate = FirstMonday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstMonday = FirstMonday.AddDays(1);
                                                        }
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
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstTuesday = FirstTuesday.AddDays(1);
                                                    }
                                                }
                                                if (now.Month < now1.Month || now.Year < now1.Year)
                                                {

                                                    FirstTuesday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < 7; count++)
                                                    {
                                                        if (FirstTuesday.DayOfWeek == DayOfWeek.Tuesday)
                                                        {

                                                            leaveDate = FirstTuesday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstTuesday = FirstTuesday.AddDays(1);
                                                        }
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
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstWednesday = FirstWednesday.AddDays(1);
                                                    }
                                                }

                                                if (now.Month < now1.Month || now.Year < now1.Year)
                                                {
                                                    FirstWednesday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < 7; count++)
                                                    {
                                                        if (FirstWednesday.DayOfWeek == DayOfWeek.Wednesday)
                                                        {
                                                            leaveDate = FirstWednesday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstWednesday = FirstWednesday.AddDays(1);
                                                        }
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
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstThursday = FirstThursday.AddDays(1);
                                                    }
                                                }
                                                if (now.Month < now1.Month || now.Year < now1.Year)
                                                {
                                                    FirstThursday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < 7; count++)
                                                    {
                                                        if (FirstThursday.DayOfWeek == DayOfWeek.Thursday)
                                                        {
                                                            leaveDate = FirstThursday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstThursday = FirstThursday.AddDays(1);
                                                        }
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
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstFriday = FirstFriday.AddDays(1);
                                                    }
                                                }

                                                if (now.Month < now1.Month || now.Year < now1.Year)
                                                {
                                                    FirstFriday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < 7; count++)
                                                    {
                                                        if (FirstFriday.DayOfWeek == DayOfWeek.Friday)
                                                        {
                                                            leaveDate = FirstFriday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstFriday = FirstFriday.AddDays(1);
                                                        }
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
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstSaturday = FirstSaturday.AddDays(1);
                                                    }
                                                }


                                                if (now.Month < now1.Month || now.Year < now1.Year)
                                                {

                                                    FirstSaturday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < 7; count++)
                                                    {
                                                        if (FirstSaturday.DayOfWeek == DayOfWeek.Saturday)
                                                        {
                                                            leaveDate = FirstSaturday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstSaturday = FirstSaturday.AddDays(1);
                                                        }
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
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstSunday = FirstSunday.AddDays(1);
                                                    }
                                                }

                                                if (now.Month < now1.Month || now.Year < now1.Year)
                                                {
                                                    FirstSunday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < 7; count++)
                                                    {
                                                        if (FirstSunday.DayOfWeek == DayOfWeek.Sunday)
                                                        {
                                                            leaveDate = FirstSunday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstSunday = FirstSunday.AddDays(1);
                                                        }
                                                    }
                                                }
                                                break;
                                        }
                                    }

                                }
                            }

                        }


                        //Last two

                        if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() == "3")
                        {


                            for (int i = 0; i <= 1; i++)
                            {
                                if (i == 0)
                                {
                                    firstdate = DateTime.DaysInMonth(now.Year, now.Month);
                                }
                                else if (i == 1)
                                {
                                    firstdate = DateTime.DaysInMonth(now.Year, now.Month) - 7;
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
                                                        FirstMonday = FirstMonday.AddDays(-1);
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
                                                        FirstTuesday = FirstTuesday.AddDays(-1);
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
                                                        FirstWednesday = FirstWednesday.AddDays(-1);
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
                                                        FirstThursday = FirstThursday.AddDays(-1);
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
                                                        FirstFriday = FirstFriday.AddDays(-1);
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
                                                        FirstSaturday = FirstSaturday.AddDays(-1);
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
                                                        FirstSunday = FirstSunday.AddDays(-1);
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


                //End:EMP-0009



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
                                    firstdate = DateTime.DaysInMonth(now.Year, now.Month);
                                    if (firstdate == 28)
                                    {
                                        break;
                                    }
                                    firstdate = 29;
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
                            int lastWeekDays = DateTime.DaysInMonth(now.Year, now.Month);
                            lastWeekDays = lastWeekDays - 28;
                            int limit = 7;

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

                                    limit = lastWeekDays;

                                    if (now.Month == 2)
                                    {
                                        if ((now.Year % 4 == 0 && now.Year % 100 != 0) || (now.Year % 400 == 0))
                                        {
                                            firstdate = 29;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        firstdate = 29;
                                    }

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
                                                for (int count = 0; count < limit; count++)
                                                {
                                                    if (FirstMonday.DayOfWeek == DayOfWeek.Monday)
                                                    {
                                                        leaveDate = FirstMonday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstMonday = FirstMonday.AddDays(1);
                                                    }
                                                }

                                                if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() != "8" && (now.Month < now1.Month || now.Year < now1.Year))
                                                {
                                                    FirstMonday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < limit; count++)
                                                    {
                                                        if (FirstMonday.DayOfWeek == DayOfWeek.Monday)
                                                        {
                                                            leaveDate = FirstMonday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstMonday = FirstMonday.AddDays(1);
                                                        }
                                                    }
                                                }
                                                break;
                                            case "3":
                                                DateTime FirstTuesday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < limit; count++)
                                                {
                                                    if (FirstTuesday.DayOfWeek == DayOfWeek.Tuesday)
                                                    {

                                                        leaveDate = FirstTuesday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstTuesday = FirstTuesday.AddDays(1);
                                                    }
                                                }
                                                if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() != "8" && (now.Month < now1.Month || now.Year < now1.Year))
                                                {
                                                    FirstTuesday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < limit; count++)
                                                    {
                                                        if (FirstTuesday.DayOfWeek == DayOfWeek.Tuesday)
                                                        {

                                                            leaveDate = FirstTuesday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstTuesday = FirstTuesday.AddDays(1);
                                                        }
                                                    }
                                                }
                                                break;
                                            case "4":
                                                DateTime FirstWednesday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < limit; count++)
                                                {
                                                    if (FirstWednesday.DayOfWeek == DayOfWeek.Wednesday)
                                                    {
                                                        leaveDate = FirstWednesday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstWednesday = FirstWednesday.AddDays(1);
                                                    }
                                                }

                                                if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() != "8" && (now.Month < now1.Month || now.Year < now1.Year))
                                                {
                                                    FirstWednesday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < limit; count++)
                                                    {
                                                        if (FirstWednesday.DayOfWeek == DayOfWeek.Wednesday)
                                                        {
                                                            leaveDate = FirstWednesday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstWednesday = FirstWednesday.AddDays(1);
                                                        }
                                                    }
                                                }
                                                break;
                                            case "5":
                                                DateTime FirstThursday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < limit; count++)
                                                {
                                                    if (FirstThursday.DayOfWeek == DayOfWeek.Thursday)
                                                    {
                                                        leaveDate = FirstThursday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstThursday = FirstThursday.AddDays(1);
                                                    }
                                                }
                                                if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() != "8" && (now.Month < now1.Month || now.Year < now1.Year))
                                                {
                                                    FirstThursday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < limit; count++)
                                                    {
                                                        if (FirstThursday.DayOfWeek == DayOfWeek.Thursday)
                                                        {
                                                            leaveDate = FirstThursday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstThursday = FirstThursday.AddDays(1);
                                                        }
                                                    }
                                                }
                                                break;
                                            case "6":
                                                DateTime FirstFriday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < limit; count++)
                                                {
                                                    if (FirstFriday.DayOfWeek == DayOfWeek.Friday)
                                                    {
                                                        leaveDate = FirstFriday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstFriday = FirstFriday.AddDays(1);
                                                    }
                                                }
                                                if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() != "8" && (now.Month < now1.Month || now.Year < now1.Year))
                                                {
                                                    FirstFriday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < limit; count++)
                                                    {
                                                        if (FirstFriday.DayOfWeek == DayOfWeek.Friday)
                                                        {
                                                            leaveDate = FirstFriday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstFriday = FirstFriday.AddDays(1);
                                                        }
                                                    }
                                                }
                                                break;
                                            case "7":

                                                DateTime FirstSaturday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < limit; count++)
                                                {
                                                    if (FirstSaturday.DayOfWeek == DayOfWeek.Saturday)
                                                    {
                                                        leaveDate = FirstSaturday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstSaturday = FirstSaturday.AddDays(1);
                                                    }
                                                }
                                                if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() != "8" && (now.Month < now1.Month || now.Year < now1.Year))
                                                {
                                                    FirstSaturday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < limit; count++)
                                                    {
                                                        if (FirstSaturday.DayOfWeek == DayOfWeek.Saturday)
                                                        {
                                                            leaveDate = FirstSaturday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstSaturday = FirstSaturday.AddDays(1);
                                                        }
                                                    }
                                                }
                                                break;
                                            case "1":
                                                DateTime FirstSunday = new DateTime(now.Year, now.Month, firstdate);
                                                for (int count = 0; count < limit; count++)
                                                {
                                                    if (FirstSunday.DayOfWeek == DayOfWeek.Sunday)
                                                    {
                                                        leaveDate = FirstSunday;
                                                        if (leaveDate != DateTime.MinValue)
                                                        {
                                                            MonthlyOffDates.Add(leaveDate);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        FirstSunday = FirstSunday.AddDays(1);
                                                    }
                                                }
                                                if (Rowd["MN_OFFDUTY_TYP_ID"].ToString() != "8" && (now.Month < now1.Month || now.Year < now1.Year))
                                                {
                                                    FirstSunday = new DateTime(now1.Year, now1.Month, firstdate);
                                                    for (int count = 0; count < limit; count++)
                                                    {
                                                        if (FirstSunday.DayOfWeek == DayOfWeek.Sunday)
                                                        {
                                                            leaveDate = FirstSunday;
                                                            if (leaveDate != DateTime.MinValue)
                                                            {
                                                                MonthlyOffDates.Add(leaveDate);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            FirstSunday = FirstSunday.AddDays(1);
                                                        }
                                                    }
                                                }
                                                break;
                                        }
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
    public static int ReadDutyofChkDateRanges(string strdateFm, string orgid, string corpid, string strdateTo)
    {
        int Count = 0;
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
        return Count;
    }
}