using System;
using System.Data;
using System.Web.UI;
using System.Text;
using CL_Compzit;
using BL_Compzit;
using System.Web.Services;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using System.Web.UI.WebControls;



public partial class HCM_HCM_Master_hcm_OnBoarding_hcm_OnBoarding_Partial_Process_hcm_OnBoarding_Partial_Process : System.Web.UI.Page
{
    //0008

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

        ddlVisaSts.Attributes.Add("onkeypress", "return isTagEnter(event)");
        ddlFlightSts.Attributes.Add("onkeypress", "return isTagEnter(event)");
        ddlRoomSts.Attributes.Add("onkeypress", "return isTagEnter(event)");
        txtVisaExptdDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtFlightTrgtDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtRoomTrgtdate.Attributes.Add("onkeypress", "return isTag(event)");

        if (!IsPostBack)
        {

            HiddenView.Value = "";
            clsEntityOnBoardingPartialProcess objEntityPartialProcess = new clsEntityOnBoardingPartialProcess();
            clsBusinessLayerOnBoardingPartialProcess objBusinessPartialProcess = new clsBusinessLayerOnBoardingPartialProcess();
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableClose = 0, intEnableHold = 0, intEnableReopen = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
            HiddenCurrentDate.Value = strCurrentDate;
            HiddenVisaType.Value = "";
            HiddenNation.Value = "";
            HiddenVisamatch.Value = "1";
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                HiddenFieldLoginUserId.Value = Session["USERID"].ToString();
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Onboaring_Partial_Process);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

