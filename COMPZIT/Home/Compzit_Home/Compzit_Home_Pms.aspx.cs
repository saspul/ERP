using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using System.Data;
using CL_Compzit;

public partial class Home_Compzit_Home_Compzit_Home_Pms : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["APP_ID"] = "7";

        if (!IsPostBack)
        {
            int intUserId = 0, intOrgId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
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
        }
    }

}