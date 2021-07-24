using BL_Compzit.BusinessLayer_GMS;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CL_Compzit;
using EL_Compzit.EntityLayer_GMS;
using BL_Compzit;
using EL_Compzit;
using System.Web.Services;
using System.Collections;
using System.IO;
using MailUtility_ERP;
using System.Linq;
// CREATED BY:EVM-0008
// CREATED DATE:10/2/2017
// REVIEWED BY:
// REVIEW DATE:


public partial class GMS_GMS_Master_gen_Bank_Guarantee_gen_Bank_Guarantee_List : System.Web.UI.Page
{

    clsBusinessLayerBankGuarantee ObjBussinessBankGuarnt = new clsBusinessLayerBankGuarantee();
    private enum Button_type
    {
        Previous = 1,
        Next = 2
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ddlPolicyType.Focus();

        ddlGuaranteeMde.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlSuplCus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        if (!IsPostBack)
        {
            pHeader.InnerHtml = "";
            PolicyNumberLoad();
            LoadInsuranceProvider();
            LoadInsuranceType_Master();//evm-0023
            HiddenCheckDashboard.Value = "0";
            HiddenCurrentDate.Value = DateTime.Now.ToString("dd-MM-yyyy");
            btnNext.Enabled = false;
            btnPrevious.Enabled = false;
            HiddenFieldRadioCusSupl.Value = "";
            guaranteeModeLoad();
            BankLoad();
            SuplierLoad();
            CustomerLoad();
            CurrencyLoad();
            //  radioCus.Checked = true;
            hiddenRsnidclose.Value = "";
            HiddenIntCanlId.Value = "0";
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

            intUserRoleRecall = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
            DataTable dtCancelRecall = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUserRoleRecall);
            if (dtCancelRecall.Rows.Count > 0)
            {
                intEnableRecall = 1;
            }
            else
            {
                intEnableRecall = 0;
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
                        hiddenRoleClose.Value = intEnableClose.ToString();
                    }

                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Renew).ToString())
                    {
                        intEnableRenew = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenFieldRenew.Value = intEnableClose.ToString();
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Suplier_Guarantee_Permission).ToString())
                    {
                        intEnableSuplier = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenFieldSuplier.Value = intEnableSuplier.ToString();
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Client_Guarantee_Permission).ToString())
                    {
                        intEnableClient = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenFieldClient.Value = intEnableClient.ToString();

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
                        hiddenFieldConfirm.Value = intEnableConfirm.ToString();

                    }

                }

                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    if (intEnableSuplier == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        divAdd.Visible = true;
                    }
                    else if (intEnableClient == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        divAdd.Visible = true;
                    }
                    else
                    {
                        divAdd.Visible = false;
                    }

                }
                else
                {

                    divAdd.Visible = false;

                }
                clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();

                if (HiddenFieldSuplier.Value == "1" && HiddenFieldClient.Value == "1")
                {
                    ObjEntityRequest.CusSupSrch = 1;
                    // btnConfirm.Visible = true;
                    if (ddlCustSuplrsrch.SelectedValue == "1")
                    {
                        divSuplier.Visible = true;
                        divcustomer.Visible = false;
                        h2SuplCus.InnerText = "Supplier";
                    }
                    else if (ddlCustSuplrsrch.SelectedValue == "2")
                    {
                        divSuplier.Visible = false;
                        divcustomer.Visible = true;
                        h2SuplCus.InnerText = "Customer";
                    }
                    ObjEntityRequest.SuplOrClient = 0;
                }
                else
                {
                    if (HiddenFieldSuplier.Value == "1")
                    {
                        radioBinding.Disabled = true;
                        // radioCus.Disabled = true;
                        // btnConfirm.Visible = true;
                        //radioSup.Disabled = true;
                        //radioSup.Checked = true;
                        radioAwdrd.Checked = true;
                        ObjEntityRequest.SuplOrClient = 1;
                        divSuplier.Visible = true;
                        divcustomer.Visible = false;
                        ddlCustSuplrsrch.SelectedValue = "1";
                        ddlCustSuplrsrch.Enabled = false;
                        ObjEntityRequest.CusSupSrch = 1;
                        h2SuplCus.InnerText = "Supplier";

                    }

                    else if (HiddenFieldClient.Value == "1")
                    {
                        // radioSup.Disabled = true;
                        //btnConfirm.Visible = true;
                        //  radioCus.Checked = true;
                        // radioSup.Disabled = true;
                        ObjEntityRequest.SuplOrClient = 2;
                        divSuplier.Visible = false;
                        divcustomer.Visible = true;
                        ddlCustSuplrsrch.SelectedValue = "2";
                        ddlCustSuplrsrch.Enabled = false;
                        ObjEntityRequest.CusSupSrch = 2;
                        h2SuplCus.InnerText = "Customer";
                    }
                    else
                    {
                        radioBinding.Disabled = true;
                        radioAwdrd.Disabled = true;
                        // btnConfirm.Visible = false;
                        // radioCus.Disabled = true;
                        // btnConfirm.Visible = true;
                        // radioSup.Disabled = true;
                        ddlSuplCus.Enabled = false;
                        ddlSup.Enabled = false;
                        ObjEntityRequest.SuplOrClient = 3;
                        divSuplier.Disabled = true;
                        divcustomer.Visible = false;
                        ddlCustSuplrsrch.Enabled = false;
                    }
                }


                //Creating objects for business layer

                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

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
                    intUserId = Convert.ToInt32(Session["USERID"]);
                    ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                clsBusinessLayer objBusiness = new clsBusinessLayer();
                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                               clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                                  };
                DataTable dtCorpDetail = new DataTable();
                dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
                if (dtCorpDetail.Rows.Count > 0)
                {
                    hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                    //EVM-0027
                    hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                }

                if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
                {
                    string strHidden = Request.QueryString["Srch"].ToString();
                    HiddenSearchField.Value = strHidden;

                    string[] strSearchFields = strHidden.Split(',');
                    string strFromDate = strSearchFields[0];
                    string strToDate = strSearchFields[1];
                    string strGuaranteType = strSearchFields[2];
                    string strGuaranteMode = strSearchFields[3];
                    string strBiding = strSearchFields[4];
                    string strAwarded = strSearchFields[5];
                    string strddlCustSuplr = strSearchFields[6];
                    string EspireDate = strSearchFields[7];
                    string strCbxStatus = strSearchFields[8];
                    string strBankId = strSearchFields[9];
                    string strGuartSts = strSearchFields[10];
                    string strCusSup = strSearchFields[11];
                    string strInsurncPrvdr = strSearchFields[12];
                    string strInsurPolicySts = strSearchFields[13];
                    string strCurrency = strSearchFields[14];

                    if (strInsurncPrvdr != null && strInsurncPrvdr != "")
                    {
                        if (ddlInsurncPrvdr.Items.FindByValue(strInsurncPrvdr) != null)
                        {
                            if (ddlInsurncPrvdr.SelectedItem.Value != "--SELECT INSURANCE PROVIDER--")
                            {
                                ddlInsurncPrvdr.ClearSelection();
                                ddlInsurncPrvdr.Items.FindByValue(strInsurncPrvdr).Selected = true;
                            }
                        }
                    }

                    if (strFromDate != null && strFromDate != "")
                    {

                        txtFromDate.Text = strFromDate;
                        //if (ddlCustomer.Items.FindByValue(strCustomer) != null)ddlCustSuplrsrch
                        //{
                        //    ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                        //}
                    }
                    if (strToDate != null && strToDate != "")
                    {

                        txtToDate.Text = strToDate;
                        //if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                        //{
                        //    ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                        //}
                    }

                    if (strBiding == "1")
                    {
                        radioBinding.Checked = true;
                        //if (ddlGuaranteCat.Items.FindByValue(strGuarantCat) != null)
                        //{
                        //    ddlGuaranteCat.Items.FindByValue(strGuarantCat).Selected = true;
                        //}
                    }
                    else if (strAwarded == "1")
                    {
                        radioAwdrd.Checked = true;
                    }
                    else if (strBiding == "0" && strAwarded == "0")
                    {
                        ObjEntityRequest.Biding = 0;
                        ObjEntityRequest.Awarded = 0;
                    }


                    if (strGuaranteType != null && strGuaranteType != "")
                    {
                        if (ddlGuaranteeTyp.Items.FindByValue(strGuaranteType) != null)
                        {

                            ddlGuaranteeTyp.ClearSelection();
                            ddlGuaranteeTyp.Items.FindByValue(strGuaranteType).Selected = true;

                        }
                    }
                    if (strGuaranteMode != null && strGuaranteMode != "")
                    {
                        if (ddlGuaranteeMde.Items.FindByValue(strGuaranteMode) != null)
                        {
                            if (ddlGuaranteeMde.SelectedItem.Value != "--SELECT GUARANTEE MODE--")
                            {
                                ddlGuaranteeMde.ClearSelection();
                                ddlGuaranteeMde.Items.FindByValue(strGuaranteMode).Selected = true;
                            }
                        }
                    }


                    if (strddlCustSuplr != null && strddlCustSuplr != "")
                    {
                        if (HiddenFieldRadioCusSupl.Value == "1")
                        {
                            if (ddlSuplCus.Items.FindByValue(strddlCustSuplr) != null)
                            {
                                if (ddlSuplCus.SelectedItem.Value != "--SELECT--")
                                {
                                    ddlSuplCus.ClearSelection();
                                    ddlSuplCus.Items.FindByValue(strddlCustSuplr).Selected = true;
                                }
                            }
                        }
                        else
                        {
                            if (ddlSup.Items.FindByValue(strddlCustSuplr) != null)
                            {
                                if (ddlSup.SelectedItem.Value != "--SELECT--")
                                {
                                    ddlSup.ClearSelection();
                                    ddlSup.Items.FindByValue(strddlCustSuplr).Selected = true;
                                }
                            }
                        }
                    }

                    if (EspireDate != null && EspireDate != "")
                    {

                        BankGurntExpire.Text = EspireDate;
                        //if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                        //{
                        //    ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                        //}
                    }

                    if (strCbxStatus == "1")
                    {
                        cbxCnclStatus.Checked = true;
                    }
                    else
                    {
                        cbxCnclStatus.Checked = false;
                    }

                    if (strBankId != null && strBankId != "")
                    {
                        if (ddlBankNm.Items.FindByValue(strBankId) != null)
                        {
                            if (ddlBankNm.SelectedItem.Value != "--SELECT BANK--")
                            {
                                ddlBankNm.ClearSelection();
                                ddlBankNm.Items.FindByValue(strBankId).Selected = true;
                            }
                        }
                    }


                    if (strGuartSts != null && strGuartSts != "")
                    {
                        if (ddlGuaranteeStatus.Items.FindByValue(strGuartSts) != null)
                        {
                            ddlGuaranteeStatus.ClearSelection();

                            ddlGuaranteeStatus.Items.FindByValue(strGuartSts).Selected = true;

                        }
                    }

                    if (strInsurPolicySts != null && strInsurPolicySts != "")
                    {
                        if (ddlPolicyType.Items.FindByValue(strInsurPolicySts) != null)
                        {
                            ddlPolicyType.ClearSelection();
                            ddlPolicyType.Items.FindByValue(strInsurPolicySts).Selected = true;
                        }
                    }


                    if (strCusSup != null && strCusSup != "")
                    {
                        if (ddlCustSuplrsrch.Items.FindByValue(strCusSup) != null)
                        {
                            ddlCustSuplrsrch.ClearSelection();

                            ddlCustSuplrsrch.Items.FindByValue(strCusSup).Selected = true;

                        }
                    }

                }

                clsCommonLibrary.CORP_GLOBAL[] arrEnumerr = {   clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE,
                                                               clsCommonLibrary.CORP_GLOBAL.CMDTY_MANTN_OFFCE,
                                                                clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
                DataTable dtCorpDetails = new DataTable();
                dtCorpDetails = objBusinessLayer.LoadGlobalDetail(arrEnumerr, intCorpId);
                if (dtCorpDetails.Rows.Count > 0)
                {
                    hiddenDfltCurrencyMstrId.Value = dtCorpDetails.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                    hiddenCommodityValue.Value = dtCorpDetails.Rows[0]["CMDTY_MANTN_OFFCE"].ToString();
                    string strListingMode = dtCorpDetails.Rows[0]["LISTING_MODE"].ToString();
                    string strLstingModeSize = dtCorpDetails.Rows[0]["LISTING_MODE_SIZE"].ToString();

                    int intListingMode = Convert.ToInt32(strListingMode);

                    if (intListingMode == 2)//variant
                    {
                        btnNext.Text = "Show Next Records";
                        btnPrevious.Text = "Show Previous Records";
                        hiddenMemorySize.Value = strLstingModeSize;
                    }
                    else if (intListingMode == 1)//fixed
                    {
                        btnNext.Text = "Show Next " + strLstingModeSize + " Records";
                        btnPrevious.Text = "Show Previous " + strLstingModeSize + " Records";
                        hiddenTotalRowCount.Value = strLstingModeSize;
                        hiddenNext.Value = strLstingModeSize;
                    }
                    hiddenPrevious.Value = "0";

                }

                //when recalled
                if (Request.QueryString["ReId"] != null)
                {
                    string strRandomMixedId = Request.QueryString["ReId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    ObjEntityRequest.GuaranteeId = Convert.ToInt32(strId);

                    DataTable dtGurntNum = ObjBussinessBankGuarnt.ChkConfirmBankGuarantee(ObjEntityRequest);

                    ObjEntityRequest.User_Id = intUserId;
                    ObjEntityRequest.GuaranteeNo = dtGurntNum.Rows[0]["GUARANTEE_NUMBER"].ToString();

                    ObjEntityRequest.D_Date = System.DateTime.Now;
                    string strRFQIdChek = "";
                    int intRfqChk = 0;
                    if (dtGurntNum.Rows[0]["RFQ_ID"].ToString() != null && dtGurntNum.Rows[0]["RFQ_ID"].ToString() != "")
                    {
                        ObjEntityRequest.ReqstGrntId = Convert.ToInt32(dtGurntNum.Rows[0]["RFQ_ID"].ToString());
                        strRFQIdChek = ObjBussinessBankGuarnt.ChckDuplRFQIdChek(ObjEntityRequest);
                        if (strRFQIdChek != "" || strRFQIdChek != "0")
                        {
                            intRfqChk = 1;
                        }
                    }

                    string strGurntNo = "";

                    strGurntNo = ObjBussinessBankGuarnt.ChckDuplGurntNo(ObjEntityRequest);
                    if (intRfqChk == 0)
                    {
                        if (strGurntNo == "" || strGurntNo == "0")
                        {


                            ObjBussinessBankGuarnt.ReCallRequest(ObjEntityRequest);
                            if (HiddenSearchField.Value == "")
                            {
                                Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd=Recl");
                            }
                            else
                            {
                                Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd=Recl&Srch=" + this.HiddenSearchField.Value);
                            }

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Duplication", "Duplication();", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationRFQ", "DuplicationRFQ();", true);
                    }

                }








                if (Request.QueryString["Close"] != null)
                {//when Canceled

                    string strRandomMixedId = Request.QueryString["Close"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    ObjEntityRequest.GuaranteeId = Convert.ToInt32(strId);
                    ObjEntityRequest.User_Id = intUserId;

                    ObjEntityRequest.D_Date = System.DateTime.Now;



                    if (HiddenSearchField.Value == "")
                    {
                        ObjEntityRequest.OpenDate = DateTime.MinValue;
                        ObjEntityRequest.ToDate = DateTime.MinValue;
                        ObjEntityRequest.GuarTypeId = 0;
                        ObjEntityRequest.Guarantee_Method = 0;
                        ObjEntityRequest.Biding = 0;
                        ObjEntityRequest.Awarded = 0;
                        ObjEntityRequest.CusSuply = 0;
                        ObjEntityRequest.ExpireDate = DateTime.MinValue;
                        ObjEntityRequest.Cancel_Status = 0;
                        ObjEntityRequest.BankId = 0;
                        ObjEntityRequest.GuartStsSrch = 1;
                        ObjEntityRequest.CusSupSrch = 1;
                        ObjEntityRequest.InsuranceProvider = 0;
                        if (ddlCurrency.SelectedItem.Value != "--SELECT CURRENCY--")
                        {
                            ObjEntityRequest.Currency = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
                        }
                    }
                    else
                    {
                        string strHidden = "";
                        strHidden = HiddenSearchField.Value;


                        string[] strSearchFields = strHidden.Split(',');
                        string strFromDate = strSearchFields[0];
                        string strToDate = strSearchFields[1];
                        string strGuaranteType = strSearchFields[2];
                        string strGuaranteMode = strSearchFields[3];
                        string strBiding = strSearchFields[4];
                        string strAwarded = strSearchFields[5];
                        string strddlCustSuplr = strSearchFields[6];
                        string EspireDate = strSearchFields[7];
                        string strCbxStatus = strSearchFields[8];
                        string strBankId = strSearchFields[9];
                        string strGuartSts = strSearchFields[10];
                        string strCusSup = strSearchFields[11];
                        string strInsurncPrvdr = strSearchFields[12];
                        string strInsurPolicySts = strSearchFields[13];
                        string strCurrency = strSearchFields[14];

                        if (strFromDate != null && strFromDate != "")
                        {

                            txtFromDate.Text = strFromDate;
                            ObjEntityRequest.OpenDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
                            //if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                            //{
                            //    ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                            //}
                        }
                        else
                        {
                            ObjEntityRequest.OpenDate = DateTime.MinValue;
                        }
                        if (strToDate != null && strToDate != "")
                        {

                            txtToDate.Text = strToDate;
                            //if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                            //{
                            //    ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                            //}
                            ObjEntityRequest.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
                        }
                        else
                        {
                            ObjEntityRequest.ToDate = DateTime.MinValue;
                        }
                        if (strBiding == "1")
                        {
                            radioBinding.Checked = true;
                            //if (ddlGuaranteCat.Items.FindByValue(strGuarantCat) != null)
                            //{
                            //    ddlGuaranteCat.Items.FindByValue(strGuarantCat).Selected = true;
                            //}
                            ObjEntityRequest.Biding = 1;
                        }
                        else if (strAwarded == "1")
                        {
                            radioAwdrd.Checked = true;
                            ObjEntityRequest.Awarded = 1;
                        }
                        else if (strBiding == "0" && strAwarded == "0")
                        {
                            ObjEntityRequest.Biding = 0;
                            ObjEntityRequest.Awarded = 0;
                        }

                        if (strGuaranteType != null && strGuaranteType != "")
                        {
                            if (ddlGuaranteeTyp.Items.FindByValue(strGuaranteType) != null)
                            {
                                ddlGuaranteeTyp.ClearSelection();
                                ddlGuaranteeTyp.Items.FindByValue(strGuaranteType).Selected = true;
                                ObjEntityRequest.GuarTypeId = Convert.ToInt32(strGuaranteType);
                            }
                        }
                        if (strGuaranteMode != null && strGuaranteMode != "")
                        {
                            if (ddlGuaranteeMde.Items.FindByValue(strGuaranteMode) != null)
                            {
                                if (ddlGuaranteeMde.SelectedItem.Value != "--SELECT GUARANTEE MODE--")
                                {
                                    ddlGuaranteeMde.ClearSelection();
                                    ddlGuaranteeMde.Items.FindByValue(strGuaranteMode).Selected = true;
                                    ObjEntityRequest.Guarantee_Method = Convert.ToInt32(strGuaranteMode);
                                }
                            }
                        }

                        if (strddlCustSuplr != null && strddlCustSuplr != "")
                        {
                            if (HiddenFieldRadioCusSupl.Value == "1")
                            {
                                if (ddlSuplCus.Items.FindByValue(strddlCustSuplr) != null)
                                {
                                    if (ddlSuplCus.SelectedItem.Value != "--SELECT--")
                                    {
                                        ddlSuplCus.ClearSelection();
                                        ddlSuplCus.Items.FindByValue(strddlCustSuplr).Selected = true;
                                        ObjEntityRequest.CusSuply = Convert.ToInt32(strddlCustSuplr);
                                    }
                                }
                            }
                            else
                            {
                                if (ddlSup.Items.FindByValue(strddlCustSuplr) != null)
                                {
                                    if (ddlSup.SelectedItem.Value != "--SELECT--")
                                    {
                                        ddlSup.ClearSelection();
                                        ddlSup.Items.FindByValue(strddlCustSuplr).Selected = true;
                                        ObjEntityRequest.CusSuply = Convert.ToInt32(strddlCustSuplr);

                                    }
                                }
                            }
                        }

                        if (EspireDate != null && EspireDate != "")
                        {

                            BankGurntExpire.Text = EspireDate;
                            ObjEntityRequest.ExpireDate = objCommon.textToDateTime(BankGurntExpire.Text.Trim());
                            //if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                            //{
                            //    ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                            //}
                        }
                        if (strBankId != null && strBankId != "")
                        {
                            if (ddlBankNm.Items.FindByValue(strBankId) != null)
                            {
                                if (ddlBankNm.SelectedItem.Value != "--SELECT BANK--")
                                {
                                    ddlBankNm.ClearSelection();
                                    ddlBankNm.Items.FindByValue(strBankId).Selected = true;
                                    ObjEntityRequest.BankId = Convert.ToInt32(strBankId);
                                }
                            }
                        }
                        if (strGuartSts != null && strGuartSts != "")
                        {
                            if (ddlGuaranteeStatus.Items.FindByValue(strGuartSts) != null)
                            {
                                ddlGuaranteeStatus.ClearSelection();

                                ddlGuaranteeStatus.Items.FindByValue(strGuartSts).Selected = true;
                                ObjEntityRequest.GuartStsSrch = Convert.ToInt32(strGuartSts);

                            }
                        }
                        if (strInsurPolicySts != null && strInsurPolicySts != "")
                        {
                            if (ddlPolicyType.Items.FindByValue(strInsurPolicySts) != null)
                            {
                                ddlPolicyType.ClearSelection();

                                ddlPolicyType.Items.FindByValue(strInsurPolicySts).Selected = true;
                                ObjEntityRequest.PolicyType = Convert.ToInt32(strInsurPolicySts);

                            }
                        }

                        if (strCbxStatus == "1")
                        {
                            cbxCnclStatus.Checked = true;
                        }
                        else
                        {
                            cbxCnclStatus.Checked = false;
                        }
                        ObjEntityRequest.Cancel_Status = Convert.ToInt32(strCbxStatus);

                        if (strCusSup != null && strCusSup != "")
                        {
                            if (ddlCustSuplrsrch.Items.FindByValue(strCusSup) != null)
                            {
                                ddlCustSuplrsrch.ClearSelection();

                                ddlCustSuplrsrch.Items.FindByValue(strCusSup).Selected = true;
                                ObjEntityRequest.CusSupSrch = Convert.ToInt32(strCusSup);
                            }
                        }
                        if (strInsurncPrvdr != null && strInsurncPrvdr != "")
                        {
                            if (ddlInsurncPrvdr.Items.FindByValue(strInsurncPrvdr) != null)
                            {
                                if (ddlInsurncPrvdr.SelectedItem.Value != "--SELECT INSURANCE PROVIDER--")
                                {
                                    ddlInsurncPrvdr.ClearSelection();
                                    ddlInsurncPrvdr.Items.FindByValue(strInsurncPrvdr).Selected = true;
                                    ObjEntityRequest.InsuranceProvider = Convert.ToInt32(strInsurncPrvdr);
                                }
                            }
                        }

                        if (strCurrency != null && strCurrency != "--SELECT CURRENCY--")
                        {
                            if (ddlCurrency.Items.FindByValue(strCurrency) != null)
                            {
                                ddlCurrency.ClearSelection();
                                ddlCurrency.Items.FindByValue(strCurrency).Selected = true;
                                ObjEntityRequest.Currency = Convert.ToInt32(strCurrency);
                            }
                        }

                    }
                    DataTable dtContract = new DataTable();
                    if (ObjEntityRequest.SuplOrClient != 3)
                        // dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList(ObjEntityRequest);

                        dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList1(ObjEntityRequest);

                    string strHtm = ConvertDataTableToHTML(dtContract, intEnableModify, intEnableCancel, intEnableRecall, intEnableClose, intEnableRenew, intEnableConfirm);
                    //Write to divReport
                    divReport.InnerHtml = strHtm;

                    string strPrintReport = ConvertDataTableForPrint(dtContract);
                    divPrintReport.InnerHtml = strPrintReport;

                    hiddenRsnidclose.Value = strId;






                }




                if (Request.QueryString["Id"] != null)
                {//when Canceled

                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    ObjEntityRequest.GuaranteeId = Convert.ToInt32(strId);
                    ObjEntityRequest.User_Id = intUserId;

                    ObjEntityRequest.D_Date = System.DateTime.Now;

                    if (dtCorpDetail.Rows.Count > 0)
                    {
                        string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                        if (CnclrsnMust == "0")
                        {
                            ObjEntityRequest.Cancel_reason = objCommon.CancelReason();

                            ObjBussinessBankGuarnt.CancelRequest(ObjEntityRequest);
                            if (HiddenSearchField.Value == "")
                            {
                                Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd=Cncl");
                            }
                            else
                            {
                                Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
                            }

                        }
                        else
                        {




                            if (HiddenSearchField.Value == "")
                            {
                                ObjEntityRequest.OpenDate = DateTime.MinValue;
                                ObjEntityRequest.ToDate = DateTime.MinValue;
                                ObjEntityRequest.GuarTypeId = 0;
                                ObjEntityRequest.Guarantee_Method = 0;
                                ObjEntityRequest.Biding = 0;
                                ObjEntityRequest.Awarded = 0;
                                ObjEntityRequest.CusSuply = 0;
                                ObjEntityRequest.ExpireDate = DateTime.MinValue;
                                ObjEntityRequest.Cancel_Status = 0;
                                ObjEntityRequest.BankId = 0;
                                ObjEntityRequest.GuartStsSrch = 1;
                                ObjEntityRequest.CusSupSrch = 1;
                                ObjEntityRequest.InsuranceProvider = 0;
                                if (ddlCurrency.SelectedItem.Value != "--SELECT CURRENCY--")
                                {
                                    ObjEntityRequest.Currency = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
                                }
                            }
                            else
                            {
                                string strHidden = "";
                                strHidden = HiddenSearchField.Value;


                                string[] strSearchFields = strHidden.Split(',');
                                string strFromDate = strSearchFields[0];
                                string strToDate = strSearchFields[1];
                                string strGuaranteType = strSearchFields[2];
                                string strGuaranteMode = strSearchFields[3];
                                string strBiding = strSearchFields[4];
                                string strAwarded = strSearchFields[5];
                                string strddlCustSuplr = strSearchFields[6];
                                string EspireDate = strSearchFields[7];
                                string strCbxStatus = strSearchFields[8];
                                string strBankId = strSearchFields[9];
                                string strGuartSts = strSearchFields[10];
                                string strCusSup = strSearchFields[11];
                                string strInsurncPrvdr = strSearchFields[12];
                                string strInsurPolicySts = strSearchFields[13];
                                string strCurrency = strSearchFields[14];

                                if (strFromDate != null && strFromDate != "")
                                {

                                    txtFromDate.Text = strFromDate;
                                    ObjEntityRequest.OpenDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
                                    //if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                                    //{
                                    //    ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                                    //}
                                }
                                else
                                {
                                    ObjEntityRequest.OpenDate = DateTime.MinValue;
                                }
                                if (strToDate != null && strToDate != "")
                                {

                                    txtToDate.Text = strToDate;
                                    //if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                                    //{
                                    //    ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                                    //}
                                    ObjEntityRequest.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
                                }
                                else
                                {
                                    ObjEntityRequest.ToDate = DateTime.MinValue;
                                }
                                if (strBiding == "1")
                                {
                                    radioBinding.Checked = true;
                                    //if (ddlGuaranteCat.Items.FindByValue(strGuarantCat) != null)
                                    //{
                                    //    ddlGuaranteCat.Items.FindByValue(strGuarantCat).Selected = true;
                                    //}
                                    ObjEntityRequest.Biding = 1;
                                }
                                else if (strAwarded == "1")
                                {
                                    radioAwdrd.Checked = true;
                                    ObjEntityRequest.Awarded = 1;
                                }
                                else if (strBiding == "0" && strAwarded == "0")
                                {
                                    ObjEntityRequest.Biding = 0;
                                    ObjEntityRequest.Awarded = 0;
                                }

                                if (strGuaranteType != null && strGuaranteType != "")
                                {
                                    if (ddlGuaranteeTyp.Items.FindByValue(strGuaranteType) != null)
                                    {
                                        ddlGuaranteeTyp.ClearSelection();
                                        ddlGuaranteeTyp.Items.FindByValue(strGuaranteType).Selected = true;
                                        ObjEntityRequest.GuarTypeId = Convert.ToInt32(strGuaranteType);
                                    }
                                }
                                if (strGuaranteMode != null && strGuaranteMode != "")
                                {
                                    if (ddlGuaranteeMde.Items.FindByValue(strGuaranteMode) != null)
                                    {
                                        if (ddlGuaranteeMde.SelectedItem.Value != "--SELECT GUARANTEE MODE--")
                                        {
                                            ddlGuaranteeMde.ClearSelection();
                                            ddlGuaranteeMde.Items.FindByValue(strGuaranteMode).Selected = true;
                                            ObjEntityRequest.Guarantee_Method = Convert.ToInt32(strGuaranteMode);
                                        }
                                    }
                                }

                                if (strddlCustSuplr != null && strddlCustSuplr != "")
                                {
                                    if (HiddenFieldRadioCusSupl.Value == "1")
                                    {
                                        if (ddlSuplCus.Items.FindByValue(strddlCustSuplr) != null)
                                        {
                                            if (ddlSuplCus.SelectedItem.Value != "--SELECT--")
                                            {
                                                ddlSuplCus.ClearSelection();
                                                ddlSuplCus.Items.FindByValue(strddlCustSuplr).Selected = true;
                                                ObjEntityRequest.CusSuply = Convert.ToInt32(strddlCustSuplr);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (ddlSup.Items.FindByValue(strddlCustSuplr) != null)
                                        {
                                            if (ddlSup.SelectedItem.Value != "--SELECT--")
                                            {
                                                ddlSup.ClearSelection();
                                                ddlSup.Items.FindByValue(strddlCustSuplr).Selected = true;
                                                ObjEntityRequest.CusSuply = Convert.ToInt32(strddlCustSuplr);

                                            }
                                        }
                                    }
                                }

                                if (EspireDate != null && EspireDate != "")
                                {

                                    BankGurntExpire.Text = EspireDate;
                                    ObjEntityRequest.ExpireDate = objCommon.textToDateTime(BankGurntExpire.Text.Trim());
                                    //if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                                    //{
                                    //    ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                                    //}
                                }
                                if (strBankId != null && strBankId != "")
                                {
                                    if (ddlBankNm.Items.FindByValue(strBankId) != null)
                                    {
                                        if (ddlBankNm.SelectedItem.Value != "--SELECT BANK--")
                                        {
                                            ddlBankNm.ClearSelection();
                                            ddlBankNm.Items.FindByValue(strBankId).Selected = true;
                                            ObjEntityRequest.BankId = Convert.ToInt32(strBankId);
                                        }
                                    }
                                }
                                if (strGuartSts != null && strGuartSts != "")
                                {
                                    if (ddlGuaranteeStatus.Items.FindByValue(strGuartSts) != null)
                                    {
                                        ddlGuaranteeStatus.ClearSelection();

                                        ddlGuaranteeStatus.Items.FindByValue(strGuartSts).Selected = true;
                                        ObjEntityRequest.GuartStsSrch = Convert.ToInt32(strGuartSts);

                                    }
                                }

                                if (strInsurPolicySts != null && strInsurPolicySts != "")
                                {
                                    if (ddlPolicyType.Items.FindByValue(strInsurPolicySts) != null)
                                    {
                                        ddlPolicyType.ClearSelection();

                                        ddlPolicyType.Items.FindByValue(strInsurPolicySts).Selected = true;
                                        ObjEntityRequest.PolicyType = Convert.ToInt32(strInsurPolicySts);

                                    }
                                }

                                if (strCbxStatus == "1")
                                {
                                    cbxCnclStatus.Checked = true;
                                }
                                else
                                {
                                    cbxCnclStatus.Checked = false;
                                }
                                ObjEntityRequest.Cancel_Status = Convert.ToInt32(strCbxStatus);


                                if (strCusSup != null && strCusSup != "")
                                {
                                    if (ddlCustSuplrsrch.Items.FindByValue(strCusSup) != null)
                                    {
                                        ddlCustSuplrsrch.ClearSelection();

                                        ddlCustSuplrsrch.Items.FindByValue(strCusSup).Selected = true;
                                        ObjEntityRequest.CusSupSrch = Convert.ToInt32(strCusSup);

                                    }
                                }
                                if (strInsurncPrvdr != null && strInsurncPrvdr != "")
                                {
                                    if (ddlInsurncPrvdr.Items.FindByValue(strInsurncPrvdr) != null)
                                    {
                                        if (ddlInsurncPrvdr.SelectedItem.Value != "--SELECT INSURANCE PROVIDER--")
                                        {
                                            ddlInsurncPrvdr.ClearSelection();
                                            ddlInsurncPrvdr.Items.FindByValue(strInsurncPrvdr).Selected = true;
                                            ObjEntityRequest.InsuranceProvider = Convert.ToInt32(strInsurncPrvdr);
                                        }
                                    }
                                }

                                if (strCurrency != null && strCurrency != "--SELECT CURRENCY--")
                                {
                                    if (ddlCurrency.Items.FindByValue(strCurrency) != null)
                                    {
                                        ddlCurrency.ClearSelection();
                                        ddlCurrency.Items.FindByValue(strCurrency).Selected = true;
                                        ObjEntityRequest.Currency = Convert.ToInt32(strCurrency);
                                    }
                                }
                            }
                            DataTable dtContract = new DataTable();
                            if (ObjEntityRequest.SuplOrClient != 3)
                                // dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList(ObjEntityRequest);
                                dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList1(ObjEntityRequest);
                            string strHtm = ConvertDataTableToHTML(dtContract, intEnableModify, intEnableCancel, intEnableRecall, intEnableClose, intEnableRenew, intEnableConfirm);
                            //Write to divReport
                            divReport.InnerHtml = strHtm;
                            string strPrintReport = ConvertDataTableForPrint(dtContract);
                            divPrintReport.InnerHtml = strPrintReport;

                            hiddenRsnid.Value = strId;


                        }

                    }
                }


                //from dashboard

                else if (Request.QueryString["default"] != null)
                {
                    hiddenDefaultDashboard.Value = "1";

                    ObjEntityRequest.PolicyType = 1;
                    ddlPolicyType.ClearSelection();
                    ddlPolicyType.Items.FindByValue("1").Selected = true;

                    ddlCurrency.ClearSelection();
                    ddlCurrency.Items.FindByValue("--SELECT CURRENCY--").Selected = true;
                    ObjEntityRequest.Currency = 0;

                    int typeid = 0;
                    DateTime date = DateTime.Today; ;
                    ObjEntityRequest.InsuranceProvider = 0;
                    ObjEntityRequest.OpenDate = DateTime.MinValue;
                    ObjEntityRequest.ToDate = DateTime.MinValue;
                    ObjEntityRequest.ExpireDate = DateTime.MinValue;
                    if (Request.QueryString["default"] == "3monthssup")
                    {
                        ObjEntityRequest.CusSupSrch = 1;
                        // txtFromDate.Text = DateTime.Today.Date.ToString("dd-MM-yyyy");
                        // txtToDate.Text = (DateTime.Today.AddDays(90)).ToString("dd-MM-yyyy");
                        //HiddenSearchField.Value = "0";
                        //string d = DateTime.Today.AddDays(90).ToString();
                        string datetoexpiry = DateTime.Today.AddDays(90).ToString("dd-MM-yyyy");
                        string datetoday = DateTime.Today.Date.ToString("dd-MM-yyyy");
                        //date = DateTime.ParseExact(datetoexpiry, "dd-MM-yyyy", null);
                        //ObjEntityRequest.ExpireDate = DateTime.ParseExact(datetoexpiry, "dd-MM-yyyy", null);

                        ObjEntityRequest.FromDashboard = 1;
                        //ObjEntityRequest.ExpiryFromDate = DateTime.ParseExact(datetoday, "dd-MM-yyyy", null);
                        //  date = DateTime.Parse(DateTime.Today.AddDays(90).ToString("dd-MM-yyyy"));
                        if (Request.QueryString["InsUpd"] != null)
                        {
                            string strInsUpd = Request.QueryString["InsUpd"].ToString();
                            if (strInsUpd == "Upd")
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                            }
                        }
                        pHeader.InnerHtml = "Supplier guarantees expiring in 3 months";
                        //ObjEntityRequest.GuartStsSrch = 0;
                        ddlGuaranteeStatus.ClearSelection();
                        ddlGuaranteeStatus.Items.FindByText("All").Selected = true;

                        ddlCustSuplrsrch.ClearSelection();
                        ddlCustSuplrsrch.Items.FindByText("SUPPLIER").Selected = true;

                        ObjEntityRequest.SuplOrClient = 102;
                    }
                    else if (Request.QueryString["default"] == "3monthscus")
                    {
                        // txtFromDate.Text = DateTime.Today.Date.ToString("dd-MM-yyyy");
                        // txtToDate.Text = (DateTime.Today.AddDays(90)).ToString("dd-MM-yyyy");
                        //HiddenSearchField.Value = "0";
                        //string d = DateTime.Today.AddDays(90).ToString();
                        ObjEntityRequest.CusSupSrch = 2;
                        string datetoexpiry = DateTime.Today.AddDays(90).ToString("dd-MM-yyyy");
                        string datetoday = DateTime.Today.Date.ToString("dd-MM-yyyy");
                        //date = DateTime.ParseExact(datetoexpiry, "dd-MM-yyyy", null);
                       // ObjEntityRequest.ExpireDate = DateTime.ParseExact(datetoexpiry, "dd-MM-yyyy", null);

                        ObjEntityRequest.FromDashboard = 1;
                        //ObjEntityRequest.ExpiryFromDate = DateTime.ParseExact(datetoday, "dd-MM-yyyy", null);
                        //  date = DateTime.Parse(DateTime.Today.AddDays(90).ToString("dd-MM-yyyy"));
                        if (Request.QueryString["InsUpd"] != null)
                        {
                            string strInsUpd = Request.QueryString["InsUpd"].ToString();
                            if (strInsUpd == "Upd")
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                            }
                        }
                        pHeader.InnerHtml = "Client guarantees expiring in 3 months";
                        //ObjEntityRequest.GuartStsSrch = 0;
                        ddlGuaranteeStatus.ClearSelection();
                        ddlGuaranteeStatus.Items.FindByText("All").Selected = true;

                        ddlCustSuplrsrch.ClearSelection();
                        ddlCustSuplrsrch.Items.FindByText("CUSTOMER").Selected = true;

                        ObjEntityRequest.SuplOrClient = 102;
                    }
                    else if (Request.QueryString["default"] == "expiredsup")
                    {
                        ObjEntityRequest.CusSupSrch = 1;
                        BankGurntExpire.Text = (DateTime.Today.Date.ToString("dd-MM-yyyy"));

                        string datetemp = DateTime.Today.Date.ToString("dd-MM-yyyy");

                        date = DateTime.ParseExact(datetemp, "dd-MM-yyyy", null);
                       // ObjEntityRequest.ExpireDate = date;
                        ObjEntityRequest.FromDashboard = 2;
                        if (Request.QueryString["InsUpd"] != null)
                        {
                            string strInsUpd = Request.QueryString["InsUpd"].ToString();
                            if (strInsUpd == "Upd")
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                            }
                        }
                        pHeader.InnerHtml = "Expired supplier guarantees ";
                        //ObjEntityRequest.GuartStsSrch = 0;
                        ddlGuaranteeStatus.ClearSelection();
                        ddlGuaranteeStatus.Items.FindByText("All").Selected = true;

                        ddlCustSuplrsrch.ClearSelection();
                        ddlCustSuplrsrch.Items.FindByText("SUPPLIER").Selected = true;

                        ObjEntityRequest.SuplOrClient = 102;
                    }
                    else if (Request.QueryString["default"] == "expiredcus")
                    {
                        BankGurntExpire.Text = (DateTime.Today.Date.ToString("dd-MM-yyyy"));

                        string datetemp = DateTime.Today.Date.ToString("dd-MM-yyyy");
                        ObjEntityRequest.CusSupSrch = 2;
                        date = DateTime.ParseExact(datetemp, "dd-MM-yyyy", null);
                       // ObjEntityRequest.ExpireDate = date;
                        ObjEntityRequest.FromDashboard = 2;

                        if (Request.QueryString["InsUpd"] != null)
                        {
                            string strInsUpd = Request.QueryString["InsUpd"].ToString();
                            if (strInsUpd == "Upd")
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                            }
                        }
                        pHeader.InnerHtml = "Expired client guarantees";
                        //ObjEntityRequest.GuartStsSrch = 0;
                        ddlGuaranteeStatus.ClearSelection();
                        ddlGuaranteeStatus.Items.FindByText("All").Selected = true;

                        ddlCustSuplrsrch.ClearSelection();
                        ddlCustSuplrsrch.Items.FindByText("CUSTOMER").Selected = true;

                        ObjEntityRequest.SuplOrClient = 101;
                    }
                    else if (Request.QueryString["default"] == "newsup")
                    {
                        ObjEntityRequest.CusSupSrch = 1;
                        pHeader.InnerHtml = "Supplier guarantees under open status";
                        ObjEntityRequest.GuartStsSrch = 1;
                        ddlGuaranteeStatus.ClearSelection();
                        ddlGuaranteeStatus.Items.FindByText("New").Selected = true;

                        ddlCustSuplrsrch.ClearSelection();
                        ddlCustSuplrsrch.Items.FindByText("SUPPLIER").Selected = true;

                        ObjEntityRequest.SuplOrClient = 102;
                    }
                    else if (Request.QueryString["default"] == "newcus")
                    {
                        ObjEntityRequest.CusSupSrch = 2;
                        pHeader.InnerHtml = "Client guarantees under open status";
                        ObjEntityRequest.GuartStsSrch = 1;
                        ddlGuaranteeStatus.ClearSelection();
                        ddlGuaranteeStatus.Items.FindByText("New").Selected = true;

                        ddlCustSuplrsrch.ClearSelection();
                        ddlCustSuplrsrch.Items.FindByText("CUSTOMER").Selected = true;

                        ObjEntityRequest.SuplOrClient = 101;
                    }

                    else if (Request.QueryString["default"] == "CurrntlyrungCus")
                    {
                        clsCommonLibrary objCommon1 = new clsCommonLibrary();
                        ObjEntityRequest.CusSupSrch = 2;
                        string datetemp = DateTime.Today.Date.ToString("dd-MM-yyyy");

                        // date = DateTime.ParseExact(datetemp, "dd-MM-yyyy", null);
                        //ObjEntityRequest.ExpireDate = objCommon1.textToDateTime(datetemp);
                        ObjEntityRequest.FromDashboard = 4;

                        pHeader.InnerHtml = "Currently running client guarantees ";
                        //ObjEntityRequest.GuartStsSrch = 2;
                        ddlGuaranteeStatus.ClearSelection();
                        ddlGuaranteeStatus.Items.FindByText("Confirmed").Selected = true;

                        ddlCustSuplrsrch.ClearSelection();
                        ddlCustSuplrsrch.Items.FindByText("CUSTOMER").Selected = true;

                        ObjEntityRequest.SuplOrClient = 101;
                    }

                    else if (Request.QueryString["default"] == "CurrntlyrungSup")
                    {
                        clsCommonLibrary objCommon1 = new clsCommonLibrary();
                        ObjEntityRequest.CusSupSrch = 1;
                        // BankGurntExpire.Text = (DateTime.Today.Date.ToString("dd-MM-yyyy"));

                        string datetemp = DateTime.Today.Date.ToString("dd-MM-yyyy");

                        // date = DateTime.ParseExact(datetemp, "dd-MM-yyyy", null);
                       // ObjEntityRequest.ExpireDate = objCommon1.textToDateTime(datetemp);
                        ObjEntityRequest.FromDashboard = 4;

                        pHeader.InnerHtml = "Currently running supplier guarantees ";
                       // ObjEntityRequest.GuartStsSrch = 2;
                        ddlGuaranteeStatus.ClearSelection();
                        ddlGuaranteeStatus.Items.FindByText("Confirmed").Selected = true;

                        ddlCustSuplrsrch.ClearSelection();
                        ddlCustSuplrsrch.Items.FindByText("SUPPLIER").Selected = true;

                        ObjEntityRequest.SuplOrClient = 102;
                    }

                    // ObjEntityRequest.Guarantee_Confirm_Status = typeid;
                    ObjEntityRequest.GuarTypeId = 0;
                    ObjEntityRequest.Guarantee_Method = 0;
                    ObjEntityRequest.Biding = 0;
                    ObjEntityRequest.Awarded = 0;
                    ObjEntityRequest.CusSuply = 0;

                    ObjEntityRequest.Cancel_Status = 0;
                    ObjEntityRequest.BankId = 0;
                    if (ddlCurrency.SelectedItem.Value != "--SELECT CURRENCY--")
                    {
                        ObjEntityRequest.Currency = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
                    }

                    DataTable dtContract = new DataTable();
                    if (ObjEntityRequest.SuplOrClient != 3)
                        //dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList(ObjEntityRequest);
                        dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList1(ObjEntityRequest);
                    int ROWCT = dtContract.Rows.Count;
                    string strHtm = ConvertDataTableToHTML(dtContract, intEnableModify, intEnableCancel, intEnableRecall, intEnableClose, intEnableRenew, intEnableConfirm);
                    //Write to divReport
                    divReport.InnerHtml = strHtm;
                    string strPrintReport = ConvertDataTableForPrint(dtContract);
                    divPrintReport.InnerHtml = strPrintReport;

                }
                else if (Request.QueryString["CONF"] != null)
                {
                    //after alert msg
                    string strRandomMixedId = Request.QueryString["CONF"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);
                    ObjEntityRequest.GuaranteeId = Convert.ToInt32(strId);
                    ObjEntityRequest.D_Date = System.DateTime.Now;

                    DataTable GuarantStatus = ObjBussinessBankGuarnt.ChkConfirmBankGuarantee(ObjEntityRequest);
                    string strchckStatus = "";
                    if (GuarantStatus.Rows.Count > 0)
                    {
                        strchckStatus = GuarantStatus.Rows[0]["GUARANTEE_STATUS"].ToString();
                    }

                    if (strchckStatus != "2")
                    {

                        //DataTable dtRqstFrGrnt = ObjBussinessBankGuarnt.ReadGuranteeById(ObjEntityBnkGurnt);
                        ObjBussinessBankGuarnt.ConfirmBankGuarantee(ObjEntityRequest);
                        if (HiddenSearchField.Value != "")
                        {
                            Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd=CONF&Srch=" + this.HiddenSearchField.Value);
                        }
                        else
                        {
                            Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd=CONF");
                        }
                    }
                    else
                    {
                        Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd=CONFCHK");
                    }



                    if (HiddenSearchField.Value == "")
                    {
                        ObjEntityRequest.OpenDate = DateTime.MinValue;
                        ObjEntityRequest.ToDate = DateTime.MinValue;
                        ObjEntityRequest.GuarTypeId = 0;
                        ObjEntityRequest.Guarantee_Method = 0;
                        ObjEntityRequest.Biding = 0;
                        ObjEntityRequest.Awarded = 0;
                        ObjEntityRequest.CusSuply = 0;
                        ObjEntityRequest.ExpireDate = DateTime.MinValue;
                        ObjEntityRequest.Cancel_Status = 0;
                        ObjEntityRequest.BankId = 0;
                        ObjEntityRequest.GuartStsSrch = 1;
                        ObjEntityRequest.CusSupSrch = 1;
                        ObjEntityRequest.InsuranceProvider = 0;
                        if (ddlCurrency.SelectedItem.Value != "--SELECT CURRENCY--")
                        {
                            ObjEntityRequest.Currency = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
                        }
                    }
                    else
                    {
                        string strHidden = "";
                        strHidden = HiddenSearchField.Value;


                        string[] strSearchFields = strHidden.Split(',');
                        string strFromDate = strSearchFields[0];
                        string strToDate = strSearchFields[1];
                        string strGuaranteType = strSearchFields[2];
                        string strGuaranteMode = strSearchFields[3];
                        string strBiding = strSearchFields[4];
                        string strAwarded = strSearchFields[5];
                        string strddlCustSuplr = strSearchFields[6];
                        string EspireDate = strSearchFields[7];
                        string strCbxStatus = strSearchFields[8];
                        string strBankId = strSearchFields[9];
                        string strGuartSts = strSearchFields[10];
                        string strCusSup = strSearchFields[11];
                        string strInsurncPrvdr = strSearchFields[12];
                        string strInsurPolicySts = strSearchFields[13];
                        string strCurrency = strSearchFields[14];

                        if (strFromDate != null && strFromDate != "")
                        {

                            txtFromDate.Text = strFromDate;
                            ObjEntityRequest.OpenDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
                            //if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                            //{
                            //    ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                            //}
                        }
                        else
                        {
                            ObjEntityRequest.OpenDate = DateTime.MinValue;
                        }
                        if (strToDate != null && strToDate != "")
                        {

                            txtToDate.Text = strToDate;
                            //if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                            //{
                            //    ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                            //}
                            ObjEntityRequest.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
                        }
                        else
                        {
                            ObjEntityRequest.ToDate = DateTime.MinValue;
                        }
                        if (strBiding == "1")
                        {
                            radioBinding.Checked = true;
                            //if (ddlGuaranteCat.Items.FindByValue(strGuarantCat) != null)
                            //{
                            //    ddlGuaranteCat.Items.FindByValue(strGuarantCat).Selected = true;
                            //}
                            ObjEntityRequest.Biding = 1;
                        }
                        else if (strAwarded == "1")
                        {
                            radioAwdrd.Checked = true;
                            ObjEntityRequest.Awarded = 1;
                        }
                        else if (strBiding == "0" && strAwarded == "0")
                        {
                            ObjEntityRequest.Biding = 0;
                            ObjEntityRequest.Awarded = 0;
                        }

                        if (strGuaranteType != null && strGuaranteType != "")
                        {
                            if (ddlGuaranteeTyp.Items.FindByValue(strGuaranteType) != null)
                            {
                                ddlGuaranteeTyp.ClearSelection();
                                ddlGuaranteeTyp.Items.FindByValue(strGuaranteType).Selected = true;
                                ObjEntityRequest.GuarTypeId = Convert.ToInt32(strGuaranteType);
                            }
                        }
                        if (strGuaranteMode != null && strGuaranteMode != "")
                        {
                            if (ddlGuaranteeMde.Items.FindByValue(strGuaranteMode) != null)
                            {
                                if (ddlGuaranteeMde.SelectedItem.Value != "--SELECT GUARANTEE MODE--")
                                {
                                    ddlGuaranteeMde.ClearSelection();
                                    ddlGuaranteeMde.Items.FindByValue(strGuaranteMode).Selected = true;
                                    ObjEntityRequest.Guarantee_Method = Convert.ToInt32(strGuaranteMode);
                                }
                            }
                        }

                        if (strddlCustSuplr != null && strddlCustSuplr != "")
                        {
                            if (HiddenFieldRadioCusSupl.Value == "1")
                            {
                                if (ddlSuplCus.Items.FindByValue(strddlCustSuplr) != null)
                                {
                                    if (ddlSuplCus.SelectedItem.Value != "--SELECT--")
                                    {
                                        ddlSuplCus.ClearSelection();
                                        ddlSuplCus.Items.FindByValue(strddlCustSuplr).Selected = true;
                                        ObjEntityRequest.CusSuply = Convert.ToInt32(strddlCustSuplr);
                                    }
                                }
                            }
                            else
                            {
                                if (ddlSup.Items.FindByValue(strddlCustSuplr) != null)
                                {
                                    if (ddlSup.SelectedItem.Value != "--SELECT--")
                                    {
                                        ddlSup.ClearSelection();
                                        ddlSup.Items.FindByValue(strddlCustSuplr).Selected = true;
                                        ObjEntityRequest.CusSuply = Convert.ToInt32(strddlCustSuplr);

                                    }
                                }
                            }
                        }

                        if (EspireDate != null && EspireDate != "")
                        {

                            BankGurntExpire.Text = EspireDate;
                            ObjEntityRequest.ExpireDate = objCommon.textToDateTime(BankGurntExpire.Text.Trim());
                            //if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                            //{
                            //    ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                            //}
                        }
                        if (strBankId != null && strBankId != "")
                        {
                            if (ddlBankNm.Items.FindByValue(strBankId) != null)
                            {
                                if (ddlBankNm.SelectedItem.Value != "--SELECT BANK--")
                                {
                                    ddlBankNm.ClearSelection();
                                    ddlBankNm.Items.FindByValue(strBankId).Selected = true;
                                    ObjEntityRequest.BankId = Convert.ToInt32(strBankId);
                                }
                            }
                        }
                        if (strGuartSts != null && strGuartSts != "")
                        {
                            if (ddlGuaranteeStatus.Items.FindByValue(strGuartSts) != null)
                            {
                                ddlGuaranteeStatus.ClearSelection();

                                ddlGuaranteeStatus.Items.FindByValue(strGuartSts).Selected = true;
                                ObjEntityRequest.GuartStsSrch = Convert.ToInt32(strGuartSts);

                            }
                        }
                        if (strInsurPolicySts != null && strInsurPolicySts != "")
                        {
                            if (ddlPolicyType.Items.FindByValue(strInsurPolicySts) != null)
                            {
                                ddlPolicyType.ClearSelection();

                                ddlPolicyType.Items.FindByValue(strInsurPolicySts).Selected = true;
                                ObjEntityRequest.PolicyType = Convert.ToInt32(strInsurPolicySts);

                            }
                        }

                        if (strCbxStatus == "1")
                        {
                            cbxCnclStatus.Checked = true;
                        }
                        else
                        {
                            cbxCnclStatus.Checked = false;
                        }
                        ObjEntityRequest.Cancel_Status = Convert.ToInt32(strCbxStatus);

                        if (strCusSup != null && strCusSup != "")
                        {
                            if (ddlCustSuplrsrch.Items.FindByValue(strCusSup) != null)
                            {
                                ddlCustSuplrsrch.ClearSelection();

                                ddlCustSuplrsrch.Items.FindByValue(strCusSup).Selected = true;
                                ObjEntityRequest.CusSupSrch = Convert.ToInt32(strCusSup);
                            }
                        }
                        if (strInsurncPrvdr != null && strInsurncPrvdr != "")
                        {
                            if (ddlInsurncPrvdr.Items.FindByValue(strInsurncPrvdr) != null)
                            {
                                if (ddlInsurncPrvdr.SelectedItem.Value != "--SELECT INSURANCE PROVIDER--")
                                {
                                    ddlInsurncPrvdr.ClearSelection();
                                    ddlInsurncPrvdr.Items.FindByValue(strInsurncPrvdr).Selected = true;
                                    ObjEntityRequest.InsuranceProvider = Convert.ToInt32(strInsurncPrvdr);
                                }
                            }
                        }

                        if (strCurrency != null && strCurrency != "")
                        {
                            if (ddlCurrency.Items.FindByValue(strCurrency) != null)
                            {
                                ddlCurrency.ClearSelection();
                                ddlCurrency.Items.FindByValue(strCurrency).Selected = true;
                                ObjEntityRequest.Currency = Convert.ToInt32(strCurrency);
                            }
                        }

                    }
                    DataTable dtContract = new DataTable();
                    if (ObjEntityRequest.SuplOrClient != 3)
                        //    dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList(ObjEntityRequest);
                        dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList1(ObjEntityRequest);
                    string strHtm = ConvertDataTableToHTML(dtContract, intEnableModify, intEnableCancel, intEnableRecall, intEnableClose, intEnableRenew, intEnableConfirm);
                    string strPrintReport = ConvertDataTableForPrint(dtContract);
                    divPrintReport.InnerHtml = strPrintReport;
                    //Write to divReport
                    divReport.InnerHtml = strHtm;

                }

                else
                {
                    //to view
                    if (HiddenSearchField.Value == "")
                    {
                        ObjEntityRequest.OpenDate = DateTime.MinValue;
                        ObjEntityRequest.ToDate = DateTime.MinValue;
                        ObjEntityRequest.GuarTypeId = 0;
                        ObjEntityRequest.Guarantee_Method = 0;
                        ObjEntityRequest.Biding = 0;
                        ObjEntityRequest.Awarded = 0;
                        ObjEntityRequest.CusSuply = 0;
                        ObjEntityRequest.ExpireDate = DateTime.MinValue;
                        ObjEntityRequest.Cancel_Status = 0;
                        ObjEntityRequest.BankId = 0;
                        ObjEntityRequest.GuartStsSrch = 0;
                        ObjEntityRequest.InsuranceProvider = 0;

                        if (ddlPolicyType.SelectedItem.Value != "" && ddlPolicyType.SelectedItem.Value != "--select--")
                        {
                            ObjEntityRequest.PolicyType = Convert.ToInt32(ddlPolicyType.SelectedItem.Value);  //evm-0023
                        }
                        else
                        {
                            ObjEntityRequest.PolicyType = 0;
                        }
                        ObjEntityRequest.intConfirmStatus = 0;
                        // ObjEntityRequest.CusSupSrch = 1;
                        ddlGuaranteeStatus.ClearSelection();
                        ddlGuaranteeStatus.Items.FindByText("All").Selected = true;

                        if (ddlCurrency.SelectedItem.Value != "--SELECT CURRENCY--")
                        {
                            ObjEntityRequest.Currency = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
                        }
                    }
                    else
                    {
                        string strHidden = "";
                        strHidden = HiddenSearchField.Value;


                        string[] strSearchFields = strHidden.Split(',');
                        string strFromDate = strSearchFields[0];
                        string strToDate = strSearchFields[1];
                        string strGuaranteType = strSearchFields[2];
                        string strGuaranteMode = strSearchFields[3];
                        string strBiding = strSearchFields[4];
                        string strAwarded = strSearchFields[5];
                        string strddlCustSuplr = strSearchFields[6];
                        string EspireDate = strSearchFields[7];
                        string strCbxStatus = strSearchFields[8];
                        string strBankId = strSearchFields[9];
                        string strGuartSts = strSearchFields[10];
                        string strCusSup = strSearchFields[11];
                        string strInsurncPrvdr = strSearchFields[12];
                        string strInsurPolicySts = strSearchFields[13];
                        string strCurrency = strSearchFields[14];

                        if (strFromDate != null && strFromDate != "")
                        {

                            txtFromDate.Text = strFromDate;
                            ObjEntityRequest.OpenDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
                            //if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                            //{
                            //    ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                            //}
                        }
                        else
                        {
                            ObjEntityRequest.OpenDate = DateTime.MinValue;
                        }
                        if (strToDate != null && strToDate != "")
                        {

                            txtToDate.Text = strToDate;
                            //if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                            //{
                            //    ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                            //}
                            ObjEntityRequest.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
                        }
                        else
                        {
                            ObjEntityRequest.ToDate = DateTime.MinValue;
                        }
                        if (strBiding == "1")
                        {
                            radioBinding.Checked = true;
                            //if (ddlGuaranteCat.Items.FindByValue(strGuarantCat) != null)
                            //{
                            //    ddlGuaranteCat.Items.FindByValue(strGuarantCat).Selected = true;
                            //}
                            ObjEntityRequest.Biding = 1;
                        }
                        else if (strAwarded == "1")
                        {
                            radioAwdrd.Checked = true;
                            ObjEntityRequest.Awarded = 1;
                        }
                        else if (strBiding == "0" && strAwarded == "0")
                        {
                            ObjEntityRequest.Biding = 0;
                            ObjEntityRequest.Awarded = 0;
                        }

                        if (strGuaranteType != null && strGuaranteType != "")
                        {
                            if (ddlGuaranteeTyp.Items.FindByValue(strGuaranteType) != null)
                            {
                                ddlGuaranteeTyp.ClearSelection();
                                ddlGuaranteeTyp.Items.FindByValue(strGuaranteType).Selected = true;
                                ObjEntityRequest.GuarTypeId = Convert.ToInt32(strGuaranteType);
                            }
                        }
                        if (strGuaranteMode != null && strGuaranteMode != "")
                        {
                            if (ddlGuaranteeMde.Items.FindByValue(strGuaranteMode) != null)
                            {
                                if (ddlGuaranteeMde.SelectedItem.Value != "--SELECT GUARANTEE MODE--")
                                {
                                    ddlGuaranteeMde.ClearSelection();
                                    ddlGuaranteeMde.Items.FindByValue(strGuaranteMode).Selected = true;
                                    ObjEntityRequest.Guarantee_Method = Convert.ToInt32(strGuaranteMode);
                                }
                            }
                        }

                        if (strddlCustSuplr != null && strddlCustSuplr != "")
                        {
                            if (HiddenFieldRadioCusSupl.Value == "1")
                            {
                                if (ddlSuplCus.Items.FindByValue(strddlCustSuplr) != null)
                                {
                                    if (ddlSuplCus.SelectedItem.Value != "--SELECT--")
                                    {
                                        ddlSuplCus.ClearSelection();
                                        ddlSuplCus.Items.FindByValue(strddlCustSuplr).Selected = true;
                                        ObjEntityRequest.CusSuply = Convert.ToInt32(strddlCustSuplr);
                                    }
                                }
                            }
                            else
                            {
                                if (ddlSup.Items.FindByValue(strddlCustSuplr) != null)
                                {
                                    if (ddlSup.SelectedItem.Value != "--SELECT--")
                                    {
                                        ddlSup.ClearSelection();
                                        ddlSup.Items.FindByValue(strddlCustSuplr).Selected = true;
                                        ObjEntityRequest.CusSuply = Convert.ToInt32(strddlCustSuplr);

                                    }
                                }
                            }
                        }

                        if (EspireDate != null && EspireDate != "")
                        {

                            BankGurntExpire.Text = EspireDate;
                            ObjEntityRequest.ExpireDate = objCommon.textToDateTime(BankGurntExpire.Text.Trim());
                            //if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                            //{
                            //    ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                            //}
                        }
                        if (strBankId != null && strBankId != "")
                        {
                            if (ddlBankNm.Items.FindByValue(strBankId) != null)
                            {
                                if (ddlBankNm.SelectedItem.Value != "--SELECT BANK--")
                                {
                                    ddlBankNm.ClearSelection();
                                    ddlBankNm.Items.FindByValue(strBankId).Selected = true;
                                    ObjEntityRequest.BankId = Convert.ToInt32(strBankId);
                                }
                            }
                        }
                        if (strGuartSts != null && strGuartSts != "")
                        {
                            if (ddlGuaranteeStatus.Items.FindByValue(strGuartSts) != null)
                            {
                                ddlGuaranteeStatus.ClearSelection();

                                ddlGuaranteeStatus.Items.FindByValue(strGuartSts).Selected = true;
                                ObjEntityRequest.GuartStsSrch = Convert.ToInt32(strGuartSts);

                            }
                        }

                        if (strInsurPolicySts != null && strInsurPolicySts != "")
                        {
                            if (ddlPolicyType.Items.FindByValue(strInsurPolicySts) != null)
                            {
                                ddlPolicyType.ClearSelection();

                                ddlPolicyType.Items.FindByValue(strInsurPolicySts).Selected = true;
                                ObjEntityRequest.PolicyType = Convert.ToInt32(strInsurPolicySts);

                            }
                        }
                        if (strCbxStatus == "1")
                        {
                            cbxCnclStatus.Checked = true;
                        }
                        else
                        {
                            cbxCnclStatus.Checked = false;
                        }
                        ObjEntityRequest.Cancel_Status = Convert.ToInt32(strCbxStatus);

                        if (strInsurncPrvdr != null && strInsurncPrvdr != "")
                        {
                            if (ddlInsurncPrvdr.Items.FindByValue(strInsurncPrvdr) != null)
                            {
                                if (ddlInsurncPrvdr.SelectedItem.Value != "--SELECT INSURANCE PROVIDER--")
                                {
                                    ddlInsurncPrvdr.ClearSelection();
                                    ddlInsurncPrvdr.Items.FindByValue(strInsurncPrvdr).Selected = true;
                                    ObjEntityRequest.InsuranceProvider = Convert.ToInt32(strInsurncPrvdr);
                                }
                            }
                        }

                        if (strCurrency != null && strCurrency != "--SELECT CURRENCY--")
                        {
                            if (ddlCurrency.Items.FindByValue(strCurrency) != null)
                            {
                                ddlCurrency.ClearSelection();
                                ddlCurrency.Items.FindByValue(strCurrency).Selected = true;
                                ObjEntityRequest.Currency = Convert.ToInt32(strCurrency);
                            }
                        }

                    }
                    DataTable dtContract = new DataTable();
                    if (ObjEntityRequest.SuplOrClient != 3)
                        //    dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList(ObjEntityRequest);
                        dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList1(ObjEntityRequest);
                    string strHtm = ConvertDataTableToHTML(dtContract, intEnableModify, intEnableCancel, intEnableRecall, intEnableClose, intEnableRenew, intEnableConfirm);
                    string strPrintReport = ConvertDataTableForPrint(dtContract);
                    divPrintReport.InnerHtml = strPrintReport;
                    //Write to divReport
                    divReport.InnerHtml = strHtm;

                    if (Request.QueryString["InsUpd"] != null)
                    {
                        string strInsUpd = Request.QueryString["InsUpd"].ToString();
                        if (strInsUpd == "Ins")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                        }
                        else if (strInsUpd == "Upd")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                        }
                        else if (strInsUpd == "Cncl")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                        }
                        else if (strInsUpd == "Recl")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessRecall", "SuccessRecall();", true);
                        }
                        else if (strInsUpd == "StsCh")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessStatusChange", "SuccessStatusChange();", true);
                        }
                        else if (strInsUpd == "Cnfrm")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirm", "SuccessConfirm();", true);
                        }
                        else if (strInsUpd == "ReOpen")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReOpen", "SuccessReOpen();", true);
                        }
                        else if (strInsUpd == "Cls")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessClose", "SuccessClose();", true);
                        }
                        else if (strInsUpd == "CONF")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirm", "SuccessConfirm();", true);
                        }
                        else if (strInsUpd == "CONFCHK")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "StatusCheck", "StatusCheck();", true);
                        }
                    }
                }


                #region _INSRNC


                clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();
                clsBusinessLayerInsuranceMaster objBusinessInsurance = new clsBusinessLayerInsuranceMaster();


                if (Request.QueryString["Id_INSRNC"] != null)
                {//when Canceled

                    string strRandomMixedId = Request.QueryString["Id_INSRNC"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityInsurance.InsuranceId = Convert.ToInt32(strId);
                    objEntityInsurance.User_Id = intUserId;

                    ObjEntityRequest.D_Date = System.DateTime.Now;

                    if (dtCorpDetail.Rows.Count > 0)
                    {
                        string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                        if (CnclrsnMust == "0")
                        {
                            objEntityInsurance.Cancel_reason = objCommon.CancelReason();

                            objBusinessInsurance.CancelInsurance(objEntityInsurance);
                            if (HiddenSearchField.Value == "")
                            {
                                Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd_INSRNC=Cncl");
                            }
                            else
                            {
                                Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd_INSRNC=Cncl&Srch=" + this.HiddenSearchField.Value);
                            }

                        }
                        else
                        {
                            if (HiddenSearchField.Value == "")
                            {
                                ObjEntityRequest.OpenDate = DateTime.MinValue;
                                ObjEntityRequest.ToDate = DateTime.MinValue;
                                ObjEntityRequest.GuarTypeId = 0;
                                ObjEntityRequest.ExpireDate = DateTime.MinValue;
                                ObjEntityRequest.Cancel_Status = 0;
                                ObjEntityRequest.InsuranceProvider = 0;
                                ObjEntityRequest.GuartStsSrch = 1;
                            }
                            else
                            {
                                //string strHidden = "";
                                //strHidden = HiddenSearchField.Value;


                                //string[] strSearchFields = strHidden.Split(',');
                                //string strFromDate = strSearchFields[0];
                                //string strToDate = strSearchFields[1];
                                //string strInsuranceTyp = strSearchFields[2];
                                //string EspireDate = strSearchFields[3];
                                //string strCbxStatus = strSearchFields[4];
                                //string strInsurncPrvdr = strSearchFields[5];
                                //string strGuartSts = strSearchFields[6];

                                //if (strFromDate != null && strFromDate != "")
                                //{

                                //    txtFromDate.Text = strFromDate;
                                //    ObjEntityRequest.OpenDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
                                //}
                                //else
                                //{
                                //    ObjEntityRequest.OpenDate = DateTime.MinValue;
                                //}
                                //if (strToDate != null && strToDate != "")
                                //{
                                //    txtToDate.Text = strToDate;
                                //    ObjEntityRequest.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
                                //}
                                //else
                                //{
                                //    ObjEntityRequest.ToDate = DateTime.MinValue;
                                //}

                                //if (strInsuranceTyp != null && strInsuranceTyp != "")
                                //{
                                //    if (ddlGuaranteeTyp.Items.FindByValue(strInsuranceTyp) != null)
                                //    {
                                //        ddlGuaranteeTyp.ClearSelection();
                                //        ddlGuaranteeTyp.Items.FindByValue(strInsuranceTyp).Selected = true;
                                //        ObjEntityRequest.GuarTypeId = Convert.ToInt32(strInsuranceTyp);
                                //    }
                                //}

                                //if (EspireDate != null && EspireDate != "")
                                //{
                                //    BankGurntExpire.Text = EspireDate;
                                //    ObjEntityRequest.ExpireDate = objCommon.textToDateTime(BankGurntExpire.Text.Trim());
                                //}
                                //if (strInsurncPrvdr != null && strInsurncPrvdr != "")
                                //{
                                //    if (ddlInsurncPrvdr.Items.FindByValue(strInsurncPrvdr) != null)
                                //    {
                                //        if (ddlInsurncPrvdr.SelectedItem.Value != "--SELECT INSURANCE PROVIDER--")
                                //        {
                                //            ddlInsurncPrvdr.ClearSelection();
                                //            ddlInsurncPrvdr.Items.FindByValue(strInsurncPrvdr).Selected = true;
                                //            ObjEntityRequest.InsuranceProvider = Convert.ToInt32(strInsurncPrvdr);
                                //        }
                                //    }
                                //}
                                //if (strGuartSts != null && strGuartSts != "")
                                //{
                                //    if (ddlGuaranteeStatus.Items.FindByValue(strGuartSts) != null)
                                //    {
                                //        ddlGuaranteeStatus.ClearSelection();

                                //        ddlGuaranteeStatus.Items.FindByValue(strGuartSts).Selected = true;
                                //        ObjEntityRequest.GuartStsSrch = Convert.ToInt32(strGuartSts);

                                //    }
                                //}
                                //if (strCbxStatus == "1")
                                //{
                                //    cbxCnclStatus.Checked = true;
                                //}
                                //else
                                //{
                                //    cbxCnclStatus.Checked = false;
                                //}

                                //ObjEntityRequest.Cancel_Status = Convert.ToInt32(strCbxStatus);
                            }
                           
                            DataTable dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList1(ObjEntityRequest);
                            string strHtm = ConvertDataTableToHTML(dtContract, intEnableModify, intEnableCancel, intEnableRecall, intEnableClose, intEnableRenew, intEnableConfirm);
                            //Write to divReport
                            divReport.InnerHtml = strHtm;
                            string strPrintReport = ConvertDataTableForPrint(dtContract);
                            divPrintReport.InnerHtml = strPrintReport;
                            hiddenRsn_INSRNCid.Value = strId;

                        }

                    }
                }
                else if (Request.QueryString["ReId_INSRNC"] != null)
                {//when recalled
                    string strRandomMixedId = Request.QueryString["ReId_INSRNC"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityInsurance.InsuranceId = Convert.ToInt32(strId);

                    DataTable dtGurntNum = objBusinessInsurance.ReadInsuranceStatus(objEntityInsurance);

                    objEntityInsurance.User_Id = intUserId;
                    objEntityInsurance.InsuranceNo = dtGurntNum.Rows[0]["INSURANCE_NUMBER"].ToString();

                    string strGurntNo = "";
                    strGurntNo = objBusinessInsurance.CheckDupInsrncNo(objEntityInsurance);
                    if (strGurntNo == "" || strGurntNo == "0")
                    {
                        objBusinessInsurance.ReCallInsurance(objEntityInsurance);

                        if (HiddenSearchField.Value == "")
                        {
                            Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd_INSRNC=Recl");
                        }
                        else
                        {
                            Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd_INSRNC=Recl&Srch=" + this.HiddenSearchField.Value);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Duplication", "Duplication();", true);
                    }
                }
                else if (Request.QueryString["CONF_INSRNC"] != null)
                {//when confirmed
                    string strRandomMixedId = Request.QueryString["CONF_INSRNC"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityInsurance.InsuranceId = Convert.ToInt32(strId);
                    objEntityInsurance.D_Date = System.DateTime.Now;
                    objEntityInsurance.User_Id = intUserId;


                    DataTable GuarantStatus = objBusinessInsurance.ReadInsuranceStatus(objEntityInsurance);
                    string strchckStatus = "";
                    if (GuarantStatus.Rows.Count > 0)
                    {
                        strchckStatus = GuarantStatus.Rows[0]["INSURANCE_STATUS"].ToString();
                    }

                    if (strchckStatus != "2")
                    {
                        objBusinessInsurance.ConfirmInsurance(objEntityInsurance);


                        if (HiddenSearchField.Value != "")
                        {
                            Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd_INSRNC=CONF&Srch=" + this.HiddenSearchField.Value);
                        }
                        else
                        {
                            Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd_INSRNC=CONF");
                        }
                    }
                    else
                    {
                        Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd_INSRNC=CONFCHK");
                    }

                    if (HiddenSearchField.Value == "")
                    {
                        ObjEntityRequest.OpenDate = DateTime.MinValue;
                        ObjEntityRequest.ToDate = DateTime.MinValue;
                        ObjEntityRequest.GuarTypeId = 0;
                        ObjEntityRequest.Guarantee_Method = 0;
                        ObjEntityRequest.Biding = 0;
                        ObjEntityRequest.Awarded = 0;
                        ObjEntityRequest.CusSuply = 0;
                        ObjEntityRequest.ExpireDate = DateTime.MinValue;
                        ObjEntityRequest.Cancel_Status = 0;
                        ObjEntityRequest.BankId = 0;
                        ObjEntityRequest.GuartStsSrch = 1;
                        ObjEntityRequest.CusSupSrch = 1;
                        ObjEntityRequest.InsuranceProvider = 0;
                        if (ddlCurrency.SelectedItem.Value != "--SELECT CURRENCY--")
                        {
                            ObjEntityRequest.Currency = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
                        }
                    }
                    else
                    {
                        string strHidden = "";
                        strHidden = HiddenSearchField.Value;


                        string[] strSearchFields = strHidden.Split(',');
                        string strFromDate = strSearchFields[0];
                        string strToDate = strSearchFields[1];
                        string strGuaranteType = strSearchFields[2];
                        string strGuaranteMode = strSearchFields[3];
                        string strBiding = strSearchFields[4];
                        string strAwarded = strSearchFields[5];
                        string strddlCustSuplr = strSearchFields[6];
                        string EspireDate = strSearchFields[7];
                        string strCbxStatus = strSearchFields[8];
                        string strBankId = strSearchFields[9];
                        string strGuartSts = strSearchFields[10];
                        string strCusSup = strSearchFields[11];
                        string strInsurncPrvdr = strSearchFields[12];
                        string strInsurPolicySts = strSearchFields[13];
                        string strCurrency = strSearchFields[14];

                        if (strFromDate != null && strFromDate != "")
                        {

                            txtFromDate.Text = strFromDate;
                            ObjEntityRequest.OpenDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
                            //if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                            //{
                            //    ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                            //}
                        }
                        else
                        {
                            ObjEntityRequest.OpenDate = DateTime.MinValue;
                        }
                        if (strToDate != null && strToDate != "")
                        {

                            txtToDate.Text = strToDate;
                            //if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                            //{
                            //    ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                            //}
                            ObjEntityRequest.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
                        }
                        else
                        {
                            ObjEntityRequest.ToDate = DateTime.MinValue;
                        }
                        if (strBiding == "1")
                        {
                            radioBinding.Checked = true;
                            //if (ddlGuaranteCat.Items.FindByValue(strGuarantCat) != null)
                            //{
                            //    ddlGuaranteCat.Items.FindByValue(strGuarantCat).Selected = true;
                            //}
                            ObjEntityRequest.Biding = 1;
                        }
                        else if (strAwarded == "1")
                        {
                            radioAwdrd.Checked = true;
                            ObjEntityRequest.Awarded = 1;
                        }
                        else if (strBiding == "0" && strAwarded == "0")
                        {
                            ObjEntityRequest.Biding = 0;
                            ObjEntityRequest.Awarded = 0;
                        }

                        if (strGuaranteType != null && strGuaranteType != "")
                        {
                            if (ddlGuaranteeTyp.Items.FindByValue(strGuaranteType) != null)
                            {
                                ddlGuaranteeTyp.ClearSelection();
                                ddlGuaranteeTyp.Items.FindByValue(strGuaranteType).Selected = true;
                                ObjEntityRequest.GuarTypeId = Convert.ToInt32(strGuaranteType);
                            }
                        }
                        if (strGuaranteMode != null && strGuaranteMode != "")
                        {
                            if (ddlGuaranteeMde.Items.FindByValue(strGuaranteMode) != null)
                            {
                                if (ddlGuaranteeMde.SelectedItem.Value != "--SELECT GUARANTEE MODE--")
                                {
                                    ddlGuaranteeMde.ClearSelection();
                                    ddlGuaranteeMde.Items.FindByValue(strGuaranteMode).Selected = true;
                                    ObjEntityRequest.Guarantee_Method = Convert.ToInt32(strGuaranteMode);
                                }
                            }
                        }

                        if (strddlCustSuplr != null && strddlCustSuplr != "")
                        {
                            if (HiddenFieldRadioCusSupl.Value == "1")
                            {
                                if (ddlSuplCus.Items.FindByValue(strddlCustSuplr) != null)
                                {
                                    if (ddlSuplCus.SelectedItem.Value != "--SELECT--")
                                    {
                                        ddlSuplCus.ClearSelection();
                                        ddlSuplCus.Items.FindByValue(strddlCustSuplr).Selected = true;
                                        ObjEntityRequest.CusSuply = Convert.ToInt32(strddlCustSuplr);
                                    }
                                }
                            }
                            else
                            {
                                if (ddlSup.Items.FindByValue(strddlCustSuplr) != null)
                                {
                                    if (ddlSup.SelectedItem.Value != "--SELECT--")
                                    {
                                        ddlSup.ClearSelection();
                                        ddlSup.Items.FindByValue(strddlCustSuplr).Selected = true;
                                        ObjEntityRequest.CusSuply = Convert.ToInt32(strddlCustSuplr);

                                    }
                                }
                            }
                        }

                        if (EspireDate != null && EspireDate != "")
                        {

                            BankGurntExpire.Text = EspireDate;
                            ObjEntityRequest.ExpireDate = objCommon.textToDateTime(BankGurntExpire.Text.Trim());
                            //if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                            //{
                            //    ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                            //}
                        }
                        if (strBankId != null && strBankId != "")
                        {
                            if (ddlBankNm.Items.FindByValue(strBankId) != null)
                            {
                                if (ddlBankNm.SelectedItem.Value != "--SELECT BANK--")
                                {
                                    ddlBankNm.ClearSelection();
                                    ddlBankNm.Items.FindByValue(strBankId).Selected = true;
                                    ObjEntityRequest.BankId = Convert.ToInt32(strBankId);
                                }
                            }
                        }
                        if (strGuartSts != null && strGuartSts != "")
                        {
                            if (ddlGuaranteeStatus.Items.FindByValue(strGuartSts) != null)
                            {
                                ddlGuaranteeStatus.ClearSelection();

                                ddlGuaranteeStatus.Items.FindByValue(strGuartSts).Selected = true;
                                ObjEntityRequest.GuartStsSrch = Convert.ToInt32(strGuartSts);

                            }
                        }
                        if (strInsurPolicySts != null && strInsurPolicySts != "")
                        {
                            if (ddlPolicyType.Items.FindByValue(strInsurPolicySts) != null)
                            {
                                ddlPolicyType.ClearSelection();

                                ddlPolicyType.Items.FindByValue(strInsurPolicySts).Selected = true;
                                ObjEntityRequest.PolicyType = Convert.ToInt32(strInsurPolicySts);

                            }
                        }

                        if (strCbxStatus == "1")
                        {
                            cbxCnclStatus.Checked = true;
                        }
                        else
                        {
                            cbxCnclStatus.Checked = false;
                        }
                        ObjEntityRequest.Cancel_Status = Convert.ToInt32(strCbxStatus);

                        if (strCusSup != null && strCusSup != "")
                        {
                            if (ddlCustSuplrsrch.Items.FindByValue(strCusSup) != null)
                            {
                                ddlCustSuplrsrch.ClearSelection();

                                ddlCustSuplrsrch.Items.FindByValue(strCusSup).Selected = true;
                                ObjEntityRequest.CusSupSrch = Convert.ToInt32(strCusSup);
                            }
                        }
                        if (strInsurncPrvdr != null && strInsurncPrvdr != "")
                        {
                            if (ddlInsurncPrvdr.Items.FindByValue(strInsurncPrvdr) != null)
                            {
                                if (ddlInsurncPrvdr.SelectedItem.Value != "--SELECT INSURANCE PROVIDER--")
                                {
                                    ddlInsurncPrvdr.ClearSelection();
                                    ddlInsurncPrvdr.Items.FindByValue(strInsurncPrvdr).Selected = true;
                                    ObjEntityRequest.InsuranceProvider = Convert.ToInt32(strInsurncPrvdr);
                                }
                            }
                        }

                        if (strCurrency != null && strCurrency != "")
                        {
                            if (ddlCurrency.Items.FindByValue(strCurrency) != null)
                            {
                                ddlCurrency.ClearSelection();
                                ddlCurrency.Items.FindByValue(strCurrency).Selected = true;
                                ObjEntityRequest.Currency = Convert.ToInt32(strCurrency);
                            }
                        }

                    }
                    DataTable dtContract = new DataTable();
                    if (ObjEntityRequest.SuplOrClient != 3)
                        //    dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList(ObjEntityRequest);
                        dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList1(ObjEntityRequest);
                    string strHtm = ConvertDataTableToHTML(dtContract, intEnableModify, intEnableCancel, intEnableRecall, intEnableClose, intEnableRenew, intEnableConfirm);
                    string strPrintReport = ConvertDataTableForPrint(dtContract);
                    divPrintReport.InnerHtml = strPrintReport;
                    //Write to divReport
                    divReport.InnerHtml = strHtm;

                }
                else if (Request.QueryString["Close_INSRNC"] != null)
                {//when closed

                    string strRandomMixedId = Request.QueryString["Close_INSRNC"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                   // ObjEntityRequest.InsuranceId = Convert.ToInt32(strId);
                    ObjEntityRequest.User_Id = intUserId;

                    ObjEntityRequest.D_Date = System.DateTime.Now;



                    if (HiddenSearchField.Value == "")
                    {
                        ObjEntityRequest.OpenDate = DateTime.MinValue;
                        ObjEntityRequest.ToDate = DateTime.MinValue;
                        ObjEntityRequest.GuarTypeId = 0;
                        ObjEntityRequest.ExpireDate = DateTime.MinValue;
                        ObjEntityRequest.Cancel_Status = 0;
                        ObjEntityRequest.InsuranceProvider = 0;
                        ObjEntityRequest.GuartStsSrch = 1;
                    }
                    else
                    {
                        //string strHidden = "";
                        //strHidden = HiddenSearchField.Value;


                        //string[] strSearchFields = strHidden.Split(',');
                        //string strFromDate = strSearchFields[0];
                        //string strToDate = strSearchFields[1];
                        //string strInsuranceTyp = strSearchFields[2];
                        //string EspireDate = strSearchFields[3];
                        //string strCbxStatus = strSearchFields[4];
                        //string strInsurncPrvdr = strSearchFields[5];
                        //string strGuartSts = strSearchFields[6];

                        //if (strFromDate != null && strFromDate != "")
                        //{
                        //    txtFromDate.Text = strFromDate;
                        //    ObjEntityRequest.OpenDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
                        //}
                        //else
                        //{
                        //    ObjEntityRequest.OpenDate = DateTime.MinValue;
                        //}
                        //if (strToDate != null && strToDate != "")
                        //{
                        //    txtToDate.Text = strToDate;
                        //    ObjEntityRequest.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
                        //}
                        //else
                        //{
                        //    ObjEntityRequest.ToDate = DateTime.MinValue;
                        //}

                        //if (strInsuranceTyp != null && strInsuranceTyp != "")
                        //{
                        //    if (ddlGuaranteeTyp.Items.FindByValue(strInsuranceTyp) != null)
                        //    {
                        //        ddlGuaranteeTyp.ClearSelection();
                        //        ddlGuaranteeTyp.Items.FindByValue(strInsuranceTyp).Selected = true;
                        //        ObjEntityRequest.GuarTypeId = Convert.ToInt32(strInsuranceTyp);
                        //    }
                        //}

                        //if (EspireDate != null && EspireDate != "")
                        //{
                        //    ddlGuaranteeTyp.Text = EspireDate;
                        //    ObjEntityRequest.ExpireDate = objCommon.textToDateTime(ddlGuaranteeTyp.Text.Trim());
                        //}
                        //if (strInsurncPrvdr != null && strInsurncPrvdr != "")
                        //{
                        //    if (ddlInsurncPrvdr.Items.FindByValue(strInsurncPrvdr) != null)
                        //    {
                        //        if (ddlInsurncPrvdr.SelectedItem.Value != "--SELECT INSURANCE PROVIDER--")
                        //        {
                        //            ddlInsurncPrvdr.ClearSelection();
                        //            ddlInsurncPrvdr.Items.FindByValue(strInsurncPrvdr).Selected = true;
                        //            ObjEntityRequest.InsuranceProvider = Convert.ToInt32(strInsurncPrvdr);
                        //        }
                        //    }
                        //}
                        //if (strGuartSts != null && strGuartSts != "")
                        //{
                        //    if (ddlGuaranteeStatus.Items.FindByValue(strGuartSts) != null)
                        //    {
                        //        ddlGuaranteeStatus.ClearSelection();

                        //        ddlGuaranteeStatus.Items.FindByValue(strGuartSts).Selected = true;
                        //        ObjEntityRequest.GuartStsSrch = Convert.ToInt32(strGuartSts);

                        //    }
                        //}

                        //if (strCbxStatus == "1")
                        //{
                        //    cbxCnclStatus.Checked = true;
                        //}
                        //else
                        //{
                        //    cbxCnclStatus.Checked = false;
                        //}

                        //ObjEntityRequest.Cancel_Status = Convert.ToInt32(strCbxStatus);
                    }

                   // DataTable dtInsurance = objBusinessInsurance.ReadInsuranceList(ObjEntityRequest);
                    DataTable dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList1(ObjEntityRequest);

                    string strHtm = ConvertDataTableToHTML(dtContract, intEnableModify, intEnableCancel, intEnableRecall, intEnableClose, intEnableRenew, intEnableConfirm);
                    //Write to divReport
                    divReport.InnerHtml = strHtm;

                    string strPrintReport = ConvertDataTableForPrint(dtContract);
                    divPrintReport.InnerHtml = strPrintReport;

                    hiddenRsn_INSRNCidclose.Value = strId;
                }
                    //evm-0023
                else if (Request.QueryString["default_INSRNC"] != null)
                {
                    hiddenDefaultDashboard.Value = "1";

                    ObjEntityRequest.PolicyType = 2;
                    ddlPolicyType.ClearSelection();
                    ddlPolicyType.Items.FindByValue("2").Selected = true;

                    ddlCurrency.ClearSelection();
                    ddlCurrency.Items.FindByValue("--SELECT CURRENCY--").Selected = true;
                    ObjEntityRequest.Currency = 0;

                    DateTime date = DateTime.Today;

                    ObjEntityRequest.InsuranceProvider = 0;
                    ObjEntityRequest.OpenDate = DateTime.MinValue;
                    ObjEntityRequest.ToDate = DateTime.MinValue;
                    ObjEntityRequest.ExpireDate = DateTime.MinValue;
                    ObjEntityRequest.GuarTypeId = 0;
                    ObjEntityRequest.Cancel_Status = 0;
                    ObjEntityRequest.GuartStsSrch = 0;

                    if (Request.QueryString["default_INSRNC"] == "new")
                    {//new status
                        pHeader.InnerHtml = "Insurances under open status";
                        ObjEntityRequest.GuartStsSrch = 1;
                    }
                    else if (Request.QueryString["default_INSRNC"] == "3months")
                    {//expiry date within 3 months
                        pHeader.InnerHtml = "Insurances Expiring in 3 Months";
                        ObjEntityRequest.FromDashboard = 1;
                        ObjEntityRequest.GuartStsSrch = 0;
                        ddlGuaranteeStatus.ClearSelection();
                        ddlGuaranteeStatus.Items.FindByText("All").Selected = true;
                        if (Request.QueryString["InsUpd"] != null)
                        {
                            string strInsUpd = Request.QueryString["InsUpd_INSRNC"].ToString();
                            if (strInsUpd == "Upd")
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation_insr", "SuccessUpdation_insr();", true);
                            }
                        }
                    }
                    else if (Request.QueryString["default_INSRNC"] == "expired")
                    {//expiry date less than current date
                        pHeader.InnerHtml = "Expired insurances";
                        ObjEntityRequest.FromDashboard = 2;
                        ObjEntityRequest.GuartStsSrch = 0;
                        ddlGuaranteeStatus.ClearSelection();
                        ddlGuaranteeStatus.Items.FindByText("All").Selected = true;
                        if (Request.QueryString["InsUpd_INSRNC"] != null)
                        {
                            string strInsUpd = Request.QueryString["InsUpd_INSRNC"].ToString();
                            if (strInsUpd == "Upd")
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation_insr", "SuccessUpdation_insr();", true);
                            }
                        }
                    }
                    else if (Request.QueryString["default_INSRNC"] == "CurrntlyRunng")
                    {//expiry date greater than current date and null and confirmed
                        pHeader.InnerHtml = "Currently running insurance";
                        ObjEntityRequest.FromDashboard = 4;
                        ObjEntityRequest.GuartStsSrch = 2;
                        ddlGuaranteeStatus.ClearSelection();
                        ddlGuaranteeStatus.Items.FindByText("Confirmed").Selected = true;

                        //  ExpiryDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                    }

                   // DataTable dtInsurance = objBusinessInsurance.ReadInsuranceList(ObjEntityRequest);
                    DataTable dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList1(ObjEntityRequest);

                    int ROWCT = dtContract.Rows.Count;
                    string strHtm = ConvertDataTableToHTML(dtContract, intEnableModify, intEnableCancel, intEnableRecall, intEnableClose, intEnableRenew, intEnableConfirm);
                    //Write to divReport
                    divReport.InnerHtml = strHtm;
                    string strPrintReport = ConvertDataTableForPrint(dtContract);
                    divPrintReport.InnerHtml = strPrintReport;


                    
                }


                #endregion


            }

            if (Request.QueryString["InsUpd_INSRNC"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd_INSRNC"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation_insr", "SuccessConfirmation_insr();", true);
                }
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation_insr", "SuccessUpdation_insr();", true);
                }
                else if (strInsUpd == "Cncl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation_insr", "SuccessCancelation_insr();", true);
                }
                else if (strInsUpd == "Recl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessRecall_insr", "SuccessRecall_insr();", true);
                }
                else if (strInsUpd == "StsCh")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessStatusChange_insr", "SuccessStatusChange_insr();", true);
                }
                else if (strInsUpd == "Cnfrm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirm_insr", "SuccessConfirm_insr();", true);
                }
                else if (strInsUpd == "ReOpen")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReOpen_insr", "SuccessReOpen_insr();", true);
                }
                else if (strInsUpd == "Cls")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessClose_insr", "SuccessClose_insr();", true);
                }
                else if (strInsUpd == "CONF")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirm_insr", "SuccessConfirm_insr();", true);
                }
                else if (strInsUpd == "CONFCHK")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "StatusCheck_insr", "StatusCheck_insr();", true);
                }
            }
        }


    }


    public void guaranteeModeLoad()
    {
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
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
        DataTable dtGuarantMod = ObjBussinessBankGuarnt.GuaranteeModeClient(ObjEntityRequest);
        if (dtGuarantMod.Rows.Count > 0)
        {
            ddlGuaranteeMde.DataSource = dtGuarantMod;
            ddlGuaranteeMde.DataTextField = "GUANTCAT_NAME";
            ddlGuaranteeMde.DataValueField = "GUANTCAT_ID";
            ddlGuaranteeMde.DataBind();

        }

        ddlGuaranteeMde.Items.Insert(0, "--SELECT GUARANTEE MODE--");
    }
    public void BankLoad()
    {
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
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
        DataTable dtSubConrt = ObjBussinessBankGuarnt.ReadBankLoad(ObjEntityRequest);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlBankNm.DataSource = dtSubConrt;
            ddlBankNm.DataTextField = "BANK_NAME";
            ddlBankNm.DataValueField = "BANK_ID";
            ddlBankNm.DataBind();


        }

        ddlBankNm.Items.Insert(0, "--SELECT BANK--");
    }
    public void SuplierLoad()
    {
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
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
        DataTable dtSubConrt = ObjBussinessBankGuarnt.ReadSuplierLoad(ObjEntityRequest);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlSup.DataSource = dtSubConrt;
            ddlSup.DataTextField = "CSTMR_NAME";
            ddlSup.DataValueField = "CSTMR_ID";
            ddlSup.DataBind();


        }

        ddlSup.Items.Insert(0, "--SELECT--");
    }

    public void CustomerLoad()
    {
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
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
        DataTable dtSubConrt = ObjBussinessBankGuarnt.ReadCustomerLoad(ObjEntityRequest);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlSuplCus.DataSource = dtSubConrt;
            ddlSuplCus.DataTextField = "CSTMR_NAME";
            ddlSuplCus.DataValueField = "CSTMR_ID";
            ddlSuplCus.DataBind();


        }

        ddlSuplCus.Items.Insert(0, "--SELECT--");
    }

    public void PolicyNumberLoad()
    {
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
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
        string policy = "";
        policy = ddlPolicyType.SelectedItem.Text;
        if (policy != "")
        {
            if (policy == "--Select--")
            {
                ObjEntityRequest.PolicyType = 0;
            }
            else if (policy == "Bank Guarantee")
            {
                ObjEntityRequest.PolicyType = 1;
            }
            else if (policy == "Insurance")
            {
                ObjEntityRequest.PolicyType = 2;
            }
        }

        DataTable dtSubConrt = ObjBussinessBankGuarnt.ReadPolicyNumLoad(ObjEntityRequest);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlPolicyNum.Items.Clear();
            ddlPolicyNum.DataSource = dtSubConrt;
            ddlPolicyNum.DataTextField = "POLICYNUMBER";
            ddlPolicyNum.DataValueField = "POLICYID";
            ddlPolicyNum.DataBind();
        }
        //// start EVM-0031 
        ddlPolicyNum.Items.Insert(0, "--SELECT POLICY NUMBER--");
        //// end EVM-0031
    }

    public void LoadInsuranceProvider()
    {
        clsBusinessLayerInsuranceMaster objBusinessInsurance = new clsBusinessLayerInsuranceMaster();
        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityInsurance.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtInsurancePrvdrs = objBusinessInsurance.ReadInsuranceProviders(objEntityInsurance);
        if (dtInsurancePrvdrs.Rows.Count > 0)
        {
            ddlInsurncPrvdr.Items.Clear();
            ddlInsurncPrvdr.DataSource = dtInsurancePrvdrs;
            ddlInsurncPrvdr.DataTextField = "INSURPRVDR_NAME";
            ddlInsurncPrvdr.DataValueField = "INSURPRVDR_ID";
            ddlInsurncPrvdr.DataBind();
        }
        ddlInsurncPrvdr.Items.Insert(0, "--SELECT INSURANCE PROVIDER--");
    }

    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intEnableRecall, int intEnableClose, int intEnableRenew, int intEnableConfirm)
    {
        int first = Convert.ToInt32(hiddenPrevious.Value);
        int intReCallForTAble = 0;

        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        if (hiddenDfltCurrencyMstrId.Value != "")
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        }

        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        DateTime DateCurrent = objBusiness.LoadCurrentDate();

        string policyTyp = "", policyopenlimtd = "";
        if (ddlPolicyType.SelectedItem.Value == "0")
        {
            policyTyp = "POLICY NUMBER";
            policyopenlimtd = "POLICY CATEGORY";
            divTitle.InnerHtml = "Policy";
        }
        else if (ddlPolicyType.SelectedItem.Value == "1")
        {
            policyTyp = "GUARANTEE NUMBER";
            policyopenlimtd = "GUARANTEE TYPE";
            divTitle.InnerHtml = "Bank Guarantee";
        }
        else if (ddlPolicyType.SelectedItem.Value == "2")
        {
            policyTyp = "INSURANCE NUMBER";
            policyopenlimtd = "INSURANCE CATEGORY";
            divTitle.InnerHtml = "Insurance";
        }

        hiddenPolicyType.Value = ddlPolicyType.SelectedItem.Value;

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%; word-wrap:break-word; text-align: center;\">" + policyTyp + "</th>";
            }
                
            else if (intColumnHeaderCount == 3)
            {
                if (ddlPolicyType.SelectedItem.Value == "2")
                {
                    strHtml += "<th class=\"thT\" style=\"width:8%; word-wrap:break-word; text-align: center;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:12%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">" + policyopenlimtd + "</th>";
            }
            else if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 8)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: right; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 9)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
        }



        if (cbxCnclStatus.Checked == false)
        {
            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                //edit

                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT</th>";


                //confirm
                if (intEnableConfirm == 1)
                {
                    if (ddlGuaranteeStatus.SelectedItem.Text == "All" || ddlGuaranteeStatus.SelectedItem.Text == "New")
                    {
                        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">CONFIRM</th>";
                    }
                }
            }
        }
        else
        {
            intReCallForTAble = 1;

            //cancel
            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">VIEW</th>";
            }
        }

        if (intReCallForTAble == 0)
        {
            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">CANCEL</th>";
            }
        }
        if (intReCallForTAble == 1)
        {
            if (intEnableRecall == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">RECALL</th>";
            }
        }

        if (intReCallForTAble == 0)
        {
            if (intEnableClose == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">CLOSE</th>";
            }
        }

        if (intReCallForTAble == 0)
        {
            if (intEnableRenew == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">RENEW</th>";
            }
        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        strHtml += "<tbody>";
         if (dt.Rows.Count > 0)
        {

            var result = from tab in dt.AsEnumerable()
                         group tab by tab["CURRENCY"]
                             into groupDt
                             select new
                             {
                                 Group = groupDt.Key,
                                 Sum = groupDt.Sum((r) => decimal.Parse(r["AMOUNT"].ToString()))
                             };

        for (int intRowBodyCount = first; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            int intExpiredSts = 0;
            int intMemoryBytes = System.Text.ASCIIEncoding.Unicode.GetByteCount(strHtml);

            if (hiddenTotalRowCount.Value == "")
            {
                if (hiddenMemorySize.Value != "")
                {
                    if (intMemoryBytes >= Convert.ToInt64(hiddenMemorySize.Value))
                    {
                        hiddenTotalRowCount.Value = intRowBodyCount.ToString();
                        hiddenNext.Value = hiddenTotalRowCount.Value;
                        btnNext.Enabled = true;
                        break;
                    }
                    else
                    {
                        int intConfirmed = 0, intClosed = 0, intRenew = 0, intnew = 0;
                        int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CNCL_USR_ID"].ToString());
                        int intCancTransaction = 0;
                        string InsrncStatus = dt.Rows[intRowBodyCount]["STATUS"].ToString();

                        if (InsrncStatus == "1")
                        {
                            intnew = 1;
                        }
                        if (InsrncStatus == "2")
                        {
                            intConfirmed = 1;
                        }
                        if (InsrncStatus == "3")
                        {
                            intRenew = 1;
                        }
                        if (InsrncStatus == "4")
                        {
                            intClosed = 1;
                        }

                        strHtml += "<tr>";


                        for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                        {
                            if (intColumnBodyCount == 1)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            else if (intColumnBodyCount == 2)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word; text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            else if (intColumnBodyCount == 3)
                            {
                                if (ddlPolicyType.SelectedItem.Value == "2")
                                {
                                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                                }
                            }
                            else if (intColumnBodyCount == 4)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            else if (intColumnBodyCount == 5)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            else if (intColumnBodyCount == 6)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            else if (intColumnBodyCount == 7)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            else if (intColumnBodyCount == 8)
                            {
                                string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                                string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);

                                strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + strNetAmountWithComma.ToString() + "</td>";

                            }
                            else if (intColumnBodyCount == 9)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                                //EVM-0027
                                HiddenCurrency.Value = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                                //END
                            }
                        }

                        string strId = dt.Rows[intRowBodyCount][0].ToString();
                        int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                        string stridLength = intIdLength.ToString("00");
                        string Id = stridLength + strId + strRandom;


                        if (dt.Rows[intRowBodyCount]["policytyp"].ToString() == "1")
                        {

                            string strQueryStr = "";
                            if (Request.QueryString["default"] != null)
                            {
                                if (Request.QueryString["default"] == "new")
                                {
                                    strQueryStr = "&default=new";
                                }
                                else if (Request.QueryString["default"] == "3months")
                                {
                                    strQueryStr = "&default=3months";
                                }
                                else if (Request.QueryString["default"] == "expired")
                                {
                                    strQueryStr = "&default=expired";
                                }
                                else if (Request.QueryString["default"] == "CurrntlyRunng")
                                {
                                    strQueryStr = "&default=CurrntlyRunng";
                                }
                            }

                            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                            {
                                //edit

                                if (intClosed == 0)
                                {
                                    if (intRenew == 0)
                                    {
                                        if (intConfirmed == 0)
                                        {
                                            if (intCnclUsrId == 0)
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"Edit\"   onclick='return getdetails(this.href);' " +
                                                      " href=\"gen_Bank_Guarantee.aspx?Id=" + Id + strQueryStr + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                                            }
                                            else
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"View\"  onclick='return getdetails(this.href);' " +
                                                 " href=\"gen_Bank_Guarantee.aspx?ViewId=" + Id + strQueryStr + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' />  " + "</a> </td>";
                                            }
                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"View\"  onclick='return getdetails(this.href);' " +
                                                     " href=\"gen_Bank_Guarantee.aspx?ViewId=" + Id + strQueryStr + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' />  " + "</a> </td>";
                                        }
                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"View\"  onclick='return getdetails(this.href);' " +
                                                 " href=\"gen_Bank_Guarantee.aspx?ViewId=" + Id + strQueryStr + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' />  " + "</a> </td>";
                                    }
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"View\"  onclick='return getdetails(this.href);' " +
                                                     " href=\"gen_Bank_Guarantee.aspx?ViewId=" + Id + strQueryStr + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' />  " + "</a> </td>";
                                }

                                //confirm

                                if (intCnclUsrId == 0)
                                {
                                    if (intEnableConfirm == 1)
                                    {
                                        if (intnew == 1)
                                        {
                                            if (HiddenSearchField.Value == "")
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align:center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left:1% ;\" title=\"Confirm\"    onclick='return ConfirmGtee(this.href," + intExpiredSts + ");' " +
                                                                  " href=\"gen_Bank_Guarantee_List.aspx?CONF=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/confirm.png' /> " + "</a> </td>";
                                            }
                                            else
                                            {

                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align:center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left:1% ;\" title=\"Confirm\"    onclick='return ConfirmGtee(this.href," + intExpiredSts + ");' " +
                                                                 " href=\"gen_Bank_Guarantee_List.aspx?CONF=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  style=\"\" src='/Images/Icons/confirm.png' /> " + "</a> </td>";
                                            }
                                        }
                                        else if (ddlGuaranteeStatus.SelectedItem.Text == "All")
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align:center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:0.2;margin-top:-1%; margin-left:1% ; \" title=\"Confirm\">" + "<img  style=\"opacity: 1;cursor: pointer;\" src='/Images/Icons/confirm.png' /> " + "</a> </td>";
                                        }
                                    }
                                }
                            }

                            //cancel
                            if (intReCallForTAble == 0)
                            {
                                if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                                {
                                    if (intCnclUsrId == 0)
                                    {
                                        if (intRenew == 0)
                                        {
                                            if (intClosed == 0)
                                            {
                                                if (intCancTransaction == 0)
                                                {
                                                    if (intConfirmed == 0)
                                                    {
                                                        if (HiddenSearchField.Value == "")
                                                        {
                                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%;margin-left:1%; \"  title=\"Cancel\"  onclick='return CancelAlert(this.href);' " +
                                                             " href=\"gen_Bank_Guarantee_List.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                                        }
                                                        else
                                                        {
                                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%;margin-left:1%; \"  title=\"Cancel\"  onclick='return CancelAlert(this.href);' " +
                                                             " href=\"gen_Bank_Guarantee_List.aspx?Id=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >"
                                                                 + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                                    }
                                                }
                                                else
                                                {
                                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left:1%;\" onclick='return CancelNotPossible();' >"
                                                            + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                                }
                                            }
                                            else
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  style=\"opacity:0.2;margin-top:-1%; margin-left:1%;\"  >"
                                                             + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                            }
                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  style=\"opacity:0.2;margin-top:-1%; margin-left:1%;\"  >"
                                                         + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                        }
                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                                    }
                                }
                            }

                            if (intReCallForTAble == 1)
                            {
                                if (intEnableRecall == 1)
                                {
                                    if (intCnclUsrId == 0)
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                                    }
                                    else
                                    {
                                        if (HiddenSearchField.Value == "")
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a style=\"z-index: 99;opacity:1;margin-top:-1%;margin-left: 1%; \" class=\"tooltip\" title=\"Recall\"  onclick='return ReCallAlert(this.href);' " +
                                             " href=\"gen_Bank_Guarantee_List.aspx?ReId=" + Id + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left: 1%;\" title=\"Recall\"   onclick='return ReCallAlert(this.href);' " +
                                             " href=\"gen_Bank_Guarantee_List.aspx?ReId=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                                        }


                                    }
                                }
                            }

                            if (intEnableClose == 1)
                            {
                                if (intReCallForTAble == 0)
                                {
                                    if (intClosed == 0)
                                    {
                                        if (intnew == 0)
                                        {
                                            if (HiddenSearchField.Value == "")
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left: .5%;\"  title=\"Close\"  onclick='return ConfirmClose(this.href);' " +
                                                                 " href=\"gen_Bank_Guarantee_List.aspx?Close=" + Id + "\">" + "<img  src='/Images/Icons/close.png' /> " + "</a> </td>";
                                            }
                                            else
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left: .5%;\"  title=\"Close\"  onclick='return ConfirmClose(this.href);' " +
                                                               " href=\"gen_Bank_Guarantee_List.aspx?Close=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/close.png' /> " + "</a> </td>";
                                            }
                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a    >"
                                                                       + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/close.png' /> " + "</a> </td>";
                                        }
                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a    >"
                                                                    + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/close.png' /> " + "</a> </td>";
                                    }
                                }
                            }

                            if (intEnableRenew == 1)
                            {
                                if (intReCallForTAble == 0)
                                {
                                    if (intCnclUsrId == 0)
                                    {
                                        if (intRenew == 1)
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%;margin-left:1%; \"  title=\"Renew\"   " +
                                                                    " href=\"gen_Bank_Guarantee.aspx?Renew=" + Id + "\">" + "<img  src='/Images/Icons/Renewal.png'/> " + "</a> </td>";
                                        }
                                        else
                                        {
                                            if (intConfirmed == 1)
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%;margin-left:1%; \"  title=\"Renew\"   " +
                                                                    " href=\"gen_Bank_Guarantee.aspx?Renew=" + Id + "\">" + "<img  src='/Images/Icons/Renewal.png'/> " + "</a> </td>";
                                            }
                                            else
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a     style=\"margin-left:10%; opacity: 0;\" >"
                                                                            + "<img style=\"opacity: 0; \" src='/Images/Icons/Renew.png' /> " + "</a> </td>";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {

                            string strQueryStr = "";
                            if (Request.QueryString["default_INSRNC"] != null)
                            {
                                if (Request.QueryString["default_INSRNC"] == "new")
                                {
                                    strQueryStr = "&default_INSRNC=new";
                                }
                                else if (Request.QueryString["default_INSRNC"] == "3months")
                                {
                                    strQueryStr = "&default_INSRNC=3months";
                                }
                                else if (Request.QueryString["default_INSRNC"] == "expired")
                                {
                                    strQueryStr = "&default_INSRNC=expired";
                                }
                                else if (Request.QueryString["default_INSRNC"] == "CurrntlyRunng")
                                {
                                    strQueryStr = "&default_INSRNC=CurrntlyRunng";
                                }
                            }

                            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                            {
                                //edit

                                if (intClosed == 0)
                                {
                                    if (intRenew == 0)
                                    {
                                        if (intConfirmed == 0)
                                        {
                                            if (intCnclUsrId == 0)
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"Edit\"   onclick='return getdetails(this.href);' " +
                                                      " href=\"gen_Bank_Guarantee.aspx?Id_INSRNC=" + Id + strQueryStr + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                                            }
                                            else
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"View\"  onclick='return getdetails(this.href);' " +
                                                 " href=\"gen_Bank_Guarantee.aspx?ViewId_INSRNC=" + Id + strQueryStr + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' />  " + "</a> </td>";
                                            }
                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"View\"  onclick='return getdetails(this.href);' " +
                                                     " href=\"gen_Bank_Guarantee.aspx?ViewId_INSRNC=" + Id + strQueryStr + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' />  " + "</a> </td>";
                                        }
                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"View\"  onclick='return getdetails(this.href);' " +
                                                 " href=\"gen_Bank_Guarantee.aspx?ViewId_INSRNC=" + Id + strQueryStr + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' />  " + "</a> </td>";
                                    }
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"View\"  onclick='return getdetails(this.href);' " +
                                                     " href=\"gen_Bank_Guarantee.aspx?ViewId_INSRNC=" + Id + strQueryStr + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' />  " + "</a> </td>";
                                }

                                //confirm

                                if (intCnclUsrId == 0)
                                {
                                    if (intEnableConfirm == 1)
                                    {
                                        if (intnew == 1)
                                        {
                                            if (HiddenSearchField.Value == "")
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align:center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left:1% ;\" title=\"Confirm\"    onclick='return ConfirmGtee(this.href," + intExpiredSts + ");' " +
                                                                  " href=\"gen_Bank_Guarantee_List.aspx?CONF_INSRNC=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/confirm.png' /> " + "</a> </td>";
                                            }
                                            else
                                            {

                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align:center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left:1% ;\" title=\"Confirm\"    onclick='return ConfirmGtee(this.href," + intExpiredSts + ");' " +
                                                                 " href=\"gen_Bank_Guarantee_List.aspx?CONF_INSRNC=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  style=\"\" src='/Images/Icons/confirm.png' /> " + "</a> </td>";
                                            }
                                        }
                                        else if (ddlGuaranteeStatus.SelectedItem.Text == "All")
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align:center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:0.2;margin-top:-1%; margin-left:1% ; \" title=\"Confirm\">" + "<img  style=\"opacity: 1;cursor: pointer;\" src='/Images/Icons/confirm.png' /> " + "</a> </td>";
                                        }
                                    }
                                }
                            }

                            //cancel
                            if (intReCallForTAble == 0)
                            {
                                if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                                {
                                    if (intCnclUsrId == 0)
                                    {
                                        if (intRenew == 0)
                                        {
                                            if (intClosed == 0)
                                            {
                                                if (intCancTransaction == 0)
                                                {
                                                    if (intConfirmed == 0)
                                                    {
                                                        if (HiddenSearchField.Value == "")
                                                        {
                                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%;margin-left:1%; \"  title=\"Cancel\"  onclick='return CancelAlert_INSRNC(this.href);' " +
                                                             " href=\"gen_Bank_Guarantee_List.aspx?Id_INSRNC=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                                        }
                                                        else
                                                        {
                                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%;margin-left:1%; \"  title=\"Cancel\"  onclick='return CancelAlert_INSRNC(this.href);' " +
                                                             " href=\"gen_Bank_Guarantee_List.aspx?Id_INSRNC=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >"
                                                                 + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                                    }
                                                }
                                                else
                                                {
                                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left:1%;\" onclick='return CancelNotPossible();' >"
                                                            + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                                }
                                            }
                                            else
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  style=\"opacity:0.2;margin-top:-1%; margin-left:1%;\"  >"
                                                             + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                            }
                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  style=\"opacity:0.2;margin-top:-1%; margin-left:1%;\"  >"
                                                         + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                        }
                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                                    }
                                }
                            }

                            if (intReCallForTAble == 1)
                            {
                                if (intEnableRecall == 1)
                                {
                                    if (intCnclUsrId == 0)
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                                    }
                                    else
                                    {
                                        if (HiddenSearchField.Value == "")
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a style=\"z-index: 99;opacity:1;margin-top:-1%;margin-left: 1%; \" class=\"tooltip\" title=\"Recall\"  onclick='return ReCallAlert(this.href);' " +
                                             " href=\"gen_Bank_Guarantee_List.aspx?ReId_INSRNC=" + Id + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left: 1%;\" title=\"Recall\"   onclick='return ReCallAlert(this.href);' " +
                                             " href=\"gen_Bank_Guarantee_List.aspx?ReId_INSRNC=" + Id + "&SrchC=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                                        }


                                    }
                                }
                            }

                            if (intEnableClose == 1)
                            {
                                if (intReCallForTAble == 0)
                                {
                                    if (intClosed == 0)
                                    {
                                        if (intnew == 0)
                                        {
                                            if (HiddenSearchField.Value == "")
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left: .5%;\"  title=\"Close\"  onclick='return ConfirmClose(this.href);' " +
                                                                 " href=\"gen_Bank_Guarantee_List.aspx?Close_INSRNC=" + Id + "\">" + "<img  src='/Images/Icons/close.png' /> " + "</a> </td>";
                                            }
                                            else
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left: .5%;\"  title=\"Close\"  onclick='return ConfirmClose(this.href);' " +
                                                               " href=\"gen_Bank_Guarantee_List.aspx?Close_INSRNC=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/close.png' /> " + "</a> </td>";
                                            }
                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a    >"
                                                                       + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/close.png' /> " + "</a> </td>";
                                        }
                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a    >"
                                                                    + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/close.png' /> " + "</a> </td>";
                                    }
                                }
                            }

                            if (intEnableRenew == 1)
                            {
                                if (intReCallForTAble == 0)
                                {
                                    if (intCnclUsrId == 0)
                                    {
                                        if (intRenew == 1)
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%;margin-left:1%; \"  title=\"Renew\"   " +
                                                                    " href=\"gen_Bank_Guarantee.aspx?Renew_INSRNC=" + Id + "\">" + "<img  src='/Images/Icons/Renewal.png'/> " + "</a> </td>";
                                        }
                                        else
                                        {
                                            if (intConfirmed == 1)
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%;margin-left:1%; \"  title=\"Renew\"   " +
                                                                    " href=\"gen_Bank_Guarantee.aspx?Renew_INSRNC=" + Id + "\">" + "<img  src='/Images/Icons/Renewal.png'/> " + "</a> </td>";
                                            }
                                            else
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a     style=\"margin-left:10%; opacity: 0;\" >"
                                                                            + "<img style=\"opacity: 0; \" src='/Images/Icons/Renew.png' /> " + "</a> </td>";
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        strHtml += "</tr>";
                    }
                }
            }
            else
            {
                if (hiddenNext.Value == "")
                {
                    hiddenNext.Value = hiddenTotalRowCount.Value;
                }
                int last = Convert.ToInt32(hiddenNext.Value);
                if (intRowBodyCount < last)
                {
                    int intConfirmed = 0, intClosed = 0, intRenew = 0, intnew = 0;
                    int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CNCL_USR_ID"].ToString());
                    int intCancTransaction = 0;

                    string InsrncStatus = dt.Rows[intRowBodyCount]["STATUS"].ToString();

                    if (InsrncStatus == "1")
                    {
                        intnew = 1;
                    }
                    if (InsrncStatus == "2")
                    {
                        intConfirmed = 1;
                    }
                    if (InsrncStatus == "3")
                    {
                        intRenew = 1;
                    }
                    if (InsrncStatus == "4")
                    {
                        intClosed = 1;
                    }

                    strHtml += "<tr>";

                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {
                        if (intColumnBodyCount == 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 2)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word; text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 3)
                        {
                            if (ddlPolicyType.SelectedItem.Value == "2")
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                        }
                        else if (intColumnBodyCount == 4)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 5)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 6)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 7)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 8)
                        {
                            string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                            string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);

                            strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + strNetAmountWithComma.ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 9)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            //EVM-0027
                            HiddenCurrency.Value = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                            //END
                        }
                    }

                    string strId = dt.Rows[intRowBodyCount][0].ToString();
                    int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                    string stridLength = intIdLength.ToString("00");
                    string Id = stridLength + strId + strRandom;

                    if (dt.Rows[intRowBodyCount]["policytyp"].ToString() == "1")
                    {

                        string strQueryStr = "";
                        if (Request.QueryString["default"] != null)
                        {
                            if (Request.QueryString["default"] == "new")
                            {
                                strQueryStr = "&default=new";
                            }
                            else if (Request.QueryString["default"] == "3months")
                            {
                                strQueryStr = "&default=3months";
                            }
                            else if (Request.QueryString["default"] == "expired")
                            {
                                strQueryStr = "&default=expired";
                            }
                            else if (Request.QueryString["default"] == "CurrntlyRunng")
                            {
                                strQueryStr = "&default=CurrntlyRunng";
                            }
                        }

                        if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            //edit

                            if (intClosed == 0)
                            {
                                if (intRenew == 0)
                                {
                                    if (intConfirmed == 0)
                                    {
                                        if (intCnclUsrId == 0)
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"Edit\"   onclick='return getdetails(this.href);' " +
                                                  " href=\"gen_Bank_Guarantee.aspx?Id=" + Id + strQueryStr + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"View\"  onclick='return getdetails(this.href);' " +
                                             " href=\"gen_Bank_Guarantee.aspx?ViewId=" + Id + strQueryStr + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' />  " + "</a> </td>";
                                        }
                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"View\"  onclick='return getdetails(this.href);' " +
                                                 " href=\"gen_Bank_Guarantee.aspx?ViewId=" + Id + strQueryStr + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' />  " + "</a> </td>";
                                    }
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"View\"  onclick='return getdetails(this.href);' " +
                                             " href=\"gen_Bank_Guarantee.aspx?ViewId=" + Id + strQueryStr + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' />  " + "</a> </td>";
                                }
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"View\"  onclick='return getdetails(this.href);' " +
                                                 " href=\"gen_Bank_Guarantee.aspx?ViewId=" + Id + strQueryStr + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' />  " + "</a> </td>";
                            }

                            //confirm

                            if (intCnclUsrId == 0)
                            {
                                if (intEnableConfirm == 1)
                                {
                                    if (intnew == 1)
                                    {
                                        if (HiddenSearchField.Value == "")
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align:center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left:1% ;\" title=\"Confirm\"    onclick='return ConfirmGtee(this.href," + intExpiredSts + ");' " +
                                                              " href=\"gen_Bank_Guarantee_List.aspx?CONF=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/confirm.png' /> " + "</a> </td>";
                                        }
                                        else
                                        {

                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align:center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left:1% ;\" title=\"Confirm\"    onclick='return ConfirmGtee(this.href," + intExpiredSts + ");' " +
                                                             " href=\"gen_Bank_Guarantee_List.aspx?CONF=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  style=\"\" src='/Images/Icons/confirm.png' /> " + "</a> </td>";
                                        }
                                    }
                                    else if (ddlGuaranteeStatus.SelectedItem.Text == "All")
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align:center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:0.2;margin-top:-1%; margin-left:1% ; \" title=\"Confirm\">" + "<img  style=\"opacity: 1;cursor: pointer;\" src='/Images/Icons/confirm.png' /> " + "</a> </td>";
                                    }
                                }
                            }
                        }

                        //cancel
                        if (intReCallForTAble == 0)
                        {
                            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                            {
                                if (intCnclUsrId == 0)
                                {
                                    if (intRenew == 0)
                                    {
                                        if (intClosed == 0)
                                        {
                                            if (intCancTransaction == 0)
                                            {
                                                if (intConfirmed == 0)
                                                {
                                                    if (HiddenSearchField.Value == "")
                                                    {
                                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%;margin-left:1%; \"  title=\"Cancel\"  onclick='return CancelAlert(this.href);' " +
                                                         " href=\"gen_Bank_Guarantee_List.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                                    }
                                                    else
                                                    {
                                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%;margin-left:1%; \"  title=\"Cancel\"  onclick='return CancelAlert(this.href);' " +
                                                         " href=\"gen_Bank_Guarantee_List.aspx?Id=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                                    }
                                                }
                                                else
                                                {
                                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >"
                                                             + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                                }
                                            }
                                            else
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left:1%;\" onclick='return CancelNotPossible();' >"
                                                        + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                            }
                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  style=\"opacity:0.2;margin-top:-1%; margin-left:1%;\"  >"
                                                         + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                        }
                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  style=\"opacity:0.2;margin-top:-1%; margin-left:1%;\"  >"
                                                     + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                    }
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                                }
                            }
                        }

                        if (intReCallForTAble == 1)
                        {
                            if (intEnableRecall == 1)
                            {
                                if (intCnclUsrId == 0)
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                                }
                                else
                                {

                                    if (HiddenSearchField.Value == "")
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a style=\"z-index: 99;opacity:1;margin-top:-1%;margin-left: 1%; \" class=\"tooltip\" title=\"Recall\"  onclick='return ReCallAlert(this.href);' " +
                                         " href=\"gen_Bank_Guarantee_List.aspx?ReId=" + Id + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left: 1%;\" title=\"Recall\"   onclick='return ReCallAlert(this.href);' " +
                                         " href=\"gen_Bank_Guarantee_List.aspx?ReId=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                                    }


                                }
                            }
                        }

                        if (intEnableClose == 1)
                        {
                            if (intReCallForTAble == 0)
                            {
                                if (intClosed == 0)
                                {
                                    if (intnew == 0)
                                    {
                                        if (HiddenSearchField.Value == "")
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left: .5%;\"  title=\"Close\"  onclick='return ConfirmClose(this.href);' " +
                                                             " href=\"gen_Bank_Guarantee_List.aspx?Close=" + Id + "\">" + "<img  src='/Images/Icons/close.png' /> " + "</a> </td>";
                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left: .5%;\"  title=\"Close\"  onclick='return ConfirmClose(this.href);' " +
                                                           " href=\"gen_Bank_Guarantee_List.aspx?Close=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/close.png' /> " + "</a> </td>";
                                        }
                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a    >"
                                                                   + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/close.png' /> " + "</a> </td>";
                                    }
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a    >"
                                                                + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/close.png' /> " + "</a> </td>";
                                }
                            }
                        }

                        if (intEnableRenew == 1)
                        {
                            if (intReCallForTAble == 0)
                            {
                                if (intCnclUsrId == 0)
                                {
                                    if (intRenew == 1)
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%;margin-left:1%; \"  title=\"Renew\"   " +
                                                                " href=\"gen_Bank_Guarantee.aspx?Renew=" + Id + "\">" + "<img  src='/Images/Icons/Renewal.png'/> " + "</a> </td>";
                                    }
                                    else
                                    {
                                        if (intConfirmed == 1)
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%;margin-left:1%; \"  title=\"Renew\"   " +
                                                                " href=\"gen_Bank_Guarantee.aspx?Renew=" + Id + "\">" + "<img  src='/Images/Icons/Renewal.png'/> " + "</a> </td>";
                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a     style=\"margin-left:10%; opacity: 0;\" >"
                                                                        + "<img style=\"opacity: 0; \" src='/Images/Icons/Renew.png' /> " + "</a> </td>";
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {

                        string strQueryStr = "";
                        if (Request.QueryString["default_INSRNC"] != null)
                        {
                            if (Request.QueryString["default_INSRNC"] == "new")
                            {
                                strQueryStr = "&default_INSRNC=new";
                            }
                            else if (Request.QueryString["default_INSRNC"] == "3months")
                            {
                                strQueryStr = "&default_INSRNC=3months";
                            }
                            else if (Request.QueryString["default_INSRNC"] == "expired")
                            {
                                strQueryStr = "&default_INSRNC=expired";
                            }
                            else if (Request.QueryString["default_INSRNC"] == "CurrntlyRunng")
                            {
                                strQueryStr = "&default_INSRNC=CurrntlyRunng";
                            }
                        }

                        if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            //edit

                            if (intClosed == 0)
                            {
                                if (intRenew == 0)
                                {
                                    if (intConfirmed == 0)
                                    {
                                        if (intCnclUsrId == 0)
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"Edit\"   onclick='return getdetails(this.href);' " +
                                                  " href=\"gen_Bank_Guarantee.aspx?Id_INSRNC=" + Id + strQueryStr + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"View\"  onclick='return getdetails(this.href);' " +
                                             " href=\"gen_Bank_Guarantee.aspx?ViewId_INSRNC=" + Id + strQueryStr + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' />  " + "</a> </td>";
                                        }
                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"View\"  onclick='return getdetails(this.href);' " +
                                                 " href=\"gen_Bank_Guarantee.aspx?ViewId_INSRNC=" + Id + strQueryStr + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' />  " + "</a> </td>";
                                    }
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"View\"  onclick='return getdetails(this.href);' " +
                                             " href=\"gen_Bank_Guarantee.aspx?ViewId_INSRNC=" + Id + strQueryStr + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' />  " + "</a> </td>";
                                }
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"View\"  onclick='return getdetails(this.href);' " +
                                                 " href=\"gen_Bank_Guarantee.aspx?ViewId_INSRNC=" + Id + strQueryStr + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' />  " + "</a> </td>";
                            }

                            //confirm

                            if (intCnclUsrId == 0)
                            {
                                if (intEnableConfirm == 1)
                                {
                                    if (intnew == 1)
                                    {
                                        if (HiddenSearchField.Value == "")
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align:center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left:1% ;\" title=\"Confirm\"    onclick='return ConfirmGtee(this.href," + intExpiredSts + ");' " +
                                                              " href=\"gen_Bank_Guarantee_List.aspx?CONF_INSRNC=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/confirm.png' /> " + "</a> </td>";
                                        }
                                        else
                                        {

                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align:center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left:1% ;\" title=\"Confirm\"    onclick='return ConfirmGtee(this.href," + intExpiredSts + ");' " +
                                                             " href=\"gen_Bank_Guarantee_List.aspx?CONF_INSRNC=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  style=\"\" src='/Images/Icons/confirm.png' /> " + "</a> </td>";
                                        }
                                    }
                                    else if (ddlGuaranteeStatus.SelectedItem.Text == "All")
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align:center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:0.2;margin-top:-1%; margin-left:1% ; \" title=\"Confirm\">" + "<img  style=\"opacity: 1;cursor: pointer;\" src='/Images/Icons/confirm.png' /> " + "</a> </td>";
                                    }
                                }
                            }
                        }

                        //cancel
                        if (intReCallForTAble == 0)
                        {
                            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                            {
                                if (intCnclUsrId == 0)
                                {
                                    if (intRenew == 0)
                                    {
                                        if (intClosed == 0)
                                        {
                                            if (intCancTransaction == 0)
                                            {
                                                if (intConfirmed == 0)
                                                {
                                                    if (HiddenSearchField.Value == "")
                                                    {
                                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%;margin-left:1%; \"  title=\"Cancel\"  onclick='return CancelAlert_INSRNC(this.href);' " +
                                                         " href=\"gen_Bank_Guarantee_List.aspx?Id_INSRNC=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                                    }
                                                    else
                                                    {
                                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%;margin-left:1%; \"  title=\"Cancel\"  onclick='return CancelAlert_INSRNC(this.href);' " +
                                                         " href=\"gen_Bank_Guarantee_List.aspx?Id_INSRNC=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                                    }
                                                }
                                                else
                                                {
                                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >"
                                                             + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                                }
                                            }
                                            else
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left:1%;\" onclick='return CancelNotPossible();' >"
                                                        + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                            }
                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  style=\"opacity:0.2;margin-top:-1%; margin-left:1%;\"  >"
                                                         + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                        }
                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  style=\"opacity:0.2;margin-top:-1%; margin-left:1%;\"  >"
                                                     + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                    }
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                                }
                            }
                        }

                        if (intReCallForTAble == 1)
                        {
                            if (intEnableRecall == 1)
                            {
                                if (intCnclUsrId == 0)
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                                }
                                else
                                {

                                    if (HiddenSearchField.Value == "")
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a style=\"z-index: 99;opacity:1;margin-top:-1%;margin-left: 1%; \" class=\"tooltip\" title=\"Recall\"  onclick='return ReCallAlert(this.href);' " +
                                         " href=\"gen_Bank_Guarantee_List.aspx?ReId_INSRNC=" + Id + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left: 1%;\" title=\"Recall\"   onclick='return ReCallAlert(this.href);' " +
                                         " href=\"gen_Bank_Guarantee_List.aspx?ReId_INSRNC=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                                    }


                                }
                            }
                        }

                        if (intEnableClose == 1)
                        {
                            if (intReCallForTAble == 0)
                            {
                                if (intClosed == 0)
                                {
                                    if (intnew == 0)
                                    {
                                        if (HiddenSearchField.Value == "")
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left: .5%;\"  title=\"Close\"  onclick='return ConfirmClose(this.href);' " +
                                                             " href=\"gen_Bank_Guarantee_List.aspx?Close_INSRNC=" + Id + "\">" + "<img  src='/Images/Icons/close.png' /> " + "</a> </td>";
                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left: .5%;\"  title=\"Close\"  onclick='return ConfirmClose(this.href);' " +
                                                           " href=\"gen_Bank_Guarantee_List.aspx?Close_INSRNC=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/close.png' /> " + "</a> </td>";
                                        }
                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a    >"
                                                                   + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/close.png' /> " + "</a> </td>";
                                    }
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a    >"
                                                                + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/close.png' /> " + "</a> </td>";
                                }
                            }
                        }

                        if (intEnableRenew == 1)
                        {
                            if (intReCallForTAble == 0)
                            {
                                if (intCnclUsrId == 0)
                                {
                                    if (intRenew == 1)
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%;margin-left:1%; \"  title=\"Renew\"   " +
                                                                " href=\"gen_Bank_Guarantee.aspx?Renew_INSRNC=" + Id + "\">" + "<img  src='/Images/Icons/Renewal.png'/> " + "</a> </td>";
                                    }
                                    else
                                    {
                                        if (intConfirmed == 1)
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%;margin-left:1%; \"  title=\"Renew\"   " +
                                                                " href=\"gen_Bank_Guarantee.aspx?Renew_INSRNC=" + Id + "\">" + "<img  src='/Images/Icons/Renewal.png'/> " + "</a> </td>";
                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a     style=\"margin-left:10%; opacity: 0;\" >"
                                                                        + "<img style=\"opacity: 0; \" src='/Images/Icons/Renew.png' /> " + "</a> </td>";
                                        }
                                    }
                                }
                            }
                        }
                    }



                    strHtml += "</tr>";
                }

                else
                {
                    btnNext.Enabled = true;
                }
            }
        }
        //        foreach (var row in result)
        //        {
        //            strHtml += "<tr id=\"TableRprtRow\" >";
        //            strHtml += "<tfoot>";
        //            strHtml += "<td  class=\"tdT\" colspan=\"6\"; style=\"border-right-color: white;font-size: SMALL;width:6%;word-break: break-all; word-wrap:break-word;text-align: right;\" >Total</td>";
        //            string strtotalAmount = "";
        //            strtotalAmount = Convert.ToString(row.Sum);
        //            string strTotal = objBusiness.AddCommasForNumberSeperation(strtotalAmount, objEntityCommon);
        //            strHtml += "<td  class=\"tdT\"  style=\" border-right: navajowhite;font-size: SMALL;width:6%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strTotal + "</td>";
        //            strHtml += "<td  class=\"tdT\"  style=\" border-right: navajowhite;font-size: SMALL;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;border-left-color: white;\" >" + row.Group + "</td>";
        //            strHtml += "</tfoot>";
        //        }




        }
        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        HiddenCheckDashboard.Value = "1";
        pHeader.Visible = false;
        pHeader.InnerHtml = "";
        clsBusinessLayerBankGuarantee ObjBussinessBankGuarnt = new clsBusinessLayerBankGuarantee();
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();

        btnNext.Enabled = false;
        btnPrevious.Enabled = false;
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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





        int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableClose = 0, intEnableRenew = 0, intEnableConfirm = 0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        intUserRoleRecall = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
        DataTable dtCancelRecall = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUserRoleRecall);
        if (dtCancelRecall.Rows.Count > 0)
        {
            intEnableRecall = 1;
        }
        else
        {
            intEnableRecall = 0;
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
                    hiddenRoleClose.Value = intEnableClose.ToString();
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Renew).ToString())
                {
                    intEnableRenew = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    HiddenFieldRenew.Value = intEnableClose.ToString();
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                {
                    intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    hiddenFieldConfirm.Value = intEnableConfirm.ToString();

                }

            }
        }


        if (HiddenFieldSuplier.Value == "1" && HiddenFieldClient.Value == "1")
        {
            ObjEntityRequest.CusSupSrch = 1;
            // btnConfirm.Visible = true;
            if (ddlCustSuplrsrch.SelectedValue == "1")
            {
                divSuplier.Visible = true;
                divcustomer.Visible = false;
                h2SuplCus.InnerText = "Supplier";
            }
            else if (ddlCustSuplrsrch.SelectedValue == "2")
            {
                divSuplier.Visible = false;
                divcustomer.Visible = true;
                h2SuplCus.InnerText = "Customer";
            }
            ObjEntityRequest.SuplOrClient = 0;
        }
        else
        {
            if (HiddenFieldSuplier.Value == "1")
            {
                radioBinding.Disabled = true;
                // radioCus.Disabled = true;
                // btnConfirm.Visible = true;
                //radioSup.Disabled = true;
                //radioSup.Checked = true;
                radioAwdrd.Checked = true;
                ObjEntityRequest.SuplOrClient = 1;
                divSuplier.Visible = true;
                divcustomer.Visible = false;
                ddlCustSuplrsrch.SelectedValue = "1";
                ddlCustSuplrsrch.Enabled = false;
                ObjEntityRequest.CusSupSrch = 1;
                h2SuplCus.InnerText = "Supplier";

            }

            else if (HiddenFieldClient.Value == "1")
            {
                // radioSup.Disabled = true;
                //btnConfirm.Visible = true;
                //  radioCus.Checked = true;
                // radioSup.Disabled = true;
                ObjEntityRequest.SuplOrClient = 2;
                divSuplier.Visible = false;
                divcustomer.Visible = true;
                ddlCustSuplrsrch.SelectedValue = "2";
                ddlCustSuplrsrch.Enabled = false;
                ObjEntityRequest.CusSupSrch = 2;
                h2SuplCus.InnerText = "Customer";
            }
            else
            {
                radioBinding.Disabled = true;
                radioAwdrd.Disabled = true;
                // btnConfirm.Visible = false;
                // radioCus.Disabled = true;
                // btnConfirm.Visible = true;
                // radioSup.Disabled = true;
                ddlSuplCus.Enabled = false;
                ddlSup.Enabled = false;
                ObjEntityRequest.SuplOrClient = 3;
                divSuplier.Disabled = true;
                divcustomer.Visible = false;
                ddlCustSuplrsrch.Enabled = false;
            }
        }


        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                                   clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE,
                                                               clsCommonLibrary.CORP_GLOBAL.CMDTY_MANTN_OFFCE
                                                              };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            hiddenCommodityValue.Value = dtCorpDetail.Rows[0]["CMDTY_MANTN_OFFCE"].ToString();
            string strListingMode = dtCorpDetail.Rows[0]["LISTING_MODE"].ToString();
            string strLstingModeSize = dtCorpDetail.Rows[0]["LISTING_MODE_SIZE"].ToString();

            int intListingMode = Convert.ToInt32(strListingMode);

            if (intListingMode == 2)//variant
            {
                btnNext.Text = "Show Next Records";
                btnPrevious.Text = "Show Previous Records";
                hiddenMemorySize.Value = strLstingModeSize;
            }
            else if (intListingMode == 1)//fixed
            {
                btnNext.Text = "Show Next " + strLstingModeSize + " Records";
                btnPrevious.Text = "Show Previous " + strLstingModeSize + " Records";
                hiddenTotalRowCount.Value = strLstingModeSize;
                hiddenNext.Value = strLstingModeSize;
            }
            hiddenPrevious.Value = "0";

        }

        if (HiddenSearchField.Value == "")
        {
            ObjEntityRequest.OpenDate = DateTime.MinValue;
            ObjEntityRequest.ToDate = DateTime.MinValue;
            ObjEntityRequest.GuarTypeId = 0;
            ObjEntityRequest.Guarantee_Method = 0;
            ObjEntityRequest.Biding = 0;
            ObjEntityRequest.Awarded = 0;
            ObjEntityRequest.CusSuply = 0;
            ObjEntityRequest.ExpireDate = DateTime.MinValue;
            ObjEntityRequest.Cancel_Status = 0;
            ObjEntityRequest.BankId = 0;
            ObjEntityRequest.GuartStsSrch = 0;
            ObjEntityRequest.InsuranceProvider = 0;
            ObjEntityRequest.InsuranceTypMstr = 0;
            ObjEntityRequest.PolicyNumber  = 0;
            // ObjEntityRequest.CusSupSrch = 1;
            if (ddlPolicyType.SelectedItem.Value != "" && ddlPolicyType.SelectedItem.Value != "--Select--")
            {
                ObjEntityRequest.PolicyType = Convert.ToInt32(ddlPolicyType.SelectedItem.Value);
            }
        }
        else
        {
            string strHidden = "";
            strHidden = HiddenSearchField.Value;


            string[] strSearchFields = strHidden.Split(',');
            string strFromDate = strSearchFields[0];
            string strToDate = strSearchFields[1];
            string strGuaranteType = strSearchFields[2];
            string strGuaranteMode = strSearchFields[3];
            string strBiding = strSearchFields[4];
            string strAwarded = strSearchFields[5];
            string strddlCustSuplr = strSearchFields[6];
            string EspireDate = strSearchFields[7];
            string strCbxStatus = strSearchFields[8];
            string strBankId = strSearchFields[9];
            string strGuartSts = strSearchFields[10];
            string strCusSup = strSearchFields[11];
            string strInsurncPrvdr = strSearchFields[12];
            string strInsurPolicySts = strSearchFields[13];
            string strCurrency = strSearchFields[14];
            string strPolicyNumber = strSearchFields[15];
            string strInsuranceTypMstr = strSearchFields[16];

            if (strFromDate != null && strFromDate != "")
            {

                txtFromDate.Text = strFromDate;
                ObjEntityRequest.OpenDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
                //if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                //{
                //    ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                //}
            }
            else
            {
                ObjEntityRequest.OpenDate = DateTime.MinValue;
            }
            if (strToDate != null && strToDate != "")
            {

                txtToDate.Text = strToDate;
                //if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                //{
                //    ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                //}
                ObjEntityRequest.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
            }
            else
            {
                ObjEntityRequest.ToDate = DateTime.MinValue;
            }
            if (strBiding == "1")
            {
                radioBinding.Checked = true;
                //if (ddlGuaranteCat.Items.FindByValue(strGuarantCat) != null)
                //{
                //    ddlGuaranteCat.Items.FindByValue(strGuarantCat).Selected = true;
                //}
                ObjEntityRequest.Biding = 1;
            }
            else if (strAwarded == "1")
            {
                radioAwdrd.Checked = true;
                ObjEntityRequest.Awarded = 1;
            }
            else if (strBiding == "0" && strAwarded == "0")
            {
                ObjEntityRequest.Biding = 0;
                ObjEntityRequest.Awarded = 0;
            }

            if (strGuaranteType != null && strGuaranteType != "")
            {
                if (ddlGuaranteeTyp.Items.FindByValue(strGuaranteType) != null)
                {
                    ddlGuaranteeTyp.ClearSelection();
                    ddlGuaranteeTyp.Items.FindByValue(strGuaranteType).Selected = true;
                    ObjEntityRequest.GuarTypeId = Convert.ToInt32(strGuaranteType);
                }
            }
            if (strGuaranteMode != null && strGuaranteMode != "")
            {
                if (ddlGuaranteeMde.Items.FindByValue(strGuaranteMode) != null)
                {
                    if (ddlGuaranteeMde.SelectedItem.Value != "--SELECT GUARANTEE MODE--")
                    {
                        ddlGuaranteeMde.ClearSelection();
                        ddlGuaranteeMde.Items.FindByValue(strGuaranteMode).Selected = true;
                        ObjEntityRequest.Guarantee_Method = Convert.ToInt32(strGuaranteMode);
                    }
                }
            }

            if (strddlCustSuplr != null && strddlCustSuplr != "")
            {
                if (HiddenFieldRadioCusSupl.Value == "1")
                {
                    if (ddlSuplCus.Items.FindByValue(strddlCustSuplr) != null)
                    {
                        if (ddlSuplCus.SelectedItem.Value != "--SELECT--")
                        {
                            ddlSuplCus.ClearSelection();
                            ddlSuplCus.Items.FindByValue(strddlCustSuplr).Selected = true;
                            ObjEntityRequest.CusSuply = Convert.ToInt32(strddlCustSuplr);
                        }
                    }
                }
                else
                {
                    if (ddlSup.Items.FindByValue(strddlCustSuplr) != null)
                    {
                        if (ddlSup.SelectedItem.Value != "--SELECT--")
                        {
                            ddlSup.ClearSelection();
                            ddlSup.Items.FindByValue(strddlCustSuplr).Selected = true;
                            ObjEntityRequest.CusSuply = Convert.ToInt32(strddlCustSuplr);

                        }
                    }
                }
            }

            if (EspireDate != null && EspireDate != "")
            {

                BankGurntExpire.Text = EspireDate;
                ObjEntityRequest.ExpireDate = objCommon.textToDateTime(BankGurntExpire.Text);
                //if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                //{
                //    ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                //}
            }
            if (strBankId != null && strBankId != "")
            {
                if (ddlBankNm.Items.FindByValue(strBankId) != null)
                {
                    if (ddlBankNm.SelectedItem.Value != "--SELECT BANK--")
                    {
                        ddlBankNm.ClearSelection();
                        ddlBankNm.Items.FindByValue(strBankId).Selected = true;
                        ObjEntityRequest.BankId = Convert.ToInt32(strBankId);
                    }
                }
            }
            if (strGuartSts != null && strGuartSts != "")
            {
                if (ddlGuaranteeStatus.Items.FindByValue(strGuartSts) != null)
                {
                    ddlGuaranteeStatus.ClearSelection();

                    ddlGuaranteeStatus.Items.FindByValue(strGuartSts).Selected = true;
                    ObjEntityRequest.GuartStsSrch = Convert.ToInt32(strGuartSts);

                }
            }
            if (strInsurPolicySts != null && strInsurPolicySts != "")
            {
                if (ddlPolicyType.Items.FindByValue(strInsurPolicySts) != null)
                {
                    ddlPolicyType.ClearSelection();
                    ddlPolicyType.Items.FindByValue(strInsurPolicySts).Selected = true;
                    ObjEntityRequest.PolicyType = Convert.ToInt32(strInsurPolicySts);

                }
            }
            if (strCbxStatus == "1")
            {
                cbxCnclStatus.Checked = true;
            }
            else
            {
                cbxCnclStatus.Checked = false;
            }


            if (strCusSup != null && strCusSup != "")
            {
                if (ddlCustSuplrsrch.Items.FindByValue(strCusSup) != null)
                {
                    ddlCustSuplrsrch.ClearSelection();

                    ddlCustSuplrsrch.Items.FindByValue(strCusSup).Selected = true;
                    ObjEntityRequest.CusSupSrch = Convert.ToInt32(strCusSup);

                }
            }
            ObjEntityRequest.Cancel_Status = Convert.ToInt32(strCbxStatus);

            if (strInsurncPrvdr != null && strInsurncPrvdr != "")
            {
                if (ddlInsurncPrvdr.SelectedItem.Value != "--SELECT INSURANCE PROVIDER--")
                {
                    ObjEntityRequest.InsuranceProvider = Convert.ToInt32(ddlInsurncPrvdr.SelectedItem.Value);
                }
            }

            if (strInsuranceTypMstr != null && strInsuranceTypMstr != "")
            {
                if (ddlInsurncTyp.SelectedItem.Value != "--SELECT INSURANCE TYPE--")
                {
                    ObjEntityRequest.InsuranceTypMstr = Convert.ToInt32(ddlInsurncTyp.SelectedItem.Value);
                }
            }

            if (strCurrency != null && strCurrency != "--SELECT CURRENCY--")
            {
                if (ddlCurrency.Items.FindByValue(strCurrency) != null)
                {
                    ddlCurrency.ClearSelection();
                    ddlCurrency.Items.FindByValue(strCurrency).Selected = true;
                    ObjEntityRequest.Currency = Convert.ToInt32(strCurrency);
                }
            }

            if (strPolicyNumber != null && strPolicyNumber != "" && strPolicyNumber !="--SELECT POLICY NUMBER--")       
            {
                if (ddlPolicyNum.Items.FindByValue(strPolicyNumber) != null)
                {
                    ddlPolicyNum.ClearSelection();
                    ddlPolicyNum.Items.FindByValue(strPolicyNumber).Selected = true;
                    ObjEntityRequest.PolicyNumber = Convert.ToInt32(strPolicyNumber);
                }
            }
            
        }
        //Request.QueryString.Remove("default");
        //Request.QueryString["default"].
        DataTable dtContract = new DataTable();
        if (ObjEntityRequest.SuplOrClient != 3)
            // dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList(ObjEntityRequest);
            dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList1(ObjEntityRequest);
        int ROWCNT = dtContract.Rows.Count;

        string strHtm = ConvertDataTableToHTML(dtContract, intEnableModify, intEnableCancel, intEnableRecall, intEnableClose, intEnableRenew, intEnableConfirm);
        //Write to divReport
        divReport.InnerHtml = strHtm;
        string strPrintReport = ConvertDataTableForPrint(dtContract);
        divPrintReport.InnerHtml = strPrintReport;
    }

    public string ConvertDataTableForPrint(DataTable dt)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        if (hiddenDfltCurrencyMstrId.Value != "")
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        }
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "", strHead = ""; ;
        if (ddlPolicyType.SelectedItem.Value == "0")
        {
            strTitle = "Policy List";
            strHead = "Policy";
        }
        else if (ddlPolicyType.SelectedItem.Value == "1")
        {
            strTitle = "Bank Guarantee List";
            strHead = "Guarantee";
        }
        else if (ddlPolicyType.SelectedItem.Value == "2")
        {
            strTitle = "Insurance List";
            strHead = "Insurance";
        }

        if (pHeader.InnerHtml != "")
        {
            strTitle = pHeader.InnerHtml;
        }

        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string usrName = "<B> Report Generated By: </B>" + Session["USERFULLNAME"];
        string strHidden = "", FromDate = "", ToDate = "", ExpireDate = "", DeleteSts = "", InsrncPrvdr = "", GuranteSts = "", GuaranteType = "", AwardBidding = "", GuaranteMode = "", CustSupName = "", Bank = "", Currency = "";

        clsBusinessLayerInsuranceReports objBusinessLayerReports = new clsBusinessLayerInsuranceReports();
        clsEntityInsuraceReports objEntityReports = new clsEntityInsuraceReports();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityReports.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityReports.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtCorp = objBusinessLayerReports.ReadCorporateAddress(objEntityReports);
        if (dtCorp.Rows.Count > 0)
        {
            strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
            strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
            strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
            strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
            strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
        }

        if (HiddenSearchField.Value.ToString() != "")
        {
            strHidden = HiddenSearchField.Value;
            string[] strSearchFields = strHidden.Split(',');
            string strFromDate = strSearchFields[0];
            string strToDate = strSearchFields[1];
            string strGuaranteType = strSearchFields[2];
            string strGuaranteMode = strSearchFields[3];
            string strBiding = strSearchFields[4];
            string strAwarded = strSearchFields[5];
            string strddlCustSuplr = strSearchFields[6];
            string EspireDate = strSearchFields[7];
            string strCbxStatus = strSearchFields[8];
            string strBankId = strSearchFields[9];
            string strGuartSts = strSearchFields[10];
            string strCusSup = strSearchFields[11];
            string strInsurncPrvdr = strSearchFields[12];
            string strInsurPolicySts = strSearchFields[13];
            string strCurrency = strSearchFields[14];


            if (strFromDate != null && strFromDate != "")
            {
                FromDate = "<B>From Date  : </B>" + strFromDate;
            }
            if (strToDate != null && strToDate != "")
            {
                ToDate = "<B>To Date  : </B>" + strToDate;
            }
            if (EspireDate != null && EspireDate != "")
            {
                ExpireDate = "<B>Expiry Date  : </B>" + EspireDate;
            }
            if (strBiding == "1")
            {
                AwardBidding = "<B>Awarded/Bidding  : </B>Bidding";
            }
            else if (strAwarded == "1")
            {
                AwardBidding = "<B>Awarded/Bidding  : </B>Awarded";
            }

            if (strGuaranteType != null && strGuaranteType != "")
            {
                if (ddlGuaranteeTyp.Items.FindByValue(strGuaranteType) != null)
                {
                    GuaranteType = "<B>" + strHead + " Category : </B>" + ddlGuaranteeTyp.SelectedItem.Text;
                }
            }
            if (strGuaranteMode != null && strGuaranteMode != "")
            {
                if (ddlGuaranteeMde.Items.FindByValue(strGuaranteMode) != null)
                {
                    if (ddlGuaranteeMde.SelectedItem.Value != "--SELECT GUARANTEE MODE--")
                    {
                        GuaranteMode = "<B>Guarantee Mode : </B>" + ddlGuaranteeMde.SelectedItem.Text;
                    }
                }
            }
            if (strddlCustSuplr != null && strddlCustSuplr != "")
            {
                if (HiddenFieldRadioCusSupl.Value == "1")
                {
                    if (ddlSuplCus.Items.FindByValue(strddlCustSuplr) != null)
                    {
                        if (ddlSuplCus.SelectedItem.Value != "--SELECT--")//cus
                        {
                            CustSupName = "<B>Customer : </B>" + ddlSuplCus.SelectedItem.Text;
                        }
                    }
                }
                else
                {
                    if (ddlSup.Items.FindByValue(strddlCustSuplr) != null)
                    {
                        if (ddlSup.SelectedItem.Value != "--SELECT--")//sup
                        {
                            CustSupName = "<B>Supplier : </B>" + ddlSup.SelectedItem.Text;
                        }
                    }
                }
            }
            if (strBankId != null && strBankId != "")
            {
                if (ddlBankNm.Items.FindByValue(strBankId) != null)
                {
                    if (ddlBankNm.SelectedItem.Value != "--SELECT BANK--")
                    {
                        Bank = "<B>Bank : </B>" + ddlBankNm.SelectedItem.Text;
                    }
                }
            }
            if (strGuartSts != null && strGuartSts != "")
            {
                if (ddlGuaranteeStatus.Items.FindByValue(strGuartSts) != null)
                {
                    GuranteSts = "<B>" + strHead + " Status : </B>" + ddlGuaranteeStatus.SelectedItem.Text;
                }
            }
            if (InsrncPrvdr != null && InsrncPrvdr != "")
            {
                if (ddlInsurncPrvdr.Items.FindByValue(InsrncPrvdr) != null)
                {
                    if (ddlInsurncPrvdr.SelectedItem.Value != "--SELECT INSURANCE PROVIDER--")
                    {
                        InsrncPrvdr = "<B>Insurance Provider : </B>" + ddlInsurncPrvdr.SelectedItem.Text;
                    }
                }
            }

            if (strCurrency != null && strCurrency != "--SELECT CURRENCY--")
            {
                if (ddlCurrency.Items.FindByValue(strCurrency) != null)
                {
                    Currency = "<B>Currency : </B>" + ddlCurrency.SelectedItem.Text;
                }
            }
        }
        else
        {
            GuranteSts = "<B>" + strHead + " Status : </B>" + ddlGuaranteeStatus.SelectedItem.Text;
            GuaranteType = "<B>" + strHead + " Category : </B>" + ddlGuaranteeTyp.SelectedItem.Text;
        }

        clsCommonLibrary objClsCommon = new clsCommonLibrary();

        StringBuilder sbCap = new StringBuilder();
        string strCaptionUser = "";
        string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
        string strCaptionTabRprtDate = "", strCaptionTabTitle = "", strFromDteTitle = "", strToDateTitle = "", strGuaranteTypeTitle = "", strGuaranteMdeTitle = "", strBidingTitle = "", strCustOrSuplTitle = "", strExpireDateTitle = "", strInsrncPrvdrTitle = "", strGuranteStsTitle = "", strGuranteAwrdBdng = "", strGuranteMode = "", strGuranteCustSupl = "", strBank = "", strCrncy = "";

        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr1 + "</td></tr>";

        if (dat != "")
        {
            strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        }
        if (usrName != "")
        {
            strCaptionUser = "<tr><td class=\"RprtDate\">" + usrName + "</td></tr>";
        }
        if (strTitle != "")
        {
            strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
        }
        if (FromDate != "")
        {
            strFromDteTitle = "<tr><td class=\"RprtDiv\">" + FromDate + "</td></tr>";
        }
        if (ToDate != "")
        {
            strToDateTitle = "<tr><td class=\"RprtDiv\">" + ToDate + "</td></tr>";
        }
        if (ExpireDate != "")
        {
            strExpireDateTitle = "<tr><td class=\"RprtDiv\">" + ExpireDate + "</td></tr>";
        }
        if (InsrncPrvdr != "")
        {
            strInsrncPrvdrTitle = "<tr><td class=\"RprtDiv\">" + InsrncPrvdr + "</td></tr>";
        }
        if (GuranteSts != "")
        {
            strGuranteStsTitle = "<tr><td class=\"RprtDiv\">" + GuranteSts + "</td></tr>";
        }
        if (GuaranteType != "")
        {
            strGuaranteTypeTitle = "<tr><td class=\"RprtDiv\">" + GuaranteType + "</td></tr>";
        }
        if (AwardBidding != "")
        {
            strGuranteAwrdBdng = "<tr><td class=\"RprtDiv\">" + AwardBidding + "</td></tr>";
        }
        if (GuaranteMode != "")
        {
            strGuranteMode = "<tr><td class=\"RprtDiv\">" + GuaranteMode + "</td></tr>";
        }
        if (CustSupName != "")
        {
            strGuranteCustSupl = "<tr><td class=\"RprtDiv\">" + CustSupName + "</td></tr>";
        }
        if (Bank != "")
        {
            strBank = "<tr><td class=\"RprtDiv\">" + Bank + "</td></tr>";
        }
        if (Currency != "")
        {
            strCrncy = "<tr><td class=\"RprtDiv\">" + Currency + "</td></tr>";
        }

        string strCaptionTabstop = "</table><br>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strCaptionUser + strCaptionTabTitle + strFromDteTitle + strToDateTitle + strGuaranteTypeTitle + strGuaranteMdeTitle + strBidingTitle + strCustOrSuplTitle + strExpireDateTitle + strInsrncPrvdrTitle + strGuranteStsTitle + strGuranteAwrdBdng + strGuranteMode + strGuranteCustSupl + strBank + strCrncy + strCaptionTabstop;

        sbCap.Append(strPrintCaptionTable);
        ////write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString();


        StringBuilder sb = new StringBuilder();







        string strHtml = "<table id=\"PrintTable\" class=\"main_table\"  >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%; word-wrap:break-word; text-align: center;\">POLICY TYPE</th>";
            }

            else if (intColumnHeaderCount == 3)
            {
                if (ddlPolicyType.SelectedItem.Value == "2")
                {
                    strHtml += "<th class=\"thT\" style=\"width:8%; word-wrap:break-word; text-align: center;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:12%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">DFGF</th>";
            }
            else if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 8)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: right; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 9)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
        }

        strHtml += "</tr>";
        strHtml += "</thead>";

        //add rows

        strHtml += "<tbody>";

        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr id=\"TableRprtRow\" >";
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word; text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 3)
                {
                    if (ddlPolicyType.SelectedItem.Value == "2")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                }
                else if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 6)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 7)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 8)
                {
                    string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                    string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);

                    strHtml += "<td class=\"tdTamount\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + strNetAmountWithComma.ToString() + "</td>";

                }
                else if (intColumnBodyCount == 9)
                {
                    strHtml += "<td class=\"tdTaa" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    //EVM-0027
                    HiddenCurrency.Value = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                    //END
                }
            }
            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";
        
        sb.Append(strHtml);
      //  return sb.ToString();

        //StringBuilder sb1 = new StringBuilder();
        string strHtml1 = "<table id=\"PrintTable1\" class=\"main_table\"  >";

        if (dt.Rows.Count > 0)
        {

            var result = from tab in dt.AsEnumerable()
                         group tab by tab["CURRENCY"]
                             into groupDt
                             select new
                             {
                                 Group = groupDt.Key,
                                 Sum = groupDt.Sum((r) => decimal.Parse(r["AMOUNT"].ToString()))
                             };




            foreach (var row in result)
            {
                strHtml1 += "<tr id=\"TableRprtRow\" >";
                strHtml1 += "<tfoot>";
                strHtml1 += "<td  class=\"tdT\" colspan=\"10\"; style=\"border-right-color: white;font-size: SMALL;width:50%;word-break: break-all; word-wrap:break-word;text-align: right;\" >Total</td>";
                string strtotalAmount = "";
                strtotalAmount = Convert.ToString(row.Sum);
                string strTotal = objBusiness.AddCommasForNumberSeperation(strtotalAmount, objEntityCommon);
                strHtml1 += "<td  class=\"tdT\"  style=\" border-right: navajowhite;font-size: SMALL;width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + strTotal + "</td>";
                strHtml1 += "<td  class=\"tdT "+row.Group+"\"  style=\" border-right: navajowhite;font-size: SMALL;width:10%;word-break: break-all; word-wrap:break-word;text-align: center;border-left-color: white;\" >" + row.Group + "</td>";
                strHtml1 += "</tfoot>";
                strHtml1+= "</tr>";
            }
        }
        strHtml1 += "</table>";
        sb.Append(strHtml1);
        return sb.ToString();
    }

    protected void BtnCloseSave_Click(object sender, EventArgs e)
    {

        //Creating objects for business layer

        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();

        if (hiddenRsnidclose.Value != null && hiddenRsnidclose.Value != "")
        {
            ObjEntityRequest.GuaranteeId = Convert.ToInt32(hiddenRsnidclose.Value);


            if (Session["USERID"] != null)
            {
                ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            ObjEntityRequest.D_Date = System.DateTime.Now;

            ObjEntityRequest.Cancel_reason = TxtCloseReson.Text.Trim();
            ObjBussinessBankGuarnt.CloseRequest(ObjEntityRequest);

            if (HiddenSearchField.Value == "")
            {
                Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd=Cls");
            }
            else
            {
                Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd=Cls&Srch=" + this.HiddenSearchField.Value);
            }


        }
    }
    protected void btnRsnSave_Click(object sender, EventArgs e)
    {

        //Creating objects for business layer

        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();

        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            ObjEntityRequest.GuaranteeId = Convert.ToInt32(hiddenRsnid.Value);


            if (Session["USERID"] != null)
            {
                ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            ObjEntityRequest.D_Date = System.DateTime.Now;

            ObjEntityRequest.Cancel_reason = txtCnclReason.Text.Trim();
            ObjBussinessBankGuarnt.CancelRequest(ObjEntityRequest);

            if (HiddenSearchField.Value == "")
            {
                Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd=Cncl");
            }
            else
            {
                Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
            }


        }
    }

    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        Set_Table(Convert.ToInt32(Button_type.Previous));
    }

    //at next records show button click
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Set_Table(Convert.ToInt32(Button_type.Next));
    }

    //prepare table set datatable
    public void Set_Table(int intButtonId)
    {
        clsBusinessLayerBankGuarantee ObjBussinessBankGuarnt = new clsBusinessLayerBankGuarantee();
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();



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





        int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableClose = 0, intEnableRenew = 0, intEnableSuplier = 0, intEnableClient = 0;
        int intEnableConfirm = 0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        intUserRoleRecall = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
        DataTable dtCancelRecall = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUserRoleRecall);
        if (dtCancelRecall.Rows.Count > 0)
        {
            intEnableRecall = 1;
        }
        else
        {
            intEnableRecall = 0;
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
                    hiddenRoleClose.Value = intEnableClose.ToString();
                }

                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Renew).ToString())
                {
                    intEnableRenew = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    HiddenFieldRenew.Value = intEnableClose.ToString();
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Suplier_Guarantee_Permission).ToString())
                {
                    intEnableSuplier = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    HiddenFieldSuplier.Value = intEnableSuplier.ToString();
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Client_Guarantee_Permission).ToString())
                {
                    intEnableClient = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    HiddenFieldClient.Value = intEnableClient.ToString();

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                {
                    intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    hiddenFieldConfirm.Value = intEnableConfirm.ToString();

                }

            }
        }

        if (HiddenFieldSuplier.Value == "1" && HiddenFieldClient.Value == "1")
        {
            ObjEntityRequest.CusSupSrch = 1;
            // btnConfirm.Visible = true;
            if (ddlCustSuplrsrch.SelectedValue == "1")
            {
                divSuplier.Visible = true;
                divcustomer.Visible = false;
                h2SuplCus.InnerText = "Supplier";
            }
            else if (ddlCustSuplrsrch.SelectedValue == "2")
            {
                divSuplier.Visible = false;
                divcustomer.Visible = true;
                h2SuplCus.InnerText = "Customer";
            }
            ObjEntityRequest.SuplOrClient = 0;
        }
        else
        {
            if (HiddenFieldSuplier.Value == "1")
            {
                radioBinding.Disabled = true;
                // radioCus.Disabled = true;
                // btnConfirm.Visible = true;
                //radioSup.Disabled = true;
                //radioSup.Checked = true;
                radioAwdrd.Checked = true;
                ObjEntityRequest.SuplOrClient = 1;
                divSuplier.Visible = true;
                divcustomer.Visible = false;
                ddlCustSuplrsrch.SelectedValue = "1";
                ddlCustSuplrsrch.Enabled = false;
                ObjEntityRequest.CusSupSrch = 1;
                h2SuplCus.InnerText = "Supplier";

            }

            else if (HiddenFieldClient.Value == "1")
            {
                // radioSup.Disabled = true;
                //btnConfirm.Visible = true;
                //  radioCus.Checked = true;
                // radioSup.Disabled = true;
                ObjEntityRequest.SuplOrClient = 2;
                divSuplier.Visible = false;
                divcustomer.Visible = true;
                ddlCustSuplrsrch.SelectedValue = "2";
                ddlCustSuplrsrch.Enabled = false;
                ObjEntityRequest.CusSupSrch = 2;
                h2SuplCus.InnerText = "Customer";
            }
            else
            {
                radioBinding.Disabled = true;
                radioAwdrd.Disabled = true;
                // btnConfirm.Visible = false;
                // radioCus.Disabled = true;
                // btnConfirm.Visible = true;
                // radioSup.Disabled = true;
                ddlSuplCus.Enabled = false;
                ddlSup.Enabled = false;
                ObjEntityRequest.SuplOrClient = 3;
                divSuplier.Disabled = true;
                divcustomer.Visible = false;
                ddlCustSuplrsrch.Enabled = false;
            }
        }



        if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            if (intEnableSuplier == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                divAdd.Visible = true;
            }
            else if (intEnableClient == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                divAdd.Visible = true;
            }
            else
            {
                divAdd.Visible = false;
            }

        }
        else
        {

            divAdd.Visible = false;

        }
        if (HiddenSearchField.Value == "")
        {
            ObjEntityRequest.OpenDate = DateTime.MinValue;
            ObjEntityRequest.ToDate = DateTime.MinValue;
            ObjEntityRequest.GuarTypeId = 0;
            ObjEntityRequest.Guarantee_Method = 0;
            ObjEntityRequest.Biding = 0;
            ObjEntityRequest.Awarded = 0;
            ObjEntityRequest.CusSuply = 0;
            ObjEntityRequest.ExpireDate = DateTime.MinValue;
            ObjEntityRequest.Cancel_Status = 0;
            ObjEntityRequest.BankId = 0;
            ObjEntityRequest.GuartStsSrch = 0;
            //ObjEntityRequest.CusSupSrch = 1;
            if (ddlPolicyType.SelectedItem.Value != "" && ddlPolicyType.SelectedItem.Value != "--select--")
            {
                ObjEntityRequest.PolicyType = Convert.ToInt32(ddlPolicyType.SelectedItem.Value);  //evm-0023
            }
            else
            {
                ObjEntityRequest.PolicyType = 0;
            }
        }
        else
        {
            string strHidden = "";
            strHidden = HiddenSearchField.Value;


            string[] strSearchFields = strHidden.Split(',');
            string strFromDate = strSearchFields[0];
            string strToDate = strSearchFields[1];
            string strGuaranteType = strSearchFields[2];
            string strGuaranteMode = strSearchFields[3];
            string strBiding = strSearchFields[4];
            string strAwarded = strSearchFields[5];
            string strddlCustSuplr = strSearchFields[6];
            string EspireDate = strSearchFields[7];
            string strCbxStatus = strSearchFields[8];
            string strBankId = strSearchFields[9];
            string strGuartSts = strSearchFields[10];
            string strCusSup = strSearchFields[11];
            string strInsurncPrvdr = strSearchFields[12];
            string strInsurPolicySts = strSearchFields[13];
            string strCurrency = strSearchFields[14];



            if (strFromDate != null && strFromDate != "")
            {

                txtFromDate.Text = strFromDate;
                ObjEntityRequest.OpenDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
                //if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                //{
                //    ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                //}
            }
            else
            {
                ObjEntityRequest.OpenDate = DateTime.MinValue;
            }
            if (strToDate != null && strToDate != "")
            {

                txtToDate.Text = strToDate;
                //if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                //{
                //    ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                //}
                ObjEntityRequest.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
            }
            else
            {
                ObjEntityRequest.ToDate = DateTime.MinValue;
            }
            if (strBiding == "1")
            {
                radioBinding.Checked = true;
                //if (ddlGuaranteCat.Items.FindByValue(strGuarantCat) != null)
                //{
                //    ddlGuaranteCat.Items.FindByValue(strGuarantCat).Selected = true;
                //}
                ObjEntityRequest.Biding = 1;
            }
            else if (strAwarded == "1")
            {
                radioAwdrd.Checked = true;
                ObjEntityRequest.Awarded = 1;
            }
            else if (strBiding == "0" && strAwarded == "0")
            {
                ObjEntityRequest.Biding = 0;
                ObjEntityRequest.Awarded = 0;
            }

            if (strGuaranteType != null && strGuaranteType != "")
            {
                if (ddlGuaranteeTyp.Items.FindByValue(strGuaranteType) != null)
                {
                    ddlGuaranteeTyp.ClearSelection();
                    ddlGuaranteeTyp.Items.FindByValue(strGuaranteType).Selected = true;
                    ObjEntityRequest.GuarTypeId = Convert.ToInt32(strGuaranteType);
                }
            }
            if (strGuaranteMode != null && strGuaranteMode != "")
            {
                if (ddlGuaranteeMde.Items.FindByValue(strGuaranteMode) != null)
                {
                    if (ddlGuaranteeMde.SelectedItem.Value != "--SELECT GUARANTEE MODE--")
                    {
                        ddlGuaranteeMde.ClearSelection();
                        ddlGuaranteeMde.Items.FindByValue(strGuaranteMode).Selected = true;
                        ObjEntityRequest.Guarantee_Method = Convert.ToInt32(strGuaranteMode);
                    }
                }
            }

            if (strddlCustSuplr != null && strddlCustSuplr != "")
            {
                if (HiddenFieldRadioCusSupl.Value == "1")
                {
                    if (ddlSuplCus.Items.FindByValue(strddlCustSuplr) != null)
                    {
                        if (ddlSuplCus.SelectedItem.Value != "--SELECT--")
                        {
                            ddlSuplCus.ClearSelection();
                            ddlSuplCus.Items.FindByValue(strddlCustSuplr).Selected = true;
                            ObjEntityRequest.CusSuply = Convert.ToInt32(strddlCustSuplr);
                        }
                    }
                }
                else
                {
                    if (ddlSup.Items.FindByValue(strddlCustSuplr) != null)
                    {
                        if (ddlSup.SelectedItem.Value != "--SELECT--")
                        {
                            ddlSup.ClearSelection();
                            ddlSup.Items.FindByValue(strddlCustSuplr).Selected = true;
                            ObjEntityRequest.CusSuply = Convert.ToInt32(strddlCustSuplr);

                        }
                    }
                }
            }

            if (EspireDate != null && EspireDate != "")
            {

                BankGurntExpire.Text = EspireDate;
                ObjEntityRequest.ExpireDate = objCommon.textToDateTime(BankGurntExpire.Text.Trim());
                //if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                //{
                //    ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                //}
            }
            if (strBankId != null && strBankId != "")
            {
                if (ddlBankNm.Items.FindByValue(strBankId) != null)
                {
                    if (ddlBankNm.SelectedItem.Value != "--SELECT BANK--")
                    {
                        ddlBankNm.ClearSelection();
                        ddlBankNm.Items.FindByValue(strBankId).Selected = true;
                        ObjEntityRequest.BankId = Convert.ToInt32(strBankId);
                    }
                }
            }
            if (strGuartSts != null && strGuartSts != "")
            {
                if (ddlGuaranteeStatus.Items.FindByValue(strGuartSts) != null)
                {
                    ddlGuaranteeStatus.ClearSelection();

                    ddlGuaranteeStatus.Items.FindByValue(strGuartSts).Selected = true;
                    ObjEntityRequest.GuartStsSrch = Convert.ToInt32(strGuartSts);

                }
            }

            if (strInsurPolicySts != null && strInsurPolicySts != "")
            {
                if (ddlPolicyType.Items.FindByValue(strInsurPolicySts) != null)
                {
                    ddlPolicyType.ClearSelection();
                    ddlPolicyType.Items.FindByValue(strInsurPolicySts).Selected = true;
                    ObjEntityRequest.PolicyType = Convert.ToInt32(strInsurPolicySts);

                }
            }
            if (strCbxStatus == "1")
            {
                cbxCnclStatus.Checked = true;
            }
            else
            {
                cbxCnclStatus.Checked = false;
            }
            ObjEntityRequest.Cancel_Status = Convert.ToInt32(strCbxStatus);

            if (strCusSup != null && strCusSup != "")
            {
                if (ddlCustSuplrsrch.Items.FindByValue(strCusSup) != null)
                {
                    ddlCustSuplrsrch.ClearSelection();

                    ddlCustSuplrsrch.Items.FindByValue(strCusSup).Selected = true;
                    ObjEntityRequest.CusSupSrch = Convert.ToInt32(strCusSup);
                }
            }

            if (strCurrency != null && strCurrency != "--SELECT CURRENCY--")
            {
                if (ddlCurrency.Items.FindByValue(strCurrency) != null)
                {
                    ddlCurrency.ClearSelection();
                    ddlCurrency.Items.FindByValue(strCurrency).Selected = true;
                    ObjEntityRequest.Currency = Convert.ToInt32(strCurrency);
                }
            }
        }
        //from dashboard
        if (HiddenCheckDashboard.Value != "1")
        {
            if (Request.QueryString["default"] != null)
            {

                //ObjEntityRequest.PolicyType = 1;
                //ddlPolicyType.Items.FindByValue("1").Selected = true;
                //ddlPolicyType.Enabled = false;

                int typeid = 0;
                DateTime date = DateTime.Today; ;
                ObjEntityRequest.OpenDate = DateTime.MinValue;
                ObjEntityRequest.ToDate = DateTime.MinValue;
                ObjEntityRequest.ExpireDate = DateTime.MinValue;
                if (Request.QueryString["default"] == "3months")
                {
                    // txtFromDate.Text = DateTime.Today.Date.ToString("dd-MM-yyyy");
                    // txtToDate.Text = (DateTime.Today.AddDays(90)).ToString("dd-MM-yyyy");
                    //HiddenSearchField.Value = "0";
                    //string d = DateTime.Today.AddDays(90).ToString();
                    string datetoexpiry = DateTime.Today.AddDays(90).ToString("dd-MM-yyyy");
                    string datetoday = DateTime.Today.Date.ToString("dd-MM-yyyy");
                    //date = DateTime.ParseExact(datetoexpiry, "dd-MM-yyyy", null);
                    ObjEntityRequest.ExpireDate = DateTime.ParseExact(datetoexpiry, "dd-MM-yyyy", null);

                    ObjEntityRequest.FromDashboard = 1;
                    ObjEntityRequest.ExpiryFromDate = DateTime.ParseExact(datetoday, "dd-MM-yyyy", null);
                    //  date = DateTime.Parse(DateTime.Today.AddDays(90).ToString("dd-MM-yyyy"));
                    if (Request.QueryString["InsUpd"] != null)
                    {
                        string strInsUpd = Request.QueryString["InsUpd"].ToString();
                        if (strInsUpd == "Upd")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                        }
                    }
                    pHeader.InnerHtml = "Guarantees Expiring in 3 Months";
                    ObjEntityRequest.GuartStsSrch = 0;
                    ddlGuaranteeStatus.ClearSelection();
                    ddlGuaranteeStatus.Items.FindByText("All").Selected = true;
                }
                else if (Request.QueryString["default"] == "expired")
                {
                    BankGurntExpire.Text = (DateTime.Today.Date.ToString("dd-MM-yyyy"));

                    string datetemp = DateTime.Today.Date.ToString("dd-MM-yyyy");

                    //date = DateTime.ParseExact(datetemp, "dd-MM-yyyy", null);
                    ObjEntityRequest.ExpireDate = objCommon.textToDateTime(datetemp);
                    ObjEntityRequest.FromDashboard = 2;
                    if (Request.QueryString["InsUpd"] != null)
                    {
                        string strInsUpd = Request.QueryString["InsUpd"].ToString();
                        if (strInsUpd == "Upd")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                        }
                    }
                    pHeader.InnerHtml = "Expired Gurantees";
                    ObjEntityRequest.GuartStsSrch = 0;
                    ddlGuaranteeStatus.ClearSelection();
                    ddlGuaranteeStatus.Items.FindByText("All").Selected = true;
                }
                else if (Request.QueryString["default"] == "new")
                {
                    pHeader.InnerHtml = "Gurantees Under Open Status";
                    ObjEntityRequest.GuartStsSrch = 1;
                    //ddlGuaranteeStatus.ClearSelection();
                    //ddlGuaranteeStatus.Items.FindByText("All").Selected = true;
                }
                else if (Request.QueryString["default"] == "CurrntlyrungCus")
                {
                    clsCommonLibrary objCommon1 = new clsCommonLibrary();
                    ObjEntityRequest.CusSupSrch = 2;
                    string datetemp = DateTime.Today.Date.ToString("dd-MM-yyyy");

                    // date = DateTime.ParseExact(datetemp, "dd-MM-yyyy", null);
                    ObjEntityRequest.ExpireDate = objCommon1.textToDateTime(datetemp);
                    ObjEntityRequest.FromDashboard = 4;

                    pHeader.InnerHtml = "Currently running guarantee";
                    ObjEntityRequest.GuartStsSrch = 2;
                    ddlGuaranteeStatus.ClearSelection();
                    ddlGuaranteeStatus.Items.FindByText("Confirmed").Selected = true;

                    ddlCustSuplrsrch.ClearSelection();
                    ddlCustSuplrsrch.Items.FindByText("CUSTOMER").Selected = true;
                }

                else if (Request.QueryString["default"] == "CurrntlyrungSup")
                {
                    clsCommonLibrary objCommon1 = new clsCommonLibrary();
                    ObjEntityRequest.CusSupSrch = 1;
                    // BankGurntExpire.Text = (DateTime.Today.Date.ToString("dd-MM-yyyy"));

                    string datetemp = DateTime.Today.Date.ToString("dd-MM-yyyy");

                    // date = DateTime.ParseExact(datetemp, "dd-MM-yyyy", null);
                    ObjEntityRequest.ExpireDate = objCommon1.textToDateTime(datetemp);
                    ObjEntityRequest.FromDashboard = 4;

                    pHeader.InnerHtml = "Currently running guarantee";
                    ObjEntityRequest.GuartStsSrch = 2;
                    ddlGuaranteeStatus.ClearSelection();
                    ddlGuaranteeStatus.Items.FindByText("Confirmed").Selected = true;

                    ddlCustSuplrsrch.ClearSelection();
                    ddlCustSuplrsrch.Items.FindByText("SUPPLIER").Selected = true;
                }


            }
        }
        DataTable dtContract = new DataTable();
        if (ObjEntityRequest.SuplOrClient != 3)
            //dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList(ObjEntityRequest);
            dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList1(ObjEntityRequest);
        //string strHtm = ConvertDataTableToHTML(dtContract, intEnableModify, intEnableCancel, intEnableRecall, intEnableClose, intEnableRenew);
        ////Write to divReport
        //divReport.InnerHtml = strHtm;

        int first = 0;
        int last = 0;

        if (intButtonId == Convert.ToInt32(Button_type.Next))
        {
            first = Convert.ToInt32(hiddenNext.Value);
            last = Convert.ToInt32(hiddenNext.Value) + Convert.ToInt32(hiddenTotalRowCount.Value);
            hiddenPrevious.Value = first.ToString();
            hiddenNext.Value = last.ToString();
        }

        if (intButtonId == Convert.ToInt32(Button_type.Previous))
        {
            first = Convert.ToInt32(hiddenPrevious.Value) - Convert.ToInt32(hiddenTotalRowCount.Value);
            last = Convert.ToInt32(hiddenPrevious.Value);
            hiddenPrevious.Value = first.ToString();
            hiddenNext.Value = last.ToString();
        }
        if (first == 0)
        {
            btnPrevious.Enabled = false;

        }
        else
        {
            btnPrevious.Enabled = true;
        }
        if (last < dtContract.Rows.Count)
        {

            btnNext.Enabled = true;
        }
        else
        {
            btnNext.Enabled = false;
        }

        string strHtm = ConvertDataTableToHTML(dtContract, intEnableModify, intEnableCancel, intEnableRecall, intEnableClose, intEnableRenew, intEnableConfirm);
        //Write to divReport
        divReport.InnerHtml = strHtm;
    }

    protected void ddlCustSuplrsrch_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (HiddenFieldSuplier.Value == "1" && HiddenFieldClient.Value == "1")
        {

            // btnConfirm.Visible = true;
            if (ddlCustSuplrsrch.SelectedValue == "1")
            {
                divSuplier.Visible = true;
                divcustomer.Visible = false;
                h2SuplCus.InnerText = "Supplier";
            }
            else if (ddlCustSuplrsrch.SelectedValue == "2")
            {
                divSuplier.Visible = false;
                divcustomer.Visible = true;
                h2SuplCus.InnerText = "Customer";
            }
            //ObjEntityRequest.SuplOrClient = 0;
        }
        else
        {
            if (HiddenFieldSuplier.Value == "1")
            {
                radioBinding.Disabled = true;
                // radioCus.Disabled = true;
                // btnConfirm.Visible = true;
                //radioSup.Disabled = true;
                //radioSup.Checked = true;
                radioAwdrd.Checked = true;
                //  ObjEntityRequest.SuplOrClient = 1;
                divSuplier.Visible = true;
                divcustomer.Visible = false;
                ddlCustSuplrsrch.SelectedValue = "1";
                ddlCustSuplrsrch.Enabled = false;
                h2SuplCus.InnerText = "Supplier";
            }

            else if (HiddenFieldClient.Value == "1")
            {
                // radioSup.Disabled = true;
                //btnConfirm.Visible = true;
                //  radioCus.Checked = true;
                // radioSup.Disabled = true;
                // ObjEntityRequest.SuplOrClient = 2;
                divSuplier.Visible = false;
                divcustomer.Visible = true;
                ddlCustSuplrsrch.SelectedValue = "2";
                ddlCustSuplrsrch.Enabled = false;
                h2SuplCus.InnerText = "Customer";
            }
            else
            {
                radioBinding.Disabled = true;
                radioAwdrd.Disabled = true;
                // btnConfirm.Visible = false;
                // radioCus.Disabled = true;
                // btnConfirm.Visible = true;
                // radioSup.Disabled = true;
                ddlSuplCus.Enabled = false;
                ddlSup.Enabled = false;
                // ObjEntityRequest.SuplOrClient = 3;
                divSuplier.Disabled = true;
                divcustomer.Visible = false;
                ddlCustSuplrsrch.Enabled = false;
            }
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "Autocomplt", "Autocomplt();", true);

    }


    public void CurrencyLoad()
    {
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
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
        DataTable dtSubConrt = ObjBussinessBankGuarnt.ReadCurrency(ObjEntityRequest);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlCurrency.DataSource = dtSubConrt;
            ddlCurrency.DataTextField = "CRNCMST_NAME";
            ddlCurrency.DataValueField = "CRNCMST_ID";
            ddlCurrency.DataBind();
        }
        ddlCurrency.Items.Insert(0, "--SELECT CURRENCY--");

        DataTable dtDefaultcurc = ObjBussinessBankGuarnt.ReadDefualtCurrency(ObjEntityRequest);
        string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        //ddlCurrency.Items.Insert(0, "--SELECT CURRENCY--");
        if (ddlCurrency.Items.FindByValue(strdefltcurrcy) != null)
            ddlCurrency.Items.FindByValue(strdefltcurrcy).Selected = true;
    }

    protected void btnRsnSave_INSRNC_Click(object sender, EventArgs e)
    {
        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();
        clsBusinessLayerInsuranceMaster objBusinessInsurance = new clsBusinessLayerInsuranceMaster();

        if (hiddenRsn_INSRNCid.Value != null && hiddenRsn_INSRNCid.Value != "")
        {
            objEntityInsurance.InsuranceId = Convert.ToInt32(hiddenRsn_INSRNCid.Value);

            if (Session["USERID"] != null)
            {
                objEntityInsurance.User_Id = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityInsurance.D_Date = System.DateTime.Now;
            objEntityInsurance.Cancel_reason = txtCnclReason.Text.Trim();

            objBusinessInsurance.CancelInsurance(objEntityInsurance);

            if (HiddenSearchField.Value == "")
            {
                Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd_INSRNC=Cncl");
            }
            else
            {
                Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd_INSRNC=Cncl&Srch=" + this.HiddenSearchField.Value);
            }
        }
    }
    protected void BtnCloseSave_INSRNC_Click(object sender, EventArgs e)
    {
        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();
        clsBusinessLayerInsuranceMaster objBusinessInsurance = new clsBusinessLayerInsuranceMaster();

        if (hiddenRsn_INSRNCidclose.Value != null && hiddenRsn_INSRNCidclose.Value != "")
        {
            objEntityInsurance.InsuranceId = Convert.ToInt32(hiddenRsn_INSRNCidclose.Value);

            if (Session["USERID"] != null)
            {
                objEntityInsurance.User_Id = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            objEntityInsurance.D_Date = System.DateTime.Now;
            objEntityInsurance.Cancel_reason = TxtCloseReson.Text.Trim();

            objBusinessInsurance.CloseInsurance(objEntityInsurance);

            if (HiddenSearchField.Value == "")
            {
                Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd_INSRNC=Cls");
            }
            else
            {
                Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd_INSRNC=Cls&Srch=" + this.HiddenSearchField.Value);
            }
        }
    }


    //EVM-0027
    public string DataTableToCSV(DataTable dtSIFHeader, char seperator)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < dtSIFHeader.Columns.Count; i++)
        {
            sb.Append(dtSIFHeader.Columns[i]);
            if (i < dtSIFHeader.Columns.Count - 1)
                sb.Append(seperator);
        }
        sb.AppendLine();
        foreach (DataRow dr in dtSIFHeader.Rows)
        {
            for (int i = 0; i < dtSIFHeader.Columns.Count; i++)
            {
                sb.Append(dr[i].ToString());

                if (i < dtSIFHeader.Columns.Count - 1)
                    sb.Append(seperator);
            }
            sb.AppendLine();
        }
        return sb.ToString();

    }

    public DataTable GetTable()
    {
        clsBusinessLayerBankGuarantee ObjBussinessBankGuarnt = new clsBusinessLayerBankGuarantee();
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (Session["USERID"] != null)
        {
            ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"].ToString());

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
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
        if (ddlCurrency.SelectedItem.Value != "--SELECT CURRENCY--")
        {
            ObjEntityRequest.Currency = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
        }

        if (HiddenSearchField.Value == "")
        {
            if (Request.QueryString["default"] != null)
            {
                hiddenDefaultDashboard.Value = "1";

                ObjEntityRequest.PolicyType = 1;
                ddlPolicyType.ClearSelection();
                ddlPolicyType.Items.FindByValue("1").Selected = true;

                ddlCurrency.ClearSelection();
                ddlCurrency.Items.FindByValue("--SELECT CURRENCY--").Selected = true;
                ObjEntityRequest.Currency = 0;

                int typeid = 0;
                DateTime date = DateTime.Today; ;
                ObjEntityRequest.InsuranceProvider = 0;
                ObjEntityRequest.OpenDate = DateTime.MinValue;
                ObjEntityRequest.ToDate = DateTime.MinValue;
                ObjEntityRequest.ExpireDate = DateTime.MinValue;
                if (Request.QueryString["default"] == "3monthssup")
                {
                    ObjEntityRequest.CusSupSrch = 1;
                    // txtFromDate.Text = DateTime.Today.Date.ToString("dd-MM-yyyy");
                    // txtToDate.Text = (DateTime.Today.AddDays(90)).ToString("dd-MM-yyyy");
                    //HiddenSearchField.Value = "0";
                    //string d = DateTime.Today.AddDays(90).ToString();
                    string datetoexpiry = DateTime.Today.AddDays(90).ToString("dd-MM-yyyy");
                    string datetoday = DateTime.Today.Date.ToString("dd-MM-yyyy");
                    //date = DateTime.ParseExact(datetoexpiry, "dd-MM-yyyy", null);
                    //ObjEntityRequest.ExpireDate = DateTime.ParseExact(datetoexpiry, "dd-MM-yyyy", null);

                    ObjEntityRequest.FromDashboard = 1;
                    //ObjEntityRequest.ExpiryFromDate = DateTime.ParseExact(datetoday, "dd-MM-yyyy", null);
                    //  date = DateTime.Parse(DateTime.Today.AddDays(90).ToString("dd-MM-yyyy"));
                    if (Request.QueryString["InsUpd"] != null)
                    {
                        string strInsUpd = Request.QueryString["InsUpd"].ToString();
                        if (strInsUpd == "Upd")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                        }
                    }
                    pHeader.InnerHtml = "Supplier guarantees expiring in 3 months";
                    //ObjEntityRequest.GuartStsSrch = 0;
                    ddlGuaranteeStatus.ClearSelection();
                    ddlGuaranteeStatus.Items.FindByText("All").Selected = true;
                }
                else if (Request.QueryString["default"] == "3monthscus")
                {
                    // txtFromDate.Text = DateTime.Today.Date.ToString("dd-MM-yyyy");
                    // txtToDate.Text = (DateTime.Today.AddDays(90)).ToString("dd-MM-yyyy");
                    //HiddenSearchField.Value = "0";
                    //string d = DateTime.Today.AddDays(90).ToString();
                    ObjEntityRequest.CusSupSrch = 2;
                    string datetoexpiry = DateTime.Today.AddDays(90).ToString("dd-MM-yyyy");
                    string datetoday = DateTime.Today.Date.ToString("dd-MM-yyyy");
                    //date = DateTime.ParseExact(datetoexpiry, "dd-MM-yyyy", null);
                    // ObjEntityRequest.ExpireDate = DateTime.ParseExact(datetoexpiry, "dd-MM-yyyy", null);

                    ObjEntityRequest.FromDashboard = 1;
                    //ObjEntityRequest.ExpiryFromDate = DateTime.ParseExact(datetoday, "dd-MM-yyyy", null);
                    //  date = DateTime.Parse(DateTime.Today.AddDays(90).ToString("dd-MM-yyyy"));
                    if (Request.QueryString["InsUpd"] != null)
                    {
                        string strInsUpd = Request.QueryString["InsUpd"].ToString();
                        if (strInsUpd == "Upd")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                        }
                    }
                    pHeader.InnerHtml = "Client guarantees expiring in 3 months";
                    //ObjEntityRequest.GuartStsSrch = 0;
                    ddlGuaranteeStatus.ClearSelection();
                    ddlGuaranteeStatus.Items.FindByText("All").Selected = true;
                }
                else if (Request.QueryString["default"] == "expiredsup")
                {
                    ObjEntityRequest.CusSupSrch = 1;
                    BankGurntExpire.Text = (DateTime.Today.Date.ToString("dd-MM-yyyy"));

                    string datetemp = DateTime.Today.Date.ToString("dd-MM-yyyy");

                    date = DateTime.ParseExact(datetemp, "dd-MM-yyyy", null);
                    // ObjEntityRequest.ExpireDate = date;
                    ObjEntityRequest.FromDashboard = 2;
                    if (Request.QueryString["InsUpd"] != null)
                    {
                        string strInsUpd = Request.QueryString["InsUpd"].ToString();
                        if (strInsUpd == "Upd")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                        }
                    }
                    pHeader.InnerHtml = "Expired supplier guarantees ";
                    //ObjEntityRequest.GuartStsSrch = 0;
                    ddlGuaranteeStatus.ClearSelection();
                    ddlGuaranteeStatus.Items.FindByText("All").Selected = true;
                }
                else if (Request.QueryString["default"] == "expiredcus")
                {
                    BankGurntExpire.Text = (DateTime.Today.Date.ToString("dd-MM-yyyy"));

                    string datetemp = DateTime.Today.Date.ToString("dd-MM-yyyy");
                    ObjEntityRequest.CusSupSrch = 2;
                    date = DateTime.ParseExact(datetemp, "dd-MM-yyyy", null);
                    // ObjEntityRequest.ExpireDate = date;
                    ObjEntityRequest.FromDashboard = 2;

                    if (Request.QueryString["InsUpd"] != null)
                    {
                        string strInsUpd = Request.QueryString["InsUpd"].ToString();
                        if (strInsUpd == "Upd")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                        }
                    }
                    pHeader.InnerHtml = "Expired client guarantees";
                    //ObjEntityRequest.GuartStsSrch = 0;
                    ddlGuaranteeStatus.ClearSelection();
                    ddlGuaranteeStatus.Items.FindByText("All").Selected = true;
                }
                else if (Request.QueryString["default"] == "newsup")
                {
                    ObjEntityRequest.CusSupSrch = 1;
                    pHeader.InnerHtml = "Supplier guarantees under open status";
                    ObjEntityRequest.GuartStsSrch = 1;
                    ddlGuaranteeStatus.ClearSelection();
                    ddlGuaranteeStatus.Items.FindByText("All").Selected = true;
                }
                else if (Request.QueryString["default"] == "newcus")
                {
                    ObjEntityRequest.CusSupSrch = 2;
                    pHeader.InnerHtml = "Client guarantees under open status";
                    ObjEntityRequest.GuartStsSrch = 1;
                    ddlGuaranteeStatus.ClearSelection();
                    ddlGuaranteeStatus.Items.FindByText("All").Selected = true;
                }

                else if (Request.QueryString["default"] == "CurrntlyrungCus")
                {
                    clsCommonLibrary objCommon1 = new clsCommonLibrary();
                    ObjEntityRequest.CusSupSrch = 2;
                    string datetemp = DateTime.Today.Date.ToString("dd-MM-yyyy");

                    // date = DateTime.ParseExact(datetemp, "dd-MM-yyyy", null);
                    //ObjEntityRequest.ExpireDate = objCommon1.textToDateTime(datetemp);
                    ObjEntityRequest.FromDashboard = 4;

                    pHeader.InnerHtml = "Currently running client guarantees ";
                    //ObjEntityRequest.GuartStsSrch = 2;
                    ddlGuaranteeStatus.ClearSelection();
                    ddlGuaranteeStatus.Items.FindByText("Confirmed").Selected = true;

                    ddlCustSuplrsrch.ClearSelection();
                    ddlCustSuplrsrch.Items.FindByText("CUSTOMER").Selected = true;
                }

                else if (Request.QueryString["default"] == "CurrntlyrungSup")
                {
                    clsCommonLibrary objCommon1 = new clsCommonLibrary();
                    ObjEntityRequest.CusSupSrch = 1;
                    // BankGurntExpire.Text = (DateTime.Today.Date.ToString("dd-MM-yyyy"));

                    string datetemp = DateTime.Today.Date.ToString("dd-MM-yyyy");

                    // date = DateTime.ParseExact(datetemp, "dd-MM-yyyy", null);
                    // ObjEntityRequest.ExpireDate = objCommon1.textToDateTime(datetemp);
                    ObjEntityRequest.FromDashboard = 4;

                    pHeader.InnerHtml = "Currently running supplier guarantees ";
                    // ObjEntityRequest.GuartStsSrch = 2;
                    ddlGuaranteeStatus.ClearSelection();
                    ddlGuaranteeStatus.Items.FindByText("Confirmed").Selected = true;

                    ddlCustSuplrsrch.ClearSelection();
                    ddlCustSuplrsrch.Items.FindByText("SUPPLIER").Selected = true;
                }

                // ObjEntityRequest.Guarantee_Confirm_Status = typeid;
                ObjEntityRequest.GuarTypeId = 0;
                ObjEntityRequest.Guarantee_Method = 0;
                ObjEntityRequest.Biding = 0;
                ObjEntityRequest.Awarded = 0;
                ObjEntityRequest.CusSuply = 0;

                ObjEntityRequest.Cancel_Status = 0;
                ObjEntityRequest.BankId = 0;
                if (ddlCurrency.SelectedItem.Value != "--SELECT CURRENCY--")
                {
                    ObjEntityRequest.Currency = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
                }

                DataTable dtContract = new DataTable();
                if (ObjEntityRequest.SuplOrClient != 3)
                    //dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList(ObjEntityRequest);
                    dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList1(ObjEntityRequest);
            }
            else if (Request.QueryString["default_INSRNC"] != null)
            {
                hiddenDefaultDashboard.Value = "1";

                ObjEntityRequest.PolicyType = 2;
                ddlPolicyType.ClearSelection();
                ddlPolicyType.Items.FindByValue("2").Selected = true;

                ddlCurrency.ClearSelection();
                ddlCurrency.Items.FindByValue("--SELECT CURRENCY--").Selected = true;
                ObjEntityRequest.Currency = 0;

                DateTime date = DateTime.Today;

                ObjEntityRequest.InsuranceProvider = 0;
                ObjEntityRequest.OpenDate = DateTime.MinValue;
                ObjEntityRequest.ToDate = DateTime.MinValue;
                ObjEntityRequest.ExpireDate = DateTime.MinValue;
                ObjEntityRequest.GuarTypeId = 0;
                ObjEntityRequest.Cancel_Status = 0;
                ObjEntityRequest.GuartStsSrch = 0;

                if (Request.QueryString["default_INSRNC"] == "new")
                {//new status
                    pHeader.InnerHtml = "Insurances under open status";
                    ObjEntityRequest.GuartStsSrch = 1;
                }
                else if (Request.QueryString["default_INSRNC"] == "3months")
                {//expiry date within 3 months
                    pHeader.InnerHtml = "Insurances Expiring in 3 Months";
                    ObjEntityRequest.FromDashboard = 1;
                    ObjEntityRequest.GuartStsSrch = 0;
                    ddlGuaranteeStatus.ClearSelection();
                    ddlGuaranteeStatus.Items.FindByText("All").Selected = true;
                    if (Request.QueryString["InsUpd"] != null)
                    {
                        string strInsUpd = Request.QueryString["InsUpd_INSRNC"].ToString();
                        if (strInsUpd == "Upd")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation_insr", "SuccessUpdation_insr();", true);
                        }
                    }
                }
                else if (Request.QueryString["default_INSRNC"] == "expired")
                {//expiry date less than current date
                    pHeader.InnerHtml = "Expired insurances";
                    ObjEntityRequest.FromDashboard = 2;
                    ObjEntityRequest.GuartStsSrch = 0;
                    ddlGuaranteeStatus.ClearSelection();
                    ddlGuaranteeStatus.Items.FindByText("All").Selected = true;
                    if (Request.QueryString["InsUpd_INSRNC"] != null)
                    {
                        string strInsUpd = Request.QueryString["InsUpd_INSRNC"].ToString();
                        if (strInsUpd == "Upd")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation_insr", "SuccessUpdation_insr();", true);
                        }
                    }
                }
                else if (Request.QueryString["default_INSRNC"] == "CurrntlyRunng")
                {//expiry date greater than current date and null and confirmed
                    pHeader.InnerHtml = "Currently running insurance";
                    ObjEntityRequest.FromDashboard = 4;
                    ObjEntityRequest.GuartStsSrch = 2;
                    ddlGuaranteeStatus.ClearSelection();
                    ddlGuaranteeStatus.Items.FindByText("Confirmed").Selected = true;

                    //  ExpiryDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                }

                // DataTable dtInsurance = objBusinessInsurance.ReadInsuranceList(ObjEntityRequest);
                DataTable dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList1(ObjEntityRequest);
            }
            else
            {

                ObjEntityRequest.OpenDate = DateTime.MinValue;
                ObjEntityRequest.ToDate = DateTime.MinValue;
                ObjEntityRequest.GuarTypeId = 0;
                ObjEntityRequest.Guarantee_Method = 0;
                ObjEntityRequest.Biding = 0;
                ObjEntityRequest.Awarded = 0;
                ObjEntityRequest.CusSuply = 0;
                ObjEntityRequest.ExpireDate = DateTime.MinValue;
                ObjEntityRequest.Cancel_Status = 0;
                ObjEntityRequest.BankId = 0;
                ObjEntityRequest.GuartStsSrch = 0;
                if (ddlPolicyType.SelectedItem.Value != "" && ddlPolicyType.SelectedItem.Value != "--select--")
                {
                    ObjEntityRequest.PolicyType = Convert.ToInt32(ddlPolicyType.SelectedItem.Value);  //evm-0023
                }
                else
                {
                    ObjEntityRequest.PolicyType = 0;
                }
            }
        }
        else
        {
            string strHidden = "";
            strHidden = HiddenSearchField.Value;


            string[] strSearchFields = strHidden.Split(',');
            string strFromDate = strSearchFields[0];
            string strToDate = strSearchFields[1];
            string strGuaranteType = strSearchFields[2];
            string strGuaranteMode = strSearchFields[3];
            string strBiding = strSearchFields[4];
            string strAwarded = strSearchFields[5];
            string strddlCustSuplr = strSearchFields[6];
            string EspireDate = strSearchFields[7];
            string strCbxStatus = strSearchFields[8];
            string strBankId = strSearchFields[9];
            string strGuartSts = strSearchFields[10];
            string strCusSup = strSearchFields[11];
            string strInsurncPrvdr = strSearchFields[12];
            string strInsurPolicySts = strSearchFields[13];
            string strCurrency = strSearchFields[14];



            if (strFromDate != null && strFromDate != "")
            {

                txtFromDate.Text = strFromDate;
                ObjEntityRequest.OpenDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
                //if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                //{
                //    ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                //}
            }
            else
            {
                ObjEntityRequest.OpenDate = DateTime.MinValue;
            }
            if (strToDate != null && strToDate != "")
            {

                txtToDate.Text = strToDate;
                //if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                //{
                //    ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                //}
                ObjEntityRequest.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
            }
            else
            {
                ObjEntityRequest.ToDate = DateTime.MinValue;
            }
            if (strBiding == "1")
            {
                radioBinding.Checked = true;
                //if (ddlGuaranteCat.Items.FindByValue(strGuarantCat) != null)
                //{
                //    ddlGuaranteCat.Items.FindByValue(strGuarantCat).Selected = true;
                //}
                ObjEntityRequest.Biding = 1;
            }
            else if (strAwarded == "1")
            {
                radioAwdrd.Checked = true;
                ObjEntityRequest.Awarded = 1;
            }
            else if (strBiding == "0" && strAwarded == "0")
            {
                ObjEntityRequest.Biding = 0;
                ObjEntityRequest.Awarded = 0;
            }

            if (strGuaranteType != null && strGuaranteType != "")
            {
                if (ddlGuaranteeTyp.Items.FindByValue(strGuaranteType) != null)
                {
                    ddlGuaranteeTyp.ClearSelection();
                    ddlGuaranteeTyp.Items.FindByValue(strGuaranteType).Selected = true;
                    ObjEntityRequest.GuarTypeId = Convert.ToInt32(strGuaranteType);
                }
            }
            if (strGuaranteMode != null && strGuaranteMode != "")
            {
                if (ddlGuaranteeMde.Items.FindByValue(strGuaranteMode) != null)
                {
                    if (ddlGuaranteeMde.SelectedItem.Value != "--SELECT GUARANTEE MODE--")
                    {
                        ddlGuaranteeMde.ClearSelection();
                        ddlGuaranteeMde.Items.FindByValue(strGuaranteMode).Selected = true;
                        ObjEntityRequest.Guarantee_Method = Convert.ToInt32(strGuaranteMode);
                    }
                }
            }

            if (strddlCustSuplr != null && strddlCustSuplr != "")
            {
                if (HiddenFieldRadioCusSupl.Value == "1")
                {
                    if (ddlSuplCus.Items.FindByValue(strddlCustSuplr) != null)
                    {
                        if (ddlSuplCus.SelectedItem.Value != "--SELECT--")
                        {
                            ddlSuplCus.ClearSelection();
                            ddlSuplCus.Items.FindByValue(strddlCustSuplr).Selected = true;
                            ObjEntityRequest.CusSuply = Convert.ToInt32(strddlCustSuplr);
                        }
                    }
                }
                else
                {
                    if (ddlSup.Items.FindByValue(strddlCustSuplr) != null)
                    {
                        if (ddlSup.SelectedItem.Value != "--SELECT--")
                        {
                            ddlSup.ClearSelection();
                            ddlSup.Items.FindByValue(strddlCustSuplr).Selected = true;
                            ObjEntityRequest.CusSuply = Convert.ToInt32(strddlCustSuplr);

                        }
                    }
                }
            }

            if (EspireDate != null && EspireDate != "")
            {

                BankGurntExpire.Text = EspireDate;
                ObjEntityRequest.ExpireDate = objCommon.textToDateTime(BankGurntExpire.Text.Trim());
                //if (ddlCustomer.Items.FindByValue(strCustomer) != null)
                //{
                //    ddlCustomer.Items.FindByValue(strCustomer).Selected = true;
                //}
            }
            if (strBankId != null && strBankId != "")
            {
                if (ddlBankNm.Items.FindByValue(strBankId) != null)
                {
                    if (ddlBankNm.SelectedItem.Value != "--SELECT BANK--")
                    {
                        ddlBankNm.ClearSelection();
                        ddlBankNm.Items.FindByValue(strBankId).Selected = true;
                        ObjEntityRequest.BankId = Convert.ToInt32(strBankId);
                    }
                }
            }
            if (strGuartSts != null && strGuartSts != "")
            {
                if (ddlGuaranteeStatus.Items.FindByValue(strGuartSts) != null)
                {
                    ddlGuaranteeStatus.ClearSelection();

                    ddlGuaranteeStatus.Items.FindByValue(strGuartSts).Selected = true;
                    ObjEntityRequest.GuartStsSrch = Convert.ToInt32(strGuartSts);

                }
            }

            if (strInsurPolicySts != null && strInsurPolicySts != "")
            {
                if (ddlPolicyType.Items.FindByValue(strInsurPolicySts) != null)
                {
                    ddlPolicyType.ClearSelection();
                    ddlPolicyType.Items.FindByValue(strInsurPolicySts).Selected = true;
                    ObjEntityRequest.PolicyType = Convert.ToInt32(strInsurPolicySts);

                }
            }
            if (strCbxStatus == "1")
            {
                cbxCnclStatus.Checked = true;
            }
            else
            {
                cbxCnclStatus.Checked = false;
            }
            ObjEntityRequest.Cancel_Status = Convert.ToInt32(strCbxStatus);

            if (strCusSup != null && strCusSup != "")
            {
                if (ddlCustSuplrsrch.Items.FindByValue(strCusSup) != null)
                {
                    ddlCustSuplrsrch.ClearSelection();

                    ddlCustSuplrsrch.Items.FindByValue(strCusSup).Selected = true;
                    ObjEntityRequest.CusSupSrch = Convert.ToInt32(strCusSup);
                }
            }

            if (strCurrency != null && strCurrency != "--SELECT CURRENCY--")
            {
                if (ddlCurrency.Items.FindByValue(strCurrency) != null)
                {
                    ddlCurrency.ClearSelection();
                    ddlCurrency.Items.FindByValue(strCurrency).Selected = true;
                    ObjEntityRequest.Currency = Convert.ToInt32(strCurrency);
                }
            }
        }

        DataTable dt = new DataTable();
        if (ObjEntityRequest.SuplOrClient != 3)
            // dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList(ObjEntityRequest);
            dt = ObjBussinessBankGuarnt.ReadRequestGuaranteeList1(ObjEntityRequest);
        //  dt = ObjBussinessBankGuarnt.ReadRequestGuaranteeList(ObjEntityRequest);
        int ROWCNT = dt.Rows.Count;

        string policyName = "",policytyp="",insuranceTyp="";
        if (ddlPolicyType.SelectedItem.Value == "0")
        {
            policyName = "POLICY NUMBER";
            policytyp = "POLICY CATEGORY";
        }
        else if (ddlPolicyType.SelectedItem.Value == "1")
        {
            policyName = "GUARANTEE NUMBER";
            policytyp = "GUARANTEE TYPE";
        }
        else if (ddlPolicyType.SelectedItem.Value == "2")
        {
            policyName = "INSURANCE NUMBER";
            policytyp = "INSURANCE CATEGORY";
            insuranceTyp = "INSURANCE TYPE";
        }

        DataTable table = new DataTable();
        table.Columns.Add("REF#", typeof(string));
        table.Columns.Add("DATE", typeof(string));
        table.Columns.Add(policyName, typeof(string));
        if (ddlPolicyType.SelectedItem.Value == "2")
        {
            table.Columns.Add(insuranceTyp, typeof(string));
        }
        table.Columns.Add("EXPIRY DATE", typeof(string));
        table.Columns.Add(policytyp, typeof(string));
        table.Columns.Add("PROJECT REF#", typeof(string));
        table.Columns.Add("AMOUNT", typeof(string));
        table.Columns.Add("CURRENCY", typeof(string));

        // clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        string strRandom = objCommon.Random_Number();
        //if ((ddlBankNm.SelectedItem.Text != "--SELECT DIVISION--") || (ddl.SelectedItem.Text != "--SELECT PROJECT--"))
        //{
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string DATE = "";

            string PROJECT = "";
            string EXPIRED = "";
            string AMOUNT = "";
            string CURRENCY = "";
            string REf = "";
            string TYPE = "";
            string POLICY = "";
            string INSURTYP = "";
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                DateTime dateExDate = DateTime.MinValue;
                string strCurrentDate = objBusiness.LoadCurrentDateInString();
                DateTime dateCurrntdte = objCommon.textToDateTime(strCurrentDate);
                if (intColumnBodyCount == 0)
                {
                    if (dt.Rows[intRowBodyCount]["REF#"].ToString() != "")
                    {
                        REf = dt.Rows[intRowBodyCount]["REF#"].ToString();
                    }

                }
                else if (intColumnBodyCount == 2)
                {
                    if (dt.Rows[intRowBodyCount]["DATE"].ToString() != "" && dt.Rows[intRowBodyCount]["DATE"].ToString() != null)
                    {
                        DATE = dt.Rows[intRowBodyCount]["DATE"].ToString();
                    }
                    else
                    {
                        DATE = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                    }
                }

                else if (intColumnBodyCount == 1)
                {
                    if (dt.Rows[intRowBodyCount]["POLICY NUMBER"].ToString() != "")
                    {
                        POLICY = dt.Rows[intRowBodyCount]["POLICY NUMBER"].ToString();
                    }

                }
                else if (intColumnBodyCount == 8)
                {
                    if (ddlPolicyType.SelectedItem.Value == "2")
                    {
                        if (dt.Rows[intRowBodyCount]["INSURANCE TYPE"].ToString() != "")
                        {
                            INSURTYP = dt.Rows[intRowBodyCount]["INSURANCE TYPE"].ToString();
                        }
                    }
                }

                else if (intColumnBodyCount == 3)
                {
                    if (dt.Rows[intRowBodyCount]["EXPIRY DATE"].ToString() != "")
                        EXPIRED = dt.Rows[intRowBodyCount]["EXPIRY DATE"].ToString();
                }

                else if (intColumnBodyCount == 4)
                {
                    TYPE = dt.Rows[intRowBodyCount]["POLICY TYPE"].ToString();

                }

                else if (intColumnBodyCount == 5)
                {
                    if (dt.Rows[intRowBodyCount]["PROJECT REF#"].ToString() != "")
                    {
                        PROJECT = dt.Rows[intRowBodyCount]["PROJECT REF#"].ToString();
                    }
                    else
                        PROJECT = "";

                }

                else if (intColumnBodyCount == 6)
                {
                    string strNetAmount = dt.Rows[intRowBodyCount]["AMOUNT"].ToString();
                    string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                    AMOUNT = strNetAmountWithComma;
                }
                else if (intColumnBodyCount == 7)
                {
                    CURRENCY = dt.Rows[intRowBodyCount]["CURRENCY"].ToString();
                }
            }
            if (ddlPolicyType.SelectedItem.Value == "2")
            {
                table.Rows.Add('"' + REf + '"', '"' + DATE + '"', '"' + POLICY + '"', '"' + INSURTYP + '"', '"' + EXPIRED + '"', '"' + TYPE + '"', '"' + PROJECT + '"', '"' + AMOUNT + '"', '"' + CURRENCY + '"');
            }
            else
            {
                table.Rows.Add('"' + REf + '"', '"' + DATE + '"', '"' + POLICY + '"', '"' + EXPIRED + '"', '"' + TYPE + '"', '"' + PROJECT + '"', '"' + AMOUNT + '"', '"' + CURRENCY + '"');

            }

            // }
            // else
            //  {
            //      string DATE = "";
            //      string AGE = "";
            //      string PROJECT = "";
            //      string EXPIRED = "";
            //      string AMOUNT = "";
            //      string CURRENCY = "";
            //      string REf = "";
            //      string BANK = "";
            //      string CATEGORY = "";
            //      table.Rows.Add('"' + REf + '"', '"' + DATE + '"', '"' + CATEGORY + '"', '"' + EXPIRED + '"', '"' + AGE + '"', '"' + BANK + '"', '"' + PROJECT + '"', '"' + AMOUNT + '"', '"' + CURRENCY + '"');

            //}


        }

        return table;
    }


    protected void BtnCSV_Click(object sender, EventArgs e)
    {

        clsBusinessLayerBankGuarantee ObjBussinessBankGuarnt = new clsBusinessLayerBankGuarantee();
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dt = GetTable();
        string strResult = DataTableToCSV(dt, ',');
        string strImagePath = "";
        string filepath = "";
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        if (Session["ORGID"] != null)
        {
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        try
        {
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.BANKGUARANTEE_CSV);
            string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.BANKGUARANTEE_CSV);
            string newFilePath = Server.MapPath(strImagePath + "/Bank_Guarantee_csv" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "Bank_Guarantee_csv" + strNextId + ".csv";
            Response.ContentType = "csv";

            string CSVName = "";
            if (ddlPolicyType.SelectedItem.Value == "0")
            {
                CSVName = "Policy_csv" + strNextId + ".csv";
            }
            else if (ddlPolicyType.SelectedItem.Value == "1")
            {
                CSVName = "Bank_Guarantee_csv" + strNextId + ".csv";
            }
            else if (ddlPolicyType.SelectedItem.Value == "2")
            {
                CSVName = "Insurance_csv" + strNextId + ".csv";
            }

            Response.AddHeader("content-Disposition", "attachment;filename=\"" + CSVName + "\"");
            Response.TransmitFile(Server.MapPath(strImagePath) + filepath);
            Response.End();
            if (File.Exists(MapPath(strImagePath) + filepath))
            {
                File.Delete(MapPath(strImagePath) + filepath);
            }

        }
        catch (Exception)
        { }
    }

    //evm-0023
    public void LoadInsuranceType_Master()
    {
        clsBusinessLayerInsuranceMaster objBusinessInsurance = new clsBusinessLayerInsuranceMaster();
        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityInsurance.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtInsuranceTyp = objBusinessInsurance.ReadInsuranceTypes(objEntityInsurance);
        if (dtInsuranceTyp.Rows.Count > 0)
        {
            ddlInsurncTyp.DataSource = dtInsuranceTyp;
            ddlInsurncTyp.DataTextField = "INSRC_TYPMSTR_NAME";
            ddlInsurncTyp.DataValueField = "INSRC_TYPMSTR_ID";
            ddlInsurncTyp.DataBind();
        }
        ddlInsurncTyp.Items.Insert(0, "--SELECT INSURANCE TYPE--");
    }
}



