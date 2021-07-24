using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using CL_Compzit;
using System.Web.Services;
using BL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;

public partial class HCM_HCM_Master_hcm_LeaveMaster_hcm_Leave_Partial_Process : System.Web.UI.Page
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
            //creating object for business layer

            HiddenView.Value = "";
            clsEntity_Leave_PartialProcess objEntityLeavePartialPrcs = new clsEntity_Leave_PartialProcess();
            clsBusiness_Leave_PartialProcess objBusinessLeavePartialPrcs = new clsBusiness_Leave_PartialProcess();

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableClose = 0;

            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
            Hiddendate.Value = strCurrentDate;

            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Leave_Partial_Process);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString())
                    {
                        intEnableClose = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                }


                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityLeavePartialPrcs.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }

                if (Session["ORGID"] != null)
                {
                    objEntityLeavePartialPrcs.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }

                if (Session["USERID"] != null)
                {
                    objEntityLeavePartialPrcs.UserId = Convert.ToInt32(Session["USERID"]);
                    hiddenUserId.Value = Session["USERID"].ToString();
                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }


                if (Request.QueryString["Id"] != null)
                {
                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    HiddenFieldQryId.Value = strRandomMixedId;
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);
                    int intEmpId = Convert.ToInt32(strId);
                    hiddenEmpId.Value = strId;

                    objEntityLeavePartialPrcs.EmpId = intEmpId;

                    if (Request.QueryString["levId"] != null)
                    {
                        string strRandomMixedLevId = Request.QueryString["levId"].ToString();
                        HiddenFieldQrylevId.Value = strRandomMixedLevId;
                        string strLenghtoflevId = strRandomMixedLevId.Substring(0, 2);
                        int intLenghtoflevId = Convert.ToInt16(strLenghtoflevId);
                        string strLevId = strRandomMixedLevId.Substring(2, intLenghtoflevId);
                        int intLevId = Convert.ToInt32(strLevId);
                        HiddenFieldLevFcltyId.Value = strLevId;

                        objEntityLeavePartialPrcs.LeaveFacltyId = Convert.ToInt32(HiddenFieldLevFcltyId.Value);

                        //read employee details to labels

                        if (hiddenEmpId.Value != "")
                        {

                        DataTable dtEmpDtls = new DataTable();
                        dtEmpDtls = objBusinessLeavePartialPrcs.ReadEmpDtlsByLevId(objEntityLeavePartialPrcs);



                        lblName.Text = dtEmpDtls.Rows[0]["USR_NAME"].ToString();
                        lblDesgntn.Text = dtEmpDtls.Rows[0]["DSGN_NAME"].ToString();

                        DataTable dtEmpDiv = new DataTable();
                        dtEmpDiv = objBusinessLeavePartialPrcs.ReadDivsnEmp(objEntityLeavePartialPrcs);

                        string strEmpDiv = "";
                        string[] DivData = new string[7];
                        if (dtEmpDiv.Rows.Count > 0)
                        {
                            foreach (DataRow dtrow in dtEmpDiv.Rows)
                            {
                                strEmpDiv = dtrow["CPRDIV_NAME"] + " , " + strEmpDiv;
                            }
                        }
                        DivData[0] = strEmpDiv.TrimEnd(" , ".ToCharArray());

                        lblDivsn.Text = DivData[0];

                        lblDept.Text = dtEmpDtls.Rows[0]["CPRDEPT_NAME"].ToString();
                        lblNation.Text = dtEmpDtls.Rows[0]["CNTRY_NAME"].ToString();

                        if (dtEmpDtls.Rows[0]["STAFF_WORKER"].ToString() == "0")
                            lblMode.Text = "STAFF";
                        else if (dtEmpDtls.Rows[0]["STAFF_WORKER"].ToString() == "1")
                            lblMode.Text = "WORKER";

                    }

                        //read assigned tabs

                        objEntityLeavePartialPrcs.EmpId = Convert.ToInt32(hiddenEmpId.Value);

                        string userId = intUserId.ToString();

                        //read employee leave facility assignment statuses

                        DataTable dtEmpPrtclrDtls = new DataTable();
                        dtEmpPrtclrDtls = objBusinessLeavePartialPrcs.ReadallAssignstatus(objEntityLeavePartialPrcs);


                        if (dtEmpPrtclrDtls.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtEmpPrtclrDtls.Rows.Count; i++)
                            {

                                //ticket status

                                if (dtEmpPrtclrDtls.Rows[i]["LEVFCLTYPRTCLR_ID"].ToString() == "0")
                                {
                                    if (userId == dtEmpPrtclrDtls.Rows[i]["EMPUSRID"].ToString())
                                    {
                                        Hiddenprtclridtickt.Value = "true";
                                    }

                                    Hidddentiketneeded.Value = "1";

                                    lblTicktTrgtDate.Text = dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_DATE"].ToString();
                                    if (ddlTicktSts.Items.FindByValue(dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_TICKET_STATUS"].ToString()) != null)
                                    {
                                        ddlTicktSts.Items.FindByValue(dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_TICKET_STATUS"].ToString()).Selected = true;
                                    }

                                    HiddenFieldTicktEmpDtlId.Value = dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_ID"].ToString();
                                    HiddenFieldTicktSts.Value = dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_TICKET_STATUS"].ToString();
                                    HiddenFieldTicketTrgtDate.Value = dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_DATE"].ToString();
                                    HiddenFieldTicktFinishSts.Value = dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_FNSH_STS"].ToString();
                                    HiddenFieldTicktCloseSts.Value = dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_CLOSE_STS"].ToString();

                                    if (dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_CLOSE_STS"].ToString() == "1")
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "TicktDisbld", "TicktDisbld();", true);
                                        ScriptManager.RegisterStartupScript(this, GetType(), "SettlmtDisbld", "SettlmtDisbld();", true);
                                        ScriptManager.RegisterStartupScript(this, GetType(), "ExitPrcsDisbld", "ExitPrcsDisbld();", true);
                                    }

                                    if (dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_FNSH_STS"].ToString() == "1")
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "TicktDisbld", "TicktDisbld();", true);
                                    }

                                }

                                //settlmt status

                                else if (dtEmpPrtclrDtls.Rows[i]["LEVFCLTYPRTCLR_ID"].ToString() == "2")
                                {

                                    if (userId == dtEmpPrtclrDtls.Rows[i]["EMPUSRID"].ToString())
                                    {
                                        Hiddenprtclridsettlmt.Value = "true";
                                    }

                                    lblSettlmtTrgtDate.Text = dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_DATE"].ToString();
                                    if (ddlSettlmtStatus.Items.FindByValue(dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_SETTLEMENT_STATUS"].ToString()) != null)
                                    {
                                        ddlSettlmtStatus.Items.FindByValue(dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_SETTLEMENT_STATUS"].ToString()).Selected = true;
                                    }

                                    HiddenFieldSettlmtEmpDtlId.Value = dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_ID"].ToString();
                                    HiddenFieldSettlmtSts.Value = dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_SETTLEMENT_STATUS"].ToString();
                                    HiddenFieldSettlmtTrgtDate.Value = dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_DATE"].ToString();
                                    HiddenFieldSettlmtFinishSts.Value = dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_FNSH_STS"].ToString();
                                    HiddenFieldSettlmtCloseSts.Value = dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_CLOSE_STS"].ToString();

                                    if (dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_CLOSE_STS"].ToString() == "1")
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "TicktDisbld", "TicktDisbld();", true);
                                        ScriptManager.RegisterStartupScript(this, GetType(), "SettlmtDisbld", "SettlmtDisbld();", true);
                                        ScriptManager.RegisterStartupScript(this, GetType(), "ExitPrcsDisbld", "ExitPrcsDisbld();", true);
                                    }

                                    if (dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_FNSH_STS"].ToString() == "1")
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "SettlmtDisbld", "SettlmtDisbld();", true);
                                    }


                                }

                                //exit prcs status

                                else if (dtEmpPrtclrDtls.Rows[i]["LEVFCLTYPRTCLR_ID"].ToString() == "3")
                                {
                                    if (userId == dtEmpPrtclrDtls.Rows[i]["EMPUSRID"].ToString())
                                    {
                                        Hiddenprtclridexit.Value = "true";
                                    }

                                    lblExitTrgtDate.Text = dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_DATE"].ToString();
                                    if (ddlExitSts.Items.FindByValue(dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_EXITPROCESS_STATUS"].ToString()) != null)
                                    {
                                        ddlExitSts.Items.FindByValue(dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_EXITPROCESS_STATUS"].ToString()).Selected = true;
                                    }

                                    HiddenFieldExitEmpDtlId.Value = dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_ID"].ToString();
                                    HiddenFieldExitSts.Value = dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_EXITPROCESS_STATUS"].ToString();
                                    HiddenFieldExitTrgtDate.Value = dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_DATE"].ToString();
                                    HiddenFieldExitFinishSts.Value = dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_FNSH_STS"].ToString();
                                    HiddenFieldExitCloseSts.Value = dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_CLOSE_STS"].ToString();

                                    if (dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_CLOSE_STS"].ToString() == "1")
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "TicktDisbld", "TicktDisbld();", true);
                                        ScriptManager.RegisterStartupScript(this, GetType(), "SettlmtDisbld", "SettlmtDisbld();", true);
                                        ScriptManager.RegisterStartupScript(this, GetType(), "ExitPrcsDisbld", "ExitPrcsDisbld();", true);
                                    }

                                    if (dtEmpPrtclrDtls.Rows[i]["LEVFCLTYDTL_FNSH_STS"].ToString() == "1")
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "ExitPrcsDisbld", "ExitPrcsDisbld();", true);
                                    }
                                }

                            }
                        }
                    }
                    if (Request.QueryString["RFGP"] != null)
                    {
                        //btnCancel.Visible = false;
                        HiddenView.Value = "1";
                        divList.Visible = false;
                        btnCancelSettlmt.Visible = false;
                        btnCanceExit.Visible = false;
                        btnCancelTickt.Visible = false;
                    }
                }
            }


            if (Request.QueryString["Ins"] != null)
            {

                string strInsUpd = Request.QueryString["Ins"].ToString();
                if (strInsUpd == "InsTickt")
                {
                    hiddenfromdiv.Value = "1";
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessAddTickt", "SuccessAddTickt();", true);
                }
                if (strInsUpd == "InsSettlmt")
                {
                    hiddenfromdiv.Value = "2";
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessAddSettlmt", "SuccessAddSettlmt();", true);
                }
                if (strInsUpd == "InsExit")
                {
                    hiddenfromdiv.Value = "3";
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessAddExit", "SuccessAddExit();", true);
                }
            }



        }
    }


    protected void btnAddTickt_Click(object sender, EventArgs e)
    {
        //updating ticket status

        clsEntity_Leave_PartialProcess objEntityLeavePartialPrcs = new clsEntity_Leave_PartialProcess();
        clsBusiness_Leave_PartialProcess objBusinessLeavePartialPrcs = new clsBusiness_Leave_PartialProcess();

        clsCommonLibrary objCommon = new clsCommonLibrary();

        objEntityLeavePartialPrcs.LeaveDtlId = Convert.ToInt32(HiddenFieldTicktEmpDtlId.Value);

        objEntityLeavePartialPrcs.Date = System.DateTime.Now;
        objEntityLeavePartialPrcs.LeaveDtlStatus = Convert.ToInt32(ddlTicktSts.SelectedItem.Value);

        if (txtTicktExptdDate.Text != "")
        {
            objEntityLeavePartialPrcs.AsgndDate = objCommon.textToDateTime(txtTicktExptdDate.Text);
        }
        else
        {
            objEntityLeavePartialPrcs.AsgndDate = objCommon.textToDateTime(HiddenFieldTicketTrgtDate.Value);
        }

        objEntityLeavePartialPrcs.LeaveFacltyId=Convert.ToInt32(HiddenFieldLevFcltyId.Value);
        objEntityLeavePartialPrcs.EmpId = Convert.ToInt32(hiddenEmpId.Value);
        objEntityLeavePartialPrcs.UserId = Convert.ToInt32(hiddenUserId.Value);

        objBusinessLeavePartialPrcs.updTicktSts(objEntityLeavePartialPrcs);
        Response.Redirect("hcm_Leave_Partial_Process.aspx?Id=" + HiddenFieldQryId.Value + "&levId=" + HiddenFieldQrylevId.Value + "&Ins=InsTickt");
    }

    protected void btnAddSettlmt_Click(object sender, EventArgs e)
    {
        //updating settlmt status

        clsEntity_Leave_PartialProcess objEntityLeavePartialPrcs = new clsEntity_Leave_PartialProcess();
        clsBusiness_Leave_PartialProcess objBusinessLeavePartialPrcs = new clsBusiness_Leave_PartialProcess();

        clsCommonLibrary objCommon = new clsCommonLibrary();

        objEntityLeavePartialPrcs.LeaveDtlId = Convert.ToInt32(HiddenFieldSettlmtEmpDtlId.Value);

        objEntityLeavePartialPrcs.Date = System.DateTime.Now;
        objEntityLeavePartialPrcs.LeaveDtlStatus = Convert.ToInt32(ddlSettlmtStatus.SelectedItem.Value);

        if (txtSettlmtExptdDate.Text != "")
        {
            objEntityLeavePartialPrcs.AsgndDate = objCommon.textToDateTime(txtSettlmtExptdDate.Text);
        }
        else
        {
            objEntityLeavePartialPrcs.AsgndDate = objCommon.textToDateTime(HiddenFieldSettlmtTrgtDate.Value);
        }

        objEntityLeavePartialPrcs.LeaveFacltyId = Convert.ToInt32(HiddenFieldLevFcltyId.Value);
        objEntityLeavePartialPrcs.EmpId = Convert.ToInt32(hiddenEmpId.Value);
        objEntityLeavePartialPrcs.UserId = Convert.ToInt32(hiddenUserId.Value);

        objBusinessLeavePartialPrcs.updSettlmtSts(objEntityLeavePartialPrcs);
        Response.Redirect("hcm_Leave_Partial_Process.aspx?Id=" + HiddenFieldQryId.Value + "&levId=" + HiddenFieldQrylevId.Value + "&Ins=InsSettlmt");

    }

    protected void btnAddExit_Click(object sender, EventArgs e)
    {
        //updating exit process status

        clsEntity_Leave_PartialProcess objEntityLeavePartialPrcs = new clsEntity_Leave_PartialProcess();
        clsBusiness_Leave_PartialProcess objBusinessLeavePartialPrcs = new clsBusiness_Leave_PartialProcess();

        clsCommonLibrary objCommon = new clsCommonLibrary();

        objEntityLeavePartialPrcs.LeaveDtlId = Convert.ToInt32(HiddenFieldExitEmpDtlId.Value);

        objEntityLeavePartialPrcs.Date = System.DateTime.Now;
        objEntityLeavePartialPrcs.LeaveDtlStatus = Convert.ToInt32(ddlExitSts.SelectedItem.Value);

        if (txtExitExptdDate.Text != "")
        {
            objEntityLeavePartialPrcs.AsgndDate = objCommon.textToDateTime(txtExitExptdDate.Text);
        }
        else
        {
            objEntityLeavePartialPrcs.AsgndDate = objCommon.textToDateTime(HiddenFieldExitTrgtDate.Value);
        }

        objEntityLeavePartialPrcs.LeaveFacltyId = Convert.ToInt32(HiddenFieldLevFcltyId.Value);
        objEntityLeavePartialPrcs.EmpId = Convert.ToInt32(hiddenEmpId.Value);
        objEntityLeavePartialPrcs.UserId = Convert.ToInt32(hiddenUserId.Value);

        objBusinessLeavePartialPrcs.updExitSts(objEntityLeavePartialPrcs);
        Response.Redirect("hcm_Leave_Partial_Process.aspx?Id=" + HiddenFieldQryId.Value + "&levId=" + HiddenFieldQrylevId.Value + "&Ins=InsExit");

    }

    [WebMethod]
    public static string CloseTickt(int intleavFcltyId, int intleavDtlId,int intEmpId,int intUserId)
    {
        //close ticket status

        clsEntity_Leave_PartialProcess objEntityLeavePartialPrcs = new clsEntity_Leave_PartialProcess();
        clsBusiness_Leave_PartialProcess objBusinessLeavePartialPrcs = new clsBusiness_Leave_PartialProcess();

        string ret = "true";

        objEntityLeavePartialPrcs.LeaveDtlId = intleavDtlId;
        objEntityLeavePartialPrcs.LeaveFacltyId = intleavFcltyId;

        objEntityLeavePartialPrcs.Date = System.DateTime.Now;
        objEntityLeavePartialPrcs.PartclrId = 0;

        objEntityLeavePartialPrcs.EmpId = intEmpId;
        objEntityLeavePartialPrcs.UserId = intUserId;

        DataTable dtClsdOrFnshd = new DataTable();
        dtClsdOrFnshd = objBusinessLeavePartialPrcs.ReadFinishdOrClosd(objEntityLeavePartialPrcs);

        if (dtClsdOrFnshd.Rows.Count > 0)
        {
            ret = "false";
        }
        else
        {
            objBusinessLeavePartialPrcs.closeTicket(objEntityLeavePartialPrcs);
        }

        return ret;

    }

    [WebMethod]
    public static string CloseSettlmt(int intleavFcltyId, int intleavDtlId, int intEmpId, int intUserId)
    {
        //close settlement status

        clsEntity_Leave_PartialProcess objEntityLeavePartialPrcs = new clsEntity_Leave_PartialProcess();
        clsBusiness_Leave_PartialProcess objBusinessLeavePartialPrcs = new clsBusiness_Leave_PartialProcess();

        string ret = "true";

        objEntityLeavePartialPrcs.LeaveDtlId = intleavDtlId;
        objEntityLeavePartialPrcs.LeaveFacltyId = intleavFcltyId;

        objEntityLeavePartialPrcs.Date = System.DateTime.Now;
        objEntityLeavePartialPrcs.PartclrId = 2;

        objEntityLeavePartialPrcs.EmpId = intEmpId;
        objEntityLeavePartialPrcs.UserId = intUserId;

        DataTable dtClsdOrFnshd = new DataTable();
        dtClsdOrFnshd = objBusinessLeavePartialPrcs.ReadFinishdOrClosd(objEntityLeavePartialPrcs);

        if (dtClsdOrFnshd.Rows.Count > 0)
        {
            ret = "false";
        }
        else
        {
            objBusinessLeavePartialPrcs.closeSettlmt(objEntityLeavePartialPrcs);
        }
        return ret;

    }

    [WebMethod]
    public static string CloseExitPrcs(int intleavFcltyId, int intleavDtlId, int intEmpId, int intUserId)
    {
        //close exit process status

        clsEntity_Leave_PartialProcess objEntityLeavePartialPrcs = new clsEntity_Leave_PartialProcess();
        clsBusiness_Leave_PartialProcess objBusinessLeavePartialPrcs = new clsBusiness_Leave_PartialProcess();

        string ret = "true";

        objEntityLeavePartialPrcs.LeaveDtlId = intleavDtlId;
        objEntityLeavePartialPrcs.LeaveFacltyId = intleavFcltyId;

        objEntityLeavePartialPrcs.Date = System.DateTime.Now;
        objEntityLeavePartialPrcs.PartclrId = 3;

        objEntityLeavePartialPrcs.EmpId = intEmpId;
        objEntityLeavePartialPrcs.UserId = intUserId;

        DataTable dtClsdOrFnshd = new DataTable();
        dtClsdOrFnshd = objBusinessLeavePartialPrcs.ReadFinishdOrClosd(objEntityLeavePartialPrcs);

        if (dtClsdOrFnshd.Rows.Count > 0)
        {
            ret = "false";
        }
        else
        {
            objBusinessLeavePartialPrcs.closeExitPrcs(objEntityLeavePartialPrcs);
        }

        return ret;

    }

    [WebMethod]
    public static string FinishTickt(int intleavFcltyId, int intleavDtlId, int intEmpId, int intUserId)
    {
        //finish ticket status

        clsEntity_Leave_PartialProcess objEntityLeavePartialPrcs = new clsEntity_Leave_PartialProcess();
        clsBusiness_Leave_PartialProcess objBusinessLeavePartialPrcs = new clsBusiness_Leave_PartialProcess();

        string ret = "true";

        objEntityLeavePartialPrcs.LeaveDtlId = intleavDtlId;
        objEntityLeavePartialPrcs.LeaveFacltyId = intleavFcltyId;

        objEntityLeavePartialPrcs.Date = System.DateTime.Now;
        objEntityLeavePartialPrcs.PartclrId = 0;

        objEntityLeavePartialPrcs.EmpId = intEmpId;
        objEntityLeavePartialPrcs.UserId = intUserId;

        DataTable dtClsdOrFnshd = new DataTable();
        dtClsdOrFnshd = objBusinessLeavePartialPrcs.ReadFinishdOrClosd(objEntityLeavePartialPrcs);

        if (dtClsdOrFnshd.Rows.Count > 0)
        {
            ret = "false";
        }
        else
        {
            objBusinessLeavePartialPrcs.finishTicket(objEntityLeavePartialPrcs);
        }

        return ret;

    }

    [WebMethod]
    public static string FinishSettlmt(int intleavFcltyId, int intleavDtlId, int intEmpId, int intUserId)
    {
        //finish settlement status

        clsEntity_Leave_PartialProcess objEntityLeavePartialPrcs = new clsEntity_Leave_PartialProcess();
        clsBusiness_Leave_PartialProcess objBusinessLeavePartialPrcs = new clsBusiness_Leave_PartialProcess();

        string ret = "true";

        objEntityLeavePartialPrcs.LeaveDtlId = intleavDtlId;
        objEntityLeavePartialPrcs.LeaveFacltyId = intleavFcltyId;

        objEntityLeavePartialPrcs.Date = System.DateTime.Now;
        objEntityLeavePartialPrcs.PartclrId = 2;

        objEntityLeavePartialPrcs.EmpId = intEmpId;
        objEntityLeavePartialPrcs.UserId = intUserId;

        DataTable dtClsdOrFnshd = new DataTable();
        dtClsdOrFnshd = objBusinessLeavePartialPrcs.ReadFinishdOrClosd(objEntityLeavePartialPrcs);

        if (dtClsdOrFnshd.Rows.Count > 0)
        {
            ret = "false";
        }
        else
        {
            objBusinessLeavePartialPrcs.finishSettlmt(objEntityLeavePartialPrcs);
        }

        return ret;

    }

    [WebMethod]
    public static string FinishExitPrcs(int intleavFcltyId, int intleavDtlId, int intEmpId, int intUserId)
    {
        //finish exit process status

        clsEntity_Leave_PartialProcess objEntityLeavePartialPrcs = new clsEntity_Leave_PartialProcess();
        clsBusiness_Leave_PartialProcess objBusinessLeavePartialPrcs = new clsBusiness_Leave_PartialProcess();

        string ret = "true";

        objEntityLeavePartialPrcs.LeaveDtlId = intleavDtlId;
        objEntityLeavePartialPrcs.LeaveFacltyId = intleavFcltyId;

        objEntityLeavePartialPrcs.Date = System.DateTime.Now;
        objEntityLeavePartialPrcs.PartclrId = 3;

        objEntityLeavePartialPrcs.EmpId = intEmpId;
        objEntityLeavePartialPrcs.UserId = intUserId;

        DataTable dtClsdOrFnshd = new DataTable();
        dtClsdOrFnshd = objBusinessLeavePartialPrcs.ReadFinishdOrClosd(objEntityLeavePartialPrcs);

        if (dtClsdOrFnshd.Rows.Count > 0)
        {
            ret = "false";
        }
        else
        {
            objBusinessLeavePartialPrcs.finishExitPrcs(objEntityLeavePartialPrcs);
        }

        return ret;

    }









}