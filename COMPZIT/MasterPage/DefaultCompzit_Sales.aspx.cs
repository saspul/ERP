﻿using BL_Compzit;
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
using System.Web.Services;

public partial class MasterPage_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    // this web method is for fetching data based on the item selected n quotation entery screen
    [WebMethod]
    public static string IconMailCountDetails(string corporateId, string organisationId, string UserId)
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
        strCnt = "";
        return strCnt;
    }
}