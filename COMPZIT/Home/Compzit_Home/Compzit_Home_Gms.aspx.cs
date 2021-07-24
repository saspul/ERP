using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using System.Text;
using CL_Compzit;
using System.Collections;
using EL_Compzit.EntityLayer_GMS;
using BL_Compzit.BusinessLayer_GMS;

public partial class Home_Compzit_Home_Compzit_Home_Gms : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["APP_ID"] = "4";

        if (!IsPostBack)
        {
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

            readDBord_IMS_Count();
            //EVM-0027
            readDBord_BankGurant_Count();
            //END
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
                    clsBusinessLayer objBusiness = new clsBusinessLayer();
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
            int intUserId = 0, intUsrRolMstrId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Bank_Guarantee);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            int intEnableSuplier = 0, intEnableClient = 0;
            if (dtChildRol.Rows.Count > 0)
            {

                divGuarantee0.Visible = false;
                divGuarantee.Visible = false;
                divGuarExpSup.Visible = false;
                divGuarantee01.Visible = false;
                divGuarantee1.Visible = false;
                divGuar3monthCus.Visible = false;

                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Suplier_Guarantee_Permission).ToString())
                    {
                        divGuarantee0.Visible = true;
                        divGuarantee.Visible = true;
                        divGuarExpSup.Visible = true;
                        intEnableSuplier = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Client_Guarantee_Permission).ToString())
                    {
                        divGuarantee01.Visible = true;
                        divGuarantee1.Visible = true;
                        divGuar3monthCus.Visible = true;
                        intEnableClient = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                }

                //Load DashBoard Counts
            //    LoadDBordCountBankGtee();
                LoadDBordCountReqFor();
            }
            else
            {
                divRFQ.Attributes.Add("style", "width: 99%;");
                divGuarantee1.Visible = false;
                divGuarantee.Visible = false;
                //divRFQ.Visible = true;
                divGuarantee0.Visible = false;
                divGuarExpSup.Visible = false;
                divGuarantee01.Visible = false;
                divGuar3monthCus.Visible = false;
            }
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Request_For_Guarantee);
            DataTable dtChildRol1 = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            if (dtChildRol1.Rows.Count > 0)
            {
                divRFQ.Visible = true;
            }
            else
            {
                divRFQ.Visible = false;
            }
        }

    }
    public void LoadDBordCountBankGtee()
    {
        int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableClose = 0, intEnableRenew = 0, intEnableSuplier = 0, intEnableClient = 0, intEnableConfirm = 0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Bank_Guarantee);
        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

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

                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Renew).ToString())
                {
                    intEnableRenew = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Suplier_Guarantee_Permission).ToString())
                {
                    intEnableSuplier = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Client_Guarantee_Permission).ToString())
                {
                    intEnableClient = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                }

                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString())
                {
                    //future

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString())
                {
                    //future

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                {
                    intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                }

            }
        }
        clsBusinessLayerBankGuarantee ObjBussinessBankGuarnt = new clsBusinessLayerBankGuarantee();
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();
        if (intEnableSuplier == 1 && intEnableClient == 1)
        {

            // btnConfirm.Visible = true;
            ObjEntityRequest.SuplOrClient = 0;
        }
        else
        {
            if (intEnableSuplier == 1)
            {

                ObjEntityRequest.SuplOrClient = 1;
            }

            else if (intEnableClient == 1)
            {

                ObjEntityRequest.SuplOrClient = 2;
            }
            else
            {
                ObjEntityRequest.SuplOrClient = 3;
            }
        }
        DateTime date = DateTime.Today; ;
        int intExpiring = 0, intGteeOpenSts = 0, intExpiredGtee = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            //intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityRequest.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ObjEntityRequest.OpenDate = DateTime.MinValue;
        ObjEntityRequest.ToDate = DateTime.MinValue;
        ObjEntityRequest.ExpireDate = DateTime.MinValue;
        //Expiring in 3 MONTHS
        string datetoexpiry = DateTime.Today.AddDays(90).ToString("dd-MM-yyyy");
        string datetoday = DateTime.Today.Date.ToString("dd-MM-yyyy");
        ObjEntityRequest.ExpireDate = DateTime.ParseExact(datetoexpiry, "dd-MM-yyyy", null);
        ObjEntityRequest.FromDashboard = 1;
        ObjEntityRequest.ExpiryFromDate = DateTime.ParseExact(datetoday, "dd-MM-yyyy", null);
        ObjEntityRequest.GuarTypeId = 0;
        ObjEntityRequest.Guarantee_Method = 0;
        ObjEntityRequest.Biding = 0;
        ObjEntityRequest.Awarded = 0;
        ObjEntityRequest.CusSuply = 0;
        ObjEntityRequest.Cancel_Status = 0;
        ObjEntityRequest.BankId = 0;
        ObjEntityRequest.CusSupSrch = 1;
        ObjEntityRequest.GuartStsSrch = 0;
        DataTable dtContract = new DataTable();
        if (ObjEntityRequest.SuplOrClient != 3)
            dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList(ObjEntityRequest);
        intExpiring = dtContract.Rows.Count;
        divGteeExpiring.InnerHtml = intExpiring.ToString();
        //Expiring in 3 MONTHS Cus
        string datetoexpiry1 = DateTime.Today.AddDays(90).ToString("dd-MM-yyyy");
        string datetoday1 = DateTime.Today.Date.ToString("dd-MM-yyyy");
        ObjEntityRequest.ExpireDate = DateTime.ParseExact(datetoexpiry1, "dd-MM-yyyy", null);
        ObjEntityRequest.FromDashboard = 1;
        ObjEntityRequest.ExpiryFromDate = DateTime.ParseExact(datetoday1, "dd-MM-yyyy", null);
        ObjEntityRequest.GuarTypeId = 0;
        ObjEntityRequest.Guarantee_Method = 0;
        ObjEntityRequest.Biding = 0;
        ObjEntityRequest.Awarded = 0;
        ObjEntityRequest.CusSuply = 0;
        ObjEntityRequest.Cancel_Status = 0;
        ObjEntityRequest.BankId = 0;
        ObjEntityRequest.CusSupSrch = 2;
        ObjEntityRequest.GuartStsSrch = 0;
        DataTable dtContract1 = new DataTable();
        if (ObjEntityRequest.SuplOrClient != 3)
            dtContract1 = ObjBussinessBankGuarnt.ReadRequestGuaranteeList(ObjEntityRequest);
        intExpiring = dtContract1.Rows.Count;
        divGteeExpiringcus.InnerHtml = intExpiring.ToString();
        //expired
        string datetemp = DateTime.Today.Date.ToString("dd-MM-yyyy");
        date = DateTime.ParseExact(datetemp, "dd-MM-yyyy", null);
        ObjEntityRequest.ExpireDate = date;

        ObjEntityRequest.CusSupSrch = 1;
        ObjEntityRequest.FromDashboard = 2;
        DataTable dtContract2 = new DataTable();
        if (ObjEntityRequest.SuplOrClient != 3)
            dtContract2 = ObjBussinessBankGuarnt.ReadRequestGuaranteeList(ObjEntityRequest);
        intExpiredGtee = dtContract2.Rows.Count;
        divExpiredGtees.InnerHtml = intExpiredGtee.ToString();
        //expired cus
        string datetemp1 = DateTime.Today.Date.ToString("dd-MM-yyyy");
        date = DateTime.ParseExact(datetemp, "dd-MM-yyyy", null);
        ObjEntityRequest.ExpireDate = date;

        ObjEntityRequest.CusSupSrch = 2;
        ObjEntityRequest.FromDashboard = 2;
        DataTable dtContract5 = new DataTable();
        if (ObjEntityRequest.SuplOrClient != 3)
            dtContract5 = ObjBussinessBankGuarnt.ReadRequestGuaranteeList(ObjEntityRequest);
        intExpiredGtee = dtContract5.Rows.Count;
        divExpiredGteescus.InnerHtml = intExpiredGtee.ToString();

        //Open
        ObjEntityRequest.OpenDate = DateTime.MinValue;
        ObjEntityRequest.ToDate = DateTime.MinValue;
        ObjEntityRequest.GuarTypeId = 0;
        ObjEntityRequest.Guarantee_Method = 0;
        ObjEntityRequest.Biding = 0;
        ObjEntityRequest.Awarded = 0;
        ObjEntityRequest.CusSuply = 0;

        ObjEntityRequest.CusSupSrch = 1;
        ObjEntityRequest.ExpireDate = DateTime.MinValue;
        ObjEntityRequest.Cancel_Status = 0;
        ObjEntityRequest.BankId = 0;
        ObjEntityRequest.GuartStsSrch = 1;
        ObjEntityRequest.FromDashboard = 0;
        DataTable dtContract3 = new DataTable();
        if (ObjEntityRequest.SuplOrClient != 3)
            dtContract2 = ObjBussinessBankGuarnt.ReadRequestGuaranteeList(ObjEntityRequest);
        intGteeOpenSts = dtContract2.Rows.Count;
        divGteeOpenSts.InnerHtml = intGteeOpenSts.ToString();

        //Open Cus
        ObjEntityRequest.OpenDate = DateTime.MinValue;
        ObjEntityRequest.ToDate = DateTime.MinValue;
        ObjEntityRequest.GuarTypeId = 0;
        ObjEntityRequest.Guarantee_Method = 0;
        ObjEntityRequest.Biding = 0;
        ObjEntityRequest.Awarded = 0;

        ObjEntityRequest.CusSupSrch = 2;
        ObjEntityRequest.CusSuply = 0;
        ObjEntityRequest.ExpireDate = DateTime.MinValue;
        ObjEntityRequest.Cancel_Status = 0;
        ObjEntityRequest.BankId = 0;
        ObjEntityRequest.GuartStsSrch = 1;
        ObjEntityRequest.FromDashboard = 0;
        DataTable dtContract4 = new DataTable();
        if (ObjEntityRequest.SuplOrClient != 3)
            dtContract4 = ObjBussinessBankGuarnt.ReadRequestGuaranteeList(ObjEntityRequest);
        intGteeOpenSts = dtContract4.Rows.Count;
        divGteeOpenStsCus.InnerHtml = intGteeOpenSts.ToString();


        //currently running customer status

        clsCommonLibrary objCommon1 = new clsCommonLibrary();
        ObjEntityRequest.OpenDate = DateTime.MinValue;
        ObjEntityRequest.ToDate = DateTime.MinValue;
        ObjEntityRequest.GuarTypeId = 0;
        ObjEntityRequest.Guarantee_Method = 0;
        ObjEntityRequest.Biding = 0;
        ObjEntityRequest.Awarded = 0;

        ObjEntityRequest.CusSupSrch = 2;
        ObjEntityRequest.CusSuply = 0;
        // ObjEntityRequest.ExpireDate = DateTime.MinValue;
        ObjEntityRequest.Cancel_Status = 0;
        ObjEntityRequest.BankId = 0;
        ObjEntityRequest.GuartStsSrch = 2;
        ObjEntityRequest.FromDashboard = 4;
        string dateExptoday = DateTime.Today.Date.ToString("dd-MM-yyyy");

        ObjEntityRequest.ExpireDate = objCommon1.textToDateTime(dateExptoday);

        DataTable dtGuarntCus = new DataTable();
        if (ObjEntityRequest.SuplOrClient != 3)
            dtGuarntCus = ObjBussinessBankGuarnt.ReadRequestGuaranteeList(ObjEntityRequest);
        intGteeOpenSts = dtGuarntCus.Rows.Count;
        divGuarntRunngCnt.InnerHtml = intGteeOpenSts.ToString();



        //currently running customer status

        //clsCommonLibrary objCommon1 = new clsCommonLibrary();
        ObjEntityRequest.OpenDate = DateTime.MinValue;
        ObjEntityRequest.ToDate = DateTime.MinValue;
        ObjEntityRequest.GuarTypeId = 0;
        ObjEntityRequest.Guarantee_Method = 0;
        ObjEntityRequest.Biding = 0;
        ObjEntityRequest.Awarded = 0;

        ObjEntityRequest.CusSupSrch = 1;
        ObjEntityRequest.CusSuply = 0;
        // ObjEntityRequest.ExpireDate = DateTime.MinValue;
        ObjEntityRequest.Cancel_Status = 0;
        ObjEntityRequest.BankId = 0;
        ObjEntityRequest.GuartStsSrch = 2;
        ObjEntityRequest.FromDashboard = 4;
        string dateExptoday1 = DateTime.Today.Date.ToString("dd-MM-yyyy");

        ObjEntityRequest.ExpireDate = objCommon1.textToDateTime(dateExptoday1);

        DataTable dtGuarntCus1 = new DataTable();
        if (ObjEntityRequest.SuplOrClient != 3)
            dtGuarntCus1 = ObjBussinessBankGuarnt.ReadRequestGuaranteeList(ObjEntityRequest);
        intGteeOpenSts = dtGuarntCus1.Rows.Count;
        divGuarntRunngSup.InnerHtml = intGteeOpenSts.ToString();





    }
    public void LoadDBordCountReqFor()
    {
        classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();
        classBusinessLayerRequestForGrnte ObjBussinessRequest = new classBusinessLayerRequestForGrnte();
        int intRfgPending = 0;

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityRequest.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ObjEntityRequest.Guarantee_Confirm_Status = 1;
        ObjEntityRequest.Guarantee_Status = 1;
        ObjEntityRequest.CustomerId = 0;
        ObjEntityRequest.GuarCatId = 0;
        ObjEntityRequest.Cancel_Status = 0;
        DataTable dtContract = new DataTable();
        dtContract = ObjBussinessRequest.ReadRequestFrGrntyList(ObjEntityRequest);
        intRfgPending = dtContract.Rows.Count;
        divRfgPending.InnerHtml = intRfgPending.ToString();
    }
    public void readDBord_IMS_Count()
    {
        clsBusinessLayerGms_Home ObjBusinessHome = new clsBusinessLayerGms_Home();
        DataTable dtCount=new DataTable();
        dtCount=ObjBusinessHome.Read_IMS_DashBoard();
        if (dtCount.Rows.Count>0)
        {
        divOpen.InnerHtml = dtCount.Rows[0]["OPEN"].ToString();
        divExpired.InnerHtml = dtCount.Rows[0]["CLOSED"].ToString();
        divRun.InnerHtml = dtCount.Rows[0]["CONFIRM"].ToString();
        divMonths.InnerHtml = dtCount.Rows[0]["EXPIRED_WITHIN_3MONTHS"].ToString();
        }

    }
    //EVM-0027

    public void readDBord_BankGurant_Count()
    {
        clsBusinessLayerGms_Home ObjBusinessHome = new clsBusinessLayerGms_Home();
        DataTable dtCount = new DataTable();
        dtCount = ObjBusinessHome.Read_BankGurnt_DashBoard();
        if (dtCount.Rows.Count > 0)
        {
            divGteeOpenStsCus.InnerHtml = dtCount.Rows[0]["CLIENT_OPEN"].ToString();
            divExpiredGteescus.InnerHtml = dtCount.Rows[0]["CLIENT_CLOSED"].ToString();
            divGuarntRunngCnt.InnerHtml = dtCount.Rows[0]["CLIENT_CONFIRM"].ToString();
            divGteeExpiringcus.InnerHtml = dtCount.Rows[0]["CLIENT_EXPIRED_WITHIN_3MONTHS"].ToString();
            //Supplier
            divGteeOpenSts.InnerHtml = dtCount.Rows[0]["SUPPLIER_OPEN"].ToString();
            divExpiredGtees.InnerHtml = dtCount.Rows[0]["SUPPLIER_CLOSED"].ToString();
            divGuarntRunngSup.InnerHtml = dtCount.Rows[0]["SUPPLIER_CONFIRM"].ToString();
            divGteeExpiring.InnerHtml = dtCount.Rows[0]["SUP_EXPIRED_WITHIN_3MONTS"].ToString();
        }

    }
    //END
}