            int intImageMaxSize = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SIZE.ONBOARDING_VISA);
            hiddenVisaFileSize.Value = intImageMaxSize.ToString();
            intImageMaxSize = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SIZE.ONBOARDING_FLIGHTTICKET);
            hiddenFlightTicketFileSize.Value = intImageMaxSize.ToString();

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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString())
                    {
                        intEnableClose = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intEnableReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }

                }



                if (Session["USERID"] != null)
                {
                    objEntityPartialProcess.User_Id = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityPartialProcess.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityPartialProcess.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }




                string strRandomMixedId = Request.QueryString["Id"].ToString();
                HiddenFieldQryId.Value = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityPartialProcess.CandId = Convert.ToInt32(strId);
                HiddenFieldOnbrdId.Value = strId;
                
                DataTable dt = objBusinessPartialProcess.ReadEmpInfoById(objEntityPartialProcess);
                if (dt.Rows.Count > 0)
                {

                    int intimgsection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
                    string imgpath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);

                    lblCandtName.Text = dt.Rows[0]["CAND_NAME"].ToString();
                    lblLoctn.Text = dt.Rows[0]["CAND_LOC"].ToString();
                    lblRefEmp.Text = dt.Rows[0]["REF"].ToString();
                    lblResume.Text = "<a href=\"" + imgpath + dt.Rows[0]["CAND_RESUMENAME"].ToString() + "\">" + dt.Rows[0]["CAND_ACT_RESUMENAME"].ToString() + "</a>";
                    lblNation.Text = dt.Rows[0]["CNTRY_NAME"].ToString();
                    lblVisa.Text = dt.Rows[0]["VISA"].ToString();
                    HiddenVisaType.Value = dt.Rows[0]["VISATYP_ID"].ToString();
                    HiddenNation.Value = dt.Rows[0]["CNTRY_ID"].ToString();
                    HiddenVisaname.Value = dt.Rows[0]["VISQT_DTLS_ID"].ToString();
                    HiddenCntryName.Value = dt.Rows[0]["CNTRY_NAME"].ToString();
                }
                int check = 0;
                if (HiddenNation.Value == "")
                {
                    LoadVisaQuota(check);
                }
                else if (HiddenVisaType.Value != "" && HiddenNation.Value != "")
                {
                    check = 1;
                    LoadVisaQuota(check);
                }
                else
                {
                    LoadVisaQuota(check);
                }
                objEntityPartialProcess.OnbrdDtlId = Convert.ToInt32(strId);
                //  objEntityPartialProcess.CandId = Convert.ToInt32(strId);

                string userId = intUserId.ToString();
                DataTable dtAsgndEmpPartclr = objBusinessPartialProcess.ReadAsgndEmpPartclr(objEntityPartialProcess);
                if (dtAsgndEmpPartclr.Rows.Count > 0)
                {
                    for (int i = 0; i < dtAsgndEmpPartclr.Rows.Count; i++)
                    {
                        if (dtAsgndEmpPartclr.Rows[i]["ONBRDPRTCLR_NAME"].ToString() == "VISA")
                        {
                            if (userId == dtAsgndEmpPartclr.Rows[i]["USR_ID"].ToString())
                            {
                                HiddenFieldVisaTab.Value = "true";
                            }
                        }
                        else if (dtAsgndEmpPartclr.Rows[i]["ONBRDPRTCLR_NAME"].ToString() == "FLIGHT")
                        {
                            if (userId == dtAsgndEmpPartclr.Rows[i]["USR_ID"].ToString())
                            {
                                HiddenFieldFlightTab.Value = "true";
                            }
                        }
                        else if (dtAsgndEmpPartclr.Rows[i]["ONBRDPRTCLR_NAME"].ToString() == "ROOM")
                        {
                            if (userId == dtAsgndEmpPartclr.Rows[i]["USR_ID"].ToString())
                            {
                                HiddenFieldRoomTab.Value = "true";
                            }
                        }
                        else if (dtAsgndEmpPartclr.Rows[i]["ONBRDPRTCLR_NAME"].ToString() == "AIRPORT")
                        {
                            if (userId == dtAsgndEmpPartclr.Rows[i]["USR_ID"].ToString())
                            {
                                HiddenFieldAirportTab.Value = "true";
                            }
                        }
                    }
                }

                DataTable dtPartlrDtls = objBusinessPartialProcess.ReadEmpPrtclrInfoById(objEntityPartialProcess);

                if (dtPartlrDtls.Rows.Count > 0)
                {
                    HiddenFieldTblOnbrdId.Value = dtPartlrDtls.Rows[0]["ONBRD_ID"].ToString();

                    for (int i = 0; i < dtPartlrDtls.Rows.Count; i++)
                    {


                        if (dtPartlrDtls.Rows[i]["ONBRDPRTCLR_NAME"].ToString() == "VISA")
                        {
                            lblVisaTrgtDate.Text = dtPartlrDtls.Rows[i]["TARGET DATE"].ToString();
                            ddlVisaSts.Items.FindByValue(dtPartlrDtls.Rows[i]["ONBRDDTL_VISA_STATUS"].ToString()).Selected = true;
                            HiddenFieldVisaSts.Value = dtPartlrDtls.Rows[i]["ONBRDDTL_VISA_STATUS"].ToString();
                            HiddenFieldVisaFinishSts.Value = dtPartlrDtls.Rows[i]["ONBRD_FNSH_STS"].ToString();
                            HiddenFieldVisaCloseSts.Value = dtPartlrDtls.Rows[i]["ONBRD_CLOSE_STS"].ToString();
                            HiddenFieldVisaOnbrdDtlId.Value = dtPartlrDtls.Rows[i]["ONBRDDTL_ID"].ToString();
                            if (dtPartlrDtls.Rows[i]["ONBRD_FNSH_STS"].ToString() == "1")
                            {
                                ddlVisaSts.Enabled = false;
                                txtVisaExptdDate.Enabled = false;
                                divVisaClose.Visible = false;
                                divVisaFinish.Visible = false;
                                btnAddVisa.Visible = false;
                                btnClearVisa.Visible = false;
                                FileUploadVisa.Enabled = false;
                                lblStatusVisa.Text = "Finished";

                                lblStatusVisa.Style.Add("display", "");
                            }
                            if (dtPartlrDtls.Rows[i]["ONBRD_CLOSE_STS"].ToString() == "1")
                            {
                                lblStatusVisa.Text = "Closed";
                                lblStatusVisa.Style.Add("display", "");


                            }
                            //visa
                            if (dtPartlrDtls.Rows[i]["ONBRDDTL_FILENAME"] != DBNull.Value && dtPartlrDtls.Rows[i]["ONBRDDTL_FILENAME"].ToString() != "")
                            {



                                hiddenVisaFile.Value = dtPartlrDtls.Rows[i]["ONBRDDTL_FILENAME"].ToString();
                                hiddenVisaFileActual.Value = dtPartlrDtls.Rows[i]["ONBRDDTL_ACT_FILENAME"].ToString();
                                string strFileName = dtPartlrDtls.Rows[i]["ONBRDDTL_FILENAME"].ToString();

                                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.ONBOARDING_VISA) + dtPartlrDtls.Rows[i]["ONBRDDTL_FILENAME"].ToString();


                                string strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
                                string strImage;

                                strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\" target=\"blank\" >Click to View Attachment Uploaded</a>";

                                divImageDisplayVisa.InnerHtml = strImage;
                            }

                        }
                        else if (dtPartlrDtls.Rows[i]["ONBRDPRTCLR_NAME"].ToString() == "FLIGHT")
                        {
                            lblFlightTrgtDate.Text = dtPartlrDtls.Rows[i]["TARGET DATE"].ToString();
                            ddlFlightSts.Items.FindByValue(dtPartlrDtls.Rows[i]["ONBRDDTL_FLIGHT_STATUS"].ToString()).Selected = true;
                            HiddenFieldFlightSts.Value = dtPartlrDtls.Rows[i]["ONBRDDTL_FLIGHT_STATUS"].ToString();
                            HiddenFieldFlightFinishSts.Value = dtPartlrDtls.Rows[i]["ONBRD_FNSH_STS"].ToString();
                            HiddenFieldFlightCloseSts.Value = dtPartlrDtls.Rows[i]["ONBRD_CLOSE_STS"].ToString();
                            HiddenFieldFlightDtlId.Value = dtPartlrDtls.Rows[i]["ONBRDDTL_ID"].ToString();

                            if (dtPartlrDtls.Rows[i]["ONBRD_FNSH_STS"].ToString() == "1")
                            {
                                lblStatusFlight.Text = "Finished";
                                lblStatusFlight.Style.Add("display", "");

                            }
                            if (dtPartlrDtls.Rows[i]["ONBRD_CLOSE_STS"].ToString() == "1")
                            {
                                lblStatusFlight.Text = "Closed";
                                lblStatusFlight.Style.Add("display", "");


                            }
                            //flight
                            if (dtPartlrDtls.Rows[i]["ONBRDDTL_FILENAME"] != DBNull.Value && dtPartlrDtls.Rows[i]["ONBRDDTL_FILENAME"].ToString() != "")
                            {



                                hiddenFlightTicketFile.Value = dtPartlrDtls.Rows[i]["ONBRDDTL_FILENAME"].ToString();

                                hiddenFlightTicketFileActual.Value = dtPartlrDtls.Rows[i]["ONBRDDTL_ACT_FILENAME"].ToString();
                                string strFileName = dtPartlrDtls.Rows[i]["ONBRDDTL_FILENAME"].ToString();

                                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.ONBOARDING_FLIGHTTICKET) + dtPartlrDtls.Rows[i]["ONBRDDTL_FILENAME"].ToString();


                                string strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
                                string strImage;

                                strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\" target=\"blank\" >Click to View Attachment Uploaded</a>";

                                divImageDisplayFlightTicket.InnerHtml = strImage;
                            }
                        }
                        else if (dtPartlrDtls.Rows[i]["ONBRDPRTCLR_NAME"].ToString() == "ROOM")
                        {
                            lblRoomTrgtDate.Text = dtPartlrDtls.Rows[i]["TARGET DATE"].ToString();
                            ddlRoomSts.Items.FindByValue(dtPartlrDtls.Rows[i]["ONBRDDTL_ROOM_STATUS"].ToString()).Selected = true;
                            HiddenFieldRoomSts.Value = dtPartlrDtls.Rows[i]["ONBRDDTL_ROOM_STATUS"].ToString();
                            HiddenFieldRoomFinishSts.Value = dtPartlrDtls.Rows[i]["ONBRD_FNSH_STS"].ToString();
                            HiddenFieldRoomCloseSts.Value = dtPartlrDtls.Rows[i]["ONBRD_CLOSE_STS"].ToString();
                            HiddenFieldRoomDtlId.Value = dtPartlrDtls.Rows[i]["ONBRDDTL_ID"].ToString();
                            if (dtPartlrDtls.Rows[i]["ONBRD_FNSH_STS"].ToString() == "1")
                            {
                                lblStatusRoom.Text = "Finished";
                                lblStatusRoom.Style.Add("display", "");
                            }
                            if (dtPartlrDtls.Rows[i]["ONBRD_CLOSE_STS"].ToString() == "1")
                            {
                                lblStatusRoom.Text = "Closed";
                                lblStatusRoom.Style.Add("display", "");

                            }
                        }
                        else if (dtPartlrDtls.Rows[i]["ONBRDPRTCLR_NAME"].ToString() == "AIRPORT")
                        {
                            lblAirptTrgtdate.Text = dtPartlrDtls.Rows[i]["TARGET DATE"].ToString();
                            ddlAirportSts.Items.FindByValue(dtPartlrDtls.Rows[i]["ONBRDDTL_AIRPT_STATUS"].ToString()).Selected = true;
                            HiddenFieldAirptFinishSts.Value = dtPartlrDtls.Rows[i]["ONBRD_FNSH_STS"].ToString();
                            HiddenFieldAirptCloseSts.Value = dtPartlrDtls.Rows[i]["ONBRD_CLOSE_STS"].ToString();
                            HiddenFieldAirportDtlId.Value = dtPartlrDtls.Rows[i]["ONBRDDTL_ID"].ToString();
                            if (dtPartlrDtls.Rows[i]["ONBRD_FNSH_STS"].ToString() == "1")
                            {

                                lblStatusAirport.Text = "Finished";
                                lblStatusAirport.Style.Add("display", "");
                            }
                            if (dtPartlrDtls.Rows[i]["ONBRD_CLOSE_STS"].ToString() == "1")
                            {
                                lblStatusAirport.Text = "Closed";
                                lblStatusAirport.Style.Add("display", "");

                            }
                        }
                    }
                }



                if (Request.QueryString["RFGP"] != null)
                {
                    HiddenView.Value = "1";
                    btnCancel.Visible = false;
                    divList.Visible = false;
                    btnCancelVisa.Visible = false;
                    btnCancelAirport.Visible = false;
                    btnCancelFlight.Visible = false;
                    btnCancelRoom.Visible = false;



                }
                if (Request.QueryString["Ins"] != null)
                {

                    string strInsUpd = Request.QueryString["Ins"].ToString();
                    if (strInsUpd == "InsVisa")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessAddVisa", "SuccessAddVisa();", true);

                    }
                    if (strInsUpd == "InsFlight")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessAddFlight", "SuccessAddFlight();", true);
                    }
                    if (strInsUpd == "InsRoom")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessAddRoom", "SuccessAddRoom();", true);
                    }
                }

                if (Request.QueryString["INSFIN"] != null)
                {
                    string strInsFin = Request.QueryString["INSFIN"].ToString();
                    if (strInsFin == "InsVisa")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessFinishVisa", "SuccessFinishVisa();", true);
                    }
                }
            }
        }
    }

    public void LoadVisaQuota(int check)
    {

        clsEntityOnBoardingPartialProcess objEntityPartialProcess = new clsEntityOnBoardingPartialProcess();
        clsBusinessLayerOnBoardingPartialProcess objBusinessPartialProcess = new clsBusinessLayerOnBoardingPartialProcess();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPartialProcess.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityPartialProcess.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityPartialProcess.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt;
        if (check == 0)
        {
            dtSubConrt = objBusinessPartialProcess.ReadVisaQuota(objEntityPartialProcess);
            if (dtSubConrt.Rows.Count > 0)
            {
                ddlVisaQuota.DataSource = dtSubConrt;
                ddlVisaQuota.DataTextField = "VISQT_NUM";
                ddlVisaQuota.DataValueField = "VISQT_ID";
                ddlVisaQuota.DataBind();

            }

            ddlVisaQuota.Items.Insert(0, "--SELECT VISA QUOTA--");


            if (HiddenFieldOnbrdId.Value != "")
            {
                objEntityPartialProcess.OnbrdDtlId = Convert.ToInt32(HiddenFieldOnbrdId.Value);
                objEntityPartialProcess.CandId = Convert.ToInt32(HiddenFieldOnbrdId.Value);
            }

            DataTable dtPartlrDtls = objBusinessPartialProcess.ReadEmpPrtclrInfoById(objEntityPartialProcess);
            if (dtPartlrDtls.Rows.Count > 0)
            {

                for (int i = 0; i < dtPartlrDtls.Rows.Count; i++)
                {
                    if (dtPartlrDtls.Rows[i]["ONBRDPRTCLR_ID"].ToString() == "1")
                    {
                        if (ddlVisaQuota.Items.FindByValue(dtPartlrDtls.Rows[0]["VISQT_ID"].ToString()) != null)
                        {
                            ddlVisaQuota.Items.FindByValue(dtPartlrDtls.Rows[0]["VISQT_ID"].ToString()).Selected = true;
                        }
                        else
                        {
                            ListItem lstGrp = new ListItem(dtPartlrDtls.Rows[0]["VISQT_NUM"].ToString(), dtPartlrDtls.Rows[0]["VISQT_ID"].ToString());
                            ddlVisaQuota.Items.Insert(0, lstGrp);
                            ddlVisaQuota.Items.FindByValue(dtPartlrDtls.Rows[0]["VISQT_ID"].ToString()).Selected = true;
                        }

                        HiddenVisaDtlId.Value = dtPartlrDtls.Rows[0]["VISQT_ID"].ToString();


                        //ddlVisaQuota.Items.FindByValue(dtSubConrt.Rows[i]["VISQT_ID"].ToString()).Selected = true;
                    }

                }
            }


        }
        if (check == 1)
        {
            int intvisatyp, intNationId;
            if (HiddenVisaType.Value != "")
                intvisatyp = Convert.ToInt32(HiddenVisaType.Value);
            else
                intvisatyp = 0;
            if (HiddenNation.Value != "")
                intNationId = Convert.ToInt32(HiddenNation.Value);
            else
                intNationId = 0;
            dtSubConrt = objBusinessPartialProcess.ReadVisaQuota(objEntityPartialProcess, intvisatyp, intNationId);
            if (dtSubConrt.Rows.Count > 0)
            {
                ddlVisaQuota.DataSource = dtSubConrt;
                ddlVisaQuota.DataTextField = "VISQT_NUM";
                ddlVisaQuota.DataValueField = "VISQT_ID";
                ddlVisaQuota.DataBind();
               // ddlVisaQuota.Items.Insert(0, "--SELECT VISA QUOTA--");
            }
           
            //if (HiddenFieldOnbrdId.Value != "")
            //{
            //    objEntityPartialProcess.OnbrdDtlId = Convert.ToInt32(HiddenFieldOnbrdId.Value);
            //    objEntityPartialProcess.CandId = Convert.ToInt32(HiddenFieldOnbrdId.Value);
            //}
            objEntityPartialProcess.OnbrdDtlId = Convert.ToInt32(HiddenFieldOnbrdId.Value);
            objEntityPartialProcess.CandId = Convert.ToInt32(HiddenFieldOnbrdId.Value);

            DataTable dtPartlrDtls = objBusinessPartialProcess.ReadEmpPrtclrInfoById(objEntityPartialProcess);

            if (dtPartlrDtls.Rows.Count > 0)


            {
                for (int i = 0; i < dtPartlrDtls.Rows.Count; i++)
                {
                    if (dtPartlrDtls.Rows[i]["ONBRDPRTCLR_ID"].ToString() == "1")
                    {
                        if (ddlVisaQuota.Items.FindByValue(dtPartlrDtls.Rows[0]["VISQT_ID"].ToString()) != null)
                        {
                            ddlVisaQuota.Items.FindByValue(dtPartlrDtls.Rows[0]["VISQT_ID"].ToString()).Selected = true;
                        }
                        else
                        {
                            ListItem lstGrp = new ListItem(dtPartlrDtls.Rows[0]["VISQT_NUM"].ToString(), dtPartlrDtls.Rows[0]["VISQT_ID"].ToString());
                            ddlVisaQuota.Items.Insert(0, lstGrp);
                            ddlVisaQuota.Items.FindByValue(dtPartlrDtls.Rows[0]["VISQT_ID"].ToString()).Selected = true;
                        }
                        HiddenVisaDtlId.Value = dtPartlrDtls.Rows[0]["VISQT_ID"].ToString();


                        //ddlVisaQuota.Items.FindByValue(dtSubConrt.Rows[i]["VISQT_ID"].ToString()).Selected = true;
                    }

                }
                
            }


        }
        else
        {
            HiddenVisamatch.Value = "0";
            dtSubConrt = objBusinessPartialProcess.ReadVisaQuota(objEntityPartialProcess);
            if (dtSubConrt.Rows.Count > 0)
            {
                ddlVisaQuota.DataSource = dtSubConrt;
                ddlVisaQuota.DataTextField = "VISQT_NUM";
                ddlVisaQuota.DataValueField = "VISQT_ID";
                ddlVisaQuota.DataBind();

            }


        }


        //  ddlVisaQuota.Items.FindByValue(dtSubConrt.Rows[0]["VISQT_ID"].ToString()).Selected = true;
        //ddlVisaQuota.Items.Insert(0, "--SELECT VISA QUOTA--");
    }


    public class ConvertToTableVisa
    {

        public string[] ConvertToTable(DataTable dt, string Prvsvisatyp, string VisaqtID, string VisaQtDtId, string CntryNm)
        {
            string check = "";
            string[] strret = new string[10];
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();

            StringBuilder sb = new StringBuilder();
            string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
            //add header row
            strHtml += "<thead>";
            strHtml += "<tr class=\"main_table_head\">";
            for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
            {
                if (intColumnHeaderCount == 1)
                {
                    strHtml += "<th class=\"thT\" style=\"width:24%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }

                else if (intColumnHeaderCount == 2)
                {
                    strHtml += "<th class=\"thT\"  style=\"width:24%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                else if (intColumnHeaderCount == 3)
                {
                    strHtml += "<th class=\"thT\"  style=\"width:24%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                else if (intColumnHeaderCount == 4)
                {
                    strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: right; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";

                }
                else if (intColumnHeaderCount == 5)
                {
                    string Mail = "SELECT";
                    strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: center; word-wrap:break-word;\">" + Mail + "</th>";
                }

            }
            strHtml += "</tr>";
            strHtml += "</thead>";
            //add rows


            strHtml += "<tbody>";
            int count = 1, listcount = 0;
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {

                strHtml += "<tr  >";
                listcount = 0;


                count++;

                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        strHtml += "<td id=\"tdVisatype" + intRowBodyCount + "\"  class=\"tdT\" style=\" word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount]["VISATYP_ID"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        strHtml += "<td id=\"tdNation" + intRowBodyCount + "\"  class=\"tdT\" style=\" word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount]["CNTRY_ID"].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                    }
                    if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right;padding-right: 14px;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        strHtml += "<td id=\"tdVisanum" + intRowBodyCount + "\"  class=\"tdT\" style=\" word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }



                }

                if (Prvsvisatyp == "")
                {
                
                    strHtml += "<td class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;\" ><input type=\"checkbox\" onkeypress=\"return isTag(event);\" onclick=\"return checkboxChange('" + strId + "','" + intRowBodyCount + "'); \"   Id=\"cblcandidatelist" + intRowBodyCount + "\"></td>";
                }
                else
                {
                    if (dt.Rows[intRowBodyCount]["VISQT_DTLS_ID"].ToString() == VisaQtDtId)
                    {

                        if (dt.Rows[intRowBodyCount]["VISATYP_ID"].ToString() == Prvsvisatyp)
                        {

                           strHtml += "<td class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;\" ><input type=\"checkbox\" checked=\"true\" onkeypress=\"return isTag(event);\" onclick=\"return checkboxChange('" + strId + "','" + intRowBodyCount + "'); \"   Id=\"cblcandidatelist" + intRowBodyCount + "\"></td>";
                            check = strId;
                        }
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;\" ><input type=\"checkbox\" onkeypress=\"return isTag(event);\" onclick=\"return checkboxChange('" + strId + "','" + intRowBodyCount + "'); \"   Id=\"cblcandidatelist" + intRowBodyCount + "\"></td>";
                    }
                }


                strHtml += "</tr>";

            }

            strHtml += "</tbody>";

            strHtml += "</table>";



            sb.Append(strHtml);
            strret[1]=sb.ToString();
            strret[2] = check;


            return strret;
          
          // HiddenDataTable.Value = sb.ToString();
            //divReport.InnerHtml = sb.ToString();
        }
    }
    protected void btnAddVisa_Click(object sender, EventArgs e)
    {
        clsEntityOnBoardingPartialProcess objEntityPartialProcess = new clsEntityOnBoardingPartialProcess();
        clsBusinessLayerOnBoardingPartialProcess objBusinessPartialProcess = new clsBusinessLayerOnBoardingPartialProcess();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        objEntityPartialProcess.CorpOffice_Id = Convert.ToInt32(HiddenFieldVisaOnbrdDtlId.Value);//For onboard detail id
        objEntityPartialProcess.ReqrmntId = Convert.ToInt32(HiddenFieldTblOnbrdId.Value);//For onboard id
        objEntityPartialProcess.User_Id = Convert.ToInt32(HiddenFieldLoginUserId.Value);
        objEntityPartialProcess.AsgndDate = System.DateTime.Now;//for insert date

        objEntityPartialProcess.StatusId = Convert.ToInt32(ddlVisaSts.SelectedItem.Value);
        if (txtVisaExptdDate.Text != "")
        {
            objEntityPartialProcess.date = objCommon.textToDateTime(txtVisaExptdDate.Text);
        }
        objEntityPartialProcess.OnbrdDtlId = Convert.ToInt32(HiddenFieldOnbrdId.Value);
        //Visa

        int intImageSectionVisa = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.ONBOARDING_VISA);
        string strImgPathVisa = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.ONBOARDING_VISA);

        if (FileUploadVisa.HasFile)
        {
            // GET FILE EXTENSION
            string strFileExt;
            objEntityPartialProcess.ActFileName = FileUploadVisa.FileName;
            strFileExt = FileUploadVisa.FileName.Substring(FileUploadVisa.FileName.LastIndexOf('.') + 1).ToLower();
            string strImageName = intImageSectionVisa.ToString() + "_" + HiddenFieldOnbrdId.Value + "." + strFileExt;
            objEntityPartialProcess.FileName = strImageName;
        }
        else
        {
            objEntityPartialProcess.FileName = hiddenVisaFile.Value;
            objEntityPartialProcess.ActFileName = hiddenVisaFileActual.Value;
        }


        objBusinessPartialProcess.addVisa(objEntityPartialProcess);
        //visa
        if (FileUploadVisa.HasFile)
        {
            FileUploadVisa.SaveAs(Server.MapPath(strImgPathVisa) + objEntityPartialProcess.FileName);
        }
        else
        {
            if (hiddenVisaFileDeleted.Value != "")
            {
                System.IO.File.Delete(Server.MapPath(strImgPathVisa) + hiddenVisaFileDeleted.Value);
            }

        }


        // objEntityPartialProcess.CorpOffice_Id = Convert.ToInt32(HiddenFieldVisaOnbrdDtlId.Value);//For onboard detail id
        
        string visadtlID = HiddenConfirmChk.Value;

        //objEntityPartialProcess.ReqrmntId = Convert.ToInt32(HiddenFieldTblOnbrdId.Value);//For onboard id
        // objEntityPartialProcess.User_Id = Convert.ToInt32(HiddenFieldLoginUserId.Value);
        string visaID = ddlVisaQuota.SelectedValue;
        //objEntityPartialProcess.OnbrdDtlId = Convert.ToInt32(HiddenFieldOnbrdId.Value);
        objEntityPartialProcess.date = System.DateTime.Now;
        //  objEntityPartialProcess.StatusId = 1;//for particular id
        DataTable dt = objBusinessPartialProcess.checkFinishOrClsed(objEntityPartialProcess);

        objBusinessPartialProcess.finishVisa(objEntityPartialProcess, visadtlID, visaID);


        Response.Redirect("hcm_OnBoarding_Partial_Process.aspx?Id=" + HiddenFieldQryId.Value + "&Ins=InsVisa");



    }
    protected void btnAddFlight_Click(object sender, EventArgs e)
    {
        clsEntityOnBoardingPartialProcess objEntityPartialProcess = new clsEntityOnBoardingPartialProcess();
        clsBusinessLayerOnBoardingPartialProcess objBusinessPartialProcess = new clsBusinessLayerOnBoardingPartialProcess();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityPartialProcess.CorpOffice_Id = Convert.ToInt32(HiddenFieldFlightDtlId.Value);//For onboard detail id
        objEntityPartialProcess.ReqrmntId = Convert.ToInt32(HiddenFieldTblOnbrdId.Value);//For onboard id
        objEntityPartialProcess.User_Id = Convert.ToInt32(HiddenFieldLoginUserId.Value);
        objEntityPartialProcess.AsgndDate = System.DateTime.Now;//for insert date

        objEntityPartialProcess.StatusId = Convert.ToInt32(ddlFlightSts.SelectedItem.Value);
        if (txtFlightTrgtDate.Text != "")
        {
            objEntityPartialProcess.date = objCommon.textToDateTime(txtFlightTrgtDate.Text);
        }
        objEntityPartialProcess.OnbrdDtlId = Convert.ToInt32(HiddenFieldOnbrdId.Value);
        int intImageSectionFlightTicket = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.ONBOARDING_FLIGHTTICKET);
        string strImgPathFlightTicket = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.ONBOARDING_FLIGHTTICKET);

        //FlightTicket

        if (FileUploadFlightTicket.HasFile)
        {
            // GET FILE EXTENSION
            string strFileExt;
            objEntityPartialProcess.ActFileName = FileUploadFlightTicket.FileName;
            strFileExt = FileUploadFlightTicket.FileName.Substring(FileUploadFlightTicket.FileName.LastIndexOf('.') + 1).ToLower();
            string strImageName = intImageSectionFlightTicket.ToString() + "_" + HiddenFieldOnbrdId.Value + "." + strFileExt;
            objEntityPartialProcess.FileName = strImageName;
        }
        else
        {
            objEntityPartialProcess.FileName = hiddenFlightTicketFile.Value;
            objEntityPartialProcess.ActFileName = hiddenFlightTicketFileActual.Value;
        }

        objBusinessPartialProcess.addFlight(objEntityPartialProcess);
        //FlightTicket
        if (FileUploadFlightTicket.HasFile)
        {
            FileUploadFlightTicket.SaveAs(Server.MapPath(strImgPathFlightTicket) + objEntityPartialProcess.FileName);
        }
        else
        {
            if (hiddenFlightTicketFileDeleted.Value != "")
            {
                System.IO.File.Delete(Server.MapPath(strImgPathFlightTicket) + hiddenFlightTicketFileDeleted.Value);

            }
        }

        Response.Redirect("hcm_OnBoarding_Partial_Process.aspx?Id=" + HiddenFieldQryId.Value + "&Ins=InsFlight");

    }
    protected void btnAddRoom_Click(object sender, EventArgs e)
    {
        clsEntityOnBoardingPartialProcess objEntityPartialProcess = new clsEntityOnBoardingPartialProcess();
        clsBusinessLayerOnBoardingPartialProcess objBusinessPartialProcess = new clsBusinessLayerOnBoardingPartialProcess();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityPartialProcess.CorpOffice_Id = Convert.ToInt32(HiddenFieldRoomDtlId.Value);//For onboard detail id
        objEntityPartialProcess.ReqrmntId = Convert.ToInt32(HiddenFieldTblOnbrdId.Value);//For onboard id
        objEntityPartialProcess.User_Id = Convert.ToInt32(HiddenFieldLoginUserId.Value);
        objEntityPartialProcess.AsgndDate = System.DateTime.Now;//for insert date

        objEntityPartialProcess.StatusId = Convert.ToInt32(ddlRoomSts.SelectedItem.Value);
        if (txtRoomTrgtdate.Text != "")
        {
            objEntityPartialProcess.date = objCommon.textToDateTime(txtRoomTrgtdate.Text);
        }
        objEntityPartialProcess.OnbrdDtlId = Convert.ToInt32(HiddenFieldOnbrdId.Value);
        objBusinessPartialProcess.addRoom(objEntityPartialProcess);
        Response.Redirect("hcm_OnBoarding_Partial_Process.aspx?Id=" + HiddenFieldQryId.Value + "&Ins=InsRoom");

    }


    [WebMethod]
    public static string CloseVisa(int OnbrdId, int OnbrdIdDtlId, int OnbrdTblId, int UserId)
    {
        clsEntityOnBoardingPartialProcess objEntityPartialProcess = new clsEntityOnBoardingPartialProcess();
        clsBusinessLayerOnBoardingPartialProcess objBusinessPartialProcess = new clsBusinessLayerOnBoardingPartialProcess();
        string ret = "true";
        objEntityPartialProcess.CorpOffice_Id = OnbrdIdDtlId;//For onboard detail id
        objEntityPartialProcess.ReqrmntId = OnbrdTblId;//For onboard id
        objEntityPartialProcess.User_Id = UserId;

        objEntityPartialProcess.OnbrdDtlId = OnbrdId;
        objEntityPartialProcess.date = System.DateTime.Now;
        objEntityPartialProcess.StatusId = 1;//for particular id
        DataTable dt = objBusinessPartialProcess.checkFinishOrClsed(objEntityPartialProcess);
        if (dt.Rows.Count > 0)
        {
            ret = "false";
        }
        else
        {
            objBusinessPartialProcess.CloseVisa(objEntityPartialProcess);
        }

        return ret;
    }
    [WebMethod]
    public static string CloseFlight(int OnbrdId, int OnbrdIdDtlId, int OnbrdTblId, int UserId)
    {
        clsEntityOnBoardingPartialProcess objEntityPartialProcess = new clsEntityOnBoardingPartialProcess();
        clsBusinessLayerOnBoardingPartialProcess objBusinessPartialProcess = new clsBusinessLayerOnBoardingPartialProcess();
        string ret = "true";
        objEntityPartialProcess.CorpOffice_Id = OnbrdIdDtlId;//For onboard detail id
        objEntityPartialProcess.ReqrmntId = OnbrdTblId;//For onboard id
        objEntityPartialProcess.User_Id = UserId;

        objEntityPartialProcess.OnbrdDtlId = OnbrdId;
        objEntityPartialProcess.date = System.DateTime.Now;
        objEntityPartialProcess.StatusId = 2;//for particular id
        DataTable dt = objBusinessPartialProcess.checkFinishOrClsed(objEntityPartialProcess);
        if (dt.Rows.Count > 0)
        {
            ret = "false";
        }
        else
        {
            objBusinessPartialProcess.CloseFlight(objEntityPartialProcess);
        }

        return ret;


    }
    [WebMethod]
    public static string CloseRoom(int OnbrdId, int OnbrdIdDtlId, int OnbrdTblId, int UserId)
    {
        clsEntityOnBoardingPartialProcess objEntityPartialProcess = new clsEntityOnBoardingPartialProcess();
        clsBusinessLayerOnBoardingPartialProcess objBusinessPartialProcess = new clsBusinessLayerOnBoardingPartialProcess();
        string ret = "true";
        objEntityPartialProcess.CorpOffice_Id = OnbrdIdDtlId;//For onboard detail id
        objEntityPartialProcess.ReqrmntId = OnbrdTblId;//For onboard id
        objEntityPartialProcess.User_Id = UserId;

        objEntityPartialProcess.OnbrdDtlId = OnbrdId;
        objEntityPartialProcess.date = System.DateTime.Now;
        objEntityPartialProcess.StatusId = 3;//for particular id
        DataTable dt = objBusinessPartialProcess.checkFinishOrClsed(objEntityPartialProcess);
        if (dt.Rows.Count > 0)
        {
            ret = "false";
        }
        else
        {
            objBusinessPartialProcess.CloseRoom(objEntityPartialProcess);
        }

        return ret;


    }
    [WebMethod]
    public static string CloseAirpt(int OnbrdId, int OnbrdIdDtlId, int OnbrdTblId, int UserId)
    {
        clsEntityOnBoardingPartialProcess objEntityPartialProcess = new clsEntityOnBoardingPartialProcess();
        clsBusinessLayerOnBoardingPartialProcess objBusinessPartialProcess = new clsBusinessLayerOnBoardingPartialProcess();
        string ret = "true";

        objEntityPartialProcess.CorpOffice_Id = OnbrdIdDtlId;//For onboard detail id
        objEntityPartialProcess.ReqrmntId = OnbrdTblId;//For onboard id
        objEntityPartialProcess.User_Id = UserId;

        objEntityPartialProcess.OnbrdDtlId = OnbrdId;
        objEntityPartialProcess.date = System.DateTime.Now;
        objEntityPartialProcess.StatusId = 4;//for particular id
        DataTable dt = objBusinessPartialProcess.checkFinishOrClsed(objEntityPartialProcess);
        if (dt.Rows.Count > 0)
        {
            ret = "false";
        }
        else
        {
            objBusinessPartialProcess.CloseAirpt(objEntityPartialProcess);
        }

        return ret;


    }


    [WebMethod]
    public static string finishFlight(int OnbrdId, int OnbrdIdDtlId, int OnbrdTblId, int UserId)
    {
        clsEntityOnBoardingPartialProcess objEntityPartialProcess = new clsEntityOnBoardingPartialProcess();
        clsBusinessLayerOnBoardingPartialProcess objBusinessPartialProcess = new clsBusinessLayerOnBoardingPartialProcess();
        string ret = "true";
        objEntityPartialProcess.CorpOffice_Id = OnbrdIdDtlId;//For onboard detail id
        objEntityPartialProcess.ReqrmntId = OnbrdTblId;//For onboard id
        objEntityPartialProcess.User_Id = UserId;

        objEntityPartialProcess.OnbrdDtlId = OnbrdId;
        objEntityPartialProcess.date = System.DateTime.Now;
        objEntityPartialProcess.StatusId = 2;//for particular id
        DataTable dt = objBusinessPartialProcess.checkFinishOrClsed(objEntityPartialProcess);
        if (dt.Rows.Count > 0)
        {
            ret = "false";
        }
        else
        {
            objBusinessPartialProcess.finishFlight(objEntityPartialProcess);
        }

        return ret;


    }
    [WebMethod]
    public static string finishRoom(int OnbrdId, int OnbrdIdDtlId, int OnbrdTblId, int UserId)
    {
        clsEntityOnBoardingPartialProcess objEntityPartialProcess = new clsEntityOnBoardingPartialProcess();
        clsBusinessLayerOnBoardingPartialProcess objBusinessPartialProcess = new clsBusinessLayerOnBoardingPartialProcess();
        string ret = "true";
        objEntityPartialProcess.CorpOffice_Id = OnbrdIdDtlId;//For onboard detail id
        objEntityPartialProcess.ReqrmntId = OnbrdTblId;//For onboard id
        objEntityPartialProcess.User_Id = UserId;

        objEntityPartialProcess.OnbrdDtlId = OnbrdId;
        objEntityPartialProcess.date = System.DateTime.Now;
        objEntityPartialProcess.StatusId = 3;//for particular id
        DataTable dt = objBusinessPartialProcess.checkFinishOrClsed(objEntityPartialProcess);
        if (dt.Rows.Count > 0)
        {
            ret = "false";
        }
        else
        {
            objBusinessPartialProcess.finishRoom(objEntityPartialProcess);
        }

        return ret;


    }
    [WebMethod]
    public static string finishAirpt(int OnbrdId, int OnbrdIdDtlId, int OnbrdTblId, int UserId)
    {
        clsEntityOnBoardingPartialProcess objEntityPartialProcess = new clsEntityOnBoardingPartialProcess();
        clsBusinessLayerOnBoardingPartialProcess objBusinessPartialProcess = new clsBusinessLayerOnBoardingPartialProcess();
        string ret = "true";
        objEntityPartialProcess.CorpOffice_Id = OnbrdIdDtlId;//For onboard detail id
        objEntityPartialProcess.ReqrmntId = OnbrdTblId;//For onboard id
        objEntityPartialProcess.User_Id = UserId;

        objEntityPartialProcess.OnbrdDtlId = OnbrdId;
        objEntityPartialProcess.date = System.DateTime.Now;
        objEntityPartialProcess.StatusId = 4;//for particular id
        DataTable dt = objBusinessPartialProcess.checkFinishOrClsed(objEntityPartialProcess);
        if (dt.Rows.Count > 0)
        {
            ret = "false";
        }
        else
        {
            objBusinessPartialProcess.finishAirpt(objEntityPartialProcess);
        }

        return ret;


    }

    [WebMethod]
    public static string[] LoadVisaTable(string VisaQutId, string OnboardId, string Prvsvisatyp, string VisaQtDtId, string CntryNm)
    {
        clsEntityOnBoardingPartialProcess objEntityPartialProcess = new clsEntityOnBoardingPartialProcess();
        clsBusinessLayerOnBoardingPartialProcess objBusinessPartialProcess = new clsBusinessLayerOnBoardingPartialProcess();
        ConvertToTableVisa objVisaQut = new ConvertToTableVisa();

      string VisaqtID = "";
      if (VisaQutId != "")
      {
          VisaqtID = VisaQutId;
      }
       objEntityPartialProcess.OnbrdDtlId = Convert.ToInt32(OnboardId);
     
    // string ret = "";
     string[] strret = new string[10];
      DataTable dt = new DataTable();
      dt = objBusinessPartialProcess.ReadVisaDetails(VisaqtID, CntryNm);


      strret = objVisaQut.ConvertToTable(dt, Prvsvisatyp, VisaqtID, VisaQtDtId, CntryNm);

      return strret;


    }

    protected void imgVisaFinish_Click(object sender, ImageClickEventArgs e)
    {
        clsEntityOnBoardingPartialProcess objEntityPartialProcess = new clsEntityOnBoardingPartialProcess();
        clsBusinessLayerOnBoardingPartialProcess objBusinessPartialProcess = new clsBusinessLayerOnBoardingPartialProcess();
        objEntityPartialProcess.OnbrdDtlId = Convert.ToInt32(HiddenFieldVisaOnbrdDtlId.Value);
        objBusinessPartialProcess.finishVisaStatus(objEntityPartialProcess);
        Response.Redirect("hcm_OnBoarding_Partial_Process.aspx?Id=" + HiddenFieldQryId.Value + "&INSFIN=InsVisa");
        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessFinishVisa", "SuccessFinishVisa();", true);
    }
}