using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;

/// <summary>
/// Summary description for WebServiceMaster
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]

public class WebServiceMaster : System.Web.Services.WebService {

    public WebServiceMaster () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    [WebMethod]
    public  string IconMailCountDetails(string corporateId, string organisationId, string UserId)
    {
        int intUserId = 0, intAllEnableMail = 0, intCorpId = 0, intOrgId = 0;
        string strCnt = "<span></span>";
        clsBusinessLayer objBusines = new clsBusinessLayer();
        //For MAIL ICON Count Display
        clsBusinessLayerDashboard objBusinessDashBoard = new clsBusinessLayerDashboard();


        if (corporateId != null && corporateId != "" && corporateId != "undefined" && organisationId != null && organisationId != "" && organisationId != "undefined" && UserId != null && UserId != "" && UserId != "undefined")
        {
            intUserId = Convert.ToInt32(UserId);
            intCorpId = Convert.ToInt32(corporateId);
            intOrgId = Convert.ToInt32(organisationId);
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
                    strCnt = "<span class=\"button__badge\">" + intTotalUnreadMsg.ToString() + "</span>";
                }
                else
                {
                    strCnt = "<span></span>";

                }
                //DashboardUnreadMail(dtUnReadMailCount);

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
                    strCnt = "<span class=\"button__badge\">" + intTotalUnreadMsg.ToString() + "</span>";
                }
                else
                {
                    strCnt = "<span></span>";

                }

