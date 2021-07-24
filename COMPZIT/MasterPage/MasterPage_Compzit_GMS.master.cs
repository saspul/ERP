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
// CREATED BY:EVM-0005
// CREATED DATE:27-12-2016
// REVIEWED BY:
// REVIEW DATE

public partial class MasterPage_MasterPage_Compzit_GMS : System.Web.UI.MasterPage
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
        GUARANTEE_MANAGEMENT_SYSTEM = 4

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hiddenMailIconVisible.Value = "true";
            int intUserId = 0, intAllEnableMail = 0, intCorpId = 0, intOrgId = 0;
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
            //Session["USERNAME"] = "admin gmail";
            //Session["USERID"] = 10028;
            //Session["WRKSTNID"] = 0;

            //Creating objects for business layer.
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





            //to show developed by information
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

                //0041
                divcopyright.InnerHtml = "©" + " " + DateTime.Now.Year.ToString() + " " + "Copyright";
                //END

                divdevelop.InnerHtml = "Developed by: <a target= \"_blank \" href=\"" + strCompanyWeb + "\">" + strCompanyName + "</a> ";
            }
            else
            {
                divdevelop.InnerHtml = "";

            }

            string strMenuCount = "";
            string strFrequentCount = "";
            string strStatus = "";

            //for changing color of header and footer
            if (Session["CORPOFFICEID"] != null)
            {
                clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = { clsCommonLibrary.CORP_GLOBAL.GN_SALES_HEADER_COLOR, 
                                                               clsCommonLibrary.CORP_GLOBAL.GN_SALES_FOOTER_COLOR ,
                                                             clsCommonLibrary.CORP_GLOBAL.MENU_STATUS, 
                                                             clsCommonLibrary.CORP_GLOBAL.RECNT_COUNT, 
                                                             clsCommonLibrary.CORP_GLOBAL.FREQNT_COUNT};
                DataTable dtCorpDetail = new DataTable();


                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);

                dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                if (dtCorpDetail.Rows.Count > 0)
                {
                    hiddenHeaderColor.Value = dtCorpDetail.Rows[0]["GN_SALES_HEADER_COLOR"].ToString();
                    hiddenFooterColor.Value = dtCorpDetail.Rows[0]["GN_SALES_FOOTER_COLOR"].ToString();

                    //for frequent and recent menu
                    strStatus = dtCorpDetail.Rows[0]["MENU_STATUS"].ToString();
                    strMenuCount = dtCorpDetail.Rows[0]["RECNT_COUNT"].ToString();
                    strFrequentCount = dtCorpDetail.Rows[0]["FREQNT_COUNT"].ToString();
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

                lblUserName.Text = Session["USERNAME"].ToString();
                h1AccntSettingName.InnerHtml = lblUserName.Text;
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
            objEntityLogin.Cmp_AppId = 4;


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
                        objstrbRecent = objBusinessMenu.GetMenuDataForRecentMenu(objEntityLogin, intUserId, strMenuCount);
                        objstrbFrequent = objBusinessMenu.GetMenuDataForFrequentlyMenu(objEntityLogin, intUserId, strFrequentCount);

                        divRecent.InnerHtml = objstrbRecent.ToString();
                        divFrequent.InnerHtml = objstrbFrequent.ToString();
                    }
                }
                else if (strStatus == "1")
                {
                    if (strMenuCount != "0")
                    {
                        objstrbRecent = objBusinessMenu.GetMenuDataForRecentMenu(objEntityLogin, intUserId, strMenuCount);

                        divRecent.InnerHtml = objstrbRecent.ToString();
                    }
                }
                else if (strStatus == "2")
                {
                    if (strFrequentCount != "0")
                    {
                        objstrbFrequent = objBusinessMenu.GetMenuDataForFrequentlyMenu(objEntityLogin, intUserId, strFrequentCount);

                        divFrequent.InnerHtml = objstrbFrequent.ToString();
                    }
                }
            }

            //---------------menu--------------------

            StringBuilder objstrb = new StringBuilder();
            objstrb = objBusinessMenu.GetMenuDataCompzit(objEntityLogin, intUserId);
            // if no menu to show
            if (objstrb.ToString() == "<ul class=\"sidebar-menu\" ></ul>")
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
                    divheaderName.InnerHtml = Session["CORPORATENAME"].ToString();
                }
                else
                {

                    if (Session["ORGNAME"] != null)
                    {
                        divheaderName.InnerHtml = Session["ORGNAME"].ToString();
                    }
                    else
                    {
                        divheaderName.InnerHtml = strCompanyName;

                    }


                }
            }
            else
            {

                string strHeader = Session["CORPORATENAME"].ToString() + " ( " + Session["PREMISENAME"] + " )";

                divheaderName.InnerHtml = strHeader;

            }




            DataTable dtUsrInfo = new DataTable();
            dtUsrInfo = objBusinessLogin.Read_UserInfo(objEntityLogin);

            if (dtUsrInfo.Rows.Count > 0)
            {
                if (dtUsrInfo.Rows[0]["USR_IMAGE"].ToString() == "" || dtUsrInfo.Rows[0]["USR_IMAGE"].ToString() == null)
                {
                    imgProPic.ImageUrl = "/Images/Icons/wlcm.png";
                    imgAccntSetting.ImageUrl = "/Images/Icons/wlcm.png";
                }
                else
                {

                    string strImgPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.USER_PROFILEPIC);
                    string imageLocation = strImgPath + dtUsrInfo.Rows[0]["USR_IMAGE"].ToString();
                    if (File.Exists(MapPath(imageLocation)))
                    {
                        imgProPic.ImageUrl = imageLocation;
                        imgAccntSetting.ImageUrl = imageLocation;
                    }
                    else
                    {
                        imgProPic.ImageUrl = "/Images/Icons/wlcm.png";
                        imgAccntSetting.ImageUrl = "/Images/Icons/wlcm.png";
                    }
                }

                h2AccntSettingEmail.InnerHtml = dtUsrInfo.Rows[0]["USR_EMAIL"].ToString();
            }


            //For MAIL ICON Count Display
            clsBusinessLayerDashboard objBusinessDashBoard = new clsBusinessLayerDashboard();
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());

            }

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

            //For TASK ICON Count Display

            int intUsrRolMstrIdLead = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.New_Lead);
            DataTable dtChildRolLead = objBusines.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrIdLead);

            if (dtChildRolLead.Rows.Count > 0)
            {
                clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
                objEntityLead.Corp_Id = intCorpId;
                objEntityLead.Org_Id = intOrgId;
                objEntityLead.Active_UserId = intUserId;
                DataTable dtTotalTaskCount = new DataTable();
                dtTotalTaskCount = objBusinessDashBoard.Read_Total_Task_Count(objEntityLead);
                DashboardTask(dtTotalTaskCount);
                divTaskIcon.Visible = false;
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
                    DataTable dtUserRole = objbusinessLayerLogin.Read_AppMenuDtl(intUserId, Convert.ToInt32(APPS.APP_ADMINSTRATION));
                    if (dtUserRole.Rows.Count > 0)
                    {
                        for (int intRowCount = 0; intRowCount < dtUserRole.Rows.Count; intRowCount++)
                        {
                            int intUserRolMastrId = Convert.ToInt32(dtUserRole.Rows[0]["USROL_ID"].ToString());

                            if (intUserRolMastrId == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.DesignationMaster) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                            {
                                intLimitedRoleCount++;
                            }
                            //EVM-0012
                            else if (intUserRolMastrId == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Job_role) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                            {
                                intLimitedRoleCount++;

                            }
                            else if (intUserRolMastrId == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Employee_Master) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                            {
                                intLimitedRoleCount++;
                            }
                            else if (intUserRolMastrId == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Employee_Role_Allocation) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
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
                        strHtm = objbusinessLayerLogin.Read_BussnsUnit_ByOrgId(objEntLoginOControl, "/Home/Compzit_LandingPage/Compzit_LandingPage.aspx");

                    //strHtm = ConvertDataTableToHTML_List(dtAllCorpOfc_ByOrgId, "/Home/Compzit_LandingPage/Compzit_LandingPage.aspx");


                }


                if (Session["DSGN_CONTROL"].ToString() == "C" || Session["DSGN_CONTROL"].ToString() == "c")
                {
                    objEntLoginOControl.UserIdInt = intUserId;
                    strHtm = objbusinessLayerLogin.ReadAcsBussnssUnit_Usr(objEntLoginOControl, "/Home/Compzit_LandingPage/Compzit_LandingPage.aspx");
                }
                if (strHtm != "")
                {
                    divBussnsUnit.Visible = true;
                    divCorpList.InnerHtml = strHtm;
                    //write list
                    hiddenCorpList.Value = "ShowCorList";
                }
                else
                {
                    divBussnsUnit.Visible = false;
                }
            }


            if (Session["FRMWRK_TYPE"]!=null &&Session["FRMWRK_TYPE"].ToString() == "1")
            {
                divIconsRight.Visible = false;
                divRightDatepick.Visible = false;
                hMaster.InnerText = "Finance Management System";
                aHome.Attributes["href"] = "/Home/Compzit_Home/Compzit_Home_Finance.aspx";
                aDashboard.Attributes["href"] = "/Home/Compzit_Home/Compzit_Home_Finance.aspx";
                aCompzit.Attributes["href"] = "/Home/Compzit_Home/Compzit_Home_Finance.aspx";
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
        // intTotalUnreadMsg = 0;
        if (intTotalUnreadMsg > 0)
        {
            spanCountUnreadMail.InnerHtml = "<span class=\"button__badge\">" + intTotalUnreadMsg.ToString() + "</span>";
        }
        else
        {
            spanCountUnreadMail.InnerHtml = "<span></span>";

        }
        //    pCountUnreadMail.
    }


    public void DashboardTask(DataTable dtTotalTaskCount)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (dtTotalTaskCount.Rows.Count > 0)
        {


            // Total count details

            string strTotalOpenTask = dtTotalTaskCount.Rows[2]["COUNT"].ToString();

            if (strTotalOpenTask != "0")
            {
                spanCountOpenTask.InnerHtml = "<span class=\"button__badge\">" + strTotalOpenTask + "</span>";
            }
            else
            {
                spanCountOpenTask.InnerHtml = "<span></span>";

            }


        }

    }

}

