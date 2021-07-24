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

        divtile.InnerHtml = "Bank Guarantee";
        ddlGuaranteeMde.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlSuplCus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        if (!IsPostBack)
        {
            HiddenCurrentDate.Value = DateTime.Now.ToString("dd-MM-yyyy");
            btnNext.Enabled = false;
            btnPrevious.Enabled = false;
            HiddenFieldRadioCusSupl.Value = "";
            guaranteeModeLoad();
            BankLoad();
            SuplierLoad();
            CustomerLoad();
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
                Response.Redirect("//GMS/GMS_Master/gen_Notification_Template/gen_Notification_Template_List.aspx.aspx");
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
                       // divAdd.Visible = true;
                    }
                    else if (intEnableClient == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                      //  divAdd.Visible = true;
                    }
                    else
                    {
                      //  divAdd.Visible = false;
                    }

                }
                else
                {

                   // divAdd.Visible = false;

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


                    }
                    DataTable dtContract = new DataTable();
                    if (ObjEntityRequest.SuplOrClient != 3)
                        dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList(ObjEntityRequest);

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
                                 ObjEntityRequest.CusSupSrch =1;
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

                            }
                            DataTable dtContract = new DataTable();
                            if (ObjEntityRequest.SuplOrClient != 3)
                                dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList(ObjEntityRequest);

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
                    int typeid = 0;
                    DateTime date = DateTime.Today; ;
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
                    else if (Request.QueryString["default"] == "expiredsup")
                    {
                        ObjEntityRequest.CusSupSrch = 1;
                        BankGurntExpire.Text = (DateTime.Today.Date.ToString("dd-MM-yyyy"));

                        string datetemp = DateTime.Today.Date.ToString("dd-MM-yyyy");

                        date = DateTime.ParseExact(datetemp, "dd-MM-yyyy", null);
                        ObjEntityRequest.ExpireDate = date;
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
                    else if (Request.QueryString["default"] == "expiredcus")
                    {
                        BankGurntExpire.Text = (DateTime.Today.Date.ToString("dd-MM-yyyy"));

                        string datetemp = DateTime.Today.Date.ToString("dd-MM-yyyy");
                        ObjEntityRequest.CusSupSrch = 2;
                        date = DateTime.ParseExact(datetemp, "dd-MM-yyyy", null);
                        ObjEntityRequest.ExpireDate = date;
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
                    else if (Request.QueryString["default"] == "newsup")
                    {
                        ObjEntityRequest.CusSupSrch = 1;
                        pHeader.InnerHtml = "Gurantees Under Open Status";
                        ObjEntityRequest.GuartStsSrch = 1;
                        //ddlGuaranteeStatus.ClearSelection();
                        //ddlGuaranteeStatus.Items.FindByText("All").Selected = true;
                    }
                    else if (Request.QueryString["default"] == "newcus")
                    {
                        ObjEntityRequest.CusSupSrch = 2;
                        pHeader.InnerHtml = "Gurantees Under Open Status";
                        ObjEntityRequest.GuartStsSrch = 1;
                        //ddlGuaranteeStatus.ClearSelection();
                        //ddlGuaranteeStatus.Items.FindByText("All").Selected = true;
                    }
                    // ObjEntityRequest.Guarantee_Confirm_Status = typeid;
                    ObjEntityRequest.GuarTypeId = 0;
                    ObjEntityRequest.Guarantee_Method = 0;
                    ObjEntityRequest.Biding = 0;
                    ObjEntityRequest.Awarded = 0;
                    ObjEntityRequest.CusSuply = 0;

                    ObjEntityRequest.Cancel_Status = 0;
                    ObjEntityRequest.BankId = 0;
               
                    DataTable dtContract = new DataTable();
                    if (ObjEntityRequest.SuplOrClient != 3)
                        dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList(ObjEntityRequest);
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
                    Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd=CONF");
                }
                else
                {
                    Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd=CONFCHK");
                }
                }

                else
                {
                    //to view
                    if (HiddenSearchField.Value == "")
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
                            ObjEntityRequest.GuartStsSrch = 0;
                           // ObjEntityRequest.CusSupSrch = 1;
                            ddlGuaranteeStatus.ClearSelection();
                            ddlGuaranteeStatus.Items.FindByText("All").Selected = true;
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
                        if (strCbxStatus == "1")
                        {
                            cbxCnclStatus.Checked = true;
                        }
                        else
                        {
                            cbxCnclStatus.Checked = false;
                        }
                        ObjEntityRequest.Cancel_Status = Convert.ToInt32(strCbxStatus);
                    }
                    DataTable dtContract = new DataTable();
                    if (ObjEntityRequest.SuplOrClient != 3)
                        dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList(ObjEntityRequest);

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


    public string ConvertDataTableForPrint(DataTable dt)
    {

        clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "Bank Guarantee List";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        //for printing product division on print
        string strHidden = "", FromDate = "", ToDate = "", GuaranteType = "", GuaranteMde = "", Biding = "", Awarded = "", CustOrSupl = "", ExpireDate = "", DeleteSts = "", BankId = "", GuranteSts = "";


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
            string strddlcussup = strSearchFields[11];
            if (strFromDate != null && strFromDate != "")
            {
                FromDate = "<B>From Date  : </B>" + strFromDate;
            }
            if (strToDate != null && strToDate != "")
            {
                ToDate = "<B>To Date  : </B>" + strToDate;
            }
            if (strGuaranteType != null && strGuaranteType != "")
            {
                if (ddlGuaranteeTyp.Items.FindByValue(strGuaranteType) != null)
                {
                    GuaranteType = "<B>Guarantee Type : </B>" + ddlGuaranteeTyp.SelectedItem.Text;
                }
            }
            if (strGuaranteMode != null && strGuaranteMode != "")
            {
                if (ddlGuaranteeMde.Items.FindByValue(strGuaranteMode) != null)
                {
                    if (ddlGuaranteeMde.SelectedItem.Value != "--SELECT GUARANTEE MODE--")
                    {
                        GuaranteMde = "<B>Guarantee Mode : </B>" + ddlGuaranteeMde.SelectedItem.Text;
                    }
                }
            }
            if (strBiding == "1")
            {
                Biding = "<B> Guarantee Category  : </B> Bidding";

            }
            else if (strAwarded == "1")
            {
                Biding = "<B> Guarantee Category  : </B> Awarded";

            }
            else if (strBiding == "0" && strAwarded == "0")
            {

            }
          

                if (HiddenFieldRadioCusSupl.Value == "1")
                {
                    if (ddlSuplCus.Items.FindByValue(strddlCustSuplr) != null)
                    {
                        if (ddlSuplCus.SelectedItem.Value != "--SELECT--")
                        {
                            CustOrSupl = "<B> Customer  : </B>" + ddlSuplCus.SelectedItem.Text;
                        }
                    }
                }
                else
                {
                    if (ddlSup.Items.FindByValue(strddlCustSuplr) != null)
                    {
                        if (ddlSup.SelectedItem.Value != "--SELECT--")
                        {
                            CustOrSupl = "<B> Supplier  : </B>" + ddlSup.SelectedItem.Text;

                        }
                    }
                }
            

            if (EspireDate != null && EspireDate != "")
            {

                ExpireDate = "<B>Expire Date  : </B>" + EspireDate;
            }

            if (strBankId != null && strBankId != "")
            {
                if (ddlBankNm.Items.FindByValue(strBankId) != null)
                {
                    if (ddlBankNm.SelectedItem.Value != "--SELECT BANK--")
                    {
                        BankId = "<B>Bank Name : </B>" + ddlBankNm.SelectedItem.Text;
                    }
                }
            }
            if (strGuartSts != null && strGuartSts != "")
            {
                if (ddlGuaranteeStatus.Items.FindByValue(strGuartSts) != null)
                {
                    GuranteSts = "<B>Guarantee Status : </B>" + ddlGuaranteeStatus.SelectedItem.Text;

                }
            }
            //if (strCbxStatus == "1")
            //{
            //    cbxCnclStatus.Checked = true;
            //}
            //else
            //{
            //    cbxCnclStatus.Checked = false;
            //}

        }
        else
        {
            GuaranteType = "<B>Guarantee Type : </B>" + ddlGuaranteeTyp.SelectedItem.Text;
            GuranteSts = "<B>Guarantee Status : </B>" + ddlGuaranteeStatus.SelectedItem.Text;
            //ToDate=

        }




        //if (dtCorp.Rows.Count > 0)
        //{
        //    strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
        //    strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
        //    strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
        //    strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
        //    strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
        //}
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        //  string strCompanyAddr = objClsCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);

        StringBuilder sbCap = new StringBuilder();



        string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
        //string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
        //string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr + "</td></tr>";
        string strCaptionTabRprtDate = "", strCaptionTabTitle = "", strFromDteTitle = "", strToDateTitle = "", strGuaranteTypeTitle = "", strGuaranteMdeTitle = "", strBidingTitle = "",
            strCustOrSuplTitle = "", strExpireDateTitle = "", strBankIdTitle = "", strGuranteStsTitle = "";
        if (dat != "")
        {
            strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
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
        if (GuaranteType != "")
        {
            strGuaranteTypeTitle = "<tr><td class=\"RprtDiv\">" + GuaranteType + "</td></tr>";
        }
        if (GuaranteMde != "")
        {
            strGuaranteMdeTitle = "<tr><td class=\"RprtDiv\">" + GuaranteMde + "</td></tr>";
        }
        if (Biding != "")
        {
            strBidingTitle = "<tr><td class=\"RprtDiv\">" + Biding + "</td></tr>";
        }
        if (CustOrSupl != "")
        {
            strCustOrSuplTitle = "<tr><td class=\"RprtDiv\">" + CustOrSupl + "</td></tr>";
        }
        if (ExpireDate != "")
        {
            strExpireDateTitle = "<tr><td class=\"RprtDiv\">" + ExpireDate + "</td></tr>";
        }
        if (BankId != "")
        {
            strBankIdTitle = "<tr><td class=\"RprtDiv\">" + BankId + "</td></tr>";
        }
        if (GuranteSts != "")
        {
            strGuranteStsTitle = "<tr><td class=\"RprtDiv\">" + GuranteSts + "</td></tr>";
        }

        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabRprtDate + strCaptionTabTitle + strFromDteTitle + strToDateTitle + strGuaranteTypeTitle + strGuaranteMdeTitle +
            strBidingTitle + strCustOrSuplTitle + strExpireDateTitle + strBankIdTitle + strGuranteStsTitle + strCaptionTabstop;



        sbCap.Append(strPrintCaptionTable);
        ////write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString();


        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {


            if (intColumnHeaderCount == 1)
            {
                strHtml += "<td class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">" + "GUARANTEE NUMBER" + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<td class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + "DATE" + "</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<td class=\"thT\" style=\"width:32%;text-align: left; word-wrap:break-word;\">" + "CUSTOMER/SUPPLIER" + "</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:22%;text-align: right; word-wrap:break-word;\">" + "AMOUNT" + "</th>";
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
                    strHtml += "<td class=\"rowHeight1\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"rowHeight1\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"rowHeight1\" style=\" width:32%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 4)
                {

                    string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                    string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                    strHtml += "<td class=\"tdT\" style=\" width:22%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + strNetAmountWithComma.ToString() + "</td>";
                }

            }
            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();

    }



    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intEnableRecall, int intEnableClose, int intEnableRenew, int intEnableConfirm)
    {
        string strQueryStr = "";
        if (Request.QueryString["default"] != null)
        {
            if (Request.QueryString["default"] == "3months")
            {
                strQueryStr = "&default=3months";
            }
            else if (Request.QueryString["default"] == "expired")
            {
                strQueryStr = "&default=expired";
            }
            else if (Request.QueryString["default"] == "new")
            {
                strQueryStr = "&default=new";
            }
        }

        int CustorsuplChk = Convert.ToInt32(ddlCustSuplrsrch.SelectedItem.Value);
        int first = Convert.ToInt32(hiddenPrevious.Value);

        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        clsBusinessLayerBankGuarantee ObjBussinessBankGuarnt = new clsBusinessLayerBankGuarantee();
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        //DateTime dateCurnt;
        //DateTime dateFrm, dateTo,dateHolConfm,dateLeavConfm;
        //DataTable LeavAllocChk;
        DateTime DateCurrent = objBusiness.LoadCurrentDate();
        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        // strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";

        //for assigning column for reopen
        int intConfirmedForHead = 0;
        int intReCallForTAble = 0;
        int intClosedHead = 0;
        int intConfirmNew = 0;
        int intRenewed = 0;
        for (int intRowBodyCount = first; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string ConfirmedTransaction = dt.Rows[intRowBodyCount]["GUARANTEE_STATUS"].ToString();
            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());

            if (Request.QueryString["default"] != null)
            {
                intConfirmNew = 1;
            }

            if (ConfirmedTransaction == "2")
            {
                intConfirmedForHead = 1;
                // intConfirmNew = 1;
            }

            if (ConfirmedTransaction == "1")
            {
                intConfirmNew = 1;
            }
            if (ConfirmedTransaction == "4")
            {
                intClosedHead = 1;
            }
            else
            {
                intClosedHead = 0;
            }
            if (ConfirmedTransaction == "3")
            {
                intRenewed = 1;
            }

            if (intCnclUsrId != 0)
            {
                intReCallForTAble = 1;
                HiddenIntCanlId.Value = "1";
            }
            else
            {
                HiddenIntCanlId.Value = "0";
            }

        }


        strHtml += "<th class=\"thT\" style=\"width:3%;text-align: left; word-wrap:break-word;\"><input type=\"checkbox\" Id=\"cbxSelectAll\" OnkeyPress=\"return DisableEnter(event)\" style=\"margin-left: 8%;\" onchange=\"selectAllGuarantee()\"></th>";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            //if (i == 0)
            //{
            //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
            //}

        

            if (intColumnHeaderCount == 1)
            {

                strHtml += "<th class=\"thT\" style=\"width:18%;text-align: left; word-wrap:break-word;\">" + "GUARANTEE NUMBER" + "</th>";

            }
            if (intColumnHeaderCount == 2)
            {

                strHtml += "<th class=\"thT\" style=\"width:12%; word-wrap:break-word; text-align: center;\">" + "DATE" + "</th>";

            }
            else if (intColumnHeaderCount == 3)
            {
                if (CustorsuplChk == 1)
                {
                    strHtml += "<th class=\"thT\"  style=\"width:26%;text-align: left; word-wrap:break-word;\">" + "SUPPLIER" + "</th>";
                }
                else
                {
                    strHtml += "<th class=\"thT\"  style=\"width:26%;text-align: left; word-wrap:break-word;\">" + "CUSTOMER" + "</th>";
                }

            }

            else if (intColumnHeaderCount == 4)
            {

                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: right; word-wrap:break-word;\">" + "AMOUNT" + "</th>";

            }
            else if (intColumnHeaderCount == 5)
            {

                strHtml += "<th class=\"thT\"  style=\"width:12%;text-align: center; word-wrap:break-word;\">" + "EXPIRY DATE" + "</th>";

            }
            else if (intColumnHeaderCount == 6)
            {

                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">" + "GUARANTEE TYPE" + "</th>";

            }



        }


      


        // }


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        hiddenRowCount.Value = dt.Rows.Count.ToString();
        strHtml += "<tbody>";
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

                        int intConfirmed, intClosed, intRenew, intnew;
                        int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
                        int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());
                        string ConfirmedTransaction = dt.Rows[intRowBodyCount]["GUARANTEE_STATUS"].ToString();
                        HiddenGurantNum.Value = dt.Rows[intRowBodyCount]["GUARANTEE_NUMBER"].ToString();
                        if (ConfirmedTransaction == "2")
                        {
                            intConfirmed = 1;
                        }
                        else
                        {
                            intConfirmed = 0;
                        }
                        if (ConfirmedTransaction == "4")
                        {
                            intClosed = 1;
                        }
                        else
                        {
                            intClosed = 0;
                        }
                        if (ConfirmedTransaction == "1")
                        {
                            intnew = 1;
                        }
                        else
                        {
                            intnew = 0;
                        }
                        if (ConfirmedTransaction == "3")
                        {
                            intRenew = 1;
                        }
                        else
                        {
                            intRenew = 0;
                        }



                        strHtml += "<tr  >";

                        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" Id=\"cblguaranteelist" + intRowBodyCount + "\"true\" onchange=\"IncrmntConfrmCounter()\" OnkeyPress=\"return DisableEnter(event)\" value=\"" + dt.Rows[intRowBodyCount][0].ToString() + " \"></td>";

                        for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                        {

                            if (intColumnBodyCount == 1)
                            {

                                strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                            }
                            if (intColumnBodyCount == 2)
                            {

                                strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word; text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                            }
                            else if (intColumnBodyCount == 3)
                            {

                                strHtml += "<td class=\"tdT\" style=\" width:26%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                            }
                            else if (intColumnBodyCount == 4)
                            {
                                string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                                string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);

                                strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + strNetAmountWithComma.ToString() + "</td>";

                            }
                            else if (intColumnBodyCount == 5)
                            {
                                //if Limited
                                if (dt.Rows[intRowBodyCount][6].ToString() == "Limited")
                                {
                                    //Limited
                                    if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() != "")
                                    {
                                        //DateTime DateExpire = String.Format("{0:MM/dd/yyyy}",dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                                        DateTime DateExpire = objCommon.textToDateTime(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                                        if (DateExpire < DateCurrent)
                                        {
                                            intExpiredSts = 1;
                                        }
                                    }
                                }
                                strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                            }
                            else if (intColumnBodyCount == 6)
                            {

                                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

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
                    int intConfirmed, intClosed, intRenew, intnew;
                    int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
                    int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());
                    string ConfirmedTransaction = dt.Rows[intRowBodyCount]["GUARANTEE_STATUS"].ToString();
                    HiddenGurantNum.Value = dt.Rows[intRowBodyCount]["GUARANTEE_NUMBER"].ToString();
                    if (ConfirmedTransaction == "2")
                    {
                        intConfirmed = 1;
                    }
                    else
                    {
                        intConfirmed = 0;
                    }
                    if (ConfirmedTransaction == "4")
                    {
                        intClosed = 1;
                    }
                    else
                    {
                        intClosed = 0;
                    }
                    if (ConfirmedTransaction == "1")
                    {
                        intnew = 1;
                    }
                    else
                    {
                        intnew = 0;
                    }
                    if (ConfirmedTransaction == "3")
                    {
                        intRenew = 1;
                    }
                    else
                    {
                        intRenew = 0;
                    }



                    strHtml += "<tr  >";

                    strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" Id=\"cblguaranteelist" + intRowBodyCount + "\"true\" onchange=\"IncrmntConfrmCounter()\" value=\"" + dt.Rows[intRowBodyCount][0].ToString() + " \"></td>";

                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {

                        if (intColumnBodyCount == 1)
                        {

                            strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                        }
                        if (intColumnBodyCount == 2)
                        {

                            strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word; text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                        }
                        else if (intColumnBodyCount == 3)
                        {

                            strHtml += "<td class=\"tdT\" style=\" width:21%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                        }
                        else if (intColumnBodyCount == 4)
                        {
                            string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                            string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);

                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + strNetAmountWithComma.ToString() + "</td>";

                        }
                        else if (intColumnBodyCount == 5)
                        {
                            //if Limited
                            if (dt.Rows[intRowBodyCount][6].ToString() == "Limited")
                            {
                                //Limited
                                if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() != "")
                                {
                                    //DateTime DateExpire = String.Format("{0:MM/dd/yyyy}",dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                                    DateTime DateExpire = objCommon.textToDateTime(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                                    if (DateExpire < DateCurrent)
                                    {
                                        intExpiredSts = 1;
                                    }
                                }
                            }
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                        }
                        else if (intColumnBodyCount == 6)
                        {

                            strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                        }

                    }
                    string strId = dt.Rows[intRowBodyCount][0].ToString();
                    int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                    string stridLength = intIdLength.ToString("00");
                    string Id = stridLength + strId + strRandom;




                   
      



                    strHtml += "</tr>";
                }
                else
                {
                    btnNext.Enabled = true;
                }
            }

        }
        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        pHeader.Visible = false;
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
           // ObjEntityRequest.CusSupSrch = 1;
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
        }
        DataTable dtContract = new DataTable();
        if (ObjEntityRequest.SuplOrClient != 3)
            dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList(ObjEntityRequest);

        string strHtm = ConvertDataTableToHTML(dtContract, intEnableModify, intEnableCancel, intEnableRecall, intEnableClose, intEnableRenew, intEnableConfirm);
        //Write to divReport
        divReport.InnerHtml = strHtm;
        string strPrintReport = ConvertDataTableForPrint(dtContract);
        divPrintReport.InnerHtml = strPrintReport;
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
               // divAdd.Visible = true;
            }
            else if (intEnableClient == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
               // divAdd.Visible = true;
            }
            else
            {
               // divAdd.Visible = false;
            }

        }
        else
        {

           // divAdd.Visible = false;

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
        }
        //from dashboard

        if (Request.QueryString["default"] != null)
        {
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

                date = DateTime.ParseExact(datetemp, "dd-MM-yyyy", null);
                ObjEntityRequest.ExpireDate = date;
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
            

        }
        DataTable dtContract = new DataTable();
        if (ObjEntityRequest.SuplOrClient != 3)
            dtContract = ObjBussinessBankGuarnt.ReadRequestGuaranteeList(ObjEntityRequest);

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
    protected void btnmodify_Click(object sender, EventArgs e)
    {
        //ScriptManager.RegisterStartupScript(this, GetType(), "closepopup", "closepopup();", true);

    }
}
