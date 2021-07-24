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
using System.Collections;
using EL_Compzit.EntityLayer_FMS;
using BL_Compzit.BusineesLayer_FMS;
using System.IO;
using Newtonsoft.Json;

public partial class Home_Compzit_Home_Compzit_Home_Finance : System.Web.UI.Page
{
    public static string strCorpIds = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["APP_ID"] = "6";

        if (Session["FRMWRK_ID"] != null && Session["FRMWRK_ID"].ToString() == "2")
        {
            aHome.HRef = "/Home/Compzit_Home/Compzit_Home_Finance.aspx";
        }
        else
        {
            aHome.HRef = " /Home/Compzit_LandingPage/Compzit_LandingPage.aspx";
        }

        if (!IsPostBack)
        {

            int intUserId = 0, intOrgId = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
            dateBankBook.InnerHtml = strCurrentDate;
            dateCashBook.InnerHtml = strCurrentDate;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            int intUsrRolMstrId = 0, intRecurrPay = 0, intRecurrRcpt = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.PAYMENT_ACCOUNT);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();
                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Recurring).ToString())
                    {
                        intRecurrPay = 1;
                    }
                }
            }
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Receipt);
            dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();
                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Recurring).ToString())
                    {
                        intRecurrRcpt = 1;
                    }
                }
            }

            //when ORGANIZATION ADMIN CHOOSES A CORPORATE 
            if (Request.QueryString["CId"] != null)
            {
                string strRandomMixedId = Request.QueryString["CId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Session["CORPOFFICEID"] = strId;

                clsBusinessLayer objBusiness = new clsBusinessLayer();

                clsEntityCommon objEntityCommon = new clsEntityCommon();

                if (Session["ORGID"] != null)
                {
                    objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                    intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
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

                        int intCorppId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = { clsCommonLibrary.CORP_GLOBAL.ACTIVE_FINCYR_ID };
                        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorppId);
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
            string strCurrIdDef = "";
            if (Session["CORPOFFICEID"] != null)
            {
                clsEntityLayerLogin objEntLogin = new clsEntityLayerLogin();
                objEntLogin.CorpOfficeId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                clsBusinessLayerLogin objBusinessLog = new clsBusinessLayerLogin();
                DataTable dtCorpName = new DataTable();
                dtCorpName = objBusinessLog.ReadCorporateName(objEntLogin);
                if (dtCorpName.Rows.Count > 0)
                {
                    strCurrIdDef = dtCorpName.Rows[0]["APCRNCY_ID"].ToString();
                }
            }


            //EVM 040 start   

            DataTable dtCorpDetail1 = new DataTable();
                    // Changed code 31-7-2020 for the purpose of checking the type of user

            if (!(((Session["DSGN_CONTROL"].ToString() == "O" || Session["DSGN_CONTROL"].ToString() == "o") && (Convert.ToInt16(Session["DSGN_TYPID"].ToString()) == Convert.ToInt16(clsCommonLibrary.DesignationType.OrganisationMosAdministrator))) || ((Session["DSGN_CONTROL"].ToString() == "O" || Session["DSGN_CONTROL"].ToString() == "o") && (Convert.ToInt16(Session["DSGN_TYPID"].ToString()) == Convert.ToInt16(clsCommonLibrary.DesignationType.App_Administrator)))))
            {

                if (Session["CORPOFFICEID"] == "" || Session["CORPOFFICEID"] == null) { }
                else
                {

                    int intCorppId1 = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    clsCommonLibrary.CORP_GLOBAL[] arrEnumer1 = { clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID };

                    dtCorpDetail1 = objBusinessLayer.LoadGlobalDetail(arrEnumer1, intCorppId1);
                    if (dtCorpDetail1.Rows.Count > 0)
                    {
                        if (dtCorpDetail1.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString() != "")
                        {
                            Session["CRNCMSTID"] = Convert.ToInt32(dtCorpDetail1.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
                        }
                    }
                }
            }
            clsBusiness_Account_Setting objBussinessAccount = new clsBusiness_Account_Setting();
            clsEntity_Account_Setting objEntityAccount = new clsEntity_Account_Setting();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityAccount.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            if (Session["ORGID"] != null)
            {
                objEntityAccount.OrgId = Convert.ToInt32(Session["ORGID"]);
                DataTable dtSubConrt = objBussinessAccount.ReadFinancialYear(objEntityAccount);
                for (int intCount = 0; intCount < dtSubConrt.Rows.Count; intCount++)
                {
                    if (Convert.ToString(Session["FINCYRID"]) == dtSubConrt.Rows[intCount]["FINCYR_ID"].ToString())
                    {
                        HiddenFinancialYear.Value = dtSubConrt.Rows[intCount]["FINCYR_DEFAULTNAME"].ToString();
                    }
                }
            }
            //EVM 040 end


            //Read Business Units
            clsBusinessLayerLogin objbusinessLayerLogin = new clsBusinessLayerLogin();
            clsEntityLayerLogin objEntLoginOControl = new clsEntityLayerLogin();
            objEntLoginOControl.OrgId = intOrgId;
            DataTable dtCorp = new DataTable();
            if (Session["DSGN_CONTROL"] != null)
            {
                if ((Session["DSGN_CONTROL"].ToString() == "O" || Session["DSGN_CONTROL"].ToString() == "o") && (Convert.ToInt16(Session["DSGN_TYPID"].ToString()) == Convert.ToInt16(clsCommonLibrary.DesignationType.OrganisationMosAdministrator)))
                {
                    dtCorp = objbusinessLayerLogin.Read_BussnsUnit_OrgId(objEntLoginOControl);
                }
                if (Session["DSGN_CONTROL"].ToString() == "C" || Session["DSGN_CONTROL"].ToString() == "c")
                {
                    objEntLoginOControl.UserIdInt = intUserId;
                    dtCorp = objbusinessLayerLogin.ReadAcsBussnssUnit_UsrId(objEntLoginOControl);
                }
            }
            if (dtCorp.Rows.Count > 0)
            {
                string strHtml = "<ul>";
                string strHtml1 = "<ul>";
                strCorpIds = "";
                for (int i = 0; i < dtCorp.Rows.Count; i++)
                {
                    if (strCorpIds == "")
                    {
                        strCorpIds = dtCorp.Rows[i]["CORPRT_ID"].ToString();
                    }
                    else
                    {
                        strCorpIds = strCorpIds + "," + dtCorp.Rows[i]["CORPRT_ID"].ToString();
                    }
                    strHtml += "<a onclick=\"return  BankBookBUclick('" + dtCorp.Rows[i]["CORPRT_ID"].ToString() + "','" + dtCorp.Rows[i]["CORPRT_NAME"].ToString() + "','14');\"><li class=\"spn2 li1\">" + dtCorp.Rows[i]["CORPRT_NAME"].ToString() + "</li></a>";
                    strHtml1 += "<a onclick=\"return BankBookBUclick('" + dtCorp.Rows[i]["CORPRT_ID"].ToString() + "','" + dtCorp.Rows[i]["CORPRT_NAME"].ToString() + "','13');\"><li class=\"spn2 li1\">" + dtCorp.Rows[i]["CORPRT_NAME"].ToString() + "</li></a>";
                }
                strHtml += "</ul>";
                strHtml1 += "</ul>";
                if (dtCorp.Rows.Count < 2)
                {
                    dtBankBookBu.Visible = false;
                    dtCashBookBu.Visible = false;
                }
                else
                {
                    dtCashBookBu.InnerHtml = strHtml;
                    dtBankBookBu.InnerHtml = strHtml1;
                }
                divDebtorAmnts.InnerHtml = LoadDebtorOutstanding(strCorpIds, 15, strCurrIdDef);
                if (divDebtorAmnts.InnerHtml == "")
                {
                    divDebtor.Visible = false;
                }
                divCreditorAmnts.InnerHtml = LoadDebtorOutstanding(strCorpIds, 16, strCurrIdDef);
                if (divCreditorAmnts.InnerHtml == "")
                {
                    divCreditor.Visible = false;
                }
            }

                    // Changed code 31-7-2020 for the purpose of checking the type of user

            if (!(((   Session["DSGN_CONTROL"].ToString().ToUpper() == "O" ) && (Convert.ToInt16(Session["DSGN_TYPID"].ToString()) == Convert.ToInt16(clsCommonLibrary.DesignationType.OrganisationMosAdministrator))) || ((Session["DSGN_CONTROL"].ToString().ToUpper() == "O") && (Convert.ToInt16(Session["DSGN_TYPID"].ToString()) == Convert.ToInt16(clsCommonLibrary.DesignationType.App_Administrator)))))
            {

                divBankBookLdgr.InnerHtml = LoadBankBook(Session["CORPOFFICEID"].ToString(), strCurrentDate, "13");
                divCashBookLdgr.InnerHtml = LoadBankBook(Session["CORPOFFICEID"].ToString(), strCurrentDate, "14");
                lblBUseleBank.InnerHtml = Session["CORPORATENAME"].ToString();
                lblBUseleCash.InnerHtml = Session["CORPORATENAME"].ToString();


                if (intRecurrRcpt != 0 || intRecurrPay != 0)
                {
                    LoadPendingOrders(intRecurrRcpt, intRecurrPay);
                }
                if (intRecurrRcpt == 0)
                {
                    menu2.Attributes.Add("style", "display:none");
                }
                if (intRecurrPay == 0)
                {
                    menu1.Attributes.Add("style", "display:none");
                }
                if (intRecurrPay == 0 && intRecurrRcpt == 0)
                {
                    divMainNotf.Attributes.Add("style", "display:none");
                }
                LoadPostDatedCheques();
            }

        }
    }
    [WebMethod]
    public static string LoadBankBook(string CorpId, string dateTo,string Mode)
    {
        clsEntityCommon objEntitylayer = new clsEntityCommon();
        clsBusinessLayerFinanceHome objBusinessLayer = new clsBusinessLayerFinanceHome();
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        objEntitylayer.Date = ObjCommonlib.textToDateTime(dateTo);
        objEntitylayer.CorporateID = Convert.ToInt32(CorpId);
        if(Convert.ToInt32(Mode)==13)
        objEntitylayer.PrimaryGrpIds = Convert.ToString(Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.BANK));
        else if (Convert.ToInt32(Mode) == 14)
            objEntitylayer.PrimaryGrpIds = Convert.ToString(Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.CASHINHND));
       // objEntitylayer.PrimaryGrpIds = Mode;
        string strHtml = "";
        try
        {
            DataTable dt = objBusinessLayer.LoadBankBookDtls(objEntitylayer);         
            if (Mode == "13")
            {
                strHtml = LoadBankBookHTML(dt, CorpId);
            }
            else
            {
                strHtml = LoadCashBookHTML(dt, CorpId);
            }
        }
        catch(Exception ex){
        }
        return strHtml;
    }
    public static string LoadBankBookHTML(DataTable dt, string CorpId)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = Convert.ToInt32(CorpId);
        int Decimalcount = 0;
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                    clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                    };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }

        string strId = CorpId;
        int intIdLength = CorpId.Length;
        string stridLength = intIdLength.ToString("00");
        string StrCorpId = stridLength + strId + strRandom;

        string format = String.Format("{{0:N{0}}}", Decimalcount);       
        string strHtml = "";
        int Cnt = Convert.ToInt32(dt.Rows.Count / 2);
        for (int i = 0; i < Cnt; i++)
        {
             int j = i * 2;

            decimal TotAmnt1 = 0, TotAmnt2 = 0, TotAmntReco1 = 0, TotAmntReco2 = 0;
            string strTotAmnt1 = "", strTotAmnt2 = "", strTotAmntReco1 = "", strTotAmntReco2 = "";
            string strTotAmnt1Mode = "DR", strTotAmnt2Mode = "DR", strTotAmntReco1Mode = "DR", strTotAmntReco2Mode = "DR";
            TotAmnt1 = Convert.ToDecimal(dt.Rows[j]["TOTAL_AMNT"].ToString());
            TotAmntReco1 = Convert.ToDecimal(dt.Rows[j]["TOTAL_AMNT_RECON"].ToString());
            TotAmnt2 = Convert.ToDecimal(dt.Rows[j + 1]["TOTAL_AMNT"].ToString());
            TotAmntReco2 = Convert.ToDecimal(dt.Rows[j + 1]["TOTAL_AMNT_RECON"].ToString());
            if (TotAmnt1 < 0)
            {
                TotAmnt1 = TotAmnt1 * -1;
                strTotAmnt1Mode = "CR";
            }
            if (TotAmnt2 < 0)
            {
                TotAmnt2 = TotAmnt2 * -1;
                strTotAmnt2Mode = "CR";
            }
            if (TotAmntReco1 < 0)
            {
                TotAmntReco1 = TotAmntReco1 * -1;
                strTotAmntReco1Mode = "CR";
            }
            if (TotAmntReco2 < 0)
            {
                TotAmntReco2 = TotAmntReco2 * -1;
                strTotAmntReco2Mode = "CR";
            }
            if (TotAmnt1 == 0)
            {
                strTotAmnt1 = String.Format(format, TotAmnt1);
            }
            else
            {
                strTotAmnt1 = objBusiness.AddCommasForNumberSeperation(TotAmnt1.ToString(), objEntityCommon);
            }
            if (TotAmnt2 == 0)
            {
                strTotAmnt2 = String.Format(format, TotAmnt2);
            }
            else
            {
                strTotAmnt2 = objBusiness.AddCommasForNumberSeperation(TotAmnt2.ToString(), objEntityCommon);
            }
            if (TotAmntReco1 == 0)
            {
                strTotAmntReco1 = String.Format(format, TotAmntReco1);
            }
            else
            {
                strTotAmntReco1 = objBusiness.AddCommasForNumberSeperation(TotAmntReco1.ToString(), objEntityCommon);
            }
            if (TotAmntReco2 == 0)
            {
                strTotAmntReco2 = String.Format(format, TotAmntReco2);
            }
            else
            {
                strTotAmntReco2 = objBusiness.AddCommasForNumberSeperation(TotAmntReco2.ToString(), objEntityCommon);
            }
           
            if (i == 0)
            {
                strHtml += "<div class=\"item active\">";
            }
            else
            {
                strHtml += "<div class=\"item\">";
            }
            strId = dt.Rows[j]["LDGR_ID"].ToString();
            intIdLength = dt.Rows[j]["LDGR_ID"].ToString().Length;
            stridLength = intIdLength.ToString("00");
            string Id1 = stridLength + strId + strRandom;

            strId = dt.Rows[j+1]["LDGR_ID"].ToString();
            intIdLength = dt.Rows[j+1]["LDGR_ID"].ToString().Length;
            stridLength = intIdLength.ToString("00");
            string Id2 = stridLength + strId + strRandom;

            strHtml += "<div class=\"asper1\"><a href=\"/FMS/FMS_Reports/fms_Ledger_Statement/fms_Ledger_Statement.aspx?Id=" + Id1 + "&Corpid=" + StrCorpId + "\">";
            strHtml += "<div class=\"Bank_head\">";
            strHtml += "<h5>" + dt.Rows[j]["LDGR_NAME"].ToString() + "</h5>";
            strHtml += "<table class=\"table1\">";
            strHtml += " <thead>";
            strHtml += "<tr class=\"tr2\">";
            strHtml += " <th class=\"th1\">AS PER BOOK</th>";
            strHtml += " <th class=\"th1\">AS PER BANK</th>";
            strHtml += " </tr>";
            strHtml += "  </thead>";
            strHtml += "<tbody>";
            strHtml += " <tr>";
            strHtml += "<td></td><td></td><td></td>";
            strHtml += " </tr>";
            strHtml += " <tr>";
            strHtml += " <td class=\"td1\"><a ><span class=\"spn2\">" + dt.Rows[j]["CRNCMST_ABBRV"].ToString() + "</span>&nbsp" + strTotAmnt1 + strTotAmnt1Mode + "</a></td>";
            strHtml += "<td class=\"td2\"><a ><span class=\"spn2\">" + dt.Rows[j]["CRNCMST_ABBRV"].ToString() + "</span>&nbsp" + strTotAmntReco1 + strTotAmntReco1Mode + "</a></td>";
            strHtml += "</tr>";
            strHtml += " </tbody>";
            strHtml += "</table>";
            strHtml += "</div>";
            strHtml += "</a></div>";
            strHtml += "<div class=\"asper2\"><a href=\"/FMS/FMS_Reports/fms_Ledger_Statement/fms_Ledger_Statement.aspx?Id=" + Id2 + "&Corpid=" + StrCorpId + "\">";
            strHtml += "<div class=\"Bank_head\">";
            strHtml += "<h5>" + dt.Rows[j + 1]["LDGR_NAME"].ToString() + "</h5>";
            strHtml += "<table class=\"table1\">";
            strHtml += "<thead>";
            strHtml += "<tr class=\"tr2\">";
            strHtml += "<th class=\"th1\">AS PER BOOK</th>";
            strHtml += "<th class=\"th1\">AS PER BANK</th>";
            strHtml += "</tr>";
            strHtml += "</thead>";
            strHtml += "<tbody>";
            strHtml += "<tr>";
            strHtml += "<td></td><td></td><td></td>";
            strHtml += "</tr>";
            strHtml += "<tr>";
            strHtml += "<td class=\"td1\"><a ><span class=\"spn2\">" + dt.Rows[j + 1]["CRNCMST_ABBRV"].ToString() + "</span>&nbsp" + strTotAmnt2 + strTotAmnt2Mode + "</a></td>";
            strHtml += "<td class=\"td2\"><a ><span class=\"spn2\">" + dt.Rows[j + 1]["CRNCMST_ABBRV"].ToString() + "</span>&nbsp" + strTotAmntReco2 + strTotAmntReco2Mode + "</a></td>";
            strHtml += "</tr>";
            strHtml += "</tbody>";
            strHtml += "</table>";
            strHtml += "</div>";
            strHtml += "</a></div>";
            strHtml += "</div>";
        }
        if (dt.Rows.Count % 2 == 1)
        {
            int j = dt.Rows.Count - 1;
            decimal TotAmnt1 = 0, TotAmntReco1 = 0;
            string strTotAmnt1 = "", strTotAmntReco1 = "";
            string strTotAmnt1Mode = "DR",  strTotAmntReco1Mode = "DR";
            TotAmnt1 = Convert.ToDecimal(dt.Rows[j]["TOTAL_AMNT"].ToString());
            TotAmntReco1 = Convert.ToDecimal(dt.Rows[j]["TOTAL_AMNT_RECON"].ToString());
            if (TotAmnt1 < 0)
            {
                TotAmnt1 = TotAmnt1 * -1;
                strTotAmnt1Mode = "CR";
            }
            if (TotAmntReco1 < 0)
            {
                TotAmntReco1 = TotAmntReco1 * -1;
                strTotAmntReco1Mode = "CR";
            }
            if (TotAmnt1 == 0)
            {
                strTotAmnt1 = String.Format(format, TotAmnt1);
            }
            else
            {
                strTotAmnt1 = objBusiness.AddCommasForNumberSeperation(TotAmnt1.ToString(), objEntityCommon);
            }
            if (TotAmntReco1 == 0)
            {
                strTotAmntReco1 = String.Format(format, TotAmntReco1);
            }
            else
            {
                strTotAmntReco1 = objBusiness.AddCommasForNumberSeperation(TotAmntReco1.ToString(), objEntityCommon);
            }
            strId = dt.Rows[j]["LDGR_ID"].ToString();
            intIdLength = dt.Rows[j]["LDGR_ID"].ToString().Length;
            stridLength = intIdLength.ToString("00");
            string Id1 = stridLength + strId + strRandom;
            if (Cnt == 0)
            {
                strHtml += "<div class=\"item active\">";
            }
            else
            {
                strHtml += "<div class=\"item\">";
            }
            strHtml += "<div class=\"asper1\"><a href=\"/FMS/FMS_Reports/fms_Ledger_Statement/fms_Ledger_Statement.aspx?Id=" + Id1 + "&Corpid=" + StrCorpId + "\">";
            strHtml += "<div class=\"Bank_head\">";
            strHtml += "<h5>" + dt.Rows[j]["LDGR_NAME"].ToString() + "</h5>";
            strHtml += "<table class=\"table1\">";
            strHtml += " <thead>";
            strHtml += "<tr class=\"tr2\">";
            strHtml += " <th class=\"th1\">AS PER BOOK</th>";
            strHtml += " <th class=\"th1\">AS PER BANK</th>";
            strHtml += " </tr>";
            strHtml += "  </thead>";
            strHtml += "<tbody>";
            strHtml += " <tr>";
            strHtml += "<td></td><td></td><td></td>";
            strHtml += " </tr>";
            strHtml += " <tr>";
            strHtml += " <td class=\"td1\"><a ><span class=\"spn2\">" + dt.Rows[j]["CRNCMST_ABBRV"].ToString() + "</span>&nbsp" + strTotAmnt1 + strTotAmnt1Mode + "</a></td>";
            strHtml += "<td class=\"td2\"><a ><span class=\"spn2\">" + dt.Rows[j]["CRNCMST_ABBRV"].ToString() + "</span>&nbsp" + strTotAmntReco1 + strTotAmntReco1Mode + "</a></td>";
            strHtml += "</tr>";
            strHtml += " </tbody>";
            strHtml += "</table>";
            strHtml += "</div>";
            strHtml += "</a></div>";
            strHtml += "</div>";
        }
        return strHtml;
    }
    public static string LoadCashBookHTML(DataTable dt, string CorpId)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = Convert.ToInt32(CorpId);
        int Decimalcount = 0;
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                    clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                    };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }
        string strId = CorpId;
        int intIdLength = CorpId.Length;
        string stridLength = intIdLength.ToString("00");
        string StrCorpId = stridLength + strId + strRandom;
        string format = String.Format("{{0:N{0}}}", Decimalcount);
        string strHtml = "";
        int Cnt = Convert.ToInt32(dt.Rows.Count / 2);
        for (int i = 0; i < Cnt; i++)
        {
            int j = i * 2;
            decimal TotAmnt1 = 0, TotAmnt2 = 0;
            string strTotAmnt1 = "", strTotAmnt2 = "";
            string strTotAmnt1Mode = "DR", strTotAmnt2Mode = "DR";
            TotAmnt1 = Convert.ToDecimal(dt.Rows[j]["TOTAL_AMNT"].ToString());
            TotAmnt2 = Convert.ToDecimal(dt.Rows[j + 1]["TOTAL_AMNT"].ToString());
            if (TotAmnt1 < 0)
            {
                TotAmnt1 = TotAmnt1 * -1;
                strTotAmnt1Mode = "CR";
            }
            if (TotAmnt2 < 0)
            {
                TotAmnt2 = TotAmnt2 * -1;
                strTotAmnt2Mode = "CR";
            }
            if (TotAmnt1 == 0)
            {
                strTotAmnt1 = String.Format(format, TotAmnt1);
            }
            else
            {
                strTotAmnt1 = objBusiness.AddCommasForNumberSeperation(TotAmnt1.ToString(), objEntityCommon);
            }
            if (TotAmnt2 == 0)
            {
                strTotAmnt2 = String.Format(format, TotAmnt2);
            }
            else
            {
                strTotAmnt2 = objBusiness.AddCommasForNumberSeperation(TotAmnt2.ToString(), objEntityCommon);
            }
            strId = dt.Rows[j]["LDGR_ID"].ToString();
            intIdLength = dt.Rows[j]["LDGR_ID"].ToString().Length;
            stridLength = intIdLength.ToString("00");
            string Id1 = stridLength + strId + strRandom;

            strId = dt.Rows[j + 1]["LDGR_ID"].ToString();
            intIdLength = dt.Rows[j + 1]["LDGR_ID"].ToString().Length;
            stridLength = intIdLength.ToString("00");
            string Id2 = stridLength + strId + strRandom;
            if (i == 0)
            {
                strHtml += "<div class=\"item active\">";
            }
            else
            {
                strHtml += "<div class=\"item\">";
            }
            strHtml += "<a href=\"/FMS/FMS_Reports/fms_Ledger_Statement/fms_Ledger_Statement.aspx?Id=" + Id1 + "&Corpid=" + StrCorpId + "\">";
            strHtml += "<div class=\"petty\">";
            strHtml += "<h5>" + dt.Rows[j]["LDGR_NAME"].ToString() + "</h5>";
            strHtml += "<h4><span class=\"spn2\">" + dt.Rows[j]["CRNCMST_ABBRV"].ToString() + "</span>&nbsp" + strTotAmnt1 + strTotAmnt1Mode + "</h4>";
            strHtml += "</div>";
            strHtml += "</a>";
            strHtml += "<a href=\"/FMS/FMS_Reports/fms_Ledger_Statement/fms_Ledger_Statement.aspx?Id=" + Id2 + "&Corpid=" + StrCorpId + "\">";
            strHtml += "<div class=\"main\">";
            strHtml += "<h5>" + dt.Rows[j + 1]["LDGR_NAME"].ToString() + "</h5>";
            strHtml += "<h4><span class=\"spn2\">" + dt.Rows[j + 1]["CRNCMST_ABBRV"].ToString() + "</span>&nbsp" + strTotAmnt2 + strTotAmnt2Mode + "</h4>";
            strHtml += "</div>";
            strHtml += "</a>";
            strHtml += "</div>";
        }
        if (dt.Rows.Count % 2 == 1)
        {
            int j = dt.Rows.Count - 1;
            decimal TotAmnt1 = 0;
            string strTotAmnt1 = "";
            string strTotAmnt1Mode = "DR";
            TotAmnt1 = Convert.ToDecimal(dt.Rows[j]["TOTAL_AMNT"].ToString());
            if (TotAmnt1 < 0)
            {
                TotAmnt1 = TotAmnt1 * -1;
                strTotAmnt1Mode = "CR";
            }
            if (TotAmnt1 == 0)
            {
                strTotAmnt1 = String.Format(format, TotAmnt1);
            }
            else
            {
                strTotAmnt1 = objBusiness.AddCommasForNumberSeperation(TotAmnt1.ToString(), objEntityCommon);
            }
            if (Cnt == 0)
            {
                strHtml += "<div class=\"item active\">";
            }
            else
            {
                strHtml += "<div class=\"item\">";
            }
            strId = dt.Rows[j]["LDGR_ID"].ToString();
            intIdLength = dt.Rows[j]["LDGR_ID"].ToString().Length;
            stridLength = intIdLength.ToString("00");
            string Id1 = stridLength + strId + strRandom;
            strHtml += "<a href=\"/FMS/FMS_Reports/fms_Ledger_Statement/fms_Ledger_Statement.aspx?Id=" + Id1 + "&Corpid=" + StrCorpId + "\">";
            strHtml += "<div class=\"petty\">";
            strHtml += "<h5>" + dt.Rows[j]["LDGR_NAME"].ToString() + "</h5>";
            strHtml += "<h4><span class=\"spn2\">" + dt.Rows[j]["CRNCMST_ABBRV"].ToString() + "</span>&nbsp" + strTotAmnt1 + strTotAmnt1Mode + "</h4>";
            strHtml += "</div>";
            strHtml += "</a>";
            strHtml += "</div>";
        }
        return strHtml;
    }
    public string LoadDebtorOutstanding(string strCorpIds,int mode,string strCurrIdDef)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int Decimalcount = 2;
        string format = String.Format("{{0:N{0}}}", Decimalcount);

        string strHtml = "";
        clsEntityCostGrpPerfAnalysis objEntitylayer = new clsEntityCostGrpPerfAnalysis();
        clsBusinessLayerFinanceHome objBusinessLayer = new clsBusinessLayerFinanceHome();
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        objEntityCommon.Date = ObjCommonlib.textToDateTime(dateBankBook.InnerHtml);
        objEntityCommon.CorprtIds = strCorpIds;
        //objEntityCommon.PrimaryGrpIds =Convert.ToString( mode);
        if (mode == 16)
        {
            objEntityCommon.PrimaryGrpIds = Convert.ToString(Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.SUNDRYCREDITR));
        }
        else
        {
            objEntityCommon.PrimaryGrpIds = Convert.ToString(Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.SUNDRYDEBTR));
        }
        if (Session["ORGID"] != null)
        {
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            DataTable dt = objBusinessLayer.LoadDebtorDtls(objEntityCommon); //cr
            string strClass="btn btn-success btn1 d1";
            if(mode==16){
                strClass = "btn btn-danger btn1 d2";
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[i]["CRNCMST_ID"].ToString());
                decimal TotAmnt1 = 0;
                string strTotAmnt1 = "";
                string strTotAmnt1Mode = "DR";
                TotAmnt1 = Convert.ToDecimal(dt.Rows[i]["LDGR_BAL"].ToString());
                if (TotAmnt1 < 0)
                {
                    TotAmnt1 = TotAmnt1 * -1;
                    strTotAmnt1Mode = "CR";
                }               
                 strTotAmnt1 = String.Format(format, TotAmnt1);
                if (strCurrIdDef == dt.Rows[i]["CRNCMST_ID"].ToString() || (strCurrIdDef=="" && i==0))
                {
                    strHtml += "<div class=\"item active\">";
                }
                else
                {
                    strHtml += "<div class=\"item\">";
                }
                strHtml += "<a >";
                strHtml += "<div class=\"debt\">";
                strHtml += "<h5>AMOUNT IN " + dt.Rows[i]["CRNCMST_NAME"].ToString() + "</h5>";
                strHtml += "<button class=\"" + strClass + "\" onmouseover=\"return DebtorChange('" + dt.Rows[i]["CRNCMST_ID"].ToString() + "','" + dt.Rows[i]["CRNCMST_ABBRV"].ToString() + "','" + mode + "');\"><i class=\"fa fa-money\" aria-hidden=\"true\"></i>&nbsp" + dt.Rows[i]["CRNCMST_ABBRV"].ToString() + "&nbsp" + strTotAmnt1 + strTotAmnt1Mode;
                strHtml += "<i class=\"fa fa-chevron-down\" aria-hidden=\"true\"></i>";
                strHtml += "</button>";
                strHtml += "</div>";
                strHtml += "</a>";
                strHtml += "</div>";
            }
        }
        return strHtml;
    }
    [WebMethod]
    public static string LoadDebtorBu(string orgID, string dateTo, string CurrencyId,string mode)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int Decimalcount = 2;
        string format = String.Format("{{0:N{0}}}", Decimalcount);
        objEntityCommon.CurrencyId = Convert.ToInt32(CurrencyId);

        clsEntityCostGrpPerfAnalysis objEntitylayer = new clsEntityCostGrpPerfAnalysis();
        clsBusinessLayerFinanceHome objBusinessLayer = new clsBusinessLayerFinanceHome();
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        objEntityCommon.Date = ObjCommonlib.textToDateTime(dateTo);
        objEntityCommon.CorprtIds = strCorpIds;
        objEntityCommon.Organisation_Id = Convert.ToInt32(orgID);
        objEntityCommon.CurrencyId = Convert.ToInt32(CurrencyId);
        if (mode == "16")
        {
            objEntityCommon.PrimaryGrpIds = Convert.ToString(Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.SUNDRYCREDITR));
        }
        else
        {
            objEntityCommon.PrimaryGrpIds = Convert.ToString(Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.SUNDRYDEBTR));
        }
       // objEntityCommon.PrimaryGrpIds = Convert.ToString(mode);
        DataTable dt = objBusinessLayer.LoadDebtorDtls(objEntityCommon);//dr
        string strHtml = "";
        if(dt.Rows.Count>0){
        strHtml+="<ul>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            decimal TotAmnt1 = 0;
            string strTotAmnt1 = "";
            string strTotAmnt1Mode = "DR";
            TotAmnt1 = Convert.ToDecimal(dt.Rows[i]["LDGR_BAL"].ToString());
            if (TotAmnt1 < 0)
            {
                TotAmnt1 = TotAmnt1 * -1;
                strTotAmnt1Mode = "CR";
            }
           
            strTotAmnt1 = String.Format(format, TotAmnt1);
            string strId = dt.Rows[i]["CORPRT_ID"].ToString();
            int intIdLength = dt.Rows[i]["CORPRT_ID"].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string StrCorpId = stridLength + strId + strRandom;

            string strHref="";
            if(mode=="15"){
                strHref = "/FMS/FMS_Reports/fms_Customer_Outstanding/fms_Customer_Outstanding.aspx?Id=" + StrCorpId;
            }
            else{
                strHref = "/FMS/FMS_Reports/fms_Supplier_Outstanding/fms_Supplier_Outstanding.aspx?Id=" + StrCorpId;
            }
            strHtml += "<a href=\"" + strHref + "\"><li class=\"spn2 li1\"><span class=\"cl_b tx_l\">BU : <span class=\"cl_r\">" + dt.Rows[i]["CORPRT_NAME"].ToString() + "</span></span> <span class=\"cl_b tx_r\">" + dt.Rows[i]["CRNCMST_ABBRV"].ToString() + "&nbsp<span class=\"cl_r\">" + strTotAmnt1 + strTotAmnt1Mode + "</span></span></li></a>";    
        }
        strHtml+="</ul>";
        }
        return strHtml;
    }

    public void LoadPendingOrders(int intRecurrRcpt,int intRecurrPay)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        if (Session["ORGID"] != null)
           {
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
           }

        if (Session["CORPOFFICEID"] != null)
          {
          objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"]);
          intCorpId = objEntityCommon.CorporateID;
          }
        
        int Decimalcount = 0;
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                    clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                    };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }
        string format = String.Format("{{0:N{0}}}", Decimalcount);
        string strHtml = "", strHtml1 = "";

        clsBusinessLayerFinanceHome objBusinessLayer = new clsBusinessLayerFinanceHome();
        DataTable dt = objBusinessLayer.ReadRecurrnceList(objEntityCommon);
        List<clsEntityCommon> objEntityNewOrdersList = new List<clsEntityCommon>();
        DateTime dtCurrentDate = objCommon.textToDateTime(dateBankBook.InnerHtml);     
        for (int i = 0; i < dt.Rows.Count; i++)
        {           
            DateTime dtRecurrDate = objCommon.textToDateTime(dt.Rows[i]["REPAREC_CURR_DATE"].ToString());
            int Period = Convert.ToInt32(dt.Rows[i]["REPAREC_PERIOD"].ToString());
            int RemindDays = Convert.ToInt32(dt.Rows[i]["REPAREC_REM_DAYS"].ToString());
            int RecurrMasterTabId = Convert.ToInt32(dt.Rows[i]["REPAREC_ID"].ToString());
            int PayRecpId = 0, PayRecpSts = 0;
            if (dt.Rows[i]["PAYMNT_ID"].ToString() != "")
            {
                PayRecpId = Convert.ToInt32(dt.Rows[i]["PAYMNT_ID"].ToString());
                PayRecpSts = 0;
            }
            else
            {
                PayRecpId = Convert.ToInt32(dt.Rows[i]["RECPT_ID"].ToString());
                PayRecpSts = 1;
            }
            DateTime dtNewRecurDate = new DateTime();
            DateTime dtRemindDate = new DateTime();
            if (Period == 1)
            {
                dtNewRecurDate = dtRecurrDate.AddDays(1);
            }
            else if (Period == 2)
            {
                dtNewRecurDate = dtRecurrDate.AddMonths(1);
            }
            else if (Period == 3)
            {
                dtNewRecurDate = dtRecurrDate.AddMonths(2);
            }
            else if (Period == 4)
            {
                dtNewRecurDate = dtRecurrDate.AddMonths(6);
            }
            else if (Period == 5)
            {
                dtNewRecurDate = dtRecurrDate.AddYears(1);
            }
            dtRemindDate = dtNewRecurDate.AddDays(RemindDays*-1);
            DataTable dtOrd = objBusinessLayer.ReadRecurrnceOrderList(objEntityCommon);
            while(dtRemindDate <= dtCurrentDate)
            {               
                DataRow[] results = dtOrd.Select("REPAREC_ID ='" + dt.Rows[i]["REPAREC_ID"].ToString() + "' AND  REPARECSUB_DATE='" + dtNewRecurDate.ToString("dd-MM-yyyy") + "'");
                if (results.Length == 0)
                {
                    clsEntityCommon objRecur = new clsEntityCommon();
                    objRecur.RecurMasterId = RecurrMasterTabId;
                    objRecur.RecurDate = objCommon.textToDateTime(dtNewRecurDate.ToString("dd-MM-yyyy"));
                    objRecur.SectionId = PayRecpSts;
                    objRecur.RecurSubId = intUserId;
                    objEntityNewOrdersList.Add(objRecur);
                }


                dtRecurrDate = objCommon.textToDateTime(dtNewRecurDate.ToString("dd-MM-yyyy"));
                if (Period == 1)
                {
                    dtNewRecurDate = dtRecurrDate.AddDays(1);
                }
                else if (Period == 2)
                {
                    dtNewRecurDate = dtRecurrDate.AddMonths(1);
                }
                else if (Period == 3)
                {
                    dtNewRecurDate = dtRecurrDate.AddMonths(2);
                }
                else if (Period == 4)
                {
                    dtNewRecurDate = dtRecurrDate.AddMonths(6);
                }
                else if (Period == 5)
                {
                    dtNewRecurDate = dtRecurrDate.AddYears(1);
                }
                dtRemindDate = dtNewRecurDate.AddDays(RemindDays * -1);
            }
        }
        if (objEntityNewOrdersList.Count > 0)
        {
            objBusinessLayer.insertNewORders(objEntityNewOrdersList);
        }
        DataTable dtOrders = objBusinessLayer.ReadRecurrnceOrderList(objEntityCommon);
        int Cnt = 0, Cnt1 = 0;
        for (int i = 0; i < dtOrders.Rows.Count; i++)
        {

            if(intRecurrRcpt==1 && dtOrders.Rows[i]["REPARECSUB_STS"].ToString()=="1")
            {
            Cnt++;
            string strId = dtOrders.Rows[i]["REPARECSUB_ID"].ToString();
            int intIdLength = dtOrders.Rows[i]["REPARECSUB_ID"].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string StrCorpId = stridLength + strId + strRandom;
            string href="",refe="";
            href = "/FMS/FMS_Master/fms_Receipt_Account/fms_Receipt_Account.aspx?Rid=" + StrCorpId;
            refe = dtOrders.Rows[i]["RECPT_REF"].ToString();

           strHtml += "<tr>";
           strHtml += "<td class=\"td_rec\">";
           strHtml += "<a href=\"" + href + "\" class=\"flip_o\" onmouseover=\"return ShowOrderDtls('" + StrCorpId + "');\">" + dtOrders.Rows[i]["REPARECSUB_DATE"].ToString() + "</a>";
           strHtml += "</td>";
           strHtml += "<td class=\"td_rec1\">" + refe + "</td>";
           strHtml += "<td class=\"td_rec\">"; 
           strHtml += "<div class=\"btn_stl1\">";
           strHtml += "<button onclick=\"return RecurReject('" + StrCorpId + "');\" class=\"btn act_btn bn3 rec_bn\" title=\"Reject\"><i class=\"fa fa-times\"></i></button>";
           strHtml += "</div>";
           strHtml += "</td>";
           strHtml += "</tr>";
            }
            else if (intRecurrPay == 1 && dtOrders.Rows[i]["REPARECSUB_STS"].ToString() == "0")
            {
                Cnt1++;
                string strId = dtOrders.Rows[i]["REPARECSUB_ID"].ToString();
                int intIdLength = dtOrders.Rows[i]["REPARECSUB_ID"].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string StrCorpId = stridLength + strId + strRandom;
                string href = "", refe = "";              
                href = "/FMS/FMS_Master/fms_Payment_Account/fms_Payment_Account.aspx?Rid=" + StrCorpId;
                refe = dtOrders.Rows[i]["PAYMNT_REF"].ToString();

                strHtml1 += "<tr>";
                strHtml1 += "<td class=\"td_rec\">";
                strHtml1 += "<a href=\"" + href + "\" class=\"flip_o\" onmouseover=\"return ShowOrderDtls('" + StrCorpId + "');\">" + dtOrders.Rows[i]["REPARECSUB_DATE"].ToString() + "</a>";
                strHtml1 += "</td>";
                strHtml1 += "<td class=\"td_rec1\">" + refe + "</td>";
                strHtml1 += "<td class=\"td_rec\">";
                strHtml1 += "<div class=\"btn_stl1\">";
                strHtml1 += "<button onclick=\"return RecurReject('" + StrCorpId + "');\" class=\"btn act_btn bn3 rec_bn\" title=\"Reject\"><i class=\"fa fa-times\"></i></button>";
                strHtml1 += "</div>";
                strHtml1 += "</td>";
                strHtml1 += "</tr>";
            }


        }

        if (Cnt > 0)
        {
            sPendOrdNumRecp.InnerText = Cnt.ToString();
            menu2.Attributes.Add("style", "display:block");
        }
        else
        {
            menu2.Attributes.Add("style", "display:none");
        }

        if (Cnt1 > 0)
        {
            sPendOrdNum.InnerText = Cnt1.ToString();
            menu1.Attributes.Add("style", "display:block");
        }
        else
        {
            menu1.Attributes.Add("style", "display:none");
        }

        if ((Cnt1 + Cnt) > 0)
        {
            sMainNotfCnt.InnerText = (Cnt1 + Cnt).ToString();
            divMainNotf.Attributes.Add("style", "display:block");
        }
        else
        {
            divMainNotf.Attributes.Add("style", "display:none");
        }

        myTable.InnerHtml=strHtml;
        myTable2.InnerHtml = strHtml1;
    }

    [WebMethod]
    public static string ShowOrderDtls(string strid, string CorpId)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
       
        string strRandomMixedId = strid;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        clsBusinessLayerFinanceHome objBusinessLayer = new clsBusinessLayerFinanceHome();
        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
        objEntityCommon.RecurSubId = Convert.ToInt32(strId);
        objEntityCommon.CorporateID = Convert.ToInt32(CorpId);
        DataTable dt = objBusinessLayer.ReadOrderDtls(objEntityCommon);//dr
        string strHtml = "";
        if (dt.Rows.Count > 0)
        {
          
          strHtml +="<div class=\"panhed_1\">";
          strHtml += "<p>" + dt.Rows[0]["L1"].ToString() + "</p>";
          strHtml +="</div>";
          strHtml +="<div class=\"pan_cont\">";
          strHtml += "<span class=\"sp1\">" + dt.Rows[0]["RECPT_REF"].ToString() + "</span><span class=\"sp2\">" + dt.Rows[0]["RECPT_DATE"].ToString() + "</span>";
          strHtml +="<table class=\"table table-bordered\">";
          strHtml +="<thead class=\"thead1\">";
          strHtml +="<tr>";
          strHtml +="<th class=\"tr_l\">Ledger Name</th>";
          strHtml +="<th class=\"tr_r\">Amount</th>";
          strHtml +="</tr>";
          strHtml +="</thead>";
          strHtml +="<tbody id=\"Tbody1\">";
          for (int i = 0; i < dt.Rows.Count; i++)
          {
              strHtml += "<tr>";
              strHtml += "<td class=\"tr_l\">" + dt.Rows[i]["L2"].ToString() + "</td>";
              strHtml += "<td class=\"tr_r\">" + dt.Rows[i]["RECPT_LD_AMT"].ToString() + " " + dt.Rows[i]["CRNCMST_ABBRV"].ToString() + "</td>";
              strHtml += "</tr>";
          }
         strHtml +="</tbody>";
         strHtml +="</table>";
         strHtml += "</div>";
        }
        return strHtml;
    }
    [WebMethod]
    public static string RecurReject(string strid, string UserId)
    {
        string strRandomMixedId = strid;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        string strHtml = "Suc";
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayerFinanceHome objBusinessLayer = new clsBusinessLayerFinanceHome();
        objEntityCommon.RecurSubId = Convert.ToInt32(strId);
        objEntityCommon.RecurMasterId = Convert.ToInt32(UserId);
        try
        {
            objBusinessLayer.rejectOrders(objEntityCommon);
        }
        catch(Exception ex){
            strHtml = "Fail";
        }
        return strHtml;
    }
    public void LoadPostDatedCheques()
    {
        clsEntityCommon objentcommn = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
        clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntity_Cheque.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objentcommn.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntity_Cheque.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            objentcommn.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }   
        objEntity_Cheque.ChequeIssueDate = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());
        DataTable dtOrders = objBusiness_Cheque.Read_PostdatedCheque_Home_List(objEntity_Cheque);
        int Cnt = 0, Cnt1 = 0;
        string strHtml = "", strHtml1 = "";
        for (int i = 0; i < dtOrders.Rows.Count; i++)
        {

            if (dtOrders.Rows[i]["PST_CHEQUE_TRANSACTION_TYPE"].ToString() == "0")
            {
                   Cnt++;
                   strHtml += "<tr id=\"rowPst" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "\">";
                   strHtml += "<td class=\"th_b2 tr_l\">" + dtOrders.Rows[i]["PST_CHEQUE_REF"].ToString() + "</td>";
                   strHtml += "<td class=\"th_b2 tr_l\">" + dtOrders.Rows[i]["ACCOUNT_LDGR"].ToString() + "</td>";
                   strHtml += "<td class=\"th_b2 tr_l\">" + dtOrders.Rows[i]["PARTY_LDGR"].ToString() + "</td>";
                   strHtml += "<td class=\"th_b6 tr_l\">" + dtOrders.Rows[i]["CHQ_DTLS_NUMBER"].ToString() + "</td>";
                   strHtml += "<td class=\"th_b7\">" + dtOrders.Rows[i]["PST_CHEQUE_DATE"].ToString() + "</td>";
                   strHtml += "<td class=\"th_b6 tr_r\">" + objBusinessLayer.AddCommasForNumberSeperation(dtOrders.Rows[i]["CHQ_DTLS_AMOUNT"].ToString(), objentcommn) + " " + dtOrders.Rows[i]["CRNCMST_ABBRV"].ToString() + "</td>";
                   strHtml += "<td class=\"th_b2 tr_l\">" + dtOrders.Rows[i]["CHQ_DTLS_REMARK"].ToString() + "</td>";

                   if (dtOrders.Rows[i]["PAY_ID"].ToString() == "")
                   {
                       strHtml += "<td class=\"th_b6\"><div class=\"btn_stl1\"><button id=\"btnGen" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "\" onclick=\"return PaidRejctStatusUpdate('" + dtOrders.Rows[i]["PST_CHEQUE_ID"].ToString() + "','" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "',1,0);\" class=\"btn act_btn bn8\" title=\"Generate\"><i class=\"fa fa-puzzle-piece\"></i></button></div></td>";
                       strHtml += "<td class=\"th_b6\">";
                       strHtml += "<div class=\"btn_stl1\">";
                       strHtml += "<button disabled id=\"btnChequePaid" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "\" class=\"btn act_btn bn2 rec_bn\" title=\"Paid\" onclick=\"return PaidRejctStatusUpdate('" + dtOrders.Rows[i]["PST_CHEQUE_ID"].ToString() + "','" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "',1,0);\">";
                       strHtml += "<i class=\"fa fa-check\"></i></button>";
                       strHtml += "<button id=\"btnChequeReject" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "\" class=\"btn act_btn bn3 rec_bn\" title=\"Reject\" onclick=\"return PaidRejctStatusUpdate('" + dtOrders.Rows[i]["PST_CHEQUE_ID"].ToString() + "','" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "',2,0);\"><i class=\"fa fa-times\"></i></button>";
                       strHtml += "</div>";
                       strHtml += "</td>";
                   }
                   else
                   {
                       strHtml += "<td class=\"th_b6\"><div class=\"btn_stl1\"><button disabled id=\"btnGen" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "\" onclick=\"return PaidRejctStatusUpdate('" + dtOrders.Rows[i]["PST_CHEQUE_ID"].ToString() + "','" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "',1,0);\" class=\"btn act_btn bn8\" title=\"Generate\"><i class=\"fa fa-puzzle-piece\"></i></button></div></td>";
                       strHtml += "<td class=\"th_b6\">";
                       strHtml += "<div class=\"btn_stl1\">";
                       strHtml += "<button id=\"btnChequePaid" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "\" class=\"btn act_btn bn2 rec_bn\" title=\"Paid\" onclick=\"return PaidRejctStatusUpdate('" + dtOrders.Rows[i]["PST_CHEQUE_ID"].ToString() + "','" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "',1,0);\">";
                       strHtml += "<i class=\"fa fa-check\"></i></button>";
                       strHtml += "<button disabled id=\"btnChequeReject" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "\" class=\"btn act_btn bn3 rec_bn\" title=\"Reject\" onclick=\"return PaidRejctStatusUpdate('" + dtOrders.Rows[i]["PST_CHEQUE_ID"].ToString() + "','" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "',2,0);\"><i class=\"fa fa-times\"></i></button>";
                       strHtml += "</div>";
                       strHtml += "</td>";

                   }
                   strHtml += "<td style=\"display: none;\"><input type=\"text\" value=\"" + dtOrders.Rows[i]["PAY_ID"].ToString() + "\" style=\"display:none;\"  id=\"tdPaymntRecptId" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "\" name=\"tdPaymntRecptId" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "\"/></td>";
                   strHtml += "</tr>";

            }
            else
            {
                Cnt1++;
                strHtml1 += "<tr id=\"rowPst" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "\">";
                strHtml1 += "<td class=\"th_b2 tr_l\">" + dtOrders.Rows[i]["PST_CHEQUE_REF"].ToString() + "</td>";
                strHtml1 += "<td class=\"th_b2 tr_l\">" + dtOrders.Rows[i]["ACCOUNT_LDGR"].ToString() + "</td>";
                strHtml1 += "<td class=\"th_b2 tr_l\">" + dtOrders.Rows[i]["PARTY_LDGR"].ToString() + "</td>";
                strHtml1 += "<td class=\"th_b6 tr_l\">" + dtOrders.Rows[i]["CHQ_DTLS_NUMBER"].ToString() + "</td>";
                strHtml1 += "<td class=\"th_b7\">" + dtOrders.Rows[i]["PST_CHEQUE_DATE"].ToString() + "</td>";
                strHtml1 += "<td class=\"th_b6 tr_r\">" + objBusinessLayer.AddCommasForNumberSeperation(dtOrders.Rows[i]["CHQ_DTLS_AMOUNT"].ToString(), objentcommn) + " " + dtOrders.Rows[i]["CRNCMST_ABBRV"].ToString() + "</td>";
                strHtml1 += "<td class=\"th_b2 tr_l\">" + dtOrders.Rows[i]["CHQ_DTLS_REMARK"].ToString() + "</td>";
                if (dtOrders.Rows[i]["REC_ID"].ToString() == "")
                {
                    strHtml1 += "<td class=\"th_b6\"><div class=\"btn_stl1\"><button id=\"btnGen" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "\" onclick=\"return PaidRejctStatusUpdate('" + dtOrders.Rows[i]["PST_CHEQUE_ID"].ToString() + "','" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "',1,1);\" class=\"btn act_btn bn8\" title=\"Generate\"><i class=\"fa fa-puzzle-piece\"></i></button></div></td>";
                    strHtml1 += "<td class=\"th_b6\">";
                    strHtml1 += "<div class=\"btn_stl1\">";
                    strHtml1 += "<button disabled id=\"btnChequePaid" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "\" class=\"btn act_btn bn2 rec_bn\" title=\"Paid\" onclick=\"return PaidRejctStatusUpdate('" + dtOrders.Rows[i]["PST_CHEQUE_ID"].ToString() + "','" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "',1,1);\">";
                    strHtml1 += "<i class=\"fa fa-check\"></i></button>";
                    strHtml1 += "<button id=\"btnChequeReject" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "\" class=\"btn act_btn bn3 rec_bn\" title=\"Reject\" onclick=\"return PaidRejctStatusUpdate('" + dtOrders.Rows[i]["PST_CHEQUE_ID"].ToString() + "','" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "',2,1);\"><i class=\"fa fa-times\"></i></button>";
                    strHtml1 += "</div>";
                    strHtml1 += "</td>";
                }
                else
                {
                    strHtml1 += "<td class=\"th_b6\"><div class=\"btn_stl1\"><button disabled id=\"btnGen" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "\" onclick=\"return PaidRejctStatusUpdate('" + dtOrders.Rows[i]["PST_CHEQUE_ID"].ToString() + "','" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "',1,1);\" class=\"btn act_btn bn8\" title=\"Generate\"><i class=\"fa fa-puzzle-piece\"></i></button></div></td>";
                    strHtml1 += "<td class=\"th_b6\">";
                    strHtml1 += "<div class=\"btn_stl1\">";
                    strHtml1 += "<button id=\"btnChequePaid" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "\" class=\"btn act_btn bn2 rec_bn\" title=\"Paid\" onclick=\"return PaidRejctStatusUpdate('" + dtOrders.Rows[i]["PST_CHEQUE_ID"].ToString() + "','" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "',1,1);\">";
                    strHtml1 += "<i class=\"fa fa-check\"></i></button>";
                    strHtml1 += "<button disabled id=\"btnChequeReject" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "\" class=\"btn act_btn bn3 rec_bn\" title=\"Reject\" onclick=\"return PaidRejctStatusUpdate('" + dtOrders.Rows[i]["PST_CHEQUE_ID"].ToString() + "','" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "',2,1);\"><i class=\"fa fa-times\"></i></button>";
                    strHtml1 += "</div>";
                    strHtml1 += "</td>";
                }
                strHtml1 += "<td style=\"display: none;\"><input type=\"text\" style=\"display:none;\" value=\"" + dtOrders.Rows[i]["REC_ID"].ToString() + "\"  id=\"tdPaymntRecptId" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "\" name=\"tdPaymntRecptId" + dtOrders.Rows[i]["PST_CHEQUE_DTLS_ID"].ToString() + "\"/></td>";
                strHtml1 += "</tr>";

            }
        }
        if (Cnt > 0)
        {
            payPostNum.InnerText = Cnt.ToString();
            menu4.Attributes.Add("style", "display:block");
        }
        else
        {
            menu4.Attributes.Add("style", "display:none");
        }

        if (Cnt1 > 0)
        {
            recpPostNum.InnerText = Cnt1.ToString();
            menu3.Attributes.Add("style", "display:block");
        }
        else
        {
            menu3.Attributes.Add("style", "display:none");
        }

        int totCnt = 0;
        if (sMainNotfCnt.InnerText != "")
        {
            totCnt = Convert.ToInt32(sMainNotfCnt.InnerText);
        }
        if ((Cnt1 + Cnt + totCnt) > 0)
        {
            sMainNotfCnt.InnerText = (Cnt1 + Cnt + totCnt).ToString();
            divMainNotf.Attributes.Add("style", "display:block");
        }
        else
        {
            divMainNotf.Attributes.Add("style", "display:none");
        }

        payPostTbody.InnerHtml = strHtml;
        recpPostTbody.InnerHtml = strHtml1;
    }
    [WebMethod]
    public static string[] ChequePaidRejectStatus(string usrId, string ChequeId, string strCorpID, string strOrgIdID, string ChequeBkId, string Status, string TransType, string PaymntRecptId)
    {
        string[] strRetss = new string[3];

        string strRets = "";
        clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
        clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();

        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
        clsBusiness_PaymentAccount objBussinessPayment = new clsBusiness_PaymentAccount();
        List<clsEntityPaymentAccount> objEntityPerfomList = new List<clsEntityPaymentAccount>();
        List<clsEntityPaymentAccount> objEntityPerfomListGrps = new List<clsEntityPaymentAccount>();
        clsEntityPaymentAccount objSubEntity = new clsEntityPaymentAccount();


        clsEntity_Receipt_Account ObjEntityRequest1 = new clsEntity_Receipt_Account();
        clsBusinessLayer_Receipt_Account objBussinessPayment1 = new clsBusinessLayer_Receipt_Account();
        List<clsEntity_Receipt_Account> objEntityPerfomList1 = new List<clsEntity_Receipt_Account>();
        List<clsEntity_Receipt_Account> objEntityPerfomListGrps1 = new List<clsEntity_Receipt_Account>();
        clsEntity_Receipt_Account objSubEntity1 = new clsEntity_Receipt_Account();




        clsCommonLibrary objCommon = new clsCommonLibrary();
        strRets = "successUpdate";
        objEntity_Cheque.PostDatedChequeId = Convert.ToInt32(ChequeId);
        objEntity_Cheque.ChequeBookId = Convert.ToInt32(ChequeBkId);
        objEntity_Cheque.User_Id = Convert.ToInt32(usrId);
        objEntity_Cheque.Organisation_id = Convert.ToInt32(strOrgIdID);
        objEntity_Cheque.Corporate_id = Convert.ToInt32(strCorpID);
        DataTable dtPaidStatus = new DataTable();
        int flag = 0;
        try
        {
            objEntity_Cheque.Status = Convert.ToInt32(Status);
            dtPaidStatus = objBusiness_Cheque.CheckChequeIsPaid_Reject(objEntity_Cheque);
            if (dtPaidStatus.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtPaidStatus.Rows[0][0].ToString()) == 1)
                {
                    strRets = "Paid";
                    flag++;
                }
                else if (Convert.ToInt32(dtPaidStatus.Rows[0][0].ToString()) == 2 && objEntity_Cheque.Status != 0)
                {
                    strRets = "Rejected";
                    flag++;
                }
                else if (Convert.ToInt32(dtPaidStatus.Rows[0][0].ToString()) == 0 && objEntity_Cheque.Status == 0)
                {
                    strRets = "CnclReject";
                    flag++;
                }
            }
            if (flag == 0)
            {
                if (Status == "2")//reject update
                {
                    objEntity_Cheque.Status = Convert.ToInt32(Status);
                    objBusiness_Cheque.UpdateChequePaidRejectStatus(objEntity_Cheque);
                }
                else if (Status == "0")// cancel reject update
                {
                    objEntity_Cheque.Status = Convert.ToInt32(Status);
                    objBusiness_Cheque.UpdateChequePaidRejectStatus(objEntity_Cheque);
                }
                else
                {
                    if (PaymntRecptId != "")//edit paymnt/receipt
                    {
                        string strRandom = objCommon.Random_Number();
                        string strId = PaymntRecptId;
                        int intIdLength = PaymntRecptId.Length;
                        string stridLength = intIdLength.ToString("00");
                        string Id = stridLength + strId + strRandom;

                        strRets = Id;
                    }
                    else//paymnt/recept insert
                    {

                        DataTable dt = objBusiness_Cheque.Read_PostDatedChequeByID(objEntity_Cheque);

                        if (TransType == "0")//paymnt insert
                        {
                            if (dt.Rows.Count > 0)
                            {
                                ObjEntityRequest.Organisation_id = Convert.ToInt32(strOrgIdID);
                                ObjEntityRequest.Corporate_id = Convert.ToInt32(strCorpID);
                                ObjEntityRequest.PayemntMode = 1;
                                if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
                                {
                                    ObjEntityRequest.CurrcyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
                                }
                                if (dt.Rows[0]["PST_CHEQUE_ACC_LDGR_ID"].ToString() != "")
                                {
                                    ObjEntityRequest.AccntNameId = Convert.ToInt32(dt.Rows[0]["PST_CHEQUE_ACC_LDGR_ID"].ToString());
                                }

                                if (dt.Rows[0]["PST_CHEQUE_DATE"].ToString() != "")
                                {
                                    ObjEntityRequest.FromDate = objCommon.textToDateTime(dt.Rows[0]["PST_CHEQUE_DATE"].ToString());
                                }
                                if (dt.Rows[0]["PST_CHEQUE_ISSUE_STATUS"].ToString() == "0")
                                {
                                    ObjEntityRequest.ChequeIssue = 0;
                                }
                                else if (dt.Rows[0]["PST_CHEQUE_ISSUE_STATUS"].ToString() == "1")
                                {
                                    ObjEntityRequest.ChequeIssue = 1;
                                    if (dt.Rows[0]["PST_CHEQUE_ISSUE_DATE"].ToString() != "")
                                        ObjEntityRequest.ChequeIssueDate = objCommon.textToDateTime(dt.Rows[0]["PST_CHEQUE_ISSUE_DATE"].ToString());
                                }
                                if (dt.Rows[0]["PST_CHEQUE_DESCRIPTION"].ToString() != "")
                                {
                                    ObjEntityRequest.Description = dt.Rows[0]["PST_CHEQUE_DESCRIPTION"].ToString();
                                }
                            }

                            DataTable dtLDGRdTLS = objBusiness_Cheque.Read_Cheque_Dtls_By_ChequeId(objEntity_Cheque);
                            for (int intCount = 0; intCount < dtLDGRdTLS.Rows.Count; intCount++)
                            {
                                ObjEntityRequest.ChequeBookId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["CHKBK_ID"].ToString());
                                ObjEntityRequest.ChequeBookNumber = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_NUMBER"].ToString());
                                ObjEntityRequest.TotalAmnt = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_AMOUNT"].ToString());
                                ObjEntityRequest.ToDate = objCommon.textToDateTime(dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_CHQ_DATE"].ToString());
                                ObjEntityRequest.FromDate = ObjEntityRequest.ToDate;
                                ObjEntityRequest.Payee = dt.Rows[0]["PST_CHEQUE_PAYEE"].ToString();
                                if (dt.Rows[0]["PST_CHEQUE_PARTY_LDGR_ID"].ToString() != "")
                                {
                                    objSubEntity.LedgerId = Convert.ToInt32(dt.Rows[0]["PST_CHEQUE_PARTY_LDGR_ID"].ToString());
                                }
                                if (dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_AMOUNT"].ToString() != "")
                                {
                                    objSubEntity.LedgerAmnt = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_AMOUNT"].ToString());
                                }
                                ObjEntityRequest.PostdateChqDtlId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["PST_CHEQUE_DTLS_ID"].ToString());
                                objEntityPerfomList.Add(objSubEntity);
                            }
                            ObjEntityRequest.PostdatedStatus = 1;
                            ObjEntityRequest.PostdateChqId = objEntity_Cheque.PostDatedChequeId;
                            ObjEntityRequest.User_Id = objEntity_Cheque.User_Id;
                            int intflag = 0;
                            objEntity_Cheque.Status = Convert.ToInt32(TransType);
                            DataTable dtCheck = objBusiness_Cheque.Read_Cheque_Dtls_Payment(objEntity_Cheque);
                            if (dtCheck.Rows.Count > 0)
                            {
                                if (Convert.ToInt32(dtCheck.Rows[0][0].ToString()) > 0)
                                {
                                    intflag++;
                                    strRets = "Payment";
                                    strRetss[1] = dtCheck.Rows[0][1].ToString();
                                }
                            }
                            if (intflag == 0)
                            {
                                objBussinessPayment.InsertPaymentMaster(ObjEntityRequest, objEntityPerfomListGrps, objEntityPerfomList);
                                //string strRandom = objCommon.Random_Number();
                                //string strId = ObjEntityRequest.PaymentId.ToString();
                                //int intIdLength = ObjEntityRequest.PaymentId.ToString().Length;
                                //string stridLength = intIdLength.ToString("00");
                                //string Id = stridLength + strId + strRandom;
                                strRets = ObjEntityRequest.PaymentId.ToString();
                                strRetss[2] = ObjEntityRequest.RefNum;
                            }
                        }//receipt insert
                        else
                        {

                            if (dt.Rows.Count > 0)
                            {
                                ObjEntityRequest1.Organisation_id = Convert.ToInt32(strOrgIdID);
                                ObjEntityRequest1.Corporate_id = Convert.ToInt32(strCorpID);
                                ObjEntityRequest1.PaymentMod = 0;
                                if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
                                {
                                    ObjEntityRequest1.CurrcyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
                                }
                                if (dt.Rows[0]["PST_CHEQUE_ACC_LDGR_ID"].ToString() != "")
                                {
                                    ObjEntityRequest1.LedgerId = Convert.ToInt32(dt.Rows[0]["PST_CHEQUE_ACC_LDGR_ID"].ToString());
                                }

                                if (dt.Rows[0]["PST_CHEQUE_DATE"].ToString() != "")
                                {
                                    ObjEntityRequest1.FromDate = objCommon.textToDateTime(dt.Rows[0]["PST_CHEQUE_DATE"].ToString());
                                }
                                if (dt.Rows[0]["PST_CHEQUE_DESCRIPTION"].ToString() != "")
                                {
                                    ObjEntityRequest1.Description = dt.Rows[0]["PST_CHEQUE_DESCRIPTION"].ToString();
                                }
                            }

                            DataTable dtLDGRdTLS = objBusiness_Cheque.Read_Cheque_Dtls_By_ChequeId(objEntity_Cheque);
                            for (int intCount = 0; intCount < dtLDGRdTLS.Rows.Count; intCount++)
                            {
                                ObjEntityRequest1.Bank_Name = dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_BANK"].ToString();
                                ObjEntityRequest1.IbanNo = dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_IBAN"].ToString();
                                ObjEntityRequest1.ChequeBook_No = dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_NUMBER"].ToString();

                                ObjEntityRequest1.TotalAmnt = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_AMOUNT"].ToString());
                                ObjEntityRequest1.PaymentDate = objCommon.textToDateTime(dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_CHQ_DATE"].ToString());
                                ObjEntityRequest1.FromDate = ObjEntityRequest1.PaymentDate;
                                
                                if (dt.Rows[0]["PST_CHEQUE_PARTY_LDGR_ID"].ToString() != "")
                                {
                                    objSubEntity1.LedgerId = Convert.ToInt32(dt.Rows[0]["PST_CHEQUE_PARTY_LDGR_ID"].ToString());
                                }
                                if (dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_AMOUNT"].ToString() != "")
                                {
                                    objSubEntity1.LedgerAmnt = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_AMOUNT"].ToString());
                                }
                                ObjEntityRequest1.RecurMasterId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["PST_CHEQUE_DTLS_ID"].ToString());
                                objEntityPerfomList1.Add(objSubEntity1);
                            }
                            ObjEntityRequest1.User_Id = objEntity_Cheque.User_Id;
                            int intflag = 0;
                            objEntity_Cheque.Status = Convert.ToInt32(TransType);
                            DataTable dtCheck = objBusiness_Cheque.Read_Cheque_Dtls_Payment(objEntity_Cheque);
                            if (dtCheck.Rows.Count > 0)
                            {
                                if (Convert.ToInt32(dtCheck.Rows[0][0].ToString()) > 0)
                                {
                                    intflag++;
                                    strRets = "Payment";
                                    strRetss[1] = dtCheck.Rows[0][1].ToString();
                                }
                            }
                            if (intflag == 0)
                            {
                                objBussinessPayment1.InsertReceiptDtls(ObjEntityRequest1, objEntityPerfomList1, objEntityPerfomListGrps1);
                                //string strRandom = objCommon.Random_Number();
                                //string strId = ObjEntityRequest1.ReceiptId.ToString();
                                //int intIdLength = ObjEntityRequest1.ReceiptId.ToString().Length;
                                //string stridLength = intIdLength.ToString("00");
                                //string Id = stridLength + strId + strRandom;
                                strRets = ObjEntityRequest1.ReceiptId.ToString();
                                strRetss[2] = ObjEntityRequest1.RefNum;
                            }
                        }
                }
                }
            }
        }
        catch
        {
            strRets = "failed";
        }
        strRetss[0] = strRets;
        return strRetss;
    }

    [WebMethod]
    public static string CheckPaymentInserted(string TransType, string strCorpID, string strOrgIdID)
    {        
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        objEntityCommon.CorporateID = Convert.ToInt32(strCorpID);
        objEntityCommon.Organisation_Id = Convert.ToInt32(strOrgIdID);
        if (TransType == "0")
        {
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.FMS_PAYMENT);
        }
        else
        {
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.RECEIPT);
        }
        string strNextId = objBusinessLayer.ReadNextSequence(objEntityCommon);
        return strNextId;
    }


    //EVM 040
    [WebMethod]
    public static string[] LoadSalesTotal(string intorgid, string intCorporateOfficeID, string intFinancialYrId, string intCurrencyId)
    {

        //string result = "";
        string[] result = new string[2];
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayerFinanceHome objBusinessLayer = new clsBusinessLayerFinanceHome();
        clsBusinessLayer objBusiness = new clsBusinessLayer();

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_TAX_ENABLED,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_INVENTORY_FOREX_STATUS
                                                              };
        objEntityCommon.FinancialYrId = Convert.ToInt32(intFinancialYrId);
        objEntityCommon.Organisation_Id = Convert.ToInt32(intorgid);
        objEntityCommon.CorporateID = Convert.ToInt32(intCorporateOfficeID);
        objEntityCommon.CurrencyId = Convert.ToInt32(intCurrencyId);


        DataTable dtCategory = objBusinessLayer.SalesTotal(objEntityCommon);

        DataTable dt = objBusiness.ReadCurrencyDetails(objEntityCommon); //cr      
        if (dt.Rows.Count > 0)
        {
            result[0] = dt.Rows[0]["CRNCMST_ABBRV"].ToString();
        }

        if (dtCategory.Rows.Count > 0)
        {
            result[1] = dtCategory.Rows[0]["NVL(SUM(SALES_NET_TOTAL),0)"].ToString();



        }
        return result;


    }
    [WebMethod]
    public static string[] LoadPurchaseTotal(string intorgid, string intCorporateOfficeID, string intFinancialYrId, string intCurrencyId)
    {
        //string result = "";
        string[] result = new string[2];
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayerFinanceHome objBusinessLayer = new clsBusinessLayerFinanceHome();
        clsBusinessLayer objBusiness = new clsBusinessLayer();

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_TAX_ENABLED,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_INVENTORY_FOREX_STATUS
                                                              };
        objEntityCommon.FinancialYrId = Convert.ToInt32(intFinancialYrId);
        objEntityCommon.Organisation_Id = Convert.ToInt32(intorgid);
        objEntityCommon.CorporateID = Convert.ToInt32(intCorporateOfficeID);
        objEntityCommon.CurrencyId = Convert.ToInt32(intCurrencyId);


        DataTable dtCategory = objBusinessLayer.PurchaseTotal(objEntityCommon);

        DataTable dt = objBusiness.ReadCurrencyDetails(objEntityCommon); //cr      
        if (dt.Rows.Count > 0)
        {
            result[0] = dt.Rows[0]["CRNCMST_ABBRV"].ToString();
        }

        if (dtCategory.Rows.Count > 0)
        {
            result[1] = dtCategory.Rows[0]["NVL(SUM(PURCHS_NET_TOTAL),0)"].ToString();



        }
        //result[1] = "";

        return result;

    }
    //end

    //EMP-0043 start
    [WebMethod]
    public static string[] LoadProfitLoss(string intshowZerosts, string intorgid, string intCorporateOfficeID, string intFinancialYrId, string intCurrencyId)
    {
        string[] result = new string[4];
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        // int intCorpId = 0, intOrgId = 0, intUserId = 0;
        clsBusinessLayerFinanceHome objBusinessLayer = new clsBusinessLayerFinanceHome();
        clsBusinessLayer objBusiness = new clsBusinessLayer();



        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerFinanceHome objBussines = new clsBusinessLayerFinanceHome();

        objEntityCommon.FinancialYrId = Convert.ToInt32(intFinancialYrId);
        objEntityCommon.ShowZerosts = Convert.ToInt32(intshowZerosts);
        objEntityCommon.Organisation_Id = Convert.ToInt32(intorgid);
        objEntityCommon.CorporateID = Convert.ToInt32(intCorporateOfficeID);
        objEntityCommon.CurrencyId = Convert.ToInt32(intCurrencyId);

        DataTable dtCategory = objBussines.ProfitAndLossAcnt_List(objEntityCommon);
        int Printsts = 0;
        string TypSts = "0";
        int StsGrp = 0;
        DataTable dtCategory1 = dtCategory;
        clsEntityProfitAndLossAccount ObjEntityRequest = new clsEntityProfitAndLossAccount();





        int intCorpId = 0, intOrgId = 0, intUserId = 0;

        if (HttpContext.Current.Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(HttpContext.Current.Session["CORPOFFICEID"].ToString());

            ObjEntityRequest.Corporate_id = intCorpId;


        }
        clsBusinessProfitAndLossAccount objBussiness = new clsBusinessProfitAndLossAccount();



        clsCommonLibrary ObjCommonlib = new clsCommonLibrary();

        int Decimalcount = 0;

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }



        int intCount = 0;

        decimal sum_Cedt = 0, sum_debt = 0;

        for (int grscnt = 0; grscnt < dtCategory.Rows.Count; grscnt++)
        {
            if (dtCategory.Rows[grscnt]["ACNT_NATURE_STS"].ToString() == "2")
            {
                sum_debt += Convert.ToDecimal(dtCategory.Rows[grscnt]["TOTAL_DEB_AMNT"]);
            }
            else
            {
                sum_Cedt += Convert.ToDecimal(dtCategory.Rows[grscnt]["TOTAL_CREDIT_AMNT"]);
            }
        }
        int stsflg = 0;
        string strRandom = objCommon.Random_Number();
        string STRBALANDR = "", STRBALANCR = "";

        if (TypSts == "0")
        {

            int COUNT = 0;
            int flg = 0;
            int actCnt = 0;
            string NewRev = "";
            if (dtCategory.Rows.Count > 0)
            {
                for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
                {
                    actCnt = intRowBodyCount;
                    // intRowBodyCount = flg;
                    string strId = dtCategory.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();
                    int intIdLength = dtCategory.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString().Length;
                    string stridLength = intIdLength.ToString("00");
                    string Id = stridLength + strId + strRandom;
                    COUNT++;

                    string strNetAmount = "";
                    string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                    string strsurAbrv = "";
                    int crCnt = 0;

                    int revflg = 0;
                    int rrvflg = 0;
                    string[] newRev1 = NewRev.Split(',');
                    for (int i = 0; i < newRev1.Length; i++)
                    {
                        if (newRev1[i] != dtCategory.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString())
                        {
                            revflg = 0;
                        }
                        else
                        {
                            revflg = 1;
                            rrvflg = 1;
                        }
                    }
                    if (rrvflg == 0)
                    {
                        if (revflg == 0)
                        {



                            // strsurAbrv = dtRowsIn["CRNCMST_ABBRV"].ToString();
                            if (dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString() != "")
                            {
                                strNetAmount = dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString();
                                decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                if (NetAmount < 0)
                                {
                                    strsurAbrv = "CR";
                                    //  NetAmount = -(NetAmount);
                                }
                                else
                                    strsurAbrv = "DR";
                                strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                            }





                            int sts = Convert.ToInt32(dtCategory.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString());

                            if (sts == 2)
                            {
                                if (dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString() != "")
                                {
                                    strNetAmount = dtCategory.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString();
                                    decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                    if (NetAmount < 0)
                                    {
                                        strsurAbrv = "CR";
                                        // NetAmount = -(NetAmount);
                                    }
                                    else
                                        strsurAbrv = "DR";
                                    strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                }
                            }
                            else
                            {
                                if (dtCategory.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString() != "")
                                {
                                    strNetAmount = dtCategory.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString();
                                    decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                    if (NetAmount < 0)
                                    {
                                        strsurAbrv = "CR";
                                        // NetAmount = -(NetAmount);
                                    }
                                    else
                                        strsurAbrv = "DR";
                                    strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                }
                            }







                            string CustomerName = dtCategory.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString();
                            if (CustomerName.Contains("\"") == true)
                            {
                                CustomerName = CustomerName.Replace("\"", "‡");
                            }
                            if (CustomerName.Contains("\'") == true)
                            {
                                CustomerName = CustomerName.Replace("\'", "¦");
                            }


                            if (dtCategory.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString() == "2")
                            {

                                NewRev = NewRev + "," + dtCategory.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();

                                flg++;

                            }

                            else
                            {


                                if (dtCategory.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString() != "")
                                {
                                    strNetAmount = dtCategory.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString();
                                    decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                    if (NetAmount < 0)
                                    {
                                        strsurAbrv = "CR";
                                        // NetAmount = -(NetAmount);
                                    }
                                    else
                                        strsurAbrv = "DR";
                                    strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                }



                                NewRev = NewRev + "," + dtCategory.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();
                                flg++;
                                crCnt = 1;

                            }

                            //else
                            //{

                            if (intRowBodyCount == flg)
                            {
                                intRowBodyCount = actCnt;
                            }

                            for (int i = intRowBodyCount + 1; i < dtCategory.Rows.Count; i++)
                            {
                                int TempCount = i;


                                rrvflg = 0;
                                for (int j = 0; j < newRev1.Length; j++)
                                {
                                    if (newRev1[j] != dtCategory.Rows[TempCount]["ACNT_GRP_ID"].ToString())
                                    {
                                        revflg = 0;
                                    }
                                    else
                                    {
                                        revflg = 1;
                                        rrvflg = 1;
                                    }
                                }


                                if (rrvflg == 0)
                                {

                                    if (TempCount < dtCategory.Rows.Count && crCnt == 0 && revflg == 0)
                                    {
                                        if (dtCategory.Rows[TempCount]["ACNT_NATURE_STS"].ToString() == "3")
                                        {
                                            if (dtCategory.Rows[TempCount]["TOTAL_CREDIT_AMNT"].ToString() != "")
                                            {
                                                strNetAmount = dtCategory.Rows[TempCount]["TOTAL_CREDIT_AMNT"].ToString();
                                                decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                                if (NetAmount < 0)
                                                {
                                                    strsurAbrv = "CR";
                                                    // NetAmount = -(NetAmount);
                                                }
                                                else
                                                    strsurAbrv = "DR";
                                                strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                            }


                                            string strrId = dtCategory.Rows[TempCount]["ACNT_GRP_ID"].ToString();
                                            int inttIdLength = dtCategory.Rows[TempCount]["ACNT_GRP_ID"].ToString().Length;
                                            string strridLength = inttIdLength.ToString("00");
                                            string tmpId = strridLength + strrId + strRandom;

                                            string CustomerNameTemp = dtCategory.Rows[TempCount]["ACNT_GRP_NAME"].ToString();
                                            if (CustomerNameTemp.Contains("\"") == true)
                                            {
                                                CustomerNameTemp = CustomerNameTemp.Replace("\"", "‡");
                                            }
                                            if (CustomerNameTemp.Contains("\'") == true)
                                            {
                                                CustomerNameTemp = CustomerNameTemp.Replace("\'", "¦");
                                            }



                                            NewRev = NewRev + "," + dtCategory.Rows[TempCount]["ACNT_GRP_ID"].ToString();

                                            // dtCategory.Rows[TempCount].Delete();
                                            flg++;
                                            crCnt = 1;
                                        }
                                    }
                                }
                            }
                        }

                    }

                }

            }

            if (StsGrp == 0)
            {


                string strNetAmount = "";
                string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                string strNetAmount1 = "";
                string strNetAmountDebitComma1 = "", strNetAmountCrComma1 = "";
                string strProfit = "";
                string strLoss = "";
                decimal NetAmount = 0;
                decimal netamtDec = 0;

                int dcmlCnt = 0;

                string[] AmtAftrDe;

                if (sum_Cedt > sum_debt)
                {
                    NetAmount = sum_Cedt - sum_debt;
                    strNetAmount1 = NetAmount.ToString();
                    strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);
                    strNetAmount = sum_Cedt.ToString();
                    strNetAmount = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                    string[] newRev1 = strNetAmount.Split('.');
                    if (newRev1[1] == "")
                    {
                        for (int i = 0; i < dcmlCnt; i++)
                        {
                            strNetAmount += "0";
                        }
                    }

                    stsflg = 0;
                    strProfit = "Gross Profit";
                }
                else
                {
                    NetAmount = sum_debt - sum_Cedt;
                    strNetAmount1 = NetAmount.ToString();
                    strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);

                    string[] newRev2 = strNetAmountCrComma.Split('.');
                    if (newRev2[1] == "")
                    {
                        for (int i = 0; i < dcmlCnt; i++)
                        {
                            strNetAmountCrComma += "0";
                        }
                    }

                    strNetAmount = sum_debt.ToString();
                    netamtDec = Convert.ToDecimal(strNetAmount);

                    strNetAmount = objBusiness.AddCommasForNumberSeperation(netamtDec.ToString(), objEntityCommon);
                    string[] newRev1 = strNetAmount.Split('.');
                    if (newRev1[1] == "")
                    {
                        for (int i = 0; i < dcmlCnt; i++)
                        {
                            strNetAmount += "0";
                        }
                    }

                    stsflg = 1;
                    strLoss = "Gross Loss";
                }

            }

        }
        if (HttpContext.Current.Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(HttpContext.Current.Session["USERID"]);
            ObjEntityRequest.User_Id = intUserId;

        }

        if (HttpContext.Current.Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(HttpContext.Current.Session["CORPOFFICEID"].ToString());
            ObjEntityRequest.Corporate_id = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }

        if (HttpContext.Current.Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(HttpContext.Current.Session["ORGID"].ToString());
            ObjEntityRequest.Organisation_id = intOrgId;

        }


        ObjEntityRequest.ToDate = ObjCommonlib.textToDateTime(DateTime.Now.ToString("dd-MM-yyyy"));



        //add rows
        int RcCOUNT = 0;
        if (TypSts == "1")
        {
            StsGrp = 0;
        }
        if (StsGrp == 0 || TypSts == "1")
        {

            DataTable dtlist = new DataTable();
            if (TypSts == "0")
            {
                dtlist = objBussiness.Net_ProfitAndLossAcnt_List(ObjEntityRequest);
            }

            int Net_flg = 0;
            int Net_actCnt = 0;
            if (dtlist.Rows.Count > 0)
            {
                string NewRRev = "";

                for (int intRowBodyCount = 0; intRowBodyCount < (dtlist.Rows.Count); intRowBodyCount++)
                {
                    Net_actCnt = intRowBodyCount;
                    // intRowBodyCount = Net_flg;
                    int crCnt = 0;
                    string strId = dtlist.Rows[intRowBodyCount][0].ToString();
                    int intIdLength = dtlist.Rows[intRowBodyCount][0].ToString().Length;
                    string stridLength = intIdLength.ToString("00");
                    string Id = stridLength + strId + strRandom;
                    RcCOUNT++;
                    //    strHtml += "<td class=\"tdT\" style=\" width:10%;text-align: left;\" >" + COUNT + "</td>";
                    int revflg = 0;
                    int revflgg = 0;
                    string[] newRev1 = NewRRev.Split(',');
                    for (int i = 0; i < newRev1.Length; i++)
                    {
                        if (newRev1[i] != dtlist.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString())
                        {
                            revflg = 0;
                        }
                        else
                        {
                            revflg = 1;
                            revflgg = 1;
                            //    break;
                        }
                    }


                    if (revflgg == 0)
                    {
                        if (revflg == 0)
                        {
                            string strNetAmount = "";
                            string strNetAmountDebitComma = "", strNetAmountCrComma = "";
                            string strsurAbrv = "";
                            // strsurAbrv = dtRowsIn["CRNCMST_ABBRV"].ToString();
                            if (dtlist.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString() != "")
                            {
                                strNetAmount = dtlist.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString();
                                decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                if (NetAmount < 0)
                                {
                                    strsurAbrv = "CR";
                                    //  NetAmount = -(NetAmount);
                                }
                                else
                                    strsurAbrv = "DR";
                                strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                            }


                            int sts = Convert.ToInt32(dtlist.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString());

                            if (sts == 2)
                            {
                                if (dtlist.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString() != "")
                                {
                                    strNetAmount = dtlist.Rows[intRowBodyCount]["TOTAL_DEB_AMNT"].ToString();
                                    decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                    if (NetAmount < 0)
                                    {
                                        strsurAbrv = "CR";
                                        //  NetAmount = -(NetAmount);
                                    }
                                    else
                                        strsurAbrv = "DR";
                                    strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                }
                            }
                            else
                            {
                                strNetAmount = dtlist.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString();
                                decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                if (NetAmount < 0)
                                {
                                    strsurAbrv = "CR";
                                    // NetAmount = -(NetAmount);
                                }
                                else
                                    strsurAbrv = "DR";
                                strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                            }

                            int dcmlCnt = 0;



                            if (strNetAmountCrComma == "0")
                            {
                                string[] newRev3 = strNetAmount.Split('.');
                                if (newRev3[1] == "")
                                {
                                    for (int i = 0; i < dcmlCnt; i++)
                                    {
                                        strNetAmountCrComma += "0";
                                    }
                                }

                            }

                            if (dtlist.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString() == "2")
                            {



                                NewRRev = NewRRev + "," + dtlist.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();
                                Net_flg++;

                            }

                            else
                            {

                                if (dtlist.Rows[intRowBodyCount]["ACNT_NATURE_STS"].ToString() == "3")
                                {
                                    if (dtlist.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString() != "")
                                    {
                                        strNetAmount = dtlist.Rows[intRowBodyCount]["TOTAL_CREDIT_AMNT"].ToString();
                                        decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                        if (NetAmount < 0)
                                        {
                                            strsurAbrv = "CR";
                                            // NetAmount = -(NetAmount);
                                        }
                                        else
                                            strsurAbrv = "DR";
                                        strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                    }



                                    // dtCategory.Rows[TempCount].Delete();
                                    NewRRev = NewRRev + "," + dtlist.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString();

                                    Net_flg++;
                                    crCnt = 1;
                                }
                            }

                            if (intRowBodyCount == Net_flg)
                            {
                                intRowBodyCount = Net_actCnt;
                            }

                            for (int i = intRowBodyCount + 1; i < dtlist.Rows.Count; i++)
                            {
                                int TempCount = i;

                                int rrvfflg = 0;

                                for (int j = 0; j < newRev1.Length; j++)
                                {
                                    if (newRev1[j] != dtlist.Rows[TempCount]["ACNT_GRP_ID"].ToString())
                                    {
                                        revflg = 0;
                                    }
                                    else
                                    {
                                        revflg = 1;
                                        rrvfflg = 1;
                                    }
                                }

                                if (rrvfflg == 0)
                                {
                                    if (TempCount < dtlist.Rows.Count && crCnt == 0 && revflg == 0)
                                    {
                                        if (dtlist.Rows[TempCount]["ACNT_NATURE_STS"].ToString() == "3")
                                        {
                                            if (dtlist.Rows[TempCount]["TOTAL_CREDIT_AMNT"].ToString() != "")
                                            {
                                                strNetAmount = dtlist.Rows[TempCount]["TOTAL_CREDIT_AMNT"].ToString();
                                                decimal NetAmount = Convert.ToDecimal(strNetAmount);
                                                if (NetAmount < 0)
                                                {
                                                    strsurAbrv = "CR";
                                                    // NetAmount = -(NetAmount);
                                                }
                                                else
                                                    strsurAbrv = "DR";
                                                strNetAmountCrComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                                            }
                                            string strrId = dtlist.Rows[TempCount][0].ToString();
                                            int inttIdLength = dtlist.Rows[TempCount][0].ToString().Length;
                                            string strridLength = inttIdLength.ToString("00");
                                            string TempId = strridLength + strrId + strRandom;

                                            // dtCategory.Rows[TempCount].Delete();
                                            NewRRev = NewRRev + "," + dtlist.Rows[TempCount]["ACNT_GRP_ID"].ToString();
                                            Net_flg++;
                                            crCnt = 1;
                                        }
                                    }
                                }
                            }
                        }


                    }

                }

                decimal sum_Cedt1 = 0, sum_debt1 = 0;
                for (int grscnt = 0; grscnt < dtlist.Rows.Count; grscnt++)
                {
                    if (dtlist.Rows[grscnt]["ACNT_NATURE_STS"].ToString() == "2")
                    {
                        sum_debt1 += Convert.ToDecimal(dtlist.Rows[grscnt]["TOTAL_DEB_AMNT"]);
                    }
                    else
                    {
                        sum_Cedt1 += Convert.ToDecimal(dtlist.Rows[grscnt]["TOTAL_CREDIT_AMNT"]);
                    }
                }

                string strNetAmountnetttl = "";
                string strNetAmountCrNetComma = "";
                string strNetAmount1 = "";
                string strNetAmountDebitComma1 = "", strNetAmountCrComma1 = "0";
                string strProfit1 = "";
                string strLoss1 = "";
                decimal net_amt = 0;
                int eXfLG = 0;
                string strNetAmt = "";
                string TotalComma = "", TotalComma1 = "";
                string profit = "0";
                string netProdiff = "0";
                decimal TTLaMTdR = 0;
                decimal TTLaMTcR = 0;
                string netProdiffcR = "0";
                net_amt = (sum_Cedt + sum_Cedt1) - (sum_debt1 + sum_debt);
                decimal ttlAmt = 0, ttlAmt1 = 0;

                //strNetAmt = net_amt.ToString();


                if (net_amt > 0 && stsflg == 1)
                {

                    decimal NetAmount = sum_Cedt - sum_debt;

                    profit = "Profit Difference";
                    strNetAmount1 = NetAmount.ToString();
                    netProdiff = objBusiness.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);
                    if (NetAmount < 0)
                    {
                        string srDBalance = netProdiff;
                        srDBalance = srDBalance.Substring(1);
                        netProdiff = srDBalance;
                    }

                }
                else if (net_amt < 0 && stsflg == 0)
                {
                    decimal NetAmount = sum_Cedt - sum_debt;

                    profit = "Profit Difference";
                    strNetAmount1 = NetAmount.ToString();
                    netProdiffcR = objBusiness.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);
                    if (NetAmount < 0)
                    {
                        string srDBalance = netProdiffcR;
                        srDBalance = srDBalance.Substring(1);
                        netProdiffcR = srDBalance;
                    }

                }
                else if (net_amt < 0 && stsflg == 1)
                {
                    strProfit1 = "Profit Difference";
                    decimal NetAmount = sum_Cedt - sum_debt;


                    strNetAmount1 = NetAmount.ToString();
                    strNetAmountCrNetComma = objBusiness.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);
                    if (NetAmount < 0)
                    {
                        string srDBalance = strNetAmountCrNetComma;
                        srDBalance = srDBalance.Substring(1);
                        strNetAmountCrNetComma = srDBalance;
                    }
                }
                else if (net_amt < 0 && stsflg == 0)
                {
                    strLoss1 = "Profit Difference";
                    decimal NetAmount = sum_Cedt - sum_debt;


                    strNetAmount1 = NetAmount.ToString();
                    strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);
                    if (NetAmount < 0)
                    {
                        string srDBalance = strNetAmountCrComma1;
                        srDBalance = srDBalance.Substring(1);
                        strNetAmountCrComma1 = srDBalance;
                    }
                }

                else if (net_amt > 0 && stsflg == 0)
                {
                    strLoss1 = "Profit Difference";
                    decimal NetAmount = sum_Cedt - sum_debt;


                    strNetAmount1 = NetAmount.ToString();
                    strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(strNetAmount1.ToString(), objEntityCommon);
                    if (NetAmount < 0)
                    {
                        string srDBalance = strNetAmountCrComma1;
                        srDBalance = srDBalance.Substring(1);
                        strNetAmountCrComma1 = srDBalance;
                    }
                }
                if (net_amt > 0)
                {
                    strProfit1 = "Net Profit";
                    strNetAmt = net_amt.ToString();
                    strNetAmountCrNetComma = objBusiness.AddCommasForNumberSeperation(strNetAmt.ToString(), objEntityCommon);
                    result[1] = strNetAmountCrNetComma;
                    result[2] = "Profit";
                }
                else
                {
                    strLoss1 = "Net Loss";
                    strNetAmt = net_amt.ToString();
                    strNetAmountCrComma1 = objBusiness.AddCommasForNumberSeperation(strNetAmt.ToString(), objEntityCommon);
                    strNetAmountCrComma1 = strNetAmountCrComma1.Substring(1);
                    result[1] = strNetAmountCrComma1;
                    result[2] = "Loss";
                }
                int ddcmlCnt = 0;


                if (strNetAmountCrNetComma != "")
                {
                    TTLaMTdR = sum_debt1 + Convert.ToDecimal(strNetAmountCrNetComma) + Convert.ToDecimal(netProdiff);

                }
                TTLaMTcR = sum_Cedt1 + Convert.ToDecimal(strNetAmountCrComma1) + Convert.ToDecimal(netProdiffcR);

                if (strNetAmountCrComma1 == "0")
                {
                    strNetAmountCrComma1 = "";
                }
                string strTTLaMTdR = objBusiness.AddCommasForNumberSeperation(TTLaMTdR.ToString(), objEntityCommon);

                string strTTLaMTcR = objBusiness.AddCommasForNumberSeperation(TTLaMTcR.ToString(), objEntityCommon);

                if (TTLaMTdR == 0)
                {
                    string[] newRev5 = strTTLaMTdR.Split('.');
                    if (newRev5[1] == "")
                    {
                        for (int i = 0; i < ddcmlCnt; i++)
                        {
                            strTTLaMTdR += "0";
                        }
                    }
                }
            }
        }

        int dispStatus = 0;
        DataTable dt = objBusiness.ReadCurrencyDetails(objEntityCommon);
        clsBusiness_Account_Setting objBussinessAccount = new clsBusiness_Account_Setting();
        clsEntity_Account_Setting objEntityAccount = new clsEntity_Account_Setting();

        objEntityAccount.CorpId = Convert.ToInt32(intCorporateOfficeID);
        objEntityAccount.OrgId = Convert.ToInt32(intorgid);

        DataTable dtSubConrt = objBussinessAccount.ReadFinancialYear(objEntityAccount);
        string finyeardate = " ";
        for (int intCount1 = 0; intCount1 < dtSubConrt.Rows.Count; intCount1++)
        {
            if (Convert.ToString(HttpContext.Current.Session["FINCYRID"]) == dtSubConrt.Rows[intCount1]["FINCYR_ID"].ToString())
            {

                finyeardate = HttpContext.Current.Session["FINCYEAR_NAME"].ToString();
            }
        }

        string[] seperator = { "-" };
        string[] year = finyeardate.Split('-');
        string endyear = "";
        string styear = (Convert.ToInt32(year[0]) - 1).ToString();
        objEntityCommon.strYears = styear;
        if (year.Length > 1)
        {
            endyear = (Convert.ToInt32(year[1]) - 1).ToString();
            objEntityCommon.strYears = styear + "-" + endyear;
        }
        objEntityCommon.strYears = styear + "-" + endyear;
        DataTable dt2 = objBusinessLayer.ReadFinsYear(objEntityCommon);

        if (dt.Rows.Count > 0)
        {
            result[0] = dt.Rows[0]["CRNCMST_ABBRV"].ToString();
        }
        if (dt2.Rows.Count > 0)
        {
            if (dt.Rows[0]["VOCHR_CATGRY"].ToString() != "" && dt.Rows[0]["VOCHR_CATGRY"].ToString() != null)
            {
                dispStatus = 1;
            }

        }
        result[3] = dispStatus.ToString();

        return result;
    }
    



}