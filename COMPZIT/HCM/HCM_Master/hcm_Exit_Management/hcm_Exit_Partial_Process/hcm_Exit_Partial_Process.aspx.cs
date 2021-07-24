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

public partial class HCM_HCM_Master_hcm_Exit_Management_hcm_Exit_Partial_Process_hcm_Exit_Partial_Process : System.Web.UI.Page
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
            HiddenView.Value = "";
            //creating object for business layer


            clsEntityLayerExitPartialProcess objEntityExitPartialProcess = new clsEntityLayerExitPartialProcess();
            clsBusinessLayerExitPartialProcess objBusinessExitPartialProcess = new clsBusinessLayerExitPartialProcess();

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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Exit_Partial_Process);
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
                    objEntityExitPartialProcess.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }

                if (Session["ORGID"] != null)
                {
                    objEntityExitPartialProcess.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }

                if (Session["USERID"] != null)
                {
                    objEntityExitPartialProcess.UserId = Convert.ToInt32(Session["USERID"]);
                    hiddenUserId.Value = Session["USERID"].ToString();
                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }


                if (Request.QueryString["Id"] != null && Request.QueryString["Usr"] != null)
                {
                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    HiddenFieldQryId.Value = strRandomMixedId;
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);
                    int intExitProcdureID = Convert.ToInt32(strId);

                    HiddenExitProcdureID.Value = strId;

                    string strRandomMixedEmpID = Request.QueryString["Usr"].ToString();
                    string strLenghtofEmpID = strRandomMixedEmpID.Substring(0, 2);
                    int intLenghtofEmpID = Convert.ToInt16(strLenghtofEmpID);
                    string strEmpID = strRandomMixedEmpID.Substring(2, intLenghtofEmpID);
                    int intEmpId = Convert.ToInt32(strEmpID);

                     objEntityExitPartialProcess.EmpId = intEmpId;




                    objEntityExitPartialProcess.ExitProcdureID = intExitProcdureID;


                    DataTable dtEmpDtlsById = new DataTable();
                    dtEmpDtlsById = objBusinessExitPartialProcess.ReadEmpDtlsById(objEntityExitPartialProcess);
                    if (dtEmpDtlsById.Rows.Count > 0)
                    {
                        //objEntityExitPartialProcess.EmpId = Convert.ToInt32(dtEmpDtlsById.Rows[0]["USR_ID"]);
                        lblEmpName.Text = dtEmpDtlsById.Rows[0]["USR_NAME"].ToString();
                        lblDesgntn.Text = dtEmpDtlsById.Rows[0]["DSGN_NAME"].ToString();
                        lblDept.Text = dtEmpDtlsById.Rows[0]["CPRDEPT_NAME"].ToString();

                    }
                    DataTable dtDivEmp = new DataTable();
                    dtDivEmp = objBusinessExitPartialProcess.ReadDivsnEmp(objEntityExitPartialProcess);
                    if (dtDivEmp.Rows.Count > 0)
                    {

                        string strDivsn = "";
                        for (int intRowCount = 0; intRowCount < dtDivEmp.Rows.Count; intRowCount++)
                        {
                            if (strDivsn == "")
                            {
                                strDivsn = dtDivEmp.Rows[intRowCount]["CPRDIV_NAME"].ToString();
                            }
                            else
                            {
                                strDivsn = strDivsn + ", " + dtDivEmp.Rows[intRowCount]["CPRDIV_NAME"].ToString();
                            }
                        }
                        lblDivsn.Text = strDivsn;

                    }


                    DataTable dtExitProcDtlsById = new DataTable();
                    dtExitProcDtlsById = objBusinessExitPartialProcess.ReadExitProcessDtlsByID(objEntityExitPartialProcess);

                    if (dtExitProcDtlsById.Rows.Count > 0)
                    {
                        for (int intRowCount = 0; intRowCount < dtExitProcDtlsById.Rows.Count; intRowCount++)
                        {
                            //ticket
                            if (dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTLPRTCLR_ID"].ToString() == "0")
                            {
                                if (dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTL_FNSH_STS"].ToString()!="0" ||dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTL_CLOSE_STS"].ToString()!="0")
                                {
                                    btnAddTickt.Visible = false;
                                    divTicktClose.Visible = false;
                                    divTicktFinish.Visible = false;
                                }

                                lblTicktTrgtDate.Text = dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTL_DATE"].ToString();
                                //EXTPRDDTL_TICKET_STATUS,EXTPRDDTL_FNSH_STS,EXTPRDDTL_CLOSE_STS,EXTPRDDTL_EXITPERMIT_STATUS,EXTPRDDTL_VISANOC_STATUS,

                                if (ddlTicktSts.Items.FindByValue(dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTL_TICKET_STATUS"].ToString()) != null)
                                {
                                    ddlTicktSts.ClearSelection();
                                    ddlTicktSts.Items.FindByValue(dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTL_TICKET_STATUS"].ToString()).Selected = true;
                                    HiddenFieldTicktSts.Value = dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTL_TICKET_STATUS"].ToString();

                                }
                                if (dtExitProcDtlsById.Rows[intRowCount]["ASSIGNED USER ID"].ToString() == intUserId.ToString())
                                {
                                    //HiddenTicketTab
                                    HiddenTicketTab.Value = "1";
                                    HiddenTicketID.Value = dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTL_ID"].ToString();

                                }
                                if (dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTL_FNSH_STS"].ToString() == "1")
                                {
                                    txtTicktExptdDate.Enabled = false;
                                    HiddenTicketFinSts.Value = "1";
                                    ddlTicktSts.Enabled = false;
                                    btnClearTickt.Style.Add("display", "none");
                                    Image11.Disabled = true;
                                    lblStatsInfoTickt.Text = "Finished";
                                    lblStatsInfoTickt.Style.Add("border-style", "solid");
                                    
                                }
                                if (dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTL_CLOSE_STS"].ToString() == "1")
                                {
                                    HiddenTicketCloseSts.Value = "1";
                                    txtTicktExptdDate.Enabled = false;
                                    ddlTicktSts.Enabled = false;
                                    btnClearTickt.Style.Add("display", "none");
                                    Image11.Disabled = true;
                                    lblStatsInfoTickt.Text = "Closed";
                                    lblStatsInfoTickt.Style.Add("border-style", "solid");
                                }

                            }
                            else if (dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTLPRTCLR_ID"].ToString() == "2")
                            {
                                //ExitPermit
                                if (dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTL_FNSH_STS"].ToString() != "0" || dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTL_CLOSE_STS"].ToString() != "0")
                                {
                                    btnAddExit.Visible = false;
                                    divExitClose.Visible = false;
                                    divExitFinish.Visible = false;
                                }

                                lblExitTrgtDate.Text = dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTL_DATE"].ToString();

                                //EXTPRDDTL_TICKET_STATUS,EXTPRDDTL_FNSH_STS,EXTPRDDTL_CLOSE_STS,EXTPRDDTL_EXITPERMIT_STATUS,EXTPRDDTL_VISANOC_STATUS,

                                if (ddlExitSts.Items.FindByValue(dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTL_EXITPERMIT_STATUS"].ToString()) != null)
                                {
                                    ddlExitSts.ClearSelection();
                                    ddlExitSts.Items.FindByValue(dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTL_EXITPERMIT_STATUS"].ToString()).Selected = true;
                                    HiddenFieldExitSts.Value = dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTL_EXITPERMIT_STATUS"].ToString();

                                }

                                if (dtExitProcDtlsById.Rows[intRowCount]["ASSIGNED USER ID"].ToString() == intUserId.ToString())
                                {
                                    // HiddenExitPermitTab
                                    HiddenExitPermitTab.Value = "1";
                                    HiddenExitPermitID.Value = dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTL_ID"].ToString();

                                }
                                if (dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTL_FNSH_STS"].ToString() == "1")
                                {
                                    HiddenExitPermitFinSts.Value = "1";
                                    txtExitExptdDate.Enabled = false;
                                    ddlExitSts.Enabled = false;
                                    btnClearExit.Style.Add("display", "none");
                                    Image2.Disabled = true;
                                    lblStatusInfoExit.Text = "Finished";
                                    lblStatusInfoExit.Style.Add("border-style", "solid");
                                }
                                if (dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTL_CLOSE_STS"].ToString() == "1")
                                {
                                    txtExitExptdDate.Enabled = false;
                                    ddlExitSts.Enabled = false;
                                    btnClearExit.Style.Add("display", "none");
                                    HiddenExitPermitCloseSts.Value = "1";
                                    Image2.Disabled = true;
                                    lblStatusInfoExit.Text = "Closed";
                                    lblStatusInfoExit.Style.Add("border-style", "solid");
                                }
                            }
                            else if (dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTLPRTCLR_ID"].ToString() == "4")
                            {
                                //visa
                                if (dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTL_FNSH_STS"].ToString() != "0" || dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTL_CLOSE_STS"].ToString() != "0")
                                {
                                    btnAddVisaNoc.Visible = false;
                                    divVisaNocClose.Visible = false;
                                    divVisaNocFinish.Visible = false;
                                }

                                lblVisaTrgtDate.Text = dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTL_DATE"].ToString();

                                //EXTPRDDTL_TICKET_STATUS,EXTPRDDTL_FNSH_STS,EXTPRDDTL_CLOSE_STS,EXTPRDDTL_EXITPERMIT_STATUS,EXTPRDDTL_VISANOC_STATUS,

                                if (ddlVisaNocStatus.Items.FindByValue(dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTL_VISANOC_STATUS"].ToString()) != null)
                                {
                                    ddlVisaNocStatus.ClearSelection();
                                    ddlVisaNocStatus.Items.FindByValue(dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTL_VISANOC_STATUS"].ToString()).Selected = true;
                                    HiddenFieldVisaSts.Value = dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTL_VISANOC_STATUS"].ToString();
                                }
                                if (dtExitProcDtlsById.Rows[intRowCount]["ASSIGNED USER ID"].ToString() == intUserId.ToString())
                                {
                                    //HiddenVisaNocTab
                                    HiddenVisaNocTab.Value = "1";
                                    HiddenVisaNocID.Value = dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTL_ID"].ToString();
                                }

                                if (dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTL_FNSH_STS"].ToString() == "1")
                                {
                                    ddlVisaNocStatus.Enabled = false;
                                    txtVisaExptdDate.Enabled = false;
                                    btnClearSettlmt.Style.Add("display", "none");
                                    HiddenVisaNocFinSts.Value = "1";
                                    Image1.Disabled = true;
                                    lblStatusInfoVisa.Text = "Finished";
                                    lblStatusInfoVisa.Style.Add("border-style", "solid");
                                }
                                if (dtExitProcDtlsById.Rows[intRowCount]["EXTPRDDTL_CLOSE_STS"].ToString() == "1")
                                {
                                    txtVisaExptdDate.Enabled = false;
                                    ddlVisaNocStatus.Enabled = false;
                                    btnClearSettlmt.Style.Add("display", "none");
                                    HiddenVisaNocCloseSts.Value = "1";
                                    Image1.Disabled = true;
                                    lblStatusInfoVisa.Text = "Closed";
                                    lblStatusInfoVisa.Style.Add("border-style", "solid");
                                }
                            }
                        }

                    }


                    if (Request.QueryString["RFGP"] != null)
                    {
                         btnCancelTickt.Visible = false;
                        divList.Visible = false;
                        imgTicktClose.Visible = false;
                        imgTicktFinish.Visible = false;
                        btnCanceExit.Visible = false;
                        btnCancelSettlmt.Visible = false;
                        HiddenView.Value = "1";
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







   

    [WebMethod]
    public static string ClosePartialExitPrcs(int intExitProcdureID, int intExitDtlId,int intMode)
    {
        //close exit process status
        clsEntityLayerExitPartialProcess objEntityExitPartialProcess = new clsEntityLayerExitPartialProcess();
        clsBusinessLayerExitPartialProcess objBusinessExitPartialProcess = new clsBusinessLayerExitPartialProcess();
        string ret = "true";
        objEntityExitPartialProcess.ExitProcDtlID = intExitDtlId;
        objEntityExitPartialProcess.ExitProcdureID = intExitProcdureID;
        objEntityExitPartialProcess.Mode = intMode;
        objEntityExitPartialProcess.Date = System.DateTime.Now;

        string strClsdOrFnshd = "";
        strClsdOrFnshd = objBusinessExitPartialProcess.CheckExitProcess(objEntityExitPartialProcess);

        if (strClsdOrFnshd != "0")
        {
            ret = "false";
        }
        else
        {
            objBusinessExitPartialProcess.closePartialExitProcess(objEntityExitPartialProcess);
        }

        return ret;

    }

    [WebMethod]
    public static string SaveExitPartialProcess(int intExitProcdureID, int intExitDtlId, string dateExpec, int intDdlStatus, string strFinishSts, int intMode)
    {
    
        //finish settlement status

        clsEntityLayerExitPartialProcess objEntityExitPartialProcess = new clsEntityLayerExitPartialProcess();
        clsBusinessLayerExitPartialProcess objBusinessExitPartialProcess = new clsBusinessLayerExitPartialProcess();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string ret = "true";
        objEntityExitPartialProcess.ExitProcDtlID = intExitDtlId;
        objEntityExitPartialProcess.ExitProcdureID = intExitProcdureID;
        objEntityExitPartialProcess.Date = System.DateTime.Now;
        if (dateExpec != "")
            objEntityExitPartialProcess.ExpectedTargetDate = objCommon.textToDateTime(dateExpec);
        objEntityExitPartialProcess.Status = intDdlStatus;

        objEntityExitPartialProcess.FinishSts = Convert.ToInt32(strFinishSts);

        objEntityExitPartialProcess.Mode = intMode;

        string strClsdOrFnshd = "";
        strClsdOrFnshd = objBusinessExitPartialProcess.CheckExitProcess(objEntityExitPartialProcess);

        if (strClsdOrFnshd != "0")
        {
            ret = "false";
        }
        else
        {
            objBusinessExitPartialProcess.updPartialExitProcess(objEntityExitPartialProcess);
        }

        return ret;

    }





}