using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using System.Data;
using BL_Compzit;
using HashingUtility;
using CL_Compzit;
using MailUtility_ERP;
using System.Configuration;
using System.Text;

// CREATED BY:EVM-0001
// CREATED DATE:26/02/2016
// REVIEWED BY:
// REVIEW DATE

public partial class Security_Login : System.Web.UI.Page
{
    private enum USERLIMITED
    {
        ISLIMITED = 1,
        NOTLIMITED = 2

    }
    private enum APPS
    {
        APP_ADMINSTRATION = 1,
        SALES_FORCE_AUTOMATION = 2,
        AUTO_WORKSHOP_MANAGEMENT_SYSTEM = 3

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string strWorkingSts = ConfigurationManager.AppSettings["WorkingStatus"];
        if (strWorkingSts == "0")
        {
            Response.Redirect("/Under_Maintenance.aspx");
        }

        //Assign enter key process.
        txtEmailId.Attributes.Add("onkeypress", "return isTag(event)");
        txtPassword.Attributes.Add("onkeypress", "return isTag(event)");
        TxtMailArea.Attributes.Add("onkeypress", "return isTag(event)");
        squaredThree.Attributes.Add("onkeypress", "return isTag(event)");
        if (!IsPostBack)
        {
            //Start:-Remember me
            if (Request.Cookies["LogUserName"] != null && Request.Cookies["LogPassword"] != null)
            {
                txtEmailId.Value = Request.Cookies["LogUserName"].Value;
                txtPassword.Attributes["value"] = Request.Cookies["LogPassword"].Value;
            }
            //End:-Remember me

            hiddenCorpList.Value = "";
            divCorpList.InnerHtml = "";
            divSendMailAll.Style["visibility"] = "hidden";

            DataTable dtConfigDtl = new DataTable();
            clsBusinessLayerLogin objBusinesLogin = new clsBusinessLayerLogin();
            clsBusinessLayer objBusines = new clsBusinessLayer();
            //Emp15--Tocheck wheather the employee is resigned on that date
            clsBusinessLayerPersonalDtls objBusinessLayerPersonalDtls = new clsBusinessLayerPersonalDtls();
            objBusinessLayerPersonalDtls.EmployeeResign();
            dtConfigDtl = objBusines.LoadConfigDetail();
            string strDvlprInfo = "0";
            int intOnCloud = 1;
            int intHCMCandidateLogin = 1;
            if (dtConfigDtl.Rows.Count > 0)
            {
                strDvlprInfo = dtConfigDtl.Rows[0]["DVLPR_INFO"].ToString().Trim();
                intOnCloud = Convert.ToInt16(dtConfigDtl.Rows[0]["ON_CLOUD"].ToString().Trim());
                intHCMCandidateLogin = Convert.ToInt16(dtConfigDtl.Rows[0]["HCM_CANDIDATE_LOGIN"].ToString().Trim());
            }
            //to show candidate login link
            if (intHCMCandidateLogin == 1)
            {
                BtnCand.Visible = true;
            }
            else
            {
                BtnCand.Visible = false;
            }
            //to show developed by information
            if (strDvlprInfo == "1")
            {
                string strCompanyName = "", strCompanyWeb = "";

                DataTable dtCompanyDetail = new DataTable();
                clsCommonLibrary.APP_COMPANY[] arrEnumer = { clsCommonLibrary.APP_COMPANY.CMPNY_NAME, clsCommonLibrary.APP_COMPANY.CMPNY_WEB, clsCommonLibrary.APP_COMPANY.CHNL_PARTNR_NAME, clsCommonLibrary.APP_COMPANY.CHNL_PARTNR_WEB };
                dtCompanyDetail = objBusines.LoadCompanyDetail(arrEnumer);
                if (dtCompanyDetail.Rows.Count > 0)
                {
                    if (dtCompanyDetail.Rows[0]["CHNL_PARTNR_NAME"].ToString() != "")
                    {
                        strCompanyName = dtCompanyDetail.Rows[0]["CHNL_PARTNR_NAME"].ToString();
                        strCompanyWeb = "http://" + dtCompanyDetail.Rows[0]["CHNL_PARTNR_WEB"].ToString();
                    }
                    else
                    {
                        strCompanyName = dtCompanyDetail.Rows[0]["CMPNY_NAME"].ToString();
                        strCompanyWeb = "http://" + dtCompanyDetail.Rows[0]["CMPNY_WEB"].ToString();

                    }
                }
                //0041

                divdevelop.InnerHtml = "©" + " " + DateTime.Now.Year.ToString() + " " + "Copyright:Developed by: <a target= \"_blank \" href=\"" + strCompanyWeb + "\">" + strCompanyName + "</a> ";

                //END
            }
            else
            {
                divdevelop.InnerHtml = " © " + DateTime.Now.Year.ToString() + " Copyright";
            }
            if (intOnCloud == Convert.ToInt16(clsCommonLibrary.Cloud.OnCloud))
            {
                divNewRegister.Visible = true;
                divSendMailAll.Style["visibility"] = "visible";
            }
            else if (intOnCloud == Convert.ToInt16(clsCommonLibrary.Cloud.NotCloud))
            {
                string strCheck = objBusinesLogin.CheckForNewRegister();
                if (strCheck == "0")
                {
                    divNewRegister.Visible = true;
                }
                else
                {
                    divNewRegister.Visible = false;

                }

                string strCheckSendMail = objBusinesLogin.CheckForShowingSendMail();
                if (strCheckSendMail == "0")
                {
                    divSendMailAll.Style["visibility"] = "hidden";
                }
                else
                {
                    divSendMailAll.Style["visibility"] = "visible";
                }
            }
            txtEmailId.Focus();
            Session.Clear();

            if (divNewRegister.Visible == false && BtnCand.Visible == false)
            {
                divOR.Visible = false;
                MainDiv.Style.Add("height", "445px");
            }
            else if (divNewRegister.Visible == false)
            {
                BtnCand.Style.Add("margin-left", "33%");
            }
            else if (BtnCand.Visible == false)
            {
                divNewRegister.Style.Add("margin-left", "33%");
            }
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        int intUserId = 0;
        hiddenCorpList.Value = "";
        divCorpList.InnerHtml = "";

        //Creating objects for business layer.
        clsBusinessLayerLogin objbusinessLayerLogin = new clsBusinessLayerLogin();
        bool blCheckTemplateAppadmin = false;
        bool blDefaultMailTemplateExists = false;
        Session.Clear();

        clsEntityLayerLogin objEntLogin = new clsEntityLayerLogin();
        //used only for deciding to show landing page or not
        clsEntityLayerLogin objEntLoginCount = new clsEntityLayerLogin();

        //used only for deciding to show CORPORATE MODAL CHOOSING PAGE
        clsEntityLayerLogin objEntLoginOControl = new clsEntityLayerLogin();

        //Passing user email id and user password to the method and get user id of email and password.

        string strPwd = txtPassword.Value;
        clsHash objHashing = new clsHash();
        string strEncryptedPwd = objHashing.GetHash(strPwd, Convert.ToInt32(clsCommonLibrary.HashType.SHA256));

        objEntLogin.UserEmail = txtEmailId.Value;
        objEntLogin.UserPwd = strEncryptedPwd;

        string strOrgId = ConfigurationManager.AppSettings["OrganisationId"];
        string strUnAvailableWrkStnCnfrm = ConfigurationManager.AppSettings["UnAvailableWorkStnConfirm"];
        objEntLogin.OrgId = Convert.ToInt32(strOrgId);
        DataTable dtLogin = new DataTable();
        dtLogin = objbusinessLayerLogin.LoadLogin(objEntLogin);
        if (dtLogin.Rows.Count > 0)
        {
            //Start:-Remember me
            if (squaredThree.Checked)
            {
                Response.Cookies["LogUserName"].Expires = DateTime.MaxValue;
                Response.Cookies["LogPassword"].Expires = DateTime.MaxValue;
                Response.Cookies["LogUserName"].Value = txtEmailId.Value.Trim();
                Response.Cookies["LogPassword"].Value = txtPassword.Value.Trim();
            }
            else
            {
                Response.Cookies["LogUserName"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["LogPassword"].Expires = DateTime.Now.AddDays(-1);
            }
            //End:-Remember me


            txtPassword.Value = "";
            Session["USERNAME"] = dtLogin.Rows[0]["USR_NAME"].ToString();
            Session["USERID"] = dtLogin.Rows[0]["USR_ID"].ToString();
            Session["USERFULLNAME"] = dtLogin.Rows[0]["EMPLOYEE_NAME"].ToString();
            intUserId = Convert.ToInt32(dtLogin.Rows[0]["USR_ID"].ToString());



            if (dtLogin.Rows[0]["FRMWRK_ID"].ToString() != "")
            {
                Session["FRMWRK_ID"] = dtLogin.Rows[0]["FRMWRK_ID"].ToString();
            }
            if (dtLogin.Rows[0]["FRMWRK_TYPE"].ToString() != "")
            {
                Session["FRMWRK_TYPE"] = dtLogin.Rows[0]["FRMWRK_TYPE"].ToString();
            }
            string FrameWrkType = dtLogin.Rows[0]["FRMWRK_TYPE"].ToString();

            //change framework
            //FrameWrkType = "1";

            string sessionUserId = Session["USERID"].ToString();
            if (dtLogin.Rows[0]["USR_ID"].ToString() != "")
            {
                objEntLoginCount.UserIdInt = Convert.ToInt32(dtLogin.Rows[0]["USR_ID"].ToString());
                objEntLoginOControl.UserIdInt = Convert.ToInt32(dtLogin.Rows[0]["USR_ID"].ToString());
            }
            if (dtLogin.Rows[0]["DSGN_CONTROL"].ToString() != "")
            {
                Session["DSGN_CONTROL"] = dtLogin.Rows[0]["DSGN_CONTROL"].ToString();
            }
            if (dtLogin.Rows[0]["DSGTYP_ID"].ToString() != "")
            {
                objEntLoginOControl.DsgnTypId = Convert.ToInt32(dtLogin.Rows[0]["DSGTYP_ID"].ToString());
                Session["DSGN_TYPID"] = dtLogin.Rows[0]["DSGTYP_ID"].ToString();
            }

            if (dtLogin.Rows[0]["ORG_ID"].ToString() != "")
            {
                objEntLoginOControl.OrgId = Convert.ToInt32(dtLogin.Rows[0]["ORG_ID"].ToString());
                Session["ORGID"] = dtLogin.Rows[0]["ORG_ID"].ToString();
                objEntLogin.OrgId = Convert.ToInt32(dtLogin.Rows[0]["ORG_ID"].ToString());
                clsBusinessLayerLogin objBusinessLog = new clsBusinessLayerLogin();
                DataTable dtOrgName = new DataTable();
                dtOrgName = objBusinessLog.ReadOrganisationName(objEntLogin);
                Session["ORGNAME"] = dtOrgName.Rows[0]["ORG_NAME"].ToString();
            }
            if (Convert.ToInt16(dtLogin.Rows[0]["DSGTYP_ID"].ToString()) == Convert.ToInt16(clsCommonLibrary.DesignationType.App_Administrator))
            {
                //app admin
                string strcheckTemplate = objbusinessLayerLogin.CheckForEmailTemplatesPresent();

                //if template is not found
                if (strcheckTemplate == "0")
                {
                    blCheckTemplateAppadmin = true;

                }

                Int32 intDefaultMailTemplateExists = objbusinessLayerLogin.DefaultMailTemplateExists();

                if (intDefaultMailTemplateExists == 1)
                {
                    blDefaultMailTemplateExists = true;

                }

            }
            DataTable dtAcsibleCorps = new DataTable();
            if (dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "C" || dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "c")
            {
                objEntLogin.UserIdInt = intUserId;
                dtAcsibleCorps = objbusinessLayerLogin.ReadAcsCorpBy_Usr(objEntLogin);
                if (dtAcsibleCorps.Rows.Count > 1)
                {
                    if (dtLogin.Rows[0]["CPRDEPT_ID"].ToString() != "")
                    {
                        Session["DEPTID"] = dtLogin.Rows[0]["CPRDEPT_ID"].ToString();
                    }
                }
                else
                {
                    if (dtLogin.Rows[0]["CORPRT_ID"].ToString() != "")
                    {
                        Session["CORPOFFICEID"] = dtLogin.Rows[0]["CORPRT_ID"].ToString();

                        objEntLogin.CorpOfficeId = Convert.ToInt32(dtLogin.Rows[0]["CORPRT_ID"].ToString());
                        clsBusinessLayerLogin objBusinessLog = new clsBusinessLayerLogin();
                        DataTable dtCorpName = new DataTable();
                        dtCorpName = objBusinessLog.ReadCorporateName(objEntLogin);


                        if (dtCorpName.Rows.Count > 0)
                        {
                            Session["CORPORATENAME"] = dtCorpName.Rows[0]["CORPRT_NAME"].ToString();
                        }


                    }
                    if (dtLogin.Rows[0]["CPRDEPT_ID"].ToString() != "")
                    {
                        Session["DEPTID"] = dtLogin.Rows[0]["CPRDEPT_ID"].ToString();
                    }

                    clsBusinessLayer objBusiness = new clsBusinessLayer();
                    clsEntityCommon objEntityCommon = new clsEntityCommon();

                    if (Session["ORGID"] != null)
                    {
                        objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                    }


                    ////For Finacial year id
                    if (dtLogin.Rows[0]["CORPRT_ID"].ToString() != "")
                    {
                        objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"]);

                        DataTable dtfinaclYear = objBusiness.ReadFinancialYear(objEntityCommon);
                        if (dtfinaclYear.Rows.Count > 0)
                        {
                            if (dtfinaclYear.Rows[0]["FINCYR_ID"].ToString() != "")
                            {
                                Session["FINCYRID"] = Convert.ToInt32(dtfinaclYear.Rows[0]["FINCYR_ID"].ToString());
                            }
                        }
                        else
                        {
                            DataTable dtCorpDetail = new DataTable();

                            int intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = { clsCommonLibrary.CORP_GLOBAL.ACTIVE_FINCYR_ID };
                            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
                            if (dtCorpDetail.Rows.Count > 0)
                            {
                                if (dtCorpDetail.Rows[0]["ACTIVE_FINCYR_ID"].ToString() != "")
                                {
                                    Session["FINCYRID"] = Convert.ToInt32(dtCorpDetail.Rows[0]["ACTIVE_FINCYR_ID"].ToString());
                                }
                            }
                        }
                    }
                }

                //For Finacial year id
                //if (dtLogin.Rows[0]["CORPRT_ID"].ToString() != "")
                //{
                //    clsBusinessLayer objBusiness = new clsBusinessLayer();
                //    DataTable dtCorpDetail = new DataTable();

                //    int intCorpId = Convert.ToInt32(dtLogin.Rows[0]["CORPRT_ID"].ToString());
                //    clsCommonLibrary.CORP_GLOBAL[] arrEnumer = { clsCommonLibrary.CORP_GLOBAL.ACTIVE_FINCYR_ID };
                //    dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
                //    if (dtCorpDetail.Rows.Count > 0)
                //    {
                //        if (dtCorpDetail.Rows[0]["ACTIVE_FINCYR_ID"].ToString() != "")
                //        {
                //            Session["FINCYRID"] = Convert.ToInt32(dtCorpDetail.Rows[0]["ACTIVE_FINCYR_ID"].ToString());
                //        }
                //    }
                //}
            }


            if ((blCheckTemplateAppadmin == false) && (blDefaultMailTemplateExists == false))
            {

                DataTable dtConfigDtl = new DataTable();
                clsBusinessLayer objBussines = new clsBusinessLayer();
                dtConfigDtl = objBussines.LoadConfigDetail();
                string strMac_Identify = "";
                if (dtConfigDtl.Rows.Count > 0)
                {
                    strMac_Identify = dtConfigDtl.Rows[0]["MAC_IDENTIFY"].ToString().Trim();
                }
                if (Request.Cookies[strMac_Identify] == null || strMac_Identify == "")
                {
                    Session["WRKSTNID"] = "0";
                    if (strUnAvailableWrkStnCnfrm == "ALLOW")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert1", "<script>alert('Sorry, WorkStation is unavailable for this device!')</script>");
                    }
                }
                else
                {
                    objEntLogin.EncryptedWrkStnId = Convert.ToString(Request.Cookies[strMac_Identify].Value);
                    string strCount = objbusinessLayerLogin.CheckEncryptedWrkStnId(objEntLogin);
                    if (strCount == "0")
                    {
                        Session["WRKSTNID"] = "0";
                        if (strUnAvailableWrkStnCnfrm == "ALLOW")
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert1", "<script>alert('Sorry, WorkStation is unavailable for this device!')</script>");
                        }
                    }
                    else
                    {
                        objEntLogin.EncryptedWrkStnId = Convert.ToString(Request.Cookies[strMac_Identify].Value);
                        DataTable dtPrmiseIdWrkStnId = new DataTable();
                        dtPrmiseIdWrkStnId = objbusinessLayerLogin.ReadPremise(objEntLogin);
                        if (dtPrmiseIdWrkStnId.Rows.Count > 0)
                        {

                            Session["PREMISEID"] = dtPrmiseIdWrkStnId.Rows[0]["PREMISE_ID"].ToString();
                            Session["WRKSTNID"] = dtPrmiseIdWrkStnId.Rows[0]["WRKSTN_ID"].ToString();
                            Session["WRKAREAID"] = dtPrmiseIdWrkStnId.Rows[0]["DPTAREA_ID"].ToString();
                            Session["CORPORATENAME"] = dtPrmiseIdWrkStnId.Rows[0]["CORPRT_NAME"].ToString();
                            Session["PREMISENAME"] = dtPrmiseIdWrkStnId.Rows[0]["PREMISE_NAME"].ToString();
                        }
                    }
                }

                DataTable dtMenuCountDtl = new DataTable();
                dtMenuCountDtl = objbusinessLayerLogin.Read_AppMenuCount(objEntLoginCount);
                if (dtMenuCountDtl.Rows.Count > 0)
                {
                    int intUserLimited = Convert.ToInt32(USERLIMITED.ISLIMITED);
                    clsBusinessLayerDesignation objBusinessLayerDsgnMaster = new clsBusinessLayerDesignation();
                    clsEntityLayerDesignation objEntityDsgn = new clsEntityLayerDesignation();
                    objEntityDsgn.DesignationUserId = intUserId;
                    DataTable dtUserLimitedDetails = new DataTable();

                    dtUserLimitedDetails = objBusinessLayerDsgnMaster.ReadIfUserLimitedByUsrId(objEntityDsgn);
                    if (dtUserLimitedDetails.Rows.Count > 0)
                    {
                        intUserLimited = Convert.ToInt32(dtUserLimitedDetails.Rows[0]["USR_LMTD"].ToString());
                    }
                    int intAppAdmistratnCount = 0;
                    int intSalesForceCount = 0;
                    int intAwmsCount = 0;
                    int intGmsCount = 0;
                    int intHcmCount = 0;
                    int intFMSCount = 0;
                    int intPMSCount = 0;
                    if (dtMenuCountDtl.Rows[0]["MCOUNT"].ToString() != "")
                    {
                        intAppAdmistratnCount = Convert.ToInt32(dtMenuCountDtl.Rows[0]["MCOUNT"].ToString());
                    }
                    if (dtMenuCountDtl.Rows[1]["MCOUNT"].ToString() != "")
                    {
                        intSalesForceCount = Convert.ToInt32(dtMenuCountDtl.Rows[1]["MCOUNT"].ToString());
                    }
                    if (dtMenuCountDtl.Rows[2]["MCOUNT"].ToString() != "")
                    {
                        intAwmsCount = Convert.ToInt32(dtMenuCountDtl.Rows[2]["MCOUNT"].ToString());
                    }
                    if (dtMenuCountDtl.Rows[3]["MCOUNT"].ToString() != "")
                    {
                        intGmsCount = Convert.ToInt32(dtMenuCountDtl.Rows[3]["MCOUNT"].ToString());
                    }
                    if (dtMenuCountDtl.Rows[4]["MCOUNT"].ToString() != "")
                    {
                        intHcmCount = Convert.ToInt32(dtMenuCountDtl.Rows[4]["MCOUNT"].ToString());
                    }
                    if (dtMenuCountDtl.Rows[5]["MCOUNT"].ToString() != "")
                    {
                        intFMSCount = Convert.ToInt32(dtMenuCountDtl.Rows[5]["MCOUNT"].ToString());
                    }
                    if (dtMenuCountDtl.Rows[6]["MCOUNT"].ToString() != "")
                    {
                        intPMSCount = Convert.ToInt32(dtMenuCountDtl.Rows[6]["MCOUNT"].ToString());
                    }
                    //evm-0012
                    //Start:-Framework
                    if (FrameWrkType == "1")
                    {
                        bool blLimitedSts = true;
                        if (intAppAdmistratnCount == 1 && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                        {
                            DataTable dtUserRole = objbusinessLayerLogin.Read_AppMenuDtl(intUserId, Convert.ToInt32(APPS.APP_ADMINSTRATION));
                            if (dtUserRole.Rows.Count > 0)
                            {
                                int intUserRolMastrId = Convert.ToInt32(dtUserRole.Rows[0]["USROL_ID"].ToString());
                                if (intUserRolMastrId == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.DesignationMaster))
                                {
                                    blLimitedSts = false;
                                }

                            }
                            else
                            {
                                blLimitedSts = false;
                            }

                        }
                        if ((dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "O" || dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "o") && (Convert.ToInt16(dtLogin.Rows[0]["DSGTYP_ID"].ToString()) == Convert.ToInt16(clsCommonLibrary.DesignationType.OrganisationMosAdministrator)))
                        {
                            DataTable dtAllCorpOfc_ByOrgId = new DataTable();
                            dtAllCorpOfc_ByOrgId = objbusinessLayerLogin.Read_CorpOffc_ByOrgId(objEntLoginOControl);
                            if (dtAllCorpOfc_ByOrgId.Rows.Count > 0)
                            {
                                if (dtAllCorpOfc_ByOrgId.Rows.Count == 1)
                                {//take that corp offc by default
                                    int intCorpOffcId = Convert.ToInt32(dtAllCorpOfc_ByOrgId.Rows[0]["CORPRT_ID"].ToString());
                                    //   string strCorpName = dt.Rows[intRowBodyCount]["CORPRT_NAME"].ToString();
                                    clsCommonLibrary objCommon = new clsCommonLibrary();
                                    string strRandom = objCommon.Random_Number();

                                    string strId = intCorpOffcId.ToString();
                                    int intIdLength = strId.Length;
                                    string stridLength = intIdLength.ToString("00");
                                    string Id = stridLength + strId + strRandom;
                                    if (blLimitedSts == true)
                                    {
                                        Response.Redirect("/Home/Compzit_Home/Compzit_Home_Finance.aspx?CId=" + Id + "");
                                    }
                                }
                                else
                                {
                                    string strHtm = "";
                                    if (blLimitedSts == true)
                                    {
                                        strHtm = ConvertDataTableToHTML_List(dtAllCorpOfc_ByOrgId, "/Home/Compzit_Home/Compzit_Home_Finance.aspx");
                                    }
                                    divCorpList.InnerHtml = strHtm;
                                    //write list
                                    hiddenCorpList.Value = "ShowCorList";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowCorpList", "ShowCorpList();", true);
                                }


                            }
                            else
                            {
                                if (blLimitedSts == true)
                                {
                                    Response.Redirect("/Home/Compzit_Home/Compzit_Home_Finance.aspx");
                                }
                            }
                        }
                        else
                        {
                            if (dtAcsibleCorps.Rows.Count > 1)
                            {
                                string strHtm = "";
                                strHtm = ConvertDataTableToHTML_List(dtAcsibleCorps, "/Home/Compzit_Home/Compzit_Home_Finance.aspx");
                                divCorpList.InnerHtml = strHtm;
                                //write list
                                hiddenCorpList.Value = "ShowCorList";
                                ScriptManager.RegisterStartupScript(this, GetType(), "ShowCorpList", "ShowCorpList();", true);
                            }
                            else
                            {
                                if (blLimitedSts == true)
                                {
                                    Response.Redirect("/Home/Compzit_Home/Compzit_Home_Finance.aspx");
                                }
                            }
                        }
                    }
                    else
                    {
                        //End:-Framework


                        //SFA & APP
                        if (intGmsCount == 0 && intSalesForceCount != 0 && intAppAdmistratnCount != 0 && intAwmsCount == 0 && intHcmCount == 0 && intFMSCount == 0 && intPMSCount == 0)
                        {
                            bool blLimitedSts = true;
                            if (intAppAdmistratnCount == 1 && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                            {
                                DataTable dtUserRole = objbusinessLayerLogin.Read_AppMenuDtl(intUserId, Convert.ToInt32(APPS.APP_ADMINSTRATION));
                                if (dtUserRole.Rows.Count > 0)
                                {
                                    int intUserRolMastrId = Convert.ToInt32(dtUserRole.Rows[0]["USROL_ID"].ToString());
                                    if (intUserRolMastrId == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.DesignationMaster))
                                    {
                                        blLimitedSts = false;
                                    }

                                }
                                else
                                {
                                    blLimitedSts = false;
                                }

                            }
                            if ((dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "O" || dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "o") && (Convert.ToInt16(dtLogin.Rows[0]["DSGTYP_ID"].ToString()) == Convert.ToInt16(clsCommonLibrary.DesignationType.OrganisationMosAdministrator)))
                            {
                                DataTable dtAllCorpOfc_ByOrgId = new DataTable();
                                dtAllCorpOfc_ByOrgId = objbusinessLayerLogin.Read_CorpOffc_ByOrgId(objEntLoginOControl);
                                if (dtAllCorpOfc_ByOrgId.Rows.Count > 0)
                                {
                                    if (dtAllCorpOfc_ByOrgId.Rows.Count == 1)
                                    {//take that corp offc by default
                                        int intCorpOffcId = Convert.ToInt32(dtAllCorpOfc_ByOrgId.Rows[0]["CORPRT_ID"].ToString());
                                        //   string strCorpName = dt.Rows[intRowBodyCount]["CORPRT_NAME"].ToString();
                                        clsCommonLibrary objCommon = new clsCommonLibrary();
                                        string strRandom = objCommon.Random_Number();

                                        string strId = intCorpOffcId.ToString();
                                        int intIdLength = strId.Length;
                                        string stridLength = intIdLength.ToString("00");
                                        string Id = stridLength + strId + strRandom;
                                        if (blLimitedSts == true)
                                        {
                                            Response.Redirect("/Home/Compzit_LandingPage/Compzit_LandingPage.aspx?CId=" + Id + "");
                                        }
                                        else
                                        {
                                            Response.Redirect("/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx?CId=" + Id + "");
                                        }
                                    }
                                    else
                                    {
                                        string strHtm = "";
                                        if (blLimitedSts == true)
                                        {
                                            strHtm = ConvertDataTableToHTML_List(dtAllCorpOfc_ByOrgId, "/Home/Compzit_LandingPage/Compzit_LandingPage.aspx");
                                        }
                                        else
                                        {
                                            strHtm = ConvertDataTableToHTML_List(dtAllCorpOfc_ByOrgId, "/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx");

                                        }
                                        divCorpList.InnerHtml = strHtm;
                                        //write list
                                        hiddenCorpList.Value = "ShowCorList";
                                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowCorpList", "ShowCorpList();", true);
                                    }


                                }
                                else
                                {
                                    if (blLimitedSts == true)
                                    {
                                        Response.Redirect("/Home/Compzit_LandingPage/Compzit_LandingPage.aspx");
                                    }
                                    else
                                    {

                                        Response.Redirect("/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx");
                                    }
                                }

                            }
                            else
                            {
                                if (dtAcsibleCorps.Rows.Count > 1)
                                {
                                    string strHtm = "";
                                    if (blLimitedSts == true)
                                    {
                                        strHtm = ConvertDataTableToHTML_List(dtAcsibleCorps, "/Home/Compzit_LandingPage/Compzit_LandingPage.aspx");
                                    }
                                    else
                                    {
                                        strHtm = ConvertDataTableToHTML_List(dtAcsibleCorps, "/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx");

                                    }
                                    divCorpList.InnerHtml = strHtm;
                                    //write list
                                    hiddenCorpList.Value = "ShowCorList";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowCorpList", "ShowCorpList();", true);
                                }
                                else
                                {

                                    if (blLimitedSts == true)
                                    {
                                        //  ScriptManager.RegisterStartupScript(this, GetType(), "HomeWindow", "HomeWindow();", true);
                                        Response.Redirect("/Home/Compzit_LandingPage/Compzit_LandingPage.aspx");
                                    }
                                    else
                                    {

                                        Response.Redirect("/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx");
                                    }
                                }
                            }
                        }
                        //GMS & APP
                        if (intGmsCount != 0 && intSalesForceCount == 0 && intAppAdmistratnCount != 0 && intAwmsCount == 0 && intHcmCount == 0 && intFMSCount == 0 && intPMSCount == 0)
                        {
                            bool blLimitedSts = true;
                            if (intAppAdmistratnCount == 1 && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                            {
                                DataTable dtUserRole = objbusinessLayerLogin.Read_AppMenuDtl(intUserId, Convert.ToInt32(APPS.APP_ADMINSTRATION));
                                if (dtUserRole.Rows.Count > 0)
                                {
                                    int intUserRolMastrId = Convert.ToInt32(dtUserRole.Rows[0]["USROL_ID"].ToString());
                                    if (intUserRolMastrId == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.DesignationMaster))
                                    {
                                        blLimitedSts = false;
                                    }

                                }
                                else
                                {
                                    blLimitedSts = false;
                                }

                            }
                            if ((dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "O" || dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "o") && (Convert.ToInt16(dtLogin.Rows[0]["DSGTYP_ID"].ToString()) == Convert.ToInt16(clsCommonLibrary.DesignationType.OrganisationMosAdministrator)))
                            {
                                DataTable dtAllCorpOfc_ByOrgId = new DataTable();
                                dtAllCorpOfc_ByOrgId = objbusinessLayerLogin.Read_CorpOffc_ByOrgId(objEntLoginOControl);
                                if (dtAllCorpOfc_ByOrgId.Rows.Count > 0)
                                {
                                    if (dtAllCorpOfc_ByOrgId.Rows.Count == 1)
                                    {//take that corp offc by default
                                        int intCorpOffcId = Convert.ToInt32(dtAllCorpOfc_ByOrgId.Rows[0]["CORPRT_ID"].ToString());
                                        //   string strCorpName = dt.Rows[intRowBodyCount]["CORPRT_NAME"].ToString();
                                        clsCommonLibrary objCommon = new clsCommonLibrary();
                                        string strRandom = objCommon.Random_Number();

                                        string strId = intCorpOffcId.ToString();
                                        int intIdLength = strId.Length;
                                        string stridLength = intIdLength.ToString("00");
                                        string Id = stridLength + strId + strRandom;
                                        if (blLimitedSts == true)
                                        {
                                            Response.Redirect("/Home/Compzit_LandingPage/Compzit_LandingPage.aspx?CId=" + Id + "");
                                        }
                                        else
                                        {
                                            Response.Redirect("/Home/Compzit_Home/Compzit_Home_Gms.aspx?CId=" + Id + "");
                                        }
                                    }
                                    else
                                    {
                                        string strHtm = "";
                                        if (blLimitedSts == true)
                                        {
                                            strHtm = ConvertDataTableToHTML_List(dtAllCorpOfc_ByOrgId, "/Home/Compzit_LandingPage/Compzit_LandingPage.aspx");
                                        }
                                        else
                                        {
                                            strHtm = ConvertDataTableToHTML_List(dtAllCorpOfc_ByOrgId, "/Home/Compzit_Home/Compzit_Home_Gms.aspx");

                                        }
                                        divCorpList.InnerHtml = strHtm;
                                        //write list
                                        hiddenCorpList.Value = "ShowCorList";
                                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowCorpList", "ShowCorpList();", true);
                                    }


                                }
                                else
                                {

                                    if (blLimitedSts == true)
                                    {
                                        Response.Redirect("/Home/Compzit_LandingPage/Compzit_LandingPage.aspx");
                                    }
                                    else
                                    {

                                        Response.Redirect("/Home/Compzit_Home/Compzit_Home_Gms.aspx");
                                    }

                                }

                            }
                            else
                            {
                                if (dtAcsibleCorps.Rows.Count > 1)
                                {
                                    string strHtm = "";
                                    if (blLimitedSts == true)
                                    {
                                        strHtm = ConvertDataTableToHTML_List(dtAcsibleCorps, "/Home/Compzit_LandingPage/Compzit_LandingPage.aspx");
                                    }
                                    else
                                    {
                                        strHtm = ConvertDataTableToHTML_List(dtAcsibleCorps, "/Home/Compzit_Home/Compzit_Home_Gms.aspx");

                                    }
                                    divCorpList.InnerHtml = strHtm;
                                    //write list
                                    hiddenCorpList.Value = "ShowCorList";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowCorpList", "ShowCorpList();", true);
                                }
                                else
                                {
                                    if (blLimitedSts == true)
                                    {
                                        //  ScriptManager.RegisterStartupScript(this, GetType(), "HomeWindow", "HomeWindow();", true);
                                        Response.Redirect("/Home/Compzit_LandingPage/Compzit_LandingPage.aspx");
                                    }
                                    else
                                    {

                                        Response.Redirect("/Home/Compzit_Home/Compzit_Home_Gms.aspx");
                                    }
                                }
                            }
                        }
                        //APP
                        else if (intGmsCount == 0 && intSalesForceCount == 0 && intAppAdmistratnCount != 0 && intAwmsCount == 0 && intHcmCount == 0 && intFMSCount == 0 && intPMSCount == 0)
                        {
                            bool blLimitedSts = true;
                            if (intAppAdmistratnCount == 1 && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                            {
                                DataTable dtUserRole = objbusinessLayerLogin.Read_AppMenuDtl(intUserId, Convert.ToInt32(APPS.APP_ADMINSTRATION));
                                if (dtUserRole.Rows.Count > 0)
                                {
                                    int intUserRolMastrId = Convert.ToInt32(dtUserRole.Rows[0]["USROL_ID"].ToString());
                                    if (intUserRolMastrId == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.DesignationMaster))
                                    {
                                        blLimitedSts = false;
                                    }

                                }
                                else
                                {
                                    blLimitedSts = false;
                                }

                            }
                            if ((dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "O" || dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "o") && (Convert.ToInt16(dtLogin.Rows[0]["DSGTYP_ID"].ToString()) == Convert.ToInt16(clsCommonLibrary.DesignationType.OrganisationMosAdministrator)))
                            {
                                DataTable dtAllCorpOfc_ByOrgId = new DataTable();
                                dtAllCorpOfc_ByOrgId = objbusinessLayerLogin.Read_CorpOffc_ByOrgId(objEntLoginOControl);
                                if (dtAllCorpOfc_ByOrgId.Rows.Count > 0)
                                {
                                    if (dtAllCorpOfc_ByOrgId.Rows.Count == 1)
                                    {//take that corp offc by default
                                        int intCorpOffcId = Convert.ToInt32(dtAllCorpOfc_ByOrgId.Rows[0]["CORPRT_ID"].ToString());
                                        //   string strCorpName = dt.Rows[intRowBodyCount]["CORPRT_NAME"].ToString();
                                        clsCommonLibrary objCommon = new clsCommonLibrary();
                                        string strRandom = objCommon.Random_Number();

                                        string strId = intCorpOffcId.ToString();
                                        int intIdLength = strId.Length;
                                        string stridLength = intIdLength.ToString("00");
                                        string Id = stridLength + strId + strRandom;
                                        if (blLimitedSts == true)
                                        {
                                            Response.Redirect("/Home/Compzit_Home/Compzit_Home_App.aspx?CId=" + Id + "");

                                        }
                                    }
                                    else
                                    {
                                        string strHtm = "";
                                        if (blLimitedSts == true)
                                        {
                                            strHtm = ConvertDataTableToHTML_List(dtAllCorpOfc_ByOrgId, "/Home/Compzit_Home/Compzit_Home_App.aspx");
                                        }
                                        divCorpList.InnerHtml = strHtm;
                                        //write list
                                        hiddenCorpList.Value = "ShowCorList";
                                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowCorpList", "ShowCorpList();", true);
                                    }


                                }
                                else
                                {
                                    if (blLimitedSts == true)
                                    {
                                        Response.Redirect("/Home/Compzit_Home/Compzit_Home_App.aspx");
                                    }
                                }

                            }
                            else
                            {

                                if (dtAcsibleCorps.Rows.Count > 1)
                                {
                                    string strHtm = "";
                                    strHtm = ConvertDataTableToHTML_List(dtAcsibleCorps, "/Home/Compzit_Home/Compzit_Home_App.aspx");
                                    divCorpList.InnerHtml = strHtm;
                                    //write list
                                    hiddenCorpList.Value = "ShowCorList";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowCorpList", "ShowCorpList();", true);
                                }
                                else
                                {
                                    if (blLimitedSts == true)
                                    {
                                        Response.Redirect("/Home/Compzit_Home/Compzit_Home_App.aspx");
                                    }
                                }
                            }
                        }
                        //SFA
                        else if (intGmsCount == 0 && intSalesForceCount != 0 && intAppAdmistratnCount == 0 && intAwmsCount == 0 && intHcmCount == 0 && intFMSCount == 0 && intPMSCount == 0)
                        {
                            if ((dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "O" || dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "o") && (Convert.ToInt16(dtLogin.Rows[0]["DSGTYP_ID"].ToString()) == Convert.ToInt16(clsCommonLibrary.DesignationType.OrganisationMosAdministrator)))
                            {
                                DataTable dtAllCorpOfc_ByOrgId = new DataTable();
                                dtAllCorpOfc_ByOrgId = objbusinessLayerLogin.Read_CorpOffc_ByOrgId(objEntLoginOControl);
                                if (dtAllCorpOfc_ByOrgId.Rows.Count > 0)
                                {
                                    if (dtAllCorpOfc_ByOrgId.Rows.Count == 1)
                                    {//take that corp offc by default
                                        int intCorpOffcId = Convert.ToInt32(dtAllCorpOfc_ByOrgId.Rows[0]["CORPRT_ID"].ToString());
                                        //   string strCorpName = dt.Rows[intRowBodyCount]["CORPRT_NAME"].ToString();
                                        clsCommonLibrary objCommon = new clsCommonLibrary();
                                        string strRandom = objCommon.Random_Number();

                                        string strId = intCorpOffcId.ToString();
                                        int intIdLength = strId.Length;
                                        string stridLength = intIdLength.ToString("00");
                                        string Id = stridLength + strId + strRandom;
                                        Response.Redirect("/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx?CId=" + Id + "");

                                    }
                                    else
                                    {
                                        string strHtm = ConvertDataTableToHTML_List(dtAllCorpOfc_ByOrgId, "/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx");
                                        divCorpList.InnerHtml = strHtm;
                                        //write list
                                        hiddenCorpList.Value = "ShowCorList";
                                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowCorpList", "ShowCorpList();", true);
                                    }


                                }
                                else
                                {
                                    Response.Redirect("/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx");
                                }

                            }
                            else
                            {
                                if (dtAcsibleCorps.Rows.Count > 1)
                                {
                                    string strHtm = "";

                                    strHtm = ConvertDataTableToHTML_List(dtAcsibleCorps, "/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx");

                                    divCorpList.InnerHtml = strHtm;
                                    //write list
                                    hiddenCorpList.Value = "ShowCorList";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowCorpList", "ShowCorpList();", true);
                                }
                                else
                                {
                                    Response.Redirect("/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx");
                                }
                            }
                        }
                        //AWMS
                        else if (intGmsCount == 0 && intSalesForceCount == 0 && intAppAdmistratnCount == 0 && intAwmsCount != 0 && intHcmCount == 0 && intFMSCount == 0 && intPMSCount == 0)
                        {
                            if ((dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "O" || dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "o") && (Convert.ToInt16(dtLogin.Rows[0]["DSGTYP_ID"].ToString()) == Convert.ToInt16(clsCommonLibrary.DesignationType.OrganisationMosAdministrator)))
                            {
                                DataTable dtAllCorpOfc_ByOrgId = new DataTable();
                                dtAllCorpOfc_ByOrgId = objbusinessLayerLogin.Read_CorpOffc_ByOrgId(objEntLoginOControl);
                                if (dtAllCorpOfc_ByOrgId.Rows.Count > 0)
                                {
                                    if (dtAllCorpOfc_ByOrgId.Rows.Count == 1)
                                    {//take that corp offc by default
                                        int intCorpOffcId = Convert.ToInt32(dtAllCorpOfc_ByOrgId.Rows[0]["CORPRT_ID"].ToString());
                                        //   string strCorpName = dt.Rows[intRowBodyCount]["CORPRT_NAME"].ToString();
                                        clsCommonLibrary objCommon = new clsCommonLibrary();
                                        string strRandom = objCommon.Random_Number();

                                        string strId = intCorpOffcId.ToString();
                                        int intIdLength = strId.Length;
                                        string stridLength = intIdLength.ToString("00");
                                        string Id = stridLength + strId + strRandom;
                                        Response.Redirect("/Home/Compzit_Home/Compzit_Home_Awms.aspx?CId=" + Id + "");

                                    }
                                    else
                                    {
                                        string strHtm = ConvertDataTableToHTML_List(dtAllCorpOfc_ByOrgId, "/Home/Compzit_Home/Compzit_Home_Awms.aspx");
                                        divCorpList.InnerHtml = strHtm;
                                        //write list
                                        hiddenCorpList.Value = "ShowCorList";
                                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowCorpList", "ShowCorpList();", true);
                                    }


                                }
                                else
                                {
                                    Response.Redirect("/Home/Compzit_Home/Compzit_Home_Awms.aspx");
                                }

                            }
                            else
                            {
                                if (dtAcsibleCorps.Rows.Count > 1)
                                {
                                    string strHtm = "";

                                    strHtm = ConvertDataTableToHTML_List(dtAcsibleCorps, "/Home/Compzit_Home/Compzit_Home_Awms.aspx");

                                    divCorpList.InnerHtml = strHtm;
                                    //write list
                                    hiddenCorpList.Value = "ShowCorList";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowCorpList", "ShowCorpList();", true);
                                }
                                else
                                {
                                    Response.Redirect("/Home/Compzit_Home/Compzit_Home_Awms.aspx");
                                }
                            }
                        }
                        //GMS
                        else if (intGmsCount != 0 && intSalesForceCount == 0 && intAppAdmistratnCount == 0 && intAwmsCount == 0 && intHcmCount == 0 && intFMSCount == 0 && intPMSCount == 0)
                        {
                            if ((dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "O" || dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "o") && (Convert.ToInt16(dtLogin.Rows[0]["DSGTYP_ID"].ToString()) == Convert.ToInt16(clsCommonLibrary.DesignationType.OrganisationMosAdministrator)))
                            {
                                DataTable dtAllCorpOfc_ByOrgId = new DataTable();
                                dtAllCorpOfc_ByOrgId = objbusinessLayerLogin.Read_CorpOffc_ByOrgId(objEntLoginOControl);
                                if (dtAllCorpOfc_ByOrgId.Rows.Count > 0)
                                {
                                    if (dtAllCorpOfc_ByOrgId.Rows.Count == 1)
                                    {//take that corp offc by default
                                        int intCorpOffcId = Convert.ToInt32(dtAllCorpOfc_ByOrgId.Rows[0]["CORPRT_ID"].ToString());
                                        //   string strCorpName = dt.Rows[intRowBodyCount]["CORPRT_NAME"].ToString();
                                        clsCommonLibrary objCommon = new clsCommonLibrary();
                                        string strRandom = objCommon.Random_Number();

                                        string strId = intCorpOffcId.ToString();
                                        int intIdLength = strId.Length;
                                        string stridLength = intIdLength.ToString("00");
                                        string Id = stridLength + strId + strRandom;
                                        Response.Redirect("/Home/Compzit_Home/Compzit_Home_Gms.aspx?CId=" + Id + "");

                                    }
                                    else
                                    {
                                        string strHtm = ConvertDataTableToHTML_List(dtAllCorpOfc_ByOrgId, "/Home/Compzit_Home/Compzit_Home_Gms.aspx");
                                        divCorpList.InnerHtml = strHtm;
                                        //write list
                                        hiddenCorpList.Value = "ShowCorList";
                                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowCorpList", "ShowCorpList();", true);
                                    }


                                }
                                else
                                {
                                    Response.Redirect("/Home/Compzit_Home/Compzit_Home_Gms.aspx");
                                }

                            }
                            else
                            {
                                if (dtAcsibleCorps.Rows.Count > 1)
                                {
                                    string strHtm = "";

                                    strHtm = ConvertDataTableToHTML_List(dtAcsibleCorps, "/Home/Compzit_Home/Compzit_Home_Gms.aspx");

                                    divCorpList.InnerHtml = strHtm;
                                    //write list
                                    hiddenCorpList.Value = "ShowCorList";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowCorpList", "ShowCorpList();", true);
                                }
                                else
                                {
                                    Response.Redirect("/Home/Compzit_Home/Compzit_Home_Gms.aspx");
                                }
                            }
                        }
                        //AWMS & APP
                        else if (intGmsCount == 0 && intSalesForceCount == 0 && intAppAdmistratnCount != 0 && intAwmsCount != 0 && intHcmCount == 0 && intFMSCount == 0 && intPMSCount == 0)
                        {
                            bool blLimitedSts = true;
                            if (intAppAdmistratnCount == 1 && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                            {
                                DataTable dtUserRole = objbusinessLayerLogin.Read_AppMenuDtl(intUserId, Convert.ToInt32(APPS.APP_ADMINSTRATION));
                                if (dtUserRole.Rows.Count > 0)
                                {
                                    int intUserRolMastrId = Convert.ToInt32(dtUserRole.Rows[0]["USROL_ID"].ToString());
                                    if (intUserRolMastrId == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.DesignationMaster))
                                    {
                                        blLimitedSts = false;
                                    }

                                }
                                else
                                {
                                    blLimitedSts = false;
                                }

                            }
                            if ((dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "O" || dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "o") && (Convert.ToInt16(dtLogin.Rows[0]["DSGTYP_ID"].ToString()) == Convert.ToInt16(clsCommonLibrary.DesignationType.OrganisationMosAdministrator)))
                            {
                                DataTable dtAllCorpOfc_ByOrgId = new DataTable();
                                dtAllCorpOfc_ByOrgId = objbusinessLayerLogin.Read_CorpOffc_ByOrgId(objEntLoginOControl);
                                if (dtAllCorpOfc_ByOrgId.Rows.Count > 0)
                                {
                                    if (dtAllCorpOfc_ByOrgId.Rows.Count == 1)
                                    {//take that corp offc by default
                                        int intCorpOffcId = Convert.ToInt32(dtAllCorpOfc_ByOrgId.Rows[0]["CORPRT_ID"].ToString());
                                        //   string strCorpName = dt.Rows[intRowBodyCount]["CORPRT_NAME"].ToString();
                                        clsCommonLibrary objCommon = new clsCommonLibrary();
                                        string strRandom = objCommon.Random_Number();

                                        string strId = intCorpOffcId.ToString();
                                        int intIdLength = strId.Length;
                                        string stridLength = intIdLength.ToString("00");
                                        string Id = stridLength + strId + strRandom;
                                        if (blLimitedSts == true)
                                        {
                                            Response.Redirect("/Home/Compzit_LandingPage/Compzit_LandingPage.aspx?CId=" + Id + "");
                                        }
                                        else
                                        {
                                            Response.Redirect("/Home/Compzit_Home/Compzit_Home_Awms.aspx?CId=" + Id + "");
                                        }
                                    }
                                    else
                                    {
                                        string strHtm = "";
                                        if (blLimitedSts == true)
                                        {
                                            strHtm = ConvertDataTableToHTML_List(dtAllCorpOfc_ByOrgId, "/Home/Compzit_LandingPage/Compzit_LandingPage.aspx");
                                        }
                                        else
                                        {
                                            strHtm = ConvertDataTableToHTML_List(dtAllCorpOfc_ByOrgId, "/Home/Compzit_Home/Compzit_Home_Awms.aspx");

                                        }
                                        divCorpList.InnerHtml = strHtm;
                                        //write list
                                        hiddenCorpList.Value = "ShowCorList";
                                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowCorpList", "ShowCorpList();", true);
                                    }


                                }
                                else
                                {
                                    if (blLimitedSts == true)
                                    {
                                        Response.Redirect("/Home/Compzit_LandingPage/Compzit_LandingPage.aspx");
                                    }
                                    else
                                    {

                                        Response.Redirect("/Home/Compzit_Home/Compzit_Home_Awms.aspx");
                                    }
                                }

                            }
                            else
                            {

                                if (dtAcsibleCorps.Rows.Count > 1)
                                {
                                    string strHtm = "";

                                    strHtm = ConvertDataTableToHTML_List(dtAcsibleCorps, "/Home/Compzit_Home/Compzit_Home_Awms.aspx");

                                    divCorpList.InnerHtml = strHtm;
                                    //write list
                                    hiddenCorpList.Value = "ShowCorList";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowCorpList", "ShowCorpList();", true);
                                }
                                else
                                {
                                    if (blLimitedSts == true)
                                    {
                                        //  ScriptManager.RegisterStartupScript(this, GetType(), "HomeWindow", "HomeWindow();", true);
                                        Response.Redirect("/Home/Compzit_LandingPage/Compzit_LandingPage.aspx");
                                    }
                                    else
                                    {

                                        Response.Redirect("/Home/Compzit_Home/Compzit_Home_Awms.aspx");
                                    }
                                }
                            }


                        }
                        //hcm only
                        else if (intGmsCount == 0 && intSalesForceCount == 0 && intAppAdmistratnCount == 0 && intAwmsCount == 0 && intHcmCount != 0 && intFMSCount == 0 && intPMSCount == 0)
                        {
                            if ((dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "O" || dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "o") && (Convert.ToInt16(dtLogin.Rows[0]["DSGTYP_ID"].ToString()) == Convert.ToInt16(clsCommonLibrary.DesignationType.OrganisationMosAdministrator)))
                            {
                                DataTable dtAllCorpOfc_ByOrgId = new DataTable();
                                dtAllCorpOfc_ByOrgId = objbusinessLayerLogin.Read_CorpOffc_ByOrgId(objEntLoginOControl);
                                if (dtAllCorpOfc_ByOrgId.Rows.Count > 0)
                                {
                                    if (dtAllCorpOfc_ByOrgId.Rows.Count == 1)
                                    {//take that corp offc by default
                                        int intCorpOffcId = Convert.ToInt32(dtAllCorpOfc_ByOrgId.Rows[0]["CORPRT_ID"].ToString());
                                        //   string strCorpName = dt.Rows[intRowBodyCount]["CORPRT_NAME"].ToString();
                                        clsCommonLibrary objCommon = new clsCommonLibrary();
                                        string strRandom = objCommon.Random_Number();

                                        string strId = intCorpOffcId.ToString();
                                        int intIdLength = strId.Length;
                                        string stridLength = intIdLength.ToString("00");
                                        string Id = stridLength + strId + strRandom;
                                        Response.Redirect("/Home/Compzit_Home/Compzit_Home_Hcm.aspx?CId=" + Id + "");

                                    }
                                    else
                                    {
                                        string strHtm = ConvertDataTableToHTML_List(dtAllCorpOfc_ByOrgId, "/Home/Compzit_Home/Compzit_Home_Hcm.aspx");
                                        divCorpList.InnerHtml = strHtm;
                                        //write list
                                        hiddenCorpList.Value = "ShowCorList";
                                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowCorpList", "ShowCorpList();", true);
                                    }


                                }
                                else
                                {
                                    Response.Redirect("/Home/Compzit_Home/Compzit_Home_Hcm.aspx");
                                }

                            }
                            else
                            {
                                if (dtAcsibleCorps.Rows.Count > 1)
                                {
                                    string strHtm = "";

                                    strHtm = ConvertDataTableToHTML_List(dtAcsibleCorps, "/Home/Compzit_Home/Compzit_Home_Hcm.aspx");

                                    divCorpList.InnerHtml = strHtm;
                                    //write list
                                    hiddenCorpList.Value = "ShowCorList";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowCorpList", "ShowCorpList();", true);
                                }
                                else
                                {
                                    Response.Redirect("/Home/Compzit_Home/Compzit_Home_Hcm.aspx?");
                                }
                            }



                            //else
                            //{
                            //    Response.Redirect("/Home/Compzit_Home/Compzit_Home_Hcm.aspx?");
                            //}
                        }
                        //16-03-2019
                        //FMS only
                        else if (intGmsCount == 0 && intSalesForceCount == 0 && intAppAdmistratnCount == 0 && intAwmsCount == 0 && intHcmCount == 0 && intFMSCount != 0 && intPMSCount == 0)
                        {
                            if ((dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "O" || dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "o") && (Convert.ToInt16(dtLogin.Rows[0]["DSGTYP_ID"].ToString()) == Convert.ToInt16(clsCommonLibrary.DesignationType.OrganisationMosAdministrator)))
                            {
                                DataTable dtAllCorpOfc_ByOrgId = new DataTable();
                                dtAllCorpOfc_ByOrgId = objbusinessLayerLogin.Read_CorpOffc_ByOrgId(objEntLoginOControl);
                                if (dtAllCorpOfc_ByOrgId.Rows.Count > 0)
                                {
                                    if (dtAllCorpOfc_ByOrgId.Rows.Count == 1)
                                    {//take that corp offc by default
                                        int intCorpOffcId = Convert.ToInt32(dtAllCorpOfc_ByOrgId.Rows[0]["CORPRT_ID"].ToString());
                                        //   string strCorpName = dt.Rows[intRowBodyCount]["CORPRT_NAME"].ToString();
                                        clsCommonLibrary objCommon = new clsCommonLibrary();
                                        string strRandom = objCommon.Random_Number();

                                        string strId = intCorpOffcId.ToString();
                                        int intIdLength = strId.Length;
                                        string stridLength = intIdLength.ToString("00");
                                        string Id = stridLength + strId + strRandom;
                                        Response.Redirect("/Home/Compzit_Home/Compzit_Home_Hcm.aspx?CId=" + Id + "");

                                    }
                                    else
                                    {
                                        string strHtm = ConvertDataTableToHTML_List(dtAllCorpOfc_ByOrgId, "/Home/Compzit_Home/Compzit_Home_Finance.aspx");
                                        divCorpList.InnerHtml = strHtm;
                                        //write list
                                        hiddenCorpList.Value = "ShowCorList";
                                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowCorpList", "ShowCorpList();", true);
                                    }


                                }
                                else
                                {
                                    Response.Redirect("/Home/Compzit_Home/Compzit_Home_Finance.aspx");
                                }

                            }
                            else
                            {
                                if (dtAcsibleCorps.Rows.Count > 1)
                                {
                                    string strHtm = "";

                                    strHtm = ConvertDataTableToHTML_List(dtAcsibleCorps, "/Home/Compzit_Home/Compzit_Home_Finance.aspx");

                                    divCorpList.InnerHtml = strHtm;
                                    //write list
                                    hiddenCorpList.Value = "ShowCorList";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowCorpList", "ShowCorpList();", true);
                                }
                                else
                                {
                                    Response.Redirect("/Home/Compzit_Home/Compzit_Home_Finance.aspx?");
                                }
                            }



                            //else
                            //{
                            //    Response.Redirect("/Home/Compzit_Home/Compzit_Home_Hcm.aspx?");
                            //}
                        }


                            //end 16-03-2019


                        //hcm and app only
                        else if (intGmsCount == 0 && intSalesForceCount == 0 && intAppAdmistratnCount != 0 && intAwmsCount == 0 && intHcmCount != 0 && intFMSCount == 0)
                        {
                            bool blLimitedSts = true;
                            if (intAppAdmistratnCount == 1 && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                            {
                                DataTable dtUserRole = objbusinessLayerLogin.Read_AppMenuDtl(intUserId, Convert.ToInt32(APPS.APP_ADMINSTRATION));
                                if (dtUserRole.Rows.Count > 0)
                                {
                                    int intUserRolMastrId = Convert.ToInt32(dtUserRole.Rows[0]["USROL_ID"].ToString());
                                    if (intUserRolMastrId == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.DesignationMaster))
                                    {
                                        blLimitedSts = false;
                                    }

                                }
                                else
                                {
                                    blLimitedSts = false;
                                }

                            }
                            if ((dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "O" || dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "o") && (Convert.ToInt16(dtLogin.Rows[0]["DSGTYP_ID"].ToString()) == Convert.ToInt16(clsCommonLibrary.DesignationType.OrganisationMosAdministrator)))
                            {
                                DataTable dtAllCorpOfc_ByOrgId = new DataTable();
                                dtAllCorpOfc_ByOrgId = objbusinessLayerLogin.Read_CorpOffc_ByOrgId(objEntLoginOControl);
                                if (dtAllCorpOfc_ByOrgId.Rows.Count > 0)
                                {
                                    if (dtAllCorpOfc_ByOrgId.Rows.Count == 1)
                                    {//take that corp offc by default
                                        int intCorpOffcId = Convert.ToInt32(dtAllCorpOfc_ByOrgId.Rows[0]["CORPRT_ID"].ToString());
                                        //   string strCorpName = dt.Rows[intRowBodyCount]["CORPRT_NAME"].ToString();
                                        clsCommonLibrary objCommon = new clsCommonLibrary();
                                        string strRandom = objCommon.Random_Number();

                                        string strId = intCorpOffcId.ToString();
                                        int intIdLength = strId.Length;
                                        string stridLength = intIdLength.ToString("00");
                                        string Id = stridLength + strId + strRandom;
                                        if (blLimitedSts == true)
                                        {
                                            Response.Redirect("/Home/Compzit_LandingPage/Compzit_LandingPage.aspx?CId=" + Id + "");
                                        }
                                        else
                                        {
                                            Response.Redirect("/Home/Compzit_Home/Compzit_Home_Hcm.aspx?CId=" + Id + "");
                                        }
                                    }
                                    else
                                    {
                                        string strHtm = "";
                                        if (blLimitedSts == true)
                                        {
                                            strHtm = ConvertDataTableToHTML_List(dtAllCorpOfc_ByOrgId, "/Home/Compzit_LandingPage/Compzit_LandingPage.aspx");
                                        }
                                        else
                                        {
                                            strHtm = ConvertDataTableToHTML_List(dtAllCorpOfc_ByOrgId, "/Home/Compzit_Home/Compzit_Home_Hcm.aspx");

                                        }
                                        divCorpList.InnerHtml = strHtm;
                                        //write list
                                        hiddenCorpList.Value = "ShowCorList";
                                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowCorpList", "ShowCorpList();", true);
                                    }
                                }
                                else
                                {
                                    if (blLimitedSts == true)
                                    {
                                        Response.Redirect("/Home/Compzit_LandingPage/Compzit_LandingPage.aspx");
                                    }
                                    else
                                    {

                                        Response.Redirect("/Home/Compzit_Home/Compzit_Home_Hcm.aspx");
                                    }
                                }

                            }
                            else
                            {
                                if (dtAcsibleCorps.Rows.Count > 1)
                                {
                                    string strHtm = "";
                                    if (blLimitedSts == true)
                                    {
                                        strHtm = ConvertDataTableToHTML_List(dtAcsibleCorps, "/Home/Compzit_LandingPage/Compzit_LandingPage.aspx");
                                    }
                                    else
                                    {
                                        strHtm = ConvertDataTableToHTML_List(dtAcsibleCorps, "/Home/Compzit_Home/Compzit_Home_Hcm.aspx");

                                    }
                                    divCorpList.InnerHtml = strHtm;
                                    //write list
                                    hiddenCorpList.Value = "ShowCorList";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowCorpList", "ShowCorpList();", true);
                                }
                                else
                                {
                                    if (blLimitedSts == true)
                                    {
                                        Response.Redirect("/Home/Compzit_LandingPage/Compzit_LandingPage.aspx");
                                    }
                                    else
                                    {

                                        Response.Redirect("/Home/Compzit_Home/Compzit_Home_Hcm.aspx");
                                    }
                                }
                            }
                        }
                        //PMS
                        else if (intGmsCount == 0 && intSalesForceCount == 0 && intAppAdmistratnCount == 0 && intAwmsCount == 0 && intHcmCount == 0 && intFMSCount == 0 && intPMSCount != 0)
                        {
                            if ((dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "O" || dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "o") && (Convert.ToInt16(dtLogin.Rows[0]["DSGTYP_ID"].ToString()) == Convert.ToInt16(clsCommonLibrary.DesignationType.OrganisationMosAdministrator)))
                            {
                                DataTable dtAllCorpOfc_ByOrgId = new DataTable();
                                dtAllCorpOfc_ByOrgId = objbusinessLayerLogin.Read_CorpOffc_ByOrgId(objEntLoginOControl);
                                if (dtAllCorpOfc_ByOrgId.Rows.Count > 0)
                                {
                                    if (dtAllCorpOfc_ByOrgId.Rows.Count == 1)
                                    {//take that corp offc by default

                                        int intCorpOffcId = Convert.ToInt32(dtAllCorpOfc_ByOrgId.Rows[0]["CORPRT_ID"].ToString());
                                        clsCommonLibrary objCommon = new clsCommonLibrary();
                                        string strRandom = objCommon.Random_Number();

                                        string strId = intCorpOffcId.ToString();
                                        int intIdLength = strId.Length;
                                        string stridLength = intIdLength.ToString("00");
                                        string Id = stridLength + strId + strRandom;
                                        Response.Redirect("/Home/Compzit_Home/Compzit_Home_Hcm.aspx?CId=" + Id + "");

                                    }
                                    else
                                    {
                                        string strHtm = ConvertDataTableToHTML_List(dtAllCorpOfc_ByOrgId, "/Home/Compzit_Home/Compzit_Home_Finance.aspx");
                                        divCorpList.InnerHtml = strHtm;
                                        
                                        //write list
                                        hiddenCorpList.Value = "ShowCorList";
                                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowCorpList", "ShowCorpList();", true);
                                    }
                                }
                                else
                                {
                                    Response.Redirect("/Home/Compzit_Home/Compzit_Home_Finance.aspx");
                                }
                            }
                            else
                            {
                                if (dtAcsibleCorps.Rows.Count > 1)
                                {
                                    string strHtm = "";
                                    strHtm = ConvertDataTableToHTML_List(dtAcsibleCorps, "/Home/Compzit_Home/Compzit_Home_Finance.aspx");
                                    divCorpList.InnerHtml = strHtm;
                                    
                                    //write list
                                    hiddenCorpList.Value = "ShowCorList";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowCorpList", "ShowCorpList();", true);
                                }
                                else
                                {
                                    Response.Redirect("/Home/Compzit_Home/Compzit_Home_Finance.aspx?");
                                }
                            }
                        }

                        else
                        {
                            int intTotalApps = 0;
                            if (intGmsCount != 0)
                            {
                                intTotalApps++;
                            }
                            if (intSalesForceCount != 0)
                            {
                                intTotalApps++;
                            }
                            if (intAppAdmistratnCount != 0)
                            {
                                intTotalApps++;
                            }
                            if (intAwmsCount != 0)
                            {
                                intTotalApps++;
                            }
                            if (intHcmCount != 0)
                            {
                                intTotalApps++;
                            }
                            if (intFMSCount != 0)
                            {
                                intTotalApps++;
                            }
                            if (intPMSCount != 0)
                            {
                                intTotalApps++;
                            }
                            if (intTotalApps > 1)
                            {
                                if (dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "C" || dtLogin.Rows[0]["DSGN_CONTROL"].ToString() == "c")
                                {
                                    if (dtAcsibleCorps.Rows.Count > 1)
                                    {
                                        string strHtm = "";
                                        strHtm = ConvertDataTableToHTML_List(dtAcsibleCorps, "/Home/Compzit_LandingPage/Compzit_LandingPage.aspx");
                                        divCorpList.InnerHtml = strHtm;
                                        //write list
                                        hiddenCorpList.Value = "ShowCorList";
                                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowCorpList", "ShowCorpList();", true);
                                    }
                                    else
                                    {
                                        Response.Redirect("/Home/Compzit_LandingPage/Compzit_LandingPage.aspx");
                                    }
                                }
                            }
                        }

                        //Start:-Framework
                    }
                    //End:-Framework

                }
            }
            else
            {
                txtPassword.Value = "";
                if (blCheckTemplateAppadmin == true)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert1", "<script>alert('Sorry, Please create email templates for all email template types!');window.close();</script>");
                }
                else if (blDefaultMailTemplateExists == true)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert2", "<script>alert('Sorry, Please update default email templates for all verification & intimation in configuration!');window.close();</script>");
                }
            }



        }
        //If user id =1 then there user email id and user password are existed.
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Email id or password is incorrect, Please try again!')</script>");
            txtPassword.Focus();
        }
    }


    //It build the Html List by using the datatable provided
    public string ConvertDataTableToHTML_List(DataTable dt, string strUrl)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<h2 >Choose Corporate Office</h2>";
        strHtml += "</br>";
        //add ul
        strHtml += "<ul class=\"ulCorp\">";

        //add li

        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            int intCorpOffcId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CORPRT_ID"].ToString());
            string strCorpName = dt.Rows[intRowBodyCount]["CORPRT_NAME"].ToString();

            strHtml += "<li style=\"cursor: pointer;\" class=\"liCorp\">";


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

            strHtml += " <a style=\"cursor: pointer;\"  onclick='return getdetails(this.href);' " +
                          " href=\"" + strUrl + "?CId=" + Id + "\">" + strCorpName + "</a>";

            strHtml += "</li>";

        }

        strHtml += "</ul>";
        sb.Append(strHtml);
        return sb.ToString();
    }




    //Method for fetch the server port and domain name.
    public string GetServerDetail()
    {
        string strDomainName = Request.ServerVariables["server_name"].ToString();
        string strPort = Request.ServerVariables["server_port"].ToString();
        string strHostAddr = strDomainName + ":" + strPort;
        return strHostAddr;

    }


    protected void hide_mydiv_Click(object sender, EventArgs e)
    {
        //Creating object for clsMail  in the MailUtility Layer
        clsMail objMail = new clsMail();

        EL_Compzit.clsEntityLayerLogin objEntLogin = new EL_Compzit.clsEntityLayerLogin();
        objEntLogin.UserEmail = TxtMailArea.Value;

        //Creating objects for business layer login.
        clsBusinessLayerLogin objbusinessLayerLogin = new clsBusinessLayerLogin();
        DataTable dtOrgStatusNotify = new DataTable();
        dtOrgStatusNotify = objbusinessLayerLogin.CheckReSendMAil_Notify(objEntLogin);
        //to check if organisation present with given email id and find its detail
        if (dtOrgStatusNotify.Rows.Count > 0)
        {
            string OrgParkID = dtOrgStatusNotify.Rows[0]["ORG_PARK_ID"].ToString();

            string strOrgStatus = dtOrgStatusNotify.Rows[0]["ORG_PARK_STATUS_ID"].ToString();
            string strOrgName = dtOrgStatusNotify.Rows[0]["ORG_PARK_NAME"].ToString();
            string strOrgVerifyCode = dtOrgStatusNotify.Rows[0]["ORG_PARK_VERIFY_CODE"].ToString();
            string strOrgVerifyLink = "http://" + GetServerDetail() + "/Master/gen_Org_Verification/gen_Org_Verification.aspx";

            //if Status is NEW
            if (Convert.ToInt16(strOrgStatus) == Convert.ToInt16(clsCommonLibrary.Status.Status_New))
            {



                clsBusinessLayer objBusines = new clsBusinessLayer();
                DataTable dtConfigDtl = new DataTable();
                dtConfigDtl = objBusines.LoadConfigDetail();

                string strTemplateId = "";
                if (dtConfigDtl.Rows.Count > 0)
                {

                    strTemplateId = dtConfigDtl.Rows[0]["DFLT_ORG_EMTMPLT_ID"].ToString();
                }
                int intTemplateId = Convert.ToInt32(strTemplateId);
                Int64 intTransId = Convert.ToInt64(OrgParkID);
                string strTransId = OrgParkID;

                clsEntityOrgParking objEntityOrgParking = new clsEntityOrgParking();
                objEntityOrgParking.Organisation_Name = strOrgName;
                objEntityOrgParking.Verification_Code = strOrgVerifyCode;
                objEntityOrgParking.Verification_Link = strOrgVerifyLink;


                //to check in email store table
                string strCheckCount = objbusinessLayerLogin.CheckEmailStore(intTransId, intTemplateId);
                //if no record found in GN_EMAIL_STORE with given Transaction Id and tempalte id
                if (strCheckCount == "0")
                {
                    //Creating object for clsBusinessLayer Mail in in the BusinessLayer
                    clsBusinessLayerMail objBusinessLayerMail = new clsBusinessLayerMail();
                    DataTable dtCompanyDetail = new DataTable();

                    dtCompanyDetail = objBusinessLayerMail.SelectCompanyDetails();
                    DataTable dtTemplateDetail = new DataTable();

                    objMail.InstantMail(strTemplateId, ref dtTemplateDetail);
                    // inserting to Gn_EMAIL_STORE
                    objBusinessLayerMail.InstantMailInsert(strTemplateId, TxtMailArea.Value, strTransId, dtCompanyDetail, dtTemplateDetail);
                    //sending mail
                    objMail.BulkMail(strTemplateId, strTransId, dtCompanyDetail, objEntityOrgParking);
                }
                else
                {



                    //Creating object for clsBusinessLayer Mail in in the BusinessLayer
                    clsBusinessLayerMail objBusinessLayerMail = new clsBusinessLayerMail();
                    DataTable dtCompanyDetail = new DataTable();

                    dtCompanyDetail = objBusinessLayerMail.SelectCompanyDetails();

                    //sending mail
                    objMail.BulkMail(strTemplateId, strTransId, dtCompanyDetail, objEntityOrgParking);

                }
            }



            //if Status is ApprovalPending
            else if (Convert.ToInt16(strOrgStatus) == Convert.ToInt16(clsCommonLibrary.Status.Status_ApprovalPending))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert(' Sorry, Cannot send mail again. This is an approval pending mail id!')</script>");


            }
            //if Status is Approved
            else if (Convert.ToInt16(strOrgStatus) == Convert.ToInt16(clsCommonLibrary.Status.Status_Approved))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert(' Sorry, Cannot send mail again. This mail id is already verified!')</script>");



            }
            //if Status is Rejected
            else if (Convert.ToInt16(strOrgStatus) == Convert.ToInt16(clsCommonLibrary.Status.Status_Rejected))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert(' Sorry, Cannot send mail again. This mail id is already rejected!')</script>");


            }

        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert(' Sorry, This email id is not registered. Select registration link for new organization!')</script>");

        }


        TxtMailArea.Value = "";
    }
}