                //  DashboardUnreadMail(dtUnReadMailCount);
            }


        }
        // strCnt = "";
        return strCnt;
    }
    [WebMethod]
    public string GetEmployeeCount(string userid,string LoginId)
    {
       
        handower objhandower = new handower();
           clsBusinessLayerClearanceFormWorker objBusinessLeaveApproval = new clsBusinessLayerClearanceFormWorker();
        clsEntityLayerClearanceFormWorker ObjEntityLeaveApproval = new clsEntityLayerClearanceFormWorker();
        //ObjEntityLeaveApproval.Empid = Convert.ToInt32(userid);
  
            ObjEntityLeaveApproval.Empid = Convert.ToInt32(LoginId);


        // MasterPage_MasterPageCompzit_Hcm objMasterPage_MasterPageCompzit_Hcm = new MasterPage_MasterPageCompzit_Hcm();
        DataTable dtTOtallve = objBusinessLeaveApproval.ReadHadover(ObjEntityLeaveApproval);

        dtTOtallve.DefaultView.RowFilter = "LVECLRSTF_USR_ID = " + userid;
        DataTable dt = (dtTOtallve.DefaultView).ToTable();
       string strHtm1 = objhandower.ConvertDataTableToHTML(dt);
        //Write to divReport
        return strHtm1;

    }
    public class handower
    {
        private string STRHTM;
        public string ConvertDataTableToHTML(DataTable dt)
        {


            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();

            // class="table table-bordered table-striped"
            StringBuilder sb = new StringBuilder();
             string strHtml ="<span id=\"Label1\"><b>"+dt.Rows[0]["USR_NAME"].ToString()+" handed over the following subject to you<b><br/></span>";
             strHtml += "<table id=\"ReportTablehandover\" class=\"main_table1\" cellspacing=\"0\" cellpadding=\"2px\" >";
            //add header row
            strHtml += "<thead>";
            strHtml += "<tr class=\"main_table_head1\">";
            int count = 0;
            strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">SL#</th>";

            for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
            {
                if (intColumnHeaderCount == 1)
                {
                    strHtml += "<th class=\"thT\" style=\"width:45%;text-align: left; word-wrap:break-word;\">Subject</th>";
                }
                if (intColumnHeaderCount == 2)
                {
                    strHtml += "<th class=\"thT\" style=\"width:25%;text-align: left; word-wrap:break-word;\">Decision</th>";
                }

                if (intColumnHeaderCount == 3)
                {
                    strHtml += "<th class=\"thT\" style=\"width:25%;text-align: left; word-wrap:break-word;\">Comments</th>";
                }

            }






            strHtml += "</tr>";
            strHtml += "</thead>";
            //add rows
            int staffworker = 0;
            strHtml += "<tbody>";
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                count = intRowBodyCount + 1;




                strHtml += "<tr  >";

                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count + "</a> </td>";

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {
                    //if (j == 0)
                    //{
                    //    int intCnt = i + 1;
                    //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                    //}



                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:45%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\"><select onchange=\"Changeddl('1',event);\" style=\"line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 100%; margin-left: 0.1%;\"id =\"ddlDecision" + intRowBodyCount + "\"class=\"form1\"><option value =\"0\">PENDING</option><option value =\"1\">APPROVED</option><option value =\"2\">REJECTED</option></select></td>";

                    }
                    if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\"><input name=\"txtComments\" maxlength=\"99\" id=\"txtComments" + intRowBodyCount + "\" class=\"form1\" onkeypress=\"return DisableEnter(event)\" onblur=\"return ReplaceTag(txtComments" + intRowBodyCount + ")\" onchange=\"IncrmntConfrmCounter()\" style=\"width:86%; margin-right:0%; text-transform: uppercase;\" type=\"text\"></td>";

                    }

                }


                strHtml += "<td id=\"tdid" + intRowBodyCount + "\"  class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount][0].ToString() + "</td>";


                strHtml += "</tr>";
            }

            strHtml += "</tbody>";

            strHtml += "</table>";



            sb.Append(strHtml);
            return sb.ToString();
        }

    }

    [WebMethod(EnableSession = true)]
    public string GetAppMode()
    {
        string strAppMode = "";
        clsEntityOrganization objEntityOrganization = new clsEntityOrganization();
        clsBusinessLayerOrganization objBusinessLayerOrganization = new clsBusinessLayerOrganization();
        objEntityOrganization.OrgId = Convert.ToInt32(WebConfigurationManager.AppSettings["OrganisationId"]);
        objEntityOrganization = objBusinessLayerOrganization.ReadAppMode(objEntityOrganization); // FUNCTION CALL
        HttpContext.Current.Session["ORG_APP_MODE"] = objEntityOrganization.OrgAppMode;
        strAppMode = HttpContext.Current.Session["ORG_APP_MODE"].ToString();
        return strAppMode;
    }

    [WebMethod]
    public string IconMailCountDetailsNew(string corporateId, string organisationId, string UserId)
    {
        int intUserId = 0, intAllEnableMail = 0, intCorpId = 0, intOrgId = 0;
        string strCnt = "<span></span>";
        clsBusinessLayer objBusines = new clsBusinessLayer();
        //For MAIL ICON Count Display
        clsBusinessLayerDashboard objBusinessDashBoard = new clsBusinessLayerDashboard();


        if (corporateId != null && corporateId != "" && corporateId != "undefined" && organisationId != null && organisationId != "" && organisationId != "undefined" && UserId != null && UserId != "" && UserId != "undefined")
        {
            intUserId = Convert.ToInt32(UserId);
            intCorpId = Convert.ToInt32(corporateId);
            intOrgId = Convert.ToInt32(organisationId);
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
                    strCnt = "<span class=\"badge beln cht\">" + intTotalUnreadMsg.ToString() + "</span>";
                }
                else
                {
                    strCnt = "<span></span>";

                }
                //DashboardUnreadMail(dtUnReadMailCount);

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
                    strCnt = "<span class=\"badge beln cht\">" + intTotalUnreadMsg.ToString() + "</span>";
                }
                else
                {
                    strCnt = "<span></span>";

                }

                //  DashboardUnreadMail(dtUnReadMailCount);
            }


        }
        // strCnt = "";
        return strCnt;
    }

    [WebMethod(EnableSession = true)]
    public void InsertRecentMenu(string menuid)
    {
        clsEntityLayerRecentMenu objEntityRecentmenu = new clsEntityLayerRecentMenu();
        clsBusinessLayerRecentMenu objBusinessRecentMenu = new clsBusinessLayerRecentMenu();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != "" || Session["CORPOFFICEID"] != null )
        {
            objEntityRecentmenu.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }

        if (Session["ORGID"] != null)
        {
            objEntityRecentmenu.OrgId = Convert.ToInt32(WebConfigurationManager.AppSettings["OrganisationId"]);
        }
        objEntityRecentmenu.AppId = Convert.ToInt32(Session["APP_ID"]);
        if (Session["USERID"] != "" && Session["USERID"] != null)
        {
            objEntityRecentmenu.UserId = Convert.ToInt32(Session["USERID"].ToString());
        
        objEntityRecentmenu.MenuId = Convert.ToInt32(menuid);
        string curdate = objBusinessLayer.LoadCurrentDate().ToString("dd-MM-yyyy");
        ///01-01-2010 01:23 pm
        string ss = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
        objEntityRecentmenu.Date = objCommon.textToDateTime(curdate);
        // objEntityRecentmenu.MenuTime = DateTime.Now.TimeOfDay;
        //objEntityRecentmenu.MenuTime = DateTime.Now.ToFileTime;
        objBusinessRecentMenu.InserRecentMenu(objEntityRecentmenu);
        }

    }
    




}
