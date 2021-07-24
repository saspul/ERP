using BL_Compzit;
using CL_Compzit;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using System.Web.UI.HtmlControls;
using Newtonsoft.Json;
using System.Web.Services;
using BL_Compzit.BusineesLayer_FMS;
using EL_Compzit.EntityLayer_FMS;

public partial class MasterPage_MasterPageCompzit : System.Web.UI.MasterPage
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
        AUTO_WORKSHOP_MANAGEMENT_SYSTEM = 3,
        GUARANTEE_MANAGEMENT_SYSTEM = 4,
        HUMAN_CAPITAL_MANAGEMENT_SYSTEM = 5,
        FINANCE_MANAGEMENT_SYSTEM = 6,
        PROCUREMENT_MANAGEMENT_SYSTEM = 7,
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hiddenMailIconVisible.Value = "false";
            int intUserId = 0, intAllEnableMail = 0, intCorpId = 0, intOrgId = 0;
            bool blShowMailIcon = true;
            if (!Request.FilePath.Contains("Default"))
            {
                string strPreviousPage = "";
                if (Request.UrlReferrer != null)
                {
                    strPreviousPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
                }
                if (strPreviousPage == "")
                {
                   Response.Redirect("~/Default.aspx");
                }
            }
            clsCommonLibrary objCommon = new clsCommonLibrary();
            DataTable dtConfigDtl = new DataTable();
            clsBusinessLayer objBusines = new clsBusinessLayer();
            clsBusinessLayerLogin objBusinessLogin = new clsBusinessLayerLogin();
            dtConfigDtl = objBusines.LoadConfigDetail();
            string strCompanyName = "", strCompanyWeb = "";
            string strDvlprInfo = "0";
            string strProductName = "";
            if (dtConfigDtl.Rows.Count > 0)
            {
                strDvlprInfo = dtConfigDtl.Rows[0]["DVLPR_INFO"].ToString().Trim();
                strProductName = dtConfigDtl.Rows[0]["PRODUCT_NAME"].ToString().Trim();
            }

            if (strDvlprInfo == "1")
            {

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
                divdevelop.InnerHtml = "Designed by <a target= \"_blank \" href=\"" + strCompanyWeb + "\">" + strCompanyName + "</a> ";
            }
            else
            {
                divdevelop.InnerHtml = "";

            }

            string strMenuCount = "";
            string strFrequentCount = "";
            string strStatus = "";

            if (Session["CORPOFFICEID"] != null)
            {
                clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = { clsCommonLibrary.CORP_GLOBAL.GN_APP_HEADER_COLOR, 
                                                             clsCommonLibrary.CORP_GLOBAL.GN_APP_FOOTER_COLOR,
                                                             clsCommonLibrary.CORP_GLOBAL.MENU_STATUS, 
                                                             clsCommonLibrary.CORP_GLOBAL.RECNT_COUNT, 
                                                             clsCommonLibrary.CORP_GLOBAL.FREQNT_COUNT
                                                           };
                DataTable dtCorpDetail = new DataTable();


                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);

                dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                if (dtCorpDetail.Rows.Count > 0)
                {
                    hiddenHeaderColor.Value = dtCorpDetail.Rows[0]["GN_APP_HEADER_COLOR"].ToString();
                    hiddenFooterColor.Value = dtCorpDetail.Rows[0]["GN_APP_FOOTER_COLOR"].ToString();

                    //for frequent and recent menu
                    strStatus = dtCorpDetail.Rows[0]["MENU_STATUS"].ToString();
                    strMenuCount = dtCorpDetail.Rows[0]["RECNT_COUNT"].ToString();
                    strFrequentCount = dtCorpDetail.Rows[0]["FREQNT_COUNT"].ToString();
                }
                clsEntityCommon ObjEntityCommon = new clsEntityCommon();
                ObjEntityCommon.CorporateID = intCorpId;
                DataTable dtCorp = objBusinessLayer.ReadCorpDetails(ObjEntityCommon);
                if (dtCorp.Rows.Count > 0)
                {
                    if (dtCorp.Rows[0]["CORPRT_ICON"].ToString() != "")
                    {
                        string imaeposition = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
                        string icon = dtCorp.Rows[0]["CORPRT_ICON"].ToString();
                        CorpIcon.ImageUrl = imaeposition + icon;
                        CorpName.InnerHtml = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
                    }
                    else
                    {
                        CorpIcon.ImageUrl = "/Images/New Images/images/dm_logo.png";
                        CorpName.InnerHtml = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
                    }
                }
            }
            EL_Compzit.clsEntityLayerLogin objEntityLogin = null;
            objEntityLogin = new EL_Compzit.clsEntityLayerLogin();
            if (Session["USERNAME"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                lblUserName.InnerText = Session["USERNAME"].ToString();
                //h1AccntSettingName.InnerHtml = lblUserName.Text;
            }
            if (Session["USERID"] != null)
            {
                objEntityLogin.UserIdInt = Convert.ToInt32(Session["USERID"].ToString());
                intUserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["WRKSTNID"] != null)
            {
                objEntityLogin.WorkStatnId = Convert.ToInt32(Session["WRKSTNID"].ToString());
            }
            else if (Session["WRKSTNID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityLogin.AppType = 'W';
            if (Session["APP_ID"] != null)
            {
                objEntityLogin.Cmp_AppId = Convert.ToInt32(Session["APP_ID"]);
            }

            if (Session["FRMWRK_ID"] != null)
            {
                objEntityLogin.FrameworkId = Convert.ToInt32(Session["FRMWRK_ID"].ToString());
            }
            if (Session["FRMWRK_TYPE"] != null)
            {
                objEntityLogin.FrameworkTypId = Convert.ToInt32(Session["FRMWRK_TYPE"].ToString());
            }

            if (Session["CORPOFFICEID"] != null)
            {


                objEntityLogin.CorpOfficeId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else
            {

                        // Changed code 31-7-2020 for the purpose of checking the type of user

                         if (!(((Session["DSGN_CONTROL"].ToString() == "O" || Session["DSGN_CONTROL"].ToString() == "o") && (Convert.ToInt16(Session["DSGN_TYPID"].ToString()) == Convert.ToInt16(clsCommonLibrary.DesignationType.OrganisationMosAdministrator))) || ((Session["DSGN_CONTROL"].ToString() == "O" || Session["DSGN_CONTROL"].ToString() == "o") && (Convert.ToInt16(Session["DSGN_TYPID"].ToString()) == Convert.ToInt16(clsCommonLibrary.DesignationType.App_Administrator)))))
                            {
                             Response.Redirect("~/Default.aspx");
                            }
            }
            if (Session["ORGID"] != null)
            {
                objEntityLogin.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else
            {
                          // Changed code 31-7-2020 for the purpose of checking the app admin

                        if (!((Session["DSGN_CONTROL"].ToString() == "O" || Session["DSGN_CONTROL"].ToString() == "o") && (Convert.ToInt16(Session["DSGN_TYPID"].ToString()) == Convert.ToInt16(clsCommonLibrary.DesignationType.App_Administrator))))
                              {
                               Response.Redirect("~/Default.aspx");
                              }
            }

            if (Session["APP_ID"] != null)
            {
                objEntityLogin.Cmp_AppId = Convert.ToInt32(Session["APP_ID"].ToString());
            }


            if (Session["APP_ID"] != null && Session["APP_ID"].ToString() == "6")//Finance
            {
                //EVM 040
                clsBusiness_Account_Setting objBussinessAccount = new clsBusiness_Account_Setting();
                clsEntity_Account_Setting objEntityAccount = new clsEntity_Account_Setting();

                objEntityAccount.CorpId = objEntityLogin.CorpOfficeId;
                objEntityAccount.OrgId = objEntityLogin.OrgId;

                DataTable dtSubConrt = objBussinessAccount.ReadFinancialYear(objEntityAccount);
                for (int intCount = 0; intCount < dtSubConrt.Rows.Count; intCount++)
                {
                    if (Convert.ToString(Session["FINCYRID"]) == dtSubConrt.Rows[intCount]["FINCYR_ID"].ToString())
                    {
                        HiddenFinancialYear.Value = dtSubConrt.Rows[intCount]["FINCYR_DEFAULTNAME"].ToString();
                        Session["FINCYEAR_NAME"] = dtSubConrt.Rows[intCount]["FINCYR_DEFAULTNAME"].ToString(); //0043 
                    }
                }
                //EVM 040
            }
            else
            {
                spanFiscal.InnerHtml = "";
            }


            clsBusinessLayerMenu objBusinessMenu = new clsBusinessLayerMenu();

            //frequent and recent menu
            StringBuilder objstrbRecent = new StringBuilder();
            StringBuilder objstrbFrequent = new StringBuilder();

            if (strStatus != "")
            {
                if (strStatus == "0")
                {
                    if (strMenuCount != "0" && strFrequentCount != "0")
                    {
                        objstrbRecent = objBusinessMenu.GetMenuDataForRecentMenuNew(objEntityLogin, intUserId, strMenuCount);
                        objstrbFrequent = objBusinessMenu.GetMenuDataForFrequentlyMenuNew(objEntityLogin, intUserId, strFrequentCount);

                        divRecent.InnerHtml = objstrbRecent.ToString();
                        divFrequent.InnerHtml = objstrbFrequent.ToString();
                    }
                }
                else if (strStatus == "1")
                {
                    if (strMenuCount != "0")
                    {
                        objstrbRecent = objBusinessMenu.GetMenuDataForRecentMenuNew(objEntityLogin, intUserId, strMenuCount);

                        divRecent.InnerHtml = objstrbRecent.ToString();
                    }
                }
                else if (strStatus == "2")
                {
                    if (strFrequentCount != "0")
                    {
                        objstrbFrequent = objBusinessMenu.GetMenuDataForFrequentlyMenuNew(objEntityLogin, intUserId, strFrequentCount);

                        divFrequent.InnerHtml = objstrbFrequent.ToString();
                    }
                }
            }

            //---------------menu--------------------

            StringBuilder objstrb = new StringBuilder();
            objstrb = objBusinessMenu.GetMenuDataCompzitNew(objEntityLogin, intUserId);

            // if no menu to show
            if (objstrb.ToString() == "<ul id=\"myUL\" class=\"menu_ul\"></ul>")
            {
                divmenu.InnerHtml = "";
                Menuselect.Visible = false;
            }
            else
            {
                divmenu.InnerHtml = objstrb.ToString();
            }

            //---------------menu--------------------

            if (strCompanyName == "")
            {
                DataTable dtCompanyDet = new DataTable();
                clsCommonLibrary.APP_COMPANY[] arrEnumertn = { clsCommonLibrary.APP_COMPANY.CMPNY_NAME };
                dtCompanyDet = objBusines.LoadCompanyDetail(arrEnumertn);
                if (dtCompanyDet.Rows.Count > 0)
                {
                    strCompanyName = dtCompanyDet.Rows[0]["CMPNY_NAME"].ToString();
                }
            }
            //if session Work Station is 0 then workstation is not allocated
            if (objEntityLogin.WorkStatnId == 0)
            {
                if (Session["CORPORATENAME"] != null)
                {

                }
                else
                {
                    if (Session["ORGNAME"] != null)
                    {

                    }
                    else
                    {

                    }
                }
            }
            else
            {
                string strHeader = Session["CORPORATENAME"].ToString() + " ( " + Session["PREMISENAME"] + " )";
            }



            DataTable dtUsrInfo = new DataTable();
            dtUsrInfo = objBusinessLogin.Read_UserInfo(objEntityLogin);

            if (dtUsrInfo.Rows.Count > 0)
            {
                if (dtUsrInfo.Rows[0]["USR_IMAGE"].ToString() == "" || dtUsrInfo.Rows[0]["USR_IMAGE"].ToString() == null)
                {
                    imgProPic.ImageUrl = "/Images/Icons/wlcm.png";
                    imgProPicR.ImageUrl = "/Images/Icons/wlcm.png";
                }
                else
                {
                    string strImgPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.USER_PROFILEPIC);
                    string imageLocation = strImgPath + dtUsrInfo.Rows[0]["USR_IMAGE"].ToString();
                    if (File.Exists(MapPath(imageLocation)))
                    {
                        imgProPic.ImageUrl = imageLocation;
                        imgProPicR.ImageUrl = imageLocation;
                    }
                    else
                    {
                        imgProPic.ImageUrl = "/Images/Icons/wlcm.png";
                        imgProPicR.ImageUrl = "/Images/Icons/wlcm.png";
                    }
                }
            }



            //For MAIL ICON Count Display
            clsBusinessLayerDashboard objBusinessDashBoard = new clsBusinessLayerDashboard();
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());

            }
            if (blShowMailIcon == true)
            {

                //Allocating child roles
                int intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Mail_Box);
                DataTable dtChildRol = objBusines.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

                if (dtChildRol.Rows.Count > 0)
                {
                    clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
                    objEntityMail.User_Id = intUserId;
                    objEntityMail.Corporate_Id = intCorpId;
                    objEntityMail.Organisation_Id = intOrgId;
                    objEntityMail.Email_Store = Convert.ToInt32(CL_Compzit.clsCommonLibrary.Mail_Storage.Inbox);


                    string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                    string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                    foreach (string strC_Role in strChildDefArrWords)
                    {
                        if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.All_Mails).ToString())
                        {
                            intAllEnableMail = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        }
                    }

                    objEntityMail.All_Mail_Enable = intAllEnableMail;
                    DataTable dtUnReadMailCount = new DataTable();
                    dtUnReadMailCount = objBusinessDashBoard.Read_UnReadMail(objEntityMail);
                    DashboardUnreadMail(dtUnReadMailCount);

                }
                else
                {
                    clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
                    objEntityMail.User_Id = intUserId;
                    objEntityMail.Corporate_Id = intCorpId;
                    objEntityMail.Organisation_Id = intOrgId;
                    objEntityMail.Email_Store = Convert.ToInt32(CL_Compzit.clsCommonLibrary.Mail_Storage.Inbox);
                    objEntityMail.All_Mail_Enable = 0;
                    DataTable dtUnReadMailCount = new DataTable();
                    dtUnReadMailCount = objBusinessDashBoard.Read_UnReadMail(objEntityMail);
                    DashboardUnreadMail(dtUnReadMailCount);
                }
            }
            else
            {
                hiddenMailIconVisible.Value = "false";
                divMailIcon.Visible = false;
            }
            //For TASK ICON Count Display
            int intUsrRolMstrIdLead = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.New_Lead);
            DataTable dtChildRolLead = objBusines.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrIdLead);
            if (dtChildRolLead.Rows.Count > 0 && Session["APP_ID"] != null && Session["APP_ID"].ToString() == "2")
            {
            }
            else
            {
                divTaskIcon.Visible = false;
            }

            hiddenCorporateId.Value = intCorpId.ToString();
            hiddenOrganizationId.Value = intOrgId.ToString();
            hiddenUserId.Value = intUserId.ToString();

            //for app icon visibility
            // FOR APP ICON VISIBILITY
            clsBusinessLayerLogin objbusinessLayerLogin = new clsBusinessLayerLogin();
            clsEntityLayerLogin objEntLoginCount = new clsEntityLayerLogin();
            DataTable dtMenuCountDtl = new DataTable();

            objEntLoginCount.UserIdInt = intUserId;
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

                int intTotalApps = 0;
                hiddenMailIconVisible.Value = "false";
                divMailIcon.Visible = false;
                if (intAppAdmistratnCount != 0)
                {
                    if (intUserLimited != Convert.ToInt32(USERLIMITED.ISLIMITED))
                    {
                        intTotalApps++;
                    }
                    divApp.Visible = true;
                    int intLimitedRoleCount = 0;
                    DataTable dtUserRole = objbusinessLayerLogin.Read_AppMenuDtl(intUserId, Convert.ToInt32(APPS.HUMAN_CAPITAL_MANAGEMENT_SYSTEM));
                    if (dtUserRole.Rows.Count > 0)
                    {
                        for (int intRowCount = 0; intRowCount < dtUserRole.Rows.Count; intRowCount++)
                        {
                            int intUserRolMastrId = Convert.ToInt32(dtUserRole.Rows[0]["USROL_ID"].ToString());
                            if (intUserRolMastrId == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Employee_Master) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                            {
                                intLimitedRoleCount++;
                            }
                            else if (intUserRolMastrId == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Employee_Role_Allocation) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                            {
                                intLimitedRoleCount++;
                            }
                        }
                    }

                    DataTable dtUserRole2 = objbusinessLayerLogin.Read_AppMenuDtl(intUserId, Convert.ToInt32(APPS.APP_ADMINSTRATION));
                    if (dtUserRole2.Rows.Count > 0)
                    {
                        for (int intRowCount = 0; intRowCount < dtUserRole2.Rows.Count; intRowCount++)
                        {
                            int intUserRolMastrId = Convert.ToInt32(dtUserRole2.Rows[0]["USROL_ID"].ToString());

                            if (intUserRolMastrId == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.DesignationMaster) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                            {
                                intLimitedRoleCount++;
                            }
                            else if (intUserRolMastrId == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Job_role) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                            {
                                intLimitedRoleCount++;
                            }
                        }
                    }

                    if (intLimitedRoleCount < dtUserRole.Rows.Count)
                    {
                        divApp.Visible = true;
                        intTotalApps++;
                    }
                    else
                    {
                        divApp.Visible = false;
                    }
                }

                if (intGmsCount != 0)
                {
                    intTotalApps++;
                }
                if (intSalesForceCount != 0)
                {
                    intTotalApps++;
                    hiddenMailIconVisible.Value = "true";
                    divMailIcon.Visible = true;
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

                if (intTotalApps == 1)
                {
                    divApp.Visible = false;
                }
                else if (intTotalApps > 1)
                {
                    divApp.Visible = true;
                }

            }
            hiddenCorpList.Value = "";

            clsEntityLayerLogin objEntLoginOControl = new clsEntityLayerLogin();
            objEntLoginOControl.OrgId = intOrgId;
            DataTable dtAllCorpOfc_ByOrgId = new DataTable();
            if (Session["DSGN_CONTROL"] != null)
            {
                string strHtm = "";
                if ((Session["DSGN_CONTROL"].ToString() == "O" || Session["DSGN_CONTROL"].ToString() == "o") && (Convert.ToInt16(Session["DSGN_TYPID"].ToString()) == Convert.ToInt16(clsCommonLibrary.DesignationType.OrganisationMosAdministrator)))
                {
                    if (strHtm != "")
                        strHtm = objbusinessLayerLogin.Read_BussnsUnit_ByOrgIdNew(objEntLoginOControl, "/Home/Compzit_LandingPage/Compzit_LandingPage.aspx");
                }


                if (Session["DSGN_CONTROL"].ToString() == "C" || Session["DSGN_CONTROL"].ToString() == "c")
                {
                    objEntLoginOControl.UserIdInt = intUserId;
                    if (Session["FRMWRK_TYPE"] != null && Session["FRMWRK_TYPE"].ToString() == "1")
                    {
                        strHtm = objbusinessLayerLogin.ReadAcsBussnssUnit_UsrNew(objEntLoginOControl, "/Home/Compzit_Home/Compzit_Home_Finance.aspx");
                    }
                    else
                    {
                        strHtm = objbusinessLayerLogin.ReadAcsBussnssUnit_UsrNew(objEntLoginOControl, "/Home/Compzit_LandingPage/Compzit_LandingPage.aspx");
                    }
                }
                if (strHtm != "")
                {
                    divBussnsUnit.Visible = true;
                    divCorpList.InnerHtml = strHtm;
                    hiddenCorpList.Value = "ShowCorList";
                }
                else
                {
                    divBussnsUnit.Visible = false;
                }
            }
            if (Session["FRMWRK_TYPE"] != null && Session["FRMWRK_TYPE"].ToString() == "1")
            {
                divApp.Visible = false;
                divMailIcon.Visible = false;
                //divRightDatepick.Visible = false;
                //hMaster.InnerText = "Finance Management System";
                //aHome.Attributes["href"] = "/Home/Compzit_Home/Compzit_Home_Finance.aspx";
                //aDashboard.Attributes["href"] = "/Home/Compzit_Home/Compzit_Home_Finance.aspx";
                //aCompzit.Attributes["href"] = "/Home/Compzit_Home/Compzit_Home_Finance.aspx";
            }
            if (Session["APP_ID"] != null)
            {
                clsEntityCommon ObjEntityCommon = new clsEntityCommon();
                ObjEntityCommon.SectionId = Convert.ToInt32(Session["APP_ID"].ToString());
                DataTable dtApp = objBusines.ReadAppDetails(ObjEntityCommon);
                if (dtApp.Rows.Count > 0)
                {
                    divFootAppName.InnerHtml = dtApp.Rows[0]["PRTZAPP_NAME"].ToString();
                    lblMenuAppName.InnerHtml = dtApp.Rows[0]["PRTZAPP_NAME"].ToString();
                    if (dtApp.Rows[0]["PRTZAPP_IMAGE"].ToString() != "")
                    {
                        string imaeposition = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.APP_ICONS);
                        string icon = dtApp.Rows[0]["PRTZAPP_IMAGE"].ToString();
                        imgAppFooter.ImageUrl = imaeposition + icon;
                        imgCorpOffc.ImageUrl = imaeposition + icon;
                    }
                }
            }
        }
    }
    public void DashboardUnreadMail(DataTable dtUnReadMailCount)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        int intTotalUnreadMsg = 0;
        for (int intcount = 0; intcount < dtUnReadMailCount.Rows.Count; intcount++)
        {
            int intCountUnread = 0;
            intCountUnread = Convert.ToInt32(dtUnReadMailCount.Rows[intcount]["COUNT"].ToString());

            intTotalUnreadMsg = intTotalUnreadMsg + intCountUnread;
        }
        if (intTotalUnreadMsg > 0)
        {
            spanCountUnreadMail.InnerHtml = "<span class=\"badge beln cht\">" + intTotalUnreadMsg.ToString() + "</span>";
        }
        else
        {
            spanCountUnreadMail.InnerHtml = "<span></span>";
        }
    }
}
