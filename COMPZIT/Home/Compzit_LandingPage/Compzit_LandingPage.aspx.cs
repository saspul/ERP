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

// CREATED BY:EVM-0001
// CREATED DATE:24/03/2016
// REVIEWED BY:
// REVIEW DATE

public partial class Home_Compzit_LandingPage_Compzit_LandingPage : System.Web.UI.Page
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

        if (!IsPostBack)
        {
            DivAppIcon.Visible = false;
            divAwmsIcon.Visible = false;
            divSalesIcon.Visible = false;
            divHcmIcon.Visible = false;
            divFinanceIcon.Visible = false;
            divProcuremntIcon.Visible = false;
            DataTable dtConfigDtl = new DataTable();
            clsBusinessLayerLogin objBusinesLogin = new clsBusinessLayerLogin();
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            dtConfigDtl = objBusiness.LoadConfigDetail();
            string strDvlprInfo = "0";

            if (dtConfigDtl.Rows.Count > 0)
            {
                strDvlprInfo = dtConfigDtl.Rows[0]["DVLPR_INFO"].ToString().Trim();

            }
            //to show developed by information
            if (strDvlprInfo == "1")
            {
                string strCompanyName = "", strCompanyWeb = "";

                DataTable dtCompanyDetail = new DataTable();
                clsCommonLibrary.APP_COMPANY[] arrEnumer = { clsCommonLibrary.APP_COMPANY.CMPNY_NAME, clsCommonLibrary.APP_COMPANY.CMPNY_WEB, clsCommonLibrary.APP_COMPANY.CHNL_PARTNR_NAME, clsCommonLibrary.APP_COMPANY.CHNL_PARTNR_WEB };
                dtCompanyDetail = objBusiness.LoadCompanyDetail(arrEnumer);
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

            //when ORGANIZATION ADMIN CHOOSES A CORPORATE 
            if (Request.QueryString["CId"] != null)
            {
                string strRandomMixedId = Request.QueryString["CId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);


                Session["CORPOFFICEID"] = strId;

                clsEntityCommon objEntityCommon = new clsEntityCommon();

                if (Session["ORGID"] != null)
                {
                    objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }

                if (Session["CORPOFFICEID"] != null)
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


            // FOR APP ICON VISIBILITY
            clsBusinessLayerLogin objbusinessLayerLogin = new clsBusinessLayerLogin();
            clsEntityLayerLogin objEntLoginCount = new clsEntityLayerLogin();
            clsBusinessLayer objBusines = new clsBusinessLayer();
            DataTable dtMenuCountDtl = new DataTable();

            int intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"].ToString());

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
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
                //16-03-2019
                int intFMSCount = 0;
                int intPMSCount=0;
                if (dtMenuCountDtl.Rows[0]["MCOUNT"].ToString() != "")
                {

                    intAppAdmistratnCount = Convert.ToInt32(dtMenuCountDtl.Rows[0]["MCOUNT"].ToString());
                }
                if (dtMenuCountDtl.Rows[1]["MCOUNT"].ToString() != "0")
                {

                    intSalesForceCount = Convert.ToInt32(dtMenuCountDtl.Rows[1]["MCOUNT"].ToString());
                }
                if (dtMenuCountDtl.Rows[2]["MCOUNT"].ToString() != "0")
                {

                    intAwmsCount = Convert.ToInt32(dtMenuCountDtl.Rows[2]["MCOUNT"].ToString());
                }
                if (dtMenuCountDtl.Rows[3]["MCOUNT"].ToString() != "0")
                {

                    intGmsCount = Convert.ToInt32(dtMenuCountDtl.Rows[3]["MCOUNT"].ToString());
                }
                if (dtMenuCountDtl.Rows[4]["MCOUNT"].ToString() != "0")
                {

                    intHcmCount = Convert.ToInt32(dtMenuCountDtl.Rows[4]["MCOUNT"].ToString());
                }
                //16-03-2019
                if (dtMenuCountDtl.Rows[5]["MCOUNT"].ToString() != "0")
                {

                    intFMSCount = Convert.ToInt32(dtMenuCountDtl.Rows[5]["MCOUNT"].ToString());
                }
                //end
                if (dtMenuCountDtl.Rows[6]["MCOUNT"].ToString() != "0")
                {

                    intPMSCount = Convert.ToInt32(dtMenuCountDtl.Rows[6]["MCOUNT"].ToString());
                }

                //evm-0012
                int intTotalApps = 0;
                divGmsIcon.Visible = false;
                divSalesIcon.Visible = false;
                DivAppIcon.Visible = false;
                divAwmsIcon.Visible = false;
                divHcmIcon.Visible = false;
                divFinanceIcon.Visible = false;
                divProcuremntIcon.Visible = false;
                if (intAppAdmistratnCount != 0)
                {
                   if(intUserLimited != Convert.ToInt32(USERLIMITED.ISLIMITED))
                   {
                       intTotalApps++;

                   }
                    DivAppIcon.Visible = true;
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
                        DivAppIcon.Visible = true;
                        intTotalApps++;
                    }
                    else
                    {
                        DivAppIcon.Visible = false;

                    }
                 
                }
                if (intSalesForceCount != 0)
                {
                    intTotalApps++;
                    divSalesIcon.Visible = true;
                }
                if (intAwmsCount != 0)
                {
                    intTotalApps++;
                    divAwmsIcon.Visible = true;
                }
                if (intGmsCount != 0)
                {
                    intTotalApps++;
                    divGmsIcon.Visible = true;
                }
                if (intHcmCount != 0)
                {
                    intTotalApps++;
                    divHcmIcon.Visible = true;
                }
                if (intFMSCount != 0)
                {
                    intTotalApps++;
                    divFinanceIcon.Visible = true;
                }
                if (intPMSCount != 0)
                {
                    intTotalApps++;
                    divProcuremntIcon.Visible = true;
                }
                if (intTotalApps == 1)
                {
                   
                    if (intSalesForceCount != 0)
                    {
                        Response.Redirect("/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx");
                    }
                    else if (intAwmsCount != 0)
                    {
                        Response.Redirect("/Home/Compzit_Home/Compzit_Home_Awms.aspx");
                    }
                    else if (intGmsCount != 0)
                    {
                        Response.Redirect("/Home/Compzit_Home/Compzit_Home_Gms.aspx");
                    }
                    else if (intHcmCount != 0)
                    {
                        Response.Redirect("/Home/Compzit_Home/Compzit_Home_Hcm.aspx");
                    }
                    else if (intFMSCount != 0)
                    {
                        Response.Redirect("/Home/Compzit_Home/Compzit_Home_Finance.aspx");
                    }
                    else if (intFMSCount != 0)
                    {
                        Response.Redirect("/Home/Compzit_Home/Compzit_Home_Pms.aspx");
                    }
                }
               


              
            }

        }
    }
}