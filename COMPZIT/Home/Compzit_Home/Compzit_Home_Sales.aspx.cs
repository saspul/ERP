using BL_Compzit;
using CL_Compzit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using System.Web.Services;
public partial class Home_Compzit_Home_Compzit_Home_Sales : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["APP_ID"] = "2";

        if (!IsPostBack)
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();
            int intUserId = 0, intAllEnableMail = 0,intCorpId=0,intOrgId=0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            //when ORGANIZATION ADMIN CHOOSES A CORPORATE 
            if (Request.QueryString["CId"] != null)
            {
                string strRandomMixedId = Request.QueryString["CId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Session["CORPOFFICEID"] = strId;

                if (Session["CORPOFFICEID"] != null)
                {

                    DataTable dtCorpDetail = new DataTable();

                    int intCorppId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    clsCommonLibrary.CORP_GLOBAL[] arrEnumer = { clsCommonLibrary.CORP_GLOBAL.ACTIVE_FINCYR_ID };
                    dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorppId);
                    if (dtCorpDetail.Rows.Count > 0)
                    {
                        if (dtCorpDetail.Rows[0]["ACTIVE_FINCYR_ID"].ToString() != "")
                        {
                            Session["FINCYRID"] = Convert.ToInt32(dtCorpDetail.Rows[0]["ACTIVE_FINCYR_ID"].ToString());
                        }
                    }
                }
                clsEntityLayerLogin objEntLogin = new clsEntityLayerLogin();
                objEntLogin.CorpOfficeId = Convert.ToInt32(strId);
                clsBusinessLayerLogin objBusinessLog = new clsBusinessLayerLogin();
                DataTable dtCorpName = new DataTable();
                dtCorpName = objBusinessLog.ReadCorporateName(objEntLogin);


                if (dtCorpName.Rows.Count > 0)
                {
                    Session["CORPORATENAME"] = dtCorpName.Rows[0]["CORPRT_NAME"].ToString();
                }
            }
            clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
            clsBusinessLayerDashboard objBusinessDashBoard= new clsBusinessLayerDashboard();
         
            if (Session["USERID"] != null)
            {
               intUserId =Convert.ToInt32(Session["USERID"].ToString());

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("../../Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId= Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("../../Default.aspx");
            }
            hiddenUserId.Value = intUserId.ToString();
            hiddenCorporateId.Value = intCorpId.ToString();
            hiddenOrganisationId.Value = intOrgId.ToString();
            objEntityLead.User_Id = intUserId;
            objEntityLead.Active_UserId = intUserId;
            objEntityLead.Corp_Id = intCorpId;
            objEntityLead.Org_Id = intOrgId;

            // check if team lead or not if team lead atleast a row
            DataTable dtTeamListTeamHead = new DataTable();
            dtTeamListTeamHead = objBusinessDashBoard.Read_TeamList_For_TeamHead(objEntityLead);

            if (dtTeamListTeamHead.Rows.Count > 0)
            {
                divTeamHead.Visible = true;
                //commented as dashboard for team head is not needed
             //   DashboardTeamHead(dtTeamListTeamHead,intUserId,intCorpId,intOrgId);
                
            }
            else
            {
                divTeamHead.Visible = false;
            }

           int    intUsrRolMstrIdLead = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.New_Lead);
        DataTable dtChildRolLead = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrIdLead);

        if (dtChildRolLead.Rows.Count > 0)
        {
            DataTable dtTotalLeadCount = new DataTable();
            DataTable dtMonthlyLeadCount = new DataTable();
            DataTable dtTotalTaskCount = new DataTable();
            dtTotalLeadCount = objBusinessDashBoard.Read_Total_New_Aprv_Actv_Lead_Count(objEntityLead);
            dtMonthlyLeadCount = objBusinessDashBoard.Read_WL_Lead_Count_of_CurrentMonth(objEntityLead);
            dtTotalTaskCount = objBusinessDashBoard.Read_Total_Task_Count(objEntityLead);
            DashboardLead(dtTotalLeadCount, dtMonthlyLeadCount);
            DashboardTask(dtTotalTaskCount);
        }
        else
        {
            divDashboardClientApprvl.Visible = false;
            divDashboardLead.Visible = false;
            divDashboardMnthlyLead.Visible = false;
            divDashboardTask.Visible = false;
        
        }
              //Allocating child roles
        int intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Mail_Box);
        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

        if (dtChildRol.Rows.Count > 0)
        {
            clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
            objEntityMail.User_Id = intUserId;
            objEntityMail.Corporate_Id = intCorpId;
            objEntityMail.Organisation_Id = intOrgId;
            objEntityMail.Email_Store = Convert.ToInt32( CL_Compzit.clsCommonLibrary.Mail_Storage.Inbox);
          

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
    }

    public void DashboardLead(DataTable dtTotalLeadCount, DataTable dtMonthlyLeadCount)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (dtTotalLeadCount.Rows.Count > 0 && dtMonthlyLeadCount.Rows.Count > 0)
        {
           // monthly count details

            decimal decMonthlyTotalLead = Convert.ToInt32(dtMonthlyLeadCount.Rows[0]["COUNTTOTAL"].ToString());
            decimal decMonthlySuccessLead = Convert.ToDecimal(dtMonthlyLeadCount.Rows[1]["COUNTTOTAL"].ToString());
            decimal decMonthlyLostLead = Convert.ToDecimal(dtMonthlyLeadCount.Rows[2]["COUNTTOTAL"].ToString());
            decimal decSucessPerc = 0;
            decimal decLostPerc = 0;
            if (decMonthlyTotalLead != 0)
            {
                decSucessPerc = (Convert.ToDecimal(decMonthlySuccessLead / decMonthlyTotalLead) * 100);
                decLostPerc = (Convert.ToDecimal(decMonthlyLostLead / decMonthlyTotalLead) * 100);

            }
            else
            {
                decSucessPerc = 0;
                decLostPerc = 0;

            }

            int intLeadDecimalCount = Convert.ToInt32(clsCommonLibrary.DASHBOARD_DECIMAL_COUNT.Lead);
            string strSucessPerc = objCommon.Format(intLeadDecimalCount, decSucessPerc.ToString());
            string strLostPerc = objCommon.Format(intLeadDecimalCount, decLostPerc.ToString());


            h3NoCnvrsnLead.InnerHtml = decMonthlySuccessLead.ToString();
            h3NoJunkLead.InnerHtml = decMonthlyLostLead.ToString();
            h3ConvrsnPerc.InnerHtml = strSucessPerc + " %";
            h3LossPerc.InnerHtml = strLostPerc + " %";


        //    Total count details

            string strTotalNewLead = dtTotalLeadCount.Rows[0]["COUNTTOTAL"].ToString();
            string strTotalApprovedLead = dtTotalLeadCount.Rows[1]["COUNTTOTAL"].ToString();
            string strTotalActiveLead = dtTotalLeadCount.Rows[2]["COUNTTOTAL"].ToString();
            string strTotalDeliveredLead = dtTotalLeadCount.Rows[3]["COUNTTOTAL"].ToString();
            h3NoNewLead.InnerHtml = strTotalNewLead;
            h3NoApprovedLead.InnerHtml = strTotalApprovedLead;
            h3NoActiveLead.InnerHtml = strTotalActiveLead;
            h3NoClientApprvl.InnerHtml = strTotalDeliveredLead;
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
            spanCountUnreadMail.InnerHtml = "<p class=\"pulse2\">" + intTotalUnreadMsg.ToString() + "</p>";
        }
        else
        {
            spanCountUnreadMail.InnerHtml = "<p >" + intTotalUnreadMsg.ToString() + "</p>";

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
            string strTotalAbtToBreachTask = dtTotalTaskCount.Rows[0]["COUNT"].ToString();
            string strTotalBreachedTask = dtTotalTaskCount.Rows[1]["COUNT"].ToString();
            string strTotalUpcomingTask = dtTotalTaskCount.Rows[3]["COUNT"].ToString();

            h3TaskOpen.InnerHtml = strTotalOpenTask;


            if (strTotalAbtToBreachTask != "0")
            {
                h3TaskAbtToBreach.InnerHtml = "<p class=\"pulse2\" style=\"margin-top: 0.5%;\">" + strTotalAbtToBreachTask + "</p>";
            }
            else
            {
                h3TaskAbtToBreach.InnerHtml = "<p style=\"margin-top: 0.5%;\">" + strTotalAbtToBreachTask + "</p>";

            }

            if (strTotalBreachedTask != "0")
            {
                h3TaskBreached.InnerHtml = "<p class=\"pulse1\" style=\"margin-top: 2.5%;\">" + strTotalBreachedTask + "</p>";
            }
            else
            {
                h3TaskBreached.InnerHtml = "<p style=\"margin-top: 2.5%;\">" + strTotalBreachedTask + "</p>";

            }

            h3TaskUpcoming.InnerHtml = strTotalUpcomingTask;
        }

    }

    public void DashboardTeamHead(DataTable dtTeamList,int intUserId,int intCorpId,int intOrgId)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (dtTeamList.Rows.Count > 0)
        {

            if (dtTeamList.Rows.Count > 1)
            {

                //more than one team
                h1MainTeam.InnerHtml = dtTeamList.Rows[0]["TEAM_NAME"].ToString();
                h1MainTeamRespnsvHead.InnerHtml = dtTeamList.Rows[0]["TEAM_NAME"].ToString();
                int intTeamID = Convert.ToInt32(dtTeamList.Rows[0]["TEAM_ID"].ToString());

                TeamSelect(intTeamID, intUserId, intCorpId, intOrgId);


                string strMultiple = " <div class=\"dropdown\"><button class=\"btn btn-primary dropdown-toggle\" type=\"button\" data-toggle=\"dropdown\"> <span class=\"caret\"></span></button>";
    
                    strMultiple = strMultiple+"<ul class=\"dropdown-menu\">";
                    for (int intRowliCount = 0; intRowliCount < dtTeamList.Rows.Count; intRowliCount++)
                    {
                        int intTID = Convert.ToInt32(dtTeamList.Rows[intRowliCount]["TEAM_ID"].ToString());
                        string strTeamName = dtTeamList.Rows[intRowliCount]["TEAM_NAME"].ToString();
                        strMultiple = strMultiple + "<li><span style=\"display: block;padding: 3px 20px;clear: both;font-weight: 400;line-height: 1.42857143;color: #333;white-space: nowrap;cursor:pointer;\" onclick=\"return ChangeTeam(" + intTID + ",'"+strTeamName+"');\">" + dtTeamList.Rows[intRowliCount]["TEAM_NAME"].ToString() + "</span></li>";
                       
                    }
                    strMultiple = strMultiple + " </ul>";
                       strMultiple = strMultiple +"</div>";

                       divMultipleTeam.InnerHtml = strMultiple;
                       divMultipleTeamRespnsvHead.InnerHtml = strMultiple;
               
            }

            else
            { 
            //only one team

                h1MainTeam.InnerHtml = dtTeamList.Rows[0]["TEAM_NAME"].ToString();
                h1MainTeamRespnsvHead.InnerHtml = dtTeamList.Rows[0]["TEAM_NAME"].ToString();
                divMultipleTeam.InnerHtml = "";
                divMultipleTeamRespnsvHead.InnerHtml = "";
                int intTeamID = Convert.ToInt32(dtTeamList.Rows[0]["TEAM_ID"].ToString());
                TeamSelect(intTeamID, intUserId, intCorpId, intOrgId);
            
            }
        }

    }

    public void TeamSelect(int intTeamId,int intUserId,int intCorpId,int intOrgId)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        string strId = intTeamId.ToString();
        int intIdLength = strId.Length;
        string stridLength = intIdLength.ToString("00");
        string strTId = stridLength + strId + strRandom;

        hiddenMixedTeamId.Value = strTId;

        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
        clsBusinessLayerDashboard objBusinessDashBoard = new clsBusinessLayerDashboard();
        objEntityLead.Org_Id = intOrgId;
        objEntityLead.User_Id = intUserId;
        objEntityLead.Corp_Id = intCorpId;
        objEntityLead.Team = intTeamId;
        DataTable dtCountApprvlPendingLead = new DataTable();
        dtCountApprvlPendingLead = objBusinessDashBoard.Read_Count_ApprvlPendingLead_For_TeamHead(objEntityLead);
        DataTable dtCountUnreadAttchMail = new DataTable();
        dtCountUnreadAttchMail = objBusinessDashBoard.Read_Count_UnreadAllocatedMail_For_TeamHead(objEntityLead);
        if (dtCountApprvlPendingLead.Rows.Count > 0)
        {

            spanTeamHeadApprvlPndngCount.InnerHtml = "<span id='spanTeamHeadApprvlPndng'  onclick=' return getdetailsApprovalPendingTeamWise();' style='cursor:pointer;'>" + dtCountApprvlPendingLead.Rows[0]["APVLPENDING_COUNT"].ToString() + "</span>";
        }
        if (dtCountUnreadAttchMail.Rows.Count > 0)
        {

            spanTeamHeadUnreadMailCount.InnerHtml = "<span id='spanTeamHeadUnreadMail' onclick=' return getdetailsUnreadAllctdMailTeamWise();' style='cursor:pointer;'>" + dtCountUnreadAttchMail.Rows[0]["UNREAD_ALLCT_MAIL_COUNT"].ToString() + "</span>";
        }
    }

    public class TeamCountDetails
    {
        public string strTeamName;
        public int intTeamCountApprovalPendingLead=0;
        public int intTeamCountUnReadAttchMail= 0;
        public string strTeamMixedId="";
    }

    [WebMethod]
    public static TeamCountDetails TeamWiseDetails(string corporateId, string organisationId, string TeamId,string strUserId)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        string strId = TeamId.ToString();
        int intIdLength = strId.Length;
        string stridLength = intIdLength.ToString("00");
        string strTId = stridLength + strId + strRandom;


        TeamCountDetails objTeamDtls = new TeamCountDetails();     // CREATE AN OBJECT.

        //Creating objects for business layer
        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
        clsBusinessLayerDashboard objBusinessDashBoard = new clsBusinessLayerDashboard();


        if (corporateId != null && corporateId != "" && corporateId != "undefined" && organisationId != null && organisationId != "" && organisationId != "undefined" && TeamId != null && TeamId != "" && TeamId != "undefined" && strUserId != null && strUserId != "" && strUserId != "undefined")
        {
            objEntityLead.Corp_Id = Convert.ToInt32(corporateId);
            objEntityLead.Org_Id = Convert.ToInt32(organisationId);
            objEntityLead.User_Id = Convert.ToInt32(strUserId);
            objEntityLead.Team = Convert.ToInt32(TeamId);
        }

        DataTable dtTeamDtl = new DataTable();
        dtTeamDtl = objBusinessDashBoard.Read_Count_ApprvlPendingLead_For_TeamHead(objEntityLead);

        DataTable dtCountUnreadAttchMail = new DataTable();
        dtCountUnreadAttchMail = objBusinessDashBoard.Read_Count_UnreadAllocatedMail_For_TeamHead(objEntityLead);
        if (dtTeamDtl.Rows.Count > 0)
        {
            objTeamDtls.intTeamCountApprovalPendingLead =Convert.ToInt32( dtTeamDtl.Rows[0]["APVLPENDING_COUNT"].ToString());

        }
        if (dtCountUnreadAttchMail.Rows.Count > 0)
        {

            objTeamDtls.intTeamCountUnReadAttchMail = Convert.ToInt32(dtCountUnreadAttchMail.Rows[0]["UNREAD_ALLCT_MAIL_COUNT"].ToString());
        }
        objTeamDtls.strTeamMixedId = strTId;
        return objTeamDtls;
    }
}